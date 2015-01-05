Public Class ConvertNG

    Public Function leeVOFactura(ByVal dsFactura As DataSet) As facturaVO

        Dim facturaVo As facturaVO = New facturaVO
        Dim facturaDVo As facturaDetalleVO = New facturaDetalleVO
        Dim lstFacturaDetalle As New List(Of facturaDetalleVO)()

        For Each row As DataRow In dsFactura.Tables(0).Rows

            facturaVo = New facturaVO
            facturaVo.listfacturaDetalle = New List(Of facturaDetalleVO)()
            facturaVo.TipoBeneficia = row("TipoBeneficia")
            facturaVo.Empresa = row("Empresa")
            facturaVo.TipoMoneda = row("Moneda")
            facturaVo.Fecha = row("FechaEmision")
            facturaVo.Proyecto = row("Proyecto")
            facturaVo.Referencia = row("Referencia")
            facturaVo.Descripcion = row("Observaciones")
            facturaVo.ClaveIntelisis = row("Cliente")
            facturaVo.Almacen = row("Almacen")
            facturaVo.Concepto = row("Concepto")
            facturaVo.Sucursal = row("Sucursal")
            facturaVo.NoSiniestro = row("NoSiniestro")
            facturaVo.NoPoliza = row("NoPoliza")
            facturaVo.Modelo = row("Modelo")
            facturaVo.NoVIN = row("NoVIN")
            facturaVo.Nombre = row("Nombre")
            facturaVo.Marca = row("Marca")
            facturaVo.SubMarca = row("SubMarca")
            facturaVo.ArticuloServ = row("ArticuloServ")

            'detail
            For Each rowd As DataRow In dsFactura.Tables(1).Rows

                lstFacturaDetalle = New List(Of facturaDetalleVO)()
                lstFacturaDetalle.Add(New facturaDetalleVO() With {
                                          .Articulo = rowd("Articulo"),
                                          .Cantidad = rowd("Cantidad"),
                                          .ImporteT = rowd("Precio"),
                                          .IVA = rowd("Impuesto1"),
                                          .Impuesto2 = rowd("Impuesto2"),
                                          .CentroCostos = rowd("CentroCostos"),
                                          .Unidad = rowd("Unidad")})

                For Each facturaD In lstFacturaDetalle

                    facturaDVo = New facturaDetalleVO
                    facturaDVo.Articulo = facturaD.Articulo
                    facturaDVo.Cantidad = facturaD.Cantidad
                    facturaDVo.ImporteT = facturaD.ImporteT
                    facturaDVo.IVA = facturaD.IVA
                    facturaDVo.Impuesto2 = facturaD.Impuesto2
                    facturaDVo.CentroCostos = facturaD.CentroCostos
                    facturaDVo.Unidad = facturaD.Unidad

                    facturaVo.listfacturaDetalle.Add(facturaDVo)
                Next
            Next
        Next
        Return facturaVo
    End Function

    Public Function leeVOGasto(ByVal dsGasto As DataSet) As gastoVO
        Dim gastoVo As gastoVO = New gastoVO
        Dim gastoDVo As gastoDetalleVO = New gastoDetalleVO
        Dim lstGastoDetalle As New List(Of gastoDetalleVO)()

        For Each row As DataRow In dsGasto.Tables(0).Rows

            gastoVo = New gastoVO
            gastoVo.listGastosDetalle = New List(Of gastoDetalleVO)()
            gastoVo.TipoBeneficia = row("TipoBeneficia")
            gastoVo.Empresa = row("Empresa")
            gastoVo.Moneda = row("Moneda")
            gastoVo.FechaEmision = row("FechaEmision")
            gastoVo.Proyecto = row("Proyecto")
            gastoVo.Clase = row("Clase")
            gastoVo.SubClase = row("Subclase")
            gastoVo.Observaciones = row("Observaciones")
            gastoVo.Proveedor = row("Proveedor")
            gastoVo.Sucursal = If(row("Sucursal") = String.Empty, 0, row("Sucursal"))

            For Each rowd As DataRow In dsGasto.Tables(1).Rows

                lstGastoDetalle = New List(Of gastoDetalleVO)()
                lstGastoDetalle.Add(New gastoDetalleVO() With {
                                          .Concepto = rowd("Concepto"),
                                          .FechaEmision = rowd("Fecha"),
                                          .Referencia = rowd("Referencia"),
                                          .DescripcionExtra = rowd("DescripcionExtra"),
                                          .Cantidad = If(rowd("Cantidad") = String.Empty, 0, rowd("Cantidad")),
                                          .Precio = rowd("Precio"),
                                          .Retencion = rowd("Retencion"),
                                          .Retencion2 = rowd("Retencion2"),
                                          .Retencion3 = rowd("Retencion3"),
                                          .Impuestos = rowd("Impuestos"),
                                          .Impuestos2 = rowd("Impuestos2"),
                                          .Impuesto = rowd("Impuesto1"),
                                          .Impuesto1 = rowd("Impuesto2"),
                                          .CentroCostos = rowd("CentroCostos")})

                For Each gastoD In lstGastoDetalle

                    gastoDVo = New gastoDetalleVO
                    gastoDVo.Concepto = gastoD.Concepto
                    gastoDVo.FechaEmision = gastoD.FechaEmision
                    gastoDVo.Referencia = gastoD.Referencia
                    gastoDVo.DescripcionExtra = gastoD.DescripcionExtra
                    gastoDVo.Cantidad = gastoD.Cantidad
                    gastoDVo.Precio = gastoD.Precio
                    gastoDVo.Retencion = gastoD.Retencion
                    gastoDVo.Retencion2 = gastoD.Retencion2
                    gastoDVo.Retencion3 = gastoD.Retencion3
                    gastoDVo.Impuestos = gastoD.Impuestos
                    gastoDVo.Impuestos2 = gastoD.Impuestos2
                    gastoDVo.Impuesto = gastoD.Impuesto
                    gastoDVo.Impuesto1 = gastoD.Impuesto1
                    gastoDVo.CentroCostos = gastoD.CentroCostos

                    gastoVo.listGastosDetalle.Add(gastoDVo)
                Next
            Next
        Next
        Return gastoVo
    End Function

    Public Function leeVOCompra(ByVal dsCompra) As comprasVO

        Dim comprasVo As comprasVO = New comprasVO
        Dim comprasDVo As comprasDetalleVO = New comprasDetalleVO
        Dim lstcomprasDetalle As New List(Of comprasDetalleVO)()

        For Each row As DataRow In dsCompra.Tables(0).Rows

            comprasVo = New comprasVO
            comprasVo.listCompraDetalle = New List(Of comprasDetalleVO)()

            comprasVo.TipoBeneficia = row("TipoBeneficia")
            comprasVo.Empresa = row("Empresa")
            comprasVo.Moneda = row("Moneda")
            comprasVo.FechaEmision = row("FechaEmision")
            comprasVo.Proyecto = row("Proyecto")
            comprasVo.Referencia = row("Referencia")
            comprasVo.Observaciones = row("Observaciones")
            comprasVo.Proveedor = row("Proveedor")
            comprasVo.Almacen = row("Almacen")
            comprasVo.Concepto = row("Concepto")
            comprasVo.Sucursal = row("Sucursal")
            comprasVo.Condicion = row("Condicion")
            For Each rowd As DataRow In dsCompra.Tables(1).Rows

                lstcomprasDetalle = New List(Of comprasDetalleVO)()
                lstcomprasDetalle.Add(New comprasDetalleVO() With {
                                          .Articulo = rowd("Articulo"),
                                          .Cantidad = rowd("Cantidad"),
                                          .Costo = rowd("Costo"),
                                          .Impuesto1 = rowd("Impuesto1"),
                                          .Impuesto2 = rowd("Impuesto2"),
                                          .Retencion1 = rowd("Retencion1"),
                                          .Retencion2 = rowd("Retencion2"),
                                          .Retencion3 = rowd("Retencion3"),
                                          .DescuentoImporte = rowd("DescuentoImporte"),
                                          .DescripcionExtra = rowd("DescripcionExtra"),
                                          .CentroCostos = rowd("CentroCostos"),
                                          .Unidad = rowd("Unidad")})
                For Each comprasD In lstcomprasDetalle

                    comprasDVo = New comprasDetalleVO
                    comprasDVo.Articulo = comprasD.Articulo
                    comprasDVo.Cantidad = comprasD.Cantidad
                    comprasDVo.Costo = comprasD.Costo
                    comprasDVo.DescripcionExtra = comprasD.Impuesto1
                    comprasDVo.Cantidad = comprasD.Impuesto2
                    comprasDVo.Retencion1 = comprasD.Retencion1
                    comprasDVo.Retencion2 = comprasD.Retencion2
                    comprasDVo.Retencion3 = comprasD.Retencion3
                    comprasDVo.DescuentoImporte = comprasD.DescuentoImporte
                    comprasDVo.DescripcionExtra = comprasD.DescripcionExtra
                    comprasDVo.CentroCostos = comprasD.CentroCostos
                    comprasDVo.Unidad = comprasD.Unidad

                    comprasVo.listCompraDetalle.Add(comprasDVo)
                Next
            Next
        Next
        Return comprasVo
    End Function

    Public Function leeVOInventario(ByVal dsInventario As DataSet) As inventarioVO
        Dim inventarioVo As inventarioVO = New inventarioVO
        Dim inventarioDVo As inventarioDetalleVO = New inventarioDetalleVO
        Dim lstInventarioDetalle As New List(Of inventarioDetalleVO)()

        For Each row As DataRow In dsInventario.Tables(0).Rows

            inventarioVo = New inventarioVO
            inventarioVo.listaInventarioDetalle = New List(Of inventarioDetalleVO)()
            inventarioVo.TipoBeneficia = row("TipoBeneficia")
            inventarioVo.Empresa = row("Empresa")
            inventarioVo.Moneda = row("Moneda")
            inventarioVo.FechaEmision = row("FechaEmision")
            inventarioVo.Proyecto = row("Proyecto")
            inventarioVo.Referencia = row("Referencia")
            inventarioVo.Observaciones = row("Observaciones")
            inventarioVo.Almacen = row("Almacen")
            inventarioVo.Concepto = row("Concepto")
            inventarioVo.Sucursal = If(row("Sucursal") = String.Empty, 0, row("Sucursal"))
    

            For Each rowd As DataRow In dsInventario.Tables(1).Rows

                lstInventarioDetalle = New List(Of inventarioDetalleVO)()
                lstInventarioDetalle.Add(New inventarioDetalleVO() With {
                                         .Articulo = rowd("Articulo"),
                                         .Cantidad = If(rowd("Cantidad") = String.Empty, 0, rowd("Cantidad")),
                                         .CentroCostos = rowd("CentroCostos"),
                                         .Unidad = rowd("Unidad")})

                For Each inventarioD In lstInventarioDetalle

                    inventarioDVo = New inventarioDetalleVO
                    inventarioDVo.Articulo = inventarioD.Articulo
                    inventarioDVo.Cantidad = inventarioD.Cantidad
                    inventarioDVo.CentroCostos = inventarioD.CentroCostos
                    inventarioDVo.Unidad = inventarioD.Unidad

                    inventarioVo.listaInventarioDetalle.Add(inventarioDVo)

                Next
            Next
        Next
        Return inventarioVo
    End Function
    'Public Function errorVO() As objError
    '    Dim objError = New objError()
    '    numError = numError + 1
    '    objError.StrMensaje = errora
    '    objError.Proveedor = gastosVo.Proveedor
    '    objError.NumeroError = numError
    'End Function
End Class
