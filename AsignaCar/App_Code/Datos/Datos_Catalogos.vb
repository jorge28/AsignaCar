Imports Microsoft.VisualBasic
Imports Acceso_a_Datos
Imports System.Data
Imports System.Data.SqlClient

Public Class Datos_Catalogos


#Region "Consulta Vehiculos "

    'Israel

    'Modificacion IsraelR 18-09-2013
    Public Function Mostrar_Arrendamiento(ByVal usr As Integer, ByVal id As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            'Se crean los parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@Id", id))
            datos.Consulta_SP("Select_Arrendamiento @Id", res.DataTable)

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("Catalogos.vb", "Select_Arrendamiento", ex.Message, ex.StackTrace)
        End Try
        Return res

    End Function

    'Modificacion IsraelR 18-09-2013
    Public Function Mostrar_Contado(ByVal usr As Integer, ByVal id As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            'Se crean los parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@Id", id))
            datos.Consulta_SP("Select_Contado @Id", res.DataTable)

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("Catalogos.vb", "Select_Contado", ex.Message, ex.StackTrace)
        End Try
        Return res

    End Function



#End Region



#Region "Regiones, Coordinación, Almacén"

    Public Function Insertar_Regiones(usr As Integer, region As CRegion) As Resultado
        Dim res As New Resultado 'Objeto para resultados
        Dim datos As New ObjDatos

        Try
            ' Valida dato
            If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(region.Nombre) Then
                Throw New Validacion_Exception("Nombre")
            End If

            'Se crea parámetro y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@nombre", region.Nombre))
            datos.Comando_SP("Insert_Regiones @nombre", res.DataTable)

            ' Graba la auditoria
            Auditoria.Registrar(usr, 1001, res.DataTable.Rows(0)(2) & "-" & region.Nombre)
        Catch ex As Validacion_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            ''Se regresan y registran los datos del error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("Catalogos.vb", "Insert_Regiones", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function

    Public Function Eliminar_Regiones(usr As Integer, id As Integer) As Resultado
        Dim res As New Resultado 'Objeto para regresar el Resultado2
        Dim datos As New ObjDatos 'Objeto para llamar ws

        Try
            'Se crea parámetro y se llama el ws
            datos.sqlParameters.Add(New SqlParameter("@Id", id))
            datos.Comando_SP("Delete_Regiones @Id", res.DataTable)

            ' Graba la auditoria
            Auditoria.Registrar(usr, 1003, id)
        Catch ex As Validacion_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            ''Se regresan y registran los datos del error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("Catalogos.vb", "Delete_Regiones", ex.Message, ex.StackTrace)
        End Try

        Return res
    End Function

    Public Function Actualizar_Regiones(usr As Integer, region As CRegion) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            ' Valida que sea un dato correcto
            If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(region.Nombre) Then
                Throw New Validacion_Exception("Nombre")
            End If

            'Se crean los parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@Id", region.Id))
            datos.sqlParameters.Add(New SqlParameter("@Nombre", region.Nombre))
            datos.Comando_SP("Update_Regiones @Id, @Nombre", res.DataTable)

            ' Graba la auditoria
            Auditoria.Registrar(usr, 1002, region.Id & "-" & region.Nombre)
        Catch ex As Validacion_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("Catalogos.vb", "Update_Regiones", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
        Return res
    End Function

    Public Function Consultar_Regiones(usr As Integer, id As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            'Se crean los parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@Id", id))
            datos.Consulta_SP("Select_Regiones @Id", res.DataTable)

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("Catalogos.vb", "Select_Regiones", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function

    Public Function Insertar_Coordinaciones(usr As Integer, coordinacion As CCoordinacion) As Resultado
        Dim res As New Resultado 'Objeto para resultados
        Dim datos As New ObjDatos

        Try
            ' Valida que sea un dato correcto
            If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(coordinacion.Nombre) Then
                Throw New Validacion_Exception("Nombre")
            End If

            'Se crea parámetro y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@nombre", coordinacion.Nombre))
            datos.sqlParameters.Add(New SqlParameter("@IdRegion", coordinacion.IdRegion))
            datos.Comando_SP("Insert_Coordinaciones @nombre, @IdRegion", res.DataTable)

            ' Graba la auditoria
            Auditoria.Registrar(usr, 1004, res.DataTable.Rows(0)(2) & "-" & coordinacion.Nombre)
        Catch ex As Validacion_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            ''Se regresan y registran los datos del error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("Catalogos.vb", "Insert_Coordinaciones", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function

    Public Function Eliminar_Coordinaciones(usr As Integer, id As Integer) As Resultado
        Dim res As New Resultado 'Objeto para regresar el Resultado2
        Dim datos As New ObjDatos 'Objeto para llamar ws

        Try
            'Se crea parámetro y se llama el ws
            datos.sqlParameters.Add(New SqlParameter("@Id", id))
            datos.Comando_SP("Delete_Coordinaciones @Id", res.DataTable)

            ' Graba la auditoria
            Auditoria.Registrar(usr, 1006, id)

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            ''Se regresan y registran los datos del error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("Catalogos.vb", "Delete_Coordinaciones", ex.Message, ex.StackTrace)
        End Try

        Return res
    End Function

    Public Function Actualizar_Coordinaciones(usr As Integer, coordinacion As CCoordinacion) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            ' Valida que sea un dato correcto
            If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(coordinacion.Nombre) Then
                Throw New Validacion_Exception("Nombre")
            End If

            'Se crean los parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@Id", coordinacion.Id))
            datos.sqlParameters.Add(New SqlParameter("@Nombre", coordinacion.Nombre))
            datos.sqlParameters.Add(New SqlParameter("@IdRegion", coordinacion.IdRegion))
            datos.Comando_SP("Update_Coordinaciones @Id, @IdRegion, @Nombre", res.DataTable)

            ' Graba la auditoria
            Auditoria.Registrar(usr, 1005, coordinacion.Id & "-" & coordinacion.Nombre)

        Catch ex As Validacion_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("Catalogos.vb", "Update_Coordinaciones", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
        Return res
    End Function

    Public Function Consultar_Coordinaciones(usr As Integer, id As Integer, idRegion As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            'Se crean los parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@Id", id))
            datos.sqlParameters.Add(New SqlParameter("@IdRegion", idRegion))
            datos.Consulta_SP("Select_Coordinaciones @Id, @IdRegion", res.DataTable)


        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("Catalogos.vb", "Select_Coordinaciones", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function

    Public Function Insertar_Almacenes(usr As Integer, almacen As CAlmacen) As Resultado
        Dim res As New Resultado 'Objeto para resultados
        Dim datos As New ObjDatos

        Try
            ' Valida que sea un dato correcto
            If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(almacen.Nombre) Then
                Throw New Validacion_Exception("Nombre")
            End If

            'Se crea parámetro y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@nombre", almacen.Nombre))
            datos.sqlParameters.Add(New SqlParameter("@IdCoordinacion", almacen.IdCoordinacion))
            datos.Comando_SP("Insert_Almacenes @nombre, @IdCoordinacion", res.DataTable)

            ' Graba la auditoria
            Auditoria.Registrar(usr, 1007, res.DataTable.Rows(0)(2) & "-" & almacen.Nombre)
        Catch ex As Validacion_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            ''Se regresan y registran los datos del error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("Catalogos.vb", "Insert_Almacenes", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function

    Public Function Eliminar_Almacenes(usr As Integer, id As Integer) As Resultado
        Dim res As New Resultado 'Objeto para regresar el Resultado2
        Dim datos As New ObjDatos 'Objeto para llamar ws

        Try
            'Se crea parámetro y se llama el ws
            datos.sqlParameters.Add(New SqlParameter("@Id", id))
            datos.Comando_SP("Delete_Almacenes @Id", res.DataTable)

            ' Graba la auditoria
            Auditoria.Registrar(usr, 1009, id)

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            ''Se regresan y registran los datos del error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("Catalogos.vb", "Delete_Almacenes", ex.Message, ex.StackTrace)
        End Try

        Return res
    End Function

    Public Function Actualizar_Almacenes(usr As Integer, almacen As CAlmacen) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            ' Valida que sea un dato correcto
            If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(almacen.Nombre) Then
                Throw New Validacion_Exception("Nombre")
            End If

            'Se crean los parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@Id", almacen.Id))
            datos.sqlParameters.Add(New SqlParameter("@Nombre", almacen.Nombre))
            datos.sqlParameters.Add(New SqlParameter("@IdCoordinacion", almacen.IdCoordinacion))
            datos.Comando_SP("Update_Almacenes @Id, @IdCoordinacion, @Nombre", res.DataTable)

            ' Graba la auditoria
            Auditoria.Registrar(usr, 1008, almacen.Id & "-" & almacen.Nombre)
        Catch ex As Validacion_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("Catalogos.vb", "Update_Almacenes", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
        Return res
    End Function

    Public Function Consultar_Almacenes(ByVal usr As Integer, ByVal id As Integer, ByVal idCoordinacion As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            'Se crean los parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@Id", id))
            datos.sqlParameters.Add(New SqlParameter("@IdCoordinacion", idCoordinacion))
            'datos.sqlParameters.Add(New SqlParameter("@IdRegion", idRegion))
            datos.Consulta_SP("Select_Almacenes @Id, @IdCoordinacion", res.DataTable)


        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("Catalogos.vb", "Select_Almacenes", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function

#End Region

#Region "Marcas, Submarca , Modelo y Banco"

    Public Function Insertar_Marcas(usr As Integer, marca As CMarca) As Resultado
        Dim res As New Resultado 'Objeto para resultados
        Dim datos As New ObjDatos
        Try
            ' Valida dato
            If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(marca.Nombre) Then
                Throw New Validacion_Exception("Nombre")
            End If

            'Se crea parámetro y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@nombre", marca.Nombre)) '
            datos.Comando_SP("Insert_Marcas @nombre", res.DataTable)

            ' Graba la auditoria
            Auditoria.Registrar(usr, 1010, res.DataTable.Rows(0)(2) & "-" & marca.Nombre)
        Catch ex As Validacion_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            ''Se regresan y registran los datos del error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("Catalogos.vb", "Insert_Marcas", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function

    Public Function Eliminar_Marcas(usr As Integer, id As Integer) As Resultado
        Dim res As New Resultado 'Objeto para regresar el Resultado2
        Dim datos As New ObjDatos

        Try
            'Se crea parámetro y se llama el ws
            datos.sqlParameters.Add(New SqlParameter("@Id", id))
            datos.Comando_SP("Delete_Marcas @Id", res.DataTable)

            ' Graba la auditoria
            Auditoria.Registrar(usr, 1012, id)

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            ''Se regresan y registran los datos del error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("Catalogos.vb", "Delete_Marcas", ex.Message, ex.StackTrace)
        End Try

        Return res
    End Function

    Public Function Actualizar_Marcas(usr As Integer, marca As CMarca) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            ' Valida que sea un dato correcto
            If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(marca.Nombre) Then
                Throw New Validacion_Exception("Nombre")
            End If

            'Se crean los parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@Id", marca.Id))
            datos.sqlParameters.Add(New SqlParameter("@Nombre", marca.Nombre))
            datos.Comando_SP("Update_Marcas @Id, @Nombre", res.DataTable)

            ' Graba la auditoria
            Auditoria.Registrar(usr, 1011, marca.Id & "-" & marca.Nombre)
        Catch ex As Validacion_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("Catalogos.vb", "Update_Marcas", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
        Return res
    End Function

    Public Function Consultar_Marcas(usr As Integer, id As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            'Se crean los parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@Id", id))
            datos.Consulta_SP("Select_MarcasCheckin @Id", res.DataTable)

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("Catalogos.vb", "Select_Marcas", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function

    Public Function Consultar_MarcasCheckIn(usr As Integer, id As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            'Se crean los parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@Id", id))
            datos.Consulta_SP("Select_MarcasCheckin @Id", res.DataTable)

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("Catalogos.vb", "Select_MarcasCheckin", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function


    Public Function Consultar_SubMarcas(ByVal usr As Integer, ByVal Id As Integer, ByVal IdMarca As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            'Se crean los parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@Id", Id))
            datos.sqlParameters.Add(New SqlParameter("@IdMarca", IdMarca))
            datos.Consulta_SP("Select_SubMarcas @Id, @IdMarca", res.DataTable)

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("Catalogos.vb", "Select_SubMarcas", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function

    Public Function Consultar_EstadoRegion(ByVal usr As Integer, ByVal Id As Integer, ByVal IdRegion As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            'Se crean los parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@Id", Id))
            datos.sqlParameters.Add(New SqlParameter("@IdRegion", IdRegion))
            datos.Consulta_SP("Select_EstadoRegion @Id, @IdRegion", res.DataTable)

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("Catalogos.vb", "Select_EstadoRegion", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function
    'Israel
    Public Function Consultar_MVA() As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            'Se crean los parámetros y se manda llamar el ws
            datos.Consulta_SP("Select_MVA", res.DataTable)

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("Catalogos.vb", "Select_MVA", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function
    'Rafael  
    '11 sep 2013
    Public Function Consultar_Placas(usr As Integer, Placas As String) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            'Se crean los parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@Placas", Placas))
            datos.Consulta_SP("Select_Placas @Placas", res.DataTable)

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("Catalogos.vb", "Select_Placas", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function

    Public Function Insertar_Submarcas(usr As Integer, submarca As CSubMarca) As Resultado
        Dim res As New Resultado 'Objeto para resultados
        Dim datos As New ObjDatos

        Try
            ' Valida dato
            If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(submarca.Nombre) Then
                Throw New Validacion_Exception("Nombre")
            End If

            'Se crea parámetro y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@nombre", submarca.Nombre)) '
            datos.sqlParameters.Add(New SqlParameter("@IdMarca", submarca.IdMarca)) '
            datos.Comando_SP("Insert_Submarcas @nombre, @IdMarca", res.DataTable)

            ' Graba la auditoria
            Auditoria.Registrar(usr, 1013, res.DataTable.Rows(0)(2) & "-" & submarca.Nombre)
        Catch ex As Validacion_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            ''Se regresan y registran los datos del error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("Catalogos.vb", "Insert_Submarcas", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function

    Public Function Eliminar_Submarcas(usr As Integer, id As Integer) As Resultado
        Dim res As New Resultado 'Objeto para regresar el Resultado2
        Dim datos As New ObjDatos

        Try
            'Se crea parámetro y se llama el ws
            datos.sqlParameters.Add(New SqlParameter("@Id", id))
            datos.Comando_SP("Delete_Submarcas @Id", res.DataTable)

            ' Graba la auditoria
            Auditoria.Registrar(usr, 1015, id)

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            ''Se regresan y registran los datos del error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("Catalogos.vb", "Delete_Submarcas", ex.Message, ex.StackTrace)
        End Try

        Return res
    End Function

    Public Function Actualizar_Submarcas(usr As Integer, submarca As CSubMarca) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            ' Valida que sea un dato correcto
            If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(submarca.Nombre) Then
                Throw New Validacion_Exception("Nombre")
            End If

            'Se crean los parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@Id", submarca.Id))
            datos.sqlParameters.Add(New SqlParameter("@nombre", submarca.Nombre)) '
            datos.sqlParameters.Add(New SqlParameter("@IdMarca", submarca.IdMarca)) '
            datos.Comando_SP("Update_Submarcas @Id, @Nombre, @IdMarca", res.DataTable)

            ' Graba la auditoria
            Auditoria.Registrar(usr, 1014, submarca.Id & "-" & submarca.Nombre)
        Catch ex As Validacion_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("Catalogos.vb", "Update_Submarcas", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
        Return res
    End Function

    Public Function Consultar_Modelos(usr As Integer, IdMarca As Integer, IdSubMarca As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try

            'Se crean los parámetros y se manda llamar el ws
            'datos.sqlParameters.Add(New SqlParameter("@IdSubMarca", IdSubMarca))
            'datos.sqlParameters.Add(New SqlParameter("@IdMarca", IdMarca))
            'datos.Consulta_SP("Select_Modelos @IdSubMarca, @IdMarca", res.DataTable)
            res.DataTable.Columns.Add(New DataColumn("Modelo", System.Type.GetType("System.Int32")))

            For año As Integer = 1975 To Now.Year + 1
                res.DataTable.Rows.Add(año)
            Next

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("Catalogos.vb", "Select_Modelos", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function



    Public Function Insertar_Banco(usr As Integer, Banco As CBanco) As Resultado
        Dim res As New Resultado 'Objeto para resultados
        Dim datos As New ObjDatos
        Try
            ' Valida dato
            If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(Banco.Nombre) Then
                Throw New Validacion_Exception("Nombre")
            End If

            'Se crea parámetro y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@nombre", Banco.Nombre)) '
            datos.Comando_SP("Insert_Banco @nombre", res.DataTable)

            ' Graba la auditoria
            Auditoria.Registrar(usr, 1010, res.DataTable.Rows(0)(2) & "-" & Banco.Nombre)
        Catch ex As Validacion_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            ''Se regresan y registran los datos del error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("Catalogos.vb", "Insert_Banco", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function

    Public Function Eliminar_Bancos(usr As Integer, id As Integer) As Resultado
        Dim res As New Resultado 'Objeto para regresar el Resultado2
        Dim datos As New ObjDatos

        Try
            'Se crea parámetro y se llama el ws
            datos.sqlParameters.Add(New SqlParameter("@Id", id))
            datos.Comando_SP("Delete_Bancos @Id", res.DataTable)

            ' Graba la auditoria
            Auditoria.Registrar(usr, 1012, id)

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            ''Se regresan y registran los datos del error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("Catalogos.vb", "Delete_Bancos", ex.Message, ex.StackTrace)
        End Try

        Return res
    End Function

    Public Function Actualizar_Bancos(usr As Integer, Banco As CBanco) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            ' Valida que sea un dato correcto
            If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(Banco.Nombre) Then
                Throw New Validacion_Exception("Nombre")
            End If

            'Se crean los parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@Id", Banco.Id))
            datos.sqlParameters.Add(New SqlParameter("@Nombre", Banco.Nombre))
            datos.Comando_SP("Update_Bancos @Id, @Nombre", res.DataTable)

            ' Graba la auditoria
            Auditoria.Registrar(usr, 1011, Banco.Id & "-" & Banco.Nombre)
        Catch ex As Validacion_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("Catalogos.vb", "Update_Bancos", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
        Return res
    End Function



#End Region

#Region "Niveles de Gasolina"

    Public Function Consultar_NivelesGasolina(usr As Integer, id As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            'Se crean los parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@Id", id))
            datos.Consulta_SP("Select_NivelesGasolina @Id", res.DataTable)

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("Catalogos.vb", "Select_NivelesGasolina", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function
#End Region

#Region "IVA"

    Public Function Consultar_IVA(usr As Integer, id As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            'Se crean los parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@Id", id))
            datos.Consulta_SP("Select_IVA @Id", res.DataTable)

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("Catalogos.vb", "Select_IVA", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function
#End Region

#Region "Propietarios"
    'Isra
    Public Function Consultar_Propietario(ByVal usr As Integer, ByVal id As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            'Se crean los parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@Id", id))
            datos.Consulta_SP("Select_Propietarios @Id", res.DataTable)

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("Catalogos.vb", "Select_Propietario", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function
    'Termina Isra

    Public Function Consultar_Propietarios(ByVal usr As Integer, ByVal id As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            'Se crean los parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@Id", id))
            datos.Consulta_SP("Select_Propietarios @Id", res.DataTable)

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("Catalogos.vb", "Select_Propietarios", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function
#End Region

#Region "Estados"
    Public Function Consultar_Estados(ByVal usr As Integer, ByVal id As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            'Se crean los parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@Id", id))
            datos.Consulta_SP("Select_Estados @Id", res.DataTable)

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("Catalogos.vb", "Select_Estados", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function

    Public Function Consultar_Municipios(usr As Integer, IdEstado As Integer, Id As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            'Se crean los parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@Id", Id))
            datos.sqlParameters.Add(New SqlParameter("@IdEstado", IdEstado))

            datos.Consulta_SP("Select_Municipios @IdEstado, @Id", res.DataTable)

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("Catalogos.vb", "Select_Municipios", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function
#End Region

#Region "Conductores"

    Public Function Insertar_Conductores(usr As Integer, conductor As CConductor) As Resultado
        Dim res As New Resultado 'Objeto para resultados
        Dim datos As New ObjDatos

        Try
            ' Valida dato
            If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(conductor.Clave) Then
                Throw New Validacion_Exception("Clave")
            End If
            If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(conductor.Nombre) Then
                Throw New Validacion_Exception("Nombre")
            End If
            If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(conductor.Paterno) Then
                Throw New Validacion_Exception("Paterno")
            End If
            If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(conductor.Materno) Then
                Throw New Validacion_Exception("Materno")
            End If
            If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(conductor.Telefono) Then
                Throw New Validacion_Exception("Telefono")
            End If
            If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(conductor.Email) Then
                Throw New Validacion_Exception("Email")
            End If
            If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(conductor.RFC) Then
                Throw New Validacion_Exception("RFC")
            End If
            If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(conductor.Calle) Then
                Throw New Validacion_Exception("Calle")
            End If
            If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(conductor.Numero) Then
                Throw New Validacion_Exception("Numero")
            End If
            If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(conductor.Colonia) Then
                Throw New Validacion_Exception("Colonia")
            End If
            If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(conductor.CP) Then
                Throw New Validacion_Exception("Código Postal")
            End If

            'Se crea parámetro y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@clave", conductor.Clave)) '
            datos.sqlParameters.Add(New SqlParameter("@nombre", conductor.Nombre)) '
            datos.sqlParameters.Add(New SqlParameter("@paterno", conductor.Paterno)) '
            datos.sqlParameters.Add(New SqlParameter("@materno", conductor.Materno)) '
            datos.sqlParameters.Add(New SqlParameter("@rfc", conductor.RFC)) '
            datos.sqlParameters.Add(New SqlParameter("@telefono", conductor.Telefono)) '
            datos.sqlParameters.Add(New SqlParameter("@email", conductor.Email)) '
            datos.sqlParameters.Add(New SqlParameter("@calle", conductor.Calle)) '
            datos.sqlParameters.Add(New SqlParameter("@colonia", conductor.Colonia)) '
            datos.sqlParameters.Add(New SqlParameter("@numero", conductor.Numero)) '
            datos.sqlParameters.Add(New SqlParameter("@cp", conductor.CP)) '
            datos.sqlParameters.Add(New SqlParameter("@IdEstado", conductor.IdEstado)) '
            datos.sqlParameters.Add(New SqlParameter("@IdMunicipio", conductor.IdMunicipio)) '
            datos.Comando_SP("Insert_Conductores @Clave,@Nombre,@Paterno,@Materno,@RFC,@Telefono,@Email,@Calle,@Numero,@Colonia,@CP,@IdEstado,@IdMunicipio", res.DataTable)

            ' Graba la auditoria
            Auditoria.Registrar(usr, 1016, res.DataTable.Rows(0)(2) & "-" & conductor.Clave & "-" & conductor.Nombre & " " & conductor.Paterno & " " & conductor.Materno)
        Catch ex As Validacion_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            ''Se regresan y registran los datos del error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("Catalogos.vb", "Insert_Conductores", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function

    Public Function Eliminar_Conductores(usr As Integer, id As Integer) As Resultado
        Dim res As New Resultado 'Objeto para regresar el Resultado2
        Dim datos As New ObjDatos 'Objeto para llamar ws

        Try
            'Se crea parámetro y se llama el ws
            datos.sqlParameters.Add(New SqlParameter("@Id", id))
            datos.Comando_SP("Delete_Conductores @Id", res.DataTable)

            ' Graba la auditoria
            Auditoria.Registrar(usr, 1018, id)
        Catch ex As Validacion_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            ''Se regresan y registran los datos del error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("Catalogos.vb", "Delete_Conductores", ex.Message, ex.StackTrace)
        End Try

        Return res
    End Function

    Public Function Actualizar_Conductores(usr As Integer, conductor As CConductor) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            ' Valida que sea un dato correcto
            If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(conductor.Clave) Then
                Throw New Validacion_Exception("Clave")
            End If
            If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(conductor.Nombre) Then
                Throw New Validacion_Exception("Nombre")
            End If
            If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(conductor.Paterno) Then
                Throw New Validacion_Exception("Paterno")
            End If
            If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(conductor.Materno) Then
                Throw New Validacion_Exception("Materno")
            End If
            If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(conductor.Telefono) Then
                Throw New Validacion_Exception("Telefono")
            End If
            If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(conductor.Email) Then
                Throw New Validacion_Exception("Email")
            End If
            If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(conductor.RFC) Then
                Throw New Validacion_Exception("RFC")
            End If
            If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(conductor.Calle) Then
                Throw New Validacion_Exception("Calle")
            End If
            If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(conductor.Numero) Then
                Throw New Validacion_Exception("Numero")
            End If
            If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(conductor.Colonia) Then
                Throw New Validacion_Exception("Colonia")
            End If
            If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(conductor.CP) Then
                Throw New Validacion_Exception("Código Postal")
            End If

            'Se crea parámetro y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@Id", conductor.Id)) '
            datos.sqlParameters.Add(New SqlParameter("@clave", conductor.Clave)) '
            datos.sqlParameters.Add(New SqlParameter("@nombre", conductor.Nombre)) '
            datos.sqlParameters.Add(New SqlParameter("@paterno", conductor.Paterno)) '
            datos.sqlParameters.Add(New SqlParameter("@materno", conductor.Materno)) '
            datos.sqlParameters.Add(New SqlParameter("@rfc", conductor.RFC)) '
            datos.sqlParameters.Add(New SqlParameter("@telefono", conductor.Telefono)) '
            datos.sqlParameters.Add(New SqlParameter("@email", conductor.Email)) '
            datos.sqlParameters.Add(New SqlParameter("@calle", conductor.Calle)) '
            datos.sqlParameters.Add(New SqlParameter("@colonia", conductor.Colonia)) '
            datos.sqlParameters.Add(New SqlParameter("@numero", conductor.Numero)) '
            datos.sqlParameters.Add(New SqlParameter("@cp", conductor.CP)) '
            datos.sqlParameters.Add(New SqlParameter("@IdEstado", conductor.IdEstado)) '
            datos.sqlParameters.Add(New SqlParameter("@IdMunicipio", conductor.IdMunicipio)) '
            datos.Comando_SP("Update_Conductores @Id,@Clave,@Nombre,@Paterno,@Materno,@RFC,@Telefono,@Email,@Calle,@Numero,@Colonia,@CP,@IdEstado,@IdMunicipio", res.DataTable)

            ' Graba la auditoria
            Auditoria.Registrar(usr, 1017, conductor.Id & "-" & conductor.Clave & "-" & conductor.Nombre & " " & conductor.Paterno & " " & conductor.Materno)

        Catch ex As Validacion_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("Catalogos.vb", "Update_Conductores", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
        Return res
    End Function

    Public Function Consultar_Conductores(usr As Integer, id As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            'Se crean los parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@Id", id))
            datos.Consulta_SP("Select_Conductores @Id", res.DataTable)

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("Catalogos.vb", "Select_Conductores", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function

#End Region

#Region "Precios de Proveedores"
    Public Function Consultar_Tipos_Conceptos_Precios_Proveedor(usr As String, Id As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            'Se crean parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@Id", Id))

            datos.Consulta_SP("Select_Tipos_Conceptos_Precios_Proveedor @Id", res.DataTable)

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("Catalogos.vb", "Select_Tipos_Conceptos_Precios_Proveedor", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
        Return res
    End Function

    ''' <summary>
    ''' Consulta los conceptos que pueden manejar los proveedores
    ''' </summary>
    ''' <param name="usr"></param>
    ''' <param name="Id"></param>
    ''' <param name="IdTipo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Consultar_Conceptos_Precios_Proveedor(usr As String, Id As Integer, IdTipo As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            'Se crean parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@Id", Id))
            datos.sqlParameters.Add(New SqlParameter("@IdTipo", IdTipo))

            datos.Consulta_SP("Select_Conceptos_Precios_Proveedor @Id, @IdTipo", res.DataTable)

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("Catalogos.vb", "Select_Conceptos_Precios_Proveedor", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
        Return res
    End Function


    ''' <summary>
    ''' Consulta los precios que cada proveedor pone en cada concepto
    ''' </summary>
    ''' <param name="usr"></param>
    ''' <param name="IdProveedor"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Consultar_Precios_Conceptos_Proveedor(usr As String, IdProveedor As Integer, IdTipoConcepto As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            'Se crean parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@IdProveedor", IdProveedor))
            datos.sqlParameters.Add(New SqlParameter("@IdTipoConcepto", IdTipoConcepto))

            datos.Consulta_SP("Select_Precios_Conceptos_Proveedor @IdProveedor, @IdTipoConcepto", res.DataTable)

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("Catalogos.vb", "Select_Precios_Conceptos_Proveedor", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
        Return res
    End Function


    Public Function Cargar_Lista_Precios_Proveedores_Excel(usr As String, IdProveedor As Integer, xml As String) As Resultado
        Dim datos As New ObjDatos()
        Dim res As New Resultado
        Dim reader As System.Xml.XmlTextReader = Nothing
        Dim sr As IO.StringReader = Nothing

        Try
            'Borra la tabla auxiliar
            datos.Comando_SP("Delete_Precios_Proveedores_Aux", res.DataTable)

            ' Abre el archivo xml
            sr = New IO.StringReader(xml)
            reader = New System.Xml.XmlTextReader(sr) 'Ruta donde está el archivo xml

            ' Primero lee hasta llegar al Table y al primer Row
            While reader.Read()
                If reader.NodeType = System.Xml.XmlNodeType.Element Then
                    If reader.Name = "Row" Then
                        ' Aquíe se encuentran los titulos. Avanza hasta el final del Row
                        While reader.Read()
                            If reader.NodeType = System.Xml.XmlNodeType.EndElement Then
                                If reader.Name = "Row" Then
                                    Exit While
                                End If
                            End If
                        End While
                        Exit While
                    End If
                End If
            End While

            ' A partir de aqui comienza a leer los datos
            While reader.Read()
                Select Case reader.NodeType
                    Case System.Xml.XmlNodeType.Element
                        If reader.Name = "Row" Then 'Lee el dato 
                            Dim param As Short = 1
                            While reader.Read()
                                If reader.NodeType = System.Xml.XmlNodeType.Text Then
                                    Select Case param
                                        Case 1
                                            datos.AddSqlParameter("@IdTipoConcepto", reader.Value)
                                        Case 2
                                            datos.AddSqlParameter("@TipoConcepto", Left(reader.Value, 100))
                                        Case 3
                                            datos.AddSqlParameter("@IdConcepto", reader.Value)
                                        Case 4
                                            datos.AddSqlParameter("@Concepto", Left(reader.Value, 100))
                                        Case 5
                                            datos.AddSqlParameter("@Precio", reader.Value)
                                            Exit While
                                    End Select
                                    param += 1
                                End If
                            End While
                        End If

                    Case System.Xml.XmlNodeType.EndElement
                        If reader.Name = "Table" Then
                            Exit While ' Fin de la carga
                        ElseIf reader.Name = "Row" Then ' Terminó el renglón
                            datos.AddSqlParameter("IdProveedor", IdProveedor) 'Se inserta en la tabla
                            datos.Comando_SP("Insert_Precios_Proveedores_Aux @IdProveedor, @IdTipoConcepto, @TipoConcepto, @IdConcepto, @Concepto, @Precio", res.DataTable)
                        End If
                End Select
            End While

            'Se actualizan los datos en la tabla real, con los datos de la tabla auxiliar
            datos.Comando_SP("Update_Precios_Proveedores_con_Aux", res.DataTable)

            Auditoria.Registrar(usr, 1048)
        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            ''Se regresan y registran los datos del error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

            Logs.LogError("Catalogos.vb", "Update_Precios_Proveedores_con_Aux", ex.Message, ex.StackTrace)

        Finally
            ' Cierra el archivo
            If reader IsNot Nothing Then reader.Close()
            If sr IsNot Nothing Then sr.Close()
        End Try

        Return res
    End Function


    Public Function Eliminar_Precios_Proveedor(usr As String, Id As Integer) As Resultado
        Dim res As New Resultado
        Dim datos As New ObjDatos


        Try

            'Se crean parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@Id", Id))

            ' Graba el proveedor
            datos.Comando_SP("Delete_Precio_Proveedor @Id", res.DataTable)

            ' Graba la auditoria
            Auditoria.Registrar(usr, 1049, Id)
        Catch ex As Validacion_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

            If datos.TransaccionIniciada Then datos.Rollback()

        Catch ex As Exception
            ''Se regresan y registran los datos del error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

            If datos.TransaccionIniciada Then datos.Rollback()

            Logs.LogError("Catalogos.vb", "Delete_Precio_Proveedor", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function


#End Region

#Region "Proveedores"

    ' 9 octubre 2013
    Public Function Insertar_Proveedor(proveedor As CProveedor) As Resultado
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            'Se crean parameros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@NombreComercial", proveedor.NombreComercial))
            datos.sqlParameters.Add(New SqlParameter("@RFC", proveedor.RFC))
            datos.sqlParameters.Add(New SqlParameter("@RazonSocial", proveedor.RazonSocial))
            datos.sqlParameters.Add(New SqlParameter("@Calle", proveedor.Calle))
            datos.sqlParameters.Add(New SqlParameter("@Numero", proveedor.Numero))
            datos.sqlParameters.Add(New SqlParameter("@Colonia", proveedor.Colonia))
            datos.sqlParameters.Add(New SqlParameter("@CP", proveedor.CP))
            datos.sqlParameters.Add(New SqlParameter("@IdEstado", proveedor.IdEstado))
            datos.sqlParameters.Add(New SqlParameter("@IdMunicipio", proveedor.IdMunicipio))
            datos.sqlParameters.Add(New SqlParameter("@Telefono", proveedor.Telefono))
            datos.sqlParameters.Add(New SqlParameter("@Comentarios", proveedor.Comentarios))
            datos.sqlParameters.Add(New SqlParameter("@Activo", 1))
            datos.sqlParameters.Add(New SqlParameter("@ClaProveedor", proveedor.ClaProveedor))
            datos.sqlParameters.Add(New SqlParameter("@TipoProveedor", proveedor.TipoProveedor))

            'Grabar
            datos.Comando_SP("Insert_Proveedor @NombreComercial,@RFC,@RazonSocial,@Calle,@Numero,@Colonia,@CP,@IdEstado,@IdMunicipio,@Telefono,@Comentarios,@Activo,@ClaProveedor,@TipoProveedor", res.DataTable)

            res.Dato = res.DataTable.Rows(0)(2) 'Aqui devuelve el Id
        Catch ex As Exception
            ''Se regresan y registran los datos del error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

            If datos.TransaccionIniciada Then datos.Rollback()

            Logs.LogError("Proveedores.vb", "Insert_Proveedor", ex.Message, ex.StackTrace)
        End Try

        Return res

    End Function

    'isra
    Public Function Consultar_Proveedores_Asistencia_II(ByVal usr As String, ByVal Id As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos(ObjDatos.CONNECTION_STRING_AsistenciaII)


        Try

            'Se crean parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@Id", Id))

            datos.Consulta_SP("Select_Proveedores_AsisII @Id", res.DataTable)


        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("ControlVehicular.vb", "Select_Proveedores_AsisII", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
        Return res
    End Function

    'termina isra


    Public Function Actualizar_Proveedores_AsistenciaII(usr As String) As Resultado
        Dim res As New Resultado
        'Dim datos As New ObjDatos(ObjDatos.CONNECTION_STRING_AsistenciaII)
        Dim datos As New ObjDatos()  'jrad 5-marz0-2013

        Try

            ' Graba el proveedor
            datos.Comando_SP("Actualizar_Proveedores_AsistenciaII", res.DataTable)

            ' Graba la auditoria
            Auditoria.Registrar(usr, 1020)
        Catch ex As Validacion_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            ''Se regresan y registran los datos del error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

            Logs.LogError("ControlVehicular.vb", "Actualizar_Proveedores_AsistenciaII", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function


    Public Function Insertar_Proveedor_Contacto(usr As String, contacto As CProveedorContacto) As Resultado
        Dim res As New Resultado
        Dim datos As New ObjDatos


        Try

            If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(contacto.Nombre) Then
                Throw New Validacion_Exception("Nombre")
            End If
            If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(contacto.Paterno) Then
                Throw New Validacion_Exception("Apellido Paterno")
            End If
            If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(contacto.Materno) Then
                Throw New Validacion_Exception("Apellido Materno")
            End If
            'If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(contacto.Email) Then
            '    Throw New Validacion_Exception("Email")
            'End If
            'If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(contacto.TelCel) Then
            '    Throw New Validacion_Exception("Teléfono Celular")
            'End If

            'Se crean parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@IdProveedor", contacto.IdProveedor))
            datos.sqlParameters.Add(New SqlParameter("@Nombre", contacto.Nombre))
            datos.sqlParameters.Add(New SqlParameter("@Paterno", contacto.Paterno))
            datos.sqlParameters.Add(New SqlParameter("@Materno", contacto.Materno))
            datos.sqlParameters.Add(New SqlParameter("@Email", contacto.Email))
            datos.sqlParameters.Add(New SqlParameter("@TelCel", contacto.TelCel))

            ' Graba el proveedor
            datos.Comando_SP("Insert_Proveedor_Contacto @IdProveedor, @Nombre, @Paterno, @Materno, @Email, @TelCel", res.DataTable)

            ' Graba la auditoria
            Auditoria.Registrar(usr, 1021, contacto.IdProveedor & "-" & res.DataTable.Rows(0)(2) & "-" & contacto.Nombre & " " & contacto.Paterno & " " & contacto.Materno)
        Catch ex As Validacion_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

            If datos.TransaccionIniciada Then datos.Rollback()

        Catch ex As Exception
            ''Se regresan y registran los datos del error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

            If datos.TransaccionIniciada Then datos.Rollback()

            Logs.LogError("ControlVehicular.vb", "Insert_Proveedor_Contacto", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function


    Public Function Actualizar_Proveedor(usr As String, proveedor As CProveedor) As Resultado
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try

            ' Valida que sean datos correctos
            If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(proveedor.NombreComercial) Then
                Throw New Validacion_Exception("Nombre Comercial")
            End If
            'If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(proveedor.RFC) Then
            '    Throw New Validacion_Exception("RFC")
            'End If
            'If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(proveedor.RazonSocial) Then
            '    Throw New Validacion_Exception("Razón Social")
            'End If
            'If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(proveedor.Calle) Then
            '    Throw New Validacion_Exception("Dirección - Calle")
            'End If
            'If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(proveedor.Numero) Then
            '    Throw New Validacion_Exception("Dirección - Número")
            'End If
            'If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(proveedor.Colonia) Then
            '    Throw New Validacion_Exception("Dirección - Colonia")
            'End If
            'If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(proveedor.CP) Then
            '    Throw New Validacion_Exception("Dirección - C.P.")
            'End If
            'If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(proveedor.Telefono) Then
            '    Throw New Validacion_Exception("Teléfono")
            'End If
            'If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(proveedor.Comentarios) Then
            '    Throw New Validacion_Exception("Comentarios")
            'End If

            'Se crean parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@Id", proveedor.Id))
            datos.sqlParameters.Add(New SqlParameter("@NombreComercial", proveedor.NombreComercial))
            datos.sqlParameters.Add(New SqlParameter("@RFC", proveedor.RFC))
            datos.sqlParameters.Add(New SqlParameter("@RazonSocial", proveedor.RazonSocial))
            datos.sqlParameters.Add(New SqlParameter("@Calle", proveedor.Calle))
            datos.sqlParameters.Add(New SqlParameter("@Numero", proveedor.Numero))
            datos.sqlParameters.Add(New SqlParameter("@Colonia", proveedor.Colonia))
            datos.sqlParameters.Add(New SqlParameter("@CP", proveedor.CP))
            datos.sqlParameters.Add(New SqlParameter("@IdEstado", proveedor.IdEstado))
            datos.sqlParameters.Add(New SqlParameter("@IdMunicipio", proveedor.IdMunicipio))
            datos.sqlParameters.Add(New SqlParameter("@Telefono", proveedor.Telefono))
            datos.sqlParameters.Add(New SqlParameter("@Comentarios", proveedor.Comentarios))
            datos.sqlParameters.Add(New SqlParameter("@ClaProveedor", proveedor.ClaProveedor))
            datos.sqlParameters.Add(New SqlParameter("@TipoProveedor", proveedor.TipoProveedor))

            ' Graba el proveedor
            datos.Comando_SP("Update_Proveedor @Id, @NombreComercial, @RFC, @RazonSocial, @Calle, @Numero, @Colonia, @CP, @IdEstado, @IdMunicipio, @Telefono, @Comentarios, @ClaProveedor, @TipoProveedor", res.DataTable)

            ' Graba la auditoria
            Auditoria.Registrar(usr, 1022, proveedor.Id & "-" & proveedor.NombreComercial & " " & proveedor.RFC)
        Catch ex As Validacion_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

            If datos.TransaccionIniciada Then datos.Rollback()

        Catch ex As Exception
            ''Se regresan y registran los datos del error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

            If datos.TransaccionIniciada Then datos.Rollback()

            Logs.LogError("ControlVehicular.vb", "Update_Proveedor", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function


    Public Function Actualizar_Proveedor_Contacto(usr As String, contacto As CProveedorContacto) As Resultado
        Dim res As New Resultado
        Dim datos As New ObjDatos


        Try

            If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(contacto.Nombre) Then
                Throw New Validacion_Exception("Nombre")
            End If
            If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(contacto.Paterno) Then
                Throw New Validacion_Exception("Apellido Paterno")
            End If
            If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(contacto.Materno) Then
                Throw New Validacion_Exception("Apellido Materno")
            End If
            'If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(contacto.Email) Then
            '    Throw New Validacion_Exception("Email")
            'End If
            'If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(contacto.TelCel) Then
            '    Throw New Validacion_Exception("Teléfono Celular")
            'End If

            'Se crean parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@Id", contacto.Id))
            datos.sqlParameters.Add(New SqlParameter("@Nombre", contacto.Nombre))
            datos.sqlParameters.Add(New SqlParameter("@Paterno", contacto.Paterno))
            datos.sqlParameters.Add(New SqlParameter("@Materno", contacto.Materno))
            datos.sqlParameters.Add(New SqlParameter("@Email", contacto.Email))
            datos.sqlParameters.Add(New SqlParameter("@TelCel", contacto.TelCel))

            ' Graba el proveedor
            datos.Comando_SP("Update_Proveedor_Contacto @Id, @Nombre, @Paterno, @Materno, @Email, @TelCel", res.DataTable)

            ' Graba la auditoria
            Auditoria.Registrar(usr, 1023, contacto.Id & "-" & contacto.Nombre & " " & contacto.Paterno & " " & contacto.Materno)
        Catch ex As Validacion_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

            If datos.TransaccionIniciada Then datos.Rollback()

        Catch ex As Exception
            ''Se regresan y registran los datos del error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

            If datos.TransaccionIniciada Then datos.Rollback()

            Logs.LogError("ControlVehicular.vb", "Update_Proveedor_Contacto", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function


    Public Function Eliminar_Proveedor_Contacto(usr As String, Id As Integer) As Resultado
        Dim res As New Resultado
        Dim datos As New ObjDatos


        Try

            'Se crean parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@Id", Id))

            ' Graba el proveedor
            datos.Comando_SP("Delete_Proveedor_Contacto @Id", res.DataTable)

            ' Graba la auditoria
            Auditoria.Registrar(usr, 1024, Id)
        Catch ex As Validacion_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

            If datos.TransaccionIniciada Then datos.Rollback()

        Catch ex As Exception
            ''Se regresan y registran los datos del error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

            If datos.TransaccionIniciada Then datos.Rollback()

            Logs.LogError("ControlVehicular.vb", "Delete_Proveedor_Contacto", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function
    'Isra
    Public Function Consultar_Proveedors(ByVal usr As String, ByVal prov As CBusqueda_Proveedor) As Resultado
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try

            'Se crean parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@IdRegion", prov.IdRegion))
            datos.sqlParameters.Add(New SqlParameter("@IdEstado", prov.IdEstado))

            datos.Consulta_SP("Select_Proveedors @IdRegion, @IdEstado", res.DataTable)


        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("ControlVehicular.vb", "Select_Proveedors", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
        Return res
    End Function

    Public Function Consultar_Proveedors_Mantenimiento(ByVal usr As String, ByVal prov As CBusqueda_Proveedor) As Resultado
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try

            'Se crean parámetros y se manda llamar el ws
            'datos.sqlParameters.Add(New SqlParameter("@IdRegion", prov.IdRegion))
            'datos.sqlParameters.Add(New SqlParameter("@IdEstado", prov.IdEstado))

            'datos.Consulta_SP("Select_Proveedors @IdRegion, @IdEstado", res.DataTable)
            datos.Consulta_SP("Select_Proveedors_Mantenimiento", res.DataTable)


        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("ControlVehicular.vb", "Select_Proveedors", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
        Return res
    End Function
    'Termina Isra

    Public Function Consultar_Proveedores(ByVal usr As String, ByVal prov As CBusqueda_Proveedor) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos


        Try

            'Se crean parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@NombreComercial", prov.NombreComercial))
            datos.sqlParameters.Add(New SqlParameter("@RFC", prov.RFC))
            datos.sqlParameters.Add(New SqlParameter("@RazonSocial", prov.RazonSocial))

            datos.Consulta_SP("Select_Proveedores @NombreComercial, @RFC, @RazonSocial", res.DataTable)


        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("ControlVehicular.vb", "Select_Proveedores", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
        Return res
    End Function


    Public Function Consultar_Proveedores_Completos(ByVal usr As String, ByVal Id As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos


        Try

            'Se crean parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@Id", Id))

            datos.Consulta_SP("Select_Proveedores_Completos @Id", res.DataTable)


        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("ControlVehicular.vb", "Select_Proveedores_Completos", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
        Return res
    End Function


    Public Function Consultar_Proveedores_Contactos(ByVal usr As String, ByVal IdProveedor As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos


        Try

            'Se crean parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@IdProveedor", IdProveedor))

            datos.Consulta_SP("Select_Proveedores_Contactos @IdProveedor", res.DataTable)


        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("ControlVehicular.vb", "Select_Proveedores_Contactos", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
        Return res
    End Function


    Public Function Insertar_Proveedor_Precio(ByVal usr As String, ByVal precio As CProveedorPrecio) As Resultado
        Dim res As New Resultado
        Dim datos As New ObjDatos


        Try

            'Se crean parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@IdProveedor", precio.IdProveedor))
            datos.sqlParameters.Add(New SqlParameter("@IdTipoConcepto", precio.IdTipoConcepto))
            datos.sqlParameters.Add(New SqlParameter("@IdConcepto", precio.IdConcepto))
            datos.sqlParameters.Add(New SqlParameter("@Precio", precio.Precio))

            ' Graba el proveedor
            datos.Comando_SP("Insert_Precio_Proveedor @IdProveedor, @IdTipoConcepto, @IdConcepto, @Precio", res.DataTable)

            ' Graba la auditoria
            Auditoria.Registrar(usr, 1025, res.DataTable.Rows(0)(2) & "-" & precio.Precio)
        Catch ex As Validacion_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

            If datos.TransaccionIniciada Then datos.Rollback()

        Catch ex As Exception
            ''Se regresan y registran los datos del error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

            If datos.TransaccionIniciada Then datos.Rollback()

            Logs.LogError("ControlVehicular.vb", "Insert_Precio_Proveedor", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function


    Public Function Actualizar_Proveedor_Precio(ByVal usr As String, ByVal precio As CProveedorPrecio) As Resultado
        Dim res As New Resultado
        Dim datos As New ObjDatos


        Try

            'Se crean parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@Id", precio.Id))
            datos.sqlParameters.Add(New SqlParameter("@Precio", precio.Precio))

            ' Graba el proveedor
            datos.Comando_SP("Update_Precio_Proveedor @Id, @Precio", res.DataTable)

            ' Graba la auditoria
            Auditoria.Registrar(usr, 1026, precio.Id & "-" & precio.Precio)
        Catch ex As Validacion_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

            If datos.TransaccionIniciada Then datos.Rollback()

        Catch ex As Exception
            ''Se regresan y registran los datos del error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

            If datos.TransaccionIniciada Then datos.Rollback()

            Logs.LogError("ControlVehicular.vb", "Update_Precio_Proveedor", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function


    Public Function Consultar_Proveedores_Precios(ByVal usr As String, ByVal IdProveedor As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos


        Try

            'Se crean parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@IdProveedor", IdProveedor))

            datos.Consulta_SP("Select_Proveedores_Precios @IdProveedor", res.DataTable)


        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("ControlVehicular.vb", "Select_Proveedores_Precios", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
        Return res
    End Function


#End Region

#Region "Aseguradoras"

    Public Function Insertar_Aseguradoras(ByVal usr As Integer, ByVal aseguradora As CAseguradora) As Resultado
        Dim res As New Resultado 'Objeto para resultados
        Dim datos As New ObjDatos

        Try
            ' Valida dato
            If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(aseguradora.Nombre) Then
                Throw New Validacion_Exception("Nombre")
            End If
            'Se crea parámetro y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@nombre", aseguradora.Nombre)) '
            datos.sqlParameters.Add(New SqlParameter("@telefono", aseguradora.Telefono)) '
            datos.sqlParameters.Add(New SqlParameter("@telefonosec", aseguradora.TelefonoSec)) '
            datos.Comando_SP("Insert_Aseguradoras @nombre, @Telefono, @TelefonoSec", res.DataTable)

            ' Graba la auditoria
            Auditoria.Registrar(usr, 1027, res.DataTable.Rows(0)(2) & "-" & aseguradora.Nombre)

        Catch ex As Validacion_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            ''Se regresan y registran los datos del error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("Catalogos.vb", "Insert_Aseguradoras", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function

    Public Function Insertar_Aseguradoras_Polizas(ByVal usr As Integer, ByVal aseguradora As CAseguradora) As Resultado
        Dim res As New Resultado 'Objeto para resultados
        Dim datos As New ObjDatos

        Try
            ' Valida dato
            If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(aseguradora.Nombre) Then
                Throw New Validacion_Exception("Nombre")
            End If
            'Se crea parámetro y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@nombre", aseguradora.Nombre)) '
            datos.sqlParameters.Add(New SqlParameter("@telefono", aseguradora.Telefono)) '
            datos.sqlParameters.Add(New SqlParameter("@telefonosec", aseguradora.TelefonoSec)) '
            datos.Comando_SP("Insert_Aseguradoras_Polizas @nombre, @Telefono, @TelefonoSec", res.DataTable)

            ' Graba la auditoria
            Auditoria.Registrar(usr, 1027, res.DataTable.Rows(0)(2) & "-" & aseguradora.Nombre)

        Catch ex As Validacion_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            ''Se regresan y registran los datos del error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("Catalogos.vb", "Insert_Aseguradoras", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function

    Public Function Eliminar_Aseguradoras(ByVal usr As Integer, ByVal id As Integer) As Resultado

        Dim res As New Resultado 'Objeto para regresar el Resultado2
        Dim datos As New ObjDatos 'Objeto para llamar ws

        Try
            'Se crea parámetro y se llama el ws
            datos.sqlParameters.Add(New SqlParameter("@Id", id))
            datos.Comando_SP("Delete_Aseguradoras @Id", res.DataTable)

            ' Graba la auditoria
            Auditoria.Registrar(usr, 1029, id)

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            ''Se regresan y registran los datos del error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("Catalogos.vb", "Delete_Aseguradoras", ex.Message, ex.StackTrace)
        End Try

        Return res
    End Function

    Public Function Eliminar_Aseguradoras_Polizas(ByVal usr As Integer, ByVal id As Integer) As Resultado

        Dim res As New Resultado 'Objeto para regresar el Resultado2
        Dim datos As New ObjDatos 'Objeto para llamar ws

        Try
            'Se crea parámetro y se llama el ws
            datos.sqlParameters.Add(New SqlParameter("@Id", id))
            datos.Comando_SP("Delete_Aseguradoras_Polizas @Id", res.DataTable)

            ' Graba la auditoria
            Auditoria.Registrar(usr, 1029, id)

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            ''Se regresan y registran los datos del error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("Catalogos.vb", "Delete_Aseguradoras", ex.Message, ex.StackTrace)
        End Try

        Return res
    End Function

    Public Function Actualizar_Aseguradoras(ByVal usr As Integer, ByVal aseguradora As CAseguradora) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            ' Valida que sea un dato correcto
            If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(aseguradora.Nombre) Then
                Throw New Validacion_Exception("Nombre")
            End If

            'Se crean los parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@Id", aseguradora.Id))
            datos.sqlParameters.Add(New SqlParameter("@Nombre", aseguradora.Nombre))
            datos.sqlParameters.Add(New SqlParameter("@Telefono", aseguradora.Telefono))
            datos.sqlParameters.Add(New SqlParameter("@TelefonoSec", aseguradora.TelefonoSec))
            datos.Comando_SP("Update_Aseguradoras @Id, @Nombre, @Telefono, @TelefonoSec", res.DataTable)

            ' Graba la auditoria
            Auditoria.Registrar(usr, 1028, aseguradora.Id & "-" & aseguradora.Nombre)
        Catch ex As Validacion_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("Catalogos.vb", "Update_Aseguradoras", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
        Return res
    End Function
    Public Function Actualizar_Aseguradoras_Polizas(ByVal usr As Integer, ByVal aseguradora As CAseguradora) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            ' Valida que sea un dato correcto
            If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(aseguradora.Nombre) Then
                Throw New Validacion_Exception("Nombre")
            End If

            'Se crean los parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@Id", aseguradora.Id))
            datos.sqlParameters.Add(New SqlParameter("@Nombre", aseguradora.Nombre))
            datos.sqlParameters.Add(New SqlParameter("@Telefono", aseguradora.Telefono))
            datos.sqlParameters.Add(New SqlParameter("@TelefonoSec", aseguradora.TelefonoSec))
            datos.Comando_SP("Update_Aseguradoras_Polizas @Id, @Nombre, @Telefono, @TelefonoSec", res.DataTable)

            ' Graba la auditoria
            Auditoria.Registrar(usr, 1028, aseguradora.Id & "-" & aseguradora.Nombre)
        Catch ex As Validacion_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("Catalogos.vb", "Update_Aseguradoras", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
        Return res
    End Function
    Public Function Consultar_Aseguradoras(ByVal usr As Integer, ByVal id As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            'Se crean los parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@Id", id))
            datos.Consulta_SP("Select_Aseguradoras @Id", res.DataTable)

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("Catalogos.vb", "Select_Aseguradoras", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function

    Public Function Consultar_Aseguradoras_Polizas(ByVal usr As Integer, ByVal id As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            'Se crean los parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@Id", id))
            datos.Consulta_SP("Select_Aseguradoras_Polizas @Id", res.DataTable)

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("Catalogos.vb", "Select_Aseguradoras", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function
#End Region

#Region "Eventos"
    Public Function Consultar_Eventos(ByVal usr As Integer, ByVal IdAseguradora As Integer, ByVal Id As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            'Se crean los parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@Id", Id))
            datos.sqlParameters.Add(New SqlParameter("@IdAseguradora", IdAseguradora))

            datos.Consulta_SP("Select_Eventos @IdAseguradora, @Id", res.DataTable)

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("Catalogos.vb", "Select_Eventos", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function

    Public Function Insertar_Eventos(ByVal usr As Integer, ByVal evento As CEvento) As Resultado
        Dim res As New Resultado 'Objeto para resultados
        Dim datos As New ObjDatos

        Try
            ' Valida que sea un dato correcto
            If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(evento.Nombre) Then
                Throw New Validacion_Exception("Nombre")
            End If

            'Se crea parámetro y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@Nombre", evento.Nombre))
            datos.sqlParameters.Add(New SqlParameter("@IdAseguradora", evento.IdAseguradora))
            datos.sqlParameters.Add(New SqlParameter("@DiasCobertura", evento.DiasCobertura))
            datos.Comando_SP("Insert_Eventos @Nombre, @IdAseguradora, @DiasCobertura", res.DataTable)

            ' Graba la auditoria
            Auditoria.Registrar(usr, 1030, res.DataTable.Rows(0)(2) & "-" & evento.Nombre)
        Catch ex As Validacion_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            ''Se regresan y registran los datos del error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("Catalogos.vb", "Insert_Eventos", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function

    Public Function Eliminar_Eventos(ByVal usr As Integer, ByVal id As Integer) As Resultado
        Dim res As New Resultado 'Objeto para regresar el Resultado2
        Dim datos As New ObjDatos 'Objeto para llamar ws

        Try
            'Se crea parámetro y se llama el ws
            datos.sqlParameters.Add(New SqlParameter("@Id", id))
            datos.Comando_SP("Delete_Eventos @Id", res.DataTable)

            ' Graba la auditoria
            Auditoria.Registrar(usr, 1032, id)

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            ''Se regresan y registran los datos del error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("Catalogos.vb", "Delete_Eventos", ex.Message, ex.StackTrace)
        End Try

        Return res
    End Function

    Public Function Actualizar_Eventos(ByVal usr As Integer, ByVal evento As CEvento) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            ' Valida que sea un dato correcto
            If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(evento.Nombre) Then
                Throw New Validacion_Exception("Nombre")
            End If

            'Se crean los parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@Id", evento.id))
            datos.sqlParameters.Add(New SqlParameter("@Nombre", evento.Nombre))
            datos.sqlParameters.Add(New SqlParameter("@IdAseguradora", evento.IdAseguradora))
            datos.sqlParameters.Add(New SqlParameter("@DiasCobertura", evento.DiasCobertura))
            datos.Comando_SP("Update_Eventos @Id, @Nombre, @IdAseguradora, @DiasCobertura", res.DataTable)

            ' Graba la auditoria
            Auditoria.Registrar(usr, 1031, evento.id & "-" & evento.Nombre)

        Catch ex As Validacion_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("Catalogos.vb", "Update_Eventos", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
        Return res
    End Function


#End Region


    ' Pendientes de saber si llevan alta - baja - cambio ***********************

#Region "Puestos"

    Public Function Consultar_Puestos(ByVal usr As Integer, ByVal id As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            'Se crean los parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@Id", id))
            datos.Consulta_SP("Select_Puestos @Id", res.DataTable)

        Catch ex As Validacion_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("ControlAcceso.vb", "Select_Puestos", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function

#End Region

#Region "Motivos de Baja (Pólizas, Vehículos, Servicios, Siniestros)"

    'Isra
    Public Function Consultar_MotivosCierreSiniestros(ByVal usr As Integer, ByVal id As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            'Se crean los parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@Id", id))
            datos.Consulta_SP("Select_MotivosCierreSiniestros @Id", res.DataTable)

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("Catalogos.vb", "Select_MotivosCierreSiniestros", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function
    'Termina Isra

    Public Function Consultar_MotivosBajaPolizas(ByVal usr As Integer, ByVal id As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            'Se crean los parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@Id", id))
            datos.Consulta_SP("Select_MotivosBajaPolizas @Id", res.DataTable)


        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("Catalogos.vb", "Select_MotivosBajaPolizas", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function

    Public Function Consultar_MotivosBajaVehiculos(ByVal usr As Integer, ByVal id As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            'Se crean los parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@Id", id))
            datos.Consulta_SP("Select_MotivosBajaVehiculos @Id", res.DataTable)

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("Catalogos.vb", "Select_MotivosBajaVehiculos", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function

    Public Function Consultar_MotivosBajaServicios(ByVal usr As Integer, ByVal id As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            'Se crean los parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@Id", id))
            datos.Consulta_SP("Select_MotivosBajaServicios @Id", res.DataTable)

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("Catalogos.vb", "Select_MotivosBajaServicios", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function

    Public Function Consultar_MotivosBajaSiniestros(ByVal usr As Integer, ByVal id As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            'Se crean los parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@Id", id))
            datos.Consulta_SP("Select_MotivosBajaSiniestros @Id", res.DataTable)

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("Catalogos.vb", "Select_MotivosBajaSiniestros", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function
#End Region

#Region "TiposCoberturas"

    Public Function Consultar_TiposCoberturas(ByVal usr As Integer, ByVal id As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            'Se crean los parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@Id", id))
            datos.Consulta_SP("Select_TiposCoberturas @Id", res.DataTable)

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("Catalogos.vb", "Select_TiposCoberturas", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function
#End Region

#Region "QuienReporta"
    Public Function Consultar_QuienesReportan(ByVal usr As Integer, ByVal Id As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            'Se crean los parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@Id", Id))

            datos.Consulta_SP("Select_QuienesReportan @Id", res.DataTable)

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("Catalogos.vb", "Select_QuienesReportan", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function
#End Region

#Region "TiposPagos"

    Public Function Consultar_TiposPagos(ByVal usr As Integer, ByVal id As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            'Se crean los parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@Id", id))
            datos.Consulta_SP("Select_TiposPagos @Id", res.DataTable)


        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("Catalogos.vb", "Select_TiposPagos", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function

#End Region

#Region "Tipos de Pagos Bancarios"

    Public Function Consultar_TiposPagosBancarios(ByVal usr As Integer, ByVal id As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            'Se crean los parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@Id", id))
            datos.Consulta_SP("Select_TiposPagosBancarios @Id", res.DataTable)


        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("Catalogos.vb", "Select_TiposPagosBancarios", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function

#End Region

#Region "Tipos de Tarjetas Bancarias"

    Public Function Consultar_TiposTarjetasBancarias(ByVal usr As Integer, ByVal id As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            'Se crean los parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@Id", id))
            datos.Consulta_SP("Select_TiposTarjetasBancarias @Id", res.DataTable)


        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("Catalogos.vb", "Select_TiposTarjetasBancarias", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function

#End Region

#Region "Tipos de Licencias"

    Public Function Consultar_TiposLicencias(ByVal usr As Integer, ByVal id As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            'Se crean los parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@Id", id))
            datos.Consulta_SP("Select_TiposLicencias @Id", res.DataTable)

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("Catalogos.vb", "Select_TiposLicencias", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function
#End Region

#Region "Tipos de Vehiculos"

    Public Function Consultar_TiposVehiculos(ByVal usr As Integer, ByVal id As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            'Se crean los parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@Id", id))
            datos.Consulta_SP("Select_TiposVehiculos @Id", res.DataTable)

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("Catalogos.vb", "Select_TiposVehiculos", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function
#End Region

#Region "Tipos de Compra"

    Public Function Consultar_TiposCompra(ByVal usr As Integer, ByVal id As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            'Se crean los parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@Id", id))
            datos.Consulta_SP("Select_TiposCompra @Id", res.DataTable)

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("Catalogos.vb", "Select_TiposCompra", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function
#End Region

#Region "UbicacionesEntrega"
    Public Function Consultar_UbicacionesEntrega(ByVal usr As Integer, ByVal Id As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            'Se crean los parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@Id", Id))

            datos.Consulta_SP("Select_UbicacionesEntrega @Id", res.DataTable)

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("Catalogos.vb", "Select_UbicacionesEntrega", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function
#End Region

#Region "TiposSiniestros"

    Public Function Consultar_TiposSiniestros(ByVal usr As String, ByVal Id As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            'Se crean parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@Id", Id))

            datos.Consulta_SP("Select_TiposSiniestros @Id", res.DataTable)

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("Catalogos.vb", "Select_TiposSiniestros", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
        Return res
    End Function

    Public Function Consultar_EstatusTiposSiniestros(ByVal usr As String, ByVal Id As Integer, ByVal IdTipoSiniestro As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            'Se crean parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@Id", Id))
            datos.sqlParameters.Add(New SqlParameter("@IdTipoSiniestro", IdTipoSiniestro))

            datos.Consulta_SP("Select_EstatusTiposSiniestros @Id, @IdTipoSiniestro", res.DataTable)

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("Catalogos.vb", "Select_EstatusTiposSiniestros", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
        Return res
    End Function
#End Region

#Region "Encuesta de Satisfaccion"

    Public Function Consultar_Encuesta_Preguntas(ByVal usr As String, Optional ByVal Id As Integer = -1) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos


        Try
            'Se crean parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@Id", Id))

            datos.Consulta_SP("Select_Encuesta_Preguntas @Id", res.DataTable)


        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("Catalogos.vb", "Consultar_Encuesta_Preguntas", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
        Return res
    End Function


    Public Function Consultar_Encuesta_Posibles_Respuestas(ByVal usr As String, Optional ByVal Id As Integer = -1) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos


        Try
            'Se crean parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@Id", Id))

            datos.Consulta_SP("Select_Encuesta_Posibles_Respuestas @Id", res.DataTable)


        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("Catalogos.vb", "Select_Encuesta_Posibles_Respuestas", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
        Return res
    End Function


#End Region

#Region "Tipos de Mantenimientos"

    Public Function Consultar_TiposMantenimientos(ByVal usr As Integer, ByVal id As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            'Se crean los parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@Id", id))
            datos.Consulta_SP("Select_TiposMantenimientos @Id", res.DataTable)

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("Catalogos.vb", "Select_TiposMantenimientos", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function
#End Region

#Region "Tipos de Gastos"

    Public Function Consultar_TiposGastos(ByVal usr As Integer, ByVal id As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            'Se crean los parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@Id", id))
            datos.Consulta_SP("Select_TiposGastos @Id", res.DataTable)

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("Catalogos.vb", "Select_TiposGastos", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function
#End Region

#Region "Tipos de Estatus de Servicios"
    Public Function Consultar_EstatusServicios(ByVal usr As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos
        Try
            datos.Consulta_SP("Select_EstatusServicios ", res.DataTable)
        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("Catalogos.vb", "Select_EstatusServicios", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
        Return res
    End Function
#End Region

#Region "Motivos de Salidas Improductivas"

    Public Function Consultar_MotivosSalidasImproductivas(ByVal usr As Integer, ByVal id As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            'Se crean los parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@Id", id))
            datos.Consulta_SP("Select_MotivosSalidasImproductivas @Id", res.DataTable)

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("Catalogos.vb", "Select_MotivosSalidasImproductivas", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function
#End Region

#Region "Motivos de Cambio de Auto en Contrato"

    Public Function Consultar_MotivosCambioAuto_Contrato(ByVal usr As Integer, ByVal id As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            'Se crean los parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@Id", id))
            datos.Consulta_SP("Select_Contratos_MotivosCambioAuto @Id", res.DataTable)

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("Catalogos.vb", "Select_Contratos_MotivosCambioAuto", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function
#End Region
#Region "Tipos de Reportes" ''Jrad marzo 2013

    Public Function Consultar_TiposReportes(ByVal usr As Integer, ByVal id As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            'Se crean los parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@Id", id))
            datos.Consulta_SP("Select_TiposReportes @Id", res.DataTable)


        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("Catalogos.vb", "Select_TiposReportes", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function

#End Region

#Region "Catalogo Bancos"

    Public Function Consultar_Cat_Bancos(ByVal usr As Integer, ByVal id As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            'Se crean los parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@Id", id))
            datos.Consulta_SP("Select_Bancos @Id", res.DataTable)


        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("Catalogos.vb", "Select_Bancos", ex.Message, ex.StackTrace)
        End Try
        Return res

    End Function

#End Region

#Region "Catalogo Causas de Rechazo Pagos"

    Public Function Consultar_Cat_Causas_Rechazo_Pagos(ByVal usr As Integer, ByVal id As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            'Se crean los parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@Id", id))
            datos.Consulta_SP("Select_Cat_Causas_Rechazo_Pagos @Id", res.DataTable)


        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("Catalogos.vb", "Select_Cat_Causas_Rechazo_Pagos", ex.Message, ex.StackTrace)
        End Try
        Return res

    End Function

#End Region
#Region "Tipos de Pagos Reembolsos"

    Public Function Consultar_TiposPagosReembolsos(ByVal usr As Integer, ByVal id As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            'Se crean los parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@Id", id))
            datos.Consulta_SP("Select_TiposPagosReembolsos @Id", res.DataTable)


        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("Catalogos.vb", "Select_TiposPagosReembolsos", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function

#End Region
    ' **************************************************************************
#Region "Catalogo Servicio"
    Public Function Consultar_NumServicio(ByVal usr As Integer, ByVal id As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            'Se crean los parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@Id", id))
            datos.Consulta_SP("Select_NumServicio @Id", res.DataTable)

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("Catalogos.vb", "Select_Marcas", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function
#End Region

#Region "Catalogo Status Extensiones"

    Public Function Consultar_CatalogoStatusExtension(ByVal usr As Integer, ByVal id As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            'Se crean los parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@Id", id))
            datos.Consulta_SP("Select_StatusExtensiones @Id", res.DataTable)


        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("Catalogos.vb", "Select_StatusExtensiones", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function

#End Region
End Class
