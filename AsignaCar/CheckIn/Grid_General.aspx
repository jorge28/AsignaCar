<%@ Page Title="" Language="VB" MasterPageFile="~/MasterServicio.master" AutoEventWireup="false" CodeFile="Grid_General.aspx.vb" Inherits="CheckIn_Grid_General" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="phAreaTrabajo" Runat="Server">
    <%--Campos para ingresar datos--%>
    <table class="TablaCampos" >
        <tr>
            <td style="width:10%">
                <asp:Label ID="lblNumServicio" runat="server" Text="Número de Servicio:" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%">                
                <telerik:RadNumericTextBox ID="txtNumServicio" Runat="server" CssClass="TextBox">
                </telerik:RadNumericTextBox>
            </td>
            <td style="width:10%"></td>
            <td style="width:10%">
                <asp:Label ID="lblEstatus" runat="server" Text="Estatus:" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%">
                <telerik:RadComboBox CssClass="ComboBox" ID="cmbEstatus" Runat="server" 
                    DataTextField="Nombre" DataValueField="Id" MarkFirstMatch="True">
                </telerik:RadComboBox>
            </td>
            <td style="width:10%"></td>
            <td style="width:10%">
                <asp:Label ID="lblTipoAsigna" runat="server" Text="Tipo de Asignación:" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%">
                <telerik:RadComboBox CssClass="ComboBox" ID="cmbTipoAsignacion" Runat="server" 
                    DataTextField="Nombre" DataValueField="Id" MarkFirstMatch="True">
                </telerik:RadComboBox>
            </td>
            <td style="width:10%"></td>
            <td style="width:10%"></td>
        </tr>
        <tr>
            <td style="width:10%">
                <asp:Label ID="lblAseguradora" runat="server" Text="Aseguradora:" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%">
                <telerik:RadComboBox CssClass="ComboBox" ID="cmbAseguradora" Runat="server" 
                    DataTextField="Nombre" DataValueField="Id" MarkFirstMatch="True">
                </telerik:RadComboBox>
            </td>
            <td style="width:10%"></td>
            <td style="width:10%">
                <asp:Label ID="lblPoliza" runat="server" Text="Póliza:" CssClass="Label" ></asp:Label>
            </td>
            <td style="width:10%">
                <telerik:RadTextBox ID="txtPoliza" Runat="server" CssClass="TextBox">
                </telerik:RadTextBox>
            </td>
            <td style="width:10%"></td>
            <td style="width:10%">
                <asp:Label ID="lblNumSiniestro" runat="server" Text="Número de Siniestro:" CssClass="Label" ></asp:Label>
            </td>
            <td style="width:10%">
                <telerik:RadTextBox ID="txtNumSiniestro" Runat="server" CssClass="TextBox">
                </telerik:RadTextBox>
            </td>
            <td style="width:10%"></td>
            <td style="width:10%"></td>
        </tr>
        <tr>
            <td style="width:10%">
                <asp:Label ID="lblAsegBene" runat="server" Text="Asegurado/Beneficiario:" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%">
                <telerik:RadTextBox ID="txtAsegurado" Runat="server" CssClass="TextBox">
                </telerik:RadTextBox>
            </td>
            <td style="width:10%">
            </td>
            <td style="width:10%">
                <asp:Label ID="lblEstado" runat="server" Text="Estado:" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%">
                <telerik:RadComboBox CssClass="ComboBox" ID="cmbEstado" Runat="server" 
                    DataTextField="Nombre" DataValueField="Id" MarkFirstMatch="True">
                </telerik:RadComboBox>
            </td>
            <td style="width:10%"></td>
            <td style="width:10%">
                <asp:Label ID="lblProveedor" runat="server" Text="Proveedor:" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%">
                <telerik:RadComboBox CssClass="ComboBox" ID="cmbProveedor" Runat="server" 
                    DataTextField="Nombre" DataValueField="Id" MarkFirstMatch="True">
                </telerik:RadComboBox>
            </td>
            <td style="width:10%"></td>
            <td style="width:10%"></td>
        </tr>        
        <tr>
            <td style="width:20%" colspan="2">
                <asp:Label ID="lblPeActivaion" runat="server" Text="Periodo de Activación:" 
                    CssClass="LabelNegrita"></asp:Label>
            </td>
            <td style="width:10%"></td>
            <td style="width:20%" colspan="2">
                <asp:Label ID="lblPeEntrega" runat="server" Text="Periodo de Entrega:" 
                    CssClass="LabelNegrita"></asp:Label>
            </td>
            <td style="width:10%"></td>
            <td style="width:20%" colspan="2">
                <asp:Label ID="lblPeDevolucion" runat="server" Text="Periodo de Devolución:" 
                    CssClass="LabelNegrita"></asp:Label>
            </td>
            <td style="width:10%"></td>
            <td style="width:10%"></td>
        </tr>
        <tr>
            <td style="width:10%">
                <asp:Label ID="lblDel" runat="server" Text="Del:" 
                    CssClass="Label"></asp:Label>
                &nbsp;
                <telerik:RadDatePicker ID="calDel" runat="server">
                <Calendar runat="server" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>
                <DateInput runat="server" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%" Enabled="false" ></DateInput>
                </telerik:RadDatePicker>
            </td>
            <td style="width:10%">
                <asp:Label ID="lblAl" runat="server" Text="Al:" 
                    CssClass="Label"></asp:Label>
                &nbsp;
                <telerik:RadDatePicker ID="calAl" runat="server">
                <Calendar runat="server" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>
                <DateInput runat="server" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%" Enabled="false" ></DateInput>
                </telerik:RadDatePicker>
            </td>
            <td style="width:10%"></td>
            <td style="width:10%">
                <asp:Label ID="lblDel1" runat="server" Text="Del:" 
                    CssClass="Label"></asp:Label>
                &nbsp;
                <telerik:RadDatePicker ID="calDel1" runat="server">
                <Calendar runat="server" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>
                <DateInput runat="server" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%" Enabled="false" ></DateInput>
                </telerik:RadDatePicker>
            </td>
            <td style="width:10%">
                <asp:Label ID="lblAl1" runat="server" Text="Al:" 
                    CssClass="Label"></asp:Label>
                &nbsp;
                <telerik:RadDatePicker ID="calAl1" runat="server">
                <Calendar runat="server" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>
                <DateInput runat="server" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%" Enabled="false" ></DateInput>
                </telerik:RadDatePicker>
            </td>
            <td style="width:10%"></td>
            <td style="width:10%">
                <asp:Label ID="lblDel2" runat="server" Text="Del:" 
                    CssClass="Label"></asp:Label>
                &nbsp;
                <telerik:RadDatePicker ID="calDel2" runat="server">
                <Calendar runat="server" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>
                <DateInput runat="server" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%" Enabled="false" ></DateInput>
                </telerik:RadDatePicker>
            </td>
            <td style="width:10%">
                <asp:Label ID="lblAl2" runat="server" Text="Al:" 
                    CssClass="Label"></asp:Label>
                &nbsp;
                <telerik:RadDatePicker ID="calAl2" runat="server">
                <Calendar runat="server" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>
                <DateInput runat="server" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%" Enabled="false" ></DateInput>
                </telerik:RadDatePicker>
            </td>
            <td style="width:10%"></td>
            <td style="width:10%"></td>
        </tr>
        <tr>
            <td style="width:10%"></td>
            <td style="width:10%"></td>
            <td style="width:10%"></td>
            <td style="width:10%">
                <asp:ImageButton ID="btnBuscar" runat="server" CssClass="Button" Height="22px" ImageUrl="~/img/btnbuscar.png" Width="67px" />
            </td>
            <td style="width:10%"></td>
            <td style="width:10%"></td>
            <td style="width:10%"></td>
            <td style="width:10%"></td>
            <td style="width:10%"></td>
            <td style="width:10%"></td>
        </tr>
        <tr>
            <td style="width:100%" colspan="10"> &nbsp;</td>
        </tr>
        <tr>
            <td style="width:100%" colspan="10">
                <div runat="server">
                <telerik:RadGrid ID="gridGeneral" runat="server" Width="100%" AllowSorting="false" AutoGenerateColumns="False" CellSpacing="0" CssClass="Grid" MasterTableView-NoMasterRecordsText="No se encontraron registros"
                    GridLines="Both" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="Orange" Skin="Simple">
                    <MasterTableView>
                        <Columns>
                            <telerik:GridBoundColumn DataField="IdServicio" HeaderText="Id" SortExpression="IdServicio" UniqueName="IdServicio" Display="false">
                            </telerik:GridBoundColumn>                            
                            <telerik:GridBoundColumn DataField="NumServicio" HeaderText="No.Servicio" SortExpression="NumServicio" UniqueName="NumServicio">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="FecActivacion" HeaderText="Fecha de Activación" SortExpression="FecActivacion" UniqueName="FecActivacion" DataFormatString="{0:d}">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="DiasActivacion" HeaderText="Días apartir de la Activación" SortExpression="DiasActivacion" UniqueName="DiasActivacion">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Estatus" HeaderText="Estatus" SortExpression="Estatus" UniqueName="Estatus">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="NomAsegurado" HeaderText="Asegurado/Beneficiario" SortExpression="NomAsegurado" UniqueName="NomAsegurado">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="NomCliente" HeaderText="Cliente(Aseguradora)" SortExpression="NomCliente" UniqueName="NomCliente">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="NumPoliza" HeaderText="Póliza/Contrato/Certificado" SortExpression="NumPoliza" UniqueName="NumPoliza">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Evento" HeaderText="Cobertura/Evento" SortExpression="Evento" UniqueName="Evento">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="FecAsignacion" HeaderText="Fecha de Asignación" SortExpression="FecAsignacion" UniqueName="FecAsignacion" DataFormatString="{0:d}">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="DiasenServ" HeaderText="Días en Servicio" SortExpression="DiasenServ" UniqueName="DiasenServ">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="FecDevolucion" HeaderText="Fecha de Devolución" SortExpression="FecDevolucion" UniqueName="FecDevolucion" DataFormatString="{0:d}">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Localidad" HeaderText="Localidad" SortExpression="Localidad" UniqueName="Localidad">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="SigAccion" HeaderText="Acción Siguiente" SortExpression="SigAccion" UniqueName="SigAccion">
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn HeaderText="Pre-Reserva" UniqueName="LNK_PreReserva">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkPreReserva" runat="server" Text="Ingresar"></asp:LinkButton>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Reserva" UniqueName="LNK_Reserva">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkReserva" runat="server" Text="Ingresar"></asp:LinkButton>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Contacto despúes de la Reserva" UniqueName="LNK_Contacto">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkContacto" runat="server" Text="Ingresar"></asp:LinkButton>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Asignar" UniqueName="LNK_Asignar">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkAsignar" runat="server" Text="Ingresar"></asp:LinkButton>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Seguimientos" UniqueName="LNK_Seguimiento">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkSeguimiento" runat="server" Text="Ingresar"></asp:LinkButton>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Término" UniqueName="LNK_Termino">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkTermino" runat="server" Text="Ingresar"></asp:LinkButton>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Historial" UniqueName="LNK_Historial">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkHistorial" runat="server" Text="Ver"></asp:LinkButton>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                        </Columns>
                    </MasterTableView>
                    <ClientSettings>
                        <Selecting CellSelectionMode="None" AllowRowSelect="True" />
                        <Scrolling AllowScroll="True" UseStaticHeaders="True" SaveScrollPosition="True" ></Scrolling>
                    </ClientSettings>
                </telerik:RadGrid>
                </div>
            </td>
        </tr>        
        <tr>
            <td style="width:10%"></td>
            <td style="width:10%"></td>
            <td style="width:10%"></td>
            <td style="width:10%"></td>
            <td style="width:10%"></td>
            <td style="width:10%"></td>
            <td style="width:10%"></td>
            <td style="width:10%"></td>
            <td style="width:10%"></td>
            <td style="width:10%"></td>
        </tr>
    </table>

</asp:Content>

