<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCortesServicio
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
        Me.Bar6 = New DevComponents.DotNetBar.Bar
        Me.ButtonItem2 = New DevComponents.DotNetBar.ButtonItem
        Me.ButtonItem1 = New DevComponents.DotNetBar.ButtonItem
        Me.btnDelete = New DevComponents.DotNetBar.ButtonItem
        Me.btnSave = New DevComponents.DotNetBar.ButtonItem
        Me.ExpandablePanel2 = New DevComponents.DotNetBar.ExpandablePanel
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.cmbEstado = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.ComboItem7 = New DevComponents.Editors.ComboItem
        Me.ComboItem8 = New DevComponents.Editors.ComboItem
        Me.ComboItem9 = New DevComponents.Editors.ComboItem
        Me.LabelX10 = New DevComponents.DotNetBar.LabelX
        Me.txtValorServicio = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.cmbCalle = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.ComboItem4 = New DevComponents.Editors.ComboItem
        Me.ComboItem5 = New DevComponents.Editors.ComboItem
        Me.ComboItem6 = New DevComponents.Editors.ComboItem
        Me.cmbServicios = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX
        Me.cmbMotivo = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.ComboItem1 = New DevComponents.Editors.ComboItem
        Me.ComboItem2 = New DevComponents.Editors.ComboItem
        Me.ComboItem3 = New DevComponents.Editors.ComboItem
        Me.txtLote = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX
        Me.txtManzana = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX
        Me.LabelX14 = New DevComponents.DotNetBar.LabelX
        Me.txtNombre = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.txtNCasa = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.LabelX13 = New DevComponents.DotNetBar.LabelX
        Me.txtPredio = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.txtEstructuta = New DevComponents.DotNetBar.LabelX
        Me.txtFechaCorte = New DevComponents.Editors.DateTimeAdv.DateTimeInput
        Me.txtFechaRegistro = New DevComponents.Editors.DateTimeAdv.DateTimeInput
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX
        Me.txtDNI = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.LabelX8 = New DevComponents.DotNetBar.LabelX
        Me.LabelX12 = New DevComponents.DotNetBar.LabelX
        Me.txtDescripcion = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.LabelX21 = New DevComponents.DotNetBar.LabelX
        Me.LabelX20 = New DevComponents.DotNetBar.LabelX
        Me.LabelX11 = New DevComponents.DotNetBar.LabelX
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX
        Me.gridPredioCorte = New DevComponents.DotNetBar.Controls.DataGridViewX
        CType(Me.Bar6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExpandablePanel2.SuspendLayout()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.txtFechaCorte, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaRegistro, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridPredioCorte, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bar6
        '
        Me.Bar6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar6.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem2, Me.ButtonItem1, Me.btnDelete, Me.btnSave})
        Me.Bar6.Location = New System.Drawing.Point(0, 518)
        Me.Bar6.Name = "Bar6"
        Me.Bar6.Size = New System.Drawing.Size(693, 25)
        Me.Bar6.Stretch = True
        Me.Bar6.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Bar6.TabIndex = 206
        Me.Bar6.TabStop = False
        Me.Bar6.Text = "Bar6"
        '
        'ButtonItem2
        '
        Me.ButtonItem2.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem2.Image = Global.COBSER.My.Resources.Resources.door
        Me.ButtonItem2.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.ButtonItem2.ImagePaddingHorizontal = 8
        Me.ButtonItem2.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.ButtonItem2.Name = "ButtonItem2"
        Me.ButtonItem2.Text = "Salir"
        '
        'ButtonItem1
        '
        Me.ButtonItem1.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem1.Image = Global.COBSER.My.Resources.Resources.accept
        Me.ButtonItem1.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.ButtonItem1.ImagePaddingHorizontal = 8
        Me.ButtonItem1.Name = "ButtonItem1"
        Me.ButtonItem1.Text = "Activar "
        '
        'btnDelete
        '
        Me.btnDelete.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnDelete.Image = Global.COBSER.My.Resources.Resources.delete
        Me.btnDelete.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.btnDelete.ImagePaddingHorizontal = 8
        Me.btnDelete.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Text = "Eliminar"
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
        'ExpandablePanel2
        '
        Me.ExpandablePanel2.CanvasColor = System.Drawing.SystemColors.Control
        Me.ExpandablePanel2.CollapseDirection = DevComponents.DotNetBar.eCollapseDirection.RightToLeft
        Me.ExpandablePanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.ExpandablePanel2.Controls.Add(Me.GroupPanel1)
        Me.ExpandablePanel2.Controls.Add(Me.gridPredioCorte)
        Me.ExpandablePanel2.ExpandButtonVisible = False
        Me.ExpandablePanel2.Location = New System.Drawing.Point(-1, -2)
        Me.ExpandablePanel2.Name = "ExpandablePanel2"
        Me.ExpandablePanel2.Size = New System.Drawing.Size(695, 514)
        Me.ExpandablePanel2.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.ExpandablePanel2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.ExpandablePanel2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.ExpandablePanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.ExpandablePanel2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.ExpandablePanel2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
        Me.ExpandablePanel2.Style.GradientAngle = 90
        Me.ExpandablePanel2.TabIndex = 205
        Me.ExpandablePanel2.TitleStyle.Alignment = System.Drawing.StringAlignment.Center
        Me.ExpandablePanel2.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.ExpandablePanel2.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.ExpandablePanel2.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner
        Me.ExpandablePanel2.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.ExpandablePanel2.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.ExpandablePanel2.TitleStyle.GradientAngle = 90
        Me.ExpandablePanel2.TitleText = "Registrar Corte Servicio"
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.cmbEstado)
        Me.GroupPanel1.Controls.Add(Me.LabelX10)
        Me.GroupPanel1.Controls.Add(Me.txtValorServicio)
        Me.GroupPanel1.Controls.Add(Me.cmbCalle)
        Me.GroupPanel1.Controls.Add(Me.cmbServicios)
        Me.GroupPanel1.Controls.Add(Me.LabelX4)
        Me.GroupPanel1.Controls.Add(Me.cmbMotivo)
        Me.GroupPanel1.Controls.Add(Me.txtLote)
        Me.GroupPanel1.Controls.Add(Me.LabelX3)
        Me.GroupPanel1.Controls.Add(Me.txtManzana)
        Me.GroupPanel1.Controls.Add(Me.LabelX1)
        Me.GroupPanel1.Controls.Add(Me.LabelX14)
        Me.GroupPanel1.Controls.Add(Me.txtNombre)
        Me.GroupPanel1.Controls.Add(Me.txtNCasa)
        Me.GroupPanel1.Controls.Add(Me.LabelX13)
        Me.GroupPanel1.Controls.Add(Me.txtPredio)
        Me.GroupPanel1.Controls.Add(Me.txtEstructuta)
        Me.GroupPanel1.Controls.Add(Me.txtFechaCorte)
        Me.GroupPanel1.Controls.Add(Me.txtFechaRegistro)
        Me.GroupPanel1.Controls.Add(Me.LabelX2)
        Me.GroupPanel1.Controls.Add(Me.txtDNI)
        Me.GroupPanel1.Controls.Add(Me.LabelX8)
        Me.GroupPanel1.Controls.Add(Me.LabelX12)
        Me.GroupPanel1.Controls.Add(Me.txtDescripcion)
        Me.GroupPanel1.Controls.Add(Me.LabelX21)
        Me.GroupPanel1.Controls.Add(Me.LabelX20)
        Me.GroupPanel1.Controls.Add(Me.LabelX11)
        Me.GroupPanel1.Controls.Add(Me.LabelX7)
        Me.GroupPanel1.Location = New System.Drawing.Point(14, 28)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(681, 239)
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
        Me.GroupPanel1.TabIndex = 202
        '
        'cmbEstado
        '
        Me.cmbEstado.DisplayMember = "Text"
        Me.cmbEstado.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstado.FormattingEnabled = True
        Me.cmbEstado.ItemHeight = 14
        Me.cmbEstado.Items.AddRange(New Object() {Me.ComboItem7, Me.ComboItem8, Me.ComboItem9})
        Me.cmbEstado.Location = New System.Drawing.Point(95, 197)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.Size = New System.Drawing.Size(123, 20)
        Me.cmbEstado.TabIndex = 245
        '
        'ComboItem7
        '
        Me.ComboItem7.Text = "Activos"
        '
        'ComboItem8
        '
        Me.ComboItem8.Text = "Inactivos"
        '
        'ComboItem9
        '
        Me.ComboItem9.Text = "Todos"
        '
        'LabelX10
        '
        Me.LabelX10.AutoSize = True
        Me.LabelX10.BackColor = System.Drawing.Color.Transparent
        Me.LabelX10.Location = New System.Drawing.Point(18, 202)
        Me.LabelX10.Name = "LabelX10"
        Me.LabelX10.Size = New System.Drawing.Size(40, 15)
        Me.LabelX10.TabIndex = 244
        Me.LabelX10.Text = "Estado:"
        '
        'txtValorServicio
        '
        '
        '
        '
        Me.txtValorServicio.Border.Class = "TextBoxBorder"
        Me.txtValorServicio.Enabled = False
        Me.txtValorServicio.Location = New System.Drawing.Point(606, 127)
        Me.txtValorServicio.Name = "txtValorServicio"
        Me.txtValorServicio.Size = New System.Drawing.Size(60, 20)
        Me.txtValorServicio.TabIndex = 243
        '
        'cmbCalle
        '
        Me.cmbCalle.DisplayMember = "Text"
        Me.cmbCalle.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbCalle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCalle.FormattingEnabled = True
        Me.cmbCalle.ItemHeight = 14
        Me.cmbCalle.Items.AddRange(New Object() {Me.ComboItem4, Me.ComboItem5, Me.ComboItem6})
        Me.cmbCalle.Location = New System.Drawing.Point(95, 43)
        Me.cmbCalle.Name = "cmbCalle"
        Me.cmbCalle.Size = New System.Drawing.Size(199, 20)
        Me.cmbCalle.TabIndex = 242
        '
        'ComboItem4
        '
        Me.ComboItem4.Text = "SOLICITUD"
        '
        'ComboItem5
        '
        Me.ComboItem5.Text = "MOROSIDAD"
        '
        'ComboItem6
        '
        Me.ComboItem6.Text = "OTROS"
        '
        'cmbServicios
        '
        Me.cmbServicios.DisplayMember = "Text"
        Me.cmbServicios.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbServicios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbServicios.FormattingEnabled = True
        Me.cmbServicios.ItemHeight = 14
        Me.cmbServicios.Location = New System.Drawing.Point(497, 125)
        Me.cmbServicios.Name = "cmbServicios"
        Me.cmbServicios.Size = New System.Drawing.Size(103, 20)
        Me.cmbServicios.TabIndex = 241
        '
        'LabelX4
        '
        Me.LabelX4.AutoSize = True
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        Me.LabelX4.Location = New System.Drawing.Point(446, 129)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(45, 15)
        Me.LabelX4.TabIndex = 240
        Me.LabelX4.Text = "Servicio:"
        '
        'cmbMotivo
        '
        Me.cmbMotivo.DisplayMember = "Text"
        Me.cmbMotivo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbMotivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMotivo.FormattingEnabled = True
        Me.cmbMotivo.ItemHeight = 14
        Me.cmbMotivo.Items.AddRange(New Object() {Me.ComboItem1, Me.ComboItem2, Me.ComboItem3})
        Me.cmbMotivo.Location = New System.Drawing.Point(297, 126)
        Me.cmbMotivo.Name = "cmbMotivo"
        Me.cmbMotivo.Size = New System.Drawing.Size(123, 20)
        Me.cmbMotivo.TabIndex = 239
        '
        'ComboItem1
        '
        Me.ComboItem1.Text = "SOLICITUD"
        '
        'ComboItem2
        '
        Me.ComboItem2.Text = "MOROSIDAD"
        '
        'ComboItem3
        '
        Me.ComboItem3.Text = "OTROS"
        '
        'txtLote
        '
        '
        '
        '
        Me.txtLote.Border.Class = "TextBoxBorder"
        Me.txtLote.Enabled = False
        Me.txtLote.Location = New System.Drawing.Point(347, 78)
        Me.txtLote.Name = "txtLote"
        Me.txtLote.Size = New System.Drawing.Size(113, 20)
        Me.txtLote.TabIndex = 238
        '
        'LabelX3
        '
        Me.LabelX3.AutoSize = True
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        Me.LabelX3.Location = New System.Drawing.Point(297, 81)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(42, 15)
        Me.LabelX3.TabIndex = 237
        Me.LabelX3.Text = "Lote N°:"
        '
        'txtManzana
        '
        '
        '
        '
        Me.txtManzana.Border.Class = "TextBoxBorder"
        Me.txtManzana.Enabled = False
        Me.txtManzana.Location = New System.Drawing.Point(95, 76)
        Me.txtManzana.Name = "txtManzana"
        Me.txtManzana.Size = New System.Drawing.Size(104, 20)
        Me.txtManzana.TabIndex = 236
        '
        'LabelX1
        '
        Me.LabelX1.AutoSize = True
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        Me.LabelX1.Location = New System.Drawing.Point(14, 81)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(51, 15)
        Me.LabelX1.TabIndex = 235
        Me.LabelX1.Text = "Manzana:"
        '
        'LabelX14
        '
        Me.LabelX14.AutoSize = True
        Me.LabelX14.BackColor = System.Drawing.Color.Transparent
        Me.LabelX14.Location = New System.Drawing.Point(15, 44)
        Me.LabelX14.Name = "LabelX14"
        Me.LabelX14.Size = New System.Drawing.Size(31, 15)
        Me.LabelX14.TabIndex = 233
        Me.LabelX14.Text = "Calle:"
        '
        'txtNombre
        '
        '
        '
        '
        Me.txtNombre.Border.Class = "TextBoxBorder"
        Me.txtNombre.Enabled = False
        Me.txtNombre.Location = New System.Drawing.Point(95, 8)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(365, 20)
        Me.txtNombre.TabIndex = 232
        '
        'txtNCasa
        '
        '
        '
        '
        Me.txtNCasa.Border.Class = "TextBoxBorder"
        Me.txtNCasa.Enabled = False
        Me.txtNCasa.Location = New System.Drawing.Point(543, 41)
        Me.txtNCasa.Name = "txtNCasa"
        Me.txtNCasa.Size = New System.Drawing.Size(123, 20)
        Me.txtNCasa.TabIndex = 230
        '
        'LabelX13
        '
        Me.LabelX13.AutoSize = True
        Me.LabelX13.BackColor = System.Drawing.Color.Transparent
        Me.LabelX13.Location = New System.Drawing.Point(473, 45)
        Me.LabelX13.Name = "LabelX13"
        Me.LabelX13.Size = New System.Drawing.Size(46, 15)
        Me.LabelX13.TabIndex = 229
        Me.LabelX13.Text = "N° Casa:"
        '
        'txtPredio
        '
        '
        '
        '
        Me.txtPredio.Border.Class = "TextBoxBorder"
        Me.txtPredio.Enabled = False
        Me.txtPredio.Location = New System.Drawing.Point(348, 43)
        Me.txtPredio.Name = "txtPredio"
        Me.txtPredio.Size = New System.Drawing.Size(112, 20)
        Me.txtPredio.TabIndex = 228
        '
        'txtEstructuta
        '
        Me.txtEstructuta.AutoSize = True
        Me.txtEstructuta.BackColor = System.Drawing.Color.Transparent
        Me.txtEstructuta.Location = New System.Drawing.Point(306, 47)
        Me.txtEstructuta.Name = "txtEstructuta"
        Me.txtEstructuta.Size = New System.Drawing.Size(37, 15)
        Me.txtEstructuta.TabIndex = 227
        Me.txtEstructuta.Text = "Predio:"
        '
        'txtFechaCorte
        '
        '
        '
        '
        Me.txtFechaCorte.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtFechaCorte.ButtonDropDown.Visible = True
        Me.txtFechaCorte.Location = New System.Drawing.Point(95, 125)
        '
        '
        '
        Me.txtFechaCorte.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        Me.txtFechaCorte.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.txtFechaCorte.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.txtFechaCorte.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.txtFechaCorte.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.txtFechaCorte.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.txtFechaCorte.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.txtFechaCorte.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.txtFechaCorte.MonthCalendar.DisplayMonth = New Date(2010, 5, 1, 0, 0, 0, 0)
        Me.txtFechaCorte.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.txtFechaCorte.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.txtFechaCorte.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.txtFechaCorte.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.txtFechaCorte.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.txtFechaCorte.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.txtFechaCorte.MonthCalendar.TodayButtonVisible = True
        Me.txtFechaCorte.Name = "txtFechaCorte"
        Me.txtFechaCorte.Size = New System.Drawing.Size(123, 20)
        Me.txtFechaCorte.TabIndex = 226
        '
        'txtFechaRegistro
        '
        '
        '
        '
        Me.txtFechaRegistro.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtFechaRegistro.ButtonDropDown.Visible = True
        Me.txtFechaRegistro.Location = New System.Drawing.Point(543, 76)
        '
        '
        '
        Me.txtFechaRegistro.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        Me.txtFechaRegistro.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.txtFechaRegistro.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.txtFechaRegistro.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.txtFechaRegistro.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.txtFechaRegistro.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.txtFechaRegistro.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.txtFechaRegistro.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.txtFechaRegistro.MonthCalendar.DisplayMonth = New Date(2010, 5, 1, 0, 0, 0, 0)
        Me.txtFechaRegistro.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.txtFechaRegistro.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.txtFechaRegistro.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.txtFechaRegistro.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.txtFechaRegistro.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.txtFechaRegistro.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.txtFechaRegistro.MonthCalendar.TodayButtonVisible = True
        Me.txtFechaRegistro.Name = "txtFechaRegistro"
        Me.txtFechaRegistro.Size = New System.Drawing.Size(123, 20)
        Me.txtFechaRegistro.TabIndex = 211
        '
        'LabelX2
        '
        Me.LabelX2.AutoSize = True
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        Me.LabelX2.Location = New System.Drawing.Point(474, 77)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(59, 15)
        Me.LabelX2.TabIndex = 210
        Me.LabelX2.Text = "F. Registro:"
        '
        'txtDNI
        '
        '
        '
        '
        Me.txtDNI.Border.Class = "TextBoxBorder"
        Me.txtDNI.Enabled = False
        Me.txtDNI.Location = New System.Drawing.Point(543, 9)
        Me.txtDNI.Name = "txtDNI"
        Me.txtDNI.Size = New System.Drawing.Size(123, 20)
        Me.txtDNI.TabIndex = 205
        '
        'LabelX8
        '
        Me.LabelX8.AutoSize = True
        Me.LabelX8.BackColor = System.Drawing.Color.Transparent
        Me.LabelX8.Location = New System.Drawing.Point(477, 9)
        Me.LabelX8.Name = "LabelX8"
        Me.LabelX8.Size = New System.Drawing.Size(40, 15)
        Me.LabelX8.TabIndex = 204
        Me.LabelX8.Text = "DNI N°:"
        '
        'LabelX12
        '
        Me.LabelX12.AutoSize = True
        Me.LabelX12.BackColor = System.Drawing.Color.Transparent
        Me.LabelX12.Location = New System.Drawing.Point(7, 97)
        Me.LabelX12.Name = "LabelX12"
        Me.LabelX12.Size = New System.Drawing.Size(676, 15)
        Me.LabelX12.TabIndex = 97
        Me.LabelX12.Text = "_________________________________________________________________________________" & _
            "______________________________"
        '
        'txtDescripcion
        '
        '
        '
        '
        Me.txtDescripcion.Border.Class = "TextBoxBorder"
        Me.txtDescripcion.Location = New System.Drawing.Point(95, 165)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(570, 20)
        Me.txtDescripcion.TabIndex = 85
        '
        'LabelX21
        '
        Me.LabelX21.AutoSize = True
        Me.LabelX21.BackColor = System.Drawing.Color.Transparent
        Me.LabelX21.Location = New System.Drawing.Point(14, 165)
        Me.LabelX21.Name = "LabelX21"
        Me.LabelX21.Size = New System.Drawing.Size(63, 15)
        Me.LabelX21.TabIndex = 84
        Me.LabelX21.Text = "Descripcion:"
        '
        'LabelX20
        '
        Me.LabelX20.AutoSize = True
        Me.LabelX20.BackColor = System.Drawing.Color.Transparent
        Me.LabelX20.Location = New System.Drawing.Point(237, 130)
        Me.LabelX20.Name = "LabelX20"
        Me.LabelX20.Size = New System.Drawing.Size(38, 15)
        Me.LabelX20.TabIndex = 78
        Me.LabelX20.Text = "Motivo:"
        '
        'LabelX11
        '
        Me.LabelX11.AutoSize = True
        Me.LabelX11.BackColor = System.Drawing.Color.Transparent
        Me.LabelX11.Location = New System.Drawing.Point(13, 129)
        Me.LabelX11.Name = "LabelX11"
        Me.LabelX11.Size = New System.Drawing.Size(63, 15)
        Me.LabelX11.TabIndex = 67
        Me.LabelX11.Text = "Fecha Corte"
        '
        'LabelX7
        '
        Me.LabelX7.AutoSize = True
        Me.LabelX7.BackColor = System.Drawing.Color.Transparent
        Me.LabelX7.Location = New System.Drawing.Point(13, 6)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(44, 15)
        Me.LabelX7.TabIndex = 6
        Me.LabelX7.Text = "Usuario:"
        '
        'gridPredioCorte
        '
        Me.gridPredioCorte.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.gridPredioCorte.AllowUserToAddRows = False
        Me.gridPredioCorte.AllowUserToDeleteRows = False
        Me.gridPredioCorte.AllowUserToResizeRows = False
        Me.gridPredioCorte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gridPredioCorte.DefaultCellStyle = DataGridViewCellStyle1
        Me.gridPredioCorte.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.gridPredioCorte.Location = New System.Drawing.Point(3, 286)
        Me.gridPredioCorte.MultiSelect = False
        Me.gridPredioCorte.Name = "gridPredioCorte"
        Me.gridPredioCorte.ReadOnly = True
        Me.gridPredioCorte.RowHeadersVisible = False
        Me.gridPredioCorte.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridPredioCorte.Size = New System.Drawing.Size(689, 225)
        Me.gridPredioCorte.TabIndex = 201
        '
        'frmCortesServicio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(693, 543)
        Me.Controls.Add(Me.Bar6)
        Me.Controls.Add(Me.ExpandablePanel2)
        Me.Name = "frmCortesServicio"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmCortesServicio"
        CType(Me.Bar6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExpandablePanel2.ResumeLayout(False)
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupPanel1.PerformLayout()
        CType(Me.txtFechaCorte, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaRegistro, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridPredioCorte, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bar6 As DevComponents.DotNetBar.Bar
    Friend WithEvents ButtonItem2 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnDelete As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnSave As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ExpandablePanel2 As DevComponents.DotNetBar.ExpandablePanel
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents txtNCasa As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX13 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtPredio As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtEstructuta As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtFechaCorte As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents txtFechaRegistro As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtDNI As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX8 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX12 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtDescripcion As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX21 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX20 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX11 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents gridPredioCorte As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents LabelX14 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtNombre As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtManzana As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtLote As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cmbMotivo As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cmbServicios As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents ComboItem1 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem2 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem3 As DevComponents.Editors.ComboItem
    Friend WithEvents cmbCalle As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents ComboItem4 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem5 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem6 As DevComponents.Editors.ComboItem
    Friend WithEvents txtValorServicio As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents cmbEstado As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents ComboItem7 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem8 As DevComponents.Editors.ComboItem
    Friend WithEvents LabelX10 As DevComponents.DotNetBar.LabelX
    Friend WithEvents ComboItem9 As DevComponents.Editors.ComboItem
    Friend WithEvents ButtonItem1 As DevComponents.DotNetBar.ButtonItem
End Class
