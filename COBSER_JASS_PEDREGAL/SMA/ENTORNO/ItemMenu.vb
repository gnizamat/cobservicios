Imports System.Windows.Forms
Public Class ItemMenu
    Private _idMenu As Integer
    Private _idPadre As Integer
    Private _mnuOpcion As ToolStripMenuItem
    Sub New(ByVal id As Integer, ByVal idp As Integer, ByVal nombre As String)
        Me._mnuOpcion = New ToolStripMenuItem(nombre)
        Me._mnuOpcion.Name = id
        Me._idMenu = id
        Me._idPadre = idp
    End Sub
    Public Property idMenu()
        Get
            Return Me._idMenu
        End Get
        Set(ByVal value)

        End Set
    End Property
    Public Property idPadre()
        Get
            Return Me._idPadre
        End Get
        Set(ByVal value)

        End Set
    End Property
    Public Property mnuOpcion()
        Get
            Return _mnuOpcion
        End Get
        Set(ByVal value)

        End Set
    End Property

End Class
