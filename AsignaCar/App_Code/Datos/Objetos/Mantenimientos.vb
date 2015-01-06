Imports Microsoft.VisualBasic

Public Enum EnumFasesMantenimiento
    Empty
    Programacion
    Activacion
    Terminacion
    Cancelacion
End Enum
Public Class CMantenimiento
    Public IdVehiculo As Integer
    Public Consec As Integer

    Public fase As EnumFasesMantenimiento

    'programacion
    Public IdTipo As Integer
    Public TipoPeriodicidad As Char
    Public FecPrevista As Date
    Public Cada_N_Km As Integer
    Public KmProgramacion As Integer
    Public Observaciones As String

    'activacion
    Public IdProveedor As Integer
    Public ObservacionesActivacion As String
    Public KmActivacion As Integer
    Public IdNivelGasolinaActivacion As Integer
    Public PrecioTotalActivacion As Double
    Public IdConcepto(-1) As Integer
    Public TextoConcepto(-1) As String
    Public PrecioConcepto(-1) As Single

    'Terminacion
    Public TipoTerminacion As Char
    Public FolioFactura As String
    Public IdIVA As Integer
    Public TotalFactura As Double
    Public FecRecepcionFactura As Date
    Public FecEntregaFactura As Date
    Public FolioSolicitudPago As String
    Public KmTerminacion As Integer
    Public IdNivelGasolinaTerminacion As Integer
    Public FecPromesa As Date
    Public FecReal As Date
    Public ComentariosTerminacion As String
End Class

Public Class CMantenimiento_Cancelacion
    Public IdVehiculo As Integer
    Public Consec As Integer

    ' Cancelacion
    Public Observaciones As String
End Class


Public Class CMantenimiento_Autorizacion
    Public IdVehiculo As Integer
    Public Consec As Integer

    ' Cancelacion
    Public Autorizacion As Char
    Public Comentarios As String
End Class

