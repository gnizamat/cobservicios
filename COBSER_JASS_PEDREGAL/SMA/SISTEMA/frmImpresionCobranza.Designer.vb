<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImpresionCobranza
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
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel
        Me.ReflectionImage1 = New DevComponents.DotNetBar.Controls.ReflectionImage
        Me.btnPreview = New DevComponents.DotNetBar.ButtonX
        Me.btnPrint = New DevComponents.DotNetBar.ButtonX
        Me.SuspendLayout()
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        Me.LabelX2.Location = New System.Drawing.Point(103, 67)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(520, 42)
        Me.LabelX2.TabIndex = 12
        Me.LabelX2.Text = "La Cobranza se realizó satisfactoriamente.  Ud. puede imprimir el comprobante de " & _
            "pago o intentarlo mas adelante."
        Me.LabelX2.WordWrap = True
        '
        'ReflectionLabel1
        '
        Me.ReflectionLabel1.BackColor = System.Drawing.Color.Transparent
        Me.ReflectionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel1.Location = New System.Drawing.Point(122, 12)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(476, 49)
        Me.ReflectionLabel1.TabIndex = 11
        Me.ReflectionLabel1.Text = "Cobranza(s) registrada(s) satisfactoriamente"
        '
        'ReflectionImage1
        '
        Me.ReflectionImage1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.ReflectionImage1.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.ReflectionImage1.Location = New System.Drawing.Point(45, 67)
        Me.ReflectionImage1.Name = "ReflectionImage1"
        Me.ReflectionImage1.Size = New System.Drawing.Size(162, 117)
        Me.ReflectionImage1.TabIndex = 10
        '
        'btnPreview
        '
        Me.btnPreview.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnPreview.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnPreview.Location = New System.Drawing.Point(140, 161)
        Me.btnPreview.Name = "btnPreview"
        Me.btnPreview.Size = New System.Drawing.Size(128, 23)
        Me.btnPreview.TabIndex = 14
        Me.btnPreview.Text = "Vista Previa Recibo"
        '
        'btnPrint
        '
        Me.btnPrint.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnPrint.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnPrint.Location = New System.Drawing.Point(349, 161)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(98, 23)
        Me.btnPrint.TabIndex = 13
        Me.btnPrint.Text = "Imprimir Pago"
        '
        'frmImpresionCobranza
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(588, 225)
        Me.Controls.Add(Me.btnPreview)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.LabelX2)
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.Controls.Add(Me.ReflectionImage1)
        Me.Name = "frmImpresionCobranza"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmImpresionCobranza"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents ReflectionImage1 As DevComponents.DotNetBar.Controls.ReflectionImage
    Friend WithEvents btnPreview As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnPrint As DevComponents.DotNetBar.ButtonX
End Class
