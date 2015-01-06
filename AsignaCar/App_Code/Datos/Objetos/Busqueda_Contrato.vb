Imports Microsoft.VisualBasic

Public Enum EnumTipoConsultaContrato
    Empty
    Abiertos
    Todos
    Pendientes
End Enum


Public Class CBusqueda_Contrato
    Public NumContrato As String
    Public NumServicio As String
    Public AsegNombre As String
    Public Placas As String
    Public NumSiniestro As String
    Public NumPoliza As String
    Public Estatus As Char
    'Public Estatus2 As Char
    Public TipoContrato As Char
    Public NumReservacion As String
    'Public EstatusContra As Integer
End Class

Public Class CBusqueda_Contrato2
    Public TipoConsulta As EnumTipoConsultaContrato

    Public NumContrato As String
    Public NumServicio As String
    Public AsegNombre As String
    Public Placas As String
    Public NumSiniestro As String
    Public NumPoliza As String
    Public Estatus As Char
    Public Fecha1 As Date
    Public Fecha2 As Date
    Public Fecha3 As Date
    Public TipoAuto As Char
End Class