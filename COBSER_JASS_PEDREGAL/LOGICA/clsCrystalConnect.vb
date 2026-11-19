Imports ACCESO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class clsCrystalConnect
    Public Shared Sub Conectar(ByRef rp)
        Dim c As New ACCESO.Conexion
        Dim CRTABLES As Tables
        Dim CRTABLE As Table
        Dim CRINFOS As New TableLogOnInfos
        Dim CRINFO As New TableLogOnInfo
        Dim CRCON As New ConnectionInfo
        Dim LOGIN As CrystalDecisions.Shared.ConnectionInfo
        If c.Connect Then
            LOGIN = New CrystalDecisions.Shared.ConnectionInfo
            LOGIN.ServerName = c.server
            LOGIN.DatabaseName = c.database
            LOGIN.UserID = c.user
            LOGIN.Password = c.password

            CRCON = LOGIN
            CRTABLES = rp.Database.Tables
            For Each CRTABLE In CRTABLES
                CRINFO = CRTABLE.LogOnInfo
                CRINFO.ConnectionInfo = LOGIN
                CRTABLE.ApplyLogOnInfo(CRINFO)
            Next
            c.Close()
        End If
    End Sub


End Class
