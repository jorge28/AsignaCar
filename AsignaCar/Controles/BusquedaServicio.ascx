<%@ Control Language="VB" AutoEventWireup="false" CodeFile="BusquedaServicio.ascx.vb" Inherits="Controles_BusquedaServicio" %>
<%--Ventanas modales --%>
        <telerik:radwindowmanager ID="RadWindowManager" runat="server">
            <Windows>
                <telerik:RadWindow runat="server" ID="winImagenes" NavigateUrl="~/General/Imagenes.aspx" ReloadOnShow="true" Modal="true" Width="800px" Height="500px" VisibleTitlebar="False" VisibleStatusbar="False" ShowContentDuringLoad="False">
                </telerik:RadWindow>
            </Windows>
	</telerik:radwindowmanager>
     <table style="background-color:#DCDCDC; width:100%">
         <tr>
           <td style="width:25%" align="center">
              <asp:Label ID="lblNoServicio" runat="server" Text="Reporte Servicio:" CssClass="LabelNegrita"></asp:Label>
           </td>
            <td style="width:20%"> 
               <telerik:RadNumericTextBox ID="RdNumServicio" runat="server" AutoPostBack="true">
                   <NumberFormat ZeroPattern="n" DecimalDigits="0" GroupSeparator=""></NumberFormat>
               </telerik:RadNumericTextBox>&nbsp;
                 </td>
            <td style="width:17%" align="left">
               
                 <asp:ImageButton ID="btnBusqueda" runat="server" ImageUrl="~/img/btnbuscar.png" >
               </asp:ImageButton>
           </td>
            <td style="width:17%"> 
                <telerik:RadTextBox ID="txtHidIdServicio" Runat="server" Enabled="false" Visible="false">
                </telerik:RadTextBox>
           </td>
            <td style="width:16%" align="right">
                            <telerik:RadTextBox ID="txtHidEstatus" Runat="server" Enabled="false" Visible="false">
                </telerik:RadTextBox>
           
           </td>
            <td style="width:16%"> 
               
                <telerik:RadButton ID="RdLimpiar" runat="server" Text="Limpiar" Visible="false">
                </telerik:RadButton>
           </td>
         </tr>
         </table>
         <table style="width: 100%">
