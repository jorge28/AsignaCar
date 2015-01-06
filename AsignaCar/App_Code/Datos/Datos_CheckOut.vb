Imports Microsoft.VisualBasic
Imports Acceso_a_Datos
Imports System.Data
Imports System.Data.SqlClient

Public Class Datos_CheckOut

#Region "Salidas Improductivas"

    Public Function Actualizar_SalidasImproductivas_Cierre(usr As Integer, salida As CSalidaImproductiva_Cierre) As Resultado
        Dim res As New Resultado 'Objeto para resultados
        Dim datos As New ObjDatos 'Objetod para mandar llamar el ws

        Try
            ' Valida que sea un dato correcto

            'Se crea parámetro y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@IdVehiculo", salida.IdVehiculo))
            datos.sqlParameters.Add(New SqlParameter("@Consec", salida.Consec))
            datos.sqlParameters.Add(New SqlParameter("@Kilometraje", salida.Kilometraje))
            datos.sqlParameters.Add(New SqlParameter("@IdNivelGasolina", salida.IdNivelGasolina))
            datos.sqlParameters.Add(New SqlParameter("@Comentarios", salida.Comentarios))

            datos.Comando_SP("Update_SalidasImproductivas_Cierre @IdVehiculo, @Consec, @Kilometraje, @IdNivelGasolina, @Comentarios", res.DataTable)

            ' Graba la auditoria
            Auditoria.Registrar(usr, 65, salida.IdVehiculo & "-" & salida.Consec)
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
            Logs.LogError("CheckOut.vb", "Update_SalidasImproductivas", ex.Message, ex.StackTrace)
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
            Logs.LogError("CheckOut.vb", "Select_SalidasImproductivas2", ex.Message, ex.StackTrace)
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
            Logs.LogError("CheckOut.vb", "Select_SalidasImproductivas_Completas", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
        Return res
    End Function

#End Region

#Region "Servicios"

    Public Function ConsultarAseguradoras(ByVal usr As Integer, ByVal id As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            'Se crean los parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@Id", id))
            datos.Consulta_SP("Select_Aseguradoras @Id", res.DataTable)

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("Catalogos.vb", "Select_Aseguradoras", ex.Message, ex.StackTrace)
        End Try
        Return res

    End Function

    Public Function ConsultarProveedores(ByVal usr As Integer, ByVal id As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            'Se crean los parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@Id", id))
            datos.Consulta_SP("Select_Proveedores_Unicos @Id", res.DataTable)

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("Catalogos.vb", "Select_Proveedores_Unicos", ex.Message, ex.StackTrace)
        End Try
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

    Public Function Consultar_Servicios(ByVal usr As String, ByVal servicio As CBusqueda_Servicio2) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos


        Try
            'Se crean parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@TipoConsulta", servicio.TipoConsulta))

            datos.sqlParameters.Add(New SqlParameter("@NumServicio", servicio.NumServicio))
            datos.sqlParameters.Add(New SqlParameter("@NumSiniestro", servicio.NumSiniestro))
            datos.sqlParameters.Add(New SqlParameter("@NumPoliza", servicio.NumPoliza))
            datos.sqlParameters.Add(New SqlParameter("@Aseguradora", servicio.NombreAseguradora))
            datos.sqlParameters.Add(New SqlParameter("@NombreAsegurado", servicio.AsegNombre))
            datos.sqlParameters.Add(New SqlParameter("@Placas", servicio.Placas))
            datos.sqlParameters.Add(New SqlParameter("@Proveedor", servicio.Proveedor))
            datos.sqlParameters.Add(New SqlParameter("@NumContrato", servicio.NumContrato))

            datos.Consulta_SP("Select_Servicios2 @TipoConsulta, @NumServicio, @NumSiniestro, @NumPoliza, @Aseguradora, @NombreAsegurado, @Placas,@Proveedor,@NumContrato", res.DataTable)


        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("CheckOut.vb", "Select_Servicios2", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
        Return res

    End Function

    Public Function Consultar_Servicios_pagos(ByVal usr As String, ByVal servicio As CBusqueda_Servicio_pagos) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos


        Try
            'Se crean parámetros y se manda llamar el ws

            datos.sqlParameters.Add(New SqlParameter("@NumServicio", servicio.NumServicio))
            datos.sqlParameters.Add(New SqlParameter("@NumSiniestro", servicio.NumSiniestro))
            datos.sqlParameters.Add(New SqlParameter("@NumPoliza", servicio.NumPoliza))
            datos.sqlParameters.Add(New SqlParameter("@NombreAseguradora", servicio.NombreAseguradora))
            datos.sqlParameters.Add(New SqlParameter("@AsegNombre", servicio.AsegNombre))
            datos.sqlParameters.Add(New SqlParameter("@Placas", servicio.Placas))
            datos.sqlParameters.Add(New SqlParameter("@Proveedor", servicio.Proveedor))
            datos.sqlParameters.Add(New SqlParameter("@Proceso", servicio.Proceso))

            datos.Consulta_SP("Select_Servicios_Pagos @NumServicio, @NumSiniestro, @NumPoliza, @NombreAseguradora, @AsegNombre, @Placas,@Proveedor,@Proceso", res.DataTable)


        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("CheckOut.vb", "Select_Servicios_pagos", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
        Return res
    End Function

    Public Function Consultar_Servicios_Completos(ByVal usr As String, ByVal IdServicio As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos


        Try
            'Se crean parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@IdServicio", IdServicio))

            'datos.Consulta_SP("Select_Servicios_Proveedores_Completos2 @IdServicio", res.DataTable)
            datos.Consulta_SP("Select_Servicios_Completos2 @IdServicio", res.DataTable)


        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("CheckOut.vb", "Select_Servicios_Completos2", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
        Return res
    End Function

    Public Function Consultar_Dias_Extension(ByVal usr As String, ByVal IdContrato As String) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos


        Try
            'Se crean parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@IdContrato", IdContrato))

            datos.Consulta_SP("Select_Dias_Extension @IdContrato", res.DataTable)


        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("CheckOut.vb", "Select_Dias_Extension", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
        Return res
    End Function

    Public Function Consultar_Servicios_Proveedores_Completos(ByVal usr As String, ByVal IdServicio As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos


        Try
            'Se crean parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@IdServicio", IdServicio))

            datos.Consulta_SP("Select_Servicios_Proveedores_Completos2 @IdServicio", res.DataTable)


        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("CheckOut.vb", "Select_Servicios_Proveedores_Completos2", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
        Return res
    End Function

    Public Function Actualizar_Fechas_Servicio(ByVal usr As String, ByVal actu As CServicio) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos


        Try
            'Se crean parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@IdServicio", actu.IdServicio))
            datos.sqlParameters.Add(New SqlParameter("@FechaDevoReal", actu.NewFecDevoReal))
            datos.sqlParameters.Add(New SqlParameter("@DiasUsados", actu.diasUsado))
            datos.sqlParameters.Add(New SqlParameter("@DiasAdicionales", actu.diasAdicionales))
            datos.sqlParameters.Add(New SqlParameter("@CostoDiasAdicionales", actu.costoDiasAdicionales))
            datos.Consulta_SP("Update_Fechas_Servicio @IdServicio, @FechaDevoReal,@DiasUsados,@DiasAdicionales,@CostoDiasAdicionales", res.DataTable)

            'datos.sqlParameters.Add(New SqlParameter("@FechaAsigna", actu.NewFecAsignacion))
            'datos.sqlParameters.Add(New SqlParameter("@FechaTermina", actu.NewFecTerminacion))

            'datos.Consulta_SP("Update_Fechas_Servicio @IdServicio, @FechaAsigna, @FechaTermina", res.DataTable)


        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("CheckOut.vb", "Update_Fechas_Servicio", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
        Return res
    End Function
#End Region

#Region "Facturas"

    Public Function Insertar_Facturas(usr As Integer, factura As CFactura) As Resultado
        Dim res As New Resultado 'Objeto para resultados
        Dim datos As New ObjDatos 'Objetod para mandar llamar el ws


        Try
            ' Valida que sea un dato correcto
            If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(factura.RFC) Then
                Throw New Validacion_Exception("RFC")
            End If

            If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(factura.Nombre) Then
                Throw New Validacion_Exception("Nombre")
            End If

            'If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(factura.Calle) Then
            '    Throw New Validacion_Exception("Calle")
            'End If

            'If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(factura.NoExt) Then
            '    Throw New Validacion_Exception("Número exterior")
            'End If

            'If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(factura.NoInt) Then
            '    Throw New Validacion_Exception("Número interior")
            'End If

            'If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(factura.Colonia) Then
            '    Throw New Validacion_Exception("Colonia")
            'End If

            'Se crea parámetro y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@IdServicio", factura.IdServicio))
            datos.sqlParameters.Add(New SqlParameter("@Nombre", factura.Nombre))
            datos.sqlParameters.Add(New SqlParameter("@RFC", factura.RFC))
            datos.sqlParameters.Add(New SqlParameter("@Calle", factura.Calle))
            datos.sqlParameters.Add(New SqlParameter("@NoExt", factura.NoExt))
            datos.sqlParameters.Add(New SqlParameter("@NoInt", factura.NoInt))
            datos.sqlParameters.Add(New SqlParameter("@Colonia", factura.Colonia))
            datos.sqlParameters.Add(New SqlParameter("@IdEstado", factura.IdEstado))
            datos.sqlParameters.Add(New SqlParameter("@IdMunicipio", factura.IdMunicipio))
            datos.sqlParameters.Add(New SqlParameter("@Importe", factura.Importe))
            datos.sqlParameters.Add(New SqlParameter("@IVA", factura.IVA))

            datos.Comando_SP("Insert_Facturas @IdServicio, @Nombre, @RFC, @Calle, @NoExt, @NoInt, @Colonia, @IdEstado, @IdMunicipio, @Importe, @IVA", res.DataTable)

            ' Verifica si todo salió bien:
            res.Dato = res.DataTable.Rows(0)(2) 'Aqui devuelve el Id

            ' Graba la auditoria
            Auditoria.Registrar(usr, 67, res.Dato)
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
            Logs.LogError("CheckOut.vb", "Insert_Facturas", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function
#End Region

#Region "Contratos"

    Public Function Consultar_Contratos_Proveedor(ByVal usr As String, ByVal contrato As CBusqueda_Contrato2) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos


        Try
            'Se crean parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@TipoConsulta", contrato.TipoConsulta))
            datos.sqlParameters.Add(New SqlParameter("@NumServicio", contrato.NumServicio))
            datos.sqlParameters.Add(New SqlParameter("@NumSiniestro", contrato.NumSiniestro))
            datos.sqlParameters.Add(New SqlParameter("@NumPoliza", contrato.NumPoliza))
            datos.sqlParameters.Add(New SqlParameter("@NumContrato", contrato.NumContrato))
            datos.sqlParameters.Add(New SqlParameter("@NombreAsegurado", contrato.AsegNombre))
            datos.sqlParameters.Add(New SqlParameter("@Placas", contrato.Placas))
            datos.sqlParameters.Add(New SqlParameter("@Estatus", contrato.Estatus))
            datos.sqlParameters.Add(New SqlParameter("@Fecha1", contrato.Fecha1))
            datos.sqlParameters.Add(New SqlParameter("@Fecha2", contrato.Fecha2))
            datos.sqlParameters.Add(New SqlParameter("@Fecha3", contrato.Fecha3))

            datos.Consulta_SP("Select_Proveedores_Contratos2 @TipoConsulta, @NumContrato, @NumServicio, @NumPoliza, @NumSiniestro, @NombreAsegurado, @Placas, @Estatus, @Fecha1, @Fecha2,@Fecha3", res.DataTable)

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("CheckOut.vb", "Select_Proveedores_Contratos2", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
        Return res
    End Function

    Public Function Consultar_Contratos(ByVal usr As String, ByVal contrato As CBusqueda_Contrato2) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos


        Try
            'Se crean parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@TipoConsulta", contrato.TipoConsulta))
            datos.sqlParameters.Add(New SqlParameter("@NumServicio", contrato.NumServicio))
            datos.sqlParameters.Add(New SqlParameter("@NumSiniestro", contrato.NumSiniestro))
            datos.sqlParameters.Add(New SqlParameter("@NumPoliza", contrato.NumPoliza))
            datos.sqlParameters.Add(New SqlParameter("@NumContrato", contrato.NumContrato))
            datos.sqlParameters.Add(New SqlParameter("@NombreAsegurado", contrato.AsegNombre))
            datos.sqlParameters.Add(New SqlParameter("@Placas", contrato.Placas))
            datos.sqlParameters.Add(New SqlParameter("@Estatus", contrato.Estatus))
            datos.sqlParameters.Add(New SqlParameter("@Fecha1", contrato.Fecha1))
            datos.sqlParameters.Add(New SqlParameter("@Fecha2", contrato.Fecha2))
            datos.sqlParameters.Add(New SqlParameter("@Fecha3", contrato.Fecha3))

            datos.Consulta_SP("Select_Contratos2 @TipoConsulta, @NumContrato, @NumServicio, @NumPoliza, @NumSiniestro, @NombreAsegurado, @Placas, @Estatus, @Fecha1, @Fecha2,@Fecha3", res.DataTable)

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("CheckOut.vb", "Select_Contratos2", ex.Message, ex.StackTrace)
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

            datos.Consulta_SP("Select_Contratos_Proveedores_Completos2 @IdServicio", res.DataTable)


        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("CheckOut.vb", "Select_Contratos_Proveedores_Completos2", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
        Return res
    End Function

    Public Function Consultar_Contratos_Completos(usr As String, IdContrato As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos


        Try
            'Se crean parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@IdContrato", IdContrato))

            datos.Consulta_SP("Select_Contratos_Completos2 @IdContrato", res.DataTable)


        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("CheckOut.vb", "Select_Contratos_Completos2", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
        Return res
    End Function

    Public Function Insertar_Contratos_Extension(usr As Integer, contrato As CContrato_Extension) As Resultado
        Dim res As New Resultado 'Objeto para resultados
        Dim datos As New ObjDatos 'Objetod para mandar llamar el ws

        Try
            ' Valida que sea un dato correcto
            If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(contrato.RefBancaria) Then
                Throw New Validacion_Exception("Referencia Bancaria")
            End If

            'Se crea parámetro y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@IdContrato", contrato.IdContrato))
            datos.sqlParameters.Add(New SqlParameter("@FecCierre", contrato.FecCierre))
            datos.sqlParameters.Add(New SqlParameter("@IdTipoPagoBancario", contrato.IdTipoPagoBancario))
            datos.sqlParameters.Add(New SqlParameter("@RefBancaria", contrato.RefBancaria))
            datos.sqlParameters.Add(New SqlParameter("@Importe", contrato.Importe))
            datos.sqlParameters.Add(New SqlParameter("@TipoAuto", contrato.TipoAuto))
            datos.sqlParameters.Add(New SqlParameter("@DiasExtension", contrato.DiasExtension))

            datos.Comando_SP("Insert_Contratos_Extension @IdContrato, @FecCierre, @IdTipoPagoBancario, @RefBancaria, @Importe,@TipoAuto,@DiasExtension", res.DataTable)

            ' Graba la auditoria
            Auditoria.Registrar(usr, 68, contrato.IdContrato & "-" & res.DataTable.Rows(0)(2))
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
            Logs.LogError("CheckOut.vb", "Insert_Contratos_Extension", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function

    Public Function Consulta_Contratos_Extension(usr As String, IdContrato As Integer, Consec As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos


        Try
            'Se crean parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@IdContrato", IdContrato))
            datos.sqlParameters.Add(New SqlParameter("@Consec", Consec))

            datos.Consulta_SP("Select_Extension_Autorizacion @IdContrato, @Consec", res.DataTable)

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("CheckOut.vb", "Select_Contratos_Completos2", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
        Return res
    End Function

    Public Function Actualizar_Contratos_Extension(usr As Integer, contrato As CContrato_Autorizacion_Extension, Consec As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try

            'Se crea parámetro y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@IdContrato", contrato.IdContrato))
            datos.sqlParameters.Add(New SqlParameter("@FecCierre", contrato.FecCierre))
            datos.sqlParameters.Add(New SqlParameter("@Consec", contrato.consec))
            datos.sqlParameters.Add(New SqlParameter("@Autorizar", contrato.Autorizacion))
            datos.sqlParameters.Add(New SqlParameter("@Comentarios", contrato.Comentarios))


            datos.Comando_SP("Update_Contratos_Extension @IdContrato, @FecCierre, @Consec, @Autorizar, @Comentarios", res.DataTable)

            ' Graba la auditoria
            Auditoria.Registrar(usr, 66, contrato.IdContrato)
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
            Logs.LogError("CheckOut.vb", "Update_Contratos_Cierre", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
        Return res
    End Function

    Public Function Consultar_PDF_Extension_Comodato(usr As String, IdContrato As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos


        Try
            'Se crean parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@IdContrato", IdContrato))

            datos.Consulta_SP("Select_PDF_Extension_Comodato @IdContrato", res.DataTable)


        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("CheckOut.vb", "Select_PDF_Extension_Comodato", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
        Return res
    End Function

    Public Function Actualizar_Contratos_Cierre(usr As Integer, cierre As CContrato_Cierre) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            ' Valida que sea un dato correcto

            If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(cierre.RefDepositoBancario) Then
                Throw New Validacion_Exception("Número de Referencia")
            End If

            ' llave
            datos.sqlParameters.Add(New SqlParameter("@IdContrato", cierre.IdContrato))
            datos.sqlParameters.Add(New SqlParameter("@IdServicio", cierre.IdServicio))

            'ACTIVACION
            datos.sqlParameters.Add(New SqlParameter("@CostoDaños", cierre.CostoDaños))
            datos.sqlParameters.Add(New SqlParameter("@CostoDiasAdicionales", cierre.CostoDiasAdicionales))
            datos.sqlParameters.Add(New SqlParameter("@CostoGasolina", cierre.CostoGasolina))
            datos.sqlParameters.Add(New SqlParameter("@DiasAdicionales", cierre.DiasAdicionales))
            datos.sqlParameters.Add(New SqlParameter("@DiasUsados", cierre.DiasUsados))
            datos.sqlParameters.Add(New SqlParameter("@IdNivelGasolina", cierre.IdNivelGasolina))
            datos.sqlParameters.Add(New SqlParameter("@IdTipoPagoBancario", cierre.IdTipoPagoBancario))
            datos.sqlParameters.Add(New SqlParameter("@Kilometraje", cierre.Kilometraje))
            datos.sqlParameters.Add(New SqlParameter("@NumTarjeta4Digitos", cierre.NumTarjeta4Digitos))
            datos.sqlParameters.Add(New SqlParameter("@RefDepositoBancario", cierre.RefDepositoBancario))


            datos.Comando_SP("Update_Contratos_Cierre @IdContrato, @IdServicio, @IdNivelGasolina, @Kilometraje, @CostoDaños, @CostoGasolina, @DiasUsados, @DiasAdicionales, @CostoDiasAdicionales, @IdTipoPagoBancario, @NumTarjeta4Digitos, @RefDepositoBancario", res.DataTable)

            ' Graba la auditoria
            Auditoria.Registrar(usr, 66, cierre.IdContrato)
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
            Logs.LogError("CheckOut.vb", "Update_Contratos_Cierre", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
        Return res
    End Function

    Public Function Actualizar_Contratos_Cierre_Proveedor(ByVal usr As Integer, ByVal cierre As CContrato_Cierre) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            ' Valida que sea un dato correcto

            If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(cierre.RefDepositoBancario) Then
                Throw New Validacion_Exception("Número de Referencia")
            End If

            ' llave
            datos.sqlParameters.Add(New SqlParameter("@IdContrato", cierre.IdContrato))
            datos.sqlParameters.Add(New SqlParameter("@IdServicio", cierre.IdServicio))

            'ACTIVACION
            datos.sqlParameters.Add(New SqlParameter("@CostoDaños", cierre.CostoDaños))
            datos.sqlParameters.Add(New SqlParameter("@CostoDiasAdicionales", cierre.CostoDiasAdicionales))
            datos.sqlParameters.Add(New SqlParameter("@CostoGasolina", cierre.CostoGasolina))
            datos.sqlParameters.Add(New SqlParameter("@DiasAdicionales", cierre.DiasAdicionales))
            datos.sqlParameters.Add(New SqlParameter("@DiasUsados", cierre.DiasUsados))
            datos.sqlParameters.Add(New SqlParameter("@IdNivelGasolina", cierre.IdNivelGasolina))
            datos.sqlParameters.Add(New SqlParameter("@IdTipoPagoBancario", cierre.IdTipoPagoBancario))
            datos.sqlParameters.Add(New SqlParameter("@Kilometraje", cierre.Kilometraje))
            datos.sqlParameters.Add(New SqlParameter("@NumTarjeta4Digitos", cierre.NumTarjeta4Digitos))
            datos.sqlParameters.Add(New SqlParameter("@RefDepositoBancario", cierre.RefDepositoBancario))


            datos.Comando_SP("Update_Contratos_Cierre_Proveedor @IdContrato, @IdServicio, @IdNivelGasolina, @Kilometraje, @CostoDaños, @CostoGasolina, @DiasUsados, @DiasAdicionales, @CostoDiasAdicionales, @IdTipoPagoBancario, @NumTarjeta4Digitos, @RefDepositoBancario", res.DataTable)

            ' Graba la auditoria
            Auditoria.Registrar(usr, 66, cierre.IdContrato)
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
            Logs.LogError("CheckOut.vb", "Update_Contratos_Cierre_Proveedor", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
        Return res
    End Function
#End Region

#Region "Encuesta de satisfaccion"

    Public Function Grabar_Encuesta_Satisfaccion(usr As Integer, encuesta As CEncuesta_Satisfaccion) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            ' Inicia la transacción
            datos.BeginTransaction()

            ' Después se graba cada uno de los registros
            For i As Integer = 0 To encuesta.IdPreguntas.Length - 1
                datos.sqlParameters.Add(New SqlParameter("@IdServicio", encuesta.IdServicio))
                datos.sqlParameters.Add(New SqlParameter("@IdPregunta", encuesta.IdPreguntas(i)))
                datos.sqlParameters.Add(New SqlParameter("@IdRespuesta", encuesta.IdRespuestas(i)))
                datos.Comando_SP_Transaccion("Insert_Encuesta_Satisfaccion @IdServicio, @IdPregunta, @IdRespuesta", res.DataTable)
            Next

            ' Hace el commit 
            datos.Commit()

            ' Graba la auditoria
            Auditoria.Registrar(usr, 69, encuesta.IdServicio)

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

            ' Hace el rollback
            If datos.TransaccionIniciada Then datos.Rollback()

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("CheckOut.vb", "Insert_Encuesta_Satisfaccion", ex.Message, ex.StackTrace)

            ' Hace el rollback
            If datos.TransaccionIniciada Then datos.Rollback()
        End Try
        'Regresa Resultado2
        Return res
    End Function
#End Region

#Region "Reembolsos"

    Public Function Insertar_Actualizar_Reembolso(usr As Integer, reembolso As CReembolso) As Resultado ''jrad marzo-2013
        Dim res As New Resultado 'Objeto para resultados
        Dim datos As New ObjDatos 'Objetod para mandar llamar el ws

        Try

            'Se crea parámetro y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@CargoAccesorios", reembolso.CargoAccesorios))
            datos.sqlParameters.Add(New SqlParameter("@CargoAirportFee", reembolso.CargoAiportfee))
            datos.sqlParameters.Add(New SqlParameter("@CargoConductor", reembolso.CargoConductor))
            datos.sqlParameters.Add(New SqlParameter("@CargoDanos", reembolso.Cargodanos))
            datos.sqlParameters.Add(New SqlParameter("@CargoDias", reembolso.CargoDias))
            datos.sqlParameters.Add(New SqlParameter("@CargoDropOff", reembolso.CargoDropoff))
            datos.sqlParameters.Add(New SqlParameter("@CargoGasolina", reembolso.CargoGasolina))
            datos.sqlParameters.Add(New SqlParameter("@CargoMultas", reembolso.Cargomultas))
            datos.sqlParameters.Add(New SqlParameter("@GastoAccesorios", reembolso.GastoAccesorios))
            datos.sqlParameters.Add(New SqlParameter("@GastoAirportFee", reembolso.GastoAiportfee))
            datos.sqlParameters.Add(New SqlParameter("@GastoConductor", reembolso.GastoConductor))
            datos.sqlParameters.Add(New SqlParameter("@GastoDanos", reembolso.Gastodanos))
            datos.sqlParameters.Add(New SqlParameter("@GastoDias", reembolso.GastoDias))
            datos.sqlParameters.Add(New SqlParameter("@GastoDropOff", reembolso.CargoDropoff))
            datos.sqlParameters.Add(New SqlParameter("@GastoGasolina", reembolso.GastoGasolina))
            datos.sqlParameters.Add(New SqlParameter("@GastoMultas", reembolso.Gastomultas))


            datos.sqlParameters.Add(New SqlParameter("@IdServicio", reembolso.IdServicio))
            datos.sqlParameters.Add(New SqlParameter("@IdUsuarioSolicitaReembolso", usr))

            datos.sqlParameters.Add(New SqlParameter("@FormaPago", reembolso.FormaPago))
            datos.sqlParameters.Add(New SqlParameter("@Banco", reembolso.Banco))
            datos.sqlParameters.Add(New SqlParameter("@Sucursal", reembolso.Sucursal))
            datos.sqlParameters.Add(New SqlParameter("@Cuenta", reembolso.Cuenta))
            datos.sqlParameters.Add(New SqlParameter("@Afavor", reembolso.Afavor))
            datos.sqlParameters.Add(New SqlParameter("@Beneficiario", reembolso.Beneficiario))
            datos.sqlParameters.Add(New SqlParameter("@totalReembolso", reembolso.tOTAL))



            datos.Comando_SP("Insert_Update_Reembolsos_Garantias  @IdServicio, @GastoDias, @GastoGasolina, @GastoAccesorios, @GastoDanos, @GastoMultas, @GastoDropOff, @GastoAirportFee, @GastoConductor,@CargoDias, @CargoGasolina, @CargoAccesorios,@CargoDanos,@CargoMultas,@CargoDropOff,@CargoAirportFee,@CargoConductor,@IdUsuarioSolicitaReembolso,@FormaPago, @Banco, @Cuenta, @Sucursal,@Afavor, @Beneficiario,@totalReembolso", res.DataTable)

            res.Dato = res.DataTable.Rows(0)(2) ' Id del reembolso generado

            ' Graba la auditoria
            Auditoria.Registrar(usr, 70, reembolso.IdServicio)
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
            Logs.LogError("CheckOut.vb", "Insert_Update_Reembolsos_Garantias", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function

    Public Function Actualizar_Reembolso_Autorizacion(usr As Integer, reembolsoautorizacion As CReembolsoAutorizacion) As Resultado 'jrad marzo-2013
        Dim res As New Resultado 'Objeto para resultados
        Dim datos As New ObjDatos 'Objetod para mandar llamar el ws

        Try
            ' Valida que sea un dato correcto

            'Se crea parámetro y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@IdServicio", reembolsoautorizacion.IdServicio))
            datos.sqlParameters.Add(New SqlParameter("@StatusReembolso", reembolsoautorizacion.StatusReembolso))

            datos.sqlParameters.Add(New SqlParameter("@Observaciones", reembolsoautorizacion.Observaciones))
            datos.sqlParameters.Add(New SqlParameter("@IdUsuarioAutorizo", reembolsoautorizacion.user))



            datos.Comando_SP("Update_Reembolsos_Autorizacion @IdServicio, @StatusReembolso, @Observaciones,@IdUsuarioAutorizo", res.DataTable)

            ' Graba la auditoria
            Auditoria.Registrar(usr, 71, reembolsoautorizacion.IdServicio)
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
            Logs.LogError("CheckOut.vb", "Update_Reembolsos_Autorizacion", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function

    Public Function Actualizar_Reembolso_Contabilidad(ByVal usr As Integer, ByVal reembolsocontabilidad As CReembolsoContabilidad) As Resultado 'jrad marzo-2013
        Dim res As New Resultado 'Objeto para resultados
        Dim datos As New ObjDatos 'Objetod para mandar llamar el ws

        Try
            ' Valida que sea un dato correcto

            'Se crea parámetro y se manda llamar el ws
            'datos.sqlParameters.Add(New SqlParameter("@FechaTransferencia", reembolsotermino.FechaTransferencia))
            'datos.sqlParameters.Add(New SqlParameter("@BancoTransferencia", reembolsotermino.BancoTransferencia))
            'datos.sqlParameters.Add(New SqlParameter("@ReferenciaTransferencia", reembolsotermino.ReferenciaTransferencia))
            datos.sqlParameters.Add(New SqlParameter("@IdServicio", reembolsocontabilidad.IdServicio))
            datos.sqlParameters.Add(New SqlParameter("@PolizaContable", reembolsocontabilidad.PolizaContable))
            datos.sqlParameters.Add(New SqlParameter("@IdUsuarioAutorizo", usr))


            datos.Comando_SP("Update_Reembolsos_Contabilidad @IdServicio, @PolizaContable, @IdUsuarioAutorizo ", res.DataTable)

            ' Graba la auditoria
            Auditoria.Registrar(usr, 71, reembolsocontabilidad.IdServicio)
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
            Logs.LogError("CheckOut.vb", "Update_Reembolsos_Contabilidad", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function

    Public Function Actualizar_Reembolso_Termino(usr As Integer, reembolsotermino As CReembolsotermino) As Resultado 'jrad marzo-2013
        Dim res As New Resultado 'Objeto para resultados
        Dim datos As New ObjDatos 'Objetod para mandar llamar el ws

        Try
            ' Valida que sea un dato correcto

            'Se crea parámetro y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@IdServicio", reembolsotermino.IdServicio))
            datos.sqlParameters.Add(New SqlParameter("@FechaTransferencia", reembolsotermino.FechaTransferencia))
            datos.sqlParameters.Add(New SqlParameter("@BancoTransferencia", reembolsotermino.BancoTransferencia))
            datos.sqlParameters.Add(New SqlParameter("@ReferenciaTransferencia", reembolsotermino.ReferenciaTransferencia))
            'datos.sqlParameters.Add(New SqlParameter("@PolizaContable", reembolsotermino.PolizaContable))
            datos.sqlParameters.Add(New SqlParameter("@IdUsuarioAutorizo", usr))


            datos.Comando_SP("Update_Reembolsos_Terminacion @IdServicio, @FechaTransferencia, @BancoTransferencia, @ReferenciaTransferencia, @IdUsuarioAutorizo", res.DataTable)

            ' Graba la auditoria
            Auditoria.Registrar(usr, 71, reembolsotermino.IdServicio)
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
            Logs.LogError("CheckOut.vb", "Update_Reembolsos_Terminacion", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function

    Public Function Consultar_Reembolsos(usr As String, reembolso As CBusqueda_Reembolso, EstatusReembolso As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try ''jrad marzo-2013
            datos.sqlParameters.Add(New SqlParameter("@EstatusReembolso", EstatusReembolso))
            datos.sqlParameters.Add(New SqlParameter("@NumServicio", reembolso.NumServicio))
            datos.sqlParameters.Add(New SqlParameter("@NumSiniestro", reembolso.NumSiniestro))
            datos.sqlParameters.Add(New SqlParameter("@NumPoliza", reembolso.NumPoliza))
            datos.sqlParameters.Add(New SqlParameter("@Aseguradora", reembolso.NombreAseguradora))
            datos.sqlParameters.Add(New SqlParameter("@NombreAsegurado", reembolso.AsegNombre))
            datos.sqlParameters.Add(New SqlParameter("@Placas", reembolso.Placas))
            datos.sqlParameters.Add(New SqlParameter("@Proveedor", reembolso.Proveedor))
            datos.sqlParameters.Add(New SqlParameter("@NumContrato", reembolso.NumContrato))

            datos.Consulta_SP("Select_Reembolsos @EstatusReembolso,@NumServicio, @NumSiniestro, @NumPoliza, @Aseguradora, @NombreAsegurado, @Placas,@Proveedor,@NumContrato", res.DataTable)


        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("CheckOut.vb", "Select_Reembolsos", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
        Return res
    End Function

    Public Function Consultar_Reembolsos_Completos(ByVal usr As String, ByVal IdServicio As Integer) As Resultado ' jrad marzo 2013
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            datos.sqlParameters.Add(New SqlParameter("@IdServicio", IdServicio))

            datos.Consulta_SP("Select_Reembolsos_Completos @IdServicio", res.DataTable)


        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("CheckOut.vb", "Select_Reembolsos_Completos", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
        Return res
    End Function

    Public Function Consultar_Reembolsos_Solicitud(ByVal usr As String, ByVal IdServicio As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            datos.sqlParameters.Add(New SqlParameter("@IdServicio", IdServicio))

            datos.Consulta_SP("Select_Reembolsos_Solicitud @IdServicio", res.DataTable)


        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("CheckOut.vb", "Select_Reembolsos_Solicitud", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
        Return res
    End Function

    Public Function Consultar_PDF_Solicitud_Pago_Reembolso(usr As String, IdReembolso As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            'Se crean parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@IdReembolso", IdReembolso))

            datos.Consulta_SP("Select_PDF_Solicitud_Pago_Reembolso @IdReembolso", res.DataTable)

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("CheckOut.vb", "Select_PDF_Recibo_Reembolso", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
        Return res
    End Function
#End Region

#Region "Pagos" '' jrad 5-marzo-2013

    Public Function Insertar_Iasistenciaii(usr As Integer, Pagos As CPagos) As Resultado
        Dim res As New Resultado 'Objeto para resultados
        Dim datos As New ObjDatos(ObjDatos.CONNECTION_STRING_AsistenciaII)

        Try

            'Se crea parámetro y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@ClaContrato", Pagos.idAseguradora))
            datos.sqlParameters.Add(New SqlParameter("@ClaServicio", Pagos.idServicioAsistencia))
            datos.sqlParameters.Add(New SqlParameter("@titular", Pagos.Asegnombre))
            datos.sqlParameters.Add(New SqlParameter("@claEstadoUbica", Pagos.repidestado))
            datos.sqlParameters.Add(New SqlParameter("@FechaSiniestro", Pagos.fecActivacion))
            datos.sqlParameters.Add(New SqlParameter("@Poliza", Pagos.numpoliza))
            datos.sqlParameters.Add(New SqlParameter("@inciso", Pagos.inciso))
            datos.sqlParameters.Add(New SqlParameter("@Siniestro", Pagos.numsiniestro))
            datos.sqlParameters.Add(New SqlParameter("@Reporte", Pagos.numservicio))
            datos.sqlParameters.Add(New SqlParameter("@claProveedor", Pagos.claproveedor))
            datos.sqlParameters.Add(New SqlParameter("@Costo", Pagos.Importe))
            datos.sqlParameters.Add(New SqlParameter("@Factura", Pagos.Factura))
            datos.sqlParameters.Add(New SqlParameter("@PagoLocalForaneo", Pagos.PagoLocalForaneo))

            datos.Comando_SP("sp_ServAutoSigue  @ClaContrato, @ClaServicio, @titular, @claEstadoUbica, @FechaSiniestro, @Poliza, @inciso, @Siniestro, @Reporte,@claProveedor,@Costo,@Factura,@PagoLocalForaneo", res.DataTable)



            ' Verifica si todo salió bien:
            res.Dato = res.DataTable.Rows(0)(2) 'Aqui devuelve el Id

            ' Graba la auditoria
            Auditoria.Registrar(usr, 63, res.Dato)
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
            Logs.LogError("CheckOut.vb", "sp_ServAutoSigue", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function

    Public Function Rechazar_Pago(usr As Integer, IdServicio As Integer, IdCausa_rechazo_Pago As Integer) As Resultado
        Dim res As New Resultado 'Objeto para resultados
        Dim datos As New ObjDatos

        Try

            'Se crea parámetro y se manda llamar el ws

            datos.sqlParameters.Add(New SqlParameter("@IdServicio", IdServicio))
            datos.sqlParameters.Add(New SqlParameter("@IdCausa_rechazo_Pago", IdCausa_rechazo_Pago))

            datos.Comando_SP("Update_Rechaza_Servicios_Pago  @IdServicio,@IdCausa_rechazo_Pago", res.DataTable)



            ' Verifica si todo salió bien:
            res.Dato = res.DataTable.Rows(0)(2) 'Aqui devuelve el Id

            ' Graba la auditoria
            Auditoria.Registrar(usr, 63, res.Dato)
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
            Logs.LogError("CheckOut.vb", "Update_Rechaza_Servicios_Pago", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function

    Public Function Actualizar_Iasistenciaii(ByVal usr As Integer, ByVal IdServicio As Integer, ByVal Idasistenciaii As String, ByVal factura As String, ByVal idrechazo As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos


        Try
            'Se crean parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@IdUsuario", usr))
            datos.sqlParameters.Add(New SqlParameter("@IdServicio", IdServicio))
            datos.sqlParameters.Add(New SqlParameter("@Idasistenciaii", Idasistenciaii))
            datos.sqlParameters.Add(New SqlParameter("@Factura", factura))
            datos.sqlParameters.Add(New SqlParameter("@IdRechazo", idrechazo))

            datos.Comando_SP("Update_Servicios_Idasistenciaii @IdUsuario , @IdServicio, @Idasistenciaii,@Factura,@IdRechazo", res.DataTable)


        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("CheckOut.vb", "Update_Servicios_Idasistenciaii", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
        Return res
    End Function

    'Public Function Actualizar_ServAutoSiguePagos(ByVal anio As Integer, ByVal consec As Integer, ByVal claProveedor As String, ByVal Costo As String, ByVal Factura As String, ByVal FechaAsigna As DateTime, ByVal FechaContacto As DateTime, ByVal FechaTermino As DateTime) As Resultado
    Public Function Actualizar_ServAutoSiguePagos(ByVal anio As Integer, ByVal consec As Integer, ByVal claProveedor As String, ByVal Costo As String, ByVal Factura As String, ByVal FechaAsigna As String, ByVal FechaContacto As String, ByVal FechaTermino As String) As Resultado

        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos(ObjDatos.CONNECTION_STRING_AsistenciaII)


        Try
            'Se crean parámetros y se manda llamar el ws
            datos.Consultar_Servcio_Asistencia_II("exec sp_Update_ServAutoSiguePagos " & anio & ", " & consec & ", '" & claProveedor & "', " & Costo & ", '" & Factura & "', '" & FechaAsigna & "', '" & FechaContacto & "', '" & FechaTermino & "' ", res.DataTable)


        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Validacion_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("CheckOut.vb", "Update_Servicios_Idasistenciaii", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
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
#End Region

#Region "Extensiones"
    Public Function Buscar_Extensiones(usr As String, contrato As CBusqueda_Contrato2) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos


        Try
            'Se crean parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@NumServicio", contrato.NumServicio))
            datos.sqlParameters.Add(New SqlParameter("@NumSiniestro", contrato.NumSiniestro))
            datos.sqlParameters.Add(New SqlParameter("@NumPoliza", contrato.NumPoliza))
            datos.sqlParameters.Add(New SqlParameter("@NumContrato", contrato.NumContrato))
            datos.sqlParameters.Add(New SqlParameter("@NombreAsegurado", contrato.AsegNombre))
            datos.sqlParameters.Add(New SqlParameter("@Placas", contrato.Placas))
            datos.sqlParameters.Add(New SqlParameter("@Estatus", contrato.Estatus))
            datos.sqlParameters.Add(New SqlParameter("@Fecha1", contrato.Fecha1))
            datos.sqlParameters.Add(New SqlParameter("@Fecha2", contrato.Fecha2))

            datos.Consulta_SP("Select_Extension @NumContrato, @NumServicio, @NumPoliza, @NumSiniestro, @NombreAsegurado, @Placas, @Estatus, @Fecha1, @Fecha2", res.DataTable)

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("CheckOut.vb", "Select_Extension", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
        Return res
    End Function

    Public Function Detalle_Extensiones(contrato As Integer, consec As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos


        Try
            'Se crean parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@Contrato", contrato))
            datos.sqlParameters.Add(New SqlParameter("@NumExtension", consec))


            datos.Consulta_SP("Select_Detalle_Extensiones @Contrato, @NumExtension", res.DataTable)

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("CheckOut.vb", "Select_Detalle_Extensiones", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
        Return res
    End Function
	
	Public Function Consultar_PDF_Extension_Comodato_Proveedor(ByVal usr As String, ByVal IdServicio As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos


        Try
            'Se crean parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@IdServicio", IdServicio))

            datos.Consulta_SP("Select_PDF_Extension_Comodato_Proveedor @IdServicio", res.DataTable)


        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("CheckOut.vb", "Select_PDF_Extension_Comodato_Proveedor", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
        Return res
    End Function
	
#End Region


End Class

