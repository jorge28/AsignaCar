Imports Telerik.Web.UI

Partial Class MasterServicio
    Inherits System.Web.UI.MasterPage

    Dim seccionDatos As New SeccionDatos
    Protected Sub PrepararMenu()
        ' Carga el sub menú
        Dim objMenu As CMenu
        Dim objPermisos As Permisos

        ' Construye el menú
        objPermisos = Session("Permisos")
        objMenu = Session("Menu")

        'objMenu.PreparaMenu(MenuIzq, objPermisos, Session)
        objMenu.PreparaMenuNormal(RadMenuServicios, objPermisos, Session)
        If Session("Padre") <> 0 Then
            'objMenu.PreparaSubMenuNormal(RadMenu2, objPermisos, Session)
            objMenu.PreparaMenu2(RadMenuMasterServicio, objPermisos, Session)
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Session("online") = True

        'txtIdVehiculo.Text = Session("IdVehiculo")
        'txtIdPropietario.Text = Session("IdPropietario")
        'txtTipoVehiculo.Text = Session("IdTipoVehiculo")

        If Not Page.IsPostBack Then
            If IO.Path.GetFileName(Request.RawUrl) <> "CambioPassword.aspx" Then
                ' Se verifica que la contraseña no haya caducado    
                If Session("CaducidadPassword") <= 0 Then
                    ' Si ya caducó, lo manda a que la cambie
                    RadWindowManager.RadAlert("Su contraseña ha caducado y debe cambiarla.", 400, 200, "AutoSigue", "ForzarCambioPassword")
                ElseIf Session("CaducidadPassword") <= 5 Then
                    ' aun no caduca solo le pregunta si la quiere cambiar
                    RadWindowManager.RadConfirm("Su contraseña caduca en " & Session("CaducidadPassword") & " dias. ¿Desea cambiarla ahora?", "confirmCallBack_CambiarPassword", 400, 200, Nothing, "AutoSigue")
                    Session("CaducidadPassword") = 100 ' ==> Esto es para que no le este diciendo a cada rato que debe cambiar la contraseña
                End If
            End If

            ' Muestra el nombre del usuario
            lblNombreUsuario.Text = Session("NombreUsuario")
            'lblPuesto.Text = Session("PuestoUsuario")

            ' Prepara el submenu
            PrepararMenu()

            ' Campos de búsqueda dependiendo del módulo en el que se encuentra
            PrepararCamposBusqueda()

            ' Prepara el titulo
            PrepararTitulo()
            Session("OrigenSeguro") = True

        End If

        If Page.IsPostBack Then
            ' El usuario eligió que si quiere cambiar su password de una vez
            If Request.Form("__EventTarget") = "CambiarPassword" Then
                Response.Redirect("~/ControlAcceso/CambioPassword.aspx")
            End If
        End If
    End Sub

    Private Sub PrepararTitulo()
        'seccionDatos.ActualizarSeccion(Me, Session)
        lblTitulo.Text = "<font color='maroon'>" & Session("Titulo_MenuPrincipal") & "</font>" & Session("Titulo")
    End Sub

    Protected Sub btnSalir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Dim userId As String = Session("IdUsuario")

        'Genera un arreglo con los id de los usuarios en session
        Try
            Application.Lock()

            ' Separa la lista en un arreglo
            Dim ArregloID() As String = Application("usuarios").ToString().Split({"|"}, StringSplitOptions.RemoveEmptyEntries)

            Application("usuarios") = "|"

            For Each id As String In ArregloID
                If id <> userId Then
                    Application("usuarios") = Application("usuarios") & id & "|"
                End If
            Next

        Catch ex As Exception
        Finally
            Application.UnLock()
        End Try

        ' Termina la sesión
        Session("IdUsuario") = Nothing
        FormsAuthentication.SignOut()
        Response.Redirect("~/General/Inicio.aspx")
    End Sub
    'Protected Sub MenuSuperior_MenuItemClick(sender As Object, e As System.Web.UI.WebControls.MenuEventArgs)
    '    Try ''jrad abril 2013
    '        Session("Titulo_MenuPrincipal") = e.Item.Parent.Text & " - " & e.Item.Text
    '    Catch ex As Exception
    '        Session("Titulo_MenuPrincipal") = ""
    '    End Try

    '    If Session("IdFuncion") <> e.Item.Value Then
    '        seccionDatos.LimpiarTexto(Session)
    '        seccionDatos.LimpiarSeleccion(Session)
    '        Session("Titulo") = ""
    '    End If

    '    ' Toma el id de la función del menú a la que ingresó el usuario
    '    Session("IdFuncion") = e.Item.Value
    '    Session("IdAccion") = 0 ' Consulta

    '    Session("OrigenSeguro") = True
    '    Select Case e.Item.Value
    '        Case 103 ' Cambio de password
    '            Response.Redirect("~/ControlAcceso/CambioPassword.aspx")
    '        Case 104 ' Alarmas
    '            Session("IdAccion") = 207 ' Configuración
    '            Response.Redirect("~/Catalogos/Alarmas.aspx")
    '        Case 105 ' Parametros
    '            Session("IdAccion") = 207 ' Configuración 
    '            Response.Redirect("~/Catalogos/Parametros.aspx")
    '        Case 201 ' Vehiculos
    '            Response.Redirect("~/ControlVehicular/Vehiculos_Busqueda.aspx")
    '        Case 202 ' Polizas
    '            Response.Redirect("~/ControlVehicular/Polizas_Busqueda.aspx")
    '        Case 204 ' Siniestros
    '            Response.Redirect("~/ControlVehicular/Siniestros_Busqueda.aspx")
    '        Case 203 ' Movimientos
    '            Session("IdAccion") = 7 ' Asignacion
    '            Response.Redirect("~/ControlVehicular/Vehiculos_Busqueda.aspx")
    '        Case 205 ' Mantenimientos
    '            Response.Redirect("~/ControlVehicular/Mantenimientos_Busqueda.aspx")
    '        Case 106 ' Proveedores
    '            Session("IdAccion") = 100 ' Edicion
    '            Response.Redirect("~/Catalogos/Proveedores_Busqueda.aspx")
    '        Case 401 ' Servicios
    '            Response.Redirect("~/CheckIn/Servicios_Busqueda.aspx")
    '        Case 402 ' Contratos
    '            Response.Redirect("~/CheckIn/Contratos_Busqueda.aspx")
    '        Case 403 ' Salidas Improductivas
    '            Response.Redirect("~/CheckIn/SalidasImproductivas_Busqueda.aspx")
    '        Case 501 ' Salidas Improductivas - CheckOut
    '            Response.Redirect("~/CheckOut/SalidasImproductivas_Busqueda.aspx")
    '        Case 502 ' Servicios - CheckOut
    '            Session("IdAccion") = 57 ' Encuesta de Satisfaccion
    '            Response.Redirect("~/CheckOut/Servicios_Busqueda.aspx")
    '        Case 503 ' Contratos - CheckOut
    '            Response.Redirect("~/CheckOut/Contratos_Busqueda.aspx")
    '        Case 4 ' reportes jrad marzo 2013

    '            Response.Redirect("~/Reportes/Menu.aspx")
    '        Case Else
    '            Response.Redirect("~/General/Inicio.aspx")
    '    End Select
    'End Sub

    'Protected Sub btnSeleccionar_Click(sender As Object, e As System.EventArgs)
    '    Session("OrigenSeguro") = True
    '    seccionDatos.LimpiarSeleccion(Session)
    '    seccionDatos.LimpiarTexto(Session)

    '    ' Redirecciona a otra página
    '    Select Case Session("IdFuncion")
    '        Case 201 ' Vehiculos
    '            Response.Redirect("~/ControlVehicular/Vehiculos_Busqueda.aspx")

    '        Case 202 ' Polizas
    '            Response.Redirect("~/ControlVehicular/Polizas_Busqueda.aspx")

    '        Case 203 ' Movimientos
    '            Response.Redirect("~/ControlVehicular/Vehiculos_Busqueda.aspx")

    '        Case 204 ' Siniestros
    '            If Session("IdAccion") = 1 Then 'Alta
    '                Response.Redirect("~/ControlVehicular/Vehiculos_Busqueda.aspx")
    '            Else
    '                Response.Redirect("~/ControlVehicular/Siniestros_Busqueda.aspx")
    '            End If

    '        Case 205 ' Mantenimientos
    '            If Session("IdAccion") = 11 Then 'Programacion
    '                Response.Redirect("~/ControlVehicular/Vehiculos_Busqueda.aspx")
    '            Else
    '                Response.Redirect("~/ControlVehicular/Mantenimientos_Busqueda.aspx")
    '            End If

    '        Case 106 ' Proveedores
    '            Response.Redirect("~/Catalogos/Proveedores_Busqueda.aspx")

    '        Case 401 ' Servicios - Check In
    '            Response.Redirect("~/CheckIn/Servicios_Busqueda.aspx")

    '        Case 402 ' Contratos - Check In
    '            Response.Redirect("~/CheckIn/Contratos_Busqueda.aspx")

    '        Case 403 ' Salidas Improductivas - Check In
    '            If Session("IdAccion") = 1 Then 'Alta
    '                Response.Redirect("~/ControlVehicular/Vehiculos_Busqueda.aspx")
    '            Else
    '                Response.Redirect("~/CheckIn/SalidasImproductivas_Busqueda.aspx")
    '            End If

    '        Case 501 ' Salidas Improductivas  - Checkout
    '            Response.Redirect("~/CheckOut/SalidasImproductivas_Busqueda.aspx")

    '        Case 502 ' Servicios  - Checkout
    '            If Session("IdAccion") = 60 Then 'Terminación de Reembolso
    '                Response.Redirect("~/CheckOut/Reembolsos_Busqueda.aspx")
    '            Else ' Cierre, Reembolso, Facturación, Encuesta de satisfacción
    '                Response.Redirect("~/CheckOut/Servicios_Busqueda.aspx")
    '            End If

    '        Case 503 ' Contratos  - Checkout
    '            Response.Redirect("~/CheckOut/Contratos_Busqueda.aspx")

    '        Case 102 ' Control de Acceso
    '            If Session("IdAccion") = 51 Then
    '                Response.Redirect("~/ControlAcceso/Grupos.aspx")
    '            ElseIf Session("IdAccion") = 52 Then
    '                Response.Redirect("~/ControlAcceso/Perfiles.aspx")
    '            End If
    '    End Select
    'End Sub

    'Protected Sub btnMenu_Click(sender As Object, e As System.EventArgs)
    '    Session("IdAccion") = CType(sender, ImageButton).CommandName ' Opción del submenú a la que se ingresó
    '    Session("OrigenSeguro") = True

    '    Select Case Session("IdFuncion")
    '        Case 201 ' Vehiculos
    '            Select Case Session("IdAccion")
    '                Case 1 'Alta
    '                    seccionDatos.LimpiarSeleccion(Session)
    '                    seccionDatos.LimpiarTexto(Session)
    '                    Response.Redirect("~/ControlVehicular/Vehiculos_Edicion.aspx")
    '                Case 61 'Autorizar Gastos
    '                    seccionDatos.LimpiarSeleccion(Session)
    '                    seccionDatos.LimpiarTexto(Session)
    '                    Response.Redirect("~/ControlVehicular/Vehiculos_Gastos_Autorizacion.aspx")
    '                Case Else
    '                    If Session("IdVehiculo") = -1 Then
    '                        seccionDatos.LimpiarSeleccion(Session)
    '                        seccionDatos.LimpiarTexto(Session)
    '                        Response.Redirect("~/ControlVehicular/Vehiculos_Busqueda.aspx")
    '                    Else
    '                        Select Case Session("IdAccion")
    '                            Case 0, 2, 3 ' Consulta, Modificacion, Baja
    '                                Response.Redirect("~/ControlVehicular/Vehiculos_Edicion.aspx")
    '                            Case 4 ' Documentos
    '                                Response.Redirect("~/ControlVehicular/Vehiculos_Documentos.aspx")
    '                            Case 6 ' Gastos
    '                                Response.Redirect("~/ControlVehicular/Vehiculos_Gastos.aspx")
    '                        End Select
    '                    End If
    '            End Select

    '        Case 202 ' Polizas
    '            Select Case Session("IdAccion")
    '                Case 1 ' Alta
    '                    seccionDatos.LimpiarSeleccion(Session)
    '                    seccionDatos.LimpiarTexto(Session)
    '                    Response.Redirect("~/ControlVehicular/Polizas_Edicion.aspx")
    '                Case 0, 2, 3, 53 ' Consulta, Modificacion, Baja, Sustitución
    '                    If Session("IdPoliza") = -1 Then
    '                        seccionDatos.LimpiarSeleccion(Session)
    '                        seccionDatos.LimpiarTexto(Session)
    '                        Response.Redirect("~/ControlVehicular/Polizas_Busqueda.aspx")
    '                    Else
    '                        Response.Redirect("~/ControlVehicular/Polizas_Edicion.aspx")
    '                    End If
    '            End Select

    '        Case 203 ' Movimientos
    '            seccionDatos.LimpiarSeleccion(Session)
    '            seccionDatos.LimpiarTexto(Session)
    '            Response.Redirect("~/ControlVehicular/Vehiculos_Busqueda.aspx")

    '        Case 204 ' Siniestros
    '            Select Case Session("IdAccion")
    '                Case 1 ' Alta
    '                    If Session("IdVehiculo") = -1 Then
    '                        seccionDatos.LimpiarSeleccion(Session)
    '                        seccionDatos.LimpiarTexto(Session)
    '                        Response.Redirect("~/ControlVehicular/Vehiculos_Busqueda.aspx")
    '                    Else
    '                        Session("Texto_Seleccion3") = ""
    '                        Session("ConsecSiniestro") = -1
    '                        Response.Redirect("~/ControlVehicular/Siniestros_Edicion.aspx")
    '                    End If
    '                Case 62 'Autorizar Cancelaciones
    '                    seccionDatos.LimpiarSeleccion(Session)
    '                    seccionDatos.LimpiarTexto(Session)
    '                    Response.Redirect("~/ControlVehicular/Siniestros_Cancelacion_Autorizacion.aspx")
    '                Case 0, 2, 5 ' Consulta, Modificacion, Cancelacion
    '                    If Session("IdVehiculo") = -1 Or Session("ConsecSiniestro") = -1 Then
    '                        seccionDatos.LimpiarSeleccion(Session)
    '                        seccionDatos.LimpiarTexto(Session)
    '                        Response.Redirect("~/ControlVehicular/Siniestros_Busqueda.aspx")
    '                    Else
    '                        Response.Redirect("~/ControlVehicular/Siniestros_Edicion.aspx")
    '                    End If
    '            End Select

    '        Case 205 ' Mantenimientos
    '            Select Case Session("IdAccion")
    '                Case 11 ' Programar
    '                    If Session("IdVehiculo") = -1 Then
    '                        seccionDatos.LimpiarSeleccion(Session)
    '                        seccionDatos.LimpiarTexto(Session)
    '                        Response.Redirect("~/ControlVehicular/Vehiculos_Busqueda.aspx")
    '                    Else
    '                        Session("Texto_Seleccion3") = ""
    '                        Session("ConsecMantenimiento") = -1
    '                        Response.Redirect("~/ControlVehicular/Mantenimientos_Edicion.aspx")
    '                    End If
    '                Case 0, 2 ' Consulta, Modificacion
    '                    If Session("IdVehiculo") = -1 Or Session("ConsecMantenimiento") = -1 Then
    '                        seccionDatos.LimpiarSeleccion(Session)
    '                        seccionDatos.LimpiarTexto(Session)
    '                        Response.Redirect("~/ControlVehicular/Mantenimientos_Busqueda.aspx")
    '                    Else
    '                        Response.Redirect("~/ControlVehicular/Mantenimientos_Edicion.aspx")
    '                    End If
    '                Case 54 ' Autorizaciones
    '                    seccionDatos.LimpiarSeleccion(Session)
    '                    seccionDatos.LimpiarTexto(Session)
    '                    Response.Redirect("~/ControlVehicular/Mantenimientos_Autorizacion.aspx")
    '            End Select

    '        Case 101 ' Catálogos
    '            Select Case Session("IdAccion")
    '                Case 200 ' Marcas
    '                    Response.Redirect("~/Catalogos/Marcas.aspx")
    '                Case 201 ' Submarcas
    '                    Response.Redirect("~/Catalogos/Submarcas.aspx")
    '                Case 203 ' Regiones
    '                    Response.Redirect("~/Catalogos/Regiones.aspx")
    '                Case 204 ' Coordinaciones
    '                    Response.Redirect("~/Catalogos/Coordinaciones.aspx")
    '                Case 205 ' Almacenes
    '                    Response.Redirect("~/Catalogos/Almacenes.aspx")
    '                Case 206 ' Conductores
    '                    Response.Redirect("~/Catalogos/Conductores.aspx")
    '                Case 207 ' Parámetros
    '                    Response.Redirect("~/Catalogos/Parametros.aspx")
    '                Case 208 ' Aseguradoras
    '                    Response.Redirect("~/Catalogos/Aseguradoras.aspx")
    '                Case 209 ' Eventos
    '                    Response.Redirect("~/Catalogos/Eventos.aspx")
    '                Case 211 ' bancos
    '                    Response.Redirect("~/Catalogos/bancos.aspx")
    '                Case 212 'Aseguradoras Poliza
    '                    Response.Redirect("~/Catalogos/Aseguradoras_Polizas.aspx")
    '            End Select

    '        Case 102 ' Control de Acceso
    '            Select Case Session("IdAccion")
    '                Case 50 ' Usuarios
    '                    Response.Redirect("~/ControlAcceso/Usuarios.aspx")
    '                Case 51 ' Grupos de Usuarios
    '                    Response.Redirect("~/ControlAcceso/Grupos.aspx")
    '                Case 52 ' Perfiles
    '                    Response.Redirect("~/ControlAcceso/Perfiles.aspx")
    '            End Select

    '        Case 104 ' Alarmas
    '            Select Case Session("IdAccion")
    '                Case 207 ' Configuracion 
    '                    Response.Redirect("~/Catalogos/Alarmas.aspx")
    '            End Select

    '        Case 105 ' Parametros
    '            Select Case Session("IdAccion")
    '                Case 207 ' Configuracion 
    '                    Response.Redirect("~/Catalogos/Parametros.aspx")
    '            End Select

    '        Case 106 'Proveedores
    '            If Session("IdProveedor") = -1 Then
    '                seccionDatos.LimpiarTexto(Session)
    '                Response.Redirect("~/Catalogos/Proveedores_Busqueda.aspx")
    '            Else
    '                Select Case Session("IdAccion")
    '                    Case 100 ' Edicion
    '                        Response.Redirect("~/Catalogos/Proveedores_Edicion.aspx")
    '                    Case 101 ' Lista de Precios
    '                        Response.Redirect("~/Catalogos/Proveedores_Precios.aspx")
    '                End Select
    '            End If

    '        Case 401 ' Servicios - Check In
    '            Select Case Session("IdAccion")
    '                Case 1 'Alta
    '                    seccionDatos.LimpiarSeleccion(Session)
    '                    seccionDatos.LimpiarTexto(Session)
    '                    Response.Redirect("~/CheckIn/Servicios_Edicion.aspx")
    '                Case Else
    '                    If Session("IdServicio") = -1 Then
    '                        seccionDatos.LimpiarSeleccion(Session)
    '                        seccionDatos.LimpiarTexto(Session)
    '                        Response.Redirect("~/CheckIn/Servicios_Busqueda.aspx")
    '                    Else
    '                        Select Case Session("IdAccion")
    '                            Case 5
    '                                Response.Redirect("~/CheckIn/Busqueda_Carpix.aspx")
    '                            Case 0, 2, 13 ' Consulta, Modificacion, Cancelacion, Reactivacion
    '                                Response.Redirect("~/CheckIn/Servicios_Edicion.aspx")
    '                            Case 12 ' Bitacora
    '                                Response.Redirect("~/CheckIn/Servicios_Bitacora.aspx")
    '                        End Select
    '                    End If
    '            End Select
    '        Case 402 ' Contratos - Check In
    '            Select Case Session("IdAccion")
    '                Case 1 'Alta
    '                    seccionDatos.LimpiarSeleccion(Session)
    '                    seccionDatos.LimpiarTexto(Session)
    '                    Response.Redirect("~/CheckIn/Contratos_Edicion.aspx")
    '                Case Else
    '                    If Session("IdContrato") = -1 Then
    '                        seccionDatos.LimpiarSeleccion(Session)
    '                        seccionDatos.LimpiarTexto(Session)
    '                        Response.Redirect("~/CheckIn/Contratos_Busqueda.aspx")
    '                    Else
    '                        Select Case Session("IdAccion")
    '                            Case 0 ' Consulta
    '                                Response.Redirect("~/CheckIn/Contratos_Edicion.aspx")
    '                            Case 14 ' Cambio de Auto
    '                                Response.Redirect("~/CheckIn/Contratos_Cambio_Auto.aspx")
    '                            Case 12 ' Bitácora
    '                                Response.Redirect("~/CheckIn/Contratos_Bitacora.aspx")
    '                        End Select
    '                    End If
    '            End Select

    '        Case 403 ' Salidas Improductivas - Check In
    '            Select Case Session("IdAccion")
    '                Case 1 ' Alta
    '                    If Session("IdVehiculo") = -1 Then
    '                        seccionDatos.LimpiarSeleccion(Session)
    '                        seccionDatos.LimpiarTexto(Session)
    '                        Response.Redirect("~/ControlVehicular/Vehiculos_Busqueda.aspx")
    '                    Else
    '                        Session("Texto_Seleccion3") = ""
    '                        Session("ConsecSalidaImproductiva") = -1
    '                        Response.Redirect("~/CheckIn/SalidasImproductivas_Edicion.aspx")
    '                    End If
    '                Case 0 ' Consulta
    '                    If Session("IdVehiculo") = -1 Or Session("ConsecSalidaImproductiva") = -1 Then
    '                        seccionDatos.LimpiarSeleccion(Session)
    '                        seccionDatos.LimpiarTexto(Session)
    '                        Response.Redirect("~/CheckIn/SalidasImproductivas_Busqueda.aspx")
    '                    Else
    '                        Response.Redirect("~/CheckIn/SalidasImproductivas_Edicion.aspx")
    '                    End If
    '            End Select

    '        Case 501 ' Salidas Improductivas - CheckOut
    '            Select Case Session("IdAccion")
    '                Case 0 ' Consulta
    '                    If Session("IdVehiculo") = -1 Or Session("ConsecSalidaImproductiva") = -1 Then
    '                        seccionDatos.LimpiarSeleccion(Session)
    '                        seccionDatos.LimpiarTexto(Session)
    '                        Response.Redirect("~/CheckOut/SalidasImproductivas_Busqueda.aspx")
    '                    Else
    '                        Response.Redirect("~/CheckOut/SalidasImproductivas_Edicion.aspx")
    '                    End If
    '                Case 55 ' Cierre
    '                    If Session("IdVehiculo") = -1 Or Session("ConsecSalidaImproductiva") = -1 Then
    '                        seccionDatos.LimpiarSeleccion(Session)
    '                        seccionDatos.LimpiarTexto(Session)
    '                        Response.Redirect("~/CheckOut/SalidasImproductivas_Busqueda.aspx")
    '                    Else
    '                        Response.Redirect("~/CheckOut/SalidasImproductivas_Cierre.aspx")
    '                    End If
    '            End Select

    '        Case 502 ' Servicios - CheckOut
    '            Select Case Session("IdAccion")
    '                Case 57 ' Encuesta de satisfacción
    '                    seccionDatos.LimpiarSeleccion(Session)
    '                    seccionDatos.LimpiarTexto(Session)
    '                    Response.Redirect("~/CheckOut/Servicios_Busqueda.aspx")

    '                Case 58 ' Facturacion
    '                    seccionDatos.LimpiarSeleccion(Session)
    '                    seccionDatos.LimpiarTexto(Session)
    '                    Response.Redirect("~/CheckOut/Servicios_Busqueda.aspx")

    '                Case 59 ' Reembolsos 
    '                    seccionDatos.LimpiarSeleccion(Session)
    '                    seccionDatos.LimpiarTexto(Session)
    '                    Response.Redirect("~/CheckOut/Servicios_Busqueda.aspx")

    '                Case 60 ' Autorizacion de Reembolsos
    '                    seccionDatos.LimpiarSeleccion(Session)
    '                    seccionDatos.LimpiarTexto(Session)
    '                    Response.Redirect("~/CheckOut/Reembolsos_Busqueda.aspx")
    '                Case 63 ' Pagos Jrad 5-marzo-2013
    '                    seccionDatos.LimpiarSeleccion(Session)
    '                    seccionDatos.LimpiarTexto(Session)
    '                    'Response.Redirect("~/CheckOut/Servicios_Busqueda.aspx")
    '                    Response.Redirect("~/CheckOut/Pagos.aspx")
    '                Case 64 ' Transferancias de Reembolsos Jrad 5-marzo-2013
    '                    seccionDatos.LimpiarSeleccion(Session)
    '                    seccionDatos.LimpiarTexto(Session)
    '                    Response.Redirect("~/CheckOut/Reembolsos_Busqueda.aspx")
    '            End Select

    '        Case 503 ' Contratos- CheckOut
    '            Select Case Session("IdAccion")
    '                Case 0 ' Consulta
    '                    If Session("IdContrato") = -1 Then
    '                        seccionDatos.LimpiarSeleccion(Session)
    '                        seccionDatos.LimpiarTexto(Session)
    '                        Response.Redirect("~/CheckOut/Contratos_Busqueda.aspx")
    '                    Else
    '                        Response.Redirect("~/CheckOut/Contratos_Edicion.aspx")
    '                    End If
    '                Case 55 ' Cierre
    '                    seccionDatos.LimpiarSeleccion(Session)
    '                    seccionDatos.LimpiarTexto(Session)
    '                    Response.Redirect("~/CheckOut/Contratos_Busqueda.aspx")
    '                Case 56 ' Extensión
    '                    seccionDatos.LimpiarSeleccion(Session)
    '                    seccionDatos.LimpiarTexto(Session)
    '                    Response.Redirect("~/CheckOut/Contratos_Busqueda.aspx")
    '                Case 65 'Autorizar Extensión
    '                    seccionDatos.LimpiarSeleccion(Session)
    '                    seccionDatos.LimpiarTexto(Session)
    '                    Response.Redirect("~/CheckOut/Contratos_Busqueda.aspx")
    '                Case 66 'Busqueda Extension
    '                    seccionDatos.LimpiarSeleccion(Session)
    '                    seccionDatos.LimpiarTexto(Session)
    '                    Response.Redirect("~/CheckOut/Extension_Busqueda.aspx")
    '            End Select

    '    End Select

    'End Sub
    'Protected Sub MenuIzq_NodeClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadTreeNodeEventArgs) Handles MenuIzq.NodeClick
    '    ' Toma la acción, la función y/o el módulo
    '    If e.Node.ParentNode Is Nothing Then
    '        ' es un módulo
    '        Session("DatosElemento") = ""
    '        Session("IdFuncion") = CShort(e.Node.Nodes(0).Value)
    '        Session("IdModulo") = CShort(e.Node.Value) ' Función a la que ingresó (Control vehicular, Check In, Check Out, etc.)
    '        'Session("Titulo_MenuPrincipal") = e.Node.Text
    '        Select Case Session("IdModulo")
    '            Case 1, 2
    '                Session("IdAccion") = 0 ' Consulta
    '            Case 3
    '                Session("IdAccion") = 57 ' encuesta de satisfacción
    '            Case Else
    '                Session("IdAccion") = -1 ' nada
    '        End Select
    '    Else
    '        If e.Node.ParentNode.ParentNode Is Nothing Then
    '            ' es una funcion
    '            Session("IdFuncion") = CShort(e.Node.Value)
    '            Session("IdModulo") = CShort(e.Node.ParentNode.Value) ' Función a la que ingresó (Control vehicular, Check In, Check Out, etc.)
    '            'Session("Titulo_MenuPrincipal") = e.Node.ParentNode.Text

    '            Select Case Session("IdModulo")
    '                Case 1, 2
    '                    If Session("IdFuncion") = 404 Then
    '                        Session("IdAccion") = -1 ' nada
    '                    Else
    '                        Session("IdAccion") = 0 ' Consulta
    '                    End If
    '                Case 3
    '                    Session("IdAccion") = 57 ' encuesta de satisfacción
    '                Case Else
    '                    Session("IdAccion") = -1 ' nada
    '            End Select
    '        Else
    '            ' es una acción
    '            Session("IdAccion") = CShort(e.Node.Value)
    '            Session("IdFuncion") = CShort(e.Node.ParentNode.Value)
    '            Session("IdModulo") = CShort(e.Node.ParentNode.ParentNode.Value) ' Función a la que ingresó (Control vehicular, Check In, Check Out, etc.)
    '            'Session("Titulo_MenuPrincipal") = e.Node.ParentNode.ParentNode.Text
    '        End If
    '    End If

    '    ' Se va a la siguiente página
    '    Navegar_Destino()

    'End Sub
    Protected Sub MenuIzq_NodeClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadTreeNodeEventArgs) Handles MenuIzq.NodeClick
        ' Toma la acción, la función y/o el módulo
        If e.Node.ParentNode Is Nothing Then
            ' es un módulo
            Session("DatosElemento") = ""
            Session("IdFuncion") = CShort(e.Node.Nodes(0).Value)
            Session("IdModulo") = CShort(e.Node.Value) ' Función a la que ingresó (Control vehicular, Check In, Check Out, etc.)
            'Session("Titulo_MenuPrincipal") = e.Node.Text
            Select Case Session("IdModulo")
                Case 1, 2
                    Session("IdAccion") = 0 ' Consulta
                Case 3
                    Session("IdAccion") = 57 ' encuesta de satisfacción
                Case Else
                    Session("IdAccion") = -1 ' nada
            End Select
        Else
            If e.Node.ParentNode.ParentNode Is Nothing Then
                ' es una funcion
                Session("IdFuncion") = CShort(e.Node.Value)
                Session("IdModulo") = CShort(e.Node.ParentNode.Value) ' Función a la que ingresó (Control vehicular, Check In, Check Out, etc.)
                'Session("Titulo_MenuPrincipal") = e.Node.ParentNode.Text

                Select Case Session("IdModulo")
                    Case 1, 2
                        If Session("IdFuncion") = 404 Then
                            Session("IdAccion") = -1 ' nada
                        Else
                            Session("IdAccion") = 0 ' Consulta
                        End If
                    Case 3
                        Session("IdAccion") = 57 ' encuesta de satisfacción
                    Case Else
                        Session("IdAccion") = -1 ' nada
                End Select
            Else
                ' es una acción
                Session("IdAccion") = CShort(e.Node.Value)
                Session("IdFuncion") = CShort(e.Node.ParentNode.Value)
                Session("IdModulo") = CShort(e.Node.ParentNode.ParentNode.Value) ' Función a la que ingresó (Control vehicular, Check In, Check Out, etc.)
                'Session("Titulo_MenuPrincipal") = e.Node.ParentNode.ParentNode.Text
            End If
        End If

        ' Se va a la siguiente página
        Navegar_Destino()

    End Sub

    Private Sub Navegar_Destino()
        Dim url As String
        Dim objMenu As CMenu

        ' se prepara para abandonar la página
        objMenu = Session("Menu")
        url = objMenu.ObtenerUrl(Session("IdFuncion"), Session("IdAccion"))
        If url <> "" Then
            Session("OrigenSeguro") = True
            Response.Redirect(url)
        End If
    End Sub

    Private Sub PrepararCamposBusqueda()

        ' Muestra y oculta los campos de búsqueda
        Select Case Session("IdModulo")
            Case 1 ' Control vehicular

                'Rafael
                'lblBusqueda1.Text = "MVA:"
                'lblBusqueda1.Visible = True
                'txtBusqueda1.Visible = True
                ' Fin Rafael

                'lblBusqueda2.Visible = False
                'txtBusqueda2.Visible = False

                'txtBusqueda1.Text = ""
                'txtBusqueda2.Text = ""

                'Rafael
                'btnBuscar.Visible = True
                'Fin Rafael

                'Rafael
                'Session("IdContrato") = -1

                If Session("IdContrato") = 0 Then
                    Session("IdContrato") = -1
                End If

                If Session("IdServicio") = 0 Then
                    Session("IdServicio") = -1
                End If


            Case 2, 3 ' Check In y Check Out
                'Rafael
                'lblBusqueda1.Text = "Servicio:"

                'txtBusqueda1.Text = ""
                'txtBusqueda2.Text = ""

                'lblBusqueda2.Visible = True
                'txtBusqueda2.Visible = True
                ''Rafael
                ''lblBusqueda1.Visible = True
                'txtBusqueda1.Visible = True

                'btnBuscar.Visible = True

                'Rafael
                ' Session("IdVehiculo") = -1


            Case 4, 5 ' Reportes, administración
                'txtBusqueda1.Text = ""
                'txtBusqueda2.Text = ""

                'lblBusqueda2.Visible = False
                'txtBusqueda2.Visible = False
                ''Rafael
                ''lblBusqueda1.Visible = False
                'txtBusqueda1.Visible = False

                'btnBuscar.Visible = 

                'Rafael
                ' Session("IdContrato") = -1
                If Session("IdContrato") = 0 Then
                    Session("IdContrato") = -1
                End If

                'Session("IdServicio") = -1

                If Session("IdServicio") = 0 Then
                    Session("IdServicio") = -1
                End If

                'Session("IdVehiculo") = -1
                If Session("IdVehiculo") = 0 Then
                    Session("IdVehiculo") = -1
                End If

        End Select
    End Sub
    'Protected Sub btnBuscar_Click(sender As Object, e As System.EventArgs) Handles btnBuscar.Click
    '    Dim serv As New Datos_General
    '    Dim resp As New Resultado
    '    Select Case Session("IdModulo")
    '        Case 1
    '            ' Busca por el mva del vehículo
    '            If txtBusqueda1.Text = "" Or txtBusqueda1.Text = "0" Then
    '                ConfigureNotification("AutoSigue", "Introduce el MVA Vehicular", 6000)
    '                Exit Sub
    '            End If

    '            'Consulta el vehículo
    '            resp = serv.Buscar_Vehiculo(Session("IdUsuario"), txtBusqueda1.Text)
    '            If resp.DataTable.Rows.Count = 0 Then
    '                ConfigureNotification("AutoSigue", "El MVA Vehicular No Existe", 6000)
    '                Exit Sub
    '            End If

    '            ' Toma los datos del vehículo 
    '            Session("DatosElemento") = "<b>MVA</b>: " & resp.DataTable.Rows(0)("MVA") & "<br /><b>Placas</b>: " & resp.DataTable.Rows(0)("Placas") & "<br /><b>Modelo</b>: " & resp.DataTable.Rows(0)("Modelo")
    '            Session("IdVehiculo") = resp.DataTable.Rows(0)("Id")
    '            Session("IdAccion") = 0 ' Consulta
    '            Session("IdFuncion") = 201 ' Vehiculos
    '            Navegar_Destino()

    '        Case 2, 3
    '            ' Busca por el número de servicio o por el número de contrato
    '            If txtBusqueda1.Text.Trim = "" And txtBusqueda2.Text.Trim = "" Then
    '                ConfigureNotification("AutoSigue", "Introduce el Número de Servicio o de Contrato", 6000)
    '                'RadWindowManager.RadAlert("Faltan el criterio de búsqueda.", 400, 200, "AutoSigue", "Búsqueda de Servicios y Contratos")
    '                Exit Sub
    '            End If
    '            If txtBusqueda1.Text.Trim <> "" And txtBusqueda2.Text.Trim <> "" Then
    '                ConfigureNotification("AutoSigue", "Solo se Permite un Criterio de Busqueda", 6000)
    '                'RadWindowManager.RadAlert("Solo se permite un criterio de búsqueda.", 400, 200, "AutoSigue", "Búsqueda de Servicios y Contratos")
    '                Exit Sub
    '            End If

    '            If txtBusqueda1.Text.Trim <> "" Then
    '                ' Busca por número de Servicio
    '                resp = serv.Buscar_Servicio(Session("IdUsuario"), txtBusqueda1.Text.Trim)
    '                If resp.DataTable.Rows.Count = 0 Then
    '                    ConfigureNotification("AutoSigue", "El Numero de Servicio no Existe", 6000)
    '                    'RadWindowManager.RadAlert("No se encontró el servicio buscado.", 400, 200, "AutoSigue", "Búsqueda de Servicios y Contratos")
    '                    Exit Sub
    '                End If

    '                ' Toma los datos del servicio 
    '                Session("DatosElemento") = "<b>Servicio</b>: " & resp.DataTable.Rows(0)("NumServicio") & "<br /><b>Siniestro</b>: " & resp.DataTable.Rows(0)("NumSiniestro") & "<br /><b>Fecha</b>: " & resp.DataTable.Rows(0)("FecActivacion")
    '                Session("IdServicio") = resp.DataTable.Rows(0)("Id")
    '                Session("IdAccion") = 0 ' Consulta
    '                Session("IdModulo") = 2 ' Check in
    '                Session("IdFuncion") = 401 ' Servicios Check In
    '                Session("Titulo_MenuPrincipal") = "Check In"
    '                Navegar_Destino()

    '            Else
    '                ' Busca por número de contrato
    '                resp = serv.Buscar_Contrato(Session("IdUsuario"), txtBusqueda2.Text.Trim)

    '                If resp.DataTable.Rows.Count = 0 Then
    '                    ConfigureNotification("AutoSigue", "El Numero de Contrato no Existe", 6000)
    '                    'RadWindowManager.RadAlert("No se encontró el contrato buscado.", 400, 200, "AutoSigue", "Búsqueda de Servicios y Contratos")
    '                    Exit Sub
    '                End If

    '                ' Toma los datos del contrato
    '                Session("DatosElemento") = "<b>Contrato</b>: " & resp.DataTable.Rows(0)("NumContrato") & "<br /><b>Fecha</b>: " & resp.DataTable.Rows(0)("FecContrato")
    '                Session("IdContrato") = resp.DataTable.Rows(0)("Id")
    '                Session("IdAccion") = 0 ' Consulta
    '                Session("IdModulo") = 2 ' Check in
    '                Session("IdFuncion") = 402 ' Contratos Check In
    '                Session("Titulo_MenuPrincipal") = "Check In"
    '                Navegar_Destino()
    '            End If
    '    End Select

    'End Sub
    Protected Sub ConfigureNotification(ByVal titulo As String, ByVal texto As String, Optional ByVal tiempo As Integer = 5000, Optional ByVal Ancho As Integer = 300, Optional ByVal Alto As Integer = 100)
        'String
        notificacion0.Title = titulo
        notificacion0.Text = texto
        'Enum
        notificacion0.Position = Telerik.Web.UI.NotificationPosition.Center
        notificacion0.Animation = Telerik.Web.UI.NotificationAnimation.Fade
        'notificacion.ContentScrolling = Telerik.Web.UI.NotificationScrolling.Default
        notificacion0.AutoCloseDelay = tiempo
        'Unit
        notificacion0.Width = Ancho
        notificacion0.Height = Alto
        notificacion0.OffsetX = -10
        notificacion0.OffsetY = 10

        notificacion0.Pinned = True
        notificacion0.EnableRoundedCorners = True
        notificacion0.EnableShadow = True
        notificacion0.KeepOnMouseOver = False
        notificacion0.VisibleTitlebar = True
        notificacion0.ShowCloseButton = True
        notificacion0.Show()

    End Sub
    'Protected Sub ImaControlVeh_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImaControlVeh.Click
    '    Session("Padre") = 1
    '    Session("IdFuncion") = 201
    '    Session("Titulo") = "VEHÍCULOS - Búsqueda de Vehículos para Consulta"
    '    Response.Redirect("~/ControlVehicular/Vehiculos_Busqueda.aspx")
    'End Sub

    'Protected Sub ImaCheckIn_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImaCheckIn.Click
    '    Session("Padre") = 2
    '    Session("IdAccion") = 0
    '    Session("Titulo") = "SERVICIOS - Búsqueda de Servicios para Consulta"
    '    Response.Redirect("~/CheckIn/Servicios_Busqueda.aspx")
    'End Sub

    'Protected Sub ImaCheckOut_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImaCheckOut.Click
    '    Session("Padre") = 3
    '    Session("IdAccion") = 57
    '    Session("Titulo") = "SERVICIOS - Búsqueda de Servicios para Consulta"
    '    Response.Redirect("~/CheckOut/Servicios_Busqueda.aspx")
    'End Sub

    'Protected Sub ImaAdmin_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImaAdmin.Click
    '    Session("Padre") = 5
    '    Session("IdAccion") = 57
    '    Session("Titulo") = "ADMINISTRACIÓN - Cambio de Contraseña"
    '    Response.Redirect("~/ControlAcceso/CambioPassword.aspx")
    'End Sub

    Protected Sub RadMenuMasterServicio_ItemClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadMenuEventArgs) Handles RadMenuMasterServicio.ItemClick

        Session("IdAccion") = e.Item.Attributes("IdAccion")
        Session("IdFuncion") = e.Item.Attributes("IdFuncion")
        Navegar_Destino()
    End Sub

    Protected Sub RadMenuMasterServicio_ItemCreated(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadMenuEventArgs) Handles RadMenuMasterServicio.ItemCreated
        If e.Item.NavigateUrl <> "" Then
            e.Item.Attributes("NavigateUrl") = e.Item.NavigateUrl
            'e.Item.Attributes("IdAccion") = "2" 'dr("IdAccion")
            e.Item.NavigateUrl = ""
        End If
    End Sub

    Protected Sub RadMenuServicios_ItemClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadMenuEventArgs) Handles RadMenuServicios.ItemClick
        If e.Item.Attributes("IdPadre") = 1 Then
            Session("Padre") = 1
            Session("IdFuncion") = 201
            Session("Titulo") = "VEHÍCULOS - Búsqueda de Vehículos para Consulta"
            Response.Redirect("~/General/Bitacora_General.aspx")
        End If
        If e.Item.Attributes("IdPadre") = 2 Then
            Session("Padre") = 2
            Session("IdAccion") = 0
            Session("Titulo") = "SERVICIOS - Búsqueda de Servicios para Consulta"
            Response.Redirect("~/General/Bitacora_General.aspx")
        End If
        If e.Item.Attributes("IdPadre") = 3 Then
            Session("Padre") = 3
            Session("IdAccion") = 57
            Session("Titulo") = "SERVICIOS - Búsqueda de Servicios para Consulta"
            Response.Redirect("~/General/Bitacora_General.aspx")
        End If
        If e.Item.Attributes("IdPadre") = 5 Then
            Session("Padre") = 5
            Session("IdAccion") = 57
            Session("Titulo") = "ADMINISTRACIÓN - Cambio de Contraseña"
            Response.Redirect("~/General/Bitacora_General.aspx")
        End If
    End Sub

    Protected Sub RadMenuServicios_ItemCreated(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadMenuEventArgs) Handles RadMenuServicios.ItemCreated
        If e.Item.NavigateUrl <> "" Then
            e.Item.Attributes("NavigateUrl") = e.Item.NavigateUrl
            'e.Item.Attributes("IdAccion") = "2" 'dr("IdAccion")
            e.Item.NavigateUrl = ""
        End If
    End Sub
End Class

