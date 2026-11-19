Imports ACCESO
Imports LOGICA
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Data.OleDb
Public Class frmGenerarInteres
    Dim tv As New DevComponents.AdvTree.AdvTree
    Dim vf As New clsValidateForm
    Dim n As TreeNode
    Dim idcalle As Integer
    Dim calle As String
    Public Monto As Double

    Private Sub frmGenerarInteres_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            clsJunta.LoadCombo(cmbJunta)
            If (frmPrincipal.userSystem.idInterfaz = 4) Then
                cmbJunta.SelectedValue = frmPrincipal.userSystem.idJunta
                cmbJunta.Enabled = False
            End If
            clsCentroPoblado.LoadComboADD(cmbCPoblado)
            cmbCPoblado.SelectedValue = 0

            clsCalles.LoadComboADD(cmbCalles)
            cmbCalles.SelectedValue = 1

            clsAnioTarifa.LoadCombo(cmbAnio)
            cmbAnio.SelectedIndex = 0
            clsMes.LoadCombo(cmbMes)
            cmbMes.SelectedValue = 1
            MontoMora()
            'cmbSubTipoTarifa.SelectedIndex = 0
            txtMontoMora.Text = FormatCurrency(Monto, 2)
            'clsTipoTarifa.LoadComboFijos(cmbSubTipoTarifa, cmbAnio.Text)
            'CargaGrid()
        Catch ex As Exception

        End Try
    End Sub

    Private Function MontoMora()
        Dim c As New ACCESO.Conexion
        Dim dt As New DataTable

        If (c.Connect) Then
            dt = c.Query("select * from tarConfiguracionInteres where cEstado=1")
            Monto = Format(dt.Rows(0).Item(4).ToString, 2)
            c.Close()
        End If
        Return monto
    End Function

    Private Sub btnFiltrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFiltrar.Click
        CargaLista()


    End Sub
    Private Sub CargaLista()
        Dim obj As New clsInteres

        obj.ListTree(tvPredios, cmbCalles.SelectedValue, cmbMes.SelectedValue, cmbAnio.SelectedValue, txtMontoMora.Text)
        tvPredios.Focus()

        lblRegistrosCobranza.Text = String.Format("{0} registros encontrados", tvPredios.Nodes.Count)
    End Sub

    Private Sub btnGeneraDeudas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGeneraDeudas.Click
        Dim codpredio As Integer
        Dim idmes As Integer
        'Dim numerror As String

        Dim cmd As New SqlCommand()
        Dim c As New ACCESO.Conexion
        For Each nodo As DevComponents.AdvTree.Node In tvPredios.Nodes
            If (nodo.Checked) Then
                If (c.Connect) Then
                    codpredio = nodo.Cells(3).Text.ToString
                    idmes = nodo.Cells(4).Text.ToString
                    cmd.CommandText = ("update tarDetalleDeudaPredio set fInteres= " & Monto & " where idpredio=" & codpredio & " and idMes = " & idmes & "")
                    'cmd.CommandText = ("update tarFacturacion set fInteres= " & Monto & " where idpredio=" & codpredio & "")
                    c.Update(cmd)
                    'c.Close()
                    'numerror = numerror

                    If (c.msgError.CompareTo("") <> 0) Then
                        MsgBox(c.msgError)
                    End If
                    
                End If

            End If
        Next
        c.Close()
        CargaLista()

        'If numerror.Length > 0 Then
        'MsgBox("Ocurrio un error mientras se generaba la deuda. Se cancelo el proceso de Importación" & Chr(13) & numerror, MsgBoxStyle.Critical)
        'Else
        MsgBox("Deuda generada satisfactoriamente", MsgBoxStyle.Information)
        'End If
    End Sub

    Private Sub chkSelectAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSelectAll.CheckedChanged
        For Each n1 As DevComponents.AdvTree.Node In tvPredios.Nodes
            If (n1.Enabled) Then
                n1.Checked = chkSelectAll.Checked
            End If
        Next
    End Sub
End Class