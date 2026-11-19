Imports LOGICA
Public Class frmJuntaNew
    Dim vf As New clsValidateForm
    Private Function vakidarForm() As Boolean
        Dim flag As Boolean = True
        Dim msg As String = ""
        If (String.Compare(cmbRegion.Text, "") = 0) Then
            flag = False
            msg &= "- No ha seleccionado ninguna región" & vbCrLf
        End If
        If (String.Compare(cmbDisRiego.Text, "") = 0) Then
            flag = False
            msg &= "- No ha seleccionado ninguna Distrito de Riego" & vbCrLf
        End If
        If (Trim(txtNombre.Text).Length <= 0) Then
            msg &= "- Nombre es un campo obligatorio" & vbCrLf
            flag = False
        End If
        If (flag = False) Then
            MsgBox(msg)
        End If
        Return flag
    End Function
    Sub Formclear()
        cmbRegion.ResetText()
        cmbDisRiego.ResetText()
        txtNombre.ResetText()
        cmbRegion.Focus()
    End Sub
    Private Sub frmJuntaNew_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        vf.addTextbox(txtNombre, "string", False)
        vf.addCombobox(cmbDisRiego, "string", False)
        vf.addCombobox(cmbRegion, "string", False)
        vf.resetForm()
        clsValidateForm.LimpiarControles(Me.GroupPanel1)
        clsRegion.LoadCombo(cmbRegion)

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If (vf.startValidation) Then

            Dim j As New clsJunta(cmbRegion.SelectedValue, cmbDisRiego.SelectedValue, txtNombre.Text)
            Dim c As New ACCESO.Conexion
            Dim tn As TreeNode
            j.Insert()
            Dim m = MessageBox.Show("Informacion registrada satisfactroriamente." & vbCrLf & "Desea registrar otro registro?", "SIRIG", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            With frmJuntas

                tn = New TreeNode(txtNombre.Text)
                tn.Tag = "J-" & j.id
                tn.Name = "J-" & j.id
                .tvJuntas.Nodes.Add(tn)

            End With
            Formclear()
            If (m = Windows.Forms.DialogResult.No) Then
                Me.Close()
            End If
        Else
            MsgBox("Información invalida o incompleta", MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Formclear()
        Me.Close()
    End Sub

    Private Sub cmbDisRiego_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbDisRiego.GotFocus
        clsDistritoRiego.LoadCombo(cmbDisRiego, " where iIdRegion='" & cmbRegion.SelectedValue & "'")
    End Sub

    Private Sub cmbDisRiego_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub cmbRegion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbRegion.SelectedIndexChanged
        cmbDisRiego.SelectedIndex = -1
    End Sub
End Class