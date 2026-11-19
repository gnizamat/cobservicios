Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports ACCESO
Public Class clsMes
    Private _idMes As Integer
    Private _vNombre As String
    Private _cEstado As String


    Public Shared Sub LoadCombo(ByRef cmb As Windows.Forms.ComboBox, Optional ByVal condicion As String = "")
        Dim c As New ACCESO.Conexion
        If (c.Connect()) Then
            Dim dt = c.Query("SELECT idMes,Mes FROM tarMes " & condicion & " order by idMes asc")
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
            dt = c.Query("SELECT * FROM tarMes " & condicion)
            c.Close()
        End If
        Return dt
    End Function
End Class
