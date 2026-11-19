Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Data.OleDb
Imports ACCESO
Imports LOGICA

Public Class clsFacturacion
    Private _idFactaracion As Integer
    Private _iAnioTarifa As Integer
    Private _idMes As Integer
    Private _idPredio As Integer
    Private _idCaja As Integer
    Private _vNroDocumento As String
    Private _fMontoTotal As Double
    Private _dFecha As Date
    Private _vUsuario As String
    Private _cEstado As String
    'Private _fInteres As String


    Public Property Id()
        Get
            Return Me._idFactaracion
        End Get
        Set(ByVal value)
            Me._idFactaracion = value
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
    Public Property caja()
        Get
            Return Me._idCaja
        End Get
        Set(ByVal value)
            Me._idCaja = value
        End Set
    End Property

    Public Property NroDoc()
        Get
            Return Me._vNroDocumento
        End Get
        Set(ByVal value)
            Me._vNroDocumento = value
        End Set
    End Property

    Public Property Monto()
        Get
            Return Me._fMontoTotal
        End Get
        Set(ByVal value)
            Me._fMontoTotal = value
        End Set
    End Property

    Public Property Fecha()
        Get
            Return Me._dFecha
        End Get
        Set(ByVal value)
            Me._dFecha = value
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
    Public Property Estado()
        Get
            Return Me._cEstado
        End Get
        Set(ByVal value)
            Me._cEstado = value
        End Set
    End Property


    Private Function NewId()
        Dim c As New ACCESO.Conexion
        Dim dt As New DataTable
        Dim id As Integer
        If (c.Connect) Then
            dt = c.Query("select isNull(max(idFacturacion),0) from dbo.tarFacturacion where iAnioTarifa=" & Me._iAnioTarifa)
            c.Close()
            id = dt.Rows(0).Item(0) + 1
        End If
        Return id
    End Function

    Public Function Insert(ByVal Idcalle As Integer, ByVal Idmes As Integer, ByVal Idaño As Integer) As Boolean
        Dim cmd As New SqlCommand() ' , ByVal idDetDeuda As Integer
        Dim c As New ACCESO.Conexion
        Dim sql As String

        Me._idFactaracion = Me.NewId
        If (c.Connect) Then
            cmd.CommandText = "INSERT INTO tarFacturacion( idFacturacion, iAnioTarifa, idMes, idPredio,idCaja, vNroDocumento, fMontoTotal, dFecha,vUsuario, cEstado)" _
                            & "VALUES (@ID,@ANIO,@MES,@PRED,@CAJA, @NRODOC,@MONTO,@FECHA,@USUARIO,@ESTADO)"
            cmd.Parameters.AddWithValue("@ID", Me._idFactaracion)
            cmd.Parameters.AddWithValue("@ANIO", Me._iAnioTarifa)
            cmd.Parameters.AddWithValue("@MES", Me._idMes)
            cmd.Parameters.AddWithValue("@PRED", Me._idPredio)
            cmd.Parameters.AddWithValue("@CAJA", Me._idCaja)
            cmd.Parameters.AddWithValue("@NRODOC", "F" & Idaño & "-" & Right("000000" & Me._idFactaracion, 6))
            cmd.Parameters.AddWithValue("@MONTO", Me._fMontoTotal)
            cmd.Parameters.AddWithValue("@FECHA", Me._dFecha)
            cmd.Parameters.AddWithValue("@USUARIO", Me._vUsuario)
            cmd.Parameters.AddWithValue("@ESTADO", Me._cEstado)
            'cmd.Parameters.AddWithValue("@INTERES", interes)

            'c.IniTransaction()
            If (c.Insert(cmd) = True) Then
                'MsgBox(c.msgError)
                'Endif

                ' INSERTAMOS LOS DETALLE
                Dim DF As New clsFacturacionDetalle

                sql = "INSERT INTO tarFacturacionDetalle " _
                  & " SELECT " & Me._idFactaracion & " as idFacturacion, tarDetalleDeudaPredio.vIdJas, tarDetalleDeudaPredio.iAnioTarifa, tarDetalleDeudaPredio.idMes, tarDetalleDeudaPredio.idPredio, tarDetalleDeudaPredio.idDetalleDeuda, tarDetalleDeudaPredio.iIdTipoTarifa" _
                  & " FROM     padUsuarioPredio INNER JOIN" _
                  & " Padusuario ON padUsuarioPredio.vIdJas = Padusuario.vIdJas AND padUsuarioPredio.iIdusuario = Padusuario.iIdUsuario INNER JOIN" _
                  & " tarDetalleDeudaPredio INNER JOIN" _
                  & " padPredio ON tarDetalleDeudaPredio.vIdJas = padPredio.vIdJas AND tarDetalleDeudaPredio.idPredio = padPredio.idpredio INNER JOIN" _
                  & " Calles ON padPredio.idcalle = Calles.idCalle ON padUsuarioPredio.iIdusuario = padPredio.iIdusuario AND padUsuarioPredio.idpredio = padPredio.idpredio AND padUsuarioPredio.vIdJas = padPredio.vIdJas"
                If Idcalle > 0 Then
                    sql = sql & " WHERE  (Calles.idCalle = " & Idcalle & ") AND "
                Else
                    sql = sql & "  WHERE  "

                End If

                sql = sql & " (tarDetalleDeudaPredio.idMes = " & Idmes & ") AND (tarDetalleDeudaPredio.iAnioTarifa = " & Idaño & ") " _
                  & " AND  padPredio.idpredio=" & Me._idPredio & " AND  padPredio.idpredio NOT IN (" _
                    & " Select idPredio" _
                    & " FROM View_Facturacion" _
                    & " WHERE  (iAnioTarifa = tarDetalleDeudaPredio.iAnioTarifa) AND (idMes = tarDetalleDeudaPredio.idMes) AND (idcalle = Calles.idCalle )  AND (idDetalleDeuda=tarDetalleDeudaPredio.idDetalleDeuda)" _
                    & ")"
                'AND tarDetalleDeudaPredio.idDetalleDeuda= " & idDetDeuda _
                c.Query(sql)

                If (Not c.myError) Then
                    'c.Commit()
                    'MsgBox("Facturación Generada para el mes de " & Idmes & " del año " & Idaño & "  Satisfactoriamente", MsgBoxStyle.Information)
                    Return True
                Else
                    'c.RollBack()
                    'MsgBox("Ocurrio un error mientras se generaba la facturación. Se cancelo el proceso de Importación", MsgBoxStyle.Critical)
                    Return False
                End If
            Else
                'c.RollBack()
                Return False
            End If
        End If
    End Function

    Public Sub ListTree(ByRef tv As DevComponents.AdvTree.AdvTree, ByVal Idcalle As Integer, ByVal Idmes As Integer, ByVal Idaño As Integer)
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
        'Dim cdt1_10 As DevComponents.AdvTree.Cell

        Dim _styleRight As DevComponents.DotNetBar.ElementStyle
        _styleRight = New DevComponents.DotNetBar.ElementStyle()
        _styleRight.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Far

        tv.Nodes.Clear()

        Try
            'Condicion= (Calles.idCalle = 12) AND (tarDetalleDeudaPredio.idMes = 3) AND (tarDetalleDeudaPredio.iAnioTarifa = 2021) AND (tarDetalleDeudaPredio.iIdTipoTarifa = 1)
            If (c.Connect) Then

              

                'sql = "SELECT padPredio.vNroPredio as Nro, padPredio.vNombre as Predio, Padusuario.vApePaterno+SPACE(1)+ Padusuario.vApeMaterno+SPACE(1)+ Padusuario.vUsuario AS Usuario," _
                '    & " SUM(tarDetalleDeudaPredio.fSaldo) as Saldo,tarDetalleDeudaPredio.vIdJas, tarDetalleDeudaPredio.iAnioTarifa, tarDetalleDeudaPredio.idMes, " _
                '    & "                 tarDetalleDeudaPredio.idPredio, tarDetalleDeudaPredio.idDetalleDeuda" _
                '    & " FROM     padUsuarioPredio INNER JOIN Padusuario ON padUsuarioPredio.vIdJas = Padusuario.vIdJas AND padUsuarioPredio.iIdusuario = Padusuario.iIdUsuario" _
                '    & " INNER JOIN tarDetalleDeudaPredio INNER JOIN padPredio ON tarDetalleDeudaPredio.vIdJas = padPredio.vIdJas AND tarDetalleDeudaPredio.idPredio = padPredio.idpredio " _
                '    & " INNER JOIN Calles ON padPredio.idcalle = Calles.idCalle ON padUsuarioPredio.iIdusuario = padPredio.iIdusuario AND padUsuarioPredio.idpredio = padPredio.idpredio " _
                '    & " AND padUsuarioPredio.vIdJas = padPredio.vIdJas "
                'If Idcalle > 0 Then
                '    sql = sql & " WHERE  (Calles.idCalle = " & Idcalle & ") AND "
                'Else
                '    sql = sql & " WHERE  "
                'End If
                'sql = sql & "  (tarDetalleDeudaPredio.idMes = " & Idmes & ") AND (tarDetalleDeudaPredio.iAnioTarifa = " & Idaño & ") AND(tarDetalleDeudaPredio.cPagado = '0')" _
                '    & " AND  padPredio.idpredio NOT IN ( " _
                '    & " Select idPredio FROM View_Facturacion " _
                '    & " WHERE  (iAnioTarifa = tarDetalleDeudaPredio.iAnioTarifa) AND (idMes = tarDetalleDeudaPredio.idMes) AND (idcalle = Calles.idCalle ) " _
                '    & " )" _
                '    & " GROUP BY padPredio.vNroPredio , padPredio.vNombre, Padusuario.vApePaterno+SPACE(1)+ Padusuario.vApeMaterno+SPACE(1)+ Padusuario.vUsuario , " _
                '    & " tarDetalleDeudaPredio.vIdJas, tarDetalleDeudaPredio.iAnioTarifa, tarDetalleDeudaPredio.idMes, tarDetalleDeudaPredio.idPredio, tarDetalleDeudaPredio.iIdTipoTarifa,tarDetalleDeudaPredio.idDetalleDeuda"


                sql = "SELECT padPredio.vNroPredio AS Nro, padPredio.vNombre AS Predio, Padusuario.vApePaterno + SPACE(1) + Padusuario.vApeMaterno + SPACE(1) + Padusuario.vUsuario AS Usuario," _
                 & " SUM(tarDetalleDeudaPredio.fSaldo) AS Saldo, tarDetalleDeudaPredio.vIdJas, tarDetalleDeudaPredio.iAnioTarifa, tarDetalleDeudaPredio.idMes, tarDetalleDeudaPredio.idPredio,'' as idDetalleDeuda FROM padUsuarioPredio INNER JOIN " _
                 & " Padusuario ON padUsuarioPredio.vIdJas = Padusuario.vIdJas AND padUsuarioPredio.iIdusuario = Padusuario.iIdUsuario INNER JOIN tarDetalleDeudaPredio INNER JOIN " _
                 & " padPredio ON tarDetalleDeudaPredio.vIdJas = padPredio.vIdJas AND tarDetalleDeudaPredio.idPredio = padPredio.idpredio INNER JOIN Calles ON padPredio.idcalle = Calles.idCalle ON padUsuarioPredio.iIdusuario = padPredio.iIdusuario AND padUsuarioPredio.idpredio = padPredio.idpredio AND padUsuarioPredio.vIdJas = padPredio.vIdJas "

                If Idcalle > 0 Then
                    sql = sql & " WHERE  (Calles.idCalle = " & Idcalle & ") and  "
                Else
                    sql = sql & " WHERE  "
                End If
                sql = sql & "  (tarDetalleDeudaPredio.idMes =  " & Idmes & ") AND (tarDetalleDeudaPredio.iAnioTarifa = " & Idaño & ") AND (tarDetalleDeudaPredio.cPagado = '0') " _
                & " AND padPredio.idpredio NOT IN ( " _
                & " SELECT idPredio FROM View_Facturacion " _
                & " WHERE (iAnioTarifa = tarDetalleDeudaPredio.iAnioTarifa) AND (idMes = tarDetalleDeudaPredio.idMes) AND (idcalle = Calles.idCalle) " _
                & " ) " _
                & " GROUP BY padPredio.vNroPredio, padPredio.vNombre, Padusuario.vApePaterno + SPACE(1) + Padusuario.vApeMaterno + SPACE(1) + Padusuario.vUsuario, tarDetalleDeudaPredio.vIdJas, tarDetalleDeudaPredio.iAnioTarifa, tarDetalleDeudaPredio.idMes, tarDetalleDeudaPredio.idPredio "
                

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
                    'cdt1_10 = New DevComponents.AdvTree.Cell

                    n1.Cells.Add(cdt1_1)
                    n1.Cells.Add(cdt1_2)
                    n1.Cells.Add(cdt1_3)
                    n1.Cells.Add(cdt1_4)
                    n1.Cells.Add(cdt1_5)
                    n1.Cells.Add(cdt1_6)
                    n1.Cells.Add(cdt1_7)
                    n1.Cells.Add(cdt1_8)
                    n1.Cells.Add(cdt1_9)
                    'n1.Cells.Add(cdt1_10)

                    n1.Cells(0).Text = midatarow(0).ToString  'Nro
                    n1.Cells(1).Text = midatarow(1).ToString  'Predio
                    n1.Cells(2).Text = midatarow(2).ToString  'Usuario
                    n1.Cells(3).Text = midatarow(3).ToString  'Saldo
                    n1.Cells(4).Text = midatarow(4).ToString  'Jas
                    n1.Cells(5).Text = midatarow(5).ToString  'año
                    n1.Cells(6).Text = midatarow(6).ToString  'mes
                    n1.Cells(7).Text = midatarow(7).ToString  'IdPredio
                    n1.Cells(8).Text = midatarow(8).ToString  'DetDeuda
                    'n1.Cells(9).Text = midatarow(9).ToString  'TipoTar

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

    Public Shared Function ListFacturacion(Optional ByVal condicion As String = "") As DataTable
        Dim dt As New DataTable
        Dim c As New ACCESO.Conexion
        If (c.Connect) Then
            Dim strQuery As String = " Select * from view_RecibosFacturacion "
            dt = c.Query(strQuery & condicion & " ORDER BY vNroDocumento")
            c.Close()

        End If
        Return dt
        'Return dt
    End Function

    Public Shared Sub elimina(ByVal nroRecibo As String, ByVal predio As Integer, ByVal idfacturacion As Integer, ByVal anio As String, ByVal idmes As Integer)

        Dim cmd As New SqlCommand()
        Dim c As New ACCESO.Conexion
        Dim pado As New clsPago
        Dim fac As New clsFacturacion
        Dim sql As String

        If (c.Connect) Then
           
            sql = "delete from  tarFacturacion WHERE  idFacturacion= " & idfacturacion & " and idPredio = " & predio & " and  vNroDocumento = '" & nroRecibo & "' and iAnioTarifa = '" & anio & "' and idmes=" & idmes & ""
            c.Query(sql)
            sql = "delete from  tarFacturacionDetalle WHERE  idFacturacion= " & idfacturacion & " and  idPredio = " & predio & "  and iAnioTarifa = '" & anio & "' and idmes=" & idmes & ""
            c.Query(sql)

            'sql = "UPDATE tarFacturacion SET cEstado='0' WHERE  vNroDocumento IN(" & facturaciones & ")"
            'c.Query(sql)
           
            c.Close()
        End If
    End Sub
End Class

