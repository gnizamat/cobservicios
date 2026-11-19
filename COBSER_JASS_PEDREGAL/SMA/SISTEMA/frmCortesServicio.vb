Imports ACCESO
Imports LOGICA
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Data.OleDb

Public Class frmCortesServicio
    Public idcalle As Integer
    Public usuario As String
    Public idPredio As Integer
    Public idjas As String
    Public predio As String
    Public dni As String
    Public nrocasa As String
    Public lote As String
    Public manzana As String
    'Public idcalle As Integer
    'Public winOrigen As Integer = 0
    Public idservicio As Integer
    Dim vf As New clsValidateForm
    Public FECHA As Date
    Public FECHACORTE As Date
    Public MOTIVO As Integer
    Dim estado As String
    'Public obj As clsCorteServicio




    Private Sub frmCortesServicio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            txtNombre.Text = usuario
            txtPredio.Text = predio
            txtNCasa.Text = nrocasa
            txtLote.Text = lote
            txtNCasa.Text = nrocasa
            txtManzana.Text = manzana
            txtDNI.Text = dni

            'clsCalles.LoadCombo(cmbCalle, "where idcalle= " & idcalle & "")
            'cmbCalle.SelectedValue = 1
            clsCalles.LoadCombo(cmbCalle)
            cmbCalle.SelectedValue = idcalle

            txtFechaRegistro.Text = ACCESO.Conexion.getDateServer
            txtFechaCorte.Text = ACCESO.Conexion.getDateServer

            clsTipoTarifa.LoadComboFijos(cmbServicios, Year(ACCESO.Conexion.getDateServer))
            cmbServicios.SelectedValue = idservicio
            cmbMotivo.SelectedIndex = 0
            cmbEstado.SelectedIndex = 2
            CARGAGRID()
        Catch ex As Exception

        End Try

        
    End Sub

    Private Sub LabelX14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LabelX14.Click

    End Sub

    Private Sub GroupPanel1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupPanel1.Click

    End Sub

    Private Sub TextBoxX4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLote.TextChanged

    End Sub

    Private Sub cmbMotivo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMotivo.SelectedIndexChanged
        Try
            'If (vf.startValidation) Then

            '    'txtValorServicio.Text = cmbServicios.SelectedItem(3).ToString

            'End If
            MOTIVO = cmbMotivo.SelectedIndex
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbServicios_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbServicios.SelectedIndexChanged
        Try
            txtValorServicio.Text = cmbServicios.SelectedItem(3).ToString
            'txtMonto.Text = cmbSubTipoTarifa.SelectedItem(5).ToString


        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim obj As New clsPago
        Dim DESCP As String
        Dim usua As String
        obj.IdPredio = idPredio

        'codigo = txtCodigo.Text
        FECHA = txtFechaRegistro.Text
        FECHACORTE = txtFechaCorte.Text
        idservicio = cmbServicios.SelectedValue
        obj.IdJAS = idjas
        usua = frmPrincipal.userSystem.usuario
        DESCP = txtDescripcion.Text

        'MOTIVO = cmbMotivo.SelectedItem
        Dim dt As New DataTable

        Dim u As New clsCorteServicio()
        u.Insert(idjas, idPredio, idservicio, FECHA, FECHACORTE, MOTIVO, DESCP, usua)
        CARGAGRID()
    End Sub

    Private Sub CARGAGRID()
        Dim dt As New DataTable
        If estado = 0 Then
            dt = clsCorteServicio.List(idPredio)
        End If
        If estado = 1 Then
            dt = clsCorteServicio.ListInactivos(idPredio)
        End If
        If estado = 2 Then
            dt = clsCorteServicio.ListTodos(idPredio)
        End If
        'dt = clsCorteServicio.List(idPredio)
        gridPredioCorte.DataSource = dt

        If gridPredioCorte.Rows.Count > 0 Then
            gridPredioCorte.Columns(0).Width = 50
            gridPredioCorte.Columns(1).Width = 60
            gridPredioCorte.Columns(2).Width = 90
            gridPredioCorte.Columns(3).Width = 70
            gridPredioCorte.Columns(4).Width = 80
            gridPredioCorte.Columns(5).Width = 80
            gridPredioCorte.Columns(6).Width = 80
            gridPredioCorte.Columns(7).Width = 80
            'gridPredios.Columns(5).Visible = False
            'gridPredios.Columns(6).Visible = False
            'gridPredios.Columns(7).Visible = False
            'gridPredios.Columns(10).Visible = False
            'gridPredios.Columns(3).Visible = False
            'gridPredios.Columns(13).Visible = False
        End If

    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim flag As Boolean = True
        Dim idpredio As Integer
        Dim idtipotarifa As Integer
        'Dim anio As Integer
        'Dim idmes As Integer
        Try
            If (ValidaGridItemSeleccionado(gridPredioCorte)) Then
                Dim corte As New clsCorteServicio
                Dim m = MessageBox.Show("Desea eliminar el registro seleccionado?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If (m = Windows.Forms.DialogResult.Yes) Then
                    idpredio = gridPredioCorte.Item(1, gridPredioCorte.CurrentRow.Index).Value
                    idtipotarifa = gridPredioCorte.Item(2, gridPredioCorte.CurrentRow.Index).Value
                    corte.update_corte(idpredio, idtipotarifa)
                    clsPrediosServicios.QuitarServicio(idpredio, idtipotarifa)
                    MsgBox("Corte Elimidado correctamente", MsgBoxStyle.Information)
                    CARGAGRID()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbEstado_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbEstado.SelectedIndexChanged
        Try
            If (vf.startValidation) Then
                'If cmbEstado.SelectedValue = 0 Then
                estado = cmbEstado.SelectedIndex
                If estado = 0 Then
                    estado = "0"
                End If
                If estado = 1 Then
                    estado = "1"
                End If
                If estado = 2 Then
                    estado = "2"
                End If

                CARGAGRID()
                'gridPredioCorte.DataSource = Filtrar()


            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ButtonItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem1.Click
        Dim flag As Boolean = True
        Dim idpredio As Integer
        Dim idtipotarifa As Integer
        'Dim anio As Integer
        'Dim idmes As Integer
        Try
            If (ValidaGridItemSeleccionado(gridPredioCorte)) Then
                Dim corte As New clsCorteServicio
                Dim m = MessageBox.Show("Desea Activar el registro seleccionado?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If (m = Windows.Forms.DialogResult.Yes) Then
                    idpredio = gridPredioCorte.Item(1, gridPredioCorte.CurrentRow.Index).Value
                    idtipotarifa = gridPredioCorte.Item(2, gridPredioCorte.CurrentRow.Index).Value
                    corte.activa_corte(idpredio, idtipotarifa)
                    'clsPrediosServicios.QuitarServicio(idpredio, idtipotarifa)
                    MsgBox("Corte Activado correctamente", MsgBoxStyle.Information)
                    CARGAGRID()
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub gridPredioCorte_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridPredioCorte.CellContentClick

    End Sub
End Class