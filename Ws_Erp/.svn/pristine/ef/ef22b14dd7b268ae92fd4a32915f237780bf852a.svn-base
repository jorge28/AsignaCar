Imports System.IO
Imports System.Data.SqlClient

Public Class Logger

    Function insError(strMetodo As String, strDescripcion As String) As Integer

        Dim blnExito As Boolean = False
        Dim conexion As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("SQLConecction"))
        Dim command As New SqlCommand("spr_Ins_Error", conexion)
        command.CommandType = CommandType.StoredProcedure
        command.Parameters.AddWithValue("@strMetodoError", strMetodo)
        command.Parameters.AddWithValue("@strDescError", strDescripcion)

        Try
            conexion.Open()
            Dim reader As Integer = command.ExecuteNonQuery()
        Catch ex As Exception
            conexion.Close()
            Throw New ApplicationException(ex.Message)
        Finally
            conexion.Dispose()
            command.Dispose()
        End Try
        Return blnExito

    End Function

End Class
