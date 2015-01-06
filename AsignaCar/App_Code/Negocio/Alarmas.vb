Imports Microsoft.VisualBasic
Imports System.Data

Public Class EnviadorAlarmas

    Public Function Mensaje_Mantenimiento_CostoMayorLimite(mva As String, consec As String) As String
        Dim cad As String

        cad = "El mantenimiento número " & consec & " del vehículo " & mva & _
            " ha excedido el monto máximo."

        Return cad
    End Function


    Public Function Mensaje_OcurrenciaSiniestro(mva As String, consec As String, NumSiniestro As String) As String
        Dim cad As String

        cad = "Se ha registrado el siniestro número " & consec & _
            " del vehículo " & mva & " con número " & NumSiniestro

        Return cad
    End Function


    Public Function Mensaje_AltaServicio(NumServicio As String) As String
        Dim cad As String

        cad = "Se ha registrado un nuevo servicio con número " & NumServicio

        Return cad
    End Function


    Public Function Mensaje_Baja_Vehiculo_Debe_Eliminar_Poliza(mva As String, NumPoliza As String, Inciso As String) As String
        Dim cad As String

        cad = "Se ha dado de baja el vehículo " & mva & _
            ", debe darse de baja el inciso " & Inciso & " de la póliza " & NumPoliza

        Return cad
    End Function

    Public Function Mensaje_DocTenencia(mva As String, consec As String, dias As Integer) As String
        Dim cad As String

        If dias < 2 Then
            cad = "La tenencia " & consec & " del vehículo " & mva & _
                  " debe pagarse de inmediato."
        Else
            cad = "La tenencia " & consec & " del vehículo " & mva & _
                  " vencerá en " & dias & " días."
        End If

        Return cad
    End Function

    Public Function Mensaje_DocTarjetaCirculacion(mva As String, consec As String, dias As Integer) As String
        Dim cad As String

        If dias < 2 Then
            cad = "La tarjeta de circulación " & consec & " del vehículo " & mva & _
                  " debe renovarse de inmediato."
        Else
            cad = "La tarjeta de circulación " & consec & " del vehículo " & mva & _
                  " vencerá en " & dias & " días."
        End If

        Return cad
    End Function

    Public Function Mensaje_DocVerificación(mva As String, consec As String, dias As Integer) As String
        Dim cad As String

        If dias < 2 Then
            cad = "La verificación " & consec & " del vehículo " & mva & _
                  " debe realizarse de inmediato."
        Else
            cad = "La verificación " & consec & " del vehículo " & mva & _
                  " debe realizarse a mas tardar en " & dias & " días."
        End If

        Return cad
    End Function

    Public Function Mensaje_DocSisLoc(mva As String, consec As String, dias As Integer) As String
        Dim cad As String

        If dias < 2 Then
            cad = "El sistema de localización " & consec & " del vehículo " & mva & _
                  " debe renovarse de inmediato."
        Else
            cad = "El sistema de localización " & consec & " del vehículo " & mva & _
                  " vencerá en " & dias & " días."
        End If

        Return cad
    End Function

    Public Function Mensaje_DocArrendamiento(mva As String, consec As String, dias As Integer, arrendadora As String, contrato As String) As String
        Dim cad As String

        If dias < 2 Then
            cad = "El contrato de arrendamiento " & consec & " del vehículo " & mva & _
                  " con número " & contrato & " de " & arrendadora & " debe renovarse de inmediato."
        Else
            cad = "El contrato de arrendamiento " & consec & " del vehículo " & mva & _
                  " con número " & contrato & " de " & arrendadora & " vencerá en " & dias & " días."
        End If

        Return cad
    End Function

    Public Function Mensaje_VencimientoPoliza(poliza As String, dias As Integer) As String
        Dim cad As String

        If dias < 2 Then
            cad = "La póliza " & poliza & " debe renovarse de inmediato."
        Else
            cad = "La póliza " & poliza & " se vencerá en " & dias & " días."
        End If

        Return cad
    End Function

    Public Function Mensaje_PagoPoliza(poliza As String, dias As Integer) As String
        Dim cad As String

        If dias < 2 Then
            cad = "La póliza " & poliza & " debe pagarse de inmediato."
        Else
            cad = "La póliza " & poliza & " debe pagarse en " & dias & " días."
        End If

        Return cad
    End Function

    Public Function Mensaje_Vehiculo_N_Años_Uso(MVA As String, AñosUso As Short, dias As Integer) As String
        Dim cad As String

        If dias < 2 Then
            cad = "El vehículo " & MVA & " ha cumplido " & AñosUso & " años de uso."
        Else
            cad = "El vehículo " & MVA & " cumplirá " & AñosUso & " años de uso dentro de " & dias & " días."
        End If

        Return cad
    End Function

    Public Function Mensaje_Vehiculo_N_KM_Recorridos(MVA As String, Km As Integer) As String
        Dim cad As String

        cad = "El vehículo " & MVA & " ya tiene " & Km & "km recorridos"

        Return cad
    End Function

    ''ISRA
   
    Public Function Mensaje_reembolsos(ByVal NumServicio As String, ByVal AsegNombre As String, ByVal UsuarioSolicita As String) As String
        Dim cad As String

        cad = "El usuario : " & UsuarioSolicita & " a generado una Solicitud de Reembolso con el número: " & NumServicio & _
            " y el beneficiario es: " & AsegNombre

        Return cad
    End Function


    Public Function Mensaje_reembolsos_Autoriza(ByVal NumServicio As String, ByVal AsegNombre As String, ByVal Monto As String, ByVal Banco As String, ByVal Cuenta As String, ByVal Usuario As String) As String
        Dim cad As String

        cad = "El Usuario: " & Usuario & " ha autorizado un reembolso con el número " & NumServicio & _
            " y el beneficiario es: " & AsegNombre & " con el Total a Reembolsar: " & Monto & _
            " en el Banco: " & Banco & " a la Cuenta: " & Cuenta
        Return cad
    End Function

    Public Function Mensaje_reembolsos_rechaza(ByVal NumServicio As String, ByVal AsegNombre As String, ByVal UsuarioAutoriza As String, ByVal Observaciones As String) As String
        Dim cad As String

        cad = "El Usuario: " & UsuarioAutoriza & " ha rechazado un reembolso con el Número de Servicio: " & NumServicio & _
            " y beneficiario es: " & AsegNombre & " por motivo de: " & Observaciones

        Return cad
    End Function

    Public Function Mensaje_reembolsos_contabilidad(ByVal NumServicio As String, ByVal PolizaContable As String, ByVal UsuarioConta As String) As String
        Dim cad As String

        cad = "El Usuario: " & UsuarioConta & " ha agregado el Número de Comprobación: " & PolizaContable & _
            " al Reembolso del Servicio: " & NumServicio
        Return cad
    End Function
    ''Isra
    Public Function Mensaje_reembolsos_terminacion(ByVal NumServicio As String, ByVal AsegNombre As String, ByVal UsuarioTermina As String, ByVal ReferenciaTransferencia As String, ByVal FechaTransferencia As Date, ByVal TotalReembolso As String, ByVal BancoTransferencia As String) As String
        Dim cad As String

        cad = "El Usuario: " & UsuarioTermina & " ha dado por termino un reembolso con el número " & NumServicio & _
            " y el beneficiario es: " & AsegNombre & " Con los Datos Siguientes: " & " " & " Número de Autorizacion: " & ReferenciaTransferencia & _
            " Fecha del Deposito: " & FechaTransferencia & " Monto Depositado: " & TotalReembolso & " Banco de la Transferencia: " & BancoTransferencia
        Return cad
    End Function

    Public Function Mensaje_rechazo_pago(ByVal NumServicio As String, ByVal Proveedor As String) As String
        Dim cad As String

        cad = "Se ha registrado un rechazo de pago con el número " & NumServicio & _
            " y el Proveedor es: " & Proveedor

        Return cad
    End Function



    ''' <summary>
    ''' Obtiene la lista de correos a los que se enviará la alarma
    ''' </summary>
    ''' <param name="dt">datatable que contiene los registros con los correos</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ConstruirListaCorreos(ByRef dt As DataTable) As String
        Dim cad As String = ""

        ' Arma la lista de correos o de nexteles a los que se les va a enviar el mensaje
        For i As Integer = 0 To dt.Rows.Count - 1
            If Trim(dt.Rows(i)("Email")) <> "" And dt.Rows(i)("EnviarEmail") Then
                cad &= dt.Rows(i)("Email") & ","
            End If
        Next
        If cad.Length > 0 Then
            cad = Left(cad, cad.Length - 1)
        End If

        Return cad
    End Function

    ''' <summary>
    ''' Obtiene la lista de telefonos de nextel a los que se enviará la alarma
    ''' </summary>
    ''' <param name="dt">datatable que contiene los registros con los números de teléfono</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ConstruirListaNextel(ByRef dt As DataTable) As String
        Dim cad As String = ""

        ' Arma la lista de correos o de nexteles a los que se les va a enviar el mensaje
        For i As Integer = 0 To dt.Rows.Count - 1
            If Trim(dt.Rows(i)("TelNextel")) <> "" And dt.Rows(i)("EnviarSMS") Then
                cad &= dt.Rows(i)("TelNextel") & "@MSGNEXTEL.COM.MX,"
            End If
        Next
        If cad.Length > 0 Then
            cad = Left(cad, cad.Length - 1)
        End If

        Return cad
    End Function



    Public Sub EnviarAlarma(tipo As EnumTiposAlarmas, ByRef Application As HttpApplicationState)
        Dim correos, nexteles As String
        Dim mensaje As String = ""
        Dim titulo As String = ""
        Dim servGeneral As New Datos_General
        Dim resPerfiles As New Resultado
        Dim resAlarma As New Resultado

        Dim objEmail As New Email
        Dim objNextel As New Nextel

        Dim envio As New CEnvioAlarma

        Try
            ' Consulta los perfiles a los que se les tiene que enviar la alarma
            resPerfiles = servGeneral.Consultar_Usuarios_Enviar_Alarma(tipo)
            correos = ConstruirListaCorreos(resPerfiles.DataTable)
            nexteles = ConstruirListaNextel(resPerfiles.DataTable)

            If correos <> "" Or nexteles <> "" Then
                ' Consulta el detalle de la alarma
                resAlarma = servGeneral.Consultar_Detalle_Envio_Alarmas(tipo)
                For Each dr As DataRow In resAlarma.DataTable.Rows
                    ' Envía la alarma
                    Select Case tipo
                        Case EnumTiposAlarmas.Doc_Tenencias
                            mensaje = Mensaje_DocTenencia(dr("MVA"), dr("Consec"), dr("DiasParaVencimiento"))
                            titulo = "Vencimiento de Tenencia"
                        Case EnumTiposAlarmas.Doc_Tarjetas_Circulacion
                            mensaje = Mensaje_DocTarjetaCirculacion(dr("MVA"), dr("Consec"), dr("DiasParaVencimiento"))
                            titulo = "Vencimiento de Tarjeta de Circulación"
                        Case EnumTiposAlarmas.Doc_Verificacion
                            mensaje = Mensaje_DocVerificación(dr("MVA"), dr("Consec"), dr("DiasParaVencimiento"))
                            titulo = "Verificación"
                        Case EnumTiposAlarmas.Doc_Arrendamiento
                            mensaje = Mensaje_DocArrendamiento(dr("MVA"), dr("Consec"), dr("DiasParaVencimiento"), dr("NombreArrendadora"), dr("NumContrato"))
                            titulo = "Vencimiento de Contrato de Arrendamiento"
                        Case EnumTiposAlarmas.Doc_Sistema_Localizacion
                            mensaje = Mensaje_DocSisLoc(dr("MVA"), dr("Consec"), dr("DiasParaVencimiento"))
                            titulo = "Vencimiento de Sistema de Localización"
                        Case EnumTiposAlarmas.Pago_de_Poliza
                            mensaje = Mensaje_PagoPoliza(dr("NumPoliza"), dr("DiasParaVencimiento"))
                            titulo = "Pago de Póliza"
                        Case EnumTiposAlarmas.Vehiculo_N_Años_Uso
                            mensaje = Mensaje_Vehiculo_N_Años_Uso(dr("MVA"), dr("AñosUso"), dr("DiasParaVencimiento"))
                            titulo = "Vehículo con " & dr("AñosUso") & " años de uso"
                        Case EnumTiposAlarmas.Vencimiento_Poliza
                            mensaje = Mensaje_VencimientoPoliza(dr("NumPoliza"), dr("DiasParaVencimiento"))
                            titulo = "Vencimiento de Póliza"
                    End Select
                    objEmail.Enviar(Application("mailFrom"), correos, titulo, mensaje)
                    objNextel.Enviar(Application("mailFrom"), nexteles, titulo, mensaje)

                    ' Marca la alarma como enviada
                    envio.IdAlarma = dr("IdAlarma")
                    If dr("FecEnvio1") = #1/1/1900# Then
                        envio.NumEnvio = 1
                        envio.Desactivar = False
                    Else
                        envio.NumEnvio = 2
                        envio.Desactivar = True
                    End If
                    servGeneral.Actualizar_Envio_Alarma(envio)
                Next
            End If

        Catch ex As Exception
            'Se regresan y registran los datos del error
            Logs.LogError("UtilAlarmas.vb", "EnviarAlarmaInmediata", ex.Message, ex.StackTrace)
        End Try
    End Sub

    Public Sub EnviarAlarmaInmediata(tipo As EnumTiposAlarmas, ByRef Application As HttpApplicationState, Optional IdVehiculo As Integer = -1, Optional Consec As Integer = -1, Optional IdServicio As Integer = -1)
        Dim correos, nexteles As String
        Dim mensaje As String = ""
        Dim titulo As String = ""
        Dim servGeneral As New Datos_General
        Dim resPerfiles As New Resultado
        Dim resAlarma As New Resultado

        Dim objEmail As New Email
        Dim objNextel As New Nextel

        Dim alarma As New CAlarma
        Dim idAlarma As Integer

        Dim envio As New CEnvioAlarma

        Try

            ' Consulta los perfiles a los que se les tiene que enviar la alarma
            resPerfiles = servGeneral.Consultar_Usuarios_Enviar_Alarma(tipo)
            correos = ConstruirListaCorreos(resPerfiles.DataTable)
            nexteles = ConstruirListaNextel(resPerfiles.DataTable)

            If correos <> "" Or nexteles <> "" Then
                ' Inserta la alarma
                alarma.IdTipoAlarma = tipo
                alarma.FecVencimiento = #1/1/1900#
                alarma.EnvioInmediato = True
                Select Case tipo
                    Case EnumTiposAlarmas.Alta_de_Servicio
                        alarma.IdBase1 = IdServicio
                        alarma.IdBase2 = -1
                    Case EnumTiposAlarmas.Ocurrencia_de_un_Siniestro
                        alarma.IdBase1 = IdVehiculo
                        alarma.IdBase2 = Consec
                    Case EnumTiposAlarmas.Baja_de_Vehiculo_Se_Requiere_Baja_de_Poliza
                        alarma.IdBase1 = IdVehiculo
                        alarma.IdBase2 = -1
                    Case EnumTiposAlarmas.Vehiculo_N_Kilometros_Recorridos
                        alarma.IdBase1 = IdVehiculo
                        alarma.IdBase2 = -1
                    Case EnumTiposAlarmas.Mantenimiento_Costo_Mayor_Limite
                        alarma.IdBase1 = IdVehiculo
                        alarma.IdBase2 = Consec

                    Case EnumTiposAlarmas.Solicita_autorizacion_de_Reembolso '' isra -2013
                        alarma.IdBase1 = IdVehiculo
                        alarma.IdBase2 = -1

                    Case EnumTiposAlarmas.Autorizacion_de_Reembolsos '' isra -2013
                        alarma.IdBase1 = IdVehiculo
                        alarma.IdBase2 = -1
                    Case EnumTiposAlarmas.Rechazo_de_Reembolsos '' isra -2013
                        alarma.IdBase1 = IdVehiculo
                        alarma.IdBase2 = -1
                    Case EnumTiposAlarmas.Termino_de_Reembolso '' isra -2013
                        alarma.IdBase1 = IdVehiculo
                        alarma.IdBase2 = -1
                    Case EnumTiposAlarmas.Rechazo_de_Pago '' isra -2013
                        alarma.IdBase1 = IdVehiculo
                        alarma.IdBase2 = -1
                    Case EnumTiposAlarmas.Numero_Comprobacion_Agregado '' isra -2013
                        alarma.IdBase1 = IdVehiculo
                        alarma.IdBase2 = -1


                End Select
                resAlarma = servGeneral.Insertar_Alarma(alarma)
                idAlarma = resAlarma.Dato

                ' Envía la alarma
                resAlarma = servGeneral.Consultar_Detalle_Envio_Alarma_Inmediata(idAlarma)
                Dim dr As DataRow = resAlarma.DataTable.Rows(0)
                Select Case tipo
                    Case EnumTiposAlarmas.Alta_de_Servicio
                        mensaje = Mensaje_AltaServicio(dr("NumServicio"))
                        titulo = "Alta de Servicio"
                    Case EnumTiposAlarmas.Ocurrencia_de_un_Siniestro
                        mensaje = Mensaje_OcurrenciaSiniestro(dr("MVA"), dr("Consec"), dr("NumSiniestro"))
                        titulo = "Alta de Siniestro"
                    Case EnumTiposAlarmas.Baja_de_Vehiculo_Se_Requiere_Baja_de_Poliza
                        mensaje = Mensaje_Baja_Vehiculo_Debe_Eliminar_Poliza(dr("MVA"), dr("NumPoliza"), dr("Inciso"))
                        titulo = "Baja de Vehículo"
                    Case EnumTiposAlarmas.Vehiculo_N_Kilometros_Recorridos
                        mensaje = Mensaje_Vehiculo_N_KM_Recorridos(dr("MVA"), dr("Km"))
                        titulo = "Vehículo con " & dr("km") & "km recorridos."
                    Case EnumTiposAlarmas.Mantenimiento_Costo_Mayor_Limite
                        mensaje = Mensaje_Mantenimiento_CostoMayorLimite(dr("MVA"), dr("Consec"))
                        titulo = "Mantenimiento con costo mayor al límite"
                        
                    Case EnumTiposAlarmas.Solicita_autorizacion_de_Reembolso '' ISRA DIC -2013
                        mensaje = Mensaje_reembolsos(dr("NumServicio"), dr("AsegNombre"), dr("UsuarioSolicita"))
                        titulo = "Solicita Autorizacion de Reembolso para el Reporte Número:" & " " & dr("NumServicio")
                        
                    Case EnumTiposAlarmas.Autorizacion_de_Reembolsos '' ISRA DIC -2013
                        mensaje = Mensaje_reembolsos_Autoriza(dr("NumServicio"), dr("AsegNombre"), dr("TotalReembolso"), dr("Banco"), dr("Cuenta"), dr("UsuarioAutoriza"))
                        titulo = "Se Autorizó Reembolso del Reporte Número:" & " " & dr("NumServicio")
                        
                    Case EnumTiposAlarmas.Rechazo_de_Reembolsos '' ISRA DIC -2013
                        mensaje = Mensaje_reembolsos_rechaza(dr("NumServicio"), dr("AsegNombre"), dr("UsuarioAutoriza"), dr("Observaciones"))
                        titulo = "Se Rechazó Reembolso del Reporte Número:" & " " & dr("NumServicio")

                    Case EnumTiposAlarmas.Termino_de_Reembolso '' ISRA DIC -2013
                        mensaje = Mensaje_reembolsos_terminacion(dr("NumServicio"), dr("AsegNombre"), dr("UsuarioTermina"), dr("ReferenciaTransferencia"), dr("FechaTransferencia"), dr("TotalReembolso"), dr("BancoTransferencia"))
                        titulo = "Terminación de Reembolso del Reporte Número:" & " " & dr("NumServicio")

                    Case EnumTiposAlarmas.Numero_Comprobacion_Agregado '' ISRA DIC -2013
                        mensaje = Mensaje_reembolsos_contabilidad(dr("NumServicio"), dr("PolizaContable"), dr("UsuarioConta"))
                        titulo = "Número de Comprobacion de Reembolso del Reporte Número:" & " " & dr("NumServicio")

                    Case EnumTiposAlarmas.Rechazo_de_Pago '' jrad marzo -2013
                        mensaje = Mensaje_rechazo_pago(dr("NumServicio"), dr("NombreComercial"))
                        titulo = "Se Rechazó Pago del Reporte Número:" & " " & dr("NumServicio")



                End Select
                objEmail.Enviar(Application("mailFrom"), correos, titulo, mensaje)
                objNextel.Enviar(Application("mailFrom"), nexteles, titulo, mensaje)

                ' Marca la alarma como enviada
                envio.Desactivar = True
                envio.IdAlarma = idAlarma
                envio.NumEnvio = 1
                servGeneral.Actualizar_Envio_Alarma(envio)
            End If

        Catch ex As Exception
            'Se regresan y registran los datos del error
            Logs.LogError("UtilAlarmas.vb", "EnviarAlarmaInmediata", ex.Message, ex.StackTrace)
        End Try
    End Sub


End Class
