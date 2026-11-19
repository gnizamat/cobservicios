
Imports ACCESO
Imports LOGICA
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Data.OleDb

Public Class frmPrediosServicios
    Public codPredio As Integer

    Dim idj As String
    Dim vf As New clsValidateForm
    Dim calle As String
    Dim TipoTarifa As Integer
    Dim predio As String
    Dim idcalle As Integer
    Dim CP As Integer

    Dim estado As String


    Private Sub frmPrediosServicios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        clsJunta.LoadCombo(cmbJunta)
        cmbEstado.SelectedIndex = 0

        estado = cmbEstado.SelectedIndex
       

        If (frmPrincipal.userSystem.idInterfaz = 4) Then
            cmbJunta.SelectedValue = frmPrincipal.userSystem.idJunta
            cmbJunta.Enabled = False
        End If
        clsTipoTarifa.LoadComboTodos(cmbServicio)

        clsCentroPoblado.LoadComboADD(cmbCPoblado)
        cmbCPoblado.SelectedValue = 0
        clsCalles.LoadComboCallesPredio(cmbCalles)
        cmbCalles.SelectedValue = 1
        idcalle = cmbCalles.SelectedValue
        clsSector.LoadComboSectorCalle(cmbsector)
        cmbsector.SelectedValue = 0
        'clsTipoTarifa.LoadComboFijos(cmbServicio, Year(ACCESO.Conexion.getDateServer))
        

    End Sub

    Public Function Filtrar() As DataTable
        'Try

        'idj = cmbJunta.SelectedValue
        'Dim estado As String

        calle = cmbCalles.SelectedValue
        TipoTarifa = cmbServicio.SelectedValue
        Dim dt As New DataTable
        'filtro de usuarios
        Dim condicion As String = ""


        'If (cmbCPoblado.SelectedValue <> 0) Then
        '    condicion &= " WHERE idCP = " & CP & ""
        'Else
        '    condicion &= " WHERE idCP like '%'"
        'End If

        If (cmbCalles.SelectedValue <> 0) Then
            condicion &= " WHERE idCalle = " & calle & ""
        Else
            condicion &= " WHERE idCalle like '%'"
        End If
        If (txtUAPaterno.Text <> "") Then
            condicion &= " and vApePaterno like '" & txtUAPaterno.Text & "%'"
        End If
        If (txtUAMaterno.Text <> "") Then
            condicion &= " and vApeMaterno like '" & txtUAMaterno.Text & "%'"
        End If
        If (txtUNombre.Text <> "") Then
            condicion &= " and Usuario like '" & txtUNombre.Text & "%'"
        End If
        If (txtDNI.Text <> "") Then
            condicion &= " and Documento like '%" & txtDNI.Text & "%'"
        End If
        If (txtUC.Text <> "") Then
            condicion &= " and vNroPredio like '%" & txtUC.Text & "%'"
        End If
        
        If (cmbServicio.SelectedValue <> 0) Then
            condicion &= " and iIdTipoTarifa = " & TipoTarifa & ""
        End If
        If (cmbEstado.SelectedIndex = 0) Then
            condicion &= " and cEstado = '1'"
        Else
            condicion &= " and cEstado = '0'"
        End If

        dt = clsPrediosServicios.List(condicion)
        'fin filtro
        txtNroPredios.Text = Val(dt.Rows.Count)
        Return dt
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
    End Function

    Private Sub cmbCalles_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCalles.SelectedIndexChanged
        Try
            clsSector.LoadComboSectorCalle(cmbsector, "WHERE padPredio.idCP = " & cmbCPoblado.SelectedValue & " and padPredio.idcalle=" & cmbCalles.SelectedValue & " ")
            If (vf.startValidation) Then
                gridPredios.DataSource = Filtrar()
                idcalle = cmbCalles.SelectedValue
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbServicio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbServicio.SelectedIndexChanged
        Try
            If (vf.startValidation) Then
                gridPredios.DataSource = Filtrar()

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ButtonItem11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem11.Click
        frmAsignarMedidor.idcalle = cmbCalles.SelectedValue
        frmAsignarMedidor.ShowDialog()

    End Sub

    Private Sub ButtonItem12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem12.Click
        Dim flag As Boolean = True
        Dim id As Integer
        Dim idservicio As Integer
        Dim dt As New DataTable


        If (Me.gridPredios.SelectedRows.Count > 0) Then
            'Try
            id = Me.gridPredios.Item(2, Me.gridPredios.CurrentRow.Index).Value
            idservicio = Me.gridPredios.Item(13, Me.gridPredios.CurrentRow.Index).Value
            'idj = Me.gridPredios.Item(0, Me.gridPredios.CurrentRow.Index).Value
            ''Catch ex As Exception
            ''    flag = False
            ''    MsgBox("Seleccione una fila valida")
            ''End Try
            If (flag) Then
                Dim m = MessageBox.Show("Desea Desactivar el Servicio al Predio seleccionado?", "Desactivar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If (m = Windows.Forms.DialogResult.Yes) Then
                    clsPrediosServicios.QuitarServicio(id, idservicio)
                    gridPredios.DataSource = Filtrar()
                End If
            End If
            'Else
            '    MsgBox("Seleccione un Usuario")
        End If
    End Sub

    Private Sub cmbReferencia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbEstado.SelectedIndexChanged
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

    Public Function CondicionEstado() As String
        Dim condicion As String = " "
        Select Case cmbEstado.SelectedIndex
            Case 0
                condicion = " and cEstado=1"
            Case 1
                condicion = " and cEstado=0"
            Case 2
                condicion = ""
        End Select
        Return condicion
    End Function

    Private Sub ButtonItem17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem17.Click
        Me.Close()

    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        txtDNI.Focus()
        txtDNI.Text = ""
        txtUAPaterno.Text = ""
        txtUAMaterno.Text = ""
        txtUNombre.Text = ""

    End Sub

    Private Sub ButtonItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem2.Click
        Dim flag As Boolean = True
        Dim id As Integer
        Dim idservicio As Integer
        Dim dt As New DataTable


        If (Me.gridPredios.SelectedRows.Count > 0) Then
            'Try
            id = Me.gridPredios.Item(2, Me.gridPredios.CurrentRow.Index).Value
            idservicio = Me.gridPredios.Item(13, Me.gridPredios.CurrentRow.Index).Value
            'idj = Me.gridPredios.Item(0, Me.gridPredios.CurrentRow.Index).Value
            ''Catch ex As Exception
            ''    flag = False
            ''    MsgBox("Seleccione una fila valida")
            ''End Try
            If (flag) Then
                Dim m = MessageBox.Show("Desea Activar el Servicio al Predio seleccionado?", "Activar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If (m = Windows.Forms.DialogResult.Yes) Then
                    clsPrediosServicios.ActivarServicio(id, idservicio)
                    gridPredios.DataSource = Filtrar()
                End If
            End If
            'Else
            '    MsgBox("Seleccione un Usuario")
        End If
    End Sub

    Private Sub cmbCPoblado_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCPoblado.SelectedIndexChanged
        Try
            clsCalles.LoadComboCallesPredio(cmbCalles, "where padPredio.idCP= " & cmbCPoblado.SelectedValue & " ")
            clsSector.LoadComboAdd(cmbsector)
            cmbsector.SelectedValue = 0
        Catch ex As Exception

        End Try
      
    End Sub

    Private Sub cmbsector_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbsector.SelectedIndexChanged

    End Sub

    Private Sub GroupPanel1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupPanel1.Click

    End Sub

    Private Sub txtUAPaterno_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUAPaterno.KeyPress
        If (vf.startValidation) Then
            gridPredios.DataSource = Filtrar()
        End If
    End Sub

    Private Sub txtUAPaterno_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUAPaterno.TextChanged

    End Sub

    Private Sub txtUAMaterno_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUAMaterno.KeyPress
        If (vf.startValidation) Then
            gridPredios.DataSource = Filtrar()
        End If
    End Sub

    Private Sub txtUAMaterno_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUAMaterno.TextChanged

    End Sub

    Private Sub txtDNI_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDNI.KeyPress
        If (vf.startValidation) Then
            gridPredios.DataSource = Filtrar()
        End If
    End Sub

    Private Sub txtDNI_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDNI.TextChanged

    End Sub

    Private Sub txtUNombre_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUNombre.KeyPress
        If (vf.startValidation) Then
            gridPredios.DataSource = Filtrar()
        End If
    End Sub

    Private Sub txtUNombre_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUNombre.TextChanged

    End Sub

    Private Sub btnCorte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCorte.Click
        If (Me.gridPredios.SelectedRows.Count > 0) Then
            codPredio = gridPredios.SelectedRows(0).Cells(1).Value


            frmCortesServicio.idjas = gridPredios.SelectedRows(0).Cells(12).Value
            frmCortesServicio.dni = gridPredios.SelectedRows(0).Cells(0).Value
            frmCortesServicio.usuario = gridPredios.SelectedRows(0).Cells(4).Value
            frmCortesServicio.predio = gridPredios.SelectedRows(0).Cells(10).Value
            frmCortesServicio.idPredio = gridPredios.SelectedRows(0).Cells(2).Value
            frmCortesServicio.idcalle = gridPredios.SelectedRows(0).Cells(11).Value
            frmCortesServicio.nrocasa = gridPredios.SelectedRows(0).Cells(9).Value
            frmCortesServicio.dni = gridPredios.SelectedRows(0).Cells(0).Value
            frmCortesServicio.idservicio = gridPredios.SelectedRows(0).Cells(13).Value
            frmCortesServicio.lote = gridPredios.SelectedRows(0).Cells(17).Value
            frmCortesServicio.manzana = gridPredios.SelectedRows(0).Cells(18).Value
            'frmDeudaAnteriorNew.uc = gridPredios.SelectedRows(0).Cells(15).Value
            'frmDeudaAnteriorNew.calle = gridPredios.SelectedRows(0).Cells(17).Value
            frmCortesServicio.ShowDialog()


        Else


            MsgBox("Seleccione un predio")
        End If
    End Sub
End Class