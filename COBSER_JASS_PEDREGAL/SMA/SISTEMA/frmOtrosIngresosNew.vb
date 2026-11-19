Imports ACCESO
Imports LOGICA
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Data.OleDb

Public Class frmOtrosIngresosNew
    Public c As New ACCESO.Conexion
    Public idjunta As String
    Public idcp As Integer
    Public caja As Integer
    Public nrorecibo As String



    Private Sub frmOtrosIngresosNew_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        clsTipoIngreso.LoadCombo(cmbTipoIngreso)
        cmbTipoIngreso.SelectedValue = frmOtrosIngresos.cmbTipoIngreso.SelectedValue
        clsTipoIngreso.LoadComboTipoDoc(cmbDocPago)
        cmbDocPago.SelectedValue = 1

        cmbAlquiler.SelectedIndex = 0

        lblFecha.Text = ACCESO.Conexion.getDateServer
        txtCaja.Text = frmPrincipal.lblCaja.Text
        'cmbCaja.SelectedValue = frmPrincipal.cajaSystem.id
        getNewCorrelativo()

        txtUsuario.Text = ""
        txtDNI.Text = ""
        txtRUC.Text = ""
        txtConcepto.Text = ""
        txtDireccion.Text = ""
        txtDias.Text = ""
        txtCantidad.Text = ""
        txtMonto.Text = ""
        txtObserva.Text = ""


    End Sub
   
    Private Function ultimoRecibo()
        Dim c As New ACCESO.Conexion
        Dim dt As New DataTable
        Dim idre As String
        If (c.Connect) Then
            dt = c.Query("select isNull(max(vNroDocumento),0)  as Recibo from tarIngresosOtros")
            c.Close()
            idre = dt.Rows(0).Item(0)
        End If
        Return idre


    End Function
    Private Function obtnernro()
        Dim c As New ACCESO.Conexion
        Dim dt As New DataTable
        Dim id As String

        'Dim corre As String
        If (c.Connect) Then
            dt = c.Query("select isNull(max(vNroDocumento),0) from tarIngresosOtros")
            id = dt.Rows(0).Item(0) + 1
            id = id.PadLeft(5, "0") & "-" & Year(Date.Now())
            txtNroDoc1.Text = id

            c.Close()
        End If
        'Return id

    End Function
    Public Function getNewCorrelativo()
        Dim dt As New DataTable
        Dim total As Integer = 0
        Dim correlativo As String
        Dim nrodoc As String
        If (c.Connect) Then
            dt = c.Query("SELECT isNull(max(vNroDocumento),'0') from tarIngresosOtros ")
            nrodoc = dt.Rows(0).Item(0)
            If (nrodoc <> "0") Then
                correlativo = Val(nrodoc.Substring(5))
                correlativo += 1
            Else
                correlativo = 1
            End If

            'nrorecibo = correlativo.PadLeft(5, "0") & "-" & Year(Date.Now())

            nrorecibo = Year(Date.Now()) & "-" & correlativo.PadLeft(6, "0")
            txtNroDoc1.Text = nrorecibo
            If (c.msgError <> "") Then
                MsgBox(c.msgError)
            End If
            c.Close()
        End If
        Return correlativo
    End Function



    Private Sub txtUsuario_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUsuario.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            txtDNI.Focus()
        End If
    End Sub

    Private Sub txtUsuario_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUsuario.TextChanged

    End Sub



    Private Sub GroupPanel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupPanel.Click

    End Sub

    Private Sub txtDNI_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDNI.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            txtRUC.Focus()
        End If
    End Sub

    Private Sub txtDNI_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDNI.TextChanged

    End Sub

    Private Sub txtRUC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRUC.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            txtDireccion.Focus()
        End If
    End Sub

    Private Sub txtRUC_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRUC.TextChanged

    End Sub

    Private Sub txtDireccion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDireccion.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            cmbAlquiler.Focus()
        End If

    End Sub

    Private Sub txtDireccion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDireccion.TextChanged

    End Sub

    Private Sub cmbAlquiler_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbAlquiler.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            cmbDocPago.Focus()
        End If
    End Sub

    Private Sub cmbAlquiler_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAlquiler.SelectedIndexChanged

    End Sub

    Private Sub cmbDocPago_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbDocPago.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            txtDias.Focus()
        End If
    End Sub

    Private Sub cmbDocPago_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDocPago.SelectedIndexChanged

    End Sub

    Private Sub txtNroDoc1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNroDoc1.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            txtDias.Focus()
        End If
    End Sub

    Private Sub txtNroDoc1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNroDoc1.TextChanged

    End Sub

    Private Sub txtNHoras_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDias.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            txtCantidad.Focus()
        End If
    End Sub

    Private Sub txtNHoras_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDias.TextChanged

    End Sub

    Private Sub txtContrato1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCantidad.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            txtConcepto.Focus()
        End If
    End Sub

    Private Sub txtContrato1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCantidad.TextChanged

    End Sub

    Private Sub txtMonto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMonto.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            txtObserva.Focus()
        End If
    End Sub

    Private Sub txtMonto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMonto.TextChanged

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            idjunta = frmOtrosIngresos.cmbJunta.SelectedValue
            idcp = frmOtrosIngresos.cmbCPoblado.SelectedValue
            caja = frmPrincipal.lblCaja.Id
            Dim OI As New clsOtrosIngresos(idjunta, idcp, caja, 1, lblFecha.Text, txtNroDoc1.Text, cmbTipoIngreso.SelectedValue, cmbDocPago.SelectedValue, txtMonto.Text, txtConcepto.Text, txtUsuario.Text, txtDNI.Text, txtRUC.Text, txtDireccion.Text, 0, txtObserva.Text, cmbAlquiler.SelectedIndex, txtDias.Text, txtCantidad.Text)
            If c.Connect Then
                OI.Insert()
                'dgCalles.DataSource = clsCalles.List
            End If
            'ReciboF = dgFacturaciones.SelectedRows(0).Cells(13).Value
            txtNroDoc1.Text = nrorecibo

            frmRecibos.Nrorecibo = nrorecibo

            frmRecibos.TIPO = 2
            frmRecibos.Show()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtConcepto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtConcepto.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            txtMonto.Focus()
        End If
    End Sub

    Private Sub txtConcepto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtConcepto.TextChanged

    End Sub

    Private Sub txtObserva_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtObserva.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            btnSave.Focus()
        End If
    End Sub

    Private Sub txtObserva_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtObserva.TextChanged

    End Sub
End Class