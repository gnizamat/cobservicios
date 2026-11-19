Imports ACCESO
Imports LOGICA
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Data.OleDb

Public Class frmPredios
    Dim idj As String
    Dim vf As New clsValidateForm
    Dim sector As Integer
    Dim calle As Integer
    Dim cp As Integer
    Dim estado As String



    Private Sub frmPredios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
       
       


        clsJunta.LoadCombo(cmbJunta)
        If (frmPrincipal.userSystem.idInterfaz = 4) Then
            cmbJunta.SelectedValue = frmPrincipal.userSystem.idJunta
            cmbJunta.Enabled = False
        End If
        clsCentroPoblado.LoadComboADD(cmbCPoblado)
        cmbCPoblado.SelectedValue = 0
        clsCalles.LoadComboADD(cmbCalles)
        cmbCalles.SelectedValue = 0
        clsSector.LoadComboAdd(cmbsector)
        


        cmbsector.SelectedValue = 0
        cmbEstado.SelectedIndex = 0

        estado = cmbEstado.SelectedIndex


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

    Private Sub ButtonItem11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem11.Click
        frmPredioNew.winOrigen = 2
        frmPredioNew.ShowDialog()

    End Sub
    Public Function Filtrar() As DataTable
        'Try
        'idj = cmbJunta.SelectedValue
        sector = cmbsector.SelectedValue
        calle = cmbCalles.SelectedValue
        cp = cmbCPoblado.SelectedValue
        Dim dt As New DataTable
        'filtro de usuarios

        Dim condicion As String = ""

        If (cmbCPoblado.SelectedValue <> 0) Then
            condicion &= "and idCP = " & cp & ""
        Else
            condicion &= "and idCP like '%'"

        End If
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
            condicion &= " and vUC like '%" & txtUC.Text & "%'"
        End If
        If (cmbEstado.SelectedIndex = 0) Then
            condicion &= " and cEstado = '1'"
        Else
            condicion &= " and cEstado = '0'"
        End If

        'dt = clsPredios.List(condicion, "1")

        dt = clsPredios.List(condicion)

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

    Private Sub txtUC_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUC.TextChanged

    End Sub

    Private Sub cmbsector_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbsector.Click
        
    End Sub

   

    Private Sub cmbCalles_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCalles.Click
        
    End Sub

  

    Private Sub cmbCalles_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cmbCalles.MouseClick
       
    End Sub

   

    Private Sub ButtonItem18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem18.Click
        txtDNI.Text = ""
        txtUAPaterno.Text = ""
        txtUAMaterno.Text = ""
        txtUNombre.Text = ""
        txtUC.Text = ""

        CargaGrid()

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

    Private Sub cmbsector_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbsector.SelectedIndexChanged

        Try
        If (vf.startValidation) Then
            gridPredios.DataSource = Filtrar()
        End If

            'CargaGrid()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ButtonItem12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem12.Click
        frmPrediosUpd.ShowDialog()
    End Sub

    Private Sub ButtonItem13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem13.Click
        Dim flag As Boolean = True
        Dim id As Integer
        If (Me.gridPredios.SelectedRows.Count > 0) Then
            'Try
            id = Me.gridPredios.Item(3, Me.gridPredios.CurrentRow.Index).Value
            'idj = Me.gridPredios.Item(0, Me.gridPredios.CurrentRow.Index).Value
            ''Catch ex As Exception
            ''    flag = False
            ''    MsgBox("Seleccione una fila valida")
            ''End Try
            If (flag) Then
                Dim m = MessageBox.Show("Desea eliminar el registro seleccionado?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If (m = Windows.Forms.DialogResult.Yes) Then
                    clsPredios.elimina(id)
                    gridPredios.DataSource = Filtrar()
                End If
            End If
            'Else
            '    MsgBox("Seleccione un Usuario")
        End If

    End Sub

    Private Sub ButtonItem14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem14.Click
       
    End Sub

    Private Sub ButtonItem19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem19.Click
        If (vf.startValidation) Then
            If cmbEstado.SelectedIndex = 1 Then
                gridPredios.DataSource = Filtrar(0)

            End If


            gridPredios.DataSource = Filtrar()

        End If
    End Sub

    Private Sub txtUAPaterno_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUAPaterno.TextChanged

    End Sub

    Private Sub txtUAMaterno_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUAMaterno.TextChanged

    End Sub

    Private Sub txtDNI_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDNI.TextChanged

    End Sub

    Private Sub ExpandablePanel2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExpandablePanel2.Click

    End Sub

    Private Sub cmbCPoblado_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCPoblado.SelectedIndexChanged
        Try
            clsCalles.LoadComboCallesPredio(cmbCalles, "where padPredio.idCP= " & cmbCPoblado.SelectedValue & " ")
            clsSector.LoadComboAdd(cmbsector)
            cmbsector.SelectedValue = 0

            If (vf.startValidation) Then
                gridPredios.DataSource = Filtrar()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbEstado_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbEstado.SelectedIndexChanged
        Try
            If (vf.startValidation) Then
                'If cmbEstado.SelectedValue = 0 Then
                estado = cmbEstado.SelectedIndex
                If estado = 0 Then
                    estado = "1"
                Else
                    estado = "0"

                End If
                gridPredios.DataSource = Filtrar()
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class