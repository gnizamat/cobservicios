Imports LOGICA
Public Class frmComisionNew
    Dim vf As New clsValidateForm
    Sub Formclear()
        txtNombre.ResetText()
        txtNombre.Focus()
    End Sub
    Private Sub frmComisionNew_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtJunta.Text = frmJuntas.tvJuntas.SelectedNode.Text
        vf.addTextbox(txtNombre, "string", False)
        vf.resetForm()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If (vf.startValidation) Then
            Dim idj As String = frmJuntas.tvJuntas.SelectedNode.Tag
            idj = idj.Substring(2)
            Dim cr As New clsComisionRegante(idj, txtNombre.Text)
            cr.Insert()
            frmJuntas.gridComisiones.DataSource = clsComisionRegante.List(" and j.vIdJuntaUsuario='" & idj & "'")
            Dim m = MessageBox.Show("Informacion registrada satisfactroriamente." & vbCrLf & "Desea continuar?", "SIRIG", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            Formclear()
            txtJunta.Text = frmJuntas.tvJuntas.SelectedNode.Text
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


End Class