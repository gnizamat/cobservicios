<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRptIndicadores
    Inherits DevComponents.DotNetBar.Office2007Form

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
        Me.cmbComision = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.cmbJunta = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX
        Me.ExpandablePanel1 = New DevComponents.DotNetBar.ExpandablePanel
        Me.Bar1 = New DevComponents.DotNetBar.Bar
        Me.btnReporte = New DevComponents.DotNetBar.ButtonItem
        Me.cmbMeses = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.cmbCapacidad = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX
        Me.cmbAnio = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX
        Me.ExpandablePanel2 = New DevComponents.DotNetBar.ExpandablePanel
        Me.crViewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.Bar3 = New DevComponents.DotNetBar.Bar
        Me.lblProgreso = New DevComponents.DotNetBar.LabelItem
        Me.pgb = New DevComponents.DotNetBar.ProgressBarItem
        Me.bgw = New System.ComponentModel.BackgroundWorker
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Bar2.SuspendLayout()
        Me.ExpandablePanel1.SuspendLayout()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExpandablePanel2.SuspendLayout()
        CType(Me.Bar3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bar2
        '
        Me.Bar2.Controls.Add(Me.cmbComision)
        Me.Bar2.Controls.Add(Me.cmbJunta)
        Me.Bar2.Controls.Add(Me.LabelX3)
        Me.Bar2.Controls.Add(Me.LabelX4)
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar2.Location = New System.Drawing.Point(0, 0)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(808, 25)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Bar2.TabIndex = 2
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
        Me.cmbComision.Location = New System.Drawing.Point(574, 0)
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
        Me.LabelX3.Location = New System.Drawing.Point(455, 5)
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
        'ExpandablePanel1
        '
        Me.ExpandablePanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.ExpandablePanel1.CollapseDirection = DevComponents.DotNetBar.eCollapseDirection.RightToLeft
        Me.ExpandablePanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.ExpandablePanel1.Controls.Add(Me.Bar1)
        Me.ExpandablePanel1.Controls.Add(Me.cmbMeses)
        Me.ExpandablePanel1.Controls.Add(Me.cmbCapacidad)
        Me.ExpandablePanel1.Controls.Add(Me.LabelX5)
        Me.ExpandablePanel1.Controls.Add(Me.LabelX2)
        Me.ExpandablePanel1.Controls.Add(Me.cmbAnio)
        Me.ExpandablePanel1.Controls.Add(Me.LabelX1)
        Me.ExpandablePanel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.ExpandablePanel1.Location = New System.Drawing.Point(0, 25)
        Me.ExpandablePanel1.Name = "ExpandablePanel1"
        Me.ExpandablePanel1.Size = New System.Drawing.Size(303, 419)
        Me.ExpandablePanel1.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.ExpandablePanel1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.ExpandablePanel1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.ExpandablePanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.ExpandablePanel1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.ExpandablePanel1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
        Me.ExpandablePanel1.Style.GradientAngle = 90
        Me.ExpandablePanel1.TabIndex = 3
        Me.ExpandablePanel1.TitleStyle.Alignment = System.Drawing.StringAlignment.Center
        Me.ExpandablePanel1.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.ExpandablePanel1.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.ExpandablePanel1.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner
        Me.ExpandablePanel1.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.ExpandablePanel1.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.ExpandablePanel1.TitleStyle.GradientAngle = 90
        Me.ExpandablePanel1.TitleText = "Parametros"
        '
        'Bar1
        '
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.DockSide = DevComponents.DotNetBar.eDockSide.Left
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnReporte})
        Me.Bar1.Location = New System.Drawing.Point(0, 394)
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
        Me.btnReporte.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.btnReporte.ImagePaddingHorizontal = 8
        Me.btnReporte.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.btnReporte.Name = "btnReporte"
        Me.btnReporte.Text = "Generar Reporte"
        '
        'cmbMeses
        '
        Me.cmbMeses.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbMeses.DisplayMember = "Text"
        Me.cmbMeses.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbMeses.FormattingEnabled = True
        Me.cmbMeses.ItemHeight = 14
        Me.cmbMeses.Location = New System.Drawing.Point(88, 111)
        Me.cmbMeses.Name = "cmbMeses"
        Me.cmbMeses.Size = New System.Drawing.Size(185, 20)
        Me.cmbMeses.TabIndex = 10
        '
        'cmbCapacidad
        '
        Me.cmbCapacidad.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbCapacidad.DisplayMember = "Text"
        Me.cmbCapacidad.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbCapacidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCapacidad.FormattingEnabled = True
        Me.cmbCapacidad.ItemHeight = 14
        Me.cmbCapacidad.Location = New System.Drawing.Point(88, 73)
        Me.cmbCapacidad.Name = "cmbCapacidad"
        Me.cmbCapacidad.Size = New System.Drawing.Size(185, 20)
        Me.cmbCapacidad.TabIndex = 9
        '
        'LabelX5
        '
        Me.LabelX5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelX5.Location = New System.Drawing.Point(12, 73)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(66, 20)
        Me.LabelX5.TabIndex = 8
        Me.LabelX5.Text = "Capacidad:"
        '
        'LabelX2
        '
        Me.LabelX2.Location = New System.Drawing.Point(12, 112)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(70, 20)
        Me.LabelX2.TabIndex = 7
        Me.LabelX2.Text = "Mes:"
        '
        'cmbAnio
        '
        Me.cmbAnio.DisplayMember = "Text"
        Me.cmbAnio.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbAnio.FormattingEnabled = True
        Me.cmbAnio.ItemHeight = 14
        Me.cmbAnio.Location = New System.Drawing.Point(88, 37)
        Me.cmbAnio.Name = "cmbAnio"
        Me.cmbAnio.Size = New System.Drawing.Size(185, 20)
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
        'ExpandablePanel2
        '
        Me.ExpandablePanel2.CanvasColor = System.Drawing.SystemColors.Control
        Me.ExpandablePanel2.CollapseDirection = DevComponents.DotNetBar.eCollapseDirection.RightToLeft
        Me.ExpandablePanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.ExpandablePanel2.Controls.Add(Me.crViewer)
        Me.ExpandablePanel2.Controls.Add(Me.Bar3)
        Me.ExpandablePanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ExpandablePanel2.ExpandButtonVisible = False
        Me.ExpandablePanel2.Location = New System.Drawing.Point(303, 25)
        Me.ExpandablePanel2.Name = "ExpandablePanel2"
        Me.ExpandablePanel2.Size = New System.Drawing.Size(505, 419)
        Me.ExpandablePanel2.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.ExpandablePanel2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.ExpandablePanel2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.ExpandablePanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.ExpandablePanel2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.ExpandablePanel2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
        Me.ExpandablePanel2.Style.GradientAngle = 90
        Me.ExpandablePanel2.TabIndex = 4
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
        Me.crViewer.Size = New System.Drawing.Size(505, 374)
        Me.crViewer.TabIndex = 178
        Me.crViewer.ViewTimeSelectionFormula = ""
        '
        'Bar3
        '
        Me.Bar3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar3.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.Bar3.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.lblProgreso, Me.pgb})
        Me.Bar3.Location = New System.Drawing.Point(0, 400)
        Me.Bar3.Name = "Bar3"
        Me.Bar3.Size = New System.Drawing.Size(505, 19)
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
        'bgw
        '
        Me.bgw.WorkerReportsProgress = True
        '
        'frmRptIndicadores
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(808, 444)
        Me.Controls.Add(Me.ExpandablePanel2)
        Me.Controls.Add(Me.ExpandablePanel1)
        Me.Controls.Add(Me.Bar2)
        Me.DoubleBuffered = True
        Me.Name = "frmRptIndicadores"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reportes"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Bar2.ResumeLayout(False)
        Me.ExpandablePanel1.ResumeLayout(False)
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExpandablePanel2.ResumeLayout(False)
        CType(Me.Bar3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents cmbComision As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents cmbJunta As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents ExpandablePanel1 As DevComponents.DotNetBar.ExpandablePanel
    Friend WithEvents ExpandablePanel2 As DevComponents.DotNetBar.ExpandablePanel
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cmbAnio As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cmbMeses As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents cmbCapacidad As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents btnReporte As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Bar3 As DevComponents.DotNetBar.Bar
    Friend WithEvents lblProgreso As DevComponents.DotNetBar.LabelItem
    Friend WithEvents pgb As DevComponents.DotNetBar.ProgressBarItem
    Friend WithEvents bgw As System.ComponentModel.BackgroundWorker
    Friend WithEvents crViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
