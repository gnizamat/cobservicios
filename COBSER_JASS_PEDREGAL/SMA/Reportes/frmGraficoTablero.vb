Imports LOGICA
Imports System.IO
Public Class frmGraficoTablero
    Dim idjunta As String
    Dim idcomision As Integer
    Dim ds As New Reportes

    Private Sub frmGraficoTablero_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmbMes.SelectedIndex = 0
        Select Case frmPrincipal.userSystem.idInterfaz
            Case 1, 2
                clsJunta.LoadCombo(cmbJunta)
                chkComision.Checked = False
                'chkEntorno.Checked = True
                'chkEntorno.Enabled = True
                'chkEntorno.Visible = True
                cmbComision.Visible = False
            Case 3
                clsJunta.LoadCombo(cmbJunta, " WHERE vIdJuntaUsuario='" & frmPrincipal.userSystem.idJunta & "'", , frmPrincipal.userSystem.idJunta)
                clsComisionRegante.LoadCombo(cmbComision, " where c.vIdJuntaUsuario='" & frmPrincipal.userSystem.idJunta & "'", , )
                chkComision.Checked = False
                cmbComision.Visible = False
                cmbJunta.Enabled = False
                'chkEntorno.Checked = True
                'chkEntorno.Enabled = True
                'chkEntorno.Visible = True
                cmbComision.Focus()
            Case 4
                clsJunta.LoadCombo(cmbJunta, " WHERE vIdJuntaUsuario='" & frmPrincipal.userSystem.idJunta & "'", , frmPrincipal.userSystem.idJunta)
                clsComisionRegante.LoadCombo(cmbComision, " where c.vIdJuntaUsuario='" & frmPrincipal.userSystem.idJunta & "' and c.iIdComisionRegante='" & frmPrincipal.userSystem.idComision & "'", , , frmPrincipal.userSystem.idComision)
                chkComision.Checked = True
                cmbComision.Visible = True
                cmbJunta.Enabled = False
                cmbComision.Enabled = False
                'chkEntorno.Checked = False
                'chkEntorno.Enabled = False
                'chkEntorno.Visible = False
        End Select
        loadAnioApertura()
        
    End Sub
    Sub LoadDataset()
        Dim c As New ACCESO.Conexion
        Dim cadXML As String = ""
        Dim dt As New DataTable
        Dim ini As Integer = 0
        Dim lb As Decimal
        Dim actual As Decimal
        Dim meta As Decimal
        Dim idcapacidad As Integer
        Dim MES As String
        MES = cmbMes.Text.Substring(0, 3)
        If (c.Connect) Then
            dt = c.Query("execute sp_Devuelve_vance_Mes '" & idjunta & "'," & idcomision & "," & cmbAnio.SelectedValue & ",0")
            cadXML = "<?xml version='1.0' encoding='iso-8859-1'?>" & vbCrLf
            cadXML &= "<capacidades>" & vbCrLf
           
            ini = 0
            For i = 0 To 3
                lb = Math.Round(CDec(IIf(dt.Rows(i).Item("LB").ToString = "", 0, dt.Rows(i).Item("LB"))), 2)
                actual = Math.Round(CDec(IIf(dt.Rows(i).Item(MES).ToString = "", 0, dt.Rows(i).Item(MES).ToString)), 2)
                meta = Math.Round(CDec(IIf(dt.Rows(i).Item("META").ToString = "", 0, dt.Rows(i).Item("META"))), 2)
                idcapacidad = dt.Rows(i).Item("IDEST")
                cadXML &= "<capacidad>" & vbCrLf
                cadXML &= "<nombre><![CDATA[" & dt.Rows(i).Item("DESCRIP").ToString & "]]></nombre>" & vbCrLf 'linea base
                cadXML &= "<linea_base>" & lb & "</linea_base>" & vbCrLf 'linea base
                cadXML &= "<avance>" & actual + lb & "</avance>" & vbCrLf 'avance
                cadXML &= "<meta>" & meta & "</meta>" & vbCrLf
                cadXML &= "<idcapacidad>" & idcapacidad & "</idcapacidad>" & vbCrLf
                cadXML &= "</capacidad>" & vbCrLf
                ini += 4
            Next
            cadXML &= "</capacidades>" & vbCrLf

            Dim oSW As New StreamWriter(Application.StartupPath & "/xml/amradar_data.xml")
            oSW.WriteLine(cadXML)
            oSW.Flush()
            oSW.Close()
            c.Close()
        End If
    End Sub
    Sub loadAnioApertura()
        If (cmbJunta.SelectedIndex <> -1) Then
            idjunta = cmbJunta.SelectedValue
            idcomision = IIf(chkComision.Checked, cmbComision.SelectedValue, 0)
            clsAperturaAnio.LoadCombo(cmbAnio, idjunta, idcomision)
            If (cmbAnio.SelectedIndex = -1) Then
                cmbMes.Enabled = False
            Else
                cmbMes.Enabled = True
            End If
        End If   
    End Sub
    Sub LoadGraficoTablero()
        Dim r As New Random()
        swfTablero.Movie = Application.StartupPath & "/swf/TableroComando.swf?r=" & r.Next()
        swfTablero.SetVariable("reload", "true")
        swfTablero.SetVariable("path", Application.StartupPath & "/xml/amradar_data.xml")
    End Sub
    Private Sub cmbJunta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbJunta.SelectedIndexChanged
        Try

            Select Case frmPrincipal.userSystem.idInterfaz
                Case 1, 2, 3
                    clsComisionRegante.LoadCombo(cmbComision, " Where c.vIdJuntaUsuario='" & cmbJunta.SelectedValue & "' ", , True)
                    cmbComision.Enabled = True
                    If cmbComision.Items.Count > 0 Then cmbComision.SelectedIndex = cmbComision.Items.Count - 1

                Case 4
                    clsComisionRegante.LoadCombo(cmbComision, " Where c.vIdJuntaUsuario='" & cmbJunta.SelectedValue & "' and c.iIdComisionRegante='" & frmPrincipal.userSystem.idComision & "'", , False)
                    cmbComision.SelectedIndex = 0
                    cmbComision.Enabled = False
            End Select
            loadAnioApertura()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub chkComision_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkComision.CheckedChanged

        cmbComision.Visible = chkComision.Checked
        loadAnioApertura()
    End Sub

    Private Sub btnViewTablero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewTablero.Click
        If (cmbAnio.SelectedIndex <> -1) Then
            LoadDataset()
            LoadGraficoTablero()
        Else
            MsgBox("Debe seleccionar un año", MsgBoxStyle.Exclamation)
        End If
        
    End Sub

    Private Sub cmbComision_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbComision.SelectedIndexChanged
        Try
            loadAnioApertura()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        btnPrint.Visible = False
        btnViewTablero.Visible = False
        PrintForm1.PrinterSettings.DefaultPageSettings.Landscape = True
        PrintForm1.PrintAction = Printing.PrintAction.PrintToPreview
        PrintForm1.Print()
        btnViewTablero.Visible = True
        btnPrint.Visible = True

    End Sub

    Private Sub swfTablero_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles swfTablero.Enter

    End Sub

    Private Sub swfTablero_FSCommand(ByVal sender As Object, ByVal e As AxShockwaveFlashObjects._IShockwaveFlashEvents_FSCommandEvent) Handles swfTablero.FSCommand
        Select Case e.command
            Case "showReport"
                'MsgBox(e.args(0))
                frmRptIndicadores.idJuntaSelect = cmbJunta.SelectedValue
                frmRptIndicadores.idComisionSelect = IIf(chkComision.Checked, cmbComision.SelectedValue, 0)
                frmRptIndicadores.anioSelect = cmbAnio.SelectedValue
                frmRptIndicadores.idcapacidadSelect = CInt(e.args(0).ToString)
                frmRptIndicadores.mesSelect = cmbMes.SelectedIndex
                frmRptIndicadores.MdiParent = frmPrincipal
                frmRptIndicadores.Show()
                frmRptIndicadores.Focus()

        End Select
    End Sub

    Private Sub cmbAnio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAnio.SelectedIndexChanged

    End Sub
End Class