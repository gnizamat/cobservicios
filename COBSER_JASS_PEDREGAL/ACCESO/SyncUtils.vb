Public Class SyncUtils
    Shared _ScopeName As String
    Shared _SyncAdapterTables() As String
    Shared _SyncAdapterTablePrimaryKeys() As String
    Shared _TombstoneAgingInHours As Integer
    Public Shared Property ScopeName()
        Get
            Return _ScopeName
        End Get
        Set(ByVal value)
            _ScopeName = value
        End Set
    End Property
    Public Shared Property SyncAdapterTables()
        Get
            Return _SyncAdapterTables
        End Get
        Set(ByVal value)
            _SyncAdapterTables = value
        End Set
    End Property
    Public Shared Property SyncAdapterTablePrimaryKeys()
        Get
            Return _SyncAdapterTablePrimaryKeys
        End Get
        Set(ByVal value)
            _SyncAdapterTablePrimaryKeys = value
        End Set
    End Property
    Public Shared Property TombstoneAgingInHours()
        Get
            Return _TombstoneAgingInHours
        End Get
        Set(ByVal value)
            _TombstoneAgingInHours = value
        End Set
    End Property
End Class
