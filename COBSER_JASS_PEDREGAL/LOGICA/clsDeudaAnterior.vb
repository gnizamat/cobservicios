
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Data.OleDb
Imports ACCESO
Imports LOGICA
Public Class clsDeudaAnterior
    'Inherits clsDetalleDeudaPredio

    Private _dtl As clsDetalleDeudaPredio

    Private _idJunta As String
    Private _idmes As Integer
    Private _idPredio As Integer
    Private _anio As Integer
    Private _mes As String
    Private _id As Integer
  
    Private _volumen As Decimal
    Private _interesInicial As Decimal
    Private _fechaRegistro As DateTime
    Public Property FechaRegistro() As DateTime
        Get
            Return Me._fechaRegistro
        End Get
        Set(ByVal value As DateTime)
            Me._fechaRegistro = value
        End Set
    End Property
    Public Property InteresInicial() As Decimal
        Get
            Return Me._interesInicial
        End Get
        Set(ByVal value As Decimal)
            Me._interesInicial = value
        End Set
    End Property
    Public Property Volumen() As Decimal
        Get
            Return Me._volumen
        End Get
        Set(ByVal value As Decimal)
            Me._volumen = value
        End Set
    End Property
    Public Property id()
        Get
            Return Me._id
        End Get
        Set(ByVal value)
            Me._id = value
        End Set
    End Property
    Public Property idPredio()
        Get
            Return Me._idPredio
        End Get
        Set(ByVal value)
            Me._idPredio = value
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
    Public Property idmes()
        Get
            Return Me._idmes
        End Get
        Set(ByVal value)
            Me._idmes = value
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
    Sub New(ByVal junta As String, ByVal idmes As Integer, ByVal idpredio As Integer, ByVal anio As Integer, ByVal fecha As Date, ByVal volumen As Single, ByVal interes As Single)
        ''(idjas,dgDeudas.Rows(i).Cells(8).Value, idpredio,dgDeudas.Rows(i).Cells(0).Value,   txtFecha.Text, dgDeudas.Rows(i).Cells(7).Value, 1, dgDeudas.Rows(i).Cells(3).Value, dgDeudas.Rows(i).Cells(5).Value)
        Me._idJunta = junta
        Me._idmes = idmes
        Me._idPredio = idpredio
        Me._anio = anio
        Me._fechaRegistro = fecha
        Me._volumen = Math.Round(volumen, 2)
        Me._interesInicial = Math.Round(interes, 2)
        'Me._saldo = Math.Round(monto, 2)
        'Me._idTipoDeuda = tipo_deuda
        'Me._idTipoTarifa = idtipo_tarifa
        'Me._concepto = concepto_deuda

        'Me._idTipoDeuda = idTipoDeuda
        'Me._idSubtipoTarifa = idsubtipo_tarifa
        'Me._SysUsuario = "ALCIRA"
        'Me._congelado = "0"
    End Sub


    Public Sub Insert()
        Dim cmd As New SqlCommand()
        Dim c As New ACCESO.Conexion
        If (c.Connect) Then
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "sp_tarDeudaAnterior_insert"
            cmd.Parameters.AddWithValue("@IDJAS", Me._idJunta)
            cmd.Parameters.AddWithValue("@ANIO", Me._anio)
            cmd.Parameters.AddWithValue("@IDMES", Me._idmes)
            cmd.Parameters.AddWithValue("@IDPREDIO", Me._idPredio)
            cmd.Parameters.AddWithValue("@IDDETALLEDEUDA", Me._dtl.id)
            cmd.Parameters.AddWithValue("@VOLUMEN", Me._volumen)
            cmd.Parameters.AddWithValue("@INTERES", Me._interesInicial)
            cmd.Parameters.AddWithValue("@FECHA", Me._fechaRegistro)
            'cmd.Parameters.AddWithValue("@IDCAMPANIA", Me._idCampania)
            'cmd.Parameters.AddWithValue("@NROCAMPANIA", Me._nroCampania)

            If (c.Execute(cmd) = False) Then
                MsgBox(c.msgError)
            End If
            c.Close()
        End If
    End Sub
    Public Sub InsertOpenConnection(ByRef c As ACCESO.Conexion)
        Dim cmd As New SqlCommand()

        If (c.Connect) Then
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "sp_tarDeudaAnterior_insert"
            cmd.Parameters.AddWithValue("@ANIO", Me._dtl.anio)
            cmd.Parameters.AddWithValue("@IDJUNTA", Me._dtl.idJunta)
            'cmd.Parameters.AddWithValue("@IDCOMISION", Me._dtl.idComision)
            cmd.Parameters.AddWithValue("@IDPREDIO", Me._dtl.idPredio)
            cmd.Parameters.AddWithValue("@IDDETALLEDEUDA", Me._dtl.id)
            'cmd.Parameters.AddWithValue("@IDCAMPANIA", Me._idCampania)
            'cmd.Parameters.AddWithValue("@NROCAMPANIA", Me._nroCampania)

            If (c.Execute(cmd) = False) Then
                MsgBox(c.msgError)
            End If

        End If
    End Sub
End Class

