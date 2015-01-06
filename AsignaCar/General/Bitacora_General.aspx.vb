Imports System.Data
Imports System.Web.UI.WebControls
Imports Telerik.Web.UI

Partial Class CheckIn_Bitacora_General
    Inherits System.Web.UI.Page

    Private Enum ColGrid
        Consec = 2
        NumServicio
        Bitacora
        NombreUsuario
        Fecha
        Contrato
    End Enum
    ''' <summary>
    ''' Id del formulario
    ''' </summary>
    ''' <remarks></remarks>
    Public Const IdFuncion As Integer = 404

    Dim serv As New Datos_CheckIn
    Dim resp As Resultado

    Dim win As Ventanas
    'Isra
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

    Protected Sub btnAgregar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        'Objeto bitácora
        If txtBitacora.Text = "" Or txtBitacora.Text = "0" Then
            ConfigureNotification("AutoSigue", "Anota algún comentario para Guardarlo en la Bitácora", 3000)
            Exit Sub
        End If

        Dim BitacoraServicios As New CBitacoraServicios  'Objeto bitácora

        'Llena campos
        BitacoraServicios.Bitacora = txtBitacora.Text
        If Session("IdServicio") <> Nothing and  Session("IdUsuario") <> nothing and Session("NumServ") <> nothing Then
            BitacoraServicios.IdServicio = Session("IdServicio") 
            BitacoraServicios.IdUsuario = Session("IdUsuario")
            BitacoraServicios.NumServicio = Session("NumServ")
			
		If Session("TipoAuto") IsNot DBNull.Value Then
            If Session("TipoAuto") = "V" Then
                BitacoraServicios.IdContrato = Session("NumContrato")
            End If
            If Session("TipoAuto") = "P" Then
                BitacoraServicios.IdContrato = Session("IdContrato")
            End If
            If Session("TipoAuto") = "C" Then
                BitacoraServicios.IdContrato = Session("IdContrato")
            End If
        Else
            BitacoraServicios.IdContrato = ""
            End If

            resp = serv.Insertar_Servicios_Bitacora(Session("IdUsuario"), BitacoraServicios)

        Else
            ConfigureNotification("Atencion", "Su sesion a caducado. Favor de accesar nuevamente")
            Seguridad.QuitarUsuarioListado(Application, Session("IdUsuario"))
            Response.Redirect("~/Autenticacion/Login.aspx")
            Exit Sub
        End If
        
        'Se llama el ws
        'If Session("TipoAuto") IsNot DBNull.Value Then
        '    If Session("TipoAuto") = "V" Then
        '        resp = serv.Insertar_Contratos_Bitacora_Proveedor2(Session("IdUsuario"), BitacoraServicios)
        '    End If
        '    If Session("TipoAuto") = "P" Or Session("TipoAuto") = "C" Then
        '        resp = serv.Insertar_Contratos_Bitacora2(Session("IdUsuario"), BitacoraServicios)
        '    End If
        'Else

        'End If

        'Si Éxito
        If resp.Estatus = Estatus.Exito Then
            CargarGrid()
            ConfigureNotification("AutoSigue", "Comentario ingresado con Éxito", 3000)
            'win.Alert("Comentario Ingresado Exitosamente")
            txtBitacora.Text = ""
        Else
            ''Muestra error
            win.Alert_Error(resp.ErrorDesc)
        End If
    End Sub

    Private Sub Regresar_a_Busqueda()
        Session("IdAccion") = 0 'Consulta
        Session("OrigenSeguro") = True
        Response.Redirect("~/CheckIn/Servicios_Busqueda.aspx")
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Session("IdAccion") = Request.QueryString("IdAccion")
        win = New Ventanas(Master)
        txtHidIdServ.Text = Session("IdServicio")
        txtHidEstatus.Text = Session("Estatus")
        If Session("TipoAuto") IsNot DBNull.Value Then
            txtHidTipoAuto.Text = Session("TipoAuto")
        Else
            txtHidTipoAuto.Text = "N"
        End If
            txtHidIdContrato.Text = Session("IdContrato")
            txtBitacora.BorderStyle = BorderStyle.Dotted
            txtBitacora.BorderColor = Drawing.Color.Aqua
            If Not Page.IsPostBack Then
                'Pone el titulo
                Session("IdFuncion") = 104
            Session("Titulo") = "Bitácora General"
            'If txtHidIdServ.Text = "-1" Then
            '    win.Alert("Para Ingresar o Ver una Bitacora de un Servicio o Contrato primero tienes que escoger uno", "Regresar_a_Busqueda")
            '    Exit Sub
            'End If
            'CargarGrid()
            End If
            lblnocontrato.Text = Session("NumContrato")
            lblnoservicio.Text = Session("NumServ")
            lblstatus.Text = Session("Estatus")
            If Page.IsPostBack Then
                If Request.Params("__EventTarget") = "Regresar_a_Busqueda" Then
                    Regresar_a_Busqueda()
                End If
            End If

    End Sub
    'Termina Isra
    Private Sub CargarGrid()
        ''Prepara el datatable
        'resp = serv.Consultar_Servicios_BitacoraGral(Session("IdUsuario"), Session("IdServicio"))

        '' Carga el grid
        'Grid.DataSource = resp.DataTable
        'grid.DataBind()

        'For Each item As GridDataItem In grid.Items
        '    ' Arregla el campo de contrato
        '    If item.Cells(ColGrid.Contrato).Text = "-" Or item.Cells(ColGrid.Contrato).Text = "0" Then
        '        item.Cells(ColGrid.Contrato).Text = "Sin Contrato aún"
        '    End If
        'Next

    End Sub
    'Private Sub VerificarPermisos()
    '    Dim permisos As Permisos = Session("Permisos")

    '    ' Verifica permisos de formulario
    '    If Not permisos.VerificarPermisoFuncion(IdFuncion) Then
    '        Response.Redirect("~/General/Inicio.aspx")
    '    End If

    'End Sub

    'Protected Sub VerificarOrigen()
    '    ' Verifica que se haya llamado la pantalla desde un lugar seguro
    '    If Not Session("OrigenSeguro") Then
    '        Response.Redirect("~/General/Inicio.aspx")
    '        Exit Sub
    '    End If

    '    Session("OrigenSeguro") = False
    'End Sub
End Class
