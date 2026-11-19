Public Class clsRegion
    Private id As Integer
    Private nombre As String
    Public Shared Sub LoadCombo(ByRef cmb As Windows.Forms.ComboBox, Optional ByVal condicion As String = "")
        Dim c As New ACCESO.Conexion
        If (c.Connect()) Then
            Dim dt = c.Query("SELECT iIdRegion,vNombre FROM Region " & condicion & " order by vNombre asc")
            cmb.DataSource = dt
            cmb.ValueMember = dt.Columns(0).ToString()
            cmb.DisplayMember = dt.Columns(1).ToString()
            cmb.Text = ""
            cmb.SelectedIndex = -1
            c.Close()
        End If
    End Sub
End Class
