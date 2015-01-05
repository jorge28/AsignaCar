Imports System.Data.SqlClient

Public Class LoginDao

    Dim inLogger As ILogger = New ILogger()

    Public Function selUsuario(strUsuario As String, strContrasenia As String) As Boolean

        Dim blnExito As Boolean = False
        Dim conexion As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("SQLConecction"))
        Dim command As New SqlCommand("spr_Sel_Usuario", conexion)
        command.CommandType = CommandType.StoredProcedure
        command.Parameters.AddWithValue("@strUsuario", strUsuario)
        command.Parameters.AddWithValue("@strContrasenia", strContrasenia)

        Try
            conexion.Open()
            Dim reader As SqlDataReader = command.ExecuteReader()

            If reader.HasRows Then
                Do While reader.Read()
                    blnExito = True
                Loop
            Else
                blnExito = False
            End If
        Catch ex As DataException

            inLogger.insError("Error en metodo: selUsuario()", ex.Message)

        Catch ex As Exception

            inLogger.insError("Error en metodo: selUsuario()", ex.Message)

        Finally
            conexion.Dispose()
            command.Dispose()
        End Try
        Return blnExito
    End Function

End Class
