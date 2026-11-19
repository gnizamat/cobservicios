Imports System.Text
Imports System.Windows
Imports System.Windows.Forms
Imports DevComponents
Imports ACCESO

Public Class clsValidateForm
    Private components As New Collection
    Private _count As Integer
    Private ttt As New ToolTip
    Sub New()
        ttt.ToolTipTitle = "Validación de Formulario"
        ttt.ToolTipIcon = ToolTipIcon.Warning
        Me._count = 0
    End Sub
    Public Sub addIntegerTextbox(ByRef comp As DevComponents.Editors.IntegerInput, ByVal tipo As String, Optional ByVal allowbblank As Boolean = False, Optional ByVal range As Boolean = False, Optional ByVal min As Double = 0, Optional ByVal max As Double = 0)
        Dim item As New clsFormItem
        item.newIntegerTextBox(comp, tipo, allowbblank, range, min, max)
        components.Add(item)
        Me._count += 1
    End Sub
    Public Sub addDoubleTextbox(ByRef comp As DevComponents.Editors.DoubleInput, ByVal tipo As String, Optional ByVal allowbblank As Boolean = False, Optional ByVal range As Boolean = False, Optional ByVal min As Double = 0, Optional ByVal max As Double = 0)
        Dim item As New clsFormItem
        item.newDoubleTextBox(comp, tipo, allowbblank, range, min, max)
        components.Add(item)
        Me._count += 1
    End Sub
    Public Sub addAdvanceMaskTextbox(ByRef comp As DevComponents.DotNetBar.Controls.MaskedTextBoxAdv, ByVal tipo As String, Optional ByVal allowbblank As Boolean = False, Optional ByVal range As Boolean = False, Optional ByVal min As Double = 0, Optional ByVal max As Double = 0)
        Dim item As New clsFormItem
        item.newAdvanceMaskTextBox(comp, tipo, allowbblank, range, min, max)
        components.Add(item)
        Me._count += 1
    End Sub
    Public Sub addTextbox(ByRef comp As TextBox, ByVal tipo As String, Optional ByVal allowbblank As Boolean = False, Optional ByVal range As Boolean = False, Optional ByVal min As Double = 0, Optional ByVal max As Double = 0)
        Dim item As New clsFormItem
        item.newTextBox(comp, tipo, allowbblank, range, min, max)
        components.Add(item)
        Me._count += 1
    End Sub
    Public Sub addCombobox(ByRef comp As ComboBox, ByVal tipo As String, ByVal allowbblank As Boolean)
        Dim item As New clsFormItem
        item.newCombobox(comp, tipo, allowbblank)
        components.Add(item)
        Me._count += 1
    End Sub
    Public Sub addMaskedTexbox(ByRef comp As MaskedTextBox, ByVal tipo As String, ByVal allowbblank As Boolean, Optional ByVal range As Boolean = False, Optional ByVal min As String = "0", Optional ByVal max As String = "0")
        Dim item As New clsFormItem
        item.newMaskedtextbox(comp, tipo, allowbblank, range, min, max)
        components.Add(item)
        Me._count += 1
    End Sub
    Public Sub addDateTimeInput(ByRef comp As DevComponents.Editors.DateTimeAdv.DateTimeInput, ByVal tipo As String, ByVal allowbblank As Boolean)
        Dim item As New clsFormItem
        item.newDateTimeInput(comp, tipo, allowbblank)
        components.Add(item)
        Me._count += 1
    End Sub
    Public Sub addDateTimePicker(ByRef comp As DateTimePicker, ByVal tipo As String, ByVal allowbblank As Boolean)
        Dim item As New clsFormItem
        item.newDateTimePicker(comp, tipo, allowbblank)
        components.Add(item)
        Me._count += 1
    End Sub
    Public Function item(ByVal index As Integer) As clsFormItem
        Return components(index)
    End Function
    Public Sub resetForm()
        Dim itm As New clsFormItem
        ttt.RemoveAll()
        For i = 1 To Me._count
            itm = components(i)
            itm.resetColor()
            itm.msgValidation = ""
        Next
    End Sub
    Public Sub removeForms()
        Me._count = 0
        Me.components = New Collection
        ttt.RemoveAll()
    End Sub
    Public Function startValidation() As Boolean
        Dim itm As New clsFormItem
        Dim m As String = "2"
        Dim completed As Boolean = True
        Dim ok As Boolean = True
        ttt.RemoveAll()
        Me.resetForm()
        For i = 1 To Me._count
            ok = True
            itm = components(i)
            itm.msgValidation = ""
            'verifico si el campo no permite valores nulos
            If (itm.allowblank = False) Then
                If itm.isBlank Then
                    itm.activeColorRequired()
                    completed = False
                    ok = False
                    itm.msgValidation = "- Campo es obligatorio"
                End If
            End If
            If (ok) Then

                'verifico el tipo de campo
                If Not itm.isBlank Then
                    If (valideType(itm) = False) Then
                        completed = False
                        ok = False
                        itm.activeColorInvalid()
                    End If
                End If
            End If
            If (String.Compare(itm.msgValidation, "") <> 0) Then
                ttt.SetToolTip(itm.item, itm.msgValidation)
            End If

        Next
        Return completed
    End Function
    Public Function valideType(ByRef itm As clsFormItem) As Boolean
        Dim flag As Boolean = True
        Dim msgError As String = ""
        'verifico el tipo de campo
        Select Case itm.tipo
            Case "string"
                If (ACCESO.ControlSecurity.ExistSQLInyection(itm.getText)) Then
                    flag = False
                    itm.msgValidation = "Se ha detectado posibles sentencias que podrian causar daños en la base de datos"
                End If
            Case "numeric"
                flag = IsNumeric(itm.getText)
                If (flag = False) Then
                    itm.msgValidation = "Campo debe ser un valor numerico"
                End If
            Case "email"
                flag = isEmail(itm.getText)
                If (flag = False) Then
                    itm.msgValidation = "Campo debe ser una direcion email valida"
                End If

            Case "date"
                flag = IsDate(itm.getText)
                If (flag = False) Then
                    itm.msgValidation = "Campo debe ser una Fecha valida en el formato dd/mm/aaaa"
                End If
        End Select
        'verifico si es el valor tiene que estar en un rango
        If (flag) Then
            If (itm.range) Then
                If (itm.validateRangeMin = False) Then
                    flag = False
                    itm.activeColorInvalid()
                    itm.msgValidation = "valor debe ser mayor o igual a " & itm.minValue
                End If
                If (itm.validateRangeMax = False) Then
                    flag = False
                    itm.activeColorInvalid()
                    itm.msgValidation = "valor debe ser menor o igual a " & itm.maxValue
                End If
            End If
        End If
        'verifico si el valor debe cumplir una longitud determinada
        If (flag) Then
            If (itm.minLength <> -1) Then
                If (itm.getText.ToString.Length < itm.minLength) Then
                    flag = False
                    itm.activeColorInvalid()
                    itm.msgValidation = "Longitud de campo debe ser mayor o igual a " & itm.minLength & " digitos"
                End If

            End If
            If (itm.maxLength <> -1) Then
                If (itm.getText.ToString.Length > itm.maxLength) Then
                    flag = False
                    itm.activeColorInvalid()
                    itm.msgValidation = "Longitud de campo debe ser menor o igual a " & itm.maxLength & " digitos"
                End If

            End If
        End If
        Return flag

    End Function
    Function isEmail(ByVal strCorreo As String) As Boolean
        Dim blnCorreo As Boolean
        Dim rgx As New RegularExpressions.Regex("\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*")
        If rgx.IsMatch(strCorreo) Then
            blnCorreo = True
        Else
            blnCorreo = False
        End If
        Return blnCorreo
    End Function

    Public Shared Sub LimpiarControles(ByRef f)
        ' recorrer todos los controles del formulario indicado  
        For Each c As Control In f.Controls
            If TypeOf c Is TextBox Then
                c.Text = "" ' eliminar el texto   
            End If
            If TypeOf c Is ComboBox Then
                CType(c, ComboBox).SelectedIndex = -1
            End If
        Next
    End Sub




End Class
