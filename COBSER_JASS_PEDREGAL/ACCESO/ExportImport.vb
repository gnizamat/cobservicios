Imports System.IO
Imports System.Windows.Forms
Imports System.Data.SqlServerCe
Imports System.Data.SqlClient
Imports System.Text

Public Class ExportImport
    Private _path As String
    Private _sqlconnection As SqlCeConnection
    Public Property path()
        Get
            Return Me._path
        End Get
        Set(ByVal value)
            Me._path = value
        End Set
    End Property
    Public Sub CreateFile(ByVal ruta As String)
        Me._path = ruta
        Dim Source As String = Application.StartupPath & "\SISTEMA\SMA_DATA.sdf"
        Dim Destination As String = ruta
        System.IO.File.Copy(Source, Destination, True)
    End Sub
    Public Function Connect() As Boolean
        Try
            Me._sqlconnection = New SqlCeConnection("Data Source=" & Me._path & ";pwd=edink09")
            Me._sqlconnection.Open()
            Return True
        Catch ex As Exception
            Return (False)
        End Try

    End Function
    Public Sub CopyfromDataset(ByVal ds As DataSet, ByVal table As String)
        
        Try
            'Dim da As New SqlCeDataAdapter("select * from AperturaAnio", Me._sqlconnection)
            'Dim cb As New SqlCeCommandBuilder(da)
            'da.Update(ds, table)
            'ds.e()
            'Dim c As New ACCESO.Conexion
            'c.Connect()

            'Dim syncOrchestrator As SyncOrchestrator = New SyncOrchestrator()
            'syncOrchestrator.LocalProvider = New SqlSyncProvider("AperturaAnio", c.conexion, Nothing, "Sync")
            'syncOrchestrator.RemoteProvider = New SqlCeSyncProvider("AperturaAnio", Me._sqlconnection, "Sync")
            'syncOrchestrator.Direction = SyncDirectionOrder.UploadAndDownload
            'syncOrchestrator.Synchronize()


            Dim cols = ds.Tables(table).Columns.Count
            Dim filas = ds.Tables(table).Rows.Count
            Dim strinCols As String = ""
            Dim strQuery As String = ""
            Dim strValues As String = ""
            For Each col As DataColumn In ds.Tables(table).Columns
                strinCols &= col.ColumnName & ","
            Next
            strinCols = strinCols.Substring(0, strinCols.Length - 1)
            For Each r As DataRow In ds.Tables(table).Rows
                strValues = ""
                For i = 0 To cols - 1
                    If (ds.Tables(table).Columns(i).DataType.Name = "DateTime") Then

                        Dim d As New Date
                        d = r.Item(i).ToString.Substring(0, 10)
                        strValues &= "'" & d.ToString("yyyyMMdd hh:mm:ss") & "',"
                    Else
                        strValues &= "'" & r.Item(i).ToString & "',"
                    End If
                Next
                strValues = strValues.Substring(0, strValues.Length - 1)
                strQuery = "insert into " & table & "(" & strinCols & ") values(" & strValues & ")"

                Dim m = Me._sqlconnection.CreateCommand()
                'actualizo mis parametros
                m.CommandText = strQuery
                Dim reader = m.ExecuteReader()
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Public Sub Close()
        Me._sqlconnection.Close()
    End Sub
End Class
