Imports LOGICA
Imports ACCESO
Public Class frmEstructuraSMA
    Public anio As Integer
    Public idJunta As String
    Public idComision As Integer
    Private nodo As Integer
    Dim idx As Integer = -1
    Dim ndx As DevComponents.AdvTree.Node
    Dim cdx As DevComponents.AdvTree.Cell
    Dim msg As String


    Private Sub frmEstructuraSMA_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'clsEstructuraSMA.EstructuraApertura(tvEstructura, anio, idJunta, idComision)
        'clsEstructuraSMA.ExpandeNivel(tvEstructura.Nodes(0), 1)
        Try

            msg = "Condición N:" & Chr(13)
            msg = msg & " 1. Compara el dato propio del mes con el valor anual." & Chr(13)
            msg = msg & " 2. Compara el valor acumulado con el valor anual." & Chr(13)
            msg = msg & " 3. Compara los datos mes a mes" & Chr(13)
            LblLeyenda.Text = msg
            CargaArbol()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub CargaArbol()
        Dim n2 As New DevComponents.AdvTree.Node
        Dim cdt1_1 As DevComponents.AdvTree.Cell
        Dim cdt1_2 As DevComponents.AdvTree.Cell
        Dim cdt1_3 As DevComponents.AdvTree.Cell
        Dim cdt1_4 As DevComponents.AdvTree.Cell
        Dim cdt1_5 As DevComponents.AdvTree.Cell
        Dim cdt1_6 As DevComponents.AdvTree.Cell
        Dim cdt1_7 As DevComponents.AdvTree.Cell
        Dim cdt1_8 As DevComponents.AdvTree.Cell
        Dim cdt1_9 As DevComponents.AdvTree.Cell
        Dim cdt1_10 As DevComponents.AdvTree.Cell

        n2 = New DevComponents.AdvTree.Node
        cdt1_1 = New DevComponents.AdvTree.Cell
        cdt1_2 = New DevComponents.AdvTree.Cell
        cdt1_3 = New DevComponents.AdvTree.Cell
        cdt1_4 = New DevComponents.AdvTree.Cell
        cdt1_5 = New DevComponents.AdvTree.Cell
        cdt1_6 = New DevComponents.AdvTree.Cell
        cdt1_7 = New DevComponents.AdvTree.Cell
        cdt1_8 = New DevComponents.AdvTree.Cell
        cdt1_9 = New DevComponents.AdvTree.Cell
        cdt1_10 = New DevComponents.AdvTree.Cell

        n2.Cells.Add(cdt1_1)
        n2.Cells.Add(cdt1_2)
        n2.Cells.Add(cdt1_3)
        n2.Cells.Add(cdt1_4)
        n2.Cells.Add(cdt1_5)
        n2.Cells.Add(cdt1_6)
        n2.Cells.Add(cdt1_7)
        n2.Cells.Add(cdt1_8)
        n2.Cells.Add(cdt1_9)
        n2.Cells.Add(cdt1_10)

        AdvTree1.Nodes.Clear()
        clsEstructuraSMA.CreaEstructuraArbol(AdvTree1, n2, 0, idJunta, idComision, anio)
        clsEstructuraSMA.ExpandeNivel(AdvTree1.Nodes(0), 1)
        AdvTree1.GridRowLines = True

        'grabado de el arbol
        Dim c As New ACCESO.Conexion
        If (c.Connect) Then
            For Each nodo As DevComponents.AdvTree.Node In AdvTree1.Nodes  '     TreeNode   Nodos
                AdvTree1.SelectedNode = AdvTree1.Nodes(nodo.Index)
                Grabar(c, AdvTree1.SelectedNode)
            Next
            c.Close()
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        ' ''Dim Nodos As TreeNodeCollection
        ''Dim c As New ACCESO.Conexion
        ' '' recorre los nodos en forma recursiva hasta que no haya mas nodos 
        ''If MsgBox("Al gurdar se reasignara loas valores iniciales", MsgBoxStyle.Information + MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.Yes Then
        ''    If (c.Connect) Then
        ''        For Each nodo As DevComponents.AdvTree.Node In AdvTree1.Nodes  '     TreeNode   Nodos
        ''            AdvTree1.SelectedNode = AdvTree1.Nodes(nodo.Index)
        ''            Grabar(c, AdvTree1.SelectedNode)
        ''        Next
        ''        clsEstructuraSMA.AperturaPesos(0, idJunta, idComision, anio)
        ''        c.Close()
        ''    End If
        ''    MsgBox("Estructura registrada satisfactoriamente", MsgBoxStyle.Information)
        ''End If
    End Sub
    Private Sub Grabar(ByVal c As ACCESO.Conexion, ByRef nodo As DevComponents.AdvTree.Node)
        Dim item As New clsEstructuraSMA(idJunta, idComision, anio, Val(nodo.Name))
        Dim dt As New DataTable
        dt = c.Query("SELECT COUNT(*) FROM EstructuraSMA WHERE vIdJuntaUsuario='" & idJunta & "' AND iIDComisionRegante='" & idComision & "' AND iAnio='" & anio & "' AND idEstructura='" & nodo.Name & "'")
        If dt.Rows(0).Item(0) = 0 Then
            'c.Query("DELETE FROM EstructuraSMA WHERE vIdJuntaUsuario='" & idJunta & "' AND iIDComisionRegante='" & idComision & "' AND iAnio='" & anio & "' AND idEstructura='" & nodo.Name & "'")
            'End If
            'If (nodo.Checked) Then
            item.DatoGeneral = ""
            item.Condicion = ""
            item.MedidaAnual = ""
            item.EstadoCalculado = ""
            item.LineaBase = 0
            item.Meta = 0
            item.Peso = 0
            item.InsertOpenConnection(c)
        Else
            'c.Query("DELETE FROM EstructuraSMA WHERE vIdJuntaUsuario='" & idJunta & "' AND iIDComisionRegante='" & idComision & "' AND iAnio='" & anio & "' AND idEstructura='" & nodo.Name & "'")

        End If
        If (nodo.Nodes.Count > 0) Then
            For Each n As DevComponents.AdvTree.Node In nodo.Nodes
                Grabar(c, n)
            Next
        End If

    End Sub

    Private Sub btnLoadAnioAnterior_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadAnioAnterior.Click
        'Dim c As New ACCESO.Conexion
        'Dim dt As New DataTable
        'Dim n() As TreeNode
        'If (c.Connect) Then
        '    For Each nodo As TreeNode In tvEstructura.Nodes
        '        nodo.Checked = False
        '    Next
        '    dt = clsEstructuraSMA.Lista(idJunta, idComision, anio - 1)
        '    For Each r As DataRow In dt.Rows
        '        n = tvEstructura.Nodes.Find(r("idEstructura").ToString(), True)
        '        n(0).Checked = True
        '    Next
        '    c.Close()
        'End If
    End Sub

    'Private Sub tvEstructura_AfterCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs)
    '    Dim n2 As TreeNode
    '    If (Not e.Node.Checked) Then
    '        For Each n As TreeNode In e.Node.Nodes
    '            n.Checked = False
    '        Next
    '    Else
    '        n2 = e.Node.Parent
    '        While Not n2 Is Nothing
    '            n2.Checked = True
    '            n2 = n2.Parent
    '        End While
    '    End If
    'End Sub

    'Private Sub tvEstructura_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs)
    '    Try
    '        nodo = e.Node.Name
    '        CargaLista()
    '        If MsgBox("Desea Ingreasr Valores", MsgBoxStyle.Question + MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.Yes Then
    '            TabControl1.SelectedTabIndex = 1

    '        End If
    '    Catch ex As Exception

    '    End Try
    'End Sub

    'Private Sub CargaLista()
    '    Dim obj As New clsEstructuraSMA(Me.idJunta, Me.idComision, Me.anio, 0)
    '    obj.ListTreeValores(tvValores, nodo)
    '    tvValores.Focus()

    'End Sub

    'Private Sub tvValores_AfterCellEditComplete(ByVal sender As Object, ByVal e As DevComponents.AdvTree.CellEditEventArgs)
    '    'validamos el registro y sino existe lo insertamos sino lo modificamos
    '    Dim c As New Conexion
    '    Dim dt As New DataTable
    '    Dim obj As New clsEstructuraSMA(Me.idJunta, Me.idComision, Me.anio, tvValores.SelectedNode.Cells(0).Text)

    '    Try
    '        If idx > 1 And idx < 5 Then

    '            If (c.Connect) Then
    '                dt = c.Query("SELECT Count(idEstructura) FROM EstructuraSMA WHERE (idEstructura=" & tvValores.SelectedNode.Cells(0).Text & ") AND (vIdJuntaUsuario = '" & Me.idJunta & "') AND (iIdComisionRegante = " & Me.idComision & ") AND (iAnio = " & Me.anio & ") ")
    '                If dt.Rows.Count > 0 Then
    '                    'actualizamos el registro
    '                    obj.LineaBase = Val(tvValores.SelectedNode.Cells(2).Text.ToString)
    '                    obj.Meta = Val(tvValores.SelectedNode.Cells(3).Text.ToString)
    '                    obj.Update()

    '                    clsEstructuraSMA.ActualizaMetas(Val(tvValores.SelectedNode.Cells(7).Text), tvValores.SelectedNode.Cells(9).Text, Val(tvValores.SelectedNode.Cells(10).Text), Val(tvValores.SelectedNode.Cells(5).Text))
    '                    clsEstructuraSMA.ActualizaLineaBase(Val(tvValores.SelectedNode.Cells(7).Text), tvValores.SelectedNode.Cells(9).Text, Val(tvValores.SelectedNode.Cells(10).Text), Val(tvValores.SelectedNode.Cells(5).Text))
    '                End If
    '                c.Close()
    '            End If
    '            tvValores.SelectedNode = ndx
    '            tvValores.SelectedNode.SelectedCell = cdx
    '            tvValores.Focus()
    '        End If

    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try

    'End Sub


    'Private Sub tvValores_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
    '    Dim i As Integer = 0
    '    Dim nivel As Integer = tvEstructura.SelectedNode.Level
    '    ndx = tvValores.SelectedNode
    '    For Each c As DevComponents.AdvTree.Cell In tvValores.SelectedNode.Cells
    '        If c.IsSelected Then
    '            cdx = c
    '            idx = i
    '            Exit For
    '        End If
    '        i += 1
    '    Next
    '    Select Case nivel
    '        Case 0 'estructura tablero visualiza capacidades
    '            Select Case idx
    '                Case 2 'lb
    '                Case 3 'meta
    '                Case 4 'peso
    '                    tvValores.SelectedNode.BeginEdit(idx)
    '            End Select

    '        Case 1 'capacidades visualiza indicadores
    '            Select Case idx
    '                Case 2 'lb
    '                Case 3 'meta
    '                Case 4 'peso
    '                    tvValores.SelectedNode.BeginEdit(idx)
    '            End Select

    '        Case 2 'indicadores visualiza medidas
    '            If idx > 1 And idx < 5 Then
    '                tvValores.SelectedNode.BeginEdit(idx)
    '            End If

    '    End Select

    'End Sub


    'Private Sub tvValores_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    'End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub AdvTree1_AfterCellEdit(ByVal sender As Object, ByVal e As DevComponents.AdvTree.CellEditEventArgs) Handles AdvTree1.AfterCellEdit
        Dim pesopadre As Double = CDbl(Val(AdvTree1.SelectedNode.Parent.Cells(8).Text.ToString))
        Dim pesos As Double = clsEstructuraSMA.SumatoriaPesosHijos(Val(AdvTree1.SelectedNode.Cells(10).Text.ToString), Me.idJunta, Me.idComision, Me.anio)
        Dim pesoold As Double = Val(AdvTree1.SelectedNode.Cells(8).Text.ToString)
        Dim pesonew As Double
        Dim sumanew As Double
        Dim newValor As Double = Val(e.NewText.ToString)
        Dim PesoMEdida As Double = Val(AdvTree1.SelectedNode.Cells(8).Text.ToString)

        If AdvTree1.SelectedNode.Level = 1 Then
            pesopadre = 100
        End If

        If idx = 6 Then 'LINEA BASE
            If Not (newValor >= 0 And newValor <= PesoMEdida) Then
                MsgBox("Ël valor ingresado se encuentra fuera de rango", MsgBoxStyle.Exclamation, Me.Text)
                e.Cancel = True
            End If
        End If

        If idx = 7 Then ' META
            If Not (newValor >= 0 And newValor <= PesoMEdida) Then
                MsgBox("Ël valor ingresado se encuentra fuera de rango", MsgBoxStyle.Exclamation, Me.Text)
                e.Cancel = True
            End If
        End If

        If idx = 8 Then
            pesonew = Val(e.NewText.ToString)
            sumanew = ((pesos - pesoold) + pesonew)
            If sumanew > pesopadre Then
                MsgBox("Ël valor ingresado supera el peso predecesor", MsgBoxStyle.Exclamation, Me.Text)
                e.Cancel = True
            End If
        End If

    End Sub

    Private Sub AdvTree1_AfterCellEditComplete(ByVal sender As Object, ByVal e As DevComponents.AdvTree.CellEditEventArgs) Handles AdvTree1.AfterCellEditComplete
        'validamos el registro y sino existe lo insertamos sino lo modificamos
        Dim c As New Conexion
        Dim dt As New DataTable
        Dim obj As New clsEstructuraSMA(Me.idJunta, Me.idComision, Me.anio, Val(AdvTree1.SelectedNode.Cells(9).Text))
        Dim sql As String = ""

        Try
            If idx > 0 And idx < 9 Then

                If (c.Connect) Then
                    dt = c.Query("SELECT Count(idEstructura) FROM EstructuraSMA WHERE (idEstructura=" & AdvTree1.SelectedNode.Cells(9).Text & ") AND (vIdJuntaUsuario = '" & Me.idJunta & "') AND (iIdComisionRegante = " & Me.idComision & ") AND (iAnio = " & Me.anio & ") ")
                    If dt.Rows(0).Item(0) > 0 Then
                        'actualizamos el registro
                        obj.DatoGeneral = IIf(AdvTree1.SelectedNode.Cells(1).Checked, 1, "")
                        obj.MedidaAnual = IIf(AdvTree1.SelectedNode.Cells(2).Checked, 1, "")
                        obj.EstadoCalculado = IIf(AdvTree1.SelectedNode.Cells(3).Checked, 1, "")
                        obj.Condicion = LCase(AdvTree1.SelectedNode.Cells(4).Text.ToString)
                        obj.CondicionN = LCase(AdvTree1.SelectedNode.Cells(5).Text)
                        obj.LineaBase = Val(AdvTree1.SelectedNode.Cells(6).Text.ToString)
                        obj.Meta = Val(AdvTree1.SelectedNode.Cells(7).Text.ToString)
                        obj.Peso = Val(AdvTree1.SelectedNode.Cells(8).Text.ToString)
                        obj.Update()

                        'clsEstructuraSMA.ActualizaPesos(Val(AdvTree1.SelectedNode.Cells(7).Text), idJunta, idComision, anio)
                        'clsEstructuraSMA.RefrescaPesos(AdvTree1.SelectedNode.PrevNode, 1, idJunta, idComision, anio)
                        If AdvTree1.SelectedNode.Level < 4 Then 'solo actualiza cuando se ingresa la lb y meta de una medida
                            clsEstructuraSMA.ActualizaMetas(Val(AdvTree1.SelectedNode.Cells(10).Text.ToString), idJunta, idComision, anio)
                            clsEstructuraSMA.ActualizaLineaBase(Val(AdvTree1.SelectedNode.Cells(10).Text.ToString), idJunta, idComision, anio)
                        End If
                    End If
                    c.Close()
                End If

                CargaArbol()
                'clsEstructuraSMA.EnsureNodeIsVisible(ndx)
                'AdvTree1.SelectedNode = ndx
                'AdvTree1.SelectedNode.SelectedCell = cdx
                'AdvTree1.Focus()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub AdvTree1_AfterCheck(ByVal sender As Object, ByVal e As DevComponents.AdvTree.AdvTreeCellEventArgs) Handles AdvTree1.AfterCheck
        'validamos el registro y sino existe lo insertamos sino lo modificamos
        Dim c As New Conexion
        Dim dt As New DataTable
        Dim obj As New clsEstructuraSMA(Me.idJunta, Me.idComision, Me.anio, Val(AdvTree1.SelectedNode.Cells(9).Text))

        Try
            'If idx > 0 And idx < 6 Then

            If (c.Connect) Then
                dt = c.Query("SELECT Count(idEstructura) FROM EstructuraSMA WHERE (idEstructura=" & AdvTree1.SelectedNode.Cells(9).Text & ") AND (vIdJuntaUsuario = '" & Me.idJunta & "') AND (iIdComisionRegante = " & Me.idComision & ") AND (iAnio = " & Me.anio & ") ")
                If dt.Rows(0).Item(0) > 0 Then
                    'actualizamos el registro
                    obj.DatoGeneral = IIf(AdvTree1.SelectedNode.Cells(1).Checked, 1, "")
                    obj.MedidaAnual = IIf(AdvTree1.SelectedNode.Cells(2).Checked, 1, "")
                    obj.EstadoCalculado = IIf(AdvTree1.SelectedNode.Cells(3).Checked, 1, "")
                    obj.Condicion = LCase(AdvTree1.SelectedNode.Cells(4).Text)
                    obj.CondicionN = LCase(AdvTree1.SelectedNode.Cells(5).Text)
                    obj.LineaBase = Val(AdvTree1.SelectedNode.Cells(6).Text.ToString)
                    obj.Meta = Val(AdvTree1.SelectedNode.Cells(7).Text.ToString)
                    obj.Peso = Val(AdvTree1.SelectedNode.Cells(8).Text.ToString)
                    obj.Update()

                    If AdvTree1.SelectedNode.Level < 4 Then 'solo actualiza cuando se ingresa la lb y meta de una medida
                        clsEstructuraSMA.ActualizaMetas(Val(AdvTree1.SelectedNode.Cells(10).Text), idJunta, idComision, anio)
                        clsEstructuraSMA.ActualizaLineaBase(Val(AdvTree1.SelectedNode.Cells(10).Text), idJunta, idComision, anio)
                    End If
                End If
                c.Close()
            End If
            'CargaArbol()
            'AdvTree1.SelectedNode = ndx
            'AdvTree1.SelectedNode.SelectedCell = cdx
            'AdvTree1.Focus()
            'End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub AdvTree1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AdvTree1.Click
        Dim c1 As New Conexion
        Dim dt As New DataTable
        Dim i As Integer
        Try
            If (c1.Connect) Then
                For Each c As DevComponents.AdvTree.Cell In AdvTree1.SelectedNode.Cells
                    If c.IsSelected Then
                        cdx = c
                        idx = i
                        Exit For
                    End If
                    i += 1
                Next
                If idx > 0 And idx <= 7 Then
                    dt = c1.Query("SELECT Count(idEstructura) FROM EstructuraSMA WHERE (idEstructura=" & AdvTree1.SelectedNode.Cells(9).Text & ") AND (vIdJuntaUsuario = '" & Me.idJunta & "') AND (iIdComisionRegante = " & Me.idComision & ") AND (iAnio = " & Me.anio & ") ")
                    If dt.Rows(0).Item(0) = 0 Then
                        Select Case idx
                            Case 1, 2, 3
                                AdvTree1.SelectedNode.Cells(idx).Checked = False
                            Case 4, 5, 6, 7, 8
                                AdvTree1.SelectedNode.Cells(idx).Text = ""
                        End Select
                        MsgBox("No se ha guardado la estructura, Guarde y luego Asigne Valores ", MsgBoxStyle.Exclamation, Me.Text)
                        Exit Sub
                    End If
                End If
                c1.Close()
            End If
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Private Sub AdvTree1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles AdvTree1.KeyPress
        If e.KeyChar = Chr(13) Then
            Dim i As Integer = 0
            Dim nivel As Integer = AdvTree1.SelectedNode.Level
            ndx = AdvTree1.SelectedNode
            For Each c As DevComponents.AdvTree.Cell In AdvTree1.SelectedNode.Cells
                If c.IsSelected Then
                    cdx = c
                    idx = i
                    Exit For
                End If
                i += 1
            Next
            Select Case nivel
                Case 1 'capacidades
                    Select Case idx
                        Case 4 'lb
                        Case 5 'meta
                        Case 8 'peso
                            AdvTree1.SelectedNode.BeginEdit(idx)
                    End Select

                Case 2 'indicadores
                    Select Case idx
                        Case 4 'lb
                        Case 5 'meta
                        Case 8 'peso
                            AdvTree1.SelectedNode.BeginEdit(idx)
                    End Select

                Case 3 'medidas
                    If idx > 3 And idx < 9 Then
                        AdvTree1.SelectedNode.BeginEdit(idx)
                    End If
                Case 4 'actividades
                    If i = 8 Then
                        AdvTree1.SelectedNode.BeginEdit(idx)
                    End If
            End Select

        End If
    End Sub

    Private Sub AdvTree1_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles AdvTree1.MouseDoubleClick
        Dim i As Integer = 0
        Dim nivel As Integer = AdvTree1.SelectedNode.Level
        ndx = AdvTree1.SelectedNode
        'MsgBox(AdvTree1.SelectedNode.Parent.Cells(6).Text)
        For Each c As DevComponents.AdvTree.Cell In AdvTree1.SelectedNode.Cells
            If c.IsSelected Then
                cdx = c
                idx = i
                Exit For
            End If
            i += 1
        Next
        Select Case nivel
            Case 1 'capacidades
                Select Case idx
                    Case 4 'lb
                    Case 5 'meta
                    Case 8 'peso
                        If frmPrincipal.userSystem.idInterfaz = 1 Then AdvTree1.SelectedNode.BeginEdit(idx)
                End Select

            Case 2 'indicadores
                Select Case idx
                    Case 4 'lb
                    Case 5 'meta
                    Case 8 'peso
                        If frmPrincipal.userSystem.idInterfaz = 1 Then AdvTree1.SelectedNode.BeginEdit(idx)
                End Select


            Case 3 'medidas
                'If idx > 2 And idx < 6 Then
                '    AdvTree1.SelectedNode.BeginEdit(idx)
                'End If
                Select Case idx
                    Case 4, 6, 7
                        AdvTree1.SelectedNode.BeginEdit(idx)
                    Case 8
                        If frmPrincipal.userSystem.idInterfaz = 1 Then AdvTree1.SelectedNode.BeginEdit(idx)
                End Select
            Case 4 'actividades
                If idx = 5 Then ' condicionN
                    AdvTree1.SelectedNode.BeginEdit(idx)
                End If
                If i = 8 Then
                    If frmPrincipal.userSystem.idInterfaz = 1 Then AdvTree1.SelectedNode.BeginEdit(idx)
                End If
        End Select

    End Sub

    Private Sub AdvTree1_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles AdvTree1.Validating

    End Sub
End Class