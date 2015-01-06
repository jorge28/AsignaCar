<%@ Page Title="" Language="VB" MasterPageFile="~/MasterServicio.master" AutoEventWireup="false" CodeFile="Bitacora_General.aspx.vb" Inherits="CheckIn_Bitacora_General" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript">
    function Regresar_a_Busqueda() {
        __doPostBack('Regresar_a_Busqueda', '');
    }
        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="phAreaTrabajo" Runat="Server">
    <telerik:RadXmlHttpPanel ID="panelAgregar" runat="server">
        <table class="TablaCampos" >
        <tr>
        <td>
        </td>
        <td>
        </td>
        <td>
        </td>
        <td>
        </td>
        <td>
            <telerik:RadAjaxPanel ID="Contrato" runat="server" height="53px" 
                width="177px" Visible="false">
                <asp:Label ID="lblnocont" runat="server" CssClass="LabelNegrita" 
                    Text="No.Contrato:"></asp:Label>&nbsp;
                <asp:Label ID="lblnocontrato" runat="server" CssClass="Label" Text=""></asp:Label><br />
                <asp:Label ID="lblnoserv" runat="server" CssClass="LabelNegrita" 
                    Text="No.Servicio:"></asp:Label>&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblnoservicio" runat="server" CssClass="Label" Text=""></asp:Label><br />
                <asp:Label ID="lblstacon" runat="server" CssClass="LabelNegrita" 
                    Text="Estatus:"></asp:Label>&nbsp;
                <asp:Label ID="lblstatus" runat="server" CssClass="Label" Text=""></asp:Label>
            </telerik:RadAjaxPanel>
            </td>
        </tr>
            <tr>
                <td class="TdDatos">
                    <asp:Label ID="Label1" runat="server" Text="Bitácora:" CssClass="Label"></asp:Label>
                </td>
                <td class="TdDatos">
                    <telerik:RadTextBox ID="txtBitacora" runat="server" CssClass="TextBox"  Height="60" Width="500"
                        TextMode="MultiLine" Rows="3">
                    </telerik:RadTextBox>
                </td>
                <td>
                    &nbsp;</td>
                <td class="TdDatos">
                    <telerik:RadButton ID="btnAgregar" runat="server" CssClass="Button" Comando="1" 
                        Text="Agregar" Height="22px" Width="76px">
                    </telerik:RadButton>
                </td>
                <td class="TdDatos">
                    <telerik:RadNotification ID="notificacion0" runat="server">
                    </telerik:RadNotification>
                </td>
            </tr>
        </table>
    </telerik:RadXmlHttpPanel>


    <telerik:RadGrid Width="100%" 
        ID="grid" runat="server" AllowSorting="false"
        AutoGenerateColumns="False" CellSpacing="0" 
        CssClass="Grid" 
        MasterTableView-NoMasterRecordsText="No se encontraron registros" 
        HeaderStyle-Font-Bold="true" Culture="es-ES" GridLines="None" >
        <MasterTableView>
<CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

<RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column"></RowIndicatorColumn>

<ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column"></ExpandCollapseColumn>
            <Columns>
                <telerik:GridBoundColumn DataField="Consec" HeaderText="Consec" SortExpression="Consec" UniqueName="Consec" Visible="false">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="NumServicio" HeaderText="NumServicio" SortExpression="NumServicio" UniqueName="NumServicio" ItemStyle-Height="1%" ItemStyle-Width="1%">    
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Bitacora" HeaderText="Bitácora" SortExpression="Bitacora" UniqueName="Bitacora">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="NombreUsuario" HeaderText="Usuario" SortExpression="NombreUsuario" UniqueName="NombreUsuario">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Fecha" HeaderText="Fecha" SortExpression="Fecha" UniqueName="Fecha">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Contrato" 
                    HeaderText="Contrato" 
                    SortExpression="Contrato" UniqueName="Contrato" Visible="false">
                    </telerik:GridBoundColumn>
            </Columns>

<EditFormSettings>
<EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
</EditFormSettings>
        </MasterTableView>
        <ClientSettings>
            <Selecting CellSelectionMode="None" AllowRowSelect="True" />
            <Scrolling AllowScroll="True" UseStaticHeaders="True" SaveScrollPosition="True" ></Scrolling>
        </ClientSettings>

<HeaderStyle Font-Bold="True"></HeaderStyle>

<FilterMenu EnableImageSprites="False"></FilterMenu>
    </telerik:RadGrid>
    &nbsp;&nbsp;&nbsp;
    <telerik:RadTextBox ID="txtHidEstatus" Runat="server" Enabled="false" Visible="false">
    </telerik:RadTextBox>
    &nbsp;&nbsp;&nbsp;
    <telerik:RadTextBox ID="txtHidTipoAuto" Runat="server" Enabled="false" Visible="false">
</telerik:RadTextBox>
&nbsp;&nbsp;&nbsp;
    <telerik:RadTextBox ID="txtHidIdContrato" Runat="server" Enabled="false" Visible="false">
    </telerik:RadTextBox>
     <telerik:RadTextBox ID="txtHidIdServ" Runat="server" Enabled="false" Visible="false">
    </telerik:RadTextBox>
</asp:Content>

