<%@ Page Title="" Language="VB" MasterPageFile="~/MasterServicio.master" AutoEventWireup="false" CodeFile="Asignacion_Propio_Edicion.aspx.vb" Inherits="CheckIn_Asignacion_Propio_Edicion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">    
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="phAreaTrabajo" Runat="Server">
    <%--Campos para ingresar datos--%>
    <table class="TablaCampos" >
        <tr>
            <td style="width:20%" colspan="2">
                <asp:Label ID="lblSePresento" runat="server" Text="¿El Beneficiario se presento a la Cita?" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%"></td>
            <td style="width:10%">
                <asp:RadioButton ID="radPresentaSi" runat="server" Text="Si"/>
                <asp:RadioButton ID="radPresentaNo" runat="server" Text="No" />
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
            <td style="width:100%" colspan="10" >
                <asp:Label ID="lblDatosReser" runat="server" Text="Datos de la Reserva:" 
                    CssClass="LabelNegrita"></asp:Label>
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
            <td style="width:100%" colspan="10"> &nbsp; 
                <asp:Label ID="lblDatosGaran" runat="server" Text="Datos de la Garantía:" 
                    CssClass="LabelNegrita"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width:10%">
                <asp:Label ID="lblGarantia" runat="server" Text="Garantía:" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%">
                <telerik:RadNumericTextBox ID="txtGarantia" runat="server" Culture="es-MX" DbValueFactor="1" LabelWidth="64px" Type="Currency" Width="160px" MaxLength="10" CssClass="TextBox">
<NegativeStyle Resize="None"></NegativeStyle>

<NumberFormat ZeroPattern="$n"></NumberFormat>

<EmptyMessageStyle Resize="None"></EmptyMessageStyle>

<ReadOnlyStyle Resize="None"></ReadOnlyStyle>

<FocusedStyle Resize="None"></FocusedStyle>

<DisabledStyle Resize="None"></DisabledStyle>

<InvalidStyle Resize="None"></InvalidStyle>

<HoveredStyle Resize="None"></HoveredStyle>

<EnabledStyle Resize="None"></EnabledStyle>
                </telerik:RadNumericTextBox>
            </td>
            <td style="width:10%"></td>
            <td style="width:10%">
                <asp:Label ID="lblDireccion" runat="server" Text="Tipo de Pago:" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%">
                <telerik:RadComboBox CssClass="ComboBox" ID="cmbTipoPago" Runat="server" 
                    DataTextField="Nombre" DataValueField="Id" MarkFirstMatch="True">
                </telerik:RadComboBox>
            </td>
            <td style="width:10%"></td>
            <td style="width:10%"></td>
            <td style="width:10%"></td>
            <td style="width:10%"></td>
            <td style="width:10%"></td>
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
        <tr>
            <td style="width:100%" colspan="10"> &nbsp; </td>
        </tr>
        <tr>
            <td style="width:100%" colspan="10"> &nbsp; 
                <asp:Label ID="lblDatosCosto" runat="server" Text="Días Fuera de Cobertura (Con Costo):" 
                    CssClass="LabelNegrita"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width:10%"></td>
            <td style="width:10%">
                <asp:Label ID="lblConIva" runat="server" Text="Con Iva:"
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%"></td>
            <td style="width:10%">
                <asp:Label ID="lblSinIva" runat="server" Text="Sin Iva:"
                    CssClass="Label"></asp:Label>
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
                <asp:Label ID="lblMontoDia" runat="server" Text="Monto por Día:"
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%">
                <telerik:RadNumericTextBox ID="txtMontoDiaConIva" runat="server" Culture="es-MX" DbValueFactor="1" LabelWidth="64px" Type="Currency" Width="160px" MaxLength="10" CssClass="TextBox">
<NegativeStyle Resize="None"></NegativeStyle>

<NumberFormat ZeroPattern="$n"></NumberFormat>

<EmptyMessageStyle Resize="None"></EmptyMessageStyle>

