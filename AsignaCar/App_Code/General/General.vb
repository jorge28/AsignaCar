Public Module General
    ''' <summary>
    ''' Resultado2 de una solicitud
    ''' </summary>
    ''' <remarks></remarks>
    Public Class Resultado
        Public Estatus As Estatus
        Public ErrorDesc As String
        Public DataTable As Data.DataTable
        Public Dato As String

        Sub New()
            ErrorDesc = ""
            Estatus = General.Estatus.Exito
            Dato = ""
            DataTable = New Data.DataTable
        End Sub
    End Class

    ''' <summary>
    ''' Exito o Error
    ''' </summary>
    ''' <remarks>Resultado2 de una operación</remarks>
    Public Enum Estatus
        Exito
        [Error]
    End Enum


    ''' <summary>
    ''' Color de los campos requeridos
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ColorCampoRequerido() As System.Drawing.Color
        Return Drawing.Color.FromArgb(192, 254, 251)
    End Function

    ''' <summary>
    ''' Obtiene el nombre del mes
    ''' </summary>
    ''' <param name="mes">Número de mes</param>
    ''' <param name="NombreCorto">Nombre Corto o Largo</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getNombreMes(ByVal Mes As Byte, Optional ByVal NombreCorto As Boolean = False) As String
        ' Obtiene el nombre del mes
        If NombreCorto Then
            Select Case Mes
                Case 1 : Return "Ene"
                Case 2 : Return "Feb"
                Case 3 : Return "Mar"
                Case 4 : Return "Abr"
                Case 5 : Return "May"
                Case 6 : Return "Jun"
                Case 7 : Return "Jul"
                Case 8 : Return "Ago"
                Case 9 : Return "Sep"
                Case 10 : Return "Oct"
                Case 11 : Return "Nov"
                Case 12 : Return "Dic"
            End Select
        Else
            Select Case Mes
                Case 1 : Return "Enero"
                Case 2 : Return "Febrero"
                Case 3 : Return "Marzo"
                Case 4 : Return "Abril"
                Case 5 : Return "Mayo"
                Case 6 : Return "Junio"
                Case 7 : Return "Julio"
                Case 8 : Return "Agosto"
                Case 9 : Return "Septiembre"
                Case 10 : Return "Octubre"
                Case 11 : Return "Noviembre"
                Case 12 : Return "Diciembre"
            End Select
        End If

        Return ""
    End Function

    ''' <summary>
    ''' Prepara una cadena que talvez tenga apóstrofes ' para usarla en alerts de javascript
    ''' </summary>
    ''' <param name="texto"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Comillas_JS(texto As String) As String
        Return Replace(texto, "'", "\'")
    End Function

    ''' <summary>
    ''' Convierte una fecha de cadena a objeto fecha
    ''' </summary>
    ''' <param name="fecha">Cadena con una fecha en formato dd/mm/yyyy</param>
    ''' <returns>Un objeto fecha</returns>
    ''' <remarks></remarks>
    Public Function ConvertirADate(fecha As String) As Date
        Dim datos() As String = fecha.Split("/")
        Return New Date(datos(2), datos(1), datos(0))
    End Function


    ''' <summary>
    ''' Agrega un elemento vacio a un control combobox
    ''' </summary>
    ''' <param name="ddl"></param>
    ''' <remarks></remarks>
    Public Sub AgregarValorInicialDDL(ByRef ddl As Telerik.Web.UI.RadComboBox)
        ddl.Items.Add(New Telerik.Web.UI.RadComboBoxItem("----------", "-1"))
        ddl.SelectedValue = "-1"
    End Sub

    ''' <summary>
    ''' Convierte un número en su descripción
    ''' </summary>
    ''' <param name="tyCantidad"></param>
    ''' <returns></returns>
    ''' <remarks>Ejemplo: 2,800.45 ==> Dos mil ocho cientos con 45c </remarks>
    Public Function NumLetras(ByVal tyCantidad As Double) As String
        Dim lyCantidad As Double, lyCentavos As Double, lnDigito As Byte, lnPrimerDigito As Byte, lnSegundoDigito As Byte, lnTercerDigito As Byte, lcBloque As String, lnNumeroBloques As Byte, lnBloqueCero
        Dim I As Object 'Si esta como Option Explicit
        NumLetras = ""
        tyCantidad = Math.Round(tyCantidad, 2)
        lyCantidad = Int(tyCantidad)
        lyCentavos = (tyCantidad - lyCantidad) * 100
        Dim laUnidades() As Object = {"UN", "DOS", "TRES", "CUATRO", "CINCO", "SEIS", "SIETE", "OCHO", "NUEVE", "DIEZ", "ONCE", "DOCE", "TRECE", "CATORCE", "QUINCE", "DIECISEIS", "DIECISIETE", "DIECIOCHO", "DIECINUEVE", "VEINTE", "VEINTIUN", "VEINTIDOS", "VEINTITRES", "VEINTICUATRO", "VEINTICINCO", "VEINTISEIS", "VEINTISIETE", "VEINTIOCHO", "VEINTINUEVE"}
        Dim laDecenas() As Object = {"DIEZ", "VEINTE", "TREINTA", "CUARENTA", "CINCUENTA", "SESENTA", "SETENTA", "OCHENTA", "NOVENTA"}
        Dim laCentenas() As Object = {"CIENTO", "DOSCIENTOS", "TRESCIENTOS", "CUATROCIENTOS", "QUINIENTOS", "SEISCIENTOS", "SETECIENTOS", "OCHOCIENTOS", "NOVECIENTOS"}
        lnNumeroBloques = 1
        Do
            lnPrimerDigito = 0
            lnSegundoDigito = 0
            lnTercerDigito = 0
            lcBloque = ""
            lnBloqueCero = 0
            For I = 1 To 3
                lnDigito = lyCantidad Mod 10
                If lnDigito <> 0 Then
                    Select Case I
                        Case 1
                            lcBloque = " " & laUnidades(lnDigito - 1)
                            lnPrimerDigito = lnDigito
                        Case 2
                            If lnDigito <= 2 Then
                                lcBloque = " " & laUnidades((lnDigito * 10) + lnPrimerDigito - 1)
                            Else
                                lcBloque = " " & laDecenas(lnDigito - 1) & IIf(lnPrimerDigito <> 0, " Y", "") & lcBloque
                            End If
                            lnSegundoDigito = lnDigito
                        Case 3
                            lcBloque = " " & IIf(lnDigito = 1 And lnPrimerDigito = 0 And lnSegundoDigito = 0, "CIEN", laCentenas(lnDigito - 1)) & lcBloque
                            lnTercerDigito = lnDigito
                    End Select
                Else
                    lnBloqueCero = lnBloqueCero + 1
                End If
                lyCantidad = Int(lyCantidad / 10)
                If lyCantidad = 0 Then
                    Exit For
                End If
            Next I
            Select Case lnNumeroBloques
                Case 1
                    NumLetras = lcBloque
                Case 2
                    NumLetras = lcBloque & IIf(lnBloqueCero = 3, "", " MIL") & NumLetras
                Case 3
                    NumLetras = lcBloque & IIf(lnPrimerDigito = 1 And lnSegundoDigito = 0 And lnTercerDigito = 0, " MILLON", " MILLONES") & NumLetras
            End Select
            lnNumeroBloques = lnNumeroBloques + 1
        Loop Until lyCantidad = 0

        If NumLetras = "" Then
            NumLetras = "CERO PESOS " & Completar2(CInt(Math.Round(lyCentavos))) & "/100 M.N."
        Else
            NumLetras &= IIf(tyCantidad > 1, " PESOS ", " PESO ") & Completar2(CInt(Math.Round(lyCentavos))) & "/100 M.N."
        End If

        NumLetras = Trim(NumLetras)
    End Function

    Public Function Completar2(ByVal numero As Integer) As String
        Return IIf(numero < 10, "0" & numero, numero)
    End Function

    'Isra
    Public Function CalcularCombustibleConsumido(IdNivelGasSalida As Integer, IdNivelGasEntrada As Integer) As String
        Dim gas As Integer
        Dim gas2 As Integer
        ' calcula la gasolina consumida
        If IdNivelGasEntrada = -1 Then
            Return "--"
        End If
        If IdNivelGasSalida = IdNivelGasEntrada Then
            Return "0"
        End If
        If IdNivelGasSalida < IdNivelGasEntrada Then
            gas2 = IdNivelGasEntrada - IdNivelGasSalida

            
            Return "+" & gas2 & "/8"
        End If

        If IdNivelGasSalida > IdNivelGasEntrada Then
            gas = IdNivelGasSalida - IdNivelGasEntrada

            If gas <= 0 Then
                Return "0"
            End If

            Return "-" & gas & "/8"
        End If

        Return "0"
    End Function
    'Termina Isra

    Public Function CalcularTotalFactura(Presupuesto As Double, IVA As String) As String


        Dim total As Double

        If IVA = "----------" Then
            Return "0.00"
        End If


        total = Presupuesto * (CInt(IVA) / 100)
        total += Presupuesto

        Return total
    End Function
End Module






