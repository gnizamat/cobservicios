Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Data.OleDb
Imports ACCESO
Imports LOGICA


Public Class clsUsuario

    Private _idJas As String = ""
    Private _id As Integer
    Private _nombre As String = ""
    Private _apePaterno As String = ""
    Private _apeMaterno As String = ""
    Private _idTipoPersona As String = "0"
    Private _sexo As String = ""
    Private _telefono As String = ""
    Private _celular As String = ""
    Private _email As String = ""
    Private _ruc As String = ""
    Private _dni As String = ""
    'Private _observaciones As String = ""
    Private _direccion As String = ""
    Private _estado As String = "1"
    Private _fRegistro As Date


    Public Property estado()
        Get
            Return Me._estado
        End Get
        Set(ByVal value)
            Me._estado = value
        End Set
    End Property

    Public Property direccion()
        Get
            Return Me._direccion
        End Get
        Set(ByVal value)
            Me._direccion = value
        End Set
    End Property
    'Public Property observaciones()
    '    Get
    '        Return Me._observaciones
    '    End Get
    '    Set(ByVal value)
    '        Me._observaciones = value
    '    End Set
    'End Property
    Public Property dni()
        Get
            Return Trim(Me._dni)
        End Get
        Set(ByVal value)
            Me._dni = value
        End Set
    End Property
    Public Property ruc()
        Get
            Return Trim(Me._ruc)
        End Get
        Set(ByVal value)
            Me._ruc = value
        End Set
    End Property
    Public Property email()
        Get
            Return Me._email
        End Get
        Set(ByVal value)
            Me._email = value
        End Set
    End Property
    'Public Property fax()
    '    Get
    '        Return Me._fax
    '    End Get
    '    Set(ByVal value)
    '        Me._fax = value
    '    End Set
    'End Property
    Public Property celular()
        Get
            Return Me._celular
        End Get
        Set(ByVal value)
            Me._celular = value
        End Set
    End Property
    Public Property telefono()
        Get
            Return Me._telefono
        End Get
        Set(ByVal value)
            Me._telefono = value
        End Set
    End Property
    Public Property sexo()
        Get
            Return Me._sexo
        End Get
        Set(ByVal value)
            Me._sexo = value
        End Set
    End Property
    Public Property idTipoPersona()
        Get
            Return Me._idTipoPersona
        End Get
        Set(ByVal value)
            Me._idTipoPersona = value
        End Set
    End Property
    Public Property apeMaterno()
        Get
            Return Me._apeMaterno
        End Get
        Set(ByVal value)
            Me._apeMaterno = value
        End Set
    End Property
    'agregago conyuge
   
   
    Public Property nombre()
        Get
            Return Me._nombre
        End Get
        Set(ByVal value)
            Me._nombre = value
        End Set
    End Property
    Public Property idJas()
        Get
            Return Me._idJas
        End Get
        Set(ByVal value)
            Me._idJas = value
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
    Public Property apePaterno()
        Get
            Return Me._apePaterno
        End Get
        Set(ByVal value)
            Me._apePaterno = value
        End Set
    End Property

    Sub New(ByVal idjas As String, ByVal tipopersona As String, ByVal nombre As String, ByVal apepaterno As String, ByVal apematerno As String, ByVal dni As String, ByVal ruc As String, ByVal direccion As String, ByVal Email As String, ByVal Celular As String, ByVal sexo As String, Optional ByVal fecha_registro As String = "")
        Me._idJas = idjas
        Me._nombre = nombre
        Me._apePaterno = apepaterno
        Me._apeMaterno = apematerno
        Me._dni = dni
        Me._ruc = ruc
        Me._sexo = sexo
        'Me._telefono = telefono
        Me._celular = Celular
        'Me._fax = fax
        Me._email = Email
        'Me._observaciones = observaciones
        Me._idTipoPersona = tipopersona
        Me._direccion = direccion
        If (fecha_registro = "") Then
            Me._fRegistro = Nothing
        Else
            Me._fRegistro = fecha_registro
        End If

        'agregago conyuge
        'Me._Conyuge = Conyuge
        'Me._CDNI = CDNI
    End Sub
    Public Shared Sub LoadComboTipoPersona(ByRef cmb As Windows.Forms.ComboBox)
        Dim dt As New DataTable
        dt.Columns.Add("id")
        dt.Columns.Add("nombre")
        dt.Rows.Add(1, "Natural")
        dt.Rows.Add(2, "Juridica")
        dt.Rows.Add(3, "Institucional")
        cmb.DataSource = dt
        cmb.ValueMember = dt.Columns(0).ToString()
        cmb.DisplayMember = dt.Columns(1).ToString()
        cmb.SelectedIndex = -1
    End Sub
    Public Shared Sub LoadComboSexo(ByRef cmb As Windows.Forms.ComboBox)
        Dim dt As New DataTable
        dt.Columns.Add("id")
        dt.Columns.Add("nombre")
        dt.Rows.Add(1, "Masculino")
        dt.Rows.Add(2, "Femenino")
        cmb.DataSource = dt
        cmb.ValueMember = dt.Columns(0).ToString()
        cmb.DisplayMember = dt.Columns(1).ToString()
        cmb.SelectedIndex = -1
    End Sub
    Public Shared Function List(Optional ByVal condicion As String = "", Optional ByVal estado As String = "") As DataTable
        Dim dt As New DataTable
        Dim c As New ACCESO.Conexion
        If (c.Connect) Then
            Dim strQuery As String = "select * from padUsuario where cEstado like '" & estado & "%'"
            dt = c.Query(strQuery & condicion)
            c.Close()
        End If
        Return dt
    End Function
    Public Shared Function ListTranferencia(Optional ByVal condicion As String = "", Optional ByVal estado As String = "") As DataTable
        Dim dt As New DataTable
        Dim c As New ACCESO.Conexion
        If (c.Connect) Then
            Dim strQuery As String = "SELECT vNombre, Calle, vNroPredio, mzPredio, lotePredio, idpredio, idcalle,iIdusuario, cEstado FROM view_PrediosBasico "
            dt = c.Query(strQuery & condicion)
            c.Close()
        End If
        Return dt
    End Function
    Public Function ListPredios(Optional ByVal condicion As String = "") As DataTable
        Dim dt As New DataTable
        Dim c As New ACCESO.Conexion
        If (c.Connect) Then
            'Dim strQuery As String = "select p.iIdPredio,p.vNombre,p.iIdComisionRegante,c.vNombre,p.vIdJuntaUsuario,j.vNombre,p.iIdBloqueRiego,b.vNombre,tp.iIdTipoResolucion,tp.vNombre,p.iIdSubsector,s.vNombre,p.iIdSectorRiego,p.fAreaTotal,p.fAreaPermiso,p.fAreaLicencia,p.fAreaFiltracion,p.fAreaBR,p.fVolPermiso,p.fVolLicencia,p.vUC,p.vUCAnt,p.vCodIde,p.dFechaResolucion,p.vNroResolucion,p.dFechaRegistro,p.tObservacion,p.cEstadoPredio from padPredios p,padUsuarioPredio up,padUsuario u,JuntaUsuario j,SubSectorRiego s,ComisionRegante c,padTipoResolucion tp,invBloqueRiego b where tp.iIdTipoResolucion = p.iIdTipoResolucion And s.iIdSubsector = p.iIdSubsector And s.iIdSectorRiego = p.iIdSectorRiego And c.iIdComisionRegante = p.iIdComisionRegante And c.vIdJuntaUsuario = p.vIdJuntaUsuario And j.vIdJuntaUsuario = p.vIdJuntaUsuario And b.iIdBloqueRiego = p.iIdBloqueRiego And b.vIdJuntaUsuario = p.vIdJuntaBloque And up.iIdPredio = p.iIdPredio And up.vIdJuntaPredio = p.vIdJuntaUsuario And up.iIdComisionRegante = p.iIdComisionRegante And u.iIdUsuario = up.iIdUsuario And u.vIdJuntaUsuario = up.vIdJuntaUsuario and up.vIdJuntaUsuario='" & Me.idJunta & "' and up.iIdUsuario='" & Me.id & "' "
            Dim strQuery As String = "execute sp_usuario_predios '" & Me.idJas & "'," & Me.id & ",'" & condicion & "'"
            dt = c.Query(strQuery)
            c.Close()
        End If
        Return dt
    End Function
    Public Function LoadComboPredios(ByVal cmb As ComboBox, Optional ByVal condicion As String = "") As DataTable
        Dim dt As New DataTable
        dt = Me.ListPredios(condicion)
        If (dt.Rows.Count > 0) Then
            cmb.DataSource = dt
            cmb.ValueMember = dt.Columns(0).ToString()
            cmb.DisplayMember = dt.Columns(1).ToString()
            cmb.SelectedIndex = -1
        End If
        Return dt
    End Function
    Private Function NewId()
        Dim c As New ACCESO.Conexion
        Dim dt As New DataTable
        Dim id As Integer
        If (c.Connect) Then
            dt = c.Query("select isnull(max(iIdUsuario),0) from padUsuario where vIdJas='" & Me._idJas & "'")
            id = dt.Rows(0).Item(0) + 1
            c.Close()
        End If
        Return id
    End Function
    Private Function NewId_OpenConnection(ByRef c As ACCESO.Conexion)
        Dim dt As New DataTable
        Dim id As Integer
        dt = c.Query(String.Format("select isnull(max(iIdUsuario),0) from padUsuario where vIdJas='{0}'", Me._idJas))
        id = dt.Rows(0).Item(0) + 1
        Return id
    End Function
   
    Public Sub Insert()
        'If Not c.OpenConnection Then
        '    Return False
        'End If
        Dim cmd As New SqlCommand()
        Dim c As New ACCESO.Conexion
        Me._id = Me.NewId
        If (c.Connect) Then
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "padUsuario_insert"
            cmd.Parameters.AddWithValue("@P_1", Me._idJas)
            cmd.Parameters.AddWithValue("@P_2", Me._id)
            cmd.Parameters.AddWithValue("@P_3", IIf(Me._idTipoPersona <> "1", Me._nombre.ToUpper, ACCESO.PUBLICAS.ConvierteACapital(Me._nombre)))
            cmd.Parameters.AddWithValue("@P_4", Me._apePaterno.ToUpper)
            cmd.Parameters.AddWithValue("@P_5", Me._apeMaterno.ToUpper)
            cmd.Parameters.AddWithValue("@P_6", Me._dni)
            cmd.Parameters.AddWithValue("@P_7", Me._ruc)

            cmd.Parameters.AddWithValue("@P_8", Me._direccion)
            cmd.Parameters.AddWithValue("@P_9", Me._email)
            cmd.Parameters.AddWithValue("@P_10", Me._celular)
            cmd.Parameters.AddWithValue("@P_11", Me._idTipoPersona)
            cmd.Parameters.AddWithValue("@P_12", ACCESO.Conexion.getDatetimeServer)
            cmd.Parameters.AddWithValue("@P_13", "1")
            cmd.Parameters.AddWithValue("@P_14", Me._sexo)

            If (c.Insert(cmd) = False) Then
                MsgBox(c.msgError)
            End If
            c.Close()
        End If
        'cmd.Parameters.AddWithValue("@P_29", Me._NroVia)
        

    End Sub
    Public Sub Update()
        Dim cmd As New SqlCommand()
        Dim c As New ACCESO.Conexion
        If (c.Connect) Then
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "padUsuario_update"
            cmd.Parameters.AddWithValue("@P_1", Me._idJas)
            cmd.Parameters.AddWithValue("@P_2", Me._id)
            cmd.Parameters.AddWithValue("@P_3", IIf(Me._idTipoPersona <> "1", Me._nombre.ToUpper, ACCESO.PUBLICAS.ConvierteACapital(Me._nombre)))
            cmd.Parameters.AddWithValue("@P_4", Me._apePaterno.ToUpper)
            cmd.Parameters.AddWithValue("@P_5", Me._apeMaterno.ToUpper)
            cmd.Parameters.AddWithValue("@P_6", Me._dni)
            cmd.Parameters.AddWithValue("@P_7", Me._ruc)

            cmd.Parameters.AddWithValue("@P_8", Me._direccion)
            cmd.Parameters.AddWithValue("@P_9", Me._email)
            cmd.Parameters.AddWithValue("@P_10", Me._celular)
            cmd.Parameters.AddWithValue("@P_11", Me._idTipoPersona)
            cmd.Parameters.AddWithValue("@P_12", ACCESO.Conexion.getDatetimeServer)
            cmd.Parameters.AddWithValue("@P_13", "1")
            cmd.Parameters.AddWithValue("@P_14", Me._sexo)

            If (c.Update(cmd) = False) Then
                MsgBox(c.msgError)
            End If
            c.Close()
        End If
        'cmd.Parameters.AddWithValue("@P_29", Me._NroVia)

    End Sub
    Public Shared Sub delete(ByVal id, ByVal idjas)
        Dim cmd As New SqlCommand()
        Dim c As New ACCESO.Conexion
        If (c.Connect) Then
            cmd.CommandText = "UPDATE padUsuario set cEstado=0 where iIdUsuario='" & id & "' and vIdJas='" & idjas & "'"
            c.Update(cmd)
            c.Close()
            If (c.msgError.CompareTo("") <> 0) Then
                MsgBox(c.msgError)
            End If
        End If

    End Sub
    Public Shared Function LoadUsuario(ByVal id As Integer, ByVal idjunta As String) As clsUsuario
        Dim c As New ACCESO.Conexion
        Dim dt As New DataTable
        Dim obj As clsUsuario
        If (c.Connect) Then
            dt = clsUsuario.List(" and iIdUsuario='" & id & "' and vIdJuntaUsuario='" & idjunta & "'")
            For Each MiDataRow As DataRow In dt.Rows
                obj._id = MiDataRow(0)
              
                '''''
                obj._idJas = MiDataRow(0)
                obj._nombre = MiDataRow(1)
                obj._apePaterno = MiDataRow(3)
                obj._apeMaterno = MiDataRow(4)
                obj._dni = MiDataRow(5)
                obj._ruc = MiDataRow(6)
                obj._sexo = MiDataRow(7)
                'Me._telefono = telefono
                obj._celular = MiDataRow(8)
                'Me._fax = faxMiDataRow(1)email
                'Me._observaciones = observaciones
                obj._idTipoPersona = MiDataRow(9)
                obj._direccion = MiDataRow(10)
                If (obj._fRegistro = "") Then
                    obj._fRegistro = Nothing
                Else
                    obj._fRegistro = MiDataRow(11)
                End If

                '''''
            Next
        End If
        Return obj
    End Function
    
    'Public Shared Function LoadUsuarioByDNI(ByVal nroDNI As String) As clsUsuario
    '    Dim c As New ACCESO.Conexion
    '    Dim dt As New DataTable
    '    Dim obj As New clsUsuario
    '    If (c.Connect) Then
    '        dt = clsUsuario.List(" and vDNI='" & nroDNI & "'")
    '        For Each MiDataRow As DataRow In dt.Rows
    '            obj._idJas = MiDataRow(1)
    '            obj._id = MiDataRow(0)

    '            obj._nombre = MiDataRow(2)
    '            obj._apePaterno = MiDataRow(3)
    '            obj._apeMaterno = MiDataRow(4)
    '            obj._idTipoPersona = MiDataRow(5)
    '            obj._dni = MiDataRow(8).ToString
    '            obj._ruc = MiDataRow(9).ToString
    '            obj._direccion = MiDataRow(10).ToString
    '            obj._telefono = MiDataRow(11).ToString
    '            obj._celular = MiDataRow(12).ToString
    '            obj._fax = MiDataRow(13).ToString
    '            obj._sexo = MiDataRow(14).ToString
    '            'obj._observaciones = MiDataRow(16).ToString
    '            obj._email = MiDataRow(17).ToString

    '            obj._estado = MiDataRow("cEstado").ToString
    '            'agrego conyuge

    '        Next
    '    End If
    '    Return obj
    'End Function
    'Public Shared Function LoadUsuarioByRUC(ByVal ruc As String) As clsUsuario
    '    Dim c As New ACCESO.Conexion
    '    Dim dt As New DataTable
    '    Dim obj As New clsUsuario
    '    If (c.Connect) Then
    '        dt = clsUsuario.List(" and vRUC='" & ruc & "'")
    '        For Each MiDataRow As DataRow In dt.Rows
    '            obj._id = MiDataRow(0)
    '            obj._idJas = MiDataRow(1)
    '            obj._nombre = MiDataRow(3)
    '            obj._apePaterno = MiDataRow(4)
    '            obj._apeMaterno = MiDataRow(5)
    '            obj._idTipoPersona = MiDataRow(6)
    '            obj._dni = MiDataRow(8).ToString
    '            obj._ruc = MiDataRow(9).ToString
    '            obj._direccion = MiDataRow(10).ToString
    '            obj._telefono = MiDataRow(11).ToString
    '            obj._celular = MiDataRow(12).ToString
    '            obj._fax = MiDataRow(13).ToString
    '            obj._sexo = MiDataRow(14).ToString

    '            'obj._observaciones = MiDataRow(16).ToString
    '            obj._email = MiDataRow(17).ToString
    '            obj._estado = MiDataRow("cEstado").ToString

    '            'agrego conyuge

    '        Next
    '    End If
    '    Return obj
    'End Function
    Public Shared Function isHomonimo(ByVal idJunta, ByVal nombre, ByVal apaterno, ByVal amaterno)
        Dim dt As New DataTable
        Dim c As New ACCESO.Conexion
        If (c.Connect) Then
            dt = c.Query("select * from padUsuario where vIdJas='" & idJunta & "' and vUsuario='" & nombre & "' and vApePaterno='" & apaterno & "' and vApeMaterno='" & amaterno & "'")
            c.Close()
        End If
        If (dt.Rows.Count > 0) Then
            Return True
        Else
            Return False
        End If
    End Function
    
    
    Public Shared Sub ReemplazaUsuarioPredio(ByVal id, ByVal nid, ByVal idjunta)
        Dim cmd As New SqlCommand()
        Dim c As New ACCESO.Conexion
        If (c.Connect) Then
            cmd.CommandText = "UPDATE padUsuarioPredio set iIdUsuario='" & nid & "' Where iIdUsuario='" & id & "' and vIdJuntaUsuario='" & idjunta & "'"
            c.Update(cmd)
            c.Close()
            If (c.msgError.CompareTo("") <> 0) Then
                MsgBox(c.msgError)
            End If
        End If
    End Sub

    Public Shared Sub elimina(ByVal id, ByVal idjunta)
        Dim cmd As New SqlCommand()
        Dim c As New ACCESO.Conexion
        If (c.Connect) Then
            cmd.CommandText = "DELETE padUsuario Where iIdUsuario='" & id & "' and vIdJas='" & idjunta & "'"
            c.Update(cmd)
            c.Close()
            If (c.msgError.CompareTo("") <> 0) Then
                MsgBox(c.msgError)
            End If
        End If
    End Sub
    Public Shared Function ExisteDNI(ByVal dni As String, ByVal idj As String) As Boolean
        Dim c As New ACCESO.Conexion
        Dim existe As Boolean = False
        Dim dt As New DataTable
        If (c.Connect) Then
            dt = c.Query("select * from padUsuario where vDNI='" & dni & "' and vIdJas='" & idj & "'")
            If (dt.Rows.Count > 0) Then
                existe = True
            End If
            c.Close()
        End If
        Return existe
    End Function
    Public Shared Function ExisteRUC(ByVal ruc As String, ByVal idj As String) As Boolean
        Dim c As New ACCESO.Conexion
        Dim existe As Boolean = False
        Dim dt As New DataTable
        If (c.Connect) Then
            dt = c.Query("select * from padUsuario where vRUC='" & ruc & "' and vIdJas='" & idj & "'")
            If (dt.Rows.Count > 0) Then
                existe = True
            End If
            c.Close()
        End If
        Return existe
    End Function
    
    Public Function ListDeudasPredios(Optional ByVal condicion As String = "")
        Dim c As New ACCESO.Conexion
        Dim dt As New DataTable
        If (c.Connect) Then
            dt = c.Query("select vIdJas,iIdComisionRegante,iIdPredio,predio,tipo_deuda,fmonto,fsaldo,iAnioTarifa,iIdDetalleDeuda from view_DetalleDeudaPredios where vIdJuntaUsuario='" & Me.idJas & "' and iIdUsuario='" & Me.id & "' " & condicion)
            If (c.msgError <> "") Then
                MsgBox(c.msgError)
            End If
            c.Close()
        End If
        Return dt
    End Function
   
    Public Shared Sub LoadCombo(ByRef cmb As Windows.Forms.ComboBox, ByVal condicion As String)
        Dim c As New ACCESO.Conexion
        If (c.Connect()) Then
            Dim dt = c.Query("select vIdJas,iIdUsuario,(vNombres+' '+vApePaterno+' '+vApeMaterno) as 'Usuario' from padUsuario " & condicion & " order by Usuario asc")
            cmb.DataSource = dt
            cmb.ValueMember = dt.Columns(1).ToString()
            cmb.DisplayMember = dt.Columns(2).ToString()
            cmb.Text = ""

            c.Close()
        End If
    End Sub

    Public Shared Function ListAsistencia(Optional ByVal condicion As String = "") As DataTable
        Dim dt As New DataTable
        Dim c As New ACCESO.Conexion

        If (c.Connect) Then
            Dim strQuery As String = "select * from view_AsistenciaUsuarios where "
            dt = c.Query(strQuery & condicion)
            c.Close()
        End If
        Return dt
    End Function
    'Public Shared Function listUsuarioPredio(ByVal vIdJuntaUsuario, ByVal condicion) As DataTable
    '    Dim dt As New DataTable
    '    Dim c As New ACCESO.Conexion
    '    Dim strQuery As String = ""
    '    If (c.Connect) Then
    '        strQuery = "execute sp_RInvPadron  '" & idJas & "','" & condicion & "'"
    '        dt = c.Query(strQuery)
    '        c.Close()
    '    End If
    '    Return dt
    'End Function
End Class

