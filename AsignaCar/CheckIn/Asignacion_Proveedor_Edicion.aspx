<%@ Page Title="" Language="VB" MasterPageFile="~/MasterServicio.master" AutoEventWireup="false" CodeFile="Asignacion_Proveedor_Edicion.aspx.vb" Inherits="CheckIn_Asignacion_Proveedor_Edicion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">    
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="phAreaTrabajo" Runat="Server">
    <%--Campos para ingresar datos--%>
    <table class="TablaCampos" >
        <tr>
            <td style="width:100%" colspan="10">
                <asp:Label ID="lblDatosProve" runat="server" Text="Datos del Proveedor" CssClass="LabelNegrita"></asp:Label>
            </td>
        </tr>       
        <tr>
            <td style="width:10%">
                <asp:Label ID="lblNomCome" runat="server" Text="Nombre Comercial:" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%">
                <asp:Label ID="lblNomComercial" runat="server" Text="Hertz Avaza" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%"></td>
            <td style="width:10%">
                <asp:Label ID="lblRazonSoc" runat="server" Text="Razon Social:" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%">
                <asp:Label ID="lblRazonSocial" runat="server" Text="Alquiladora de Vehículos Automotriz" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%"></td>
            <td style="width:10%">
                <asp:Label ID="lblrfc0" runat="server" Text="RFC:" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%">
                <asp:Label ID="lblrfc" runat="server" Text="AVA89746UDHU" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%"></td>
            <td style="width:10%"></td>
        </tr>       
        <tr>
            <td style="width:10%">
                <asp:Label ID="lblTel" runat="server" Text="Teléfono:" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%">
                <asp:Label ID="lblTelefono" runat="server" Text="010457712191262" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%"></td>
            <td style="width:10%">
                <asp:Label ID="lblNumReserva" runat="server" Text="Número de Reservación:" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%">
                <asp:Label ID="lblNumReservacion" runat="server" Text="2736DHDUDJ"
                    CssClass="Label"></asp:Label>
            </td>
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
                <asp:Label ID="lblContacto" runat="server" CssClass="LabelNegrita" text="Contacto con el Proveedor">
                </asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width:20%" colspan="2">
                <asp:RadioButton ID="radEfectiva" runat="server" Text="Llamada Efectiva" />
            </td>
            <td style="width:10%"></td>
            <td style="width:30%" colspan="3">
                <asp:RadioButton ID="radNoEfectiva" runat="server" Text="Llamada No Efectiva" />
            </td>
            <td style="width:10%"></td>
            <td style="width:10%"></td>
            <td style="width:10%"></td>
            <td style="width:10%"></td>
        </tr>
        <tr>
            <td style="width:100%" colspan="10"> 
                <asp:Label ID="lblSpeech" runat="server" Text="Buenos (as) días/tardes/noches el motivo de mi llamada es para solicitar los datos de la reserva para el Número de Servicio:" CssClass="LabelNegrita"></asp:Label>
                &nbsp;
                <asp:Label ID="lblNumServicio" runat="server" Text="20150001" CssClass="Label"></asp:Label>
            </td>
        </tr>  
        <tr>
            <td style="width:20%" colspan="2">
                <asp:Label ID="lblSpeech2" runat="server" Text="¿Me puede atender en este momento?" CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%"></td>
            <td style="width:10%">
                <asp:RadioButton ID="radSi" runat="server" Text="Si" />
                &nbsp;
                <asp:RadioButton ID="radNo" runat="server" Text="No" />
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
                <asp:Label ID="lblMotivo" runat="server" Text="Motivo:"></asp:Label>
            </td>
            <td style="width:10%">
                <telerik:RadComboBox ID="cmbMotivo" runat="server" DataTextField="Nombre" DataValueField="Id" MarkFirstMatch="true" CssClass="ComboBox"></telerik:RadComboBox>
            </td>
            <td style="width:10%"></td>
            <td style="width:20%" colspan="2">
                <asp:Label ID="lblSpeech3" runat="server" Text="¿En que Horario y Fecha podría atenderme?" CssClass="Label"></asp:Label>
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
            <td style="width:20%" colspan="2">
                <asp:Label ID="lblSpeech4" runat="server" Text="¿El beneficiario se presentó a la Cita?" CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%"></td>
            <td style="width:10%">
                <asp:RadioButton ID="radSiPresento" runat="server" Text="Si" />
                &nbsp;
                <asp:RadioButton ID="radNoPresento" runat="server" Text="No" />
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
                <asp:Label ID="lblDatos" runat="server" CssClass="LabelNegrita" Text="Datos de la Reservación"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width:10%">
                <asp:Label ID="lblFecEntrega" runat="server" Text="Fecha de Entrega:" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%">
                <telerik:RadDateTimePicker ID="calFecEntrega" runat="server" Culture="es-MX">
                    <DateInput ID="dtFecEntrega" runat="server" Enabled="false"></DateInput>
                </telerik:RadDateTimePicker>
            </td>            
            <td style="width:10%"></td>
            <td style="width:10%">
                <asp:Label ID="lblFecDevolucion" runat="server" Text="Fecha de Devolución:" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%">
                <telerik:RadDateTimePicker ID="calFecDevolucion" runat="server" Culture="es-MX">
                    <DateInput ID="dtFecDevolucion" runat="server" Enabled="false"></DateInput>
                </telerik:RadDateTimePicker>
            </td>
            <td style="width:10%"></td>
            <td style="width:10%">
                <asp:Label ID="lblDiasServ" runat="server" Text="Días de Servicio:" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%">
                <telerik:RadNumericTextBox ID="txtDiasServ" Runat="server" CssClass="TextBox" Enabled="false" 
                    Culture="es-MX" DbValueFactor="1" Width="50px">
                </telerik:RadNumericTextBox>            
            </td>
            <td style="width:10%"></td>
            <td style="width:10%"></td>
        </tr>
        <tr>
            <td style="width:100%" colspan="10"> &nbsp;</td>
        </tr> 
        <tr>
            <td style="width:100%" colspan="10">
                <asp:Label ID="lblDatosVeh" runat="server" CssClass="LabelNegrita" Text="Datos del Vehículo"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width:10%">
                <asp:Label ID="lblPla" runat="server" Text="Placas:" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%">
                <telerik:RadTextBox ID="txtPlacas" Runat="server" CssClass="TextBox">
                </telerik:RadTextBox>
            </td>
            <td style="width:10%"></td>
            <td style="width:10%">
                <asp:Label ID="lblMar" runat="server" Text="Marca:" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%">
                <telerik:RadComboBox ID="cmbMarca" runat="server" DataTextField="Nombre" DataValueField="Id" MarkFirstMatch="true" CssClass="ComboBox"></telerik:RadComboBox>
            </td>
            <td style="width:10%"></td>
            <td style="width:10%">
                <asp:Label ID="lblNivelGas" runat="server" Text="Nivel de Gasolina:" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%">
                <telerik:RadComboBox ID="cmbNivelGalosina" runat="server" DataTextField="Nombre" DataValueField="Id" MarkFirstMatch="true" CssClass="ComboBox"></telerik:RadComboBox>
            </td>
            <td style="width:10%"></td>
            <td style="width:10%"></td>
        </tr>
        <tr>
            <td style="width:10%">
                <asp:Label ID="lblColor" runat="server" Text="Color:" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%">
                <telerik:RadTextBox ID="txtColor" Runat="server" CssClass="TextBox">
                </telerik:RadTextBox>
            </td>
            <td style="width:10%"></td>
            <td style="width:10%">
                <asp:Label ID="lblSubamrca" runat="server" Text="Submarca:" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%">
                <telerik:RadComboBox ID="cmbSubmarca" runat="server" DataTextField="Nombre" DataValueField="Id" MarkFirstMatch="true" CssClass="ComboBox"></telerik:RadComboBox>
            </td>
            <td style="width:10%"></td>
            <td style="width:10%">
                <asp:Label ID="lblKilom" runat="server" Text="Kilometraje:" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%">
                <telerik:RadTextBox ID="txtKilometraje" Runat="server" CssClass="TextBox">
                </telerik:RadTextBox>
            </td>
            <td style="width:10%"></td>
            <td style="width:10%"></td>
        </tr>
        <tr>
            <td style="width:100%" colspan="10"></td>
        </tr>
        <tr>
            <td style="width:100%" colspan="10"> 
                <asp:Label ID="lblDatosAsigna" runat="server" CssClass="LabelNegrita" Text="Datos de la Asignación"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width:10%">
                <asp:Label ID="lblNumContrato" runat="server" Text="Número de Contrato:" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%">
                <telerik:RadTextBox ID="txtNumContrato" Runat="server" CssClass="TextBox">
                </telerik:RadTextBox>
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
            <td style="width:20%" colspan="2">
                <asp:CheckBox ID="chkBeneNoPresenta" runat="server" Text="El Beneficiario no se presentó" CssClass="CheckBox"/>
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
            <td style="width:100%" colspan="10"></td>
        </tr>
        <tr>
            <td style="width:10%"></td>
            <td style="width:10%">
                <telerik:RadButton ID="btnGuardar" runat="server" Text="Guardar"></telerik:RadButton>
            </td>
            <td style="width:10%">
                &nbsp;</td>
            <td style="width:10%">
                <telerik:RadButton ID="btnCancelar" runat="server" Text="Cancelar"></telerik:RadButton>
            </td>
            <td style="width:10%"></td>
            <td style="width:10%"></td>
            <td style="width:10%"></td>
            <td style="width:10%"></td>
            <td style="width:10%"></td>
            <td style="width:10%"></td>
        </tr>
    </table>

</asp:Content>

