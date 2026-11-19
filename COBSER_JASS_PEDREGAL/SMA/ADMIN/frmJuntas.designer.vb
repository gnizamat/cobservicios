<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmJuntas
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmJuntas))
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.saveScript = New System.Windows.Forms.SaveFileDialog
        Me.pnlJuntas = New DevComponents.DotNetBar.ExpandablePanel
        Me.tvJuntas = New System.Windows.Forms.TreeView
        Me.Bar2 = New DevComponents.DotNetBar.Bar
        Me.btnJuntaNew = New DevComponents.DotNetBar.ButtonItem
        Me.btnJuntaUpd = New DevComponents.DotNetBar.ButtonItem
        Me.btnJuntaDel = New DevComponents.DotNetBar.ButtonItem
        Me.btnRefresh = New DevComponents.DotNetBar.ButtonItem
        Me.btnExportar = New DevComponents.DotNetBar.ButtonItem
        Me.Bar1 = New DevComponents.DotNetBar.Bar
        Me.LabelItem1 = New DevComponents.DotNetBar.LabelItem
        Me.ViewJuntas = New DevComponents.DotNetBar.ButtonItem
        Me.ViewAll = New DevComponents.DotNetBar.ButtonItem
        Me.ViewDistrito = New DevComponents.DotNetBar.ButtonItem
        Me.txtSearchJunta = New DevComponents.DotNetBar.TextBoxItem
        Me.btnBuscarJunta = New DevComponents.DotNetBar.ButtonItem
        Me.ExpandablePanel2 = New DevComponents.DotNetBar.ExpandablePanel
        Me.Bar4 = New DevComponents.DotNetBar.Bar
        Me.btnComisionNew = New DevComponents.DotNetBar.ButtonItem
        Me.btnComisionUpd = New DevComponents.DotNetBar.ButtonItem
        Me.btnComisionDel = New DevComponents.DotNetBar.ButtonItem
        Me.gridComisiones = New DevComponents.DotNetBar.Controls.DataGridViewX
        Me.Bar3 = New DevComponents.DotNetBar.Bar
        Me.txtBuscar = New DevComponents.DotNetBar.TextBoxItem
        Me.bgw = New System.ComponentModel.BackgroundWorker
        Me.pnlJuntas.SuspendLayout()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExpandablePanel2.SuspendLayout()
        CType(Me.Bar4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridComisiones, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "map.png")
        Me.ImageList1.Images.SetKeyName(1, "group.png")
        '
        'saveScript
        '
        '
        'pnlJuntas
        '
        Me.pnlJuntas.CanvasColor = System.Drawing.SystemColors.Control
        Me.pnlJuntas.CollapseDirection = DevComponents.DotNetBar.eCollapseDirection.RightToLeft
        Me.pnlJuntas.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.pnlJuntas.Controls.Add(Me.tvJuntas)
        Me.pnlJuntas.Controls.Add(Me.Bar2)
        Me.pnlJuntas.Controls.Add(Me.Bar1)
        Me.pnlJuntas.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlJuntas.Location = New System.Drawing.Point(0, 0)
        Me.pnlJuntas.Name = "pnlJuntas"
        Me.pnlJuntas.Size = New System.Drawing.Size(269, 459)
        Me.pnlJuntas.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.pnlJuntas.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.pnlJuntas.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.pnlJuntas.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.pnlJuntas.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.pnlJuntas.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
        Me.pnlJuntas.Style.GradientAngle = 90
        Me.pnlJuntas.TabIndex = 13
        Me.pnlJuntas.TitleStyle.Alignment = System.Drawing.StringAlignment.Center
        Me.pnlJuntas.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.pnlJuntas.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.pnlJuntas.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner
        Me.pnlJuntas.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.pnlJuntas.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.pnlJuntas.TitleStyle.GradientAngle = 90
        Me.pnlJuntas.TitleText = "Listado de Junta de Usuarios"
        '
        'tvJuntas
        '
        Me.tvJuntas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvJuntas.FullRowSelect = True
        Me.tvJuntas.HideSelection = False
        Me.tvJuntas.ImageIndex = 1
        Me.tvJuntas.ImageList = Me.ImageList1
        Me.tvJuntas.Location = New System.Drawing.Point(0, 51)
        Me.tvJuntas.Name = "tvJuntas"
        Me.tvJuntas.SelectedImageIndex = 1
        Me.tvJuntas.Size = New System.Drawing.Size(269, 383)
        Me.tvJuntas.TabIndex = 14
        '
        'Bar2
        '
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.DockSide = DevComponents.DotNetBar.eDockSide.Left
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnJuntaNew, Me.btnJuntaUpd, Me.btnJuntaDel, Me.btnRefresh, Me.btnExportar})
        Me.Bar2.Location = New System.Drawing.Point(0, 434)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(269, 25)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Bar2.TabIndex = 2
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'btnJuntaNew
        '
        Me.btnJuntaNew.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.btnJuntaNew.ImagePaddingHorizontal = 8
        Me.btnJuntaNew.Name = "btnJuntaNew"
        Me.btnJuntaNew.Text = "Nuevo"
        '
        'btnJuntaUpd
        '
        Me.btnJuntaUpd.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.btnJuntaUpd.ImagePaddingHorizontal = 8
        Me.btnJuntaUpd.Name = "btnJuntaUpd"
        Me.btnJuntaUpd.Text = "Editar"
        '
        'btnJuntaDel
        '
        Me.btnJuntaDel.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.btnJuntaDel.ImagePaddingHorizontal = 8
        Me.btnJuntaDel.Name = "btnJuntaDel"
        Me.btnJuntaDel.Text = "Eliminar"
        '
        'btnRefresh
        '
        Me.btnRefresh.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.btnRefresh.ImagePaddingHorizontal = 8
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Text = "Refrescar"
        Me.btnRefresh.Tooltip = "Refrescar"
        '
        'btnExportar
        '
        Me.btnExportar.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.btnExportar.ImagePaddingHorizontal = 8
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Text = "Exportar"
        Me.btnExportar.Tooltip = "Exportar Comisiones y Comites"
        '
        'Bar1
        '
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar1.DockSide = DevComponents.DotNetBar.eDockSide.Left
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem1, Me.ViewJuntas, Me.txtSearchJunta, Me.btnBuscarJunta})
        Me.Bar1.Location = New System.Drawing.Point(0, 26)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(269, 25)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Bar1.TabIndex = 1
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'LabelItem1
        '
        Me.LabelItem1.Name = "LabelItem1"
        Me.LabelItem1.Text = "Vista:"
        '
        'ViewJuntas
        '
        Me.ViewJuntas.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.ViewJuntas.ImagePaddingHorizontal = 8
        Me.ViewJuntas.Name = "ViewJuntas"
        Me.ViewJuntas.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ViewAll, Me.ViewDistrito})
        Me.ViewJuntas.Text = "ButtonItem1"
        '
        'ViewAll
        '
        Me.ViewAll.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.ViewAll.ImagePaddingHorizontal = 8
        Me.ViewAll.Name = "ViewAll"
        Me.ViewAll.Text = "No Agrupar"
        '
        'ViewDistrito
        '
        Me.ViewDistrito.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.ViewDistrito.ImagePaddingHorizontal = 8
        Me.ViewDistrito.Name = "ViewDistrito"
        Me.ViewDistrito.Text = "Agrupar por Distrito de Riego"
        '
        'txtSearchJunta
        '
        Me.txtSearchJunta.Caption = "Buscar Junta"
        Me.txtSearchJunta.Name = "txtSearchJunta"
        Me.txtSearchJunta.TextBoxWidth = 140
        Me.txtSearchJunta.WatermarkColor = System.Drawing.SystemColors.GrayText
        '
        'btnBuscarJunta
        '
        Me.btnBuscarJunta.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.btnBuscarJunta.ImagePaddingHorizontal = 8
        Me.btnBuscarJunta.Name = "btnBuscarJunta"
        Me.btnBuscarJunta.Text = "ButtonItem4"
        '
        'ExpandablePanel2
        '
        Me.ExpandablePanel2.CanvasColor = System.Drawing.SystemColors.Control
        Me.ExpandablePanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.ExpandablePanel2.Controls.Add(Me.Bar4)
        Me.ExpandablePanel2.Controls.Add(Me.gridComisiones)
        Me.ExpandablePanel2.Controls.Add(Me.Bar3)
        Me.ExpandablePanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ExpandablePanel2.ExpandButtonVisible = False
        Me.ExpandablePanel2.Location = New System.Drawing.Point(269, 0)
        Me.ExpandablePanel2.Name = "ExpandablePanel2"
        Me.ExpandablePanel2.Size = New System.Drawing.Size(693, 459)
        Me.ExpandablePanel2.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.ExpandablePanel2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.ExpandablePanel2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.ExpandablePanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.ExpandablePanel2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.ExpandablePanel2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
        Me.ExpandablePanel2.Style.GradientAngle = 90
        Me.ExpandablePanel2.TabIndex = 14
        Me.ExpandablePanel2.Text = "Comisión"
        Me.ExpandablePanel2.TitleStyle.Alignment = System.Drawing.StringAlignment.Center
        Me.ExpandablePanel2.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.ExpandablePanel2.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.ExpandablePanel2.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner
        Me.ExpandablePanel2.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.ExpandablePanel2.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.ExpandablePanel2.TitleStyle.GradientAngle = 90
        Me.ExpandablePanel2.TitleText = "Comisión de Regantes"
        '
        'Bar4
        '
        Me.Bar4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar4.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.Bar4.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnComisionNew, Me.btnComisionUpd, Me.btnComisionDel})
        Me.Bar4.Location = New System.Drawing.Point(0, 434)
        Me.Bar4.Name = "Bar4"
        Me.Bar4.Size = New System.Drawing.Size(693, 25)
        Me.Bar4.Stretch = True
        Me.Bar4.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Bar4.TabIndex = 3
        Me.Bar4.TabStop = False
        Me.Bar4.Text = "Bar4"
        '
        'btnComisionNew
        '
        Me.btnComisionNew.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnComisionNew.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.btnComisionNew.ImagePaddingHorizontal = 8
        Me.btnComisionNew.Name = "btnComisionNew"
        Me.btnComisionNew.Text = "Nueva Comisión de R."
        '
        'btnComisionUpd
        '
        Me.btnComisionUpd.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnComisionUpd.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.btnComisionUpd.ImagePaddingHorizontal = 8
        Me.btnComisionUpd.Name = "btnComisionUpd"
        Me.btnComisionUpd.Text = "Editar Comisión de R."
        '
        'btnComisionDel
        '
        Me.btnComisionDel.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnComisionDel.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.btnComisionDel.ImagePaddingHorizontal = 8
        Me.btnComisionDel.Name = "btnComisionDel"
        Me.btnComisionDel.Text = "Eliminar Comisión de R."
        '
        'gridComisiones
        '
        Me.gridComisiones.AllowUserToAddRows = False
        Me.gridComisiones.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gridComisiones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gridComisiones.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle16
        Me.gridComisiones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gridComisiones.DefaultCellStyle = DataGridViewCellStyle17
        Me.gridComisiones.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.gridComisiones.Location = New System.Drawing.Point(6, 55)
        Me.gridComisiones.MultiSelect = False
        Me.gridComisiones.Name = "gridComisiones"
        Me.gridComisiones.ReadOnly = True
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gridComisiones.RowHeadersDefaultCellStyle = DataGridViewCellStyle18
        Me.gridComisiones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridComisiones.Size = New System.Drawing.Size(684, 373)
        Me.gridComisiones.TabIndex = 2
        '
        'Bar3
        '
        Me.Bar3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar3.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.Bar3.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.txtBuscar})
        Me.Bar3.Location = New System.Drawing.Point(0, 26)
        Me.Bar3.Name = "Bar3"
        Me.Bar3.Size = New System.Drawing.Size(693, 23)
        Me.Bar3.Stretch = True
        Me.Bar3.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Bar3.TabIndex = 1
        Me.Bar3.TabStop = False
        Me.Bar3.Text = "Bar3"
        '
        'txtBuscar
        '
        Me.txtBuscar.AlwaysShowCaption = True
        Me.txtBuscar.Caption = "Buscar Comision de Regantes:"
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.TextBoxWidth = 190
        Me.txtBuscar.WatermarkColor = System.Drawing.SystemColors.GrayText
        '
        'frmJuntas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(962, 459)
        Me.Controls.Add(Me.ExpandablePanel2)
        Me.Controls.Add(Me.pnlJuntas)
        Me.DoubleBuffered = True
        Me.Name = "frmJuntas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Juntas de Usuarios"
        Me.pnlJuntas.ResumeLayout(False)
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExpandablePanel2.ResumeLayout(False)
        CType(Me.Bar4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridComisiones, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents saveScript As System.Windows.Forms.SaveFileDialog
    Friend WithEvents pnlJuntas As DevComponents.DotNetBar.ExpandablePanel
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents btnJuntaNew As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnJuntaUpd As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnJuntaDel As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents LabelItem1 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents ViewJuntas As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ViewAll As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ViewDistrito As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents txtSearchJunta As DevComponents.DotNetBar.TextBoxItem
    Friend WithEvents btnBuscarJunta As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents tvJuntas As System.Windows.Forms.TreeView
    Friend WithEvents btnRefresh As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnExportar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ExpandablePanel2 As DevComponents.DotNetBar.ExpandablePanel
    Friend WithEvents Bar4 As DevComponents.DotNetBar.Bar
    Friend WithEvents btnComisionNew As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnComisionUpd As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnComisionDel As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents gridComisiones As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Bar3 As DevComponents.DotNetBar.Bar
    Friend WithEvents txtBuscar As DevComponents.DotNetBar.TextBoxItem
    Friend WithEvents bgw As System.ComponentModel.BackgroundWorker
End Class
