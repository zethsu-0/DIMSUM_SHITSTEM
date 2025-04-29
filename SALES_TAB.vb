Imports System.Data.SqlClient
Imports System.Reflection
Imports System.Web
Imports System.Windows.Forms.DataVisualization.Charting
Imports SixLabors.ImageSharp.PixelFormats
Imports CrystalDecisions.CrystalReports.Engine

Public Class SALES_TAB

    Public Property user_Role As String
    Private Sub SALES_TAB_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.DailySalesTableAdapter.Fill(Me.SHITSTEMDataSet.DailySales)
        Me.MonthlySalesTableAdapter.Fill(Me.SHITSTEMDataSet.MonthlySales)

        Me.STOCKSTableAdapter.Fill(Me.SHITSTEMDataSet.STOCKS)
        Me.DailySummaryTableAdapter.Fill(Me.SHITSTEMDataSet.DailySummary)
        Me.WeeklySalesTableAdapter.Fill(Me.SHITSTEMDataSet.WeeklySales)
        Me.TransactionsTableAdapter.Fill(Me.SHITSTEMDataSet.Transactions)
        ' Somewhere in Form_Load or the Designer code:
        TransactionDetailsDataGridView.DataSource = TransactionDetailsBindingSource

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

        If user_Role = "Manager" Then
            TransactionsDataGridView.Columns("Profit").Visible = False
        End If

        ExpireOldProducts()
        salesTotallbl.Text = "0.00"
        dailytotalearn()
        LoadCharts()

    End Sub


    Private Sub LoadCharts()
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
        monthlyProfitSeries("PointWidth") = "0.2"
        monthlySalesSeries("PointWidth") = "0.2"

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

            Chart1.ChartAreas(0).AxisX.MajorGrid.Enabled = False
            With Chart1.ChartAreas(0).AxisY.MajorGrid
                .LineColor = Color.LightGray
                .LineDashStyle = ChartDashStyle.Dot
            End With
        Catch ex As Exception
            MessageBox.Show("Error loading MonthlySales: " & ex.Message)
        Finally
            con.Close()
        End Try

        ' === Chart2: Weekly Profit & Sales ===
        Opencon()

        Dim weekStart As Date = Date.Today.AddDays(-(CInt(Date.Today.DayOfWeek) - 1))
        If weekStart > Date.Today Then weekStart = weekStart.AddDays(-7)

        Dim weekEnd As Date = weekStart.AddDays(6)

        Dim chartQuery As String = "
