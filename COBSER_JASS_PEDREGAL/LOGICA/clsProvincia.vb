Public Class clsProvincia
    Private id As Integer
    Private nombre As String
    Public Shared Sub LoadCombo(ByRef cmb As Windows.Forms.ComboBox, Optional ByVal condicion As String = "")
        Dim c As New ACCESO.Conexion
        If (c.Connect()) Then
            Dim dt = c.Query("SELECT iIdProvincia,vNombre FROM Provincia " & condicion & " order by vNombre asc")
            cmb.DataSource = dt
            cmb.ValueMember = dt.Columns(0).ToString()
            cmb.DisplayMember = dt.Columns(1).ToString()
            cmb.Text = ""
            cmb.SelectedIndex = -1
            c.Close()
        End If
    End Sub
    Public Shared Function Export(Optional ByVal parametro As String = "") As String
        Dim dt As New DataTable
        Dim dt_columns As New DataTable
        Dim c As New ACCESO.Conexion
        Dim sqlExport As String = "/*************************PROVINCIA***********************/" & vbCrLf
        Dim insertColumns As String = ""
        Dim nroColumns As Integer
        Dim insertValues As String = ""
        Dim strInsert As String = ""
        Dim strUpdate As String = ""
        Dim updateValues As String = ""
        Dim index As Integer
        Dim valor As String = ""

        If (c.Connect) Then
            dt_columns = c.Query("SELECT COLUMN_NAME,DATA_TYPE,IS_NULLABLE FROM information_schema.columns WHERE table_name = 'Provincia'")
            nroColumns = dt_columns.Rows.Count
            'cadena de nombre de columnas
            For Each MiDataRow2 As DataRow In dt_columns.Rows
                insertColumns = insertColumns & MiDataRow2(0) & ","
            Next
            insertColumns = insertColumns.Substring(0, insertColumns.Length - 1)
            dt = c.Query("select * from Provincia " + parametro)
            'genero script de todos los datos del canal
            For Each MiDataRow As DataRow In dt.Rows
                insertValues = ""
                'cadena de datos
                For i = 0 To nroColumns - 1
                    'insertValues = insertValues & "'" & MiDataRow(i) & "',"
                    valor = ""
                    Select Case dt_columns.Rows(i).Item(1)

                        Case "varchar", "char", "text"
                            'Verifico si el campo acepta .NULL.
                            If Trim(MiDataRow(i).ToString) = "" And dt_columns.Rows(i).Item(2) = "YES" Then
                                valor = "NULL"
                            Else
                                valor = "'" & MiDataRow(i) & "'"
                            End If

                        Case "int", "float", "numeric"
                            If IsDBNull(MiDataRow(i)) Then
                                valor = "NULL"
                            Else
                                valor = MiDataRow(i).ToString
                            End If
                        Case "datetime"
                            If IsDBNull(MiDataRow(i)) Then
                                valor = "NULL"
                            Else
                                valor = "CONVERT(datetime,'" & Mid(MiDataRow(i).ToString, 1, 19) & "')"
                            End If
                        Case Else
                            If IsDBNull(MiDataRow(i)) And dt_columns.Rows(i).Item(2) = "YES" Then
                                valor = "NULL"
                            Else
                                valor = "'" & MiDataRow(i) & "'"
                            End If
                    End Select
                    insertValues = insertValues & valor & ","
                Next
                index = 2
                updateValues = ""

                For j = index To nroColumns - 1
                    'updateValues = updateValues & dt_columns.Rows(j).Item(0) & "='" & MiDataRow(j) & "',"
                    valor = ""
                    Select Case dt_columns.Rows(j).Item(1)
                        Case "varchar", "char", "text"
                            'Verifico si el campo acepta .NULL.
                            If Trim(MiDataRow(j).ToString) = "" And dt_columns.Rows(j).Item(2) = "YES" Then
                                valor = "NULL"
                            Else
                                valor = "'" & MiDataRow(j) & "'"
                            End If
                        Case "int", "float", "numeric"
                            If IsDBNull(MiDataRow(j)) Then
                                valor = "NULL"
                            Else
                                valor = MiDataRow(j).ToString
                            End If
                        Case "datetime"
                            If IsDBNull(MiDataRow(j)) Then
                                valor = "NULL"
                            Else
                                valor = "CONVERT(datetime,'" & Mid(MiDataRow(j).ToString, 1, 19) & "')"
                            End If
                        Case Else
                            If IsDBNull(MiDataRow(j)) And dt_columns.Rows(j).Item(2) = "YES" Then
                                valor = "NULL"
                            Else
                                valor = "'" & MiDataRow(j) & "'"
                            End If
                    End Select
                    updateValues = updateValues & dt_columns.Rows(j).Item(0) & "=" & valor & ","
                Next

                updateValues = updateValues.Substring(0, updateValues.Length - 1)
                insertValues = insertValues.Substring(0, insertValues.Length - 1)
                strInsert = "insert into Provincia(" & insertColumns & ")" & " values(" & insertValues & ");" & vbCrLf
                strUpdate = "update Provincia set " & updateValues & " where " & dt_columns.Rows(0).Item(0) & "=" & MiDataRow(0) & " And " & dt_columns.Rows(1).Item(0) & "=" & MiDataRow(1) & ";" & vbCrLf
                sqlExport = sqlExport & strInsert & strUpdate
            Next
            c.Close()
        End If
        Return sqlExport
    End Function

End Class
