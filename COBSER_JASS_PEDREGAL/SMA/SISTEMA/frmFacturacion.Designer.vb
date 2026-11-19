<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFacturacion
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.TabControl1 = New DevComponents.DotNetBar.TabControl
        Me.TabControlPanel1 = New DevComponents.DotNetBar.TabControlPanel
        Me.ExpandablePanel2 = New DevComponents.DotNetBar.ExpandablePanel
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.tvPredios = New DevComponents.AdvTree.AdvTree
        Me.ColumnHeader1 = New DevComponents.AdvTree.ColumnHeader
        Me.ColumnHeader2 = New DevComponents.AdvTree.ColumnHeader
        Me.ColumnHeader3 = New DevComponents.AdvTree.ColumnHeader
        Me.ColumnHeader4 = New DevComponents.AdvTree.ColumnHeader
        Me.ColumnHeader5 = New DevComponents.AdvTree.ColumnHeader
        Me.ColumnHeader6 = New DevComponents.AdvTree.ColumnHeader
        Me.ColumnHeader7 = New DevComponents.AdvTree.ColumnHeader
        Me.ColumnHeader8 = New DevComponents.AdvTree.ColumnHeader
        Me.ColumnHeader9 = New DevComponents.AdvTree.ColumnHeader
        Me.NodeConnector1 = New DevComponents.AdvTree.NodeConnector
        Me.ElementStyle1 = New DevComponents.DotNetBar.ElementStyle
        Me.Bar3 = New DevComponents.DotNetBar.Bar
        Me.lblTotalRegistros = New DevComponents.DotNetBar.LabelX
        Me.btnGenerar = New DevComponents.DotNetBar.ButtonItem
        Me.lblTotal = New DevComponents.DotNetBar.LabelItem
        Me.ProgressBarItem2 = New DevComponents.DotNetBar.ProgressBarItem
        Me.Bar4 = New DevComponents.DotNetBar.Bar
        Me.chkSelectAll = New DevComponents.DotNetBar.Controls.CheckBoxX
        Me.ControlContainerItem4 = New DevComponents.DotNetBar.ControlContainerItem
        Me.ExpandablePanel1 = New DevComponents.DotNetBar.ExpandablePanel
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.cmbCPoblado = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.LabelX25 = New DevComponents.DotNetBar.LabelX
        Me.cmbJunta = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX
        Me.LabelX16 = New DevComponents.DotNetBar.LabelX
        Me.lblUnidad = New DevComponents.DotNetBar.LabelX
        Me.txtValorSubTarifa = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.txtTipoTarifa = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.LabelX13 = New DevComponents.DotNetBar.LabelX
        Me.cmbSubTipoTarifa = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.cmbCalles = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX
        Me.LabelX18 = New DevComponents.DotNetBar.LabelX
        Me.cmbMes = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.ComboItem1 = New DevComponents.Editors.ComboItem
        Me.ComboItem2 = New DevComponents.Editors.ComboItem
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX
        Me.cmbAnio = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.Bar1 = New DevComponents.DotNetBar.Bar
        Me.btnconsultar1 = New DevComponents.DotNetBar.ButtonItem
        Me.btnFiltrar1 = New DevComponents.DotNetBar.ButtonItem
        Me.Bar6 = New DevComponents.DotNetBar.Bar
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX
        Me.Bar2 = New DevComponents.DotNetBar.Bar
        Me.lblEstadoMsg = New DevComponents.DotNetBar.LabelX
        Me.TabItem1 = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanel2 = New DevComponents.DotNetBar.TabControlPanel
        Me.lblMontoTotal = New DevComponents.DotNetBar.LabelX
        Me.LabelX21 = New DevComponents.DotNetBar.LabelX
        Me.Bar7 = New DevComponents.DotNetBar.Bar
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX
        Me.cmbJuntaC = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.cmbCaja = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.LabelX14 = New DevComponents.DotNetBar.LabelX
        Me.ControlContainerItem5 = New DevComponents.DotNetBar.ControlContainerItem
        Me.ControlContainerItem12 = New DevComponents.DotNetBar.ControlContainerItem
        Me.ControlContainerItem13 = New DevComponents.DotNetBar.ControlContainerItem
        Me.ControlContainerItem14 = New DevComponents.DotNetBar.ControlContainerItem
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.cmbCPoblado1 = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.LabelX10 = New DevComponents.DotNetBar.LabelX
        Me.txtNombres = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.txtApeMaterno = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.txtApePaterno = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.LabelX9 = New DevComponents.DotNetBar.LabelX
        Me.LabelX8 = New DevComponents.DotNetBar.LabelX
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX
        Me.cmbCalles1 = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.cmbAnio1 = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.LabelX15 = New DevComponents.DotNetBar.LabelX
        Me.btnLoadPagos = New DevComponents.DotNetBar.ButtonX
        Me.cmbMes1 = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.LabelX24 = New DevComponents.DotNetBar.LabelX
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX
        Me.Bar8 = New DevComponents.DotNetBar.Bar
        Me.btnPreview = New DevComponents.DotNetBar.ButtonItem
        Me.btnPrint = New DevComponents.DotNetBar.ButtonItem
        Me.LabelItem2 = New DevComponents.DotNetBar.LabelItem
        Me.ButtonItem7 = New DevComponents.DotNetBar.ButtonItem
        Me.btnAnulaPago = New DevComponents.DotNetBar.ButtonItem
        Me.lblRegistros = New DevComponents.DotNetBar.LabelItem
        Me.ProgressBarItem3 = New DevComponents.DotNetBar.ProgressBarItem
        Me.dgFacturaciones = New DevComponents.DotNetBar.Controls.DataGridViewX
        Me.TabItem2 = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.ProgressBarItem1 = New DevComponents.DotNetBar.ProgressBarItem
        Me.ControlContainerItem3 = New DevComponents.DotNetBar.ControlContainerItem
        Me.pgb = New DevComponents.DotNetBar.ProgressBarItem
        Me.ControlContainerItem2 = New DevComponents.DotNetBar.ControlContainerItem
        Me.ControlContainerItem1 = New DevComponents.DotNetBar.ControlContainerItem
        Me.ControlContainerItem11 = New DevComponents.DotNetBar.ControlContainerItem
        Me.Bar5 = New DevComponents.DotNetBar.Bar
        Me.ButtonItem2 = New DevComponents.DotNetBar.ButtonItem
        Me.ButtonItem3 = New DevComponents.DotNetBar.ButtonItem
        Me.btnCalcularDeuda = New DevComponents.DotNetBar.ButtonItem
        Me.btnVisualizar = New DevComponents.DotNetBar.ButtonItem
        Me.btnFiltrar = New DevComponents.DotNetBar.ButtonItem
        Me.BtnLimpiaBuscar = New DevComponents.DotNetBar.ButtonItem
        Me.ButtonItem19 = New DevComponents.DotNetBar.ButtonItem
        Me.ButtonItem1 = New DevComponents.DotNetBar.ButtonItem
        Me.ButtonItem4 = New DevComponents.DotNetBar.ButtonItem
        Me.ButtonItem5 = New DevComponents.DotNetBar.ButtonItem
        Me.ButtonItem6 = New DevComponents.DotNetBar.ButtonItem
        CType(Me.TabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabControlPanel1.SuspendLayout()
        Me.ExpandablePanel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.tvPredios, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Bar3.SuspendLayout()
        CType(Me.Bar4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Bar4.SuspendLayout()
        Me.ExpandablePanel1.SuspendLayout()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Bar6.SuspendLayout()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Bar2.SuspendLayout()
        Me.TabControlPanel2.SuspendLayout()
        CType(Me.Bar7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Bar7.SuspendLayout()
        Me.GroupPanel2.SuspendLayout()
        CType(Me.Bar8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgFacturaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar5, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.TabControl1.Size = New System.Drawing.Size(1043, 492)
        Me.TabControl1.Style = DevComponents.DotNetBar.eTabStripStyle.Office2007Document
        Me.TabControl1.TabIndex = 2
        Me.TabControl1.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
        Me.TabControl1.Tabs.Add(Me.TabItem1)
        Me.TabControl1.Tabs.Add(Me.TabItem2)
        Me.TabControl1.Text = "TabControl1"
        '
        'TabControlPanel1
        '
        Me.TabControlPanel1.Controls.Add(Me.ExpandablePanel2)
        Me.TabControlPanel1.Controls.Add(Me.ExpandablePanel1)
        Me.TabControlPanel1.Controls.Add(Me.Bar6)
        Me.TabControlPanel1.Controls.Add(Me.Bar2)
        Me.TabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel1.Location = New System.Drawing.Point(0, 22)
        Me.TabControlPanel1.Name = "TabControlPanel1"
        Me.TabControlPanel1.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel1.Size = New System.Drawing.Size(1043, 470)
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
        'ExpandablePanel2
        '
        Me.ExpandablePanel2.CanvasColor = System.Drawing.SystemColors.Control
        Me.ExpandablePanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.ExpandablePanel2.Controls.Add(Me.Panel1)
        Me.ExpandablePanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ExpandablePanel2.ExpandButtonVisible = False
        Me.ExpandablePanel2.Location = New System.Drawing.Point(281, 1)
        Me.ExpandablePanel2.Name = "ExpandablePanel2"
        Me.ExpandablePanel2.Size = New System.Drawing.Size(761, 464)
        Me.ExpandablePanel2.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.ExpandablePanel2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.ExpandablePanel2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.ExpandablePanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.ExpandablePanel2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.ExpandablePanel2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
        Me.ExpandablePanel2.Style.GradientAngle = 90
        Me.ExpandablePanel2.TabIndex = 133
        Me.ExpandablePanel2.TitleStyle.Alignment = System.Drawing.StringAlignment.Center
        Me.ExpandablePanel2.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.ExpandablePanel2.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.ExpandablePanel2.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner
        Me.ExpandablePanel2.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.ExpandablePanel2.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.ExpandablePanel2.TitleStyle.GradientAngle = 90
        Me.ExpandablePanel2.TitleText = "Listado de Predios a Facturar Deudas Anteriores"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.tvPredios)
        Me.Panel1.Controls.Add(Me.Bar3)
        Me.Panel1.Controls.Add(Me.Bar4)
        Me.Panel1.Location = New System.Drawing.Point(7, 29)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(749, 430)
        Me.Panel1.TabIndex = 21
        '
        'tvPredios
        '
        Me.tvPredios.AllowDrop = True
        Me.tvPredios.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tvPredios.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.tvPredios.BackgroundStyle.Class = "TreeBorderKey"
        Me.tvPredios.CellEdit = True
        Me.tvPredios.Columns.Add(Me.ColumnHeader1)
        Me.tvPredios.Columns.Add(Me.ColumnHeader2)
        Me.tvPredios.Columns.Add(Me.ColumnHeader3)
        Me.tvPredios.Columns.Add(Me.ColumnHeader4)
        Me.tvPredios.Columns.Add(Me.ColumnHeader5)
        Me.tvPredios.Columns.Add(Me.ColumnHeader6)
        Me.tvPredios.Columns.Add(Me.ColumnHeader7)
        Me.tvPredios.Columns.Add(Me.ColumnHeader8)
        Me.tvPredios.Columns.Add(Me.ColumnHeader9)
        Me.tvPredios.DragDropEnabled = False
        Me.tvPredios.GridRowLines = True
        Me.tvPredios.HotTracking = True
        Me.tvPredios.Location = New System.Drawing.Point(0, 26)
        Me.tvPredios.Name = "tvPredios"
        Me.tvPredios.NodesConnector = Me.NodeConnector1
        Me.tvPredios.NodeStyle = Me.ElementStyle1
        Me.tvPredios.PathSeparator = ";"
        Me.tvPredios.SelectionBoxStyle = DevComponents.AdvTree.eSelectionStyle.FullRowSelect
        Me.tvPredios.Size = New System.Drawing.Size(751, 378)
        Me.tvPredios.Styles.Add(Me.ElementStyle1)
        Me.tvPredios.SuspendPaint = False
        Me.tvPredios.TabIndex = 180
        Me.tvPredios.Text = "tvListado"
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Name = "ColumnHeader1"
        Me.ColumnHeader1.Text = "Nro"
        Me.ColumnHeader1.Width.Absolute = 60
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Name = "ColumnHeader2"
        Me.ColumnHeader2.Text = "Predio"
        Me.ColumnHeader2.Width.Absolute = 120
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Name = "ColumnHeader3"
        Me.ColumnHeader3.Text = "Usuario"
        Me.ColumnHeader3.Width.Absolute = 120
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Name = "ColumnHeader4"
        Me.ColumnHeader4.Text = "Deuda"
        Me.ColumnHeader4.Width.Absolute = 60
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Name = "ColumnHeader5"
        Me.ColumnHeader5.Text = "IdJas"
        Me.ColumnHeader5.Width.Absolute = 60
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Name = "ColumnHeader6"
        Me.ColumnHeader6.Text = "Anio"
        Me.ColumnHeader6.Width.Absolute = 60
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Name = "ColumnHeader7"
        Me.ColumnHeader7.Text = "Mes"
        Me.ColumnHeader7.Width.Absolute = 60
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Name = "ColumnHeader8"
        Me.ColumnHeader8.Text = "IdPredio"
        Me.ColumnHeader8.Width.Absolute = 60
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.EditorType = DevComponents.AdvTree.eCellEditorType.NumericInteger
        Me.ColumnHeader9.Name = "ColumnHeader9"
        Me.ColumnHeader9.Text = "IdDetDeu"
        Me.ColumnHeader9.Width.Absolute = 150
        '
        'NodeConnector1
        '
        Me.NodeConnector1.LineColor = System.Drawing.SystemColors.ControlText
        '
        'ElementStyle1
        '
        Me.ElementStyle1.Name = "ElementStyle1"
        Me.ElementStyle1.TextColor = System.Drawing.SystemColors.ControlText
        '
        'Bar3
        '
        Me.Bar3.Controls.Add(Me.lblTotalRegistros)
        Me.Bar3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar3.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnGenerar, Me.lblTotal, Me.ProgressBarItem2})
        Me.Bar3.Location = New System.Drawing.Point(0, 405)
        Me.Bar3.Name = "Bar3"
        Me.Bar3.Size = New System.Drawing.Size(749, 25)
        Me.Bar3.Stretch = True
        Me.Bar3.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Bar3.TabIndex = 21
        Me.Bar3.TabStop = False
        Me.Bar3.Text = "Bar3"
        '
        'lblTotalRegistros
        '
        Me.lblTotalRegistros.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotalRegistros.BackColor = System.Drawing.Color.Transparent
        Me.lblTotalRegistros.Location = New System.Drawing.Point(32453, 1454)
        Me.lblTotalRegistros.Name = "lblTotalRegistros"
        Me.lblTotalRegistros.Size = New System.Drawing.Size(227, 19)
        Me.lblTotalRegistros.TabIndex = 0
        Me.lblTotalRegistros.Text = "-"
        Me.lblTotalRegistros.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'btnGenerar
        '
        Me.btnGenerar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnGenerar.Image = Global.COBSER.My.Resources.Resources.pago
        Me.btnGenerar.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.btnGenerar.ImagePaddingHorizontal = 8
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Text = "Generar Facturacion"
        '
        'lblTotal
        '
        Me.lblTotal.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Text = "0 Registros encontrados"
        '
        'ProgressBarItem2
        '
        Me.ProgressBarItem2.ChunkGradientAngle = 0.0!
        Me.ProgressBarItem2.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.ProgressBarItem2.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
        Me.ProgressBarItem2.Name = "ProgressBarItem2"
        Me.ProgressBarItem2.RecentlyUsed = False
        '
        'Bar4
        '
        Me.Bar4.Controls.Add(Me.chkSelectAll)
        Me.Bar4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar4.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ControlContainerItem4})
        Me.Bar4.Location = New System.Drawing.Point(0, 0)
        Me.Bar4.Name = "Bar4"
        Me.Bar4.Size = New System.Drawing.Size(749, 23)
        Me.Bar4.Stretch = True
        Me.Bar4.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Bar4.TabIndex = 19
        Me.Bar4.TabStop = False
        Me.Bar4.Text = "Bar4"
        '
        'chkSelectAll
        '
        Me.chkSelectAll.AutoSize = True
        Me.chkSelectAll.BackColor = System.Drawing.Color.Transparent
        Me.chkSelectAll.Location = New System.Drawing.Point(3, 2)
        Me.chkSelectAll.Name = "chkSelectAll"
        Me.chkSelectAll.Size = New System.Drawing.Size(117, 18)
        Me.chkSelectAll.TabIndex = 0
        Me.chkSelectAll.Text = "Seleccionar Todos"
        '
        'ControlContainerItem4
        '
        Me.ControlContainerItem4.AllowItemResize = False
        Me.ControlContainerItem4.Control = Me.chkSelectAll
        Me.ControlContainerItem4.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
        Me.ControlContainerItem4.Name = "ControlContainerItem4"
        '
        'ExpandablePanel1
        '
        Me.ExpandablePanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.ExpandablePanel1.CollapseDirection = DevComponents.DotNetBar.eCollapseDirection.RightToLeft
        Me.ExpandablePanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.ExpandablePanel1.Controls.Add(Me.GroupPanel1)
        Me.ExpandablePanel1.Controls.Add(Me.Bar1)
        Me.ExpandablePanel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.ExpandablePanel1.Location = New System.Drawing.Point(1, 1)
        Me.ExpandablePanel1.Name = "ExpandablePanel1"
        Me.ExpandablePanel1.Size = New System.Drawing.Size(280, 464)
        Me.ExpandablePanel1.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.ExpandablePanel1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.ExpandablePanel1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.ExpandablePanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.ExpandablePanel1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.ExpandablePanel1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
        Me.ExpandablePanel1.Style.GradientAngle = 90
        Me.ExpandablePanel1.TabIndex = 132
        Me.ExpandablePanel1.TitleStyle.Alignment = System.Drawing.StringAlignment.Center
        Me.ExpandablePanel1.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.ExpandablePanel1.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.ExpandablePanel1.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner
        Me.ExpandablePanel1.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.ExpandablePanel1.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.ExpandablePanel1.TitleStyle.GradientAngle = 90
        Me.ExpandablePanel1.TitleText = "Filtrar por"
        '
        'GroupPanel1
        '
        Me.GroupPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.cmbCPoblado)
        Me.GroupPanel1.Controls.Add(Me.LabelX25)
        Me.GroupPanel1.Controls.Add(Me.cmbJunta)
        Me.GroupPanel1.Controls.Add(Me.LabelX4)
        Me.GroupPanel1.Controls.Add(Me.LabelX16)
        Me.GroupPanel1.Controls.Add(Me.lblUnidad)
        Me.GroupPanel1.Controls.Add(Me.txtValorSubTarifa)
        Me.GroupPanel1.Controls.Add(Me.txtTipoTarifa)
        Me.GroupPanel1.Controls.Add(Me.LabelX13)
        Me.GroupPanel1.Controls.Add(Me.cmbSubTipoTarifa)
        Me.GroupPanel1.Controls.Add(Me.cmbCalles)
        Me.GroupPanel1.Controls.Add(Me.LabelX3)
        Me.GroupPanel1.Controls.Add(Me.LabelX18)
        Me.GroupPanel1.Controls.Add(Me.cmbMes)
        Me.GroupPanel1.Controls.Add(Me.LabelX1)
        Me.GroupPanel1.Controls.Add(Me.cmbAnio)
        Me.GroupPanel1.Location = New System.Drawing.Point(12, 42)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(262, 264)
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
        Me.GroupPanel1.TabIndex = 3
        Me.GroupPanel1.Text = "Parametros"
        '
        'cmbCPoblado
        '
        Me.cmbCPoblado.DisplayMember = "Text"
        Me.cmbCPoblado.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbCPoblado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCPoblado.FormattingEnabled = True
        Me.cmbCPoblado.ItemHeight = 15
        Me.cmbCPoblado.Location = New System.Drawing.Point(66, 38)
        Me.cmbCPoblado.Name = "cmbCPoblado"
        Me.cmbCPoblado.Size = New System.Drawing.Size(187, 21)
        Me.cmbCPoblado.TabIndex = 177
        '
        'LabelX25
        '
        Me.LabelX25.AutoSize = True
        Me.LabelX25.BackColor = System.Drawing.Color.Transparent
        Me.LabelX25.Location = New System.Drawing.Point(7, 40)
        Me.LabelX25.Name = "LabelX25"
        Me.LabelX25.Size = New System.Drawing.Size(60, 15)
        Me.LabelX25.TabIndex = 176
        Me.LabelX25.Text = "C. Poblado:"
        '
        'cmbJunta
        '
        Me.cmbJunta.DisplayMember = "Text"
        Me.cmbJunta.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbJunta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbJunta.FormattingEnabled = True
        Me.cmbJunta.ItemHeight = 17
        Me.cmbJunta.Location = New System.Drawing.Point(66, 4)
        Me.cmbJunta.Name = "cmbJunta"
        Me.cmbJunta.Size = New System.Drawing.Size(187, 23)
        Me.cmbJunta.TabIndex = 171
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        Me.LabelX4.Location = New System.Drawing.Point(8, 3)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(46, 19)
        Me.LabelX4.TabIndex = 170
        Me.LabelX4.Text = "JASS:"
        '
        'LabelX16
        '
        Me.LabelX16.AutoSize = True
        Me.LabelX16.BackColor = System.Drawing.Color.Transparent
        Me.LabelX16.Location = New System.Drawing.Point(3, 187)
        Me.LabelX16.Name = "LabelX16"
        Me.LabelX16.Size = New System.Drawing.Size(62, 15)
        Me.LabelX16.TabIndex = 169
        Me.LabelX16.Text = "Valor Tarifa:"
        Me.LabelX16.Visible = False
        '
        'lblUnidad
        '
        Me.lblUnidad.BackColor = System.Drawing.Color.Transparent
        Me.lblUnidad.Location = New System.Drawing.Point(171, 186)
        Me.lblUnidad.Name = "lblUnidad"
        Me.lblUnidad.Size = New System.Drawing.Size(34, 18)
        Me.lblUnidad.TabIndex = 167
        Me.lblUnidad.Text = "S/./m³"
        Me.lblUnidad.Visible = False
        '
        'txtValorSubTarifa
        '
        '
        '
        '
        Me.txtValorSubTarifa.Border.Class = "TextBoxBorder"
        Me.txtValorSubTarifa.Enabled = False
        Me.txtValorSubTarifa.Location = New System.Drawing.Point(3, 208)
        Me.txtValorSubTarifa.Name = "txtValorSubTarifa"
        Me.txtValorSubTarifa.ReadOnly = True
        Me.txtValorSubTarifa.Size = New System.Drawing.Size(96, 20)
        Me.txtValorSubTarifa.TabIndex = 168
        Me.txtValorSubTarifa.Visible = False
        '
        'txtTipoTarifa
        '
        '
        '
        '
        Me.txtTipoTarifa.Border.Class = "TextBoxBorder"
        Me.txtTipoTarifa.Location = New System.Drawing.Point(161, 208)
        Me.txtTipoTarifa.Name = "txtTipoTarifa"
        Me.txtTipoTarifa.ReadOnly = True
        Me.txtTipoTarifa.Size = New System.Drawing.Size(92, 20)
        Me.txtTipoTarifa.TabIndex = 165
        Me.txtTipoTarifa.Visible = False
        '
        'LabelX13
        '
        Me.LabelX13.AutoSize = True
        Me.LabelX13.BackColor = System.Drawing.Color.Transparent
        Me.LabelX13.Location = New System.Drawing.Point(4, 148)
        Me.LabelX13.Name = "LabelX13"
        Me.LabelX13.Size = New System.Drawing.Size(73, 15)
        Me.LabelX13.TabIndex = 164
        Me.LabelX13.Text = "Tipo de Tarifa:"
        Me.LabelX13.Visible = False
        '
        'cmbSubTipoTarifa
        '
        Me.cmbSubTipoTarifa.DisplayMember = "Text"
        Me.cmbSubTipoTarifa.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbSubTipoTarifa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSubTipoTarifa.FormattingEnabled = True
        Me.cmbSubTipoTarifa.ItemHeight = 14
        Me.cmbSubTipoTarifa.Location = New System.Drawing.Point(114, 147)
        Me.cmbSubTipoTarifa.Name = "cmbSubTipoTarifa"
        Me.cmbSubTipoTarifa.Size = New System.Drawing.Size(139, 20)
        Me.cmbSubTipoTarifa.TabIndex = 163
        Me.cmbSubTipoTarifa.Visible = False
        '
        'cmbCalles
        '
        Me.cmbCalles.DisplayMember = "Text"
        Me.cmbCalles.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbCalles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCalles.FormattingEnabled = True
        Me.cmbCalles.ItemHeight = 15
        Me.cmbCalles.Location = New System.Drawing.Point(65, 72)
        Me.cmbCalles.Name = "cmbCalles"
        Me.cmbCalles.Size = New System.Drawing.Size(188, 21)
        Me.cmbCalles.TabIndex = 162
        '
        'LabelX3
        '
        Me.LabelX3.AutoSize = True
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        Me.LabelX3.Location = New System.Drawing.Point(8, 73)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(31, 15)
        Me.LabelX3.TabIndex = 161
        Me.LabelX3.Text = "Calle:"
        '
        'LabelX18
        '
        Me.LabelX18.AutoSize = True
        Me.LabelX18.BackColor = System.Drawing.Color.Transparent
        Me.LabelX18.Location = New System.Drawing.Point(161, 110)
        Me.LabelX18.Name = "LabelX18"
        Me.LabelX18.Size = New System.Drawing.Size(26, 15)
        Me.LabelX18.TabIndex = 61
        Me.LabelX18.Text = "Mes:"
        '
        'cmbMes
        '
        Me.cmbMes.DisplayMember = "Text"
        Me.cmbMes.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMes.FormattingEnabled = True
        Me.cmbMes.ItemHeight = 14
        Me.cmbMes.Items.AddRange(New Object() {Me.ComboItem1, Me.ComboItem2})
        Me.cmbMes.Location = New System.Drawing.Point(193, 108)
        Me.cmbMes.Name = "cmbMes"
        Me.cmbMes.Size = New System.Drawing.Size(60, 20)
        Me.cmbMes.TabIndex = 60
        '
        'ComboItem1
        '
        Me.ComboItem1.Text = "I"
        Me.ComboItem1.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'ComboItem2
        '
        Me.ComboItem2.Text = "II"
        Me.ComboItem2.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX1
        '
        Me.LabelX1.AutoSize = True
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        Me.LabelX1.Location = New System.Drawing.Point(7, 111)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(56, 15)
        Me.LabelX1.TabIndex = 59
        Me.LabelX1.Text = "Año Tarifa:"
        '
        'cmbAnio
        '
        Me.cmbAnio.DisplayMember = "Text"
        Me.cmbAnio.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbAnio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAnio.FormattingEnabled = True
        Me.cmbAnio.ItemHeight = 14
        Me.cmbAnio.Location = New System.Drawing.Point(66, 108)
        Me.cmbAnio.Name = "cmbAnio"
        Me.cmbAnio.Size = New System.Drawing.Size(89, 20)
        Me.cmbAnio.TabIndex = 58
        '
        'Bar1
        '
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.DockSide = DevComponents.DotNetBar.eDockSide.Left
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnconsultar1, Me.btnFiltrar1})
        Me.Bar1.Location = New System.Drawing.Point(0, 439)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(280, 25)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Bar1.TabIndex = 22
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'btnconsultar1
        '
        Me.btnconsultar1.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnconsultar1.Image = Global.COBSER.My.Resources.Resources.application_view_columns
        Me.btnconsultar1.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.btnconsultar1.ImagePaddingHorizontal = 8
        Me.btnconsultar1.Name = "btnconsultar1"
        Me.btnconsultar1.Text = "Consultar"
        '
        'btnFiltrar1
        '
        Me.btnFiltrar1.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnFiltrar1.Image = Global.COBSER.My.Resources.Resources.arrow_join
        Me.btnFiltrar1.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.btnFiltrar1.ImagePaddingHorizontal = 8
        Me.btnFiltrar1.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.btnFiltrar1.Name = "btnFiltrar1"
        Me.btnFiltrar1.Text = "Filtrar Datos"
        '
        'Bar6
        '
        Me.Bar6.Controls.Add(Me.LabelX2)
        Me.Bar6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar6.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.Bar6.Location = New System.Drawing.Point(1, 465)
        Me.Bar6.Name = "Bar6"
        Me.Bar6.Size = New System.Drawing.Size(1041, 2)
        Me.Bar6.Stretch = True
        Me.Bar6.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Bar6.TabIndex = 131
        Me.Bar6.TabStop = False
        Me.Bar6.Text = "Bar6"
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        Me.LabelX2.Location = New System.Drawing.Point(31, 3)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(304, 20)
        Me.LabelX2.TabIndex = 53
        Me.LabelX2.Text = "Ejecutando consulta. Espere un momento porfavor."
        Me.LabelX2.Visible = False
        '
        'Bar2
        '
        Me.Bar2.Controls.Add(Me.lblEstadoMsg)
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.Bar2.Location = New System.Drawing.Point(1, 467)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(1041, 2)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Bar2.TabIndex = 130
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'lblEstadoMsg
        '
        Me.lblEstadoMsg.BackColor = System.Drawing.Color.Transparent
        Me.lblEstadoMsg.Location = New System.Drawing.Point(31, 3)
        Me.lblEstadoMsg.Name = "lblEstadoMsg"
        Me.lblEstadoMsg.Size = New System.Drawing.Size(304, 20)
        Me.lblEstadoMsg.TabIndex = 53
        Me.lblEstadoMsg.Text = "Ejecutando consulta. Espere un momento porfavor."
        Me.lblEstadoMsg.Visible = False
        '
        'TabItem1
        '
        Me.TabItem1.AttachedControl = Me.TabControlPanel1
        Me.TabItem1.Name = "TabItem1"
        Me.TabItem1.Text = "Generar Facturacion"
        '
        'TabControlPanel2
        '
        Me.TabControlPanel2.Controls.Add(Me.lblMontoTotal)
        Me.TabControlPanel2.Controls.Add(Me.LabelX21)
        Me.TabControlPanel2.Controls.Add(Me.Bar7)
        Me.TabControlPanel2.Controls.Add(Me.GroupPanel2)
        Me.TabControlPanel2.Controls.Add(Me.Bar8)
        Me.TabControlPanel2.Controls.Add(Me.dgFacturaciones)
        Me.TabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel2.Location = New System.Drawing.Point(0, 22)
        Me.TabControlPanel2.Name = "TabControlPanel2"
        Me.TabControlPanel2.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel2.Size = New System.Drawing.Size(1043, 470)
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
        'lblMontoTotal
        '
        Me.lblMontoTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblMontoTotal.AutoSize = True
        Me.lblMontoTotal.BackColor = System.Drawing.Color.Transparent
        Me.lblMontoTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMontoTotal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblMontoTotal.Location = New System.Drawing.Point(903, 420)
        Me.lblMontoTotal.Name = "lblMontoTotal"
        Me.lblMontoTotal.Size = New System.Drawing.Size(7, 17)
        Me.lblMontoTotal.TabIndex = 101
        Me.lblMontoTotal.Text = "-"
        '
        'LabelX21
        '
        Me.LabelX21.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LabelX21.AutoSize = True
        Me.LabelX21.BackColor = System.Drawing.Color.Transparent
        Me.LabelX21.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX21.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LabelX21.Location = New System.Drawing.Point(807, 421)
        Me.LabelX21.Name = "LabelX21"
        Me.LabelX21.Size = New System.Drawing.Size(75, 17)
        Me.LabelX21.TabIndex = 100
        Me.LabelX21.Text = "Monto Total:"
        '
        'Bar7
        '
        Me.Bar7.Controls.Add(Me.LabelX5)
        Me.Bar7.Controls.Add(Me.cmbJuntaC)
        Me.Bar7.Controls.Add(Me.cmbCaja)
        Me.Bar7.Controls.Add(Me.LabelX14)
        Me.Bar7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar7.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.Bar7.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ControlContainerItem5, Me.ControlContainerItem12, Me.ControlContainerItem13, Me.ControlContainerItem14})
        Me.Bar7.Location = New System.Drawing.Point(1, 1)
        Me.Bar7.Name = "Bar7"
        Me.Bar7.Size = New System.Drawing.Size(1041, 28)
        Me.Bar7.Stretch = True
        Me.Bar7.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Bar7.TabIndex = 27
        Me.Bar7.TabStop = False
        Me.Bar7.Text = "Bar7"
        '
        'LabelX5
        '
        Me.LabelX5.BackColor = System.Drawing.Color.Transparent
        Me.LabelX5.Location = New System.Drawing.Point(3, 5)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(114, 16)
        Me.LabelX5.TabIndex = 10
        Me.LabelX5.Text = "JASS:"
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
        Me.cmbJuntaC.Size = New System.Drawing.Size(160, 23)
        Me.cmbJuntaC.TabIndex = 11
        '
        'cmbCaja
        '
        Me.cmbCaja.DisplayMember = "Text"
        Me.cmbCaja.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbCaja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCaja.FormattingEnabled = True
        Me.cmbCaja.ItemHeight = 17
        Me.cmbCaja.Location = New System.Drawing.Point(329, 2)
        Me.cmbCaja.Name = "cmbCaja"
        Me.cmbCaja.Size = New System.Drawing.Size(173, 23)
        Me.cmbCaja.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003
        Me.cmbCaja.TabIndex = 13
        '
        'LabelX14
        '
        Me.LabelX14.BackColor = System.Drawing.Color.Transparent
        Me.LabelX14.Location = New System.Drawing.Point(285, 5)
        Me.LabelX14.Name = "LabelX14"
        Me.LabelX14.Size = New System.Drawing.Size(40, 16)
        Me.LabelX14.TabIndex = 12
        Me.LabelX14.Text = "Caja:"
        '
        'ControlContainerItem5
        '
        Me.ControlContainerItem5.AllowItemResize = False
        Me.ControlContainerItem5.Control = Me.LabelX5
        Me.ControlContainerItem5.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
        Me.ControlContainerItem5.Name = "ControlContainerItem5"
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
        'GroupPanel2
        '
        Me.GroupPanel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupPanel2.BackColor = System.Drawing.Color.Transparent
        Me.GroupPanel2.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.cmbCPoblado1)
        Me.GroupPanel2.Controls.Add(Me.LabelX10)
        Me.GroupPanel2.Controls.Add(Me.txtNombres)
        Me.GroupPanel2.Controls.Add(Me.txtApeMaterno)
        Me.GroupPanel2.Controls.Add(Me.txtApePaterno)
        Me.GroupPanel2.Controls.Add(Me.LabelX9)
        Me.GroupPanel2.Controls.Add(Me.LabelX8)
        Me.GroupPanel2.Controls.Add(Me.LabelX7)
        Me.GroupPanel2.Controls.Add(Me.cmbCalles1)
        Me.GroupPanel2.Controls.Add(Me.cmbAnio1)
        Me.GroupPanel2.Controls.Add(Me.LabelX15)
        Me.GroupPanel2.Controls.Add(Me.btnLoadPagos)
        Me.GroupPanel2.Controls.Add(Me.cmbMes1)
        Me.GroupPanel2.Controls.Add(Me.LabelX24)
        Me.GroupPanel2.Controls.Add(Me.LabelX6)
        Me.GroupPanel2.Location = New System.Drawing.Point(4, 35)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(1035, 90)
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
        Me.GroupPanel2.TabIndex = 26
        Me.GroupPanel2.Text = "Listar Facturaciones Segun"
        '
        'cmbCPoblado1
        '
        Me.cmbCPoblado1.DisplayMember = "Text"
        Me.cmbCPoblado1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbCPoblado1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCPoblado1.FormattingEnabled = True
        Me.cmbCPoblado1.ItemHeight = 15
        Me.cmbCPoblado1.Location = New System.Drawing.Point(80, 3)
        Me.cmbCPoblado1.Name = "cmbCPoblado1"
        Me.cmbCPoblado1.Size = New System.Drawing.Size(175, 21)
        Me.cmbCPoblado1.TabIndex = 179
        '
        'LabelX10
        '
        Me.LabelX10.AutoSize = True
        Me.LabelX10.BackColor = System.Drawing.Color.Transparent
        Me.LabelX10.Location = New System.Drawing.Point(9, 5)
        Me.LabelX10.Name = "LabelX10"
        Me.LabelX10.Size = New System.Drawing.Size(60, 15)
        Me.LabelX10.TabIndex = 178
        Me.LabelX10.Text = "C. Poblado:"
        '
        'txtNombres
        '
        '
        '
        '
        Me.txtNombres.Border.Class = "TextBoxBorder"
        Me.txtNombres.Location = New System.Drawing.Point(668, 40)
        Me.txtNombres.Name = "txtNombres"
        Me.txtNombres.Size = New System.Drawing.Size(129, 20)
        Me.txtNombres.TabIndex = 40
        '
        'txtApeMaterno
        '
        '
        '
        '
        Me.txtApeMaterno.Border.Class = "TextBoxBorder"
        Me.txtApeMaterno.Location = New System.Drawing.Point(336, 40)
        Me.txtApeMaterno.Name = "txtApeMaterno"
        Me.txtApeMaterno.Size = New System.Drawing.Size(129, 20)
        Me.txtApeMaterno.TabIndex = 39
        '
        'txtApePaterno
        '
        '
        '
        '
        Me.txtApePaterno.Border.Class = "TextBoxBorder"
        Me.txtApePaterno.Location = New System.Drawing.Point(80, 39)
        Me.txtApePaterno.Name = "txtApePaterno"
        Me.txtApePaterno.Size = New System.Drawing.Size(129, 20)
        Me.txtApePaterno.TabIndex = 38
        '
        'LabelX9
        '
        Me.LabelX9.AutoSize = True
        Me.LabelX9.BackColor = System.Drawing.Color.Transparent
        Me.LabelX9.Location = New System.Drawing.Point(604, 39)
        Me.LabelX9.Name = "LabelX9"
        Me.LabelX9.Size = New System.Drawing.Size(45, 15)
        Me.LabelX9.TabIndex = 37
        Me.LabelX9.Text = "Nombre:"
        '
        'LabelX8
        '
        Me.LabelX8.AutoSize = True
        Me.LabelX8.BackColor = System.Drawing.Color.Transparent
        Me.LabelX8.Location = New System.Drawing.Point(263, 41)
        Me.LabelX8.Name = "LabelX8"
        Me.LabelX8.Size = New System.Drawing.Size(71, 15)
        Me.LabelX8.TabIndex = 36
        Me.LabelX8.Text = "Ape. Materno:"
        '
        'LabelX7
        '
        Me.LabelX7.AutoSize = True
        Me.LabelX7.BackColor = System.Drawing.Color.Transparent
        Me.LabelX7.Location = New System.Drawing.Point(7, 39)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(70, 15)
        Me.LabelX7.TabIndex = 35
        Me.LabelX7.Text = "Ape. Paterno:"
        '
        'cmbCalles1
        '
        Me.cmbCalles1.DisplayMember = "Text"
        Me.cmbCalles1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbCalles1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCalles1.FormattingEnabled = True
        Me.cmbCalles1.ItemHeight = 14
        Me.cmbCalles1.Location = New System.Drawing.Point(336, 3)
        Me.cmbCalles1.Name = "cmbCalles1"
        Me.cmbCalles1.Size = New System.Drawing.Size(246, 20)
        Me.cmbCalles1.TabIndex = 34
        '
        'cmbAnio1
        '
        Me.cmbAnio1.DisplayMember = "Text"
        Me.cmbAnio1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbAnio1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAnio1.FormattingEnabled = True
        Me.cmbAnio1.ItemHeight = 14
        Me.cmbAnio1.Location = New System.Drawing.Point(668, 2)
        Me.cmbAnio1.Name = "cmbAnio1"
        Me.cmbAnio1.Size = New System.Drawing.Size(129, 20)
        Me.cmbAnio1.TabIndex = 33
        '
        'LabelX15
        '
        Me.LabelX15.AutoSize = True
        Me.LabelX15.BackColor = System.Drawing.Color.Transparent
        Me.LabelX15.Location = New System.Drawing.Point(267, 5)
        Me.LabelX15.Name = "LabelX15"
        Me.LabelX15.Size = New System.Drawing.Size(31, 15)
        Me.LabelX15.TabIndex = 30
        Me.LabelX15.Text = "Calle:"
        '
        'btnLoadPagos
        '
        Me.btnLoadPagos.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnLoadPagos.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnLoadPagos.Image = Global.COBSER.My.Resources.Resources.search
        Me.btnLoadPagos.Location = New System.Drawing.Point(868, 39)
        Me.btnLoadPagos.Name = "btnLoadPagos"
        Me.btnLoadPagos.Size = New System.Drawing.Size(124, 27)
        Me.btnLoadPagos.TabIndex = 32
        Me.btnLoadPagos.Text = "Mostrar"
        '
        'cmbMes1
        '
        Me.cmbMes1.DisplayMember = "Text"
        Me.cmbMes1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbMes1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMes1.FormattingEnabled = True
        Me.cmbMes1.ItemHeight = 14
        Me.cmbMes1.Location = New System.Drawing.Point(868, 1)
        Me.cmbMes1.Name = "cmbMes1"
        Me.cmbMes1.Size = New System.Drawing.Size(124, 20)
        Me.cmbMes1.TabIndex = 29
        '
        'LabelX24
        '
        Me.LabelX24.AutoSize = True
        Me.LabelX24.BackColor = System.Drawing.Color.Transparent
        Me.LabelX24.Location = New System.Drawing.Point(604, 5)
        Me.LabelX24.Name = "LabelX24"
        Me.LabelX24.Size = New System.Drawing.Size(25, 15)
        Me.LabelX24.TabIndex = 28
        Me.LabelX24.Text = "Año:"
        '
        'LabelX6
        '
        Me.LabelX6.AutoSize = True
        Me.LabelX6.BackColor = System.Drawing.Color.Transparent
        Me.LabelX6.Location = New System.Drawing.Point(819, 2)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(29, 15)
        Me.LabelX6.TabIndex = 26
        Me.LabelX6.Text = "Mes :"
        '
        'Bar8
        '
        Me.Bar8.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar8.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.Bar8.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnPreview, Me.btnPrint, Me.LabelItem2, Me.ButtonItem7, Me.lblRegistros, Me.ProgressBarItem3})
        Me.Bar8.Location = New System.Drawing.Point(1, 444)
        Me.Bar8.Name = "Bar8"
        Me.Bar8.Size = New System.Drawing.Size(1041, 25)
        Me.Bar8.Stretch = True
        Me.Bar8.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Bar8.TabIndex = 25
        Me.Bar8.TabStop = False
        Me.Bar8.Text = "Bar8"
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
        'ButtonItem7
        '
        Me.ButtonItem7.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem7.Image = Global.COBSER.My.Resources.Resources.cog_edit
        Me.ButtonItem7.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.ButtonItem7.ImagePaddingHorizontal = 8
        Me.ButtonItem7.Name = "ButtonItem7"
        Me.ButtonItem7.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnAnulaPago})
        Me.ButtonItem7.Text = "Operaciones"
        '
        'btnAnulaPago
        '
        Me.btnAnulaPago.Image = Global.COBSER.My.Resources.Resources.delete
        Me.btnAnulaPago.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.btnAnulaPago.ImagePaddingHorizontal = 8
        Me.btnAnulaPago.Name = "btnAnulaPago"
        Me.btnAnulaPago.Text = "Anular Recibo"
        '
        'lblRegistros
        '
        Me.lblRegistros.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.lblRegistros.Name = "lblRegistros"
        Me.lblRegistros.Text = "0 Registros encontrados"
        '
        'ProgressBarItem3
        '
        Me.ProgressBarItem3.ChunkGradientAngle = 0.0!
        Me.ProgressBarItem3.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.ProgressBarItem3.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
        Me.ProgressBarItem3.Name = "ProgressBarItem3"
        Me.ProgressBarItem3.RecentlyUsed = False
        Me.ProgressBarItem3.Width = 150
        '
        'dgFacturaciones
        '
        Me.dgFacturaciones.AllowUserToAddRows = False
        Me.dgFacturaciones.AllowUserToDeleteRows = False
        Me.dgFacturaciones.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgFacturaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgFacturaciones.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgFacturaciones.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgFacturaciones.Location = New System.Drawing.Point(3, 141)
        Me.dgFacturaciones.MultiSelect = False
        Me.dgFacturaciones.Name = "dgFacturaciones"
        Me.dgFacturaciones.ReadOnly = True
        Me.dgFacturaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgFacturaciones.Size = New System.Drawing.Size(1035, 273)
        Me.dgFacturaciones.TabIndex = 24
        '
        'TabItem2
        '
        Me.TabItem2.AttachedControl = Me.TabControlPanel2
        Me.TabItem2.Name = "TabItem2"
        Me.TabItem2.Text = "Facturaciones Generadas"
        '
        'ProgressBarItem1
        '
        Me.ProgressBarItem1.ChunkGradientAngle = 0.0!
        Me.ProgressBarItem1.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.ProgressBarItem1.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
        Me.ProgressBarItem1.Name = "ProgressBarItem1"
        Me.ProgressBarItem1.RecentlyUsed = False
        '
        'ControlContainerItem3
        '
        Me.ControlContainerItem3.AllowItemResize = False
        Me.ControlContainerItem3.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
        Me.ControlContainerItem3.Name = "ControlContainerItem3"
        '
        'pgb
        '
        Me.pgb.ChunkGradientAngle = 0.0!
        Me.pgb.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.pgb.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
        Me.pgb.Name = "pgb"
        Me.pgb.RecentlyUsed = False
        '
        'ControlContainerItem2
        '
        Me.ControlContainerItem2.AllowItemResize = False
        Me.ControlContainerItem2.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
        Me.ControlContainerItem2.Name = "ControlContainerItem2"
        '
        'ControlContainerItem1
        '
        Me.ControlContainerItem1.AllowItemResize = False
        Me.ControlContainerItem1.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
        Me.ControlContainerItem1.Name = "ControlContainerItem1"
        '
        'ControlContainerItem11
        '
        Me.ControlContainerItem11.AllowItemResize = False
        Me.ControlContainerItem11.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
        Me.ControlContainerItem11.Name = "ControlContainerItem11"
        '
        'Bar5
        '
        Me.Bar5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar5.DockSide = DevComponents.DotNetBar.eDockSide.Top
        Me.Bar5.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem2, Me.ButtonItem3})
        Me.Bar5.Location = New System.Drawing.Point(0, 339)
        Me.Bar5.Name = "Bar5"
        Me.Bar5.Size = New System.Drawing.Size(280, 25)
        Me.Bar5.Stretch = True
        Me.Bar5.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Bar5.TabIndex = 22
        Me.Bar5.TabStop = False
        Me.Bar5.Text = "Bar5"
        '
        'ButtonItem2
        '
        Me.ButtonItem2.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem2.Image = Global.COBSER.My.Resources.Resources.application_view_columns
        Me.ButtonItem2.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.ButtonItem2.ImagePaddingHorizontal = 8
        Me.ButtonItem2.Name = "ButtonItem2"
        Me.ButtonItem2.Text = "Consultar"
        '
        'ButtonItem3
        '
        Me.ButtonItem3.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem3.Image = Global.COBSER.My.Resources.Resources.arrow_join
        Me.ButtonItem3.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.ButtonItem3.ImagePaddingHorizontal = 8
        Me.ButtonItem3.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.ButtonItem3.Name = "ButtonItem3"
        Me.ButtonItem3.Text = "Filtrar Datos"
        '
        'btnCalcularDeuda
        '
        Me.btnCalcularDeuda.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnCalcularDeuda.Image = Global.COBSER.My.Resources.Resources.pago
        Me.btnCalcularDeuda.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.btnCalcularDeuda.ImagePaddingHorizontal = 8
        Me.btnCalcularDeuda.Name = "btnCalcularDeuda"
        Me.btnCalcularDeuda.Text = "Generar Facturacion"
        '
        'btnVisualizar
        '
        Me.btnVisualizar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnVisualizar.Image = Global.COBSER.My.Resources.Resources.application_view_columns
        Me.btnVisualizar.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.btnVisualizar.ImagePaddingHorizontal = 8
        Me.btnVisualizar.Name = "btnVisualizar"
        Me.btnVisualizar.Text = "Consultar"
        '
        'btnFiltrar
        '
        Me.btnFiltrar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnFiltrar.Image = Global.COBSER.My.Resources.Resources.arrow_join
        Me.btnFiltrar.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.btnFiltrar.ImagePaddingHorizontal = 8
        Me.btnFiltrar.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.btnFiltrar.Name = "btnFiltrar"
        Me.btnFiltrar.Text = "Filtrar Datos"
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
        'ButtonItem1
        '
        Me.ButtonItem1.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem1.Image = Global.COBSER.My.Resources.Resources.pago
        Me.ButtonItem1.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.ButtonItem1.ImagePaddingHorizontal = 8
        Me.ButtonItem1.Name = "ButtonItem1"
        Me.ButtonItem1.Text = "Generar Facturacion"
        '
        'ButtonItem4
        '
        Me.ButtonItem4.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem4.Image = Global.COBSER.My.Resources.Resources.application_view_columns
        Me.ButtonItem4.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.ButtonItem4.ImagePaddingHorizontal = 8
        Me.ButtonItem4.Name = "ButtonItem4"
        Me.ButtonItem4.Text = "Consultar"
        '
        'ButtonItem5
        '
        Me.ButtonItem5.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem5.Image = Global.COBSER.My.Resources.Resources.arrow_join
        Me.ButtonItem5.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.ButtonItem5.ImagePaddingHorizontal = 8
        Me.ButtonItem5.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.ButtonItem5.Name = "ButtonItem5"
        Me.ButtonItem5.Text = "Filtrar Datos"
        '
        'ButtonItem6
        '
        Me.ButtonItem6.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem6.Image = Global.COBSER.My.Resources.Resources.pago
        Me.ButtonItem6.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.ButtonItem6.ImagePaddingHorizontal = 8
        Me.ButtonItem6.Name = "ButtonItem6"
        Me.ButtonItem6.Text = "Generar Facturacion"
        '
        'frmFacturacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1043, 492)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "frmFacturacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmFacturacion"
        CType(Me.TabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabControlPanel1.ResumeLayout(False)
        Me.ExpandablePanel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.tvPredios, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Bar3.ResumeLayout(False)
        CType(Me.Bar4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Bar4.ResumeLayout(False)
        Me.Bar4.PerformLayout()
        Me.ExpandablePanel1.ResumeLayout(False)
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupPanel1.PerformLayout()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Bar6.ResumeLayout(False)
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Bar2.ResumeLayout(False)
        Me.TabControlPanel2.ResumeLayout(False)
        Me.TabControlPanel2.PerformLayout()
        CType(Me.Bar7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Bar7.ResumeLayout(False)
        Me.GroupPanel2.ResumeLayout(False)
        Me.GroupPanel2.PerformLayout()
        CType(Me.Bar8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgFacturaciones, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As DevComponents.DotNetBar.TabControl
    Friend WithEvents TabControlPanel1 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents TabItem1 As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControlPanel2 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents TabItem2 As DevComponents.DotNetBar.TabItem
    Friend WithEvents BtnLimpiaBuscar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem19 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ControlContainerItem1 As DevComponents.DotNetBar.ControlContainerItem
    Friend WithEvents ControlContainerItem11 As DevComponents.DotNetBar.ControlContainerItem
    Friend WithEvents btnCalcularDeuda As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents pgb As DevComponents.DotNetBar.ProgressBarItem
    Friend WithEvents ControlContainerItem2 As DevComponents.DotNetBar.ControlContainerItem
    Friend WithEvents btnVisualizar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnFiltrar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ProgressBarItem1 As DevComponents.DotNetBar.ProgressBarItem
    Friend WithEvents ControlContainerItem3 As DevComponents.DotNetBar.ControlContainerItem
    Friend WithEvents ButtonItem2 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem3 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents lblEstadoMsg As DevComponents.DotNetBar.LabelX
    Friend WithEvents Bar5 As DevComponents.DotNetBar.Bar
    Friend WithEvents ButtonItem1 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem4 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem5 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem6 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ExpandablePanel2 As DevComponents.DotNetBar.ExpandablePanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents tvPredios As DevComponents.AdvTree.AdvTree
    Friend WithEvents ColumnHeader1 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader2 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader3 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader4 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader5 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader6 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader7 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader8 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader9 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents NodeConnector1 As DevComponents.AdvTree.NodeConnector
    Friend WithEvents ElementStyle1 As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents Bar3 As DevComponents.DotNetBar.Bar
    Friend WithEvents lblTotalRegistros As DevComponents.DotNetBar.LabelX
    Friend WithEvents btnGenerar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ProgressBarItem2 As DevComponents.DotNetBar.ProgressBarItem
    Friend WithEvents Bar4 As DevComponents.DotNetBar.Bar
    Friend WithEvents chkSelectAll As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents ControlContainerItem4 As DevComponents.DotNetBar.ControlContainerItem
    Friend WithEvents ExpandablePanel1 As DevComponents.DotNetBar.ExpandablePanel
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents LabelX16 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblUnidad As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtValorSubTarifa As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtTipoTarifa As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX13 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cmbSubTipoTarifa As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents cmbCalles As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX18 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cmbMes As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents ComboItem1 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem2 As DevComponents.Editors.ComboItem
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cmbAnio As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents btnconsultar1 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnFiltrar1 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Bar6 As DevComponents.DotNetBar.Bar
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cmbJunta As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX15 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Bar7 As DevComponents.DotNetBar.Bar
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cmbJuntaC As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents cmbCaja As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX14 As DevComponents.DotNetBar.LabelX
    Friend WithEvents ControlContainerItem5 As DevComponents.DotNetBar.ControlContainerItem
    Friend WithEvents ControlContainerItem12 As DevComponents.DotNetBar.ControlContainerItem
    Friend WithEvents ControlContainerItem13 As DevComponents.DotNetBar.ControlContainerItem
    Friend WithEvents ControlContainerItem14 As DevComponents.DotNetBar.ControlContainerItem
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents btnLoadPagos As DevComponents.DotNetBar.ButtonX
    Friend WithEvents cmbMes1 As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX24 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Bar8 As DevComponents.DotNetBar.Bar
    Friend WithEvents btnPreview As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnPrint As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelItem2 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents ButtonItem7 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnAnulaPago As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents lblRegistros As DevComponents.DotNetBar.LabelItem
    Friend WithEvents ProgressBarItem3 As DevComponents.DotNetBar.ProgressBarItem
    Friend WithEvents dgFacturaciones As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents cmbAnio1 As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents lblMontoTotal As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX21 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX9 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX8 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cmbCalles1 As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents txtNombres As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtApeMaterno As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtApePaterno As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents cmbCPoblado As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX25 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblTotal As DevComponents.DotNetBar.LabelItem
    Friend WithEvents cmbCPoblado1 As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX10 As DevComponents.DotNetBar.LabelX
End Class
