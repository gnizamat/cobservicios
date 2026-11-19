Imports ACCESO
Imports LOGICA
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Data.OleDb
Public Class frmServicios
    Public c As New ACCESO.Conexion
    'Public anio As String
    Public tipotaria As Integer
    Private Sub frmServicios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try

            clsJunta.LoadCombo(cmbJunta)
            If (frmPrincipal.userSystem.idInterfaz = 4) Then
                cmbJunta.SelectedValue = frmPrincipal.userSystem.idJunta
                cmbJunta.Enabled = False
            End If

            dgServicios.DataSource = clsTipoTarifa.List
            'CargaLista()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnTarifaNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTarifaNew.Click
        Try

            Dim P As New clsTipoTarifa(cmbJunta.SelectedValue, 1, txtServicio.Text, 1, cmbTipoServicio.SelectedIndex)
            If c.Connect Then
                P.Insert()
                dgServicios.DataSource = clsTipoTarifa.List()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgServicios_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgServicios.CellContentClick

    End Sub

    Private Sub dgServicios_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgServicios.SelectionChanged
        Try
            Dim junta As String = Me.dgServicios.Item(0, Me.dgServicios.CurrentRow.Index).Value
            Dim idtipotarifa As Integer = Me.dgServicios.Item(1, Me.dgServicios.CurrentRow.Index).Value
            Dim servicio As String = Me.dgServicios.Item(2, Me.dgServicios.CurrentRow.Index).Value
            Dim tiposervicio As Integer = Me.dgServicios.Item(5, Me.dgServicios.CurrentRow.Index).Value
            'idservicio = tiposervicio + 1
            tipotaria = Me.dgServicios.Item(1, Me.dgServicios.CurrentRow.Index).Value
            cmbTipoServicio.SelectedIndex = Val(tiposervicio.ToString)
            txtServicio.Text = servicio
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnTarifaUpd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTarifaUpd.Click
        Try

            Dim P As New clsTipoTarifa(cmbJunta.SelectedValue, tipotaria, txtServicio.Text, 1, cmbTipoServicio.SelectedIndex)
            If c.Connect Then
                P.Update()
                MsgBox("Registro Actualizado correctamente", MsgBoxStyle.Information)
                dgServicios.DataSource = clsTipoTarifa.List()

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ButtonItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem3.Click
        Dim cmd As New SqlCommand()
        Dim c As New ACCESO.Conexion
        If (c.Connect) Then
            cmd.CommandText = "UPDATE tarTipoTarifa SET  cEstado=0 WHERE  iIdTipoTarifa=" & tipotaria & " "
            'cmd.Parameters.AddWithValue("@ANIO", Me._Anio)
            If (c.Update(cmd) = False) Then
                MsgBox(c.msgError)

            End If
            MsgBox("Registro Eliminado", MsgBoxStyle.Information)
            dgServicios.DataSource = clsTipoTarifa.List()
            c.Close()
        End If
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
End Class