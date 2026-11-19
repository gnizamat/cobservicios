Imports ACCESO
Imports LOGICA
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Data.OleDb

Public Class frmControlHidrometrico
    Public tiempob As Double
    Public horasb As String

    Public idestructura As Integer
    Public idlectura As Integer
    Public idJas As String
    'Public codigo As String
    Public anio As String
    'Public winOrigen As Integer = 0
    Public mes As Integer
    Public horaini As String
    Public horafin As String
    Public FECHA As Date
    'Public codigo As String
    Public segundos As Double

    Public linicial As Double
    Public lfinal As Double
    Public volumenE As Double
    'Public volConsumolt As Double
    'Public anioactual As String

    Dim volumenc As Double
    Dim idmes As Integer



    Private Sub frmControlHidrometrico_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            clsJunta.LoadCombo(cmbJunta)

            If (frmPrincipal.userSystem.idInterfaz = 4) Then
                cmbJunta.SelectedValue = frmPrincipal.userSystem.idJunta
                cmbJunta.Enabled = False
            End If
            clsEstructura.LoadCombo(cmbEstructura)
            clsAnioTarifa.LoadComboAnioVigente(cmbAnio)
            clsMes.LoadCombo(cmbMes)
            cmbMes.SelectedValue = 1
            txtFechaRegistro.Text = ACCESO.Conexion.getDateServer
            txtFechaL.Text = ACCESO.Conexion.getDateServer
            btnSave.Enabled = False
            btnDelete.Enabled = True
            DatosEstructuras()
            'CARGAGRIDLECTURAS()
        Catch ex As Exception

        End Try
    End Sub
    Sub CALCULAR()
        Dim segundos As Long
        Dim hora As String
        segundos = DateDiff(DateInterval.Second, txtFechaInicio.Value, txtFechaFinal.Value)
        txtSegundos.Text = segundos
        hora = FormatoHorasMinutos(segundos)
        txtHoras.Text = hora

    End Sub
    Private Sub CARGAGRIDLECTURAS()
        Try

            Dim dt As New DataTable
            dt = clsControlHidrometrico.List(cmbEstructura.SelectedValue, cmbAnio.SelectedValue, idmes)
            gridLecturas.DataSource = dt
            If gridLecturas.Rows.Count > 0 Then
                gridLecturas.Columns(0).Width = 40
                gridLecturas.Columns(1).Width = 40
                gridLecturas.Columns(2).Width = 50
                gridLecturas.Columns(3).Width = 60
                gridLecturas.Columns(4).Width = 60
                gridLecturas.Columns(5).Width = 60
                gridLecturas.Columns(6).Width = 70
                gridLecturas.Columns(8).Width = 70
                gridLecturas.Columns(9).Width = 70
                gridLecturas.Columns(10).Width = 70
                gridLecturas.Columns(11).Width = 70
                gridLecturas.Columns(0).Visible = False
                gridLecturas.Columns(14).Visible = False

                'gridLecturas.Columns(14).Width = 120

                'gridLecturas.Columns(3).Visible = False
                'gridLecturas.Columns(4).Visible = False
                'gridLecturas.Columns(5).Visible = False
                'gridLecturas.Columns(7).Visible = False
                'gridLecturas.Columns(12).Visible = False
                'gridLecturas.Columns(15).Visible = False
                'gridLecturas.Columns(16).Visible = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
   

    Private Sub mskHoraIni_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
      
    End Sub

    Private Sub mskHoraIni_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs)

    End Sub

    Private Sub mskHoraFin_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            txtInicial.Focus()
        End If
    End Sub

    Private Sub mskHoraFin_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs)

    End Sub

    Private Sub txtInicial_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtInicial.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            txtFinal.Focus()
        End If
    End Sub

    Private Sub txtInicial_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtInicial.TextChanged
        'txtInicial.Text = Format(Val(txtInicial.Text), "###,##0.###")
        'txtInicial.Text = FormatNumber(txtInicial.Text, 2)
    End Sub

    Private Sub mskHoraFin_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)

        'mskHoras.Text = horasb


    End Sub

    Private Sub txtFinal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFinal.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            txtCloroIni.Focus()
        End If
    End Sub

    Private Sub txtFinal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFinal.TextChanged
        volumenc = (txtFinal.Text) - Val(txtInicial.Text)
        txtVolumen.Text = FormatNumber(volumenc, 3)

    End Sub

    Private Sub txtCloroIni_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCloroIni.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            txtCloroFin.Focus()
        End If
    End Sub

    Private Sub txtCloroIni_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCloroIni.TextChanged

    End Sub

    Private Sub txtCloroFin_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCloroFin.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            txtObserv.Focus()
        End If
    End Sub

    Private Sub txtCloroFin_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCloroFin.TextChanged

    End Sub

    Private Sub txtFechaFinal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFechaFinal.Click

    End Sub

    Private Sub txtFechaFinal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFechaFinal.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            txtInicial.Focus()
        End If
    End Sub

    Private Sub txtFechaFinal_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFechaFinal.ValueChanged
        CALCULAR()
    End Sub

    Private Sub txtHoras_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHoras.TextChanged

    End Sub

    Private Sub ButtonItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim f As New Date
        Dim flagValido As Boolean = True
        Dim userSystem As New ACCESO.User
        'idmedidor = cmbTipoMedidor.SelectedValue
        'codigo = txtCodigo.Text
        FECHA = txtFechaL.Text
        Dim dt As New DataTable
        Dim ch As New clsControlHidrometrico()
        userSystem = frmPrincipal.userSystem
        ch.UsuarioSys = UCase(userSystem.usuario)
        ch.anio = cmbAnio.SelectedValue
        ch.Mes = cmbMes.SelectedValue
        ch.Estructura = cmbEstructura.SelectedValue
        ch.FechaActual = txtFechaRegistro.Text
        ch.horai = txtFechaInicio.Text
        ch.horaf = txtFechaFinal.Text
        ch.horas = txtHoras.Text
        ch.duracion = txtSegundos.Text
        ch.lecturai = txtInicial.Text
        ch.lecturaf = txtFinal.Text
        ch.volumen = txtVolumen.Text
        ch.cloroi = txtCloroIni.Text
        ch.clorof = txtCloroFin.Text

        ch.Referencia = txtObserv.Text

        For Each r As DataGridViewRow In gridLecturas.Rows
            f = r.Cells("dFechaLectura").Value

            'If (cmbAnio.SelectedValue =FE r.Cells(2).Value And cmbMes.SelectedValue = r.Cells(3).Value) Then
            If (txtFechaL.Text = r.Cells(4).Value) Then
                flagValido = False
            End If
        Next

        If (flagValido) Then

            ch.Insert(cmbJunta.SelectedValue, cmbEstructura.SelectedValue, idlectura, cmbAnio.Text, cmbMes.SelectedValue, FECHA, ch.UsuarioSys)

            CARGAGRIDLECTURAS()
            btnNuevo.Enabled = True
            btnEliminar.Enabled = True
        Else
            MsgBox("Ya se ha registrado Lectura para este Año y Mes", MsgBoxStyle.Exclamation)
        End If

    End Sub

    Private Sub ButtonItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        txtInicial.Text = ""
        txtFinal.Text = ""
        txtHoras.Text = ""
        txtVolumen.Text = ""
        txtSegundos.Text = ""
        txtCloroIni.Text = ""
        txtCloroFin.Text = ""
        txtObserv.Text = ""

        cmbMes.Focus()
        btnSave.Enabled = True
        btnDelete.Enabled = False
    End Sub

    Private Sub txtAnio_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtModelo.TextChanged

    End Sub

    Private Sub cmbMes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CARGAGRIDLECTURAS()

    End Sub

    Private Sub txtFechaL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFechaL.Click
        'txtFechaInicio.Text = txtFechaL.Text
        'txtFechaFinal.Text = txtFechaL.Text
    End Sub

    Private Sub txtFechaL_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFechaL.TextChanged
        txtFechaInicio.Text = txtFechaL.Text
        txtFechaFinal.Text = txtFechaL.Text
        txtFechaInicio.Focus()
    End Sub

    Private Sub ButtonItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim flag As Boolean = True
        Dim idestructura As Integer
        Dim idlectura As Integer
        Dim anio As Integer

        Try
            If (ValidaGridItemSeleccionado(gridLecturas)) Then
                Dim ch As New clsControlHidrometrico
                Dim m = MessageBox.Show("Desea eliminar el registro seleccionado?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If (m = Windows.Forms.DialogResult.Yes) Then
                    idestructura = gridLecturas.Item(0, gridLecturas.CurrentRow.Index).Value
                    idlectura = gridLecturas.Item(1, gridLecturas.CurrentRow.Index).Value
                    anio = gridLecturas.Item(2, gridLecturas.CurrentRow.Index).Value
                    clsControlHidrometrico.delete(idestructura, idlectura, anio)
                    MsgBox("Lectura Elimidada correctamente", MsgBoxStyle.Information)
                    CARGAGRIDLECTURAS()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbMes_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbMes.Click
        
    End Sub


    Private Sub cmbMes_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMes.SelectedIndexChanged
        Try

            idmes = cmbMes.SelectedValue
            'cmbMes.SelectedValue = 1

            CARGAGRIDLECTURAS()
        Catch ex As Exception

        End Try
    End Sub
    Function DatosEstructuras()
        Try
            Dim caudal As String
            Dim tipo As String
            Dim marca As String

            Dim c As New ACCESO.Conexion
            Dim dt As New DataTable
            Dim estructura As New clsEstructura
            If (c.Connect) Then
                dt = c.Query("SELECT     iIdEstructura, vNombre, Tipo, fCaudal, Marca FROM Estructura where iIdEstructura = " & cmbEstructura.SelectedValue & " ")
                'dt = c.Query("SELECT  vIdJas, idpredio, iIdTipoTarifa, idLectura, iAnioTarifa, idMes, dFechaLectura, fLecturaM3, fLecturaLt, fVolumenTotal, fVolumenConsumo, fVolumenM3 FROM tarPrediosLecturas T1 WHERE dFechaLectura = (SELECT max(dFechaLectura)FROM tarPrediosLecturas T2 WHERE T1.idpredio=T2.idpredio)and vIdJas= " & cmbJunta.SelectedValue & " and iAnioTarifa= " & cmbAnio.SelectedValue & " and idpredio= " & idPredio & " ")
                If (dt.Rows.Count > 0) Then
                    caudal = dt.Rows(0).Item(3)
                    tipo = dt.Rows(0).Item(2)
                    marca = dt.Rows(0).Item(4)
                    txtTipo.Text = tipo
                    txtCaudal.Text = caudal
                    txtModelo.Text = marca
                End If

            End If
            c.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function
    Private Sub cmbEstructura_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbEstructura.SelectedIndexChanged

    End Sub

    Private Sub ButtonItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem3.Click

    End Sub
End Class