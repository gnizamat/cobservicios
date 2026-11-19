<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRpt_Lecturas
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
        Me.crViewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.Bar2 = New DevComponents.DotNetBar.Bar
        Me.cmbJunta = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX
        Me.ExpandablePanel1 = New DevComponents.DotNetBar.ExpandablePanel
        Me.cmbCPoblado = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.LabelX25 = New DevComponents.DotNetBar.LabelX
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX
        Me.cmbEstructura = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.LabelX18 = New DevComponents.DotNetBar.LabelX
        Me.cmbMes = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.ComboItem6 = New DevComponents.Editors.ComboItem
        Me.ComboItem7 = New DevComponents.Editors.ComboItem
        Me.cmbAños = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX
        Me.cmbCalles = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX
        Me.LabelX8 = New DevComponents.DotNetBar.LabelX
        Me.cmbReporte = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.ComboItem4 = New DevComponents.Editors.ComboItem
        Me.ComboItem1 = New DevComponents.Editors.ComboItem
        Me.ComboItem2 = New DevComponents.Editors.ComboItem
        Me.ComboItem3 = New DevComponents.Editors.ComboItem
        Me.ComboItem5 = New DevComponents.Editors.ComboItem
        Me.Bar1 = New DevComponents.DotNetBar.Bar
        Me.btnReporte = New DevComponents.DotNetBar.ButtonItem
        Me.Bar3 = New DevComponents.DotNetBar.Bar
        Me.lblProgreso = New DevComponents.DotNetBar.LabelItem
        Me.pgb = New DevComponents.DotNetBar.ProgressBarItem
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Bar2.SuspendLayout()
        Me.ExpandablePanel1.SuspendLayout()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'crViewer
        '
        Me.crViewer.ActiveViewIndex = -1
        Me.crViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crViewer.DisplayGroupTree = False
        Me.crViewer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.crViewer.Location = New System.Drawing.Point(283, 25)
        Me.crViewer.Name = "crViewer"
        Me.crViewer.SelectionFormula = ""
        Me.crViewer.Size = New System.Drawing.Size(652, 390)
        Me.crViewer.TabIndex = 186
        Me.crViewer.ViewTimeSelectionFormula = ""
        '
        'Bar2
        '
        Me.Bar2.Controls.Add(Me.cmbJunta)
        Me.Bar2.Controls.Add(Me.LabelX4)
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar2.Location = New System.Drawing.Point(283, 0)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(652, 25)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Bar2.TabIndex = 183
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
        Me.LabelX4.Text = "AGUAS:"
        '
        'ExpandablePanel1
        '
        Me.ExpandablePanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.ExpandablePanel1.CollapseDirection = DevComponents.DotNetBar.eCollapseDirection.RightToLeft
        Me.ExpandablePanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.ExpandablePanel1.Controls.Add(Me.cmbCPoblado)
        Me.ExpandablePanel1.Controls.Add(Me.LabelX25)
        Me.ExpandablePanel1.Controls.Add(Me.LabelX3)
        Me.ExpandablePanel1.Controls.Add(Me.cmbEstructura)
        Me.ExpandablePanel1.Controls.Add(Me.LabelX18)
        Me.ExpandablePanel1.Controls.Add(Me.cmbMes)
        Me.ExpandablePanel1.Controls.Add(Me.cmbAños)
        Me.ExpandablePanel1.Controls.Add(Me.LabelX1)
        Me.ExpandablePanel1.Controls.Add(Me.cmbCalles)
        Me.ExpandablePanel1.Controls.Add(Me.LabelX2)
        Me.ExpandablePanel1.Controls.Add(Me.LabelX8)
        Me.ExpandablePanel1.Controls.Add(Me.cmbReporte)
        Me.ExpandablePanel1.Controls.Add(Me.Bar1)
        Me.ExpandablePanel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.ExpandablePanel1.Location = New System.Drawing.Point(0, 0)
        Me.ExpandablePanel1.Name = "ExpandablePanel1"
        Me.ExpandablePanel1.Size = New System.Drawing.Size(283, 415)
        Me.ExpandablePanel1.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.ExpandablePanel1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.ExpandablePanel1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.ExpandablePanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.ExpandablePanel1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.ExpandablePanel1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
        Me.ExpandablePanel1.Style.GradientAngle = 90
        Me.ExpandablePanel1.TabIndex = 184
        Me.ExpandablePanel1.TitleStyle.Alignment = System.Drawing.StringAlignment.Center
        Me.ExpandablePanel1.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.ExpandablePanel1.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.ExpandablePanel1.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner
        Me.ExpandablePanel1.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.ExpandablePanel1.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.ExpandablePanel1.TitleStyle.GradientAngle = 90
        Me.ExpandablePanel1.TitleText = "Parametros"
        '
        'cmbCPoblado
        '
        Me.cmbCPoblado.DisplayMember = "Text"
        Me.cmbCPoblado.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbCPoblado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCPoblado.FormattingEnabled = True
        Me.cmbCPoblado.ItemHeight = 15
        Me.cmbCPoblado.Location = New System.Drawing.Point(12, 101)
        Me.cmbCPoblado.Name = "cmbCPoblado"
        Me.cmbCPoblado.Size = New System.Drawing.Size(259, 21)
        Me.cmbCPoblado.TabIndex = 209
        '
        'LabelX25
        '
        Me.LabelX25.AutoSize = True
        Me.LabelX25.BackColor = System.Drawing.Color.Transparent
        Me.LabelX25.Location = New System.Drawing.Point(12, 83)
        Me.LabelX25.Name = "LabelX25"
        Me.LabelX25.Size = New System.Drawing.Size(60, 15)
        Me.LabelX25.TabIndex = 208
        Me.LabelX25.Text = "C. Poblado:"
        '
        'LabelX3
        '
        Me.LabelX3.AutoSize = True
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        Me.LabelX3.Location = New System.Drawing.Point(12, 179)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(107, 15)
        Me.LabelX3.TabIndex = 207
        Me.LabelX3.Text = "Estacion de Bombeo:"
        '
        'cmbEstructura
        '
        Me.cmbEstructura.DisplayMember = "Text"
        Me.cmbEstructura.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbEstructura.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstructura.FormattingEnabled = True
        Me.cmbEstructura.ItemHeight = 14
        Me.cmbEstructura.Location = New System.Drawing.Point(12, 200)
        Me.cmbEstructura.Name = "cmbEstructura"
        Me.cmbEstructura.Size = New System.Drawing.Size(259, 20)
        Me.cmbEstructura.TabIndex = 206
        '
        'LabelX18
        '
        Me.LabelX18.AutoSize = True
        Me.LabelX18.BackColor = System.Drawing.Color.Transparent
        Me.LabelX18.Location = New System.Drawing.Point(197, 235)
        Me.LabelX18.Name = "LabelX18"
        Me.LabelX18.Size = New System.Drawing.Size(26, 15)
        Me.LabelX18.TabIndex = 188
        Me.LabelX18.Text = "Mes:"
        '
        'cmbMes
        '
        Me.cmbMes.DisplayMember = "Text"
        Me.cmbMes.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMes.FormattingEnabled = True
        Me.cmbMes.ItemHeight = 14
        Me.cmbMes.Items.AddRange(New Object() {Me.ComboItem6, Me.ComboItem7})
        Me.cmbMes.Location = New System.Drawing.Point(185, 258)
        Me.cmbMes.Name = "cmbMes"
        Me.cmbMes.Size = New System.Drawing.Size(86, 20)
        Me.cmbMes.TabIndex = 187
        '
        'ComboItem6
        '
        Me.ComboItem6.Text = "I"
        Me.ComboItem6.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'ComboItem7
        '
        Me.ComboItem7.Text = "II"
        Me.ComboItem7.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'cmbAños
        '
        Me.cmbAños.DisplayMember = "Text"
        Me.cmbAños.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbAños.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAños.FormattingEnabled = True
        Me.cmbAños.ItemHeight = 15
        Me.cmbAños.Location = New System.Drawing.Point(12, 256)
        Me.cmbAños.Name = "cmbAños"
        Me.cmbAños.Size = New System.Drawing.Size(99, 21)
        Me.cmbAños.TabIndex = 184
        '
        'LabelX1
        '
        Me.LabelX1.AutoSize = True
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        Me.LabelX1.Location = New System.Drawing.Point(12, 235)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(55, 15)
        Me.LabelX1.TabIndex = 183
        Me.LabelX1.Text = "Año Activo"
        '
        'cmbCalles
        '
        Me.cmbCalles.DisplayMember = "Text"
        Me.cmbCalles.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbCalles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCalles.FormattingEnabled = True
        Me.cmbCalles.ItemHeight = 15
        Me.cmbCalles.Location = New System.Drawing.Point(12, 153)
        Me.cmbCalles.Name = "cmbCalles"
        Me.cmbCalles.Size = New System.Drawing.Size(259, 21)
        Me.cmbCalles.TabIndex = 182
        '
        'LabelX2
        '
        Me.LabelX2.AutoSize = True
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        Me.LabelX2.Location = New System.Drawing.Point(12, 132)
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
        Me.cmbReporte.Items.AddRange(New Object() {Me.ComboItem4, Me.ComboItem1, Me.ComboItem2, Me.ComboItem3, Me.ComboItem5})
        Me.cmbReporte.Location = New System.Drawing.Point(12, 57)
        Me.cmbReporte.Name = "cmbReporte"
        Me.cmbReporte.Size = New System.Drawing.Size(259, 20)
        Me.cmbReporte.TabIndex = 179
        '
        'ComboItem4
        '
        Me.ComboItem4.Text = "1. Reporte Toma de Lecturas"
        '
        'ComboItem1
        '
        Me.ComboItem1.Text = "2. Reporte de Volumenes Consumidos"
        '
        'ComboItem2
        '
        Me.ComboItem2.Text = "3.  Consumo Mensual del predio"
        '
        'ComboItem3
        '
        Me.ComboItem3.Text = "4. Reporte de Estacion de Bombeo"
        '
        'ComboItem5
        '
        Me.ComboItem5.Text = "5. Listado Detallado de Meedidores"
        '
        'Bar1
        '
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.DockSide = DevComponents.DotNetBar.eDockSide.Left
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnReporte})
        Me.Bar1.Location = New System.Drawing.Point(0, 390)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(283, 25)
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
        Me.Bar3.Location = New System.Drawing.Point(0, 415)
        Me.Bar3.Name = "Bar3"
        Me.Bar3.Size = New System.Drawing.Size(935, 19)
        Me.Bar3.Stretch = True
        Me.Bar3.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Bar3.TabIndex = 185
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
        'frmRpt_Lecturas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(935, 434)
        Me.Controls.Add(Me.crViewer)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.ExpandablePanel1)
        Me.Controls.Add(Me.Bar3)
        Me.Name = "frmRpt_Lecturas"
        Me.Text = "frmRpt_Lecturas"
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Bar2.ResumeLayout(False)
        Me.ExpandablePanel1.ResumeLayout(False)
        Me.ExpandablePanel1.PerformLayout()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents crViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents cmbJunta As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents ExpandablePanel1 As DevComponents.DotNetBar.ExpandablePanel
    Friend WithEvents cmbAños As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cmbCalles As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX8 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cmbReporte As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents ComboItem4 As DevComponents.Editors.ComboItem
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents btnReporte As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Bar3 As DevComponents.DotNetBar.Bar
    Friend WithEvents lblProgreso As DevComponents.DotNetBar.LabelItem
    Friend WithEvents pgb As DevComponents.DotNetBar.ProgressBarItem
    Friend WithEvents LabelX18 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cmbMes As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents ComboItem6 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem7 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem1 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem2 As DevComponents.Editors.ComboItem
    Friend WithEvents cmbEstructura As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents ComboItem3 As DevComponents.Editors.ComboItem
    Friend WithEvents cmbCPoblado As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX25 As DevComponents.DotNetBar.LabelX
    Friend WithEvents ComboItem5 As DevComponents.Editors.ComboItem
End Class
