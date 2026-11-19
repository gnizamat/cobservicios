Imports ACCESO
Imports LOGICA
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Data.OleDb
Public Class frmAsambleas
    Public c As New ACCESO.Conexion
    Public idAsamblea As Integer
    Public id As Integer
    Public idCP As Integer
    Public tipoa As Integer
    Public ambito As Integer
    Public dfecha As Date


    Private Sub frmAsambleas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            clsJunta.LoadCombo(cmbJunta)
            If (frmPrincipal.userSystem.idInterfaz = 4) Then
                cmbJunta.SelectedValue = frmPrincipal.userSystem.idJunta
                cmbJunta.Enabled = False
            End If
            clsCentroPoblado.LoadComboADD(cmbCPoblado)
            cmbCPoblado.SelectedIndex = 0
            cmbAmbito.SelectedIndex = 0
            cmbTipoAsamblea.SelectedIndex = 0
            txtFecha.Text = ACCESO.Conexion.getDateServer
            dgAsambleas.DataSource = clsAsambleas.List

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnResolucionNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResolucionNew.Click
        'Dim obj As New clsAsambleas
        tipoa = cmbTipoAsamblea.SelectedIndex
        ambito = cmbAmbito.SelectedIndex
        dfecha = txtFecha.Text
        idAsamblea = Me.dgAsambleas.Item(0, Me.dgAsambleas.CurrentRow.Index).Value
        Try
            Dim P As New clsAsambleas(idAsamblea, txtDescripcion.Text, txtAnio.Text, "1", tipoa, ambito, cmbJunta.SelectedValue, cmbCPoblado.SelectedValue, dfecha)
            If c.Connect Then
                P.Insert()
                dgAsambleas.DataSource = clsAsambleas.List
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbJunta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbJunta.SelectedIndexChanged

    End Sub
    Private Sub dgAsambleas_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgAsambleas.SelectionChanged
        Try
            Dim texto As String = cmbTipoAsamblea.SelectedItem.ToString()
            Dim texto1 As String = cmbTipoAsamblea.SelectedItem.ToString()
            Dim idA As Integer = Me.dgAsambleas.Item(0, Me.dgAsambleas.CurrentRow.Index).Value
            Dim descripcion As String = Me.dgAsambleas.Item(1, Me.dgAsambleas.CurrentRow.Index).Value
            Dim anio As String = Me.dgAsambleas.Item(2, Me.dgAsambleas.CurrentRow.Index).Value
            Dim estado As String = Me.dgAsambleas.Item(3, Me.dgAsambleas.CurrentRow.Index).Value
            Dim tipo As Integer = Me.dgAsambleas.Item(4, Me.dgAsambleas.CurrentRow.Index).Value


            Dim ambito As Integer = Me.dgAsambleas.Item(5, Me.dgAsambleas.CurrentRow.Index).Value
            Dim idcp As Integer = Me.dgAsambleas.Item(7, Me.dgAsambleas.CurrentRow.Index).Value
            Dim fecha As String = Me.dgAsambleas.Item(8, Me.dgAsambleas.CurrentRow.Index).Value

            idA = Me.dgAsambleas.Item(0, Me.dgAsambleas.CurrentRow.Index).Value
            txtDescripcion.Text = descripcion

            cmbCPoblado.SelectedValue = Convert.ToInt32(idcp)
            txtAnio.Text = anio
            cmbTipoAsamblea.SelectedIndex = tipo
            cmbAmbito.SelectedIndex = ambito

            txtFecha.Text = fecha

        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgAsambleas_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgAsambleas.CellContentClick
        id = Me.dgAsambleas.Item(0, Me.dgAsambleas.CurrentRow.Index).Value
    End Sub

    Private Sub btnResolucionUpd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResolucionUpd.Click

        Try

            id = Me.dgAsambleas.Item(0, Me.dgAsambleas.CurrentRow.Index).Value

            Dim u As New clsAsambleas(id, txtDescripcion.Text, txtAnio.Text, "0", tipoa, ambito, cmbJunta.SelectedValue, cmbCPoblado.SelectedValue, txtFecha.Text)
            If c.Connect Then
                'idAsamblea = Me.dgAsambleas.Item(0, Me.dgAsambleas.CurrentRow.Index).Value
                u.Update()
                MsgBox("Registro Actualizado correctamente", MsgBoxStyle.Information)
                dgAsambleas.DataSource = clsAsambleas.List
                'dgCalles.DataSource = clsCalles.List
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnResolucionDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResolucionDel.Click
        Dim flag As Boolean = True

        Dim idAsamblea As Integer
        Try
            If (ValidaGridItemSeleccionado(dgAsambleas)) Then
                'Dim calle As New clsCalles
                Dim m = MessageBox.Show("Desea eliminar el registro seleccionado?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If (m = Windows.Forms.DialogResult.Yes) Then
                    idAsamblea = dgAsambleas.Item(0, dgAsambleas.CurrentRow.Index).Value

                    clsAsambleas.delete(idAsamblea)
                    MsgBox("Calle Elimidada correctamente", MsgBoxStyle.Information)
                    dgAsambleas.DataSource = clsAsambleas.List
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnActiva_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActiva.Click
        Dim id As Integer
        Dim x As String
        If (Me.dgAsambleas.SelectedRows.Count > 0) Then
            Try
                id = Me.dgAsambleas.Item(0, Me.dgAsambleas.CurrentRow.Index).Value
                x = Me.dgAsambleas.Item(3, Me.dgAsambleas.CurrentRow.Index).Value
                If (x = 0) Then
                    clsAsambleas.ActivaDesactiva(id, 1)
                Else
                    clsAsambleas.ActivaDesactiva(id, 0)
                End If
                dgAsambleas.DataSource = clsAsambleas.List()
            Catch ex As Exception
                MsgBox("Seleccione un Asamblea", MsgBoxStyle.Information, "Mensaje")
            End Try

        Else
            MsgBox("Seleccione Asamblea", MsgBoxStyle.Information, "Mensaje")
        End If
    End Sub

    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
        Dim c As New Conexion
        Dim sql As String
        Dim DT As New DataTable
        Try
            If c.Connect Then
                'c.Query("DROP VIEW View_AsistenciaUsuarios ")
                'c.Query("drop table PAD_ASISTENCIAUSUARIOS")
                If (ValidaGridItemSeleccionado(dgAsambleas)) Then
                    idAsamblea = dgAsambleas.Item(0, dgAsambleas.CurrentRow.Index).Value
                    idCP = dgAsambleas.Item(7, dgAsambleas.CurrentRow.Index).Value
                    'sql = "exec pad_GeneraPadronAsistencia '10501',1," & idAsamblea & ", " & idCP & ""
                    sql = "exec pad_GeneraPadronAsistencia " & idAsamblea & ", " & idCP & ""
                    'c.Query(sql)
                    DT = c.Query(sql)
                    MsgBox("padron generado")
                End If

                'sql = "alter table PAD_ASISTENCIAUSUARIOS add ASISTENCIA BIT NOT NULL DEFAULT(0)"
                'c.Query(sql)

                'sql = "create VIEW [dbo].[View_AsistenciaUsuarios] " _
                '& " AS " _
                '& " SELECT dbo.PAD_ASISTENCIAUSUARIOS.CORRELATIVO,dbo.PAD_ASISTENCIAUSUARIOS.vIdJuntaUsuario, dbo.JuntaUsuario.vNombre, dbo.PAD_ASISTENCIAUSUARIOS.comision, dbo.PAD_ASISTENCIAUSUARIOS.iIdUsuario, " _
                '& " dbo.PAD_ASISTENCIAUSUARIOS.usuario, dbo.PAD_ASISTENCIAUSUARIOS.vDNI, dbo.PAD_ASISTENCIAUSUARIOS.habil, dbo.PAD_ASISTENCIAUSUARIOS.ASISTENCIA" _
                '& " FROM  dbo.PAD_ASISTENCIAUSUARIOS INNER JOIN  dbo.JuntaUsuario ON dbo.PAD_ASISTENCIAUSUARIOS.vIdJuntaUsuario = dbo.JuntaUsuario.vIdJuntaUsuario"

                ''sql = "create VIEW [dbo].[View_AsistenciaUsuarios]  AS SELECT dbo.PAD_ASISTENCIAUSUARIOS.CORRELATIVO, dbo.PAD_ASISTENCIAUSUARIOS.vDNI AS Documento, dbo.PAD_ASISTENCIAUSUARIOS.usuario, dbo.PAD_ASISTENCIAUSUARIOS.comision, dbo.JuntaUsuario.vNombre AS Junta, dbo.PAD_ASISTENCIAUSUARIOS.iIdUsuario, dbo.PAD_ASISTENCIAUSUARIOS.habil, dbo.PAD_ASISTENCIAUSUARIOS.ASISTENCIA, dbo.PAD_ASISTENCIAUSUARIOS.vIdJuntaUsuario FROM   dbo.PAD_ASISTENCIAUSUARIOS INNER JOIN dbo.JuntaUsuario ON dbo.PAD_ASISTENCIAUSUARIOS.vIdJuntaUsuario = dbo.JuntaUsuario.vIdJuntaUsuario"
                'c.Query(sql)
                MsgBox("Padron Generado")

            End If

        Catch ex As Exception

        End Try
    End Sub

    
End Class