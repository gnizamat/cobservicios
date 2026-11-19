Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Data.OleDb
Imports ACCESO
Imports LOGICA

Public Class clsDeudaPredio
    Private _anio As Integer

    Private _idJunta As String
    Private _idComision As Integer
    Private _idpredio As Integer

    Private _idUsuario As Integer
    Private _idCorrelativo As Integer ' indica el dueño actual del predio
    Private _montoTotal As Decimal
    Private _saldoTotal As Decimal
    Private _interesTotal As Decimal
    Public Property SaldoTotal() As Decimal
        Get
            Return Me._saldoTotal
        End Get
        Set(ByVal value As Decimal)
            Me._saldoTotal = value
        End Set
    End Property
    Public Property InteresTotal() As Decimal
        Get
            Return Me._interesTotal
        End Get
        Set(ByVal value As Decimal)
            Me._interesTotal = value
        End Set
    End Property
    Public Property MontoTotal() As Decimal
        Get
            Return Me._montoTotal
        End Get
        Set(ByVal value As Decimal)
            Me._montoTotal = value
        End Set
    End Property
    Public Property IdUsuario() As Integer
        Get
            Return Me._idUsuario
        End Get
        Set(ByVal value As Integer)
            Me._idUsuario = value
        End Set
    End Property
    Public Property IdCorrelativo() As Integer
        Get
            Return Me._idCorrelativo
        End Get
        Set(ByVal value As Integer)
            Me._idCorrelativo = value
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
    Public Property idJunta()
        Get
            Return Me._idJunta
        End Get
        Set(ByVal value)
            Me._idJunta = value
        End Set
    End Property
    Public Property idComision()
        Get
            Return Me._idComision
        End Get
        Set(ByVal value)
            Me._idComision = value
        End Set
    End Property
    Public Property idPredio()
        Get
            Return Me._idpredio
        End Get
        Set(ByVal value)
            Me._idpredio = value
        End Set
    End Property
    'Public Property SysUsuario()
    '    Get
    '        Return Me._SysUsuario
    '    End Get
    '    Set(ByVal value)
    '        Me._SysUsuario = value
    '    End Set
    'End Property
    Sub New()

    End Sub
    Sub New(ByVal idjunta As String, ByVal idcomision As Integer, ByVal idpredio As Integer, ByVal idusuario As Integer, ByVal correlativo As Integer, ByVal anio As Integer)
        Me._idJunta = idjunta
        Me._idComision = idcomision
        Me._idUsuario = idusuario
        Me._idpredio = idpredio
        Me._idCorrelativo = correlativo
        Me._anio = anio
    End Sub
    Public Function VerificaExisteDeudaOpenConnection(ByRef c As ACCESO.Conexion) As Boolean
        Dim dt As New DataTable
        Dim estado As Boolean = False
        dt = c.Query("SELECT * FROM tarDeudaPredio where iAnioTarifa='" & Me._anio & "' and vIdJuntaUsuario='" & Me._idJunta & "' and iIdComisionRegante='" & Me._idComision & "' and iIdPredio='" & Me._idpredio & "'")
        If (dt.Rows.Count > 0) Then
            estado = True
        Else
            estado = False
        End If
        Return estado
    End Function
    Public Function ExisteDeudaExtraordinaria(ByRef c As ACCESO.Conexion, ByVal idResolucion As Integer) As Boolean
        Dim dt As New DataTable
        Dim estado As Boolean = False
        dt = c.Query("SELECT iIdDetalleDeuda FROM tarDeudaExtraordinaria where iAnioTarifa='" & Me._anio & "' and vIdJuntaUsuario='" & Me._idJunta & "' and iIdComisionRegante='" & Me._idComision & "' and iIdPredio='" & Me._idpredio & "' AND iIdResolucion='" & idResolucion & "'")
        If (dt.Rows.Count > 0) Then
            estado = True
        Else
            estado = False
        End If
        Return estado
    End Function
    Public Function VerificaExisteDeuda() As Boolean
        Dim c As New Conexion
        Dim dt As New DataTable
        Dim estado As Boolean = False
        If (c.Connect) Then
            dt = c.Query("SELECT * FROM tarDeudaPredio where iAnioTarifa='" & Me._anio & "' and vIdJuntaUsuario='" & Me._idJunta & "' and iIdComisionRegante='" & Me._idComision & "' and iIdPredio='" & Me._idpredio & "'")
            If (dt.Rows.Count > 0) Then
                estado = True
            Else
                estado = False
            End If
            c.Close()
        End If
        Return estado
    End Function
    Public Sub Insert()
        Dim cmd As New SqlCommand()
        Dim c As New ACCESO.Conexion
        If (c.Connect) Then
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "sp_tarDeudaPredio_insert"
            cmd.Parameters.AddWithValue("@ANIO", Me._anio)
            cmd.Parameters.AddWithValue("@IDJUNTA", Me._idJunta)
            cmd.Parameters.AddWithValue("@IDCOMISION", Me._idComision)
            cmd.Parameters.AddWithValue("@IDPREDIO", Me._idpredio)
            cmd.Parameters.AddWithValue("@IDUSUARIO", Me._idUsuario)
            cmd.Parameters.AddWithValue("@CORRELATIVO", Me._idCorrelativo)
            If (c.Execute(cmd) = False) Then
                MsgBox(c.msgError)
            End If
            c.Close()
        End If
    End Sub
    Public Sub InsertOpenConnection(ByRef c As ACCESO.Conexion)
        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "sp_tarDeudaPredio_insert"
        cmd.Parameters.AddWithValue("@ANIO", Me._anio)
        cmd.Parameters.AddWithValue("@IDJUNTA", Me._idJunta)
        cmd.Parameters.AddWithValue("@IDCOMISION", Me._idComision)
        cmd.Parameters.AddWithValue("@IDPREDIO", Me._idpredio)
        cmd.Parameters.AddWithValue("@IDUSUARIO", Me._idUsuario)
        cmd.Parameters.AddWithValue("@CORRELATIVO", Me._idCorrelativo)
        If (c.Execute(cmd) = False) Then
            MsgBox(c.msgError)
        End If
    End Sub
    'Public Function InsertDetallesDeuda(ByVal monto As Double, ByVal tipo_deuda As Integer, ByVal fecha As Date, Optional ByVal concepto As String = "", Optional ByVal idtipo_tarifa As Integer = Nothing, Optional ByVal idsubtipo_tarifa As Integer = Nothing, Optional ByVal nroCampania As Integer = 1, Optional ByVal user As String = "") As clsDeudaPredio
    '    Dim dtl As New clsDeudaPredio(Me._idJunta, Me._idComision, Me._idpredio, Me._anio, monto, tipo_deuda, fecha, concepto, idtipo_tarifa, idsubtipo_tarifa, nroCampania)
    '    dtl.SysUsuario = user
    '    dtl.Insert()
    '    Return dtl
    'End Function
    'Public Function InsertDetallesDeudaOpenConnection(ByRef c As ACCESO.Conexion, ByVal monto As Double, ByVal tipo_deuda As Integer, ByVal fecha As Date, Optional ByVal concepto As String = "", Optional ByVal idtipo_tarifa As Integer = Nothing, Optional ByVal idsubtipo_tarifa As Integer = Nothing, Optional ByVal nroCampania As Integer = 1, Optional ByVal user As String = "") As clsDeudaPredio
    '    Dim dtl As New clsDeudaPredio(Me._idJunta, Me._idComision, Me._idpredio, Me._anio, monto, tipo_deuda, fecha, concepto, idtipo_tarifa, idsubtipo_tarifa, nroCampania)
    '    dtl.SysUsuario = user
    '    dtl.InsertOpenConnection(c)
    '    Return dtl
    'End Function

    Public Sub RemoveDeudasOpenConnection(ByRef c As ACCESO.Conexion, Optional ByVal condicion As String = "")
        'si es deuda extraordinaria
        'c.Query("delete from tarDeudaExtraordinaria where iAnioTarifa='" & Me._anio & "' and vIdJuntaUsuario='" & Me._idJunta & "' and iIdComisionRegante='" & Me._idComision & "' and iIdPredio='" & Me._idpredio & "' " & condicion)

        c.Query("delete from tarDetalleDeudaPredio where iAnioTarifa='" & Me._anio & "' and vIdJuntaUsuario='" & Me._idJunta & "' and iIdComisionRegante='" & Me._idComision & "' and iIdPredio='" & Me._idpredio & "' " & condicion)
        c.Query("UPDATE tarDeudaPredio set fMontoTotal=(select sum(ddp.fMonto) from tarDetalleDeudaPredio ddp where ddp.iAnioTarifa='" & Me._anio & "' and ddp.vIdJuntaUsuario='" & Me._idJunta & "' and ddp.iIdComisionRegante='" & Me._idComision & "' and ddp.iIdPredio='" & Me._idpredio & "' ) where iAnioTarifa='" & Me._anio & "' and vIdJuntaUsuario='" & Me._idJunta & "' and iIdComisionRegante='" & Me._idComision & "' and iIdPredio='" & Me._idpredio & "' ")
        If (c.msgError <> "") Then
            MsgBox(c.msgError)
        End If
    End Sub
    Public Sub RecalcularMontoDeudaOpenConnection(ByRef c As ACCESO.Conexion)
        c.Query("UPDATE tarDeudaPredio set fMontoTotal=(select sum(ddp.fMonto) from tarDetalleDeudaPredio ddp where ddp.iAnioTarifa='" & Me._anio & "' and ddp.vIdJuntaUsuario='" & Me._idJunta & "' and ddp.iIdComisionRegante='" & Me._idComision & "' and ddp.iIdPredio='" & Me._idpredio & "' ) where iAnioTarifa='" & Me._anio & "' and vIdJuntaUsuario='" & Me._idJunta & "' and iIdComisionRegante='" & Me._idComision & "' and iIdPredio='" & Me._idpredio & "' ")
        If (c.msgError <> "") Then
            MsgBox(c.msgError)
        End If
    End Sub
    Public Shared Function ListCountDeudasporUsuario(Optional ByVal condicion As String = "") As Integer
        Dim c As New ACCESO.Conexion
        Dim dt As New DataTable
        If (c.Connect) Then
            dt = c.Query("select vIdJuntaUsuario,iIdUsuario,unombrec,sum(fsaldo) as 'deuda' from view_DetalleDeudaPredios " & condicion & " group by vIdJuntaUsuario,iIdUsuario,unombrec")
            If (c.msgError <> "") Then
                MsgBox(c.msgError)
            End If
            c.Close()
        End If
        Return dt.Rows.Count
    End Function
    Public Shared Function ListDeudasporUsuario(Optional ByVal condicion As String = "") As DataTable
        Dim c As New ACCESO.Conexion
        Dim dt As New DataTable
        If (c.Connect) Then
            condicion = IIf(condicion <> "", String.Format("{0} and cCongelado<>1 ", condicion), " where cCongelado<>1")
            dt = c.Query("select vIdJuntaUsuario,iIdUsuario,unombrec,'-',sum(fsaldo) as 'deuda',sum(fInteres),sum(fsaldo+fInteres)  from view_DetalleDeudaPredios " & condicion & " group by vIdJuntaUsuario,iIdUsuario,unombrec")
            If (c.msgError <> "") Then
                MsgBox(c.msgError)
            End If
            c.Close()
        End If
        Return dt
    End Function
    Public Shared Function ListDeudasporPredio(Optional ByVal condicion As String = "") As DataTable
        Dim c As New ACCESO.Conexion
        Dim dt As New DataTable
        If (c.Connect) Then
            condicion = IIf(condicion <> "", String.Format("{0} and cCongelado<>1 ", condicion), " where cCongelado<>1")
            dt = c.Query("select vIdJuntaUsuario,iIdComisionRegante,iIdPredio,predio,vUC,sum(fsaldo) as 'deuda',sum(fInteres),sum(fsaldo+fInteres),iIdUsuario,unombrec from view_DetalleDeudaPredios " & condicion & " group by vIdJuntaUsuario,iIdComisionRegante,iIdPredio,predio,iIdUsuario,unombrec,vUC")
            If (c.msgError <> "") Then
                MsgBox(c.msgError)
            End If
            c.Close()
        End If
        Return dt
    End Function
    Public Shared Function ListCountDeudasporPredio(Optional ByVal condicion As String = "") As Integer
        Dim c As New ACCESO.Conexion
        Dim dt As New DataTable
        If (c.Connect) Then
            dt = c.Query("select vIdJuntaUsuario,iIdComisionRegante,iIdPredio,predio,sum(fsaldo) as 'deuda' from view_DetalleDeudaPredios where fSaldo>0 " & condicion & " group by vIdJuntaUsuario,iIdComisionRegante,iIdPredio,predio")
            If (c.msgError <> "") Then
                MsgBox(c.msgError)
            End If
            c.Close()
        End If
        Return dt.Rows.Count
    End Function
    Public Shared Sub listTreeDeudas(ByRef tv As DevComponents.AdvTree.AdvTree, ByVal tipo As Integer, ByRef bgw As System.ComponentModel.BackgroundWorker, Optional ByVal condicion As String = "")
        Dim n1 As New DevComponents.AdvTree.Node
        Dim n2 As New DevComponents.AdvTree.Node
        Dim cdt1_1 As DevComponents.AdvTree.Cell 'predio-usuario
        Dim cdt1_2 As DevComponents.AdvTree.Cell 'uc
        Dim cdt1_3 As DevComponents.AdvTree.Cell 'saldo
        Dim cdt1_4 As DevComponents.AdvTree.Cell 'interes
        Dim cdt1_5 As DevComponents.AdvTree.Cell 'total
        Dim cdt1_6 As DevComponents.AdvTree.Cell 'concepto
        Dim cdt1_7 As DevComponents.AdvTree.Cell 'nombre
        Dim cdt1_8 As DevComponents.AdvTree.Cell 'idusuario-idpredio
        Dim cdt1_9 As DevComponents.AdvTree.Cell 'mes
        Dim cdt1_10 As DevComponents.AdvTree.Cell 'año

        Dim cdt2_1 As DevComponents.AdvTree.Cell 'nombre
        Dim cdt2_2 As DevComponents.AdvTree.Cell '
        Dim cdt2_3 As DevComponents.AdvTree.Cell '
        Dim cdt2_4 As DevComponents.AdvTree.Cell 'idusuario
        Dim cdt2_5 As DevComponents.AdvTree.Cell 'idusuario
        Dim cdt2_6 As DevComponents.AdvTree.Cell 'idusuario
        Dim cdt2_7 As DevComponents.AdvTree.Cell 'idusuario
        Dim cdt2_8 As DevComponents.AdvTree.Cell 'idusuario-idpredio
        Dim cdt2_9 As DevComponents.AdvTree.Cell 'mes
        Dim cdt2_10 As DevComponents.AdvTree.Cell 'año

        Dim dt1 As New DataTable
        Dim dt2 As New DataTable
        Dim c As New ACCESO.Conexion
        Select Case tipo
            Case 1
                dt1 = clsDeudaPredio.ListDeudasporUsuario(condicion)
                tv.Columns(0).Text = "Usuario"
                tv.Columns(1).Text = "Predio"
            Case 2
                dt1 = clsDeudaPredio.ListDeudasporPredio(condicion)
                tv.Columns(0).Text = "Predio"
                tv.Columns(1).Text = "Usuario"
        End Select
        tv.Columns(7).Visible = False
        Dim cont As Integer = 0
        If (c.Connect) Then
            For Each midatarow As DataRow In dt1.Rows
                n1 = New DevComponents.AdvTree.Node
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

                Select Case tipo
                    Case 1
                        n1.Cells(0).Text = midatarow(2) 'usuario-predio
                        n1.Cells(1).Text = "" 'predio-usuario
                        n1.Cells(2).Text = midatarow(3) 'uc
                        n1.Cells(3).Text = midatarow(4) 'saldo
                        n1.Cells(4).Text = midatarow(5) 'ínteres
                        n1.Cells(5).Text = midatarow(6) 'total
                        n1.Cells(6).Text = "" 'concepto
                        n1.Cells(7).Text = midatarow(1)
                        n1.ImageIndex = 0
                        n1.Tag = "U-" & midatarow(1)
                        dt2 = c.Query("SET LANGUAGE Spanish;select convert(varchar,dFecha,103),predio,vUC,fsaldo,fInteres,(fsaldo+fInteres),tipo_deuda,datename(month,dFecha) as mes,year(dFecha) as anio from view_DetalleDeudaPredios where cCongelado<>1 and vIdJuntaUsuario='" & midatarow(0) & "' and iIdUsuario='" & midatarow(1) & "' and fSaldo>0")
                    Case 2
                        n1.Cells(0).Text = midatarow(3) 'predio
                        n1.Cells(1).Text = midatarow(9) 'usuario
                        n1.Cells(2).Text = midatarow(4) 'uc
                        n1.Cells(3).Text = midatarow(5) 'saldo
                        n1.Cells(4).Text = midatarow(6) 'interes
                        n1.Cells(5).Text = midatarow(7) 'total
                        n1.Cells(6).Text = "" 'concepto
                        n1.Cells(7).Text = midatarow(2) 'concepto

                        n1.ImageIndex = 2
                        n1.Tag = "P-" & midatarow(5)
                        dt2 = c.Query("SET LANGUAGE Spanish;select convert(varchar,dFecha,103),unombrec,'" & midatarow(4) & "',fsaldo,fInteres,(fsaldo+fInteres),tipo_deuda,datename(month,dFecha) as mes,year(dFecha) as anio from view_DetalleDeudaPredios where cCongelado<>1 and vIdJuntaUsuario='" & midatarow(0) & "' and iIdComisionRegante='" & midatarow(1) & "' and iIdPredio='" & midatarow(2) & "' and fSaldo>0")
                End Select
                For Each midatarow2 As DataRow In dt2.Rows
                    n2 = New DevComponents.AdvTree.Node
                    n2.Style = tv.Styles(1)
                    n2.ImageIndex = 1
                    cdt2_1 = New DevComponents.AdvTree.Cell
                    cdt2_2 = New DevComponents.AdvTree.Cell
                    cdt2_3 = New DevComponents.AdvTree.Cell
                    cdt2_4 = New DevComponents.AdvTree.Cell
                    cdt2_5 = New DevComponents.AdvTree.Cell
                    cdt2_6 = New DevComponents.AdvTree.Cell
                    cdt2_7 = New DevComponents.AdvTree.Cell
                    cdt2_8 = New DevComponents.AdvTree.Cell
                    cdt2_9 = New DevComponents.AdvTree.Cell
                    cdt2_10 = New DevComponents.AdvTree.Cell


                    n2.Cells.Add(cdt2_1)
                    n2.Cells.Add(cdt2_2)
                    n2.Cells.Add(cdt2_3)
                    n2.Cells.Add(cdt2_4)
                    n2.Cells.Add(cdt2_5)
                    n2.Cells.Add(cdt2_6)
                    n2.Cells.Add(cdt2_7)
                    n2.Cells.Add(cdt2_8)
                    n2.Cells.Add(cdt2_9)
                    n2.Cells.Add(cdt2_10)

                    Select Case tipo
                        Case 1
                            n2.Cells(7).Text = midatarow(1).ToString
                            n2.Tag = "D-" & midatarow(1).ToString
                        Case 2
                            n2.Cells(7).Text = midatarow(5).ToString
                            n2.Tag = "D-" & midatarow(5).ToString
                    End Select

                    n2.Cells(0).Text = midatarow2(0).ToString
                    n2.Cells(1).Text = midatarow2(1).ToString
                    n2.Cells(2).Text = midatarow2(2).ToString
                    n2.Cells(3).Text = midatarow2(3).ToString
                    n2.Cells(4).Text = midatarow2(4).ToString
                    n2.Cells(5).Text = midatarow2(5).ToString
                    n2.Cells(6).Text = midatarow2(6).ToString
                    n2.Cells(8).Text = midatarow2(7).ToString
                    n2.Cells(9).Text = midatarow2(8).ToString
                    n1.Nodes.Add(n2)
                Next
                tv.Nodes.Add(n1)
                cont += 1
                bgw.ReportProgress(cont)
                If (bgw.CancellationPending) Then
                    Exit Sub
                End If
            Next
            c.Close()
        End If
    End Sub

End Class
