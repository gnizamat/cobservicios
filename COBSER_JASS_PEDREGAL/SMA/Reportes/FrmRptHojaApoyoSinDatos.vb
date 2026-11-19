Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports ACCESO
Imports LOGICA
Imports System.IO
Public Class FrmRptHojaApoyoSinDatos
    Private IdCapacidad As Integer
    Private ianio As Integer
    Private cJunta As String
    Private idCP As String
    Private idcalle As String
    Private idSECTOR As String
    Private imes As Integer
    Private txtCP As String
    Private txtJunta As String
    Private txtcr As String
    Private txtCapacidad As String
    Private idservicio As Integer
    Private idanio As String
    Private AGUAS As String
    Private CPOBLADO As String
    Private SERVICIO As String
    Dim optionRPT As Integer

    Dim rp As New Rpt_PadronUsuarios
    Dim rpServicios As New Rpt_PadronUsuarioServicios
    Dim rpPrediosCortes As New Rpt_PrediosCorte
    Dim rpReporteAsistenciaA As New Rpt_PadronUsuariosAsistenciaAsamblea




    Private Sub FrmRptHojaApoyoSinDatos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        Select Case frmPrincipal.userSystem.idInterfaz
            Case 1, 2
                clsJunta.LoadCombo(cmbJunta)

            Case 3
                clsJunta.LoadCombo(cmbJunta, " WHERE vIdJuntaUsuario='" & frmPrincipal.userSystem.idJunta & "'", , frmPrincipal.userSystem.idJunta)
                cmbJunta.Enabled = False
                'cmbComision.Focus()
            Case 4
                clsJunta.LoadCombo(cmbJunta, " WHERE vIdJuntaUsuario='" & frmPrincipal.userSystem.idJunta & "'", , frmPrincipal.userSystem.idJunta)
                'clsComisionRegante.LoadCombo(cmbComision, " where c.vIdJuntaUsuario='" & frmPrincipal.userSystem.idJunta & "' and c.iIdComisionRegante='" & frmPrincipal.userSystem.idComision & "'", , False, frmPrincipal.userSystem.idComision)
                cmbJunta.Enabled = False
                'cmbComision.Enabled = False
        End Select
        CargaAniosApertura()
        clsCentroPoblado.LoadComboADD(cmbCPoblado)
        cmbCPoblado.SelectedValue = 0
        clsCalles.LoadComboADD(cmbCalles)
        cmbCalles.SelectedValue = 0
        clsSector.LoadComboAdd(cmbsector)
        cmbsector.SelectedValue = 0
        cJunta = cmbJunta.SelectedValue
        'idcalle = cmbCalles.SelectedValue
        cmbComision.Visible = False
        cmbReporte.SelectedIndex = 0

        clsTipoTarifa.LoadComboFijos(cmbServicio, Year(ACCESO.Conexion.getDateServer))
        cmbServicio.SelectedValue = 1
        GroupPanel1.Visible = False
        'cmbCalles.SelectedIndex = 0
        ''CARGAMESES(cmbMeses)
        ''        Me.cmbJunta.Text
    End Sub

    Private Sub CargaAniosApertura()
        Dim dt As New DataTable
        Dim c As New Conexion
        If c.Connect Then
            dt = c.Query("SELECT    iAnio  FROM  dbo.AperturaAnio WHERE  (vIdJuntaUsuario = '" & cmbJunta.SelectedValue & "') AND (iIdComisionRegante = " & cmbComision.SelectedValue & ") ORDER BY iAnio")
            'cmbAnio.DataSource = dt
            If dt.Rows.Count > 0 Then
                'cmbAnio.ValueMember = dt.Columns(0).ToString()
                'cmbAnio.DisplayMember = dt.Columns(0).ToString()
            End If
            'If cmbAnio.Items.Count > 0 Then cmbAnio.SelectedItem = cmbAnio.Items.Count - 1
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

             Select optionRPT
                Case 0
                    Me.crViewer.ReportSource = rp
                    Me.crViewer.Focus()
                Case 1
                    Me.crViewer.ReportSource = rpServicios
                    Me.crViewer.Focus()

                Case 2
                    Me.crViewer.ReportSource = rpPrediosCortes
                    Me.crViewer.Focus()
                Case 3
                    Me.crViewer.ReportSource = rpReporteAsistenciaA
                    Me.crViewer.Focus()
            End Select

        End If
    End Sub

    Private Sub btnReporte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReporte.Click
        

        'Me.crViewer.ReportSource = Nothing
        'bgw.RunWorkerAsync()

        Dim c As New ACCESO.Conexion
        Dim ds As New Reportes
        Dim dt As New DataTable


        Select Case optionRPT


            Case 0
                If c.Connect Then
                    clsCrystalConnect.Conectar(rp)
                    rp.ParameterFields("@IDJAS").CurrentValues.Clear()
                    rp.ParameterFields("@IDCP").CurrentValues.Clear()
                    rp.ParameterFields("@IDCALLE").CurrentValues.Clear()
                    rp.ParameterFields("@IDSECTOR").CurrentValues.Clear()
                    rp.ParameterFields("CP").CurrentValues.Clear()


                    rp.SetParameterValue("@IDJAS", cJunta)
                    rp.SetParameterValue("@IDCP", idCP)
                    rp.SetParameterValue("@IDCALLE", idcalle)
                    rp.SetParameterValue("@IDSECTOR", idSECTOR)
                    rp.SetParameterValue("CP", txtCP)

                    ViewReport()
                    c.Close()
                End If
            Case 1

                If c.Connect Then
                    clsCrystalConnect.Conectar(rpServicios)
                    rpServicios.ParameterFields("@IDJAS").CurrentValues.Clear()
                    rpServicios.ParameterFields("@IDCP").CurrentValues.Clear()
                    rpServicios.ParameterFields("@IDCALLE").CurrentValues.Clear()
                    rpServicios.ParameterFields("@IDSERVICIO").CurrentValues.Clear()
                    'rpServicios.ParameterFields("@IDCP").CurrentValues.Clear()
                    rpServicios.ParameterFields("@IDANIO").CurrentValues.Clear()
                    rpServicios.ParameterFields("AGUAS").CurrentValues.Clear()
                    rpServicios.ParameterFields("CPOBLADO").CurrentValues.Clear()
                    rpServicios.ParameterFields("SERVICIO").CurrentValues.Clear()


                    rpServicios.SetParameterValue("@IDJAS", cJunta)
                    rpServicios.SetParameterValue("@IDCP", idCP)
                    rpServicios.SetParameterValue("@IDCALLE", idcalle)
                    rpServicios.SetParameterValue("@IDSERVICIO", idservicio)
                    'rpServicios.SetParameterValue("@IDCP", txtCP)
                    rpServicios.SetParameterValue("@IDANIO", idanio)
                    rpServicios.SetParameterValue("AGUAS", txtJunta)
                    rpServicios.SetParameterValue("CPOBLADO", txtCP)
                    rpServicios.SetParameterValue("SERVICIO", SERVICIO)
                    ViewReport()
                    c.Close()
                End If
            Case 2
                If c.Connect Then
                    clsCrystalConnect.Conectar(rpPrediosCortes)
                    rpPrediosCortes.ParameterFields("@IDJAS").CurrentValues.Clear()
                    rpPrediosCortes.ParameterFields("@IDCP").CurrentValues.Clear()
                    rpPrediosCortes.ParameterFields("@IDCALLE").CurrentValues.Clear()
                    rpPrediosCortes.ParameterFields("JASS").CurrentValues.Clear()
                    rpPrediosCortes.ParameterFields("CALLE").CurrentValues.Clear()
                    rpPrediosCortes.ParameterFields("CP").CurrentValues.Clear()


                    rpPrediosCortes.SetParameterValue("@IDJAS", cJunta)
                    rpPrediosCortes.SetParameterValue("@IDCP", idCP)
                    rpPrediosCortes.SetParameterValue("@IDCALLE", idcalle)
                    rpPrediosCortes.SetParameterValue("JASS", txtJunta)
                    rpPrediosCortes.SetParameterValue("CALLE", cmbCalles.Text)
                    rpPrediosCortes.SetParameterValue("CP", txtCP)

                    ViewReport()
                    c.Close()
                End If

            Case 3
                If c.Connect Then
                    clsCrystalConnect.Conectar(rpReporteAsistenciaA)
                    rpReporteAsistenciaA.ParameterFields("@IDJAS").CurrentValues.Clear()
                    rpReporteAsistenciaA.ParameterFields("@IDCP").CurrentValues.Clear()
                    rpReporteAsistenciaA.ParameterFields("@IDCALLE").CurrentValues.Clear()
                    rpReporteAsistenciaA.ParameterFields("@IDSECTOR").CurrentValues.Clear()
                    rpReporteAsistenciaA.ParameterFields("CP").CurrentValues.Clear()


                    rpReporteAsistenciaA.SetParameterValue("@IDJAS", cJunta)
                    rpReporteAsistenciaA.SetParameterValue("@IDCP", idCP)
                    rpReporteAsistenciaA.SetParameterValue("@IDCALLE", idcalle)
                    rpReporteAsistenciaA.SetParameterValue("@IDSECTOR", idSECTOR)
                    rpReporteAsistenciaA.SetParameterValue("CP", txtCP)

                    ViewReport()
                    c.Close()
                End If
        End Select
      
    End Sub

    Private Sub bgw_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgw.DoWork
        'Dim c As New ACCESO.Conexion
        'Dim ds As New Reportes
        'Dim dt As New DataTable


        'Select Case optionRPT
        '    Case 0
        '        If c.Connect Then
        '            clsCrystalConnect.Conectar(rp)
        '            rp.ParameterFields("@IDJAS").CurrentValues.Clear()
        '            rp.ParameterFields("@IDCP").CurrentValues.Clear()
        '            rp.ParameterFields("@IDCALLE").CurrentValues.Clear()
        '            rp.ParameterFields("@IDSECTOR").CurrentValues.Clear()
        '            rp.ParameterFields("CP").CurrentValues.Clear()


        '            rp.SetParameterValue("@IDJAS", cJunta)
        '            rp.SetParameterValue("@IDCP", idCP)
        '            rp.SetParameterValue("@IDCALLE", idcalle)
        '            rp.SetParameterValue("@IDSECTOR", idSECTOR)
        '            rp.SetParameterValue("CP", txtCP)

        '            ViewReport()
        '            c.Close()
        '        End If
        '    Case 1

        '        If c.Connect Then
        '            clsCrystalConnect.Conectar(rpServicios)
        '            rpServicios.ParameterFields("@IDJAS").CurrentValues.Clear()
        '            rpServicios.ParameterFields("@IDCP").CurrentValues.Clear()
        '            rpServicios.ParameterFields("@IDCALLE").CurrentValues.Clear()
        '            rpServicios.ParameterFields("@IDSERVICIO").CurrentValues.Clear()
        '            rpServicios.ParameterFields("@IDCP").CurrentValues.Clear()
        '            rpServicios.ParameterFields("@IDANIO").CurrentValues.Clear()
        '            rpServicios.ParameterFields("AGUAS").CurrentValues.Clear()
        '            rpServicios.ParameterFields("CPOBLADO").CurrentValues.Clear()
        '            rpServicios.ParameterFields("SERVICIO").CurrentValues.Clear()


        '            rpServicios.SetParameterValue("@IDJAS", cJunta)
        '            rpServicios.SetParameterValue("@IDCP", idCP)
        '            rpServicios.SetParameterValue("@IDCALLE", idcalle)
        '            rpServicios.SetParameterValue("@IDSERVICIO", idSECTOR)
        '            rpServicios.SetParameterValue("@IDCP", txtCP)
        '            rpServicios.SetParameterValue("@IDANIO", idcalle)
        '            rpServicios.SetParameterValue("AGUAS", txtJunta)
        '            rpServicios.SetParameterValue("CPOBLADO", txtCP)
        '            rpServicios.SetParameterValue("SERVICIO", SERVICIO)
        '            ViewReport()
        '            c.Close()
        '        End If
        'End Select
    End Sub

    Private Sub cmbComision_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbComision.SelectedIndexChanged
        Try
            CargaAniosApertura()
            'iidcr = cmbComision.SelectedValue
            txtcr = cmbComision.Text
        Catch ex As Exception

        End Try

    End Sub

    Private Sub cmbAnio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim dt As New DataTable
            'dt = clsEstructuraSMA.ListaCapacidades(cmbJunta.SelectedValue, cmbComision.SelectedValue, cmbAnio.SelectedValue)
            'cmbCapacidad.DataSource = dt
            'cmbCapacidad.ValueMember = dt.Columns(0).ToString()
            'cmbCapacidad.DisplayMember = dt.Columns(1).ToString()
            'ianio = cmbAnio.Text
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

    Private Sub cmbCapacidad_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            'IdCapacidad = cmbCapacidad.SelectedValue
            'txtCapacidad = cmbCapacidad.Text
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

    Private Sub cmbReporte_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbReporte.SelectedIndexChanged
        optionRPT = cmbReporte.SelectedIndex
        Select Case optionRPT
            Case 0
                Try
                    GroupPanel1.Visible = False
                    cmbsector.Visible = True
                    LabelX1.Visible = True
                Catch ex As Exception

                End Try
            Case 1
                GroupPanel1.Visible = True
                cmbsector.Visible = False
                LabelX1.Visible = False


            Case 2
                Try
                    GroupPanel1.Visible = False
                    cmbsector.Visible = False
                    LabelX1.Visible = False

                Catch ex As Exception

                End Try
        End Select
    End Sub

    Private Sub ExpandablePanel1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExpandablePanel1.Click

    End Sub

    Private Sub crViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles crViewer.Load

    End Sub

    Private Sub cmbCalles_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCalles.SelectedIndexChanged
        Try

            idcalle = cmbCalles.SelectedValue
            If idcalle = 0 Then
                idcalle = "%"
            Else
                idcalle = idcalle
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmbCPoblado_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCPoblado.SelectedIndexChanged
        Try

            idCP = cmbCPoblado.SelectedValue
            txtCP = cmbCPoblado.Text
            If idCP = 0 Then
                idCP = "%"
            Else
                idCP = idCP
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmbsector_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbsector.SelectedIndexChanged
        Try

            idSECTOR = cmbsector.SelectedValue
            If idSECTOR = 0 Then
                idSECTOR = "%"
            Else
                idSECTOR = idSECTOR
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtValorSubTarifa_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtValorServicio.TextChanged

    End Sub

    Private Sub LabelX16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LabelX16.Click

    End Sub

    Private Sub cmbSubTipoTarifa_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbServicio.SelectedIndexChanged
        Try

        
            idservicio = cmbServicio.SelectedValue
            SERVICIO = cmbServicio.Text
            idanio = Year(ACCESO.Conexion.getDateServer)
            txtValorServicio.Text = cmbServicio.SelectedItem(3).ToString
        Catch ex As Exception

        End Try

    End Sub

    Private Sub LabelX13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LabelX13.Click

    End Sub
End Class
