Imports Microsoft.VisualBasic

Public Enum EnumParametros
    Vacio ' 0
    Dias_Atras_Busqueda_Servicios_Una_Misma_Poliza ' 1
    Numero_Maximo_Incisos_Poliza ' 2
    Monto_Maximo_Gasto_Sin_Pedir_Autorizacion ' 3
    Kilometraje_Maximo_Programacion_Mantenimientos '4
    Kilometraje_Envio_Alerta_Avisando_KM_Recorridos_Auto '5
    Años_Envio_Alerta_Avisando_Tiempo_Vida_Auto '6
    Monto_Maximo_Mantenimiento_Sin_Enviar_Alerta '7
    Monto_Maximo_Mantenimiento_Sin_Pedir_Autorizacion '8
    Correo_Para_Enviar_XML_Datos_Facturacion '9
End Enum


Public Class Parametros
    ' Obtiene el valor de un parámetro
    Public Shared Function getParametro(ByRef App As HttpApplicationState, ByVal param As EnumParametros) As String
        Return App("_param_" & param)
    End Function

    ' Establece el valor de un parámetro
    Public Shared Sub setParametro(ByRef App As HttpApplicationState, ByVal param As EnumParametros, ByVal valor As String)
        App.Lock()

        Try
            App("_param_" & param) = valor
        Catch ex As Exception
        Finally
            App.UnLock()
        End Try
    End Sub

    Public Shared Sub CargarParametros(ByRef App As HttpApplicationState)
        ' Carga la lista de parámetros y sus valores
        Dim serv As New Datos_General
        Dim resp As Resultado

        resp = serv.Consultar_Parametros(-1, -1)

        App.Lock()
        Try
            ' Los mete en sesión
            For Each dr As System.Data.DataRow In resp.DataTable.Rows
                App("_param_" & dr("Id")) = dr("Valor")
            Next

        Catch ex As Exception
        Finally
            App.UnLock()
        End Try
    End Sub
End Class
