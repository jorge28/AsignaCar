Imports Microsoft.VisualBasic
Imports System.Net

''' <summary>
''' Tipos de documentos válidos para Carpix
''' </summary>
''' <remarks></remarks>
Public Enum EnumTiposImagenes
    Empty
    Vehiculos
    Catarula_Poliza
    Doc_Tenencia
    Doc_Verificacion
    Doc_Tarj_Circulacion
    Doc_Arrendamiento
    Doc_SisLoc
    Siniestro
    CheckIn
    CheckOut
End Enum

Public Class Imagenes
    Public Shared URL_Carpix As String

    Public Expediente As String = ""
    Public TipoImagen As EnumTiposImagenes = EnumTiposImagenes.Empty
    Public Consec As Integer = -1


    Public Function ContieneImagenes() As Boolean
        'Return False
        Dim respuesta As String
        Dim url As String

        url = getURL("estatus")

        'Creamos el cliente que pedira el recurso de la URL
        Dim cliente As WebClient = New WebClient()

        'Pedimos el recurso de la URL como string
        Try
            ' Verifica si hay imagenes en Carpix
            respuesta = Trim(cliente.DownloadString(url))
        Catch ex As Exception
            respuesta = ""
        End Try

        'Revisamos si respuesta es igual a {tipodoc:contiene}
        If respuesta.Trim = "{tipodoc:contiene}" Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function getURL(accion As String) As String
        'Creamos el url
        Dim url As String = URL_Carpix

        Select Case TipoImagen
            Case EnumTiposImagenes.Catarula_Poliza, EnumTiposImagenes.Siniestro
                url &= "?expediente=" & Expediente
            Case Else
                url &= "?expediente=" & Right("000000000" & Expediente, 9)
        End Select
        url &= "&tipodoc=" & Right("000" & CStr(TipoImagen), 3)
        If Consec <> -1 Then
            url &= "&consec=" & Right("0000" & CStr(Consec), 4)
        End If

        Return url & "&accion=" & accion
    End Function

End Class
