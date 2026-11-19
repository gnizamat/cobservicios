Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports ACCESO
Public Class clsTarias
    Private _cEstado As String
    Public Shared Function List(Optional ByVal condicion As String = "") As DataTable
        Dim dt As New DataTable
        Dim c As New ACCESO.Conexion
        If (c.Connect) Then
            dt = c.Query("SELECT iAnioTarifa, vIdJas, cModalidad, CASE tarTarifaAnual.cEstadoTarifa WHEN '0' THEN 'Inactiva' WHEN '1' THEN 'Activa' END AS Estado, vNombre FROM tarTarifaAnual " & condicion)
            c.Close()
        End If
        Return dt
    End Function
    Public Shared Sub LoadComboModalidad(ByRef cmb As Windows.Forms.ComboBox)
        Dim dt As New DataTable
        dt.Columns.Add("id")
        dt.Columns.Add("nombre")
        dt.Rows.Add(1, "Contraentrega")
        cmb.DataSource = dt
        cmb.ValueMember = dt.Columns(0).ToString()
        cmb.DisplayMember = dt.Columns(1).ToString()
        cmb.SelectedIndex = -1
    End Sub
    Public Shared Sub LoadComboUnidadRecaudacion(ByRef cmb As Windows.Forms.ComboBox)
        Dim dt As New DataTable
        dt.Columns.Add("id")
        dt.Columns.Add("nombre")
        dt.Rows.Add(1, "Soles por Metro Cúbico (S/.* m3)")
        cmb.ValueMember = dt.Columns(0).ToString()
        cmb.DisplayMember = dt.Columns(1).ToString()
        cmb.SelectedIndex = -1
    End Sub
    Public Function Insert(ByVal anio As String, ByVal vIdJas As String, ByVal modalidad As Integer, ByVal unidrecau As Integer, ByVal nombreanio As String) As Boolean
        Dim cmd As New SqlCommand()
        Dim c As New ACCESO.Conexion

        'Me._idMedidor = Me.NewId
        If (c.Connect) Then
            cmd.CommandText = "INSERT INTO tarTarifaAnual (iAnioTarifa,vIdJas,cModalidad, cUndRecaudacion, cEstadoTarifa, cCMConfig1, vNombre)" _
                            & " VALUES(@IDANIO, @IDJAS, @MODALIDAD,@UNIRECAU,@ESTADO,@CONFIG,@NOMBRE)"
            cmd.Parameters.AddWithValue("@IDANIO", anio)
            cmd.Parameters.AddWithValue("@IDJAS", vIdJas)
            cmd.Parameters.AddWithValue("@MODALIDAD", modalidad)
            cmd.Parameters.AddWithValue("@UNIRECAU", unidrecau)
            cmd.Parameters.AddWithValue("@ESTADO", 1)
            cmd.Parameters.AddWithValue("@CONFIG", 1) 'cmd.Parameters.AddWithValue("@FPAGO", DBNull.Value)
            cmd.Parameters.AddWithValue("@NOMBRE", nombreanio)
          
            c.IniTransaction()
            If (c.Insert(cmd) = False) Then
                MsgBox(c.msgError)
            End If
            If (Not c.myError) Then
                c.Commit()
                MsgBox("Año Registrado Satisfactoriamente", MsgBoxStyle.Information)
                Return True
            Else
                c.RollBack()
                MsgBox("Ocurrio un error", MsgBoxStyle.Critical)
                Return False
            End If

        End If
    End Function

    Public Function update_tarifa(ByVal anio) As Boolean
        Dim cmd As New SqlCommand()
        Dim c As New ACCESO.Conexion

        If (c.Connect) Then
            cmd.CommandText = " UPDATE tarTarifaAnual SET cEstadotarifa=0 WHERE tarTarifaAnual.iAnioTarifa < " & anio & " "
            If (c.Update(cmd) = False) Then
                MsgBox(c.msgError)
            End If
            c.Close()
        End If
        Return True
    End Function
    Public Shared Sub ActivarTarifa(ByVal idjunta As String, ByVal anio As Integer)
        Dim c As New ACCESO.Conexion
        Dim dt As New DataTable
        If (c.Connect) Then
            c.Query("UPDATE tarTarifaAnual set cEstadoTarifa='0' where vIdJas='" & idjunta & "'")
            c.Query("UPDATE tarTarifaAnual set cEstadoTarifa='1' where iAnioTarifa='" & anio & "' and vIdJas='" & idjunta & "' ")
            If (c.msgError <> "") Then
                MsgBox(c.msgError)
            End If
            c.Close()
        End If
    End Sub

    Public Shared Function delete(ByVal anio, ByVal idjas) As Boolean
        Dim c As New ACCESO.Conexion

        If (c.Connect) Then
            If (c.Delete("delete  from tarTarifaAnual  where  iAnioTarifa= " & anio & " and vIdJas='" & idjas & "' ")) Then

            Else
                MsgBox("No se puede elminar el registro porque existen datos vinculados al mismo", MsgBoxStyle.Critical)
                c.Close()
                Return False
            End If
            c.Close()
        End If
        Return True
    End Function

End Class
