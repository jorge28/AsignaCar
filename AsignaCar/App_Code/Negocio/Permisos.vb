Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports Telerik.Web.UI

Public Class Permisos
    Public AccionesPermitidas(,) As Integer
    Public FuncionesPermitidas() As Integer

    ''' <summary>
    ''' Consulta los permisos que tiene un grupo de usuarios para ingresar a los formularios y para ejecutar acciones dentro de ellos
    ''' </summary>
    ''' <param name="usr"></param>
    ''' <param name="IdGrupo"></param>
    ''' <remarks></remarks>
    Public Sub ConsultarPermisos(usr As Integer, IdGrupo As Integer)
        Dim serv As New Datos_ControlAcceso
        Dim resp As New Resultado

        ' Permisos de acciones
        resp = serv.Consultar_Permisos_Funcion_Accion(usr, IdGrupo)
        With resp.DataTable
            AccionesPermitidas = New Integer(.Rows.Count - 1, 2) {}

            For i As Integer = 0 To .Rows.Count - 1
                AccionesPermitidas(i, 0) = .Rows(i).Item("IdFuncion")
                AccionesPermitidas(i, 1) = .Rows(i).Item("IdAccion")
            Next
        End With

        ' Permisos de funciones
        resp = serv.Consultar_Permisos_Funcion(usr, IdGrupo)
        With resp.DataTable
            FuncionesPermitidas = New Integer(.Rows.Count - 1) {}

            For i As Integer = 0 To .Rows.Count - 1
                FuncionesPermitidas(i) = .Rows(i).Item("IdFuncion")
            Next
        End With
    End Sub

    ''' <summary>
    ''' Verifica si el usuario tiene permiso de ingresar a esta función
    ''' </summary>
    ''' <param name="IdFuncion"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function VerificarPermisoFuncion(ByVal IdFuncion As Integer) As Boolean
        For i As Integer = 0 To FuncionesPermitidas.Length - 1
            If FuncionesPermitidas(i) = IdFuncion Then
                Return True
            End If
        Next

        Return False
    End Function

    ''' <summary>
    ''' Verifica si el usuario tiene permiso de ejecutar la acción especificada
    ''' </summary>
    ''' <param name="IdFuncion"></param>
    ''' <param name="IdAccion"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function VerificarPermisoAccion(ByVal IdFuncion As Integer, ByVal IdAccion As Integer) As Boolean
        For i As Integer = 0 To (AccionesPermitidas.Length / 2) - 1
            If AccionesPermitidas(i, 0) = IdFuncion And AccionesPermitidas(i, 1) = IdAccion Then
                Return True
            End If
        Next
        Return False
    End Function

End Class
