
Partial Class Controles_RangoFechas
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

    End Sub

    Public ReadOnly Property getFecha1() As Date
        Get
            If Fecha1.IsEmpty Or Fecha2.IsEmpty Then
                Return #1/1/1900#
            End If
            Return Fecha1.SelectedDate
        End Get
    End Property

    Public ReadOnly Property getFecha2() As Date
        Get
            If Fecha1.IsEmpty Or Fecha2.IsEmpty Then
                Return #1/1/1900#
            End If
            Return Fecha2.SelectedDate
        End Get
    End Property

    Public ReadOnly Property RangoValido() As Boolean
        Get
            If Fecha1.IsEmpty Or Fecha2.IsEmpty Then
                Return False
            End If
            If Fecha1.SelectedDate > Fecha2.SelectedDate Then
                Return False
            End If
            Return True
        End Get
    End Property

    Public ReadOnly Property SinValor() As Boolean
        Get
            Return Fecha1.IsEmpty And Fecha2.IsEmpty
        End Get
    End Property

End Class
