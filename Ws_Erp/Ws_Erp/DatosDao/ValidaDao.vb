Imports System.Data.SqlClient

Public Class ValidaDao
    Dim inLogger As ILogger = New ILogger()


    Public Function validaVentaSP(strEmpresa, strMoneda, strProyecto, strCliente, strAlamacen, strConcepto, intSucursal, strArticulo, strCentroCostos, strUnidad) As String

        Dim errorVenta As String = String.Empty
        Dim conexion As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("SQLConecction"))

        Try
            conexion.Open()
            Dim command As New SqlCommand("Valida_Ventas", conexion)

            command.CommandType = CommandType.StoredProcedure
            command.Parameters.AddWithValue("@strEmpresa", strEmpresa)
            command.Parameters.AddWithValue("@strMoneda", strMoneda)
            command.Parameters.AddWithValue("@strProyecto", strProyecto)
            command.Parameters.AddWithValue("@strCliente", strCliente)
            command.Parameters.AddWithValue("@strAlmacen", strAlamacen)
            command.Parameters.AddWithValue("@strConcepto", strConcepto)
            command.Parameters.AddWithValue("@intSucursal", intSucursal)
            command.Parameters.AddWithValue("@strArticulo", strArticulo)
            command.Parameters.AddWithValue("@strCentroCosto", strCentroCostos)
            command.Parameters.AddWithValue("@strUnidad", strUnidad)

            Dim reader As SqlDataReader = command.ExecuteReader()

            If reader.HasRows Then
                If reader.Read Then
                    errorVenta = reader.GetString(0)
                End If
            End If

        Catch ex As DataException

            inLogger.insError("Error en metodo: validaVenta()", ex.Message)

        Catch ex As Exception

            inLogger.insError("Error en metodo: validaVenta()", ex.Message)

        Finally
            conexion.Close()
            conexion.Dispose()
        End Try

        Return errorVenta
    End Function
    Public Function validaGasto(ByVal gastoVo As gastoVO) As String

        Dim errorGasto As String = String.Empty
        Dim conexion As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("SQLConecction"))

        Try
            conexion.Open()
            Dim command As New SqlCommand("spr_Val_Gasto", conexion)

            command.CommandType = CommandType.StoredProcedure
            command.Parameters.AddWithValue("@strEmpresa", gastoVo.Empresa)
            command.Parameters.AddWithValue("@strMoneda", gastoVo.Moneda)
            command.Parameters.AddWithValue("@strProyecto", gastoVo.Proyecto)
            command.Parameters.AddWithValue("@strClase", gastoVo.Clase)
            command.Parameters.AddWithValue("@strSubClase", gastoVo.SubClase)
            command.Parameters.AddWithValue("@strProveedor", gastoVo.Proveedor)
            command.Parameters.AddWithValue("@strSucursal", gastoVo.Sucursal)

            Dim reader As SqlDataReader = command.ExecuteReader()

            If reader.HasRows Then
                If reader.Read Then
                    errorGasto = reader.GetString(0)
                End If
            End If

        Catch ex As DataException

            inLogger.insError("Error en metodo: validaGasto()", ex.Message)

        Catch ex As Exception

            inLogger.insError("Error en metodo: validaGasto()", ex.Message)

        Finally
            conexion.Close()
            conexion.Dispose()
        End Try

        Return errorGasto
    End Function

    Public Function validaGastoD(Concepto, CentroCostos) As String

        Dim errorGasto As String = String.Empty
        Dim conexion As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("SQLConecction"))

        Try
            conexion.Open()
            Dim command As New SqlCommand("spr_Val_GastoDetalle", conexion)

            command.CommandType = CommandType.StoredProcedure
            command.Parameters.AddWithValue("@strConcepto", Concepto)
            command.Parameters.AddWithValue("@strCentroCosto", CentroCostos)

            Dim reader As SqlDataReader = command.ExecuteReader()

            If reader.HasRows Then
                If reader.Read Then
                    errorGasto = reader.GetString(0)
                End If
            End If

        Catch ex As DataException

            inLogger.insError("Error en metodo: validaGastoD()", ex.Message)

        Catch ex As Exception

            inLogger.insError("Error en metodo: validaGastoD()", ex.Message)

        Finally
            conexion.Close()
            conexion.Dispose()
        End Try

        Return errorGasto
    End Function

    Public Function validaInventario(ByRef inventarioVO As inventarioVO) As String

        Dim errorInventario As String = String.Empty
        Dim conexion As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("SQLConecction"))

        Try
            conexion.Open()
            Dim command As New SqlCommand("spr_Val_Inventario", conexion)

            command.CommandType = CommandType.StoredProcedure
            command.Parameters.AddWithValue("@strEmpresa", inventarioVO.Empresa)
            command.Parameters.AddWithValue("@strMoneda", inventarioVO.Moneda)
            command.Parameters.AddWithValue("@strProyecto", inventarioVO.Proyecto)
            command.Parameters.AddWithValue("@strAlmacen", inventarioVO.Almacen)
            command.Parameters.AddWithValue("@strConcepto", inventarioVO.Concepto)
            command.Parameters.AddWithValue("@intSucursal", inventarioVO.Sucursal)

            Dim reader As SqlDataReader = command.ExecuteReader()

            If reader.HasRows Then
                If reader.Read Then
                    errorInventario = reader.GetString(0)
                End If
            End If

        Catch ex As DataException

            inLogger.insError("Error en metodo: validaInventario()", ex.Message)

        Catch ex As Exception

            inLogger.insError("Error en metodo: validaInventario()", ex.Message)

        Finally
            conexion.Close()
            conexion.Dispose()
        End Try

        Return errorInventario
    End Function

    Public Function validaInventarioD(ByVal inventarioDetalleVO As inventarioDetalleVO) As String

        Dim errorInventario As String = String.Empty
        Dim conexion As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("SQLConecction"))

        Try
            conexion.Open()
            Dim command As New SqlCommand("spr_Val_InventarioDetalle", conexion)

            command.CommandType = CommandType.StoredProcedure
            command.Parameters.AddWithValue("@strArticulo", inventarioDetalleVO.Articulo)
            command.Parameters.AddWithValue("@strCentroCosto", inventarioDetalleVO.CentroCostos)
            command.Parameters.AddWithValue("@strUnidad", inventarioDetalleVO.Unidad)

            Dim reader As SqlDataReader = command.ExecuteReader()

            If reader.HasRows Then
                If reader.Read Then
                    errorInventario = reader.GetString(0)
                End If
            End If

        Catch ex As DataException

            inLogger.insError("Error en metodo: validaInventarioD()", ex.Message)

        Catch ex As Exception

            inLogger.insError("Error en metodo: validaInventarioD()", ex.Message)

        Finally
            conexion.Close()
            conexion.Dispose()
        End Try

        Return errorInventario
    End Function
End Class
