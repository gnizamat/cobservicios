Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports ACCESO
Imports LOGICA
Imports System.IO
Public Class frmRpt_TarFacturaciones
    Private ianio As Integer
    Private cJunta As String
    Private idcalle As String
    Private idanio As String
    Private imes As Integer
    Private txtJunta As String
    Private calle As String
    Private anio As String
    Private idcp As String
    Dim optionRPT As Integer
    Dim lrf As New tar_Rpt_ListadoRecibosFacturacion
    Dim rpdRecibosMes As New tar_Rpt_ReciboFacturacionMensual


    Private Sub frmRpt_TarFacturaciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            clsJunta.LoadCombo(cmbJunta)
            If (frmPrincipal.userSystem.idInterfaz = 4) Then
                cmbJunta.SelectedValue = frmPrincipal.userSystem.idJunta
                cmbJunta.Enabled = False
            End If
            clsCalles.LoadComboADD(cmbCalles)
            clsAnioTarifa.LoadCombo(cmbAnio)

            clsMes.LoadCombo(cmbMes)
            cmbReporte.SelectedIndex = 0

            clsCentroPoblado.LoadComboADD(cmbCPoblado)
            cmbCPoblado.SelectedValue = 0

            cmbCalles.SelectedValue = 0
            clsAnioTarifa.LoadCombo(cmbAnio)
            cmbAnio.SelectedIndex = 0
            clsMes.LoadCombo(cmbMes)
            cmbMes.SelectedIndex = 0
            idcalle = cmbCalles.SelectedValue
            idanio = cmbAnio.Text
            imes = cmbMes.SelectedValue
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
                    Me.crViewer.ReportSource = lrf
                    Me.crViewer.Focus()

                Case 1
                    Me.crViewer.ReportSource = rpdRecibosMes
                    Me.crViewer.Focus()
            End Select

        End If
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

        idcp = cmbCPoblado.SelectedValue

        If idcp = 0 Then
            idcp = "%"
        Else
            idcp = idcp

        End If

        idanio = cmbAnio.SelectedValue
        imes = cmbMes.SelectedValue
        Select Case optionRPT
            Case 0
                If c.Connect Then
                    clsCrystalConnect.Conectar(lrf)
                    lrf.ParameterFields("@IDCALLE").CurrentValues.Clear()
                    lrf.ParameterFields("CALLE").CurrentValues.Clear()
                    lrf.ParameterFields("@ANIO").CurrentValues.Clear()
                    lrf.ParameterFields("@MES").CurrentValues.Clear()


                    lrf.SetParameterValue("@IDCALLE", idcalle)
                    lrf.SetParameterValue("CALLE", calle)
                    lrf.SetParameterValue("@ANIO", idanio)
                    lrf.SetParameterValue("@MES", imes)

                    ViewReport()
                    c.Close()
                End If

            Case 1
                If c.Connect Then
                    clsCrystalConnect.Conectar(rpdRecibosMes)
                    rpdRecibosMes.ParameterFields("@RECIBO").CurrentValues.Clear()
                    rpdRecibosMes.ParameterFields("@IDCALLE").CurrentValues.Clear()
                    rpdRecibosMes.ParameterFields("@IDCP").CurrentValues.Clear()
                    rpdRecibosMes.ParameterFields("@ANIO").CurrentValues.Clear()
                    rpdRecibosMes.ParameterFields("@MES").CurrentValues.Clear()

                    rpdRecibosMes.SetParameterValue("@RECIBO", "%")
                    rpdRecibosMes.SetParameterValue("@IDCALLE", idcalle)
                    rpdRecibosMes.SetParameterValue("@IDCP", idcp)
                    rpdRecibosMes.SetParameterValue("@ANIO", idanio)
                    rpdRecibosMes.SetParameterValue("@MES", imes)

                    ViewReport()
                    c.Close()
                End If
        End Select

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

    Private Sub cmbMes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMes.SelectedIndexChanged
        'imes = cmbMes.SelectedValue
    End Sub

    Private Sub ExpandablePanel1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExpandablePanel1.Click

    End Sub

    Private Sub cmbCPoblado_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCPoblado.SelectedIndexChanged
        Try
            'clsSector.LoadCombo(cmbSector, "Where idCP=" & cmbCPoblado.SelectedValue & "")
            clsCalles.LoadComboCallesPredio(cmbCalles, "where padPredio.idCP= " & cmbCPoblado.SelectedValue & " ")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbReporte_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbReporte.SelectedIndexChanged
        optionRPT = cmbReporte.SelectedIndex

    End Sub
End Class