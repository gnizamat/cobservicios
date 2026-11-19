Public Class ITEM

    Public _value As Object
    Public _text As String
    Public ReadOnly Property value()
        Get
            Return _value
        End Get
    End Property
    Public ReadOnly Property text()
        Get
            Return _text
        End Get
    End Property

    Public Sub New(ByVal NewValue As Object, ByVal NewDescription As String)
        _value = NewValue
        _text = NewDescription
    End Sub

    Public Overrides Function ToString() As String
        Return _text
    End Function
End Class

