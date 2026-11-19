<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAsignarMedidor
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
        Me.btnCalcularDeuda = New DevComponents.DotNetBar.ButtonItem
        Me.btnAplicarDeuda = New DevComponents.DotNetBar.ButtonItem
        Me.btnCancelar = New DevComponents.DotNetBar.ButtonItem
        Me.pgb = New DevComponents.DotNetBar.ProgressBarItem
        Me.ControlContainerItem1 = New DevComponents.DotNetBar.ControlContainerItem
        Me.ExpandablePanel1 = New DevComponents.DotNetBar.ExpandablePanel
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.cmbTipoServicio = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.ComboItem1 = New DevComponents.Editors.ComboItem
        Me.ComboItem2 = New DevComponents.Editors.ComboItem
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX
        Me.chkUnicas = New DevComponents.DotNetBar.Controls.CheckBoxX
        Me.cmbCPoblado = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.LabelX25 = New DevComponents.DotNetBar.LabelX
        Me.LabelX12 = New DevComponents.DotNetBar.LabelX
        Me.txtValorServicio = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.txtObserv = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX
        Me.cmbServicio = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX
        Me.cmbCalles = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX
        Me.Bar5 = New DevComponents.DotNetBar.Bar
        Me.btnFiltrar = New DevComponents.DotNetBar.ButtonItem
        Me.Bar2 = New DevComponents.DotNetBar.Bar
        Me.lblEstadoMsg = New DevComponents.DotNetBar.LabelX
        Me.imgEstadoMsg = New System.Windows.Forms.PictureBox
        Me.ControlContainerItem11 = New DevComponents.DotNetBar.ControlContainerItem
        Me.lblPredios = New DevComponents.DotNetBar.LabelItem
        Me.Bar1 = New DevComponents.DotNetBar.Bar
        Me.cmbJunta = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX
        Me.ExpandablePanel2 = New DevComponents.DotNetBar.ExpandablePanel
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.Bar6 = New DevComponents.DotNetBar.Bar
        Me.chkSelectAll = New DevComponents.DotNetBar.CheckBoxItem
        Me.lblnro = New DevComponents.DotNetBar.LabelItem
        Me.Bar3 = New DevComponents.DotNetBar.Bar
        Me.Bar4 = New DevComponents.DotNetBar.Bar
        Me.btnGrabar = New DevComponents.DotNetBar.ButtonItem
        Me.ButtonItem17 = New DevComponents.DotNetBar.ButtonItem
        Me.gridPredios = New DevComponents.DotNetBar.Controls.DataGridViewX
        Me.txtNroPredios = New DevComponents.DotNetBar.TextBoxItem
        Me.ButtonItem18 = New DevComponents.DotNetBar.ButtonItem
        Me.ButtonItem19 = New DevComponents.DotNetBar.ButtonItem
        Me.ButtonItem2 = New DevComponents.DotNetBar.ButtonItem
        Me.ButtonItem3 = New DevComponents.DotNetBar.ButtonItem
        Me.ComboItem3 = New DevComponents.Editors.ComboItem
        Me.ExpandablePanel1.SuspendLayout()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.Bar5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Bar2.SuspendLayout()
        CType(Me.imgEstadoMsg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Bar1.SuspendLayout()
        Me.ExpandablePanel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.Bar6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridPredios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCalcularDeuda
        '
        Me.btnCalcularDeuda.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnCalcularDeuda.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.btnCalcularDeuda.ImagePaddingHorizontal = 8
        Me.btnCalcularDeuda.Name = "btnCalcularDeuda"
        Me.btnCalcularDeuda.Text = "Asignar Medidor"
        '
        'btnAplicarDeuda
        '
        Me.btnAplicarDeuda.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnAplicarDeuda.Enabled = False
        Me.btnAplicarDeuda.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.btnAplicarDeuda.ImagePaddingHorizontal = 8
        Me.btnAplicarDeuda.Name = "btnAplicarDeuda"
        Me.btnAplicarDeuda.Text = "Aplicar Deuda"
        '
        'btnCancelar
        '
        Me.btnCancelar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnCancelar.Enabled = False
        Me.btnCancelar.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.btnCancelar.ImagePaddingHorizontal = 8
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Text = "Cancelar"
        '
        'pgb
        '
        Me.pgb.ChunkGradientAngle = 0.0!
        Me.pgb.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.pgb.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
        Me.pgb.Name = "pgb"
        Me.pgb.RecentlyUsed = False
        '
        'ControlContainerItem1
        '
        Me.ControlContainerItem1.AllowItemResize = False
        Me.ControlContainerItem1.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
        Me.ControlContainerItem1.Name = "ControlContainerItem1"
        '
        'ExpandablePanel1
        '
        Me.ExpandablePanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.ExpandablePanel1.CollapseDirection = DevComponents.DotNetBar.eCollapseDirection.RightToLeft
        Me.ExpandablePanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.ExpandablePanel1.Controls.Add(Me.GroupPanel1)
        Me.ExpandablePanel1.Controls.Add(Me.Bar5)
        Me.ExpandablePanel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.ExpandablePanel1.Location = New System.Drawing.Point(0, 25)
        Me.ExpandablePanel1.Name = "ExpandablePanel1"
        Me.ExpandablePanel1.Size = New System.Drawing.Size(257, 456)
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
        Me.GroupPanel1.Controls.Add(Me.cmbTipoServicio)
        Me.GroupPanel1.Controls.Add(Me.LabelX2)
        Me.GroupPanel1.Controls.Add(Me.chkUnicas)
        Me.GroupPanel1.Controls.Add(Me.cmbCPoblado)
        Me.GroupPanel1.Controls.Add(Me.LabelX25)
        Me.GroupPanel1.Controls.Add(Me.LabelX12)
        Me.GroupPanel1.Controls.Add(Me.txtValorServicio)
        Me.GroupPanel1.Controls.Add(Me.txtObserv)
        Me.GroupPanel1.Controls.Add(Me.LabelX1)
        Me.GroupPanel1.Controls.Add(Me.cmbServicio)
        Me.GroupPanel1.Controls.Add(Me.LabelX5)
        Me.GroupPanel1.Controls.Add(Me.cmbCalles)
        Me.GroupPanel1.Controls.Add(Me.LabelX3)
        Me.GroupPanel1.Location = New System.Drawing.Point(12, 42)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(239, 259)
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
        '
        'cmbTipoServicio
        '
        Me.cmbTipoServicio.DisplayMember = "Text"
        Me.cmbTipoServicio.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbTipoServicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoServicio.FormattingEnabled = True
        Me.cmbTipoServicio.ItemHeight = 15
        Me.cmbTipoServicio.Items.AddRange(New Object() {Me.ComboItem1, Me.ComboItem2, Me.ComboItem3})
        Me.cmbTipoServicio.Location = New System.Drawing.Point(102, 75)
        Me.cmbTipoServicio.Name = "cmbTipoServicio"
        Me.cmbTipoServicio.Size = New System.Drawing.Size(118, 21)
        Me.cmbTipoServicio.TabIndex = 182
        '
        'ComboItem1
        '
        Me.ComboItem1.Text = "Agua"
        '
        'ComboItem2
        '
        Me.ComboItem2.Text = "Alcantarillado"
        '
        'LabelX2
        '
        Me.LabelX2.AutoSize = True
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        Me.LabelX2.Location = New System.Drawing.Point(3, 81)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(84, 15)
        Me.LabelX2.TabIndex = 181
        Me.LabelX2.Text = "Tipo de Servicio:"
        '
        'chkUnicas
        '
        Me.chkUnicas.AutoSize = True
        Me.chkUnicas.BackColor = System.Drawing.Color.Transparent
        Me.chkUnicas.Checked = True
        Me.chkUnicas.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkUnicas.CheckValue = "Y"
        Me.chkUnicas.Location = New System.Drawing.Point(3, 226)
        Me.chkUnicas.Name = "chkUnicas"
        Me.chkUnicas.Size = New System.Drawing.Size(92, 15)
        Me.chkUnicas.TabIndex = 180
        Me.chkUnicas.Text = "Servicio Unico"
        '
        'cmbCPoblado
        '
        Me.cmbCPoblado.DisplayMember = "Text"
        Me.cmbCPoblado.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbCPoblado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCPoblado.FormattingEnabled = True
        Me.cmbCPoblado.ItemHeight = 14
        Me.cmbCPoblado.Location = New System.Drawing.Point(61, 5)
        Me.cmbCPoblado.Name = "cmbCPoblado"
        Me.cmbCPoblado.Size = New System.Drawing.Size(159, 20)
        Me.cmbCPoblado.TabIndex = 178
        Me.cmbCPoblado.WatermarkText = "Seleccione un CP"
        '
        'LabelX25
        '
        Me.LabelX25.AutoSize = True
        Me.LabelX25.BackColor = System.Drawing.Color.Transparent
        Me.LabelX25.Location = New System.Drawing.Point(3, 7)
        Me.LabelX25.Name = "LabelX25"
        Me.LabelX25.Size = New System.Drawing.Size(60, 15)
        Me.LabelX25.TabIndex = 179
        Me.LabelX25.Text = "C. Poblado:"
        '
        'LabelX12
        '
        Me.LabelX12.AutoSize = True
        Me.LabelX12.BackColor = System.Drawing.Color.Transparent
        Me.LabelX12.Location = New System.Drawing.Point(3, 151)
        Me.LabelX12.Name = "LabelX12"
        Me.LabelX12.Size = New System.Drawing.Size(93, 15)
        Me.LabelX12.TabIndex = 177
        Me.LabelX12.Text = "Costo Servicio S/.:"
        '
        'txtValorServicio
        '
        '
        '
        '
        Me.txtValorServicio.Border.Class = "TextBoxBorder"
        Me.txtValorServicio.Enabled = False
        Me.txtValorServicio.Location = New System.Drawing.Point(102, 151)
        Me.txtValorServicio.Name = "txtValorServicio"
        Me.txtValorServicio.Size = New System.Drawing.Size(111, 20)
        Me.txtValorServicio.TabIndex = 176
        '
        'txtObserv
        '
        '
        '
        '
        Me.txtObserv.Border.Class = "TextBoxBorder"
        Me.txtObserv.Location = New System.Drawing.Point(102, 189)
        Me.txtObserv.Name = "txtObserv"
        Me.txtObserv.Size = New System.Drawing.Size(118, 20)
        Me.txtObserv.TabIndex = 169
        '
        'LabelX1
        '
        Me.LabelX1.AutoSize = True
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        Me.LabelX1.Location = New System.Drawing.Point(3, 193)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(79, 15)
        Me.LabelX1.TabIndex = 168
        Me.LabelX1.Text = "Observaciones:"
        '
        'cmbServicio
        '
        Me.cmbServicio.DisplayMember = "Text"
        Me.cmbServicio.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbServicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbServicio.FormattingEnabled = True
        Me.cmbServicio.ItemHeight = 15
        Me.cmbServicio.Location = New System.Drawing.Point(102, 113)
        Me.cmbServicio.Name = "cmbServicio"
        Me.cmbServicio.Size = New System.Drawing.Size(118, 21)
        Me.cmbServicio.TabIndex = 166
        '
        'LabelX5
        '
        Me.LabelX5.AutoSize = True
        Me.LabelX5.BackColor = System.Drawing.Color.Transparent
        Me.LabelX5.Location = New System.Drawing.Point(3, 114)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(45, 15)
        Me.LabelX5.TabIndex = 165
        Me.LabelX5.Text = "Servicio:"
        '
        'cmbCalles
        '
        Me.cmbCalles.DisplayMember = "Text"
        Me.cmbCalles.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbCalles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCalles.FormattingEnabled = True
        Me.cmbCalles.ItemHeight = 15
        Me.cmbCalles.Location = New System.Drawing.Point(61, 37)
        Me.cmbCalles.Name = "cmbCalles"
        Me.cmbCalles.Size = New System.Drawing.Size(159, 21)
        Me.cmbCalles.TabIndex = 162
        '
        'LabelX3
        '
        Me.LabelX3.AutoSize = True
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        Me.LabelX3.Location = New System.Drawing.Point(3, 43)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(31, 15)
        Me.LabelX3.TabIndex = 161
        Me.LabelX3.Text = "Calle:"
        '
        'Bar5
        '
        Me.Bar5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar5.DockSide = DevComponents.DotNetBar.eDockSide.Left
        Me.Bar5.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnFiltrar})
        Me.Bar5.Location = New System.Drawing.Point(0, 431)
        Me.Bar5.Name = "Bar5"
        Me.Bar5.Size = New System.Drawing.Size(257, 25)
        Me.Bar5.Stretch = True
        Me.Bar5.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Bar5.TabIndex = 22
        Me.Bar5.TabStop = False
        Me.Bar5.Text = "Bar5"
        '
        'btnFiltrar
        '
        Me.btnFiltrar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnFiltrar.Image = Global.COBSER.My.Resources.Resources.accept
        Me.btnFiltrar.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.btnFiltrar.ImagePaddingHorizontal = 8
        Me.btnFiltrar.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.btnFiltrar.Name = "btnFiltrar"
        Me.btnFiltrar.Text = "Agregar Servicio"
        '
        'Bar2
        '
        Me.Bar2.Controls.Add(Me.lblEstadoMsg)
        Me.Bar2.Controls.Add(Me.imgEstadoMsg)
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ControlContainerItem11, Me.lblPredios})
        Me.Bar2.Location = New System.Drawing.Point(0, 481)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(1005, 30)
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
        Me.Bar1.Size = New System.Drawing.Size(1005, 25)
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
        Me.LabelX4.Text = "AGUAS:"
        '
        'ExpandablePanel2
        '
        Me.ExpandablePanel2.CanvasColor = System.Drawing.SystemColors.Control
        Me.ExpandablePanel2.CollapseDirection = DevComponents.DotNetBar.eCollapseDirection.RightToLeft
        Me.ExpandablePanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.ExpandablePanel2.Controls.Add(Me.Panel3)
        Me.ExpandablePanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ExpandablePanel2.ExpandButtonVisible = False
        Me.ExpandablePanel2.Location = New System.Drawing.Point(257, 25)
        Me.ExpandablePanel2.Name = "ExpandablePanel2"
        Me.ExpandablePanel2.Size = New System.Drawing.Size(748, 456)
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
        Me.ExpandablePanel2.TitleText = "Listado de Predios"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Bar6)
        Me.Panel3.Controls.Add(Me.Bar3)
        Me.Panel3.Controls.Add(Me.Bar4)
        Me.Panel3.Controls.Add(Me.gridPredios)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 26)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(748, 430)
        Me.Panel3.TabIndex = 25
        '
        'Bar6
        '
        Me.Bar6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar6.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.Bar6.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.chkSelectAll, Me.lblnro})
        Me.Bar6.Location = New System.Drawing.Point(0, 2)
        Me.Bar6.Name = "Bar6"
        Me.Bar6.Size = New System.Drawing.Size(748, 25)
        Me.Bar6.Stretch = True
        Me.Bar6.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Bar6.TabIndex = 160
        Me.Bar6.TabStop = False
        Me.Bar6.Text = "Bar6"
        '
        'chkSelectAll
        '
        Me.chkSelectAll.Name = "chkSelectAll"
        Me.chkSelectAll.Text = "Seleccionar Todos"
        '
        'lblnro
        '
        Me.lblnro.ImagePosition = DevComponents.DotNetBar.eImagePosition.Right
        Me.lblnro.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.lblnro.Name = "lblnro"
        Me.lblnro.Text = "LabelItem1"
        Me.lblnro.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'Bar3
        '
        Me.Bar3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar3.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.Bar3.Location = New System.Drawing.Point(0, 0)
        Me.Bar3.Name = "Bar3"
        Me.Bar3.Size = New System.Drawing.Size(748, 2)
        Me.Bar3.Stretch = True
        Me.Bar3.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Bar3.TabIndex = 159
        Me.Bar3.TabStop = False
        Me.Bar3.Text = "Bar3"
        '
        'Bar4
        '
        Me.Bar4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar4.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.Bar4.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnGrabar, Me.ButtonItem17})
        Me.Bar4.Location = New System.Drawing.Point(0, 405)
        Me.Bar4.Name = "Bar4"
        Me.Bar4.Size = New System.Drawing.Size(748, 25)
        Me.Bar4.Stretch = True
        Me.Bar4.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Bar4.TabIndex = 30
        Me.Bar4.TabStop = False
        Me.Bar4.Text = "Bar4"
        '
        'btnGrabar
        '
        Me.btnGrabar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnGrabar.Image = Global.COBSER.My.Resources.Resources.disk
        Me.btnGrabar.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.btnGrabar.ImagePaddingHorizontal = 8
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Text = "Grabar Servicio"
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
        'gridPredios
        '
        Me.gridPredios.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.gridPredios.AllowUserToAddRows = False
        Me.gridPredios.AllowUserToDeleteRows = False
        Me.gridPredios.AllowUserToResizeRows = False
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
        Me.gridPredios.Location = New System.Drawing.Point(3, 29)
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
        Me.gridPredios.Size = New System.Drawing.Size(742, 370)
        Me.gridPredios.TabIndex = 2
        '
        'txtNroPredios
        '
        Me.txtNroPredios.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.txtNroPredios.Name = "txtNroPredios"
        Me.txtNroPredios.WatermarkColor = System.Drawing.SystemColors.GrayText
        '
        'ButtonItem18
        '
        Me.ButtonItem18.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem18.Image = Global.COBSER.My.Resources.Resources.lightning
        Me.ButtonItem18.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.ButtonItem18.ImagePaddingHorizontal = 8
        Me.ButtonItem18.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.ButtonItem18.Name = "ButtonItem18"
        Me.ButtonItem18.Text = "Nueva Consulta"
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
        'ButtonItem2
        '
        Me.ButtonItem2.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem2.Image = Global.COBSER.My.Resources.Resources.delete
        Me.ButtonItem2.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.ButtonItem2.ImagePaddingHorizontal = 8
        Me.ButtonItem2.Name = "ButtonItem2"
        Me.ButtonItem2.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem3})
        Me.ButtonItem2.Text = "Elimar Servicio"
        '
        'ButtonItem3
        '
        Me.ButtonItem3.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem3.EnableMarkup = False
        Me.ButtonItem3.Image = Global.COBSER.My.Resources.Resources.page_right
        Me.ButtonItem3.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.ButtonItem3.ImagePaddingHorizontal = 8
        Me.ButtonItem3.Name = "ButtonItem3"
        Me.ButtonItem3.Text = "Salir"
        '
        'ComboItem3
        '
        Me.ComboItem3.Text = "Medidor"
        '
        'frmAsignarMedidor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1005, 511)
        Me.Controls.Add(Me.ExpandablePanel2)
        Me.Controls.Add(Me.ExpandablePanel1)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.Bar1)
        Me.MinimizeBox = False
        Me.Name = "frmAsignarMedidor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmAsignarServicios"
        Me.ExpandablePanel1.ResumeLayout(False)
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupPanel1.PerformLayout()
        CType(Me.Bar5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Bar2.ResumeLayout(False)
        CType(Me.imgEstadoMsg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Bar1.ResumeLayout(False)
        Me.ExpandablePanel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        CType(Me.Bar6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridPredios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnCalcularDeuda As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnAplicarDeuda As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnCancelar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents pgb As DevComponents.DotNetBar.ProgressBarItem
    Friend WithEvents ControlContainerItem1 As DevComponents.DotNetBar.ControlContainerItem
    Friend WithEvents ExpandablePanel1 As DevComponents.DotNetBar.ExpandablePanel
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents cmbCalles As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Bar5 As DevComponents.DotNetBar.Bar
    Friend WithEvents btnFiltrar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents lblEstadoMsg As DevComponents.DotNetBar.LabelX
    Friend WithEvents imgEstadoMsg As System.Windows.Forms.PictureBox
    Friend WithEvents ControlContainerItem11 As DevComponents.DotNetBar.ControlContainerItem
    Friend WithEvents lblPredios As DevComponents.DotNetBar.LabelItem
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents cmbJunta As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents ExpandablePanel2 As DevComponents.DotNetBar.ExpandablePanel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents ButtonItem18 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem19 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Bar4 As DevComponents.DotNetBar.Bar
    Friend WithEvents btnGrabar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem17 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents cmbServicio As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents gridPredios As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents txtObserv As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Bar3 As DevComponents.DotNetBar.Bar
    Friend WithEvents ButtonItem2 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem3 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Bar6 As DevComponents.DotNetBar.Bar
    Friend WithEvents chkSelectAll As DevComponents.DotNetBar.CheckBoxItem
    Friend WithEvents txtNroPredios As DevComponents.DotNetBar.TextBoxItem
    Friend WithEvents lblnro As DevComponents.DotNetBar.LabelItem
    Friend WithEvents LabelX12 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtValorServicio As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents cmbCPoblado As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX25 As DevComponents.DotNetBar.LabelX
    Friend WithEvents chkUnicas As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents cmbTipoServicio As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents ComboItem1 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem2 As DevComponents.Editors.ComboItem
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents ComboItem3 As DevComponents.Editors.ComboItem
End Class
