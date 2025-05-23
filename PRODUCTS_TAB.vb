﻿Imports System.Data.SqlClient
Imports System.IO
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports ZXing

Public Class PRODUCTS_TAB

    Private Sub PRODUCTS_TAB_Load(sender As Object, e As EventArgs) Handles Me.Load
        Opencon()
        con.Close()
        STOCKSDataGridView.Width = 946
        Me.STOCKSTableAdapter.Fill(Me.SHITSTEMDataSet.STOCKS)
        STOCKSDataGridView.ClearSelection()

    End Sub

    Private editmemo As Boolean = False
    Private openform As Boolean = False


    Dim Item_no As String
    Dim Product_name As String
    Dim Quantity As String
    Dim Price As Decimal
    Dim Cost As Decimal
    Dim product_group As String = ""

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
            If TextBox8.Text = "" Or TextBox7.Text = "" Or TextBox6.Text = "" Or TextBox5.Text = "" Or TextBox3.Text = "" Or PictureBox2.Image Is Nothing Then
                MessageBox.Show("Please Fill all the SHITS")
            Else
                con.Open()
                Item_no = CInt(TextBox8.Text).ToString("D3") ' "D3" Ensures "4" becomes "004", "11" becomes "011"
                Product_name = TextBox7.Text
                Quantity = TextBox6.Text
                Price = TextBox5.Text
                Cost = TextBox3.Text
                product_group = ComboBox1.Text



                Dim Filesize As UInt32
                Dim mstream As New System.IO.MemoryStream
                PictureBox1.Image.Save(mstream, System.Drawing.Imaging.ImageFormat.Png)
                Dim arrimage() As Byte = mstream.GetBuffer()
                Filesize = mstream.Length
                mstream.Close()

                Dim Filesize2 As UInt32
                Dim mstream2 As New System.IO.MemoryStream
                PictureBox2.Image.Save(mstream2, System.Drawing.Imaging.ImageFormat.Png)
                Dim arrimage2() As Byte = mstream2.GetBuffer()
                Filesize2 = mstream2.Length
                mstream2.Close()

                ' Insert into database
                Dim insertQuery As String = "
                    INSERT INTO stocks (Item_no, Product_name, product_group, Quantity, Cost, price, Barcode, Product_image, expdate) 
                    VALUES (@Item_no, @Product_name, @product_group, @Quantity, @Cost, @price, @Barcode, @Product_image, @expdate)
                        "

                Using insertCmd As New SqlCommand(insertQuery, con)
                    insertCmd.Parameters.AddWithValue("@Item_no", Item_no)
                    insertCmd.Parameters.AddWithValue("@Product_name", Product_name)
                    insertCmd.Parameters.AddWithValue("@product_group", product_group)
                    insertCmd.Parameters.AddWithValue("@Quantity", Quantity)
                    insertCmd.Parameters.AddWithValue("@Price", Price)
                    insertCmd.Parameters.AddWithValue("@Cost", Cost)
                    insertCmd.Parameters.AddWithValue("@Barcode", arrimage)
                    insertCmd.Parameters.AddWithValue("@Product_image", arrimage2)
                    insertCmd.Parameters.AddWithValue("@expdate", DateTimePicker1.Value.Date)
                    insertCmd.ExecuteNonQuery()
                    con.Close()
                End Using

                ' Clear fields after insert
                clearform()
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
                    clearform()
                    Me.STOCKSTableAdapter.Fill(Me.SHITSTEMDataSet.STOCKS)

                End Using
            End If
        End If
    End Sub


    Private Sub Label7_Click(sender As Object, e As EventArgs)
        MessageBox.Show("To Edit or Delete a Product, Just select in the Grid", "Edit Stocks")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        clearform()
    End Sub


    Private Sub clearform()
        STOCKSDataGridView.ClearSelection()
        TextBox7.Text = ""
        TextBox8.Text = ""
        TextBox6.Text = ""
        TextBox5.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox1.Text = ""
        ComboBox1.Text = ""
        PictureBox1.Image = Nothing
        PictureBox2.Image = My.Resources.errorimage
        Button5.Visible = False
        TextBox8.Enabled = True
        Button5.Visible = True
        TextBox7.ReadOnly = False
        DateTimePicker1.Value = Date.Today
    End Sub


    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        If MessageBox.Show("Are you sure you want to update this product?", "Confirm Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            If TextBox8.Text = "" Or TextBox7.Text = "" Or TextBox6.Text = "" Or TextBox5.Text = "" Or TextBox3.Text = "" Then
                MessageBox.Show("Please fill in all fields", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                Item_no = TextBox8.Text
                Product_name = TextBox7.Text
                Quantity = TextBox6.Text
                Price = TextBox5.Text
                Cost = TextBox3.Text
                product_group = ComboBox1.Text

                Dim Filesize As UInt32
                Dim mstream As New System.IO.MemoryStream
                PictureBox1.Image.Save(mstream, System.Drawing.Imaging.ImageFormat.Png)
                Dim arrimage() As Byte = mstream.GetBuffer()
                Filesize = mstream.Length
                mstream.Close()

                Dim Filesize2 As UInt32
                Dim mstream2 As New System.IO.MemoryStream
                PictureBox2.Image.Save(mstream2, System.Drawing.Imaging.ImageFormat.Png)
                Dim arrimage2() As Byte = mstream2.GetBuffer()
                Filesize2 = mstream2.Length
                mstream2.Close()

                Dim query As String = "UPDATE stocks SET Item_no=@Item_no, Product_name=@Product_name, product_group=@product_group, Quantity=@Quantity, Cost=@Cost, price=@price, barcode=@barcode, product_image=@product_image, expdate=@expdate WHERE Item_no=@Item_no"

                Using cmd As New SqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@Item_no", Item_no)
                    cmd.Parameters.AddWithValue("@Product_name", Product_name)
                    cmd.Parameters.AddWithValue("@product_group", product_group)
                    cmd.Parameters.AddWithValue("@Quantity", Quantity)
                    cmd.Parameters.AddWithValue("@Price", Price)
                    cmd.Parameters.AddWithValue("@Cost", Cost)
                    cmd.Parameters.AddWithValue("@barcode", arrimage)
                    cmd.Parameters.AddWithValue("@product_image", arrimage2)
                    cmd.Parameters.AddWithValue("@expdate", DateTimePicker1.Value.Date)
                    con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                    clearform()
                    Me.STOCKSTableAdapter.Fill(Me.SHITSTEMDataSet.STOCKS)

                End Using
            End If
        End If
        Button5.Visible = True
        TextBox7.ReadOnly = False

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
                            TextBox3.Text = dt.Rows(0)("Cost").ToString()
                            ComboBox1.Text = dt.Rows(0)("product_group").ToString()
                            Button5.Visible = False

                            ' Set expiration date
                            If Not IsDBNull(dt.Rows(0)("expdate")) Then
                                DateTimePicker1.Value = Convert.ToDateTime(dt.Rows(0)("expdate"))
                            Else
                                DateTimePicker1.Value = Date.Today ' or any fallback default
                            End If

                            ' Load image
                            If Not IsDBNull(dt.Rows(0)("product_image")) Then
                                Dim imageData() As Byte = CType(dt.Rows(0)("product_image"), Byte())
                                Using ms As New MemoryStream(imageData)
                                    PictureBox2.Image = Image.FromStream(ms)
                                    PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage
                                End Using
                            Else
                                PictureBox2.Image = My.Resources.errorimage
                            End If
                        Else
                            clearform()
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
            Case "Siomai"
                product_group = "FD"
            Case "Siopao"
                product_group = "FD"
            Case "Drinks"
                product_group = "DR"
            Case Else
                product_group = "Na"
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





    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        Dim openFileDialog As New OpenFileDialog()

        With openFileDialog
            .Title = "Select an Image"
            .Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp"
            .Multiselect = False
        End With

        If openFileDialog.ShowDialog() = DialogResult.OK Then
            Dim selectedFile As String = openFileDialog.FileName


            Dim fileInfo As New FileInfo(selectedFile)
            If fileInfo.Length > 1048576 Then ' 1MB = 1048576 bytes
                MessageBox.Show("Image size must be less than 1MB.", "File Too Large", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Dim originalImage As Image = Image.FromFile(selectedFile)
            Dim resizedImage As Image = ResizeImage(originalImage, 200, 200) ' Adjust size as needed


            PictureBox2.Image = resizedImage
            PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage
        End If
    End Sub
    Private Function ResizeImage(img As Image, maxWidth As Integer, maxHeight As Integer) As Image
        Dim ratioX As Double = maxWidth / img.Width
        Dim ratioY As Double = maxHeight / img.Height
        Dim ratio As Double = Math.Min(ratioX, ratioY)

        Dim newWidth As Integer = CInt(img.Width * ratio)
        Dim newHeight As Integer = CInt(img.Height * ratio)

        Dim newImage As New Bitmap(newWidth, newHeight)
        Using g As Graphics = Graphics.FromImage(newImage)
            g.DrawImage(img, 0, 0, newWidth, newHeight)
        End Using

        Return newImage
    End Function

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click
        PictureBox2.Image = Nothing
    End Sub

    Private Sub Guna2TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Guna2TabControl1.SelectedIndexChanged
        Dim selectedIndex As Integer = Guna2TabControl1.SelectedIndex
        Dim selectedTab As TabPage = Guna2TabControl1.SelectedTab

        If selectedIndex = 1 Then
            clearform()
        End If
        If selectedIndex = 0 Then
            Me.STOCKSTableAdapter.Fill(Me.SHITSTEMDataSet.STOCKS)
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Dim searchTerm As String = TextBox1.Text.Trim()

        If String.IsNullOrEmpty(searchTerm) Then
            STOCKSBindingSource.RemoveFilter() ' Show all if empty
        Else
            ' Example: Search by "firstname" column
            STOCKSBindingSource.Filter = $"product_name LIKE '%{searchTerm}%'"
        End If
    End Sub
    Private Sub DateTimePicker1_Leave(sender As Object, e As EventArgs) Handles DateTimePicker1.Leave

        If DateTimePicker1.Value.Date <= Date.Today Then
            MessageBox.Show("Expiration date must be in the future.", "Invalid Expiration", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
    End Sub

    Private Sub ExpireOldProducts()
        Try
            Opencon()

            ' Update all products where expdate is today or earlier
            Dim expireQuery As String = "
            UPDATE STOCKS
            SET Quantity = 0
            WHERE expdate <= @today
        "

            Using cmd As New SqlCommand(expireQuery, con)
                cmd.Parameters.AddWithValue("@today", Date.Today)
                Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

                If rowsAffected > 0 Then

                End If
            End Using

        Catch ex As Exception
            MessageBox.Show("Error updating expired products: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If con.State = ConnectionState.Open Then con.Close()
        End Try
    End Sub



    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

        If TextBox3.Text IsNot "" Then
            Cost = TextBox3.Text
        End If
    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged
        If TextBox5.Text IsNot "" Then
            Price = TextBox5.Text
        End If

    End Sub
    Private Sub TextBox5_MouseLeave(sender As Object, e As EventArgs) Handles TextBox5.Leave
        If Cost >= Price Then
            TextBox5.Text = "0"
            MsgBox("Price cannot be less than the cost")
        End If
    End Sub
End Class
