Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports ACCESO
Public Class clsColaboradores
    Private _idResponsable As Integer
    Private _idArea As Integer
    Private _vNombre As String
    Private _cEstado As String


    Public Shared Sub LoadCombo(ByRef cmb As Windows.Forms.ComboBox, Optional ByVal condicion As String = "")
        Dim c As New ACCESO.Conexion
        If (c.Connect()) Then
            Dim dt = c.Query("SELECT idResponsable,vNombres FROM Colaboradores " & condicion & " order by vNombres asc")
            cmb.DataSource = dt
            cmb.ValueMember = dt.Columns(0).ToString()
            cmb.DisplayMember = dt.Columns(1).ToString()
            cmb.Text = ""
            cmb.SelectedIndex = -1
            c.Close()
        End If
    End Sub
End Class
