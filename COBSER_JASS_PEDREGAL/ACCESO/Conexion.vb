Imports System.IO
Imports System.Windows.Forms
Imports System.Data.SqlServerCe
Imports System.Data.SqlClient
Imports System.Text

Public Class Conexion
    Private _server As String
    Private _database As String
    Private _user As String
    Private _password As String
    Private _idGrupo As Integer
    Private _strConexion As String
    Private _conexion As SqlConnection
    Private _msgError As String = ""
    Private _pathMap As String = ""
    Private _pathRPT As String = ""
    'acceso a las propiedades de la clase
    Private _transaction As SqlTransaction
    Private _iniTransaction As Boolean = False
    Private _error As Boolean = False
    Private _openConnection As Boolean = False


    Public Property conexion()
        Get
            Return Me._conexion
        End Get
        Set(ByVal value)
            Me._conexion = value
        End Set
    End Property
    Public Property myError()
        Get
            Return Me._error
        End Get
        Set(ByVal value)
            Me._error = value
        End Set
    End Property
    Public ReadOnly Property pathRPT()
        Get
            Return Me._pathRPT
        End Get
    End Property

    Public ReadOnly Property pathMap()
        Get
            Return Me._pathMap
        End Get
    End Property
    Public Property strConexion() As String
        Get
            Return Me._strConexion
        End Get
        Set(ByVal value As String)
            Me._strConexion = value
        End Set
    End Property
    Public Property msgError() As String
        Get
            Return Me._msgError
        End Get
        Set(ByVal value As String)
            Me._msgError = value
        End Set
    End Property
    Public ReadOnly Property server()
        Get
            Return Me._server
        End Get
    End Property
    Public ReadOnly Property database()
        Get
            Return Me._database
        End Get
    End Property
    Public ReadOnly Property user()
        Get
            Return Me._user
        End Get
    End Property
    Public ReadOnly Property password()
        Get
            Return Me._password
        End Get
    End Property
    Public ReadOnly Property idGrupo()
        Get
            Return Me._idGrupo
        End Get
    End Property
    Public Property OpenConnection() As Boolean
        Get
            Return Me._openConnection
        End Get
        Set(ByVal value As Boolean)
            Me._openConnection = value
        End Set
    End Property

    'adiciona los parametros de conexion
    Public Sub AddParams(ByVal srv As String, ByVal usr As String, ByVal pw As String, ByVal db As String, ByVal idg As Integer)
        Me._server = srv
        Me._user = usr
        Me._database = db
        Me._password = pw
        Me._idGrupo = idg
    End Sub
    Public Shared Sub LoadComboServer(ByRef cmb As ComboBox)
        Dim dt As New DataTable
        dt = Sql.SqlDataSourceEnumerator.Instance.GetDataSources
        cmb.Items.Clear()
        If (dt.Rows.Count > 0) Then
            For Each midata As DataRow In dt.Rows
                cmb.Items.Add(midata(0) & "\" & midata(1))
            Next
        End If

    End Sub
    Public Shared Sub TesterConnection(ByVal Iserver As String, ByVal user As String, ByVal password As String, ByVal bd As String)
        Dim ccn As System.Data.SqlClient.SqlConnection
        Dim strCCN As String = "Data Source=" & Iserver & ";Initial Catalog=" & bd & ";User ID=" & user & ";Password=" & password
        Dim dt As New DataTable
        Try
            ccn = New System.Data.SqlClient.SqlConnection(strCCN)
            ccn.Open()
            ccn.Close()
            MsgBox("Conexión Satisfactoria", MsgBoxStyle.Information)
        Catch e As Exception
            MsgBox("ERROR DE CONEXION: " & vbCrLf & e.Message, MsgBoxStyle.Critical)
        End Try

    End Sub
    Public Shared Sub LoadComboBD(ByRef cmb As ComboBox, ByVal Iserver As String, ByVal user As String, ByVal password As String)
        Dim ccn As System.Data.SqlClient.SqlConnection
        Dim strCCN As String = "Data Source=" & Iserver & ";Initial Catalog=master;User ID=" & user & ";Password=" & password
        Dim dt As New DataTable
        'MsgBox("abri conexion")
        Try
            ccn = New System.Data.SqlClient.SqlConnection(strCCN)
            ccn.Open()
            Dim dbDataAdapter As New SqlDataAdapter("exec sp_helpdb", strCCN)
            dbDataAdapter.Fill(dt)
            cmb.DataSource = dt
            cmb.ValueMember = dt.Columns(0).ToString
            cmb.DisplayMember = dt.Columns(0).ToString
            ccn.Close()
        Catch e As Exception
            'MsgBox("ERROR DE CONEXION: " & e.Message)
        End Try

    End Sub

    Public Function updatePathMap(ByVal path As String) As Boolean

        Try
            Me._pathMap = path
            'conexion a la base de datos local que guarda los parametros de acceso a la Base de Datos SIRIG
            Dim sqlconnection As New SqlCeConnection("Data Source=" & Application.StartupPath & "\ENTORNO\SIMIG.sdf;pwd=edink09")
            sqlconnection.Open()
            Dim m = sqlconnection.CreateCommand()
            'actualizo mis parametros
            m.CommandText = "update config_sirig set  pathMap=@PATH where id=1"
            m.Parameters.AddWithValue("@PATH", Me._pathMap)
            Dim reader = m.ExecuteReader()
            'cierro la conexion
            sqlconnection.Close()
            Return True
        Catch e As Exception
            Me._msgError = "No se encuentra la Base de Datos de Configuracion SIGMA.sdf en " & Application.StartupPath & ": " & e.Message
            Return False
        End Try
    End Function


    Public Function updatePathRPT(ByVal path As String) As Boolean

        Try
            Me._pathRPT = path
            'conexion a la base de datos local que guarda los parametros de acceso a la Base de Datos SIRIG
            Dim sqlconnection As New SqlCeConnection("Data Source=" & Application.StartupPath & "\ENTORNO\SIMIG.sdf;pwd=edink09")
            sqlconnection.Open()
            Dim m = sqlconnection.CreateCommand()
            'actualizo mis parametros
            m.CommandText = "update config_sirig set  pathRPT=@PATH where id=1"
            m.Parameters.AddWithValue("@PATH", Me._pathRPT)
            Dim reader = m.ExecuteReader()
            'cierro la conexion
            sqlconnection.Close()
            Return True
        Catch e As Exception
            Me._msgError = "No se encuentra la Base de Datos de Configuracion SMA.sdf en " & Application.StartupPath & ": " & e.Message
            Return False
        End Try
    End Function

    'carga los parametros de conexion de la base de datos local
    Public Function LoadConnection() As Boolean
        Try
            'conexion a la base de datos local que guarda los parametros de acceso a la Base de Datos SIRIG
            Dim sqlconnection As New SqlCeConnection("Data Source=" & Application.StartupPath & "\ENTORNO\SIMIG.sdf;pwd=edink09")
            sqlconnection.Open()
            Dim m = sqlconnection.CreateCommand()
            'obtengo todos los parametros de conexion
            m.CommandText = "select id, servidor,usuario,password,bd,idGrupo,pathMap,pathRPT from config_sirig where id=1"
            Dim reader = m.ExecuteReader()
            'asigno los valores a mi clase
            reader.Read()
            Me._server = reader(1).ToString
            Me._user = reader(2).ToString
            Me._password = reader(3).ToString
            Me._database = reader(4).ToString
            Me._idGrupo = reader(5)
            Me._pathMap = reader(6).ToString
            Me._pathRPT = reader(7).ToString
            'cierro la conexion
            sqlconnection.Close()
            Return True
        Catch e As Exception
            Me._msgError = "No se encuentra la Base de Datos de Configuracion SIGMA.sdf en " & Application.StartupPath & ": " & e.Message
            Return False
        End Try
    End Function

    'guarda los parametros de conexion en la base de datos local
    Public Function SaveConnection()
        Try
            'conexion a la base de datos local que guarda los parametros de acceso a la Base de Datos SIRIG
            Dim sqlconnection As New SqlCeConnection("Data Source=" & Application.StartupPath & "\ENTORNO\SIMIG.sdf;pwd=edink09")
            sqlconnection.Open()
            Dim m = sqlconnection.CreateCommand()
            'actualizo mis parametros
            m.CommandText = "update config_sirig set servidor=@SERVIDOR,usuario=@USUARIO,password=@PASSWORD,bd=@BD,idGrupo=@GRUPO where id=1"
            m.Parameters.AddWithValue("@SERVIDOR", Me._server)
            m.Parameters.AddWithValue("@USUARIO", Me._user)
            m.Parameters.AddWithValue("@PASSWORD", Me._password)
            m.Parameters.AddWithValue("@BD", Me._database)
            m.Parameters.AddWithValue("@GRUPO", Me._idGrupo)

            Dim reader = m.ExecuteReader()
            'cierro la conexion
            sqlconnection.Close()
            Return True
        Catch e As Exception
            Me._msgError = "No se encuentra la Base de Datos de Configuracion SMA.sdf en " & Application.StartupPath & ": " & e.Message
            Return False
        End Try
    End Function

    'Realiza la conexion a la base de datos SIRIG
    Public Function Connect() As Boolean
        If (Me.LoadConnection()) Then
            Me._strConexion = "Data Source=" & Me._server & ";Initial Catalog=" & Me._database & ";User ID=" & Me._user & ";Password=" & Me._password
            'MsgBox("abri conexion")
            Try
                Me._conexion = New System.Data.SqlClient.SqlConnection(Me._strConexion)
                Me._conexion.Open()
                Return True
            Catch e As Exception
                Me._msgError = "Error al crear la conexión:" & vbCrLf & e.Message
                Return False
            End Try
        End If
    End Function
    Public Function IniTransaction() As Boolean
        Me._transaction = Me._conexion.BeginTransaction()
        Me._iniTransaction = True
    End Function
    Public Function Commit() As Boolean
        Me._transaction.Commit()
        Me._error = False
    End Function
    Public Function RollBack() As Boolean
        Me._transaction.Rollback()
    End Function
    'realiza consultas a la base de datos SIRIG y devuelve un datatable
    Public Function Query(ByVal strQuery As String)
        Dim dt As New DataTable
        Try
            Dim dbDataAdapter As New SqlDataAdapter(strQuery, Me._strConexion)

            dbDataAdapter.Fill(dt)
        Catch ex As Exception
            Me._error = True
            Me._msgError = "Error mientras se realizaba la consulta" & vbCrLf & ex.Message
        End Try
        Return dt

    End Function
    Public Sub QueryDataset(ByVal strQuery As String, ByRef dataset As DataSet, ByVal table As String)
        Dim dt As New DataTable
        Try
            Dim dbDataAdapter As New SqlDataAdapter(strQuery, Me._strConexion)
            dbDataAdapter.Fill(dataset, table)
        Catch ex As Exception
            Me._msgError = "Error mientras se realizaba la consulta" & vbCrLf & ex.Message
        End Try
    End Sub
    'elimina registros de la base de datos y devuelvge true si la operacion fue correcta
    Public Function Delete(ByVal strQuery As String) As Boolean
        Try
            Dim cmd As New SqlCommand(strQuery, Me._conexion)
            If (Me._iniTransaction) Then
                cmd.Transaction = Me._transaction
            End If
            cmd.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            Me._error = True
            Me._msgError = "No se puede eliminar Elemento : Item se encuentra vinculado a otra información" & vbCrLf & "SIGMA" & vbCrLf & "Debe eliminar la información Vinculada antes de continuar"
            Return False
        End Try

    End Function
    'actualiza registros de la base de datos
    Public Function Update(ByRef cmd As SqlCommand) As Boolean
        Try
            'cmd.CommandText = strQuery
            If (Me._iniTransaction) Then
                cmd.Transaction = Me._transaction
            End If
            cmd.Connection = Me._conexion
            Dim t As Integer = cmd.ExecuteNonQuery
            Return True
        Catch ex As Exception
            Me._error = True
            Me._msgError = "Error mientras se intentaba actualizar el registro" & vbCrLf & ex.Message
            Return False
        End Try

    End Function
    Public Function Insert(ByRef cmd As SqlCommand)
        Try
            cmd.Connection = Me._conexion
            If (Me._iniTransaction) Then
                cmd.Transaction = Me._transaction
            End If
            Dim t = (cmd.ExecuteNonQuery)
            Return True
        Catch ex As Exception
            Me._error = True
            Me._msgError = "Error mientras se intentaba grabar el registro:" & vbCrLf & ex.Message
            Return False
        End Try
    End Function

    Public Sub BulkCopy(ByVal tabla As String, ByVal dt As DataTable)
        Dim sqlbc As New SqlBulkCopy(Me._conexion)
        sqlbc.DestinationTableName = tabla
        sqlbc.WriteToServer(dt)
    End Sub

    Public Function QueryCMD(ByRef cmd As SqlCommand) As DataTable
        Dim dt As New DataTable

        Try
            Dim da As New SqlDataAdapter(cmd)
            da.SelectCommand.Connection = Me._conexion
            If (Me._iniTransaction) Then
                cmd.Transaction = Me._transaction
            End If
            da.Fill(dt)
        Catch ex As Exception
            Me._error = True
            Me._msgError = ex.Message
            Me._msgError = "Error mientras se intentaba realizar la consulta al procedimiento: " & vbCrLf & ex.Message
        End Try
        Return dt
    End Function
    'cierra la conexion de la base de datos SIRIG
    Public Sub Close()
        Me._conexion.Close()
        'MsgBox("cerre conexion")
    End Sub
    Public Sub IncrementTable(ByVal table As String)
        Dim c As New Conexion
        Dim cmd As New SqlCommand()
        If (c.Connect) Then
            cmd.CommandText = "update sysTablas set iUltCorrelativo=iUltCorrelativo+1 where vTabla='" & table & "'"
            c.Update(cmd)
            c.Close()
        End If
    End Sub
    'carga un combobox con todos los tipos de grupos que maneja la interfaz 
    Public Shared Sub LoadCombo(ByRef cmb As Windows.Forms.ComboBox)
        Dim reader As SqlCeDataReader
        Dim dt As New DataTable
        Try
            'conexion a la base de datos local que guarda los parametros de acceso a la Base de Datos SIRIG
            Dim sqlconnection As New SqlCeConnection("Data Source=" & Application.StartupPath & "\ENTORNO\SIMIG.sdf;pwd=edink09")
            sqlconnection.Open()
            Dim m = sqlconnection.CreateCommand()
            'obtengo todos los parametros de conexion
            m.CommandText = "select idGrupo,vNombre from sysGrupo"
            reader = m.ExecuteReader
            dt.Columns.Add("idGrupo")
            dt.Columns.Add("vNombre")
            While (reader.Read)
                dt.Rows.Add(reader(0), reader(1))
            End While
            cmb.DataSource = dt
            cmb.ValueMember = dt.Columns(0).ToString
            cmb.DisplayMember = dt.Columns(1).ToString
            cmb.Text = ""
            'cierro la conexion
            sqlconnection.Close()

        Catch e As Exception
            MsgBox(e.Message)
        End Try


    End Sub
    Public Shared Function getDateServer() As String
        Dim c As New ACCESO.Conexion
        Dim dt As New DataTable
        Dim fecha As String = ""
        If (c.Connect) Then
            dt = c.Query("select dbo.fn_get_fecha() AS 'FECHA'")
            If (dt.Rows.Count > 0) Then
                fecha = dt.Rows(0).Item(0)
            End If
            c.Close()
        End If
        Return fecha
    End Function
    Public Shared Function getDatetimeServer() As DateTime
        Dim c As New ACCESO.Conexion
        Dim dt As New DataTable
        Dim fecha As New DateTime
        If (c.Connect) Then
            dt = c.Query("select dbo.fn_get_NOWDATETIME() AS 'FECHA'")
            If (dt.Rows.Count > 0) Then
                fecha = dt.Rows(0).Item(0)
            End If
            c.Close()
        End If
        Return fecha
    End Function
    Public Shared Sub TreeDataBase(ByRef tv As TreeView)
        Dim c As New ACCESO.Conexion
        Dim dt As New DataTable
        Dim dt_columns As New DataTable
        Dim tn As New TreeNode
        Dim tn2 As New TreeNode
        If (c.Connect) Then
            dt = c.Query("SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE' AND TABLE_CATALOG='" & c._database & "' order by TABLE_NAME asc")
            For Each midatarow As DataRow In dt.Rows
                tn = New TreeNode(midatarow(0))
                tn.SelectedImageIndex = 0
                tn.ImageIndex = 0
                tv.Nodes.Add(tn)
                dt_columns = c.Query("SELECT COLUMN_NAME FROM information_schema.columns WHERE table_name = '" & midatarow(0) & "'")
                For Each midatarow2 As DataRow In dt_columns.Rows
                    tn2 = New TreeNode(midatarow2(0))
                    tn2.SelectedImageIndex = 1
                    tn2.ImageIndex = 1
                    tn.Nodes.Add(tn2)
                Next
            Next
            c.Close()
        End If
    End Sub

    

    Public Function BACKUP_BD(ByVal directorio As String, ByVal backup As String, ByVal descripcion As String) As Boolean

        Dim c As New Conexion
        Dim crear_backup As Boolean
        Dim ruta As String
        ruta = directorio & "\" + backup & ".bak"
        If (c.Connect) Then
            Try
                c.Query("BACKUP DATABASE [" & c.database + "] TO  DISK = N'" & ruta & "' WITH DESCRIPTION = N'" & descripcion & "', NOFORMAT, NOINIT,NAME = N'" & backup & "', SKIP, NOREWIND, NOUNLOAD,  STATS = 10")
                crear_backup = True
            Catch ex As Exception
                crear_backup = False
                MsgBox(ex.Message)
            End Try
            c.Close()
        End If

        Return crear_backup

    End Function
  
    Public Sub SyncData(ByRef ce As ConexionSqlCe, ByVal scope_name As String, ByVal tablas() As String, ByVal tablas_pk() As String)
        'Dim synchronizationHelper As SynchronizationHelper = New SynchronizationHelper(scope_name, tablas, tablas_pk)
        'Dim srcProvider As RelationalSyncProvider = New SqlCeSyncProvider(scope_name, ce.sqlConnection)
        'Dim destinationProvider As RelationalSyncProvider = New SqlSyncProvider(scope_name, Me.conexion)
        'synchronizationHelper.ConfigureSqlSyncProvider(Me)
        'Dim stats As SyncOperationStatistics = synchronizationHelper.SynchronizeProviders(Me, srcProvider, destinationProvider)
        ''Set memory data cache size property. 0 represents non batched mode
        'srcProvider.MemoryDataCacheSize = 0
        'destinationProvider.MemoryDataCacheSize = 0

    End Sub
    Public Sub ImportData(ByRef ce As ConexionSqlCe, ByVal tablas() As String)
        Dim dt As New DataTable
        Dim cmd As New SqlCommand()
        For Each tabla As String In tablas
            dt = ce.Query("select * from " & tabla)
            cmd = New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = tabla & "_insert"
            For Each r As DataRow In dt.Rows
                For i As Integer = 1 To dt.Columns.Count
                    cmd.Parameters.AddWithValue("@P_" & i, r(i - 1))
                Next
                Me.Insert(cmd)
                cmd.Parameters.Clear()
            Next
        Next
    End Sub
    Public Sub EnableIntegridad(ByVal active As Integer)
        Dim cmd As New SqlCommand
        cmd.CommandText = "sp_mant_ActivarIntegridad"
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@ACTIVE", active)
        Me.Insert(cmd)
    End Sub
    Public Function crear_backup(ByVal directorio As String, ByVal backup As String, ByVal descripcion As String) As Boolean
        Dim c As New Conexion
        Dim ruta As String

        Dim conecsb As New SqlConnectionStringBuilder

        If c.Connect Then
            ruta = directorio & "\" + backup & ".bak"
            conecsb.DataSource = Me._server
            conecsb.InitialCatalog = "master"
            conecsb.IntegratedSecurity = True
            conecsb.Password = Me._password
            conecsb.UserID = Me._user
            c.Close()
            Using con As New SqlConnection(conecsb.ConnectionString)
                Try
                    con.Open()
                    Dim sCmd As New StringBuilder
                    'sCmd.Append("ALTER DATABASE " + c.database + " SET SINGLE_USER WITH ROLLBACK IMMEDIATE " & Chr(13))
                    sCmd.Append("BACKUP DATABASE [" + c.database + "] TO  DISK = N'" + ruta + "' ")
                    sCmd.Append("WITH DESCRIPTION = N'" + descripcion + "', FORMAT, INIT, ")
                    sCmd.Append("NAME = N'" + backup + "', SKIP, NOREWIND, NOUNLOAD,  STATS = 10, CHECKSUM" & Chr(13))
                    sCmd.Append(" ALTER DATABASE " + c.database + " SET MULTI_USER " & Chr(13))
                    Dim cmd As New SqlCommand(sCmd.ToString, con)
                    cmd.ExecuteNonQuery()
                    crear_backup = True
                Catch ex As Exception
                    crear_backup = False
                    MessageBox.Show(ex.Message)
                    ex = Nothing
                Finally
                    con.Close()
                End Try
            End Using
        End If
    End Function

   

    Public Function Execute(ByRef cmd As SqlCommand)
        If Me.OpenConnection Then
            Try
                cmd.Connection = Me._conexion
                cmd.CommandTimeout = 360
                If (Me._iniTransaction) Then
                    cmd.Transaction = Me._transaction
                End If
                Dim t = (cmd.ExecuteNonQuery)
                Return True
            Catch ex As Exception
                Me._error = True
                Me._msgError = "Error mientras se intentaba ejecutar la operacion:" & vbCrLf & ex.Message
                Return False
            End Try
        Else
            Me._msgError = "No existe una conexion para realizar la operacion"
            Return False
        End If

    End Function
End Class

