Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports ACCESO

Public Class clsActividadesCalculadas
    Dim _ianio As Integer
    Dim _sIdJuntaUsuario As String
    Dim _iIdComisionRegante As Integer
    Dim _iIdEstructura As Integer
    Dim _iIdRubro As Integer
    Dim _iIdTipooperacion As Integer
    Dim _fValor As Double

    Public Property Anio()
        Get
            Return Me._ianio
        End Get
        Set(ByVal value)
            Me._ianio = value
        End Set
    End Property
    Public Property IdJunta()
        Get
            Return Me._sIdJuntaUsuario
        End Get
        Set(ByVal value)
            Me._sIdJuntaUsuario = value
        End Set
    End Property
    Public Property IdComision()
        Get
            Return Me._iIdComisionRegante
        End Get
        Set(ByVal value)
            Me._iIdComisionRegante = value
        End Set
    End Property
    Public Property IdEstructura()
        Get
            Return Me._iIdEstructura
        End Get
        Set(ByVal value)
            Me._iIdEstructura = value
        End Set
    End Property
    Public Property IdRubro()
        Get
            Return Me._iIdRubro
        End Get
        Set(ByVal value)
            Me._iIdRubro = value
        End Set
    End Property

    Public Property IdTipoOperacion()
        Get
            Return Me._iIdTipooperacion
        End Get
        Set(ByVal value)
            Me._iIdTipooperacion = value
        End Set
    End Property

    Public Property Valor()
        Get
            Return Me._fValor
        End Get
        Set(ByVal value)
            Me._fValor = value
        End Set
    End Property


    Public Shared Sub LoadCheckedList(ByRef cmb As Windows.Forms.CheckedListBox, Optional ByVal condicion As String = "")
        Dim c As New ACCESO.Conexion
        Dim i As Integer
        If c.Connect Then
            Dim dt = c.Query("SELECT iIdRubro, case len(vCodRubro) when 1 then space(1)+vCodRubro else vCodRubro end + ' - ' + vDesRubro FROM dbo.view_ActividadesCalculadas " & condicion)
            cmb.DataSource = dt
            cmb.ValueMember = dt.Columns(0).ToString()
            cmb.DisplayMember = dt.Columns(1).ToString()
            cmb.Text = ""
            For i = 0 To cmb.Items.Count - 1
                cmb.CheckOnClick = True
                cmb.SetItemChecked(i, True)
            Next
            If cmb.Items.Count <> 0 Then
                cmb.SelectedIndex = 0
            Else
                cmb.SelectedIndex = -1
            End If

            c.Close()
        End If
    End Sub

    Public Shared Sub LoadCheckedList_Otros(ByRef cmb As Windows.Forms.CheckedListBox, Optional ByVal condicion As String = "")
        Dim c As New ACCESO.Conexion
        Dim i As Integer
        If c.Connect Then
            Dim dt = c.Query("SELECT idEstructuraD, vDescripcion FROM dbo.view_ActividadesCalculadas_Otros " & condicion)
            cmb.DataSource = dt
            cmb.ValueMember = dt.Columns(0).ToString()
            cmb.DisplayMember = dt.Columns(1).ToString()
            cmb.Text = ""
            For i = 0 To cmb.Items.Count - 1
                cmb.CheckOnClick = True
                cmb.SetItemChecked(i, True)
            Next
            If cmb.Items.Count <> 0 Then
                cmb.SelectedIndex = 0
            Else
                cmb.SelectedIndex = -1
            End If

            c.Close()
        End If
    End Sub

    Public Shared Function List(Optional ByVal condicion As String = "") As DataTable
        Dim dt As New DataTable
        Dim c As New ACCESO.Conexion
        If (c.Connect) Then
            dt = c.Query("select * From dbo.view_ActividadesCalculadas " & condicion)
            c.Close()
        End If
        Return dt
    End Function

    Public Function Insert() As Boolean
        Dim cmd As New SqlCommand()
        Dim c As New ACCESO.Conexion
        If (c.Connect) Then
            cmd.CommandText = "INSERT INTO CalculoActividadFinanciera(iAnio, vIdJuntaUsuario, iIdComisionRegante, idEstructura, iIdRubro)" _
            & " VALUES (@ANIO,@IDJUNTA,@IDCR,@IDEST,@IDRUBRO)"
            cmd.Parameters.AddWithValue("@ANIO", Me._ianio)
            cmd.Parameters.AddWithValue("@IDJUNTA", Me._sIdJuntaUsuario)
            cmd.Parameters.AddWithValue("@IDCR", Me._iIdComisionRegante)
            cmd.Parameters.AddWithValue("@IDEST", Me._iIdEstructura)
            cmd.Parameters.AddWithValue("@IDRUBRO", Me._iIdRubro)

            If (c.Update(cmd) = False) Then
                MsgBox(c.msgError)
            End If
            c.Close()
        End If
    End Function

    Public Function Insert_Otros() As Boolean
        Dim cmd As New SqlCommand()
        Dim c As New ACCESO.Conexion
        If (c.Connect) Then
            cmd.CommandText = "INSERT INTO CalculoActividades(iAnio, vIdJuntaUsuario, iIdComisionRegante, idEstructura, idEstructuraD,cTipo,fValor)" _
            & " VALUES (@ANIO,@IDJUNTA,@IDCR,@IDEST,@IDRUBRO,@IDTIPO,@VALOR)"
            cmd.Parameters.AddWithValue("@ANIO", Me._ianio)
            cmd.Parameters.AddWithValue("@IDJUNTA", Me._sIdJuntaUsuario)
            cmd.Parameters.AddWithValue("@IDCR", Me._iIdComisionRegante)
            cmd.Parameters.AddWithValue("@IDEST", Me._iIdEstructura)
            cmd.Parameters.AddWithValue("@IDRUBRO", Me._iIdRubro)
            cmd.Parameters.AddWithValue("@IDTIPO", IIf(Me._iIdTipooperacion.ToString = "", DBNull.Value, Me._iIdTipooperacion.ToString))
            cmd.Parameters.AddWithValue("@VALOR", Me._fValor)

            If (c.Update(cmd) = False) Then
                MsgBox(c.msgError)
            End If
            c.Close()
        End If
    End Function

    Public Function Delete() As Boolean
        Dim cmd As New SqlCommand()
        Dim c As New ACCESO.Conexion
        If (c.Connect) Then

            cmd.CommandText = "DELETE  FROM CalculoActividadFinanciera WHERE iAnio=@ANIO AND vIdJuntaUsuario=@IDJUNTA AND iIdComisionRegante=@IDCR AND idEstructura=@IDEST"
            cmd.Parameters.AddWithValue("@ANIO", Me._ianio)
            cmd.Parameters.AddWithValue("@IDJUNTA", Me._sIdJuntaUsuario)
            cmd.Parameters.AddWithValue("@IDCR", Me._iIdComisionRegante)
            cmd.Parameters.AddWithValue("@IDEST", Me._iIdEstructura)
            If (c.Update(cmd) = False) Then
                MsgBox(c.msgError)
            End If
            c.Close()
        End If
    End Function

    Public Function Delete_Otros() As Boolean
        Dim cmd As New SqlCommand()
        Dim c As New ACCESO.Conexion
        If (c.Connect) Then

            cmd.CommandText = "DELETE  FROM CalculoActividades WHERE iAnio=@ANIO AND vIdJuntaUsuario=@IDJUNTA AND iIdComisionRegante=@IDCR AND idEstructura=@IDEST"
            cmd.Parameters.AddWithValue("@ANIO", Me._ianio)
            cmd.Parameters.AddWithValue("@IDJUNTA", Me._sIdJuntaUsuario)
            cmd.Parameters.AddWithValue("@IDCR", Me._iIdComisionRegante)
            cmd.Parameters.AddWithValue("@IDEST", Me._iIdEstructura)
            If (c.Update(cmd) = False) Then
                MsgBox(c.msgError)
            End If
            c.Close()
        End If
    End Function
End Class
