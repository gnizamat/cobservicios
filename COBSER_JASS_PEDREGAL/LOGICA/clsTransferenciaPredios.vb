Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Data.OleDb
Imports ACCESO
Imports LOGICA
Public Class clsTransferenciaPredios
    Private idusu As Integer
    Private idpredio As Integer


    Public Function addUsuario(ByVal idpredio, ByVal idusuario, ByVal iidusuario) As Boolean
        Dim c As New ACCESO.Conexion
        Dim cmd As New SqlCommand()
        Dim dtfecha As Date = Date.Now
        If (c.Connect) Then
            cmd.CommandText = "UPDATE padUsuarioPredio set cEstado=0 where cEstado=1 and idPredio=" & idpredio & ""
            If (c.Update(cmd) = False) Then
                MsgBox(c.msgError)
            End If
            c.Close()
        End If
        Return False


    End Function

    Public Function InsertPrediot(ByVal vIdJas As String, ByVal idusuario As Integer, ByVal idpredio As Integer, ByVal idcorre As Integer, ByVal FECHA As Date) As Boolean
        Dim cmd As New SqlCommand()
        Dim c As New ACCESO.Conexion

        'Me._idMedidor = Me.NewId
        If (c.Connect) Then
            c.Query("UPDATE padUsuarioPredio set cEstado=0 where cEstado=1 and vIdJas='" & vIdJas & "' and idPredio='" & idpredio & "' ")
            cmd.CommandText = "INSERT INTO padUsuarioPredio(vIdJas,iIdUsuario,idPredio,iCorrelativo, dFechaRegistro,cEstado) values(@IDJAS,@IDUSUARIO,@IDPREDIO,1,@FINI,1)"
            cmd.Parameters.AddWithValue("@IDJAS", vIdJas)
            cmd.Parameters.AddWithValue("@IDUSUARIO", idusuario)
            cmd.Parameters.AddWithValue("@IDPREDIO", idpredio)
            'cmd.Parameters.AddWithValue("@IDCORRE", 1)
            cmd.Parameters.AddWithValue("@FINI", ACCESO.Conexion.getDatetimeServer)
            If (c.Insert(cmd) = False) Then
                MsgBox(c.msgError)
            End If
            c.Close()
        End If
    End Function

    Public Function getUsuarioActual() As clsTransferenciaPredios
        Dim prediot As New clsTransferenciaPredios
        Dim dt As New DataTable
        Dim c As New ACCESO.Conexion

        If (c.Connect) Then
            dt = c.Query("select iIdUsuario,idPredio from padUsuarioPredio where iIdPredio=" & idpredio & " cEstado=1")
            If (dt.Rows.Count > 0) Then
                prediot.idusu = Val(dt.Rows(0).Item("idUsuario").ToString)
                prediot.idpredio = dt.Rows(0).Item("idPredio").ToString
                'usuario.id = dt.Rows(0).Item("iCorrelativo").ToString
            End If
            c.Close()
        End If
        Return prediot


        'Return usuario
    End Function
End Class
