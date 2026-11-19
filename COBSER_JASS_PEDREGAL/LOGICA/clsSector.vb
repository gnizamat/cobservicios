Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports ACCESO
Public Class clsSector
    Private _idSector As Integer
    Private _idCP As Integer
    Private _vNombre As String
    Private _cEstado As String
    Public Property idSector()
        Get
            Return Me._idSector
        End Get
        Set(ByVal value)
            Me._idSector = value
        End Set
    End Property
    Public Property idCP()
        Get
            Return Me._idCP
        End Get
        Set(ByVal value)
            Me._idCP = value
        End Set
    End Property
    Public Property vNombre()
        Get
            Return Me._vNombre
        End Get
        Set(ByVal value)
            Me._vNombre = value
        End Set
    End Property
    Public Property cEstado()
        Get
            Return Me._cEstado
        End Get
        Set(ByVal value)
            Me._cEstado = value
        End Set
    End Property
    Sub New(ByVal idsector As Integer, ByVal idCP As Integer, ByVal nombre As String, ByVal estado As String)
        Me._idSector = idsector
        Me._idCP = idCP
        Me._vNombre = nombre
        Me._cEstado = estado

    End Sub
    Public Shared Sub LoadCombo(ByRef cmb As Windows.Forms.ComboBox, Optional ByVal condicion As String = "")
        Dim c As New ACCESO.Conexion
        If (c.Connect()) Then
            Dim dt = c.Query("SELECT idSector,vNombre FROM Sector " & condicion & " order by vNombre asc")
            cmb.DataSource = dt
            cmb.ValueMember = dt.Columns(0).ToString()
            cmb.DisplayMember = dt.Columns(1).ToString()
            cmb.Text = ""
            cmb.SelectedIndex = -1
            c.Close()
        End If

    End Sub

    Public Shared Sub LoadComboSectorCalle(ByRef cmb As Windows.Forms.ComboBox, Optional ByVal condicion As String = "", Optional ByVal all As Boolean = True)
        Dim c As New ACCESO.Conexion
        If (c.Connect()) Then
            Dim dt = c.Query("SELECT  padPredio.idsector, Sector.vNombre AS SECTOR FROM   padPredio INNER JOIN Sector ON padPredio.idsector = Sector.idSector  " & condicion & " GROUP BY padPredio.idsector,Sector.vNombre")
            If (all And dt.Rows.Count > 0) Then
                dt.Rows.Add(0, "[Todos los Sectores]")
            End If
            cmb.DataSource = dt
            cmb.ValueMember = dt.Columns(0).ToString()
            cmb.DisplayMember = dt.Columns(1).ToString()
            cmb.Text = ""
            cmb.SelectedValue = 0
            c.Close()
        End If

    End Sub
    Public Shared Sub LoadComboAdd(ByRef cmb As Windows.Forms.ComboBox, Optional ByVal condicion As String = "", Optional ByVal all As Boolean = True)
        Dim c As New ACCESO.Conexion
        If (c.Connect()) Then
            Dim dt = c.Query("SELECT idSector,vNombre FROM Sector " & condicion & " order by vNombre asc")
            If (all And dt.Rows.Count > 0) Then
                dt.Rows.Add(0, "[Todos los Sectores]")
            End If
            cmb.DataSource = dt
            cmb.ValueMember = dt.Columns(0).ToString()
            cmb.DisplayMember = dt.Columns(1).ToString()
            cmb.Text = ""
            cmb.SelectedIndex = -1
            c.Close()
        End If


    End Sub

    Private Function NewId()
        Dim c As New ACCESO.Conexion
        Dim dt As New DataTable
        Dim id As Integer
        If (c.Connect) Then
            dt = c.Query("select isNull(max(idSector),0) from Sector")
            c.Close()
            id = dt.Rows(0).Item(0) + 1
        End If
        Return id
    End Function

    Public Shared Function List(Optional ByVal condicion As String = "") As DataTable
        Dim dt As New DataTable
        Dim c As New ACCESO.Conexion
        If (c.Connect) Then
            dt = c.Query("SELECT * FROM  Sector " & condicion)
            c.Close()
        End If
        Return dt
     
    End Function

    Public Function Insert() As Boolean
        Dim cmd As New SqlCommand()
        Dim c As New ACCESO.Conexion
        Me._idSector = Me.NewId
        If (c.Connect) Then
            cmd.CommandText = "INSERT INTO Sector (idSector, idCP, vNombre, cEstado)  VALUES (@IDSECTOR,@IDCP,@NOMBRE,@ESTADO)"
            cmd.Parameters.AddWithValue("@IDSECTOR", Me._idSector)
            cmd.Parameters.AddWithValue("@IDCP", Me._idCP)
            cmd.Parameters.AddWithValue("@NOMBRE", Me._vNombre)
            cmd.Parameters.AddWithValue("@ESTADO", Me._cEstado)

            If (c.Update(cmd) = False) Then
                MsgBox(c.msgError)
            End If
            c.Close()
        End If
    End Function

    Public Function Update() As Boolean
        Dim cmd As New SqlCommand()
        Dim c As New ACCESO.Conexion
        If (c.Connect) Then

            cmd.CommandText = "UPDATE Sector SET idCP=@IDCP, vNombre=@NOMBRE WHERE idSector=@IDSECTOR"
            cmd.Parameters.AddWithValue("@IDSECTOR", Me._idSector)
            cmd.Parameters.AddWithValue("@IDCP", Me._idCP)
            cmd.Parameters.AddWithValue("@NOMBRE", Me._vNombre)

            c.Update(cmd)
            c.Close()
        End If
    End Function
End Class
