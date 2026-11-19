<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUsuarios
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.ExpandablePanel2 = New DevComponents.DotNetBar.ExpandablePanel
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.txtNroUsuarios = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.btnClear = New DevComponents.DotNetBar.ButtonX
        Me.txtRUC = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.txtDNI = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.txtAMaterno = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.txtAPaterno = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.txtNombre = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Bar1 = New DevComponents.DotNetBar.Bar
        Me.btnUsuarioNew = New DevComponents.DotNetBar.ButtonItem
        Me.btnUsuarioUpd = New DevComponents.DotNetBar.ButtonItem
        Me.btnUsuarioDel = New DevComponents.DotNetBar.ButtonItem
        Me.btnPredios = New DevComponents.DotNetBar.ButtonItem
        Me.ButtonItem2 = New DevComponents.DotNetBar.ButtonItem
        Me.btnSeleccionar = New DevComponents.DotNetBar.ButtonItem
        Me.btnExportar = New DevComponents.DotNetBar.ButtonItem
        Me.btnSalir = New DevComponents.DotNetBar.ButtonItem
        Me.gridUsuarios = New DevComponents.DotNetBar.Controls.DataGridViewX
        Me.Label7 = New System.Windows.Forms.Label
        Me.ExpandablePanel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridUsuarios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ExpandablePanel2
        '
        Me.ExpandablePanel2.CanvasColor = System.Drawing.SystemColors.Control
        Me.ExpandablePanel2.CollapseDirection = DevComponents.DotNetBar.eCollapseDirection.RightToLeft
        Me.ExpandablePanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.ExpandablePanel2.Controls.Add(Me.Panel3)
        Me.ExpandablePanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ExpandablePanel2.ExpandButtonVisible = False
        Me.ExpandablePanel2.Location = New System.Drawing.Point(0, 0)
        Me.ExpandablePanel2.Name = "ExpandablePanel2"
        Me.ExpandablePanel2.Size = New System.Drawing.Size(903, 509)
        Me.ExpandablePanel2.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.ExpandablePanel2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.ExpandablePanel2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.ExpandablePanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.ExpandablePanel2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.ExpandablePanel2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
        Me.ExpandablePanel2.Style.GradientAngle = 90
        Me.ExpandablePanel2.TabIndex = 29
        Me.ExpandablePanel2.TitleStyle.Alignment = System.Drawing.StringAlignment.Center
        Me.ExpandablePanel2.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.ExpandablePanel2.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.ExpandablePanel2.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner
        Me.ExpandablePanel2.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.ExpandablePanel2.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.ExpandablePanel2.TitleStyle.GradientAngle = 90
        Me.ExpandablePanel2.TitleText = "Listado de Usuarios"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.txtNroUsuarios)
        Me.Panel3.Controls.Add(Me.GroupPanel1)
        Me.Panel3.Controls.Add(Me.Bar1)
        Me.Panel3.Controls.Add(Me.gridUsuarios)
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 26)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(903, 483)
        Me.Panel3.TabIndex = 25
        '
        'txtNroUsuarios
        '
        Me.txtNroUsuarios.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        '
        '
        '
        Me.txtNroUsuarios.Border.Class = "TextBoxBorder"
        Me.txtNroUsuarios.Location = New System.Drawing.Point(791, 147)
        Me.txtNroUsuarios.Name = "txtNroUsuarios"
        Me.txtNroUsuarios.ReadOnly = True
        Me.txtNroUsuarios.Size = New System.Drawing.Size(81, 20)
        Me.txtNroUsuarios.TabIndex = 1
        '
        'GroupPanel1
        '
        Me.GroupPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.btnClear)
        Me.GroupPanel1.Controls.Add(Me.txtRUC)
        Me.GroupPanel1.Controls.Add(Me.txtDNI)
        Me.GroupPanel1.Controls.Add(Me.txtAMaterno)
        Me.GroupPanel1.Controls.Add(Me.txtAPaterno)
        Me.GroupPanel1.Controls.Add(Me.txtNombre)
        Me.GroupPanel1.Controls.Add(Me.Label6)
        Me.GroupPanel1.Controls.Add(Me.Label5)
        Me.GroupPanel1.Controls.Add(Me.Label4)
        Me.GroupPanel1.Controls.Add(Me.Label3)
        Me.GroupPanel1.Controls.Add(Me.Label2)
        Me.GroupPanel1.DrawTitleBox = False
        Me.GroupPanel1.Location = New System.Drawing.Point(29, 9)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(852, 129)
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
        Me.GroupPanel1.TabIndex = 32
        Me.GroupPanel1.Text = "Criterios de busqueda"
        '
        'btnClear
        '
        Me.btnClear.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnClear.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnClear.Image = Global.COBSER.My.Resources.Resources.lightning
        Me.btnClear.Location = New System.Drawing.Point(685, 1)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(123, 20)
        Me.btnClear.TabIndex = 10
        Me.btnClear.Text = "Nueva Consulta"
        Me.btnClear.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left
        '
        'txtRUC
        '
        '
        '
        '
        Me.txtRUC.Border.Class = "TextBoxBorder"
        Me.txtRUC.Location = New System.Drawing.Point(420, 0)
        Me.txtRUC.Name = "txtRUC"
        Me.txtRUC.Size = New System.Drawing.Size(151, 20)
        Me.txtRUC.TabIndex = 9
        Me.txtRUC.WatermarkText = "RUC del Usuario"
        '
        'txtDNI
        '
        '
        '
        '
        Me.txtDNI.Border.Class = "TextBoxBorder"
        Me.txtDNI.Location = New System.Drawing.Point(146, 0)
        Me.txtDNI.Name = "txtDNI"
        Me.txtDNI.Size = New System.Drawing.Size(137, 20)
        Me.txtDNI.TabIndex = 7
        Me.txtDNI.WatermarkText = "DNI del Usuario"
        '
        'txtAMaterno
        '
        Me.txtAMaterno.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        '
        '
        '
        Me.txtAMaterno.Border.Class = "TextBoxBorder"
        Me.txtAMaterno.Location = New System.Drawing.Point(146, 81)
        Me.txtAMaterno.Name = "txtAMaterno"
        Me.txtAMaterno.Size = New System.Drawing.Size(674, 20)
        Me.txtAMaterno.TabIndex = 6
        Me.txtAMaterno.WatermarkText = "Apellido Materno del Usuario"
        '
        'txtAPaterno
        '
        Me.txtAPaterno.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        '
        '
        '
        Me.txtAPaterno.Border.Class = "TextBoxBorder"
        Me.txtAPaterno.Location = New System.Drawing.Point(146, 55)
        Me.txtAPaterno.Name = "txtAPaterno"
        Me.txtAPaterno.Size = New System.Drawing.Size(674, 20)
        Me.txtAPaterno.TabIndex = 5
        Me.txtAPaterno.WatermarkText = "Apellido Paterno del Usuario"
        '
        'txtNombre
        '
        Me.txtNombre.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        '
        '
        '
        Me.txtNombre.Border.Class = "TextBoxBorder"
        Me.txtNombre.Location = New System.Drawing.Point(146, 26)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(674, 20)
        Me.txtNombre.TabIndex = 4
        Me.txtNombre.WatermarkText = "Nombre o Razón Social del Usuario"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(371, 2)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(33, 13)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "RUC:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(20, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(29, 13)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "DNI:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(20, 83)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "A. Materno:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(20, 57)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "A. Paterno:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(20, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(122, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Nombre o Razon Social:"
        '
        'Bar1
        '
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnUsuarioNew, Me.btnUsuarioUpd, Me.btnUsuarioDel, Me.btnPredios, Me.btnSeleccionar, Me.btnExportar, Me.btnSalir})
        Me.Bar1.Location = New System.Drawing.Point(0, 458)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(903, 25)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Bar1.TabIndex = 30
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'btnUsuarioNew
        '
        Me.btnUsuarioNew.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnUsuarioNew.Image = Global.COBSER.My.Resources.Resources.add
        Me.btnUsuarioNew.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.btnUsuarioNew.ImagePaddingHorizontal = 8
        Me.btnUsuarioNew.Name = "btnUsuarioNew"
        Me.btnUsuarioNew.Text = "Nuevo "
        '
        'btnUsuarioUpd
        '
        Me.btnUsuarioUpd.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnUsuarioUpd.Image = Global.COBSER.My.Resources.Resources.pencil
        Me.btnUsuarioUpd.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.btnUsuarioUpd.ImagePaddingHorizontal = 8
        Me.btnUsuarioUpd.Name = "btnUsuarioUpd"
        Me.btnUsuarioUpd.Text = "Editar"
        '
        'btnUsuarioDel
        '
        Me.btnUsuarioDel.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnUsuarioDel.Image = Global.COBSER.My.Resources.Resources.delete
        Me.btnUsuarioDel.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.btnUsuarioDel.ImagePaddingHorizontal = 8
        Me.btnUsuarioDel.Name = "btnUsuarioDel"
        Me.btnUsuarioDel.Text = "Eliminar "
        '
        'btnPredios
        '
        Me.btnPredios.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnPredios.Image = Global.COBSER.My.Resources.Resources.list_users
        Me.btnPredios.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.btnPredios.ImagePaddingHorizontal = 8
        Me.btnPredios.Name = "btnPredios"
        Me.btnPredios.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem2})
        Me.btnPredios.Text = "Predios Urbanos"
        '
        'ButtonItem2
        '
        Me.ButtonItem2.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.ButtonItem2.ImagePaddingHorizontal = 8
        Me.ButtonItem2.Name = "ButtonItem2"
        Me.ButtonItem2.Text = "Reporte Predios de Usuarios"
        '
        'btnSeleccionar
        '
        Me.btnSeleccionar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnSeleccionar.Image = Global.COBSER.My.Resources.Resources.accept
        Me.btnSeleccionar.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.btnSeleccionar.ImagePaddingHorizontal = 8
        Me.btnSeleccionar.Name = "btnSeleccionar"
        Me.btnSeleccionar.Text = "Seleccionar"
        '
        'btnExportar
        '
        Me.btnExportar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnExportar.Image = Global.COBSER.My.Resources.Resources.page_white_excel
        Me.btnExportar.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.btnExportar.ImagePaddingHorizontal = 8
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Text = "Exportar a Excel"
        '
        'btnSalir
        '
        Me.btnSalir.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnSalir.EnableMarkup = False
        Me.btnSalir.Image = Global.COBSER.My.Resources.Resources.page_right
        Me.btnSalir.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.btnSalir.ImagePaddingHorizontal = 8
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Text = "Salir"
        '
        'gridUsuarios
        '
        Me.gridUsuarios.AllowUserToAddRows = False
        Me.gridUsuarios.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gridUsuarios.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.gridUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gridUsuarios.DefaultCellStyle = DataGridViewCellStyle2
        Me.gridUsuarios.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.gridUsuarios.Location = New System.Drawing.Point(5, 182)
        Me.gridUsuarios.Name = "gridUsuarios"
        Me.gridUsuarios.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gridUsuarios.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.gridUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridUsuarios.Size = New System.Drawing.Size(894, 270)
        Me.gridUsuarios.TabIndex = 2
        Me.gridUsuarios.VirtualMode = True
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(717, 151)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(66, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Nº Usuarios:"
        '
        'frmUsuarios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(903, 509)
        Me.Controls.Add(Me.ExpandablePanel2)
        Me.Name = "frmUsuarios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Usuarios del Servicio"
        Me.ExpandablePanel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupPanel1.PerformLayout()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridUsuarios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ExpandablePanel2 As DevComponents.DotNetBar.ExpandablePanel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents txtNroUsuarios As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents btnClear As DevComponents.DotNetBar.ButtonX
    Friend WithEvents txtRUC As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtDNI As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtAMaterno As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtAPaterno As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtNombre As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents btnUsuarioNew As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnUsuarioUpd As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnUsuarioDel As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnPredios As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem2 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnExportar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnSalir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents gridUsuarios As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnSeleccionar As DevComponents.DotNetBar.ButtonItem
End Class
