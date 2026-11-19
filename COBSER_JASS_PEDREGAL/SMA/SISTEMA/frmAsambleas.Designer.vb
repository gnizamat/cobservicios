<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAsambleas
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
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Bar1 = New DevComponents.DotNetBar.Bar
        Me.cmbJunta = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX
        Me.Bar2 = New DevComponents.DotNetBar.Bar
        Me.btnGenerar = New DevComponents.DotNetBar.ButtonItem
        Me.btnResolucionNew = New DevComponents.DotNetBar.ButtonItem
        Me.btnResolucionUpd = New DevComponents.DotNetBar.ButtonItem
        Me.btnResolucionDel = New DevComponents.DotNetBar.ButtonItem
        Me.btnActiva = New DevComponents.DotNetBar.ButtonItem
        Me.btnSalir = New DevComponents.DotNetBar.ButtonItem
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.txtFecha = New DevComponents.Editors.DateTimeAdv.DateTimeInput
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX
        Me.cmbTipoAsamblea = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.Ordinaria = New DevComponents.Editors.ComboItem
        Me.extra = New DevComponents.Editors.ComboItem
        Me.lblA2 = New DevComponents.DotNetBar.LabelX
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX
        Me.cmbAmbito = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.Junta = New DevComponents.Editors.ComboItem
        Me.Comision = New DevComponents.Editors.ComboItem
        Me.txtAnio = New DevComponents.Editors.IntegerInput
        Me.cmbCPoblado = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.LabelX25 = New DevComponents.DotNetBar.LabelX
        Me.txtDescripcion = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX
        Me.LabelX8 = New DevComponents.DotNetBar.LabelX
        Me.dgAsambleas = New DevComponents.DotNetBar.Controls.DataGridViewX
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Bar1.SuspendLayout()
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAnio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgAsambleas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bar1
        '
        Me.Bar1.Controls.Add(Me.cmbJunta)
        Me.Bar1.Controls.Add(Me.LabelX1)
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Bar1.Location = New System.Drawing.Point(0, 0)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(784, 25)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Bar1.TabIndex = 18
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'cmbJunta
        '
        Me.cmbJunta.DisplayMember = "Text"
        Me.cmbJunta.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbJunta.DropDownHeight = 250
        Me.cmbJunta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbJunta.FormattingEnabled = True
        Me.cmbJunta.IntegralHeight = False
        Me.cmbJunta.ItemHeight = 17
        Me.cmbJunta.Location = New System.Drawing.Point(116, 0)
        Me.cmbJunta.Name = "cmbJunta"
        Me.cmbJunta.Size = New System.Drawing.Size(369, 23)
        Me.cmbJunta.TabIndex = 1
        Me.cmbJunta.WatermarkText = "Seleccione una Junta de Usuarios"
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        Me.LabelX1.Location = New System.Drawing.Point(13, 3)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(134, 19)
        Me.LabelX1.TabIndex = 0
        Me.LabelX1.Text = "JASS:"
        '
        'Bar2
        '
        Me.Bar2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar2.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnGenerar, Me.btnResolucionNew, Me.btnResolucionUpd, Me.btnResolucionDel, Me.btnActiva, Me.btnSalir})
        Me.Bar2.Location = New System.Drawing.Point(0, 464)
        Me.Bar2.Name = "Bar2"
        Me.Bar2.Size = New System.Drawing.Size(784, 25)
        Me.Bar2.Stretch = True
        Me.Bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Bar2.TabIndex = 16
        Me.Bar2.TabStop = False
        Me.Bar2.Text = "Bar2"
        '
        'btnGenerar
        '
        Me.btnGenerar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnGenerar.Image = Global.COBSER.My.Resources.Resources.application_side_boxes
        Me.btnGenerar.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.btnGenerar.ImagePaddingHorizontal = 8
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Text = "Generar Padron "
        '
        'btnResolucionNew
        '
        Me.btnResolucionNew.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnResolucionNew.Image = Global.COBSER.My.Resources.Resources.add
        Me.btnResolucionNew.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.btnResolucionNew.ImagePaddingHorizontal = 8
        Me.btnResolucionNew.Name = "btnResolucionNew"
        Me.btnResolucionNew.Text = "Nueva Asamblea"
        '
        'btnResolucionUpd
        '
        Me.btnResolucionUpd.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnResolucionUpd.Image = Global.COBSER.My.Resources.Resources.pencil
        Me.btnResolucionUpd.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.btnResolucionUpd.ImagePaddingHorizontal = 8
        Me.btnResolucionUpd.Name = "btnResolucionUpd"
        Me.btnResolucionUpd.Text = "Editar Asamblea"
        '
        'btnResolucionDel
        '
        Me.btnResolucionDel.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnResolucionDel.Image = Global.COBSER.My.Resources.Resources.delete
        Me.btnResolucionDel.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.btnResolucionDel.ImagePaddingHorizontal = 8
        Me.btnResolucionDel.Name = "btnResolucionDel"
        Me.btnResolucionDel.Text = "Eliminar Asamblea"
        '
        'btnActiva
        '
        Me.btnActiva.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnActiva.Image = Global.COBSER.My.Resources.Resources.accept
        Me.btnActiva.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.btnActiva.ImagePaddingHorizontal = 8
        Me.btnActiva.Name = "btnActiva"
        Me.btnActiva.Text = "Activar/Desactivar"
        '
        'btnSalir
        '
        Me.btnSalir.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnSalir.EnableMarkup = False
        Me.btnSalir.Image = Global.COBSER.My.Resources.Resources.cross
        Me.btnSalir.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.btnSalir.ImagePaddingHorizontal = 8
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Text = "Salir"
        '
        'GroupPanel1
        '
        Me.GroupPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.txtFecha)
        Me.GroupPanel1.Controls.Add(Me.LabelX2)
        Me.GroupPanel1.Controls.Add(Me.cmbTipoAsamblea)
        Me.GroupPanel1.Controls.Add(Me.lblA2)
        Me.GroupPanel1.Controls.Add(Me.LabelX6)
        Me.GroupPanel1.Controls.Add(Me.cmbAmbito)
        Me.GroupPanel1.Controls.Add(Me.txtAnio)
        Me.GroupPanel1.Controls.Add(Me.cmbCPoblado)
        Me.GroupPanel1.Controls.Add(Me.LabelX25)
        Me.GroupPanel1.Controls.Add(Me.txtDescripcion)
        Me.GroupPanel1.Controls.Add(Me.LabelX5)
        Me.GroupPanel1.Controls.Add(Me.LabelX8)
        Me.GroupPanel1.DrawTitleBox = False
        Me.GroupPanel1.Location = New System.Drawing.Point(0, 28)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(783, 142)
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
        Me.GroupPanel1.TabIndex = 34
        Me.GroupPanel1.Text = "Criterios de busqueda"
        '
        'txtFecha
        '
        '
        '
        '
        Me.txtFecha.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtFecha.ButtonDropDown.Visible = True
        Me.txtFecha.Location = New System.Drawing.Point(610, 78)
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
        Me.txtFecha.Size = New System.Drawing.Size(146, 20)
        Me.txtFecha.TabIndex = 212
        '
        'LabelX2
        '
        Me.LabelX2.AutoSize = True
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        Me.LabelX2.Location = New System.Drawing.Point(516, 78)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(88, 15)
        Me.LabelX2.TabIndex = 179
        Me.LabelX2.Text = "Fecha Asamblea:"
        '
        'cmbTipoAsamblea
        '
        Me.cmbTipoAsamblea.DisplayMember = "Text"
        Me.cmbTipoAsamblea.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbTipoAsamblea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoAsamblea.FormattingEnabled = True
        Me.cmbTipoAsamblea.ItemHeight = 14
        Me.cmbTipoAsamblea.Items.AddRange(New Object() {Me.Ordinaria, Me.extra})
        Me.cmbTipoAsamblea.Location = New System.Drawing.Point(363, 75)
        Me.cmbTipoAsamblea.Name = "cmbTipoAsamblea"
        Me.cmbTipoAsamblea.Size = New System.Drawing.Size(138, 20)
        Me.cmbTipoAsamblea.TabIndex = 177
        '
        'Ordinaria
        '
        Me.Ordinaria.Text = "ORDINARIA"
        '
        'extra
        '
        Me.extra.Text = "EXTRAORDINARIA"
        '
        'lblA2
        '
        Me.lblA2.AutoSize = True
        Me.lblA2.BackColor = System.Drawing.Color.Transparent
        Me.lblA2.Location = New System.Drawing.Point(266, 75)
        Me.lblA2.Name = "lblA2"
        Me.lblA2.Size = New System.Drawing.Size(79, 15)
        Me.lblA2.TabIndex = 178
        Me.lblA2.Text = "Tipo Asamblea:"
        '
        'LabelX6
        '
        Me.LabelX6.AutoSize = True
        Me.LabelX6.BackColor = System.Drawing.Color.Transparent
        Me.LabelX6.Location = New System.Drawing.Point(10, 78)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(40, 15)
        Me.LabelX6.TabIndex = 176
        Me.LabelX6.Text = "Ambito:"
        '
        'cmbAmbito
        '
        Me.cmbAmbito.DisplayMember = "Text"
        Me.cmbAmbito.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbAmbito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAmbito.FormattingEnabled = True
        Me.cmbAmbito.ItemHeight = 14
        Me.cmbAmbito.Items.AddRange(New Object() {Me.Junta, Me.Comision})
        Me.cmbAmbito.Location = New System.Drawing.Point(96, 75)
        Me.cmbAmbito.Name = "cmbAmbito"
        Me.cmbAmbito.Size = New System.Drawing.Size(126, 20)
        Me.cmbAmbito.TabIndex = 175
        '
        'Junta
        '
        Me.Junta.Text = "PRINCIPAL"
        '
        'Comision
        '
        Me.Comision.Text = "ANEXO"
        '
        'txtAnio
        '
        '
        '
        '
        Me.txtAnio.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtAnio.Location = New System.Drawing.Point(651, 3)
        Me.txtAnio.Name = "txtAnio"
        Me.txtAnio.ShowUpDown = True
        Me.txtAnio.Size = New System.Drawing.Size(105, 20)
        Me.txtAnio.TabIndex = 174
        '
        'cmbCPoblado
        '
        Me.cmbCPoblado.DisplayMember = "Text"
        Me.cmbCPoblado.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbCPoblado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCPoblado.FormattingEnabled = True
        Me.cmbCPoblado.ItemHeight = 14
        Me.cmbCPoblado.Location = New System.Drawing.Point(96, 3)
        Me.cmbCPoblado.Name = "cmbCPoblado"
        Me.cmbCPoblado.Size = New System.Drawing.Size(260, 20)
        Me.cmbCPoblado.TabIndex = 172
        Me.cmbCPoblado.WatermarkText = "Seleccione un CP"
        '
        'LabelX25
        '
        Me.LabelX25.AutoSize = True
        Me.LabelX25.BackColor = System.Drawing.Color.Transparent
        Me.LabelX25.Location = New System.Drawing.Point(10, 3)
        Me.LabelX25.Name = "LabelX25"
        Me.LabelX25.Size = New System.Drawing.Size(60, 15)
        Me.LabelX25.TabIndex = 173
        Me.LabelX25.Text = "C. Poblado:"
        '
        'txtDescripcion
        '
        '
        '
        '
        Me.txtDescripcion.Border.Class = "TextBoxBorder"
        Me.txtDescripcion.Location = New System.Drawing.Point(97, 39)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(644, 20)
        Me.txtDescripcion.TabIndex = 149
        '
        'LabelX5
        '
        Me.LabelX5.AutoSize = True
        Me.LabelX5.BackColor = System.Drawing.Color.Transparent
        Me.LabelX5.Location = New System.Drawing.Point(10, 44)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(66, 15)
        Me.LabelX5.TabIndex = 158
        Me.LabelX5.Text = "Descripcion :"
        '
        'LabelX8
        '
        Me.LabelX8.AutoSize = True
        Me.LabelX8.BackColor = System.Drawing.Color.Transparent
        Me.LabelX8.Location = New System.Drawing.Point(610, 8)
        Me.LabelX8.Name = "LabelX8"
        Me.LabelX8.Size = New System.Drawing.Size(25, 15)
        Me.LabelX8.TabIndex = 144
        Me.LabelX8.Text = "Año:"
        '
        'dgAsambleas
        '
        Me.dgAsambleas.AllowUserToAddRows = False
        Me.dgAsambleas.AllowUserToDeleteRows = False
        Me.dgAsambleas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgAsambleas.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle19
        Me.dgAsambleas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgAsambleas.DefaultCellStyle = DataGridViewCellStyle20
        Me.dgAsambleas.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgAsambleas.Location = New System.Drawing.Point(0, 176)
        Me.dgAsambleas.Name = "dgAsambleas"
        Me.dgAsambleas.ReadOnly = True
        DataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgAsambleas.RowHeadersDefaultCellStyle = DataGridViewCellStyle21
        Me.dgAsambleas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgAsambleas.Size = New System.Drawing.Size(784, 282)
        Me.dgAsambleas.TabIndex = 35
        '
        'frmAsambleas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 489)
        Me.Controls.Add(Me.dgAsambleas)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.Bar2)
        Me.Name = "frmAsambleas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmAsambleas"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Bar1.ResumeLayout(False)
        CType(Me.Bar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupPanel1.PerformLayout()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAnio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgAsambleas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents cmbJunta As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Bar2 As DevComponents.DotNetBar.Bar
    Friend WithEvents btnGenerar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnResolucionNew As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnResolucionUpd As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnResolucionDel As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnActiva As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnSalir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents cmbCPoblado As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX25 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtDescripcion As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX8 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cmbTipoAsamblea As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents Ordinaria As DevComponents.Editors.ComboItem
    Friend WithEvents extra As DevComponents.Editors.ComboItem
    Friend WithEvents lblA2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cmbAmbito As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents Junta As DevComponents.Editors.ComboItem
    Friend WithEvents Comision As DevComponents.Editors.ComboItem
    Friend WithEvents txtAnio As DevComponents.Editors.IntegerInput
    Friend WithEvents dgAsambleas As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtFecha As DevComponents.Editors.DateTimeAdv.DateTimeInput
End Class
