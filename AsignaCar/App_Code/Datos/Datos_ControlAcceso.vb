Imports Microsoft.VisualBasic
Imports Acceso_a_Datos
Imports System.Data
Imports System.Data.SqlClient

Public Class Datos_ControlAcceso

#Region "Usuarios"
    Public Function Insertar_Usuarios(usr As Integer, usuario As CUsuario) As Resultado
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            ' Valida que sea un dato correcto
            If Not Validacion.Solo_LetrasDigitosEspaciosSinNumeros(usuario.Nombre) Then
                Throw New Validacion_Exception("Nombre")
            End If

            If Not Validacion.Solo_LetrasDigitosEspaciosSinNumeros(usuario.ApellidoMaterno) Then
                Throw New Validacion_Exception("Apellido Materno")
            End If

            If Not Validacion.Solo_LetrasDigitosEspaciosSinNumeros(usuario.ApellidoPaterno) Then
                Throw New Validacion_Exception("Apellido Paterno")
            End If

            'If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(usuario.Username) Then
            '    Throw New Validacion_Exception("Username")
            'End If

            'If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(usuario.Password) Then
            '    Throw New Validacion_Exception("Password")
            'End If

            'Se crea parámetro y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@ApellidoMaterno", usuario.ApellidoMaterno))
            datos.sqlParameters.Add(New SqlParameter("@ApellidoPaterno", usuario.ApellidoPaterno))
            datos.sqlParameters.Add(New SqlParameter("@Email", usuario.Email))
            datos.sqlParameters.Add(New SqlParameter("@IdGrupo", usuario.IdGrupo))
            datos.sqlParameters.Add(New SqlParameter("@Nombre", usuario.Nombre))
            datos.sqlParameters.Add(New SqlParameter("@TelCel", usuario.TelCel))
            datos.sqlParameters.Add(New SqlParameter("@TelNextel", usuario.TelNextel))
            datos.sqlParameters.Add(New SqlParameter("@Username", usuario.Username))
            datos.sqlParameters.Add(New SqlParameter("@Password", usuario.Password))
            datos.sqlParameters.Add(New SqlParameter("@IdPuesto", usuario.IdPuesto))
            datos.sqlParameters.Add(New SqlParameter("@IdRegion", usuario.IdRegion))
            datos.sqlParameters.Add(New SqlParameter("@IdCoordinacion", usuario.IdCoordinacion))
            datos.sqlParameters.Add(New SqlParameter("@IdAlmacen", usuario.IdAlmacen))

            datos.Comando_SP("Insert_Usuarios @IdGrupo, @Nombre, @Username, @Password, @ApellidoPaterno, @ApellidoMaterno, @TelCel, @TelNextel, @Email, @IdPuesto, @IdRegion, @IdCoordinacion, @IdAlmacen", res.DataTable)

            ' Graba la auditoria
            Auditoria.Registrar(usr, 1035, res.DataTable.Rows(0)(2) & "-" & usuario.Username)

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
            Logs.LogError("ControlAcceso.vb", "Insert_Usuarios", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function

    Public Function Eliminar_Usuarios(usr As Integer, id As Integer) As Resultado

        Dim res As New Resultado 'Objeto para regresar el Resultado2
        Dim datos As New ObjDatos 'Objeto para llamar ws

        Try

            'Se crea parámetro y se llama el ws
            datos.sqlParameters.Add(New SqlParameter("@Id", id))
            datos.Comando_SP("Delete_Usuarios @Id", res.DataTable)

            ' Graba la auditoria
            Auditoria.Registrar(usr, 1037, id)

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
            Logs.LogError("ControlAcceso.vb", "Delete_Usuarios", ex.Message, ex.StackTrace)
        End Try

        Return res
    End Function

    Public Function Actualizar_Usuarios(usr As Integer, usuario As CUsuario) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            ' Valida que sea un dato correcto
            If Not Validacion.Solo_LetrasDigitosEspaciosSinNumeros(usuario.Nombre) Then
                Throw New Validacion_Exception("Nombre")
            End If

            If Not Validacion.Solo_LetrasDigitosEspaciosSinNumeros(usuario.ApellidoMaterno) Then
                Throw New Validacion_Exception("Apellido Materno")
            End If

            If Not Validacion.Solo_LetrasDigitosEspaciosSinNumeros(usuario.ApellidoPaterno) Then
                Throw New Validacion_Exception("Apellido Paterno")
            End If

            'Se crean los parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@ApellidoMaterno", usuario.ApellidoMaterno))
            datos.sqlParameters.Add(New SqlParameter("@ApellidoPaterno", usuario.ApellidoPaterno))
            datos.sqlParameters.Add(New SqlParameter("@Email", usuario.Email))
            datos.sqlParameters.Add(New SqlParameter("@IdGrupo", usuario.IdGrupo))
            datos.sqlParameters.Add(New SqlParameter("@Nombre", usuario.Nombre))
            datos.sqlParameters.Add(New SqlParameter("@TelCel", usuario.TelCel))
            datos.sqlParameters.Add(New SqlParameter("@TelNextel", usuario.TelNextel))
            datos.sqlParameters.Add(New SqlParameter("@Id", usuario.Id))
            datos.sqlParameters.Add(New SqlParameter("@IdPuesto", usuario.IdPuesto))
            datos.sqlParameters.Add(New SqlParameter("@IdRegion", usuario.IdRegion))
            datos.sqlParameters.Add(New SqlParameter("@IdCoordinacion", usuario.IdCoordinacion))
            datos.sqlParameters.Add(New SqlParameter("@IdAlmacen", usuario.IdAlmacen))
            datos.sqlParameters.Add(New SqlParameter("@Username", usuario.Username))

            datos.Comando_SP("Update_Usuarios @Id, @Nombre, @IdGrupo, @ApellidoPaterno, @ApellidoMaterno, @TelCel, @TelNextel, @Email, @IdPuesto, @IdRegion, @IdCoordinacion, @IdAlmacen, @Username", res.DataTable)

            ' Graba la auditoria
            Auditoria.Registrar(usr, 1036, usuario.Id)

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
            Logs.LogError("ControlAcceso.vb", "Update_Usuarios", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
        Return res
    End Function

    Public Function Consultar_Usuarios(usr As Integer, username As String) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            'Se crean los parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@Username", username))
            datos.Consulta_SP("Select_Usuarios @Username", res.DataTable)

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("ControlAcceso.vb", "Select_Usuarios", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function
#End Region

#Region "Login y Cambio de Password"
    Public Function ComprobarLogin(usr As Integer, username As String, password As String) As Resultado
        Dim datos As New ObjDatos
        Dim res As New Resultado

        Try
            ' Comprueba el login
            datos.sqlParameters.Add(New SqlParameter("@Username", username))
            datos.sqlParameters.Add(New SqlParameter("@Password", password))
            datos.Consulta_SP("Comprobar_Usuario_Login @Username,  @Password", res.DataTable)

        Catch ex As Validacion_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("ControlAcceso.vb", "Comprobar_Usuario_Login", ex.Message, ex.StackTrace)
        End Try
        Return res

    End Function

    Public Function ConsultarUsuario(usr As Integer, username As String) As Resultado
        Dim datos As New ObjDatos
        Dim res As New Resultado

        Try

            'Se consulta al usuario específicado
            datos.sqlParameters.Add(New SqlParameter("@Username", username))
            datos.Consulta_SP("Select_Usuarios @Username", res.DataTable)

        Catch ex As Validacion_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("ControlAcceso.vb", "Select_Usuarios", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function

    'Public Function Actualizar_Usuarios_Password(usr As Integer, IdUsuario As Integer, password As String) As Resultado
    '    Dim res As New Resultado
    '    Dim datos As New ObjDatos

    '    Try

    '        'Se consulta al usuario específicado
    '        datos.sqlParameters.Add(New SqlParameter("@Id", IdUsuario))
    '        datos.sqlParameters.Add(New SqlParameter("@Password", password))
    '        datos.Comando_SP("Update_Usuarios_Password @Id, @Password", res.DataTable)

    '        ' Graba la auditoria
    '        Auditoria.Registrar(usr, 1038, IdUsuario)

    '    Catch ex As Validacion_Exception
    '        'Se regresan y registran los datos de error
    '        res.Estatus = Estatus.Error
    '        res.ErrorDesc = ex.Message

    '    Catch ex As AccesoDatos_Exception
    '        'Se regresan y registran los datos de error
    '        res.Estatus = Estatus.Error
    '        res.ErrorDesc = ex.Message

    '    Catch ex As Exception
    '        'Se regresan y registran los datos de error
    '        res.Estatus = Estatus.Error
    '        res.ErrorDesc = ex.Message
    '        Logs.LogError("ControlAcceso.vb", "Update_Usuarios_Password", ex.Message, ex.StackTrace)
    '    End Try
    '    Return res
    'End Function
#End Region

#Region "Grupos"
    Public Function Insertar_Grupos(usr As Integer, grupo As CGrupo) As Resultado
        Dim res As New Resultado 'Objeto para resultados
        Dim datos As New ObjDatos

        Try
            ' Valida que sea un dato correcto
            If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(grupo.Nombre) Then
                Throw New Validacion_Exception("Nombre")
            End If

            'Se crea parámetro y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@nombre", grupo.Nombre)) '
            datos.Comando_SP("Insert_Grupos @nombre", res.DataTable)

            ' Graba la auditoria
            Auditoria.Registrar(usr, 1039, res.DataTable.Rows(0)(2) & "-" & grupo.Nombre)

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
            Logs.LogError("ControlAcceso.vb", "Insert_Grupos", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function

    Public Function Eliminar_Grupos(usr As Integer, id As Integer) As Resultado
        Dim res As New Resultado 'Objeto para regresar el Resultado2
        Dim datos As New ObjDatos 'Objeto para llamar ws

        Try
            'Se crea parámetro y se llama el ws
            datos.sqlParameters.Add(New SqlParameter("@Id", id))
            datos.Comando_SP("Delete_Grupos @Id", res.DataTable)

            ' Graba la auditoria
            Auditoria.Registrar(usr, 1041, id)

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
            Logs.LogError("ControlAcceso.vb", "Delete_Grupos", ex.Message, ex.StackTrace)
        End Try

        Return res
    End Function

    Public Function Actualizar_Grupos(usr As Integer, grupo As CGrupo) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            ' Valida que sea un dato correcto
            If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(grupo.Nombre) Then
                Throw New Validacion_Exception("Nombre")
            End If

            'Se crean los parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@Id", grupo.Id))
            datos.sqlParameters.Add(New SqlParameter("@Nombre", grupo.Nombre))
            datos.Comando_SP("Update_Grupos @Id, @Nombre", res.DataTable)

            ' Graba la auditoria
            Auditoria.Registrar(usr, 1040, grupo.Id & "-" & grupo.Nombre)

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
            Logs.LogError("ControlAcceso.vb", "Update_Grupos", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
        Return res
    End Function

    Public Function Consultar_Grupos(usr As Integer, id As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            'Se crean los parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@Id", id))
            datos.Consulta_SP("Select_Grupos @Id", res.DataTable)

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
            Logs.LogError("ControlAcceso.vb", "Select_Grupos", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function
#End Region

#Region "Permisos"
    Public Function Consultar_Permisos_Funcion(usr As Integer, IdGrupo As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            'Se crean los parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@IdGrupo", IdGrupo))
            datos.Consulta_SP("Permisos_Funciones @IdGrupo", res.DataTable)

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
            Logs.LogError("ControlAcceso.vb", "Consultar_Permisos_Funciones", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function

    Public Function Consultar_Permisos_Funcion_Accion(usr As Integer, IdGrupo As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            'Se crean los parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@IdGrupo", IdGrupo))
            datos.Consulta_SP("Permisos_Funciones_Acciones @IdGrupo", res.DataTable)

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
            Logs.LogError("ControlAcceso.vb", "Consultar_Permisos_Funciones_Acciones", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function

    Public Function Consultar_Funciones(usr As Integer, id As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            'Se crean los parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@Id", id))
            datos.Consulta_SP("Select_Funciones @Id", res.DataTable)

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
            Logs.LogError("ControlAcceso.vb", "Select_Funciones", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function

    Public Function Consultar_Acciones(usr As Integer, id As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            'Se crean los parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@Id", id))
            datos.Consulta_SP("Select_Acciones @Id", res.DataTable)

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
            Logs.LogError("ControlAcceso.vb", "Select_Acciones", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function

    Public Function Consultar_Grupos_Perfiles(usr As Integer, idGrupo As Integer, idPerfil As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            'Se crean los parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@IdGrupo", idGrupo))
            datos.sqlParameters.Add(New SqlParameter("@IdPerfil", idPerfil))
            datos.Consulta_SP("Select_Grupos_Perfiles @IdGrupo, @IdPerfil", res.DataTable)

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
            Logs.LogError("ControlAcceso.vb", "Select_Grupos_Perfiles", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function

    Public Function Grabar_Grupos_Perfiles(usr As Integer, grupo As CGrupo) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            ' Inicia la transacción
            datos.BeginTransaction()

            ' Primero borra los perfiles que tiene asignados
            datos.sqlParameters.Add(New SqlParameter("@IdGrupo", grupo.Id))
            datos.Comando_SP_Transaccion("Delete_Grupos_Perfiles @IdGrupo", res.DataTable)

            ' Después se graba cada uno de los registros
            For Each perfil As String In grupo.Perfiles
                datos.sqlParameters.Add(New SqlParameter("@IdGrupo", grupo.Id))
                datos.sqlParameters.Add(New SqlParameter("@IdPerfil", perfil))
                datos.Comando_SP_Transaccion("Insert_Grupos_Perfiles @IdGrupo, @IdPerfil", res.DataTable)
            Next

            ' Hace el commit 
            datos.Commit()

            ' Graba la auditoria
            Auditoria.Registrar(usr, 1045, grupo.Id)

        Catch ex As Validacion_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            ' Hace el rollback
            If datos.TransaccionIniciada Then datos.Rollback()

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("ControlAcceso.vb", "Update_Grupos_Perfiles", ex.Message, ex.StackTrace)
            ' Hace el rollback
            If datos.TransaccionIniciada Then datos.Rollback()
        End Try
        'Regresa Resultado2
        Return res
    End Function

    Public Function Consultar_Perfiles_Funciones(usr As Integer, IdPerfil As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            'Se crean los parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@IdPerfil", IdPerfil))
            datos.Consulta_SP("Select_Perfiles_Funciones @IdPerfil", res.DataTable)

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
            Logs.LogError("ControlAcceso.vb", "Select_Perfiles_Funciones", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function

    Public Function Grabar_Perfiles_Funciones(usr As Integer, perfil As CPerfil) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            ' Inicia la transacción
            datos.BeginTransaction()

            ' Primero selecciona los formularios que tiene asignado el perfil
            datos.sqlParameters.Add(New SqlParameter("@IdPerfil", perfil.Id))
            datos.Comando_SP_Transaccion("Delete_Perfiles_Funciones @IdPerfil", res.DataTable)

            ' Después se graba cada uno de los registros
            For Each funcion As String In perfil.Funciones
                datos.sqlParameters.Add(New SqlParameter("@IdPerfil", perfil.Id))
                datos.sqlParameters.Add(New SqlParameter("@IdFuncion", funcion))
                datos.Comando_SP_Transaccion("Insert_Perfiles_Funciones @IdPerfil, @IdFuncion", res.DataTable)
            Next

            'Se eliminan los formularios que no esten en el nuevo conjunto
            datos.sqlParameters.Add(New SqlParameter("@IdPerfil", perfil.Id))
            datos.Comando_SP_Transaccion("Delete_Perfiles_Funciones_Acciones @IdPerfil", res.DataTable)

            ' Hace el commit 
            datos.Commit()

            ' Graba la auditoria
            Auditoria.Registrar(usr, 1046, perfil.Id)

        Catch ex As Validacion_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            ' Hace el rollback
            If datos.TransaccionIniciada Then datos.Rollback()

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("ControlAcceso.vb", "Update_Perfiles_Funciones", ex.Message, ex.StackTrace)
            ' Hace el rollback
            If datos.TransaccionIniciada Then datos.Rollback()
        End Try
        'Regresa Resultado2
        Return res
    End Function

    Public Function Consultar_Funciones_Acciones(usr As Integer, IdFuncion As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            'Se crean los parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@IdFuncion", IdFuncion))
            datos.Consulta_SP("Select_Funciones_Acciones @IdFuncion", res.DataTable)

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
            Logs.LogError("ControlAcceso.vb", "Select_Funciones_Acciones", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function

    Public Function Consultar_Perfiles_Funciones_Acciones(usr As Integer, idPerfil As Integer, idFuncion As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            'Se crean los parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@IdPerfil", idPerfil))
            datos.sqlParameters.Add(New SqlParameter("@IdFuncion", idFuncion))
            datos.Consulta_SP("Select_Perfiles_Funciones_Acciones @IdPerfil, @IdFuncion", res.DataTable)

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
            Logs.LogError("ControlAcceso.vb", "Select_Perfiles_Funciones_Acciones", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function

    Public Function Grabar_Perfiles_Funciones_Acciones(usr As Integer, perfil As CPerfil) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            ' Inicia la transacción
            datos.BeginTransaction()

            ' Primero borra los perfiles que tiene asignados
            datos.sqlParameters.Add(New SqlParameter("@IdPerfil", perfil.Id))
            datos.sqlParameters.Add(New SqlParameter("@IdFuncion", perfil.Acciones_IdFuncion))
            datos.Comando_SP_Transaccion("Delete_Perfiles_Funciones_Acciones @IdPerfil, @IdFuncion", res.DataTable)

            ' Después se graba cada uno de los registros
            For Each accion As String In perfil.Acciones
                datos.sqlParameters.Add(New SqlParameter("@IdFuncion", perfil.Acciones_IdFuncion))
                datos.sqlParameters.Add(New SqlParameter("@IdPerfil", perfil.Id))
                datos.sqlParameters.Add(New SqlParameter("@IdAccion", accion))
                datos.Comando_SP_Transaccion("Insert_Perfiles_Funciones_Acciones @IdPerfil, @IdFuncion, @IdAccion", res.DataTable)
            Next

            ' Hace el commit 
            datos.Commit()

            ' Graba la auditoria
            Auditoria.Registrar(usr, 1047, perfil.Id)

        Catch ex As Validacion_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            ' Hace el rollback
            If datos.TransaccionIniciada Then datos.Rollback()

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("ControlAcceso.vb", "Grabar_Perfiles_Funciones_Acciones", ex.Message, ex.StackTrace)
            ' Hace el rollback
            If datos.TransaccionIniciada Then datos.Rollback()
        End Try
        'Regresa Resultado2
        Return res
    End Function
#End Region

#Region "Perfiles"
    Public Function Insertar_Perfiles(usr As Integer, perfil As CPerfil) As Resultado
        Dim res As New Resultado 'Objeto para resultados
        Dim datos As New ObjDatos

        Try
            ' Valida que sea un dato correcto
            If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(perfil.Nombre) Then
                Throw New Validacion_Exception("Nombre")
            End If

            'Se crea parámetro y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@nombre", perfil.Nombre)) '
            datos.Comando_SP("Insert_Perfiles @nombre", res.DataTable)

            ' Graba la auditoria
            Auditoria.Registrar(usr, 1042, res.DataTable.Rows(0)(2) & "-" & perfil.Nombre)

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
            Logs.LogError("ControlAcceso.vb", "Insert_Perfiles", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function

    Public Function Eliminar_Perfiles(usr As Integer, id As Integer) As Resultado
        Dim res As New Resultado 'Objeto para regresar el Resultado2
        Dim datos As New ObjDatos 'Objeto para llamar ws

        Try
            'Se crea parámetro y se llama el ws
            datos.sqlParameters.Add(New SqlParameter("@Id", id))
            datos.Comando_SP("Delete_Perfiles @Id", res.DataTable)

            ' Graba la auditoria
            Auditoria.Registrar(usr, 1044, id)

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
            Logs.LogError("ControlAcceso.vb", "Delete_Perfiles", ex.Message, ex.StackTrace)
        End Try

        Return res
    End Function

    Public Function Actualizar_Perfiles(usr As Integer, perfil As CPerfil) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            ' Valida que sea un dato correcto
            If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(perfil.Nombre) Then
                Throw New Validacion_Exception("Nombre")
            End If

            'Se crean los parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@Id", perfil.Id))
            datos.sqlParameters.Add(New SqlParameter("@Name", perfil.Nombre))
            datos.Comando_SP("Update_Perfiles @Id, @Name", res.DataTable)

            ' Graba la auditoria
            Auditoria.Registrar(usr, 1043, perfil.Id & "-" & perfil.Nombre)

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
            Logs.LogError("ControlAcceso.vb", "Update_Perfiles", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
        Return res
    End Function

    Public Function Consultar_Perfiles(usr As Integer, id As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            'Se crean los parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@Id", id))
            datos.Consulta_SP("Select_Perfiles @Id", res.DataTable)

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
            Logs.LogError("ControlAcceso.vb", "Select_Perfiles", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function
#End Region

#Region "Menú"
    Public Function Consultar_Menu(usr As String, IdGrupo As Integer) As Resultado
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            'Se crean parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@IdGrupo", IdGrupo))
            datos.Consulta_SP("Select_Menu @IdGrupo", res.DataTable)

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            ''Se regresan y registran los datos del error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("General.vb", "Consultar_Menu", ex.Message, ex.StackTrace)
        End Try
        Return res

    End Function
#End Region


End Class
