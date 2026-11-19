<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGraficoTablero
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGraficoTablero))
        Me.chkComision = New DevComponents.DotNetBar.Controls.CheckBoxX
        Me.cmbComision = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.cmbJunta = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX
        Me.btnPrint = New DevComponents.DotNetBar.ButtonX
        Me.btnViewTablero = New DevComponents.DotNetBar.ButtonX
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX
        Me.cmbMes = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.ComboItem1 = New DevComponents.Editors.ComboItem
        Me.ComboItem2 = New DevComponents.Editors.ComboItem
        Me.ComboItem3 = New DevComponents.Editors.ComboItem
        Me.ComboItem4 = New DevComponents.Editors.ComboItem
        Me.ComboItem5 = New DevComponents.Editors.ComboItem
        Me.ComboItem6 = New DevComponents.Editors.ComboItem
        Me.ComboItem7 = New DevComponents.Editors.ComboItem
        Me.ComboItem8 = New DevComponents.Editors.ComboItem
        Me.ComboItem9 = New DevComponents.Editors.ComboItem
        Me.ComboItem10 = New DevComponents.Editors.ComboItem
        Me.ComboItem11 = New DevComponents.Editors.ComboItem
        Me.ComboItem12 = New DevComponents.Editors.ComboItem
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX
        Me.cmbAnio = New DevComponents.DotNetBar.Controls.ComboBoxEx
        Me.swfTablero = New AxShockwaveFlashObjects.AxShockwaveFlash
        Me.PrintForm1 = New Microsoft.VisualBasic.PowerPacks.Printing.PrintForm(Me.components)
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel
        CType(Me.swfTablero, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'chkComision
        '
        Me.chkComision.BackColor = System.Drawing.Color.Transparent
        Me.chkComision.Location = New System.Drawing.Point(422, 46)
        Me.chkComision.Name = "chkComision"
        Me.chkComision.Size = New System.Drawing.Size(154, 23)
        Me.chkComision.TabIndex = 10
        Me.chkComision.Text = "Comision de Regantes:"
        '
        'cmbComision
        '
        Me.cmbComision.DisplayMember = "Text"
        Me.cmbComision.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbComision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbComision.FormattingEnabled = True
        Me.cmbComision.ItemHeight = 17
        Me.cmbComision.Location = New System.Drawing.Point(582, 48)
        Me.cmbComision.Name = "cmbComision"
        Me.cmbComision.Size = New System.Drawing.Size(236, 23)
        Me.cmbComision.TabIndex = 8
        '
        'cmbJunta
        '
        Me.cmbJunta.DisplayMember = "Text"
        Me.cmbJunta.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbJunta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbJunta.FormattingEnabled = True
        Me.cmbJunta.ItemHeight = 17
        Me.cmbJunta.Location = New System.Drawing.Point(127, 46)
        Me.cmbJunta.Name = "cmbJunta"
        Me.cmbJunta.Size = New System.Drawing.Size(289, 23)
        Me.cmbJunta.TabIndex = 7
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        Me.LabelX4.Location = New System.Drawing.Point(18, 50)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(103, 19)
        Me.LabelX4.TabIndex = 5
        Me.LabelX4.Text = "Junta de Usuarios:"
        '
        'btnPrint
        '
        Me.btnPrint.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnPrint.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnPrint.Location = New System.Drawing.Point(742, 76)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(75, 23)
        Me.btnPrint.TabIndex = 5
        Me.btnPrint.Text = "Imprimir"
        '
        'btnViewTablero
        '
        Me.btnViewTablero.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnViewTablero.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnViewTablero.Location = New System.Drawing.Point(582, 75)
        Me.btnViewTablero.Name = "btnViewTablero"
        Me.btnViewTablero.Size = New System.Drawing.Size(154, 23)
        Me.btnViewTablero.TabIndex = 4
        Me.btnViewTablero.Text = "Mostrar Grafico Tablero"
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        Me.LabelX2.Location = New System.Drawing.Point(264, 83)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(25, 15)
        Me.LabelX2.TabIndex = 3
        Me.LabelX2.Text = "Mes:"
        '
        'cmbMes
        '
        Me.cmbMes.DisplayMember = "Text"
        Me.cmbMes.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMes.FormattingEnabled = True
        Me.cmbMes.ItemHeight = 14
        Me.cmbMes.Items.AddRange(New Object() {Me.ComboItem1, Me.ComboItem2, Me.ComboItem3, Me.ComboItem4, Me.ComboItem5, Me.ComboItem6, Me.ComboItem7, Me.ComboItem8, Me.ComboItem9, Me.ComboItem10, Me.ComboItem11, Me.ComboItem12})
        Me.cmbMes.Location = New System.Drawing.Point(295, 78)
        Me.cmbMes.Name = "cmbMes"
        Me.cmbMes.Size = New System.Drawing.Size(121, 20)
        Me.cmbMes.TabIndex = 2
        '
        'ComboItem1
        '
        Me.ComboItem1.Text = "ENERO"
        '
        'ComboItem2
        '
        Me.ComboItem2.Text = "FEBRERO"
        '
        'ComboItem3
        '
        Me.ComboItem3.Text = "MARZO"
        '
        'ComboItem4
        '
        Me.ComboItem4.Text = "ABRIL"
        '
        'ComboItem5
        '
        Me.ComboItem5.Text = "MAYO"
        '
        'ComboItem6
        '
        Me.ComboItem6.Text = "JUNIO"
        '
        'ComboItem7
        '
        Me.ComboItem7.Text = "JULIO"
        '
        'ComboItem8
        '
        Me.ComboItem8.Text = "AGOSTO"
        '
        'ComboItem9
        '
        Me.ComboItem9.Text = "SETIEMBRE"
        '
        'ComboItem10
        '
        Me.ComboItem10.Text = "OCTUBRE"
        '
        'ComboItem11
        '
        Me.ComboItem11.Text = "NOVIEMBRE"
        '
        'ComboItem12
        '
        Me.ComboItem12.Text = "DICIEMBRE"
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        Me.LabelX1.Location = New System.Drawing.Point(23, 84)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(25, 15)
        Me.LabelX1.TabIndex = 1
        Me.LabelX1.Text = "Año:"
        '
        'cmbAnio
        '
        Me.cmbAnio.DisplayMember = "Text"
        Me.cmbAnio.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbAnio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAnio.FormattingEnabled = True
        Me.cmbAnio.ItemHeight = 14
        Me.cmbAnio.Location = New System.Drawing.Point(127, 79)
        Me.cmbAnio.Name = "cmbAnio"
        Me.cmbAnio.Size = New System.Drawing.Size(121, 20)
        Me.cmbAnio.TabIndex = 0
        '
        'swfTablero
        '
        Me.swfTablero.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.swfTablero.Enabled = True
        Me.swfTablero.Location = New System.Drawing.Point(18, 104)
        Me.swfTablero.Name = "swfTablero"
        Me.swfTablero.OcxState = CType(resources.GetObject("swfTablero.OcxState"), System.Windows.Forms.AxHost.State)
        Me.swfTablero.Size = New System.Drawing.Size(922, 402)
        Me.swfTablero.TabIndex = 4
        '
        'PrintForm1
        '
        Me.PrintForm1.DocumentName = "document"
        Me.PrintForm1.Form = Me
        Me.PrintForm1.PrintAction = System.Drawing.Printing.PrintAction.PrintToPrinter
        Me.PrintForm1.PrinterSettings = CType(resources.GetObject("PrintForm1.PrinterSettings"), System.Drawing.Printing.PrinterSettings)
        Me.PrintForm1.PrintFileName = Nothing
        '
        'ReflectionLabel1
        '
        Me.ReflectionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel1.Location = New System.Drawing.Point(365, 2)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(225, 38)
        Me.ReflectionLabel1.TabIndex = 11
        Me.ReflectionLabel1.Text = "Grafico Tablero Comando"
        '
        'frmGraficoTablero
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(952, 507)
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.Controls.Add(Me.chkComision)
        Me.Controls.Add(Me.cmbComision)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.cmbJunta)
        Me.Controls.Add(Me.swfTablero)
        Me.Controls.Add(Me.LabelX4)
        Me.Controls.Add(Me.btnViewTablero)
        Me.Controls.Add(Me.LabelX2)
        Me.Controls.Add(Me.cmbMes)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.cmbAnio)
        Me.DoubleBuffered = True
        Me.Name = "frmGraficoTablero"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Grafico del Tablero"
        CType(Me.swfTablero, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmbComision As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents cmbJunta As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents swfTablero As AxShockwaveFlashObjects.AxShockwaveFlash
    Friend WithEvents chkComision As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cmbMes As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cmbAnio As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents btnViewTablero As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ComboItem1 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem2 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem3 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem4 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem5 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem6 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem7 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem8 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem9 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem10 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem11 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem12 As DevComponents.Editors.ComboItem
    Friend WithEvents btnPrint As DevComponents.DotNetBar.ButtonX
    Friend WithEvents PrintForm1 As Microsoft.VisualBasic.PowerPacks.Printing.PrintForm
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
End Class
