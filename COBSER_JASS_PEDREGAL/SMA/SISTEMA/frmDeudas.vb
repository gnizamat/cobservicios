Public Class frmDeudas
    Public sql As String
    Public IdCalle As Integer
    Public Año As Integer
    Public Mes As Integer
    Public TipoTarifa As Integer

    Private Sub btnCalcularDeuda_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalcularDeuda.Click
        Me.Close()
    End Sub

    Private Sub frmDeudas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
       
        ListTree(tvPredios, IdCalle, Mes, Año, TipoTarifa)
    End Sub

    Public Sub ListTree(ByRef tv As DevComponents.AdvTree.AdvTree, ByVal Idcalle As Integer, ByVal Idmes As Integer, ByVal Idaño As Integer, ByVal tipotar As Integer)
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
        'Dim cdt1_11 As DevComponents.AdvTree.Cell
        'Dim cdt1_12 As DevComponents.AdvTree.Cell

        Dim _styleRight As DevComponents.DotNetBar.ElementStyle
        _styleRight = New DevComponents.DotNetBar.ElementStyle()
        _styleRight.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Far

        tv.Nodes.Clear()

        Try
            If (c.Connect) Then

                sql = "SELECT padPredio.vNroPredio as Nro, padPredio.vNombre as Predio, Padusuario.vApePaterno+space(1)+ Padusuario.vApeMaterno+space(1)+ Padusuario.vUsuario as Usuario, " _
                 & " tarDetalleDeudaPredio.fSaldo as Deuda, tarDetalleDeudaPredio.iAnioTarifa as Año, tarDetalleDeudaPredio.idMes as Mes, " _
                 & " tarDetalleDeudaPredio.vConcepto as Concepto, tarDetalleDeudaPredio.dFechaDeuda as FechaGeneración, tarDetalleDeudaPredio.cPagado as Estado " _
                 & " FROM     tarDetalleDeudaPredio INNER JOIN " _
                 & " padPredio ON tarDetalleDeudaPredio.vIdJas = padPredio.vIdJas AND tarDetalleDeudaPredio.idPredio = padPredio.idpredio INNER JOIN " _
                 & " Calles ON padPredio.idcalle = Calles.idCalle INNER JOIN " _
                 & " padUsuarioPredio ON padPredio.vIdJas = padUsuarioPredio.vIdJas AND padPredio.idpredio = padUsuarioPredio.idpredio INNER JOIN " _
                 & " Padusuario ON padUsuarioPredio.vIdJas = Padusuario.vIdJas AND padUsuarioPredio.iIdusuario = Padusuario.iIdUsuario " _
                 & " WHERE(Calles.idCalle = " & Idcalle & " And tarDetalleDeudaPredio.iAnioTarifa = " & Idaño & " And tarDetalleDeudaPredio.idMes=" & Idmes & " AND tarDetalleDeudaPredio.cPagado = '0')  " _
                 & " ORDER BY  Padusuario.vApePaterno + SPACE(1) + Padusuario.vApeMaterno + SPACE(1) + Padusuario.vUsuario "
                '''and tarDetalleDeudaPredio.iIdTipoTarifa=" & tipotar & " 
                dt1 = c.Query(sql)
                For Each midatarow As DataRow In dt1.Rows
                    n1 = New DevComponents.AdvTree.Node

                    'n1.CheckBoxVisible = True
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
                    'cdt1_11 = New DevComponents.AdvTree.Cell
                    'cdt1_12 = New DevComponents.AdvTree.Cell

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
                    'n1.Cells.Add(cdt1_11)
                    'n1.Cells.Add(cdt1_12)

                    n1.Cells(0).Text = midatarow(0).ToString  'Nro
                    n1.Cells(1).Text = midatarow(1).ToString  'Predio
                    n1.Cells(2).Text = midatarow(2).ToString  'Usuario
                    n1.Cells(3).Text = midatarow(3).ToString  'Deuda
                    n1.Cells(4).Text = midatarow(4).ToString  'año
                    n1.Cells(5).Text = midatarow(5).ToString  'mes
                    n1.Cells(6).Text = midatarow(6).ToString  'concepto
                    n1.Cells(7).Text = midatarow(7).ToString  'Fecha
                    n1.Cells(8).Text = midatarow(8).ToString  'Estado
                    'n1.Cells(9).Text = midatarow(9).ToString  'Estado
                    'n1.Cells(10).Text = midatarow(10).ToString  'IdCalle
                    'n1.Cells(11).Text = midatarow(11).ToString  'IdPredio

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