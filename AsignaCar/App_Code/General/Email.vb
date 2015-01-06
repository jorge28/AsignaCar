Imports System.Net.Mail
Imports Microsoft.VisualBasic

Public Class Email

    Public Shared MailHost As String
    Public Shared MailPort As String

    Public Sub Enviar([from] As String, [to] As String, subject As String, body As String)
        'On Error Resume Next

        If [to] = "" Then Exit Sub

        ' Envía un email
        Dim smtp As New SmtpClient(MailHost)
        smtp.UseDefaultCredentials = True

        smtp.Send([from], [to], subject, body)
    End Sub


    Public Sub Enviar2([from] As String, [to] As String, subject As String, body As String, Adjuntos_Texto() As String, ContentType_Texto() As String, Adjuntos_Archivo() As String, ContentType_Archivo() As String)
        'On Error Resume Next

        If [to] = "" Then Exit Sub

        ' Prepara los objetos
        Dim mensaje As New MailMessage()
        Dim smtp As New SmtpClient(MailHost)

        'smtp.UseDefaultCredentials = True

        ' Prepara el mensaje
        mensaje.To.Add([to].Trim)
        mensaje.From = New MailAddress([from])
        mensaje.Subject = subject
        mensaje.Body = body

        ' attachments como archivos
        If Adjuntos_Archivo IsNot Nothing Then
            For i As Integer = 0 To Adjuntos_Archivo.Length - 1
                mensaje.Attachments.Add(New Attachment(Adjuntos_Archivo(i), ContentType_Archivo(i)))
            Next
        End If

        ' attachments en forma de stream
        If Adjuntos_Texto IsNot Nothing Then
            For i As Integer = 0 To Adjuntos_Texto.Length - 1
                mensaje.Attachments.Add(Attachment.CreateAttachmentFromString(Adjuntos_Texto(i), ContentType_Texto(i)))
            Next
        End If

        ' Envía un email
        smtp.Send(mensaje)
    End Sub



End Class

Public Class Nextel

    Public Shared MailHost As String
    Public Shared MailPort As String

    Public Sub Enviar([from] As String, [to] As String, subject As String, body As String)
        'On Error Resume Next

        If [to] = "" Then Exit Sub

        ' Envía un email
        Dim smtp As New SmtpClient(MailHost)
        smtp.UseDefaultCredentials = True

        smtp.Send([from], [to], subject, body)
    End Sub

End Class