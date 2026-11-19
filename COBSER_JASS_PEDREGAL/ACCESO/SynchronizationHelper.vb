Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Data.SqlClient
Imports System.Data
Imports System.Data.SqlServerCe
Imports System.IO
Imports System.Windows.Forms
'Imports Microsoft.Synchronization
'Imports Microsoft.Synchronization.Data.SqlServerCe
'Imports Microsoft.Synchronization.Data
'Imports Microsoft.Synchronization.Data.SqlServer
Public Class SynchronizationHelper
    Private SyncUtils As SyncUtils
    Sub New(ByVal scope_name As String, ByVal tablas() As String, ByVal tablas_primary_keys() As String)
        Dim TombstoneAgingInHours As Integer = 10
        SyncUtils.ScopeName = scope_name
        SyncUtils.SyncAdapterTables = tablas 'tablas a agregar
        SyncUtils.SyncAdapterTablePrimaryKeys = tablas_primary_keys
        SyncUtils.TombstoneAgingInHours = TombstoneAgingInHours
    End Sub
    'Public Function ConfigureSqlSyncProvider(ByRef c As Conexion) As SqlSyncProvider
    '    Dim provider As SqlSyncProvider = New SqlSyncProvider()
    '    provider.ScopeName = SyncUtils.ScopeName

    '    Dim builder As SqlConnectionStringBuilder = New SqlConnectionStringBuilder()
    '    builder.DataSource = c.server
    '    builder.IntegratedSecurity = True
    '    builder.InitialCatalog = c.database
    '    builder.ConnectTimeout = 1
    '    provider.Connection = New SqlConnection(builder.ToString())

    '    'create a new scope description and add the appropriate tables to this scope
    '    Dim scopeDesc As DbSyncScopeDescription = New DbSyncScopeDescription(SyncUtils.ScopeName)

    '    'class to be used to provision the scope defined above
    '    Dim serverConfig As SqlSyncScopeProvisioning = New SqlSyncScopeProvisioning(scopeDesc)

    '    'determine if this scope already exists on the server and if not go ahead and provision

    '    If (Not serverConfig.ScopeExists(SyncUtils.ScopeName, c.conexion)) Then

    '        'add the approrpiate tables to this scope
    '        For Each tabla As String In SyncUtils.SyncAdapterTables
    '            scopeDesc.Tables.Add(SqlSyncDescriptionBuilder.GetDescriptionForTable(tabla, c.conexion))
    '        Next
    '        'note that it is important to call this after the tables have been added to the scope
    '        serverConfig.PopulateFromScopeDescription(scopeDesc)

    '        'indicate that the base table already exists and does not need to be created
    '        serverConfig.SetCreateTableDefault(DbSyncCreationOption.Skip)

    '        'provision the server
    '        serverConfig.Apply(c.conexion)
    '    End If

    '    Return provider
    'End Function

    'Public Function ConfigureCESyncProvider(ByRef ce As ConexionSqlCe) As SqlCeSyncProvider

    '    Dim provider As SqlCeSyncProvider = New SqlCeSyncProvider()
    '    'Set the scope name
    '    provider.ScopeName = SyncUtils.ScopeName
    '    'Set the connection.
    '    provider.Connection = ce.sqlConnection
    '    Return provider
    'End Function

    'Public Function SynchronizeProviders(ByRef c As Conexion, ByVal localProvider As RelationalSyncProvider, ByVal remoteProvider As RelationalSyncProvider) As SyncOperationStatistics

    '    Dim orchestrator As SyncOrchestrator = New SyncOrchestrator()
    '    orchestrator.LocalProvider = localProvider
    '    orchestrator.RemoteProvider = remoteProvider
    '    orchestrator.Direction = SyncDirectionOrder.UploadAndDownload

    '    'Check to see if any provider is a SqlCe provider and if it needs schema
    '    CheckIfProviderNeedsSchema(c, localProvider)
    '    'CheckIfProviderNeedsSchema(c, remoteProvider)

    '    Dim stats As SyncOperationStatistics = orchestrator.Synchronize()
    '    Dim metadataCleanup As SqlSyncStoreMetadataCleanup = New SqlSyncStoreMetadataCleanup(c.conexion)
    '    Dim cleanupSuccessful As Boolean
    '    metadataCleanup.RetentionInDays = 0
    '    cleanupSuccessful = metadataCleanup.PerformCleanup()
    '    Return stats
    'End Function
    'Private Sub CheckIfProviderNeedsSchema(ByRef c As Conexion, ByVal localProvider As SqlCeSyncProvider)

    'If (Not localProvider Is Nothing) Then

    '    Dim ceConn As SqlCeConnection = New SqlCeConnection(localProvider.Connection.ConnectionString)
    '    Dim ceConfig As SqlCeSyncScopeProvisioning = New SqlCeSyncScopeProvisioning()
    '    Dim scopeName As String = localProvider.ScopeName
    '    If (Not ceConfig.ScopeExists(scopeName, ceConn)) Then
    '        Dim scopeDesc As DbSyncScopeDescription = SqlSyncDescriptionBuilder.GetDescriptionForScope(SyncUtils.ScopeName, c.conexion)
    '        ceConfig.PopulateFromScopeDescription(scopeDesc)
    '        ceConfig.Apply(ceConn)
    '    End If
    'End If
    'End Sub

End Class