SELECT SaleDate, Profit, Sales_total 
FROM WeeklySales 
WHERE SaleDate BETWEEN @WeekStart AND @WeekEnd 
ORDER BY SaleDate"

        Dim cmd2 As New SqlCommand(chartQuery, con)
        cmd2.Parameters.AddWithValue("@WeekStart", weekStart)
        cmd2.Parameters.AddWithValue("@WeekEnd", weekEnd)

        Dim reader2 As SqlDataReader
        Chart2.Series.Clear()
        Chart2.Legends.Clear()

        Dim weeklyProfitSeries As New Series("Profit")
        Dim weeklySalesSeries As New Series("Sales")

        weeklyProfitSeries.ChartType = SeriesChartType.Column
        weeklySalesSeries.ChartType = SeriesChartType.Column
        weeklyProfitSeries.Color = Color.Black
        weeklySalesSeries.Color = Color.Yellow
        weeklyProfitSeries.IsValueShownAsLabel = True
        weeklySalesSeries.IsValueShownAsLabel = True

        Try
            reader2 = cmd2.ExecuteReader()
            While reader2.Read()
                Dim saleDate As Date = Convert.ToDateTime(reader2("SaleDate"))
                Dim dayLabel As String = saleDate.ToString("ddd dd") ' e.g., "Mon 22"

                Dim profit = If(IsDBNull(reader2("Profit")), 0D, Convert.ToDecimal(reader2("Profit")))
                Dim sales = If(IsDBNull(reader2("Sales_total")), 0D, Convert.ToDecimal(reader2("Sales_total")))

                If user_Role <> "Manager" Then
                    weeklyProfitSeries.Points.AddXY(dayLabel, profit)
                End If
                weeklySalesSeries.Points.AddXY(dayLabel, sales)
            End While

            Chart2.Series.Add(weeklyProfitSeries)
            Chart2.Series.Add(weeklySalesSeries)

            Chart2.Legends.Add("Legend")
            Chart2.Legends(0).Docking = Docking.Top
            Chart2.Legends(0).Font = New Font("Arial", 9, FontStyle.Bold)
            Chart2.ChartAreas(0).Area3DStyle.Enable3D = False
            Chart2.ChartAreas(0).AxisX.MajorGrid.Enabled = False
        Catch ex As Exception
            MessageBox.Show("Error loading WeeklySales: " & ex.Message)
        Finally
            con.Close()
        End Try




        Opencon()
        Dim cmd3 As New SqlCommand("SELECT Year, Profit, Sales_Total FROM YearlySales", con)
        Dim reader3 As SqlDataReader

        Chart3.Series.Clear()
        Chart3.Legends.Clear()

        Dim yearlyProfitSeries As New Series("Yearly Profit")
        Dim yearlySalesSeries As New Series("Yearly Sales")

        yearlyProfitSeries.ChartType = SeriesChartType.Column
        yearlySalesSeries.ChartType = SeriesChartType.Column
        yearlyProfitSeries.Color = Color.Black
        yearlySalesSeries.Color = Color.Yellow
        yearlyProfitSeries.IsValueShownAsLabel = True
        yearlySalesSeries.IsValueShownAsLabel = True

        Try
            reader3 = cmd3.ExecuteReader()
            While reader3.Read()
                Dim month = reader3("Year").ToString()
                Dim profit = If(IsDBNull(reader3("Profit")), 0D, Convert.ToDecimal(reader3("Profit"))) ' Handle Null profit
                Dim sales = If(IsDBNull(reader3("Sales_Total")), 0D, Convert.ToDecimal(reader3("Sales_Total"))) ' Handle Null sales

                If String.IsNullOrEmpty(month) Then
                    month = "Unknown"
                End If

                If user_Role <> "Manager" Then
                    yearlyProfitSeries.Points.AddXY(month, profit)
                End If
                yearlySalesSeries.Points.AddXY(month, sales)
            End While

            Chart3.Series.Add(yearlyProfitSeries)
            Chart3.Series.Add(yearlySalesSeries)

            Chart3.Legends.Add("Legend3")
            Chart3.Legends(0).Docking = Docking.Top
            Chart3.Legends(0).Font = New Font("Arial", 9, FontStyle.Bold)
            Chart3.ChartAreas(0).Area3DStyle.Enable3D = False
            Chart3.ChartAreas(0).AxisX.MajorGrid.Enabled = False

            yearlyProfitSeries.BorderWidth = 1
            yearlySalesSeries.BorderWidth = 1

            yearlyProfitSeries("PointWidth") = "0.2"
            yearlySalesSeries("PointWidth") = "0.2"
            With Chart3.ChartAreas(0).AxisY.MajorGrid
                .LineColor = Color.LightGray
                .LineDashStyle = ChartDashStyle.Dot
            End With
        Catch ex As Exception
            MessageBox.Show("Error loading YearlySales: " & ex.Message)
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

    Private Sub ExpireOldProducts()
        Try
            Opencon()

            ' Update all products where expdate is today or earlier
            Dim expireQuery As String = "
            UPDATE STOCKS
            SET Quantity = 0
            WHERE expdate <= @today
        "

            Using cmd As New SqlCommand(expireQuery, con)
                cmd.Parameters.AddWithValue("@today", Date.Today)
                Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

                If rowsAffected > 0 Then

                End If
            End Using

        Catch ex As Exception
            MessageBox.Show("Error updating expired products: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If con.State = ConnectionState.Open Then con.Close()
        End Try
    End Sub




    Private Sub SALES_TAB_ParentChanged(sender As Object, e As EventArgs) Handles Me.ParentChanged
        If Me.Visible Then
            RefreshData()
        End If

    End Sub

    Private Sub Guna2CircleButton1_Click(sender As Object, e As EventArgs) Handles Guna2CircleButton1.Click
        RefreshData()
        LoadCharts()
    End Sub


    Private Sub RESTOCKBTN_Click(sender As Object, e As EventArgs) Handles RESTOCKBTN.Click
        RESTOCKBTN.Enabled = False

        Using restockForm As New RESTOCK_TAB()
            restockForm.ShowDialog()
        End Using

        RESTOCKBTN.Enabled = True
    End Sub


    Private Sub RESTOCKBTN_Closed(sender As Object, e As FormClosedEventArgs)
        RefreshData()
    End Sub
    Public Sub RefreshData()
        Me.DailySalesTableAdapter.Fill(Me.SHITSTEMDataSet.DailySales)
        Me.MonthlySalesTableAdapter.Fill(Me.SHITSTEMDataSet.MonthlySales)

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

        Dim lowStockView As New DataView(dt)
        lowStockView.RowFilter = "Quantity <= 5 AND Quantity > 0"
        STOCKSDataGridView.DataSource = lowStockView

        dailytotalearn()
        LoadCharts()
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        PrintFilteredData()
    End Sub
    Private Function GetVisibleTransactionsData() As DataTable
        ' Build a new DataTable with the correct columns matching the Crystal Report structure
        Dim dt As New DataTable()

        ' Create exact columns expected by Crystal Report
        dt.Columns.Add("TransactionID", GetType(Integer))
        dt.Columns.Add("TransactionDate", GetType(Date))
        dt.Columns.Add("TotalAmount", GetType(Decimal))
        dt.Columns.Add("PaymentAmount", GetType(Decimal))
        dt.Columns.Add("ChangeGiven", GetType(Decimal))
        dt.Columns.Add("Total_Item", GetType(Integer))
        dt.Columns.Add("Profit", GetType(Decimal))
        dt.Columns.Add("Discount", GetType(String))

        ' Now loop and add rows from visible rows in DataGridView
        For Each row As DataGridViewRow In TransactionsDataGridView.Rows
            If Not row.IsNewRow Then
                Dim newRow As DataRow = dt.NewRow()

                newRow("TransactionID") = Convert.ToInt32(row.Cells("TransactionID").Value)
                newRow("TransactionDate") = Convert.ToDateTime(row.Cells("TransactionDate").Value)
                newRow("TotalAmount") = Convert.ToDecimal(row.Cells("TotalAmount").Value)
                newRow("PaymentAmount") = Convert.ToDecimal(row.Cells("PaymentAmount").Value)
                newRow("ChangeGiven") = Convert.ToDecimal(row.Cells("ChangeGiven").Value)
                newRow("Total_Item") = Convert.ToInt32(row.Cells("Total_Item").Value)
                newRow("Profit") = Convert.ToDecimal(row.Cells("Profit").Value)
                newRow("Discount") = row.Cells("Discount").Value.ToString()

                dt.Rows.Add(newRow)
            End If
        Next

        Return dt
    End Function
    Private Sub PrintFilteredData()
        ' Create a DataView from the BindingSource list
        Dim filteredDataView As DataView = CType(TransactionsBindingSource.List, DataView)

        ' Convert DataView to DataTable
        Dim filteredTable As DataTable = filteredDataView.ToTable()

        ' Create a new Crystal Report instance
        Dim rpt As New CrystalReport2() ' Replace with your actual Crystal Report class

        ' Set the data source for the report
        rpt.SetDataSource(filteredTable)

        ' Create a form to show the Crystal Report
        Dim reportViewerForm As New Form
        Dim viewer As New CrystalDecisions.Windows.Forms.CrystalReportViewer With {
        .Dock = DockStyle.Fill,
        .ReportSource = rpt
    }

        ' Add the CrystalReportViewer to the form and show it
        reportViewerForm.Controls.Add(viewer)
        reportViewerForm.WindowState = FormWindowState.Maximized
        reportViewerForm.ShowDialog()
    End Sub
    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs)
        resetdatas()
    End Sub
    Private Sub resetdatas()

        profitlbl.Text = "0.00"
        salesTotallbl.Text = "0.00"
        Dim deleteQuery As String = "
    DELETE FROM DailySales;
    DELETE FROM WeeklySales;
    DELETE FROM MonthlySales;
    DELETE FROM Yearlysales;
    DELETE FROM DailySummary;
    DELETE FROM Transactions;"

        Try
            Opencon()
            Using cmd As New SqlCommand(deleteQuery, con)
                cmd.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            MessageBox.Show("Error deleting: " & ex.Message)
        Finally
            If con.State = ConnectionState.Open Then con.Close()
        End Try

        RefreshData()
    End Sub

    Private Sub TransactionsDataGridView_CellClick(sender As Object, e As DataGridViewCellEventArgs) _
    Handles TransactionsDataGridView.CellClick

        ' ignore header or out-of-range clicks
        If e.RowIndex < 0 Then Return

        ' grab the ID from the clicked row of TransactionsDataGridView
        Dim cellVal = TransactionsDataGridView.Rows(e.RowIndex).Cells("TransactionID").Value
        If cellVal Is Nothing OrElse IsDBNull(cellVal) Then Return

        Dim transactionID As Integer
        If Integer.TryParse(cellVal.ToString(), transactionID) Then
            TransactionDetailsDataGridView.Width = 503
            TransactionDetailsDataGridView.DataSource = TransactionDetailsBindingSource
            LoadTransactionDetails(transactionID)
        End If
    End Sub

    Private Sub LoadTransactionDetails(transactionID As Integer)
        Try
            Opencon()

            ' Query to get details
            Dim query As String = "
        SELECT Item_no, Product_name, Quantity, date
        FROM TransactionDetails
        WHERE transactionID = @transactionID
        "

            Using cmd As New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@transactionID", transactionID)

                Using da As New SqlDataAdapter(cmd)
                    Dim dt As New DataTable()
                    da.Fill(dt)

                    ' Check if data is returned
                    If dt.Rows.Count > 0 Then
                        ' Set the DataTable to the BindingSource
                        TransactionDetailsBindingSource.DataSource = dt

                        ' Refresh the DataGridView
                        TransactionDetailsBindingSource.ResetBindings(False)
                        TransactionDetailsDataGridView.Refresh() ' Correct DataGridView name here
                    Else
                        ' If no data, inform the user (optional)
                        MessageBox.Show("No details found for this transaction.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error loading transaction details: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If con.State = ConnectionState.Open Then con.Close()
        End Try
    End Sub


    Private Sub DateRange_ValueChanged(sender As Object, e As EventArgs) _
    Handles DateTimePicker1.ValueChanged, DateTimePicker2.ValueChanged

        ' Only apply the filter if both pickers are checked
        If DateTimePicker1.Checked AndAlso DateTimePicker2.Checked Then
            Dim startDate As Date = DateTimePicker1.Value.Date
            Dim endDate As Date = DateTimePicker2.Value.Date.AddDays(1) ' Add 1 day to include entire end date

            If startDate <= endDate Then
                TransactionsBindingSource.Filter =
                $"TransactionDate >= #{startDate:MM/dd/yyyy}# AND TransactionDate < #{endDate:MM/dd/yyyy}#"
            Else
                MessageBox.Show("Start date must be before or equal to end date.", "Invalid Range", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            ' If either is unchecked, remove filter
            TransactionsBindingSource.RemoveFilter()
        End If
    End Sub

    Private Sub Guna2Button2_Click_1(sender As Object, e As EventArgs)

    End Sub
    Private Sub Guna2Button3_Click(sender As Object, e As EventArgs) Handles Guna2Button3.Click
        TransactionDetailsDataGridView.DataSource = Nothing
        TransactionDetailsDataGridView.Width = 10
        ClearTransactionFilter()
    End Sub
    Private Sub ClearTransactionFilter()
        TransactionsBindingSource.RemoveFilter()
        TransactionsDataGridView.ClearSelection()
    End Sub


End Class
