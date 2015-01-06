Imports Microsoft.VisualBasic
Imports Acceso_a_Datos
Imports System.Data
Imports System.Data.SqlClient

Public Class Datos_ControlVehicular

#Region "Polizas"

    Public Function Insertar_Polizas(usr As String, poliza As CPoliza) As Resultado
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            '' Valida que sean datos correctos
            'If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(poliza.NumPoliza) Then
            '    Throw New Validacion_Exception("Número de Póliza")
            'End If
            'If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(poliza.Telefono1) Then
            '    Throw New Validacion_Exception("Teléfono 1")
            'End If
            'If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(poliza.Telefono2) Then
            '    Throw New Validacion_Exception("Teléfono 2")
            'End If
            'If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(poliza.AgenteSeguros) Then
            '    Throw New Validacion_Exception("Agente de Seguros")
            'End If

            'Se crean parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@NumPoliza", poliza.NumPoliza))
            datos.sqlParameters.Add(New SqlParameter("@IdAseguradora", poliza.IdAseguradora))
            datos.sqlParameters.Add(New SqlParameter("@FecIniVigencia", poliza.FecIniVigencia))
            datos.sqlParameters.Add(New SqlParameter("@FecFinVigencia", poliza.FecFinVigencia))
            datos.sqlParameters.Add(New SqlParameter("@Telefono1", poliza.Telefono1))
            datos.sqlParameters.Add(New SqlParameter("@IdTipoCobertura", poliza.IdTipoCobertura))
            datos.sqlParameters.Add(New SqlParameter("@Telefono2", poliza.Telefono2))
            datos.sqlParameters.Add(New SqlParameter("@Mensualidad", poliza.Mensualidad))
            datos.sqlParameters.Add(New SqlParameter("@AgenteSeguros", poliza.AgenteSeguros))
            datos.sqlParameters.Add(New SqlParameter("@CostoAnual", poliza.CostoAnual))
            datos.sqlParameters.Add(New SqlParameter("@FecPago", poliza.FecPago))
            datos.sqlParameters.Add(New SqlParameter("@IdTipoPago", poliza.IdTipoPago))
            datos.sqlParameters.Add(New SqlParameter("@Individual", poliza.Individual))

            datos.Comando_SP("Insert_Polizas @NumPoliza, @IdAseguradora, @FecIniVigencia, @FecFinVigencia, @IdTipoCobertura, @Telefono1, @Telefono2, @FecPago, @IdTipoPago, @CostoAnual, @Mensualidad, @AgenteSeguros, @Individual", res.DataTable)

            res.Dato = res.DataTable.Rows(0)(2) 'Aqui devuelve el id de la poliza

            ' Graba la auditoria
            Auditoria.Registrar(usr, 11, res.Dato & "-" & poliza.NumPoliza)
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
            Logs.LogError("ControlVehicular.vb", "Insert_Polizas", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function


    Public Function Actualizar_Polizas(usr As String, poliza As CPoliza) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            ' Valida que sean datos correctos
            'If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(poliza.Telefono1) Then
            '    Throw New Validacion_Exception("Teléfono 1")
            'End If
            'If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(poliza.Telefono2) Then
            '    Throw New Validacion_Exception("Teléfono 2")
            'End If
            'If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(poliza.AgenteSeguros) Then
            '    Throw New Validacion_Exception("Agente de Seguros")
            'End If

            'Se crean parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@IdPoliza", poliza.Id))
            'datos.sqlParameters.Add(New SqlParameter("@IdAseguradora", poliza.IdAseguradora))
            'datos.sqlParameters.Add(New SqlParameter("@FecIniVigencia", poliza.FecIniVigencia))
            'datos.sqlParameters.Add(New SqlParameter("@FecFinVigencia", poliza.FecFinVigencia))
            'datos.sqlParameters.Add(New SqlParameter("@Telefono1", poliza.Telefono1))
            datos.sqlParameters.Add(New SqlParameter("@IdTipoCobertura", poliza.IdTipoCobertura))
            'datos.sqlParameters.Add(New SqlParameter("@Telefono2", poliza.Telefono2))
            datos.sqlParameters.Add(New SqlParameter("@Mensualidad", poliza.Mensualidad))
            'datos.sqlParameters.Add(New SqlParameter("@AgenteSeguros", poliza.AgenteSeguros))
            datos.sqlParameters.Add(New SqlParameter("@CostoAnual", poliza.CostoAnual))
            'datos.sqlParameters.Add(New SqlParameter("@FecPago", poliza.FecPago))

            datos.Comando_SP("Update_Polizas @IdPoliza, @IdTipoCobertura, @CostoAnual, @Mensualidad", res.DataTable)

            ' Graba la auditoria
            Auditoria.Registrar(usr, 12, poliza.Id & "-" & poliza.NumPoliza)
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
            Logs.LogError("ControlVehicular.vb", "Update_Polizas", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
        Return res
    End Function


    Public Function Consultar_Polizas(usr As String, poliza As CBusqueda_Poliza) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos


        Try
            'Se crean parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@NumPoliza", poliza.NumPoliza))
            datos.sqlParameters.Add(New SqlParameter("@MVA", poliza.MVA))
            datos.sqlParameters.Add(New SqlParameter("@NumSerie", poliza.NumSerie))
            datos.sqlParameters.Add(New SqlParameter("@Placas", poliza.Placas))

            datos.Consulta_SP("Select_Polizas @NumPoliza, @Placas, @MVA, @NumSerie", res.DataTable)


        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("ControlVehicular.vb", "Select_Poliza", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
        Return res
    End Function


    Public Function Consultar_Polizas_Completas(usr As String, IdPoliza As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos


        Try

            'Se crean parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@IdPoliza", IdPoliza))

            datos.Consulta_SP("Select_Polizas_Completas @IdPoliza", res.DataTable)


        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("ControlVehicular.vb", "Select_Polizas_Completas", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
        Return res
    End Function


    Public Function Eliminar_Poliza(usr As String, IdPoliza As Integer, IdMotivo As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos


        Try

            'Se crean parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@IdPoliza", IdPoliza))
            datos.sqlParameters.Add(New SqlParameter("@IdMotivo", IdMotivo))
            datos.Comando_SP("Delete_Polizas @IdPoliza, @IdMotivo", res.DataTable)

            ' Graba la auditoria
            Auditoria.Registrar(usr, 13, IdPoliza)
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
            Logs.LogError("ControlVehicular.vb", "Delete_Polizas", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
        Return res
    End Function


    Public Function Insertar_Poliza_Incisos(usr As String, poliza_incisos As CPolizas_Incisos) As Resultado
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            ' Valida que sean datos correctos
            For i As Integer = 0 To poliza_incisos.Inciso.Length - 1
                If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(poliza_incisos.Inciso(i)) Then
                    Throw New Validacion_Exception("Inciso: " & poliza_incisos.Inciso(i))
                End If
            Next

            datos.BeginTransaction()

            For i As Integer = 0 To poliza_incisos.Inciso.Length - 1
                ' Inserta cada uno de los incisos
                datos.sqlParameters.Add(New SqlParameter("@IdPoliza", poliza_incisos.IdPoliza))
                datos.sqlParameters.Add(New SqlParameter("@Inciso", poliza_incisos.Inciso(i)))
                datos.sqlParameters.Add(New SqlParameter("@IdVehiculo", poliza_incisos.IdVehiculo(i)))
                ' Graba el dato
                datos.Comando_SP_Transaccion("Insert_Poliza_Inciso @IdPoliza, @Inciso, @IdVehiculo", res.DataTable)
            Next

            datos.Commit()

            ' Graba la auditoria
            Auditoria.Registrar(usr, 14, poliza_incisos.IdPoliza)
        Catch ex As Validacion_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            ' Hace el rollback
            If datos.TransaccionIniciada Then datos.Rollback()

        Catch ex As Exception
            ''Se regresan y registran los datos del error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("ControlVehicular.vb", "Insert_Poliza_Incisos", ex.Message, ex.StackTrace)
            ' Hace el rollback
            If datos.TransaccionIniciada Then datos.Rollback()
        End Try
        Return res
    End Function


    Public Function Consultar_Incisos_Vehiculos(usr As String, IdPoliza As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos


        Try

            'Se crean parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@IdPoliza", IdPoliza))

            datos.Consulta_SP("Select_Incisos_Vehiculos @IdPoliza", res.DataTable)


        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("ControlVehicular.vb", "Select_Vehiculos_Incisos", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
        Return res
    End Function

    Public Function Eliminar_Poliza_Inciso(usr As String, IdPoliza As Integer, ConsecInciso As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos


        Try

            'Se crean parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@IdPoliza", IdPoliza))
            datos.sqlParameters.Add(New SqlParameter("@ConsecInciso", ConsecInciso))
            datos.Comando_SP("Delete_Poliza_Inciso @IdPoliza, @ConsecInciso", res.DataTable)

            ' Graba la auditoria
            Auditoria.Registrar(usr, 15, IdPoliza & "-" & ConsecInciso)
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
            Logs.LogError("ControlVehicular.vb", "Delete_Poliza_Inciso", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
        Return res
    End Function
    'Isra
    Public Function Sustituir_Polizas(usr As String, poliza As CPoliza) As Resultado
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            '' Valida que sean datos correctos
            'If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(poliza.NumPoliza) Then
            '    Throw New Validacion_Exception("Número de Póliza")
            'End If
            'If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(poliza.Telefono1) Then
            '    Throw New Validacion_Exception("Teléfono 1")
            'End If
            'If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(poliza.Telefono2) Then
            '    Throw New Validacion_Exception("Teléfono 2")
            'End If
            'If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(poliza.AgenteSeguros) Then
            '    Throw New Validacion_Exception("Agente de Seguros")
            'End If

            'Se crean parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@IdPolizaAnt", poliza.Id))
            datos.sqlParameters.Add(New SqlParameter("@NumPoliza", poliza.NumPoliza))
            datos.sqlParameters.Add(New SqlParameter("@IdAseguradora", poliza.IdAseguradora))
            datos.sqlParameters.Add(New SqlParameter("@FecIniVigencia", poliza.FecIniVigencia))
            datos.sqlParameters.Add(New SqlParameter("@FecFinVigencia", poliza.FecFinVigencia))
            datos.sqlParameters.Add(New SqlParameter("@Telefono1", poliza.Telefono1))
            datos.sqlParameters.Add(New SqlParameter("@IdTipoCobertura", poliza.IdTipoCobertura))
            datos.sqlParameters.Add(New SqlParameter("@Telefono2", poliza.Telefono2))
            datos.sqlParameters.Add(New SqlParameter("@Mensualidad", poliza.Mensualidad))
            datos.sqlParameters.Add(New SqlParameter("@AgenteSeguros", poliza.AgenteSeguros))
            datos.sqlParameters.Add(New SqlParameter("@CostoAnual", poliza.CostoAnual))
            datos.sqlParameters.Add(New SqlParameter("@FecPago", poliza.FecPago))
            datos.sqlParameters.Add(New SqlParameter("@IdTipoPago", poliza.IdTipoPago))
            datos.sqlParameters.Add(New SqlParameter("@Individual", poliza.IdTipoPago))

            datos.Comando_SP("Sustituir_Polizas @IdPolizaAnt, @NumPoliza, @IdAseguradora, @FecIniVigencia, @FecFinVigencia, @IdTipoCobertura, @Telefono1, @Telefono2, @FecPago, @IdTipoPago, @CostoAnual, @Mensualidad, @AgenteSeguros, @Individual", res.DataTable)

            'Devuelve el MVA del vehículo que se grabo
            res.Dato = res.DataTable.Rows(0)(2) 'Aqui devuelve el id de la poliza

            ' Graba la auditoria
            Auditoria.Registrar(usr, 16, poliza.Id & "-" & res.Dato & "-" & poliza.NumPoliza)
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
            Logs.LogError("ControlVehicular.vb", "Sustituir_Polizas", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function
    'Termina Isra

    Public Function Consultar_Poliza_Inciso_Vehiculo(usr As String, IdVehiculo As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos


        Try

            'Se crean parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@IdVehiculo", IdVehiculo))

            datos.Consulta_SP("Select_Poliza_Inciso_Vehiculo @IdVehiculo", res.DataTable)

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("ControlVehicular.vb", "Select_Poliza_Inciso_Vehiculo", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
        Return res
    End Function


#End Region


#Region "Vehiculos"
    'Isra

    Public Function Buscar_MVA(ByVal usr As String, ByVal placas As CVehiculo) As Resultado
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            datos.sqlParameters.Add(New SqlParameter("@Placas", placas.Placas))

            datos.Consulta_SP("Buscar_MVA @Placas", res.DataTable)

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("ControlVehicular.vb", "Buscar_MVA", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
        Return res
    End Function


    Public Function Insertar_Vehiculos(usr As String, vehiculo As CVehiculo) As Resultado
        Dim res As New Resultado
        Dim datos As New ObjDatos


        Try
            'If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(vehiculo.Color) Then
            '    Throw New Validacion_Exception("Color")
            'End If

            'Se crean parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@CapacidadTanque", vehiculo.CapacidadTanque))
            datos.sqlParameters.Add(New SqlParameter("@Color", vehiculo.Color))
            datos.sqlParameters.Add(New SqlParameter("@CostoInicial_Otros", vehiculo.CostoInicial_Otros))
            datos.sqlParameters.Add(New SqlParameter("@CostoInicial_Placas", vehiculo.CostoInicial_Placas))
            datos.sqlParameters.Add(New SqlParameter("@CostoInicial_Tenencia", vehiculo.CostoInicial_Tenencia))
            datos.sqlParameters.Add(New SqlParameter("@CostoInicial_Verificacion", vehiculo.CostoInicial_Verificacion))
            datos.sqlParameters.Add(New SqlParameter("@Equipamiento", vehiculo.Equipamiento))
            datos.sqlParameters.Add(New SqlParameter("@Factura", vehiculo.Factura))
            datos.sqlParameters.Add(New SqlParameter("@FecCompra", vehiculo.FecCompra))
            datos.sqlParameters.Add(New SqlParameter("@IdMarca", vehiculo.IdMarca))
            datos.sqlParameters.Add(New SqlParameter("@IdPropietario", vehiculo.IdPropietario))
            datos.sqlParameters.Add(New SqlParameter("@IdTipoCompra", vehiculo.IdTipoCompra))
            datos.sqlParameters.Add(New SqlParameter("@IdNivelGasolina", vehiculo.IdNivelGasolina))
            datos.sqlParameters.Add(New SqlParameter("@IdTipoVehiculo", vehiculo.IdTipoVehiculo))
            datos.sqlParameters.Add(New SqlParameter("@Kilometraje", vehiculo.Kilometraje))
            datos.sqlParameters.Add(New SqlParameter("@Modelo", vehiculo.Modelo))
            datos.sqlParameters.Add(New SqlParameter("@NumMotor", vehiculo.NumMotor))
            datos.sqlParameters.Add(New SqlParameter("@NumSerie", vehiculo.NumSerie))
            datos.sqlParameters.Add(New SqlParameter("@Placas", vehiculo.Placas))
            datos.sqlParameters.Add(New SqlParameter("@FecPrimerDiaFlota", vehiculo.FecPrimerDiaFlota))
            datos.sqlParameters.Add(New SqlParameter("@IdSubMarca", vehiculo.IdSubMarca))
            datos.sqlParameters.Add(New SqlParameter("@Tarifa", vehiculo.Tarifa))
            datos.sqlParameters.Add(New SqlParameter("@Transmision", vehiculo.Transmision))
            datos.sqlParameters.Add(New SqlParameter("@ValorVehiculo", vehiculo.ValorVehiculo))
            datos.sqlParameters.Add(New SqlParameter("@Inv_AireAcondicionado", vehiculo.Inv_AireAcondicionado))
            datos.sqlParameters.Add(New SqlParameter("@Inv_Encendedor", vehiculo.Inv_Encendedor))
            datos.sqlParameters.Add(New SqlParameter("@Inv_Extintor", vehiculo.Inv_Extintor))
            datos.sqlParameters.Add(New SqlParameter("@Inv_Gato", vehiculo.Inv_Gato))
            datos.sqlParameters.Add(New SqlParameter("@Inv_Herramientas", vehiculo.Inv_Herramientas))
            datos.sqlParameters.Add(New SqlParameter("@Inv_LlantaRefaccion", vehiculo.Inv_LlantaRefaccion))
            datos.sqlParameters.Add(New SqlParameter("@Inv_Llaves", vehiculo.Inv_Llaves))
            datos.sqlParameters.Add(New SqlParameter("@Inv_ManualConductor", vehiculo.Inv_ManualConductor))
            datos.sqlParameters.Add(New SqlParameter("@Inv_Radio", vehiculo.Inv_Radio))
            datos.sqlParameters.Add(New SqlParameter("@Inv_Reflejantes", vehiculo.Inv_Reflejantes))
            datos.sqlParameters.Add(New SqlParameter("@Status", vehiculo.status))
            datos.sqlParameters.Add(New SqlParameter("@Desc_Otros_Costos", vehiculo.Desc_Otros_Costos))

            datos.Comando_SP("Insert_Vehiculos @NumSerie,@NumMotor,@Factura,@IdMarca,@CapacidadTanque,@Color,@Modelo,@IdSubMarca,@Placas,@Equipamiento,@Kilometraje,@IdNivelGasolina,@Transmision,@FecCompra,@ValorVehiculo,@IdTipoVehiculo,@IdPropietario,@IdTipoCompra,@Tarifa,@CostoInicial_Placas,@CostoInicial_Tenencia,@CostoInicial_Verificacion,@CostoInicial_Otros,@FecPrimerDiaFlota,@Inv_ManualConductor,@Inv_Herramientas,@Inv_LLantaRefaccion,@Inv_Reflejantes,@Inv_Extintor,@Inv_Radio,@Inv_Encendedor,@Inv_Llaves,@Inv_Gato,@Inv_AireAcondicionado,@Status,@Desc_Otros_Costos", res.DataTable)

            'Devuelve el Id del vehículo que se grabo
            res.Dato = res.DataTable.Rows(0)(2) 'Aqui devuelve el Id

            ' Graba la auditoria
            Auditoria.Registrar(usr, 1, res.Dato & "-" & res.DataTable.Rows(0)(3))
        Catch ex As Validacion_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("ControlVehicular.vb", "Insert_Vehiculos", ex.Message, ex.StackTrace)

        Catch ex As Exception
            ''Se regresan y registran los datos del error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("ControlVehicular.vb", "Insert_Vehiculos", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function
    '


    Public Function Actualizar_Vehiculos(usr As String, vehiculo As CVehiculo) As Resultado
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try

            'If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(vehiculo.NumMotor) Then
            '    Throw New Validacion_Exception("Número de Motor")
            'End If
            'If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(vehiculo.Placas) Then
            '    Throw New Validacion_Exception("Matricula")
            'End If
            'If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(vehiculo.Factura) Then
            '    Throw New Validacion_Exception("Factura")
            'End If
            'If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(vehiculo.Color) Then
            '    Throw New Validacion_Exception("Color")
            'End If
            'If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(vehiculo.Equipamiento) Then
            '    Throw New Validacion_Exception("Equipamiento")
            'End If

            'Se crean parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@Id", vehiculo.Id))

            datos.sqlParameters.Add(New SqlParameter("@CapacidadTanque", vehiculo.CapacidadTanque))
            datos.sqlParameters.Add(New SqlParameter("@Color", vehiculo.Color))
            'datos.sqlParameters.Add(New SqlParameter("@CostoInicial_Otros", vehiculo.CostoInicial_Otros))
            'datos.sqlParameters.Add(New SqlParameter("@CostoInicial_Placas", vehiculo.CostoInicial_Placas))
            'datos.sqlParameters.Add(New SqlParameter("@CostoInicial_Tenencia", vehiculo.CostoInicial_Tenencia))
            'datos.sqlParameters.Add(New SqlParameter("@CostoInicial_Verificacion", vehiculo.CostoInicial_Verificacion))
            datos.sqlParameters.Add(New SqlParameter("@Equipamiento", vehiculo.Equipamiento))
            datos.sqlParameters.Add(New SqlParameter("@Factura", vehiculo.Factura))
            datos.sqlParameters.Add(New SqlParameter("@FecCompra", vehiculo.FecCompra))
            datos.sqlParameters.Add(New SqlParameter("@IdMarca", vehiculo.IdMarca))
            datos.sqlParameters.Add(New SqlParameter("@IdPropietario", vehiculo.IdPropietario))
            datos.sqlParameters.Add(New SqlParameter("@IdTipoCompra", vehiculo.IdTipoCompra))
            datos.sqlParameters.Add(New SqlParameter("@IdNivelGasolina", vehiculo.IdNivelGasolina))
            datos.sqlParameters.Add(New SqlParameter("@IdTipoVehiculo", vehiculo.IdTipoVehiculo))
            datos.sqlParameters.Add(New SqlParameter("@Kilometraje", vehiculo.Kilometraje))
            datos.sqlParameters.Add(New SqlParameter("@Modelo", vehiculo.Modelo))
            datos.sqlParameters.Add(New SqlParameter("@NumMotor", vehiculo.NumMotor))
            'datos.sqlParameters.Add(New SqlParameter("@NumSerie", vehiculo.NumSerie))
            datos.sqlParameters.Add(New SqlParameter("@Placas", vehiculo.Placas))
            datos.sqlParameters.Add(New SqlParameter("@FecPrimerDiaFlota", vehiculo.FecPrimerDiaFlota))
            datos.sqlParameters.Add(New SqlParameter("@IdSubMarca", vehiculo.IdSubMarca))
            datos.sqlParameters.Add(New SqlParameter("@Tarifa", vehiculo.Tarifa))
            datos.sqlParameters.Add(New SqlParameter("@Transmision", vehiculo.Transmision))
            datos.sqlParameters.Add(New SqlParameter("@ValorVehiculo", vehiculo.ValorVehiculo))
            datos.sqlParameters.Add(New SqlParameter("@Inv_AireAcondicionado", vehiculo.Inv_AireAcondicionado))
            datos.sqlParameters.Add(New SqlParameter("@Inv_Encendedor", vehiculo.Inv_Encendedor))
            datos.sqlParameters.Add(New SqlParameter("@Inv_Extintor", vehiculo.Inv_Extintor))
            datos.sqlParameters.Add(New SqlParameter("@Inv_Gato", vehiculo.Inv_Gato))
            datos.sqlParameters.Add(New SqlParameter("@Inv_Herramientas", vehiculo.Inv_Herramientas))
            datos.sqlParameters.Add(New SqlParameter("@Inv_LlantaRefaccion", vehiculo.Inv_LlantaRefaccion))
            datos.sqlParameters.Add(New SqlParameter("@Inv_Llaves", vehiculo.Inv_Llaves))
            datos.sqlParameters.Add(New SqlParameter("@Inv_ManualConductor", vehiculo.Inv_ManualConductor))
            datos.sqlParameters.Add(New SqlParameter("@Inv_Radio", vehiculo.Inv_Radio))
            datos.sqlParameters.Add(New SqlParameter("@Inv_Reflejantes", vehiculo.Inv_Reflejantes))
            datos.sqlParameters.Add(New SqlParameter("@Cambio_Placas", vehiculo.Cambio_Placas))
            datos.sqlParameters.Add(New SqlParameter("@Cambio_IdPropietario", vehiculo.Cambio_IdPropietario))
            datos.sqlParameters.Add(New SqlParameter("@Cambio_Kilometraje", vehiculo.Cambio_Kilometraje))

            datos.Comando_SP("Update_Vehiculos @Id, @NumMotor,@Factura,@IdMarca,@CapacidadTanque,@Color,@Modelo,@IdSubMarca,@Placas,@Equipamiento,@Kilometraje,@IdNivelGasolina,@Transmision,@FecCompra,@ValorVehiculo,@IdTipoVehiculo,@IdPropietario,@IdTipoCompra,@Tarifa,@FecPrimerDiaFlota,@Inv_ManualConductor,@Inv_Herramientas,@Inv_LLantaRefaccion,@Inv_Reflejantes,@Inv_Extintor,@Inv_Radio,@Inv_Encendedor,@Inv_Llaves,@Inv_Gato,@Inv_AireAcondicionado, @Cambio_Placas, @Cambio_IdPropietario, @Cambio_Kilometraje", res.DataTable)

            ' Graba la auditoria
            Auditoria.Registrar(usr, 2, vehiculo.Id & "-" & vehiculo.MVA)
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
            Logs.LogError("ControlVehicular.vb", "Update_Vehiculos", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function
    'Isra
    Public Function Consultar_Vehiculos_CheckIn(ByVal usr As String, ByVal Id As CBusqueda_Vehiculo) As Resultado
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            datos.sqlParameters.Add(New SqlParameter("@IdRegion", Id.IdRegion))
            datos.sqlParameters.Add(New SqlParameter("@IdTipoVehiculo", Id.IdTipoVehiculo))

            datos.Consulta_SP("Select_Vehiculos_CheckInContratos @IdRegion, @IdTipoVehiculo", res.DataTable)

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("ControlVehicular.vb", "Select_Vehiculos_CheckInContratos", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
        Return res
    End Function
    'Termina Isra


    Public Function Consultar_Vehiculos(usr As String, vehiculo As CBusqueda_Vehiculo) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos


        Try
            datos.sqlParameters.Add(New SqlParameter("@TipoConsulta", vehiculo.TipoConsulta))
            'Se crean parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@MVA", vehiculo.MVA))
            datos.sqlParameters.Add(New SqlParameter("@Placas", vehiculo.Placas))
            datos.sqlParameters.Add(New SqlParameter("@Serie", vehiculo.Serie))
            datos.sqlParameters.Add(New SqlParameter("@Marca", vehiculo.Marca))
            datos.sqlParameters.Add(New SqlParameter("@Modelo", vehiculo.Modelo))
            datos.sqlParameters.Add(New SqlParameter("@PersonaAsignada", vehiculo.PersonaAsignada))
            datos.sqlParameters.Add(New SqlParameter("@Estatus", vehiculo.Estatus))
            datos.sqlParameters.Add(New SqlParameter("@IdPropietario", vehiculo.IdPropietario))
            datos.sqlParameters.Add(New SqlParameter("@IdAlmacen", -1))
            datos.sqlParameters.Add(New SqlParameter("@IdUsuario", usr))
            datos.sqlParameters.Add(New SqlParameter("@VehIdEstado", 0))

            datos.Consulta_SP("Select_Vehiculos @TipoConsulta, @MVA, @Placas, @Serie, @Marca, @Modelo, @PersonaAsignada, @Estatus, @IdPropietario,@IdAlmacen, @IdUsuario,@VehIdEstado", res.DataTable)


        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("ControlVehicular.vb", "Select_Vehiculos", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
        Return res
    End Function

    'Isra
    Public Function Consultar_Vehiculos_Flotilla(ByVal usr As String, ByVal vehiculo As CBusqueda_Vehiculo) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos


        Try
            datos.sqlParameters.Add(New SqlParameter("@TipoConsulta", vehiculo.TipoConsulta))
            'Se crean parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@MVA", vehiculo.MVA))
            datos.sqlParameters.Add(New SqlParameter("@Placas", vehiculo.Placas))
            datos.sqlParameters.Add(New SqlParameter("@Serie", vehiculo.Serie))
            datos.sqlParameters.Add(New SqlParameter("@Marca", vehiculo.Marca))
            datos.sqlParameters.Add(New SqlParameter("@Modelo", vehiculo.Modelo))
            datos.sqlParameters.Add(New SqlParameter("@PersonaAsignada", vehiculo.PersonaAsignada))
            datos.sqlParameters.Add(New SqlParameter("@Estatus", vehiculo.Estatus))
            datos.sqlParameters.Add(New SqlParameter("@IdPropietario", vehiculo.IdPropietario))
            datos.sqlParameters.Add(New SqlParameter("@IdAlmacen", -1))
            datos.sqlParameters.Add(New SqlParameter("@IdUsuario", usr))
            datos.sqlParameters.Add(New SqlParameter("@VehIdEstado", 0))

            datos.Consulta_SP("Select_Localizacion_Flotilla @TipoConsulta, @MVA, @Placas, @Serie, @Marca, @Modelo, @PersonaAsignada, @Estatus, @IdPropietario,@IdAlmacen, @IdUsuario,@VehIdEstado", res.DataTable)


        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("ControlVehicular.vb", "Select_Localizacion_Flotilla", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
        Return res
    End Function
    'Termina Isra


    Public Function Consultar_Vehiculos_Completos(ByVal usr As String, ByVal Id As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos


        Try

            'Se crean parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@Id", Id))

            datos.Consulta_SP("Select_Vehiculos_Completos @Id", res.DataTable)





        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("ControlVehicular.vb", "Select_Vehiculos_Completos", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
        Return res
    End Function


    Public Function Eliminar_Vehiculo(usr As String, baja As CVehiculos_Baja) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos


        Try

            'Se crean parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@IdVehiculo", baja.IdVehiculo))
            datos.sqlParameters.Add(New SqlParameter("@IdMotivoBaja", baja.IdMotivoBaja))
            datos.sqlParameters.Add(New SqlParameter("@FecVenta", baja.FecVenta))
            datos.sqlParameters.Add(New SqlParameter("@MontoVenta", baja.MontoVenta))
            datos.sqlParameters.Add(New SqlParameter("@NombreComprador", baja.NombreComprador))
            datos.sqlParameters.Add(New SqlParameter("@NombreEmpresaCompradora", baja.NombreEmpresaCompradora))
            datos.Comando_SP("Delete_Vehiculos @IdVehiculo, @IdMotivoBaja, @FecVenta, @MontoVenta, @NombreComprador, @NombreEmpresaCompradora", res.DataTable)

            ' Graba la auditoria
            Auditoria.Registrar(usr, 3, baja.IdVehiculo)
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
            Logs.LogError("ControlVehicular.vb", "Delete_Vehiculos", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
        Return res
    End Function


#End Region


#Region "Documentos"


#Region "Tenencias"


    Public Function Consultar_DocTenencias(usr As Integer, IdVehiculo As Integer, Consec As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos


        Try

            'Se crean los parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@Consec", Consec))
            datos.sqlParameters.Add(New SqlParameter("@IdVehiculo", IdVehiculo))
            datos.Consulta_SP("Select_DocTenencias @IdVehiculo, @Consec", res.DataTable)


        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("ControlAcceso.vb", "Select_DocTenencias", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function


    Public Function Insertar_DocTenencia(usr As String, docTenencia As CDocTenencia) As Resultado
        Dim res As New Resultado
        Dim datos As New ObjDatos


        Try

            'Se crean parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@IdVehiculo", docTenencia.IdVehiculo))
            datos.sqlParameters.Add(New SqlParameter("@Costo", docTenencia.Costo))
            datos.sqlParameters.Add(New SqlParameter("@FecVencimiento", docTenencia.FecVencimiento))

            'Graba Documento
            datos.Comando_SP("Insert_DocTenencias @IdVehiculo, @Costo, @FecVencimiento", res.DataTable)

            ' Graba la auditoria
            Auditoria.Registrar(usr, 21, docTenencia.IdVehiculo & " - " & res.DataTable.Rows(0)(2))
        Catch ex As Validacion_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

            If datos.TransaccionIniciada Then datos.Rollback()

        Catch ex As Exception
            ''Se regresan y registran los datos del error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

            If datos.TransaccionIniciada Then datos.Rollback()

            Logs.LogError("ControlVehicular.vb", "Insert_DocTenencias", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function


    Public Function Eliminar_DocTenencias(usr As String, IdVehiculo As Integer, Consec As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try

            'Se crean parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@Consec", Consec))
            datos.sqlParameters.Add(New SqlParameter("@IdVehiculo", IdVehiculo))
            datos.Comando_SP("Delete_DocTenencias @IdVehiculo, @Consec", res.DataTable)

            ' Graba la auditoria
            Auditoria.Registrar(usr, 22, IdVehiculo & " - " & Consec)
        Catch ex As Validacion_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

            'Rollback
            If datos.TransaccionIniciada Then datos.Rollback()

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("ControlVehicular.vb", "Delete_DocTenencias", ex.Message, ex.StackTrace)
            'Rollback
            If datos.TransaccionIniciada Then datos.Rollback()
        End Try
        'Regresa Resultado2
        Return res
    End Function

#End Region

#Region "Tarjetas de circulacion"


    Public Function Consultar_DocTarjetas(usr As Integer, IdVehiculo As Integer, Consec As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos


        Try

            'Se crean los parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@Consec", Consec))
            datos.sqlParameters.Add(New SqlParameter("@IdVehiculo", IdVehiculo))
            datos.Consulta_SP("Select_DocTarjetas @IdVehiculo, @Consec", res.DataTable)


        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("ControlAcceso.vb", "Select_DocTarjetas", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function


    Public Function Insertar_DocTarjetas(usr As String, docTarjeta As CDocTarjetaCirculacion) As Resultado
        Dim res As New Resultado
        Dim datos As New ObjDatos


        Try

            'Se crean parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@IdVehiculo", docTarjeta.IdVehiculo))
            datos.sqlParameters.Add(New SqlParameter("@Costo", docTarjeta.Costo))
            datos.sqlParameters.Add(New SqlParameter("@FecVencimiento", docTarjeta.FecVencimiento))

            'Graba Documento
            datos.Comando_SP("Insert_DocTarjetas @IdVehiculo, @Costo, @FecVencimiento", res.DataTable)


            ' Graba la auditoria
            Auditoria.Registrar(usr, 23, docTarjeta.IdVehiculo & " - " & res.DataTable.Rows(0)(2))
        Catch ex As Validacion_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

            If datos.TransaccionIniciada Then datos.Rollback()

        Catch ex As Exception
            ''Se regresan y registran los datos del error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

            If datos.TransaccionIniciada Then datos.Rollback()

            Logs.LogError("ControlVehicular.vb", "Insert_DocTarjetas", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function


    Public Function Eliminar_DocTarjetas(usr As String, IdVehiculo As Integer, Consec As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try

            'Se crean parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@Consec", Consec))
            datos.sqlParameters.Add(New SqlParameter("@IdVehiculo", IdVehiculo))
            datos.Comando_SP("Delete_DocTarjetas @IdVehiculo, @Consec", res.DataTable)

            ' Graba la auditoria
            Auditoria.Registrar(usr, 24, IdVehiculo & "-" & Consec)
        Catch ex As Validacion_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

            'Rollback
            If datos.TransaccionIniciada Then datos.Rollback()

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("ControlVehicular.vb", "Delete_DocTarjetas", ex.Message, ex.StackTrace)
            'Rollback
            If datos.TransaccionIniciada Then datos.Rollback()
        End Try
        'Regresa Resultado2
        Return res
    End Function

#End Region

#Region "Verificaciones"


    Public Function Consultar_DocVerificaciones(usr As Integer, IdVehiculo As Integer, Consec As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos


        Try

            'Se crean los parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@Consec", Consec))
            datos.sqlParameters.Add(New SqlParameter("@IdVehiculo", IdVehiculo))
            datos.Consulta_SP("Select_DocVerificaciones @IdVehiculo, @Consec", res.DataTable)


        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("ControlAcceso.vb", "Select_DocVerificaciones", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function


    Public Function Insertar_DocVerificaciones(usr As String, verificacion As CDocVerificacion) As Resultado
        Dim res As New Resultado
        Dim datos As New ObjDatos


        Try

            'Se crean parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@IdVehiculo", verificacion.IdVehiculo))
            datos.sqlParameters.Add(New SqlParameter("@Costo", verificacion.Costo))
            datos.sqlParameters.Add(New SqlParameter("@FecVencimiento", verificacion.FecVencimiento))

            'Graba Documento
            datos.Comando_SP("Insert_DocVerificaciones @IdVehiculo, @Costo, @FecVencimiento", res.DataTable)

            ' Graba la auditoria
            Auditoria.Registrar(usr, 25, verificacion.IdVehiculo & "-" & res.DataTable.Rows(0)(2))
        Catch ex As Validacion_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

            If datos.TransaccionIniciada Then datos.Rollback()

        Catch ex As Exception
            ''Se regresan y registran los datos del error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

            If datos.TransaccionIniciada Then datos.Rollback()

            Logs.LogError("ControlVehicular.vb", "Insert_Verificaciones", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function


    Public Function Eliminar_DocVerificaciones(usr As String, IdVehiculo As Integer, Consec As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try

            'Se crean parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@Consec", Consec))
            datos.sqlParameters.Add(New SqlParameter("@IdVehiculo", IdVehiculo))
            datos.Comando_SP("Delete_DocVerificaciones @IdVehiculo, @Consec", res.DataTable)

            ' Graba la auditoria
            Auditoria.Registrar(usr, 26, IdVehiculo & "-" & Consec)
        Catch ex As Validacion_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

            'Rollback
            If datos.TransaccionIniciada Then datos.Rollback()

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("ControlVehicular.vb", "Delete_Verificaciones", ex.Message, ex.StackTrace)
            'Rollback
            If datos.TransaccionIniciada Then datos.Rollback()
        End Try
        'Regresa Resultado2
        Return res
    End Function

#End Region

#Region "Sistema de localización"


    Public Function Consultar_DocSisLoc(usr As Integer, IdVehiculo As Integer, Consec As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos


        Try

            'Se crean los parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@Consec", Consec))
            datos.sqlParameters.Add(New SqlParameter("@IdVehiculo", IdVehiculo))
            datos.Consulta_SP("Select_DocSisLoc @IdVehiculo, @Consec", res.DataTable)


        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("ControlAcceso.vb", "Select_DocSisLoc", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function


    Public Function Insertar_DocSisLoc(usr As String, sisLoc As CDocSisLoc) As Resultado
        Dim res As New Resultado
        Dim datos As New ObjDatos


        Try

            'Se crean parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@IdVehiculo", sisLoc.IdVehiculo))
            datos.sqlParameters.Add(New SqlParameter("@Costo", sisLoc.Costo))
            datos.sqlParameters.Add(New SqlParameter("@FecVencimiento", sisLoc.FecVencimiento))

            'Graba Documento
            datos.Comando_SP("Insert_DocSisLoc @IdVehiculo, @Costo, @FecVencimiento", res.DataTable)

            ' Graba la auditoria
            Auditoria.Registrar(usr, 27, sisLoc.IdVehiculo & "-" & res.DataTable.Rows(0)(2))
        Catch ex As Validacion_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

            If datos.TransaccionIniciada Then datos.Rollback()

        Catch ex As Exception
            ''Se regresan y registran los datos del error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

            If datos.TransaccionIniciada Then datos.Rollback()

            Logs.LogError("ControlVehicular.vb", "Insert_DocSisLoc", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function


    Public Function Eliminar_DocSisLoc(usr As String, IdVehiculo As Integer, Consec As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try

            'Se crean parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@Consec", Consec))
            datos.sqlParameters.Add(New SqlParameter("@IdVehiculo", IdVehiculo))
            datos.Comando_SP("Delete_DocSisLoc @IdVehiculo, @Consec", res.DataTable)

            ' Graba la auditoria
            Auditoria.Registrar(usr, 28, IdVehiculo & "-" & Consec)
        Catch ex As Validacion_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

            'Rollback
            If datos.TransaccionIniciada Then datos.Rollback()

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("ControlVehicular.vb", "Delete_DocSisLoc", ex.Message, ex.StackTrace)
            'Rollback
            If datos.TransaccionIniciada Then datos.Rollback()
        End Try
        'Regresa Resultado2
        Return res
    End Function

#End Region

#Region "Arrendamiento"


    Public Function Consultar_DocArrendamiento(usr As Integer, IdVehiculo As Integer, Consec As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos


        Try

            'Se crean los parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@Consec", Consec))
            datos.sqlParameters.Add(New SqlParameter("@IdVehiculo", IdVehiculo))
            datos.Consulta_SP("Select_DocArrendamiento @IdVehiculo, @Consec", res.DataTable)


        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("ControlVehicular.vb", "Select_DocArre", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function


    Public Function Insertar_DocArrendamiento(usr As String, arrendamiento As CDocArrendamiento) As Resultado
        Dim res As New Resultado
        Dim datos As New ObjDatos


        Try

            ' Valida que sean datos correctos
            If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(arrendamiento.NombreArrendadora) Then
                Throw New Validacion_Exception("Nombre de la Arrendadora")
            End If
            If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(arrendamiento.NumContrato) Then
                Throw New Validacion_Exception("Número de Contrato")
            End If


            'Se crean parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@CostoMensualidad", arrendamiento.CostoMensualidad))
            datos.sqlParameters.Add(New SqlParameter("@FecInicio", arrendamiento.FecInicio))
            datos.sqlParameters.Add(New SqlParameter("@FecTermino", arrendamiento.FeTermino))
            datos.sqlParameters.Add(New SqlParameter("@PeriodoPago", arrendamiento.PeriodoPago))
            datos.sqlParameters.Add(New SqlParameter("@ValorResidual", arrendamiento.ValorResidual))
            datos.sqlParameters.Add(New SqlParameter("@IdVehiculo", arrendamiento.IdVehiculo))
            datos.sqlParameters.Add(New SqlParameter("@NombreArrendadora", arrendamiento.NombreArrendadora))
            datos.sqlParameters.Add(New SqlParameter("@NumContrato", arrendamiento.NumContrato))

            'Graba Documento
            datos.Comando_SP("Insert_DocArrendamiento @IdVehiculo, @NombreArrendadora, @NumContrato, @CostoMensualidad, @ValorResidual, @FecInicio, @FecTermino, @PeriodoPago", res.DataTable)


            ' Graba la auditoria
            Auditoria.Registrar(usr, 29, arrendamiento.IdVehiculo & "-" & res.DataTable.Rows(0)(2))

        Catch ex As Validacion_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

            If datos.TransaccionIniciada Then datos.Rollback()

        Catch ex As Exception
            ''Se regresan y registran los datos del error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

            If datos.TransaccionIniciada Then datos.Rollback()

            Logs.LogError("ControlVehicular.vb", "Insert_DocArrendamiento", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function


    Public Function Eliminar_DocArrendamiento(usr As String, IdVehiculo As Integer, Consec As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try

            'Se crean parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@Consec", Consec))
            datos.sqlParameters.Add(New SqlParameter("@IdVehiculo", IdVehiculo))
            datos.Comando_SP("Delete_DocArrendamiento @IdVehiculo, @Consec", res.DataTable)

            ' Graba la auditoria
            Auditoria.Registrar(usr, 30, IdVehiculo & "-" & Consec)
        Catch ex As Validacion_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

            'Rollback
            If datos.TransaccionIniciada Then datos.Rollback()

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("ControlVehicular.vb", "Delete_Arrendamiento", ex.Message, ex.StackTrace)
            'Rollback
            If datos.TransaccionIniciada Then datos.Rollback()
        End Try
        'Regresa Resultado2
        Return res
    End Function

#End Region


#End Region

#Region "Siniestros"

    Public Function Insertar_Siniestro(usr As Integer, ByRef Application As HttpApplicationState, siniestro As CSiniestro) As Resultado
        Dim res As New Resultado 'Objeto para resultados
        Dim datos As New ObjDatos

        Try

            '' Valida que sea un dato correcto
            If Not Validacion.Solo_LetrasDigitosEspaciosSinNumeros(siniestro.ConductorNombre) Then
                Throw New Validacion_Exception("Nombre del conductor")
            End If

            If Not Validacion.Solo_LetrasDigitosEspaciosSinNumeros(siniestro.ConductorPaterno) Then
                Throw New Validacion_Exception("Apellido paterno del conductor")
            End If

            If Not Validacion.Solo_LetrasDigitosEspaciosSinNumeros(siniestro.ConductorMaterno) Then
                Throw New Validacion_Exception("Apellido materno del conductor")
            End If

            If Not Validacion.Solo_LetrasDigitosEspaciosSinNumeros(siniestro.OperadorNombre) Then
                Throw New Validacion_Exception("Nombre del operador")
            End If

            If Not Validacion.Solo_LetrasDigitosEspaciosSinNumeros(siniestro.OperadorPaterno) Then
                Throw New Validacion_Exception("Apellido materno del operador")
            End If

            If Not Validacion.Solo_LetrasDigitosEspaciosSinNumeros(siniestro.OperadorMaterno) Then
                Throw New Validacion_Exception("Apellido materno del operador")
            End If

            If Not Validacion.Solo_LetrasDigitosEspaciosSinNumeros(siniestro.AjustadorNombre) Then
                Throw New Validacion_Exception("Nombre del Ajustador")
            End If

            If Not Validacion.Solo_LetrasDigitosEspaciosSinNumeros(siniestro.AjustadorPaterno) Then
                Throw New Validacion_Exception("Apellido Paterno del Ajustador")
            End If

            If Not Validacion.Solo_LetrasDigitosEspaciosSinNumeros(siniestro.AjustadorMaterno) Then
                Throw New Validacion_Exception("Apellido Materno del Ajustador")
            End If

            'If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(siniestro.ComentaCierre) Then
            '    Throw New Validacion_Exception("Comantario de cierre")
            'End If

            'If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(siniestro.Narracion) Then
            '    Throw New Validacion_Exception("Narración del siniestro")
            'End If

            'If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(siniestro.TelefonoConductor) Then
            '    Throw New Validacion_Exception("Teléfono del conductor")
            'End If

            'If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(siniestro.UbicacionCalle) Then
            '    Throw New Validacion_Exception("Ubicación - Calle")
            'End If

            'If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(siniestro.UbicacionNumero) Then
            '    Throw New Validacion_Exception("Ubicación - Número")
            'End If

            'If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(siniestro.UbicacionColonia) Then
            '    Throw New Validacion_Exception("Ubicación - Colonia")
            'End If

            'If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(siniestro.UbicacionCP) Then
            '    Throw New Validacion_Exception("Ubicacion - CP")
            'End If

            'If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(siniestro.UbicacionReferencias) Then
            '    Throw New Validacion_Exception("Ubicacion - Referencias")
            'End If

            'If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(siniestro.DictamenPerdida) Then
            '    Throw New Validacion_Exception("Dictamen Pérdida")
            'End If

            'If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(siniestro.Factura) Then
            '    Throw New Validacion_Exception("Factura")
            'End If

            'If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(siniestro.Placas) Then
            '    Throw New Validacion_Exception("Placas")
            'End If
            'If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(siniestro.TarjetaCirculacion) Then
            '    Throw New Validacion_Exception("Tarjeta de circulación")
            'End If
            'If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(siniestro.TramiteBajaPlacas) Then
            '    Throw New Validacion_Exception("Tramite baja de placas")
            'End If
            'If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(siniestro.Tenencias) Then
            '    Throw New Validacion_Exception("Tenencias")
            'End If
            'If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(siniestro.DocAsegArrend) Then
            '    Throw New Validacion_Exception("Documentación a aseguradora y/o arrendadora")
            'End If
            'If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(siniestro.ChequeFiniquito) Then
            '    Throw New Validacion_Exception("Cheque Finiquito")
            'End If

            'If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(siniestro.TallerAsignado) Then
            '    Throw New Validacion_Exception("Taller o Agencia Asignada")
            'End If

            'Se crea parámetro y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@IdVehiculo", siniestro.IdVehiculo))

            datos.sqlParameters.Add(New SqlParameter("@AjustadorMaterno", siniestro.AjustadorMaterno))
            datos.sqlParameters.Add(New SqlParameter("@AjustadorNombre", siniestro.AjustadorNombre))
            datos.sqlParameters.Add(New SqlParameter("@AjustadorPaterno", siniestro.AjustadorPaterno))
            datos.sqlParameters.Add(New SqlParameter("@ComentaCierre", siniestro.ComentaCierre))
            datos.sqlParameters.Add(New SqlParameter("@ConductorMaterno", siniestro.ConductorMaterno))
            datos.sqlParameters.Add(New SqlParameter("@ConductorNombre", siniestro.ConductorNombre))
            datos.sqlParameters.Add(New SqlParameter("@ConductorPaterno", siniestro.ConductorPaterno))
            datos.sqlParameters.Add(New SqlParameter("@EstatusTipoSiniestro", siniestro.IdEstatusTipoSiniestro))
            datos.sqlParameters.Add(New SqlParameter("@FecOcurrido", siniestro.FecOcurrido))
            datos.sqlParameters.Add(New SqlParameter("@IdTipoSiniestro", siniestro.IdTipoSiniestro))
            datos.sqlParameters.Add(New SqlParameter("@Narracion", siniestro.Narracion))
            datos.sqlParameters.Add(New SqlParameter("@NumSiniestro", siniestro.NumSiniestro))
            datos.sqlParameters.Add(New SqlParameter("@OperadorMaterno", siniestro.OperadorMaterno))
            datos.sqlParameters.Add(New SqlParameter("@OperadorNombre", siniestro.OperadorNombre))
            datos.sqlParameters.Add(New SqlParameter("@OperadorPaterno", siniestro.OperadorPaterno))
            datos.sqlParameters.Add(New SqlParameter("@Responsabilidad", siniestro.Responsabilidad))
            datos.sqlParameters.Add(New SqlParameter("@TelefonoConductor", siniestro.TelefonoConductor))
            datos.sqlParameters.Add(New SqlParameter("@UbicacionCalle", siniestro.UbicacionCalle))
            datos.sqlParameters.Add(New SqlParameter("@UbicacionColonia", siniestro.UbicacionColonia))
            datos.sqlParameters.Add(New SqlParameter("@UbicacionCP", siniestro.UbicacionCP))
            datos.sqlParameters.Add(New SqlParameter("@UbicacionIdEstado", siniestro.UbicacionIdEstado))
            datos.sqlParameters.Add(New SqlParameter("@UbicacionIdMunicipio", siniestro.UbicacionIdMunicipio))
            datos.sqlParameters.Add(New SqlParameter("@UbicacionNumero", siniestro.UbicacionNumero))
            datos.sqlParameters.Add(New SqlParameter("@UbicacionReferencias", siniestro.UbicacionReferencias))
            datos.sqlParameters.Add(New SqlParameter("@DictamenPerdida", siniestro.DictamenPerdida))
            datos.sqlParameters.Add(New SqlParameter("@Factura", siniestro.Factura))
            datos.sqlParameters.Add(New SqlParameter("@Placas", siniestro.Placas))
            datos.sqlParameters.Add(New SqlParameter("@TarjetaCirculacion", siniestro.TarjetaCirculacion))
            datos.sqlParameters.Add(New SqlParameter("@TramiteBajaPlacas", siniestro.TramiteBajaPlacas))
            datos.sqlParameters.Add(New SqlParameter("@Tenencias", siniestro.Tenencias))
            datos.sqlParameters.Add(New SqlParameter("@DocAsegArrend", siniestro.DocAsegArrend))
            datos.sqlParameters.Add(New SqlParameter("@ChequeFiniquito", siniestro.ChequeFiniquito))
            datos.sqlParameters.Add(New SqlParameter("@MontoCheque", siniestro.MontoCheque))
            datos.sqlParameters.Add(New SqlParameter("@AvisoArren", siniestro.AvisoArren))
            datos.sqlParameters.Add(New SqlParameter("@MontoValuacion", siniestro.MontoValuacion))
            datos.sqlParameters.Add(New SqlParameter("@Deducible", siniestro.Deducible))
            datos.sqlParameters.Add(New SqlParameter("@TiempoEstRep", siniestro.TiempoEstRep))
            datos.sqlParameters.Add(New SqlParameter("@TipoDeducible", siniestro.TipoDeducible))
            datos.sqlParameters.Add(New SqlParameter("@MontoDeducible", siniestro.MontoDeducible))
            datos.sqlParameters.Add(New SqlParameter("@TallerAsignado", siniestro.TallerAsignado))

            datos.Comando_SP("Insert_Siniestros @IdVehiculo, @IdTipoSiniestro, @EstatusTipoSiniestro, " &
                             "@ComentaCierre, @ConductorNombre, @ConductorPaterno, @ConductorMaterno, " &
                             "@TelefonoConductor, @UbicacionCalle, @UbicacionColonia, @UbicacionCP, " &
                             "@UbicacionIdEstado, @UbicacionIdMunicipio, @UbicacionNumero, @UbicacionReferencias, @NumSiniestro, @OperadorNombre,  @OperadorPaterno, " &
                             "@OperadorMaterno, @AjustadorNombre, @AjustadorPaterno, @AjustadorMaterno, @FecOcurrido, " &
                             "@Responsabilidad, @Narracion, @DictamenPerdida, @Factura,	@Placas, @TarjetaCirculacion, " &
                             "@TramiteBajaPlacas, @Tenencias, @DocAsegArrend, @ChequeFiniquito, @MontoCheque, @AvisoArren, @MontoValuacion, " &
                             "@Deducible, @TipoDeducible, @MontoDeducible, @TallerAsignado, @TiempoEstRep", res.DataTable)

            ' Verifica si todo salió bien:
            res.Dato = res.DataTable.Rows(0)(2) ' Devuelve el consec del siniestro generado

            ' Graba la auditoria
            Auditoria.Registrar(usr, 31, siniestro.IdVehiculo & "-" & res.Dato & "-" & siniestro.NumSiniestro)

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
            Logs.LogError("ControlVehicular.vb", "Insert_Siniestro", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function

    Public Function Actualizar_Siniestros(usr As Integer, siniestro As CSiniestro) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try

            ' Valida que sea un dato correcto
            If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(siniestro.AjustadorNombre) Then
                Throw New Validacion_Exception("Nombre del Ajustador")
            End If

            If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(siniestro.AjustadorPaterno) Then
                Throw New Validacion_Exception("Apellido Paterno del Ajustador")
            End If

            If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(siniestro.AjustadorMaterno) Then
                Throw New Validacion_Exception("Apellido Materno del Ajustador")
            End If

            'If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(siniestro.ComentaCierre) Then
            '    Throw New Validacion_Exception("Comantario de cierre")
            'End If

            If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(siniestro.ConductorNombre) Then
                Throw New Validacion_Exception("Nombre del conductor")
            End If

            If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(siniestro.ConductorPaterno) Then
                Throw New Validacion_Exception("Apellido paterno del conductor")
            End If

            If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(siniestro.ConductorMaterno) Then
                Throw New Validacion_Exception("Apellido materno del conductor")
            End If

            'If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(siniestro.Narracion) Then
            '    Throw New Validacion_Exception("Narración del siniestro")
            'End If

            If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(siniestro.OperadorNombre) Then
                Throw New Validacion_Exception("Nombre del operador")
            End If

            If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(siniestro.OperadorPaterno) Then
                Throw New Validacion_Exception("Apellido materno del operador")
            End If

            If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(siniestro.OperadorMaterno) Then
                Throw New Validacion_Exception("Apellido materno del operador")
            End If

            'If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(siniestro.TelefonoConductor) Then
            '    Throw New Validacion_Exception("Teléfono del conductor")
            'End If

            'If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(siniestro.UbicacionCalle) Then
            '    Throw New Validacion_Exception("Ubicación - Calle")
            'End If

            'If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(siniestro.UbicacionNumero) Then
            '    Throw New Validacion_Exception("Ubicación - Número")
            'End If

            'If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(siniestro.UbicacionColonia) Then
            '    Throw New Validacion_Exception("Ubicación - Colonia")
            'End If

            'If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(siniestro.UbicacionCP) Then
            '    Throw New Validacion_Exception("Ubicacion - CP")
            'End If

            'If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(siniestro.UbicacionReferencias) Then
            '    Throw New Validacion_Exception("Ubicacion - Referencias")
            'End If

            'If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(siniestro.DictamenPerdida) Then
            '    Throw New Validacion_Exception("Dictamen Pérdida")
            'End If

            'If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(siniestro.Factura) Then
            '    Throw New Validacion_Exception("Factura")
            'End If

            'If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(siniestro.Placas) Then
            '    Throw New Validacion_Exception("Placas")
            'End If
            'If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(siniestro.TarjetaCirculacion) Then
            '    Throw New Validacion_Exception("Tarjeta de circulación")
            'End If
            'If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(siniestro.TramiteBajaPlacas) Then
            '    Throw New Validacion_Exception("Tramite baja de placas")
            'End If
            'If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(siniestro.Tenencias) Then
            '    Throw New Validacion_Exception("Tenencias")
            'End If
            'If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(siniestro.DocAsegArrend) Then
            '    Throw New Validacion_Exception("Documentación a aseguradora y/o arrendadora")
            'End If
            'If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(siniestro.ChequeFiniquito) Then
            '    Throw New Validacion_Exception("Cheque Finiquito")
            'End If

            'If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(siniestro.TallerAsignado) Then
            '    Throw New Validacion_Exception("Taller o Agencia Asignada")
            'End If

            'Llave
            datos.sqlParameters.Add(New SqlParameter("@IdVehiculo", siniestro.IdVehiculo))
            datos.sqlParameters.Add(New SqlParameter("@Consec", siniestro.Consec))

            'ACTIVACION
            datos.sqlParameters.Add(New SqlParameter("@AjustadorMaterno", siniestro.AjustadorMaterno))
            datos.sqlParameters.Add(New SqlParameter("@AjustadorNombre", siniestro.AjustadorNombre))
            datos.sqlParameters.Add(New SqlParameter("@AjustadorPaterno", siniestro.AjustadorPaterno))
            datos.sqlParameters.Add(New SqlParameter("@ComentaCierre", siniestro.ComentaCierre))
            datos.sqlParameters.Add(New SqlParameter("@ConductorMaterno", siniestro.ConductorMaterno))
            datos.sqlParameters.Add(New SqlParameter("@ConductorNombre", siniestro.ConductorNombre))
            datos.sqlParameters.Add(New SqlParameter("@ConductorPaterno", siniestro.ConductorPaterno))
            datos.sqlParameters.Add(New SqlParameter("@EstatusTipoSiniestro", siniestro.IdEstatusTipoSiniestro))
            datos.sqlParameters.Add(New SqlParameter("@FecOcurrido", siniestro.FecOcurrido))
            datos.sqlParameters.Add(New SqlParameter("@IdTipoSiniestro", siniestro.IdTipoSiniestro))
            datos.sqlParameters.Add(New SqlParameter("@Narracion", siniestro.Narracion))
            datos.sqlParameters.Add(New SqlParameter("@NumSiniestro", siniestro.NumSiniestro))
            datos.sqlParameters.Add(New SqlParameter("@OperadorMaterno", siniestro.OperadorMaterno))
            datos.sqlParameters.Add(New SqlParameter("@OperadorNombre", siniestro.OperadorNombre))
            datos.sqlParameters.Add(New SqlParameter("@OperadorPaterno", siniestro.OperadorPaterno))
            datos.sqlParameters.Add(New SqlParameter("@Responsabilidad", siniestro.Responsabilidad))
            datos.sqlParameters.Add(New SqlParameter("@TelefonoConductor", siniestro.TelefonoConductor))
            datos.sqlParameters.Add(New SqlParameter("@UbicacionCalle", siniestro.UbicacionCalle))
            datos.sqlParameters.Add(New SqlParameter("@UbicacionColonia", siniestro.UbicacionColonia))
            datos.sqlParameters.Add(New SqlParameter("@UbicacionCP", siniestro.UbicacionCP))
            datos.sqlParameters.Add(New SqlParameter("@UbicacionIdEstado", siniestro.UbicacionIdEstado))
            datos.sqlParameters.Add(New SqlParameter("@UbicacionIdMunicipio", siniestro.UbicacionIdMunicipio))
            datos.sqlParameters.Add(New SqlParameter("@UbicacionNumero", siniestro.UbicacionNumero))
            datos.sqlParameters.Add(New SqlParameter("@UbicacionReferencias", siniestro.UbicacionReferencias))
            datos.sqlParameters.Add(New SqlParameter("@DictamenPerdida", siniestro.DictamenPerdida))
            datos.sqlParameters.Add(New SqlParameter("@Factura", siniestro.Factura))
            datos.sqlParameters.Add(New SqlParameter("@Placas", siniestro.Placas))
            datos.sqlParameters.Add(New SqlParameter("@TarjetaCirculacion", siniestro.TarjetaCirculacion))
            datos.sqlParameters.Add(New SqlParameter("@TramiteBajaPlacas", siniestro.TramiteBajaPlacas))
            datos.sqlParameters.Add(New SqlParameter("@Tenencias", siniestro.Tenencias))
            datos.sqlParameters.Add(New SqlParameter("@DocAsegArrend", siniestro.DocAsegArrend))
            datos.sqlParameters.Add(New SqlParameter("@ChequeFiniquito", siniestro.ChequeFiniquito))
            datos.sqlParameters.Add(New SqlParameter("@MontoCheque", siniestro.MontoCheque))
            datos.sqlParameters.Add(New SqlParameter("@AvisoArren", siniestro.AvisoArren))
            datos.sqlParameters.Add(New SqlParameter("@MontoValuacion", siniestro.MontoValuacion))
            datos.sqlParameters.Add(New SqlParameter("@Deducible", siniestro.Deducible))
            datos.sqlParameters.Add(New SqlParameter("@TiempoEstRep", siniestro.TiempoEstRep))
            datos.sqlParameters.Add(New SqlParameter("@TipoDeducible", siniestro.TipoDeducible))
            datos.sqlParameters.Add(New SqlParameter("@MontoDeducible", siniestro.MontoDeducible))
            datos.sqlParameters.Add(New SqlParameter("@TallerAsignado", siniestro.TallerAsignado))



            datos.Comando_SP("Update_Siniestros @IdVehiculo, @Consec, @IdTipoSiniestro, @EstatusTipoSiniestro, " &
                             "@ComentaCierre, @ConductorNombre, @ConductorPaterno, @ConductorMaterno, " &
                             "@TelefonoConductor, @UbicacionCalle, @UbicacionColonia, @UbicacionCP, " &
                             "@UbicacionIdEstado, @UbicacionIdMunicipio, @UbicacionNumero, @UbicacionReferencias, @NumSiniestro, @OperadorNombre,  @OperadorPaterno, " &
                             "@OperadorMaterno, @AjustadorNombre, @AjustadorPaterno, @AjustadorMaterno, @FecOcurrido, " &
                             "@Responsabilidad, @Narracion, @DictamenPerdida, @Factura,	@Placas, @TarjetaCirculacion, " &
                             "@TramiteBajaPlacas, @Tenencias, @DocAsegArrend, @ChequeFiniquito, @MontoCheque, @AvisoArren, @MontoValuacion, " &
                             "@Deducible, @TipoDeducible, @MontoDeducible, @TallerAsignado, @TiempoEstRep", res.DataTable)

            ' Graba la auditoria
            Auditoria.Registrar(usr, 32, siniestro.IdVehiculo & "-" & siniestro.Consec & "-" & siniestro.NumSiniestro)
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
            Logs.LogError("ControlVehicular.vb", "Update_Siniestro", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
        Return res
    End Function


    Public Function Consultar_Siniestros_Completos(usr As String, IdVehiculo As Integer, Consec As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos


        Try
            'Se crean parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@IdVehiculo", IdVehiculo))
            datos.sqlParameters.Add(New SqlParameter("@Consec", Consec))

            datos.Consulta_SP("Select_Siniestros_Completos @IdVehiculo, @Consec", res.DataTable)


        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("ControlVehicular.vb", "Select_Siniestros_Completos", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
        Return res
    End Function


    Public Function Consultar_Siniestros(usr As String, siniestro As CBusqueda_Siniestro) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos


        Try

            'Se crean parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@NumSerie", siniestro.NumSerie))
            datos.sqlParameters.Add(New SqlParameter("@IdTipoSiniestro", siniestro.IdTipoSiniestro))
            datos.sqlParameters.Add(New SqlParameter("@NumSiniestro", siniestro.NumSiniestro))
            datos.sqlParameters.Add(New SqlParameter("@Placas", siniestro.Placas))

            datos.Consulta_SP("Select_Siniestros @NumSerie, @Placas, @NumSiniestro, @IdTipoSiniestro", res.DataTable)


        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("ControlVehicular.vb", "Select_Siniestros", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
        Return res
    End Function

    'Isra
    Public Function Cancelar_Siniestro(ByVal usr As String, ByVal id As CancelarSiniestro) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos


        Try

            'Se crean parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@IdVehiculo", id.IdVehiculo))
            datos.sqlParameters.Add(New SqlParameter("@Consec", id.Consec))
            datos.sqlParameters.Add(New SqlParameter("@IdMotivoCancel", id.IdMotivo))
            datos.sqlParameters.Add(New SqlParameter("@OtroMotivoCancel", id.OtroMotivoCancel))
            datos.Comando_SP("Delete_Siniestros @IdVehiculo, @Consec, @IdMotivoCancel, @OtroMotivoCancel", res.DataTable)

            ' Graba la auditoria
            Auditoria.Registrar(usr, 33, id.IdVehiculo & "-" & id.Consec)
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
            Logs.LogError("ControlVehicular.vb", "Delete_Siniestros", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
        Return res
    End Function

    Public Function Cerrar_Siniestro(ByVal usr As String, ByVal cierre As CSiniestro_Cierre) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try

            ' Valida que sea un dato correcto
            'If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(cierre.OtroMotivoCierre) Then
            '    Throw New Validacion_Exception("Otro Motivo")
            'End If

            'Se crean parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@IdVehiculo", cierre.IdVehiculo))
            datos.sqlParameters.Add(New SqlParameter("@Consec", cierre.Consec))
            datos.sqlParameters.Add(New SqlParameter("@IdMotivoCierre", cierre.IdMotivoCierre))
            datos.sqlParameters.Add(New SqlParameter("@OtroMotivoCierre", cierre.OtroMotivoCierre))
            datos.Comando_SP("Delete_Siniestros_Cierre @IdVehiculo, @Consec, @IdMotivoCierre, @OtroMotivoCierre", res.DataTable)

            ' Graba la auditoria
            Auditoria.Registrar(usr, 72, cierre.IdVehiculo & "-" & cierre.Consec)
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
            Logs.LogError("ControlVehicular.vb", "Delete_Siniestros_Cierre", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
        Return res
    End Function
    'Termina Isra

    Public Function Consultar_Siniestros_Cancel_Pendientes_Autorizar(ByVal usr As String) As Resultado
        Dim res As New Resultado
        Dim datos As New ObjDatos


        Try

            datos.Consulta_SP("Select_Siniestros_Cancel_Pendientes_Autorizacion", res.DataTable)

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("ControlVehicular.vb", "Select_Siniestros_Cancel_Pendientes_Autorizacion", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
        Return res
    End Function

    'Isra
    Public Function Autorizar_Siniestro_Cancel(ByVal usr As String, ByVal siniestro As CSiniestro_Cancel_Autorizacion) As Resultado
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try

            'Se crean parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@IdVehiculo", siniestro.IdVehiculo))
            datos.sqlParameters.Add(New SqlParameter("@Consec", siniestro.Consec))

            datos.sqlParameters.Add(New SqlParameter("@Autorizacion", siniestro.Autorizacion))
            datos.sqlParameters.Add(New SqlParameter("@Comentarios", siniestro.Comentarios))

            'Graba Asignación
            datos.Comando_SP("Autorizar_Cancelacion_Siniestro @IdVehiculo, @Consec, @Autorizacion, @Comentarios", res.DataTable)

            ' Graba la auditoria
            Auditoria.Registrar(usr, 64, siniestro.IdVehiculo & "-" & siniestro.Consec)

        Catch ex As Validacion_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

            If datos.TransaccionIniciada Then datos.Rollback()

        Catch ex As Exception
            ''Se regresan y registran los datos del error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

            If datos.TransaccionIniciada Then datos.Rollback()

            Logs.LogError("ControlVehicular.vb", "Autorizar_Cancelacion_Siniestro", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function
    '


#End Region

#Region "Asignaciones"


    Public Function Insertar_Asignacion(ByVal usr As String, ByVal asignacion As CAsignacion) As Resultado
        Dim res As New Resultado
        Dim datos As New ObjDatos


        Try

            ' Valida que sean datos correctos
            'If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(asignacion.NumContrato) Then
            '    Throw New Validacion_Exception("Número de Contrato")
            'End If

            'Se crean parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@IdVehiculo", asignacion.IdVehiculo))
            datos.sqlParameters.Add(New SqlParameter("@IdRegion", asignacion.IdRegion))
            datos.sqlParameters.Add(New SqlParameter("@IdCoordinacion", asignacion.IdCoordinacion))
            datos.sqlParameters.Add(New SqlParameter("@IdAlmacen", asignacion.IdAlmacen))
            datos.sqlParameters.Add(New SqlParameter("@NumContrato", asignacion.NumContrato))
            datos.sqlParameters.Add(New SqlParameter("@IdPropietario", asignacion.IdPropietario))
            datos.sqlParameters.Add(New SqlParameter("@IdTipoVehiculo", asignacion.IdTipoVehiculo))
            datos.sqlParameters.Add(New SqlParameter("@IdConductor", asignacion.IdConductor))
            datos.sqlParameters.Add(New SqlParameter("@Inv_AireAcondicionado", asignacion.Inv_AireAcondicionado))
            datos.sqlParameters.Add(New SqlParameter("@Inv_Encendedor", asignacion.Inv_Encendedor))
            datos.sqlParameters.Add(New SqlParameter("@Inv_Extintor", asignacion.Inv_Extintor))
            datos.sqlParameters.Add(New SqlParameter("@Inv_Gato", asignacion.Inv_Gato))
            datos.sqlParameters.Add(New SqlParameter("@Inv_Herramientas", asignacion.Inv_Herramientas))
            datos.sqlParameters.Add(New SqlParameter("@Inv_LlantaRefaccion", asignacion.Inv_LlantaRefaccion))
            datos.sqlParameters.Add(New SqlParameter("@Inv_Llaves", asignacion.Inv_Llaves))
            datos.sqlParameters.Add(New SqlParameter("@Inv_ManualConductor", asignacion.Inv_ManualConductor))
            datos.sqlParameters.Add(New SqlParameter("@Inv_Radio", asignacion.Inv_Radio))
            datos.sqlParameters.Add(New SqlParameter("@Inv_Reflejantes", asignacion.Inv_Reflejantes))

            'Graba Asignación
            datos.Comando_SP("Insert_Asignacion @IdVehiculo, @IdRegion, @IdCoordinacion, @IdAlmacen, @NumContrato, @IdPropietario, @IdTipoVehiculo, @IdConductor, @Inv_ManualConductor,@Inv_Herramientas,@Inv_LLantaRefaccion,@Inv_Reflejantes,@Inv_Extintor,@Inv_Radio,@Inv_Encendedor,@Inv_Llaves,@Inv_Gato,@Inv_AireAcondicionado", res.DataTable)

            ''Obtiene el consecutivo generado
            asignacion.Id = res.DataTable.Rows(0)(2)

            ' Graba la auditoria
            Auditoria.Registrar(usr, 41, asignacion.IdVehiculo & "-" & asignacion.Id)

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

            Logs.LogError("ControlVehicular.vb", "Insert_Asignacion", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function


    Public Function Consultar_Asignaciones_MotivosTerminacion(ByVal usr As String, ByVal Id As Integer) As Resultado
        Dim res As New Resultado
        Dim datos As New ObjDatos


        Try

            datos.sqlParameters.Add(New SqlParameter("@Id", Id))

            'Consulta motivos de asignación
            datos.Consulta_SP("Select_Asignaciones_MotivosTerminacion @Id", res.DataTable)


        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("ControlVehicular.vb", "Select_Asignaciones_MotivosTerminacion", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
        Return res
    End Function


    Public Function Terminar_Asignacion(ByVal usr As String, ByVal asignacion As CAsignacion) As Resultado
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try

            ' Valida que sean datos correctos
            'If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(asignacion.Term_Comentarios) Then
            '    Throw New Validacion_Exception("Comentarios")
            'End If

            'Se crean parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@Id", asignacion.Id))

            datos.sqlParameters.Add(New SqlParameter("@Inv_AireAcondicionado", asignacion.Inv_AireAcondicionado))
            datos.sqlParameters.Add(New SqlParameter("@Inv_Encendedor", asignacion.Inv_Encendedor))
            datos.sqlParameters.Add(New SqlParameter("@Inv_Extintor", asignacion.Inv_Extintor))
            datos.sqlParameters.Add(New SqlParameter("@Inv_Gato", asignacion.Inv_Gato))
            datos.sqlParameters.Add(New SqlParameter("@Inv_Herramientas", asignacion.Inv_Herramientas))
            datos.sqlParameters.Add(New SqlParameter("@Inv_LlantaRefaccion", asignacion.Inv_LlantaRefaccion))
            datos.sqlParameters.Add(New SqlParameter("@Inv_Llaves", asignacion.Inv_Llaves))
            datos.sqlParameters.Add(New SqlParameter("@Inv_ManualConductor", asignacion.Inv_ManualConductor))
            datos.sqlParameters.Add(New SqlParameter("@Inv_Radio", asignacion.Inv_Radio))
            datos.sqlParameters.Add(New SqlParameter("@Inv_Reflejantes", asignacion.Inv_Reflejantes))

            datos.sqlParameters.Add(New SqlParameter("@IdMotivoTerminacion", asignacion.IdMotivoTerminacion))
            datos.sqlParameters.Add(New SqlParameter("@Term_Comentarios", asignacion.Term_Comentarios))

            'Graba Asignación
            datos.Comando_SP("Update_Terminar_Asignacion @Id, @IdMotivoTerminacion, @Term_Comentarios, @Inv_ManualConductor,@Inv_Herramientas,@Inv_LLantaRefaccion,@Inv_Reflejantes,@Inv_Extintor,@Inv_Radio,@Inv_Encendedor,@Inv_Llaves,@Inv_Gato,@Inv_AireAcondicionado", res.DataTable)

            ' Graba la auditoria
            Auditoria.Registrar(usr, 42, asignacion.Id)

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

            Logs.LogError("ControlVehicular.vb", "Update_Terminar_Asignacion", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function


    Public Function Consultar_Asignacion_Actual(ByVal usr As String, ByVal IdVehiculo As Integer) As Resultado
        Dim res As New Resultado
        Dim datos As New ObjDatos


        Try

            datos.sqlParameters.Add(New SqlParameter("@IdVehiculo", IdVehiculo))

            'Consulta motivos de asignación
            datos.Consulta_SP("Select_Asignacion_Actual @IdVehiculo", res.DataTable)


        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("ControlVehicular.vb", "Select_Asignacion_Actual", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
        Return res
    End Function


    Public Function Consultar_Vehiculo_Asignado_A(ByVal usr As String, ByVal IdVehiculo As Integer) As Resultado
        Dim res As New Resultado
        Dim datos As New ObjDatos


        Try

            datos.sqlParameters.Add(New SqlParameter("@IdVehiculo", IdVehiculo))

            'Consulta motivos de asignación
            datos.Consulta_SP("Select_Vehiculo_Asignado_A @IdVehiculo", res.DataTable)


        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("ControlVehicular.vb", "Select_Vehiculo_Asignado_A", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
        Return res
    End Function


#End Region

#Region "Envio y Recepción"

    Public Function Insertar_Envio(ByVal usr As String, ByVal envio As CEnvio) As Resultado
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try

            ' Valida que sean datos correctos
            If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(envio.ComentariosSalida) Then
                Throw New Validacion_Exception("Comentarios")
            End If
            If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(envio.Conductor) Then
                Throw New Validacion_Exception("Conductor")
            End If
            If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(envio.PersonaAutoriza) Then
                Throw New Validacion_Exception("Persona que Autoriza")
            End If


            'Se crean parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@IdVehiculo", envio.IdVehiculo))
            datos.sqlParameters.Add(New SqlParameter("@KmSalida", envio.KmSalida))
            datos.sqlParameters.Add(New SqlParameter("@IdNivelGasolinaSalida", envio.IdNivelGasolinaSalida))
            datos.sqlParameters.Add(New SqlParameter("@Comentarios", envio.ComentariosSalida))
            datos.sqlParameters.Add(New SqlParameter("@Conductor", envio.Conductor))
            datos.sqlParameters.Add(New SqlParameter("@IdRegion", envio.IdRegion))
            datos.sqlParameters.Add(New SqlParameter("@IdCoordinacion", envio.IdCoordinacion))
            datos.sqlParameters.Add(New SqlParameter("@IdAlmacen", envio.IdAlmacen))
            datos.sqlParameters.Add(New SqlParameter("@IdEstado", envio.IdEstado))
            datos.sqlParameters.Add(New SqlParameter("@Inv_AireAcondicionado", envio.Inv_AireAcondicionado))
            datos.sqlParameters.Add(New SqlParameter("@Inv_Encendedor", envio.Inv_Encendedor))
            datos.sqlParameters.Add(New SqlParameter("@Inv_Extintor", envio.Inv_Extintor))
            datos.sqlParameters.Add(New SqlParameter("@Inv_Gato", envio.Inv_Gato))
            datos.sqlParameters.Add(New SqlParameter("@Inv_Herramientas", envio.Inv_Herramientas))
            datos.sqlParameters.Add(New SqlParameter("@Inv_LlantaRefaccion", envio.Inv_LlantaRefaccion))
            datos.sqlParameters.Add(New SqlParameter("@Inv_Llaves", envio.Inv_Llaves))
            datos.sqlParameters.Add(New SqlParameter("@Inv_ManualConductor", envio.Inv_ManualConductor))
            datos.sqlParameters.Add(New SqlParameter("@Inv_Radio", envio.Inv_Radio))
            datos.sqlParameters.Add(New SqlParameter("@Inv_Reflejantes", envio.Inv_Reflejantes))
            datos.sqlParameters.Add(New SqlParameter("@TipoEnvio", envio.TipoEnvio))
            datos.sqlParameters.Add(New SqlParameter("@PersonaAutoriza", envio.PersonaAutoriza))
            datos.sqlParameters.Add(New SqlParameter("@CostoTraslado", envio.CostoTraslado))

            'Graba Envio
            datos.Comando_SP("Insert_Envio @IdVehiculo, @KmSalida, @IdNivelGasolinaSalida, @Comentarios, @Conductor, @IdRegion, @IdCoordinacion, @IdAlmacen, @IdEstado, @Inv_ManualConductor,@Inv_Herramientas,@Inv_LLantaRefaccion,@Inv_Reflejantes,@Inv_Extintor,@Inv_Radio,@Inv_Encendedor,@Inv_Llaves,@Inv_Gato,@Inv_AireAcondicionado, @TipoEnvio, @PersonaAutoriza, @CostoTraslado", res.DataTable)

            ''Obtiene el consecutivo generado
            envio.Id = res.DataTable.Rows(0)(2)
            res.Dato = envio.Id

            ' Graba la auditoria
            Auditoria.Registrar(usr, 43, envio.IdVehiculo & "-" & envio.Id)

        Catch ex As Validacion_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

            If datos.TransaccionIniciada Then datos.Rollback()

        Catch ex As Exception
            ''Se regresan y registran los datos del error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

            If datos.TransaccionIniciada Then datos.Rollback()

            Logs.LogError("ControlVehicular.vb", "Insert_Envio", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function


    Public Function Actualizar_Envio(ByVal usr As String, ByVal envio As CEnvio) As Resultado
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try

            ' Valida que sean datos correctos
            If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(envio.ComentariosSalida) Then
                Throw New Validacion_Exception("Comentarios")
            End If
            If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(envio.Conductor) Then
                Throw New Validacion_Exception("Conductor")
            End If
            If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(envio.PersonaAutoriza) Then
                Throw New Validacion_Exception("Persona Autoriza")
            End If


            'Se crean parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@Id", envio.Id))
            datos.sqlParameters.Add(New SqlParameter("@KmSalida", envio.KmSalida))
            datos.sqlParameters.Add(New SqlParameter("@IdNivelGasolinaSalida", envio.IdNivelGasolinaSalida))
            datos.sqlParameters.Add(New SqlParameter("@Comentarios", envio.ComentariosSalida))
            datos.sqlParameters.Add(New SqlParameter("@Conductor", envio.Conductor))
            datos.sqlParameters.Add(New SqlParameter("@IdRegion", envio.IdRegion))
            datos.sqlParameters.Add(New SqlParameter("@IdCoordinacion", envio.IdCoordinacion))
            datos.sqlParameters.Add(New SqlParameter("@IdAlmacen", envio.IdAlmacen))
            datos.sqlParameters.Add(New SqlParameter("@IdEstado", envio.IdEstado))
            datos.sqlParameters.Add(New SqlParameter("@Inv_AireAcondicionado", envio.Inv_AireAcondicionado))
            datos.sqlParameters.Add(New SqlParameter("@Inv_Encendedor", envio.Inv_Encendedor))
            datos.sqlParameters.Add(New SqlParameter("@Inv_Extintor", envio.Inv_Extintor))
            datos.sqlParameters.Add(New SqlParameter("@Inv_Gato", envio.Inv_Gato))
            datos.sqlParameters.Add(New SqlParameter("@Inv_Herramientas", envio.Inv_Herramientas))
            datos.sqlParameters.Add(New SqlParameter("@Inv_LlantaRefaccion", envio.Inv_LlantaRefaccion))
            datos.sqlParameters.Add(New SqlParameter("@Inv_Llaves", envio.Inv_Llaves))
            datos.sqlParameters.Add(New SqlParameter("@Inv_ManualConductor", envio.Inv_ManualConductor))
            datos.sqlParameters.Add(New SqlParameter("@Inv_Radio", envio.Inv_Radio))
            datos.sqlParameters.Add(New SqlParameter("@Inv_Reflejantes", envio.Inv_Reflejantes))
            datos.sqlParameters.Add(New SqlParameter("@TipoEnvio", envio.TipoEnvio))
            datos.sqlParameters.Add(New SqlParameter("@PersonaAutoriza", envio.PersonaAutoriza))
            datos.sqlParameters.Add(New SqlParameter("@CostoTraslado", envio.CostoTraslado))

            'Graba Envio
            datos.Comando_SP("Update_Envio @Id, @KmSalida, @IdNivelGasolinaSalida, @Comentarios, @Conductor, @IdRegion, @IdCoordinacion, @IdAlmacen, @IdEstado, @Inv_ManualConductor,@Inv_Herramientas,@Inv_LLantaRefaccion,@Inv_Reflejantes,@Inv_Extintor,@Inv_Radio,@Inv_Encendedor,@Inv_Llaves,@Inv_Gato,@Inv_AireAcondicionado, @TipoEnvio, @PersonaAutoriza, @CostoTraslado", res.DataTable)

            ' Graba la auditoria
            Auditoria.Registrar(usr, 44, envio.Id)

        Catch ex As Validacion_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

            If datos.TransaccionIniciada Then datos.Rollback()

        Catch ex As Exception
            ''Se regresan y registran los datos del error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

            If datos.TransaccionIniciada Then datos.Rollback()

            Logs.LogError("ControlVehicular.vb", "Update_Envio", ex.Message, ex.StackTrace)
        End Try
        Return res

    End Function


    Public Function Consultar_Envio_Actual(ByVal usr As String, ByVal IdVehiculo As Integer) As Resultado
        Dim res As New Resultado
        Dim datos As New ObjDatos


        Try

            datos.sqlParameters.Add(New SqlParameter("@IdVehiculo", IdVehiculo))

            'Consulta motivos de asignación
            datos.Consulta_SP("Select_Envio_Actual @IdVehiculo", res.DataTable)


        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("ControlVehicular.vb", "Select_Envio_Actual", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
        Return res
    End Function


    Public Function Actualizar_Recepcion(ByVal usr As String, ByVal recepcion As CRecepcion) As Resultado
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try

            ' Valida que sean datos correctos
            If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(recepcion.ComentariosEntrada) Then
                Throw New Validacion_Exception("Comentarios")
            End If

            'Se crean parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@Id", recepcion.Id))
            datos.sqlParameters.Add(New SqlParameter("@IdVehiculo", recepcion.IdVehiculo))
            datos.sqlParameters.Add(New SqlParameter("@KmEntrada", recepcion.KmEntrada))
            datos.sqlParameters.Add(New SqlParameter("@IdNivelGasolinaEntrada", recepcion.IdNivelGasolinaEntrada))
            datos.sqlParameters.Add(New SqlParameter("@Comentarios", recepcion.ComentariosEntrada))
            datos.sqlParameters.Add(New SqlParameter("@Inv_AireAcondicionado", recepcion.Inv_AireAcondicionado))
            datos.sqlParameters.Add(New SqlParameter("@Inv_Encendedor", recepcion.Inv_Encendedor))
            datos.sqlParameters.Add(New SqlParameter("@Inv_Extintor", recepcion.Inv_Extintor))
            datos.sqlParameters.Add(New SqlParameter("@Inv_Gato", recepcion.Inv_Gato))
            datos.sqlParameters.Add(New SqlParameter("@Inv_Herramientas", recepcion.Inv_Herramientas))
            datos.sqlParameters.Add(New SqlParameter("@Inv_LlantaRefaccion", recepcion.Inv_LlantaRefaccion))
            datos.sqlParameters.Add(New SqlParameter("@Inv_Llaves", recepcion.Inv_Llaves))
            datos.sqlParameters.Add(New SqlParameter("@Inv_ManualConductor", recepcion.Inv_ManualConductor))
            datos.sqlParameters.Add(New SqlParameter("@Inv_Radio", recepcion.Inv_Radio))
            datos.sqlParameters.Add(New SqlParameter("@Inv_Reflejantes", recepcion.Inv_Reflejantes))
            'Graba Envio
            datos.Comando_SP("Update_Recepcion @Id, @IdVehiculo, @KmEntrada, @IdNivelGasolinaEntrada, @Comentarios, @Inv_ManualConductor,@Inv_Herramientas,@Inv_LLantaRefaccion,@Inv_Reflejantes,@Inv_Extintor,@Inv_Radio,@Inv_Encendedor,@Inv_Llaves,@Inv_Gato,@Inv_AireAcondicionado", res.DataTable)

            ' Graba la auditoria
            Auditoria.Registrar(usr, 45, recepcion.Id)

        Catch ex As Validacion_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

            If datos.TransaccionIniciada Then datos.Rollback()

        Catch ex As Exception
            ''Se regresan y registran los datos del error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

            If datos.TransaccionIniciada Then datos.Rollback()

            Logs.LogError("ControlVehicular.vb", "Update_Recepcion", ex.Message, ex.StackTrace)
        End Try
        Return res

    End Function
#End Region

#Region "Gastos"


    Public Function Insertar_Gasto(ByVal usr As String, ByVal gasto As CGasto) As Resultado
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try

            'Se crean parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@IdVehiculo", gasto.IdVehiculo))
            datos.sqlParameters.Add(New SqlParameter("@IdTipoGasto", gasto.IdTipoGasto))
            datos.sqlParameters.Add(New SqlParameter("@MontoGasto", gasto.MontoGasto))
            datos.sqlParameters.Add(New SqlParameter("@MontoRecuperado", gasto.MontoRecuperado))

            'Graba Asignación
            datos.Comando_SP("Insert_Gastos @IdVehiculo, @IdTipoGasto, @MontoGasto, @MontoRecuperado", res.DataTable)

            ' Graba la auditoria
            Auditoria.Registrar(usr, 46, gasto.IdVehiculo & "-" & gasto.IdTipoGasto & "-" & gasto.MontoGasto)

        Catch ex As Validacion_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

            If datos.TransaccionIniciada Then datos.Rollback()

        Catch ex As Exception
            ''Se regresan y registran los datos del error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

            If datos.TransaccionIniciada Then datos.Rollback()

            Logs.LogError("ControlVehicular.vb", "Insert_Gastos", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function


    Public Function Autorizar_Gasto(ByVal usr As String, ByVal gasto As CGasto_Autorizacion) As Resultado
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try

            'Se crean parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@IdVehiculo", gasto.IdVehiculo))
            datos.sqlParameters.Add(New SqlParameter("@Consec", gasto.Consec))
            datos.sqlParameters.Add(New SqlParameter("@Autorizar", gasto.Autorizacion))
            datos.sqlParameters.Add(New SqlParameter("@Comentarios", gasto.Comentarios))

            'Graba Asignación
            datos.Comando_SP("Autorizar_Gasto @IdVehiculo, @Consec, @Autorizar, @Comentarios", res.DataTable)

            ' Graba la auditoria
            Auditoria.Registrar(usr, 63, gasto.IdVehiculo & "-" & gasto.Consec)

        Catch ex As Validacion_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

            If datos.TransaccionIniciada Then datos.Rollback()

        Catch ex As Exception
            ''Se regresan y registran los datos del error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

            If datos.TransaccionIniciada Then datos.Rollback()

            Logs.LogError("ControlVehicular.vb", "Autorizar_Gasto", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function


    Public Function Consultar_Gastos(ByVal usr As String, ByVal IdVehiculo As Integer, ByVal Consec As Integer) As Resultado
        Dim res As New Resultado
        Dim datos As New ObjDatos


        Try

            datos.sqlParameters.Add(New SqlParameter("@IdVehiculo", IdVehiculo))
            datos.sqlParameters.Add(New SqlParameter("@Consec", Consec))

            'Consulta motivos de asignación
            datos.Consulta_SP("Select_Gastos @IdVehiculo, @Consec", res.DataTable)


        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("ControlVehicular.vb", "Select_Gastos", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
        Return res
    End Function


    Public Function Consultar_Gastos_Pendientes_Autorizar(ByVal usr As String) As Resultado
        Dim res As New Resultado
        Dim datos As New ObjDatos


        Try

            datos.Consulta_SP("Select_Gastos_Pendientes_Autorizacion", res.DataTable)

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("ControlVehicular.vb", "Select_Gastos_Pendientes_Autorizacion", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
        Return res
    End Function

#End Region

#Region "Mantenimientos"

    Public Function Insertar_Mantenimientos(usr As String, mantenimiento As CMantenimiento) As Resultado
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            ' Valida que sean datos correctos
            ''If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(mantenimiento.Observaciones) Then
            ''    Throw New Validacion_Exception("Observaciones")
            ''End If

            'Se crean parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@IdVehiculo", mantenimiento.IdVehiculo))
            datos.sqlParameters.Add(New SqlParameter("@IdTipo", mantenimiento.IdTipo))
            datos.sqlParameters.Add(New SqlParameter("@TipoPeriodicidad", mantenimiento.TipoPeriodicidad))
            datos.sqlParameters.Add(New SqlParameter("@KmProgramacion", mantenimiento.KmProgramacion))
            datos.sqlParameters.Add(New SqlParameter("@FecPrevista", mantenimiento.FecPrevista))
            datos.sqlParameters.Add(New SqlParameter("@Cada_N_Km", mantenimiento.Cada_N_Km))
            datos.sqlParameters.Add(New SqlParameter("@Observaciones", mantenimiento.Observaciones))

            datos.Comando_SP("Insert_Mantenimientos @IdVehiculo, @IdTipo, @TipoPeriodicidad, @FecPrevista, @KmProgramacion, @Cada_N_Km, @Observaciones", res.DataTable)

            'Devuelve el Consec del mantenimiento que se grabo (si fueron varios, devuelve el primero)
            res.Dato = res.DataTable.Rows(0)(2)

            ' Graba la auditoria
            Auditoria.Registrar(usr, 51, mantenimiento.IdVehiculo & " - " & res.Dato)
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
            Logs.LogError("ControlVehicular.vb", "Insert_Mantenimientos", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function


    Public Function Actualizar_Mantenimientos(usr As String, mantenimiento As CMantenimiento) As Resultado
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            ' Valida que sean datos correctos
            Select Case mantenimiento.fase
                Case EnumFasesMantenimiento.Programacion
                    'If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(mantenimiento.Observaciones) Then
                    '    Throw New Validacion_Exception("Observaciones")
                    'End If

                Case EnumFasesMantenimiento.Activacion
                    'If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(mantenimiento.ObservacionesActivacion) Then
                    '    Throw New Validacion_Exception("Observaciones")
                    'End If

                Case EnumFasesMantenimiento.Terminacion
                    'If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(mantenimiento.FolioFactura) Then
                    '    Throw New Validacion_Exception("Folio de la Factura")
                    'End If
                    'If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(mantenimiento.FolioSolicitudPago) Then
                    '    Throw New Validacion_Exception("Folio de Solicitud de Pago")
                    'End If
                    'If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(mantenimiento.ComentariosTerminacion) Then
                    '    Throw New Validacion_Exception("Comentarios")
                    'End If
            End Select

            datos.sqlParameters.Add(New SqlParameter("@fase", mantenimiento.fase))

            'Se crean parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@IdVehiculo", mantenimiento.IdVehiculo))
            datos.sqlParameters.Add(New SqlParameter("@Consec", mantenimiento.Consec))
            ' Programacion
            datos.sqlParameters.Add(New SqlParameter("@IdTipo", mantenimiento.IdTipo))
            datos.sqlParameters.Add(New SqlParameter("@TipoPeriodicidad", mantenimiento.TipoPeriodicidad))
            datos.sqlParameters.Add(New SqlParameter("@KmProgramacion", mantenimiento.KmProgramacion))
            datos.sqlParameters.Add(New SqlParameter("@FecPrevista", mantenimiento.FecPrevista))
            datos.sqlParameters.Add(New SqlParameter("@Cada_N_Km", mantenimiento.Cada_N_Km))
            datos.sqlParameters.Add(New SqlParameter("@Observaciones", mantenimiento.Observaciones))
            ' Activacion
            datos.sqlParameters.Add(New SqlParameter("@IdProveedor", mantenimiento.IdProveedor))
            datos.sqlParameters.Add(New SqlParameter("@ObservacionesActivacion", mantenimiento.ObservacionesActivacion))
            datos.sqlParameters.Add(New SqlParameter("@KmActivacion", mantenimiento.KmActivacion))
            datos.sqlParameters.Add(New SqlParameter("@IdNivelGasolinaActivacion", mantenimiento.IdNivelGasolinaActivacion))
            datos.sqlParameters.Add(New SqlParameter("@PrecioTotalActivacion", mantenimiento.PrecioTotalActivacion))
            ' Terminacion
            datos.sqlParameters.Add(New SqlParameter("@TipoTerminacion", mantenimiento.TipoTerminacion))
            datos.sqlParameters.Add(New SqlParameter("@FolioFactura", mantenimiento.FolioFactura))
            datos.sqlParameters.Add(New SqlParameter("@IdIva", mantenimiento.IdIVA))
            datos.sqlParameters.Add(New SqlParameter("@TotalFactura", mantenimiento.TotalFactura))
            datos.sqlParameters.Add(New SqlParameter("@FecRecepcionFactura", mantenimiento.FecRecepcionFactura))
            datos.sqlParameters.Add(New SqlParameter("@FecEntregaFactura", mantenimiento.FecEntregaFactura))
            datos.sqlParameters.Add(New SqlParameter("@FolioSolicitudPago", mantenimiento.FolioSolicitudPago))
            datos.sqlParameters.Add(New SqlParameter("@KmTerminacion", mantenimiento.KmTerminacion))
            datos.sqlParameters.Add(New SqlParameter("@IdNivelGasolinaTerminacion", mantenimiento.IdNivelGasolinaTerminacion))
            datos.sqlParameters.Add(New SqlParameter("@FecPromesa", mantenimiento.FecPromesa))
            datos.sqlParameters.Add(New SqlParameter("@FecReal", mantenimiento.FecReal))
            datos.sqlParameters.Add(New SqlParameter("@ComentariosTerminacion", mantenimiento.ComentariosTerminacion))

            datos.BeginTransaction()

            ' Graba los datos del mantenimiento
            datos.Comando_SP_Transaccion("Update_Mantenimientos @fase, @IdVehiculo, @Consec, @IdTipo, @TipoPeriodicidad, @FecPrevista, @KmProgramacion, @Cada_N_Km, @Observaciones, @IdProveedor, @ObservacionesActivacion, @KmActivacion, @IdNivelGasolinaActivacion, @PrecioTotalActivacion, @TipoTerminacion, @FolioFactura,@IdIva, @TotalFactura, @FecRecepcionFactura, @FecEntregaFactura, @FolioSolicitudPago, @KmTerminacion, @IdNivelGasolinaTerminacion, @FecPromesa, @FecReal, @ComentariosTerminacion", res.DataTable)

            If mantenimiento.fase = EnumFasesMantenimiento.Activacion Then
                ' Borra los conceptos
                datos.sqlParameters.Add(New SqlParameter("@IdVehiculo", mantenimiento.IdVehiculo))
                datos.sqlParameters.Add(New SqlParameter("@Consec", mantenimiento.Consec))
                datos.Comando_SP_Transaccion("Delete_Mantenimientos_Detalle @IdVehiculo, @Consec", res.DataTable)

                ' Inserta cada uno de los conceptos
                For i As Integer = 0 To mantenimiento.IdConcepto.Length - 1
                    datos.sqlParameters.Add(New SqlParameter("@IdVehiculo", mantenimiento.IdVehiculo))
                    datos.sqlParameters.Add(New SqlParameter("@Consec", mantenimiento.Consec))
                    datos.sqlParameters.Add(New SqlParameter("@IdConcepto", mantenimiento.IdConcepto(i)))
                    datos.sqlParameters.Add(New SqlParameter("@Precio", mantenimiento.PrecioConcepto(i)))
                    datos.sqlParameters.Add(New SqlParameter("@Descripcion", mantenimiento.TextoConcepto(i)))
                    ' Graba el dato
                    datos.Comando_SP_Transaccion("Insert_Mantenimientos_Detalle @IdVehiculo, @Consec, @IdConcepto, @Precio, @Descripcion", res.DataTable)
                Next
            End If

            ' Hace el commit 
            datos.Commit()

            ' Graba la auditoria
            Auditoria.Registrar(usr, 52, mantenimiento.IdVehiculo & " - " & mantenimiento.Consec)
        Catch ex As Validacion_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

            ' Hace el rollback
            If datos.TransaccionIniciada Then datos.Rollback()

        Catch ex As Exception
            ''Se regresan y registran los datos del error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("ControlVehicular.vb", "Update_Mantenimientos", ex.Message, ex.StackTrace)
            ' Hace el rollback
            If datos.TransaccionIniciada Then datos.Rollback()
        End Try
        Return res
    End Function

    Public Function Cancelar_Mantenimientos(usr As String, mantenimiento As CMantenimiento_Cancelacion) As Resultado
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(mantenimiento.Observaciones) Then
                Throw New Validacion_Exception("Observaciones")
            End If

            'Se crean parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@IdVehiculo", mantenimiento.IdVehiculo))
            datos.sqlParameters.Add(New SqlParameter("@Consec", mantenimiento.Consec))
            datos.sqlParameters.Add(New SqlParameter("@Observaciones", mantenimiento.Observaciones))

            ' Graba los datos del mantenimiento
            datos.Comando_SP("Cancelar_Mantenimientos @IdVehiculo, @Consec, @Observaciones", res.DataTable)

            ' Graba la auditoria
            Auditoria.Registrar(usr, 53, mantenimiento.IdVehiculo & " - " & mantenimiento.Consec)
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
            Logs.LogError("ControlVehicular.vb", "Cancelar_Mantenimientos", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function

    Public Function Consultar_Mantenimientos(usr As String, mantenimiento As CBusqueda_Mantenimiento) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos


        Try
            'Se crean parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@NumMantenimiento", mantenimiento.NumMantenimiento))
            datos.sqlParameters.Add(New SqlParameter("@Placas", mantenimiento.Placas))
            datos.sqlParameters.Add(New SqlParameter("@Serie", mantenimiento.Serie))
            datos.sqlParameters.Add(New SqlParameter("@ProveedorAsignado", mantenimiento.ProveedorAsignado))
            datos.sqlParameters.Add(New SqlParameter("@MVA", mantenimiento.MVA))

            datos.Consulta_SP("Select_Mantenimientos @NumMantenimiento, @Placas, @Serie, @ProveedorAsignado, @MVA", res.DataTable)


        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("ControlVehicular.vb", "Select_Mantenimientos", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
        Return res
    End Function

    Public Function Consultar_Mantenimientos_Completos(usr As String, IdVehiculo As Integer, Consec As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos


        Try

            'Se crean parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@IdVehiculo", IdVehiculo))
            datos.sqlParameters.Add(New SqlParameter("@Consec", Consec))

            datos.Consulta_SP("Select_Mantenimientos_Completos @IdVehiculo, @Consec", res.DataTable)


        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("ControlVehicular.vb", "Select_Mantenimientos_Completos", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
        Return res
    End Function

    Public Function Consultar_Mantenimientos_Detalle(usr As String, IdVehiculo As Integer, Consec As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos


        Try

            'Se crean parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@IdVehiculo", IdVehiculo))
            datos.sqlParameters.Add(New SqlParameter("@Consec", Consec))

            datos.Consulta_SP("Select_Mantenimientos_Detalle @IdVehiculo, @Consec", res.DataTable)


        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("ControlVehicular.vb", "Select_Mantenimientos_Detalle", ex.Message, ex.StackTrace)
        End Try

        Return res
    End Function


    Public Function Consultar_Mantenimientos_Pendientes_Autorizar(usr As String) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try

            datos.Consulta_SP("Select_Mantenimientos_Pendientes_Autorizacion", res.DataTable)

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("ControlVehicular.vb", "Select_Mantenimientos_Pendientes_Autorizacion", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
        Return res
    End Function


    Public Function Autorizar_Mantenimientos(usr As String, mantenimiento As CMantenimiento_Autorizacion) As Resultado
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            '' Valida que sean datos correctos
            'If Not Validacion.Solo_LetrasDigitosEspaciosSimbolos(mantenimiento.Comentarios) Then
            '    Throw New Validacion_Exception("Comentarios")
            'End If

            'Se crean parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@IdVehiculo", mantenimiento.IdVehiculo))
            datos.sqlParameters.Add(New SqlParameter("@Consec", mantenimiento.Consec))
            ' Programacion
            datos.sqlParameters.Add(New SqlParameter("@Autorizacion", mantenimiento.Autorizacion))
            datos.sqlParameters.Add(New SqlParameter("@Comentarios", mantenimiento.Comentarios))

            ' Graba los datos del mantenimiento
            datos.Comando_SP("Autorizar_Mantenimientos @IdVehiculo, @Consec, @Autorizacion, @Comentarios", res.DataTable)

            ' Graba la auditoria
            Auditoria.Registrar(usr, 54, mantenimiento.IdVehiculo & " - " & mantenimiento.Consec)
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
            Logs.LogError("ControlVehicular.vb", "Autorizar_Mantenimientos", ex.Message, ex.StackTrace)
        End Try
        Return res
    End Function


#End Region

#Region "Servicios"

    Public Function Consultar_ReporteServicio(NumServicio As Integer) As Resultado
        'Se crean objetos de Resultado2 y para llamar ws
        Dim res As New Resultado
        Dim datos As New ObjDatos

        Try
            'Se crean parámetros y se manda llamar el ws
            datos.sqlParameters.Add(New SqlParameter("@NumServicio", NumServicio))

            datos.Consulta_SP("Select_ReporteServicio @NumServicio", res.DataTable)

        Catch ex As AccesoDatos_Exception
            'Se regresan y registran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message

        Catch ex As Exception
            'Se regresan y resgistran los datos de error
            res.Estatus = Estatus.Error
            res.ErrorDesc = ex.Message
            Logs.LogError("ControlVehicular.vb", "Select_ReporteServicio", ex.Message, ex.StackTrace)
        End Try
        'Regresa Resultado2
        Return res
    End Function

#End Region
End Class

