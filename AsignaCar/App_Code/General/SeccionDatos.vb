Imports Microsoft.VisualBasic

Public Class SeccionDatos

    Public Sub ActualizarSeccion(ByRef master As MasterPage, ByRef session As HttpSessionState)
        'Dim lbl1 As Label = master.FindControl("lblSeleccion1")
        'Dim lbl2 As Label = master.FindControl("lblSeleccion2")
        'Dim lbl3 As Label = master.FindControl("lblSeleccion3")

        'lbl1.Text = session("Texto_Seleccion1")
        'lbl2.Text = session("Texto_Seleccion2")
        'lbl3.Text = session("Texto_Seleccion3")

        'Dim btn As ImageButton = master.FindControl("btnSeleccionar")
        'btn.Visible = (lbl1.Text <> "")
    End Sub

    Public Sub PrepararTexto_Vehiculo(ByRef session As HttpSessionState, mva As String, placas As String, marca As String, submarca As String, modelo As String)
        'session("Texto_Seleccion1") = "<b>MVA:</b> " & mva & "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Placas:</b> " & placas
        'session("Texto_Seleccion2") = "<b>Descripción:</b> " & marca & " " & submarca & " " & modelo
        'session("Texto_Seleccion3") = ""
    End Sub

    Public Sub PrepararTexto_Mantenimiento(ByRef session As HttpSessionState, mva As String, placas As String, marca As String, submarca As String, modelo As String, ConsecMantenimiento As String)
        'session("Texto_Seleccion1") = "<b>MVA:</b> " & mva & "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Placas:</b> " & placas
        'session("Texto_Seleccion2") = "<b>Descripción:</b> " & marca & " " & submarca & " " & modelo
        session("Texto_Seleccion3") = "<b>Num. Mantenimiento:</b> " & ConsecMantenimiento
    End Sub

    Public Sub PrepararTexto_Mantenimiento(ByRef session As HttpSessionState, ConsecMantenimiento As String)
        session("Texto_Seleccion3") = "<b>Num. Mantenimiento:</b> " & ConsecMantenimiento
    End Sub

    Public Sub PrepararTexto_SalidaImproductiva(ByRef session As HttpSessionState, mva As String, placas As String, marca As String, submarca As String, modelo As String, NumSalida As String)
        'session("Texto_Seleccion1") = "<b>MVA:</b> " & mva & "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Placas:</b> " & placas
        'session("Texto_Seleccion2") = "<b>Descripción:</b> " & marca & " " & submarca & " " & modelo
        session("Texto_Seleccion3") = "<b>Num. Salida:</b> " & NumSalida
    End Sub
    Public Sub PrepararTexto_SalidaImproductiva(ByRef session As HttpSessionState, NumSalida As String)
        session("Texto_Seleccion3") = "<b>Num. Salida:</b> " & NumSalida
    End Sub

    Public Sub PrepararTexto_Siniestro(ByRef session As HttpSessionState, mva As String, placas As String, marca As String, submarca As String, modelo As String, siniestro As String)
        'session("Texto_Seleccion1") = "<b>MVA:</b> " & mva & "&nbsp;&nbsp;<b>Placas:</b> " & placas
        'session("Texto_Seleccion2") = "<b>Descripción:</b> " & marca & " " & submarca & " " & modelo
        session("Texto_Seleccion3") = "<b>Siniestro:</b> " & siniestro
    End Sub
    Public Sub PrepararTexto_Siniestro(ByRef session As HttpSessionState, siniestro As String)
        session("Texto_Seleccion3") = "<b>Siniestro:</b> " & siniestro
    End Sub

    Public Sub PrepararTexto_Proveedor(ByRef session As HttpSessionState, nombre_comercial As String, rfc As String, razon_social As String)
        session("Texto_Seleccion1") = "<b>Nombre Comercial:</b> " & nombre_comercial
        session("Texto_Seleccion2") = "<b>RFC:</b> " & rfc
        session("Texto_Seleccion3") = "<b>Razón Social:</b> " & razon_social
    End Sub

    Public Sub PrepararTexto_Grupos(ByRef session As HttpSessionState, grupo As String)
        session("Texto_Seleccion1") = "<b>Grupo:</b> " & grupo
        session("Texto_Seleccion2") = ""
        session("Texto_Seleccion3") = ""
    End Sub

    Public Sub PrepararTexto_Servicio(ByRef session As HttpSessionState, servicio As String)
        'session("Texto_Seleccion1") = "<b>No. Servicio:</b> " & servicio
        'session("Texto_Seleccion2") = ""
        'session("Texto_Seleccion3") = ""
    End Sub

    Public Sub PrepararTexto_Permisos(ByRef session As HttpSessionState, perfil As String, Optional funcion As String = "")
        session("Texto_Seleccion1") = "<b>Perfil:</b> " & perfil
        If funcion = "" Then
            session("Texto_Seleccion2") = ""
        Else
            session("Texto_Seleccion2") = "<b>Función:</b> " & funcion
        End If
        session("Texto_Seleccion3") = ""
    End Sub

    Public Sub PrepararTexto_Poliza(ByRef session As HttpSessionState, poliza As String)
        session("Texto_Seleccion1") = "<b>Póliza:</b> " & poliza
        session("Texto_Seleccion2") = ""
        session("Texto_Seleccion3") = ""
    End Sub

    Public Sub PrepararTexto_Contrato(ByRef session As HttpSessionState, ByVal contrato As String, ByVal servicio As String)
        '    session("Texto_Seleccion1") = ("No. de Contrato:" & " " & session("NumContrato"))
        '    session("Texto_Seleccion2") = ("No. de Servicio:" & " " & (session("NumServ") Or session("Servicio")))
        '    session("Texto_Seleccion3") = ""
    End Sub

    Public Sub LimpiarTexto(ByRef session As HttpSessionState)
        session("Texto_Seleccion1") = ""
        session("Texto_Seleccion2") = ""
        session("Texto_Seleccion3") = ""
    End Sub

    Public Sub LimpiarSeleccion(ByRef session As HttpSessionState)
        'session("IdVehiculo") = -1
        'session("IdPoliza") = -1
        'session("IdProveedor") = -1
        'session("IdServicio") = -1
        'session("IdContrato") = -1
        'session("IdReembolso") = -1
        'session("ConsecSiniestro") = -1
        'session("ConsecMantenimiento") = -1
        'session("ConsecSalidaImproductiva") = -1
    End Sub

End Class
