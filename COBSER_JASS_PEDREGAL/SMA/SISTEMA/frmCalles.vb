Imports ACCESO
Imports LOGICA
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Data.OleDb
Public Class frmCalles
    Public c As New ACCESO.Conexion
    Public idcalle As Integer


    Private Sub frmCalles_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            clsJunta.LoadCombo(cmbJunta)
            If (frmPrincipal.userSystem.idInterfaz = 4) Then
                cmbJunta.SelectedValue = frmPrincipal.userSystem.idJunta
                cmbJunta.Enabled = False
            End If
            clsCentroPoblado.LoadComboADD(cmbCPoblado)
            cmbCPoblado.SelectedValue = 0
            
            clsSector.LoadComboSectorCalle(cmbsector)
            cmbsector.SelectedValue = 0
            clsTipoCalles.LoadCombo(cmbTipoCalle)
            cmbTipoCalle.SelectedValue = 1
            dgCalles.DataSource = clsCalles.List

            'dgServicios.DataSource = clsTipoTarifa.List
            'CargaLista()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbJunta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbJunta.SelectedIndexChanged

    End Sub

    Private Sub cmbCPoblado_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCPoblado.SelectedIndexChanged
        
    End Sub

    Private Sub btnTarifaNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTarifaNew.Click
        Try
           
            Dim P As New clsCalles(cmbJunta.SelectedValue, cmbsector.SelectedValue, txtCalle.Text, txtReferencia.Text, cmbTipoCalle.SelectedValue, cmbCPoblado.SelectedValue)
            If c.Connect Then
                P.Insert()
                dgCalles.DataSource = clsCalles.List
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ButtonItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem3.Click
        Dim flag As Boolean = True
        Dim idcalle As Integer
        Dim idsector As Integer
        Dim idcp As Integer
        Try
            If (ValidaGridItemSeleccionado(dgCalles)) Then
                'Dim calle As New clsCalles
                Dim m = MessageBox.Show("Desea eliminar el registro seleccionado?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If (m = Windows.Forms.DialogResult.Yes) Then
                    idcalle = dgCalles.Item(0, dgCalles.CurrentRow.Index).Value
                    idsector = dgCalles.Item(1, dgCalles.CurrentRow.Index).Value
                    idcp = dgCalles.Item(6, dgCalles.CurrentRow.Index).Value
                    clsCalles.delete(idcalle, idcp, idsector)
                    MsgBox("Calle Elimidada correctamente", MsgBoxStyle.Information)
                    dgCalles.DataSource = clsCalles.List
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgCalles_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgCalles.CellContentClick
       
    End Sub

    Private Sub dgCalles_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgCalles.SelectionChanged
        Try

            Dim centroP As String = Me.dgCalles.Item(6, Me.dgCalles.CurrentRow.Index).Value
            Dim sector As String = Me.dgCalles.Item(1, Me.dgCalles.CurrentRow.Index).Value
            Dim calle As String = Me.dgCalles.Item(2, Me.dgCalles.CurrentRow.Index).Value
            Dim referencia As String = Me.dgCalles.Item(3, Me.dgCalles.CurrentRow.Index).Value
            Dim idtipocalle As Integer = Me.dgCalles.Item(4, Me.dgCalles.CurrentRow.Index).Value
            idcalle = Me.dgCalles.Item(0, Me.dgCalles.CurrentRow.Index).Value
            cmbCPoblado.SelectedValue = centroP
            cmbsector.SelectedValue = sector
            txtCalle.Text = calle
            txtReferencia.Text = referencia
            cmbTipoCalle.SelectedValue = idtipocalle



        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnTarifaUpd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTarifaUpd.Click

        Try

            Dim P As New clsCalles(idcalle, cmbsector.SelectedValue, txtCalle.Text, txtReferencia.Text, cmbTipoCalle.SelectedValue, cmbCPoblado.SelectedValue)
            If c.Connect Then
                P.Update()
                MsgBox("Registro Actualizado correctamente", MsgBoxStyle.Information)
                dgCalles.DataSource = clsCalles.List
                'dgCalles.DataSource = clsCalles.List
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub txtCalle_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCalle.TextChanged

    End Sub
End Class