<ReadOnlyStyle Resize="None"></ReadOnlyStyle>

<FocusedStyle Resize="None"></FocusedStyle>

<DisabledStyle Resize="None"></DisabledStyle>

<InvalidStyle Resize="None"></InvalidStyle>

<HoveredStyle Resize="None"></HoveredStyle>

<EnabledStyle Resize="None"></EnabledStyle>
                </telerik:RadNumericTextBox>
            </td>
            <td style="width:10%"></td>
            <td style="width:10%">
                <telerik:RadNumericTextBox ID="txtMontoDiaSinIva" runat="server" Culture="es-MX" DbValueFactor="1" LabelWidth="64px" Type="Currency" Width="160px" MaxLength="10" CssClass="TextBox">
<NegativeStyle Resize="None"></NegativeStyle>

<NumberFormat ZeroPattern="$n"></NumberFormat>

<EmptyMessageStyle Resize="None"></EmptyMessageStyle>

<ReadOnlyStyle Resize="None"></ReadOnlyStyle>

<FocusedStyle Resize="None"></FocusedStyle>

<DisabledStyle Resize="None"></DisabledStyle>

<InvalidStyle Resize="None"></InvalidStyle>

<HoveredStyle Resize="None"></HoveredStyle>

<EnabledStyle Resize="None"></EnabledStyle>
                </telerik:RadNumericTextBox>
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
                <asp:Label ID="lblMontoTotal" runat="server" Text="Monto Total:" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%">
                <telerik:RadNumericTextBox ID="txtMontoTotalConIva" runat="server" Culture="es-MX" DbValueFactor="1" LabelWidth="64px" Type="Currency" Width="160px" MaxLength="10" CssClass="TextBox">
<NegativeStyle Resize="None"></NegativeStyle>

<NumberFormat ZeroPattern="$n"></NumberFormat>

<EmptyMessageStyle Resize="None"></EmptyMessageStyle>

<ReadOnlyStyle Resize="None"></ReadOnlyStyle>

<FocusedStyle Resize="None"></FocusedStyle>

<DisabledStyle Resize="None"></DisabledStyle>

<InvalidStyle Resize="None"></InvalidStyle>

<HoveredStyle Resize="None"></HoveredStyle>

<EnabledStyle Resize="None"></EnabledStyle>
                </telerik:RadNumericTextBox>
            </td>
            <td style="width:10%"></td>
            <td style="width:10%">
                <telerik:RadNumericTextBox ID="txtMontoTotalSinIva" runat="server" Culture="es-MX" DbValueFactor="1" LabelWidth="64px" Type="Currency" Width="160px" MaxLength="10" CssClass="TextBox">
<NegativeStyle Resize="None"></NegativeStyle>

<NumberFormat ZeroPattern="$n"></NumberFormat>

<EmptyMessageStyle Resize="None"></EmptyMessageStyle>

<ReadOnlyStyle Resize="None"></ReadOnlyStyle>

<FocusedStyle Resize="None"></FocusedStyle>

<DisabledStyle Resize="None"></DisabledStyle>

<InvalidStyle Resize="None"></InvalidStyle>

<HoveredStyle Resize="None"></HoveredStyle>

