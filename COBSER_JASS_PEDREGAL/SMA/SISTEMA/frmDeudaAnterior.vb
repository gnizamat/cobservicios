
Imports ACCESO
Imports LOGICA
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Data.OleDb
Public Class frmDeudaAnterior
    Dim idj As String
    Dim vf As New clsValidateForm
    Dim idsector As Integer
    Dim idcalle As Integer
    Dim calle As String
    Dim sector As String
    'Dim usuario As String
    Dim predio As String
    'Dim nrocasa As String
    'Dim uc As String



    Private Sub frmDeudaAnterior_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'clsSector.LoadComboAdd(cmbsector)

        'clsCalles.LoadComboADD(cmbCalles)

        clsJunta.LoadCombo(cmbJunta)
        If (frmPrincipal.userSystem.idInterfaz = 4) Then
            cmbJunta.SelectedValue = frmPrincipal.userSystem.idJunta
            cmbJunta.Enabled = False
        End If

        clsCentroPoblado.LoadComboADD(cmbCPoblado)
        cmbCPoblado.SelectedValue = 0
        clsCalles.LoadComboCallesPredio(cmbCalles)
        cmbCalles.SelectedValue = 1
        idcalle = cmbCalles.SelectedValue
        clsSector.LoadComboSectorCalle(cmbsector)
        cmbsector.SelectedValue = 0

        CargaGrid()

    End Sub
    Private Sub CargaGrid()
        Dim dt As New DataTable
        dt = clsPredios.List(" ORDER BY vApePaterno, vApeMaterno, vUsuario")
        gridPredios.DataSource = dt
        If gridPredios.Rows.Count > 0 Then
            gridPredios.Columns(0).Width = 80
            gridPredios.Columns(1).Width = 80
            gridPredios.Columns(2).Width = 80
            gridPredios.Columns(3).Width = 100
            gridPredios.Columns(5).Width = 150
            gridPredios.Columns(2).Visible = False
            gridPredios.Columns(3).Visible = False
            gridPredios.Columns(4).Visible = False
        End If
        txtNroPredios.Text = Val(dt.Rows.Count)
    End Sub

    Public Function Filtrar() As DataTable
        'Try

        'idj = cmbJunta.SelectedValue
        sector = cmbsector.SelectedValue
        calle = cmbCalles.SelectedValue
        Dim dt As New DataTable
        'filtro de usuarios
        Dim condicion As String = ""

        If (cmbsector.SelectedValue <> 0) Then
            condicion &= "and idsector = " & sector & ""
        Else
            condicion &= "and idsector like '%'"
        End If
        If (cmbCalles.SelectedValue <> 0) Then
            condicion &= "and idCalle = " & calle & ""
        Else
            condicion &= "and idCalle like '%'"
        End If
        If (txtUAPaterno.Text <> "") Then
            condicion &= " and vApePaterno like '" & txtUAPaterno.Text & "%'"
        End If
        If (txtUAMaterno.Text <> "") Then
            condicion &= " and vApeMaterno like '" & txtUAMaterno.Text & "%'"
        End If
        If (txtUNombre.Text <> "") Then
            condicion &= " and vUsuario like '" & txtUNombre.Text & "%'"
        End If
        If (txtDNI.Text <> "") Then
            condicion &= " and vDNI like '%" & txtDNI.Text & "%'"
        End If
        If (txtUC.Text <> "") Then
            condicion &= " and vNroPredio like '%" & txtUC.Text & "%'"
        End If
        'dt = (" and vIdJuntaUsuario='" & idj & "'" & condicion, "1")
        dt = clsPredios.List(condicion, "1")
        'fin filtro
        txtNroPredios.Text = Val(dt.Rows.Count)
        Return dt
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
    End Function
    Private Sub txtDNI_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDNI.KeyUp
        If (vf.startValidation) Then
            gridPredios.DataSource = Filtrar()
        End If
    End Sub
    Private Sub txtUAPaterno_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUAPaterno.KeyUp
        If (vf.startValidation) Then
            gridPredios.DataSource = Filtrar()
        End If
    End Sub
    Private Sub txtUAMaterno_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUAMaterno.KeyUp
        If (vf.startValidation) Then
            gridPredios.DataSource = Filtrar()
        End If
    End Sub
    Private Sub txtUNombre_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUNombre.KeyUp
        If (vf.startValidation) Then
            gridPredios.DataSource = Filtrar()
        End If
    End Sub
    Private Sub txtUC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUC.KeyPress
        If (vf.startValidation) Then
            gridPredios.DataSource = Filtrar()
        End If
    End Sub

    Private Sub cmbsector_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbsector.SelectedIndexChanged
        Try
            If (vf.startValidation) Then
                gridPredios.DataSource = Filtrar()
            End If

            'CargaGrid()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbCalles_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCalles.SelectedIndexChanged
        Try
            clsSector.LoadComboSectorCalle(cmbsector, "WHERE padPredio.idCP = " & cmbCPoblado.SelectedValue & " and padPredio.idcalle=" & cmbCalles.SelectedValue & " ")
            If (vf.startValidation) Then
                gridPredios.DataSource = Filtrar()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ButtonItem11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem11.Click

        If (Me.gridPredios.SelectedRows.Count > 0) Then
            frmDeudaAnteriorNew.usuario = gridPredios.SelectedRows(0).Cells(8).Value
            frmDeudaAnteriorNew.predio = gridPredios.SelectedRows(0).Cells(10).Value
            frmDeudaAnteriorNew.idpredio = gridPredios.SelectedRows(0).Cells(3).Value
            frmDeudaAnteriorNew.nrocasa = gridPredios.SelectedRows(0).Cells(11).Value
            frmDeudaAnteriorNew.uc = gridPredios.SelectedRows(0).Cells(15).Value
            frmDeudaAnteriorNew.calle = gridPredios.SelectedRows(0).Cells(17).Value
            frmDeudaAnteriorNew.ShowDialog()
        Else
            MsgBox("Seleccione un Usuario")
        End If
        'frmRptSiembraUsuario.idUsuario = dgvDemanda1.SelectedRows(0).Cells(13).Value
    End Sub

    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label7.Click

    End Sub

    Private Sub txtUAMaterno_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUAMaterno.TextChanged

    End Sub

    Private Sub txtDNI_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDNI.TextChanged

    End Sub

    Private Sub txtUAPaterno_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUAPaterno.TextChanged

    End Sub

    Private Sub txtUC_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUC.TextChanged

    End Sub

    Private Sub cmbCPoblado_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCPoblado.SelectedIndexChanged
        Try

            clsCalles.LoadComboCallesPredio(cmbCalles, "where padPredio.idCP= " & cmbCPoblado.SelectedValue & " ")
            clsSector.LoadComboAdd(cmbsector)
            cmbsector.SelectedValue = 0
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LabelX25_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LabelX25.Click

    End Sub
End Class