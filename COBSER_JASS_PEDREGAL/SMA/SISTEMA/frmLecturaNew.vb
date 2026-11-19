Imports ACCESO
Imports LOGICA
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Data.OleDb

Public Class frmLecturaNew
    Public usuario As String
    Public dni As String
    Public nrocasa As String

    Public idPredio As Integer
    Public idmed As Integer
    Public idJas As String
    Public codigo As String
    Public anio As String
    'Public winOrigen As Integer = 0
    Public tipotarifa As Integer
    Public PREDIO As String
    Public FECHA As Date
    'Public codigo As String
    Public voltotalu As Double
    Public volactual As Double
    Public volaTotalctual As Double
    Public volConsumolt As Double
    Public anioactual As String
    Public codigoM As String



    Private Sub TextBoxX1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLt.TextChanged

    End Sub

    Private Sub frmLecturaNew_InputLanguageChanging(ByVal sender As Object, ByVal e As System.Windows.Forms.InputLanguageChangingEventArgs) Handles Me.InputLanguageChanging


    End Sub

    Private Sub frmLecturaNew_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim lectura As New clsLecturas
      
        clsJunta.LoadCombo(cmbJunta)

        If (frmPrincipal.userSystem.idInterfaz = 4) Then
            cmbJunta.SelectedValue = frmPrincipal.userSystem.idJunta
            cmbJunta.Enabled = False
        End If
        'clsMedidor.LoadCombo(cmbTipoMedidor)
        'cmbTipoMedidor.SelectedIndex = 0
       
        idmed = cmbMedidor.SelectedValue
        clsAnioTarifa.LoadComboAnioVigente(cmbAnio)

        clsMedidor.LoadComboActMedidor(cmbMedidor, idPredio)
        cmbMedidor.SelectedIndex = 0

        clsMes.LoadCombo(cmbMes)
        cmbMes.SelectedValue = 1
        clsColaboradores.LoadCombo(cmbColaborador)
        txtNombre.Text = usuario
        txtLote.Text = PREDIO
        txtNro.Text = nrocasa
        txtDNI.Text = dni
        txtCodigo.Text = codigo
        txtCodigoM.Text = codigoM
        txtFecha.Text = ACCESO.Conexion.getDateServer
        anioactual = cmbAnio.SelectedValue
        txtFActual.Text = ACCESO.Conexion.getDateServer
        txtFUltima.Text = ""
        txtM3Actual.Text = ""
        txtLtActual.Text = ""
        txtTotalLA.Text = ""
        btnGrabar.Enabled = False
        btnEliminar.Enabled = True
        cmbColaborador.SelectedIndex = 0


        Call CargarUltimaLectura()

        CARGAGRIDLECTURAS()
       


        'txtM3Ult.Text = lectura.ultimaLecturam3
        'txtLtUlt.Text = lectura.ultimaLecturalt
    End Sub
    
    Private Sub txtLtActual_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLtActual.KeyPress
        'volactual = Val(txtM3Actual.Text) * 1000
        'volaTotalctual = volactual + Val(txtLtActual.Text)
        'txtTotalLA.Text = volaTotalctual
        'volConsumolt = volaTotalctual - Val(txtTotalUlt.Text)
        'txtLt.Text = volConsumolt
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            cmbColaborador.Focus()
        End If
    End Sub

    Private Sub txtLtActual_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLtActual.TextChanged
        'volactual = Val(txtM3Actual.Text) * 1000

        volaTotalctual = volactual + Val(txtLtActual.Text)
        txtTotalLA.Text = volaTotalctual
        If txtTotalUlt.Text >= 0 Then
            volConsumolt = volaTotalctual - Val(txtTotalUlt.Text)
            txtLt.Text = volConsumolt
            txtM3.Text = volConsumolt / 1000

        Else

            txtLt.Text = 0
            txtM3.Text = 0

        End If
      
    End Sub

    Function CargarUltimaLectura()

        Try
            Dim voltotalu As Double
            Dim fechaultima As Date
            Dim m3ultima As Double
            Dim ltultima As Double
            Dim c As New ACCESO.Conexion
            Dim dt As New DataTable
            Dim lecturas As New clsLecturas
            If (c.Connect) Then
                dt = c.Query("SELECT  vIdJas, idpredio, iIdTipoTarifa, idLectura, iAnioTarifa, idMes, dFechaLectura, fLecturaM3, fLecturaLt, fVolumenTotal, fVolumenConsumo, fVolumenM3,idMedidor FROM tarPrediosLecturas T1 WHERE dFechaLectura = (SELECT max(dFechaLectura)FROM tarPrediosLecturas T2 WHERE T1.idpredio=T2.idpredio)and vIdJas= " & cmbJunta.SelectedValue & " and iAnioTarifa<=" & cmbAnio.SelectedValue & " and idpredio= " & idPredio & "  and idMedidor= " & cmbMedidor.SelectedValue & "")
                If (dt.Rows.Count > 0) Then
                    fechaultima = dt.Rows(0).Item(6)
                    m3ultima = dt.Rows(0).Item(7)
                    ltultima = dt.Rows(0).Item(8)
                    voltotalu = dt.Rows(0).Item(9)
                    txtFUltima.Text = fechaultima
                    txtM3Ult.Text = m3ultima
                    txtLtUlt.Text = ltultima
                    txtTotalUlt.Text = voltotalu
                    'txtFActual.Focus()
                    cmbMes.SelectedValue = Month(txtFUltima.Text) + 1
                    txtFActual.Focus()

                Else

                    txtFUltima.Text = ""
                    txtM3Ult.Text = 0
                    txtLtUlt.Text = 0
                    txtTotalUlt.Text = 0
                    txtM3.Text = 0

                    txtLt.Text = 0
                    txtFActual.Focus()

                End If

            End If
            c.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function
    Function costotarifa()
        Dim c As New ACCESO.Conexion
        Dim dt As New DataTable
        Dim costot As Double
        If (c.Connect) Then
            dt = c.Query("SELECT tarTarifaAnual.iAnioTarifa, tarTipoTarifa.vNombre, tarCostoTarifa.iIdTipoTarifa, tarCostoTarifa.fMonto FROM tarTarifaAnual INNER JOIN tarCostoTarifa ON tarTarifaAnual.iAnioTarifa = tarCostoTarifa.iAnioTarifa INNER JOIN tarTipoTarifa ON tarCostoTarifa.vIdJas = tarTipoTarifa.vIdJas AND tarCostoTarifa.iIdTipoTarifa = tarTipoTarifa.iIdTipoTarifa WHERE tarTarifaAnual.cEstadoTarifa = '1' AND tarCostoTarifa.iIdTipoTarifa = 16 AND tarTarifaAnual.iAnioTarifa= '" & cmbAnio.Text & "'")
            If (dt.Rows.Count > 0) Then
                costot = dt.Rows(0).Item(3)
                txtCosto.Text = Val(costot)
            End If

        End If
    End Function

    Private Sub txtM3Actual_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtM3Actual.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            txtLtActual.Focus()
        End If
    End Sub

    Private Sub txtM3Actual_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtM3Actual.KeyUp

    End Sub

    Private Sub txtM3Actual_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtM3Actual.TextChanged

        volactual = Val(txtM3Actual.Text) * 1000
        'volaTotalctual = volactual + Val(txtLtActual.Text)
        txtTotalLA.Text = volactual
        'volConsumolt = volaTotalctual - Val(txtTotalUlt.Text)
        'txtLt.Text = volConsumolt
    End Sub

    Private Sub ButtonItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        Dim f As New Date
        Dim flagValido As Boolean = True
        Dim userSystem As New ACCESO.User
        'idmedidor = cmbTipoMedidor.SelectedValue
        codigo = txtCodigo.Text
        FECHA = txtFecha.Text
        Dim dt As New DataTable
        Dim l As New clsLecturas()
        userSystem = frmPrincipal.userSystem
        l.UsuarioSys = UCase(userSystem.usuario)
        l.anio = cmbAnio.SelectedValue
        l.Mes = cmbMes.SelectedValue
        l.IdPredio = idPredio
        l.FechaActual = txtFActual.Text
        l.ultimaLecturam3 = txtM3Actual.Text
        l.ultimaLecturalt = txtLtActual.Text
        l.fVolumenTotal = txtTotalLA.Text
        l.volumenconsumoM3 = txtM3.Text
        l.volumenconsumo = txtLt.Text
        l.Referencia = cmbColaborador.Text
        l.idMedidor = cmbMedidor.SelectedValue
        
        For Each r As DataGridViewRow In gridLecturas.Rows
            f = r.Cells("dFechaLectura").Value

            If (cmbAnio.SelectedValue = r.Cells(6).Value And cmbMes.Text = r.Cells(8).Value) Then
                flagValido = False
            End If
        Next

        If (flagValido) Then

            l.Insert(cmbJunta.SelectedValue, idPredio, tipotarifa, cmbAnio.Text, cmbMes.SelectedValue, codigo, FECHA, l.UsuarioSys, l.idMedidor)

            CARGAGRIDLECTURAS()
            btnNuevo.Enabled = True
            btnEliminar.Enabled = True
        Else
            MsgBox("Ya se ha registrado Lectura para este Año y Mes", MsgBoxStyle.Exclamation)
        End If

    End Sub
    Private Sub CARGAGRIDLECTURAS()
        Dim dt As New DataTable
        dt = clsLecturas.List(cmbAnio.SelectedValue, idPredio, cmbMedidor.SelectedValue)
        gridLecturas.DataSource = dt
        If gridLecturas.Rows.Count > 0 Then
            'gridLecturas.Columns(0).Width = 50
            gridLecturas.Columns(1).Width = 100
            gridLecturas.Columns(2).Width = 70
            gridLecturas.Columns(3).Width = 70
            gridLecturas.Columns(4).Width = 60
            gridLecturas.Columns(5).Width = 70
            gridLecturas.Columns(6).Width = 70
            gridLecturas.Columns(8).Width = 70
            gridLecturas.Columns(9).Width = 70
            gridLecturas.Columns(10).Width = 70
            gridLecturas.Columns(11).Width = 70
            gridLecturas.Columns(14).Width = 120
            gridLecturas.Columns(0).Visible = False
            gridLecturas.Columns(3).Visible = False
            gridLecturas.Columns(4).Visible = False
            gridLecturas.Columns(5).Visible = False
            gridLecturas.Columns(7).Visible = False
            gridLecturas.Columns(12).Visible = False
            gridLecturas.Columns(15).Visible = False
            gridLecturas.Columns(16).Visible = False
        End If

    End Sub

    Private Sub ButtonItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Call CargarUltimaLectura()
        txtFActual.Text = ""
        txtM3Actual.Text = ""
        txtLtActual.Text = ""
        txtTotalLA.Text = ""
        txtM3.Text = ""
        txtLt.Text = ""
        cmbColaborador.Text = ""
        txtFActual.Focus()
        btnGrabar.Enabled = True
        btnEliminar.Enabled = False

    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Dim flag As Boolean = True
        Dim idpredio As Integer
        'Dim anio As Integer
        Dim idmes As Integer
        Try
            If (ValidaGridItemSeleccionado(gridLecturas)) Then
                Dim lectura As New clsLecturas
                Dim m = MessageBox.Show("Desea eliminar el registro seleccionado?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If (m = Windows.Forms.DialogResult.Yes) Then
                    lectura.anio = gridLecturas.Item(6, gridLecturas.CurrentRow.Index).Value
                    idpredio = gridLecturas.Item(0, gridLecturas.CurrentRow.Index).Value
                    idmes = gridLecturas.Item(7, gridLecturas.CurrentRow.Index).Value
                    clsLecturas.delete(idpredio, lectura.anio, idmes)
                    MsgBox("Lectura Elimidada correctamente", MsgBoxStyle.Information)
                    CARGAGRIDLECTURAS()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()

    End Sub

    Private Sub txtFActual_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFActual.Click

    End Sub

    Private Sub txtFActual_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFActual.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            txtM3Actual.Focus()
        End If
    End Sub

    Private Sub cmbMes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMes.SelectedIndexChanged
       
        'If (flagValido) Then

        'Else
        '    MsgBox("Ya se ha registrado una deuda para esta Fecha. Asegurese de que la deuda ingresada no pertenesca la mismo año y al mismo mes", MsgBoxStyle.Exclamation)
        'End If
    End Sub

    Private Sub cmbAnio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAnio.SelectedIndexChanged
        Call costotarifa()
    End Sub

    Private Sub txtM3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtM3.TextChanged
        txtMonto.Text = FormatCurrency(Val(txtM3.Text) * Val(txtCosto.Text), 2)
    End Sub

    Private Sub gridLecturas_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridLecturas.CellContentClick

    End Sub

    Private Sub gridLecturas_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridLecturas.Click
        Dim dt As New DataTable
        Try
            Dim codigo As String = Me.gridLecturas.Item(1, Me.gridLecturas.CurrentRow.Index).Value
            Dim anio As String = Me.gridLecturas.Item(6, Me.gridLecturas.CurrentRow.Index).Value
            Dim mes As String = Me.gridLecturas.Item(8, Me.gridLecturas.CurrentRow.Index).Value
            Dim dfechal As String = Me.gridLecturas.Item(9, Me.gridLecturas.CurrentRow.Index).Value
            Dim lm3u As String = Me.gridLecturas.Item(10, Me.gridLecturas.CurrentRow.Index).Value
            Dim lltu As String = Me.gridLecturas.Item(11, Me.gridLecturas.CurrentRow.Index).Value
            Dim voltotal As String = Me.gridLecturas.Item(12, Me.gridLecturas.CurrentRow.Index).Value
            Dim LT As String = Me.gridLecturas.Item(13, Me.gridLecturas.CurrentRow.Index).Value
            Dim colab As String = Me.gridLecturas.Item(14, Me.gridLecturas.CurrentRow.Index).Value
            Dim M3 As String = Me.gridLecturas.Item(15, Me.gridLecturas.CurrentRow.Index).Value
            Dim defchar As String = Me.gridLecturas.Item(16, Me.gridLecturas.CurrentRow.Index).Value

            txtCodigo.Text = codigo
            cmbAnio.Text = anio
            cmbMes.Text = mes
            txtFUltima.Text = dfechal
            txtM3Ult.Text = lm3u
            txtLtUlt.Text = lltu
            txtTotalUlt.Text = voltotal
            txtLt.Text = LT
            txtM3.Text = M3
            cmbColaborador.Text = colab
            txtFecha.Text = defchar
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ButtonItem1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem1.Click
        frmRptConsumoPredios.idmesant = gridLecturas.SelectedRows(0).Cells(7).Value - 1
        frmRptConsumoPredios.idmesact = gridLecturas.SelectedRows(0).Cells(7).Value
        frmRptConsumoPredios.idanio = gridLecturas.SelectedRows(0).Cells(6).Value
        frmRptConsumoPredios.idcalle = gridLecturas.SelectedRows(0).Cells(17).Value
        frmRptConsumoPredios.idpredio = gridLecturas.SelectedRows(0).Cells(0).Value
        frmRptConsumoPredios.mesc = gridLecturas.SelectedRows(0).Cells(8).Value
        frmRptConsumoPredios.montop = txtMonto.Text
        frmRptConsumoPredios.costom = txtCosto.Text

        frmRptConsumoPredios.Show()


    End Sub

    Private Sub txtMonto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMonto.TextChanged

    End Sub

    Private Sub txtCosto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCosto.TextChanged

    End Sub

    Private Sub GroupPanel1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupPanel1.Click

    End Sub

    Private Sub cmbMedidor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMedidor.SelectedIndexChanged

    End Sub

    Private Sub txtM3Ult_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtM3Ult.TextChanged

    End Sub
End Class