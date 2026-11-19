Imports System.Windows.Forms
Imports System.Data.SqlClient
Public Class Grupo
    Private _idPGrupo As Integer
    Private _idGrupo As Integer
    Private _nombre As String
    Private _idRegion As Integer
    Private _idDistritoRiego As Integer
    Private _idJunta As String
    Private _idComision As Integer
   
    Public Property idRegion()
        Get
            Return Me._idRegion
        End Get
        Set(ByVal value)
            Me._idRegion = value
        End Set
    End Property
    Public Property idDistritoRiego()
        Get
            Return Me._idDistritoRiego
        End Get
        Set(ByVal value)
            Me._idDistritoRiego = value
        End Set
    End Property
    Public Property idJunta()
        Get
            Return Me._idJunta
        End Get
        Set(ByVal value)
            Me._idJunta = value
        End Set
    End Property
    Public Property idComision()
        Get
            Return Me._idComision
        End Get
        Set(ByVal value)
            Me._idComision = value
        End Set
    End Property
    Sub New(Optional ByVal n As String = "")
        Me._nombre = n
    End Sub
    Sub New(ByVal nombre As String, ByVal idinterfaz As String, Optional ByVal idregion As String = "", Optional ByVal iddistrito As String = "", Optional ByVal idjunta As String = "", Optional ByVal idcomision As String = "")
        Me._idPGrupo = idinterfaz
        Me._nombre = nombre
        Me._idRegion = idregion
        Me._idDistritoRiego = iddistrito
        Me._idJunta = idjunta
        Me._idComision = idcomision
    End Sub
    Public Property nombre()
        Get
            Return Me._nombre
        End Get
        Set(ByVal value)
            Me._nombre = value
        End Set
    End Property
    Public Property idGrupo()
        Get
            Return Me._idGrupo
        End Get
        Set(ByVal value)
            Me._idGrupo = value
        End Set
    End Property
    Private Function NewId()
        Dim c As New ACCESO.Conexion
        Dim dt As New DataTable
        Dim id As Integer
        If (c.Connect) Then
            dt = c.Query("select isNull(max(idGrupo),0) from sysGrupo")
            c.Close()
            id = dt.Rows(0).Item(0) + 1
        End If
        Return id
    End Function
    Public Function Insert() As Boolean
        Dim cmd As New SqlCommand()
        Dim c As New ACCESO.Conexion
        Me._idGrupo = Me.NewId
        If (c.Connect) Then
            cmd.CommandText = "INSERT INTO sysGrupo(idGrupo,idPGrupo,vNombre,cEstado,iIdRegion,iIdDistritoRiego,vIdJuntaUsuario,iIdComisionRegante) values(@ID,@PADRE,@NOMBRE,1,@IDREGION,@IDDISTRITO,@IDJUNTA,@IDCOMISION)"
            cmd.Parameters.AddWithValue("@ID", Me._idGrupo)
            cmd.Parameters.AddWithValue("@PADRE", Me._idPGrupo)
            cmd.Parameters.AddWithValue("@NOMBRE", Me._nombre)
            cmd.Parameters.AddWithValue("@IDREGION", Me._idRegion)
            cmd.Parameters.AddWithValue("@IDDISTRITO", Me._idDistritoRiego)
            cmd.Parameters.AddWithValue("@IDJUNTA", Me._idJunta)
            cmd.Parameters.AddWithValue("@IDCOMISION", Me._idComision)

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
            cmd.CommandText = "update sysGrupo set  idPGrupo=@PADRE,vNombre=@NOMBRE,iIdRegion=@IDREGION,iIdDistritoRiego=@IDDISTRITO,vIdJuntaUsuario=@IDJUNTA,iIdComisionRegante=@IDCOMISION where idGrupo='" & Me._idGrupo & "'"
            cmd.Parameters.AddWithValue("@PADRE", Me._idPGrupo)
            cmd.Parameters.AddWithValue("@NOMBRE", Me._nombre)
            cmd.Parameters.AddWithValue("@IDREGION", Me._idRegion)
            cmd.Parameters.AddWithValue("@IDDISTRITO", Me._idDistritoRiego)
            cmd.Parameters.AddWithValue("@IDJUNTA", Me._idJunta)
            cmd.Parameters.AddWithValue("@IDCOMISION", Me._idComision)
            c.Update(cmd)
            c.Close()
        End If
    End Function
    Public Function getNroUsuarios() As Integer
        Dim dt As New DataTable
        Dim c As New ACCESO.Conexion
        If (c.Connect) Then
            dt = c.Query("select * from sysUsuario where cEstado=1 and idGrupo='" & Me._idGrupo & "'")
            c.Close()
        End If
        Return dt.Rows.Count
    End Function
    Public Shared Function List(Optional ByVal condicion As String = "") As DataTable
        Dim dt As New DataTable
        Try
            Dim c As New ACCESO.Conexion
            If (c.Connect) Then
                dt = c.Query("select g.idGrupo,g.idPGrupo,g.vNombre,(select p.vNombre from sysGrupo p where p.idGrupo=g.idPGrupo) as 'Interfaz',(select count(*) from sysUsuario u where u.idGrupo=g.idGrupo ) as 'NroUsuarios',g.iIdRegion,(select vNombre from Region r where r.iIdRegion=g.iIdRegion ) as 'Region',iIdDistritoRiego,(select vNombre from DistritoRiego d where d.iIdDistritoRiego=g.iIdDistritoRiego) as Ditrito,vIdJuntaUsuario,(select j.vNombre from JuntaUsuario j where j.vIdJuntaUsuario=g.vIdJuntaUsuario) as Junta,iIdComisionRegante,(select cr.vNombre from ComisionRegante cr where cr.iIdComisionRegante=g.iIdComisionRegante and cr.vIdJuntaUsuario=g.vIdJuntaUsuario) as comision from sysGrupo g where cEstado=1 " & condicion)
                c.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return dt
    End Function
    Public Shared Sub LoadCombo(ByRef cmb As Windows.Forms.ComboBox, ByVal condicion As String)
        Dim c As New ACCESO.Conexion
        If (c.Connect()) Then
            Dim dt = Grupo.List(condicion)
            cmb.DataSource = dt
            cmb.ValueMember = dt.Columns(0).ToString()
            cmb.DisplayMember = dt.Columns(2).ToString()
            cmb.Text = ""
            cmb.SelectedIndex = -1
            c.Close()
        End If
    End Sub
    Public Shared Sub Delete(ByVal id As Integer)
        Dim cmd As New SqlCommand()
        Dim c As New ACCESO.Conexion
        If (c.Connect) Then
            cmd.CommandText = "update sysGrupo set cEstado=0 where idGrupo='" & id & "'"
            c.Update(cmd)
            c.Query("update sysUsuario set cEstado=0 where idGrupo='" & id & "'")
            c.Close()
        End If
    End Sub


    Public Shared Sub GeneraTreePermisos(ByRef trv As TreeView, ByVal idinterfaz As Integer, ByVal idgrupo As Integer)
        Dim c As New ACCESO.Conexion

        Dim dt As New DataTable
        Dim dt2 As New DataTable
        Dim tn As New TreeNode
        If (c.Connect) Then
            dt = c.Query("select m.idMenu,m.idPMenu,m.vNombre from sysPermiso p,sysMenu m where m.idMenu=p.idMenu and m.idPMenu=0 and p.idGrupo='" & idinterfaz & "'")
            For Each MiDataRow As DataRow In dt.Rows
                dt2 = c.Query("select idMenu from sysPermiso where idGrupo='" & idgrupo & "' and idMenu='" & MiDataRow(0) & "'")
                tn = New TreeNode(MiDataRow(2))
                trv.Nodes.Add(tn)
                tn.Tag = MiDataRow(0)
                If (dt2.Rows.Count > 0) Then
                    tn.Checked = True
                End If
                treePermisos(tn, MiDataRow(0), idinterfaz, idgrupo, c)
            Next
            c.Close()
        End If
    End Sub
    Private Shared Sub treePermisos(ByRef tn As TreeNode, ByVal id As String, ByVal idinterfaz As String, ByVal idgrupo As String, ByVal c As ACCESO.Conexion)
        Dim dt As New DataTable
        Dim dt2 As New DataTable
        Dim childnode As New TreeNode
        dt = c.Query("select m.idMenu,m.idPMenu,m.vNombre from sysPermiso p,sysMenu m where m.idMenu=p.idMenu and m.idPMenu='" & id & "' and p.idGrupo='" & idinterfaz & "'")
        If (dt.Rows.Count > 0) Then
            For Each MiDataRow As DataRow In dt.Rows
                dt2 = c.Query("select idMenu from sysPermiso where idGrupo='" & idgrupo & "' and idMenu='" & MiDataRow(0) & "'")
                childnode = New TreeNode(MiDataRow(2))
                tn.Nodes.Add(childnode)
                childnode.Tag = MiDataRow(0)
                If (dt2.Rows.Count > 0) Then
                    childnode.Checked = True
                End If
                treePermisos(childnode, MiDataRow(0), idinterfaz, idgrupo, c)
            Next
        End If

    End Sub
    Public Shared Sub SavePermisosGrupo(ByVal tv As TreeView, ByVal idgrupo As String)
        removePermisos(idgrupo)
        SavePermisos(tv.Nodes, idgrupo)
    End Sub
    Private Shared Sub savePermisos(ByRef Nodos As TreeNodeCollection, ByVal idgrupo As Integer)
        For Each Nodo As TreeNode In Nodos
            If Nodo.Nodes.Count > 0 Then
                SavePermisos(Nodo.Nodes, idgrupo)
            End If
            If (Nodo.Checked) Then
                insertPermisos(Nodo.Tag, idgrupo)
            End If
        Next
    End Sub
    Private Shared Sub removePermisos(ByVal id)
        Dim cmd As New SqlCommand()
        Dim c As New ACCESO.Conexion
        If (c.Connect) Then
            cmd.CommandText = "delete from sysPermiso  where idGrupo='" & id & "'"
            c.Update(cmd)
            c.Close()
        End If
    End Sub
    Private Shared Sub insertPermisos(ByVal idmenu, ByVal idgrupo)
        Dim cmd As New SqlCommand()
        Dim c As New ACCESO.Conexion
        If (c.Connect) Then
            cmd.CommandText = "INSERT INTO sysPermiso(idMenu,idGrupo) values(@IDMENU,@IDGRUPO)"
            cmd.Parameters.AddWithValue("@IDMENU", idmenu)
            cmd.Parameters.AddWithValue("@IDGRUPO", idgrupo)
            If (c.Insert(cmd) = False) Then
                MsgBox(c.msgError)
            End If
            c.Close()
        End If
    End Sub
    Public Shared Function load(ByVal id) As Grupo
        Dim c As New ACCESO.Conexion
        Dim dt As New DataTable
        Dim obj As New Grupo
        If (c.Connect) Then
            dt = Grupo.List(" and g.idGrupo='" & id & "'")
            For Each MiDataRow As DataRow In dt.Rows
                obj._idGrupo = MiDataRow(0)
                obj._idPGrupo = MiDataRow(1).ToString
                obj.nombre = MiDataRow(2)
                obj._idRegion = Val(MiDataRow(5).ToString)
                obj._idDistritoRiego = Val(MiDataRow(7).ToString)
                obj._idJunta = MiDataRow(9).ToString
                obj._idComision = Val(MiDataRow(11).ToString)

            Next
            c.Close()
        End If
        Return obj
    End Function

    Public Sub INSERTALL_PERMISOS()
        Dim c As New ACCESO.Conexion
        Dim dt As New DataTable
        If (c.Connect) Then
            dt = c.Query("select idMenu from sysPermiso where idGrupo='" & Me._idPGrupo & "'")
            For Each MiDataRow As DataRow In dt.Rows
                insertPermisos(MiDataRow(0), Me._idGrupo)
            Next
        End If
    End Sub
End Class
