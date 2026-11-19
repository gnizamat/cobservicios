<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGenerarDeudasMensuales
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
        Me.NodeConnector1 = New DevComponents.AdvTree.NodeConnector
        Me.ElementStyle1 = New DevComponents.DotNetBar.ElementStyle
        Me.Bar3 = New DevComponents.DotNetBar.Bar
        Me.lblTotalRegistros = New DevComponents.DotNetBar.LabelX
        Me.btnGeneraDeudas = New DevComponents.DotNetBar.ButtonItem
        Me.lblRegistrosCobranza = New DevComponents.DotNetBar.LabelItem
        Me.ProgressBarItem1 = New DevComponents.DotNetBar.ProgressBarItem
        Me.Bar4 = New DevComponents.DotNetBar.Bar
        Me.chkSelectAll = New DevComponents.DotNetBar.Controls.CheckBoxX
        Me.ControlContainerItem1 = New DevComponents.DotNetBar.ControlContainerItem
        Me.pgb = New DevComponents.DotNetBar.ProgressBarItem
        Me.ExpandablePanel1 = New DevComponents.DotNetBar.ExpandablePanel
        Me.chkUnicas = New DevComponents.DotNetBar.Controls.CheckBoxX
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.btnClear = New DevComponents.DotNetBar.ButtonX
        Me.cmbCPoblado = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.LabelX25 = New DevComponents.DotNetBar.LabelX
        Me.LabelX16 = New DevComponents.DotNetBar.LabelX
        Me.txtValorSubTarifa = New DevComponents.DotNetBar.Controls.TextBoxX
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
        Me.Bar5 = New DevComponents.DotNetBar.Bar
        Me.btnVisualizar = New DevComponents.DotNetBar.ButtonItem
        Me.btnFiltrar = New DevComponents.DotNetBar.ButtonItem
        Me.Bar2 = New DevComponents.DotNetBar.Bar
        Me.lblEstadoMsg = New DevComponents.DotNetBar.LabelX
        Me.imgEstadoMsg = New System.Windows.Forms.PictureBox
        Me.ControlContainerItem11 = New DevComponents.DotNetBar.ControlContainerItem
        Me.lblPredios = New DevComponents.DotNetBar.LabelItem
        Me.Bar1 = New DevComponents.DotNetBar.Bar
        Me.cmbJunta = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX
        Me.btnCalcularDeuda = New DevComponents.DotNetBar.ButtonItem
        Me.ExpandablePanel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.tvPredios, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Bar3.SuspendLayout()
        CType(Me.Bar4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Bar4.SuspendLayout()
        Me.ExpandablePanel1.SuspendLayout()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.Bar5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Bar2.SuspendLayout()
        CType(Me.imgEstadoMsg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Bar1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ExpandablePanel2
        '
        Me.ExpandablePanel2.CanvasColor = System.Drawing.SystemColors.Control
        Me.ExpandablePanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.ExpandablePanel2.Controls.Add(Me.Panel1)
        Me.ExpandablePanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ExpandablePanel2.ExpandButtonVisible = False
        Me.ExpandablePanel2.Location = New System.Drawing.Point(286, 25)
        Me.ExpandablePanel2.Name = "ExpandablePanel2"
        Me.ExpandablePanel2.Size = New System.Drawing.Size(792, 408)
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
        Me.ExpandablePanel2.TitleText = "Listado de Predios a Facturar Mensual"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.tvPredios)
        Me.Panel1.Controls.Add(Me.Bar3)
        Me.Panel1.Controls.Add(Me.Bar4)
        Me.Panel1.Location = New System.Drawing.Point(3, 27)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(786, 381)
        Me.Panel1.TabIndex = 22
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
        Me.tvPredios.DragDropEnabled = False
        Me.tvPredios.GridRowLines = True
        Me.tvPredios.HotTracking = True
        Me.tvPredios.Location = New System.Drawing.Point(0, 26)
        Me.tvPredios.Name = "tvPredios"
        Me.tvPredios.NodesConnector = Me.NodeConnector1
        Me.tvPredios.NodeStyle = Me.ElementStyle1
        Me.tvPredios.PathSeparator = ";"
        Me.tvPredios.SelectionBoxStyle = DevComponents.AdvTree.eSelectionStyle.FullRowSelect
        Me.tvPredios.Size = New System.Drawing.Size(777, 324)
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
        Me.ColumnHeader4.Text = "IdJAS"
        Me.ColumnHeader4.Width.Absolute = 60
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Name = "ColumnHeader5"
        Me.ColumnHeader5.Text = "IdPredio"
        Me.ColumnHeader5.Width.Absolute = 60
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Name = "ColumnHeader6"
        Me.ColumnHeader6.Text = "TipoTarifa"
        Me.ColumnHeader6.Width.Absolute = 60
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Name = "ColumnHeader7"
        Me.ColumnHeader7.Text = "IdCalle"
        Me.ColumnHeader7.Width.Absolute = 60
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
        Me.Bar3.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnGeneraDeudas, Me.lblRegistrosCobranza, Me.ProgressBarItem1})
        Me.Bar3.Location = New System.Drawing.Point(0, 356)
        Me.Bar3.Name = "Bar3"
        Me.Bar3.Size = New System.Drawing.Size(786, 25)
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
        Me.lblTotalRegistros.Location = New System.Drawing.Point(32452, 1373)
        Me.lblTotalRegistros.Name = "lblTotalRegistros"
        Me.lblTotalRegistros.Size = New System.Drawing.Size(227, 19)
        Me.lblTotalRegistros.TabIndex = 0
        Me.lblTotalRegistros.Text = "-"
        Me.lblTotalRegistros.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'btnGeneraDeudas
        '
        Me.btnGeneraDeudas.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnGeneraDeudas.Image = Global.COBSER.My.Resources.Resources.pago
        Me.btnGeneraDeudas.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.btnGeneraDeudas.ImagePaddingHorizontal = 8
        Me.btnGeneraDeudas.Name = "btnGeneraDeudas"
        Me.btnGeneraDeudas.Text = "Generar Deuda"
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
        '
        'Bar4
        '
        Me.Bar4.Controls.Add(Me.chkSelectAll)
        Me.Bar4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar4.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ControlContainerItem1})
        Me.Bar4.Location = New System.Drawing.Point(0, 0)
        Me.Bar4.Name = "Bar4"
        Me.Bar4.Size = New System.Drawing.Size(786, 23)
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
        'ControlContainerItem1
        '
        Me.ControlContainerItem1.AllowItemResize = False
        Me.ControlContainerItem1.Control = Me.chkSelectAll
        Me.ControlContainerItem1.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
        Me.ControlContainerItem1.Name = "ControlContainerItem1"
        '
        'pgb
        '
        Me.pgb.ChunkGradientAngle = 0.0!
        Me.pgb.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.pgb.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
        Me.pgb.Name = "pgb"
        Me.pgb.RecentlyUsed = False
        '
        'ExpandablePanel1
        '
        Me.ExpandablePanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.ExpandablePanel1.CollapseDirection = DevComponents.DotNetBar.eCollapseDirection.RightToLeft
        Me.ExpandablePanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.ExpandablePanel1.Controls.Add(Me.chkUnicas)
        Me.ExpandablePanel1.Controls.Add(Me.GroupPanel1)
        Me.ExpandablePanel1.Controls.Add(Me.Bar5)
        Me.ExpandablePanel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.ExpandablePanel1.Location = New System.Drawing.Point(0, 25)
        Me.ExpandablePanel1.Name = "ExpandablePanel1"
        Me.ExpandablePanel1.Size = New System.Drawing.Size(286, 408)
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
        'chkUnicas
        '
        Me.chkUnicas.AutoSize = True
        Me.chkUnicas.BackColor = System.Drawing.Color.Transparent
        Me.chkUnicas.Checked = True
        Me.chkUnicas.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkUnicas.CheckValue = "Y"
        Me.chkUnicas.Location = New System.Drawing.Point(8, 327)
        Me.chkUnicas.Name = "chkUnicas"
        Me.chkUnicas.Size = New System.Drawing.Size(92, 15)
        Me.chkUnicas.TabIndex = 23
        Me.chkUnicas.Text = "Servicio Unico"
        '
        'GroupPanel1
        '
        Me.GroupPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.btnClear)
        Me.GroupPanel1.Controls.Add(Me.cmbCPoblado)
        Me.GroupPanel1.Controls.Add(Me.LabelX25)
        Me.GroupPanel1.Controls.Add(Me.LabelX16)
        Me.GroupPanel1.Controls.Add(Me.txtValorSubTarifa)
        Me.GroupPanel1.Controls.Add(Me.LabelX13)
        Me.GroupPanel1.Controls.Add(Me.cmbSubTipoTarifa)
        Me.GroupPanel1.Controls.Add(Me.cmbCalles)
        Me.GroupPanel1.Controls.Add(Me.LabelX3)
        Me.GroupPanel1.Controls.Add(Me.LabelX18)
        Me.GroupPanel1.Controls.Add(Me.cmbMes)
        Me.GroupPanel1.Controls.Add(Me.LabelX1)
        Me.GroupPanel1.Controls.Add(Me.cmbAnio)
        Me.GroupPanel1.Location = New System.Drawing.Point(12, 41)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(268, 280)
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
        'btnClear
        '
        Me.btnClear.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnClear.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnClear.Image = Global.COBSER.My.Resources.Resources.sectores2
        Me.btnClear.Location = New System.Drawing.Point(9, 197)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(243, 48)
        Me.btnClear.TabIndex = 162
        Me.btnClear.Text = "Consultar Servicio Generado"
        Me.btnClear.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left
        '
        'cmbCPoblado
        '
        Me.cmbCPoblado.DisplayMember = "Text"
        Me.cmbCPoblado.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbCPoblado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCPoblado.FormattingEnabled = True
        Me.cmbCPoblado.ItemHeight = 15
        Me.cmbCPoblado.Location = New System.Drawing.Point(78, 11)
        Me.cmbCPoblado.Name = "cmbCPoblado"
        Me.cmbCPoblado.Size = New System.Drawing.Size(171, 21)
        Me.cmbCPoblado.TabIndex = 175
        '
        'LabelX25
        '
        Me.LabelX25.AutoSize = True
        Me.LabelX25.BackColor = System.Drawing.Color.Transparent
        Me.LabelX25.Location = New System.Drawing.Point(7, 14)
        Me.LabelX25.Name = "LabelX25"
        Me.LabelX25.Size = New System.Drawing.Size(60, 15)
        Me.LabelX25.TabIndex = 174
        Me.LabelX25.Text = "C. Poblado:"
        '
        'LabelX16
        '
        Me.LabelX16.AutoSize = True
        Me.LabelX16.BackColor = System.Drawing.Color.Transparent
        Me.LabelX16.Location = New System.Drawing.Point(6, 162)
        Me.LabelX16.Name = "LabelX16"
        Me.LabelX16.Size = New System.Drawing.Size(79, 15)
        Me.LabelX16.TabIndex = 169
        Me.LabelX16.Text = "Valor Tarifa S/.:"
        '
        'txtValorSubTarifa
        '
        '
        '
        '
        Me.txtValorSubTarifa.Border.Class = "TextBoxBorder"
        Me.txtValorSubTarifa.Enabled = False
        Me.txtValorSubTarifa.Location = New System.Drawing.Point(87, 157)
        Me.txtValorSubTarifa.Name = "txtValorSubTarifa"
        Me.txtValorSubTarifa.ReadOnly = True
        Me.txtValorSubTarifa.Size = New System.Drawing.Size(59, 20)
        Me.txtValorSubTarifa.TabIndex = 168
        '
        'LabelX13
        '
        Me.LabelX13.AutoSize = True
        Me.LabelX13.BackColor = System.Drawing.Color.Transparent
        Me.LabelX13.Location = New System.Drawing.Point(9, 123)
        Me.LabelX13.Name = "LabelX13"
        Me.LabelX13.Size = New System.Drawing.Size(73, 15)
        Me.LabelX13.TabIndex = 164
        Me.LabelX13.Text = "Tipo de Tarifa:"
        '
        'cmbSubTipoTarifa
        '
        Me.cmbSubTipoTarifa.DisplayMember = "Text"
        Me.cmbSubTipoTarifa.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbSubTipoTarifa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSubTipoTarifa.FormattingEnabled = True
        Me.cmbSubTipoTarifa.ItemHeight = 14
        Me.cmbSubTipoTarifa.Location = New System.Drawing.Point(87, 118)
        Me.cmbSubTipoTarifa.Name = "cmbSubTipoTarifa"
        Me.cmbSubTipoTarifa.Size = New System.Drawing.Size(162, 20)
        Me.cmbSubTipoTarifa.TabIndex = 163
        '
        'cmbCalles
        '
        Me.cmbCalles.DisplayMember = "Text"
        Me.cmbCalles.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbCalles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCalles.FormattingEnabled = True
        Me.cmbCalles.ItemHeight = 15
        Me.cmbCalles.Location = New System.Drawing.Point(78, 47)
        Me.cmbCalles.Name = "cmbCalles"
        Me.cmbCalles.Size = New System.Drawing.Size(171, 21)
        Me.cmbCalles.TabIndex = 162
        '
        'LabelX3
        '
        Me.LabelX3.AutoSize = True
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        Me.LabelX3.Location = New System.Drawing.Point(6, 47)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(31, 15)
        Me.LabelX3.TabIndex = 161
        Me.LabelX3.Text = "Calle:"
        '
        'LabelX18
        '
        Me.LabelX18.AutoSize = True
        Me.LabelX18.BackColor = System.Drawing.Color.Transparent
        Me.LabelX18.Location = New System.Drawing.Point(155, 85)
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
        Me.cmbMes.Location = New System.Drawing.Point(179, 80)
        Me.cmbMes.Name = "cmbMes"
        Me.cmbMes.Size = New System.Drawing.Size(70, 20)
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
        Me.LabelX1.Location = New System.Drawing.Point(7, 84)
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
        Me.cmbAnio.Location = New System.Drawing.Point(78, 80)
        Me.cmbAnio.Name = "cmbAnio"
        Me.cmbAnio.Size = New System.Drawing.Size(68, 20)
        Me.cmbAnio.TabIndex = 58
        '
        'Bar5
        '
        Me.Bar5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar5.DockSide = DevComponents.DotNetBar.eDockSide.Left
        Me.Bar5.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnVisualizar, Me.btnFiltrar})
        Me.Bar5.Location = New System.Drawing.Point(0, 383)
        Me.Bar5.Name = "Bar5"
        Me.Bar5.Size = New System.Drawing.Size(286, 25)
        Me.Bar5.Stretch = True
        Me.Bar5.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Bar5.TabIndex = 22
        Me.Bar5.TabStop = False
        Me.Bar5.Text = "Bar5"
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
        'Bar2
        '
        Me.Bar2.Controls.Add(Me.lblEstadoMsg)
        Me.Bar2.Controls.Add(Me.imgEstadoMsg)
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ControlContainerItem11, Me.lblPredios})
        Me.Bar2.Location = New System.Drawing.Point(0, 433)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(1078, 30)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Bar2.TabIndex = 131
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
        'imgEstadoMsg
        '
        Me.imgEstadoMsg.BackColor = System.Drawing.Color.Transparent
        Me.imgEstadoMsg.Location = New System.Drawing.Point(3, 2)
        Me.imgEstadoMsg.Name = "imgEstadoMsg"
        Me.imgEstadoMsg.Size = New System.Drawing.Size(22, 25)
        Me.imgEstadoMsg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.imgEstadoMsg.TabIndex = 52
        Me.imgEstadoMsg.TabStop = False
        Me.imgEstadoMsg.Visible = False
        '
        'ControlContainerItem11
        '
        Me.ControlContainerItem11.AllowItemResize = False
        Me.ControlContainerItem11.Control = Me.imgEstadoMsg
        Me.ControlContainerItem11.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
        Me.ControlContainerItem11.Name = "ControlContainerItem11"
        '
        'lblPredios
        '
        Me.lblPredios.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.lblPredios.Name = "lblPredios"
        Me.lblPredios.Text = "Realize una busqueda"
        '
        'Bar1
        '
        Me.Bar1.Controls.Add(Me.cmbJunta)
        Me.Bar1.Controls.Add(Me.LabelX4)
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar1.Location = New System.Drawing.Point(0, 0)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(1078, 25)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Bar1.TabIndex = 130
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'cmbJunta
        '
        Me.cmbJunta.DisplayMember = "Text"
        Me.cmbJunta.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbJunta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbJunta.FormattingEnabled = True
        Me.cmbJunta.ItemHeight = 17
        Me.cmbJunta.Location = New System.Drawing.Point(110, 1)
        Me.cmbJunta.Name = "cmbJunta"
        Me.cmbJunta.Size = New System.Drawing.Size(266, 23)
        Me.cmbJunta.TabIndex = 1
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        Me.LabelX4.Location = New System.Drawing.Point(12, 3)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(99, 19)
        Me.LabelX4.TabIndex = 0
        Me.LabelX4.Text = "JASS:"
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
        'frmGenerarDeudasMensuales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1078, 463)
        Me.Controls.Add(Me.ExpandablePanel2)
        Me.Controls.Add(Me.ExpandablePanel1)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.Bar1)
        Me.Name = "frmGenerarDeudasMensuales"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmGenerarDeudasMensuales"
        Me.ExpandablePanel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.tvPredios, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Bar3.ResumeLayout(False)
        CType(Me.Bar4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Bar4.ResumeLayout(False)
        Me.Bar4.PerformLayout()
        Me.ExpandablePanel1.ResumeLayout(False)
        Me.ExpandablePanel1.PerformLayout()
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupPanel1.PerformLayout()
        CType(Me.Bar5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Bar2.ResumeLayout(False)
        CType(Me.imgEstadoMsg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Bar1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ExpandablePanel2 As DevComponents.DotNetBar.ExpandablePanel
    Friend WithEvents btnCalcularDeuda As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents pgb As DevComponents.DotNetBar.ProgressBarItem
    Friend WithEvents ExpandablePanel1 As DevComponents.DotNetBar.ExpandablePanel
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents LabelX16 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtValorSubTarifa As DevComponents.DotNetBar.Controls.TextBoxX
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
    Friend WithEvents Bar5 As DevComponents.DotNetBar.Bar
    Friend WithEvents btnVisualizar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnFiltrar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents lblEstadoMsg As DevComponents.DotNetBar.LabelX
    Friend WithEvents imgEstadoMsg As System.Windows.Forms.PictureBox
    Friend WithEvents ControlContainerItem11 As DevComponents.DotNetBar.ControlContainerItem
    Friend WithEvents lblPredios As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents cmbJunta As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents tvPredios As DevComponents.AdvTree.AdvTree
    Friend WithEvents ColumnHeader1 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader2 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader3 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader4 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader5 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader6 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader7 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents NodeConnector1 As DevComponents.AdvTree.NodeConnector
    Friend WithEvents ElementStyle1 As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents Bar3 As DevComponents.DotNetBar.Bar
    Friend WithEvents lblTotalRegistros As DevComponents.DotNetBar.LabelX
    Friend WithEvents btnGeneraDeudas As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ProgressBarItem1 As DevComponents.DotNetBar.ProgressBarItem
    Friend WithEvents Bar4 As DevComponents.DotNetBar.Bar
    Friend WithEvents chkSelectAll As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents ControlContainerItem1 As DevComponents.DotNetBar.ControlContainerItem
    Friend WithEvents cmbCPoblado As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX25 As DevComponents.DotNetBar.LabelX
    Friend WithEvents chkUnicas As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents lblRegistrosCobranza As DevComponents.DotNetBar.LabelItem
    Friend WithEvents btnClear As DevComponents.DotNetBar.ButtonX
End Class
