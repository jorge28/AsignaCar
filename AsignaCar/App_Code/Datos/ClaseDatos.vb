Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class ClaseDatos
#Region " Declaracion de variables "
    Protected conexion As ClaseConexion
    Protected SQLRead As SqlClient.SqlDataReader
    Protected lDataTabla As DataTable
    Protected lDataset As DataSet
    Protected SQLquery As String = ""
    Protected lCampos As String = ""
    Protected lWhere As String = ""
    Protected lCadena As String = ""
    Protected i, j, n, m, swKey, swCampo As Integer
    Protected mTranasaccion As SqlClient.SqlTransaction
    Protected mTranasaccionEstado As Boolean = False
    Protected mTranasaccionError As Boolean = False
#End Region
    Public Sub New()
        conexion = New ClaseConexion()
    End Sub
    'Public Sub New(ByVal con As ClaseConexion)
    '    conexion = con
    'End Sub
#Region " Transaccion "
    Public Sub TransaccionIniciar()
        conexion.TransaccionIniciar(mTranasaccion)
        mTranasaccionEstado = True
        mTranasaccionError = False
    End Sub
    Public Sub TransaccionTerminar()
        If mTranasaccionError = True Then
            If mTranasaccionEstado Then
                mTranasaccion.Rollback()
                mTranasaccionEstado = False
            End If
        Else
            If mTranasaccionEstado Then
                mTranasaccion.Commit()
                mTranasaccionEstado = False
            End If
        End If
    End Sub
    Public Property TransaccionEstado() As Boolean
        Get
            Return mTranasaccionEstado
        End Get
        Set(ByVal value As Boolean)

        End Set
    End Property

    Public Property TransaccionError() As Boolean
        Get
            Return mTranasaccionError
        End Get
        Set(ByVal value As Boolean)
            mTranasaccionError = value
        End Set
    End Property

    Public Function Transaccion() As SqlClient.SqlTransaction
        Return mTranasaccion
    End Function
