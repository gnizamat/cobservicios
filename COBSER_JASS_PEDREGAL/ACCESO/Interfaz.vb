Imports System.Windows.Forms
Imports System.Data.SqlClient
Public Class Interfaz

    Public Shared Sub LoadCombo(ByRef cmb As Windows.Forms.ComboBox, Optional ByVal all As Boolean = False)
        Dim dt As New DataTable
        dt.Columns.Add("id")
        dt.Columns.Add("nombre")
        If (all) Then
            dt.Rows.Add(1, "TODOS")
        End If
        dt.Rows.Add(2, "AUTORIDAD LOCAL DEL AGUA")
        dt.Rows.Add(3, "JUNTA DE USUARIOS")
        dt.Rows.Add(4, "COMISION DE USUARIOS")
        cmb.DataSource = dt
        cmb.ValueMember = dt.Columns(0).ToString()
        cmb.DisplayMember = dt.Columns(1).ToString()
        cmb.SelectedIndex = -1
    End Sub

    Public Shared Sub GeneraTreePermisos(ByRef trv As TreeView, ByVal idinterfaz As Integer)
        Dim c As New ACCESO.Conexion

        Dim dt As New DataTable
        Dim dt2 As New DataTable
        Dim tn As New TreeNode
        If (c.Connect) Then
            dt = c.Query("select m.idMenu,m.idPMenu,m.vNombre from sysMenu m where m.idPMenu=0 order by m.iOrden asc")
            For Each MiDataRow As DataRow In dt.Rows
                dt2 = c.Query("select idMenu from sysPermiso where idGrupo='" & idinterfaz & "' and idMenu='" & MiDataRow(0) & "'")
                tn = New TreeNode(MiDataRow(2))
                trv.Nodes.Add(tn)
                tn.Tag = MiDataRow(0)
                If (dt2.Rows.Count > 0) Then
                    tn.Checked = True
                End If
                treePermisos(tn, MiDataRow(0), idinterfaz, c)
            Next
            c.Close()
        End If
    End Sub
    Private Shared Sub treePermisos(ByRef tn As TreeNode, ByVal id As String, ByVal idinterfaz As String, ByVal c As ACCESO.Conexion)
        Dim dt As New DataTable
        Dim dt2 As New DataTable
        Dim childnode As New TreeNode
        dt = c.Query("select m.idMenu,m.idPMenu,m.vNombre from sysMenu m where m.idPMenu='" & id & "' order by m.iOrden asc")
        If (dt.Rows.Count > 0) Then
            For Each MiDataRow As DataRow In dt.Rows
                dt2 = c.Query("select idMenu from sysPermiso where idGrupo='" & idinterfaz & "' and idMenu='" & MiDataRow(0) & "'")
                childnode = New TreeNode(MiDataRow(2))
                tn.Nodes.Add(childnode)
                childnode.Tag = MiDataRow(0)
                If (dt2.Rows.Count > 0) Then
                    childnode.Checked = True
                End If
                treePermisos(childnode, MiDataRow(0), idinterfaz, c)
            Next
        End If

    End Sub
    Public Shared Sub SavePermisosGrupo(ByVal tv As TreeView, ByVal idgrupo As String)
        removePermisos(idgrupo)
        savePermisos(tv.Nodes, idgrupo)
    End Sub
    Private Shared Sub savePermisos(ByRef Nodos As TreeNodeCollection, ByVal idgrupo As Integer)
        For Each Nodo As TreeNode In Nodos
            If Nodo.Nodes.Count > 0 Then
                savePermisos(Nodo.Nodes, idgrupo)
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
End Class
