Imports ACCESO
Imports LOGICA
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Data.OleDb

Public Class frmGenerarDeudasMensuales
    Dim tv As New DevComponents.AdvTree.AdvTree
    Dim vf As New clsValidateForm
    Dim n As TreeNode
    Dim idcalle As Integer
    Dim calle As String
    Private Sub frmGenerarDeudasMensuales_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            clsJunta.LoadCombo(cmbJunta)
            If (frmPrincipal.userSystem.idInterfaz = 4) Then
                cmbJunta.SelectedValue = frmPrincipal.userSystem.idJunta
                cmbJunta.Enabled = False
            End If
            clsCentroPoblado.LoadComboADD(cmbCPoblado)
            cmbCPoblado.SelectedValue = 0

            clsCalles.LoadComboADD(cmbCalles)
            cmbCalles.SelectedValue = 0

            clsAnioTarifa.LoadCombo(cmbAnio)
            cmbAnio.SelectedIndex = 0
            clsMes.LoadCombo(cmbMes)
            cmbMes.SelectedValue = 1

            cmbSubTipoTarifa.SelectedIndex = 0

            clsTipoTarifa.LoadComboFijos(cmbSubTipoTarifa, cmbAnio.Text)
            CargaGrid()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbCalles_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCalles.SelectedIndexChanged
        Try
            CargaLista()
        Catch ex As Exception

        End Try
    End Sub
 

    Private Sub btnFiltrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFiltrar.Click
        CargaLista()
    End Sub

    Private Sub CargaLista()
        Dim obj As New clsDeudasMensuales
        If chkUnicas.Checked = False Then
            obj.ListTree(tvPredios, cmbCalles.SelectedValue, cmbMes.SelectedValue, cmbAnio.SelectedValue, cmbSubTipoTarifa.SelectedValue)
            tvPredios.Focus()
        End If
        If chkUnicas.Checked = True Then
            obj.ListTreeUnicas(tvPredios, cmbCalles.SelectedValue, cmbMes.SelectedValue, cmbAnio.SelectedValue, cmbSubTipoTarifa.SelectedValue)
            tvPredios.Focus()
        End If

        'For Each N As DevComponents.AdvTree.Node In tvEjecucion.Nodes
        '    tvEjecucion.SelectedNode = tvEjecucion.Nodes(N.Index)
        '    tvEjecucion.Nodes(tvEjecucion.SelectedNode.Index).Expand()
        'Next
        lblRegistrosCobranza.Text = String.Format("{0} registros encontrados", tvPredios.Nodes.Count)
    End Sub

    'Private Sub cmbSubTipoTarifa_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSubTipoTarifa.SelectedIndexChanged
    '    Try
    '        txtValorSubTarifa.Text = cmbSubTipoTarifa.SelectedItem(3).ToString
    '        'txtMonto.Text = cmbSubTipoTarifa.SelectedItem(5).ToString
    '        CargaLista()

    '    Catch ex As Exception

    '    End Try
    'End Sub
    Private Sub CargaServiciosGenerados()
        Dim obj As New clsDeudasMensuales
        Dim anioc As Integer
        Dim mesc As Integer

        'anioc = cmbAnio.SelectedValue
        'mesc = cmbMes.SelectedValue

        If cmbMes.SelectedValue = 1 Then

            mesc = 12
            anioc = cmbAnio.SelectedValue - 1

        Else
            mesc = cmbMes.SelectedValue - 1
            anioc = cmbAnio.SelectedValue

        End If


        If chkUnicas.Checked = True Then
            obj.ListServiciosG(tvPredios, cmbCalles.SelectedValue, mesc, anioc, cmbSubTipoTarifa.SelectedValue)
            tvPredios.Focus()
        End If
        'If chkUnicas.Checked = True Then
        '    obj.ListTreeUnicas(tvPredios, cmbCalles.SelectedValue, cmbMes.SelectedValue, cmbAnio.SelectedValue, cmbSubTipoTarifa.SelectedValue)
        '    tvPredios.Focus()
        'End If

        lblRegistrosCobranza.Text = String.Format("{0} registros encontrados", tvPredios.Nodes.Count)
    End Sub
    Private Sub cmbSubTipoTarifa_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSubTipoTarifa.SelectedIndexChanged
        Try
            txtValorSubTarifa.Text = cmbSubTipoTarifa.SelectedItem(3).ToString
            ''txtMonto.Text = cmbSubTipoTarifa.SelectedItem(5).ToString
            'CargaLista()

        Catch ex As Exception

        End Try
    End Sub

    Public Function Filtrar() As DataTable
        'Try

        'idj = cmbJunta.SelectedValue

        calle = cmbCalles.SelectedValue
        Dim dt As New DataTable
        'filtro de usuarios
        Dim condicion As String = ""


        If (cmbCalles.SelectedValue <> 0) Then
            condicion &= "and idCalle = " & calle & ""
        Else
            condicion &= "and idCalle like '%'"
        End If

        'dt = (" and vIdJuntaUsuario='" & idj & "'" & condicion, "1")
        dt = clsPredios.List(condicion, "1")
        'fin filtro
        'txtNroPredios.Text = Val(dt.Rows.Count)
        Return dt
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
    End Function
    Private Sub CargaGrid()
        '    Dim dt As New DataTable
        '    dt = clsPredios.List(" ORDER BY vApePaterno, vApeMaterno, vUsuario")
        '    gridPredios.DataSource = dt
        '    If gridPredios.Rows.Count > 0 Then
        '        Dim dcol As New DataGridViewCheckBoxColumn()
        '        gridPredios.Columns.Insert(0, dcol)
        '        gridPredios.Columns(0).Width = 30

        '        gridPredios.Columns(1).Width = 80
        '        gridPredios.Columns(2).Width = 80
        '        gridPredios.Columns(3).Width = 100
        '        gridPredios.Columns(5).Width = 150
        '        gridPredios.Columns(2).Visible = False
        '        gridPredios.Columns(3).Visible = False
        '        gridPredios.Columns(4).Visible = False
        '    End If
        '    txtNroPredios.Text = Val(dt.Rows.Count)
    End Sub

    Private Sub btnGeneraDeudas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGeneraDeudas.Click
        Dim obj As New clsDeudasMensuales
        Dim userSystem As New ACCESO.User
        Dim numerror As String
        numerror = ""
        For Each nodo As DevComponents.AdvTree.Node In tvPredios.Nodes  '     TreeNode   Nodos
            tvPredios.SelectedNode = tvPredios.Nodes(nodo.Index)
            obj.IdJAS = nodo.Cells(3).Text.ToString
            obj.Año = cmbAnio.SelectedValue
            obj.Mes = cmbMes.SelectedValue
            obj.Predio = nodo.Cells(4).Text.ToString
            'obj.DetalleDeuda = 
            obj.TipoDeuda = 2
            obj.TipoTarifa = cmbSubTipoTarifa.SelectedValue
            obj.Monto = txtValorSubTarifa.Text
            obj.Saldo = txtValorSubTarifa.Text
            obj.Redondeo = 0
            obj.Volumen = 0
            obj.Concepto = cmbSubTipoTarifa.Text
            obj.FechaDeuda = Today
            'obj.FechaPago = DBNull.Value
            obj.Pagado = 0
            userSystem = frmPrincipal.userSystem
            obj.UsuarioSys = UCase(userSystem.usuario)
            obj.Congelado = 0
            obj.Interes = 0
            If (nodo.Checked) Then
                If Not obj.Insert(cmbCalles.SelectedValue, cmbMes.SelectedValue, cmbAnio.SelectedValue) Then
                    numerror = numerror & "Deuda Generada para el predio " & nodo.Cells(7).Text.ToString & " del usuario " & nodo.Cells(2).Text.ToString & " no se genero correctamente" & Chr(13)
                End If
            End If

        Next
        obj.ListTree(tvPredios, cmbCalles.SelectedValue, cmbMes.SelectedValue, cmbAnio.SelectedValue, cmbSubTipoTarifa.SelectedValue)
        tvPredios.Focus()

        If numerror.Length > 0 Then
            MsgBox("Ocurrio un error mientras se generaba la deuda. Se cancelo el proceso de Importación" & Chr(13) & numerror, MsgBoxStyle.Critical)
        Else
            MsgBox("Deuda generada satisfactoriamente", MsgBoxStyle.Information)
        End If

    End Sub

    Private Sub btnVisualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVisualizar.Click
        frmDeudas.IdCalle = cmbCalles.SelectedValue
        frmDeudas.Año = cmbAnio.SelectedValue
        frmDeudas.Mes = cmbMes.SelectedValue
        frmDeudas.TipoTarifa = cmbSubTipoTarifa.SelectedValue
        frmDeudas.ShowDialog()

    End Sub

    Private Sub chkSelectAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSelectAll.CheckedChanged
        For Each n1 As DevComponents.AdvTree.Node In tvPredios.Nodes
            If (n1.Enabled) Then
                n1.Checked = chkSelectAll.Checked
            End If
        Next
    End Sub

    Private Sub cmbJunta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbJunta.SelectedIndexChanged

    End Sub

    Private Sub cmbAnio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAnio.SelectedIndexChanged
        clsTipoTarifa.LoadComboFijos(cmbSubTipoTarifa, cmbAnio.Text)
    End Sub

    Private Sub Bar1_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bar1.ItemClick

    End Sub

    Private Sub Bar2_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bar2.ItemClick

    End Sub

    Private Sub cmbCPoblado_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCPoblado.SelectedIndexChanged
        Try

            clsCalles.LoadComboCallesPredio(cmbCalles, "where padPredio.idCP= " & cmbCPoblado.SelectedValue & " ")
            
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbMes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMes.SelectedIndexChanged
        Try
            CargaLista()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtValorSubTarifa_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtValorSubTarifa.TextChanged

    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        Try
            CargaServiciosGenerados()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub chkUnicas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkUnicas.CheckedChanged

    End Sub
End Class