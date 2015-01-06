Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports Telerik.Web.UI

Public Class CMenu

    ''' <summary>
    ''' Respuesta que contiene los datos del menú
    ''' </summary>
    ''' <remarks></remarks>
    Private respMenu As New Resultado

    ' devuelve la URL de destino para una funcion/acción dada
    Public Function ObtenerUrl(IdFuncion As Integer, IdAccion As Integer) As String
        For Each dr As DataRow In respMenu.DataTable.Rows
            If dr("IdFuncion") = IdFuncion And Not IsDBNull(dr("IdAccion")) Then
                If dr("IdAccion") = IdAccion Then
                    Return dr("Url") & "?IdAccion=" & dr("IdAccion")
                End If
            End If
        Next

        Return ""
    End Function

    ''' <summary>
    ''' Consulta los elementos que se deben poner en el menú
    ''' </summary>
    ''' <param name="usr"></param>
    ''' <param name="IdGrupo"></param>
    ''' <remarks></remarks>
    Public Sub CargarMenu(usr As Integer, IdGrupo As Integer)
        Dim serv As New Datos_ControlAcceso

        ' Consulta los elementos del menú   
        respMenu = serv.Consultar_Menu(usr, IdGrupo)
    End Sub

    Public Sub PreparaMenuNormal(ByRef menu As RadMenu, ByRef permisos As Permisos, ByRef session As HttpSessionState)
        Dim dr As DataRow
        'Dim IdFuncion As Integer

        ' Quita todos los elementos
        menu.Items.Clear()

        ' Genera de nuevo el menú
        For i As Integer = 0 To respMenu.DataTable.Rows.Count - 1

            ' toma el renglon actual
            dr = respMenu.DataTable.Rows(i)

            If dr("IdPadre") = -1 Then
                ' es un nodo raíz, lo agrega directamente
                'menu.Items.Add(New RadMenuItem(dr("Texto"), dr("IdFuncion")))
                Dim rmi As New RadMenuItem
                'rmi.Text = "" 'dr("Texto")
                rmi.Attributes.Add("IdPadre", dr("IdMenu"))
                rmi.NavigateUrl = dr("Url")
                rmi.ImageUrl = dr("UrlImagen")

                menu.Items.Add(rmi)

                If session("IdModulo") = dr("IdFuncion") Then
                    menu.Items(menu.Items.Count - 1).ExpandMode = True
                End If
            End If
        Next
                'Else
                '' Busca el nodo padre 
                'For Each item As RadMenuItem In menu.Items

                '    If dr("IdPadre") = 1 And dr("IdFuncion") > 200 And dr("IdFuncion") < 300 And item.Index = 0 Then
                '        ' Agrega el nodo al menú    
                '        item.Items.Add(New RadMenuItem(dr("Texto"), dr("IdFuncion")))

                '    End If

                '    If dr("IdPadre") = 2 And dr("IdFuncion") > 400 And dr("IdFuncion") < 500 And item.Index = 1 Then
                '        ' Agrega el nodo al menú            
                '        item.Items.Add(New RadMenuItem(dr("Texto"), dr("IdFuncion")))
                '    End If


                '    If dr("IdPadre") = 3 And dr("IdFuncion") > 500 And dr("IdFuncion") < 600 And item.Index = 2 Then
                '        ' Agrega el nodo al menú    
                '        item.Items.Add(New RadMenuItem(dr("Texto"), dr("IdFuncion")))
                '    End If


                '    If dr("IdPadre") = 5 And dr("IdFuncion") > 100 And dr("IdFuncion") < 200 And item.Index = 3 Then
                '        ' Agrega el nodo al menú    
                '        item.Items.Add(New RadMenuItem(dr("Texto"), dr("IdFuncion")))
                '    End If

                '    ' Agrega las acciones que puede realizar, para eso hace un barrido del datatable
                '    IdFuncion = dr("IdFuncion")

                'Next
                '    End If
                'Next

        'For i As Integer = 0 To respMenu.DataTable.Rows.Count - 1
        '    ' toma el renglon actual
        '    dr = respMenu.DataTable.Rows(i)

        '    If dr("IdPadre") <> -1 Then
        '        ' Busca el nodo padre 
        '        For Each item As RadMenuItem In menu.Items
        '            For Each itemNuevo As RadMenuItem In item.Items

        '                If dr("IdPadre") = 1 And dr("IdFuncion") > 200 And dr("IdFuncion") < 300 And item.Index = 0 Then

        '                    Select Case dr("IdFuncion")
        '                        Case 201
        '                            If dr("Texto") = "Vehículos" Then
        '                                'itemNuevo.Items(itemNuevo.Index).NavigateUrl = ObtenerUrl(dr("IdFuncion"), dr("IdAccion"))
        '                                'itemNuevo.Items(dr("Texto")).NavigateUrl = ObtenerUrl(dr("IdFuncion"), dr("IdAccion"))
        '                                itemNuevo.NavigateUrl = ObtenerUrl(dr("IdFuncion"), dr("IdAccion"))
        '                                'itemNuevo(itemNuevo.Items).NavigateUrl = ObtenerUrl(dr("IdFuncion"), dr("IdAccion"))
        '                            End If

        '                        Case 202
        '                            If dr("Texto") = "Pólizas" Then
        '                                itemNuevo.NavigateUrl = ObtenerUrl(dr("IdFuncion"), dr("IdAccion"))
        '                            End If

        '                        Case 203
        '                            itemNuevo.NavigateUrl = ObtenerUrl(dr("IdFuncion"), dr("IdAccion"))
        '                        Case 204
        '                            itemNuevo.NavigateUrl = ObtenerUrl(dr("IdFuncion"), dr("IdAccion"))
        '                        Case 205
        '                            itemNuevo.NavigateUrl = ObtenerUrl(dr("IdFuncion"), dr("IdAccion"))

        '                    End Select

        '                End If

        '                '********************************************************************************************************
        '                If dr("IdPadre") = 2 And dr("IdFuncion") > 400 And dr("IdFuncion") < 500 And item.Index = 1 Then
        '                    Select Case dr("IdFuncion")
        '                        Case 401
        '                            If dr("Texto") = "Salidas Improductivas" Then
        '                                itemNuevo.NavigateUrl = ObtenerUrl(dr("IdFuncion"), dr("IdAccion"))
        '                            End If

        '                        Case 402
        '                            If dr("Texto") = "Servicios" Then
        '                                itemNuevo.NavigateUrl = ObtenerUrl(dr("IdFuncion"), dr("IdAccion"))
        '                            End If

        '                        Case 403
        '                            If dr("Texto") = "Contratos" Then
        '                                itemNuevo.NavigateUrl = ObtenerUrl(dr("IdFuncion"), dr("IdAccion"))
        '                            End If
        '                    End Select

        '                End If

        '                '********************************************************************************************************
        '                If dr("IdPadre") = 3 And dr("IdFuncion") > 500 And dr("IdFuncion") < 600 And item.Index = 2 Then
        '                    itemNuevo.NavigateUrl = ObtenerUrl(dr("IdFuncion"), dr("IdAccion"))
        '                End If

        '                If dr("IdPadre") = 5 And dr("IdFuncion") > 100 And dr("IdFuncion") < 200 And item.Index = 3 Then
        '                    itemNuevo.NavigateUrl = ObtenerUrl(dr("IdFuncion"), dr("IdAccion"))
        '                End If

        '            Next
        '        Next
        '    End If
        'Next

        'For Each item As RadMenuItem In menu.Items
        '    For Each itemNuevo As RadMenuItem In item.Items
        '        itemNuevo.NavigateUrl = ObtenerUrl(402, 1)
        '    Next
        'Nextw

    End Sub
    ' ''' <summary>
    ' ''' Prepara el menú principal
    ' ''' </summary>
    ' ''' <param name="menu"></param>
    ' ''' <remarks></remarks>
    'Public Sub PreparaMenu(ByRef menu As RadTreeView, ByRef permisos As Permisos, ByRef session As HttpSessionState)
    '    Dim dr As DataRow
    '    Dim IdFuncion As Integer

    '    ' Quita todos los elementos
    '    menu.Nodes.Clear()

    '    ' Genera de nuevo el menú
    '    For i As Integer = 0 To respMenu.DataTable.Rows.Count - 1
    '        ' toma el renglon actual
    '        dr = respMenu.DataTable.Rows(i)

    '        If dr("IdPadre") = -1 Then
    '            ' es un nodo raíz, lo agrega directamente
    '            menu.Nodes.Add(New RadTreeNode(dr("Texto"), dr("IdFuncion")))

    '            If session("IdModulo") = dr("IdFuncion") Then
    '                menu.Nodes(menu.Nodes.Count - 1).Expanded = True
    '            End If
    '        Else
    '            ' Busca el nodo padre 
    '            For Each item As RadTreeNode In menu.Nodes
    '                If item.Value = dr("IdPadre") Then
    '                    ' Agrega el nodo al menú
    '                    item.Nodes.Add(New RadTreeNode(dr("Texto"), dr("IdFuncion")))

    '                    If session("IdFuncion") = dr("IdFuncion") Then
    '                        item.Nodes(item.Nodes.Count - 1).Expanded = True
    '                    End If

    '                    ' Agrega las acciones que puede realizar, para eso hace un barrido del datatable
    '                    IdFuncion = dr("IdFuncion")
    '                    Do
    '                        If dr("IdAccion") <> -1 And Not IsDBNull(dr("Accion")) Then
    '                            item.Nodes(item.Nodes.Count - 1).Nodes.Add(New RadTreeNode(dr("Accion"), dr("IdAccion")))
    '                        End If

    '                        i += 1
    '                        If i = respMenu.DataTable.Rows.Count Then Exit For ' si llega al final del datatable se sale del for
    '                        dr = respMenu.DataTable.Rows(i)
    '                    Loop While IdFuncion = dr("IdFuncion") ' Mientras siga siendo la misma opción del menú (ejemplo: Control Vehicular - Pólizas)

    '                    i -= 1
    '                    Exit For
    '                End If
    '            Next
    '        End If
    '    Next

    'End Sub
    Public Sub PreparaMenu2(ByRef menu As RadMenu, ByRef permisos As Permisos, ByRef session As HttpSessionState)
        'Dim rdi As New RadMenuItem
        Dim dr As DataRow
        Dim IdFuncion As Integer

        ' Quita todos los elementos
        menu.Items.Clear()

        'Dim RadMenuI As New RadMenuItem
        ' Genera de nuevo el menú
        For i As Integer = 0 To respMenu.DataTable.Rows.Count - 1
            ' toma el renglon actual
            dr = respMenu.DataTable.Rows(i)

            'If dr("IdPadre") = -1 Then
            If dr("IdPadre") = session("Padre") And dr("Texto") <> "" Then
                ' es un nodo raíz, lo agrega directamente

                'se crean objetos items pertenecientes al menú

                Dim rmi As New RadMenuItem
                'rmi.Text = dr("Texto")
                rmi.Attributes.Add("onmouseover", "SetImage(2)")
                rmi.ImageUrl = dr("UrlImagen")
                rmi.NavigateUrl = dr("Url")
                rmi.Attributes.Add("IdAccion", dr("IdAccion"))
                rmi.Attributes.Add("IdFuncion", dr("IdFuncion"))
                menu.Items.Add(rmi)
                'menu.Items.Add(New RadMenuItem(dr("Texto"), ObtenerUrl(dr("IdFuncion"), dr("IdAccion"))))
                'menu.Attributes.Add("IdAccion", dr("IdAccion"))
                'menu.Items.Add(New RadMenuItem(dr("Texto"), dr("IdAccion")))
                'rdi.Attributes("IdAccion") = dr("IdAccion")
                'menu.Items.Add(rdi)

                'rdi.na()
                If session("IdModulo") = dr("IdFuncion") Then
                    menu.Items(menu.Items.Count - 1).ExpandMode = True
                End If
            Else
                ' Busca el nodo padre 
                For Each item As RadMenuItem In menu.Items
                    If session("IdFuncion") = dr("IdFuncion") Then
                        menu.Items(menu.Items.Count - 1).ExpandMode = True
                    End If

                    ' Agrega las acciones que puede realizar, para eso hace un barrido del datatable
                    IdFuncion = dr("IdFuncion")
                    Do
                        If dr("IdAccion") <> -1 And Not IsDBNull(dr("Accion")) And dr("IdPadre") = session("Padre") Then
                            'menu.Items(menu.Items.Count - 1).Items.Add(New RadMenuItem(dr("Accion"), dr("IdAccion")))
                            'menu.Items(menu.Items.Count - 1).Items.Add(New RadMenuItem(dr("Accion"), ObtenerUrl(dr("IdFuncion"), dr("IdAccion"))))
                            'rdi.Attributes("IdAccion") = dr("IdAccion")
                            'menu.Items.Add(rdi)
                            Dim rmii As New RadMenuItem
                            'rmii.Text = dr("Accion")
                            rmii.ImageUrl = dr("UrlImagen")
                            rmii.NavigateUrl = dr("Url")
                            rmii.Attributes.Add("IdAccion", dr("IdAccion"))
                            rmii.Attributes.Add("IdFuncion", dr("IdFuncion"))
                            menu.Items(menu.Items.Count - 1).Items.Add(rmii)
                        End If

                        i += 1
                        If i = respMenu.DataTable.Rows.Count Then Exit For ' si llega al final del datatable se sale del for
                        dr = respMenu.DataTable.Rows(i)
                    Loop While IdFuncion = dr("IdFuncion") ' Mientras siga siendo la misma opción del menú (ejemplo: Control Vehicular - Pólizas)

                    i -= 1
                    Exit For
                    'End If
                Next
            End If
        Next

    End Sub

End Class
