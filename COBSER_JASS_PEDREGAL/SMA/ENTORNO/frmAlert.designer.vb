<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAlert
    'Inherits System.Windows.Forms.Form
    Inherits DevComponents.DotNetBar.Balloon
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
        Me.ReflectionImage1 = New DevComponents.DotNetBar.Controls.ReflectionImage
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX
        Me.lblMessage = New DevComponents.DotNetBar.LabelX
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.lblUsuario = New DevComponents.DotNetBar.LabelX
        Me.lblFecha = New DevComponents.DotNetBar.LabelX
        Me.SuspendLayout()
        '
        'ReflectionImage1
        '
        Me.ReflectionImage1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.ReflectionImage1.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.ReflectionImage1.Image = Global.COBSER.My.Resources.Resources.info
        Me.ReflectionImage1.Location = New System.Drawing.Point(13, 13)
        Me.ReflectionImage1.Name = "ReflectionImage1"
        Me.ReflectionImage1.Size = New System.Drawing.Size(72, 128)
        Me.ReflectionImage1.TabIndex = 0
        '
        'LabelX1
        '
        Me.LabelX1.AutoSize = True
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        Me.LabelX1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.Location = New System.Drawing.Point(83, 12)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(178, 19)
        Me.LabelX1.TabIndex = 1
        Me.LabelX1.Text = "Actualizaciones Remotas"
        '
        'lblMessage
        '
        Me.lblMessage.BackColor = System.Drawing.Color.Transparent
        Me.lblMessage.Location = New System.Drawing.Point(83, 72)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(211, 63)
        Me.lblMessage.TabIndex = 2
        Me.lblMessage.Text = "MSG"
        Me.lblMessage.TextLineAlignment = System.Drawing.StringAlignment.Near
        Me.lblMessage.WordWrap = True
        '
        'Timer1
        '
        Me.Timer1.Interval = 10000
        '
        'lblUsuario
        '
        Me.lblUsuario.AutoSize = True
        Me.lblUsuario.BackColor = System.Drawing.Color.Transparent
        Me.lblUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUsuario.Location = New System.Drawing.Point(83, 37)
        Me.lblUsuario.Name = "lblUsuario"
        Me.lblUsuario.Size = New System.Drawing.Size(42, 15)
        Me.lblUsuario.TabIndex = 3
        Me.lblUsuario.Text = "Usuario"
        Me.lblUsuario.TextLineAlignment = System.Drawing.StringAlignment.Near
        Me.lblUsuario.WordWrap = True
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.BackColor = System.Drawing.Color.Transparent
        Me.lblFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFecha.Location = New System.Drawing.Point(83, 51)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(34, 15)
        Me.lblFecha.TabIndex = 4
        Me.lblFecha.Text = "Fecha"
        Me.lblFecha.TextLineAlignment = System.Drawing.StringAlignment.Far
        Me.lblFecha.WordWrap = True
        '
        'frmAlert
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(175, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.BorderColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(307, 147)
        Me.Controls.Add(Me.lblFecha)
        Me.Controls.Add(Me.lblUsuario)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.ReflectionImage1)
        Me.ForeColor = System.Drawing.Color.FromArgb(CType(CType(8, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(114, Byte), Integer))
        Me.Location = New System.Drawing.Point(0, 0)
        Me.Name = "frmAlert"
        Me.Style = DevComponents.DotNetBar.eBallonStyle.Office2007Alert
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ReflectionImage1 As DevComponents.DotNetBar.Controls.ReflectionImage
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblMessage As DevComponents.DotNetBar.LabelX
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents lblUsuario As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblFecha As DevComponents.DotNetBar.LabelX
End Class
