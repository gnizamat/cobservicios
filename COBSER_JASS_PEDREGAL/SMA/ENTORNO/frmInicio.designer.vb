<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
<Global.System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726")> _
Partial Class frmInicio
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
    Friend WithEvents lblUser As System.Windows.Forms.Label
    Friend WithEvents lblPass As System.Windows.Forms.Label

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInicio))
        Me.lblUser = New System.Windows.Forms.Label
        Me.lblPass = New System.Windows.Forms.Label
        Me.lblGroup = New System.Windows.Forms.Label
        Me.cmbGrupo = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.txtUsuario = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.txtPassword = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.lblSplahText = New DevComponents.DotNetBar.LabelX
        Me.btnCancelar = New DevComponents.DotNetBar.ButtonX
        Me.btnAceptar = New DevComponents.DotNetBar.ButtonX
        Me.btnConnect = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblUser
        '
        Me.lblUser.AutoSize = True
        Me.lblUser.BackColor = System.Drawing.Color.Transparent
        Me.lblUser.ForeColor = System.Drawing.Color.White
        Me.lblUser.Location = New System.Drawing.Point(154, 129)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(43, 13)
        Me.lblUser.TabIndex = 3
        Me.lblUser.Text = "&Usuario"
        Me.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPass
        '
        Me.lblPass.AutoSize = True
        Me.lblPass.BackColor = System.Drawing.Color.Transparent
        Me.lblPass.ForeColor = System.Drawing.Color.White
        Me.lblPass.Location = New System.Drawing.Point(154, 170)
        Me.lblPass.Name = "lblPass"
        Me.lblPass.Size = New System.Drawing.Size(61, 13)
        Me.lblPass.TabIndex = 5
        Me.lblPass.Text = "&Contraseña"
        Me.lblPass.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblGroup
        '
        Me.lblGroup.AutoSize = True
        Me.lblGroup.BackColor = System.Drawing.Color.Transparent
        Me.lblGroup.ForeColor = System.Drawing.Color.White
        Me.lblGroup.Location = New System.Drawing.Point(154, 96)
        Me.lblGroup.Name = "lblGroup"
        Me.lblGroup.Size = New System.Drawing.Size(36, 13)
        Me.lblGroup.TabIndex = 1
        Me.lblGroup.Text = "&Grupo"
        '
        'cmbGrupo
        '
        Me.cmbGrupo.DisplayMember = "Text"
        Me.cmbGrupo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbGrupo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbGrupo.FormattingEnabled = True
        Me.cmbGrupo.ItemHeight = 14
        Me.cmbGrupo.Location = New System.Drawing.Point(221, 89)
        Me.cmbGrupo.Name = "cmbGrupo"
        Me.cmbGrupo.Size = New System.Drawing.Size(219, 20)
        Me.cmbGrupo.TabIndex = 10
        '
        'txtUsuario
        '
        '
        '
        '
        Me.txtUsuario.Border.Class = "TextBoxBorder"
        Me.txtUsuario.Location = New System.Drawing.Point(221, 122)
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.Size = New System.Drawing.Size(219, 20)
        Me.txtUsuario.TabIndex = 11
        '
        'txtPassword
        '
        '
        '
        '
        Me.txtPassword.Border.Class = "TextBoxBorder"
        Me.txtPassword.Location = New System.Drawing.Point(221, 163)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(219, 20)
        Me.txtPassword.TabIndex = 12
        Me.txtPassword.UseSystemPasswordChar = True
        '
        'lblSplahText
        '
        Me.lblSplahText.AutoSize = True
        Me.lblSplahText.BackColor = System.Drawing.Color.Transparent
        Me.lblSplahText.ForeColor = System.Drawing.Color.White
        Me.lblSplahText.Location = New System.Drawing.Point(12, 50)
        Me.lblSplahText.Name = "lblSplahText"
        Me.lblSplahText.Size = New System.Drawing.Size(384, 15)
        Me.lblSplahText.TabIndex = 13
        Me.lblSplahText.Text = "Bienvenido, seleccione un grupo e ingrese su nombre de usuario y contraseña"
        '
        'btnCancelar
        '
        Me.btnCancelar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancelar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCancelar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnCancelar.Image = Global.COBSER.My.Resources.Resources.cross
        Me.btnCancelar.Location = New System.Drawing.Point(339, 214)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(101, 33)
        Me.btnCancelar.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005
        Me.btnCancelar.TabIndex = 15
        Me.btnCancelar.Text = "Cancelar"
        '
        'btnAceptar
        '
        Me.btnAceptar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAceptar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnAceptar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnAceptar.Image = Global.COBSER.My.Resources.Resources.ok
        Me.btnAceptar.Location = New System.Drawing.Point(232, 214)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(101, 33)
        Me.btnAceptar.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005
        Me.btnAceptar.TabIndex = 14
        Me.btnAceptar.Text = "Aceptar"
        '
        'btnConnect
        '
        Me.btnConnect.Image = Global.COBSER.My.Resources.Resources.connect
        Me.btnConnect.Location = New System.Drawing.Point(12, 224)
        Me.btnConnect.Name = "btnConnect"
        Me.btnConnect.Size = New System.Drawing.Size(28, 23)
        Me.btnConnect.TabIndex = 9
        Me.btnConnect.Tag = ""
        Me.btnConnect.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.ErrorImage = Nothing
        Me.PictureBox1.Image = Global.COBSER.My.Resources.Resources.splash_02
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(452, 252)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox1.TabIndex = 8
        Me.PictureBox1.TabStop = False
        '
        'frmInicio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(207, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(452, 252)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.lblSplahText)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.txtUsuario)
        Me.Controls.Add(Me.cmbGrupo)
        Me.Controls.Add(Me.btnConnect)
        Me.Controls.Add(Me.lblGroup)
        Me.Controls.Add(Me.lblPass)
        Me.Controls.Add(Me.lblUser)
        Me.Controls.Add(Me.PictureBox1)
        Me.ForeColor = System.Drawing.Color.FromArgb(CType(CType(102, Byte), Integer), CType(CType(114, Byte), Integer), CType(CType(196, Byte), Integer))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmInicio"
        Me.Opacity = 0.86
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Inicio de Sesión"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblGroup As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents btnConnect As System.Windows.Forms.Button
    Friend WithEvents cmbGrupo As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents txtUsuario As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtPassword As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents lblSplahText As DevComponents.DotNetBar.LabelX
    Friend WithEvents btnAceptar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCancelar As DevComponents.DotNetBar.ButtonX

End Class
