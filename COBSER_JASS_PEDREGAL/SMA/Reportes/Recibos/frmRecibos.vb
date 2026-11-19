Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports ACCESO
Imports LOGICA
Imports System.IO

Public Class frmRecibos
    Public rpt As New CrystalDecisions.CrystalReports.Engine.ReportDocument
    Public Nrorecibo As String
    Public TIPO As Integer
    Public ranio As String

    'Dim rp As New tar_Rpt_ReciboPago

    Dim pago As New clsPago
    Dim rpi As New tar_Rpt_ReciboPago
    Dim rpf As New tar_Rpt_ReciboFacturacion
    Dim rpt_ReciboOtros As New tar_Rpt_ReciboOtrosIngresos

    Private Sub ButtonItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem1.Click

        PRINT()
        Me.Close()


        'Dim pd As New PrintDialog()

        'pd.ShowDialog()
        '= DialogResult.OK
        'rpi.PrintToPrinter(pd.PrinterSettings.PrinterName)
        'frmRecibos.ViewReport(rpi.PrinterSettings.PrinterName)
        'rpt.PrintToPrinter(1, False, 1, 1)
        'rpt.PrintToPrinter(pd.PrinterSettings.PrinterName)
        'pago.Print(pd.PrinterSettings.PrinterName)

    End Sub

    Private Sub frmRecibos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim c As New ACCESO.Conexion
        Dim ds As New Reportes
        Dim dt As New DataTable

        'Nrorecibo = 
        If c.Connect Then
            If TIPO = 0 Then
                clsCrystalConnect.Conectar(rpi)
                'rpi.ParameterFields("@RECIBO").CurrentValues.Clear()
                'rpi.SetParameterValue("@RECIBO", Nrorecibo)
                View()
                'ViewReport()
                c.Close()
            End If
            If TIPO = 1 Then
                clsCrystalConnect.Conectar(rpf)
                'rpf.ParameterFields("@RECIBO").CurrentValues.Clear()
                'rpf.SetParameterValue("@RECIBO", Nrorecibo)
                View()
                'ViewReport()
                c.Close()
            End If

            If TIPO = 2 Then
                clsCrystalConnect.Conectar(rpt_ReciboOtros)
                'rpf.ParameterFields("@RECIBO").CurrentValues.Clear()
                'rpf.SetParameterValue("@RECIBO", Nrorecibo)
                View()
                'ViewReport()
                c.Close()
            End If
        End If
    End Sub
    Private Delegate Sub ViewReport_Delegate()

    Private Sub ViewReport()
        If TIPO = 0 Then
            If Me.InvokeRequired = True Then
                Me.Invoke(New ViewReport_Delegate(AddressOf ViewReport))
            Else

                Me.crViewer.ReportSource = rpi
                Me.crViewer.Focus()

            End If
        End If
        If TIPO = 1 Then
            If Me.InvokeRequired = True Then
                Me.Invoke(New ViewReport_Delegate(AddressOf ViewReport))
            Else

                Me.crViewer.ReportSource = rpf
                Me.crViewer.Focus()

            End If
        End If
        If TIPO = 2 Then
            If Me.InvokeRequired = True Then
                Me.Invoke(New ViewReport_Delegate(AddressOf ViewReport))
            Else

                Me.crViewer.ReportSource = rpt_ReciboOtros
                Me.crViewer.Focus()

            End If
        End If
    End Sub

    Private Sub crViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles crViewer.Load

    End Sub
    Sub View()
        If TIPO = 0 Then

            'Dim frm As New frmRecibos
            Dim prdoDocumento As New System.Drawing.Printing.PrintDocument
            Dim page As New System.Drawing.Printing.PaperSize("RECIBO_COBSER", 15, 21)
            Dim imp As New System.Drawing.Printing.PrinterSettings
            prdoDocumento.PrinterSettings = imp
            prdoDocumento.PrinterSettings.Copies = 2
            prdoDocumento.DefaultPageSettings.PaperSize = page
            frmCobranzaNew.Anio = ranio
            For i = 0 To prdoDocumento.PrinterSettings.PaperSizes.Count - 1
                If prdoDocumento.PrinterSettings.PaperSizes.Item(i).PaperName = "RECIBO_COBSER" Then
                    page = prdoDocumento.PrinterSettings.PaperSizes.Item(i)

                End If
            Next
            rpi.PrintOptions.PaperSize = CType(page.RawKind, CrystalDecisions.Shared.PaperSize)
            rpi.ParameterFields("@RECIBO").CurrentValues.Clear()
            rpi.SetParameterValue("@RECIBO", Nrorecibo)
            rpi.SetParameterValue("ANIOV", ranio)
            Me.crViewer.ReportSource = rpi
            'rpi.PrintToPrinter(2, False, 1, 1)
            Me.crViewer.Focus()
        End If

        If TIPO = 1 Then
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
            rpf.PrintOptions.PaperSize = CType(page.RawKind, CrystalDecisions.Shared.PaperSize)
            rpf.ParameterFields("@RECIBO").CurrentValues.Clear()
            rpf.SetParameterValue("@RECIBO", Nrorecibo)
            'rpi.SetParameterValue("ANIOV", ranio)
            Me.crViewer.ReportSource = rpf
            'rpi.PrintToPrinter(2, False, 1, 1)
            Me.crViewer.Focus()
        End If

        If TIPO = 2 Then
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
            rpt_ReciboOtros.PrintOptions.PaperSize = CType(page.RawKind, CrystalDecisions.Shared.PaperSize)
            rpt_ReciboOtros.ParameterFields("@RECIBO").CurrentValues.Clear()
            rpt_ReciboOtros.SetParameterValue("@RECIBO", Nrorecibo)
            'rpi.SetParameterValue("ANIOV", ranio)
            Me.crViewer.ReportSource = rpt_ReciboOtros
            'rpi.PrintToPrinter(2, False, 1, 1)
            Me.crViewer.Focus()
        End If
    End Sub
    Sub PRINT()
        If TIPO = 0 Then

            'Dim frm As New frmRecibos
            Dim prdoDocumento As New System.Drawing.Printing.PrintDocument
            Dim page As New System.Drawing.Printing.PaperSize("RECIBO_COBSER", 15, 21)
            Dim imp As New System.Drawing.Printing.PrinterSettings
            prdoDocumento.PrinterSettings = imp
            prdoDocumento.PrinterSettings.Copies = 2
            prdoDocumento.DefaultPageSettings.PaperSize = page
            For i = 0 To prdoDocumento.PrinterSettings.PaperSizes.Count - 1
                If prdoDocumento.PrinterSettings.PaperSizes.Item(i).PaperName = "RECIBO_COBSER" Then
                    page = prdoDocumento.PrinterSettings.PaperSizes.Item(i)

                End If
            Next
            rpi.PrintOptions.PaperSize = CType(page.RawKind, CrystalDecisions.Shared.PaperSize)
            rpi.ParameterFields("@RECIBO").CurrentValues.Clear()
            rpi.SetParameterValue("@RECIBO", Nrorecibo)
            'rpi.SetDataSource()
            rpi.PrintToPrinter(2, False, 1, 1)

        End If

        'Dim imp As New System.Drawing.Printing.PrinterSettings
        'Dim prdoDocumento As New System.Drawing.Printing.PrintDocument
        'Dim page As New System.Drawing.Printing.PaperSize("unico", 21, 15)
        'imp.PrinterName = impresora
        'prdoDocumento.PrinterSettings = imp
        'prdoDocumento.DefaultPageSettings.PaperSize = page
        'For i = 0 To prdoDocumento.PrinterSettings.PaperSizes.Count - 1
        '    If prdoDocumento.PrinterSettings.PaperSizes.Item(i).PaperName = "RECIBO_UNICO_SIGMA" Then
        '        page = prdoDocumento.PrinterSettings.PaperSizes.Item(i)

        '    End If

        'Next
        'rp.PrintOptions.PaperSize = CType(page.RawKind, CrystalDecisions.Shared.PaperSize)
        'rp.SetDataSource(ds)
        'rp.PrintToPrinter(nroCopias, False, 1, 1)

        If TIPO = 1 Then

            'Dim frm As New frmRecibos
            Dim prdoDocumento As New System.Drawing.Printing.PrintDocument
            Dim page As New System.Drawing.Printing.PaperSize("RECIBO_COBSER", 15, 21)
            Dim imp As New System.Drawing.Printing.PrinterSettings
            prdoDocumento.PrinterSettings = imp
            prdoDocumento.PrinterSettings.Copies = 2
            prdoDocumento.DefaultPageSettings.PaperSize = page
            For i = 0 To prdoDocumento.PrinterSettings.PaperSizes.Count - 1
                If prdoDocumento.PrinterSettings.PaperSizes.Item(i).PaperName = "RECIBO_COBSER" Then
                    page = prdoDocumento.PrinterSettings.PaperSizes.Item(i)

                End If
            Next
            rpf.PrintOptions.PaperSize = CType(page.RawKind, CrystalDecisions.Shared.PaperSize)
            rpf.ParameterFields("@RECIBO").CurrentValues.Clear()
            rpf.SetParameterValue("@RECIBO", Nrorecibo)
            rpf.PrintToPrinter(2, False, 1, 1)

        End If

        If TIPO = 2 Then

            'Dim frm As New frmRecibos
            Dim prdoDocumento As New System.Drawing.Printing.PrintDocument
            Dim page As New System.Drawing.Printing.PaperSize("RECIBO_COBSER", 15, 21)
            Dim imp As New System.Drawing.Printing.PrinterSettings
            prdoDocumento.PrinterSettings = imp
            prdoDocumento.PrinterSettings.Copies = 2
            prdoDocumento.DefaultPageSettings.PaperSize = page
            For i = 0 To prdoDocumento.PrinterSettings.PaperSizes.Count - 1
                If prdoDocumento.PrinterSettings.PaperSizes.Item(i).PaperName = "RECIBO_COBSER" Then
                    page = prdoDocumento.PrinterSettings.PaperSizes.Item(i)

                End If
            Next
            rpt_ReciboOtros.PrintOptions.PaperSize = CType(page.RawKind, CrystalDecisions.Shared.PaperSize)
            rpt_ReciboOtros.ParameterFields("@RECIBO").CurrentValues.Clear()
            rpt_ReciboOtros.SetParameterValue("@RECIBO", Nrorecibo)
            rpt_ReciboOtros.PrintToPrinter(2, False, 1, 1)

        End If

    End Sub
End Class