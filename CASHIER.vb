Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Drawing.Text
Imports System.Globalization
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Web.Util
Imports Guna.UI2.WinForms
Imports Microsoft.VisualBasic.ApplicationServices
Public Class CASHIER

    Public Property user_Role As String
    Public Property user_id As String

    Private singleClickTimer As New Timer()
    Private clickedButtonForSingleClick As Guna2Button
    Private clickCancelled As Boolean = False

    Private Sub CASHIER_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If con IsNot Nothing AndAlso con.State = ConnectionState.Open Then con.Close()
        Opencon()

        con.Close()
        ' --- Set up the Delete Button Column in the DataGridView ---
        Dim deleteButtonColumn As New DataGridViewButtonColumn()
        deleteButtonColumn.Name = "DeleteButton"
        deleteButtonColumn.HeaderText = " "
        deleteButtonColumn.Text = "−"
        deleteButtonColumn.Width = 25
        deleteButtonColumn.UseColumnTextForButtonValue = True


        If Not OrdersDataGridView.Columns.Contains("DeleteButton") Then
            OrdersDataGridView.Columns.Add(deleteButtonColumn)
        End If

        If OrdersDataGridView.Columns.Contains("Item_No") Then
            OrdersDataGridView.Columns("Item_No").Visible = False
        Else
            MessageBox.Show("Warning: Could not find 'Item_No' column in the grid to hide it.", "Column Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

        Try
            Me.OrdersTableAdapter.Fill(Me.SHITSTEMDataSet.Orders)
        Catch ex As Exception
            MessageBox.Show($"Error loading initial orders: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

        For Each column As DataGridViewColumn In OrdersDataGridView.Columns
            If Not String.IsNullOrEmpty(column.DataPropertyName) Then
                column.Name = column.DataPropertyName
            End If
        Next

        OrdersDataGridView.ClearSelection()
        OrdersDataGridView.CurrentCell = Nothing

        resetcart()


        AddHandler OrdersDataGridView.CellValueChanged, AddressOf UpdateTotalSum
        AddHandler OrdersDataGridView.RowsRemoved, AddressOf UpdateTotalSum
        AddHandler OrdersDataGridView.RowsAdded, AddressOf UpdateTotalSum

        AddHandler singleClickTimer.Tick, AddressOf SingleClickTimer_Tick
        singleClickTimer.Interval = SystemInformation.DoubleClickTime

        ResetRevenueIfNewDay()
        countingproducts()
        GenerateProductButtons()

        discount_choice.Text = "NONE"
    End Sub

    Private Sub ResetRevenueIfNewDay()
        Try
            Opencon()
            Dim todayDate As Date = Date.Today

            Dim selectQuery As String = "
            SELECT user_id, revenue, dateofremittance, firstname, lastname
            FROM login
            WHERE role IN ('Owner','Manager','Employee')
        "
            Dim usersToReset As New List(Of (userId As String, revenue As Decimal, firstName As String, lastName As String))

            Using cmd As New SqlCommand(selectQuery, con)
                Using reader As SqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim userId = reader("user_id").ToString()
                        Dim revenueAmt = If(reader.IsDBNull(reader.GetOrdinal("revenue")), 0D, Convert.ToDecimal(reader("revenue")))
                        Dim lastResetVal = reader("dateofremittance")
                        Dim lastReset As Date? = If(lastResetVal Is DBNull.Value, CType(Nothing, Date?), CType(lastResetVal, Date))
                        If (Not lastReset.HasValue OrElse lastReset.Value.Date <> todayDate) AndAlso revenueAmt > 0 Then
                            usersToReset.Add((userId, revenueAmt, reader("firstname").ToString(), reader("lastname").ToString()))
                        End If
                    End While
                End Using
            End Using

            ' 2) Now reader is closed, do inserts & updates
            For Each u In usersToReset
                ' Insert into remittancehistory
                Using insertCmd As New SqlCommand("
                INSERT INTO remittancehistory
                  (User_id, revenue, date, firstname, lastname)
                VALUES
                  (@User_id, @revenue, @date, @firstname, @lastname)
            ", con)
                    insertCmd.Parameters.AddWithValue("@User_id", u.userId)
                    insertCmd.Parameters.AddWithValue("@revenue", u.revenue)
                    insertCmd.Parameters.AddWithValue("@date", todayDate)
                    insertCmd.Parameters.AddWithValue("@firstname", u.firstName)
                    insertCmd.Parameters.AddWithValue("@lastname", u.lastName)
                    insertCmd.ExecuteNonQuery()
                End Using

                ' Reset login.revenue & update dateofremittance
                Using resetCmd As New SqlCommand("
                UPDATE login
                SET revenue = 0,
                    dateofremittance = @today
                WHERE user_id = @userID
            ", con)
                    resetCmd.Parameters.AddWithValue("@today", todayDate)
                    resetCmd.Parameters.AddWithValue("@userID", u.userId)
                    resetCmd.ExecuteNonQuery()
                End Using
            Next

        Catch ex As Exception
            MessageBox.Show("Error resetting employee revenues: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If con.State = ConnectionState.Open Then con.Close()
        End Try
    End Sub



    Private Sub countingproducts()
        Try
            Opencon()
            Dim query As String = "SELECT COUNT(*) FROM STOCKS"
            Using cmd As New SqlCommand(query, con)
                Dim count As Integer = CInt(cmd.ExecuteScalar())
                If count = 0 Then
                    MessageBox.Show("No products found in the database.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)

                End If

            End Using
        Catch ex As Exception
            MessageBox.Show($"Error counting products: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If con IsNot Nothing AndAlso con.State = ConnectionState.Open Then
                con.Close()
            End If
        End Try
    End Sub


    Private Sub GenerateProductButtons(Optional groupFilter As String = "", Optional searchTerm As String = "")
        FlowLayoutPanel1.Controls.Clear()

        If String.IsNullOrWhiteSpace(groupFilter) Then
            FlowLayoutPanel3.Controls.Clear()
        End If

        Dim query As String = "SELECT Item_no, Product_name, Product_image,Price, product_group FROM STOCKS WHERE 1=1"
        Dim params As New List(Of SqlParameter)

        If Not String.IsNullOrWhiteSpace(searchTerm) Then
            query &= " AND (Item_no LIKE @searchPattern OR Product_name LIKE @searchPattern)"
            params.Add(New SqlParameter("@searchPattern", "%" & searchTerm & "%"))
        End If

        Try
            Opencon()
            Using cmd As New SqlCommand(query, con)
                If params.Count > 0 Then
                    cmd.Parameters.AddRange(params.ToArray())
                End If

                Using reader As SqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim itemNo As String = reader("Item_no").ToString()
                        Dim productName As String = reader("Product_name").ToString()
                        Dim productGroup As String = reader("product_group").ToString()
                        Dim price As String = reader("Price").ToString()


                        If Not String.IsNullOrWhiteSpace(groupFilter) AndAlso productGroup <> groupFilter AndAlso productGroup <> "Others" Then
                            Continue While
                        End If

                        Dim btn As New Guna2Button()
                        btn.Name = "DynamicGunaBtn_" & itemNo
                        btn.Text = productName & " Price: " & price
                        btn.Size = New Size(200, 200)
                        btn.Margin = New Padding(10)
                        btn.BorderRadius = 15
                        btn.BorderThickness = 2
                        btn.FillColor = Color.Transparent
                        btn.ForeColor = Color.Black
                        btn.TextOffset = New Point(0, 40)
                        btn.ImageSize = New Size(60, 60)
                        btn.TextAlign = HorizontalAlignment.Center
                        btn.ImageAlign = HorizontalAlignment.Center
                        btn.Tag = itemNo

                        If Not IsDBNull(reader("Product_image")) Then
                            Try
                                Dim imageBytes As Byte() = CType(reader("Product_image"), Byte())
                                Using ms As New MemoryStream(imageBytes)
                                    btn.BackgroundImage = Image.FromStream(ms)
                                    btn.BackgroundImageLayout = ImageLayout.Stretch
                                End Using
                            Catch exImg As Exception
                                btn.Text = productName & vbCrLf & "(No Img)"
                            End Try
                        Else
                            btn.Text = productName & vbCrLf & "(No Img)"
                        End If

                        AddHandler btn.Click, AddressOf DynamicButton_Click
                        AddHandler btn.DoubleClick, AddressOf DynamicButton_DoubleClick

                        If productGroup = "Others" Then
                            If String.IsNullOrWhiteSpace(groupFilter) Then
                                btn.Size = New Size(120, 120)
                                btn.Margin = New Padding(30, 0, 30, 30)
                                FlowLayoutPanel3.Controls.Add(btn)
                            ElseIf FlowLayoutPanel3.Controls.Find("DynamicGunaBtn_" & itemNo, False).Length = 0 Then
                                btn.Size = New Size(120, 120)
                                FlowLayoutPanel3.Controls.Add(btn)
                            End If
                        Else
                            FlowLayoutPanel1.Controls.Add(btn)
                        End If
                    End While
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error generating product buttons: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If con IsNot Nothing AndAlso con.State = ConnectionState.Open Then
                con.Close()
            End If
        End Try
    End Sub


    Private Sub DynamicButton_Click(sender As Object, e As EventArgs)
        clickedButtonForSingleClick = DirectCast(sender, Guna2Button)
        clickCancelled = False
        singleClickTimer.Start()
    End Sub
    Private Sub SingleClickTimer_Tick(sender As Object, e As EventArgs)
        singleClickTimer.Stop()

        If Not clickCancelled Then
            ' Perform the single-click action
            If clickedButtonForSingleClick IsNot Nothing AndAlso clickedButtonForSingleClick.Tag IsNot Nothing Then
                Dim specificItemNo As String = DirectCast(clickedButtonForSingleClick.Tag, String)
                Dim productGroup As String = ""
                Dim quantityToAdd As Integer = 1

                Dim queryGroup As String = "SELECT product_group FROM STOCKS WHERE Item_no = @itemNoParam"
                Try
                    Opencon()
                    Using cmdGroup As New SqlCommand(queryGroup, con)
                        cmdGroup.Parameters.AddWithValue("@itemNoParam", specificItemNo)
                        Dim result = cmdGroup.ExecuteScalar()
                        If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                            productGroup = result.ToString()
                        End If
                    End Using
                Catch ex As Exception
                    MessageBox.Show($"Error getting product group: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    If con IsNot Nothing AndAlso con.State = ConnectionState.Open Then con.Close()
                End Try

                If productGroup.Equals("Siomai", StringComparison.OrdinalIgnoreCase) Then
                    quantityToAdd = 4
                Else
                    quantityToAdd = 1
                End If

                Me.AddProductToCart(specificItemNo, quantityToAdd)
            End If
        End If
    End Sub


    Private Sub DynamicButton_DoubleClick(sender As Object, e As EventArgs)
        clickCancelled = True
        singleClickTimer.Stop()

        Dim clickedButton As Guna2Button = DirectCast(sender, Guna2Button)

        If clickedButton.Tag IsNot Nothing AndAlso TypeOf clickedButton.Tag Is String Then
            Dim specificItemNo As String = DirectCast(clickedButton.Tag, String)

            Using customForm As New custommultiplier()
                If customForm.ShowDialog() = DialogResult.OK Then
                    Dim quantityToAdd As Integer = customForm.CustomQuantity

                    If quantityToAdd > 0 Then
                        Me.AddProductToCart(specificItemNo, quantityToAdd)
                    Else
                        MessageBox.Show("Please enter a quantity greater than zero.")
                    End If
                End If
            End Using
        Else
            MessageBox.Show("Error: Button is missing associated product data (Item No).", "Button Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub AddProductToCart(ByVal itemNoToAdd As String, ByVal quantityToAdd As Integer)
        Dim localProductName As String = ""
        Dim currentStock As Integer = 0
        Dim unitPrice As Integer = 0

        Try
            Opencon()
            Dim queryDetails As String = "SELECT Product_name, quantity,price FROM STOCKS WHERE Item_no = @Item_no"
            Using cmdDetails As New SqlCommand(queryDetails, con)
                cmdDetails.Parameters.AddWithValue("@Item_no", itemNoToAdd)
                Using reader As SqlDataReader = cmdDetails.ExecuteReader()
                    If reader.Read() Then
                        localProductName = reader("Product_name").ToString()
                        currentStock = Convert.ToInt32(reader("quantity"))
                        unitPrice = reader("price")

                    Else
                        MessageBox.Show("Item not found in stocks.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error fetching product details: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        Finally
            If con IsNot Nothing AndAlso con.State = ConnectionState.Open Then con.Close()
        End Try

        If currentStock < quantityToAdd Then
            MessageBox.Show($"Not enough stock available for {localProductName}! Only {currentStock} left.", "Stock Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Opencon()

            Dim existingCartQuantity As Integer = 0
            Dim checkCartQuery As String = "SELECT Quantity FROM Orders WHERE Item_No = @Item_No"

            Using cmdCheck As New SqlCommand(checkCartQuery, con)
                cmdCheck.Parameters.AddWithValue("@Item_No", itemNoToAdd)
                Dim result = cmdCheck.ExecuteScalar()
                If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                    existingCartQuantity = Convert.ToInt32(result)
                End If
            End Using

            Dim sellingPrice As Integer = unitPrice

            If existingCartQuantity > 0 Then
                Dim newQuantity As Integer = existingCartQuantity + quantityToAdd
                Dim newTotalPrice As Integer = newQuantity * sellingPrice
                Dim updateQuery As String = "UPDATE Orders SET Quantity = @Quantity, Total_price = @TotalPrice WHERE Item_No = @Item_No"

                Using updateCmd As New SqlCommand(updateQuery, con)
                    updateCmd.Parameters.AddWithValue("@Quantity", newQuantity)
                    updateCmd.Parameters.AddWithValue("@TotalPrice", newTotalPrice)
                    updateCmd.Parameters.AddWithValue("@Item_No", itemNoToAdd)
                    updateCmd.ExecuteNonQuery()
                End Using
            Else
                Dim newTotalPrice As Integer = quantityToAdd * sellingPrice
                Dim insertQuery As String = "INSERT INTO Orders (Item_No, Product_name, Quantity, Price, Total_price, OrderDate) VALUES (@Item_No, @Product_name, @Quantity, @Price, @Total_price, @OrderDate)"

                Using insertCmd As New SqlCommand(insertQuery, con)
                    insertCmd.Parameters.AddWithValue("@Item_No", itemNoToAdd)
                    insertCmd.Parameters.AddWithValue("@Product_name", localProductName)
                    insertCmd.Parameters.AddWithValue("@Quantity", quantityToAdd)
                    insertCmd.Parameters.AddWithValue("@Price", sellingPrice)
                    insertCmd.Parameters.AddWithValue("@Total_price", newTotalPrice)
                    insertCmd.Parameters.AddWithValue("@OrderDate", DateTime.Now.Date)
                    insertCmd.ExecuteNonQuery()
                End Using
            End If


            Dim updateStockQuery As String = "UPDATE STOCKS SET quantity = quantity - @quantitySold WHERE Item_No = @Item_No"
            Using stockCmd As New SqlCommand(updateStockQuery, con)
                stockCmd.Parameters.AddWithValue("@quantitySold", quantityToAdd)
                stockCmd.Parameters.AddWithValue("@Item_No", itemNoToAdd)
                stockCmd.ExecuteNonQuery()
            End Using


            Me.OrdersTableAdapter.Fill(Me.SHITSTEMDataSet.Orders)

        Catch ex As Exception
            MessageBox.Show($"Error adding/updating product in cart: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            If con IsNot Nothing AndAlso con.State = ConnectionState.Open Then con.Close()
        End Try

    End Sub


    Private Async Sub checkoutbtn_Click(sender As Object, e As EventArgs) Handles checkoutbtn.Click
        Dim paymentAmount As Integer = 0
        Dim totalSum As Integer = 0

        ' --- Input Validation ---
        If String.IsNullOrWhiteSpace(paymenttxtbox.Text) Then
            MessageBox.Show("Please enter a payment amount.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            paymenttxtbox.Focus()
            Return
        End If

        If Not Integer.TryParse(paymenttxtbox.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, paymentAmount) AndAlso
           Not Integer.TryParse(paymenttxtbox.Text, paymentAmount) Then
            MessageBox.Show("Invalid payment amount. Please enter a valid number.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            paymenttxtbox.SelectAll()
            paymenttxtbox.Focus()
            Return
        End If

        ' --- Get Total Sum from Label ---
        Dim cleanTotal As String = lbltotal.Text.Replace("₱", "").Replace(",", "").Trim()
        If Not Decimal.TryParse(cleanTotal, totalSum) Then
            MessageBox.Show("Could not read the total sum from the label.", "Internal Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' --- Check if cart is empty ---
        If totalSum <= 0 Then
            MessageBox.Show("The cart is empty. Please add items before checking out.", "Empty Cart", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If


        ' --- Check Payment Amount ---
        If paymentAmount < totalSum Then
            MessageBox.Show("Payment amount is less than the total sum. Please enter a sufficient amount.", "Payment Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            paymenttxtbox.SelectAll()
            paymenttxtbox.Focus()
            Return
        End If

        ' --- Calculate Change ---
        Dim changeAmount As Integer = paymentAmount - totalSum

        Dim salesTotalForReport As Integer = 0
        Dim totalProfitForReport As Integer = 0

        Try
            For Each row As DataGridViewRow In OrdersDataGridView.Rows
                If Not row.IsNewRow Then

                    Dim itemNo As Integer = Convert.ToInt32(row.Cells("Item_no").Value)
                    Dim sellingPrice As Integer = row.Cells("Price").Value
                    Dim quantity As Integer = Convert.ToInt32(row.Cells("Quantity").Value)

                    ' --- Retrieve the cost from STOCKS table based on Item_no ---
                    Dim cost As Integer = 0
                    Dim query As String = "SELECT Cost FROM STOCKS WHERE Item_no = @Item_no"
                    Using cmd As New SqlCommand(query, con)
                        cmd.Parameters.AddWithValue("@Item_no", itemNo)
                        If con.State = ConnectionState.Closed Then
                            con.Open()
                        End If
                        Using reader As SqlDataReader = cmd.ExecuteReader()
                            If reader.HasRows Then
                                reader.Read()
                                cost = reader("Cost")
                            Else
                                MessageBox.Show($"Error: Item with number {itemNo} not found in STOCKS.", "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Return
                            End If
                        End Using
                    End Using

                    Dim itemTotal As Integer = sellingPrice * quantity
                    salesTotalForReport += itemTotal

                    Dim itemProfit As Integer = (sellingPrice - cost) * quantity
                    totalProfitForReport += itemProfit
                End If
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
            Next

            If Math.Abs(salesTotalForReport - totalSum) > 0.001D Then
                MessageBox.Show($"Warning: Calculated total ({salesTotalForReport:C}) doesn't match label ({totalSum:C}). Proceeding with label total.", "Calculation Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                salesTotalForReport = totalSum

            End If

            Opencon()
            Dim today As Date = Date.Today
            Dim calendar = CultureInfo.CurrentCulture.Calendar

            ' === DAILY SALES RESET ===
            Dim resetDaily As Boolean = False

            Dim dailyQueryreset As String = "SELECT TOP 1 [Day] FROM Dailysales ORDER BY [Day] DESC"
            Using dailyCmd As New SqlCommand(dailyQueryreset, con)
                Dim lastDailyDateObj = dailyCmd.ExecuteScalar()
                If lastDailyDateObj IsNot Nothing Then
                    Dim lastDailyDate As Date
                    If Date.TryParse(lastDailyDateObj.ToString(), lastDailyDate) Then
                        If lastDailyDate.Date <> today Then
                            resetDaily = True
                        End If
                    End If
                Else
                    ' No records exist at all
                    resetDaily = False ' (optional — you could keep it False since it's empty)
                End If
            End Using

            If resetDaily Then
                Dim resetQuery As String = "DELETE FROM Dailysales"
                Using resetCmd As New SqlCommand(resetQuery, con)
                    resetCmd.ExecuteNonQuery()
                End Using
            End If

            ' === INSERT for TODAY ===
            Dim insertDailyQuery As String = "INSERT INTO Dailysales (Day, Sales_total, Profit) VALUES (@Day, @Sales_total, @Profit)"
            Using cmdDaily As New SqlCommand(insertDailyQuery, con)
                cmdDaily.Parameters.AddWithValue("@Day", today)
                cmdDaily.Parameters.AddWithValue("@Sales_total", salesTotalForReport)
                cmdDaily.Parameters.AddWithValue("@Profit", totalProfitForReport)
                cmdDaily.ExecuteNonQuery()
            End Using


            ' --- WEEKLY SALES RESET ---
            Dim currentDay As String = DateTime.Today.DayOfWeek.ToString()
            Dim resetWeek As Boolean = False

            Dim weeklyCheckQuery As String = "SELECT COUNT(*) FROM WeeklySales"
            Using checkCmd As New SqlCommand(weeklyCheckQuery, con)
                Dim count = Convert.ToInt32(checkCmd.ExecuteScalar())
                If count >= 7 Then
                    ' If all 7 weekdays have been filled, reset weekly sales
                    resetWeek = True
                End If
            End Using

            If resetWeek Then
                Dim resetWeeklyQuery As String = "DELETE FROM WeeklySales"
                Using resetCmd As New SqlCommand(resetWeeklyQuery, con)
                    resetCmd.ExecuteNonQuery()
                End Using
            End If

            Dim currentDayOfWeek As String = DateTime.Today.DayOfWeek.ToString()

            Dim weeklyQuery As String = "
    IF EXISTS (SELECT 1 FROM WeeklySales WHERE Day = @dayParam)
        UPDATE WeeklySales 
        SET Sales_total = Sales_total + @Sales_total, 
            Profit = Profit + @Profit 
        WHERE Day = @dayParam
    ELSE
        INSERT INTO WeeklySales (Day, Sales_total, Profit) 
        VALUES (@dayParam, @Sales_total, @Profit)"

            Using cmdWeekly As New SqlCommand(weeklyQuery, con)
                cmdWeekly.Parameters.AddWithValue("@dayParam", currentDayOfWeek)
                cmdWeekly.Parameters.AddWithValue("@Sales_total", salesTotalForReport)
                cmdWeekly.Parameters.AddWithValue("@Profit", totalProfitForReport)
                cmdWeekly.ExecuteNonQuery()
            End Using

            ' === MONTHLY SALES RESET ===
            Dim today1 As Date = Date.Today
            Dim currentMonthName As String = today1.ToString("MMMM") ' e.g., "April"
            Dim resetMonthly As Boolean = False

            Dim monthlyQueryreset As String = "SELECT TOP 1 [Month] FROM Monthlysales ORDER BY [Month] DESC"
            Using monthlyCmd As New SqlCommand(monthlyQueryreset, con)
                Dim lastMonthlyMonthObj = monthlyCmd.ExecuteScalar()
                If lastMonthlyMonthObj IsNot Nothing Then
                    Dim lastMonthlyMonth As String = lastMonthlyMonthObj.ToString()
                    If Not lastMonthlyMonth.Equals(currentMonthName, StringComparison.OrdinalIgnoreCase) Then
                        resetMonthly = True
                    End If
                End If
            End Using

            ' === INSERT or UPDATE for the current month ===
            Dim monthlyUpsertQuery As String = "
    IF EXISTS (SELECT 1 FROM MonthlySales WHERE Month = @Month)
        UPDATE MonthlySales
        SET Sales_total = Sales_total + @Sales_total,
            Profit = Profit + @Profit
        WHERE Month = @Month
    ELSE
        INSERT INTO MonthlySales (Month, Sales_total, Profit)
        VALUES (@Month, @Sales_total, @Profit)"

            Using cmdMonthly As New SqlCommand(monthlyUpsertQuery, con)
                cmdMonthly.Parameters.AddWithValue("@Month", currentMonthName)
                cmdMonthly.Parameters.AddWithValue("@Sales_total", salesTotalForReport)
                cmdMonthly.Parameters.AddWithValue("@Profit", totalProfitForReport)
                cmdMonthly.ExecuteNonQuery()
            End Using

            ' === HANDLE YEARLY SALES ===
            Try
                If con.State = ConnectionState.Closed Then con.Open()

                Dim todayDate As Date = Date.Today
                Dim currentYear As String = todayDate.Year.ToString() ' e.g., "2024"
                Dim resetYearly As Boolean = False

                ' Step 1: Check if reset is needed
                Dim yearlyQueryReset As String = "SELECT TOP 1 [Year] FROM YearlySales ORDER BY [Year] DESC"
                Using yearlyCmd As New SqlCommand(yearlyQueryReset, con)
                    Dim lastYearlyYearObj = yearlyCmd.ExecuteScalar()
                    If lastYearlyYearObj IsNot Nothing Then
                        Dim lastYearlyYear As String = lastYearlyYearObj.ToString()
                        If Not lastYearlyYear.Equals(currentYear, StringComparison.OrdinalIgnoreCase) Then
                            resetYearly = True
                        End If
                    End If
                End Using


                ' Step 3: Insert or Update YearlySales
                Dim yearlyUpsertQuery As String = "
    IF EXISTS (SELECT 1 FROM YearlySales WHERE Year = @Year)
        UPDATE YearlySales
        SET Sales_total = Sales_total + @Sales_total,
            Profit = Profit + @Profit
        WHERE Year = @Year
    ELSE
        INSERT INTO YearlySales (Year, Sales_total, Profit)
        VALUES (@Year, @Sales_total, @Profit)"

                Using cmdYearly As New SqlCommand(yearlyUpsertQuery, con)
                    cmdYearly.Parameters.AddWithValue("@Year", currentYear)
                    cmdYearly.Parameters.AddWithValue("@Sales_total", salesTotalForReport)
                    cmdYearly.Parameters.AddWithValue("@Profit", totalProfitForReport)
                    cmdYearly.ExecuteNonQuery()
                End Using


                ' === UPDATE employee's revenue ===
                Dim updateRevenueQuery As String = "
UPDATE login 
SET revenue = ISNULL(revenue, 0) + @earnedToday 
WHERE user_id = @userID
"

                Using cmdUpdateRevenue As New SqlCommand(updateRevenueQuery, con)
                    cmdUpdateRevenue.Parameters.AddWithValue("@earnedToday", salesTotalForReport)
                    cmdUpdateRevenue.Parameters.AddWithValue("@userID", user_id)
                    cmdUpdateRevenue.ExecuteNonQuery()
                End Using

            Catch ex As Exception
                MessageBox.Show("Error updating YearlySales: " & ex.Message)
            Finally
                If con.State = ConnectionState.Open Then con.Close()
            End Try




            Dim totalItemCount As Integer = 0

            For Each row As DataGridViewRow In OrdersDataGridView.Rows
                If Not row.IsNewRow Then
                    totalItemCount += Convert.ToInt32(row.Cells("Quantity").Value)
                End If
            Next


            Dim transactionId As Integer
            Dim insertTransactionQuery As String = "
INSERT INTO Transactions (TransactionDate, TotalAmount, PaymentAmount, ChangeGiven, Total_Item, Profit, Discount) 
OUTPUT INSERTED.TransactionID 
VALUES (@TransactionDate, @TotalAmount, @PaymentAmount, @ChangeGiven, @Total_Item, @Profit, @Discount)"
            Using transactionCmd As New SqlCommand(insertTransactionQuery, con)
                transactionCmd.Parameters.AddWithValue("@TransactionDate", DateTime.Now)
                transactionCmd.Parameters.AddWithValue("@TotalAmount", totalSum)
                transactionCmd.Parameters.AddWithValue("@PaymentAmount", paymentAmount)
                transactionCmd.Parameters.AddWithValue("@ChangeGiven", changeAmount)
                transactionCmd.Parameters.AddWithValue("@Total_Item", totalItemCount)
                transactionCmd.Parameters.AddWithValue("@Profit", totalProfitForReport)

                Dim discountText As String = discount_choice.Text
                transactionCmd.Parameters.AddWithValue("@Discount", discountText)

                If con.State = ConnectionState.Closed Then con.Open()
                transactionId = Convert.ToInt32(transactionCmd.ExecuteScalar())
            End Using




            ' STEP 1: Clear the DailySummary table
            Dim clearSummaryQuery As String = "DELETE FROM DailySummary"
            Using clearCmd As New SqlCommand(clearSummaryQuery, con)
                clearCmd.ExecuteNonQuery()
            End Using

            ' STEP 2: Insert new grouped summary using actual TransactionDate
            Dim insertSummaryQuery As String = "
    INSERT INTO DailySummary (Product_name, Quantity, OrderDate, Revenue)
    SELECT 
        s.Product_name,
        SUM(o.Quantity) AS TotalQuantity,
        t.TransactionDate,
        SUM(o.Quantity * o.Price) AS TotalRevenue
    FROM Orders o
    INNER JOIN STOCKS s ON o.Item_No = s.Item_No
    CROSS JOIN (SELECT TransactionDate FROM Transactions WHERE TransactionID = @TransactionID) t
    GROUP BY s.Product_name, t.TransactionDate"



            Using insertCmd As New SqlCommand(insertSummaryQuery, con)
                insertCmd.Parameters.AddWithValue("@TransactionID", transactionId)
                insertCmd.ExecuteNonQuery()
            End Using


            Dim receiptForm As New RECEIPT()
            receiptForm.LoadReport(paymentAmount, changeAmount)
            receiptForm.ShowDialog()




            InsertTransactionDetails(transactionId)

            lbltotal.Text = "₱0.00"
        Catch ex As Exception
            MessageBox.Show($"Error during checkout process: {ex.Message}", "Checkout Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            If con IsNot Nothing AndAlso con.State = ConnectionState.Open Then
                con.Close()
            End If

            MessageBox.Show("Checkout complete!" & vbCrLf & vbCrLf &
    $"Total Sale: ₱{salesTotalForReport:N2}" & vbCrLf &
    $"Payment Received: ₱{paymentAmount:N2}" & vbCrLf &
    $"Change Due: ₱{changeAmount:N2}",
    "Transaction Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
            UpdateRevenueAndRecordHistory(user_id, salesTotalForReport)

            resetcart()
            paymenttxtbox.Clear()
        End Try
    End Sub

    Private Sub InsertTransactionDetails(transactionID As Integer)
        If con IsNot Nothing AndAlso con.State = ConnectionState.Open Then
            con.Close()
        End If
        Try

            Opencon()

            ' Step 1: Load all current Orders into a list first
            Dim ordersQuery As String = "
            SELECT Item_no, Product_name, Quantity
            FROM Orders
        "

            Dim orderList As New List(Of (itemNo As String, productName As String, quantity As Integer))

            ' Read all orders into memory
            Using cmd As New SqlCommand(ordersQuery, con)
                Using reader As SqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim itemNo As String = reader("Item_no").ToString()
                        Dim productName As String = reader("Product_name").ToString()
                        Dim quantity As Integer = Convert.ToInt32(reader("Quantity"))
                        orderList.Add((itemNo, productName, quantity))
                    End While
                End Using
            End Using
            ' === Now the DataReader is closed ===

            ' Step 2: Get the TransactionDate from Transactions table
            Dim transactionDateQuery As String = "
            SELECT TransactionDate
            FROM Transactions
            WHERE TransactionID = @transactionID
        "
            Dim transactionDate As Date

            Using cmdDate As New SqlCommand(transactionDateQuery, con)
                cmdDate.Parameters.AddWithValue("@transactionID", transactionID)
                transactionDate = CDate(cmdDate.ExecuteScalar())
            End Using

            ' Step 3: Now insert all orders into TransactionDetails
            For Each order In orderList
                Dim insertQuery As String = "
                INSERT INTO TransactionDetails (transactionID, Item_no, Product_name, Quantity, date)
                VALUES (@transactionID, @Item_no, @Product_name, @Quantity, @date)
            "
                Using cmdInsert As New SqlCommand(insertQuery, con)
                    cmdInsert.Parameters.AddWithValue("@transactionID", transactionID)
                    cmdInsert.Parameters.AddWithValue("@Item_no", order.itemNo)
                    cmdInsert.Parameters.AddWithValue("@Product_name", order.productName)
                    cmdInsert.Parameters.AddWithValue("@Quantity", order.quantity)
                    cmdInsert.Parameters.AddWithValue("@date", transactionDate)
                    cmdInsert.ExecuteNonQuery()
                End Using
            Next

        Catch ex As Exception
            MessageBox.Show("Error inserting transaction details: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If con.State = ConnectionState.Open Then con.Close()
        End Try
    End Sub



    Private Sub UpdateRevenueAndRecordHistory(userId As String, earnedToday As Decimal)
        Try
            Opencon()

            ' Step 1: Add the earned revenue to the existing revenue in login
            Dim updateRevenueQuery As String = "
        UPDATE login 
        SET revenue = ISNULL(revenue, 0) + @earnedToday 
        WHERE user_id = @userID
        "

            Using cmdUpdateRevenue As New SqlCommand(updateRevenueQuery, con)
                cmdUpdateRevenue.Parameters.AddWithValue("@earnedToday", earnedToday)
                cmdUpdateRevenue.Parameters.AddWithValue("@userID", userId)
                cmdUpdateRevenue.ExecuteNonQuery()
            End Using

        Catch ex As Exception
            MessageBox.Show("Error updating revenue: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If con.State = ConnectionState.Open Then con.Close()
        End Try
    End Sub


    Public Sub resetcart()
        Try
            con.Open()
            Dim delquery As String = "DELETE FROM Orders"
            Using cmd As New SqlCommand(delquery, con)
                cmd.ExecuteNonQuery()
            End Using

            Me.OrdersTableAdapter.Fill(Me.SHITSTEMDataSet.Orders)

        Catch ex As Exception
            MessageBox.Show($"Error resetting cart: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If con IsNot Nothing AndAlso con.State = ConnectionState.Open Then
                con.Close()
            End If
        End Try

        UpdateTotalSum(Me, EventArgs.Empty)
        OrdersDataGridView.ClearSelection()
        discount_choice.Text = "NONE"
    End Sub

    Private Sub UpdateTotalSum(sender As Object, e As EventArgs)
        Try
            Dim totalSum As Integer = 0
            For Each row As DataGridViewRow In OrdersDataGridView.Rows
                ' Check if it's not the new row placeholder and the cell has a value
                If Not row.IsNewRow AndAlso row.Cells("Total_price") IsNot Nothing AndAlso row.Cells("Total_price").Value IsNot Nothing AndAlso Not IsDBNull(row.Cells("Total_price").Value) Then
                    totalSum += row.Cells("Total_price").Value
                End If
            Next
            lbltotal.Text = totalSum.ToString("C", CultureInfo.GetCultureInfo("en-PH")) ' Format as Philippine Peso
            If totalSum = 0 Then
                Guna2Button1.Visible = False
            Else
                Guna2Button1.Visible = True
            End If
        Catch ex As FormatException
            MessageBox.Show($"Error formatting total: {ex.Message}. Check data in Total_price column.", "Formatting Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Catch ex As Exception
            MessageBox.Show($"Error calculating total: {ex.Message}", "Calculation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub


    Private Sub UpdateItemQuantityInCart(ByVal itemNoToUpdate As String, ByVal newQuantity As Integer)

        Dim sellingPrice As Integer = 0
        Dim newTotalPrice As Integer = 0

        Try
            Opencon()
            Dim getPriceQuery As String = "SELECT Price FROM Orders WHERE Item_No = @Item_No"
            Using cmdGetPrice As New SqlCommand(getPriceQuery, con)
                cmdGetPrice.Parameters.AddWithValue("@Item_No", itemNoToUpdate)
                Dim result = cmdGetPrice.ExecuteScalar()
                If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                    sellingPrice = result
                Else
                    MessageBox.Show($"Could not find selling price for item {itemNoToUpdate} in cart.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If
            End Using

            newTotalPrice = newQuantity * sellingPrice

            ' Now, update the Orders table
            Dim updateQuery As String = "UPDATE Orders SET Quantity = @Quantity, Total_price = @TotalPrice WHERE Item_No = @Item_No"
            Using updateCmd As New SqlCommand(updateQuery, con)
                updateCmd.Parameters.AddWithValue("@Quantity", newQuantity)
                updateCmd.Parameters.AddWithValue("@TotalPrice", newTotalPrice)
                updateCmd.Parameters.AddWithValue("@Item_No", itemNoToUpdate)
                updateCmd.ExecuteNonQuery()
            End Using


            Me.OrdersTableAdapter.Fill(Me.SHITSTEMDataSet.Orders)
            ' Total label updates via event handlers

        Catch ex As Exception
            MessageBox.Show($"Error updating item quantity in cart: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If con IsNot Nothing AndAlso con.State = ConnectionState.Open Then con.Close()
        End Try

        ' UpdateTotalSum(Me, EventArgs.Empty) ' Should happen automatically via event handler
    End Sub

    ' --- Handles Clicks within the Orders DataGridView (Specifically for the Delete Button) ---
    Private Sub OrdersDataGridView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) _
    Handles OrdersDataGridView.CellContentClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex = OrdersDataGridView.Columns("DeleteButton").Index Then
            Dim rawItemNo As String = OrdersDataGridView.Rows(e.RowIndex).Cells("Item_No").Value.ToString()
            Dim paddedItemNo As String = ""
            Dim itemNoInt As Integer

            If Integer.TryParse(rawItemNo, itemNoInt) Then
                paddedItemNo = itemNoInt.ToString("D3")
            Else
                MessageBox.Show("Invalid Item_No format.")
                Return
            End If


            Dim currentQty As Integer = Convert.ToInt32(OrdersDataGridView.Rows(e.RowIndex).Cells("Quantity").Value)

            If currentQty > 1 Then
                Dim newQty = currentQty - 1
                RestockItem(paddedItemNo, 1)
                UpdateItemQuantityInCart(rawItemNo, newQty)
            Else
                DeleteItemFromCart(rawItemNo)
            End If

            UpdateTotalSum(Me, EventArgs.Empty)
        End If
    End Sub


    ' --- Increases Stock Quantity in the STOCKS Table ---
    Private Sub RestockItem(ByVal paddedItemNo As String, ByVal quantityToReturn As Integer)
        Try
            Opencon()
            Dim updateStockQuery As String =
            "UPDATE STOCKS 
               SET Quantity = Quantity + @qty 
             WHERE Item_No = @Item_No"
            Using cmd As New SqlCommand(updateStockQuery, con)
                cmd.Parameters.AddWithValue("@qty", quantityToReturn)
                cmd.Parameters.AddWithValue("@Item_No", paddedItemNo)
                cmd.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error restocking item {paddedItemNo}: {ex.Message}",
                        "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If con IsNot Nothing AndAlso con.State = ConnectionState.Open Then con.Close()
        End Try
    End Sub


    Private Sub DeleteItemFromCart(ByVal rawItemNo As String)
        Dim quantityToReturn As Integer = 0
        Dim itemNoInt As Integer
        Dim paddedItemNo As String = ""

        If Integer.TryParse(rawItemNo, itemNoInt) Then
            paddedItemNo = itemNoInt.ToString("D3")
        Else
            MessageBox.Show("Invalid Item_No format.")
            Return
        End If

        Try
            Opencon()
            Using qtyCmd As New SqlCommand("SELECT Quantity FROM Orders WHERE Item_No = @Item_No", con)
                qtyCmd.Parameters.AddWithValue("@Item_No", rawItemNo)
                Dim result = qtyCmd.ExecuteScalar()
                If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                    quantityToReturn = Convert.ToInt32(result)
                Else
                    Debug.Print($"Item {rawItemNo} not found in Orders table.")
                    Return
                End If
            End Using
            Using deleteCmd As New SqlCommand("DELETE FROM Orders WHERE Item_No = @Item_No", con)
                deleteCmd.Parameters.AddWithValue("@Item_No", rawItemNo)
                deleteCmd.ExecuteNonQuery()
            End Using
            If quantityToReturn > 0 Then
                Using stockCmd As New SqlCommand(
                    "UPDATE STOCKS 
                     SET Quantity = Quantity + @qty 
                     WHERE Item_No = @paddedItemNo", con)

                    stockCmd.Parameters.AddWithValue("@qty", quantityToReturn)
                    stockCmd.Parameters.AddWithValue("@paddedItemNo", paddedItemNo)
                    Dim rows = stockCmd.ExecuteNonQuery()
                    If rows = 0 Then
                        Debug.Print($"Padded key {paddedItemNo} not found in STOCKS.")
                    End If
                End Using
            End If
            Me.OrdersTableAdapter.Fill(Me.SHITSTEMDataSet.Orders)
            UpdateTotalSum(Me, EventArgs.Empty)

        Catch ex As Exception
            MessageBox.Show($"Error returning stock for {rawItemNo}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If con.State = ConnectionState.Open Then con.Close()
        End Try
    End Sub



    ' --- Handles Form Closing Event (if user is Employee) ---
    Private Sub CASHIER_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        If user_Role = "Employee" Then
            LOGIN_PAGE.Show()
        Else
            Dim form2 As New Form2()
            form2.user_role = user_Role
            form2.user_id = user_id
            form2.Show()
        End If



        ReturnAllCartItemsAndClearOrders()
    End Sub
    Private Sub TextBoxSearch_TextChanged(sender As Object, e As EventArgs) Handles TextBoxSearch.TextChanged
        GenerateProductButtons(searchTerm:=TextBoxSearch.Text)
    End Sub
    ' --- Filter Button Click Handlers ---
    Private Sub FoodFilter_Click(sender As Object, e As EventArgs) Handles SiomaiFilter.Click
        HandleCategoryFilter(SiomaiFilter, "Siomai")
    End Sub
    Private Sub DrinksFilter_Click(sender As Object, e As EventArgs) Handles DrinksFilter.Click
        HandleCategoryFilter(DrinksFilter, "Drinks") ' Show only "Drinks" group
    End Sub
    Private Sub SiopaoFilter_Click(sender As Object, e As EventArgs) Handles SiopaoFilter.Click
        HandleCategoryFilter(SiopaoFilter, "Siopao")
    End Sub
    Private Sub Cancel_Click(sender As Object, e As EventArgs) Handles Cancel.Click
        HandleCategoryFilter(Cancel, Nothing)
    End Sub
    Private currentCategoryButton As Guna.UI2.WinForms.Guna2Button = Nothing

    Private Sub HandleCategoryFilter(clickedBtn As Guna.UI2.WinForms.Guna2Button, groupFilter As String)

        If String.IsNullOrEmpty(groupFilter) Then
            GenerateProductButtons() ' Show all
        Else
            GenerateProductButtons(groupFilter)
        End If
    End Sub
    Private Sub ReturnAllCartItemsAndClearOrders()

        Dim itemsToReturn As New List(Of (itemNo As String, qty As Integer))()

        Try
            Opencon()
            Dim queryReadOrders As String = "SELECT Item_no, Quantity FROM Orders"
            Using cmdRead As New SqlCommand(queryReadOrders, con)
                Using reader As SqlDataReader = cmdRead.ExecuteReader()
                    While reader.Read()
                        If reader("Item_no") IsNot Nothing AndAlso Not IsDBNull(reader("Item_no")) AndAlso
                           reader("Quantity") IsNot Nothing AndAlso Not IsDBNull(reader("Quantity")) Then

                            itemsToReturn.Add((
                                  itemNo:=CInt(reader("Item_no")).ToString("D3"),
                                  qty:=Convert.ToInt32(reader("Quantity"))
                            ))
                        End If
                    End While
                End Using
            End Using

            If itemsToReturn.Count > 0 Then

                For Each item In itemsToReturn
                    Dim updateStockQuery As String = "UPDATE STOCKS SET Quantity = Quantity + @qty WHERE Item_no = @itemNo"
                    Using cmdUpdateStock As New SqlCommand(updateStockQuery, con)
                        cmdUpdateStock.Parameters.AddWithValue("@qty", item.qty)
                        cmdUpdateStock.Parameters.AddWithValue("@itemNo", item.itemNo)
                        Dim rowsAffected As Integer = cmdUpdateStock.ExecuteNonQuery()
                        If rowsAffected = 0 Then
                            Debug.Print($"WARNING (CASHIER_Closed): Could not return stock for Item_no {item.itemNo}. Item not found in STOCKS?")
                        End If
                    End Using
                Next

                Dim queryDeleteOrders As String = "DELETE FROM Orders"
                Using cmdDelete As New SqlCommand(queryDeleteOrders, con)
                    cmdDelete.ExecuteNonQuery()
                End Using

                Debug.Print($"{itemsToReturn.Count} item types returned to stock due to form closure.")


            End If

        Catch ex As Exception

            Debug.Print($"Error during CASHIER_Closed cleanup: {ex.Message}")
            MessageBox.Show($"Error returning items to stock on close: {ex.Message}", "Cleanup Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If con IsNot Nothing AndAlso con.State = ConnectionState.Open Then con.Close()
        End Try
    End Sub



    Private Sub discount_choice_SelectedIndexChanged(sender As Object, e As EventArgs) Handles discount_choice.SelectedIndexChanged
        Discount()
    End Sub

    Dim highestproductname As String = ""
    Dim highestproductprice As Integer = 0D

    Public Sub Discount()
        Dim discountRate As Integer = 0

        ' 1. Determine the selected discount
        Select Case discount_choice.Text
            Case "PWD/SENIOR"
                discountRate = 0.2D
            Case "10%"
                discountRate = 0.1D
            Case "15%"
                discountRate = 0.15D
            Case Else
                discountRate = 0
        End Select

        Try
            Opencon()

            Dim resetQuery As String = "
            UPDATE O
SET O.Price = S.Price,
    O.Total_price = O.Quantity * S.Price
FROM Orders O
JOIN STOCKS S ON O.Item_No = S.Item_No
"
            Using resetCmd As New SqlCommand(resetQuery, con)
                resetCmd.ExecuteNonQuery()
            End Using

            ' 3. Get the highest-priced product again (after reset)
            Dim query As String = "SELECT TOP 1 Item_No FROM Orders ORDER BY Price DESC"
            Dim itemNo As String = ""

            Using cmd As New SqlCommand(query, con)
                Using reader As SqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        itemNo = reader("Item_No").ToString()
                    End If
                End Using
            End Using

            If itemNo = "" Then Exit Sub

            ' 4. Get original price from STOCKS
            Dim originalPrice As Integer = 0
            Dim getPriceQuery As String = "SELECT Price FROM STOCKS WHERE Item_No = @Item_No"

            Dim itemNoInt As Integer
            If Integer.TryParse(itemNo, itemNoInt) Then
                Using priceCmd As New SqlCommand(getPriceQuery, con)
                    priceCmd.Parameters.AddWithValue("@Item_No", itemNoInt)
                    Dim result = priceCmd.ExecuteScalar()
                    If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                        originalPrice = result
                    Else
                        MessageBox.Show("Failed to find original price in STOCKS for Item_No: " & itemNo)
                        Return
                    End If
                End Using
            Else
                MessageBox.Show("Invalid Item_No format: " & itemNo)
                Return
            End If

            ' 5. Apply discount only to that item
            Dim discountedPrice As Integer = originalPrice * (1 - discountRate)

            Dim updateQuery As String = "
            UPDATE Orders
            SET Price = @Price,
                Total_price = Quantity * @Price
            WHERE Item_No = @Item_No"
            Using updateCmd As New SqlCommand(updateQuery, con)
                updateCmd.Parameters.AddWithValue("@Price", discountedPrice)
                updateCmd.Parameters.AddWithValue("@Item_No", itemNo)
                updateCmd.ExecuteNonQuery()
            End Using

            ' 6. Refresh UI
            Me.OrdersTableAdapter.Fill(Me.SHITSTEMDataSet.Orders)
            UpdateTotalSum(Me, EventArgs.Empty)

        Catch ex As Exception
            MessageBox.Show("Error applying discount: " & ex.Message)
        Finally
            If con.State = ConnectionState.Open Then con.Close()
        End Try
    End Sub


    Private Sub paymenttxtbox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles paymenttxtbox.KeyPress
        OnlyAllowintegerInput(sender, e)
    End Sub
    Public Sub OnlyAllowintegerInput(sender As Object, e As KeyPressEventArgs)
        Dim tb As TextBox = CType(sender, TextBox)

        ' Allow digits, backspace, and one dot (.)
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "."c Then
            e.Handled = True ' Block anything else
        End If

        ' Only allow one dot
        If e.KeyChar = "."c AndAlso tb.Text.Contains(".") Then
            e.Handled = True
        End If

        ' Prevent starting with a dot (.)
        If tb.SelectionStart = 0 AndAlso e.KeyChar = "."c Then
            e.Handled = True
        End If
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        If MessageBox.Show("VOID ORDER?", "PA VOID PLS",
                 MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then

            ' Instead of resetcart(), loop through each item and delete properly
            For Each row As DataGridViewRow In OrdersDataGridView.Rows
                If Not row.IsNewRow Then
                    Dim rawItemNo As String = row.Cells("Item_No").Value.ToString()

                    If Not String.IsNullOrEmpty(rawItemNo) Then
                        DeleteItemFromCart(rawItemNo)
                    End If
                End If
            Next

            UpdateTotalSum(Me, EventArgs.Empty)
            OrdersDataGridView.ClearSelection()
            discount_choice.Text = "NONE"
            paymenttxtbox.Clear()
            lbltotal.Text = "₱0.00"

        End If
    End Sub


End Class