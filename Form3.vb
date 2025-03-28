Imports System.Data.SqlClient
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports ZXing

Public Class Form3

    Private editmemo As Boolean = False
    Private openform As Boolean = False

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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


    Private Sub Form3_Click(sender As Object, e As EventArgs) Handles Me.Click
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
        Dim Item_no As String = TextBox8.Text
        Dim Product_name As String = TextBox7.Text
        Dim Quatity As String = TextBox6.Text
        Dim Price As String = TextBox5.Text

        Try
            con.Open()

            Dim Filesize As UInt32
            Dim mstream As New System.IO.MemoryStream
            PictureBox1.Image.Save(mstream, System.Drawing.Imaging.ImageFormat.Png)
            Dim arrimage() As Byte = mstream.GetBuffer()
            Filesize = mstream.Length
            mstream.Close()

            If TextBox8.Text = "" Or TextBox7.Text = "" Or TextBox6.Text = "" Or TextBox5.Text = "" Then
                MessageBox.Show("Please Fill all the SHITS")
            Else

                Dim insertQuery As String = "INSERT INTO STOCKS (Item_No, Product_name, Quatity, Price, Barcode) VALUES (@Item_no, @Product_name, @Quatity, @Price, @Barcode)"
                Using insertCmd As New SqlCommand(insertQuery, con)
                    insertCmd.Parameters.AddWithValue("@Item_no", Item_no)
                    insertCmd.Parameters.AddWithValue("@Product_name", Product_name)
                    insertCmd.Parameters.AddWithValue("@Quatity", Quatity)
                    insertCmd.Parameters.AddWithValue("@Price", Price)
                    insertCmd.Parameters.AddWithValue("@Barcode", arrimage)

                    insertCmd.ExecuteNonQuery()
                    con.Close()
                End Using
                TextBox8.Text = ""
                TextBox7.Text = ""
                TextBox6.Text = ""
                TextBox5.Text = ""
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
                    TextBox8.Text = ""
                    TextBox7.Text = ""
                    TextBox6.Text = ""
                    TextBox5.Text = ""
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
        TextBox8.Text = ""
        TextBox7.Text = ""
        TextBox6.Text = ""
        TextBox5.Text = ""
        TextBox8.Enabled = True
        Button5.Enabled = True
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
                Dim Item_no As Integer = TextBox8.Text
                Dim Product_name As String = TextBox7.Text
                Dim Quatity As String = TextBox6.Text
                Dim Price As String = TextBox5.Text


                Dim query As String = "UPDATE stocks SET Item_no=@Item_no,Product_name=@Product_name,Quatity=@Quatity,Price=@Price, barcode = @barcode WHERE Item_no = @Item_no"
                Using cmd As New SqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@Item_no", Item_no)
                    cmd.Parameters.AddWithValue("@Product_name", Product_name)
                    cmd.Parameters.AddWithValue("@Quatity", Quatity)
                    cmd.Parameters.AddWithValue("@Price", Price)
                    cmd.Parameters.AddWithValue("@barcode", arrimage)
                    con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                    TextBox8.Text = ""
                    TextBox7.Text = ""
                    TextBox6.Text = ""
                    TextBox5.Text = ""
                    Me.STOCKSTableAdapter.Fill(Me.SHITSTEMDataSet.STOCKS)
                    MessageBox.Show("Saved!")
                End Using
            End If
        End If



    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim query As String = "SELECT * FROM stocks WHERE Item_no = @search OR Product_name = @searchPattern"

        Using cmd As SqlCommand = New SqlCommand(query, con)

            cmd.Parameters.AddWithValue("@search", TextBox2.Text.Trim()) ' Exact match for Item_no
            cmd.Parameters.AddWithValue("@searchPattern", "%" & TextBox2.Text.Trim() & "%")

            Using da As New SqlDataAdapter()
                da.SelectCommand = cmd
                Using dt As New DataTable()


                    da.Fill(dt)
                    If dt.Rows.Count > 0 Then
                        TextBox8.Text = dt.Rows(0)(0).ToString()
                        TextBox7.Text = dt.Rows(0)(1).ToString()
                        TextBox6.Text = dt.Rows(0)(2).ToString()
                        TextBox5.Text = dt.Rows(0)(3).ToString()
                    Else
                        TextBox8.Text = ""
                        TextBox7.Text = ""
                        TextBox6.Text = ""
                        TextBox5.Text = ""
                    End If
                End Using
            End Using
        End Using
    End Sub

    Dim item_number As String
    Dim product_name As String



    Public Sub Barcodegenerator()

        Dim bargen = item_number + product_name
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
        product_name = TextBox7.Text
        Barcodegenerator()
    End Sub

    Private Sub TextBox8_TextChanged(sender As Object, e As EventArgs) Handles TextBox8.TextChanged
        item_number = TextBox8.Text
        Barcodegenerator()
    End Sub

End Class