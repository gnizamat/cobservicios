Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Data.OleDb
Imports ACCESO
Imports LOGICA
Imports COBSER.Menu
Public Class frmGenerarDeudasUnicas


    Public TipoTarifa As Integer
    Public idcalle As Integer
    Public idanio As String
    Public idmes As Integer

    Dim nroRegistros As Integer
    Dim calle As Integer
    Dim vf As New clsValidateForm
    Dim costoservicio As Double
    Dim nrocuotas As Integer
    Dim costocuota As Double



    Private Sub cmbSubTipoTarifa_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbServicios.SelectedIndexChanged
        Try
            txtValorSubTarifa.Text = cmbServicios.SelectedItem(5).ToString
            'txtMonto.Text = cmbSubTipoTarifa.SelectedItem(5).ToString
            TipoTarifa = cmbServicios.SelectedValue

            If TipoTarifa = 18 Then
                LabelX5.Visible = False
                LabelX14.Visible = False
                LabelX3.Visible = False
                LabelX6.Visible = False
                txtFecha.Visible = False
                txtMes.Visible = False
                cmbCuotas.Visible = False
                txtCuotas.Visible = False
                txtMontoCouta.Visible = False

                gridPredios.Columns.Clear()
                CargaGridMultas()
                txtMontoCouta.Text = txtValorSubTarifa.Text

            Else
                'gridPredios.DataSource = Filtrar()
                gridPredios.Columns.Clear()
                CargaGrid()
                txtMontoCouta.Text = txtValorSubTarifa.Text


            End If
            'gridPredios.DataSource = Filtrar()
            'gridPredios.Columns.Clear()
            'CargaGrid()
            'txtMontoCouta.Text = txtValorSubTarifa.Text

        Catch ex As Exception
        End Try
    End Sub

    Private Sub frmGenerarDeudasUnicas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        clsJunta.LoadCombo(cmbJunta)
        If (frmPrincipal.userSystem.idInterfaz = 4) Then
            cmbJunta.SelectedValue = frmPrincipal.userSystem.idJunta
            cmbJunta.Enabled = False
        End If
        clsAnioTarifa.LoadCombo(cmbAnio)
        cmbAnio.SelectedIndex = 0
        'clsTipoTarifa.LoadComboUnicas(cmbServicios)
        clsTipoTarifa.LoadComboUnicas(cmbServicios, " AND iAnioTarifa='" & cmbAnio.Text & "' ")
        txtFecha.Text = ACCESO.Conexion.getDateServer
        cmbCuotas.SelectedIndex = 0
        clsCentroPoblado.LoadComboADD(cmbCPoblado)
        cmbCPoblado.SelectedValue = 0

        clsCalles.LoadComboADD(cmbCalles)
        cmbCalles.SelectedValue = 1

        txtMontoCouta.Text = ""

    End Sub
    Private Sub CargaGrid()
        Dim dt As New DataTable

        dt = clsDeudasUnicas.ListaServciosUnicos(idcalle, TipoTarifa)
        gridPredios.DataSource = dt
        If gridPredios.Rows.Count > 0 Then
            Dim dcol As New DataGridViewCheckBoxColumn()
            gridPredios.Columns.Insert(0, dcol)
            gridPredios.Columns(0).Width = 30
            gridPredios.Columns(1).Width = 80
            gridPredios.Columns(2).Width = 50
            gridPredios.Columns(3).Width = 170
            gridPredios.Columns(4).Width = 80
            gridPredios.Columns(5).Width = 80
            gridPredios.Columns(6).Width = 60
            gridPredios.Columns(7).Width = 50
            gridPredios.Columns(8).Width = 50
            gridPredios.Columns(9).Width = 50
            gridPredios.Columns(10).Width = 60
            gridPredios.Columns(11).Width = 50
            gridPredios.Columns(12).Width = 50
            gridPredios.Columns(7).Visible = False
        End If
        txtNroPredios.Text = Val(dt.Rows.Count)
    End Sub
    Private Sub CargaGridMultas()
        Dim dt As New DataTable

        dt = clsDeudasUnicas.ListaGenerarMultas(idcalle, TipoTarifa)
        gridPredios.DataSource = dt
        If gridPredios.Rows.Count > 0 Then
            Dim dcol As New DataGridViewCheckBoxColumn()
            gridPredios.Columns.Insert(0, dcol)
            gridPredios.Columns(0).Width = 30
            gridPredios.Columns(1).Width = 80
            gridPredios.Columns(2).Width = 50
            gridPredios.Columns(3).Width = 170
            gridPredios.Columns(4).Width = 80
            gridPredios.Columns(5).Width = 80
            gridPredios.Columns(6).Width = 60
            gridPredios.Columns(7).Width = 50
            gridPredios.Columns(8).Width = 50
            gridPredios.Columns(9).Width = 50
            'gridPredios.Columns(10).Width = 60
            'gridPredios.Columns(11).Width = 50
            'gridPredios.Columns(12).Width = 50
            'gridPredios.Columns(7).Visible = False
        End If
        txtNroPredios.Text = Val(dt.Rows.Count)
    End Sub

    Private Sub cmbCalles_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCalles.SelectedIndexChanged
        Try
            Dim dt As New DataTable

            idcalle = cmbCalles.SelectedValue
            If idcalle = 0 Then
                idcalle = "%"
            Else
                idcalle = cmbCalles.SelectedValue
            End If
            gridPredios.Columns.Clear()
            'CargaGrid()
            CargaGridMultas()


        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbAnio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAnio.SelectedIndexChanged
        idanio = cmbAnio.Text
        clsTipoTarifa.LoadComboUnicas(cmbServicios, " AND iAnioTarifa='" & idanio & "' ")

    End Sub
    Dim evtPress As Boolean = True

    Private Sub chkSelectAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSelectAll.CheckedChanged
        If (evtPress) Then
            If (chkSelectAll.Checked) Then
                For Each r As DataGridViewRow In gridPredios.Rows
                    r.Cells(0).Value = True
                Next
                nroRegistros = gridPredios.Rows.Count

            Else
                nroRegistros = 0
                For Each r As DataGridViewRow In gridPredios.Rows
                    r.Cells(0).Value = False
                Next
            End If
            'lblnro.Text = nroRegistros & " Registros Seleccionado de " & gridPredios.Rows.Count
        End If
    End Sub

    Public Function Filtrar() As DataTable

        calle = cmbCalles.SelectedValue
        idanio = cmbAnio.Text
        Dim dt As New DataTable
        'filtro de usuarios
        Dim condicion As String = ""


        If (cmbCalles.SelectedValue <> 0) Then
            condicion &= "WHERE idCalle = " & calle & ""
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
            condicion &= " and vNroPredio like '%" & txtUC.Text & "%'"
        End If
        'If (cmbAnio.Text <> "") Then
        '    condicion &= " and Anio like '%" & idanio & "%'"
        'End If
        'dt = (" and vIdJuntaUsuario='" & idj & "'" & condicion, "1")

        dt = clsDeudasUnicas.ListaServciosUnicos(condicion, "1")
        'fin filtro
        txtNroPredios.Text = Val(dt.Rows.Count)
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

    Private Sub txtDNI_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDNI.TextChanged

    End Sub

    Private Sub txtUAPaterno_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUAPaterno.KeyUp
        If (vf.startValidation) Then
            gridPredios.DataSource = Filtrar()
        End If
    End Sub

    Private Sub txtUAPaterno_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUAPaterno.TextChanged

    End Sub

    Private Sub txtUAMaterno_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUAMaterno.KeyUp
        If (vf.startValidation) Then
            gridPredios.DataSource = Filtrar()
        End If
    End Sub

    Private Sub txtUAMaterno_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUAMaterno.TextChanged

    End Sub

    Private Sub txtUNombre_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUNombre.KeyUp
        If (vf.startValidation) Then
            gridPredios.DataSource = Filtrar()
        End If
    End Sub

    Private Sub txtUNombre_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUNombre.TextChanged

    End Sub

    Private Sub gridPredios_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridPredios.CellContentClick

    End Sub

    Private Sub LabelX16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LabelX16.Click

    End Sub

    Private Sub cmbCuotas_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCuotas.SelectedIndexChanged
        'Dim mesanio As Integer
        'Dim meses_anio As Integer


        'cmbCuotas.SelectedIndex = nrocuotas


        costoservicio = Val(txtValorSubTarifa.Text)
        nrocuotas = cmbCuotas.SelectedIndex + 1

        costocuota = costoservicio / nrocuotas
        'txtMontoCouta.Text = FormatCurrency(costocuota, 2)
        'txtMontoCouta.Text = Format(costocuota, "###,###.##")

        txtMontoCouta.Text = Format(costocuota, "0.00")


    End Sub

    Private Sub btnFiltrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFiltrar.Click
        'Try
        '    Dim obj As New clsDeudasUnicas
        '    Dim dt As New DataTable
        '    If (vf.startValidation) Then
        '        'gridPredios.DataSource = Filtrar()
        '        'dt = obj.ListaPrediosServicio(cmbCalles.SelectedValue, cmbServicio.SelectedValue)
        '        'gridPredios.DataSource = dt
        '        gridPredios.Columns.Clear()

        '        CargaGrid()

        '        For Each r As DataGridViewRow In gridPredios.Rows
        '            r.Cells(14).Value = cmbCuotas.SelectedIndex + 1
        '            r.Cells(15).Value = txtMontoCouta.Text

        '        Next

        '    End If
        'Catch ex As Exception

        'End Try
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        Dim obj As New clsDeudasUnicas

        'Dim dt As New DataTable
        'dt = obj.calcula_cuotas_medidor(240, 9)
        'For Each midata As DataRow In dt.Rows
        '    MsgBox(midata(0))
        'Next
        Dim dt As New DataTable
        'Dim idr As String
        Dim mtotal As String
        Dim idcuota As String
        For x = 1 To nrocuotas
            mtotal = ""
            idcuota = ""
            dt = obj.CalculaCouotas(txtValorSubTarifa.Text, nrocuotas)

            For Each midata As DataRow In dt.Rows
                idcuota = (midata(0))
                mtotal = mtotal & (midata(0)) & " - " & (midata(1)) & " , "
                'nro = nro & (midata(0))

            Next

            MsgBox(mtotal)
        Next

    End Sub

    Private Sub ButtonItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem1.Click
        Dim obj As New clsDeudasUnicas
        Dim numerror As String
        Dim mesanio As Integer
        Dim mesini As Integer
        Dim anio As String
        Dim nrocuotasanio As Integer
        Dim mescorre As Integer
        Dim aniocorre As Integer
        'numerror = ""
        Dim dt As New DataTable
        Dim userSystem As New ACCESO.User
        Dim mtotal As String
        Dim idcuota As String
        Dim valor_correlativo_celda As Integer
        Dim valor_idpredio As String
        mesanio = 12
        'mesrecorre = 0

        'meses_anio = nrocuotas - mesanio
        Try


            'nrocuotasanio = mesanio - mesini - 1
            For Each fila As DataGridViewRow In gridPredios.Rows
                valor_correlativo_celda = gridPredios.Item(0, fila.Index).Value
                mescorre = Val(Month(txtFecha.Text))
                aniocorre = Val(Year(txtFecha.Text))

                If valor_correlativo_celda = True Then
                    valor_idpredio = gridPredios.Item(2, fila.Index).Value

                    obj.IdJAS = fila.Cells(11).Value
                    obj.Año = cmbAnio.Text

                    obj.Predio = fila.Cells(2).Value
                    obj.TipoTarifa = fila.Cells(12).Value
                    obj.Concepto = fila.Cells(13).Value
                    obj.Mes = Month(txtFecha.Text)
                    obj.TipoDeuda = 4
                    obj.FechaDeuda = txtFecha.Text
                    obj.Volumen = 0

                    'obj.FechaPago = DBNull.Value
                    obj.Pagado = 0
                    userSystem = frmPrincipal.userSystem
                    obj.UsuarioSys = UCase(userSystem.usuario)
                    obj.Congelado = 0

                    dt = obj.CalculaCouotas(txtValorSubTarifa.Text, nrocuotas)
                    mtotal = 0
                    'mescorre = mesini
                    For Each midata As DataRow In dt.Rows

                        idcuota = (midata(0))
                        mtotal = (midata(1))

                        obj.Insert(cmbCalles.SelectedValue, aniocorre, mescorre, obj.Predio, idcuota, mtotal)
                        If mescorre <= 12 Then
                            '    aniocorre = aniocorre + 1
                            '    mescorre = 1

                            'Else
                            If mescorre = 12 Then
                                aniocorre = aniocorre + 1
                                mescorre = 1
                            Else
                                mescorre = mescorre + 1

                            End If
                            'mescorre = mescorre + 1

                        End If
                    Next

                End If
            Next
            MsgBox("Servicio Asignado satisfactoriamente", MsgBoxStyle.Information)

            gridPredios.Columns.Clear()

            CargaGrid()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub txtFecha_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFecha.Click
        Dim mes As String

        mes = Month(txtFecha.Text)
        idmes = mes

        txtMes.Text = mes


    End Sub

    Private Sub gridPredios_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridPredios.CellEndEdit
        Dim valor_correlativo_celda As Integer
        Dim valor_de_celda As Integer
        Try

            If (e.ColumnIndex = 0) Then

                If gridPredios.SelectedRows.Count > 0 Then
                    ''MsgBox("Estado: " & Me.gridPredios.Rows(e.RowIndex).Cells(" ").Value)
                    'gridPredios.Columns(0).ReadOnly = True
                    'gridPredios.Rows(e.RowIndex).Cells(0).Value = Not gridPredios.Rows(e.RowIndex).Cells(0).Value
                    valor_correlativo_celda = gridPredios.Item(0, gridPredios.CurrentRow.Index).Value
                    valor_de_celda = gridPredios.Item(2, gridPredios.CurrentRow.Index).Value
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnVisualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txtCuotas_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCuotas.Click

    End Sub

    Private Sub txtCuotas_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCuotas.ValueChanged
        nrocuotas = txtCuotas.TextAlign
    End Sub


    Private Sub cmbCPoblado_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCPoblado.SelectedIndexChanged
        Try
            clsCalles.LoadComboCallesPredio(cmbCalles, "where padPredio.idCP= " & cmbCPoblado.SelectedValue & " ")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GroupPanel2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupPanel2.Click

    End Sub
End Class