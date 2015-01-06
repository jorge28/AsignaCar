Imports Microsoft.VisualBasic

Public Enum EnumTiposConsultaVehiculo
    Empty
    Vehiculos_Activos
    Vehiculos_Eliminados
    Vehiculos_Asignados
    Vehiculos_SinAsignar
    Vehiculos_ParaEnviar
    Vehiculos_Enviados
    Vehiculos_ParaIncisos
    Vehiculos_ParaCheckIn
    Vehiculos_ParaSiniestros
    Vehiculos_ParaTerminarAsignacion
End Enum

Public Class CBusqueda_Vehiculo
    ' Tipo de consulta
    Public TipoConsulta As EnumTiposConsultaVehiculo

    ' filtro
    Public IdContrato As String
    Public MVA As String
    Public Placas As String
    Public Serie As String
    Public Marca As String
    Public Modelo As Integer
    Public PersonaAsignada As String
    Public Estatus As Char
    Public IdPropietario As Integer
    Public IdRegion As String
    Public IdTipoVehiculo As String
End Class
