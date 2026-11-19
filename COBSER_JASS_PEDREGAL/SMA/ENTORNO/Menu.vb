Imports DevComponents.DotNetBar.Office2007Form
Imports COBSER.ItemMenu
'Imports ACCESO
'Imports LOGICA
Public Class Menu
    Public miMenu As New MenuStrip
    Public group As Integer
    Public valGeneral As Integer

    Public Sub New(ByVal g As Integer)
        Me.group = g
    End Sub
    Public Sub CreateMenu()
        Dim c As New ACCESO.Conexion
        Dim dt As New DataTable
        Dim cont As Integer = 0
        If (c.Connect()) Then
            dt = c.Query("select m.idMenu,m.idPMenu,vNombre from sysPermiso p,sysMenu m where m.idMenu=p.idMenu and idGrupo='" & Me.group & "' and m.idPMenu=0 and m.iToolBar=1 and m.idMenu<>'1' order by iOrden")
            'dt = c.Query("select m.idMenu,m.idPMenu,vNombre from sysPermiso p,sysMenu m where m.idMenu=p.idMenu and idGrupo='" & Me.group & "' and m.idPMenu=0  and m.idMenu<>'1' order by iOrden")
            For Each MiDataRow As DataRow In dt.Rows
                Dim rbtb As New DevComponents.DotNetBar.RibbonTabItem
                Dim rbp As New DevComponents.DotNetBar.RibbonPanel
                Dim rbb As New DevComponents.DotNetBar.RibbonBar

                rbb.AutoOverflowEnabled = True
                rbb.Dock = System.Windows.Forms.DockStyle.Fill
                rbb.Location = New System.Drawing.Point(3, 0)
                rbb.Name = "rbb_" & MiDataRow(0)
                rbb.Size = New System.Drawing.Size(443, 100)
                rbb.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
                rbb.TabIndex = 0
                rbb.Text = "Menu de Opciones"

                rbp.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
                rbp.Controls.Add(rbb)
                rbp.Dock = System.Windows.Forms.DockStyle.Fill
                rbp.Location = New System.Drawing.Point(0, 55)
                rbp.Name = "RibbonPanel2"
                rbp.Padding = New System.Windows.Forms.Padding(3, 0, 3, 0)
                rbp.Size = New System.Drawing.Size(752, 97)
                rbp.TabIndex = cont

                'rbp.Visible = False

                rbtb = New DevComponents.DotNetBar.RibbonTabItem
                rbtb.ImagePaddingHorizontal = 8
                rbtb.Name = "rbt_" & MiDataRow(0)
                rbtb.Panel = rbp
                rbtb.Text = MiDataRow(2)
                Dim mnu As New ItemMenu(MiDataRow(0), MiDataRow(1), MiDataRow(2))

                Me.CreateButtons(mnu, rbb, c)
                frmPrincipal.rbPrincipal.Controls.Add(rbp)
                frmPrincipal.rbPrincipal.Items.Add(rbtb)


            Next
            c.Close()
        End If
    End Sub
    Private Function selectImg(ByVal id) As System.Drawing.Image
        Dim obj As System.Drawing.Image = Nothing
        Select Case id

            Case 50
                'obj = Global.SIMIG.My.Resources.Resources.exportar
                obj = Global.COBSER.My.Resources.Resources.usuarios

            Case 51
                obj = Global.COBSER.My.Resources.Resources.help

            Case 52
                obj = Global.COBSER.My.Resources.Resources.gdeuda
            Case 53
                obj = Global.COBSER.My.Resources.Resources.application
            Case 56
                obj = Global.COBSER.My.Resources.Resources.reportes
            Case 57
                obj = Global.COBSER.My.Resources.Resources.reportes
            Case 60
                obj = Global.COBSER.My.Resources.Resources.tipos
            Case 64
                obj = Global.COBSER.My.Resources.Resources.config_users
            Case 65
                obj = Global.COBSER.My.Resources.Resources.sectores2
            Case 66
                obj = Global.COBSER.My.Resources.Resources.Bloques
            Case 72
                obj = Global.COBSER.My.Resources.Resources.transferencia
            Case 73
                obj = Global.COBSER.My.Resources.Resources.balance
            Case 74
                obj = Global.COBSER.My.Resources.Resources.bloques2
            Case 77
                obj = Global.COBSER.My.Resources.Resources.punto_control
            Case 78
                obj = Global.COBSER.My.Resources.Resources.reportes
            Case 81
                obj = Global.COBSER.My.Resources.Resources.transferencia

            Case 84
                obj = Global.COBSER.My.Resources.Resources.seguimiento
        End Select
        Return obj
    End Function

    Private Sub CreateButtons(ByRef mnup As ItemMenu, ByRef rbb As DevComponents.DotNetBar.RibbonBar, ByVal c As ACCESO.Conexion)
        'creo mi submenus
        Dim dt As New DataTable
        dt = c.Query("select m.idMenu,m.idPMenu,vNombre from sysPermiso p,sysMenu m where m.idMenu=p.idMenu and idGrupo='" & Me.group & "' and m.iToolBar=1 and m.idPMenu=" & mnup.idMenu & " order by iOrden")
        'si tiene hijos
        If (dt.Rows.Count > 0) Then
            'para cada hijo
            For Each MiDataRow As DataRow In dt.Rows
                Dim btn As New DevComponents.DotNetBar.ButtonItem
                btn.Image = selectImg(MiDataRow(0))
                btn.ImagePaddingHorizontal = 75
                btn.ImageFixedSize = New Size(32, 32)
                btn.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
                btn.Name = "btn_" & MiDataRow(0)
                btn.SubItemsExpandWidth = 14
                btn.Text = MiDataRow(2)
                AddHandler btn.Click, AddressOf Me.MenuClick
                rbb.Items.Add(btn)
                Dim itemMenu = New ItemMenu(MiDataRow(0), MiDataRow(1), MiDataRow(2))
                Me.CreateSubMenus(itemMenu, btn, c)
            Next
        End If
    End Sub


    Private Sub CreateSubMenus(ByRef mnup As ItemMenu, ByRef rbb As DevComponents.DotNetBar.ButtonItem, ByVal c As ACCESO.Conexion)
        'creo mi submenus
        Dim dt As New DataTable
        dt = c.Query("select m.idMenu,m.idPMenu,vNombre from sysPermiso p,sysMenu m where m.idMenu=p.idMenu and idGrupo='" & Me.group & "' and m.iToolBar=1 and m.idPMenu=" & mnup.idMenu & " order by iOrden")
        'si tiene hijos
        If (dt.Rows.Count > 0) Then
            'para cada hijo
            For Each MiDataRow As DataRow In dt.Rows
                Dim btn As New DevComponents.DotNetBar.ButtonItem
                btn.Image = selectImg(MiDataRow(0))
                btn.ImagePaddingHorizontal = 60
                btn.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
                btn.Name = "btn_" & MiDataRow(0)
                btn.SubItemsExpandWidth = 14
                btn.Text = MiDataRow(2)
                If valGeneral = 1 Then
                    btn.Enabled = False
                End If
                AddHandler btn.Click, AddressOf Me.MenuClick
                rbb.SubItems.Add(btn)
                Dim itemMenu = New ItemMenu(MiDataRow(0), MiDataRow(1), MiDataRow(2))
                Me.CreateSubMenus(itemMenu, btn, c)
            Next
        End If
    End Sub
    Public Shared Function VerificaPermiso(ByVal idmenu As Integer, ByVal grupo As Integer) As Boolean
        Dim c As New ACCESO.Conexion
        Dim dt As New DataTable
        Dim flag As Boolean = False
        If (c.Connect()) Then
            dt = c.Query("select idMenu from sysPermiso where idGrupo='" & grupo & "' and idMenu='" & idmenu & "'")
            If (dt.Rows.Count > 0) Then
                flag = True
            End If
            c.Close()
        End If
        Return flag
    End Function

    Public Sub CreateButtonsStart()
        'creo mi submenus
        Dim c As New ACCESO.Conexion
        If (c.Connect) Then

        End If
        Dim dt As New DataTable
        dt = c.Query("select m.idMenu,m.idPMenu,vNombre from sysPermiso p,sysMenu m where m.idMenu=p.idMenu and idGrupo='" & Me.group & "' and m.iToolBar=1 and m.idPMenu=1 order by iOrden")
        'si tiene hijos
        If (dt.Rows.Count > 0) Then
            'para cada hijo
            For Each MiDataRow As DataRow In dt.Rows
                Dim btn As New DevComponents.DotNetBar.ButtonItem
                btn.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
                btn.Image = selectImg(MiDataRow(0))
                btn.ImagePaddingHorizontal = 8
                btn.Name = "btn_" & MiDataRow(0)
                btn.Text = MiDataRow(2)

                AddHandler btn.Click, AddressOf Me.MenuClick
                frmPrincipal.itmContStart2.SubItems.Add(btn)
                Dim itemMenu = New ItemMenu(MiDataRow(0), MiDataRow(1), MiDataRow(2))
                Me.CreateSubMenusStart(itemMenu, btn, c)
            Next
        End If
    End Sub
    Private Sub CreateSubMenusStart(ByRef mnup As ItemMenu, ByRef rbb As DevComponents.DotNetBar.ButtonItem, ByVal c As ACCESO.Conexion)
        'creo mi submenus
        Dim dt As New DataTable
        dt = c.Query("select m.idMenu,m.idPMenu,vNombre from sysPermiso p,sysMenu m where m.idMenu=p.idMenu and idGrupo='" & Me.group & "' and m.iToolBar=1 and m.idPMenu=" & mnup.idMenu & " order by iOrden")
        'si tiene hijos
        If (dt.Rows.Count > 0) Then
            'para cada hijo
            For Each MiDataRow As DataRow In dt.Rows
                Dim btn As New DevComponents.DotNetBar.ButtonItem
                btn.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
                btn.Image = selectImg(MiDataRow(0))
                btn.ImagePaddingHorizontal = 8
                btn.Name = "btn_" & MiDataRow(0)
                btn.Text = MiDataRow(2)

                AddHandler btn.Click, AddressOf Me.MenuClick
                rbb.SubItems.Add(btn)
                Dim itemMenu = New ItemMenu(MiDataRow(0), MiDataRow(1), MiDataRow(2))
                Me.CreateSubMenus(itemMenu, btn, c)
            Next
        End If
    End Sub



    Private Sub MenuClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo xerr
        Dim OpcionSeleccionada As DevComponents.DotNetBar.ButtonItem = CType(sender, DevComponents.DotNetBar.ButtonItem)
        Select Case OpcionSeleccionada.Name.ToString.Substring(4)

            Case 2 'grupos
                frmSysGrupos.MdiParent = frmPrincipal
                frmSysGrupos.Show()
                frmSysGrupos.Focus()

            Case 3 'usuarios
                frmSysUsuarios.MdiParent = frmPrincipal
                frmSysUsuarios.Show()
                frmSysUsuarios.Focus()
            Case 4 'juntas
                frmJuntas.MdiParent = frmPrincipal
                frmJuntas.Show()
                frmJuntas.Focus()
                '------------------------------------------------------------------------ Utilidades
            Case 6 'contrasenia
                frmMyPasswordUpd.MdiParent = frmPrincipal
                frmMyPasswordUpd.Show()
                frmMyPasswordUpd.Focus()
            Case 7 'sesion
                frmSesionClose.MdiParent = frmPrincipal
                frmSesionClose.Show()
                frmSesionClose.Focus()
            Case 8 'backup
                frmBackup.MdiParent = frmPrincipal
                frmBackup.Show()
                frmBackup.Focus()
            Case 9 'interfases
                frmAdminInterfaces.MdiParent = frmPrincipal
                frmAdminInterfaces.Show()
                frmAdminInterfaces.Focus()
                '--------------------------------------------------------------------- Mantenimiento
            



                '--------------------------------------------------------------------- Apertura
                'Case 16 'apertura
                '    frmAperturaAnio.MdiParent = frmPrincipal
                '    frmAperturaAnio.Show()
                '    frmAperturaAnio.Focus()
                'Case 17 'Exportar Apertura
            Case 18 'Exportar Apertura
                '--------------------------------------------------------------------- Programacion y monitoreo

           
            Case 22 'Exportar 
                frmExportar.ShowDialog()
            Case 23 'Importar
                frmImportar.ShowDialog()
                '---------------------------------------------------------------------Tablero
          
                '---------------------------------------------------------------------Reportes
                '---------------------------------------------------------------------Reportes
            Case 28 ' rpt Por Capacidad
                ''FrmRptEvalPorCapacidad.MdiParent = frmPrincipal
                ''FrmRptEvalPorCapacidad.Show()
                ''FrmRptEvalPorCapacidad.Focus()
                frmRptIndicadores.MdiParent = frmPrincipal
                frmRptIndicadores.Show()
                frmRptIndicadores.Focus()

                'Case 29 ' rpt Indice de Gestion
                '    'FrmRptEvalIndiceDeGestion.MdiParent = frmPrincipal
                '    'FrmRptEvalIndiceDeGestion.Show()
                '    'FrmRptEvalIndiceDeGestion.Focus()
                '    FrmReportesPadron.MdiParent = frmPrincipal
                '    FrmReportesPadron.Show()
                '    FrmReportesPadron.Focus()
           
          
         
          
            Case 38 ' rptHoja de Campo Sin Datos
                FrmRptHojaApoyoSinDatos.MdiParent = frmPrincipal
                FrmRptHojaApoyoSinDatos.Show()
                FrmRptHojaApoyoSinDatos.Focus()
           


                '---------------------------------------------------------------------
            Case 41 ' glosario
                Process.Start("GLOSARIO DE TERMINO.pdf") ' y listo
            Case 42 ' manual
                Process.Start("MANUAL DE USUARIO SMA.pdf") ' y listo
           
           
           
            Case 50 'Usuarios de servicio
                frmUsuarios.MdiParent = frmPrincipal
                frmUsuarios.Show()
                frmUsuarios.Focus()
            Case 51 'Predis de servicio
                frmPredios.MdiParent = frmPrincipal
                frmPredios.Show()
                frmPredios.Focus()

            Case 53 'COBRANZA DE DEUDAS
                frmCobranza.MdiParent = frmPrincipal
                frmCobranza.Show()
                frmCobranza.Focus()
            Case 54 'DEUDAS ANTERIORES
                frmDeudaAnterior.MdiParent = frmPrincipal
                frmDeudaAnterior.Show()
                frmDeudaAnterior.Focus()
            Case 55 'DEUDAS ANTERIORES
                frmRegistrarVolumenSinLectura.MdiParent = frmPrincipal
                frmRegistrarVolumenSinLectura.Show()
                frmRegistrarVolumenSinLectura.Focus()
                'Case 55 'generar Facturacion DA
                '    frmGenerarFacturacion.MdiParent = frmPrincipal
                '    frmGenerarFacturacion.Show()
                '    frmGenerarFacturacion.Focus()

            Case 58 'REPORTES DE PADRON
                FrmRptHojaApoyoSinDatos.MdiParent = frmPrincipal
                FrmRptHojaApoyoSinDatos.Show()
                FrmRptHojaApoyoSinDatos.Focus()
            Case 59 'REPORTES DE DEUDAS
                FrmRpt_TarDeudas.MdiParent = frmPrincipal
                FrmRpt_TarDeudas.Show()
                FrmRpt_TarDeudas.Focus()
            Case 61 'TARIFAS AÑOS
                frmTarifasAnios.MdiParent = frmPrincipal
                frmTarifasAnios.Show()
                frmTarifasAnios.Focus()
            Case 62 'TIPOS DE SERVICCIOS
                frmServicios.MdiParent = frmPrincipal
                frmServicios.Show()
                frmServicios.Focus()

            Case 63 'TIPOS DE SERVICCIOS
                frmCostosTarifas.MdiParent = frmPrincipal
                frmCostosTarifas.Show()
                frmCostosTarifas.Focus()
            Case 66 'asignar medidores
                frmSector.MdiParent = frmPrincipal
                frmSector.Show()
                frmSector.Focus()
            Case 65 'asignar medidores
                frmCalles.MdiParent = frmPrincipal
                frmCalles.Show()
                frmCalles.Focus()
            Case 67 'generar deudas SERICIOS MENSUALES
                frmGenerarDeudasMensuales.MdiParent = frmPrincipal
                frmGenerarDeudasMensuales.Show()
                frmGenerarDeudasMensuales.Focus()

            Case 68 'generar deudas SERICIOS UNICAS
                frmGenerarDeudasUnicas.MdiParent = frmPrincipal
                frmGenerarDeudasUnicas.Show()
                frmGenerarDeudasUnicas.Focus()

            Case 69 'generar deudas VOLUMEN
                frmGenerarDeudasVolumen.MdiParent = frmPrincipal
                frmGenerarDeudasVolumen.Show()
                frmGenerarDeudasVolumen.Focus()

            Case 70 'COBRANZA DE FACTURACIONES
                frmCobranza.MdiParent = frmPrincipal
                frmCobranza.Show()
                frmCobranza.Focus()

            Case 71 'COBRANZA OTROS SERVICIOS
                frmOtrosIngresos.MdiParent = frmPrincipal
                frmOtrosIngresos.Show()
                frmOtrosIngresos.Focus()
            Case 72 'ASOCIAR SERVICIOS
                frmPrediosServicios.MdiParent = frmPrincipal
                frmPrediosServicios.Show()
                frmPrediosServicios.Focus()

            Case 73 'registrar lecturas
                frmRegistrarLecturas.MdiParent = frmPrincipal
                frmRegistrarLecturas.Show()
                frmRegistrarLecturas.Focus()
            Case 74 'generar Facturacion DA
               
                frmFacturacion.MdiParent = frmPrincipal
                frmFacturacion.Show()
                frmFacturacion.Focus()

            Case 75 'Reporte de facturaciones

                frmRpt_TarFacturaciones.MdiParent = frmPrincipal
                frmRpt_TarFacturaciones.Show()
                frmRpt_TarFacturaciones.Focus()
            Case 76 'reporte de conranzas
                frmRpt_TarCobranzas.MdiParent = frmPrincipal
                frmRpt_TarCobranzas.Show()
                frmRpt_TarCobranzas.Focus()
            Case 77 'reporte de conranzas
                frmControlHidrometrico.MdiParent = frmPrincipal
                frmControlHidrometrico.Show()
                frmControlHidrometrico.Focus()
            Case 79 'reporte de conranzas
                frmRpt_Lecturas.MdiParent = frmPrincipal
                frmRpt_Lecturas.Show()
                frmRpt_Lecturas.Focus()

            Case 81 'reporte de conranzas
                frmTransferenciaPredios.MdiParent = frmPrincipal
                frmTransferenciaPredios.Show()
                frmTransferenciaPredios.Focus()
            Case 82 'reporte de conranzas
                frmGenerarInteres.MdiParent = frmPrincipal
                frmGenerarInteres.Show()
                frmGenerarInteres.Focus()


            Case 83 'Generar deuda volumen alcantarillado
                frmGenerarDeudasVolumenAlcantarillado.MdiParent = frmPrincipal
                frmGenerarDeudasVolumenAlcantarillado.Show()
                frmGenerarDeudasVolumenAlcantarillado.Focus()

            Case 84 'control de asabmlbeas
                frmAsistenciaUsuarios.MdiParent = frmPrincipal
                frmAsistenciaUsuarios.Show()
                frmAsistenciaUsuarios.Focus()

            Case 85 'Registro Aasambleas
                frmAsambleas.MdiParent = frmPrincipal
                frmAsambleas.Show()
                frmAsambleas.Focus()
        End Select
xerr:
        If Err.Number <> 0 Then
            Resume
        End If

    End Sub
End Class
