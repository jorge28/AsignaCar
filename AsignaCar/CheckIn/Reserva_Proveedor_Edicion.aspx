<%@ Page Title="" Language="VB" MasterPageFile="~/MasterServicio.master" AutoEventWireup="false" CodeFile="Reserva_Proveedor_Edicion.aspx.vb" Inherits="CheckIn_Reserva_Proveedor_Edicion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">    
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="phAreaTrabajo" Runat="Server">
    <%--Campos para ingresar datos--%>
    <table class="TablaCampos" >
        <tr>
            <td style="width:100%" colspan="10" >
                <asp:Label ID="lblRegistro" runat="server" Text="Registro de Reservación de Vehículo de Proveedor:" 
                    CssClass="LabelNegrita"></asp:Label>
            </td>            
        </tr>        
        <tr>
            <td style="width:10%">
                <asp:Label ID="lblSelectProv" runat="server" Text="Seleccionar Proveedor:" CssClass="Label" ></asp:Label>
            </td>
            <td style="width:10%">
                <telerik:RadButton ID="btnBuscar" runat="server" Text="Buscar Proveedor"></telerik:RadButton>
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
            <td style="width:100%" colspan="10"> &nbsp; </td>
        </tr>
        <tr>
            <td style="width:100%" colspan="10">
                <telerik:RadGrid ID="gridVehiculos" runat="server" Width="100%" AllowSorting="false" AutoGenerateColumns="False" CellSpacing="0" CssClass="Grid" MasterTableView-NoMasterRecordsText="No se encontraron registros"
                    GridLines="Both" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="Orange" Skin="Simple">
                    <MasterTableView>
                        <Columns>
                            <telerik:GridBoundColumn DataField="IdProveedor" HeaderText="Id Proveedor" SortExpression="IdProveedor" UniqueName="IdProveedor" Display="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Proveedor" HeaderText="Nombre Comercial" SortExpression="Proveedor" UniqueName="Proveedor">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="RFC" HeaderText="RFC" SortExpression="RFC" UniqueName="RFC">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="RazonSocial" HeaderText="Razon Social" SortExpression="RazonSocial" UniqueName="RazonSocial">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Estado" HeaderText="Estado" SortExpression="Estado" UniqueName="Estado">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Municipio" HeaderText="Municipio" SortExpression="Municipio" UniqueName="Municipio">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Direccion" HeaderText="Dirección" SortExpression="Direccion" UniqueName="Direccion">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Region" HeaderText="Región" SortExpression="Region" UniqueName="Region">
                            </telerik:GridBoundColumn>
                            <telerik:GridButtonColumn CommandName="Seleccionar" ImageUrl="~/img/Seleccionar.png"  HeaderText="Seleccionar" UniqueName="" Text="Seleccionar" ButtonType="ImageButton">
                            </telerik:GridButtonColumn>                            
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
            <td style="width:100%" colspan="10"> &nbsp;</td>
        </tr>
        <tr>
            <td style="width:100%" colspan="10">
                <asp:Label ID="lblContacto" runat="server" CssClass="LabelNegrita" text="Contacto con el Proveedor para la Reserva">
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
            <td style="width:10%">
                <asp:Label ID="lblMotivo" runat="server" Text="Motivo:"></asp:Label>
            </td>
            <td style="width:10%">
                <telerik:RadComboBox ID="cmbMotivo" runat="server" DataTextField="Nombre" DataValueField="Id" MarkFirstMatch="true"></telerik:RadComboBox>
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
            <td style="width:10%">
                <asp:Label ID="lblCategoria" runat="server" Text="Categoría del Vehiculo:" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%">
                <telerik:RadComboBox CssClass="ComboBox" ID="cmbCategoriaVeh" Runat="server" 
                    DataTextField="Nombre" DataValueField="Id" MarkFirstMatch="True">
                </telerik:RadComboBox>
            </td>
            <td style="width:10%"></td>
            <td style="width:10%">
                <asp:Label ID="lblTarifa" runat="server" Text="Tarifa por Día:" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%">
                <telerik:RadNumericTextBox ID="txtTarifa" Runat="server" CssClass="TextBox"
                    Culture="es-MX" DbValueFactor="1" Width="50px">
                </telerik:RadNumericTextBox>            
            </td>
            <td style="width:10%"></td>
            <td style="width:10%">
                <asp:Label ID="lblIva" runat="server" Text="IVA:" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%">
                <telerik:RadNumericTextBox ID="txtIva" Runat="server" CssClass="TextBox"
                    Culture="es-MX" DbValueFactor="1" Width="50px">
                </telerik:RadNumericTextBox>            
            </td>
            <td style="width:10%"></td>
            <td style="width:10%"></td>
        </tr>       
        <tr>
            <td style="width:10%">
                <asp:Label ID="lblDisponibilidad" runat="server" Text="¿Tiene Disponilidad?" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%">
                <asp:RadioButton ID="radDisponible" runat="server" Text="Si" />
                &nbsp;
                <asp:RadioButton ID="radNoDisponible" runat="server" Text="No" />
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
                <asp:Label ID="lblObservacion" runat="server" Text="Observación:" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:20%" colspan="2">
                <telerik:RadTextBox ID="txtObservacion" runat="server" TextMode="MultiLine" Width="100%" CssClass="TextBox"></telerik:RadTextBox>
            </td>
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
                <asp:Label ID="lblUbicacion" runat="server" Text="Ubicación Entrega:" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%">
                <telerik:RadComboBox CssClass="ComboBox" ID="cmbUbicacionEntrega" Runat="server" 
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
                <asp:Label ID="lblDireccion" runat="server" Text="Dirección Entrega:" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:20%" colspan="2">
                <telerik:RadTextBox ID="txtDireccionEntrega" runat="server" Width="100%" CssClass="TextBox"></telerik:RadTextBox>
            </td>
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
                <asp:Label ID="lblSucur" runat="server" Text="Sucursal:" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:60%" colspan="6">
                <asp:Label ID="lblSucursal" runat="server" Text="Polanco Presidente Masaryk 61, Polanco, Miguel Hidalgo, Ciudad de México, Distrito Federal" Width="100%"
                    CssClass="Label"></asp:Label>
            </td>
        </tr>       
        <tr>
            <td style="width:100%" colspan="10"> &nbsp;</td>
        </tr>
        <tr>
            <td style="width:100%" colspan="10">
                <asp:Label ID="lblDatosCarta" runat="server" Text="Datos de Carta Responsiva" CssClass="LabelNegrita"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width:20%" colspan="2">
                <asp:Label ID="lblOperador" runat="server" Text="Operador de Reservación:"></asp:Label>
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
                <asp:Label ID="lblNombre" runat="server" Text="Nombre:" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%">
                <telerik:RadTextBox ID="txtNombre" runat="server" CssClass="TextBox"></telerik:RadTextBox>
            </td>
            <td style="width:10%">&nbsp;</td>
            <td style="width:10%">
                <asp:Label ID="lblApp" runat="server" Text="Apellido Paterno:" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%">
                <telerik:RadTextBox ID="txtApp" runat="server" CssClass="TextBox"></telerik:RadTextBox>
            </td>
            <td style="width:10%"></td>
            <td style="width:10%">
                <asp:Label ID="lblApm" runat="server" Text="Apellido Materno:" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%">
                <telerik:RadTextBox ID="txtApm" runat="server" CssClass="TextBox"></telerik:RadTextBox>
            </td>
            <td style="width:10%"></td>
            <td style="width:10%"></td>
        </tr>
        <tr>
            <td style="width:10%">
                <asp:Label ID="lblCorreo" runat="server" Text="Correo Electronico:" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%">
                <telerik:RadTextBox ID="txtCorreo" runat="server" CssClass="TextBox"></telerik:RadTextBox>
            </td>
            <td style="width:10%"></td>
            <td style="width:10%">
                <asp:Label ID="lblDiasRenta" runat="server" Text="Días Renta:" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%">
                <telerik:RadNumericTextBox ID="txtDiasRenta" Runat="server" CssClass="TextBox"
                    Culture="es-MX" DbValueFactor="1" Width="50px">
                </telerik:RadNumericTextBox>            
            </td>
            <td style="width:10%"></td>
            <td style="width:10%">
                <asp:Label ID="lblTotalDias" runat="server" Text="Total Días Renta:" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%">
                <telerik:RadNumericTextBox ID="txtTotalDias" Runat="server" CssClass="TextBox"
                    Culture="es-MX" DbValueFactor="1" Width="50px">
                </telerik:RadNumericTextBox>            
            </td>
            <td style="width:10%"></td>
            <td style="width:10%"></td>
        </tr>
        <tr>
            <td style="width:10%">
                <asp:Label ID="lblDropOff" runat="server" Text="Drop Off:" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%">
                <telerik:RadNumericTextBox ID="txtDropOff" Runat="server" CssClass="TextBox"
                    Culture="es-MX" DbValueFactor="1" Width="100px" MaxLength="10">
                </telerik:RadNumericTextBox>            
            </td>
            <td style="width:10%"></td>
            <td style="width:10%">
                <asp:Label ID="lblConduAdicional" runat="server" Text="Conductor Adicional:" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%">
                <telerik:RadNumericTextBox ID="txtConduAdicional" Runat="server" CssClass="TextBox"
                    Culture="es-MX" DbValueFactor="1" Width="100px" MaxLength="10">
                </telerik:RadNumericTextBox>            
            </td>
            <td style="width:10%"></td>
            <td style="width:10%">
                <asp:Label ID="lblConducMenor" runat="server" Text="Conductor Menor:" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%">
                <telerik:RadNumericTextBox ID="txtConduMenor" Runat="server" CssClass="TextBox" Width="100px"
                    Culture="es-MX" DbValueFactor="1" MaxLength="10">
                </telerik:RadNumericTextBox>            
            </td>
            <td style="width:10%"></td>
            <td style="width:10%"></td>
        </tr>
        <tr>
            <td style="width:10%">
                <asp:Label ID="lblImpuesto" runat="server" Text="Impuesto Federal de Aeropuerto:" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%">
                <telerik:RadNumericTextBox ID="txtImpuesto" Runat="server" CssClass="TextBox"
                    Culture="es-MX" DbValueFactor="1" Width="100px" MaxLength="10">
                </telerik:RadNumericTextBox>            
            </td>
            <td style="width:10%"></td>
            <td style="width:10%">
                <asp:Label ID="lblMontoTotal" runat="server" Text="MONTO TOTAL:" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%">
                <telerik:RadNumericTextBox ID="txtMontoTotal" Runat="server" CssClass="TextBox"
                    Culture="es-MX" DbValueFactor="1" Width="100px" MaxLength="15">
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
            <td style="width:10%">
                <asp:Label ID="lblNumReservacion" runat="server" Text="Número de Reservación:" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%">
                <telerik:RadTextBox ID="txtNumReservacion" runat="server" CssClass="TextBox"></telerik:RadTextBox>
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

