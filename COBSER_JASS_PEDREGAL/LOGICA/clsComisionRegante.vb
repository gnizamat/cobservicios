Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Data.OleDb
Public Class clsComisionRegante
    Private _id As Integer
    Private _idJunta As String
    Private _nombre As String
    Private _estado As Boolean
    Private _idantiguo As String
    Sub New()

    End Sub
    Public Property id()
        Get
            Return Me._id
        End Get
        Set(ByVal value)
            Me._id = value
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
    Public Property nombre()
        Get
            Return Me._nombre
        End Get
        Set(ByVal value)
            Me._nombre = value
        End Set
    End Property
    Public Sub New(ByVal idj As String, ByVal nom As String, Optional ByVal idantiguo As String = "")
        Me._idJunta = idj
        Me._nombre = nom
        Me._idantiguo = idantiguo
    End Sub
    Private Function NewId()
        Dim c As New ACCESO.Conexion
        Dim dt As New DataTable
        Dim id As Integer
        If (c.Connect) Then
            dt = c.Query("select isNull(max(iIdComisionRegante),0) from ComisionRegante where vIdJuntaUsuario='" & Me._idJunta & "'")
            id = dt.Rows(0).Item(0) + 1
            c.Close()
        End If
        Return id
    End Function
    Public Sub Insert(Optional ByVal generate_id As Boolean = True)
        Dim cmd As New SqlCommand()
        Dim c As New ACCESO.Conexion
        If (generate_id) Then
            Me._id = Me.NewId
        End If
        If (c.Connect) Then
            cmd.CommandText = "INSERT INTO ComisionRegante(iIdComisionRegante,vIdJuntaUsuario,vNombre,vIdAntiguo) values(@ID,@IDJUNTA,@NOMBRE,@IDANTIGUO)"
            cmd.Parameters.AddWithValue("@ID", Me._id)
            cmd.Parameters.AddWithValue("@IDJUNTA", Me._idJunta)
            cmd.Parameters.AddWithValue("@NOMBRE", Me._nombre)
            cmd.Parameters.AddWithValue("@IDANTIGUO", Me._idantiguo)

            If (c.Insert(cmd) = False) Then
                MsgBox(c.msgError)
            End If
            c.Close()
        End If
    End Sub
    Public Sub Update()
        Dim cmd As New SqlCommand()
        Dim c As New ACCESO.Conexion
        If (c.Connect) Then
            cmd.CommandText = "update ComisionRegante set vNombre=@NOMBRE where iIdComisionRegante='" & Me._id & "' and vIdJuntaUsuario='" & Me.idJunta & "'"
            cmd.Parameters.AddWithValue("@NOMBRE", Me._nombre)
            If (Not c.Update(cmd)) Then
                MsgBox(c.msgError)
            End If
            c.Close()
        End If

    End Sub
    Public Shared Sub delete(ByVal id, ByVal idjunta)
        Dim c As New ACCESO.Conexion
        If (c.Connect) Then
            If (c.Delete("delete from ComisionRegante where iIdComisionRegante='" & id & "' and vIdJuntaUsuario='" & idjunta & "'")) Then
            Else
                MessageBox.Show(c.msgError, "SIGMA", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            c.Close()
        End If
    End Sub
    Public Shared Function List(Optional ByVal condicion As String = "") As DataTable
        Dim dt As New DataTable
        Dim c As New ACCESO.Conexion
        If (c.Connect) Then
            'dt = c.Query("select c.iIdComisionRegante,c.vNombre,c.vIdJuntaUsuario,j.vNombre,(select count(*) from ComiteRegante ct where ct.iIdComisionRegante=c.iIdComisionRegante and ct.vIdJuntaUsuario=c.vIdJuntaUsuario) as 'nro_comites',(select count(*) from invBloqueComision bc where bc.iIdComisionRegante=c.iIdComisionRegante) as 'nroBloques' from ComisionRegante c,JuntaUsuario j where j.vIdJuntaUsuario=c.vIdJuntaUsuario " & condicion)
            dt = c.Query("select c.iIdComisionRegante,c.vNombre,c.vIdJuntaUsuario,j.vNombre,'' as 'nro_comites','' as 'nroBloques' from ComisionRegante c,JuntaUsuario j where j.vIdJuntaUsuario=c.vIdJuntaUsuario " & condicion)

            c.Close()
        End If
        Return dt
    End Function
    Public Function listTarifas(Optional ByRef condicion As String = "") As DataTable
        Dim dt As New DataTable
        dt = clsAnioTarifa.List2(" where  vIdJas='" & Me.idJunta & "' " & condicion)
        Return dt
    End Function
    Public Shared Sub LoadCombo(ByRef cmb As Windows.Forms.ComboBox, Optional ByVal condicion As String = "", Optional ByVal order As String = " order by vNombre asc", Optional ByVal all As Boolean = False, Optional ByVal SelectionStart As Integer = -1)
        Dim c As New ACCESO.Conexion
        Dim dt As New DataTable
        If (c.Connect()) Then
            dt = c.Query("select c.iIdComisionRegante,c.vNombre from ComisionRegante c " & condicion & order)
            If (all And dt.Rows.Count > 0) Then
                dt.Rows.Add(0, "[Solo Junta de Usuarios]")
            End If
            cmb.DataSource = dt
            cmb.ValueMember = dt.Columns(0).ToString()
            cmb.DisplayMember = dt.Columns(1).ToString()
            'cmb.Text = ""
            If (SelectionStart <> -1) Then
                cmb.SelectionStart = SelectionStart
            End If
            c.Close()
        End If
    End Sub
    'Public Shared Sub GeneraTreeComite(ByRef trv As TreeView)
    '    Dim c As New ACCESO.Conexion
    '    Dim dt As New DataTable
    '    Dim dt2 As New DataTable
    '    Dim tn As New TreeNode
    '    Dim tn2 As New TreeNode
    '    dt = clsComisionRegante.List
    '    If (c.Connect) Then
    '        For Each MiDataRow As DataRow In dt.Rows
    '            tn = New TreeNode(MiDataRow(1))
    '            trv.Nodes.Add(tn)
    '            tn.Tag = "C-" & MiDataRow(0)
    '            tn.Name = MiDataRow(1)
    '            dt2 = clsComiteRegante.List(" and ct.iIdComisionRegante='" & MiDataRow(0) & "'")
    '            For Each MiDataRow2 As DataRow In dt2.Rows
    '                tn2 = New TreeNode(MiDataRow2(1))
    '                tn2.Tag = "T-" & MiDataRow2(0)
    '                tn2.Name = "T-" & MiDataRow2(0)
    '                tn.Nodes.Add(tn2)
    '            Next

    '        Next
    '        c.Close()
    '    End If
    'End Sub
    Public Function InsertOpenConnection(ByVal c As ACCESO.Conexion, Optional ByVal generate_id As Boolean = True) As Boolean
        Dim cmd As New SqlCommand()
        If (generate_id) Then
            Me._id = Me.NewId
        End If
        cmd.CommandText = "INSERT INTO ComisionRegante(iIdComisionRegante,vIdJuntaUsuario,vNombre,vIdAntiguo) values(@ID,@IDJUNTA,@NOMBRE,@IDANTIGUO)"
        cmd.Parameters.AddWithValue("@ID", Me._id)
        cmd.Parameters.AddWithValue("@IDJUNTA", Me._idJunta)
        cmd.Parameters.AddWithValue("@NOMBRE", Me._nombre)
        cmd.Parameters.AddWithValue("@IDANTIGUO", Me._idantiguo)
        If (c.Insert(cmd) = False) Then
            Return False
        Else
            Return True
        End If
    End Function
    Public Shared Function rows_count_MIGRAR_DE_SIRIG_II(ByVal bd As String) As Integer
        Dim deTipoCanales As New DataTable
        Dim strConexion As String = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" & bd
        Dim cn As OleDbConnection
        Dim dbDataAdapter As OleDbDataAdapter
        Dim dt As DataTable
        Dim query As String = ""
        Dim cont As Integer = 0
        Try
            cn = New OleDbConnection(strConexion)
            cn.Open()
            query = "select cCod_CR,xNom_CR,cCod_JU from [comision_de_regantes]"
            dbDataAdapter = New OleDbDataAdapter(query, cn)
            Dim commandBuilder As New OleDbCommandBuilder(dbDataAdapter)
            dt = New DataTable
            dbDataAdapter.Fill(dt)
            cont = dt.Rows.Count
            cn.Close()
        Catch ex As Exception
            MsgBox("Error al intentar conectarse a la BD: " & ex.Message)
        End Try
        Return cont
    End Function
    Public Shared Sub MIGRAR_DE_SIRIG_II(ByVal bd As String, ByVal password As String, ByRef bgw As System.ComponentModel.BackgroundWorker, ByRef rtb As RichTextBox, ByRef Migrados As Integer)
        Dim strConexion As String = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" & bd
        Dim dt As New DataTable
        Dim cr As clsComisionRegante
        Dim cMensaje As String = ""
        Dim lError As Boolean = False
        Dim strSql As String
        Dim c As New ACCESO.Conexion
        Dim dt_tmp As New DataTable
        Dim frm As New Form
        Dim msgTotal As String = ""
        Dim cAccess As New ACCESO.ConexionAccess(bd, password)
        Try
            If (cAccess.Connect) Then
                dt = cAccess.Query("select cCod_CR,xNom_CR,cCod_JU from [comision_de_regantes]")
                cAccess.Close()
            End If

            If dt.Rows.Count = 0 Then

                ''MsgBox("La TABLA de ACCESS 'COMISION_DE_REGANTES' no tiene información para migrar", MsgBoxStyle.Information, "Mensaje")
                rtb.Text = rtb.Text & vbCrLf & "La TABLA de ACCESS 'COMISION_DE_REGANTES' no tiene información para migrar" & vbCrLf

                Exit Sub
            End If

            'Antes verifico si hay información en la Tabla JuntaUsuarios
            strSql = "Select vIdJuntaUsuario From JuntaUsuario"
            If (c.Connect) Then
                dt_tmp = c.Query(strSql)
                c.Close()
            End If

            If (dt_tmp.Rows.Count = 0) Then
                'lError = True
                'cMensaje = "No ha migrado las Juntas de Usuarios y no puede continuar con la migración"
                rtb.Text = rtb.Text & vbCrLf & "La TABLA de 'JuntaUsuario' se encuentra vacia y no puede continuar con la migración" & vbCrLf
            Else
                For Each MiDataRow As DataRow In dt.Rows
                    strSql = "Select * From JuntaUsuario Where vIdJuntaUsuario='" & MiDataRow(2) & "'"
                    If (c.Connect) Then
                        dt_tmp = c.Query(strSql)
                    End If
                    If (dt_tmp.Rows.Count = 0) Then
                        'cMensaje = "No existe código de la Junta:' " + MiDataRow(2) + "' y no puede continuar con la migración"
                        'lError = True
                        rtb.Text = rtb.Text & vbCrLf & "No existe código de la Junta:' " & MiDataRow(2) & "' y no se migraran la comisiones de regantes relacionadas a esta Junta de usuarios" & vbCrLf
                    End If
                Next
            End If

            ''If lError = True Then
            ''MsgBox(cMensaje)
            ''Exit Sub
            ''End If

            Dim cont = 0
            Migrados = 0
            If (c.Connect) Then
                For Each MiDataRow As DataRow In dt.Rows
                    cr = New clsComisionRegante(MiDataRow(2), MiDataRow(1), MiDataRow(0))
                    cr.id = Val(MiDataRow(0).ToString.Substring(5, 2))
                    If (Not cr.InsertOpenConnection(c, False)) Then
                        rtb.Text = rtb.Text & vbCrLf & "ERROR REGISTRO " & cont & ": " & c.msgError & vbCrLf
                    Else
                        Migrados += 1
                    End If
                    cont += 1
                    bgw.ReportProgress(cont)
                Next
                c.Close()
            End If
            rtb.Text &= vbCrLf & Migrados & " registros migrados de " & cont & vbCrLf

        Catch ex As Exception
            MsgBox("Error al intentar conectarse a la BD: " & ex.Message)
        End Try

    End Sub

    Public Shared Function Export(Optional ByVal parametro As String = "") As String
        Dim dt As New DataTable
        Dim dt_columns As New DataTable
        Dim c As New ACCESO.Conexion
        Dim sqlExport As String = "/*************************COMISION DE REGANTES***********************/" & vbCrLf
        Dim insertColumns As String = ""
        Dim nroColumns As Integer
        Dim insertValues As String = ""
        Dim strInsert As String = ""
        Dim strUpdate As String = ""
        Dim updateValues As String = ""
        Dim index As Integer
        Dim valor As String = ""

        If (c.Connect) Then
            dt_columns = c.Query("SELECT COLUMN_NAME,DATA_TYPE,IS_NULLABLE FROM information_schema.columns WHERE table_name = 'ComisionRegante'")
            nroColumns = dt_columns.Rows.Count
            'cadena de nombre de columnas
            For Each MiDataRow2 As DataRow In dt_columns.Rows
                insertColumns = insertColumns & MiDataRow2(0) & ","
            Next
            insertColumns = insertColumns.Substring(0, insertColumns.Length - 1)
            dt = c.Query("select * from ComisionRegante " + parametro)
            'genero script de todos los datos del canal
            For Each MiDataRow As DataRow In dt.Rows
                insertValues = ""
                'cadena de datos
                For i = 0 To nroColumns - 1
                    'insertValues = insertValues & "'" & MiDataRow(i) & "',"
                    valor = ""
                    Select Case dt_columns.Rows(i).Item(1)
                        Case "varchar", "char", "text"
                            'Verifico si el campo acepta .NULL.
                            If Trim(MiDataRow(i).ToString) = "" And dt_columns.Rows(i).Item(2) = "YES" Then
                                valor = "NULL"
                            Else
                                valor = "'" & MiDataRow(i) & "'"
                            End If

                        Case "int", "float", "numeric"
                            If IsDBNull(MiDataRow(i)) Then
                                valor = "NULL"
                            Else
                                valor = MiDataRow(i).ToString
                            End If

                        Case "datetime"
                            If IsDBNull(MiDataRow(i)) Then
                                valor = "NULL"
                            Else
                                valor = "CONVERT(datetime,'" & Mid(MiDataRow(i).ToString, 1, 19) & "')"
                            End If
                        Case Else
                            If IsDBNull(MiDataRow(i)) And dt_columns.Rows(i).Item(2) = "YES" Then
                                valor = "NULL"
                            Else
                                valor = "'" & MiDataRow(i) & "'"
                            End If
                    End Select
                    insertValues = insertValues & valor & ","
                Next
                index = 3
                updateValues = ""
                For j = index To nroColumns - 1
                    'updateValues = updateValues & dt_columns.Rows(j).Item(0) & "='" & MiDataRow(j) & "',"
                    valor = ""
                    Select Case dt_columns.Rows(j).Item(1)
                        Case "varchar", "char", "text"
                            'Verifico si el campo acepta .NULL.
                            If Trim(MiDataRow(j).ToString) = "" And dt_columns.Rows(j).Item(2) = "YES" Then
                                valor = "NULL"
                            Else
                                valor = "'" & MiDataRow(j) & "'"
                            End If
                        Case "int", "float", "numeric"
                            If IsDBNull(MiDataRow(j)) Then
                                valor = "NULL"
                            Else
                                valor = MiDataRow(j).ToString
                            End If
                        Case "datetime"
                            If IsDBNull(MiDataRow(j)) Then
                                valor = "NULL"
                            Else
                                valor = "CONVERT(datetime,'" & Mid(MiDataRow(j).ToString, 1, 19) & "')"
                            End If

                        Case Else
                            If IsDBNull(MiDataRow(j)) And dt_columns.Rows(j).Item(2) = "YES" Then
                                valor = "NULL"
                            Else
                                valor = "'" & MiDataRow(j) & "'"
                            End If
                    End Select

                    updateValues = updateValues & dt_columns.Rows(j).Item(0) & "=" & valor & ","

                Next
                updateValues = updateValues.Substring(0, updateValues.Length - 1)
                insertValues = insertValues.Substring(0, insertValues.Length - 1)
                strInsert = "insert into ComisionRegante(" & insertColumns & ")" & " values(" & insertValues & ");" & vbCrLf
                strUpdate = "update ComisionRegante set " & updateValues & " where " & dt_columns.Rows(0).Item(0) & "=" & MiDataRow(0) & " And " & dt_columns.Rows(1).Item(0) & "=" & MiDataRow(1) & ";" & vbCrLf
                sqlExport = sqlExport & strInsert & strUpdate
            Next
            c.Close()
        End If
        Return sqlExport
    End Function

    Public Shared Sub GeneraTree(ByRef trv As TreeView, Optional ByVal condicion As String = "")
        Dim c As New ACCESO.Conexion
        Dim dt As New DataTable
        Dim dt2 As New DataTable
        Dim tn As New TreeNode
        Dim tn2 As New TreeNode
        dt = clsComisionRegante.List(condicion)
        If (c.Connect) Then
            For Each MiDataRow As DataRow In dt.Rows
                tn = New TreeNode(MiDataRow(1))
                trv.Nodes.Add(tn)
                tn.Tag = "J-" & MiDataRow(0)
                tn.Name = MiDataRow(1)
            Next
            c.Close()
        End If
    End Sub

    Public Shared Sub BuscarComision(ByRef Tv As TreeView, ByVal texto As String, ByVal sMayMin As Boolean)
        With Tv
            ' Indicar la clave a buscar , el tipo de búsqueda   
            ' ( Si se encuentra retorna una matriz de nodos )   
            Dim ret As TreeNode() = .Nodes.Find(texto, True)
            If ret.Length = 0 Then
                MsgBox("No se encontró", MsgBoxStyle.Information)
            Else
                ' seleccionar el nodo   
                .SelectedNode = ret(0)
                .SelectedNode.Expand() ' expandir 
                .Focus()
            End If
        End With

    End Sub


    'Public Function listTarifas(Optional ByRef condicion As String = "") As DataTable
    '    Dim dt As New DataTable
    '    dt = clsTarifa.List(" and tc.iIdComisionRegante='" & Me.id & "' and tc.vIdJuntaUsuario='" & Me.idJunta & "' " & condicion)
    '    Return dt
    'End Function



    Public Sub AddCanal(ByVal idCanal)
        Dim cmd As New SqlCommand()
        Dim c As New ACCESO.Conexion
        If (c.Connect) Then
            cmd.CommandText = "INSERT INTO invCanalComision(vIdJuntaUsuario,iIdComisionRegante,iIdCanalDren) values(@IDJUNTA,@IDCOMISION,@IDCANAL)"
            cmd.Parameters.AddWithValue("@IDJUNTA", Me._idJunta)
            cmd.Parameters.AddWithValue("@IDCOMISION", Me._id)
            cmd.Parameters.AddWithValue("@IDCANAL", idCanal)
            If (c.Insert(cmd) = False) Then
                MsgBox(c.msgError, MsgBoxStyle.Critical)
            End If
            c.Close()
        End If
    End Sub
    Public Function ExisteCanal(ByVal idCanal As Integer) As Boolean
        Dim c As New ACCESO.Conexion
        Dim dt As New DataTable
        If (c.Connect) Then
            dt = c.Query("Select * from invCanalComision WHERE vIdJuntaUsuario='" & Me.idJunta & "' AND iIdComisionRegante=" & Me.id & " AND iIdCanalDren='" & idCanal & "'")
            c.Close()
            If (dt.Rows.Count > 0) Then
                Return True
            End If
        End If
        Return False
    End Function
    Public Sub RemoveCanal(ByVal idCanal)
        Dim cmd As New SqlCommand()
        Dim c As New ACCESO.Conexion
        If (c.Connect) Then
            cmd.CommandText = "DELETE FROM invCanalComision  WHERE vIdJuntaUsuario=@IDJUNTA AND iIdComisionRegante=@IDCOMISION AND iIdCanalDren=@IDCANAL"
            cmd.Parameters.AddWithValue("@IDJUNTA", Me._idJunta)
            cmd.Parameters.AddWithValue("@IDCOMISION", Me._id)
            cmd.Parameters.AddWithValue("@IDCANAL", idCanal)
            If (c.Insert(cmd) = False) Then
                MsgBox(c.msgError, MsgBoxStyle.Critical)
            End If
            c.Close()
        End If
    End Sub
    Public Sub addBloque(ByVal idbloque, ByVal idJuntaBloque)
        Dim cmd As New SqlCommand()
        Dim c As New ACCESO.Conexion
        If (c.Connect) Then
            cmd.CommandText = "INSERT INTO invBloqueComision(iIdBloqueRiego,vIdJuntaBloque,iIdComisionRegante,vIdJuntaComision) values(@IDBLOQUE,@IDJUNTAB,@IDCOMISION,@IDJUNTAC)"
            cmd.Parameters.AddWithValue("@IDBLOQUE", idbloque)
            cmd.Parameters.AddWithValue("@IDJUNTAB", idJuntaBloque)
            cmd.Parameters.AddWithValue("@IDCOMISION", Me._id)
            cmd.Parameters.AddWithValue("@IDJUNTAC", Me._idJunta)
            If (c.Insert(cmd) = False) Then
                MsgBox(c.msgError)
            End If
            c.Close()
        End If
    End Sub
    Public Shared Sub addBloque(ByVal idbloque, ByVal idJuntaBloque, ByVal idjuntaComision, ByVal idcomision)
        Dim cmd As New SqlCommand()
        Dim c As New ACCESO.Conexion
        If (c.Connect) Then
            cmd.CommandText = "INSERT INTO invBloqueComision(iIdBloqueRiego,vIdJuntaBloque,iIdComisionRegante,vIdJuntaComision) values(@IDBLOQUE,@IDJUNTAB,@IDCOMISION,@IDJUNTAC)"
            cmd.Parameters.AddWithValue("@IDBLOQUE", idbloque)
            cmd.Parameters.AddWithValue("@IDJUNTAB", idJuntaBloque)
            cmd.Parameters.AddWithValue("@IDCOMISION", idcomision)
            cmd.Parameters.AddWithValue("@IDJUNTAC", idjuntaComision)

            If (c.Insert(cmd) = False) Then
                MsgBox(c.msgError)
            End If
            c.Close()
        End If
    End Sub
    Public Sub deleteBloque(ByVal idbloque As Integer)
        Dim cmd As New SqlCommand()
        Dim c As New ACCESO.Conexion
        If (c.Connect) Then
            c.Delete("delete from invBloqueComision where iIdBloqueRiego='" & idbloque & "' and vIdJuntaBloque='" & Me._idJunta & "' and iIdComisionRegante='" & Me._id & "'")
            c.Close()
        End If
    End Sub
    Public Shared Function ListBloques(ByVal idJunta As String, ByVal idComision As Integer) As DataTable
        Dim c As New ACCESO.Conexion
        Dim dt As New DataTable
        If (c.Connect) Then
            dt = c.Query("select b.iIdBloqueRiego ,b.vNombre from invBloqueComision bc,invBloqueRiego  b where bc.iIdBloqueRiego=b.iIdBloqueRiego and bc.vIdJuntaBloque=b.vIdJuntaUsuario and bc.vIdJuntaBloque='" & idJunta & "' and bc.iIdComisionRegante='" & idComision & "'")
            c.Close()
        End If
        Return dt
    End Function
End Class
