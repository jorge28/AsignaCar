<%@ Page Title="" Language="VB" MasterPageFile="~/MasterServicio.master" AutoEventWireup="false" CodeFile="Tercer_Seguimiento.aspx.vb" Inherits="CheckIn_Tercer_Seguimiento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="phAreaTrabajo" Runat="Server">
    <%--Campos para ingresar datos--%>
    <table class="TablaCampos" >        
        <tr>
            <td style="width:100%" colspan="10">
                <asp:Label ID="lblTercerSegui" runat="server" Text="Contacto con el Beneficiario Tercer Seguimiento" 
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
                <asp:Label ID="lblSpeech" runat="server" Text="Buenos(as) días/tardes/noches el motivo de mi llamada es para darle seguimiento a su asignación de AutoRelevo con su Número de Servicio:" 
                    CssClass="Label"></asp:Label>
                &nbsp;
                <asp:Label ID="lblNumServicio" runat="server" Text="201536674" 
                    CssClass="LabelNegrita"></asp:Label>
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
                <asp:Label ID="lblSpeech2" runat="server" Text="¿En que Horario y Fecha podría atenderme?" 
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
                <asp:Label ID="lblDetallesSegui" runat="server" Text="Detalles del Seguimiento" 
                    CssClass="LabelNegrita"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width:100%" colspan="10">
                <asp:Label ID="lblSpeech3" runat="server" Text="Le recuerdo que dentro de 48 Hrs. Ud deberá de entregar el AutoSustituto, le informo que en caso de que lo requiera le ofrecemos una extensión de los días que le corresponden. Si cuenta con días disponibles su servicio será sin costo, sino será con costo teniendo en cuenta los dias de su cobertura." 
                    CssClass="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width:100%" colspan="10">
                <asp:Label ID="lblSpeech4" runat="server" Text="¿Desea una extensión del Servicio?" 
                    CssClass="Label"></asp:Label>
                &nbsp;
                <asp:RadioButton ID="radExtensionSi" runat="server" Text="Si"/>
                &nbsp;
                <asp:RadioButton ID="radExtensioNo" runat="server" Text="No"/>
                &nbsp;
                <asp:RadioButton ID="radExtensionProblema" runat="server" Text="Problemas para entrega del Vehículo"/>
            </td>
        </tr>                
        <tr>
            <td style="width:100%" colspan="10">
                <asp:Label ID="lblSpeech5" runat="server" Text="Le agradecemos su atención, cualquier situación comuníquese al 01800" 
                    CssClass="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width:100%" colspan="10">
                <asp:Label ID="lblSpeech6" runat="server" Text="Sr (a) le informamos que si no entrega el vehículo a tiempo se procederá a cobrar los días que no esten contemplados dentro del Servicio." 
                    CssClass="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width:20%" colspan="2">
                <asp:Label ID="lblMotivo2" runat="server" Text="Motivo por el cual no se entregará el vehículo en tiempo:" 
                    CssClass="Label"></asp:Label>
            </td>            
            <td style="width:10%"></td>
            <td style="width:10%">
                <telerik:RadComboBox CssClass="ComboBox" ID="cmbMotivo0" Runat="server" 
                    DataTextField="Nombre" DataValueField="Id" MarkFirstMatch="True">
                </telerik:RadComboBox>
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
                <asp:Label ID="lblObservaciones" runat="server" Text="Observaciones:" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:30%" colspan="3">
                <telerik:RadTextBox ID="txtObservaciones" Runat="server" CssClass="TextBox" TextMode="MultiLine" Width="100%">
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

