Public Class frmSesionClose

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub swfLogin_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub swfLogin_FSCommand(ByVal sender As Object, ByVal e As AxShockwaveFlashObjects._IShockwaveFlashEvents_FSCommandEvent)
        Select Case e.command
            Case "CLOSE"
                Me.Close()
                frmPrincipal.Close()
            Case "CHANGE"
                Application.Restart()
            Case "CLOSEWIN"
                Me.Close()
        End Select
    End Sub

    Private Sub frmSesionClose_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        Me.Close()
        frmPrincipal.Close()
    End Sub

    Private Sub ButtonX1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX1.Click
        Application.Restart()
    End Sub
End Class