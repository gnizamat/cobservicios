Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports ACCESO
Imports LOGICA
Imports System.IO

Public Class frmRpt_TarCobranzas
    Dim optionRPT As Integer
    Dim rpcajas As New tar_Rpt_LiquidacionDiariaCaja
    Dim rpRCS As New tar_Rpt_ResumenCobranzaServicios
    Dim rpRCA As New tar_Rpt_ResumenCobranzaAnios
    Dim rpRCAD As New tar_Rpt_LiquidacionCobranzaDetallada
    Dim rpRCADIARIA As New tar_Rpt_ResumenCobranzasDiaria
    Dim Rpt_TipoTarifa As New tar_Rpt_ResumenCobranzasTipoTarifa
    Dim Rpt_Moras As New tar_Rpt_CobranzasDetalladoMoras
    Dim Rpt_CobranzaT As New tar_Rpt_ResumenCobranzasTotal



    Private Sub frmRpt_TarCobranzas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        Select Case frmPrincipal.userSystem.idInterfaz
            Case 4
                clsJunta.LoadCombo(cmbJunta, " WHERE vIdJuntaUsuario='" & frmPrincipal.userSystem.idJunta & "'", , frmPrincipal.userSystem.idJunta)
                cmbJunta.Enabled = False
        End Select
        'CargaAniosApertura()
        txtFechaIni.Text = ACCESO.Conexion.getDateServer
        txtFechaFin.Text = ACCESO.Conexion.getDateServer
        clsCaja.LoadCombo(cmbCajas)
        cmbReporte.SelectedIndex = 0
        clsTipoTarifa.LoadComboTodosyMora(cmbTipoDeuda)
        cmbTipoDeuda.SelectedIndex = 0

    End Sub

    Private Sub btnReporte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReporte.Click
        Dim c As New ACCESO.Conexion
        Dim ds As New Reportes
        Dim dt As New DataTable
         Select optionRPT
            Case 0
                If c.Connect Then
                    clsCrystalConnect.Conectar(rpcajas)
                    rpcajas.ParameterFields("@IDCAJA").CurrentValues.Clear()
                    rpcajas.ParameterFields("@FINI").CurrentValues.Clear()
                    rpcajas.ParameterFields("@FFIN").CurrentValues.Clear()

                    rpcajas.SetParameterValue("@IDCAJA", cmbCajas.SelectedValue)
                    rpcajas.SetParameterValue("@FINI", txtFechaIni.Text)
                    rpcajas.SetParameterValue("@FFIN", txtFechaFin.Text)
                    ViewReport()
                    c.Close()
                End If

            Case 1

                'If c.Connect Then
                '    clsCrystalConnect.Conectar(rpRCS)
                '    rpRCS.ParameterFields("@IDCAJA").CurrentValues.Clear()
                '    rpRCS.ParameterFields("@FINI").CurrentValues.Clear()
                '    rpRCS.ParameterFields("@FFIN").CurrentValues.Clear()

                '    rpRCS.SetParameterValue("@IDCAJA", cmbCajas.SelectedValue)
                '    rpRCS.SetParameterValue("@FINI", txtFechaIni.Text)
                '    rpRCS.SetParameterValue("@FFIN", txtFechaFin.Text)
                '    ViewReport()
                '    c.Close()
                'End If

                If c.Connect Then
                    clsCrystalConnect.Conectar(Rpt_CobranzaT)
                    Rpt_CobranzaT.ParameterFields("@IDCAJA").CurrentValues.Clear()
                    Rpt_CobranzaT.ParameterFields("@FINI").CurrentValues.Clear()
                    Rpt_CobranzaT.ParameterFields("@FFIN").CurrentValues.Clear()

                    Rpt_CobranzaT.SetParameterValue("@IDCAJA", cmbCajas.SelectedValue)
                    Rpt_CobranzaT.SetParameterValue("@FINI", txtFechaIni.Text)
                    Rpt_CobranzaT.SetParameterValue("@FFIN", txtFechaFin.Text)
                    ViewReport()
                    c.Close()
                End If

            Case 2
                If c.Connect Then
                    clsCrystalConnect.Conectar(rpRCA)
                    rpRCA.ParameterFields("@IDCAJA").CurrentValues.Clear()
                    rpRCA.ParameterFields("@FINI").CurrentValues.Clear()
                    rpRCA.ParameterFields("@FFIN").CurrentValues.Clear()

                    rpRCA.SetParameterValue("@IDCAJA", cmbCajas.SelectedValue)
                    rpRCA.SetParameterValue("@FINI", txtFechaIni.Text)
                    rpRCA.SetParameterValue("@FFIN", txtFechaFin.Text)
                    ViewReport()
                    c.Close()
                End If
            Case 3
                If c.Connect Then
                    clsCrystalConnect.Conectar(rpRCAD)
                    rpRCAD.ParameterFields("@IDCAJA").CurrentValues.Clear()
                    rpRCAD.ParameterFields("@FINI").CurrentValues.Clear()
                    rpRCAD.ParameterFields("@FFIN").CurrentValues.Clear()

                    rpRCAD.SetParameterValue("@IDCAJA", cmbCajas.SelectedValue)
                    rpRCAD.SetParameterValue("@FINI", txtFechaIni.Text)
                    rpRCAD.SetParameterValue("@FFIN", txtFechaFin.Text)
                    ViewReport()
                    c.Close()
                End If
            Case 4
                If c.Connect Then
                    clsCrystalConnect.Conectar(rpRCADIARIA)
                    rpRCADIARIA.ParameterFields("@IDCAJA").CurrentValues.Clear()
                    rpRCADIARIA.ParameterFields("@FINI").CurrentValues.Clear()
                    rpRCADIARIA.ParameterFields("@FFIN").CurrentValues.Clear()

                    rpRCADIARIA.SetParameterValue("@IDCAJA", cmbCajas.SelectedValue)
                    rpRCADIARIA.SetParameterValue("@FINI", txtFechaIni.Text)
                    rpRCADIARIA.SetParameterValue("@FFIN", txtFechaFin.Text)
                    ViewReport()
                    c.Close()
                End If

            Case 5
                If cmbTipoDeuda.SelectedValue <> 0 Then
                    If c.Connect Then
                        clsCrystalConnect.Conectar(Rpt_TipoTarifa)
                        Rpt_TipoTarifa.ParameterFields("@IDCAJA").CurrentValues.Clear()
                        Rpt_TipoTarifa.ParameterFields("@FINI").CurrentValues.Clear()
                        Rpt_TipoTarifa.ParameterFields("@FFIN").CurrentValues.Clear()
                        Rpt_TipoTarifa.ParameterFields("@IDTIPOTARIFA").CurrentValues.Clear()

                        Rpt_TipoTarifa.SetParameterValue("@IDCAJA", cmbCajas.SelectedValue)
                        Rpt_TipoTarifa.SetParameterValue("@FINI", txtFechaIni.Text)
                        Rpt_TipoTarifa.SetParameterValue("@FFIN", txtFechaFin.Text)
                        Rpt_TipoTarifa.SetParameterValue("@IDTIPOTARIFA", cmbTipoDeuda.SelectedValue)
                        ViewReport()
                        c.Close()
                    End If
                End If

                If cmbTipoDeuda.SelectedValue = 0 Then
                    If c.Connect Then
                        clsCrystalConnect.Conectar(Rpt_Moras)
                        Rpt_Moras.ParameterFields("@IDCAJA").CurrentValues.Clear()
                        Rpt_Moras.ParameterFields("@FINI").CurrentValues.Clear()
                        Rpt_Moras.ParameterFields("@FFIN").CurrentValues.Clear()
                        'Rpt_TipoTarifa.ParameterFields("@IDTIPOTARIFA").CurrentValues.Clear()

                        Rpt_Moras.SetParameterValue("@IDCAJA", cmbCajas.SelectedValue)
                        Rpt_Moras.SetParameterValue("@FINI", txtFechaIni.Text)
                        Rpt_Moras.SetParameterValue("@FFIN", txtFechaFin.Text)
                        'Rpt_TipoTarifa.SetParameterValue("@IDTIPOTARIFA", cmbTipoDeuda.SelectedValue)
                        ViewReport()
                        c.Close()
                    End If

                End If

        End Select

    End Sub
    Private Delegate Sub ViewReport_Delegate()

    Private Sub ViewReport()
        If Me.InvokeRequired = True Then
            Me.Invoke(New ViewReport_Delegate(AddressOf ViewReport))
        Else
            Select Case optionRPT
                Case 0
                    Me.crViewer.ReportSource = rpcajas
                    Me.crViewer.Focus()
                Case 1
                    'Me.crViewer.ReportSource = rpRCS
                    'Me.crViewer.Focus()
                    Me.crViewer.ReportSource = Rpt_CobranzaT
                    Me.crViewer.Focus()
                Case 2
                    Me.crViewer.ReportSource = rpRCA
                    Me.crViewer.Focus()
                Case 3
                    Me.crViewer.ReportSource = rpRCAD
                    Me.crViewer.Focus()

                Case 4
                    Me.crViewer.ReportSource = rpRCADIARIA
                    Me.crViewer.Focus()
                Case 5
                    If cmbTipoDeuda.SelectedValue <> 0 Then
                        Me.crViewer.ReportSource = Rpt_TipoTarifa
                        Me.crViewer.Focus()
                    Else
                        Me.crViewer.ReportSource = Rpt_Moras
                        Me.crViewer.Focus()
                    End If
                   
            End Select

        End If
    End Sub

    Private Sub cmbReporte_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbReporte.SelectedIndexChanged
        optionRPT = cmbReporte.SelectedIndex

        If optionRPT <= 4 Then
            LabelX9.Visible = True
            txtFechaIni.Visible = True
            LabelX1.Visible = True
            txtFechaFin.Visible = True
            LabelX2.Visible = True
            cmbCajas.Visible = True
            LabelX5.Visible = False
            cmbTipoDeuda.Visible = False
            txtValorSubTarifa.Visible = False

        End If
        If optionRPT = 5 Then
            LabelX9.Visible = True
            txtFechaIni.Visible = True
            LabelX1.Visible = True
            txtFechaFin.Visible = True
            LabelX2.Visible = True
            cmbCajas.Visible = True
            LabelX5.Visible = True
            cmbTipoDeuda.Visible = True
            txtValorSubTarifa.Visible = True

        End If

    End Sub


    Private Sub txtFechaIni_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFechaIni.Click

    End Sub

    Private Sub GroupPanel1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupPanel1.Click

    End Sub

    Private Sub cmbTipoDeuda_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipoDeuda.SelectedIndexChanged
        Try
            txtValorSubTarifa.Text = cmbTipoDeuda.SelectedItem(3).ToString
            'txtMonto.Text = cmbSubTipoTarifa.SelectedItem(5).ToString
            'CargaLista()

        Catch ex As Exception

        End Try
    End Sub
End Class