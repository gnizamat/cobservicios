<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRpt_TarCobranzas
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
        Me.Bar2 = New DevComponents.DotNetBar.Bar
        Me.cmbJunta = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX
        Me.ExpandablePanel1 = New DevComponents.DotNetBar.ExpandablePanel
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.cmbTipoDeuda = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.ComboItem9 = New DevComponents.Editors.ComboItem
        Me.ComboItem10 = New DevComponents.Editors.ComboItem
        Me.ComboItem11 = New DevComponents.Editors.ComboItem
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX
        Me.cmbCajas = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.ComboItem2 = New DevComponents.Editors.ComboItem
        Me.ComboItem3 = New DevComponents.Editors.ComboItem
        Me.ComboItem6 = New DevComponents.Editors.ComboItem
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX
        Me.txtFechaFin = New DevComponents.Editors.DateTimeAdv.DateTimeInput
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX
        Me.LabelX8 = New DevComponents.DotNetBar.LabelX
        Me.txtFechaIni = New DevComponents.Editors.DateTimeAdv.DateTimeInput
        Me.LabelX9 = New DevComponents.DotNetBar.LabelX
        Me.cmbReporte = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.ComboItem5 = New DevComponents.Editors.ComboItem
        Me.ComboItem4 = New DevComponents.Editors.ComboItem
        Me.ComboItem1 = New DevComponents.Editors.ComboItem
        Me.ComboItem7 = New DevComponents.Editors.ComboItem
        Me.ComboItem8 = New DevComponents.Editors.ComboItem
        Me.ComboItem12 = New DevComponents.Editors.ComboItem
        Me.Bar1 = New DevComponents.DotNetBar.Bar
        Me.btnReporte = New DevComponents.DotNetBar.ButtonItem
        Me.Bar3 = New DevComponents.DotNetBar.Bar
        Me.lblProgreso = New DevComponents.DotNetBar.LabelItem
        Me.pgb = New DevComponents.DotNetBar.ProgressBarItem
        Me.crViewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.txtValorSubTarifa = New DevComponents.DotNetBar.Controls.TextBoxX
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Bar2.SuspendLayout()
        Me.ExpandablePanel1.SuspendLayout()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.txtFechaFin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaIni, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bar2
        '
        Me.Bar2.Controls.Add(Me.cmbJunta)
        Me.Bar2.Controls.Add(Me.LabelX4)
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar2.Location = New System.Drawing.Point(339, 0)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(586, 25)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Bar2.TabIndex = 182
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'cmbJunta
        '
        Me.cmbJunta.DisplayMember = "Text"
        Me.cmbJunta.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbJunta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbJunta.FormattingEnabled = True
        Me.cmbJunta.ItemHeight = 17
        Me.cmbJunta.Location = New System.Drawing.Point(121, 0)
        Me.cmbJunta.Name = "cmbJunta"
        Me.cmbJunta.Size = New System.Drawing.Size(227, 23)
        Me.cmbJunta.TabIndex = 7
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        Me.LabelX4.Location = New System.Drawing.Point(12, 3)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(103, 19)
        Me.LabelX4.TabIndex = 5
        Me.LabelX4.Text = "JASS:"
        '
        'ExpandablePanel1
        '
        Me.ExpandablePanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.ExpandablePanel1.CollapseDirection = DevComponents.DotNetBar.eCollapseDirection.RightToLeft
        Me.ExpandablePanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.ExpandablePanel1.Controls.Add(Me.GroupPanel1)
        Me.ExpandablePanel1.Controls.Add(Me.Bar1)
        Me.ExpandablePanel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.ExpandablePanel1.Location = New System.Drawing.Point(0, 0)
        Me.ExpandablePanel1.Name = "ExpandablePanel1"
        Me.ExpandablePanel1.Size = New System.Drawing.Size(339, 444)
        Me.ExpandablePanel1.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.ExpandablePanel1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.ExpandablePanel1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.ExpandablePanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.ExpandablePanel1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.ExpandablePanel1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
        Me.ExpandablePanel1.Style.GradientAngle = 90
        Me.ExpandablePanel1.TabIndex = 183
        Me.ExpandablePanel1.TitleStyle.Alignment = System.Drawing.StringAlignment.Center
        Me.ExpandablePanel1.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.ExpandablePanel1.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.ExpandablePanel1.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner
        Me.ExpandablePanel1.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.ExpandablePanel1.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.ExpandablePanel1.TitleStyle.GradientAngle = 90
        Me.ExpandablePanel1.TitleText = "Parametros"
        '
        'GroupPanel1
        '
        Me.GroupPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.txtValorSubTarifa)
        Me.GroupPanel1.Controls.Add(Me.cmbTipoDeuda)
        Me.GroupPanel1.Controls.Add(Me.LabelX5)
        Me.GroupPanel1.Controls.Add(Me.cmbCajas)
        Me.GroupPanel1.Controls.Add(Me.LabelX2)
        Me.GroupPanel1.Controls.Add(Me.txtFechaFin)
        Me.GroupPanel1.Controls.Add(Me.LabelX1)
        Me.GroupPanel1.Controls.Add(Me.LabelX8)
        Me.GroupPanel1.Controls.Add(Me.txtFechaIni)
        Me.GroupPanel1.Controls.Add(Me.LabelX9)
        Me.GroupPanel1.Controls.Add(Me.cmbReporte)
        Me.GroupPanel1.Location = New System.Drawing.Point(12, 47)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(314, 220)
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
        Me.GroupPanel1.TabIndex = 188
        Me.GroupPanel1.Text = "Parametros"
        '
        'cmbTipoDeuda
        '
        Me.cmbTipoDeuda.DisplayMember = "Text"
        Me.cmbTipoDeuda.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbTipoDeuda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoDeuda.FormattingEnabled = True
        Me.cmbTipoDeuda.ItemHeight = 15
        Me.cmbTipoDeuda.Items.AddRange(New Object() {Me.ComboItem9, Me.ComboItem10, Me.ComboItem11})
        Me.cmbTipoDeuda.Location = New System.Drawing.Point(118, 145)
        Me.cmbTipoDeuda.Name = "cmbTipoDeuda"
        Me.cmbTipoDeuda.Size = New System.Drawing.Size(119, 21)
        Me.cmbTipoDeuda.TabIndex = 193
        '
        'ComboItem9
        '
        Me.ComboItem9.Text = "Saldo"
        '
        'ComboItem10
        '
        Me.ComboItem10.Text = "Mora"
        '
        'ComboItem11
        '
        Me.ComboItem11.Text = "Todo"
        '
        'LabelX5
        '
        Me.LabelX5.AutoSize = True
        Me.LabelX5.BackColor = System.Drawing.Color.Transparent
        Me.LabelX5.Location = New System.Drawing.Point(16, 151)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(74, 15)
        Me.LabelX5.TabIndex = 192
        Me.LabelX5.Text = "Tipo de Deuda"
        '
        'cmbCajas
        '
        Me.cmbCajas.DisplayMember = "Text"
        Me.cmbCajas.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbCajas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCajas.FormattingEnabled = True
        Me.cmbCajas.ItemHeight = 14
        Me.cmbCajas.Items.AddRange(New Object() {Me.ComboItem2, Me.ComboItem3, Me.ComboItem6})
        Me.cmbCajas.Location = New System.Drawing.Point(118, 101)
        Me.cmbCajas.Name = "cmbCajas"
        Me.cmbCajas.Size = New System.Drawing.Size(184, 20)
        Me.cmbCajas.TabIndex = 191
        '
        'ComboItem2
        '
        Me.ComboItem2.Text = "C1. Liquidacion de Cobranza Detallada"
        '
        'ComboItem3
        '
        Me.ComboItem3.Text = "C2. Resumen Cobranza Servicios"
        '
        'ComboItem6
        '
        Me.ComboItem6.Text = "C3. Resumen Cobrzan Años"
        '
        'LabelX2
        '
        Me.LabelX2.AutoSize = True
        Me.LabelX2.Location = New System.Drawing.Point(16, 106)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(28, 15)
        Me.LabelX2.TabIndex = 190
        Me.LabelX2.Text = "Caja:"
        '
        'txtFechaFin
        '
        '
        '
        '
        Me.txtFechaFin.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtFechaFin.ButtonDropDown.Visible = True
        Me.txtFechaFin.Location = New System.Drawing.Point(208, 65)
        '
        '
        '
        Me.txtFechaFin.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        Me.txtFechaFin.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.txtFechaFin.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.txtFechaFin.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.txtFechaFin.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.txtFechaFin.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.txtFechaFin.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.txtFechaFin.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.txtFechaFin.MonthCalendar.DisplayMonth = New Date(2010, 5, 1, 0, 0, 0, 0)
        Me.txtFechaFin.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.txtFechaFin.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.txtFechaFin.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.txtFechaFin.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.txtFechaFin.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.txtFechaFin.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.txtFechaFin.MonthCalendar.TodayButtonVisible = True
        Me.txtFechaFin.Name = "txtFechaFin"
        Me.txtFechaFin.Size = New System.Drawing.Size(95, 20)
        Me.txtFechaFin.TabIndex = 189
        '
        'LabelX1
        '
        Me.LabelX1.AutoSize = True
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        Me.LabelX1.Location = New System.Drawing.Point(168, 65)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(34, 15)
        Me.LabelX1.TabIndex = 188
        Me.LabelX1.Text = "Hasta:"
        '
        'LabelX8
        '
        Me.LabelX8.AutoSize = True
        Me.LabelX8.Location = New System.Drawing.Point(13, 3)
        Me.LabelX8.Name = "LabelX8"
        Me.LabelX8.Size = New System.Drawing.Size(103, 15)
        Me.LabelX8.TabIndex = 180
        Me.LabelX8.Text = "Visualizar el reporte:"
        '
        'txtFechaIni
        '
        '
        '
        '
        Me.txtFechaIni.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtFechaIni.ButtonDropDown.Visible = True
        Me.txtFechaIni.Location = New System.Drawing.Point(57, 62)
        '
        '
        '
        Me.txtFechaIni.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        Me.txtFechaIni.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.txtFechaIni.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.txtFechaIni.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.txtFechaIni.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.txtFechaIni.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.txtFechaIni.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.txtFechaIni.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.txtFechaIni.MonthCalendar.DisplayMonth = New Date(2010, 5, 1, 0, 0, 0, 0)
        Me.txtFechaIni.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.txtFechaIni.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.txtFechaIni.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.txtFechaIni.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.txtFechaIni.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.txtFechaIni.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.txtFechaIni.MonthCalendar.TodayButtonVisible = True
        Me.txtFechaIni.Name = "txtFechaIni"
        Me.txtFechaIni.Size = New System.Drawing.Size(104, 20)
        Me.txtFechaIni.TabIndex = 186
        '
        'LabelX9
        '
        Me.LabelX9.AutoSize = True
        Me.LabelX9.BackColor = System.Drawing.Color.Transparent
        Me.LabelX9.Location = New System.Drawing.Point(14, 65)
        Me.LabelX9.Name = "LabelX9"
        Me.LabelX9.Size = New System.Drawing.Size(37, 15)
        Me.LabelX9.TabIndex = 187
        Me.LabelX9.Text = "Desde:"
        '
        'cmbReporte
        '
        Me.cmbReporte.DisplayMember = "Text"
        Me.cmbReporte.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbReporte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbReporte.FormattingEnabled = True
        Me.cmbReporte.ItemHeight = 14
        Me.cmbReporte.Items.AddRange(New Object() {Me.ComboItem5, Me.ComboItem4, Me.ComboItem1, Me.ComboItem7, Me.ComboItem8, Me.ComboItem12})
        Me.cmbReporte.Location = New System.Drawing.Point(13, 24)
        Me.cmbReporte.Name = "cmbReporte"
        Me.cmbReporte.Size = New System.Drawing.Size(289, 20)
        Me.cmbReporte.TabIndex = 179
        '
        'ComboItem5
        '
        Me.ComboItem5.Text = "C1. Liquidacion de Cobranza Detallada"
        '
        'ComboItem4
        '
        Me.ComboItem4.Text = "C2. Resumen Cobranza Servicios"
        '
        'ComboItem1
        '
        Me.ComboItem1.Text = "C3. Resumen Cobranza Años"
        '
        'ComboItem7
        '
        Me.ComboItem7.Text = "C4. Liquidacion Detallada de Cobranzas"
        '
        'ComboItem8
        '
        Me.ComboItem8.Text = "C5. Liquidacion de Cobranzas Diaria"
        '
        'ComboItem12
        '
        Me.ComboItem12.Text = "C6. Liquidacion de Cobranzas por Servicio"
        '
        'Bar1
        '
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.DockSide = DevComponents.DotNetBar.eDockSide.Left
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnReporte})
        Me.Bar1.Location = New System.Drawing.Point(0, 419)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(339, 25)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Bar1.TabIndex = 170
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'btnReporte
        '
        Me.btnReporte.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnReporte.Image = Global.COBSER.My.Resources.Resources.list_users
        Me.btnReporte.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.btnReporte.ImagePaddingHorizontal = 8
        Me.btnReporte.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.btnReporte.Name = "btnReporte"
        Me.btnReporte.Text = "Generar Reporte"
        '
        'Bar3
        '
        Me.Bar3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar3.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.lblProgreso, Me.pgb})
        Me.Bar3.Location = New System.Drawing.Point(0, 444)
        Me.Bar3.Name = "Bar3"
        Me.Bar3.Size = New System.Drawing.Size(925, 19)
        Me.Bar3.Stretch = True
        Me.Bar3.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Bar3.TabIndex = 184
        Me.Bar3.TabStop = False
        Me.Bar3.Text = "s"
        '
        'lblProgreso
        '
        Me.lblProgreso.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.lblProgreso.Name = "lblProgreso"
        Me.lblProgreso.TextAlignment = System.Drawing.StringAlignment.Far
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
        'crViewer
        '
        Me.crViewer.ActiveViewIndex = -1
        Me.crViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crViewer.DisplayGroupTree = False
        Me.crViewer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.crViewer.Location = New System.Drawing.Point(339, 25)
        Me.crViewer.Name = "crViewer"
        Me.crViewer.SelectionFormula = ""
        Me.crViewer.Size = New System.Drawing.Size(586, 419)
        Me.crViewer.TabIndex = 185
        Me.crViewer.ViewTimeSelectionFormula = ""
        '
        'txtValorSubTarifa
        '
        '
        '
        '
        Me.txtValorSubTarifa.Border.Class = "TextBoxBorder"
        Me.txtValorSubTarifa.Enabled = False
        Me.txtValorSubTarifa.Location = New System.Drawing.Point(243, 145)
        Me.txtValorSubTarifa.Name = "txtValorSubTarifa"
        Me.txtValorSubTarifa.ReadOnly = True
        Me.txtValorSubTarifa.Size = New System.Drawing.Size(59, 20)
        Me.txtValorSubTarifa.TabIndex = 194
        '
        'frmRpt_TarCobranzas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(925, 463)
        Me.Controls.Add(Me.crViewer)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.ExpandablePanel1)
        Me.Controls.Add(Me.Bar3)
        Me.Name = "frmRpt_TarCobranzas"
        Me.Text = "frmRpt_TarCobranzas"
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Bar2.ResumeLayout(False)
        Me.ExpandablePanel1.ResumeLayout(False)
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupPanel1.PerformLayout()
        CType(Me.txtFechaFin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaIni, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents cmbJunta As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents ExpandablePanel1 As DevComponents.DotNetBar.ExpandablePanel
    Friend WithEvents LabelX8 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cmbReporte As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents ComboItem5 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem4 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem1 As DevComponents.Editors.ComboItem
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents btnReporte As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Bar3 As DevComponents.DotNetBar.Bar
    Friend WithEvents lblProgreso As DevComponents.DotNetBar.LabelItem
    Friend WithEvents pgb As DevComponents.DotNetBar.ProgressBarItem
    Friend WithEvents LabelX9 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtFechaIni As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents cmbCajas As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents ComboItem2 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem3 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem6 As DevComponents.Editors.ComboItem
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtFechaFin As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents crViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents ComboItem7 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem8 As DevComponents.Editors.ComboItem
    Friend WithEvents cmbTipoDeuda As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents ComboItem9 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem10 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem11 As DevComponents.Editors.ComboItem
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents ComboItem12 As DevComponents.Editors.ComboItem
    Friend WithEvents txtValorSubTarifa As DevComponents.DotNetBar.Controls.TextBoxX
End Class
