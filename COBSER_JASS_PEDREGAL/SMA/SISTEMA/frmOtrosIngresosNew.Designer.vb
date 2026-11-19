<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOtrosIngresosNew
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
        Me.components = New System.ComponentModel.Container
        Dim ListViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"Subtotal", ""}, -1)
        Dim ListViewItem2 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"IGV", ""}, -1)
        Dim ListViewItem3 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"Total", ""}, -1)
        Me.GroupPanel = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.btnSelectUsuario = New DevComponents.DotNetBar.ButtonX
        Me.lblFecha = New DevComponents.DotNetBar.LabelX
        Me.LabelX29 = New DevComponents.DotNetBar.LabelX
        Me.txtDireccion = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.txtNroDoc1 = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.txtCaja = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.LabelX22 = New DevComponents.DotNetBar.LabelX
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX
        Me.txtUsuario = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.tabIngresos = New DevComponents.DotNetBar.TabControl
        Me.TabControlPanel1 = New DevComponents.DotNetBar.TabControlPanel
        Me.txtConcepto = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX
        Me.txtObserva = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX
        Me.cmbAlquiler = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.ComboItem1 = New DevComponents.Editors.ComboItem
        Me.ComboItem2 = New DevComponents.Editors.ComboItem
        Me.LabelX30 = New DevComponents.DotNetBar.LabelX
        Me.LabelX19 = New DevComponents.DotNetBar.LabelX
        Me.cmbDocPago = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.LabelX26 = New DevComponents.DotNetBar.LabelX
        Me.txtDias = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.txtCantidad = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.LabelX25 = New DevComponents.DotNetBar.LabelX
        Me.txtMonto = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.Cantidad = New DevComponents.DotNetBar.LabelX
        Me.TabItem1 = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanel3 = New DevComponents.DotNetBar.TabControlPanel
        Me.txtDocumento3 = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.LabelX11 = New DevComponents.DotNetBar.LabelX
        Me.cmbDocPago3 = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.LabelX14 = New DevComponents.DotNetBar.LabelX
        Me.LabelX9 = New DevComponents.DotNetBar.LabelX
        Me.txtTotal3 = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.LabelX17 = New DevComponents.DotNetBar.LabelX
        Me.txtCantidad3 = New DevComponents.Editors.IntegerInput
        Me.cmbTipoTramite = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.LabelX13 = New DevComponents.DotNetBar.LabelX
        Me.LabelX12 = New DevComponents.DotNetBar.LabelX
        Me.txtCostoUnitario = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.TabItem3 = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanel4 = New DevComponents.DotNetBar.TabControlPanel
        Me.ListViewEx1 = New DevComponents.DotNetBar.Controls.ListViewEx
        Me.ColumnHeader3 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader4 = New System.Windows.Forms.ColumnHeader
        Me.txtTotal4 = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.LabelX28 = New DevComponents.DotNetBar.LabelX
        Me.txtConcepto4 = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.LabelX24 = New DevComponents.DotNetBar.LabelX
        Me.txtDocumento4 = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.LabelX15 = New DevComponents.DotNetBar.LabelX
        Me.cmbDocPago4 = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.LabelX16 = New DevComponents.DotNetBar.LabelX
        Me.TabItem4 = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX
        Me.cmbTipoIngreso = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.txtRUC = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.LabelX20 = New DevComponents.DotNetBar.LabelX
        Me.txtDNI = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.LabelX18 = New DevComponents.DotNetBar.LabelX
        Me.Bar1 = New DevComponents.DotNetBar.Bar
        Me.btnSave = New DevComponents.DotNetBar.ButtonItem
        Me.btnCancel = New DevComponents.DotNetBar.ButtonItem
        Me.GroupPanel.SuspendLayout()
        CType(Me.tabIngresos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabIngresos.SuspendLayout()
        Me.TabControlPanel1.SuspendLayout()
        Me.TabControlPanel3.SuspendLayout()
        CType(Me.txtCantidad3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControlPanel4.SuspendLayout()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupPanel
        '
        Me.GroupPanel.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel.Controls.Add(Me.btnSelectUsuario)
        Me.GroupPanel.Controls.Add(Me.lblFecha)
        Me.GroupPanel.Controls.Add(Me.LabelX29)
        Me.GroupPanel.Controls.Add(Me.txtDireccion)
        Me.GroupPanel.Controls.Add(Me.txtNroDoc1)
        Me.GroupPanel.Controls.Add(Me.txtCaja)
        Me.GroupPanel.Controls.Add(Me.LabelX22)
        Me.GroupPanel.Controls.Add(Me.LabelX4)
        Me.GroupPanel.Controls.Add(Me.LabelX3)
        Me.GroupPanel.Controls.Add(Me.LabelX2)
        Me.GroupPanel.Controls.Add(Me.txtUsuario)
        Me.GroupPanel.Controls.Add(Me.tabIngresos)
        Me.GroupPanel.Controls.Add(Me.LabelX1)
        Me.GroupPanel.Controls.Add(Me.cmbTipoIngreso)
        Me.GroupPanel.Controls.Add(Me.txtRUC)
        Me.GroupPanel.Controls.Add(Me.LabelX20)
        Me.GroupPanel.Controls.Add(Me.txtDNI)
        Me.GroupPanel.Controls.Add(Me.LabelX18)
        Me.GroupPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupPanel.Location = New System.Drawing.Point(0, 0)
        Me.GroupPanel.Name = "GroupPanel"
        Me.GroupPanel.Size = New System.Drawing.Size(550, 385)
        '
        '
        '
        Me.GroupPanel.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel.Style.BackColorGradientAngle = 90
        Me.GroupPanel.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel.Style.BorderBottomWidth = 1
        Me.GroupPanel.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel.Style.BorderLeftWidth = 1
        Me.GroupPanel.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel.Style.BorderRightWidth = 1
        Me.GroupPanel.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel.Style.BorderTopWidth = 1
        Me.GroupPanel.Style.CornerDiameter = 4
        Me.GroupPanel.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        Me.GroupPanel.TabIndex = 3
        Me.GroupPanel.Text = "Datos Principales"
        '
        'btnSelectUsuario
        '
        Me.btnSelectUsuario.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnSelectUsuario.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnSelectUsuario.Location = New System.Drawing.Point(456, 96)
        Me.btnSelectUsuario.Name = "btnSelectUsuario"
        Me.btnSelectUsuario.Size = New System.Drawing.Size(75, 23)
        Me.btnSelectUsuario.TabIndex = 68
        Me.btnSelectUsuario.Text = "Seleccionar..."
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.BackColor = System.Drawing.Color.Transparent
        Me.lblFecha.Location = New System.Drawing.Point(105, 16)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(6, 15)
        Me.lblFecha.TabIndex = 67
        Me.lblFecha.Text = "-"
        '
        'LabelX29
        '
        Me.LabelX29.AutoSize = True
        Me.LabelX29.BackColor = System.Drawing.Color.Transparent
        Me.LabelX29.Location = New System.Drawing.Point(17, 16)
        Me.LabelX29.Name = "LabelX29"
        Me.LabelX29.Size = New System.Drawing.Size(59, 15)
        Me.LabelX29.TabIndex = 66
        Me.LabelX29.Text = "F. Registro:"
        '
        'txtDireccion
        '
        '
        '
        '
        Me.txtDireccion.Border.Class = "TextBoxBorder"
        Me.txtDireccion.Location = New System.Drawing.Point(105, 125)
        Me.txtDireccion.Name = "txtDireccion"
        Me.txtDireccion.Size = New System.Drawing.Size(426, 20)
        Me.txtDireccion.TabIndex = 4
        '
        'txtNroDoc1
        '
        '
        '
        '
        Me.txtNroDoc1.Border.Class = "TextBoxBorder"
        Me.txtNroDoc1.Enabled = False
        Me.txtNroDoc1.Location = New System.Drawing.Point(369, 16)
        Me.txtNroDoc1.Name = "txtNroDoc1"
        Me.txtNroDoc1.Size = New System.Drawing.Size(162, 20)
        Me.txtNroDoc1.TabIndex = 2
        '
        'txtCaja
        '
        '
        '
        '
        Me.txtCaja.Border.Class = "TextBoxBorder"
        Me.txtCaja.Location = New System.Drawing.Point(348, 47)
        Me.txtCaja.Name = "txtCaja"
        Me.txtCaja.ReadOnly = True
        Me.txtCaja.Size = New System.Drawing.Size(184, 20)
        Me.txtCaja.TabIndex = 6
        '
        'LabelX22
        '
        Me.LabelX22.AutoSize = True
        Me.LabelX22.BackColor = System.Drawing.Color.Transparent
        Me.LabelX22.Location = New System.Drawing.Point(314, 16)
        Me.LabelX22.Name = "LabelX22"
        Me.LabelX22.Size = New System.Drawing.Size(40, 15)
        Me.LabelX22.TabIndex = 60
        Me.LabelX22.Text = "Nº Doc:"
        '
        'LabelX4
        '
        Me.LabelX4.AutoSize = True
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        Me.LabelX4.Location = New System.Drawing.Point(17, 130)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(52, 15)
        Me.LabelX4.TabIndex = 64
        Me.LabelX4.Text = "Direccion:"
        '
        'LabelX3
        '
        Me.LabelX3.AutoSize = True
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        Me.LabelX3.Location = New System.Drawing.Point(314, 52)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(28, 15)
        Me.LabelX3.TabIndex = 5
        Me.LabelX3.Text = "Caja:"
        '
        'LabelX2
        '
        Me.LabelX2.AutoSize = True
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        Me.LabelX2.Location = New System.Drawing.Point(17, 78)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(44, 15)
        Me.LabelX2.TabIndex = 3
        Me.LabelX2.Text = "Usuario:"
        '
        'txtUsuario
        '
        '
        '
        '
        Me.txtUsuario.Border.Class = "TextBoxBorder"
        Me.txtUsuario.Location = New System.Drawing.Point(105, 73)
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.Size = New System.Drawing.Size(427, 20)
        Me.txtUsuario.TabIndex = 1
        '
        'tabIngresos
        '
        Me.tabIngresos.BackColor = System.Drawing.Color.Transparent
        Me.tabIngresos.CanReorderTabs = True
        Me.tabIngresos.Controls.Add(Me.TabControlPanel1)
        Me.tabIngresos.Controls.Add(Me.TabControlPanel3)
        Me.tabIngresos.Controls.Add(Me.TabControlPanel4)
        Me.tabIngresos.Location = New System.Drawing.Point(10, 168)
        Me.tabIngresos.Name = "tabIngresos"
        Me.tabIngresos.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.tabIngresos.SelectedTabIndex = 0
        Me.tabIngresos.Size = New System.Drawing.Size(522, 193)
        Me.tabIngresos.Style = DevComponents.DotNetBar.eTabStripStyle.Office2007Document
        Me.tabIngresos.TabIndex = 2
        Me.tabIngresos.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
        Me.tabIngresos.Tabs.Add(Me.TabItem1)
        Me.tabIngresos.Tabs.Add(Me.TabItem3)
        Me.tabIngresos.Tabs.Add(Me.TabItem4)
        Me.tabIngresos.TabsVisible = False
        Me.tabIngresos.Text = "TabControl1"
        '
        'TabControlPanel1
        '
        Me.TabControlPanel1.Controls.Add(Me.txtConcepto)
        Me.TabControlPanel1.Controls.Add(Me.LabelX6)
        Me.TabControlPanel1.Controls.Add(Me.txtObserva)
        Me.TabControlPanel1.Controls.Add(Me.LabelX5)
        Me.TabControlPanel1.Controls.Add(Me.cmbAlquiler)
        Me.TabControlPanel1.Controls.Add(Me.LabelX30)
        Me.TabControlPanel1.Controls.Add(Me.LabelX19)
        Me.TabControlPanel1.Controls.Add(Me.cmbDocPago)
        Me.TabControlPanel1.Controls.Add(Me.LabelX26)
        Me.TabControlPanel1.Controls.Add(Me.txtDias)
        Me.TabControlPanel1.Controls.Add(Me.txtCantidad)
        Me.TabControlPanel1.Controls.Add(Me.LabelX25)
        Me.TabControlPanel1.Controls.Add(Me.txtMonto)
        Me.TabControlPanel1.Controls.Add(Me.Cantidad)
        Me.TabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel1.Location = New System.Drawing.Point(0, 22)
        Me.TabControlPanel1.Name = "TabControlPanel1"
        Me.TabControlPanel1.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel1.Size = New System.Drawing.Size(522, 171)
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
        'txtConcepto
        '
        '
        '
        '
        Me.txtConcepto.Border.Class = "TextBoxBorder"
        Me.txtConcepto.Location = New System.Drawing.Point(95, 86)
        Me.txtConcepto.Name = "txtConcepto"
        Me.txtConcepto.Size = New System.Drawing.Size(215, 20)
        Me.txtConcepto.TabIndex = 69
        '
        'LabelX6
        '
        Me.LabelX6.AutoSize = True
        Me.LabelX6.BackColor = System.Drawing.Color.Transparent
        Me.LabelX6.Location = New System.Drawing.Point(13, 91)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(53, 15)
        Me.LabelX6.TabIndex = 68
        Me.LabelX6.Text = "Concepto:"
        '
        'txtObserva
        '
        '
        '
        '
        Me.txtObserva.Border.Class = "TextBoxBorder"
        Me.txtObserva.Location = New System.Drawing.Point(95, 121)
        Me.txtObserva.Name = "txtObserva"
        Me.txtObserva.Size = New System.Drawing.Size(409, 20)
        Me.txtObserva.TabIndex = 67
        '
        'LabelX5
        '
        Me.LabelX5.AutoSize = True
        Me.LabelX5.BackColor = System.Drawing.Color.Transparent
        Me.LabelX5.Location = New System.Drawing.Point(9, 122)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(67, 15)
        Me.LabelX5.TabIndex = 66
        Me.LabelX5.Text = "Observacion:"
        '
        'cmbAlquiler
        '
        Me.cmbAlquiler.DisplayMember = "Text"
        Me.cmbAlquiler.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbAlquiler.DropDownHeight = 300
        Me.cmbAlquiler.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAlquiler.FormattingEnabled = True
        Me.cmbAlquiler.IntegralHeight = False
        Me.cmbAlquiler.ItemHeight = 17
        Me.cmbAlquiler.Items.AddRange(New Object() {Me.ComboItem1, Me.ComboItem2})
        Me.cmbAlquiler.Location = New System.Drawing.Point(95, 11)
        Me.cmbAlquiler.Name = "cmbAlquiler"
        Me.cmbAlquiler.Size = New System.Drawing.Size(117, 23)
        Me.cmbAlquiler.TabIndex = 65
        '
        'ComboItem1
        '
        Me.ComboItem1.Text = "Usuario"
        '
        'ComboItem2
        '
        Me.ComboItem2.Text = "Particular"
        '
        'LabelX30
        '
        Me.LabelX30.AutoSize = True
        Me.LabelX30.BackColor = System.Drawing.Color.Transparent
        Me.LabelX30.Location = New System.Drawing.Point(8, 14)
        Me.LabelX30.Name = "LabelX30"
        Me.LabelX30.Size = New System.Drawing.Size(79, 15)
        Me.LabelX30.TabIndex = 64
        Me.LabelX30.Text = "Tipo de Cliente:"
        '
        'LabelX19
        '
        Me.LabelX19.AutoSize = True
        Me.LabelX19.BackColor = System.Drawing.Color.Transparent
        Me.LabelX19.Location = New System.Drawing.Point(338, 91)
        Me.LabelX19.Name = "LabelX19"
        Me.LabelX19.Size = New System.Drawing.Size(49, 15)
        Me.LabelX19.TabIndex = 58
        Me.LabelX19.Text = "Monto S/."
        '
        'cmbDocPago
        '
        Me.cmbDocPago.DisplayMember = "Text"
        Me.cmbDocPago.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbDocPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDocPago.FormattingEnabled = True
        Me.cmbDocPago.ItemHeight = 14
        Me.cmbDocPago.Location = New System.Drawing.Point(335, 14)
        Me.cmbDocPago.Name = "cmbDocPago"
        Me.cmbDocPago.Size = New System.Drawing.Size(166, 20)
        Me.cmbDocPago.TabIndex = 1
        '
        'LabelX26
        '
        Me.LabelX26.AutoSize = True
        Me.LabelX26.BackColor = System.Drawing.Color.Transparent
        Me.LabelX26.Location = New System.Drawing.Point(260, 19)
        Me.LabelX26.Name = "LabelX26"
        Me.LabelX26.Size = New System.Drawing.Size(57, 15)
        Me.LabelX26.TabIndex = 53
        Me.LabelX26.Text = "Doc. Pago:"
        '
        'txtDias
        '
        '
        '
        '
        Me.txtDias.Border.Class = "TextBoxBorder"
        Me.txtDias.Location = New System.Drawing.Point(93, 53)
        Me.txtDias.Name = "txtDias"
        Me.txtDias.Size = New System.Drawing.Size(119, 20)
        Me.txtDias.TabIndex = 4
        '
        'txtCantidad
        '
        '
        '
        '
        Me.txtCantidad.Border.Class = "TextBoxBorder"
        Me.txtCantidad.Location = New System.Drawing.Point(335, 53)
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(166, 20)
        Me.txtCantidad.TabIndex = 5
        '
        'LabelX25
        '
        Me.LabelX25.AutoSize = True
        Me.LabelX25.BackColor = System.Drawing.Color.Transparent
        Me.LabelX25.Location = New System.Drawing.Point(8, 50)
        Me.LabelX25.Name = "LabelX25"
        Me.LabelX25.Size = New System.Drawing.Size(43, 15)
        Me.LabelX25.TabIndex = 50
        Me.LabelX25.Text = "Nº Dias:"
        '
        'txtMonto
        '
        '
        '
        '
        Me.txtMonto.Border.Class = "TextBoxBorder"
        Me.txtMonto.Location = New System.Drawing.Point(412, 86)
        Me.txtMonto.Name = "txtMonto"
        Me.txtMonto.Size = New System.Drawing.Size(89, 20)
        Me.txtMonto.TabIndex = 3
        '
        'Cantidad
        '
        Me.Cantidad.AutoSize = True
        Me.Cantidad.BackColor = System.Drawing.Color.Transparent
        Me.Cantidad.Location = New System.Drawing.Point(260, 54)
        Me.Cantidad.Name = "Cantidad"
        Me.Cantidad.Size = New System.Drawing.Size(50, 15)
        Me.Cantidad.TabIndex = 40
        Me.Cantidad.Text = "Cantidad:"
        '
        'TabItem1
        '
        Me.TabItem1.AttachedControl = Me.TabControlPanel1
        Me.TabItem1.Name = "TabItem1"
        Me.TabItem1.Text = "Alquiler de Sillas"
        '
        'TabControlPanel3
        '
        Me.TabControlPanel3.Controls.Add(Me.txtDocumento3)
        Me.TabControlPanel3.Controls.Add(Me.LabelX11)
        Me.TabControlPanel3.Controls.Add(Me.cmbDocPago3)
        Me.TabControlPanel3.Controls.Add(Me.LabelX14)
        Me.TabControlPanel3.Controls.Add(Me.LabelX9)
        Me.TabControlPanel3.Controls.Add(Me.txtTotal3)
        Me.TabControlPanel3.Controls.Add(Me.LabelX17)
        Me.TabControlPanel3.Controls.Add(Me.txtCantidad3)
        Me.TabControlPanel3.Controls.Add(Me.cmbTipoTramite)
        Me.TabControlPanel3.Controls.Add(Me.LabelX13)
        Me.TabControlPanel3.Controls.Add(Me.LabelX12)
        Me.TabControlPanel3.Controls.Add(Me.txtCostoUnitario)
        Me.TabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel3.Location = New System.Drawing.Point(0, 22)
        Me.TabControlPanel3.Name = "TabControlPanel3"
        Me.TabControlPanel3.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel3.Size = New System.Drawing.Size(522, 171)
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
        'txtDocumento3
        '
        '
        '
        '
        Me.txtDocumento3.Border.Class = "TextBoxBorder"
        Me.txtDocumento3.Location = New System.Drawing.Point(400, 45)
        Me.txtDocumento3.Name = "txtDocumento3"
        Me.txtDocumento3.Size = New System.Drawing.Size(102, 20)
        Me.txtDocumento3.TabIndex = 65
        '
        'LabelX11
        '
        Me.LabelX11.AutoSize = True
        Me.LabelX11.BackColor = System.Drawing.Color.Transparent
        Me.LabelX11.Location = New System.Drawing.Point(340, 46)
        Me.LabelX11.Name = "LabelX11"
        Me.LabelX11.Size = New System.Drawing.Size(40, 15)
        Me.LabelX11.TabIndex = 64
        Me.LabelX11.Text = "Nº Doc:"
        '
        'cmbDocPago3
        '
        Me.cmbDocPago3.DisplayMember = "Text"
        Me.cmbDocPago3.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbDocPago3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDocPago3.FormattingEnabled = True
        Me.cmbDocPago3.ItemHeight = 14
        Me.cmbDocPago3.Location = New System.Drawing.Point(93, 45)
        Me.cmbDocPago3.Name = "cmbDocPago3"
        Me.cmbDocPago3.Size = New System.Drawing.Size(195, 20)
        Me.cmbDocPago3.TabIndex = 63
        '
        'LabelX14
        '
        Me.LabelX14.AutoSize = True
        Me.LabelX14.BackColor = System.Drawing.Color.Transparent
        Me.LabelX14.Location = New System.Drawing.Point(7, 46)
        Me.LabelX14.Name = "LabelX14"
        Me.LabelX14.Size = New System.Drawing.Size(57, 15)
        Me.LabelX14.TabIndex = 62
        Me.LabelX14.Text = "Doc. Pago:"
        '
        'LabelX9
        '
        Me.LabelX9.AutoSize = True
        Me.LabelX9.BackColor = System.Drawing.Color.Transparent
        Me.LabelX9.Location = New System.Drawing.Point(340, 82)
        Me.LabelX9.Name = "LabelX9"
        Me.LabelX9.Size = New System.Drawing.Size(30, 15)
        Me.LabelX9.TabIndex = 40
        Me.LabelX9.Text = "Total:"
        '
        'txtTotal3
        '
        '
        '
        '
        Me.txtTotal3.Border.Class = "TextBoxBorder"
        Me.txtTotal3.Location = New System.Drawing.Point(400, 77)
        Me.txtTotal3.Name = "txtTotal3"
        Me.txtTotal3.ReadOnly = True
        Me.txtTotal3.Size = New System.Drawing.Size(102, 20)
        Me.txtTotal3.TabIndex = 39
        '
        'LabelX17
        '
        Me.LabelX17.AutoSize = True
        Me.LabelX17.BackColor = System.Drawing.Color.Transparent
        Me.LabelX17.Location = New System.Drawing.Point(178, 82)
        Me.LabelX17.Name = "LabelX17"
        Me.LabelX17.Size = New System.Drawing.Size(50, 15)
        Me.LabelX17.TabIndex = 36
        Me.LabelX17.Text = "Cantidad:"
        '
        'txtCantidad3
        '
        Me.txtCantidad3.AccessibleDescription = ""
        '
        '
        '
        Me.txtCantidad3.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtCantidad3.Location = New System.Drawing.Point(234, 77)
        Me.txtCantidad3.MinValue = 1
        Me.txtCantidad3.Name = "txtCantidad3"
        Me.txtCantidad3.ShowUpDown = True
        Me.txtCantidad3.Size = New System.Drawing.Size(54, 20)
        Me.txtCantidad3.TabIndex = 35
        Me.txtCantidad3.Value = 1
        '
        'cmbTipoTramite
        '
        Me.cmbTipoTramite.DisplayMember = "Text"
        Me.cmbTipoTramite.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbTipoTramite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoTramite.FormattingEnabled = True
        Me.cmbTipoTramite.ItemHeight = 14
        Me.cmbTipoTramite.Location = New System.Drawing.Point(93, 19)
        Me.cmbTipoTramite.Name = "cmbTipoTramite"
        Me.cmbTipoTramite.Size = New System.Drawing.Size(409, 20)
        Me.cmbTipoTramite.TabIndex = 21
        '
        'LabelX13
        '
        Me.LabelX13.AutoSize = True
        Me.LabelX13.BackColor = System.Drawing.Color.Transparent
        Me.LabelX13.Location = New System.Drawing.Point(7, 24)
        Me.LabelX13.Name = "LabelX13"
        Me.LabelX13.Size = New System.Drawing.Size(40, 15)
        Me.LabelX13.TabIndex = 26
        Me.LabelX13.Text = "Detalle:"
        '
        'LabelX12
        '
        Me.LabelX12.AutoSize = True
        Me.LabelX12.BackColor = System.Drawing.Color.Transparent
        Me.LabelX12.Location = New System.Drawing.Point(11, 82)
        Me.LabelX12.Name = "LabelX12"
        Me.LabelX12.Size = New System.Drawing.Size(75, 15)
        Me.LabelX12.TabIndex = 28
        Me.LabelX12.Text = "Costo Unitario:"
        '
        'txtCostoUnitario
        '
        '
        '
        '
        Me.txtCostoUnitario.Border.Class = "TextBoxBorder"
        Me.txtCostoUnitario.Location = New System.Drawing.Point(98, 77)
        Me.txtCostoUnitario.Name = "txtCostoUnitario"
        Me.txtCostoUnitario.Size = New System.Drawing.Size(63, 20)
        Me.txtCostoUnitario.TabIndex = 27
        '
        'TabItem3
        '
        Me.TabItem3.AttachedControl = Me.TabControlPanel3
        Me.TabItem3.Name = "TabItem3"
        Me.TabItem3.Text = "Pagos Administrativos"
        '
        'TabControlPanel4
        '
        Me.TabControlPanel4.Controls.Add(Me.ListViewEx1)
        Me.TabControlPanel4.Controls.Add(Me.txtTotal4)
        Me.TabControlPanel4.Controls.Add(Me.LabelX28)
        Me.TabControlPanel4.Controls.Add(Me.txtConcepto4)
        Me.TabControlPanel4.Controls.Add(Me.LabelX24)
        Me.TabControlPanel4.Controls.Add(Me.txtDocumento4)
        Me.TabControlPanel4.Controls.Add(Me.LabelX15)
        Me.TabControlPanel4.Controls.Add(Me.cmbDocPago4)
        Me.TabControlPanel4.Controls.Add(Me.LabelX16)
        Me.TabControlPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel4.Location = New System.Drawing.Point(0, 22)
        Me.TabControlPanel4.Name = "TabControlPanel4"
        Me.TabControlPanel4.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel4.Size = New System.Drawing.Size(522, 171)
        Me.TabControlPanel4.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.TabControlPanel4.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(157, Byte), Integer), CType(CType(188, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.TabControlPanel4.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel4.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
        Me.TabControlPanel4.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                    Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel4.Style.GradientAngle = 90
        Me.TabControlPanel4.TabIndex = 4
        Me.TabControlPanel4.TabItem = Me.TabItem4
        '
        'ListViewEx1
        '
        '
        '
        '
        Me.ListViewEx1.Border.Class = "ListViewBorder"
        Me.ListViewEx1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader3, Me.ColumnHeader4})
        Me.ListViewEx1.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem1, ListViewItem2, ListViewItem3})
        Me.ListViewEx1.Location = New System.Drawing.Point(7, 111)
        Me.ListViewEx1.Name = "ListViewEx1"
        Me.ListViewEx1.Size = New System.Drawing.Size(501, 97)
        Me.ListViewEx1.TabIndex = 64
        Me.ListViewEx1.UseCompatibleStateImageBehavior = False
        Me.ListViewEx1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Montos"
        Me.ColumnHeader3.Width = 344
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "(S/.)"
        Me.ColumnHeader4.Width = 125
        '
        'txtTotal4
        '
        '
        '
        '
        Me.txtTotal4.Border.Class = "TextBoxBorder"
        Me.txtTotal4.Location = New System.Drawing.Point(82, 85)
        Me.txtTotal4.Name = "txtTotal4"
        Me.txtTotal4.Size = New System.Drawing.Size(102, 20)
        Me.txtTotal4.TabIndex = 69
        '
        'LabelX28
        '
        Me.LabelX28.AutoSize = True
        Me.LabelX28.BackColor = System.Drawing.Color.Transparent
        Me.LabelX28.Location = New System.Drawing.Point(16, 85)
        Me.LabelX28.Name = "LabelX28"
        Me.LabelX28.Size = New System.Drawing.Size(30, 15)
        Me.LabelX28.TabIndex = 68
        Me.LabelX28.Text = "Total:"
        '
        'txtConcepto4
        '
        '
        '
        '
        Me.txtConcepto4.Border.Class = "TextBoxBorder"
        Me.txtConcepto4.Location = New System.Drawing.Point(79, 27)
        Me.txtConcepto4.Name = "txtConcepto4"
        Me.txtConcepto4.Size = New System.Drawing.Size(422, 20)
        Me.txtConcepto4.TabIndex = 0
        '
        'LabelX24
        '
        Me.LabelX24.AutoSize = True
        Me.LabelX24.BackColor = System.Drawing.Color.Transparent
        Me.LabelX24.Location = New System.Drawing.Point(16, 33)
        Me.LabelX24.Name = "LabelX24"
        Me.LabelX24.Size = New System.Drawing.Size(53, 15)
        Me.LabelX24.TabIndex = 66
        Me.LabelX24.Text = "Concepto:"
        '
        'txtDocumento4
        '
        '
        '
        '
        Me.txtDocumento4.Border.Class = "TextBoxBorder"
        Me.txtDocumento4.Location = New System.Drawing.Point(399, 59)
        Me.txtDocumento4.Name = "txtDocumento4"
        Me.txtDocumento4.Size = New System.Drawing.Size(102, 20)
        Me.txtDocumento4.TabIndex = 65
        '
        'LabelX15
        '
        Me.LabelX15.AutoSize = True
        Me.LabelX15.BackColor = System.Drawing.Color.Transparent
        Me.LabelX15.Location = New System.Drawing.Point(342, 64)
        Me.LabelX15.Name = "LabelX15"
        Me.LabelX15.Size = New System.Drawing.Size(40, 15)
        Me.LabelX15.TabIndex = 64
        Me.LabelX15.Text = "Nº Doc:"
        '
        'cmbDocPago4
        '
        Me.cmbDocPago4.DisplayMember = "Text"
        Me.cmbDocPago4.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbDocPago4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDocPago4.FormattingEnabled = True
        Me.cmbDocPago4.ItemHeight = 14
        Me.cmbDocPago4.Location = New System.Drawing.Point(79, 59)
        Me.cmbDocPago4.Name = "cmbDocPago4"
        Me.cmbDocPago4.Size = New System.Drawing.Size(238, 20)
        Me.cmbDocPago4.TabIndex = 63
        '
        'LabelX16
        '
        Me.LabelX16.AutoSize = True
        Me.LabelX16.BackColor = System.Drawing.Color.Transparent
        Me.LabelX16.Location = New System.Drawing.Point(16, 64)
        Me.LabelX16.Name = "LabelX16"
        Me.LabelX16.Size = New System.Drawing.Size(57, 15)
        Me.LabelX16.TabIndex = 62
        Me.LabelX16.Text = "Doc. Pago:"
        '
        'TabItem4
        '
        Me.TabItem4.AttachedControl = Me.TabControlPanel4
        Me.TabItem4.Name = "TabItem4"
        Me.TabItem4.Text = "Otros"
        '
        'LabelX1
        '
        Me.LabelX1.AutoSize = True
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        Me.LabelX1.Location = New System.Drawing.Point(17, 48)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(79, 15)
        Me.LabelX1.TabIndex = 1
        Me.LabelX1.Text = "Tipo de Ingreso"
        '
        'cmbTipoIngreso
        '
        Me.cmbTipoIngreso.DisplayMember = "Text"
        Me.cmbTipoIngreso.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbTipoIngreso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoIngreso.FormattingEnabled = True
        Me.cmbTipoIngreso.ItemHeight = 14
        Me.cmbTipoIngreso.Location = New System.Drawing.Point(105, 47)
        Me.cmbTipoIngreso.Name = "cmbTipoIngreso"
        Me.cmbTipoIngreso.Size = New System.Drawing.Size(180, 20)
        Me.cmbTipoIngreso.TabIndex = 0
        '
        'txtRUC
        '
        '
        '
        '
        Me.txtRUC.Border.Class = "TextBoxBorder"
        Me.txtRUC.Location = New System.Drawing.Point(348, 99)
        Me.txtRUC.Name = "txtRUC"
        Me.txtRUC.Size = New System.Drawing.Size(87, 20)
        Me.txtRUC.TabIndex = 3
        '
        'LabelX20
        '
        Me.LabelX20.AutoSize = True
        Me.LabelX20.BackColor = System.Drawing.Color.Transparent
        Me.LabelX20.Location = New System.Drawing.Point(17, 104)
        Me.LabelX20.Name = "LabelX20"
        Me.LabelX20.Size = New System.Drawing.Size(24, 15)
        Me.LabelX20.TabIndex = 39
        Me.LabelX20.Text = "DNI:"
        '
        'txtDNI
        '
        '
        '
        '
        Me.txtDNI.Border.Class = "TextBoxBorder"
        Me.txtDNI.Location = New System.Drawing.Point(105, 99)
        Me.txtDNI.Name = "txtDNI"
        Me.txtDNI.Size = New System.Drawing.Size(89, 20)
        Me.txtDNI.TabIndex = 2
        '
        'LabelX18
        '
        Me.LabelX18.AutoSize = True
        Me.LabelX18.BackColor = System.Drawing.Color.Transparent
        Me.LabelX18.Location = New System.Drawing.Point(314, 104)
        Me.LabelX18.Name = "LabelX18"
        Me.LabelX18.Size = New System.Drawing.Size(29, 15)
        Me.LabelX18.TabIndex = 42
        Me.LabelX18.Text = "RUC:"
        '
        'Bar1
        '
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnSave, Me.btnCancel})
        Me.Bar1.Location = New System.Drawing.Point(0, 385)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(550, 25)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Bar1.TabIndex = 2
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
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
        Me.btnCancel.Text = "Cancelar"
        '
        'frmOtrosIngresosNew
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(550, 410)
        Me.Controls.Add(Me.GroupPanel)
        Me.Controls.Add(Me.Bar1)
        Me.Name = "frmOtrosIngresosNew"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmOtrosIngresosNew"
        Me.GroupPanel.ResumeLayout(False)
        Me.GroupPanel.PerformLayout()
        CType(Me.tabIngresos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabIngresos.ResumeLayout(False)
        Me.TabControlPanel1.ResumeLayout(False)
        Me.TabControlPanel1.PerformLayout()
        Me.TabControlPanel3.ResumeLayout(False)
        Me.TabControlPanel3.PerformLayout()
        CType(Me.txtCantidad3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControlPanel4.ResumeLayout(False)
        Me.TabControlPanel4.PerformLayout()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupPanel As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents btnSelectUsuario As DevComponents.DotNetBar.ButtonX
    Friend WithEvents lblFecha As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX29 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtDireccion As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtCaja As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtUsuario As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents tabIngresos As DevComponents.DotNetBar.TabControl
    Friend WithEvents TabControlPanel1 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents cmbAlquiler As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX30 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtNroDoc1 As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX22 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX19 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cmbDocPago As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX26 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtDias As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtCantidad As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX25 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtMonto As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Cantidad As DevComponents.DotNetBar.LabelX
    Friend WithEvents TabItem1 As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControlPanel3 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents txtDocumento3 As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX11 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cmbDocPago3 As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX14 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX9 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtTotal3 As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX17 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtCantidad3 As DevComponents.Editors.IntegerInput
    Friend WithEvents cmbTipoTramite As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX13 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX12 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtCostoUnitario As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TabItem3 As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControlPanel4 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents txtTotal4 As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX28 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtConcepto4 As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX24 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtDocumento4 As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX15 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cmbDocPago4 As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX16 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TabItem4 As DevComponents.DotNetBar.TabItem
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cmbTipoIngreso As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents txtRUC As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX20 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtDNI As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX18 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents btnSave As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnCancel As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ComboItem1 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem2 As DevComponents.Editors.ComboItem
    Friend WithEvents ListViewEx1 As DevComponents.DotNetBar.Controls.ListViewEx
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtObserva As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtConcepto As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
End Class
