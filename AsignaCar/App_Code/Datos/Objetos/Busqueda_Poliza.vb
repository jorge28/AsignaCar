Imports Microsoft.VisualBasic

Public Enum EnumTiposConsultaPoliza
    Empty
    Polizas_Activas
    Polizas_Eliminadas
End Enum

Public Class CBusqueda_Poliza
    ' Tipo de consulta
    Public TipoConsulta As EnumTiposConsultaPoliza

    ' filtro
    Public NumPoliza As String
    Public MVA As String
    Public NumSerie As String
    Public Placas As String
End Class
