﻿Imports System.Data.SqlClient

Public Class InventarioDAO
    '''''''''''''''''''''''''''''''
    '' Objetos de Acceso a Datos ''
    '''''''''''''''''''''''''''''''
    Public conn As SqlConnection = Nothing
    Public adapter As SqlDataAdapter = Nothing
    Public dataReader As SqlDataReader = Nothing
    Public dataSet As DataSet = Nothing
    Public dataRow As DataRow = Nothing
    Public transaction As SqlTransaction = Nothing
    Public fecha As Date
    Public errorDesc As String
    Public sqlConnectionString As String
    Public mostrarErrores As Boolean = False
    Dim inLogger As ILogger = New ILogger()

    Public Function insInventario(ByVal inventario As inventarioVO) As Boolean

        Dim conexion As New SqlConnection(System.Configuration.ConfigurationManager.AppSettings("SQLConecction"))
        Dim objTransac As SqlTransaction = Nothing
        Try
            conexion.Open()
            Dim command As New SqlCommand("spr_Ins_Inventario", conexion)
            objTransac = conexion.BeginTransaction
            command.CommandType = CommandType.StoredProcedure

            command.Parameters.Add("intID", SqlDbType.Int).Direction = ParameterDirection.InputOutput
            command.Parameters("intID").Value = 0
            command.Parameters.AddWithValue("@strTipoBeneficia", inventario.TipoBeneficia)
            command.Parameters.AddWithValue("@strEmpresa", inventario.Empresa)
            command.Parameters.AddWithValue("@strMoneda", inventario.Moneda)
            command.Parameters.AddWithValue("@dtmFechaEmision", inventario.FechaEmision)
            command.Parameters.AddWithValue("@strProyecto", inventario.Proyecto)
            command.Parameters.AddWithValue("@strReferencia", inventario.Referencia)
            command.Parameters.AddWithValue("@strObservaciones", inventario.Observaciones)
            command.Parameters.AddWithValue("@strAlmacen", inventario.Almacen)
            command.Parameters.AddWithValue("@strConcepto", inventario.Concepto)
            command.Parameters.AddWithValue("@intSucursal", inventario.Sucursal)

            'Parametros de la Tabla InventarioD
            With command
                .Transaction = objTransac
                .ExecuteNonQuery()
            End With

            Dim id = command.Parameters("intID").Value

            Dim comman As New SqlCommand("spr_Ins_InventarioDetalle", conexion)
            comman.CommandType = CommandType.StoredProcedure
            Dim renglon As Integer = 0
            For Each inventarioDetalle In inventario.listaInventarioDetalle
                renglon = renglon + 1
                comman.Parameters.AddWithValue("@intID", id)
                comman.Parameters.AddWithValue("@intRenglon", renglon)
                comman.Parameters.AddWithValue("@strArticulo", inventarioDetalle.Articulo)
                comman.Parameters.AddWithValue("@dblCantidad", inventarioDetalle.Cantidad)
                comman.Parameters.AddWithValue("@dblCosto", inventarioDetalle.Costo)
                comman.Parameters.AddWithValue("@strCentroCostos", inventarioDetalle.CentroCostos)
                comman.Parameters.AddWithValue("@strUnidad", inventarioDetalle.Unidad)

                With comman
                    .Transaction = objTransac
                    .ExecuteNonQuery()
                End With
                comman.Parameters.Clear()
            Next
            objTransac.Commit()
            Return True
        Catch ex As DataException
            objTransac.Rollback()
            inLogger.insError("Error en metodo: insInventario()", ex.Message)
            Return False
        Catch ex As Exception
            objTransac.Rollback()
            inLogger.insError("Error en metodo: insInventario()", ex.Message)
            Return False
        Finally
            conexion.Close()
            conexion.Dispose()
        End Try
    End Function
End Class