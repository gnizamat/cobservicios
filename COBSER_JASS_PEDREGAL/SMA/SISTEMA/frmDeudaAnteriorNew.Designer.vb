<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDeudaAnteriorNew
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.txtUC = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.LabelX14 = New DevComponents.DotNetBar.LabelX
        Me.txtCalle = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.txtNumeroCasa = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX
        Me.LabelX12 = New DevComponents.DotNetBar.LabelX
        Me.GroupPanel3 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.dgDeudas = New DevComponents.DotNetBar.Controls.DataGridViewX
        Me.Bar2 = New DevComponents.DotNetBar.Bar
        Me.btnRemove = New DevComponents.DotNetBar.ButtonItem
        Me.txtMTotal = New DevComponents.DotNetBar.TextBoxItem
        Me.txtTotal = New DevComponents.DotNetBar.TextBoxItem
        Me.TxtSumaTotal = New DevComponents.DotNetBar.TextBoxItem
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.txtInteres = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.btnEliminar = New DevComponents.DotNetBar.ButtonX
        Me.txtMonto = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.LabelX19 = New DevComponents.DotNetBar.LabelX
        Me.LabelX18 = New DevComponents.DotNetBar.LabelX
        Me.txtVolumen = New DevComponents.Editors.DoubleInput
        Me.LabelX17 = New DevComponents.DotNetBar.LabelX
        Me.LabelX16 = New DevComponents.DotNetBar.LabelX
        Me.LabelX15 = New DevComponents.DotNetBar.LabelX
        Me.txtTotalSuma = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.LabelX9 = New DevComponents.DotNetBar.LabelX
        Me.txtFecha = New DevComponents.Editors.DateTimeAdv.DateTimeInput
        Me.cmbMes = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.ComboItem1 = New DevComponents.Editors.ComboItem
        Me.ComboItem2 = New DevComponents.Editors.ComboItem
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX
        Me.lblUnidad = New DevComponents.DotNetBar.LabelX
        Me.txtValorSubTarifa = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.LabelX13 = New DevComponents.DotNetBar.LabelX
        Me.cmbSubTipoTarifa = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.btnAdd = New DevComponents.DotNetBar.ButtonX
        Me.LabelX8 = New DevComponents.DotNetBar.LabelX
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX
        Me.txtDescripcion = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX
        Me.cmbAnio = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX
        Me.txtTipoTarifa = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX
        Me.txtPredio = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX
        Me.txtUsuario = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.Bar1 = New DevComponents.DotNetBar.Bar
        Me.lblEstado = New DevComponents.DotNetBar.LabelItem
        Me.btndelete = New DevComponents.DotNetBar.ButtonItem
        Me.btnSave = New DevComponents.DotNetBar.ButtonItem
        Me.btnCancel = New DevComponents.DotNetBar.ButtonItem
        Me.Bar3 = New DevComponents.DotNetBar.Bar
        Me.LabelX10 = New DevComponents.DotNetBar.LabelX
        Me.cmbJunta = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.ControlContainerItem1 = New DevComponents.DotNetBar.ControlContainerItem
        Me.ControlContainerItem2 = New DevComponents.DotNetBar.ControlContainerItem
        Me.ControlContainerItem3 = New DevComponents.DotNetBar.ControlContainerItem
        Me.ControlContainerItem4 = New DevComponents.DotNetBar.ControlContainerItem
        Me.colAnio = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Mes = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colIdSubTipoTarifa = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colMonto = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Volumen = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colTotal = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.fIneteres = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MontoT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FechaRegistro = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colDescripcion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colId = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colEstado = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.idPredio1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.idNroCampania = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Interes = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.estado = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupPanel1.SuspendLayout()
        Me.GroupPanel3.SuspendLayout()
        CType(Me.dgDeudas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel2.SuspendLayout()
        CType(Me.txtVolumen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Bar3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.txtUC)
        Me.GroupPanel1.Controls.Add(Me.LabelX14)
        Me.GroupPanel1.Controls.Add(Me.txtCalle)
        Me.GroupPanel1.Controls.Add(Me.txtNumeroCasa)
        Me.GroupPanel1.Controls.Add(Me.LabelX5)
        Me.GroupPanel1.Controls.Add(Me.LabelX12)
        Me.GroupPanel1.Controls.Add(Me.GroupPanel3)
        Me.GroupPanel1.Controls.Add(Me.GroupPanel2)
        Me.GroupPanel1.Controls.Add(Me.LabelX6)
        Me.GroupPanel1.Controls.Add(Me.txtPredio)
        Me.GroupPanel1.Controls.Add(Me.LabelX3)
        Me.GroupPanel1.Controls.Add(Me.txtUsuario)
        Me.GroupPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupPanel1.Location = New System.Drawing.Point(0, 25)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(816, 469)
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
        Me.GroupPanel1.TabIndex = 10
        Me.GroupPanel1.Text = "Datos Principales"
        '
        'txtUC
        '
        Me.txtUC.BackColor = System.Drawing.SystemColors.Control
        '
        '
        '
        Me.txtUC.Border.Class = "TextBoxBorder"
        Me.txtUC.Enabled = False
        Me.txtUC.Location = New System.Drawing.Point(658, 63)
        Me.txtUC.Name = "txtUC"
        Me.txtUC.ReadOnly = True
        Me.txtUC.Size = New System.Drawing.Size(94, 20)
        Me.txtUC.TabIndex = 26
        '
        'LabelX14
        '
        Me.LabelX14.AutoSize = True
        Me.LabelX14.BackColor = System.Drawing.Color.Transparent
        Me.LabelX14.Location = New System.Drawing.Point(588, 66)
        Me.LabelX14.Name = "LabelX14"
        Me.LabelX14.Size = New System.Drawing.Size(64, 15)
        Me.LabelX14.TabIndex = 27
        Me.LabelX14.Text = "U. Catastral:"
        '
        'txtCalle
        '
        Me.txtCalle.BackColor = System.Drawing.SystemColors.Control
        '
        '
        '
        Me.txtCalle.Border.Class = "TextBoxBorder"
        Me.txtCalle.Enabled = False
        Me.txtCalle.Location = New System.Drawing.Point(135, 63)
        Me.txtCalle.Name = "txtCalle"
        Me.txtCalle.ReadOnly = True
        Me.txtCalle.Size = New System.Drawing.Size(271, 20)
        Me.txtCalle.TabIndex = 23
        '
        'txtNumeroCasa
        '
        Me.txtNumeroCasa.BackColor = System.Drawing.SystemColors.Control
        '
        '
        '
        Me.txtNumeroCasa.Border.Class = "TextBoxBorder"
        Me.txtNumeroCasa.Enabled = False
        Me.txtNumeroCasa.Location = New System.Drawing.Point(484, 63)
        Me.txtNumeroCasa.Name = "txtNumeroCasa"
        Me.txtNumeroCasa.ReadOnly = True
        Me.txtNumeroCasa.Size = New System.Drawing.Size(85, 20)
        Me.txtNumeroCasa.TabIndex = 22
        '
        'LabelX5
        '
        Me.LabelX5.AutoSize = True
        Me.LabelX5.BackColor = System.Drawing.Color.Transparent
        Me.LabelX5.Location = New System.Drawing.Point(8, 68)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(31, 15)
        Me.LabelX5.TabIndex = 25
        Me.LabelX5.Text = "Calle:"
        '
        'LabelX12
        '
        Me.LabelX12.AutoSize = True
        Me.LabelX12.BackColor = System.Drawing.Color.Transparent
        Me.LabelX12.Location = New System.Drawing.Point(427, 66)
        Me.LabelX12.Name = "LabelX12"
        Me.LabelX12.Size = New System.Drawing.Size(46, 15)
        Me.LabelX12.TabIndex = 24
        Me.LabelX12.Text = "N° Casa:"
        '
        'GroupPanel3
        '
        Me.GroupPanel3.BackColor = System.Drawing.Color.Transparent
        Me.GroupPanel3.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel3.Controls.Add(Me.dgDeudas)
        Me.GroupPanel3.Controls.Add(Me.Bar2)
        Me.GroupPanel3.Location = New System.Drawing.Point(9, 239)
        Me.GroupPanel3.Name = "GroupPanel3"
        Me.GroupPanel3.Size = New System.Drawing.Size(792, 209)
        '
        '
        '
        Me.GroupPanel3.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel3.Style.BackColorGradientAngle = 90
        Me.GroupPanel3.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel3.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel3.Style.BorderBottomWidth = 1
        Me.GroupPanel3.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel3.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel3.Style.BorderLeftWidth = 1
        Me.GroupPanel3.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel3.Style.BorderRightWidth = 1
        Me.GroupPanel3.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel3.Style.BorderTopWidth = 1
        Me.GroupPanel3.Style.CornerDiameter = 4
        Me.GroupPanel3.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel3.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel3.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel3.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        Me.GroupPanel3.TabIndex = 21
        Me.GroupPanel3.Text = "Listado de Deudas"
        '
        'dgDeudas
        '
        Me.dgDeudas.AllowUserToAddRows = False
        Me.dgDeudas.AllowUserToDeleteRows = False
        Me.dgDeudas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgDeudas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgDeudas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colAnio, Me.Mes, Me.colIdSubTipoTarifa, Me.colMonto, Me.Volumen, Me.colTotal, Me.fIneteres, Me.MontoT, Me.FechaRegistro, Me.colDescripcion, Me.colId, Me.colEstado, Me.idPredio1, Me.idNroCampania, Me.Interes, Me.estado})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgDeudas.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgDeudas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgDeudas.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgDeudas.Location = New System.Drawing.Point(0, 0)
        Me.dgDeudas.MultiSelect = False
        Me.dgDeudas.Name = "dgDeudas"
        Me.dgDeudas.ReadOnly = True
        Me.dgDeudas.RowHeadersVisible = False
        Me.dgDeudas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgDeudas.Size = New System.Drawing.Size(786, 163)
        Me.dgDeudas.TabIndex = 19
        '
        'Bar2
        '
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnRemove, Me.txtMTotal, Me.txtTotal, Me.TxtSumaTotal})
        Me.Bar2.Location = New System.Drawing.Point(0, 163)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(786, 25)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Bar2.TabIndex = 0
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'btnRemove
        '
        Me.btnRemove.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnRemove.Image = Global.COBSER.My.Resources.Resources.delete
        Me.btnRemove.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.btnRemove.ImagePaddingHorizontal = 8
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Text = "Quitar"
        '
        'txtMTotal
        '
        Me.txtMTotal.AlwaysShowCaption = True
        Me.txtMTotal.Caption = "Total Saldo"
        Me.txtMTotal.Enabled = False
        Me.txtMTotal.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.txtMTotal.Name = "txtMTotal"
        Me.txtMTotal.WatermarkColor = System.Drawing.SystemColors.GrayText
        '
        'txtTotal
        '
        Me.txtTotal.AlwaysShowCaption = True
        Me.txtTotal.Caption = "Total Mora"
        Me.txtTotal.Enabled = False
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.WatermarkColor = System.Drawing.SystemColors.GrayText
        '
        'TxtSumaTotal
        '
        Me.TxtSumaTotal.AlwaysShowCaption = True
        Me.TxtSumaTotal.Caption = "Monto Total"
        Me.TxtSumaTotal.Enabled = False
        Me.TxtSumaTotal.Name = "TxtSumaTotal"
        Me.TxtSumaTotal.WatermarkColor = System.Drawing.SystemColors.GrayText
        '
        'GroupPanel2
        '
        Me.GroupPanel2.BackColor = System.Drawing.Color.Transparent
        Me.GroupPanel2.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.txtInteres)
        Me.GroupPanel2.Controls.Add(Me.btnEliminar)
        Me.GroupPanel2.Controls.Add(Me.txtMonto)
        Me.GroupPanel2.Controls.Add(Me.LabelX19)
        Me.GroupPanel2.Controls.Add(Me.LabelX18)
        Me.GroupPanel2.Controls.Add(Me.txtVolumen)
        Me.GroupPanel2.Controls.Add(Me.LabelX17)
        Me.GroupPanel2.Controls.Add(Me.LabelX16)
        Me.GroupPanel2.Controls.Add(Me.LabelX15)
        Me.GroupPanel2.Controls.Add(Me.txtTotalSuma)
        Me.GroupPanel2.Controls.Add(Me.LabelX9)
        Me.GroupPanel2.Controls.Add(Me.txtFecha)
        Me.GroupPanel2.Controls.Add(Me.cmbMes)
        Me.GroupPanel2.Controls.Add(Me.LabelX1)
        Me.GroupPanel2.Controls.Add(Me.lblUnidad)
        Me.GroupPanel2.Controls.Add(Me.txtValorSubTarifa)
        Me.GroupPanel2.Controls.Add(Me.LabelX13)
        Me.GroupPanel2.Controls.Add(Me.cmbSubTipoTarifa)
        Me.GroupPanel2.Controls.Add(Me.btnAdd)
        Me.GroupPanel2.Controls.Add(Me.LabelX8)
        Me.GroupPanel2.Controls.Add(Me.LabelX7)
        Me.GroupPanel2.Controls.Add(Me.txtDescripcion)
        Me.GroupPanel2.Controls.Add(Me.LabelX2)
        Me.GroupPanel2.Controls.Add(Me.cmbAnio)
        Me.GroupPanel2.Controls.Add(Me.LabelX4)
        Me.GroupPanel2.Controls.Add(Me.txtTipoTarifa)
        Me.GroupPanel2.Location = New System.Drawing.Point(11, 89)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(790, 144)
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
        Me.GroupPanel2.TabIndex = 20
        Me.GroupPanel2.Text = "Nueva Deuda"
        '
        'txtInteres
        '
        Me.txtInteres.BackColor = System.Drawing.SystemColors.ButtonHighlight
        '
        '
        '
        Me.txtInteres.Border.Class = "TextBoxBorder"
        Me.txtInteres.Location = New System.Drawing.Point(422, 58)
        Me.txtInteres.Name = "txtInteres"
        Me.txtInteres.Size = New System.Drawing.Size(96, 20)
        Me.txtInteres.TabIndex = 61
        '
        'btnEliminar
        '
        Me.btnEliminar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnEliminar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnEliminar.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnEliminar.Image = Global.COBSER.My.Resources.Resources.cross
        Me.btnEliminar.Location = New System.Drawing.Point(509, 87)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(105, 27)
        Me.btnEliminar.TabIndex = 60
        Me.btnEliminar.Text = "Eliminar Deuda"
        '
        'txtMonto
        '
        Me.txtMonto.BackColor = System.Drawing.SystemColors.ButtonHighlight
        '
        '
        '
        Me.txtMonto.Border.Class = "TextBoxBorder"
        Me.txtMonto.Location = New System.Drawing.Point(108, 58)
        Me.txtMonto.Name = "txtMonto"
        Me.txtMonto.Size = New System.Drawing.Size(96, 20)
        Me.txtMonto.TabIndex = 59
        '
        'LabelX19
        '
        Me.LabelX19.BackColor = System.Drawing.Color.Transparent
        Me.LabelX19.Location = New System.Drawing.Point(594, 33)
        Me.LabelX19.Name = "LabelX19"
        Me.LabelX19.Size = New System.Drawing.Size(20, 18)
        Me.LabelX19.TabIndex = 58
        Me.LabelX19.Text = "S/."
        '
        'LabelX18
        '
        Me.LabelX18.AutoSize = True
        Me.LabelX18.BackColor = System.Drawing.Color.Transparent
        Me.LabelX18.Location = New System.Drawing.Point(386, 5)
        Me.LabelX18.Name = "LabelX18"
        Me.LabelX18.Size = New System.Drawing.Size(26, 15)
        Me.LabelX18.TabIndex = 57
        Me.LabelX18.Text = "Mes:"
        '
        'txtVolumen
        '
        '
        '
        '
        Me.txtVolumen.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtVolumen.Increment = 1
        Me.txtVolumen.Location = New System.Drawing.Point(266, 58)
        Me.txtVolumen.MinValue = 0
        Me.txtVolumen.Name = "txtVolumen"
        Me.txtVolumen.ShowUpDown = True
        Me.txtVolumen.Size = New System.Drawing.Size(105, 20)
        Me.txtVolumen.TabIndex = 56
        '
        'LabelX17
        '
        Me.LabelX17.AutoSize = True
        Me.LabelX17.BackColor = System.Drawing.Color.Transparent
        Me.LabelX17.Location = New System.Drawing.Point(210, 59)
        Me.LabelX17.Name = "LabelX17"
        Me.LabelX17.Size = New System.Drawing.Size(49, 15)
        Me.LabelX17.TabIndex = 55
        Me.LabelX17.Text = "Volumen:"
        '
        'LabelX16
        '
        Me.LabelX16.AutoSize = True
        Me.LabelX16.BackColor = System.Drawing.Color.Transparent
        Me.LabelX16.Location = New System.Drawing.Point(525, 34)
        Me.LabelX16.Name = "LabelX16"
        Me.LabelX16.Size = New System.Drawing.Size(62, 15)
        Me.LabelX16.TabIndex = 54
        Me.LabelX16.Text = "Valor Tarifa:"
        '
        'LabelX15
        '
        Me.LabelX15.AutoSize = True
        Me.LabelX15.BackColor = System.Drawing.Color.Transparent
        Me.LabelX15.Location = New System.Drawing.Point(525, 63)
        Me.LabelX15.Name = "LabelX15"
        Me.LabelX15.Size = New System.Drawing.Size(30, 15)
        Me.LabelX15.TabIndex = 53
        Me.LabelX15.Text = "Total:"
        '
        'txtTotalSuma
        '
        '
        '
        '
        Me.txtTotalSuma.Border.Class = "TextBoxBorder"
        Me.txtTotalSuma.Enabled = False
        Me.txtTotalSuma.Location = New System.Drawing.Point(594, 56)
        Me.txtTotalSuma.Name = "txtTotalSuma"
        Me.txtTotalSuma.ReadOnly = True
        Me.txtTotalSuma.Size = New System.Drawing.Size(127, 20)
        Me.txtTotalSuma.TabIndex = 52
        '
        'LabelX9
        '
        Me.LabelX9.AutoSize = True
        Me.LabelX9.BackColor = System.Drawing.Color.Transparent
        Me.LabelX9.Location = New System.Drawing.Point(10, 9)
        Me.LabelX9.Name = "LabelX9"
        Me.LabelX9.Size = New System.Drawing.Size(59, 15)
        Me.LabelX9.TabIndex = 51
        Me.LabelX9.Text = "F. Registro:"
        '
        'txtFecha
        '
        '
        '
        '
        Me.txtFecha.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtFecha.ButtonDropDown.Visible = True
        Me.txtFecha.Location = New System.Drawing.Point(108, 4)
        '
        '
        '
        Me.txtFecha.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        Me.txtFecha.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.txtFecha.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.txtFecha.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.txtFecha.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.txtFecha.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.txtFecha.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.txtFecha.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.txtFecha.MonthCalendar.DisplayMonth = New Date(2010, 5, 1, 0, 0, 0, 0)
        Me.txtFecha.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.txtFecha.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.txtFecha.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.txtFecha.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.txtFecha.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.txtFecha.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.txtFecha.MonthCalendar.TodayButtonVisible = True
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.Size = New System.Drawing.Size(100, 20)
        Me.txtFecha.TabIndex = 50
        '
        'cmbMes
        '
        Me.cmbMes.DisplayMember = "Text"
        Me.cmbMes.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMes.FormattingEnabled = True
        Me.cmbMes.ItemHeight = 14
        Me.cmbMes.Items.AddRange(New Object() {Me.ComboItem1, Me.ComboItem2})
        Me.cmbMes.Location = New System.Drawing.Point(420, 4)
        Me.cmbMes.Name = "cmbMes"
        Me.cmbMes.Size = New System.Drawing.Size(99, 20)
        Me.cmbMes.TabIndex = 49
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
        Me.LabelX1.Location = New System.Drawing.Point(373, 63)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(47, 15)
        Me.LabelX1.TabIndex = 45
        Me.LabelX1.Text = "Mora S/.:"
        '
        'lblUnidad
        '
        Me.lblUnidad.BackColor = System.Drawing.Color.Transparent
        Me.lblUnidad.Location = New System.Drawing.Point(590, 8)
        Me.lblUnidad.Name = "lblUnidad"
        Me.lblUnidad.Size = New System.Drawing.Size(34, 18)
        Me.lblUnidad.TabIndex = 42
        Me.lblUnidad.Text = "S/./m³"
        '
        'txtValorSubTarifa
        '
        '
        '
        '
        Me.txtValorSubTarifa.Border.Class = "TextBoxBorder"
        Me.txtValorSubTarifa.Enabled = False
        Me.txtValorSubTarifa.Location = New System.Drawing.Point(625, 30)
        Me.txtValorSubTarifa.Name = "txtValorSubTarifa"
        Me.txtValorSubTarifa.ReadOnly = True
        Me.txtValorSubTarifa.Size = New System.Drawing.Size(96, 20)
        Me.txtValorSubTarifa.TabIndex = 43
        '
        'LabelX13
        '
        Me.LabelX13.AutoSize = True
        Me.LabelX13.BackColor = System.Drawing.Color.Transparent
        Me.LabelX13.Location = New System.Drawing.Point(10, 37)
        Me.LabelX13.Name = "LabelX13"
        Me.LabelX13.Size = New System.Drawing.Size(73, 15)
        Me.LabelX13.TabIndex = 41
        Me.LabelX13.Text = "Tipo de Tarifa:"
        '
        'cmbSubTipoTarifa
        '
        Me.cmbSubTipoTarifa.DisplayMember = "Text"
        Me.cmbSubTipoTarifa.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbSubTipoTarifa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSubTipoTarifa.FormattingEnabled = True
        Me.cmbSubTipoTarifa.ItemHeight = 14
        Me.cmbSubTipoTarifa.Location = New System.Drawing.Point(108, 32)
        Me.cmbSubTipoTarifa.Name = "cmbSubTipoTarifa"
        Me.cmbSubTipoTarifa.Size = New System.Drawing.Size(410, 20)
        Me.cmbSubTipoTarifa.TabIndex = 40
        '
        'btnAdd
        '
        Me.btnAdd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAdd.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnAdd.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnAdd.Image = Global.COBSER.My.Resources.Resources.add
        Me.btnAdd.Location = New System.Drawing.Point(624, 87)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(114, 27)
        Me.btnAdd.TabIndex = 20
        Me.btnAdd.Text = "Agregar Deuda"
        '
        'LabelX8
        '
        Me.LabelX8.AutoSize = True
        Me.LabelX8.BackColor = System.Drawing.Color.Transparent
        Me.LabelX8.Location = New System.Drawing.Point(10, 87)
        Me.LabelX8.Name = "LabelX8"
        Me.LabelX8.Size = New System.Drawing.Size(63, 15)
        Me.LabelX8.TabIndex = 19
        Me.LabelX8.Text = "Descripción:"
        '
        'LabelX7
        '
        Me.LabelX7.AutoSize = True
        Me.LabelX7.BackColor = System.Drawing.Color.Transparent
        Me.LabelX7.Location = New System.Drawing.Point(11, 61)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(52, 15)
        Me.LabelX7.TabIndex = 18
        Me.LabelX7.Text = "Monto S/.:"
        '
        'txtDescripcion
        '
        '
        '
        '
        Me.txtDescripcion.Border.Class = "TextBoxBorder"
        Me.txtDescripcion.Location = New System.Drawing.Point(108, 86)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(312, 20)
        Me.txtDescripcion.TabIndex = 17
        '
        'LabelX2
        '
        Me.LabelX2.AutoSize = True
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        Me.LabelX2.Location = New System.Drawing.Point(230, 5)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(56, 15)
        Me.LabelX2.TabIndex = 5
        Me.LabelX2.Text = "Año Tarifa:"
        '
        'cmbAnio
        '
        Me.cmbAnio.DisplayMember = "Text"
        Me.cmbAnio.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbAnio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAnio.FormattingEnabled = True
        Me.cmbAnio.ItemHeight = 14
        Me.cmbAnio.Location = New System.Drawing.Point(290, 4)
        Me.cmbAnio.Name = "cmbAnio"
        Me.cmbAnio.Size = New System.Drawing.Size(81, 20)
        Me.cmbAnio.TabIndex = 4
        '
        'LabelX4
        '
        Me.LabelX4.AutoSize = True
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        Me.LabelX4.Location = New System.Drawing.Point(525, 9)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(58, 15)
        Me.LabelX4.TabIndex = 9
        Me.LabelX4.Text = "Tipo Tarifa:"
        '
        'txtTipoTarifa
        '
        '
        '
        '
        Me.txtTipoTarifa.Border.Class = "TextBoxBorder"
        Me.txtTipoTarifa.Location = New System.Drawing.Point(626, 4)
        Me.txtTipoTarifa.Name = "txtTipoTarifa"
        Me.txtTipoTarifa.ReadOnly = True
        Me.txtTipoTarifa.Size = New System.Drawing.Size(95, 20)
        Me.txtTipoTarifa.TabIndex = 8
        '
        'LabelX6
        '
        Me.LabelX6.AutoSize = True
        Me.LabelX6.BackColor = System.Drawing.Color.Transparent
        Me.LabelX6.Location = New System.Drawing.Point(8, 42)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(37, 15)
        Me.LabelX6.TabIndex = 15
        Me.LabelX6.Text = "Predio:"
        '
        'txtPredio
        '
        '
        '
        '
        Me.txtPredio.Border.Class = "TextBoxBorder"
        Me.txtPredio.Location = New System.Drawing.Point(135, 37)
        Me.txtPredio.Name = "txtPredio"
        Me.txtPredio.ReadOnly = True
        Me.txtPredio.Size = New System.Drawing.Size(271, 20)
        Me.txtPredio.TabIndex = 14
        '
        'LabelX3
        '
        Me.LabelX3.AutoSize = True
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        Me.LabelX3.Location = New System.Drawing.Point(6, 16)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(44, 15)
        Me.LabelX3.TabIndex = 13
        Me.LabelX3.Text = "Usuario:"
        '
        'txtUsuario
        '
        '
        '
        '
        Me.txtUsuario.Border.Class = "TextBoxBorder"
        Me.txtUsuario.Location = New System.Drawing.Point(135, 11)
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.ReadOnly = True
        Me.txtUsuario.Size = New System.Drawing.Size(617, 20)
        Me.txtUsuario.TabIndex = 12
        '
        'Bar1
        '
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.lblEstado, Me.btndelete, Me.btnSave, Me.btnCancel})
        Me.Bar1.Location = New System.Drawing.Point(0, 494)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(816, 25)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Bar1.TabIndex = 9
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'lblEstado
        '
        Me.lblEstado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblEstado.Image = Global.COBSER.My.Resources.Resources.important
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Text = "ESTADO"
        '
        'btndelete
        '
        Me.btndelete.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btndelete.Image = Global.COBSER.My.Resources.Resources.cross
        Me.btndelete.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.btndelete.ImagePaddingHorizontal = 8
        Me.btndelete.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.btndelete.Name = "btndelete"
        Me.btndelete.Text = "Eliminar"
        '
        'btnSave
        '
        Me.btnSave.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnSave.Image = Global.COBSER.My.Resources.Resources.disk
        Me.btnSave.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.btnSave.ImagePaddingHorizontal = 8
        Me.btnSave.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Text = "Grabar"
        '
        'btnCancel
        '
        Me.btnCancel.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnCancel.Image = Global.COBSER.My.Resources.Resources.door
        Me.btnCancel.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.btnCancel.ImagePaddingHorizontal = 8
        Me.btnCancel.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Text = "Cancelar"
        '
        'Bar3
        '
        Me.Bar3.Controls.Add(Me.LabelX10)
        Me.Bar3.Controls.Add(Me.cmbJunta)
        Me.Bar3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar3.Location = New System.Drawing.Point(0, 0)
        Me.Bar3.Name = "Bar3"
        Me.Bar3.Size = New System.Drawing.Size(816, 25)
        Me.Bar3.Stretch = True
        Me.Bar3.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Bar3.TabIndex = 11
        Me.Bar3.TabStop = False
        Me.Bar3.Text = "Bar3"
        '
        'LabelX10
        '
        Me.LabelX10.AutoSize = True
        Me.LabelX10.BackColor = System.Drawing.Color.Transparent
        Me.LabelX10.Location = New System.Drawing.Point(15, 5)
        Me.LabelX10.Name = "LabelX10"
        Me.LabelX10.Size = New System.Drawing.Size(30, 18)
        Me.LabelX10.TabIndex = 152
        Me.LabelX10.Text = "JASS:"
        '
        'cmbJunta
        '
        Me.cmbJunta.DisplayMember = "Text"
        Me.cmbJunta.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbJunta.DropDownHeight = 400
        Me.cmbJunta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbJunta.FormattingEnabled = True
        Me.cmbJunta.IntegralHeight = False
        Me.cmbJunta.ItemHeight = 17
        Me.cmbJunta.Location = New System.Drawing.Point(80, 1)
        Me.cmbJunta.Name = "cmbJunta"
        Me.cmbJunta.Size = New System.Drawing.Size(253, 23)
        Me.cmbJunta.TabIndex = 151
        '
        'ControlContainerItem1
        '
        Me.ControlContainerItem1.AllowItemResize = False
        Me.ControlContainerItem1.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
        Me.ControlContainerItem1.Name = "ControlContainerItem1"
        '
        'ControlContainerItem2
        '
        Me.ControlContainerItem2.AllowItemResize = False
        Me.ControlContainerItem2.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
        Me.ControlContainerItem2.Name = "ControlContainerItem2"
        '
        'ControlContainerItem3
        '
        Me.ControlContainerItem3.AllowItemResize = False
        Me.ControlContainerItem3.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
        Me.ControlContainerItem3.Name = "ControlContainerItem3"
        '
        'ControlContainerItem4
        '
        Me.ControlContainerItem4.AllowItemResize = False
        Me.ControlContainerItem4.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
        Me.ControlContainerItem4.Name = "ControlContainerItem4"
        '
        'colAnio
        '
        Me.colAnio.HeaderText = "Año"
        Me.colAnio.Name = "colAnio"
        Me.colAnio.ReadOnly = True
        '
        'Mes
        '
        Me.Mes.HeaderText = "Mes"
        Me.Mes.Name = "Mes"
        Me.Mes.ReadOnly = True
        '
        'colIdSubTipoTarifa
        '
        Me.colIdSubTipoTarifa.HeaderText = "TipoTarifa"
        Me.colIdSubTipoTarifa.Name = "colIdSubTipoTarifa"
        Me.colIdSubTipoTarifa.ReadOnly = True
        '
        'colMonto
        '
        Me.colMonto.HeaderText = "Monto"
        Me.colMonto.Name = "colMonto"
        Me.colMonto.ReadOnly = True
        '
        'Volumen
        '
        Me.Volumen.HeaderText = "Volumen"
        Me.Volumen.Name = "Volumen"
        Me.Volumen.ReadOnly = True
        '
        'colTotal
        '
        Me.colTotal.HeaderText = "Saldo"
        Me.colTotal.Name = "colTotal"
        Me.colTotal.ReadOnly = True
        '
        'fIneteres
        '
        Me.fIneteres.HeaderText = "Mora"
        Me.fIneteres.Name = "fIneteres"
        Me.fIneteres.ReadOnly = True
        '
        'MontoT
        '
        Me.MontoT.HeaderText = "MontoTotal"
        Me.MontoT.Name = "MontoT"
        Me.MontoT.ReadOnly = True
        '
        'FechaRegistro
        '
        Me.FechaRegistro.HeaderText = "F. Registro"
        Me.FechaRegistro.Name = "FechaRegistro"
        Me.FechaRegistro.ReadOnly = True
        '
        'colDescripcion
        '
        Me.colDescripcion.HeaderText = "SubTipoTarifa"
        Me.colDescripcion.Name = "colDescripcion"
        Me.colDescripcion.ReadOnly = True
        '
        'colId
        '
        Me.colId.HeaderText = "idMes"
        Me.colId.Name = "colId"
        Me.colId.ReadOnly = True
        '
        'colEstado
        '
        Me.colEstado.HeaderText = "TipoDeuda"
        Me.colEstado.Name = "colEstado"
        Me.colEstado.ReadOnly = True
        Me.colEstado.Visible = False
        '
        'idPredio1
        '
        Me.idPredio1.HeaderText = "idpredio"
        Me.idPredio1.Name = "idPredio1"
        Me.idPredio1.ReadOnly = True
        Me.idPredio1.Visible = False
        '
        'idNroCampania
        '
        Me.idNroCampania.HeaderText = "idDetalleDeuda"
        Me.idNroCampania.Name = "idNroCampania"
        Me.idNroCampania.ReadOnly = True
        Me.idNroCampania.Visible = False
        '
        'Interes
        '
        Me.Interes.HeaderText = "vIdJas"
        Me.Interes.Name = "Interes"
        Me.Interes.ReadOnly = True
        Me.Interes.Visible = False
        '
        'estado
        '
        Me.estado.HeaderText = "Estado"
        Me.estado.Name = "estado"
        Me.estado.ReadOnly = True
        '
        'frmDeudaAnteriorNew
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(816, 519)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.Bar3)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDeudaAnteriorNew"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Registro de DeudasAnteriores"
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupPanel1.PerformLayout()
        Me.GroupPanel3.ResumeLayout(False)
        CType(Me.dgDeudas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel2.ResumeLayout(False)
        Me.GroupPanel2.PerformLayout()
        CType(Me.txtVolumen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Bar3.ResumeLayout(False)
        Me.Bar3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents txtUC As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX14 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtCalle As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtNumeroCasa As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX12 As DevComponents.DotNetBar.LabelX
    Friend WithEvents GroupPanel3 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents dgDeudas As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents btnRemove As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents txtMTotal As DevComponents.DotNetBar.TextBoxItem
    Friend WithEvents txtTotal As DevComponents.DotNetBar.TextBoxItem
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents txtVolumen As DevComponents.Editors.DoubleInput
    Friend WithEvents LabelX17 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX16 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX15 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtTotalSuma As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX9 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtFecha As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents cmbMes As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents ComboItem1 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem2 As DevComponents.Editors.ComboItem
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblUnidad As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtValorSubTarifa As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX13 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cmbSubTipoTarifa As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents btnAdd As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelX8 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtDescripcion As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cmbAnio As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtTipoTarifa As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtPredio As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtUsuario As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents lblEstado As DevComponents.DotNetBar.LabelItem
    Friend WithEvents btnSave As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnCancel As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Bar3 As DevComponents.DotNetBar.Bar
    Friend WithEvents ControlContainerItem1 As DevComponents.DotNetBar.ControlContainerItem
    Friend WithEvents ControlContainerItem2 As DevComponents.DotNetBar.ControlContainerItem
    Friend WithEvents ControlContainerItem3 As DevComponents.DotNetBar.ControlContainerItem
    Friend WithEvents ControlContainerItem4 As DevComponents.DotNetBar.ControlContainerItem
    Friend WithEvents LabelX18 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX19 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtMonto As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX10 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cmbJunta As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents btnEliminar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btndelete As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents txtInteres As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TxtSumaTotal As DevComponents.DotNetBar.TextBoxItem
    Friend WithEvents colAnio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Mes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colIdSubTipoTarifa As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colMonto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Volumen As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTotal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents fIneteres As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MontoT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaRegistro As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDescripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colEstado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents idPredio1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents idNroCampania As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Interes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents estado As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
