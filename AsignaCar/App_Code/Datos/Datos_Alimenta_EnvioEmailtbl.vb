Imports Microsoft.VisualBasic
Imports Acceso_a_Datos
Imports System.Data
Imports System.Data.SqlClient

Public Class Datos_Alimenta_EnvioEmailtbl
#Region "Alimentador de EnvioEmailSMS_tbl"

    'Public Function Insertar_EnvioEmailSMS(ByVal IdUsuario As Integer, ByVal servicio As ServicioEmailSMS) As Resultado
    '    Dim res As New Resultado 'Objeto para resultados
    '    Dim datos As New ObjDatos 'Objetod para mandar llamar el ws


    '    Try
    '        'Se crea parámetro y se manda llamar el ws
    '        datos.sqlParameters.Add(New SqlParameter("@IdUsuario", IdUsuario))
    '        datos.sqlParameters.Add(New SqlParameter("@NumServicio", servicio.reporte_numero))
    '        datos.sqlParameters.Add(New SqlParameter("@NumPoliza", servicio.reporte_poliza))
    '        datos.sqlParameters.Add(New SqlParameter("@Email", servicio.enviomail))
    '        datos.sqlParameters.Add(New SqlParameter("@Telefono", servicio.enviotelefono))
    '        datos.sqlParameters.Add(New SqlParameter("@Etapa", servicio.envioetapa))
    '        datos.sqlParameters.Add(New SqlParameter("@EmailEnviado", servicio.mailenviado))
    '        datos.sqlParameters.Add(New SqlParameter("@SMSEnviado", servicio.smsenviado))

    '        datos.Comando_SP("Insert_EnvioMailSMS @IdUsuario, @NumServicio, @NumPoliza, @Email, @Telefono, @Etapa, @EmailEnviado, @SMSEnviado", res.DataTable)

    '        ' Verifica si todo salió bien:
    '        'res.Dato = res.DataTable.Rows(0)(2) 'Aqui devuelve el Id
    '        'Dim NumServicio As String = res.DataTable.Rows(0)(3)


    '        ' Graba la auditoria
    '        'Auditoria.Registrar(usr, 55, res.Dato & "-" & NumServicio)
    '    Catch ex As Validacion_Exception
    '        'Se regresan y registran los datos de error
    '        res.Estatus = Estatus.Error
    '        res.ErrorDesc = ex.Message

    '    Catch ex As AccesoDatos_Exception
    '        'Se regresan y registran los datos de error
    '        res.Estatus = Estatus.Error
    '        res.ErrorDesc = ex.Message

    '    Catch ex As Exception
    '        ''Se regresan y registran los datos del error
    '        res.Estatus = Estatus.Error
    '        res.ErrorDesc = ex.Message
    '        Logs.LogError("CheckIn.vb", "Insert_EnvioMailSMS", ex.Message, ex.StackTrace)
    '    End Try
    '    Return res
    'End Function
#End Region
End Class
