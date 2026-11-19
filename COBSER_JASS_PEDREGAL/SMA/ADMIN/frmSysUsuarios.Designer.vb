<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSysUsuarios
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSysUsuarios))
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Bar1 = New DevComponents.DotNetBar.Bar
        Me.Bar2 = New DevComponents.DotNetBar.Bar
        Me.btnUsuarioNew = New DevComponents.DotNetBar.ButtonItem
        Me.btnUsuarioUpd = New DevComponents.DotNetBar.ButtonItem
        Me.btnusuarioDel = New DevComponents.DotNetBar.ButtonItem
        Me.btnRefresh = New DevComponents.DotNetBar.ButtonItem
        Me.gridUsuarios = New DevComponents.DotNetBar.Controls.DataGridViewX
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridUsuarios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bar1
        '
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar1.Location = New System.Drawing.Point(0, 0)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(738, 25)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Bar1.TabIndex = 19
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'Bar2
        '
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnUsuarioNew, Me.btnUsuarioUpd, Me.btnusuarioDel, Me.btnRefresh})
        Me.Bar2.Location = New System.Drawing.Point(0, 369)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(738, 25)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Bar2.TabIndex = 20
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'btnUsuarioNew
        '
        Me.btnUsuarioNew.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnUsuarioNew.Image = CType(resources.GetObject("btnUsuarioNew.Image"), System.Drawing.Image)
        Me.btnUsuarioNew.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.btnUsuarioNew.ImagePaddingHorizontal = 8
        Me.btnUsuarioNew.Name = "btnUsuarioNew"
        Me.btnUsuarioNew.Text = "Nuevo Usuario"
        '
        'btnUsuarioUpd
        '
        Me.btnUsuarioUpd.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnUsuarioUpd.Image = CType(resources.GetObject("btnUsuarioUpd.Image"), System.Drawing.Image)
        Me.btnUsuarioUpd.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.btnUsuarioUpd.ImagePaddingHorizontal = 8
        Me.btnUsuarioUpd.Name = "btnUsuarioUpd"
        Me.btnUsuarioUpd.Text = "Editar Usuario"
        '
        'btnusuarioDel
        '
        Me.btnusuarioDel.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnusuarioDel.Image = Global.COBSER.My.Resources.Resources.delete
        Me.btnusuarioDel.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.btnusuarioDel.ImagePaddingHorizontal = 8
        Me.btnusuarioDel.Name = "btnusuarioDel"
        Me.btnusuarioDel.Text = "Eliminar Usuario"
        '
        'btnRefresh
        '
        Me.btnRefresh.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnRefresh.Image = Global.COBSER.My.Resources.Resources.arrow_refresh
        Me.btnRefresh.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.btnRefresh.ImagePaddingHorizontal = 8
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Text = "Refrescar"
        '
        'gridUsuarios
        '
        Me.gridUsuarios.AllowUserToAddRows = False
        Me.gridUsuarios.AllowUserToDeleteRows = False
        Me.gridUsuarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.gridUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gridUsuarios.DefaultCellStyle = DataGridViewCellStyle2
        Me.gridUsuarios.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridUsuarios.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.gridUsuarios.Location = New System.Drawing.Point(0, 25)
        Me.gridUsuarios.Name = "gridUsuarios"
        Me.gridUsuarios.ReadOnly = True
        Me.gridUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridUsuarios.Size = New System.Drawing.Size(738, 344)
        Me.gridUsuarios.TabIndex = 21
        '
        'frmSysUsuarios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(738, 394)
        Me.Controls.Add(Me.gridUsuarios)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Name = "frmSysUsuarios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Usuarios"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridUsuarios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents btnUsuarioNew As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents gridUsuarios As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents btnUsuarioUpd As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnusuarioDel As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnRefresh As DevComponents.DotNetBar.ButtonItem
End Class
