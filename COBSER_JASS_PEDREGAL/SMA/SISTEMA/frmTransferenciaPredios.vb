Imports ACCESO
Imports LOGICA
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Data.OleDb


Public Class frmTransferenciaPredios
    Dim vf As New clsValidateForm
    Public usuario1 As clsUsuario
    Public Usuario2 As clsUsuario
    Public idUsu As Integer
    Public idUsuario As String
    Public idJas As String
    Public idpredio As Integer
    Public idpredio2 As Integer
    Public iidusuario As Integer
    Public observ As String





    Private Sub frmTransferenciaPredios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        clsJunta.LoadCombo(cmbJunta)
        If (frmPrincipal.userSystem.idInterfaz = 4) Then
            cmbJunta.SelectedValue = frmPrincipal.userSystem.idJunta
            cmbJunta.Enabled = False
        End If

        
        Me.dgPredios1.Rows.Clear()
        Me.dgPredios1.Columns.Clear()
        dgPredios1.Columns.Add("vNombre", "PREDIO")
        dgPredios1.Columns.Add("calle", "CALLE")
        dgPredios1.Columns.Add("vNroPredio", "N° CASA")
        dgPredios1.Columns.Add("mzPredio", "MANZANA")
        dgPredios1.Columns.Add("lotePredio", "LOTE")
        dgPredios1.Columns.Add("lotePredio", "IDPREDIO")
        dgPredios1.Columns.Add("idcalle", "IDCALLE")
        dgPredios1.Columns.Add("iIdusuario", "IDUSUARIO")

        Me.dgPredios2.Rows.Clear()
        Me.dgPredios2.Columns.Clear()
        dgPredios2.Columns.Add("vNombre", "PREDIO")
        dgPredios2.Columns.Add("calle", "CALLE")
        dgPredios2.Columns.Add("vNroPredio", "N° CASA")
        dgPredios2.Columns.Add("mzPredio", "MANZANA")
        dgPredios2.Columns.Add("lotePredio", "LOTE")
        dgPredios2.Columns.Add("idpredio", "IDPREDIO")
        dgPredios2.Columns.Add("idcalle", "IDCALLE")
        dgPredios2.Columns.Add("iIdusuario", "IDUSUARIO")




        'dgPredios2.Columns.Add("junta", "Junta de Usuarios")
        'dgPredios2.Columns.Add("atotal", "A.Total")
        'dgPredios2.Columns.Add("abr", "A.Bajo Riego")
        'dgPredios2.Columns.Add("uc", "UC")
        'dgPredios2.Columns(5).Visible = False
        'dgPredios2.Columns(6).Visible = False
        'dgPredios2.Columns(7).Visible = False
        'dgPredios2.Columns(8).Visible = False
        vf.addTextbox(txtUsuario1, "string", False)
        vf.addTextbox(txtUsuario2, "string", False)
        vf.addCombobox(cmbJunta, "string", False)

        vf.resetForm()

    End Sub

    Private Sub txtUsuario1_ButtonCustom2Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUsuario1.ButtonCustom2Click
       
    End Sub

    Private Sub txtUsuario1_ButtonCustomClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUsuario1.ButtonCustomClick
        frmUsuarios.Close()
        frmUsuarios.winOrigen = 3
        frmUsuarios.ShowDialog()
    End Sub

    Private Sub txtUsuario1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUsuario1.TextChanged

    End Sub

    Private Sub txtUsuario2_ButtonCustomClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUsuario2.ButtonCustomClick
        frmUsuarios.Close()
        frmUsuarios.winOrigen = 4
        frmUsuarios.ShowDialog()
    End Sub

    Private Sub txtUsuario2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUsuario2.TextChanged

    End Sub

    Private Sub btn_1_a_Usuario2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_1_a_Usuario2.Click
        If (txtUsuario2.Text <> "") Then
            If (dgPredios1.SelectedRows.Count > 0) Then
                idpredio2 = dgPredios1.SelectedRows(0).Cells(5).Value

                With dgPredios1.SelectedRows(0)
                    dgPredios2.Rows.Add(.Cells(0).Value, .Cells(1).Value, .Cells(2).Value, .Cells(3).Value, .Cells(4).Value, .Cells(5).Value, .Cells(6).Value, .Cells(7).Value)
                End With
                dgPredios1.Rows.Remove(dgPredios1.SelectedRows(0))

            End If

            'idpredio = 
            'idUsu = dgPredios1.Item(7, dgPredios1.CurrentRow.Index).Value
        Else
            MsgBox("Debe Agregar un usuario al cual se le asignara el predio")
        End If
    End Sub

    Private Sub btn_1_a_Usuario1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_1_a_Usuario1.Click
        If (txtUsuario1.Text <> "") Then
            If (dgPredios2.SelectedRows.Count > 0) Then
                With dgPredios2.SelectedRows(0)
                    dgPredios1.Rows.Add(.Cells(0).Value, .Cells(1).Value, .Cells(2).Value, .Cells(3).Value, .Cells(4).Value, .Cells(5).Value, .Cells(6).Value, .Cells(7).Value)
                End With
                dgPredios2.Rows.Remove(dgPredios2.SelectedRows(0))
            End If
        Else
            MsgBox("Debe Agregar un usuario al cual se le asignara el predio")
        End If

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If (vf.startValidation) Then
            'If (usuario1.id = Usuario2.id) Then
            '    MsgBox("Usuarios seleccionados para el proceso de transferencia no deben ser iguales", MsgBoxStyle.Exclamation)

            'Else
            Dim prediot As New clsTransferenciaPredios
            'Dim usuario As clsUsuario
            'Dim usuario As New clsPredios
            'Dim dtfecha As DateTime = DateTime.Now
            'grabando predios a usuario1
            For Each row As DataGridViewRow In dgPredios1.Rows
                'predio.id = row.Cells(5).Value
                idpredio = Me.dgPredios1.Item(5, Me.dgPredios1.CurrentRow.Index).Value
                idUsuario = Me.dgPredios2.Item(7, Me.dgPredios1.CurrentRow.Index).Value
                idJas = cmbJunta.SelectedValue
                idpredio = row.Cells(5).Value
                idUsuario = row.Cells(7).Value

                If (idpredio2 <> idpredio) Then
                    prediot.addUsuario(idpredio2, idUsuario, iidusuario)
                    prediot.InsertPrediot(idJas, idUsuario, idpredio2, 1, ACCESO.Conexion.getDateServer)

                End If

                'End If
            Next
            'grabando predios a usuario2
            For Each row As DataGridViewRow In dgPredios2.Rows
                'predio.id = row.Cells(5).Value
                idJas = cmbJunta.SelectedValue
                idpredio = row.Cells(5).Value
                idUsuario = row.Cells(7).Value
                observ = txtReferencia.Text
                ''prediot = prediot.getUsuarioActual
                If (idpredio2 <> idpredio) Then
                    prediot.addUsuario(idpredio2, idUsuario, iidusuario)
                    prediot.InsertPrediot(idJas, idUsuario, idpredio2, 1, ACCESO.Conexion.getDateServer)

                End If

                If (dgPredios2.Rows.Count = 1) Then
                    prediot.addUsuario(idpredio2, idUsuario, iidusuario)
                    prediot.InsertPrediot(idJas, idUsu, idpredio2, 1, ACCESO.Conexion.getDateServer)

                End If
            Next
            MsgBox("Transferencia realizada satisfactoriamente", MsgBoxStyle.Information)
            'End If
        Else
        MsgBox("información invalida o incompleta", MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub dgPredios2_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgPredios2.CellContentClick

    End Sub

    Private Sub btn_all_a_Usuario2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txtReferencia_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtReferencia.TextChanged

    End Sub
End Class