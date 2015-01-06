Imports Microsoft.VisualBasic

Public Enum EnumTipoConsultaSalidasImproductivas
    Empty
    Abiertas
    Todas
End Enum

Public Class CBusqueda_SalidaImproductiva
    ' filtro
    Public TipoConsulta As EnumTipoConsultaSalidasImproductivas
    Public NumSalida As String
    Public Placas As String
    Public FecIni As Date
    Public FecFin As Date
End Class
