Imports System.Data

Partial Class Autenticacion_Login
    Inherits System.Web.UI.Page

    Dim serv As New Datos_ControlAcceso
    Dim resp As New Resultado
    Dim seccionDatos As New SeccionDatos

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

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack() Then
            'Se busca si existe la cookie con el username
            If Not Request.Cookies("Username") Is Nothing Then
                txtUsername.Text = Request.Cookies("Username").Value 'Si existe se coloca el username en textbox
                chkRecordar.Checked = True
            End If
        End If

        If Page.IsPostBack Then
            ' hicieron un postback, es igual a un click del botón
            '' btnAceptar_Click(New Object, New System.EventArgs)
        End If
    End Sub

    Protected Sub btnAceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Dim username As String = txtUsername.Text
        Dim password As String = txtPassword.Text

        resp = serv.ComprobarLogin(Session("IdUsuario"), username, password) 'Respuesta del ws
        Dim code As Integer = resp.DataTable.Rows(0)(0) 'Código de respuesta del ws (0, 1, -1)

        'Si encontró el usuario   
        If code = 0 Then
            resp = serv.ConsultarUsuario(Session("IdUsuario"), username) 'Consulta los datos del usuario
            If resp.DataTable.Rows.Count <= 0 Then
                ConfigureNotification("AutoSigue", "El Usuario no Existe. Favor de contactar al Administrador", 3000)
                Exit Sub
            End If
            With resp.DataTable.Rows(0)
                Dim caducidad As Date = .Item("CaducidadPassword") 'Obtiene la fecha de caducidad
                Dim userId As String = .Item("IdUsuario") 'Obtiene Id

                Dim puesto As String
                If IsDBNull(.Item("NombrePuesto")) Then
                    puesto = ""
                Else
                    puesto = .Item("NombrePuesto")
                End If

                ' Agrega al usuario en la lista de usuarios logeados
                If Not MeterIdApplication(userId) Then Exit Sub

                'Agrega Caducidad, username, Id, Nombre del usuario a Session
                Session.Add("CaducidadPassword", DateDiff(DateInterval.Day, Now, caducidad))
                Session.Add("Username", username)
                Session.Add("IdUsuario", userId)
                Session.Add("NombreUsuario", .Item("Nombre") & " " & .Item("ApellidoPaterno") & " " & .Item("ApellidoMaterno"))
                Session.Add("PuestoUsuario", IIf(puesto = "-", "", puesto))

                'Se obtienen los permisos del usuario
                Dim permisosObj As New Permisos
                permisosObj.ConsultarPermisos(Session("IdUsuario"), .Item("IdGrupo"))
                Session("Permisos") = permisosObj

                ' Se obtiene el menú
                Dim menuObj As New CMenu
                menuObj.CargarMenu(Session("IdUsuario"), .Item("IdGrupo"))
                ' menuObj.CargarSubMenu(Session("IdUsuario"))
                Session("Menu") = menuObj

                ' Limpia las variables de control del menú
                Session("IdFuncion") = -1
                Session("IdAccion") = -1
                seccionDatos.LimpiarSeleccion(Session)

                'Se agrega Username a las cookies
                If chkRecordar.Checked Then
                    Response.Cookies.Add(New HttpCookie("Username", username))
                    Response.Cookies("Username").Expires = Now.AddMonths(1)
                Else
                    Response.Cookies.Add(New HttpCookie("Username", username))
                    Response.Cookies("Username").Expires = #1/1/2000# ' Elimina la cookie
                End If

                'Se redirecciona
                FormsAuthentication.RedirectFromLoginPage(username, False)
            End With
        Else
            'Si no encontró al usuario se manda el aviso de error
            ConfigureNotification("AutoSigue", "El Usuario o la Contraseña es Incorrecta. Vuelve a Intentar", 3000)
        End If
    End Sub

    Protected Function MeterIdApplication(UserId As String) As Boolean
        Dim hayError As Boolean = False

        ' Mete al usuario en el listado de Id's que se mantiene en el application

        Try
            Application.Lock()

            'Genera un arreglo con los id de los usuarios en session
            Dim ArregloID() As String = Application("usuarios").ToString().Split({"|"}, StringSplitOptions.RemoveEmptyEntries)

            'Busca al usuario entre los usuarios con sesión iniciada
            For Each id As String In ArregloID
                If id = UserId Then 'Si encuentra al usuario 
                    Throw New Exception()
                End If
            Next

            'Se agrega al usuario en la lista de los usuarios que han inicido sesión
            Application("Usuarios") = Application("Usuarios") & UserId & "|"

        Catch ex As Exception
            hayError = True

        Finally
            Application.UnLock()
        End Try

        'Manda mensaje si ya inició sesión
        If hayError Then
            RadWindowManager.RadAlert("El usuario " & txtUsername.Text & " ya inició sesión.", 400, 200, "AutoSigue", Nothing)
            Return False
        End If

        Return True
    End Function

End Class
