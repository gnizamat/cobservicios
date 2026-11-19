

Partial Public Class SMA_DATADataSet
    Partial Class CalculoActividadFinancieraDataTable

        Private Sub CalculoActividadFinancieraDataTable_CalculoActividadFinancieraRowChanging(ByVal sender As System.Object, ByVal e As CalculoActividadFinancieraRowChangeEvent) Handles Me.CalculoActividadFinancieraRowChanging

        End Sub

    End Class

    Partial Class EjecucionRubrosDataTable

        Private Sub EjecucionRubrosDataTable_ColumnChanging(ByVal sender As System.Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.vIdJuntaUsuarioColumn.ColumnName) Then
                'Agregar código de usuario aquí
            End If

        End Sub

    End Class

    Partial Class RubroMesDataTable

        Private Sub RubroMesDataTable_RubroMesRowChanging(ByVal sender As System.Object, ByVal e As RubroMesRowChangeEvent) Handles Me.RubroMesRowChanging

        End Sub

    End Class

End Class
