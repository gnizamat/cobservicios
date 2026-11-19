Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports ACCESO
Public Class clsMedidor
    Private _idMedidor As Integer
    Private _vIdJas As String
    Private _idMes As Integer
    Private _idPredio As Integer
    Private _Predio As String
    Private _codigo As String
    Private _iIdTipoTarifa As Integer
    Private _dFecha As Date
    Private _cEstado As String
    Public Property idmedidor()
        Get
            Return Me._idMedidor
        End Get
        Set(ByVal value)
            Me._idMedidor = value
        End Set
    End Property
    Public Property IdJAS()
        Get
            Return Me._vIdJas
        End Get
        Set(ByVal value)
            Me._vIdJas = value
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
    Public Property TipoTarifa()
        Get
            Return Me._iIdTipoTarifa
        End Get
        Set(ByVal value)
            Me._iIdTipoTarifa = value
        End Set
    End Property
    Public Property codigo()
        Get
            Return Me._codigo
        End Get
        Set(ByVal value)
            Me._codigo = value
        End Set
    End Property

    Public Property dFecha()
        Get
            Return Me._dFecha
        End Get
        Set(ByVal value)
            Me._dFecha = value
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
    
    Public Shared Sub LoadCombo(ByRef cmb As Windows.Forms.ComboBox, Optional ByVal condicion As String = "")
        Dim c As New ACCESO.Conexion
        If (c.Connect()) Then
            Dim dt = c.Query("SELECT idMedidor, Tipo, Marca, Serie, dFechaCompra FROM Medidor " & condicion & "")
            cmb.DataSource = dt
            cmb.ValueMember = dt.Columns(0).ToString()
            cmb.DisplayMember = dt.Columns(1).ToString()
            cmb.Text = ""
            cmb.SelectedIndex = -1
            c.Close()
        End If
    End Sub
    Public Shared Sub LoadComboActMedidor(ByRef cmb As Windows.Forms.ComboBox, Optional ByVal idpredio As String = "")
        Dim c As New ACCESO.Conexion
        If (c.Connect()) Then
            'Dim dt = c.Query("SELECT idMedidor, Tipo, Marca, Serie, dFechaCompra FROM Medidor " & condicion & "")
            Dim dt = c.Query(" SELECT Medidor.idMedidor, Medidor.Marca, padPredioServicioMedidor.idpredio,  padPredioServicioMedidor.Codigo FROM  padPredioServicioMedidor INNER JOIN Medidor ON padPredioServicioMedidor.idMedidor = Medidor.idMedidor WHERE  padPredioServicioMedidor.idpredio = " & idpredio & " AND padPredioServicioMedidor.cEstado = '1'")

            cmb.DataSource = dt
            cmb.ValueMember = dt.Columns(0).ToString()
            cmb.DisplayMember = dt.Columns(1).ToString()
            cmb.Text = ""
            cmb.SelectedIndex = -1
            c.Close()
        End If
    End Sub

    Private Function NewId()
        Dim c As New ACCESO.Conexion
        Dim dt As New DataTable
        Dim id As Integer
        If (c.Connect) Then
            dt = c.Query("select isNull(max(IdDetalleDeuda),0) from padPredioServicioMedidor where  vIdJas='" & Me._vIdJas & "' and IdPredio='" & Me._idPredio & "'")
            c.Close()
            id = dt.Rows(0).Item(0) + 1
        End If
        Return id
    End Function
    Public Shared Function List(ByVal idpredio As Integer) As DataTable
        Dim dt As New DataTable
        Dim c As New ACCESO.Conexion
        Dim SQLTEXT As String
        If (c.Connect) Then
            'SQLTEXT = " SELECT padPredioServicioMedidor.idpredio, Medidor.Tipo, Medidor.Marca, padPredioServicioMedidor.Codigo, view_PrediosServiciosUnicos.vNroPredio, view_PrediosServiciosUnicos.TipoPredio, view_PrediosServiciosUnicos.TipoServicio, CASE  padPredioServicioMedidor.cEstado WHEN '1' THEN 'Activo'WHEN '0' THEN 'Inactivo' END AS Estado,Medidor.idMedidor " _
            ' & " FROM padPredioServicioMedidor INNER JOIN view_PrediosServiciosUnicos ON padPredioServicioMedidor.idpredio = view_PrediosServiciosUnicos.idpredio AND  " _
            ' & " padPredioServicioMedidor.vIdJas = view_PrediosServiciosUnicos.vIdJas INNER JOIN Medidor ON padPredioServicioMedidor.idMedidor = Medidor.idMedidor " _
            ' & " WHERE padPredioServicioMedidor.idpredio='" & idpredio & "'"

            SQLTEXT = "SELECT padPredioServicioMedidor.idpredio, Medidor.Tipo, Medidor.Marca, padPredioServicioMedidor.Codigo, view_PrediosServiciosUnicos.vNroPredio, view_PrediosServiciosUnicos.TipoPredio, view_PrediosServiciosUnicos.TipoServicio, " _
            & " CASE padPredioServicioMedidor.cEstado WHEN '1' THEN 'Activo' WHEN '0' THEN 'Inactivo' END AS Estado, Medidor.idMedidor " _
            & " FROM  padPredioServicioMedidor INNER JOIN  view_PrediosServiciosUnicos ON padPredioServicioMedidor.idpredio = view_PrediosServiciosUnicos.idPredio AND padPredioServicioMedidor.vIdJas = view_PrediosServiciosUnicos.vIdJas AND  " _
            & " padPredioServicioMedidor.iIdTipoTarifa = view_PrediosServiciosUnicos.iIdTipoTarifa AND padPredioServicioMedidor.idMedidor = view_PrediosServiciosUnicos.idMedidor INNER JOIN  " _
            & "  Medidor ON padPredioServicioMedidor.idMedidor = Medidor.idMedidor WHERE  padPredioServicioMedidor.idpredio = '" & idpredio & "'"
            dt = c.Query(SQLTEXT)
            c.Close()
        End If
        Return dt
        'Return dt
    End Function
    Public Function Insert(ByVal vIdJas As String, ByVal idPredio As Integer, ByVal idtipotarifa As Integer, ByVal idMedidor As Integer, ByVal codigo As String, ByVal FECHA As Date) As Boolean
        Dim cmd As New SqlCommand()
        Dim c As New ACCESO.Conexion

        'Me._idMedidor = Me.NewId
        If (c.Connect) Then
            cmd.CommandText = "INSERT INTO padPredioServicioMedidor (vIdJas,idPredio, iIdTipoTarifa, idMedidor, Codigo, dFecha, cEstado)" _
                            & " VALUES(@IDJAS, @IDPREDIO,@TIPOTARIFA,@IDMEDIDOR,@CODIGO,@FECHA,@ESTADO)"
            cmd.Parameters.AddWithValue("@IDJAS", vIdJas)
            'cmd.Parameters.AddWithValue("@MES", Me._idMes)
            cmd.Parameters.AddWithValue("@IDPREDIO", idPredio)
            cmd.Parameters.AddWithValue("@TIPOTARIFA", idtipotarifa)
            cmd.Parameters.AddWithValue("@IDMEDIDOR", idMedidor)
            cmd.Parameters.AddWithValue("@CODIGO", codigo)
            cmd.Parameters.AddWithValue("@FECHA", FECHA) 'cmd.Parameters.AddWithValue("@FPAGO", DBNull.Value)
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
    Public Shared Function delete(ByVal idpredio, ByVal idmedidor) As Boolean
        Dim c As New ACCESO.Conexion

        If (c.Connect) Then
            If (c.Delete("delete  from padPredioServicioMedidor  where idpredio=" & idpredio & "  and idMedidor= " & idmedidor & "  ")) Then

            Else
                MsgBox("No se puede elminar el registro porque existen datos vinculados al mismo", MsgBoxStyle.Critical)
                c.Close()
                Return False
            End If
            c.Close()
        End If
        Return True
    End Function

    Public Shared Function elimina(ByVal idpredio, ByVal idmedidor) As Boolean
        Dim cmd As New SqlCommand()
        Dim c As New ACCESO.Conexion

        If (c.Connect) Then
            cmd.CommandText = ("update padPredioServicioMedidor set cEstado=0  where idpredio=" & idpredio & "  and idMedidor= " & idmedidor & "")
            c.Update(cmd)
            c.Close()
            If (c.msgError.CompareTo("") <> 0) Then
                MsgBox(c.msgError)
            End If
        End If


    End Function
    Public Shared Function ActivaMedidor(ByVal idpredio, ByVal idmedidor) As Boolean
        Dim cmd As New SqlCommand()
        Dim c As New ACCESO.Conexion

        If (c.Connect) Then
            cmd.CommandText = ("update padPredioServicioMedidor set cEstado=1  where idpredio=" & idpredio & "  and idMedidor= " & idmedidor & "")
            c.Update(cmd)
            c.Close()
            If (c.msgError.CompareTo("") <> 0) Then
                MsgBox(c.msgError)
            End If
        End If


    End Function
End Class
