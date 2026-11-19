Imports System.IO
Imports System.Text
Imports System.Data.SqlClient
Imports LOGICA
Public Class frmBackup
    Dim vf As New clsValidateForm
    Private Sub frmBackup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        vf.resetForm()
        vf.addTextbox(txtDirectorio, "string", False)
        vf.addTextbox(txtBackup, "string ", False)
        txtBackup.Text = "DBSERVICIOS_"

    End Sub

    Private Sub txtDirectorio_ButtonCustomClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDirectorio.ButtonCustomClick
        Dim Directorio As New FolderBrowserDialog

        If Directorio.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtDirectorio.Text = Directorio.SelectedPath
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim c As New ACCESO.Conexion
        If (c.Connect) Then
            Dim oSW As New StreamWriter(txtDirectorio.Text & "/" & txtBackup.Text & ".bak")
            oSW.WriteLine("")
            oSW.Flush()
            oSW.Close()
            If (c.crear_backup(txtDirectorio.Text, txtBackup.Text, txtObservacion.Text)) Then
                MsgBox("Backup creado satisfactoriamente")
            End If
            'If (c.BACKUP_BD(txtDirectorio.Text, txtBackup.Text, txtObservacion.Text)) Then
            '    MsgBox("Backup creado satisfactoriamente")
            'End If
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub ButtonItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem1.Click
        Dim c As New ACCESO.Conexion
        If (c.Connect) Then
            Dim oSW As New StreamWriter(txtDirectorio.Text & "/" & txtBackup.Text & ".bak")
            oSW.WriteLine("")
            oSW.Flush()
            oSW.Close()
            If (c.BACKUP_BD(txtDirectorio.Text, txtBackup.Text, txtObservacion.Text)) Then
                MsgBox("Backup creado satisfactoriamente")
            End If
        End If
    End Sub
End Class