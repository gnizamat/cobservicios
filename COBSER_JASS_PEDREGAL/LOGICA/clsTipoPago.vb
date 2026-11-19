Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Data.OleDb
Imports ACCESO
Public Class clsTipoPago
    Private _id As Integer
    Private _nombre As String
    Private _estado As Char
    
    Public Property id()
        Get
            Return Me._id
        End Get
        Set(ByVal value)
            Me._id = value
        End Set
    End Property
    Public Property Nombre() As Char
        Get
            Return _nombre
        End Get
        Set(ByVal value As Char)
            _nombre = value
        End Set
    End Property
    Public Property Estado() As Char
        Get
            Return _estado
        End Get
        Set(ByVal value As Char)
            _estado = value
        End Set
    End Property
    
    Public Shared Sub LoadCombo(ByRef cmb As Windows.Forms.ComboBox, Optional ByVal condicion As String = "", Optional ByVal all As Boolean = False)
        Dim c As New ACCESO.Conexion
        Dim dt As New DataTable
        If (c.Connect()) Then
            dt = c.Query("select idTipoPago,vNombre from tarTipoPago " & condicion)
            cmb.DataSource = dt
            If (all And dt.Rows.Count > 0) Then
                Dim myNewRow As DataRow
                myNewRow = dt.NewRow()
                myNewRow(0) = 0
                myNewRow(1) = "[Todos los Tipos]"
                dt.Rows.InsertAt(myNewRow, 0)
            End If
            cmb.ValueMember = dt.Columns(0).ToString()
            cmb.DisplayMember = dt.Columns(1).ToString()
            cmb.SelectionStart = 1

        End If
    End Sub
End Class
