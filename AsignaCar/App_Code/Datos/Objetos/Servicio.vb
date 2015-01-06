Imports Microsoft.VisualBasic

Public Enum EnumFasesServicios
    Empty
    Activacion
    Atencion
End Enum

Public Class CServicio
    Public IdServicio As Integer
    Public IdServicio_Ant As Integer ' Se usa para reactivación
    Public DescOtro As String

    Public fase As EnumFasesServicios

    'activacion
    Public ConCosto As Boolean
    Public Estatus As String
    Public FecActivacion As Date
    Public IdAseguradora As Integer
    Public IdQuienReporta As Integer
    Public NumPoliza As String
    Public Inciso As String
    Public Categoria As Char
    Public IdUbicacionEntrega As Integer
    Public IdEvento As Integer
    Public Cobertura As Boolean
    Public Costo As Double
    Public DiasRenta As Integer
    Public RepNombre As String
    Public RepPaterno As String
    Public RepMaterno As String
    Public RepTelefono As String
    Public RepTelefono0 As String
    Public LadaRepTelefono As String
    Public LadaRepTelefono0 As String
    Public RepEmail As String
    Public RepIdEstado As Integer
    Public RepIdMunicipio As Integer
    Public AsegNombre As String
    Public AsegPaterno As String
    Public AsegMaterno As String
    Public AsegTelefono As String
    Public AsegTelefono0 As String
    Public LadaAsegTelefono As String
    Public LadaAsegTelefono0 As String
    'Atencion cita
    Public FecEntrega As DateTime
    Public FecDevolucionPrevista As DateTime
    Public VehIdMarca As Integer
    Public VehIdSubMarca As Integer
    Public VehValorComercial As Double
    Public VehModelo As Integer
    Public VehColonia As String
    Public VehCalle As String
    Public VehNumero As String
    Public VehCP As String
    Public VehIdEstado As Integer
    Public VehIdMunicipio As Integer
    Public AsisIdMunicipio As Integer
    Public VehPlacas As String
    Public VehSerie As String
    Public NumSiniestro As String
    Public SiniLugarOcurrencia As String
    Public SiniLugarReporte As String
    'Descripcion Reporte
    Public DescripcionReporte As String
    'Proveedor
    Public IdProveedor As Integer
    'Nuevas Fechas
    Public NewFecAsignacion As DateTime
    Public NewFecTerminacion As DateTime
    'Guardar Modificaciones
    Public NewFecDevoReal As DateTime
    Public diasUsado As Integer
    Public diasAdicionales As Integer
    Public costoDiasAdicionales As Integer
End Class

Public Class CBitacoraServicios
    Public Bitacora As String
    Public IdServicio As Integer
    Public IdUsuario As Integer
    Public IdContrato As String
    Public NumServicio as Integer
End Class

