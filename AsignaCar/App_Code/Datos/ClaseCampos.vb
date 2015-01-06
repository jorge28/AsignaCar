Class ClaseCampo
    Private mValor As String
    Private mNombre As String
    Private mTipo As String
    Public Sub New()
        mValor = ""
        mNombre = ""
        mTipo = ""
    End Sub
    Public Property Valor() As String
        Get
            Return mValor
        End Get
        Set(ByVal value As String)
            mValor = value
        End Set
    End Property
    Public Property Nombre() As String
        Get
            Return mValor
        End Get
        Set(ByVal value As String)
            mValor = value
        End Set
    End Property
    Public Property Tipo() As String
        Get
            Return mValor
        End Get
        Set(ByVal value As String)
            mValor = value
        End Set
    End Property
End Class ' esta clase fue reemplazada con la estructura campo
Public Enum TipoDato As Integer
    Numero = 0
    Cadena = 1
End Enum 'Para determinar si un tipo de dato es numero o cadena
Public Enum PrimaryKey As Integer
    si = 0
    no = 1
End Enum 'Para saber si un campo es codigo o no
Public Structure Campo
    Public Valor As String
    Public Nombre As String
    Public Tipo As TipoDato
    Public Key As PrimaryKey
End Structure 'la estructura de un campo

Public Class ClaseCampos
    Private mCampos() As Campo
    Private mMaximo As Integer
    Public Sub New(ByVal CamtidadCampos As Integer)
        ReDim Preserve mCampos(CamtidadCampos) 'redimencionamos el array
        mMaximo = CamtidadCampos
        Dim i As Integer
        For i = 0 To mMaximo - 1
            mCampos(i) = New Campo()
        Next
    End Sub

    Public Function SacarValor(ByVal Campo As Integer)
        Return mCampos(Campo).Valor
    End Function
    Public Function SacarNombre(ByVal Campo As Integer)
        Return mCampos(Campo).Nombre
    End Function
    Public Function SacarTipo(ByVal Campo As Integer)
        Return mCampos(Campo).Tipo
    End Function
    Public Function SacarKey(ByVal Campo As Integer)
        Return mCampos(Campo).Key
    End Function

    Public Sub PonerValor(ByVal Campo As Integer, ByVal Valor As String)
        mCampos(Campo).Valor = Valor
    End Sub
    Public Sub PonerNombre(ByVal Campo As Integer, ByVal Valor As String)
        mCampos(Campo).Nombre = Valor
    End Sub
    Public Sub PonerTipo(ByVal Campo As Integer, ByVal Valor As TipoDato)
        mCampos(Campo).Tipo = Valor
    End Sub
    Public Sub PonerKey(ByVal Campo As Integer, ByVal Valor As PrimaryKey)
        mCampos(Campo).Key = Valor
    End Sub

    Public Function Tamaño()
        Return mMaximo
    End Function
End Class 'campos con la estructura campo



