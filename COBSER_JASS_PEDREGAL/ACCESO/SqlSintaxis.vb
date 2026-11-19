Imports System.Windows.Forms
Imports System.Drawing
Imports System.Text.RegularExpressions
Public Class SqlSintaxis
    Private _RichTextBox1 As RichTextBox
    Public Sub New(ByRef rtb As RichTextBox)
        Me._RichTextBox1 = rtb
    End Sub
    Private Sub setTextColor(ByVal pStr As String, ByVal pColor As Drawing.Color)

        
        Dim Resultados As MatchCollection
        Dim Palabra As Match
        ' PAsar el pattern e indicar que ignore las mayúsculas y minúsculas al mosmento de buscar   
        Dim obj_Expresion As New Regex(pStr, RegexOptions.IgnoreCase)

        ' Ejecutar el método Matches para buscar la cadena en el texto del control   
        ' y retornar un MatchCollection con los resultados   
        Resultados = obj_Expresion.Matches(Me._RichTextBox1.Text)
        Dim posori As Integer = Me._RichTextBox1.SelectionStart
       

        ' Si se encontraron coincidencias recorre las colección   

        For Each Palabra In Resultados
            With Me._RichTextBox1
                .SelectionStart = Palabra.Index ' comienzo de la selección   
                .SelectionLength = Palabra.Length ' longitud de la cadena a seleccionar  
                .SelectionFont = New Font("Courier New", 9, FontStyle.Regular)
                .SelectionColor = pColor ' color de la selección   
                'Debug.Print(Palabra.Value)
            End With
        Next Palabra
        Me._RichTextBox1.SelectionStart = posori
        Me._RichTextBox1.SelectionLength = 0
    End Sub

    Private Sub SetConstant(ByVal pColor As Drawing.Color)
        Dim i As Integer
        Dim posAnt As Integer

        Dim pos1, pos2 As Integer

        posAnt = -1

        Me._RichTextBox1.SelectionStart = 0
        Me._RichTextBox1.SelectionLength = 0

        For i = 0 To 1000

            If i = 0 Then
                Me._RichTextBox1.Find("'", 0, RichTextBoxFinds.None)
            Else
                Me._RichTextBox1.Find("'", pos2 + 1, RichTextBoxFinds.None)
            End If

            pos1 = Me._RichTextBox1.SelectionStart

            Me._RichTextBox1.Find("'", Me._RichTextBox1.SelectionStart + 1, RichTextBoxFinds.None)

            pos2 = Me._RichTextBox1.SelectionStart

            If posAnt = pos1 Or Me._RichTextBox1.SelectedText = "" Then
                Exit For
            End If

            Me._RichTextBox1.SelectionStart = pos1
            Me._RichTextBox1.SelectionLength = pos2 - pos1 + 1

            Me._RichTextBox1.SelectionFont = New Font("Courier New", 9, FontStyle.Regular)
            Me._RichTextBox1.SelectionColor = pColor
            posAnt = Me._RichTextBox1.SelectionStart

        Next

    End Sub
    Private Sub SetComment(ByVal pColor As Drawing.Color)
        Dim strLine As String
        Dim strWords As String

        For Each strLine In Me._RichTextBox1.Lines

            If InStr(strLine, "--") > 0 Then

                strWords = Mid(strLine, InStr(strLine, "--"))

                setTextColor(strWords, pColor)

            End If
        Next
    End Sub
    Private Sub SetCommentLong(ByVal pColor As Drawing.Color)
        Dim i As Integer
        Dim posAnt As Integer

        Dim pos1, pos2 As Integer

        posAnt = -1

        Me._RichTextBox1.SelectionStart = 0
        Me._RichTextBox1.SelectionLength = 0

        For i = 0 To 1000

            If i = 0 Then
                Me._RichTextBox1.Find("/*", 0, RichTextBoxFinds.None)
            Else
                Me._RichTextBox1.Find("/*", pos2 + 1, RichTextBoxFinds.None)
            End If

            pos1 = Me._RichTextBox1.SelectionStart

            Me._RichTextBox1.Find("*/", Me._RichTextBox1.SelectionStart + 1, RichTextBoxFinds.None)

            pos2 = Me._RichTextBox1.SelectionStart

            If posAnt = pos1 Or Me._RichTextBox1.SelectedText = "" Then
                Exit For
            End If

            Me._RichTextBox1.SelectionStart = pos1
            Me._RichTextBox1.SelectionLength = pos2 - pos1 + 1

            Me._RichTextBox1.SelectionFont = New Font("Courier New", 9, FontStyle.Regular)
            Me._RichTextBox1.SelectionColor = pColor
            posAnt = Me._RichTextBox1.SelectionStart

        Next

    End Sub
    Public Sub ColorearSQL()
        Dim posori As Integer = Me._RichTextBox1.SelectionStart
        With Me._RichTextBox1
            .SelectAll()
            .SelectionColor = Color.Black
        End With
        Me._RichTextBox1.SelectionLength = 0
        Me._RichTextBox1.SelectionStart = posori
        '------------------
        'blue
        '------------------
        setTextColor("select", Color.Blue)
        setTextColor("from", Color.Blue)
        setTextColor("create", Color.Blue)
        setTextColor("procedure", Color.Blue)
        setTextColor("as", Color.Blue)
        setTextColor("inner", Color.Blue)
        setTextColor("on", Color.Blue)
        setTextColor("where", Color.Blue)
        setTextColor("table", Color.Blue)

        setTextColor("insert", Color.Blue)
        setTextColor("into", Color.Blue)
        setTextColor("update", Color.Blue)
        setTextColor("delete", Color.Blue)

        setTextColor("bit", Color.Blue)
        setTextColor("int", Color.Blue)
        setTextColor("varchar", Color.Blue)
        setTextColor("char", Color.Blue)
        setTextColor("numeric", Color.Blue)
        setTextColor("datetime", Color.Blue)
        setTextColor("float", Color.Blue)
        setTextColor("money", Color.Blue)

        setTextColor("declare", Color.Blue)
        setTextColor("set", Color.Blue)
        setTextColor("output", Color.Blue)
        setTextColor("order", Color.Blue)
        setTextColor("group", Color.Blue)
        setTextColor("by", Color.Blue)

        setTextColor("asc", Color.Blue)
        setTextColor("desc", Color.Blue)
        setTextColor("dateformat", Color.Blue)
        setTextColor("nocount", Color.Blue)
        setTextColor("is", Color.Blue)

        setTextColor("sum", Color.Fuchsia)
        setTextColor("avg", Color.Fuchsia)
        setTextColor("count", Color.Fuchsia)
        setTextColor("max", Color.Fuchsia)
        setTextColor("min", Color.Fuchsia)

        setTextColor("if", Color.Blue)
        setTextColor("else", Color.Blue)
        setTextColor("begin", Color.Blue)
        setTextColor("end", Color.Blue)
        setTextColor("when", Color.Blue)
        setTextColor("then", Color.Blue)
        setTextColor("return", Color.Blue)
        setTextColor("values", Color.Blue)

        '------------------
        'Gray
        '------------------
        setTextColor("and", Color.Gray)
        setTextColor("or", Color.Gray)
        setTextColor("join", Color.Gray)
        setTextColor("outer", Color.Gray)
        setTextColor("exists", Color.Gray)
        setTextColor("in", Color.Gray)
        setTextColor("not", Color.Gray)
        setTextColor("between", Color.Gray)
        setTextColor("null", Color.Gray)

        '------------------
        'fucsia
        '------------------
        setTextColor("left", Color.Fuchsia)
        setTextColor("isnull", Color.Fuchsia)
        setTextColor("case", Color.Fuchsia)
        setTextColor("convert", Color.Fuchsia)
        setTextColor("getdate", Color.Fuchsia)
        setTextColor("@@identity", Color.Fuchsia)
        setTextColor("@@ROWCOUNT", Color.Fuchsia)

        '------------------
        'red
        '------------------
        'SetConstant(Color.Red)
        'SetComment(Color.Green)
        'SetCommentLong(Color.Green)

        'Me._RichTextBox1.SelectionStart = 0
        'Me._RichTextBox1.SelectionLength = 0
        'Me._RichTextBox1.SelectionStart = posori
    End Sub
End Class