#End Region

    Public Function GetConexion() As ClaseConexion
        Return conexion
    End Function
    Public Sub SQLQueryCerrar()
        conexion.CerraLectorDatos()
    End Sub

    'Crear Query String
    Private Function GetNuevoCodigo(ByVal TablaNombre As String, ByVal CampoNombre As String) As Integer
        Dim retorno As Integer = 0
        Dim vlSqlQuery As String = ""
        Dim vlTabla As DataTable
        Try
            vlSqlQuery = "SELECT MAX( " & CampoNombre & " ) AS Maximo FROM " & TablaNombre & " "
            vlTabla = conexion.GetDataTable(vlSqlQuery)
            retorno = vlTabla.Rows(0).Item(0)
        Catch ex As Exception
        End Try
        retorno = retorno + 1
        Return retorno
    End Function
    Private Function GetSQLQueryInsertGenerarCodigo(ByRef Clase As Object) As String
        Dim retorno As String = ""
        Dim vlNewCodigo As Integer
        Dim i As Integer
        n = Clase.TablaTamaño
        swKey = 0
        For i = 0 To n
            If (Clase.mTablaCampos.SacarTipo(i) = TipoDato.Cadena) Then
                Me.lCadena = "'"
            Else
                lCadena = ""
            End If
            If (Clase.mTablaCampos.SacarKey(i) = PrimaryKey.si And Clase.mTablaCampos.SacarTipo(i) = TipoDato.Numero) Then
                If (swKey = 0) Then
                    vlNewCodigo = GetNuevoCodigo(Clase.mTablaNombre, Clase.mTablaCampos.SacarNombre(i))
                    Clase.mTablaCampos.PonerValor(i, vlNewCodigo)
                    swKey = 1
                End If
            End If
            If i = 0 Then
                If swKey = 1 Then
                    lCampos = lCadena & vlNewCodigo & lCadena
                Else
                    lCampos = lCadena & Clase.mTablaCampos.SacarValor(i) & lCadena
                End If
            Else
                If swKey = 1 Then
                    lCampos = lCampos & "," & lCadena & vlNewCodigo & lCadena
                Else
                    lCampos = lCampos & "," & lCadena & Clase.mTablaCampos.SacarValor(i) & lCadena
                End If
            End If
            If (swKey = 1) Then
                swKey = swKey + 1
            End If
        Next
        retorno = "insert into " & Clase.mTablaNombre & " values(" & lCampos & ")"
        Return retorno
    End Function
    Private Function GetSQLQueryInsertNoGenerarCodigo(ByVal Clase As Object) As String
        Dim retorno As String = ""
        Dim i As Integer
        n = Clase.TablaTamaño
        For i = 0 To n
            If (Clase.mTablaCampos.SacarTipo(i) = TipoDato.Cadena) Then
                Me.lCadena = "'"
            Else
                lCadena = ""
            End If
            If i = 0 Then
                lCampos = lCadena & Clase.mTablaCampos.SacarValor(i) & lCadena
            Else
                lCampos = lCampos & "," & lCadena & Clase.mTablaCampos.SacarValor(i) & lCadena
            End If
        Next
        retorno = "insert into " & Clase.mTablaNombre & " values(" & lCampos & ")"
        Return retorno
    End Function
    Private Function GetSQLQueryUpDate(ByVal Clase As Object) As String
        Dim retorno As String = ""
        Dim i As Integer
        n = Clase.TablaTamaño
        swKey = 0
        For i = 0 To n
            If (Clase.mTablaCampos.SacarTipo(i) = TipoDato.Cadena) Then
                lCadena = "'"
            Else
                lCadena = ""
            End If
            If i = 0 Then
                lCampos = Clase.mTablaCampos.SacarNombre(i) & " = " & lCadena & Clase.mTablaCampos.SacarValor(i) & lCadena
            Else
                lCampos = lCampos & "," & Clase.mTablaCampos.SacarNombre(i) & " = " & lCadena & Clase.mTablaCampos.SacarValor(i) & lCadena
            End If
            If (Clase.mTablaCampos.SacarKey(i) = PrimaryKey.si) Then
                If (swKey = 0) Then
                    lWhere = Clase.mTablaCampos.SacarNombre(i) & " = " & lCadena & Clase.mTablaCampos.SacarValor(i) & lCadena
                    swKey = 1
                Else
                    lWhere = lWhere & " AND " & Clase.mTablaCampos.SacarNombre(i) & " = " & lCadena & Clase.mTablaCampos.SacarValor(i) & lCadena
                End If
            End If
        Next
        retorno = "UPDATE  " & Clase.mTablaNombre & "  SET " & lCampos & " WHERE " & lWhere
        Return retorno
    End Function
    Private Function GetSQLQuerySelect(ByVal Clase As Object) As String
        Dim retorno As String = ""
        Dim i As Integer
        n = Clase.TablaTamaño
        swKey = 0
        For i = 0 To n
            If (Clase.mTablaCampos.SacarTipo(i) = TipoDato.Cadena) Then
                lCadena = "'"
            Else
                lCadena = ""
            End If
            If i = 0 Then
                lCampos = Clase.mTablaCampos.SacarNombre(i)
            Else
                lCampos = lCampos & "," & Clase.mTablaCampos.SacarNombre(i)
            End If
            If (Clase.mTablaCampos.SacarKey(i) = PrimaryKey.si) Then
                If (swKey = 0) Then
                    lWhere = Clase.mTablaCampos.SacarNombre(i) & " = " & lCadena & Clase.mTablaCampos.SacarValor(i) & lCadena
                    swKey = 1
                Else
                    lWhere = lWhere & " AND " & Clase.mTablaCampos.SacarNombre(i) & " = " & lCadena & Clase.mTablaCampos.SacarValor(i) & lCadena
                End If
            End If
        Next
        retorno = "select " & lCampos & " from " & Clase.mTablaNombre & " where " & lWhere
        Return retorno
    End Function
    Private Function GetSQLQueryDelete(ByVal Clase As Object) As String
        Dim retorno As String = ""
        Dim i As Integer
        n = Clase.TablaTamaño
        swKey = 0
        For i = 0 To n
            If (Clase.mTablaCampos.SacarTipo(i) = TipoDato.Cadena) Then
                lCadena = "'"
            Else
                lCadena = ""
            End If

            If (Clase.mTablaCampos.SacarKey(i) = PrimaryKey.si) Then
                If (swKey = 0) Then
                    lWhere = Clase.mTablaCampos.SacarNombre(i) & " = " & lCadena & Clase.mTablaCampos.SacarValor(i) & lCadena
                    swKey = 1
                Else
                    lWhere = lWhere & " AND " & Clase.mTablaCampos.SacarNombre(i) & " = " & lCadena & Clase.mTablaCampos.SacarValor(i) & lCadena
                End If
            End If
        Next
        retorno = "Delete From  " & Clase.mTablaNombre & " WHERE " & lWhere
        Return retorno
    End Function
    Private Function GetSQLQueryListaDeCodigo(ByVal Clase As Object) As String
        Dim retorno As String = ""
        Dim i As Integer
        n = Clase.TablaTamaño
        swKey = 0
        For i = 0 To n - 1
            If (Clase.mTablaCampos.SacarTipo(i) = TipoDato.Cadena) Then
                lCadena = "'"
            Else
                lCadena = ""
            End If
            If (swKey = 0 And Clase.mTablaCampos.SacarKey(i) = PrimaryKey.si) Then
                lCampos = Clase.mTablaCampos.SacarNombre(i)
                swKey = swKey + 1
            Else
                swKey = swKey + 1
                lCampos = lCampos & " , " & Clase.mTablaCampos.SacarNombre(i)
            End If
        Next
        retorno = "select " & lCampos & "from " & Clase.mTablaNombre
        Return retorno
    End Function
    Private Function GetSQLQuery(ByVal Clase As Object) As String
        Dim retorno As String = ""
        Dim i As Integer
        n = Clase.TablaTamaño
        swKey = 0
        For i = 0 To n
            If (Clase.mTablaCampos.SacarTipo(i) = TipoDato.Cadena) Then
                lCadena = "'"
            Else
                lCadena = ""
            End If
            If i = 0 Then
                lCampos = Clase.mTablaCampos.SacarNombre(i)
            Else
                lCampos = lCampos & "," & Clase.mTablaCampos.SacarNombre(i)
            End If
        Next
        retorno = "select " & lCampos & " from " & Clase.mTablaNombre
        Return retorno
    End Function
    'ABC de la tabla
    Public Sub RegistroAgregarNoGenerarCodigo(ByVal Clase As Object)
        Try
            conexion.AbrirConexion()
            SQLquery = GetSQLQueryInsertNoGenerarCodigo(Clase)
            conexion.SQLNoQuery(SQLquery, Me)
            conexion.CerrarConexion()
        Catch ex As Exception
            If TransaccionEstado() Then
                Me.TransaccionError = True
            End If
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub RegistroAgregarGenerarCodigo(ByRef Clase As Object)
        Try
            conexion.AbrirConexion()
            SQLquery = GetSQLQueryInsertGenerarCodigo(Clase)
            conexion.SQLNoQuery(SQLquery, Me)
            conexion.CerrarConexion()
        Catch ex As Exception
            If TransaccionEstado() Then
                Me.TransaccionError = True
            End If
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub RegistroActualizar(ByVal Clase As Object)
        Try
            conexion.AbrirConexion()
            SQLquery = GetSQLQueryUpDate(Clase)
            conexion.SQLNoQuery(SQLquery, Me)
            conexion.CerrarConexion()
        Catch ex As Exception
            If TransaccionEstado() Then
                Me.TransaccionError = True
            End If
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub RegistroRecuperar(ByRef Clase As Object, Optional ByVal SQLquery As String = "")
        Dim lTabla As DataTable
        Try
            Dim i, n As Integer
            SQLquery = GetSQLQuerySelect(Clase)
            lTabla = conexion.GetDataTable(SQLquery)
            n = lTabla.Columns.Count
            For i = 0 To n - 1
                Clase.mTablaCampos.PonerValor(i, lTabla.Rows(0).Item(i))
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub RegistroEliminar(ByRef Clase As Object)
        Try
            SQLquery = GetSQLQueryDelete(Clase)
            SQLRead = conexion.SQLQuery(SQLquery, Me)
            SQLQueryCerrar()
        Catch ex As Exception
            If TransaccionEstado() Then
                Me.TransaccionError = True
            End If
            MsgBox(ex.Message)
        End Try
    End Sub
    'Operaciones y comprobaciones de la tabla
    Public Function RegistroExiste(ByRef Clase As Object) As Boolean
        Dim retorno As Boolean = False
        Try
            SQLquery = GetSQLQuerySelect(Clase)
            SQLRead = conexion.SQLQuery(SQLquery, Me)
            If (SQLRead.Read And SQLRead.HasRows = True) Then ' If (read.Read And read.HasRows = False) Then
                retorno = True
            End If
            SQLQueryCerrar()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return retorno
    End Function
    Public Function RegistroListaCodigos(ByRef Clase As Object) As ArrayList
        Dim retorno As ArrayList = New ArrayList
        Dim i As Integer
        Dim J As Integer
        Dim CamposCodigo() As String
        Try
            SQLquery = GetSQLQueryListaDeCodigo(Clase)
            lDataTabla = conexion.GetDataTable(SQLquery)
            n = lDataTabla.Rows.Count
            m = lDataTabla.Columns.Count
            For i = 0 To n - 1
                'ReDim Preserve CamposCodigo(CantidadCamposCodigo)
                ReDim CamposCodigo(m)
                'CamposCodigo = New String(n) {}
                For j = 0 To m - 1
                    CamposCodigo(j) = lDataTabla.Rows(i).Item(j)
                Next
                retorno.Add(CamposCodigo)
            Next
            SQLQueryCerrar()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return retorno
    End Function
    Public Function RegistroRecuperarConjuntoDeDatos(ByRef Clase As Object) As DataSet
        Dim ds As DataSet = New DataSet()
        Try
            SQLquery = GetSQLQuery(Clase)
            ds = conexion.GetDataSet(SQLquery)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return ds
    End Function
    Public Function RegistroRecuperarTabla(ByRef Clase As Object) As DataTable
        Dim dt As DataTable = New DataTable()
        Try
            SQLquery = GetSQLQuery(Clase)
            dt = conexion.GetDataTable(SQLquery)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return dt
    End Function
    'Procedimientos almacenados
    Public Function ProcedimientoAlmacenado(ByVal Procedimiento As String, ByVal NombreTabla As String, ByVal Parametros As Array, Optional ByVal NumParam As Integer = 0) As DataSet
        Try
            lDataset = conexion.GetStoreProcedure(Procedimiento, NombreTabla, Parametros, NumParam)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return lDataset
    End Function
    'llenar Objetos con datos de la tabla
    Public Sub DataGridViewerLlenar(ByRef dgwGrid As GridView, ByVal Clase As Object)
        Dim dt As DataTable = New DataTable()
        Try
            SQLquery = GetSQLQuery(Clase)
            lDataTabla = conexion.GetDataTable(SQLquery)
            dgwGrid.DataSource = lDataTabla
            dgwGrid.DataBind()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class


