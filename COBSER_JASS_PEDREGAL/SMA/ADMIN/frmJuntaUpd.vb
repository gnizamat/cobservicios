Imports LOGICA
Imports ACCESO
Public Class frmJuntaUpd
    Dim id As String
    Dim j As New clsJunta
    Dim vf As New clsValidateForm
    Private Sub frmJuntaUpd_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        vf.addCombobox(cmbRegion, "string", False)
        vf.addCombobox(cmbDisRiego, "string", False)
        vf.addTextbox(txtNombre, "string", False)
        vf.resetForm()
        clsValidateForm.LimpiarControles(Me.GroupBox1)
        Try

            Dim c As New Conexion
            Dim idj As String = ""
            clsRegion.LoadCombo(cmbRegion)
            clsDistritoRiego.LoadCombo(cmbDisRiego)
            Dim cad = frmJuntas.tvJuntas.SelectedNode.Tag
            If (cad.Length >= 3) Then
                idj = cad.Substring(0, 2)
            End If
            If (String.Compare("J-", idj) = 0) Then
                id = cad.Substring(2)
            End If
            j = clsJunta.LoadJunta(id)
            cmbRegion.SelectedValue = j.idRegion
            cmbDisRiego.SelectedValue = j.idDisRiego
            txtNombre.Text = j.nombre
        Catch ex As Exception
            MsgBox("error: " & ex.Message)
        End Try

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If (vf.startValidation) Then
            Dim j As New clsJunta(cmbRegion.SelectedValue, cmbDisRiego.SelectedValue, txtNombre.Text)
            j.id = id
            j.Update()
            frmJuntas.tvJuntas.Nodes.Clear()
            clsJunta.GeneraTree(frmJuntas.tvJuntas)
            Me.Close()
        Else
            MsgBox("Información invalida o incompleta", MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnCleaner_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCleaner.Click
        cmbDisRiego.ResetText()
        cmbRegion.ResetText()
        txtNombre.ResetText()
    End Sub
End Class