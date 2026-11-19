<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCobranzaNew
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
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.LabelX11 = New DevComponents.DotNetBar.LabelX
        Me.cmbAnio = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.txtNro = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.txtPredio = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.txtAnioVigente = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX
        Me.GroupPanel4 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.txtReferencia = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.cmbTipoPago = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX
        Me.LabelX15 = New DevComponents.DotNetBar.LabelX
        Me.lblPagoDeuda = New DevComponents.DotNetBar.LabelX
        Me.LabelX14 = New DevComponents.DotNetBar.LabelX
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX
        Me.lblPagoTotal = New DevComponents.DotNetBar.LabelX
        Me.LabelX17 = New DevComponents.DotNetBar.LabelX
        Me.lblMonto = New DevComponents.DotNetBar.LabelX
        Me.LabelX18 = New DevComponents.DotNetBar.LabelX
        Me.lblPagoInteres = New DevComponents.DotNetBar.LabelX
        Me.lblPagoTotalRedondeo = New DevComponents.DotNetBar.LabelX
        Me.LabelX20 = New DevComponents.DotNetBar.LabelX
        Me.GroupPanel3 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.txtObservaciones = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.txtDni = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX
        Me.ButtonX1 = New DevComponents.DotNetBar.ButtonX
        Me.LabelX8 = New DevComponents.DotNetBar.LabelX
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX
        Me.txtUsuario = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.tvDeudas = New DevComponents.AdvTree.AdvTree
        Me.Año = New DevComponents.AdvTree.ColumnHeader
        Me.Mes = New DevComponents.AdvTree.ColumnHeader
        Me.NroFactura = New DevComponents.AdvTree.ColumnHeader
        Me.Monto = New DevComponents.AdvTree.ColumnHeader
        Me.MontoS = New DevComponents.AdvTree.ColumnHeader
        Me.Mora = New DevComponents.AdvTree.ColumnHeader
        Me.Volumen = New DevComponents.AdvTree.ColumnHeader
        Me.Servicio = New DevComponents.AdvTree.ColumnHeader
        Me.Id = New DevComponents.AdvTree.ColumnHeader
        Me.IdMes = New DevComponents.AdvTree.ColumnHeader
        Me.NodeConnector1 = New DevComponents.AdvTree.NodeConnector
        Me.ElementStyle1 = New DevComponents.DotNetBar.ElementStyle
        Me.ElementStyle2 = New DevComponents.DotNetBar.ElementStyle
        Me.Bar6 = New DevComponents.DotNetBar.Bar
        Me.chkSelectAll = New DevComponents.DotNetBar.Controls.CheckBoxX
        Me.Bar3 = New DevComponents.DotNetBar.Bar
        Me.lblFecha = New DevComponents.DotNetBar.LabelX
        Me.LabelX23 = New DevComponents.DotNetBar.LabelX
        Me.cmbJunta = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.LabelX13 = New DevComponents.DotNetBar.LabelX
        Me.ControlContainerItem1 = New DevComponents.DotNetBar.ControlContainerItem
        Me.ControlContainerItem3 = New DevComponents.DotNetBar.ControlContainerItem
        Me.Bar1 = New DevComponents.DotNetBar.Bar
        Me.LabelItem3 = New DevComponents.DotNetBar.LabelItem
        Me.lblCaja = New DevComponents.DotNetBar.LabelItem
        Me.btnSave = New DevComponents.DotNetBar.ButtonItem
        Me.btnCancel = New DevComponents.DotNetBar.ButtonItem
        Me.ComboItem2 = New DevComponents.Editors.ComboItem
        Me.ComboItem1 = New DevComponents.Editors.ComboItem
        Me.LabelX9 = New DevComponents.DotNetBar.LabelX
        Me.Node1 = New DevComponents.AdvTree.Node
        Me.LabelX10 = New DevComponents.DotNetBar.LabelX
        Me.Node2 = New DevComponents.AdvTree.Node
        Me.GroupPanel1.SuspendLayout()
        Me.GroupPanel4.SuspendLayout()
        Me.GroupPanel3.SuspendLayout()
        Me.GroupPanel2.SuspendLayout()
        CType(Me.tvDeudas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Bar6.SuspendLayout()
        CType(Me.Bar3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Bar3.SuspendLayout()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.Transparent
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.LabelX11)
        Me.GroupPanel1.Controls.Add(Me.cmbAnio)
        Me.GroupPanel1.Controls.Add(Me.txtNro)
        Me.GroupPanel1.Controls.Add(Me.txtPredio)
        Me.GroupPanel1.Controls.Add(Me.txtAnioVigente)
        Me.GroupPanel1.Controls.Add(Me.LabelX7)
        Me.GroupPanel1.Controls.Add(Me.GroupPanel4)
        Me.GroupPanel1.Controls.Add(Me.GroupPanel3)
        Me.GroupPanel1.Controls.Add(Me.txtDni)
        Me.GroupPanel1.Controls.Add(Me.LabelX4)
        Me.GroupPanel1.Controls.Add(Me.LabelX3)
        Me.GroupPanel1.Controls.Add(Me.ButtonX1)
        Me.GroupPanel1.Controls.Add(Me.LabelX8)
        Me.GroupPanel1.Controls.Add(Me.LabelX1)
        Me.GroupPanel1.Controls.Add(Me.txtUsuario)
        Me.GroupPanel1.Controls.Add(Me.GroupPanel2)
        Me.GroupPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupPanel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupPanel1.Location = New System.Drawing.Point(0, 30)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(1019, 545)
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
        Me.GroupPanel1.TabIndex = 4
        Me.GroupPanel1.Text = "Datos Principales"
        '
        'LabelX11
        '
        Me.LabelX11.AutoSize = True
        Me.LabelX11.BackColor = System.Drawing.Color.Transparent
        Me.LabelX11.Location = New System.Drawing.Point(11, 89)
        Me.LabelX11.Name = "LabelX11"
        Me.LabelX11.Size = New System.Drawing.Size(83, 16)
        Me.LabelX11.TabIndex = 133
        Me.LabelX11.Text = "Filtrar Por Año:"
        '
        'cmbAnio
        '
        Me.cmbAnio.DisplayMember = "Text"
        Me.cmbAnio.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbAnio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAnio.FormattingEnabled = True
        Me.cmbAnio.ItemHeight = 15
        Me.cmbAnio.Location = New System.Drawing.Point(103, 91)
        Me.cmbAnio.Name = "cmbAnio"
        Me.cmbAnio.Size = New System.Drawing.Size(88, 21)
        Me.cmbAnio.TabIndex = 132
        '
        'txtNro
        '
        Me.txtNro.BackColor = System.Drawing.Color.PowderBlue
        '
        '
        '
        Me.txtNro.Border.Class = "TextBoxBorder"
        Me.txtNro.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNro.Location = New System.Drawing.Point(498, 64)
        Me.txtNro.Name = "txtNro"
        Me.txtNro.Size = New System.Drawing.Size(87, 21)
        Me.txtNro.TabIndex = 131
        '
        'txtPredio
        '
        Me.txtPredio.BackColor = System.Drawing.Color.PowderBlue
        '
        '
        '
        Me.txtPredio.Border.Class = "TextBoxBorder"
        Me.txtPredio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPredio.Location = New System.Drawing.Point(103, 63)
        Me.txtPredio.Name = "txtPredio"
        Me.txtPredio.ReadOnly = True
        Me.txtPredio.Size = New System.Drawing.Size(285, 22)
        Me.txtPredio.TabIndex = 130
        Me.txtPredio.Text = "-"
        Me.txtPredio.WatermarkText = "Nombre de Usuario"
        '
        'txtAnioVigente
        '
        Me.txtAnioVigente.BackColor = System.Drawing.Color.PowderBlue
        '
        '
        '
        Me.txtAnioVigente.Border.Class = "TextBoxBorder"
        Me.txtAnioVigente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAnioVigente.Location = New System.Drawing.Point(103, 3)
        Me.txtAnioVigente.Name = "txtAnioVigente"
        Me.txtAnioVigente.Size = New System.Drawing.Size(87, 21)
        Me.txtAnioVigente.TabIndex = 129
        '
        'LabelX7
        '
        Me.LabelX7.BackColor = System.Drawing.Color.Transparent
        Me.LabelX7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX7.Location = New System.Drawing.Point(14, -1)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(66, 20)
        Me.LabelX7.TabIndex = 128
        Me.LabelX7.Text = "Año Tarifa:"
        Me.LabelX7.WordWrap = True
        '
        'GroupPanel4
        '
        Me.GroupPanel4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupPanel4.BackColor = System.Drawing.Color.Transparent
        Me.GroupPanel4.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel4.Controls.Add(Me.txtReferencia)
        Me.GroupPanel4.Controls.Add(Me.cmbTipoPago)
        Me.GroupPanel4.Controls.Add(Me.LabelX2)
        Me.GroupPanel4.Controls.Add(Me.LabelX15)
        Me.GroupPanel4.Controls.Add(Me.lblPagoDeuda)
        Me.GroupPanel4.Controls.Add(Me.LabelX14)
        Me.GroupPanel4.Controls.Add(Me.LabelX5)
        Me.GroupPanel4.Controls.Add(Me.lblPagoTotal)
        Me.GroupPanel4.Controls.Add(Me.LabelX17)
        Me.GroupPanel4.Controls.Add(Me.lblMonto)
        Me.GroupPanel4.Controls.Add(Me.LabelX18)
        Me.GroupPanel4.Controls.Add(Me.lblPagoInteres)
        Me.GroupPanel4.Controls.Add(Me.lblPagoTotalRedondeo)
        Me.GroupPanel4.Controls.Add(Me.LabelX20)
        Me.GroupPanel4.Location = New System.Drawing.Point(6, 413)
        Me.GroupPanel4.Name = "GroupPanel4"
        Me.GroupPanel4.Size = New System.Drawing.Size(1004, 106)
        '
        '
        '
        Me.GroupPanel4.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel4.Style.BackColorGradientAngle = 90
        Me.GroupPanel4.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel4.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel4.Style.BorderBottomWidth = 1
        Me.GroupPanel4.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel4.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel4.Style.BorderLeftWidth = 1
        Me.GroupPanel4.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel4.Style.BorderRightWidth = 1
        Me.GroupPanel4.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel4.Style.BorderTopWidth = 1
        Me.GroupPanel4.Style.CornerDiameter = 4
        Me.GroupPanel4.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel4.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel4.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel4.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        Me.GroupPanel4.TabIndex = 125
        Me.GroupPanel4.Text = "Pago"
        '
        'txtReferencia
        '
        '
        '
        '
        Me.txtReferencia.Border.Class = "TextBoxBorder"
        Me.txtReferencia.Location = New System.Drawing.Point(380, 5)
        Me.txtReferencia.Name = "txtReferencia"
        Me.txtReferencia.Size = New System.Drawing.Size(402, 21)
        Me.txtReferencia.TabIndex = 118
        Me.txtReferencia.WatermarkText = "Doc. Referencia"
        '
        'cmbTipoPago
        '
        Me.cmbTipoPago.DisplayMember = "Text"
        Me.cmbTipoPago.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbTipoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoPago.FormattingEnabled = True
        Me.cmbTipoPago.ItemHeight = 15
        Me.cmbTipoPago.Location = New System.Drawing.Point(120, 3)
        Me.cmbTipoPago.Name = "cmbTipoPago"
        Me.cmbTipoPago.Size = New System.Drawing.Size(110, 21)
        Me.cmbTipoPago.TabIndex = 22
        '
        'LabelX2
        '
        Me.LabelX2.AutoSize = True
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        Me.LabelX2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX2.Location = New System.Drawing.Point(11, 3)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(83, 17)
        Me.LabelX2.TabIndex = 23
        Me.LabelX2.Text = "Tipo de Pago:"
        '
        'LabelX15
        '
        Me.LabelX15.AutoSize = True
        Me.LabelX15.BackColor = System.Drawing.Color.Transparent
        Me.LabelX15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LabelX15.Location = New System.Drawing.Point(10, 64)
        Me.LabelX15.Name = "LabelX15"
        Me.LabelX15.Size = New System.Drawing.Size(126, 17)
        Me.LabelX15.TabIndex = 92
        Me.LabelX15.Text = "Total a Pagar Deuda:"
        '
        'lblPagoDeuda
        '
        Me.lblPagoDeuda.BackColor = System.Drawing.Color.Transparent
        Me.lblPagoDeuda.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPagoDeuda.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblPagoDeuda.Location = New System.Drawing.Point(153, 60)
        Me.lblPagoDeuda.Name = "lblPagoDeuda"
        Me.lblPagoDeuda.Size = New System.Drawing.Size(86, 21)
        Me.lblPagoDeuda.TabIndex = 93
        Me.lblPagoDeuda.Text = "-"
        Me.lblPagoDeuda.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelX14
        '
        Me.LabelX14.AutoSize = True
        Me.LabelX14.BackColor = System.Drawing.Color.Transparent
        Me.LabelX14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX14.Location = New System.Drawing.Point(262, 62)
        Me.LabelX14.Name = "LabelX14"
        Me.LabelX14.Size = New System.Drawing.Size(84, 17)
        Me.LabelX14.TabIndex = 94
        Me.LabelX14.Text = "Total a Pagar:"
        '
        'LabelX5
        '
        Me.LabelX5.AutoSize = True
        Me.LabelX5.BackColor = System.Drawing.Color.Transparent
        Me.LabelX5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX5.Location = New System.Drawing.Point(262, 36)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(42, 17)
        Me.LabelX5.TabIndex = 95
        Me.LabelX5.Text = "Monto:"
        '
        'lblPagoTotal
        '
        Me.lblPagoTotal.BackColor = System.Drawing.Color.Transparent
        Me.lblPagoTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPagoTotal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblPagoTotal.Location = New System.Drawing.Point(369, 61)
        Me.lblPagoTotal.Name = "lblPagoTotal"
        Me.lblPagoTotal.Size = New System.Drawing.Size(78, 18)
        Me.lblPagoTotal.TabIndex = 96
        Me.lblPagoTotal.Text = "-"
        Me.lblPagoTotal.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelX17
        '
        Me.LabelX17.AutoSize = True
        Me.LabelX17.BackColor = System.Drawing.Color.Transparent
        Me.LabelX17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX17.Location = New System.Drawing.Point(262, 7)
        Me.LabelX17.Name = "LabelX17"
        Me.LabelX17.Size = New System.Drawing.Size(69, 17)
        Me.LabelX17.TabIndex = 117
        Me.LabelX17.Text = "Referencia:"
        '
        'lblMonto
        '
        Me.lblMonto.BackColor = System.Drawing.Color.Transparent
        Me.lblMonto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMonto.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblMonto.Location = New System.Drawing.Point(380, 38)
        Me.lblMonto.Name = "lblMonto"
        Me.lblMonto.Size = New System.Drawing.Size(65, 18)
        Me.lblMonto.TabIndex = 97
        Me.lblMonto.Text = "-"
        Me.lblMonto.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelX18
        '
        Me.LabelX18.AutoSize = True
        Me.LabelX18.BackColor = System.Drawing.Color.Transparent
        Me.LabelX18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX18.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LabelX18.Location = New System.Drawing.Point(9, 34)
        Me.LabelX18.Name = "LabelX18"
        Me.LabelX18.Size = New System.Drawing.Size(127, 17)
        Me.LabelX18.TabIndex = 100
        Me.LabelX18.Text = "Total a Pagar Interes:"
        '
        'lblPagoInteres
        '
        Me.lblPagoInteres.BackColor = System.Drawing.Color.Transparent
        Me.lblPagoInteres.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPagoInteres.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblPagoInteres.Location = New System.Drawing.Point(146, 38)
        Me.lblPagoInteres.Name = "lblPagoInteres"
        Me.lblPagoInteres.Size = New System.Drawing.Size(93, 18)
        Me.lblPagoInteres.TabIndex = 101
        Me.lblPagoInteres.Text = "-"
        Me.lblPagoInteres.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'lblPagoTotalRedondeo
        '
        Me.lblPagoTotalRedondeo.BackColor = System.Drawing.Color.Transparent
        Me.lblPagoTotalRedondeo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPagoTotalRedondeo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblPagoTotalRedondeo.Location = New System.Drawing.Point(836, 58)
        Me.lblPagoTotalRedondeo.Name = "lblPagoTotalRedondeo"
        Me.lblPagoTotalRedondeo.Size = New System.Drawing.Size(97, 20)
        Me.lblPagoTotalRedondeo.TabIndex = 103
        Me.lblPagoTotalRedondeo.Text = "-"
        Me.lblPagoTotalRedondeo.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelX20
        '
        Me.LabelX20.AutoSize = True
        Me.LabelX20.BackColor = System.Drawing.Color.Transparent
        Me.LabelX20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX20.Location = New System.Drawing.Point(677, 61)
        Me.LabelX20.Name = "LabelX20"
        Me.LabelX20.Size = New System.Drawing.Size(153, 17)
        Me.LabelX20.TabIndex = 102
        Me.LabelX20.Text = "Total a Pagar(Redondeo):"
        '
        'GroupPanel3
        '
        Me.GroupPanel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupPanel3.BackColor = System.Drawing.Color.Transparent
        Me.GroupPanel3.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel3.Controls.Add(Me.txtObservaciones)
        Me.GroupPanel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupPanel3.Location = New System.Drawing.Point(784, -1)
        Me.GroupPanel3.Name = "GroupPanel3"
        Me.GroupPanel3.Size = New System.Drawing.Size(220, 358)
        '
        '
        '
        Me.GroupPanel3.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel3.Style.BackColorGradientAngle = 90
        Me.GroupPanel3.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel3.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel3.Style.BorderBottomWidth = 1
        Me.GroupPanel3.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel3.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel3.Style.BorderLeftWidth = 1
        Me.GroupPanel3.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel3.Style.BorderRightWidth = 1
        Me.GroupPanel3.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel3.Style.BorderTopWidth = 1
        Me.GroupPanel3.Style.CornerDiameter = 4
        Me.GroupPanel3.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel3.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel3.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel3.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        Me.GroupPanel3.TabIndex = 124
        Me.GroupPanel3.Text = "Detalles"
        '
        'txtObservaciones
        '
        Me.txtObservaciones.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        '
        '
        '
        Me.txtObservaciones.Border.Class = "TextBoxBorder"
        Me.txtObservaciones.Location = New System.Drawing.Point(3, 3)
        Me.txtObservaciones.Multiline = True
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Size = New System.Drawing.Size(208, 330)
        Me.txtObservaciones.TabIndex = 110
        Me.txtObservaciones.WatermarkText = "Observaciones de Cobranza"
        '
        'txtDni
        '
        Me.txtDni.BackColor = System.Drawing.Color.PowderBlue
        '
        '
        '
        Me.txtDni.Border.Class = "TextBoxBorder"
        Me.txtDni.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDni.Location = New System.Drawing.Point(499, 35)
        Me.txtDni.Name = "txtDni"
        Me.txtDni.Size = New System.Drawing.Size(87, 21)
        Me.txtDni.TabIndex = 123
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        Me.LabelX4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX4.Location = New System.Drawing.Point(434, 34)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(38, 20)
        Me.LabelX4.TabIndex = 122
        Me.LabelX4.Text = "DNI:"
        Me.LabelX4.WordWrap = True
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        Me.LabelX3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX3.Location = New System.Drawing.Point(433, 63)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(38, 20)
        Me.LabelX3.TabIndex = 120
        Me.LabelX3.Text = "Nro:"
        Me.LabelX3.WordWrap = True
        '
        'ButtonX1
        '
        Me.ButtonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX1.Image = Global.COBSER.My.Resources.Resources.config_users
        Me.ButtonX1.Location = New System.Drawing.Point(784, 363)
        Me.ButtonX1.Name = "ButtonX1"
        Me.ButtonX1.Size = New System.Drawing.Size(220, 49)
        Me.ButtonX1.TabIndex = 26
        Me.ButtonX1.Text = "Estado Cuenta del Usuario"
        '
        'LabelX8
        '
        Me.LabelX8.BackColor = System.Drawing.Color.Transparent
        Me.LabelX8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX8.Location = New System.Drawing.Point(11, 63)
        Me.LabelX8.Name = "LabelX8"
        Me.LabelX8.Size = New System.Drawing.Size(73, 20)
        Me.LabelX8.TabIndex = 13
        Me.LabelX8.Text = "Predios:"
        Me.LabelX8.WordWrap = True
        '
        'LabelX1
        '
        Me.LabelX1.AutoSize = True
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        Me.LabelX1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.Location = New System.Drawing.Point(11, 35)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(51, 17)
        Me.LabelX1.TabIndex = 3
        Me.LabelX1.Text = "Usuario:"
        '
        'txtUsuario
        '
        Me.txtUsuario.BackColor = System.Drawing.Color.PowderBlue
        '
        '
        '
        Me.txtUsuario.Border.Class = "TextBoxBorder"
        Me.txtUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUsuario.Location = New System.Drawing.Point(103, 35)
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.ReadOnly = True
        Me.txtUsuario.Size = New System.Drawing.Size(285, 22)
        Me.txtUsuario.TabIndex = 2
        Me.txtUsuario.Text = "-"
        Me.txtUsuario.WatermarkText = "Nombre de Usuario"
        '
        'GroupPanel2
        '
        Me.GroupPanel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupPanel2.BackColor = System.Drawing.Color.Transparent
        Me.GroupPanel2.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.tvDeudas)
        Me.GroupPanel2.Controls.Add(Me.Bar6)
        Me.GroupPanel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupPanel2.Location = New System.Drawing.Point(3, 118)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(775, 295)
        '
        '
        '
        Me.GroupPanel2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel2.Style.BackColorGradientAngle = 90
        Me.GroupPanel2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderBottomWidth = 1
        Me.GroupPanel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderLeftWidth = 1
        Me.GroupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderRightWidth = 1
        Me.GroupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderTopWidth = 1
        Me.GroupPanel2.Style.CornerDiameter = 4
        Me.GroupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        Me.GroupPanel2.TabIndex = 8
        Me.GroupPanel2.Text = "Facturaciones Pendientes"
        '
        'tvDeudas
        '
        Me.tvDeudas.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline
        Me.tvDeudas.AllowDrop = True
        Me.tvDeudas.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.tvDeudas.BackgroundStyle.Class = "TreeBorderKey"
        Me.tvDeudas.Columns.Add(Me.Año)
        Me.tvDeudas.Columns.Add(Me.Mes)
        Me.tvDeudas.Columns.Add(Me.NroFactura)
        Me.tvDeudas.Columns.Add(Me.Monto)
        Me.tvDeudas.Columns.Add(Me.MontoS)
        Me.tvDeudas.Columns.Add(Me.Mora)
        Me.tvDeudas.Columns.Add(Me.Volumen)
        Me.tvDeudas.Columns.Add(Me.Servicio)
        Me.tvDeudas.Columns.Add(Me.Id)
        Me.tvDeudas.Columns.Add(Me.IdMes)
        Me.tvDeudas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvDeudas.DragDropEnabled = False
        Me.tvDeudas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tvDeudas.GridRowLines = True
        Me.tvDeudas.Location = New System.Drawing.Point(0, 25)
        Me.tvDeudas.Name = "tvDeudas"
        Me.tvDeudas.NodesConnector = Me.NodeConnector1
        Me.tvDeudas.NodeStyle = Me.ElementStyle1
        Me.tvDeudas.PathSeparator = ";"
        Me.tvDeudas.Size = New System.Drawing.Size(769, 248)
        Me.tvDeudas.Styles.Add(Me.ElementStyle1)
        Me.tvDeudas.Styles.Add(Me.ElementStyle2)
        Me.tvDeudas.SuspendPaint = False
        Me.tvDeudas.TabIndex = 0
        Me.tvDeudas.Text = "AdvTree1"
        '
        'Año
        '
        Me.Año.Name = "Año"
        Me.Año.Text = "Año"
        Me.Año.Width.Absolute = 90
        '
        'Mes
        '
        Me.Mes.Name = "Mes"
        Me.Mes.Text = "Mes"
        Me.Mes.Width.Absolute = 60
        '
        'NroFactura
        '
        Me.NroFactura.Name = "NroFactura"
        Me.NroFactura.Text = "Nro Factura"
        Me.NroFactura.Width.Absolute = 90
        '
        'Monto
        '
        Me.Monto.EditorType = DevComponents.AdvTree.eCellEditorType.NumericDouble
        Me.Monto.Name = "Monto"
        Me.Monto.Text = "Monto Total"
        Me.Monto.Width.Absolute = 80
        '
        'MontoS
        '
        Me.MontoS.Name = "MontoS"
        Me.MontoS.Text = "Monto Fact."
        Me.MontoS.Width.Absolute = 70
        '
        'Mora
        '
        Me.Mora.Name = "Mora"
        Me.Mora.Text = "Mora"
        Me.Mora.Width.Absolute = 70
        '
        'Volumen
        '
        Me.Volumen.Name = "Volumen"
        Me.Volumen.Text = "Volumen"
        Me.Volumen.Width.Absolute = 70
        '
        'Servicio
        '
        Me.Servicio.Name = "Servicio"
        Me.Servicio.Text = "Servicio"
        Me.Servicio.Width.Absolute = 90
        '
        'Id
        '
        Me.Id.EditorType = DevComponents.AdvTree.eCellEditorType.NumericInteger
        Me.Id.Name = "Id"
        Me.Id.Text = "IdFactura"
        Me.Id.Width.Absolute = 50
        '
        'IdMes
        '
        Me.IdMes.Name = "IdMes"
        Me.IdMes.Text = "IdMes"
        Me.IdMes.Width.Absolute = 40
        '
        'NodeConnector1
        '
        Me.NodeConnector1.LineColor = System.Drawing.SystemColors.ControlText
        '
        'ElementStyle1
        '
        Me.ElementStyle1.Name = "ElementStyle1"
        Me.ElementStyle1.TextColor = System.Drawing.SystemColors.ControlText
        '
        'ElementStyle2
        '
        Me.ElementStyle2.Name = "ElementStyle2"
        Me.ElementStyle2.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Far
        Me.ElementStyle2.TextColor = System.Drawing.SystemColors.ActiveCaptionText
        '
        'Bar6
        '
        Me.Bar6.Controls.Add(Me.chkSelectAll)
        Me.Bar6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar6.Location = New System.Drawing.Point(0, 0)
        Me.Bar6.Name = "Bar6"
        Me.Bar6.Size = New System.Drawing.Size(769, 25)
        Me.Bar6.Stretch = True
        Me.Bar6.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Bar6.TabIndex = 2
        Me.Bar6.TabStop = False
        Me.Bar6.Text = "Bar6"
        '
        'chkSelectAll
        '
        Me.chkSelectAll.AutoSize = True
        Me.chkSelectAll.BackColor = System.Drawing.Color.Transparent
        Me.chkSelectAll.Location = New System.Drawing.Point(16, 0)
        Me.chkSelectAll.Name = "chkSelectAll"
        Me.chkSelectAll.Size = New System.Drawing.Size(117, 18)
        Me.chkSelectAll.TabIndex = 0
        Me.chkSelectAll.Text = "Seleccionar Todos"
        '
        'Bar3
        '
        Me.Bar3.Controls.Add(Me.lblFecha)
        Me.Bar3.Controls.Add(Me.LabelX23)
        Me.Bar3.Controls.Add(Me.cmbJunta)
        Me.Bar3.Controls.Add(Me.LabelX13)
        Me.Bar3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar3.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ControlContainerItem1, Me.ControlContainerItem3})
        Me.Bar3.Location = New System.Drawing.Point(0, 0)
        Me.Bar3.Name = "Bar3"
        Me.Bar3.Size = New System.Drawing.Size(1019, 30)
        Me.Bar3.Stretch = True
        Me.Bar3.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Bar3.TabIndex = 5
        Me.Bar3.TabStop = False
        Me.Bar3.Text = "Bar3"
        '
        'lblFecha
        '
        Me.lblFecha.BackColor = System.Drawing.Color.Transparent
        Me.lblFecha.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFecha.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblFecha.Location = New System.Drawing.Point(800, 2)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(83, 23)
        Me.lblFecha.TabIndex = 5
        Me.lblFecha.Text = "12/12/2012"
        '
        'LabelX23
        '
        Me.LabelX23.BackColor = System.Drawing.Color.Transparent
        Me.LabelX23.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX23.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LabelX23.Location = New System.Drawing.Point(719, 2)
        Me.LabelX23.Name = "LabelX23"
        Me.LabelX23.Size = New System.Drawing.Size(75, 23)
        Me.LabelX23.TabIndex = 4
        Me.LabelX23.Text = "F. Cobranza:"
        '
        'cmbJunta
        '
        Me.cmbJunta.DisplayMember = "Text"
        Me.cmbJunta.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbJunta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbJunta.Enabled = False
        Me.cmbJunta.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbJunta.FormattingEnabled = True
        Me.cmbJunta.ItemHeight = 19
        Me.cmbJunta.Location = New System.Drawing.Point(110, 2)
        Me.cmbJunta.Name = "cmbJunta"
        Me.cmbJunta.Size = New System.Drawing.Size(248, 25)
        Me.cmbJunta.TabIndex = 3
        '
        'LabelX13
        '
        Me.LabelX13.BackColor = System.Drawing.Color.Transparent
        Me.LabelX13.Location = New System.Drawing.Point(3, 5)
        Me.LabelX13.Name = "LabelX13"
        Me.LabelX13.Size = New System.Drawing.Size(103, 19)
        Me.LabelX13.TabIndex = 1
        Me.LabelX13.Text = "JASS:"
        '
        'ControlContainerItem1
        '
        Me.ControlContainerItem1.AllowItemResize = False
        Me.ControlContainerItem1.Control = Me.LabelX13
        Me.ControlContainerItem1.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
        Me.ControlContainerItem1.Name = "ControlContainerItem1"
        '
        'ControlContainerItem3
        '
        Me.ControlContainerItem3.AllowItemResize = False
        Me.ControlContainerItem3.Control = Me.cmbJunta
        Me.ControlContainerItem3.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
        Me.ControlContainerItem3.Name = "ControlContainerItem3"
        '
        'Bar1
        '
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem3, Me.lblCaja, Me.btnSave, Me.btnCancel})
        Me.Bar1.Location = New System.Drawing.Point(0, 575)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(1019, 25)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Bar1.TabIndex = 3
        Me.Bar1.TabNavigation = True
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'LabelItem3
        '
        Me.LabelItem3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LabelItem3.Name = "LabelItem3"
        Me.LabelItem3.Text = "Caja de Cobranza: "
        '
        'lblCaja
        '
        Me.lblCaja.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblCaja.Name = "lblCaja"
        Me.lblCaja.Text = "-"
        '
        'btnSave
        '
        Me.btnSave.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnSave.Enabled = False
        Me.btnSave.Image = Global.COBSER.My.Resources.Resources.coins
        Me.btnSave.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.btnSave.ImagePaddingHorizontal = 8
        Me.btnSave.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Text = "Cobrar Deuda"
        '
        'btnCancel
        '
        Me.btnCancel.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnCancel.Image = Global.COBSER.My.Resources.Resources.cross
        Me.btnCancel.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.btnCancel.ImagePaddingHorizontal = 8
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Text = "Cancelar"
        '
        'ComboItem2
        '
        Me.ComboItem2.Text = "NOTA DE DEBITO"
        '
        'ComboItem1
        '
        Me.ComboItem1.Text = "CONTADO"
        '
        'LabelX9
        '
        Me.LabelX9.AutoSize = True
        Me.LabelX9.BackColor = System.Drawing.Color.Transparent
        Me.LabelX9.Location = New System.Drawing.Point(0, 2)
        Me.LabelX9.Name = "LabelX9"
        Me.LabelX9.Size = New System.Drawing.Size(0, 0)
        Me.LabelX9.TabIndex = 134
        Me.LabelX9.Text = "Filtrar por Año"
        '
        'Node1
        '
        Me.Node1.Expanded = True
        Me.Node1.HostedControl = Me.LabelX9
        Me.Node1.Name = "Node1"
        Me.Node1.Text = "Node1"
        '
        'LabelX10
        '
        Me.LabelX10.BackColor = System.Drawing.Color.Transparent
        Me.LabelX10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX10.Location = New System.Drawing.Point(405, 224)
        Me.LabelX10.Name = "LabelX10"
        Me.LabelX10.Size = New System.Drawing.Size(66, 20)
        Me.LabelX10.TabIndex = 132
        Me.LabelX10.Text = "Año Tarifa:"
        Me.LabelX10.WordWrap = True
        '
        'Node2
        '
        Me.Node2.Expanded = True
        Me.Node2.HostedControl = Me.LabelX10
        Me.Node2.Name = "Node2"
        Me.Node2.Text = "Node2"
        '
        'frmCobranzaNew
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1019, 600)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.Bar3)
        Me.Controls.Add(Me.Bar1)
        Me.Name = "frmCobranzaNew"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frmCobranzaNew"
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupPanel1.PerformLayout()
        Me.GroupPanel4.ResumeLayout(False)
        Me.GroupPanel4.PerformLayout()
        Me.GroupPanel3.ResumeLayout(False)
        Me.GroupPanel2.ResumeLayout(False)
        CType(Me.tvDeudas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Bar6.ResumeLayout(False)
        Me.Bar6.PerformLayout()
        CType(Me.Bar3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Bar3.ResumeLayout(False)
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents txtReferencia As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX17 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblPagoTotalRedondeo As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX20 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblPagoInteres As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX18 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblMonto As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblPagoTotal As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX14 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblPagoDeuda As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX15 As DevComponents.DotNetBar.LabelX
    Friend WithEvents ButtonX1 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtUsuario As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents tvDeudas As DevComponents.AdvTree.AdvTree
    Friend WithEvents Monto As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents NroFactura As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents Id As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents NodeConnector1 As DevComponents.AdvTree.NodeConnector
    Friend WithEvents ElementStyle1 As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents ElementStyle2 As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents Bar6 As DevComponents.DotNetBar.Bar
    Friend WithEvents chkSelectAll As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Bar3 As DevComponents.DotNetBar.Bar
    Friend WithEvents lblFecha As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX23 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cmbJunta As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX13 As DevComponents.DotNetBar.LabelX
    Friend WithEvents ControlContainerItem1 As DevComponents.DotNetBar.ControlContainerItem
    Friend WithEvents ControlContainerItem3 As DevComponents.DotNetBar.ControlContainerItem
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents LabelItem3 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents lblCaja As DevComponents.DotNetBar.LabelItem
    Friend WithEvents btnSave As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnCancel As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cmbTipoPago As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents ComboItem2 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem1 As DevComponents.Editors.ComboItem
    Friend WithEvents LabelX8 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtDni As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents GroupPanel4 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents GroupPanel3 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents txtObservaciones As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Mes As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents txtAnioVigente As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtPredio As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtNro As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Año As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents LabelX9 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Node1 As DevComponents.AdvTree.Node
    Friend WithEvents LabelX10 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Node2 As DevComponents.AdvTree.Node
    Friend WithEvents LabelX11 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cmbAnio As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents Volumen As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents Servicio As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents IdMes As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents Mora As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents MontoS As DevComponents.AdvTree.ColumnHeader
End Class
