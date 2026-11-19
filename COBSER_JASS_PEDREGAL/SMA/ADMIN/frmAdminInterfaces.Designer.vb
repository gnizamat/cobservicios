<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAdminInterfaces
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
        Me.components = New System.ComponentModel.Container
        Me.TabControl2 = New DevComponents.DotNetBar.TabControl
        Me.TabControlPanel1 = New DevComponents.DotNetBar.TabControlPanel
        Me.tvATDR = New System.Windows.Forms.TreeView
        Me.TabItem1 = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanel3 = New DevComponents.DotNetBar.TabControlPanel
        Me.tvCR = New System.Windows.Forms.TreeView
        Me.TabItem3 = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanel2 = New DevComponents.DotNetBar.TabControlPanel
        Me.tvJU = New System.Windows.Forms.TreeView
        Me.TabItem2 = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.bgw = New System.ComponentModel.BackgroundWorker
        Me.Bar1 = New DevComponents.DotNetBar.Bar
        Me.imgEstadoMsg = New System.Windows.Forms.PictureBox
        Me.btnSave = New DevComponents.DotNetBar.ButtonItem
        Me.ButtonItem1 = New DevComponents.DotNetBar.ButtonItem
        CType(Me.TabControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl2.SuspendLayout()
        Me.TabControlPanel1.SuspendLayout()
        Me.TabControlPanel3.SuspendLayout()
        Me.TabControlPanel2.SuspendLayout()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Bar1.SuspendLayout()
        CType(Me.imgEstadoMsg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl2
        '
        Me.TabControl2.BackColor = System.Drawing.Color.Transparent
        Me.TabControl2.CanReorderTabs = True
        Me.TabControl2.Controls.Add(Me.TabControlPanel1)
        Me.TabControl2.Controls.Add(Me.TabControlPanel3)
        Me.TabControl2.Controls.Add(Me.TabControlPanel2)
        Me.TabControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl2.Location = New System.Drawing.Point(0, 0)
        Me.TabControl2.Name = "TabControl2"
        Me.TabControl2.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.TabControl2.SelectedTabIndex = 2
        Me.TabControl2.Size = New System.Drawing.Size(375, 420)
        Me.TabControl2.Style = DevComponents.DotNetBar.eTabStripStyle.Office2007Document
        Me.TabControl2.TabIndex = 3
        Me.TabControl2.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
        Me.TabControl2.Tabs.Add(Me.TabItem1)
        Me.TabControl2.Tabs.Add(Me.TabItem2)
        Me.TabControl2.Tabs.Add(Me.TabItem3)
        Me.TabControl2.Text = "TabControl2"
        '
        'TabControlPanel1
        '
        Me.TabControlPanel1.Controls.Add(Me.tvATDR)
        Me.TabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel1.Location = New System.Drawing.Point(0, 22)
        Me.TabControlPanel1.Name = "TabControlPanel1"
        Me.TabControlPanel1.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel1.Size = New System.Drawing.Size(375, 398)
        Me.TabControlPanel1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.TabControlPanel1.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(157, Byte), Integer), CType(CType(188, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.TabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel1.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
        Me.TabControlPanel1.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                    Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel1.Style.GradientAngle = 90
        Me.TabControlPanel1.TabIndex = 1
        Me.TabControlPanel1.TabItem = Me.TabItem1
        '
        'tvATDR
        '
        Me.tvATDR.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tvATDR.CheckBoxes = True
        Me.tvATDR.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvATDR.Location = New System.Drawing.Point(1, 1)
        Me.tvATDR.Name = "tvATDR"
        Me.tvATDR.Size = New System.Drawing.Size(373, 396)
        Me.tvATDR.TabIndex = 1
        '
        'TabItem1
        '
        Me.TabItem1.AttachedControl = Me.TabControlPanel1
        Me.TabItem1.Name = "TabItem1"
        Me.TabItem1.Text = "Autoridad Local del Agua"
        '
        'TabControlPanel3
        '
        Me.TabControlPanel3.Controls.Add(Me.tvCR)
        Me.TabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel3.Location = New System.Drawing.Point(0, 22)
        Me.TabControlPanel3.Name = "TabControlPanel3"
        Me.TabControlPanel3.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel3.Size = New System.Drawing.Size(375, 398)
        Me.TabControlPanel3.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.TabControlPanel3.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(157, Byte), Integer), CType(CType(188, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.TabControlPanel3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel3.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
        Me.TabControlPanel3.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                    Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel3.Style.GradientAngle = 90
        Me.TabControlPanel3.TabIndex = 3
        Me.TabControlPanel3.TabItem = Me.TabItem3
        '
        'tvCR
        '
        Me.tvCR.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tvCR.CheckBoxes = True
        Me.tvCR.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvCR.Location = New System.Drawing.Point(1, 1)
        Me.tvCR.Name = "tvCR"
        Me.tvCR.Size = New System.Drawing.Size(373, 396)
        Me.tvCR.TabIndex = 5
        '
        'TabItem3
        '
        Me.TabItem3.AttachedControl = Me.TabControlPanel3
        Me.TabItem3.Name = "TabItem3"
        Me.TabItem3.Text = "Comisión de Regantes"
        '
        'TabControlPanel2
        '
        Me.TabControlPanel2.Controls.Add(Me.tvJU)
        Me.TabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel2.Location = New System.Drawing.Point(0, 22)
        Me.TabControlPanel2.Name = "TabControlPanel2"
        Me.TabControlPanel2.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel2.Size = New System.Drawing.Size(375, 398)
        Me.TabControlPanel2.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.TabControlPanel2.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(157, Byte), Integer), CType(CType(188, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.TabControlPanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel2.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
        Me.TabControlPanel2.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                    Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel2.Style.GradientAngle = 90
        Me.TabControlPanel2.TabIndex = 2
        Me.TabControlPanel2.TabItem = Me.TabItem2
        '
        'tvJU
        '
        Me.tvJU.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tvJU.CheckBoxes = True
        Me.tvJU.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvJU.Location = New System.Drawing.Point(1, 1)
        Me.tvJU.Name = "tvJU"
        Me.tvJU.Size = New System.Drawing.Size(373, 396)
        Me.tvJU.TabIndex = 3
        '
        'TabItem2
        '
        Me.TabItem2.AttachedControl = Me.TabControlPanel2
        Me.TabItem2.Name = "TabItem2"
        Me.TabItem2.Text = "Junta de Usuarios"
        '
        'bgw
        '
        '
        'Bar1
        '
        Me.Bar1.Controls.Add(Me.imgEstadoMsg)
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnSave, Me.ButtonItem1})
        Me.Bar1.Location = New System.Drawing.Point(0, 420)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(375, 25)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Bar1.TabIndex = 7
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'imgEstadoMsg
        '
        Me.imgEstadoMsg.BackColor = System.Drawing.Color.Transparent
        Me.imgEstadoMsg.Image = Global.COBSER.My.Resources.Resources.accept
        Me.imgEstadoMsg.Location = New System.Drawing.Point(4, 0)
        Me.imgEstadoMsg.Name = "imgEstadoMsg"
        Me.imgEstadoMsg.Size = New System.Drawing.Size(30, 25)
        Me.imgEstadoMsg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.imgEstadoMsg.TabIndex = 55
        Me.imgEstadoMsg.TabStop = False
        Me.imgEstadoMsg.Visible = False
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
        'ButtonItem1
        '
        Me.ButtonItem1.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem1.Image = Global.COBSER.My.Resources.Resources.cross
        Me.ButtonItem1.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.ButtonItem1.ImagePaddingHorizontal = 8
        Me.ButtonItem1.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.ButtonItem1.Name = "ButtonItem1"
        Me.ButtonItem1.Text = "Cerrar"
        '
        'frmAdminInterfaces
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(375, 445)
        Me.Controls.Add(Me.TabControl2)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAdminInterfaces"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Administrador de Permisos"
        CType(Me.TabControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl2.ResumeLayout(False)
        Me.TabControlPanel1.ResumeLayout(False)
        Me.TabControlPanel3.ResumeLayout(False)
        Me.TabControlPanel2.ResumeLayout(False)
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Bar1.ResumeLayout(False)
        CType(Me.imgEstadoMsg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl2 As DevComponents.DotNetBar.TabControl
    Friend WithEvents TabControlPanel1 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents tvATDR As System.Windows.Forms.TreeView
    Friend WithEvents TabItem1 As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControlPanel3 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents tvCR As System.Windows.Forms.TreeView
    Friend WithEvents TabItem3 As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControlPanel2 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents tvJU As System.Windows.Forms.TreeView
    Friend WithEvents TabItem2 As DevComponents.DotNetBar.TabItem
    Friend WithEvents bgw As System.ComponentModel.BackgroundWorker
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents btnSave As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents imgEstadoMsg As System.Windows.Forms.PictureBox
    Friend WithEvents ButtonItem1 As DevComponents.DotNetBar.ButtonItem
End Class
