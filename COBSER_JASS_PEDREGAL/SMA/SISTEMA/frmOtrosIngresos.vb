Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Data.OleDb
Imports ACCESO
Imports LOGICA
Public Class frmOtrosIngresos
    Public ReciboD As String
    Public fechaini As String
    Public fechafin As String
    Public tipodeuda As Integer
    'Dim fserver As Date
    Private Sub frmOtrosIngresos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        clsJunta.LoadCombo(cmbJunta)
        If (frmPrincipal.userSystem.idInterfaz = 4) Then
            cmbJunta.SelectedValue = frmPrincipal.userSystem.idJunta
            cmbJunta.Enabled = False
        End If
        clsCentroPoblado.LoadComboADD(cmbCPoblado)
        clsTipoIngreso.LoadCombo(cmbTipoIngreso)
        txtFInicio.Value = ACCESO.Conexion.getDateServer
        txtFFin.Value = ACCESO.Conexion.getDateServer
        lblFecha.Text = ACCESO.Conexion.getDateServer
        caragarGrid()
    End Sub

    Private Sub cmbTipoIngreso_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipoIngreso.SelectedIndexChanged
        SearchIngresos()

    End Sub
    Public Sub SearchIngresos()
        Try
            Dim dt As New DataTable
            Dim montototal As Decimal

            Dim condicion1 As String = ""
            Dim condicion2 As String = ""
            Dim condicion3 As String = ""
            If (txtFInicio.Text <> "") Then
                condicion1 = " and convert(datetime,dFecha,103)>=convert(datetime,'" & txtFInicio.Text & "',103)"
            End If
            If (txtFFin.Text <> "") Then
                condicion2 = " and convert(datetime,dFecha,103)<=convert(datetime,'" & txtFFin.Text & "',103)"
            End If
            If (cmbTipoIngreso.SelectedValue <> 0) Then
                condicion3 = " and  idTipoIngreso='" & cmbTipoIngreso.SelectedValue & "'"
            End If
            'dgIngresos.DataSource = clsOtrosIngresos.List(" where idCP='" & cmbCPoblado.SelectedValue & "'" & condicion1 & condicion2 & condicion3)
            dgIngresos.DataSource = clsOtrosIngresos.ListPagos(" where idCP='" & cmbCPoblado.SelectedValue & "'" & condicion1 & condicion2 & condicion3)
            
            'dgIngresos.DataSource = dt

            'dgIngresos.Columns(0).Visible = False
            'dgIngresos.Columns(1).Visible = False
            'dgIngresos.Columns(4).Visible = False
            'dgIngresos.Columns(5).Visible = False
            'dgIngresos.Columns(3).HeaderText = "FECHA"
            ''dgIngresos.Columns(4).Visible = False
            ''dgIngresos.Columns(5).Visible = False
            'dgIngresos.Columns(6).HeaderText = "DOCUMENTO"
            'dgIngresos.Columns(7).HeaderText = "NOBRES"
            'dgIngresos.Columns(9).HeaderText = "MONTO"
            ''dgIngresos.Columns(9).Visible = False
            'dgIngresos.Columns(10).HeaderText = "Documento"
            'dgIngresos.Columns(11).HeaderText = "Nº Documento"
            For Each r As DataGridViewRow In dgIngresos.Rows
                montototal += CDec(r.Cells("fMonto").Value)
            Next
            lblMontoTotal.Text = FormatCurrency(montototal, 2)
            'lblRegistros.Text = String.Format("{0} registros encontrados", dgFacturaciones.Rows.Count)
        Catch ex As Exception

        End Try
    End Sub
    Sub LoadCobranzas()

        Dim montototal As Decimal

        fechaini = txtFInicio.Text
        fechafin = txtFFin.Text
        tipodeuda = cmbTipoIngreso.SelectedValue
        SearchIngresos()


        For Each r As DataGridViewRow In dgIngresos.Rows
            If (r.Cells("EstadoRecibo").Value.ToString <> "ANULADO") Then
                montototal += CDec(r.Cells("fMontoTotal").Value)
            End If
        Next

        lblMontoTotal.Text = FormatCurrency(montototal, 2)
    End Sub
    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        frmOtrosIngresosNew.ShowDialog()


    End Sub
    Private Sub caragarGrid()
        Dim dt As DataTable
        Dim sqltext As String
        Try
            sqltext = " WHERE (dFecha>='" & txtFInicio.Text & "' and dfecha <= '" & txtFFin.Text & "')"
            dt = clsOtrosIngresos.ListPagos(sqltext)
            dgIngresos.DataSource = dt

        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtFInicio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFInicio.Click

    End Sub

    Private Sub txtFInicio_CursorChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFInicio.CursorChanged

    End Sub

    Private Sub txtFInicio_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFInicio.KeyUp
        SearchIngresos()
    End Sub

    Private Sub txtFInicio_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFInicio.ValueChanged

        'txtFInicio.Text = Format(Date.Now(), "dd/MM/yyyy")
        'txtFInicio.Value = txtFFin.Value
        'If (txtFFin.Value < txtFInicio.Value) Then
        '    txtFFin.Value = txtFInicio.Value
        'End If
        'txtFInicio.Text = ""

        Call SearchIngresos()
    End Sub

    Private Sub btnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDel.Click
        Dim nroRecibo As String
        'Dim idIngreso As Integer
        'Dim predio As Integer
        'Dim anio As String
        'Dim idmes As Integer

        Dim numerror As String
        numerror = ""
        If (Me.dgIngresos.SelectedRows.Count > 0) Then
            'Try
            'idfacturacion = dgIngresos.SelectedRows(0).Cells(16).Value

            'idIngreso = dgIngresos.SelectedRows(0).Cells(1).Value
            nroRecibo = dgIngresos.SelectedRows(0).Cells(1).Value

            Dim m = MessageBox.Show("Desea eliminar el registro seleccionado?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If (m = Windows.Forms.DialogResult.Yes) Then
                clsOtrosIngresos.elimina(nroRecibo)

            End If
            MsgBox("Registro Eliminado correctamente", MsgBoxStyle.Information)
            SearchIngresos()

        End If
    End Sub

    Private Sub ButtonItem13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem13.Click
        Dim EstadoRecibo As String

        ReciboD = dgIngresos.SelectedRows(0).Cells(1).Value
        EstadoRecibo = dgIngresos.SelectedRows(0).Cells(15).Value
        frmRecibos.Nrorecibo = ReciboD
        frmRecibos.TIPO = 2
        If EstadoRecibo <> "ANULADO" Then
            frmRecibos.Show()
        Else
            MsgBox("Recibo Eliminado", MsgBoxStyle.Information)
        End If

    End Sub

    Private Sub ButtonItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem1.Click
        frmReportes.optionRPT = 1
        frmReportes.dfini = txtFInicio.Text
        frmReportes.dffin = txtFFin.Text
        frmReportes.tipoingreso = cmbTipoIngreso.SelectedValue
        frmReportes.ShowDialog()
    End Sub
End Class