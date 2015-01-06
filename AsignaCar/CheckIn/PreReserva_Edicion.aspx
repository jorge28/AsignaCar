<%@ Page Title="" Language="VB" MasterPageFile="~/MasterServicio.master" AutoEventWireup="false" CodeFile="PreReserva_Edicion.aspx.vb" Inherits="CheckIn_PreReserva_Edicion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="phAreaTrabajo" Runat="Server">
    <%--Campos para ingresar datos--%>
    <table class="TablaCampos" >
        <tr>
            <td style="width:100%" colspan="10" >
                <asp:Label ID="lblVerificacion" runat="server" Text="Verificación de Datos de Póliza:" 
                    CssClass="LabelNegrita"></asp:Label>
            </td>            
        </tr>
        <tr>
            <td style="width:20%" colspan="2">
                <asp:Label ID="lblVigencia" runat="server" Text="Fecha de Vigencia de la Póliza:" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%"></td>
            <td style="width:10%">
                <asp:Label ID="lblVigenciaDe" runat="server" Text="De:" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%">
                <telerik:RadDatePicker ID="calVigenciaDe" runat="server">
                <Calendar runat="server" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>
                <DateInput runat="server" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%" Enabled="false" ></DateInput>
                </telerik:RadDatePicker>
            </td>
            <td style="width:10%"></td>
            <td style="width:10%">
                <asp:Label ID="lblVigenciaHasta" runat="server" Text="Hasta:" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%">
                <telerik:RadDatePicker ID="calVigenciaHasta" runat="server">
                <Calendar runat="server" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>
                <DateInput runat="server" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%" Enabled="false" ></DateInput>
                </telerik:RadDatePicker>
            </td>
            <td style="width:10%"></td>
            <td style="width:10%"></td>
        </tr>
        <tr>
            <td style="width:10%">
                <asp:Label ID="lblDiasUsados" runat="server" Text="Días Usados:" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%">
                <telerik:RadNumericTextBox ID="txtDiasUsados" Runat="server" CssClass="TextBox" 
                    Culture="es-MX" DbValueFactor="1" MaxLength="5" Width="30%">
                </telerik:RadNumericTextBox>            
            </td>
            <td style="width:10%"></td>
            <td style="width:10%">
                <asp:Label ID="lblDiasRestan" runat="server" Text="Dias Restantes:" CssClass="Label" ></asp:Label>
            </td>
            <td style="width:10%">
                <telerik:RadNumericTextBox ID="txtDiasUsados0" Runat="server" CssClass="TextBox" 
                    Culture="es-MX" DbValueFactor="1" MaxLength="5" Width="30%">
                </telerik:RadNumericTextBox>            
            </td>
            <td style="width:10%"></td>
            <td style="width:10%">
                <asp:Label ID="lblTipoServ" runat="server" Text="Tipo de Servicio:" CssClass="Label" ></asp:Label>
            </td>
            <td style="width:10%">
                <telerik:RadComboBox CssClass="ComboBox" ID="cmbTipoServicio" Runat="server" 
                    DataTextField="Nombre" DataValueField="Id" MarkFirstMatch="True">
                </telerik:RadComboBox>
            </td>
            <td style="width:20%" colspan="2">
                <asp:LinkButton ID="lnkDetalles" runat="server" CssClass="LinkButton" Width="100%">Detalle de Servicios Anteriores</asp:LinkButton>                
            </td>
        </tr>
        <tr>
            <td style="width:100%" colspan="10">
                &nbsp;
            </td>            
        </tr>
        <tr>
            <td style="width:100%" colspan="10">
                <asp:Label ID="lblValidación" runat="server" Text="Validación de Datos de Identificación, Licencia y Garantía:" 
                    CssClass="LabelNegrita"></asp:Label>
            </td>            
        </tr>
        <tr>
            <td style="width:10%">
                <asp:Label ID="lblTipoIdenti" runat="server" Text="Tipo de Identificación:" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%">
                <telerik:RadComboBox CssClass="ComboBox" ID="cmbTipoIdentificacion" Runat="server" 
                    DataTextField="Nombre" DataValueField="Id" MarkFirstMatch="True">
                </telerik:RadComboBox>
            </td>
            <td style="width:10%">
            </td>
            <td style="width:10%">
                <asp:Label ID="lblLicencia" runat="server" Text="Licencia Permanente:" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%">
                <asp:RadioButton ID="radLicenSi" runat="server" Text="Si"/>
                &nbsp;
                <asp:RadioButton ID="radLicenNo" runat="server" Text="No" />
            </td>
            <td style="width:10%"></td>
            <td style="width:10%">
                <asp:Label ID="lblPagoGarantia" runat="server" Text="Pago de Garantía:" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%">
                <asp:RadioButton ID="radGaranSi" runat="server" Text="Si"/>
                &nbsp;
                <asp:RadioButton ID="radGaranNo" runat="server" Text="No" />
            </td>
            <td style="width:10%"></td>
            <td style="width:10%"></td>
        </tr>        
        <tr>
            <td style="width:10%">
                <asp:Label ID="lblVigenIdenti" runat="server" Text="Identificación Vigente:" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%">
                <asp:RadioButton ID="radIdentiSi" runat="server" Text="Si"/>
                &nbsp;
                <asp:RadioButton ID="radIdentiNo" runat="server" Text="No" />
            </td>
            <td style="width:10%"></td>
            <td style="width:10%">
                <asp:Label ID="lblFecVigencia" runat="server" Text="Fecha de Vigencia:" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%">
                <telerik:RadDatePicker ID="calFecVigencia" runat="server">
                <Calendar runat="server" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>
                <DateInput runat="server" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%" Enabled="false" ></DateInput>
                </telerik:RadDatePicker>
            </td>
            <td style="width:10%"></td>
            <td style="width:10%">
                <asp:Label ID="lblTipoPago" runat="server" Text="Tipo de Pago:" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%">
                <telerik:RadComboBox CssClass="ComboBox" ID="cmbTipoPago" Runat="server" 
                    DataTextField="Nombre" DataValueField="Id" MarkFirstMatch="True">
                </telerik:RadComboBox>
            </td>
            <td style="width:10%"></td>
            <td style="width:10%"></td>
        </tr>
        <tr>
            <td style="width:10%">
                <asp:Label ID="lblMayor25" runat="server" Text="Mayor de 25 años:" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%">
                <asp:RadioButton ID="radMayorSi" runat="server" Text="Si"/>
                &nbsp;
                <asp:RadioButton ID="radMayorNo" runat="server" Text="No" />
            </td>
            <td style="width:10%"></td>
            <td style="width:10%">
                <asp:Label ID="lblTipoLicencia" runat="server" Text="Tipo de Licencia:" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%">
                <telerik:RadComboBox CssClass="ComboBox" ID="cmbTipoLicencia" Runat="server" 
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
            <td style="width:100%" colspan="10"> &nbsp;</td>
        </tr>
        <tr>
            <td style="width:100%" colspan="10">
                <asp:Label ID="lblValidacionDoc" runat="server" Text="Validación de Documentos:" 
                    CssClass="LabelNegrita"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width:100%" colspan="10">
                <telerik:RadGrid ID="gridValidacionDoc" runat="server" Width="100%" AllowSorting="false" AutoGenerateColumns="False" CellSpacing="0" CssClass="Grid" MasterTableView-NoMasterRecordsText="No se encontraron registros"
                    GridLines="Both" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="Orange" Skin="Simple">
                    <MasterTableView>
                        <Columns>
                            <telerik:GridBoundColumn DataField="Nombre" HeaderText="Documento" SortExpression="Documento" UniqueName="Documento">
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn HeaderText="Numero Correspondiente" UniqueName="TXT_NumCorresponde">
                                <ItemTemplate>                                    
                                    <telerik:RadNumericTextBox ID="txtNumCorresponde" runat="server" CssClass="TextBox" MaxLength="50">
                                    </telerik:RadNumericTextBox>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Aceptado" UniqueName="RAD_Aceptado">
                                <ItemTemplate>
                                    <asp:RadioButton ID="radSi" runat="server" Text="Si"/>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Rechazado" UniqueName="RAD_Rechazado">
                                <ItemTemplate>
                                    <asp:RadioButton ID="radNo" runat="server" Text="No"/>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Motivo de Rechazo" UniqueName="CMB_MotivoRechazo">
                                <ItemTemplate>
                                    <telerik:RadComboBox ID="cmbMotivoRecha" runat="server" DataTextField="Nombre" DataValueField="Id" MarkFirstMatch="true" CssClass="ComboBoxPequeño">
                                    </telerik:RadComboBox>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Observacion" UniqueName="TXT_Observaciones">
                                <ItemTemplate>
                                    <telerik:RadTextBox ID="txtObservaciones" runat="server" CssClass="TextBox" >
                                    </telerik:RadTextBox>
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
            <td style="width:100%" colspan="10"> &nbsp; </td>
        </tr>
        <tr>
            <td style="width:100%" colspan="10">
                <asp:Label ID="lblValidacionDocPM" runat="server" Text="Validación de Documentos Persona Moral:" 
                    CssClass="LabelNegrita"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width:100%" colspan="10">
                <telerik:RadGrid ID="gridValidacionDocPM" runat="server" Width="100%" AllowSorting="false" AutoGenerateColumns="False" CellSpacing="0" CssClass="Grid" MasterTableView-NoMasterRecordsText="No se encontraron registros"
                    GridLines="Both" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="Orange" Skin="Simple">
                    <MasterTableView>
                        <Columns>
                            <telerik:GridBoundColumn DataField="Nombre" HeaderText="Documento" SortExpression="Documento" UniqueName="DocumentoPM">
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn HeaderText="Aceptado" UniqueName="RAD_AceptadoPM">
                                <ItemTemplate>
                                    <asp:RadioButton ID="radSiPM" runat="server" Text="Si"/>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Rechazado" UniqueName="RAD_RechazadoPM">
                                <ItemTemplate>
                                    <asp:RadioButton ID="radNoPM" runat="server" Text="No"/>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Motivo de Rechazo" UniqueName="CMB_MotivoRechazoPM">
                                <ItemTemplate>
                                    <telerik:RadComboBox ID="cmbMotivoRechaPM" runat="server" DataTextField="Nombre" DataValueField="Id" MarkFirstMatch="true" CssClass="ComboBoxPequeño">
                                    </telerik:RadComboBox>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Observacion" UniqueName="TXT_ObservacionesPM">
                                <ItemTemplate>
                                    <telerik:RadTextBox ID="txtObservacionesPM" runat="server" CssClass="TextBox" >
                                    </telerik:RadTextBox>
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
            <td style="width:100%" colspan="10"> &nbsp; </td>
        </tr>
        <tr>
            <td style="width:100%" colspan="10">
                <asp:Label ID="lblValidacionDocPM0" runat="server" Text="Validación de Documentos Persona Moral:" 
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
                <asp:Label ID="lblSpeech1" runat="server" Text="Buenos(as) días/tardes/noches el motivo de mi llamada es para informarle sobre la validación de los documentos del servicio:" 
                    CssClass="Label"></asp:Label>
                &nbsp;
                <asp:Label ID="lblNumServicio" runat="server" Text="20150001" 
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
            <td style="width:10%">
                <asp:Label ID="lblObservacion" runat="server" Text="Observacion:" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%">
                <telerik:RadTextBox ID="txtObservacion" Runat="server" TextMode="MultiLine">
                </telerik:RadTextBox>
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
                <asp:Label ID="lblDatosReserva" runat="server" Text="Datos de la Reserva:" 
                    CssClass="LabelNegrita"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width:10%">
                <asp:Label ID="lblTipoServicio" runat="server" Text="Tipo de Servicio:" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%">
                <telerik:RadTextBox ID="txtTipoServicio" Runat="server" Enabled="false" CssClass="TextBox">
                </telerik:RadTextBox>
            </td>
            <td style="width:10%"></td>
            <td style="width:10%">
                <asp:Label ID="lblDiasServ" runat="server" Text="Días de Servicio:" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%">
                <telerik:RadNumericTextBox ID="txtDiasServ" Runat="server" CssClass="TextBox" enabled="false"
                    Culture="es-MX" DbValueFactor="1" MaxLength="5" Width="30%">
                </telerik:RadNumericTextBox>            
            </td>
            <td style="width:10%"></td>
            <td style="width:10%">
                <asp:Label ID="lblMontoDia" runat="server" Text="Monto por Día:" enabled="false"
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%">
                <telerik:RadNumericTextBox ID="txtMontoDia" Runat="server" CssClass="TextBox" enabled="false"
                    Culture="es-MX" DbValueFactor="1" Type="Currency">
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
        </tr>
        <tr>
            <td style="width:10%">
                <asp:Label ID="lblCobertura" runat="server" Text="Cobertura:" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%">
                <asp:Label ID="lblCobertura2" runat="server" Text="Colisión Parcial L.U.C. 15" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%"></td>
            <td style="width:10%">
                <asp:Label ID="lblFecEntrega" runat="server" Text="Fecha de Entrega:" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%">
                <telerik:RadDateTimePicker ID="calFecEntrega" runat="server" Culture="es-MX" Enabled="false" Width="100%">
                </telerik:RadDateTimePicker>
            </td>
            <td style="width:10%"></td>
            <td style="width:10%">
                <asp:Label ID="lblGarantia" runat="server" Text="Garantia:" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%">
                <telerik:RadNumericTextBox ID="txtMontoDia0" Runat="server" CssClass="TextBox" enabled="false"
                    Culture="es-MX" DbValueFactor="1" Type="Currency">
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
        </tr>
        <tr>
            <td style="width:10%">
                <asp:Label ID="lblDiasRestan2" runat="server" Text="Días Restantes:" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%">
                <asp:Label ID="lblDiasRestan3" runat="server" Text="5" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%"></td>
            <td style="width:10%">
                <asp:Label ID="lblFecDevolucion" runat="server" Text="Fecha de Devolución:" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%">
                <telerik:RadDateTimePicker ID="calFecDevolucion" runat="server" Culture="es-MX" Enabled="false" Width="100%">
                </telerik:RadDateTimePicker>
            </td>
            <td style="width:10%"></td>
            <td style="width:10%">
                <asp:Label ID="lblMontoTotal" runat="server" Text="Monto Total:" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%">
                <telerik:RadNumericTextBox ID="txtMontoDia1" Runat="server" CssClass="TextBox" enabled="false"
                    Culture="es-MX" DbValueFactor="1" Type="Currency">
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
        </tr>
        <tr>
            <td style="width:10%">
                <asp:Label ID="lblDiasUsados2" runat="server" Text="Días Usados:" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%">
                <asp:Label ID="lblDiasUsados3" runat="server" Text="10" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%"></td>
            <td style="width:10%"></td>
            <td style="width:10%"></td>
            <td style="width:10%"></td>
            <td style="width:10%">
                <asp:Label ID="lblTipoPago2" runat="server" Text="Tipo de Pago:" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%">
                <telerik:RadComboBox CssClass="ComboBox" ID="cmbMotivo0" Runat="server" enabled="false"
                    DataTextField="Nombre" DataValueField="Id" MarkFirstMatch="True">
                </telerik:RadComboBox>
            </td>
            <td style="width:10%"></td>
            <td style="width:10%"></td>
        </tr>
        <tr>
            <td style="width:100%" colspan="10"></td>
        </tr>
        <tr>
            <td style="width:100%" colspan="10">
                <asp:Label ID="lblSpeech2" runat="server" Text="Seleccionar en caso de no requerir una reservación del vehículo" 
                    CssClass="LabelNegrita"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width:100%" colspan="10">
             <telerik:RadGrid ID="RadGrid1" runat="server" Width="100%" AllowSorting="false" AutoGenerateColumns="False" CellSpacing="0" CssClass="Grid" MasterTableView-NoMasterRecordsText="No se encontraron registros"
                    GridLines="Both" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="Orange" Skin="Simple">
                    <MasterTableView>
                        <Columns>
                            <telerik:GridTemplateColumn HeaderText="Check" UniqueName="CHK">
                                <ItemTemplate>                                    
                                    <asp:CheckBox ID="ChkSeleccionar" runat="server" />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn DataField="Nombre" HeaderText="Accion" SortExpression="Accion" UniqueName="Accion">
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn HeaderText="Motivo" UniqueName="CMB_Motivo">
                                <ItemTemplate>
                                    <telerik:RadComboBox ID="cmbMotivo" runat="server" DataTextField="Nombre" DataValueField="Id" MarkFirstMatch="true" CssClass="ComboBoxPequeño">
                                    </telerik:RadComboBox>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Observaciones" UniqueName="TXT_Observaciones">
                                <ItemTemplate>
                                    <telerik:RadTextBox ID="txtObservaciones" runat="server" CssClass="TextBox" >
                                    </telerik:RadTextBox>
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

