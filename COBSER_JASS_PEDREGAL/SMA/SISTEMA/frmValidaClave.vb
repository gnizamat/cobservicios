Public Class frmValidaClave

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    

  
    Private Sub txtClave_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtClave.TextChanged

    End Sub

    Private Sub frmValidaClave_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtClave.Text = ""
    End Sub

    Private Sub LabelX4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LabelX4.Click

    End Sub
End Class