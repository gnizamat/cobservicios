Imports System
Imports System.Windows.Forms
Imports System.Data.SqlClient
Public Class User
    Private _usuario As String
    Private _password As String
    Private _idGrupo As Integer
    Private _idInterfaz As Integer
    Private _nombres As String
    Private _apellidos As String
    Private _telefono As String
    Private _email As String
    Private _idRegion As Integer
    Private _idDistritoRiego As Integer
    Private _idJunta As String
    Private _idComision As Integer
    Private cs As New ControlSecurity
    Public Property nombres()
        Get
            Return Me._nombres
        End Get
        Set(ByVal value)
            Me._nombres = value
        End Set
    End Property
    Public Property apellidos()
        Get
            Return Me._apellidos
        End Get
        Set(ByVal value)
            Me._apellidos = value
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
    Public Property email()
        Get
            Return Me._email
        End Get
        Set(ByVal value)
            Me._email = value
        End Set
    End Property
    Public Property idRegion()
        Get
            Return Me._idRegion
        End Get
        Set(ByVal value)
            Me._idRegion = value
        End Set
    End Property
    Public Property idDistritoRiego()
        Get
            Return Me._idDistritoRiego
        End Get
        Set(ByVal value)
            Me._idDistritoRiego = value
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
    Public Property idComision()
        Get
            Return Me._idComision
        End Get
        Set(ByVal value)
            Me._idComision = value
        End Set
    End Property
    Public Property usuario()
        Get
            Return Me._usuario
        End Get
        Set(ByVal value)
            Me._usuario = cs.controlString(value)
        End Set
    End Property
    Public Property password()
        Get
            Return Me._password
        End Get
        Set(ByVal value)
            Me._password = value

        End Set
    End Property
    Public Property idGrupo()
        Get
            Return Me._idGrupo
        End Get
        Set(ByVal value)
            Me._idGrupo = value
        End Set
    End Property
    Public Property idInterfaz()
        Get
            Return Me._idInterfaz
        End Get
        Set(ByVal value)
            Me._idInterfaz = value
        End Set
    End Property
    Sub New(Optional ByVal idg As Integer = 0, Optional ByVal u As String = "", Optional ByVal p As String = "", Optional ByVal nombres As String = "", Optional ByVal apellidos As String = "", Optional ByVal telefono As String = "", Optional ByVal email As String = "")
        Me._usuario = cs.controlString(u)
        Me._password = getMd5Hash(p)
        Me._idGrupo = idg
        Me._nombres = nombres
        Me._apellidos = apellidos
        Me._telefono = telefono
        Me._email = email
    End Sub
    Public Function Validar() As Boolean
        Dim c As New ACCESO.Conexion
        Dim dt As New DataTable
        If (c.Connect) Then
            dt = c.Query("select * from sysUsuario where vIdUsuario='" & Me._usuario & "' and vPassword='" & Me._password & "' and idGrupo='" & Me._idGrupo & "'")
            c.Close()
            If (dt.Rows.Count > 0) Then
                Return True
            Else
                Return False
            End If
        End If
    End Function

    Public Function ValidarAdminJU() As Boolean
        Dim c As New ACCESO.Conexion
        Dim dt As New DataTable
        Dim sql As String
        If (c.Connect) Then
            'dt = c.Query("select * from sysUsuario where vIdUsuario='" & Me._usuario & "' and vPassword='" & Me._password & "' and idPGrupo='" & Me._idGrupo & "'")
            sql = "SELECT sysUsuario.idGrupo, sysUsuario.vIdUsuario, sysUsuario.vPassword, sysUsuario.vNombres, sysUsuario.vApellidos, sysUsuario.vTelefono, "
            sql = sql & " sysUsuario.vEmail,sysUsuario.cEstado FROM sysUsuario INNER JOIN sysGrupo ON sysUsuario.idGrupo = sysGrupo.idGrupo "
            sql = sql & " WHERE (sysUsuario.vIdUsuario = '" & Me._usuario & "') AND "
            sql = sql & " (sysUsuario.vPassword = '" & Me._password & "') AND "
            sql = sql & " (sysGrupo.idPGrupo = '" & Me._idGrupo & "') "
            dt = c.Query(sql)
            c.Close()
            If (dt.Rows.Count > 0) Then
                Return True
            Else
                Return False
            End If
        End If
    End Function

    Public Shared Function ExisteUsuario(ByVal usuario As String) As Boolean
        Dim c As New ACCESO.Conexion
        Dim dt As New DataTable

        If (c.Connect) Then
            dt = c.Query("select * from sysUsuario where vIdUsuario='" & usuario & "' ")
            c.Close()
            If (dt.Rows.Count > 0) Then
                Return True
            Else
                Return False
            End If
        End If
    End Function
    Public Function Insert() As Boolean
        Dim cmd As New SqlCommand()
        Dim c As New ACCESO.Conexion
        If (c.Connect) Then
            cmd.CommandText = "INSERT INTO sysUsuario (idGrupo,vIdUsuario,vNombres,vApellidos,vTelefono,vEmail,vPassword,cEstado) values(@IDGRUPO,@USUARIO,@NOMBRES,@APELLIDOS,@TELEFONO,@EMAIL,@PASSWORD,1)"
            cmd.Parameters.AddWithValue("@IDGRUPO", Me._idGrupo)
            cmd.Parameters.AddWithValue("@USUARIO", Me._usuario)
            cmd.Parameters.AddWithValue("@NOMBRES", Me._nombres)
            cmd.Parameters.AddWithValue("@APELLIDOS", Me._apellidos)
            cmd.Parameters.AddWithValue("@TELEFONO", Me._telefono)
            cmd.Parameters.AddWithValue("@EMAIL", Me._email)
            cmd.Parameters.AddWithValue("@PASSWORD", Me._password)

            If (c.Update(cmd) = False) Then
                MsgBox(c.msgError)
            End If
            c.Close()
        End If
    End Function
    Public Function Update() As Boolean
        Dim cmd As New SqlCommand()
        Dim c As New ACCESO.Conexion
        If (c.Connect) Then
            cmd.CommandText = "update sysUsuario set vNombres=@NOMBRES,vApellidos=@APELLIDOS,vTelefono=@TELEFONO,vEmail=@EMAIL where vIdUsuario='" & Me._usuario & "'"
            cmd.Parameters.AddWithValue("@NOMBRES", Me._nombres)
            cmd.Parameters.AddWithValue("@APELLIDOS", Me._apellidos)
            cmd.Parameters.AddWithValue("@TELEFONO", Me._telefono)
            cmd.Parameters.AddWithValue("@EMAIL", Me._email)
            c.Update(cmd)
            c.Close()
        End If
    End Function
    Public Function UpdatePassword(ByVal password As String) As Boolean
        Dim cmd As New SqlCommand()
        Dim c As New ACCESO.Conexion
        Me._password = password
        If (c.Connect) Then
            cmd.CommandText = "update sysUsuario set vPassword=@PASSWORD where vIdUsuario='" & Me._usuario & "'"
            cmd.Parameters.AddWithValue("@PASSWORD", password)
            c.Update(cmd)
            c.Close()
        End If
    End Function
    Public Shared Function List(Optional ByVal condicion As String = "") As DataTable
        Dim dt As New DataTable
        Try
            Dim c As New ACCESO.Conexion
            If (c.Connect) Then
                dt = c.Query("select vIdUsuario,g.idGrupo,g.vNombre,vNombres,vApellidos,vEmail,vTelefono from sysUsuario u,sysGrupo g where g.idGrupo=u.idGrupo and u.cEstado=1 " & condicion)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return dt
    End Function
    Public Shared Sub Delete(ByVal id As String)
        Dim cmd As New SqlCommand()
        Dim c As New ACCESO.Conexion
        If (c.Connect) Then
            cmd.CommandText = "update sysUsuario set cEstado=0 where vIdUsuario='" & id & "'"
            c.Update(cmd)
            c.Close()
        End If
    End Sub

End Class
