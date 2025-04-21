Imports System.Data.SqlClient
Imports System.Reflection
Imports System.Windows.Forms.DataVisualization.Charting
Imports SixLabors.ImageSharp.PixelFormats

Public Class SALES_TAB

    Public Property user_Role As String
    Private Sub SALES_TAB_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.DailySalesTableAdapter.Fill(Me.SHITSTEMDataSet.DailySales)
        Me.MonthlySalesTableAdapter.Fill(Me.SHITSTEMDataSet.MonthlySales)
        Me.WeeklySalesTableAdapter.Fill(Me.SHITSTEMDataSet.WeeklySales)
        Me.STOCKSTableAdapter.Fill(Me.SHITSTEMDataSet.STOCKS)
        Me.DailySummaryTableAdapter.Fill(Me.SHITSTEMDataSet.DailySummary)
        Me.TransactionsTableAdapter.Fill(Me.SHITSTEMDataSet.Transactions)
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




        salesTotallbl.Text = DateTime.Now.ToString("dddd, MMMM dd, yyyy")
        dailytotalearn()
        LoadCharts()
    End Sub
    Private Sub LoadCharts()
        ' === Chart1: Monthly Profit & Sales ===
        Opencon()
        Dim cmd As New SqlCommand("SELECT Month, Profit, Sales_Total FROM MonthlySales", con)
        Dim reader As SqlDataReader

        Chart1.Series.Clear()
        Chart1.Legends.Clear()

        Dim monthlyProfitSeries As New Series("Monthly Profit")
        Dim monthlySalesSeries As New Series("Monthly Sales")

        ' Style
        monthlyProfitSeries.ChartType = SeriesChartType.Column
        monthlySalesSeries.ChartType = SeriesChartType.Column
        monthlyProfitSeries.Color = Color.Black
        monthlySalesSeries.Color = Color.Yellow
        monthlyProfitSeries.IsValueShownAsLabel = True
        monthlySalesSeries.IsValueShownAsLabel = True
        monthlyProfitSeries("PointWidth") = "0.5"
        monthlySalesSeries("PointWidth") = "0.5"

        Try
            reader = cmd.ExecuteReader()
            While reader.Read()
                Dim month = reader("Month").ToString()
                Dim profit = If(IsDBNull(reader("Profit")), 0D, Convert.ToDecimal(reader("Profit"))) ' Handle Null profit
                Dim sales = If(IsDBNull(reader("Sales_Total")), 0D, Convert.ToDecimal(reader("Sales_Total"))) ' Handle Null sales

                If user_Role <> "Manager" Then
                    monthlyProfitSeries.Points.AddXY(month, profit)
                End If

                monthlySalesSeries.Points.AddXY(month, sales)
            End While

            Chart1.Series.Add(monthlyProfitSeries)
            Chart1.Series.Add(monthlySalesSeries)

            Chart1.Legends.Add("Legend1")
            Chart1.Legends(0).Docking = Docking.Top
            Chart1.Legends(0).Font = New Font("Arial", 9, FontStyle.Bold)

            Chart1.ChartAreas(0).AxisX.IsMarginVisible = True
            Chart1.ChartAreas(0).AxisX.Interval = 1

        Catch ex As Exception
            MessageBox.Show("Error loading MonthlySales: " & ex.Message)
        Finally
            con.Close()
        End Try

        ' === Chart2: Weekly Profit & Sales ===
        Opencon()
        Dim cmd2 As New SqlCommand("SELECT Day, Profit, Sales_Total FROM WeeklySales", con)
        Dim reader2 As SqlDataReader

        Chart2.Series.Clear()
        Chart2.Legends.Clear()

        Dim weeklyProfitSeries As New Series("Weekly Profit")
        Dim weeklySalesSeries As New Series("Weekly Sales")

        weeklyProfitSeries.ChartType = SeriesChartType.Column
        weeklySalesSeries.ChartType = SeriesChartType.Column
        weeklyProfitSeries.Color = Color.Black
        weeklySalesSeries.Color = Color.Yellow
        weeklyProfitSeries.IsValueShownAsLabel = True
        weeklySalesSeries.IsValueShownAsLabel = True

        Try
            reader2 = cmd2.ExecuteReader()
            While reader2.Read()
                Dim day = reader2("Day").ToString()
                Dim profit = If(IsDBNull(reader2("Profit")), 0D, Convert.ToDecimal(reader2("Profit"))) ' Handle Null profit
                Dim sales = If(IsDBNull(reader2("Sales_Total")), 0D, Convert.ToDecimal(reader2("Sales_Total"))) ' Handle Null sales

                ' Check if day is Null or empty
                If String.IsNullOrEmpty(day) Then
                    day = "Unknown"  ' Or set to any default value like "N/A"
                End If

                ' Add profit and sales data points
                If user_Role <> "Manager" Then
                    weeklyProfitSeries.Points.AddXY(day, profit)
                End If
                weeklySalesSeries.Points.AddXY(day, sales)
            End While

            Chart2.Series.Add(weeklyProfitSeries)
            Chart2.Series.Add(weeklySalesSeries)

            Chart2.Legends.Add("Legend2")
            Chart2.Legends(0).Docking = Docking.Top
            Chart2.Legends(0).Font = New Font("Arial", 9, FontStyle.Bold)
            Chart2.ChartAreas(0).Area3DStyle.Enable3D = False
            weeklyProfitSeries.BorderWidth = 1
            weeklySalesSeries.BorderWidth = 1

            weeklyProfitSeries("PointWidth") = "0.4"
            weeklySalesSeries("PointWidth") = "0.4"

        Catch ex As Exception
            MessageBox.Show("Error loading WeeklySales: " & ex.Message)
        Finally
            con.Close()
        End Try
    End Sub










    Public Sub dailytotalearn()
        Dim dailyProfit As Decimal = 0
        Dim dailySales_total As Decimal = 0

        Dim query As String = "SELECT SUM(Profit) AS TotalProfit, SUM(Sales_total) AS TotalSales 
                                FROM DailySales 
                                WHERE CONVERT(date, Day) = CONVERT(date, GETDATE())"

        Using cmd As New SqlCommand(query, con)
            If con IsNot Nothing AndAlso con.State = ConnectionState.Open Then con.Close()
            con.Open()
            Using reader As SqlDataReader = cmd.ExecuteReader()
                If reader.Read() Then
                    If Not IsDBNull(reader("TotalProfit")) Then
                        dailyProfit = Convert.ToDecimal(reader("TotalProfit"))
                        profitlbl.Text = dailyProfit.ToString()
                    End If

                    If Not IsDBNull(reader("TotalSales")) Then
                        dailySales_total = Convert.ToDecimal(reader("TotalSales"))
                        salesTotallbl.Text = dailySales_total.ToString()
                    End If
                End If
            End Using
            con.Close()
        End Using

    End Sub

    Private Sub SALES_TAB_ParentChanged(sender As Object, e As EventArgs) Handles Me.ParentChanged
        If Me.Visible Then
            RefreshData()
        End If

    End Sub

    Private Sub Guna2CircleButton1_Click(sender As Object, e As EventArgs) Handles Guna2CircleButton1.Click
        dailytotalearn()
        LoadCharts()
        RefreshData()
        Me.DailySalesTableAdapter.Fill(Me.SHITSTEMDataSet.DailySales)
        Me.MonthlySalesTableAdapter.Fill(Me.SHITSTEMDataSet.MonthlySales)
        Me.WeeklySalesTableAdapter.Fill(Me.SHITSTEMDataSet.WeeklySales)
        Me.DailySummaryTableAdapter.Fill(Me.SHITSTEMDataSet.DailySummary)
        Me.STOCKSTableAdapter.Fill(Me.SHITSTEMDataSet.STOCKS)
        Me.TransactionsTableAdapter.Fill(Me.SHITSTEMDataSet.Transactions)

    End Sub


    Private Sub RESTOCKBTN_Click(sender As Object, e As EventArgs) Handles RESTOCKBTN.Click
        RESTOCK_TAB.Show()
    End Sub


    Public Sub RefreshData()
        ' Refresh data logic, like re-fetching and binding to DataGridViews
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

        Dim lowStockView As New DataView(dt)
        lowStockView.RowFilter = "Quantity <= 5 AND Quantity > 0"
        STOCKSDataGridView.DataSource = lowStockView

        Me.STOCKSTableAdapter.Fill(Me.SHITSTEMDataSet.STOCKS)
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class
