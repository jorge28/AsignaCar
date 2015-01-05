Imports System.Data.SqlClient

Public Class GastoDao
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


    Public Function insGastos(ByVal gastos As gastoVO) As Boolean

        Dim conexion As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("SQLConecction"))
        Dim objTransac As SqlTransaction = Nothing

        Try
            conexion.Open()

            Dim command As New SqlCommand("spr_Ins_Gastos", conexion)
            objTransac = conexion.BeginTransaction
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@intId", SqlDbType.Int).Direction = ParameterDirection.InputOutput
            command.Parameters("@intId").Value = 0
            command.Parameters.AddWithValue("@strTipoBeneficia", gastos.TipoBeneficia)
            command.Parameters.AddWithValue("@strEmpresa", gastos.Empresa)
            command.Parameters.AddWithValue("@strMoneda", gastos.Moneda)
            command.Parameters.AddWithValue("@dtmFechaEmision", gastos.FechaEmision)
            command.Parameters.AddWithValue("@strProyecto", gastos.Proyecto)
            command.Parameters.AddWithValue("@strClase", gastos.Clase)
            command.Parameters.AddWithValue("@strSubClase", gastos.SubClase)
            command.Parameters.AddWithValue("@strObservaciones", gastos.Observaciones)
            command.Parameters.AddWithValue("@strProveedor", gastos.Proveedor)
            command.Parameters.AddWithValue("@intSucursal", gastos.Sucursal)

            ''Parametros de la tabla GastoD
            With command
                .Transaction = objTransac
                .ExecuteNonQuery()
            End With

            Dim id = command.Parameters("@intId").Value

            Dim comman As New SqlCommand("spr_Ins_GastoDetalle", conexion)
            comman.CommandType = CommandType.StoredProcedure
            Dim costo As Integer = 0
            For Each gastoDetalle In gastos.listGastosDetalle
                costo = costo + 1
                comman.Parameters.AddWithValue("@intId", id)
                comman.Parameters.AddWithValue("@intRenglon", costo)
                comman.Parameters.AddWithValue("@strConcepto", gastoDetalle.Concepto)
                comman.Parameters.AddWithValue("@dtmFecha", gastoDetalle.FechaEmision)
                comman.Parameters.AddWithValue("@strReferencia", gastoDetalle.Referencia)
                comman.Parameters.AddWithValue("@strDescripcionExtra", gastoDetalle.DescripcionExtra)
                comman.Parameters.AddWithValue("@dblCantidad", gastoDetalle.Cantidad)
                comman.Parameters.AddWithValue("@dblPrecio", gastoDetalle.Precio)
                comman.Parameters.AddWithValue("@dblRetencion1", gastoDetalle.Retencion)
                comman.Parameters.AddWithValue("@dblRetencion2", gastoDetalle.Retencion2)
                comman.Parameters.AddWithValue("@dblRetencion3", gastoDetalle.Retencion3)
                comman.Parameters.AddWithValue("@dblImpuestos1", gastoDetalle.Impuestos)
                comman.Parameters.AddWithValue("@dblImpuestos2", gastoDetalle.Impuestos2)
                comman.Parameters.AddWithValue("@dblImpuesto1", gastoDetalle.Impuesto)
                comman.Parameters.AddWithValue("@dblImpuesto2", gastoDetalle.Impuesto1)
                comman.Parameters.AddWithValue("@strCentroCostos", gastoDetalle.CentroCostos)

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
            inLogger.insError("Error en metodo: insGastos()", ex.Message)
            Return False
        Catch ex As Exception

            objTransac.Rollback()
            inLogger.insError("Error en metodo: insGastos()", ex.Message)
            Return False
        Finally
            conexion.Close()
            conexion.Dispose()
        End Try

    End Function


    Public Function insertaGastosMovo(ByVal gastos As gastoVO) As Boolean

        Dim conexion As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("SQLConecction"))
        Dim objTransac As SqlTransaction = Nothing

        Try
            conexion.Open()

            Dim command As New SqlCommand("spr_Ins_GastosMovo", conexion)
            objTransac = conexion.BeginTransaction
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("@intId", SqlDbType.Int).Direction = ParameterDirection.InputOutput
            command.Parameters("@intId").Value = 0
            command.Parameters.AddWithValue("@strTipoBeneficia", gastos.TipoBeneficia)
            command.Parameters.AddWithValue("@strEmpresa", gastos.Empresa)
            command.Parameters.AddWithValue("@strMoneda", gastos.Moneda)
            command.Parameters.AddWithValue("@dtmFechaEmision", gastos.FechaEmision)
            command.Parameters.AddWithValue("@strProyecto", gastos.Proyecto)
            command.Parameters.AddWithValue("@strClase", gastos.Clase)
            command.Parameters.AddWithValue("@strSubClase", gastos.SubClase)
            command.Parameters.AddWithValue("@strObservaciones", gastos.Observaciones)
            command.Parameters.AddWithValue("@strProveedor", gastos.Proveedor)
            command.Parameters.AddWithValue("@intSucursal", gastos.Sucursal)
            'Nuevo codigo fase final  
            command.Parameters.AddWithValue("@strCxpCtaDinero", gastos.CxpCtaDinero)
            command.Parameters.AddWithValue("@strCxpCtaProveedor", gastos.CxpCtaProveedor)
            command.Parameters.AddWithValue("@strCxpFormaPago", gastos.CxpFormaPago)
            command.Parameters.AddWithValue("@strCxpConcepto", gastos.CxpConcepto)
            command.Parameters.AddWithValue("@strCxpReferencia", gastos.CxpReferencia)

            ''Parametros de la tabla GastoD
            With command
                .Transaction = objTransac
                .ExecuteNonQuery()
            End With

            Dim id = command.Parameters("@intId").Value

            Dim comman As New SqlCommand("spr_Ins_GastoDetalleMovo", conexion)
            comman.CommandType = CommandType.StoredProcedure
            Dim costo As Integer = 0
            For Each gastoDetalle In gastos.listGastosDetalle
                costo = costo + 1
                comman.Parameters.AddWithValue("@intId", id)
                comman.Parameters.AddWithValue("@intRenglon", costo)
                comman.Parameters.AddWithValue("@strConcepto", gastoDetalle.Concepto)
                comman.Parameters.AddWithValue("@dtmFecha", gastoDetalle.FechaEmision)
                comman.Parameters.AddWithValue("@strReferencia", gastoDetalle.Referencia)
                comman.Parameters.AddWithValue("@strDescripcionExtra", gastoDetalle.DescripcionExtra)
                comman.Parameters.AddWithValue("@dblCantidad", gastoDetalle.Cantidad)
                comman.Parameters.AddWithValue("@dblPrecio", gastoDetalle.Precio)
                comman.Parameters.AddWithValue("@dblRetencion1", gastoDetalle.Retencion)
                comman.Parameters.AddWithValue("@dblRetencion2", gastoDetalle.Retencion2)
                comman.Parameters.AddWithValue("@dblRetencion3", gastoDetalle.Retencion3)
                comman.Parameters.AddWithValue("@dblImpuestos1", gastoDetalle.Impuestos)
                comman.Parameters.AddWithValue("@dblImpuestos2", gastoDetalle.Impuestos2)
                comman.Parameters.AddWithValue("@dblImpuesto1", gastoDetalle.Impuesto)
                comman.Parameters.AddWithValue("@dblImpuesto2", gastoDetalle.Impuesto1)
                comman.Parameters.AddWithValue("@strCentroCostos", gastoDetalle.CentroCostos)

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
            inLogger.insError("Error en metodo: insGastos()", ex.Message)
            Return False
        Catch ex As Exception

            objTransac.Rollback()
            inLogger.insError("Error en metodo: insGastos()", ex.Message)
            Return False
        Finally
            conexion.Close()
            conexion.Dispose()
        End Try

    End Function

    Public Function updGasto(intIdTransaccion, strEmpresa, strMovimiento, dtmFechaEmision, strProyecto, strMoneda, dblTipoCambio, strClase, strSubClase, strObservaciones, strProveedor, dblImporte, dblRetencion, dblImpuestos, intSucursal, strConcepto, dtmFecha, strReferencia, strDescripcionExtra, dblCantidad, dblPrecio, dblImporteD, dblRetencionD, dblRetencion2D, dblRetencion3D, dblImpuesto1D, dblImpuesto2D, strContUso) As Boolean

        Dim respuesta As Boolean = False
        Dim conexion As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("SQLConecction"))
        Dim objTransac As SqlTransaction = Nothing
        Try
            conexion.Open()

            Dim command As New SqlCommand("spr_Upd_Gastos", conexion)
            objTransac = conexion.BeginTransaction
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.AddWithValue("@intIdTransaccion", intIdTransaccion)
            command.Parameters.AddWithValue("@IdErp", 1)
            command.Parameters.AddWithValue("@strEmpresa", strEmpresa)
            command.Parameters.AddWithValue("@strMovimiento", strMovimiento)
            command.Parameters.AddWithValue("@dtmFechaEmision", dtmFechaEmision)
            command.Parameters.AddWithValue("@strProyecto", strProyecto)
            command.Parameters.AddWithValue("@strMoneda", strMoneda)
            command.Parameters.AddWithValue("@dblTipoCambio", dblTipoCambio)
            command.Parameters.AddWithValue("@strClase", strClase)
            command.Parameters.AddWithValue("@strSubClase", strSubClase)
            command.Parameters.AddWithValue("@strObservaciones", strObservaciones)
            command.Parameters.AddWithValue("@dblImporte", dblImporte)
            command.Parameters.AddWithValue("@dblRetencion", dblRetencion)
            command.Parameters.AddWithValue("@dblImpuestos", dblImpuestos)
            command.Parameters.AddWithValue("@intSucursal", intSucursal)
            ''Parametros de la tabla GastoD''
            command.Parameters.AddWithValue("@strConcepto", strConcepto)
            command.Parameters.AddWithValue("@dtmFecha", dtmFecha)
            command.Parameters.AddWithValue("@strReferencia", strReferencia)
            command.Parameters.AddWithValue("@strDescripcionExtra", strDescripcionExtra)
            command.Parameters.AddWithValue("@dblCantidad", dblCantidad)
            command.Parameters.AddWithValue("@dblPrecio", dblPrecio)
            command.Parameters.AddWithValue("@dblImporteD", dblImporteD)
            command.Parameters.AddWithValue("@dblRetencionD", dblRetencionD)
            command.Parameters.AddWithValue("@dblRetencion2D", dblRetencion2D)
            command.Parameters.AddWithValue("@dblRetencion3D", dblRetencion3D)
            command.Parameters.AddWithValue("@dblImpuesto1D", dblImpuesto1D)
            command.Parameters.AddWithValue("@dblImpuesto2D", dblImpuesto2D)
            command.Parameters.AddWithValue("@strContUso", strContUso)

            With command
                .Transaction = objTransac
                .ExecuteNonQuery() ' ejecutar  
            End With
            objTransac.Commit()

        Catch ex As DataException

            objTransac.Rollback()
            inLogger.insError("Error en metodo: updGasto()", ex.Message)

        Catch ex As Exception

            objTransac.Rollback()
            inLogger.insError("Error en metodo: updGasto()", ex.Message)

        Finally
            conexion.Close()
            conexion.Dispose()
        End Try

        Return respuesta

    End Function

    Public Function delGasto(intIdTransaccion) As Boolean

        Dim resultado As Boolean = False
        Dim conexion As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("SQLConecction"))
        Dim objTransac As SqlTransaction = Nothing
        Try
            conexion.Open()
            Dim command As New SqlCommand("spr_Del_Gasto", conexion)
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
            inLogger.insError("Error en metodo: delGasto()", ex.Message)

        Catch ex As Exception

            objTransac.Rollback()
            inLogger.insError("Error en metodo: delGasto()", ex.Message)

        Finally
            conexion.Close()
            conexion.Dispose()
        End Try

        Return resultado

    End Function
End Class
