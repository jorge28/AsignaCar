Imports Microsoft.VisualBasic

Public Class Seguridad
    Public Shared Sub QuitarUsuarioListado(ByRef App As HttpApplicationState, userId As String)
        'Genera un arreglo con los id de los usuarios en session
        App.Lock()

        Try
            ' Separa la lista en un arreglo
            Dim ArregloID() As String = App("usuarios").ToString().Split({"|"}, StringSplitOptions.RemoveEmptyEntries)

            App("usuarios") = "|"

            For Each id As String In ArregloID
                If id <> userId Then
                    App("usuarios") = App("usuarios") & id & "|"
                End If
            Next
        Catch ex As Exception
        Finally
            App.UnLock()
        End Try

    End Sub
End Class
