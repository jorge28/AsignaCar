Imports Microsoft.VisualBasic

Public Class CUsuario
    Public Id As Integer
    Public IdGrupo As Integer
    Public IdPuesto As Integer
    Public Nombre As String
    Public Username As String
    Public ApellidoPaterno As String
    Public ApellidoMaterno As String
    Public TelCel As String
    Public TelNextel As String
    Public Email As String
    Public Password As String
    Public IdRegion As String
    Public IdCoordinacion As String
    Public IdAlmacen As String
End Class

Public Class CGrupo
    Public Id As Integer
    Public Nombre As String

    ' Perfiles que tiene un grupo
    Public Perfiles(-1) As Integer
End Class

Public Class CPerfil
    Public Id As Integer
    Public Nombre As String

    Public Funciones(-1) As Integer


    Public Acciones_IdFuncion As Integer
    Public Acciones(-1) As Integer
End Class
