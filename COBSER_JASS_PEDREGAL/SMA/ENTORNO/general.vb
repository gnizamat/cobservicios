Imports System.IO
Imports System.Windows.Forms
Imports System
Imports System.Security.Cryptography
Imports System.Text
'Imports PIA = Microsoft.Office.Interop.Excel
'Imports LOGICA
Module general
    Public Sub showAlertActualizacionRemota(ByVal frm As Form, ByVal msg As String, Optional ByVal usuario As String = "", Optional ByVal fecha As String = "")
        Dim wAlert = New frmAlert()
        Dim r As Rectangle = Screen.GetWorkingArea(frm)
        wAlert.Location = New Point(r.Right - wAlert.Width, r.Bottom - wAlert.Height)
        wAlert.AutoClose = True
        wAlert.AutoCloseTimeOut = 10
        wAlert.lblMessage.Text = msg
        wAlert.lblUsuario.Text = usuario
        wAlert.lblFecha.Text = fecha
        'm_AlertOnLoad.AlertAnimation = eAlertAnimation.BottomToTop
        'wAlert.AlertAnimationDuration = 300
        wAlert.Show(False)
    End Sub

    'Public Sub fxExportarXLS(ByVal Grid As DataGridView, ByVal ruta As String)
    '    Dim excelApplication As PIA.Application = New PIA.Application
    '    Dim excelWorkbook As PIA.Workbook = CType(excelApplication.Workbooks.Add(System.Reflection.Missing.Value), PIA.Workbook)
    '    Dim excelSheet As PIA.Worksheet = CType(excelWorkbook.Sheets(1), PIA.Worksheet)
    '    'add the columns
    '    Dim col As Integer = 0
    '    For i As Integer = 0 To Grid.Columns.Count - 1
    '        If Grid.Columns(i).Visible Then
    '            col += 1
    '            CType(excelSheet.Cells(1, col), PIA.Range).Value2 = Grid.Columns(i).HeaderText
    '        End If
    '    Next i

    '    'set the column styles
    '    excelSheet.Range(excelSheet.Cells(1, 1), excelSheet.Cells(1, Grid.Columns.Count)).Font.Bold = True
    '    excelSheet.Range(excelSheet.Cells(1, 1), excelSheet.Cells(1, Grid.Columns.Count)).HorizontalAlignment = PIA.XlHAlign.xlHAlignCenter
    '    For i As Integer = 0 To Grid.Rows.Count - 2
    '        col = 0
    '        For j As Integer = 0 To Grid.Columns.Count - 1
    '            If Grid.Columns(j).Visible Then
    '                col += 1
    '                excelSheet.Cells(i + 2, col) = Grid.Rows(i).Cells(j).Value
    '            End If
    '        Next
    '    Next i
    '    'tmp = excelSheet.Cells.Range(excelSheet.Cells(2, 1), excelSheet.Cells(2, 1)).Value2.ToString()

    '    'save the file
    '    Try
    '        excelWorkbook.Close(True, ruta, Nothing)
    '    Catch ex As Exception
    '        MsgBox("Documento se encuentra abierto", MsgBoxStyle.Critical)
    '    End Try


    '    'Dispose of the resource
    '    System.Runtime.InteropServices.Marshal.ReleaseComObject(excelWorkbook)
    '    System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApplication)
    '    excelWorkbook = Nothing
    '    excelApplication = Nothing

    '    'Open the created file
    '    Dim p As Process = New Process
    '    p.StartInfo.FileName = ruta
    '    p.Start()
    'End Sub
    Public Sub fxExportarXLS2(ByVal Grid As DataGridView, ByVal ruta As String)
        Dim Obj_Excel As Object
        Dim Obj_Libro As Object
        Dim Obj_Hoja As Object
        Dim oSW As New StreamWriter(ruta)
        oSW.Flush()
        oSW.Close()
        Obj_Excel = CreateObject("Excel.Application")
        Obj_Libro = Obj_Excel.Workbooks.Add(ruta)

        'Ponemos la aplicación excel visible   
        Obj_Excel.Visible = True

        'Hoja activa   
        Obj_Hoja = Obj_Excel.ActiveSheet

        ' Recorre el Datagrid   
        Dim iCol As Integer = 0
        Dim j As Integer
        Dim n_Filas As Integer = Grid.Rows.Count - 1
        For i = 0 To Grid.Columns.Count - 1
            If Grid.Columns(i).Visible Then
                iCol = iCol + 1
                'Caption de la columna   
                Obj_Hoja.Cells(1, iCol) = Grid.Columns(i).HeaderText
                'asigna el valor a la celda del Excel   
                Try

                    For j = 0 To n_Filas - 2
                        Obj_Hoja.Cells(j + 2, iCol) = Grid.Rows(j).Cells(i).Value
                    Next
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try



            End If
        Next


        Obj_Hoja.Rows(1).Font.Bold = True
        Obj_Hoja.rows(1).Interior.Color = RGB(200, 160, 35)
        'Obj_Hoja.rows(1).lineStyle = "xlEdgeBottom"
        'Autoajustamos   
        Obj_Hoja.Columns("A:Z").AutoFit()

        'Eliminamos las variables de objeto excel   
        Obj_Hoja = Nothing
        Obj_Libro = Nothing
        Obj_Excel = Nothing

    End Sub

    Function getMd5Hash(ByVal input As String) As String
        ' Create a new instance of the MD5 object.
        Dim md5Hasher As MD5 = MD5.Create()

        ' Convert the input string to a byte array and compute the hash.
        Dim data As Byte() = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input))

        ' Create a new Stringbuilder to collect the bytes
        ' and create a string.
        Dim sBuilder As New StringBuilder()

        ' Loop through each byte of the hashed data 
        ' and format each one as a hexadecimal string.
        Dim i As Integer
        For i = 0 To data.Length - 1
            sBuilder.Append(data(i).ToString("x2"))
        Next i

        ' Return the hexadecimal string.
        Return sBuilder.ToString()

    End Function
    Public Function showMessages(ByVal tipo) As Boolean
        Dim estado As Boolean = True
        Select Case tipo
            Case "delete"
                Dim m = MessageBox.Show("Desea eliminar el registro seleccionado?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                estado = IIf(m = DialogResult.Yes, True, False)
            Case "save"
                Dim m = MessageBox.Show("Informacion registrada satisfactoriamente." & vbCrLf & "Desea continuar?", "SIRIG", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                estado = IIf(m = DialogResult.Yes, True, False)

            Case "update"
                MsgBox("Registro(s) actualizado(s) satisfactoriamente", MsgBoxStyle.Information)
            Case "formInvalid"
                MessageBox.Show("Información invalida o incompleta." & vbCrLf & " Complete los campos obligatorios y asegurese que la informacion ingresada corresponda al formato solicitado", "SMA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                'MsgBox("Información invalida o incompleta." & vbCrLf & " Complete los campos obligatorios y asegurese que la informacion ingresada corresponda al formato solicitado", MsgBoxStyle.Exclamation)
            Case "print"
                Dim m = MessageBox.Show("Desea imprimir el documento seleccionado?", "SMA", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                estado = IIf(m = DialogResult.Yes, True, False)
            Case "RequiredSelect"
                MsgBox("Debe seleccionar un registro", MsgBoxStyle.Exclamation)
            Case "PasswordIncorrect"
                MsgBox("Contraseña incorrecta, no tiene permisos para acceder a esta interfaz", MsgBoxStyle.Exclamation)
        End Select
        Return estado
    End Function
    Public Function getFechaCosecha(ByVal fecha_siembra As Date, ByVal periodo As Integer) As String
        Dim auxMes As Integer
        Dim auxDia As Integer
        Dim auxAnno As Integer
        auxMes = Month(fecha_siembra) + periodo
        auxDia = DateAndTime.Day(fecha_siembra)

        If auxMes > 12 Then
            auxMes = (Month(fecha_siembra) + periodo) - 12
            auxAnno = (Year(fecha_siembra) + 1)
        Else
            auxMes = (Month(fecha_siembra) + periodo)
            auxAnno = Year(fecha_siembra)
        End If

        If auxMes > 12 Then
            auxMes = auxMes - 12
        End If

        If auxMes = 2 Then
            If auxAnno Mod 4 = 0 Then
                auxDia = DateAndTime.Day(fecha_siembra) - 29
                If auxDia > 0 Then
                    auxMes = auxMes + 1
                Else
                    auxDia = DateAndTime.Day(fecha_siembra)
                End If
            Else
                auxDia = DateAndTime.Day(fecha_siembra) - 28
                If auxDia > 0 Then
                    auxMes = auxMes + 1
                Else
                    auxDia = DateAndTime.Day(fecha_siembra)
                End If
            End If
        End If

        If auxMes = 4 Or auxMes = 6 Or auxMes = 9 Or auxMes = 11 Then
            If auxDia = 31 Then
                auxDia = 30
            End If
        End If

        Return IIf(auxDia < 10, "0" & auxDia, auxDia) & "/" & IIf(auxMes < 10, "0" & auxMes, auxMes) & "/" & auxAnno
    End Function

    Public Function DevolverConCeros(ByVal nroItems As Integer, ByVal valor As Integer) As String
        Dim ceros As String = ""
        Dim cadenaValor As String
        For i = 1 To nroItems
            ceros &= "0"
        Next
        cadenaValor = ceros & valor
        cadenaValor = cadenaValor.Substring(cadenaValor.Length - nroItems)
        Return cadenaValor
    End Function

    Public Function getNombre(ByVal path As String) As String
        Dim index As Integer = 0
        Dim flag As Boolean = False
        While flag = False
            If (path.IndexOf("\", index + 1) = -1) Then
                flag = True
            Else
                index = path.IndexOf("\", index + 1)
            End If
        End While
        Return path.Substring(index + 1)
    End Function
    Public Function ValidaGridItemSeleccionado(ByRef grid As DataGridView, Optional ByVal msg As String = "Debe Seleccionar un elemento del listado") As Boolean
        Try

            If (grid.SelectedRows.Count > 0) Then
                If (grid.CurrentRow.Index >= 0) Then
                    Return True
                Else
                    Return False
                End If

            Else
                MsgBox(msg, MsgBoxStyle.Exclamation)
                Return False
            End If
        Catch ex As Exception
            MsgBox(msg, MsgBoxStyle.Exclamation)
            Return False
        End Try
    End Function
    Public Function SegundosFormatoHoras(ByVal segundos As Single) As String
        Dim formato As String
        Dim t2 As TimeSpan = TimeSpan.FromSeconds(segundos)
        formato = t2.Days.ToString() + "dias y " & t2.Hours.ToString() & ":" + t2.Minutes.ToString() & ":" & t2.Seconds.ToString()
        Return formato
    End Function
    Public Function FormatoHorasMinutos(ByVal segundos As Single) As String
        Dim formato As String
        Dim t2 As TimeSpan = TimeSpan.FromSeconds(segundos)
        formato = t2.Hours.ToString() & ":" + t2.Minutes.ToString()
        Return formato
    End Function


End Module
