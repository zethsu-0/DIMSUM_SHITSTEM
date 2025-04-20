Imports System.Data.SqlClient
Imports System.Reflection
Imports System.Windows.Forms.DataVisualization.Charting

Public Class SALES_TAB

    Public Property user_Role As String
    Private Sub SALES_TAB_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.DailySalesTableAdapter.Fill(Me.SHITSTEMDataSet.DailySales)
        Me.MonthlySalesTableAdapter.Fill(Me.SHITSTEMDataSet.MonthlySales)
        Me.WeeklySalesTableAdapter.Fill(Me.SHITSTEMDataSet.WeeklySales)
        Me.STOCKSTableAdapter.Fill(Me.SHITSTEMDataSet.STOCKS)

        If user_Role = "Owner" Then
            profitpanel.Visible = True
            Label1.Visible = True
            Label3.Visible = True
            profitlbl.Visible = True
        End If
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
        ' === MonthlySales: Profit to Chart1, Sales_Total to Chart3 ===
        Opencon()
        Dim cmd As New SqlCommand("SELECT Month, Profit, Sales_Total FROM MonthlySales", con)
        Dim reader As SqlDataReader

        Chart1.Series.Clear()
        Chart3.Series.Clear()

        Dim profitSeries As New Series("Monthly Profit")
        Dim salesSeries As New Series("Monthly Sales")

        profitSeries.ChartType = SeriesChartType.Column
        salesSeries.ChartType = SeriesChartType.Column

        profitSeries.IsValueShownAsLabel = True
        salesSeries.IsValueShownAsLabel = True

        Try
            reader = cmd.ExecuteReader()
            Dim index As Integer = 0

            While reader.Read()
                Dim month = reader("Month").ToString()
                Dim profit = Convert.ToDecimal(reader("Profit"))
                Dim sales = Convert.ToDecimal(reader("Sales_Total"))

                ' Profit to Chart1
                Dim profitPoint As New DataPoint()
                profitPoint.SetValueXY(month, profit)
                profitSeries.Points.Add(profitPoint)

                ' Sales_Total to Chart3
                Dim salesPoint As New DataPoint()
                salesPoint.SetValueXY(month, sales)
                salesSeries.Points.Add(salesPoint)

                index += 1
            End While

            Chart1.Series.Add(profitSeries)
            Chart3.Series.Add(salesSeries)

        Catch ex As Exception
            MessageBox.Show("Error loading MonthlySales: " & ex.Message)
        Finally
            con.Close()
        End Try

        ' === WeeklySales: Profit to Chart2, Sales_Total to Chart4 ===
        Opencon()
        Dim cmd2 As New SqlCommand("SELECT Day, Profit, Sales_Total FROM WeeklySales", con)
        Dim reader2 As SqlDataReader

        Chart2.Series.Clear()
        Chart4.Series.Clear()

        Dim profitSeries2 As New Series("Weekly Profit")
        Dim salesSeries2 As New Series("Weekly Sales")

        profitSeries2.ChartType = SeriesChartType.Column
        salesSeries2.ChartType = SeriesChartType.Column

        profitSeries2.IsValueShownAsLabel = True
        salesSeries2.IsValueShownAsLabel = True

        Try
            reader2 = cmd2.ExecuteReader()
            Dim index As Integer = 0

            While reader2.Read()
                Dim day = reader2("Day").ToString()
                Dim profit = Convert.ToDecimal(reader2("Profit"))
                Dim sales = Convert.ToDecimal(reader2("Sales_Total"))

                ' Profit to Chart2
                Dim profitPoint As New DataPoint()
                profitPoint.SetValueXY(day, profit)
                profitSeries2.Points.Add(profitPoint)

                ' Sales to Chart4
                Dim salesPoint As New DataPoint()
                salesPoint.SetValueXY(day, sales)
                salesSeries2.Points.Add(salesPoint)

                index += 1
            End While

            Chart2.Series.Add(profitSeries2)
            Chart4.Series.Add(salesSeries2)

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
                        profitlbl.Text = "Profit: " & dailyProfit.ToString("C2")
                    End If

                    If Not IsDBNull(reader("TotalSales")) Then
                        dailySales_total = Convert.ToDecimal(reader("TotalSales"))
                        salesTotallbl.Text = "Sales: " & dailySales_total.ToString("C2")
                    End If
                End If
            End Using
            con.Close()
        End Using

        ' Update labels

        ' Make sure this label exists
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
        Me.STOCKSTableAdapter.Fill(Me.SHITSTEMDataSet.STOCKS)
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

End Class
