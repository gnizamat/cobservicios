Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Data.OleDb
Imports ACCESO
Imports LOGICA

Public Class clsControlHidrometrico
    Private _vIdJas As Integer
    Private _idEstructura As Integer
    Private _idLectura As Integer
    Private _iAnioTarifa As Integer
    Private _idMes As Integer
    Private _dFechaRegistro As Date
    Private _dFechaLectura As Date
    Private _vHoraIni As String
    Private _vHoraFin As String
    Private _vTotalHoras As String
    Private _DuracionBombeo As Integer
    Private _fLecturaIni As Double
    Private _fLecturaFin As Double
    Private _fVolumenTotal As Double
    Private _fCloroIni As Double
    Private _fCloroFin As Double
    Private _vReferencia As String
    Private _vUsuario As String

    Public Property Estructura()
        Get
            Return Me._idEstructura
        End Get
        Set(ByVal value)
            Me._idEstructura = value
        End Set
    End Property
    Public Property idlectura()
        Get
            Return Me._idLectura
        End Get
        Set(ByVal value)
            Me._idLectura = value
        End Set
    End Property
    Public Property anio()
        Get
            Return Me._iAnioTarifa
        End Get
        Set(ByVal value)
            Me._iAnioTarifa = value
        End Set
    End Property
    Public Property Mes()
        Get
            Return Me._idMes
        End Get
        Set(ByVal value)
            Me._idMes = value
        End Set
    End Property
    Public Property Usuario()
        Get
            Return Me._vUsuario
        End Get
        Set(ByVal value)
            Me._vUsuario = value
        End Set
    End Property
    Public Property FechaRegistro()
        Get
            Return Me._dFechaRegistro
        End Get
        Set(ByVal value)
            Me._dFechaRegistro = value
        End Set
    End Property
    Public Property FechaActual()
        Get
            Return Me._dFechaLectura
        End Get
        Set(ByVal value)
            Me._dFechaLectura = value
        End Set
    End Property
    Public Property horai()
        Get
            Return Me._vHoraIni
        End Get
        Set(ByVal value)
            Me._vHoraIni = value
        End Set
    End Property
    Public Property horaf()
        Get
            Return Me._vHoraFin
        End Get
        Set(ByVal value)
            Me._vHoraFin = value
        End Set
    End Property
    Public Property horas()
        Get
            Return Me._vTotalHoras
        End Get
        Set(ByVal value)
            Me._vTotalHoras = value
        End Set
    End Property
    Public Property duracion()
        Get
            Return Me._DuracionBombeo
        End Get
        Set(ByVal value)
            Me._DuracionBombeo = value
        End Set
    End Property
    Public Property lecturai()
        Get
            Return Me._fLecturaIni
        End Get
        Set(ByVal value)
            Me._fLecturaIni = value
        End Set
    End Property
    Public Property lecturaf()
        Get
            Return Me._fLecturaFin
        End Get
        Set(ByVal value)
            Me._fLecturaFin = value
        End Set
    End Property
    Public Property volumen()
        Get
            Return Me._fVolumenTotal
        End Get
        Set(ByVal value)
            Me._fVolumenTotal = value
        End Set
    End Property
    Public Property cloroi()
        Get
            Return Me._fCloroIni
        End Get
        Set(ByVal value)
            Me._fCloroIni = value
        End Set
    End Property
    Public Property clorof()
        Get
            Return Me._fCloroFin
        End Get
        Set(ByVal value)
            Me._fCloroFin = value
        End Set
    End Property
    Public Property Referencia()
        Get
            Return Me._vReferencia
        End Get
        Set(ByVal value)
            Me._vReferencia = value
        End Set
    End Property
    Public Property UsuarioSys()
        Get
            Return Me._vUsuario
        End Get
        Set(ByVal value)
            Me._vUsuario = value
        End Set
    End Property
    Private Function NewId()
        Dim c As New ACCESO.Conexion
        Dim dt As New DataTable
        Dim id As Integer
        If (c.Connect) Then
            dt = c.Query("select isNull(max(idLectura),0) from ControlHidrometrico where iAnioTarifa='" & anio & "'")
            c.Close()
            id = dt.Rows(0).Item(0) + 1
        End If
        Return id
    End Function
    Public Shared Function List(ByVal Estructura As Integer, ByVal anio As Integer, ByVal mes As Integer) As DataTable
        Try
            Dim dt As New DataTable
            Dim c As New ACCESO.Conexion
            Dim SQLTEXT As String
            If (c.Connect) Then
                SQLTEXT = " SELECT iIdEstructura, idLectura, iAnioTarifa, idMes,dFechaLectura, vhoraIni, vHoraFin, vHoraDiferencia, DuracionBombeo, fLecturaIni, fLecturaFin, fVolumenM3, fCloroIni, fCloroFin, vUsuario " _
                & " FROM ControlHidrometrico " _
                & " WHERE ControlHidrometrico.iIdEstructura = " & Estructura & "  AND ControlHidrometrico.iAnioTarifa = " & anio & " AND ControlHidrometrico.idMes = " & mes & ""
                dt = c.Query(SQLTEXT)
                c.Close()
            End If
            Return dt
        Catch ex As Exception

        End Try
    End Function

    Public Function Insert(ByVal vIdJas As String, ByVal idEstructura As Integer, ByVal idLectura As Integer, ByVal anio As Integer, ByVal idmes As Integer, ByVal FECHA As Date, ByVal usuario As String) As Boolean
        Dim cmd As New SqlCommand()
        Dim c As New ACCESO.Conexion
        Me._idLectura = Me.NewId
        If (c.Connect) Then
            cmd.CommandText = "INSERT INTO ControlHidrometrico (vIdJas,iIdEstructura,idLectura, iAnioTarifa,idMes,dFechaRegistro,dFechaLectura, vHoraIni,vHoraFin,vHoraDiferencia,DuracionBombeo,fLecturaIni,fLecturaFin,fVolumenM3,fCloroIni,fCloroFin,vReferencia, vUsuario)" _
                            & " VALUES(@IDJAS, @IDESTRUCTURA,@IDLECTURA,@ANIO,@MES,@DFECHA,@DFECHACTUAL,@HORAI,@HORAF,@HORAB,@DURACION,@LECTURAI,@LECTURAF,@VOLUMEN,@CLOROI,@CLOROF,@REFERENCIA,@USUARIO)"
            cmd.Parameters.AddWithValue("@IDJAS", vIdJas)
            cmd.Parameters.AddWithValue("@IDESTRUCTURA", idEstructura)
            cmd.Parameters.AddWithValue("@IDLECTURA", _idLectura)
            cmd.Parameters.AddWithValue("@ANIO", anio)
            cmd.Parameters.AddWithValue("@MES", idmes)
            cmd.Parameters.AddWithValue("@DFECHA", ACCESO.Conexion.getDateServer)
            cmd.Parameters.AddWithValue("@DFECHACTUAL", FECHA)
            cmd.Parameters.AddWithValue("@HORAI", Me._vHoraIni)
            cmd.Parameters.AddWithValue("@HORAF", Me._vHoraFin)
            cmd.Parameters.AddWithValue("@HORAB", Me._vTotalHoras)
            cmd.Parameters.AddWithValue("@DURACION", Me._DuracionBombeo)
            cmd.Parameters.AddWithValue("@LECTURAI", Me._fLecturaIni)
            cmd.Parameters.AddWithValue("@LECTURAF", Me._fLecturaFin)
            cmd.Parameters.AddWithValue("@VOLUMEN", Me._fVolumenTotal)
            cmd.Parameters.AddWithValue("@CLOROI", Me._fCloroIni)
            cmd.Parameters.AddWithValue("@CLOROF", Me._fCloroFin)
            cmd.Parameters.AddWithValue("@REFERENCIA", Me._vReferencia)
            cmd.Parameters.AddWithValue("@USUARIO", Me._vUsuario)
            c.IniTransaction()
            If (c.Insert(cmd) = False) Then
                MsgBox(c.msgError)
            Else
                MsgBox("Lectura Registrada Satisfactoriamente", MsgBoxStyle.Information)

            End If
            If (Not c.myError) Then
                c.Commit()
                'MsgBox("Facturación Generada para el mes de " & Idmes & " del año " & Idaño & "  Satisfactoriamente", MsgBoxStyle.Information)
                Return True
            Else
                c.RollBack()
                'MsgBox("Ocurrio un error mientras se generaba la facturación. Se cancelo el proceso de Importación", MsgBoxStyle.Critical)
                Return False
            End If
        End If
    End Function

    Public Shared Function delete(ByVal idestructura, ByVal idlectura, ByVal anio) As Boolean
        Dim c As New ACCESO.Conexion

        If (c.Connect) Then
            If (c.Delete("delete  from ControlHidrometrico  where iIdEstructura=" & idestructura & "  and idLectura= " & idlectura & " AND  iAnioTarifa=" & anio & "")) Then

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
