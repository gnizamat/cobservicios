Imports System
Imports System.Windows.Forms
Imports System.Drawing
Public Class clsFormItem
    Private _item
    Private _tipoForm As String 'combobox,textbox
    Private _tipo As String 'numeric,string,email,float
    Private _allowBlank As Boolean
    Private _range As Boolean
    Private _minValue
    Private _maxValue
    Private _msgValidation As String = ""
    Private _minLength As Integer = -1
    Private _maxLength As Integer = -1
    Public Property minLength()
        Get
            Return Me._minLength
        End Get
        Set(ByVal value)
            Me._minLength = value
        End Set
    End Property
    Public Property maxLength()
        Get
            Return Me._maxLength
        End Get
        Set(ByVal value)
            Me._maxLength = value
        End Set
    End Property
    Public Property msgValidation()
        Get
            Return Me._msgValidation
        End Get
        Set(ByVal value)
            Me._msgValidation = value
        End Set
    End Property
    Public Property allowblank()
        Get
            Return Me._allowBlank
        End Get
        Set(ByVal value)
            Me._allowBlank = value
        End Set
    End Property
    Public Property minValue()
        Get
            Return Me._minValue
        End Get
        Set(ByVal value)
            Me._minValue = value
        End Set
    End Property
    Public Property maxValue()
        Get
            Return Me._maxValue
        End Get
        Set(ByVal value)
            Me._maxValue = value
        End Set
    End Property
    Public Property range()
        Get
            Return Me._range
        End Get
        Set(ByVal value)
            Me._range = value
        End Set
    End Property
    Public Function validateRange() As Boolean
        Dim Valor
        Dim flag As Boolean = False
        Valor = Me.getText
        If (Valor >= Me._minValue) Then
            If (Valor <= Me._maxValue) Then
                flag = True
            End If
        End If

        Return flag
    End Function
    Public Function validateRangeMax() As Boolean
        Dim Valor
        Dim flag As Boolean = False
        Valor = Val(Me.getText)
        If (Valor <= Val(Me._maxValue)) Then
            flag = True
        End If
        Return flag
    End Function
    Public Function validateRangeMin() As Boolean
        Dim Valor
        Dim flag As Boolean = False
        Valor = Val(Me.getText)
        If (Valor >= Val(Me._minValue)) Then
            flag = True
        End If
        Return flag
    End Function
    Public ReadOnly Property item()
        Get
            Return Me._item
        End Get
    End Property
    Public Property tipo()
        Get
            Return Me._tipo
        End Get
        Set(ByVal value)
            Me._tipo = value
        End Set
    End Property
    Public Sub newIntegerTextBox(ByRef element As DevComponents.Editors.IntegerInput, ByVal type As String, Optional ByVal allowblank As Boolean = False, Optional ByVal range As Boolean = False, Optional ByVal min As Double = 0, Optional ByVal max As Double = 0)
        Me._item = New DevComponents.Editors.IntegerInput
        Me._item = element
        Me._tipo = type
        Me._allowBlank = allowblank
        Me._tipoForm = "textbox"
        Me._range = range
        Me._minValue = min
        Me._maxValue = max
    End Sub
    Public Sub newDoubleTextBox(ByRef element As DevComponents.Editors.DoubleInput, ByVal type As String, Optional ByVal allowblank As Boolean = False, Optional ByVal range As Boolean = False, Optional ByVal min As Double = 0, Optional ByVal max As Double = 0)
        Me._item = New DevComponents.Editors.IntegerInput
        Me._item = element
        Me._tipo = type
        Me._allowBlank = allowblank
        Me._tipoForm = "textbox"
        Me._range = range
        Me._minValue = min
        Me._maxValue = max
    End Sub
    Public Sub newAdvanceMaskTextBox(ByRef element As DevComponents.DotNetBar.Controls.MaskedTextBoxAdv, ByVal type As String, Optional ByVal allowblank As Boolean = False, Optional ByVal range As Boolean = False, Optional ByVal min As Double = 0, Optional ByVal max As Double = 0)
        Me._item = New DevComponents.Editors.IntegerInput
        Me._item = element
        Me._tipo = type
        Me._allowBlank = allowblank
        Me._tipoForm = "textbox"
        Me._range = range
        Me._minValue = min
        Me._maxValue = max
    End Sub
    Public Sub newTextBox(ByRef element As TextBox, ByVal type As String, Optional ByVal allowblank As Boolean = False, Optional ByVal range As Boolean = False, Optional ByVal min As Double = 0, Optional ByVal max As Double = 0)
        Me._item = New Windows.Forms.TextBox
        Me._item = element
        Me._tipo = type
        Me._allowBlank = allowblank
        Me._tipoForm = "textbox"
        Me._range = range
        Me._minValue = min
        Me._maxValue = max
    End Sub
    Public Sub newCombobox(ByRef element As ComboBox, ByVal type As String, ByVal allowblank As Boolean)
        Me._item = New Windows.Forms.ComboBox
        Me._item = element
        Me._tipo = type
        Me._allowBlank = allowblank
        Me._tipoForm = "combobox"
    End Sub
    Public Sub newMaskedtextbox(ByRef element As MaskedTextBox, ByVal type As String, ByVal allowblank As Boolean, Optional ByVal range As Boolean = False, Optional ByVal min As String = "0", Optional ByVal max As String = "0")
        Me._item = New Windows.Forms.MaskedTextBox
        Me._item = element
        Me._tipo = type
        Me._range = range
        Me._allowBlank = allowblank
        Me._tipoForm = "maskedTextBox"
        Me._minValue = min
        Me._maxValue = max
    End Sub
    Public Sub newDateTimePicker(ByRef element As DateTimePicker, ByVal type As String, ByVal allowblank As Boolean)
        Me._item = New Windows.Forms.DateTimePicker
        Me._item = element
        Me._tipo = type
        Me._allowBlank = allowblank
        Me._tipoForm = "datetimepicker"
    End Sub
    Public Sub newDateTimeInput(ByRef element As DevComponents.Editors.DateTimeAdv.DateTimeInput, ByVal type As String, ByVal allowblank As Boolean)
        Me._item = New DevComponents.Editors.DateTimeAdv.DateTimeInput
        Me._item = element
        Me._tipo = type
        Me._allowBlank = allowblank
        Me._tipoForm = "datetimeinput"
    End Sub
    Public Function isBlank() As Boolean
        Dim flag As Boolean = False
        Select Case (Me._tipoForm)
            Case "textbox"
                Try
                    If (Me._item.text.CompareTo("") = 0) Then
                        flag = True
                    Else
                        If (Me._tipo = "progresiva") Then
                            If (Replace(Me._item.text, " ", "").CompareTo("+.") = 0) Then
                                flag = True
                            End If
                        End If
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

            Case "combobox"
                If (Me._item.selectedindex < 0) Then
                    flag = True
                End If
            Case "maskedTextBox"
                If (Me._item.text.CompareTo("") = 0) Then
                    flag = True
                Else
                    If (Me._tipo = "progresiva") Then
                        If (Me._item.text.CompareTo("") = 0) Then
                            flag = True
                        End If
                    End If
                End If
            Case "datetimepicker"
                If (Me._item.text.CompareTo("") = 0) Then
                    flag = True
                End If
            Case "datetimeinput"
                If (Me._item.text.CompareTo("") = 0) Then
                    flag = True
                End If
        End Select
        Return flag
    End Function
    Public Function getText() As String
        Dim valor As String = ""
        Select Case (Me._tipoForm)
            Case "textbox"
                valor = Me._item.text
            Case "combobox"
                valor = Me._item.text
            Case "maskedTextBox"
                valor = Me._item.text
            Case "datetimepicker"
                valor = Me._item.text
            Case "datetimeinput"
                valor = Me._item.text
        End Select
        Return valor
    End Function
    Public Sub setText(ByVal value)
        Select Case (Me._tipoForm)
            Case "textbox"
                Me._item.text = value
        End Select
    End Sub
    Public Sub enabled(ByVal value As Boolean)
        Me._item.enabled = value
    End Sub
    Public Sub activeColorRequired()
        Me._item.BackColor = Color.YellowGreen
        Try
            If (Me._tipoForm = "combobox") Then
                Me._item.waterMarkColor = Color.YellowGreen
                Me._item.waterMarkText = "Seleccione un elemento"
            Else
                Me._item.waterMarkColor = Color.White
            End If
        Catch ex As Exception

        End Try


    End Sub
    Public Sub activeColorInvalid()
        Me._item.BackColor = Color.Cyan
        Try
            Me._item.waterMarkColor = Color.Cyan
        Catch ex As Exception

        End Try
    End Sub
    Public Sub resetColor()
        Me._item.BackColor = Color.White
        Try
            Me._item.waterMarkColor = Color.LightGray
        Catch ex As Exception

        End Try

    End Sub
End Class
