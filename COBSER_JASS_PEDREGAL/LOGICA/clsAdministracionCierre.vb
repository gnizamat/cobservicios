Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports ACCESO

Public Class clsAdministracionCierre
    Dim _ianio As Integer
    Dim _sIdJuntaUsuario As String
    Dim _iIdComisionRegante As Integer

    Public Property Anio()
        Get
            Return Me._ianio
        End Get
        Set(ByVal value)
            Me._ianio = value
        End Set
    End Property
    Public Property IdJunta()
        Get
            Return Me._sIdJuntaUsuario
        End Get
        Set(ByVal value)
            Me._sIdJuntaUsuario = value
        End Set
    End Property
    Public Property IdComision()
        Get
            Return Me._iIdComisionRegante
        End Get
        Set(ByVal value)
            Me._iIdComisionRegante = value
        End Set
    End Property

    Public Shared Function List(Optional ByVal condicion As String = "") As DataTable
        Dim dt As New DataTable
        Dim c As New ACCESO.Conexion
        If (c.Connect) Then
            dt = c.Query("SELECT * FROM dbo.view_AdministracionCierre " & condicion)
            c.Close()
        End If
        Return dt
    End Function

    Public Shared Sub LoadCheckedList(ByRef cmb As Windows.Forms.CheckedListBox, Optional ByVal condicion As String = "")
        Dim c As New ACCESO.Conexion
        Dim i As Integer
        If c.Connect Then
            Dim dt = c.Query("SELECT * FROM dbo.view_AdministracionCierre " & condicion)
            cmb.DataSource = dt
            cmb.ValueMember = dt.Columns(0).ToString()
            cmb.DisplayMember = dt.Columns(1).ToString()
            cmb.Text = ""
            For i = 0 To cmb.Items.Count - 1
                cmb.CheckOnClick = True
                cmb.SetItemChecked(i, True)
            Next
            If cmb.Items.Count <> 0 Then
                cmb.SelectedIndex = 0
            Else
                cmb.SelectedIndex = -1
            End If

            c.Close()
        End If
    End Sub
End Class
