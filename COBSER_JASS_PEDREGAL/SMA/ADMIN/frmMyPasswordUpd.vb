Imports ACCESO
Imports LOGICA
Public Class frmMyPasswordUpd
    Dim vf As New clsValidateForm
    Private Sub frmMyPasswordUpd_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtUsuario.Text = frmPrincipal.userSystem.usuario
        vf.addTextbox(txtUsuario, "string", False)
        vf.addTextbox(txtPassword, "string", False)
        vf.addTextbox(txtPasswordNew, "string", False)
        vf.addTextbox(txtPasswordNew2, "string", False)
        vf.item(3).minLength = 6
        vf.item(3).maxLength = 20
        vf.item(4).minLength = 6
        vf.item(4).maxLength = 20
        vf.resetForm()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If (vf.startValidation) Then
            If (frmPrincipal.userSystem.password = getMd5Hash(txtPassword.Text)) Then
                If (txtPasswordNew.Text = txtPasswordNew2.Text) Then
                    frmPrincipal.userSystem.UpdatePassword(getMd5Hash(txtPasswordNew.Text))
                    MsgBox("Contraseña actualizada satisfactoriamente", MsgBoxStyle.Information)
                    Me.Close()
                Else
                    MsgBox("Nueva contraseña no es igual", MsgBoxStyle.Exclamation)
                End If

            Else
                MsgBox("Contraseña ingresada es incorrecta", MsgBoxStyle.Exclamation)
            End If
        Else
            showMessages("formInvalid")
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class