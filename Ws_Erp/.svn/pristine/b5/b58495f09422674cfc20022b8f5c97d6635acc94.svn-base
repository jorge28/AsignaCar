Imports System.Data.SqlClient

Public Class ComprasDao
    '''''''''''''''''''''''''''''''
    '' Objetos de Acceso a Datos ''
    '''''''''''''''''''''''''''''''
    Public conn As SqlConnection = Nothing
    Public adapter As SqlDataAdapter = Nothing
    Public dataReader As SqlDataReader = Nothing
    Public dataSet As DataSet = Nothing
    Public dataRow As DataRow = Nothing
    Public transaction As SqlTransaction = Nothing
    Public fecha As Date
    Public errorDesc As String
    Public sqlConnectionString As String
    Public mostrarErrores As Boolean = False
    Dim inLogger As ILogger = New ILogger()

    ''''''''''''''''''''''''''''
    '' Conectar Y Desconectar ''
    ''''''''''''''''''''''''''''

    Public Function insComprasXml(ByVal compras As comprasVO) As Boolean

        Dim conexion As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("SQLConecction"))
        Dim objTransac As SqlTransaction = Nothing

        Try

            conexion.Open()

            Dim command As New SqlCommand("spr_Ins_Compra", conexion)
            objTransac = conexion.BeginTransaction
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@intId", SqlDbType.Int).Direction = ParameterDirection.InputOutput
            command.Parameters("@intId").Value = 0
            command.Parameters.AddWithValue("@strTipoBeneficia", compras.TipoBeneficia)
            command.Parameters.AddWithValue("@strEmpresa", compras.Empresa)
            command.Parameters.AddWithValue("@strMoneda", compras.Moneda)
            command.Parameters.AddWithValue("@dtmFechaEmision", compras.FechaEmision)
            command.Parameters.AddWithValue("@strProyecto", compras.Proyecto)
            command.Parameters.AddWithValue("@strReferencia", compras.Referencia)
            command.Parameters.AddWithValue("@strObservaciones", compras.Observaciones)
            command.Parameters.AddWithValue("@strProveedor", compras.Proveedor)
            command.Parameters.AddWithValue("@strAlmacen", compras.Almacen)
            command.Parameters.AddWithValue("@strConcepto", compras.Concepto)
            command.Parameters.AddWithValue("@intSucursal", compras.Sucursal)
            command.Parameters.AddWithValue("@strCondicion", compras.Condicion)
            command.Parameters.AddWithValue("@dblDescuentoGlobal", compras.DescuentoGlobal)
            command.Parameters.AddWithValue("@strCxpCtaDinero", compras.CxpCtaDinero)
            command.Parameters.AddWithValue("@strCxpCtaProveedor", compras.CxpCtaProveedor)
            command.Parameters.AddWithValue("@strCxpFormaPago", compras.CxpFormaPago)
            command.Parameters.AddWithValue("@strCxpConcepto", compras.CxpConcepto)
            command.Parameters.AddWithValue("@bitRecibido", compras.Recibido)

            With command
                .Transaction = objTransac
                .ExecuteNonQuery()
            End With

            Dim id = command.Parameters("@intId").Value

            Dim comman As New SqlCommand("spr_Ins_CompraDetalle", conexion)
            comman.CommandType = CommandType.StoredProcedure
            Dim renglon As Integer = 0
            For Each compraDetalle In compras.listCompraDetalle
                renglon = renglon + 1
                comman.Parameters.AddWithValue("@intId", id)
                comman.Parameters.AddWithValue("@strArticulo", compraDetalle.Articulo)
                comman.Parameters.AddWithValue("@intRenglon", renglon)
                comman.Parameters.AddWithValue("@dblCantidad", compraDetalle.Cantidad)
                comman.Parameters.AddWithValue("@dblCosto", compraDetalle.Costo)
                comman.Parameters.AddWithValue("@dblImpuesto1", compraDetalle.Impuesto1)
                comman.Parameters.AddWithValue("@dblImpuesto2", compraDetalle.Impuesto2)
                comman.Parameters.AddWithValue("@dblRetencion1", compraDetalle.Retencion1)
                comman.Parameters.AddWithValue("@dblRetencion2", compraDetalle.Retencion2)
                comman.Parameters.AddWithValue("@dblRetencion3", compraDetalle.Retencion3)
                comman.Parameters.AddWithValue("@dblDescuentoImporte", compraDetalle.DescuentoImporte)
                comman.Parameters.AddWithValue("@strDescripcionExtra", compraDetalle.DescripcionExtra)
                comman.Parameters.AddWithValue("@strCentroCostos", compraDetalle.CentroCostos)
                comman.Parameters.AddWithValue("@strUnidad", compraDetalle.Unidad)

                With comman
                    .Transaction = objTransac
                    .ExecuteNonQuery() ' ejecutar  
                End With
                comman.Parameters.Clear()
            Next

            objTransac.Commit()
            Return True
        Catch ex As DataException

            objTransac.Rollback()
            inLogger.insError("Error en metodo: insCompras()", ex.Message)
            Return False
        Catch ex As Exception

            objTransac.Rollback()
            inLogger.insError("Error en metodo: insCompras()", ex.Message)
            Return False
        Finally
            conexion.Close()
            conexion.Dispose()
        End Try
    End Function

    Public Function insCompra(strEmpresa, strMovimiento, dtmFechaEmision, strConcepto, strProyecto, strMoneda, dblTipoCambio, strReferencia, strObservaciones, strProveedor, strAlmacen, strCondicion, dblDescuentoGlobal, dblImporte, dblImpuestos, dblRetencion, intSucursal, strArticulo, dblCantidad, dblCosto, dblImpuesto1, dblImpuesto2, dblRetencion1, dblRetencion2, dblRetencion3, dblDescuentoImporte, strDescripcionExtra, strContUso, strUnidad) As Boolean

        Dim respuesta As Boolean = False
        Dim conexion As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("SQLConecction"))
        Dim objTransac As SqlTransaction = Nothing
        Try
            conexion.Open()
            Dim command As New SqlCommand("spr_Ins_Compra", conexion)
            objTransac = conexion.BeginTransaction

            command.CommandType = CommandType.StoredProcedure
            command.Parameters.AddWithValue("@IdErp", 1)
            command.Parameters.AddWithValue("@strEmpresa", strEmpresa)
            command.Parameters.AddWithValue("@strMovimiento", strMovimiento)
            command.Parameters.AddWithValue("@dtmFechaEmision", dtmFechaEmision)
            command.Parameters.AddWithValue("@strConcepto", strConcepto)
            command.Parameters.AddWithValue("@strProyecto", strProyecto)
            command.Parameters.AddWithValue("@strMoneda", strMoneda)
            command.Parameters.AddWithValue("@dblTipoCambio", dblTipoCambio)
            command.Parameters.AddWithValue("@strReferencia", strReferencia)
            command.Parameters.AddWithValue("@strObservaciones", strObservaciones)
            command.Parameters.AddWithValue("@strProveedor", strProveedor)
            command.Parameters.AddWithValue("@strAlmacen", strAlmacen)
            command.Parameters.AddWithValue("@strCondicion", strCondicion)
            command.Parameters.AddWithValue("@dblDescuentoGlobal", dblDescuentoGlobal)
            command.Parameters.AddWithValue("@dblImporte", dblImporte)
            command.Parameters.AddWithValue("@dblImpuestos", dblImpuestos)
            command.Parameters.AddWithValue("@dblRetencion", dblRetencion)
            command.Parameters.AddWithValue("@intSucursal", intSucursal)
            ''Parametros para la tabla de compraD''
            command.Parameters.AddWithValue("@strArticulo", strArticulo)
            command.Parameters.AddWithValue("@dblCantidad", dblCantidad)
            command.Parameters.AddWithValue("@dblCosto", dblCosto)
            command.Parameters.AddWithValue("@dblImpuesto1", dblImpuesto1)
            command.Parameters.AddWithValue("@dblImpuesto2", dblImpuesto2)
            command.Parameters.AddWithValue("@dblRetencion1", dblRetencion1)
            command.Parameters.AddWithValue("@dblRetencion2", dblRetencion2)
            command.Parameters.AddWithValue("@dblRetencion3", dblRetencion3)
            command.Parameters.AddWithValue("@dblDescuentoImporte", dblDescuentoImporte)
            command.Parameters.AddWithValue("@strDescripcionExtra", strDescripcionExtra)
            command.Parameters.AddWithValue("@strContUso", strContUso)
            command.Parameters.AddWithValue("@strUnidad", strUnidad)

            With command
                .Transaction = objTransac
                .ExecuteNonQuery() ' ejecutar  
            End With

            objTransac.Commit()

        Catch ex As DataException

            objTransac.Rollback()
            inLogger.insError("Error en metodo: insCompra()", ex.Message)

        Catch ex As Exception

            objTransac.Rollback()
            inLogger.insError("Error en metodo: insCompra()", ex.Message)

        Finally
            conexion.Close()
            conexion.Dispose()
        End Try
        Return respuesta
    End Function

    Public Function updCompra(intIdTransaccion, strEmpresa, strMovimiento, dtmFechaEmision, strConcepto, strProyecto, strMoneda, dblTipoCambio, strReferencia, strObservaciones, strProveedor, strAlmacen, strCondicion, dblDescuentoGlobal, dblImporte, dblImpuestos, dblRetencion, intSucursal, strArticulo, dblCantidad, dblCosto, dblImpuesto1, dblImpuesto2, dblRetencion1, dblRetencion2, dblRetencion3, dblDescuentoImporte, strDescripcionExtra, strContUso, strUnidad) As Boolean

        Dim respuesta As Boolean = False
        Dim conexion As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("SQLConecction"))
        Dim objTransac As SqlTransaction = Nothing
        Try
            conexion.Open()
            Dim command As New SqlCommand("spr_upd_Compra", conexion)
            objTransac = conexion.BeginTransaction

            command.CommandType = CommandType.StoredProcedure
            command.Parameters.AddWithValue("@intIdTransaccion", intIdTransaccion)
            command.Parameters.AddWithValue("@IdErp", 1)
            command.Parameters.AddWithValue("@strEmpresa", strEmpresa)
            command.Parameters.AddWithValue("@strMovimiento", strMovimiento)
            command.Parameters.AddWithValue("@dtmFechaEmision", dtmFechaEmision)
            command.Parameters.AddWithValue("@strConcepto", strConcepto)
            command.Parameters.AddWithValue("@strProyecto", strProyecto)
            command.Parameters.AddWithValue("@strMoneda", strMoneda)
            command.Parameters.AddWithValue("@dblTipoCambio", dblTipoCambio)
            command.Parameters.AddWithValue("@strReferencia", strReferencia)
            command.Parameters.AddWithValue("@strObservaciones", strObservaciones)
            command.Parameters.AddWithValue("@strProveedor", strProveedor)
            command.Parameters.AddWithValue("@strAlmacen", strAlmacen)
            command.Parameters.AddWithValue("@strCondicion", strCondicion)
            command.Parameters.AddWithValue("@dblDescuentoGlobal", dblDescuentoGlobal)
            command.Parameters.AddWithValue("@dblImporte", dblImporte)
            command.Parameters.AddWithValue("@dblImpuestos", dblImpuestos)
            command.Parameters.AddWithValue("@dblRetencion", dblRetencion)
            command.Parameters.AddWithValue("@intSucursal", intSucursal)
            ''Parametros para la tabla de compraD''
            command.Parameters.AddWithValue("@strArticulo", strArticulo)
            command.Parameters.AddWithValue("@dblCantidad", dblCantidad)
            command.Parameters.AddWithValue("@dblCosto", dblCosto)
            command.Parameters.AddWithValue("@dblImpuesto1", dblImpuesto1)
            command.Parameters.AddWithValue("@dblImpuesto2", dblImpuesto2)
            command.Parameters.AddWithValue("@dblRetencion1", dblRetencion1)
            command.Parameters.AddWithValue("@dblRetencion2", dblRetencion2)
            command.Parameters.AddWithValue("@dblRetencion3", dblRetencion3)
            command.Parameters.AddWithValue("@dblDescuentoImporte", dblDescuentoImporte)
            command.Parameters.AddWithValue("@strDescripcionExtra", strDescripcionExtra)
            command.Parameters.AddWithValue("@strContUso", strContUso)
            command.Parameters.AddWithValue("@strUnidad", strUnidad)

            With command
                .Transaction = objTransac
                .ExecuteNonQuery() ' ejecutar  
            End With
            objTransac.Commit()

        Catch ex As DataException

            objTransac.Rollback()
            inLogger.insError("Error en metodo: updCompra()", ex.Message)

        Catch ex As Exception

            objTransac.Rollback()
            inLogger.insError("Error en metodo: updCompra()", ex.Message)

        Finally
            conexion.Close()
            conexion.Dispose()
        End Try

        Return respuesta

    End Function

    Public Function delCompra(intIdTransaccion) As Boolean

        Dim resultado As Boolean = False
        Dim conexion As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("SQLConecction"))
        Dim objTransac As SqlTransaction = Nothing

        Try
            conexion.Open()
            Dim command As New SqlCommand("spr_Del_Compra", conexion)
            objTransac = conexion.BeginTransaction

            command.CommandType = CommandType.StoredProcedure
            command.Parameters.AddWithValue("@intIdTransaccion", intIdTransaccion)

            With command
                .Transaction = objTransac
                .ExecuteNonQuery() ' ejecutar  
            End With

            objTransac.Commit()

        Catch ex As DataException

            objTransac.Rollback()
            inLogger.insError("Error en metodo: delCompra()", ex.Message)

        Catch ex As Exception

            objTransac.Rollback()
            inLogger.insError("Error en metodo: delCompra()", ex.Message)

        Finally
            conexion.Close()
            conexion.Dispose()
        End Try

        Return resultado

    End Function

End Class
