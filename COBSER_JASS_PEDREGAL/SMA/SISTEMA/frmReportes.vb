
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports ACCESO
Imports LOGICA
Imports System.IO
Public Class frmReportes
    Public idjas As Integer
    Public idPredio As Integer
    Public optionRPT As Integer
    Public dfini As String
    Public dffin As String
    Public tipoingreso As Integer
    Dim rptarjeta As New tar_Rpt_TarjetaDetallada
    Dim rptotrosI As New tar_Rpt_CobranzaDetalladaOtrosIngresos
    Dim rptPadronAsistenciaP As New Rpt_PadronUsuariosAsistenciaAsambleaP
    Dim rptPadronAsistentes As New Rpt_PadronUsuariosAsistentes

    Dim c As New ACCESO.Conexion



    Private Sub frmReportes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Select Case optionRPT

                Case 0

                    If c.Connect Then
                        If c.Connect Then
                            clsCrystalConnect.Conectar(rptarjeta)
                            rptarjeta.ParameterFields("@IDJASS").CurrentValues.Clear()
                            rptarjeta.ParameterFields("@IDPREDIO").CurrentValues.Clear()

                            rptarjeta.SetParameterValue("@IDJASS", idjas)
                            rptarjeta.SetParameterValue("@IDPREDIO", idPredio)


                            ViewReport()
                            c.Close()
                        End If

                    End If

                Case 1
                    If c.Connect Then
                        If c.Connect Then
                            clsCrystalConnect.Conectar(rptotrosI)
                            rptotrosI.ParameterFields("@FINI").CurrentValues.Clear()
                            rptotrosI.ParameterFields("@FFIN").CurrentValues.Clear()
                            rptotrosI.ParameterFields("@IDTIPOINGRESO").CurrentValues.Clear()
                            rptotrosI.SetParameterValue("@FINI", dfini)
                            rptotrosI.SetParameterValue("@FFIN", dffin)
                            rptotrosI.SetParameterValue("@IDTIPOINGRESO", tipoingreso)
                            ViewReport()
                            c.Close()
                        End If

                    End If
                Case 2
                    If c.Connect Then
                        If c.Connect Then
                            clsCrystalConnect.Conectar(rptPadronAsistenciaP)
                            ViewReport()
                            c.Close()
                        End If

                    End If

                Case 3
                    If c.Connect Then
                        If c.Connect Then
                            clsCrystalConnect.Conectar(rptPadronAsistentes)
                            ViewReport()
                            c.Close()
                        End If

                    End If
            End Select
        Catch ex As Exception

        End Try
    End Sub
    Private Delegate Sub ViewReport_Delegate()

    Private Sub ViewReport()
        If Me.InvokeRequired = True Then
            Me.Invoke(New ViewReport_Delegate(AddressOf ViewReport))
        Else
            Select Case optionRPT
                Case 0
                    Me.crViewer.ReportSource = rptarjeta
                    Me.crViewer.Focus()
                Case 1
                    Me.crViewer.ReportSource = rptotrosI
                    Me.crViewer.Focus()
                Case 2
                    Me.crViewer.ReportSource = rptPadronAsistenciaP
                    Me.crViewer.Focus()
                Case 3
                    Me.crViewer.ReportSource = rptPadronAsistentes
                    Me.crViewer.Focus()
            End Select

        End If
    End Sub
End Class