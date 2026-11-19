Imports ACCESO.Conexion
Imports System.Xml
Public Class frmConexion
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim c As New ACCESO.Conexion
        c.AddParams(cmbServer.Text, txtUsuario.Text, txtPassword.Text, cmbBD.Text, cmbGrupo.SelectedValue)
        c.SaveConnection()
        Dim m = MessageBox.Show("Los datos de configuración se grabaron satisfactoriamente." & vbLf & "Debera reiniciar la aplicacion para que los cambios hagan efecto" & vbCrLf & "Desea Reiniciar la aplicación?", "SMA", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If (m = Windows.Forms.DialogResult.Yes) Then
            Application.Restart()
        End If
        Me.Close()

    End Sub

    Private Sub frmConexion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim c As New ACCESO.Conexion
        c.LoadConnection()
        'ACCESO.Conexion.LoadComboServer(cmbServer)
        ACCESO.Conexion.LoadCombo(cmbGrupo)
        'ACCESO.Conexion.LoadComboBD(cmbBD, cmbServer.Text, txtUsuario.Text, txtPassword.Text)
        cmbGrupo.SelectedValue = c.idGrupo
        cmbServer.Text = c.server
        cmbBD.Text = c.database
        txtUsuario.Text = c.user
        txtPassword.Text = c.password

    End Sub

    Private Sub cmbBD_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbBD.DropDown
        ACCESO.Conexion.LoadComboBD(cmbBD, cmbServer.Text, txtUsuario.Text, txtPassword.Text)
    End Sub

    Private Sub cmbServer_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbServer.DropDown
        ACCESO.Conexion.LoadComboServer(cmbServer)
    End Sub

    Private Sub cmbServer_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbServer.SelectedIndexChanged

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnTester_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTester.Click
        ACCESO.Conexion.TesterConnection(cmbServer.Text, txtUsuario.Text, txtPassword.Text, cmbBD.Text)
    End Sub
End Class