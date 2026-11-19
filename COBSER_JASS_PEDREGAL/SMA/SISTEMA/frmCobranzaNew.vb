
Imports ACCESO
Imports LOGICA
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Data.OleDb

Public Class frmCobranzaNew
    Public sUsuario As String
    Public sDNI As String
    Public IdPredio As Integer
    Public sPredio As String
    Public Snro As String
    Public Anio As String

    Dim _tarifa As New clsAnioTarifa
    'Dim dt As New DataTable

    Private Sub frmCobranzaNew_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        clsJunta.LoadCombo(cmbJunta)
        Dim dtTarifas As New DataTable
        If (frmPrincipal.userSystem.idInterfaz = 4) Then
            cmbJunta.SelectedValue = frmPrincipal.userSystem.idJunta
            cmbJunta.Enabled = False
        End If
        Limpiardatos()

       
        clsAnioTarifa.LoadComboADD(cmbAnio)

        txtAnioVigente.Text = _tarifa.getTarifaActual.anio

        lblCaja.Text = clsCaja.obtenerCaja.nombre

        txtUsuario.Text = sUsuario
        txtDni.Text = sDNI
        txtPredio.Text = sPredio
        txtNro.Text = Snro
        lblFecha.Text = Format(Date.Now(), "dd/MM/yyyy")
        cargatree(0)

        clsTipoPago.LoadCombo(cmbTipoPago)
        cmbTipoPago.SelectedValue = 1
        chkSelectAll.Checked = False
        
        'clsTipoDeudaPredio.LoadCombo(cmbTipoDeuda, , True)
        'cmbTipoDeuda.SelectedValue = 0
    End Sub
    Private Sub cargatree(ByVal criterioanio As Integer)
        Dim objCobranza As New clsCobranza

        objCobranza.ListTree(tvDeudas, IdPredio, criterioanio)
        

    End Sub

    Private Sub tvDeudas_AfterCellEditComplete(ByVal sender As Object, ByVal e As DevComponents.AdvTree.CellEditEventArgs) Handles tvDeudas.AfterCellEditComplete

    End Sub
    Private Sub tvDeudas_AfterCheck(ByVal sender As Object, ByVal e As DevComponents.AdvTree.AdvTreeCellEventArgs) Handles tvDeudas.AfterCheck
        CalculaMonto()
    End Sub

    Private Sub CalculaMonto()
        Dim sumaMonto As Double = 0
        Dim sumainteres As Double = 0
        Dim sumaSaldo As Double = 0

        Dim sumaMtotal As Double = 0
        Dim IdFacturas(tvDeudas.Nodes.Count) As String
        Dim i As Integer = 0
        For Each nodo As DevComponents.AdvTree.Node In tvDeudas.Nodes  '    
            'tvDeudas.SelectedNode = tvDeudas.Nodes(nodo.Index)
            If tvDeudas.Nodes(nodo.Index).Checked Then
                sumaMonto = sumaMonto + CDbl(tvDeudas.Nodes(nodo.Index).Cells(3).Text)
                sumainteres = sumainteres + CDbl(tvDeudas.Nodes(nodo.Index).Cells(5).Text)
                sumaMtotal = sumaMtotal + CDbl(tvDeudas.Nodes(nodo.Index).Cells(3).Text)
                sumaSaldo = sumaSaldo + CDbl(tvDeudas.Nodes(nodo.Index).Cells(4).Text)

                IdFacturas(i) = "'" & tvDeudas.Nodes(nodo.Index).Cells(2).Text & "'" '& "-" & tvDeudas.Nodes(nodo.Index).Cells(0).Text & "-" & tvDeudas.Nodes(nodo.Index).Cells(1).Text

                i = i + 1
            End If
        Next
        ' carga de datos de pago
        lblPagoDeuda.Text = FormatCurrency(sumaMonto, 2)
        lblPagoInteres.Text = FormatCurrency(sumainteres, 2)
        'lblPagoInteres.Text = FormatCurrency(interesT, 2)

        lblPagoTotal.Text = FormatCurrency(sumaMtotal, 2)
        lblMonto.Text = FormatCurrency(sumaSaldo, 2)
        lblPagoTotalRedondeo.Text = FormatCurrency(sumaMonto, 2)
        ' control de activación del boton de cobrar
        If sumaMonto > 0 Then
            btnSave.Enabled = True
        Else
            btnSave.Enabled = False
        End If

        txtObservaciones.Text = ""
        For fila = 0 To IdFacturas.Length - 1
            If (fila = 0) Then
                txtObservaciones.Text = txtObservaciones.Text & IdFacturas(fila)
            Else
                If Not (IdFacturas(fila) = Nothing) Then
                    txtObservaciones.Text = txtObservaciones.Text & "," & IdFacturas(fila)
                End If
            End If
        Next
    End Sub

    Private Sub txtObservaciones_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtObservaciones.TextChanged

    End Sub

    Private Sub chkSelectAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSelectAll.CheckedChanged
        If chkSelectAll.Checked Then
            For Each nodo As DevComponents.AdvTree.Node In tvDeudas.Nodes  '    
                tvDeudas.Nodes(nodo.Index).Checked = True
            Next
        Else
            For Each nodo As DevComponents.AdvTree.Node In tvDeudas.Nodes  '    
                tvDeudas.Nodes(nodo.Index).Checked = False
            Next

        End If
        CalculaMonto()
    End Sub

    Private Sub cmbTipoPago_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipoPago.SelectedIndexChanged
        Try
            If cmbTipoPago.SelectedValue = 1 Then
                txtReferencia.Text = ""
                txtReferencia.Enabled = False
            Else
                txtReferencia.Text = ""
                txtReferencia.Enabled = True
                txtReferencia.Focus()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub tvDeudas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tvDeudas.Click
        'txtReferencia.Focus()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim obj As New clsPago
        Dim numerror As String
        Dim montos As Double
        numerror = ""
        obj.IdJAS = cmbJunta.SelectedValue
        frmRecibos.ranio = txtAnioVigente.Text
        obj.IdCaja = clsCaja.obtenerCaja.id

        obj.NroDocumento = "P" & txtAnioVigente.Text
        obj.IdPredio = IdPredio
        obj.Fecha = Format(Date.Now(), "dd/MM/yyyy") ' Fecha actual
        obj.TipoPago = cmbTipoPago.SelectedValue
        obj.Monto = FormatCurrency(lblMonto.Text, 2)
        obj.Interes = FormatCurrency(lblPagoInteres.Text, 2)
        obj.MontoTotal = FormatCurrency(lblPagoTotalRedondeo.Text, 2)
        obj.Redondeo = FormatCurrency(0, 2)
        obj.Anulado = 0
        obj.Observaciones = txtObservaciones.Text
        obj.Usuario = frmPrincipal.userSystem.usuario
        obj.Referencia = txtReferencia.Text
        'For Each nodo As DevComponents.AdvTree.Node In tvDeudas.Nodes
        '    montos = nodo.Cells(3).Text.ToStringE
        '    If (nodo.Checked) Then

        If Not obj.Insert(txtObservaciones.Text) Then
            'If obj.Insert(txtObservaciones.Text, montos) Then
            numerror = numerror & "Pago del predio " & txtPredio.Text & " del usuario " & txtUsuario.Text & " no se genero correctamente" & Chr(13)
        End If

        '    End If
        'Next
        If numerror.Length > 0 Then
            MsgBox("Ocurrio un error mientras se generaba el pago. Se cancelo el proceso " & Chr(13) & numerror, MsgBoxStyle.Critical)
        Else
            MsgBox("Pago se genero correctamente", MsgBoxStyle.Information)
            cargatree(0)
        End If

        frmRecibos.Nrorecibo = ultimoRecibo()
        Limpiardatos()
        'Call ultimoRecibo()


        frmRecibos.Show()

    End Sub
    Sub Limpiardatos()
        btnSave.Enabled = False
        lblPagoDeuda.Text = ""
        lblPagoTotal.Text = ""
        lblMonto.Text = ""
        txtObservaciones.Text = ""
        txtUsuario.Text = ""
        txtPredio.Text = ""
        lblPagoTotalRedondeo.Text = ""
        lblPagoInteres.Text = ""


    End Sub
    Private Sub txtPredio_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txtReferencia_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtReferencia.TextChanged

    End Sub

    Private Sub LabelX9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LabelX9.Click

    End Sub

    Private Sub cmbAnio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAnio.SelectedIndexChanged
        Try

            cargatree(cmbAnio.SelectedValue)
            'cargatree(Anio)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub ButtonX1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX1.Click
        frmReportes.optionRPT = 0
        frmReportes.idjas = cmbJunta.SelectedValue
        frmReportes.idPredio = Me.IdPredio
        frmReportes.ShowDialog()
    End Sub
    Private Function ultimoRecibo()
        Dim c As New ACCESO.Conexion
        Dim dt As New DataTable
        Dim idre As String
        If (c.Connect) Then
            dt = c.Query("select isNull(max(vNroDocumento),0)  as Recibo from tarPago ")
            c.Close()
            idre = dt.Rows(0).Item(0)
        End If
        Return idre


    End Function

    Private Sub Bar3_ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bar3.ItemClick

    End Sub

    Private Sub lblPagoDeuda_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblPagoDeuda.Click

    End Sub

    Private Sub lblRedondeo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblMonto.Click

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

    End Sub
End Class