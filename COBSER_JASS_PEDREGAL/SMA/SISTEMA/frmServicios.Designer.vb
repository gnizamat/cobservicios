<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmServicios
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
        Me.dgServicios = New DevComponents.DotNetBar.Controls.DataGridViewX
        Me.Bar1 = New DevComponents.DotNetBar.Bar
        Me.btnTarifaNew = New DevComponents.DotNetBar.ButtonItem
        Me.btnTarifaUpd = New DevComponents.DotNetBar.ButtonItem
        Me.ButtonItem3 = New DevComponents.DotNetBar.ButtonItem
        Me.btnImprimir = New DevComponents.DotNetBar.ButtonItem
        Me.btnSalir = New DevComponents.DotNetBar.ButtonItem
        Me.cmbJunta = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.cmbTipoServicio = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.ComboItem1 = New DevComponents.Editors.ComboItem
        Me.ComboItem2 = New DevComponents.Editors.ComboItem
        Me.LabelX25 = New DevComponents.DotNetBar.LabelX
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX
        Me.txtServicio = New DevComponents.DotNetBar.Controls.TextBoxX
        CType(Me.dgServicios, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgServicios
        '
        Me.dgServicios.AllowUserToAddRows = False
        Me.dgServicios.AllowUserToDeleteRows = False
        Me.dgServicios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgServicios.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgServicios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgServicios.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgServicios.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgServicios.Location = New System.Drawing.Point(0, 110)
        Me.dgServicios.Name = "dgServicios"
        Me.dgServicios.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgServicios.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgServicios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgServicios.Size = New System.Drawing.Size(608, 200)
        Me.dgServicios.TabIndex = 11
        '
        'Bar1
        '
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnTarifaNew, Me.btnTarifaUpd, Me.ButtonItem3, Me.btnImprimir, Me.btnSalir})
        Me.Bar1.Location = New System.Drawing.Point(0, 316)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(608, 25)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Bar1.TabIndex = 12
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
        Me.btnTarifaNew.Text = "Nuevo"
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
        'cmbJunta
        '
        Me.cmbJunta.DisplayMember = "Text"
        Me.cmbJunta.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbJunta.DropDownHeight = 250
        Me.cmbJunta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbJunta.FormattingEnabled = True
        Me.cmbJunta.IntegralHeight = False
        Me.cmbJunta.ItemHeight = 17
        Me.cmbJunta.Location = New System.Drawing.Point(112, 3)
        Me.cmbJunta.Name = "cmbJunta"
        Me.cmbJunta.Size = New System.Drawing.Size(437, 23)
        Me.cmbJunta.TabIndex = 12
        '
        'GroupPanel1
        '
        Me.GroupPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.cmbJunta)
        Me.GroupPanel1.Controls.Add(Me.cmbTipoServicio)
        Me.GroupPanel1.Controls.Add(Me.LabelX25)
        Me.GroupPanel1.Controls.Add(Me.LabelX4)
        Me.GroupPanel1.Controls.Add(Me.LabelX3)
        Me.GroupPanel1.Controls.Add(Me.txtServicio)
        Me.GroupPanel1.DrawTitleBox = False
        Me.GroupPanel1.Location = New System.Drawing.Point(1, 1)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(607, 103)
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
        Me.GroupPanel1.TabIndex = 35
        Me.GroupPanel1.Text = "Criterios de busqueda"
        '
        'cmbTipoServicio
        '
        Me.cmbTipoServicio.DisplayMember = "Text"
        Me.cmbTipoServicio.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbTipoServicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoServicio.FormattingEnabled = True
        Me.cmbTipoServicio.ItemHeight = 15
        Me.cmbTipoServicio.Items.AddRange(New Object() {Me.ComboItem1, Me.ComboItem2})
        Me.cmbTipoServicio.Location = New System.Drawing.Point(112, 44)
        Me.cmbTipoServicio.Name = "cmbTipoServicio"
        Me.cmbTipoServicio.Size = New System.Drawing.Size(133, 21)
        Me.cmbTipoServicio.TabIndex = 174
        '
        'ComboItem1
        '
        Me.ComboItem1.Text = "Mesual"
        '
        'ComboItem2
        '
        Me.ComboItem2.Text = "Fijo"
        '
        'LabelX25
        '
        Me.LabelX25.AutoSize = True
        Me.LabelX25.BackColor = System.Drawing.Color.Transparent
        Me.LabelX25.Location = New System.Drawing.Point(12, 44)
        Me.LabelX25.Name = "LabelX25"
        Me.LabelX25.Size = New System.Drawing.Size(69, 15)
        Me.LabelX25.TabIndex = 173
        Me.LabelX25.Text = "Tipo Servicio:"
        '
        'LabelX4
        '
        Me.LabelX4.AutoSize = True
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        Me.LabelX4.Location = New System.Drawing.Point(351, 46)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(45, 15)
        Me.LabelX4.TabIndex = 155
        Me.LabelX4.Text = "Servicio:"
        '
        'LabelX3
        '
        Me.LabelX3.AutoSize = True
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        Me.LabelX3.Location = New System.Drawing.Point(11, 9)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(33, 15)
        Me.LabelX3.TabIndex = 150
        Me.LabelX3.Text = "JASS:"
        '
        'txtServicio
        '
        '
        '
        '
        Me.txtServicio.Border.Class = "TextBoxBorder"
        Me.txtServicio.Location = New System.Drawing.Point(416, 43)
        Me.txtServicio.Name = "txtServicio"
        Me.txtServicio.Size = New System.Drawing.Size(133, 20)
        Me.txtServicio.TabIndex = 149
        '
        'frmServicios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(608, 341)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.dgServicios)
        Me.Controls.Add(Me.Bar1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmServicios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmServicios"
        CType(Me.dgServicios, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgServicios As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents btnTarifaNew As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnTarifaUpd As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem3 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnImprimir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnSalir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents cmbJunta As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents cmbTipoServicio As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX25 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtServicio As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents ComboItem2 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem1 As DevComponents.Editors.ComboItem
End Class
