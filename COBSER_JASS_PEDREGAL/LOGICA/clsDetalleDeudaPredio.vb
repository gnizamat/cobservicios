Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Data.OleDb
Imports ACCESO
'Imports COBSER.Menu
Imports LOGICA

Public Class clsDetalleDeudaPredio
    Public userSystem As New ACCESO.User
    Private _idJunta As String
    Private _idmes As Integer
    Private _idPredio As Integer
    Private _anio As Integer
    Private _mes As String
    Private _id As Integer
    Private _monto As Single
    Private _volumen As Decimal
    Private _saldo As Single

    Private _idTipoDeuda As Integer
    Private _idTipoTarifa As Integer

    Private _fechadeuda As Date
    Private _fechapago As Date
    Private _concepto As String
    'Private _idTipoTarifa As String

    Private _idSubtipoTarifa As String
    'Private _nroCampania As Integer
    Private _SysUsuario As String
    Private _congelado As Integer
    Private _cPagado As String
    Private _interes As Single


    Public Property volumen() As Decimal
        Get
            Return Me._volumen
        End Get
        Set(ByVal value As Decimal)
            Me._volumen = value
        End Set
    End Property

    Public Property SysUsuario()
        Get
            Return Me._SysUsuario
        End Get
        Set(ByVal value)
            Me._SysUsuario = value
        End Set
    End Property

    Public Property fechadeuda()
        Get
            Return Me._fechadeuda
        End Get
        Set(ByVal value)
            Me._fechadeuda = value
        End Set
    End Property
    Public Property monto()
        Get
            Return Me._monto
        End Get
        Set(ByVal value)
            Me._monto = value
        End Set
    End Property

    Public Property idTipoTarifa()
        Get
            Return Me._idTipoTarifa
        End Get
        Set(ByVal value)
            Me._idTipoTarifa = value
        End Set
    End Property
    Public Property idTipoDeuda()
        Get
            Return Me._idTipoDeuda
        End Get
        Set(ByVal value)
            Me._idTipoDeuda = value
        End Set
    End Property
    Public Property saldo()
        Get
            Return Me._saldo
        End Get
        Set(ByVal value)
            Me._saldo = value
        End Set
    End Property
    Public Property interes()
        Get
            Return Me._saldo
        End Get
        Set(ByVal value)
            Me._interes = value
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
    Public Property idPredio()
        Get
            Return Me._idPredio
        End Get
        Set(ByVal value)
            Me._idPredio = value
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
    Public Property idmes()
        Get
            Return Me._idmes
        End Get
        Set(ByVal value)
            Me._idmes = value
        End Set
    End Property
    Public Property anio()
        Get
            Return Me._anio
        End Get
        Set(ByVal value)
            Me._anio = value
        End Set
    End Property
    Public Property concepto()
        Get
            Return Me._concepto
        End Get
        Set(ByVal value)
            Me._concepto = value
        End Set
    End Property
    Public Property mes()
        Get
            Return Me._mes
        End Get
        Set(ByVal value)
            Me._mes = value
        End Set
    End Property
    Sub New()

    End Sub
    Sub New(ByVal junta As String, ByVal idmes As Integer, ByVal idpredio As Integer, ByVal anio As Integer, ByVal fecha As Date, ByVal monto As Single, ByVal interes As Single, ByVal tipo_deuda As Integer, Optional ByVal idtipo_tarifa As Integer = Nothing, Optional ByVal concepto_deuda As String = "")
        ''(idjas,dgDeudas.Rows(i).Cells(8).Value, idpredio,dgDeudas.Rows(i).Cells(0).Value,   txtFecha.Text, dgDeudas.Rows(i).Cells(7).Value, 1, dgDeudas.Rows(i).Cells(3).Value, dgDeudas.Rows(i).Cells(5).Value)
        Me._idJunta = junta
        Me._idmes = idmes
        Me._idPredio = idpredio
        Me._anio = anio
        Me._fechadeuda = fecha
        'Me._fechapago = IsDBNull()
        Me._monto = Math.Round(monto, 2)
        Me._saldo = Math.Round(monto, 2)

        Me._idTipoDeuda = tipo_deuda
        Me._idTipoTarifa = idtipo_tarifa
        Me._concepto = concepto_deuda

        Me._idTipoDeuda = idTipoDeuda
        'Me._idSubtipoTarifa = idsubtipo_tarifa
        Me._SysUsuario = UCase(userSystem.usuario)

        Me._congelado = "0"
        Me._cPagado = "0"
        Me._interes = Math.Round(interes, 2)
    End Sub
    Public Function NewId()
        Dim c As New ACCESO.Conexion
        Dim dt As New DataTable
        Dim id As Integer
        If (c.Connect) Then
            dt = c.Query("select isNull(max(idDetalleDeuda),0) from tarDetalleDeudaPredio where iAnioTarifa='" & Me._anio & "' and vIdJas='" & Me._idJunta & "'and idPredio='" & Me._idPredio & "'")
            id = dt.Rows(0).Item(0) + 1
            c.Close()
        End If
        Return id
    End Function

    Private Function NewIdOpenConnection(ByRef c As ACCESO.Conexion)
        Dim dt As New DataTable
        Dim id As Integer
        dt = c.Query("select isNull(max(iIdDetalleDeuda),0) from tarDetalleDeudaPredio where iAnioTarifa='" & Me._anio & "' and vIdJas='" & Me._idJunta & "' and iIdPredio='" & Me._idPredio & "'")
        id = dt.Rows(0).Item(0) + 1
        Return id
    End Function
    Public Sub Insert()
        Dim cmd As New SqlCommand()
        Dim c As New ACCESO.Conexion
        Me._id = NewId()
        If (c.Connect) Then
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "sp_tarDetalleDeudaPredio_insert"
            cmd.Parameters.AddWithValue("@IDJAS", Me._idJunta)
            cmd.Parameters.AddWithValue("@ANIO", Me._anio)
            cmd.Parameters.AddWithValue("@IDMES", Me._idmes)
            cmd.Parameters.AddWithValue("@IDPREDIO", Me._idPredio)
            cmd.Parameters.AddWithValue("@ID", Me._id)
            cmd.Parameters.AddWithValue("@IDTIPODEUDA", Me._idTipoDeuda)
            cmd.Parameters.AddWithValue("@IDTIPOTARIFA", Me._idTipoTarifa)
            cmd.Parameters.AddWithValue("@MONTO", Me._monto)
            cmd.Parameters.AddWithValue("@REDONDEO", 0.0)
            cmd.Parameters.AddWithValue("@VOLUMEN", Me._volumen)
            cmd.Parameters.AddWithValue("@CONCEPTO", Me._concepto)
            cmd.Parameters.AddWithValue("@FECHA", Me._fechadeuda)
            cmd.Parameters.AddWithValue("@CPAGADO", Me._cPagado)
            'cmd.Parameters.AddWithValue("@IDTTARIFA", IIf(Me._idTipoTarifa = Nothing, DBNull.Value, Me._idTipoTarifa))
            'cmd.Parameters.AddWithValue("@IDSTTARIFA", IIf(Me._idSubtipoTarifa = Nothing, DBNull.Value, Me._idSubtipoTarifa))
            'cmd.Parameters.AddWithValue("@NROCAMPANIA", Me._nroCampania)
            cmd.Parameters.AddWithValue("@USUARIO", Me._SysUsuario)
            cmd.Parameters.AddWithValue("@CONGELADO", Me._congelado)
            cmd.Parameters.AddWithValue("@INTERES", Me._interes)
            If (c.Insert(cmd) = False) Then
                MsgBox(c.msgError)
            End If
            c.Close()
        End If
    End Sub
    Public Overridable Sub InsertOpenConnection(ByRef c As ACCESO.Conexion)
        Dim cmd As New SqlCommand()
        Me._id = NewIdOpenConnection(c)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "sp_tarDetalleDeudaPredio_insert"
        cmd.Parameters.AddWithValue("@ANIO", Me._anio)
        cmd.Parameters.AddWithValue("@IDJUNTA", Me._idJunta)
        cmd.Parameters.AddWithValue("@IDCOMISION", Me._idmes)
        cmd.Parameters.AddWithValue("@IDPREDIO", Me._idPredio)
        cmd.Parameters.AddWithValue("@ID", Me._id)
        cmd.Parameters.AddWithValue("@IDTIPODEUDA", Me._idTipoDeuda)
        cmd.Parameters.AddWithValue("@MONTO", Me._monto)
        cmd.Parameters.AddWithValue("@INTERES", Me._interes)
        cmd.Parameters.AddWithValue("@FECHA", Me._fechadeuda)
        cmd.Parameters.AddWithValue("@CONCEPTO", Me._concepto)
        cmd.Parameters.AddWithValue("@IDTTARIFA", IIf(Me._idTipoTarifa = Nothing, DBNull.Value, Me._idTipoTarifa))
        'cmd.Parameters.AddWithValue("@IDSTTARIFA", IIf(Me._idSubtipoTarifa = Nothing, DBNull.Value, Me._idSubtipoTarifa))
        'cmd.Parameters.AddWithValue("@NROCAMPANIA", Me._nroCampania)
        cmd.Parameters.AddWithValue("@USUARIO", Me._SysUsuario)


        If (c.Execute(cmd) = False) Then
            MsgBox(c.msgError)
        End If
    End Sub
    Public Sub Update()
        Dim c As New ACCESO.Conexion
        Dim cmd As New SqlCommand()
        If (c.Connect) Then
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "sp_tarDetalleDeudaPredio_update"
            cmd.Parameters.AddWithValue("@ANIO", Me._anio)
            cmd.Parameters.AddWithValue("@IDJUNTA", Me._idJunta)
            cmd.Parameters.AddWithValue("@IDCOMISION", Me._idmes)
            cmd.Parameters.AddWithValue("@IDPREDIO", Me._idPredio)
            cmd.Parameters.AddWithValue("@ID", IIf(Me._id = 0, DBNull.Value, Me._id))
            cmd.Parameters.AddWithValue("@IDTIPODEUDA", Me._idTipoDeuda)
            cmd.Parameters.AddWithValue("@MONTO", Math.Round(Me._monto, 2))
            cmd.Parameters.AddWithValue("@INTERES", Math.Round(Me._interes, 2))
            If (c.Execute(cmd) = False) Then
                MsgBox(c.msgError)
            End If
        End If
    End Sub
    Public Sub UpdateOpenConnection(ByRef c As ACCESO.Conexion)
        Dim cmd As New SqlCommand()

        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "sp_tarDetalleDeudaPredio_update"
        cmd.Parameters.AddWithValue("@ANIO", Me._anio)
        cmd.Parameters.AddWithValue("@IDJUNTA", Me._idJunta)
        cmd.Parameters.AddWithValue("@IDCOMISION", Me._idmes)
        cmd.Parameters.AddWithValue("@IDPREDIO", Me._idPredio)
        cmd.Parameters.AddWithValue("@ID", IIf(Me._id = 0, DBNull.Value, Me._id))
        cmd.Parameters.AddWithValue("@IDTIPODEUDA", Me._idTipoDeuda)
        cmd.Parameters.AddWithValue("@MONTO", Me._monto)
        cmd.Parameters.AddWithValue("@INTERES", Me._interes)
        If (c.Execute(cmd) = False) Then
            MsgBox(c.msgError)
        End If
    End Sub
    Public Shared Sub DescontarDeuda(ByVal anio As Integer, ByVal junta As String, ByVal comision As Integer, ByVal predio As Integer, ByVal detalle As Integer, ByVal monto As Double, ByVal deudatotal As Boolean)
        Dim cmd As New SqlCommand()
        Dim c As New ACCESO.Conexion
        If (c.Connect) Then
            If (deudatotal) Then
                c.Query("update tarDetalleDeudaPredio set fSaldo=0 where iAnioTarifa='" & anio & "' and vIdJuntaUsuario='" & junta & "' and iIdComisionRegante='" & comision & "' and iIdPredio='" & predio & "' and iIdDetalleDeuda='" & detalle & "'")
            Else
                c.Query("update tarDetalleDeudaPredio set fSaldo=fsaldo-" & monto & " where iAnioTarifa='" & anio & "' and vIdJuntaUsuario='" & junta & "' and iIdComisionRegante='" & comision & "' and iIdPredio='" & predio & "' and iIdDetalleDeuda='" & detalle & "'")
            End If

            c.Close()
        End If
    End Sub
    Public Sub DescontarDeuda(ByVal monto As Double)
        Dim cmd As New SqlCommand()
        Dim c As New ACCESO.Conexion
        If (c.Connect) Then
            If (monto > Me._saldo) Then
                Me._saldo = 0
            Else
                Me._saldo = Me._saldo - monto
            End If
            c.Query("update tarDetalleDeudaPredio set fSaldo=" & Me._saldo & " where iAnioTarifa='" & Me._anio & "' and vIdJuntaUsuario='" & Me.idJunta & "' and iIdPredio='" & Me.idPredio & "' and iIdDetalleDeuda='" & Me.id & "'")
            c.Close()
        End If
    End Sub
    Public Sub RecalcularDeuda()
        Dim c As New ACCESO.Conexion
        Dim cmd As New SqlCommand()
        If (c.Connect) Then
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "sp_recalcularDetalleDeuda"
            cmd.Parameters.AddWithValue("@ANIO", Me._anio)
            cmd.Parameters.AddWithValue("@IDJUNTA", Me._idJunta)
            cmd.Parameters.AddWithValue("@IDCOMISION", Me._idmes)
            cmd.Parameters.AddWithValue("@IDPREDIO", Me._idPredio)
            cmd.Parameters.AddWithValue("@IDDETALLEDEUDA", Me._id)
            If (c.Execute(cmd) = False) Then
                MsgBox(c.msgError)
            End If
            c.Close()
        End If
    End Sub
    Public Shared Function List(Optional ByVal condicion As String = "") As DataTable
        Dim dt As New DataTable
        Dim c As New ACCESO.Conexion
        If (c.Connect) Then
            Dim strQuery As String = "select * from view_DetalleDeudaPredios "
            dt = c.Query(strQuery & condicion & " ")
            If (c.msgError <> "") Then
                MsgBox(c.msgError, MsgBoxStyle.Critical)
            End If
            c.Close()
        End If
        Return dt
    End Function
    Public Shared Function List1(ByVal idpredio As Integer) As DataTable
        Dim dt As New DataTable
        Dim c As New ACCESO.Conexion
        If (c.Connect) Then
            'Dim strQuery As String = "  SELECT  tarDetalleDeudaPredio.iAnioTarifa, CASE WHEN idMes = '1' THEN 'Enero' WHEN idMes = '2' THEN 'Febrero' WHEN idMes = '3' THEN 'Marzo' WHEN idMes = '4' THEN 'Abril' WHEN idMes = '5' THEN 'Mayo' WHEN idMes = '6' THEN 'Junio' " _
            ' & " WHEN idMes = '7' THEN 'Julio' WHEN idMes = '8' THEN 'Agosto' WHEN idMes = '9' THEN 'Setiembre' WHEN idMes = '10' THEN 'Octubre' WHEN idMes = '11' THEN 'Noviembre' WHEN idMes = '12' THEN 'Diciembre' END AS MES, tarTipoTarifa.vNombre AS TIPOTARIFA, tarDetalleDeudaPredio.fMonto, tarDetalleDeudaPredio.fInteres, tarDetalleDeudaPredio.fSaldo,tarDetalleDeudaPredio.fVolumen, tarDetalleDeudaPredio.dFechaDeuda, " _
            ' & " tarDetalleDeudaPredio.iIdTipoTarifa, tarDetalleDeudaPredio.idMes, tarDetalleDeudaPredio.idTipoDeuda, tarDetalleDeudaPredio.idPredio, tarDetalleDeudaPredio.idDetalleDeuda, tarDetalleDeudaPredio.vIdJas FROM tarDetalleDeudaPredio INNER JOIN " _
            ' & " tarTipoTarifa ON tarDetalleDeudaPredio.vIdJas = tarTipoTarifa.vIdJas AND tarDetalleDeudaPredio.iIdTipoTarifa = tarTipoTarifa.iIdTipoTarifa"

            Dim strQuery As String = "  SELECT tarDetalleDeudaPredio.iAnioTarifa, CASE WHEN idMes = '1' THEN 'Enero' WHEN idMes = '2' THEN 'Febrero' WHEN idMes = '3' THEN 'Marzo' WHEN idMes = '4' THEN 'Abril' WHEN idMes = '5' THEN 'Mayo' WHEN idMes = '6' THEN 'Junio' WHEN idMes = '7' THEN 'Julio' WHEN idMes = '8' THEN 'Agosto' " _
             & " WHEN idMes = '9' THEN 'Setiembre' WHEN idMes = '10' THEN 'Octubre' WHEN idMes = '11' THEN 'Noviembre' WHEN idMes = '12' THEN 'Diciembre' END AS MES, tarTipoTarifa.vNombre AS TIPOTARIFA, tarDetalleDeudaPredio.fMonto,  tarDetalleDeudaPredio.fSaldo, tarDetalleDeudaPredio.fInteres AS fInteres, SUM(tarDetalleDeudaPredio.fSaldo + tarDetalleDeudaPredio.fInteres) AS MontoTotal, " _
             & " tarDetalleDeudaPredio.fVolumen, tarDetalleDeudaPredio.dFechaDeuda, tarDetalleDeudaPredio.iIdTipoTarifa, tarDetalleDeudaPredio.idMes, tarDetalleDeudaPredio.idTipoDeuda, tarDetalleDeudaPredio.idPredio, tarDetalleDeudaPredio.idDetalleDeuda, tarDetalleDeudaPredio.vIdJas " _
             & " FROM tarDetalleDeudaPredio INNER JOIN tarTipoTarifa ON tarDetalleDeudaPredio.vIdJas = tarTipoTarifa.vIdJas AND tarDetalleDeudaPredio.iIdTipoTarifa = tarTipoTarifa.iIdTipoTarifa " _
             & "  WHERE  idPredio='" & idpredio & "' and idTipoDeuda<=4 " _
             & " GROUP BY tarDetalleDeudaPredio.iAnioTarifa, tarTipoTarifa.vNombre, tarDetalleDeudaPredio.fMonto, tarDetalleDeudaPredio.fInteres, tarDetalleDeudaPredio.fSaldo, tarDetalleDeudaPredio.fVolumen, tarDetalleDeudaPredio.dFechaDeuda, tarDetalleDeudaPredio.iIdTipoTarifa, tarDetalleDeudaPredio.idMes, tarDetalleDeudaPredio.idTipoDeuda, tarDetalleDeudaPredio.idPredio, tarDetalleDeudaPredio.idDetalleDeuda, tarDetalleDeudaPredio.vIdJas"
            dt = c.Query(strQuery)
            If (c.msgError <> "") Then
                MsgBox(c.msgError, MsgBoxStyle.Critical)
            End If
            c.Close()
        End If
        Return dt
    End Function
    Public Shared Function List_OpenConection(ByRef c As ACCESO.Conexion, Optional ByVal condicion As String = "") As DataTable
        Dim dt As New DataTable
        Dim strQuery As String = "select * from view_DetalleDeudaPredios with(NOLOCK) "
        dt = c.Query(strQuery & condicion & " ")
        Return dt
    End Function
    Public Shared Function delete(ByVal idpredio, ByVal iddetalledeuda, ByVal anio, ByVal idjas, ByVal idmes) As Boolean
        Dim c As New ACCESO.Conexion
        'If (c.Connect) Then
        '    Dim strQuery As String = "DELETE from tarDetalleDeudaPredio "
        '    'dt = c.Query(strQuery & condicion & "")


        '    c.Close()
        '    If (c.msgError.CompareTo("") <> 0) Then
        '        MsgBox(c.msgError)
        '    End If
        'End If
        If (c.Connect) Then
            If (c.Delete("delete  from tarDetalleDeudaPredio  where idpredio=" & idpredio & " and  idDetalleDeuda=" & iddetalledeuda & " and iAnioTarifa= " & anio & " and vIdJas='" & idjas & "' and idmes=" & idmes & "")) Then


            Else
                MsgBox("No se puede elminar el registro porque existen datos vinculados al mismo", MsgBoxStyle.Critical)
                c.Close()
                Return False
            End If
            c.Close()
        End If
        Return True
    End Function

End Class
