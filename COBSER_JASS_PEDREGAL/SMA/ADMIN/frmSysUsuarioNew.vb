Imports ACCESO
Imports LOGICA
Public Class frmSysUsuarioNew
    Dim vf As New clsValidateForm
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If (vf.startValidation) Then
            If (User.ExisteUsuario(txtUsuario.Text) = False) Then
                If (txtPassword.Text.CompareTo(txtRePassword.Text) = 0) Then
                    Dim u As New User(cmbGrupo.SelectedValue, txtUsuario.Text, txtPassword.Text, txtNombres.Text, txtApellidos.Text, txtTelefono.Text, txtEmail.Text)
                    u.Insert()
                    If (frmPrincipal.userSystem.idInterfaz = 1) Then
                        frmSysUsuarios.gridUsuarios.DataSource = ACCESO.User.List(" and g.idPGrupo<>1")
                    Else
                        If (frmPrincipal.userSystem.idInterfaz = 2) Then
                            frmSysUsuarios.gridUsuarios.DataSource = ACCESO.User.List(" and g.idPGrupo<>1 and g.idPGrupo<>2 ")
                        Else
                            frmSysUsuarios.gridUsuarios.DataSource = ACCESO.User.List(" and g.idPGrupo<>1 and u.idGrupo='" & frmPrincipal.userSystem.idGrupo & "'")

                        End If
                    End If

                    Dim m = MessageBox.Show("Información registrada satisfactroriamente." & vbCrLf & "Desea continuar?", "SMA", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    If (m = Windows.Forms.DialogResult.No) Then
                        Me.Close()
                    End If
                    clsValidateForm.LimpiarControles(Me.GroupPanel1)
                    cmbInterfaz.SelectedIndex = -1
                    cmbGrupo.SelectedIndex = -1
                Else
                    MsgBox("Contraseñas ingresadas no son iguales")
                    txtPassword.ResetText()
                    txtRePassword.ResetText()
                End If
            Else
                MsgBox("Usuario ya se encuentra registrado, pruebe con otro nombre", MsgBoxStyle.Information)
                txtUsuario.Focus()
            End If
        Else
            MsgBox("Información invalida o incompleta", MsgBoxStyle.Exclamation)
        End If
    End Sub

    

    Private Sub frmSysUsuarioNew_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        vf.addTextbox(txtNombres, "string", False)
        vf.addTextbox(txtApellidos, "string", False)
        vf.addTextbox(txtUsuario, "string", False)
        vf.addTextbox(txtPassword, "string", False)
        vf.addTextbox(txtRePassword, "string", False)
        vf.addTextbox(txtEmail, "email", True)
        vf.addTextbox(txtTelefono, "string", True)
        vf.addCombobox(cmbInterfaz, "string", False)
        vf.addCombobox(cmbGrupo, "string", False)
        vf.item(3).minLength = 5
        vf.item(3).maxLength = 20
        vf.item(4).minLength = 6
        vf.item(5).minLength = 6
        vf.item(4).maxLength = 20
        vf.item(5).maxLength = 20
        vf.item(7).maxLength = 15
        vf.resetForm()
        Interfaz.LoadCombo(cmbInterfaz)
        clsValidateForm.LimpiarControles(Me.GroupPanel1)
        If (frmPrincipal.userSystem.idInterfaz <> 1 And frmPrincipal.userSystem.idInterfaz <> 2) Then
            cmbInterfaz.SelectedValue = frmPrincipal.userSystem.idInterfaz
            cmbInterfaz.Enabled = False
            Grupo.LoadCombo(cmbGrupo, " and g.idPGrupo='" & frmPrincipal.userSystem.idInterfaz & "'")
            cmbGrupo.SelectedValue = frmPrincipal.userSystem.idGrupo
            cmbGrupo.Enabled = False
        End If

    End Sub

    Private Sub cmbGrupo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbGrupo.GotFocus
        Grupo.LoadCombo(cmbGrupo, " and g.idPGrupo='" & cmbInterfaz.SelectedValue & "'")
    End Sub

    Private Sub cmbInterfaz_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbInterfaz.SelectedIndexChanged
        cmbGrupo.SelectedIndex = -1
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnValidate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnValidate.Click
        If (txtUsuario.Text <> "") Then
            If (User.ExisteUsuario(txtUsuario.Text)) Then
                MsgBox("Usuario ya se encuentra registrado, pruebe con otro nombre", MsgBoxStyle.Information)
            Else
                MsgBox("Usuario disponible", MsgBoxStyle.Information)
            End If
        Else
            MsgBox("campo Usuario no debe ser un valor vacio ", MsgBoxStyle.Information)
            txtUsuario.Focus()
        End If
    End Sub
End Class