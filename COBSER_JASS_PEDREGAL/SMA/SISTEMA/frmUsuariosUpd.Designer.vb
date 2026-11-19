<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUsuariosUpd
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
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.Bar6 = New DevComponents.DotNetBar.Bar
        Me.btnSave = New DevComponents.DotNetBar.ButtonItem
        Me.btnCancel = New DevComponents.DotNetBar.ButtonItem
        Me.txtDomicilio = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.txtCelular = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.LabelX14 = New DevComponents.DotNetBar.LabelX
        Me.txtEmail = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.LabelX10 = New DevComponents.DotNetBar.LabelX
        Me.LabelX9 = New DevComponents.DotNetBar.LabelX
        Me.txtApellidoM = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.LabelX8 = New DevComponents.DotNetBar.LabelX
        Me.txtApellidoP = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX
        Me.txtNombre = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.txtRUC = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.txtDNI = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.cmbSexo = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.cmbTipo = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX
        Me.cmbJunta = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX
        Me.GroupPanel1.SuspendLayout()
        CType(Me.Bar6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.Bar6)
        Me.GroupPanel1.Controls.Add(Me.txtDomicilio)
        Me.GroupPanel1.Controls.Add(Me.txtCelular)
        Me.GroupPanel1.Controls.Add(Me.LabelX14)
        Me.GroupPanel1.Controls.Add(Me.txtEmail)
        Me.GroupPanel1.Controls.Add(Me.LabelX10)
        Me.GroupPanel1.Controls.Add(Me.LabelX9)
        Me.GroupPanel1.Controls.Add(Me.txtApellidoM)
        Me.GroupPanel1.Controls.Add(Me.LabelX8)
        Me.GroupPanel1.Controls.Add(Me.txtApellidoP)
        Me.GroupPanel1.Controls.Add(Me.LabelX6)
        Me.GroupPanel1.Controls.Add(Me.txtNombre)
        Me.GroupPanel1.Controls.Add(Me.txtRUC)
        Me.GroupPanel1.Controls.Add(Me.txtDNI)
        Me.GroupPanel1.Controls.Add(Me.cmbSexo)
        Me.GroupPanel1.Controls.Add(Me.cmbTipo)
        Me.GroupPanel1.Controls.Add(Me.LabelX7)
        Me.GroupPanel1.Controls.Add(Me.LabelX4)
        Me.GroupPanel1.Controls.Add(Me.LabelX5)
        Me.GroupPanel1.Controls.Add(Me.LabelX3)
        Me.GroupPanel1.Controls.Add(Me.LabelX2)
        Me.GroupPanel1.Controls.Add(Me.cmbJunta)
        Me.GroupPanel1.Controls.Add(Me.LabelX1)
        Me.GroupPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(499, 359)
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
        Me.GroupPanel1.TabIndex = 43
        Me.GroupPanel1.Text = "Datos del Usuario"
        '
        'Bar6
        '
        Me.Bar6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar6.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.Bar6.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnSave, Me.btnCancel})
        Me.Bar6.Location = New System.Drawing.Point(0, 313)
        Me.Bar6.Name = "Bar6"
        Me.Bar6.Size = New System.Drawing.Size(493, 25)
        Me.Bar6.Stretch = True
        Me.Bar6.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Bar6.TabIndex = 41
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
        Me.btnCancel.Image = Global.COBSER.My.Resources.Resources.door
        Me.btnCancel.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.btnCancel.ImagePaddingHorizontal = 8
        Me.btnCancel.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Text = "Cancelar"
        '
        'txtDomicilio
        '
        '
        '
        '
        Me.txtDomicilio.Border.Class = "TextBoxBorder"
        Me.txtDomicilio.Location = New System.Drawing.Point(139, 196)
        Me.txtDomicilio.Name = "txtDomicilio"
        Me.txtDomicilio.Size = New System.Drawing.Size(340, 20)
        Me.txtDomicilio.TabIndex = 8
        '
        'txtCelular
        '
        '
        '
        '
        Me.txtCelular.Border.Class = "TextBoxBorder"
        Me.txtCelular.Location = New System.Drawing.Point(139, 232)
        Me.txtCelular.Name = "txtCelular"
        Me.txtCelular.Size = New System.Drawing.Size(138, 20)
        Me.txtCelular.TabIndex = 11
        '
        'LabelX14
        '
        Me.LabelX14.AutoSize = True
        Me.LabelX14.BackColor = System.Drawing.Color.Transparent
        Me.LabelX14.Location = New System.Drawing.Point(12, 233)
        Me.LabelX14.Name = "LabelX14"
        Me.LabelX14.Size = New System.Drawing.Size(41, 15)
        Me.LabelX14.TabIndex = 29
        Me.LabelX14.Text = "Celular:"
        '
        'txtEmail
        '
        '
        '
        '
        Me.txtEmail.Border.Class = "TextBoxBorder"
        Me.txtEmail.Location = New System.Drawing.Point(139, 267)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(340, 20)
        Me.txtEmail.TabIndex = 9
        '
        'LabelX10
        '
        Me.LabelX10.AutoSize = True
        Me.LabelX10.BackColor = System.Drawing.Color.Transparent
        Me.LabelX10.Location = New System.Drawing.Point(12, 270)
        Me.LabelX10.Name = "LabelX10"
        Me.LabelX10.Size = New System.Drawing.Size(37, 15)
        Me.LabelX10.TabIndex = 19
        Me.LabelX10.Text = "E-mail:"
        '
        'LabelX9
        '
        Me.LabelX9.AutoSize = True
        Me.LabelX9.BackColor = System.Drawing.Color.Transparent
        Me.LabelX9.Location = New System.Drawing.Point(12, 198)
        Me.LabelX9.Name = "LabelX9"
        Me.LabelX9.Size = New System.Drawing.Size(50, 15)
        Me.LabelX9.TabIndex = 17
        Me.LabelX9.Text = "Domicilio:"
        '
        'txtApellidoM
        '
        '
        '
        '
        Me.txtApellidoM.Border.Class = "TextBoxBorder"
        Me.txtApellidoM.Location = New System.Drawing.Point(139, 165)
        Me.txtApellidoM.Name = "txtApellidoM"
        Me.txtApellidoM.Size = New System.Drawing.Size(340, 20)
        Me.txtApellidoM.TabIndex = 7
        '
        'LabelX8
        '
        Me.LabelX8.AutoSize = True
        Me.LabelX8.BackColor = System.Drawing.Color.Transparent
        Me.LabelX8.Location = New System.Drawing.Point(12, 164)
        Me.LabelX8.Name = "LabelX8"
        Me.LabelX8.Size = New System.Drawing.Size(88, 15)
        Me.LabelX8.TabIndex = 15
        Me.LabelX8.Text = "Apellido Materno:"
        '
        'txtApellidoP
        '
        '
        '
        '
        Me.txtApellidoP.Border.Class = "TextBoxBorder"
        Me.txtApellidoP.Location = New System.Drawing.Point(139, 132)
        Me.txtApellidoP.Name = "txtApellidoP"
        Me.txtApellidoP.Size = New System.Drawing.Size(340, 20)
        Me.txtApellidoP.TabIndex = 6
        '
        'LabelX6
        '
        Me.LabelX6.AutoSize = True
        Me.LabelX6.BackColor = System.Drawing.Color.Transparent
        Me.LabelX6.Location = New System.Drawing.Point(12, 132)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(86, 15)
        Me.LabelX6.TabIndex = 13
        Me.LabelX6.Text = "Apellido Paterno:"
        '
        'txtNombre
        '
        '
        '
        '
        Me.txtNombre.Border.Class = "TextBoxBorder"
        Me.txtNombre.Location = New System.Drawing.Point(139, 100)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(340, 20)
        Me.txtNombre.TabIndex = 5
        '
        'txtRUC
        '
        '
        '
        '
        Me.txtRUC.Border.Class = "TextBoxBorder"
        Me.txtRUC.Location = New System.Drawing.Point(341, 70)
        Me.txtRUC.Name = "txtRUC"
        Me.txtRUC.Size = New System.Drawing.Size(138, 20)
        Me.txtRUC.TabIndex = 4
        '
        'txtDNI
        '
        '
        '
        '
        Me.txtDNI.Border.Class = "TextBoxBorder"
        Me.txtDNI.Location = New System.Drawing.Point(139, 69)
        Me.txtDNI.Name = "txtDNI"
        Me.txtDNI.Size = New System.Drawing.Size(132, 20)
        Me.txtDNI.TabIndex = 3
        '
        'cmbSexo
        '
        Me.cmbSexo.DisplayMember = "Text"
        Me.cmbSexo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbSexo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSexo.FormattingEnabled = True
        Me.cmbSexo.ItemHeight = 14
        Me.cmbSexo.Location = New System.Drawing.Point(341, 37)
        Me.cmbSexo.Name = "cmbSexo"
        Me.cmbSexo.Size = New System.Drawing.Size(138, 20)
        Me.cmbSexo.TabIndex = 2
        '
        'cmbTipo
        '
        Me.cmbTipo.DisplayMember = "Text"
        Me.cmbTipo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipo.FormattingEnabled = True
        Me.cmbTipo.ItemHeight = 14
        Me.cmbTipo.Location = New System.Drawing.Point(139, 37)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(132, 20)
        Me.cmbTipo.TabIndex = 1
        '
        'LabelX7
        '
        Me.LabelX7.AutoSize = True
        Me.LabelX7.BackColor = System.Drawing.Color.Transparent
        Me.LabelX7.Location = New System.Drawing.Point(12, 102)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(121, 15)
        Me.LabelX7.TabIndex = 6
        Me.LabelX7.Text = "Nombre o Razon Social:"
        '
        'LabelX4
        '
        Me.LabelX4.AutoSize = True
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        Me.LabelX4.Location = New System.Drawing.Point(293, 70)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(29, 15)
        Me.LabelX4.TabIndex = 5
        Me.LabelX4.Text = "RUC:"
        '
        'LabelX5
        '
        Me.LabelX5.AutoSize = True
        Me.LabelX5.BackColor = System.Drawing.Color.Transparent
        Me.LabelX5.Location = New System.Drawing.Point(12, 70)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(24, 15)
        Me.LabelX5.TabIndex = 4
        Me.LabelX5.Text = "DNI:"
        '
        'LabelX3
        '
        Me.LabelX3.AutoSize = True
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        Me.LabelX3.Location = New System.Drawing.Point(293, 37)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(31, 15)
        Me.LabelX3.TabIndex = 3
        Me.LabelX3.Text = "Sexo:"
        '
        'LabelX2
        '
        Me.LabelX2.AutoSize = True
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        Me.LabelX2.Location = New System.Drawing.Point(12, 37)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(86, 15)
        Me.LabelX2.TabIndex = 2
        Me.LabelX2.Text = "Tipo de Persona:"
        '
        'cmbJunta
        '
        Me.cmbJunta.DisplayMember = "Text"
        Me.cmbJunta.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbJunta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbJunta.FormattingEnabled = True
        Me.cmbJunta.ItemHeight = 14
        Me.cmbJunta.Location = New System.Drawing.Point(139, 7)
        Me.cmbJunta.Name = "cmbJunta"
        Me.cmbJunta.Size = New System.Drawing.Size(340, 20)
        Me.cmbJunta.TabIndex = 0
        '
        'LabelX1
        '
        Me.LabelX1.AutoSize = True
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        Me.LabelX1.Location = New System.Drawing.Point(15, 8)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(33, 15)
        Me.LabelX1.TabIndex = 0
        Me.LabelX1.Text = "JASS:"
        '
        'frmUsuariosUpd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(499, 359)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Name = "frmUsuariosUpd"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Actulizar Usuario"
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupPanel1.PerformLayout()
        CType(Me.Bar6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Bar6 As DevComponents.DotNetBar.Bar
    Friend WithEvents btnSave As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnCancel As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents txtDomicilio As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtCelular As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX14 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtEmail As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX10 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX9 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtApellidoM As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX8 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtApellidoP As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtNombre As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtRUC As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtDNI As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents cmbSexo As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents cmbTipo As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cmbJunta As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
End Class
