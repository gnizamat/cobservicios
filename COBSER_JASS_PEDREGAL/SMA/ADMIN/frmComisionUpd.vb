Imports LOGICA
Public Class frmComisionUpd
    Dim id As String
    Dim idj As String
    Dim vf As New clsValidateForm
    Sub Formclear()
        txtNombre.ResetText()
        txtNombre.Focus()
    End Sub
    Private Sub frmComisionUpd_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        vf.addTextbox(txtNombre, "string", False)
        With frmJuntas.gridComisiones
            id = .Item(0, .CurrentRow.Index).Value
            txtNombre.Text = .Item(1, .CurrentRow.Index).Value
            idj = .Item(2, .CurrentRow.Index).Value
            txtJunta.Text = .Item(3, .CurrentRow.Index).Value

        End With
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If (vf.startValidation) Then
            Dim c As New clsComisionRegante(idj, txtNombre.Text)
            c.id = id
            c.Update()
            MsgBox("Registrado actualizado satisfactoriamente", MsgBoxStyle.Information)
            frmJuntas.gridComisiones.DataSource = clsComisionRegante.List(" and j.vIdJuntaUsuario='" & idj & "'")
            Formclear()
            Me.Close()
        Else
            MsgBox("Información invalida o incompleta")
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Formclear()
        Me.Close()
    End Sub

    Private Sub btnCleaner_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCleaner.Click
        Formclear()
    End Sub
End Class