Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports ACCESO

Public Class clsAperturaAnio
    Private _iIdComisionRegante As Integer
    Private _IdJuntaUsuario As String
    Private _iAnio As Integer
    Private _cExisteTUIMay As String
    Private _iMetasLargoPlazo As Integer
    Private _fvalorRealTarifa As Double
    Private _fValorActualTarifa As Double
    Private _dFechaIniCamp As Date
    Private _dFechaFinCamp As Date
    Private _cEstado As String
    Private _cEstadoDatosGenerales As String
    Private _msgError As String = ""

    Public ReadOnly Property msgError() As String
        Get
            Return Me._msgError
        End Get
    End Property

    Public Property IdJunta()
        Get
            Return Me._IdJuntaUsuario
        End Get
        Set(ByVal value)
            Me._IdJuntaUsuario = value
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

    Public Property Anio()
        Get
            Return Me._iAnio
        End Get
        Set(ByVal value)
            Me._iAnio = value
        End Set
    End Property

    Public Property ExisteTUI_MAY()
        Get
            Return Me._cExisteTUIMay
        End Get
        Set(ByVal value)
            Me._cExisteTUIMay = value
        End Set
    End Property

    Public Property AniosMetasLargoPlazo()
        Get
            Return Me._iMetasLargoPlazo
        End Get
        Set(ByVal value)
            Me._iMetasLargoPlazo = value
        End Set
    End Property

    Public Property ValorRealTarifa()
        Get
            Return Me._fvalorRealTarifa
        End Get
        Set(ByVal value)
            Me._fvalorRealTarifa = value
        End Set
    End Property

    Public Property ValorActualTarifa()
        Get
            Return Me._fValorActualTarifa
        End Get
        Set(ByVal value)
            Me._fValorActualTarifa = value
        End Set
    End Property

    Public Property FechaIni_Camp()
        Get
            Return Me._dFechaIniCamp
        End Get
        Set(ByVal value)
            Me._dFechaIniCamp = value
        End Set
    End Property

    Public Property Fechafin_Camp()
        Get
            Return Me._dFechaFinCamp
        End Get
        Set(ByVal value)
            Me._dFechaFinCamp = value
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

    Public Property EstadoDatosGenerales()
        Get
            Return Me._cEstadoDatosGenerales
        End Get
        Set(ByVal value)
            Me._cEstadoDatosGenerales = value
        End Set
    End Property

    Private Function Valida_Apertura()
        Dim c As New ACCESO.Conexion
        Dim dt As New DataTable
        Dim id As Integer
        If (c.Connect) Then
            dt = c.Query("select ianio from AperturaAnio where  vIdJuntaUsuario=" & Me._IdJuntaUsuario & " AND iIdComisionRegante=" & Me._iIdComisionRegante & " AND cEstado=1") 'iAnio=" & Me._iAnio & " and
            If dt.Rows.Count > 0 Then
                id = dt.Rows(0).Item(0)
            Else
                id = 0
            End If
            c.Close()
        End If
        Return id
    End Function

    Public Shared Function Valida_DatosGenerales(Optional ByVal condicion As String = "") As DataTable
        Dim dt As New DataTable
        Dim c As New ACCESO.Conexion
        If (c.Connect) Then
            dt = c.Query("SELECT * FROM view_Apertura " & condicion)
            c.Close()
        End If
        Return dt
    End Function

    Public Shared Function List(Optional ByVal condicion As String = "") As DataTable
        Dim dt As New DataTable
        Dim c As New ACCESO.Conexion
        If (c.Connect) Then
            dt = c.Query("SELECT * FROM view_Apertura " & condicion)
            c.Close()
        End If
        Return dt
    End Function

    Public Function Insert() As Boolean
        Dim cmd As New SqlCommand()
        Dim c As New ACCESO.Conexion
        If (c.Connect) Then
            If Valida_Apertura() = 0 Then
                Me._cEstado = 1
                'If Me._iIdComisionRegante <> 0 Then
                cmd.CommandText = "INSERT INTO AperturaAnio (iAnio,vIdJuntaUsuario, iIdComisionRegante,cEstado,cExisteTUIMayor,iMetasLargoPlazo,fValorRealTarifa,fValorActualTarifa,dFechaIniCamp,dFechaFinCamp)" _
                                & " VALUES (@ANIO,@IDJU,@IDCR,@TIPO,@TUI,@METAS,@TREAL,@TACTUAL,@FINI,@FFIN)"
                cmd.Parameters.AddWithValue("@IDJU", Me._IdJuntaUsuario)
                cmd.Parameters.AddWithValue("@IDCR", Me._iIdComisionRegante)
                cmd.Parameters.AddWithValue("@ANIO", Me._iAnio)
                cmd.Parameters.AddWithValue("@TIPO", Me._cEstado)
                cmd.Parameters.AddWithValue("@TUI", Me._cExisteTUIMay)
                cmd.Parameters.AddWithValue("@METAS", Me._iMetasLargoPlazo)
                cmd.Parameters.AddWithValue("@TREAL", Me._fvalorRealTarifa)
                cmd.Parameters.AddWithValue("@TACTUAL", Me._fValorActualTarifa)
                cmd.Parameters.AddWithValue("@FINI", Me._dFechaIniCamp)
                cmd.Parameters.AddWithValue("@FFIN", Me._dFechaFinCamp)
                If (c.Insert(cmd) = False) Then
                    'MsgBox(c.msgError)
                    Return False
                End If

                c.Query("EXEC sp_ConfigureDataIni " & Me._iAnio & ",'" & Me._IdJuntaUsuario & "'," & Me._iIdComisionRegante)
                c.Query("EXEC sp_Copia_Estructura_Padre '" & Me._IdJuntaUsuario & "'," & Me._iIdComisionRegante & "," & Me._iAnio)

                Return True
            Else
                _msgError = "Existe ya una apertura para el Año"
                Return False
            End If
            c.Close()

        End If

    End Function

    Public Function Update() As Boolean
        Dim cmd As New SqlCommand()
        Dim c As New ACCESO.Conexion
        If (c.Connect) Then

            cmd.CommandText = "UPDATE AperturaAnio SET cEstado=@TIPO, cExisteTUIMayor=@TUI,iMetasLargoPlazo=@METAS,fValorRealTarifa=@TREAL,fValorActualTarifa=@TACTUAL,dFechaIniCamp=@FINI,dFechaFinCamp=@FFIN " _
                              & " WHERE iAnio=@ANIO AND vIdJuntaUsuario=@IDJU AND iIdComisionRegante=@IDCR"
            cmd.Parameters.AddWithValue("@IDJU", Me._IdJuntaUsuario)
            cmd.Parameters.AddWithValue("@IDCR", Me._iIdComisionRegante)
            cmd.Parameters.AddWithValue("@ANIO", Me._iAnio)
            cmd.Parameters.AddWithValue("@TIPO", Me._cEstado)
            cmd.Parameters.AddWithValue("@TUI", Me._cExisteTUIMay)
            cmd.Parameters.AddWithValue("@METAS", Me._iMetasLargoPlazo)
            cmd.Parameters.AddWithValue("@TREAL", Me._fvalorRealTarifa)
            cmd.Parameters.AddWithValue("@TACTUAL", Me._fValorActualTarifa)
            cmd.Parameters.AddWithValue("@FINI", Me._dFechaIniCamp)
            cmd.Parameters.AddWithValue("@FFIN", Me._dFechaFinCamp)
            If c.Update(cmd) = False Then
                MsgBox(c.msgError)
                Return False
            Else
                Return True
            End If

            c.Close()
        End If
    End Function


    Public Shared Sub LoadCombo(ByRef cmb As ComboBox, ByVal idjunta As String, ByVal idcomision As Integer)
        Dim dt As New DataTable
        Dim c As New Conexion
        If c.Connect Then
            dt = c.Query("SELECT    iAnio  FROM  dbo.AperturaAnio WHERE  (vIdJuntaUsuario = '" & idjunta & "') AND (iIdComisionRegante = " & idcomision & ") AND (cEstado = '1') ORDER BY iAnio")
            cmb.DataSource = dt
            If dt.Rows.Count > 0 Then
                cmb.ValueMember = dt.Columns(0).ToString()
                cmb.DisplayMember = dt.Columns(0).ToString()
            End If
            If cmb.Items.Count > 0 Then cmb.SelectedItem = cmb.Items.Count - 1
            c.Close()
        End If
    End Sub
    Public Shared Sub LoadComboeX(ByRef cmb As ComboBox, ByVal idjunta As String, ByVal idcomision As Integer)
        Dim dt As New DataTable
        Dim c As New Conexion
        If c.Connect Then
            dt = c.Query("SELECT    iAnio  FROM  dbo.AperturaAnio WHERE  (vIdJuntaUsuario = '" & idjunta & "') AND (iIdComisionRegante = " & idcomision & ") AND (cEstado = '0') ORDER BY iAnio")
            cmb.DataSource = dt
            If dt.Rows.Count > 0 Then
                cmb.ValueMember = dt.Columns(0).ToString()
                cmb.DisplayMember = dt.Columns(0).ToString()
            End If
            If cmb.Items.Count > 0 Then cmb.SelectedItem = cmb.Items.Count - 1
            c.Close()
        End If
    End Sub
End Class
