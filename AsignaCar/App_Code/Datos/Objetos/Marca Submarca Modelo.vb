Imports Microsoft.VisualBasic

Public Class CMarca
    Public Id As Integer
    Public Nombre As String
End Class

Public Class CModelo
    Public IdSubMarca As Integer
    Public IdMarca As Integer
    Public Modelo As Short
End Class

Public Class CSubMarca
    Public Id As Integer
    Public Nombre As String
    Public IdMarca As Integer
End Class

Public Class CBanco
    Public Id As Integer
    Public Nombre As String
End Class
