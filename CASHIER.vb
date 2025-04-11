Imports System.Data.SqlClient
Imports System.Drawing.Text
Public Class CASHIER

    Private Sub CASHIER_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim deleteButtonColumn As New DataGridViewButtonColumn()
        deleteButtonColumn.Name = "DeleteButton"
        deleteButtonColumn.HeaderText = " "
        deleteButtonColumn.Text = " —— "
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
        Dim totalSum As Decimal = 0

        Try
            Opencon()

            Dim sumQuery As String = "SELECT SUM(Total_price) FROM Orders"

            Using cmd As New SqlCommand(sumQuery, con)
                Dim result = cmd.ExecuteScalar()
                If result IsNot DBNull.Value Then
                    totalSum = Convert.ToDecimal(result)
                End If
            End Using

        Catch ex As Exception
            MsgBox("Error calculating total: " & ex.Message, vbCritical)
        Finally
            If con.State = ConnectionState.Open Then con.Close()
        End Try

        lbltotal.Text = totalSum.ToString("C2")
        OrdersDataGridView.NotifyCurrentCellDirty(True)
    End Sub





    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        RECEIPT.Show()
    End Sub

    Private Sub OrdersDataGridView_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles OrdersDataGridView.CellContentClick
        If e.RowIndex >= 0 Then

            If OrdersDataGridView.Columns.Contains("Product_name") Then

                Dim productName As String = OrdersDataGridView.Rows(e.RowIndex).Cells("Product_name").Value.ToString()
                    Dim result As DialogResult = MessageBox.Show("Are you sure you want to delete this item?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                    If result = DialogResult.Yes Then

                        DeleteItem(productName)

                        OrdersDataGridView.Rows.RemoveAt(e.RowIndex)

                        Me.OrdersTableAdapter.Fill(Me.SHITSTEMDataSet.Orders)

                End If
            Else
                MessageBox.Show("Product_name column not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

    Private Sub Guna2Button5_Click(sender As Object, e As EventArgs) Handles Guna2Button5.Click
        For Each col As DataGridViewColumn In OrdersDataGridView.Columns
            Debug.WriteLine("Column: " & col.Name)
        Next
    End Sub
End Class
