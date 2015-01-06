Imports Microsoft.VisualBasic

Public Class CReembolso
    Public IdServicio As Integer

    Public GastoAccesorios As Double
    Public GastoAiportfee As Double
    Public GastoConductor As Double
    Public Gastodanos As Double
    Public GastoDias As Double
    Public GastoDropoff As Double
    Public GastoGasolina As Double
    Public Gastomultas As Double

    Public CargoAccesorios As Double
    Public CargoAiportfee As Double
    Public CargoConductor As Double
    Public Cargodanos As Double
    Public CargoDias As Double
    Public CargoDropoff As Double
    Public CargoGasolina As Double
    Public Cargomultas As Double
    Public FormaPago As Integer
    Public Banco As Integer
    Public Cuenta As String
    Public Sucursal As String
    Public Afavor As Integer
    Public Beneficiario As String
    Public tOTAL As Double

End Class

Public Class CReembolsoAutorizacion
    Public IdServicio As Integer
    Public StatusReembolso As Integer
    Public Observaciones As String
    Public user As Integer

End Class

Public Class CReembolsotermino
    Public IdServicio As Integer
    Public BancoTransferencia As Integer
    Public FechaTransferencia As Date
    Public ReferenciaTransferencia As String
End Class

Public Class CReembolsoContabilidad
    Public PolizaContable As String
    Public IdServicio As Integer
End Class
