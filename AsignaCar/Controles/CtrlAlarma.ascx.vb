Imports System.Data
Imports Telerik.Web.UI


Partial Class Controles_CtrlAlarma
    Inherits System.Web.UI.UserControl

    Private Const _CHK As Byte = 2
    Private Const _Id As Byte = 3
    Private Const _Nombre As Byte = 4


    Public ReadOnly Property PerfilesSeleccionados As Integer()
        Get
            Dim perfiles(-1) As Integer
            Dim chk As CheckBox
            Dim i As Integer = -1

            For Each r As GridDataItem In gridAlarma.Items
                chk = r.FindControl("chk")
                If chk.Checked Then
                    i += 1
                    ReDim Preserve perfiles(i)
                    perfiles(i) = r.Cells(_Id).Text
                End If
            Next

            Return perfiles
        End Get
    End Property

    Public Sub CargarGrid(ByRef dt As DataTable)
        gridAlarma.DataSource = dt
        gridAlarma.DataBind()
    End Sub

    Public Sub LimpiarCampos()
        txtPeriodoAlerta.Text = ""

        Dim chk As CheckBox

        For Each r As GridDataItem In gridAlarma.Items
            chk = r.FindControl("chk")
            chk.Checked = False
        Next

        chkEmail.Checked = False
        chkSMS.Checked = False

    End Sub

    Public ReadOnly Property SMS As Boolean
        Get
            Return chkSMS.Checked
        End Get
    End Property

    Public ReadOnly Property Email As Boolean
        Get
            Return chkEmail.Checked
        End Get
    End Property

    Public ReadOnly Property PeriodoAlerta As Short
        Get
            Return txtPeriodoAlerta.Text
        End Get
    End Property

    Public WriteOnly Property ValidationGroup As String
        Set(value As String)
            validador1.ValidationGroup = value
            validador2.ValidationGroup = value
        End Set
    End Property

    Public WriteOnly Property Requerido As Boolean
        Set(value As Boolean)
            If value Then
                txtPeriodoAlerta.BackColor = ColorCampoRequerido()
            End If
        End Set
    End Property
End Class
