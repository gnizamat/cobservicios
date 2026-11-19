<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTransferenciaPredios
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
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX
        Me.lblid = New System.Windows.Forms.Label
        Me.txtReferencia = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.LabelX11 = New DevComponents.DotNetBar.LabelX
        Me.btn_1_a_Usuario1 = New DevComponents.DotNetBar.ButtonX
        Me.btn_1_a_Usuario2 = New DevComponents.DotNetBar.ButtonX
        Me.dgPredios2 = New DevComponents.DotNetBar.Controls.DataGridViewX
        Me.txtUsuario2 = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.dgPredios1 = New DevComponents.DotNetBar.Controls.DataGridViewX
        Me.txtUsuario1 = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.Bar1 = New DevComponents.DotNetBar.Bar
        Me.cmbJunta = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX
        Me.Bar6 = New DevComponents.DotNetBar.Bar
        Me.btnSave = New DevComponents.DotNetBar.ButtonItem
        Me.btnCancel = New DevComponents.DotNetBar.ButtonItem
        Me.GroupPanel1.SuspendLayout()
        CType(Me.dgPredios2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgPredios1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Bar1.SuspendLayout()
        CType(Me.Bar6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.LabelX3)
        Me.GroupPanel1.Controls.Add(Me.LabelX2)
        Me.GroupPanel1.Controls.Add(Me.lblid)
        Me.GroupPanel1.Controls.Add(Me.txtReferencia)
        Me.GroupPanel1.Controls.Add(Me.LabelX11)
        Me.GroupPanel1.Controls.Add(Me.btn_1_a_Usuario1)
        Me.GroupPanel1.Controls.Add(Me.btn_1_a_Usuario2)
        Me.GroupPanel1.Controls.Add(Me.dgPredios2)
        Me.GroupPanel1.Controls.Add(Me.txtUsuario2)
        Me.GroupPanel1.Controls.Add(Me.dgPredios1)
        Me.GroupPanel1.Controls.Add(Me.txtUsuario1)
        Me.GroupPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupPanel1.Location = New System.Drawing.Point(0, 25)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(811, 402)
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
        Me.GroupPanel1.TabIndex = 45
        Me.GroupPanel1.Text = "Transferencia de Predios"
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        Me.LabelX3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX3.Location = New System.Drawing.Point(433, 30)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(254, 19)
        Me.LabelX3.TabIndex = 159
        Me.LabelX3.Text = "Seleccione Usuario Destino"
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        Me.LabelX2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX2.Location = New System.Drawing.Point(10, 30)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(254, 19)
        Me.LabelX2.TabIndex = 158
        Me.LabelX2.Text = "Seleccione Usuario"
        '
        'lblid
        '
        Me.lblid.AutoSize = True
        Me.lblid.Location = New System.Drawing.Point(109, 359)
        Me.lblid.Name = "lblid"
        Me.lblid.Size = New System.Drawing.Size(0, 13)
        Me.lblid.TabIndex = 157
        '
        'txtReferencia
        '
        '
        '
        '
        Me.txtReferencia.Border.Class = "TextBoxBorder"
        Me.txtReferencia.Location = New System.Drawing.Point(100, 337)
        Me.txtReferencia.Name = "txtReferencia"
        Me.txtReferencia.Size = New System.Drawing.Size(696, 20)
        Me.txtReferencia.TabIndex = 155
        '
        'LabelX11
        '
        Me.LabelX11.AutoSize = True
        Me.LabelX11.BackColor = System.Drawing.Color.Transparent
        Me.LabelX11.Location = New System.Drawing.Point(19, 337)
        Me.LabelX11.Name = "LabelX11"
        Me.LabelX11.Size = New System.Drawing.Size(59, 15)
        Me.LabelX11.TabIndex = 156
        Me.LabelX11.Text = "Referencia:"
        '
        'btn_1_a_Usuario1
        '
        Me.btn_1_a_Usuario1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btn_1_a_Usuario1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btn_1_a_Usuario1.Location = New System.Drawing.Point(383, 128)
        Me.btn_1_a_Usuario1.Name = "btn_1_a_Usuario1"
        Me.btn_1_a_Usuario1.Size = New System.Drawing.Size(37, 23)
        Me.btn_1_a_Usuario1.TabIndex = 7
        Me.btn_1_a_Usuario1.Text = "<"
        '
        'btn_1_a_Usuario2
        '
        Me.btn_1_a_Usuario2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btn_1_a_Usuario2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btn_1_a_Usuario2.Location = New System.Drawing.Point(383, 99)
        Me.btn_1_a_Usuario2.Name = "btn_1_a_Usuario2"
        Me.btn_1_a_Usuario2.Size = New System.Drawing.Size(37, 23)
        Me.btn_1_a_Usuario2.TabIndex = 6
        Me.btn_1_a_Usuario2.Text = ">"
        '
        'dgPredios2
        '
        Me.dgPredios2.AllowUserToAddRows = False
        Me.dgPredios2.AllowUserToDeleteRows = False
        Me.dgPredios2.AllowUserToResizeRows = False
        Me.dgPredios2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgPredios2.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgPredios2.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgPredios2.Location = New System.Drawing.Point(427, 81)
        Me.dgPredios2.Name = "dgPredios2"
        Me.dgPredios2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgPredios2.Size = New System.Drawing.Size(369, 237)
        Me.dgPredios2.TabIndex = 4
        '
        'txtUsuario2
        '
        '
        '
        '
        Me.txtUsuario2.Border.Class = "TextBoxBorder"
        Me.txtUsuario2.ButtonCustom.Visible = True
        Me.txtUsuario2.Location = New System.Drawing.Point(433, 55)
        Me.txtUsuario2.Name = "txtUsuario2"
        Me.txtUsuario2.ReadOnly = True
        Me.txtUsuario2.Size = New System.Drawing.Size(369, 20)
        Me.txtUsuario2.TabIndex = 3
        '
        'dgPredios1
        '
        Me.dgPredios1.AllowUserToAddRows = False
        Me.dgPredios1.AllowUserToDeleteRows = False
        Me.dgPredios1.AllowUserToResizeRows = False
        Me.dgPredios1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgPredios1.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgPredios1.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgPredios1.Location = New System.Drawing.Point(8, 81)
        Me.dgPredios1.Name = "dgPredios1"
        Me.dgPredios1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgPredios1.Size = New System.Drawing.Size(369, 237)
        Me.dgPredios1.TabIndex = 2
        '
        'txtUsuario1
        '
        '
        '
        '
        Me.txtUsuario1.Border.Class = "TextBoxBorder"
        Me.txtUsuario1.ButtonCustom.Visible = True
        Me.txtUsuario1.Location = New System.Drawing.Point(8, 55)
        Me.txtUsuario1.Name = "txtUsuario1"
        Me.txtUsuario1.ReadOnly = True
        Me.txtUsuario1.Size = New System.Drawing.Size(369, 20)
        Me.txtUsuario1.TabIndex = 0
        '
        'Bar1
        '
        Me.Bar1.Controls.Add(Me.cmbJunta)
        Me.Bar1.Controls.Add(Me.LabelX1)
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar1.Location = New System.Drawing.Point(0, 0)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(811, 25)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Bar1.TabIndex = 44
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
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
        Me.cmbJunta.Location = New System.Drawing.Point(136, 0)
        Me.cmbJunta.Name = "cmbJunta"
        Me.cmbJunta.Size = New System.Drawing.Size(287, 23)
        Me.cmbJunta.TabIndex = 1
        Me.cmbJunta.WatermarkText = "Seleccione una Junta de Usuarios"
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        Me.LabelX1.Location = New System.Drawing.Point(13, 3)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(117, 19)
        Me.LabelX1.TabIndex = 0
        Me.LabelX1.Text = "JASS:"
        '
        'Bar6
        '
        Me.Bar6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar6.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnSave, Me.btnCancel})
        Me.Bar6.Location = New System.Drawing.Point(0, 427)
        Me.Bar6.Name = "Bar6"
        Me.Bar6.Size = New System.Drawing.Size(811, 25)
        Me.Bar6.Stretch = True
        Me.Bar6.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Bar6.TabIndex = 43
        Me.Bar6.TabStop = False
        Me.Bar6.Text = "Bar6"
        '
        'btnSave
        '
        Me.btnSave.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnSave.Image = Global.COBSER.My.Resources.Resources.disk
        Me.btnSave.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.btnSave.ImagePaddingHorizontal = 8
        Me.btnSave.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Text = "Grabar"
        '
        'btnCancel
        '
        Me.btnCancel.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnCancel.Image = Global.COBSER.My.Resources.Resources.cross
        Me.btnCancel.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.btnCancel.ImagePaddingHorizontal = 8
        Me.btnCancel.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Text = "Cancelar"
        '
        'frmTransferenciaPredios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(811, 452)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.Bar6)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTransferenciaPredios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmTransferenciaPredios"
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupPanel1.PerformLayout()
        CType(Me.dgPredios2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgPredios1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Bar1.ResumeLayout(False)
        CType(Me.Bar6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents btn_1_a_Usuario1 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btn_1_a_Usuario2 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents dgPredios2 As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents txtUsuario2 As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents dgPredios1 As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents txtUsuario1 As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents cmbJunta As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Bar6 As DevComponents.DotNetBar.Bar
    Friend WithEvents btnSave As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnCancel As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents txtReferencia As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX11 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblid As System.Windows.Forms.Label
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
End Class
