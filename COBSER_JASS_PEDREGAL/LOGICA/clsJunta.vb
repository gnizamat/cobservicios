Imports System.Data.SqlClient
Imports System.Windows.Forms
Public Class clsJunta
    Private _id As String
    Private _idRegion As Integer
    Private _idDisRiego As String
    Private _nombre As String
    Private _estado As Boolean
    Public Property id()
        Get
            Return Me._id
        End Get
        Set(ByVal value)
            Me._id = value
        End Set
    End Property
    Public Property idRegion()
        Get
            Return Me._idRegion
        End Get
        Set(ByVal value)
            Me._idRegion = value
        End Set
    End Property
    Public Property nombre()
        Get
            Return Me._nombre
        End Get
        Set(ByVal value)
            Me._nombre = value
        End Set
    End Property
    Public Property idDisRiego()
        Get
            Return Me._idDisRiego
        End Get
        Set(ByVal value)
            Me._idDisRiego = value
        End Set
    End Property
    Public Sub New()
        'ningun parametro
    End Sub
    Public Sub New(ByVal idr As Integer, ByVal idd As Integer, ByVal nom As String)
        Me._idRegion = idr
        Me._idDisRiego = idd
        Me._nombre = nom
    End Sub
    Private Function NewId()
        Dim c As New ACCESO.Conexion
        Dim dt As New DataTable
        Dim id As Integer
        If (c.Connect) Then
            dt = c.Query("Select ISNULL(Max(vIdJuntaUsuario),0) From JuntaUsuario")
            id = dt.Rows(0).Item(0) + 1
            c.Close()
        End If
        Return id
    End Function
    Public Sub Insert()
        Dim cmd As New SqlCommand()
        Dim c As New ACCESO.Conexion
        Me._id = NewId()
        If (c.Connect) Then
            cmd.CommandText = "INSERT INTO JuntaUsuario(vIdJuntaUsuario,iIdDistritoRiego,vNombre) values(@ID,@IDDISRIEGO,@NOMBRE)"
            cmd.Parameters.AddWithValue("@ID", Me._id)
            cmd.Parameters.AddWithValue("@IDDISRIEGO", Me._idDisRiego)
            cmd.Parameters.AddWithValue("@NOMBRE", Me._nombre)
            If (c.Insert(cmd) = False) Then
                MsgBox(c.msgError)
            End If
            c.Close()
        End If
    End Sub
    Public Sub Update()
        Dim cmd As New SqlCommand()
        Dim c As New ACCESO.Conexion
        If (c.Connect) Then
            cmd.CommandText = "update JuntaUsuario set iIdDistritoRiego=@IDDISRIEGO,vNombre=@NOMBRE where vIdJuntaUsuario='" & Me.id & "'"
            cmd.Parameters.AddWithValue("@IDDISRIEGO", Me._idDisRiego)
            cmd.Parameters.AddWithValue("@NOMBRE", Me._nombre)
            c.Update(cmd)
            c.Close()
        End If

    End Sub
    Public Shared Sub delete(ByVal id)
        Dim c As New ACCESO.Conexion
        If (c.Connect) Then
            If (c.Delete("delete from JuntaUsuario where vIdJuntaUsuario='" & id & "'")) Then
            Else
                MsgBox(c.msgError)
            End If
            c.Close()
        End If
    End Sub
    Public Shared Function List(Optional ByVal condicion As String = "", Optional ByVal order As String = " order by j.vNombre asc") As DataTable
        Dim dt As New DataTable
        Dim c As New ACCESO.Conexion
        If (c.Connect) Then
            dt = c.Query("select j.vIdJuntaUsuario,j.vNombre,j.iIdDistritoRiego,d.vNombre from JuntaUsuario j,DistritoRiego d where d.iIdDistritoRiego=j.iIdDistritoRiego " & condicion & order)
            c.Close()
        End If
        Return dt
    End Function
    Public Shared Function LoadJunta(ByVal id As String) As clsJunta
        Dim c As New ACCESO.Conexion
        Dim dt As New DataTable
        Dim obj As New clsJunta
        If (c.Connect) Then
            dt = c.Query("select j.vIdJuntaUsuario,j.vNombre,j.iIdDistritoRiego,d.iIdRegion from JuntaUsuario j,DistritoRiego d where  vIdJuntaUsuario='" & id & "' and d.iIdDistritoRiego=j.iIdDistritoRiego")
            For Each MiDataRow As DataRow In dt.Rows
                obj.id = MiDataRow(0)
                obj.nombre = MiDataRow(1)
                obj.idDisRiego = MiDataRow(2)
                obj.idRegion = MiDataRow(3)
            Next
            c.Close()
        End If
        Return obj
    End Function
    Public Shared Sub GeneraTree(ByRef trv As TreeView, Optional ByVal condicion As String = "")
        Dim c As New ACCESO.Conexion
        Dim dt As New DataTable
        Dim dt2 As New DataTable
        Dim tn As New TreeNode
        Dim tn2 As New TreeNode
        dt = clsJunta.List(condicion)
        If (c.Connect) Then
            For Each MiDataRow As DataRow In dt.Rows
                tn = New TreeNode(MiDataRow(1))
                trv.Nodes.Add(tn)
                tn.Tag = "J-" & MiDataRow(0)
                tn.Name = MiDataRow(1)
            Next
            c.Close()
        End If
    End Sub
    Public Shared Sub GeneraTreeJuntaComision(ByRef trv As TreeView)
        Dim c As New ACCESO.Conexion
        Dim dt As New DataTable
        Dim dt2 As New DataTable
        Dim tn As New TreeNode
        Dim tn2 As New TreeNode
        dt = clsJunta.List
        If (c.Connect) Then
            For Each MiDataRow As DataRow In dt.Rows
                tn = New TreeNode("[JU] " & MiDataRow(1))
                trv.Nodes.Add(tn)
                tn.Tag = "J-" & MiDataRow(0)
                tn.Name = MiDataRow(1)
                dt2 = clsComisionRegante.List(" and c.vIdJuntaUsuario='" & MiDataRow(0) & "'")
                For Each MiDataRow2 As DataRow In dt2.Rows
                    tn2 = New TreeNode(MiDataRow2(1))
                    tn2.Tag = "C-" & MiDataRow2(0)
                    tn2.Name = "C-" & MiDataRow2(0)
                    tn.Nodes.Add(tn2)
                Next

            Next
            c.Close()
        End If
    End Sub
    Public Shared Sub LoadCombo(ByRef cmb As Windows.Forms.ComboBox, Optional ByVal condicion As String = "", Optional ByVal order As String = " order by vNombre", Optional ByVal SelectionStart As Integer = -1)
        Dim c As New ACCESO.Conexion
        Dim dt As New DataTable
        If (c.Connect()) Then
            dt = c.Query("select vIdJuntaUsuario,vNombre from JuntaUsuario " & condicion & " " & order)
            cmb.DataSource = dt
            cmb.ValueMember = dt.Columns(0).ToString()
            cmb.DisplayMember = dt.Columns(1).ToString()
            If (SelectionStart <> -1) Then
                cmb.SelectionStart = SelectionStart
            End If
            c.Close()
        End If
    End Sub
    Public Shared Sub BuscarJunta(ByRef Tv As TreeView, ByVal texto As String, ByVal sMayMin As Boolean)
        With Tv
            ' Indicar la clave a buscar , el tipo de búsqueda   
            ' ( Si se encuentra retorna una matriz de nodos )   
            Dim ret As TreeNode() = .Nodes.Find(texto, True)
            If ret.Length = 0 Then
                MsgBox("No se encontró", MsgBoxStyle.Information)
            Else
                ' seleccionar el nodo   
                .SelectedNode = ret(0)
                .SelectedNode.Expand() ' expandir 
                .Focus()

            End If
        End With


    End Sub
End Class
