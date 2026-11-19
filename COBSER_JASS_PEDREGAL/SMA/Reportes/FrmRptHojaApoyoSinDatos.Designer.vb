<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRptHojaApoyoSinDatos
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
        Me.Bar1 = New DevComponents.DotNetBar.Bar
        Me.btnReporte = New DevComponents.DotNetBar.ButtonItem
        Me.Bar2 = New DevComponents.DotNetBar.Bar
        Me.cmbComision = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.cmbJunta = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX
        Me.ExpandablePanel2 = New DevComponents.DotNetBar.ExpandablePanel
        Me.crViewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.Bar3 = New DevComponents.DotNetBar.Bar
        Me.lblProgreso = New DevComponents.DotNetBar.LabelItem
        Me.pgb = New DevComponents.DotNetBar.ProgressBarItem
        Me.ExpandablePanel1 = New DevComponents.DotNetBar.ExpandablePanel
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.LabelX16 = New DevComponents.DotNetBar.LabelX
        Me.txtValorServicio = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.LabelX13 = New DevComponents.DotNetBar.LabelX
        Me.cmbServicio = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX
        Me.cmbsector = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.cmbCPoblado = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.LabelX25 = New DevComponents.DotNetBar.LabelX
        Me.cmbCalles = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX
        Me.LabelX8 = New DevComponents.DotNetBar.LabelX
        Me.cmbReporte = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.ComboItem5 = New DevComponents.Editors.ComboItem
        Me.ComboItem1 = New DevComponents.Editors.ComboItem
        Me.ComboItem2 = New DevComponents.Editors.ComboItem
        Me.bgw = New System.ComponentModel.BackgroundWorker
        Me.ComboItem3 = New DevComponents.Editors.ComboItem
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Bar2.SuspendLayout()
        Me.ExpandablePanel2.SuspendLayout()
        CType(Me.Bar3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExpandablePanel1.SuspendLayout()
        Me.GroupPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Bar1
        '
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.DockSide = DevComponents.DotNetBar.eDockSide.Left
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnReporte})
        Me.Bar1.Location = New System.Drawing.Point(0, 340)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(303, 25)
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
        'Bar2
        '
        Me.Bar2.Controls.Add(Me.cmbComision)
        Me.Bar2.Controls.Add(Me.cmbJunta)
        Me.Bar2.Controls.Add(Me.LabelX4)
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar2.Location = New System.Drawing.Point(303, 0)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(635, 25)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Bar2.TabIndex = 5
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'cmbComision
        '
        Me.cmbComision.DisplayMember = "Text"
        Me.cmbComision.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbComision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbComision.FormattingEnabled = True
        Me.cmbComision.ItemHeight = 17
        Me.cmbComision.Location = New System.Drawing.Point(444, 0)
        Me.cmbComision.Name = "cmbComision"
        Me.cmbComision.Size = New System.Drawing.Size(118, 23)
        Me.cmbComision.TabIndex = 8
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
        'ExpandablePanel2
        '
        Me.ExpandablePanel2.CanvasColor = System.Drawing.SystemColors.Control
        Me.ExpandablePanel2.CollapseDirection = DevComponents.DotNetBar.eCollapseDirection.RightToLeft
        Me.ExpandablePanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.ExpandablePanel2.Controls.Add(Me.crViewer)
        Me.ExpandablePanel2.Controls.Add(Me.Bar3)
        Me.ExpandablePanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ExpandablePanel2.ExpandButtonVisible = False
        Me.ExpandablePanel2.Location = New System.Drawing.Point(303, 0)
        Me.ExpandablePanel2.Name = "ExpandablePanel2"
        Me.ExpandablePanel2.Size = New System.Drawing.Size(635, 365)
        Me.ExpandablePanel2.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.ExpandablePanel2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.ExpandablePanel2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.ExpandablePanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.ExpandablePanel2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.ExpandablePanel2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
        Me.ExpandablePanel2.Style.GradientAngle = 90
        Me.ExpandablePanel2.TabIndex = 7
        Me.ExpandablePanel2.TitleStyle.Alignment = System.Drawing.StringAlignment.Center
        Me.ExpandablePanel2.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.ExpandablePanel2.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.ExpandablePanel2.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner
        Me.ExpandablePanel2.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.ExpandablePanel2.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.ExpandablePanel2.TitleStyle.GradientAngle = 90
        Me.ExpandablePanel2.TitleText = "Reporte"
        '
        'crViewer
        '
        Me.crViewer.ActiveViewIndex = -1
        Me.crViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crViewer.DisplayGroupTree = False
        Me.crViewer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.crViewer.Location = New System.Drawing.Point(0, 26)
        Me.crViewer.Name = "crViewer"
        Me.crViewer.SelectionFormula = ""
        Me.crViewer.Size = New System.Drawing.Size(635, 320)
        Me.crViewer.TabIndex = 178
        Me.crViewer.ViewTimeSelectionFormula = ""
        '
        'Bar3
        '
        Me.Bar3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar3.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.Bar3.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.lblProgreso, Me.pgb})
        Me.Bar3.Location = New System.Drawing.Point(0, 346)
        Me.Bar3.Name = "Bar3"
        Me.Bar3.Size = New System.Drawing.Size(635, 19)
        Me.Bar3.Stretch = True
        Me.Bar3.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Bar3.TabIndex = 177
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
        'ExpandablePanel1
        '
        Me.ExpandablePanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.ExpandablePanel1.CollapseDirection = DevComponents.DotNetBar.eCollapseDirection.RightToLeft
        Me.ExpandablePanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.ExpandablePanel1.Controls.Add(Me.GroupPanel1)
        Me.ExpandablePanel1.Controls.Add(Me.LabelX1)
        Me.ExpandablePanel1.Controls.Add(Me.cmbsector)
        Me.ExpandablePanel1.Controls.Add(Me.cmbCPoblado)
        Me.ExpandablePanel1.Controls.Add(Me.LabelX25)
        Me.ExpandablePanel1.Controls.Add(Me.cmbCalles)
        Me.ExpandablePanel1.Controls.Add(Me.LabelX2)
        Me.ExpandablePanel1.Controls.Add(Me.LabelX8)
        Me.ExpandablePanel1.Controls.Add(Me.cmbReporte)
        Me.ExpandablePanel1.Controls.Add(Me.Bar1)
        Me.ExpandablePanel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.ExpandablePanel1.Location = New System.Drawing.Point(0, 0)
        Me.ExpandablePanel1.Name = "ExpandablePanel1"
        Me.ExpandablePanel1.Size = New System.Drawing.Size(303, 365)
        Me.ExpandablePanel1.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.ExpandablePanel1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.ExpandablePanel1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.ExpandablePanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.ExpandablePanel1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.ExpandablePanel1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
        Me.ExpandablePanel1.Style.GradientAngle = 90
        Me.ExpandablePanel1.TabIndex = 6
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
        Me.GroupPanel1.Controls.Add(Me.LabelX16)
        Me.GroupPanel1.Controls.Add(Me.txtValorServicio)
        Me.GroupPanel1.Controls.Add(Me.LabelX13)
        Me.GroupPanel1.Controls.Add(Me.cmbServicio)
        Me.GroupPanel1.Location = New System.Drawing.Point(13, 233)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(268, 80)
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
        Me.GroupPanel1.TabIndex = 187
        Me.GroupPanel1.Text = "Tipo Servicio"
        '
        'LabelX16
        '
        Me.LabelX16.AutoSize = True
        Me.LabelX16.BackColor = System.Drawing.Color.Transparent
        Me.LabelX16.Location = New System.Drawing.Point(0, 37)
        Me.LabelX16.Name = "LabelX16"
        Me.LabelX16.Size = New System.Drawing.Size(93, 15)
        Me.LabelX16.TabIndex = 169
        Me.LabelX16.Text = "Costo Servicio S/.:"
        '
        'txtValorServicio
        '
        '
        '
        '
        Me.txtValorServicio.Border.Class = "TextBoxBorder"
        Me.txtValorServicio.Enabled = False
        Me.txtValorServicio.Location = New System.Drawing.Point(99, 36)
        Me.txtValorServicio.Name = "txtValorServicio"
        Me.txtValorServicio.ReadOnly = True
        Me.txtValorServicio.Size = New System.Drawing.Size(96, 20)
        Me.txtValorServicio.TabIndex = 168
        '
        'LabelX13
        '
        Me.LabelX13.AutoSize = True
        Me.LabelX13.BackColor = System.Drawing.Color.Transparent
        Me.LabelX13.Location = New System.Drawing.Point(3, 9)
        Me.LabelX13.Name = "LabelX13"
        Me.LabelX13.Size = New System.Drawing.Size(42, 15)
        Me.LabelX13.TabIndex = 164
        Me.LabelX13.Text = "Servicio"
        '
        'cmbServicio
        '
        Me.cmbServicio.DisplayMember = "Text"
        Me.cmbServicio.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbServicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbServicio.FormattingEnabled = True
        Me.cmbServicio.ItemHeight = 14
        Me.cmbServicio.Location = New System.Drawing.Point(99, 4)
        Me.cmbServicio.Name = "cmbServicio"
        Me.cmbServicio.Size = New System.Drawing.Size(158, 20)
        Me.cmbServicio.TabIndex = 163
        '
        'LabelX1
        '
        Me.LabelX1.AutoSize = True
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        Me.LabelX1.Location = New System.Drawing.Point(13, 180)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(37, 15)
        Me.LabelX1.TabIndex = 186
        Me.LabelX1.Text = "Sector:"
        '
        'cmbsector
        '
        Me.cmbsector.DisplayMember = "Text"
        Me.cmbsector.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbsector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbsector.FormattingEnabled = True
        Me.cmbsector.ItemHeight = 15
        Me.cmbsector.Location = New System.Drawing.Point(12, 199)
        Me.cmbsector.Name = "cmbsector"
        Me.cmbsector.Size = New System.Drawing.Size(261, 21)
        Me.cmbsector.TabIndex = 185
        '
        'cmbCPoblado
        '
        Me.cmbCPoblado.DisplayMember = "Text"
        Me.cmbCPoblado.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbCPoblado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCPoblado.FormattingEnabled = True
        Me.cmbCPoblado.ItemHeight = 14
        Me.cmbCPoblado.Location = New System.Drawing.Point(12, 103)
        Me.cmbCPoblado.Name = "cmbCPoblado"
        Me.cmbCPoblado.Size = New System.Drawing.Size(261, 20)
        Me.cmbCPoblado.TabIndex = 183
        Me.cmbCPoblado.WatermarkText = "Seleccione un CP"
        '
        'LabelX25
        '
        Me.LabelX25.AutoSize = True
        Me.LabelX25.BackColor = System.Drawing.Color.Transparent
        Me.LabelX25.Location = New System.Drawing.Point(12, 86)
        Me.LabelX25.Name = "LabelX25"
        Me.LabelX25.Size = New System.Drawing.Size(60, 15)
        Me.LabelX25.TabIndex = 184
        Me.LabelX25.Text = "C. Poblado:"
        '
        'cmbCalles
        '
        Me.cmbCalles.DisplayMember = "Text"
        Me.cmbCalles.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbCalles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCalles.FormattingEnabled = True
        Me.cmbCalles.ItemHeight = 15
        Me.cmbCalles.Location = New System.Drawing.Point(12, 150)
        Me.cmbCalles.Name = "cmbCalles"
        Me.cmbCalles.Size = New System.Drawing.Size(261, 21)
        Me.cmbCalles.TabIndex = 182
        '
        'LabelX2
        '
        Me.LabelX2.AutoSize = True
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        Me.LabelX2.Location = New System.Drawing.Point(12, 131)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(31, 15)
        Me.LabelX2.TabIndex = 181
        Me.LabelX2.Text = "Calle:"
        '
        'LabelX8
        '
        Me.LabelX8.AutoSize = True
        Me.LabelX8.Location = New System.Drawing.Point(12, 36)
        Me.LabelX8.Name = "LabelX8"
        Me.LabelX8.Size = New System.Drawing.Size(103, 15)
        Me.LabelX8.TabIndex = 180
        Me.LabelX8.Text = "Visualizar el reporte:"
        '
        'cmbReporte
        '
        Me.cmbReporte.DisplayMember = "Text"
        Me.cmbReporte.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbReporte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbReporte.FormattingEnabled = True
        Me.cmbReporte.ItemHeight = 14
        Me.cmbReporte.Items.AddRange(New Object() {Me.ComboItem5, Me.ComboItem1, Me.ComboItem2, Me.ComboItem3})
        Me.cmbReporte.Location = New System.Drawing.Point(12, 57)
        Me.cmbReporte.Name = "cmbReporte"
        Me.cmbReporte.Size = New System.Drawing.Size(261, 20)
        Me.cmbReporte.TabIndex = 179
        '
        'ComboItem5
        '
        Me.ComboItem5.Text = "1. Padrón usuario y predios "
        '
        'ComboItem1
        '
        Me.ComboItem1.Text = "2. Reporte de Predios con Tipo Servicio"
        '
        'ComboItem2
        '
        Me.ComboItem2.Text = "3. Reporte  de Predios con Corte del Servicio"
        '
        'bgw
        '
        Me.bgw.WorkerReportsProgress = True
        '
        'ComboItem3
        '
        Me.ComboItem3.Text = "4. Reporte de Asistencia a Asambleas"
        '
        'FrmRptHojaApoyoSinDatos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(938, 365)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.ExpandablePanel2)
        Me.Controls.Add(Me.ExpandablePanel1)
        Me.Name = "FrmRptHojaApoyoSinDatos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de padron de Usuarios"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Bar2.ResumeLayout(False)
        Me.ExpandablePanel2.ResumeLayout(False)
        CType(Me.Bar3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExpandablePanel1.ResumeLayout(False)
        Me.ExpandablePanel1.PerformLayout()
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents btnReporte As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents cmbJunta As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents ExpandablePanel2 As DevComponents.DotNetBar.ExpandablePanel
    Friend WithEvents crViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents Bar3 As DevComponents.DotNetBar.Bar
    Friend WithEvents lblProgreso As DevComponents.DotNetBar.LabelItem
    Friend WithEvents pgb As DevComponents.DotNetBar.ProgressBarItem
    Friend WithEvents ExpandablePanel1 As DevComponents.DotNetBar.ExpandablePanel
    Friend WithEvents bgw As System.ComponentModel.BackgroundWorker
    Friend WithEvents LabelX8 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cmbReporte As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents ComboItem5 As DevComponents.Editors.ComboItem
    Friend WithEvents cmbCalles As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cmbComision As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents cmbCPoblado As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX25 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cmbsector As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents LabelX16 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtValorServicio As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX13 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cmbServicio As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents ComboItem1 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem2 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem3 As DevComponents.Editors.ComboItem
End Class
