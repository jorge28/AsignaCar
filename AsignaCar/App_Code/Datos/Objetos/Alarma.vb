Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports Acceso_a_Datos

''' <summary>
''' Alarmas que maneja el sistema
''' </summary>
''' <remarks></remarks>
Public Enum EnumTiposAlarmas
    Empty
    Doc_Tarjetas_Circulacion = 1
    Doc_Tenencias = 2
    Doc_Verificacion = 3
    Doc_Arrendamiento = 4
    Doc_Sistema_Localizacion = 5
    Vencimiento_Poliza = 6
    Vehiculo_N_Kilometros_Recorridos = 7
    Pago_de_Poliza = 8
    Ocurrencia_de_un_Siniestro = 9
    Baja_de_Vehiculo_Se_Requiere_Baja_de_Poliza = 10
    Vehiculo_N_Años_Uso = 11
    Mantenimiento_Costo_Mayor_Limite = 12
    Alta_de_Servicio = 13

    Solicita_autorizacion_de_Reembolso = 14
    Autorizacion_de_Reembolsos = 15
    Rechazo_de_Pago = 16
    Rechazo_de_Reembolsos = 17 '' jrad marzo 2013
    Termino_de_Reembolso = 18
    Numero_Comprobacion_Agregado = 19



End Enum

Public Class TipoAlarma
    Public Id As Integer
    Public Nombre As String
    Public EnviarDiasAntes As Integer
    Public EnviarSMS As Boolean
    Public EnviarEmail As Boolean
    Public Activo As Boolean
End Class

Public Class CAlarmas_Perfiles
    Public IdTipoAlarma As EnumTiposAlarmas
    Public Perfiles(-1) As Integer
End Class

Public Class CEnvioAlarma
    Public IdAlarma As Integer
    Public NumEnvio As Short
    Public Desactivar As Boolean
End Class

Public Class CAlarma
    Public IdTipoAlarma As EnumTiposAlarmas
    Public IdBase1, IdBase2 As Integer
    Public FecVencimiento As Date
    Public EnvioInmediato As Boolean
End Class