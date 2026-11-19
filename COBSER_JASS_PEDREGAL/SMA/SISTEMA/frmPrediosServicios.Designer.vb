<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrediosServicios
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.pgb = New DevComponents.DotNetBar.ProgressBarItem
        Me.ColumnHeader12 = New DevComponents.AdvTree.ColumnHeader
        Me.ColumnHeader11 = New DevComponents.AdvTree.ColumnHeader
        Me.ColumnHeader10 = New DevComponents.AdvTree.ColumnHeader
        Me.ColumnHeader9 = New DevComponents.AdvTree.ColumnHeader
        Me.ColumnHeader8 = New DevComponents.AdvTree.ColumnHeader
        Me.ColumnHeader7 = New DevComponents.AdvTree.ColumnHeader
        Me.ColumnHeader6 = New DevComponents.AdvTree.ColumnHeader
        Me.ColumnHeader5 = New DevComponents.AdvTree.ColumnHeader
        Me.ColumnHeader4 = New DevComponents.AdvTree.ColumnHeader
        Me.ColumnHeader3 = New DevComponents.AdvTree.ColumnHeader
        Me.ColumnHeader2 = New DevComponents.AdvTree.ColumnHeader
        Me.ColumnHeader1 = New DevComponents.AdvTree.ColumnHeader
        Me.ElementStyle1 = New DevComponents.DotNetBar.ElementStyle
        Me.Bar5 = New DevComponents.DotNetBar.Bar
        Me.ButtonItem11 = New DevComponents.DotNetBar.ButtonItem
        Me.ButtonItem12 = New DevComponents.DotNetBar.ButtonItem
        Me.ButtonItem2 = New DevComponents.DotNetBar.ButtonItem
        Me.btnCorte = New DevComponents.DotNetBar.ButtonItem
        Me.ButtonItem17 = New DevComponents.DotNetBar.ButtonItem
        Me.ExpandablePanel2 = New DevComponents.DotNetBar.ExpandablePanel
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX
        Me.txtNroPredios = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.btnClear = New DevComponents.DotNetBar.ButtonX
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.LabelX12 = New DevComponents.DotNetBar.LabelX
        Me.txtValorServicio = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.LabelX11 = New DevComponents.DotNetBar.LabelX
        Me.cmbsector = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.cmbCPoblado = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.LabelX25 = New DevComponents.DotNetBar.LabelX
        Me.cmbEstado = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.ComboItem1 = New DevComponents.Editors.ComboItem
        Me.ComboItem2 = New DevComponents.Editors.ComboItem
        Me.LabelX10 = New DevComponents.DotNetBar.LabelX
        Me.cmbCalles = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX
        Me.cmbServicio = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.cmbJunta = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.txtDNI = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX
        Me.txtUAMaterno = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX
        Me.LabelX8 = New DevComponents.DotNetBar.LabelX
        Me.txtUNombre = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.txtUC = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.txtUAPaterno = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.LabelX9 = New DevComponents.DotNetBar.LabelX
        Me.gridPredios = New DevComponents.DotNetBar.Controls.DataGridViewX
        Me.ButtonItem1 = New DevComponents.DotNetBar.ButtonItem
        Me.btnCalcularDeuda = New DevComponents.DotNetBar.ButtonItem
        CType(Me.Bar5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExpandablePanel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.gridPredios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pgb
        '
        Me.pgb.ChunkGradientAngle = 0.0!
        Me.pgb.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.pgb.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
        Me.pgb.Name = "pgb"
        Me.pgb.RecentlyUsed = False
        '
        'ColumnHeader12
        '
        Me.ColumnHeader12.Name = "ColumnHeader12"
        Me.ColumnHeader12.Text = "IdPredio"
        Me.ColumnHeader12.Width.Absolute = 150
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Name = "ColumnHeader11"
        Me.ColumnHeader11.Text = "IdCalle"
        Me.ColumnHeader11.Width.Absolute = 150
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Name = "ColumnHeader10"
        Me.ColumnHeader10.Text = "Estado"
        Me.ColumnHeader10.Width.Absolute = 150
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Name = "ColumnHeader9"
        Me.ColumnHeader9.Text = "Fecha"
        Me.ColumnHeader9.Width.Absolute = 150
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Name = "ColumnHeader8"
        Me.ColumnHeader8.Text = "Calle"
        Me.ColumnHeader8.Width.Absolute = 60
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Name = "ColumnHeader7"
        Me.ColumnHeader7.Text = "Nro Doc"
        Me.ColumnHeader7.Width.Absolute = 60
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Name = "ColumnHeader6"
        Me.ColumnHeader6.Text = "Mes"
        Me.ColumnHeader6.Width.Absolute = 60
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Name = "ColumnHeader5"
        Me.ColumnHeader5.Text = "Año"
        Me.ColumnHeader5.Width.Absolute = 60
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Name = "ColumnHeader4"
        Me.ColumnHeader4.Text = "Monto"
        Me.ColumnHeader4.Width.Absolute = 60
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Name = "ColumnHeader3"
        Me.ColumnHeader3.Text = "Usuario"
        Me.ColumnHeader3.Width.Absolute = 120
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Name = "ColumnHeader2"
        Me.ColumnHeader2.Text = "Predio"
        Me.ColumnHeader2.Width.Absolute = 120
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Name = "ColumnHeader1"
        Me.ColumnHeader1.Text = "Nro"
        Me.ColumnHeader1.Width.Absolute = 60
        '
        'ElementStyle1
        '
        Me.ElementStyle1.Name = "ElementStyle1"
        Me.ElementStyle1.TextColor = System.Drawing.SystemColors.ControlText
        '
        'Bar5
        '
        Me.Bar5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar5.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.Bar5.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem11, Me.ButtonItem12, Me.ButtonItem2, Me.btnCorte, Me.ButtonItem17})
        Me.Bar5.Location = New System.Drawing.Point(0, 477)
        Me.Bar5.Name = "Bar5"
        Me.Bar5.Size = New System.Drawing.Size(901, 25)
        Me.Bar5.Stretch = True
        Me.Bar5.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Bar5.TabIndex = 30
        Me.Bar5.TabStop = False
        Me.Bar5.Text = "Bar5"
        '
        'ButtonItem11
        '
        Me.ButtonItem11.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem11.Image = Global.COBSER.My.Resources.Resources.add
        Me.ButtonItem11.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.ButtonItem11.ImagePaddingHorizontal = 8
        Me.ButtonItem11.Name = "ButtonItem11"
        Me.ButtonItem11.Text = "Asignar Servicios"
        '
        'ButtonItem12
        '
        Me.ButtonItem12.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem12.Image = Global.COBSER.My.Resources.Resources.delete
        Me.ButtonItem12.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.ButtonItem12.ImagePaddingHorizontal = 8
        Me.ButtonItem12.Name = "ButtonItem12"
        Me.ButtonItem12.Text = "Desactivar Servicio"
        '
        'ButtonItem2
        '
        Me.ButtonItem2.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem2.Image = Global.COBSER.My.Resources.Resources.accept
        Me.ButtonItem2.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.ButtonItem2.ImagePaddingHorizontal = 8
        Me.ButtonItem2.Name = "ButtonItem2"
        Me.ButtonItem2.Text = "Activar  Servicio"
        '
        'btnCorte
        '
        Me.btnCorte.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnCorte.Image = Global.COBSER.My.Resources.Resources.cog_edit
        Me.btnCorte.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.btnCorte.ImagePaddingHorizontal = 8
        Me.btnCorte.Name = "btnCorte"
        Me.btnCorte.Text = "Corte Servicio"
        '
        'ButtonItem17
        '
        Me.ButtonItem17.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem17.EnableMarkup = False
        Me.ButtonItem17.Image = Global.COBSER.My.Resources.Resources.page_right
        Me.ButtonItem17.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.ButtonItem17.ImagePaddingHorizontal = 8
        Me.ButtonItem17.Name = "ButtonItem17"
        Me.ButtonItem17.Text = "Salir"
        '
        'ExpandablePanel2
        '
        Me.ExpandablePanel2.CanvasColor = System.Drawing.SystemColors.Control
        Me.ExpandablePanel2.CollapseDirection = DevComponents.DotNetBar.eCollapseDirection.RightToLeft
        Me.ExpandablePanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.ExpandablePanel2.Controls.Add(Me.Panel3)
        Me.ExpandablePanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ExpandablePanel2.ExpandButtonVisible = False
        Me.ExpandablePanel2.Location = New System.Drawing.Point(0, 0)
        Me.ExpandablePanel2.Name = "ExpandablePanel2"
        Me.ExpandablePanel2.Size = New System.Drawing.Size(901, 528)
        Me.ExpandablePanel2.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.ExpandablePanel2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.ExpandablePanel2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.ExpandablePanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.ExpandablePanel2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.ExpandablePanel2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
        Me.ExpandablePanel2.Style.GradientAngle = 90
        Me.ExpandablePanel2.TabIndex = 130
        Me.ExpandablePanel2.TitleStyle.Alignment = System.Drawing.StringAlignment.Center
        Me.ExpandablePanel2.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.ExpandablePanel2.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.ExpandablePanel2.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner
        Me.ExpandablePanel2.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.ExpandablePanel2.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.ExpandablePanel2.TitleStyle.GradientAngle = 90
        Me.ExpandablePanel2.TitleText = "Listado de Predios Con Servicio"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.LabelX1)
        Me.Panel3.Controls.Add(Me.txtNroPredios)
        Me.Panel3.Controls.Add(Me.btnClear)
        Me.Panel3.Controls.Add(Me.GroupPanel1)
        Me.Panel3.Controls.Add(Me.Bar5)
        Me.Panel3.Controls.Add(Me.gridPredios)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 26)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(901, 502)
        Me.Panel3.TabIndex = 25
        '
        'LabelX1
        '
        Me.LabelX1.AutoSize = True
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        Me.LabelX1.Location = New System.Drawing.Point(711, 186)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(58, 15)
        Me.LabelX1.TabIndex = 33
        Me.LabelX1.Text = "N° Predios:"
        '
        'txtNroPredios
        '
        Me.txtNroPredios.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        '
        '
        '
        Me.txtNroPredios.Border.Class = "TextBoxBorder"
        Me.txtNroPredios.Location = New System.Drawing.Point(781, 185)
        Me.txtNroPredios.Name = "txtNroPredios"
        Me.txtNroPredios.ReadOnly = True
        Me.txtNroPredios.Size = New System.Drawing.Size(98, 20)
        Me.txtNroPredios.TabIndex = 1
        '
        'btnClear
        '
        Me.btnClear.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnClear.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnClear.Image = Global.COBSER.My.Resources.Resources.search
        Me.btnClear.Location = New System.Drawing.Point(21, 180)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(120, 20)
        Me.btnClear.TabIndex = 161
        Me.btnClear.Text = "Nueva Busqueda"
        Me.btnClear.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left
        '
        'GroupPanel1
        '
        Me.GroupPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.LabelX12)
        Me.GroupPanel1.Controls.Add(Me.txtValorServicio)
        Me.GroupPanel1.Controls.Add(Me.LabelX11)
        Me.GroupPanel1.Controls.Add(Me.cmbsector)
        Me.GroupPanel1.Controls.Add(Me.cmbCPoblado)
        Me.GroupPanel1.Controls.Add(Me.LabelX25)
        Me.GroupPanel1.Controls.Add(Me.cmbEstado)
        Me.GroupPanel1.Controls.Add(Me.LabelX10)
        Me.GroupPanel1.Controls.Add(Me.cmbCalles)
        Me.GroupPanel1.Controls.Add(Me.LabelX2)
        Me.GroupPanel1.Controls.Add(Me.LabelX4)
        Me.GroupPanel1.Controls.Add(Me.LabelX3)
        Me.GroupPanel1.Controls.Add(Me.cmbServicio)
        Me.GroupPanel1.Controls.Add(Me.cmbJunta)
        Me.GroupPanel1.Controls.Add(Me.txtDNI)
        Me.GroupPanel1.Controls.Add(Me.LabelX5)
        Me.GroupPanel1.Controls.Add(Me.LabelX7)
        Me.GroupPanel1.Controls.Add(Me.txtUAMaterno)
        Me.GroupPanel1.Controls.Add(Me.LabelX6)
        Me.GroupPanel1.Controls.Add(Me.LabelX8)
        Me.GroupPanel1.Controls.Add(Me.txtUNombre)
        Me.GroupPanel1.Controls.Add(Me.txtUC)
        Me.GroupPanel1.Controls.Add(Me.txtUAPaterno)
        Me.GroupPanel1.Controls.Add(Me.LabelX9)
        Me.GroupPanel1.DrawTitleBox = False
        Me.GroupPanel1.Location = New System.Drawing.Point(16, 9)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(863, 165)
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
        Me.GroupPanel1.TabIndex = 32
        Me.GroupPanel1.Text = "Criterios de busqueda"
        '
        'LabelX12
        '
        Me.LabelX12.AutoSize = True
        Me.LabelX12.BackColor = System.Drawing.Color.Transparent
        Me.LabelX12.Location = New System.Drawing.Point(303, 41)
        Me.LabelX12.Name = "LabelX12"
        Me.LabelX12.Size = New System.Drawing.Size(93, 15)
        Me.LabelX12.TabIndex = 175
        Me.LabelX12.Text = "Costo Servicio S/.:"
        '
        'txtValorServicio
        '
        '
        '
        '
        Me.txtValorServicio.Border.Class = "TextBoxBorder"
        Me.txtValorServicio.Enabled = False
        Me.txtValorServicio.Location = New System.Drawing.Point(406, 36)
        Me.txtValorServicio.Name = "txtValorServicio"
        Me.txtValorServicio.Size = New System.Drawing.Size(153, 20)
        Me.txtValorServicio.TabIndex = 174
        '
        'LabelX11
        '
        Me.LabelX11.AutoSize = True
        Me.LabelX11.BackColor = System.Drawing.Color.Transparent
        Me.LabelX11.Location = New System.Drawing.Point(586, 37)
        Me.LabelX11.Name = "LabelX11"
        Me.LabelX11.Size = New System.Drawing.Size(37, 15)
        Me.LabelX11.TabIndex = 173
        Me.LabelX11.Text = "Sector:"
        '
        'cmbsector
        '
        Me.cmbsector.DisplayMember = "Text"
        Me.cmbsector.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbsector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbsector.FormattingEnabled = True
        Me.cmbsector.ItemHeight = 15
        Me.cmbsector.Location = New System.Drawing.Point(663, 37)
        Me.cmbsector.Name = "cmbsector"
        Me.cmbsector.Size = New System.Drawing.Size(170, 21)
        Me.cmbsector.TabIndex = 172
        '
        'cmbCPoblado
        '
        Me.cmbCPoblado.DisplayMember = "Text"
        Me.cmbCPoblado.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbCPoblado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCPoblado.FormattingEnabled = True
        Me.cmbCPoblado.ItemHeight = 14
        Me.cmbCPoblado.Location = New System.Drawing.Point(406, 3)
        Me.cmbCPoblado.Name = "cmbCPoblado"
        Me.cmbCPoblado.Size = New System.Drawing.Size(153, 20)
        Me.cmbCPoblado.TabIndex = 170
        Me.cmbCPoblado.WatermarkText = "Seleccione un CP"
        '
        'LabelX25
        '
        Me.LabelX25.AutoSize = True
        Me.LabelX25.BackColor = System.Drawing.Color.Transparent
        Me.LabelX25.Location = New System.Drawing.Point(303, 8)
        Me.LabelX25.Name = "LabelX25"
        Me.LabelX25.Size = New System.Drawing.Size(60, 15)
        Me.LabelX25.TabIndex = 171
        Me.LabelX25.Text = "C. Poblado:"
        '
        'cmbEstado
        '
        Me.cmbEstado.DisplayMember = "Text"
        Me.cmbEstado.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstado.FormattingEnabled = True
        Me.cmbEstado.ItemHeight = 14
        Me.cmbEstado.Items.AddRange(New Object() {Me.ComboItem1, Me.ComboItem2})
        Me.cmbEstado.Location = New System.Drawing.Point(663, 109)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.Size = New System.Drawing.Size(170, 20)
        Me.cmbEstado.TabIndex = 169
        '
        'ComboItem1
        '
        Me.ComboItem1.Text = "Activos"
        '
        'ComboItem2
        '
        Me.ComboItem2.Text = "Inactivos"
        '
        'LabelX10
        '
        Me.LabelX10.AutoSize = True
        Me.LabelX10.BackColor = System.Drawing.Color.Transparent
        Me.LabelX10.Location = New System.Drawing.Point(586, 112)
        Me.LabelX10.Name = "LabelX10"
        Me.LabelX10.Size = New System.Drawing.Size(70, 15)
        Me.LabelX10.TabIndex = 168
        Me.LabelX10.Text = "Listar Estado:"
        '
        'cmbCalles
        '
        Me.cmbCalles.DisplayMember = "Text"
        Me.cmbCalles.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbCalles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCalles.FormattingEnabled = True
        Me.cmbCalles.ItemHeight = 15
        Me.cmbCalles.Location = New System.Drawing.Point(663, 2)
        Me.cmbCalles.Name = "cmbCalles"
        Me.cmbCalles.Size = New System.Drawing.Size(170, 21)
        Me.cmbCalles.TabIndex = 160
        '
        'LabelX2
        '
        Me.LabelX2.AutoSize = True
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        Me.LabelX2.Location = New System.Drawing.Point(586, 2)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(31, 15)
        Me.LabelX2.TabIndex = 142
        Me.LabelX2.Text = "Calle:"
        '
        'LabelX4
        '
        Me.LabelX4.AutoSize = True
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        Me.LabelX4.Location = New System.Drawing.Point(12, 44)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(69, 15)
        Me.LabelX4.TabIndex = 155
        Me.LabelX4.Text = "Tipo Servicio:"
        '
        'LabelX3
        '
        Me.LabelX3.AutoSize = True
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        Me.LabelX3.Location = New System.Drawing.Point(11, 9)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(33, 15)
        Me.LabelX3.TabIndex = 150
        Me.LabelX3.Text = "JASS:"
        '
        'cmbServicio
        '
        Me.cmbServicio.DisplayMember = "Text"
        Me.cmbServicio.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbServicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbServicio.FormattingEnabled = True
        Me.cmbServicio.ItemHeight = 15
        Me.cmbServicio.Location = New System.Drawing.Point(111, 37)
        Me.cmbServicio.Name = "cmbServicio"
        Me.cmbServicio.Size = New System.Drawing.Size(150, 21)
        Me.cmbServicio.TabIndex = 145
        '
        'cmbJunta
        '
        Me.cmbJunta.DisplayMember = "Text"
        Me.cmbJunta.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbJunta.DropDownHeight = 400
        Me.cmbJunta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbJunta.FormattingEnabled = True
        Me.cmbJunta.IntegralHeight = False
        Me.cmbJunta.ItemHeight = 15
        Me.cmbJunta.Location = New System.Drawing.Point(111, 5)
        Me.cmbJunta.Name = "cmbJunta"
        Me.cmbJunta.Size = New System.Drawing.Size(150, 21)
        Me.cmbJunta.TabIndex = 143
        '
        'txtDNI
        '
        '
        '
        '
        Me.txtDNI.Border.Class = "TextBoxBorder"
        Me.txtDNI.Location = New System.Drawing.Point(112, 74)
        Me.txtDNI.Name = "txtDNI"
        Me.txtDNI.Size = New System.Drawing.Size(149, 20)
        Me.txtDNI.TabIndex = 149
        '
        'LabelX5
        '
        Me.LabelX5.AutoSize = True
        Me.LabelX5.BackColor = System.Drawing.Color.Transparent
        Me.LabelX5.Location = New System.Drawing.Point(12, 78)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(40, 15)
        Me.LabelX5.TabIndex = 158
        Me.LabelX5.Text = "N° DNI:"
        '
        'LabelX7
        '
        Me.LabelX7.AutoSize = True
        Me.LabelX7.BackColor = System.Drawing.Color.Transparent
        Me.LabelX7.Location = New System.Drawing.Point(586, 74)
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
        Me.txtUAMaterno.Location = New System.Drawing.Point(663, 72)
        Me.txtUAMaterno.Name = "txtUAMaterno"
        Me.txtUAMaterno.Size = New System.Drawing.Size(170, 20)
        Me.txtUAMaterno.TabIndex = 148
        '
        'LabelX6
        '
        Me.LabelX6.AutoSize = True
        Me.LabelX6.BackColor = System.Drawing.Color.Transparent
        Me.LabelX6.Location = New System.Drawing.Point(301, 76)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(70, 15)
        Me.LabelX6.TabIndex = 152
        Me.LabelX6.Text = "Ape. Paterno:"
        '
        'LabelX8
        '
        Me.LabelX8.AutoSize = True
        Me.LabelX8.BackColor = System.Drawing.Color.Transparent
        Me.LabelX8.Location = New System.Drawing.Point(12, 115)
        Me.LabelX8.Name = "LabelX8"
        Me.LabelX8.Size = New System.Drawing.Size(86, 15)
        Me.LabelX8.TabIndex = 144
        Me.LabelX8.Text = "Nombre Usuario:"
        '
        'txtUNombre
        '
        '
        '
        '
        Me.txtUNombre.Border.Class = "TextBoxBorder"
        Me.txtUNombre.Location = New System.Drawing.Point(112, 108)
        Me.txtUNombre.Name = "txtUNombre"
        Me.txtUNombre.Size = New System.Drawing.Size(149, 20)
        Me.txtUNombre.TabIndex = 146
        '
        'txtUC
        '
        '
        '
        '
        Me.txtUC.Border.Class = "TextBoxBorder"
        Me.txtUC.Location = New System.Drawing.Point(406, 109)
        Me.txtUC.Name = "txtUC"
        Me.txtUC.Size = New System.Drawing.Size(153, 20)
        Me.txtUC.TabIndex = 151
        '
        'txtUAPaterno
        '
        '
        '
        '
        Me.txtUAPaterno.Border.Class = "TextBoxBorder"
        Me.txtUAPaterno.Location = New System.Drawing.Point(406, 73)
        Me.txtUAPaterno.Name = "txtUAPaterno"
        Me.txtUAPaterno.Size = New System.Drawing.Size(153, 20)
        Me.txtUAPaterno.TabIndex = 147
        '
        'LabelX9
        '
        Me.LabelX9.AutoSize = True
        Me.LabelX9.BackColor = System.Drawing.Color.Transparent
        Me.LabelX9.Location = New System.Drawing.Point(301, 110)
        Me.LabelX9.Name = "LabelX9"
        Me.LabelX9.Size = New System.Drawing.Size(62, 15)
        Me.LabelX9.TabIndex = 154
        Me.LabelX9.Text = "N° de Casa:"
        '
        'gridPredios
        '
        Me.gridPredios.AllowUserToAddRows = False
        Me.gridPredios.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gridPredios.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.gridPredios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gridPredios.DefaultCellStyle = DataGridViewCellStyle2
        Me.gridPredios.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.gridPredios.Location = New System.Drawing.Point(12, 211)
        Me.gridPredios.Name = "gridPredios"
        Me.gridPredios.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gridPredios.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.gridPredios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridPredios.Size = New System.Drawing.Size(877, 260)
        Me.gridPredios.TabIndex = 2
        Me.gridPredios.VirtualMode = True
        '
        'ButtonItem1
        '
        Me.ButtonItem1.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem1.Image = Global.COBSER.My.Resources.Resources.delete
        Me.ButtonItem1.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.ButtonItem1.ImagePaddingHorizontal = 8
        Me.ButtonItem1.Name = "ButtonItem1"
        Me.ButtonItem1.Text = "Quitar Servicio"
        '
        'btnCalcularDeuda
        '
        Me.btnCalcularDeuda.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnCalcularDeuda.Image = Global.COBSER.My.Resources.Resources.door
        Me.btnCalcularDeuda.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.btnCalcularDeuda.ImagePaddingHorizontal = 8
        Me.btnCalcularDeuda.Name = "btnCalcularDeuda"
        Me.btnCalcularDeuda.Text = "Cerrar"
        '
        'frmPrediosServicios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(901, 528)
        Me.Controls.Add(Me.ExpandablePanel2)
        Me.Name = "frmPrediosServicios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmPrediosServicios"
        CType(Me.Bar5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExpandablePanel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupPanel1.PerformLayout()
        CType(Me.gridPredios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnCalcularDeuda As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents pgb As DevComponents.DotNetBar.ProgressBarItem
    Friend WithEvents ButtonItem1 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ColumnHeader12 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader11 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader10 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader9 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader8 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader7 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader6 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader5 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader4 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader3 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader2 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader1 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ElementStyle1 As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents Bar5 As DevComponents.DotNetBar.Bar
    Friend WithEvents ButtonItem11 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem12 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem17 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ExpandablePanel2 As DevComponents.DotNetBar.ExpandablePanel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents txtNroPredios As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents btnClear As DevComponents.DotNetBar.ButtonX
    Friend WithEvents cmbCalles As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cmbServicio As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents cmbJunta As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents txtDNI As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtUAMaterno As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX8 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtUNombre As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtUC As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtUAPaterno As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX9 As DevComponents.DotNetBar.LabelX
    Friend WithEvents gridPredios As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cmbEstado As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents ComboItem1 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem2 As DevComponents.Editors.ComboItem
    Friend WithEvents LabelX10 As DevComponents.DotNetBar.LabelX
    Friend WithEvents ButtonItem2 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents cmbCPoblado As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX25 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX11 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cmbsector As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX12 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtValorServicio As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents btnCorte As DevComponents.DotNetBar.ButtonItem
End Class
