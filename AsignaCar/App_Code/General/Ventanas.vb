Imports Microsoft.VisualBasic
Imports Telerik.Web.UI

Public Class Ventanas

    Private master As MasterPage
    Private popup As Page

    Sub New(ByRef master As MasterPage)
        Me.master = master
    End Sub

    Sub New(ByRef popup As Page)
        Me.popup = popup
    End Sub

    Sub New()
        ' TODO: Complete member initialization 
    End Sub

    ''' <summary>
    ''' Alert desde MasterPage
    ''' </summary>
    ''' <param name="mensaje"></param>
    ''' <param name="callBack"></param>
    ''' <remarks></remarks>
    Public Sub Alert(mensaje As String, Optional callBack As String = Nothing)
        Dim rad As RadWindowManager

        ' Recupera el RadWindowManager
        rad = master.FindControl("RadWindowManager")

        ' Muestra el mensaje
        rad.RadAlert(Comillas_JS(mensaje), 450, 200, "AutoSigue", callBack)
    End Sub

    ''' <summary>
    ''' Alert desde un Popup Page
    ''' </summary>
    ''' <param name="mensaje"></param>
    ''' <param name="callBack"></param>
    ''' <remarks></remarks>
    Public Sub AlertPopup(mensaje As String, Optional callBack As String = Nothing)
        Dim rad As RadWindowManager

        ' Recupera el RadWindowManager
        rad = popup.FindControl("RadWindowManager")

        ' Muestra el mensaje
        rad.RadAlert(Comillas_JS(mensaje), 300, 200, "AutoSigue", callBack)
    End Sub



    Public Sub Confirm(mensaje As String, callback As String)
        Dim rad As RadWindowManager

        ' Recupera el RadWindowManager
        rad = master.FindControl("RadWindowManager")

        ' Muestra el mensaje
        rad.RadConfirm(Comillas_JS(mensaje), callback, 450, 200, Nothing, "AutoSigue")
    End Sub

    Public Sub FuncionPopup(funcion As String)
        Dim rad As RadAjaxPanel

        ' Recupera el RadWindowManager
        rad = popup.FindControl("RadAjaxPanel")

        ' Muestra el mensaje
        rad.ResponseScripts.Add(funcion)
    End Sub

