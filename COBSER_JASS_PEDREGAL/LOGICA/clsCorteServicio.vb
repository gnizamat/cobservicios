Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports ACCESO
Public Class clsCorteServicio
    Private _vIdJas As String
    Private _idPredio As Integer
    Private _idTipoTarifa As Integer
    Private _dFechaCorte As Date
    Private _dFecha As Date
    Private _vMotivo As String
    Private _vObervacion As String
    Private _cUsuario As String
    Private _cEstado As String

    Public Property IdJAS()
        Get
            Return Me._vIdJas
        End Get
        Set(ByVal value)
            Me._vIdJas = value
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

    Public Property TipoTarifa()
        Get
            Return Me._idTipoTarifa
        End Get
        Set(ByVal value)
            Me._idTipoTarifa = value
        End Set
    End Property

    Public Property FechaCorte()
        Get
            Return Me._dFechaCorte
        End Get
        Set(ByVal value)
            Me._dFechaCorte = value
        End Set
    End Property
    Public Property FechaRegistro()
        Get
            Return Me._dFecha
        End Get
        Set(ByVal value)
            Me._dFecha = value
        End Set
    End Property
    Public Property Motivo()
        Get
            Return Me._vMotivo
        End Get
        Set(ByVal value)
            Me._vMotivo = value
        End Set
    End Property

    Public Property Obervacion()
        Get
            Return Me._vObervacion
        End Get
        Set(ByVal value)
            Me._vObervacion = value
        End Set
    End Property
    Public Property Usuario()
        Get
            Return Me._cUsuario
        End Get
        Set(ByVal value)
            Me._cUsuario = value
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


    Public Function Insert(ByVal vIdJas As String, ByVal idPredio As Integer, ByVal idtipotarifa As Integer, ByVal FECHAC As Date, ByVal FECHA As Date, ByVal Motivo As String, ByVal descrip As String, ByVal usu As String) As Boolean
        Dim cmd As New SqlCommand()
        Dim c As New ACCESO.Conexion
        If (c.Connect) Then
            cmd.CommandText = "INSERT INTO padCortesPredios (vIdJas,idPredio, iIdTipoTarifa,dFechaCorte, dFechaRegistro, vMotivo,vObservacion, cUsuario, cEstadoPredio)" _
                            & " VALUES(@IDJAS, @IDPREDIO,@TIPOTARIFA,@FECHACORTE,@FECHAR,@MOTIVO,@OBSERVACION,@USUARIO,@ESTADO)"
            cmd.Parameters.AddWithValue("@IDJAS", vIdJas)
            cmd.Parameters.AddWithValue("@IDPREDIO", idPredio)
            cmd.Parameters.AddWithValue("@TIPOTARIFA", idtipotarifa)
            cmd.Parameters.AddWithValue("@FECHACORTE", FECHAC)
            cmd.Parameters.AddWithValue("@FECHAR", FECHA)
            cmd.Parameters.AddWithValue("@MOTIVO", Motivo)
            cmd.Parameters.AddWithValue("@OBSERVACION", descrip)
            cmd.Parameters.AddWithValue("@USUARIO", usu)
            cmd.Parameters.AddWithValue("@ESTADO", 1)

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

    Public Shared Function List(ByVal idpredio As Integer) As DataTable
        Dim dt As New DataTable
        Dim c As New ACCESO.Conexion
        Dim SQLTEXT As String
        If (c.Connect) Then
            SQLTEXT = "SELECT vIdjas, idPredio, iIdTipoTarifa, dFechaCorte, dFechaRegistro, CASE padCortesPredios.vMotivo WHEN '0' THEN 'SOLICITUD' WHEN '1' THEN 'MOROSIDAD' WHEN '2' THEN 'OTROS' END AS MOTIVO, vObservacion, cUsuario, CASE padCortesPredios.cEstadoPredio WHEN '0' THEN 'INACTIVO'  WHEN '1' THEN 'ACTIVO'  END AS E_CORTE  " _
            & " FROM     padCortesPredios " _
             & " WHERE padCortesPredios.cEstadoPredio='1' AND padCortesPredios.idpredio='" & idpredio & "'"
            dt = c.Query(SQLTEXT)
            c.Close()
        End If
        Return dt
        'Return dt
    End Function
    Public Shared Function ListInactivos(ByVal idpredio As Integer) As DataTable
        Dim dt As New DataTable
        Dim c As New ACCESO.Conexion
        Dim SQLTEXT As String
        If (c.Connect) Then
            SQLTEXT = "SELECT vIdjas, idPredio, iIdTipoTarifa, dFechaCorte, dFechaRegistro, CASE padCortesPredios.vMotivo WHEN '0' THEN 'SOLICITUD' WHEN '1' THEN 'MOROSIDAD' WHEN '2' THEN 'OTROS' END AS MOTIVO, vObservacion, cUsuario, CASE padCortesPredios.cEstadoPredio WHEN '0' THEN 'INACTIVO'  WHEN '1' THEN 'ACTIVO'  END AS E_CORTE  " _
            & " FROM     padCortesPredios " _
             & " WHERE padCortesPredios.cEstadoPredio='0' AND padCortesPredios.idpredio='" & idpredio & "'"
            dt = c.Query(SQLTEXT)
            c.Close()
        End If
        Return dt
        'Return dt
    End Function

    Public Shared Function ListTodos(ByVal idpredio As Integer) As DataTable
        Dim dt As New DataTable
        Dim c As New ACCESO.Conexion
        Dim SQLTEXT As String
        If (c.Connect) Then
            SQLTEXT = "SELECT vIdjas, idPredio, iIdTipoTarifa, dFechaCorte, dFechaRegistro, CASE padCortesPredios.vMotivo WHEN '0' THEN 'SOLICITUD' WHEN '1' THEN 'MOROSIDAD' WHEN '2' THEN 'OTROS' END AS MOTIVO, vObservacion, cUsuario, CASE padCortesPredios.cEstadoPredio WHEN '0' THEN 'INACTIVO'  WHEN '1' THEN 'ACTIVO'  END AS E_CORTE  " _
            & " FROM     padCortesPredios " _
             & " WHERE  padCortesPredios.idpredio='" & idpredio & "'"
            dt = c.Query(SQLTEXT)
            c.Close()
        End If
        Return dt
        'Return dt
    End Function


    Public Shared Function delete(ByVal idpredio, ByVal idtipotarifa) As Boolean
        Dim cmd As New SqlCommand()
        Dim c As New ACCESO.Conexion


        If (c.Connect) Then
            If (c.Delete("delete  from padCortesPredios  where idpredio=" & idpredio & "  and iIdTipoTarifa= " & idtipotarifa & "  ")) Then

                If (c.Update(cmd) = False) Then
                    MsgBox(c.msgError)
                End If
                c.Close()
            End If
            Return True
        End If
    End Function

    Public Function update_corte(ByVal idpredio, ByVal idservicio) As Boolean
        Dim cmd As New SqlCommand()
        Dim c As New ACCESO.Conexion

        If (c.Connect) Then
            cmd.CommandText = " UPDATE padCortesPredios SET cEstadoPredio=0 WHERE idpredio=" & idpredio & "  and iIdTipoTarifa= " & idservicio & " "
            If (c.Update(cmd) = False) Then
                MsgBox(c.msgError)
            End If
            c.Close()
        End If
        Return True
    End Function

    Public Function activa_corte(ByVal idpredio, ByVal idservicio) As Boolean
        Dim cmd As New SqlCommand()
        Dim c As New ACCESO.Conexion

        If (c.Connect) Then
            cmd.CommandText = " UPDATE padCortesPredios SET cEstadoPredio=1 WHERE idpredio=" & idpredio & "  and iIdTipoTarifa= " & idservicio & " "
            If (c.Update(cmd) = False) Then
                MsgBox(c.msgError)
            End If
            c.Close()
        End If
        Return True
    End Function
End Class
