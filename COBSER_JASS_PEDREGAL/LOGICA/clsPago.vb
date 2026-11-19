Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Data.OleDb
Imports ACCESO
Imports LOGICA
Imports System.IO

Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared



Public Class clsPago
    'Public rpt As New CrystalDecisions.CrystalReports.Engine.ReportDocument

    
    'Dim ds As New dsRecibos

    Private _vIdJas As Integer
    Private _iIdCaja As Integer
    Private _idPredio As Integer
    Private _dFecha As Date
    Private _iIdPago As Integer
    Private _vNroDocumento As String
    Private _idTipoPago As Integer
    'Private _iIdTipoDeuda  As Double
    Private _fMonto As Double
    Private _fInteres As Double
    Private _fRedondeo As Double
    Private _fMontoTotal As Double
    Private _cAnulado As String
    Private _vObservaciones As String
    Private _vUsuario As String
    Private _vReferencia As String


    Public Property IdJAS()
        Get
            Return Me._vIdJas
        End Get
        Set(ByVal value)
            Me._vIdJas = value
        End Set
    End Property
    Public Property IdCaja()
        Get
            Return Me._iIdCaja
        End Get
        Set(ByVal value)
            Me._iIdCaja = value
        End Set
    End Property ' como se va a manejar falta tablas
    Public Property IdPredio()
        Get
            Return Me._idPredio
        End Get
        Set(ByVal value)
            Me._idPredio = value
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
    Public Property IdPago()
        Get
            Return Me._iIdPago
        End Get
        Set(ByVal value)
            Me._iIdPago = value
        End Set
    End Property
    Public Property NroDocumento()
        Get
            Return Me._vNroDocumento
        End Get
        Set(ByVal value)
            Me._vNroDocumento = value
        End Set
    End Property
    Public Property TipoPago()
        Get
            Return Me._idTipoPago
        End Get
        Set(ByVal value)
            Me._idTipoPago = value
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
    Public Property Interes()
        Get
            Return Me._fInteres
        End Get
        Set(ByVal value)
            Me._fInteres = value
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
    Public Property MontoTotal()
        Get
            Return Me._fMontoTotal
        End Get
        Set(ByVal value)
            Me._fMontoTotal = value
        End Set
    End Property
    Public Property Anulado()
        Get
            Return Me._cAnulado
        End Get
        Set(ByVal value)
            Me._cAnulado = value
        End Set
    End Property
    Public Property Observaciones()
        Get
            Return Me._vObservaciones
        End Get
        Set(ByVal value)
            Me._vObservaciones = value
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
    Public Property Referencia()
        Get
            Return Me._vReferencia
        End Get
        Set(ByVal value)
            Me._vReferencia = value
        End Set
    End Property
    Private Function ultimoRecibo()
        Dim c As New ACCESO.Conexion
        Dim dt As New DataTable
        Dim id As Integer
        If (c.Connect) Then
            dt = c.Query("select isNull(max(vNroDocumento),0)  as Recibo from tarPago ")
            'dt = c.Query("select isNull(max(vNroDocumento),0)  as Recibo from tarPago WHERE dFecha= '" & Year(Me.Fecha) & "' ")
            c.Close()
            id = dt.Rows(0).Item(0)
        End If
        Return id
    End Function

    Private Function NewId()
        Dim c As New ACCESO.Conexion
        Dim dt As New DataTable
        Dim id As Integer
        If (c.Connect) Then
            'dt = c.Query("select isNull(max(iIdPago),0) from tarPago ")
            dt = c.Query("select isNull(max(iIdPago),0) from tarPago WHERE substring(vNroDocumento, 2, 4)= '" & Year(Me.Fecha) & "' ")
            c.Close()
            id = dt.Rows(0).Item(0) + 1
        End If
        Return id
    End Function

    Public Function Insert(ByVal Detalles As String) As Boolean
        Dim cmd As New SqlCommand()
        Dim c As New ACCESO.Conexion
        Dim sql As String

        Me._iIdPago = Me.NewId
        If (c.Connect) Then
            cmd.CommandText = "INSERT INTO tarPago (vIdJas, iIdCaja, idPredio, dFecha, iIdPago, vNroDocumento, idTipoPago, iIdTipoDeuda, fMonto, " _
                            & " fInteres, fMontoTotal, fRedondeo, cAnulado, vObservaciones, vUsuario,vReferencia)" _
                            & " VALUES (@IDJAS, @IDCAJA, @IDPREDIO, @FECHA, @IDPAGO, @NRODOC, @IDTIPOPAGO, @IDTIPODEUDA, @MONTO, " _
                            & " @INTERES, @TOTAL, @REDONDEO, @ANULADO, @OBS, @USER,@REF)"
            cmd.Parameters.AddWithValue("@IDJAS", Me._vIdJas)
            cmd.Parameters.AddWithValue("@IDCAJA", Me._iIdCaja)
            cmd.Parameters.AddWithValue("@IDPREDIO", Me._idPredio)
            cmd.Parameters.AddWithValue("@FECHA", Format(Me._dFecha, "dd/MM/yyyy")) ' Format(Me._dFecha, "ddMMMyyyy")
            cmd.Parameters.AddWithValue("@IDPAGO", Me._iIdPago)
            cmd.Parameters.AddWithValue("@NRODOC", Me._vNroDocumento & "-" & Right("000000000" & Me._iIdPago, 8))
            cmd.Parameters.AddWithValue("@IDTIPOPAGO", Me._idTipoPago)
            cmd.Parameters.AddWithValue("@IDTIPODEUDA", 0)
            cmd.Parameters.AddWithValue("@MONTO", Me._fMonto)
            cmd.Parameters.AddWithValue("@INTERES", Me._fInteres)
            cmd.Parameters.AddWithValue("@TOTAL", Me._fMontoTotal)
            cmd.Parameters.AddWithValue("@REDONDEO", Me._fRedondeo)
            cmd.Parameters.AddWithValue("@ANULADO", Me._cAnulado)
            cmd.Parameters.AddWithValue("@OBS", Me._vObservaciones)
            cmd.Parameters.AddWithValue("@USER", Me._vUsuario)
            cmd.Parameters.AddWithValue("@REF", Me._vReferencia)
            c.IniTransaction()
            If (c.Insert(cmd) = True) Then
                'MsgBox(c.msgError)
                'Endif
                ' INSERTAMOS LOS DETALLE
                sql = "INSERT INTO tarPagoFacturacion " _
                & " SELECT '" & Me._vIdJas & "' as vIdJas," & Me._iIdCaja & " as iIdCaja," & Me._idPredio & " as idPredio,'" & Format(Me._dFecha, "dd/MM/yyyy") & "' as dFecha," & Me._iIdPago & " as iIdPago, idFacturacion, iAnioTarifa, idMes, idPredio" _
                & " FROM tarFacturacion WHERE  vNroDocumento IN (" & Detalles & ")"
                c.Query(sql)
                'actualziamos valor de estado en tarfacturacion
                sql = "UPDATE tarFacturacion SET cEstado='1' WHERE  vNroDocumento IN (" & Detalles & ")"
                c.Query(sql)
                ' actualziamos en tardeudapredio el saldo, cpagado y fechapago
                sql = "UPDATE tarDetalleDeudaPredio SET tarDetalleDeudaPredio.fSaldo=0,tarDetalleDeudaPredio.fInteres=0, tarDetalleDeudaPredio.cPagado='1', tarDetalleDeudaPredio.dFechaPago='" & Format(Me._dFecha, "dd/MM/yyyy") & "'" _
                     & " FROM     tarFacturacion INNER JOIN " _
                     & " tarFacturacionDetalle ON tarFacturacion.idFacturacion = tarFacturacionDetalle.idFacturacion AND tarFacturacion.iAnioTarifa = tarFacturacionDetalle.iAnioTarifa AND tarFacturacion.idMes = tarFacturacionDetalle.idMes AND " _
                     & " tarFacturacion.idPredio = tarFacturacionDetalle.idPredio INNER JOIN " _
                     & " tarDetalleDeudaPredio ON tarFacturacionDetalle.vIdJas = tarDetalleDeudaPredio.vIdJas AND tarFacturacionDetalle.iAnioTarifa = tarDetalleDeudaPredio.iAnioTarifa AND tarFacturacionDetalle.idMes = tarDetalleDeudaPredio.idMes AND " _
                     & " tarFacturacionDetalle.idPredio = tarDetalleDeudaPredio.idPredio" _
                     & " WHERE  tarFacturacion.vNroDocumento IN (" & Detalles & ")"
                c.Query(sql)


                If (Not c.myError) Then
                    c.Commit()
                    'MsgBox("Facturación Generada para el mes de " & Idmes & " del año " & Idaño & "  Satisfactoriamente", MsgBoxStyle.Information)
                    Return True
                Else
                    c.RollBack()
                    'MsgBox("Ocurrio un error mientras se generaba la facturación. Se cancelo el proceso de Importación", MsgBoxStyle.Critical)
                    Return False
                End If
            Else
                c.RollBack()
                Return False
            End If
        End If
    End Function
    Public Sub Print(ByVal impresora As String, Optional ByVal preview As Boolean = False, Optional ByVal nroCopias As Integer = 1)

        Select Case Me.NroDocumento
            Case 1
                'PrintRecibo_TarifaAgua(rpt, impresora, preview)

            Case Else
                MsgBox("La deuda se genero pero aun no se ha implementado un formato de impresion para este documento")
        End Select

    End Sub

    Public Shared Function ListPagos(ByVal dfechai As String, ByVal dfechaf As String) As DataTable
        Dim dt As New DataTable
        Dim c As New ACCESO.Conexion
        Dim SQLTEXT As String
        If (c.Connect) Then

            SQLTEXT = " Select * from view_Pagos " _
                       & " WHERE view_Pagos.dFecha >= '" & dfechai & "' AND  view_Pagos.dFecha  <= '" & dfechaf & "' " _
                         & " ORDER BY Recibo "
            dt = c.Query(SQLTEXT)
            c.Close()
        End If
        Return dt
        'Return dt
    End Function

    Public Shared Sub elimina(ByVal nroRecibo As String, ByVal predio As Integer, ByVal idpago As Integer, ByVal dfecha As String, ByVal facturaciones As String)

        Dim cmd As New SqlCommand()
        Dim c As New ACCESO.Conexion
        Dim pado As New clsPago
        Dim fac As New clsFacturacion
        Dim sql As String

        If (c.Connect) Then
            'cmd.CommandText = ("update padPredio set cEstado=0 where idPredio='" & nroRecibo & "'")
            sql = "UPDATE tarPago SET cAnulado='1' WHERE  vNroDocumento = '" & nroRecibo & "'"
            c.Query(sql)
            sql = "delete from  tarPagoFacturacion WHERE  idPredio = " & predio & " and  iIdpago = " & idpago & " and dfecha = '" & dfecha & "'"
            c.Query(sql)
            sql = "UPDATE tarFacturacion SET cEstado='0' WHERE  vNroDocumento IN(" & facturaciones & ")"
            c.Query(sql)
            'sql = "UPDATE tarDetalleDeudaPredio SET tarDetalleDeudaPredio.fSaldo=fMonto, tarDetalleDeudaPredio.cPagado='0',tarDetalleDeudaPredio.dfechapago= 'null' WHERE  idPredio= " & Me._idPredio & " and "
            'c.Query(sql)
            sql = "UPDATE tarDetalleDeudaPredio SET tarDetalleDeudaPredio.fSaldo=fMonto, tarDetalleDeudaPredio.cPagado='0', tarDetalleDeudaPredio.dFechaPago=null" _
                     & " FROM     tarFacturacion INNER JOIN " _
                     & " tarFacturacionDetalle ON tarFacturacion.idFacturacion = tarFacturacionDetalle.idFacturacion AND tarFacturacion.iAnioTarifa = tarFacturacionDetalle.iAnioTarifa AND tarFacturacion.idMes = tarFacturacionDetalle.idMes AND " _
                     & " tarFacturacion.idPredio = tarFacturacionDetalle.idPredio INNER JOIN " _
                     & " tarDetalleDeudaPredio ON tarFacturacionDetalle.vIdJas = tarDetalleDeudaPredio.vIdJas AND tarFacturacionDetalle.iAnioTarifa = tarDetalleDeudaPredio.iAnioTarifa AND tarFacturacionDetalle.idMes = tarDetalleDeudaPredio.idMes AND " _
                     & " tarFacturacionDetalle.idPredio = tarDetalleDeudaPredio.idPredio" _
                     & " WHERE  tarFacturacion.vNroDocumento IN (" & facturaciones & ")"
            c.Query(sql)



            'cmd.CommandText = ("update padUsuarioPredio set cEstado=0 where idPredio='" & nroRecibo & "'")
            'c.Update(cmd)
            c.Close()

            'If (c.msgError.CompareTo("") <> 0) Then
            '    MsgBox(c.msgError)
            'End If
        End If
    End Sub
   
End Class
