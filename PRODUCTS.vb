﻿Imports System.Data.SqlClient
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports ZXing

Public Class PRODUCTS

    Private editmemo As Boolean = False
    Private openform As Boolean = False


    Dim Item_no As String
    Dim Product_name As String
    Dim Quantity As String
    Dim Price As Decimal
    Dim taxed_price As Decimal
    Dim product_group As String = ""

    Private Sub PRODUCTS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ProductGroupsTableAdapter.Fill(Me.SHITSTEMDataSet.ProductGroups)
        Opencon()
        con.Close()
        STOCKSDataGridView.Width = 946
        Me.STOCKSTableAdapter.Fill(Me.SHITSTEMDataSet.STOCKS)
        STOCKSDataGridView.ClearSelection()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim confirm = MessageBox.Show("are you sure you want to Exit?", "Confirm", CType(vbOKCancel, MessageBoxButtons))
        If confirm = MsgBoxResult.Ok Then
            Me.Close()
        Else
            Return
        End If
    End Sub


    Private Sub PRODUCTS_Click(sender As Object, e As EventArgs) Handles Me.Click
        STOCKSDataGridView.ClearSelection()
        STOCKSDataGridView.CurrentCell = Nothing
    End Sub


    Private Sub Button7_Click(sender As Object, e As EventArgs)
        TextBox8.Text = ""
        TextBox7.Text = ""
        TextBox6.Text = ""
        TextBox5.Text = ""
    End Sub

    Private Sub Button5_Click_1(sender As Object, e As EventArgs) Handles Button5.Click

        Try
            If TextBox8.Text = "" Or TextBox7.Text = "" Or TextBox6.Text = "" Or TextBox5.Text = "" Then
                MessageBox.Show("Please Fill all the SHITS")
            Else
                con.Open()
                Item_no = CInt(TextBox8.Text).ToString("D3") ' Ensures "4" becomes "004", "11" becomes "011"
                Product_name = TextBox7.Text
                Quantity = TextBox6.Text
                Price = Convert.ToDecimal(TextBox5.Text)
                product_group = ComboBox1.Text
                taxed_price = Convert.ToDecimal(TextBox1.Text)


                ' Convert image to byte array
                Dim Filesize As UInt32
                Dim mstream As New System.IO.MemoryStream
                PictureBox1.Image.Save(mstream, System.Drawing.Imaging.ImageFormat.Png)
                Dim arrimage() As Byte = mstream.GetBuffer()
                Filesize = mstream.Length
                mstream.Close()

                ' Insert into database
                Dim insertQuery As String = "INSERT INTO STOCKS (Item_No, Product_name,product_group, Quantity, Price,taxed_price, Barcode) 
                                     VALUES (@Item_no, @Product_name,@product_group, @Quantity, @Price,@taxed_price, @Barcode)"
                Using insertCmd As New SqlCommand(insertQuery, con)
                    insertCmd.Parameters.AddWithValue("@Item_no", Item_no)
                    insertCmd.Parameters.AddWithValue("@Product_name", Product_name)
                    insertCmd.Parameters.AddWithValue("@product_group", product_group)
                    insertCmd.Parameters.AddWithValue("@Quantity", Quantity)
                    insertCmd.Parameters.AddWithValue("@Price", Price)
                    insertCmd.Parameters.AddWithValue("@taxed_price", taxed_price)
                    insertCmd.Parameters.AddWithValue("@Barcode", arrimage)

                    insertCmd.ExecuteNonQuery()
                    con.Close()
                End Using

                ' Clear fields after insert
                TextBox7.Text = ""
                TextBox8.Text = ""
                TextBox6.Text = ""
                TextBox5.Text = ""
                TextBox1.Text = ""
                TextBox2.Text = ""
                ComboBox1.Text = ""
                PictureBox1.Image = Nothing
                RadioButton1.Checked = False
                RadioButton2.Checked = False
                Me.STOCKSTableAdapter.Fill(Me.SHITSTEMDataSet.STOCKS)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            con.Close()
        End Try


    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click
        If MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Dim Item_no As String = TextBox8.Text
            Dim Product_name As String = TextBox7.Text
            Dim query As String = "DELETE FROM STOCKS WHERE Item_no=@Item_no"

            If Not Item_no = "" Then
                Using cmd As New SqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@Item_no", Item_no)
                    con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                    MessageBox.Show(Product_name & "DELETED")
                    TextBox7.Text = ""
                    TextBox8.Text = ""
                    TextBox6.Text = ""
                    TextBox5.Text = ""
                    TextBox1.Text = ""
                    TextBox2.Text = ""
                    ComboBox1.Text = ""
                    PictureBox1.Image = Nothing
                    Button5.Visible = True
                    RadioButton1.Checked = False
                    RadioButton2.Checked = False
                    Me.STOCKSTableAdapter.Fill(Me.SHITSTEMDataSet.STOCKS)

                End Using
            End If
        End If
    End Sub


    Private Sub Label7_Click(sender As Object, e As EventArgs)
        MessageBox.Show("To Edit or Delete a Product, Just select in the Grid", "Edit Stocks")
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        STOCKSDataGridView.ClearSelection()
        TextBox7.Text = ""
        TextBox8.Text = ""
        TextBox6.Text = ""
        TextBox5.Text = ""
        TextBox2.Text = ""
        TextBox1.Text = ""
        ComboBox1.Text = ""
        RadioButton1.Checked = False
        RadioButton2.Checked = False
        PictureBox1.Image = Nothing
        Button5.Visible = False
        TextBox8.Enabled = True
        Button5.Visible = True
        TextBox7.ReadOnly = False
        TextBox8.ReadOnly = False
    End Sub





    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim Filesize As UInt32
        Dim mstream As New System.IO.MemoryStream
        PictureBox1.Image.Save(mstream, System.Drawing.Imaging.ImageFormat.Png)
        Dim arrimage() As Byte = mstream.GetBuffer()
        Filesize = mstream.Length
        mstream.Close()



        If MessageBox.Show("Are you sure you want to update this product?", "Confirm Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            If TextBox8.Text = "" Or TextBox7.Text = "" Or TextBox6.Text = "" Or TextBox5.Text = "" Then
                MessageBox.Show("Please fill in all fields" & vbCrLf & vbCrLf & "Or Select From the Grid", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                Item_no = TextBox8.Text
                Product_name = TextBox7.Text
                Quantity = TextBox6.Text
                Price = Convert.ToDecimal(TextBox5.Text)
                taxed_price = TextBox1.Text
                product_group = ComboBox1.Text



                Dim query As String = "UPDATE stocks SET Item_no=@Item_no,Product_name=@Product_name,product_group=@product_group,Quantity=@Quantity,Price=@Price, taxed_price=@taxed_price, barcode = @barcode WHERE Item_no = @Item_no"
                Using cmd As New SqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@Item_no", Item_no)
                    cmd.Parameters.AddWithValue("@Product_name", Product_name)
                    cmd.Parameters.AddWithValue("@product_group", product_group)
                    cmd.Parameters.AddWithValue("@Quantity", Quantity)
                    cmd.Parameters.AddWithValue("@Price", Price)
                    cmd.Parameters.AddWithValue("@taxed_price", taxed_price)
                    cmd.Parameters.AddWithValue("@barcode", arrimage)
                    con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                    TextBox7.Text = ""
                    TextBox8.Text = ""
                    TextBox6.Text = ""
                    TextBox5.Text = ""
                    TextBox1.Text = ""
                    TextBox2.Text = ""
                    ComboBox1.Text = ""
                    PictureBox1.Image = Nothing
                    PictureBox1.Image = Nothing
                    Button5.Visible = False
                    Me.STOCKSTableAdapter.Fill(Me.SHITSTEMDataSet.STOCKS)

                End Using
            End If
        End If


        Button5.Visible = True
        TextBox7.ReadOnly = False
        TextBox8.ReadOnly = False
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If TextBox2.Text IsNot "" Then

            Dim query As String = "SELECT * FROM stocks WHERE Item_no = @search OR Product_name LIKE @searchPattern"

            Using cmd As SqlCommand = New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@search", TextBox2.Text.Trim())
                cmd.Parameters.AddWithValue("@searchPattern", "%" & TextBox2.Text.Trim() & "%")

                Using da As New SqlDataAdapter(cmd)
                    Using dt As New DataTable()
                        da.Fill(dt)
                        If dt.Rows.Count > 0 Then
                            TextBox8.Text = dt.Rows(0)("Item_no").ToString()
                            TextBox7.Text = dt.Rows(0)("Product_name").ToString()
                            TextBox6.Text = dt.Rows(0)("Quantity").ToString()
                            TextBox5.Text = dt.Rows(0)("Price").ToString()
                            TextBox1.Text = dt.Rows(0)("taxed_price").ToString()
                            ComboBox1.Text = dt.Rows(0)("product_group").ToString()
                            Button5.Visible = False
                            TextBox7.ReadOnly = True
                            TextBox8.ReadOnly = True
                            RadioButton1.Checked = False
                            RadioButton2.Checked = False
                        Else

                            TextBox8.Text = ""
                            TextBox7.Text = ""
                            TextBox6.Text = ""
                            TextBox5.Text = ""
                            TextBox2.Text = ""
                            RadioButton1.Checked = False
                            RadioButton2.Checked = False
                        End If
                    End Using
                End Using
            End Using
        End If
    End Sub



    Dim barCodename As String = ""
    Dim barProdId As String = ""
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        ' Determine Product Group Code
        Select Case ComboBox1.Text
            Case "Food"
                product_group = "FD"
            Case "Drinks"
                product_group = "DR"
            Case Else
                MessageBox.Show("Please select a valid product group.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
        End Select
        Barcodegenerator()
    End Sub

    Public Sub Barcodegenerator()

        Dim bargen = product_group & TextBox8.Text & barCodename
        Dim generator As New BarcodeWriter
        generator.Format = BarcodeFormat.CODE_128
        generator.Options.PureBarcode = True
        Try
        PictureBox1.Image = generator.Write(bargen)
        Catch ex As Exception
            PictureBox1.Image = Nothing
        End Try
    End Sub


    Private Sub TextBox7_TextChanged(sender As Object, e As EventArgs) Handles TextBox7.TextChanged
        barCodename = TextBox7.Text



        If String.IsNullOrEmpty(TextBox8.Text) Then
            con.Open()
            Dim cmd As New SqlCommand("
        WITH NumberSeries AS (
            SELECT ROW_NUMBER() OVER (ORDER BY CAST(Item_No AS INT)) AS RowNum, CAST(Item_No AS INT) AS ItemNo
            FROM STOCKS
        )
        SELECT MIN(RowNum) FROM NumberSeries WHERE RowNum <> ItemNo", con)

            Dim missingItemNo As Object = cmd.ExecuteScalar()
            con.Close()

            ' If there is a missing number, use it; otherwise, use MAX + 1
            If missingItemNo IsNot DBNull.Value Then
                TextBox8.Text = CInt(missingItemNo).ToString("D3")
            Else
                con.Open()
                Dim maxCmd As New SqlCommand("SELECT ISNULL(MAX(CAST(Item_No AS INT)), 0) + 1 FROM STOCKS", con)
                Dim nextItemNo As Integer = CInt(maxCmd.ExecuteScalar())
                con.Close()

                TextBox8.Text = nextItemNo.ToString("D3")

            End If
        End If
        Barcodegenerator()


    End Sub



    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        If Decimal.TryParse(TextBox5.Text, Price) Then
            Dim taxed_price As Decimal = Price
            TextBox1.Text = taxed_price.ToString()


        End If
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        If Decimal.TryParse(TextBox5.Text, Price) Then
            Dim tax As Decimal = Price * 0.12
            Dim taxed_price As Decimal = Price + tax
            TextBox1.Text = taxed_price.ToString()
        End If
    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged
        TextBox1.Text = taxed_price
    End Sub
End Class