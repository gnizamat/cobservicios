Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports ACCESO
Public Class clsAnioTarifa
    Private _anio As Integer
    'Private _idComision As Integer
    Private _idJunta As String
    Private _modalidad As Char
    Private _undRecaudacion As Char
    Private _estado As Char
    Private _idtipoTarifa As Integer

    'atributos de configuración de la tarifa
    Private _configCM1 As Char
    Private _configCM2 As Char
    Private _configCM3 As Char
    'Private _tipoTarifa As New clsTipoTarifa
    Private _configPD1 As Integer
    
    Public Property Estado() As Char
        Get
            Return Me._estado
        End Get
        Set(ByVal value As Char)
            Me._estado = value
        End Set
    End Property
   
    Public Property UndRecaudacion() As Char
        Get
            Return Me._undRecaudacion
        End Get
        Set(ByVal value As Char)
            Me._undRecaudacion = value
        End Set
    End Property
    Public Property Modalidad() As Char
        Get
            Return Me._modalidad
        End Get
        Set(ByVal value As Char)
            Me._modalidad = value
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
   
    Public Property configCM1()
        Get
            Return Me._configCM1
        End Get
        Set(ByVal value)
            Me._configCM1 = value
        End Set
    End Property
    Public Property configCM2()
        Get
            Return Me._configCM2
        End Get
        Set(ByVal value)
            Me._configCM2 = value
        End Set
    End Property
    Public Property configCM3()
        Get
            Return Me._configCM3
        End Get
        Set(ByVal value)
            Me._configCM3 = value
        End Set
    End Property
    Public Property configPD1()
        Get
            Return Me._configPD1
        End Get
        Set(ByVal value)
            Me._configPD1 = value
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
    Public Property idtipoTarifa()
        Get
            Return _idtipoTarifa
        End Get
        Set(ByVal value)
            _idtipoTarifa = value
        End Set
    End Property
    Sub New()

    End Sub
    Sub New(ByVal anio_tarifa As Integer, ByVal cod_junta As String, ByVal cod_tipo As Integer, ByVal modalidad As Char, ByVal unidad_recaudacion As Char)
        Me._anio = anio_tarifa
        'Me._idComision = cod_comision
        Me._idJunta = cod_junta
        Me.IdTipoTarifa = cod_tipo
        Me._undRecaudacion = unidad_recaudacion
        Me._modalidad = modalidad
        Me._configCM1 = "3"
        Me._configCM2 = "3"
        Me._configCM3 = "2"
        Me._configPD1 = 3

    End Sub
    Public Shared Sub ActivarTarifa(ByVal idjunta As String, ByVal anio As Integer)
        Dim c As New ACCESO.Conexion
        Dim dt As New DataTable
        If (c.Connect) Then
            c.Query("UPDATE tarTarifaComisionAnual set cEstadoTarifa='0' where vIdJuntaUsuario='" & idjunta & "' and cEstadoTarifa='1'")
            c.Query("UPDATE tarTarifaComisionAnual set cEstadoTarifa='1' where iAnioTarifa='" & anio & "' and vIdJuntaUsuario='" & idjunta & "' ")
            If (c.msgError <> "") Then
                MsgBox(c.msgError)
            End If
            c.Close()
        End If
    End Sub
    Public Shared Function isValidAnioTarifa(ByVal idjunta As String, ByVal idcomision As String, ByVal anio As Integer) As Boolean
        Dim c As New ACCESO.Conexion
        Dim dt As New DataTable
        If (c.Connect) Then
            dt = c.Query("select * from tarTarifaAnual where iAnioTarifa='" & anio & "' and vIdJas='" & idjunta & "' ")
            If (c.msgError <> "") Then
                MsgBox(c.msgError, MsgBoxStyle.Exclamation)
            Else
                If (dt.Rows.Count > 0) Then
                    Return False
                Else
                    Return True
                End If
            End If
        End If
    End Function
    Public Shared Sub LoadComboModalidad(ByRef cmb As Windows.Forms.ComboBox)
        Dim dt As New DataTable
        dt.Columns.Add("id")
        dt.Columns.Add("nombre")
        dt.Rows.Add(1, "Contraentrega")
        dt.Rows.Add(2, "Fraccionada")
        cmb.DataSource = dt
        cmb.ValueMember = dt.Columns(0).ToString()
        cmb.DisplayMember = dt.Columns(1).ToString()
        cmb.SelectedIndex = -1
    End Sub
    Public Shared Sub LoadComboUnidadRecaudacion(ByRef cmb As Windows.Forms.ComboBox)
        Dim dt As New DataTable
        dt.Columns.Add("id")
        dt.Columns.Add("nombre")
        dt.Rows.Add(1, "Soles por Metro Cúbico (S/. / m3)")
        dt.Rows.Add(2, "Soles por Hectarea (S/. / Ha.)")
        cmb.DataSource = dt
        cmb.ValueMember = dt.Columns(0).ToString()
        cmb.DisplayMember = dt.Columns(1).ToString()
        cmb.SelectedIndex = -1
    End Sub
    Public Sub Insert()
        Dim cmd As New SqlCommand()
        Dim c As New ACCESO.Conexion
        Me._estado = "1"
        If (c.Connect) Then
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "sp_tarTarifaComisionAnual_insert"
            cmd.Parameters.AddWithValue("@ANIO", Me._anio)
            'cmd.Parameters.AddWithValue("@IDCOMISION", Me._idComision)
            cmd.Parameters.AddWithValue("@IDJUNTA", Me._idJunta)
            'cmd.Parameters.AddWithValue("@IDTIPO", Me.IdTipoTarifa)
            cmd.Parameters.AddWithValue("@MODALIDAD", Me._modalidad)
            cmd.Parameters.AddWithValue("@UNDRECAUDACION", Me._undRecaudacion)
            cmd.Parameters.AddWithValue("@ESTADO", Me._estado)
            cmd.Parameters.AddWithValue("@CMCONFIG1", Me._configCM1)
            cmd.Parameters.AddWithValue("@CMCONFIG2", Me._configCM2)
            cmd.Parameters.AddWithValue("@CMCONFIG3", Me._configCM3)
            cmd.Parameters.AddWithValue("@PDCONFIG1", Me._configPD1)
            If (c.Execute(cmd) = False) Then
                MsgBox(c.msgError)
            End If
            c.Close()

        End If
    End Sub
    Public Sub Update()
        Dim cmd As New SqlCommand()
        Dim c As New ACCESO.Conexion
        If (c.Connect) Then
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "sp_tarTarifaComisionAnual_update"
            cmd.Parameters.AddWithValue("@ANIO", Me._anio)
            'cmd.Parameters.AddWithValue("@IDCOMISION", Me._idComision)
            cmd.Parameters.AddWithValue("@IDJUNTA", Me._idJunta)
            cmd.Parameters.AddWithValue("@IDTIPO", Me.idtipoTarifa)
            cmd.Parameters.AddWithValue("@MODALIDAD", Me._modalidad)
            cmd.Parameters.AddWithValue("@UNDRECAUDACION", Me._undRecaudacion)
            If (c.Update(cmd) = False) Then
                MsgBox(c.msgError)
            End If
            c.Close()
        End If
    End Sub
    Public Sub UpdateConfig()
        Dim cmd As New SqlCommand()
        Dim c As New ACCESO.Conexion
        If (c.Connect) Then
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "sp_tarTarifaComisionAnual_UpdateConfig"
            cmd.Parameters.AddWithValue("@ANIO", Me._anio)
            'cmd.Parameters.AddWithValue("@IDCOMISION", Me._idComision)
            cmd.Parameters.AddWithValue("@IDJUNTA", Me._idJunta)
            cmd.Parameters.AddWithValue("@CMCONFIG1", Me._configCM1)
            cmd.Parameters.AddWithValue("@CMCONFIG2", Me._configCM2)
            cmd.Parameters.AddWithValue("@CMCONFIG3", Me._configCM3)
            cmd.Parameters.AddWithValue("@PDCONFIG1", Me._configPD1)
            If (c.Update(cmd) = False) Then
                MsgBox(c.msgError)
            End If
            c.Close()
        End If
    End Sub
    Public Shared Sub Delete(ByVal idjunta As String, ByVal idanio As Integer)
        Dim cmd As New SqlCommand()
        Dim c As New ACCESO.Conexion
        If (c.Connect) Then
            c.Delete("DELETE FROM tarTarifaComisionAnual where iAnioTarifa='" & idanio & "' and vIdJuntaUsuario='" & idjunta & "'")
            If (c.msgError <> "") Then
                'MsgBox(c.msgError, MsgBoxStyle.Critical)
                MessageBox.Show(c.msgError, "SIGMA", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            c.Close()
        End If
    End Sub


    Public Shared Function getTarifaActual() As clsAnioTarifa
        Dim dt As New DataTable
        Dim c As New ACCESO.Conexion
        Dim tarifa As New clsAnioTarifa
        If (c.Connect) Then
            dt = c.Query("SELECT iAnioTarifa,cUndRecaudacion,cModalidad,cCMConfig1 from tarTarifaAnual WHERE  cEstadoTarifa=1 ")
            If (c.msgError <> "") Then
                MsgBox(c.msgError)
            Else
                If (dt.Rows.Count > 0) Then
                    tarifa._anio = dt.Rows(0).Item(0)
                    'tarifa._idComision = idcomision
                    'tarifa._idJunta = idjunta
                    tarifa._undRecaudacion = dt.Rows(0).Item(1)
                    tarifa._modalidad = dt.Rows(0).Item(2)
                    tarifa._configCM1 = dt.Rows(0).Item(3)

                Else
                    Return Nothing
                End If
            End If
            c.Close()
        End If
        Return tarifa
    End Function
    Public Shared Function getTarifa(ByVal idjunta As String, ByVal anio As Integer) As clsAnioTarifa
        Dim dt As New DataTable
        Dim c As New ACCESO.Conexion

        Dim tarifa As New clsAnioTarifa
        If (c.Connect) Then
            dt = c.Query("SELECT iAnioTarifa,cUndRecaudacion,cModalidad,cCMConfig1  from tarTarifaAnual WHERE vIdJas='" & idjunta & "'  and iAnioTarifa='" & anio & "'")
            If (c.msgError <> "") Then
                MsgBox(c.msgError)
            Else
                If (dt.Rows.Count > 0) Then
                    tarifa._anio = dt.Rows(0).Item(0)
                    'tarifa._idComision = idcomision
                    tarifa._idJunta = idjunta
                    tarifa.idtipoTarifa = dt.Rows(0).Item("iidTipoTarifa")
                    tarifa._undRecaudacion = dt.Rows(0).Item(1)
                    tarifa._modalidad = dt.Rows(0).Item(2)
                    tarifa._configCM1 = dt.Rows(0).Item(3)


                Else
                    Return Nothing
                End If
            End If
            c.Close()
        End If
        Return tarifa
    End Function
    Public Shared Sub LoadCombo(ByRef cmb As Windows.Forms.ComboBox, Optional ByVal condicion As String = "")
        Dim c As New ACCESO.Conexion
        If (c.Connect()) Then
            Dim dt = c.Query("SELECT iAnioTarifa,cUndRecaudacion,cModalidad,cCMConfig1 from tarTarifaAnual " & condicion & " order by iAnioTarifa desc")
            cmb.DataSource = dt
            cmb.ValueMember = dt.Columns(0).ToString()
            cmb.DisplayMember = dt.Columns(0).ToString()
            cmb.Text = ""
            'cmb.SelectedIndex = -1
            c.Close()
        End If
    End Sub
    Public Shared Sub LoadComboADD(ByRef cmb As Windows.Forms.ComboBox, Optional ByVal condicion As String = "", Optional ByVal all As Boolean = True)
        Dim c As New ACCESO.Conexion
        If (c.Connect()) Then
            Dim dt = c.Query("SELECT iAnioTarifa,Cast(iAnioTarifa as char(10)) AS Descrip  from tarTarifaAnual " & condicion & " order by iAnioTarifa desc")

            If (all And dt.Rows.Count > 0) Then
                dt.Rows.Add(0, "[Todos]")
            End If
            cmb.DataSource = dt
            cmb.ValueMember = dt.Columns(0).ToString()
            cmb.DisplayMember = dt.Columns(1).ToString()
            cmb.Text = ""
            cmb.SelectedValue = 0
            c.Close()
        End If
    End Sub
    Public Shared Sub LoadComboAnioVigente(ByRef cmb As Windows.Forms.ComboBox, Optional ByVal condicion As String = "")
        Dim c As New ACCESO.Conexion
        If (c.Connect()) Then
            Dim dt = c.Query("SELECT iAnioTarifa,cUndRecaudacion,cModalidad,cCMConfig1 from tarTarifaAnual where cEstadoTarifa='1' ")
            cmb.DataSource = dt
            cmb.ValueMember = dt.Columns(0).ToString()
            cmb.DisplayMember = dt.Columns(0).ToString()
            cmb.Text = ""
            'cmb.SelectedIndex = -1
            c.Close()
        End If
    End Sub
    Public Shared Function List2(Optional ByVal condicion As String = "", Optional ByVal columns As String = "") As DataTable
        Dim dt As New DataTable
        Dim c As New ACCESO.Conexion
        If (c.Connect) Then
            dt = c.Query("SELECT * FROM tarTarifaAnual" & condicion & " order by iAnioTarifa desc")
            If (c.msgError <> "") Then
                MsgBox(c.msgError)
            End If
            c.Close()
        End If
        Return dt
    End Function
    End Class
