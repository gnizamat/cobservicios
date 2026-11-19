Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports ACCESO
Public Class clsEstructuraSMA

    Private _vIdJuntaUsuarios As String
    Private _iIdComisionRegante As Integer
    Private _iAnio As Integer
    Private _idEstructura As Integer
    Private _fLineaBase As Double
    Private _fMeta As Double
    Private _fPeso As Double
    Private _cMedida As String
    Private _cCalculo As String
    Private _cCondicion As String
    Private _cDatoGeneral As String
    Private _cCondicionN As String
    Public tempIDP As Integer

    Public Property CondicionN()
        Get
            Return Me._cCondicionN
        End Get
        Set(ByVal value)
            Me._cCondicionN = value
        End Set
    End Property

    Public Property DatoGeneral()
        Get
            Return Me._cDatoGeneral
        End Get
        Set(ByVal value)
            Me._cDatoGeneral = value
        End Set
    End Property

    Public Property Condicion()
        Get
            Return Me._cCondicion
        End Get
        Set(ByVal value)
            Me._cCondicion = value
        End Set
    End Property

    Public Property EstadoCalculado()
        Get
            Return Me._cCalculo
        End Get
        Set(ByVal value)
            Me._cCalculo = value
        End Set
    End Property
    Public Property MedidaAnual()
        Get
            Return Me._cMedida
        End Get
        Set(ByVal value)
            Me._cMedida = value
        End Set
    End Property
    Public Property LineaBase()
        Get
            Return Me._fLineaBase
        End Get
        Set(ByVal value)
            Me._fLineaBase = value
        End Set
    End Property
    Public Property Meta()
        Get
            Return Me._fMeta
        End Get
        Set(ByVal value)
            Me._fMeta = value
        End Set
    End Property
    Public Property Peso()
        Get
            Return Me._fPeso
        End Get
        Set(ByVal value)
            Me._fPeso = value
        End Set
    End Property
    Public Property IdJU()
        Get
            Return Me._vIdJuntaUsuarios
        End Get
        Set(ByVal value)
            Me._vIdJuntaUsuarios = value
        End Set
    End Property
    Public Property IdCR()
        Get
            Return Me._iIdComisionRegante
        End Get
        Set(ByVal value)
            Me._iIdComisionRegante = value
        End Set
    End Property
    Public Property Anio()
        Get
            Return Me._iAnio
        End Get
        Set(ByVal value)
            Me._iAnio = value
        End Set
    End Property
    Sub New(ByVal idj As String, ByVal idc As Integer, ByVal anio As Integer, ByVal idestructura As Integer)
        Me._vIdJuntaUsuarios = idj
        Me._iIdComisionRegante = idc
        Me._iAnio = anio
        Me._idEstructura = idestructura
    End Sub

    Function Update() As Boolean
        Dim cmd As New SqlCommand()
        Dim c As New ACCESO.Conexion
        If (c.Connect) Then
            cmd.CommandText = "UPDATE EstructuraSMA SET  fLineaBase=@LB, fMeta=@META , fPeso=@PESO , cMedicionAnual=@MED ,cEstadoCalculado=@CAL, cCondicion=@CON , cDatosGenerales=@GNRL, cCasoCondicionN=@CN WHERE idEstructura=@IDESTRUCTURA AND vIdJuntaUsuario=@IDJUNTA AND iIdComisionRegante=@IDCOMISION AND iAnio=@ANIO "
            cmd.Parameters.AddWithValue("@MED", IIf(Me._cMedida.ToString = "", DBNull.Value, Me._cMedida.ToString))
            cmd.Parameters.AddWithValue("@CAL", IIf(Me._cCalculo.ToString = "", DBNull.Value, Me._cCalculo.ToString))
            cmd.Parameters.AddWithValue("@LB", IIf(Me._fLineaBase = 0, 0, Me._fLineaBase))
            cmd.Parameters.AddWithValue("@META", IIf(Me._fMeta = 0, 0, Me._fMeta))
            cmd.Parameters.AddWithValue("@PESO", IIf(Me._fPeso = 0, DBNull.Value, Me._fPeso))
            cmd.Parameters.AddWithValue("@IDESTRUCTURA", Me._idEstructura)
            cmd.Parameters.AddWithValue("@ANIO", Me._iAnio)
            cmd.Parameters.AddWithValue("@IDJUNTA", Me._vIdJuntaUsuarios)
            cmd.Parameters.AddWithValue("@IDCOMISION", Me._iIdComisionRegante)
            cmd.Parameters.AddWithValue("@CON", Me._cCondicion)
            cmd.Parameters.AddWithValue("@GNRL", IIf(Me._cDatoGeneral.ToString = "", DBNull.Value, Me._cDatoGeneral.ToString))
            cmd.Parameters.AddWithValue("@CN", IIf(Me._cCondicionN.ToString = "", DBNull.Value, Me._cCondicionN.ToString))


            If (c.Update(cmd) = False) Then
                MsgBox(c.msgError)
                Return False
            Else
                Return True
            End If
            c.Close()
        End If
    End Function

    Sub Insert()
        Dim cmd As New SqlCommand()
        Dim c As New ACCESO.Conexion
        If (c.Connect) Then
            cmd.CommandText = "INSERT INTO EstructuraSMA (idEstructura,vIdJuntaUsuario,iIdComisionRegante,iAnio,cMedicionAnual,cEstadoCalculado,fLineaBase,fMeta,fPeso,cCondicion,cDatosGenerales,cCasoCondicionN)" _
                    & " VALUES (@IDESTRUCTURA,@IDJUNTA,@IDCOMISION,@ANIO,@MED,@CAL,@LB,@META,@PESO,@CON,@GNRL,@CN)"
            cmd.Parameters.AddWithValue("@MED", IIf(Me._cMedida.ToString = "", DBNull.Value, Me._cMedida.ToString))
            cmd.Parameters.AddWithValue("@CAL", IIf(Me._cCalculo.ToString = "", DBNull.Value, Me._cCalculo.ToString))
            cmd.Parameters.AddWithValue("@LB", IIf(Me._fLineaBase = 0, 0, Me._fLineaBase))
            cmd.Parameters.AddWithValue("@META", IIf(Me._fMeta = 0, 0, Me._fMeta))
            cmd.Parameters.AddWithValue("@PESO", IIf(Me._fPeso = 0, DBNull.Value, Me._fPeso))
            cmd.Parameters.AddWithValue("@IDESTRUCTURA", Me._idEstructura)
            cmd.Parameters.AddWithValue("@ANIO", Me._iAnio)
            cmd.Parameters.AddWithValue("@IDJUNTA", Me._vIdJuntaUsuarios)
            cmd.Parameters.AddWithValue("@IDCOMISION", Me._iIdComisionRegante)
            cmd.Parameters.AddWithValue("@CON", Me._cCondicion)
            cmd.Parameters.AddWithValue("@GNRL", IIf(Me._cDatoGeneral.ToString = "", DBNull.Value, Me._cDatoGeneral.ToString))
            cmd.Parameters.AddWithValue("@CN", IIf(Me._cCondicionN.ToString = "", DBNull.Value, Me._cCondicionN.ToString))

            If (c.Update(cmd) = False) Then
                MsgBox(c.msgError)
            End If
            c.Close()
        End If
    End Sub
    Sub InsertOpenConnection(ByVal c As ACCESO.Conexion)
        Dim cmd As New SqlCommand()
        Dim dt As New DataTable
        dt = c.Query("SELECT * FROM EstructuraSMA WHERE vIdJuntaUsuario='" & Me._vIdJuntaUsuarios & "' AND iIDComisionRegante='" & Me._iIdComisionRegante & "' AND iAnio='" & Me._iAnio & "' AND idEstructura='" & Me._idEstructura & "'")
        If (dt.Rows.Count = 0) And Me._idEstructura <> 0 Then
            cmd.CommandText = "INSERT INTO EstructuraSMA (idEstructura,vIdJuntaUsuario,iIdComisionRegante,iAnio,fpeso)" _
                    & " VALUES (@IDESTRUCTURA,@IDJUNTA,@IDCOMISION,@ANIO,@peso)"
            cmd.Parameters.AddWithValue("@IDESTRUCTURA", Me._idEstructura)
            cmd.Parameters.AddWithValue("@ANIO", Me._iAnio)
            cmd.Parameters.AddWithValue("@IDJUNTA", Me._vIdJuntaUsuarios)
            cmd.Parameters.AddWithValue("@IDCOMISION", Me._iIdComisionRegante)
            cmd.Parameters.AddWithValue("@peso", Me._fPeso)

            If (c.Insert(cmd) = False) Then
                MsgBox(c.msgError)
            End If
        End If
    End Sub
    Public Shared Function Lista(ByVal IdJU As String, ByVal IdCr As Integer, ByVal NumAnio As Integer)
        Dim c As New Conexion
        Dim dt As New DataTable
        If c.Connect Then

            dt = c.Query("SELECT     dbo.EstructuraSMA.idEstructura, dbo.Conceptos.vDescripcion " _
                        & " FROM      dbo.EstructuraSMA INNER JOIN" _
                        & " dbo.Estructura_Padre ON dbo.EstructuraSMA.idEstructura = dbo.Estructura_Padre.idEstructura INNER JOIN" _
                        & " dbo.Conceptos ON dbo.Estructura_Padre.iIdConcepto = dbo.Conceptos.iIdConcepto" _
                        & " WHERE     (dbo.EstructuraSMA.iAnio = " & NumAnio & ") AND (dbo.EstructuraSMA.vIdJuntaUsuario = '" & IdJU & "') AND (dbo.EstructuraSMA.iIdComisionRegante = " & IdCr & ")")
            c.Close()
        End If
        Return dt

    End Function

    Public Shared Function ListaCapacidades(ByVal IdJU As String, ByVal IdCr As Integer, ByVal NumAnio As Integer)
        Dim c As New Conexion
        Dim dt As New DataTable
        If c.Connect Then

            dt = c.Query("SELECT     dbo.EstructuraSMA.idEstructura, dbo.Conceptos.vDescripcion " _
                        & " FROM      dbo.EstructuraSMA INNER JOIN" _
                        & " dbo.Estructura_Padre ON dbo.EstructuraSMA.idEstructura = dbo.Estructura_Padre.idEstructura INNER JOIN" _
                        & " dbo.Conceptos ON dbo.Estructura_Padre.iIdConcepto = dbo.Conceptos.iIdConcepto" _
                        & " WHERE     (dbo.EstructuraSMA.iAnio = " & NumAnio & ") AND (dbo.EstructuraSMA.vIdJuntaUsuario = '" & IdJU & "') AND (dbo.EstructuraSMA.iIdComisionRegante = " & IdCr & ") AND " _
                        & "(dbo.Estructura_Padre.iIdTipoEstructura = 1)")
            c.Close()
        End If
        Return dt

    End Function

    Public Shared Sub LoadCheckedList(ByRef cmb As Windows.Forms.CheckedListBox, Optional ByVal condicion As String = "")
        Dim c As New ACCESO.Conexion
        If c.Connect Then
            'Dim dt = c.Query("SELECT     dbo.EstructuraSMA.idEstructura, dbo.Conceptos.vDescripcion " _
            '            & " FROM      dbo.EstructuraSMA INNER JOIN" _
            '            & " dbo.Estructura_Padre ON dbo.EstructuraSMA.idEstructura = dbo.Estructura_Padre.idEstructura INNER JOIN" _
            '            & " dbo.Conceptos ON dbo.Estructura_Padre.iIdConcepto = dbo.Conceptos.iIdConcepto " & condicion)
            '& " WHERE     (dbo.EstructuraSMA.iAnio = " & NumAnio & ") AND (dbo.EstructuraSMA.vIdJuntaUsuario = '" & IdJU & "') AND (dbo.EstructuraSMA.iIdComisionRegante = " & IdCR & ") AND (dbo.Estructura_Padre.iIdTipoEstructura = 1)"

            Dim DT = c.Query("exec sp_list_tree_Estructura " & condicion)

            cmb.DataSource = dt
            cmb.ValueMember = DT.Columns(1).ToString()
            cmb.DisplayMember = DT.Columns(0).ToString()
            cmb.Text = ""
            For i = 0 To cmb.Items.Count - 1
                cmb.CheckOnClick = True
                cmb.SetItemChecked(i, False)
            Next
            If cmb.Items.Count <> 0 Then
                cmb.SelectedIndex = 0
            Else
                cmb.SelectedIndex = -1
            End If

            c.Close()
        End If

    End Sub

    Public Shared Sub EstructuraApertura(ByRef trv As TreeView, ByVal anio As Integer, ByVal idjunta As String, ByVal idcomision As String, Optional ByVal condicion As String = "")
        Dim c As New ACCESO.Conexion
        Dim dt As New DataTable
        Dim dt2 As New DataTable
        Dim tn() As TreeNode
        Dim tn2 As New TreeNode
        Dim tn3 As New TreeNode
        Dim tipp As String = ""
        trv.Nodes.Clear()
        tn3 = New TreeNode("ESTRUCTURA DEL TABLERO")
        trv.Nodes.Add(tn3)
        tn3.Tag = 0
        tn3.Name = 0

        If (c.Connect) Then
            dt = c.Query("select iIdTipoEstructura from TipoEstructura " & condicion & " order by iIdTipoEstructura")
            For Each tipo As DataRow In dt.Rows
                dt2 = c.Query("SELECT  Estructura_Padre.idEstructura,Estructura_Padre.iIdConcepto,Estructura_Padre.idPEstructura,Conceptos.vDescripcion,EstructuraSMA.iAnio FROM Estructura_Padre INNER JOIN Conceptos ON dbo.Estructura_Padre.iIdConcepto = dbo.Conceptos.iIdConcepto LEFT OUTER JOIN EstructuraSMA ON dbo.Estructura_Padre.idEstructura = dbo.EstructuraSMA.idEstructura AND iAnio='" & anio & "' AND vIdJuntaUsuario='" & idjunta & "' AND iIdComisionRegante='" & idcomision & "' WHERE Estructura_Padre.iIdTipoEstructura='" & tipo(0) & "'")
                For Each midatarow As DataRow In dt2.Rows
                    tn2 = New TreeNode(midatarow(3))
                    tn2.Name = midatarow(0).ToString

                    tn2.Checked = IIf(midatarow(4).ToString = "", False, True)
                    If (tipo(0) > 1) Then
                        tn = trv.Nodes.Find(midatarow(2), True)
                        tn(0).Nodes.Add(tn2)
                    Else
                        tn3.Nodes.Add(tn2)
                        'trv.Nodes.Add(tn2)
                    End If
                Next
            Next

        End If
    End Sub

    Public Sub ListTreeValores(ByRef tv As DevComponents.AdvTree.AdvTree, Optional ByVal condicion As String = "")
        Dim c As New ACCESO.Conexion
        Dim dt1 As New DataTable

        Dim n1 As New DevComponents.AdvTree.Node

        Dim cdt1_1 As DevComponents.AdvTree.Cell
        Dim cdt1_2 As DevComponents.AdvTree.Cell
        Dim cdt1_3 As DevComponents.AdvTree.Cell
        Dim cdt1_4 As DevComponents.AdvTree.Cell
        Dim cdt1_5 As DevComponents.AdvTree.Cell
        Dim cdt1_6 As DevComponents.AdvTree.Cell
        Dim cdt1_7 As DevComponents.AdvTree.Cell
        Dim cdt1_8 As DevComponents.AdvTree.Cell
        Dim cdt1_9 As DevComponents.AdvTree.Cell
        Dim cdt1_10 As DevComponents.AdvTree.Cell

        Dim _styleRight As DevComponents.DotNetBar.ElementStyle
        _styleRight = New DevComponents.DotNetBar.ElementStyle()
        _styleRight.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Far

        tv.Nodes.Clear()

        If (c.Connect) Then
            dt1 = c.Query("SELECT     EstructuraSMA.idEstructura, Conceptos.vDescripcion, EstructuraSMA.fLineaBase, EstructuraSMA.fMeta,EstructuraSMA.fPeso, AperturaAnio.iAnio, Estructura_Padre.iIdConcepto, " _
                        & " Estructura_Padre.idPEstructura, Estructura_Padre.iIdTipoEstructura, AperturaAnio.vIdJuntaUsuario, AperturaAnio.iIdComisionRegante" _
                        & " FROM         EstructuraSMA INNER JOIN" _
                        & " Estructura_Padre ON EstructuraSMA.idEstructura = Estructura_Padre.idEstructura INNER JOIN" _
                        & " Conceptos ON Estructura_Padre.iIdConcepto = Conceptos.iIdConcepto INNER JOIN" _
                        & " AperturaAnio ON EstructuraSMA.iAnio = AperturaAnio.iAnio AND EstructuraSMA.vIdJuntaUsuario = AperturaAnio.vIdJuntaUsuario AND " _
                        & " EstructuraSMA.iIdComisionRegante = AperturaAnio.iIdComisionRegante" _
                        & " WHERE (Estructura_Padre.iIdTipoEstructura < 4) AND (AperturaAnio.vIdJuntaUsuario = '" & Me._vIdJuntaUsuarios & "') AND (AperturaAnio.iIdComisionRegante = " & Me._iIdComisionRegante & ") AND (AperturaAnio.iAnio = " & Me._iAnio & ") " _
                        & " AND (isnull(Estructura_Padre.idPEstructura,0) = " & condicion & ")") ' 

            For Each midatarow As DataRow In dt1.Rows
                n1 = New DevComponents.AdvTree.Node
                n1.Enabled = True
                cdt1_1 = New DevComponents.AdvTree.Cell
                cdt1_2 = New DevComponents.AdvTree.Cell
                cdt1_3 = New DevComponents.AdvTree.Cell
                cdt1_4 = New DevComponents.AdvTree.Cell
                cdt1_5 = New DevComponents.AdvTree.Cell
                cdt1_6 = New DevComponents.AdvTree.Cell
                cdt1_7 = New DevComponents.AdvTree.Cell
                cdt1_8 = New DevComponents.AdvTree.Cell
                cdt1_9 = New DevComponents.AdvTree.Cell
                cdt1_10 = New DevComponents.AdvTree.Cell

                n1.Cells.Add(cdt1_1)
                n1.Cells.Add(cdt1_2)
                n1.Cells.Add(cdt1_3)
                n1.Cells.Add(cdt1_4)
                n1.Cells.Add(cdt1_5)
                n1.Cells.Add(cdt1_6)
                n1.Cells.Add(cdt1_7)
                n1.Cells.Add(cdt1_8)
                n1.Cells.Add(cdt1_9)
                n1.Cells.Add(cdt1_10)

                n1.Cells(0).Text = midatarow(0).ToString  'item
                n1.Cells(1).Text = midatarow(1).ToString  'concepto
                n1.Cells(2).Text = midatarow(2).ToString
                n1.Cells(3).Text = midatarow(3).ToString
                n1.Cells(4).Text = midatarow(4).ToString
                n1.Cells(5).Text = midatarow(5).ToString
                n1.Cells(6).Text = midatarow(6).ToString
                n1.Cells(7).Text = midatarow(7).ToString
                n1.Cells(8).Text = midatarow(8).ToString
                n1.Cells(9).Text = midatarow(9).ToString
                n1.Cells(10).Text = midatarow(10).ToString
                'Finaliza los datos de Ejecucion ruebos Mes

                tv.Nodes.Add(n1)
                tv.Refresh()
            Next
            c.Close()
            'For i = 2 To 14
            '    tv.Columns(i).Width.Absolute = 55
            'Next
        End If

    End Sub


    Public Shared Sub EnsureNodeIsVisible(ByVal node As DevComponents.AdvTree.Node)
        '' espande elarbol como estaba cuando se seleciono el nodo
        Dim tvw As DevComponents.AdvTree.AdvTree = node.TreeControl
        tvw.SelectedNode = node
        ' expand this node and all its ancestors
        Do Until node.Parent Is Nothing
            node = node.Parent
            node.Expand()
        Loop
        tvw.SelectedNode.EnsureVisible()
    End Sub

    Public Shared Sub ExpandeNivel(ByVal node As TreeNode, ByVal inivel As Integer)
        ' expande el arbol alnivel indicado
        Dim tv As TreeView = node.TreeView
        If Not node.IsExpanded Then node.Expand()

        Dim i As Integer
        For i = 0 To node.Nodes.Count - 1
            If node.Nodes(i).Level <= inivel Then
                node.Nodes(i).Expand()
                If node.Nodes(i).Nodes.Count > 0 Then
                    ExpandeNivel(node.Nodes(i), inivel)
                End If
            End If
        Next
    End Sub

    Public Shared Sub ExpandeNivel(ByVal node As DevComponents.AdvTree.Node, ByVal inivel As Integer)
        ' expande el arbol alnivel indicado
        'Dim tv As DevComponents.AdvTree = node.
        If Not node.Expanded Then node.Expand()

        Dim i As Integer
        For i = 0 To node.Nodes.Count - 1
            If node.Nodes(i).Level <= inivel Then
                node.Nodes(i).Expand()
                If node.Nodes(i).Nodes.Count > 0 Then
                    ExpandeNivel(node.Nodes(i), inivel)
                End If
            End If
        Next
    End Sub

    Public Shared Sub RefrescaPesos(ByVal node As DevComponents.AdvTree.Node, ByVal inivel As Integer, ByVal idJunta As String, ByVal idComision As Integer, ByVal anio As Integer)
        ' actualiza el nodo
        'Dim tv As DevComponents.AdvTree = node.
        'If Not node.Expanded Then node.Expand()
        Dim sql As String
        Dim i As Integer
        Dim dt As New DataTable
        Dim c As New ACCESO.Conexion

        'For i = 0 To node.Nodes.Count - 1
        If node.Level >= inivel Then

            'capturasmo el idpestructura del idpadre
            sql = "SELECT     EstructuraSMA.fPeso "
            sql = sql & " FROM   EstructuraSMA INNER JOIN"
            sql = sql & " Estructura_Padre ON EstructuraSMA.idEstructura = Estructura_Padre.idEstructura INNER JOIN"
            sql = sql & " Conceptos ON Estructura_Padre.iIdConcepto = Conceptos.iIdConcepto"
            sql = sql & " WHERE     (ISNULL(Estructura_Padre.idEstructura, 0) =" & Val(node.Cells(7).Text) & ") AND (EstructuraSMA.vIdJuntaUsuario = '" & idJunta & "') AND (EstructuraSMA.iIdComisionRegante = " & idComision & ") AND "
            sql = sql & " (EstructuraSMA.iAnio = " & anio & ")"
            If c.Connect Then
                dt = c.Query(sql)
                node.Cells(5) = dt.Rows(0).Item(0)
                node.Expand()
                If node.Nodes(i).Nodes.Count > 0 Then
                    RefrescaPesos(node.PrevNode, inivel, idJunta, idComision, anio)
                End If
                c.Close()
            End If
        End If
        'Next
    End Sub


    Public Shared Function AsiganVance(ByRef tv As DevComponents.AdvTree.AdvTree, ByVal IdJunta As String, ByVal IdComision As Integer, ByVal IdAnio As Integer, Optional ByVal idEstCap As Integer = 0) As Boolean
        Dim dt As New DataTable
        Dim c As New ACCESO.Conexion

        If c.Connect Then
            dt = c.Query("exec dbo.sp_Devuelve_Vance_Mes '" & IdJunta & "'," & IdComision & "," & IdAnio & "," & idEstCap)
            For Each Nrow As DataRow In dt.Rows
                tv.SelectedNode = tv.FindNodeByName(Nrow.Item(4).ToString)

                tv.SelectedNode.Cells(6).Text = Math.Round(Val(Nrow.Item(7).ToString), 2)
                tv.SelectedNode.Cells(7).Text = Math.Round(Val(Nrow.Item(8).ToString), 2)
                tv.SelectedNode.Cells(8).Text = Math.Round(Val(Nrow.Item(9).ToString), 2)
                tv.SelectedNode.Cells(9).Text = Math.Round(Val(Nrow.Item(10).ToString), 2)
                tv.SelectedNode.Cells(10).Text = Math.Round(Val(Nrow.Item(11).ToString), 2)
                tv.SelectedNode.Cells(11).Text = Math.Round(Val(Nrow.Item(12).ToString), 2)
                tv.SelectedNode.Cells(12).Text = Math.Round(Val(Nrow.Item(13).ToString), 2)
                tv.SelectedNode.Cells(13).Text = Math.Round(Val(Nrow.Item(14).ToString), 2)
                tv.SelectedNode.Cells(14).Text = Math.Round(Val(Nrow.Item(15).ToString), 2)
                tv.SelectedNode.Cells(15).Text = Math.Round(Val(Nrow.Item(16).ToString), 2)
                tv.SelectedNode.Cells(16).Text = Math.Round(Val(Nrow.Item(17).ToString), 2)
                tv.SelectedNode.Cells(17).Text = Math.Round(Val(Nrow.Item(18).ToString), 2)
            Next
            c.Close()
        End If
        Return True
    End Function


    Public Shared Function CreaEstructuraApertura(ByRef tv As DevComponents.AdvTree.AdvTree, ByRef n1 As DevComponents.AdvTree.Node, ByVal IdPdre As Integer, ByVal IdJunta As String, ByVal IdComision As Integer, ByVal IdAnio As Integer, Optional ByVal estado As Boolean = False) As Boolean
        'crea elarbol con la estrutura de Aperturada para el monitoreo deindicadores
        Dim c As New ACCESO.Conexion
        Dim dt As New DataTable
        Dim sql As String
        Dim nrohijos As Integer

        Dim n2 As New DevComponents.AdvTree.Node
        Dim cdt1_1 As DevComponents.AdvTree.Cell
        Dim cdt1_2 As DevComponents.AdvTree.Cell
        Dim cdt1_3 As DevComponents.AdvTree.Cell
        Dim cdt1_4 As DevComponents.AdvTree.Cell
        Dim cdt1_5 As DevComponents.AdvTree.Cell
        Dim cdt1_6 As DevComponents.AdvTree.Cell
        Dim cdt1_7 As DevComponents.AdvTree.Cell
        Dim cdt1_8 As DevComponents.AdvTree.Cell
        Dim cdt1_9 As DevComponents.AdvTree.Cell
        Dim cdt1_10 As DevComponents.AdvTree.Cell
        Dim cdt1_11 As DevComponents.AdvTree.Cell
        Dim cdt1_12 As DevComponents.AdvTree.Cell
        Dim cdt1_13 As DevComponents.AdvTree.Cell
        Dim cdt1_14 As DevComponents.AdvTree.Cell
        Dim cdt1_15 As DevComponents.AdvTree.Cell
        Dim cdt1_16 As DevComponents.AdvTree.Cell
        Dim cdt1_17 As DevComponents.AdvTree.Cell
        Dim cdt1_18 As DevComponents.AdvTree.Cell
        Dim cdt1_19 As DevComponents.AdvTree.Cell


        If c.Connect Then

            'solo para la elprimer llamado
            If IdPdre = 0 Then
                'n1.CheckBoxVisible = True
                n2.Name = "0"  'idEstructura
                n1.Cells(0).Text = "Estructura tablero"  'item
                n1.Cells(1).Text = ""  'concepto
                n1.Cells(2).Text = ""
                n1.Cells(3).Text = ""
                n1.Cells(4).Text = ""
                n1.Cells(5).Text = ""
                n1.Cells(6).Text = ""
                n1.Cells(7).Text = ""
            Else
                If estado Then
                    'n1.CheckBoxVisible = True
                    Dim XS As String
                    Dim DTT As New DataTable
                    XS = "SELECT     dbo.Conceptos.vDescripcion"
                    XS = XS & " FROM         dbo.EstructuraSMA INNER JOIN"
                    XS = XS & " dbo.Estructura_Padre ON dbo.EstructuraSMA.idEstructura = dbo.Estructura_Padre.idEstructura INNER JOIN"
                    XS = XS & " dbo.Conceptos ON dbo.Estructura_Padre.iIdConcepto = dbo.Conceptos.iIdConcepto"
                    XS = XS & " WHERE     (dbo.EstructuraSMA.vIdJuntaUsuario = '" & IdJunta & "') AND (dbo.EstructuraSMA.iIdComisionRegante = " & IdComision & ") AND (dbo.EstructuraSMA.iAnio = " & IdAnio & ") AND "
                    XS = XS & " (dbo.EstructuraSMA.idEstructura = " & IdPdre & ")"
                    DTT = c.Query(XS)
                    n1.Name = IdPdre  'idEstructura
                    n1.Cells(0).Text = DTT.Rows(0).Item(0).ToString
                    n1.Cells(1).Text = ""  'concepto
                    n1.Cells(2).Text = ""
                    n1.Cells(3).Text = ""
                    n1.Cells(4).Text = ""
                    n1.Cells(5).Text = ""
                    n1.Cells(6).Text = ""
                    n1.Cells(7).Text = ""
                End If
            End If

                'capturamos el numero de hijos
            dt = c.Query("select dbo.fn_get_NumeroHijosApertura(" & IdPdre & ",'" & IdJunta & "'," & IdComision & ")")
                nrohijos = dt.Rows(0).Item(0)
                If nrohijos > 0 Then
                    'LISTAMOS TODOS LOS HIJOS 
                    sql = "SELECT  EstructuraSMA.vIdJuntaUsuario,EstructuraSMA.iIdComisionRegante,Estructura_Padre.idEstructura,Estructura_Padre.iIdConcepto,Estructura_Padre.idPEstructura,"
                    sql = sql & " Conceptos.vDescripcion,EstructuraSMA.iAnio,cMedicionAnual, cEstadoCalculado, EstructuraSMA.fLineaBase, EstructuraSMA.fMeta, EstructuraSMA.fPeso,Estructura_Padre.iIdTipoEstructura"
                    sql = sql & " FROM         EstructuraSMA INNER JOIN"
                    sql = sql & " Estructura_Padre ON EstructuraSMA.idEstructura = Estructura_Padre.idEstructura INNER JOIN"
                    sql = sql & " Conceptos ON Estructura_Padre.iIdConcepto = Conceptos.iIdConcepto"
                    sql = sql & " WHERE     (ISNULL(Estructura_Padre.idPEstructura, 0) = " & IdPdre & ") AND (EstructuraSMA.vIdJuntaUsuario = '" & IdJunta & "') AND (EstructuraSMA.iIdComisionRegante = " & IdComision & ") AND "
                    sql = sql & "           (EstructuraSMA.iAnio = " & IdAnio & ") and (Estructura_Padre.iIdTipoEstructura<5)" 'ANTES TENIA 4 PARA NO MOSTRAR LAS ACTIVIDADES


                    dt = c.Query(sql)
                    If IdPdre = 0 Then
                        For Each Nrow As DataRow In dt.Rows
                            n2 = New DevComponents.AdvTree.Node
                            cdt1_1 = New DevComponents.AdvTree.Cell
                            cdt1_2 = New DevComponents.AdvTree.Cell
                            cdt1_3 = New DevComponents.AdvTree.Cell
                            cdt1_4 = New DevComponents.AdvTree.Cell
                            cdt1_5 = New DevComponents.AdvTree.Cell
                            cdt1_6 = New DevComponents.AdvTree.Cell
                            cdt1_7 = New DevComponents.AdvTree.Cell
                            cdt1_8 = New DevComponents.AdvTree.Cell
                            cdt1_9 = New DevComponents.AdvTree.Cell
                            cdt1_10 = New DevComponents.AdvTree.Cell
                            cdt1_11 = New DevComponents.AdvTree.Cell
                            cdt1_12 = New DevComponents.AdvTree.Cell
                            cdt1_13 = New DevComponents.AdvTree.Cell
                            cdt1_14 = New DevComponents.AdvTree.Cell
                            cdt1_15 = New DevComponents.AdvTree.Cell
                            cdt1_16 = New DevComponents.AdvTree.Cell
                            cdt1_17 = New DevComponents.AdvTree.Cell
                            cdt1_18 = New DevComponents.AdvTree.Cell
                            cdt1_19 = New DevComponents.AdvTree.Cell

                            n2.Cells.Add(cdt1_1)
                            n2.Cells.Add(cdt1_2)
                            n2.Cells.Add(cdt1_3)
                            n2.Cells.Add(cdt1_4)
                            n2.Cells.Add(cdt1_5)
                            n2.Cells.Add(cdt1_6)
                            n2.Cells.Add(cdt1_7)
                            n2.Cells.Add(cdt1_8)
                            n2.Cells.Add(cdt1_9)
                            n2.Cells.Add(cdt1_10)
                            n2.Cells.Add(cdt1_11)
                            n2.Cells.Add(cdt1_12)
                            n2.Cells.Add(cdt1_13)
                            n2.Cells.Add(cdt1_14)
                            n2.Cells.Add(cdt1_15)
                            n2.Cells.Add(cdt1_16)
                            n2.Cells.Add(cdt1_17)
                            n2.Cells.Add(cdt1_18)
                            n2.Cells.Add(cdt1_19)

                            'ágregamos nodo
                            'n2.CheckBoxVisible = True
                            'n2.Checked = IIf(Nrow(6).ToString = "", False, True)
                            n2.Name = Nrow.Item(2).ToString  'idEstructura
                            n2.Cells(0).Text = Nrow(5).ToString  'descrip

                            'n2.Cells(1).Text = Nrow.Item(7).ToString
                            If Nrow.Item(12).ToString = 4 Then
                                'SE CAMBIOPARA FORMULARIO MONITOREO INDICADORES
                                'n2.Cells(1).CheckBoxVisible = True
                                'n2.Cells(1).Checked = IIf(Nrow.Item(7).ToString = "", False, True)  'med
                                'n2.Cells(2).CheckBoxVisible = True
                                'n2.Cells(2).Checked = IIf(Nrow.Item(8).ToString = "", False, True)  'cal
                                n2.Cells(1).Text = ""  '
                                n2.Cells(2).Text = ""  'LB
                                n2.Cells(3).Text = ""  'LB
                                n2.Cells(4).Text = ""  'META
                                n2.Cells(5).Text = ""  'PESO
                            Else
                                n2.Cells(1).Text = ""
                                n2.Cells(2).Text = ""
                            n2.Cells(3).Text = Math.Round(IIf(Nrow.Item(9).ToString <> "", Math.Round(Val(Nrow.Item(9).ToString), 2), Val("")), 2)   'LB
                            n2.Cells(4).Text = Math.Round(IIf(Nrow.Item(10).ToString <> "", Math.Round(Val(Nrow.Item(10).ToString), 2), Val("")), 2)   'META
                            n2.Cells(5).Text = Math.Round(IIf(Nrow.Item(11).ToString <> "", Math.Round(Val(Nrow.Item(11).ToString), 2), Val("")), 2)  'PESO
                            End If
                            n2.Cells(18).Text = Nrow.Item(2).ToString  'idEstructura
                            n2.Cells(19).Text = Nrow.Item(4).ToString  'idPEstructura

                            'CreaEstructuraArbol(tv, n2, Nrow.Item(2), Nrow.Item(0), Nrow.Item(1), Nrow.Item(6))
                            CreaEstructuraApertura(tv, n2, Nrow.Item(2), IdJunta, IdComision, IdAnio, False)
                            n1.Nodes.Add(n2)

                        Next
                    Else
                        'n2 = n1
                        For Each Nrow As DataRow In dt.Rows
                            n2 = New DevComponents.AdvTree.Node
                            cdt1_1 = New DevComponents.AdvTree.Cell
                            cdt1_2 = New DevComponents.AdvTree.Cell
                            cdt1_3 = New DevComponents.AdvTree.Cell
                            cdt1_4 = New DevComponents.AdvTree.Cell
                            cdt1_5 = New DevComponents.AdvTree.Cell
                            cdt1_6 = New DevComponents.AdvTree.Cell
                            cdt1_7 = New DevComponents.AdvTree.Cell
                            cdt1_8 = New DevComponents.AdvTree.Cell
                            cdt1_9 = New DevComponents.AdvTree.Cell
                            cdt1_10 = New DevComponents.AdvTree.Cell
                            cdt1_11 = New DevComponents.AdvTree.Cell
                            cdt1_12 = New DevComponents.AdvTree.Cell
                            cdt1_13 = New DevComponents.AdvTree.Cell
                            cdt1_14 = New DevComponents.AdvTree.Cell
                            cdt1_15 = New DevComponents.AdvTree.Cell
                            cdt1_16 = New DevComponents.AdvTree.Cell
                            cdt1_17 = New DevComponents.AdvTree.Cell
                            cdt1_18 = New DevComponents.AdvTree.Cell
                            cdt1_19 = New DevComponents.AdvTree.Cell

                            n2.Cells.Add(cdt1_1)
                            n2.Cells.Add(cdt1_2)
                            n2.Cells.Add(cdt1_3)
                            n2.Cells.Add(cdt1_4)
                            n2.Cells.Add(cdt1_5)
                            n2.Cells.Add(cdt1_6)
                            n2.Cells.Add(cdt1_7)
                            n2.Cells.Add(cdt1_8)
                            n2.Cells.Add(cdt1_9)
                            n2.Cells.Add(cdt1_10)
                            n2.Cells.Add(cdt1_11)
                            n2.Cells.Add(cdt1_12)
                            n2.Cells.Add(cdt1_13)
                            n2.Cells.Add(cdt1_14)
                            n2.Cells.Add(cdt1_15)
                            n2.Cells.Add(cdt1_16)
                            n2.Cells.Add(cdt1_17)
                            n2.Cells.Add(cdt1_18)
                            n2.Cells.Add(cdt1_19)

                            'ágregamos nodo
                            'n2.CheckBoxVisible = True
                            'n2.Checked = IIf(Nrow(6).ToString = "", False, True)
                            n2.Name = Nrow.Item(2).ToString  'idEstructura
                            n2.Cells(0).Text = Nrow(5).ToString  'descrip
                            'n2.Cells(1).Text = Nrow.Item(7).ToString
                            If Nrow.Item(12).ToString = 4 Then
                                'n2.Cells(1).CheckBoxVisible = True
                                'n2.Cells(1).Checked = IIf(Nrow.Item(7).ToString = "", False, True)  'med
                                'n2.Cells(2).CheckBoxVisible = True
                                'n2.Cells(2).Checked = IIf(Nrow.Item(8).ToString = "", False, True)  'cal
                                n2.Cells(1).Text = ""  '
                                n2.Cells(2).Text = ""  'LB
                                n2.Cells(3).Text = ""  'LB
                                n2.Cells(4).Text = ""  'META
                                n2.Cells(5).Text = ""  'PESO
                            Else
                                n2.Cells(1).Text = ""
                                n2.Cells(2).Text = ""
                                n2.Cells(3).Text = Math.Round(IIf(Nrow.Item(9).ToString <> "", Math.Round(Val(Nrow.Item(9).ToString), 2), ""), 2)  'LB
                                n2.Cells(4).Text = Math.Round(IIf(Nrow.Item(10).ToString <> "", Math.Round(Val(Nrow.Item(10).ToString), 2), ""), 2)   'META
                                n2.Cells(5).Text = Math.Round(IIf(Nrow.Item(11).ToString <> "", Math.Round(Val(Nrow.Item(11).ToString), 2), ""), 2)  'PESO
                            End If



                            n2.Cells(18).Text = Nrow.Item(2).ToString  'idEstructura
                            n2.Cells(19).Text = Nrow.Item(4).ToString  'idPEstructura
                            CreaEstructuraApertura(tv, n2, Nrow.Item(2), IdJunta, IdComision, IdAnio, False)
                            n1.Nodes.Add(n2)
                        Next
                    End If
                End If

                If estado Then
                    tv.Nodes.Add(n1)
                End If

                c.Close()
        End If
        Return True

    End Function

    Public Shared Function CreaEstructuraArbol(ByRef tv As DevComponents.AdvTree.AdvTree, ByRef n1 As DevComponents.AdvTree.Node, ByVal IdPdre As Integer, ByVal IdJunta As String, ByVal IdComision As Integer, ByVal IdAnio As Integer) As Boolean
        'crea elarbol con la estrutura de apertura
        On Error GoTo XERR
        Dim c As New ACCESO.Conexion
        Dim dt As New DataTable
        Dim sql As String
        Dim nrohijos As Integer

        Dim n2 As New DevComponents.AdvTree.Node
        Dim cdt1_1 As DevComponents.AdvTree.Cell
        Dim cdt1_2 As DevComponents.AdvTree.Cell
        Dim cdt1_3 As DevComponents.AdvTree.Cell
        Dim cdt1_4 As DevComponents.AdvTree.Cell
        Dim cdt1_5 As DevComponents.AdvTree.Cell
        Dim cdt1_6 As DevComponents.AdvTree.Cell
        Dim cdt1_7 As DevComponents.AdvTree.Cell
        Dim cdt1_8 As DevComponents.AdvTree.Cell
        Dim cdt1_9 As DevComponents.AdvTree.Cell
        Dim cdt1_10 As DevComponents.AdvTree.Cell

        If c.Connect Then

            'solo para la elprimer llamado
            If IdPdre = 0 Then
                'n1.CheckBoxVisible = True
                n2.Name = "0"  'idEstructura
                n1.Cells(0).Text = "Estructura tablero"  'item
                n1.Cells(1).Text = ""  'concepto
                n1.Cells(2).Text = ""
                n1.Cells(3).Text = ""
                n1.Cells(4).Text = ""
                n1.Cells(5).Text = ""
                n1.Cells(6).Text = ""
                n1.Cells(7).Text = ""
                n1.Cells(8).Text = ""
            End If

            'capturamos el numero de hijos
            dt = New DataTable
            dt = c.Query("select dbo.fn_get_NumeroHijos(" & IdPdre & ",'" & IdJunta & "'," & IdComision & "," & IdAnio & ")") '
            If dt.Rows.Count > 0 Then nrohijos = Val(dt.Rows(0).Item(0).ToString)

            sql = "SELECT     EstructuraSMA.vIdJuntaUsuario, EstructuraSMA.iIdComisionRegante, Estructura_Padre.idEstructura, Estructura_Padre.iIdConcepto, Estructura_Padre.idPEstructura, "
            sql = sql & " Conceptos.vDescripcion, EstructuraSMA.iAnio, EstructuraSMA.cMedicionAnual, EstructuraSMA.cEstadoCalculado, EstructuraSMA.cCondicion,EstructuraSMA.fLineaBase, EstructuraSMA.fMeta, EstructuraSMA.fPeso,Estructura_Padre.iIdTipoEstructura"
            sql = sql & " , Estructura_Padre.ccondicion AS ConDefault,EstructuraSMA.cDatosGenerales,EstructuraSMA.cCasoCondicionN" '13,14,15,16
            sql = sql & " FROM         Conceptos INNER JOIN"
            sql = sql & " Estructura_Padre ON Conceptos.iIdConcepto = Estructura_Padre.iIdConcepto LEFT OUTER JOIN"
            sql = sql & " EstructuraSMA ON Estructura_Padre.idEstructura = EstructuraSMA.idEstructura"
            sql = sql & " WHERE(ISNULL(Estructura_Padre.idPEstructura, 0) = " & IdPdre & ") AND (EstructuraSMA.vIdJuntaUsuario = '" & IdJunta & "') "
            sql = sql & " AND (EstructuraSMA.iIdComisionRegante = " & IdComision & ") AND  (EstructuraSMA.iAnio = " & IdAnio & ")	"
            sql = sql & " ORDER BY Estructura_Padre.idPEstructura, Estructura_Padre.iIdConcepto"

            If nrohijos = 0 Then

                dt = New DataTable
                dt = c.Query(" select dbo.fn_get_NumeroHijosApertura(" & IdPdre & ",'" & IdJunta & "'," & IdComision & ")")
                nrohijos = Val(dt.Rows(0).Item(0).ToString)
                'LISTAMOS TODOS LOS HIJOS 
                'sql = "SELECT     EstructuraSMA.vIdJuntaUsuario, EstructuraSMA.iIdComisionRegante, Estructura_Padre.idEstructura, Estructura_Padre.iIdConcepto, Estructura_Padre.idPEstructura, "
                'sql = sql & " Conceptos.vDescripcion, EstructuraSMA.iAnio, EstructuraSMA.cMedicionAnual, EstructuraSMA.cEstadoCalculado, EstructuraSMA.cCondicion,0 AS fLineaBase, 0 AS fMeta, EstructuraSMA.fPeso,Estructura_Padre.iIdTipoEstructura"
                'sql = sql & " , Estructura_Padre.ccondicion AS ConDefault,EstructuraSMA.cDatosGenerales,EstructuraSMA.cCasoCondicionN" '13,14,15
                'sql = sql & " FROM         Conceptos INNER JOIN"
                'sql = sql & " Estructura_Padre ON Conceptos.iIdConcepto = Estructura_Padre.iIdConcepto LEFT OUTER JOIN"
                'sql = sql & " EstructuraSMA ON Estructura_Padre.idEstructura = EstructuraSMA.idEstructura"
                'sql = sql & " WHERE(ISNULL(Estructura_Padre.idPEstructura, 0) = " & IdPdre & ") "
                'sql = sql & " AND (EstructuraSMA.vIdJuntaUsuario = '" & IdJunta & "') "
                'sql = sql & " AND (EstructuraSMA.iIdComisionRegante = " & IdComision & ") " 'AND  (EstructuraSMA.iAnio = " & IdAnio & ")	
                'sql = sql & " ORDER BY Estructura_Padre.idPEstructura, Estructura_Padre.iIdConcepto"

                sql = "SELECT     '" & IdJunta & "' AS vIdJuntaUsuario, " & IdComision & " AS iIdComisionRegante, Estructura_Padre.idEstructura, Estructura_Padre.iIdConcepto, Estructura_Padre.idPEstructura, "
                sql = sql & " Conceptos.vDescripcion, " & IdAnio & " AS iAnio, '' AS cMedicionAnual, '' AS cEstadoCalculado, '' AS cCondicion,0 AS fLineaBase, 0 AS fMeta, 0 AS fPeso,Estructura_Padre.iIdTipoEstructura"
                sql = sql & " , Estructura_Padre.ccondicion AS ConDefault, '' AS cDatosGenerales,'' AS cCasoCondicionN" '13,14,15
                sql = sql & " FROM         Conceptos INNER JOIN Estructura_Padre ON Conceptos.iIdConcepto = Estructura_Padre.iIdConcepto"
                sql = sql & " WHERE(ISNULL(Estructura_Padre.idPEstructura, 0) = " & IdPdre & ") "
                sql = sql & " ORDER BY Estructura_Padre.idPEstructura, Estructura_Padre.iIdConcepto"

            End If
            If nrohijos > 0 Then


                dt = New DataTable
                dt = c.Query(sql)
                If IdPdre = 0 Then
                    'MsgBox(dt.Rows.Count)

                    For Each Nrow As DataRow In dt.Rows
                        'If Nrow.Item(2).ToString = "19" Then Stop
                        n2 = New DevComponents.AdvTree.Node
                        cdt1_1 = New DevComponents.AdvTree.Cell
                        cdt1_2 = New DevComponents.AdvTree.Cell
                        cdt1_3 = New DevComponents.AdvTree.Cell
                        cdt1_4 = New DevComponents.AdvTree.Cell
                        cdt1_5 = New DevComponents.AdvTree.Cell
                        cdt1_6 = New DevComponents.AdvTree.Cell
                        cdt1_7 = New DevComponents.AdvTree.Cell
                        cdt1_8 = New DevComponents.AdvTree.Cell
                        cdt1_9 = New DevComponents.AdvTree.Cell
                        cdt1_10 = New DevComponents.AdvTree.Cell

                        n2.Cells.Add(cdt1_1)
                        n2.Cells.Add(cdt1_2)
                        n2.Cells.Add(cdt1_3)
                        n2.Cells.Add(cdt1_4)
                        n2.Cells.Add(cdt1_5)
                        n2.Cells.Add(cdt1_6)
                        n2.Cells.Add(cdt1_7)
                        n2.Cells.Add(cdt1_8)
                        n2.Cells.Add(cdt1_9)
                        n2.Cells.Add(cdt1_10)

                        'ágregamos nodo
                        'n2.CheckBoxVisible = True
                        'n2.Checked = IIf(Nrow(6).ToString = "", False, True)
                        n2.Name = Nrow.Item(2).ToString  'idEstructura
                        n2.Cells(0).Text = Nrow(5).ToString  'descrip

                        'n2.Cells(1).Text = Nrow.Item(7).ToString
                        Select Case Nrow.Item(13).ToString
                            Case 4
                                n2.Cells(1).CheckBoxVisible = True
                                n2.Cells(1).Checked = IIf(Nrow.Item(15).ToString = "", False, True)  'grl
                                n2.Cells(2).Checked = IIf(Nrow.Item(7).ToString = "", False, True)  'med
                                n2.Cells(3).Checked = IIf(Nrow.Item(8).ToString = "", False, True)  'cal
                                n2.Cells(4).Text = ""
                                n2.Cells(5).Text = IIf(Nrow.Item(16).ToString <> "", Math.Round(Val(Nrow.Item(16).ToString), 4), "")   'condicionN
                                n2.Cells(6).Text = ""  'LB
                                n2.Cells(7).Text = ""  'META
                                n2.Cells(8).Text = ""  'PESO
                            Case 3
                                n2.Cells(1).Text = ""
                                n2.Cells(2).Text = ""
                                n2.Cells(3).Text = ""
                                n2.Cells(4).Text = IIf(Nrow.Item(9).ToString <> "", Nrow.Item(9).ToString, Nrow.Item(14).ToString) : n2.Cells(3).Enabled = False
                                n2.Cells(6).Text = IIf(Nrow.Item(10).ToString <> "", Math.Round(Val(Nrow.Item(10).ToString), 4), "")   'LB
                                n2.Cells(7).Text = IIf(Nrow.Item(11).ToString <> "", Math.Round(Val(Nrow.Item(11).ToString), 4), "")   'META
                                n2.Cells(8).Text = IIf(Nrow.Item(12).ToString <> "", Math.Round(Val(Nrow.Item(12).ToString), 4), "")  'PESO
                                'n2.Cells(1).Enabled = False
                                'n2.Cells(2).Enabled = False
                                'n2.Cells(3).Enabled = False
                                'n2.Cells(5).Enabled = False
                            Case 1, 2
                                n2.Cells(1).Text = ""
                                n2.Cells(2).Text = ""
                                n2.Cells(3).Text = ""
                                n2.Cells(4).Text = ""
                                n2.Cells(6).Text = IIf(Nrow.Item(10).ToString <> "", Math.Round(Val(Nrow.Item(10).ToString), 4), "")   'LB
                                n2.Cells(7).Text = IIf(Nrow.Item(11).ToString <> "", Math.Round(Val(Nrow.Item(11).ToString), 4), "")   'META
                                n2.Cells(8).Text = IIf(Nrow.Item(12).ToString <> "", Math.Round(Val(Nrow.Item(12).ToString), 4), "")  'PESO

                                n1.Cells(6).Text = Val(n1.Cells(6).Text.ToString) + IIf(Nrow.Item(10).ToString <> "", Math.Round(Val(Nrow.Item(10).ToString), 4), 0)   'LB
                                n1.Cells(7).Text = Val(n1.Cells(7).Text.ToString) + IIf(Nrow.Item(11).ToString <> "", Math.Round(Val(Nrow.Item(11).ToString), 4), 0)   'META
                                n1.Cells(8).Text = Val(n1.Cells(8).Text.ToString) + IIf(Nrow.Item(12).ToString <> "", Math.Round(Val(Nrow.Item(12).ToString), 4), 0)  'PESO

                        End Select


                        n2.Cells(9).Text = Nrow.Item(2).ToString  'idEstructura
                        n2.Cells(10).Text = Nrow.Item(4).ToString  'idPEstructura

                        'CreaEstructuraArbol(tv, n2, Nrow.Item(2), Nrow.Item(0), Nrow.Item(1), Nrow.Item(6))
                        CreaEstructuraArbol(tv, n2, Nrow.Item(2), IdJunta, IdComision, IdAnio)
                        n1.Nodes.Add(n2)

                    Next
                Else
                    'n2 = n1
                    For Each Nrow As DataRow In dt.Rows
                        'If Nrow.Item(2).ToString = "19" Then Stop
                        n2 = New DevComponents.AdvTree.Node
                        cdt1_1 = New DevComponents.AdvTree.Cell
                        cdt1_2 = New DevComponents.AdvTree.Cell
                        cdt1_3 = New DevComponents.AdvTree.Cell
                        cdt1_4 = New DevComponents.AdvTree.Cell
                        cdt1_5 = New DevComponents.AdvTree.Cell
                        cdt1_6 = New DevComponents.AdvTree.Cell
                        cdt1_7 = New DevComponents.AdvTree.Cell
                        cdt1_8 = New DevComponents.AdvTree.Cell
                        cdt1_9 = New DevComponents.AdvTree.Cell
                        cdt1_10 = New DevComponents.AdvTree.Cell

                        n2.Cells.Add(cdt1_1)
                        n2.Cells.Add(cdt1_2)
                        n2.Cells.Add(cdt1_3)
                        n2.Cells.Add(cdt1_4)
                        n2.Cells.Add(cdt1_5)
                        n2.Cells.Add(cdt1_6)
                        n2.Cells.Add(cdt1_7)
                        n2.Cells.Add(cdt1_8)
                        n2.Cells.Add(cdt1_9)
                        n2.Cells.Add(cdt1_10)

                        'ágregamos nodo
                        'n2.CheckBoxVisible = True
                        'n2.Checked = IIf(Nrow(6).ToString = "", False, True)
                        n2.Name = Nrow.Item(2).ToString  'idEstructura
                        n2.Cells(0).Text = Nrow(5).ToString  'descrip
                        'n2.Cells(1).Text = Nrow.Item(7).ToString
                        Select Case Nrow.Item(13).ToString
                            Case 4
                                n2.Cells(1).CheckBoxVisible = True
                                n2.Cells(1).Checked = IIf(Nrow.Item(15).ToString = "", False, True)  'GNRL
                                n2.Cells(2).CheckBoxVisible = True
                                n2.Cells(2).Checked = IIf(Nrow.Item(7).ToString = "", False, True)  'med
                                n2.Cells(3).CheckBoxVisible = True
                                n2.Cells(3).Checked = IIf(Nrow.Item(8).ToString = "", False, True)  'cal
                                n2.Cells(4).Text = ""
                                n2.Cells(5).Text = IIf(Nrow.Item(16).ToString <> "", Math.Round(Val(Nrow.Item(16).ToString), 4), "")   'condicionN
                                n2.Cells(6).Text = ""  'LB
                                n2.Cells(7).Text = ""  'META
                                n2.Cells(8).Text = ""  'PESO
                                'n2.Cells(5).Text = IIf(Nrow.Item(10).ToString <> "", Math.Round(Val(Nrow.Item(10).ToString), 4), "")   'LB
                                'n2.Cells(6).Text = IIf(Nrow.Item(11).ToString <> "", Math.Round(Val(Nrow.Item(11).ToString), 4), "")   'META
                                n2.Cells(8).Text = IIf(Nrow.Item(12).ToString <> "", Math.Round(Val(Nrow.Item(12).ToString), 4), "")  'PESO

                            Case 3
                                n2.Cells(1).Text = ""
                                n2.Cells(2).Text = ""
                                n2.Cells(3).Text = ""
                                n2.Cells(4).Text = IIf(Nrow.Item(9).ToString <> "", Nrow.Item(9).ToString, Nrow.Item(14).ToString) : n2.Cells(3).Enabled = False
                                n2.Cells(6).Text = IIf(Nrow.Item(10).ToString <> "", Math.Round(Val(Nrow.Item(10).ToString), 4), "")   'LB
                                n2.Cells(7).Text = IIf(Nrow.Item(11).ToString <> "", Math.Round(Val(Nrow.Item(11).ToString), 4), "")   'META
                                n2.Cells(8).Text = IIf(Nrow.Item(12).ToString <> "", Math.Round(Val(Nrow.Item(12).ToString), 4), "")  'PESO
                                'n2.Cells(1).Enabled = False
                                'n2.Cells(2).Enabled = False
                                'n2.Cells(3).Enabled = False
                                'n2.Cells(5).Enabled = False

                            Case 1, 2
                                n2.Cells(1).Text = ""
                                n2.Cells(2).Text = ""
                                n2.Cells(3).Text = ""
                                n2.Cells(4).Text = ""
                                n2.Cells(6).Text = IIf(Nrow.Item(10).ToString <> "", Math.Round(Val(Nrow.Item(10).ToString), 4), "")   'LB
                                n2.Cells(7).Text = IIf(Nrow.Item(11).ToString <> "", Math.Round(Val(Nrow.Item(11).ToString), 4), "")   'META
                                n2.Cells(8).Text = IIf(Nrow.Item(12).ToString <> "", Math.Round(Val(Nrow.Item(12).ToString), 4), "")  'PESO

                        End Select
                        n2.Cells(9).Text = Nrow.Item(2).ToString  'idEstructura
                        n2.Cells(10).Text = Nrow.Item(4).ToString  'idPEstructura
                        CreaEstructuraArbol(tv, n2, Nrow.Item(2), IdJunta, IdComision, IdAnio)
                        n1.Nodes.Add(n2)
                    Next
                End If
            End If

            If IdPdre = 0 Then
                tv.Nodes.Add(n1)
            End If

            c.Close()
        End If
        Return True
