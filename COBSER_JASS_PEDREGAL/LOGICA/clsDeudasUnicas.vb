Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Data.OleDb
Imports ACCESO
Imports LOGICA
Public Class clsDeudasUnicas
    Private _vIdJas As String
    Private _iAnioTarifa As Integer
    Private _idMes As Integer
    Private _idPredio As Integer
    Private _idDetalleDeuda As Integer
    Private _idTipoDeuda As Integer
    Private _iIdTipoTarifa As Integer
    Private _idCuota As Integer
    Private _fMonto As Double
    Private _fSaldo As Double
    Private _fVolumen As Double
    Private _vConcepto As String
    Private _dFechaDeuda As Date
    Private _dFechaPago As Date
    Private _cPagado As String
    Private _vUsuario As String
    Private _cCongelado As String

    Public Property IdJAS()
        Get
            Return Me._vIdJas
        End Get
        Set(ByVal value)
            Me._vIdJas = value
        End Set
    End Property
    Public Property Año()
        Get
            Return Me._iAnioTarifa
        End Get
        Set(ByVal value)
            Me._iAnioTarifa = value
        End Set
    End Property
    Public Property Mes()
        Get
            Return Me._idMes
        End Get
        Set(ByVal value)
            Me._idMes = value
        End Set
    End Property
    Public Property Predio()
        Get
            Return Me._idPredio
        End Get
        Set(ByVal value)
            Me._idPredio = value
        End Set
    End Property
    Public Property DetalleDeuda()
        Get
            Return Me._idDetalleDeuda
        End Get
        Set(ByVal value)
            Me._idDetalleDeuda = value
        End Set
    End Property
    Public Property TipoDeuda()
        Get
            Return Me._idTipoDeuda
        End Get
        Set(ByVal value)
            Me._idTipoDeuda = value
        End Set
    End Property
    Public Property TipoTarifa()
        Get
            Return Me._iIdTipoTarifa
        End Get
        Set(ByVal value)
            Me._iIdTipoTarifa = value
        End Set
    End Property
    Public Property Monto()
        Get
            Return Me._fMonto
        End Get
        Set(ByVal value)
            Me._fMonto = value
        End Set
    End Property
    Public Property Saldo()
        Get
            Return Me._fSaldo
        End Get
        Set(ByVal value)
            Me._fSaldo = value
        End Set
    End Property
    Public Property Volumen()
        Get
            Return Me._fVolumen
        End Get
        Set(ByVal value)
            Me._fVolumen = value
        End Set
    End Property
    Public Property Concepto()
        Get
            Return Me._vConcepto
        End Get
        Set(ByVal value)
            Me._vConcepto = value
        End Set
    End Property
    Public Property FechaDeuda()
        Get
            Return Me._dFechaDeuda
        End Get
        Set(ByVal value)
            Me._dFechaDeuda = value
        End Set
    End Property
    Public Property FechaPago()
        Get
            Return Me._dFechaPago
        End Get
        Set(ByVal value)
            Me._dFechaPago = value
        End Set
    End Property
    Public Property Pagado()
        Get
            Return Me._cPagado
        End Get
        Set(ByVal value)
            Me._cPagado = value
        End Set
    End Property
    Public Property UsuarioSys()
        Get
            Return Me._vUsuario
        End Get
        Set(ByVal value)
            Me._vUsuario = value
        End Set
    End Property
    Public Property Congelado()
        Get
            Return Me._cCongelado
        End Get
        Set(ByVal value)
            Me._cCongelado = value
        End Set
    End Property
    Private Function NewId(ByVal Idaño As Integer, ByVal predio As Integer)
        Dim c As New ACCESO.Conexion
        Dim dt As New DataTable
        Dim id As Integer
        If (c.Connect) Then
            dt = c.Query("select isNull(max(IdDetalleDeuda),0) from tarDetalleDeudaPredio where iAnioTarifa='" & Idaño & "' and vIdJas='" & Me._vIdJas & "' and IdPredio='" & predio & "'")
            c.Close()
            id = dt.Rows(0).Item(0) + 1
        End If
        Return id
    End Function

    Public Function Insert(ByVal Idcalle As Integer, ByVal Idaño As Integer, ByVal Idmes As Integer, ByVal predio As Integer, ByVal idcuota As Integer, ByVal montocuota As Double) As Boolean
        Dim cmd As New SqlCommand()
        Dim c As New ACCESO.Conexion

        Me._idDetalleDeuda = Me.NewId(Idaño, predio)
        If (c.Connect) Then
            cmd.CommandText = "INSERT INTO tarDetalleDeudaPredio (vIdJas, iAnioTarifa, idMes, idPredio, idDetalleDeuda, idTipoDeuda, iIdTipoTarifa, fMonto, fSaldo,fRedondeo, fVolumen, vConcepto, dFechaDeuda, dFechaPago, cPagado, vUsuario, cCongelado)" _
                            & " VALUES(@IDJAS, @ANIO,@MES,@PRED,@IDEDETDEUDA,@IDTIPODEUDA,@TIPOTARIFA,@MONTO,@SALDO,0,@VOLUMEN,@CONCEPTO,@FDEUDA,null,@PAGADO,@USUARIO,@CONGELADO)"
            cmd.Parameters.AddWithValue("@IDJAS", Me._vIdJas)
            cmd.Parameters.AddWithValue("@ANIO", Idaño)
            cmd.Parameters.AddWithValue("@MES", Idmes)
            cmd.Parameters.AddWithValue("@PRED", predio)
            cmd.Parameters.AddWithValue("@IDEDETDEUDA", Me._idDetalleDeuda)
            cmd.Parameters.AddWithValue("@IDTIPODEUDA", Me._idTipoDeuda)
            cmd.Parameters.AddWithValue("@TIPOTARIFA", Me._iIdTipoTarifa)
            cmd.Parameters.AddWithValue("@MONTO", montocuota)
            cmd.Parameters.AddWithValue("@SALDO", montocuota)
            cmd.Parameters.AddWithValue("@VOLUMEN", Me._fVolumen)
            cmd.Parameters.AddWithValue("@CONCEPTO", Concepto)
            cmd.Parameters.AddWithValue("@FDEUDA", Me._dFechaDeuda)
            'cmd.Parameters.AddWithValue("@FPAGO", DBNull.Value)
            cmd.Parameters.AddWithValue("@PAGADO", Me._cPagado)
            cmd.Parameters.AddWithValue("@USUARIO", Me._vUsuario)
            cmd.Parameters.AddWithValue("@CONGELADO", Me._cCongelado)

            c.IniTransaction()
            If (c.Insert(cmd) = False) Then
                MsgBox(c.msgError)
            End If
            If (Not c.myError) Then
                c.Commit()
                'MsgBox("Facturación Generada para el mes de " & Idmes & " del año " & Idaño & "  Satisfactoriamente", MsgBoxStyle.Information)
                Return True
            Else
                c.RollBack()
                'MsgBox("Ocurrio un error mientras se generaba la facturación. Se cancelo el proceso de Importación", MsgBoxStyle.Critical)
                Return False
            End If
        End If
    End Function

    Public Shared Function ListaServciosUnicos(ByVal Idcalle As Integer, ByVal idtipo As Integer) As DataTable
        Dim dt As New DataTable
        Dim c As New ACCESO.Conexion


        Dim SQLTEXT As String
        If (c.Connect) Then
            'SQLTEXT = "  SELECT     Padusuario.vDni + ' ' + Padusuario.vRuc AS Documento, padUsuarioPredio.iIdusuario, padPredio.idpredio," _
            ' & " CASE dbo.Padusuario.cTipoPersona WHEN '1' THEN 'Natural' WHEN '2' THEN 'Juridica' WHEN '3' THEN 'Institucional' END AS TipoPersona, " _
            ' & " CASE WHEN dbo.padUsuario.cTipoPersona = '1' THEN (dbo.padUsuario.vApePaterno + ' ' + dbo.padUsuario.vApeMaterno + ',  ' + dbo.padUsuario.vUsuario)" _
            ' & " ELSE dbo.padUsuario.vUsuario END AS Usuario,padUsuario.vApePaterno,padUsuario.vApeMaterno,dbo.padUsuario.vUsuario as Nombre, CASE dbo.padPredio.idtpredio WHEN '1' THEN 'Vivienda' WHEN '2' THEN 'Comercial' WHEN '3' THEN 'Cementerio' END AS TipoPredio, " _
            ' & " padPredio.vNroPredio, padPredio.vNombre, padPredio.idcalle, padPredio.vIdJas,'' as TipoServicio,'' as idServicio" _
            ' & " FROM Padusuario INNER JOIN " _
            ' & " padPredio INNER JOIN " _
            ' & " padUsuarioPredio ON padPredio.vIdJas = padUsuarioPredio.vIdJas AND padPredio.idpredio = padUsuarioPredio.idpredio ON Padusuario.vIdJas = padUsuarioPredio.vIdJas AND " _
            ' & " Padusuario.iIdUsuario = padUsuarioPredio.iIdusuario" _
            ' & " WHERE (padUsuarioPredio.cEstado = '1') AND  padPredio.idpredio NOT IN (SELECT idpredio FROM  padPredioServicio WHERE idpredio=padPredio.idpredio and idTipoTarifa = " & idtipo & ")" _
            '& "  and padPredio.idcalle LIKE " & Idcalle & ""


            SQLTEXT = " SELECT view_PrediosServicio.Documento, view_PrediosServicio.idpredio, view_PrediosServicio.Usuario, view_PrediosServicio.vApePaterno, view_PrediosServicio.vApeMaterno, " _
            & " view_PrediosServicio.Nombre, view_PrediosServicio.TipoPredio, view_PrediosServicio.vNroPredio, view_PrediosServicio.vNombre, view_PrediosServicio.idcalle, view_PrediosServicio.vIdJas, " _
            & " view_PrediosServicio.iIdTipoTarifa,view_PrediosServicio.TipoServicio " _
            & " FROM view_PrediosServicio INNER JOIN " _
            & " tarTipoTarifa ON view_PrediosServicio.vIdJas = tarTipoTarifa.vIdJas AND view_PrediosServicio.iIdTipoTarifa = tarTipoTarifa.iIdTipoTarifa " _
            & " WHERE (tarTipoTarifa.cTipo = 2) AND (view_PrediosServicio.cEstado = '1')and  view_PrediosServicio.iIdTipoTarifa=" & idtipo & " AND view_PrediosServicio.idcalle=" & Idcalle & "" _
            & " AND  view_PrediosServicio.idpredio NOT IN (SELECT  tarDetalleDeudaPredio.idPredio FROM  padPredio INNER JOIN tarDetalleDeudaPredio ON padPredio.vIdJas = tarDetalleDeudaPredio.vIdJas AND padPredio.idpredio = tarDetalleDeudaPredio.idPredio " _
             & " WHERE     (padPredio.idcalle = " & Idcalle & " )  AND (tarDetalleDeudaPredio.iIdTipoTarifa =  " & idtipo & "))"
            dt = c.Query(SQLTEXT)
            c.Close()
        End If
        Return dt


    End Function

    Public Shared Function ListaGenerarMultas(ByVal Idcalle As Integer, ByVal idtipo As Integer) As DataTable
        Dim dt As New DataTable
        Dim c As New ACCESO.Conexion


        Dim SQLTEXT As String
        If (c.Connect) Then

            SQLTEXT = " SELECT vDni + ' ' + vRuc AS Documento, iIdusuario, idpredio, usuario, vApePaterno, vApeMaterno, vUsuario, vNombre, TipoPredio, idcalle " _
             & " FROM     view_PrediosBasico AS vp " _
             & " WHERE  (cEstado = '1') AND (NOT EXISTS " _
             & " (SELECT 1 AS Expr1 " _
             & " FROM      PAD_ASISTENCIAUSUARIOS AS pa " _
             & " WHERE   (iIdUsuario = vp.iIdusuario) AND (idPredio = vp.idpredio) AND (Asistencia = 1))) AND (idcalle like " & Idcalle & " )"
            dt = c.Query(SQLTEXT)
            c.Close()
        End If
        Return dt


    End Function

    'Public Function calcula_cuotas_medidor(ByVal monto As Double, ByVal nrocuotas As Integer) As DataTable

    '    Dim cuotas As New DataTable

    '    'Dim acumulado As Double
    '    Dim cuotaredondeo As Double
    '    Dim sumcuotas As Double
    '    Dim montoredondeado As Double

    '    'ReDim cuotas(nrocuotas)
    '    cuotaredondeo = Math.Round(monto / nrocuotas, 1)
    '    sumcuotas = cuotaredondeo * nrocuotas
    '    montoredondeado = sumcuotas - monto

    '    Dim dt As New DataTable
    '    dt.Columns.Add("Cuota")

    '    For i = 0 To nrocuotas - 1
    '        Dim row As DataRow = dt.NewRow()


    '        If i = nrocuotas - 1 Then
    '            row("Couta") = cuotaredondeo - montoredondeado
    '            'cuotas(i). = cuotaredondeo - montoredondeado
    '        Else
    '            row("Couta") = cuotaredondeo
    '            'dt.Rows("Couta") = cuotaredondeo
    '        End If
    '        dt.Rows.Add(row)
    '    Next
    '    Return dt


    'End Function
    Public Function CalculaCouotas(ByVal monto As Double, ByVal nrocuotas As Integer) As DataTable
        Dim dt As New DataTable
        Dim credondeo As Double
        Dim mredondeo As Double
        'Dim nro As Integer

        credondeo = Math.Round((monto / nrocuotas), 1) ' 26.7
        mredondeo = Math.Round(monto - (credondeo * nrocuotas), 1) ' - 0.3

        dt.Columns.Add("idcuota")
        dt.Columns.Add("Cuota")
        For i = 0 To nrocuotas - 1
            Dim row As DataRow = dt.NewRow()

            If i = nrocuotas - 1 Then
                row("idcuota") = i + 1
                row("Cuota") = credondeo + mredondeo ' 26.4=26.7+-0.3
            Else
                row("idcuota") = i + 1
                row("Cuota") = credondeo ' 26.7
            End If

            dt.Rows.Add(row)
        Next
        Return dt
    End Function
End Class
