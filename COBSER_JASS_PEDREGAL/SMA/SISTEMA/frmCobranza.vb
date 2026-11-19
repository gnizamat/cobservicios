Imports ACCESO
Imports LOGICA
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Data.OleDb
Public Class frmCobranza
    Public fechaini As String
    Public fechafin As String
    Public ReciboD As String
    Dim _tarifa As New clsAnioTarifa
    Dim calle As Integer
    Dim vf As New clsValidateForm

    Private Sub frmCobranza_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

       

        'Dim debito As Decimal
        Try
            'clsCalles.LoadComboADD(cmbCalles)
            clsJunta.LoadCombo(cmbJunta)
            If (frmPrincipal.userSystem.idInterfaz = 4) Then
                cmbJunta.SelectedValue = frmPrincipal.userSystem.idJunta
                cmbJunta.Enabled = False


            End If
            clsJunta.LoadCombo(cmbJuntaC)
            cmbJuntaC.Enabled = False
            clsCentroPoblado.LoadComboADD(cmbCPoblado)
            cmbCPoblado.SelectedValue = 0

            clsCalles.LoadComboCallesPredio(cmbCalles)
            cmbCalles.SelectedValue = 1

            cmbCalles.SelectedValue = 0
            clsCaja.LoadCombo(cmbCaja)
            txtFInicio.Text = Format(Date.Now(), "dd/MM/yyyy")
            txtFFin.Text = Format(Date.Now(), "dd/MM/yyyy")
            txtAnioVigente.Text = _tarifa.getTarifaActual.anio
            CargaGrid()


        Catch ex As Exception

        End Try

    End Sub

    Private Sub CargaGrid()
        Dim dt As New DataTable
        dt = clsPredios.List(" ORDER BY vApePaterno, vApeMaterno, vUsuario")
        gridPredios.DataSource = dt
        If gridPredios.Rows.Count > 0 Then
            gridPredios.Columns(0).Width = 80
            gridPredios.Columns(1).Width = 80
            gridPredios.Columns(2).Width = 80
            gridPredios.Columns(3).Width = 100
            gridPredios.Columns(5).Width = 150
            gridPredios.Columns(2).Visible = False
            gridPredios.Columns(3).Visible = False
            gridPredios.Columns(4).Visible = False
        End If
        lblRegistros.Text = Val(dt.Rows.Count)
    End Sub

    Public Function Filtrar() As DataTable
        calle = cmbCalles.SelectedValue

        Dim dt As New DataTable
        'filtro de usuarios

        Dim condicion As String = ""

        If (cmbCalles.SelectedValue <> 0) Then
            condicion &= "and idCalle = " & calle & ""
        Else
            condicion &= "and idCalle like '%'"

        End If

        If (txtUAPaterno.Text <> "") Then
            condicion &= " and vApePaterno like '" & txtUAPaterno.Text & "%'"
        End If
        If (txtUAMaterno.Text <> "") Then
            condicion &= " and vApeMaterno like '" & txtUAMaterno.Text & "%'"
        End If
        If (txtUNombre.Text <> "") Then
            condicion &= " and vUsuario like '" & txtUNombre.Text & "%'"
        End If
        If (txtDNI.Text <> "") Then
            condicion &= " and vDNI like '%" & txtDNI.Text & "%'"
        End If
        If (txtUC.Text <> "") Then
            condicion &= " and vUC like '%" & txtUC.Text & "%'"
        End If
        'dt = (" and vIdJuntaUsuario='" & idj & "'" & condicion, "1")
        dt = clsPredios.List(condicion, "1")

        'fin filtro
        lblRegistros.Text = Val(dt.Rows.Count)
        Return dt
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
    End Function

    Private Sub txtDNI_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDNI.KeyUp
        If (vf.startValidation) Then
            gridPredios.DataSource = Filtrar()
        End If
    End Sub

    Private Sub txtUAPaterno_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUAPaterno.KeyUp
        If (vf.startValidation) Then
            gridPredios.DataSource = Filtrar()
        End If
    End Sub

    Private Sub txtUAMaterno_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUAMaterno.KeyUp
        If (vf.startValidation) Then
            gridPredios.DataSource = Filtrar()
        End If
    End Sub

    Private Sub txtUNombre_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUNombre.KeyUp
        If (vf.startValidation) Then
            gridPredios.DataSource = Filtrar()
        End If
    End Sub

    Private Sub txtUC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUC.KeyPress
        If (vf.startValidation) Then
            gridPredios.DataSource = Filtrar()
        End If
    End Sub

    Private Sub BtnLimpiaBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLimpiaBuscar.Click
        txtDNI.Text = ""
        txtUAPaterno.Text = ""
        txtUAMaterno.Text = ""
        txtUNombre.Text = ""
        txtUC.Text = ""
        CargaGrid()
        'Dim dt As New DataTable
        'Dim mtotal As String
        'For x = 1 To 24
        '    mtotal = ""
        '    dt = CalculaCouotas(240, x)
        '    For Each midata As DataRow In dt.Rows
        '        mtotal = mtotal & (midata(0)) & " , "
        '    Next
        '    MsgBox(mtotal)
        'Next
    End Sub

    'Private Function CalculaCouotas(ByVal monto As Double, ByVal nrocuotas As Integer) As DataTable
    '    Dim dt As New DataTable
    '    Dim credondeo As Double
    '    Dim mredondeo As Double

    '    credondeo = Math.Round((monto / nrocuotas), 1) ' 26.7
    '    mredondeo = Math.Round(monto - (credondeo * nrocuotas), 1) ' - 0.3

    '    dt.Columns.Add("Cuota")
    '    For i = 0 To nrocuotas - 1
    '        Dim row As DataRow = dt.NewRow()

    '        If i = nrocuotas - 1 Then
    '            row("Cuota") = credondeo + mredondeo ' 26.4=26.7+-0.3
    '        Else
    '            row("Cuota") = credondeo ' 26.7
    '        End If

    '        dt.Rows.Add(row)
    '    Next
    '    Return dt
    'End Function

    Private Sub cmbCalles_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCalles.SelectedIndexChanged
        Try
            If (vf.startValidation) Then
                gridPredios.DataSource = Filtrar()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnCobranzaNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCobranzaNew.Click
        frmCobranzaNew.IdPredio = gridPredios.Item(3, gridPredios.CurrentRow.Index).Value ' idpredio
        frmCobranzaNew.sDNI = gridPredios.Item(0, gridPredios.CurrentRow.Index).Value ' DNI
        frmCobranzaNew.sUsuario = gridPredios.Item(8, gridPredios.CurrentRow.Index).Value ' usuario
        frmCobranzaNew.sPredio = gridPredios.Item(10, gridPredios.CurrentRow.Index).Value ' Predio
        frmCobranzaNew.Snro = gridPredios.Item(11, gridPredios.CurrentRow.Index).Value ' Nro
        frmCobranzaNew.ShowDialog()
    End Sub
    Private Sub CARGAPAGOS()
        Dim dt As New DataTable
        dt = clsPago.ListPagos(fechaini, fechafin)
        dgCobranzas.DataSource = dt
        If dgCobranzas.Rows.Count > 0 Then
            'gridLecturas.Columns(0).Width = 50
            dgCobranzas.Columns(1).Width = 100
            dgCobranzas.Columns(2).Width = 70
            dgCobranzas.Columns(3).Width = 70
            dgCobranzas.Columns(4).Width = 60
            dgCobranzas.Columns(5).Width = 70
            dgCobranzas.Columns(6).Width = 70
            dgCobranzas.Columns(8).Width = 70
            dgCobranzas.Columns(9).Width = 70
            dgCobranzas.Columns(10).Width = 70
            dgCobranzas.Columns(11).Width = 70
            'dgCobranzas.Columns(0).Visible = False
            'dgCobranzas.Columns(3).Visible = False
            'dgCobranzas.Columns(4).Visible = False
            'dgCobranzas.Columns(5).Visible = False
            'dgCobranzas.Columns(7).Visible = False
            'dgCobranzas.Columns(12).Visible = False

        End If

    End Sub

    Private Sub btnLoadPagos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadPagos.Click
        LoadCobranzas()

        
    End Sub
    Sub LoadCobranzas()

        Dim monto As Decimal
        Dim interes As Decimal
        Dim redondeo As Decimal
        Dim montototal As Decimal

        fechaini = txtFInicio.Text
        fechafin = txtFFin.Text
        CARGAPAGOS()

        For Each r As DataGridViewRow In dgCobranzas.Rows
            If (r.Cells("EstadoRecibo").Value.ToString <> "ANULADO") Then
                monto += CDec(r.Cells("fMonto").Value)
                montototal += CDec(r.Cells("fMontoTotal").Value)
                interes += CDec(r.Cells("fInteres").Value)
                redondeo += CDec(r.Cells("fRedondeo").Value)

            End If
        Next

        lblMonto.Text = FormatCurrency(monto, 2)
        lblMontoTotal.Text = FormatCurrency(montototal, 2)
        lblRedondeo.Text = FormatCurrency(redondeo, 2)
        lblInteres.Text = FormatCurrency(interes, 2)
        lblTotalRecibido.Text = FormatCurrency(montototal + redondeo, 2)
        lblRegistrosCobranza.Text = String.Format("{0} registros encontrados", dgCobranzas.Rows.Count)
    End Sub
    Private Sub TabControl1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl1.Click

    End Sub

    Private Sub btnPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreview.Click
        Dim EstadoRecibo As String

        ReciboD = dgCobranzas.SelectedRows(0).Cells(6).Value
        EstadoRecibo = dgCobranzas.SelectedRows(0).Cells(13).Value
        frmRecibos.Nrorecibo = ReciboD
        frmRecibos.TIPO = 0
        frmRecibos.ranio = txtAnioVigente.Text
        If EstadoRecibo <> "ANULADO" Then
            frmRecibos.Show()
        Else
            MsgBox("Recibo Eliminado", MsgBoxStyle.Information)
        End If
        
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim pd As New PrintDialog()
        pd.ShowDialog()
    End Sub

    Private Sub btnAnulaPago_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnulaPago.Click
        Dim obj As New clsPago
        Dim nroRecibo As String
        Dim idpago As Integer
        Dim predio As Integer
        Dim dfechapago As String
        Dim facturaciones As String

        Dim numerror As String

        numerror = ""
        'obj.NroDocumento = dgCobranzas.SelectedRows(0).Cells(6).Value


        If (Me.dgCobranzas.SelectedRows.Count > 0) Then
            'Try
            nroRecibo = dgCobranzas.SelectedRows(0).Cells(6).Value
            idpago = dgCobranzas.SelectedRows(0).Cells(16).Value
            predio = dgCobranzas.SelectedRows(0).Cells(14).Value

            dfechapago = dgCobranzas.SelectedRows(0).Cells(7).Value
            facturaciones = dgCobranzas.SelectedRows(0).Cells(12).Value

           
            Dim m = MessageBox.Show("Desea eliminar el registro seleccionado?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If (m = Windows.Forms.DialogResult.Yes) Then
                clsPago.elimina(nroRecibo, predio, idpago, dfechapago, facturaciones)

            End If
            MsgBox("Pago Eliminado correctamente", MsgBoxStyle.Information)
            LoadCobranzas()
       
        End If
    End Sub
    Public Function FiltrarPagos() As String
        'Dim nroRecibo As String
        Dim dt As New DataTable
        Try
            Dim condicion As String = ""


            If (txtNroDocumento.Text <> "") Then
                condicion &= " AND Recibo = '" & txtNroDocumento.Text & "'"
            End If
            Return condicion
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function
    Private Sub TabControlPanel2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControlPanel2.Click

    End Sub

    Private Sub txtNroDocumento_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNroDocumento.TextChanged

    End Sub

    Private Sub cmbCPoblado_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCPoblado.SelectedIndexChanged
        Try

            clsCalles.LoadComboCallesPredio(cmbCalles, "where padPredio.idCP= " & cmbCPoblado.SelectedValue & " ")
            'clsSector.LoadComboAdd(cmbsector)
            'cmbsector.SelectedValue = 0
        Catch ex As Exception

        End Try
    End Sub

    Private Sub lblRegistrosCobranza_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblRegistrosCobranza.Click

    End Sub

    Private Sub txtFInicio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFInicio.Click

    End Sub

    Private Sub ButtonItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem6.Click

    End Sub

    Private Sub cmbTipoPago_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipoPago.SelectedIndexChanged

    End Sub
End Class