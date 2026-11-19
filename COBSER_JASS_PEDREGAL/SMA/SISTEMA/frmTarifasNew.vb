Imports ACCESO
Imports LOGICA
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Data.OleDb
Public Class frmTarifasNew
    Dim idjunta As String


    Private Sub frmTarifasNew_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        clsTarias.LoadComboModalidad(cmbModalidad)
        clsTarias.LoadComboUnidadRecaudacion(cmbUnidad)
        idjunta = frmTarifasAnios.cmbJunta1.SelectedValue

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Dim u As New clsTarias()
        u.Insert(txtAnio.Text, idjunta, 1, 1, txtNombreAnio.Text)
        u.update_tarifa(txtAnio.Text)
        frmTarifasAnios.dgTarifas.DataSource = clsTarias.List
    End Sub

    Private Sub cmbModalidad_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbModalidad.SelectedIndexChanged

    End Sub
End Class