Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports ACCESO
Public Class clsCentroPoblado
    Private _idCP As Integer
    Private _idDistrito As Integer
    Private _vNombre As String
    Public Shared Sub LoadCombo(ByRef cmb As Windows.Forms.ComboBox, Optional ByVal condicion As String = "")
        Try
            Dim c As New ACCESO.Conexion
            If (c.Connect()) Then
                Dim dt = c.Query("SELECT idCP,vNombre FROM CentroPoblado " & condicion & " order by vNombre asc")
                cmb.DataSource = dt
                cmb.ValueMember = dt.Columns(0).ToString()
                cmb.DisplayMember = dt.Columns(1).ToString()
                cmb.Text = ""
                cmb.SelectedIndex = 0
                c.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Shared Sub LoadComboADD(ByRef cmb As Windows.Forms.ComboBox, Optional ByVal condicion As String = "", Optional ByVal all As Boolean = True)
        Dim c As New ACCESO.Conexion
        If (c.Connect()) Then
            Dim dt = c.Query("SELECT idCP,vNombre FROM CentroPoblado " & condicion & " order by vNombre asc")
            If (all And dt.Rows.Count > 0) Then
                dt.Rows.Add(0, "[Todas los CP]")
            End If
            cmb.DataSource = dt
            cmb.ValueMember = dt.Columns(0).ToString()
            cmb.DisplayMember = dt.Columns(1).ToString()
            cmb.Text = ""
            'cmb.SelectedIndex = 0
            cmb.SelectedIndex = -1
            c.Close()
        End If
    End Sub
End Class
