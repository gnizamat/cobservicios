Public Class frmVerificaUsuario
    Public valido As Boolean

    Private Sub frmVerificaUsuario_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        txtPassword.Focus()
    End Sub

    Private Sub frmVerificaUsuario_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        txtPassword.Focus()
    End Sub
    Private Sub frmVerificaUsuario_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        valido = False
        txtPassword.Text = ""
        lblUsuario.Text = frmPrincipal.userSystem.usuario
        txtPassword.Focus()
        chkHide.Checked = True
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If (Validar()) Then
            valido = True
            Me.Visible = False
            'MsgBox(Me.ParentForm.Name)
        Else
            valido = False
            showMessages("PasswordIncorrect")
        End If
    End Sub
    Public Function Validar() As Boolean
        Dim pass As String = ""
        pass = frmPrincipal.userSystem.password
        If (pass = getMd5Hash(txtPassword.Text)) Then
            Return True
        End If
        Return False
    End Function

    Private Sub txtPassword_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPassword.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            btnSave_Click(btnSave, e)
        End If
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub txtPassword_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPassword.TextChanged

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub lblIdentificador_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblIdentificador.Click

    End Sub

  
    Private Sub chkHide_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkHide.CheckedChanged
        txtPassword.UseSystemPasswordChar = chkHide.Checked
    End Sub
End Class