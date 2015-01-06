Imports Telerik.Web.UI

Partial Class General_Inicio
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        ' Oculta el título
        Dim div As HtmlControls.HtmlGenericControl
        Dim div2 As HtmlControls.HtmlGenericControl
        div = Master.FindControl("divTitulo")
        'div.Visible = False
        div2 = Master.FindControl("divMenuMasterHorizontal")
        'div2.Visible = False

        If Not IsPostBack Then
            ''Rafael
            Session("IdFuncion") = 101

        End If
    End Sub
End Class
