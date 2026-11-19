Imports System.Data.OleDb
Public Class ConexionAccess
    Private _database As String
    Private _password As String
    Private _strConexion As String
    Dim cn As OleDbConnection
    Sub New(ByVal bd As String, ByVal password As String)
        Me._database = bd
        Me._password = password
        Me._strConexion = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" & Me._database
    End Sub
    Public Function Connect()
        Dim flag As Boolean = True
        Try
            cn = New OleDbConnection(Me._strConexion)
            cn.Open()
        Catch ex As Exception
            flag = False
        End Try
        Return flag
    End Function
    Function Query(ByVal strQuery As String) As DataTable
        Dim dbDataAdapter As OleDbDataAdapter
        Dim dt As New DataTable
        dbDataAdapter = New OleDbDataAdapter(strQuery, cn)
        Dim commandBuilder As New OleDbCommandBuilder(dbDataAdapter)
        dbDataAdapter.Fill(dt)
        Return dt
    End Function
    Sub Close()
        cn.Close()
    End Sub
End Class
