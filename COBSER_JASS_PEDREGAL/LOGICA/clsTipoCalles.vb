Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports ACCESO
Public Class clsTipoCalles
    Private _idTipoCalle As Integer
    Private _vNombre As String
    Public Shared Sub LoadCombo(ByRef cmb As Windows.Forms.ComboBox, Optional ByVal condicion As String = "")
        Try
            Dim c As New ACCESO.Conexion
            If (c.Connect()) Then
                Dim dt = c.Query("SELECT idTipoCalle,vNombre FROM TipoCalle " & condicion & " order by idTipoCalle asc")
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
End Class
