
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Data.OleDb
Imports ACCESO
Imports LOGICA
Imports COBSER.Menu


Public Class frmDeudaAnteriorNew

    'Public uSU As New clsUsuario
    Public estado1 As String

    Public idjas As Integer
    Public usuario As String
    Public predio As String
    Public nrocasa As String
    Public uc As String
    Public calle As String
    Public USERI As String
    Public predios As clsPredios
    Public idpredio As Integer
    Dim dtTarifas As New DataTable
    Dim idmes As Integer
    'Dim idtipoTarifa As Integer
    Dim tipoTarifa As Integer
    Dim tipodeuda As Integer
    Dim subtipotarifa As String
    Dim usrcor As Integer
    'Dim vf As New clsValidateForm
    Dim deudasRemove() As Integer
    Dim aniosRemove() As Integer
    Dim total_delete As Integer
    'Dim dtTarifas As New DataTable
    Dim dtdeudas As New DataTable
    Dim vf As New clsValidateForm

    Dim NewDeudas As New List(Of clsDetalleDeudaPredio)
    Dim DelDeudas As New List(Of clsDetalleDeudaPredio)
    Dim title_mes_large() As String = {"ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SETIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE"}
    Private Sub frmDeudaAnteriorNew_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        clsJunta.LoadCombo(cmbJunta)
        If (frmPrincipal.userSystem.idInterfaz = 4) Then
            cmbJunta.SelectedValue = frmPrincipal.userSystem.idJunta
            cmbJunta.Enabled = False
        End If


        clsAnioTarifa.LoadCombo(cmbAnio)
        cmbAnio.SelectedIndex = 0

        txtCalle.Text = calle
        txtUsuario.Text = usuario
        txtPredio.Text = predio
        txtNumeroCasa.Text = nrocasa
        txtUC.Text = uc
        'cmbJunta.SelectedValue = idjas
        idjas = cmbJunta.SelectedValue
        txtFecha.Text = ACCESO.Conexion.getDateServer

        Call limpiar()
        btnEliminar.Enabled = False
        btnEliminar.Visible = False
        btndelete.Enabled = False

        CARGAGRID_DEUDAS()

        CalcularTotales()
        'dgDeudas.Rows.Clear()
        'Dim dt As New DataTable

        'dt = clsDetalleDeudaPredio.List1(" WHERE  idPredio='" & idpredio & "' and idTipoDeuda=1")
        'dgDeudas.DataSource = dt
        
    End Sub

    Private Sub cmbSubTipoTarifa_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSubTipoTarifa.SelectedIndexChanged
        Try
            txtTipoTarifa.Text = cmbSubTipoTarifa.SelectedItem(4).ToString
            txtValorSubTarifa.Text = cmbSubTipoTarifa.SelectedItem(5).ToString
            txtMonto.Text = cmbSubTipoTarifa.SelectedItem(5).ToString

        Catch ex As Exception

        End Try
    End Sub
    Sub limpiar()
        txtPredio.ResetText()
        txtMonto.Text = 0
        txtInteres.Text = 0
        txtTotalSuma.Text = 0
        txtDescripcion.ResetText()
        txtUC.ResetText()
    End Sub

    Private Sub cmbAnio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAnio.SelectedIndexChanged
        Try
            clsMes.LoadCombo(cmbMes)
            cmbMes.SelectedValue = 1
            'clsAnioTarifa.LoadCombo(cmbAnio)
           
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Dim fNew As New Date
        Dim f As New Date
        Dim flagValido As Boolean = True
        Dim user As String = DevolverConCeros(2, frmPrincipal.userSystem.idComision) & "-" & frmPrincipal.userSystem.usuario
        Dim deuda As clsDetalleDeudaPredio

        fNew = txtFecha.Value


        For Each r As DataGridViewRow In dgDeudas.Rows
            f = r.Cells("FechaRegistro").Value

            If (cmbAnio.SelectedValue = r.Cells(0).Value And cmbMes.Text = r.Cells(1).Value And cmbSubTipoTarifa.Text = r.Cells(2).Value) Then
                flagValido = False
            End If
        Next
        If (flagValido) Then
            deuda = New clsDetalleDeudaPredio
            deuda.anio = cmbAnio.SelectedValue
            deuda.mes = cmbMes.Text

            subtipotarifa = cmbSubTipoTarifa.Text
            deuda.monto = txtMonto.Text
            deuda.interes = Val(txtInteres.Text)

            deuda.volumen = txtVolumen.Text
            deuda.fechadeuda = txtFecha.Text

            idmes = cmbMes.SelectedValue
            tipoTarifa = cmbSubTipoTarifa.SelectedValue
            tipodeuda = "1"
            estado1 = "True"
            NewDeudas.Add(deuda)
            dgDeudas.Rows.Add(deuda.anio, deuda.mes, subtipotarifa, deuda.monto, deuda.volumen, deuda.monto, txtInteres.Text, txtTotalSuma.Text, deuda.fechadeuda.ToString, tipoTarifa, idmes, tipodeuda, "", "", "", estado1)
            'txtMonto.Val = 0
            'txtInteres.Value = 0
            CalcularTotales()
            EstadoPendiente(True)
        Else
            MsgBox("Ya se ha registrado una deuda para esta Fecha. Asegurese de que la deuda ingresada no pertenesca la mismo año y al mismo mes", MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub cmbMes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMes.SelectedIndexChanged
        Try

            clsTipoTarifa.LoadCombo(cmbSubTipoTarifa, "Where iAnioTarifa='" & cmbAnio.Text & "' ")
            cmbSubTipoTarifa.SelectedIndex = 0
        Catch ex As Exception

        End Try
    End Sub
    Sub CalcularTotales()
        Dim total As Decimal
        'Dim iTotal As Decimal
        Dim mTotal As Decimal
        Dim stotal As Decimal

        For Each r As DataGridViewRow In dgDeudas.Rows
            mTotal += r.Cells(5).Value
            'iTotal += r.Cells(4).Value
            total += (Val(r.Cells(6).Value))
            stotal += (Val(r.Cells(5).Value)) + (Val(r.Cells(6).Value))
        Next
        txtTotal.ControlText = FormatCurrency(total, 2)
        'txtITotal.ControlText = FormatCurrency(iTotal, 2)
        txtMTotal.ControlText = FormatCurrency(mTotal, 2)
        TxtSumaTotal.ControlText = FormatCurrency(stotal, 2)

    End Sub
    Public Sub EstadoPendiente(ByVal estado As Boolean)
        If (estado) Then
            lblEstado.Visible = True
            lblEstado.Text = "Existen cambios pendientes por guardar. si cancela no se guardara ningun cambio"

        Else
            lblEstado.Visible = False
        End If
        Bar1.Refresh()
    End Sub

    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        If (ValidaGridItemSeleccionado(dgDeudas)) Then
            Dim deuda As New clsDetalleDeudaPredio
            'euda.idJunta = clsPredios.
            'deuda.idComision = predio.idComision
            deuda.anio = dgDeudas.Item(0, dgDeudas.CurrentRow.Index).Value
            'deuda.idPredio = 
            deuda.idJunta = idjas
            deuda.id = Val(dgDeudas.Item(7, dgDeudas.CurrentRow.Index).Value)
            DelDeudas.Add(deuda)
            EstadoPendiente(True)
            
            'If dgDeudas.Rows(0).Cells(13).Value = True Then
                If estado1 = True Then
                    dgDeudas.Rows.Remove(dgDeudas.CurrentRow)
                Else
                    MsgBox("No pude quietar deudar Registradas...Utilece la Opcion Eliminar", MsgBoxStyle.Information)
                End If

            End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Dim deuda_predio As New clsDetalleDeudaPredio
        'Dim deudaAnterior As New clsDeudaAnterior
        Dim deudaresumen_predio As New clsDeudaPredio

        Dim u As Integer = 0
        Dim d As Integer = 0


        Dim ddp As New clsDetalleDeudaPredio
        Dim c As New ACCESO.Conexion
        Dim user As String = DevolverConCeros(2, frmPrincipal.userSystem.idComision) & "-" & frmPrincipal.userSystem.usuario
        Try

            If (c.Connect) Then
                idjas = cmbJunta.SelectedValue
                'idpredio = predios.id


                For i = 0 To dgDeudas.Rows.Count - 1
                    deuda_predio.idTipoDeuda = 0
                    'If estado = True Then
                    'If dgDeudas.Rows(u).Cells(d).Style.BackColor <> Color.LightGoldenrodYellow Then

                    'deuda_predio = New clsDetalleDeudaPredio(idjas, dgDeudas.Rows(i).Cells(8).Value, idpredio, dgDeudas.Rows(i).Cells(0).Value, dgDeudas.Rows(i).Cells(6).Value, dgDeudas.Rows(i).Cells(3).Value, 1, dgDeudas.Rows(i).Cells(7).Value, dgDeudas.Rows(i).Cells(2).Value)
                    deuda_predio = New clsDetalleDeudaPredio(idjas, dgDeudas.Rows(i).Cells(10).Value, idpredio, dgDeudas.Rows(i).Cells(0).Value, dgDeudas.Rows(i).Cells(8).Value, dgDeudas.Rows(i).Cells(3).Value, dgDeudas.Rows(i).Cells(6).Value, 1, dgDeudas.Rows(i).Cells(9).Value, dgDeudas.Rows(i).Cells(2).Value)
                    If dgDeudas.Rows(i).Cells(15).Value = True Then

                        deuda_predio.Insert()
                    Else

                    End If

                    'Dim b As New clsDeudaAnterior(idjas, dgDeudas.Rows(i).Cells(8).Value, idpredio, dgDeudas.Rows(i).Cells(0).Value, dgDeudas.Rows(i).Cells(6).Value, 1, 0)
                    'b.Insert()
                    'Else
                    'MsgBox("Deuda Registrada correctamente", MsgBoxStyle.Information)
                    'End If


                Next
                CARGAGRID_DEUDAS()

                'If (showMessages("save2")) Then
                'End If
                MsgBox("Deuda Registrada correctamente", MsgBoxStyle.Information)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Bar3_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bar3.ItemClick

    End Sub
    Private Sub CARGAGRID_DEUDAS()
        Dim i As Integer
        Dim j As Integer
        'vacio el listado de deudas reguistradas
        dgDeudas.Rows.Clear()
        'lleno el listado con las deudas registradas
        dtdeudas = clsDetalleDeudaPredio.List1(idpredio)
        ''(" WHERE  idPredio='" & idpredio & "' and idTipoDeuda=1")
        i = 0
        For Each midata As DataRow In dtdeudas.Rows


            dgDeudas.Rows.Add(midata("iAnioTarifa"), midata(1), midata(2), midata("fMonto"), midata("fVolumen"), midata("fSaldo"), midata("fInteres"), midata("MontoTotal"), midata(8), midata(9), midata(10), midata(11), midata(12), midata(13), midata(14), False)
            For j = 0 To dgDeudas.Columns.Count - 1
                'estado = True

                dgDeudas.Rows(i).Cells(j).Style.BackColor = Color.LightGoldenrodYellow
            Next
            i += 1
        Next
        If dtdeudas.Rows.Count > 0 Then
            btnEliminar.Enabled = True
            btndelete.Enabled = True

        End If

        'campos obligatorios
        vf.addCombobox(cmbAnio, "string", False)
        'vf.addDoubleTextbox(txtITotal, "numeric", False)
        vf.addCombobox(cmbMes, "string", False)
        ReDim deudasRemove(i)
        ReDim aniosRemove(i)
        total_delete = 0
        EstadoPendiente(False)
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub txtInteres_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Dim flag As Boolean = True
        Dim idpredio As Integer
        'Dim idjas As String
        Dim iddetalledeuda As Integer
        'Dim anio As Integer
        Dim idmes As Integer
        Try

            If (ValidaGridItemSeleccionado(dgDeudas)) Then
                Dim deuda As New clsDetalleDeudaPredio
                'euda.idJunta = clsPredios.
                'deuda.idComision = predio.idComision
                Dim m = MessageBox.Show("Desea eliminar el registro seleccionado?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If (m = Windows.Forms.DialogResult.Yes) Then
                    deuda.anio = dgDeudas.Item(0, dgDeudas.CurrentRow.Index).Value
                    'deuda.idPredio = 
                    deuda.idJunta = idjas
                    deuda.id = Val(dgDeudas.Item(7, dgDeudas.CurrentRow.Index).Value)
                    DelDeudas.Add(deuda)
                    EstadoPendiente(True)
                    'dgDeudas.Rows.Remove(dgDeudas.CurrentRow)
                    iddetalledeuda = dgDeudas.Item(11, dgDeudas.CurrentRow.Index).Value
                    idpredio = dgDeudas.Item(10, dgDeudas.CurrentRow.Index).Value
                    idmes = dgDeudas.Item(8, dgDeudas.CurrentRow.Index).Value

                    'If (flag) Then

                    clsDetalleDeudaPredio.delete(idpredio, iddetalledeuda, deuda.anio, idjas, idmes)
                    MsgBox("Deuda Elimidada correctamente", MsgBoxStyle.Information)
                    'dgDeudas.DataSource = Filtrar()
                    CARGAGRID_DEUDAS()
                End If
                'End If

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btndelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndelete.Click
        Dim flag As Boolean = True
        Dim idpredio As Integer
        'Dim idjas As String
        Dim iddetalledeuda As Integer
        'Dim anio As Integer
        Dim idmes As Integer
        Try

            If (ValidaGridItemSeleccionado(dgDeudas)) Then
                Dim deuda As New clsDetalleDeudaPredio
                'euda.idJunta = clsPredios.
                'deuda.idComision = predio.idComision
                Dim m = MessageBox.Show("Desea eliminar el registro seleccionado?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If (m = Windows.Forms.DialogResult.Yes) Then
                    deuda.anio = dgDeudas.Item(0, dgDeudas.CurrentRow.Index).Value
                    'deuda.idPredio = 
                    deuda.idJunta = idjas
                    deuda.id = Val(dgDeudas.Item(7, dgDeudas.CurrentRow.Index).Value)
                    DelDeudas.Add(deuda)
                    EstadoPendiente(True)
                    'dgDeudas.Rows.Remove(dgDeudas.CurrentRow)
                    iddetalledeuda = dgDeudas.Item(13, dgDeudas.CurrentRow.Index).Value
                    idpredio = dgDeudas.Item(12, dgDeudas.CurrentRow.Index).Value
                    idmes = dgDeudas.Item(10, dgDeudas.CurrentRow.Index).Value

                    'If (flag) Then

                    clsDetalleDeudaPredio.delete(idpredio, iddetalledeuda, deuda.anio, idjas, idmes)
                    MsgBox("Deuda Elimidada correctamente", MsgBoxStyle.Information)
                    'dgDeudas.DataSource = Filtrar()
                    CARGAGRID_DEUDAS()
                End If
                'End If

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgDeudas_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDeudas.CellContentClick
        estado1 = dgDeudas.Item(15, dgDeudas.CurrentRow.Index).Value

    End Sub

    Private Sub txtFecha_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFecha.Click

    End Sub

    Private Sub txtMonto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMonto.TextChanged
        txtTotalSuma.Text = Val(txtMonto.Text)
    End Sub

    Private Sub txtInteres_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtInteres.TextChanged
        txtTotalSuma.Text = Val(txtMonto.Text) + Val(txtInteres.Text)
    End Sub
End Class