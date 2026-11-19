Imports ACCESO
Imports LOGICA
Public Class frmSysGrupoNew
    Dim vf As New clsValidateForm
    Sub Formclear()
        txtNombre.ResetText()
        cmbInterfaz.SelectedIndex = -1
        cmbRegion.SelectedIndex = -1
        cmbDistritoRiego.SelectedIndex = -1
        cmbJU.SelectedIndex = -1
        cmbCR.SelectedIndex = -1
        cmbRegion.Enabled = False
        cmbDistritoRiego.Enabled = False
        cmbJU.Enabled = False
        cmbCR.Enabled = False

    End Sub
    Private Sub frmSysGrupoNew_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        vf.addTextbox(txtNombre, "string", False)
        vf.addCombobox(cmbInterfaz, "string", False)
        vf.addCombobox(cmbRegion, "string", True)
        vf.addCombobox(cmbDistritoRiego, "string", True)
        vf.addCombobox(cmbJU, "string", True)
        vf.addCombobox(cmbCR, "string", True)
        vf.resetForm()
        Interfaz.LoadCombo(cmbInterfaz)
        clsRegion.LoadCombo(cmbRegion)
        cmbRegion.Enabled = False
        cmbDistritoRiego.Enabled = False
        cmbJU.Enabled = False
        cmbCR.Enabled = False
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If (vf.startValidation) Then
            Dim region As Integer
            If (cmbRegion.SelectedIndex = -1) Then
                region = 0
            Else
                region = cmbRegion.SelectedValue
            End If

            Dim distrito As Integer
            If (cmbDistritoRiego.SelectedIndex = -1) Then
                distrito = 0
            Else
                distrito = cmbDistritoRiego.SelectedValue
            End If

            Dim junta As String
            If (cmbJU.SelectedIndex = -1) Then
                junta = ""
            Else
                junta = cmbJU.SelectedValue
            End If

            Dim comision As Integer
            If (cmbCR.SelectedIndex = -1) Then
                comision = 0
            Else
                comision = cmbCR.SelectedValue
            End If

            Dim g As New ACCESO.Grupo(txtNombre.Text, cmbInterfaz.SelectedValue, region, distrito, junta, comision)
            g.Insert()
            g.INSERTALL_PERMISOS()
            frmSysGrupos.gridGrupos.DataSource = Grupo.List(" and g.idPGrupo<>'1'")
            Dim m = MessageBox.Show("Informacion registrada satisfactroriamente." & vbCrLf & "Desea continuar?", "SIMIG", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            Formclear()
            If (m = Windows.Forms.DialogResult.No) Then
                Me.Close()
            End If
        Else
            showMessages("formInvalid")

        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnCleaner_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCleaner.Click
        Me.Formclear()
    End Sub
    Private Sub cmbRegion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbRegion.SelectedIndexChanged
        cmbDistritoRiego.SelectedIndex = -1
    End Sub

    Private Sub cmbDistritoRiego_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbDistritoRiego.GotFocus
        clsDistritoRiego.LoadCombo(cmbDistritoRiego, " where iIdRegion='" & cmbRegion.SelectedValue & "'")
    End Sub
    Private Sub cmbJU_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbJU.GotFocus
        clsJunta.LoadCombo(cmbJU, " where iIdDistritoRiego='" & cmbDistritoRiego.SelectedValue & "'")
    End Sub

    
    Private Sub cmbDistritoRiego_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDistritoRiego.SelectedIndexChanged
        cmbJU.SelectedIndex = -1
    End Sub

    Private Sub cmbInterfaz_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbInterfaz.SelectedIndexChanged
        Try

            Select Case cmbInterfaz.SelectedItem(0)
                Case 2
                    vf.item(3).allowblank = True
                    vf.item(4).allowblank = True
                    vf.item(5).allowblank = True
                    vf.item(6).allowblank = True
                    cmbRegion.Enabled = False
                    cmbDistritoRiego.Enabled = False
                    cmbJU.Enabled = False
                    cmbCR.Enabled = False
                    cmbRegion.SelectedIndex = -1
                    cmbDistritoRiego.SelectedIndex = -1
                    cmbJU.SelectedIndex = -1
                    cmbCR.SelectedIndex = -1
                Case 3
                    vf.item(3).allowblank = False
                    vf.item(4).allowblank = False
                    vf.item(5).allowblank = False
                    vf.item(6).allowblank = True
                    cmbRegion.Enabled = True
                    cmbDistritoRiego.Enabled = True
                    cmbJU.Enabled = True
                    cmbCR.Enabled = False
                    cmbCR.SelectedIndex = -1
                Case 4
                    vf.item(3).allowblank = False
                    vf.item(4).allowblank = False
                    vf.item(5).allowblank = False
                    vf.item(6).allowblank = False
                    cmbRegion.Enabled = True
                    cmbDistritoRiego.Enabled = True
                    cmbJU.Enabled = True
                    cmbCR.Enabled = True
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbJU_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbJU.SelectedIndexChanged
        cmbCR.SelectedIndex = -1
    End Sub

    Private Sub cmbCR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCR.GotFocus
        clsComisionRegante.LoadCombo(cmbCR, " where c.vIdJuntaUsuario='" & cmbJU.SelectedValue & "'")
    End Sub

   
End Class