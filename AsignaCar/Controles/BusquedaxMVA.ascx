<%@ Control Language="VB" AutoEventWireup="false" CodeFile="BusquedaxMVA.ascx.vb" Inherits="Controles_BusquedaxMVA" %>
<%--Ventanas modales --%>

        <telerik:radwindowmanager ID="RadWindowManager" runat="server">
            <Windows>
                <telerik:RadWindow runat="server" ID="winImagenes" NavigateUrl="~/General/Imagenes.aspx" ReloadOnShow="true" Modal="true" Width="800px" Height="500px" VisibleTitlebar="False" VisibleStatusbar="False" ShowContentDuringLoad="False">
                </telerik:RadWindow>
            </Windows>
	</telerik:radwindowmanager>
<table style="background-color: #DCDCDC; width:100%">
<tr>
<td style="width:1%"></td>
<td>
            <asp:Label ID="lblMVA" runat="server" Text=" MVA:" CssClass="LabelNegrita"></asp:Label>
            &nbsp;
             <telerik:RadNumericTextBox ID="RadNumerictxtMVA" runat="server" AutoPostBack="true">
                    <NumberFormat ZeroPattern="n" DecimalDigits="0"></NumberFormat>
             </telerik:RadNumericTextBox>
</td>
<td>
             <asp:Label ID="lblPlacas" runat="server" Text=" Placas:" CssClass="LabelNegrita"></asp:Label>
             &nbsp;
             <telerik:RadTextBox ID="RadtxtPlacas"  runat="server" AutoPostBack="true">
             </telerik:RadTextBox>
</td>
<td>
             <asp:ImageButton ID="RadBusquedaMVA" runat="server" ImageUrl="~/img/btnbuscar.png">
             </asp:ImageButton>
</td>
</tr>
</table>
<table style="width: 100%">
<tr>
<td>
<telerik:RadSplitter  ID = "RadSplitter1"  runat = "server" Width="100%" Height="150px" BorderColor="Green" BorderWidth="0" > 
 <telerik:RadPane  ID = "MiddlePane"  runat = "server"  Scrolling = "None" Width="100%" Height="150px" BorderColor="Red" BorderWidth="0" >
   <telerik:RadSplitter  ID = "NestedSplitter"  runat = "server" 
                        Orientation = "Horizontal"  Width="100%"  Height="150px" BorderWidth="0" BorderColor="Yellow" > 
     <telerik:RadPane  ID = "TopPane"  runat = "server" BackColor="Black" Width="100%"  Height="140px" BorderWidth="0" BorderColor="Beige" >
     <table style="background-color:black; width:100%">
<tr>
<td>
<asp:Label ID="lblMar" runat="server" Text="Marca:" CssClass="LabelNegritaPrincipal"></asp:Label>
&nbsp;
<asp:Label ID="lblMarca" runat="server" Font-Size="Smaller" CssClass="LabelPrincipal" ></asp:Label>
</td>
<td>
<asp:Label ID="lblSubM" runat="server" Text="SubMarca:" CssClass="LabelNegritaPrincipal" ></asp:Label>
&nbsp;
<asp:Label ID="lblSubMarca" runat="server" Text="" Font-Size="Smaller" CssClass="LabelPrincipal" ></asp:Label>
</td>
<td>
<asp:Label ID="lblMod" runat="server" Text="Modelo:" CssClass="LabelNegritaPrincipal"></asp:Label>
&nbsp;
<asp:Label ID="lblModelo" runat="server" Text="" Font-Size="Smaller" CssClass="LabelPrincipal"></asp:Label>
</td>
<td>
</td>
</tr>
<tr>
<td>
<asp:Label ID="lblCol" runat="server" Text="Color:" CssClass="LabelNegritaPrincipal" ></asp:Label>
&nbsp;
<asp:Label ID="lblColor" runat="server" Text="" Font-Size="Smaller" CssClass="LabelPrincipal" ></asp:Label>
</td>
<td>
<asp:Label ID="lblEst" runat="server" Text="Estatus:" CssClass="LabelNegritaPrincipal"></asp:Label>
&nbsp;
<asp:Label ID="lblEstatus" runat="server" Text="" Font-Size="Smaller" CssClass="LabelPrincipal"></asp:Label>
</td>
<td>
<asp:Label ID="lblFec" runat="server" Text="Fecha de Compra:" CssClass="LabelNegritaPrincipal"></asp:Label>
&nbsp;
<asp:Label ID="lblFecCompra" runat="server" Text="" Font-Size="Smaller" CssClass="LabelPrincipal"></asp:Label>
</td>
<td>
</td>
</tr>
<tr>
<td>
<asp:Label ID="lblRegion" runat="server" Text="" Font-Size="Smaller" Visible="false" ></asp:Label>
</td>
<td>
</td>
<td>
</td>
</tr>
<tr>
<td>
<telerik:RadTextBox ID="txtHidKilometraje" runat="server"  Enabled="false" Visible="false">
</telerik:RadTextBox>
</td>
<td>
<telerik:RadTextBox ID="txtHidEstatus" runat="server"  Enabled="false" Visible="false">
</telerik:RadTextBox>
</td>
<td>
         
             <telerik:RadNotification ID="notificacion0" runat="server">
             </telerik:RadNotification>
         
</td>
</tr> 
</table> 
       </telerik:RadPane>          
     <telerik:RadSplitBar  ID = "RadSplitBar3"  runat = "server"  CollapseMode="Forward" Width="100%" BackColor="Orange"/> 
     <telerik:RadPane ID="paneprueba" runat="server" Width="0%" BorderWidth="0" BorderColor="Transparent"></telerik:RadPane>
     </telerik:RadSplitter>     
     </telerik:RadPane>
 </telerik:RadSplitter> 
</td>
</tr>
</table>