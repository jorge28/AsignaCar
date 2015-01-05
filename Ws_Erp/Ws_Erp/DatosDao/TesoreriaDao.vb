Imports System.Data.SqlClient

Public Class TesoreriaDao

    'Public Function selTesoreria() As IList(Of EntTesoreria)

    '    Dim tesoreria As New List(Of EntTesoreria)()

    '    Dim custDS As DataSet = New DataSet()

    '    Dim conexion As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("SQLConecction"))
    '    Dim command As New SqlCommand("spr_Sel_Tesoreria", conexion)
    '    command.CommandType = CommandType.StoredProcedure
    '    Try
    '        conexion.Open()
    '        Dim reader As SqlDataReader = command.ExecuteReader()

    '        If reader.HasRows Then
    '            Do While reader.Read()

    '                tesoreria.Add(New EntTesoreria() With {
    '                .IdErp = reader(0),
    '                .ModuloOrigen = reader(1),
    '                .TransOrigen = reader(2),
    '                .Empresa = reader(3),
    '                .Mov = reader(4),
    '                .MovId = reader(5),
    '                .FechaEmision = reader(6),
    '                .Concepto = reader(7),
    '                .Proyecto = reader(8),
    '                .Moneda = reader(9),
    '                .TipoCambio = reader(10),
    '                .Referencia = reader(11),
    '                .Observaciones = reader.GetString(12),
    '                .BenefNombre = reader.GetString(13),
    '                .CtaDineroOrigen = reader(14),
    '                .CtaDineroDestino = reader.GetString(15),
    '                .Contacto = reader(16),
    '                .ContactoTipo = reader(17),
    '                .Importe = reader(18),
    '                .Impuestos = reader(19),
    '                .FechaProgramada = reader(20),
    '                .FormaPago = reader(21),
    '             .Sucursal = reader(22)
    '             })
    '            Loop
    '        End If
    '    Catch ex As Exception
    '        'MessageBox.Show(ex.Message)
    '    Finally
    '        conexion.Dispose()
    '        command.Dispose()
    '    End Try
    '    Return tesoreria
    'End Function

    Public Function selTesoreria() As DataTable

        Dim lista = New DataTable()
        Dim ds As New System.Data.DataSet()
        Dim conexion As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("SQLConecction"))
        Dim command As New SqlCommand("spr_Sel_Tesoreria", conexion)
        command.CommandType = CommandType.StoredProcedure
        Try
            conexion.Open()
            Using reader As SqlDataReader = command.ExecuteReader
                Dim adapter As New System.Data.SqlClient.SqlDataAdapter()
                lista.Load(reader)
            End Using
        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        Finally
            conexion.Dispose()
            command.Dispose()
        End Try
        Return lista
    End Function

End Class
