Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports ACCESO
Public Class clsCalles

    Private _idCalle As Integer
    Private _idSector As Integer
    Private _vNombre As String
    Private _vReferencia As String
    Private _idtipocalle As Integer

    Private _cEstado As String
    Private _idCP As Integer
    Public Property idCalle()
        Get
            Return Me._idCalle
        End Get
        Set(ByVal value)
            Me._idCalle = value
        End Set
    End Property
    Public Property idSector()
        Get
            Return Me._idSector
        End Get
        Set(ByVal value)
            Me._idSector = value
        End Set
    End Property
    Public Property vNombre()
        Get
            Return Me._vNombre
        End Get
        Set(ByVal value)
            Me._vNombre = value
        End Set
    End Property
    Public Property vReferencia()
        Get
            Return Me._vReferencia
        End Get
        Set(ByVal value)
            Me._vReferencia = value
        End Set
    End Property
    Public Property idtipocalle()
        Get
            Return Me._idtipocalle
        End Get
        Set(ByVal value)
            Me._idtipocalle = value
        End Set
    End Property
    Public Property cEstado()
        Get
            Return Me._cEstado
        End Get
        Set(ByVal value)
            Me._cEstado = value
        End Set
    End Property

    Public Property idCP()
        Get
            Return Me._idCP
        End Get
        Set(ByVal value)
            Me._idCP = value
        End Set
    End Property
    Sub New(ByVal idcalle As Integer, ByVal idsector As Integer, ByVal nombre As String, ByVal referencia As String, ByVal idtipocalle As Integer, ByVal idcp As Integer)
        Me._idCalle = idcalle
        Me._idSector = idsector
        Me._vNombre = nombre
        Me._vReferencia = referencia
        Me._idtipocalle = idtipocalle
        Me._cEstado = "1"
        Me._idCP = idcp

    End Sub

    Public Shared Sub LoadCombo(ByRef cmb As Windows.Forms.ComboBox, Optional ByVal condicion As String = "")
        Dim c As New ACCESO.Conexion
        If (c.Connect()) Then
            Dim dt = c.Query("SELECT idCalle,vNombre FROM Calles " & condicion & " order by vNombre asc")
            cmb.DataSource = dt
            cmb.ValueMember = dt.Columns(0).ToString()
            cmb.DisplayMember = dt.Columns(1).ToString()
            cmb.Text = ""
            cmb.SelectedIndex = -1
            c.Close()
        End If
    End Sub
    Public Shared Sub LoadComboADD(ByRef cmb As Windows.Forms.ComboBox, Optional ByVal condicion As String = "", Optional ByVal all As Boolean = True)
        Dim c As New ACCESO.Conexion
        If (c.Connect()) Then
            Dim dt = c.Query("SELECT idCalle,vNombre FROM Calles " & condicion & " order by idCalle asc")
            If (all And dt.Rows.Count > 0) Then
                dt.Rows.Add(0, "[Todas las Calles]")
            End If
            cmb.DataSource = dt
            cmb.ValueMember = dt.Columns(0).ToString()
            cmb.DisplayMember = dt.Columns(1).ToString()
            cmb.Text = ""
            cmb.SelectedIndex = -1
            c.Close()
        End If
    End Sub
    Public Shared Sub LoadComboCallesPredio(ByRef cmb As Windows.Forms.ComboBox, Optional ByVal condicion As String = "", Optional ByVal all As Boolean = True)
        Dim c As New ACCESO.Conexion
        If (c.Connect()) Then
            Dim dt = c.Query("SELECT padPredio.idcalle, Calles.vNombre FROM padPredio INNER JOIN Calles ON padPredio.idcalle = Calles.idCalle " & condicion & " GROUP BY Calles.vNombre, padPredio.idcalle ORDER BY padPredio.idcalle")
            If (all And dt.Rows.Count > 0) Then
                dt.Rows.Add(0, "[Todas las Calles]")
            End If
            cmb.DataSource = dt
            cmb.ValueMember = dt.Columns(0).ToString()
            cmb.DisplayMember = dt.Columns(1).ToString()
            cmb.Text = ""
            cmb.SelectedValue = 0
            c.Close()
        End If
    End Sub
    Private Function NewId()
        Dim c As New ACCESO.Conexion
        Dim dt As New DataTable
        Dim id As Integer
        If (c.Connect) Then
            dt = c.Query("select isNull(max(idCalle),0) from Calles")
            c.Close()
            id = dt.Rows(0).Item(0) + 1
        End If
        Return id
    End Function
    Public Shared Function List(Optional ByVal condicion As String = "") As DataTable
        Dim dt As New DataTable
        Dim c As New ACCESO.Conexion
        If (c.Connect) Then
            dt = c.Query("SELECT * FROM Calles " & condicion)
            c.Close()
        End If
        Return dt
    End Function

    Public Function Insert() As Boolean
        Dim cmd As New SqlCommand()
        Dim c As New ACCESO.Conexion
        Me._idCalle = Me.NewId
        If (c.Connect) Then

            If (c.msgError = "") Then

                cmd.CommandText = "INSERT INTO Calles (idCalle,idSector,vNombre,vReferencia,idTipoCalle,cEstado,idCP)  VALUES (@IDCALLE,@IDSECTOR,@NOMBRE,@REFERENCIA,@TIPOCALLE,@ESTADO, @IDCP)"
                cmd.Parameters.AddWithValue("@IDCALLE", Me._idCalle)
                cmd.Parameters.AddWithValue("@IDSECTOR", Me._idSector)
                cmd.Parameters.AddWithValue("@NOMBRE", Me._vNombre)
                cmd.Parameters.AddWithValue("@REFERENCIA", Me._vReferencia)
                cmd.Parameters.AddWithValue("@TIPOCALLE", Me._idtipocalle)
                cmd.Parameters.AddWithValue("@ESTADO", Me._cEstado)
                cmd.Parameters.AddWithValue("@IDCP", Me._idCP)

                If (c.Update(cmd) = False) Then
                    MsgBox(c.msgError)
                Else
                    MsgBox("Calle Registrada correctamente", MsgBoxStyle.Information)
                End If
            Else
                MsgBox(c.msgError, MsgBoxStyle.Critical)
            End If


            c.Close()
        End If
    End Function

    Public Function Update() As Boolean
        Dim cmd As New SqlCommand()
        Dim c As New ACCESO.Conexion
        If (c.Connect) Then
            cmd.CommandText = "UPDATE Calles SET idCP= @IDCP,idSector=@IDSECTOR, vNombre=@NOMBRE, vReferencia=@REFERENCIA,idTipoCalle=@TIPOCALLE WHERE idCalle=" & idcalle & ""
            cmd.Parameters.AddWithValue("@IDCP", Me._idCP)
            cmd.Parameters.AddWithValue("@IDSECTOR", Me._idSector)
            cmd.Parameters.AddWithValue("@TIPOCALLE", Me._idtipocalle)
            cmd.Parameters.AddWithValue("@NOMBRE", Me._vNombre)
            cmd.Parameters.AddWithValue("@REFERENCIA", Me._vReferencia)
            cmd.Parameters.AddWithValue("@ESTADO", Me._cEstado)
            If (c.Update(cmd) = False) Then
                MsgBox(c.msgError)

            End If
            c.Close()
        End If
    End Function
    Public Shared Function delete(ByVal idcalle, ByVal idCP, ByVal idSector) As Boolean
        Dim c As New ACCESO.Conexion

        If (c.Connect) Then
            If (c.Delete("delete  from Calles  where idcalle=" & idcalle & "  and idCP= " & idCP & "  and idsector=" & idSector & "")) Then

                'MsgBox("No se puede elminar el registro porque existen datos vinculados al mismo", MsgBoxStyle.Critical)
                'c.Close()
                c.Close()
                Return False
            End If
            c.Close()
        End If
        Return True
    End Function

    Private Shared Sub treeCanales(ByRef tn As TreeNode, ByVal id As String, ByVal iscanal As Integer, ByVal c As ACCESO.Conexion)
        Dim dt As New DataTable
        Dim childnode As New TreeNode
        tn.Tag = "C-" & id
        tn.Name = "C-" & id
        dt = c.Query("select c.iIdCanalDren,c.vNombre,t.vNombre from invCanalDren c,invTipoCanalDren t where c.iIdPCanalDren=" & id & " and c.cEsCanal='" & iscanal & "' and t.iIdTipoCanalDren=c.iIdTipoCanalDren")
        If (dt.Rows.Count > 0) Then
            For Each MiDataRow As DataRow In dt.Rows
                childnode = New TreeNode("[" & MiDataRow(2) & "] " & MiDataRow(1))
                tn.Nodes.Add(childnode)
                childnode.Tag = "C-" & MiDataRow(0)
                treeCanales(childnode, MiDataRow(0), iscanal, c)
            Next
        End If
    End Sub
End Class
