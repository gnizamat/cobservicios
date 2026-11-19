
Public Class PUBLICAS
    Public Shared Function SegundosFormatoHoras(ByVal segundos As Single) As String
        Dim formato As String
        Dim t2 As TimeSpan = TimeSpan.FromSeconds(segundos)
        formato = t2.Days.ToString() + "dias y " & t2.Hours.ToString() & ":" + t2.Minutes.ToString() & ":" & t2.Seconds.ToString()
        Return formato
    End Function
    Public Shared Function DevolverConCeros(ByVal nroItems As Integer, ByVal valor As Integer) As String
        Dim ceros As String = ""
        Dim cadenaValor As String
        For i = 1 To nroItems
            ceros &= "0"
        Next
        cadenaValor = ceros & valor
        cadenaValor = cadenaValor.Substring(cadenaValor.Length - nroItems)
        Return cadenaValor
    End Function
    Public Shared Sub LoadComboHoras(ByRef cmb As System.Windows.Forms.ComboBox)
        Dim dt As New DataTable
        Dim valor As String
        dt.Columns.Add("id")
        dt.Columns.Add("nombre")
        For i = 0 To 23
            If (i < 10) Then
                valor = "0" & i
            Else
                valor = i
            End If
            dt.Rows.Add(valor, valor)
        Next
        cmb.DataSource = dt
        cmb.ValueMember = dt.Columns(0).ToString()
        cmb.DisplayMember = dt.Columns(1).ToString()
    End Sub
    Public Shared Sub LoadComboMinutos(ByRef cmb As System.Windows.Forms.ComboBox)
        Dim dt As New DataTable
        Dim valor As String
        dt.Columns.Add("id")
        dt.Columns.Add("nombre")
        For i = 0 To 60 Step 15
            If (i < 10) Then
                valor = "0" & i
            Else
                valor = i
            End If
            dt.Rows.Add(valor, valor)
        Next
        cmb.DataSource = dt
        cmb.ValueMember = dt.Columns(0).ToString()
        cmb.DisplayMember = dt.Columns(1).ToString()
    End Sub
    Public Shared Function ConvierteACapital(ByVal pTexto As String) As String
        Dim palabras() As String
        Dim texto As String = ""
        palabras = pTexto.Split(" ")
        If palabras.Length > 0 Then
            For Each palabra As String In palabras
                If (palabra.Length > 0) Then
                    texto &= palabra.ToUpperInvariant(0) & IIf(palabra.Length > 1, palabra.ToLower.Substring(1) & " ", " ")
                End If

            Next
            If texto.Length > 0 Then
                Return texto.Substring(0, texto.Length - 1)
            End If
        End If
        Return pTexto
    End Function
End Class
