Imports ACCESO
Imports LOGICA
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Data.OleDb

Public Class frmPredioNew
    Public idUsuario As String
    Public idJas As String
    Public winOrigen As String
    Public tipopredio As Integer
    Public PREDIO As String

    


    Dim vf As New clsValidateForm
   
    Private Sub frmPredioNew_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            clsCalles.LoadCombo(cmbCalles)
            cmbCalles.SelectedValue = 1
            clsTipoPredio.LoadCombo(cmbTipoPredio)
            cmbTipoPredio.SelectedValue = 1
            clsCentroPoblado.LoadCombo(cmbCPoblado)
            'clsCalles.LoadCombo(cmbCalles)
            txtUsuario.Text = ""

            clsProvincia.LoadCombo(cmbProvincia, " where iIdDepartamento='20'")
            Select Case winOrigen
                Case 0 'ventana usuario
                    btnSelectUsuario.Enabled = False
                    'cmbJunta.SelectedValue = frmPrediosUsuario.idUsuarioJunta
                    'idUsuario = frmPrediosUsuario.idUsuario
                    'idJas = frmPrediosUsuario.idUsuarioJunta
                    'cmbJunta.Enabled = False
                    'txtUsuario.Text = frmPrediosUsuario.usuario
                Case 1 'ventana predios
                    btnSelectUsuario.Enabled = True
                    cmbJunta.Enabled = True
                    If (frmPrincipal.userSystem.idInterfaz = 3) Then
                        cmbJunta.SelectedValue = frmPrincipal.userSystem.idJunta
                        'cmbJunta.SelectedValue = frmPrediosUsuario.idUsuarioJunta
                    End If

            End Select
            'Dim dtFecha As DateTime = DateTime.Now
            txtFRegistro.Text = ACCESO.Conexion.getDateServer

            txtFActualizacion.Text = ACCESO.Conexion.getDateServer
            gbPropiedad.Enabled = False
            Call LIMPIAR()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub LIMPIAR()
        txtUsuario.Text = ""
        txtNombre.Text = ""
        txtnumero.Text = ""
        txtLote.Text = ""
        txtManzana.Text = ""
        txtFDco.Text = ""
        txtPartida.Text = ""
        txtUC.Text = ""
        txtTitulo.Text = ""
        txtCEste.Text = ""
        txtCNorte.Text = ""
        cmbCalles.SelectedIndex = -1
        cmbTipoDoc.SelectedIndex = -1


    End Sub
    Private Sub gbDatosG_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gbDatosG.Click

    End Sub

    Private Sub btnSelectUsuario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectUsuario.Click
        Try
            Select winOrigen
                Case 2
                    If (frmUsuarios.Visible = True) Then
                        frmUsuarios.Close()
                    End If
                    frmUsuarios.winOrigen = 2
                    frmUsuarios.ShowDialog()
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cmbProvincia_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbProvincia.GotFocus
        clsProvincia.LoadCombo(cmbProvincia, " where iIdDepartamento='20'")
    End Sub

    Private Sub cmbProvincia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbProvincia.SelectedIndexChanged
        'cmbProvincia.SelectedIndex = -1
    End Sub

    Private Sub cmbDistrito_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbDistrito.GotFocus
        clsDistritoPolitico.LoadCombo(cmbDistrito, " and d.iIdProvincia='" & cmbProvincia.SelectedValue & "'")
    End Sub

    Private Sub cmbDistrito_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDistrito.SelectedIndexChanged
        'cmbDistrito.SelectedIndex = -1
    End Sub

    Private Sub cmbCPoblado_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCPoblado.GotFocus
        'clsCentroPoblado.LoadCombo(cmbCPoblado, " WHERE iIdDistrito='" & cmbDistrito.SelectedValue & "'")
    End Sub

    Private Sub cmbCPoblado_HandleCreated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCPoblado.HandleCreated

    End Sub

    Private Sub cmbCPoblado_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCPoblado.SelectedIndexChanged
        'cmbCPoblado.SelectedIndex = -1
        clsCalles.LoadCombo(cmbCalles, " where idCp=" & cmbCPoblado.SelectedValue & "")
        cmbCalles.SelectedIndex = 0
    End Sub

    Private Sub TabControlPanel1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControlPanel1.Click

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim m As MsgBoxResult
        'If (cmbTipoPredio.SelectedValue = 1) Then
        'tipopredio = cmbTipoPredio.SelectedValue
        'Else
        'tipopredio = 0
        'End If
        PREDIO = txtNombre.Text
        'monto1 = Val(txtMonto.Text)
        Dim r As New clsPredios(idJas, idUsuario, Val(cmbTipoPredio.SelectedValue), Val(cmbDistrito.SelectedValue), Val(cmbSector.SelectedValue), Val(cmbCalles.SelectedValue), PREDIO, Val(cmbTipoDoc.SelectedIndex), txtFDco.Text, txtTitulo.Text, txtnumero.Text, txtPartida.Text, txtUC.Text, txtManzana.Text, txtLote.Text, txtFRegistro.Text, txtFActualizacion.Text, Val(cmbCPoblado.SelectedValue), txtCEste.Text, txtCNorte.Text)
        r.Insert()
        r.addUsuario(idUsuario)

        'm = MessageBox.Show("Informacion registrada satisfactroriamente." & vbCrLf & "Desea continuar?", "COBSERV", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        frmPredios.gridPredios.DataSource = clsPredios.List()

        m = MessageBox.Show("Informacion registrada satisfactroriamente." & vbCrLf & "Desea continuar?", "COBSER", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        frmPredios.gridPredios.DataSource = frmPredios.Filtrar()
        clsValidateForm.LimpiarControles(Me.GroupPanel1)
        vf.resetForm()
        Call LIMPIAR()
        If (frmPrincipal.userSystem.idInterfaz = 3) Then
            cmbJunta.SelectedValue = frmPrincipal.userSystem.idJunta
            cmbJunta.Enabled = False
        End If
        If (m = Windows.Forms.DialogResult.No) Then
            Me.Close()
        End If
    End Sub


    Private Sub cmbTipoDoc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipoDoc.SelectedIndexChanged
        If cmbTipoDoc.SelectedIndex = 1 Then
            gbPropiedad.Enabled = True
        Else
            gbPropiedad.Enabled = False

        End If
        txtNombre.Focus()

    End Sub

    Private Sub LabelX25_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LabelX25.Click

    End Sub

    Private Sub cmbSector_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbSector.GotFocus
        clsSector.LoadCombo(cmbSector, " WHERE idCP='" & cmbCPoblado.SelectedValue & "'")
    End Sub

    Private Sub cmbSector_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSector.SelectedIndexChanged
        'cmbSector.SelectedIndex = -1

    End Sub

    Private Sub txtNombre_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombre.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            txtnumero.Focus()
        End If
    End Sub

    Private Sub txtNombre_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNombre.TextChanged

    End Sub

    Private Sub txtnumero_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnumero.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            txtManzana.Focus()
        End If
    End Sub

    Private Sub txtnumero_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtnumero.TextChanged

    End Sub

    Private Sub txtManzana_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtManzana.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            txtLote.Focus()
        End If
    End Sub

    Private Sub txtManzana_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtManzana.TextChanged

    End Sub

    Private Sub txtLote_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLote.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            txtCEste.Focus()
        End If
    End Sub

    Private Sub txtLote_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLote.TextChanged

    End Sub

    Private Sub txtCEste_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCEste.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            txtCNorte.Focus()
        End If
    End Sub

    Private Sub txtCEste_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCEste.TextChanged

    End Sub

    Private Sub txtCNorte_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCNorte.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            txtFDco.Focus()
        End If
    End Sub

    Private Sub txtCNorte_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCNorte.TextChanged

    End Sub

    Private Sub txtFDco_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFDco.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            txtTitulo.Focus()
        End If
    End Sub

    Private Sub txtFDco_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFDco.TextChanged

    End Sub

    Private Sub txtTitulo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTitulo.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            txtPartida.Focus()
        End If
    End Sub

    Private Sub txtTitulo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTitulo.TextChanged

    End Sub

    Private Sub txtPartida_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPartida.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            txtUC.Focus()
        End If
    End Sub

    Private Sub txtPartida_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPartida.TextChanged

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub cmbCalles_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCalles.SelectedIndexChanged

    End Sub

    Private Sub cmbTipoPredio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipoPredio.SelectedIndexChanged

    End Sub
End Class