Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Data.OleDb
Imports ACCESO
Imports LOGICA
Public Class clsPrediosServicios
    Private _vIdJas As String
    Private _idpredio As Integer
    Private _idTipotarifa As Integer
    Private _dFechaRegistro As Date
    Private _vReferencia As String
    Private _vObservaciones As String
    Private _cUsuario As String
    Private _cEstado As String
    Public Property vIdJas()
        Get
            Return Me._vIdJas
        End Get
        Set(ByVal value)
            Me._vIdJas = value
            'Me.Comision.Junta.id = value
        End Set
    End Property
    Public Property idpredio()
        Get
            Return Me._idpredio
        End Get
        Set(ByVal value)
            Me._idpredio = value
        End Set
    End Property
    Public Property idTipoTarifa()
        Get
            Return Me._idTipotarifa
        End Get
        Set(ByVal value)
            Me._idTipotarifa = value
        End Set
    End Property
    Public Property Fecha()
        Get
            Return Me._dFechaRegistro
        End Get
        Set(ByVal value)
            Me._dFechaRegistro = value
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

    Public Shared Function List(Optional ByVal condicion As String = "", Optional ByVal estado As String = "", Optional ByVal sector As String = "", Optional ByVal calle As String = "") As DataTable
        Dim dt As New DataTable
        Dim c As New ACCESO.Conexion
        If (c.Connect) Then
            Dim strQuery As String = "SELECT * FROM view_PrediosServicio "
            dt = c.Query(strQuery & condicion)
            c.Close()
        End If
        Return dt
    End Function

    Public Shared Function ListServiciosUnicos(Optional ByVal condicion As String = "", Optional ByVal estado As String = "", Optional ByVal sector As String = "", Optional ByVal calle As String = "") As DataTable
        Dim dt As New DataTable
        Dim c As New ACCESO.Conexion
        If (c.Connect) Then
            Dim strQuery As String = "SELECT * FROM view_PrediosServiciosUnicos "
            'Dim strQuery As String = "SELECT * FROM view_PrediosServiciosVolumen "
            dt = c.Query(strQuery & condicion)
            c.Close()
        End If
        Return dt
    End Function

    Public Shared Sub QuitarServicio(ByVal id, ByVal idservicio)
        Dim cmd As New SqlCommand()
        Dim c As New ACCESO.Conexion

        If (c.Connect) Then
            cmd.CommandText = ("update padPredioServicio set cEstado=0 where idPredio=" & id & " and iIdTipoTarifa= " & idservicio & "")

            c.Update(cmd)
            c.Close()
            If (c.msgError.CompareTo("") <> 0) Then
                MsgBox(c.msgError)
            End If
        End If
    End Sub
    Public Shared Sub ActivarServicio(ByVal id, ByVal idservicio)
        Dim cmd As New SqlCommand()
        Dim c As New ACCESO.Conexion

        If (c.Connect) Then
            cmd.CommandText = ("update padPredioServicio set cEstado=1 where idPredio=" & id & " and iIdTipoTarifa= " & idservicio & "")

            c.Update(cmd)
            c.Close()
            If (c.msgError.CompareTo("") <> 0) Then
                MsgBox(c.msgError)
            End If
        End If
    End Sub
End Class