#Region "Abrir Ventanas"

    Public Sub Abrir_winImagenes()
        Dim rad As RadAjaxPanel

        ' Recupera el RadAjaxPanel
        rad = master.FindControl("RadAjaxPanel")

        ' Abre la ventana
        rad.ResponseScripts.Add("Abrir_winImagenes();")
    End Sub

    Public Sub Abrir_winMotivoBajaPoliza()
        Dim rad As RadAjaxPanel

        ' Recupera el RadAjaxPanel
        rad = master.FindControl("RadAjaxPanel")

        ' Abre la ventana
        rad.ResponseScripts.Add("Abrir_winMotivoBajaPoliza();")
    End Sub

    Public Sub Abrir_winMotivoBajaVehiculo()
        Dim rad As RadAjaxPanel

        ' Recupera el RadAjaxPanel
        rad = master.FindControl("RadAjaxPanel")

        ' Abre la ventana
        rad.ResponseScripts.Add("Abrir_winMotivoBajaVehiculo();")
    End Sub

    Public Sub Abrir_winPolizasIncisosEdicion()
        Dim rad As RadAjaxPanel

        ' Recupera el RadAjaxPanel
        rad = master.FindControl("RadAjaxPanel")

        ' Abre la ventana
        rad.ResponseScripts.Add("Abrir_winPolizasIncisosEdicion();")
    End Sub

    Public Sub Abrir_winMotivoBajaServicio()
        Dim rad As RadAjaxPanel

        ' Recupera el RadAjaxPanel
        rad = master.FindControl("RadAjaxPanel")

        ' Abre la ventana
        rad.ResponseScripts.Add("Abrir_winMotivoBajaServicio();")
    End Sub

    Public Sub Abrir_winServiciosPolizaNDias()
        Dim rad As RadAjaxPanel

        ' Recupera el RadAjaxPanel
        rad = master.FindControl("RadAjaxPanel")

        ' Abre la ventana
        rad.ResponseScripts.Add("Abrir_winServiciosPolizaNDias();")
    End Sub

    Public Sub Abrir_winMotivoBajaSiniestro()
        Dim rad As RadAjaxPanel

        ' Recupera el RadAjaxPanel
        rad = master.FindControl("RadAjaxPanel")

        ' Abre la ventana
        rad.ResponseScripts.Add("Abrir_winMotivoBajaSiniestro();")
    End Sub
    'Isra
    Public Sub Abrir_winMotivoCierreSiniestro()
        Dim rad As RadAjaxPanel

        ' Recupera el RadAjaxPanel
        rad = master.FindControl("RadAjaxPanel")

        ' Abre la ventana
        rad.ResponseScripts.Add("Abrir_winMotivoCierreSiniestro();")
    End Sub

    Public Sub Abrir_winBusquedaVehiculosContrato()
        Dim rad As RadAjaxPanel

        ' Recupera el RadAjaxPanel
        rad = master.FindControl("RadAjaxPanel")

        ' Abre la ventana
        rad.ResponseScripts.Add("Abrir_winBusquedaVehiculosContrato();")
    End Sub

    Public Sub Abrir_winBusquedaVehiculosCambioVeh()
        Dim rad As RadAjaxPanel

        ' Recupera el RadAjaxPanel
        rad = master.FindControl("RadAjaxPanel")

        ' Abre la ventana
        rad.ResponseScripts.Add("Abrir_winBusquedaVehiculosCambioVeh();")
    End Sub

    Public Sub Abrir_winBusquedaProveedoresContrato()
        Dim rad As RadAjaxPanel

        ' Recupera el RadAjaxPanel
        rad = master.FindControl("RadAjaxPanel")

        ' Abre la ventana
        rad.ResponseScripts.Add("Abrir_winBusquedaProveedoresContrato();")
    End Sub

    Public Sub Abrir_winBusquedaProveedoresCambioVeh()
        Dim rad As RadAjaxPanel

        ' Recupera el RadAjaxPanel
        rad = master.FindControl("RadAjaxPanel")

        ' Abre la ventana
        rad.ResponseScripts.Add("Abrir_winBusquedaProveedoresCambioVeh();")
    End Sub
    'Termina Isra


    Public Sub Abrir_winBusquedaProveedoresMantenimiento()
        Dim rad As RadAjaxPanel

        ' Recupera el RadAjaxPanel
        rad = master.FindControl("RadAjaxPanel")

        ' Abre la ventana
        rad.ResponseScripts.Add("Abrir_winBusquedaProveedoresMantenimiento();")
    End Sub

    Public Sub Abrir_winCargarListaPreciosProveedores()
        Dim rad As RadAjaxPanel

        ' Recupera el RadAjaxPanel
        rad = master.FindControl("RadAjaxPanel")

        ' Abre la ventana
        rad.ResponseScripts.Add("Abrir_winCargarListaPreciosProveedores();")
    End Sub

    Public Sub Abrir_winReportes() ''jrad marzo 2013
        Dim rad As RadAjaxPanel

        ' Recupera el RadAjaxPanel
        rad = master.FindControl("RadAjaxPanel")

        ' Abre la ventana
        rad.ResponseScripts.Add("Abrir_winReportes();")
    End Sub

    Public Sub Abrir_winHistorialCambiosUnidad()
        Dim rad As RadAjaxPanel

        ' Recupera el RadAjaxPanel
        rad = master.FindControl("RadAjaxPanel")

        ' Abre la ventana
        rad.ResponseScripts.Add("Abrir_winHistorialCambiosUnidad();")
    End Sub


#End Region

#Region "Alerta de Error"

    ''' <summary>
    ''' Alert desde MasterPage
    ''' </summary>
    ''' <param name="mensaje"></param>
    ''' <remarks></remarks>
    Public Sub Alert_Error(mensaje As String)
        Dim rad As RadWindowManager

        ' Recupera el RadWindowManager
        rad = master.FindControl("RadWindowManager")

        ' Muestra el mensaje
        mensaje = "<h2>Ocurrió un error:</h2> <span class=""LabelError"">" & mensaje & "</span><br /><br />"
        rad.RadAlert(Comillas_JS(mensaje), 450, 200, "AutoSigue", Nothing, "../img/Error.jpg")
    End Sub

    ''' <summary>
    ''' Alert desde un Popup Page
    ''' </summary>
    ''' <param name="mensaje"></param>
    ''' <remarks></remarks>
    Public Sub AlertPopup_Error(mensaje As String)
        Dim rad As RadWindowManager

        ' Recupera el RadWindowManager
        rad = popup.FindControl("RadWindowManager")

        ' Muestra el mensaje
        mensaje = "<h2>Ocurrió un error:</h2> <span class=""LabelError"">" & mensaje & "</span><br /><br />"
        rad.RadAlert(Comillas_JS(mensaje), 300, 200, "AutoSigue", Nothing, "../img/Error.jpg")
    End Sub


#End Region

End Class
