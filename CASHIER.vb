Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Drawing.Text
Imports System.Globalization
Imports System.IO
Imports Guna.UI2.WinForms

Public Class CASHIER
    Public Property user_Role As String

    Private Sub CASHIER_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If con IsNot Nothing AndAlso con.State = ConnectionState.Open Then con.Close()
        Opencon()
        con.Close()
        ' --- Set up the Delete Button Column in the DataGridView ---
        Dim deleteButtonColumn As New DataGridViewButtonColumn()
        deleteButtonColumn.Name = "DeleteButton" ' Give the column a name to identify it later
        deleteButtonColumn.HeaderText = " "      ' No visible header text
        deleteButtonColumn.Text = "−"             ' The minus symbol for the button text
        deleteButtonColumn.Width = 25             ' Make the button narrow
        deleteButtonColumn.UseColumnTextForButtonValue = True ' Display the Text property on the button


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


        countingproducts()
        GenerateProductButtons()

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

        Dim query As String = "SELECT Item_no, Product_name, Product_image FROM STOCKS WHERE 1=1"
        Dim params As New List(Of SqlParameter)


        If Not String.IsNullOrWhiteSpace(groupFilter) Then
            query &= " AND product_group = @groupFilterParam"
            params.Add(New SqlParameter("@groupFilterParam", groupFilter))
        End If


        If Not String.IsNullOrWhiteSpace(searchTerm) Then
            query &= " AND (Item_no LIKE @searchParam OR Product_name LIKE @searchPatternParam)"
            params.Add(New SqlParameter("@searchParam", searchTerm))
            params.Add(New SqlParameter("@searchPatternParam", "%" & searchTerm & "%"))
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


                        Dim btn As New Guna2Button()
                        btn.Name = "DynamicGunaBtn_" & itemNo
                        '  btn.Text = If(productName.Length > 15, productName.Substring(0, 12) & "...", productName)
                        btn.Size = New Size(120, 120)
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

                                Debug.Print($"Error loading image for {productName}: {exImg.Message}")
                                btn.Text = productName & vbCrLf & "(No Img)"
                            End Try
                        End If

                        AddHandler btn.Click, AddressOf DynamicButton_Click
                        FlowLayoutPanel1.Controls.Add(btn)
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

        Dim clickedButton As Guna2Button = DirectCast(sender, Guna2Button)

        If clickedButton.Tag IsNot Nothing AndAlso TypeOf clickedButton.Tag Is String Then
            Dim specificItemNo As String = DirectCast(clickedButton.Tag, String)
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

        Else
            MessageBox.Show("Error: Button is missing associated product data (Item No).", "Button Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub AddProductToCart(ByVal itemNoToAdd As String, ByVal quantityToAdd As Integer)
        Dim localProductName As String = ""
        Dim currentStock As Integer = 0
        Dim unitPrice As Decimal = 0

        Try
            Opencon()
            Dim queryDetails As String = "SELECT Product_name, quantity, taxed_price FROM STOCKS WHERE Item_no = @Item_no"
            Using cmdDetails As New SqlCommand(queryDetails, con)
                cmdDetails.Parameters.AddWithValue("@Item_no", itemNoToAdd)
                Using reader As SqlDataReader = cmdDetails.ExecuteReader()
                    If reader.Read() Then
                        localProductName = reader("Product_name").ToString()
                        currentStock = Convert.ToInt32(reader("quantity"))
                        unitPrice = Convert.ToDecimal(reader("taxed_price"))
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
            Opencon() '

            Dim existingCartQuantity As Integer = 0
            Dim checkCartQuery As String = "SELECT Quantity FROM Orders WHERE Item_No = @Item_No"

            Using cmdCheck As New SqlCommand(checkCartQuery, con)
                cmdCheck.Parameters.AddWithValue("@Item_No", itemNoToAdd)
                Dim result = cmdCheck.ExecuteScalar()
                If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                    existingCartQuantity = Convert.ToInt32(result)
                End If
            End Using

            Dim sellingPrice As Decimal = unitPrice * 1.15D

            If existingCartQuantity > 0 Then
                Dim newQuantity As Integer = existingCartQuantity + quantityToAdd
                Dim newTotalPrice As Decimal = newQuantity * sellingPrice
                Dim updateQuery As String = "UPDATE Orders SET Quantity = @Quantity, Total_price = @TotalPrice WHERE Item_No = @Item_No"

                Using updateCmd As New SqlCommand(updateQuery, con)
                    updateCmd.Parameters.AddWithValue("@Quantity", newQuantity)
                    updateCmd.Parameters.AddWithValue("@TotalPrice", newTotalPrice)
                    updateCmd.Parameters.AddWithValue("@Item_No", itemNoToAdd)
                    updateCmd.ExecuteNonQuery()
                End Using
            Else
                Dim newTotalPrice As Decimal = quantityToAdd * sellingPrice
                Dim insertQuery As String = "INSERT INTO Orders (Item_No, Product_name, Quantity, Price, Total_price, OrderDate) VALUES (@Item_No, @Product_name, @Quantity, @Price, @Total_price, @OrderDate)"

                Using insertCmd As New SqlCommand(insertQuery, con)
                    insertCmd.Parameters.AddWithValue("@Item_No", itemNoToAdd)
                    insertCmd.Parameters.AddWithValue("@Product_name", localProductName)
                    insertCmd.Parameters.AddWithValue("@Quantity", quantityToAdd)
                    insertCmd.Parameters.AddWithValue("@Price", sellingPrice) ' Store the calculated selling price
                    insertCmd.Parameters.AddWithValue("@Total_price", newTotalPrice)
                    insertCmd.Parameters.AddWithValue("@OrderDate", DateTime.Now.Date) ' Store Date only
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
        Dim paymentAmount As Decimal = 0
        Dim totalSum As Decimal = 0

        ' --- Input Validation ---
        If String.IsNullOrWhiteSpace(paymenttxtbox.Text) Then
            MessageBox.Show("Please enter a payment amount.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            paymenttxtbox.Focus()
            Return
        End If

        If Not Decimal.TryParse(paymenttxtbox.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, paymentAmount) AndAlso
           Not Decimal.TryParse(paymenttxtbox.Text, paymentAmount) Then
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
        Dim changeAmount As Decimal = paymentAmount - totalSum

        Dim salesTotalForReport As Decimal = 0
        Dim totalProfitForReport As Decimal = 0




        Try
            For Each row As DataGridViewRow In OrdersDataGridView.Rows
                If Not row.IsNewRow Then

                    Dim itemNo As Integer = Convert.ToInt32(row.Cells("Item_no").Value)
                    Dim sellingPrice As Decimal = Convert.ToDecimal(row.Cells("Price").Value)
                    Dim quantity As Integer = Convert.ToInt32(row.Cells("Quantity").Value)

                    ' --- Retrieve the cost from STOCKS table based on Item_no ---
                    Dim cost As Decimal = 0
                    Dim query As String = "SELECT Cost FROM STOCKS WHERE Item_no = @Item_no"
                    Using cmd As New SqlCommand(query, con)
                        cmd.Parameters.AddWithValue("@Item_no", itemNo)
                        If con.State = ConnectionState.Closed Then
                            con.Open()
                        End If
                        Using reader As SqlDataReader = cmd.ExecuteReader()
                            If reader.HasRows Then
                                reader.Read()
                                cost = Convert.ToDecimal(reader("Cost"))
                            Else
                                MessageBox.Show($"Error: Item with number {itemNo} not found in STOCKS.", "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Return
                            End If
                        End Using
                    End Using

                    Dim itemTotal As Decimal = sellingPrice * quantity
                    salesTotalForReport += itemTotal

                    Dim itemProfit As Decimal = (sellingPrice - cost) * quantity
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

            ' --- DAILY SALES RESET ---
            Dim dailyQueryreset As String = "SELECT TOP 1 [Day] FROM Dailysales ORDER BY [Day] DESC"
            Using dailyCmd As New SqlCommand(dailyQueryreset, con)
                Dim lastDailyDateObj = dailyCmd.ExecuteScalar()
                If lastDailyDateObj IsNot Nothing Then
                    Dim lastDailyDate As Date
                    If Date.TryParse(lastDailyDateObj.ToString(), lastDailyDate) Then
                        If lastDailyDate.Date <> today Then
                            Dim resetDailyQuery As String = "DELETE FROM Dailysales"
                            Using resetCmd As New SqlCommand(resetDailyQuery, con)
                                resetCmd.ExecuteNonQuery()
                            End Using
                        End If
                    End If
                End If
            End Using

            ' --- WEEKLY SALES RESET ---
            Dim weeklyQueryreset As String = "SELECT TOP 1 [Day] FROM Weeklysales ORDER BY [Day] DESC"
            Using weeklyCmd As New SqlCommand(weeklyQueryreset, con)
                Dim lastWeeklyDayObj = weeklyCmd.ExecuteScalar()
                If lastWeeklyDayObj IsNot Nothing Then
                    Dim lastWeeklyDay As String = lastWeeklyDayObj.ToString()
                    Dim currentDayOfWeek1 As String = today.DayOfWeek.ToString()
                    If Not lastWeeklyDay.Equals(currentDayOfWeek1, StringComparison.OrdinalIgnoreCase) Then
                        Dim resetWeeklyQuery As String = "DELETE FROM Weeklysales"
                        Using resetCmd As New SqlCommand(resetWeeklyQuery, con)
                            resetCmd.ExecuteNonQuery()
                        End Using
                    End If
                End If
            End Using

            ' --- MONTHLY SALES RESET ---
            Dim monthlyQueryreset As String = "SELECT TOP 1 [Month] FROM Monthlysales ORDER BY [Month] DESC"
            Using monthlyCmd As New SqlCommand(monthlyQueryreset, con)
                Dim lastMonthlyMonthObj = monthlyCmd.ExecuteScalar()
                If lastMonthlyMonthObj IsNot Nothing Then
                    Dim lastMonthlyMonth As String = lastMonthlyMonthObj.ToString()
                    Dim currentMonth1 As String = today.ToString("MMMM")
                    If Not lastMonthlyMonth.Equals(currentMonth1, StringComparison.OrdinalIgnoreCase) Then
                        Dim resetMonthlyQuery As String = "DELETE FROM Monthlysales"
                        Using resetCmd As New SqlCommand(resetMonthlyQuery, con)
                            resetCmd.ExecuteNonQuery()
                        End Using
                    End If
                End If
            End Using



            ' 1. INSERT into DailySales
            Dim insertDailyQuery As String = "INSERT INTO DailySales (Day, Sales_total, Profit) VALUES (@Day, @Sales_total, @Profit)"
            Using cmdDaily As New SqlCommand(insertDailyQuery, con)
                cmdDaily.Parameters.AddWithValue("@Day", DateTime.Now.Date)
                cmdDaily.Parameters.AddWithValue("@Sales_total", salesTotalForReport)
                cmdDaily.Parameters.AddWithValue("@Profit", totalProfitForReport)
                cmdDaily.ExecuteNonQuery()
            End Using

            ' 2. Update or Insert into WeeklySales
            Dim currentDayOfWeek As String = DateTime.Today.DayOfWeek.ToString()
            Dim weeklyQuery As String = "
                IF EXISTS (SELECT 1 FROM WeeklySales WHERE Day = @dayParam)
                    UPDATE WeeklySales SET Sales_total = Sales_total + @Sales_total, Profit = Profit + @Profit WHERE Day = @dayParam
                ELSE
                    INSERT INTO WeeklySales (Day, Sales_total, Profit) VALUES (@dayParam, @Sales_total, @Profit)"
            Using cmdWeekly As New SqlCommand(weeklyQuery, con)
                cmdWeekly.Parameters.AddWithValue("@dayParam", currentDayOfWeek)
                cmdWeekly.Parameters.AddWithValue("@Sales_total", salesTotalForReport)
                cmdWeekly.Parameters.AddWithValue("@Profit", totalProfitForReport)
                cmdWeekly.ExecuteNonQuery()
            End Using

            ' 3. Update or Insert into MonthlySales
            Dim currentMonth As String = DateTime.Now.ToString("MMMM") ' Full month name like "April"
            Dim monthlyQuery As String = "
                IF EXISTS (SELECT 1 FROM MonthlySales WHERE Month = @monthParam)
                    UPDATE MonthlySales SET Sales_total = Sales_total + @Sales_total, Profit = Profit + @Profit WHERE Month = @monthParam
                ELSE
                    INSERT INTO MonthlySales (Month, Sales_total, Profit) VALUES (@monthParam, @Sales_total, @Profit)"
            Using cmdMonthly As New SqlCommand(monthlyQuery, con)
                cmdMonthly.Parameters.AddWithValue("@monthParam", currentMonth)
                cmdMonthly.Parameters.AddWithValue("@Sales_total", salesTotalForReport)
                cmdMonthly.Parameters.AddWithValue("@Profit", totalProfitForReport)
                cmdMonthly.ExecuteNonQuery()
            End Using
            MessageBox.Show("Checkout complete!" & vbCrLf & vbCrLf &
                $"Total Sale: ₱{salesTotalForReport:N2}" & vbCrLf &
                $"Payment Received: ₱{paymentAmount:N2}" & vbCrLf &
                $"Change Due: ₱{changeAmount:N2}",
                "Transaction Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)


            ' --- Show Receipt (Assuming RECEIPT form exists and uses data appropriately) ---
            ' You might need to pass data (like items, totals, payment, change) to the RECEIPT form.
            ' --- Calculate total quantity of items in cart ---

            Dim totalItemCount As Integer = 0

            For Each row As DataGridViewRow In OrdersDataGridView.Rows
                If Not row.IsNewRow Then
                    totalItemCount += Convert.ToInt32(row.Cells("Quantity").Value)
                End If
            Next

            ' --- Insert summarized transaction into Transactions table ---
            Dim transactionId As Integer
            Dim insertTransactionQuery As String = "INSERT INTO Transactions (TransactionDate, TotalAmount, PaymentAmount, ChangeGiven, Total_Item) 
                                        OUTPUT INSERTED.TransactionID 
                                        VALUES (@TransactionDate, @TotalAmount, @PaymentAmount, @ChangeGiven, @Total_Item)"

            Using transactionCmd As New SqlCommand(insertTransactionQuery, con)
                transactionCmd.Parameters.AddWithValue("@TransactionDate", DateTime.Now)
                transactionCmd.Parameters.AddWithValue("@TotalAmount", totalSum)
                transactionCmd.Parameters.AddWithValue("@PaymentAmount", paymentAmount)
                transactionCmd.Parameters.AddWithValue("@ChangeGiven", changeAmount)
                transactionCmd.Parameters.AddWithValue("@Total_Item", totalItemCount)

                If con.State = ConnectionState.Closed Then con.Open()
                transactionId = Convert.ToInt32(transactionCmd.ExecuteScalar())
            End Using

            RECEIPT.Show()


            ' --- Wait briefly before resetting ---
            ' Reduced delay slightly
            Await Task.Delay(1500)

            paymenttxtbox.Clear()
            lbltotal.Text = "₱0.00"
        Catch ex As Exception
            MessageBox.Show($"Error during checkout process: {ex.Message}", "Checkout Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            If con IsNot Nothing AndAlso con.State = ConnectionState.Open Then
                con.Close()

            End If
            resetcart()
        End Try
    End Sub

    ' --- Clears the Orders Table in the Database and Refreshes the Grid ---
    Public Sub resetcart()
        Try
            con.Open()
            Dim delquery As String = "DELETE FROM Orders" ' Deletes ALL rows from Orders
            Using cmd As New SqlCommand(delquery, con)
                cmd.ExecuteNonQuery()
            End Using

            ' Refresh the local dataset after clearing the database table
            Me.OrdersTableAdapter.Fill(Me.SHITSTEMDataSet.Orders)
            ' The grid (if bound) and total label should update automatically via events.

        Catch ex As Exception
            MessageBox.Show($"Error resetting cart: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If con IsNot Nothing AndAlso con.State = ConnectionState.Open Then
                con.Close()
            End If
        End Try

        UpdateTotalSum(Me, EventArgs.Empty)
        OrdersDataGridView.ClearSelection()
    End Sub

    Private Sub UpdateTotalSum(sender As Object, e As EventArgs)
        Try
            Dim totalSum As Decimal = 0
            For Each row As DataGridViewRow In OrdersDataGridView.Rows
                ' Check if it's not the new row placeholder and the cell has a value
                If Not row.IsNewRow AndAlso row.Cells("Total_price") IsNot Nothing AndAlso row.Cells("Total_price").Value IsNot Nothing AndAlso Not IsDBNull(row.Cells("Total_price").Value) Then
                    totalSum += Convert.ToDecimal(row.Cells("Total_price").Value)
                End If
            Next
            lbltotal.Text = totalSum.ToString("C", CultureInfo.GetCultureInfo("en-PH")) ' Format as Philippine Peso

        Catch ex As FormatException
            MessageBox.Show($"Error formatting total: {ex.Message}. Check data in Total_price column.", "Formatting Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Catch ex As Exception
            MessageBox.Show($"Error calculating total: {ex.Message}", "Calculation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub UpdateItemQuantityInCart(ByVal itemNoToUpdate As String, ByVal newQuantity As Integer)

        Dim sellingPrice As Decimal = 0
        Dim newTotalPrice As Decimal = 0

        Try
            Opencon()
            Dim getPriceQuery As String = "SELECT Price FROM Orders WHERE Item_No = @Item_No"
            Using cmdGetPrice As New SqlCommand(getPriceQuery, con)
                cmdGetPrice.Parameters.AddWithValue("@Item_No", itemNoToUpdate)
                Dim result = cmdGetPrice.ExecuteScalar()
                If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                    sellingPrice = Convert.ToDecimal(result)
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
            Dim paddedItemNo As String = CInt(rawItemNo).ToString("D3")

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

    ' --- Deletes an Item from the Orders Table and Restocks It ---
    Private Sub DeleteItemFromCart(ByVal rawItemNo As String)
        Dim quantityToReturn As Integer = 0
        Dim paddedItemNo As String = CInt(rawItemNo).ToString("D3")

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
        End If
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
    Private Sub OthersFilter_Click(sender As Object, e As EventArgs) Handles OthersFilter.Click
        HandleCategoryFilter(OthersFilter, "Others") ' Show only "Others" group
    End Sub
    Private Sub SiopaoFilter_Click(sender As Object, e As EventArgs) Handles SiopaoFilter.Click
        HandleCategoryFilter(OthersFilter, "Siopao")
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

    Private Sub CASHIER_Closed(sender As Object, e As EventArgs) Handles Me.Closed

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
        If discount_choice.Text = "PWD/SENIOR" Then

        End If
    End Sub
End Class