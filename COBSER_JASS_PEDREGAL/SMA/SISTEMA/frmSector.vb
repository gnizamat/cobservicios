Imports ACCESO
Imports LOGICA
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Data.OleDb
Public Class frmSector
    Public c As New ACCESO.Conexion
    Public idsector As Integer

    Private Sub frmSector_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            clsJunta.LoadCombo(cmbJunta)
            If (frmPrincipal.userSystem.idInterfaz = 4) Then
                cmbJunta.SelectedValue = frmPrincipal.userSystem.idJunta
                cmbJunta.Enabled = False
            End If
            clsCentroPoblado.LoadComboADD(cmbCPoblado)
            cmbCPoblado.SelectedValue = 0
            dgSector.DataSource = clsSector.List

            'dgServicios.DataSource = clsTipoTarifa.List
            'CargaLista()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub cmbJunta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbJunta.SelectedIndexChanged

    End Sub

    Private Sub btnTarifaNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTarifaNew.Click
        Try

            Dim P As New clsSector(1, cmbCPoblado.SelectedValue, txtSector.Text, 1)
            If c.Connect Then
                P.Insert()
                dgSector.DataSource = clsSector.List()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnTarifaUpd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTarifaUpd.Click
        Try

            Dim P As New clsSector(idsector, cmbCPoblado.SelectedValue, txtSector.Text, 1)
            If c.Connect Then
                P.Update()
                MsgBox("Registro Actualizado correctamente", MsgBoxStyle.Information)
                dgSector.DataSource = clsSector.List()

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbCPoblado_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCPoblado.SelectedIndexChanged
        Try

            dgSector.DataSource = clsSector.List("Where Sector.idCP=" & cmbCPoblado.SelectedValue & "")
            'cmbSubTipoTarifa.SelectedIndex = 0
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgSector_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgSector.CellContentClick

    End Sub

    Private Sub dgSector_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgSector.SelectionChanged
        Try
            'Dim junta As String = Me.dgServicios.Item(0, Me.dgServicios.CurrentRow.Index).Value
            idsector = Me.dgSector.Item(0, Me.dgSector.CurrentRow.Index).Value
            Dim cp As Integer = Me.dgSector.Item(1, Me.dgSector.CurrentRow.Index).Value
            Dim sector As String = Me.dgSector.Item(2, Me.dgSector.CurrentRow.Index).Value

            ''idservicio = tiposervicio + 1
            'tipotaria = Me.dgSector.Item(1, Me.dgSector.CurrentRow.Index).Value
            cmbCPoblado.SelectedValue = cp
            txtSector.Text = sector
        Catch ex As Exception

        End Try
    End Sub
End Class