<%@ Control Language="VB" AutoEventWireup="false" CodeFile="CtrlAlarma.ascx.vb" Inherits="Controles_CtrlAlarma" %>

<table width="100%">
    <tr>
        <td colspan="6">
            <asp:Label ID="label" Text="Envío de Alarma" runat="server" 
                CssClass="Subtitulo"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="TdDatos">
            <asp:Label ID="Label7" runat="server" Text="Tipo de Mensaje:" CssClass="Label"></asp:Label>
        </td>
        <td class="TdDatos">
            <asp:CheckBox ID="chkSMS" runat="server" CssClass="CheckBox" Text="SMS" />
            <asp:CheckBox ID="chkEmail" runat="server"  CssClass="CheckBox" Text="Email"/>
        </td>
        <td ></td>
        <td class="TdDatos">
            <asp:Label ID="Label6" runat="server" Text="Periodo de Alerta (en días):" 
                CssClass="Label"></asp:Label>
        </td>
        <td class="TdDatos">
            <telerik:RadNumericTextBox ID="txtPeriodoAlerta" Runat="server" CssClass="TextBoxPequeño" NumberFormat-DecimalDigits="0" NumberFormat-GroupSeparator="" MinValue="0" MaxValue="1000"></telerik:RadNumericTextBox>
        </td>
        <td >
            <asp:CompareValidator Display="Dynamic" ID="validador2" runat="server" 
                ControlToValidate="txtPeriodoAlerta" CssClass="ValidacionError"
                ErrorMessage="*" Operator="DataTypeCheck" Type="Integer" ></asp:CompareValidator>
            <asp:RequiredFieldValidator ID="validador1" runat="server" Display="Dynamic"
                ErrorMessage="*" CssClass="ValidacionError" ControlToValidate="txtPeriodoAlerta"></asp:RequiredFieldValidator>
        </td>
                    
    </tr>
    <tr>
        <td style="width:100%" valign="top" colspan="6">
            <asp:Label ID="Label1" runat="server" Text="Perfiles para enviar la alarma" CssClass="Label"></asp:Label><br />
            <telerik:RadGrid 
                ID="gridAlarma" runat="server" 
                AutoGenerateColumns="False" CellSpacing="0" 
                CssClass="Grid" MasterTableView-NoMasterRecordsText="No se encontraron registros" GridLines="Both" HeaderStyle-Font-Bold="true" Height="150px" Width="300px">
                <MasterTableView>
                    <Columns>
                        <telerik:GridTemplateColumn ItemStyle-Width="25px">
                            <ItemTemplate>
                                <asp:CheckBox ID="chk" runat="server" />
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridBoundColumn DataField="Id" HeaderText="Id" UniqueName="Id" Visible="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Nombre" HeaderText="Perfil" UniqueName="Nombre">
                        </telerik:GridBoundColumn>
                    </Columns>
                </MasterTableView>
                <ClientSettings>
                    <Selecting CellSelectionMode="None" AllowRowSelect="True" />
                    <Scrolling AllowScroll="True" UseStaticHeaders="True" SaveScrollPosition="True" ></Scrolling>
                </ClientSettings>
            </telerik:RadGrid>
        </td>
        
    </tr>
</table>
