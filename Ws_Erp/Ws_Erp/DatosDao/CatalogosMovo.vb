Imports System.Data.SqlClient

Public Class CatalogosMovo
    Public Function selCatalogos() As DataSet

        Dim dsCatalogos = New DataSet("Catalogos")
        Dim conexion As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("SQLConecction"))
        Dim cmd As SqlCommand = New SqlCommand("spr_Sel_Catalogos", conexion)
        cmd.CommandType = CommandType.StoredProcedure
        Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)

        da.Fill(dsCatalogos, "Almacen")
        da.Fill(dsCatalogos, "Articulo")

        Return dsCatalogos

    End Function

    Public Function GetCatalogoXNombre(ByVal strCatalogo As String) As DataSet

        Dim lista = New DataSet()
        Dim ds As New System.Data.DataSet()
        Dim conexion As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("SQLConecction"))
        Dim command As New SqlCommand("spr_Sel_CatalogoXNombre", conexion)
        command.CommandType = CommandType.StoredProcedure
        command.Parameters.AddWithValue("@strNombre", strCatalogo)
        Try

            Dim da As New SqlDataAdapter(command)
            da.Fill(ds)

        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        Finally
            conexion.Dispose()
            command.Dispose()
        End Try
        Return ds

    End Function

    Public Function ObtenerDatos() As DataSet

        Dim cnn As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("SQLConecction"))
        Dim cmd As New SqlCommand("spr_Sel_Catalogos", cnn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim ds As New DataSet
        Dim i As Integer

        Dim da As New SqlDataAdapter(cmd)
        da.Fill(ds)

        Dim oArray() As String

        If ds.Tables.Count > 1 Then
            If ds.Tables(ds.Tables.Count - 1).Rows(0).ItemArray(0).ToString() = "collection" Then
                oArray = Split(ds.Tables(ds.Tables.Count - 1).Rows(0).ItemArray(1).ToString(), ";")
                For i = 0 To ds.Tables.Count - 2
                    ds.Tables(i).TableName = oArray(i).ToString()
                Next
            End If
        End If

        Return ds

    End Function

End Class
