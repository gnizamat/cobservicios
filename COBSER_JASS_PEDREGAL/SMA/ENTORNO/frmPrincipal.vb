Imports System.Windows.Forms
Imports COBSER.Menu
Imports LOGICA
Public Class frmPrincipal

    Dim mimenu As New MenuStrip()
    Public userSystem As New ACCESO.User
    Public grupoSystem As New ACCESO.Grupo
    Public IPLOCAL As String

    Private Sub frmPrincipal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim interfaz As String = ""
        Dim miMenu As New COBSER.Menu(userSystem.idGrupo) 'creo un objeto menu asignandole el grupo al que pertenece

        miMenu.CreateButtonsStart()
        miMenu.CreateMenu()

        Me.rbPrincipal.SelectFirstVisibleRibbonTab()

        Select Case userSystem.idInterfaz
            'Case 1
            '    interfaz = "ADMINISTRADOR"
            'Case 2
            '    interfaz = "ALA"
            'Case 3
            '    interfaz = "JUNTA DE USUARIOS"
            Case 4
                interfaz = "CP PEDREGAL GRANDE"

        End Select

        grupoSystem = ACCESO.Grupo.load(userSystem.idGrupo)

        Me.Text = Me.Text & " - " & interfaz
        lblUsuario.Text = "Usuario: " & userSystem.usuario
        lblGrupo.Text = "Grupo: " & grupoSystem.nombre
        lblFecha.Text = "Fecha: " & ACCESO.Conexion.getDateServer
        ' ''lblCaja.Text = clsCaja.obtenerCaja.nombre
        lblCaja.Text = "Caja: " & clsCaja.obtenerCaja.nombre


    End Sub

    Private Sub btnGray_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGray.Click
        RibbonControl.Office2007ColorTable = DevComponents.DotNetBar.Rendering.eOffice2007ColorScheme.Silver
    End Sub

    Private Sub ButtonItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItem3.Click
        RibbonControl.Office2007ColorTable = DevComponents.DotNetBar.Rendering.eOffice2007ColorScheme.Blue
    End Sub

    Private Sub btnBlack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBlack.Click
        RibbonControl.Office2007ColorTable = DevComponents.DotNetBar.Rendering.eOffice2007ColorScheme.Black
    End Sub

    Private Sub rbPrincipal_AfterRibbonPanelPopup(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbPrincipal.AfterRibbonPanelPopup

    End Sub



    Private Sub rbPrincipal_SelectedRibbonTabChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbPrincipal.SelectedRibbonTabChanged
        Dim dt As New DataTable
        Dim EstadoDatosGenerales As Integer
        Dim rbtb As New DevComponents.DotNetBar.RibbonTabItem
        Dim rbp As New DevComponents.DotNetBar.RibbonPanel
        Dim rbb As New DevComponents.DotNetBar.RibbonBar
        Try

            If (rbPrincipal.SelectedRibbonTabItem.Name) = "rbt_24" Then
                rbtb = rbPrincipal.SelectedRibbonTabItem
                rbp = rbtb.Panel
                rbb = rbp.Controls.Item(0)

                'verificamos si hay que activar el menu
                dt = clsAperturaAnio.Valida_DatosGenerales("WHERE vIdJuntaUsuario=" & grupoSystem.idJunta & " AND iIdComisionRegante=" & grupoSystem.idComision & " AND Estado='Activo'")
                EstadoDatosGenerales = IIf(dt.Rows(0).Item(12).ToString = "Activo", 1, 0)
                If EstadoDatosGenerales = 1 Then
                    MsgBox("Debe Guardar definitivo para entrar a esta opcion", MsgBoxStyle.Information, Me.Text)
                    rbb.Items("btn_25").Enabled = False
                    rbb.Items("btn_44").Enabled = False
                Else
                    rbb.Items("btn_25").Enabled = True
                    rbb.Items("btn_44").Enabled = True
                End If

            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub rbPrincipal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbPrincipal.Click

    End Sub
End Class
