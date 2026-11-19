Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Data.OleDb
Imports ACCESO
Imports LOGICA
Imports COBSER.Menu
Public Class frmAsignarMedidor
    Public TipoTarifa As Integer
    Public idcalle As Integer
    Dim idj As String
    Dim vf As New clsValidateForm
    Dim idsector As Integer

    Dim calle As String

    Dim nroRegistros As Integer


    Private Sub txtUAMaterno_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If (vf.startValidation) Then
            gridPredios.DataSource = Filtrar()
        End If
    End Sub
    Private Sub txtUAMaterno_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub frmAsignarMedidor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            clsJunta.LoadCombo(cmbJunta)
            If (frmPrincipal.userSystem.idInterfaz = 4) Then
                cmbJunta.SelectedValue = frmPrincipal.userSystem.idJunta
                cmbJunta.Enabled = False
            End If

            'clsCalles.LoadComboADD(cmbCalles)
            'cmbCalles.SelectedValue = frmPrediosServicios.cmbCalles.SelectedValue

            clsCentroPoblado.LoadComboADD(cmbCPoblado)
            cmbCPoblado.SelectedValue = 0
            clsCalles.LoadComboCallesPredio(cmbCalles)
            cmbCalles.SelectedValue = 0
            idcalle = cmbCalles.SelectedValue
            TipoTarifa = cmbServicio.SelectedValue

            'clsTipoTarifa.LoadComboFijos(cmbServicio, Year(ACCESO.Conexion.getDateServer))

            'CargaGrid()
            txtObserv.Text = ""

        Catch ex As Exception

        End Try
    End Sub

    Private Sub CargaGrid()
        Dim dt As New DataTable

        If chkUnicas.Checked = False Then
            dt = clsAsignarServicios.ListaPrediosServicio(idcalle, TipoTarifa)
            gridPredios.DataSource = dt
        End If
        If chkUnicas.Checked = True Then
            dt = clsAsignarServicios.ListaPrediosServicioUnico(idcalle, TipoTarifa)
            gridPredios.DataSource = dt
        End If
        'dt = clsAsignarServicios.ListaPrediosServicio(idcalle, TipoTarifa)
        'gridPredios.DataSource = dt
        If gridPredios.Rows.Count > 0 Then
            Dim dcol As New DataGridViewCheckBoxColumn()
            gridPredios.Columns.Insert(0, dcol)
            gridPredios.Columns(0).Width = 25

            gridPredios.Columns(1).Width = 80
            gridPredios.Columns(2).Width = 80
            gridPredios.Columns(3).Width = 50
            gridPredios.Columns(4).Width = 60
            gridPredios.Columns(5).Width = 150
            gridPredios.Columns(6).Width = 50
            gridPredios.Columns(7).Width = 50
            gridPredios.Columns(6).Visible = False
            gridPredios.Columns(7).Visible = False
            gridPredios.Columns(8).Visible = False
            gridPredios.Columns(2).Visible = False
            'gridPredios.Columns(3).Visible = False
            gridPredios.Columns(13).Visible = False
        End If
        txtNroPredios.Text = Val(dt.Rows.Count)
    End Sub

    Public Function Filtrar() As DataTable
        'Try

        'idj = cmbJunta.SelectedValue

        calle = cmbCalles.SelectedValue
        TipoTarifa = cmbServicio.SelectedValue
        Dim dt As New DataTable
        'filtro de usuarios
        Dim condicion As String = ""

        If (cmbCalles.SelectedValue <> 0) Then
            condicion &= "and idCalle = " & calle & ""
        Else
            condicion &= "and idCalle like '%'"
        End If

        If (cmbServicio.SelectedValue) <> 0 Then
            condicion &= " and  iIdTipoTarifa = " & TipoTarifa & ""
        End If
        'dt = (" and vIdJuntaUsuario='" & idj & "'" & condicion, "1")
        'dt = clsAsignarServicios.ListaPrediosServicio(condicion)
        'fin filtro
        'dt.Columns.Add("TipoServicio")
        'dt.Columns.Add("idTipo")
        txtNroPredios.Text = Val(dt.Rows.Count)
        Return dt

        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
    End Function

    Private Sub cmbsector_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If (vf.startValidation) Then
                gridPredios.DataSource = Filtrar()
            End If

            'CargaGrid()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbCalles_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCalles.SelectedIndexChanged
        Try

            idcalle = cmbCalles.SelectedValue
            If idcalle = 0 Then
                idcalle = "%"
            Else
                idcalle = cmbCalles.SelectedValue
                'cmbCalles.SelectedValue = idcalle

            End If

            'If (vf.startValidation) Then
            'gridPredios.DataSource = Filtrar(cmbCalles.SelectedValue)

            gridPredios.Columns.Clear()


            CargaGrid()

            'dt.Columns.Add("TipoServicio")
            'End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtUAPaterno_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If (vf.startValidation) Then
            gridPredios.DataSource = Filtrar()
        End If
    End Sub

    Private Sub txtUAPaterno_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txtDNI_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If (vf.startValidation) Then
            gridPredios.DataSource = Filtrar()
        End If
    End Sub

    Private Sub txtDNI_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txtUNombre_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If (vf.startValidation) Then
            gridPredios.DataSource = Filtrar()
        End If
    End Sub

    Private Sub txtUNombre_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub



    Private Sub gridPredios_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridPredios.CellContentClick

        'Dim c As New Conexio
        ''Dim sql As String
        ''Dim DT As New DataTable
        'Dim valor_correlativo_celda As Integer

        'Dim valor_de_celda As Integer

        'If gridPredios.SelectedRows.Count > 0 Then

        If (e.ColumnIndex = 0) Then

            ''MsgBox("Estado: " & Me.gridPredios.Rows(e.RowIndex).Cells(" ").Value)
            'gridPredios.Columns(0).ReadOnly = True
            gridPredios.Rows(e.RowIndex).Cells(0).Value = Not gridPredios.Rows(e.RowIndex).Cells(0).Value
        End If

        'If (e.ColumnIndex = 0) Then

        '    'MsgBox("Estado: " & Me.gridPredios.Rows(e.RowIndex).Cells(" ").Value)
        '    gridPredios.Columns(0).ReadOnly = True
        '    ''gridPredios.Rows(e.RowIndex).Cells(0).Value = gridPredios.Rows(e.RowIndex).Cells(0).Value
        '    For i As Integer = 0 To Me.gridPredios.Rows.Count - 1
        '        If gridPredios.Rows(i).Cells(0).Value = True Then
        '            gridPredios.Rows(i).Cells(0).Value = False
        '        Else
        '            gridPredios.Rows(i).Cells(0).Value = True
        '        End If
        '    Next
        'End If
    End Sub

    Private Sub gridPredios_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridPredios.CellEndEdit
        If (e.ColumnIndex = 0) Then

            ''MsgBox("Estado: " & Me.gridPredios.Rows(e.RowIndex).Cells(" ").Value)
            'gridPredios.Columns(0).ReadOnly = True
            gridPredios.Rows(e.RowIndex).Cells(0).Value = gridPredios.Rows(e.RowIndex).Cells(0).Value
        End If
    End Sub

    Private Sub Bar1_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bar1.ItemClick

    End Sub

    Private Sub btnFiltrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFiltrar.Click

        'CargaLista()

        Try
            Dim obj As New clsAsignarServicios
            Dim dt As New DataTable
            If (vf.startValidation) Then
                'gridPredios.DataSource = Filtrar()
                'dt = obj.ListaPrediosServicio(cmbCalles.SelectedValue, cmbServicio.SelectedValue)
                'gridPredios.DataSource = dt
                gridPredios.Columns.Clear()

                CargaGrid()

                For Each r As DataGridViewRow In gridPredios.Rows
                    r.Cells(0).Value = True
                    r.Cells(14).Value = cmbServicio.Text
                    r.Cells(15).Value = cmbServicio.SelectedValue

                Next
                
            End If
        Catch ex As Exception

        End Try


    End Sub
    Private Sub CargaLista()
        Dim obj As New clsAsignarServicios

        clsAsignarServicios.ListaPrediosServicio(cmbCalles.SelectedValue, cmbServicio.SelectedValue)

        'For Each N As DevComponents.AdvTree.Node In tvEjecucion.Nodes
        '    tvEjecucion.SelectedNode = tvEjecucion.Nodes(N.Index)
        '    tvEjecucion.Nodes(tvEjecucion.SelectedNode.Index).Expand()
        'Next

    End Sub

    Private Sub ButtonItem11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        Dim obj As New clsAsignarServicios
        Dim userSystem As New ACCESO.User
        Dim numerror As String
        numerror = ""

        'If gridPredios.Item(15, gridPredios.CurrentRow.Index).Value <> "" Then

        For Each fila As DataGridViewRow In gridPredios.Rows
            'If fila.Cells(15).Value = "" Then
            'End If
            obj.vIdJas = fila.Cells(13).Value
            obj.idpredio = fila.Cells(3).Value
            'obj.idTipoTarifa = fila.Cells(15).Value
            obj.idTipoTarifa = cmbServicio.SelectedValue
            obj.Referencia = cmbServicio.Text
            obj.Observaciones = txtObserv.Text
            obj.Fecha = ACCESO.Conexion.getDateServer

            userSystem = frmPrincipal.userSystem
            obj.Usuario = UCase(userSystem.usuario)
            'obj.Usuario = "ALCIRA"
            obj.Estado = 1
            If gridPredios.Item(0, fila.Index).Value = True Then

                obj.Insert(obj.idTipoTarifa, obj.Referencia)

            End If

        Next
        MsgBox("Servicio Asignado satisfactoriamente", MsgBoxStyle.Information)
        'Else
        '    MsgBox("Agregar tipo de Servicio", MsgBoxStyle.Information)
        'End If

        gridPredios.Columns.Clear()

        CargaGrid()



    End Sub
    Dim evtPress As Boolean = True

    Private Sub chkSelectAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If (evtPress) Then
        '    If (chkSelectAll.Checked) Then
        '        For Each r As DataGridViewRow In gridPredios.Rows
        '            r.Cells(0).Value = True
        '        Next
        '        nroRegistros = gridPredios.Rows.Count

        '    Else
        '        nroRegistros = 0
        '        For Each r As DataGridViewRow In gridPredios.Rows
        '            r.Cells(0).Value = False
        '        Next
        '    End If
        '    txtNroPredios.Text = nroRegistros & " Registros Seleccionado de " & gridPredios.Rows.Count
        'End If
    End Sub

    Private Sub CheckBoxItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSelectAll.Click
        If (evtPress) Then
            If (chkSelectAll.Checked) Then
                For Each r As DataGridViewRow In gridPredios.Rows
                    r.Cells(0).Value = True
                Next
                nroRegistros = gridPredios.Rows.Count

            Else
                nroRegistros = 0
                For Each r As DataGridViewRow In gridPredios.Rows
                    r.Cells(0).Value = False
                Next
            End If
            lblnro.Text = nroRegistros & " Registros Seleccionado de " & gridPredios.Rows.Count
        End If
    End Sub

    Private Sub LabelItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblnro.Click

    End Sub

    Private Sub cmbServicio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbServicio.SelectedIndexChanged

        Try
            TipoTarifa = cmbServicio.SelectedValue
            'Dim dt As New DataTable
            'dt = clsAsignarServicios.ListaPrediosServicio(cmbCalles.SelectedValue, cmbServicio.SelectedValue)
            'gridPredios.DataSource = dt
            txtValorServicio.Text = cmbServicio.SelectedItem(3).ToString

            gridPredios.Columns.Clear()

            CargaGrid()
            For Each r As DataGridViewRow In gridPredios.Rows
                r.Cells(0).Value = True
            Next
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnVisualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ButtonItem17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem17.Click
        Me.Close()

    End Sub

    Private Sub cmbCPoblado_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCPoblado.SelectedIndexChanged
        Try
            clsCalles.LoadComboCallesPredio(cmbCalles, "where padPredio.idCP= " & cmbCPoblado.SelectedValue & " ")
            'clsSector.LoadComboAdd(cmbsector)
            'cmbsector.SelectedValue = 0
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Bar5_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bar5.ItemClick

    End Sub

    Private Sub txtValorServicio_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtValorServicio.TextChanged

    End Sub

    Private Sub LabelX12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LabelX12.Click

    End Sub

    Private Sub LabelX1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LabelX1.Click

    End Sub

    Private Sub cmbTipoServicio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipoServicio.SelectedIndexChanged
        If cmbTipoServicio.SelectedIndex = 0 Then
            clsTipoTarifa.LoadComboVolumen(cmbServicio, Year(ACCESO.Conexion.getDateServer))
        End If

        If cmbTipoServicio.SelectedIndex = 1 Then
            clsTipoTarifa.LoadComboAlcantarillado(cmbServicio, Year(ACCESO.Conexion.getDateServer))
        End If

        If cmbTipoServicio.SelectedIndex = 2 Then
            clsTipoTarifa.LoadComboMedidor(cmbServicio, Year(ACCESO.Conexion.getDateServer))
        End If
    End Sub
End Class