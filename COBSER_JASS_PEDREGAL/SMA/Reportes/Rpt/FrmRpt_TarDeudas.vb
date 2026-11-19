Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports ACCESO
Imports LOGICA
Imports System.IO

Public Class FrmRpt_TarDeudas
    Private ianio As Integer
    Private cJunta As String
    Private idcalle As String
    Private idanio As String
    Private imes As Integer
    Private txtJunta As String
    Private calle As String
    Private anio As String
    Private mes As String
    Dim optionRPT As Integer
    Dim rp As New tar_Rpt_DetalleDeudaPrediosPorAnios
    Dim rpa As New tar_Rpt_DetalleDeudaPrediosPorAniosconTot
    Dim rpd As New tar_Rpt_DetalleDeudaPredios
    Dim rpdRes As New tar_Rpt_ResumenDeudasAnios
    Dim rpdResAnioscalles As New tar_Rpt_ResumenDeudasaAniosCalles
    Dim rpdRescalles As New tar_Rpt_ResumenDeudasCalles
    Dim rpdMorosos As New tar_Rpt_Listado_Morosos





    Private Sub FrmRpt_TarDeudas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Me.WindowState = FormWindowState.Maximized
            Select Case frmPrincipal.userSystem.idInterfaz
                Case 4
                    clsJunta.LoadCombo(cmbJunta, " WHERE vIdJuntaUsuario='" & frmPrincipal.userSystem.idJunta & "'", , frmPrincipal.userSystem.idJunta)
                    cmbJunta.Enabled = False
            End Select
            'CargaAniosApertura()
            clsCalles.LoadComboADD(cmbCalles)
            clsAnioTarifa.LoadCombo(cmbAños)
            cJunta = cmbJunta.SelectedValue

            clsCentroPoblado.LoadComboADD(cmbCPoblado)
            cmbCPoblado.SelectedIndex = 0

            idcalle = cmbCalles.SelectedValue
            'idanio = cmbAños.SelectedValue
            txtJunta = cmbJunta.Text
            'calle = cmbCalles.Text 
            cmbReporte.SelectedIndex = 0
            cmbCalles.SelectedValue = 0
            cmbTipoDeuda.SelectedIndex = 2
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnReporte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReporte.Click
        'Try
        '    Me.crViewer.ReportSource = Nothing
        '    bgw.RunWorkerAsync()
        'Catch ex As Exception

        'End Try

        Dim c As New ACCESO.Conexion
        Dim ds As New Reportes
        Dim dt As New DataTable

        Try

            If chkAnio.Checked = True Then
                anio = cmbAños.Text
                idanio = cmbAños.Text
            Else
                anio = "TODOS"
                idanio = "%"
            End If
            mes = txtMeses.Text
            Select Case optionRPT
                Case 0
                    If c.Connect Then
                        clsCrystalConnect.Conectar(rp)
                        rp.ParameterFields("@IDJAS").CurrentValues.Clear()
                        rp.ParameterFields("@IDCALLE").CurrentValues.Clear()
                        rp.ParameterFields("@IDANIO").CurrentValues.Clear()
                        rp.ParameterFields("JAS").CurrentValues.Clear()
                        rp.ParameterFields("CALLE").CurrentValues.Clear()
                        rp.ParameterFields("ANIO").CurrentValues.Clear()

                        rp.SetParameterValue("@IDJAS", cJunta)
                        rp.SetParameterValue("@IDCALLE", idcalle)
                        rp.SetParameterValue("@IDANIO", idanio)
                        rp.SetParameterValue("JAS", txtJunta)
                        rp.SetParameterValue("CALLE", calle)
                        rp.SetParameterValue("ANIO", anio)
                        ViewReport()
                        c.Close()
                    End If

                Case 1
                    If c.Connect Then
                        clsCrystalConnect.Conectar(rpa)
                        rpa.ParameterFields("@IDJAS").CurrentValues.Clear()
                        rpa.ParameterFields("@IDCALLE").CurrentValues.Clear()
                        rpa.ParameterFields("@IDANIO").CurrentValues.Clear()
                        rpa.ParameterFields("JAS").CurrentValues.Clear()
                        rpa.ParameterFields("CALLE").CurrentValues.Clear()
                        rpa.ParameterFields("ANIO").CurrentValues.Clear()

                        rpa.SetParameterValue("@IDJAS", cJunta)
                        rpa.SetParameterValue("@IDCALLE", idcalle)
                        rpa.SetParameterValue("@IDANIO", idanio)
                        rpa.SetParameterValue("JAS", txtJunta)
                        rpa.SetParameterValue("CALLE", calle)
                        rpa.SetParameterValue("ANIO", anio)
                        ViewReport()
                        c.Close()
                    End If
                Case 2
                    If c.Connect Then
                        clsCrystalConnect.Conectar(rpd)
                        rpd.ParameterFields("@IDJAS").CurrentValues.Clear()
                        rpd.ParameterFields("@IDCALLE").CurrentValues.Clear()
                        rpd.ParameterFields("@IDANIO").CurrentValues.Clear()
                        rpd.ParameterFields("JAS").CurrentValues.Clear()
                        rpd.ParameterFields("CALLE").CurrentValues.Clear()
                        rpd.ParameterFields("ANIO").CurrentValues.Clear()

                        rpd.SetParameterValue("@IDJAS", cJunta)
                        rpd.SetParameterValue("@IDCALLE", idcalle)
                        rpd.SetParameterValue("@IDANIO", idanio)
                        rpd.SetParameterValue("JAS", txtJunta)
                        rpd.SetParameterValue("CALLE", calle)
                        rpd.SetParameterValue("ANIO", anio)

                        ViewReport()
                        c.Close()
                    End If
                Case 3
                    If c.Connect Then
                        clsCrystalConnect.Conectar(rpdRes)
                        rpdRes.ParameterFields("@IDJAS").CurrentValues.Clear()
                        rpdRes.ParameterFields("@IDCALLE").CurrentValues.Clear()
                        rpdRes.ParameterFields("@IDANIO").CurrentValues.Clear()
                        rpdRes.ParameterFields("JAS").CurrentValues.Clear()
                        rpdRes.ParameterFields("CALLE").CurrentValues.Clear()
                        rpdRes.ParameterFields("ANIO").CurrentValues.Clear()

                        rpdRes.SetParameterValue("@IDJAS", cJunta)
                        rpdRes.SetParameterValue("@IDCALLE", idcalle)
                        rpdRes.SetParameterValue("@IDANIO", idanio)
                        rpdRes.SetParameterValue("JAS", txtJunta)
                        rpdRes.SetParameterValue("CALLE", calle)
                        rpdRes.SetParameterValue("ANIO", anio)

                        ViewReport()
                        c.Close()
                    End If
                Case 4
                    If c.Connect Then
                        clsCrystalConnect.Conectar(rpdResAnioscalles)
                        'clsCrystalConnect.Conectar("tar_Rpt_ResumenDeudasaAniosCalles.rpt")
                        rpdResAnioscalles.ParameterFields("@IDJAS").CurrentValues.Clear()
                        rpdResAnioscalles.ParameterFields("@IDCALLE").CurrentValues.Clear()
                        rpdResAnioscalles.ParameterFields("@IDANIO").CurrentValues.Clear()
                        rpdResAnioscalles.ParameterFields("JAS").CurrentValues.Clear()
                        rpdResAnioscalles.ParameterFields("CALLE").CurrentValues.Clear()
                        rpdResAnioscalles.ParameterFields("ANIO").CurrentValues.Clear()

                        rpdResAnioscalles.SetParameterValue("@IDJAS", cJunta)
                        rpdResAnioscalles.SetParameterValue("@IDCALLE", idcalle)
                        rpdResAnioscalles.SetParameterValue("@IDANIO", idanio)
                        rpdResAnioscalles.SetParameterValue("JAS", txtJunta)
                        rpdResAnioscalles.SetParameterValue("CALLE", calle)
                        rpdResAnioscalles.SetParameterValue("ANIO", anio)
                        ViewReport()
                        c.Close()

                    End If

                Case 5
                    idanio = cmbAños.Text
                    If c.Connect Then
                        clsCrystalConnect.Conectar(rpdMorosos)
                        'clsCrystalConnect.Conectar("tar_Rpt_ResumenDeudasaAniosCalles.rpt")
                        rpdMorosos.ParameterFields("@IDJAS").CurrentValues.Clear()
                        rpdMorosos.ParameterFields("@IDCALLE").CurrentValues.Clear()
                        rpdMorosos.ParameterFields("@IDANIO").CurrentValues.Clear()
                        rpdMorosos.ParameterFields("@IDMES").CurrentValues.Clear()
                        rpdMorosos.ParameterFields("JASS").CurrentValues.Clear()
                        rpdMorosos.ParameterFields("CALLE").CurrentValues.Clear()

                        rpdMorosos.SetParameterValue("@IDJAS", cJunta)
                        rpdMorosos.SetParameterValue("@IDCALLE", idcalle)
                        rpdMorosos.SetParameterValue("@IDMES", mes)
                        rpdMorosos.SetParameterValue("@IDANIO", idanio)
                        rpdMorosos.SetParameterValue("JASS", txtJunta)
                        rpdMorosos.SetParameterValue("CALLE", calle)
                        'rpdMorosos.SetParameterValue("ANIO", anio)
                        ViewReport()
                        c.Close()

                    End If
            End Select
        Catch ex As Exception
        End Try

    End Sub
    Private Delegate Sub ViewReport_Delegate()

    Private Sub ViewReport()
        If Me.InvokeRequired = True Then
            Me.Invoke(New ViewReport_Delegate(AddressOf ViewReport))
        Else
            Select Case optionRPT
                Case 0
                    Me.crViewer.ReportSource = rp
                    Me.crViewer.Focus()
                Case 1
                    Me.crViewer.ReportSource = rpa
                    Me.crViewer.Focus()
                Case 2
                    Me.crViewer.ReportSource = rpd
                    Me.crViewer.Focus()
                Case 3
                    Me.crViewer.ReportSource = rpdRes
                    Me.crViewer.Focus()
                Case 4
                    Me.crViewer.ReportSource = rpdResAnioscalles
                    Me.crViewer.Focus()
                Case 5
                    Me.crViewer.ReportSource = rpdMorosos
                    Me.crViewer.Focus()
            End Select
          
        End If
    End Sub
    'Private Sub ViewReport1()
    '    If Me.InvokeRequired = True Then
    '        Me.Invoke(New ViewReport_Delegate(AddressOf ViewReport))
    '    Else
    '        Me.crViewer.ReportSource = rpd
    '        Me.crViewer.Focus()
    '    End If
    'End Sub

    Private Sub bgw_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgw.DoWork
        'Dim c As New ACCESO.Conexion
        'Dim ds As New Reportes
        'Dim dt As New DataTable

        'Try

        '    If chkAnio.Checked = True Then
        '        anio = cmbAños.Text
        '        idanio = cmbAños.Text
        '    Else
        '        anio = "TODOS"
        '        idanio = "%"
        '    End If

        '    Select Case optionRPT
        '        Case 0
        '            If c.Connect Then
        '                clsCrystalConnect.Conectar(rp)
        '                rp.ParameterFields("@IDJAS").CurrentValues.Clear()
        '                rp.ParameterFields("@IDCALLE").CurrentValues.Clear()
        '                rp.ParameterFields("@IDANIO").CurrentValues.Clear()
        '                rp.ParameterFields("JAS").CurrentValues.Clear()
        '                rp.ParameterFields("CALLE").CurrentValues.Clear()
        '                rpd.ParameterFields("ANIO").CurrentValues.Clear()

        '                rp.SetParameterValue("@IDJAS", cJunta)
        '                rp.SetParameterValue("@IDCALLE", idcalle)
        '                rp.SetParameterValue("@IDANIO", idanio)
        '                rp.SetParameterValue("JAS", txtJunta)
        '                rp.SetParameterValue("CALLE", calle)
        '                rpd.SetParameterValue("ANIO", anio)
        '                ViewReport()
        '                c.Close()
        '            End If
        '        Case 1
        '            If c.Connect Then
        '                clsCrystalConnect.Conectar(rpd)
        '                rpd.ParameterFields("@IDJAS").CurrentValues.Clear()
        '                rpd.ParameterFields("@IDCALLE").CurrentValues.Clear()
        '                rpd.ParameterFields("@IDANIO").CurrentValues.Clear()
        '                rpd.ParameterFields("JAS").CurrentValues.Clear()
        '                rpd.ParameterFields("CALLE").CurrentValues.Clear()
        '                rpd.ParameterFields("ANIO").CurrentValues.Clear()

        '                rpd.SetParameterValue("@IDJAS", cJunta)
        '                rpd.SetParameterValue("@IDCALLE", idcalle)
        '                rpd.SetParameterValue("@IDANIO", idanio)
        '                rpd.SetParameterValue("JAS", txtJunta)
        '                rpd.SetParameterValue("CALLE", calle)
        '                rpd.SetParameterValue("ANIO", anio)

        '                ViewReport()
        '                c.Close()
        '            End If
        '        Case 2

        '    End Select
        'Catch ex As Exception
        'End Try
    End Sub

    Private Sub cmbCalles_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCalles.SelectedIndexChanged
        Try

            idcalle = cmbCalles.SelectedValue
            If idcalle = 0 Then
                idcalle = "%"
            Else
                idcalle = idcalle
            End If
            calle = cmbCalles.Text
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmbAños_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAños.SelectedIndexChanged
        Try

            idanio = cmbAños.Text
            anio = cmbAños.Text
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmbReporte_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbReporte.SelectedIndexChanged
        optionRPT = cmbReporte.SelectedIndex
        If optionRPT <= 4 Then
            LabelX3.Visible = False
            txtMeses.Visible = False
            LabelX1.Visible = True
            cmbAños.Visible = True
            chkAnio.Visible = True

            'LabelX3.Visible = False

        End If
        If optionRPT = 5 Then
            LabelX3.Visible = True
            txtMeses.Visible = True
            LabelX1.Visible = False
            cmbAños.Visible = True
            chkAnio.Visible = False
            txtMeses.Focus()
        End If

    End Sub

    Private Sub chkAnio_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAnio.CheckedChanged
        If chkAnio.Checked = True Then
            anio = cmbAños.Text
            idanio = cmbAños.Text
        Else
            anio = "TODOS"
            idanio = "%"
        End If

    End Sub

    Private Sub LabelX4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LabelX4.Click

    End Sub

    Private Sub ExpandablePanel1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExpandablePanel1.Click

    End Sub

    Private Sub Bar2_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bar2.ItemClick

    End Sub

    Private Sub cmbCPoblado_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCPoblado.SelectedIndexChanged
        Try
            'clsSector.LoadCombo(cmbSector, "Where idCP=" & cmbCPoblado.SelectedValue & "")
            clsCalles.LoadComboCallesPredio(cmbCalles, "where padPredio.idCP= " & cmbCPoblado.SelectedValue & " ")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtMeses_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMeses.TextChanged

    End Sub

    Private Sub cmbTipoDeuda_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipoDeuda.SelectedIndexChanged

    End Sub
End Class