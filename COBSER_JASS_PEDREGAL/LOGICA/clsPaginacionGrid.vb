Imports System.Windows.Forms
Public Class clsPaginacionGrid
    Private bs As New BindingSource
    Private _dt As New DataTable
    Private _dtGlobal As New DataTable
    Private _dtpag As New DataTable
    Private _numRows As Integer = 50
    Private _numPages As Integer
    Private _currentPage As Integer
    Public Property dt()
        Get
            Return Me._dt
        End Get
        Set(ByVal value)
            Me._dt = value
        End Set
    End Property
    Public ReadOnly Property numPages()
        Get
            Return Me._numPages
        End Get

    End Property
    Public ReadOnly Property currentPage()
        Get
            Return Me._currentPage
        End Get
    End Property
    Public Sub New(ByVal dt As DataTable, ByVal maxItems As Integer)
        Me._dt = dt
        Me._dtGlobal = dt
        Me._numRows = maxItems
        If (Me._dt.Rows.Count Mod Me._numRows = 0) Then
            Me._numPages = Math.Floor(Me._dt.Rows.Count / Me._numRows)
        Else
            Me._numPages = Math.Floor(Me._dt.Rows.Count / Me._numRows) + 1
        End If
        Me._currentPage = 1

    End Sub
    Private Sub reloadVars()
        If (Me._dt.Rows.Count Mod Me._numRows = 0) Then
            Me._numPages = Math.Floor(Me._dt.Rows.Count / Me._numRows)
        Else
            Me._numPages = Math.Floor(Me._dt.Rows.Count / Me._numRows) + 1
        End If
        Me._currentPage = 1
        Me._dtpag = Me.LoadPage(Me._currentPage)

    End Sub
    Public Function LoadPage(ByVal pag As Integer) As DataTable
        Dim desde = Me._numRows * (pag - 1)
        Me._dtpag = Me._dt.Clone
        If (Me._currentPage <= Me._numPages Or Me._currentPage >= 1) Then
            If (Me._currentPage = Me._numPages) Then
                Dim x = (Me._dt.Rows.Count Mod Me._numRows)
                For i = 0 To x - 1
                    Me._dtpag.ImportRow(Me._dt.Rows(desde + i))

                Next
            Else
                If (Me._dt.Rows.Count > 0) Then
                    For i = 0 To Me._numRows - 1
                        Me._dtpag.ImportRow(Me._dt.Rows(desde + i))
                    Next
                End If
            End If

        End If

        Return Me._dtpag
    End Function
    Public Function NextPage() As DataTable
        If (Me._currentPage < Me._numPages) Then
            Me._currentPage = Me._currentPage + 1
            Me._dtpag = Me.LoadPage(Me._currentPage)

        End If
        Return Me._dtpag
    End Function
    Public Function PreviusPage() As DataTable
        If (Me._currentPage > 1) Then
            Me._currentPage = Me._currentPage - 1
            Me._dtpag = Me.LoadPage(Me._currentPage)

        End If
        Return Me._dtpag
    End Function
    Public Function FisrtPage() As DataTable
        Dim dt As DataTable
        Me._currentPage = 1
        dt = Me.LoadPage(Me._currentPage)
        Return dt
    End Function
    Public Function LastPage() As DataTable
        Dim dt As DataTable
        Me._currentPage = Me._numPages
        dt = Me.LoadPage(Me._currentPage)
        Return dt
    End Function
    Public Function gotoPage(ByVal page As Integer) As DataTable
        If (page >= 1 And page <= Me._numPages) Then
            Me._currentPage = page
            Me._dtpag = Me.LoadPage(Me._currentPage)
        End If
        Return Me._dtpag
    End Function
    Public Function Filter(ByVal strFilter As String, Optional ByVal strOrder As String = "") As DataTable
        Dim rows As DataRow()
        'Me.bs.Filter = strFilter
        rows = Me._dtGlobal.Select(strFilter)
        Me._dt = SelectDataTable(Me._dtGlobal, strFilter, strOrder)
        reloadVars()
        Return Me._dtpag
    End Function

    Public Function SelectDataTable(ByVal dt As DataTable, ByVal filter As String, Optional ByVal order As String = "") As DataTable

        Dim rows As DataRow()
        Dim dtNew As DataTable
        dtNew = dt.Clone() 'copio la estructura de la tabla
        rows = dt.Select(filter, order) 'filtro las data
        For Each dr As DataRow In rows ' lleno el nuevo datatable
            dtNew.ImportRow(dr)
        Next
        Return dtNew ' retorno el nuevo datatable filtrado
    End Function

End Class
