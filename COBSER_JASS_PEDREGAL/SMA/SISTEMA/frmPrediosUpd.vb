Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Data.OleDb
Imports ACCESO
Imports LOGICA

Public Class frmPrediosUpd
    Dim id As String
    Dim idJas As String
    Dim idusuario As Integer
    Dim idpredio As Integer
    Public PREDIO As String
    
    Dim vf As New clsValidateForm

    Private Sub frmPrediosUpd_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        clsTipoPredio.LoadCombo(cmbTipoPredio)
        clsCalles.LoadCombo(cmbCalles)
        clsProvincia.LoadCombo(cmbProvincia)
        clsDistritoPolitico.LoadCombo(cmbDistrito)
        clsCentroPoblado.LoadCombo(cmbCPoblado)
        clsSector.LoadCombo(cmbSector)

        idJas = cmbJunta.SelectedValue

        idusuario = frmPredios.gridPredios.Item(2, frmPredios.gridPredios.CurrentRow.Index).Value
        idpredio = frmPredios.gridPredios.Item(3, frmPredios.gridPredios.CurrentRow.Index).Value
        txtFRegistro.Text = frmPredios.gridPredios.Item(26, frmPredios.gridPredios.CurrentRow.Index).Value
        txtFActualizacion.Text = ACCESO.Conexion.getDateServer
        cmbTipoPredio.Text = frmPredios.gridPredios.Item(9, frmPredios.gridPredios.CurrentRow.Index).Value
        txtUsuario.Text = frmPredios.gridPredios.Item(8, frmPredios.gridPredios.CurrentRow.Index).Value
        cmbCalles.Text = frmPredios.gridPredios.Item(17, frmPredios.gridPredios.CurrentRow.Index).Value
        cmbTipoDoc.Text = frmPredios.gridPredios.Item(12, frmPredios.gridPredios.CurrentRow.Index).Value
        txtNombre.Text = frmPredios.gridPredios.Item(10, frmPredios.gridPredios.CurrentRow.Index).Value
        txtnumero.Text = frmPredios.gridPredios.Item(11, frmPredios.gridPredios.CurrentRow.Index).Value
        txtManzana.Text = frmPredios.gridPredios.Item(18, frmPredios.gridPredios.CurrentRow.Index).Value
        txtLote.Text = frmPredios.gridPredios.Item(19, frmPredios.gridPredios.CurrentRow.Index).Value
        txtCEste.Text = frmPredios.gridPredios.Item(27, frmPredios.gridPredios.CurrentRow.Index).Value
        txtCNorte.Text = frmPredios.gridPredios.Item(28, frmPredios.gridPredios.CurrentRow.Index).Value
        txtFDco.Text = frmPredios.gridPredios.Item(20, frmPredios.gridPredios.CurrentRow.Index).Value
        txtTitulo.Text = frmPredios.gridPredios.Item(13, frmPredios.gridPredios.CurrentRow.Index).Value
        txtPartida.Text = frmPredios.gridPredios.Item(14, frmPredios.gridPredios.CurrentRow.Index).Value
        txtUC.Text = frmPredios.gridPredios.Item(15, frmPredios.gridPredios.CurrentRow.Index).Value
        cmbProvincia.SelectedValue = frmPredios.gridPredios.Item(24, frmPredios.gridPredios.CurrentRow.Index).Value
        cmbDistrito.SelectedValue = frmPredios.gridPredios.Item(23, frmPredios.gridPredios.CurrentRow.Index).Value
        cmbCPoblado.SelectedValue = frmPredios.gridPredios.Item(22, frmPredios.gridPredios.CurrentRow.Index).Value
        cmbSector.SelectedValue = frmPredios.gridPredios.Item(21, frmPredios.gridPredios.CurrentRow.Index).Value


    End Sub

    Private Sub GroupPanel2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupPanel2.Click

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        PREDIO = txtNombre.Text
        Dim u As New clsPredios(idJas, idusuario, Val(cmbTipoPredio.SelectedValue), Val(cmbDistrito.SelectedValue), Val(cmbSector.SelectedValue), Val(cmbCalles.SelectedValue), PREDIO, Val(cmbTipoDoc.SelectedIndex), txtFDco.Text, txtTitulo.Text, txtnumero.Text, txtPartida.Text, txtUC.Text, txtManzana.Text, txtLote.Text, txtFRegistro.Text, txtFActualizacion.Text, Val(cmbCPoblado.SelectedValue), txtCEste.Text, txtCNorte.Text)
        u.id = idpredio
        u.update()
        frmPredios.gridPredios.DataSource = clsPredios.List()
        'frmUsuarios.gridUsuarios.DataSource = frmUsuarios.Filtrar()
        vf.resetForm()
        MsgBox("Información actualizada satisfactoriamente", MsgBoxStyle.Information)
        Me.Close()

    End Sub

    Private Sub cmbCPoblado_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCPoblado.SelectedIndexChanged
        'cmbCPoblado.SelectedIndex = -1
        'clsCalles.LoadCombo(cmbCalles, " where idCp=" & cmbCPoblado.SelectedValue & "")
    End Sub

    Private Sub cmbCalles_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCalles.SelectedIndexChanged

    End Sub

    Private Sub cmbTipoPredio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipoPredio.SelectedIndexChanged

    End Sub
End Class