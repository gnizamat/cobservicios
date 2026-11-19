<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLecturaNew
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
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.txtCodigoM = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.LabelX26 = New DevComponents.DotNetBar.LabelX
        Me.LabelX25 = New DevComponents.DotNetBar.LabelX
        Me.cmbMedidor = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.LabelX24 = New DevComponents.DotNetBar.LabelX
        Me.LabelX15 = New DevComponents.DotNetBar.LabelX
        Me.txtMonto = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.LabelX9 = New DevComponents.DotNetBar.LabelX
        Me.txtCosto = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.txtAnio = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.LabelX8 = New DevComponents.DotNetBar.LabelX
        Me.cmbColaborador = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.ComboItem3 = New DevComponents.Editors.ComboItem
        Me.ComboItem4 = New DevComponents.Editors.ComboItem
        Me.ExpandablePanel2 = New DevComponents.DotNetBar.ExpandablePanel
        Me.gridLecturas = New DevComponents.DotNetBar.Controls.DataGridViewX
        Me.LabelX12 = New DevComponents.DotNetBar.LabelX
        Me.txtTotalLA = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.LabelX23 = New DevComponents.DotNetBar.LabelX
        Me.txtTotalUlt = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.LabelX10 = New DevComponents.DotNetBar.LabelX
        Me.txtCodigo = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.txtLote = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.LabelX22 = New DevComponents.DotNetBar.LabelX
        Me.txtLt = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.txtM3 = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.LabelX21 = New DevComponents.DotNetBar.LabelX
        Me.cv = New DevComponents.DotNetBar.LabelX
        Me.txtLtActual = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.LabelX19 = New DevComponents.DotNetBar.LabelX
        Me.txtFActual = New DevComponents.Editors.DateTimeAdv.DateTimeInput
        Me.txtM3Actual = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.LabelX20 = New DevComponents.DotNetBar.LabelX
        Me.LabelX17 = New DevComponents.DotNetBar.LabelX
        Me.txtLtUlt = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.LabelX16 = New DevComponents.DotNetBar.LabelX
        Me.LabelX13 = New DevComponents.DotNetBar.LabelX
        Me.txtFUltima = New DevComponents.Editors.DateTimeAdv.DateTimeInput
        Me.LabelX11 = New DevComponents.DotNetBar.LabelX
        Me.txtFecha = New DevComponents.Editors.DateTimeAdv.DateTimeInput
        Me.LabelX18 = New DevComponents.DotNetBar.LabelX
        Me.cmbMes = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.ComboItem1 = New DevComponents.Editors.ComboItem
        Me.ComboItem2 = New DevComponents.Editors.ComboItem
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX
        Me.cmbAnio = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX
        Me.Bar6 = New DevComponents.DotNetBar.Bar
        Me.btnSalir = New DevComponents.DotNetBar.ButtonItem
        Me.ButtonItem1 = New DevComponents.DotNetBar.ButtonItem
        Me.btnEliminar = New DevComponents.DotNetBar.ButtonItem
        Me.btnGrabar = New DevComponents.DotNetBar.ButtonItem
        Me.btnNuevo = New DevComponents.DotNetBar.ButtonItem
        Me.LabelX14 = New DevComponents.DotNetBar.LabelX
        Me.txtM3Ult = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX
        Me.txtNombre = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.txtNro = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.txtDNI = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX
        Me.cmbJunta = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX
        Me.btAgregar = New DevComponents.DotNetBar.ButtonItem
        Me.btnEditar = New DevComponents.DotNetBar.ButtonItem
        Me.btnDel = New DevComponents.DotNetBar.ButtonItem
        Me.btnRefrescar = New DevComponents.DotNetBar.ButtonItem
        Me.GroupPanel1.SuspendLayout()
        Me.ExpandablePanel2.SuspendLayout()
        CType(Me.gridLecturas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFActual, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFUltima, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.txtCodigoM)
        Me.GroupPanel1.Controls.Add(Me.LabelX26)
        Me.GroupPanel1.Controls.Add(Me.LabelX25)
        Me.GroupPanel1.Controls.Add(Me.cmbMedidor)
        Me.GroupPanel1.Controls.Add(Me.LabelX24)
        Me.GroupPanel1.Controls.Add(Me.LabelX15)
        Me.GroupPanel1.Controls.Add(Me.txtMonto)
        Me.GroupPanel1.Controls.Add(Me.LabelX9)
        Me.GroupPanel1.Controls.Add(Me.txtCosto)
        Me.GroupPanel1.Controls.Add(Me.txtAnio)
        Me.GroupPanel1.Controls.Add(Me.LabelX8)
        Me.GroupPanel1.Controls.Add(Me.cmbColaborador)
        Me.GroupPanel1.Controls.Add(Me.ExpandablePanel2)
        Me.GroupPanel1.Controls.Add(Me.LabelX12)
        Me.GroupPanel1.Controls.Add(Me.txtTotalLA)
        Me.GroupPanel1.Controls.Add(Me.LabelX23)
        Me.GroupPanel1.Controls.Add(Me.txtTotalUlt)
        Me.GroupPanel1.Controls.Add(Me.LabelX10)
        Me.GroupPanel1.Controls.Add(Me.txtCodigo)
        Me.GroupPanel1.Controls.Add(Me.txtLote)
        Me.GroupPanel1.Controls.Add(Me.LabelX22)
        Me.GroupPanel1.Controls.Add(Me.txtLt)
        Me.GroupPanel1.Controls.Add(Me.txtM3)
        Me.GroupPanel1.Controls.Add(Me.LabelX21)
        Me.GroupPanel1.Controls.Add(Me.cv)
        Me.GroupPanel1.Controls.Add(Me.txtLtActual)
        Me.GroupPanel1.Controls.Add(Me.LabelX19)
        Me.GroupPanel1.Controls.Add(Me.txtFActual)
        Me.GroupPanel1.Controls.Add(Me.txtM3Actual)
        Me.GroupPanel1.Controls.Add(Me.LabelX20)
        Me.GroupPanel1.Controls.Add(Me.LabelX17)
        Me.GroupPanel1.Controls.Add(Me.txtLtUlt)
        Me.GroupPanel1.Controls.Add(Me.LabelX16)
        Me.GroupPanel1.Controls.Add(Me.LabelX13)
        Me.GroupPanel1.Controls.Add(Me.txtFUltima)
        Me.GroupPanel1.Controls.Add(Me.LabelX11)
        Me.GroupPanel1.Controls.Add(Me.txtFecha)
        Me.GroupPanel1.Controls.Add(Me.LabelX18)
        Me.GroupPanel1.Controls.Add(Me.cmbMes)
        Me.GroupPanel1.Controls.Add(Me.LabelX3)
        Me.GroupPanel1.Controls.Add(Me.cmbAnio)
        Me.GroupPanel1.Controls.Add(Me.LabelX2)
        Me.GroupPanel1.Controls.Add(Me.Bar6)
        Me.GroupPanel1.Controls.Add(Me.LabelX14)
        Me.GroupPanel1.Controls.Add(Me.txtM3Ult)
        Me.GroupPanel1.Controls.Add(Me.LabelX6)
        Me.GroupPanel1.Controls.Add(Me.txtNombre)
        Me.GroupPanel1.Controls.Add(Me.txtNro)
        Me.GroupPanel1.Controls.Add(Me.txtDNI)
        Me.GroupPanel1.Controls.Add(Me.LabelX7)
        Me.GroupPanel1.Controls.Add(Me.LabelX4)
        Me.GroupPanel1.Controls.Add(Me.LabelX5)
        Me.GroupPanel1.Controls.Add(Me.cmbJunta)
        Me.GroupPanel1.Controls.Add(Me.LabelX1)
        Me.GroupPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(641, 541)
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
        Me.GroupPanel1.TabIndex = 43
        Me.GroupPanel1.Text = "Nueva Lectura"
        '
        'txtCodigoM
        '
        '
        '
        '
        Me.txtCodigoM.Border.Class = "TextBoxBorder"
        Me.txtCodigoM.Enabled = False
        Me.txtCodigoM.Location = New System.Drawing.Point(472, 107)
        Me.txtCodigoM.Name = "txtCodigoM"
        Me.txtCodigoM.Size = New System.Drawing.Size(133, 20)
        Me.txtCodigoM.TabIndex = 214
        '
        'LabelX26
        '
        Me.LabelX26.AutoSize = True
        Me.LabelX26.BackColor = System.Drawing.Color.Transparent
        Me.LabelX26.Location = New System.Drawing.Point(396, 110)
        Me.LabelX26.Name = "LabelX26"
        Me.LabelX26.Size = New System.Drawing.Size(71, 15)
        Me.LabelX26.TabIndex = 213
        Me.LabelX26.Text = "Nº de Codigo:"
        '
        'LabelX25
        '
        Me.LabelX25.AutoSize = True
        Me.LabelX25.BackColor = System.Drawing.Color.Transparent
        Me.LabelX25.Location = New System.Drawing.Point(15, 107)
        Me.LabelX25.Name = "LabelX25"
        Me.LabelX25.Size = New System.Drawing.Size(42, 15)
        Me.LabelX25.TabIndex = 212
        Me.LabelX25.Text = "Medidor"
        '
        'cmbMedidor
        '
        Me.cmbMedidor.DisplayMember = "Text"
        Me.cmbMedidor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbMedidor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMedidor.FormattingEnabled = True
        Me.cmbMedidor.ItemHeight = 14
        Me.cmbMedidor.Location = New System.Drawing.Point(101, 107)
        Me.cmbMedidor.Name = "cmbMedidor"
        Me.cmbMedidor.Size = New System.Drawing.Size(168, 20)
        Me.cmbMedidor.TabIndex = 211
        '
        'LabelX24
        '
        Me.LabelX24.AutoSize = True
        Me.LabelX24.BackColor = System.Drawing.Color.Transparent
        Me.LabelX24.Location = New System.Drawing.Point(13, 128)
        Me.LabelX24.Name = "LabelX24"
        Me.LabelX24.Size = New System.Drawing.Size(616, 15)
        Me.LabelX24.TabIndex = 210
        Me.LabelX24.Text = "_________________________________________________________________________________" & _
            "____________________"
        '
        'LabelX15
        '
        Me.LabelX15.AutoSize = True
        Me.LabelX15.BackColor = System.Drawing.Color.Transparent
        Me.LabelX15.Location = New System.Drawing.Point(438, 256)
        Me.LabelX15.Name = "LabelX15"
        Me.LabelX15.Size = New System.Drawing.Size(52, 15)
        Me.LabelX15.TabIndex = 209
        Me.LabelX15.Text = "Monto S/.:"
        '
        'txtMonto
        '
        '
        '
        '
        Me.txtMonto.Border.Class = "TextBoxBorder"
        Me.txtMonto.Enabled = False
        Me.txtMonto.Location = New System.Drawing.Point(491, 255)
        Me.txtMonto.Name = "txtMonto"
        Me.txtMonto.Size = New System.Drawing.Size(114, 20)
        Me.txtMonto.TabIndex = 208
        '
        'LabelX9
        '
        Me.LabelX9.AutoSize = True
        Me.LabelX9.BackColor = System.Drawing.Color.Transparent
        Me.LabelX9.Location = New System.Drawing.Point(334, 255)
        Me.LabelX9.Name = "LabelX9"
        Me.LabelX9.Size = New System.Drawing.Size(50, 15)
        Me.LabelX9.TabIndex = 207
        Me.LabelX9.Text = "Valor M3:"
        '
        'txtCosto
        '
        '
        '
        '
        Me.txtCosto.Border.Class = "TextBoxBorder"
        Me.txtCosto.Enabled = False
        Me.txtCosto.Location = New System.Drawing.Point(390, 253)
        Me.txtCosto.Name = "txtCosto"
        Me.txtCosto.Size = New System.Drawing.Size(42, 20)
        Me.txtCosto.TabIndex = 206
        '
        'txtAnio
        '
        '
        '
        '
        Me.txtAnio.Border.Class = "TextBoxBorder"
        Me.txtAnio.Enabled = False
        Me.txtAnio.Location = New System.Drawing.Point(475, 3)
        Me.txtAnio.Name = "txtAnio"
        Me.txtAnio.Size = New System.Drawing.Size(130, 20)
        Me.txtAnio.TabIndex = 205
        '
        'LabelX8
        '
        Me.LabelX8.AutoSize = True
        Me.LabelX8.BackColor = System.Drawing.Color.Transparent
        Me.LabelX8.Location = New System.Drawing.Point(401, 4)
        Me.LabelX8.Name = "LabelX8"
        Me.LabelX8.Size = New System.Drawing.Size(71, 15)
        Me.LabelX8.TabIndex = 204
        Me.LabelX8.Text = "Año de Tarifa:"
        '
        'cmbColaborador
        '
        Me.cmbColaborador.DisplayMember = "Text"
        Me.cmbColaborador.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbColaborador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbColaborador.FormattingEnabled = True
        Me.cmbColaborador.ItemHeight = 14
        Me.cmbColaborador.Items.AddRange(New Object() {Me.ComboItem3, Me.ComboItem4})
        Me.cmbColaborador.Location = New System.Drawing.Point(101, 285)
        Me.cmbColaborador.Name = "cmbColaborador"
        Me.cmbColaborador.Size = New System.Drawing.Size(504, 20)
        Me.cmbColaborador.TabIndex = 203
        '
        'ComboItem3
        '
        Me.ComboItem3.Text = "I"
        Me.ComboItem3.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'ComboItem4
        '
        Me.ComboItem4.Text = "II"
        Me.ComboItem4.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'ExpandablePanel2
        '
        Me.ExpandablePanel2.CanvasColor = System.Drawing.SystemColors.Control
        Me.ExpandablePanel2.CollapseDirection = DevComponents.DotNetBar.eCollapseDirection.RightToLeft
        Me.ExpandablePanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.ExpandablePanel2.Controls.Add(Me.gridLecturas)
        Me.ExpandablePanel2.ExpandButtonVisible = False
        Me.ExpandablePanel2.Location = New System.Drawing.Point(0, 313)
        Me.ExpandablePanel2.Name = "ExpandablePanel2"
        Me.ExpandablePanel2.Size = New System.Drawing.Size(630, 179)
        Me.ExpandablePanel2.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.ExpandablePanel2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.ExpandablePanel2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.ExpandablePanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.ExpandablePanel2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.ExpandablePanel2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
        Me.ExpandablePanel2.Style.GradientAngle = 90
        Me.ExpandablePanel2.TabIndex = 202
        Me.ExpandablePanel2.TitleStyle.Alignment = System.Drawing.StringAlignment.Center
        Me.ExpandablePanel2.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.ExpandablePanel2.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.ExpandablePanel2.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner
        Me.ExpandablePanel2.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.ExpandablePanel2.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.ExpandablePanel2.TitleStyle.GradientAngle = 90
        Me.ExpandablePanel2.TitleText = "Listado de Lecturas"
        '
        'gridLecturas
        '
        Me.gridLecturas.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.gridLecturas.AllowUserToAddRows = False
        Me.gridLecturas.AllowUserToDeleteRows = False
        Me.gridLecturas.AllowUserToResizeRows = False
        Me.gridLecturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gridLecturas.DefaultCellStyle = DataGridViewCellStyle1
        Me.gridLecturas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridLecturas.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.gridLecturas.Location = New System.Drawing.Point(0, 26)
        Me.gridLecturas.MultiSelect = False
        Me.gridLecturas.Name = "gridLecturas"
        Me.gridLecturas.ReadOnly = True
        Me.gridLecturas.RowHeadersVisible = False
        Me.gridLecturas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridLecturas.Size = New System.Drawing.Size(630, 153)
        Me.gridLecturas.TabIndex = 200
        '
        'LabelX12
        '
        Me.LabelX12.AutoSize = True
        Me.LabelX12.BackColor = System.Drawing.Color.Transparent
        Me.LabelX12.Location = New System.Drawing.Point(13, 86)
        Me.LabelX12.Name = "LabelX12"
        Me.LabelX12.Size = New System.Drawing.Size(616, 15)
        Me.LabelX12.TabIndex = 97
        Me.LabelX12.Text = "_________________________________________________________________________________" & _
            "____________________"
        '
        'txtTotalLA
        '
        '
        '
        '
        Me.txtTotalLA.Border.Class = "TextBoxBorder"
        Me.txtTotalLA.Location = New System.Drawing.Point(491, 225)
        Me.txtTotalLA.Name = "txtTotalLA"
        Me.txtTotalLA.Size = New System.Drawing.Size(114, 20)
        Me.txtTotalLA.TabIndex = 94
        '
        'LabelX23
        '
        Me.LabelX23.AutoSize = True
        Me.LabelX23.BackColor = System.Drawing.Color.Transparent
        Me.LabelX23.Location = New System.Drawing.Point(438, 225)
        Me.LabelX23.Name = "LabelX23"
        Me.LabelX23.Size = New System.Drawing.Size(47, 15)
        Me.LabelX23.TabIndex = 93
        Me.LabelX23.Text = "Total(Lt.)"
        '
        'txtTotalUlt
        '
        '
        '
        '
        Me.txtTotalUlt.Border.Class = "TextBoxBorder"
        Me.txtTotalUlt.Enabled = False
        Me.txtTotalUlt.Location = New System.Drawing.Point(491, 187)
        Me.txtTotalUlt.Name = "txtTotalUlt"
        Me.txtTotalUlt.Size = New System.Drawing.Size(114, 20)
        Me.txtTotalUlt.TabIndex = 92
        '
        'LabelX10
        '
        Me.LabelX10.AutoSize = True
        Me.LabelX10.BackColor = System.Drawing.Color.Transparent
        Me.LabelX10.Location = New System.Drawing.Point(438, 189)
        Me.LabelX10.Name = "LabelX10"
        Me.LabelX10.Size = New System.Drawing.Size(47, 15)
        Me.LabelX10.TabIndex = 91
        Me.LabelX10.Text = "Total(Lt.)"
        '
        'txtCodigo
        '
        '
        '
        '
        Me.txtCodigo.Border.Class = "TextBoxBorder"
        Me.txtCodigo.Enabled = False
        Me.txtCodigo.Location = New System.Drawing.Point(472, 66)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(133, 20)
        Me.txtCodigo.TabIndex = 90
        '
        'txtLote
        '
        '
        '
        '
        Me.txtLote.Border.Class = "TextBoxBorder"
        Me.txtLote.Enabled = False
        Me.txtLote.Location = New System.Drawing.Point(262, 64)
        Me.txtLote.Name = "txtLote"
        Me.txtLote.Size = New System.Drawing.Size(127, 20)
        Me.txtLote.TabIndex = 89
        '
        'LabelX22
        '
        Me.LabelX22.AutoSize = True
        Me.LabelX22.BackColor = System.Drawing.Color.Transparent
        Me.LabelX22.Location = New System.Drawing.Point(230, 253)
        Me.LabelX22.Name = "LabelX22"
        Me.LabelX22.Size = New System.Drawing.Size(15, 15)
        Me.LabelX22.TabIndex = 87
        Me.LabelX22.Text = "Lt."
        '
        'txtLt
        '
        '
        '
        '
        Me.txtLt.Border.Class = "TextBoxBorder"
        Me.txtLt.Location = New System.Drawing.Point(254, 253)
        Me.txtLt.Name = "txtLt"
        Me.txtLt.Size = New System.Drawing.Size(72, 20)
        Me.txtLt.TabIndex = 86
        '
        'txtM3
        '
        '
        '
        '
        Me.txtM3.Border.Class = "TextBoxBorder"
        Me.txtM3.Location = New System.Drawing.Point(102, 253)
        Me.txtM3.Name = "txtM3"
        Me.txtM3.Size = New System.Drawing.Size(122, 20)
        Me.txtM3.TabIndex = 85
        '
        'LabelX21
        '
        Me.LabelX21.AutoSize = True
        Me.LabelX21.BackColor = System.Drawing.Color.Transparent
        Me.LabelX21.Location = New System.Drawing.Point(15, 258)
        Me.LabelX21.Name = "LabelX21"
        Me.LabelX21.Size = New System.Drawing.Size(74, 15)
        Me.LabelX21.TabIndex = 84
        Me.LabelX21.Text = "Consumo M3 :"
        '
        'cv
        '
        Me.cv.AutoSize = True
        Me.cv.BackColor = System.Drawing.Color.Transparent
        Me.cv.Location = New System.Drawing.Point(336, 223)
        Me.cv.Name = "cv"
        Me.cv.Size = New System.Drawing.Size(15, 15)
        Me.cv.TabIndex = 82
        Me.cv.Text = "Lt."
        '
        'txtLtActual
        '
        Me.txtLtActual.AcceptsReturn = True
        '
        '
        '
        Me.txtLtActual.Border.Class = "TextBoxBorder"
        Me.txtLtActual.ForeColor = System.Drawing.Color.Maroon
        Me.txtLtActual.Location = New System.Drawing.Point(360, 220)
        Me.txtLtActual.MaxLength = 3
        Me.txtLtActual.Name = "txtLtActual"
        Me.txtLtActual.Size = New System.Drawing.Size(72, 20)
        Me.txtLtActual.TabIndex = 81
        '
        'LabelX19
        '
        Me.LabelX19.AutoSize = True
        Me.LabelX19.BackColor = System.Drawing.Color.Transparent
        Me.LabelX19.Location = New System.Drawing.Point(230, 220)
        Me.LabelX19.Name = "LabelX19"
        Me.LabelX19.Size = New System.Drawing.Size(21, 15)
        Me.LabelX19.TabIndex = 80
        Me.LabelX19.Text = "M3:"
        '
        'txtFActual
        '
        '
        '
        '
        Me.txtFActual.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtFActual.ButtonDropDown.Visible = True
        Me.txtFActual.Location = New System.Drawing.Point(101, 220)
        '
        '
        '
        Me.txtFActual.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        Me.txtFActual.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.txtFActual.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.txtFActual.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.txtFActual.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.txtFActual.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.txtFActual.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.txtFActual.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.txtFActual.MonthCalendar.DisplayMonth = New Date(2010, 5, 1, 0, 0, 0, 0)
        Me.txtFActual.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.txtFActual.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.txtFActual.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.txtFActual.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.txtFActual.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.txtFActual.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.txtFActual.MonthCalendar.TodayButtonVisible = True
        Me.txtFActual.Name = "txtFActual"
        Me.txtFActual.Size = New System.Drawing.Size(123, 20)
        Me.txtFActual.TabIndex = 79
        '
        'txtM3Actual
        '
        '
        '
        '
        Me.txtM3Actual.Border.Class = "TextBoxBorder"
        Me.txtM3Actual.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtM3Actual.ForeColor = System.Drawing.Color.Navy
        Me.txtM3Actual.Location = New System.Drawing.Point(254, 220)
        Me.txtM3Actual.Name = "txtM3Actual"
        Me.txtM3Actual.Size = New System.Drawing.Size(72, 20)
        Me.txtM3Actual.TabIndex = 77
        '
        'LabelX20
        '
        Me.LabelX20.AutoSize = True
        Me.LabelX20.BackColor = System.Drawing.Color.Transparent
        Me.LabelX20.Location = New System.Drawing.Point(13, 223)
        Me.LabelX20.Name = "LabelX20"
        Me.LabelX20.Size = New System.Drawing.Size(85, 15)
        Me.LabelX20.TabIndex = 78
        Me.LabelX20.Text = "F. Lectura Actual"
        '
        'LabelX17
        '
        Me.LabelX17.AutoSize = True
        Me.LabelX17.BackColor = System.Drawing.Color.Transparent
        Me.LabelX17.Location = New System.Drawing.Point(337, 189)
        Me.LabelX17.Name = "LabelX17"
        Me.LabelX17.Size = New System.Drawing.Size(15, 15)
        Me.LabelX17.TabIndex = 76
        Me.LabelX17.Text = "Lt."
        '
        'txtLtUlt
        '
        '
        '
        '
        Me.txtLtUlt.Border.Class = "TextBoxBorder"
        Me.txtLtUlt.Enabled = False
        Me.txtLtUlt.Location = New System.Drawing.Point(359, 186)
        Me.txtLtUlt.Name = "txtLtUlt"
        Me.txtLtUlt.Size = New System.Drawing.Size(73, 20)
        Me.txtLtUlt.TabIndex = 75
        '
        'LabelX16
        '
        Me.LabelX16.AutoSize = True
        Me.LabelX16.BackColor = System.Drawing.Color.Transparent
        Me.LabelX16.Location = New System.Drawing.Point(230, 187)
        Me.LabelX16.Name = "LabelX16"
        Me.LabelX16.Size = New System.Drawing.Size(21, 15)
        Me.LabelX16.TabIndex = 74
        Me.LabelX16.Text = "M3:"
        '
        'LabelX13
        '
        Me.LabelX13.AutoSize = True
        Me.LabelX13.BackColor = System.Drawing.Color.Transparent
        Me.LabelX13.Location = New System.Drawing.Point(396, 69)
        Me.LabelX13.Name = "LabelX13"
        Me.LabelX13.Size = New System.Drawing.Size(71, 15)
        Me.LabelX13.TabIndex = 71
        Me.LabelX13.Text = "Nº de Codigo:"
        '
        'txtFUltima
        '
        '
        '
        '
        Me.txtFUltima.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtFUltima.ButtonDropDown.Visible = True
        Me.txtFUltima.Enabled = False
        Me.txtFUltima.Location = New System.Drawing.Point(101, 185)
        '
        '
        '
        Me.txtFUltima.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        Me.txtFUltima.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.txtFUltima.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.txtFUltima.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.txtFUltima.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.txtFUltima.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.txtFUltima.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.txtFUltima.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.txtFUltima.MonthCalendar.DisplayMonth = New Date(2010, 5, 1, 0, 0, 0, 0)
        Me.txtFUltima.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.txtFUltima.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.txtFUltima.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.txtFUltima.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.txtFUltima.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.txtFUltima.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.txtFUltima.MonthCalendar.TodayButtonVisible = True
        Me.txtFUltima.Name = "txtFUltima"
        Me.txtFUltima.Size = New System.Drawing.Size(123, 20)
        Me.txtFUltima.TabIndex = 68
        '
        'LabelX11
        '
        Me.LabelX11.AutoSize = True
        Me.LabelX11.BackColor = System.Drawing.Color.Transparent
        Me.LabelX11.Location = New System.Drawing.Point(360, 154)
        Me.LabelX11.Name = "LabelX11"
        Me.LabelX11.Size = New System.Drawing.Size(59, 15)
        Me.LabelX11.TabIndex = 67
        Me.LabelX11.Text = "F. Registro:"
        '
        'txtFecha
        '
        '
        '
        '
        Me.txtFecha.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtFecha.ButtonDropDown.Visible = True
        Me.txtFecha.Location = New System.Drawing.Point(491, 154)
        '
        '
        '
        Me.txtFecha.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        Me.txtFecha.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.txtFecha.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.txtFecha.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.txtFecha.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.txtFecha.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.txtFecha.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.txtFecha.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.txtFecha.MonthCalendar.DisplayMonth = New Date(2010, 5, 1, 0, 0, 0, 0)
        Me.txtFecha.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.txtFecha.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.txtFecha.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.txtFecha.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.txtFecha.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.txtFecha.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.txtFecha.MonthCalendar.TodayButtonVisible = True
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.Size = New System.Drawing.Size(114, 20)
        Me.txtFecha.TabIndex = 66
        '
        'LabelX18
        '
        Me.LabelX18.AutoSize = True
        Me.LabelX18.BackColor = System.Drawing.Color.Transparent
        Me.LabelX18.Location = New System.Drawing.Point(222, 154)
        Me.LabelX18.Name = "LabelX18"
        Me.LabelX18.Size = New System.Drawing.Size(26, 15)
        Me.LabelX18.TabIndex = 65
        Me.LabelX18.Text = "Mes:"
        '
        'cmbMes
        '
        Me.cmbMes.DisplayMember = "Text"
        Me.cmbMes.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMes.FormattingEnabled = True
        Me.cmbMes.ItemHeight = 14
        Me.cmbMes.Items.AddRange(New Object() {Me.ComboItem1, Me.ComboItem2})
        Me.cmbMes.Location = New System.Drawing.Point(254, 154)
        Me.cmbMes.Name = "cmbMes"
        Me.cmbMes.Size = New System.Drawing.Size(79, 20)
        Me.cmbMes.TabIndex = 64
        '
        'ComboItem1
        '
        Me.ComboItem1.Text = "I"
        Me.ComboItem1.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'ComboItem2
        '
        Me.ComboItem2.Text = "II"
        Me.ComboItem2.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX3
        '
        Me.LabelX3.AutoSize = True
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        Me.LabelX3.Location = New System.Drawing.Point(16, 154)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(28, 15)
        Me.LabelX3.TabIndex = 63
        Me.LabelX3.Text = "Año :"
        '
        'cmbAnio
        '
        Me.cmbAnio.DisplayMember = "Text"
        Me.cmbAnio.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbAnio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAnio.FormattingEnabled = True
        Me.cmbAnio.ItemHeight = 14
        Me.cmbAnio.Location = New System.Drawing.Point(102, 154)
        Me.cmbAnio.Name = "cmbAnio"
        Me.cmbAnio.Size = New System.Drawing.Size(93, 20)
        Me.cmbAnio.TabIndex = 62
        '
        'LabelX2
        '
        Me.LabelX2.AutoSize = True
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        Me.LabelX2.Location = New System.Drawing.Point(221, 65)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(27, 15)
        Me.LabelX2.TabIndex = 43
        Me.LabelX2.Text = "Lote:"
        '
        'Bar6
        '
        Me.Bar6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar6.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.Bar6.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnSalir, Me.ButtonItem1, Me.btnEliminar, Me.btnGrabar, Me.btnNuevo})
        Me.Bar6.Location = New System.Drawing.Point(0, 495)
        Me.Bar6.Name = "Bar6"
        Me.Bar6.Size = New System.Drawing.Size(635, 25)
        Me.Bar6.Stretch = True
        Me.Bar6.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Bar6.TabIndex = 41
        Me.Bar6.TabStop = False
        Me.Bar6.Text = "Bar6"
        '
        'btnSalir
        '
        Me.btnSalir.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnSalir.Image = Global.COBSER.My.Resources.Resources.door
        Me.btnSalir.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.btnSalir.ImagePaddingHorizontal = 8
        Me.btnSalir.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Text = "Salir"
        '
        'ButtonItem1
        '
        Me.ButtonItem1.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem1.Image = Global.COBSER.My.Resources.Resources.printer
        Me.ButtonItem1.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.ButtonItem1.ImagePaddingHorizontal = 8
        Me.ButtonItem1.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.ButtonItem1.Name = "ButtonItem1"
        Me.ButtonItem1.Text = "Imprimir"
        '
        'btnEliminar
        '
        Me.btnEliminar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnEliminar.Image = Global.COBSER.My.Resources.Resources.delete
        Me.btnEliminar.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.btnEliminar.ImagePaddingHorizontal = 8
        Me.btnEliminar.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Text = "Eliminar"
        '
        'btnGrabar
        '
        Me.btnGrabar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnGrabar.Image = Global.COBSER.My.Resources.Resources.disk
        Me.btnGrabar.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.btnGrabar.ImagePaddingHorizontal = 8
        Me.btnGrabar.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Text = "Grabar"
        '
        'btnNuevo
        '
        Me.btnNuevo.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnNuevo.Image = Global.COBSER.My.Resources.Resources.add
        Me.btnNuevo.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.btnNuevo.ImagePaddingHorizontal = 8
        Me.btnNuevo.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Text = "Nueva"
        '
        'LabelX14
        '
        Me.LabelX14.AutoSize = True
        Me.LabelX14.BackColor = System.Drawing.Color.Transparent
        Me.LabelX14.Location = New System.Drawing.Point(12, 285)
        Me.LabelX14.Name = "LabelX14"
        Me.LabelX14.Size = New System.Drawing.Size(58, 15)
        Me.LabelX14.TabIndex = 29
        Me.LabelX14.Text = "Lecturador:"
        '
        'txtM3Ult
        '
        '
        '
        '
        Me.txtM3Ult.Border.Class = "TextBoxBorder"
        Me.txtM3Ult.Enabled = False
        Me.txtM3Ult.Location = New System.Drawing.Point(254, 185)
        Me.txtM3Ult.Name = "txtM3Ult"
        Me.txtM3Ult.Size = New System.Drawing.Size(72, 20)
        Me.txtM3Ult.TabIndex = 6
        '
        'LabelX6
        '
        Me.LabelX6.AutoSize = True
        Me.LabelX6.BackColor = System.Drawing.Color.Transparent
        Me.LabelX6.Location = New System.Drawing.Point(13, 188)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(86, 15)
        Me.LabelX6.TabIndex = 13
        Me.LabelX6.Text = "F. Ultima Lectura"
        '
        'txtNombre
        '
        '
        '
        '
        Me.txtNombre.Border.Class = "TextBoxBorder"
        Me.txtNombre.Enabled = False
        Me.txtNombre.Location = New System.Drawing.Point(101, 31)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(288, 20)
        Me.txtNombre.TabIndex = 5
        '
        'txtNro
        '
        '
        '
        '
        Me.txtNro.Border.Class = "TextBoxBorder"
        Me.txtNro.Enabled = False
        Me.txtNro.Location = New System.Drawing.Point(101, 64)
        Me.txtNro.Name = "txtNro"
        Me.txtNro.Size = New System.Drawing.Size(94, 20)
        Me.txtNro.TabIndex = 4
        '
        'txtDNI
        '
        '
        '
        '
        Me.txtDNI.Border.Class = "TextBoxBorder"
        Me.txtDNI.Enabled = False
        Me.txtDNI.Location = New System.Drawing.Point(472, 32)
        Me.txtDNI.Name = "txtDNI"
        Me.txtDNI.Size = New System.Drawing.Size(133, 20)
        Me.txtDNI.TabIndex = 3
        '
        'LabelX7
        '
        Me.LabelX7.AutoSize = True
        Me.LabelX7.BackColor = System.Drawing.Color.Transparent
        Me.LabelX7.Location = New System.Drawing.Point(15, 36)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(44, 15)
        Me.LabelX7.TabIndex = 6
        Me.LabelX7.Text = "Usuario:"
        '
        'LabelX4
        '
        Me.LabelX4.AutoSize = True
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        Me.LabelX4.Location = New System.Drawing.Point(12, 66)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(61, 15)
        Me.LabelX4.TabIndex = 5
        Me.LabelX4.Text = "Nº de Casa:"
        '
        'LabelX5
        '
        Me.LabelX5.AutoSize = True
        Me.LabelX5.BackColor = System.Drawing.Color.Transparent
        Me.LabelX5.Location = New System.Drawing.Point(401, 33)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(24, 15)
        Me.LabelX5.TabIndex = 4
        Me.LabelX5.Text = "DNI:"
        '
        'cmbJunta
        '
        Me.cmbJunta.DisplayMember = "Text"
        Me.cmbJunta.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbJunta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbJunta.Enabled = False
        Me.cmbJunta.FormattingEnabled = True
        Me.cmbJunta.ItemHeight = 14
        Me.cmbJunta.Location = New System.Drawing.Point(101, 3)
        Me.cmbJunta.Name = "cmbJunta"
        Me.cmbJunta.Size = New System.Drawing.Size(288, 20)
        Me.cmbJunta.TabIndex = 0
        '
        'LabelX1
        '
        Me.LabelX1.AutoSize = True
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        Me.LabelX1.Location = New System.Drawing.Point(15, 4)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(33, 15)
        Me.LabelX1.TabIndex = 0
        Me.LabelX1.Text = "JASS:"
        '
        'btAgregar
        '
        Me.btAgregar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btAgregar.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.btAgregar.ImagePaddingHorizontal = 8
        Me.btAgregar.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.btAgregar.Name = "btAgregar"
        Me.btAgregar.Text = "&Nuevo"
        '
        'btnEditar
        '
        Me.btnEditar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnEditar.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.btnEditar.ImagePaddingHorizontal = 8
        Me.btnEditar.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Text = "Editar"
        '
        'btnDel
        '
        Me.btnDel.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnDel.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.btnDel.ImagePaddingHorizontal = 8
        Me.btnDel.Name = "btnDel"
        Me.btnDel.Text = "Quitar "
        '
        'btnRefrescar
        '
        Me.btnRefrescar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnRefrescar.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.btnRefrescar.ImagePaddingHorizontal = 8
        Me.btnRefrescar.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.btnRefrescar.Name = "btnRefrescar"
        Me.btnRefrescar.Text = "Cargar"
        '
        'frmLecturaNew
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(641, 541)
        Me.Controls.Add(Me.GroupPanel1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLecturaNew"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Registro de Lecturas"
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupPanel1.PerformLayout()
        Me.ExpandablePanel2.ResumeLayout(False)
        CType(Me.gridLecturas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFActual, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFUltima, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Bar6 As DevComponents.DotNetBar.Bar
    Friend WithEvents btnSalir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelX14 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtM3Ult As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtNombre As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtNro As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtDNI As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cmbJunta As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX18 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cmbMes As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents ComboItem1 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem2 As DevComponents.Editors.ComboItem
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cmbAnio As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX11 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtFecha As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents LabelX13 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtFUltima As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents LabelX17 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtLtUlt As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX16 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cv As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtLtActual As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX19 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtFActual As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents txtM3Actual As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX20 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtM3 As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX21 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtLt As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX22 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtTotalLA As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX23 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtTotalUlt As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX10 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtCodigo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtLote As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents btnEliminar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnGrabar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnNuevo As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelX12 As DevComponents.DotNetBar.LabelX
    Friend WithEvents btAgregar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnEditar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnDel As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnRefrescar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ExpandablePanel2 As DevComponents.DotNetBar.ExpandablePanel
    Friend WithEvents gridLecturas As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents cmbColaborador As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents ComboItem3 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem4 As DevComponents.Editors.ComboItem
    Friend WithEvents LabelX8 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtAnio As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX9 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtCosto As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX15 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtMonto As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents ButtonItem1 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelX25 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cmbMedidor As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX24 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtCodigoM As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX26 As DevComponents.DotNetBar.LabelX
End Class
