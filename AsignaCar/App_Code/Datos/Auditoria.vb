Imports Microsoft.VisualBasic
Imports Acceso_a_Datos
Imports System.Data.SqlClient

Public Class Auditoria

    ''' <summary>
    ''' Graba un registro de auditoría en el sistema
    ''' </summary>
    ''' <param name="IdUsuario"></param>
    ''' <param name="IdMovto"></param>
    ''' <param name="Desc"></param>
    ''' <remarks></remarks>
    Public Shared Sub Registrar(IdUsuario As Integer, IdMovto As Integer, Optional Desc As String = "")
        Dim datos As New ObjDatos
        Dim res As New Resultado

        Try
            datos.sqlParameters.Add(New SqlParameter("@IdUsuario", IdUsuario))
            datos.sqlParameters.Add(New SqlParameter("@Movto", IdMovto))
            datos.sqlParameters.Add(New SqlParameter("@Desc", Left(Desc, 100)))
            datos.Comando_SP("Insert_Auditoria @IdUsuario, @Movto, @Desc", res.DataTable)

        Catch ex As Exception
            Logs.LogError("Auditoria.vb", "Registrar", ex.Message, ex.StackTrace)
        End Try

    End Sub

End Class
