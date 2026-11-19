Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports ACCESO
Public Class clsAsambleas
    Private _id As Integer
    Private _Descripcion As String
    Private _anio As Integer
    Private _cEstado As String
    Private _TipoAsamblea As String
    Private _ambito As String
    Private _idJas As String
    Private _idCP As Integer
    Private _fecha As String

    Public Property id()
        Get
            Return Me._id
        End Get
        Set(ByVal value)
            Me._id = value
        End Set
    End Property
    Public Property Descripcion()
        Get
            Return Me._Descripcion
        End Get
        Set(ByVal value)
            Me._Descripcion = value
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
    Public Property cestado()
        Get
            Return Me._cEstado
        End Get
        Set(ByVal value)
            Me._cEstado = value
        End Set
    End Property
    
    Public Property TipoAsamblea()
        Get
            Return Me._TipoAsamblea
        End Get
        Set(ByVal value)
            Me._TipoAsamblea = value
        End Set
    End Property
    Public Property Ambito()
        Get
            Return Me._ambito
        End Get
        Set(ByVal value)
            Me._ambito = value
        End Set
    End Property
    

    Public Property idJAS()
        Get
            Return Me._idJas
        End Get
        Set(ByVal value)
            Me._idJas = value
        End Set
    End Property

    Public Property idcp()
        Get
            Return Me._idCP
        End Get
        Set(ByVal value)
            Me._idCP = value
        End Set
    End Property
    Public Property fecha()
        Get
            Return Me._fecha
        End Get
        Set(ByVal value)
            Me._fecha = value
        End Set
    End Property

    Sub New(ByVal id As Integer, ByVal Descripcion As String, ByVal anio As String, ByVal estado As Char, ByVal TipoAsamblea As Integer, ByVal ambito As Integer, ByVal idJas As String, ByVal idCP As Integer, ByVal fecha As String)
        Me._id = id
        Me._Descripcion = Descripcion
        Me._anio = anio
        Me._cEstado = "1"
        Me._TipoAsamblea = TipoAsamblea
        Me._ambito = ambito
        Me._idJas = idJas
        Me._idCP = idCP
        'Me._idComision = idcomision
        Me._fecha = fecha
        ' Dim P As New clsAsambleas(txtDescripcion.Text, txtAnio.Text, "1", tipoa, ambito, cmbJunta.SelectedValue, cmbCPoblado.SelectedValue, " ")
    End Sub

    Private Function NewId()
        Dim c As New ACCESO.Conexion
        Dim dt As New DataTable
        Dim id As Integer
        If (c.Connect) Then
            dt = c.Query("select isNull(max(iIdAsamblea),0) from padAsamblea WHERE  idCP='" & idcp & "'")
            id = dt.Rows(0).Item(0) + 1
            c.Close()
        End If
        Return id
    End Function
    Public Shared Function List(Optional ByVal condicion As String = "") As DataTable
        Dim dt As New DataTable
        Dim c As New ACCESO.Conexion
        If (c.Connect) Then
            'dt = c.Query("SELECT * FROM padAsamblea " & condicion)
            dt = c.Query("SELECT iIdAsamblea, vDescripcion, iAnio, cEstado, iIdTipo, cAmbito, vIdJas, idCP, dFechaH,CASE WHEN (padAsamblea.cAmbito=0) THEN 'PRINCIPAL' ELSE 'ANEXO' END AS AMBITO,CASE WHEN (padAsamblea.iIdTipo=0) THEN 'ORDINARIA' ELSE 'ESTRAORDINARIA' END AS TIPO,case padAsamblea.cEstado when '1' then  'ACTIVADO' when '0' then 'DESACTIVADO' end Estado FROM padAsamblea " & condicion)
            c.Close()
        End If
        Return dt
    End Function

    Public Function Insert() As Boolean
        Dim cmd As New SqlCommand()
        Dim c As New ACCESO.Conexion
        Me._id = Me.NewId
        If (c.Connect) Then
            If (c.msgError = "") Then
                cmd.CommandText = "INSERT INTO padAsamblea (iIdAsamblea,vDescripcion,iAnio,cEstado,iIdTipo,cAmbito,vIdJas,idCP,dFechaH)  VALUES (@ID,@DESCRIPCION,@ANIO,@ESTADO,@TIPOA,@AMBITO,@IDJAS,@IDCP, @FECHAD)"
                cmd.Parameters.AddWithValue("@ID", Me._id)
                cmd.Parameters.AddWithValue("@DESCRIPCION", Me._Descripcion)
                cmd.Parameters.AddWithValue("@ANIO", Me._anio)
                cmd.Parameters.AddWithValue("@ESTADO", "0")
                cmd.Parameters.AddWithValue("@TIPOA", Me._TipoAsamblea)
                cmd.Parameters.AddWithValue("@AMBITO", Me._ambito)
                cmd.Parameters.AddWithValue("@IDJAS", Me._idJas)
                cmd.Parameters.AddWithValue("@IDCP", Me._idCP)
                cmd.Parameters.AddWithValue("@FECHAD", Me._fecha)
                If (c.Update(cmd) = False) Then
                    MsgBox(c.msgError)
                Else
                    MsgBox("Asamblea Registrada correctamente", MsgBoxStyle.Information)
                End If
            Else
                MsgBox(c.msgError, MsgBoxStyle.Critical)
            End If


            c.Close()
        End If
    End Function

    Public Function Update() As Boolean
        Dim cmd As New SqlCommand()
        Dim c As New ACCESO.Conexion
        If (c.Connect) Then
            cmd.CommandText = "UPDATE padAsamblea SET vDescripcion= @DESCRIPCION,iAnio=@ANIO, iIdTipo=@TIPOA, cAmbito=@AMBITO,dFechaH=@FECHAD WHERE iIdAsamblea=" & id & ""
            cmd.Parameters.AddWithValue("@ID", Me._id)
            cmd.Parameters.AddWithValue("@DESCRIPCION", Me._Descripcion)
            cmd.Parameters.AddWithValue("@ANIO", Me._anio)
            cmd.Parameters.AddWithValue("@TIPOA", Me._TipoAsamblea)
            cmd.Parameters.AddWithValue("@AMBITO", Me._ambito)
            cmd.Parameters.AddWithValue("@FECHAD", Me._fecha)
            If (c.Update(cmd) = False) Then
                MsgBox(c.msgError)

            End If
            c.Close()
        End If
    End Function

    Public Shared Function delete(ByVal id) As Boolean
        Dim c As New ACCESO.Conexion

        If (c.Connect) Then
            If (c.Delete("delete  from padAsamblea  where iIdAsamblea=" & id & " ")) Then
                c.Close()
                Return False
            End If
            c.Close()
        End If
        Return True
    End Function

    Public Shared Sub ActivaDesactiva(ByVal id As Integer, ByVal opt As Integer)
        Dim cmd As New SqlCommand()
        Dim c As New ACCESO.Conexion

        If (c.Connect) Then
            cmd.CommandText = "update padAsamblea set cEstado=" & opt & " WHERE iIdAsamblea=" & id & " "
            If (c.Update(cmd) = False) Then
                MsgBox(c.msgError)
            End If
            c.Close()
        End If
    End Sub
End Class
