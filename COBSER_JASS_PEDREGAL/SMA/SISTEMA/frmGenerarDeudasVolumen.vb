Imports ACCESO
Imports LOGICA
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Data.OleDb

Public Class frmGenerarDeudasVolumen
    Dim tv As New DevComponents.AdvTree.AdvTree
    Dim vf As New clsValidateForm
    Dim n As TreeNode
    Dim idcalle As Integer
    Dim calle As String
    Private idcp As String
    Private CP As String

    Private Sub frmGenerarDeudasVolumen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            clsJunta.LoadCombo(cmbJunta)
            If (frmPrincipal.userSystem.idInterfaz = 4) Then
                cmbJunta.SelectedValue = frmPrincipal.userSystem.idJunta
                cmbJunta.Enabled = False
            End If
            'clsCalles.LoadComboADD(cmbCalles)
            'clsAnioTarifa.LoadCombo(cmbAnio)

            clsCentroPoblado.LoadComboADD(cmbCPoblado)
            cmbCPoblado.SelectedValue = 0
            clsCalles.LoadComboCallesPredio(cmbCalles)
            cmbCalles.SelectedValue = 1
            idcalle = cmbCalles.SelectedValue

            clsAnioTarifa.LoadComboAnioVigente(cmbAnio)
            cmbAnio.SelectedIndex = 0
            clsMes.LoadCombo(cmbMes)
            cmbMes.SelectedValue = 1
            'clsTipoTarifa.LoadComboFijos(cmbServicios, cmbAnio.Text)
            clsTipoTarifa.LoadComboVolumen(cmbServicios, cmbAnio.Text)
            cmbServicios.SelectedIndex = 0
            cmbCalles.SelectedValue = 1
            cmbTipoServicio.SelectedIndex = 0


            'CargaLista()

        Catch ex As Exception

        End Try
    End Sub
    Private Sub CargaLista()
        Dim obj As New clsDeudasVolumen
        Dim idservicio As Integer
        idservicio = cmbServicios.SelectedValue

        If chkUnicas.Checked = False Then
            obj.ListTreeTodas(tvPredios, cmbCalles.SelectedValue, cmbMes.SelectedValue, cmbAnio.SelectedValue, idservicio)
            tvPredios.Focus()

        End If
        If chkUnicas.Checked = True Then
            obj.ListTree(tvPredios, cmbCalles.SelectedValue, cmbMes.SelectedValue, cmbAnio.SelectedValue, idservicio)
            tvPredios.Focus()
        End If
      


        'Dim obj As New clsDeudasMensuales
        'If chkUnicas.Checked = False Then
        '    obj.ListTree(tvPredios, cmbCalles.SelectedValue, cmbMes.SelectedValue, cmbAnio.SelectedValue, cmbSubTipoTarifa.SelectedValue)
        '    tvPredios.Focus()
        'End If
        'If chkUnicas.Checked = True Then
        '    obj.ListTreeUnicas(tvPredios, cmbCalles.SelectedValue, cmbMes.SelectedValue, cmbAnio.SelectedValue, cmbSubTipoTarifa.SelectedValue)
        '    tvPredios.Focus()
        'End If

    End Sub

    Private Sub cmbCalles_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCalles.SelectedIndexChanged

    End Sub

    Private Sub btnFiltrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFiltrar.Click
        CargaLista()
    End Sub

    Private Sub cmbSubTipoTarifa_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbServicios.SelectedIndexChanged
        txtValorSubTarifa.Text = cmbServicios.SelectedItem(3).ToString
    End Sub

    Private Sub btnGeneraDeudas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGeneraDeudas.Click
        Dim montofac As Double
        Dim montore As Decimal
        Dim redondeo As Decimal


        For Each n As DevComponents.AdvTree.Node In tvPredios.Nodes

            'If (n.Enabled) Then
            'If (n.Checked) Then
            montofac = FormatNumber(Math.Round(Val(txtValorSubTarifa.Text) * Val(n.Cells(9).Text), 2), 2)
            montore = Math.Round(montofac, 1)

            'FormatNumber(Math.Round(Val(txtValorSubTarifa.Text) * Val(n.Cells(9).Text), 1), 1)
            redondeo = Math.Round((montore - montofac), 2)

            n.Cells(10).Text = montofac
            n.Cells(11).Text = redondeo
            n.Cells(12).Text = montore

            'n.Cells(10).Text = Math.Round(Val(txtValorSubTarifa.Text) * Val(n.Cells(9).Text), 2)
            'montofac = Math.Round(Val(n.Cells(10).Text), 2)
            'CalcularVolumenRiegoTiempo(n)

            'End If
            'End If
        Next
    End Sub

    Private Sub ButtonItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem1.Click
        Dim objv As New clsDeudasVolumen
        Dim userSystem As New ACCESO.User
        Dim numerror As String
        numerror = ""
        For Each nodo As DevComponents.AdvTree.Node In tvPredios.Nodes  '     TreeNode   Nodos
            tvPredios.SelectedNode = tvPredios.Nodes(nodo.Index)
            objv.IdJAS = nodo.Cells(3).Text.ToString
            objv.Año = cmbAnio.SelectedValue
            objv.Mes = cmbMes.SelectedValue
            objv.Predio = nodo.Cells(4).Text.ToString
            'obj.DetalleDeuda = 
            objv.TipoDeuda = 3
            objv.TipoTarifa = cmbServicios.SelectedValue
            objv.Monto = nodo.Cells(10).Text.ToString
            objv.Saldo = nodo.Cells(12).Text.ToString
            objv.Redondeo = nodo.Cells(11).Text.ToString
            objv.Volumen = nodo.Cells(8).Text.ToString
            objv.Concepto = cmbServicios.Text
            objv.FechaDeuda = Today
            'obj.FechaPago = DBNull.Value
            objv.Pagado = 0
            userSystem = frmPrincipal.userSystem
            objv.UsuarioSys = UCase(userSystem.usuario)
            objv.Congelado = 0
            If (nodo.Checked) Then
                If Not objv.Insert(cmbCalles.SelectedValue, cmbMes.SelectedValue, cmbAnio.SelectedValue) Then
                    numerror = numerror & "Deuda Generada para el predio " & nodo.Cells(7).Text.ToString & " del usuario " & nodo.Cells(2).Text.ToString & " no se genero correctamente" & Chr(13)
                End If
            End If

        Next
        objv.ListTree(tvPredios, cmbCalles.SelectedValue, cmbMes.SelectedValue, cmbAnio.SelectedValue, cmbServicios.SelectedValue)
        tvPredios.Focus()

        If numerror.Length > 0 Then
            MsgBox("Ocurrio un error mientras se generaba la deuda. Se cancelo el proceso de Importación" & Chr(13) & numerror, MsgBoxStyle.Critical)
        Else
            MsgBox("Deuda generada satisfactoriamente", MsgBoxStyle.Information)
        End If

    End Sub

    Private Sub btnVisualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVisualizar.Click

    End Sub

    Private Sub cmbCPoblado_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCPoblado.SelectedIndexChanged
        Try
            clsCalles.LoadComboCallesPredio(cmbCalles, "where padPredio.idCP= " & cmbCPoblado.SelectedValue & " ")
            idcp = cmbCPoblado.SelectedValue
            If idcp = 0 Then
                idcp = "%"
            Else
                idcp = idcp
            End If
            CP = cmbCPoblado.Text


        Catch ex As Exception

        End Try
    End Sub

    Private Sub chkSelectAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSelectAll.CheckedChanged
        For Each n1 As DevComponents.AdvTree.Node In tvPredios.Nodes
            If (n1.Enabled) Then
                n1.Checked = chkSelectAll.Checked
            End If
        Next
    End Sub

    Private Sub Bar5_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bar5.ItemClick

    End Sub

    Private Sub cmbTipoServicio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipoServicio.SelectedIndexChanged
        If cmbTipoServicio.SelectedIndex = 0 Then
            clsTipoTarifa.LoadComboVolumen(cmbServicios, Year(ACCESO.Conexion.getDateServer))
        End If

        If cmbTipoServicio.SelectedIndex = 1 Then
            clsTipoTarifa.LoadComboAlcantarillado(cmbServicios, Year(ACCESO.Conexion.getDateServer))
        End If
    End Sub

    Private Sub tvPredios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tvPredios.Click

    End Sub
End Class