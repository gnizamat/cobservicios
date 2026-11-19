Imports ACCESO
Imports LOGICA
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Data.OleDb
Public Class frmTarifasAnios
    Public anio As String
    Private Sub frmTarifasAnios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            clsJunta.LoadCombo(cmbJunta1)
            If (frmPrincipal.userSystem.idInterfaz = 4) Then
                cmbJunta1.SelectedValue = frmPrincipal.userSystem.idJunta
                cmbJunta1.Enabled = False
            End If
            dgTarifas.DataSource = clsTarias.List
            'CargaLista()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnTarifaNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTarifaNew.Click
        frmTarifasNew.ShowDialog()

    End Sub

    Private Sub btnActivar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActivar.Click
        'Dim u As New clsTarias()
        'u.update_tarifa(dgTarifas.Item(0, dgTarifas.CurrentRow.Index).Value)

        If (ValidaGridItemSeleccionado(dgTarifas)) Then
            clsTarias.ActivarTarifa(cmbJunta1.SelectedValue, dgTarifas.Item(0, dgTarifas.CurrentRow.Index).Value)
            'dgTarifas.DataSource = comision.listTarifas()
            dgTarifas.DataSource = clsTarias.List
        End If


    End Sub

    Private Sub ButtonItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem3.Click
        Dim anio As Integer
        Dim IDJAS As String

        Dim m = MessageBox.Show("Desea eliminar el registro seleccionado?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If (m = Windows.Forms.DialogResult.Yes) Then
            anio = dgTarifas.Item(0, dgTarifas.CurrentRow.Index).Value
            IDJAS = dgTarifas.Item(1, dgTarifas.CurrentRow.Index).Value
            clsTarias.delete(anio, IDJAS)
            MsgBox("Deuda Elimidada correctamente", MsgBoxStyle.Information)
            dgTarifas.DataSource = clsTarias.List
        End If
    End Sub

    Private Sub btnDistribucion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDistribucion.Click
        If (Me.dgTarifas.SelectedRows.Count > 0) Then
           
            frmCostosTarifas.anio = dgTarifas.SelectedRows(0).Cells(0).Value
            'frmRegistrarMedidor.tipotarifa = dgTarifas.SelectedRows(0).Cells(11).Value
            frmCostosTarifas.ShowDialog()

        Else
            MsgBox("Seleccione un predio")
        End If

    End Sub

    Private Sub btnTarifaUpd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTarifaUpd.Click
        frmTarifasUpd.ShowDialog()

    End Sub

    Private Sub LabelX1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LabelX1.Click

    End Sub
End Class