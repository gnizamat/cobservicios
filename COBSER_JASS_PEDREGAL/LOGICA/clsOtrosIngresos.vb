Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports ACCESO
Public Class clsOtrosIngresos
    Private _idJunta As String
    Private _idCP As Integer
    Private _iIdCaja As Integer
    Private _idIngreso As Integer
    Private _dFecha As DateTime
    Private _vNroDocumento As String
    Private _idTipoIngreso As Integer
    Private _iIdTipoDocumento As Integer
    Private _fMonto As Single
    Private _vConcepto As String
    Private _vUsuario As String
    Private _vDni As String
    Private _vRuc As String
    Private _vDireccion As String
    Private _cAnulado As String
    Private _vObserv As String
    Private _idTipoC As Integer
    Private _NDias As String
    Private _Ncantidad As String
    Public Property idJunta()
        Get
            Return Me._idJunta
        End Get
        Set(ByVal value)
            Me._idJunta = value
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

    Public Property iIdCaja()
        Get
            Return Me._iIdCaja
        End Get
        Set(ByVal value)
            Me._iIdCaja = value
        End Set
    End Property

    'Public Property idIngreso()
    '    Get
    '        Return Me._idIngreso
    '    End Get
    '    Set(ByVal value)
    '        Me._idIngreso = value
    '    End Set
    'End Property

    Public Property dFecha()
        Get
            Return Me._dFecha
        End Get
        Set(ByVal value)
            Me._dFecha = value
        End Set
    End Property

    Public Property vNroDocumento()
        Get
            Return Me._vNroDocumento
        End Get
        Set(ByVal value)
            Me._vNroDocumento = value
        End Set
    End Property
    Public Property idTipoIngreso()
        Get
            Return Me._idTipoIngreso
        End Get
        Set(ByVal value)
            Me._idTipoIngreso = value
        End Set
    End Property

    Public Property iIdTipoDocumento()
        Get
            Return Me._iIdTipoDocumento
        End Get
        Set(ByVal value)
            Me._iIdTipoDocumento = value
        End Set
    End Property
    Public Property fMonto()
        Get
            Return Me._fMonto
        End Get
        Set(ByVal value)
            Me._fMonto = value
        End Set
    End Property

    Public Property vConcepto()
        Get
            Return Me._vConcepto
        End Get
        Set(ByVal value)
            Me._vConcepto = value
        End Set
    End Property
    Public Property vUsuario()
        Get
            Return Me._vUsuario
        End Get
        Set(ByVal value)
            Me._vUsuario = value
        End Set
    End Property
    Public Property vDni()
        Get
            Return Me._vDni
        End Get
        Set(ByVal value)
            Me._vDni = value
        End Set
    End Property
    Public Property vRuc()
        Get
            Return Me._vRuc
        End Get
        Set(ByVal value)
            Me._vRuc = value
        End Set
    End Property

    Public Property vDireccion()
        Get
            Return Me._vDireccion
        End Get
        Set(ByVal value)
            Me._vDireccion = value
        End Set
    End Property

    Public Property cAnulado()
        Get
            Return Me._cAnulado
        End Get
        Set(ByVal value)
            Me._cAnulado = value
        End Set
    End Property
    Public Property vObserv()
        Get
            Return Me._vObserv
        End Get
        Set(ByVal value)
            Me._vObserv = value
        End Set
    End Property
    Public Property idTipoc()
        Get
            Return Me._idTipoc
        End Get
        Set(ByVal value)
            Me._idTipoc = value
        End Set
    End Property
    Public Property NDias()
        Get
            Return Me._NDias
        End Get
        Set(ByVal value)
            Me._NDias = value
        End Set
    End Property

    Sub New(ByVal idJunta As String, ByVal idCP As Integer, ByVal idcaja As Integer, ByVal idIngreso As Integer, ByVal dFecha As String, ByVal vNroDocumento As String, ByVal idTipoIngreso As Integer, ByVal iIdTipoDocumento As Integer, ByVal fMonto As Single, ByVal vConcepto As String, ByVal vUsuario As String, ByVal vDni As String, ByVal vRuc As String, ByVal vDireccion As String, ByVal cAnulado As String, ByVal vObserv As String, ByVal idTipoC As Integer, ByVal NDias As String, ByVal Ncantidad As String)
        Me._idJunta = idJunta
        Me._idCP = idCP
        Me._iIdCaja = iIdCaja
        Me._idIngreso = idIngreso
        Me._dFecha = dFecha
        Me._vNroDocumento = vNroDocumento
        Me._idTipoIngreso = idTipoIngreso
        Me._iIdTipoDocumento = iIdTipoDocumento
        Me._fMonto = fMonto
        Me._vConcepto = vConcepto
        Me._vUsuario = vUsuario
        Me._vDni = vDni
        Me._vRuc = vRuc
        Me._vDireccion = vDireccion
        Me._cAnulado = cAnulado
        Me._vObserv = vObserv
        Me._idTipoC = idTipoC
        Me._NDias = NDias
        Me._Ncantidad = Ncantidad

    End Sub
    Private Function NewId()
        Dim c As New ACCESO.Conexion
        Dim dt As New DataTable
        Dim id As Integer
        If (c.Connect) Then
            dt = c.Query("select isNull(max(idIngreso),0) from dbo.tarIngresosOtros ")
            c.Close()
            id = dt.Rows(0).Item(0) + 1
        End If
        Return id
    End Function

    Public Function Insert() As Boolean
        Dim cmd As New SqlCommand()
        Dim c As New ACCESO.Conexion
        'Me._idCalle = Me.NewId
        Me._idIngreso = Me.NewId
        If (c.Connect) Then

            If (c.msgError = "") Then

                cmd.CommandText = "INSERT INTO tarIngresosOtros (vIdJas, idCP, iIdCaja, idIngreso, dFecha,vNroDocumento,idTipoIngreso,iIdTipoDocumento,fMonto,vConcepto,vUsuario,vDni,vRuc,vDireccion, cAnulado,vObserv, idTipoCliente, NDias, Ncantidad)   VALUES (@IDJAS, @IDCP,@IDCAJA,@IDINGRESO,@FECHA,@NRODOCUMENTO,@TIPOINGRESO,@TIPODOCUMENTO,@MONTO,@CONCEPTO,@USUARIO,@DNI,@RUC,@DIRECCION,@ANULADO,@OBSERV,@IDTIPOC,@NDIAS, @NCANTIDAD )"
                cmd.Parameters.AddWithValue("@IDJAS", Me._idJunta)
                cmd.Parameters.AddWithValue("@IDCP", Me._idCP)
                cmd.Parameters.AddWithValue("@IDCAJA", Me._iIdCaja)
                cmd.Parameters.AddWithValue("@IDINGRESO", Me._idIngreso)
                cmd.Parameters.AddWithValue("@FECHA", Me._dFecha)
                cmd.Parameters.AddWithValue("@NRODOCUMENTO", Me._vNroDocumento)
                cmd.Parameters.AddWithValue("@TIPOINGRESO", Me._idTipoIngreso)
                cmd.Parameters.AddWithValue("@TIPODOCUMENTO", Me._iIdTipoDocumento)
                cmd.Parameters.AddWithValue("@MONTO", Me._fMonto)
                cmd.Parameters.AddWithValue("@CONCEPTO", Me._vConcepto)
                cmd.Parameters.AddWithValue("@USUARIO", Me._vUsuario)
                cmd.Parameters.AddWithValue("@DNI", Me._vDni)
                cmd.Parameters.AddWithValue("@RUC", Me._vRuc)
                cmd.Parameters.AddWithValue("@DIRECCION", Me._vDireccion)
                cmd.Parameters.AddWithValue("@ANULADO", Me._cAnulado)
                cmd.Parameters.AddWithValue("@OBSERV", Me._vObserv)
                cmd.Parameters.AddWithValue("@IDTIPOC", Me._idTipoC)
                cmd.Parameters.AddWithValue("@NDIAS", Me._NDias)
                cmd.Parameters.AddWithValue("@NCANTIDAD", Me._Ncantidad)

                If (c.Update(cmd) = False) Then
                    MsgBox(c.msgError)
                Else
                    MsgBox("Registrado correctamente", MsgBoxStyle.Information)
                End If
            Else
                MsgBox(c.msgError, MsgBoxStyle.Critical)
            End If


            c.Close()
        End If
    End Function
    Public Shared Function List(Optional ByVal condicion As String = "") As DataTable
        Dim dt As New DataTable
        Dim c As New ACCESO.Conexion
        If (c.Connect) Then
            dt = c.Query("SELECT vIdJas, idCP, vNroDocumento, dFecha, idTipoIngreso, iIdTipoDocumento, vDni, vUsuario, vConcepto, fMonto, vDireccion, vObserv FROM tarIngresosOtros " & condicion)
            c.Close()
        End If
        Return dt
    End Function
    Public Shared Function ListPagos(Optional ByVal condicion As String = "") As DataTable
        Dim dt As New DataTable
        Dim c As New ACCESO.Conexion
        'Dim SQLTEXT As String
        'If (c.Connect) Then

        '    SQLTEXT = " Select * from view_OtrosIngresos  & condicion " _
        '                & " ORDER BY vNroDocumento "
        '    dt = c.Query(SQLTEXT)
        '    c.Close()
        'End If

        If (c.Connect) Then
            Dim strQuery As String = " Select * from view_OtrosIngresos "
            dt = c.Query(strQuery & condicion & " ORDER BY vNroDocumento")
            c.Close()

        End If

        Return dt
        'Return dt
    End Function

    Public Shared Sub elimina(ByVal nroRecibo As String)

        Dim cmd As New SqlCommand()
        Dim c As New ACCESO.Conexion
        Dim pado As New clsPago
        Dim fac As New clsFacturacion
        Dim sql As String

        If (c.Connect) Then

            sql = "update tarIngresosOtros set  cAnulado='1', fMonto=0.00 WHERE vNroDocumento = '" & nroRecibo & "' "
            c.Query(sql)
            c.Close()
        End If
    End Sub

End Class
