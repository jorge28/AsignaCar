Imports System.Xml
Imports System

Public Class fileXML

    Dim inLogger As ILogger = New ILogger()

    Public Function Leer_XML(ByVal id As Integer)

        Dim strMensaje As String = ""

        Try
            Dim documentoxml As XmlDocument
            Dim nodelist As XmlNodeList
            Dim nodo As XmlNode
            documentoxml = New XmlDocument
            documentoxml.Load(HttpContext.Current.Server.MapPath("~/XML/cadenas.xml"))
            nodelist = documentoxml.SelectNodes("/mensajes/mensaje")
            For Each nodo In nodelist
                If nodo.Attributes.GetNamedItem("id").Value = id Then
                    Dim nodo1 = nodo.ChildNodes(0).InnerText
                    strMensaje = (nodo1)
                End If
            Next
        Catch ex As Exception
            inLogger.insError("Error en el metodo Leer_XML()", ex.Message)
        End Try
        Return strMensaje

    End Function

End Class
