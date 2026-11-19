<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSysGrupos
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Bar1 = New DevComponents.DotNetBar.Bar
        Me.btnNew = New DevComponents.DotNetBar.ButtonItem
        Me.btnUpd = New DevComponents.DotNetBar.ButtonItem
        Me.btnDel = New DevComponents.DotNetBar.ButtonItem
        Me.btnPermisos = New DevComponents.DotNetBar.ButtonItem
        Me.btnRefresh = New DevComponents.DotNetBar.ButtonItem
        Me.Bar2 = New DevComponents.DotNetBar.Bar
        Me.gridGrupos = New DevComponents.DotNetBar.Controls.DataGridViewX
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridGrupos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bar1
        '
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnNew, Me.btnUpd, Me.btnDel, Me.btnPermisos, Me.btnRefresh})
        Me.Bar1.Location = New System.Drawing.Point(0, 331)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(773, 25)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Bar1.TabIndex = 17
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'btnNew
        '
        Me.btnNew.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnNew.Image = Global.COBSER.My.Resources.Resources.add
        Me.btnNew.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.btnNew.ImagePaddingHorizontal = 8
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Text = "Nuevo Grupo"
        '
        'btnUpd
        '
        Me.btnUpd.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnUpd.Image = Global.COBSER.My.Resources.Resources.pencil
        Me.btnUpd.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.btnUpd.ImagePaddingHorizontal = 8
        Me.btnUpd.Name = "btnUpd"
        Me.btnUpd.Text = "Editar Grupo"
        '
        'btnDel
        '
        Me.btnDel.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnDel.Image = Global.COBSER.My.Resources.Resources.delete
        Me.btnDel.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.btnDel.ImagePaddingHorizontal = 8
        Me.btnDel.Name = "btnDel"
        Me.btnDel.Text = "Eliminar Grupo"
        '
        'btnPermisos
        '
        Me.btnPermisos.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnPermisos.Image = Global.COBSER.My.Resources.Resources.list_users
        Me.btnPermisos.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.btnPermisos.ImagePaddingHorizontal = 8
        Me.btnPermisos.Name = "btnPermisos"
        Me.btnPermisos.Text = "Permisos"
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
        'Bar2
        '
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar2.Location = New System.Drawing.Point(0, 0)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(773, 25)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Bar2.TabIndex = 19
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'gridGrupos
        '
        Me.gridGrupos.AllowUserToAddRows = False
        Me.gridGrupos.AllowUserToDeleteRows = False
        Me.gridGrupos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gridGrupos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.gridGrupos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gridGrupos.DefaultCellStyle = DataGridViewCellStyle1
        Me.gridGrupos.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.gridGrupos.Location = New System.Drawing.Point(0, 25)
        Me.gridGrupos.MultiSelect = False
        Me.gridGrupos.Name = "gridGrupos"
        Me.gridGrupos.ReadOnly = True
        Me.gridGrupos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridGrupos.Size = New System.Drawing.Size(773, 306)
        Me.gridGrupos.TabIndex = 20
        '
        'frmSysGrupos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(773, 356)
        Me.Controls.Add(Me.gridGrupos)
        Me.Controls.Add(Me.Bar2)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.Name = "frmSysGrupos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Grupos de Usuarios"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridGrupos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents btnNew As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnUpd As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnDel As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnPermisos As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents gridGrupos As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents btnRefresh As DevComponents.DotNetBar.ButtonItem
End Class
