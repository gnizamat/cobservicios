Imports System.IO
Imports System.Windows.Forms
Imports System.Data.SqlServerCe
Imports System.Data.SqlClient
Imports System.Text
Imports ErikEJ.SqlCe
Public Class ConexionSqlCe
    Private _path As String
    Private _sqlconnection As SqlCeConnection
    Private _strSqlConnection As String
    Public Property sqlConnection()
        Get
            Return Me._sqlconnection
        End Get
        Set(ByVal value)
            Me._sqlconnection = value
        End Set
    End Property
    Public Property path()
        Get
            Return Me._path
        End Get
        Set(ByVal value)
            Me._path = value
        End Set
    End Property
    Public Property strConnection()
        Get
            Return Me._strSqlConnection
        End Get
        Set(ByVal value)
            Me._strSqlConnection = value
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
            Me._strSqlConnection = "Data Source=" & Me._path & ";Max Database Size = 1024;"
            Me._sqlconnection = New SqlCeConnection(Me._strSqlConnection)
            Me._sqlconnection.Open()
            Return True
        Catch ex As Exception
            Return (False)
        End Try

    End Function
    Public Function Query(ByVal strQuery As String) As DataTable
        Dim dt As New DataTable
        Try
            Dim dbDataAdapter As New SqlCeDataAdapter(strQuery, Me._strSqlConnection)
            dbDataAdapter.Fill(dt)
        Catch ex As Exception
            'Me._error = True
            'Me._msgError = "Error mientras se realizaba la consulta" & vbCrLf & ex.Message
        End Try
        Return dt
    End Function
    Public Sub CopyfromDataset(ByVal ds As DataSet, ByVal table As String)

        Try

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
                    If (r.Item(i) Is System.DBNull.Value) Then
                        strValues &= "NULL,"
                    Else
                        Select Case ds.Tables(table).Columns(i).DataType.Name
                            Case "DateTime"
                                Dim d As New Date
                                d = r.Item(i).ToString.Substring(0, 10)
                                strValues &= "'" & d.ToString("yyyyMMdd hh:mm:ss") & "',"
                            Case Else
                                strValues &= "'" & r.Item(i).ToString & "',"
                        End Select


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
    Public Sub BulkCopy(ByVal dt As DataTable, ByVal tabla As String)

        Dim sqlceopt As New ErikEJ.SqlCe.SqlCeBulkCopyOptions
        sqlceopt = SqlCeBulkCopyOptions.KeepNulls
        Dim sqlce As New ErikEJ.SqlCe.SqlCeBulkCopy(Me._sqlconnection, sqlceopt)
        sqlce.DestinationTableName = tabla
        sqlce.WriteToServer(dt)
    End Sub
    Public Sub CopyfromDatasetBGW(ByRef bgw As System.ComponentModel.BackgroundWorker, ByVal ds As DataSet, ByVal table As String)

        Try

            Dim cols = ds.Tables(table).Columns.Count
            Dim filas = ds.Tables(table).Rows.Count
            Dim strinCols As String = ""
            Dim strQuery As String = ""
            Dim strValues As String = ""
            Dim progreso As Integer = 0
            bgw.ReportProgress(ds.Tables(table).Rows.Count)
            For Each col As DataColumn In ds.Tables(table).Columns
                strinCols &= col.ColumnName & ","
            Next
            strinCols = strinCols.Substring(0, strinCols.Length - 1)
            For Each r As DataRow In ds.Tables(table).Rows
                strValues = ""
                For i = 0 To cols - 1
                    If (r.Item(i) Is System.DBNull.Value) Then
                        strValues &= "NULL,"
                    Else
                        Select Case ds.Tables(table).Columns(i).DataType.Name
                            Case "DateTime"
                                Dim d As New Date
                                d = r.Item(i).ToString.Substring(0, 10)
                                strValues &= "'" & d.ToString("yyyyMMdd hh:mm:ss") & "',"
                            Case Else
                                strValues &= "'" & r.Item(i).ToString & "',"
                        End Select


                    End If

                Next
                strValues = strValues.Substring(0, strValues.Length - 1)
                strQuery = "insert into " & table & "(" & strinCols & ") values(" & strValues & ")"

                Dim m = Me._sqlconnection.CreateCommand()
                'actualizo mis parametros
                m.CommandText = strQuery
                Dim reader = m.ExecuteReader()
                progreso += 1
                bgw.ReportProgress(progreso)
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Public Sub Close()
        Me._sqlconnection.Close()
    End Sub
End Class
