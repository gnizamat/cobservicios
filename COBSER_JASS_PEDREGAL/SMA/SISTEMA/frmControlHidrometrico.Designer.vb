<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmControlHidrometrico
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
        Me.btnSalir = New DevComponents.DotNetBar.ButtonItem
        Me.ButtonItem1 = New DevComponents.DotNetBar.ButtonItem
        Me.btnEliminar = New DevComponents.DotNetBar.ButtonItem
        Me.btnGrabar = New DevComponents.DotNetBar.ButtonItem
        Me.btnNuevo = New DevComponents.DotNetBar.ButtonItem
        Me.ExpandablePanel2 = New DevComponents.DotNetBar.ExpandablePanel
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.cmbMes = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.ComboItem1 = New DevComponents.Editors.ComboItem
        Me.ComboItem2 = New DevComponents.Editors.ComboItem
        Me.txtCaudal = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.LabelX13 = New DevComponents.DotNetBar.LabelX
        Me.txtTipo = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.txtEstructuta = New DevComponents.DotNetBar.LabelX
        Me.txtFechaL = New DevComponents.Editors.DateTimeAdv.DateTimeInput
        Me.cmbEstructura = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.txtSegundos = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.txtHoras = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.txtFechaFinal = New DevComponents.Editors.DateTimeAdv.DateTimeInput
        Me.txtFechaInicio = New DevComponents.Editors.DateTimeAdv.DateTimeInput
        Me.txtFinal = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.LabelX9 = New DevComponents.DotNetBar.LabelX
        Me.txtObserv = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.LabelX10 = New DevComponents.DotNetBar.LabelX
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX
        Me.txtFechaRegistro = New DevComponents.Editors.DateTimeAdv.DateTimeInput
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX
        Me.txtModelo = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.LabelX8 = New DevComponents.DotNetBar.LabelX
        Me.LabelX12 = New DevComponents.DotNetBar.LabelX
        Me.txtVolumen = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.LabelX23 = New DevComponents.DotNetBar.LabelX
        Me.LabelX22 = New DevComponents.DotNetBar.LabelX
        Me.txtCloroFin = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.txtCloroIni = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.LabelX21 = New DevComponents.DotNetBar.LabelX
        Me.txtInicial = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.LabelX20 = New DevComponents.DotNetBar.LabelX
        Me.LabelX11 = New DevComponents.DotNetBar.LabelX
        Me.LabelX18 = New DevComponents.DotNetBar.LabelX
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX
        Me.cmbAnio = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX
        Me.cmbJunta = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX
        Me.gridLecturas = New DevComponents.DotNetBar.Controls.DataGridViewX
        Me.Bar6 = New DevComponents.DotNetBar.Bar
        Me.ButtonItem2 = New DevComponents.DotNetBar.ButtonItem
        Me.ButtonItem3 = New DevComponents.DotNetBar.ButtonItem
        Me.btnDelete = New DevComponents.DotNetBar.ButtonItem
        Me.btnSave = New DevComponents.DotNetBar.ButtonItem
        Me.btnNew = New DevComponents.DotNetBar.ButtonItem
        Me.ExpandablePanel2.SuspendLayout()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.txtFechaL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaFinal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaInicio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaRegistro, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridLecturas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bar6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        'ExpandablePanel2
        '
        Me.ExpandablePanel2.CanvasColor = System.Drawing.SystemColors.Control
        Me.ExpandablePanel2.CollapseDirection = DevComponents.DotNetBar.eCollapseDirection.RightToLeft
        Me.ExpandablePanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.ExpandablePanel2.Controls.Add(Me.GroupPanel1)
        Me.ExpandablePanel2.Controls.Add(Me.gridLecturas)
        Me.ExpandablePanel2.ExpandButtonVisible = False
        Me.ExpandablePanel2.Location = New System.Drawing.Point(-2, -3)
        Me.ExpandablePanel2.Name = "ExpandablePanel2"
        Me.ExpandablePanel2.Size = New System.Drawing.Size(660, 489)
        Me.ExpandablePanel2.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.ExpandablePanel2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.ExpandablePanel2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.ExpandablePanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.ExpandablePanel2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.ExpandablePanel2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
        Me.ExpandablePanel2.Style.GradientAngle = 90
        Me.ExpandablePanel2.TabIndex = 203
        Me.ExpandablePanel2.TitleStyle.Alignment = System.Drawing.StringAlignment.Center
        Me.ExpandablePanel2.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.ExpandablePanel2.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.ExpandablePanel2.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner
        Me.ExpandablePanel2.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.ExpandablePanel2.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.ExpandablePanel2.TitleStyle.GradientAngle = 90
        Me.ExpandablePanel2.TitleText = "Listado de Lecturas"
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.cmbMes)
        Me.GroupPanel1.Controls.Add(Me.txtCaudal)
        Me.GroupPanel1.Controls.Add(Me.LabelX13)
        Me.GroupPanel1.Controls.Add(Me.txtTipo)
        Me.GroupPanel1.Controls.Add(Me.txtEstructuta)
        Me.GroupPanel1.Controls.Add(Me.txtFechaL)
        Me.GroupPanel1.Controls.Add(Me.cmbEstructura)
        Me.GroupPanel1.Controls.Add(Me.txtSegundos)
        Me.GroupPanel1.Controls.Add(Me.txtHoras)
        Me.GroupPanel1.Controls.Add(Me.txtFechaFinal)
        Me.GroupPanel1.Controls.Add(Me.txtFechaInicio)
        Me.GroupPanel1.Controls.Add(Me.txtFinal)
        Me.GroupPanel1.Controls.Add(Me.LabelX9)
        Me.GroupPanel1.Controls.Add(Me.txtObserv)
        Me.GroupPanel1.Controls.Add(Me.LabelX10)
        Me.GroupPanel1.Controls.Add(Me.LabelX5)
        Me.GroupPanel1.Controls.Add(Me.LabelX4)
        Me.GroupPanel1.Controls.Add(Me.txtFechaRegistro)
        Me.GroupPanel1.Controls.Add(Me.LabelX2)
        Me.GroupPanel1.Controls.Add(Me.txtModelo)
        Me.GroupPanel1.Controls.Add(Me.LabelX8)
        Me.GroupPanel1.Controls.Add(Me.LabelX12)
        Me.GroupPanel1.Controls.Add(Me.txtVolumen)
        Me.GroupPanel1.Controls.Add(Me.LabelX23)
        Me.GroupPanel1.Controls.Add(Me.LabelX22)
        Me.GroupPanel1.Controls.Add(Me.txtCloroFin)
        Me.GroupPanel1.Controls.Add(Me.txtCloroIni)
        Me.GroupPanel1.Controls.Add(Me.LabelX21)
        Me.GroupPanel1.Controls.Add(Me.txtInicial)
        Me.GroupPanel1.Controls.Add(Me.LabelX20)
        Me.GroupPanel1.Controls.Add(Me.LabelX11)
        Me.GroupPanel1.Controls.Add(Me.LabelX18)
        Me.GroupPanel1.Controls.Add(Me.LabelX3)
        Me.GroupPanel1.Controls.Add(Me.cmbAnio)
        Me.GroupPanel1.Controls.Add(Me.LabelX6)
        Me.GroupPanel1.Controls.Add(Me.LabelX7)
        Me.GroupPanel1.Controls.Add(Me.cmbJunta)
        Me.GroupPanel1.Controls.Add(Me.LabelX1)
        Me.GroupPanel1.Location = New System.Drawing.Point(14, 28)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(646, 275)
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
        Me.GroupPanel1.TabIndex = 202
        '
        'cmbMes
        '
        Me.cmbMes.DisplayMember = "Text"
        Me.cmbMes.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMes.FormattingEnabled = True
        Me.cmbMes.ItemHeight = 14
        Me.cmbMes.Items.AddRange(New Object() {Me.ComboItem1, Me.ComboItem2})
        Me.cmbMes.Location = New System.Drawing.Point(337, 118)
        Me.cmbMes.Name = "cmbMes"
        Me.cmbMes.Size = New System.Drawing.Size(79, 20)
        Me.cmbMes.TabIndex = 231
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
        'txtCaudal
        '
        '
        '
        '
        Me.txtCaudal.Border.Class = "TextBoxBorder"
        Me.txtCaudal.Enabled = False
        Me.txtCaudal.Location = New System.Drawing.Point(504, 69)
        Me.txtCaudal.Name = "txtCaudal"
        Me.txtCaudal.Size = New System.Drawing.Size(102, 20)
        Me.txtCaudal.TabIndex = 230
        '
        'LabelX13
        '
        Me.LabelX13.AutoSize = True
        Me.LabelX13.BackColor = System.Drawing.Color.Transparent
        Me.LabelX13.Location = New System.Drawing.Point(401, 70)
        Me.LabelX13.Name = "LabelX13"
        Me.LabelX13.Size = New System.Drawing.Size(81, 15)
        Me.LabelX13.TabIndex = 229
        Me.LabelX13.Text = "Caudal Lt./Seg.:"
        '
        'txtTipo
        '
        '
        '
        '
        Me.txtTipo.Border.Class = "TextBoxBorder"
        Me.txtTipo.Enabled = False
        Me.txtTipo.Location = New System.Drawing.Point(101, 66)
        Me.txtTipo.Name = "txtTipo"
        Me.txtTipo.Size = New System.Drawing.Size(166, 20)
        Me.txtTipo.TabIndex = 228
        '
        'txtEstructuta
        '
        Me.txtEstructuta.AutoSize = True
        Me.txtEstructuta.BackColor = System.Drawing.Color.Transparent
        Me.txtEstructuta.Location = New System.Drawing.Point(15, 70)
        Me.txtEstructuta.Name = "txtEstructuta"
        Me.txtEstructuta.Size = New System.Drawing.Size(65, 15)
        Me.txtEstructuta.TabIndex = 227
        Me.txtEstructuta.Text = "T. Estructura"
        '
        'txtFechaL
        '
        '
        '
        '
        Me.txtFechaL.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtFechaL.ButtonDropDown.Visible = True
        Me.txtFechaL.Location = New System.Drawing.Point(504, 117)
        '
        '
        '
        Me.txtFechaL.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        Me.txtFechaL.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.txtFechaL.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.txtFechaL.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.txtFechaL.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.txtFechaL.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.txtFechaL.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.txtFechaL.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.txtFechaL.MonthCalendar.DisplayMonth = New Date(2010, 5, 1, 0, 0, 0, 0)
        Me.txtFechaL.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.txtFechaL.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.txtFechaL.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.txtFechaL.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.txtFechaL.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.txtFechaL.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.txtFechaL.MonthCalendar.TodayButtonVisible = True
        Me.txtFechaL.Name = "txtFechaL"
        Me.txtFechaL.Size = New System.Drawing.Size(101, 20)
        Me.txtFechaL.TabIndex = 226
        '
        'cmbEstructura
        '
        Me.cmbEstructura.DisplayMember = "Text"
        Me.cmbEstructura.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbEstructura.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstructura.Enabled = False
        Me.cmbEstructura.FormattingEnabled = True
        Me.cmbEstructura.ItemHeight = 14
        Me.cmbEstructura.Location = New System.Drawing.Point(101, 35)
        Me.cmbEstructura.Name = "cmbEstructura"
        Me.cmbEstructura.Size = New System.Drawing.Size(288, 20)
        Me.cmbEstructura.TabIndex = 205
        '
        'txtSegundos
        '
        '
        '
        '
        Me.txtSegundos.Border.Class = "TextBoxBorder"
        Me.txtSegundos.Enabled = False
        Me.txtSegundos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSegundos.ForeColor = System.Drawing.Color.Navy
        Me.txtSegundos.Location = New System.Drawing.Point(517, 214)
        Me.txtSegundos.Name = "txtSegundos"
        Me.txtSegundos.Size = New System.Drawing.Size(88, 20)
        Me.txtSegundos.TabIndex = 225
        '
        'txtHoras
        '
        '
        '
        '
        Me.txtHoras.Border.Class = "TextBoxBorder"
        Me.txtHoras.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHoras.ForeColor = System.Drawing.Color.Navy
        Me.txtHoras.Location = New System.Drawing.Point(556, 149)
        Me.txtHoras.Name = "txtHoras"
        Me.txtHoras.Size = New System.Drawing.Size(49, 20)
        Me.txtHoras.TabIndex = 224
        '
        'txtFechaFinal
        '
        '
        '
        '
        Me.txtFechaFinal.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtFechaFinal.ButtonDropDown.Visible = True
        Me.txtFechaFinal.CustomFormat = "dd/MM/yyyy HH:mm"
        Me.txtFechaFinal.Format = DevComponents.Editors.eDateTimePickerFormat.Custom
        Me.txtFechaFinal.Location = New System.Drawing.Point(340, 149)
        '
        '
        '
        Me.txtFechaFinal.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        Me.txtFechaFinal.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.txtFechaFinal.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.txtFechaFinal.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.txtFechaFinal.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.txtFechaFinal.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.txtFechaFinal.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.txtFechaFinal.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.txtFechaFinal.MonthCalendar.DisplayMonth = New Date(2009, 6, 1, 0, 0, 0, 0)
        Me.txtFechaFinal.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.txtFechaFinal.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.txtFechaFinal.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.txtFechaFinal.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.txtFechaFinal.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.txtFechaFinal.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.txtFechaFinal.MonthCalendar.TodayButtonVisible = True
        Me.txtFechaFinal.Name = "txtFechaFinal"
        Me.txtFechaFinal.Size = New System.Drawing.Size(113, 20)
        Me.txtFechaFinal.TabIndex = 223
        Me.txtFechaFinal.Value = New Date(2009, 6, 18, 0, 0, 0, 0)
        '
        'txtFechaInicio
        '
        '
        '
        '
        Me.txtFechaInicio.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtFechaInicio.ButtonDropDown.Visible = True
        Me.txtFechaInicio.CustomFormat = "dd/MM/yyyy HH:mm"
        Me.txtFechaInicio.Format = DevComponents.Editors.eDateTimePickerFormat.Custom
        Me.txtFechaInicio.Location = New System.Drawing.Point(119, 149)
        '
        '
        '
        Me.txtFechaInicio.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        Me.txtFechaInicio.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.txtFechaInicio.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.txtFechaInicio.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.txtFechaInicio.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.txtFechaInicio.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.txtFechaInicio.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.txtFechaInicio.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.txtFechaInicio.MonthCalendar.DisplayMonth = New Date(2009, 6, 1, 0, 0, 0, 0)
        Me.txtFechaInicio.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.txtFechaInicio.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.txtFechaInicio.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.txtFechaInicio.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.txtFechaInicio.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.txtFechaInicio.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.txtFechaInicio.MonthCalendar.TodayButtonVisible = True
        Me.txtFechaInicio.Name = "txtFechaInicio"
        Me.txtFechaInicio.Size = New System.Drawing.Size(116, 20)
        Me.txtFechaInicio.TabIndex = 222
        Me.txtFechaInicio.Value = New Date(2009, 6, 18, 0, 0, 0, 0)
        '
        'txtFinal
        '
        '
        '
        '
        Me.txtFinal.Border.Class = "TextBoxBorder"
        Me.txtFinal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFinal.ForeColor = System.Drawing.Color.Navy
        Me.txtFinal.Location = New System.Drawing.Point(340, 180)
        Me.txtFinal.Name = "txtFinal"
        Me.txtFinal.Size = New System.Drawing.Size(87, 20)
        Me.txtFinal.TabIndex = 221
        '
        'LabelX9
        '
        Me.LabelX9.AutoSize = True
        Me.LabelX9.BackColor = System.Drawing.Color.Transparent
        Me.LabelX9.Location = New System.Drawing.Point(15, 246)
        Me.LabelX9.Name = "LabelX9"
        Me.LabelX9.Size = New System.Drawing.Size(56, 15)
        Me.LabelX9.TabIndex = 219
        Me.LabelX9.Text = "Observac.:"
        '
        'txtObserv
        '
        '
        '
        '
        Me.txtObserv.Border.Class = "TextBoxBorder"
        Me.txtObserv.Location = New System.Drawing.Point(119, 241)
        Me.txtObserv.Name = "txtObserv"
        Me.txtObserv.Size = New System.Drawing.Size(486, 20)
        Me.txtObserv.TabIndex = 218
        '
        'LabelX10
        '
        Me.LabelX10.AutoSize = True
        Me.LabelX10.BackColor = System.Drawing.Color.Transparent
        Me.LabelX10.Location = New System.Drawing.Point(241, 180)
        Me.LabelX10.Name = "LabelX10"
        Me.LabelX10.Size = New System.Drawing.Size(69, 15)
        Me.LabelX10.TabIndex = 214
        Me.LabelX10.Text = "Lectura Final:"
        '
        'LabelX5
        '
        Me.LabelX5.AutoSize = True
        Me.LabelX5.BackColor = System.Drawing.Color.Transparent
        Me.LabelX5.Location = New System.Drawing.Point(456, 150)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(102, 15)
        Me.LabelX5.TabIndex = 213
        Me.LabelX5.Text = "H.Bombeo(HH:mm):"
        '
        'LabelX4
        '
        Me.LabelX4.AutoSize = True
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        Me.LabelX4.Location = New System.Drawing.Point(241, 150)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(95, 15)
        Me.LabelX4.TabIndex = 212
        Me.LabelX4.Text = "Hora Fin (HH:mm):"
        '
        'txtFechaRegistro
        '
        '
        '
        '
        Me.txtFechaRegistro.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtFechaRegistro.ButtonDropDown.Visible = True
        Me.txtFechaRegistro.Location = New System.Drawing.Point(476, 8)
        '
        '
        '
        Me.txtFechaRegistro.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        Me.txtFechaRegistro.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.txtFechaRegistro.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.txtFechaRegistro.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.txtFechaRegistro.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.txtFechaRegistro.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.txtFechaRegistro.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.txtFechaRegistro.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.txtFechaRegistro.MonthCalendar.DisplayMonth = New Date(2010, 5, 1, 0, 0, 0, 0)
        Me.txtFechaRegistro.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.txtFechaRegistro.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.txtFechaRegistro.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.txtFechaRegistro.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.txtFechaRegistro.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.txtFechaRegistro.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.txtFechaRegistro.MonthCalendar.TodayButtonVisible = True
        Me.txtFechaRegistro.Name = "txtFechaRegistro"
        Me.txtFechaRegistro.Size = New System.Drawing.Size(130, 20)
        Me.txtFechaRegistro.TabIndex = 211
        '
        'LabelX2
        '
        Me.LabelX2.AutoSize = True
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        Me.LabelX2.Location = New System.Drawing.Point(401, 8)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(59, 15)
        Me.LabelX2.TabIndex = 210
        Me.LabelX2.Text = "F. Registro:"
        '
        'txtModelo
        '
        '
        '
        '
        Me.txtModelo.Border.Class = "TextBoxBorder"
        Me.txtModelo.Enabled = False
        Me.txtModelo.Location = New System.Drawing.Point(504, 38)
        Me.txtModelo.Name = "txtModelo"
        Me.txtModelo.Size = New System.Drawing.Size(101, 20)
        Me.txtModelo.TabIndex = 205
        '
        'LabelX8
        '
        Me.LabelX8.AutoSize = True
        Me.LabelX8.BackColor = System.Drawing.Color.Transparent
        Me.LabelX8.Location = New System.Drawing.Point(401, 40)
        Me.LabelX8.Name = "LabelX8"
        Me.LabelX8.Size = New System.Drawing.Size(42, 15)
        Me.LabelX8.TabIndex = 204
        Me.LabelX8.Text = "Modelo:"
        '
        'LabelX12
        '
        Me.LabelX12.AutoSize = True
        Me.LabelX12.BackColor = System.Drawing.Color.Transparent
        Me.LabelX12.Location = New System.Drawing.Point(4, 89)
        Me.LabelX12.Name = "LabelX12"
        Me.LabelX12.Size = New System.Drawing.Size(616, 15)
        Me.LabelX12.TabIndex = 97
        Me.LabelX12.Text = "_________________________________________________________________________________" & _
            "____________________"
        '
        'txtVolumen
        '
        '
        '
        '
        Me.txtVolumen.Border.Class = "TextBoxBorder"
        Me.txtVolumen.Enabled = False
        Me.txtVolumen.Location = New System.Drawing.Point(518, 179)
        Me.txtVolumen.Name = "txtVolumen"
        Me.txtVolumen.Size = New System.Drawing.Size(88, 20)
        Me.txtVolumen.TabIndex = 94
        '
        'LabelX23
        '
        Me.LabelX23.AutoSize = True
        Me.LabelX23.BackColor = System.Drawing.Color.Transparent
        Me.LabelX23.Location = New System.Drawing.Point(440, 181)
        Me.LabelX23.Name = "LabelX23"
        Me.LabelX23.Size = New System.Drawing.Size(75, 15)
        Me.LabelX23.TabIndex = 93
        Me.LabelX23.Text = "Volumen (m3):"
        '
        'LabelX22
        '
        Me.LabelX22.AutoSize = True
        Me.LabelX22.BackColor = System.Drawing.Color.Transparent
        Me.LabelX22.Location = New System.Drawing.Point(251, 215)
        Me.LabelX22.Name = "LabelX22"
        Me.LabelX22.Size = New System.Drawing.Size(59, 15)
        Me.LabelX22.TabIndex = 87
        Me.LabelX22.Text = "Cloro Final:"
        '
        'txtCloroFin
        '
        '
        '
        '
        Me.txtCloroFin.Border.Class = "TextBoxBorder"
        Me.txtCloroFin.Location = New System.Drawing.Point(340, 213)
        Me.txtCloroFin.Name = "txtCloroFin"
        Me.txtCloroFin.Size = New System.Drawing.Size(87, 20)
        Me.txtCloroFin.TabIndex = 86
        '
        'txtCloroIni
        '
        '
        '
        '
        Me.txtCloroIni.Border.Class = "TextBoxBorder"
        Me.txtCloroIni.Location = New System.Drawing.Point(119, 211)
        Me.txtCloroIni.Name = "txtCloroIni"
        Me.txtCloroIni.Size = New System.Drawing.Size(91, 20)
        Me.txtCloroIni.TabIndex = 85
        '
        'LabelX21
        '
        Me.LabelX21.AutoSize = True
        Me.LabelX21.BackColor = System.Drawing.Color.Transparent
        Me.LabelX21.Location = New System.Drawing.Point(15, 216)
        Me.LabelX21.Name = "LabelX21"
        Me.LabelX21.Size = New System.Drawing.Size(63, 15)
        Me.LabelX21.TabIndex = 84
        Me.LabelX21.Text = "Cloro Inicial:"
        '
        'txtInicial
        '
        '
        '
        '
        Me.txtInicial.Border.Class = "TextBoxBorder"
        Me.txtInicial.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInicial.ForeColor = System.Drawing.Color.Navy
        Me.txtInicial.Location = New System.Drawing.Point(119, 180)
        Me.txtInicial.MaxLength = 12
        Me.txtInicial.Name = "txtInicial"
        Me.txtInicial.Size = New System.Drawing.Size(91, 20)
        Me.txtInicial.TabIndex = 77
        '
        'LabelX20
        '
        Me.LabelX20.AutoSize = True
        Me.LabelX20.BackColor = System.Drawing.Color.Transparent
        Me.LabelX20.Location = New System.Drawing.Point(13, 183)
        Me.LabelX20.Name = "LabelX20"
        Me.LabelX20.Size = New System.Drawing.Size(70, 15)
        Me.LabelX20.TabIndex = 78
        Me.LabelX20.Text = "Lectura Inicial"
        '
        'LabelX11
        '
        Me.LabelX11.AutoSize = True
        Me.LabelX11.BackColor = System.Drawing.Color.Transparent
        Me.LabelX11.Location = New System.Drawing.Point(433, 118)
        Me.LabelX11.Name = "LabelX11"
        Me.LabelX11.Size = New System.Drawing.Size(52, 15)
        Me.LabelX11.TabIndex = 67
        Me.LabelX11.Text = "F. Lectura"
        '
        'LabelX18
        '
        Me.LabelX18.AutoSize = True
        Me.LabelX18.BackColor = System.Drawing.Color.Transparent
        Me.LabelX18.Location = New System.Drawing.Point(241, 118)
        Me.LabelX18.Name = "LabelX18"
        Me.LabelX18.Size = New System.Drawing.Size(26, 15)
        Me.LabelX18.TabIndex = 65
        Me.LabelX18.Text = "Mes:"
        '
        'LabelX3
        '
        Me.LabelX3.AutoSize = True
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        Me.LabelX3.Location = New System.Drawing.Point(16, 118)
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
        Me.cmbAnio.Location = New System.Drawing.Point(119, 118)
        Me.cmbAnio.Name = "cmbAnio"
        Me.cmbAnio.Size = New System.Drawing.Size(105, 20)
        Me.cmbAnio.TabIndex = 62
        '
        'LabelX6
        '
        Me.LabelX6.AutoSize = True
        Me.LabelX6.BackColor = System.Drawing.Color.Transparent
        Me.LabelX6.Location = New System.Drawing.Point(13, 150)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(103, 15)
        Me.LabelX6.TabIndex = 13
        Me.LabelX6.Text = "Hora Inicio(HH:mm):"
        '
        'LabelX7
        '
        Me.LabelX7.AutoSize = True
        Me.LabelX7.BackColor = System.Drawing.Color.Transparent
        Me.LabelX7.Location = New System.Drawing.Point(12, 39)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(88, 15)
        Me.LabelX7.TabIndex = 6
        Me.LabelX7.Text = "Punto de Control:"
        '
        'cmbJunta
        '
        Me.cmbJunta.DisplayMember = "Text"
        Me.cmbJunta.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbJunta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbJunta.Enabled = False
        Me.cmbJunta.FormattingEnabled = True
        Me.cmbJunta.ItemHeight = 14
        Me.cmbJunta.Location = New System.Drawing.Point(101, 6)
        Me.cmbJunta.Name = "cmbJunta"
        Me.cmbJunta.Size = New System.Drawing.Size(288, 20)
        Me.cmbJunta.TabIndex = 0
        '
        'LabelX1
        '
        Me.LabelX1.AutoSize = True
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        Me.LabelX1.Location = New System.Drawing.Point(15, 6)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(33, 15)
        Me.LabelX1.TabIndex = 0
        Me.LabelX1.Text = "JASS:"
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
        Me.gridLecturas.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.gridLecturas.Location = New System.Drawing.Point(3, 309)
        Me.gridLecturas.MultiSelect = False
        Me.gridLecturas.Name = "gridLecturas"
        Me.gridLecturas.ReadOnly = True
        Me.gridLecturas.RowHeadersVisible = False
        Me.gridLecturas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridLecturas.Size = New System.Drawing.Size(657, 178)
        Me.gridLecturas.TabIndex = 201
        '
        'Bar6
        '
        Me.Bar6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar6.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem2, Me.ButtonItem3, Me.btnDelete, Me.btnSave, Me.btnNew})
        Me.Bar6.Location = New System.Drawing.Point(0, 496)
        Me.Bar6.Name = "Bar6"
        Me.Bar6.Size = New System.Drawing.Size(658, 25)
        Me.Bar6.Stretch = True
        Me.Bar6.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Bar6.TabIndex = 204
        Me.Bar6.TabStop = False
        Me.Bar6.Text = "Bar6"
        '
        'ButtonItem2
        '
        Me.ButtonItem2.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem2.Image = Global.COBSER.My.Resources.Resources.door
        Me.ButtonItem2.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.ButtonItem2.ImagePaddingHorizontal = 8
        Me.ButtonItem2.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.ButtonItem2.Name = "ButtonItem2"
        Me.ButtonItem2.Text = "Salir"
        '
        'ButtonItem3
        '
        Me.ButtonItem3.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem3.Image = Global.COBSER.My.Resources.Resources.printer
        Me.ButtonItem3.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.ButtonItem3.ImagePaddingHorizontal = 8
        Me.ButtonItem3.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.ButtonItem3.Name = "ButtonItem3"
        Me.ButtonItem3.Text = "Imprimir"
        '
        'btnDelete
        '
        Me.btnDelete.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnDelete.Image = Global.COBSER.My.Resources.Resources.delete
        Me.btnDelete.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.btnDelete.ImagePaddingHorizontal = 8
        Me.btnDelete.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Text = "Eliminar"
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
        'btnNew
        '
        Me.btnNew.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnNew.Image = Global.COBSER.My.Resources.Resources.add
        Me.btnNew.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.btnNew.ImagePaddingHorizontal = 8
        Me.btnNew.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Text = "Nueva"
        '
        'frmControlHidrometrico
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(658, 521)
        Me.Controls.Add(Me.Bar6)
        Me.Controls.Add(Me.ExpandablePanel2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmControlHidrometrico"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmControlHidrometrico"
        Me.ExpandablePanel2.ResumeLayout(False)
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupPanel1.PerformLayout()
        CType(Me.txtFechaL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaFinal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaInicio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaRegistro, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridLecturas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bar6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnSalir As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem1 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnEliminar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnGrabar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnNuevo As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ExpandablePanel2 As DevComponents.DotNetBar.ExpandablePanel
    Friend WithEvents Bar6 As DevComponents.DotNetBar.Bar
    Friend WithEvents ButtonItem2 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem3 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnDelete As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnSave As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnNew As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents gridLecturas As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents txtModelo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX8 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX12 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtVolumen As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX23 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX22 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtCloroFin As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtCloroIni As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX21 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtInicial As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX20 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX11 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX18 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cmbAnio As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cmbJunta As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtFechaRegistro As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX10 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX9 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtObserv As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtFinal As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtFechaFinal As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents txtFechaInicio As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents txtHoras As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtSegundos As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents cmbEstructura As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents txtFechaL As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents txtCaudal As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX13 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtTipo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtEstructuta As DevComponents.DotNetBar.LabelX
    Friend WithEvents cmbMes As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents ComboItem1 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem2 As DevComponents.Editors.ComboItem
End Class
