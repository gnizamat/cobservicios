<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTarifasAnios
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.ControlContainerItem3 = New DevComponents.DotNetBar.ControlContainerItem
        Me.ControlContainerItem4 = New DevComponents.DotNetBar.ControlContainerItem
        Me.panelHistorial = New DevComponents.DotNetBar.ExpandablePanel
        Me.dgTarifas = New DevComponents.DotNetBar.Controls.DataGridViewX
        Me.Bar1 = New DevComponents.DotNetBar.Bar
        Me.btnTarifaNew = New DevComponents.DotNetBar.ButtonItem
        Me.btnTarifaUpd = New DevComponents.DotNetBar.ButtonItem
        Me.ButtonItem3 = New DevComponents.DotNetBar.ButtonItem
        Me.btnDistribucion = New DevComponents.DotNetBar.ButtonItem
        Me.btnActivar = New DevComponents.DotNetBar.ButtonItem
        Me.btnImprimir = New DevComponents.DotNetBar.ButtonItem
        Me.btnSalir = New DevComponents.DotNetBar.ButtonItem
        Me.ControlContainerItem2 = New DevComponents.DotNetBar.ControlContainerItem
        Me.cmbJunta = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX
        Me.Bar2 = New DevComponents.DotNetBar.Bar
        Me.cmbJunta1 = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.panelHistorial.SuspendLayout()
        CType(Me.dgTarifas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Bar2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ControlContainerItem3
        '
        Me.ControlContainerItem3.AllowItemResize = False
        Me.ControlContainerItem3.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
        Me.ControlContainerItem3.Name = "ControlContainerItem3"
        '
        'ControlContainerItem4
        '
        Me.ControlContainerItem4.AllowItemResize = False
        Me.ControlContainerItem4.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
        Me.ControlContainerItem4.Name = "ControlContainerItem4"
        '
        'panelHistorial
        '
        Me.panelHistorial.CanvasColor = System.Drawing.SystemColors.Control
        Me.panelHistorial.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.panelHistorial.Controls.Add(Me.dgTarifas)
        Me.panelHistorial.Controls.Add(Me.Bar1)
        Me.panelHistorial.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panelHistorial.ExpandButtonVisible = False
        Me.panelHistorial.Location = New System.Drawing.Point(0, 0)
        Me.panelHistorial.Name = "panelHistorial"
        Me.panelHistorial.Size = New System.Drawing.Size(696, 343)
        Me.panelHistorial.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.panelHistorial.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.panelHistorial.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.panelHistorial.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.panelHistorial.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.panelHistorial.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
        Me.panelHistorial.Style.GradientAngle = 90
        Me.panelHistorial.TabIndex = 9
        Me.panelHistorial.TitleStyle.Alignment = System.Drawing.StringAlignment.Center
        Me.panelHistorial.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.panelHistorial.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.panelHistorial.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner
        Me.panelHistorial.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.panelHistorial.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.panelHistorial.TitleStyle.GradientAngle = 90
        Me.panelHistorial.TitleText = "Historial Tarifas"
        '
        'dgTarifas
        '
        Me.dgTarifas.AllowUserToAddRows = False
        Me.dgTarifas.AllowUserToDeleteRows = False
        Me.dgTarifas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgTarifas.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgTarifas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgTarifas.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgTarifas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgTarifas.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgTarifas.Location = New System.Drawing.Point(0, 26)
        Me.dgTarifas.Name = "dgTarifas"
        Me.dgTarifas.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgTarifas.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgTarifas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgTarifas.Size = New System.Drawing.Size(696, 292)
        Me.dgTarifas.TabIndex = 1
        '
        'Bar1
        '
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnTarifaNew, Me.btnTarifaUpd, Me.ButtonItem3, Me.btnDistribucion, Me.btnActivar, Me.btnImprimir, Me.btnSalir})
        Me.Bar1.Location = New System.Drawing.Point(0, 318)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(696, 25)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Bar1.TabIndex = 2
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'btnTarifaNew
        '
        Me.btnTarifaNew.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnTarifaNew.Image = Global.COBSER.My.Resources.Resources.add
        Me.btnTarifaNew.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.btnTarifaNew.ImagePaddingHorizontal = 8
        Me.btnTarifaNew.Name = "btnTarifaNew"
        Me.btnTarifaNew.Text = "Nueva"
        '
        'btnTarifaUpd
        '
        Me.btnTarifaUpd.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnTarifaUpd.Image = Global.COBSER.My.Resources.Resources.pencil
        Me.btnTarifaUpd.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.btnTarifaUpd.ImagePaddingHorizontal = 8
        Me.btnTarifaUpd.Name = "btnTarifaUpd"
        Me.btnTarifaUpd.Text = "Editar"
        '
        'ButtonItem3
        '
        Me.ButtonItem3.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem3.Image = Global.COBSER.My.Resources.Resources.delete
        Me.ButtonItem3.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.ButtonItem3.ImagePaddingHorizontal = 8
        Me.ButtonItem3.Name = "ButtonItem3"
        Me.ButtonItem3.Text = "Eliminar"
        '
        'btnDistribucion
        '
        Me.btnDistribucion.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnDistribucion.Image = Global.COBSER.My.Resources.Resources.coins
        Me.btnDistribucion.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.btnDistribucion.ImagePaddingHorizontal = 8
        Me.btnDistribucion.Name = "btnDistribucion"
        Me.btnDistribucion.Text = "Costos Tarifa"
        '
        'btnActivar
        '
        Me.btnActivar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnActivar.Image = Global.COBSER.My.Resources.Resources.accept
        Me.btnActivar.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.btnActivar.ImagePaddingHorizontal = 8
        Me.btnActivar.Name = "btnActivar"
        Me.btnActivar.Text = "Marcar como Tarifa Activa"
        '
        'btnImprimir
        '
        Me.btnImprimir.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnImprimir.Image = Global.COBSER.My.Resources.Resources.printer
        Me.btnImprimir.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.btnImprimir.ImagePaddingHorizontal = 8
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Text = "Imprimir"
        '
        'btnSalir
        '
        Me.btnSalir.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnSalir.EnableMarkup = False
        Me.btnSalir.Image = Global.COBSER.My.Resources.Resources.page_right
        Me.btnSalir.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.btnSalir.ImagePaddingHorizontal = 8
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Text = "Salir"
        '
        'ControlContainerItem2
        '
        Me.ControlContainerItem2.AllowItemResize = False
        Me.ControlContainerItem2.Control = Me.cmbJunta
        Me.ControlContainerItem2.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
        Me.ControlContainerItem2.Name = "ControlContainerItem2"
        '
        'cmbJunta
        '
        Me.cmbJunta.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbJunta.DisplayMember = "Text"
        Me.cmbJunta.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbJunta.DropDownHeight = 300
        Me.cmbJunta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbJunta.FormattingEnabled = True
        Me.cmbJunta.IntegralHeight = False
        Me.cmbJunta.ItemHeight = 17
        Me.cmbJunta.Location = New System.Drawing.Point(3, 2)
        Me.cmbJunta.Name = "cmbJunta"
        Me.cmbJunta.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbJunta.Size = New System.Drawing.Size(971, 23)
        Me.cmbJunta.TabIndex = 3
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        Me.LabelX1.Location = New System.Drawing.Point(12, 3)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(44, 18)
        Me.LabelX1.TabIndex = 8
        Me.LabelX1.Text = "JASS:"
        '
        'Bar2
        '
        Me.Bar2.Controls.Add(Me.cmbJunta1)
        Me.Bar2.Controls.Add(Me.LabelX1)
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar2.Location = New System.Drawing.Point(0, 0)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(696, 25)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Bar2.TabIndex = 10
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'cmbJunta1
        '
        Me.cmbJunta1.DisplayMember = "Text"
        Me.cmbJunta1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbJunta1.DropDownHeight = 250
        Me.cmbJunta1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbJunta1.FormattingEnabled = True
        Me.cmbJunta1.IntegralHeight = False
        Me.cmbJunta1.ItemHeight = 17
        Me.cmbJunta1.Location = New System.Drawing.Point(95, 1)
        Me.cmbJunta1.Name = "cmbJunta1"
        Me.cmbJunta1.Size = New System.Drawing.Size(384, 23)
        Me.cmbJunta1.TabIndex = 13
        '
        'frmTarifasAnios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(696, 343)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.panelHistorial)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTarifasAnios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmTarifasAnios"
        Me.panelHistorial.ResumeLayout(False)
        CType(Me.dgTarifas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Bar2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ControlContainerItem3 As DevComponents.DotNetBar.ControlContainerItem
    Friend WithEvents ControlContainerItem4 As DevComponents.DotNetBar.ControlContainerItem
    Friend WithEvents panelHistorial As DevComponents.DotNetBar.ExpandablePanel
    Friend WithEvents dgTarifas As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents btnTarifaNew As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnTarifaUpd As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem3 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnDistribucion As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnActivar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnImprimir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnSalir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ControlContainerItem2 As DevComponents.DotNetBar.ControlContainerItem
    Friend WithEvents cmbJunta As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents cmbJunta1 As DevComponents.DotNetBar.Controls.ComboBoxEx
End Class
