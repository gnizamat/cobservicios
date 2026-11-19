Imports ACCESO
Imports LOGICA
Public Class frmAdminInterfaces

    Private Sub frmAdminInterfaces_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'para la interfaz atdr
        Me.tvATDR.Nodes.Clear()
        Interfaz.GeneraTreePermisos(Me.tvATDR, 2)
        Me.tvATDR.ExpandAll()
        'para la interfaz junta de usuarios
        Me.tvJU.Nodes.Clear()
        Interfaz.GeneraTreePermisos(Me.tvJU, 3)
        Me.tvJU.ExpandAll()

        'para la interfaz comision de regantes
        Me.tvCR.Nodes.Clear()
        Interfaz.GeneraTreePermisos(Me.tvCR, 4)
        Me.tvCR.ExpandAll()

    End Sub
    Dim tipo As Integer

    Private Sub bgw_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgw.DoWork
        Select Case tipo
            Case 1
                Interfaz.SavePermisosGrupo(Me.tvATDR, 2)

            Case 2
                Interfaz.SavePermisosGrupo(Me.tvJU, 3)

            Case 3
                Interfaz.SavePermisosGrupo(Me.tvCR, 4)

        End Select
    End Sub

   

    Private Sub bgw_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgw.RunWorkerCompleted
        imgEstadoMsg.Image = Global.COBSER.My.Resources.Resources.accept
        MsgBox("Permisos actualizados satisfactoriamente", MsgBoxStyle.Information)
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        tipo = TabControl2.SelectedTabIndex + 1
        imgEstadoMsg.Image = Global.COBSER.My.Resources.Resources._28v
        bgw.RunWorkerAsync()
    End Sub

    Private Sub tvATDR_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvATDR.AfterSelect

    End Sub

    Private Sub ButtonItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem1.Click
        Me.Close()

    End Sub
End Class