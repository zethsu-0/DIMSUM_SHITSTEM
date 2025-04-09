Imports System.Data.SqlClient

Public Class CASHIER

    Dim item_no As String = ""
    Dim Product_name As String = ""
    Dim StockQuantity As Integer = 0
    Dim Price As Decimal = 0
    Dim cartQuantity As Integer = 0
    Dim Total_price As Decimal = 0
    Private Sub CASHIER_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Load existing orders into the dataset
        Me.OrdersTableAdapter.Fill(Me.SHITSTEMDataSet.Orders)
        OrdersDataGridView.ClearSelection()
        OrdersDataGridView.CurrentCell = Nothing
        OrdersDataGridView.DefaultCellStyle.SelectionBackColor = OrdersDataGridView.DefaultCellStyle.BackColor
        OrdersDataGridView.DefaultCellStyle.SelectionForeColor = OrdersDataGridView.DefaultCellStyle.ForeColor
        Opencon()
        con.Close()
        resetcart()
    End Sub

    Private Sub checkproduct()
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
    End Sub

    Private Sub Insertproduct()
        Try
            Opencon()

            Dim existingcartQuantity As Decimal = 0
            Dim existingUnitPrice As Decimal = 0
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
                ' Update existing cart item
                Dim updateQuery As String = "UPDATE Orders SET Quantity = Quantity + @cartQuantity, Total_price = (Quantity + @cartQuantity) * @UnitPrice WHERE Product_name = @Product_name"

                Using updateCmd As New SqlCommand(updateQuery, con)
                    updateCmd.Parameters.AddWithValue("@cartQuantity", cartQuantity)
                    updateCmd.Parameters.AddWithValue("@UnitPrice", Price)
                    updateCmd.Parameters.AddWithValue("@Product_name", Product_name)
                    updateCmd.ExecuteNonQuery()
                End Using
            Else
                ' Insert new cart item
                Dim insertQuery As String = "INSERT INTO Orders (Product_name, Quantity, Price, Total_price) VALUES (@Product_name, @Quantity, @Price, @Total_price)"

                Using insertCmd As New SqlCommand(insertQuery, con)
                    insertCmd.Parameters.AddWithValue("@Product_name", Product_name)
                    insertCmd.Parameters.AddWithValue("@Quantity", cartQuantity)
                    insertCmd.Parameters.AddWithValue("@Price", Price)
                    insertCmd.Parameters.AddWithValue("@Total_price", cartQuantity * Price)
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
    Private Sub checkoutbtn_Click(sender As Object, e As EventArgs) Handles checkoutbtn.Click
        resetcart()
    End Sub

    Private Sub prod_1_Click(sender As Object, e As EventArgs) Handles prod_1.Click
        item_no = "001"
        cartQuantity = 1

        checkproduct()

        If StockQuantity > 0 Then
            Insertproduct()
        End If

        cartQuantity = 0
    End Sub


    Private Sub prod_2_Click(sender As Object, e As EventArgs) Handles prod_2.Click
        item_no = "002"
        cartQuantity = 1

        checkproduct()

        If StockQuantity > 0 Then
            Insertproduct()
        End If

        cartQuantity = 0
    End Sub

    Private Sub prod_3_Click(sender As Object, e As EventArgs) Handles prod_3.Click
        item_no = "003"
        cartQuantity = 1

        checkproduct()

        If StockQuantity > 0 Then
            Insertproduct()
        End If

        cartQuantity = 0
    End Sub

    Private Sub prod_4_Click(sender As Object, e As EventArgs) Handles prod_4.Click
        item_no = "004"
        cartQuantity = 1

        checkproduct()

        If StockQuantity > 0 Then
            Insertproduct()
        End If

        cartQuantity = 0
    End Sub

    Private Sub prod_5_Click(sender As Object, e As EventArgs) Handles prod_5.Click
        item_no = "005"
        cartQuantity = 1

        checkproduct()

        If StockQuantity > 0 Then
            Insertproduct()
        End If

        cartQuantity = 0
    End Sub

    Private Sub prod_6_Click(sender As Object, e As EventArgs) Handles prod_6.Click

    End Sub

    Private Sub prod_7_Click(sender As Object, e As EventArgs) Handles prod_7.Click

    End Sub

    Private Sub prod_8_Click(sender As Object, e As EventArgs) Handles prod_8.Click
        item_no = "006"
        cartQuantity = 1

        checkproduct()

        If StockQuantity > 0 Then
            Insertproduct()
        End If

        cartQuantity = 0
    End Sub
End Class
