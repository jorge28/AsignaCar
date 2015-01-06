Imports System.Web.UI.HtmlControls

Partial Class General_Imagenes
    Inherits System.Web.UI.Page

    Protected Sub VerificarOrigen()
        ' Verifica que se haya llamado la pantalla desde un lugar seguro
        If Not Session("OrigenSeguro") Then
            Response.Redirect("Inicio.aspx")
            Exit Sub
        End If
        Session("OrigenSeguro") = False
    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            VerificarOrigen()

            'Carga ddlMotivo
            CargarImagenes()
        End If
    End Sub

    Protected Sub CargarImagenes()
        'Dim img As Imagenes = Session("ObjImagenes")
        'imgIFrame.Attributes.Add("src", img.getURL("ver"))
    End Sub

    Protected Sub btnCerrar_Click(sender As Object, e As System.EventArgs) Handles btnCerrar.Click
        RadAjaxPanel.ResponseScripts.Add("Cerrar();")
    End Sub
End Class
