<%@ Page Title="" Language="VB" MasterPageFile="~/MasterServicio.master" AutoEventWireup="false" CodeFile="Primer_Seguimiento.aspx.vb" Inherits="CheckIn_Primer_Seguimiento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="phAreaTrabajo" Runat="Server">
    <%--Campos para ingresar datos--%>
    <table class="TablaCampos" >        
        <tr>
            <td style="width:100%" colspan="10">
                <asp:Label ID="lblPrimerSegui" runat="server" Text="Contacto con el Beneficiario Primer Seguimiento" 
                    CssClass="LabelNegrita"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width:10%">
                <asp:Label ID="lblNumTelefono" runat="server" Text="Número Telefonico de Contacto:" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%">
                <telerik:RadComboBox CssClass="ComboBox" ID="cmbNumTelefono" Runat="server" 
                    DataTextField="Nombre" DataValueField="Id" MarkFirstMatch="True">
                </telerik:RadComboBox>
            </td>
            <td style="width:10%"></td>
            <td style="width:10%"></td>
            <td style="width:10%"></td>
            <td style="width:10%"></td>
            <td style="width:10%"></td>
            <td style="width:10%"></td>
            <td style="width:10%"></td>
            <td style="width:10%"></td>
        </tr>
        <tr>
            <td style="width:10%">
                <asp:RadioButton ID="radEfectiva" runat="server" Text="Llamada Efectiva"/>
                </td>
            <td style="width:10%">
                <asp:RadioButton ID="radNoEfectiva" runat="server" Text="Llamada No Efectiva"/>
                </td>
            <td style="width:10%"></td>
            <td style="width:10%">
                <asp:RadioButton ID="radNoPosible" runat="server" Text="No Posible"/>
                </td>
            <td style="width:10%"></td>
            <td style="width:10%"></td>
            <td style="width:10%"></td>
            <td style="width:10%"></td>
            <td style="width:10%"></td>
            <td style="width:10%"></td>
        </tr>
        <tr>
            <td style="width:100%" colspan="10">
                <asp:Label ID="lblSpeech" runat="server" Text="Buenos(as) días/tardes/noches" 
                    CssClass="Label"></asp:Label>
                &nbsp;
                <asp:Label ID="lblBeneficiario" runat="server" Text="Karen Gonzalez" 
                    CssClass="LabelNegrita"></asp:Label>
                &nbsp;
                <asp:Label ID="lblSpeech2" runat="server" Text="soy" 
                    CssClass="Label"></asp:Label>
                &nbsp;
                <asp:Label ID="lblOperador" runat="server" Text="Israel Rojas Martinez" 
                    CssClass="LabelNegrita"></asp:Label>
                &nbsp;
                <asp:Label ID="lblSpeech3" runat="server" Text="supervisor de ASIGNACAR" 
                    CssClass="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width:20%" colspan="2">
                <asp:Label ID="lblPuedeAtender" runat="server" Text="¿Me puede atender en este momento?" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%"></td>
            <td style="width:10%">
                <asp:RadioButton ID="radAtencionSi" runat="server" Text="Si"/>
                &nbsp;
                <asp:RadioButton ID="radAtencionNo" runat="server" Text="No"/>
                </td>
            <td style="width:10%"></td>
            <td style="width:10%"></td>
            <td style="width:10%"></td>
            <td style="width:10%"></td>
            <td style="width:10%"></td>
            <td style="width:10%"></td>
        </tr>
        <tr>
            <td style="width:10%">
                <asp:Label ID="lblMotivo" runat="server" Text="Motivo:" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%">
                <telerik:RadComboBox CssClass="ComboBox" ID="cmbMotivo" Runat="server" 
                    DataTextField="Nombre" DataValueField="Id" MarkFirstMatch="True">
                </telerik:RadComboBox>
            </td>
            <td style="width:10%"></td>
            <td style="width:20%" colspan="2">
                <asp:Label ID="lblSpeech4" runat="server" Text="¿En que Horario y Fecha podría atenderme?" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%"></td>
            <td style="width:10%">
                <asp:Label ID="lblFecAtencion" runat="server" Text="Fecha:"></asp:Label>
            </td>
            <td style="width:10%">
                <telerik:RadDatePicker ID="calFecAtencion" runat="server">
                <Calendar runat="server" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>
                <DateInput runat="server" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%" Enabled="false" ></DateInput>
                </telerik:RadDatePicker>
            </td>
            <td style="width:10%"></td>
            <td style="width:10%"></td>
        </tr>
        <tr>
            <td style="width:100%" colspan="10"> &nbsp;</td>            
        </tr>
        <tr>
            <td style="width:100%" colspan="10">
                <asp:Label ID="lblSpeech5" runat="server" Text="Hoy debió recoger su AutoRelevo, ¿Por favor me puede indicar si ya cuenta con la unidad?" 
                    CssClass="Label"></asp:Label>
                &nbsp;&nbsp;
                <asp:RadioButton ID="radUnidadSi" runat="server" Text="Si"/>
                &nbsp;
                <asp:RadioButton ID="radUnidadNo" runat="server" Text="No"/>
            </td>
        </tr>
        <tr>
            <td style="width:10%">
                <asp:Label ID="lblMotivo2" runat="server" Text="Motivo:" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%">
                <telerik:RadComboBox CssClass="ComboBox" ID="cmbMotivo2" Runat="server" 
                    DataTextField="Nombre" DataValueField="Id" MarkFirstMatch="True">
                </telerik:RadComboBox>
            </td>
            <td style="width:10%"></td>
            <td style="width:20%" colspan="2">
                <asp:Label ID="lblDeseaReserva" runat="server" Text="¿Desea realizar una Reservación?" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%"></td>
            <td style="width:10%">
                <asp:RadioButton ID="radReservaSi" runat="server" Text="Si"/>
                &nbsp;
                <asp:RadioButton ID="radReservaNo" runat="server" Text="No"/>
            </td>
            <td style="width:10%"></td>
            <td style="width:10%"></td>
            <td style="width:10%"></td>
        </tr>
        <tr>
            <td style="width:100%" colspan="10" align="center"> 
                <asp:Label ID="lblSpeech6" runat="server" Text="ENCUESTA"
                    CssClass="LabelNegrita"></asp:Label>
                </td>            
        </tr>
        <tr>
            <td style="width:100%" colspan="10"> 
                <asp:Label ID="lblSpeech7" runat="server" Text="Con la finalidad de evaluar la calidad su Servicio ¿Me permite realizarle 3 preguntas?" 
                    CssClass="Label"></asp:Label>
                </td>            
        </tr>
        <tr>
            <td style="width:100%" colspan="10">
                <telerik:RadGrid ID="gridEncuenta" runat="server" Width="100%" AllowSorting="false" AutoGenerateColumns="False" CellSpacing="0" CssClass="Grid" MasterTableView-NoMasterRecordsText="No se encontraron registros"
                    GridLines="Both" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="Orange" Skin="Simple">
                    <MasterTableView>
                        <Columns>
                            <telerik:GridBoundColumn DataField="Id" HeaderText="Id" UniqueName="Id" Display="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Pregunta" HeaderText="Pregunta" UniqueName="Pregunta" >
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn HeaderText="Respuesta" UniqueName="Respuesta">
                                <ItemTemplate>
                                    <asp:RadioButtonList ID="radRespuesta" runat="server" CssClass="RadioButton" RepeatDirection="Vertical">
                                    </asp:RadioButtonList>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                    </Columns>
                    </MasterTableView>
                    <ClientSettings>
                        <Selecting CellSelectionMode="None" AllowRowSelect="True" />
                        <Scrolling AllowScroll="True" UseStaticHeaders="True" SaveScrollPosition="True" ></Scrolling>
                    </ClientSettings>
                </telerik:RadGrid>
                </td>
        </tr>
        <tr>
            <td style="width:20%" colspan="2">
                <asp:Label ID="lblporque" runat="server" Text="¿Por que otorgó esta Calificación?" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%"></td>
            <td style="width:10%">
                <telerik:RadTextBox ID="txtPorque" Runat="server" CssClass="TextBox" TextMode="MultiLine">
                </telerik:RadTextBox>
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
                <asp:Label ID="lblSpeech8" runat="server" Text="Muchas Gracias por sus repuestas las cuales nos ayudarán a mejorar nuestros servicios. Le atendio" 
                    CssClass="Label"></asp:Label>
                &nbsp;
                <asp:Label ID="lblOperador2" runat="server" Text="Israel Rojas Martinez" 
                    CssClass="LabelNegrita"></asp:Label>
                <asp:Label ID="lblSpeech9" runat="server" Text=", que tenga una excelente Día/Tarde/Noche" 
                    CssClass="Label"></asp:Label>
                </td>
        </tr>
        <tr>
            <td style="width:10%"></td>
            <td style="width:10%">
                <telerik:RadButton ID="btnGuardar" runat="server" Text="Guardar"></telerik:RadButton>
            </td>
            <td style="width:10%">
                <telerik:RadButton ID="btnCancelar" runat="server" Text="Cancelar"></telerik:RadButton>
            </td>
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