XERR:
        If Err.Number <> 0 Then

            MsgBox(Err.Description)
            Resume
        End If
    End Function

    Public Shared Function SumatoriaPesosHijos(ByVal IdPadre As Integer, ByVal idJu As String, ByVal idcr As Integer, ByVal ianio As Integer) As Double
        Dim dt As New DataTable
        Dim c As New ACCESO.Conexion
        Dim sql As String
        Dim p As Double = 0
        If c.Connect Then
            sql = "SELECT     sum(EstructuraSMA.fPeso)"
            sql &= " FROM         Conceptos INNER JOIN"
            sql &= " Estructura_Padre ON Conceptos.iIdConcepto = Estructura_Padre.iIdConcepto LEFT OUTER JOIN"
            sql &= " EstructuraSMA ON Estructura_Padre.idEstructura = EstructuraSMA.idEstructura"
            sql &= " WHERE     (ISNULL(Estructura_Padre.idPEstructura, 0) = " & IdPadre & ") AND (EstructuraSMA.vIdJuntaUsuario = '" & idJu & "') AND (EstructuraSMA.iIdComisionRegante = " & idcr & ") AND "
            sql &= " (EstructuraSMA.iAnio = " & ianio & ")"
            dt = c.Query(sql)

            p = Val(dt.Rows(0).Item(0).ToString)
            c.Close()
        End If
        Return p

    End Function

    Public Shared Sub TreeEstructuraSMA(ByRef trv As TreeView, ByVal anio As Integer, ByVal idjunta As String, ByVal idcomision As String, Optional ByVal condicion As String = "")
        'MUESTRA INFORMACION DE LA ESTRUCTURA APERTURADA PARA EL ANIO
        Dim c As New ACCESO.Conexion
        Dim dt As New DataTable
        Dim dt2 As New DataTable
        Dim tn() As TreeNode
        Dim tn2 As New TreeNode
        Dim tn3 As New TreeNode
        Dim tipp As String = ""
        trv.Nodes.Clear()
        tn3 = New TreeNode("ESTRUCTURA DEL TABLERO")
        trv.Nodes.Add(tn3)
        tn3.Tag = 0
        tn3.Name = 0

        If (c.Connect) Then
            dt = c.Query("select iIdTipoEstructura from TipoEstructura " & condicion & " order by iIdTipoEstructura")
            For Each tipo As DataRow In dt.Rows
                dt2 = c.Query("SELECT  Estructura_Padre.idEstructura,Estructura_Padre.iIdConcepto,Estructura_Padre.idPEstructura,Conceptos.vDescripcion,EstructuraSMA.iAnio FROM Estructura_Padre INNER JOIN Conceptos ON dbo.Estructura_Padre.iIdConcepto = dbo.Conceptos.iIdConcepto INNER JOIN EstructuraSMA ON dbo.Estructura_Padre.idEstructura = dbo.EstructuraSMA.idEstructura AND iAnio='" & anio & "' AND vIdJuntaUsuario='" & idjunta & "' AND iIdComisionRegante='" & idcomision & "' WHERE Estructura_Padre.iIdTipoEstructura='" & tipo(0) & "'")
                For Each midatarow As DataRow In dt2.Rows
                    tn2 = New TreeNode(midatarow(3))
                    tn2.Name = midatarow(0).ToString

                    tn2.Checked = IIf(midatarow(4).ToString = "", False, True)
                    If (tipo(0) > 1) Then
                        tn = trv.Nodes.Find(midatarow(2), True)
                        tn(0).Nodes.Add(tn2)
                    Else
                        tn3.Nodes.Add(tn2)
                        'trv.Nodes.Add(tn2)
                    End If
                Next
            Next

        End If
    End Sub

    Public Shared Function ActualizaLineaBase(ByVal IdPdre As Integer, ByVal IdJunta As String, ByVal IdComision As Integer, ByVal IdAnio As Integer)
        '' calcula las metas desde la medida hasta la capacidad
        Dim c As New ACCESO.Conexion
        Dim dt As New DataTable
        Dim sql As String
        Dim fLineab As Double
        Dim fpeso As Double
        Dim idtipo As Integer
        Dim id As Integer

        If c.Connect Then
            'PROMEDIO DE PESOS DE TODOS LOS HIJOS 
            sql = "SELECT  isnull(SUM(EstructuraSMA.fLineaBase),0)"
            sql = sql & " FROM         EstructuraSMA INNER JOIN"
            sql = sql & " Estructura_Padre ON EstructuraSMA.idEstructura = Estructura_Padre.idEstructura INNER JOIN"
            sql = sql & " Conceptos ON Estructura_Padre.iIdConcepto = Conceptos.iIdConcepto"
            sql = sql & " WHERE     (ISNULL(Estructura_Padre.idPEstructura, 0) = " & IdPdre & ") AND (EstructuraSMA.vIdJuntaUsuario = '" & IdJunta & "') AND (EstructuraSMA.iIdComisionRegante = " & IdComision & ") AND "
            sql = sql & "           (EstructuraSMA.iAnio = " & IdAnio & ")"
            dt = c.Query(sql)
            fLineab = CDbl(dt.Rows(0).Item(0).ToString)

            'peso del idpadre
            sql = " SELECT     EstructuraSMA.fPeso, Estructura_Padre.iIdTipoEstructura"
            sql = sql & " FROM         EstructuraSMA INNER JOIN"
            sql = sql & " Estructura_Padre ON EstructuraSMA.idEstructura = Estructura_Padre.idEstructura INNER JOIN"
            sql = sql & " Conceptos ON Estructura_Padre.iIdConcepto = Conceptos.iIdConcepto"
            sql = sql & " WHERE     (ISNULL(Estructura_Padre.idEstructura, 0) = " & IdPdre & ") AND (EstructuraSMA.vIdJuntaUsuario = '" & IdJunta & "') AND (EstructuraSMA.iIdComisionRegante = " & IdComision & ") AND "
            sql = sql & " (EstructuraSMA.iAnio = " & IdAnio & ")"
            dt = c.Query(sql)
            If dt.Rows.Count = 0 Then Exit Function
            idtipo = Val(dt.Rows(0).Item(1).ToString)
            fpeso = CDbl(dt.Rows(0).Item(0).ToString)

            'promedio ponderado del idpadre
            If idtipo <> 1 Then
                fLineab = Math.Round(fLineab * fpeso, 2)
            Else
                fLineab = Math.Round(fLineab, 2)
            End If



            'asignamos peso alos hijos
            c.Query("UPDATE dbo.view_UpdateValoresSMA   SET fLineaBase=" & fLineab & " WHERE  (vIdJuntaUsuario = '" & IdJunta & "') AND (iIdComisionRegante = " & IdComision & ") AND (iAnio = " & IdAnio & ") AND (ISNULL(idEstructura,0) = " & IdPdre & ")")

            'capturasmo el idpestructura del idpadre
            sql = "SELECT     isnull(Estructura_Padre.idPEstructura,0), Estructura_Padre.iIdTipoEstructura"
            sql = sql & " FROM   EstructuraSMA INNER JOIN"
            sql = sql & " Estructura_Padre ON EstructuraSMA.idEstructura = Estructura_Padre.idEstructura INNER JOIN"
            sql = sql & " Conceptos ON Estructura_Padre.iIdConcepto = Conceptos.iIdConcepto"
            sql = sql & " WHERE     (ISNULL(Estructura_Padre.idEstructura, 0) =" & IdPdre & ") AND (EstructuraSMA.vIdJuntaUsuario = '" & IdJunta & "') AND (EstructuraSMA.iIdComisionRegante = " & IdComision & ") AND "
            sql = sql & " (EstructuraSMA.iAnio = " & IdAnio & ")"

            dt = c.Query(sql)
            If dt.Rows.Count > 0 Then
                If dt.Rows(0).Item(0) > 0 Then
                    id = dt.Rows(0).Item(0)
                    ActualizaLineaBase(id, IdJunta, IdComision, IdAnio)
                End If
            End If

            c.Close()
        End If
        Return True
    End Function


    'Public Shared Function ActualizaMetas(ByVal IdPdre As Integer, ByVal IdJunta As String, ByVal IdComision As Integer, ByVal IdAnio As Integer)
    '    '' calcula las metas desde la medida hasta la capacidad
    '    Dim c As New ACCESO.Conexion
    '    Dim dt As New DataTable
    '    Dim sql As String
    '    Dim fmeta As Double
    '    Dim fpeso As Double
    '    Dim idtipo As Integer
    '    Dim id As Integer

    '    If c.Connect Then
    '        'SUMA DE METAS DE TODOS LOS HIJOS 
    '        sql = "SELECT  isnull(SUM(EstructuraSMA.fmeta),0)"
    '        sql = sql & " FROM         EstructuraSMA INNER JOIN"
    '        sql = sql & " Estructura_Padre ON EstructuraSMA.idEstructura = Estructura_Padre.idEstructura INNER JOIN"
    '        sql = sql & " Conceptos ON Estructura_Padre.iIdConcepto = Conceptos.iIdConcepto"
    '        sql = sql & " WHERE     (ISNULL(Estructura_Padre.idPEstructura, 0) = " & IdPdre & ") AND (EstructuraSMA.vIdJuntaUsuario = '" & IdJunta & "') AND (EstructuraSMA.iIdComisionRegante = " & IdComision & ") AND "
    '        sql = sql & "           (EstructuraSMA.iAnio = " & IdAnio & ")"
    '        dt = c.Query(sql)
    '        fmeta = CDbl(dt.Rows(0).Item(0).ToString)

    '        'peso del idpadre
    '        sql = " SELECT     EstructuraSMA.fPeso, Estructura_Padre.iIdTipoEstructura"
    '        sql = sql & " FROM         EstructuraSMA INNER JOIN"
    '        sql = sql & " Estructura_Padre ON EstructuraSMA.idEstructura = Estructura_Padre.idEstructura INNER JOIN"
    '        sql = sql & " Conceptos ON Estructura_Padre.iIdConcepto = Conceptos.iIdConcepto"
    '        sql = sql & " WHERE     (ISNULL(Estructura_Padre.idEstructura, 0) = " & IdPdre & ") AND (EstructuraSMA.vIdJuntaUsuario = '" & IdJunta & "') AND (EstructuraSMA.iIdComisionRegante = " & IdComision & ") AND "
    '        sql = sql & " (EstructuraSMA.iAnio = " & IdAnio & ")"
    '        dt = c.Query(sql)

    '        If dt.Rows.Count = 0 Then

    '        End If
    '        Exit Function
    '        idtipo = Val(dt.Rows(0).Item(1).ToString)
    '        fpeso = CDbl(dt.Rows(0).Item(0).ToString)

    '        'promedio ponderado del idpadre
    '        If idtipo <> 1 Then
    '            fmeta = Math.Round(fmeta * fpeso, 2)
    '        Else
    '            fmeta = Math.Round(fmeta, 2)
    '        End If

    '        'asignamos peso alos hijos
    '        c.Query("UPDATE dbo.view_UpdateValoresSMA   SET fMeta=" & fmeta & " WHERE  (vIdJuntaUsuario = '" & IdJunta & "') AND (iIdComisionRegante = " & IdComision & ") AND (iAnio = " & IdAnio & ") AND (ISNULL(idEstructura,0) = " & IdPdre & ")")

    '        'capturasmo el idpestructura del idpadre
    '        sql = "SELECT     isnull(Estructura_Padre.idPEstructura,0), Estructura_Padre.iIdTipoEstructura"
    '        sql = sql & " FROM   EstructuraSMA INNER JOIN"
    '        sql = sql & " Estructura_Padre ON EstructuraSMA.idEstructura = Estructura_Padre.idEstructura INNER JOIN"
    '        sql = sql & " Conceptos ON Estructura_Padre.iIdConcepto = Conceptos.iIdConcepto"
    '        sql = sql & " WHERE     (ISNULL(Estructura_Padre.idEstructura, 0) =" & IdPdre & ") AND (EstructuraSMA.vIdJuntaUsuario = '" & IdJunta & "') AND (EstructuraSMA.iIdComisionRegante = " & IdComision & ") AND "
    '        sql = sql & " (EstructuraSMA.iAnio = " & IdAnio & ")"

    '        dt = c.Query(sql)
    '        If dt.Rows.Count > 0 Then
    '            If dt.Rows(0).Item(0) > 0 Then
    '                id = dt.Rows(0).Item(0)
    '                ActualizaMetas(id, IdJunta, IdComision, IdAnio)
    '            End If
    '        End If

    '        c.Close()
    '    End If
    '        Return True
    'End Function


    Public Shared Function AperturaPesos(ByVal IdPdre As Integer, ByVal IdJunta As String, ByVal IdComision As Integer, ByVal IdAnio As Integer) As Integer
        Dim c As New ACCESO.Conexion
        Dim dt As New DataTable
        Dim sql As String
        Dim fpesoPadre As Double
        Dim nrohijos As Integer
        Dim fpeso As Double

        If c.Connect Then
            'capturamos el peso del padre
            sql = "SELECT  isnull(dbo.EstructuraSMA.fpeso,0) "
            sql = sql & " FROM    dbo.EstructuraSMA INNER JOIN dbo.Estructura_Padre ON dbo.EstructuraSMA.idEstructura = dbo.Estructura_Padre.idEstructura "
            sql = sql & " INNER JOIN dbo.Conceptos ON dbo.Estructura_Padre.iIdConcepto = dbo.Conceptos.iIdConcepto "
            sql = sql & " WHERE   ISNULL(dbo.Estructura_Padre.idEstructura,0)=" & IdPdre & " AND (EstructuraSMA.vIdJuntaUsuario = '" & IdJunta & "') AND "
            sql = sql & " (EstructuraSMA.iIdComisionRegante = " & IdComision & ") AND (EstructuraSMA.iAnio = " & IdAnio & ")"

            dt = c.Query(sql)
            If dt.Rows.Count > 0 Then
                fpesoPadre = dt.Rows(0).Item(0)
            Else
                fpesoPadre = 1
            End If
            'capturamos el numero de hijos
            dt = c.Query("select dbo.fn_get_NumeroHijos(" & IdPdre & "," & IdJunta & "," & IdComision & "," & IdAnio & ")")
            nrohijos = dt.Rows(0).Item(0)

            'peso para cada hijo
            If nrohijos > 0 Then
                fpeso = fpesoPadre / nrohijos
            Else
                fpeso = fpesoPadre
            End If

            'asignamos peso alos hijos
            c.Query("UPDATE dbo.view_UpdateValoresSMA   SET fPeso=" & fpeso & " WHERE  (vIdJuntaUsuario = '" & IdJunta & "') AND (iIdComisionRegante = " & IdComision & ") AND (iAnio = " & IdAnio & ") AND (ISNULL(idPEstructura,0) = " & IdPdre & ")")


            'LISTAMOS TODOS LOS HIJOS y sus pesos asiganados
            sql = "SELECT    EstructuraSMA.idEstructura, EstructuraSMA.vIdJuntaUsuario, EstructuraSMA.iIdComisionRegante, EstructuraSMA.iAnio,  EstructuraSMA.fPeso"
            sql = sql & " FROM         EstructuraSMA INNER JOIN"
            sql = sql & " Estructura_Padre ON EstructuraSMA.idEstructura = Estructura_Padre.idEstructura INNER JOIN"
            sql = sql & " Conceptos ON Estructura_Padre.iIdConcepto = Conceptos.iIdConcepto"
            sql = sql & " WHERE     (ISNULL(Estructura_Padre.idPEstructura, 0) = " & IdPdre & ") AND (EstructuraSMA.vIdJuntaUsuario = '" & IdJunta & "') AND (EstructuraSMA.iIdComisionRegante = " & IdComision & ") AND "
            sql = sql & "           (EstructuraSMA.iAnio = " & IdAnio & ")"
            dt = c.Query(sql)

            For Each Nrow As DataRow In dt.Rows
                AperturaPesos(Nrow.Item(0), Nrow.Item(1), Nrow.Item(2), Nrow.Item(3))
            Next

            c.Close()
        End If
        Return 1

    End Function

    Public Shared Function ActualizaPesos(ByVal IdPdre As Integer, ByVal IdJunta As String, ByVal IdComision As Integer, ByVal IdAnio As Integer)
        '' calculalos peso hacia arriba de la medida
        Dim c As New ACCESO.Conexion
        Dim dt As New DataTable
        Dim sql As String
        Dim fmeta As Double
        Dim id As Integer

        If c.Connect Then
            'PROMEDIO DE PESOS DE TODOS LOS HIJOS 
            sql = "SELECT  isnull(SUM(EstructuraSMA.fPeso),0)"
            sql = sql & " FROM         EstructuraSMA INNER JOIN"
            sql = sql & " Estructura_Padre ON EstructuraSMA.idEstructura = Estructura_Padre.idEstructura INNER JOIN"
            sql = sql & " Conceptos ON Estructura_Padre.iIdConcepto = Conceptos.iIdConcepto"
            sql = sql & " WHERE     (ISNULL(Estructura_Padre.idPEstructura, 0) = " & IdPdre & ") AND (EstructuraSMA.vIdJuntaUsuario = '" & IdJunta & "') AND (EstructuraSMA.iIdComisionRegante = " & IdComision & ") AND "
            sql = sql & "           (EstructuraSMA.iAnio = " & IdAnio & ")"
            dt = c.Query(sql)
            fmeta = dt.Rows(0).Item(0)

            'asignamos peso alos hijos
            c.Query("UPDATE dbo.view_UpdateValoresSMA   SET fPeso=" & fmeta & " WHERE  (vIdJuntaUsuario = '" & IdJunta & "') AND (iIdComisionRegante = " & IdComision & ") AND (iAnio = " & IdAnio & ") AND (ISNULL(idEstructura,0) = " & IdPdre & ")")

            'capturasmo el idpestructura del idpadre
            sql = "SELECT     isnull(Estructura_Padre.idPEstructura,0), Estructura_Padre.iIdTipoEstructura"
            sql = sql & " FROM   EstructuraSMA INNER JOIN"
            sql = sql & " Estructura_Padre ON EstructuraSMA.idEstructura = Estructura_Padre.idEstructura INNER JOIN"
            sql = sql & " Conceptos ON Estructura_Padre.iIdConcepto = Conceptos.iIdConcepto"
            sql = sql & " WHERE     (ISNULL(Estructura_Padre.idEstructura, 0) =" & IdPdre & ") AND (EstructuraSMA.vIdJuntaUsuario = '" & IdJunta & "') AND (EstructuraSMA.iIdComisionRegante = " & IdComision & ") AND "
            sql = sql & " (EstructuraSMA.iAnio = " & IdAnio & ")"

            dt = c.Query(sql)
            If dt.Rows.Count > 0 Then
                If dt.Rows(0).Item(0) > 0 Then
                    id = dt.Rows(0).Item(0)
                    ActualizaPesos(id, IdJunta, IdComision, IdAnio)
                End If
            End If

            c.Close()
        End If
        Return True
    End Function

    Public Shared Sub LoadCombo(ByRef cmb As Windows.Forms.ComboBox, Optional ByVal condicion As String = "")
        Dim c As New ACCESO.Conexion
        Dim dt As New DataTable
        'Dim DT2 As New DataTable
        If c.Connect Then
            dt = c.Query("exec sp_list_tree_Estructura_Calculada " & condicion)
            'MsgBox(dt.Rows.Count)
            'MsgBox(dt.Select(" Estado='1'").Count)
            cmb.DataSource = dt
            cmb.ValueMember = dt.Columns(1).ToString()
            cmb.DisplayMember = dt.Columns(0).ToString()
            cmb.Text = ""
            If cmb.Items.Count <> 0 Then
                cmb.SelectedIndex = 0
            Else
                cmb.SelectedIndex = -1
            End If

            c.Close()
        End If

    End Sub
    Public Shared Function ImportEstructuraSMAAnterior(ByVal anioActual As Integer, ByVal idjunta As String, ByVal idcomision As Integer) As Boolean
        Dim cmd As New SqlCommand()
        Dim dt As New DataTable
        Dim c As New ACCESO.Conexion
        If (c.Connect) Then
            cmd.CommandText = "sp_EstructuraSMA_importAnterior"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@ANIO", anioActual)
            cmd.Parameters.AddWithValue("@IDJUNTA", idjunta)
            cmd.Parameters.AddWithValue("@IDCOMISION", idcomision)

            If (c.Insert(cmd) = False) Then
                MsgBox(c.msgError)
                Return False
            Else
                dt = c.Query("execute sp_Devuelve_vance_Mes '" & idjunta & "'," & idcomision & "," & anioActual - 1 & ",0")
                For Each r As DataRow In dt.Rows
                    c.Query("UPDATE EstructuraSMA set fLineaBase=" & r("DIC") & " WHERE iAnio=" & anioActual & " AND vIdJuntaUsuario=" & idjunta & " AND iIdComisionRegante=" & idcomision & " and idEstructura=" & r("IDEST"))
                Next
                Return True
            End If

            c.Close()
        End If
    End Function

End Class
