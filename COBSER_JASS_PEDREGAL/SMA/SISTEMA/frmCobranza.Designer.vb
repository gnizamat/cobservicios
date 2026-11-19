<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCobranza
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.TabControl1 = New DevComponents.DotNetBar.TabControl
        Me.TabControlPanel2 = New DevComponents.DotNetBar.TabControlPanel
        Me.txtAnioVigente = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.lblTotalRecibido = New DevComponents.DotNetBar.LabelX
        Me.LabelX22 = New DevComponents.DotNetBar.LabelX
        Me.lblRedondeo = New DevComponents.DotNetBar.LabelX
        Me.LabelX20 = New DevComponents.DotNetBar.LabelX
        Me.LabelX11 = New DevComponents.DotNetBar.LabelX
        Me.LabelX15 = New DevComponents.DotNetBar.LabelX
        Me.lblMontoTotal = New DevComponents.DotNetBar.LabelX
        Me.txtFFin = New DevComponents.Editors.DateTimeAdv.DateTimeInput
        Me.LabelX21 = New DevComponents.DotNetBar.LabelX
        Me.txtFInicio = New DevComponents.Editors.DateTimeAdv.DateTimeInput
        Me.lblInteres = New DevComponents.DotNetBar.LabelX
        Me.LabelX19 = New DevComponents.DotNetBar.LabelX
        Me.lblMonto = New DevComponents.DotNetBar.LabelX
        Me.LabelX17 = New DevComponents.DotNetBar.LabelX
        Me.Bar4 = New DevComponents.DotNetBar.Bar
        Me.LabelX13 = New DevComponents.DotNetBar.LabelX
        Me.cmbJuntaC = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.cmbCaja = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.LabelX14 = New DevComponents.DotNetBar.LabelX
        Me.ControlContainerItem11 = New DevComponents.DotNetBar.ControlContainerItem
        Me.ControlContainerItem12 = New DevComponents.DotNetBar.ControlContainerItem
        Me.ControlContainerItem13 = New DevComponents.DotNetBar.ControlContainerItem
        Me.ControlContainerItem14 = New DevComponents.DotNetBar.ControlContainerItem
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.btnLoadPagos = New DevComponents.DotNetBar.ButtonX
        Me.cmbTipoDeuda = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.LabelX25 = New DevComponents.DotNetBar.LabelX
        Me.cmbTipoPago = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.LabelX24 = New DevComponents.DotNetBar.LabelX
        Me.txtNroDocumento = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.LabelX18 = New DevComponents.DotNetBar.LabelX
        Me.Bar5 = New DevComponents.DotNetBar.Bar
        Me.btnPreview = New DevComponents.DotNetBar.ButtonItem
        Me.btnPrint = New DevComponents.DotNetBar.ButtonItem
        Me.LabelItem2 = New DevComponents.DotNetBar.LabelItem
        Me.ButtonItem6 = New DevComponents.DotNetBar.ButtonItem
        Me.btnAnulaPago = New DevComponents.DotNetBar.ButtonItem
        Me.lblRegistrosCobranza = New DevComponents.DotNetBar.LabelItem
        Me.ProgressBarItem1 = New DevComponents.DotNetBar.ProgressBarItem
        Me.dgCobranzas = New DevComponents.DotNetBar.Controls.DataGridViewX
        Me.TabItem2 = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanel1 = New DevComponents.DotNetBar.TabControlPanel
        Me.gridPredios = New DevComponents.DotNetBar.Controls.DataGridViewX
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.cmbCPoblado = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX
        Me.txtCodigo = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX
        Me.cmbCalles = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX
        Me.Bar2 = New DevComponents.DotNetBar.Bar
        Me.BtnLimpiaBuscar = New DevComponents.DotNetBar.ButtonItem
        Me.ButtonItem19 = New DevComponents.DotNetBar.ButtonItem
        Me.txtDNI = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX
        Me.txtUAMaterno = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.LabelX8 = New DevComponents.DotNetBar.LabelX
        Me.LabelX9 = New DevComponents.DotNetBar.LabelX
        Me.txtUNombre = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.txtUC = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.txtUAPaterno = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.LabelX12 = New DevComponents.DotNetBar.LabelX
        Me.Bar3 = New DevComponents.DotNetBar.Bar
        Me.cmbJunta = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX
        Me.ControlContainerItem1 = New DevComponents.DotNetBar.ControlContainerItem
        Me.Bar1 = New DevComponents.DotNetBar.Bar
        Me.btnCobranzaNew = New DevComponents.DotNetBar.ButtonItem
        Me.lblRegistros = New DevComponents.DotNetBar.LabelItem
        Me.pgb = New DevComponents.DotNetBar.ProgressBarItem
        Me.btnCancelProgress = New DevComponents.DotNetBar.ButtonItem
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX
        Me.TabItem1 = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.ControlContainerItem2 = New DevComponents.DotNetBar.ControlContainerItem
        Me.ControlContainerItem5 = New DevComponents.DotNetBar.ControlContainerItem
        Me.ControlContainerItem6 = New DevComponents.DotNetBar.ControlContainerItem
        Me.ComboItem2 = New DevComponents.Editors.ComboItem
        Me.ComboItem1 = New DevComponents.Editors.ComboItem
        CType(Me.TabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabControlPanel2.SuspendLayout()
        CType(Me.txtFFin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFInicio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Bar4.SuspendLayout()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.Bar5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgCobranzas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControlPanel1.SuspendLayout()
        CType(Me.gridPredios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel2.SuspendLayout()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Bar3.SuspendLayout()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.TabControl1.CanReorderTabs = True
        Me.TabControl1.Controls.Add(Me.TabControlPanel2)
        Me.TabControl1.Controls.Add(Me.TabControlPanel1)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.TabControl1.SelectedTabIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(952, 465)
        Me.TabControl1.Style = DevComponents.DotNetBar.eTabStripStyle.Office2007Document
        Me.TabControl1.TabIndex = 1
        Me.TabControl1.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
        Me.TabControl1.Tabs.Add(Me.TabItem1)
        Me.TabControl1.Tabs.Add(Me.TabItem2)
        Me.TabControl1.Text = "TabControl1"
        '
        'TabControlPanel2
        '
        Me.TabControlPanel2.Controls.Add(Me.txtAnioVigente)
        Me.TabControlPanel2.Controls.Add(Me.lblTotalRecibido)
        Me.TabControlPanel2.Controls.Add(Me.LabelX22)
        Me.TabControlPanel2.Controls.Add(Me.lblRedondeo)
        Me.TabControlPanel2.Controls.Add(Me.LabelX20)
        Me.TabControlPanel2.Controls.Add(Me.LabelX11)
        Me.TabControlPanel2.Controls.Add(Me.LabelX15)
        Me.TabControlPanel2.Controls.Add(Me.lblMontoTotal)
        Me.TabControlPanel2.Controls.Add(Me.txtFFin)
        Me.TabControlPanel2.Controls.Add(Me.LabelX21)
        Me.TabControlPanel2.Controls.Add(Me.txtFInicio)
        Me.TabControlPanel2.Controls.Add(Me.lblInteres)
        Me.TabControlPanel2.Controls.Add(Me.LabelX19)
        Me.TabControlPanel2.Controls.Add(Me.lblMonto)
        Me.TabControlPanel2.Controls.Add(Me.LabelX17)
        Me.TabControlPanel2.Controls.Add(Me.Bar4)
        Me.TabControlPanel2.Controls.Add(Me.GroupPanel1)
        Me.TabControlPanel2.Controls.Add(Me.Bar5)
        Me.TabControlPanel2.Controls.Add(Me.dgCobranzas)
        Me.TabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel2.Location = New System.Drawing.Point(0, 22)
        Me.TabControlPanel2.Name = "TabControlPanel2"
        Me.TabControlPanel2.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel2.Size = New System.Drawing.Size(952, 443)
        Me.TabControlPanel2.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.TabControlPanel2.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(157, Byte), Integer), CType(CType(188, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.TabControlPanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel2.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
        Me.TabControlPanel2.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                    Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel2.Style.GradientAngle = 90
        Me.TabControlPanel2.TabIndex = 2
        Me.TabControlPanel2.TabItem = Me.TabItem2
        '
        'txtAnioVigente
        '
        '
        '
        '
        Me.txtAnioVigente.Border.Class = "TextBoxBorder"
        Me.txtAnioVigente.Enabled = False
        Me.txtAnioVigente.Location = New System.Drawing.Point(629, 35)
        Me.txtAnioVigente.Name = "txtAnioVigente"
        Me.txtAnioVigente.Size = New System.Drawing.Size(116, 20)
        Me.txtAnioVigente.TabIndex = 33
        '
        'lblTotalRecibido
        '
        Me.lblTotalRecibido.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotalRecibido.AutoSize = True
        Me.lblTotalRecibido.BackColor = System.Drawing.Color.Transparent
        Me.lblTotalRecibido.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalRecibido.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblTotalRecibido.Location = New System.Drawing.Point(872, 400)
        Me.lblTotalRecibido.Name = "lblTotalRecibido"
        Me.lblTotalRecibido.Size = New System.Drawing.Size(7, 17)
        Me.lblTotalRecibido.TabIndex = 105
        Me.lblTotalRecibido.Text = "-"
        '
        'LabelX22
        '
        Me.LabelX22.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelX22.AutoSize = True
        Me.LabelX22.BackColor = System.Drawing.Color.Transparent
        Me.LabelX22.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX22.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LabelX22.Location = New System.Drawing.Point(777, 400)
        Me.LabelX22.Name = "LabelX22"
        Me.LabelX22.Size = New System.Drawing.Size(89, 17)
        Me.LabelX22.TabIndex = 104
        Me.LabelX22.Text = "Total Recibido:"
        '
        'lblRedondeo
        '
        Me.lblRedondeo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblRedondeo.AutoSize = True
        Me.lblRedondeo.BackColor = System.Drawing.Color.Transparent
        Me.lblRedondeo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRedondeo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblRedondeo.Location = New System.Drawing.Point(608, 377)
        Me.lblRedondeo.Name = "lblRedondeo"
        Me.lblRedondeo.Size = New System.Drawing.Size(7, 17)
        Me.lblRedondeo.TabIndex = 103
        Me.lblRedondeo.Text = "-"
        '
        'LabelX20
        '
        Me.LabelX20.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LabelX20.AutoSize = True
        Me.LabelX20.BackColor = System.Drawing.Color.Transparent
        Me.LabelX20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX20.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LabelX20.Location = New System.Drawing.Point(536, 377)
        Me.LabelX20.Name = "LabelX20"
        Me.LabelX20.Size = New System.Drawing.Size(66, 17)
        Me.LabelX20.TabIndex = 102
        Me.LabelX20.Text = "Redondeo:"
        '
        'LabelX11
        '
        Me.LabelX11.AutoSize = True
        Me.LabelX11.BackColor = System.Drawing.Color.Transparent
        Me.LabelX11.Location = New System.Drawing.Point(318, 40)
        Me.LabelX11.Name = "LabelX11"
        Me.LabelX11.Size = New System.Drawing.Size(32, 15)
        Me.LabelX11.TabIndex = 24
        Me.LabelX11.Text = "hasta:"
        '
        'LabelX15
        '
        Me.LabelX15.AutoSize = True
        Me.LabelX15.BackColor = System.Drawing.Color.Transparent
        Me.LabelX15.Location = New System.Drawing.Point(7, 40)
        Me.LabelX15.Name = "LabelX15"
        Me.LabelX15.Size = New System.Drawing.Size(132, 15)
        Me.LabelX15.TabIndex = 23
        Me.LabelX15.Text = "Mostrar Cobranzas desde:"
        '
        'lblMontoTotal
        '
        Me.lblMontoTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblMontoTotal.AutoSize = True
        Me.lblMontoTotal.BackColor = System.Drawing.Color.Transparent
        Me.lblMontoTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMontoTotal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblMontoTotal.Location = New System.Drawing.Point(416, 377)
        Me.lblMontoTotal.Name = "lblMontoTotal"
        Me.lblMontoTotal.Size = New System.Drawing.Size(7, 17)
        Me.lblMontoTotal.TabIndex = 99
        Me.lblMontoTotal.Text = "-"
        '
        'txtFFin
        '
        '
        '
        '
        Me.txtFFin.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtFFin.ButtonClear.Visible = True
        Me.txtFFin.ButtonDropDown.Visible = True
        Me.txtFFin.Location = New System.Drawing.Point(356, 35)
        '
        '
        '
        Me.txtFFin.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        Me.txtFFin.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.txtFFin.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.txtFFin.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.txtFFin.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.txtFFin.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.txtFFin.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.txtFFin.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.txtFFin.MonthCalendar.DisplayMonth = New Date(2009, 9, 1, 0, 0, 0, 0)
        Me.txtFFin.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.txtFFin.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.txtFFin.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.txtFFin.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.txtFFin.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.txtFFin.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.txtFFin.MonthCalendar.TodayButtonVisible = True
        Me.txtFFin.Name = "txtFFin"
        Me.txtFFin.Size = New System.Drawing.Size(151, 20)
        Me.txtFFin.TabIndex = 22
        '
        'LabelX21
        '
        Me.LabelX21.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LabelX21.AutoSize = True
        Me.LabelX21.BackColor = System.Drawing.Color.Transparent
        Me.LabelX21.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX21.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LabelX21.Location = New System.Drawing.Point(335, 377)
        Me.LabelX21.Name = "LabelX21"
        Me.LabelX21.Size = New System.Drawing.Size(75, 17)
        Me.LabelX21.TabIndex = 98
        Me.LabelX21.Text = "Monto Total:"
        '
        'txtFInicio
        '
        '
        '
        '
        Me.txtFInicio.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtFInicio.ButtonClear.Visible = True
        Me.txtFInicio.ButtonDropDown.Visible = True
        Me.txtFInicio.Location = New System.Drawing.Point(145, 35)
        '
        '
        '
        Me.txtFInicio.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        Me.txtFInicio.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.txtFInicio.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.txtFInicio.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.txtFInicio.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.txtFInicio.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.txtFInicio.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.txtFInicio.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.txtFInicio.MonthCalendar.DisplayMonth = New Date(2009, 9, 1, 0, 0, 0, 0)
        Me.txtFInicio.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.txtFInicio.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.txtFInicio.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.txtFInicio.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.txtFInicio.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.txtFInicio.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.txtFInicio.MonthCalendar.TodayButtonVisible = True
        Me.txtFInicio.Name = "txtFInicio"
        Me.txtFInicio.Size = New System.Drawing.Size(150, 20)
        Me.txtFInicio.TabIndex = 21
        '
        'lblInteres
        '
        Me.lblInteres.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblInteres.AutoSize = True
        Me.lblInteres.BackColor = System.Drawing.Color.Transparent
        Me.lblInteres.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInteres.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblInteres.Location = New System.Drawing.Point(227, 377)
        Me.lblInteres.Name = "lblInteres"
        Me.lblInteres.Size = New System.Drawing.Size(7, 17)
        Me.lblInteres.TabIndex = 97
        Me.lblInteres.Text = "-"
        '
        'LabelX19
        '
        Me.LabelX19.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LabelX19.AutoSize = True
        Me.LabelX19.BackColor = System.Drawing.Color.Transparent
        Me.LabelX19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX19.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LabelX19.Location = New System.Drawing.Point(175, 377)
        Me.LabelX19.Name = "LabelX19"
        Me.LabelX19.Size = New System.Drawing.Size(46, 17)
        Me.LabelX19.TabIndex = 96
        Me.LabelX19.Text = "Interes:"
        '
        'lblMonto
        '
        Me.lblMonto.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblMonto.AutoSize = True
        Me.lblMonto.BackColor = System.Drawing.Color.Transparent
        Me.lblMonto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMonto.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblMonto.Location = New System.Drawing.Point(60, 377)
        Me.lblMonto.Name = "lblMonto"
        Me.lblMonto.Size = New System.Drawing.Size(7, 17)
        Me.lblMonto.TabIndex = 95
        Me.lblMonto.Text = "-"
        '
        'LabelX17
        '
        Me.LabelX17.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LabelX17.AutoSize = True
        Me.LabelX17.BackColor = System.Drawing.Color.Transparent
        Me.LabelX17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LabelX17.Location = New System.Drawing.Point(12, 377)
        Me.LabelX17.Name = "LabelX17"
        Me.LabelX17.Size = New System.Drawing.Size(42, 17)
        Me.LabelX17.TabIndex = 94
        Me.LabelX17.Text = "Monto:"
        '
        'Bar4
        '
        Me.Bar4.Controls.Add(Me.LabelX13)
        Me.Bar4.Controls.Add(Me.cmbJuntaC)
        Me.Bar4.Controls.Add(Me.cmbCaja)
        Me.Bar4.Controls.Add(Me.LabelX14)
        Me.Bar4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar4.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.Bar4.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ControlContainerItem11, Me.ControlContainerItem12, Me.ControlContainerItem13, Me.ControlContainerItem14})
        Me.Bar4.Location = New System.Drawing.Point(1, 1)
        Me.Bar4.Name = "Bar4"
        Me.Bar4.Size = New System.Drawing.Size(950, 28)
        Me.Bar4.Stretch = True
        Me.Bar4.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Bar4.TabIndex = 21
        Me.Bar4.TabStop = False
        Me.Bar4.Text = "Bar4"
        '
        'LabelX13
        '
        Me.LabelX13.BackColor = System.Drawing.Color.Transparent
        Me.LabelX13.Location = New System.Drawing.Point(3, 5)
        Me.LabelX13.Name = "LabelX13"
        Me.LabelX13.Size = New System.Drawing.Size(114, 16)
        Me.LabelX13.TabIndex = 10
        Me.LabelX13.Text = "JASS:"
        '
        'cmbJuntaC
        '
        Me.cmbJuntaC.DisplayMember = "Text"
        Me.cmbJuntaC.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbJuntaC.DropDownHeight = 250
        Me.cmbJuntaC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbJuntaC.FormattingEnabled = True
        Me.cmbJuntaC.IntegralHeight = False
        Me.cmbJuntaC.ItemHeight = 17
        Me.cmbJuntaC.Location = New System.Drawing.Point(121, 2)
        Me.cmbJuntaC.Name = "cmbJuntaC"
        Me.cmbJuntaC.Size = New System.Drawing.Size(173, 23)
        Me.cmbJuntaC.TabIndex = 11
        '
        'cmbCaja
        '
        Me.cmbCaja.DisplayMember = "Text"
        Me.cmbCaja.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbCaja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCaja.FormattingEnabled = True
        Me.cmbCaja.ItemHeight = 17
        Me.cmbCaja.Location = New System.Drawing.Point(342, 2)
        Me.cmbCaja.Name = "cmbCaja"
        Me.cmbCaja.Size = New System.Drawing.Size(173, 23)
        Me.cmbCaja.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003
        Me.cmbCaja.TabIndex = 13
        '
        'LabelX14
        '
        Me.LabelX14.BackColor = System.Drawing.Color.Transparent
        Me.LabelX14.Location = New System.Drawing.Point(298, 5)
        Me.LabelX14.Name = "LabelX14"
        Me.LabelX14.Size = New System.Drawing.Size(40, 16)
        Me.LabelX14.TabIndex = 12
        Me.LabelX14.Text = "Caja:"
        '
        'ControlContainerItem11
        '
        Me.ControlContainerItem11.AllowItemResize = False
        Me.ControlContainerItem11.Control = Me.LabelX13
        Me.ControlContainerItem11.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
        Me.ControlContainerItem11.Name = "ControlContainerItem11"
        '
        'ControlContainerItem12
        '
        Me.ControlContainerItem12.AllowItemResize = False
        Me.ControlContainerItem12.Control = Me.cmbJuntaC
        Me.ControlContainerItem12.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
        Me.ControlContainerItem12.Name = "ControlContainerItem12"
        '
        'ControlContainerItem13
        '
        Me.ControlContainerItem13.AllowItemResize = False
        Me.ControlContainerItem13.Control = Me.LabelX14
        Me.ControlContainerItem13.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
        Me.ControlContainerItem13.Name = "ControlContainerItem13"
        '
        'ControlContainerItem14
        '
        Me.ControlContainerItem14.AllowItemResize = False
        Me.ControlContainerItem14.Control = Me.cmbCaja
        Me.ControlContainerItem14.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
        Me.ControlContainerItem14.Name = "ControlContainerItem14"
        '
        'GroupPanel1
        '
        Me.GroupPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupPanel1.BackColor = System.Drawing.Color.Transparent
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.btnLoadPagos)
        Me.GroupPanel1.Controls.Add(Me.cmbTipoDeuda)
        Me.GroupPanel1.Controls.Add(Me.LabelX25)
        Me.GroupPanel1.Controls.Add(Me.cmbTipoPago)
        Me.GroupPanel1.Controls.Add(Me.LabelX24)
        Me.GroupPanel1.Controls.Add(Me.txtNroDocumento)
        Me.GroupPanel1.Controls.Add(Me.LabelX18)
        Me.GroupPanel1.Location = New System.Drawing.Point(4, 61)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(936, 76)
        '
        '
        '
        Me.GroupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel1.Style.BackColorGradientAngle = 90
        Me.GroupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderBottomWidth = 1
        Me.GroupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderLeftWidth = 1
        Me.GroupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderRightWidth = 1
        Me.GroupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderTopWidth = 1
        Me.GroupPanel1.Style.CornerDiameter = 4
        Me.GroupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        Me.GroupPanel1.TabIndex = 20
        Me.GroupPanel1.Text = "Listar Planillas Segun"
        '
        'btnLoadPagos
        '
        Me.btnLoadPagos.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnLoadPagos.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnLoadPagos.Location = New System.Drawing.Point(787, 15)
        Me.btnLoadPagos.Name = "btnLoadPagos"
        Me.btnLoadPagos.Size = New System.Drawing.Size(72, 23)
        Me.btnLoadPagos.TabIndex = 32
        Me.btnLoadPagos.Text = "Mostrar"
        '
        'cmbTipoDeuda
        '
        Me.cmbTipoDeuda.DisplayMember = "Text"
        Me.cmbTipoDeuda.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbTipoDeuda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoDeuda.FormattingEnabled = True
        Me.cmbTipoDeuda.ItemHeight = 14
        Me.cmbTipoDeuda.Location = New System.Drawing.Point(575, 18)
        Me.cmbTipoDeuda.Name = "cmbTipoDeuda"
        Me.cmbTipoDeuda.Size = New System.Drawing.Size(195, 20)
        Me.cmbTipoDeuda.TabIndex = 31
        '
        'LabelX25
        '
        Me.LabelX25.AutoSize = True
        Me.LabelX25.BackColor = System.Drawing.Color.Transparent
        Me.LabelX25.Location = New System.Drawing.Point(492, 23)
        Me.LabelX25.Name = "LabelX25"
        Me.LabelX25.Size = New System.Drawing.Size(78, 15)
        Me.LabelX25.TabIndex = 30
        Me.LabelX25.Text = "Tipo de Deuda:"
        '
        'cmbTipoPago
        '
        Me.cmbTipoPago.DisplayMember = "Text"
        Me.cmbTipoPago.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbTipoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoPago.FormattingEnabled = True
        Me.cmbTipoPago.ItemHeight = 14
        Me.cmbTipoPago.Location = New System.Drawing.Point(328, 18)
        Me.cmbTipoPago.Name = "cmbTipoPago"
        Me.cmbTipoPago.Size = New System.Drawing.Size(145, 20)
        Me.cmbTipoPago.TabIndex = 29
        '
        'LabelX24
        '
        Me.LabelX24.AutoSize = True
        Me.LabelX24.BackColor = System.Drawing.Color.Transparent
        Me.LabelX24.Location = New System.Drawing.Point(5, 23)
        Me.LabelX24.Name = "LabelX24"
        Me.LabelX24.Size = New System.Drawing.Size(77, 15)
        Me.LabelX24.TabIndex = 28
        Me.LabelX24.Text = "N° Documento:"
        '
        'txtNroDocumento
        '
        '
        '
        '
        Me.txtNroDocumento.Border.Class = "TextBoxBorder"
        Me.txtNroDocumento.Location = New System.Drawing.Point(88, 18)
        Me.txtNroDocumento.Name = "txtNroDocumento"
        Me.txtNroDocumento.Size = New System.Drawing.Size(116, 20)
        Me.txtNroDocumento.TabIndex = 27
        '
        'LabelX18
        '
        Me.LabelX18.AutoSize = True
        Me.LabelX18.BackColor = System.Drawing.Color.Transparent
        Me.LabelX18.Location = New System.Drawing.Point(251, 23)
        Me.LabelX18.Name = "LabelX18"
        Me.LabelX18.Size = New System.Drawing.Size(71, 15)
        Me.LabelX18.TabIndex = 26
        Me.LabelX18.Text = "Tipo de Pago:"
        '
        'Bar5
        '
        Me.Bar5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar5.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.Bar5.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnPreview, Me.btnPrint, Me.LabelItem2, Me.ButtonItem6, Me.lblRegistrosCobranza, Me.ProgressBarItem1})
        Me.Bar5.Location = New System.Drawing.Point(1, 417)
        Me.Bar5.Name = "Bar5"
        Me.Bar5.Size = New System.Drawing.Size(950, 25)
        Me.Bar5.Stretch = True
        Me.Bar5.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Bar5.TabIndex = 19
        Me.Bar5.TabStop = False
        Me.Bar5.Text = "Bar5"
        '
        'btnPreview
        '
        Me.btnPreview.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnPreview.FontBold = True
        Me.btnPreview.Image = Global.COBSER.My.Resources.Resources.search
        Me.btnPreview.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.btnPreview.ImagePaddingHorizontal = 8
        Me.btnPreview.Name = "btnPreview"
        Me.btnPreview.Text = "Vista Previa"
        '
        'btnPrint
        '
        Me.btnPrint.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnPrint.FontBold = True
        Me.btnPrint.Image = Global.COBSER.My.Resources.Resources.printer
        Me.btnPrint.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.btnPrint.ImagePaddingHorizontal = 8
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Text = "Imprimir"
        '
        'LabelItem2
        '
        Me.LabelItem2.Name = "LabelItem2"
        Me.LabelItem2.Text = "   |   "
        '
        'ButtonItem6
        '
        Me.ButtonItem6.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem6.Image = Global.COBSER.My.Resources.Resources.cog_edit
        Me.ButtonItem6.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.ButtonItem6.ImagePaddingHorizontal = 8
        Me.ButtonItem6.Name = "ButtonItem6"
        Me.ButtonItem6.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnAnulaPago})
        Me.ButtonItem6.Text = "Operaciones"
        '
        'btnAnulaPago
        '
        Me.btnAnulaPago.Image = Global.COBSER.My.Resources.Resources.delete
        Me.btnAnulaPago.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.btnAnulaPago.ImagePaddingHorizontal = 8
        Me.btnAnulaPago.Name = "btnAnulaPago"
        Me.btnAnulaPago.Text = "Anular Recibo"
        '
        'lblRegistrosCobranza
        '
        Me.lblRegistrosCobranza.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.lblRegistrosCobranza.Name = "lblRegistrosCobranza"
        Me.lblRegistrosCobranza.Text = "0 Registros encontrados"
        '
        'ProgressBarItem1
        '
        Me.ProgressBarItem1.ChunkGradientAngle = 0.0!
        Me.ProgressBarItem1.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.ProgressBarItem1.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
        Me.ProgressBarItem1.Name = "ProgressBarItem1"
        Me.ProgressBarItem1.RecentlyUsed = False
        Me.ProgressBarItem1.Width = 150
        '
        'dgCobranzas
        '
        Me.dgCobranzas.AllowUserToAddRows = False
        Me.dgCobranzas.AllowUserToDeleteRows = False
        Me.dgCobranzas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgCobranzas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgCobranzas.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgCobranzas.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgCobranzas.Location = New System.Drawing.Point(4, 143)
        Me.dgCobranzas.MultiSelect = False
        Me.dgCobranzas.Name = "dgCobranzas"
        Me.dgCobranzas.ReadOnly = True
        Me.dgCobranzas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgCobranzas.Size = New System.Drawing.Size(936, 228)
        Me.dgCobranzas.TabIndex = 18
        '
        'TabItem2
        '
        Me.TabItem2.AttachedControl = Me.TabControlPanel2
        Me.TabItem2.Name = "TabItem2"
        Me.TabItem2.Text = "CobranzasRealizadas"
        '
        'TabControlPanel1
        '
        Me.TabControlPanel1.Controls.Add(Me.gridPredios)
        Me.TabControlPanel1.Controls.Add(Me.GroupPanel2)
        Me.TabControlPanel1.Controls.Add(Me.Bar3)
        Me.TabControlPanel1.Controls.Add(Me.Bar1)
        Me.TabControlPanel1.Controls.Add(Me.LabelX2)
        Me.TabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel1.Location = New System.Drawing.Point(0, 22)
        Me.TabControlPanel1.Name = "TabControlPanel1"
        Me.TabControlPanel1.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel1.Size = New System.Drawing.Size(952, 443)
        Me.TabControlPanel1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.TabControlPanel1.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(157, Byte), Integer), CType(CType(188, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.TabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel1.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
        Me.TabControlPanel1.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                    Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel1.Style.GradientAngle = 90
        Me.TabControlPanel1.TabIndex = 1
        Me.TabControlPanel1.TabItem = Me.TabItem1
        '
        'gridPredios
        '
        Me.gridPredios.AllowUserToAddRows = False
        Me.gridPredios.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gridPredios.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.gridPredios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gridPredios.DefaultCellStyle = DataGridViewCellStyle7
        Me.gridPredios.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.gridPredios.Location = New System.Drawing.Point(1, 196)
        Me.gridPredios.Name = "gridPredios"
        Me.gridPredios.ReadOnly = True
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gridPredios.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.gridPredios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridPredios.Size = New System.Drawing.Size(948, 221)
        Me.gridPredios.TabIndex = 34
        Me.gridPredios.VirtualMode = True
        '
        'GroupPanel2
        '
        Me.GroupPanel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupPanel2.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.cmbCPoblado)
        Me.GroupPanel2.Controls.Add(Me.LabelX4)
        Me.GroupPanel2.Controls.Add(Me.txtCodigo)
        Me.GroupPanel2.Controls.Add(Me.LabelX3)
        Me.GroupPanel2.Controls.Add(Me.cmbCalles)
        Me.GroupPanel2.Controls.Add(Me.LabelX1)
        Me.GroupPanel2.Controls.Add(Me.Bar2)
        Me.GroupPanel2.Controls.Add(Me.txtDNI)
        Me.GroupPanel2.Controls.Add(Me.LabelX5)
        Me.GroupPanel2.Controls.Add(Me.LabelX7)
        Me.GroupPanel2.Controls.Add(Me.txtUAMaterno)
        Me.GroupPanel2.Controls.Add(Me.LabelX8)
        Me.GroupPanel2.Controls.Add(Me.LabelX9)
        Me.GroupPanel2.Controls.Add(Me.txtUNombre)
        Me.GroupPanel2.Controls.Add(Me.txtUC)
        Me.GroupPanel2.Controls.Add(Me.txtUAPaterno)
        Me.GroupPanel2.Controls.Add(Me.LabelX12)
        Me.GroupPanel2.DrawTitleBox = False
        Me.GroupPanel2.Location = New System.Drawing.Point(3, 32)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(945, 158)
        '
        '
        '
        Me.GroupPanel2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel2.Style.BackColorGradientAngle = 90
        Me.GroupPanel2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderBottomWidth = 1
        Me.GroupPanel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderLeftWidth = 1
        Me.GroupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderRightWidth = 1
        Me.GroupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderTopWidth = 1
        Me.GroupPanel2.Style.CornerDiameter = 4
        Me.GroupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        Me.GroupPanel2.TabIndex = 33
        Me.GroupPanel2.Text = "Criterios de busqueda"
        '
        'cmbCPoblado
        '
        Me.cmbCPoblado.DisplayMember = "Text"
        Me.cmbCPoblado.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbCPoblado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCPoblado.FormattingEnabled = True
        Me.cmbCPoblado.ItemHeight = 14
        Me.cmbCPoblado.Location = New System.Drawing.Point(112, 6)
        Me.cmbCPoblado.Name = "cmbCPoblado"
        Me.cmbCPoblado.Size = New System.Drawing.Size(211, 20)
        Me.cmbCPoblado.TabIndex = 174
        Me.cmbCPoblado.WatermarkText = "Seleccione un CP"
        '
        'LabelX4
        '
        Me.LabelX4.AutoSize = True
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        Me.LabelX4.Location = New System.Drawing.Point(13, 8)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(60, 15)
        Me.LabelX4.TabIndex = 175
        Me.LabelX4.Text = "C. Poblado:"
        '
        'txtCodigo
        '
        '
        '
        '
        Me.txtCodigo.Border.Class = "TextBoxBorder"
        Me.txtCodigo.Location = New System.Drawing.Point(112, 77)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(211, 20)
        Me.txtCodigo.TabIndex = 162
        '
        'LabelX3
        '
        Me.LabelX3.AutoSize = True
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        Me.LabelX3.Location = New System.Drawing.Point(17, 82)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(40, 15)
        Me.LabelX3.TabIndex = 161
        Me.LabelX3.Text = "Codigo:"
        '
        'cmbCalles
        '
        Me.cmbCalles.DisplayMember = "Text"
        Me.cmbCalles.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbCalles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCalles.FormattingEnabled = True
        Me.cmbCalles.ItemHeight = 15
        Me.cmbCalles.Location = New System.Drawing.Point(426, 3)
        Me.cmbCalles.Name = "cmbCalles"
        Me.cmbCalles.Size = New System.Drawing.Size(211, 21)
        Me.cmbCalles.TabIndex = 160
        '
        'LabelX1
        '
        Me.LabelX1.AutoSize = True
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        Me.LabelX1.Location = New System.Drawing.Point(349, 11)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(31, 15)
        Me.LabelX1.TabIndex = 142
        Me.LabelX1.Text = "Calle:"
        '
        'Bar2
        '
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnLimpiaBuscar, Me.ButtonItem19})
        Me.Bar2.Location = New System.Drawing.Point(0, 112)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(939, 25)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Bar2.TabIndex = 159
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'BtnLimpiaBuscar
        '
        Me.BtnLimpiaBuscar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnLimpiaBuscar.Image = Global.COBSER.My.Resources.Resources.lightning
        Me.BtnLimpiaBuscar.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.BtnLimpiaBuscar.ImagePaddingHorizontal = 8
        Me.BtnLimpiaBuscar.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.BtnLimpiaBuscar.Name = "BtnLimpiaBuscar"
        Me.BtnLimpiaBuscar.Text = "Nueva Consulta"
        '
        'ButtonItem19
        '
        Me.ButtonItem19.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem19.Image = Global.COBSER.My.Resources.Resources.search
        Me.ButtonItem19.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.ButtonItem19.ImagePaddingHorizontal = 8
        Me.ButtonItem19.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.ButtonItem19.Name = "ButtonItem19"
        Me.ButtonItem19.Text = "Listar Predios"
        '
        'txtDNI
        '
        '
        '
        '
        Me.txtDNI.Border.Class = "TextBoxBorder"
        Me.txtDNI.Location = New System.Drawing.Point(764, 6)
        Me.txtDNI.Name = "txtDNI"
        Me.txtDNI.Size = New System.Drawing.Size(170, 20)
        Me.txtDNI.TabIndex = 149
        '
        'LabelX5
        '
        Me.LabelX5.AutoSize = True
        Me.LabelX5.BackColor = System.Drawing.Color.Transparent
        Me.LabelX5.Location = New System.Drawing.Point(658, 6)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(40, 15)
        Me.LabelX5.TabIndex = 158
        Me.LabelX5.Text = "N° DNI:"
        '
        'LabelX7
        '
        Me.LabelX7.AutoSize = True
        Me.LabelX7.BackColor = System.Drawing.Color.Transparent
        Me.LabelX7.Location = New System.Drawing.Point(349, 44)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(71, 15)
        Me.LabelX7.TabIndex = 156
        Me.LabelX7.Text = "Ape. Materno:"
        '
        'txtUAMaterno
        '
        '
        '
        '
        Me.txtUAMaterno.Border.Class = "TextBoxBorder"
        Me.txtUAMaterno.Location = New System.Drawing.Point(426, 39)
        Me.txtUAMaterno.Name = "txtUAMaterno"
        Me.txtUAMaterno.Size = New System.Drawing.Size(211, 20)
        Me.txtUAMaterno.TabIndex = 148
        '
        'LabelX8
        '
        Me.LabelX8.AutoSize = True
        Me.LabelX8.BackColor = System.Drawing.Color.Transparent
        Me.LabelX8.Location = New System.Drawing.Point(17, 48)
        Me.LabelX8.Name = "LabelX8"
        Me.LabelX8.Size = New System.Drawing.Size(70, 15)
        Me.LabelX8.TabIndex = 152
        Me.LabelX8.Text = "Ape. Paterno:"
        '
        'LabelX9
        '
        Me.LabelX9.AutoSize = True
        Me.LabelX9.BackColor = System.Drawing.Color.Transparent
        Me.LabelX9.Location = New System.Drawing.Point(658, 41)
        Me.LabelX9.Name = "LabelX9"
        Me.LabelX9.Size = New System.Drawing.Size(86, 15)
        Me.LabelX9.TabIndex = 144
        Me.LabelX9.Text = "Nombre Usuario:"
        '
        'txtUNombre
        '
        '
        '
        '
        Me.txtUNombre.Border.Class = "TextBoxBorder"
        Me.txtUNombre.Location = New System.Drawing.Point(766, 36)
        Me.txtUNombre.Name = "txtUNombre"
        Me.txtUNombre.Size = New System.Drawing.Size(170, 20)
        Me.txtUNombre.TabIndex = 146
        '
        'txtUC
        '
        '
        '
        '
        Me.txtUC.Border.Class = "TextBoxBorder"
        Me.txtUC.Location = New System.Drawing.Point(426, 77)
        Me.txtUC.Name = "txtUC"
        Me.txtUC.Size = New System.Drawing.Size(211, 20)
        Me.txtUC.TabIndex = 151
        '
        'txtUAPaterno
        '
        '
        '
        '
        Me.txtUAPaterno.Border.Class = "TextBoxBorder"
        Me.txtUAPaterno.Location = New System.Drawing.Point(112, 43)
        Me.txtUAPaterno.Name = "txtUAPaterno"
        Me.txtUAPaterno.Size = New System.Drawing.Size(211, 20)
        Me.txtUAPaterno.TabIndex = 147
        '
        'LabelX12
        '
        Me.LabelX12.AutoSize = True
        Me.LabelX12.BackColor = System.Drawing.Color.Transparent
        Me.LabelX12.Location = New System.Drawing.Point(342, 82)
        Me.LabelX12.Name = "LabelX12"
        Me.LabelX12.Size = New System.Drawing.Size(62, 15)
        Me.LabelX12.TabIndex = 154
        Me.LabelX12.Text = "N° de Casa:"
        '
        'Bar3
        '
        Me.Bar3.Controls.Add(Me.cmbJunta)
        Me.Bar3.Controls.Add(Me.LabelX6)
        Me.Bar3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar3.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.Bar3.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ControlContainerItem1})
        Me.Bar3.Location = New System.Drawing.Point(1, 1)
        Me.Bar3.Name = "Bar3"
        Me.Bar3.Size = New System.Drawing.Size(950, 23)
        Me.Bar3.Stretch = True
        Me.Bar3.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Bar3.TabIndex = 14
        Me.Bar3.TabStop = False
        Me.Bar3.Text = "Bar3"
        '
        'cmbJunta
        '
        Me.cmbJunta.DisplayMember = "Text"
        Me.cmbJunta.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbJunta.DropDownHeight = 250
        Me.cmbJunta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbJunta.FormattingEnabled = True
        Me.cmbJunta.IntegralHeight = False
        Me.cmbJunta.ItemHeight = 17
        Me.cmbJunta.Location = New System.Drawing.Point(46, 0)
        Me.cmbJunta.Name = "cmbJunta"
        Me.cmbJunta.Size = New System.Drawing.Size(244, 23)
        Me.cmbJunta.TabIndex = 12
        '
        'LabelX6
        '
        Me.LabelX6.BackColor = System.Drawing.Color.Transparent
        Me.LabelX6.Location = New System.Drawing.Point(3, 3)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(97, 16)
        Me.LabelX6.TabIndex = 10
        Me.LabelX6.Text = "JASS:"
        '
        'ControlContainerItem1
        '
        Me.ControlContainerItem1.AllowItemResize = False
        Me.ControlContainerItem1.Control = Me.LabelX6
        Me.ControlContainerItem1.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
        Me.ControlContainerItem1.Name = "ControlContainerItem1"
        '
        'Bar1
        '
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnCobranzaNew, Me.lblRegistros, Me.pgb, Me.btnCancelProgress})
        Me.Bar1.Location = New System.Drawing.Point(1, 417)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(950, 25)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Bar1.TabIndex = 8
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'btnCobranzaNew
        '
        Me.btnCobranzaNew.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnCobranzaNew.Image = Global.COBSER.My.Resources.Resources.pago
        Me.btnCobranzaNew.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.btnCobranzaNew.ImagePaddingHorizontal = 8
        Me.btnCobranzaNew.Name = "btnCobranzaNew"
        Me.btnCobranzaNew.Text = "Cobrar Deuda"
        '
        'lblRegistros
        '
        Me.lblRegistros.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.lblRegistros.Name = "lblRegistros"
        Me.lblRegistros.Text = "0 Registros encontrados"
        '
        'pgb
        '
        Me.pgb.ChunkGradientAngle = 0.0!
        Me.pgb.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.pgb.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
        Me.pgb.Name = "pgb"
        Me.pgb.RecentlyUsed = False
        Me.pgb.Width = 150
        '
        'btnCancelProgress
        '
        Me.btnCancelProgress.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.btnCancelProgress.ImagePaddingHorizontal = 8
        Me.btnCancelProgress.Name = "btnCancelProgress"
        Me.btnCancelProgress.Tag = "Cancelar Busqueda"
        '
        'LabelX2
        '
        Me.LabelX2.AutoSize = True
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        Me.LabelX2.Location = New System.Drawing.Point(700, 4)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(94, 15)
        Me.LabelX2.TabIndex = 2
        Me.LabelX2.Text = "Fecha: 21/04/2009"
        '
        'TabItem1
        '
        Me.TabItem1.AttachedControl = Me.TabControlPanel1
        Me.TabItem1.Name = "TabItem1"
        Me.TabItem1.Text = "Realizar Cobranzas"
        '
        'ControlContainerItem2
        '
        Me.ControlContainerItem2.AllowItemResize = False
        Me.ControlContainerItem2.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
        Me.ControlContainerItem2.Name = "ControlContainerItem2"
        '
        'ControlContainerItem5
        '
        Me.ControlContainerItem5.AllowItemResize = False
        Me.ControlContainerItem5.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
        Me.ControlContainerItem5.Name = "ControlContainerItem5"
        '
        'ControlContainerItem6
        '
        Me.ControlContainerItem6.AllowItemResize = False
        Me.ControlContainerItem6.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
        Me.ControlContainerItem6.Name = "ControlContainerItem6"
        '
        'ComboItem2
        '
        Me.ComboItem2.Text = "Predio"
        '
        'ComboItem1
        '
        Me.ComboItem1.Text = "Usuario"
        '
        'frmCobranza
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(952, 465)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "frmCobranza"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmCobranza"
        CType(Me.TabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabControlPanel2.ResumeLayout(False)
        Me.TabControlPanel2.PerformLayout()
        CType(Me.txtFFin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFInicio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Bar4.ResumeLayout(False)
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupPanel1.PerformLayout()
        CType(Me.Bar5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgCobranzas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControlPanel1.ResumeLayout(False)
        Me.TabControlPanel1.PerformLayout()
        CType(Me.gridPredios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel2.ResumeLayout(False)
        Me.GroupPanel2.PerformLayout()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Bar3.ResumeLayout(False)
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As DevComponents.DotNetBar.TabControl
    Friend WithEvents TabControlPanel1 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents Bar3 As DevComponents.DotNetBar.Bar
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents ControlContainerItem5 As DevComponents.DotNetBar.ControlContainerItem
    Friend WithEvents ControlContainerItem6 As DevComponents.DotNetBar.ControlContainerItem
    Friend WithEvents ControlContainerItem1 As DevComponents.DotNetBar.ControlContainerItem
    Friend WithEvents ControlContainerItem2 As DevComponents.DotNetBar.ControlContainerItem
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents btnCobranzaNew As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents lblRegistros As DevComponents.DotNetBar.LabelItem
    Friend WithEvents pgb As DevComponents.DotNetBar.ProgressBarItem
    Friend WithEvents btnCancelProgress As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TabItem1 As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControlPanel2 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents lblTotalRecibido As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX22 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblRedondeo As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX20 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX11 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX15 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblMontoTotal As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtFFin As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents LabelX21 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtFInicio As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents lblInteres As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX19 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblMonto As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX17 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Bar4 As DevComponents.DotNetBar.Bar
    Friend WithEvents LabelX13 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cmbJuntaC As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents cmbCaja As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX14 As DevComponents.DotNetBar.LabelX
    Friend WithEvents ControlContainerItem11 As DevComponents.DotNetBar.ControlContainerItem
    Friend WithEvents ControlContainerItem12 As DevComponents.DotNetBar.ControlContainerItem
    Friend WithEvents ControlContainerItem13 As DevComponents.DotNetBar.ControlContainerItem
    Friend WithEvents ControlContainerItem14 As DevComponents.DotNetBar.ControlContainerItem
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents btnLoadPagos As DevComponents.DotNetBar.ButtonX
    Friend WithEvents cmbTipoDeuda As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX25 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cmbTipoPago As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX24 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtNroDocumento As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX18 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Bar5 As DevComponents.DotNetBar.Bar
    Friend WithEvents btnPreview As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnPrint As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem2 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents ButtonItem6 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnAnulaPago As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents lblRegistrosCobranza As DevComponents.DotNetBar.LabelItem
    Friend WithEvents ProgressBarItem1 As DevComponents.DotNetBar.ProgressBarItem
    Friend WithEvents dgCobranzas As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents TabItem2 As DevComponents.DotNetBar.TabItem
    Friend WithEvents ComboItem2 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem1 As DevComponents.Editors.ComboItem
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents cmbCalles As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents BtnLimpiaBuscar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem19 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents txtDNI As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtUAMaterno As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX8 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX9 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtUNombre As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtUC As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtUAPaterno As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX12 As DevComponents.DotNetBar.LabelX
    Friend WithEvents gridPredios As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents cmbJunta As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents txtCodigo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtAnioVigente As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents cmbCPoblado As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
End Class
