Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Data.OleDb
Imports ACCESO
Imports LOGICA

Public Class clsCobranza

    Public Sub ListTree(ByRef tv As DevComponents.AdvTree.AdvTree, ByVal idPredio As Integer, ByVal anio As String)
        Dim c As New ACCESO.Conexion
        Dim dt1 As New DataTable
        Dim sql As String
        Dim n1 As New DevComponents.AdvTree.Node
        Dim n2 As New DevComponents.AdvTree.Node
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
        Dim _styleRight As DevComponents.DotNetBar.ElementStyle
        _styleRight = New DevComponents.DotNetBar.ElementStyle()
        _styleRight.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Far

        tv.Nodes.Clear()

        Try
            If (c.Connect) Then

                '' modificado por JAT
                'sql = " SELECT tarFacturacion.iAnioTarifa, tarMes.Mes,tarFacturacion.vNroDocumento," _
                '& " tarFacturacion.fMontoTotal,'0.00' as Mora,'' as Vol, '' as Servicio, tarFacturacion.idFacturacion,tarFacturacion.idMes " _
                '& " FROM     tarFacturacion INNER JOIN tarMes ON tarFacturacion.idMes = tarMes.idMes " _
                '& " WHERE  (tarFacturacion.idPredio = " & idPredio & ") AND (tarFacturacion.cEstado = 0)"


                ' '' modificado por GILBERT
                'sql = " SELECT tarFacturacion.iAnioTarifa, tarMes.Mes, tarFacturacion.vNroDocumento, tarFacturacion.fMontoTotal,tarDetalleDeudaPredio.fSaldo,tarDetalleDeudaPredio.fInteres AS Mora,  tarDetalleDeudaPredio.fVolumen AS Vol, '' AS Servicio, tarFacturacion.idFacturacion, tarFacturacion.idMes " _
                '& " FROM tarFacturacion INNER JOIN tarMes ON tarFacturacion.idMes = tarMes.idMes INNER JOIN " _
                '& " tarDetalleDeudaPredio ON tarFacturacion.iAnioTarifa = tarDetalleDeudaPredio.iAnioTarifa AND tarFacturacion.idMes = tarDetalleDeudaPredio.idMes AND tarFacturacion.idPredio = tarDetalleDeudaPredio.idPredio " _
                '& " WHERE  (tarFacturacion.idPredio = " & idPredio & ") AND (tarFacturacion.cEstado = 0)  "

                ' modificado por GILBERT - 26-08-2024
                sql = " SELECT DISTINCT tarFacturacion.iAnioTarifa, tarMes.Mes, tarFacturacion.vNroDocumento, tarFacturacion.fMontoTotal,tarFacturacion.fMontoTotal as fSaldo,tarDetalleDeudaPredio.fInteres AS Mora,  tarDetalleDeudaPredio.fVolumen AS Vol, '' AS Servicio, tarFacturacion.idFacturacion, tarFacturacion.idMes " _
                & " FROM tarFacturacion INNER JOIN tarMes ON tarFacturacion.idMes = tarMes.idMes INNER JOIN " _
                & " tarDetalleDeudaPredio ON tarFacturacion.iAnioTarifa = tarDetalleDeudaPredio.iAnioTarifa AND tarFacturacion.idMes = tarDetalleDeudaPredio.idMes AND tarFacturacion.idPredio = tarDetalleDeudaPredio.idPredio " _
                & " WHERE  (tarFacturacion.idPredio = " & idPredio & ") AND (tarFacturacion.cEstado = 0)  "

                'sql = " SELECT tarFacturacion.iAnioTarifa, tarMes.Mes, tarFacturacion.vNroDocumento, SUM(tarFacturacion.fMontoTotal + tarDetalleDeudaPredio.fInteres) AS fMontoTotal, tarDetalleDeudaPredio.fSaldo, tarDetalleDeudaPredio.fInteres AS Mora, " _
                '& " tarDetalleDeudaPredio.fVolumen AS Vol, '' AS Servicio, tarFacturacion.idFacturacion, tarFacturacion.idMes " _
                '& " FROM tarFacturacion INNER JOIN tarMes ON tarFacturacion.idMes = tarMes.idMes INNER JOIN " _
                '& " tarDetalleDeudaPredio ON tarFacturacion.iAnioTarifa = tarDetalleDeudaPredio.iAnioTarifa AND tarFacturacion.idMes = tarDetalleDeudaPredio.idMes AND tarFacturacion.idPredio = tarDetalleDeudaPredio.idPredio " _
                '& " WHERE  (tarFacturacion.idPredio = " & idPredio & ") AND (tarFacturacion.cEstado = 0)and tarFacturacion.iAnioTarifa LIKE " & anio & "  " _
                '& " GROUP BY tarFacturacion.iAnioTarifa, tarMes.Mes,  tarFacturacion.idFacturacion, tarFacturacion.idMes,tarFacturacion.vNroDocumento,tarDetalleDeudaPredio.fSaldo,tarDetalleDeudaPredio.fInteres,tarDetalleDeudaPredio.fVolumen"


                'If anio = 0 Then
                '    sql = sql & " Order by tarFacturacion.iAnioTarifa desc, tarFacturacion.idmes desc "
                'Else
                '    sql = sql & "  Order by iAnioTarifa desc, tarFacturacion.idmes desc "
                '    'sql = sql & "  Order by iAnioTarifa desc, tarFacturacion.idmes desc "
                'End If
                If anio = 0 Then
                    sql = sql & " Order by tarFacturacion.iAnioTarifa desc, tarFacturacion.idmes desc "
                Else
                    sql = sql & " and tarFacturacion.iAnioTarifa=" & anio & " Order by iAnioTarifa desc, tarFacturacion.idmes desc "
                End If
                dt1 = c.Query(sql)
                Dim MontoT As Double
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


                    n1.Cells(0).Text = midatarow(0).ToString  'Año
                    n1.Cells(1).Text = midatarow(1).ToString  'Mes
                    n1.Cells(2).Text = midatarow(2).ToString  'Nro doc
                    MontoT = +midatarow(4).ToString + midatarow(5).ToString 'Monto
                    'n1.Cells(3).Text = midatarow(3).ToString  'Monto
                    n1.Cells(3).Text = FormatCurrency(MontoT, 2) 'Monto
                    n1.Cells(4).Text = FormatCurrency(midatarow(4).ToString, 2) 'Volumen
                    n1.Cells(5).Text = FormatCurrency(midatarow(5).ToString, 2) 'servicio
                    n1.Cells(6).Text = midatarow(6).ToString  'IdFacturacion
                    n1.Cells(7).Text = midatarow(7).ToString  'Idmes
                    n1.Cells(8).Text = midatarow(8).ToString  'Mora
                    n1.Cells(9).Text = midatarow(9).ToString  'MontoTotal

                    'CDbl(tvDeudas.Nodes(nodo.Index).Cells(3).Text)
                    'n1.Cells(1).StyleNormal = _styleRight
                    'n1.Cells(1).StyleDisabled = _styleRight
                    'n1.Cells(1).StyleSelected = _styleRight

                    'Modificado por JAT
                    '******************************************************************************
                    Dim dt2 As New DataTable
                    sql = "SELECT tarDetalleDeudaPredio.fSaldo, tarDetalleDeudaPredio.fInteres,tarDetalleDeudaPredio.fVolumen, tarDetalleDeudaPredio.vConcepto" _
                        & " FROM     tarFacturacionDetalle INNER JOIN" _
                        & " tarDetalleDeudaPredio ON tarFacturacionDetalle.vIdJas = tarDetalleDeudaPredio.vIdJas AND tarFacturacionDetalle.idDetalleDeuda = tarDetalleDeudaPredio.idDetalleDeuda AND " _
                        & " tarFacturacionDetalle.iIdTipoTarifa = tarDetalleDeudaPredio.iIdTipoTarifa AND tarFacturacionDetalle.iAnioTarifa = tarDetalleDeudaPredio.iAnioTarifa AND tarFacturacionDetalle.idMes = tarDetalleDeudaPredio.idMes AND " _
                        & " tarFacturacionDetalle.idPredio = tarDetalleDeudaPredio.idPredio" _
                        & " WHERE  (tarFacturacionDetalle.idFacturacion = " & midatarow(8).ToString & ")  AND (tarFacturacionDetalle.iAnioTarifa = " & midatarow(0).ToString & ") AND " _
                        & " (tarFacturacionDetalle.idMes = " & midatarow(9).ToString & ") AND (tarFacturacionDetalle.idPredio = " & idPredio & ")"


                    dt2 = c.Query(sql)
                    For Each midatarow1 As DataRow In dt2.Rows
                        n2 = New DevComponents.AdvTree.Node

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

                        n2.Cells.Add(cdt1_1)
                        n2.Cells.Add(cdt1_2)
                        n2.Cells.Add(cdt1_3)
                        n2.Cells.Add(cdt1_4)
                        n2.Cells.Add(cdt1_5)
                        n2.Cells.Add(cdt1_6)
                        n2.Cells.Add(cdt1_7)
                        n2.Cells.Add(cdt1_8)
                        n2.Cells.Add(cdt1_9)
                        n2.Cells.Add(cdt1_10)

                        n2.Cells(0).Text = ""  'Año
                        n2.Cells(1).Text = ""  'Mes
                        n2.Cells(2).Text = ""  'Nro doc
                        n2.Cells(3).Text = ""  'T.fact
                        n2.Cells(4).Text = midatarow1(0).ToString  'Saldo
                        n2.Cells(5).Text = midatarow1(1).ToString  'mORA
                        n2.Cells(6).Text = midatarow1(2).ToString  'vol
                        n2.Cells(7).Text = midatarow1(3).ToString
                        n2.Cells(8).Text = ""  'IDFAC
                        n2.Cells(9).Text = ""  'IDMES


                        n1.Nodes.Add(n2)
                    Next
                    ' *****************************************************************************
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
