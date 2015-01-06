Imports System.Data
Imports Acceso_a_Datos
Imports System.Data.SqlClient
Imports System.Web.UI.WebControls
Imports Telerik.Web.UI

Partial Class CheckIn_Asignacion_Propio_Edicion

    Inherits System.Web.UI.Page

    ''' <summary>
    ''' Id del formulario
    ''' </summary>
    ''' <remarks></remarks>
    ''' 
    Public Const IdFuncion As Integer = 201 ' Vehiculos

    ' Objetos 
    Dim servCatalogos As New Datos_Catalogos
    Dim servVehiculos As New Datos_ControlVehicular
    Dim respCatalogos As New Resultado
    Dim respVehiculos As New Resultado



    Dim win As Ventanas
    Dim seccionDatos As New SeccionDatos
    ' Dim txtMva As Telerik.Web.UI.RadNumericTextBox


    'Isra
    Dim bor As BorderStyle = BorderStyle.Dotted
    Dim col As Drawing.Color = Drawing.Color.Aqua
    Dim min As Date

    'Protected Sub ConfigureNotification(ByVal titulo As String, ByVal texto As String, Optional ByVal tiempo As Integer = 5000, Optional ByVal Ancho As Integer = 300, Optional ByVal Alto As Integer = 100)
    '    'String
    '    notificacion0.Title = titulo
    '    notificacion0.Text = texto
    '    'Enum
    '    notificacion0.Position = Telerik.Web.UI.NotificationPosition.Center
    '    notificacion0.Animation = Telerik.Web.UI.NotificationAnimation.Fade
    '    'notificacion.ContentScrolling = Telerik.Web.UI.NotificationScrolling.Default
    '    notificacion0.AutoCloseDelay = tiempo
    '    'Unit
    '    notificacion0.Width = Ancho
    '    notificacion0.Height = Alto
    '    notificacion0.OffsetX = -10
    '    notificacion0.OffsetY = 10

    '    notificacion0.Pinned = True
    '    notificacion0.EnableRoundedCorners = True
    '    notificacion0.EnableShadow = True
    '    notificacion0.KeepOnMouseOver = False
    '    notificacion0.VisibleTitlebar = True
    '    notificacion0.ShowCloseButton = True
    '    notificacion0.Show()

    'End Sub

    'Private Sub CargarRegiones(ByRef controlCmb As RadComboBox)
    '    ''Elimina los items cargados previamente
    '    controlCmb.Items.Clear()
    '    controlCmb.SelectedValue = Nothing

    '    'Consulta regiones
    '    respCatalogos = servCatalogos.Consultar_Regiones(Session("IdUsuario"), -1)


    '    ''Se carga el ddl
    '    controlCmb.DataSource = respCatalogos.DataTable
    '    controlCmb.DataBind()

    '    ''Agrega el campo inicial
    '    AgregarValorInicialDDL(controlCmb)
    'End Sub

    'Private Sub CargarCoordinaciones(ByRef controlCmb As RadComboBox, Optional ByVal IdRegion As Integer = -1)
    '    ''Elimina los items cargados previamente
    '    controlCmb.Items.Clear()
    '    controlCmb.SelectedValue = Nothing

    '    If IdRegion <> -1 Then
    '        'Consulta coordinaciones
    '        respCatalogos = servCatalogos.Consultar_Coordinaciones(Session("IdUsuario"), -1, IdRegion)


    '        ''Se carga el ddl
    '        controlCmb.DataSource = respCatalogos.DataTable
    '        controlCmb.DataBind()
    '    End If

    '    ''Agrega el campo inicial
    '    AgregarValorInicialDDL(controlCmb)
    'End Sub

    'Private Sub CargarAlmacenes(ByRef controlCmb As RadComboBox, Optional ByVal IdCoordinacion As Integer = -1)
    '    ''Elimina los items cargados previamente
    '    controlCmb.Items.Clear()
    '    controlCmb.SelectedValue = Nothing

    '    If IdCoordinacion <> -1 Then
    '        'Consulta almacenes
    '        respCatalogos = servCatalogos.Consultar_Almacenes(Session("IdUsuario"), -1, IdCoordinacion)


    '        ''Se carga el ddl
    '        controlCmb.DataSource = respCatalogos.DataTable
    '        controlCmb.DataBind()
    '    End If

    '    ''Agrega el campo inicial
    '    AgregarValorInicialDDL(controlCmb)
    'End Sub

    'Protected Sub cmbAsigRegionAltaVeh_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cmbAsigRegionAltaVeh.SelectedIndexChanged
    '    CargarCoordinaciones(cmbAsigCoordinacionAltaVeh, cmbAsigRegionAltaVeh.SelectedValue)
    '    'cmbAsigCoordinacionAltaVeh.Focus()
    '    calPrimerDiaFlota.Focus()
    'End Sub

    'Protected Sub cmbAsigCoordinacionAltaVeh_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles cmbAsigCoordinacionAltaVeh.SelectedIndexChanged
    '    CargarAlmacenes(cmbAsigAlmacenAltaVeh, cmbAsigCoordinacionAltaVeh.SelectedValue)
    '    cmbAsigAlmacenAltaVeh.Focus()
    'End Sub

    'Public Sub FechaCompra()

    '    calFechaCompra.SelectedDate = Today().AddYears(-5) 'Now().AddYears(-5)
    '    calFechaCompra.MinDate = calFechaCompra.SelectedDate

    '    min = calFechaCompra.MinDate

    'End Sub

    'Private Sub CargarControles()
    '    ConfigureNotification("AutoSigue", "Llene los Campos Obligatorios Con Borde Azul", 3000)
    '    ddlTipoVehiculo.Enabled = False
    '    'RadTextBox
    '    txtMVA.BorderStyle = bor
    '    txtNumSerie.BorderStyle = bor
    '    txtNumSerie.BorderColor = col
    '    txtNumMotor.BorderStyle = bor
    '    txtNumMotor.BorderColor = col
    '    txtFactura.BorderStyle = bor
    '    txtFactura.BorderColor = col
    '    txtPlacas.BorderStyle = bor
    '    txtPlacas.BorderColor = col
    '    txtColor.BorderStyle = bor
    '    txtColor.BorderColor = col
    '    txtTarifa.BorderStyle = bor
    '    txtTarifa.BorderColor = col
    '    txtCapacidadTanque.BorderStyle = bor
    '    txtCapacidadTanque.BorderColor = col
    '    txtKilometraje.BorderStyle = bor
    '    txtKilometraje.BorderColor = col
    '    txtValorVehiculo.BorderStyle = bor
    '    txtValorVehiculo.BorderColor = col
    '    txtEquipamiento.BorderStyle = bor
    '    txtEquipamiento.BorderColor = col
    '    txtCostoInicialPlacas.BorderStyle = bor
    '    txtCostoInicialTenencia.BorderStyle = bor
    '    txtCostoInicialVerificacion.BorderStyle = bor
    '    txtCostoInicialOtros.BorderStyle = bor
    '    txtValorArrendamientoAltaVeh.BorderStyle = bor

    '    'RadComboBox
    '    ddlMarca.BorderStyle = bor
    '    ddlMarca.BorderColor = col
    '    ddlSubMarca.BorderStyle = bor
    '    ddlSubMarca.BorderColor = col
    '    ddlModelo.BorderStyle = bor
    '    ddlModelo.BorderColor = col
    '    ddlNivelGasolina.BorderStyle = bor
    '    ddlNivelGasolina.BorderColor = col
    '    ddlTipoCompra.BorderStyle = bor
    '    ddlTipoCompra.BorderColor = col
    '    ddlTipoVehiculo.BorderStyle = bor
    '    ddlTipoVehiculo.BorderColor = col
    '    ddlNivelGasolina.BorderStyle = bor
    '    ddlNivelGasolina.BorderColor = col
    '    ddlPropietario.BorderStyle = bor
    '    ddlPropietario.BorderColor = col
    '    cmbAsigRegionAltaVeh.BorderStyle = bor
    '    cmbAsigRegionAltaVeh.BorderColor = col
    '    'RadCalender
    '    calFechaCompra.BorderStyle = bor
    '    calFechaCompra.BorderColor = col
    '    calPrimerDiaFlota.BorderStyle = bor
    '    calPrimerDiaFlota.BorderColor = col

    'End Sub

    'Protected Sub ddlTipoCompra_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles ddlTipoCompra.SelectedIndexChanged
    '    ddlTipoVehiculo.Focus()
    '    If ddlTipoCompra.SelectedValue = 1 Then 'Tipo Compra- 1-Arrendamiento, 2-Credito, 3-Contado
    '        ddlTipoVehiculo.Enabled = True ' Tipo Vehiculo 1.-Propio 2-Arrendamiento 3-Consignacion
    '        CargarArrendamiento()
    '    ElseIf ddlTipoCompra.SelectedValue = 2 Then
    '        ddlTipoVehiculo.Enabled = True
    '        CargarTiposVehiculos()
    '    ElseIf ddlTipoCompra.SelectedValue = 3 Then
    '        ddlTipoVehiculo.Enabled = True
    '        CargarContado()
    '    ElseIf ddlTipoCompra.SelectedValue = -1 Then
    '        ddlTipoVehiculo.Enabled = False
    '        ' CargarTiposVehiculos()
    '    End If
    'End Sub

    'Protected Sub ddlPropietario_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles ddlPropietario.SelectedIndexChanged
    '    If ddlPropietario.SelectedValue = 3 Then
    '        If Session("IdAccion") = 2 Then
    '            txtTarifa.Focus()
    '            CargarSoloTarifa()
    '            Label19.Enabled = True
    '            Label19.Visible = True
    '            txtTarifa.Enabled = True
    '            txtTarifa.Visible = True
    '        Else
    '            txtTarifa.Focus()
    '            Label19.Enabled = True
    '            Label19.Visible = True
    '            txtTarifa.Enabled = True
    '            txtTarifa.Visible = True
    '        End If
    '        'ddlTipoVehiculo.Enabled = True
    '    Else
    '        txtTarifa.Text = ""
    '        Label19.Enabled = False
    '        Label19.Visible = False
    '        txtTarifa.Enabled = False
    '        txtTarifa.Visible = False
    '        cmbAsigRegionAltaVeh.Focus()
    '        'calPrimerDiaFlota.Focus()
    '        'ddlTipoVehiculo.Enabled = True
    '    End If
    'End Sub

    'Private Sub CargarSoloTarifa()
    '    respVehiculos = servVehiculos.Consultar_Vehiculos_Completos(Session("IdUsuario"), Session("IdVehiculo"))

    '    Dim row As DataRow = respVehiculos.DataTable.Rows(0)

    '    txtTarifa.Text = row("Tarifa")
    'End Sub

    'Private Sub CargarArrendamiento()
    '    'Elimina los items cargados previamente
    '    ddlTipoVehiculo.Items.Clear()
    '    ddlTipoVehiculo.SelectedValue = Nothing

    '    'Consulta aseguradoras
    '    respCatalogos = servCatalogos.Mostrar_Arrendamiento(Session("IdUsuario"), -1)


    '    'Se carga el ddl
    '    ddlTipoVehiculo.DataSource = respCatalogos.DataTable
    '    ddlTipoVehiculo.DataBind()

    '    'Agrega el campo inicial
    '    AgregarValorInicialDDL(ddlTipoVehiculo)
    'End Sub

    'Private Sub CargarContado()
    '    'Elimina los items cargados previamente
    '    ddlTipoVehiculo.Items.Clear()
    '    ddlTipoVehiculo.SelectedValue = Nothing

    '    'Consulta aseguradoras
    '    respCatalogos = servCatalogos.Mostrar_Contado(Session("IdUsuario"), -1)


    '    'Se carga el ddl
    '    ddlTipoVehiculo.DataSource = respCatalogos.DataTable
    '    ddlTipoVehiculo.DataBind()

    '    'Agrega el campo inicial
    '    AgregarValorInicialDDL(ddlTipoVehiculo)
    'End Sub

    Private Sub CargarTítulo()
        Session("Titulo") = "Check In - Reserva Propio"
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Session("IdAccion") = Request.QueryString("IdAccion")
        'win = New Ventanas(Master)
        CargarTítulo()
        'Dim datos As New ObjDatos
        'Dim res As New Resultado

        'txtHidIdMVA.Text = Session("IdVehiculo")
        'txtHidIdEstatus.Text = Session("Estatus")
        
        If Not Page.IsPostBack Then
            'VerificarOrigen()
            'VerificarPermisos()

            ''Carga los catálogos
            'CargarTiposVehiculos()
            'CargarNivelesGasolina()
            'CargarMarcas()
            'CargarPropietarios()
            'CargarTiposCompra()
            ''CargarRegiones(cmbAsigRegionAltaVeh)
            ''CargarCoordinaciones(cmbAsigCoordinacionAltaVeh)
            ''CargarAlmacenes(cmbAsigAlmacenAltaVeh)
            '' Perpara el título
            'Select Case Session("IdAccion")
            '    Case 0 ' Consulta
            '        CargarValoresCampos()
            '        PrepararModoConsulta()
            '        'VerificarImagenes()
            '    Case 1 ' Alta
            '        PrepararModoAlta()
            '        CargarControles()
            '        FechaCompra()
            '        seccionDatos.LimpiarTexto(Session)
            '        calPrimerDiaFlota.SelectedDate = Date.Today
            '        calPrimerDiaFlota.MinDate = calFechaCompra.SelectedDate
            '        ' ''Isra
            '        ' ''Cargar la funcion Consultar_MVA de Datos_Catalogos
            '        ''respVehiculos = servCatalogos.Consultar_MVA()
            '        ''If respVehiculos.DataTable.Rows.Count > 0 Then

            '        ''    Dim row As DataRow = respVehiculos.DataTable.Rows(0)
            '        ''    txtMVA.Text = row(0).ToString

            '        ''End If
            '        ' ''Termina Isra

            '    Case 2 ' Modificacion
            '        If txtHidIdMVA.Text <= "0" Then
            '            win.Alert("Para Modificar un Vehículo primero debes escoger uno", "Regresar_a_Busqueda")
            '            Exit Sub
            '        End If

            '        If txtHidIdEstatus.Text <> "D" Then
            '            ConfigureNotification("AutoSigue", "No se puede Modificar un Vehículo Inactivo", 3000)
            '            CargarValoresCampos()
            '            PrepararModoConsulta()
            '            'VerificarImagenes()
            '            Exit Sub
            '        Else
            '            CargarValoresCampos()
            '            'VerificarImagenes()
            '            PrepararModoEdicion()
            '            CargarControles()
            '        End If
            '    Case 3 ' Baja
            '        If txtHidIdMVA.Text <= "0" Then
            '            win.Alert("Para dar de Baja un Vehículo primero debes escoger uno", "Regresar_a_Busqueda")
            '            Exit Sub
            '        End If

            '        If txtHidIdEstatus.Text <> "D" Then
            '            ConfigureNotification("AutoSigue", "No se puede dar de Baja un Vehículo Inactivo", 3000)
            '            CargarValoresCampos()
            '            PrepararModoConsulta()
            '            'VerificarImagenes()
            '            Exit Sub
            '        Else
            '            CargarValoresCampos()
            '            PrepararModoConsulta()
            '            btnEliminar.Visible = True
            '            btnCancelar.Visible = True
            '            'VerificarImagenes()
            '        End If
            '    Case 16 ' Consulta
            '        CargarValoresCampos()
            '        PrepararModoConsulta()
            '        'VerificarImagenes()
            'End Select

        End If

        If Page.IsPostBack Then

            '' Verifica si viene de una confirmación de eliminar o de modificar
            'If Request.Form("__EventTarget") = "Modificar" Then
            '    ModificarRegistro()
            'End If
            'If Request.Form("__EventTarget") = "Eliminar" Then
            '    EliminarRegistro()
            'End If
            'If Request.Form("__EventTarget") = "Regresar_a_Busqueda" Then
            '    Regresar_a_Busqueda()
            'End If
            'If Request.Form("__EventTarget") = "Ir_a_Asignacion" Then
            '    Ir_a_Asignacion()
            'End If
        End If
    End Sub

    'Protected Sub btnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGuardar.Click

    '    If txtNumSerie.Text.Trim() = "" Then
    '        ConfigureNotification("AutoSigue", "Anota el Número de Serie", 3000)
    '        txtNumSerie.Focus()
    '        Exit Sub
    '    ElseIf txtNumSerie.Text.Length <= 16 Then
    '        ConfigureNotification("AutoSigue", "Le Faltan Caracteres al Número de Serie", 3000)
    '        txtNumSerie.Focus()
    '        Exit Sub
    '    ElseIf txtNumMotor.Text.Trim() = "" Or txtNumMotor.Text.Trim() = "0" Then
    '        ConfigureNotification("AutoSigue", "Anota el Número de Motor", 3000)
    '        txtNumMotor.Focus()
    '        Exit Sub
    '    ElseIf txtFactura.Text.Trim() = "" Or txtFactura.Text.Trim() = "0" Then
    '        ConfigureNotification("AutoSigue", "Anota La Factura", 3000)
    '        txtFactura.Focus()
    '        Exit Sub
    '    ElseIf ddlMarca.SelectedValue = -1 Then
    '        ConfigureNotification("AutoSigue", "Elije una Marca de Auto", 3000)
    '        ddlMarca.Focus()
    '        Exit Sub
    '    ElseIf ddlSubMarca.SelectedValue = -1 Then
    '        ConfigureNotification("AutoSigue", "Elije una SubMarca de Auto", 3000)
    '        ddlSubMarca.Focus()
    '        Exit Sub
    '    ElseIf ddlModelo.SelectedValue = -1 Then
    '        ConfigureNotification("AutoSigue", "Elije el Modelo de Auto", 3000)
    '        ddlModelo.Focus()
    '        Exit Sub
    '    ElseIf txtPlacas.Text.Trim() = "" Or txtPlacas.Text.Trim() = "0" Then
    '        ConfigureNotification("AutoSigue", "Anota la Matricula", 3000)
    '        txtPlacas.Focus()
    '        Exit Sub
    '    ElseIf txtPlacas.Text.Length < 6 Then
    '        ConfigureNotification("AutoSigue", "La Matricula debe contener almenos 6 caracteres", 3000)
    '        txtPlacas.Focus()
    '        Exit Sub
    '    ElseIf txtColor.Text.Trim() = "" Or txtColor.Text.Trim() = "0" Then
    '        ConfigureNotification("AutoSigue", "Anota el Color del Auto", 3000)
    '        txtColor.Focus()
    '        Exit Sub
    '    ElseIf txtCapacidadTanque.Text.Trim() = "" Or txtPlacas.Text.Trim() = "0" Then
    '        ConfigureNotification("AutoSigue", "Anota la Capacidad del Tanque", 3000)
    '        txtCapacidadTanque.Focus()
    '        Exit Sub
    '    ElseIf txtKilometraje.Text.Trim() = "" Or txtKilometraje.Text.Trim() = "0" Then
    '        ConfigureNotification("AutoSigue", "Anota el Kilometraje", 3000)
    '        txtKilometraje.Focus()
    '        Exit Sub
    '    ElseIf ddlNivelGasolina.SelectedValue = -1 Then
    '        ConfigureNotification("AutoSigue", "Elije el Nivel de Gasolina", 3000)
    '        ddlNivelGasolina.Focus()
    '        Exit Sub
    '    ElseIf radTransmision.SelectedValue = "" Then
    '        ConfigureNotification("AutoSigue", "Elije una Transmisión", 3000)
    '        radTransmision.Focus()
    '        Exit Sub
    '    ElseIf calFechaCompra.SelectedDate > Date.Today Then
    '        ConfigureNotification("AutoSigue", "La Fecha de Compra no deber ser mayor a la Fecha:" & " " & Date.Today, 6000)
    '        FechaCompra()
    '        calFechaCompra.Focus()
    '        Exit Sub
    '    ElseIf ddlTipoCompra.SelectedValue = -1 Then
    '        ConfigureNotification("AutoSigue", "Elije el Tipo de Compra", 3000)
    '        ddlTipoCompra.Focus()
    '        Exit Sub
    '    ElseIf ddlTipoVehiculo.SelectedValue = -1 Then
    '        ConfigureNotification("AutoSigue", "Elije el Tipo de Vehiculo", 3000)
    '        ddlTipoVehiculo.Focus()
    '        Exit Sub
    '    ElseIf txtValorVehiculo.Text.Trim() = "" Or txtValorVehiculo.Text.Trim() = "0" Then
    '        ConfigureNotification("AutoSigue", "Anota el Valor Vehicular", 3000)
    '        txtValorVehiculo.Focus()
    '        Exit Sub
    '    ElseIf txtEquipamiento.Text.Trim() = "" Or txtEquipamiento.Text.Trim() = "0" Then
    '        ConfigureNotification("AutoSigue", "Anota el Equipamiento", 3000)
    '        txtEquipamiento.Focus()
    '        Exit Sub
    '    ElseIf ddlPropietario.SelectedValue = -1 Then
    '        ConfigureNotification("AutoSigue", "Elije el Propietario", 3000)
    '        ddlPropietario.Focus()
    '        Exit Sub
    '    ElseIf ddlPropietario.SelectedValue = 3 And (txtTarifa.Text = "" Or txtTarifa.Text = "0") Then
    '        ConfigureNotification("AutoSigue", "Anota la Tarifa", 3000)
    '        txtTarifa.Focus()
    '        Exit Sub
    '        'ElseIf cmbAsigRegionAltaVeh.SelectedValue = -1 Then
    '        '    ConfigureNotification("AutoSigue", "Elije la Región para el Vehículo", 3000)
    '        '    cmbAsigRegionAltaVeh.Focus()
    '        '    Exit Sub
    '    ElseIf calPrimerDiaFlota.SelectedDate < calFechaCompra.SelectedDate Then
    '        ConfigureNotification("AutoSigue", "La Fecha de Flota no debe ser menor a la Fecha de Compra" & " " & calFechaCompra.SelectedDate, 5000)
    '        calPrimerDiaFlota.SelectedDate = Date.Today
    '        calPrimerDiaFlota.Focus()
    '        Exit Sub
    '    ElseIf calPrimerDiaFlota.SelectedDate > Date.Now Then
    '        ConfigureNotification("AutoSigue", "La Fecha de Flota no debe ser mayor a la Fecha Actual" & " " & Date.Now, 5000)
    '        calPrimerDiaFlota.SelectedDate = Date.Today
    '        calPrimerDiaFlota.Focus()
    '        Exit Sub
    '    ElseIf txtDescrCostos.Visible = True Then
    '        If txtDescrCostos.Text.Trim() = "" Or txtDescrCostos.Text.Trim() = "0" Then
    '            ConfigureNotification("AutoSigue", "Anota la Descripción de Otros Costos", 3000)
    '            txtDescrCostos.Focus()
    '            Exit Sub
    '        End If
    '    End If

    '    Select Case Session("IdAccion")
    '        Case 1 'Alta
    '            AgregarRegistro()
    '        Case 2 ' Modificacion
    '            win.Confirm("¿Está seguro de que desea modificar el vehículo?", "confirmCallBack_Modificar")
    '    End Select
    'End Sub

    ''Protected Sub ddlMarca_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles ddlMarca.SelectedIndexChanged
    ''    ' Carga las submarcas
    ''    CargarSubMarcas(ddlMarca.SelectedValue)
    ''    CargarModelos()
    ''    ddlSubMarca.Focus()
    ''End Sub

    ''Protected Sub ddlSubMarca_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles ddlSubMarca.SelectedIndexChanged
    ''    CargarModelos(ddlSubMarca.SelectedValue)
    ''    ddlModelo.Focus()
    ''End Sub

    ''Protected Function ValidarDatos() As Boolean
    ''    ' Valida los datos
    ''    Try
    ''        If Session("IdAccion") = 2 Then ' Modificacion
    ''            If ViewState("Kilometraje") > CInt(txtKilometraje.Text) Then
    ''                'Isra
    ''                respVehiculos = servVehiculos.Consultar_Vehiculos_Completos(Session("IdUsuario"), Session("IdVehiculo"))
    ''                Dim row As DataRow = respVehiculos.DataTable.Rows(0)

    ''                txtKilometraje.Text = row("Kilometraje")
    ''                '
    ''                Throw New Exception("El kilometraje no puede ser menor al anterior")
    ''                txtKilometraje.Focus()
    ''                'ConfigureNotification("AutoSigue", "El Kilometraje no puede ser menor al Anterior", 3000)
    ''                'Exit sub
    ''            End If
    ''        End If

    ''        If ddlTipoVehiculo.SelectedValue = 2 Then
    ''            If ddlTipoCompra.SelectedValue <> 1 Then
    ''                Throw New Exception("si el tipo vehículo es ARRENDAMIENTO el tipo de compra debe ser ARRENDAMIENTO.")
    ''            End If
    ''        End If

    ''    Catch ex As Exception
    ''        win.Alert(ex.Message)
    ''        Return False
    ''    End Try

    ''    Return True
    ''End Function

    ''Protected Sub btnEliminar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
    ''    win.Confirm("¿Está seguro de que desea eliminar el vehículo?", "confirmCallBack_Eliminar")
    ''    Session("DiadeFlota") = calPrimerDiaFlota.SelectedDate
    ''End Sub

    ''Private Function CrearVehiculo() As CVehiculo
    ''    Dim vehiculo As New CVehiculo

    ''    If Session("IdAccion") = 2 Then ' Modificacion
    ''        vehiculo.Id = Session("IdVehiculo")
    ''    End If
    ''    vehiculo.MVA = txtMVA.Text.Trim
    ''    vehiculo.CapacidadTanque = IIf(txtCapacidadTanque.Text.Trim = "", 0, txtCapacidadTanque.Text.Trim)
    ''    vehiculo.Color = txtColor.Text.Trim
    ''    vehiculo.Desc_Otros_Costos = IIf(txtDescrCostos.Text.Trim = "", 0, txtDescrCostos.Text.Trim)
    ''    vehiculo.CostoInicial_Otros = IIf(txtCostoInicialOtros.Text.Trim = "", 0, txtCostoInicialOtros.Text.Trim)
    ''    vehiculo.CostoInicial_Placas = IIf(txtCostoInicialPlacas.Text.Trim = "", 0, txtCostoInicialPlacas.Text.Trim)
    ''    vehiculo.CostoInicial_Tenencia = IIf(txtCostoInicialTenencia.Text.Trim = "", 0, txtCostoInicialTenencia.Text.Trim)
    ''    vehiculo.CostoInicial_Verificacion = IIf(txtCostoInicialVerificacion.Text.Trim = "", 0, txtCostoInicialVerificacion.Text.Trim)
    ''    vehiculo.Equipamiento = Left(txtEquipamiento.Text.Trim, 500)
    ''    vehiculo.Factura = txtFactura.Text.Trim
    ''    vehiculo.Kilometraje = IIf(txtKilometraje.Text.Trim = "", 0, txtKilometraje.Text.Trim)
    ''    vehiculo.Modelo = ddlModelo.SelectedValue
    ''    vehiculo.NumMotor = txtNumMotor.Text.Trim
    ''    vehiculo.NumSerie = txtNumSerie.Text.Trim
    ''    vehiculo.Placas = txtPlacas.Text.Trim
    ''    vehiculo.IdSubMarca = ddlSubMarca.SelectedValue
    ''    vehiculo.Tarifa = IIf(txtTarifa.Text.Trim = "", 0, txtTarifa.Text.Trim)
    ''    vehiculo.ValorVehiculo = IIf(txtValorVehiculo.Text.Trim = "", 0, txtValorVehiculo.Text.Trim)
    ''    vehiculo.ValorVehiculoArrendamiento = IIf(txtValorArrendamientoAltaVeh.Text.Trim = "", 0, txtValorArrendamientoAltaVeh.Text.Trim)
    ''    vehiculo.IdMarca = ddlMarca.SelectedValue
    ''    vehiculo.IdPropietario = ddlPropietario.SelectedValue
    ''    vehiculo.IdTipoCompra = ddlTipoCompra.SelectedValue
    ''    vehiculo.IdNivelGasolina = ddlNivelGasolina.SelectedValue
    ''    vehiculo.IdTipoVehiculo = ddlTipoVehiculo.SelectedValue
    ''    'vehiculo.IdRegion = cmbAsigRegionAltaVeh.SelectedValue '----------------------------------------------
    ''    vehiculo.FecCompra = IIf(calFechaCompra.IsEmpty, #1/1/1900#, calFechaCompra.SelectedDate)
    ''    vehiculo.FecPrimerDiaFlota = IIf(calPrimerDiaFlota.IsEmpty, #1/1/1900#, calPrimerDiaFlota.SelectedDate)
    ''    vehiculo.Inv_AireAcondicionado = chkAireAcondicionado.Checked
    ''    vehiculo.Inv_Encendedor = chkEncendedor.Checked
    ''    vehiculo.Inv_Extintor = chkExtintor.Checked
    ''    vehiculo.Inv_Gato = chkGato.Checked
    ''    vehiculo.Inv_Herramientas = chkHerramientas.Checked
    ''    vehiculo.Inv_LlantaRefaccion = chkLlantaRefaccion.Checked
    ''    vehiculo.Inv_Llaves = chkLlaves.Checked
    ''    vehiculo.Inv_ManualConductor = chkManualConductor.Checked
    ''    vehiculo.Inv_Radio = chkRadio.Checked
    ''    vehiculo.Inv_Reflejantes = chkReflejantes.Checked
    ''    vehiculo.Transmision = IIf(radTransmision.SelectedIndex = -1, "", radTransmision.SelectedValue)
    ''    'isra
    ''    vehiculo.status = ""
    ''    '
    ''    Return vehiculo
    ''End Function

    ''Private Sub CargarPropietarios()
    ''    'Elimina los items cargados previamente
    ''    ddlPropietario.Items.Clear()
    ''    ddlPropietario.SelectedValue = Nothing

    ''    'Consulta aseguradoras
    ''    respCatalogos = servCatalogos.Consultar_Propietario(Session("IdUsuario"), -1)


    ''    'Se carga el ddl
    ''    ddlPropietario.DataSource = respCatalogos.DataTable
    ''    ddlPropietario.DataBind()

    ''    'Agrega el campo inicial
    ''    AgregarValorInicialDDL(ddlPropietario)
    ''End Sub

    ''Protected Sub txtCostoInicialOtros_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCostoInicialOtros.TextChanged
    ''    If txtCostoInicialOtros.Text.Trim = "0" Or txtCostoInicialOtros.Text = "" Then
    ''        txtDescrCostos.Visible = False
    ''    Else
    ''        Label30.Visible = True
    ''        txtDescrCostos.Visible = True
    ''        txtDescrCostos.BorderStyle = bor
    ''        txtDescrCostos.BorderColor = col
    ''    End If

    ''End Sub
    ' ''Termina Isra

    'Protected Sub VerificarOrigen()
    '    ' Verifica que se haya llamado la pantalla desde un lugar seguro
    '    If Not Session("OrigenSeguro") Then
    '        Response.Redirect("~/General/Inicio.aspx")
    '        Exit Sub
    '    End If

    '    Session("OrigenSeguro") = False
    'End Sub

    'Private Sub VerificarPermisos()
    '    Dim permisos As Permisos = Session("Permisos")

    '    ' Verifica permisos de formulario
    '    If Not permisos.VerificarPermisoFuncion(IdFuncion) Then
    '        Response.Redirect("~/General/Inicio.aspx")
    '    End If

    'End Sub

    'Private Sub CargarMarcas()
    '    ''Elimina los items cargados previamente
    '    ddlMarca.Items.Clear()
    '    ddlMarca.SelectedValue = Nothing

    '    'Consulta tipos de pagos
    '    respCatalogos = servCatalogos.Consultar_Marcas(Session("IdUsuario"), -1)


    '    ''Se carga el ddl
    '    ddlMarca.DataSource = respCatalogos.DataTable
    '    ddlMarca.DataBind()

    '    ''Agrega el campo inicial
    '    AgregarValorInicialDDL(ddlMarca)
    'End Sub

    'Private Sub CargarSubMarcas(Optional ByVal idMarca As Integer = -1)
    '    ''Elimina los items cargados previamente
    '    ddlSubMarca.Items.Clear()
    '    ddlSubMarca.SelectedValue = Nothing

    '    If idMarca <> -1 Then
    '        'Consulta tipos de pagos
    '        respCatalogos = servCatalogos.Consultar_SubMarcas(Session("IdUsuario"), -1, idMarca)


    '        ''Se carga el ddl
    '        ddlSubMarca.DataSource = respCatalogos.DataTable
    '        ddlSubMarca.DataBind()
    '    End If

    '    ''Agrega el campo inicial
    '    AgregarValorInicialDDL(ddlSubMarca)
    'End Sub

    'Private Sub CargarModelos(Optional ByVal idSubMarca As Integer = -1)
    '    ''Elimina los items cargados previamente
    '    ddlModelo.Items.Clear()
    '    ddlModelo.SelectedValue = Nothing
    '    If idSubMarca <> -1 Then

    '        'Consulta tipos de pagos
    '        respCatalogos = servCatalogos.Consultar_Modelos(Session("IdUsuario"), -1, idSubMarca)


    '        ''Se carga el ddl
    '        ddlModelo.DataSource = respCatalogos.DataTable
    '        ddlModelo.DataBind()
    '    End If

    '    ''Agrega el campo inicial
    '    AgregarValorInicialDDL(ddlModelo)
    'End Sub

    'Private Sub CargarNivelesGasolina()
    '    ''Elimina los items cargados previamente
    '    ddlNivelGasolina.Items.Clear()
    '    ddlNivelGasolina.SelectedValue = Nothing


    '    'Consulta Coberturas
    '    respCatalogos = servCatalogos.Consultar_NivelesGasolina(Session("IdUsuario"), -1)

    '    ''Se carga el ddl
    '    ddlNivelGasolina.DataSource = respCatalogos.DataTable
    '    ddlNivelGasolina.DataBind()

    '    ''Agrega el campo inicial
    '    AgregarValorInicialDDL(ddlNivelGasolina)
    'End Sub

    'Private Sub CargarTiposVehiculos()
    '    'Elimina los items cargados previamente
    '    ddlTipoVehiculo.Items.Clear()
    '    ddlTipoVehiculo.SelectedValue = Nothing

    '    'Consulta aseguradoras
    '    respCatalogos = servCatalogos.Consultar_TiposVehiculos(Session("IdUsuario"), -1)


    '    'Se carga el ddl
    '    ddlTipoVehiculo.DataSource = respCatalogos.DataTable
    '    ddlTipoVehiculo.DataBind()

    '    'Agrega el campo inicial
    '    AgregarValorInicialDDL(ddlTipoVehiculo)
    'End Sub

    'Private Sub CargarTiposCompra()
    '    'Elimina los items cargados previamente
    '    ddlTipoCompra.Items.Clear()
    '    ddlTipoCompra.SelectedValue = Nothing

    '    'Consulta aseguradoras
    '    respCatalogos = servCatalogos.Consultar_TiposCompra(Session("IdUsuario"), -1)


    '    'Se carga el ddl
    '    ddlTipoCompra.DataSource = respCatalogos.DataTable
    '    ddlTipoCompra.DataBind()

    '    'Agrega el campo inicial
    '    AgregarValorInicialDDL(ddlTipoCompra)
    'End Sub

    'Private Sub PrepararModoConsulta()
    '    txtMVA.Enabled = False
    '    txtCapacidadTanque.Enabled = False
    '    txtColor.Enabled = False
    '    txtCostoInicialOtros.Enabled = False
    '    txtCostoInicialPlacas.Enabled = False
    '    txtCostoInicialTenencia.Enabled = False
    '    txtCostoInicialVerificacion.Enabled = False
    '    txtCostoInicialTenencia.Visible = True
    '    txtCostoInicialVerificacion.Visible = True
    '    lblcostotene.Visible = True
    '    lblcostoveri.Visible = True
    '    txtEquipamiento.Enabled = False
    '    txtFactura.Enabled = False
    '    txtKilometraje.Enabled = False
    '    ddlModelo.Enabled = False
    '    txtNumMotor.Enabled = False
    '    txtNumSerie.Enabled = False
    '    txtPlacas.Enabled = False
    '    ddlSubMarca.Enabled = False
    '    txtTarifa.Enabled = False
    '    txtValorVehiculo.Enabled = False
    '    txtValorArrendamientoAltaVeh.Enabled = False
    '    ddlMarca.Enabled = False
    '    ddlPropietario.Enabled = False
    '    ddlTipoCompra.Enabled = False
    '    ddlNivelGasolina.Enabled = False
    '    ddlTipoVehiculo.Enabled = False
    '    'cmbAsigRegionAltaVeh.Enabled = False
    '    calFechaCompra.Enabled = False
    '    calPrimerDiaFlota.Enabled = False
    '    chkAireAcondicionado.Enabled = False
    '    chkEncendedor.Enabled = False
    '    chkExtintor.Enabled = False
    '    chkGato.Enabled = False
    '    chkHerramientas.Enabled = False
    '    chkLlantaRefaccion.Enabled = False
    '    chkLlaves.Enabled = False
    '    chkManualConductor.Enabled = False
    '    chkRadio.Enabled = False
    '    chkReflejantes.Enabled = False
    '    radTransmision.Enabled = False
    '    'Isra
    '    If txtCostoInicialOtros.Text.Trim() <> 0 Then
    '        Label30.Visible = True
    '        txtDescrCostos.Visible = True
    '        txtDescrCostos.Enabled = False
    '    End If
    '    '
    '    btnInciso.Enabled = (hidNumPoliza.Value <> "")

    '    btnGuardar.Visible = False
    '    btnCancelar.Visible = False

    'End Sub

    'Private Sub CargarValoresCampos()
    '    'Consulta Póliza que se desear consultar
    '    respVehiculos = servVehiculos.Consultar_Vehiculos_Completos(Session("IdUsuario"), Session("IdVehiculo"))

    '    Dim row As DataRow = respVehiculos.DataTable.Rows(0)

    '    txtCapacidadTanque.Text = row("CapacidadTanque")
    '    txtColor.Text = row("Color")
    '    txtCostoInicialOtros.Text = IIf(row("CostoInicial_Otros") = 0, 0, row("CostoInicial_Otros"))
    '    txtCostoInicialPlacas.Text = IIf(row("CostoInicial_Placas") = 0, 0, row("CostoInicial_Placas"))
    '    'txtCostoInicialTenencia.Text = IIf(("CostoInicial_Tenencia") = "", 0, row("CostoInicial_Tenencia"))
    '    'txtCostoInicialVerificacion.Text = IIf(row("CostoInicial_Verificacion") = 0, 0, row("CostoInicial_Verificacion"))
    '    If row("CostoIniTenencia") IsNot DBNull.Value Then
    '        txtCostoInicialTenencia.Text = row("CostoIniTenencia")
    '    Else
    '        txtCostoInicialTenencia.Text = "0"
    '    End If
    '    If row("CostoIniTenencia") IsNot DBNull.Value Then
    '        txtCostoInicialVerificacion.Text = row("CostoIniVerifica")
    '    Else
    '        txtCostoInicialVerificacion.Text = "0"
    '    End If
    '    'txtCostoInicialTenencia.Text = IIf(row("CostoIniTenencia") = "", 0, row("CostoIniTenencia"))
    '    'txtCostoInicialVerificacion.Text = IIf(row("CostoIniVerifica") = 0, 0, row("CostoIniVerifica"))
    '    txtEquipamiento.Text = row("Equipamiento")
    '    txtFactura.Text = row("Factura")
    '    txtKilometraje.Text = row("Kilometraje")
    '    txtMVA.Text = row("MVA")
    '    txtNumMotor.Text = row("NumMotor")
    '    txtNumSerie.Text = row("NumSerie")
    '    txtPlacas.Text = row("Placas")
    '    txtTarifa.Text = row("Tarifa")
    '    txtValorVehiculo.Text = row("ValorVehiculo")
    '    'txtValorArrendamientoAltaVeh.Text = row("ValorVehiculo")
    '    ddlMarca.SelectedValue = row("IdMarca")
    '    CargarSubMarcas(ddlMarca.SelectedValue)
    '    ddlSubMarca.SelectedValue = row("IdSubmarca")
    '    CargarModelos(ddlSubMarca.SelectedValue)
    '    ddlModelo.SelectedValue = row("Modelo")
    '    ddlPropietario.SelectedValue = row("IdPropietario")
    '    ddlTipoCompra.SelectedValue = row("IdTipoCompra")
    '    ddlNivelGasolina.SelectedValue = row("IdNivelGasolina")
    '    ddlTipoVehiculo.SelectedValue = row("IdTipoVehiculo")
    '    calFechaCompra.SelectedDate = IIf(row("FecCompra") = #1/1/1900#, calFechaCompra.SelectedDate = Date.Today, row("FecCompra"))
    '    calPrimerDiaFlota.SelectedDate = IIf(row("FecPrimerDiaFlota") = #1/1/1900#, calPrimerDiaFlota.SelectedDate = Date.Today, row("FecPrimerDiaFlota"))
    '    chkAireAcondicionado.Checked = row("Inv_AireAcondicionado")
    '    chkEncendedor.Checked = row("Inv_Encendedor")
    '    chkExtintor.Checked = row("Inv_Extintor")
    '    chkGato.Checked = row("Inv_Gato")
    '    chkHerramientas.Checked = row("Inv_Herramientas")
    '    chkLlantaRefaccion.Checked = row("Inv_LlantaRefaccion")
    '    chkLlaves.Checked = row("Inv_Llaves")
    '    chkManualConductor.Checked = row("Inv_ManualConductor")
    '    chkRadio.Checked = row("Inv_Radio")
    '    chkReflejantes.Checked = row("Inv_Reflejantes")
    '    If txtCostoInicialOtros.Text.Trim() <> 0 Then
    '        'Isra
    '        txtDescrCostos.Text = row("Desc_Otros_Costo")
    '    Else
    '        txtDescrCostos.Text = "0"
    '        '
    '    End If
    '    If row("Transmision") <> "" Then
    '        radTransmision.SelectedValue = row("Transmision")
    '    End If
    '    If Not IsDBNull(row("IdPoliza")) Then
    '        hidIdPoliza.Value = row("IdPoliza")
    '        hidNumPoliza.Value = row("NumPoliza")
    '        lblInciso.Text = row("NumPoliza") & "-" & row("Inciso")
    '        btnInciso.Enabled = True
    '    Else
    '        btnInciso.Enabled = False
    '    End If

    '    'Carga en viewstate el km y los datos del historial
    '    ViewState("Kilometraje") = txtKilometraje.Text
    '    ViewState("IdPropietario") = ddlPropietario.SelectedValue
    '    ViewState("Placas") = txtPlacas.Text
    'End Sub

    'Private Sub VerificarImagenes()
    '    Dim img As New Imagenes

    '    ' Verifica si hay imagenes en carpix
    '    img.Expediente = txtMVA.Text
    '    img.TipoImagen = EnumTiposImagenes.Vehiculos
    '    btnImagenes.Enabled = img.ContieneImagenes()
    '    If Not btnImagenes.Enabled Then
    '        btnImagenes.Text = "No hay imágenes"
    '    End If
    'End Sub

    'Private Sub ModificarRegistro()
    '    Dim vehiculo As CVehiculo

    '    ' Valida los datos
    '    If Not ValidarDatos() Then Exit Sub

    '    'Se crea la poliza
    '    vehiculo = CrearVehiculo()

    '    'Si el usuario cambio los datos del historial
    '    If vehiculo.IdPropietario <> ViewState("IdPropietario") Then
    '        vehiculo.Cambio_IdPropietario = True
    '    End If
    '    If vehiculo.Kilometraje <> ViewState("Kilometraje") Then
    '        vehiculo.Cambio_Kilometraje = True
    '    End If
    '    If vehiculo.Placas <> ViewState("Placas") Then
    '        vehiculo.Cambio_Placas = True
    '    End If

    '    'Se manda llamar el ws
    '    respVehiculos = servVehiculos.Actualizar_Vehiculos(Session("Id"), vehiculo)

    '    'Si fué éxito
    '    If respVehiculos.Estatus = Estatus.Exito Then
    '        Session("OrigenSeguro") = True
    '        win.Alert("Vehículo Modificado con Éxito", "Regresar_a_Busqueda")

    '        EnviarAlarma_KmRecorridos(vehiculo.Kilometraje)
    '    Else
    '        ' En caso de error, lo muestra en pantalla
    '        win.Alert_Error(respVehiculos.ErrorDesc)
    '    End If

    'End Sub

    'Private Sub EliminarRegistro()
    '    Session("OrigenSeguro") = True
    '    win.Abrir_winMotivoBajaVehiculo()
    'End Sub

    'Private Sub PrepararModoAlta()
    '    'Habilita controles
    '    txtMVA.Enabled = False
    '    txtCapacidadTanque.Enabled = True
    '    txtColor.Enabled = True
    '    txtCostoInicialOtros.Enabled = True
    '    txtCostoInicialPlacas.Enabled = True
    '    txtCostoInicialTenencia.Enabled = True
    '    txtCostoInicialVerificacion.Enabled = True
    '    txtEquipamiento.Enabled = True
    '    txtFactura.Enabled = True
    '    txtKilometraje.Enabled = True
    '    ddlModelo.Enabled = True
    '    txtNumMotor.Enabled = True
    '    txtNumSerie.Enabled = True
    '    txtPlacas.Enabled = True
    '    ddlSubMarca.Enabled = True
    '    txtTarifa.Enabled = True
    '    ddlMarca.Enabled = True
    '    ddlPropietario.Enabled = True
    '    ddlTipoCompra.Enabled = True
    '    ddlNivelGasolina.Enabled = True
    '    cmbAsigRegionAltaVeh.Enabled = True
    '    chkAireAcondicionado.Enabled = True
    '    chkEncendedor.Enabled = True
    '    chkExtintor.Enabled = True
    '    chkGato.Enabled = True
    '    chkHerramientas.Enabled = True
    '    chkLlantaRefaccion.Enabled = True
    '    chkLlaves.Enabled = True
    '    chkManualConductor.Enabled = True
    '    chkRadio.Enabled = True
    '    chkReflejantes.Enabled = True
    '    radTransmision.Enabled = True

    '    'LimpiaCampos
    '    txtCapacidadTanque.Text = ""
    '    txtColor.Text = ""
    '    txtCostoInicialOtros.Text = ""
    '    txtCostoInicialPlacas.Text = ""
    '    txtCostoInicialTenencia.Text = ""
    '    txtCostoInicialVerificacion.Text = ""
    '    txtEquipamiento.Text = ""
    '    txtFactura.Text = ""
    '    txtKilometraje.Text = ""
    '    'txtMVA.Text = ""
    '    txtNumMotor.Text = ""
    '    txtNumSerie.Text = ""
    '    txtPlacas.Text = ""
    '    txtTarifa.Text = ""
    '    txtValorVehiculo.Text = ""
    '    txtValorArrendamientoAltaVeh.Text = ""
    '    ddlMarca.SelectedValue = "-1"
    '    CargarSubMarcas()
    '    ddlSubMarca.SelectedValue = "-1"
    '    CargarModelos()
    '    ddlModelo.SelectedValue = "-1"
    '    ddlPropietario.SelectedValue = "-1"
    '    ddlTipoCompra.SelectedValue = "-1"
    '    ddlNivelGasolina.SelectedValue = "-1"
    '    ddlTipoVehiculo.SelectedValue = "-1"
    '    chkAireAcondicionado.Checked = False
    '    chkEncendedor.Checked = False
    '    chkExtintor.Checked = False
    '    chkGato.Checked = False
    '    chkHerramientas.Checked = False
    '    chkLlantaRefaccion.Checked = False
    '    chkLlaves.Checked = False
    '    chkManualConductor.Checked = False
    '    chkRadio.Checked = False
    '    chkReflejantes.Checked = False
    '    radTransmision.SelectedIndex = -1

    '    ViewState("Kilometraje") = 0

    '    btnInciso.Enabled = False

    '    btnGuardar.Visible = True
    '    btnCancelar.Visible = True

    'End Sub

    'Private Sub PrepararModoEdicion()
    '    txtMVA.Enabled = False
    '    txtCapacidadTanque.Enabled = True
    '    txtColor.Enabled = True
    '    txtCostoInicialOtros.Enabled = False
    '    txtCostoInicialPlacas.Enabled = False
    '    txtCostoInicialTenencia.Enabled = False
    '    txtCostoInicialVerificacion.Enabled = False
    '    txtCostoInicialTenencia.Visible = True
    '    txtCostoInicialVerificacion.Visible = True
    '    lblcostotene.Visible = True
    '    lblcostoveri.Visible = True
    '    txtEquipamiento.Enabled = True
    '    txtFactura.Enabled = True
    '    txtKilometraje.Enabled = True
    '    txtNumMotor.Enabled = True
    '    txtNumSerie.Enabled = False
    '    txtPlacas.Enabled = True
    '    txtValorVehiculo.Enabled = True
    '    txtValorArrendamientoAltaVeh.Enabled = True
    '    ddlMarca.Enabled = True
    '    ddlSubMarca.Enabled = True
    '    ddlModelo.Enabled = True
    '    ddlPropietario.Enabled = True
    '    If ddlPropietario.SelectedValue = 3 Then
    '        Label19.Visible = True
    '        txtTarifa.Visible = True
    '        txtTarifa.Enabled = True
    '    End If
    '    txtTarifa.Enabled = True
    '    cmbAsigRegionAltaVeh.Enabled = True
    '    ddlTipoCompra.Enabled = False
    '    ddlNivelGasolina.Enabled = True
    '    ddlTipoVehiculo.Enabled = False
    '    calFechaCompra.Enabled = False
    '    calPrimerDiaFlota.Enabled = False
    '    chkAireAcondicionado.Enabled = True
    '    chkEncendedor.Enabled = True
    '    chkExtintor.Enabled = True
    '    chkGato.Enabled = True
    '    chkHerramientas.Enabled = True
    '    chkLlantaRefaccion.Enabled = True
    '    chkLlaves.Enabled = True
    '    chkManualConductor.Enabled = True
    '    chkRadio.Enabled = True
    '    chkReflejantes.Enabled = True
    '    radTransmision.Enabled = True
    '    'Isra
    '    If txtCostoInicialOtros.Text.Trim() <> 0 Then
    '        Label30.Visible = True
    '        txtDescrCostos.Visible = True
    '        txtDescrCostos.Enabled = False
    '    End If
    '    '
    '    btnGuardar.Visible = True
    '    btnCancelar.Visible = True

    '    btnInciso.Enabled = False
    'End Sub

    'Private Sub AgregarRegistro()
    '    Dim vehiculo As CVehiculo

    '    ' Valida los datos
    '    If Not ValidarDatos() Then Exit Sub

    '    'Se crea la poliza
    '    vehiculo = CrearVehiculo()


    '    'Se manda llamar el ws
    '    respVehiculos = servVehiculos.Insertar_Vehiculos(Session("IdUsuario"), vehiculo)

    '    If respVehiculos.Estatus = Estatus.Exito Then
    '        'Carga el MVA recien agregado para mostrarlo y llevarlo como Session("IdVehiculo")
    '        Dim veh As New CVehiculo

    '        veh.Placas = txtPlacas.Text.Trim

    '        respVehiculos = servVehiculos.Buscar_MVA(Session("IdUsuario"), veh)

    '        Dim row As DataRow = respVehiculos.DataTable.Rows(0)

    '        txtMVA.Text = row("MVA")
    '        txtHidIdEstatus.Text = row("Estatus")
    '        Session("IdVehiculo") = txtMVA.Text
    '        Session("Estatus") = txtHidIdEstatus.Text

    '        win.Alert("Vehículo Guardado con Éxito. Con el MVA:" & " " & Session("IdVehiculo") & " " & "Prosiga con Asignar una Region al Vehículo", "Ir_a_Asignacion")

    '        EnviarAlarma_KmRecorridos(vehiculo.Kilometraje)

    '    Else
    '        ' En caso de error, lo muestra en pantalla
    '        win.Alert_Error(respVehiculos.ErrorDesc)
    '    End If

    'End Sub

    'Protected Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
    '    Regresar_a_Busqueda()
    'End Sub

    'Private Sub Regresar_a_Busqueda()
    '    Session("IdAccion") = 0 ' Consulta
    '    Session("OrigenSeguro") = True
    '    Response.Redirect("Vehiculos_Busqueda.aspx")
    'End Sub

    'Private Sub Ir_a_Asignacion()
    '    Session("IdAccion") = 7 ' Asignación
    '    Session("OrigenSeguro") = True
    '    Response.Redirect("Vehiculos_Movimientos.aspx")
    'End Sub

    'Protected Sub btnImagenes_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnImagenes.Click
    '    Dim img As New Imagenes
    '    img.Expediente = txtMVA.Text
    '    img.TipoImagen = EnumTiposImagenes.Vehiculos
    '    Session("ObjImagenes") = img
    '    Session("OrigenSeguro") = True
    '    win.Abrir_winImagenes()
    'End Sub

    'Protected Sub btnInciso_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnInciso.Click
    '    ' Se va a ver los datos de la póliza. Deja de se vehículos
    '    Session("OrigenSeguro") = True
    '    seccionDatos.LimpiarSeleccion(Session)
    '    seccionDatos.PrepararTexto_Poliza(Session, hidNumPoliza.Value)
    '    Session("IdPoliza") = hidIdPoliza.Value
    '    Session("IdFuncion") = 202 ' Polizas
    '    Session("IdAccion") = 0 ' Consulta
    '    Response.Redirect("Polizas_Edicion.aspx")
    'End Sub

    'Private Sub EnviarAlarma_KmRecorridos(ByVal km As Integer)
    '    ' Verifica si debe enviar la alarma
    '    If km < Parametros.getParametro(Application, EnumParametros.Kilometraje_Envio_Alerta_Avisando_KM_Recorridos_Auto) Then Exit Sub

    '    ' Envia la alarma
    '    Dim alarmas As New EnviadorAlarmas
    '    alarmas.EnviarAlarmaInmediata(EnumTiposAlarmas.Vehiculo_N_Kilometros_Recorridos, Application, Session("IdVehiculo"))
    'End Sub
End Class
