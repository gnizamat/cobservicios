Imports ACCESO
Imports LOGICA
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Data.OleDb
Public Class frmFacturacion
    Public ReciboF As String
    Public TIPO As Integer

    Dim tv As New DevComponents.AdvTree.AdvTree
    Dim vf As New clsValidateForm
    Dim n As TreeNode
    'Dim ifquery As String = ""

    Private Sub btnCalcularDeuda_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalcularDeuda.Click

    End Sub

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        Try
            clsJunta.LoadCombo(cmbJunta)
            If (frmPrincipal.userSystem.idInterfaz = 4) Then
                cmbJunta.SelectedValue = frmPrincipal.userSystem.idJunta
                cmbJunta.Enabled = False
            End If
            clsJunta.LoadCombo(cmbJuntaC)
            If (frmPrincipal.userSystem.idInterfaz = 4) Then
                cmbJuntaC.SelectedValue = frmPrincipal.userSystem.idJunta
                cmbJuntaC.Enabled = False
            End If
            clsCentroPoblado.LoadComboADD(cmbCPoblado)
            cmbCPoblado.SelectedValue = 0

            clsCalles.LoadComboADD(cmbCalles)
            clsAnioTarifa.LoadCombo(cmbAnio)
            cmbAnio.SelectedIndex = 0
            clsMes.LoadCombo(cmbMes)
            cmbMes.SelectedValue = 1

            clsTipoTarifa.LoadCombo(cmbSubTipoTarifa, "Where iAnioTarifa='" & cmbAnio.Text & "' ")
            cmbSubTipoTarifa.SelectedIndex = 0
            cmbCalles.SelectedValue = 1
            'cmbCalles1.SelectedValue = 1

            clsAnioTarifa.LoadCombo(cmbAnio1)
            cmbAnio1.SelectedIndex = 0
            clsMes.LoadCombo(cmbMes1)
            cmbMes1.SelectedValue = 1
            clsCaja.LoadCombo(cmbCaja)
            clsCentroPoblado.LoadComboADD(cmbCPoblado1)
            clsCalles.LoadComboADD(cmbCalles1)
            cmbCalles1.SelectedValue = 1
            cmbMes1.SelectedValue = 1

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbSubTipoTarifa_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            txtTipoTarifa.Text = cmbSubTipoTarifa.SelectedItem(4).ToString
            txtValorSubTarifa.Text = cmbSubTipoTarifa.SelectedItem(5).ToString
            'txtMonto.Text = cmbSubTipoTarifa.SelectedItem(5).ToString

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbCalles_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If (vf.startValidation) Then
                tvPredios.SelectedNode = tvPredios.Nodes(0)
                tvPredios.Focus()
                tvPredios.Nodes.Clear()
                'n = tvCanales.SelectedNode
                'tvPredios. = clsPredios.List
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ButtonItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem3.Click

    End Sub

    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
        Dim obj As New clsFacturacion
        Dim userSystem As New ACCESO.User
        'Dim Interes As Double
        Dim numerror As String
        numerror = ""
        For Each nodo As DevComponents.AdvTree.Node In tvPredios.Nodes  '     TreeNode   Nodos
            tvPredios.SelectedNode = tvPredios.Nodes(nodo.Index)
            obj.Año = nodo.Cells(5).Text.ToString
            obj.Mes = nodo.Cells(6).Text.ToString
            obj.Predio = nodo.Cells(7).Text.ToString
            obj.caja = clsCaja.obtenerCaja.id
            'obj.NroDoc = 1
            obj.Monto = nodo.Cells(3).Text.ToString
            obj.Fecha = Format(Date.Now(), "dd/MM/yyyy")

            userSystem = frmPrincipal.userSystem
            obj.Usuario = UCase(userSystem.usuario)
            'obj.Interes = nodo.Cells(3).Text.ToString
            obj.Estado = 0
            If (nodo.Checked) Then
                If Not obj.Insert(cmbCalles.SelectedValue, cmbMes.SelectedValue, cmbAnio.SelectedValue) Then ', nodo.Cells(8).Text.ToString

                    numerror = numerror & "Facturación Generada para el predio " & nodo.Cells(7).Text.ToString & " del usuario " & nodo.Cells(2).Text.ToString & " no se genero correctamente" & Chr(13)
                End If
            End If

        Next
        obj.ListTree(tvPredios, cmbCalles.SelectedValue, cmbMes.SelectedValue, cmbAnio.SelectedValue)
        tvPredios.Focus()

        If numerror.Length > 0 Then
            MsgBox("Ocurrio un error mientras se generaba la facturación. Se cancelo el proceso de Importación" & Chr(13) & numerror, MsgBoxStyle.Critical)
        Else
            MsgBox("Facturación generada satisfactoriamente", MsgBoxStyle.Information)
        End If


    End Sub

    Private Sub btnFiltrar1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFiltrar1.Click
        CargaLista()
    End Sub
    Private Sub CargaLista()
        Dim obj As New clsFacturacion
        obj.ListTree(tvPredios, cmbCalles.SelectedValue, cmbMes.SelectedValue, cmbAnio.SelectedValue)
        tvPredios.Focus()
        'For Each N As DevComponents.AdvTree.Node In tvEjecucion.Nodes
        '    tvEjecucion.SelectedNode = tvEjecucion.Nodes(N.Index)
        '    tvEjecucion.Nodes(tvEjecucion.SelectedNode.Index).Expand()
        'Next

    End Sub

    Private Sub btnconsultar1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnconsultar1.Click
        frmFaturacion.IdCalle = cmbCalles.SelectedValue
        frmFaturacion.Año = cmbAnio.SelectedValue
        frmFaturacion.Mes = cmbMes.SelectedValue
        frmFaturacion.ShowDialog()
    End Sub

    Private Sub cmbCalles_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCalles.SelectedIndexChanged
        Try
            If (vf.startValidation) Then
                tvPredios.SelectedNode = tvPredios.Nodes(0)
                tvPredios.Focus()
                tvPredios.Nodes.Clear()
                'n = tvCanales.SelectedNode
                'tvPredios. = clsPredios.List
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbSubTipoTarifa_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSubTipoTarifa.SelectedIndexChanged
        Try
            txtTipoTarifa.Text = cmbSubTipoTarifa.SelectedItem(4).ToString
            txtValorSubTarifa.Text = cmbSubTipoTarifa.SelectedItem(5).ToString
            'txtMonto.Text = cmbSubTipoTarifa.SelectedItem(5).ToString

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbJunta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbJunta.SelectedIndexChanged

    End Sub

    Private Sub LabelItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LabelItem2.Click

    End Sub

    Private Sub btnLoadPagos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadPagos.Click

        Try
            If (vf.startValidation) Then
                'dgFacturaciones.DataSource = FiltrarFacturacions()
                LoadFacturaciones()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Sub LoadFacturaciones()
        Dim anio As String
        Dim mes As Integer
        Dim montototal As Decimal
        anio = cmbAnio1.Text
        mes = cmbMes1.SelectedValue
        Dim dt As New DataTable
        dt = clsFacturacion.ListFacturacion(FiltrarFacturacions)
        dgFacturaciones.DataSource = dt
        If dgFacturaciones.Rows.Count > 0 Then
            dgFacturaciones.Columns(0).Width = 80
            dgFacturaciones.Columns(1).Width = 80
            dgFacturaciones.Columns(2).Width = 80
            dgFacturaciones.Columns(3).Width = 100
            dgFacturaciones.Columns(5).Width = 150
            dgFacturaciones.Columns(2).Visible = False
            dgFacturaciones.Columns(3).Visible = False
            dgFacturaciones.Columns(4).Visible = False
            dgFacturaciones.Columns(5).Visible = False
        End If
        For Each r As DataGridViewRow In dgFacturaciones.Rows
            montototal += CDec(r.Cells("fMontoTotal").Value)
        Next
        lblMontoTotal.Text = FormatCurrency(montototal, 2)
        lblRegistros.Text = String.Format("{0} registros encontrados", dgFacturaciones.Rows.Count)
    End Sub

    Public Function FiltrarFacturacions() As String
        Dim calle As Integer
        Dim idcp As Integer

        Dim dt As New DataTable
        Try
            Dim condicion As String = ""
            calle = cmbCalles1.SelectedValue
            idcp = cmbCPoblado1.SelectedValue

            If (cmbAnio1.Text <> "") Then
                condicion &= " where iAnioTarifa = '" & cmbAnio1.Text & "'"
            End If
            If (cmbMes1.SelectedValue <> 0) Then
                condicion &= " and idmes = " & cmbMes1.SelectedValue & " "
            End If

            If (cmbCPoblado1.SelectedValue <> 0) Then
                condicion &= " and idCP=" & idcp & ""
            Else
                condicion &= " and idCP like '%'"
            End If

            If (cmbCalles1.SelectedValue <> 0) Then
                condicion &= "and idCalle = " & calle & ""
            Else
                condicion &= "and idCalle like '%'"
            End If
            If (txtApePaterno.Text <> "") Then
                condicion &= " and vApePaterno like '" & txtApePaterno.Text & "%'"
            End If
            If (txtApeMaterno.Text <> "") Then
                condicion &= " and vApeMaterno like '" & txtApeMaterno.Text & "%'"
            End If
            If (txtNombres.Text <> "") Then
                condicion &= " and vUsuario like '" & txtNombres.Text & "%'"
            End If
            'dt = clsFacturacion.ListFacturacion(condicion)
            Return condicion
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Private Sub txtApePaterno_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtApePaterno.KeyUp
        If (vf.startValidation) Then
            LoadFacturaciones()

        End If
    End Sub

    Private Sub txtApePaterno_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtApePaterno.TextChanged

    End Sub

    Private Sub txtApeMaterno_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtApeMaterno.KeyUp
        If (vf.startValidation) Then
            LoadFacturaciones()

        End If
    End Sub

    Private Sub txtApeMaterno_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtApeMaterno.TextChanged

    End Sub

    Private Sub txtNombres_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNombres.KeyUp
        If (vf.startValidation) Then
            LoadFacturaciones()

        End If
    End Sub

    Private Sub txtNombres_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNombres.TextChanged

    End Sub

    Private Sub btnPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreview.Click
        ReciboF = dgFacturaciones.SelectedRows(0).Cells(13).Value
        frmRecibos.Nrorecibo = ReciboF
        frmRecibos.TIPO = 1
        frmRecibos.Show()

    End Sub

    Private Sub btnAnulaPago_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnulaPago.Click
        'Dim fact As New clsFacturacion
        Dim nroRecibo As String
        Dim idfacturacion As Integer
        Dim predio As Integer
        Dim anio As String
        Dim idmes As Integer

        Dim numerror As String
        numerror = ""
        If (Me.dgFacturaciones.SelectedRows.Count > 0) Then
            'Try
            idfacturacion = dgFacturaciones.SelectedRows(0).Cells(16).Value
            nroRecibo = dgFacturaciones.SelectedRows(0).Cells(13).Value
            predio = dgFacturaciones.SelectedRows(0).Cells(7).Value

            anio = dgFacturaciones.SelectedRows(0).Cells(11).Value
            idmes = dgFacturaciones.SelectedRows(0).Cells(12).Value

            Dim m = MessageBox.Show("Desea eliminar el registro seleccionado?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If (m = Windows.Forms.DialogResult.Yes) Then
                clsFacturacion.elimina(nroRecibo, predio, idfacturacion, anio, idmes)

            End If
            MsgBox("Factura Eliminado correctamente", MsgBoxStyle.Information)
             LoadFacturaciones()
        End If
    End Sub

    Private Sub GroupPanel2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupPanel2.Click

    End Sub

    Private Sub cmbMes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMes.SelectedIndexChanged

    End Sub

    Private Sub cmbAnio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAnio.SelectedIndexChanged

    End Sub

    Private Sub cmbCPoblado1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCPoblado.SelectedIndexChanged
        Try
            clsCalles.LoadComboCallesPredio(cmbCalles, "where padPredio.idCP= " & cmbCPoblado.SelectedValue & " ")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub chkSelectAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSelectAll.CheckedChanged
        For Each n1 As DevComponents.AdvTree.Node In tvPredios.Nodes
            If (n1.Enabled) Then
                n1.Checked = chkSelectAll.Checked
            End If
        Next
    End Sub

    Private Sub tvPredios_AfterCheck(ByVal sender As Object, ByVal e As DevComponents.AdvTree.AdvTreeCellEventArgs) Handles tvPredios.AfterCheck
        Try
            Dim count As Integer = 0
            For Each n As DevComponents.AdvTree.Node In tvPredios.Nodes
                If (n.Checked) Then
                    count += 1
                    lblTotal.Text = count & "Predios Seleccionados de " & tvPredios.Nodes.Count
                End If

            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub tvPredios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tvPredios.Click

    End Sub

    Private Sub cmbAnio1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAnio1.SelectedIndexChanged

    End Sub

    Private Sub cmbCalles1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCalles1.SelectedIndexChanged

    End Sub

    Private Sub cmbMes1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMes1.SelectedIndexChanged

    End Sub

    Private Sub cmbCPoblado_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCPoblado.SelectedIndexChanged

    End Sub

    Private Sub cmbCPoblado1_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCPoblado1.SelectedIndexChanged
        Try
            clsCalles.LoadComboCallesPredio(cmbCalles1, "where padPredio.idCP= " & cmbCPoblado1.SelectedValue & " ")
        Catch ex As Exception

        End Try
    End Sub
End Class