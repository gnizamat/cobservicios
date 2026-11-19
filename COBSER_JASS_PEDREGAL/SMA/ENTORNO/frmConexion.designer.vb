<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConexion
    'Inherits System.Windows.Forms.Form
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
        Me.cmbServer = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.cmbBD = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX
        Me.cmbGrupo = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.btnTester = New DevComponents.DotNetBar.ButtonX
        Me.txtPassword = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.txtUsuario = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.Bar1 = New DevComponents.DotNetBar.Bar
        Me.btnSave = New DevComponents.DotNetBar.ButtonItem
        Me.btnCancel = New DevComponents.DotNetBar.ButtonItem
        Me.GroupPanel1.SuspendLayout()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmbServer
        '
        Me.cmbServer.DisplayMember = "Text"
        Me.cmbServer.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbServer.FormattingEnabled = True
        Me.cmbServer.ItemHeight = 14
        Me.cmbServer.Location = New System.Drawing.Point(104, 19)
        Me.cmbServer.Name = "cmbServer"
        Me.cmbServer.Size = New System.Drawing.Size(216, 20)
        Me.cmbServer.TabIndex = 12
        '
        'cmbBD
        '
        Me.cmbBD.DisplayMember = "Text"
        Me.cmbBD.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbBD.FormattingEnabled = True
        Me.cmbBD.ItemHeight = 14
        Me.cmbBD.Location = New System.Drawing.Point(104, 97)
        Me.cmbBD.Name = "cmbBD"
        Me.cmbBD.Size = New System.Drawing.Size(216, 20)
        Me.cmbBD.TabIndex = 13
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.LabelX5)
        Me.GroupPanel1.Controls.Add(Me.LabelX4)
        Me.GroupPanel1.Controls.Add(Me.LabelX3)
        Me.GroupPanel1.Controls.Add(Me.LabelX2)
        Me.GroupPanel1.Controls.Add(Me.LabelX1)
        Me.GroupPanel1.Controls.Add(Me.cmbGrupo)
        Me.GroupPanel1.Controls.Add(Me.btnTester)
        Me.GroupPanel1.Controls.Add(Me.txtPassword)
        Me.GroupPanel1.Controls.Add(Me.txtUsuario)
        Me.GroupPanel1.Controls.Add(Me.cmbBD)
        Me.GroupPanel1.Controls.Add(Me.cmbServer)
        Me.GroupPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(335, 247)
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
        Me.GroupPanel1.TabIndex = 14
        Me.GroupPanel1.Text = "Datos de Conexión"
        '
        'LabelX5
        '
        Me.LabelX5.AutoSize = True
        Me.LabelX5.BackColor = System.Drawing.Color.Transparent
        Me.LabelX5.Location = New System.Drawing.Point(9, 167)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(42, 15)
        Me.LabelX5.TabIndex = 22
        Me.LabelX5.Text = "Interfaz:"
        '
        'LabelX4
        '
        Me.LabelX4.AutoSize = True
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        Me.LabelX4.Location = New System.Drawing.Point(9, 102)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(77, 15)
        Me.LabelX4.TabIndex = 21
        Me.LabelX4.Text = "Base de Datos:"
        '
        'LabelX3
        '
        Me.LabelX3.AutoSize = True
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        Me.LabelX3.Location = New System.Drawing.Point(9, 76)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(62, 15)
        Me.LabelX3.TabIndex = 20
        Me.LabelX3.Text = "Contraseña:"
        '
        'LabelX2
        '
        Me.LabelX2.AutoSize = True
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        Me.LabelX2.Location = New System.Drawing.Point(9, 50)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(44, 15)
        Me.LabelX2.TabIndex = 19
        Me.LabelX2.Text = "Usuario:"
        '
        'LabelX1
        '
        Me.LabelX1.AutoSize = True
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        Me.LabelX1.Location = New System.Drawing.Point(9, 24)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(47, 15)
        Me.LabelX1.TabIndex = 18
        Me.LabelX1.Text = "Servidor:"
        '
        'cmbGrupo
        '
        Me.cmbGrupo.DisplayMember = "Text"
        Me.cmbGrupo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbGrupo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbGrupo.FormattingEnabled = True
        Me.cmbGrupo.ItemHeight = 14
        Me.cmbGrupo.Location = New System.Drawing.Point(104, 162)
        Me.cmbGrupo.Name = "cmbGrupo"
        Me.cmbGrupo.Size = New System.Drawing.Size(216, 20)
        Me.cmbGrupo.TabIndex = 17
        '
        'btnTester
        '
        Me.btnTester.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnTester.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnTester.Location = New System.Drawing.Point(209, 123)
        Me.btnTester.Name = "btnTester"
        Me.btnTester.Size = New System.Drawing.Size(111, 23)
        Me.btnTester.TabIndex = 16
        Me.btnTester.Text = "Probar Conexión"
        '
        'txtPassword
        '
        '
        '
        '
        Me.txtPassword.Border.Class = "TextBoxBorder"
        Me.txtPassword.Location = New System.Drawing.Point(104, 71)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(216, 20)
        Me.txtPassword.TabIndex = 15
        Me.txtPassword.UseSystemPasswordChar = True
        '
        'txtUsuario
        '
        '
        '
        '
        Me.txtUsuario.Border.Class = "TextBoxBorder"
        Me.txtUsuario.Location = New System.Drawing.Point(104, 45)
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.Size = New System.Drawing.Size(216, 20)
        Me.txtUsuario.TabIndex = 14
        '
        'Bar1
        '
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnSave, Me.btnCancel})
        Me.Bar1.Location = New System.Drawing.Point(0, 222)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(335, 25)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Bar1.TabIndex = 15
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
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
        'frmConexion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(335, 247)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.GroupPanel1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmConexion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Configuracion de Conexión"
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupPanel1.PerformLayout()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmbServer As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents cmbBD As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents cmbGrupo As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents btnTester As DevComponents.DotNetBar.ButtonX
    Friend WithEvents txtPassword As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtUsuario As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents btnSave As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnCancel As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
End Class
