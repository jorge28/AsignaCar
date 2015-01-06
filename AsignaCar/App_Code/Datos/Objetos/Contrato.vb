Imports Microsoft.VisualBasic

Public Class CContrato
    Public Id As Integer
    Public IdServicio As String

    Public AsegLicencia As String
    Public IdTipoLicenciaAseg As Integer
    Public Permanente As Integer
    Public FecAsegVencimientoLicencia As DateTime

    Public Garantia As Char
    Public IdTipoPagoBancario As Integer
    Public IdTipoTarjetaBancaria As Integer
    Public NumTarjeta4Digitos As String
    Public VencimientoTarjeta As String
    Public NumAutorizacionTarjeta As String
    Public CodigoSeguridadTarjeta As String
    Public RefDepositoBancario As String
    Public Monto As Single
    Public IdRegion As String

    Public TipoAuto As Char
    Public IdVehiculo As String
    Public IdMarcaVehProv As Integer
    Public IdSubmarcaVehProv As Integer
    Public ModeloVehProv As Short
    Public PlacasVehProv As String
    Public Kilometraje As Integer
    Public IdNivelGasolina As Integer
    Public IdProveedor As String
    Public Costo As Double
    Public CostoDropOff As Double
    Public Precio As Double
    Public ImpuestoFedAero As Double
    Public SeguroConductorMenor As Double
    Public ColorVeh As String
    Public NumReserva As String
    Public NumContrato As String

    Public TipoAutoAnt As Char
    Public FecEntregaReal As DateTime
    Public FecDevoPrevistaII As DateTime

    Public IdRegionVeh As Integer
    Public IdCoordinacionVeh As Integer
    Public IdAlmacenVeh As Integer
    Public PlacasVeh As String
End Class

Public Class CBitacoraContratos
    Public Bitacora As String
    Public IdContrato As String
    Public IdUsuario As Integer
End Class

Public Class Bitacora_General
    Public Bitacora As String
    Public IdContrato As String
    Public IdUsuario As Integer
    Public IdServicio As Integer
End Class

Public Class CContrato_CambioAuto
    Public IdContrato As String
    Public IdMotivoCambioAuto As Integer

    Public KmEntrada As Integer
    Public IdNivelGasolinaEntrada As Integer

    Public TipoAuto As Char
    Public IdVehiculo As Integer
    Public IdMarcaVehProv As Integer
    Public IdSubmarcaVehProv As Integer
    Public ModeloVehProv As Short
    Public PlacasVehProv As String
    Public IdProveedor As Integer
    Public Kilometraje As Integer
    Public IdNivelGasolina As Integer
    Public ColorVeh As String
End Class

Public Class CContrato_Extension
    Public IdContrato As String

    Public FecCierre As DateTime
    Public IdTipoPagoBancario As Integer
    Public Importe As Double
    Public RefBancaria As String
    Public TipoAuto As String
    Public DiasExtension As Integer
End Class

Public Class CContrato_Autorizacion_Extension
    Public IdContrato As String

    Public consec As Integer
    Public FecCierre As Date
    ' Cancelacion
    Public Autorizacion As Char
    Public Comentarios As String
End Class

Public Class CContrato_Cierre
    Public IdServicio As Integer
    'Public IdContrato As Integer
    Public IdContrato As String

    'Cierre
    Public IdNivelGasolina As Integer
    Public Kilometraje As Integer
    Public CostoDaños As Double
    Public CostoGasolina As Double
    Public DiasUsados As Integer '' jrad marzo 2013
    Public DiasAdicionales As Integer '' jrad marzo 2013
    Public CostoDiasAdicionales As Double
    Public IdTipoPagoBancario As Integer
    Public NumTarjeta4Digitos As String
    Public RefDepositoBancario As String

End Class