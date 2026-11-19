Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports ACCESO
Imports LOGICA
Imports System.IO
Public Class FrmRptEvalTendPorCapacidad
    Private IdCapacidad As Integer
    Private ianio As Integer
    Private cJunta As String
    Private iidcr As Integer
    Private txtJunta As String
    Private txtcr As String
    Private imes As Integer
    Private txtmes As String
    Private txtCapacidad As String

    Dim rp As New RptTendenciaCapacidad1
    Dim rp1 As New RptCurvaTendenciaCapacidad
    Private Sub FrmRptEvalTendPorCapacidad_LOAD(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        CargaAniosApertura()
        CARGAMESES(cmbMeses)
        ''cmbJunta.Text 
    End Sub

    Private Sub CargaAniosApertura()
        Dim dt As New DataTable
        Dim c As New Conexion
        If c.Connect Then
            dt = c.Query("SELECT    iAnio  FROM  dbo.AperturaAnio WHERE  (vIdJuntaUsuario = '" & cmbJunta.SelectedValue & "') AND (iIdComisionRegante = " & cmbComision.SelectedValue & ") ORDER BY iAnio")
            cmbAnio.DataSource = dt
            If dt.Rows.Count > 0 Then
                cmbAnio.ValueMember = dt.Columns(0).ToString()
                cmbAnio.DisplayMember = dt.Columns(0).ToString()
            End If
            If cmbAnio.Items.Count > 0 Then cmbAnio.SelectedItem = cmbAnio.Items.Count - 1
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
    Private Sub ViewReport1()
        If Me.InvokeRequired = True Then
            Me.Invoke(New ViewReport_Delegate(AddressOf ViewReport1))
        Else
            Me.crViewer.ReportSource = rp1
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
        Catch ex As Exception

        End Try
    End Sub

    Private Sub bgw_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgw.DoWork
        Dim c As New ACCESO.Conexion
        'Dim ds As New Reportes
        'Dim dt As New DataTable

        If c.Connect Then
            clsCrystalConnect.Conectar(rp)
            rp.ParameterFields("JU").CurrentValues.Clear()
            rp.ParameterFields("CR").CurrentValues.Clear()
            rp.ParameterFields("ANIO").CurrentValues.Clear()
            rp.ParameterFields("MES").CurrentValues.Clear()

            rp.SetParameterValue("JUNTA", txtJunta)
            rp.SetParameterValue("JU", cJunta)
            rp.SetParameterValue("CR", iidcr)
            rp.SetParameterValue("Comision", txtcr)
            rp.SetParameterValue("ANIO", ianio)
            rp.SetParameterValue("MES", imes)
            rp.SetParameterValue("MESES", txtmes)
            ViewReport()
        End If
    End Sub
    Private Sub bgw1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgw1.DoWork
        Dim c As New ACCESO.Conexion
        'Dim ds As New Reportes
        'Dim dt As New DataTable-

        If c.Connect Then
            clsCrystalConnect.Conectar(rp1)
            rp1.ParameterFields("JU").CurrentValues.Clear()
            rp1.ParameterFields("CR").CurrentValues.Clear()
            rp1.ParameterFields("ANIO").CurrentValues.Clear()
            rp1.ParameterFields("MES").CurrentValues.Clear()

            rp1.SetParameterValue("JUNTA", txtJunta)
            rp1.SetParameterValue("JU", cJunta)
            rp1.SetParameterValue("CR", iidcr)
            rp1.SetParameterValue("Comision", txtcr)
            rp1.SetParameterValue("ANIO", ianio)
            rp1.SetParameterValue("MES", imes)
            rp1.SetParameterValue("MESES", txtmes)
            ViewReport1()
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
            'cmbCapacidad.DataSource = dt
            'cmbCapacidad.ValueMember = dt.Columns(0).ToString()
            'cmbCapacidad.DisplayMember = dt.Columns(1).ToString()
            ianio = cmbAnio.Text
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


    Private Sub btnReporte2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReporte2.Click
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
            bgw1.RunWorkerAsync()
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