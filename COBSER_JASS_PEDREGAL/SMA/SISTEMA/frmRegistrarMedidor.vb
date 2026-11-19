Imports ACCESO
Imports LOGICA
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Data.OleDb

Public Class frmRegistrarMedidor
    Public usuario As String
    Public dni As String
    Public nrocasa As String

    Public idPredio As Integer
    Public idJas As String
    Public codigo As String
    Public idmedidor As Integer
    Public winOrigen As Integer = 0
    Public tipotarifa As Integer
    Public PREDIO As String
    Public FECHA As Date
    Dim dtdeudas As New DataTable
    Public obj As clsMedidor


   

    Private Sub frmRegistrarMedidor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        clsJunta.LoadCombo(cmbJunta)

        If (frmPrincipal.userSystem.idInterfaz = 4) Then
            cmbJunta.SelectedValue = frmPrincipal.userSystem.idJunta
            cmbJunta.Enabled = False
        End If
        clsMedidor.LoadCombo(cmbTipoMedidor)
        cmbTipoMedidor.SelectedIndex = 0

        '''''
        'idJas = frmRegistrarMedidor.SelectedRows(0).Cells(10).Value
        'usuario = gridPredios.SelectedRows(0).Cells(2).Value
        'PREDIO = gridPredios.SelectedRows(0).Cells(8).Value
        'idPredio = gridPredios.SelectedRows(0).Cells(1).Value
        'nrocasa = gridPredios.SelectedRows(0).Cells(7).Value
        'dni = gridPredios.SelectedRows(0).Cells(0).Value

        '''''
        txtNombre.Text = usuario
        txtLote.Text = PREDIO
        txtNro.Text = nrocasa
        txtDNI.Text = dni
        txtCodigo.Text = ""
        txtFecha.Text = ACCESO.Conexion.getDateServer
        CARGAGRID()

    End Sub

    Private Sub cmbTipoMedidor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipoMedidor.SelectedIndexChanged
        txtCodigo.Focus()

    End Sub

    Private Sub ButtonItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem1.Click
        Dim idpredioe As Integer
        Dim idmedidore As Integer
        idmedidor = cmbTipoMedidor.SelectedValue
        codigo = txtCodigo.Text
        FECHA = txtFecha.Text

      
        Dim dt As New DataTable

        Dim u As New clsMedidor()
        If gridMedidor.Rows.Count = 0 Then
            u.Insert(cmbJunta.SelectedValue, idPredio, tipotarifa, idmedidor, codigo, FECHA)
            'Next
        End If
        'For i = 0 To gridMedidor.Rows.Count - 0
        'If gridMedidor.Rows.Count = 0 Then
        
        If gridMedidor.Rows.Count > 0 Then

            idpredioe = gridMedidor.Item(0, gridMedidor.CurrentRow.Index).Value
            idmedidore = gridMedidor.Item(8, gridMedidor.CurrentRow.Index).Value
            u.Insert(cmbJunta.SelectedValue, idPredio, tipotarifa, idmedidor, codigo, FECHA)
            clsMedidor.elimina(idpredioe, idmedidore)
        End If


        'numerror = numerror & "Deuda Generada para el predio " & nodo.Cells(7).Text.ToString & " del usuario " & nodo.Cells(2).Text.ToString & " no se genero correctamente" & Chr(13)
        CARGAGRID()
    End Sub
    Private Sub CARGAGRID()
        Dim dt As New DataTable
        dt = clsMedidor.List(idPredio)
        gridMedidor.DataSource = dt
        If gridMedidor.Rows.Count > 0 Then
            gridMedidor.Columns(0).Width = 50
            gridMedidor.Columns(1).Width = 60
            gridMedidor.Columns(2).Width = 90
            gridMedidor.Columns(3).Width = 70
            gridMedidor.Columns(4).Width = 80
            gridMedidor.Columns(5).Width = 80
            gridMedidor.Columns(6).Width = 80
            gridMedidor.Columns(7).Width = 80
            'gridPredios.Columns(5).Visible = False
            'gridPredios.Columns(6).Visible = False
            'gridPredios.Columns(7).Visible = False
            'gridPredios.Columns(10).Visible = False
            'gridPredios.Columns(3).Visible = False
            'gridPredios.Columns(13).Visible = False
        End If
       
    End Sub
    Private Sub txtFecha_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFecha.Click
        FECHA = txtFecha.Text
    End Sub

    Private Sub ButtonItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem4.Click
        Dim flag As Boolean = True
        Dim idpredio As Integer
        'Dim anio As Integer
        Dim idmes As Integer
        Try
            If (ValidaGridItemSeleccionado(gridMedidor)) Then
                Dim meididor As New clsMedidor
                Dim m = MessageBox.Show("Desea eliminar el registro seleccionado?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If (m = Windows.Forms.DialogResult.Yes) Then
                    'meididor.anio = gridMedidor.Item(6, gridMedidor.CurrentRow.Index).Value
                    idpredio = gridMedidor.Item(0, gridMedidor.CurrentRow.Index).Value
                    idmedidor = gridMedidor.Item(8, gridMedidor.CurrentRow.Index).Value
                    clsMedidor.elimina(idpredio, idmedidor)
                    MsgBox("Medidor Elimidado correctamente", MsgBoxStyle.Information)
                    CARGAGRID()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub gridMedidor_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridMedidor.CellContentClick

    End Sub

    Private Sub ButtonItem12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem12.Click
        Dim flag As Boolean = True
        Dim idpredio As Integer
        'Dim anio As Integer
        'Dim idmes As Integer
        Try
            If (ValidaGridItemSeleccionado(gridMedidor)) Then
                Dim meididor As New clsMedidor
                Dim m = MessageBox.Show("Desea eliminar el registro seleccionado?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If (m = Windows.Forms.DialogResult.Yes) Then
                    'meididor.anio = gridMedidor.Item(6, gridMedidor.CurrentRow.Index).Value
                    idpredio = gridMedidor.Item(0, gridMedidor.CurrentRow.Index).Value
                    idmedidor = gridMedidor.Item(8, gridMedidor.CurrentRow.Index).Value
                    clsMedidor.elimina(idpredio, idmedidor)
                    MsgBox("Medidor Desactivado correctamente", MsgBoxStyle.Information)
                    CARGAGRID()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ButtonItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem2.Click
        Dim flag As Boolean = True
        Dim idpredio As Integer
        'Dim anio As Integer
        'Dim idmes As Integer
        Try
            If (ValidaGridItemSeleccionado(gridMedidor)) Then
                Dim meididor As New clsMedidor
                Dim m = MessageBox.Show("Desea eliminar el registro seleccionado?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If (m = Windows.Forms.DialogResult.Yes) Then
                    'meididor.anio = gridMedidor.Item(6, gridMedidor.CurrentRow.Index).Value
                    idpredio = gridMedidor.Item(0, gridMedidor.CurrentRow.Index).Value
                    idmedidor = gridMedidor.Item(8, gridMedidor.CurrentRow.Index).Value
                    clsMedidor.ActivaMedidor(idpredio, idmedidor)
                    MsgBox("Medidor Activado correctamente", MsgBoxStyle.Information)
                    CARGAGRID()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class