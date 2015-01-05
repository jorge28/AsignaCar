Public Class gastoDetalleVO

    Private strConcepto As String
    Private dtmFechaEmision As Date
    Private strReferencia As String
    Private strDescripcionExtra As String
    Private intCantidad As Integer
    Private dblImporte As Double
    Private dblRetencion As Double
    Private dblRetencion2 As Double
    Private dblRetencion3 As Double
    Private dblImpuestos As Double
    Private dblImpuestos2 As Double
    Private dblImpuesto As Double
    Private dblImpuesto1 As Double
    Private strCentroCostos As String


    Public Property Concepto As String
        Get
            Return Me.strConcepto
        End Get
        Set(value As String)
            Me.strConcepto = value
        End Set
    End Property

    Public Property FechaEmision As Date
        Get
            Return Me.dtmFechaEmision
        End Get
        Set(value As Date)
            Me.dtmFechaEmision = value
        End Set
    End Property

    Public Property Referencia As String
        Get
            Return Me.strReferencia
        End Get
        Set(value As String)
            Me.strReferencia = value
        End Set
    End Property

    Public Property DescripcionExtra As String
        Get
            Return Me.strDescripcionExtra
        End Get
        Set(value As String)
            Me.strDescripcionExtra = value
        End Set
    End Property

    Public Property Cantidad As Integer
        Get
            Return Me.intCantidad
        End Get
        Set(value As Integer)
            Me.intCantidad = value
        End Set
    End Property

    Public Property Precio As Double
        Get
            Return Me.dblImporte
        End Get
        Set(value As Double)
            Me.dblImporte = value
        End Set
    End Property

    Public Property Retencion As Double
        Get
            Return Me.dblRetencion
        End Get
        Set(value As Double)
            Me.dblRetencion = value
        End Set
    End Property

    Public Property Retencion2 As Double
        Get
            Return Me.dblRetencion2
        End Get
        Set(value As Double)
            Me.dblRetencion2 = value
        End Set
    End Property

    Public Property Retencion3 As Double
        Get
            Return Me.dblRetencion3
        End Get
        Set(value As Double)
            Me.dblRetencion3 = value
        End Set
    End Property

    Public Property Impuestos As Double
        Get
            Return Me.dblImpuestos
        End Get
        Set(value As Double)
            Me.dblImpuestos = value
        End Set
    End Property

    Public Property Impuestos2 As Double
        Get
            Return Me.dblImpuestos2
        End Get
        Set(value As Double)
            Me.dblImpuestos2 = value
        End Set
    End Property

    Public Property Impuesto As Double
        Get
            Return Me.dblImpuesto
        End Get
        Set(value As Double)
            Me.dblImpuesto = value
        End Set
    End Property

    Public Property Impuesto1 As Double
        Get
            Return Me.dblImpuesto1
        End Get
        Set(value As Double)
            Me.dblImpuesto1 = value
        End Set
    End Property


    Public Property CentroCostos As String
        Get
            Return Me.strCentroCostos
        End Get
        Set(value As String)
            Me.strCentroCostos = value
        End Set
    End Property

End Class
