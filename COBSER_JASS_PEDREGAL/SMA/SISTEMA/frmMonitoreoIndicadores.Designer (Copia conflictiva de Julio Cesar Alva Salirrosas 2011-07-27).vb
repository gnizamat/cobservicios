<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMonitoreoIndicadores
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.ExpandablePanel1 = New DevComponents.DotNetBar.ExpandablePanel
        Me.adtvMonitoreo = New DevComponents.AdvTree.AdvTree
        Me.ColumnHeader13 = New DevComponents.AdvTree.ColumnHeader
        Me.ColumnHeader14 = New DevComponents.AdvTree.ColumnHeader
        Me.ColumnHeader15 = New DevComponents.AdvTree.ColumnHeader
        Me.ColumnHeader16 = New DevComponents.AdvTree.ColumnHeader
        Me.ColumnHeader17 = New DevComponents.AdvTree.ColumnHeader
        Me.ColumnHeader18 = New DevComponents.AdvTree.ColumnHeader
        Me.ColumnHeader1 = New DevComponents.AdvTree.ColumnHeader
        Me.ColumnHeader2 = New DevComponents.AdvTree.ColumnHeader
        Me.ColumnHeader3 = New DevComponents.AdvTree.ColumnHeader
        Me.ColumnHeader4 = New DevComponents.AdvTree.ColumnHeader
        Me.ColumnHeader5 = New DevComponents.AdvTree.ColumnHeader
        Me.ColumnHeader6 = New DevComponents.AdvTree.ColumnHeader
        Me.ColumnHeader7 = New DevComponents.AdvTree.ColumnHeader
        Me.ColumnHeader8 = New DevComponents.AdvTree.ColumnHeader
        Me.ColumnHeader9 = New DevComponents.AdvTree.ColumnHeader
        Me.ColumnHeader10 = New DevComponents.AdvTree.ColumnHeader
        Me.ColumnHeader11 = New DevComponents.AdvTree.ColumnHeader
        Me.ColumnHeader20 = New DevComponents.AdvTree.ColumnHeader
        Me.ColumnHeader12 = New DevComponents.AdvTree.ColumnHeader
        Me.ColumnHeader19 = New DevComponents.AdvTree.ColumnHeader
        Me.NodeConnector2 = New DevComponents.AdvTree.NodeConnector
        Me.ElementStyle2 = New DevComponents.DotNetBar.ElementStyle
        Me.Bar2 = New DevComponents.DotNetBar.Bar
        Me.cmbAnio = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX
        Me.cmbComision = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.cmbJunta = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX
        Me.Grid = New DevComponents.DotNetBar.Controls.DataGridViewX
        Me.cmbCapacidad = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX
        Me.ExpandablePanel1.SuspendLayout()
        CType(Me.adtvMonitoreo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Bar2.SuspendLayout()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ExpandablePanel1
        '
        Me.ExpandablePanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ExpandablePanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.ExpandablePanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.ExpandablePanel1.Controls.Add(Me.adtvMonitoreo)
        Me.ExpandablePanel1.ExpandButtonVisible = False
        Me.ExpandablePanel1.Location = New System.Drawing.Point(1, 54)
        Me.ExpandablePanel1.Name = "ExpandablePanel1"
        Me.ExpandablePanel1.Size = New System.Drawing.Size(993, 332)
        Me.ExpandablePanel1.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.ExpandablePanel1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.ExpandablePanel1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.ExpandablePanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.ExpandablePanel1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.ExpandablePanel1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
        Me.ExpandablePanel1.Style.GradientAngle = 90
        Me.ExpandablePanel1.TabIndex = 0
        Me.ExpandablePanel1.TitleStyle.Alignment = System.Drawing.StringAlignment.Center
        Me.ExpandablePanel1.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.ExpandablePanel1.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.ExpandablePanel1.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner
        Me.ExpandablePanel1.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.ExpandablePanel1.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.ExpandablePanel1.TitleStyle.GradientAngle = 90
        Me.ExpandablePanel1.TitleText = "Monitoreo de Indicadores"
        '
        'adtvMonitoreo
        '
        Me.adtvMonitoreo.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline
        Me.adtvMonitoreo.AllowDrop = True
        Me.adtvMonitoreo.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.adtvMonitoreo.BackgroundStyle.Class = "TreeBorderKey"
        Me.adtvMonitoreo.Columns.Add(Me.ColumnHeader13)
        Me.adtvMonitoreo.Columns.Add(Me.ColumnHeader14)
        Me.adtvMonitoreo.Columns.Add(Me.ColumnHeader15)
        Me.adtvMonitoreo.Columns.Add(Me.ColumnHeader16)
        Me.adtvMonitoreo.Columns.Add(Me.ColumnHeader17)
        Me.adtvMonitoreo.Columns.Add(Me.ColumnHeader18)
        Me.adtvMonitoreo.Columns.Add(Me.ColumnHeader1)
        Me.adtvMonitoreo.Columns.Add(Me.ColumnHeader2)
        Me.adtvMonitoreo.Columns.Add(Me.ColumnHeader3)
        Me.adtvMonitoreo.Columns.Add(Me.ColumnHeader4)
        Me.adtvMonitoreo.Columns.Add(Me.ColumnHeader5)
        Me.adtvMonitoreo.Columns.Add(Me.ColumnHeader6)
        Me.adtvMonitoreo.Columns.Add(Me.ColumnHeader7)
        Me.adtvMonitoreo.Columns.Add(Me.ColumnHeader8)
        Me.adtvMonitoreo.Columns.Add(Me.ColumnHeader9)
        Me.adtvMonitoreo.Columns.Add(Me.ColumnHeader10)
        Me.adtvMonitoreo.Columns.Add(Me.ColumnHeader11)
        Me.adtvMonitoreo.Columns.Add(Me.ColumnHeader20)
        Me.adtvMonitoreo.Columns.Add(Me.ColumnHeader12)
        Me.adtvMonitoreo.Columns.Add(Me.ColumnHeader19)
        Me.adtvMonitoreo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.adtvMonitoreo.Location = New System.Drawing.Point(0, 26)
        Me.adtvMonitoreo.Name = "adtvMonitoreo"
        Me.adtvMonitoreo.NodesConnector = Me.NodeConnector2
        Me.adtvMonitoreo.NodeStyle = Me.ElementStyle2
        Me.adtvMonitoreo.PathSeparator = ";"
        Me.adtvMonitoreo.SelectionPerCell = True
        Me.adtvMonitoreo.Size = New System.Drawing.Size(993, 306)
        Me.adtvMonitoreo.Styles.Add(Me.ElementStyle2)
        Me.adtvMonitoreo.SuspendPaint = False
        Me.adtvMonitoreo.TabIndex = 9
        Me.adtvMonitoreo.Text = "AdvTree1"
        '
        'ColumnHeader13
        '
        Me.ColumnHeader13.Name = "ColumnHeader13"
        Me.ColumnHeader13.Text = "Descripcion"
        Me.ColumnHeader13.Width.Absolute = 350
        '
        'ColumnHeader14
        '
        Me.ColumnHeader14.EditorType = DevComponents.AdvTree.eCellEditorType.NumericInteger
        Me.ColumnHeader14.Name = "ColumnHeader14"
        Me.ColumnHeader14.Text = "Anual"
        Me.ColumnHeader14.Visible = False
        Me.ColumnHeader14.Width.Absolute = 40
        '
        'ColumnHeader15
        '
        Me.ColumnHeader15.EditorType = DevComponents.AdvTree.eCellEditorType.NumericInteger
        Me.ColumnHeader15.Name = "ColumnHeader15"
        Me.ColumnHeader15.Text = "Calc"
        Me.ColumnHeader15.Visible = False
        Me.ColumnHeader15.Width.Absolute = 40
        '
        'ColumnHeader16
        '
        Me.ColumnHeader16.EditorType = DevComponents.AdvTree.eCellEditorType.NumericDouble
        Me.ColumnHeader16.ImageAlignment = DevComponents.AdvTree.eColumnImageAlignment.Right
        Me.ColumnHeader16.Name = "ColumnHeader16"
        Me.ColumnHeader16.Text = "L.Base"
        Me.ColumnHeader16.Width.Absolute = 40
        '
        'ColumnHeader17
        '
        Me.ColumnHeader17.EditorType = DevComponents.AdvTree.eCellEditorType.NumericDouble
        Me.ColumnHeader17.ImageAlignment = DevComponents.AdvTree.eColumnImageAlignment.Right
        Me.ColumnHeader17.Name = "ColumnHeader17"
        Me.ColumnHeader17.Text = "Meta"
        Me.ColumnHeader17.Width.Absolute = 40
        '
        'ColumnHeader18
        '
        Me.ColumnHeader18.EditorType = DevComponents.AdvTree.eCellEditorType.NumericDouble
        Me.ColumnHeader18.ImageAlignment = DevComponents.AdvTree.eColumnImageAlignment.Right
        Me.ColumnHeader18.Name = "ColumnHeader18"
        Me.ColumnHeader18.Text = "Peso"
        Me.ColumnHeader18.Width.Absolute = 40
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Name = "ColumnHeader1"
        Me.ColumnHeader1.Text = "Ene"
        Me.ColumnHeader1.Width.Absolute = 50
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Name = "ColumnHeader2"
        Me.ColumnHeader2.Text = "Feb"
        Me.ColumnHeader2.Width.Absolute = 50
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Name = "ColumnHeader3"
        Me.ColumnHeader3.Text = "Mar"
        Me.ColumnHeader3.Width.Absolute = 50
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Name = "ColumnHeader4"
        Me.ColumnHeader4.Text = "Abr"
        Me.ColumnHeader4.Width.Absolute = 50
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Name = "ColumnHeader5"
        Me.ColumnHeader5.Text = "May"
        Me.ColumnHeader5.Width.Absolute = 50
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Name = "ColumnHeader6"
        Me.ColumnHeader6.Text = "Jun"
        Me.ColumnHeader6.Width.Absolute = 50
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Name = "ColumnHeader7"
        Me.ColumnHeader7.Text = "Jul"
        Me.ColumnHeader7.Width.Absolute = 50
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Name = "ColumnHeader8"
        Me.ColumnHeader8.Text = "Ago"
        Me.ColumnHeader8.Width.Absolute = 50
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Name = "ColumnHeader9"
        Me.ColumnHeader9.Text = "Set"
        Me.ColumnHeader9.Width.Absolute = 50
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Name = "ColumnHeader10"
        Me.ColumnHeader10.Text = "Oct"
        Me.ColumnHeader10.Width.Absolute = 50
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Name = "ColumnHeader11"
        Me.ColumnHeader11.Text = "Nov"
        Me.ColumnHeader11.Width.Absolute = 50
        '
        'ColumnHeader20
        '
        Me.ColumnHeader20.Name = "ColumnHeader20"
        Me.ColumnHeader20.Text = "Dic"
        Me.ColumnHeader20.Width.Absolute = 50
        '
        'ColumnHeader12
        '
        Me.ColumnHeader12.Name = "ColumnHeader12"
        Me.ColumnHeader12.Text = "idEstructura"
        Me.ColumnHeader12.Visible = False
        Me.ColumnHeader12.Width.Absolute = 50
        '
        'ColumnHeader19
        '
        Me.ColumnHeader19.Name = "ColumnHeader19"
        Me.ColumnHeader19.Text = "IdPEstru"
        Me.ColumnHeader19.Visible = False
        Me.ColumnHeader19.Width.Absolute = 150
        '
        'NodeConnector2
        '
        Me.NodeConnector2.LineColor = System.Drawing.SystemColors.ControlText
        '
        'ElementStyle2
        '
        Me.ElementStyle2.Name = "ElementStyle2"
        Me.ElementStyle2.TextColor = System.Drawing.SystemColors.ControlText
        '
        'Bar2
        '
        Me.Bar2.Controls.Add(Me.cmbAnio)
        Me.Bar2.Controls.Add(Me.LabelX1)
        Me.Bar2.Controls.Add(Me.cmbComision)
        Me.Bar2.Controls.Add(Me.cmbJunta)
        Me.Bar2.Controls.Add(Me.LabelX3)
        Me.Bar2.Controls.Add(Me.LabelX4)
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar2.Location = New System.Drawing.Point(0, 0)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(992, 25)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Bar2.TabIndex = 2
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'cmbAnio
        '
        Me.cmbAnio.DisplayMember = "Text"
        Me.cmbAnio.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbAnio.FormattingEnabled = True
        Me.cmbAnio.ItemHeight = 17
        Me.cmbAnio.Location = New System.Drawing.Point(761, 1)
        Me.cmbAnio.Name = "cmbAnio"
        Me.cmbAnio.Size = New System.Drawing.Size(108, 23)
        Me.cmbAnio.TabIndex = 10
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        Me.LabelX1.Location = New System.Drawing.Point(680, 1)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(79, 20)
        Me.LabelX1.TabIndex = 9
        Me.LabelX1.Text = "Año Apertura:"
        '
        'cmbComision
        '
        Me.cmbComision.DisplayMember = "Text"
        Me.cmbComision.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbComision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbComision.FormattingEnabled = True
        Me.cmbComision.ItemHeight = 17
        Me.cmbComision.Location = New System.Drawing.Point(473, 0)
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
        Me.LabelX3.Location = New System.Drawing.Point(354, 5)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(113, 15)
        Me.LabelX3.TabIndex = 6
        Me.LabelX3.Text = "Comision Regantes:"
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
        'Grid
        '
        Me.Grid.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Grid.BackgroundColor = System.Drawing.SystemColors.Info
        Me.Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grid.DefaultCellStyle = DataGridViewCellStyle3
        Me.Grid.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.Grid.Location = New System.Drawing.Point(1, 392)
        Me.Grid.Name = "Grid"
        Me.Grid.ReadOnly = True
        Me.Grid.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal
        Me.Grid.Size = New System.Drawing.Size(991, 95)
        Me.Grid.TabIndex = 3
        '
        'cmbCapacidad
        '
        Me.cmbCapacidad.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbCapacidad.DisplayMember = "Text"
        Me.cmbCapacidad.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbCapacidad.FormattingEnabled = True
        Me.cmbCapacidad.ItemHeight = 14
        Me.cmbCapacidad.Location = New System.Drawing.Point(88, 31)
        Me.cmbCapacidad.Name = "cmbCapacidad"
        Me.cmbCapacidad.Size = New System.Drawing.Size(390, 20)
        Me.cmbCapacidad.TabIndex = 7
        '
        'LabelX2
        '
        Me.LabelX2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelX2.Location = New System.Drawing.Point(12, 31)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(70, 20)
        Me.LabelX2.TabIndex = 6
        Me.LabelX2.Text = "Capacidad:"
        '
        'frmMonitoreoIndicadores
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(992, 490)
        Me.Controls.Add(Me.cmbCapacidad)
        Me.Controls.Add(Me.LabelX2)
        Me.Controls.Add(Me.Grid)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.ExpandablePanel1)
        Me.DoubleBuffered = True
        Me.Name = "frmMonitoreoIndicadores"
        Me.Text = "Monitoreo de Indicadores"
        Me.ExpandablePanel1.ResumeLayout(False)
        CType(Me.adtvMonitoreo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Bar2.ResumeLayout(False)
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ExpandablePanel1 As DevComponents.DotNetBar.ExpandablePanel
    Friend WithEvents adtvMonitoreo As DevComponents.AdvTree.AdvTree
    Friend WithEvents ColumnHeader13 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader14 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader15 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader16 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader17 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader18 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader12 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader19 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents NodeConnector2 As DevComponents.AdvTree.NodeConnector
    Friend WithEvents ElementStyle2 As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents ColumnHeader1 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader2 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader3 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader4 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader5 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader6 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader7 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader8 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader9 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader10 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader11 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader20 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents cmbComision As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents cmbJunta As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cmbAnio As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Grid As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents cmbCapacidad As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
End Class
