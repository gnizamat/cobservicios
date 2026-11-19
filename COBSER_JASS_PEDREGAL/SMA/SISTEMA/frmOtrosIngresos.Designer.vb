<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOtrosIngresos
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
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.lblFecha = New DevComponents.DotNetBar.LabelX
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX
        Me.LabelX10 = New DevComponents.DotNetBar.LabelX
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX
        Me.txtFFin = New DevComponents.Editors.DateTimeAdv.DateTimeInput
        Me.cmbTipoIngreso = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.txtFInicio = New DevComponents.Editors.DateTimeAdv.DateTimeInput
        Me.Bar6 = New DevComponents.DotNetBar.Bar
        Me.btnNew = New DevComponents.DotNetBar.ButtonItem
        Me.btnDel = New DevComponents.DotNetBar.ButtonItem
        Me.ButtonItem13 = New DevComponents.DotNetBar.ButtonItem
        Me.ButtonItem1 = New DevComponents.DotNetBar.ButtonItem
        Me.dgIngresos = New DevComponents.DotNetBar.Controls.DataGridViewX
        Me.Bar2 = New DevComponents.DotNetBar.Bar
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX
        Me.cmbJunta = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.cmbCPoblado = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX
        Me.ControlContainerItem5 = New DevComponents.DotNetBar.ControlContainerItem
        Me.ControlContainerItem2 = New DevComponents.DotNetBar.ControlContainerItem
        Me.ControlContainerItem3 = New DevComponents.DotNetBar.ControlContainerItem
        Me.ControlContainerItem4 = New DevComponents.DotNetBar.ControlContainerItem
        Me.lblMontoTotal = New DevComponents.DotNetBar.LabelX
        Me.LabelX21 = New DevComponents.DotNetBar.LabelX
        Me.GroupPanel1.SuspendLayout()
        CType(Me.txtFFin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFInicio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgIngresos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Bar2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupPanel1
        '
        Me.GroupPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.lblFecha)
        Me.GroupPanel1.Controls.Add(Me.LabelX5)
        Me.GroupPanel1.Controls.Add(Me.LabelX10)
        Me.GroupPanel1.Controls.Add(Me.LabelX4)
        Me.GroupPanel1.Controls.Add(Me.LabelX1)
        Me.GroupPanel1.Controls.Add(Me.txtFFin)
        Me.GroupPanel1.Controls.Add(Me.cmbTipoIngreso)
        Me.GroupPanel1.Controls.Add(Me.txtFInicio)
        Me.GroupPanel1.Location = New System.Drawing.Point(0, 34)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(655, 119)
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
        Me.GroupPanel1.TabIndex = 23
        Me.GroupPanel1.Text = "GroupPanel1"
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.BackColor = System.Drawing.Color.Transparent
        Me.lblFecha.Location = New System.Drawing.Point(144, 3)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(58, 15)
        Me.lblFecha.TabIndex = 24
        Me.lblFecha.Text = "25/05/2009"
        '
        'LabelX5
        '
        Me.LabelX5.AutoSize = True
        Me.LabelX5.BackColor = System.Drawing.Color.Transparent
        Me.LabelX5.Location = New System.Drawing.Point(317, 69)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(44, 15)
        Me.LabelX5.TabIndex = 20
        Me.LabelX5.Text = "hasta el:"
        '
        'LabelX10
        '
        Me.LabelX10.AutoSize = True
        Me.LabelX10.BackColor = System.Drawing.Color.Transparent
        Me.LabelX10.Location = New System.Drawing.Point(9, 3)
        Me.LabelX10.Name = "LabelX10"
        Me.LabelX10.Size = New System.Drawing.Size(62, 15)
        Me.LabelX10.TabIndex = 21
        Me.LabelX10.Text = "F. Registro :"
        '
        'LabelX4
        '
        Me.LabelX4.AutoSize = True
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        Me.LabelX4.Location = New System.Drawing.Point(9, 69)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(87, 15)
        Me.LabelX4.TabIndex = 19
        Me.LabelX4.Text = "Mostrar desde el:"
        '
        'LabelX1
        '
        Me.LabelX1.AutoSize = True
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        Me.LabelX1.Location = New System.Drawing.Point(9, 33)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(82, 15)
        Me.LabelX1.TabIndex = 12
        Me.LabelX1.Text = "Tipo de Ingreso:"
        '
        'txtFFin
        '
        '
        '
        '
        Me.txtFFin.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtFFin.ButtonClear.Visible = True
        Me.txtFFin.ButtonDropDown.Visible = True
        Me.txtFFin.Location = New System.Drawing.Point(367, 64)
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
        Me.txtFFin.TabIndex = 18
        '
        'cmbTipoIngreso
        '
        Me.cmbTipoIngreso.DisplayMember = "Text"
        Me.cmbTipoIngreso.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbTipoIngreso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoIngreso.FormattingEnabled = True
        Me.cmbTipoIngreso.ItemHeight = 14
        Me.cmbTipoIngreso.Location = New System.Drawing.Point(142, 28)
        Me.cmbTipoIngreso.Name = "cmbTipoIngreso"
        Me.cmbTipoIngreso.Size = New System.Drawing.Size(489, 20)
        Me.cmbTipoIngreso.TabIndex = 11
        '
        'txtFInicio
        '
        '
        '
        '
        Me.txtFInicio.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtFInicio.ButtonClear.Visible = True
        Me.txtFInicio.ButtonDropDown.Visible = True
        Me.txtFInicio.Location = New System.Drawing.Point(142, 64)
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
        Me.txtFInicio.TabIndex = 17
        '
        'Bar6
        '
        Me.Bar6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar6.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnNew, Me.btnDel, Me.ButtonItem13})
        Me.Bar6.Location = New System.Drawing.Point(0, 535)
        Me.Bar6.Name = "Bar6"
        Me.Bar6.Size = New System.Drawing.Size(655, 25)
        Me.Bar6.Stretch = True
        Me.Bar6.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Bar6.TabIndex = 22
        Me.Bar6.TabStop = False
        Me.Bar6.Text = "Bar6"
        '
        'btnNew
        '
        Me.btnNew.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnNew.Image = Global.COBSER.My.Resources.Resources.add
        Me.btnNew.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.btnNew.ImagePaddingHorizontal = 8
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Text = "Nuevo "
        '
        'btnDel
        '
        Me.btnDel.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnDel.Image = Global.COBSER.My.Resources.Resources.delete
        Me.btnDel.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.btnDel.ImagePaddingHorizontal = 8
        Me.btnDel.Name = "btnDel"
        Me.btnDel.Text = "Anular"
        '
        'ButtonItem13
        '
        Me.ButtonItem13.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem13.Image = Global.COBSER.My.Resources.Resources.printer
        Me.ButtonItem13.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.ButtonItem13.ImagePaddingHorizontal = 8
        Me.ButtonItem13.Name = "ButtonItem13"
        Me.ButtonItem13.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem1})
        Me.ButtonItem13.Text = "Imprimir"
        '
        'ButtonItem1
        '
        Me.ButtonItem1.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.ButtonItem1.ImagePaddingHorizontal = 8
        Me.ButtonItem1.Name = "ButtonItem1"
        Me.ButtonItem1.Text = "Listado de Pagos"
        '
        'dgIngresos
        '
        Me.dgIngresos.AllowUserToAddRows = False
        Me.dgIngresos.AllowUserToDeleteRows = False
        Me.dgIngresos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgIngresos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgIngresos.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgIngresos.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgIngresos.Location = New System.Drawing.Point(0, 159)
        Me.dgIngresos.MultiSelect = False
        Me.dgIngresos.Name = "dgIngresos"
        Me.dgIngresos.ReadOnly = True
        Me.dgIngresos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgIngresos.Size = New System.Drawing.Size(655, 344)
        Me.dgIngresos.TabIndex = 21
        '
        'Bar2
        '
        Me.Bar2.Controls.Add(Me.LabelX3)
        Me.Bar2.Controls.Add(Me.cmbJunta)
        Me.Bar2.Controls.Add(Me.cmbCPoblado)
        Me.Bar2.Controls.Add(Me.LabelX2)
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ControlContainerItem5, Me.ControlContainerItem2, Me.ControlContainerItem3, Me.ControlContainerItem4})
        Me.Bar2.Location = New System.Drawing.Point(0, 0)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(655, 28)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Bar2.TabIndex = 24
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        Me.LabelX3.Location = New System.Drawing.Point(3, 5)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(114, 16)
        Me.LabelX3.TabIndex = 10
        Me.LabelX3.Text = "JASS:"
        '
        'cmbJunta
        '
        Me.cmbJunta.DisplayMember = "Text"
        Me.cmbJunta.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbJunta.DropDownHeight = 300
        Me.cmbJunta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbJunta.FormattingEnabled = True
        Me.cmbJunta.IntegralHeight = False
        Me.cmbJunta.ItemHeight = 17
        Me.cmbJunta.Location = New System.Drawing.Point(121, 2)
        Me.cmbJunta.Name = "cmbJunta"
        Me.cmbJunta.Size = New System.Drawing.Size(202, 23)
        Me.cmbJunta.TabIndex = 3
        '
        'cmbCPoblado
        '
        Me.cmbCPoblado.DisplayMember = "Text"
        Me.cmbCPoblado.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbCPoblado.DropDownHeight = 300
        Me.cmbCPoblado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCPoblado.FormattingEnabled = True
        Me.cmbCPoblado.IntegralHeight = False
        Me.cmbCPoblado.ItemHeight = 17
        Me.cmbCPoblado.Location = New System.Drawing.Point(350, 2)
        Me.cmbCPoblado.Name = "cmbCPoblado"
        Me.cmbCPoblado.Size = New System.Drawing.Size(163, 23)
        Me.cmbCPoblado.TabIndex = 9
        '
        'LabelX2
        '
        Me.LabelX2.AutoSize = True
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        Me.LabelX2.Location = New System.Drawing.Point(327, 4)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(19, 18)
        Me.LabelX2.TabIndex = 10
        Me.LabelX2.Text = "CP:"
        '
        'ControlContainerItem5
        '
        Me.ControlContainerItem5.AllowItemResize = False
        Me.ControlContainerItem5.Control = Me.LabelX3
        Me.ControlContainerItem5.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
        Me.ControlContainerItem5.Name = "ControlContainerItem5"
        '
        'ControlContainerItem2
        '
        Me.ControlContainerItem2.AllowItemResize = False
        Me.ControlContainerItem2.Control = Me.cmbJunta
        Me.ControlContainerItem2.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
        Me.ControlContainerItem2.Name = "ControlContainerItem2"
        '
        'ControlContainerItem3
        '
        Me.ControlContainerItem3.AllowItemResize = False
        Me.ControlContainerItem3.Control = Me.LabelX2
        Me.ControlContainerItem3.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
        Me.ControlContainerItem3.Name = "ControlContainerItem3"
        '
        'ControlContainerItem4
        '
        Me.ControlContainerItem4.AllowItemResize = False
        Me.ControlContainerItem4.Control = Me.cmbCPoblado
        Me.ControlContainerItem4.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
        Me.ControlContainerItem4.Name = "ControlContainerItem4"
        '
        'lblMontoTotal
        '
        Me.lblMontoTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblMontoTotal.AutoSize = True
        Me.lblMontoTotal.BackColor = System.Drawing.Color.Transparent
        Me.lblMontoTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMontoTotal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblMontoTotal.Location = New System.Drawing.Point(613, 511)
        Me.lblMontoTotal.Name = "lblMontoTotal"
        Me.lblMontoTotal.Size = New System.Drawing.Size(7, 17)
        Me.lblMontoTotal.TabIndex = 103
        Me.lblMontoTotal.Text = "-"
        '
        'LabelX21
        '
        Me.LabelX21.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LabelX21.AutoSize = True
        Me.LabelX21.BackColor = System.Drawing.Color.Transparent
        Me.LabelX21.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX21.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LabelX21.Location = New System.Drawing.Point(519, 512)
        Me.LabelX21.Name = "LabelX21"
        Me.LabelX21.Size = New System.Drawing.Size(75, 17)
        Me.LabelX21.TabIndex = 102
        Me.LabelX21.Text = "Monto Total:"
        '
        'frmOtrosIngresos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(655, 560)
        Me.Controls.Add(Me.lblMontoTotal)
        Me.Controls.Add(Me.LabelX21)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.Bar6)
        Me.Controls.Add(Me.dgIngresos)
        Me.Name = "frmOtrosIngresos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmOtrosIngresos"
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupPanel1.PerformLayout()
        CType(Me.txtFFin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFInicio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgIngresos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Bar2.ResumeLayout(False)
        Me.Bar2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX10 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtFFin As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents cmbTipoIngreso As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents txtFInicio As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Bar6 As DevComponents.DotNetBar.Bar
    Friend WithEvents btnNew As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnDel As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem13 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents dgIngresos As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents lblFecha As DevComponents.DotNetBar.LabelX
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cmbJunta As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents cmbCPoblado As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents ControlContainerItem5 As DevComponents.DotNetBar.ControlContainerItem
    Friend WithEvents ControlContainerItem2 As DevComponents.DotNetBar.ControlContainerItem
    Friend WithEvents ControlContainerItem3 As DevComponents.DotNetBar.ControlContainerItem
    Friend WithEvents ControlContainerItem4 As DevComponents.DotNetBar.ControlContainerItem
    Friend WithEvents ButtonItem1 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents lblMontoTotal As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX21 As DevComponents.DotNetBar.LabelX
End Class
