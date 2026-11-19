Imports ACCESO
Imports LOGICA
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Data.OleDb


Public Class frmUsuarios
    Public winOrigen As Integer = 0
    'Public _usu As New clsUsuario
    Public _select As Boolean = False
    'Public iidusuario As Integer
    Dim idj As String
    Dim vf As New clsValidateForm
    

    


    Public Function Filtrar() As DataTable
        idj = "10501"

        Dim dt As New DataTable
        'filtro de usuarios

        Dim condicion As String = ""
        If (txtNombre.Text <> "") Then
            condicion &= " and vUsuario like '" & txtNombre.Text & "%'"
        End If
        If (txtAPaterno.Text <> "") Then
            condicion &= " and vApePaterno like '" & txtAPaterno.Text & "%'"
        End If
        If (txtAMaterno.Text <> "") Then
            condicion &= " and vApeMaterno like '" & txtAMaterno.Text & "%'"
        End If
        If (txtDNI.Text <> "") Then
            condicion &= " and vDNI like '%" & txtDNI.Text & "%'"
        End If
        If (txtRUC.Text <> "") Then
            condicion &= " and vRUC like '%" & txtRUC.Text & "%'"
        End If
        'dt = (" and vIdJuntaUsuario='" & idj & "'" & condicion, "1")
        dt = clsUsuario.List(" and vIdJas='" & idj & "'" & condicion, "1")

        'fin filtro
        txtNroUsuarios.Text = Val(dt.Rows.Count)
        Return dt
    End Function
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CargaGrid()

    End Sub
    Private Sub CargaGrid()
        Dim dt As New DataTable

        dt = clsUsuario.List(" ORDER BY vApePaterno, vApeMaterno, vUsuario")
        'dt = clsUsuario.List()

        gridUsuarios.DataSource = dt
        If gridUsuarios.Rows.Count > 0 Then
            gridUsuarios.Columns(0).Width = 50
            gridUsuarios.Columns(1).Width = 50
            gridUsuarios.Columns(2).Width = 80
            gridUsuarios.Columns(3).Width = 80
            gridUsuarios.Columns(4).Width = 80

            'gridUsuarios.Columns(4).Visible = False
            'gridUsuarios.Columns(5).Visible = False
            'gridUsuarios.Columns(6).Visible = False
        End If
        txtNroUsuarios.Text = Val(dt.Rows.Count)
    End Sub

    Private Sub btnUsuarioNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUsuarioNew.Click
        Dim isJunta As String = ""
        'Dim m As TreeNode
        'Try
        'm = Me.tvJuntas.SelectedNode
        'Dim cad As String = Me.tvJuntas.SelectedNode.Tag
        'isJunta = cad.Substring(0, 2)
        'If (String.Compare("J-", isJunta) = 0) Then
        frmUsuarioNew.ShowDialog()
        'Else
        '    MsgBox("Debe seleccionar una junta")
        'End If
        'Catch
        '    MsgBox("Debe seleccionar una junta")
        'End Try

    End Sub

    Private Sub txtNombre_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNombre.KeyUp
        If (vf.startValidation) Then
            gridUsuarios.DataSource = Filtrar()
        End If
    End Sub

    Private Sub txtNombre_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNombre.TextChanged

    End Sub

    Private Sub txtAPaterno_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAPaterno.KeyUp
        If (vf.startValidation) Then
            gridUsuarios.DataSource = Filtrar()
        End If
    End Sub

    Private Sub txtAPaterno_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAPaterno.TextChanged

    End Sub

    Private Sub txtDNI_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDNI.KeyUp
        If (vf.startValidation) Then
            gridUsuarios.DataSource = Filtrar()
        End If
    End Sub

    Private Sub txtDNI_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDNI.TextChanged

    End Sub

    Private Sub txtAMaterno_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAMaterno.KeyUp
        If (vf.startValidation) Then
            gridUsuarios.DataSource = Filtrar()
        End If
    End Sub

    Private Sub txtAMaterno_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAMaterno.TextChanged

    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        txtNombre.Text = ""
        txtAPaterno.Text = ""
        txtAMaterno.Text = ""
        txtDNI.Text = ""
        txtAPaterno.Focus()

    End Sub

    Private Sub btnUsuarioUpd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUsuarioUpd.Click
        If (Me.gridUsuarios.SelectedRows.Count > 0) Then
            frmUsuariosUpd.ShowDialog()
            'Filtrar()
        Else
            MsgBox("Seleccione un Usuario")
        End If
    End Sub

    Private Sub btnUsuarioDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUsuarioDel.Click
        Dim flag As Boolean = True
        Dim id As Integer
        If (Me.gridUsuarios.SelectedRows.Count > 0) Then
            Try
                id = Me.gridUsuarios.Item(1, Me.gridUsuarios.CurrentRow.Index).Value
                idj = Me.gridUsuarios.Item(0, Me.gridUsuarios.CurrentRow.Index).Value
            Catch ex As Exception
                flag = False
                MsgBox("Seleccione una fila valida")
            End Try
            If (flag) Then
                Dim m = MessageBox.Show("Desea eliminar el registro seleccionado?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If (m = Windows.Forms.DialogResult.Yes) Then
                    clsUsuario.delete(id, idj)
                    gridUsuarios.DataSource = Filtrar()
                End If
            End If
        Else
            MsgBox("Seleccione un Usuario")
        End If
    End Sub

    Private Sub btnSeleccionar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSeleccionar.Click
        If (Me.gridUsuarios.SelectedRows.Count > 0) Then
            '_select = True
            '_usuario.idJas = Me.gridUsuarios.Item(1, Me.gridUsuarios.CurrentRow.Index).Value
            '_usuario.id = Me.gridUsuarios.Item(0, Me.gridUsuarios.CurrentRow.Index).Value
            ''_usuario.NombreCompleto = Me.gridUsuarios.Item(4, Me.gridUsuarios.CurrentRow.Index).Value & " " & Me.gridUsuarios.Item(5, Me.gridUsuarios.CurrentRow.Index).Value & ", " & Me.gridUsuarios.Item(3, Me.gridUsuarios.CurrentRow.Index).Value

            Select winOrigen
                Case 2
                    frmPredioNew.txtUsuario.Text = Me.gridUsuarios.Item(3, Me.gridUsuarios.CurrentRow.Index).Value & " " & Me.gridUsuarios.Item(4, Me.gridUsuarios.CurrentRow.Index).Value & ", " & Me.gridUsuarios.Item(2, Me.gridUsuarios.CurrentRow.Index).Value
                    frmPredioNew.idJas = Me.gridUsuarios.Item(0, Me.gridUsuarios.CurrentRow.Index).Value
                    frmPredioNew.idUsuario = Me.gridUsuarios.Item(1, Me.gridUsuarios.CurrentRow.Index).Value

                Case 3

                    frmTransferenciaPredios.txtUsuario1.Text = Me.gridUsuarios.Item(3, Me.gridUsuarios.CurrentRow.Index).Value & " " & Me.gridUsuarios.Item(4, Me.gridUsuarios.CurrentRow.Index).Value & ", " & Me.gridUsuarios.Item(2, Me.gridUsuarios.CurrentRow.Index).Value
                    frmTransferenciaPredios.idUsu = Me.gridUsuarios.Item(1, Me.gridUsuarios.CurrentRow.Index).Value
                    frmTransferenciaPredios.iidusuario = Me.gridUsuarios.Item(1, Me.gridUsuarios.CurrentRow.Index).Value

                    Dim dt As New DataTable
                    'dt = frmTransferenciaPredio.ListTranferencia(" and up.cEstado=1")
                    dt = frmTransferenciaPredios.usuario1.ListTranferencia(" WHERE iIdusuario= " & frmTransferenciaPredios.idUsu & " AND cEstado=1")

                    frmTransferenciaPredios.dgPredios1.Rows.Clear()
                    For Each midatarow As DataRow In dt.Rows
                        frmTransferenciaPredios.dgPredios1.Rows.Add(midatarow(0), midatarow(1), midatarow(2), midatarow(3), midatarow(4), midatarow(5), midatarow(6), midatarow(7), midatarow(8))
                    Next
                Case 4
                    frmTransferenciaPredios.txtUsuario2.Text = Me.gridUsuarios.Item(3, Me.gridUsuarios.CurrentRow.Index).Value & " " & Me.gridUsuarios.Item(4, Me.gridUsuarios.CurrentRow.Index).Value & ", " & Me.gridUsuarios.Item(2, Me.gridUsuarios.CurrentRow.Index).Value
                    frmTransferenciaPredios.idUsu = Me.gridUsuarios.Item(1, Me.gridUsuarios.CurrentRow.Index).Value

                    Dim dt As New DataTable
                    'dt = frmTransferenciaPredio.ListTranferencia(" and up.cEstado=1")
                    dt = frmTransferenciaPredios.Usuario2.ListTranferencia(" WHERE iIdusuario= " & frmTransferenciaPredios.idUsu & " AND cEstado=1")
                    frmTransferenciaPredios.dgPredios2.Rows.Clear()
                    For Each midatarow As DataRow In dt.Rows
                        frmTransferenciaPredios.dgPredios2.Rows.Add(midatarow(0), midatarow(1), midatarow(2), midatarow(3), midatarow(4), midatarow(5), midatarow(6), midatarow(7), midatarow(8))
                    Next
                Case Else

            End Select
                    Me.winOrigen = 0
                    Me.Close()

        Else
            _select = False
            MsgBox("Seleccione un Usuario")
        End If
    End Sub

    Private Sub btnPredios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPredios.Click
        If (Me.gridUsuarios.SelectedRows.Count > 0) Then
            frmPredios.ShowDialog()
        Else
            MsgBox("Seleccione un Usuario")
        End If
    End Sub

    Private Sub ExpandablePanel2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExpandablePanel2.Click

    End Sub
End Class