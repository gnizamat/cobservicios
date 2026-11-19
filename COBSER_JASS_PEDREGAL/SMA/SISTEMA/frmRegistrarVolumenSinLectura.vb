Imports ACCESO
Imports LOGICA
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Data.OleDb
Public Class frmRegistrarVolumenSinLectura
    Dim tv As New DevComponents.AdvTree.AdvTree
    Dim vf As New clsValidateForm
    Dim n As TreeNode
    Dim idcalle As Integer
    Dim calle As String
    Private Sub frmRegistrarVolumenSinLectura_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            clsJunta.LoadCombo(cmbJunta)
            If (frmPrincipal.userSystem.idInterfaz = 4) Then
                cmbJunta.SelectedValue = frmPrincipal.userSystem.idJunta
                cmbJunta.Enabled = False
            End If
            clsCalles.LoadComboADD(cmbCalles)
            'clsAnioTarifa.LoadCombo(cmbAnio)
            clsAnioTarifa.LoadComboAnioVigente(cmbAnio)
            cmbAnio.SelectedIndex = 0
            clsMes.LoadCombo(cmbMes)
            cmbMes.SelectedValue = 1
            clsTipoTarifa.LoadComboFijos(cmbServicios, cmbAnio.Text)
            cmbServicios.SelectedIndex = 0
            cmbCalles.SelectedValue = 1

            'CargaLista()

        Catch ex As Exception

        End Try
    End Sub
    Private Sub CargaLista()
        Dim obj As New clsLecturas
        Dim idservicio As Integer
        Dim anio As String
        Dim idmes As Integer
        anio = cmbAnio.Text
        idmes = cmbMes.SelectedValue
        idservicio = 9


        obj.ListTree(tvPredios, cmbCalles.SelectedValue, cmbMes.SelectedValue, cmbAnio.SelectedValue, idservicio)
        tvPredios.Focus()
        'For Each N As DevComponents.AdvTree.Node In tvPredios.Nodes
        '    obj.anio = N.Cells(7).Text.ToString
        '    obj.Mes = N.Cells(9).Text.ToString

        'Next

    End Sub
    Private Sub btnFiltrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFiltrar.Click
        CargaLista()
    End Sub

    Private Sub btnGeneraDeudas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGeneraDeudas.Click

    End Sub

    Private Sub cmbServicios_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbServicios.SelectedIndexChanged
        txtValorSubTarifa.Text = cmbServicios.SelectedItem(3).ToString
    End Sub
End Class