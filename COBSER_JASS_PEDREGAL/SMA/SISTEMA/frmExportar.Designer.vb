<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmExportar
    'Inherits System.Windows.Forms.Form
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
        Me.Bar1 = New DevComponents.DotNetBar.Bar
        Me.btnExportar = New DevComponents.DotNetBar.ButtonItem
        Me.btnCerrar = New DevComponents.DotNetBar.ButtonItem
        Me.chkApertura = New DevComponents.DotNetBar.Controls.CheckBoxX
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel
        Me.chkAddData = New DevComponents.DotNetBar.Controls.CheckBoxX
        Me.chkResponsable = New DevComponents.DotNetBar.Controls.CheckBoxX
        Me.chkActividadFinanciera = New DevComponents.DotNetBar.Controls.CheckBoxX
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX
        Me.chkProgEjec = New DevComponents.DotNetBar.Controls.CheckBoxX
        Me.chkComision = New DevComponents.DotNetBar.Controls.CheckBoxX
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX
        Me.cmbJunta = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.chkEstructura = New DevComponents.DotNetBar.Controls.CheckBoxX
        Me.cmbAnio = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.cmbComision = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.txtUbicacion = New DevComponents.DotNetBar.Controls.TextBoxX
        Me.sfd = New System.Windows.Forms.SaveFileDialog
        Me.bgw = New System.ComponentModel.BackgroundWorker
        Me.pgb = New DevComponents.DotNetBar.Controls.ProgressBarX
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Bar1
        '
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnExportar, Me.btnCerrar})
        Me.Bar1.Location = New System.Drawing.Point(0, 405)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(453, 25)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Bar1.TabIndex = 3
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'btnExportar
        '
        Me.btnExportar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnExportar.Image = Global.COBSER.My.Resources.Resources.database_go
        Me.btnExportar.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.btnExportar.ImagePaddingHorizontal = 8
        Me.btnExportar.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Text = "Exportar"
        '
        'btnCerrar
        '
        Me.btnCerrar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.btnCerrar.Image = Global.COBSER.My.Resources.Resources.cross
        Me.btnCerrar.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.btnCerrar.ImagePaddingHorizontal = 8
        Me.btnCerrar.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Text = "Cerrar"
        '
        'chkApertura
        '
        Me.chkApertura.AutoSize = True
        Me.chkApertura.BackColor = System.Drawing.Color.Transparent
        Me.chkApertura.Checked = True
        Me.chkApertura.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkApertura.CheckValue = "Y"
        Me.chkApertura.Location = New System.Drawing.Point(38, 203)
        Me.chkApertura.Name = "chkApertura"
        Me.chkApertura.Size = New System.Drawing.Size(101, 15)
        Me.chkApertura.TabIndex = 4
        Me.chkApertura.Text = "Año de Apertura"
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.chkAddData)
        Me.GroupPanel1.Controls.Add(Me.chkResponsable)
        Me.GroupPanel1.Controls.Add(Me.chkActividadFinanciera)
        Me.GroupPanel1.Controls.Add(Me.LabelX3)
        Me.GroupPanel1.Controls.Add(Me.chkProgEjec)
        Me.GroupPanel1.Controls.Add(Me.chkComision)
        Me.GroupPanel1.Controls.Add(Me.LabelX4)
        Me.GroupPanel1.Controls.Add(Me.LabelX2)
        Me.GroupPanel1.Controls.Add(Me.LabelX1)
        Me.GroupPanel1.Controls.Add(Me.cmbJunta)
        Me.GroupPanel1.Controls.Add(Me.chkEstructura)
        Me.GroupPanel1.Controls.Add(Me.cmbAnio)
        Me.GroupPanel1.Controls.Add(Me.cmbComision)
        Me.GroupPanel1.Controls.Add(Me.txtUbicacion)
        Me.GroupPanel1.Controls.Add(Me.chkApertura)
        Me.GroupPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(453, 405)
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
        Me.GroupPanel1.TabIndex = 5
        Me.GroupPanel1.Text = "Formulario de Exportación"
        '
        'chkAddData
        '
        Me.chkAddData.AutoSize = True
        Me.chkAddData.BackColor = System.Drawing.Color.Transparent
        Me.chkAddData.Checked = True
        Me.chkAddData.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkAddData.CheckValue = "Y"
        Me.chkAddData.Location = New System.Drawing.Point(170, 119)
        Me.chkAddData.Name = "chkAddData"
        Me.chkAddData.Size = New System.Drawing.Size(236, 15)
        Me.chkAddData.TabIndex = 178
        Me.chkAddData.Text = "Anexar a archivo de Transferencia existente"
        Me.chkAddData.Visible = False
        '
        'chkResponsable
        '
        Me.chkResponsable.AutoSize = True
        Me.chkResponsable.BackColor = System.Drawing.Color.Transparent
        Me.chkResponsable.Checked = True
        Me.chkResponsable.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkResponsable.CheckValue = "Y"
        Me.chkResponsable.Location = New System.Drawing.Point(38, 287)
        Me.chkResponsable.Name = "chkResponsable"
        Me.chkResponsable.Size = New System.Drawing.Size(155, 15)
        Me.chkResponsable.TabIndex = 20
        Me.chkResponsable.Text = "Responsables de Indicador"
        '
        'chkActividadFinanciera
        '
        Me.chkActividadFinanciera.AutoSize = True
        Me.chkActividadFinanciera.BackColor = System.Drawing.Color.Transparent
        Me.chkActividadFinanciera.Checked = True
        Me.chkActividadFinanciera.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkActividadFinanciera.CheckValue = "Y"
        Me.chkActividadFinanciera.Location = New System.Drawing.Point(38, 266)
        Me.chkActividadFinanciera.Name = "chkActividadFinanciera"
        Me.chkActividadFinanciera.Size = New System.Drawing.Size(118, 15)
        Me.chkActividadFinanciera.TabIndex = 19
        Me.chkActividadFinanciera.Text = "Calculo Actividades"
        '
        'LabelX3
        '
        Me.LabelX3.AutoSize = True
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        Me.LabelX3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX3.Location = New System.Drawing.Point(9, 166)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(223, 19)
        Me.LabelX3.TabIndex = 17
        Me.LabelX3.Text = "Selecciones los datos a exportar:"
        '
        'chkProgEjec
        '
        Me.chkProgEjec.AutoSize = True
        Me.chkProgEjec.BackColor = System.Drawing.Color.Transparent
        Me.chkProgEjec.Checked = True
        Me.chkProgEjec.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkProgEjec.CheckValue = "Y"
        Me.chkProgEjec.Location = New System.Drawing.Point(38, 245)
        Me.chkProgEjec.Name = "chkProgEjec"
        Me.chkProgEjec.Size = New System.Drawing.Size(149, 15)
        Me.chkProgEjec.TabIndex = 16
        Me.chkProgEjec.Text = "Programación y Ejecución"
        '
        'chkComision
        '
        Me.chkComision.AutoSize = True
        Me.chkComision.BackColor = System.Drawing.Color.Transparent
        Me.chkComision.Location = New System.Drawing.Point(17, 46)
        Me.chkComision.Name = "chkComision"
        Me.chkComision.Size = New System.Drawing.Size(132, 15)
        Me.chkComision.TabIndex = 15
        Me.chkComision.Text = "Comision de Usuarios:"
        '
        'LabelX4
        '
        Me.LabelX4.AutoSize = True
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        Me.LabelX4.Location = New System.Drawing.Point(23, 72)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(76, 15)
        Me.LabelX4.TabIndex = 14
        Me.LabelX4.Text = "Año a Exportar"
        '
        'LabelX2
        '
        Me.LabelX2.AutoSize = True
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        Me.LabelX2.Location = New System.Drawing.Point(23, 94)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(89, 15)
        Me.LabelX2.TabIndex = 12
        Me.LabelX2.Text = "Ruta exportación:"
        '
        'LabelX1
        '
        Me.LabelX1.AutoSize = True
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        Me.LabelX1.Location = New System.Drawing.Point(23, 20)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(94, 15)
        Me.LabelX1.TabIndex = 11
        Me.LabelX1.Text = "Junta de Usuarios:"
        '
        'cmbJunta
        '
        Me.cmbJunta.DisplayMember = "Text"
        Me.cmbJunta.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbJunta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbJunta.FormattingEnabled = True
        Me.cmbJunta.ItemHeight = 14
        Me.cmbJunta.Location = New System.Drawing.Point(170, 15)
        Me.cmbJunta.Name = "cmbJunta"
        Me.cmbJunta.Size = New System.Drawing.Size(268, 20)
        Me.cmbJunta.TabIndex = 10
        '
        'chkEstructura
        '
        Me.chkEstructura.AutoSize = True
        Me.chkEstructura.BackColor = System.Drawing.Color.Transparent
        Me.chkEstructura.Checked = True
        Me.chkEstructura.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkEstructura.CheckValue = "Y"
        Me.chkEstructura.Location = New System.Drawing.Point(38, 224)
        Me.chkEstructura.Name = "chkEstructura"
        Me.chkEstructura.Size = New System.Drawing.Size(98, 15)
        Me.chkEstructura.TabIndex = 9
        Me.chkEstructura.Text = "Estructura SMA"
        '
        'cmbAnio
        '
        Me.cmbAnio.DisplayMember = "Text"
        Me.cmbAnio.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbAnio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAnio.FormattingEnabled = True
        Me.cmbAnio.ItemHeight = 14
        Me.cmbAnio.Location = New System.Drawing.Point(170, 67)
        Me.cmbAnio.Name = "cmbAnio"
        Me.cmbAnio.Size = New System.Drawing.Size(268, 20)
        Me.cmbAnio.TabIndex = 7
        '
        'cmbComision
        '
        Me.cmbComision.DisplayMember = "Text"
        Me.cmbComision.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbComision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbComision.FormattingEnabled = True
        Me.cmbComision.ItemHeight = 14
        Me.cmbComision.Location = New System.Drawing.Point(170, 41)
        Me.cmbComision.Name = "cmbComision"
        Me.cmbComision.Size = New System.Drawing.Size(268, 20)
        Me.cmbComision.TabIndex = 6
        '
        'txtUbicacion
        '
        '
        '
        '
        Me.txtUbicacion.Border.Class = "TextBoxBorder"
        Me.txtUbicacion.ButtonCustom.Visible = True
        Me.txtUbicacion.Location = New System.Drawing.Point(170, 93)
        Me.txtUbicacion.Name = "txtUbicacion"
        Me.txtUbicacion.ReadOnly = True
        Me.txtUbicacion.Size = New System.Drawing.Size(268, 20)
        Me.txtUbicacion.TabIndex = 5
        '
        'sfd
        '
        '
        'bgw
        '
        Me.bgw.WorkerReportsProgress = True
        '
        'pgb
        '
        Me.pgb.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pgb.Location = New System.Drawing.Point(0, 382)
        Me.pgb.Name = "pgb"
        Me.pgb.ProgressType = DevComponents.DotNetBar.eProgressItemType.Marquee
        Me.pgb.Size = New System.Drawing.Size(453, 23)
        Me.pgb.TabIndex = 22
        Me.pgb.Text = "ProgressBarX1"
        '
        'frmExportar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(453, 430)
        Me.Controls.Add(Me.pgb)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.Bar1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmExportar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Exportar Información"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents btnExportar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnCerrar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents chkApertura As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents txtUbicacion As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents sfd As System.Windows.Forms.SaveFileDialog
    Friend WithEvents cmbAnio As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents cmbComision As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents chkEstructura As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cmbJunta As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents chkComision As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents chkProgEjec As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents chkActividadFinanciera As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents chkResponsable As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents bgw As System.ComponentModel.BackgroundWorker
    Friend WithEvents pgb As DevComponents.DotNetBar.Controls.ProgressBarX
    Friend WithEvents chkAddData As DevComponents.DotNetBar.Controls.CheckBoxX
End Class
