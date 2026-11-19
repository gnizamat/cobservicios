<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRptEvalTendPorCapacidad
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
        Me.pgb = New DevComponents.DotNetBar.ProgressBarItem
        Me.lblProgreso = New DevComponents.DotNetBar.LabelItem
        Me.bgw = New System.ComponentModel.BackgroundWorker
        Me.bgw1 = New System.ComponentModel.BackgroundWorker
        Me.ExpandablePanel1 = New DevComponents.DotNetBar.ExpandablePanel
        Me.cmbMeses = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX
        Me.Bar1 = New DevComponents.DotNetBar.Bar
        Me.btnReporte = New DevComponents.DotNetBar.ButtonItem
        Me.btnReporte2 = New DevComponents.DotNetBar.ButtonItem
        Me.cmbAnio = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX
        Me.ControlContainerItem1 = New DevComponents.DotNetBar.ControlContainerItem
        Me.ExpandablePanel2 = New DevComponents.DotNetBar.ExpandablePanel
        Me.crViewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.Bar3 = New DevComponents.DotNetBar.Bar
        Me.LabelItem1 = New DevComponents.DotNetBar.LabelItem
        Me.ProgressBarItem1 = New DevComponents.DotNetBar.ProgressBarItem
        Me.Bar2 = New DevComponents.DotNetBar.Bar
        Me.cmbComision = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.cmbJunta = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX
        Me.ExpandablePanel1.SuspendLayout()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExpandablePanel2.SuspendLayout()
        CType(Me.Bar3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Bar2.SuspendLayout()
        Me.SuspendLayout()
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
        'lblProgreso
        '
        Me.lblProgreso.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.lblProgreso.Name = "lblProgreso"
        Me.lblProgreso.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'bgw
        '
        Me.bgw.WorkerReportsProgress = True
        '
        'bgw1
        '
        Me.bgw1.WorkerReportsProgress = True
        '
        'ExpandablePanel1
        '
        Me.ExpandablePanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.ExpandablePanel1.CollapseDirection = DevComponents.DotNetBar.eCollapseDirection.RightToLeft
        Me.ExpandablePanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.ExpandablePanel1.Controls.Add(Me.cmbMeses)
        Me.ExpandablePanel1.Controls.Add(Me.LabelX2)
        Me.ExpandablePanel1.Controls.Add(Me.Bar1)
        Me.ExpandablePanel1.Controls.Add(Me.cmbAnio)
        Me.ExpandablePanel1.Controls.Add(Me.LabelX1)
        Me.ExpandablePanel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.ExpandablePanel1.Location = New System.Drawing.Point(0, 0)
        Me.ExpandablePanel1.Name = "ExpandablePanel1"
        Me.ExpandablePanel1.Size = New System.Drawing.Size(280, 444)
        Me.ExpandablePanel1.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.ExpandablePanel1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.ExpandablePanel1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.ExpandablePanel1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.ExpandablePanel1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
        Me.ExpandablePanel1.Style.GradientAngle = 90
        Me.ExpandablePanel1.TabIndex = 11
        Me.ExpandablePanel1.TitleStyle.Alignment = System.Drawing.StringAlignment.Center
        Me.ExpandablePanel1.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.ExpandablePanel1.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.ExpandablePanel1.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner
        Me.ExpandablePanel1.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.ExpandablePanel1.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.ExpandablePanel1.TitleStyle.GradientAngle = 90
        Me.ExpandablePanel1.TitleText = "Parametros"
        '
        'cmbMeses
        '
        Me.cmbMeses.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbMeses.DisplayMember = "Text"
        Me.cmbMeses.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbMeses.FormattingEnabled = True
        Me.cmbMeses.ItemHeight = 14
        Me.cmbMeses.Location = New System.Drawing.Point(97, 77)
        Me.cmbMeses.Name = "cmbMeses"
        Me.cmbMeses.Size = New System.Drawing.Size(176, 20)
        Me.cmbMeses.TabIndex = 172
        '
        'LabelX2
        '
        Me.LabelX2.Location = New System.Drawing.Point(8, 78)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(83, 20)
        Me.LabelX2.TabIndex = 171
        Me.LabelX2.Text = "Hasta el Mes de:"
        '
        'Bar1
        '
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.DockSide = DevComponents.DotNetBar.eDockSide.Left
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnReporte, Me.btnReporte2})
        Me.Bar1.Location = New System.Drawing.Point(0, 419)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(280, 25)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Bar1.TabIndex = 170
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'btnReporte
        '
        Me.btnReporte.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnReporte.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.btnReporte.ImagePaddingHorizontal = 8
        Me.btnReporte.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.btnReporte.Name = "btnReporte"
        Me.btnReporte.Text = "Imprimir Tendencia"
        '
        'btnReporte2
        '
        Me.btnReporte2.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnReporte2.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.btnReporte2.ImagePaddingHorizontal = 8
        Me.btnReporte2.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.btnReporte2.Name = "btnReporte2"
        Me.btnReporte2.Text = "Curva de Tendencias"
        '
        'cmbAnio
        '
        Me.cmbAnio.DisplayMember = "Text"
        Me.cmbAnio.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbAnio.FormattingEnabled = True
        Me.cmbAnio.ItemHeight = 14
        Me.cmbAnio.Location = New System.Drawing.Point(97, 37)
        Me.cmbAnio.Name = "cmbAnio"
        Me.cmbAnio.Size = New System.Drawing.Size(176, 20)
        Me.cmbAnio.TabIndex = 6
        '
        'LabelX1
        '
        Me.LabelX1.Location = New System.Drawing.Point(12, 37)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(70, 20)
        Me.LabelX1.TabIndex = 5
        Me.LabelX1.Text = "Año Apertura:"
        '
        'ControlContainerItem1
        '
        Me.ControlContainerItem1.AllowItemResize = False
        Me.ControlContainerItem1.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
        Me.ControlContainerItem1.Name = "ControlContainerItem1"
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
        Me.ExpandablePanel2.Location = New System.Drawing.Point(280, 0)
        Me.ExpandablePanel2.Name = "ExpandablePanel2"
        Me.ExpandablePanel2.Size = New System.Drawing.Size(705, 444)
        Me.ExpandablePanel2.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.ExpandablePanel2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.ExpandablePanel2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.ExpandablePanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.ExpandablePanel2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.ExpandablePanel2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
        Me.ExpandablePanel2.Style.GradientAngle = 90
        Me.ExpandablePanel2.TabIndex = 12
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
        Me.crViewer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.crViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crViewer.DisplayGroupTree = False
        Me.crViewer.Location = New System.Drawing.Point(0, 52)
        Me.crViewer.Name = "crViewer"
        Me.crViewer.SelectionFormula = ""
        Me.crViewer.Size = New System.Drawing.Size(705, 373)
        Me.crViewer.TabIndex = 178
        Me.crViewer.ViewTimeSelectionFormula = ""
        '
        'Bar3
        '
        Me.Bar3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar3.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.Bar3.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem1, Me.ProgressBarItem1})
        Me.Bar3.Location = New System.Drawing.Point(0, 425)
        Me.Bar3.Name = "Bar3"
        Me.Bar3.Size = New System.Drawing.Size(705, 19)
        Me.Bar3.Stretch = True
        Me.Bar3.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Bar3.TabIndex = 177
        Me.Bar3.TabStop = False
        Me.Bar3.Text = "s"
        '
        'LabelItem1
        '
        Me.LabelItem1.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.LabelItem1.Name = "LabelItem1"
        Me.LabelItem1.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'ProgressBarItem1
        '
        Me.ProgressBarItem1.ChunkGradientAngle = 0.0!
        Me.ProgressBarItem1.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.ProgressBarItem1.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
        Me.ProgressBarItem1.Name = "ProgressBarItem1"
        Me.ProgressBarItem1.RecentlyUsed = False
        Me.ProgressBarItem1.Width = 150
        '
        'Bar2
        '
        Me.Bar2.Controls.Add(Me.cmbComision)
        Me.Bar2.Controls.Add(Me.cmbJunta)
        Me.Bar2.Controls.Add(Me.LabelX3)
        Me.Bar2.Controls.Add(Me.LabelX4)
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar2.Location = New System.Drawing.Point(280, 0)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(705, 25)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Bar2.TabIndex = 180
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
        Me.cmbComision.Location = New System.Drawing.Point(504, 0)
        Me.cmbComision.Name = "cmbComision"
        Me.cmbComision.Size = New System.Drawing.Size(201, 23)
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
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        Me.LabelX3.Location = New System.Drawing.Point(376, 5)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(113, 15)
        Me.LabelX3.TabIndex = 6
        Me.LabelX3.Text = "Comision Usuarios:"
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        Me.LabelX4.Location = New System.Drawing.Point(12, 3)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(103, 19)
        Me.LabelX4.TabIndex = 5
        Me.LabelX4.Text = "Junta de Usuarios:"
        '
        'FrmRptEvalTendPorCapacidad
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(985, 444)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.ExpandablePanel2)
        Me.Controls.Add(Me.ExpandablePanel1)
        Me.Name = "FrmRptEvalTendPorCapacidad"
        Me.Text = "Tendencias Por Capacidad"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ExpandablePanel1.ResumeLayout(False)
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExpandablePanel2.ResumeLayout(False)
        CType(Me.Bar3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Bar2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pgb As DevComponents.DotNetBar.ProgressBarItem
    Friend WithEvents lblProgreso As DevComponents.DotNetBar.LabelItem
    Friend WithEvents bgw As System.ComponentModel.BackgroundWorker
    Friend WithEvents bgw1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents ExpandablePanel1 As DevComponents.DotNetBar.ExpandablePanel
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents btnReporte As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnReporte2 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents cmbAnio As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents ExpandablePanel2 As DevComponents.DotNetBar.ExpandablePanel
    Friend WithEvents crViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents Bar3 As DevComponents.DotNetBar.Bar
    Friend WithEvents LabelItem1 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents ProgressBarItem1 As DevComponents.DotNetBar.ProgressBarItem
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents cmbComision As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents cmbJunta As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cmbMeses As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents ControlContainerItem1 As DevComponents.DotNetBar.ControlContainerItem
End Class
