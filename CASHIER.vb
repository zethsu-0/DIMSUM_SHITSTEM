Imports System.Data.SqlClient
Imports System.Drawing.Text
Imports Guna.UI2.WinForms
Public Class CASHIER

    Dim item_no As String = ""
    Dim Product_name As String = ""
    Dim StockQuantity As Integer = 0
    Dim Price As Decimal = 0
    Dim cartQuantity As Integer = 0
    Dim Total_price As Decimal = 0
    Dim paymentAmount As Decimal

    Private Sub CASHIER_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim deleteButtonColumn As New DataGridViewButtonColumn()
        deleteButtonColumn.Name = "DeleteButton"
        deleteButtonColumn.HeaderText = " "
        deleteButtonColumn.Text = "−"
        deleteButtonColumn.Width = 25
        deleteButtonColumn.UseColumnTextForButtonValue = True


        If Not OrdersDataGridView.Columns.Contains("DeleteButton") Then
            OrdersDataGridView.Columns.Add(deleteButtonColumn)
        End If

        Me.OrdersTableAdapter.Fill(Me.SHITSTEMDataSet.Orders)
        For Each column As DataGridViewColumn In OrdersDataGridView.Columns
            column.Name = column.DataPropertyName
        Next
        OrdersDataGridView.ClearSelection()
        OrdersDataGridView.CurrentCell = Nothing
        Opencon()
        con.Close()
        resetcart()
        snacks_tabbtn.PerformClick()

        AddHandler OrdersDataGridView.CellValueChanged, AddressOf UpdateTotalSum
        AddHandler OrdersDataGridView.RowsRemoved, AddressOf UpdateTotalSum
        AddHandler OrdersDataGridView.RowsAdded, AddressOf UpdateTotalSum

        countingproducts()
        GenerateProductButtons()
    End Sub


    Private Sub countingproducts()
        con.Open()
        Dim cmd As New SqlCommand("SELECT COUNT(*) FROM STOCKS", con)
        Dim count As Integer = CInt(cmd.ExecuteScalar())
        If count = 0 Then
            MessageBox.Show("No products found in database.")
            Exit Sub
        End If
        Dim prodcount = count
        con.Close()
    End Sub


    Private Sub GenerateProductButtons()
        FlowLayoutPanel1.Controls.Clear()


        Dim query As String = "SELECT Item_no, Product_name FROM STOCKS ORDER BY Item_no"
        Using cmd As New SqlCommand(query, con)
            con.Open()
            Using reader As SqlDataReader = cmd.ExecuteReader()
                While reader.Read()
                    Dim itemNo As String = reader("Item_no").ToString()
                    Dim productName As String = reader("Product_name").ToString()

                    Dim btn As New Guna2Button()
                    btn.Name = "DynamicGunaBtn" & itemNo
                    btn.Text = productName
                    btn.Size = New Size(120, 120)
                    btn.Margin = New Padding(20, 20, 20, 20)
                    btn.BorderRadius = 15
                    btn.BorderThickness = 2
                    btn.FillColor = Color.Transparent
                    btn.ForeColor = Color.Black
                    btn.TextOffset = New Point(0, 30)
                    ' btn.BackgroundImage = System.Drawing.Image.FromFile("C:\Users\herod\Downloads\aakk.png")
                    btn.BackgroundImageLayout = ImageLayout.Stretch
                    btn.Tag = itemNo

                    AddHandler btn.Click, AddressOf DynamicButton_Click
                    FlowLayoutPanel1.Controls.Add(btn)
                End While
            End Using
            con.Close()
        End Using
    End Sub


    Private Sub DynamicButton_Click(sender As Object, e As EventArgs)

        Dim clickedButton As Guna2Button = DirectCast(sender, Guna2Button)


        If clickedButton.Tag IsNot Nothing AndAlso TypeOf clickedButton.Tag Is String Then
            Dim specificItemNo As String = DirectCast(clickedButton.Tag, String)

            Me.item_no = specificItemNo
            Me.cartQuantity = 1


            Me.addproduct()

            Me.cartQuantity = 0

        Else

            MessageBox.Show("Error: Button is missing associated product data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub



    Private Sub addproduct()
        Try
            Opencon()
            Dim query As String = "SELECT Product_name, quantity, taxed_price FROM STOCKS WHERE Item_no = @Item_no"

            Using cmd As New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@Item_no", item_no)
                Using reader As SqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        Product_name = reader("Product_name").ToString()
                        StockQuantity = Convert.ToInt32(reader("quantity"))
                        Price = Convert.ToDecimal(reader("taxed_price"))
                    Else
                        MsgBox("Item not found in stocks.", vbCritical)
                        Exit Sub
                    End If
                End Using
            End Using

            If StockQuantity <= 0 Then
                MsgBox("Not enough stock available!", vbExclamation)
                Exit Sub
            End If

        Catch ex As Exception
            MsgBox("Error checking product: " & ex.Message, vbCritical)
        Finally
            If con.State = ConnectionState.Open Then con.Close()
        End Try

        Try
            Opencon()

            Dim existingcartQuantity As Decimal = 0
            Dim existingUnitPrice As Decimal = 0
            Dim profit As Decimal = Price * 1.15
            Dim checkCartQuery As String = "SELECT Quantity, Price FROM Orders WHERE Product_name = @Product_name"

            Using cmd As New SqlCommand(checkCartQuery, con)
                cmd.Parameters.AddWithValue("@Product_name", Product_name)
                Using reader As SqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        existingcartQuantity = Convert.ToInt32(reader("Quantity"))
                        existingUnitPrice = Convert.ToDecimal(reader("Price"))
                    End If
                End Using
            End Using

            If existingcartQuantity > 0 Then
                ' Update existing order items
                Dim newQuantity As Integer = existingcartQuantity + cartQuantity
                Dim updateQuery As String = "UPDATE Orders SET Quantity = @Quantity, Total_price = @TotalPrice WHERE Product_name = @Product_name"

                Using updateCmd As New SqlCommand(updateQuery, con)
                    updateCmd.Parameters.AddWithValue("@Quantity", newQuantity)
                    updateCmd.Parameters.AddWithValue("@TotalPrice", newQuantity * profit)
                    updateCmd.Parameters.AddWithValue("@Product_name", Product_name)
                    updateCmd.ExecuteNonQuery()
                End Using
            Else
                ' Insert new order items
                Dim insertQuery As String = "INSERT INTO Orders (Product_name, Quantity, Price, Total_price, OrderDate) VALUES (@Product_name, @Quantity, @Price, @Total_price, @OrderDate)"

                Using insertCmd As New SqlCommand(insertQuery, con)
                    insertCmd.Parameters.AddWithValue("@Product_name", Product_name)
                    insertCmd.Parameters.AddWithValue("@Quantity", cartQuantity)
                    insertCmd.Parameters.AddWithValue("@Price", profit)
                    insertCmd.Parameters.AddWithValue("@Total_price", cartQuantity * profit)
                    insertCmd.Parameters.AddWithValue("@OrderDate", DateTime.Now.Date)
                    insertCmd.ExecuteNonQuery()
                End Using
            End If

            ' Update stock quantity
            Dim updateStockQuery As String = "UPDATE STOCKS SET quantity = quantity - @cartQuantity WHERE Product_name = @Product_name"

            Using stockCmd As New SqlCommand(updateStockQuery, con)
                stockCmd.Parameters.AddWithValue("@cartQuantity", cartQuantity)
                stockCmd.Parameters.AddWithValue("@Product_name", Product_name)
                stockCmd.ExecuteNonQuery()
            End Using

            Me.OrdersTableAdapter.Fill(Me.SHITSTEMDataSet.Orders)
        Catch ex As Exception
            MsgBox("Error inserting product: " & ex.Message, vbCritical)
        Finally
            If con.State = ConnectionState.Open Then con.Close()

        End Try

        Me.OrdersTableAdapter.Fill(Me.SHITSTEMDataSet.Orders)


        RaiseEvent RefreshOrdersRequested(Me, EventArgs.Empty)

    End Sub
    Public Event RefreshOrdersRequested As EventHandler




    Private Sub RefreshOrders(sender As Object, e As EventArgs)
        Try
            Me.OrdersTableAdapter.Fill(Me.SHITSTEMDataSet.Orders)
            OrdersDataGridView.DataSource = Me.SHITSTEMDataSet.Orders ' Adjust if needed
        Catch ex As Exception
            MessageBox.Show("Error refreshing orders: " & ex.Message)
        End Try
    End Sub
    Private Sub checkoutbtn_Click(sender As Object, e As EventArgs) Handles checkoutbtn.Click
        Try
            ' Check if the payment textbox is empty or contains a non-numeric value
            If String.IsNullOrWhiteSpace(paymenttxtbox.Text) Then
                MessageBox.Show("Please enter a payment amount.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            Dim paymentAmount As Decimal

            ' Try parsing the payment amount
            If Not Decimal.TryParse(paymenttxtbox.Text, paymentAmount) Then
                MessageBox.Show("Invalid payment amount. Please enter a valid number.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            ' Clean the lbltotal.Text (remove any non-numeric characters like commas, currency symbols, etc.)
            Dim totalSum As Decimal
            Dim cleanTotal As String = lbltotal.Text
            cleanTotal = cleanTotal.Replace(",", "").Replace("$", "") ' Remove commas and dollar signs

            ' Try converting the cleaned total sum text to a Decimal
            If Not Decimal.TryParse(cleanTotal, totalSum) Then
                MessageBox.Show("Invalid total sum format.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            ' Check if payment amount is less than total sum
            If paymentAmount < totalSum Then
                MessageBox.Show("Payment amount is less than the total sum. Please enter a valid amount.", "Payment Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            ' Calculate the change
            Dim changeAmount As Decimal = paymentAmount - totalSum

            ' Proceed with the checkout process if all conditions are met
            Dim totalProfit As Decimal = 0
            Dim Sales_total As Decimal = 0

            ' Loop through the orders and calculate totals
            For Each row As DataGridViewRow In OrdersDataGridView.Rows
                If Not row.IsNewRow AndAlso row.Cells("Price").Value IsNot Nothing AndAlso row.Cells("Quantity").Value IsNot Nothing Then
                    Dim price As Decimal = Convert.ToDecimal(row.Cells("Price").Value)
                    Dim quantity As Integer = Convert.ToInt32(row.Cells("Quantity").Value)

                    Dim itemTotal As Decimal = price * quantity
                    Dim itemProfit As Decimal = itemTotal * 0.15D

                    Sales_total += itemTotal
                    totalProfit += itemProfit
                End If
            Next

            ' INSERT into DailySales
            Dim insertQuery As String = "INSERT INTO DailySales (Day, Sales_total, Profit) VALUES (@Day, @Sales_total, @Profit)"
            Using cmd As New SqlCommand(insertQuery, con)
                cmd.Parameters.AddWithValue("@Day", DateTime.Now.Date)
                cmd.Parameters.AddWithValue("@Sales_total", Sales_total)
                cmd.Parameters.AddWithValue("@Profit", totalProfit)

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End Using

            ' Update or Insert into WeeklySales
            Dim currentDay As String = DateTime.Today.DayOfWeek.ToString()

            Dim weeklyQuery As String = "
        IF EXISTS (SELECT 1 FROM WeeklySales WHERE Day = @day)
            UPDATE WeeklySales 
            SET Sales_total = Sales_total + @Sales_total, Profit = Profit + @Profit 
            WHERE Day = @day
        ELSE
            INSERT INTO WeeklySales (Day, Sales_total, Profit) 
            VALUES (@day, @Sales_total, @Profit)
    "
            Using cmd As New SqlCommand(weeklyQuery, con)
                cmd.Parameters.AddWithValue("@day", currentDay)
                cmd.Parameters.AddWithValue("@Sales_total", Sales_total)
                cmd.Parameters.AddWithValue("@Profit", totalProfit)
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End Using

            ' Update or Insert into MonthlySales
            Dim currentMonth As String = DateTime.Now.ToString("MMMM")

            Dim monthlysalesq As String = "
        IF EXISTS (SELECT 1 FROM MonthlySales WHERE Month = @month)
            UPDATE MonthlySales 
            SET Sales_total = Sales_total + @Sales_total, Profit = Profit + @Profit 
            WHERE Month = @month
        ELSE
            INSERT INTO MonthlySales (Month, Sales_total, Profit) 
            VALUES (@month, @Sales_total, @Profit)
    "
            Using cmd As New SqlCommand(monthlysalesq, con)
                cmd.Parameters.AddWithValue("@month", currentMonth)
                cmd.Parameters.AddWithValue("@Sales_total", Sales_total)
                cmd.Parameters.AddWithValue("@Profit", totalProfit)
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End Using

            ' === Insert into Orders table (Including Payment and Change) ===
            Dim orderInsertQuery As String = "
        INSERT INTO Orders (OrderDate, payment, change)
        VALUES (@OrderDate, @payment, @change)
    "

            Using cmd As New SqlCommand(orderInsertQuery, con)
                cmd.Parameters.AddWithValue("@OrderDate", DateTime.Now.Date)

                cmd.Parameters.AddWithValue("@payment", paymentAmount)
                cmd.Parameters.AddWithValue("@change", changeAmount)

                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            End Using



            MessageBox.Show("Checkout complete!" & vbCrLf &
                "Sales Total: " & Sales_total.ToString("C2") & vbCrLf &
                "Profit: " & totalProfit.ToString("C2") & vbCrLf &
                "Payment: " & paymentAmount.ToString("C2") & vbCrLf &
                "Change: " & changeAmount.ToString("C2"))
        Catch ex As Exception
            MessageBox.Show("Error during checkout: " & ex.Message)
        Finally
            If con.State = ConnectionState.Open Then con.Close()
        End Try
    End Sub



    Public Sub resetcart()
        Dim delquery As String = "DELETE FROM Orders"
        Using cmd As New SqlCommand(delquery, con)
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            Me.OrdersTableAdapter.Fill(Me.SHITSTEMDataSet.Orders)
        End Using
    End Sub

    Private Sub UpdateTotalSum(sender As Object, e As EventArgs)
        Try
            Dim totalSum As Decimal = 0
            For Each row As DataGridViewRow In OrdersDataGridView.Rows
                If Not row.IsNewRow AndAlso row.Cells("Total_price").Value IsNot Nothing Then
                    totalSum += Convert.ToDecimal(row.Cells("Total_price").Value)
                End If
            Next
            lbltotal.Text = totalSum.ToString("C2")
        Catch ex As Exception
            MsgBox("Error calculating total: " & ex.Message, vbCritical)
        End Try
    End Sub



    Private Sub UpdateItemQuantity(productName As String, newQuantity As Integer, newTotal As Decimal)
        Try
            Opencon()

            Dim updateQuery As String = "UPDATE Orders SET Quantity = @Quantity, Total_price = @TotalPrice WHERE Product_name = @ProductName"

            Using updateCmd As New SqlCommand(updateQuery, con)
                updateCmd.Parameters.AddWithValue("@Quantity", newQuantity)
                updateCmd.Parameters.AddWithValue("@TotalPrice", newTotal)
                updateCmd.Parameters.AddWithValue("@ProductName", productName)

                updateCmd.ExecuteNonQuery()
            End Using

        Catch ex As Exception
            MessageBox.Show("Error updating quantity: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If con.State = ConnectionState.Open Then con.Close()
        End Try

        UpdateTotalSum(Me, EventArgs.Empty)
    End Sub
    Private Sub OrdersDataGridView_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles OrdersDataGridView.CellContentClick
        If e.RowIndex >= 0 Then
            Dim productName As String = OrdersDataGridView.Rows(e.RowIndex).Cells("Product_name").Value.ToString()
            Dim currentQty As Integer = Convert.ToInt32(OrdersDataGridView.Rows(e.RowIndex).Cells("Quantity").Value)
            Dim productPrice As Decimal = Convert.ToDecimal(OrdersDataGridView.Rows(e.RowIndex).Cells("Price").Value)

            If currentQty > 1 Then
                ' Reduce quantity by 1
                Dim newQty = currentQty - 1
                Dim newTotal = newQty * productPrice


                RestockItem(productName, 1)
                ' Update database
                UpdateItemQuantity(productName, newQty, newTotal)


                ' Refresh grid
                Me.OrdersTableAdapter.Fill(Me.SHITSTEMDataSet.Orders)
            Else
                ' If quantity is 1, delete the item completely
                DeleteItem(productName)
                Me.OrdersTableAdapter.Fill(Me.SHITSTEMDataSet.Orders)
            End If
        End If
    End Sub
    Private Sub RestockItem(productName As String, quantity As Integer)
        Try
            Opencon()
            Dim updateStockQuery As String = "UPDATE STOCKS SET quantity = quantity + @qty WHERE Product_name = @Product_name"
            Using cmd As New SqlCommand(updateStockQuery, con)
                cmd.Parameters.AddWithValue("@qty", quantity)
                cmd.Parameters.AddWithValue("@Product_name", productName)
                cmd.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            MsgBox("Error restocking: " & ex.Message)
        Finally
            If con.State = ConnectionState.Open Then con.Close()
        End Try
    End Sub
    Private Sub DeleteItem(productName As String)
        Try
            Opencon()

            ' Get quantity to return to stock
            Dim quantityToReturn As Integer = 0
            Dim getQtyQuery As String = "SELECT Quantity FROM Orders WHERE Product_name = @Product_name"
            Using qtyCmd As New SqlCommand(getQtyQuery, con)
                qtyCmd.Parameters.AddWithValue("@Product_name", productName)
                Dim result = qtyCmd.ExecuteScalar()
                If result IsNot Nothing Then
                    quantityToReturn = Convert.ToInt32(result)
                End If
            End Using

            ' Add back to stock
            Dim updateStockQuery As String = "UPDATE STOCKS SET quantity = quantity + @qty WHERE Product_name = @Product_name"
            Using stockCmd As New SqlCommand(updateStockQuery, con)
                stockCmd.Parameters.AddWithValue("@qty", quantityToReturn)
                stockCmd.Parameters.AddWithValue("@Product_name", productName)
                stockCmd.ExecuteNonQuery()
            End Using

            ' Now delete from orders
            Dim deleteQuery As String = "DELETE FROM Orders WHERE Product_name = @Product_name"
            Using deleteCmd As New SqlCommand(deleteQuery, con)
                deleteCmd.Parameters.AddWithValue("@Product_name", productName)
                deleteCmd.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            MessageBox.Show("Error deleting item: " & ex.Message)
        Finally
            If con.State = ConnectionState.Open Then con.Close()
        End Try
    End Sub

    Public Property user_Role As String
    Private Sub CASHIER_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        If user_Role = "Employee" Then
            LOGIN_PAGE.Show()
        End If
    End Sub

    Private Async Sub Guna2Button2_Click_1(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        RECEIPT.Show()

        ' Wait for a specified duration (e.g., 2 seconds)
        Await Task.Delay(2000) ' 2000 milliseconds = 2 seconds

        ' Call resetcart after the delay
        resetcart()
    End Sub
End Class
