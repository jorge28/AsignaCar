﻿Public Class inventarioDetalleVO

    Private strArticulo As String
    Private intCantidad As Integer
    Private strCentroCostos As String
    Private strUnidad As String
    Private dblCosto As Double


    Public Property Articulo() As String
        Get
            Return strArticulo
        End Get
        Set(ByVal value As String)
            strArticulo = value
        End Set
    End Property

    Public Property Cantidad() As Integer
        Get
            Return intCantidad
        End Get
        Set(ByVal value As Integer)
            intCantidad = value
        End Set
    End Property

    Public Property Costo() As Double
        Get
            Return dblCosto
        End Get
        Set(value As Double)
            dblCosto = value
        End Set
    End Property


    Public Property CentroCostos() As String
        Get
            Return strCentroCostos
        End Get
        Set(ByVal value As String)
            strCentroCostos = value
        End Set
    End Property

    Public Property Unidad() As String
        Get
            Return strUnidad
        End Get
        Set(ByVal value As String)
            strUnidad = value
        End Set
    End Property

End Class