<EnabledStyle Resize="None"></EnabledStyle>
                </telerik:RadNumericTextBox>
            </td>
            <td style="width:10%">
                &nbsp;</td>
            <td style="width:10%"></td>
            <td style="width:10%">
                &nbsp;</td>
            <td style="width:10%">
                &nbsp;</td>
            <td style="width:10%"></td>
            <td style="width:10%"></td>
        </tr>
        <tr>
            <td style="width:10%">
                <asp:Label ID="lblTipoPago" runat="server" Text="Tipo de Pago:" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%">
                <telerik:RadComboBox CssClass="ComboBox" ID="cmbTipoPago2" Runat="server"
                    DataTextField="Nombre" DataValueField="Id" MarkFirstMatch="True">
                </telerik:RadComboBox>
            </td>
            <td style="width:10%"></td>
            <td style="width:10%">
                &nbsp;</td>
            <td style="width:10%">
                &nbsp;</td>
            <td style="width:10%"></td>
            <td style="width:10%">
                &nbsp;</td>
            <td style="width:10%">
                &nbsp;</td>
            <td style="width:10%"></td>
            <td style="width:10%"></td>
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
        <tr>
            <td style="width:100%" colspan="10"> &nbsp;</td>
        </tr>
        <tr>
            <td style="width:100%" colspan="10"> 
                <asp:Label ID="lblCostosAdi" runat="server" Text="Costos de Servicios Adicionales:" 
                    CssClass="LabelNegrita"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width:10%"></td>
            <td style="width:10%">
                <asp:Label ID="lblConIva2" runat="server" Text="Con Iva:"
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%"></td>
            <td style="width:10%">
                <asp:Label ID="lblSinIva2" runat="server" Text="Sin Iva:"
                    CssClass="Label"></asp:Label>
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
                <asp:Label ID="lblCostoDrop" runat="server" Text="Costo Drop Off:"
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%">
                <telerik:RadNumericTextBox ID="txtCostoDropConIva" runat="server" Culture="es-MX" DbValueFactor="1" LabelWidth="64px" Type="Currency" Width="160px" MaxLength="10" CssClass="TextBox">
<NegativeStyle Resize="None"></NegativeStyle>

<NumberFormat ZeroPattern="$n"></NumberFormat>

<EmptyMessageStyle Resize="None"></EmptyMessageStyle>

<ReadOnlyStyle Resize="None"></ReadOnlyStyle>

<FocusedStyle Resize="None"></FocusedStyle>

<DisabledStyle Resize="None"></DisabledStyle>

<InvalidStyle Resize="None"></InvalidStyle>

<HoveredStyle Resize="None"></HoveredStyle>

<EnabledStyle Resize="None"></EnabledStyle>
                </telerik:RadNumericTextBox>
            </td>
            <td style="width:10%"></td>
            <td style="width:10%">
                <telerik:RadNumericTextBox ID="txtCostoDropSinIva" runat="server" Culture="es-MX" DbValueFactor="1" LabelWidth="64px" Type="Currency" Width="160px" MaxLength="10" CssClass="TextBox">
<NegativeStyle Resize="None"></NegativeStyle>

<NumberFormat ZeroPattern="$n"></NumberFormat>

<EmptyMessageStyle Resize="None"></EmptyMessageStyle>

<ReadOnlyStyle Resize="None"></ReadOnlyStyle>

<FocusedStyle Resize="None"></FocusedStyle>

<DisabledStyle Resize="None"></DisabledStyle>

<InvalidStyle Resize="None"></InvalidStyle>

<HoveredStyle Resize="None"></HoveredStyle>

<EnabledStyle Resize="None"></EnabledStyle>
                </telerik:RadNumericTextBox>
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
                <asp:Label ID="lblConductorAdicional" runat="server" Text="Conductor Adicional:"
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%">
                <telerik:RadNumericTextBox ID="txtConductorAdiConIva" runat="server" Culture="es-MX" DbValueFactor="1" LabelWidth="64px" Type="Currency" Width="160px" MaxLength="10" CssClass="TextBox">
<NegativeStyle Resize="None"></NegativeStyle>

<NumberFormat ZeroPattern="$n"></NumberFormat>

<EmptyMessageStyle Resize="None"></EmptyMessageStyle>

<ReadOnlyStyle Resize="None"></ReadOnlyStyle>

<FocusedStyle Resize="None"></FocusedStyle>

<DisabledStyle Resize="None"></DisabledStyle>

<InvalidStyle Resize="None"></InvalidStyle>

<HoveredStyle Resize="None"></HoveredStyle>

