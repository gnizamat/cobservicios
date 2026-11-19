<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSysPermisos
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
        Me.Bar1 = New DevComponents.DotNetBar.Bar
        Me.imgEstadoMsg = New System.Windows.Forms.PictureBox
        Me.btnSave = New DevComponents.DotNetBar.ButtonItem
        Me.btnCancel = New DevComponents.DotNetBar.ButtonItem
        Me.ControlContainerItem4 = New DevComponents.DotNetBar.ControlContainerItem
        Me.ControlContainerItem1 = New DevComponents.DotNetBar.ControlContainerItem
        Me.ControlContainerItem2 = New DevComponents.DotNetBar.ControlContainerItem
        Me.Bar2 = New DevComponents.DotNetBar.Bar
        Me.tvPermisos = New System.Windows.Forms.TreeView
        Me.bgw = New System.ComponentModel.BackgroundWorker
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.lblEstadoMsg = New DevComponents.DotNetBar.LabelX
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Bar1.SuspendLayout()
        CType(Me.imgEstadoMsg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bar1
        '
        Me.Bar1.Controls.Add(Me.imgEstadoMsg)
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnSave, Me.btnCancel, Me.ControlContainerItem4})
        Me.Bar1.Location = New System.Drawing.Point(0, 442)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(402, 30)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Bar1.TabIndex = 17
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'imgEstadoMsg
        '
        Me.imgEstadoMsg.BackColor = System.Drawing.Color.Transparent
        Me.imgEstadoMsg.Image = Global.COBSER.My.Resources.Resources.accept
        Me.imgEstadoMsg.Location = New System.Drawing.Point(377, 2)
        Me.imgEstadoMsg.Name = "imgEstadoMsg"
        Me.imgEstadoMsg.Size = New System.Drawing.Size(22, 25)
        Me.imgEstadoMsg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.imgEstadoMsg.TabIndex = 54
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
        'btnCancel
        '
        Me.btnCancel.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnCancel.Image = Global.COBSER.My.Resources.Resources.cross
        Me.btnCancel.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.btnCancel.ImagePaddingHorizontal = 8
        Me.btnCancel.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Text = "Cerrar"
        '
        'ControlContainerItem4
        '
        Me.ControlContainerItem4.AllowItemResize = False
        Me.ControlContainerItem4.Control = Me.imgEstadoMsg
        Me.ControlContainerItem4.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
        Me.ControlContainerItem4.Name = "ControlContainerItem4"
        '
        'ControlContainerItem1
        '
        Me.ControlContainerItem1.AllowItemResize = False
        Me.ControlContainerItem1.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
        Me.ControlContainerItem1.Name = "ControlContainerItem1"
        '
        'ControlContainerItem2
        '
        Me.ControlContainerItem2.AllowItemResize = False
        Me.ControlContainerItem2.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
        Me.ControlContainerItem2.Name = "ControlContainerItem2"
        '
        'Bar2
        '
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar2.Location = New System.Drawing.Point(0, 0)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(402, 25)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Bar2.TabIndex = 18
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'tvPermisos
        '
        Me.tvPermisos.CheckBoxes = True
        Me.tvPermisos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvPermisos.FullRowSelect = True
        Me.tvPermisos.Location = New System.Drawing.Point(0, 25)
        Me.tvPermisos.Name = "tvPermisos"
        Me.tvPermisos.Size = New System.Drawing.Size(402, 417)
        Me.tvPermisos.TabIndex = 19
        '
        'bgw
        '
        '
        'lblEstadoMsg
        '
        Me.lblEstadoMsg.BackColor = System.Drawing.Color.Transparent
        Me.lblEstadoMsg.Location = New System.Drawing.Point(29, 4)
        Me.lblEstadoMsg.Name = "lblEstadoMsg"
        Me.lblEstadoMsg.Size = New System.Drawing.Size(282, 20)
        Me.lblEstadoMsg.TabIndex = 55
        Me.lblEstadoMsg.Text = "Ejecutando consulta. Espere un momento porfavor."
        Me.lblEstadoMsg.Visible = False
        '
        'frmSysPermisos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(402, 472)
        Me.Controls.Add(Me.tvPermisos)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSysPermisos"
        Me.Text = "Permisos"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Bar1.ResumeLayout(False)
        CType(Me.imgEstadoMsg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents ControlContainerItem1 As DevComponents.DotNetBar.ControlContainerItem
    Friend WithEvents ControlContainerItem2 As DevComponents.DotNetBar.ControlContainerItem
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents tvPermisos As System.Windows.Forms.TreeView
    Friend WithEvents btnSave As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnCancel As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents bgw As System.ComponentModel.BackgroundWorker
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents lblEstadoMsg As DevComponents.DotNetBar.LabelX
    Friend WithEvents imgEstadoMsg As System.Windows.Forms.PictureBox
    Friend WithEvents ControlContainerItem4 As DevComponents.DotNetBar.ControlContainerItem
End Class
