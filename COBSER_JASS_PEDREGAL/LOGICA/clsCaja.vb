Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports ACCESO

Public Class clsCaja
    Private _idJunta As String
    Private _idComision As Integer
    Private _id As Integer
    Private _nombre As String
    Private _ip As String
    Private _tipo As Char
    Private _idBanco As Integer
    Private _idCuenta As Integer
    Public Property IdBanco() As Integer
        Get
            Return _idBanco
        End Get
        Set(ByVal value As Integer)
            _idBanco = value
        End Set
    End Property
    Public Property IdCuenta() As Integer
        Get
            Return _idCuenta
        End Get
        Set(ByVal value As Integer)
            _idCuenta = value
        End Set
    End Property
    Public Property tipo()
        Get
            Return Me._tipo
        End Get
        Set(ByVal value)
            Me._tipo = value
        End Set
    End Property
    Public Property idJunta()
        Get
            Return Me._idJunta
        End Get
        Set(ByVal value)
            Me._idJunta = value
        End Set
    End Property
    Public Property idComision()
        Get
            Return Me._idComision
        End Get
        Set(ByVal value)
            Me._idComision = value
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
    Public Property nombre()
        Get
            Return Me._nombre
        End Get
        Set(ByVal value)
            Me._nombre = value
        End Set
    End Property
    Public Property ip()
        Get
            Return Me._ip
        End Get
        Set(ByVal value)
            Me._ip = value
        End Set
    End Property
    Sub New()

    End Sub
    Sub New(ByVal id_junta As String, ByVal id_comision As String, ByVal nombre As String, ByVal tipo As Char, Optional ByVal ip As String = "")
        Me._idJunta = id_junta
        Me._idComision = id_comision
        Me._nombre = nombre
        Me._ip = ip
        Me._tipo = tipo
    End Sub
    Sub New(ByVal id_junta As String, ByVal id_comision As String, ByVal nombre As String, ByVal tipo As Char, ByVal id_Banco As Integer, ByVal id_Cuenta As Integer)
        Me._idJunta = id_junta
        Me._idComision = id_comision
        Me._nombre = nombre
        Me.IdBanco = id_Banco
        Me._idCuenta = id_Cuenta
        Me._tipo = tipo
    End Sub
    Private Function NewId()
        Dim c As New ACCESO.Conexion
        Dim dt As New DataTable
        Dim id As Integer
        If (c.Connect) Then
            dt = c.Query("select isNull(max(iIdCaja),0) from tarCaja where vIdJuntaUsuario='" & Me._idJunta & "' and iCodComision='" & Me._idComision & "'")
            id = dt.Rows(0).Item(0) + 1
            c.Close()
        End If
        Return id
    End Function
    Public Sub Insert()
        Dim cmd As New SqlCommand()
        Dim c As New ACCESO.Conexion
        Me._id = Me.NewId
        If (c.Connect) Then
            cmd.CommandType = CommandType.StoredProcedure
            Select Case (Me._tipo)
                Case "1"
                    cmd.CommandText = "sp_tarCaja_insert2"
                    cmd.Parameters.AddWithValue("@IDBANCO", Me.IdBanco)
                    cmd.Parameters.AddWithValue("@IDCUENTA", Me._idCuenta)
                Case "0"
                    'cmd.CommandText = "sp_tarCaja_insert"
                    cmd.CommandText = "sp_tarCaja_insert2"
                    cmd.Parameters.AddWithValue("@IP", Me._ip)
            End Select
            cmd.Parameters.AddWithValue("@IDCAJA", Me._id)
            cmd.Parameters.AddWithValue("@IDJUNTA", Me._idJunta)
            cmd.Parameters.AddWithValue("@IDCOMISION", Me._idComision)
            cmd.Parameters.AddWithValue("@NOMBRE", Me._nombre)
            cmd.Parameters.AddWithValue("@IDBANCO", Me._idBanco)
            cmd.Parameters.AddWithValue("@IDCUENTA", Me._idCuenta)
            cmd.Parameters.AddWithValue("@TIPO", Me._tipo)

            If (c.Execute(cmd) = False) Then
                MsgBox(c.msgError)
            Else
                'clsConfiguracionDocumento.InsertDefault(Me._idJunta, Me._idComision, Me._id)
            End If
            c.Close()
        End If
    End Sub
    Public Sub Update()
        Dim cmd As New SqlCommand()
        Dim c As New ACCESO.Conexion
        If (c.Connect) Then
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "sp_tarCaja_update"
            cmd.Parameters.AddWithValue("@IDCAJA", Me._id)
            cmd.Parameters.AddWithValue("@IDJUNTA", Me._idJunta)
            cmd.Parameters.AddWithValue("@IDCOMISION", Me._idComision)
            cmd.Parameters.AddWithValue("@NOMBRE", Me._nombre)
            cmd.Parameters.AddWithValue("@TIPO", Me._tipo)
            Select Case Me._tipo
                Case "0"
                    cmd.Parameters.AddWithValue("@IP", Me._ip)
                    cmd.Parameters.AddWithValue("@IDBANCO", Me._idBanco)
                    cmd.Parameters.AddWithValue("@IDCUENTA", Me._idCuenta)
                Case "1"
                    cmd.Parameters.AddWithValue("@IP", DBNull.Value)
                    cmd.Parameters.AddWithValue("@IDBANCO", Me.IdBanco)
                    cmd.Parameters.AddWithValue("@IDCUENTA", Me._idCuenta)
            End Select

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
            dt = c.Query("Select c.vIdJuntaUsuario,(select j.vNombre from JuntaUsuario j where j.vIdJuntaUsuario=c.vIdJuntaUsuario) as 'junta',c.iCodComision,isNull((select cm.vNombre from ComisionRegante cm where cm.iIdComisionRegante=c.iCodComision and cm.vIdJuntaUsuario=c.vIdJuntaUsuario),'-') as 'comision',c.iIdCaja,c.vNombre,c.vIP,c.cTipo,case c.cTipo when '0' then 'Sistema' when '1' then 'Entidad Bancaria' ELSE '-' END,c.cEstado,c.iIdBanco,c.iIdCuenta from tarCaja c " & condicion & order)
            c.Close()
        End If
        Return dt
    End Function
    Public Shared Sub LoadCombo(ByRef cmb As Windows.Forms.ComboBox, Optional ByVal condicion As String = "")
        Dim c As New ACCESO.Conexion
        Dim dt As New DataTable
        If (c.Connect()) Then
            dt = c.Query("SELECT tarCaja.* FROM tarCaja" & condicion)
            cmb.DataSource = dt
            cmb.ValueMember = dt.Columns(1).ToString()
            cmb.DisplayMember = dt.Columns(2).ToString()
            cmb.Text = ""

            c.Close()
        End If
    End Sub
    Public Shared Function obtenerCaja() As clsCaja
        Dim dt As New DataTable
        Dim c As New ACCESO.Conexion
        Dim caja As New clsCaja
        If (c.Connect) Then
            dt = c.Query("SELECT vIdJas, iIdCaja, vNombre, vIP, cEstado, cTipo, iIdBanco, iIdCuenta FROM tarCaja WHERE  cEstado=1 ")
            If (c.msgError <> "") Then
                MsgBox(c.msgError)
            Else
                If (dt.Rows.Count > 0) Then
                    caja._idJunta = dt.Rows(0).Item(0)
                    'tarifa._idComision = idcomision
                    'tarifa._idJunta = idjunta
                    caja._id = dt.Rows(0).Item(1)
                    caja._nombre = dt.Rows(0).Item(2)
                    caja._tipo = dt.Rows(0).Item(3)
                    caja._ip = dt.Rows(0).Item(4)


                Else
                    Return Nothing
                End If
            End If
            c.Close()
        End If
        Return caja
    End Function
End Class
