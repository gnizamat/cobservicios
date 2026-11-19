<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAsistenciaUsuarios
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
        Me.ExpandablePanel2 = New DevComponents.DotNetBar.ExpandablePanel
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.gridUsuarios = New DevComponents.DotNetBar.Controls.DataGridViewX
        Me.Label8 = New System.Windows.Forms.Label
        Me.TxtPorcentaje = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtNroAsistentes = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.txtNroUsuarios = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.cmbCalles = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.cmbJunta = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX
        Me.cmbCPoblado = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.LabelX25 = New DevComponents.DotNetBar.LabelX
        Me.TxtCorrelativo = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.Label3 = New System.Windows.Forms.Label
        Me.btnClear = New DevComponents.DotNetBar.ButtonX
        Me.txtDNI = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.txtNombre = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblJuntaSelected2 = New DevComponents.DotNetBar.Controls.ReflectionLabel
        Me.Bar1 = New DevComponents.DotNetBar.Bar
        Me.btnUsuarioUpd = New DevComponents.DotNetBar.ButtonItem
        Me.ButtonItem1 = New DevComponents.DotNetBar.ButtonItem
        Me.ButtonItem2 = New DevComponents.DotNetBar.ButtonItem
        Me.ButtonItem3 = New DevComponents.DotNetBar.ButtonItem
        Me.btnExportar = New DevComponents.DotNetBar.ButtonItem
        Me.btnSalir = New DevComponents.DotNetBar.ButtonItem
        Me.Label7 = New System.Windows.Forms.Label
        Me.lblJuntaSelected = New System.Windows.Forms.Label
        Me.pnlJuntas = New DevComponents.DotNetBar.ExpandablePanel
        Me.tvJuntas = New System.Windows.Forms.TreeView
        Me.ExpandablePanel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.gridUsuarios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlJuntas.SuspendLayout()
        Me.SuspendLayout()
        '
        'ExpandablePanel2
        '
        Me.ExpandablePanel2.CanvasColor = System.Drawing.SystemColors.Control
        Me.ExpandablePanel2.CollapseDirection = DevComponents.DotNetBar.eCollapseDirection.RightToLeft
        Me.ExpandablePanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.ExpandablePanel2.Controls.Add(Me.Panel3)
        Me.ExpandablePanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ExpandablePanel2.ExpandButtonVisible = False
        Me.ExpandablePanel2.Location = New System.Drawing.Point(177, 0)
        Me.ExpandablePanel2.Name = "ExpandablePanel2"
        Me.ExpandablePanel2.Size = New System.Drawing.Size(871, 576)
        Me.ExpandablePanel2.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.ExpandablePanel2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.ExpandablePanel2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.ExpandablePanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.ExpandablePanel2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.ExpandablePanel2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
        Me.ExpandablePanel2.Style.GradientAngle = 90
        Me.ExpandablePanel2.TabIndex = 30
        Me.ExpandablePanel2.TitleStyle.Alignment = System.Drawing.StringAlignment.Center
        Me.ExpandablePanel2.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.ExpandablePanel2.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.ExpandablePanel2.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner
        Me.ExpandablePanel2.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.ExpandablePanel2.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.ExpandablePanel2.TitleStyle.GradientAngle = 90
        Me.ExpandablePanel2.TitleText = "Listado de Usuarios"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.gridUsuarios)
        Me.Panel3.Controls.Add(Me.Label8)
        Me.Panel3.Controls.Add(Me.TxtPorcentaje)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Controls.Add(Me.TxtNroAsistentes)
        Me.Panel3.Controls.Add(Me.txtNroUsuarios)
        Me.Panel3.Controls.Add(Me.GroupPanel1)
        Me.Panel3.Controls.Add(Me.lblJuntaSelected2)
        Me.Panel3.Controls.Add(Me.Bar1)
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Controls.Add(Me.lblJuntaSelected)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 26)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(871, 550)
        Me.Panel3.TabIndex = 25
        '
        'gridUsuarios
        '
        Me.gridUsuarios.AllowUserToAddRows = False
        Me.gridUsuarios.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gridUsuarios.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.gridUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gridUsuarios.DefaultCellStyle = DataGridViewCellStyle2
        Me.gridUsuarios.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.gridUsuarios.Location = New System.Drawing.Point(6, 207)
        Me.gridUsuarios.Name = "gridUsuarios"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gridUsuarios.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.gridUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridUsuarios.Size = New System.Drawing.Size(857, 312)
        Me.gridUsuarios.TabIndex = 37
        Me.gridUsuarios.VirtualMode = True
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(560, 149)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(112, 20)
        Me.Label8.TabIndex = 36
        Me.Label8.Text = "% Asistencia"
        '
        'TxtPorcentaje
        '
        Me.TxtPorcentaje.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        '
        '
        '
        Me.TxtPorcentaje.Border.Class = "TextBoxBorder"
        Me.TxtPorcentaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPorcentaje.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TxtPorcentaje.Location = New System.Drawing.Point(557, 172)
        Me.TxtPorcentaje.Name = "TxtPorcentaje"
        Me.TxtPorcentaje.ReadOnly = True
        Me.TxtPorcentaje.Size = New System.Drawing.Size(116, 26)
        Me.TxtPorcentaje.TabIndex = 35
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(368, 150)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(117, 20)
        Me.Label1.TabIndex = 34
        Me.Label1.Text = "N° Asistentes"
        '
        'TxtNroAsistentes
        '
        Me.TxtNroAsistentes.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        '
        '
        '
        Me.TxtNroAsistentes.Border.Class = "TextBoxBorder"
        Me.TxtNroAsistentes.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNroAsistentes.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TxtNroAsistentes.Location = New System.Drawing.Point(369, 174)
        Me.TxtNroAsistentes.Name = "TxtNroAsistentes"
        Me.TxtNroAsistentes.ReadOnly = True
        Me.TxtNroAsistentes.Size = New System.Drawing.Size(116, 26)
        Me.TxtNroAsistentes.TabIndex = 33
        '
        'txtNroUsuarios
        '
        Me.txtNroUsuarios.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        '
        '
        '
        Me.txtNroUsuarios.Border.Class = "TextBoxBorder"
        Me.txtNroUsuarios.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNroUsuarios.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtNroUsuarios.Location = New System.Drawing.Point(730, 172)
        Me.txtNroUsuarios.Name = "txtNroUsuarios"
        Me.txtNroUsuarios.ReadOnly = True
        Me.txtNroUsuarios.Size = New System.Drawing.Size(100, 26)
        Me.txtNroUsuarios.TabIndex = 1
        '
        'GroupPanel1
        '
        Me.GroupPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.cmbCalles)
        Me.GroupPanel1.Controls.Add(Me.cmbJunta)
        Me.GroupPanel1.Controls.Add(Me.LabelX1)
        Me.GroupPanel1.Controls.Add(Me.cmbCPoblado)
        Me.GroupPanel1.Controls.Add(Me.LabelX25)
        Me.GroupPanel1.Controls.Add(Me.TxtCorrelativo)
        Me.GroupPanel1.Controls.Add(Me.Label3)
        Me.GroupPanel1.Controls.Add(Me.btnClear)
        Me.GroupPanel1.Controls.Add(Me.txtDNI)
        Me.GroupPanel1.Controls.Add(Me.txtNombre)
        Me.GroupPanel1.Controls.Add(Me.Label5)
        Me.GroupPanel1.Controls.Add(Me.Label4)
        Me.GroupPanel1.Controls.Add(Me.Label2)
        Me.GroupPanel1.DrawTitleBox = False
        Me.GroupPanel1.Location = New System.Drawing.Point(5, 0)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(858, 142)
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
        'cmbCalles
        '
        Me.cmbCalles.DisplayMember = "Text"
        Me.cmbCalles.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbCalles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCalles.FormattingEnabled = True
        Me.cmbCalles.ItemHeight = 15
        Me.cmbCalles.Location = New System.Drawing.Point(146, 96)
        Me.cmbCalles.Name = "cmbCalles"
        Me.cmbCalles.Size = New System.Drawing.Size(250, 21)
        Me.cmbCalles.TabIndex = 178
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
        Me.cmbJunta.Location = New System.Drawing.Point(146, 0)
        Me.cmbJunta.Name = "cmbJunta"
        Me.cmbJunta.Size = New System.Drawing.Size(250, 23)
        Me.cmbJunta.TabIndex = 177
        Me.cmbJunta.WatermarkText = "Seleccione una Junta de Usuarios"
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        Me.LabelX1.Location = New System.Drawing.Point(23, 3)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(134, 19)
        Me.LabelX1.TabIndex = 176
        Me.LabelX1.Text = "JASS:"
        '
        'cmbCPoblado
        '
        Me.cmbCPoblado.DisplayMember = "Text"
        Me.cmbCPoblado.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbCPoblado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCPoblado.FormattingEnabled = True
        Me.cmbCPoblado.ItemHeight = 14
        Me.cmbCPoblado.Location = New System.Drawing.Point(588, 1)
        Me.cmbCPoblado.Name = "cmbCPoblado"
        Me.cmbCPoblado.Size = New System.Drawing.Size(221, 20)
        Me.cmbCPoblado.TabIndex = 174
        Me.cmbCPoblado.WatermarkText = "Seleccione un CP"
        '
        'LabelX25
        '
        Me.LabelX25.AutoSize = True
        Me.LabelX25.BackColor = System.Drawing.Color.Transparent
        Me.LabelX25.Location = New System.Drawing.Point(522, 6)
        Me.LabelX25.Name = "LabelX25"
        Me.LabelX25.Size = New System.Drawing.Size(60, 15)
        Me.LabelX25.TabIndex = 175
        Me.LabelX25.Text = "C. Poblado:"
        '
        'TxtCorrelativo
        '
        '
        '
        '
        Me.TxtCorrelativo.Border.Class = "TextBoxBorder"
        Me.TxtCorrelativo.Location = New System.Drawing.Point(665, 35)
        Me.TxtCorrelativo.Name = "TxtCorrelativo"
        Me.TxtCorrelativo.Size = New System.Drawing.Size(144, 20)
        Me.TxtCorrelativo.TabIndex = 12
        Me.TxtCorrelativo.WatermarkText = "Nº Correlativo"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(576, 39)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Nº Correlativo:"
        '
        'btnClear
        '
        Me.btnClear.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnClear.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnClear.Image = Global.COBSER.My.Resources.Resources.lightning
        Me.btnClear.Location = New System.Drawing.Point(678, 94)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(131, 23)
        Me.btnClear.TabIndex = 10
        Me.btnClear.Text = "Nueva Busqueda"
        Me.btnClear.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left
        '
        'txtDNI
        '
        '
        '
        '
        Me.txtDNI.Border.Class = "TextBoxBorder"
        Me.txtDNI.Location = New System.Drawing.Point(146, 32)
        Me.txtDNI.Name = "txtDNI"
        Me.txtDNI.Size = New System.Drawing.Size(137, 20)
        Me.txtDNI.TabIndex = 7
        Me.txtDNI.WatermarkText = "Documento del Usuario"
        '
        'txtNombre
        '
        Me.txtNombre.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        '
        '
        '
        Me.txtNombre.Border.Class = "TextBoxBorder"
        Me.txtNombre.Location = New System.Drawing.Point(146, 61)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(663, 20)
        Me.txtNombre.TabIndex = 4
        Me.txtNombre.WatermarkText = "Apellidos y Nombres"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(20, 37)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 13)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Documento:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(20, 96)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Calles:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(20, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(102, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Apellidos y Nombres"
        '
        'lblJuntaSelected2
        '
        Me.lblJuntaSelected2.Location = New System.Drawing.Point(18, 159)
        Me.lblJuntaSelected2.Name = "lblJuntaSelected2"
        Me.lblJuntaSelected2.Size = New System.Drawing.Size(299, 38)
        Me.lblJuntaSelected2.TabIndex = 31
        Me.lblJuntaSelected2.Text = "<b><font size=""+6""><i>JASS</i><font color=""#B02B2C"">PEDREGAL</font></font></b>"
        '
        'Bar1
        '
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnUsuarioUpd, Me.ButtonItem1, Me.ButtonItem2, Me.ButtonItem3, Me.btnExportar, Me.btnSalir})
        Me.Bar1.Location = New System.Drawing.Point(0, 525)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(871, 25)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Bar1.TabIndex = 30
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'btnUsuarioUpd
        '
        Me.btnUsuarioUpd.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnUsuarioUpd.Image = Global.COBSER.My.Resources.Resources.ajax_loader2
        Me.btnUsuarioUpd.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.btnUsuarioUpd.ImagePaddingHorizontal = 8
        Me.btnUsuarioUpd.Name = "btnUsuarioUpd"
        Me.btnUsuarioUpd.Text = "Sortear"
        '
        'ButtonItem1
        '
        Me.ButtonItem1.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem1.Image = Global.COBSER.My.Resources.Resources.printer
        Me.ButtonItem1.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.ButtonItem1.ImagePaddingHorizontal = 8
        Me.ButtonItem1.Name = "ButtonItem1"
        Me.ButtonItem1.Text = "Padron General"
        '
        'ButtonItem2
        '
        Me.ButtonItem2.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem2.Image = Global.COBSER.My.Resources.Resources.application_view_columns
        Me.ButtonItem2.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.ButtonItem2.ImagePaddingHorizontal = 8
        Me.ButtonItem2.Name = "ButtonItem2"
        Me.ButtonItem2.Text = "Listar Asistencia"
        '
        'ButtonItem3
        '
        Me.ButtonItem3.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem3.Image = Global.COBSER.My.Resources.Resources.list_users
        Me.ButtonItem3.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.ButtonItem3.ImagePaddingHorizontal = 8
        Me.ButtonItem3.Name = "ButtonItem3"
        Me.ButtonItem3.Text = "Resumen Asistencia"
        '
        'btnExportar
        '
        Me.btnExportar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnExportar.Image = Global.COBSER.My.Resources.Resources.page_white_excel
        Me.btnExportar.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.btnExportar.ImagePaddingHorizontal = 8
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Text = "Exportar a Excel"
        '
        'btnSalir
        '
        Me.btnSalir.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnSalir.EnableMarkup = False
        Me.btnSalir.Image = Global.COBSER.My.Resources.Resources.page_right
        Me.btnSalir.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.btnSalir.ImagePaddingHorizontal = 8
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Text = "Salir"
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(734, 148)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(103, 20)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "N° Usuarios"
        '
        'lblJuntaSelected
        '
        Me.lblJuntaSelected.AutoSize = True
        Me.lblJuntaSelected.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblJuntaSelected.Location = New System.Drawing.Point(16, 158)
        Me.lblJuntaSelected.Name = "lblJuntaSelected"
        Me.lblJuntaSelected.Size = New System.Drawing.Size(201, 24)
        Me.lblJuntaSelected.TabIndex = 22
        Me.lblJuntaSelected.Text = "Selecciones una Junta"
        Me.lblJuntaSelected.Visible = False
        '
        'pnlJuntas
        '
        Me.pnlJuntas.CanvasColor = System.Drawing.SystemColors.Control
        Me.pnlJuntas.CollapseDirection = DevComponents.DotNetBar.eCollapseDirection.RightToLeft
        Me.pnlJuntas.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.pnlJuntas.Controls.Add(Me.tvJuntas)
        Me.pnlJuntas.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlJuntas.Location = New System.Drawing.Point(0, 0)
        Me.pnlJuntas.Name = "pnlJuntas"
        Me.pnlJuntas.Size = New System.Drawing.Size(177, 576)
        Me.pnlJuntas.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.pnlJuntas.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.pnlJuntas.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.pnlJuntas.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.pnlJuntas.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.pnlJuntas.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
        Me.pnlJuntas.Style.GradientAngle = 90
        Me.pnlJuntas.TabIndex = 29
        Me.pnlJuntas.TitleStyle.Alignment = System.Drawing.StringAlignment.Center
        Me.pnlJuntas.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.pnlJuntas.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.pnlJuntas.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner
        Me.pnlJuntas.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.pnlJuntas.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.pnlJuntas.TitleStyle.GradientAngle = 90
        Me.pnlJuntas.TitleText = "Juntas de Usuarios"
        '
        'tvJuntas
        '
        Me.tvJuntas.BackColor = System.Drawing.Color.White
        Me.tvJuntas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvJuntas.FullRowSelect = True
        Me.tvJuntas.HideSelection = False
        Me.tvJuntas.Location = New System.Drawing.Point(0, 26)
        Me.tvJuntas.Name = "tvJuntas"
        Me.tvJuntas.Size = New System.Drawing.Size(177, 550)
        Me.tvJuntas.TabIndex = 15
        '
        'frmAsistenciaUsuarios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1048, 576)
        Me.Controls.Add(Me.ExpandablePanel2)
        Me.Controls.Add(Me.pnlJuntas)
        Me.Name = "frmAsistenciaUsuarios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmAsistenciaUsuarios"
        Me.ExpandablePanel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.gridUsuarios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupPanel1.PerformLayout()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlJuntas.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ExpandablePanel2 As DevComponents.DotNetBar.ExpandablePanel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents gridUsuarios As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TxtPorcentaje As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtNroAsistentes As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtNroUsuarios As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents TxtCorrelativo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnClear As DevComponents.DotNetBar.ButtonX
    Friend WithEvents txtDNI As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtNombre As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblJuntaSelected2 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents btnUsuarioUpd As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem1 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem2 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem3 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnExportar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnSalir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblJuntaSelected As System.Windows.Forms.Label
    Friend WithEvents pnlJuntas As DevComponents.DotNetBar.ExpandablePanel
    Friend WithEvents tvJuntas As System.Windows.Forms.TreeView
    Friend WithEvents cmbCPoblado As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX25 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cmbJunta As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cmbCalles As DevComponents.DotNetBar.Controls.ComboBoxEx
End Class
