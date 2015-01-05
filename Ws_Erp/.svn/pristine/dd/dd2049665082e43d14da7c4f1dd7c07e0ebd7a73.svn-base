Imports System.Data.SqlClient

Public Class VentasDao

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

    Public Function insVentas(strTipoBeneficia, strEmpresa, strMoneda, dtmFechaEmision, strProyecto, strReferecia, strObservaciones, strCliente, strAlamacen, strConcepto, intSucursal, strArticulo, dblCantidad, dblPrecio, dblImpuesto1, dblImpuesto2, strCentroCosto, strUnidad) As Boolean
        Dim conexion As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("SQLConecction"))
        Dim objTransac As SqlTransaction = Nothing
        Try
            conexion.Open()
            Dim command As New SqlCommand("spr_Ins_Ventas", conexion)
            objTransac = conexion.BeginTransaction

            command.CommandType = CommandType.StoredProcedure
            command.Parameters.AddWithValue("@strTipoBeneficia", strTipoBeneficia)
            command.Parameters.AddWithValue("@strEmpresa", strEmpresa)
            command.Parameters.AddWithValue("@strMoneda", strMoneda)
            command.Parameters.AddWithValue("@dtmFechaEmision", dtmFechaEmision)
            command.Parameters.AddWithValue("@strProyecto", strProyecto)
            command.Parameters.AddWithValue("@strReferencia", strReferecia)
            command.Parameters.AddWithValue("@strObservaciones", strObservaciones)
            command.Parameters.AddWithValue("@strCliente", strCliente)
            command.Parameters.AddWithValue("@strAlmacen", strAlamacen)
            command.Parameters.AddWithValue("@strConcepto", strConcepto)
            command.Parameters.AddWithValue("@intSucursal", intSucursal)

            ''Parametros para la tabla ventaD
            command.Parameters.AddWithValue("@strArticulo", strArticulo)
            command.Parameters.AddWithValue("@dblCantidad", dblCantidad)
            command.Parameters.AddWithValue("@dblPrecio", dblPrecio)
            command.Parameters.AddWithValue("@dblImpuesto1", dblImpuesto1)
            command.Parameters.AddWithValue("@dblImpuesto2", dblImpuesto2)
            command.Parameters.AddWithValue("@strCentroCosto", strCentroCosto)
            command.Parameters.AddWithValue("@strUnidad", strUnidad)

            With command
                .Transaction = objTransac
                .ExecuteNonQuery() ' ejecutar  
            End With

            objTransac.Commit()
            Return True
        Catch ex As DataException

            objTransac.Rollback()
            inLogger.insError("Error en metodo: insVentas()", ex.Message)
            Return False
        Catch ex As Exception

            objTransac.Rollback()
            inLogger.insError("Error en metodo: insVentas()", ex.Message)
            Return False
        Finally
            conexion.Close()
            conexion.Dispose()
        End Try
    End Function

    Public Function updVentas(intIdTransaccion, strEmpresa, strMoneda, dtmFechaEmision, strProyecto, strReferecia, strObservaciones, strCliente, strAlamacen, strConcepto, intSucursal, dblCantidad, strArticulo, dblPrecio, dblImpuesto1, dblImpuesto2, strContUsu, strUnidad) As Boolean

        Dim strRespuesta As Boolean = False
        Dim conexion As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("SQLConecction"))
        Dim objTransac As SqlTransaction = Nothing
        Try
            conexion.Open()
            Dim command As New SqlCommand("spr_Upd_Venta", conexion)
            objTransac = conexion.BeginTransaction

            command.CommandType = CommandType.StoredProcedure
            command.Parameters.AddWithValue("@intIdTransaccion", intIdTransaccion)
            command.Parameters.AddWithValue("@strEmpresa", strEmpresa)
            command.Parameters.AddWithValue("@strMoneda", strMoneda)
            command.Parameters.AddWithValue("@dtmFechaEmision", dtmFechaEmision)
            command.Parameters.AddWithValue("@strProyecto", strProyecto)
            command.Parameters.AddWithValue("@strReferencia", strReferecia)
            command.Parameters.AddWithValue("@strObservaciones", strObservaciones)
            command.Parameters.AddWithValue("@strCliente", strCliente)
            command.Parameters.AddWithValue("@strAlmacen", strAlamacen)
            command.Parameters.AddWithValue("@strConcepto", strConcepto)
            command.Parameters.AddWithValue("@intSucursal", intSucursal)
            ''Parametros para la tabla VentaD
            command.Parameters.AddWithValue("@strArticulo", strArticulo)
            command.Parameters.AddWithValue("@dblCantidad", dblCantidad)
            command.Parameters.AddWithValue("@dblPrecio", dblPrecio)
            command.Parameters.AddWithValue("@dblImpuesto1", dblImpuesto1)
            command.Parameters.AddWithValue("@dblImpuesto2", dblImpuesto2)
            command.Parameters.AddWithValue("@sstrContUso", strContUsu)
            command.Parameters.AddWithValue("@strUnidad", strUnidad)

            With command
                .Transaction = objTransac
                .ExecuteNonQuery() ' ejecutar  
            End With
            objTransac.Commit()

        Catch ex As DataException

            objTransac.Rollback()
            inLogger.insError("Error en metodo: updVentas()", ex.Message)

        Catch ex As Exception

            objTransac.Rollback()
            inLogger.insError("Error en metodo: updVentas()", ex.Message)

        Finally
            conexion.Close()
            conexion.Dispose()
        End Try
        Return strRespuesta

    End Function

    Public Function delVenta(intIdTransaccion) As Boolean

        Dim strRespuesta As Boolean = False
        Dim conexion As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("SQLConecction"))
        Dim objTransac As SqlTransaction = Nothing
        Try
            conexion.Open()
            Dim command As New SqlCommand("spr_Del_Venta", conexion)
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
            inLogger.insError("Error en metodo: delVenta()", ex.Message)

        Catch ex As Exception

            objTransac.Rollback()
            inLogger.insError("Error en metodo: delVenta()", ex.Message)

        Finally
            conexion.Close()
            conexion.Dispose()
        End Try
        Return strRespuesta

    End Function

    'Metodo utlizando objetos (FINAL)'

    Public Function insVentasMovo(ByVal facturaM As facturaVO) As Boolean
        Dim strRespuesta As String = "Exito"
        Dim conexion As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("SQLConecction"))
        Dim objTransac As SqlTransaction = Nothing
        Try
            conexion.Open()
            Dim command As New SqlCommand("spr_Ins_VentasMovo", conexion)
            objTransac = conexion.BeginTransaction
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@intId", SqlDbType.Int).Direction = ParameterDirection.InputOutput
            command.Parameters("@intId").Value = 0
            command.Parameters.AddWithValue("@strTipoBeneficia", facturaM.TipoBeneficia)
            command.Parameters.AddWithValue("@strEmpresa", facturaM.ClaveIntelisis)
            command.Parameters.AddWithValue("@strMoneda", facturaM.TipoMoneda)
            command.Parameters.AddWithValue("@dtmFechaEmision", facturaM.Fecha)
            command.Parameters.AddWithValue("@strProyecto", facturaM.Proyecto)
            command.Parameters.AddWithValue("@strReferencia", facturaM.Referencia)
            command.Parameters.AddWithValue("@strObservaciones", facturaM.Descripcion)
            command.Parameters.AddWithValue("@strCliente", facturaM.Empresa)
            command.Parameters.AddWithValue("@strAlmacen", facturaM.Almacen)
            command.Parameters.AddWithValue("@strConcepto", facturaM.Concepto)
            command.Parameters.AddWithValue("@strCondicionPago", facturaM.CondicionPago)
            command.Parameters.AddWithValue("@intSucursal", facturaM.Sucursal)
            command.Parameters.AddWithValue("@strCxcCtaDinero", facturaM.CxcCtaDinero)
            command.Parameters.AddWithValue("@strCxcFormaPago", facturaM.CxcFormaPago)
            command.Parameters.AddWithValue("@bitAvanzar", facturaM.Avanzar)
            command.Parameters.AddWithValue("@strNoSiniestro", facturaM.NoSiniestro)
            command.Parameters.AddWithValue("@strNoPoliza", facturaM.NoPoliza)
            command.Parameters.AddWithValue("@strModelo", facturaM.Modelo)
            command.Parameters.AddWithValue("@strNoVIN", facturaM.NoVIN)
            command.Parameters.AddWithValue("@strNombre", facturaM.Nombre)
            command.Parameters.AddWithValue("@strMarca", facturaM.Marca)
            command.Parameters.AddWithValue("@strSubMarca", facturaM.SubMarca)
            command.Parameters.AddWithValue("@strArticuloServ", facturaM.ArticuloServ)

            With command
                .Transaction = objTransac
                .ExecuteNonQuery() ' ejecutar  
            End With

            Dim id = command.Parameters("@intId").Value

            Dim comman As New SqlCommand("spr_Ins_VentasDetalleM", conexion)
            comman.CommandType = CommandType.StoredProcedure
            Dim costo As Integer = 0
            For Each facturaD In facturaM.listfacturaDetalle
                costo = costo + 1
                comman.Parameters.AddWithValue("@intId", id)
                comman.Parameters.AddWithValue("@intRenglon", costo)
                comman.Parameters.AddWithValue("@strArticulo", facturaD.Articulo)
                comman.Parameters.AddWithValue("@dblCantidad", facturaD.Cantidad)
                comman.Parameters.AddWithValue("@dblPrecio", facturaD.ImporteT)
                comman.Parameters.AddWithValue("@dblImpuesto1", facturaD.IVA)
                comman.Parameters.AddWithValue("@dblImpuesto2", facturaD.Impuesto2)
                comman.Parameters.AddWithValue("@strCentroCosto", facturaD.CentroCostos)
                comman.Parameters.AddWithValue("@strUnidad", facturaD.Unidad)

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
            inLogger.insError("Error en metodo: insVentas()", ex.Message)
            Return False

        Catch ex As Exception

            objTransac.Rollback()
            inLogger.insError("Error en metodo: insVentas()", ex.Message)
            Return False
        Finally
            conexion.Close()
            conexion.Dispose()
        End Try
        Return strRespuesta
    End Function

    Public Function insVentasP(ByVal factura As facturaVO) As String

        Dim strRespuesta As String = "Exito"
        Dim conexion As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("SQLConecction"))
        Dim objTransac As SqlTransaction = Nothing
        Try
            conexion.Open()
            Dim command As New SqlCommand("spr_Ins_Ventas", conexion)
            objTransac = conexion.BeginTransaction

            command.CommandType = CommandType.StoredProcedure
            command.Parameters.AddWithValue("@strTipoBeneficia", factura.TipoBeneficia)
            command.Parameters.AddWithValue("@strEmpresa", factura.Empresa)
            command.Parameters.AddWithValue("@strMoneda", factura.TipoMoneda)
            command.Parameters.AddWithValue("@dtmFechaEmision", factura.Fecha)
            command.Parameters.AddWithValue("@strProyecto", factura.Proyecto)
            command.Parameters.AddWithValue("@strReferencia", factura.Referencia)
            command.Parameters.AddWithValue("@strObservaciones", factura.Descripcion)
            command.Parameters.AddWithValue("@strCliente", factura.ClaveIntelisis)
            command.Parameters.AddWithValue("@strAlmacen", factura.Almacen)
            command.Parameters.AddWithValue("@strConcepto", factura.Concepto)
            command.Parameters.AddWithValue("@intSucursal", factura.Sucursal)
            command.Parameters.AddWithValue("@strArticulo", factura.Articulo)
            command.Parameters.AddWithValue("@dblCantidad", factura.Cantidad)
            command.Parameters.AddWithValue("@dblPrecio", factura.ImporteT)
            command.Parameters.AddWithValue("@dblImpuesto1", factura.IVA)
            command.Parameters.AddWithValue("@dblImpuesto2", factura.Impuesto2)
            command.Parameters.AddWithValue("@strCentroCosto", factura.CentroCostos)
            command.Parameters.AddWithValue("@strUnidad", factura.Unidad)

            With command
                .Transaction = objTransac
                .ExecuteNonQuery() ' ejecutar  
            End With

            objTransac.Commit()

        Catch ex As DataException

            objTransac.Rollback()
            inLogger.insError("Error en metodo: insVentas()", ex.Message)
            Return strRespuesta = "Error"

        Catch ex As Exception

            objTransac.Rollback()
            inLogger.insError("Error en metodo: insVentas()", ex.Message)
            Return strRespuesta = "Error"
        Finally
            conexion.Close()
            conexion.Dispose()
        End Try
        Return strRespuesta

    End Function

End Class
