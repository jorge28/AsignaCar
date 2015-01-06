<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Login.aspx.vb" Inherits="Autenticacion_Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="CACHE-CONTROL" content="NO-CACHE" />
    <meta http-equiv="EXPIRES" content="Mon, 22 Jul 2002 11:12:01 GMT" />
    <title>AsignaCar</title>
    <style type="text/css">
        #vert-hoz{
            position: fixed;
            top: 50%;
            left: 31%;
            margin-left: -265px;
            margin-top: -403px;
        }
        .style1
        {
            width: 67%;
        }
        .style2
        {
            height: 748px;
        }
        #form1
        {
            height: 37px;
        }
    </style>
</head>
<body style="background-image:url('../img/backLogin.jpg'); background-repeat:repeat-x;">
<div id="divinicio" runat="server" style="position: absolute">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

        <telerik:RadWindowManager ID="RadWindowManager" runat="server">
        </telerik:RadWindowManager>   
    <%--Terminan los controles iniciales de telerik--%>
    <div id="div1" runat="server" style="position: absolute">
        <table style="background-image:url('../img/portadainicio1.jpg'); background-repeat:no-repeat; width: 1018px;" 
        id="vert-hoz">
            <tr>
                <td class="style2" >
                    <table>
                        <tr>
                            <td class="style1">
                                <telerik:RadNotification ID="notificacion0" runat="server">
                                </telerik:RadNotification>
                            </td>
                            <td style="width:50%">
                                <table style="height: 143px" >
                                    <tr>
                                        <td align="right">
                                            &nbsp;</td>
                                        <td>
                                            <telerik:RadTextBox ID="txtUsername" Runat="server" CssClass="TextBox" 
                                                MaxLength="30" Text="">
                                            </telerik:RadTextBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator1" runat="server"  CssClass="ValidacionError"
                                                ControlToValidate="txtUsername" ErrorMessage="*"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>
                                            <telerik:RadTextBox ID="txtPassword" Runat="server" CssClass="TextBox" 
                                                MaxLength="30" TextMode="Password" Text="admin">
                                            </telerik:RadTextBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator2" runat="server" CssClass="ValidacionError"
                                                ControlToValidate="txtPassword" ErrorMessage="*"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td>
                                            <asp:CheckBox ID="chkRecordar" runat="server" Text="Recordarme" 
                                                CssClass="CheckBox" ForeColor="Lime" />
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td align="center">
                                            <br />
                                            <asp:ImageButton ID="btnAceptar" runat="server"  
                                                ImageUrl="~/img/Entrar.png"></asp:ImageButton>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td style="width:25%">
                            </td>
                        </tr>
                    </table>
                    <br />
                    <br />
                    <br />
                </td>
            </tr>
        </table>
        </div>
    </form>
    </div>
</body>
</html>
