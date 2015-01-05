Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports System.IO

' Para permitir que se llame a este servicio Web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class Service1
    Inherits System.Web.Services.WebService
    Dim daoVentas As VentasDao = New VentasDao()
    Dim daoGastos As GastoDao = New GastoDao()
    Dim inLogger As ILogger = New ILogger()
    Dim daoCompras As ComprasDao = New ComprasDao()
    Dim daoTesoreria As TesoreriaDao = New TesoreriaDao()
    Dim daoInventario As InventarioDAO = New InventarioDAO()
    Dim val As Validaciones = New Validaciones()
    Dim daoLogin As LoginDao = New LoginDao()
    Dim selCatalogo As CatalogosMovo = New CatalogosMovo()
    Dim convertNG As ConvertNG = New ConvertNG()
    Dim strMensaje As String
    Dim Usuario As String = "admin"
    Dim Contraseña As String = "secret42"
    Dim blnExito As Boolean
    Dim xml As fileXML = New fileXML()
    Dim numValidos As Integer
    Dim numError As Integer


#Region "Ventas"

    <WebMethod()> _
    Public Function insVentas(ByVal Usuario As String, ByVal Contraseña As String, ByVal strTipoBeneficia As String, ByVal strEmpresa As String, ByVal strMoneda As String, ByVal dtmFechaEmision As Date, ByVal strProyecto As String, ByVal strReferecia As String, ByVal strObservaciones As String, ByVal strCliente As String, ByVal strAlamacen As String, ByVal strConcepto As String, ByVal intSucursal As Integer, ByVal strArticulo As String, ByVal dblCantidad As Double, ByVal dblPrecio As Double, ByVal dblImpuesto1 As Double, ByVal dblImpuesto2 As Double, ByVal strCentroCosto As String, ByVal strUnidad As String) As objError
        Dim objError = New objError()
        objError.ObjError = False
        objError.StrMensaje = ""

        If Usuario = "" Or Contraseña = "" Then
            objError.StrMensaje = xml.Leer_XML(1)
        Else
            Try
                blnExito = daoLogin.selUsuario(Usuario, Contraseña)
                If blnExito = True Then
                    objError.StrMensaje = val.validaVenta(strEmpresa, strMoneda, strProyecto, strCliente, strAlamacen, strConcepto, intSucursal, strArticulo, strCentroCosto, strUnidad)
                    If objError.StrMensaje = String.Empty Then
                        objError.ObjError = daoVentas.insVentas(strTipoBeneficia, strEmpresa, strMoneda, dtmFechaEmision, strProyecto, strReferecia, strObservaciones, strCliente, strAlamacen, strConcepto, intSucursal, strArticulo, dblCantidad, dblPrecio, dblImpuesto1, dblImpuesto2, strCentroCosto, strUnidad)
                    End If
                Else
                    numError = numError + 1
                    objError.ObjError = False
                    objError.StrMensaje = xml.Leer_XML(2)
                    objError.NumeroError = numError
                End If
            Catch ex As Exception
                inLogger.insError("Error en metodo de Web Services: insVentas()", ex.Message)
                objError.ObjError = False
            End Try
        End If
        Return objError
    End Function

    <WebMethod()> _
    Public Function insVentasP(ByVal factura As facturaVO) As objError

        Dim objError = New objError()
        objError.ObjError = False
        objError.StrMensaje = ""

        If Usuario = "" Or Contraseña = "" Then
            strMensaje = xml.Leer_XML(1)
        Else
            Try
                blnExito = daoLogin.selUsuario(Usuario, Contraseña)
                If blnExito = True Then

                    objError.StrMensaje = val.validaVenta(factura.Empresa, factura.TipoMoneda, factura.Proyecto, factura.ClaveIntelisis, factura.Almacen, factura.Concepto, factura.Sucursal, factura.Articulo, factura.CentroCostos, factura.Unidad)

                    If objError.StrMensaje = String.Empty Then
                        Dim errorDes = daoVentas.insVentasP(factura)
                    End If
                Else
                    objError.StrMensaje = xml.Leer_XML(2)
                    objError.ObjError = False
                End If
            Catch ex As Exception
                inLogger.insError("Error en metodo de Web Services: insVentas()", ex.Message)
            End Try
        End If
        Return objError

    End Function

    <WebMethod()> _
    Public Function insVentasXml(ByVal facturaxml As String) As objError

        Dim objError = New objError()
        objError.ObjError = False
        objError.StrMensaje = ""

        Dim ms As MemoryStream
        Dim buf() As Byte
        Dim ds As New DataSet

        If Usuario = "" Or Contraseña = "" Then
            objError.StrMensaje = xml.Leer_XML(1)
        Else
            Try
                blnExito = daoLogin.selUsuario(Usuario, Contraseña)
                If blnExito = True Then

                    buf = System.Text.ASCIIEncoding.ASCII.GetBytes(facturaxml)
                    ms = New MemoryStream(buf)
                    ds.ReadXml(ms)

                    Dim facturaVo As facturaVO = New facturaVO

                    facturaVo = convertNG.leeVOFactura(ds)

                    'objError.StrMensaje = val.validaVentaFinal(facturaVo.Empresa, facturaVo.TipoMoneda, strCliente, facturaVo.Almacen, strConcepto, intSucursal, facturaVo.Articulo, facturaVo.CentroCostos, facturaVo.Unidad)

                    If objError.StrMensaje = String.Empty Then

                        objError.ObjError = daoVentas.insVentasMovo(facturaVo)

                    End If

                Else
                    objError.StrMensaje = xml.Leer_XML(2)
                    objError.ObjError = False
                End If
            Catch ex As Exception
                inLogger.insError("Error en metodo de Web Services: insVentasXml()", ex.Message)
            End Try
        End If
        Return objError
    End Function

    <WebMethod()> _
    Public Function insertaVentasMovo(ByVal factura As facturaVO) As objError

        Dim objError = New objError()
        objError.ObjError = False
        objError.StrMensaje = ""

        If Usuario = "" Or Contraseña = "" Then
            strMensaje = xml.Leer_XML(1)
        Else
            Try
                blnExito = daoLogin.selUsuario(Usuario, Contraseña)
                If blnExito = True Then

                    objError.StrMensaje = val.validaVenta(factura.Empresa, factura.TipoMoneda, factura.Proyecto, factura.ClaveIntelisis, factura.Almacen, factura.Concepto, factura.Sucursal, factura.Articulo, factura.CentroCostos, factura.Unidad)

                    If objError.StrMensaje = String.Empty Then
                        Dim errorDes = daoVentas.insVentasMovo(factura)
                    End If
                Else
                    objError.StrMensaje = xml.Leer_XML(2)
                    objError.ObjError = False
                End If
            Catch ex As Exception
                inLogger.insError("Error en metodo de Web Services: insVentas()", ex.Message)
            End Try
        End If
        Return objError

    End Function

    <WebMethod()> _
    Public Function updVentas(ByVal Usuario As String, ByVal Contraseña As String, ByVal intIdTransaccion As String, ByVal strEmpresa As String, ByVal strMov As String, ByVal strMoneda As String, ByVal dtmFechaEmision As Date, ByVal strProyecto As String, ByVal strReferecia As String, ByVal strObservaciones As String, ByVal strCliente As String, ByVal strAlamacen As String, ByVal strConcepto As String, ByVal dblImporte As Double, ByVal dblImpuestos As Double, ByVal intSucursal As Integer, ByVal dblCantidad As Double, ByVal strArticulo As String, ByVal dblPrecio As Double, ByVal dblImpuesto1 As Double, ByVal dblImpuesto2 As Double, ByVal strContUsu As String, ByVal strUnidad As String) As String

        blnExito = False
        strMensaje = xml.Leer_XML(3)

        If Usuario = "" Or Contraseña = "" Then
            strMensaje = xml.Leer_XML(1)
        Else
            Try
                blnExito = daoLogin.selUsuario(Usuario, Contraseña)
                If blnExito = True Then
                    daoVentas.updVentas(intIdTransaccion, strEmpresa, strMoneda, dtmFechaEmision, strProyecto, strReferecia, strCliente, strObservaciones, strAlamacen, strConcepto, intSucursal, dblCantidad, strArticulo, dblPrecio, dblImpuesto1, dblImpuesto2, strContUsu, strUnidad)
                Else
                    'insVentasDetalle(strEmpresa, strMov)
                    strMensaje = xml.Leer_XML(2)
                End If
            Catch ex As Exception
                inLogger.insError("Error en metodo de Web Services: updVentas()", ex.Message)
            End Try
        End If
        Return strMensaje

    End Function

    <WebMethod()> _
    Public Function delVentas(ByVal Usuario As String, ByVal Contraseña As String, ByVal intIdTransaccion As String) As String

        blnExito = False
        strMensaje = xml.Leer_XML(3)
        If Usuario = "" Or Contraseña = "" Then
            strMensaje = xml.Leer_XML(1)
        Else
            Try
                blnExito = daoLogin.selUsuario(Usuario, Contraseña)
                If blnExito = True Then
                    daoVentas.delVenta(intIdTransaccion)
                Else
                    strMensaje = xml.Leer_XML(2)
                End If
            Catch ex As Exception
                inLogger.insError("Error en metodo de Web Services: delVentas()", ex.Message)
            End Try
        End If
        Return strMensaje

    End Function

