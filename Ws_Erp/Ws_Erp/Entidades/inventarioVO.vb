Public Class inventarioVO

    Private strTipoBeneficia As String
    Private strEmpresa As String
    Private strMoneda As String
    Private dtmFecha As Date
    Private strProyecto As String
    Private strReferencia As String
    Private strObservaciones As String
    Private strAlmacen As String
    Private strConcepto As String
    Private intSucursal As Integer
    Private lstInventarioDetalle As List(Of inventarioDetalleVO)

    Public Property TipoBeneficia() As String
        Get
            Return strTipoBeneficia
        End Get
        Set(ByVal value As String)
            strTipoBeneficia = value
        End Set
    End Property

    Public Property Empresa() As String
        Get
            Return strEmpresa
        End Get
        Set(ByVal value As String)
            strEmpresa = value
        End Set
    End Property

    Public Property Moneda() As String
        Get
            Return strMoneda
        End Get
        Set(ByVal value As String)
            strMoneda = value
        End Set
    End Property

    Public Property FechaEmision() As Date
        Get
            Return dtmFecha
        End Get
        Set(ByVal value As Date)
            dtmFecha = value
        End Set
    End Property

    Public Property Proyecto() As String
        Get
            Return strProyecto
        End Get
        Set(ByVal value As String)
            strProyecto = value
        End Set
    End Property

    Public Property Referencia() As String
        Get
            Return strReferencia
        End Get
        Set(ByVal value As String)
            strReferencia = value
        End Set
    End Property

    Public Property Observaciones() As String
        Get
            Return strObservaciones
        End Get
        Set(ByVal value As String)
            strObservaciones = value
        End Set
    End Property

    Public Property Almacen() As String
        Get
            Return strAlmacen
        End Get
        Set(ByVal value As String)
            strAlmacen = value
        End Set
    End Property

    Public Property Concepto() As String
        Get
            Return strConcepto
        End Get
        Set(ByVal value As String)
            strConcepto = value
        End Set
    End Property

    Public Property Sucursal() As Integer
        Get
            Return intSucursal
        End Get
        Set(ByVal value As Integer)
            intSucursal = value
        End Set
    End Property

    Public Property listaInventarioDetalle() As List(Of inventarioDetalleVO)
        Get
            Return lstInventarioDetalle
        End Get
        Set(ByVal value As List(Of inventarioDetalleVO))
            lstInventarioDetalle = value
        End Set
    End Property


End Class