<EnabledStyle Resize="None"></EnabledStyle>
                </telerik:RadNumericTextBox>
            </td>
            <td style="width:10%"></td>
            <td style="width:10%">
                <telerik:RadNumericTextBox ID="txtConductorAdiSinIva" runat="server" Culture="es-MX" DbValueFactor="1" LabelWidth="64px" Type="Currency" Width="160px" MaxLength="10" CssClass="TextBox">
<NegativeStyle Resize="None"></NegativeStyle>

<NumberFormat ZeroPattern="$n"></NumberFormat>

<EmptyMessageStyle Resize="None"></EmptyMessageStyle>

<ReadOnlyStyle Resize="None"></ReadOnlyStyle>

<FocusedStyle Resize="None"></FocusedStyle>

<DisabledStyle Resize="None"></DisabledStyle>

<InvalidStyle Resize="None"></InvalidStyle>

<HoveredStyle Resize="None"></HoveredStyle>

<EnabledStyle Resize="None"></EnabledStyle>
                </telerik:RadNumericTextBox>
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
                <asp:Label ID="lblConductorMenor" runat="server" Text="Conductor Menor:"
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%">
                <telerik:RadNumericTextBox ID="txtConductorMenConIva" runat="server" Culture="es-MX" DbValueFactor="1" LabelWidth="64px" Type="Currency" Width="160px" MaxLength="10" CssClass="TextBox">
<NegativeStyle Resize="None"></NegativeStyle>

<NumberFormat ZeroPattern="$n"></NumberFormat>

<EmptyMessageStyle Resize="None"></EmptyMessageStyle>

<ReadOnlyStyle Resize="None"></ReadOnlyStyle>

<FocusedStyle Resize="None"></FocusedStyle>

<DisabledStyle Resize="None"></DisabledStyle>

<InvalidStyle Resize="None"></InvalidStyle>

<HoveredStyle Resize="None"></HoveredStyle>

<EnabledStyle Resize="None"></EnabledStyle>
                </telerik:RadNumericTextBox>
            </td>
            <td style="width:10%"></td>
            <td style="width:10%">
                <telerik:RadNumericTextBox ID="txtConductorMenSinIva" runat="server" Culture="es-MX" DbValueFactor="1" LabelWidth="64px" Type="Currency" Width="160px" MaxLength="10" CssClass="TextBox">
<NegativeStyle Resize="None"></NegativeStyle>

<NumberFormat ZeroPattern="$n"></NumberFormat>

<EmptyMessageStyle Resize="None"></EmptyMessageStyle>

<ReadOnlyStyle Resize="None"></ReadOnlyStyle>

<FocusedStyle Resize="None"></FocusedStyle>

<DisabledStyle Resize="None"></DisabledStyle>

<InvalidStyle Resize="None"></InvalidStyle>

<HoveredStyle Resize="None"></HoveredStyle>

<EnabledStyle Resize="None"></EnabledStyle>
                </telerik:RadNumericTextBox>
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
                <asp:Label ID="lblCostoTotal" runat="server" Text="Costo Total:" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%">
                <telerik:RadNumericTextBox ID="txtCostoTotal" runat="server" Culture="es-MX" DbValueFactor="1" LabelWidth="64px" Type="Currency" Width="160px" MaxLength="10" CssClass="TextBox">
<NegativeStyle Resize="None"></NegativeStyle>

<NumberFormat ZeroPattern="$n"></NumberFormat>

<EmptyMessageStyle Resize="None"></EmptyMessageStyle>

<ReadOnlyStyle Resize="None"></ReadOnlyStyle>

<FocusedStyle Resize="None"></FocusedStyle>

<DisabledStyle Resize="None"></DisabledStyle>

<InvalidStyle Resize="None"></InvalidStyle>

<HoveredStyle Resize="None"></HoveredStyle>

