Imports ACCESO
Imports LOGICA
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Data.OleDb
Public Class frmCostosTarifas
    Public c As New ACCESO.Conexion
    Public anio As String
    Public tipotaria As Integer


    Private Sub frmCostosTarifas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim _tarifa As New clsAnioTarifa
            clsJunta.LoadCombo(cmbJunta)
            If (frmPrincipal.userSystem.idInterfaz = 4) Then
                cmbJunta.SelectedValue = frmPrincipal.userSystem.idJunta
                cmbJunta.Enabled = False
            End If
            clsAnioTarifa.LoadCombo(cmbAnio)
            cmbAnio.SelectedIndex = 0
            clsTipoTarifa.LoadComboTodos(cmbServicios)
            cmbServicios.SelectedIndex = 0
            caragarGrid()
            'dgServicios.DataSource = clsCostosServicios.List("Where iAnioTarifa='" & cmbAnio.Text & "' ")
            'dgServicios.DataSource = clsCostosServicios.List
            'CargaLista()

        Catch ex As Exception

        End Try
    End Sub
    Private Sub caragarGrid()
        Dim dt As DataTable
        Dim sqltext As String
        Try


            sqltext = " WHERE (iAnioTarifa='" & cmbAnio.Text & "')"
            dt = clsCostosServicios.List(sqltext)
            dgServicios.DataSource = dt

        Catch ex As Exception

        End Try
    End Sub
    Private Sub cmbAnio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAnio.SelectedIndexChanged
        Try
            caragarGrid()
            'dgServicios.DataSource = clsCostosServicios.List("Where iAnioTarifa='" & cmbAnio.Text & "' ")
            'cmbSubTipoTarifa.SelectedIndex = 0
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnTarifaNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTarifaNew.Click
        Try

            Dim P As New clsCostosServicios(cmbAnio.SelectedValue, cmbJunta.SelectedValue, cmbServicios.SelectedValue, txtmonto.Text, txtvalor.Text)
            If c.Connect Then
                P.Insert()
                dgServicios.DataSource = clsCostosServicios.List("Where iAnioTarifa='" & cmbAnio.Text & "' ")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnTarifaUpd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTarifaUpd.Click
        Try

            Dim P As New clsCostosServicios(anio, cmbJunta.SelectedValue, cmbServicios.SelectedValue, txtmonto.Text, txtvalor.Text)
            If c.Connect Then
                P.Update()
                MsgBox("Registro Actualizado correctamente", MsgBoxStyle.Information)
                dgServicios.DataSource = clsCostosServicios.List("Where iAnioTarifa='" & cmbAnio.Text & "' ")
                
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgServicios_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgServicios.CellContentClick

    End Sub

    Private Sub dgServicios_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgServicios.SelectionChanged

        Try

            Dim junta As String = Me.dgServicios.Item(1, Me.dgServicios.CurrentRow.Index).Value
            Dim valor As Double = Me.dgServicios.Item(3, Me.dgServicios.CurrentRow.Index).Value
            Dim monto As Double = Me.dgServicios.Item(4, Me.dgServicios.CurrentRow.Index).Value

            anio = Me.dgServicios.Item(0, Me.dgServicios.CurrentRow.Index).Value
            tipotaria = Me.dgServicios.Item(2, Me.dgServicios.CurrentRow.Index).Value

            cmbAnio.SelectedValue = anio
            cmbServicios.SelectedValue = tipotaria
            txtvalor.Text = valor
            txtmonto.Text = monto

        Catch ex As Exception

        End Try
    End Sub

    Private Sub ButtonItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem3.Click
        Dim flag As Boolean = True
        Dim idcalle As Integer
        Dim idsector As Integer
        Dim idcp As Integer
        Try
            If (ValidaGridItemSeleccionado(dgServicios)) Then
                'Dim calle As New clsCalles
                Dim m = MessageBox.Show("Desea eliminar el registro seleccionado?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If (m = Windows.Forms.DialogResult.Yes) Then
                    anio = dgServicios.Item(0, dgServicios.CurrentRow.Index).Value
                    tipotaria = dgServicios.Item(2, dgServicios.CurrentRow.Index).Value
                    'idcp = dgServicios.Item(6, dgServicios.CurrentRow.Index).Value
                    clsCostosServicios.delete(anio, tipotaria)
                    MsgBox("Servicio Elimidada correctamente", MsgBoxStyle.Information)
                    dgServicios.DataSource = clsCostosServicios.List("Where iAnioTarifa='" & cmbAnio.Text & "' ")

                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
End Class