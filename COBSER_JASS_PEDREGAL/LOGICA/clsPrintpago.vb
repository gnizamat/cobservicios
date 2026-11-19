Imports ACCESO
Imports LOGICA
Imports System.Data.SqlClient
Imports System.Windows.Forms

Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class clsPrintpago
    Dim rp As clsPago
    Sub Print1(ByVal impresora As String, Optional ByVal nroCopias As Integer = 1)
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

    End Sub

    Sub Print(ByVal impresora As String, Optional ByVal nroCopias As Integer = 1)
        Dim imp As New System.Drawing.Printing.PrinterSettings
        Dim prdoDocumento As New System.Drawing.Printing.PrintDocument
        Dim page As New System.Drawing.Printing.PaperSize("unico", 21, 15)
        imp.PrinterName = impresora
        prdoDocumento.PrinterSettings = imp
        prdoDocumento.DefaultPageSettings.PaperSize = page
        For i = 0 To prdoDocumento.PrinterSettings.PaperSizes.Count - 1
            If prdoDocumento.PrinterSettings.PaperSizes.Item(i).PaperName = "RECIBO_UNICO_SIGMA" Then
                page = prdoDocumento.PrinterSettings.PaperSizes.Item(i)

            End If

        Next
        'rp.PrintOptions.PaperSize = CType(page.RawKind, CrystalDecisions.Shared.PaperSize)
        'rp.SetDataSource(ds)
        'rp.PrintToPrinter(nroCopias, False, 1, 1)

    End Sub
    Sub View()
        'Dim frm As New frmRecibos
        Dim prdoDocumento As New System.Drawing.Printing.PrintDocument
        Dim page As New System.Drawing.Printing.PaperSize("RECIBO_UNICO_SIGMA", 21, 15)
        Dim imp As New System.Drawing.Printing.PrinterSettings

        prdoDocumento.DefaultPageSettings.PaperSize = page
        For i = 0 To prdoDocumento.PrinterSettings.PaperSizes.Count - 1
            If prdoDocumento.PrinterSettings.PaperSizes.Item(i).PaperName = "RECIBO_UNICO_SIGMA" Then
                page = prdoDocumento.PrinterSettings.PaperSizes.Item(i)

            End If

        Next
        'rp.PrintOptions.PaperSize = CType(page.RawKind, CrystalDecisions.Shared.PaperSize)
        'rp.SetDataSource(ds)
        'frm.rpt = rp
        'frm.crViewer.ReportSource = rp
        'frm.ShowDialog()
    End Sub
End Class
