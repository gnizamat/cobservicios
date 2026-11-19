Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Data.OleDb
Imports ACCESO
Imports LOGICA

Public Class clsFacturacionDetalle
    Private _idFacturacion As Integer
    Private _vIdJas As String
    Private _iAnioTarifa As Integer
    Private _idMes As Integer
    Private _idPredio As Integer
    Private _idDetalleDeuda As Integer
    Private _idTipoTarifa As Integer

    Public Property Id()
        Get
            Return Me._idFacturacion
        End Get
        Set(ByVal value)
            Me._idFacturacion = value
        End Set
    End Property

    Public Property Jas()
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

    Public Property TipoTarifa()
        Get
            Return Me._idTipoTarifa
        End Get
        Set(ByVal value)
            Me._idTipoTarifa = value
        End Set
    End Property

    Public Function Insert(ByRef c As ACCESO.Conexion) As Boolean
        Dim cmd As New SqlCommand()
        If (c.Connect) Then
            cmd.CommandText = "INSERT INTO tarFacturacionDetalle(idFacturacion, vIdJas, iAnioTarifa, idMes, idPredio, idDetalleDeuda, idTipoTarifa)" _
            & " VALUES(@ID,@IDJU,@ANIO,@MES,@PREDIO,@DET,@TIPO)"
            cmd.Parameters.AddWithValue("@ID", Me._idFacturacion)
            cmd.Parameters.AddWithValue("@IDJU", Me._vIdJas)
            cmd.Parameters.AddWithValue("@ANIO", Me._iAnioTarifa)
            cmd.Parameters.AddWithValue("@MES", Me._idMes)
            cmd.Parameters.AddWithValue("@PRED", Me._idPredio)
            cmd.Parameters.AddWithValue("@DET", Me._idDetalleDeuda)
            cmd.Parameters.AddWithValue("@TIPO", Me._idTipoTarifa)


            If (c.Insert(cmd) = False) Then
                MsgBox(c.msgError)
            End If
            c.Close()
        End If
    End Function


End Class
