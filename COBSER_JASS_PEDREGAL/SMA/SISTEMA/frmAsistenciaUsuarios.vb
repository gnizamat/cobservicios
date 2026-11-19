Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Data.OleDb
Imports ACCESO
Imports LOGICA
Imports COBSER.Menu
Public Class frmAsistenciaUsuarios
    Public c As New ACCESO.Conexion
    Public anio As String
    Public tipotaria As Integer

    Dim idj As Integer
    Public winOrigen As Integer = 0
    Dim vf As New clsValidateForm
    'Public _usuario As New clsUsuario
    Public _select As Boolean = False
    Public comision As New clsComisionRegante
    Public junta As New clsJunta
    Public ESTADOA As String
    Public TIPOA As String = ""
    Dim RUTA As String
    Dim TIPO As Integer
    'Dim rpt As New ReportDocument

    Sub iniInterfaz()
        Select Case frmPrincipal.userSystem.idInterfaz
            Case 1, 2
                clsJunta.GeneraTree(tvJuntas)
                pnlJuntas.Expanded = True
            Case 3, 4
                clsJunta.GeneraTree(tvJuntas, "and j.vIdJuntaUsuario='" & frmPrincipal.userSystem.idJunta & "'")
                tvJuntas.SelectedNode = tvJuntas.Nodes.Item(0)
                pnlJuntas.Expanded = False
                pnlJuntas.Enabled = False
                'clsComisionRegante.LoadCombo(cmbComision, " where c.vIdJuntaUsuario='" & frmPrincipal.userSystem.idJunta & "' and c.iIdComisionRegante='" & frmPrincipal.userSystem.idComision & "'", , False, frmPrincipal.userSystem.idComision)

        End Select
    End Sub

    Private Sub frmAsistenciaUsuarios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim dt As New DataTable

            clsJunta.LoadCombo(cmbJunta)
            If (frmPrincipal.userSystem.idInterfaz = 4) Then
                cmbJunta.SelectedValue = frmPrincipal.userSystem.idJunta
                cmbJunta.Enabled = False
            End If
            clsCentroPoblado.LoadComboADD(cmbCPoblado)
            cmbCPoblado.SelectedIndex = 0

            clsCalles.LoadComboCallesPredio(cmbCalles)
            cmbCalles.SelectedValue = 0

            TxtNroAsistentes.Text = ""
            TxtPorcentaje.Text = ""

            vf.addTextbox(txtNombre, "string", True)
            vf.addTextbox(txtDNI, "numeric", True)
            vf.addTextbox(TxtCorrelativo, "numeric", True)
            
            TxtPorcentaje.Text = Math.Round(Val(TxtNroAsistentes.Text) / Val(txtNroUsuarios.Text) * 100, 2)
            
            'segun el tipo de interfaz
            iniInterfaz()

            'segun la ventana origen desde donde se llama este formulario
            'btnUsuarioNew.
            gridUsuarios.DataSource = Filtrar()
            PINTA()

            ESTADOA = gridUsuarios.Item(9, gridUsuarios.CurrentRow.Index).Value

            If ESTADOA = 1 Then
                'btnUsuarioNew.Enabled = False
            Else

                'btnUsuarioNew.Enabled = True
            End If

            Call NroUsuariosAsistencia()
            TxtPorcentaje.Text = Math.Round(Val(TxtNroAsistentes.Text) / Val(txtNroUsuarios.Text) * 100, 2)

        Catch ex As Exception

            MsgBox(ex.Message)
        End Try

    End Sub
    Private Sub PINTA()
        For i = 0 To gridUsuarios.RowCount - 1
            ':::Realizamos la validación de cada celda
            If gridUsuarios.Rows(i).Cells(4).Value = True Then
                ':::Pintamos de color azul las que son iguales
                gridUsuarios.Rows(i).DefaultCellStyle.BackColor = Color.SkyBlue
                ':::Aumentamos nuestro contador en 1
                'Total += 1
            Else
                ':::Pintamos de naranja los que no son iguales
                gridUsuarios.Rows(i).DefaultCellStyle.BackColor = Color.White
            End If
            ':::Mostramos el resultado
            'LblIguales.Text = "Números iguales: " & Total
            'LblDiferentes.Text = "Números diferentes: " & DGTabla.RowCount - Total

        Next
    End Sub
    Public Function Filtrar() As DataTable
        Dim dt As New DataTable
        'filtro de usuarios
        Dim condicion As String = " "
        idj = cmbJunta.SelectedValue
        If (txtNombre.Text <> "") Then
            condicion &= " AND usuario like '%" & txtNombre.Text & "%'"
        End If
        'If (txtAPaterno.Text <> "") Then
        '    condicion &= " and vApePaterno like '" & txtAPaterno.Text & "%'"
        'End If
        'If (txtAMaterno.Text <> "") Then
        '    condicion &= " and vApeMaterno like '" & txtAMaterno.Text & "%'"
        'End If
        If (txtDNI.Text <> "") Then
            condicion &= " and vDNI like '%" & txtDNI.Text & "%'"
        End If
        'If (txtComision.Text <> "") Then
        '    condicion &= " and comision like '" & txtComision.Text & "%'"
        'End If

        If (TxtCorrelativo.Text <> "") Then
            condicion &= " and CORRELATIVO like '" & TxtCorrelativo.Text & "'"
        End If
        If (cmbCalles.Text <> "[Todas las Calles]") Then
            condicion &= " and calle = '" & cmbCalles.Text & "'"
        Else
            condicion &= " and calle LIKE '%'"
        End If
        'If (cmbComision.SelectedValue = 0) Then
        '    condicion &= " and vIdJuntaUsuario like '" & idj & "'"
        'End If
        dt = clsUsuario.ListAsistencia(" vidJas='" & idj & "'" & condicion)
        'fin filtro

        txtNroUsuarios.Text = Val(dt.Rows.Count)
        'Call NroUsuariosAsistencia()
        Return dt
        'PINTA()

    End Function

    Private Sub lblJuntaSelected2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblJuntaSelected2.Click

    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()

    End Sub

    Private Sub txtDNI_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDNI.KeyUp
        If (vf.startValidation) Then
            gridUsuarios.DataSource = Filtrar()
            PINTA()
        End If

    End Sub

    Private Sub txtDNI_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDNI.TextChanged

    End Sub

    Private Sub txtNombre_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNombre.KeyUp
        If (vf.startValidation) Then
            gridUsuarios.DataSource = Filtrar()
            PINTA()
        End If

    End Sub

    Private Sub txtNombre_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNombre.TextChanged

    End Sub

    Private Sub TxtCorrelativo_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCorrelativo.KeyUp
        If (vf.startValidation) Then
            gridUsuarios.DataSource = Filtrar()
            PINTA()
        End If

    End Sub

    Private Sub TxtCorrelativo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCorrelativo.TextChanged

    End Sub

    Private Sub cmbCalles_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCalles.SelectedIndexChanged
        If (vf.startValidation) Then
            gridUsuarios.DataSource = Filtrar()
            PINTA()
        End If

    End Sub

    Private Sub gridUsuarios_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridUsuarios.CellContentClick
        'If (e.ColumnIndex = 0) Then
        '    gridUsuarios.Rows(e.RowIndex).Cells(0).Value = Not gridUsuarios.Rows(e.RowIndex).Cells(0).Value
        'End If
        Dim c As New Conexion
        Dim sql As String
        Dim valor_correlativo_celda As Integer
        Dim valor_de_celda As Integer
        Dim fila As Integer
        Dim idA As Integer

        Try

            If c.Connect Then
                'If gridUsuarios.SelectedRows.Count > 0 Then
                If (e.ColumnIndex = 4) Then
                    valor_correlativo_celda = gridUsuarios.Item(0, gridUsuarios.CurrentRow.Index).Value
                    valor_de_celda = gridUsuarios.Item(4, gridUsuarios.CurrentRow.Index).Value
                    fila = gridUsuarios.CurrentRow.Index
                    idA = gridUsuarios.Item(5, gridUsuarios.CurrentRow.Index).Value

                    gridUsuarios.Rows(e.RowIndex).Cells(0).Value = Not gridUsuarios.Rows(e.RowIndex).Cells(0).Value

                    If valor_de_celda = 0 Then

                        sql = "Update PAD_ASISTENCIAUSUARIOS set ASISTENCIA=1 where correlativo= " & valor_correlativo_celda & " and  iIdAsamblea=" & idA & ""
                        c.Query(sql)
                        MsgBox("Asistencia Registrada...!", MsgBoxStyle.Information, "Mensaje")

                        gridUsuarios.Rows(fila).DefaultCellStyle.BackColor = Color.SkyBlue
                        'gridUsuarios.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    Else

                        'sql = "Update PAD_ASISTENCIAUSUARIOS set ASISTENCIA=0 where correlativo=" & valor_correlativo_celda
                        sql = "Update PAD_ASISTENCIAUSUARIOS set Asistencia=0 where correlativo=" & valor_correlativo_celda & " and  iIdAsamblea=" & idA & ""
                        c.Query(sql)
                        gridUsuarios.Rows(fila).DefaultCellStyle.BackColor = Color.White
                    End If
                End If
            End If
            Call NroUsuariosAsistencia()
            TxtPorcentaje.Text = Math.Round(Val(TxtNroAsistentes.Text) / Val(txtNroUsuarios.Text) * 100, 2)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub NroUsuariosAsistencia()

        Dim c As New Conexion
        Dim dt As New DataTable
        Dim iCont As Integer = 0
        Try

            If c.Connect Then
                dt = c.Query("select count(*) as NroAs from view_AsistenciaUsuarios where ASISTENCIA=1")
                c.Close()
                If dt.Rows.Count > 0 Then
                    iCont = dt.Rows(0).Item("NroAs")

                End If
                TxtNroAsistentes.Text = iCont
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        txtDNI.Text = ""
        TxtCorrelativo.Text = ""
        txtNombre.Text = ""
        txtNombre.Focus()
        gridUsuarios.DataSource = Filtrar()
        PINTA()

    End Sub

    Private Sub ButtonItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem2.Click
        frmReportes.optionRPT = 3
        frmReportes.idjas = cmbJunta.SelectedValue
        frmReportes.ShowDialog()
    End Sub

    Private Sub ButtonItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem1.Click
        frmReportes.optionRPT = 2
        frmReportes.idjas = cmbJunta.SelectedValue
        frmReportes.ShowDialog()
    End Sub

    Private Sub GroupPanel1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupPanel1.Click

    End Sub
End Class