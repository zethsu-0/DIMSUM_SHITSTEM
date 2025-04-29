Imports CrystalDecisions.CrystalReports.Engine

Public Class ReportViewerForm
    Private reportDoc As ReportDocument

    ' This is the custom constructor that takes the report
    Public Sub New(report As ReportDocument)
        ' This is required to initialize the form and its controls
        InitializeComponent()

        ' Store and assign the report
        reportDoc = report
        CrystalReportViewer1.ReportSource = reportDoc
        CrystalReportViewer1.RefreshReport()
    End Sub
End Class