#End Region

#Region "Gastos"
 
    <WebMethod()> _
    Public Function insGastosXml(ByVal gastosXml As String) As objError

        Dim objError = New objError()
        objError.ObjError = False
        objError.StrMensaje = ""

        Dim ms As MemoryStream
        Dim buf() As Byte
        Dim ds As New DataSet

        If Usuario = "" Or Contraseña = "" Then
            strMensaje = xml.Leer_XML(1)
        Else
            Try
                blnExito = daoLogin.selUsuario(Usuario, Contraseña)
                If blnExito = True Then

                    buf = System.Text.ASCIIEncoding.ASCII.GetBytes(gastosXml)
                    ms = New MemoryStream(buf)
                    ds.ReadXml(ms)

                    Dim gastoVo As gastoVO = New gastoVO

                    gastoVo = convertNG.leeVOGasto(ds)

                    objError.StrMensaje = val.validaGastoVO(gastoVo)

                    If objError.StrMensaje = String.Empty Then
                        objError.ObjError = daoGastos.insGastos(gastoVo)
                    End If
                Else
                    objError.StrMensaje = xml.Leer_XML(2)
                    objError.ObjError = False
                End If
            Catch ex As Exception
                inLogger.insError("Error en metodo de Web Services: insGastosXml()", ex.Message)
            End Try
        End If
        Return objError

    End Function
 
    <WebMethod()> _
    Public Function insGastos(ByVal gastosVo As gastoVO) As objError

        Dim objError = New objError()
        Dim errora As String
        objError.ObjError = False
        objError.StrMensaje = ""

        If Usuario = "" Or Contraseña = "" Then
            strMensaje = xml.Leer_XML(1)
        Else
            Try
                blnExito = daoLogin.selUsuario(Usuario, Contraseña)
                If blnExito = True Then

                    errora = val.validaGastoVO(gastosVo)
                   
                    If errora = String.Empty Then

                        objError.ObjError = daoGastos.insGastos(gastosVo)

                        If objError.ObjError = True Then
                            numValidos = numValidos + 1
                            objError.NumeroVal = numValidos
                        End If
                    Else
                        numError = numError + 1
                        objError.StrMensaje = errora
                        objError.Proveedor = gastosVo.Proveedor
                        objError.NumeroError = numError

                    End If
                Else
                    objError.StrMensaje = xml.Leer_XML(2)
                    objError.ObjError = False
                End If
            Catch ex As Exception
                inLogger.insError("Error en metodo de Web Services: insGastos()", ex.Message)
            End Try
        End If
        Return objError

    End Function

    <WebMethod()> _
    Public Function insertaGastosMovo(ByVal gastosVo As gastoVO) As objError

        Dim objError = New objError()
        Dim errora As String
        objError.ObjError = False
        objError.StrMensaje = ""

        If Usuario = "" Or Contraseña = "" Then
            strMensaje = xml.Leer_XML(1)
        Else
            Try
                blnExito = daoLogin.selUsuario(Usuario, Contraseña)
                If blnExito = True Then

                    errora = val.validaGastoVO(gastosVo)

                    If errora = String.Empty Then

                        objError.ObjError = daoGastos.insertaGastosMovo(gastosVo)

                        If objError.ObjError = True Then
                            numValidos = numValidos + 1
                            objError.NumeroVal = numValidos
                        End If
                    Else
                        numError = numError + 1
                        objError.StrMensaje = errora
                        objError.Proveedor = gastosVo.Proveedor
                        objError.NumeroError = numError

                    End If
                Else
                    objError.StrMensaje = xml.Leer_XML(2)
                    objError.ObjError = False
                End If
            Catch ex As Exception
                inLogger.insError("Error en metodo de Web Services: insGastos()", ex.Message)
            End Try
        End If
        Return objError

    End Function

    <WebMethod()> _
    Public Function updGasto(ByVal Usuario As String, ByVal Contraseña As String, ByVal intIdTransaccion As String, ByVal Empresa As String, ByVal Movimiento As String, ByVal FechaEmision As Date, ByVal Proyecto As String, ByVal Moneda As String, ByVal TipoCambio As Double, ByVal Clase As String, ByVal SubClase As String, ByVal Observaciones As String, ByVal Proveedor As String, ByVal Importe As Double, ByVal Retencion As Double, ByVal Impuestos As Double, ByVal Sucursal As Integer, ByVal strConcepto As String, ByVal dtmFecha As Date, ByVal strReferencia As String, ByVal strDescripcionExtra As String, ByVal dblCantidad As Double, ByVal dblPrecio As Double, ByVal dblImporteD As Double, ByVal dblRetencionD As Double, ByVal dblRetencion2D As Double, ByVal dblRetencion3D As Double, ByVal dblImpuesto1D As Double, ByVal dblImpuesto2D As Double, ByVal strContUso As String) As String

        blnExito = False
        strMensaje = xml.Leer_XML(3)

        If Usuario = "" Or Contraseña = "" Then
            strMensaje = xml.Leer_XML(1)
        Else
            Try
                blnExito = daoLogin.selUsuario(Usuario, Contraseña)
                If blnExito = True Then
                    daoGastos.updGasto(intIdTransaccion, Empresa, Movimiento, FechaEmision, Proyecto, Moneda, TipoCambio, Clase, SubClase, Observaciones, Proveedor, Importe, Retencion, Impuestos, Sucursal, strConcepto, dtmFecha, strReferencia, strDescripcionExtra, dblCantidad, dblPrecio, dblImporteD, dblRetencionD, dblRetencion2D, dblRetencion3D, dblImpuesto1D, dblImpuesto2D, strContUso)
                Else
                    'insVentasDetalle(strEmpresa, strMov)
                    strMensaje = xml.Leer_XML(2)
                End If
            Catch ex As Exception
                inLogger.insError("Error en metodo de Web Services: updGasto()", ex.Message)
            End Try
        End If
        Return strMensaje

    End Function

    <WebMethod()> _
    Public Function delGasto(ByVal Usuario As String, ByVal Contraseña As String, ByVal intIdTransaccion As String) As String

        blnExito = False
        strMensaje = xml.Leer_XML(3)

        If Usuario = "" Or Contraseña = "" Then
            strMensaje = xml.Leer_XML(1)
        Else
            Try
                blnExito = daoLogin.selUsuario(Usuario, Contraseña)
                If blnExito = True Then
                    daoGastos.delGasto(intIdTransaccion)
                Else
                    strMensaje = xml.Leer_XML(2)
                End If
            Catch ex As Exception
                inLogger.insError("Error en metodo de Web Services: delGasto()", ex.Message)
            End Try
        End If
        Return strMensaje

    End Function

