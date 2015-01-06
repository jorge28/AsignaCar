<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Imagenes.aspx.vb" Inherits="General_Imagenes" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="CACHE-CONTROL" content="NO-CACHE" />
    <meta http-equiv="EXPIRES" content="Mon, 22 Jul 2002 11:12:01 GMT" />
    <title>AutoSigue</title>

    <%--Script para cerrar la ventana--%>
    <script type="text/javascript">
        function GetRadWindow() {
            var oWindow = null;

            try {
                if (window.radWindow) oWindow = window.radWindow;
                else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow;

                return oWindow;
            } catch (e) {
            }
        }

        function Cerrar() {
            //get a reference to the RadWindow
            var oWnd = GetRadWindow();
            //close the RadWindow 
            oWnd.close();
        }

    </script>
</head>
<body>
    <form id="form2" runat="server">
        <%--Controles iniciales de telerik --%>
	    <telerik:RadScriptManager ID="RadScriptManager" runat="server">
		    <Scripts>
			    <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js" />
			    <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js" />
			    <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js" />
		    </Scripts>
	    </telerik:RadScriptManager>

        <telerik:RadAjaxManager ID="RadAjaxManager" runat="server">
        </telerik:RadAjaxManager>
    
        <%--Terminan los controles de Telerik--%>
        <telerik:RadAjaxPanel ID="RadAjaxPanel" runat="server">
            <asp:Button ID="btnCerrar" runat="server" CssClass="Button" CausesValidation="false" Text="Cerrar" ></asp:Button>
        </telerik:RadAjaxPanel>

        <iframe id="imgIFrame" runat="server" width="700px" height="500px"> 
        </iframe>

    </form>
</body>
</html>
