Imports System.Data.SqlClient

Public Class Validaciones

    Public conn As SqlConnection = Nothing
    Dim xml As fileXML = New fileXML()
    Dim inLogger As ILogger = New ILogger()
    Dim valdao As ValidaDao = New ValidaDao()


    Public Function validaVenta(strEmpresa, strMoneda, strProeyecto, strCliente, strAlamacen, strConcepto, intSucursal, strArticulo, strCentroCosto, strUnidad) As String

        Dim strMensaje2 As String
        Dim strMensaje As String = ""
        Dim intLongitud As Integer

        strMensaje2 = valdao.validaVentaSP(strEmpresa, strMoneda, strProeyecto, strCliente, strAlamacen, strConcepto, intSucursal, strArticulo, strCentroCosto, strUnidad)

        intLongitud = Len(strEmpresa)

        If intLongitud > 5 Then
            strMensaje += xml.Leer_XML(4)
            strMensaje += vbCr
        End If

        intLongitud = Len(strMoneda)

        If intLongitud > 10 Then
            strMensaje += xml.Leer_XML(5)
            strMensaje += vbCr
        End If

        intLongitud = Len(strCliente)

        If intLongitud > 10 Then
            strMensaje += xml.Leer_XML(7)
            strMensaje += vbCr
        End If

        intLongitud = Len(strAlamacen)

        If intLongitud > 10 Then
            strMensaje += xml.Leer_XML(8)
            strMensaje += vbCr
        End If

        intLongitud = Len(strConcepto)

        If intLongitud > 50 Then
            strMensaje += xml.Leer_XML(9)
            strMensaje += vbCr
        End If

        intLongitud = Len(strArticulo)

        If intLongitud > 20 Then
            strMensaje += xml.Leer_XML(10)
            strMensaje += vbCr
        End If

        intLongitud = Len(strCentroCosto)

        If intLongitud > 20 Then
            strMensaje += xml.Leer_XML(11)
            strMensaje += vbCr
        End If

        intLongitud = Len(strUnidad)

        If intLongitud > 20 Then
            strMensaje += xml.Leer_XML(12)
            strMensaje += vbCr
        End If

        Dim mensaje As String = ""
        If strMensaje2 <> String.Empty Then

            Dim words As String() = strMensaje2.Split(New Char() {"|"})

            Dim word As String
            For Each word In words
                mensaje += word + vbCr
            Next
        End If
        mensaje += strMensaje

        Return mensaje
    End Function

    Public Function validaGastoVO(ByVal gastoVo As gastoVO) As String
        Dim strMensaje2 As String = String.Empty
        Dim strMensaje As String = String.Empty
        Dim intLongitud As Integer

        strMensaje2 += valdao.validaGasto(gastoVo)

        If gastoVo.TipoBeneficia = String.Empty Then
            strMensaje += xml.Leer_XML(19)
            strMensaje += vbCr
        End If

        If gastoVo.Empresa = String.Empty Then
            strMensaje += xml.Leer_XML(20)
            strMensaje += vbCr
        End If

        If gastoVo.Moneda = String.Empty Then
            strMensaje += xml.Leer_XML(21)
            strMensaje += vbCr
        End If

        If gastoVo.Proyecto = String.Empty Then
            strMensaje += xml.Leer_XML(22)
            strMensaje += vbCr
        End If

        If gastoVo.Clase = String.Empty Then
            strMensaje += xml.Leer_XML(23)
            strMensaje += vbCr
        End If

        If gastoVo.SubClase = String.Empty Then
            strMensaje += xml.Leer_XML(24)
            strMensaje += vbCr
        End If

        If gastoVo.Observaciones = String.Empty Then
            strMensaje += xml.Leer_XML(25)
            strMensaje += vbCr
        End If

        If gastoVo.Proveedor = String.Empty Then
            strMensaje += xml.Leer_XML(26)
            strMensaje += vbCr
        End If

        For Each gastod In gastoVo.listGastosDetalle

            strMensaje2 += valdao.validaGastoD(gastod.Concepto, gastod.CentroCostos)

            If gastod.Concepto = String.Empty Then
                strMensaje += xml.Leer_XML(15)
                strMensaje += vbCr
            End If

            If gastod.DescripcionExtra = String.Empty Then
                strMensaje += xml.Leer_XML(14)
                strMensaje += vbCr
            End If

            If gastod.Referencia = String.Empty Then
                strMensaje += xml.Leer_XML(16)
                strMensaje += vbCr
            End If

            If gastod.CentroCostos = String.Empty Then
                strMensaje += xml.Leer_XML(18)
                strMensaje += vbCr
            End If

            intLongitud = Len(gastod.Concepto)

            If intLongitud > 50 Then
                strMensaje += xml.Leer_XML(9)
                strMensaje += vbCr
            End If

            intLongitud = Len(gastod.CentroCostos)

            If intLongitud > 50 Then
                strMensaje += xml.Leer_XML(11)
                strMensaje += vbCr
            End If

            intLongitud = Len(gastod.DescripcionExtra)

            If intLongitud > 100 Then
                strMensaje += xml.Leer_XML(13)
                strMensaje += vbCr
            End If

        Next

        Dim mensaje As String = ""
        If strMensaje2 <> String.Empty Then

            Dim words As String() = strMensaje2.Split(New Char() {"|"})

            Dim word As String
            For Each word In words
                If word.ToString() <> String.Empty Then
                    mensaje += word + "Del Servicio " + gastoVo.Observaciones + vbCr
                End If
            Next
        End If
        mensaje += strMensaje


        Return mensaje

    End Function

    Public Function validaInventarioVO(ByVal inventarioVO As inventarioVO) As String
        Dim strMensaje2 As String = String.Empty
        Dim strMensaje As String = String.Empty

        strMensaje2 += valdao.validaInventario(inventarioVO)

        If inventarioVO.TipoBeneficia = String.Empty Then
            strMensaje += xml.Leer_XML(19)
            strMensaje += vbCr
        End If

        If inventarioVO.Empresa = String.Empty Then
            strMensaje += xml.Leer_XML(20)
            strMensaje += vbCr
        End If

        If inventarioVO.Moneda = String.Empty Then
            strMensaje += xml.Leer_XML(21)
            strMensaje += vbCr
        End If

        If inventarioVO.Proyecto = String.Empty Then
            strMensaje += xml.Leer_XML(22)
            strMensaje += vbCr
        End If

        If inventarioVO.Almacen = String.Empty Then
            strMensaje += xml.Leer_XML(27)
            strMensaje += vbCr
        End If

        If inventarioVO.Concepto = String.Empty Then
            strMensaje += xml.Leer_XML(28)
            strMensaje += vbCr
        End If

        For Each inventariod In inventarioVO.listaInventarioDetalle

            strMensaje2 += valdao.validaInventarioD(inventariod)

            If inventariod.Articulo = String.Empty Then
                strMensaje += xml.Leer_XML(29)
                strMensaje += vbCr
            End If

            If inventariod.CentroCostos = String.Empty Then
                strMensaje += xml.Leer_XML(18)
                strMensaje += vbCr
            End If

            If inventariod.Unidad = String.Empty Then
                strMensaje += xml.Leer_XML(30)
                strMensaje += vbCr
            End If

        Next

        Dim mensaje As String = ""
        If strMensaje2 <> String.Empty Then

            Dim words As String() = strMensaje2.Split(New Char() {"|"})

            'Dim word As String
            'For Each word In words
            '    If word.ToString() <> String.Empty Then
            '        mensaje += word + "Del Servicio " + gastoVO.Observaciones + vbCr
            '    End If
            'Next
        End If
        mensaje += strMensaje


        Return mensaje

    End Function
End Class
