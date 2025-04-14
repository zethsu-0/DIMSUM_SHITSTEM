Imports System.Data.SqlClient
Imports System.Web.Security
Imports System.Windows.Controls
Imports System.Windows.Forms.VisualStyles
Imports Guna.UI2.WinForms
Imports MessagingToolkit.Barcode.Common
Imports System.Drawing
Imports Image = System.Drawing.Image

Public Class CASHIER_MENU_FOOD_TAB
    Dim item_no As String = ""
    Dim Product_name As String = ""
    Dim StockQuantity As Integer = 0
    Dim Price As Decimal = 0
    Dim cartQuantity As Integer = 0
    Dim Total_price As Decimal = 0


    Private Sub CASHIER_MENU_FOOD_TAB_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.OrdersTableAdapter.Fill(Me.SHITSTEMDataSet.Orders)
        Opencon()
        con.Close()
        resetcart()

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
                    btn.BackgroundImage = System.Drawing.Image.FromFile("C:\Users\herod\Downloads\aakk.png")
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


            Me.checkproduct()

            Me.cartQuantity = 0

        Else

            MessageBox.Show("Error: Button is missing associated product data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
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
    Public Sub resetcart()
        Dim delquery As String = "DELETE FROM Orders"
        Using cmd As New SqlCommand(delquery, con)
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            Me.OrdersTableAdapter.Fill(Me.SHITSTEMDataSet.Orders)

        End Using
    End Sub


End Class
