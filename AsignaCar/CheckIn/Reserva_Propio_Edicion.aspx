<%@ Page Title="" Language="VB" MasterPageFile="~/MasterServicio.master" AutoEventWireup="false" CodeFile="Reserva_Propio_Edicion.aspx.vb" Inherits="CheckIn_Reserva_Propio_Edicion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">    
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="phAreaTrabajo" Runat="Server">
    <%--Campos para ingresar datos--%>
    <table class="TablaCampos" >
        <tr>
            <td style="width:100%" colspan="10" >
                <asp:Label ID="lblRegistro" runat="server" Text="Registro de Reservación de Vehículo:" 
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
                    Culture="es-MX" DbValueFactor="1" Width="50%">
                </telerik:RadNumericTextBox>            
            </td>
            <td style="width:10%"></td>
            <td style="width:10%"></td>
        </tr>
        <tr>
            <td style="width:10%">
                <asp:Label ID="lblTipoServ" runat="server" Text="Tipo de Servicio:" CssClass="Label" ></asp:Label>
            </td>
            <td style="width:10%">
                <telerik:RadComboBox CssClass="ComboBox" ID="cmbTipoServicio" Runat="server" 
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
            <td style="width:100%" colspan="10">
                <telerik:RadButton ID="btnDisponibilidad" runat="server" Text="Consultar Disponibilidad">
                </telerik:RadButton>
                &nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="lnkProveedor" runat="server" CssClass="LinkButton">Reservar con Proveedor</asp:LinkButton>                
            </td>            
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
                            <telerik:GridBoundColumn DataField="IdVehiculo" HeaderText="Id Vehiculo" SortExpression="IdVehiculo" UniqueName="IdVehiculo" Display="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="MVA" HeaderText="MVA" SortExpression="MVA" UniqueName="MVA">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Marca" HeaderText="Marca" SortExpression="Marca" UniqueName="Marca">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Submarca" HeaderText="Submarca" SortExpression="Submarca" UniqueName="Submarca">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Modelo" HeaderText="Modelo" SortExpression="Modelo" UniqueName="Modelo">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Color" HeaderText="Color" SortExpression="Color" UniqueName="Color">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Matricula" HeaderText="Matricula" SortExpression="Matricula" UniqueName="Matricula">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Region" HeaderText="Región" SortExpression="Region" UniqueName="Region">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Coordinacion" HeaderText="Coordinación" SortExpression="Coordinacion" UniqueName="Coordinacion">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Almacen" HeaderText="Almacen" SortExpression="Almacen" UniqueName="Almacen">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Propietario" HeaderText="Propietario" SortExpression="Propietario" UniqueName="Propietario">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="TipoVehiculo" HeaderText="Tipo de Vehículo" SortExpression="TipoVehiculo" UniqueName="TipoVehiculo">
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
            <td style="width:10%">
                <asp:Label ID="lblUbicacion" runat="server" Text="Ubicación de Entrega:" 
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
            <td style="width:30%" colspan="3">
                <telerik:RadTextBox ID="txtDireccionEntrega" runat="server" Width="100%" CssClass="TextBox"></telerik:RadTextBox>
            </td>
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
                <telerik:RadGrid ID="gridUbicaEntrega" runat="server" Width="100%" AllowSorting="false" AutoGenerateColumns="False" CellSpacing="0" CssClass="Grid" MasterTableView-NoMasterRecordsText="No se encontraron registros"
                    GridLines="Both" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="Orange" Skin="Simple">
                    <MasterTableView>
                        <Columns>
                            <telerik:GridBoundColumn DataField="IdUbicaEntrega" HeaderText="Id Ubicación Entrega" SortExpression="IdUbicaEntrega" UniqueName="IdUbicaEntrega" Display="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="NombreUbicacion" HeaderText="Nombre del Centro/Agencia" SortExpression="Documento" UniqueName="DocumentoPM">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Direccion" HeaderText="Dirección" SortExpression="Direccion" UniqueName="Direccion">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Ciudad" HeaderText="Ciudad" SortExpression="Ciudad" UniqueName="Ciudad">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Municipio" HeaderText="Municipio/Delegación" SortExpression="Municipio" UniqueName="Municipio">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Contacto" HeaderText="Contacto" SortExpression="Contacto" UniqueName="Contacto">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="CorreoE" HeaderText="Correo Electronico" SortExpression="CorreoE" UniqueName="CorreoE">
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
            <td style="width:100%" colspan="10">
                <telerik:RadGrid ID="gridUbicaEntrega2" runat="server" Width="100%" AllowSorting="false" AutoGenerateColumns="False" CellSpacing="0" CssClass="Grid" MasterTableView-NoMasterRecordsText="No se encontraron registros"
                    GridLines="Both" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="White" HeaderStyle-BackColor="Orange" Skin="Simple">
                    <MasterTableView>
                        <Columns>
                            <telerik:GridBoundColumn DataField="IdAgencia" HeaderText="Id Agencia" SortExpression="IdAgencia" UniqueName="IdAgencia" Display="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Agencia" HeaderText="Agencia" SortExpression="Agencia" UniqueName="Agencia">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Municipio" HeaderText="Municipio" SortExpression="Municipio" UniqueName="Municipio">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Direccion" HeaderText="Direccion" SortExpression="Direccion" UniqueName="Direccion">
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
            <td style="width:100%" colspan="10"> &nbsp; </td>
        </tr>
        <tr>
            <td style="width:10%">
                <asp:Label ID="lblNomCentro" runat="server" Text="Nombre del Centro:"
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%">
                <asp:Label ID="lblNombreCentro" runat="server" Text="Centro de Valuación ABA Seguros" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%"></td>
            <td style="width:10%">
                <asp:Label ID="lblDirecCentro" runat="server" Text="Dirección:" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%">
                <asp:Label ID="lblDireccionCentro" runat="server" Text="División del Norte 3054, Coyoacan" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%"></td>
            <td style="width:10%">
                <asp:Label ID="lblCiu" runat="server" Text="Ciudad:"
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%">
                <asp:Label ID="lblCiudad" runat="server" Text="Distrito Federal"
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%"></td>
            <td style="width:10%"></td>
        </tr>
        <tr>
            <td style="width:10%">
                <asp:Label ID="lblTelOfi" runat="server" Text="Teléfono Oficina:" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%">
                <asp:Label ID="lblTelOficina" runat="server" Text="015567856789" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%"></td>
            <td style="width:10%">
                <asp:Label ID="lblExt" runat="server" Text="Extensión:" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%">
                <asp:Label ID="lblExtension" runat="server" Text="23" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%"></td>
            <td style="width:10%">
                <asp:Label ID="lblTelF" runat="server" Text="Teléfono Fijo:" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%">
                <asp:Label ID="lblTelFijo" runat="server" Text="015567543645" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%"></td>
            <td style="width:10%"></td>
        </tr>
        <tr>
            <td style="width:10%">
                <asp:Label ID="lblTelM" runat="server" Text="Móvil:" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%">
                <asp:Label ID="lblTelMovil" runat="server" Text="7712191262" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%"></td>
            <td style="width:10%">
                <asp:Label ID="lblNext" runat="server" Text="Nextel:" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%">
                <asp:Label ID="lblNextel" runat="server" Text="879654" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%"></td>
            <td style="width:10%">
                <asp:Label ID="lblContac" runat="server" Text="Contacto:" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%">
                <asp:Label ID="lblContacto" runat="server" Text="Israel Rojas Martínez" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%"></td>
            <td style="width:10%"></td>
        </tr>
        <tr>
            <td style="width:10%">
                <asp:Label ID="lblCorreoE" runat="server" Text="Correo Electronico del Contacto:" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%">
                <asp:Label ID="lblCorreoElectronico" runat="server" Text="irojas7.17.ir@gmail.com" 
                    CssClass="Label"></asp:Label>
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
            <td style="width:10%">
                <asp:Label ID="lblNumReservacion" runat="server" Text="Número de Reservación:" 
                    CssClass="Label"></asp:Label>
            </td>
            <td style="width:10%">
                <telerik:RadNumericTextBox ID="txtNumReservacion" Runat="server" CssClass="TextBox" Enabled="false" 
                    Culture="es-MX" DbValueFactor="1" Width="100%">
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