<EnabledStyle Resize="None"></EnabledStyle>
                </telerik:RadNumericTextBox>
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
            <td style="width:100%" colspan="10"> &nbsp;</td>
        </tr>
        <tr>
            <td style="width:100%" colspan="10"> 
                <asp:Label ID="lblCostoTotal2" runat="server" Text="Costo Total del Servicio:" 
                    CssClass="LabelNegrita"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width:10%">
                <asp:Label ID="lblMontoTotal2" runat="server" Text="MONTO TOTAL:" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%">
                <telerik:RadNumericTextBox ID="txtMontoTotal" runat="server" Culture="es-MX" DbValueFactor="1" LabelWidth="64px" Type="Currency" Width="160px" MaxLength="10" CssClass="TextBox">
<NegativeStyle Resize="None"></NegativeStyle>

<NumberFormat ZeroPattern="$n"></NumberFormat>

<EmptyMessageStyle Resize="None"></EmptyMessageStyle>

<ReadOnlyStyle Resize="None"></ReadOnlyStyle>

<FocusedStyle Resize="None"></FocusedStyle>

<DisabledStyle Resize="None"></DisabledStyle>

<InvalidStyle Resize="None"></InvalidStyle>

<HoveredStyle Resize="None"></HoveredStyle>

<EnabledStyle Resize="None"></EnabledStyle>
                </telerik:RadNumericTextBox>
            </td>
            <td style="width:10%"></td>
            <td style="width:10%">
                <asp:Label ID="lblNumComprobante" runat="server" Text="Número de Comprobante:" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%">
                <telerik:RadNumericTextBox ID="txtNumComprobante" runat="server" Culture="es-MX" DbValueFactor="1" LabelWidth="64px" Width="160px" MaxLength="10" CssClass="TextBox">
                </telerik:RadNumericTextBox>
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
                <asp:Label ID="lblDatosVeh" runat="server" Text="Datos del Vehículo:" 
                    CssClass="LabelNegrita"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width:10%">
                <asp:Label ID="lblCategoriaVeh" runat="server" Text="Categoría del Vehículo:" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%">
                <telerik:RadComboBox CssClass="ComboBox" ID="cmbCategoriaVeh" Runat="server"
                    DataTextField="Nombre" DataValueField="Id" MarkFirstMatch="True">
                </telerik:RadComboBox>
            </td>
            <td style="width:10%"></td>
            <td style="width:10%">
                <telerik:RadButton ID="btnSeleccionar" runat="server" Text="Seleccionar Vehículo"></telerik:RadButton>
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
                <asp:Label ID="lblMVA" runat="server" Text="MVA:" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%">
                <asp:Label ID="lblMVA2" runat="server" Text="0001" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%"></td>
            <td style="width:10%">
                <asp:Label ID="lblMar" runat="server" Text="Marca:" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%">
                <asp:Label ID="lblMarca" runat="server" Text="Ford" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%"></td>
            <td style="width:10%">
                <asp:Label ID="lblPla" runat="server" Text="Placas:" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%">
                <asp:Label ID="lblPlacas" runat="server" Text="XTHY674" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%"></td>
            <td style="width:10%"></td>
        </tr>
        <tr>
            <td style="width:10%">
                <asp:Label ID="lblKilom" runat="server" Text="Kilometraje:" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%">
                <asp:Label ID="lblKilometraje" runat="server" Text="10000" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%"></td>
            <td style="width:10%">
                <asp:Label ID="lblNivelGas" runat="server" Text="Nivel de Gasolina:" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%">
                <asp:Label ID="lblNivelGasolina" runat="server" Text="2/4" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%"></td>
            <td style="width:10%">
                <asp:Label ID="lblOficiVeh" runat="server" Text="Oficina:" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:30%" colspan="3">
                <asp:Label ID="lblOficiVehiculo" runat="server" Text="Almacen: CDR VALLARTA, CoordinacióN: MMETRO, Región: METRO" Width="100%"
                    CssClass="Label"></asp:Label>
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
        <tr>
            <td style="width:100%" colspan="10"> &nbsp;</td>
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

