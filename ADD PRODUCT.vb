Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Diagnostics
Imports System.Data.SqlClient
Public Class ADD_PRODUCT

    Private hasAddedNew As Boolean = False

    Private Sub ADD_PRODUCT_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Opencon()
        con.Close()
        Me.STOCKSTableAdapter.Fill(Me.SHITSTEMDataSet.STOCKS)
        STOCKSDataGridView.ClearSelection()
        ClearFormFields()
    End Sub

    Private Sub ClearFormFields()


    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        con.Open()
        Dim Item_no As String = TextBox1.Text
        Dim Product_name As String = TextBox2.Text
        Dim Quatity As String = TextBox3.Text
        Dim Price As String = TextBox4.Text
        If Not TextBox1.Text = "" Or Not TextBox2.Text = "" Or Not TextBox3.Text = "" Or Not TextBox4.Text = "" Then


            Dim insertQuery As String = "INSERT INTO STOCKS (Item_No, Product_name, Quatity, Price) VALUES (@Item_no, @Product_name, @Quatity, @Price)"
            Using insertCmd As New SqlCommand(insertQuery, con)
                insertCmd.Parameters.AddWithValue("@Item_no", Item_no)
                insertCmd.Parameters.AddWithValue("@Product_name", Product_name)
                insertCmd.Parameters.AddWithValue("@Quatity", Quatity)
                insertCmd.Parameters.AddWithValue("@Price", Price)
                insertCmd.ExecuteNonQuery()
            End Using
            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = ""
            TextBox4.Text = ""
            Dim viewForm As Form3 = Application.OpenForms.OfType(Of Form3)().FirstOrDefault()
            viewForm?.RefreshDataGridView()

            Me.STOCKSTableAdapter.Fill(Me.SHITSTEMDataSet.STOCKS)
            STOCKSBindingSource.ResetBindings(False)
            STOCKSDataGridView.ClearSelection()
            con.Close()
        Else
            MessageBox.Show("Please Fill all the SHITS")
            con.Close()
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            STOCKSBindingSource.RemoveCurrent()
            Me.Validate()
            STOCKSBindingSource.EndEdit()
            TableAdapterManager.UpdateAll(Me.SHITSTEMDataSet)


            Dim viewForm As Form3 = Application.OpenForms.OfType(Of Form3)().FirstOrDefault()
            If viewForm IsNot Nothing Then
                viewForm?.RefreshDataGridView()
            End If
        End If


    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        If STOCKSBindingSource.Current IsNot Nothing Then
            Dim currentRow As DataRowView = CType(STOCKSBindingSource.Current, DataRowView)
            If currentRow.Row.RowState = DataRowState.Added AndAlso String.IsNullOrWhiteSpace(currentRow("item_no").ToString()) Then
                STOCKSBindingSource.CancelEdit()
            End If
        End If
        STOCKSDataGridView.Visible = True
        Button1.Visible = False
        Button2.Visible = True
        hasAddedNew = False
        Form3.Hide()
        Label2.Visible = True
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        Button2.Visible = False
        Button1.Visible = True
        STOCKSDataGridView.Visible = False
        Label2.Visible = False
        Form3.Show()
    End Sub
End Class