Imports ACCESO
Public Class frmSysPermisos
    Dim id As Integer
    Dim idPadre As Integer
    Private Sub frmSysPermisos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.tvPermisos.Nodes.Clear()
        id = frmSysGrupos.gridGrupos.Item(0, frmSysGrupos.gridGrupos.CurrentRow.Index).Value
        idPadre = frmSysGrupos.gridGrupos.Item(1, frmSysGrupos.gridGrupos.CurrentRow.Index).Value
        Grupo.GeneraTreePermisos(Me.tvPermisos, idPadre, id)
        Me.tvPermisos.ExpandAll()
        lblEstadoMsg.Visible = False
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        imgEstadoMsg.Image = Global.COBSER.My.Resources.Resources._28v
        btnSave.Enabled = False
        bgw.RunWorkerAsync()

    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub


    Private Sub bgw_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgw.DoWork
        Grupo.SavePermisosGrupo(Me.tvPermisos, id)
    End Sub

    Private Sub bgw_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgw.RunWorkerCompleted
        imgEstadoMsg.Image = Global.COBSER.My.Resources.Resources.accept

        btnSave.Enabled = True
        MsgBox("Permisos actualizados satisfactoriamente", MsgBoxStyle.Information)
        Me.Close()
    End Sub

    Private Sub imgEstadoMsg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgEstadoMsg.Click

    End Sub
End Class