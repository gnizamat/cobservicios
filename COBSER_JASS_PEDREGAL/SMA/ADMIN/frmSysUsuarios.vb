Imports ACCESO
Public Class frmSysUsuarios
    Public idgrupo As Integer
    Private Sub btnBloqueNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub frmSysUsuarios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        reloadData()
        Me.gridUsuarios.Columns(0).HeaderText = "Usuario"
        Me.gridUsuarios.Columns(2).HeaderText = "Grupo"
        Me.gridUsuarios.Columns(3).HeaderText = "Nombres"
        Me.gridUsuarios.Columns(4).HeaderText = "Apellidos"
        Me.gridUsuarios.Columns(5).HeaderText = "Email"
        Me.gridUsuarios.Columns(6).HeaderText = "Teléfono"
        Me.gridUsuarios.Columns(1).Visible = False
    End Sub

    Private Sub btnUsuarioNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUsuarioNew.Click
        frmSysUsuarioNew.ShowDialog()
    End Sub

    Private Sub btnUsuarioUpd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUsuarioUpd.Click
        Dim flag As Boolean = True
        Dim id As String
        If (Me.gridUsuarios.SelectedRows.Count > 0) Then
            Try
                id = Me.gridUsuarios.Item(0, Me.gridUsuarios.CurrentRow.Index).Value
            Catch ex As Exception
                flag = False
                MsgBox("Seleccione una fila valida")
            End Try
            If (flag) Then
                frmSysUsuarioUpd.ShowDialog()
            End If
        Else
            MsgBox("Seleccione un Usuario")
        End If
    End Sub

    Private Sub btnusuarioDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnusuarioDel.Click
        Dim flag As Boolean = True
        Dim id As String = ""
        If (Me.gridUsuarios.SelectedRows.Count > 0) Then
            Try
                id = Me.gridUsuarios.Item(0, Me.gridUsuarios.CurrentRow.Index).Value
            Catch ex As Exception
                flag = False
                MsgBox("Seleccione una fila valida")
            End Try
            If (flag) Then
                Dim m = MessageBox.Show("Desea eliminar el registro seleccionado?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If (m = Windows.Forms.DialogResult.Yes) Then
                    ACCESO.User.Delete(id)
                    reloadData
                End If
            End If
        Else
            MsgBox("Seleccione un Usuario")
        End If
    End Sub

    Public Sub reloadData()
        If (frmPrincipal.userSystem.idInterfaz = 1) Then
            Me.gridUsuarios.DataSource = ACCESO.User.List(" and g.idPGrupo<>1")
        Else
            If (frmPrincipal.userSystem.idInterfaz = 2) Then
                Me.gridUsuarios.DataSource = ACCESO.User.List(" and g.idPGrupo<>1 and g.idPGrupo<>2")
            Else
                Me.gridUsuarios.DataSource = ACCESO.User.List(" and g.idPGrupo<>1 and u.idGrupo='" & frmPrincipal.userSystem.idGrupo & "'")
            End If

        End If
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        reloadData()
    End Sub
End Class