#End Region

#Region "Compras"

    <WebMethod()> _
    Public Function insCompraXml(ByVal gastosXml As String) As objError

        Dim objError = New objError()
        objError.ObjError = False
        objError.StrMensaje = ""

        Dim ms As MemoryStream
        Dim buf() As Byte
        Dim ds As New DataSet


        If Usuario = "" Or Contraseña = "" Then
            strMensaje = xml.Leer_XML(1)
        Else
            Try
                'blnExito = daoLogin.selUsuario(Usuario, Contraseña)
                'If blnExito = True Then
                buf = System.Text.ASCIIEncoding.ASCII.GetBytes(gastosXml)
                ms = New MemoryStream(buf)
                ds.ReadXml(ms)

                Dim comprasVo As comprasVO = New comprasVO

                comprasVo = convertNG.leeVOCompra(ds)

                objError.ObjError = daoCompras.insComprasXml(comprasVo)
                ''Else
                'strMensaje = xml.Leer_XML(2)
                'End If
            Catch ex As Exception
                inLogger.insError("Error en metodo de Web Services: insCompraXml()", ex.Message)
            End Try
        End If
        Return objError

    End Function

    <WebMethod()> _
    Public Function updCompra(ByVal Usuario As String, ByVal Contraseña As String, ByVal intIdTransaccion As String, ByVal Empresa As String, ByVal Movimiento As String, ByVal FechaEmision As Date, ByVal Concepto As String, ByVal Proyecto As String, ByVal Moneda As String, ByVal TipoCambio As Double, ByVal Referencia As String, ByVal Observaciones As String, ByVal Proveedor As String, ByVal Almacen As String, ByVal Condicion As String, ByVal DescuentoGlobal As Double, ByVal Importe As Double, ByVal Impuestos As Double, ByVal Retencion As Double, ByVal Sucursal As Integer, ByVal strArticulo As String, ByVal dblCantidad As Double, ByVal dblCosto As Double, ByVal dblImpuesto1 As Double, ByVal dblImpuesto2 As Double, ByVal dblRetencion1 As Double, ByVal dblRetencion2 As Double, ByVal dblRetencion3 As Double, ByVal dblDescuentoImporte As Double, ByVal strDescripcionExtra As String, ByVal strContUso As String, ByVal strUnidad As String) As String

        blnExito = False
        strMensaje = xml.Leer_XML(3)

        If Usuario = "" Or Contraseña = "" Then
            strMensaje = xml.Leer_XML(1)
        Else
            Try
                blnExito = daoLogin.selUsuario(Usuario, Contraseña)
                If blnExito = True Then
                    daoCompras.updCompra(intIdTransaccion, Empresa, Movimiento, FechaEmision, Concepto, Proyecto, Moneda, TipoCambio, Referencia, Observaciones, Proveedor, Almacen, Condicion, DescuentoGlobal, Importe, Impuestos, Retencion, Sucursal, strArticulo, dblCantidad, dblCosto, dblImpuesto1, dblImpuesto2, dblRetencion1, dblRetencion2, dblRetencion3, dblDescuentoImporte, strDescripcionExtra, strContUso, strUnidad)
                Else
                    strMensaje = xml.Leer_XML(2)
                End If
            Catch ex As Exception
                inLogger.insError("Error en metodo de Web Services: updCompra()", ex.Message)
            End Try
        End If
        Return strMensaje

    End Function

    <WebMethod()> _
    Public Function delCompra(ByVal Usuario As String, ByVal Contraseña As String, ByVal intIdTransaccion As String) As String

        blnExito = False
        strMensaje = xml.Leer_XML(3)

        If Usuario = "" Or Contraseña = "" Then
            strMensaje = xml.Leer_XML(1)
        Else
            Try
                blnExito = daoLogin.selUsuario(Usuario, Contraseña)
                If blnExito = True Then
                    daoCompras.delCompra(intIdTransaccion)
                Else
                    strMensaje = xml.Leer_XML(2)
                End If
            Catch ex As Exception
                inLogger.insError("Error en metodo de Web Services: delCompra()", ex.Message)
            End Try
        End If
        Return strMensaje

    End Function

