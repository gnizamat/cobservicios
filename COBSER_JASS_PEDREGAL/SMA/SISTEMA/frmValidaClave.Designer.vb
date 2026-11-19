<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmValidaClave
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
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX
        Me.txtClave = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.Bar1 = New DevComponents.DotNetBar.Bar
        Me.btAceptar = New DevComponents.DotNetBar.ButtonItem
        Me.btnCerrar = New DevComponents.DotNetBar.ButtonItem
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        Me.LabelX4.Location = New System.Drawing.Point(3, 26)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(127, 19)
        Me.LabelX4.TabIndex = 6
        Me.LabelX4.Text = "Clave de Inicio:"
        '
        'txtClave
        '
        Me.txtClave.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        '
        '
        '
        Me.txtClave.Border.Class = "TextBoxBorder"
        Me.txtClave.Location = New System.Drawing.Point(127, 25)
        Me.txtClave.Name = "txtClave"
        Me.txtClave.Size = New System.Drawing.Size(167, 20)
        Me.txtClave.TabIndex = 7
        Me.txtClave.UseSystemPasswordChar = True
        Me.txtClave.WatermarkText = "Ingrese clave"
        '
        'Bar1
        '
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btAceptar, Me.btnCerrar})
        Me.Bar1.Location = New System.Drawing.Point(0, 88)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(356, 25)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Bar1.TabIndex = 8
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'btAceptar
        '
        Me.btAceptar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btAceptar.Image = Global.COBSER.My.Resources.Resources.accept
        Me.btAceptar.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.btAceptar.ImagePaddingHorizontal = 8
        Me.btAceptar.Name = "btAceptar"
        Me.btAceptar.Text = "Aceptar"
        '
        'btnCerrar
        '
        Me.btnCerrar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnCerrar.Image = Global.COBSER.My.Resources.Resources.door
        Me.btnCerrar.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.btnCerrar.ImagePaddingHorizontal = 8
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Text = "Cerrar"
        '
        'frmValidaClave
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(356, 113)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.txtClave)
        Me.Controls.Add(Me.LabelX4)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmValidaClave"
        Me.Text = "Valida Clave"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtClave As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents btAceptar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnCerrar As DevComponents.DotNetBar.ButtonItem
End Class
