Imports System.IO
Imports LOGICA

Public Class frmJuntas
    Public idj As String
    Dim sqlExport As String = ""
    Dim vIdJuntaUsuario As String
    Public comision As New clsComisionRegante

    Public Sub Permisos()
        'nueva junta
        btnJuntaNew.Visible = COBSER.Menu.VerificaPermiso(39, frmPrincipal.userSystem.idGrupo)
        'editar junta
        btnJuntaUpd.Visible = COBSER.Menu.VerificaPermiso(40, frmPrincipal.userSystem.idGrupo)
        'eliminar junta
        btnJuntaDel.Visible = COBSER.Menu.VerificaPermiso(41, frmPrincipal.userSystem.idGrupo)
        'nueva comision
        btnComisionNew.Visible = COBSER.Menu.VerificaPermiso(42, frmPrincipal.userSystem.idGrupo)
        'editar comision
        btnComisionUpd.Visible = COBSER.Menu.VerificaPermiso(43, frmPrincipal.userSystem.idGrupo)
        'eliminar comision
        btnComisionDel.Visible = COBSER.Menu.VerificaPermiso(44, frmPrincipal.userSystem.idGrupo)
        'comites
        'btnComites.Visible = SIMIG.Menu.VerificaPermiso(45, frmPrincipal.userSystem.idGrupo)
    End Sub
    
    Private Sub frmJuntas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ViewJuntas.Image = ViewAll.Image
        Permisos()
        ViewJuntas.Tooltip = ViewAll.Text
        Select Case frmPrincipal.userSystem.idInterfaz
            Case 1, 2
                clsJunta.GeneraTree(tvJuntas)
            Case 3, 4
                clsJunta.GeneraTree(tvJuntas, "and j.vIdJuntaUsuario='" & frmPrincipal.userSystem.idJunta & "'")
                tvJuntas.SelectedNode = tvJuntas.Nodes.Item(0)
                pnlJuntas.Expanded = False
                pnlJuntas.Enabled = False

        End Select

    End Sub
 
    Private Sub btnJuntaNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnJuntaNew.Click
        frmJuntaNew.ShowDialog()
    End Sub

    Private Sub btnJuntaUpd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnJuntaUpd.Click
        Try
            Dim cad = Me.tvJuntas.SelectedNode.Tag
            frmJuntaUpd.ShowDialog()
        Catch
            MsgBox("Seleccione una junta de usuarios")
        End Try
    End Sub

    Private Sub tvJuntas_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvJuntas.AfterSelect
        Dim c As New ACCESO.Conexion
        Dim dt As New DataTable
        Dim cad As String = e.Node.Tag
        Dim tip As String = ""
        If (cad.Length >= 3) Then
            tip = cad.Substring(0, 2)
        End If
        If (c.Connect) Then
            If (String.Compare("J-", tip) = 0) Then
                idj = cad.Substring(2)
                vIdJuntaUsuario = idj
                dt = clsComisionRegante.List(" and j.vIdJuntaUsuario='" & idj & "'")
                gridComisiones.DataSource = dt
                gridComisiones.Columns(0).HeaderText = "Código"
                gridComisiones.Columns(1).HeaderText = "Comisión"
                gridComisiones.Columns(3).HeaderText = "Junta de Usuarios"
                gridComisiones.Columns(4).HeaderText = "Nº de Comites"
                gridComisiones.Columns(5).HeaderText = "Nº de Bloques"
                gridComisiones.Columns(2).Visible = False
                gridComisiones.Columns(0).Visible = False
                ExpandablePanel2.TitleText = "Comisión de Regantes - " & e.Node.Text
            End If
        End If
    End Sub

    Private Sub btnComisionNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnComisionNew.Click
        Dim isJunta As String = ""
        Dim m As TreeNode
        Try
            m = Me.tvJuntas.SelectedNode

            Dim cad As String = Me.tvJuntas.SelectedNode.Tag
            If (cad.Length >= 3) Then
                isJunta = cad.Substring(0, 2)
            End If
            If (String.Compare("J-", isJunta) = 0) Then
                frmComisionNew.ShowDialog()
            Else
                MsgBox("Debe seleccionar una junta")
            End If
        Catch
            MsgBox("Debe seleccionar una junta")
        End Try


    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        tvJuntas.Nodes.Clear()
        gridComisiones.DataSource = Nothing
        If (ViewJuntas.Text = ViewDistrito.Text) Then
            If (frmPrincipal.userSystem.idInterfaz = 3) Then
                clsDistritoRiego.GeneraTree(tvJuntas, " where iIdDistritoRiego='" & frmPrincipal.userSystem.idDistritoRiego & "'", " and j.vIdJuntaUsuario='" & frmPrincipal.userSystem.idJunta & "'")
            Else
                clsDistritoRiego.GeneraTree(tvJuntas)
            End If
        Else
            If (frmPrincipal.userSystem.idInterfaz = 3) Then
                clsJunta.GeneraTree(tvJuntas, "and j.vIdJuntaUsuario='" & frmPrincipal.userSystem.idJunta & "'")
            Else
                clsJunta.GeneraTree(tvJuntas)
            End If
        End If

    End Sub

  
    Private Sub txtBuscar_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBuscar.KeyUp
        Me.gridComisiones.DataSource = clsComisionRegante.List(" and j.vIdJuntaUsuario='" & idj & "' and c.vNombre like '%" & txtBuscar.ControlText & "%'")
    End Sub

    Private Sub ToolStripButton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnJuntaDel.Click
        Dim isJunta As String = ""

        Try

            Dim cad As String = Me.tvJuntas.SelectedNode.Tag
            isJunta = cad.Substring(0, 2)
            If (String.Compare("J-", isJunta) = 0) Then
                Dim m = MessageBox.Show("Desea eliminar el registro seleccionado?", "SMA", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If (m = Windows.Forms.DialogResult.Yes) Then
                    Dim id = cad.Substring(2)
                    clsJunta.delete(id)
                    Me.tvJuntas.Nodes.Clear()
                    clsJunta.GeneraTree(Me.tvJuntas)
                End If
            Else
                MsgBox("Debe seleccionar una junta")
            End If
        Catch ex As Exception
            MsgBox("Debe seleccionar una junta")
        End Try
    End Sub


    Private Sub btnComisionUpd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnComisionUpd.Click
        Dim id As String
        Dim flag As Boolean = True
        If (Me.gridComisiones.SelectedRows.Count > 0) Then
            Try
                id = Me.gridComisiones.Item(0, Me.gridComisiones.CurrentRow.Index).Value
            Catch ex As Exception
                flag = False
                MsgBox("Seleccione un registro valido")
            End Try
            If (flag) Then
                frmComisionUpd.ShowDialog()
            End If
        Else
            MsgBox("Seleccione una Comisión de Regantes")
        End If
    End Sub

    Private Sub btnComisionDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnComisionDel.Click
        Dim id As String
        If (Me.gridComisiones.SelectedRows.Count > 0) Then
            With Me.gridComisiones
                Try
                    id = .Item(0, .CurrentRow.Index).Value
                    Dim m = MessageBox.Show("Desea eliminar el registro seleccionado?", "SIRIG", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    If (m = Windows.Forms.DialogResult.Yes) Then
                        clsComisionRegante.delete(id, idj)
                        gridComisiones.DataSource = clsComisionRegante.List(" and j.vIdJuntaUsuario='" & idj & "'")
                    End If
                Catch ex As Exception
                    MsgBox("Seleccione un registro valido")
                End Try
            End With

        Else
            MsgBox("Seleccione una Comisión de Regantes")
        End If
    End Sub
    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarJunta.Click
        clsJunta.BuscarJunta(tvJuntas, txtSearchJunta.ControlText, True)
    End Sub

    Private Sub ToolStripButton9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportar.Click
        Dim node As New TreeNode
        Dim flag As Boolean = True
        Try
            node = tvJuntas.SelectedNode
        Catch ex As Exception
            flag = False
        End Try
        If (node Is Nothing) Then
            flag = False
        End If
        If (flag) Then
            If Not (Me.gridComisiones.SelectedRows.Count > 0) Then
                MsgBox("No existe Comisiones para la Junta seleccionada para exportar la información", MsgBoxStyle.Information, "SIGMA")
            Else
                Dim dtFecha As DateTime = DateTime.Now
                saveScript.InitialDirectory = Application.StartupPath & "\backups\mantenimiento"
                saveScript.Filter = "(*.sql)|*.sql"
                saveScript.FileName = "Comision - Junta " + Trim(tvJuntas.SelectedNode.Text) + " " & dtFecha.ToString("dd-MM-yyyy") & ".sql"
                saveScript.ShowDialog()
            End If
        Else
            MsgBox("Seleccione una Junta de Usuarios del Listado", MsgBoxStyle.Exclamation, "SIGMA")
        End If

    End Sub

    Private Sub saveScript_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles saveScript.FileOk

        '    sqlExport = clsComisionRegante.Export(" Where vIdJuntaUsuario='" & vIdJuntaUsuario & "'")
        '    sqlExport = sqlExport + clsComiteRegante.Export(" Where vIdJuntaUsuario='" & vIdJuntaUsuario & "'")
        '    Dim oSW As New StreamWriter(saveScript.FileName)
        '    oSW.WriteLine(sqlExport)
        '    oSW.Flush()
        '    oSW.Close()
        '    MsgBox("Se realizo la exportación con éxito..", MsgBoxStyle.Information, "Mensaje")
    End Sub

    Private Sub ButtonItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewAll.Click
        ViewJuntas.Image = ViewAll.Image
        ViewJuntas.Text = ViewAll.Text
        ViewJuntas.Tooltip = ViewAll.Text
        tvJuntas.Nodes.Clear()
        If (frmPrincipal.userSystem.idInterfaz = 3) Then
            clsJunta.GeneraTree(tvJuntas, "and j.vIdJuntaUsuario='" & frmPrincipal.userSystem.idJunta & "'")
        Else
            clsJunta.GeneraTree(tvJuntas)
        End If
    End Sub

    Private Sub ButtonItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewDistrito.Click
        ViewJuntas.Image = ViewDistrito.Image
        ViewJuntas.Text = ViewDistrito.Text
        ViewJuntas.Tooltip = ViewDistrito.Text
        tvJuntas.Nodes.Clear()
        If (frmPrincipal.userSystem.idInterfaz = 3) Then
            clsDistritoRiego.GeneraTree(tvJuntas, " where iIdDistritoRiego='" & frmPrincipal.userSystem.idDistritoRiego & "'", " and j.vIdJuntaUsuario='" & frmPrincipal.userSystem.idJunta & "'")
        Else
            clsDistritoRiego.GeneraTree(tvJuntas)
        End If
    End Sub


    'Private Sub btnBloques_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBloques.Click
    '    If (ValidaGridItemSeleccionado(gridComisiones)) Then
    '        Dim r As DataGridViewRow
    '        r = gridComisiones.CurrentRow
    '        comision = New clsComisionRegante(r.Cells(2).Value, r.Cells(1).Value)
    '        comision.id = r.Cells(0).Value
    '        'frmBloquesComision.ShowDialog()
    '    End If
    'End Sub
End Class