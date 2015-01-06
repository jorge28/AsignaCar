Imports Microsoft.VisualBasic

Public Class CProveedorPrecio
    Public Id As Integer
    Public IdProveedor As Integer
    Public IdTipoConcepto As Integer
    Public IdConcepto As Integer
    Public Precio As Single
End Class

Public Class CProveedorContacto
    Public Id As Integer
    Public IdProveedor As Integer

    Public Nombre As String
    Public Paterno As String
    Public Materno As String
    Public Email As String
    Public TelCel As String
End Class

Public Class CProveedor
    Public Id As Integer
    Public NombreComercial As String
    Public RFC As String
    Public RazonSocial As String
    Public Calle As String
    Public Numero As String
    Public CP As String
    Public Colonia As String
    Public IdEstado As Integer
    Public IdMunicipio As Integer
    Public Telefono As String
    Public Comentarios As String
    Public ClaProveedor As Integer
    Public TipoProveedor As Integer
End Class
