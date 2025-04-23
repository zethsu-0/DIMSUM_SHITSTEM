Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Public Class RECEIPT
    Public Sub LoadReport(paymentAmount As Decimal, changeAmount As Decimal)
        Dim rpt As New CrystalReport1()

        ' Now set parameters
        rpt.SetParameterValue("PaymentAmount", paymentAmount)
        rpt.SetParameterValue("ChangeAmount", changeAmount)

        CrystalReportViewer1.ReportSource = rpt
    End Sub

    Private Sub RECEIPT_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class