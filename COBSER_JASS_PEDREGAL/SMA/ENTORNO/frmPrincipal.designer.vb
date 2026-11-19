<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrincipal
    'Inherits System.Windows.Forms.Form
    Inherits DevComponents.DotNetBar.Office2007RibbonForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPrincipal))
        Me.QatCustomizeItem1 = New DevComponents.DotNetBar.QatCustomizeItem
        Me.rbPrincipal = New DevComponents.DotNetBar.RibbonControl
        Me.Office2007StartButton3 = New DevComponents.DotNetBar.Office2007StartButton
        Me.ItemContainer5 = New DevComponents.DotNetBar.ItemContainer
        Me.ItemContainer7 = New DevComponents.DotNetBar.ItemContainer
        Me.itmContStart2 = New DevComponents.DotNetBar.ItemContainer
        Me.GalleryContainer3 = New DevComponents.DotNetBar.GalleryContainer
        Me.LabelItem2 = New DevComponents.DotNetBar.LabelItem
        Me.ButtonItem1 = New DevComponents.DotNetBar.ButtonItem
        Me.MdiWindowListItem1 = New DevComponents.DotNetBar.MdiWindowListItem
        Me.ItemContainer3 = New DevComponents.DotNetBar.ItemContainer
        Me.ButtonItem5 = New DevComponents.DotNetBar.ButtonItem
        Me.ButtonItem6 = New DevComponents.DotNetBar.ButtonItem
        Me.Bar1 = New DevComponents.DotNetBar.Bar
        Me.lblUsuario = New DevComponents.DotNetBar.LabelItem
        Me.lblGrupo = New DevComponents.DotNetBar.LabelItem
        Me.lblFecha = New DevComponents.DotNetBar.LabelItem
        Me.btnBlack = New DevComponents.DotNetBar.ButtonItem
        Me.ButtonItem3 = New DevComponents.DotNetBar.ButtonItem
        Me.btnGray = New DevComponents.DotNetBar.ButtonItem
        Me.lblCaja = New DevComponents.DotNetBar.LabelItem
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'QatCustomizeItem1
        '
        Me.QatCustomizeItem1.Name = "QatCustomizeItem1"
        '
        'rbPrincipal
        '
        Me.rbPrincipal.CaptionVisible = True
        Me.rbPrincipal.Dock = System.Windows.Forms.DockStyle.Top
        Me.rbPrincipal.KeyTipsFont = New System.Drawing.Font("Tahoma", 7.0!)
        Me.rbPrincipal.Location = New System.Drawing.Point(4, 1)
        Me.rbPrincipal.Name = "rbPrincipal"
        Me.rbPrincipal.Padding = New System.Windows.Forms.Padding(0, 0, 0, 2)
        Me.rbPrincipal.QuickToolbarItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Office2007StartButton3, Me.QatCustomizeItem1})
        Me.rbPrincipal.Size = New System.Drawing.Size(775, 159)
        Me.rbPrincipal.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.rbPrincipal.TabGroupHeight = 14
        Me.rbPrincipal.TabIndex = 8
        '
        'Office2007StartButton3
        '
        Me.Office2007StartButton3.AutoExpandOnClick = True
        Me.Office2007StartButton3.CanCustomize = False
        Me.Office2007StartButton3.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.Image
        Me.Office2007StartButton3.Image = Global.COBSER.My.Resources.Resources.logo
        Me.Office2007StartButton3.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.Office2007StartButton3.ImagePaddingHorizontal = 2
        Me.Office2007StartButton3.ImagePaddingVertical = 2
        Me.Office2007StartButton3.Name = "Office2007StartButton3"
        Me.Office2007StartButton3.ShowSubItems = False
        Me.Office2007StartButton3.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainer5})
        Me.Office2007StartButton3.Text = "&File"
        '
        'ItemContainer5
        '
        '
        '
        '
        Me.ItemContainer5.BackgroundStyle.Class = "RibbonFileMenuContainer"
        Me.ItemContainer5.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.ItemContainer5.Name = "ItemContainer5"
        Me.ItemContainer5.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainer7})
        '
        'ItemContainer7
        '
        '
        '
        '
        Me.ItemContainer7.BackgroundStyle.Class = "RibbonFileMenuTwoColumnContainer"
        Me.ItemContainer7.ItemSpacing = 0
        Me.ItemContainer7.Name = "ItemContainer7"
        Me.ItemContainer7.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.itmContStart2})
        '
        'itmContStart2
        '
        '
        '
        '
        Me.itmContStart2.BackgroundStyle.Class = "RibbonFileMenuColumnOneContainer"
        Me.itmContStart2.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.itmContStart2.MinimumSize = New System.Drawing.Size(120, 0)
        Me.itmContStart2.Name = "itmContStart2"
        '
        'GalleryContainer3
        '
        '
        '
        '
        Me.GalleryContainer3.BackgroundStyle.Class = "RibbonFileMenuColumnTwoContainer"
        Me.GalleryContainer3.EnableGalleryPopup = False
        Me.GalleryContainer3.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.GalleryContainer3.MinimumSize = New System.Drawing.Size(180, 240)
        Me.GalleryContainer3.MultiLine = False
        Me.GalleryContainer3.Name = "GalleryContainer3"
        Me.GalleryContainer3.PopupUsesStandardScrollbars = False
        '
        'LabelItem2
        '
        Me.LabelItem2.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom
        Me.LabelItem2.BorderType = DevComponents.DotNetBar.eBorderType.Etched
        Me.LabelItem2.CanCustomize = False
        Me.LabelItem2.Name = "LabelItem2"
        '
        'ButtonItem1
        '
        Me.ButtonItem1.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.ButtonItem1.ImagePaddingHorizontal = 8
        Me.ButtonItem1.Name = "ButtonItem1"
        Me.ButtonItem1.Text = "ButtonItem1"
        '
        'MdiWindowListItem1
        '
        Me.MdiWindowListItem1.Name = "MdiWindowListItem1"
        Me.MdiWindowListItem1.ShowWindowIcons = True
        Me.MdiWindowListItem1.Visible = False
        '
        'ItemContainer3
        '
        Me.ItemContainer3.Name = "ItemContainer3"
        Me.ItemContainer3.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem5, Me.ButtonItem6})
        '
        'ButtonItem5
        '
        Me.ButtonItem5.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.ButtonItem5.ImagePaddingHorizontal = 8
        Me.ButtonItem5.Name = "ButtonItem5"
        Me.ButtonItem5.Text = "ButtonItem5"
        '
        'ButtonItem6
        '
        Me.ButtonItem6.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.ButtonItem6.ImagePaddingHorizontal = 8
        Me.ButtonItem6.Name = "ButtonItem6"
        Me.ButtonItem6.Text = "ButtonItem6"
        '
        'Bar1
        '
        Me.Bar1.AccessibleDescription = "Bar1 (Bar1)"
        Me.Bar1.AccessibleName = "Bar1"
        Me.Bar1.AccessibleRole = System.Windows.Forms.AccessibleRole.ToolBar
        Me.Bar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.lblUsuario, Me.lblGrupo, Me.lblFecha, Me.lblCaja, Me.btnBlack, Me.ButtonItem3, Me.btnGray})
        Me.Bar1.ItemSpacing = 2
        Me.Bar1.Location = New System.Drawing.Point(4, 393)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(775, 25)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.Bar1.TabIndex = 15
        Me.Bar1.TabNavigation = True
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'lblUsuario
        '
        Me.lblUsuario.BorderSide = DevComponents.DotNetBar.eBorderSide.Right
        Me.lblUsuario.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.lblUsuario.Name = "lblUsuario"
        Me.lblUsuario.Text = "Usuario"
        '
        'lblGrupo
        '
        Me.lblGrupo.BorderSide = DevComponents.DotNetBar.eBorderSide.Right
        Me.lblGrupo.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.lblGrupo.Name = "lblGrupo"
        Me.lblGrupo.Text = "Grupo"
        '
        'lblFecha
        '
        Me.lblFecha.BorderSide = DevComponents.DotNetBar.eBorderSide.Right
        Me.lblFecha.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Text = "Fecha"
        '
        'btnBlack
        '
        Me.btnBlack.Image = CType(resources.GetObject("btnBlack.Image"), System.Drawing.Image)
        Me.btnBlack.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnBlack.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.btnBlack.ImagePaddingHorizontal = 8
        Me.btnBlack.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.btnBlack.Name = "btnBlack"
        Me.btnBlack.OptionGroup = "navBar"
        Me.btnBlack.Text = "ButtonItem2"
        '
        'ButtonItem3
        '
        Me.ButtonItem3.Checked = True
        Me.ButtonItem3.Image = Global.COBSER.My.Resources.Resources.application
        Me.ButtonItem3.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.ButtonItem3.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.ButtonItem3.ImagePaddingHorizontal = 8
        Me.ButtonItem3.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.ButtonItem3.Name = "ButtonItem3"
        Me.ButtonItem3.OptionGroup = "navBar"
        Me.ButtonItem3.Text = "btnBlue"
        '
        'btnGray
        '
        Me.btnGray.Image = Global.COBSER.My.Resources.Resources.application_osx
        Me.btnGray.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnGray.ImageListSizeSelection = DevComponents.DotNetBar.eButtonImageListSelection.NotSet
        Me.btnGray.ImagePaddingHorizontal = 8
        Me.btnGray.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.btnGray.Name = "btnGray"
        Me.btnGray.OptionGroup = "navBar"
        Me.btnGray.Text = "ButtonItem2"
        '
        'lblCaja
        '
        Me.lblCaja.BorderSide = DevComponents.DotNetBar.eBorderSide.Right
        Me.lblCaja.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.lblCaja.Name = "lblCaja"
        Me.lblCaja.Text = "Caja"
        '
        'frmPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.COBSER.My.Resources.Resources.fondo_principal_01
        Me.ClientSize = New System.Drawing.Size(783, 420)
        Me.Controls.Add(Me.Bar1)
        Me.Controls.Add(Me.rbPrincipal)
        Me.IsMdiContainer = True
        Me.Name = "frmPrincipal"
        Me.Text = "JASS"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Office2007StartButton1 As DevComponents.DotNetBar.Office2007StartButton
    Friend WithEvents ItemContainer1 As DevComponents.DotNetBar.ItemContainer
    Friend WithEvents ItemContainer2 As DevComponents.DotNetBar.ItemContainer
    Friend WithEvents itmContStart As DevComponents.DotNetBar.ItemContainer
    Friend WithEvents GalleryContainer2 As DevComponents.DotNetBar.GalleryContainer
    Friend WithEvents LabelItem1 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents QatCustomizeItem1 As DevComponents.DotNetBar.QatCustomizeItem
    Friend WithEvents rbPrincipal As DevComponents.DotNetBar.RibbonControl
    Friend WithEvents Office2007StartButton3 As DevComponents.DotNetBar.Office2007StartButton
    Friend WithEvents ItemContainer5 As DevComponents.DotNetBar.ItemContainer
    Friend WithEvents ItemContainer7 As DevComponents.DotNetBar.ItemContainer
    Friend WithEvents itmContStart2 As DevComponents.DotNetBar.ItemContainer
    Friend WithEvents GalleryContainer3 As DevComponents.DotNetBar.GalleryContainer
    Friend WithEvents LabelItem2 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents ButtonItem1 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents MdiWindowListItem1 As DevComponents.DotNetBar.MdiWindowListItem
    Friend WithEvents ItemContainer3 As DevComponents.DotNetBar.ItemContainer
    Friend WithEvents ButtonItem5 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem6 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents lblUsuario As DevComponents.DotNetBar.LabelItem
    Private WithEvents lblGrupo As DevComponents.DotNetBar.LabelItem
    Friend WithEvents btnBlack As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem3 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnGray As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents lblFecha As DevComponents.DotNetBar.LabelItem
    Friend WithEvents lblCaja As DevComponents.DotNetBar.LabelItem
End Class
