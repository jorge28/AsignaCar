Imports Microsoft.VisualBasic
Imports Acceso_a_Datos
Imports System.Data
Imports System.Data.SqlClient

Public Class Datos_CheckIn

#Region "Servicios"

    Public Function Consultar_Existe_Vehiculos(usr As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos
        Try
            datos.Consulta_SP("Select_Existe_Vehiculos ", res.DataTable)
        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("CheckIn.vb", "Select_Existe_Vehiculos", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
        Return res


    End Function

    Public Function Consultar_Servicios(usr As String, servicio As CBusqueda_Servicio) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos


        Try
            'Se crean parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@NumServicio", servicio.NumServicio))
            datos.sqlParameters.Add(New SqlParameter("@NumSiniestro", servicio.NumSiniestro))
            datos.sqlParameters.Add(New SqlParameter("@NumPoliza", servicio.NumPoliza))
            datos.sqlParameters.Add(New SqlParameter("@Aseguradora", servicio.NombreAseguradora))
            datos.sqlParameters.Add(New SqlParameter("@NombreAsegurado", servicio.AsegNombre))
            datos.sqlParameters.Add(New SqlParameter("@TipoConsulta", servicio.TipoConsulta))
            datos.sqlParameters.Add(New SqlParameter("@Estatus", servicio.EstatusServicio))

            datos.Consulta_SP("Select_Servicios @TipoConsulta, @NumServicio, @NumSiniestro, @NumPoliza, @Aseguradora, @NombreAsegurado, @Estatus", res.DataTable)


        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("CheckIn.vb", "Select_Servicios", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
        Return res
    End Function

    Public Function Insertar_Servicios(ByVal usr As Integer, ByVal servicio As CServicio, ByVal IdUsuario As String, ByVal bitacora As String) As Resultado
        Dim res As New Resultado 'Objeto para resultados
        Dim datos As New ObjDatos 'Objetod para mandar llamar el ws


        Try

            ' Valida que sea un dato correcto
            If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(servicio.AsegNombre) Then
                Throw New Validacion_Exception("Nombre del Asegurado")
            End If

            If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(servicio.AsegMaterno) Then
                Throw New Validacion_Exception("Apellido Materno del Asegurado")
            End If

            If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(servicio.AsegPaterno) Then
                Throw New Validacion_Exception("Apellido Paterno del Asegurado")
            End If

            'If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(servicio.AsegTelefono) Then
            '    Throw New Validacion_Exception("Teléfono del Asegurado")
            'End If

            'If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(servicio.NumPoliza) Then
            '    Throw New Validacion_Exception("Número de Póliza")
            'End If

            'If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(servicio.Inciso) Then
            '    Throw New Validacion_Exception("Inciso")
            'End If

            If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(servicio.RepNombre) Then
                Throw New Validacion_Exception("Nombre de Quien Reporta")
            End If

            If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(servicio.RepMaterno) Then
                Throw New Validacion_Exception("Apellido Materno de Quien Reporta")
            End If

            If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(servicio.RepPaterno) Then
                Throw New Validacion_Exception("Apellido Paterno de Quien Reporta")
            End If

            'If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(servicio.RepTelefono) Then
            '    Throw New Validacion_Exception("Teléfono de Quien Reporta")
            'End If

            'Se crea parámetro y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@ConCosto", servicio.ConCosto))
            datos.sqlParameters.Add(New SqlParameter("@AsegMaterno", servicio.AsegMaterno))
            datos.sqlParameters.Add(New SqlParameter("@AsegNombre", servicio.AsegNombre))
            datos.sqlParameters.Add(New SqlParameter("@AsegPaterno", servicio.AsegPaterno))
            datos.sqlParameters.Add(New SqlParameter("@AsegTelefono", servicio.AsegTelefono))
            datos.sqlParameters.Add(New SqlParameter("@Categoria", servicio.Categoria))
            datos.sqlParameters.Add(New SqlParameter("@Cobertura", servicio.Cobertura))
            datos.sqlParameters.Add(New SqlParameter("@Costo", servicio.Costo))
            datos.sqlParameters.Add(New SqlParameter("@DiasRenta", servicio.DiasRenta))
            datos.sqlParameters.Add(New SqlParameter("@IdAseguradora", servicio.IdAseguradora))
            datos.sqlParameters.Add(New SqlParameter("@IdEvento", servicio.IdEvento))
            datos.sqlParameters.Add(New SqlParameter("@IdQuienReporta", servicio.IdQuienReporta))
            datos.sqlParameters.Add(New SqlParameter("@IdUbicacionEntrega", servicio.IdUbicacionEntrega))
            datos.sqlParameters.Add(New SqlParameter("@Inciso", servicio.Inciso))
            datos.sqlParameters.Add(New SqlParameter("@NumPoliza", servicio.NumPoliza))
            datos.sqlParameters.Add(New SqlParameter("@RepEmail", servicio.RepEmail))
            datos.sqlParameters.Add(New SqlParameter("@RepIdEstado", servicio.RepIdEstado))
            datos.sqlParameters.Add(New SqlParameter("@RepIdMunicipio", servicio.RepIdMunicipio))
            datos.sqlParameters.Add(New SqlParameter("@RepMaterno", servicio.RepMaterno))
            datos.sqlParameters.Add(New SqlParameter("@RepNombre", servicio.RepNombre))
            datos.sqlParameters.Add(New SqlParameter("@RepPaterno", servicio.RepPaterno))
            datos.sqlParameters.Add(New SqlParameter("@RepTelefono", servicio.RepTelefono))
            datos.sqlParameters.Add(New SqlParameter("@IdServicio_Ant", servicio.IdServicio_Ant))
            datos.sqlParameters.Add(New SqlParameter("@IdUsuario", IdUsuario))
            datos.sqlParameters.Add(New SqlParameter("@IdServicio", servicio.IdServicio))
            datos.sqlParameters.Add(New SqlParameter("@RepTelefono0", servicio.RepTelefono0))
            datos.sqlParameters.Add(New SqlParameter("@AsegTelefono0", servicio.AsegTelefono0))
            datos.sqlParameters.Add(New SqlParameter("@LadaRepTelefono", servicio.LadaRepTelefono))
            datos.sqlParameters.Add(New SqlParameter("@LadaRepTelefono0", servicio.LadaRepTelefono0))
            datos.sqlParameters.Add(New SqlParameter("@LadaAsegTelefono", servicio.LadaAsegTelefono))
            datos.sqlParameters.Add(New SqlParameter("@LadaAsegTelefono0", servicio.LadaAsegTelefono0))

            datos.Comando_SP("Insert_Servicios @ConCosto, @IdAseguradora, @IdQuienReporta, @NumPoliza, @Inciso, @Categoria, @IdUbicacionEntrega, @IdEvento, @Cobertura, @Costo, @DiasRenta, @RepNombre, @RepPaterno, @RepMaterno, @RepTelefono, @RepEmail, @RepIdEstado, @RepIdMunicipio, @AsegNombre, @AsegPaterno, @AsegMaterno, @AsegTelefono, @IdServicio_Ant, @IdUsuario, @IdServicio, @RepTelefono0, @AsegTelefono0, @LadaRepTelefono, @LadaRepTelefono0, @LadaAsegTelefono, @LadaAsegTelefono0", res.DataTable)

            ' Verifica si todo salió bien:
            res.Dato = res.DataTable.Rows(0)(2) 'Aqui devuelve el Id
            Dim NumServicio As String = res.DataTable.Rows(0)(3)

            ' Graba la bitacora
            If bitacora <> "" Then
                datos.sqlParameters.Add(New SqlParameter("@IdUsuario", IdUsuario))
                datos.sqlParameters.Add(New SqlParameter("@IdServicio", res.Dato))
                datos.sqlParameters.Add(New SqlParameter("@Bitacora", bitacora))
                datos.Comando_SP("Insert_Servicios_Bitacora @IdServicio, @Bitacora, @IdUsuario", res.DataTable)
            End If

            ' Graba la auditoria
            Auditoria.Registrar(usr, 55, res.Dato & "-" & NumServicio)
        Catch ex As Validacion_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            ''Se regresan y registran los datos del error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("CheckIn.vb", "Insert_Servicios", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function

    Public Function Insertar_ServiciosIasistenciII(ByVal usr As Integer, ByVal servicio As CServicio, ByVal IdUsuario As String, ByVal bitacora As String) As Resultado
        Dim res As New Resultado 'Objeto para resultados
        Dim datos As New ObjDatos 'Objetod para mandar llamar el ws

        Try

            ' Valida que sea un dato correcto
            If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(servicio.AsegNombre) Then
                Throw New Validacion_Exception("Nombre del Asegurado")
            End If

            If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(servicio.AsegMaterno) Then
                Throw New Validacion_Exception("Apellido Materno del Asegurado")
            End If

            If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(servicio.AsegPaterno) Then
                Throw New Validacion_Exception("Apellido Paterno del Asegurado")
            End If

            'If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(servicio.AsegTelefono) Then
            '    Throw New Validacion_Exception("Teléfono del Asegurado")
            'End If

            'If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(servicio.NumPoliza) Then
            '    Throw New Validacion_Exception("Número de Póliza")
            'End If

            'If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(servicio.Inciso) Then
            '    Throw New Validacion_Exception("Inciso")
            'End If

            'If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(servicio.RepTelefono) Then
            '    Throw New Validacion_Exception("Teléfono de Quien Reporta")
            'End If

            'Se crea parámetro y se manda llamar el ws

            'exec(sp_ServAutoSustituto)
            '@titular = 'Prueba',       seria = servicio.AsegNombre &" "& servicio.AsegMaterno &" "& servicio.AsegPaterno
            '@ClaPaisUbica = 0,         seria = 0
            '@claEstadoUbica = 33,      seria = servicio.RepIdEstado
            '@ClaMunicipioUbica = 35,   seria = servicio.RepIdMunicipio
            '@usuario = 'prueba',       seria = usr
            '@FechaSiniestro = '2013-12-26 00:00:00.000',  seria = format(now(), "MM-dd-yyyy HH:mm")
            '@ClaContrato = 1,          seria = servicio.IdAseguradora
            '@ClaServicio = ''          seria = servicio.IdEvento

            datos.sqlParameters.Add(New SqlParameter("@titular", servicio.AsegNombre & " " & servicio.AsegMaterno & " " & servicio.AsegPaterno))
            datos.sqlParameters.Add(New SqlParameter("@ClaPaisUbica", 0))
            datos.sqlParameters.Add(New SqlParameter("@claEstadoUbica", servicio.RepIdEstado))
            datos.sqlParameters.Add(New SqlParameter("@ClaMunicipioUbica", servicio.AsisIdMunicipio))
            datos.sqlParameters.Add(New SqlParameter("@usuario", usr))
            datos.sqlParameters.Add(New SqlParameter("@FechaSiniestro", Format(Now(), "MM-dd-yyyy HH:mm")))
            datos.sqlParameters.Add(New SqlParameter("@ClaContrato", servicio.IdAseguradora))
            datos.sqlParameters.Add(New SqlParameter("@ClaServicio", servicio.IdEvento))

            datos.Consultar_Servcio_Asistencia_II("sp_ServAutoSustituto '" & servicio.AsegNombre & " " & servicio.AsegMaterno & " " & servicio.AsegPaterno & _
                                                  "', 0," & servicio.RepIdEstado & ", " & servicio.AsisIdMunicipio & ", '" & usr & "', '" & Format(Now(), "MM-dd-yyyy HH:mm") & "', " & servicio.IdAseguradora & ", " & servicio.IdEvento, res.DataTable)

            ' Verifica si todo salió bien:
            'res.Dato =  'Aqui devuelve el Id
            Dim NumServicio As String = res.DataTable.Rows(0)(0) & "" & res.DataTable.Rows(0)(1)

            ' Graba la bitacora

            ' Graba la auditoria
            Auditoria.Registrar(usr, 55, res.Dato & "-" & NumServicio)
        Catch ex As Validacion_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            ''Se regresan y registran los datos del error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("CheckIn.vb", "Insert_Servicios", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function

    Public Function Actualiza_ProveedorIasistenciII(ByVal anio As Integer, ByVal consec As Integer, ByVal usr As String, ByVal contrato As CContrato) As Resultado
        Dim res As New Resultado 'Objeto para resultados
        Dim datos As New ObjDatos 'Objetod para mandar llamar el ws

        Try

            Dim claproveedor As Integer = Consultar_Proveedor_Asistencia_II(contrato.IdProveedor).DataTable.Rows(0)(0)

            If claproveedor <> Nothing Then

                If res.ErrorDesc <> "" Then
                    res.Estatus = Estatus.Error
                Else

                    datos.Consultar_Servcio_Asistencia_II(" exec sp_Update_ProveedorAutoSigue " & anio & ", " & consec & ", " & claproveedor, res.DataTable)

                    'Verifica si todo salió bien:
                    'res.Dato =  'Aqui devuelve el Id
                    'Dim NumServicio As String = res.DataTable.Rows(0)(0) & "" & res.DataTable.Rows(0)(1)

                    'Graba la bitacora

                    'Graba la auditoria
                    'Auditoria.Registrar(usr, 55, res.Dato & "-" & NumServicio)
                End If
            End If

        Catch ex As Validacion_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            ''Se regresan y registran los datos del error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("CheckIn.vb", "sp_Update_ProveedorAutoSigue", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function

    Public Function Consultar_Proveedor_Asistencia_II(ByVal idproveedor As Integer) As Resultado
        Dim res As New Resultado 'Objeto para resultados
        Dim datos As New ObjDatos 'Objetod para mandar llamar el ws

        Try

            datos.sqlParameters.Add(New SqlParameter("@id", idproveedor))

            datos.Consulta_SP(" exec Select_ProveedorAsistencia_sp @id", res.DataTable)

            ' Verifica si todo salió bien:
            'res.Dato =  'Aqui devuelve el Id

            ' Graba la bitacora

            ' Graba la auditoria
            'Auditoria.Registrar(usr, 55, res.Dato & "-" & NumServicio)
        Catch ex As Validacion_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            ''Se regresan y registran los datos del error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("CheckIn.vb", "Select_ProveedorAsistencia_sp", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function

    Public Function Actualiza_servicios_AsistenciaII(ByVal anio As Integer, ByVal consec As Integer, ByVal servicio As CServicio, ByVal IdUsuario As String, ByVal bitacora As String) As Resultado
        Dim res As New Resultado 'Objeto para resultados
        Dim datos As New ObjDatos 'Objetod para mandar llamar el ws



        Try
            datos.Actualizar_Servcio_Asistencia_II(" exec Update_Servicios_AutoSigue " & anio & "," & consec & ",'" & servicio.NumPoliza & "','" & servicio.Inciso & "','" & servicio.VehPlacas & "','" & servicio.NumSiniestro & "','" & Replace(servicio.FecActivacion, "a.m.", "") & "','" & servicio.VehSerie & "','" & servicio.RepNombre & "','" & servicio.RepTelefono & "','" & "'", res.DataTable)

        Catch ex As Exception
            datos.Desconectar()
            res.ErrorDesc = ex.Message
            Logs.LogError("AccesoDatos.vb", "Update_Servicios_AutoSigue", ex.Message)
        Finally

            datos.Desconectar()

        End Try
        Return res
    End Function

    Public Function Consultar_IdServicio(ByVal usr As String, ByVal NumServicio As String) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos


        Try
            'Se crean parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@NumServicio", NumServicio))

            datos.Consulta_SP("Select_IdServicio @NumServicio", res.DataTable)


        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("CheckIn.vb", "Select_IdServicio", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
        Return res
    End Function

    Public Function Actualizar_Servicios(ByVal usr As Integer, ByVal servicio As CServicio, ByVal IdUsuario As Integer, ByVal Bitacora As String) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos


        Try

            If Not Validacion.Solo_LetrasDigitosEspaciosSinNumeros(servicio.AsegNombre) Then
                Throw New Validacion_Exception("Nombre del Asegurado")
            End If

            If Not Validacion.Solo_LetrasDigitosEspaciosSinNumeros(servicio.AsegMaterno) Then
                Throw New Validacion_Exception("Apellido Materno del Asegurado")
            End If

            If Not Validacion.Solo_LetrasDigitosEspaciosSinNumeros(servicio.AsegPaterno) Then
                Throw New Validacion_Exception("Apellido Paterno del Asegurado")
            End If

            If Not Validacion.Solo_LetrasDigitosEspaciosSinNumeros(servicio.RepNombre) Then
                Throw New Validacion_Exception("Nombre de Quien Reporta")
            End If

            If Not Validacion.Solo_LetrasDigitosEspaciosSinNumeros(servicio.RepMaterno) Then
                Throw New Validacion_Exception("Apellido Materno de Quien Reporta")
            End If

            If Not Validacion.Solo_LetrasDigitosEspaciosSinNumeros(servicio.RepPaterno) Then
                Throw New Validacion_Exception("Apellido Paterno de Quien Reporta")
            End If

            'Indicador de la fase
            datos.sqlParameters.Add(New SqlParameter("@Fase", servicio.fase))

            ' Usuario que realizó la modificación
            datos.sqlParameters.Add(New SqlParameter("@IdUsuario", IdUsuario))

            ' llave
            datos.sqlParameters.Add(New SqlParameter("@IdServicio", servicio.IdServicio))

            'ACTIVACION
            datos.sqlParameters.Add(New SqlParameter("@ConCosto", servicio.ConCosto))
            datos.sqlParameters.Add(New SqlParameter("@AsegMaterno", servicio.AsegMaterno))
            datos.sqlParameters.Add(New SqlParameter("@AsegNombre", servicio.AsegNombre))
            datos.sqlParameters.Add(New SqlParameter("@AsegPaterno", servicio.AsegPaterno))
            datos.sqlParameters.Add(New SqlParameter("@AsegTelefono", servicio.AsegTelefono))
            datos.sqlParameters.Add(New SqlParameter("@Categoria", servicio.Categoria))
            datos.sqlParameters.Add(New SqlParameter("@Cobertura", servicio.Cobertura))
            datos.sqlParameters.Add(New SqlParameter("@Costo", servicio.Costo))
            datos.sqlParameters.Add(New SqlParameter("@DiasRenta", servicio.DiasRenta))
            datos.sqlParameters.Add(New SqlParameter("@IdAseguradora", servicio.IdAseguradora))
            datos.sqlParameters.Add(New SqlParameter("@IdEvento", servicio.IdEvento))
            datos.sqlParameters.Add(New SqlParameter("@IdQuienReporta", servicio.IdQuienReporta))
            datos.sqlParameters.Add(New SqlParameter("@IdUbicacionEntrega", servicio.IdUbicacionEntrega))
            datos.sqlParameters.Add(New SqlParameter("@Inciso", servicio.Inciso))
            datos.sqlParameters.Add(New SqlParameter("@NumPoliza", servicio.NumPoliza))
            datos.sqlParameters.Add(New SqlParameter("@RepEmail", servicio.RepEmail))
            datos.sqlParameters.Add(New SqlParameter("@RepIdEstado", servicio.RepIdEstado))
            datos.sqlParameters.Add(New SqlParameter("@RepIdMunicipio", servicio.RepIdMunicipio))
            datos.sqlParameters.Add(New SqlParameter("@RepMaterno", servicio.RepMaterno))
            datos.sqlParameters.Add(New SqlParameter("@RepNombre", servicio.RepNombre))
            datos.sqlParameters.Add(New SqlParameter("@RepPaterno", servicio.RepPaterno))
            datos.sqlParameters.Add(New SqlParameter("@RepTelefono", servicio.RepTelefono))
            datos.sqlParameters.Add(New SqlParameter("@RepTelefono0", servicio.RepTelefono0))
            datos.sqlParameters.Add(New SqlParameter("@AsegTelefono0", servicio.AsegTelefono0))
            datos.sqlParameters.Add(New SqlParameter("@LadaRepTelefono", servicio.LadaRepTelefono))
            datos.sqlParameters.Add(New SqlParameter("@LadaRepTelefono0", servicio.LadaRepTelefono0))
            datos.sqlParameters.Add(New SqlParameter("@LadaAsegTelefono", servicio.LadaAsegTelefono))
            datos.sqlParameters.Add(New SqlParameter("@LadaAsegTelefono0", servicio.LadaAsegTelefono0))

            'ATENCION CITA
            datos.sqlParameters.Add(New SqlParameter("@FecEntrega", servicio.FecEntrega))
            datos.sqlParameters.Add(New SqlParameter("@FecDevolucionPrevista", servicio.FecDevolucionPrevista))
            datos.sqlParameters.Add(New SqlParameter("@VehIdMarca", servicio.VehIdMarca))
            datos.sqlParameters.Add(New SqlParameter("@VehIdSubMarca", servicio.VehIdSubMarca))
            datos.sqlParameters.Add(New SqlParameter("@VehValorComercial", servicio.VehValorComercial))
            datos.sqlParameters.Add(New SqlParameter("@VehModelo", servicio.VehModelo))
            datos.sqlParameters.Add(New SqlParameter("@VehIdEstado", servicio.VehIdEstado))
            datos.sqlParameters.Add(New SqlParameter("@VehIdMunicipio", servicio.VehIdMunicipio))
            datos.sqlParameters.Add(New SqlParameter("@VehColonia", servicio.VehColonia))
            datos.sqlParameters.Add(New SqlParameter("@VehCalle", servicio.VehCalle))
            datos.sqlParameters.Add(New SqlParameter("@VehNumero", servicio.VehNumero))
            datos.sqlParameters.Add(New SqlParameter("@VehCP", servicio.VehCP))
            datos.sqlParameters.Add(New SqlParameter("@VehPlacas", servicio.VehPlacas))
            datos.sqlParameters.Add(New SqlParameter("@VehSerie", servicio.VehSerie))
            datos.sqlParameters.Add(New SqlParameter("@NumSiniestro", servicio.NumSiniestro))
            datos.sqlParameters.Add(New SqlParameter("@SiniLugarOcurrencia", servicio.SiniLugarOcurrencia))
            datos.sqlParameters.Add(New SqlParameter("@SiniLugarReporte", servicio.SiniLugarReporte))
            datos.sqlParameters.Add(New SqlParameter("@DescripcionReporte", servicio.DescripcionReporte))

            datos.Comando_SP("Update_Servicios @Fase, @IdUsuario, @IdServicio, @ConCosto, @IdAseguradora, @IdQuienReporta, @NumPoliza, @Inciso, @Categoria, @IdUbicacionEntrega, " &
                             "@IdEvento, @Cobertura, @Costo, @DiasRenta, @RepNombre, @RepPaterno, @RepMaterno, @RepTelefono, @RepEmail, " &
                             "@RepIdEstado, @RepIdMunicipio, @AsegNombre, @AsegPaterno, @AsegMaterno, @AsegTelefono, @RepTelefono0, @AsegTelefono0, @LadaRepTelefono, @LadaRepTelefono0, @LadaAsegTelefono, @LadaAsegTelefono0, @FecEntrega, @FecDevolucionPrevista, " &
                             "@VehIdMarca, @VehIdSubMarca, @VehValorComercial, @VehModelo, @VehIdEstado, @VehIdMunicipio, @VehColonia, " &
                             "@VehCalle, @VehNumero, @VehCP, @VehPlacas, @VehSerie, " &
                             "@NumSiniestro, @SiniLugarOcurrencia, @SiniLugarReporte, @DescripcionReporte", res.DataTable)

            ' Graba la auditoria
            Auditoria.Registrar(usr, 56, servicio.IdServicio)
        Catch ex As Validacion_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("CheckIn.vb", "Update_Servicios", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
        Return res
    End Function

    Public Function Consultar_Servicios_Completos(usr As String, IdServicio As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos


        Try
            'Se crean parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@IdServicio", IdServicio))

            datos.Consulta_SP("Select_Servicios_Completos @IdServicio", res.DataTable)


        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("CheckIn.vb", "Select_Servicios_Completos", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
        Return res
    End Function

    Public Function Cancelar_Servicio(ByVal usr As String, ByVal IdServicio As Integer, ByVal IdMotivoCancel As Integer, ByVal Descrip As CServicio) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos


        Try
            'Se crean parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@IdServicio", IdServicio))
            datos.sqlParameters.Add(New SqlParameter("@IdMotivoCancel", IdMotivoCancel))
            datos.sqlParameters.Add(New SqlParameter("@DescOtro", Descrip.DescOtro))
            datos.Comando_SP("Delete_Servicios @IdServicio, @IdMotivoCancel, @DescOtro", res.DataTable)

            ' Graba la auditoria
            Auditoria.Registrar(usr, 57, IdServicio)
        Catch ex As Validacion_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("CheckIn.vb", "Delete_Servicios", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
        Return res
    End Function

    Public Function Insertar_Servicios_Bitacora(ByVal usr As Integer, ByVal bitacora As CBitacoraServicios) As Resultado
        Dim res As New Resultado 'Objeto para resultados
        Dim datos As New ObjDatos 'Objetod para mandar llamar el ws


        Try

            datos.sqlParameters.Add(New SqlParameter("@IdServicio", bitacora.IdServicio))
            datos.sqlParameters.Add(New SqlParameter("@Bitacora", bitacora.Bitacora))
            datos.sqlParameters.Add(New SqlParameter("@IdUsuario", usr))
            datos.sqlParameters.Add(New SqlParameter("@IdContrato", bitacora.IdContrato))
            datos.sqlParameters.Add(New SqlParameter("@NumServicio", bitacora.NumServicio))
            datos.Comando_SP("Insert_Servicios_Bitacora @IdServicio, @Bitacora, @IdUsuario,@IdContrato,@NumServicio", res.DataTable)

            ' Graba la auditoria
            Auditoria.Registrar(usr, 58, bitacora.IdServicio & "-" & res.DataTable.Rows(0)(2))
        Catch ex As Validacion_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            ''Se regresan y registran los datos del error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("CheckIn.vb", "Insert_Servicios_Bitacora", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function

    Public Function Consultar_Servicios_Bitacora(usr As String, IdServicio As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos


        Try

            'Se crean parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@IdServicio", IdServicio))

            datos.Consulta_SP("Select_Servicios_Bitacora @IdServicio", res.DataTable)


        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("CheckIn.vb", "Select_Servicios_Bitacora", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
        Return res
    End Function

    Public Function Consultar_Servicios_BitacoraGral(ByVal usr As String, ByVal IdServicio As Integer) As Resultado ', ByVal IdContrato As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos


        Try

            'Se crean parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@IdServicio", IdServicio))
            'datos.sqlParameters.Add(New SqlParameter("@IdContrato", IdContrato))

            datos.Consulta_SP("Select_ServYContra_BitacoraGral @IdServicio", res.DataTable) ', @IdContrato", res.DataTable)


        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("CheckIn.vb", "Select_ServYContra_BitacoraGral", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
        Return res
    End Function

    Public Function Consultar_Servicios_Poliza_N_Dias(usr As String, NumPoliza As String) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos


        Try
            'Se crean parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@NumPoliza", NumPoliza))

            datos.Consulta_SP("Select_Servicios_Poliza_N_Dias @NumPoliza", res.DataTable)


        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("CheckIn.vb", "Select_Servicios_Poliza_N_Dias", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
        Return res
    End Function

    Public Function Consultar_Servicios_Poliza_N_Dias2(ByVal usr As String, ByVal NumPoliza As String, ByVal IdAseguradora As String) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos


        Try
            'Se crean parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@NumPoliza", NumPoliza))
            datos.sqlParameters.Add(New SqlParameter("@IdAseg", IdAseguradora))

            datos.Consulta_SP("Select_Servicios_Poliza_N_Dias @NumPoliza, @IdAseg", res.DataTable)


        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("CheckIn.vb", "Select_Servicios_Poliza_N_Dias", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
        Return res
    End Function

    Public Function Consultar_Dias_Usados_Poliza2(ByVal usr As String, ByVal NumPoliza As String, ByVal IdAseg As String) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos


        Try
            'Se crean parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@NumPoliza", NumPoliza))
            datos.sqlParameters.Add(New SqlParameter("@IdAseg", IdAseg))

            datos.Consulta_SP("Select_Dias_Usados_Poliza @NumPoliza, @IdAseg", res.DataTable)

            If IsDBNull(res.DataTable.Rows(0)(0)) Then
                res.Dato = 0
            Else
                res.Dato = res.DataTable.Rows(0)(0)
            End If

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("CheckIn.vb", "Select_Dias_Usados_Poliza", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
        Return res
    End Function

    Public Function Consultar_Dias_Usados_Poliza(usr As String, NumPoliza As String) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos


        Try
            'Se crean parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@NumPoliza", NumPoliza))

            datos.Consulta_SP("Select_Dias_Usados_Poliza @NumPoliza", res.DataTable)

            If IsDBNull(res.DataTable.Rows(0)(0)) Then
                res.Dato = 0
            Else
                res.Dato = res.DataTable.Rows(0)(0)
            End If

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("CheckIn.vb", "Select_Dias_Usados_Poliza", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
        Return res
    End Function

    Public Function Consultar_Servicios_X_Poliza(usr As String, NumPoliza As String) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos


        Try
            'Se crean parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@NumPoliza", NumPoliza))

            datos.Consulta_SP("Select_Servicios_X_Poliza @NumPoliza", res.DataTable)

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("CheckIn.vb", "Select_Servicios_X_Poliza", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
        Return res
    End Function

    Public Function Buscar_IdServicio(usr As String, NumServicio As String, SoloDisponibles As Boolean) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos


        Try
            'Se crean parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@NumServicio", NumServicio))
            datos.sqlParameters.Add(New SqlParameter("@SoloDisponibles", SoloDisponibles))

            datos.Consulta_SP("Buscar_IdServicio @NumServicio, @SoloDisponibles", res.DataTable)

            ' Verifica si todo salió bien:
            If res.DataTable.Rows.Count = 0 Then
                res.Dato = -1
            Else
                'Devuelve el Id del servicio que encontro
                res.Dato = res.DataTable.Rows(0)(0) 'Aqui devuelve el Id
            End If


        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("CheckIn.vb", "Buscar_IdServicio", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
        Return res
    End Function

#End Region

#Region "Contratos"
    'Isra
    Public Function Consulta_IdRegion(ByVal usr As String, ByVal region As CContrato) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try

            datos.sqlParameters.Add(New SqlParameter("@IdEstado", region.IdRegion))

            datos.Consulta_SP("Select_IdRegion @IdEstado", res.DataTable)


        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("CheckIn.vb", "Select_IdRegion", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
        Return res
    End Function
    'Termina Isra
    Public Function Insertar_Contratos(ByVal usr As Integer, ByVal contrato As CContrato) As Resultado
        Dim res As New Resultado 'Objeto para resultados
        Dim datos As New ObjDatos 'Objetod para mandar llamar el ws

        Try
            ' Valida que sea un dato correcto
            'If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(contrato.AsegLicencia) Then
            '    Throw New Validacion_Exception("Número de Licencia")
            'End If

            If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(contrato.RefDepositoBancario) Then
                Throw New Validacion_Exception("Referencia de Depósito Bancario")
            End If

            If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(contrato.NumAutorizacionTarjeta) Then
                Throw New Validacion_Exception("Número de Autorización")
            End If

            'If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(contrato.PlacasVehProv) Then
            '    Throw New Validacion_Exception("Placas del Vehículo")
            'End If


            'Se crea parámetro y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@AsegLicencia", contrato.AsegLicencia))
            datos.sqlParameters.Add(New SqlParameter("@Permanente", contrato.Permanente))
            datos.sqlParameters.Add(New SqlParameter("@FecAsegVencimientoLicencia", contrato.FecAsegVencimientoLicencia))
            datos.sqlParameters.Add(New SqlParameter("@IdServicio", contrato.IdServicio))
            datos.sqlParameters.Add(New SqlParameter("@IdTipoLicenciaAseg", contrato.IdTipoLicenciaAseg))
            datos.sqlParameters.Add(New SqlParameter("@Garantia", contrato.Garantia))
            datos.sqlParameters.Add(New SqlParameter("@IdTipoPagoBancario", contrato.IdTipoPagoBancario))
            datos.sqlParameters.Add(New SqlParameter("@IdTipoTarjetaBancaria", contrato.IdTipoTarjetaBancaria))
            datos.sqlParameters.Add(New SqlParameter("@IdVehiculo", contrato.IdVehiculo))
            datos.sqlParameters.Add(New SqlParameter("@Monto", contrato.Monto))
            datos.sqlParameters.Add(New SqlParameter("@NumAutorizacion", contrato.NumAutorizacionTarjeta))
            datos.sqlParameters.Add(New SqlParameter("@NumTarjeta4Digitos", contrato.NumTarjeta4Digitos))
            datos.sqlParameters.Add(New SqlParameter("@CodigoSeguridad", contrato.CodigoSeguridadTarjeta))
            datos.sqlParameters.Add(New SqlParameter("@RefDepositoBancario", contrato.RefDepositoBancario))
            datos.sqlParameters.Add(New SqlParameter("@VencimientoTarjeta", contrato.VencimientoTarjeta))
            datos.sqlParameters.Add(New SqlParameter("@TipoAuto", contrato.TipoAuto))
            datos.sqlParameters.Add(New SqlParameter("@IdMarcaVehProv", contrato.IdMarcaVehProv))
            datos.sqlParameters.Add(New SqlParameter("@IdSubmarcaVehProv", contrato.IdSubmarcaVehProv))
            datos.sqlParameters.Add(New SqlParameter("@ModeloVehProv", contrato.ModeloVehProv))
            datos.sqlParameters.Add(New SqlParameter("@PlacasVehProv", contrato.PlacasVehProv))
            datos.sqlParameters.Add(New SqlParameter("@Kilometraje", contrato.Kilometraje))
            datos.sqlParameters.Add(New SqlParameter("@IdNivelGasolina", contrato.IdNivelGasolina))
            datos.sqlParameters.Add(New SqlParameter("@IdProveedor", contrato.IdProveedor))
            datos.sqlParameters.Add(New SqlParameter("@Costo", contrato.Costo))
            datos.sqlParameters.Add(New SqlParameter("@CostoDropOff", contrato.CostoDropOff))
            datos.sqlParameters.Add(New SqlParameter("@Precio", contrato.Precio))
            datos.sqlParameters.Add(New SqlParameter("@ImpuestoFedAero", contrato.ImpuestoFedAero))
            datos.sqlParameters.Add(New SqlParameter("@SeguroConductorMenor", contrato.SeguroConductorMenor))
            datos.sqlParameters.Add(New SqlParameter("@ColorVeh", contrato.ColorVeh))
            'datos.sqlParameters.Add(New SqlParameter("@NumReserva", contrato.NumReserva))
            datos.sqlParameters.Add(New SqlParameter("@TipoAutoAnt", contrato.TipoAutoAnt))
            datos.sqlParameters.Add(New SqlParameter("@FecDevolucionPrevistaII", contrato.FecDevoPrevistaII))
            datos.sqlParameters.Add(New SqlParameter("@IdRegionVeh", contrato.IdRegionVeh))
            datos.sqlParameters.Add(New SqlParameter("@IdCoordinacionVeh", contrato.IdCoordinacionVeh))
            datos.sqlParameters.Add(New SqlParameter("@IdAlmacenVeh", contrato.IdAlmacenVeh))
            datos.sqlParameters.Add(New SqlParameter("@PlacasVeh", contrato.PlacasVeh))

            datos.Comando_SP("Insert_Contratos @IdServicio, @AsegLicencia, @IdTipoLicenciaAseg, @Permanente, @FecAsegVencimientoLicencia, @Garantia, @IdTipoPagoBancario, @IdTipoTarjetaBancaria, @NumTarjeta4Digitos, @CodigoSeguridad, @VencimientoTarjeta, @NumAutorizacion, @RefDepositoBancario, @Monto, @TipoAuto, @IdVehiculo, @IdMarcaVehProv, @IdSubmarcaVehProv, @ModeloVehProv, @PlacasVehProv, @kilometraje, @IdNivelGasolina, @IdProveedor, @Costo, @CostoDropOff, @ImpuestoFedAero, @SeguroConductorMenor, @Precio,@ColorVeh,@TipoAutoAnt,@FecDevolucionPrevistaII,@IdRegionVeh, @IdCoordinacionVeh, @IdAlmacenVeh, @PlacasVeh", res.DataTable)

            'Devuelve el Id del contrato que se grabo
            res.Dato = res.DataTable.Rows(0)(2) 'Aqui devuelve el Id

            ' Graba la auditoria
            Auditoria.Registrar(usr, 59, res.Dato & "-" & res.DataTable.Rows(0)(3))
        Catch ex As Validacion_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            ''Se regresan y registran los datos del error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("CheckIn.vb", "Insert_Contratos", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function

    Public Function Update_Contratos1(ByVal usr As Integer, ByVal contrato As CContrato) As Resultado
        Dim res As New Resultado 'Objeto para resultados
        Dim datos As New ObjDatos 'Objetod para mandar llamar el ws

        Try
            ' Valida que sea un dato correcto
            'If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(contrato.AsegLicencia) Then
            '    Throw New Validacion_Exception("Número de Licencia")
            'End If

            'If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(contrato.RefDepositoBancario) Then
            '    Throw New Validacion_Exception("Referencia de Depósito Bancario")
            'End If

            'If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(contrato.NumAutorizacionTarjeta) Then
            '    Throw New Validacion_Exception("Número de Autorización")
            'End If

            'If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(contrato.PlacasVehProv) Then
            '    Throw New Validacion_Exception("Placas del Vehículo")
            'End If


            'Se crea parámetro y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@AsegLicencia", contrato.AsegLicencia))
            datos.sqlParameters.Add(New SqlParameter("@Permanente", contrato.Permanente))
            datos.sqlParameters.Add(New SqlParameter("@FecAsegVencimientoLicencia", contrato.FecAsegVencimientoLicencia))
            datos.sqlParameters.Add(New SqlParameter("@IdServicio", contrato.IdServicio))
            datos.sqlParameters.Add(New SqlParameter("@IdTipoLicenciaAseg", contrato.IdTipoLicenciaAseg))
            datos.sqlParameters.Add(New SqlParameter("@Garantia", contrato.Garantia))
            datos.sqlParameters.Add(New SqlParameter("@IdTipoPagoBancario", contrato.IdTipoPagoBancario))
            datos.sqlParameters.Add(New SqlParameter("@IdTipoTarjetaBancaria", contrato.IdTipoTarjetaBancaria))
            datos.sqlParameters.Add(New SqlParameter("@IdVehiculo", contrato.IdVehiculo))
            datos.sqlParameters.Add(New SqlParameter("@Monto", contrato.Monto))
            datos.sqlParameters.Add(New SqlParameter("@NumAutorizacion", contrato.NumAutorizacionTarjeta))
            datos.sqlParameters.Add(New SqlParameter("@NumTarjeta4Digitos", contrato.NumTarjeta4Digitos))
            datos.sqlParameters.Add(New SqlParameter("@CodigoSeguridad", contrato.CodigoSeguridadTarjeta))
            datos.sqlParameters.Add(New SqlParameter("@RefDepositoBancario", contrato.RefDepositoBancario))
            datos.sqlParameters.Add(New SqlParameter("@VencimientoTarjeta", contrato.VencimientoTarjeta))
            datos.sqlParameters.Add(New SqlParameter("@TipoAuto", contrato.TipoAuto))
            datos.sqlParameters.Add(New SqlParameter("@IdMarcaVehProv", contrato.IdMarcaVehProv))
            datos.sqlParameters.Add(New SqlParameter("@IdSubmarcaVehProv", contrato.IdSubmarcaVehProv))
            datos.sqlParameters.Add(New SqlParameter("@ModeloVehProv", contrato.ModeloVehProv))
            datos.sqlParameters.Add(New SqlParameter("@PlacasVehProv", contrato.PlacasVehProv))
            datos.sqlParameters.Add(New SqlParameter("@Kilometraje", contrato.Kilometraje))
            datos.sqlParameters.Add(New SqlParameter("@IdNivelGasolina", contrato.IdNivelGasolina))
            datos.sqlParameters.Add(New SqlParameter("@IdProveedor", contrato.IdProveedor))
            datos.sqlParameters.Add(New SqlParameter("@Costo", contrato.Costo))
            datos.sqlParameters.Add(New SqlParameter("@CostoDropOff", contrato.CostoDropOff))
            datos.sqlParameters.Add(New SqlParameter("@Precio", contrato.Precio))
            datos.sqlParameters.Add(New SqlParameter("@ImpuestoFedAero", contrato.ImpuestoFedAero))
            datos.sqlParameters.Add(New SqlParameter("@SeguroConductorMenor", contrato.SeguroConductorMenor))
            datos.sqlParameters.Add(New SqlParameter("@ColorVeh", contrato.ColorVeh))
            datos.sqlParameters.Add(New SqlParameter("@NumReserva", contrato.NumReserva))
            datos.sqlParameters.Add(New SqlParameter("@NumContrato", contrato.NumContrato))
            datos.sqlParameters.Add(New SqlParameter("@FecEntregaReal", contrato.FecEntregaReal))
            datos.sqlParameters.Add(New SqlParameter("@FecDevoPrevistaII", contrato.FecDevoPrevistaII))

            datos.Comando_SP("Update_Contratos1 @IdServicio, @AsegLicencia, @IdTipoLicenciaAseg, @Permanente, @FecAsegVencimientoLicencia, @Garantia, @IdTipoPagoBancario, @IdTipoTarjetaBancaria, @NumTarjeta4Digitos, @CodigoSeguridad, @VencimientoTarjeta, @NumAutorizacion, @RefDepositoBancario, @Monto, @TipoAuto, @IdVehiculo, @IdMarcaVehProv, @IdSubmarcaVehProv, @ModeloVehProv, @PlacasVehProv, @kilometraje, @IdNivelGasolina, @IdProveedor, @Costo, @CostoDropOff, @ImpuestoFedAero, @SeguroConductorMenor, @Precio,@ColorVeh,@NumReserva,@NumContrato,@FecEntregaReal,@FecDevoPrevistaII", res.DataTable)

            'Devuelve el Id del contrato que se grabo
            res.Dato = res.DataTable.Rows(0)(2) 'Aqui devuelve el Id

            ' Graba la auditoria
            Auditoria.Registrar(usr, 59, res.Dato & "-" & res.DataTable.Rows(0)(3))
        Catch ex As Validacion_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            ''Se regresan y registran los datos del error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("CheckIn.vb", "Update_Contratos1", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function

    Public Function Update_Contratos2(ByVal usr As Integer, ByVal contrato As CContrato) As Resultado
        Dim res As New Resultado 'Objeto para resultados
        Dim datos As New ObjDatos 'Objetod para mandar llamar el ws

        Try
            ' Valida que sea un dato correcto
            'If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(contrato.AsegLicencia) Then
            '    Throw New Validacion_Exception("Número de Licencia")
            'End If

            'If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(contrato.RefDepositoBancario) Then
            '    Throw New Validacion_Exception("Referencia de Depósito Bancario")
            'End If

            'If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(contrato.NumAutorizacionTarjeta) Then
            '    Throw New Validacion_Exception("Número de Autorización")
            'End If

            'If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(contrato.PlacasVehProv) Then
            '    Throw New Validacion_Exception("Placas del Vehículo")
            'End If


            'Se crea parámetro y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@AsegLicencia", contrato.AsegLicencia))
            datos.sqlParameters.Add(New SqlParameter("@Permanente", contrato.Permanente))
            datos.sqlParameters.Add(New SqlParameter("@FecAsegVencimientoLicencia", contrato.FecAsegVencimientoLicencia))
            datos.sqlParameters.Add(New SqlParameter("@IdServicio", contrato.IdServicio))
            datos.sqlParameters.Add(New SqlParameter("@IdTipoLicenciaAseg", contrato.IdTipoLicenciaAseg))
            datos.sqlParameters.Add(New SqlParameter("@Garantia", contrato.Garantia))
            datos.sqlParameters.Add(New SqlParameter("@IdTipoPagoBancario", contrato.IdTipoPagoBancario))
            datos.sqlParameters.Add(New SqlParameter("@IdTipoTarjetaBancaria", contrato.IdTipoTarjetaBancaria))
            datos.sqlParameters.Add(New SqlParameter("@IdVehiculo", contrato.IdVehiculo))
            datos.sqlParameters.Add(New SqlParameter("@Monto", contrato.Monto))
            datos.sqlParameters.Add(New SqlParameter("@NumAutorizacion", contrato.NumAutorizacionTarjeta))
            datos.sqlParameters.Add(New SqlParameter("@NumTarjeta4Digitos", contrato.NumTarjeta4Digitos))
            datos.sqlParameters.Add(New SqlParameter("@CodigoSeguridad", contrato.CodigoSeguridadTarjeta))
            datos.sqlParameters.Add(New SqlParameter("@RefDepositoBancario", contrato.RefDepositoBancario))
            datos.sqlParameters.Add(New SqlParameter("@VencimientoTarjeta", contrato.VencimientoTarjeta))
            datos.sqlParameters.Add(New SqlParameter("@TipoAuto", contrato.TipoAuto))
            datos.sqlParameters.Add(New SqlParameter("@IdMarcaVehProv", contrato.IdMarcaVehProv))
            datos.sqlParameters.Add(New SqlParameter("@IdSubmarcaVehProv", contrato.IdSubmarcaVehProv))
            datos.sqlParameters.Add(New SqlParameter("@ModeloVehProv", contrato.ModeloVehProv))
            datos.sqlParameters.Add(New SqlParameter("@PlacasVehProv", contrato.PlacasVehProv))
            datos.sqlParameters.Add(New SqlParameter("@Kilometraje", contrato.Kilometraje))
            datos.sqlParameters.Add(New SqlParameter("@IdNivelGasolina", contrato.IdNivelGasolina))
            datos.sqlParameters.Add(New SqlParameter("@IdProveedor", contrato.IdProveedor))
            datos.sqlParameters.Add(New SqlParameter("@Costo", contrato.Costo))
            datos.sqlParameters.Add(New SqlParameter("@CostoDropOff", contrato.CostoDropOff))
            datos.sqlParameters.Add(New SqlParameter("@Precio", contrato.Precio))
            datos.sqlParameters.Add(New SqlParameter("@ImpuestoFedAero", contrato.ImpuestoFedAero))
            datos.sqlParameters.Add(New SqlParameter("@SeguroConductorMenor", contrato.SeguroConductorMenor))
            datos.sqlParameters.Add(New SqlParameter("@ColorVeh", contrato.ColorVeh))
            datos.sqlParameters.Add(New SqlParameter("@NumReserva", contrato.NumReserva))
            datos.sqlParameters.Add(New SqlParameter("@NumContrato", contrato.NumContrato))

            datos.Comando_SP("Update_Contratos1_2 @IdServicio, @AsegLicencia, @IdTipoLicenciaAseg, @Permanente, @FecAsegVencimientoLicencia, @Garantia, @IdTipoPagoBancario, @IdTipoTarjetaBancaria, @NumTarjeta4Digitos, @CodigoSeguridad, @VencimientoTarjeta, @NumAutorizacion, @RefDepositoBancario, @Monto, @TipoAuto, @IdVehiculo, @IdMarcaVehProv, @IdSubmarcaVehProv, @ModeloVehProv, @PlacasVehProv, @kilometraje, @IdNivelGasolina, @IdProveedor, @Costo, @CostoDropOff, @ImpuestoFedAero, @SeguroConductorMenor, @Precio,@ColorVeh,@NumReserva,@NumContrato", res.DataTable)

            'Devuelve el Id del contrato que se grabo
            res.Dato = res.DataTable.Rows(0)(2) 'Aqui devuelve el Id

            ' Graba la auditoria
            Auditoria.Registrar(usr, 59, res.Dato & "-" & res.DataTable.Rows(0)(3))
        Catch ex As Validacion_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            ''Se regresan y registran los datos del error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("CheckIn.vb", "Update_Contratos1_2", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function

    Public Function Insertar_Contratos_Proveedor(ByVal usr As Integer, ByVal contrato As CContrato) As Resultado
        Dim res As New Resultado 'Objeto para resultados
        Dim datos As New ObjDatos 'Objetod para mandar llamar el ws

        Try
            ' Valida que sea un dato correcto
            'If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(contrato.AsegLicencia) Then
            '    Throw New Validacion_Exception("Número de Licencia")
            'End If

            If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(contrato.RefDepositoBancario) Then
                Throw New Validacion_Exception("Referencia de Depósito Bancario")
            End If

            If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(contrato.NumAutorizacionTarjeta) Then
                Throw New Validacion_Exception("Número de Autorización")
            End If

            'If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(contrato.PlacasVehProv) Then
            '    Throw New Validacion_Exception("Placas del Vehículo")
            'End If


            'Se crea parámetro y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@AsegLicencia", contrato.AsegLicencia))
            datos.sqlParameters.Add(New SqlParameter("@Permanente", contrato.Permanente))
            datos.sqlParameters.Add(New SqlParameter("@FecAsegVencimientoLicencia", contrato.FecAsegVencimientoLicencia))
            datos.sqlParameters.Add(New SqlParameter("@IdServicio", contrato.IdServicio))
            datos.sqlParameters.Add(New SqlParameter("@IdTipoLicenciaAseg", contrato.IdTipoLicenciaAseg))
            datos.sqlParameters.Add(New SqlParameter("@Garantia", contrato.Garantia))
            datos.sqlParameters.Add(New SqlParameter("@IdTipoPagoBancario", contrato.IdTipoPagoBancario))
            datos.sqlParameters.Add(New SqlParameter("@IdTipoTarjetaBancaria", contrato.IdTipoTarjetaBancaria))
            datos.sqlParameters.Add(New SqlParameter("@IdVehiculo", contrato.IdVehiculo))
            datos.sqlParameters.Add(New SqlParameter("@Monto", contrato.Monto))
            datos.sqlParameters.Add(New SqlParameter("@NumAutorizacion", contrato.NumAutorizacionTarjeta))
            datos.sqlParameters.Add(New SqlParameter("@NumTarjeta4Digitos", contrato.NumTarjeta4Digitos))
            datos.sqlParameters.Add(New SqlParameter("@CodigoSeguridad", contrato.CodigoSeguridadTarjeta))
            datos.sqlParameters.Add(New SqlParameter("@RefDepositoBancario", contrato.RefDepositoBancario))
            datos.sqlParameters.Add(New SqlParameter("@VencimientoTarjeta", contrato.VencimientoTarjeta))
            datos.sqlParameters.Add(New SqlParameter("@TipoAuto", contrato.TipoAuto))
            datos.sqlParameters.Add(New SqlParameter("@IdMarcaVehProv", contrato.IdMarcaVehProv))
            datos.sqlParameters.Add(New SqlParameter("@IdSubmarcaVehProv", contrato.IdSubmarcaVehProv))
            datos.sqlParameters.Add(New SqlParameter("@ModeloVehProv", contrato.ModeloVehProv))
            datos.sqlParameters.Add(New SqlParameter("@PlacasVehProv", contrato.PlacasVehProv))
            datos.sqlParameters.Add(New SqlParameter("@Kilometraje", contrato.Kilometraje))
            datos.sqlParameters.Add(New SqlParameter("@IdNivelGasolina", contrato.IdNivelGasolina))
            datos.sqlParameters.Add(New SqlParameter("@IdProveedor", contrato.IdProveedor))
            datos.sqlParameters.Add(New SqlParameter("@Costo", contrato.Costo))
            datos.sqlParameters.Add(New SqlParameter("@CostoDropOff", contrato.CostoDropOff))
            datos.sqlParameters.Add(New SqlParameter("@Precio", contrato.Precio))
            datos.sqlParameters.Add(New SqlParameter("@ImpuestoFedAero", contrato.ImpuestoFedAero))
            datos.sqlParameters.Add(New SqlParameter("@SeguroConductorMenor", contrato.SeguroConductorMenor))
            datos.sqlParameters.Add(New SqlParameter("@ColorVeh", contrato.ColorVeh))
            datos.sqlParameters.Add(New SqlParameter("@NumReserva", contrato.NumReserva))

            datos.Comando_SP("Insert_Contratos1 @IdServicio, @AsegLicencia, @IdTipoLicenciaAseg, @Permanente, @FecAsegVencimientoLicencia, @Garantia, @IdTipoPagoBancario, @IdTipoTarjetaBancaria, @NumTarjeta4Digitos, @CodigoSeguridad, @VencimientoTarjeta, @NumAutorizacion, @RefDepositoBancario, @Monto, @TipoAuto, @IdVehiculo, @IdMarcaVehProv, @IdSubmarcaVehProv, @ModeloVehProv, @PlacasVehProv, @kilometraje, @IdNivelGasolina, @IdProveedor, @Costo, @CostoDropOff, @ImpuestoFedAero, @SeguroConductorMenor, @Precio,@ColorVeh,@NumReserva", res.DataTable)

            'Devuelve el Id del contrato que se grabo
            'res.Dato = res.DataTable.Rows(0)(2) 'Aqui devuelve el Id

            ' Graba la auditoria
            Auditoria.Registrar(usr, 59, res.Dato & "-" & res.DataTable.Rows(0)(3))
        Catch ex As Validacion_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            ''Se regresan y registran los datos del error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("CheckIn.vb", "Insert_Contratos1", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function

    Public Function Consultar_Contratos(ByVal usr As String, ByVal contrato As CBusqueda_Contrato) As Resultado
        'Se crean objetos de Resultado  2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos


        Try
            'Se crean parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@Estatus", contrato.Estatus))
            datos.sqlParameters.Add(New SqlParameter("@NumContrato", contrato.NumContrato))
            datos.sqlParameters.Add(New SqlParameter("@NumServicio", contrato.NumServicio))
            datos.sqlParameters.Add(New SqlParameter("@NumPoliza", contrato.NumPoliza))
            datos.sqlParameters.Add(New SqlParameter("@NumSiniestro", contrato.NumSiniestro))
            datos.sqlParameters.Add(New SqlParameter("@AsegNombre", contrato.AsegNombre))
            datos.sqlParameters.Add(New SqlParameter("@Placas", contrato.Placas))
            datos.sqlParameters.Add(New SqlParameter("@TipoContrato", contrato.TipoContrato))
            'datos.sqlParameters.Add(New SqlParameter("@Estatus2", contrato.Estatus))

            datos.Consulta_SP("Select_Contratos @Estatus, @NumContrato, @NumServicio, @NumPoliza, @NumSiniestro, @AsegNombre, @Placas, @TipoContrato", res.DataTable) '@Estatus2", res.DataTable)

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("CheckIn.vb", "Select_Contratos", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
        Return res
    End Function

    Public Function Consultar_Proveedores_Contratos(ByVal usr As String, ByVal contrato As CBusqueda_Contrato) As Resultado
        'Se crean objetos de Resultado  2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos


        Try
            'Se crean parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@Estatus", contrato.Estatus))
            datos.sqlParameters.Add(New SqlParameter("@NumContrato", contrato.NumContrato))
            datos.sqlParameters.Add(New SqlParameter("@NumServicio", contrato.NumServicio))
            datos.sqlParameters.Add(New SqlParameter("@NumPoliza", contrato.NumPoliza))
            datos.sqlParameters.Add(New SqlParameter("@NumSiniestro", contrato.NumSiniestro))
            datos.sqlParameters.Add(New SqlParameter("@AsegNombre", contrato.AsegNombre))
            datos.sqlParameters.Add(New SqlParameter("@Placas", contrato.Placas))
            datos.sqlParameters.Add(New SqlParameter("@TipoContrato", contrato.TipoContrato))
            datos.sqlParameters.Add(New SqlParameter("@NumReservacion", contrato.NumReservacion))
            'datos.sqlParameters.Add(New SqlParameter("@EstatusContrato", contrato.EstatusContra))

            datos.Consulta_SP("Select_Proveedores_Contratos @Estatus, @NumContrato, @NumServicio, @NumPoliza, @NumSiniestro, @AsegNombre, @Placas, @TipoContrato,@NumReservacion", res.DataTable) '@EstatusContrato", res.DataTable)

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("CheckIn.vb", "Select_Proveedores_Contratos", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
        Return res
    End Function

    Public Function Consultar_Contratos_Completos(ByVal usr As String, ByVal IdContrato As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos


        Try
            'Se crean parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@IdContrato", IdContrato))

            datos.Consulta_SP("Select_Contratos_Completos @IdContrato", res.DataTable)


        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("CheckIn.vb", "Select_Contratos_Completos", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
        Return res
    End Function

    Public Function Consultar_Contratos_Proveedores_Completos(ByVal usr As String, ByVal IdServicio As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos


        Try
            'Se crean parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@IdServicio", IdServicio))

            datos.Consulta_SP("Select_Contratos_Proveedores_Completos @IdServicio", res.DataTable)


        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("CheckIn.vb", "Select_Contratos_Proveedores_Completos", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
        Return res
    End Function

    Public Function Insertar_Contratos_Bitacora(ByVal usr As Integer, ByVal bitacora As CBitacoraContratos) As Resultado
        Dim res As New Resultado 'Objeto para resultados
        Dim datos As New ObjDatos 'Objetod para mandar llamar el ws


        Try

            datos.sqlParameters.Add(New SqlParameter("@IdContrato", bitacora.IdContrato))
            datos.sqlParameters.Add(New SqlParameter("@Bitacora", bitacora.Bitacora))
            datos.sqlParameters.Add(New SqlParameter("@IdUsuario", bitacora.IdUsuario))
            datos.Comando_SP("Insert_Contratos_Bitacora @IdContrato, @Bitacora, @IdUsuario", res.DataTable)

            ' Graba la auditoria
            Auditoria.Registrar(usr, 60, bitacora.IdContrato & "-" & res.DataTable.Rows(0)(2))
        Catch ex As Validacion_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            ''Se regresan y registran los datos del error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("CheckIn.vb", "Insert_Contratos_Bitacora", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function

    Public Function Insertar_Contratos_Bitacora2(ByVal usr As Integer, ByVal bitacora As CBitacoraServicios) As Resultado
        Dim res As New Resultado 'Objeto para resultados
        Dim datos As New ObjDatos 'Objetod para mandar llamar el ws


        Try

            datos.sqlParameters.Add(New SqlParameter("@IdContrato", bitacora.IdContrato))
            datos.sqlParameters.Add(New SqlParameter("@Bitacora", bitacora.Bitacora))
            datos.sqlParameters.Add(New SqlParameter("@IdUsuario", bitacora.IdUsuario))
            datos.Comando_SP("Insert_Contratos_Bitacora @IdContrato, @Bitacora, @IdUsuario", res.DataTable)

            ' Graba la auditoria
            Auditoria.Registrar(usr, 60, bitacora.IdContrato & "-" & res.DataTable.Rows(0)(2))
        Catch ex As Validacion_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            ''Se regresan y registran los datos del error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("CheckIn.vb", "Insert_Contratos_Bitacora", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function

    Public Function Insertar_Contratos_Bitacora_Proveedor(ByVal usr As Integer, ByVal bitacora As CBitacoraContratos) As Resultado
        Dim res As New Resultado 'Objeto para resultados
        Dim datos As New ObjDatos 'Objetod para mandar llamar el ws


        Try

            datos.sqlParameters.Add(New SqlParameter("@IdContrato", bitacora.IdContrato))
            datos.sqlParameters.Add(New SqlParameter("@Bitacora", bitacora.Bitacora))
            datos.sqlParameters.Add(New SqlParameter("@IdUsuario", bitacora.IdUsuario))
            datos.Comando_SP("Insert_Contratos_Bitacora_Proveedor @IdContrato, @Bitacora, @IdUsuario", res.DataTable)

            ' Graba la auditoria
            Auditoria.Registrar(usr, 60, bitacora.IdContrato & "-" & res.DataTable.Rows(0)(2))
        Catch ex As Validacion_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            ''Se regresan y registran los datos del error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("CheckIn.vb", "Insert_Contratos_Bitacora_Proveedor", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function

    Public Function Insertar_Contratos_Bitacora_Proveedor2(ByVal usr As Integer, ByVal bitacora As CBitacoraServicios) As Resultado
        Dim res As New Resultado 'Objeto para resultados
        Dim datos As New ObjDatos 'Objetod para mandar llamar el ws


        Try

            datos.sqlParameters.Add(New SqlParameter("@IdContrato", bitacora.IdContrato))
            datos.sqlParameters.Add(New SqlParameter("@Bitacora", bitacora.Bitacora))
            datos.sqlParameters.Add(New SqlParameter("@IdUsuario", bitacora.IdUsuario))
            datos.Comando_SP("Insert_Contratos_Bitacora_Proveedor @IdContrato, @Bitacora, @IdUsuario", res.DataTable)

            ' Graba la auditoria
            Auditoria.Registrar(usr, 60, bitacora.IdContrato & "-" & res.DataTable.Rows(0)(2))
        Catch ex As Validacion_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            ''Se regresan y registran los datos del error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("CheckIn.vb", "Insert_Contratos_Bitacora_Proveedor", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function

    Public Function Consultar_Contratos_Bitacora(ByVal usr As String, ByVal IdContrato As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos


        Try

            'Se crean parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@IdContrato", IdContrato))

            datos.Consulta_SP("Select_Contratos_Bitacora @IdContrato", res.DataTable)


        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("CheckIn.vb", "Select_Contratos_Bitacora", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
        Return res
    End Function

    Public Function Consultar_PDF_Condiciones_Comodato(ByVal usr As String, ByVal IdContrato As String) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos


        Try
            'Se crean parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@IdContrato", IdContrato))

            datos.Consulta_SP("Select_PDF_Condiciones_Comodato @IdContrato", res.DataTable)


        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("CheckIn.vb", "Select_PDF_Condiciones_Comodato", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
        Return res
    End Function

    Public Function Insertar_Contratos_Cambio_Auto(ByVal usr As Integer, ByVal cambio As CContrato_CambioAuto) As Resultado
        Dim res As New Resultado 'Objeto para resultados
        Dim datos As New ObjDatos 'Objetod para mandar llamar el ws

        Try
            ' Valida que sea un dato correcto
            'If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(cambio.PlacasVehProv) Then
            '    Throw New Validacion_Exception("Placas del Vehículo")
            'End If

            'Se crea parámetro y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@IdContrato", cambio.IdContrato))
            datos.sqlParameters.Add(New SqlParameter("@KmEntrada", cambio.KmEntrada))
            datos.sqlParameters.Add(New SqlParameter("@IdNivelGasolinaEntrada", cambio.IdNivelGasolinaEntrada))
            datos.sqlParameters.Add(New SqlParameter("@IdMotivoCambioAuto", cambio.IdMotivoCambioAuto))
            datos.sqlParameters.Add(New SqlParameter("@TipoAuto", cambio.TipoAuto))
            datos.sqlParameters.Add(New SqlParameter("@IdVehiculo", cambio.IdVehiculo))
            datos.sqlParameters.Add(New SqlParameter("@IdMarcaVehProv", cambio.IdMarcaVehProv))
            datos.sqlParameters.Add(New SqlParameter("@IdSubmarcaVehProv", cambio.IdSubmarcaVehProv))
            datos.sqlParameters.Add(New SqlParameter("@ModeloVehProv", cambio.ModeloVehProv))
            datos.sqlParameters.Add(New SqlParameter("@PlacasVehProv", cambio.PlacasVehProv))
            datos.sqlParameters.Add(New SqlParameter("@IdProveedor", cambio.IdProveedor))
            datos.sqlParameters.Add(New SqlParameter("@kilometraje", cambio.Kilometraje))
            datos.sqlParameters.Add(New SqlParameter("@IdNivelGasolina", cambio.IdNivelGasolina))
            datos.sqlParameters.Add(New SqlParameter("@colorVeh", cambio.ColorVeh))

            datos.Comando_SP("Insert_CambioVehiculoContrato @IdContrato, @KmEntrada, @IdNivelGasolinaEntrada,  @TipoAuto, @IdVehiculo, @IdMarcaVehProv, @IdSubmarcaVehProv, @ModeloVehProv, @PlacasVehProv, @IdProveedor, @kilometraje, @IdNivelGasolina, @IdMotivoCambioAuto, @colorVeh", res.DataTable)

            res.Dato = res.DataTable.Rows(0)(2) 'Aqui devuelve el Consec

            ' Graba la auditoria
            Auditoria.Registrar(usr, 61, cambio.IdContrato & "-" & res.Dato)
        Catch ex As Validacion_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            ''Se regresan y registran los datos del error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("CheckIn.vb", "Insert_CambiosVehiculos", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function

    Public Function Consultar_PDF_Cambio_de_Unidad(ByVal usr As String, ByVal IdContrato As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos


        Try
            'Se crean parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@IdContrato", IdContrato))

            datos.Consulta_SP("Select_PDF_Cambio_de_Unidad @IdContrato", res.DataTable)


        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("CheckIn.vb", "Select_PDF_Cambio_de_Unidad", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
        Return res
    End Function

    'Isra

    Public Function Consultar_ContratosCambiosUnidad_Proveedor(ByVal usr As String, ByVal camb As CBusqueda_Vehiculo) As Resultado

        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos


        Try
            'Se crean parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@IdContrato", camb.IdContrato))

            datos.Consulta_SP("Select_ContratosCambiosUnidad_Proveedor @IdContrato", res.DataTable)


        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("CheckIn.vb", "Select_ContratosCambiosUnidad_Proveedor", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
        Return res
    End Function

    Public Function Consultar_Cambios_de_Unidad(ByVal usr As String, ByVal camb As CBusqueda_Vehiculo) As Resultado

        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos


        Try
            'Se crean parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@IdContrato", camb.IdContrato))

            datos.Consulta_SP("Select_ContratosCambiosUnidad @IdContrato", res.DataTable)


        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("CheckIn.vb", "Select_ContratosCambiosUnidad", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
        Return res
    End Function
    'Termina Isra

#End Region

#Region "Salidas Improductivas"

    Public Function Insertar_SalidasImproductivas(usr As Integer, salida As CSalidaImproductiva) As Resultado
        Dim res As New Resultado 'Objeto para resultados
        Dim datos As New ObjDatos 'Objetod para mandar llamar el ws

        Try
            ' Valida que sea un dato correcto

            'Se crea parámetro y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@IdVehiculo", salida.IdVehiculo))
            datos.sqlParameters.Add(New SqlParameter("@Kilometraje", salida.Kilometraje))
            datos.sqlParameters.Add(New SqlParameter("@IdNivelGasolina", salida.IdNivelGasolina))
            datos.sqlParameters.Add(New SqlParameter("@IdMotivo", salida.IdMotivoSalida))
            datos.sqlParameters.Add(New SqlParameter("@PersonaAsignada", salida.PersonaAsignada))
            datos.sqlParameters.Add(New SqlParameter("@Comentarios", salida.Comentarios))

            datos.Comando_SP("Insert_SalidasImproductivas @IdVehiculo, @Kilometraje, @IdNivelGasolina, @IdMotivo, @PersonaAsignada, @Comentarios", res.DataTable)

            'Devuelve el Consec del registro que se grabo
            res.Dato = res.DataTable.Rows(0)(2) 'Aqui devuelve el Consec

            ' Graba la auditoria
            Auditoria.Registrar(usr, 62, salida.IdVehiculo & "-" & res.Dato)
        Catch ex As Validacion_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            ''Se regresan y registran los datos del error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("CheckIn.vb", "Insert_SalidasImproductivas", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function


    Public Function Consultar_SalidasImproductivas(usr As String, salida As CBusqueda_SalidaImproductiva) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            'Se crean parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@TipoConsulta", salida.TipoConsulta))
            datos.sqlParameters.Add(New SqlParameter("@NumSalida", salida.NumSalida))
            datos.sqlParameters.Add(New SqlParameter("@Placas", salida.Placas))
            datos.sqlParameters.Add(New SqlParameter("@FecIni", salida.FecIni))
            datos.sqlParameters.Add(New SqlParameter("@FecFin", salida.FecFin))

            datos.Consulta_SP("Select_SalidasImproductivas2 @TipoConsulta, @NumSalida, @Placas, @FecIni, @FecFin", res.DataTable)

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("CheckIn.vb", "Select_SalidasImproductivas2", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
        Return res
    End Function

    Public Function Consultar_SalidasImproductivas_Completas(usr As String, IdVehiculo As Integer, ConsecSalida As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            'Se crean parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@IdVehiculo", IdVehiculo))
            datos.sqlParameters.Add(New SqlParameter("@ConsecSalida", ConsecSalida))

            datos.Consulta_SP("Select_SalidasImproductivas_Completas @IdVehiculo, @ConsecSalida", res.DataTable)

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("CheckIn.vb", "Select_SalidasImproductivas_Completas", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
        Return res
    End Function

	Public Function Consultar_PDF_Condiciones_Comodato_Proveedor(ByVal usr As String, ByVal IdServicio As String) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos


        Try
            'Se crean parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@IdServicio", IdServicio))

            datos.Consulta_SP("Select_PDF_Condiciones_Comodato_Proveedor @IdServicio", res.DataTable)


        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("CheckIn.vb", "Select_PDF_Condiciones_Comodato_Proveedor", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
        Return res
    End Function
	
	Public Function Consultar_PDF_Cambio_de_Unidad_Proveedor(ByVal usr As String, ByVal IdServicio As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos


        Try
            'Se crean parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@IdServicio", IdServicio))

            datos.Consulta_SP("Select_PDF_Cambio_de_Unidad_Proveedor @IdServicio", res.DataTable)


        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("CheckIn.vb", "Select_PDF_Cambio_de_Unidad_Proveedor", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
        Return res
    End Function

    Public Function Consulta_Municipio(ByVal vehIdMunicipio As Integer) As Resultado
        Dim res As New Resultado 'Objeto para resultados
        Dim datos As New ObjDatos 'Objetod para mandar llamar el ws
        Dim idVehAsis As String = ""
        Try


            'Se crea parámetro y se manda llamar el ws
            'exec Select_MunicipiosAsis @IdMpio = 1

            datos.sqlParameters.Add(New SqlParameter("@IdMpio", vehIdMunicipio))

            datos.Consulta_SP("Select_MunicipiosAsis @IdMpio", res.DataTable)

            ' Verifica si todo salió bien:
            'res.Dato =  'Aqui devuelve el Id

        Catch ex As Validacion_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

            'Catch ex As AccesoDatos_Exception
            '    'Se regresan y registran los datos de error
            '    res.Estatus = Estatus.Error
            '    res.ErrorDesc = ex.Message

        Catch ex As Exception
            ''Se regresan y registran los datos del error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("CheckIn.vb", "Select_MunicipiosAsis", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function

#End Region

End Class
