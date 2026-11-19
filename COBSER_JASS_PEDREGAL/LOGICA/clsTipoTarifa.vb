Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports ACCESO
Public Class clsTipoTarifa
    Private _idJunta As String
    Private _idTipotarifa As Integer
    Private _vNombre As String
    Private _cEstado As Char
    Private _cTipo As Integer
    Public Property idJunta()
        Get
            Return Me._idJunta
        End Get
        Set(ByVal value)
            Me._idJunta = value
        End Set
    End Property
    Public Property idTipotarifa()
        Get
            Return Me._idTipotarifa
        End Get
        Set(ByVal value)
            Me._idTipotarifa = value
        End Set
    End Property
    Public Property vNombre()
        Get
            Return Me._vNombre
        End Get
        Set(ByVal value)
            Me._vNombre = value
        End Set
    End Property
    Public Property cEstado()
        Get
            Return Me._cEstado
        End Get
        Set(ByVal value)
            Me._cEstado = value
        End Set
    End Property
    Public Property cTipo()
        Get
            Return Me._cTipo
        End Get
        Set(ByVal value)
            Me._cTipo = value
        End Set
    End Property
    Sub New(ByVal junta As String, ByVal tipotarifa As Integer, ByVal nombre As String, ByVal estado As String, ByVal tipo As Integer)
        'Me._Anio = anio
        Me._idJunta = junta
        Me._idTipotarifa = tipotarifa
        Me._vNombre = nombre
        Me._cEstado = estado
        Me._cTipo = tipo
        'Me._idCP = idcp

    End Sub


    Public Shared Sub LoadCombo(ByRef cmb As Windows.Forms.ComboBox, Optional ByVal condicion As String = "")
        Dim c As New ACCESO.Conexion
        If (c.Connect()) Then
            'Dim dt = c.Query("SELECT iAnioTarifa,cUndRecaudacion,cModalidad,cCMConfig1 from tarTarifaAnual " & condicion & " order by iAnioTarifa desc")
            Dim dt = c.Query("SELECT tarTipoTarifa.iIdTipoTarifa, tarTipoTarifa.vIdJas, tarTipoTarifa.vNombre, tarCostoTarifa.iAnioTarifa, tarCostoTarifa.fValorTarifa, tarCostoTarifa.fMonto FROM tarTipoTarifa INNER JOIN tarCostoTarifa ON tarTipoTarifa.vIdJas = tarCostoTarifa.vIdJas AND tarTipoTarifa.iIdTipoTarifa = tarCostoTarifa.iIdTipoTarifa  " & condicion & " order by iAnioTarifa desc")
            cmb.DataSource = dt
            cmb.ValueMember = dt.Columns(0).ToString()
            cmb.DisplayMember = dt.Columns(2).ToString()
            cmb.Text = ""
            'cmb.SelectedIndex = -1
            c.Close()
        End If
    End Sub
    Public Shared Sub getTarifa(ByRef cmb As Windows.Forms.ComboBox, Optional ByVal condicion As String = "")
        Dim c As New ACCESO.Conexion
        If (c.Connect()) Then
            'Dim dt = c.Query("SELECT iAnioTarifa,cUndRecaudacion,cModalidad,cCMConfig1 from tarTarifaAnual " & condicion & " order by iAnioTarifa desc")
            Dim dt = c.Query("SELECT tarCostoTarifa.iAnioTarifa, tarTipoTarifa.vIdJas, tarTipoTarifa.vNombre, tarTipoTarifa.iIdTipoTarifa, tarCostoTarifa.fValorTarifa, tarCostoTarifa.fMonto FROM tarTipoTarifa INNER JOIN tarCostoTarifa ON tarTipoTarifa.vIdJas = tarCostoTarifa.vIdJas AND tarTipoTarifa.iIdTipoTarifa = tarCostoTarifa.iIdTipoTarifa  " & condicion & " order by iAnioTarifa desc")
            cmb.DataSource = dt
            cmb.ValueMember = dt.Columns(0).ToString()
            cmb.DisplayMember = dt.Columns(6).ToString()
            cmb.Text = ""
            cmb.SelectedIndex = -1
            c.Close()
        End If
    End Sub
    Public Shared Sub LoadComboVolumen(ByRef cmb As Windows.Forms.ComboBox, Optional ByVal condicion As String = "", Optional ByVal all As Boolean = False)
        Dim c As New ACCESO.Conexion
        Dim dt As New DataTable
        Try


            If (c.Connect()) Then
                'dt = c.Query("select iIdTipoTarifa,vNombre from tarTipoTarifa  WHERE cTipo=1 ")

                dt = c.Query("SELECT tarTipoTarifa.iIdTipoTarifa, tarTipoTarifa.vNombre, tarCostoTarifa.iAnioTarifa, tarCostoTarifa.fMonto FROM tarTipoTarifa INNER JOIN tarCostoTarifa ON tarTipoTarifa.vIdJas = tarCostoTarifa.vIdJas AND tarTipoTarifa.iIdTipoTarifa = tarCostoTarifa.iIdTipoTarifa WHERE(tarCostoTarifa.iAnioTarifa = " & condicion & ") AND (tarTipoTarifa.cTipo = 2) ORDER BY tarCostoTarifa.iAnioTarifa DESC")
                cmb.DataSource = dt
                If (all And dt.Rows.Count > 0) Then
                    Dim myNewRow As DataRow
                    myNewRow = dt.NewRow()

                End If
                cmb.ValueMember = dt.Columns(0).ToString()
                cmb.DisplayMember = dt.Columns(1).ToString()
                cmb.SelectionStart = 1

            End If
        Catch ex As Exception

        End Try
    End Sub
    Public Shared Sub LoadComboAlcantarillado(ByRef cmb As Windows.Forms.ComboBox, Optional ByVal condicion As String = "", Optional ByVal all As Boolean = False)
        Dim c As New ACCESO.Conexion
        Dim dt As New DataTable
        Try


            If (c.Connect()) Then
                'dt = c.Query("select iIdTipoTarifa,vNombre from tarTipoTarifa  WHERE cTipo=1 ")

                dt = c.Query("SELECT tarTipoTarifa.iIdTipoTarifa, tarTipoTarifa.vNombre, tarCostoTarifa.iAnioTarifa, tarCostoTarifa.fMonto FROM tarTipoTarifa INNER JOIN tarCostoTarifa ON tarTipoTarifa.vIdJas = tarCostoTarifa.vIdJas AND tarTipoTarifa.iIdTipoTarifa = tarCostoTarifa.iIdTipoTarifa WHERE(tarCostoTarifa.iAnioTarifa = " & condicion & ") AND (tarTipoTarifa.cTipo = 3) ORDER BY tarCostoTarifa.iAnioTarifa DESC")
                cmb.DataSource = dt
                If (all And dt.Rows.Count > 0) Then
                    Dim myNewRow As DataRow
                    myNewRow = dt.NewRow()
                End If
                cmb.ValueMember = dt.Columns(0).ToString()
                cmb.DisplayMember = dt.Columns(1).ToString()
                cmb.SelectionStart = 1

            End If
        Catch ex As Exception

        End Try
    End Sub
    Public Shared Sub LoadComboMedidor(ByRef cmb As Windows.Forms.ComboBox, Optional ByVal condicion As String = "", Optional ByVal all As Boolean = False)
        Dim c As New ACCESO.Conexion
        Dim dt As New DataTable
        Try


            If (c.Connect()) Then
                'dt = c.Query("select iIdTipoTarifa,vNombre from tarTipoTarifa  WHERE cTipo=1 ")

                dt = c.Query("SELECT tarTipoTarifa.iIdTipoTarifa, tarTipoTarifa.vNombre, tarCostoTarifa.iAnioTarifa, tarCostoTarifa.fMonto FROM tarTipoTarifa INNER JOIN tarCostoTarifa ON tarTipoTarifa.vIdJas = tarCostoTarifa.vIdJas AND tarTipoTarifa.iIdTipoTarifa = tarCostoTarifa.iIdTipoTarifa WHERE(tarCostoTarifa.iAnioTarifa = " & condicion & ") AND (tarTipoTarifa.cTipo = 4) ORDER BY tarCostoTarifa.iAnioTarifa DESC")
                cmb.DataSource = dt
                If (all And dt.Rows.Count > 0) Then
                    Dim myNewRow As DataRow
                    myNewRow = dt.NewRow()
                End If
                cmb.ValueMember = dt.Columns(0).ToString()
                cmb.DisplayMember = dt.Columns(1).ToString()
                cmb.SelectionStart = 1

            End If
        Catch ex As Exception

        End Try
    End Sub


    Public Shared Sub LoadComboFijos(ByRef cmb As Windows.Forms.ComboBox, Optional ByVal condicion As String = "", Optional ByVal all As Boolean = False)
        Dim c As New ACCESO.Conexion
        Dim dt As New DataTable
        Try

     
            If (c.Connect()) Then
                'dt = c.Query("select iIdTipoTarifa,vNombre from tarTipoTarifa  WHERE cTipo=1 ")

                dt = c.Query("SELECT tarTipoTarifa.iIdTipoTarifa, tarTipoTarifa.vNombre, tarCostoTarifa.iAnioTarifa, tarCostoTarifa.fMonto FROM tarTipoTarifa INNER JOIN tarCostoTarifa ON tarTipoTarifa.vIdJas = tarCostoTarifa.vIdJas AND tarTipoTarifa.iIdTipoTarifa = tarCostoTarifa.iIdTipoTarifa WHERE(tarCostoTarifa.iAnioTarifa = " & condicion & ") AND (tarTipoTarifa.cTipo = 0) ORDER BY tarCostoTarifa.iAnioTarifa DESC")
                cmb.DataSource = dt
                If (all And dt.Rows.Count > 0) Then
                    Dim myNewRow As DataRow
                    myNewRow = dt.NewRow()

                End If
                cmb.ValueMember = dt.Columns(0).ToString()
                cmb.DisplayMember = dt.Columns(1).ToString()
                cmb.SelectionStart = 1

            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Shared Sub LoadComboTodos(ByRef cmb As Windows.Forms.ComboBox, Optional ByVal condicion As String = "", Optional ByVal all As Boolean = False)
        Dim c As New ACCESO.Conexion
        Dim dt As New DataTable
        If (c.Connect()) Then
            dt = c.Query("select iIdTipoTarifa,vNombre from tarTipoTarifa ORDER BY tarTipoTarifa.iIdTipoTarifa ASC ")
            cmb.DataSource = dt
            If (all And dt.Rows.Count > 0) Then
                Dim myNewRow As DataRow
                myNewRow = dt.NewRow()

            End If
            cmb.ValueMember = dt.Columns(0).ToString()
            cmb.DisplayMember = dt.Columns(1).ToString()
            cmb.SelectionStart = 1

        End If
    End Sub
    Public Shared Sub LoadComboTodosyMora(ByRef cmb As Windows.Forms.ComboBox, Optional ByVal condicion As String = "", Optional ByVal all As Boolean = False)
        Dim c As New ACCESO.Conexion
        Dim dt As New DataTable
        If (c.Connect()) Then
            dt = c.Query("select iIdTipoTarifa,vNombre from tarTipoTarifa ORDER BY tarTipoTarifa.iIdTipoTarifa ASC ")
            cmb.DataSource = dt
            'If (all And dt.Rows.Count > 0) Then
            '    Dim myNewRow As DataRow
            '    myNewRow = dt.NewRow()

            'End If
            If (dt.Rows.Count > 0) Then
                dt.Rows.Add(0, "MORAS")
            End If
            cmb.DataSource = dt
            cmb.ValueMember = dt.Columns(0).ToString()
            cmb.DisplayMember = dt.Columns(1).ToString()
            cmb.Text = ""
            'cmb.SelectedIndex = -1
            c.Close()

        End If
    End Sub


    Public Shared Sub LoadComboUnicas(ByRef cmb As Windows.Forms.ComboBox, Optional ByVal condicion As String = "", Optional ByVal all As Boolean = False)
        Dim c As New ACCESO.Conexion
        Dim dt As New DataTable
        If (c.Connect()) Then
            'dt = c.Query("select iIdTipoTarifa,vNombre from tarTipoTarifa  WHERE cTipo=2 " & condicion)

            dt = c.Query("SELECT tarTipoTarifa.iIdTipoTarifa, tarTipoTarifa.vIdJas, tarTipoTarifa.vNombre, tarCostoTarifa.iAnioTarifa, tarCostoTarifa.fValorTarifa, tarCostoTarifa.fMonto FROM tarTipoTarifa INNER JOIN tarCostoTarifa ON tarTipoTarifa.vIdJas = tarCostoTarifa.vIdJas AND tarTipoTarifa.iIdTipoTarifa = tarCostoTarifa.iIdTipoTarifa  WHERE cTipo=1 " & condicion & " order by iAnioTarifa desc")
            cmb.DataSource = dt
            If (all And dt.Rows.Count > 0) Then
                Dim myNewRow As DataRow
                myNewRow = dt.NewRow()

            End If
            cmb.ValueMember = dt.Columns(0).ToString()
            cmb.DisplayMember = dt.Columns(2).ToString()
            cmb.SelectionStart = 1

        End If
    End Sub
    Public Shared Function List(Optional ByVal condicion As String = "") As DataTable
        Dim dt As New DataTable
        Dim c As New ACCESO.Conexion
        If (c.Connect) Then
            dt = c.Query("SELECT vIdJas, iIdTipoTarifa, vNombre, cEstado,  CASE dbo.tarTipoTarifa.cTipo WHEN '0' THEN 'Mensual' WHEN '1' THEN 'Fijo'END AS Tipo, cTipo FROM tarTipoTarifa WHERE cEstado=1 ORDER BY Tipo DESC " & condicion)
            c.Close()
        End If
        Return dt
    End Function
    Private Function NewId()
        Dim c As New ACCESO.Conexion
        Dim dt As New DataTable
        Dim id As Integer
        If (c.Connect) Then
            dt = c.Query("select isNull(max(iIdTipoTarifa),0) from tarTipoTarifa")
            c.Close()
            id = dt.Rows(0).Item(0) + 1
        End If
        Return id
    End Function

    Public Function Insert() As Boolean
        Dim cmd As New SqlCommand()
        Dim c As New ACCESO.Conexion
        Me._idTipotarifa = Me.NewId
        If (c.Connect) Then

            If (c.msgError = "") Then
                cmd.CommandText = "INSERT INTO tarTipoTarifa ( vIdJas, iIdTipoTarifa, vNombre, cEstado, cTipo)  VALUES (@IDJAS, @TIPOTARIFA, @NOMBRE, @ESTADO, @TIPO)"
                cmd.Parameters.AddWithValue("@IDJAS", Me._idJunta)
                cmd.Parameters.AddWithValue("@TIPOTARIFA", Me._idTipotarifa)
                cmd.Parameters.AddWithValue("@NOMBRE", Me._vNombre)
                cmd.Parameters.AddWithValue("@ESTADO", Me._cEstado)
                cmd.Parameters.AddWithValue("@TIPO", Me._cTipo)
                If (c.Update(cmd) = False) Then
                    MsgBox(c.msgError)
                Else
                    MsgBox("Servicio Registrado correctamente", MsgBoxStyle.Information)
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
            cmd.CommandText = "UPDATE tarTipoTarifa SET vNombre=@NOMBRE, cTipo=@TIPO WHERE  iIdTipoTarifa=" & idTipotarifa & " "
            cmd.Parameters.AddWithValue("@IDJAS", Me._idJunta)
            cmd.Parameters.AddWithValue("@TIPOTARIFA", Me._idTipotarifa)
            cmd.Parameters.AddWithValue("@NOMBRE", Me._vNombre)
            cmd.Parameters.AddWithValue("@ESTADO", Me._cEstado)
            cmd.Parameters.AddWithValue("@TIPO", Me._cTipo)
            If (c.Update(cmd) = False) Then
                MsgBox(c.msgError)

            End If
            c.Close()
        End If
    End Function
End Class
