Imports Microsoft.VisualBasic
Imports Acceso_a_Datos
Imports System.Data
Imports System.Data.SqlClient

Public Class Datos_General


#Region "Alarmas"

    Public Function Consultar_TiposAlarmas(ByVal usr As Integer, ByVal id As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            'Se crean los parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@Id", id))
            datos.Consulta_SP("Select_TiposAlarmas @Id", res.DataTable)

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("Datos_General.vb", "Select_TiposAlarmas", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function

    Public Function Actualizar_TiposAlarmas(ByVal usr As Integer, ByVal tipoAlarma As TipoAlarma) As Resultado
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try

            'Eliminamos datos anteriores de perfiles
            datos = New ObjDatos
            datos.sqlParameters.Add(New SqlParameter("@Id", tipoAlarma.Id))
            datos.sqlParameters.Add(New SqlParameter("@EnviarDiasAntes", tipoAlarma.EnviarDiasAntes))
            datos.sqlParameters.Add(New SqlParameter("@EnviarEmail", tipoAlarma.EnviarEmail))
            datos.sqlParameters.Add(New SqlParameter("@EnviarSMS", tipoAlarma.EnviarSMS))
            datos.sqlParameters.Add(New SqlParameter("@Activo", tipoAlarma.Activo))

            datos.Comando_SP("Update_TiposAlarmas @Id, @EnviarDiasAntes, @EnviarSMS, @EnviarEmail, @Activo", res.DataTable)

            ' Graba la auditoria
            Auditoria.Registrar(usr, 1033, tipoAlarma.Id)
        Catch ex As Validacion_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            ''Se regresan y registran los datos del error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

            Logs.LogError("Datos_General.vb", "Update_TiposAlarmas", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function

    Public Function Consultar_Alarmas_Perfiles(ByVal usr As Integer, ByVal idTipoAlarma As Integer, ByVal idPerfil As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            'Se crean los parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@IdTipoAlarma", idTipoAlarma))
            datos.sqlParameters.Add(New SqlParameter("@IdPerfil", idPerfil))
            datos.Consulta_SP("Select_AlarmasPerfiles @IdTipoAlarma, @IdPerfil", res.DataTable)

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("Datos_General.vb", "Select_AlarmasPerfiles", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function

    Public Function Actualizar_Alarmas_Perfiles(ByVal usr As Integer, ByVal alarmaperf As CAlarmas_Perfiles) As Resultado
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try

            datos.BeginTransaction()

            'Eliminamos datos anteriores de perfiles
            datos.sqlParameters.Add(New SqlParameter("@IdTipoAlarma", alarmaperf.IdTipoAlarma))
            datos.sqlParameters.Add(New SqlParameter("@IdPerfil", -1))

            datos.Comando_SP_Transaccion("Delete_AlarmasPerfiles @IdTipoAlarma, @IdPerfil", res.DataTable)

            'Grabamos los nuevos alarma_perfiles
            For Each idPerfil As Integer In alarmaperf.Perfiles
                datos.sqlParameters.Add(New SqlParameter("@IdTipoAlarma", alarmaperf.IdTipoAlarma))
                datos.sqlParameters.Add(New SqlParameter("@IdPerfil", idPerfil))
                datos.Comando_SP_Transaccion("Insert_AlarmasPerfiles @IdTipoAlarma, @IdPerfil", res.DataTable)
            Next

            datos.Commit()

            ' Graba la auditoria
            Auditoria.Registrar(usr, 1034, alarmaperf.IdTipoAlarma)
        Catch ex As Validacion_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

            If datos.TransaccionIniciada Then datos.Rollback()

        Catch ex As Exception
            ''Se regresan y registran los datos del error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

            If datos.TransaccionIniciada Then datos.Rollback()

            Logs.LogError("Datos_General.vb", "Update_Alarmas_Perfiles", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function




    Public Function Consultar_Detalle_Envio_Alarmas(ByVal IdTipoAlarma As Short) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            'Se crean los parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@IdTipoAlarma", IdTipoAlarma))
            datos.Consulta_SP("Select_Detalle_Envio_Alarmas @IdTipoAlarma", res.DataTable)

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("Datos_General.vb", "Select_Detalle_Envio_Alarmas", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function

    Public Function Consultar_Usuarios_Enviar_Alarma(ByVal IdTipoAlarma As Short) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            'Se crean los parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@IdTipoAlarma", IdTipoAlarma))
            datos.Consulta_SP("Select_Usuarios_Enviar_Alarma @IdTipoAlarma", res.DataTable)

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("Datos_General.vb", "Select_Usuarios_Enviar_Alarma", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function

    Public Function Actualizar_Envio_Alarma(envio As CEnvioAlarma) As Resultado
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try

            ' Marca una alarma como enviada
            datos.sqlParameters.Add(New SqlParameter("@IdAlarma", envio.IdAlarma))
            datos.sqlParameters.Add(New SqlParameter("@NumEnvio", envio.NumEnvio))
            datos.sqlParameters.Add(New SqlParameter("@Desactivar", envio.Desactivar))

            datos.Comando_SP_Transaccion("Update_Alarma_Envio @IdAlarma, @NumEnvio, @Desactivar", res.DataTable)

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            ''Se regresan y registran los datos del error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

            Logs.LogError("Datos_General.vb", "Update_Alarma_Envio", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function

    Public Function Insertar_Alarma(alarma As CAlarma) As Resultado
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try

            ' Marca una alarma como enviada
            datos.sqlParameters.Add(New SqlParameter("@IdTipoAlarma", alarma.IdTipoAlarma))
            datos.sqlParameters.Add(New SqlParameter("@IdBase1", alarma.IdBase1))
            datos.sqlParameters.Add(New SqlParameter("@IdBase2", alarma.IdBase2))
            datos.sqlParameters.Add(New SqlParameter("@FecVencimiento", alarma.FecVencimiento))
            datos.sqlParameters.Add(New SqlParameter("@EnvioInmediato", alarma.EnvioInmediato))

            datos.Comando_SP_Transaccion("Insert_Alarma @IdTipoAlarma, @IdBase1, @IdBase2, @FecVencimiento, @EnvioInmediato", res.DataTable)

            res.Dato = res.DataTable.Rows(0)(2) ' Id de la alarma generada

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            ''Se regresan y registran los datos del error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

            Logs.LogError("Datos_General.vb", "Insert_Alarma", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function


    Public Function Consultar_Detalle_Envio_Alarma_Inmediata(ByVal IdAlarma As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            'Se crean los parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@IdAlarma", IdAlarma))
            datos.Consulta_SP("Select_Detalle_Envio_Alarma_Inmediata @IdAlarma", res.DataTable)

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("Datos_General.vb", "Select_Detalle_Envio_Alarma_Inmediata", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function


#End Region

#Region "Parámetros"

    Public Function Consultar_Parametros(usr As Integer, id As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            'Se crean los parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@Id", id))
            datos.Consulta_SP("Select_Parametros @Id", res.DataTable)

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("Datos_General.vb", "Select_Parametros", ex.Message, ex.StackTrace)
        End Try

        Return res
    End Function

    Public Function Actualizar_Parametros(usr As Integer, parametro As CParametro) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            'Se crean los parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@Id", parametro.Id))
            datos.sqlParameters.Add(New SqlParameter("@Valor", parametro.Valor))
            datos.Comando_SP("Update_Parametros @Id, @Valor", res.DataTable)

            ' Graba la auditoria
            Auditoria.Registrar(usr, 1019, parametro.Id & "-" & parametro.Valor)

        Catch ex As Validacion_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("Datos_General.vb", "Update_Parametros", ex.Message, ex.StackTrace)
        End Try

        'Regresa Resultado2
        Return res
    End Function

#End Region

#Region "Busquedas Iniciales desde el MasterPage"

    Public Function Buscar_Vehiculo(usr As Integer, MVA As String) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            'Se crean los parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@MVA", MVA))
            datos.Consulta_SP("Select_Vehiculo @MVA", res.DataTable)

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("Datos_General.vb", "Buscar_Vehiculo", ex.Message, ex.StackTrace)
        End Try

        Return res
    End Function

    Public Function Buscar_Contrato(usr As Integer, NumContrato As String) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            'Se crean los parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@NumContrato", NumContrato))
            datos.Consulta_SP("Select_Contrato @NumContrato", res.DataTable)

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("Datos_General.vb", "Buscar_Contrato", ex.Message, ex.StackTrace)
        End Try

        Return res
    End Function

    Public Function Buscar_Servicio(usr As Integer, NumServicio As String) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            'Se crean los parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@NumServicio", NumServicio))
            datos.Consulta_SP("Select_Servicio @NumServicio", res.DataTable)

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("Datos_General.vb", "Buscar_Servicio", ex.Message, ex.StackTrace)
        End Try

        Return res
    End Function


#End Region

End Class
