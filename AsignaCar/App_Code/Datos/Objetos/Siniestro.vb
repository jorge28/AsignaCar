Imports Microsoft.VisualBasic

Public Class CSiniestro
    Public IdVehiculo As Integer
    Public Consec As Integer

    'Alta de siniestro
    Public Estatus As Char
    Public IdTipoSiniestro As Integer
    Public IdEstatusTipoSiniestro As Integer
    Public ComentaCierre As String
    Public ConductorNombre As String
    Public ConductorPaterno As String
    Public ConductorMaterno As String
    Public UbicacionIdEstado As Integer
    Public UbicacionIdMunicipio As Integer
    Public UbicacionColonia As String
    Public UbicacionCalle As String
    Public UbicacionCP As String
    Public UbicacionNumero As String
    Public UbicacionReferencias As String
    Public TelefonoConductor As String
    Public NumSiniestro As String
    Public OperadorNombre As String
    Public OperadorPaterno As String
    Public OperadorMaterno As String
    Public AjustadorNombre As String
    Public AjustadorPaterno As String
    Public AjustadorMaterno As String
    Public FecOcurrido As DateTime
    Public FecRegistro As DateTime
    Public Responsabilidad As String
    Public Narracion As String

    'Estatus pérdida

    Public DictamenPerdida As String
    Public Factura As String
    Public Placas As String
    Public TarjetaCirculacion As String
    Public TramiteBajaPlacas As String
    Public Tenencias As String
    Public DocAsegArrend As String
    Public ChequeFiniquito As String
    Public MontoCheque As Double
    Public AvisoArren As Boolean

    'Colisión Valuacion
    Public MontoValuacion As Double

    'Colision Reparacion
    Public Deducible As Boolean
    Public TipoDeducible As Char
    Public MontoDeducible As Double
    Public TallerAsignado As String
    Public TiempoEstRep As Integer

End Class
'ISRA
Public Class CancelarSiniestro
    Public IdVehiculo As Integer
    Public Consec As Integer
    Public IdMotivo As String
    Public OtroMotivoCancel As String
End Class
Public Class CSiniestro_Cierre
    Public IdVehiculo As Integer
    Public Consec As Integer

    ' Cierre
    Public IdMotivoCierre As Integer
    Public OtroMotivoCierre As String
End Class
'Termina Isra

Public Class CSiniestro_Cancel_Autorizacion
    Public IdVehiculo As Integer
    Public Consec As Integer

    ' Cancelacion
    Public Autorizacion As Char
    Public Comentarios As String
End Class