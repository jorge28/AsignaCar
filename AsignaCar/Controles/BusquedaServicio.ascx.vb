Imports System.Data
Imports System.Web.UI.WebControls
Imports Telerik.Web.UI

Partial Class Controles_BusquedaServicio
    Inherits System.Web.UI.UserControl

    ' Objetos 
    Dim serv As New Datos_ControlVehicular
    Dim resp As Resultado

    Dim servCheckOut As New Datos_CheckOut
    Dim respCheckOut As Resultado

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

    Public Sub MostrarControles()
        RadSplitter1.Visible = True
        lblAseguradora.Visible = True
        lblAsegurado.Visible = True
        lblEstado.Visible = True
        lblMunicipio.Visible = True
        lblPoliza.Visible = True
        lblEstatus.Visible = True
        lblEvento.Visible = True
        lblSiniestro.Visible = True
        lblFecActivacion.Visible = True
        lblFechaFin.Visible = True
        lblFechaIni.Visible = True
        lblCont.Visible = True
        lblNombreAseguradora.Visible = True
        lblNombreAsegurado.Visible = True
        lblNombreEstado.Visible = True
        lblNombreMunicipio.Visible = True
        lblNoPoliza.Visible = True
        lblDescripcionEstatus.Visible = True
        lblDescripcionEvento.Visible = True
        lblDescripcionSiniestro.Visible = True
        lblFechaActivacion.Visible = True
        lblFechaFinal.Visible = True
        lblFechaInicio.Visible = True
        lblContrato.Visible = True
        lblnocont.Visible = True
        lblnocontrato.Visible = True
        lblTelef.Visible = True
        lblTelefono.Visible = True
    End Sub

    Public Sub OcultarControles()
        RadSplitter1.Visible = False
        lblAseguradora.Visible = False
        lblAsegurado.Visible = False
        lblEstado.Visible = False
        lblMunicipio.Visible = False
        lblPoliza.Visible = False
        lblEstatus.Visible = False
        lblEvento.Visible = False
        lblSiniestro.Visible = False
        lblFecActivacion.Visible = False
        lblFechaFin.Visible = False
        lblFechaIni.Visible = False
        lblCont.Visible = False
        lblNombreAseguradora.Visible = False
        lblNombreAsegurado.Visible = False
        lblNombreEstado.Visible = False
        lblNombreMunicipio.Visible = False
        lblNoPoliza.Visible = False
        lblDescripcionEstatus.Visible = False
        lblDescripcionEvento.Visible = False
        lblDescripcionSiniestro.Visible = False
        lblFechaActivacion.Visible = False
        lblFechaFinal.Visible = False
        lblFechaInicio.Visible = False
        lblContrato.Visible = False
        lblNombreAseguradora.Text = ""
        lblNombreAsegurado.Text = ""
        lblNombreEstado.Text = ""
        lblNombreMunicipio.Text = ""
        lblNoPoliza.Text = ""
        lblDescripcionEstatus.Text = ""
        lblDescripcionEvento.Text = ""
        lblDescripcionSiniestro.Text = ""
        lblFechaActivacion.Text = ""
        lblFechaFinal.Text = ""
        lblFechaInicio.Text = ""
        lblContrato.Text = ""
        lblnocont.Visible = False
        lblnocontrato.Visible = False
        lblnocontrato.Text = ""
        lblTelef.Visible = False
        lblTelefono.Visible = False
        lbldiasextras.Visible = False
        lbldiasren.Visible = False
        diasrentacosto.Visible = False
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            txtHidIdServicio.Text = Session("IdServicio")
            If txtHidIdServicio.Text = "-1" Then
                txtHidIdServicio.Text = "0"
            Else
                txtHidIdServicio.Text = Session("IdServicio")
            End If

            RdNumServicio.Text = Session("Servicio")
            If RdNumServicio.Text <= " " Then
                RdNumServicio.Text = "0"
            Else
                RdNumServicio.Text = Session("Servicio")
            End If

            If Session("NumServ") = True Then
                RdNumServicio.Text = Session("NumServ")
            Else
                RdNumServicio.Text = Session("Servicio")
            End If

            txtHidEstatus.Text = Session("Contrato")
            If txtHidEstatus.Text = " " Then
                txtHidEstatus.Text = "0"
            Else
                txtHidEstatus.Text = Session("Contrato")
            End If

            If txtHidIdServicio.Text = "0" And RdNumServicio.Text <= "0" Then
                RdNumServicio.Text = "0"
            End If
        End If
        btnBusqueda_Click(RdNumServicio.Text, e)
        If Page.IsPostBack Then
            If RdNumServicio.Text <> "" Then

            Else
                OcultarControles()
            End If
            If RdNumServicio.Text = "0" Then
                OcultarControles()
            End If

        End If

    End Sub
    'Termina Isra
    Protected Sub btnBusqueda_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBusqueda.Click
        Dim NoServicio As Integer

        If RdNumServicio.Text.Trim = "" Or RdNumServicio.Text.Trim <= "0" Then
            RdNumServicio.Focus()
            OcultarControles()
            Exit Sub
        End If

        If RdNumServicio.Text > "0" Then
            NoServicio = RdNumServicio.Text
            'Prepara el datatable
            resp = serv.Consultar_ReporteServicio(NoServicio)

            If resp.DataTable.Rows.Count > 0 Then
                'RadSplitter1.Visible = True
                Session("Servicio") = NoServicio
                Dim row As DataRow = resp.DataTable.Rows(0)
                lblNombreAseguradora.Text = row("Aseguradora")
                lblNombreAsegurado.Text = row("AsegNombre") & " " & row("AsegPaterno") & " " & row("AsegMaterno")
                lblNombreEstado.Text = row("DescripcionEstado")
                lblTelefono.Text = "<b>" & "(" & "</b>" & row("AsegLadaTelefonica") & "<b>" & ")" & "</b>" & " " & row("AsegTelefono")
                lblNombreMunicipio.Text = row("DescripcionMunicipio")
                lblNoPoliza.Text = row("NumPoliza") & "-" & row("Inciso")
                Select Case row("Estatus")
                    Case "A"
                        lblDescripcionEstatus.Text = "Activo"
                    Case "T"
                        lblDescripcionEstatus.Text = "Terminado"
                    Case "P"
                        lblDescripcionEstatus.Text = "Abierto"
                    Case "D"
                        lblDescripcionEstatus.Text = "Atendido"
                    Case "C"
                        lblDescripcionEstatus.Text = "Cancelado"
                    Case "E"
                        lblDescripcionEstatus.Text = "Asignado a Proveedor"
                End Select

                lblDescripcionEvento.Text = row("Evento")
                If row("DiasRenta") = 0 Then
                    lbldiasextras.Visible = False
                    lbldiasren.Visible = False
                    diasrentacosto.Visible = False
                Else
                    If row("DiasRenta") <> row("DiasCobertura") Then
                        diasrentacosto.Text = row("DiasRenta")
                        lbldiasextras.Visible = True
                        lbldiasren.Visible = True
                        diasrentacosto.Visible = True
                    Else
                        lbldiasextras.Visible = False
                        lbldiasren.Visible = False
                        diasrentacosto.Visible = False
                    End If
                End If

                txtHidIdServicio.Text = row("Id")
                lblFechaActivacion.Text = row("FecActivacion")
                
                MostrarControles()

                'Agregar las nuevas fechas
                If row("FecAtencion") IsNot DBNull.Value Then
                    If row("FecAtencion") <> "1900/01/01" Then
                        lblFecAtenc.Visible = True
                        lblFechaAtencion.Visible = True
                        lblFechaAtencion.Text = row("FecAtencion")
                    End If
                End If

                If row("FecEntrega") IsNot DBNull.Value Then
                    If row("FecEntrega") <> "1900/01/01" Then
                        lblFechaInicio.Text = row("FecEntrega")
                        lblFechaFinal.Text = row("FecDevolucionPrevista")
                        lblDescripcionSiniestro.Text = row("NumSiniestro")
                        lblFechaFin.Visible = True
                        lblFechaIni.Visible = True
                        lblSiniestro.Visible = True
                    Else
                        lblFechaInicio.Text = ""
                        lblFechaFinal.Text = ""
                        lblDescripcionSiniestro.Text = ""
                        lblFechaFin.Visible = False
                        lblFechaIni.Visible = False
                        lblSiniestro.Visible = False
                    End If

                End If
                ''
                If row("EstatusC") IsNot DBNull.Value Then
                    txtHidEstatus.Text = row("EstatusC")
                    lblContrato.Text = row("EstatusC")
                    lblnocontrato.Text = row("NumContrato")
                    If row("NumContrato") <> "0" Then
                        lblIdContrato.Text = row("IdContrato")
                    Else
                        lblIdContrato.Text = "0"
                    End If
                    'Agregar las nuevas fechas
                    If row("FecEntregaReal") IsNot DBNull.Value Then
                        If row("FecEntregaReal") <> "1900/01/01" Then
                            'lblFechaEntreRe.Visible = True
                            'lblFechaEntregaReal.Visible = True
                            lblFechaEntregaReal.Text = row("FecEntregaReal")
                            'lblFechaDevoPre.Visible = True
                            'lblFechaDevoPrevista.Visible = True
                            lblFechaDevoPrevista.Text = row("FecDevolucionPrevistaII")
                        End If
                    End If
                    If row("FecDevolucionReal") IsNot DBNull.Value Then
                        If row("FecDevolucionReal") <> "1900/01/01" Then
                            'lblFechaDevoRe.Visible = True
                            'lblFechaDevolucionReal.Visible = True
                            lblFechaDevolucionReal.Text = row("FecDevolucionReal")
                        End If
                    End If
                    If row("FecDevolucionRealCierre") IsNot DBNull.Value Then
                        If row("FecDevolucionRealCierre") <> "1900/01/01" Then
                            'lblFechaCier.Visible = True
                            'lblFechaCierre.Visible = True
                            lblFechaCierre.Text = row("FecDevolucionRealCierre")
                        End If
                    End If

                    Dim idcontrato As String = ""

                    If row("TipoAuto") IsNot DBNull.Value Then
                        If row("TipoAuto") = "V" Then
                            idcontrato = lblnocontrato.Text
                        Else
                            idcontrato = lblIdContrato.Text
                        End If
                    End If
                    respCheckOut = servCheckOut.Consultar_Dias_Extension(Session("IdUsuario"), idcontrato)

                    Dim rowd As DataRow = respCheckOut.DataTable.Rows(0)

                    If rowd("DiasExtension") IsNot DBNull.Value Then
                        lblFechaExte.Visible = True
                        lblFechaExtension.Visible = True
                        lblFechaExtension.Text = rowd("FechaExtension")
                    End If
                    'Termina las nuevas fechas
                Else
                    txtHidEstatus.Text = "Sin Contrato"
                    lblContrato.Text = "Sin Contrato"
                    lblnocont.Visible = False
                    lblIdContrato.Text = -1
                End If

                Session("IdServicio") = txtHidIdServicio.Text
                Session("Estatus") = lblDescripcionEstatus.Text
                Session("Contrato") = txtHidEstatus.Text
                Session("NumServ") = RdNumServicio.Text
                Session("NoContrato") = lblnocontrato.Text
                Session("IdContrato") = lblIdContrato.Text
                Session("NumContrato") = lblnocontrato.Text
                Session("EstatusC") = lblDescripcionEstatus.Text
                Session("TipoAuto") = row("TipoAuto")

                If lblDescripcionEstatus.Text = "Activo" Then
                    lblFechaFin.Visible = False
                    lblFechaIni.Visible = False
                    lblSiniestro.Visible = False
                    lblnocont.Visible = False
                End If
                If lblDescripcionEstatus.Text = "" Then
                    lblFechaFin.Visible = False
                    lblFechaIni.Visible = False
                    lblSiniestro.Visible = False
                    lblnocont.Visible = False
                End If
            Else
                ConfigureNotification("AutoSigue", "El Número de Servicio No Existe", 3000)
                OcultarControles()
                RdNumServicio.Focus()
            End If
        End If

    End Sub
    'Protected Sub RdBusquedaServicio_Click(sender As Object, e As System.EventArgs) Handles RdBusquedaServicio.Click
    '    'Dim NoServicio As Integer

    '    'If RdBusquedaServicio.Text.Trim = "" Or RdBusquedaServicio.Text.Trim = "0" Then
    '    '    ConfigureNotification("AutoSigue", "No has anotado el Número de Servicio", 3000)
    '    '    RdBusquedaServicio.Focus()
    '    '    Exit Sub
    '    'End If


    '    'If RdNumServicio.Text <> "" Then
    '    '    NoServicio = RdNumServicio.Text

    '    '    'Prepara el datatable
    '    '    resp = serv.Consultar_ReporteServicio(NoServicio)

    '    '    If resp.DataTable.Rows.Count > 0 Then
    '    '        pnlBusqueda.Visible = True
    '    '        'Session("Servicio") = NoServicio

    '    '        Dim row As DataRow = resp.DataTable.Rows(0)
    '    '        lblNombreAseguradora.Text = row("Aseguradora")
    '    '        lblNombreAsegurado.Text = row("AsegNombre") & " " & row("AsegPaterno") & " " & row("AsegMaterno")
    '    '        lblNombreEstado.Text = row("DescripcionEstado")
    '    '        lblNombreMunicipio.Text = row("DescripcionMunicipio")
    '    '        lblNoPoliza.Text = row("NumPoliza")
    '    '        If row("Estatus") = "A" Then
    '    '            row("Estatus") = "Activo"
    '    '            lblDescripcionEstatus.Text = row("Estatus")
    '    '        End If
    '    '        If row("Estatus") = "T" Then
    '    '            row("Estatus") = "Terminado"
    '    '            lblDescripcionEstatus.Text = row("Estatus")
    '    '        End If
    '    '        If row("Estatus") = "P" Then
    '    '            row("Estatus") = "Proveedor"
    '    '            lblDescripcionEstatus.Text = row("Estatus")
    '    '        End If
    '    '        lblDescripcionEvento.Text = row("IdEvento")
    '    '        lblDescripcionSiniestro.Text = row("NumSiniestro")
    '    '        lblFechaInicio.Text = row("FecEntrega")
    '    '        lblFechaFinal.Text = row("FecDevolucionPrevista")
    '    '        txtHidIdServicio.Text = row("Id")

    '    '        Session("IdServicio") = txtHidIdServicio.Text
    '    '        Session("Estatus") = lblDescripcionEstatus.Text

    '    '    Else
    '    '        ConfigureNotification("AutoSigue", "El Número de Servicio No Existe", 3000)
    '    '        Limpiar()
    '    '        pnlBusqueda.Visible = False
    '    '        RdBusquedaServicio.Focus()
    '    '    End If
    '    'End If

    '    'Catch ex As Exception
    '    '    Throw ex
    '    'End Try

    'End Sub

    

    'Protected Sub RdLimpiar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RdLimpiar.Click
    '    Limpiar()
    '    pnlBusqueda.Visible = False
    'End Sub
    Protected Sub RdNumServicio_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RdNumServicio.TextChanged
        btnBusqueda_Click(RdNumServicio.Text, e)
        Session("IdAccion") = 0
        Response.Redirect("~/CheckIn/Servicios_Busqueda.aspx")
    End Sub
End Class
