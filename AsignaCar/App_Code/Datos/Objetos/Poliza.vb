Imports Microsoft.VisualBasic

Public Class CPoliza
    Public Id As Integer
    Public NumPoliza As String
    Public IdAseguradora As Integer
    Public FecIniVigencia As Date
    Public FecFinVigencia As Date
    Public IdTipoCobertura As Integer
    Public Telefono1 As String
    Public Telefono2 As String
    Public FecPago As Date
    Public IdTipoPago As Integer
    Public CostoAnual As Double
    Public Mensualidad As Double
    Public AgenteSeguros As String
    Public Individual As Boolean

    Public Cambio_FecPago As Boolean
End Class

Public Class CPolizas_Incisos
    Public IdPoliza As Integer
    Public Inciso(-1) As String
    Public IdVehiculo(-1) As Integer
End Class

Public Class Polizas_MotivoBaja
    Public Id As Integer
    Public Nombre As String
End Class
