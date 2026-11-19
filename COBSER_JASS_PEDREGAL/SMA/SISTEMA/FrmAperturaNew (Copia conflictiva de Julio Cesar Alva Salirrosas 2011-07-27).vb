Imports ACCESO
Imports LOGICA

Public Class FrmAperturaNew
    Private _idJU As String
    Private _idCR As Integer
    Private _nom As String

    Public Property NombreOrganizacion()
        Get
            Return Me._nom
        End Get
        Set(ByVal value)
            Me._nom = value
        End Set
    End Property

    Public Property IdJU()
        Get
            Return Me._idJU
        End Get
        Set(ByVal value)
            Me._idJU = value
        End Set
    End Property

    Public Property IdCR()
        Get
            Return Me._idCR
        End Get
        Set(ByVal value)
            Me._idCR = value
        End Set
    End Property

  

    Private Sub FrmAperturaNew_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblOrganizacion.Text = "<b><font size='+6'><i>Organizacion : </i><font color='#B02B2C'>" & Me._nom & "</font></font></b>"
        txtAnio.Value = Year(Now)
        txtMetasLargoPlazo.Text = Nothing
        dtFechaIni.Text = ""
        dtFechaFin.Text = ""
        cboVol.Items.Clear()

        cboVol.Items.Add("m3")
        cboVol.Items.Add("mmm")
        cboVol.Text = ""

    End Sub

   

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Dim ObjApr As New clsAperturaAnio
        Try

            ObjApr.IdJunta = Me._idJU
            ObjApr.IdComision = Me._idCR
            ObjApr.Anio = txtAnio.Value
            If rbtTUI.Checked Then ObjApr.ExisteTUI_MAY = 1 Else ObjApr.ExisteTUI_MAY = 0
            ObjApr.AniosMetasLargoPlazo = txtMetasLargoPlazo.Value
            ObjApr.FechaIni_Camp = dtFechaIni.Value
            ObjApr.Fechafin_Camp = dtFechaFin.Value
            ObjApr.ValorActualTarifa = cboVol.SelectedIndex   'txtValorActual.Value
            ObjApr.ValorRealTarifa = txtValorReal.Value
            If ObjApr.Insert = False Then
                MsgBox(ObjApr.msgError, MsgBoxStyle.Information, Me.Text)
            Else

                MsgBox("Datos guardados satisfactoriamente", MsgBoxStyle.Information, Me.Text)
            End If
            Me.Close()
        Catch ex As Exception
            MsgBox(Err.Description, MsgBoxStyle.Exclamation, Me.Text)
        End Try

    End Sub
End Class