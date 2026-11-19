<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImportar
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
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.txtUbicacion = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX
        Me.pgb = New DevComponents.DotNetBar.Controls.ProgressBarX
        Me.Bar2 = New DevComponents.DotNetBar.Bar
        Me.btnImportar = New DevComponents.DotNetBar.ButtonItem
        Me.btnSalir = New DevComponents.DotNetBar.ButtonItem
        Me.bgw = New System.ComponentModel.BackgroundWorker
        Me.opdImportar = New System.Windows.Forms.OpenFileDialog
        Me.GroupPanel1.SuspendLayout()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.txtUbicacion)
        Me.GroupPanel1.Controls.Add(Me.LabelX3)
        Me.GroupPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(519, 107)
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
        Me.GroupPanel1.TabIndex = 186
        Me.GroupPanel1.Text = "Importar Datos"
        '
        'txtUbicacion
        '
        '
        '
        '
        Me.txtUbicacion.Border.Class = "TextBoxBorder"
        Me.txtUbicacion.ButtonCustom.Visible = True
        Me.txtUbicacion.Location = New System.Drawing.Point(137, 23)
        Me.txtUbicacion.Name = "txtUbicacion"
        Me.txtUbicacion.ReadOnly = True
        Me.txtUbicacion.Size = New System.Drawing.Size(324, 20)
        Me.txtUbicacion.TabIndex = 176
        '
        'LabelX3
        '
        Me.LabelX3.AutoSize = True
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        Me.LabelX3.Location = New System.Drawing.Point(13, 24)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(109, 15)
        Me.LabelX3.TabIndex = 175
        Me.LabelX3.Text = "Ubicacion de Archivo:"
        '
        'pgb
        '
        Me.pgb.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pgb.Location = New System.Drawing.Point(0, 107)
        Me.pgb.Name = "pgb"
        Me.pgb.ProgressType = DevComponents.DotNetBar.eProgressItemType.Marquee
        Me.pgb.Size = New System.Drawing.Size(519, 23)
        Me.pgb.TabIndex = 187
        Me.pgb.TextVisible = True
        '
        'Bar2
        '
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.DockTabAlignment = DevComponents.DotNetBar.eTabStripAlignment.Top
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnImportar, Me.btnSalir})
        Me.Bar2.Location = New System.Drawing.Point(0, 130)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(519, 25)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Bar2.TabIndex = 185
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'btnImportar
        '
        Me.btnImportar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnImportar.EnableMarkup = False
        Me.btnImportar.Image = Global.COBSER.My.Resources.Resources.database_refresh
        Me.btnImportar.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.btnImportar.ImagePaddingHorizontal = 8
        Me.btnImportar.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.btnImportar.Name = "btnImportar"
        Me.btnImportar.Text = "Importar"
        '
        'btnSalir
        '
        Me.btnSalir.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnSalir.EnableMarkup = False
        Me.btnSalir.Image = Global.COBSER.My.Resources.Resources.cross
        Me.btnSalir.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.btnSalir.ImagePaddingHorizontal = 8
        Me.btnSalir.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Text = "Cerrar"
        '
        'bgw
        '
        Me.bgw.WorkerReportsProgress = True
        Me.bgw.WorkerSupportsCancellation = True
        '
        'opdImportar
        '
        Me.opdImportar.FileName = "OpenFileDialog1"
        '
        'frmImportar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(519, 155)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.pgb)
        Me.Controls.Add(Me.Bar2)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmImportar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Importar Transferencia"
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupPanel1.PerformLayout()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents txtUbicacion As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents pgb As DevComponents.DotNetBar.Controls.ProgressBarX
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents btnImportar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnSalir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents bgw As System.ComponentModel.BackgroundWorker
    Friend WithEvents opdImportar As System.Windows.Forms.OpenFileDialog
End Class
