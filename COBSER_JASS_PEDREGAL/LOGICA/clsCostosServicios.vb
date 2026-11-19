Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports ACCESO
Public Class clsCostosServicios
    Private _Anio As String
    Private _idJunta As String
    Private _idTipotarifa As Integer
    'Private _vNombre As String
    Private _Valort As Single
    Private _Monto As Single
    Public Property Anio()
        Get
            Return Me._Anio
        End Get
        Set(ByVal value)
            Me._Anio = value
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
    Public Property idTipotarifa()
        Get
            Return Me._idTipotarifa
        End Get
        Set(ByVal value)
            Me._idTipotarifa = value
        End Set
    End Property
    Public Property Valort()
        Get
            Return Me._Valort
        End Get
        Set(ByVal value)
            Me._Valort = value
        End Set
    End Property
    Public Property Monto()
        Get
            Return Me._Monto
        End Get
        Set(ByVal value)
            Me._Monto = value
        End Set
    End Property
    Sub New(ByVal anio As String, ByVal junta As String, ByVal tipotarifa As Integer, ByVal Monto As Single, ByVal valort As Single)
        Me._Anio = anio
        Me._idJunta = junta
        Me._idTipotarifa = tipotarifa
        Me._Monto = Monto
        Me._Valort = valort
        'Me._cEstado = "1"
        'Me._idCP = idcp

    End Sub
    Public Function Insert() As Boolean
        Dim cmd As New SqlCommand()
        Dim c As New ACCESO.Conexion
        'Me._idCalle = Me.NewId
        If (c.Connect) Then

            If (c.msgError = "") Then

                cmd.CommandText = "INSERT INTO tarCostoTarifa ( iAnioTarifa, vIdJas, iIdTipoTarifa, fValorTarifa, fMonto)  VALUES (@ANIO, @IDJAS, @TIPOTARIFA, @VALORT,@MONTO)"
                cmd.Parameters.AddWithValue("@ANIO", Me._Anio)
                cmd.Parameters.AddWithValue("@IDJAS", Me._idJunta)
                cmd.Parameters.AddWithValue("@TIPOTARIFA", Me._idTipotarifa)
                cmd.Parameters.AddWithValue("@VALORT", Me._Valort)
                cmd.Parameters.AddWithValue("@MONTO", Me._Monto)
              
                If (c.Update(cmd) = False) Then
                    MsgBox(c.msgError)
                Else
                    MsgBox("Costo Servicio Registrado correctamente", MsgBoxStyle.Information)
                End If
            Else
                MsgBox(c.msgError, MsgBoxStyle.Critical)
            End If


            c.Close()
        End If
    End Function
    Public Function Update() As Boolean
        Dim cmd As New SqlCommand()
        Dim c As New ACCESO.Conexion
        If (c.Connect) Then
            cmd.CommandText = "UPDATE tarCostoTarifa SET iIdTipoTarifa= @TIPOTARIFA, fValorTarifa=@VALORT, fMonto=@MONTO WHERE iAnioTarifa=" & Anio & " AND iIdTipoTarifa=" & idTipotarifa & " "
            cmd.Parameters.AddWithValue("@ANIO", Me._Anio)
            cmd.Parameters.AddWithValue("@IDJAS", Me._idJunta)
            cmd.Parameters.AddWithValue("@TIPOTARIFA", Me._idTipotarifa)
            cmd.Parameters.AddWithValue("@VALORT", Me._Valort)
            cmd.Parameters.AddWithValue("@MONTO", Me._Monto)
            If (c.Update(cmd) = False) Then
                MsgBox(c.msgError)

            End If
            c.Close()
        End If
    End Function

    Public Shared Function delete(ByVal anio, ByVal idtipotarifa) As Boolean
        Dim c As New ACCESO.Conexion

        If (c.Connect) Then
            If (c.Delete("delete  from tarCostoTarifa  where iAnioTarifa=" & anio & "  and iIdTipoTarifa= " & idtipotarifa & " ")) Then

                'MsgBox("No se puede elminar el registro porque existen datos vinculados al mismo", MsgBoxStyle.Critical)
                'c.Close()
                c.Close()
                Return False
            End If
            c.Close()
        End If
        Return True
    End Function
    Public Shared Function List(Optional ByVal condicion As String = "") As DataTable
        Dim dt As New DataTable
        Dim c As New ACCESO.Conexion
        If (c.Connect) Then
            dt = c.Query("SELECT iAnioTarifa, vIdJas, iIdTipoTarifa, fValorTarifa, fMonto FROM  tarCostoTarifa  " & condicion)
            c.Close()
        End If
        Return dt
    End Function
End Class
