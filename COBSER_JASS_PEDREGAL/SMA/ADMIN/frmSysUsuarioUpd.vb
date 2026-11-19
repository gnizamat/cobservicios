Imports ACCESO
Imports LOGICA
Public Class frmSysUsuarioUpd
    Dim vf As New clsValidateForm
    Dim idusuario As String
    Dim idgrupo As Integer
    Private Sub frmSysUsuarioUpd_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dt As New DataTable
        vf.addTextbox(txtNombres, "string", False)
        vf.addTextbox(txtApellidos, "string", False)
        vf.addTextbox(txtUsuario, "string", False)
        vf.addTextbox(txtEmail, "email", True)
        vf.addTextbox(txtTelefono, "string", True)
        vf.addCombobox(cmbInterfaz, "string", False)
        vf.addCombobox(cmbGrupo, "string", False)
        vf.resetForm()
        vf.item(5).maxLength = 15
        clsValidateForm.LimpiarControles(Me.GroupPanel1)
        If (frmPrincipal.userSystem.idInterfaz <> 1) Then
            cmbInterfaz.SelectedValue = frmPrincipal.userSystem.idInterfaz
            cmbInterfaz.Enabled = False
            Grupo.LoadCombo(cmbGrupo, " and g.idPGrupo='" & frmPrincipal.userSystem.idInterfaz & "'")
            cmbGrupo.SelectedValue = frmPrincipal.userSystem.idGrupo
            cmbGrupo.Enabled = False
        End If
        Interfaz.LoadCombo(cmbInterfaz)
        idusuario = frmSysUsuarios.gridUsuarios.Item(0, frmSysUsuarios.gridUsuarios.CurrentRow.Index).Value
        txtUsuario.Text = idusuario
        txtNombres.Text = frmSysUsuarios.gridUsuarios.Item(3, frmSysUsuarios.gridUsuarios.CurrentRow.Index).Value
        txtApellidos.Text = frmSysUsuarios.gridUsuarios.Item(4, frmSysUsuarios.gridUsuarios.CurrentRow.Index).Value
        txtEmail.Text = frmSysUsuarios.gridUsuarios.Item(5, frmSysUsuarios.gridUsuarios.CurrentRow.Index).Value
        txtTelefono.Text = frmSysUsuarios.gridUsuarios.Item(6, frmSysUsuarios.gridUsuarios.CurrentRow.Index).Value
        idgrupo = frmSysUsuarios.gridUsuarios.Item(1, frmSysUsuarios.gridUsuarios.CurrentRow.Index).Value
        dt = Grupo.List(" and g.idGrupo='" & idgrupo & "'")
        cmbInterfaz.SelectedValue = dt.Rows(0).Item(1)
        cmbGrupo.SelectedValue = idgrupo
    End Sub

    Private Sub cmbInterfaz_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbInterfaz.SelectedIndexChanged
        cmbGrupo.SelectedIndex = -1
        Try
            Grupo.LoadCombo(cmbGrupo, " and g.idPGrupo='" & cmbInterfaz.SelectedValue & "'")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If (vf.startValidation) Then
            Dim u As New User()
            u.idGrupo = cmbGrupo.SelectedValue
            u.usuario = txtUsuario.Text
            u.nombres = txtNombres.Text
            u.apellidos = txtApellidos.Text
            u.telefono = txtTelefono.Text
            u.email = txtEmail.Text
            u.Update()
            If (frmPrincipal.userSystem.idInterfaz = 1) Then
                frmSysUsuarios.gridUsuarios.DataSource = ACCESO.User.List(" and g.idPGrupo<>1")
            Else
                frmSysUsuarios.gridUsuarios.DataSource = ACCESO.User.List(" and g.idPGrupo<>1 and u.idGrupo='" & frmPrincipal.userSystem.idGrupo & "'")
            End If
            showMessages("update")
            Me.Close()
        Else
            showMessages("formInvalid")
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class