Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Data.OleDb
Imports ACCESO
Imports LOGICA
Public Class clsTipoDeudaPredio
    Private _id As Integer
    Private _nombre As String
    Private _tipo As Char 'tipo definido en el sistema 0=sistema,1=usuario
    Private _tipoAsociado As Char 'si es una deuda aplicada al usuario=1 o al predio=2
    Private _idTipoDocumento As Integer
    Private _estado As Char
    Public Property Estado() As Char
        Get
            Return _estado
        End Get
        Set(ByVal value As Char)
            _estado = value
        End Set
    End Property
    Public Property id()
        Get
            Return Me._id
        End Get
        Set(ByVal value)
            Me._id = value
        End Set
    End Property
    Sub New()

    End Sub
    'Public Shared Function getDocumentoByID(ByVal idDeuda As Integer) As clsDocumento
    '    Dim doc As New clsDocumento
    '    Dim dt As New DataTable
    '    Dim c As New ACCESO.Conexion
    '    If (c.Connect()) Then
    '        dt = c.Query("select d.iIdDocumento,d.vNombre,d.iNroItemsDocumento,d.cTipoCodDocumento from tarTipoDeudaPredio td,tarDocumento d where d.iIdDocumento=td.iIdDocumento  and td.iIdTipoDeuda='" & idDeuda & "'")
    '        If (dt.Rows.Count > 0) Then
    '            doc = New clsDocumento(dt.Rows(0).Item(1), dt.Rows(0).Item(2), dt.Rows(0).Item(3))
    '            doc.id = dt.Rows(0).Item(0)
    '        End If
    '        If (c.msgError <> "") Then
    '            MsgBox(c.msgError)
    '        End If
    '        c.Close()
    '    End If
    '    Return doc
    'End Function
    'Public Shared Function getDocumentoByID_OpenConnection(ByRef c As Sigma.Dao.Conexion, ByVal idDeuda As Integer) As clsDocumento
    '    'Dim doc As New clsDocumento
    '    Dim dt As New DataTable
    '    dt = c.Query("select d.iIdDocumento,d.vNombre,d.iNroItemsDocumento,d.cTipoCodDocumento from tarTipoDeudaPredio td ,tarDocumento d where d.iIdDocumento=td.iIdDocumento  and td.iIdTipoDeuda='" & idDeuda & "'")
    '    If (dt.Rows.Count > 0) Then
    '        doc = New clsDocumento(dt.Rows(0).Item(1), dt.Rows(0).Item(2), dt.Rows(0).Item(3))
    '        doc.id = dt.Rows(0).Item(0)
    '    End If
    '    If (c.msgError <> "") Then
    '        MsgBox(c.msgError)
    '    End If
    '    Return doc
    'End Function
    Sub New(ByVal nombre As String, ByVal tipo_asociado As String, ByVal tipo_doc As Integer)
        Me.Nombre = nombre
        Me._tipoAsociado = tipo_asociado
        Me.IdTipoDocumento = tipo_doc
    End Sub
    Public Shared Sub LoadCombo(ByRef cmb As Windows.Forms.ComboBox, Optional ByVal condicion As String = "", Optional ByVal all As Boolean = False)
        Dim c As New ACCESO.Conexion
        Dim dt As New DataTable
        If (c.Connect()) Then
            dt = c.Query("select idTipoDeuda,vNombre from tarTipoDeudaPredio " & condicion)
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
    Public Sub Update()
        Dim cmd As New SqlCommand()
        Dim c As New ACCESO.Conexion
        If (c.Connect) Then
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "sp_tarTipoDeudaPredio_update"
            cmd.Parameters.AddWithValue("@ID", Me._id)
            cmd.Parameters.AddWithValue("@IDDOCUMENTO", Me.IdTipoDocumento)
            If (c.Execute(cmd) = False) Then
                MsgBox(c.msgError)
            End If
            c.Close()
        End If

    End Sub
    Public Shared Function List(Optional ByVal condicion As String = "", Optional ByVal order As String = " order by vNombre") As DataTable
        Dim dt As New DataTable
        Dim c As New ACCESO.Conexion
        If (c.Connect) Then
            dt = c.Query("Select iIdTipoDeuda,vNombre,iIdDocumento,cTipo from tarTipoDeudaPredio " & condicion & order)
            c.Close()
        End If
        Return dt
    End Function
    Public Property IdTipoDocumento() As Integer
        Get
            Return _idTipoDocumento
        End Get
        Set(ByVal value As Integer)
            _idTipoDocumento = value
        End Set
    End Property
    Public Property Nombre() As String
        Get
            Return _nombre
        End Get
        Set(ByVal value As String)
            _nombre = value
        End Set
    End Property
    Public Property Tipo() As Char
        Get
            Return _tipo
        End Get
        Set(ByVal value As Char)
            _tipo = value
        End Set
    End Property
End Class
