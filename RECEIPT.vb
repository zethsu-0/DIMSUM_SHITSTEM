Imports CrystalDecisions.CrystalReports.Engine

Public Class RECEIPT
    Private Sub RECEIPT_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim report As New ReportDocument()
        report.Load("YourReportPath.rpt")
        report.SetDataSource(reportData)

        CrystalReportViewer1.ReportSource = report
        CrystalReportViewer1.RefreshReport()
    End Sub
End Class