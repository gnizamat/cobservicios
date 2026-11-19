Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports ACCESO

'Autor: jorge Agurto
'Fecha: 21/06/2010
'Descripcion: clase creada para generar y consultar la estrutura de capacidades indicadores y medidas

Public Class clsEstructuraTablero

    Private _IdEstructura As Integer
    Private _iIdConcepto As Integer
    Private _iIdConcepto1 As Integer
    Private _iIdConcepto2 As Integer
    Private _idPEstructura As Integer
    Private _iIdTipoEstructura As Integer
    Private _ccondicion As String
    Private _iVisualizacion As Integer

    Public Property IdTipoEstructura()
        Get
            Return Me._iIdTipoEstructura
        End Get
        Set(ByVal value)
            Me._iIdTipoEstructura = value
        End Set
    End Property

    Public Property idPEstructura()
        Get
            Return Me._idPEstructura
        End Get
        Set(ByVal value)
            Me._idPEstructura = value
        End Set
    End Property


    Public Property IdEstructura()
        Get
            Return Me._IdEstructura
        End Get
        Set(ByVal value)
            Me._IdEstructura = value
        End Set
    End Property

    Public Property IdConcepto()
        Get
            Return Me._iIdConcepto
        End Get
        Set(ByVal value)
            Me._iIdConcepto = value
        End Set
    End Property

    Public Property IdConcepto1()
        Get
            Return Me._iIdConcepto1
        End Get
        Set(ByVal value)
            Me._iIdConcepto1 = value
        End Set
    End Property

    Public Property IdConcepto2()
        Get
            Return Me._iIdConcepto2
        End Get
        Set(ByVal value)
            Me._iIdConcepto2 = value
        End Set
    End Property
    Public Property Condicion()
        Get
            Return Me._ccondicion
        End Get
        Set(ByVal value)
            Me._ccondicion = value
        End Set
    End Property

    Public Property Visualizacion()
        Get
            Return Me._iVisualizacion
        End Get
        Set(ByVal value)
            Me._iVisualizacion = value
        End Set
    End Property

    Private Function NewId()
        Dim c As New ACCESO.Conexion
        Dim dt As New DataTable
        Dim id As Integer
        If (c.Connect) Then
            dt = c.Query("select isNull(max(idEstructura),0) from dbo.Estructura_Padre")
            c.Close()
            id = dt.Rows(0).Item(0) + 1
        End If
        Return id
    End Function

    Public Function Insert() As Boolean
        Dim cmd As New SqlCommand()
        Dim c As New ACCESO.Conexion
        Me._IdEstructura = Me.NewId
        If (c.Connect) Then
            If Me._idPEstructura <> 0 Then
                cmd.CommandText = "INSERT INTO Estructura_Padre (idEstructura, iIdConcepto, idPEstructura, iIdTipoEstructura,ccondicion,tvisualizacion,iIdConcepto1,iIdConcepto2 )" _
                    & " VALUES (@IDES,@IDCON,@IDPCON,@IDTIPO,@COND,@VIS,@IDCON1,@IDCON2)"
                cmd.Parameters.AddWithValue("@IDES", Me._IdEstructura)
                cmd.Parameters.AddWithValue("@IDCON", Me._iIdConcepto)
                cmd.Parameters.AddWithValue("@IDPCON", Me._idPEstructura)
                cmd.Parameters.AddWithValue("@IDTIPO", Me._iIdTipoEstructura)
                cmd.Parameters.AddWithValue("@COND", IIf(Me._ccondicion.ToString = "", DBNull.Value, Me._ccondicion))
                cmd.Parameters.AddWithValue("@VIS", IIf(Me._iVisualizacion = -1, DBNull.Value, Me._iVisualizacion))
                cmd.Parameters.AddWithValue("IDCON1", IIf(Me._iIdConcepto1 = 0, DBNull.Value, Me._iIdConcepto1))
                cmd.Parameters.AddWithValue("IDCON2", IIf(Me._iIdConcepto2 = 0, DBNull.Value, Me._iIdConcepto2))

            Else
                cmd.CommandText = "INSERT INTO Estructura_Padre (idEstructura, iIdConcepto,  iIdTipoEstructura,ccondicion,tvisualizacion,iIdConcepto1,iIdConcepto2)" _
                    & " VALUES (@IDES,@IDCON,@IDTIPO,@COND,@VIS,@IDCON1,@IDCON2)"
                cmd.Parameters.AddWithValue("@IDES", Me._IdEstructura)
                cmd.Parameters.AddWithValue("@IDCON", Me._iIdConcepto)
                cmd.Parameters.AddWithValue("@IDTIPO", Me._iIdTipoEstructura)
                cmd.Parameters.AddWithValue("@COND", IIf(Me._ccondicion.ToString = "", DBNull.Value, Me._ccondicion))
                cmd.Parameters.AddWithValue("@VIS", IIf(Me._iVisualizacion = -1, DBNull.Value, Me._iVisualizacion))
                cmd.Parameters.AddWithValue("IDCON1", IIf(Me._iIdConcepto1 = 0, DBNull.Value, Me._iIdConcepto1))
                cmd.Parameters.AddWithValue("IDCON2", IIf(Me._iIdConcepto2 = 0, DBNull.Value, Me._iIdConcepto2))
            End If
            If (c.Update(cmd) = False) Then
                MsgBox(c.msgError)
            End If
            c.Close()
        End If
    End Function
    Public Function Update() As Boolean
        Dim cmd As New SqlCommand()
        Dim c As New ACCESO.Conexion
        If (c.Connect) Then
            If Me._idPEstructura <> 0 Then
                cmd.CommandText = "UPDATE Estructura_Padre SET iIdConcepto=@IDCON, idPEstructura=@IDPCON, " _
                & " iIdTipoEstructura=@IDTIPO,ccondicion=@COND,tvisualizacion=@VIS,iIdConcepto1=@IDCON1,iIdConcepto2=@IDCON2" _
                & "  WHERE idEstructura=@IDES"

                cmd.Parameters.AddWithValue("@IDES", Me._IdEstructura)
                cmd.Parameters.AddWithValue("@IDCON", Me._iIdConcepto)
                cmd.Parameters.AddWithValue("@IDPCON", Me._idPEstructura)
                cmd.Parameters.AddWithValue("@IDTIPO", Me._iIdTipoEstructura)
                cmd.Parameters.AddWithValue("@COND", IIf(Me._ccondicion.ToString = "", DBNull.Value, Me._ccondicion))
                cmd.Parameters.AddWithValue("@VIS", IIf(Me._iVisualizacion = -1, DBNull.Value, Me._iVisualizacion))
                cmd.Parameters.AddWithValue("IDCON1", IIf(Me._iIdConcepto1 = 0, DBNull.Value, Me._iIdConcepto1))
                cmd.Parameters.AddWithValue("IDCON2", IIf(Me._iIdConcepto2 = 0, DBNull.Value, Me._iIdConcepto2))
                c.Update(cmd)
                c.Close()
            Else
                cmd.CommandText = "UPDATE Estructura_Padre SET iIdConcepto=@IDCON, idPEstructura=NULL, " _
                & " iIdTipoEstructura=@IDTIPO,ccondicion=@COND,tvisualizacion=@VIS,iIdConcepto1=@IDCON1,iIdConcepto2=@IDCON2" _
                & "  WHERE IdEstructura=@IDES"

                cmd.Parameters.AddWithValue("@IDES", Me._IdEstructura)
                cmd.Parameters.AddWithValue("@IDCON", Me._iIdConcepto)
                cmd.Parameters.AddWithValue("@IDTIPO", Me._iIdTipoEstructura)
                cmd.Parameters.AddWithValue("@COND", IIf(Me._ccondicion.ToString = "", DBNull.Value, Me._ccondicion))
                cmd.Parameters.AddWithValue("@VIS", IIf(Me._iVisualizacion = -1, DBNull.Value, Me._iVisualizacion))
                cmd.Parameters.AddWithValue("IDCON1", IIf(Me._iIdConcepto1 = 0, DBNull.Value, Me._iIdConcepto1))
                cmd.Parameters.AddWithValue("IDCON2", IIf(Me._iIdConcepto2 = 0, DBNull.Value, Me._iIdConcepto2))
                c.Update(cmd)
                c.Close()
            End If
        End If
    End Function

    Public Shared Function List(Optional ByVal condicion As String = "", Optional ByVal order As String = "") As DataTable
        Dim dt As New DataTable
        Dim c As New ACCESO.Conexion
        If (c.Connect) Then
            dt = c.Query("SELECT * FROM dbo.view_Estructura " & condicion & order)
            c.Close()
        End If
        Return dt

    End Function

    Public Shared Function DevuelveConcepto1(ByVal condicion As String)
        Dim dt As New DataTable
        Dim Idcon1 As Integer
        Dim c As New ACCESO.Conexion
        If (c.Connect) Then
            dt = c.Query("SELECT ISNULL(iIdConcepto1,0) FROM dbo.Estructura_Padre WHERE idEstructura=" & condicion)
            If dt.Rows.Count > 0 Then
                Idcon1 = dt.Rows(0).Item(0)
            Else
                Idcon1 = 0
            End If
            c.Close()
        End If
        Return Idcon1
    End Function
    Public Shared Function DevuelveConcepto2(ByVal condicion As String)
        Dim dt As New DataTable
        Dim Idcon1 As Integer
        Dim c As New ACCESO.Conexion
        If (c.Connect) Then
            dt = c.Query("SELECT ISNULL(iIdConcepto2,0) FROM dbo.Estructura_Padre WHERE idEstructura=" & condicion)
            If dt.Rows.Count > 0 Then
                Idcon1 = dt.Rows(0).Item(0)
            Else
                Idcon1 = 0
            End If
            c.Close()
        End If
        Return Idcon1
    End Function
    Public Shared Sub GeneraTree(ByRef trv As TreeView, Optional ByVal Tipo As Integer = 5)
        Dim c As New ACCESO.Conexion
        Dim dt As New DataTable
        Dim dt2 As New DataTable
        Dim tn As New TreeNode
        Dim tn2 As New TreeNode
        Dim tipp As String = ""

        trv.Nodes.Clear()
        tn = New TreeNode("ESTRUCTURA DEL TABLERO")
        tn.Tag = 0
        tn.Name = 0
        trv.Nodes.Add(tn)

        If (c.Connect) Then
            'dt = c.Query("SELECT     dbo.Estructura_Padre.iIdConcepto, dbo.Estructura_Padre.idPEstructura, dbo.EstructuraSMA.IdEstructura, dbo.EstructuraSMA.iIdAA, dbo.Conceptos.vDescripcion FROM         dbo.Conceptos INNER JOIN dbo.Estructura_Padre ON dbo.Conceptos.iIdConcepto = dbo.Estructura_Padre.iIdConcepto INNER JOIN dbo.EstructuraSMA ON dbo.Estructura_Padre.idEstructura = dbo.EstructuraSMA.idEstructura WHERE     (dbo.Estructura_Padre.idPEstructura IS NULL)")
            dt = c.Query("SELECT     dbo.Estructura_Padre.iIdConcepto, dbo.Estructura_Padre.idPEstructura, dbo.Conceptos.vDescripcion,dbo.Estructura_Padre.idEstructura FROM         dbo.Conceptos INNER JOIN dbo.Estructura_Padre ON dbo.Conceptos.iIdConcepto = dbo.Estructura_Padre.iIdConcepto WHERE     (dbo.Estructura_Padre.idPEstructura IS NULL)")

            For Each MiDataRow As DataRow In dt.Rows
                tn2 = New TreeNode(MiDataRow(2))
                tn2.Name = MiDataRow(3).ToString 'id estructura
                tn2.ToolTipText = MiDataRow(0).ToString 'idconcepto
                TreeDetalles(tn2, MiDataRow(3).ToString, c, Tipo)
                tn.Nodes.Add(tn2)

            Next
            c.Close()
        End If
    End Sub
    Private Shared Sub TreeDetalles(ByRef tn As TreeNode, ByVal id As String, ByVal c As ACCESO.Conexion, ByVal tipo As Integer)
        Dim dt As New DataTable
        Dim childnode As New TreeNode
        tn.Tag = id
        tn.Name = id
        'dt = c.Query("SELECT     dbo.Estructura_Padre.iIdConcepto, dbo.Estructura_Padre.idPEstructura, dbo.EstructuraSMA.IdEstructura, dbo.EstructuraSMA.iIdAA, dbo.Conceptos.vDescripcion FROM  dbo.Conceptos INNER JOIN  dbo.Estructura_Padre ON dbo.Conceptos.iIdConcepto = dbo.Estructura_Padre.iIdConcepto INNER JOIN dbo.EstructuraSMA ON dbo.Estructura_Padre.idEstructura = dbo.EstructuraSMA.idEstructura WHERE     (dbo.Estructura_Padre.idPEstructura = " & id & ") AND (dbo.Estructura_Padre.iIdTipoEstructura <= " & tipo & ")")
        dt = c.Query("SELECT     dbo.Estructura_Padre.iIdConcepto, dbo.Estructura_Padre.idPEstructura, dbo.Conceptos.vDescripcion,dbo.Estructura_Padre.idEstructura FROM  dbo.Conceptos INNER JOIN  dbo.Estructura_Padre ON dbo.Conceptos.iIdConcepto = dbo.Estructura_Padre.iIdConcepto  WHERE     (dbo.Estructura_Padre.idPEstructura = " & id & ") AND (dbo.Estructura_Padre.iIdTipoEstructura <= " & tipo & ")")
        If (dt.Rows.Count > 0) Then
            For Each MiDataRow As DataRow In dt.Rows
                childnode = New TreeNode(MiDataRow(2))
                childnode.Name = MiDataRow(3).ToString  '1
                childnode.ToolTipText = MiDataRow(0).ToString
                TreeDetalles(childnode, MiDataRow(3).ToString, c, tipo) '0
                tn.Nodes.Add(childnode)
            Next
        End If
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

    Public Shared Sub EnsureNodeIsVisible(ByVal node As TreeNode)
        '' espande elarbol como estaba cuando se seleciono el nodo
        Dim tvw As TreeView = node.TreeView
        tvw.SelectedNode = node
        ' expand this node and all its ancestors
        Do Until node.Parent Is Nothing
            node = node.Parent
            node.Expand()
        Loop
        tvw.SelectedNode.EnsureVisible()
    End Sub

    Public Shared Sub MoverEstructura(ByVal idEstructura As Integer, ByVal tipoEstructura As String, ByVal idPEstructura As Integer)
        Dim cmd As New SqlCommand()
        Dim c As New ACCESO.Conexion
        If (c.Connect) Then
            Select Case tipoEstructura
                Case 1
                    cmd.CommandText = "update Estructura_Padre set iIdTipoEstructura=@IDTIPO,idPEstructura=@IDPCON where idEstructura='" & idEstructura & "'"
                    cmd.Parameters.AddWithValue("@IDTIPO", tipoEstructura)
                    cmd.Parameters.AddWithValue("@IDPCON", DBNull.Value)
                Case Else
                    cmd.CommandText = "update Estructura_Padre set iIdTipoEstructura=@IDTIPO,idPEstructura=@IDPCON where idEstructura='" & idEstructura & "'"
                    cmd.Parameters.AddWithValue("@IDTIPO", tipoEstructura)
                    cmd.Parameters.AddWithValue("@IDPCON", idPEstructura)
            End Select
            c.Update(cmd)
            'Dim orden As Integer = getOrdenTipoCanal(idtipo, escanal)
            'recalcularNodos(idcanal, orden, escanal, c)
            c.Close()
        End If
    End Sub

End Class

