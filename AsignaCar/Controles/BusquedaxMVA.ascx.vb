Imports System.Data
Imports System.Web.UI.WebControls
Imports Telerik.Web.UI
Partial Class Controles_BusquedaxMVA
    Inherits System.Web.UI.UserControl

    ' Objetos 
    Dim serv As New Datos_ControlVehicular
    Dim resp As Resultado
    Dim servCatalogos As New Datos_Catalogos
    Dim respCatalogos As Resultado
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
        lblCol.Visible = True
        lblColor.Visible = True
        lblEst.Visible = True
        lblEstatus.Visible = True
        lblMar.Visible = True
        lblMarca.Visible = True
        lblMod.Visible = True
        lblModelo.Visible = True
        lblSubM.Visible = True
        lblSubMarca.Visible = True
        lblFec.Visible = True
        lblFecCompra.Visible = True
    End Sub

    Public Sub OcultarControles()
        RadSplitter1.Visible = False
        lblCol.Visible = False
        lblColor.Visible = False
        lblColor.Text = ""
        lblEst.Visible = False
        lblEstatus.Visible = False
        lblEstatus.Text = ""
        lblMar.Visible = False
        lblMarca.Visible = False
        lblMarca.Text = ""
        lblMod.Visible = False
        lblModelo.Visible = False
        lblModelo.Text = ""
        lblSubM.Visible = False
        lblSubMarca.Visible = False
        lblSubMarca.Text = ""
        lblFec.Visible = False
        lblFecCompra.Visible = False
        lblFecCompra.Text = ""
    End Sub

    'Private Sub Limpiar()
    '    lblColor.Text = ""
    '    lblEstatus.Text = ""
    '    lblMarca.Text = ""
    '    lblModelo.Text = ""
    '    lblSubMarca.Text = ""
    'End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            RadNumerictxtMVA.Text = Session("IdVehiculo")
            If RadNumerictxtMVA.Text <= "0" Then
                RadNumerictxtMVA.Text = "0"
            Else
                RadNumerictxtMVA.Text = Session("IdVehiculo")
            End If
            RadBusquedaMVA_Click(RadNumerictxtMVA.Text, e)
        End If
        If Page.IsPostBack Then
            If RadNumerictxtMVA.Text <> "" Then

            Else
                OcultarControles()
            End If
            If RadNumerictxtMVA.Text = "0" Then
                OcultarControles()
            End If
        End If

    End Sub

    Protected Sub RadBusquedaMVA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadBusquedaMVA.Click
        Dim MVA As Integer
        Dim Placas As String
        Dim Marca As Integer
        Dim SubMarca As Integer

        If RadNumerictxtMVA.Text.Trim = "0" And RadtxtPlacas.Text.Trim = "0" Or (RadNumerictxtMVA.Text.Trim = "" And RadtxtPlacas.Text.Trim = "") Then
            'ConfigureNotification("AutoSigue", "Anota al menos un Criterio de Búsqueda", 3000)
            RadNumerictxtMVA.Focus()
            OcultarControles()
            'Limpiar()
            Exit Sub
        End If
        If RadNumerictxtMVA.Text.Trim = "" And RadtxtPlacas.Text.Trim = "0" Or (RadNumerictxtMVA.Text.Trim = "0" And RadtxtPlacas.Text.Trim = "") Then
            'ConfigureNotification("AutoSigue", "Anota al menos un Criterio de Búsqueda", 3000)
            RadNumerictxtMVA.Focus()
            OcultarControles()
            'Limpiar()
            Exit Sub
        End If

        If RadtxtPlacas.Text.Trim > "0" And (RadNumerictxtMVA.Text.Trim = "0" Or RadNumerictxtMVA.Text.Trim = "") Then
            Placas = RadtxtPlacas.Text

            'Prepara el datatable
            resp = servCatalogos.Consultar_Placas(Session("IdUsuario"), Placas)


            If resp.DataTable.Rows.Count > 0 Then
                Dim rowPlacas As DataRow = resp.DataTable.Rows(0)
                MostrarControles()
                RadNumerictxtMVA.Text = rowPlacas("Id")
                'RadtxtPlacas.Text = rowPlacas("Placas")
                lblColor.Text = rowPlacas("Color").ToString.ToUpper
                lblModelo.Text = rowPlacas("Modelo")
                lblFecCompra.Text = rowPlacas("FecCompra")
                Select Case rowPlacas("Estatus")
                    Case "T"
                        lblEstatus.Text = "TRASLADO"
                    Case "D"
                        lblEstatus.Text = "DISPONIBLE"
                    Case "V"
                        lblEstatus.Text = "EN SERVICIO"
                    Case "I"
                        lblEstatus.Text = "INACTIVO POR SINIESTRO"
                    Case "B"
                        lblEstatus.Text = "BAJA"
                    Case "S"
                        lblEstatus.Text = "INACTIVO POR SALIDA IMPRODUCTIVA"
                    Case "M"
                        lblEstatus.Text = "MANTENIMIENTO"
                End Select
                Marca = Convert.ToInt32(rowPlacas("IdMarca"))
                SubMarca = Convert.ToInt32(rowPlacas("IdSubMarca"))
                txtHidKilometraje.Text = rowPlacas("Kilometraje")
                txtHidEstatus.Text = rowPlacas("Estatus")
                lblRegion.text = rowPlacas("IdRegion")


                Session("Kilometraje") = txtHidKilometraje.Text
                Session("Estatus") = txtHidEstatus.Text
                Session("FecCompra") = lblFecCompra.Text
                Session("IdRegion") = lblRegion.text
                resp = servCatalogos.Consultar_Marcas(Session("IdUsuario"), Marca)

                If resp.DataTable.Rows.Count > 0 Then
                    Dim rowMarca As DataRow = resp.DataTable.Rows(0)
                    lblMarca.Text = rowMarca("Nombre").ToString.ToUpper
                End If

                resp = servCatalogos.Consultar_SubMarcas(Session("IdUsuario"), SubMarca, Marca)

                If resp.DataTable.Rows.Count > 0 Then
                    Dim rowSubmarca As DataRow = resp.DataTable.Rows(0)
                    lblSubMarca.Text = rowSubmarca("Nombre").ToString.ToUpper
                End If
            Else
                ConfigureNotification("AutoSigue", "Las Placas no existen", 3000)
                RadtxtPlacas.Focus()
                OcultarControles()
                'Limpiar()
                Exit Sub
            End If
        End If

            If RadNumerictxtMVA.Text.Trim > "0" And (RadtxtPlacas.Text.Trim = "" Or RadtxtPlacas.Text.Trim = "0") Then
                MVA = RadNumerictxtMVA.Text
                'Prepara el datatable
                resp = serv.Consultar_Vehiculos_Completos(Session("IdUsuario"), MVA)

                If resp.DataTable.Rows.Count > 0 Then
                    'Session("IdVehiculo") = MVA
                    MostrarControles()
                    Dim row As DataRow = resp.DataTable.Rows(0)
                    RadtxtPlacas.Text = row("Placas").ToString.ToUpper
                    lblColor.Text = row("Color").ToString.ToUpper
                    lblModelo.Text = row("Modelo")
                    lblFecCompra.Text = row("FecCompra")
                    Select Case row("Estatus")
                        Case "T"
                            lblEstatus.Text = "TRASLADO"
                        Case "D"
                            lblEstatus.Text = "DISPONIBLE"
                        Case "V"
                            lblEstatus.Text = "EN SERVICIO"
                        Case "I"
                            lblEstatus.Text = "INACTIVO POR SINIESTRO"
                        Case "B"
                            lblEstatus.Text = "BAJA"
                        Case "S"
                            lblEstatus.Text = "INACTIVO POR SALIDA IMPRODUCTIVA"
                        Case "M"
                            lblEstatus.Text = "MANTENIMIENTO"
                    End Select
                    Marca = Convert.ToInt32(row("IdMarca"))
                    SubMarca = Convert.ToInt32(row("IdSubMarca"))
                    txtHidKilometraje.Text = row("Kilometraje")
                txtHidEstatus.Text = row("Estatus")
                lblRegion.text = row("IdRegion")

                    Session("IdVehiculo") = MVA
                    Session("Kilometraje") = txtHidKilometraje.Text
                    Session("Estatus") = txtHidEstatus.Text
                Session("FecCompra") = lblFecCompra.Text
                Session("IdRegion") = lblRegion.text
                    resp = servCatalogos.Consultar_Marcas(Session("IdUsuario"), Marca)

                    If resp.DataTable.Rows.Count > 0 Then
                        Dim rowMarca As DataRow = resp.DataTable.Rows(0)
                        lblMarca.Text = rowMarca("Nombre").ToString.ToUpper
                    End If

                    resp = servCatalogos.Consultar_SubMarcas(Session("IdUsuario"), SubMarca, Marca)

                    If resp.DataTable.Rows.Count > 0 Then
                        Dim rowSubmarca As DataRow = resp.DataTable.Rows(0)
                        lblSubMarca.Text = rowSubmarca("Nombre").ToString.ToUpper
                    End If
                Else
                    ConfigureNotification("AutoSigue", "EL MVA no existe", 3000)
                    RadNumerictxtMVA.Focus()
                    OcultarControles()
                    'Limpiar()
                    Exit Sub
                End If
            End If

            If RadNumerictxtMVA.Text.Trim > "0" And RadtxtPlacas.Text.Trim > "0" Then
                MVA = RadNumerictxtMVA.Text
                'Prepara el datatable
                resp = serv.Consultar_Vehiculos_Completos(Session("IdUsuario"), MVA)

                If resp.DataTable.Rows.Count > 0 Then
                    'Session("IdVehiculo") = MVA
                    MostrarControles()
                    Dim row As DataRow = resp.DataTable.Rows(0)
                    RadtxtPlacas.Text = row("Placas").ToString.ToUpper
                    lblColor.Text = row("Color").ToString.ToUpper
                    lblModelo.Text = row("Modelo")
                    lblFecCompra.Text = row("FecCompra")
                    Select Case row("Estatus")
                        Case "T"
                            lblEstatus.Text = "TRASLADO"
                        Case "D"
                            lblEstatus.Text = "DISPONIBLE"
                        Case "V"
                            lblEstatus.Text = "EN SERVICIO"
                        Case "I"
                            lblEstatus.Text = "INACTIVO POR SINIESTRO"
                        Case "B"
                            lblEstatus.Text = "BAJA"
                        Case "S"
                            lblEstatus.Text = "INACTIVO POR SALIDA IMPRODUCTIVA"
                        Case "M"
                            lblEstatus.Text = "MANTENIMIENTO"
                    End Select
                    Marca = Convert.ToInt32(row("IdMarca"))
                    SubMarca = Convert.ToInt32(row("IdSubMarca"))
                    txtHidKilometraje.Text = row("Kilometraje")
                txtHidEstatus.Text = row("Estatus")
                lblRegion.text = row("IdRegion")

                    Session("IdVehiculo") = MVA
                    Session("Kilometraje") = txtHidKilometraje.Text
                    Session("Estatus") = txtHidEstatus.Text
                Session("FecCompra") = lblFecCompra.Text
                Session("IdRegion") = lblRegion.text
                    resp = servCatalogos.Consultar_Marcas(Session("IdUsuario"), Marca)

                    If resp.DataTable.Rows.Count > 0 Then
                        Dim rowMarca As DataRow = resp.DataTable.Rows(0)
                        lblMarca.Text = rowMarca("Nombre").ToString.ToUpper
                    End If

                    resp = servCatalogos.Consultar_SubMarcas(Session("IdUsuario"), SubMarca, Marca)

                    If resp.DataTable.Rows.Count > 0 Then
                        Dim rowSubmarca As DataRow = resp.DataTable.Rows(0)
                        lblSubMarca.Text = rowSubmarca("Nombre").ToString.ToUpper
                    End If
                Else
                    ConfigureNotification("AutoSigue", "EL MVA no existe", 3000)
                    RadNumerictxtMVA.Focus()
                    OcultarControles()
                    'Limpiar()
                    Exit Sub
                End If
            End If
    End Sub
    'Termina Isra

    Protected Sub RadNumerictxtMVA_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadNumerictxtMVA.TextChanged
        RadBusquedaMVA_Click(RadNumerictxtMVA.Text, e)
        Response.Redirect("~/General/Inicio.aspx")
    End Sub

    Protected Sub RadtxtPlacas_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadtxtPlacas.TextChanged
        RadBusquedaMVA_Click(RadtxtPlacas.Text, e)
        Response.Redirect("~/General/Inicio.aspx")
    End Sub
End Class
