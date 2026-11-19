Imports System.IO
Imports ACCESO
Imports LOGICA
Public Class frmImportar
    Dim vf As New clsValidateForm
    Dim ce As New ConexionSqlCe
    Private Sub frmImportar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        vf.addTextbox(txtUbicacion, "string", False)
        pgb.Visible = False
        btnImportar.Enabled = True
        btnSalir.Enabled = True
    End Sub
    Private Sub txtUbicacion_ButtonCustomClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUbicacion.ButtonCustomClick
        opdImportar.InitialDirectory = Application.StartupPath & "\exports\"
        opdImportar.Filter = "(*.sdf)|*.sdf"
        'opdImportar.FileName = "PadronUsuarioPredio"
        opdImportar.ShowDialog()
        txtUbicacion.Text = opdImportar.FileName
    End Sub

    Private Sub btnImportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImportar.Click
        If (vf.startValidation) Then

            pgb.Visible = True
            btnImportar.Enabled = False
            btnSalir.Enabled = False
            bgw.RunWorkerAsync()
        End If
    End Sub

    Private Sub opdImportar_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles opdImportar.FileOk
        txtUbicacion.Text = opdImportar.FileName
        ce.path = txtUbicacion.Text
    End Sub

    Private Sub bgw_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgw.DoWork
        Dim c As New ACCESO.Conexion

        If (c.Connect) Then         
            If (ce.Connect) Then
                c.IniTransaction()
                c.EnableIntegridad(0)
                Dim tablas() As String = {"AperturaAnio", "EstructuraSMA", "ProgramacionEjecucion", "EjecucionRubros", "RubroMes", "CalculoActividades", "Responsable", "ResponsableIndicador"}
                c.ImportData(ce, tablas)
                'c.SyncData(ce, "scope_transferencia", tablas, tablas)

                c.EnableIntegridad(1)
                If (Not c.myError) Then
                    c.Commit()
                    MsgBox("Información Importada Satisfactoriamente", MsgBoxStyle.Information)
                Else
                    c.RollBack()
                    MsgBox("Ocurrio un error mientras se impotaban los datos. Se cancelo el proceso de Importación", MsgBoxStyle.Critical)
                End If


                ce.Close()
            End If
            c.Close()
        End If
    End Sub

    Private Sub bgw_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgw.RunWorkerCompleted
        pgb.Visible = False
        btnImportar.Enabled = True
        btnSalir.Enabled = True

    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
End Class