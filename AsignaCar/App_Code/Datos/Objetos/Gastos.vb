Imports Microsoft.VisualBasic

Public Class CGasto
    Public IdVehiculo As Integer
    Public Consec As Integer
    Public MontoGasto As Single
    Public MontoRecuperado As Single
    Public IdTipoGasto As Integer
End Class


Public Class CGasto_Autorizacion
    Public IdVehiculo As Integer
    Public Consec As Integer

    ' Cancelacion
    Public Autorizacion As Char
    Public Comentarios As String
End Class