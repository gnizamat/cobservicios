Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports ACCESO
Imports LOGICA
Imports System.IO
Public Class frmRpt_Lecturas
    Private cJunta As String
    Private idcalle As String
    Private idCP As String
    Private idanio As String
    Private imes As Integer
    Private imesant As Integer
    Private txtJunta As String
    Private CP As String
    Private calle As String
    Private jass As String
    Private mes As String
    Private anio As String
    Dim optionRPT As Integer
    Dim rpl As New Rpt_Hid_TomaDatos
    Dim rpVolConsumo As New Rpt_Hid_VolumenesConsumidosPredios
    Dim rpVolConsumoPredio As New tar_Rpt_ConsumoCostoPredio
    Dim rpConttolH As New Rpt_Hid_LecturasEstacion
    Dim rpmedidores As New Rpt_Hid_Medidores_Listado







    Private Sub frmRpt_Lecturas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        Select Case frmPrincipal.userSystem.idInterfaz
            Case 4
                clsJunta.LoadCombo(cmbJunta, " WHERE vIdJuntaUsuario='" & frmPrincipal.userSystem.idJunta & "'", , frmPrincipal.userSystem.idJunta)
                cmbJunta.Enabled = False
        End Select
        'CargaAniosApertura()
        clsCentroPoblado.LoadComboADD(cmbCPoblado)
        cmbCPoblado.SelectedValue = 0

        clsCalles.LoadComboADD(cmbCalles)
        clsAnioTarifa.LoadCombo(cmbAños)
        cJunta = cmbJunta.SelectedValue
        idcalle = cmbCalles.SelectedValue
        idanio = cmbAños.SelectedValue
        clsMes.LoadCombo(cmbMes)
        cmbMes.SelectedIndex = 0
        txtJunta = cmbJunta.Text
        calle = cmbCalles.Text
        cmbReporte.SelectedIndex = 0
        cmbCalles.SelectedIndex = 0
        clsEstructura.LoadCombo(cmbEstructura)
        LabelX3.Visible = False
        cmbEstructura.Visible = False
    End Sub
    Private Delegate Sub ViewReport_Delegate()
    Private Sub ViewReport()
        If Me.InvokeRequired = True Then
            Me.Invoke(New ViewReport_Delegate(AddressOf ViewReport))
        Else
            Select Case optionRPT
                Case 0
                    Me.crViewer.ReportSource = rpl
                    Me.crViewer.Focus()
                Case 1
                    Me.crViewer.ReportSource = rpVolConsumo
                    Me.crViewer.Focus()
                Case 2
                    Me.crViewer.ReportSource = rpVolConsumoPredio
                    Me.crViewer.Focus()
                Case 3
                    Me.crViewer.ReportSource = rpConttolH
                    Me.crViewer.Focus()
                    'rpConttolH
                Case 4
                    Me.crViewer.ReportSource = rpmedidores
                    Me.crViewer.Focus()
            End Select

        End If
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

    Private Sub btnReporte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReporte.Click
        Dim c As New ACCESO.Conexion
        Dim ds As New Reportes
        Dim dt As New DataTable

        idcalle = cmbCalles.SelectedValue
        If idcalle = 0 Then
            idcalle = "%"
        Else
            idcalle = idcalle
        End If
        calle = cmbCalles.Text
        jass = cmbJunta.Text
        mes = cmbMes.Text
        idanio = cmbAños.SelectedValue
        imes = cmbMes.SelectedValue
        imesant = cmbMes.SelectedValue - 1


        Select Case optionRPT
            Case 0
                If c.Connect Then
                    clsCrystalConnect.Conectar(rpl)
                    rpl.ParameterFields("@IDJAS").CurrentValues.Clear()
                    rpl.ParameterFields("@IDCP").CurrentValues.Clear()
                    rpl.ParameterFields("@IDCALLE").CurrentValues.Clear()
                    rpl.ParameterFields("CALLE").CurrentValues.Clear()
                    rpl.ParameterFields("CPOBLADO").CurrentValues.Clear()
                    rpl.ParameterFields("@IDMES").CurrentValues.Clear()
                    rpl.ParameterFields("@IDANIO").CurrentValues.Clear()

                    rpl.SetParameterValue("@IDJAS", cmbJunta.SelectedValue)
                    rpl.SetParameterValue("@IDCP", cmbCPoblado.SelectedValue)
                    rpl.SetParameterValue("@IDCALLE", idcalle)
                    rpl.SetParameterValue("CALLE", calle)
                    rpl.SetParameterValue("CPOBLADO", CP)
                    rpl.SetParameterValue("@IDMES", imes)
                    rpl.SetParameterValue("@IDANIO", idanio)
                    ViewReport()
                    c.Close()
                End If
            Case 1
                If c.Connect Then
                    clsCrystalConnect.Conectar(rpVolConsumo)
                    rpVolConsumo.ParameterFields("@IDJAS").CurrentValues.Clear()
                    rpVolConsumo.ParameterFields("@IDCP").CurrentValues.Clear()
                    rpVolConsumo.ParameterFields("@IDCALLE").CurrentValues.Clear()
                    rpVolConsumo.ParameterFields("JASS").CurrentValues.Clear()
                    rpVolConsumo.ParameterFields("CPOBLADO").CurrentValues.Clear()
                    rpVolConsumo.ParameterFields("@IDMES").CurrentValues.Clear()
                    rpVolConsumo.ParameterFields("@IDANIO").CurrentValues.Clear()

                    rpVolConsumo.SetParameterValue("@IDJAS", cmbJunta.SelectedValue)
                    rpVolConsumo.SetParameterValue("@IDCP", cmbCPoblado.SelectedValue)
                    rpVolConsumo.SetParameterValue("@IDCALLE", idcalle)
                    rpVolConsumo.SetParameterValue("JASS", jass)
                    rpVolConsumo.SetParameterValue("CPOBLADO", CP)
                    rpVolConsumo.SetParameterValue("@IDMES", imes)
                    rpVolConsumo.SetParameterValue("@IDANIO", idanio)
                    ViewReport()
                    c.Close()
                End If
            Case 2
                If c.Connect Then
                    clsCrystalConnect.Conectar(rpVolConsumoPredio)
                    'rpVolConsumo.ParameterFields("@IDJAS").CurrentValues.Clear()
                    rpVolConsumoPredio.ParameterFields("@IDCALLE").CurrentValues.Clear()
                    'rpVolConsumoPredio.ParameterFields("JASS").CurrentValues.Clear()
                    rpVolConsumoPredio.ParameterFields("@IDMESANT").CurrentValues.Clear()
                    rpVolConsumoPredio.ParameterFields("@IDMESACT").CurrentValues.Clear()
                    rpVolConsumoPredio.ParameterFields("MESC").CurrentValues.Clear()
                    rpVolConsumoPredio.ParameterFields("@IDANIO").CurrentValues.Clear()

                    'rpVolConsumo.SetParameterValue("@IDJAS", cmbJunta.SelectedValue)
                    rpVolConsumoPredio.SetParameterValue("@IDCALLE", idcalle)
                    'rpVolConsumoPredio.SetParameterValue("JASS", jass)
                    rpVolConsumoPredio.SetParameterValue("@IDMESANT", imesant)
                    rpVolConsumoPredio.SetParameterValue("@IDMESACT", imes)
                    rpVolConsumoPredio.SetParameterValue("MESC", cmbMes.Text)
                    rpVolConsumoPredio.SetParameterValue("@IDANIO", idanio)
                    ViewReport()
                    c.Close()
                End If
            Case 3
                If c.Connect Then
                    clsCrystalConnect.Conectar(rpConttolH)
                    rpConttolH.ParameterFields("@IDJAS").CurrentValues.Clear()
                    rpConttolH.ParameterFields("@IDEST").CurrentValues.Clear()
                    rpConttolH.ParameterFields("JASS").CurrentValues.Clear()
                    rpConttolH.ParameterFields("MES").CurrentValues.Clear()
                    'rpl.ParameterFields("CALLE").CurrentValues.Clear()
                    rpConttolH.ParameterFields("@IDMES").CurrentValues.Clear()
                    rpConttolH.ParameterFields("@IDANIO").CurrentValues.Clear()

                    rpConttolH.SetParameterValue("@IDJAS", cmbJunta.SelectedValue)
                    rpConttolH.SetParameterValue("JASS", jass)
                    rpConttolH.SetParameterValue("MES", mes)
                    rpConttolH.SetParameterValue("@IDEST", cmbEstructura.SelectedValue)
                    'rpl.SetParameterValue("CALLE", calle)
                    rpConttolH.SetParameterValue("@IDMES", imes)
                    rpConttolH.SetParameterValue("@IDANIO", idanio)
                    ViewReport()
                    c.Close()
                End If

            Case 4
                If c.Connect Then
                    clsCrystalConnect.Conectar(rpmedidores)
                    rpmedidores.ParameterFields("@IDJAS").CurrentValues.Clear()
                    rpmedidores.ParameterFields("@IDCP").CurrentValues.Clear()
                    rpmedidores.ParameterFields("@IDCALLE").CurrentValues.Clear()
                    rpmedidores.ParameterFields("CALLE").CurrentValues.Clear()
                    rpmedidores.ParameterFields("CP").CurrentValues.Clear()


                    rpmedidores.SetParameterValue("@IDJAS", cmbJunta.SelectedValue)
                    rpmedidores.SetParameterValue("@IDCP", cmbCPoblado.SelectedValue)
                    rpmedidores.SetParameterValue("@IDCALLE", idcalle)
                    rpmedidores.SetParameterValue("CALLE", calle)
                    rpmedidores.SetParameterValue("CP", CP)

                    ViewReport()
                    c.Close()
                End If
        End Select

    End Sub

    Private Sub cmbReporte_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbReporte.SelectedIndexChanged
        optionRPT = cmbReporte.SelectedIndex

        If optionRPT <= 2 Then
            LabelX2.Visible = True
            cmbCalles.Visible = True
            LabelX3.Visible = False
            cmbEstructura.Visible = False
        End If
        If optionRPT = 3 Then
            LabelX2.Visible = False
            cmbCalles.Visible = False
            LabelX3.Visible = True
            cmbEstructura.Visible = True

        End If


    End Sub

    Private Sub cmbCPoblado_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCPoblado.SelectedIndexChanged
        Try
            clsCalles.LoadComboCallesPredio(cmbCalles, "where padPredio.idCP= " & cmbCPoblado.SelectedValue & " ")
            idCP = cmbCPoblado.SelectedValue
            If idCP = 0 Then
                idCP = "%"
            Else
                idCP = idCP
            End If
            CP = cmbCPoblado.Text


        Catch ex As Exception

        End Try
    End Sub
End Class