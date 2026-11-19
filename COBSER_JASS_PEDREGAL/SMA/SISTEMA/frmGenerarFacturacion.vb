Imports ACCESO
Imports LOGICA
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Data.OleDb
Public Class frmGenerarFacturacion
    Dim tv As New DevComponents.AdvTree.AdvTree
    Dim vf As New clsValidateForm
    Dim n As TreeNode

    Private Sub frmGenerarFacturacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            clsJunta.LoadCombo(cmbJunta)
            If (frmPrincipal.userSystem.idInterfaz = 4) Then
                cmbJunta.SelectedValue = frmPrincipal.userSystem.idJunta
                cmbJunta.Enabled = False
            End If
            clsCalles.LoadComboADD(cmbCalles)
            clsAnioTarifa.LoadCombo(cmbAnio)
            cmbAnio.SelectedIndex = 0
            clsMes.LoadCombo(cmbMes)
            cmbMes.SelectedValue = 1
            clsTipoTarifa.LoadCombo(cmbSubTipoTarifa, "Where iAnioTarifa='" & cmbAnio.Text & "' ")
            cmbSubTipoTarifa.SelectedIndex = 0
            cmbCalles.SelectedValue = 0
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbSubTipoTarifa_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSubTipoTarifa.SelectedIndexChanged
        Try
            txtTipoTarifa.Text = cmbSubTipoTarifa.SelectedItem(4).ToString
            txtValorSubTarifa.Text = cmbSubTipoTarifa.SelectedItem(5).ToString
            'txtMonto.Text = cmbSubTipoTarifa.SelectedItem(5).ToString

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbCalles_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCalles.SelectedIndexChanged
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

    Private Sub btnFiltrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFiltrar.Click
        CargaLista()
    End Sub

    Private Sub CargaLista()
        Dim obj As New clsfacturacion
        obj.ListTree(tvPredios, cmbCalles.SelectedValue, cmbMes.SelectedValue, cmbAnio.SelectedValue)
        tvPredios.Focus()
        'For Each N As DevComponents.AdvTree.Node In tvEjecucion.Nodes
        '    tvEjecucion.SelectedNode = tvEjecucion.Nodes(N.Index)
        '    tvEjecucion.Nodes(tvEjecucion.SelectedNode.Index).Expand()
        'Next

    End Sub

    Private Sub btnCalcularDeuda_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalcularDeuda.Click
        Dim obj As New clsFacturacion
        Dim numerror As String
        Dim interes As Double
        numerror = ""
        For Each nodo As DevComponents.AdvTree.Node In tvPredios.Nodes  '     TreeNode   Nodos
            tvPredios.SelectedNode = tvPredios.Nodes(nodo.Index)
            obj.Año = nodo.Cells(5).Text.ToString
            obj.Mes = nodo.Cells(6).Text.ToString
            obj.Predio = nodo.Cells(7).Text.ToString
            'obj.NroDoc = 1
            obj.Monto = nodo.Cells(3).Text.ToString
            obj.Fecha = Format(Date.Now(), "dd/MM/yyyy")
            obj.Estado = 0
            'obj.Interes = 0
            If Not obj.Insert(cmbCalles.SelectedValue, cmbMes.SelectedValue, cmbAnio.SelectedValue) Then ', nodo.Cells(8).Text.ToString

                numerror = numerror & "Facturación Generada para el predio " & nodo.Cells(7).Text.ToString & " del usuario " & nodo.Cells(2).Text.ToString & " no se genero correctamente" & Chr(13)
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

    Private Sub btnVisualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVisualizar.Click
        frmFaturacion.IdCalle = cmbCalles.SelectedValue
        frmFaturacion.Año = cmbAnio.SelectedValue
        frmFaturacion.Mes = cmbMes.SelectedValue
        frmFaturacion.ShowDialog()

    End Sub

    Private Sub cmbAnio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAnio.SelectedIndexChanged

    End Sub

    Private Sub cmbJunta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbJunta.SelectedIndexChanged

    End Sub
End Class