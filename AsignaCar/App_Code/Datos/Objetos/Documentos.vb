Imports Microsoft.VisualBasic

Public Class CDocSisLoc
    Public IdVehiculo As Integer
    Public Costo As Single
    Public FecVencimiento As Date
End Class

Public Class CDocArrendamiento
    Public IdVehiculo As Integer
    Public NombreArrendadora As String
    Public NumContrato As String
    Public CostoMensualidad As Double
    Public ValorResidual As Double
    Public FecInicio As Date
    Public FeTermino As Date
    Public PeriodoPago As Integer
End Class

Public Class CDocTarjetaCirculacion
    Public IdVehiculo As Integer
    Public Costo As Single
    Public FecVencimiento As Date
End Class

Public Class CDocTenencia
    Public IdVehiculo As Integer
    Public Costo As Single
    Public FecVencimiento As Date
End Class

Public Class CDocVerificacion
    Public IdVehiculo As Integer
    Public Costo As Single
    Public FecVencimiento As Date
End Class
