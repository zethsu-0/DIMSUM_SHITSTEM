Imports System.Data.SqlClient
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Form3


    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Opencon()
        con.Close()
        STOCKSDataGridView.Width = 946
        Me.STOCKSTableAdapter.Fill(Me.SHITSTEMDataSet.STOCKS)
        GroupBox2.Visible = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        GroupBox2.Visible = True
        Button4.Visible = True
        Button3.Visible = True
        Button1.Visible = False
        STOCKSDataGridView.Width -= 300
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form2.Show()
        Me.Hide()
    End Sub

    Private Sub Form3_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Form2.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        GroupBox2.Visible = False
        GroupBox1.Visible = True
        Button4.Visible = True
        Button7.Visible = True
        Button3.Visible = False
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Button1.Visible = True
        Button4.Visible = False
        Button7.Visible = False
        Button3.Visible = False
        STOCKSDataGridView.Width += 300
        GroupBox2.Visible = False
        GroupBox1.Visible = False
    End Sub
    Private Sub STOCKSDataGridView_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles STOCKSDataGridView.CellClick
        If e.RowIndex >= 0 Then
            TextBox8.Text = STOCKSDataGridView.Rows(e.RowIndex).Cells(0).Value.ToString()
            TextBox7.Text = STOCKSDataGridView.Rows(e.RowIndex).Cells(1).Value.ToString()
            TextBox6.Text = STOCKSDataGridView.Rows(e.RowIndex).Cells(2).Value.ToString()
            TextBox5.Text = STOCKSDataGridView.Rows(e.RowIndex).Cells(3).Value.ToString()
        End If

    End Sub
    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

        If TextBox8.Text = "" Or TextBox7.Text = "" Or TextBox6.Text = "" Or TextBox5.Text = "" Then
            MessageBox.Show("Please fill in all fields" & vbCrLf & vbCrLf & "Or Select From the Grid", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Dim Item_no As Integer = TextBox8.Text
            Dim Product_name As String = TextBox7.Text
            Dim Quatity As String = TextBox6.Text
            Dim Price As String = TextBox5.Text

            Dim query As String = "UPDATE stocks SET Item_no=@Item_no,Product_name=@Product_name,Quatity=@Quatity,Price=@Price WHERE Item_no = @Item_no"
            Using cmd As SqlCommand = New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@Item_no", Item_no)
                cmd.Parameters.AddWithValue("@Product_name", Product_name)
                cmd.Parameters.AddWithValue("@Quatity", Quatity)
                cmd.Parameters.AddWithValue("@Price", Price)
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
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click

        Dim Item_no As String = TextBox1.Text
        Dim Product_name As String = TextBox2.Text
        Dim Quatity As String = TextBox3.Text
        Dim Price As String = TextBox4.Text
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Then
            MessageBox.Show("Please Fill all the SHITS")
        Else

            Dim insertQuery As String = "INSERT INTO STOCKS (Item_No, Product_name, Quatity, Price) VALUES (@Item_no, @Product_name, @Quatity, @Price)"
            Using insertCmd As New SqlCommand(insertQuery, con)
                insertCmd.Parameters.AddWithValue("@Item_no", Item_no)
                insertCmd.Parameters.AddWithValue("@Product_name", Product_name)
                insertCmd.Parameters.AddWithValue("@Quatity", Quatity)
                insertCmd.Parameters.AddWithValue("@Price", Price)
                con.Open()
                insertCmd.ExecuteNonQuery()
                con.Close()
            End Using
            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = ""
            TextBox4.Text = ""


            Me.STOCKSTableAdapter.Fill(Me.SHITSTEMDataSet.STOCKS)

        End If

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Dim Item_no As String = TextBox1.Text
            Dim query As String = "DELETE FROM STOCKS WHERE Item_no=@Item_no"

            If Not Item_no = "" Then
                Using cmd As SqlCommand = New SqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@Item_no", Item_no)
                    con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                    TextBox1.Text = ""
                    TextBox2.Text = ""
                    TextBox3.Text = ""
                    TextBox4.Text = ""
                    Me.STOCKSTableAdapter.Fill(Me.SHITSTEMDataSet.STOCKS)
                    MessageBox.Show("success DELETED")
                End Using
            End If
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        GroupBox2.Visible = True
        GroupBox1.Visible = False
        Button4.Visible = True
        Button3.Visible = True
        Button1.Visible = False
    End Sub
End Class