Imports LOGICA
Imports System.IO
Public Class frmExportar
    Dim ds As New SMA_DATADataSet
    Dim cCe As New ACCESO.ConexionSqlCe
    Dim idjunta As String
    Dim idcomision As Integer
    Dim anio As Integer
    Dim vf As New clsValidateForm
    Private Sub CheckBoxX1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkApertura.CheckedChanged
        vf.addTextbox(txtUbicacion, "string", False)

    End Sub

    Private Sub btnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportar.Click
        If (vf.startValidation) Then
            If (Not File.Exists(sfd.FileName)) Then
                cCe.CreateFile(txtUbicacion.Text)
            Else

                If (Not chkAddData.Checked) Then
                    File.Delete(txtUbicacion.Text)
                    cCe.CreateFile(txtUbicacion.Text)
                Else
                    cCe.path = sfd.FileName
                End If
            End If
            anio = cmbAnio.SelectedValue
            pgb.visible = True
            bgw.RunWorkerAsync()
            MsgBox("Se realizó la exportación satisfactoriamente", MsgBoxStyle.Information, Me.Text)
        Else
            MsgBox("Seleccione la ruta de exportación", MsgBoxStyle.Exclamation, Me.Text)
        End If
        

    End Sub

    Private Sub TextBoxX1_ButtonCustomClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUbicacion.ButtonCustomClick

        Dim dtFecha As DateTime = DateTime.Now
        sfd.InitialDirectory = Application.StartupPath & "\exports\"
        sfd.Filter = "(*.sdf)|*.sdf"
        sfd.FileName = "SMA " & dtFecha.ToString("dd-MM-yyyy") & ".sdf"
        sfd.ShowDialog()

    End Sub

    Private Sub sfd_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles sfd.FileOk
        txtUbicacion.Text = sfd.FileName

    End Sub


    Private Sub frmExportar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pgb.Visible = False
        Select Case frmPrincipal.userSystem.idInterfaz
            Case 1, 2
                clsJunta.LoadCombo(cmbJunta)
                chkComision.Checked = False
                'chkEntorno.Checked = True
                'chkEntorno.Enabled = True
                'chkEntorno.Visible = True
            Case 3
                clsJunta.LoadCombo(cmbJunta, " WHERE vIdJuntaUsuario='" & frmPrincipal.userSystem.idJunta & "'", , frmPrincipal.userSystem.idJunta)
                cmbJunta.Enabled = False
                chkComision.Checked = False
                'chkEntorno.Checked = True
                'chkEntorno.Enabled = True
                'chkEntorno.Visible = True
                'cmbComision.Focus()
            Case 4
                clsJunta.LoadCombo(cmbJunta, " WHERE vIdJuntaUsuario='" & frmPrincipal.userSystem.idJunta & "'", , frmPrincipal.userSystem.idJunta)
                clsComisionRegante.LoadCombo(cmbComision, " where c.vIdJuntaUsuario='" & frmPrincipal.userSystem.idJunta & "' and c.iIdComisionRegante='" & frmPrincipal.userSystem.idComision & "'", , False, frmPrincipal.userSystem.idComision)
                cmbJunta.Enabled = False
                cmbComision.Enabled = False
                chkComision.Checked = True
                chkComision.Enabled = False

                'chkEntorno.Checked = False
                'chkEntorno.Enabled = False
                'chkEntorno.Visible = False
        End Select
        cmbComision.Visible = chkComision.Checked
        loadAnioApertura()
    End Sub
    Private Sub cmbJunta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbJunta.SelectedIndexChanged
        Try

            Select Case frmPrincipal.userSystem.idInterfaz
                Case 1, 2, 3
                    clsComisionRegante.LoadCombo(cmbComision, " Where c.vIdJuntaUsuario='" & cmbJunta.SelectedValue & "' ", , False)
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
    Sub loadAnioApertura()
        If (cmbJunta.SelectedIndex <> -1) Then
            idjunta = cmbJunta.SelectedValue
            idcomision = IIf(chkComision.Checked, cmbComision.SelectedValue, 0)
            clsAperturaAnio.LoadCombo(cmbAnio, idjunta, idcomision)
           
        End If
    End Sub

    Private Sub chkComision_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkComision.CheckedChanged
        Try
            cmbComision.Visible = chkComision.Checked
            loadAnioApertura()
        Catch ex As Exception

        End Try
        
    End Sub

    Private Sub cmbComision_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbComision.SelectedIndexChanged
        Try
            loadAnioApertura()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub bgw_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgw.DoWork
        Dim c As New ACCESO.Conexion

        Dim dt As New DataTable

        If (c.Connect) Then
            If (cCe.Connect) Then
                If (chkApertura.Checked) Then
                    dt = c.Query("select * from AperturaAnio where iAnio=" & anio & " and vIdJuntaUsuario='" & idjunta & "' and iIdComisionRegante='" & idcomision & "'")
                    cCe.BulkCopy(dt, "AperturaAnio")
                End If
                If (chkEstructura.Checked) Then
                    dt = c.Query("select * from EstructuraSMA where iAnio=" & anio & " and vIdJuntaUsuario='" & idjunta & "' and iIdComisionRegante='" & idcomision & "'")
                    cCe.BulkCopy(dt, "EstructuraSMA")
                End If
                If (chkProgEjec.Checked) Then
                    dt = c.Query("select * from ProgramacionEjecucion where iAnio=" & anio & " and vIdJuntaUsuario='" & idjunta & "' and iIdComisionRegante='" & idcomision & "'")
                    cCe.BulkCopy(dt, "ProgramacionEjecucion")
                End If
                If (chkActividadFinanciera.Checked) Then
                    dt = c.Query("select * from CalculoActividades where iAnio=" & anio & " and vIdJuntaUsuario='" & idjunta & "' and iIdComisionRegante='" & idcomision & "'")
                    cCe.BulkCopy(dt, "CalculoActividades")
                End If
                'If (chkActividadFinanciera.Checked) Then
                '    dt = c.Query("select * from CalculoActividadFinanciera where iAnio=" & anio & " and vIdJuntaUsuario='" & idjunta & "' and iIdComisionRegante='" & idcomision & "'")
                '    cCe.BulkCopy(dt, "CalculoActividadFinanciera")
                'End If
                If (chkResponsable.Checked) Then
                    dt = c.Query("select * from Responsable where vIdJuntaUsuario='" & idjunta & "' and iIdComisionRegante='" & idcomision & "'")
                    cCe.BulkCopy(dt, "Responsable")
                    dt = c.Query("select * from ResponsableIndicador where vIdJuntaUsuario='" & idjunta & "' and iIdComisionRegante='" & idcomision & "'")
                    cCe.BulkCopy(dt, "ResponsableIndicador")
                End If
            End If
            cCe.Close()
            c.Close()
        End If
    End Sub

    Private Sub bgw_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgw.RunWorkerCompleted
        pgb.Visible = False
        'MsgBox("Información exportada satisfactoriamente")
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub
End Class