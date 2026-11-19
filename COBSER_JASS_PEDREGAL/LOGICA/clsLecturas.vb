Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Data.OleDb
Imports ACCESO
Imports LOGICA
Public Class clsLecturas
    Private _vIdJas As Integer
    Private _idPredio As Integer
    Private _idTipoTarifa As Integer
    Private _idMedidor As Integer
    Private _idLectura As Integer
    Private _iAnioTarifa As Integer
    Private _idMes As Integer
    Private _dFechaRegistro As Date
    Private _dFechaLectura As Date
    Private _dFechaUltima As Date
    Private _fLecturaM3 As Double
    Private _fLecturaLt As Double
    Private _fVolumenTotal As Double
    Private _fVolumenConsumo As Double
    Private _fVolumenM3 As Double
    Private _vReferencia As String
    Private _vUsuario As String


    Public Property ultimaLecturam3()
        Get
            Return Me._fLecturaM3
        End Get
        Set(ByVal value)
            Me._fLecturaM3 = value
        End Set
    End Property
    Public Property ultimaLecturalt()
        Get
            Return Me._fLecturaLt
        End Get
        Set(ByVal value)
            Me._fLecturaLt = value
        End Set
    End Property
    Public Property fVolumenTotal()
        Get
            Return Me._fVolumenTotal
        End Get
        Set(ByVal value)
            Me._fVolumenTotal = value
        End Set
    End Property
    Public Property volumenconsumo()
        Get
            Return Me._fVolumenConsumo
        End Get
        Set(ByVal value)
            Me._fVolumenConsumo = value
        End Set
    End Property
    Public Property volumenconsumoM3()
        Get
            Return Me._fVolumenM3
        End Get
        Set(ByVal value)
            Me._fVolumenM3 = value
        End Set
    End Property
    Public Property IdPredio()
        Get
            Return Me._idPredio
        End Get
        Set(ByVal value)
            Me._idPredio = value
        End Set
    End Property
    Public Property anio()
        Get
            Return Me._iAnioTarifa
        End Get
        Set(ByVal value)
            Me._iAnioTarifa = value
        End Set
    End Property
    Public Property idtipoTarifa()
        Get
            Return _idtipoTarifa
        End Get
        Set(ByVal value)
            _idtipoTarifa = value
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
    Public Property Usuario()
        Get
            Return Me._vUsuario
        End Get
        Set(ByVal value)
            Me._vUsuario = value
        End Set
    End Property
    Public Property FechaRegistro()
        Get
            Return Me._dFechaRegistro
        End Get
        Set(ByVal value)
            Me._dFechaRegistro = value
        End Set
    End Property
    Public Property FechaActual()
        Get
            Return Me._dFechaLectura
        End Get
        Set(ByVal value)
            Me._dFechaLectura = value
        End Set
    End Property
    Public Property FechaUltima()
        Get
            Return Me._dFechaUltima
        End Get
        Set(ByVal value)
            Me._dFechaUltima = value
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
    Public Property UsuarioSys()
        Get
            Return Me._vUsuario
        End Get
        Set(ByVal value)
            Me._vUsuario = value
        End Set
    End Property
    Public Property idMedidor()
        Get
            Return Me._idMedidor
        End Get
        Set(ByVal value)
            Me._idMedidor = value
        End Set
    End Property
    Private Function NewId()
        Dim c As New ACCESO.Conexion
        Dim dt As New DataTable
        Dim id As Integer
        If (c.Connect) Then
            dt = c.Query("select isNull(max(idLectura),0) from tarPrediosLecturas where iAnioTarifa='" & anio & "'  and IdPredio=" & IdPredio & "")
            c.Close()
            id = dt.Rows(0).Item(0) + 1
        End If
        Return id
    End Function
    Public Shared Function List(ByVal anio As Integer, ByVal idpredio As Integer, ByVal idmed As Integer) As DataTable
        Dim dt As New DataTable
        Dim c As New ACCESO.Conexion
        Dim SQLTEXT As String
        If (c.Connect) Then
            'SQLTEXT = " SELECT padPredioServicioMedidor.idpredio, Medidor.Tipo, Medidor.Marca, padPredioServicioMedidor.Codigo, view_PrediosServiciosUnicos.vNroPredio, view_PrediosServiciosUnicos.TipoPredio, view_PrediosServiciosUnicos.TipoServicio, CASE  padPredioServicioMedidor.cEstado WHEN '1' THEN 'Activo'WHEN '0' THEN 'Inactivo' END AS Estado " _
            ' & " FROM padPredioServicioMedidor INNER JOIN view_PrediosServiciosUnicos ON padPredioServicioMedidor.idpredio = view_PrediosServiciosUnicos.idpredio AND  " _
            ' & " padPredioServicioMedidor.vIdJas = view_PrediosServiciosUnicos.vIdJas INNER JOIN Medidor ON padPredioServicioMedidor.idMedidor = Medidor.idMedidor " _
            ' & " WHERE padPredioServicioMedidor.idpredio='" & idpredio & "'"


            'SQLTEXT = " SELECT  padPredioServicioMedidor.idpredio, padPredioServicioMedidor.Codigo, view_PrediosServiciosUnicos.vNroPredio, view_PrediosServiciosUnicos.TipoPredio,  " _
            '   & " view_PrediosServiciosUnicos.TipoServicio, tarPrediosLecturas.idLectura, tarPrediosLecturas.iAnioTarifa, tarPrediosLecturas.idMes,tarMes.Mes, tarPrediosLecturas.dFechaLectura,  " _
            '   & " tarPrediosLecturas.fLecturaM3, tarPrediosLecturas.fLecturaLt, tarPrediosLecturas.fVolumenTotal, tarPrediosLecturas.fVolumenConsumo, tarPrediosLecturas.vReferencia,  tarPrediosLecturas.fVolumenM3, tarPrediosLecturas.dFechaRegistro, view_PrediosServiciosUnicos.idcalle " _
            '    & " FROM  padPredioServicioMedidor INNER JOIN  " _
            '   & " view_PrediosServiciosUnicos ON padPredioServicioMedidor.idpredio = view_PrediosServiciosUnicos.idpredio AND  " _
            '   & "  padPredioServicioMedidor.vIdJas = view_PrediosServiciosUnicos.vIdJas INNER JOIN " _
            '   & " tarPrediosLecturas ON padPredioServicioMedidor.vIdJas = tarPrediosLecturas.vIdJas AND padPredioServicioMedidor.idpredio = tarPrediosLecturas.idpredio AND  " _
            '    & " padPredioServicioMedidor.iIdTipoTarifa = tarPrediosLecturas.iIdTipoTarifa INNER JOIN tarMes ON tarPrediosLecturas.idMes = tarMes.idMes" _
            '    & " WHERE padPredioServicioMedidor.idpredio = " & idpredio & " AND  tarPrediosLecturas.iAnioTarifa<=" & anio & " "

            SQLTEXT = " SELECT padPredioServicioMedidor.idpredio, padPredioServicioMedidor.Codigo, view_PrediosServiciosUnicos.vNroPredio, view_PrediosServiciosUnicos.TipoPredio, view_PrediosServiciosUnicos.TipoServicio, tarPrediosLecturas.idLectura, " _
            & " tarPrediosLecturas.iAnioTarifa, tarPrediosLecturas.idMes, tarMes.Mes, tarPrediosLecturas.dFechaLectura, tarPrediosLecturas.fLecturaM3, tarPrediosLecturas.fLecturaLt, tarPrediosLecturas.fVolumenTotal,  " _
            & " tarPrediosLecturas.fVolumenConsumo, tarPrediosLecturas.vReferencia, tarPrediosLecturas.fVolumenM3, tarPrediosLecturas.dFechaRegistro, view_PrediosServiciosUnicos.idCalle, padPredioServicioMedidor.idMedidor " _
            & " FROM padPredioServicioMedidor INNER JOIN " _
            & " view_PrediosServiciosUnicos ON padPredioServicioMedidor.idpredio = view_PrediosServiciosUnicos.idPredio AND padPredioServicioMedidor.vIdJas = view_PrediosServiciosUnicos.vIdJas AND  " _
            & " padPredioServicioMedidor.idMedidor = view_PrediosServiciosUnicos.idMedidor INNER JOIN tarPrediosLecturas ON padPredioServicioMedidor.vIdJas = tarPrediosLecturas.vIdJas AND padPredioServicioMedidor.idpredio = tarPrediosLecturas.idpredio AND  " _
            & " padPredioServicioMedidor.iIdTipoTarifa = tarPrediosLecturas.iIdTipoTarifa AND padPredioServicioMedidor.idMedidor = tarPrediosLecturas.idMedidor INNER JOIN tarMes ON tarPrediosLecturas.idMes = tarMes.idMes  " _
            & " WHERE  padPredioServicioMedidor.idpredio = " & idpredio & " AND tarPrediosLecturas.iAnioTarifa <= " & anio & "  and padPredioServicioMedidor.idMedidor = " & idmed & " "


            dt = c.Query(SQLTEXT)
            c.Close()
        End If
        Return dt
        'Return dt
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
        'Dim cdt1_8 As DevComponents.AdvTree.Cell
        'Dim cdt1_9 As DevComponents.AdvTree.Cell
        'Dim cdt1_10 As DevComponents.AdvTree.Cell
        'Dim cdt1_11 As DevComponents.AdvTree.Cell
        'Dim cdt1_12 As DevComponents.AdvTree.Cell
        'Dim cdt1_13 As DevComponents.AdvTree.Cell



        Dim _styleRight As DevComponents.DotNetBar.ElementStyle
        _styleRight = New DevComponents.DotNetBar.ElementStyle()
        _styleRight.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Far

        tv.Nodes.Clear()

        Try
            If (c.Connect) Then


                '''sin filtro
                'sql = " SELECT view_PrediosServicio.vNroPredio, padPredioServicioMedidor.Codigo, view_PrediosServicio.Usuario, view_PrediosServicio.vIdJas, view_PrediosServicio.idpredio, " _
                '& " view_PrediosServicio.iIdTipoTarifa, tarPrediosLecturas.iAnioTarifa, tarMes.Mes, tarPrediosLecturas.fVolumenConsumo, tarPrediosLecturas.fVolumenM3,'' as MontoFacturado,'' as Redondeo FROM view_PrediosServicio INNER JOIN tarPrediosLecturas ON view_PrediosServicio.idpredio = tarPrediosLecturas.idpredio " _
                '& " AND view_PrediosServicio.vIdJas = tarPrediosLecturas.vIdJas INNER JOIN tarMes ON tarPrediosLecturas.idMes = tarMes.idMes INNER JOIN  " _
                '& " padPredioServicioMedidor ON view_PrediosServicio.idpredio = padPredioServicioMedidor.idpredio AND view_PrediosServicio.vIdJas = padPredioServicioMedidor.vIdJas AND  view_PrediosServicio.iIdTipoTarifa = padPredioServicioMedidor.iIdTipoTarifa " _
                '& " WHERE(tarPrediosLecturas.fVolumenConsumo > 0) AND (view_PrediosServicio.iIdTipoTarifa = " & IdTipoTarifa & ") AND (tarPrediosLecturas.iAnioTarifa = " & Idaño & ") AND (tarPrediosLecturas.idMes = " & Idmes & ") AND (view_PrediosServicio.idcalle = " & Idcalle & ") AND (padPredioServicioMedidor.cEstado = '1') "


                '''''con filtro
                'sql = " SELECT view_PrediosServicio.vNroPredio, padPredioServicioMedidor.Codigo, view_PrediosServicio.Usuario, view_PrediosServicio.vIdJas, view_PrediosServicio.idpredio,  " _
                '& " view_PrediosServicio.iIdTipoTarifa, tarPrediosLecturas.iAnioTarifa, tarMes.Mes, tarPrediosLecturas.fVolumenConsumo, tarPrediosLecturas.fVolumenM3, '' AS MontoFacturado,'' AS Redondeo FROM view_PrediosServicio INNER JOIN " _
                '& " tarPrediosLecturas ON view_PrediosServicio.idpredio = tarPrediosLecturas.idpredio AND view_PrediosServicio.vIdJas = tarPrediosLecturas.vIdJas INNER JOIN tarMes ON tarPrediosLecturas.idMes = tarMes.idMes INNER JOIN " _
                '& " padPredioServicioMedidor ON view_PrediosServicio.idpredio = padPredioServicioMedidor.idpredio AND view_PrediosServicio.vIdJas = padPredioServicioMedidor.vIdJas AND  " _
                '& " view_PrediosServicio.iIdTipoTarifa = padPredioServicioMedidor.iIdTipoTarifa " _
                '& " WHERE(tarPrediosLecturas.fVolumenConsumo > 0) AND (view_PrediosServicio.iIdTipoTarifa = " & IdTipoTarifa & ") AND (tarPrediosLecturas.iAnioTarifa = " & Idaño & ") AND (tarPrediosLecturas.idMes = " & Idmes & ") AND (view_PrediosServicio.idcalle = " & Idcalle & ") AND padPredioServicioMedidor.cEstado = '1' " _
                ' & " AND (view_PrediosServicio.idpredio NOT IN (SELECT    tarDetalleDeudaPredio.idPredio FROM tarDetalleDeudaPredio WHERE     (vIdJas = view_PrediosServicio.vIdJas) AND (iAnioTarifa = " & Idaño & ") AND (idMes = " & Idmes & ") AND (iIdTipoTarifa = " & IdTipoTarifa & ") ))"
                ''''''
                sql = " SELECT  padPredio.vNroPredio AS Nro, padPredio.vNombre AS Predio, Padusuario.vApePaterno + SPACE(1) + Padusuario.vApeMaterno + SPACE(1) + Padusuario.vUsuario AS Usuario, padPredio.vIdJas, padPredio.idpredio,'1' as EXP1,  padPredio.idcalle  " _
                 & " FROM   padUsuarioPredio INNER JOIN Padusuario ON padUsuarioPredio.vIdJas = Padusuario.vIdJas AND padUsuarioPredio.iIdusuario = Padusuario.iIdUsuario INNER JOIN padPredio ON padUsuarioPredio.vIdJas = padPredio.vIdJas AND padUsuarioPredio.idpredio = padPredio.idpredio  " _
                 & " WHERE (padUsuarioPredio.cEstado = '1') AND (padPredio.idcalle = " & Idcalle & ") AND (padPredio.idpredio NOT IN  " _
                 & " (SELECT idPredio FROM tarPrediosLecturas WHERE      (vIdJas = padPredio.vIdJas) AND (iAnioTarifa = " & Idaño & ") AND (idMes = " & Idmes & ") AND (idPredio = padPredio.idpredio) AND (iIdTipoTarifa = " & IdTipoTarifa & ")))ORDER BY Usuario"


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
                    'cdt1_8 = New DevComponents.AdvTree.Cell
                    'cdt1_9 = New DevComponents.AdvTree.Cell
                    'cdt1_10 = New DevComponents.AdvTree.Cell
                    'cdt1_11 = New DevComponents.AdvTree.Cell
                    'cdt1_12 = New DevComponents.AdvTree.Cell
                    'cdt1_13 = New DevComponents.AdvTree.Cell
                    n1.Cells.Add(cdt1_1)
                    n1.Cells.Add(cdt1_2)
                    n1.Cells.Add(cdt1_3)
                    n1.Cells.Add(cdt1_4)
                    n1.Cells.Add(cdt1_5)
                    n1.Cells.Add(cdt1_6)
                    n1.Cells.Add(cdt1_7)
                    'n1.Cells.Add(cdt1_8)
                    'n1.Cells.Add(cdt1_9)
                    'n1.Cells.Add(cdt1_10)
                    'n1.Cells.Add(cdt1_11)
                    'n1.Cells.Add(cdt1_12)
                    'n1.Cells.Add(cdt1_13)

                    n1.Cells(0).Text = midatarow(0).ToString  'Nro
                    n1.Cells(1).Text = midatarow(1).ToString  'codigo
                    n1.Cells(2).Text = midatarow(2).ToString  'Usuario
                    n1.Cells(3).Text = midatarow(3).ToString  'vIdJas
                    n1.Cells(4).Text = midatarow(4).ToString  'IdPredio
                    n1.Cells(5).Text = midatarow(5).ToString  'IIdTipoTarifa
                    n1.Cells(6).Text = midatarow(6).ToString  'Año
                    'n1.Cells(7).Text = midatarow(7).ToString  'Mes
                    'n1.Cells(8).Text = midatarow(8).ToString  'VolumenLt
                    'n1.Cells(9).Text = midatarow(9).ToString  'VolumenM3
                    'n1.Cells(10).Text = midatarow(10).ToString  'MONTO
                    'n1.Cells(11).Text = midatarow(11).ToString  'MONTO
                    'n1.Cells(12).Text = 0 'MONTO
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


    Public Function Insert(ByVal vIdJas As String, ByVal idPredio As Integer, ByVal idtipotarifa As Integer, ByVal anio As Integer, ByVal idmes As Integer, ByVal codigo As String, ByVal FECHA As Date, ByVal usuario As String, ByVal idmedidor As Integer) As Boolean
        Dim cmd As New SqlCommand()
        Dim c As New ACCESO.Conexion

        Me._idLectura = Me.NewId
        If (c.Connect) Then
            cmd.CommandText = "INSERT INTO tarPrediosLecturas (vIdJas,idPredio, iIdTipoTarifa, idLectura, iAnioTarifa,idMes,dFechaRegistro,dFechaLectura, fLecturaM3,fLecturaLt,fVolumenTotal,fVolumenConsumo,fVolumenM3,vReferencia, vUsuario, idMedidor)" _
                            & " VALUES(@IDJAS, @IDPREDIO,@TIPOTARIFA,@IDLECTURA,@ANIO,@MES,@DFECHA,@FECHACTUAL,@LECTURAM3,@LECTURALT,@VOLTOTAL,@VOLCONSUMO,@VOLCONSUMOM3,@REFERENCIA,@USUARIO,@IDMEDIDOR)"
            cmd.Parameters.AddWithValue("@IDJAS", vIdJas)
            'cmd.Parameters.AddWithValue("@MES", Me._idMes)
            cmd.Parameters.AddWithValue("@IDPREDIO", idPredio)
            cmd.Parameters.AddWithValue("@TIPOTARIFA", idtipotarifa)
            'cmd.Parameters.AddWithValue("@IDMEDIDOR", idMedidor)
            cmd.Parameters.AddWithValue("@IDLECTURA", _idLectura)
            cmd.Parameters.AddWithValue("@ANIO", anio)
            cmd.Parameters.AddWithValue("@MES", idmes)
            cmd.Parameters.AddWithValue("@DFECHA", ACCESO.Conexion.getDateServer)
            cmd.Parameters.AddWithValue("@FECHACTUAL", Me._dFechaLectura)
            cmd.Parameters.AddWithValue("@LECTURAM3", Me._fLecturaM3)
            cmd.Parameters.AddWithValue("@LECTURALT", Me._fLecturaLt)
            cmd.Parameters.AddWithValue("@VOLTOTAL", Me._fVolumenTotal)
            cmd.Parameters.AddWithValue("@VOLCONSUMO", Me._fVolumenConsumo)
            cmd.Parameters.AddWithValue("@VOLCONSUMOM3", Me._fVolumenM3)
            cmd.Parameters.AddWithValue("@REFERENCIA", Me._vReferencia)
            cmd.Parameters.AddWithValue("@USUARIO", Me._vUsuario)
            cmd.Parameters.AddWithValue("@IDMEDIDOR", idMedidor)

            'cmd.Parameters.AddWithValue("@FECHA", FECHA) 'cmd.Parameters.AddWithValue("@FPAGO", DBNull.Value)
            'cmd.Parameters.AddWithValue("@ESTADO", 1)

            c.IniTransaction()
            If (c.Insert(cmd) = False) Then
                MsgBox(c.msgError)
            Else
                MsgBox("Lectura Registrada Satisfactoriamente", MsgBoxStyle.Information)

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

    Public Shared Function delete(ByVal idpredio, ByVal anio, ByVal idmes) As Boolean
        Dim c As New ACCESO.Conexion

        If (c.Connect) Then
            If (c.Delete("delete  from tarPrediosLecturas  where idpredio=" & idpredio & "  and iAnioTarifa= " & anio & "  and idmes=" & idmes & "")) Then

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
