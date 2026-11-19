Imports ACCESO
Imports LOGICA
Public Class frmSysGrupos
    Public dt As New DataTable
    Private Sub frmSysGrupos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        reloadData()
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        frmSysGrupoNew.ShowDialog()
    End Sub

    Private Sub btnUpd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpd.Click
        Dim flag As Boolean = True
        If (Me.gridGrupos.SelectedRows.Count > 0) Then
            Try
                Dim id As Integer = Me.gridGrupos.Item(0, Me.gridGrupos.CurrentRow.Index).Value
            Catch ex As Exception
                flag = False
                MsgBox("Seleccione una fila valida")
            End Try

        Else
            flag = False
            MsgBox("debe seleccionar una fila")
        End If
        If (flag) Then
            frmSysGrupoUpd.ShowDialog()
        End If
    End Sub

    Private Sub btnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDel.Click
        If (Me.gridGrupos.SelectedRows.Count > 0) Then
            Dim m = MessageBox.Show("Desea eliminar el registro seleccionado?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If (m = Windows.Forms.DialogResult.Yes) Then
                Dim g As New Grupo
                g.idGrupo = Me.gridGrupos.Item(0, Me.gridGrupos.CurrentRow.Index).Value
                If (g.getNroUsuarios > 0) Then
                    Dim n = MessageBox.Show("Existen usuarios pertenecientes al grupo seleccionado. Desea continuar y eliminar al grupo con todos sus usuarios?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    If (n = Windows.Forms.DialogResult.Yes) Then
                        Grupo.Delete(g.idGrupo)
                    End If
                Else
                    Grupo.Delete(g.idGrupo)
                End If
                reloadData()
            End If      
        Else
        MsgBox("Seleccione un Grupo")
        End If
    End Sub

    Private Sub btnPermisos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPermisos.Click
        Dim flag As Boolean = True
        If (Me.gridGrupos.SelectedRows.Count > 0) Then
            Try
                Dim id As Integer = Me.gridGrupos.Item(0, Me.gridGrupos.CurrentRow.Index).Value
            Catch ex As Exception
                flag = False
                MsgBox("Seleccione una fila valida")
            End Try

        Else
            flag = False
            MsgBox("debe seleccionar una fila")
        End If
        If (flag) Then
            frmSysPermisos.ShowDialog()
        End If

    End Sub
    Public Sub reloadData()
        Dim c As New ACCESO.Conexion
        Dim bs As New BindingSource
        If (c.Connect) Then
            dt = Grupo.List(" and g.idPGrupo<>'1' and g.idPGrupo<>'2'")
            If dt.Rows.Count > 0 Then
                gridGrupos.DataSource = dt
                gridGrupos.Columns(0).HeaderText = "Código"
                gridGrupos.Columns(2).HeaderText = "Nombre"
                gridGrupos.Columns(4).HeaderText = "Nº Usuarios"
                gridGrupos.Columns(6).HeaderText = "Región"
                gridGrupos.Columns(8).HeaderText = "Distrito de Riego"
                gridGrupos.Columns(10).HeaderText = "Junta de Usuario"
                gridGrupos.Columns(12).HeaderText = "Comisión de Regante"


                gridGrupos.Columns(0).Visible = False
                gridGrupos.Columns(1).Visible = False
                gridGrupos.Columns(5).Visible = False
                gridGrupos.Columns(7).Visible = False
                gridGrupos.Columns(9).Visible = False
                gridGrupos.Columns(11).Visible = False
            End If

        End If

    End Sub
    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        reloadData()
    End Sub

    Private Sub gridGrupos_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridGrupos.CellContentClick

    End Sub
End Class