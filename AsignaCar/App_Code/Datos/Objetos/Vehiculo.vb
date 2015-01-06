Imports Microsoft.VisualBasic

Public Class CVehiculo
    Public Id As Integer
    Public MVA As String
    Public NumSerie As String
    Public NumMotor As String
    Public Factura As String
    Public IdMarca As Integer
    Public CapacidadTanque As Short
    Public Color As String
    Public IdSubMarca As Integer
    Public Placas As String
    Public Equipamiento As String
    Public Transmision As Char
    Public FecCompra As Date
    Public Tarifa As Single
    Public CostoInicial_Placas As Single
    Public CostoInicial_Tenencia As Single
    Public CostoInicial_Verificacion As Single
    Public CostoInicial_Otros As Single
    Public Modelo As Short
    Public Kilometraje As Integer
    Public IdNivelGasolina As Integer
    Public IdTipoVehiculo As Integer
    Public IdPropietario As Integer
    'Public IdRegion As Integer
    Public IdTipoCompra As Integer
    Public FecPrimerDiaFlota As Date
    Public ValorVehiculo As Single
    Public ValorVehiculoArrendamiento As Single
    Public Inv_ManualConductor As Boolean
    Public Inv_Herramientas As Boolean
    Public Inv_LlantaRefaccion As Boolean
    Public Inv_Reflejantes As Boolean
    Public Inv_Extintor As Boolean
    Public Inv_Radio As Boolean
    Public Inv_Encendedor As Boolean
    Public Inv_Llaves As Boolean
    Public Inv_Gato As Boolean
    Public Inv_AireAcondicionado As Boolean
    Public Desc_Otros_Costos As String

    Public Cambio_Kilometraje As Boolean
    Public Cambio_Placas As Boolean
    Public Cambio_IdPropietario As Boolean
    Public status As String
End Class

Public Class CVehiculos_Baja
    Public IdVehiculo As Integer
    Public IdMotivoBaja As Integer
    Public FecVenta As DateTime
    Public MontoVenta As Double
    Public NombreComprador As String
    Public NombreEmpresaCompradora As String
End Class

Public Class CVehiculos_MotivoBaja
    Public Id As Integer
    Public Nombre As String
End Class
