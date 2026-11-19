Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Data.OleDb
Imports ACCESO
Imports LOGICA

Public Class clsPredios
    Private _id As Integer
    Private _vIdJas As String
    Private _iIdusuario As Integer
    Private _idpredio As Integer
    Private _idtpredio As Integer
    Private _iIdDistrito As Integer
    Private _idsector As Integer
    Private _idcalle As Integer
    Private _vNombre As String
    Private _idTipoDocumento As Integer
    Private _dFechaDoc As String
    Private _vTitulo As String
    Private _vpartidaR As String
    Private _vUC As String
    Private _vNroPredio As String
    Private _mzPredio As String
    Private _lotePredio As String
    Private _dFechaRegistro As Date
    Private _dFechaActualizacion As Date
    Private _vCEste As String
    Private _vCNorte As String
    Private _cEstadoPredio As String
    'Private _cEstado As String
    Private _estado As String = "1"
    Private _idcp As Integer



    Public Property estado()
        Get
            Return Me._estado
        End Get
        Set(ByVal value)
            Me._estado = value
        End Set
    End Property
    Public Property cEstadoPredio() As String
        Get
            Return Me._cEstadoPredio
        End Get
        Set(ByVal value As String)
            Me._cEstadoPredio = value
        End Set
    End Property
    Public Property iIdDistrito()
        Get
            Return Me._iIdDistrito
        End Get
        Set(ByVal value)
            Me._iIdDistrito = value
        End Set
    End Property
    Public Property idpredio()
        Get
            Return Me._idpredio
        End Get
        Set(ByVal value)
            Me._idpredio = value
        End Set
    End Property
    Public Property idcalle()
        Get
            Return Me._idcalle
        End Get
        Set(ByVal value)
            Me._idcalle = value
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
    Public Property dFechaRegistro()
        Get
            Return Me._dFechaRegistro
        End Get
        Set(ByVal value)
            Me._dFechaRegistro = value
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
    Public Property vUC() As String
        Get
            Return Me._vUC
        End Get
        Set(ByVal value As String)
            Me._vUC = value
        End Set
    End Property
    
    Public Property vIdJas()
        Get
            Return Me._vIdJas
        End Get
        Set(ByVal value)
            Me._vIdJas = value
            'Me.Comision.Junta.id = value
        End Set
    End Property

    Sub New(ByVal vIdJas As String, ByVal iIdusuario As Integer, ByVal idtpredio As Integer, ByVal iIdDistrito As Integer, ByVal idsector As Integer, ByVal idcalle As Integer, ByVal vNombre As String, ByVal idTipoDocumento As Integer, ByVal dfechaDoc As String, ByVal vTitulo As String, ByVal vNroPredio As String, ByVal vpartidaR As String, ByVal vUC As String, ByVal mzPredio As String, ByVal lotePredio As String, ByVal dFechaRegistro As String, ByVal dFechaActualizacion As String, ByVal idcp As Integer, Optional ByVal vCEste As String = "", Optional ByVal vCNorte As String = "")
        Me._vIdJas = vIdJas
        Me._iIdusuario = iIdusuario
        'Me._idpredio = idpredio
        Me._idtpredio = idtpredio
        Me._iIdDistrito = iIdDistrito
        Me._idsector = idsector
        Me._idcalle = idcalle
        Me._vNombre = vNombre
        Me._idTipoDocumento = idTipoDocumento
        Me._dFechaDoc = dfechaDoc
        Me._vTitulo = vTitulo
        Me._vNroPredio = vNroPredio

        Me._vpartidaR = vpartidaR
        Me._vUC = vUC

        Me._mzPredio = mzPredio
        Me._lotePredio = lotePredio
        Me._dFechaRegistro = dFechaRegistro
        Me._dFechaActualizacion = dFechaActualizacion
        Me._vCEste = vCEste
        Me._vCNorte = vCNorte
        Me._cEstadoPredio = "1"
        Me._idcp = idcp
    End Sub
    Public Shared Function List(Optional ByVal condicion As String = "", Optional ByVal estado As String = "", Optional ByVal sector As String = "", Optional ByVal calle As String = "") As DataTable
        Dim dt As New DataTable
        Dim c As New ACCESO.Conexion
        If (c.Connect) Then
            Dim strQuery As String = "SELECT * FROM view_PrediosBasico where cEstado like '" & estado & "%'"
            dt = c.Query(strQuery & condicion)
            c.Close()
        End If
        Return dt
    End Function
    Private Function NewId()
        Dim c As New ACCESO.Conexion
        Dim dt As New DataTable
        Dim id As Integer
        If (c.Connect) Then
            dt = c.Query("select isnull(max(idPredio),0) from padPredio where vIdJas='" & Me._vIdJas & "'")
            id = dt.Rows(0).Item(0) + 1
            c.Close()
        End If
        Return id
    End Function
    Public Sub Insert()
        'If Not c.OpenConnection Then
        '    Return False
        'End If
        Dim cmd As New SqlCommand()
        Dim c As New ACCESO.Conexion
        Me._idpredio = Me.NewId
        If (c.Connect) Then
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "padPredio_insert"
            cmd.Parameters.AddWithValue("@P_1", Me._vIdJas)
            cmd.Parameters.AddWithValue("@P_2", Me._iIdusuario)
            cmd.Parameters.AddWithValue("@P_3", Me._idpredio)
            cmd.Parameters.AddWithValue("@P_4", Me._idtpredio)
            cmd.Parameters.AddWithValue("@P_5", Me._iIdDistrito)
            cmd.Parameters.AddWithValue("@P_6", Me._idsector)
            cmd.Parameters.AddWithValue("@P_7", Me._idcalle)

            cmd.Parameters.AddWithValue("@P_8", Me._vNombre)
            cmd.Parameters.AddWithValue("@P_9", Me._idTipoDocumento)
            cmd.Parameters.AddWithValue("@P_10", Me._dFechaDoc)
            cmd.Parameters.AddWithValue("@P_11", Me._vTitulo)
            cmd.Parameters.AddWithValue("@P_12", Me._vNroPredio)
            cmd.Parameters.AddWithValue("@P_13", Me._vpartidaR)
            cmd.Parameters.AddWithValue("@P_14", Me._vUC)

            cmd.Parameters.AddWithValue("@P_15", Me._mzPredio)
            cmd.Parameters.AddWithValue("@P_16", Me._lotePredio)
            'vNroPredio

            cmd.Parameters.AddWithValue("@P_17", ACCESO.Conexion.getDatetimeServer)
            cmd.Parameters.AddWithValue("@P_18", ACCESO.Conexion.getDatetimeServer)
            cmd.Parameters.AddWithValue("@P_19", Me._vCEste)
            cmd.Parameters.AddWithValue("@P_20", Me._vCNorte)
            cmd.Parameters.AddWithValue("@P_21", Me._cEstadoPredio)
            cmd.Parameters.AddWithValue("@P_22", "1")
            cmd.Parameters.AddWithValue("@P_23", Me._idcp)


            If (c.Insert(cmd) = False) Then
                MsgBox(c.msgError)
            End If
            c.Close()
        End If
        'Private _vIdJas As String
        'Private _iIdusuario As Integer
        'Private _idpredio As Integer
        'Private _idtpredio As Integer
        'Private _iIdDistrito As Integer
        'Private _idsector As Integer
        'Private _idcalle As Integer
        'Private _vNombre As String
        'Private _idTipoDocumento As Integer
        'Private _dFechaDoc As Date
        'Private _vTitulo As String
        'Private _vpartidaR As String
        'Private _vUC As String
        'Private _vNroPredio As String
        'Private _mzPredio As String
        'Private _lotePredio As String
        'Private _dFechaRegistro As Date
        'Private _dFechaActualizacion As Date
        'Private _vCEste As String
        'Private _vCNorte As String
        'Private _cEstadoPredio As String
        ''Private _cEstado As String
        'Private _estado As String = "1"


    End Sub
    Public Sub update()
        'If Not c.OpenConnection Then
        '    Return False
        'End If
        Dim cmd As New SqlCommand()
        Dim c As New ACCESO.Conexion
        If (c.Connect) Then
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "padPredio_update"
            'cmd.Parameters.AddWithValue("@P_1", Me._vIdJas)
            cmd.Parameters.AddWithValue("@P_2", Me._iIdusuario)
            cmd.Parameters.AddWithValue("@P_3", Me._id)
            cmd.Parameters.AddWithValue("@P_4", Me._idtpredio)
            cmd.Parameters.AddWithValue("@P_5", Me._iIdDistrito)
            cmd.Parameters.AddWithValue("@P_6", Me._idsector)
            cmd.Parameters.AddWithValue("@P_7", Me._idcalle)

            cmd.Parameters.AddWithValue("@P_8", Me._vNombre)
            cmd.Parameters.AddWithValue("@P_9", Me._idTipoDocumento)
            cmd.Parameters.AddWithValue("@P_10", Me._dFechaDoc)
            cmd.Parameters.AddWithValue("@P_11", Me._vTitulo)
            cmd.Parameters.AddWithValue("@P_12", Me._vNroPredio)
            cmd.Parameters.AddWithValue("@P_13", Me._vpartidaR)
            cmd.Parameters.AddWithValue("@P_14", Me._vUC)

            cmd.Parameters.AddWithValue("@P_15", Me._mzPredio)
            cmd.Parameters.AddWithValue("@P_16", Me._lotePredio)
            'vNroPredio

            'cmd.Parameters.AddWithValue("@P_17", ACCESO.Conexion.getDatetimeServer)
            cmd.Parameters.AddWithValue("@P_17", ACCESO.Conexion.getDatetimeServer)
            cmd.Parameters.AddWithValue("@P_18", Me._vCEste)
            cmd.Parameters.AddWithValue("@P_19", Me._vCNorte)
            cmd.Parameters.AddWithValue("@P_20", Me._cEstadoPredio)
            cmd.Parameters.AddWithValue("@P_21", "1")
            cmd.Parameters.AddWithValue("@P_23", Me._idcp)

            If (c.Update(cmd) = False) Then
                MsgBox(c.msgError)
            End If
            c.Close()
        End If

    End Sub
    Private Function NewIdUsuario(ByVal idusuario As String, ByVal idjunta As String)
        Dim c As New ACCESO.Conexion
        Dim dt As New DataTable
        Dim id As Integer
        If (c.Connect) Then
            dt = c.Query("select isNull(max(iCorrelativo),0) from padUsuarioPredio where idPredio='" & Me.id & "' and vIdJas='" & vIdJas & "' and iIdUsuario='" & idusuario & "'")
            id = CInt(dt.Rows(0).Item(0).ToString) + 1
            c.Close()
        End If
        Return id
    End Function
    Public Sub addUsuario(ByVal idUsuario As Integer)
        Dim c As New ACCESO.Conexion
        Dim cmd As New SqlCommand()
        Dim dtfecha As Date = Date.Now
        If (c.Connect) Then
            c.Query("UPDATE padUsuarioPredio set cEstado=0 where cEstado=1 and vIdJas='" & Me._vIdJas & "' and idPredio='" & Me.idpredio & "' ")
            cmd.CommandText = "INSERT INTO padUsuarioPredio(vIdJas,iIdUsuario,idPredio,iCorrelativo, dFechaRegistro,cEstado) values(@IDJAS,@IDUSUARIO,@IDPREDIO,1,@FINI,1)"
            cmd.Parameters.AddWithValue("@IDJAS", Me._vIdJas)
            cmd.Parameters.AddWithValue("@IDUSUARIO", Me._iIdusuario)
            cmd.Parameters.AddWithValue("@IDPREDIO", Me._idpredio)
            'cmd.Parameters.AddWithValue("@IDCORRE", 1)
            cmd.Parameters.AddWithValue("@FINI", ACCESO.Conexion.getDatetimeServer)
            'cmd.Parameters.AddWithValue("@ESTADO", 1)
            'cmd.Parameters.AddWithValue("@IDJUNTAPREDIO", Me._vIdJas)
            'cmd.Parameters.AddWithValue("@IDJUNTA", idJunta)

            If (c.Insert(cmd) = False) Then
                MsgBox(c.msgError)
            End If
            c.Close()
        End If

    End Sub
    'Public Function getUsuarioActual() As clsUsuario
    '    Dim usuario As New clsUsuario
    '    Dim dt As New DataTable
    '    Dim c As New ACCESO.Conexion

    '    If (c.Connect) Then
    '        dt = c.Query("select iIdUsuario,vIdJuntaUsuario,iCorrelativo from padUsuarioPredio where iIdPredio='" & Me._id & "' cEstado=1")
    '        If (dt.Rows.Count > 0) Then
    '            usuario.id = Val(dt.Rows(0).Item("iIdUsuario").ToString)
    '            usuario.idJas = dt.Rows(0).Item("vIdJuntaUsuario").ToString
    '            usuario.id = dt.Rows(0).Item("iCorrelativo").ToString
    '        End If
    '        c.Close()
    '    End If

    '    Return usuario
    'End Function

    Public Shared Sub elimina(ByVal id)
        Dim cmd As New SqlCommand()
        Dim c As New ACCESO.Conexion

        If (c.Connect) Then
            cmd.CommandText = ("update padPredio set cEstado=0 where idPredio='" & id & "'")
            cmd.CommandText = ("update padUsuarioPredio set cEstado=0 where idPredio='" & id & "'")
            c.Update(cmd)
            c.Close()
            If (c.msgError.CompareTo("") <> 0) Then
                MsgBox(c.msgError)
            End If
        End If
    End Sub
End Class

