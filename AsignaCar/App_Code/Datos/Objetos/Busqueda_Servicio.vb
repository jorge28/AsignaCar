Imports Microsoft.VisualBasic

Public Enum EnumTiposConsultaServicio
    Empty
    Servicios_Activos
    Servicios_Cancelados
End Enum

Public Class CBusqueda_Servicio
    ' Tipo de consulta
    Public TipoConsulta As EnumTiposConsultaServicio

    ' filtro
    Public NumServicio As String
    Public NumSiniestro As String
    Public NumPoliza As String
    Public NombreAseguradora As String
    Public AsegNombre As String ' nombre del asegurado
    Public EstatusServicio As String
End Class

Public Enum EnumTiposConsultaServicio2
    Empty
    Servicios_Sin_Terminar
    Servicios_Terminados_Para_Reembolso
    Servicios_Terminados_Sin_Encuesta_Satisfaccion
    Servicios_Terminados_Sin_Facturar
    Servicios_Terminados_Sin_Pago '' Jrad 5-mar-2013
End Enum

Public Class CBusqueda_Servicio2
    Public TipoConsulta As EnumTiposConsultaServicio2

    ' filtro
    Public NumServicio As String
    Public NumSiniestro As String
    Public NumPoliza As String
    Public NombreAseguradora As String
    Public AsegNombre As String ' nombre del asegurado
    Public Placas As String
    Public Proveedor As String
    Public NumContrato As String

End Class


Public Class CBusqueda_Servicio_pagos
    ' filtro
    Public NumServicio As String
    Public NumSiniestro As String
    Public NumPoliza As String
    Public NombreAseguradora As String
    Public AsegNombre As String ' nombre del asegurado
    Public Placas As String
    Public Proveedor As String
    Public Proceso As Integer
End Class