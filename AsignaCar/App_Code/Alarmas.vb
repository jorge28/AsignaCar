Imports Acceso_a_Datos
Imports System.Data
Imports System.Data.SqlClient
Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols

<WebService(Namespace:="http://www.gintegra.com.mx/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class Alarmas
    Inherits System.Web.Services.WebService

    <WebMethod()> _
    Public Sub EnviarAlarmas()
        Dim utilAlarmas As New EnviadorAlarmas

        Try

            ' Se envian todas las alarmas que haya pendientes

            utilAlarmas.EnviarAlarma(EnumTiposAlarmas.Doc_Tenencias, Application)
            utilAlarmas.EnviarAlarma(EnumTiposAlarmas.Doc_Tarjetas_Circulacion, Application)
            utilAlarmas.EnviarAlarma(EnumTiposAlarmas.Doc_Verificacion, Application)
            utilAlarmas.EnviarAlarma(EnumTiposAlarmas.Doc_Sistema_Localizacion, Application)
            utilAlarmas.EnviarAlarma(EnumTiposAlarmas.Doc_Arrendamiento, Application)

            utilAlarmas.EnviarAlarma(EnumTiposAlarmas.Vencimiento_Poliza, Application)
            utilAlarmas.EnviarAlarma(EnumTiposAlarmas.Pago_de_Poliza, Application)

            utilAlarmas.EnviarAlarma(EnumTiposAlarmas.Vehiculo_N_Años_Uso, Application)

        Catch ex As Exception
            ''Se regresan y registran los datos del error
            Logs.LogError("Serv Web Alarmas.vb", "EnviarAlarmas", ex.Message, ex.StackTrace)
        End Try

    End Sub

End Class