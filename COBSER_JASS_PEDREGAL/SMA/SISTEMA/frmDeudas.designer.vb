<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDeudas
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
        Me.ExpandablePanel2 = New DevComponents.DotNetBar.ExpandablePanel
        Me.Bar3 = New DevComponents.DotNetBar.Bar
        Me.lblTotalRegistros = New DevComponents.DotNetBar.LabelX
        Me.btnCalcularDeuda = New DevComponents.DotNetBar.ButtonItem
        Me.pgb = New DevComponents.DotNetBar.ProgressBarItem
        Me.tvPredios = New DevComponents.AdvTree.AdvTree
        Me.ColumnHeader1 = New DevComponents.AdvTree.ColumnHeader
        Me.ColumnHeader2 = New DevComponents.AdvTree.ColumnHeader
        Me.ColumnHeader3 = New DevComponents.AdvTree.ColumnHeader
        Me.ColumnHeader4 = New DevComponents.AdvTree.ColumnHeader
        Me.ColumnHeader5 = New DevComponents.AdvTree.ColumnHeader
        Me.ColumnHeader6 = New DevComponents.AdvTree.ColumnHeader
        Me.ColumnHeader7 = New DevComponents.AdvTree.ColumnHeader
        Me.ColumnHeader8 = New DevComponents.AdvTree.ColumnHeader
        Me.ColumnHeader9 = New DevComponents.AdvTree.ColumnHeader
        Me.NodeConnector1 = New DevComponents.AdvTree.NodeConnector
        Me.ElementStyle1 = New DevComponents.DotNetBar.ElementStyle
        Me.ExpandablePanel2.SuspendLayout()
        CType(Me.Bar3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Bar3.SuspendLayout()
        CType(Me.tvPredios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ExpandablePanel2
        '
        Me.ExpandablePanel2.CanvasColor = System.Drawing.SystemColors.Control
        Me.ExpandablePanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.ExpandablePanel2.Controls.Add(Me.Bar3)
        Me.ExpandablePanel2.Controls.Add(Me.tvPredios)
        Me.ExpandablePanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ExpandablePanel2.ExpandButtonVisible = False
        Me.ExpandablePanel2.Location = New System.Drawing.Point(0, 0)
        Me.ExpandablePanel2.Name = "ExpandablePanel2"
        Me.ExpandablePanel2.Size = New System.Drawing.Size(803, 430)
        Me.ExpandablePanel2.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.ExpandablePanel2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.ExpandablePanel2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.ExpandablePanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.ExpandablePanel2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.ExpandablePanel2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
        Me.ExpandablePanel2.Style.GradientAngle = 90
        Me.ExpandablePanel2.TabIndex = 131
        Me.ExpandablePanel2.TitleStyle.Alignment = System.Drawing.StringAlignment.Center
        Me.ExpandablePanel2.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.ExpandablePanel2.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.ExpandablePanel2.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner
        Me.ExpandablePanel2.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.ExpandablePanel2.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.ExpandablePanel2.TitleStyle.GradientAngle = 90
        Me.ExpandablePanel2.TitleText = "Listado de Predios con Deuda"
        '
        'Bar3
        '
        Me.Bar3.Controls.Add(Me.lblTotalRegistros)
        Me.Bar3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar3.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.Bar3.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnCalcularDeuda, Me.pgb})
        Me.Bar3.Location = New System.Drawing.Point(0, 405)
        Me.Bar3.Name = "Bar3"
        Me.Bar3.Size = New System.Drawing.Size(803, 25)
        Me.Bar3.Stretch = True
        Me.Bar3.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Bar3.TabIndex = 182
        Me.Bar3.TabStop = False
        Me.Bar3.Text = "Bar3"
        '
        'lblTotalRegistros
        '
        Me.lblTotalRegistros.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotalRegistros.BackColor = System.Drawing.Color.Transparent
        Me.lblTotalRegistros.Location = New System.Drawing.Point(26496, 1055)
        Me.lblTotalRegistros.Name = "lblTotalRegistros"
        Me.lblTotalRegistros.Size = New System.Drawing.Size(227, 19)
        Me.lblTotalRegistros.TabIndex = 0
        Me.lblTotalRegistros.Text = "-"
        Me.lblTotalRegistros.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'btnCalcularDeuda
        '
        Me.btnCalcularDeuda.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnCalcularDeuda.Image = Global.COBSER.My.Resources.Resources.cross
        Me.btnCalcularDeuda.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.btnCalcularDeuda.ImagePaddingHorizontal = 8
        Me.btnCalcularDeuda.Name = "btnCalcularDeuda"
        Me.btnCalcularDeuda.Text = "Cerrar"
        '
        'pgb
        '
        Me.pgb.ChunkGradientAngle = 0.0!
        Me.pgb.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.pgb.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
        Me.pgb.Name = "pgb"
        Me.pgb.RecentlyUsed = False
        '
        'tvPredios
        '
        Me.tvPredios.AllowDrop = True
        Me.tvPredios.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tvPredios.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.tvPredios.BackgroundStyle.Class = "TreeBorderKey"
        Me.tvPredios.CellEdit = True
        Me.tvPredios.Columns.Add(Me.ColumnHeader1)
        Me.tvPredios.Columns.Add(Me.ColumnHeader2)
        Me.tvPredios.Columns.Add(Me.ColumnHeader3)
        Me.tvPredios.Columns.Add(Me.ColumnHeader4)
        Me.tvPredios.Columns.Add(Me.ColumnHeader5)
        Me.tvPredios.Columns.Add(Me.ColumnHeader6)
        Me.tvPredios.Columns.Add(Me.ColumnHeader7)
        Me.tvPredios.Columns.Add(Me.ColumnHeader8)
        Me.tvPredios.Columns.Add(Me.ColumnHeader9)
        Me.tvPredios.DragDropEnabled = False
        Me.tvPredios.GridRowLines = True
        Me.tvPredios.HotTracking = True
        Me.tvPredios.Location = New System.Drawing.Point(10, 33)
        Me.tvPredios.Name = "tvPredios"
        Me.tvPredios.NodesConnector = Me.NodeConnector1
        Me.tvPredios.NodeStyle = Me.ElementStyle1
        Me.tvPredios.PathSeparator = ";"
        Me.tvPredios.SelectionBoxStyle = DevComponents.AdvTree.eSelectionStyle.FullRowSelect
        Me.tvPredios.Size = New System.Drawing.Size(784, 350)
        Me.tvPredios.Styles.Add(Me.ElementStyle1)
        Me.tvPredios.SuspendPaint = False
        Me.tvPredios.TabIndex = 181
        Me.tvPredios.Text = "tvListado"
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Name = "ColumnHeader1"
        Me.ColumnHeader1.Text = "Nro"
        Me.ColumnHeader1.Width.Absolute = 60
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Name = "ColumnHeader2"
        Me.ColumnHeader2.Text = "Predio"
        Me.ColumnHeader2.Width.Absolute = 120
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Name = "ColumnHeader3"
        Me.ColumnHeader3.Text = "Usuario"
        Me.ColumnHeader3.Width.Absolute = 120
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Name = "ColumnHeader4"
        Me.ColumnHeader4.Text = "Monto"
        Me.ColumnHeader4.Width.Absolute = 60
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Name = "ColumnHeader5"
        Me.ColumnHeader5.Text = "Año"
        Me.ColumnHeader5.Width.Absolute = 60
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Name = "ColumnHeader6"
        Me.ColumnHeader6.Text = "Mes"
        Me.ColumnHeader6.Width.Absolute = 60
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Name = "ColumnHeader7"
        Me.ColumnHeader7.Text = "Concepto"
        Me.ColumnHeader7.Width.Absolute = 60
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Name = "ColumnHeader8"
        Me.ColumnHeader8.Text = "Fecha"
        Me.ColumnHeader8.Width.Absolute = 60
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Name = "ColumnHeader9"
        Me.ColumnHeader9.Text = "Estado"
        Me.ColumnHeader9.Width.Absolute = 150
        '
        'NodeConnector1
        '
        Me.NodeConnector1.LineColor = System.Drawing.SystemColors.ControlText
        '
        'ElementStyle1
        '
        Me.ElementStyle1.Name = "ElementStyle1"
        Me.ElementStyle1.TextColor = System.Drawing.SystemColors.ControlText
        '
        'frmDeudas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(803, 430)
        Me.Controls.Add(Me.ExpandablePanel2)
        Me.DoubleBuffered = True
        Me.Name = "frmDeudas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frmDeudas"
        Me.ExpandablePanel2.ResumeLayout(False)
        CType(Me.Bar3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Bar3.ResumeLayout(False)
        CType(Me.tvPredios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ExpandablePanel2 As DevComponents.DotNetBar.ExpandablePanel
    Friend WithEvents Bar3 As DevComponents.DotNetBar.Bar
    Friend WithEvents lblTotalRegistros As DevComponents.DotNetBar.LabelX
    Friend WithEvents btnCalcularDeuda As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents pgb As DevComponents.DotNetBar.ProgressBarItem
    Friend WithEvents tvPredios As DevComponents.AdvTree.AdvTree
    Friend WithEvents ColumnHeader1 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader2 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader3 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader4 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader5 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader6 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader7 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader8 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader9 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents NodeConnector1 As DevComponents.AdvTree.NodeConnector
    Friend WithEvents ElementStyle1 As DevComponents.DotNetBar.ElementStyle
End Class
