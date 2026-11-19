<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSysGrupoUpd
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
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.btnCancel = New DevComponents.DotNetBar.ButtonX
        Me.btnCleaner = New DevComponents.DotNetBar.ButtonX
        Me.btnSave = New DevComponents.DotNetBar.ButtonX
        Me.lblCR2 = New DevComponents.DotNetBar.LabelX
        Me.lblJU2 = New DevComponents.DotNetBar.LabelX
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX
        Me.cmbInterfaz = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.cmbCR = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.cmbJU = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.cmbRegion = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.cmbDistritoRiego = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX
        Me.txtNombre = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX
        Me.GroupPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.btnCancel)
        Me.GroupPanel1.Controls.Add(Me.btnCleaner)
        Me.GroupPanel1.Controls.Add(Me.btnSave)
        Me.GroupPanel1.Controls.Add(Me.lblCR2)
        Me.GroupPanel1.Controls.Add(Me.lblJU2)
        Me.GroupPanel1.Controls.Add(Me.LabelX4)
        Me.GroupPanel1.Controls.Add(Me.LabelX3)
        Me.GroupPanel1.Controls.Add(Me.cmbInterfaz)
        Me.GroupPanel1.Controls.Add(Me.cmbCR)
        Me.GroupPanel1.Controls.Add(Me.cmbJU)
        Me.GroupPanel1.Controls.Add(Me.cmbRegion)
        Me.GroupPanel1.Controls.Add(Me.cmbDistritoRiego)
        Me.GroupPanel1.Controls.Add(Me.LabelX2)
        Me.GroupPanel1.Controls.Add(Me.txtNombre)
        Me.GroupPanel1.Controls.Add(Me.LabelX1)
        Me.GroupPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(473, 318)
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
        Me.GroupPanel1.Text = "Datos del Grupo"
        '
        'btnCancel
        '
        Me.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCancel.Location = New System.Drawing.Point(169, 241)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 34
        Me.btnCancel.Text = "Cancelar"
        '
        'btnCleaner
        '
        Me.btnCleaner.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCleaner.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCleaner.Location = New System.Drawing.Point(250, 241)
        Me.btnCleaner.Name = "btnCleaner"
        Me.btnCleaner.Size = New System.Drawing.Size(75, 23)
        Me.btnCleaner.TabIndex = 33
        Me.btnCleaner.Text = "limpiar"
        '
        'btnSave
        '
        Me.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnSave.Location = New System.Drawing.Point(88, 241)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 32
        Me.btnSave.Text = "Grabar"
        '
        'lblCR2
        '
        Me.lblCR2.AutoSize = True
        Me.lblCR2.BackColor = System.Drawing.Color.Transparent
        Me.lblCR2.Location = New System.Drawing.Point(3, 188)
        Me.lblCR2.Name = "lblCR2"
        Me.lblCR2.Size = New System.Drawing.Size(117, 15)
        Me.lblCR2.TabIndex = 31
        Me.lblCR2.Text = "Comisión de Regantes:"
        '
        'lblJU2
        '
        Me.lblJU2.AutoSize = True
        Me.lblJU2.BackColor = System.Drawing.Color.Transparent
        Me.lblJU2.Location = New System.Drawing.Point(3, 162)
        Me.lblJU2.Name = "lblJU2"
        Me.lblJU2.Size = New System.Drawing.Size(94, 15)
        Me.lblJU2.TabIndex = 30
        Me.lblJU2.Text = "Junta de Usuarios:"
        '
        'LabelX4
        '
        Me.LabelX4.AutoSize = True
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        Me.LabelX4.Location = New System.Drawing.Point(3, 133)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(87, 15)
        Me.LabelX4.TabIndex = 29
        Me.LabelX4.Text = "Distrito de Riego:"
        '
        'LabelX3
        '
        Me.LabelX3.AutoSize = True
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        Me.LabelX3.Location = New System.Drawing.Point(3, 107)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(40, 15)
        Me.LabelX3.TabIndex = 28
        Me.LabelX3.Text = "Región:"
        '
        'cmbInterfaz
        '
        Me.cmbInterfaz.DisplayMember = "Text"
        Me.cmbInterfaz.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbInterfaz.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbInterfaz.FormattingEnabled = True
        Me.cmbInterfaz.ItemHeight = 14
        Me.cmbInterfaz.Location = New System.Drawing.Point(124, 8)
        Me.cmbInterfaz.Name = "cmbInterfaz"
        Me.cmbInterfaz.Size = New System.Drawing.Size(290, 20)
        Me.cmbInterfaz.TabIndex = 27
        Me.cmbInterfaz.WatermarkColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.cmbInterfaz.WatermarkText = "Seleccione una Interfaz"
        '
        'cmbCR
        '
        Me.cmbCR.DisplayMember = "Text"
        Me.cmbCR.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbCR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCR.FormattingEnabled = True
        Me.cmbCR.ItemHeight = 14
        Me.cmbCR.Location = New System.Drawing.Point(124, 183)
        Me.cmbCR.Name = "cmbCR"
        Me.cmbCR.Size = New System.Drawing.Size(290, 20)
        Me.cmbCR.TabIndex = 26
        Me.cmbCR.WatermarkColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.cmbCR.WatermarkText = "Seleccione una Comisión de Regantes"
        '
        'cmbJU
        '
        Me.cmbJU.DisplayMember = "Text"
        Me.cmbJU.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbJU.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbJU.FormattingEnabled = True
        Me.cmbJU.ItemHeight = 14
        Me.cmbJU.Location = New System.Drawing.Point(124, 157)
        Me.cmbJU.Name = "cmbJU"
        Me.cmbJU.Size = New System.Drawing.Size(290, 20)
        Me.cmbJU.TabIndex = 25
        Me.cmbJU.WatermarkColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.cmbJU.WatermarkText = "Seleccione una Junta de Usuarios"
        '
        'cmbRegion
        '
        Me.cmbRegion.DisplayMember = "Text"
        Me.cmbRegion.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbRegion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRegion.FormattingEnabled = True
        Me.cmbRegion.ItemHeight = 14
        Me.cmbRegion.Location = New System.Drawing.Point(124, 102)
        Me.cmbRegion.Name = "cmbRegion"
        Me.cmbRegion.Size = New System.Drawing.Size(290, 20)
        Me.cmbRegion.TabIndex = 24
        Me.cmbRegion.WatermarkColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.cmbRegion.WatermarkText = "Seleccione una Región"
        '
        'cmbDistritoRiego
        '
        Me.cmbDistritoRiego.DisplayMember = "Text"
        Me.cmbDistritoRiego.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbDistritoRiego.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDistritoRiego.FormattingEnabled = True
        Me.cmbDistritoRiego.ItemHeight = 14
        Me.cmbDistritoRiego.Location = New System.Drawing.Point(124, 128)
        Me.cmbDistritoRiego.Name = "cmbDistritoRiego"
        Me.cmbDistritoRiego.Size = New System.Drawing.Size(290, 20)
        Me.cmbDistritoRiego.TabIndex = 23
        Me.cmbDistritoRiego.WatermarkColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.cmbDistritoRiego.WatermarkText = "Seleccione un Distrito de Riego"
        '
        'LabelX2
        '
        Me.LabelX2.AutoSize = True
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        Me.LabelX2.Location = New System.Drawing.Point(3, 44)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(45, 15)
        Me.LabelX2.TabIndex = 21
        Me.LabelX2.Text = "Nombre:"
        '
        'txtNombre
        '
        '
        '
        '
        Me.txtNombre.Border.Class = "TextBoxBorder"
        Me.txtNombre.Location = New System.Drawing.Point(124, 39)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(290, 20)
        Me.txtNombre.TabIndex = 20
        Me.txtNombre.WatermarkText = "Nombre de Interfaz"
        '
        'LabelX1
        '
        Me.LabelX1.AutoSize = True
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        Me.LabelX1.Location = New System.Drawing.Point(3, 13)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(42, 15)
        Me.LabelX1.TabIndex = 0
        Me.LabelX1.Text = "Interfaz:"
        '
        'frmSysGrupoUpd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(473, 318)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Name = "frmSysGrupoUpd"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Editar Grupo"
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents btnCancel As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCleaner As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnSave As DevComponents.DotNetBar.ButtonX
    Friend WithEvents lblCR2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblJU2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cmbInterfaz As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents cmbCR As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents cmbJU As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents cmbRegion As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents cmbDistritoRiego As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtNombre As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
End Class
