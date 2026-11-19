Public Class clsTipoIngreso
    Private _id As Integer
    Private _nombre As String
    Private _estado As Char

    Public Shared Sub LoadCombo(ByRef cmb As Windows.Forms.ComboBox, Optional ByVal condicion As String = "", Optional ByVal order As String = " order by idTipoIngreso", Optional ByVal start_idx As Integer = 0, Optional ByVal all As Boolean = False)
        Dim c As New ACCESO.Conexion
        Dim dt As New DataTable
        If (c.Connect()) Then
            dt = c.Query("select idTipoIngreso,vNombre from tarIngresosTipo where cEstado=1  " & order)
            cmb.DataSource = dt
            cmb.ValueMember = dt.Columns(0).ToString()
            cmb.DisplayMember = dt.Columns(1).ToString()
            cmb.Text = ""
            If (dt.Rows.Count > 0) Then
                If (all) Then
                    dt.Rows.Add(0, "[ Todos los Ingresos ]")

                End If
                cmb.SelectionStart = start_idx
            Else
                cmb.SelectedIndex = -1
            End If
            c.Close()
        End If
    End Sub
    Public Shared Sub LoadComboTipoDoc(ByRef cmb As Windows.Forms.ComboBox, Optional ByVal condicion As String = "")
        Dim c As New ACCESO.Conexion
        If (c.Connect()) Then
            Dim dt = c.Query("select iIdTipoDocumento, vNombre, idDocumento  from tarIngresoDocumentoTipo" & condicion)
            cmb.DataSource = dt
            cmb.ValueMember = dt.Columns(0).ToString()
            cmb.DisplayMember = dt.Columns(1).ToString()
            cmb.Text = ""
            cmb.SelectedValue = 0
        End If
    End Sub

End Class
