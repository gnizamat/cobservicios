Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Data.OleDb
Imports ACCESO
Imports LOGICA
Public Class clsAsignarServicios
    Private _vIdJas As String
    Private _idpredio As Integer
    Private _idTipotarifa As Integer
    Private _dFechaRegistro As Date
    Private _vReferencia As String
    Private _vObservaciones As String
    Private _cUsuario As String
    Private _cEstado As String


    Public Property vIdJas()
        Get
            Return Me._vIdJas
        End Get
        Set(ByVal value)
            Me._vIdJas = value
            'Me.Comision.Junta.id = value
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
    Public Property idTipoTarifa()
        Get
            Return Me._idTipotarifa
        End Get
        Set(ByVal value)
            Me._idTipotarifa = value
        End Set
    End Property
    Public Property Fecha()
        Get
            Return Me._dFechaRegistro
        End Get
        Set(ByVal value)
            Me._dFechaRegistro = value
        End Set
    End Property
    Public Property Referencia()
        Get
            Return Me._vReferencia
        End Get
        Set(ByVal value)
            Me._vReferencia = value
        End Set
    End Property
    Public Property Observaciones()
        Get
            Return Me._vObservaciones
        End Get
        Set(ByVal value)
            Me._vObservaciones = value
        End Set
    End Property



    Public Property Usuario()
        Get
            Return Me._cUsuario
        End Get
        Set(ByVal value)
            Me._cUsuario = value
        End Set
    End Property
    'Public Property UsuarioSys()
    '    Get
    '        Return Me._vUsuario
    '    End Get
    '    Set(ByVal value)
    '        Me._vUsuario = value
    '    End Set
    'End Property
    Public Property Estado()
        Get
            Return Me._cEstado
        End Get
        Set(ByVal value)
            Me._cEstado = value
        End Set
    End Property

    Public Shared Function ListaPrediosServicio(ByVal Idcalle As Integer, ByVal idtipo As Integer) As DataTable
        Dim dt As New DataTable
        Dim c As New ACCESO.Conexion
        

        Dim SQLTEXT As String
        If (c.Connect) Then
            SQLTEXT = "  SELECT     Padusuario.vDni + ' ' + Padusuario.vRuc AS Documento, padUsuarioPredio.iIdusuario, padPredio.idpredio," _
             & " CASE dbo.Padusuario.cTipoPersona WHEN '1' THEN 'Natural' WHEN '2' THEN 'Juridica' WHEN '3' THEN 'Institucional' END AS TipoPersona, " _
             & " CASE WHEN dbo.padUsuario.cTipoPersona = '1' THEN (dbo.padUsuario.vApePaterno + ' ' + dbo.padUsuario.vApeMaterno + ',  ' + dbo.padUsuario.vUsuario)" _
             & " ELSE dbo.padUsuario.vUsuario END AS Usuario,padUsuario.vApePaterno,padUsuario.vApeMaterno,dbo.padUsuario.vUsuario as Nombre, CASE dbo.padPredio.idtpredio WHEN '1' THEN 'Vivienda' WHEN '2' THEN 'Comercial' WHEN '3' THEN 'Cementerio' END AS TipoPredio, " _
             & " padPredio.vNroPredio, padPredio.vNombre, padPredio.idcalle, padPredio.vIdJas,'' as TipoServicio,'' as idServicio" _
             & " FROM Padusuario INNER JOIN " _
             & " padPredio INNER JOIN " _
             & " padUsuarioPredio ON padPredio.vIdJas = padUsuarioPredio.vIdJas AND padPredio.idpredio = padUsuarioPredio.idpredio ON Padusuario.vIdJas = padUsuarioPredio.vIdJas AND " _
             & " Padusuario.iIdUsuario = padUsuarioPredio.iIdusuario" _
             & " WHERE (padUsuarioPredio.cEstado = '1') AND  padPredio.idpredio NOT IN (SELECT idpredio FROM  padPredioServicio WHERE idpredio=padPredio.idpredio and iIdTipoTarifa = " & idtipo & ")" _
            & "  and padPredio.idcalle LIKE " & Idcalle & ""
            dt = c.Query(SQLTEXT)
            c.Close()
        End If
        Return dt

    End Function

    Public Shared Function ListaPrediosServicioUnico(ByVal Idcalle As Integer, ByVal idtipo As Integer) As DataTable
        Dim dt As New DataTable
        Dim c As New ACCESO.Conexion


        Dim SQLTEXT As String
        If (c.Connect) Then
            SQLTEXT = "  SELECT     Padusuario.vDni + ' ' + Padusuario.vRuc AS Documento, padUsuarioPredio.iIdusuario, padPredio.idpredio," _
             & " CASE dbo.Padusuario.cTipoPersona WHEN '1' THEN 'Natural' WHEN '2' THEN 'Juridica' WHEN '3' THEN 'Institucional' END AS TipoPersona, " _
             & " CASE WHEN dbo.padUsuario.cTipoPersona = '1' THEN (dbo.padUsuario.vApePaterno + ' ' + dbo.padUsuario.vApeMaterno + ',  ' + dbo.padUsuario.vUsuario)" _
             & " ELSE dbo.padUsuario.vUsuario END AS Usuario,padUsuario.vApePaterno,padUsuario.vApeMaterno,dbo.padUsuario.vUsuario as Nombre, CASE dbo.padPredio.idtpredio WHEN '1' THEN 'Vivienda' WHEN '2' THEN 'Comercial' WHEN '3' THEN 'Cementerio' END AS TipoPredio, " _
             & " padPredio.vNroPredio, padPredio.vNombre, padPredio.idcalle, padPredio.vIdJas,'' as TipoServicio,'' as idServicio" _
             & " FROM Padusuario INNER JOIN " _
             & " padPredio INNER JOIN " _
             & " padUsuarioPredio ON padPredio.vIdJas = padUsuarioPredio.vIdJas AND padPredio.idpredio = padUsuarioPredio.idpredio ON Padusuario.vIdJas = padUsuarioPredio.vIdJas AND " _
             & " Padusuario.iIdUsuario = padUsuarioPredio.iIdusuario" _
             & " WHERE (padUsuarioPredio.cEstado = '1') AND  padPredio.idpredio NOT IN (SELECT idpredio FROM  padPredioServicio WHERE idpredio=padPredio.idpredio )" _
            & "  and padPredio.idcalle LIKE " & Idcalle & ""
            dt = c.Query(SQLTEXT)
            c.Close()
        End If
        Return dt

    End Function

    Public Function Insert(ByVal idTipoServicio As Integer, ByVal servicio As String) As Boolean
        Dim cmd As New SqlCommand()
        Dim c As New ACCESO.Conexion
        'Dim sql As String


        If (c.Connect) Then
            cmd.CommandText = "INSERT INTO padPredioServicio( vIdJas, idpredio, iIdTipoTarifa, dFechaRegistro, vReferencia, vObservaciones, cUsuario, cEstado)" _
                            & "VALUES (@IDJAS,@IDPREDIO,@IDTIPOTARIFA,@DFECHA,@REFEREN,@OBSER,@USUARIO,@ESTADO)"
            cmd.Parameters.AddWithValue("@IDJAS", Me._vIdJas)
            cmd.Parameters.AddWithValue("@IDPREDIO", Me._idpredio)
            cmd.Parameters.AddWithValue("@IDTIPOTARIFA", Me._idTipotarifa)
            cmd.Parameters.AddWithValue("@DFECHA", Me._dFechaRegistro)
            cmd.Parameters.AddWithValue("@REFEREN", Me._vReferencia)
            cmd.Parameters.AddWithValue("@OBSER", Me._vObservaciones)
            cmd.Parameters.AddWithValue("@USUARIO", Me._cUsuario)
            cmd.Parameters.AddWithValue("@ESTADO", Me._cEstado)

            'c.IniTransaction()
            If (c.Insert(cmd) = False) Then
                MsgBox(c.msgError)
            End If
            c.Close()

        End If
    End Function
End Class
