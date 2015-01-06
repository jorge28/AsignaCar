<%@ Page Title="" Language="VB" MasterPageFile="~/MasterServicio.master" AutoEventWireup="false" CodeFile="Segundo_Seguimiento.aspx.vb" Inherits="CheckIn_Segundo_Seguimiento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="phAreaTrabajo" Runat="Server">
    <%--Campos para ingresar datos--%>
    <table class="TablaCampos" >        
        <tr>
            <td style="width:100%" colspan="10">
                <asp:Label ID="lblSegundoSegui" runat="server" Text="Contacto con el Beneficiario Segundo Seguimiento" 
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
                <asp:Label ID="lblSpeech" runat="server" Text="Buenos(as) días/tardes/noches el motivo de mi llamada es para darle seguimiento a su aginación de AutoRelevo con el Número de Servicio:" 
                    CssClass="Label"></asp:Label>
                &nbsp;
                <asp:Label ID="lblNumServicio" runat="server" Text="201567846" 
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
                <asp:Label ID="lblDetalles" runat="server" Text="Detalles del Funcionamiento de la Unidad" 
                    CssClass="LabelNegrita"></asp:Label>
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
                <asp:Label ID="lblSpeech3" runat="server" Text="¿Por favor me puede indicar si la unidad está funcionando correctamente?"
                    CssClass="Label"></asp:Label>
                <asp:RadioButton ID="radFuncionaSi" runat="server" Text="Si"/>
                &nbsp;
                <asp:RadioButton ID="radFuncionaNo" runat="server" Text="No"/>
            </td>                            
        </tr>
        <tr>
            <td style="width:100%" colspan="10" align="center"> 
                <asp:Label ID="lblSpeech4" runat="server" Text="Le agradecemos su atención, por favor cualquier situación comunicarse al 01800"
                    CssClass="Label"></asp:Label>
            </td>                            
        </tr>
        <tr>
            <td style="width:100%" colspan="10"> 
                <asp:Label ID="lblSpeech5" runat="server" Text="¿Requeriría cambio de Vehículo?" 
                    CssClass="Label"></asp:Label>
                &nbsp;
                <asp:RadioButton ID="radCambioSi" runat="server" Text="Si"/>
                &nbsp;
                <asp:RadioButton ID="radCambioNo" runat="server" Text="No"/>
            </td>            
        </tr>
        <tr>
            <td style="width:100%" colspan="10">&nbsp;</td>
        </tr>
        <tr>
            <td style="width:100%" colspan="10">
                <asp:Label ID="lblDatosAsegu" runat="server" Text="Datos del Asegurado" 
                    CssClass="LabelNegrita"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width:10%">
                <asp:Label ID="lblNumServ" runat="server" Text="No. de Servicio:" 
                    CssClass="LabelNegrita"></asp:Label>
            </td>
            <td style="width:10%">
                <asp:Label ID="lblNumServicio2" runat="server" Text="201578958" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%"></td>
            <td style="width:10%">                
                <asp:Label ID="lblAsegu" runat="server" Text="Asegurado:" 
                    CssClass="LabelNegrita"></asp:Label>
            </td>
            <td style="width:40%" colspan="4">                
                <asp:Label ID="lblAsegurado" runat="server" Text="Lorena Gonzalez Montoya" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%"></td>
            <td style="width:10%"></td>
        </tr>
        <tr>
            <td style="width:10%">
                <asp:Label ID="lblFecEntre" runat="server" Text="Fecha/Hora de Salida:" 
                    CssClass="LabelNegrita"></asp:Label>
            
            </td>
            <td style="width:10%">
                <asp:Label ID="lblFecEntrega" runat="server" Text="01/05/2015 12:00" 
                    CssClass="Label"></asp:Label>
            
            </td>
            <td style="width:10%"></td>
            <td style="width:10%">
                <asp:Label ID="lblFecDevo" runat="server" Text="Fecha/Hora de Devolución:" 
                    CssClass="LabelNegrita"></asp:Label>
            </td>
            <td style="width:10%">
                <asp:Label ID="lblFecDevolucion" runat="server" Text="15/01/2015 12:00" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%"></td>
            <td style="width:10%">
                <asp:Label ID="lblEven" runat="server" Text="Evento:" 
                    CssClass="LabelNegrita"></asp:Label>
            </td>
            <td style="width:20%" colspan="2">
                <asp:Label ID="lblEvento" runat="server" Text="Colisión Parcial L.U.C 15" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%"></td>
        </tr>
        <tr>
            <td style="width:10%">
                <asp:Label ID="lblNumContra" runat="server" Text="No. de Contrato:" 
                    CssClass="LabelNegrita"></asp:Label>
            </td>
            <td style="width:10%">
                <asp:Label ID="lblNumContrato" runat="server" Text="647DYH" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%"></td>
            <td style="width:10%">
                <asp:Label ID="lblClie" runat="server" Text="Cliente:" 
                    CssClass="LabelNegrita"></asp:Label>
            </td>
            <td style="width:20%" colspan="2">
                <asp:Label ID="lblCliete" runat="server" Text="HERTZ AVASA" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%">
                <asp:Label ID="lblRazonCambio" runat="server" Text="Razón de Cambio:" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%">
                <telerik:RadComboBox CssClass="ComboBox" ID="cmbRazonCambio" Runat="server" 
                    DataTextField="Nombre" DataValueField="Id" MarkFirstMatch="True">
                </telerik:RadComboBox>
            </td>
            <td style="width:10%"></td>
            <td style="width:10%"></td>
        </tr>
        <tr>
            <td style="width:10%">
                <asp:Label ID="lblLoca" runat="server" Text="Localidad:" 
                    CssClass="LabelNegrita"></asp:Label>
            </td>
            <td style="width:40%" colspan="4">
                <asp:Label ID="lblLocalidad" runat="server" Text="COLONIA DEL VALLE, DELEGACIÓN BENITO JUARES, DISTRITO FEDERAL" 
                    CssClass="Label"></asp:Label>
            </td>            
            <td style="width:10%"></td>
            <td style="width:10%"></td>
            <td style="width:10%"></td>
            <td style="width:10%"></td>
            <td style="width:10%"></td>
        </tr>
        <tr>
            <td style="width:100%" colspan="10">&nbsp;</td>
        </tr>
        <tr>
            <td style="width:100%" colspan="10">
                <asp:Label ID="lblDatosVeh" runat="server" Text="Datos del Vehículo Actual" 
                    CssClass="LabelNegrita"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width:10%">
                <asp:Label ID="lblNumServ0" runat="server" Text="No. de Servicio:" 
                    CssClass="LabelNegrita"></asp:Label>
            </td>
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

