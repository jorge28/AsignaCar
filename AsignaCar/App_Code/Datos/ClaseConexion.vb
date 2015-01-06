Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.IO
Imports System.Text

Public Class ClaseConexion
    Private mComando As SqlClient.SqlCommand
    Private mLector As SqlClient.SqlDataReader
    Private mConexion As New SqlClient.SqlConnection
    Private mDataSet As DataSet
    Private mTable As DataTable
    Private mDataAdapter As SqlDataAdapter

    'Dim CadenaConexion = "Data Source=50.31.26.43;Initial Catalog=Transforma3H; User ID=sa;Password=C0chisquila"
    'Dim CadenaConexion = "Data Source=;Initial Catalog=Transforma3H; User ID=sa;Password=C0chisquila"
    Dim CadenaConexion As String = ConfigurationManager.ConnectionStrings("AutoSigueIIConnectionString").ConnectionString




    Function GetConexion() As SqlConnection
        Return mConexion
    End Function

    Sub AbrirConexion()
        Try
            If Not (Me.mConexion.State = ConnectionState.Open) Then
                mConexion.ConnectionString = CadenaConexion
                mConexion.Open()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub




    Public Function SQLQuery(ByVal Query As String, ByRef Dato As ClaseDatos) As SqlClient.SqlDataReader
        mComando = New SqlClient.SqlCommand(Query, mConexion)
        mComando.CommandTimeout = 800
        If (Dato.TransaccionEstado) Then
            mComando.Transaction = Dato.Transaccion
        End If
        mLector = mComando.ExecuteReader(CommandBehavior.Default)
        Return mLector
    End Function

    Public Sub SQLNoQuery(ByVal Query As String, ByRef Dato As ClaseDatos)   'no retorna nada
        If (Me.mConexion.State = ConnectionState.Open) Then
            mConexion.Close()
        End If
        mConexion.ConnectionString = CadenaConexion
        mConexion.Open()
        mComando = New SqlClient.SqlCommand(Query, mConexion)
        mComando.CommandTimeout = 800
        If (Dato.TransaccionEstado) Then
            mComando.Transaction = Dato.Transaccion
        End If
        mComando.ExecuteNonQuery()
    End Sub
    Public Sub SQLNoQueryNoClase(ByVal Query As String)   'no retorna nada
        If (Me.mConexion.State = ConnectionState.Open) Then
            mConexion.Close()
        End If
        mConexion.ConnectionString = CadenaConexion
        mConexion.Open()
        mComando = New SqlClient.SqlCommand(Query, mConexion)
        mComando.CommandTimeout = 800
        mComando.ExecuteNonQuery()
    End Sub

    Sub CerrarConexion()
        If (Me.mConexion.State = ConnectionState.Open) Then
            mConexion.Close()
        End If
    End Sub

    Sub CerraLectorDatos()
        mLector.Close()
    End Sub

    Sub TransaccionIniciar(ByRef Transaccion As SqlClient.SqlTransaction)
        Transaccion = mConexion.BeginTransaction
    End Sub
    Public Function GetCadenaDeConexion() As String
        Return Me.mConexion.ConnectionString
    End Function

    Public Function CanRead() As Boolean
        Try
            Return mLector.Read
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return False
    End Function

    'Metodos para Generar Tabla y DataSet
    Public Sub CerrarAdaptador()
        mDataAdapter.Dispose()
    End Sub
    Public Sub CerrarDataSet()
        mDataSet.Dispose()
    End Sub

    Public Function GetDataSet(ByVal SQLQuery As String) As DataSet
        If (Me.mConexion.State = ConnectionState.Open) Then
            mConexion.Close()
        End If
        mConexion.ConnectionString = CadenaConexion
        mConexion.Open()
        mDataAdapter = New SqlDataAdapter
        mComando = New SqlCommand
        mDataSet = New DataSet()
        mComando.CommandText = SQLQuery
        mComando.Connection = Me.mConexion
        mComando.CommandTimeout = 800
        mDataAdapter.SelectCommand = mComando
        mDataAdapter.Fill(mDataSet)
        Return Me.mDataSet
    End Function

    Public Function GetDataTable(ByVal SQLQuery As String) As DataTable
        If (Me.mConexion.State = ConnectionState.Open) Then
            mConexion.Close()
        End If
        mConexion.ConnectionString = CadenaConexion
        mConexion.Open()
        mDataAdapter = New SqlDataAdapter
        mComando = New SqlCommand
        mTable = New DataTable()
        mComando.CommandText = SQLQuery
        mComando.CommandTimeout = 800
        mComando.Connection = Me.mConexion
        mDataAdapter.SelectCommand = mComando
        mDataAdapter.Fill(mTable)

        Return Me.mTable
    End Function


    Public Function GetStoreProcedure(ByVal Procedimiento As String, ByVal NombreTabla As String, ByVal Parametros As Array, Optional ByVal NumParam As Integer = 0, Optional ByVal CadenaConexion As String = "") As DataSet
        mDataAdapter = New SqlDataAdapter()
        mComando = New SqlCommand()
        mDataSet = New DataSet()

        Dim i As Integer
        Dim sparCatID As New SqlParameter
        Dim sComm As String = String.Empty
        Try
            AbrirConexion() 'abre la conexion
            mComando = New SqlCommand(Procedimiento, GetConexion)

            mDataAdapter = New SqlDataAdapter(mComando)
            mComando.CommandTimeout = 800
            mComando.CommandType = CommandType.StoredProcedure
            For i = 0 To NumParam - 1
                sparCatID = New SqlParameter
                With sparCatID
                    sparCatID.ParameterName = Parametros.GetValue(i, 0).ToString()
                    sparCatID.DbType = CType(Parametros.GetValue(i, 1), DbType)
                    sparCatID.Value = Parametros.GetValue(i, 2)
                End With
                mComando.Parameters.Add(sparCatID)
                sComm = sparCatID.Value.ToString

            Next


            mDataAdapter.Fill(mDataSet, NombreTabla)

        Catch exp As Exception
            MsgBox(exp.Message)
        End Try
        Return mDataSet
    End Function

    Public Sub GetSqlComand(ByRef Comand As SqlCommand)
        Comand = Me.mComando
    End Sub


End Class

