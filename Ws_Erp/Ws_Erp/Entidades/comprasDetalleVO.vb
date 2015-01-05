Public Class comprasDetalleVO

    Private strArticulo As String
    Private intCantidad As Integer
    Private dblCosto As Double
    Private dblimpuesto1 As Double
    Private dblimpuesto2 As Double
    Private dblRetencion1 As Double
    Private dblRetencion2 As Double
    Private dblRetencion3 As Double
    Private dblDescuentoImporte As Double
    Private strDescripcionExtra As String
    Private strCentroCostos As String
    Private strUnidad As String

    Public Property Unidad As String
        Get
            Return strUnidad
        End Get
        Set(value As String)
            strUnidad = value
        End Set
    End Property

    Public Property CentroCostos As String
        Get
            Return strCentroCostos
        End Get
        Set(value As String)
            strCentroCostos = value
        End Set
    End Property

    Public Property DescripcionExtra As String
        Get
            Return strDescripcionExtra
        End Get
        Set(value As String)
            strDescripcionExtra = value
        End Set
    End Property

    Public Property DescuentoImporte As Double
        Get
            Return dblDescuentoImporte
        End Get
        Set(value As Double)
            dblDescuentoImporte = value
        End Set
    End Property

    Public Property Retencion3 As Double
        Get
            Return dblRetencion3
        End Get
        Set(value As Double)
            dblRetencion3 = value
        End Set
    End Property

    Public Property Retencion2 As Double
        Get
            Return dblRetencion2
        End Get
        Set(value As Double)
            dblRetencion2 = value
        End Set
    End Property

    Public Property Retencion1 As Double
        Get
            Return dblRetencion1
        End Get
        Set(value As Double)
            dblRetencion1 = value
        End Set
    End Property

    Public Property Impuesto2 As Double
        Get
            Return dblimpuesto2
        End Get
        Set(value As Double)
            dblimpuesto2 = value
        End Set
    End Property

    Public Property Impuesto1 As Double
        Get
            Return dblimpuesto1
        End Get
        Set(value As Double)
            dblimpuesto1 = value
        End Set
    End Property

    Public Property Articulo As String
        Get
            Return strArticulo
        End Get
        Set(value As String)
            strArticulo = value
        End Set
    End Property

    Public Property Cantidad As Integer
        Get
            Return intCantidad
        End Get
        Set(value As Integer)
            intCantidad = value
        End Set
    End Property

    Public Property Costo As Double
        Get
            Return dblCosto
        End Get
        Set(value As Double)
            dblCosto = value
        End Set
    End Property

End Class
