Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Data.OleDb
Imports ACCESO
Imports LOGICA
Public Class clsDeudasVolumen
    Private _vIdJas As String
    Private _iAnioTarifa As Integer
    Private _idMes As Integer
    Private _idPredio As Integer
    Private _idDetalleDeuda As Integer
    Private _idTipoDeuda As Integer
    Private _iIdTipoTarifa As Integer
    Private _fMonto As Double
    Private _fSaldo As Double
    Private _fRedondeo As Decimal
    Private _fVolumen As Double
    Private _vConcepto As String
    Private _dFechaDeuda As Date
    Private _dFechaPago As Date
    Private _cPagado As String
    Private _vUsuario As String
    Private _cCongelado As String
    Private _finteres As Double

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
    Public Property interes()
        Get
            Return Me._fSaldo
        End Get
        Set(ByVal value)
            Me._finteres = value
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
        Dim cdt1_8 As DevComponents.AdvTree.Cell
        Dim cdt1_9 As DevComponents.AdvTree.Cell
        Dim cdt1_10 As DevComponents.AdvTree.Cell
        Dim cdt1_11 As DevComponents.AdvTree.Cell
        Dim cdt1_12 As DevComponents.AdvTree.Cell
        Dim cdt1_13 As DevComponents.AdvTree.Cell



        Dim _styleRight As DevComponents.DotNetBar.ElementStyle
        _styleRight = New DevComponents.DotNetBar.ElementStyle()
        _styleRight.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Far

        tv.Nodes.Clear()

        Try
            If (c.Connect) Then


                '''''con filtro
                sql = " SELECT view_PrediosServicio.vNroPredio, padPredioServicioMedidor.Codigo, view_PrediosServicio.Usuario, view_PrediosServicio.vIdJas, view_PrediosServicio.idpredio,  " _
                & " view_PrediosServicio.iIdTipoTarifa, tarPrediosLecturas.iAnioTarifa, tarMes.Mes, tarPrediosLecturas.fVolumenConsumo, tarPrediosLecturas.fVolumenM3, '' AS MontoFacturado,'' AS Redondeo FROM view_PrediosServicio INNER JOIN " _
                & " tarPrediosLecturas ON view_PrediosServicio.idpredio = tarPrediosLecturas.idpredio AND view_PrediosServicio.vIdJas = tarPrediosLecturas.vIdJas INNER JOIN tarMes ON tarPrediosLecturas.idMes = tarMes.idMes INNER JOIN " _
                & " padPredioServicioMedidor ON view_PrediosServicio.idpredio = padPredioServicioMedidor.idpredio AND view_PrediosServicio.vIdJas = padPredioServicioMedidor.vIdJas AND  " _
                & " view_PrediosServicio.iIdTipoTarifa = padPredioServicioMedidor.iIdTipoTarifa " _
                & " WHERE(tarPrediosLecturas.fVolumenConsumo > 0) AND (view_PrediosServicio.iIdTipoTarifa = " & IdTipoTarifa & ") AND (tarPrediosLecturas.iAnioTarifa = " & Idaño & ") AND (tarPrediosLecturas.idMes = " & Idmes & ") AND (view_PrediosServicio.idcalle = " & Idcalle & ") AND padPredioServicioMedidor.cEstado = '1' " _
                 & " AND (view_PrediosServicio.idpredio NOT IN (SELECT    tarDetalleDeudaPredio.idPredio FROM tarDetalleDeudaPredio WHERE     (vIdJas = view_PrediosServicio.vIdJas) AND (iAnioTarifa = " & Idaño & ") AND (idMes = " & Idmes & ") AND (iIdTipoTarifa = " & IdTipoTarifa & ") ))"



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
                    cdt1_8 = New DevComponents.AdvTree.Cell
                    cdt1_9 = New DevComponents.AdvTree.Cell
                    cdt1_10 = New DevComponents.AdvTree.Cell
                    cdt1_11 = New DevComponents.AdvTree.Cell
                    cdt1_12 = New DevComponents.AdvTree.Cell
                    cdt1_13 = New DevComponents.AdvTree.Cell
                    n1.Cells.Add(cdt1_1)
                    n1.Cells.Add(cdt1_2)
                    n1.Cells.Add(cdt1_3)
                    n1.Cells.Add(cdt1_4)
                    n1.Cells.Add(cdt1_5)
                    n1.Cells.Add(cdt1_6)
                    n1.Cells.Add(cdt1_7)
                    n1.Cells.Add(cdt1_8)
                    n1.Cells.Add(cdt1_9)
                    n1.Cells.Add(cdt1_10)
                    n1.Cells.Add(cdt1_11)
                    n1.Cells.Add(cdt1_12)
                    n1.Cells.Add(cdt1_13)

                    n1.Cells(0).Text = midatarow(0).ToString  'Nro
                    n1.Cells(1).Text = midatarow(1).ToString  'codigo
                    n1.Cells(2).Text = midatarow(2).ToString  'Usuario
                    n1.Cells(3).Text = midatarow(3).ToString  'vIdJas
                    n1.Cells(4).Text = midatarow(4).ToString  'IdPredio
                    n1.Cells(5).Text = midatarow(5).ToString  'IIdTipoTarifa
                    n1.Cells(6).Text = midatarow(6).ToString  'Año
                    n1.Cells(7).Text = midatarow(7).ToString  'Mes
                    n1.Cells(8).Text = midatarow(8).ToString  'VolumenLt
                    n1.Cells(9).Text = midatarow(9).ToString  'VolumenM3
                    n1.Cells(10).Text = midatarow(10).ToString  'MONTO
                    n1.Cells(11).Text = midatarow(11).ToString  'MONTO
                    n1.Cells(12).Text = 0 'MONTO
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

    Public Sub ListTreeTodas(ByRef tv As DevComponents.AdvTree.AdvTree, ByVal Idcalle As Integer, ByVal Idmes As Integer, ByVal Idaño As Integer, ByVal IdTipoTarifa As Integer)
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
        Dim cdt1_8 As DevComponents.AdvTree.Cell
        Dim cdt1_9 As DevComponents.AdvTree.Cell
        Dim cdt1_10 As DevComponents.AdvTree.Cell
        Dim cdt1_11 As DevComponents.AdvTree.Cell
        Dim cdt1_12 As DevComponents.AdvTree.Cell
        Dim cdt1_13 As DevComponents.AdvTree.Cell



        Dim _styleRight As DevComponents.DotNetBar.ElementStyle
        _styleRight = New DevComponents.DotNetBar.ElementStyle()
        _styleRight.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Far

        tv.Nodes.Clear()

        Try
            If (c.Connect) Then


                '''''con filtro
                sql = " SELECT view_PrediosServicio.vNroPredio, padPredioServicioMedidor.Codigo, view_PrediosServicio.Usuario, view_PrediosServicio.vIdJas, view_PrediosServicio.idpredio,  " _
                & " view_PrediosServicio.iIdTipoTarifa, tarPrediosLecturas.iAnioTarifa, tarMes.Mes, tarPrediosLecturas.fVolumenConsumo, tarPrediosLecturas.fVolumenM3, '' AS MontoFacturado,'' AS Redondeo FROM view_PrediosServicio INNER JOIN " _
                & " tarPrediosLecturas ON view_PrediosServicio.idpredio = tarPrediosLecturas.idpredio AND view_PrediosServicio.vIdJas = tarPrediosLecturas.vIdJas INNER JOIN tarMes ON tarPrediosLecturas.idMes = tarMes.idMes INNER JOIN " _
                & " padPredioServicioMedidor ON view_PrediosServicio.idpredio = padPredioServicioMedidor.idpredio AND view_PrediosServicio.vIdJas = padPredioServicioMedidor.vIdJas AND  " _
                & " view_PrediosServicio.iIdTipoTarifa = padPredioServicioMedidor.iIdTipoTarifa " _
                & " WHERE(tarPrediosLecturas.fVolumenConsumo > 0) AND (tarPrediosLecturas.iAnioTarifa = " & Idaño & ") AND (tarPrediosLecturas.idMes = " & Idmes & ") AND (view_PrediosServicio.idcalle = " & Idcalle & ") AND padPredioServicioMedidor.cEstado = '1' " _
                 & " AND (view_PrediosServicio.idpredio NOT IN (SELECT    tarDetalleDeudaPredio.idPredio FROM tarDetalleDeudaPredio WHERE     (vIdJas = view_PrediosServicio.vIdJas) AND (iAnioTarifa = " & Idaño & ") AND (idMes = " & Idmes & ") AND (iIdTipoTarifa = " & IdTipoTarifa & ") ))"



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
                    cdt1_8 = New DevComponents.AdvTree.Cell
                    cdt1_9 = New DevComponents.AdvTree.Cell
                    cdt1_10 = New DevComponents.AdvTree.Cell
                    cdt1_11 = New DevComponents.AdvTree.Cell
                    cdt1_12 = New DevComponents.AdvTree.Cell
                    cdt1_13 = New DevComponents.AdvTree.Cell
                    n1.Cells.Add(cdt1_1)
                    n1.Cells.Add(cdt1_2)
                    n1.Cells.Add(cdt1_3)
                    n1.Cells.Add(cdt1_4)
                    n1.Cells.Add(cdt1_5)
                    n1.Cells.Add(cdt1_6)
                    n1.Cells.Add(cdt1_7)
                    n1.Cells.Add(cdt1_8)
                    n1.Cells.Add(cdt1_9)
                    n1.Cells.Add(cdt1_10)
                    n1.Cells.Add(cdt1_11)
                    n1.Cells.Add(cdt1_12)
                    n1.Cells.Add(cdt1_13)

                    n1.Cells(0).Text = midatarow(0).ToString  'Nro
                    n1.Cells(1).Text = midatarow(1).ToString  'codigo
                    n1.Cells(2).Text = midatarow(2).ToString  'Usuario
                    n1.Cells(3).Text = midatarow(3).ToString  'vIdJas
                    n1.Cells(4).Text = midatarow(4).ToString  'IdPredio
                    n1.Cells(5).Text = midatarow(5).ToString  'IIdTipoTarifa
                    n1.Cells(6).Text = midatarow(6).ToString  'Año
                    n1.Cells(7).Text = midatarow(7).ToString  'Mes
                    n1.Cells(8).Text = midatarow(8).ToString  'VolumenLt
                    n1.Cells(9).Text = midatarow(9).ToString  'VolumenM3
                    n1.Cells(10).Text = midatarow(10).ToString  'MONTO
                    n1.Cells(11).Text = midatarow(11).ToString  'MONTO
                    n1.Cells(12).Text = 0 'MONTO
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
            cmd.Parameters.AddWithValue("@INTERES", Me._finteres)
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
End Class
