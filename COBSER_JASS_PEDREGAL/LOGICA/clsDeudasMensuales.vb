
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Data.OleDb
Imports ACCESO
Imports LOGICA

Public Class clsDeudasMensuales
    Private _vIdJas As String
    Private _iAnioTarifa As Integer
    Private _idMes As Integer
    Private _idPredio As Integer
    Private _idDetalleDeuda As Integer
    Private _idTipoDeuda As Integer
    Private _iIdTipoTarifa As Integer
    Private _fMonto As Double
    Private _fSaldo As Double
    Private _fRedondeo As Double
    Private _fVolumen As Double
    Private _vConcepto As String
    Private _dFechaDeuda As Date
    Private _dFechaPago As Date
    Private _cPagado As String
    Private _vUsuario As String
    Private _cCongelado As String
    Private _fInteres As String


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
    Public Property Redondeo()
        Get
            Return Me._fRedondeo
        End Get
        Set(ByVal value)
            Me._fRedondeo = value
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
    Public Property Interes()
        Get
            Return Me._fInteres
        End Get
        Set(ByVal value)
            Me._fInteres = value
        End Set
    End Property

    Private Function NewId()
        Dim c As New ACCESO.Conexion
        Dim dt As New DataTable
        Dim id As Integer
        If (c.Connect) Then
            dt = c.Query("select isNull(max(IdDetalleDeuda),0) from tarDetalleDeudaPredio where iAnioTarifa='" & Me._iAnioTarifa & "' and vIdJas='" & Me._vIdJas & "' and IdPredio='" & Me._idPredio & "'")
            c.Close()
            id = dt.Rows(0).Item(0) + 1
        End If
        Return id
    End Function
    Public Function Insert(ByVal Idcalle As Integer, ByVal Idmes As Integer, ByVal Idaño As Integer) As Boolean
        Dim cmd As New SqlCommand()
        Dim c As New ACCESO.Conexion

        Me._idDetalleDeuda = Me.NewId
        If (c.Connect) Then
            cmd.CommandText = "INSERT INTO tarDetalleDeudaPredio (vIdJas, iAnioTarifa, idMes, idPredio, idDetalleDeuda, idTipoDeuda, iIdTipoTarifa, fMonto, fSaldo, fRedondeo, fVolumen, vConcepto, dFechaDeuda, dFechaPago, cPagado, vUsuario, cCongelado, fInteres)" _
                            & " VALUES(@IDJAS, @ANIO,@MES,@PRED,@IDEDETDEUDA,@IDTIPODEUDA,@TIPOTARIFA,@MONTO,@SALDO,@REDONDEO,@VOLUMEN,@CONCEPTO,@FDEUDA,null,@PAGADO,@USUARIO,@CONGELADO,@INTERES)"
            cmd.Parameters.AddWithValue("@IDJAS", Me._vIdJas)
            cmd.Parameters.AddWithValue("@ANIO", Me._iAnioTarifa)
            cmd.Parameters.AddWithValue("@MES", Me._idMes)
            cmd.Parameters.AddWithValue("@PRED", Me._idPredio)
            cmd.Parameters.AddWithValue("@IDEDETDEUDA", Me._idDetalleDeuda)
            cmd.Parameters.AddWithValue("@IDTIPODEUDA", Me._idTipoDeuda)
            cmd.Parameters.AddWithValue("@TIPOTARIFA", Me._iIdTipoTarifa)
            cmd.Parameters.AddWithValue("@MONTO", Me._fMonto)
            cmd.Parameters.AddWithValue("@SALDO", Me._fSaldo)
            cmd.Parameters.AddWithValue("@REDONDEO", Me._fRedondeo)
            cmd.Parameters.AddWithValue("@VOLUMEN", Me._fVolumen)
            cmd.Parameters.AddWithValue("@CONCEPTO", Me._vConcepto)
            cmd.Parameters.AddWithValue("@FDEUDA", Me._dFechaDeuda)
            'cmd.Parameters.AddWithValue("@FPAGO", DBNull.Value)
            cmd.Parameters.AddWithValue("@PAGADO", Me._cPagado)
            cmd.Parameters.AddWithValue("@USUARIO", Me._vUsuario)
            cmd.Parameters.AddWithValue("@CONGELADO", Me._cCongelado)
            cmd.Parameters.AddWithValue("@INTERES", Me._fInteres)
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
    Public Sub ListServiciosG(ByRef tv As DevComponents.AdvTree.AdvTree, ByVal Idcalle As Integer, ByVal Idmes As Integer, ByVal Idaño As Integer, ByVal IdTipoTarifa As Integer)
        Dim c As New ACCESO.Conexion
        Dim dt1 As New DataTable
        Dim sql As String
        Dim n1 As New DevComponents.AdvTree.Node
        Dim cdt1_1 As DevComponents.AdvTree.Cell
        Dim cdt1_2 As DevComponents.AdvTree.Cell
        Dim cdt1_3 As DevComponents.AdvTree.Cell
        Dim cdt1_4 As DevComponents.AdvTree.Cell
        Dim cdt1_5 As DevComponents.AdvTree.Cell
        Dim cdt1_6 As DevComponents.AdvTree.Cell
        Dim cdt1_7 As DevComponents.AdvTree.Cell

        Dim _styleRight As DevComponents.DotNetBar.ElementStyle
        _styleRight = New DevComponents.DotNetBar.ElementStyle()
        _styleRight.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Far
        tv.Nodes.Clear()
        Try
            If (c.Connect) Then
                sql = " SELECT padPredio.vNroPredio AS Nro, padPredio.vNombre AS Predio, Padusuario.vApePaterno + SPACE(1) + Padusuario.vApeMaterno + SPACE(1) + Padusuario.vUsuario AS Usuario, padPredio.vIdJas, padPredio.idpredio, " & IdTipoTarifa & "," _
                 & "  padPredio.idcalle FROM  padUsuarioPredio INNER JOIN " _
                & "  Padusuario ON padUsuarioPredio.vIdJas = Padusuario.vIdJas AND padUsuarioPredio.iIdusuario = Padusuario.iIdUsuario INNER JOIN " _
                & "  padPredio ON padUsuarioPredio.vIdJas = padPredio.vIdJas AND padUsuarioPredio.idpredio = padPredio.idpredio INNER JOIN " _
                & "  tarDetalleDeudaPredio ON padPredio.vIdJas = tarDetalleDeudaPredio.vIdJas AND padPredio.idpredio = tarDetalleDeudaPredio.idPredio INNER JOIN " _
                & "  tarTipoTarifa ON tarDetalleDeudaPredio.vIdJas = tarTipoTarifa.vIdJas AND tarDetalleDeudaPredio.idTipoDeuda = tarTipoTarifa.iIdTipoTarifa " _
                & "  WHERE  (padUsuarioPredio.cEstado = '1') AND (padPredio.idcalle = " & Idcalle & ") AND (tarDetalleDeudaPredio.iAnioTarifa = " & Idaño & ") AND (tarDetalleDeudaPredio.idMes = " & Idmes & ") AND (tarDetalleDeudaPredio.iIdTipoTarifa = " & IdTipoTarifa & ") AND " _
                & "  (NOT (padPredio.idpredio IN (SELECT idPredio FROM padCortesPredios " _
                & "  WHERE   (vIdjas = padPredio.vIdJas) AND (idPredio = padPredio.idpredio) AND (cEstadoPredio = 1)))) " _
                & "  ORDER BY Usuario"

                dt1 = c.Query(sql)
                For Each midatarow As DataRow In dt1.Rows
                    n1 = New DevComponents.AdvTree.Node

                    n1.CheckBoxVisible = True
                    cdt1_1 = New DevComponents.AdvTree.Cell
                    cdt1_2 = New DevComponents.AdvTree.Cell
                    cdt1_3 = New DevComponents.AdvTree.Cell
                    cdt1_4 = New DevComponents.AdvTree.Cell
                    cdt1_5 = New DevComponents.AdvTree.Cell
                    cdt1_6 = New DevComponents.AdvTree.Cell
                    cdt1_7 = New DevComponents.AdvTree.Cell
                    n1.Cells.Add(cdt1_1)
                    n1.Cells.Add(cdt1_2)
                    n1.Cells.Add(cdt1_3)
                    n1.Cells.Add(cdt1_4)
                    n1.Cells.Add(cdt1_5)
                    n1.Cells.Add(cdt1_6)
                    n1.Cells.Add(cdt1_7)
                    n1.Cells(0).Text = midatarow(0).ToString  'Nro
                    n1.Cells(1).Text = midatarow(1).ToString  'Predio
                    n1.Cells(2).Text = midatarow(2).ToString  'Usuario
                    n1.Cells(3).Text = midatarow(3).ToString  'vIdJas
                    n1.Cells(4).Text = midatarow(4).ToString  'IdPredio
                    n1.Cells(5).Text = midatarow(5).ToString  'IIdTipoTarifa
                    n1.Cells(6).Text = midatarow(6).ToString  'IdCalle
                    'n1.Cells(1).StyleNormal = _styleRight
                    'n1.Cells(1).StyleDisabled = _styleRight
                    'n1.Cells(1).StyleSelected = _styleRight
                    tv.Nodes.Add(n1)
                    tv.Refresh()
                Next
                c.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Public Sub ListTree(ByRef tv As DevComponents.AdvTree.AdvTree, ByVal Idcalle As Integer, ByVal Idmes As Integer, ByVal Idaño As Integer, ByVal IdTipoTarifa As Integer)
        Dim c As New ACCESO.Conexion
        Dim dt1 As New DataTable
        Dim sql As String
        Dim n1 As New DevComponents.AdvTree.Node
        Dim cdt1_1 As DevComponents.AdvTree.Cell
        Dim cdt1_2 As DevComponents.AdvTree.Cell
        Dim cdt1_3 As DevComponents.AdvTree.Cell
        Dim cdt1_4 As DevComponents.AdvTree.Cell
        Dim cdt1_5 As DevComponents.AdvTree.Cell
        Dim cdt1_6 As DevComponents.AdvTree.Cell
        Dim cdt1_7 As DevComponents.AdvTree.Cell

        Dim _styleRight As DevComponents.DotNetBar.ElementStyle
        _styleRight = New DevComponents.DotNetBar.ElementStyle()
        _styleRight.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Far
        tv.Nodes.Clear()
        Try
            If (c.Connect) Then
                sql = "SELECT padPredio.vNroPredio AS Nro, padPredio.vNombre AS Predio, Padusuario.vApePaterno + SPACE(1) + Padusuario.vApeMaterno + SPACE(1) + Padusuario.vUsuario AS Usuario, " _
                    & " padPredio.vIdJas, padPredio.idpredio," & IdTipoTarifa & ",padPredio.idcalle" _
                    & " FROM     padUsuarioPredio INNER JOIN " _
                                      & " Padusuario ON padUsuarioPredio.vIdJas = Padusuario.vIdJas AND padUsuarioPredio.iIdusuario = Padusuario.iIdUsuario INNER JOIN " _
                                      & " padPredio ON padUsuarioPredio.vIdJas = padPredio.vIdJas AND padUsuarioPredio.idpredio = padPredio.idpredio " _
                    & " WHERE  (padUsuarioPredio.cEstado = '1') " _
                    & " And(padPredio.idcalle = " & Idcalle & ")  " _
                    & " AND padPredio.idpredio NOT IN (  " _
                    & " Select idPredio FROM View_ServiciosPredio " _
                    & " WHERE(vIdJas = padPredio.vIdJas) And iAnioTarifa=" & Idaño & " And idMes=" & Idmes & " And  " _
                    & "  idPredio = padPredio.idpredio And iIdTipoTarifa = " & IdTipoTarifa _
                    & " ) " _
                    & " AND (padPredio.idpredio NOT IN (SELECT idPredio " _
                    & " FROM padCortesPredios " _
                    & "    WHERE   (vIdJas = padPredio.vIdJas) AND (idPredio = padPredio.idpredio) AND cEstadoPredio=1 )) " _
                    & " ORDER BY  Padusuario.vApePaterno + SPACE(1) + Padusuario.vApeMaterno + SPACE(1) + Padusuario.vUsuario "
                dt1 = c.Query(sql)
                For Each midatarow As DataRow In dt1.Rows
                    n1 = New DevComponents.AdvTree.Node

                    n1.CheckBoxVisible = True
                    cdt1_1 = New DevComponents.AdvTree.Cell
                    cdt1_2 = New DevComponents.AdvTree.Cell
                    cdt1_3 = New DevComponents.AdvTree.Cell
                    cdt1_4 = New DevComponents.AdvTree.Cell
                    cdt1_5 = New DevComponents.AdvTree.Cell
                    cdt1_6 = New DevComponents.AdvTree.Cell
                    cdt1_7 = New DevComponents.AdvTree.Cell
                    n1.Cells.Add(cdt1_1)
                    n1.Cells.Add(cdt1_2)
                    n1.Cells.Add(cdt1_3)
                    n1.Cells.Add(cdt1_4)
                    n1.Cells.Add(cdt1_5)
                    n1.Cells.Add(cdt1_6)
                    n1.Cells.Add(cdt1_7)
                    n1.Cells(0).Text = midatarow(0).ToString  'Nro
                    n1.Cells(1).Text = midatarow(1).ToString  'Predio
                    n1.Cells(2).Text = midatarow(2).ToString  'Usuario
                    n1.Cells(3).Text = midatarow(3).ToString  'vIdJas
                    n1.Cells(4).Text = midatarow(4).ToString  'IdPredio
                    n1.Cells(5).Text = midatarow(5).ToString  'IIdTipoTarifa
                    n1.Cells(6).Text = midatarow(6).ToString  'IdCalle
                    'n1.Cells(1).StyleNormal = _styleRight
                    'n1.Cells(1).StyleDisabled = _styleRight
                    'n1.Cells(1).StyleSelected = _styleRight
                    tv.Nodes.Add(n1)
                    tv.Refresh()
                Next
                c.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Public Sub ListTreeUnicas(ByRef tv As DevComponents.AdvTree.AdvTree, ByVal Idcalle As Integer, ByVal Idmes As Integer, ByVal Idaño As Integer, ByVal IdTipoTarifa As Integer)
        Dim c As New ACCESO.Conexion
        Dim dt1 As New DataTable
        Dim sql As String
        Dim n1 As New DevComponents.AdvTree.Node
        Dim cdt1_1 As DevComponents.AdvTree.Cell
        Dim cdt1_2 As DevComponents.AdvTree.Cell
        Dim cdt1_3 As DevComponents.AdvTree.Cell
        Dim cdt1_4 As DevComponents.AdvTree.Cell
        Dim cdt1_5 As DevComponents.AdvTree.Cell
        Dim cdt1_6 As DevComponents.AdvTree.Cell
        Dim cdt1_7 As DevComponents.AdvTree.Cell

        Dim _styleRight As DevComponents.DotNetBar.ElementStyle
        _styleRight = New DevComponents.DotNetBar.ElementStyle()
        _styleRight.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Far

        tv.Nodes.Clear()

        Try
            If (c.Connect) Then



                sql = "SELECT padPredio.vNroPredio AS Nro, padPredio.vNombre AS Predio, Padusuario.vApePaterno + SPACE(1) + Padusuario.vApeMaterno + SPACE(1) + Padusuario.vUsuario AS Usuario, " _
                    & " padPredio.vIdJas, padPredio.idpredio," & IdTipoTarifa & ",padPredio.idcalle" _
                    & " FROM     padUsuarioPredio INNER JOIN " _
                                      & " Padusuario ON padUsuarioPredio.vIdJas = Padusuario.vIdJas AND padUsuarioPredio.iIdusuario = Padusuario.iIdUsuario INNER JOIN " _
                                      & " padPredio ON padUsuarioPredio.vIdJas = padPredio.vIdJas AND padUsuarioPredio.idpredio = padPredio.idpredio " _
                    & " WHERE  (padUsuarioPredio.cEstado = '1') " _
                    & " And(padPredio.idcalle = " & Idcalle & ")  " _
                    & " AND padPredio.idpredio NOT IN (  " _
                    & " Select idPredio FROM View_ServiciosPredio " _
                    & " WHERE(vIdJas = padPredio.vIdJas) And iAnioTarifa=" & Idaño & " And idMes=" & Idmes & " And  " _
                    & " idPredio = padPredio.idpredio " _
                    & " ) " _
                    & " AND (padPredio.idpredio NOT IN (SELECT idPredio " _
                    & " FROM padCortesPredios  " _
                    & " WHERE (vIdJas = padPredio.vIdJas) AND (idPredio = padPredio.idpredio) AND cEstadoPredio=1 )) " _
                    & " ORDER BY  Padusuario.vApePaterno + SPACE(1) + Padusuario.vApeMaterno + SPACE(1) + Padusuario.vUsuario "


                dt1 = c.Query(sql)
                For Each midatarow As DataRow In dt1.Rows
                    n1 = New DevComponents.AdvTree.Node

                    n1.CheckBoxVisible = True
                    cdt1_1 = New DevComponents.AdvTree.Cell
                    cdt1_2 = New DevComponents.AdvTree.Cell
                    cdt1_3 = New DevComponents.AdvTree.Cell
                    cdt1_4 = New DevComponents.AdvTree.Cell
                    cdt1_5 = New DevComponents.AdvTree.Cell
                    cdt1_6 = New DevComponents.AdvTree.Cell
                    cdt1_7 = New DevComponents.AdvTree.Cell
                    n1.Cells.Add(cdt1_1)
                    n1.Cells.Add(cdt1_2)
                    n1.Cells.Add(cdt1_3)
                    n1.Cells.Add(cdt1_4)
                    n1.Cells.Add(cdt1_5)
                    n1.Cells.Add(cdt1_6)
                    n1.Cells.Add(cdt1_7)

                    n1.Cells(0).Text = midatarow(0).ToString  'Nro
                    n1.Cells(1).Text = midatarow(1).ToString  'Predio
                    n1.Cells(2).Text = midatarow(2).ToString  'Usuario
                    n1.Cells(3).Text = midatarow(3).ToString  'vIdJas
                    n1.Cells(4).Text = midatarow(4).ToString  'IdPredio
                    n1.Cells(5).Text = midatarow(5).ToString  'IIdTipoTarifa
                    n1.Cells(6).Text = midatarow(6).ToString  'IdCalle

                    'n1.Cells(1).StyleNormal = _styleRight
                    'n1.Cells(1).StyleDisabled = _styleRight
                    'n1.Cells(1).StyleSelected = _styleRight
                    tv.Nodes.Add(n1)
                    tv.Refresh()
                Next
                c.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Public Sub ListTreeUnicasServicio(ByRef tv As DevComponents.AdvTree.AdvTree, ByVal Idcalle As Integer, ByVal Idmes As Integer, ByVal Idaño As Integer, ByVal IdTipoTarifa As Integer)
        Dim c As New ACCESO.Conexion
        Dim dt1 As New DataTable
        Dim sql As String
        Dim n1 As New DevComponents.AdvTree.Node
        Dim cdt1_1 As DevComponents.AdvTree.Cell
        Dim cdt1_2 As DevComponents.AdvTree.Cell
        Dim cdt1_3 As DevComponents.AdvTree.Cell
        Dim cdt1_4 As DevComponents.AdvTree.Cell
        Dim cdt1_5 As DevComponents.AdvTree.Cell
        Dim cdt1_6 As DevComponents.AdvTree.Cell
        Dim cdt1_7 As DevComponents.AdvTree.Cell

        Dim _styleRight As DevComponents.DotNetBar.ElementStyle
        _styleRight = New DevComponents.DotNetBar.ElementStyle()
        _styleRight.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Far

        tv.Nodes.Clear()

        Try
            If (c.Connect) Then



                'sql = "SELECT padPredio.vNroPredio AS Nro, padPredio.vNombre AS Predio, Padusuario.vApePaterno + SPACE(1) + Padusuario.vApeMaterno + SPACE(1) + Padusuario.vUsuario AS Usuario, " _
                '    & " padPredio.vIdJas, padPredio.idpredio," & IdTipoTarifa & ",padPredio.idcalle" _
                '    & " FROM     padUsuarioPredio INNER JOIN " _
                '                      & " Padusuario ON padUsuarioPredio.vIdJas = Padusuario.vIdJas AND padUsuarioPredio.iIdusuario = Padusuario.iIdUsuario INNER JOIN " _
                '                      & " padPredio ON padUsuarioPredio.vIdJas = padPredio.vIdJas AND padUsuarioPredio.idpredio = padPredio.idpredio " _
                '    & " WHERE  (padUsuarioPredio.cEstado = '1') " _
                '    & " And(padPredio.idcalle = " & Idcalle & ")  " _
                '    & " AND padPredio.idpredio NOT IN (  " _
                '    & " Select idPredio FROM View_ServiciosPredio " _
                '    & " WHERE(vIdJas = padPredio.vIdJas) And iAnioTarifa=" & Idaño & " And idMes=" & Idmes & " And  " _
                '    & " idPredio = padPredio.idpredio " _
                '    & " ) " _
                '    & " AND (padPredio.idpredio NOT IN (SELECT idPredio " _
                '    & " FROM padCortesPredios  " _
                '    & " WHERE (vIdJas = padPredio.vIdJas) AND (idPredio = padPredio.idpredio) AND cEstadoPredio=1 )) " _
                '    & " ORDER BY  Padusuario.vApePaterno + SPACE(1) + Padusuario.vApeMaterno + SPACE(1) + Padusuario.vUsuario "

                sql = " SELECT padPredio.vNroPredio AS Nro, padPredio.vNombre AS Predio, Padusuario.vApePaterno + SPACE(1) + Padusuario.vApeMaterno + SPACE(1) + Padusuario.vUsuario AS Usuario, padPredio.vIdJas, padPredio.idpredio, " & IdTipoTarifa & ", " _
                & " padPredio.idcalle, view_PrediosServicio.iIdTipoTarifa, view_PrediosServicio.TipoServicio" _
                & " FROM padUsuarioPredio INNER JOIN " _
                 & " Padusuario ON padUsuarioPredio.vIdJas = Padusuario.vIdJas AND padUsuarioPredio.iIdusuario = Padusuario.iIdUsuario INNER JOIN " _
                 & " padPredio ON padUsuarioPredio.vIdJas = padPredio.vIdJas AND padUsuarioPredio.idpredio = padPredio.idpredio LEFT OUTER JOIN " _
                 & " view_PrediosServicio ON padPredio.idpredio = view_PrediosServicio.idpredio" _
                 & " WHERE  (padUsuarioPredio.cEstado = '1')" _
                & "  AND (padPredio.idcalle =  " & Idcalle & ") AND (padPredio.idpredio NOT IN" _
                 & " (SELECT idPredio FROM View_ServiciosPredio" _
                 & " WHERE   (vIdJas = padPredio.vIdJas) AND (iAnioTarifa = " & Idaño & " ) AND (idMes = " & Idmes & ") AND (idPredio = padPredio.idpredio))) AND (padPredio.idpredio NOT IN" _
                 & " (SELECT idPredio FROM padCortesPredios" _
                  & " WHERE   (vIdjas = padPredio.vIdJas) AND (idPredio = padPredio.idpredio) AND (cEstadoPredio = 1))) AND (view_PrediosServicio.iIdTipoTarifa = " & IdTipoTarifa & ")" _
                 & " ORDER BY Usuario"


                dt1 = c.Query(sql)
                For Each midatarow As DataRow In dt1.Rows
                    n1 = New DevComponents.AdvTree.Node

                    n1.CheckBoxVisible = True
                    cdt1_1 = New DevComponents.AdvTree.Cell
                    cdt1_2 = New DevComponents.AdvTree.Cell
                    cdt1_3 = New DevComponents.AdvTree.Cell
                    cdt1_4 = New DevComponents.AdvTree.Cell
                    cdt1_5 = New DevComponents.AdvTree.Cell
                    cdt1_6 = New DevComponents.AdvTree.Cell
                    cdt1_7 = New DevComponents.AdvTree.Cell
                    n1.Cells.Add(cdt1_1)
                    n1.Cells.Add(cdt1_2)
                    n1.Cells.Add(cdt1_3)
                    n1.Cells.Add(cdt1_4)
                    n1.Cells.Add(cdt1_5)
                    n1.Cells.Add(cdt1_6)
                    n1.Cells.Add(cdt1_7)

                    n1.Cells(0).Text = midatarow(0).ToString  'Nro
                    n1.Cells(1).Text = midatarow(1).ToString  'Predio
                    n1.Cells(2).Text = midatarow(2).ToString  'Usuario
                    n1.Cells(3).Text = midatarow(3).ToString  'vIdJas
                    n1.Cells(4).Text = midatarow(4).ToString  'IdPredio
                    n1.Cells(5).Text = midatarow(5).ToString  'IIdTipoTarifa
                    n1.Cells(6).Text = midatarow(6).ToString  'IdCalle

                    'n1.Cells(1).StyleNormal = _styleRight
                    'n1.Cells(1).StyleDisabled = _styleRight
                    'n1.Cells(1).StyleSelected = _styleRight
                    tv.Nodes.Add(n1)
                    tv.Refresh()
                Next
                c.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
End Class
