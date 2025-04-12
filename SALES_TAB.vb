Imports System.Data.SqlClient
Imports System.Windows.Forms.DataVisualization.Charting

Public Class SALES_TAB


    Private Sub SALES_TAB_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.DailySalesTableAdapter.Fill(Me.SHITSTEMDataSet.DailySales)
        Me.MonthlySalesTableAdapter.Fill(Me.SHITSTEMDataSet.MonthlySales)
        Me.STOCKSTableAdapter.Fill(Me.SHITSTEMDataSet.STOCKS)



        Dim dt As New DataTable()
        Dim query As String = "SELECT * FROM STOCKS"
        Using filtercmd As New SqlCommand(query, con)
            Using da As New SqlDataAdapter(filtercmd)
                da.Fill(dt)
            End Using
        End Using


        Dim outOfStockView As New DataView(dt)
        outOfStockView.RowFilter = "Quantity = 0"
        DataGridView1.DataSource = outOfStockView

        ' Filter for low-stock (Quantity < 5 but > 0)
        Dim lowStockView As New DataView(dt)
        lowStockView.RowFilter = "Quantity <= 5 AND Quantity > 0"
        STOCKSDataGridView.DataSource = lowStockView




        Label2.Text = DateTime.Now.ToString("dddd, MMMM dd, yyyy")
        dailytotalearn()
        LoadCharts()
    End Sub
    Private Sub LoadCharts()
        ' === MonthlySales Chart ===
        Opencon()
        Dim cmd As New SqlCommand("SELECT Month, Earned FROM MonthlySales", con)
        Dim reader As SqlDataReader

        Chart1.Series.Clear()
        Dim series As New Series("Earned")
        series.ChartType = SeriesChartType.Column
        series.BorderWidth = 2
        series.IsValueShownAsLabel = True

        With Chart1.ChartAreas(0)
            .AxisY.Maximum = Double.NaN  ' Let the chart auto scale
            .AxisY.Minimum = Double.NaN
            .AxisY.IntervalAutoMode = DataVisualization.Charting.IntervalAutoMode.VariableCount
            .AxisY.LabelStyle.Format = "N0" ' Use thousand separators, and adjust the label angle
        End With
        Dim color1 As Color = Color.DarkOrange
        Dim color2 As Color = Color.Gray



        Try
            reader = cmd.ExecuteReader()
            Dim index As Integer = 0
            While reader.Read()
                Dim point As New DataPoint()
                point.SetValueXY(reader("Month").ToString(), Convert.ToDouble(reader("Earned")))
                point.Color = If(index Mod 2 = 0, color1, color2)
                series.Points.Add(point)
                index += 1
            End While
            Chart1.Series.Add(series)
        Catch ex As Exception
            MessageBox.Show("Error loading monthly chart: " & ex.Message)
        Finally
            con.Close()
        End Try

        ' === WeeklySales Chart ===
        Opencon()
        Dim cmd2 As New SqlCommand("SELECT Day, Earned FROM WeeklySales", con)
        Dim reader2 As SqlDataReader

        Chart2.Series.Clear()
        Dim series2 As New Series("Daily Sales")
        series2.ChartType = SeriesChartType.Column
        series2.BorderWidth = 2
        series2.IsValueShownAsLabel = True

        With Chart2.ChartAreas(0)
            .AxisY.Maximum = Double.NaN  ' Let the chart auto scale
            .AxisY.Minimum = Double.NaN
            .AxisY.IntervalAutoMode = DataVisualization.Charting.IntervalAutoMode.VariableCount
            .AxisY.LabelStyle.Format = "N0" ' U se thousand separators, and adjust the label angle
        End With

        Dim color3 As Color = Color.DarkOrange
        Dim color4 As Color = Color.Gray

        Try
            reader2 = cmd2.ExecuteReader()
            Dim index As Integer = 0
            While reader2.Read()
                Dim point As New DataPoint()
                point.SetValueXY(reader2("Day").ToString(), Convert.ToDouble(reader2("Earned")))
                point.Color = If(index Mod 2 = 0, color3, color4)
                series2.Points.Add(point)
                index += 1
            End While
            Chart2.Series.Add(series2)
        Catch ex As Exception
            MessageBox.Show("Error loading weekly chart: " & ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Public Sub dailytotalearn()
        Dim dailyearned As Decimal = 0
        Dim earnedquery As String = "SELECT SUM(Earned) FROM DailySales"

        Using earnedcmd As New SqlCommand(earnedquery, con)
            con.Open()
            Dim result = earnedcmd.ExecuteScalar()
            If result IsNot DBNull.Value Then
                dailyearned = Convert.ToDecimal(result)
            End If
            con.Close()
        End Using

        Label6.Text = dailyearned.ToString("C2")

    End Sub
    Private Sub SALES_TAB_ParentChanged(sender As Object, e As EventArgs) Handles Me.ParentChanged
        If Me.Visible Then
            Dim dt As New DataTable()
            Dim query As String = "SELECT * FROM STOCKS"
            Using filtercmd As New SqlCommand(query, con)
                Using da As New SqlDataAdapter(filtercmd)
                    da.Fill(dt)
                End Using
            End Using

            Dim outOfStockView As New DataView(dt)
            outOfStockView.RowFilter = "Quantity = 0"
            DataGridView1.DataSource = outOfStockView

            ' Filter for low-stock (Quantity < 5 but > 0)
            Dim lowStockView As New DataView(dt)
            lowStockView.RowFilter = "Quantity <= 5 AND Quantity > 0"
            STOCKSDataGridView.DataSource = lowStockView
            Me.STOCKSTableAdapter.Fill(Me.SHITSTEMDataSet.STOCKS)
        End If
    End Sub

    Private Sub Guna2CircleButton1_Click(sender As Object, e As EventArgs) Handles Guna2CircleButton1.Click
        dailytotalearn()
        LoadCharts()
        Me.STOCKSTableAdapter.Fill(Me.SHITSTEMDataSet.STOCKS)
    End Sub
End Class
