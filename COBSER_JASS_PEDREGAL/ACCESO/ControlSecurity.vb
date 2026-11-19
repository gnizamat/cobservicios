Public Class ControlSecurity
    Private _msgError As String
    Private c As ACCESO.Conexion
    Private _ScriptInvalid As String
    Public Function controlString(ByVal str As String) As String
        'Dim sentencia As String
        'Dim sentencias() As String = {"SELECT", "UPDATE", "DELETE", "DROP", "TABLE", ";", "--", "/*", "*/"}
        'str = str.ToUpper()
        'For Each sentencia In sentencias
        ' If (str.Contains(sentencia)) Then
        'str.Replace(sentencia, "")
        'Me._msgError = "Parece que esta intentando usar valores que podrian causar daños en el sistema"
        'c.Query("insert into sysSecurity(user,sentencia) values('&str&') ")
        ' End If
        ' Next
        Return str
    End Function
    Public Shared Function ExistScriptInvalid(ByVal str As String) As Boolean
        Dim sentencia As String = ""
        Dim flagInvalid As Boolean = False
        Dim sentencias() As String = {"TRUNCATE ", "DELETE ", "DROP ", "TABLE "}
        str = str.ToUpper()
        For Each sentencia In sentencias
            If (str.Contains(sentencia)) Then
                flagInvalid = True
                'c.Query("insert into sysSecurity(user,sentencia) values('&str&') ")
            End If
        Next
        Return flagInvalid
    End Function

    Public Shared Function ExistSQLInyection(ByVal str As String) As Boolean
        Dim sentencia As String = ""
        Dim flagInvalid As Boolean = False
        Dim sentencias() As String = {"TRUNCATE ", "DELETE ", "DROP ", "TABLE ", "SELECT ", "*", "UPDATE ", "DATABASE", "WHERE", "ALTER ", "EXECUTE ", "'", "--", ";"}
        str = str.ToUpper()
        For Each sentencia In sentencias
            If (str.Contains(sentencia)) Then
                flagInvalid = True
                'c.Query("insert into sysSecurity(user,sentencia) values('&str&') ")
            End If
        Next
        Return flagInvalid
    End Function
End Class
