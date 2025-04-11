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
        resetcart()
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

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        RECEIPT.Show()
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

    Private Sub DeleteItem(productName As String)
        Try
            Opencon()

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

End Class
