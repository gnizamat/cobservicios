Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports ACCESO
Public Class clsInteres

    Public Sub ListTree(ByRef tv As DevComponents.AdvTree.AdvTree, ByVal Idcalle As Integer, ByVal Idmes As Integer, ByVal Idaño As Integer, ByVal monto As Double)
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
        Dim _styleRight As DevComponents.DotNetBar.ElementStyle
        _styleRight = New DevComponents.DotNetBar.ElementStyle()
        _styleRight.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Far
        tv.Nodes.Clear()
        Try
            If (c.Connect) Then
                sql = "SELECT view_PrediosBasico.Calle, view_PrediosBasico.usuario, view_PrediosBasico.vNombre AS Predio, tarDetalleDeudaPredio.idPredio, tarDetalleDeudaPredio.idMes, tarDetalleDeudaPredio.iAnioTarifa, tarDetalleDeudaPredio.fSaldo, " _
                & " tarDetalleDeudaPredio.fInteres, view_PrediosBasico.idcalle, tarDetalleDeudaPredio.iIdTipoTarifa, tarTipoTarifa.vNombre AS TipoTarifa " _
                & " FROM tarDetalleDeudaPredio INNER JOIN view_PrediosBasico ON tarDetalleDeudaPredio.idPredio = view_PrediosBasico.idpredio INNER JOIN " _
                & " tarTipoTarifa ON tarDetalleDeudaPredio.vIdJas = tarTipoTarifa.vIdJas AND tarDetalleDeudaPredio.iIdTipoTarifa = tarTipoTarifa.iIdTipoTarifa " _
                & " WHERE (tarDetalleDeudaPredio.fSaldo > 0) AND (tarDetalleDeudaPredio.fInteres = 0) AND (tarDetalleDeudaPredio.idMes < " & Idmes & " ) AND (tarDetalleDeudaPredio.iAnioTarifa <= " & Idaño & " ) OR  " _
                & " (tarDetalleDeudaPredio.fSaldo > 0) AND (tarDetalleDeudaPredio.fInteres = 0) AND (tarDetalleDeudaPredio.iAnioTarifa <= " & Idaño & " - 1) and (tarDetalleDeudaPredio.iIdTipoTarifa <= 4) " _
                & " GROUP BY tarDetalleDeudaPredio.idPredio, tarDetalleDeudaPredio.iAnioTarifa, tarDetalleDeudaPredio.idMes, tarDetalleDeudaPredio.fSaldo, tarDetalleDeudaPredio.fInteres, view_PrediosBasico.usuario, view_PrediosBasico.vNombre,  " _
                & " view_PrediosBasico.idcalle, view_PrediosBasico.Calle, tarDetalleDeudaPredio.iIdTipoTarifa, tarTipoTarifa.vNombre"

                If Idcalle > 0 Then
                    sql = sql & " HAVING  (view_PrediosBasico.idcalle = " & Idcalle & ") "
                Else
                    sql = sql & " "
                End If

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
                '    & "  idPredio = padPredio.idpredio And iIdTipoTarifa = " & IdTipoTarifa _
                '    & " ) " _
                '    & " AND (padPredio.idpredio NOT IN (SELECT idPredio " _
                '    & " FROM padCortesPredios " _
                '    & "    WHERE   (vIdJas = padPredio.vIdJas) AND (idPredio = padPredio.idpredio) AND cEstadoPredio=1 )) " _
                '    & " ORDER BY  Padusuario.vApePaterno + SPACE(1) + Padusuario.vApeMaterno + SPACE(1) + Padusuario.vUsuario "
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
                    n1.Cells(0).Text = midatarow(0).ToString  'Nro
                    n1.Cells(1).Text = midatarow(1).ToString  'Predio
                    n1.Cells(2).Text = midatarow(2).ToString  'Usuario
                    n1.Cells(3).Text = midatarow(3).ToString  'vIdJas
                    n1.Cells(4).Text = midatarow(4).ToString  'IdPredio
                    n1.Cells(5).Text = midatarow(5).ToString  'IIdTipoTarifa
                    n1.Cells(6).Text = midatarow(6).ToString  'SALDO
                    n1.Cells(7).Text = monto   'MORA
                    n1.Cells(8).Text = midatarow(8).ToString  'IdCalle
                    n1.Cells(9).Text = midatarow(9).ToString  'IdCalle
                    n1.Cells(10).Text = midatarow(10).ToString  'IdCalle

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
