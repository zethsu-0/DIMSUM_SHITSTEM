Imports System.Data.SqlClient
Imports System.Drawing.Text
Public Class CASHIER

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
    End Sub

    Private CASHIER_MENU_FOOD_TAB As New CASHIER_MENU_FOOD_TAB()
    Private Sub snacks_tabbtn_Click_1(sender As Object, e As EventArgs) Handles snacks_tabbtn.Click
        Dim ordersUC As New CASHIER_MENU_FOOD_TAB()

        AddHandler ordersUC.RefreshOrdersRequested, AddressOf RefreshOrders

        Me.Panel3.Controls.Clear()
        Me.Panel3.Controls.Add(ordersUC)
        ordersUC.Dock = DockStyle.Fill

    End Sub
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
            Dim totalProfit As Decimal = 0
            Dim Sales_total As Decimal = 0

            For Each row As DataGridViewRow In OrdersDataGridView.Rows
                If Not row.IsNewRow AndAlso row.Cells("Price").Value IsNot Nothing AndAlso row.Cells("Quantity").Value IsNot Nothing Then
                    Dim price As Decimal = Convert.ToDecimal(row.Cells("Price").Value)
                    Dim quantity As Integer = Convert.ToInt32(row.Cells("Quantity").Value)

                    Dim itemTotal As Decimal = price * quantity
                    Dim itemProfit As Decimal = itemTotal * 0.02D

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

            ' Reset cart
            resetcart()

            MessageBox.Show("Checkout complete!" & vbCrLf &
                    "Sales Total: " & Sales_total.ToString("C2") & vbCrLf &
                    "Profit: " & totalProfit.ToString("C2"))

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

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        RECEIPT.Show()
    End Sub
End Class
