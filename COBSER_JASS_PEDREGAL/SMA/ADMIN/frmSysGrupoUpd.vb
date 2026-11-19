Imports LOGICA
Imports ACCESO
Public Class frmSysGrupoUpd
    Dim vf As New clsValidateForm
    Dim id As Integer
    Private Sub frmSysGrupoUpd_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        id = frmSysGrupos.gridGrupos.Item(0, frmSysGrupos.gridGrupos.CurrentRow.Index).Value
        txtNombre.Text = frmSysGrupos.gridGrupos.Item(2, frmSysGrupos.gridGrupos.CurrentRow.Index).Value
        cmbInterfaz.SelectedValue = frmSysGrupos.gridGrupos.Item(1, frmSysGrupos.gridGrupos.CurrentRow.Index).Value
        cmbRegion.SelectedValue = frmSysGrupos.gridGrupos.Item(5, frmSysGrupos.gridGrupos.CurrentRow.Index).Value
        clsDistritoRiego.LoadCombo(cmbDistritoRiego, " where iIdRegion='" & cmbRegion.SelectedValue & "'")
        cmbDistritoRiego.SelectedValue = frmSysGrupos.gridGrupos.Item(7, frmSysGrupos.gridGrupos.CurrentRow.Index).Value
        clsJunta.LoadCombo(cmbJU, " where iIdDistritoRiego='" & cmbDistritoRiego.SelectedValue & "'")
        cmbJU.SelectedValue = frmSysGrupos.gridGrupos.Item(9, frmSysGrupos.gridGrupos.CurrentRow.Index).Value
        clsComisionRegante.LoadCombo(cmbCR, " where c.vIdJuntaUsuario='" & cmbJU.SelectedValue & "'")
        cmbCR.SelectedValue = frmSysGrupos.gridGrupos.Item(11, frmSysGrupos.gridGrupos.CurrentRow.Index).Value
        txtNombre.Focus()
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
            g.idGrupo = id
            g.Update()
            frmSysGrupos.gridGrupos.DataSource = Grupo.List(" and g.idPGrupo<>'1'")
            MsgBox("Informacion actualizada satisfactroriamente.", MsgBoxStyle.Information)
            clsValidateForm.LimpiarControles(Me.GroupPanel1)
            Me.Close()
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub cmbRegion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbRegion.SelectedIndexChanged
        cmbDistritoRiego.SelectedIndex = -1
        Try
            'clsDistritoRiego.LoadCombo(cmbDistritoRiego, " where iIdRegion='" & cmbRegion.SelectedValue & "'")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbDistritoRiego_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbDistritoRiego.GotFocus
        'clsDistritoRiego.LoadCombo(cmbDistritoRiego, " where iIdRegion='" & cmbRegion.SelectedValue & "'")
    End Sub

    Private Sub cmbDistritoRiego_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDistritoRiego.SelectedIndexChanged
        cmbJU.SelectedIndex = -1
        Try
            clsJunta.LoadCombo(cmbJU, " where iIdDistritoRiego='" & cmbDistritoRiego.SelectedValue & "'")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbJU_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        'clsJunta.LoadCombo(cmbJU, " where iIdDistritoRiego='" & cmbDistritoRiego.SelectedValue & "'")
    End Sub

    Private Sub cmbJU_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbJU.SelectedIndexChanged
        cmbCR.SelectedIndex = -1
        Try
            clsComisionRegante.LoadCombo(cmbCR, " where c.vIdJuntaUsuario='" & cmbJU.SelectedValue & "'")
        Catch ex As Exception

        End Try
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

    Private Sub cmbCR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        'clsComisionRegante.LoadCombo(cmbCR, " where c.vIdJuntaUsuario='" & cmbJU.SelectedValue & "'")
    End Sub

    Private Sub cmbCR_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class