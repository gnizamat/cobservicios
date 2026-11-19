Imports System.Data.SqlClient
Public Class sysOperacion
    Private _id As DateTime
    Private _tipo As String
    Private _idGrupo As Integer
    Private _usuario As String
    Private _msg As String
    Private _tabla As String
    Sub New(ByVal tipo As String, ByVal idgrupo As Integer, ByVal usuario As String, Optional ByVal tabla As String = "", Optional ByVal mensaje As String = "")
        Me._tipo = tipo
        Me._idGrupo = idgrupo
        Me._usuario = usuario
        Me._msg = mensaje
        Me._tabla = tabla
    End Sub
    Public Sub Insert()
        Dim cmd As New SqlCommand()
        Dim c As New ACCESO.Conexion
        If (c.Connect) Then
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "sp_sysOperacion_insert"
            cmd.Parameters.AddWithValue("@TIPO", Me._tipo)
            cmd.Parameters.AddWithValue("@IDGRUPO", Me._idGrupo)
            cmd.Parameters.AddWithValue("@USUARIO", Me._usuario)
            cmd.Parameters.AddWithValue("@MENSAJE", Me._msg)
            cmd.Parameters.AddWithValue("@TABLA", Me._tabla)
            If (c.Insert(cmd) = False) Then
                MsgBox(c.msgError)
            End If
            c.Close()
        End If
    End Sub
    Public Shared Function ListUltimasOperaciones(ByVal tabla As String, Optional ByVal allTipo As Boolean = True, Optional ByVal tipo As String = "") As DataTable
        Dim c As New ACCESO.Conexion
        Dim dt As New DataTable
        Dim condicion As String = ""
        If (c.Connect) Then
            If (Not allTipo) Then
                condicion = " and vTipo='" & tipo & "'"
            End If
            dt = c.Query("select dIdOperacion,vMensaje,vIdUsuario from sysOperacion WHERE dIdOperacion>=DATEADD( Minute,-1,GETDATE()) and vTabla='" & tabla & "' " & condicion & " order by dIdOperacion desc")
            c.Close()
        End If
        Return dt
    End Function
End Class
