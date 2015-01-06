<%@ Application Language="VB" %>
<%@ Import Namespace="System.Web.Configuration" %>

<script runat="server">  
 
    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        Acceso_a_Datos.ObjDatos.CONNECTION_STRING = WebConfigurationManager.ConnectionStrings("ConnString").ConnectionString
        Acceso_a_Datos.ObjDatos.CONNECTION_STRING_AsistenciaII  = WebConfigurationManager.ConnectionStrings("ConnString_AsistII").ConnectionString
         
        Application("AppDir") = System.Web.Configuration.WebConfigurationManager.AppSettings("AppDir")
     
        Logs.RUTA_ARCHIVO_LOG = Application("AppDir") & "App_Data\Logs\"
         
        Application("Usuarios") = "|" 
         
        ConexionInicial()
        
        Parametros.CargarParametros(Application)

        ' Email
        Application("mailAdmin") = WebConfigurationManager.AppSettings("mailAdmin")
        Application("mailFrom") = WebConfigurationManager.AppSettings("mailFrom")
        Email.MailHost = WebConfigurationManager.AppSettings("mailHost")
        Email.MailPort = WebConfigurationManager.AppSettings("mailPort")
        Nextel.MailHost = WebConfigurationManager.AppSettings("mailHost")
        Nextel.MailPort = WebConfigurationManager.AppSettings("mailPort")
                
        ' Imagenes
        Imagenes.URL_Carpix  = WebConfigurationManager.AppSettings("UrlImagenes")
    End Sub
    
    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs on application shutdown
    End Sub
        
    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when an unhandled error occurs
        Dim ex As Exception = Server.GetLastError()
        Logs.LogError("Global.asax", "Application_Error", ex.Message, ex.StackTrace)
    End Sub

    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when a new session is started
        'Session.Timeout = 1
        Session("OrigenSeguro") = False
        Session("IdFuncion") = -1
        Session("IdAccion") = -1
        Session("IdVehiculo") = -1
        Session("IdContrato") = -1
        Session("IdServicio") = -1
        Session("IdModulo") = 1
        'Rafael
        Session("NoServicio") = 0
        Session("MVA") = 0
        Session("Padre") = 0
        ' Fin Rafael
        Application("Usuarios") = "|"
    End Sub

    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when a session ends. 
        ' Note: The Session_End event is raised only when the sessionstate mode
        ' is set to InProc in the Web.config file. If session mode is set to StateServer 
        ' or SQLServer, the event is not raised.
        Seguridad.QuitarUsuarioListado(Application, Session("IdUsuario"))
    End Sub
    
    ''' <summary>
    ''' Por alguna extraña razón la primera vez no se logra conectar a la base. Así que aqui lo intenta varias veces
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ConexionInicial()
        Dim datos As New Acceso_a_Datos.ObjDatos
        Dim exito As Boolean 
         
        Do
            Try
                datos.Conectar()
                exito = True
            Catch ex As Exception
                exito = False
            End Try
            datos.Desconectar()
            
        Loop While exito = False
    End Sub
    
</script>