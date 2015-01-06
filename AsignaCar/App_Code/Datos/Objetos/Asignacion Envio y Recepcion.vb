Imports Microsoft.VisualBasic

Public Class CAsignacion
    Public Id As Integer
    Public IdVehiculo As Integer
    Public IdRegion As Integer
    Public IdCoordinacion As Integer
    Public IdAlmacen As Integer

    Public NumContrato As String
    Public IdPropietario As Integer
    Public IdTipoVehiculo As Integer
    Public IdConductor As Integer

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

    Public IdMotivoTerminacion As Integer
    Public Term_Comentarios As String

End Class

Public Class CEnvio
    Public Id As Integer

    'Datos del Auto
    Public IdVehiculo As Integer
    Public KmSalida As Integer
    Public IdNivelGasolinaSalida As Integer
    Public ComentariosSalida As String
    Public Conductor As String

    'Datos de Envio
    Public IdRegion As Integer
    Public IdCoordinacion As Integer
    Public IdAlmacen As Integer
    Public IdEstado As Integer
    Public TipoEnvio As Char
    Public PersonaAutoriza As String
    Public CostoTraslado As Double

    'Inventario
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

End Class

Public Class CRecepcion
    Public Id As Integer

    'Datos del Auto
    Public IdVehiculo As Integer
    Public KmEntrada As Integer
    Public IdNivelGasolinaEntrada As Integer
    Public ComentariosEntrada As String
    Public CombustibleConsumido As Integer

    'Inventario
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

End Class