<tr>
<td>
<telerik:RadSplitter  ID = "RadSplitter1"  runat = "server" Width="100%" Height="165px" BorderColor="Green" BorderWidth="0" > 
 <telerik:RadPane  ID = "MiddlePane"  runat = "server"  Scrolling = "None" Width="100%" Height="150px" BorderColor="Red" BorderWidth="0" >
   <telerik:RadSplitter  ID = "NestedSplitter"  runat = "server" 
                        Orientation = "Horizontal"  Width="100%"  Height="150px" BorderWidth="0" BorderColor="Yellow" > 
     <telerik:RadPane  ID = "TopPane"  runat = "server" BackColor="Black" Width="100%"  Height="155px" BorderWidth="0" BorderColor="Beige" >
     <table style="background-color:black; width:100%">
     <tr>
           <td align="left" style="width:3%">
            <asp:Label ID="lblAseguradora" runat="server" Text="Cliente:" CssClass="LabelNegritaPrincipal"></asp:Label>
            <br \ />
               <asp:Label ID="lblNombreAseguradora" runat="server" CssClass="LabelPrincipal" 
                   Font-Size="Smaller"></asp:Label>
           </td>
            <td align="left" style="width:3%"> 
                <asp:Label ID="lblAsegurado" runat="server" CssClass="LabelNegritaPrincipal" 
                    Text="Asegurado:"></asp:Label>
                    <br \ />
                <asp:Label ID="lblNombreAsegurado" runat="server" CssClass="LabelPrincipal" Text="" Font-Size="Smaller"></asp:Label>
              </td>
            <td align="left" style="width:3%">
                
                <asp:Label ID="lblTelef" runat="server" CssClass="LabelNegritaPrincipal" 
                    Text="Teléfono Asegurado:"></asp:Label>
                    <br \ />
                <asp:Label ID="lblTelefono" runat="server" CssClass="LabelPrincipal" Font-Size="Smaller" 
                    Text=""></asp:Label>
              </td>
            <td align="left" style="width:3%"> 
                <asp:Label ID="lblEstado" runat="server" CssClass="LabelNegritaPrincipal" Text="Estado:"></asp:Label>
                <br \ />
                <asp:Label ID="lblNombreEstado" runat="server" CssClass="LabelPrincipal" 
                    Font-Size="Smaller" Text=""></asp:Label>
              </td>
            <td align="left" style="width:3%">
                <asp:Label ID="lblMunicipio" runat="server" CssClass="LabelNegritaPrincipal" 
                    Text="Municipio:"></asp:Label>
                    <br \ />
                <asp:Label ID="lblNombreMunicipio" runat="server" CssClass="LabelPrincipal" 
                    Font-Size="Smaller" Text=""></asp:Label>
              </td>
            <td align="left" style="width:3%"> 
                <asp:Label ID="lblEvento" runat="server" CssClass="LabelNegritaPrincipal" 
                    Text="Evento:"></asp:Label>
                    <br \ />
                <asp:Label ID="lblDescripcionEvento" runat="server" CssClass="LabelPrincipal" 
                    Font-Size="Smaller" Text=""></asp:Label>
              </td>
         </tr>
          <tr>
           <td  align="left" style="width:3%">              
               <asp:Label ID="lblFecActivacion" runat="server" CssClass="LabelNegritaPrincipal" 
                   Text="Fecha de Activación:"></asp:Label>
                   <br \ />
               <asp:Label ID="lblFechaActivacion" runat="server" CssClass="LabelPrincipal" 
                   Font-Size="Smaller" Text=""></asp:Label>                   
               </td>
            <td align="left" style="width:3%">
                <asp:Label ID="lblPoliza" runat="server" CssClass="LabelNegritaPrincipal" 
                    Text="No. Poliza:"></asp:Label>
                    <br \ />
                <asp:Label ID="lblNoPoliza" runat="server" CssClass="LabelPrincipal" 
                    Font-Size="Smaller" Text=""></asp:Label>
              </td>
            <td align="left" style="width:3%">                                        
                <asp:Label ID="lblEstatus" runat="server" CssClass="LabelNegritaPrincipal" 
                    Text="Estatus:"></asp:Label>
                    <br \ />
                <asp:Label ID="lblDescripcionEstatus" runat="server" CssClass="LabelPrincipal" 
                    Font-Size="Smaller" Text=""></asp:Label>
              </td>
            <td align="left" style="width:3%">
                 <asp:Label ID="lblCont" runat="server" CssClass="LabelNegritaPrincipal" 
                     Text="Contrato:"></asp:Label>
                     &nbsp;
                 <asp:Label ID="lblContrato" runat="server" CssClass="LabelPrincipal" 
                     Font-Size="Smaller" Text=""></asp:Label>
                     <br \ /> 
                 <asp:Label ID="lblnocont" runat="server" CssClass="LabelNegritaPrincipal" Text="No:"></asp:Label>
                 &nbsp;
                 <asp:Label ID="lblnocontrato" runat="server" CssClass="LabelPrincipal" 
                     Font-Size="Smaller" Text=""></asp:Label>
                 <asp:Label ID="lblIdContrato" runat="server" CssClass="LabelPrincipal" 
                     Font-Size="Smaller" Visible="false"></asp:Label>
                 </td>
            <td align="left" style="width:3%">
                <asp:Label ID="lblSiniestro" runat="server" CssClass="LabelNegritaPrincipal" 
                    Text="No. Siniestro:" Visible="false"></asp:Label>
                    <br \ />
                <asp:Label ID="lblDescripcionSiniestro" runat="server" CssClass="LabelPrincipal" 
                    Font-Size="Smaller" Text=""></asp:Label>
              </td>
            <td align="left" style="width:3%">
                <asp:Label ID="lbldiasextras" runat="server" CssClass="LabelNegritaPrincipal" 
                    Text="Evento con Costo con:" Visible="false"></asp:Label>
                    <br \ />
                <asp:Label ID="diasrentacosto" runat="server" CssClass="LabelPrincipal" 
                    Font-Size="Smaller" Text="" Visible="false"></asp:Label>
                <asp:Label ID="lbldiasren" runat="server" CssClass="LabelNegritaPrincipal" 
                    Text="dias de Renta" Visible="false"></asp:Label>
            </td>
         </tr>
          <tr>
           <td align="left" style="width:3%"> 
               <asp:Label ID="lblFecAtenc" runat="server" CssClass="LabelNegritaPrincipal" 
                   Text="Fecha de Atención:" Visible="false"></asp:Label>
                   <br \ />
               <asp:Label ID="lblFechaAtencion" runat="server" CssClass="LabelPrincipal" 
                   Font-Size="Smaller" Text="" Visible="false"></asp:Label>
           </td>
            <td align="left" style="width:3%"> 
                <asp:Label ID="lblFechaIni" runat="server" CssClass="LabelNegritaPrincipal" 
                    Text="Fecha Entrega:" Visible="false"></asp:Label>
                    <br \ />
                <asp:Label ID="lblFechaInicio" runat="server" CssClass="LabelPrincipal" 
                    Font-Size="Smaller" Text=""></asp:Label>
                </td>
            <td align="left" style="width:3%">                
                    <asp:Label ID="lblFechaFin" runat="server" CssClass="LabelNegritaPrincipal" 
                        Text="Fecha Devolución:" Visible="false"></asp:Label>
                        <br \ />
                    <asp:Label ID="lblFechaFinal" runat="server" CssClass="LabelPrincipal" 
                        Font-Size="Smaller" Text=""></asp:Label>
                    <br \ />
                </td>
            <td align="left" style="width:3%">                                     
                    
                <asp:Label ID="lblFechaExte" runat="server" CssClass="LabelNegritaPrincipal" 
                    Text="Fecha Devolución despúes de la Extensión:" Visible="false"></asp:Label>
                    <br \ />                    
                <asp:Label ID="lblFechaExtension" runat="server" CssClass="LabelPrincipal" 
                    Font-Size="Smaller" Text=""></asp:Label>
                    
                </td>
            <td align="left" style="width:3%">                
                <asp:Label ID="lblFechaDevoPre" runat="server" CssClass="LabelNegritaPrincipal" 
                    Text="Fecha Devolución Prevista:" Visible="false"></asp:Label>
                    <br \ />
                <asp:Label ID="lblFechaDevoPrevista" runat="server" CssClass="LabelPrincipal" 
                    Font-Size="Smaller" Text="" Visible="false"></asp:Label>
              </td>
            <td align="left" style="width:3%">                     
                &nbsp;</td>
         </tr>
          <tr>
           <td align="left" style="width:3%">
               <asp:Label ID="lblFechaCier" runat="server" CssClass="LabelNegritaPrincipal" 
                   Text="Fecha Cierre del Servicio:" Visible="false"></asp:Label>
                   <br \ />
               <asp:Label ID="lblFechaCierre" runat="server" CssClass="LabelPrincipal" 
                   Font-Size="Smaller" Text="" Visible="false"></asp:Label>
               </td>
            <td align="left" style="width:3%">
                <asp:Label ID="lblFechaDevoRe" runat="server" CssClass="LabelNegritaPrincipal" 
                    Text="Fecha Devolución Real:" Visible="false"></asp:Label>
                    <br \ />
                <asp:Label ID="lblFechaDevolucionReal" runat="server" CssClass="LabelPrincipal" 
                    Font-Size="Smaller" Text="" Visible="false"></asp:Label>
                </td>
            <td align="left" style="width:3%">                
                &nbsp;</td>
            <td align="left" style="width:3%"> 
                
                <asp:Label ID="lblFechaEntreRe" runat="server" CssClass="LabelNegritaPrincipal" 
                    Text="Fecha Entrega Real:" Visible="false"></asp:Label>
                    <br \ />
                <asp:Label ID="lblFechaEntregaReal" runat="server" CssClass="LabelPrincipal" 
                    Font-Size="Smaller" Text="" Visible="false"></asp:Label>
              </td>
            <td align="left" style="width:3%">
                &nbsp;</td>
            <td align="left" style="width:3%"> 
                &nbsp;</td>
         </tr>         
</table> 
       </telerik:RadPane>          
     <telerik:RadSplitBar  ID = "RadSplitBar3"  runat = "server"  CollapseMode="Forward" Width="100%" BackColor="orange"/> 
     <telerik:RadPane ID="paneprueba" runat="server" Width="0%" BorderWidth="0" BorderColor="Transparent"></telerik:RadPane>
     </telerik:RadSplitter>     
     </telerik:RadPane>
 </telerik:RadSplitter> 
</td>
</tr>
</table>
<telerik:RadNotification ID="notificacion0" runat="server">
</telerik:RadNotification>

