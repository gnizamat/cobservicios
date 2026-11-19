
Imports ACCESO
Imports LOGICA
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Data.OleDb
Public Class frmRegistrarLecturas

    Public usuario As String
    Public predio As String
    Public nrocasa As String
    Public codPredio As String
    Dim idj As String
    Dim vf As New clsValidateForm
    Dim calle As String
    Dim medidor As String
    Dim TipoTarifa As Integer
    Dim idcalle As Integer

    Dim sector As Integer
    Dim cp As Integer

    Public winOrigen As Integer = 0
    'Public _usu As New clsUsuario
    Public _select As Boolean = False
    Public flagMedidor As Boolean = True



    Private Sub frmRegistrarLecturas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        clsJunta.LoadCombo(cmbJunta)

        'clsCalles.LoadComboADD(cmbCalles)


        If (frmPrincipal.userSystem.idInterfaz = 4) Then
            cmbJunta.SelectedValue = frmPrincipal.userSystem.idJunta
            cmbJunta.Enabled = False
        End If
        clsCentroPoblado.LoadComboADD(cmbCPoblado)
        cmbCPoblado.SelectedValue = 0
        clsCalles.LoadComboCallesPredio(cmbCalles)
        cmbCalles.SelectedValue = 1
        idcalle = cmbCalles.SelectedValue

        'cmbCalles.SelectedValue = 0
        'idcalle = cmbCalles.SelectedValue

    End Sub
    'Private Sub CargaGrid()
    '    Dim dt As New DataTable
    '    dt = clsPredios.List(" ORDER BY vApePaterno, vApeMaterno, vUsuario")
    '    gridPredios.DataSource = dt
    '    If gridPredios.Rows.Count > 0 Then
    '        gridPredios.Columns(0).Width = 80
    '        gridPredios.Columns(1).Width = 80
    '        gridPredios.Columns(2).Width = 80
    '        gridPredios.Columns(3).Width = 100
    '        gridPredios.Columns(5).Width = 150
    '        gridPredios.Columns(2).Visible = False
    '        gridPredios.Columns(3).Visible = False
    '        gridPredios.Columns(4).Visible = False
    '    End If
    '    txtNroPredios.Text = Val(dt.Rows.Count)
    'End Sub

    Private Sub cmbCalles_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCalles.SelectedIndexChanged
        Try
            If (vf.startValidation) Then
                gridPredios.DataSource = Filtrar()
                idcalle = cmbCalles.SelectedValue

            End If
        Catch ex As Exception

        End Try
    End Sub
    Public Function Filtrar() As DataTable
        'Try

        'idj = cmbJunta.SelectedValue
        'Dim estado As String

        calle = cmbCalles.SelectedValue

        'sector = cmbsector.SelectedValue
        'calle = cmbCalles.SelectedValue
        cp = cmbCPoblado.SelectedValue

        'TipoTarifa = cmbServicio.SelectedValue
        Dim dt As New DataTable
        'filtro de usuarios
        Dim condicion As String = ""

        If (cmbCPoblado.SelectedValue <> 0) Then
            condicion &= "WHERE idCP = " & cp & ""
        Else
            condicion &= "WHERE idCP like '%'"

        End If
        'If (cmbsector.SelectedValue <> 0) Then
        '    condicion &= "and idsector = " & sector & ""
        'Else
        '    condicion &= "and idsector like '%'"

        'End If

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

        'If (cmbServicio.SelectedValue <> 0) Then
        '    condicion &= " and idTipoTarifa = " & TipoTarifa & ""
        'End If

        dt = clsPrediosServicios.ListServiciosUnicos(condicion)

        'fin filtro
        txtNroPredios.Text = Val(dt.Rows.Count)
        Return dt
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
    End Function

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLecturas.Click
        Try

        
            If (Me.gridPredios.SelectedRows.Count > 0) Then
                codPredio = gridPredios.SelectedRows(0).Cells(1).Value
                verificarMedidor()
                If flagMedidor = True Then
                    frmLecturaNew.idJas = gridPredios.SelectedRows(0).Cells(10).Value
                    frmLecturaNew.usuario = gridPredios.SelectedRows(0).Cells(2).Value
                    frmLecturaNew.PREDIO = gridPredios.SelectedRows(0).Cells(8).Value
                    frmLecturaNew.idPredio = gridPredios.SelectedRows(0).Cells(1).Value
                    frmLecturaNew.nrocasa = gridPredios.SelectedRows(0).Cells(7).Value
                    frmLecturaNew.dni = gridPredios.SelectedRows(0).Cells(0).Value
                    frmLecturaNew.tipotarifa = gridPredios.SelectedRows(0).Cells(11).Value
                    frmLecturaNew.codigo = gridPredios.SelectedRows(0).Cells(1).Value
                    'frmLecturaNew.codigoM = gridPredios.SelectedRows(0).Cells(13).Value
                    'frmDeudaAnteriorNew.uc = gridPredios.SelectedRows(0).Cells(15).Value
                    'frmDeudaAnteriorNew.calle = gridPredios.SelectedRows(0).Cells(17).Value
                    frmLecturaNew.ShowDialog()
                Else
                    MsgBox("Antes de Registra una Lecura Registre el Medidor", MsgBoxStyle.Exclamation)

                    'frmLecturaNew.idJas = gridPredios.SelectedRows(0).Cells(10).Value
                    ''frmLecturaNew.usuario = gridPredios.SelectedRows(0).Cells(2).Value
                    ''frmLecturaNew.PREDIO = gridPredios.SelectedRows(0).Cells(8).Value
                    ''frmLecturaNew.idPredio = gridPredios.SelectedRows(0).Cells(1).Value
                    ''frmLecturaNew.nrocasa = gridPredios.SelectedRows(0).Cells(7).Value
                    ''frmLecturaNew.dni = gridPredios.SelectedRows(0).Cells(0).Value
                    ''frmLecturaNew.tipotarifa = gridPredios.SelectedRows(0).Cells(11).Value

                    'clsMedidor.LoadCombo(frmRegistrarMedidor.cmbTipoMedidor)
                    'frmRegistrarMedidor.cmbTipoMedidor.SelectedIndex = 0
                    'frmRegistrarMedidor.txtNombre.Text = gridPredios.SelectedRows(0).Cells(2).Value
                    'frmRegistrarMedidor.txtLote.Text = gridPredios.SelectedRows(0).Cells(8).Value
                    'frmRegistrarMedidor.txtNro.Text = gridPredios.SelectedRows(0).Cells(7).Value
                    'frmRegistrarMedidor.txtDNI.Text = gridPredios.SelectedRows(0).Cells(0).Value
                    'frmRegistrarMedidor.txtCodigo.Text = ""
                    'frmRegistrarMedidor.txtFecha.Text = ACCESO.Conexion.getDateServer

                    'frmRegistrarMedidor.ShowDialog()
                End If

            Else


                MsgBox("Seleccione un predio")
            End If
        Catch ex As Exception

        End Try

        'frmRptSiembraUsuario.idUsuario = dgvDemanda1.SelectedRows(0).Cells(13).Value
    End Sub
    Function verificarMedidor()
        Dim c As New ACCESO.Conexion
        Dim dt As New DataTable
        If (c.Connect) Then
            dt = c.Query("SELECT vIdJas, idpredio, iIdTipoTarifa, idMedidor, Codigo, dFecha, cEstado FROM  padPredioServicioMedidor WHERE cEstado=1 AND idpredio = " & codPredio & "")
            'dt = c.Query("SELECT tarTarifaAnual.iAnioTarifa, tarTipoTarifa.vNombre, tarCostoTarifa.iIdTipoTarifa, tarCostoTarifa.fMonto FROM tarTarifaAnual INNER JOIN tarCostoTarifa ON tarTarifaAnual.iAnioTarifa = tarCostoTarifa.iAnioTarifa INNER JOIN tarTipoTarifa ON tarCostoTarifa.vIdJas = tarTipoTarifa.vIdJas AND tarCostoTarifa.iIdTipoTarifa = tarTipoTarifa.iIdTipoTarifa WHERE tarTarifaAnual.cEstadoTarifa = '1' AND tarCostoTarifa.iIdTipoTarifa = 10 AND tarTarifaAnual.iAnioTarifa= '" & cmbAnio.Text & "'")
            If (dt.Rows.Count > 0) Then
                flagMedidor = True
            Else
                flagMedidor = False

            End If

        End If
    End Function

    Private Sub btnMedidor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMedidor.Click
        If (Me.gridPredios.SelectedRows.Count > 0) Then
            frmRegistrarMedidor.idJas = gridPredios.SelectedRows(0).Cells(10).Value
            frmRegistrarMedidor.usuario = gridPredios.SelectedRows(0).Cells(2).Value
            frmRegistrarMedidor.PREDIO = gridPredios.SelectedRows(0).Cells(8).Value
            frmRegistrarMedidor.idPredio = gridPredios.SelectedRows(0).Cells(1).Value
            frmRegistrarMedidor.nrocasa = gridPredios.SelectedRows(0).Cells(7).Value
            frmRegistrarMedidor.dni = gridPredios.SelectedRows(0).Cells(0).Value
            frmRegistrarMedidor.tipotarifa = gridPredios.SelectedRows(0).Cells(11).Value
            frmRegistrarMedidor.ShowDialog()
        Else
            MsgBox("Seleccione un predio")
        End If
    End Sub

    Private Sub cmbJunta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbJunta.SelectedIndexChanged

    End Sub

    Private Sub txtUAMaterno_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUAMaterno.KeyUp
        If (vf.startValidation) Then
            gridPredios.DataSource = Filtrar()
        End If
    End Sub

    Private Sub txtUAMaterno_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUAMaterno.TextChanged

    End Sub

    Private Sub txtUAPaterno_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUAPaterno.KeyUp
        If (vf.startValidation) Then
            gridPredios.DataSource = Filtrar()
        End If
    End Sub

    Private Sub txtUAPaterno_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUAPaterno.TextChanged

    End Sub

    Private Sub txtUNombre_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUNombre.KeyUp
        If (vf.startValidation) Then
            gridPredios.DataSource = Filtrar()
        End If
    End Sub

    Private Sub txtUNombre_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUNombre.TextChanged

    End Sub

    Private Sub txtUC_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUC.KeyUp
        If (vf.startValidation) Then
            gridPredios.DataSource = Filtrar()
        End If
    End Sub

    Private Sub txtUC_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUC.TextChanged

    End Sub

    Private Sub txtMedidor_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMedidor.KeyUp
        'If (vf.startValidation) Then
        '    gridPredios.DataSource = Filtrar()
        'End If
    End Sub

    Private Sub txtMedidor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMedidor.TextChanged

    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        'txtDNI.Text = ""
        txtUAPaterno.Text = ""
        txtUAMaterno.Text = ""
        txtUNombre.Text = ""
        txtUC.Text = ""
        txtMedidor.Text = ""
        txtUAPaterno.Focus()

    End Sub

    Private Sub cmbCPoblado_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCPoblado.SelectedIndexChanged
    

        Try
            clsCalles.LoadComboCallesPredio(cmbCalles, "where padPredio.idCP= " & cmbCPoblado.SelectedValue & " ")
            'clsSector.LoadComboAdd(cmbsector)
            'cmbsector.SelectedValue = 0

            If (vf.startValidation) Then
                gridPredios.DataSource = Filtrar()
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class