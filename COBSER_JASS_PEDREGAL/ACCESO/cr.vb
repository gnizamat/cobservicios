Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Shared



Public Class cr
    Private Shared loginfo As CrystalDecisions.Shared.ConnectionInfo
    Public Shared exportar_mail As Boolean
    Public Shared rutaRpt As String
    Public Shared stillOpen As Boolean
    Public Shared custTitle As String
    Public Shared formula As String
    Public Shared Paper As String = ""

    Public Shared Sub Connect()
        Dim c As New ACCESO.Conexion
        c.LoadConnection()
        conectar(c.server, c.database, c.user, c.password)
        cr.rutaRpt = c.pathRPT
    End Sub
    Public Shared Sub conectar(ByVal servidor As String, ByVal basedatos As String, ByVal usuario As String, ByVal password As String)
        loginfo = New CrystalDecisions.Shared.ConnectionInfo
        loginfo.ServerName = servidor
        loginfo.DatabaseName = basedatos
        loginfo.UserID = usuario
        loginfo.Password = password

    End Sub
    Public Shared Sub TipoPapel(Optional ByVal f As String = "")
        Paper = f
    End Sub
    Public Shared Sub AddFormula(ByVal f As String)
        formula = f
    End Sub
    Private Shared Function genpar(ByVal ParamArray matriz() As String) As ParameterFields

        Dim c As Long, p1, p2 As String, l As Integer

        Dim parametros As New ParameterFields

        For c = 0 To matriz.Length - 1

            l = InStr(matriz(c), ";")

            If l > 0 Then

                p1 = Mid(matriz(c), 1, l - 1)

                p2 = Mid(matriz(c), l + 1, Len(matriz(c)) - l)

                Dim parametro As New ParameterField

                Dim dVal As New ParameterDiscreteValue

                parametro.ParameterFieldName = p1

                dVal.Value = p2

                parametro.CurrentValues.Add(dVal)

                parametros.Add(parametro)

            End If

        Next

        Return (parametros)

    End Function

    Private Shared Function logonrpt(ByRef reporte As ReportDocument)
        Dim crtableLogoninfos As New TableLogOnInfos
        Dim crtableLogoninfo As New TableLogOnInfo
        Dim crConnectionInfo As New ConnectionInfo
        Dim CrTables As Tables
        Dim CrTable As Table
        crConnectionInfo = loginfo
        CrTables = reporte.Database.Tables
        For Each CrTable In CrTables
            crtableLogoninfo = CrTable.LogOnInfo
            crtableLogoninfo.ConnectionInfo = crConnectionInfo
            CrTable.ApplyLogOnInfo(crtableLogoninfo)
        Next
    End Function

    'Public Overloads Shared Function printrpt(ByRef crviewer As Windows.Forms.CrystalReportViewer, ByVal nombrereporte As String, ByVal ParamArray par() As String)
    '    Dim rpt As New ReportDocument
    '    Try
    '        With crviewer
    '            If par.Length > 0 Then
    '                .ParameterFieldInfo = genpar(par)
    '            End If
    '            If rutaRpt.Trim.Length = 0 Then
    '                rpt.Load(nombrereporte, OpenReportMethod.OpenReportByDefault)
    '            ElseIf Mid(rutaRpt.Trim, rutaRpt.Trim.Length, 1) = "\" Then
    '                rpt.Load(rutaRpt & nombrereporte, OpenReportMethod.OpenReportByDefault)
    '            Else
    '                rpt.Load(rutaRpt & "\" & nombrereporte, OpenReportMethod.OpenReportByDefault)
    '            End If

    '            logonrpt(rpt)

    '            rpt.RecordSelectionFormula = formula
    '            'Configurar aquí cualquier opción de exportación 

    '            Dim opt As New ExportOptions

    '            opt = rpt.ExportOptions

    '            'Configurar aquí cualquier opción de impresión 
    '            If Paper <> "" Then
    '                Dim prn As PrintOptions
    '                Dim I As Integer
    '                Dim prdoDocumento As New System.Drawing.Printing.PrintDocument
    '                Dim page As New System.Drawing.Printing.PaperSize("unico", 21, 15) 'unico 21,15
    '                Dim imp As New System.Drawing.Printing.PrinterSettings
    '                Dim flag As Boolean = False
    '                prn = rpt.PrintOptions

    '                prdoDocumento.DefaultPageSettings.PaperSize = page
    '                For I = 0 To prdoDocumento.PrinterSettings.PaperSizes.Count - 1
    '                    If prdoDocumento.PrinterSettings.PaperSizes.Item(I).PaperName = Paper Then
    '                        page = prdoDocumento.PrinterSettings.PaperSizes.Item(I)
    '                        flag = True
    '                    End If

    '                Next
    '                If (flag) Then
    '                    prn.PrinterName = prdoDocumento.PrinterSettings.PrinterName
    '                    prn.PaperSize = CType(page.RawKind, CrystalDecisions.Shared.PaperSize)
    '                    prn.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait
    '                    .ShowPrintButton = False
    '                End If
    '                Paper = ""

    '            End If
    '            .ShowRefreshButton = False
    '            .ReportSource = rpt


    '        End With
    '    Catch ex As Exception
    '        If rutaRpt.Trim.Length = 0 Then
    '            MsgBox("No se ha configurado adecuadamente la ruta de los reportes", MsgBoxStyle.Exclamation, "SIGMA")
    '        Else
    '            MsgBox(ex.Message)
    '        End If

    '    End Try
    '    Return rpt
    'End Function

    ''Public Overloads Shared Sub printrpt(ByRef crviewer As CrystalDecisions.Windows.Forms.CrystalReportViewer, ByVal nombrereporte As String)

    ''    Dim rpt As New ReportDocument
    ''    Try

    ''        With crviewer

    ''            If rutaRpt.Trim.Length = 0 Then

    ''                rpt.Load(nombrereporte, OpenReportMethod.OpenReportByDefault)

    ''            ElseIf Mid(rutaRpt.Trim, rutaRpt.Trim.Length, 1) = "\" Then

    ''                rpt.Load(rutaRpt & nombrereporte, OpenReportMethod.OpenReportByDefault)

    ''            Else

    ''                rpt.Load(rutaRpt & "\" & nombrereporte, OpenReportMethod.OpenReportByDefault)

    ''            End If

    ''            logonrpt(rpt)

    '            'Configurar aquí cualquier opción de exportación 

    '            Dim opt As New ExportOptions

    '            opt = rpt.ExportOptions

    '            'Configurar aquí cualquier opción de impresión

    '            Dim prn As PrintOptions

    '            prn = rpt.PrintOptions

    '            .ReportSource = rpt



    '        End With
    '    Catch ex As Exception
    '        If rutaRpt.Trim.Length = 0 Then
    '            MsgBox("No se ha configurado adecuadamente la ruta de los reportes", MsgBoxStyle.Exclamation, "SIGMA")
    '        Else
    '            MsgBox(ex.Message)
    '        End If
    '    End Try

    'End Sub


    'Protected Overrides Sub Finalize()
    '    MyBase.Finalize()
    'End Sub
End Class
