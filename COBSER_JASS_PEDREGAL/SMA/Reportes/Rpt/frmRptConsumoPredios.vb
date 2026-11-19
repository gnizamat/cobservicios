Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports ACCESO
Imports LOGICA
Imports System.IO
Public Class frmRptConsumoPredios
    Public rpt As New CrystalDecisions.CrystalReports.Engine.ReportDocument
    Public idmesant As Integer
    Public idmesact As Integer
    Public idpredio As Integer
    Public idanio As String
    Public idcalle As Integer
    Public mesc As String
    Public montop As String
    Public costom As Double


    Dim rpi As New tar_Rpt_ConsumoPredio

    Private Sub frmRptConsumoPredios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim c As New ACCESO.Conexion
        Dim ds As New Reportes
        Dim dt As New DataTable
        If c.Connect Then

            clsCrystalConnect.Conectar(rpi)
            'rpi.ParameterFields("@RECIBO").CurrentValues.Clear()
            'rpi.SetParameterValue("@RECIBO", Nrorecibo)
            View()
            'ViewReport()
            c.Close()

        End If

    End Sub
    Sub View()

        Dim prdoDocumento As New System.Drawing.Printing.PrintDocument
        Dim page As New System.Drawing.Printing.PaperSize("RECIBO_COBSER", 15, 21)
        Dim imp As New System.Drawing.Printing.PrinterSettings
        prdoDocumento.PrinterSettings = imp
        prdoDocumento.PrinterSettings.Copies = 2
        prdoDocumento.DefaultPageSettings.PaperSize = page
        'frmCobranzaNew.Anio = ranio
        For i = 0 To prdoDocumento.PrinterSettings.PaperSizes.Count - 1
            If prdoDocumento.PrinterSettings.PaperSizes.Item(i).PaperName = "RECIBO_COBSER" Then
                page = prdoDocumento.PrinterSettings.PaperSizes.Item(i)

            End If
        Next
        rpi.PrintOptions.PaperSize = CType(page.RawKind, CrystalDecisions.Shared.PaperSize)
        rpi.ParameterFields("@IDMESANT").CurrentValues.Clear()
        rpi.ParameterFields("@IDMESACT").CurrentValues.Clear()
        rpi.ParameterFields("@IDPREDIO").CurrentValues.Clear()
        rpi.ParameterFields("@IDANIO").CurrentValues.Clear()
        rpi.ParameterFields("@IDCALLE").CurrentValues.Clear()
        rpi.ParameterFields("MESC").CurrentValues.Clear()
        rpi.ParameterFields("MONTOP").CurrentValues.Clear()
        rpi.ParameterFields("COSTOM3").CurrentValues.Clear()

        rpi.SetParameterValue("@IDMESANT", idmesant)
        rpi.SetParameterValue("@IDMESACT", idmesact)
        rpi.SetParameterValue("@IDPREDIO", idpredio)
        rpi.SetParameterValue("@IDANIO", idanio)
        rpi.SetParameterValue("@IDCALLE", idcalle)
        rpi.SetParameterValue("MESC", mesc)
        rpi.SetParameterValue("MONTOP", montop)
        rpi.SetParameterValue("COSTOM3", costom)

        Me.crViewer.ReportSource = rpi
        'rpi.PrintToPrinter(2, False, 1, 1)
        Me.crViewer.Focus()
       
    End Sub
End Class