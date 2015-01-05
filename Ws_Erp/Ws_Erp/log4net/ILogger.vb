Public Class ILogger

    Dim logger As Logger = New Logger()


    Public Sub insError(ByVal strMetodo As String, ByVal strDescripcion As String)

        Dim filas As Integer = logger.insError(strMetodo, strDescripcion)

    End Sub
End Class
