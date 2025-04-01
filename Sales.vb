Imports System.Data.SqlClient
Imports System.Windows.Forms.DataVisualization.Charting
Public Class Sales
    Private Sub Sales_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Opencon()
        Dim cmd As New SqlCommand("SELECT Month, Sales FROM Sales", con)
        Dim reader As SqlDataReader

        Chart1.Series.Clear()
        Dim series As New Series("Sales")
        series.ChartType = SeriesChartType.Line
        series.BorderWidth = 2
        series.Color = Color.Red
        series.IsValueShownAsLabel = True

        With Chart1.ChartAreas(0).AxisX
            .Interval = 1
            .LabelStyle.Angle = -45
            .LabelStyle.IsStaggered = True
        End With

        Try

            reader = cmd.ExecuteReader()
            While reader.Read()
                series.Points.AddXY(reader("Month").ToString(), Convert.ToDouble(reader("Sales")))
            End While
            Chart1.Series.Add(series)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub
End Class