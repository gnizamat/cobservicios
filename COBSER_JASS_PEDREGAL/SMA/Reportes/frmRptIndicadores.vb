Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports ACCESO
Imports LOGICA
Imports System.IO
Public Class frmRptIndicadores
    Private IdCapacidad As Integer
    Private ianio As Integer
    Private imes As Integer
    Private cJunta As String
    Private iidcr As Integer

    Private txtJunta As String
    Private txtcr As String
    Private txtmes As String

    Dim rp As New Rpt1
    'variables edinson
    Public idJuntaSelect As String
    Public idComisionSelect As Integer
    Public anioSelect As Integer
    Public idcapacidadSelect As Integer
    Public mesSelect As Integer
    Private txtCapacidad As String
    Private Sub frmRptIndicadores_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        Select Case frmPrincipal.userSystem.idInterfaz
            Case 1, 2
                clsJunta.LoadCombo(cmbJunta)
            Case 3
                clsJunta.LoadCombo(cmbJunta, " WHERE vIdJuntaUsuario='" & frmPrincipal.userSystem.idJunta & "'", , frmPrincipal.userSystem.idJunta)
                cmbJunta.Enabled = False
                cmbComision.Focus()
            Case 4
                clsJunta.LoadCombo(cmbJunta, " WHERE vIdJuntaUsuario='" & frmPrincipal.userSystem.idJunta & "'", , frmPrincipal.userSystem.idJunta)
                clsComisionRegante.LoadCombo(cmbComision, " where c.vIdJuntaUsuario='" & frmPrincipal.userSystem.idJunta & "' and c.iIdComisionRegante='" & frmPrincipal.userSystem.idComision & "'", , False, frmPrincipal.userSystem.idComision)
                cmbJunta.Enabled = False
                cmbComision.Enabled = False
        End Select
        ''CargaAniosApertura()
        CARGAMESES(cmbMeses)
    End Sub

    Private Sub CargaAniosApertura()
        Dim dt As New DataTable
        Dim c As New Conexion
        If c.Connect Then
            '' dt = c.Query("SELECT    iAnio  FROM  dbo.AperturaAnio WHERE  (vIdJuntaUsuario = '" & cmbJunta.SelectedValue & "') AND (iIdComisionRegante = " & cmbComision.SelectedValue & ") AND (cEstado = '1') ORDER BY iAnio") ORIGINAL
            dt = c.Query("SELECT    iAnio  FROM  dbo.AperturaAnio WHERE  (vIdJuntaUsuario = '" & cmbJunta.SelectedValue & "') AND (iIdComisionRegante = " & cmbComision.SelectedValue & ")  ORDER BY iAnio")
            cmbAnio.DataSource = dt
            If dt.Rows.Count > 0 Then
                cmbAnio.ValueMember = dt.Columns(0).ToString()
                cmbAnio.DisplayMember = dt.Columns(0).ToString()
            End If
            If cmbAnio.Items.Count > 0 Then cmbAnio.SelectedItem = cmbAnio.Items.Count - 1
            cmbAnio.SelectedValue = anioSelect
            c.Close()
        End If
    End Sub

    Private Delegate Sub IniPgb_Delegate(ByVal value As Integer, ByVal lbl As String)
    Public Sub IniPgb(ByVal value As Integer, ByVal lbl As String)
        If Me.InvokeRequired = True Then
            Me.Invoke(New IniPgb_Delegate(AddressOf IniPgb), value, lbl)
        Else
            pgb.Value = 0
            pgb.Maximum = value
            lblProgreso.Text = lbl
        End If
    End Sub

    Private Sub bgw_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles bgw.ProgressChanged
        pgb.Value = e.ProgressPercentage
    End Sub

    Private Delegate Sub ViewReport_Delegate()
    Private Sub ViewReport()
        If Me.InvokeRequired = True Then
            Me.Invoke(New ViewReport_Delegate(AddressOf ViewReport))
        Else
            Me.crViewer.ReportSource = rp
            Me.crViewer.Focus()
        End If
    End Sub

    Private Sub btnReporte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReporte.Click
        If Me.cmbAnio.Text = "" Then
            MsgBox("Seleccione Año")
            cmbAnio.Focus()
            Exit Sub
        End If

        If Me.cmbMeses.Text = "" Then
            MsgBox("Seleccione Mes")
            cmbMeses.Focus()
            Exit Sub
        End If
        Try
            Me.crViewer.ReportSource = Nothing
            bgw.RunWorkerAsync()
            pgb.Visible = False

        Catch ex As Exception
        End Try
    End Sub

    Private Sub bgw_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgw.DoWork
        Dim c As New ACCESO.Conexion
        Dim ds As New Reportes
        Dim dt As New DataTable
        'Dim fila As Data.DataRow
        Dim fila1 As Data.DataRow
        Dim filaC() As DataRow
        Dim filai() As DataRow
        Dim I As Integer = 0
        'Dim ENCONTRADO As Boolean = False
        If c.Connect Then
            'limpiamos el contenedor
            ds.Tables("AVANCES").Rows.Clear()
            'obtenemos los datos
            c.QueryDataset("EXEC dbo.sp_Devuelve_Vance_Mes '" & cJunta & "'," & iidcr & "," & ianio & "," & IdCapacidad, ds, "AVANCES")

            'CAPTURAMOS LOS DATOS DEL INDICADOR2
            filaC = ds.Tables("AVANCES").Select("IDEST = " & IdCapacidad & "")
            filai = ds.Tables("AVANCES").Select("IDPEST = " & IdCapacidad & "")
            IniPgb(filai.Length, "")
            'RECORREMOS LA TABLA DE AVANCES  BUSCANDO LOS VALORES PARA INSERTAR
            For Each Midatarow2 As DataRow In ds.Tables("AVANCES").Select("IDPEST = " & IdCapacidad & "")
                'fila = ds.Tables("CUADROS").NewRow()
                'fila("IDESTC") = filaC(0).Item(2)
                'fila("CAPACIDAD") = filaC(0).Item(0)
                'fila("PESOC") = filaC(0).Item(1)
                'fila("VALORC") = filaC(0).Item(4 + imes)

                'fila("IDESTI") = Midatarow2(2)
                'fila("INDICADOR") = Midatarow2(0)
                'fila("PESO") = Midatarow2(1)
                'fila("VALORI") = Midatarow2(4 + imes)
                For Each Midatarow3 As DataRow In ds.Tables("AVANCES").Select("IDPEST = " & Midatarow2(4) & "")
                    fila1 = ds.Tables("CUADROS").NewRow()
                    fila1("IDESTC") = filaC(0).Item(2)
                    fila1("CAPACIDAD") = filaC(0).Item(0)
                    fila1("PESOC") = filaC(0).Item(1)
                    fila1("VALORC") = filaC(0).Item(4 + imes)

                    fila1("IDESTI") = Midatarow2(4)
                    fila1("INDICADOR") = Midatarow2(0)
                    fila1("PESO") = Midatarow2(1)
                    fila1("VALORI") = Midatarow2(6 + imes)

                    fila1("IDESTM") = Midatarow3(4)
                    fila1("MEDIDA") = Midatarow3(0)
                    fila1("PESOM") = Midatarow3(1)
                    fila1("VALORM") = Midatarow3(6 + imes)
                    ds.Tables("CUADROS").Rows.Add(fila1)
                    'ENCONTRADO = True
                Next

                bgw.ReportProgress(I)
                I += 1
                'If Not ENCONTRADO Then
                '    ds.Tables("CUADROS").Rows.Add(fila)
                '    ENCONTRADO = False
                'End If

            Next
            rp.SetDataSource(ds)
            rp.ParameterFields("JU").CurrentValues.Clear()
            rp.ParameterFields("CR").CurrentValues.Clear()
            rp.ParameterFields("ANIO").CurrentValues.Clear()
            rp.ParameterFields("MES").CurrentValues.Clear()

            rp.ParameterFields("JU").CurrentValues.AddValue(txtJunta)
            rp.ParameterFields("CR").CurrentValues.AddValue(txtcr)
            rp.ParameterFields("ANIO").CurrentValues.AddValue(ianio)
            rp.ParameterFields("MES").CurrentValues.AddValue(txtmes)

            ViewReport()

            'MsgBox(ds.Tables("CUADROS").Rows.Count)
            c.Close()
        End If
    End Sub

    Private Sub cmbComision_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbComision.SelectedIndexChanged
        Try
            CargaAniosApertura()
            iidcr = cmbComision.SelectedValue
            txtcr = cmbComision.Text
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmbAnio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAnio.SelectedIndexChanged
        Try
            Dim dt As New DataTable
            dt = clsEstructuraSMA.ListaCapacidades(cmbJunta.SelectedValue, cmbComision.SelectedValue, cmbAnio.SelectedValue)
            cmbCapacidad.DataSource = dt
            cmbCapacidad.ValueMember = dt.Columns(0).ToString()
            cmbCapacidad.DisplayMember = dt.Columns(1).ToString()
            ianio = cmbAnio.Text
            cmbCapacidad.SelectedValue = idcapacidadSelect
            If (idcapacidadSelect <> 0) Then
                Me.crViewer.ReportSource = Nothing
                bgw.RunWorkerAsync()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CARGAMESES(ByRef CMB As DevComponents.DotNetBar.Controls.ComboBoxEx)
        CMB.Items.Clear()
        CMB.Items.Add("Enero")
        CMB.Items.Add("Febrero")
        CMB.Items.Add("Marzo")
        CMB.Items.Add("Abril")
        CMB.Items.Add("Mayo")
        CMB.Items.Add("Junio")
        CMB.Items.Add("Julio")
        CMB.Items.Add("Agosto")
        CMB.Items.Add("Setiembre")
        CMB.Items.Add("Octubre")
        CMB.Items.Add("Noviembre")
        CMB.Items.Add("Diciembre")
        'CMB.SelectedIndex = mesSelect
    End Sub

    Private Sub cmbJunta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbJunta.SelectedIndexChanged
        Try
            Select Case frmPrincipal.userSystem.idInterfaz
                Case 1, 2, 3
                    clsComisionRegante.LoadCombo(cmbComision, " Where c.vIdJuntaUsuario='" & cmbJunta.SelectedValue & "' ", , True, 0)
                    cmbComision.Enabled = True
                    If cmbComision.Items.Count > 0 Then cmbComision.SelectedIndex = cmbComision.Items.Count - 1
                Case 4
                    clsComisionRegante.LoadCombo(cmbComision, " Where c.vIdJuntaUsuario='" & cmbJunta.SelectedValue & "' and c.iIdComisionRegante='" & frmPrincipal.userSystem.idComision & "'", , False)
                    cmbComision.SelectedIndex = 0
                    cmbComision.Enabled = False
            End Select
            CargaAniosApertura()
            cJunta = cmbJunta.SelectedValue
            txtJunta = cmbJunta.Text
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmbCapacidad_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCapacidad.SelectedIndexChanged
        Try
            IdCapacidad = cmbCapacidad.SelectedValue
            txtCapacidad = cmbCapacidad.Text
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmbMeses_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMeses.SelectedIndexChanged
        Try
            imes = cmbMeses.SelectedIndex + 1
            txtmes = cmbMeses.Text
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmbJunta_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbJunta.SelectedValueChanged
        Try
            Select Case frmPrincipal.userSystem.idInterfaz
                Case 1, 2, 3
                    clsComisionRegante.LoadCombo(cmbComision, " Where c.vIdJuntaUsuario='" & cmbJunta.SelectedValue & "' ", , True, 0)
                    cmbComision.Enabled = True
                    If cmbComision.Items.Count > 0 Then cmbComision.SelectedIndex = cmbComision.Items.Count - 1
                Case 4
                    clsComisionRegante.LoadCombo(cmbComision, " Where c.vIdJuntaUsuario='" & cmbJunta.SelectedValue & "' and c.iIdComisionRegante='" & frmPrincipal.userSystem.idComision & "'", , False)
                    cmbComision.SelectedIndex = 0
                    cmbComision.Enabled = False
            End Select

            CargaAniosApertura()
            cJunta = cmbJunta.SelectedValue
            txtJunta = cmbJunta.Text
        Catch ex As Exception
        End Try
    End Sub
End Class