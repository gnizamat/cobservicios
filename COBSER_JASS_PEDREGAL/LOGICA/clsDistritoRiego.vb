Imports System.Data.SqlClient
Imports System.Windows.Forms
Public Class clsDistritoRiego
    Private id As Integer
    Private nombre As String
    Public Shared Sub LoadCombo(ByRef cmb As Windows.Forms.ComboBox, Optional ByVal condicion As String = "")
        Dim c As New ACCESO.Conexion
        If (c.Connect()) Then
            Dim dt = c.Query("SELECT iIdDistritoRiego,vNombre FROM DistritoRiego " & condicion & " order by vNombre asc")
            cmb.DataSource = dt
            cmb.ValueMember = dt.Columns(0).ToString()
            cmb.DisplayMember = dt.Columns(1).ToString()
            cmb.Text = ""
            cmb.SelectedIndex = -1
            c.Close()
        End If
    End Sub
    Public Shared Function List(Optional ByVal condicion As String = "") As DataTable
        Dim dt As New DataTable
        Dim c As New ACCESO.Conexion
        If (c.Connect) Then
            dt = c.Query("SELECT iIdDistritoRiego,vNombre FROM DistritoRiego " & condicion & " order by vNombre")
            c.Close()
        End If
        Return dt
    End Function
    Public Shared Sub GeneraTree(ByRef trv As TreeView, Optional ByVal condicion1 As String = "", Optional ByVal condicion2 As String = "")
        Dim c As New ACCESO.Conexion
        Dim dt As New DataTable
        Dim dt2 As New DataTable
        Dim tn As New TreeNode
        Dim tn2 As New TreeNode
        dt = clsDistritoRiego.List(condicion1)
        If (c.Connect) Then
            For Each MiDataRow As DataRow In dt.Rows
                tn = New TreeNode(MiDataRow(1))
                trv.Nodes.Add(tn)
                tn.Tag = "D-" & MiDataRow(0)
                tn.Name = "D-" & MiDataRow(0)
                tn.ImageIndex = 0
                tn.SelectedImageIndex = 0
                dt2 = clsJunta.List(" and j.iIdDistritoRiego='" & MiDataRow(0) & "' " & condicion2)
                For Each MiDataRow2 As DataRow In dt2.Rows
                    tn2 = New TreeNode(MiDataRow2(1))
                    tn2.Tag = "J-" & MiDataRow2(0)
                    tn2.Name = MiDataRow2(1)
                    tn2.ImageIndex = 1
                    tn2.SelectedImageIndex = 1
                    tn.Nodes.Add(tn2)
                Next
            Next
            c.Close()
        End If
    End Sub
End Class