#End Region

#Region "Inventarios"

    <WebMethod()> _
    Public Function insInventario(ByVal inventarioVo As inventarioVO) As objError

        Dim objError = New objError()
        Dim errora As String
        objError.ObjError = False
        objError.StrMensaje = ""

        If Usuario = "" Or Contraseña = "" Then
            strMensaje = xml.Leer_XML(1)
        Else
            Try
                blnExito = daoLogin.selUsuario(Usuario, Contraseña)
                If blnExito = True Then

                    errora = val.validaInventarioVO(inventarioVo)

                    If errora = String.Empty Then

                        objError.ObjError = daoInventario.insInventario(inventarioVo)

                        If objError.ObjError = True Then
                            numValidos = numValidos + 1
                            objError.NumeroVal = numValidos
                        End If
                    Else
                        numError = numError + 1
                        objError.StrMensaje = errora
                        objError.NumeroError = numError

                    End If
                Else
                    objError.StrMensaje = xml.Leer_XML(2)
                    objError.ObjError = False
                End If
            Catch ex As Exception
                inLogger.insError("Error en metodo de Web Services: insInventario()", ex.Message)
            End Try
        End If
        Return objError

    End Function

    <WebMethod()> _
    Public Function insInventarioXml(ByVal inventarioXml As String) As objError

        Dim objError = New objError()
        objError.ObjError = False
        objError.StrMensaje = ""

        Dim ms As MemoryStream
        Dim buf() As Byte
        Dim ds As New DataSet

        If Usuario = "" Or Contraseña = "" Then
            strMensaje = xml.Leer_XML(1)
        Else
            Try
                blnExito = daoLogin.selUsuario(Usuario, Contraseña)
                If blnExito = True Then

                    buf = System.Text.ASCIIEncoding.ASCII.GetBytes(inventarioXml)
                    ms = New MemoryStream(buf)
                    ds.ReadXml(ms)

                    Dim inventarioVo As inventarioVO = New inventarioVO
                    inventarioVo = convertNG.leeVOInventario(ds)

                    objError.StrMensaje = val.validaInventarioVO(inventarioVo)

                    If objError.StrMensaje = String.Empty Then
                        objError.ObjError = daoInventario.insInventario(inventarioVo)
                    End If
                Else
                    objError.StrMensaje = xml.Leer_XML(2)
                    objError.ObjError = False
                End If
            Catch ex As Exception
                inLogger.insError("Error en metodo de Web Services: insInventarioXml()", ex.Message)
            End Try
        End If
        Return objError

    End Function

#End Region

#Region "Tesoreria"

    <WebMethod()> _
    Public Function selTesoreria() As DataTable

        'Dim tesoreria As New List(Of EntTesoreria)()
        Dim list As New DataTable("Tesoreria")
        list = daoTesoreria.selTesoreria()
        Return list

    End Function

#End Region

#Region "Metodos MOVO"

    <WebMethod()> _
    Public Function selCatalogos() As DataSet

        Dim dsCatalogos = New DataSet()


        dsCatalogos = selCatalogo.ObtenerDatos()


        Return dsCatalogos


    End Function

    <WebMethod()> _
    Public Function selCatalogoXNombre(ByVal strNombre As String) As DataSet

        Dim dtCatalogos = New DataSet()

        dtCatalogos = selCatalogo.GetCatalogoXNombre(strNombre)

        Return dtCatalogos

    End Function

#End Region

End Class