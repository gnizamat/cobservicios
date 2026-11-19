<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSesionClose
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
        Me.btnClear = New DevComponents.DotNetBar.ButtonX
        Me.ButtonX1 = New DevComponents.DotNetBar.ButtonX
        Me.SuspendLayout()
        '
        'btnClear
        '
        Me.btnClear.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnClear.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnClear.Image = Global.COBSER.My.Resources.Resources.cerrar
        Me.btnClear.Location = New System.Drawing.Point(24, 25)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(123, 40)
        Me.btnClear.TabIndex = 11
        Me.btnClear.Text = "Cerrar Sistema"
        Me.btnClear.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left
        '
        'ButtonX1
        '
        Me.ButtonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX1.Image = Global.COBSER.My.Resources.Resources.logo
        Me.ButtonX1.Location = New System.Drawing.Point(192, 27)
        Me.ButtonX1.Name = "ButtonX1"
        Me.ButtonX1.Size = New System.Drawing.Size(123, 38)
        Me.ButtonX1.TabIndex = 12
        Me.ButtonX1.Text = "Cambiar Usuario"
        Me.ButtonX1.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left
        '
        'frmSesionClose
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(361, 105)
        Me.Controls.Add(Me.ButtonX1)
        Me.Controls.Add(Me.btnClear)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmSesionClose"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmSesionClose"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnClear As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX1 As DevComponents.DotNetBar.ButtonX
End Class
