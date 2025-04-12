Imports System.Data.SqlClient

Public Class EMPLOYEE_TAB

    Dim user_id As String
    Dim firstname As String
    Dim lastname As String
    Dim age As String
    Dim address As String
    Dim Phone_no As String
    Dim password As String
    Dim role As String
    Public Property user_Role As String

    Private Sub EMPLOYEE_TAB_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Opencon()
        con.Close()
        Me.LoginTableAdapter.Fill(Me.SHITSTEMDataSet.login)
        If user_Role = "Owner" Then
            LoginBindingSource.Filter = "role <> 'Owner'"
            ComboBox1.Items.Clear()
            ComboBox1.Items.Add("Employee")
            ComboBox1.Items.Add("Manager")
        End If

        If user_role = "Manager" Then
            LoginBindingSource.Filter = "role <> 'Manager' AND role <> 'Owner'"

            ComboBox1.Items.Clear()
            ComboBox1.Items.Add("Employee")
        End If
        Me.BeginInvoke(Sub()
                           LoginDataGridView.ClearSelection()

                       End Sub)
    End Sub




    Private Sub addemplybtn_Click(sender As Object, e As EventArgs) Handles addemplybtn.Click
        Panel1.Visible = True
        resetbtn()
        addbtn.Visible = True
        closebtn.Visible = True
        propmt1.Visible = False
        Panel2.Padding = Nothing
        LoginDataGridView.ClearSelection()
        LoginDataGridView.Enabled = False
        cleartextboxes()
    End Sub

    Private Sub closebtn_Click(sender As Object, e As EventArgs) Handles closebtn.Click
        closebtn.Visible = False
        Panel1.Visible = False
        Panel2.Padding = Nothing
        propmt1.Visible = False
        LoginDataGridView.Enabled = False
        LoginDataGridView.ClearSelection()
        cleartextboxes()
        resetbtn()
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs)
        Panel1.Visible = True
        closebtn.Visible = True
        LoginDataGridView.Enabled = True
        resetbtn()
        deletebtn.Visible = True
    End Sub





    Private Sub addbtn_Click(sender As Object, e As EventArgs) Handles addbtn.Click
        password = TextBox6.Text
        allowedit = False
        Try
            con.Open()

            If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or TextBox6.Text = "" Or ComboBox1.Text = "" Then
                MessageBox.Show("Please Fill all the SHITS")
            Else

                role = ComboBox1.Text
                firstname = TextBox1.Text
                lastname = TextBox2.Text
                age = TextBox3.Text
                address = TextBox4.Text
                Phone_no = TextBox5.Text

                Dim insertQuery As String = "INSERT INTO login (firstname, lastname, age, address, Phone_no, password,role, user_id) VALUES (@firstname, @lastname, @age, @address,@Phone_no,@password,@role,@user_id)"
                Using insertCmd As New SqlCommand(insertQuery, con)
                    insertCmd.Parameters.AddWithValue("@user_id", user_id)
                    insertCmd.Parameters.AddWithValue("@firstname", firstname)
                    insertCmd.Parameters.AddWithValue("@lastname", lastname)
                    insertCmd.Parameters.AddWithValue("@role", role)
                    insertCmd.Parameters.AddWithValue("@age", age)
                    insertCmd.Parameters.AddWithValue("@address", address)
                    insertCmd.Parameters.AddWithValue("@Phone_no", Phone_no)
                    insertCmd.Parameters.AddWithValue("@password", password)

                    insertCmd.ExecuteNonQuery()
                    con.Close()
                End Using
                MsgBox("Your User_ID: " & user_id & vbCrLf & "Your Password: " & password)

                LoginDataGridView.ReadOnly = True

                Me.LoginTableAdapter.Fill(Me.SHITSTEMDataSet.login)
                cleartextboxes()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If con.State = ConnectionState.Open Then con.Close()
        End Try

    End Sub


    Dim allowedit As Boolean = False
    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        allowedit = True

        Panel2.Padding = New Padding(3, 3, 3, 3)
        closebtn.Visible = True
        addbtn.Visible = False
        deletebtn.Visible = True
        savebtn.Visible = True
        Panel1.Visible = True
        propmt1.Visible = True
        LoginDataGridView.Enabled = True
        LoginDataGridView.ClearSelection()
    End Sub

    Private Sub LoginDataGridView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles LoginDataGridView.CellClick
        propmt1.Visible = False
        TextBox1.Text = LoginDataGridView.Rows(e.RowIndex).Cells(1).Value.ToString() ' firstname
        TextBox2.Text = LoginDataGridView.Rows(e.RowIndex).Cells(2).Value.ToString() ' lastname
        ComboBox1.Text = LoginDataGridView.Rows(e.RowIndex).Cells(3).Value.ToString() ' role
        TextBox3.Text = LoginDataGridView.Rows(e.RowIndex).Cells(4).Value.ToString() ' age
        TextBox4.Text = LoginDataGridView.Rows(e.RowIndex).Cells(5).Value.ToString() ' address
        TextBox5.Text = LoginDataGridView.Rows(e.RowIndex).Cells(6).Value.ToString() ' phone_no
        TextBox6.Text = LoginDataGridView.Rows(e.RowIndex).Cells(7).Value.ToString() ' phone_no
        user_id = LoginDataGridView.Rows(e.RowIndex).Cells(0).Value.ToString()
    End Sub

    Private Sub savebtn_Click(sender As Object, e As EventArgs) Handles savebtn.Click
        Try
            Opencon()
            If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or TextBox6.Text = "" Or ComboBox1.Text = "" Then
                MessageBox.Show("Please Fill all the SHITS")
            Else
                role = ComboBox1.Text
                firstname = TextBox1.Text
                lastname = TextBox2.Text
                age = TextBox3.Text
                address = TextBox4.Text
                Phone_no = TextBox5.Text
                password = TextBox6.Text

                Dim savequery As String = "UPDATE login SET firstname=@firstname, lastname=@lastname, role=@role, age=@age, address=@address, phone_no=@phone_no, password=@password WHERE user_id = @user_id"
                Using savecmd As New SqlCommand(savequery, con)
                    savecmd.Parameters.AddWithValue("@user_id", user_id)
                    savecmd.Parameters.AddWithValue("@firstname", firstname)
                    savecmd.Parameters.AddWithValue("@lastname", lastname)
                    savecmd.Parameters.AddWithValue("@role", role)
                    savecmd.Parameters.AddWithValue("@age", age)
                    savecmd.Parameters.AddWithValue("@address", address)
                    savecmd.Parameters.AddWithValue("@Phone_no", Phone_no)
                    savecmd.Parameters.AddWithValue("@password", password)


                    savecmd.ExecuteNonQuery()

                    Me.LoginTableAdapter.Fill(Me.SHITSTEMDataSet.login)
                    cleartextboxes()
                End Using


            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            If con.State = ConnectionState.Open Then con.Close()
        End Try
    End Sub

    Private Sub deletebtn_Click(sender As Object, e As EventArgs) Handles deletebtn.Click
        If MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            firstname = TextBox1.Text

            Dim query As String = "DELETE FROM login WHERE user_id=@user_id"
            Using cmd As New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@user_id", user_id)
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                MessageBox.Show(firstname & "DELETED")

                Me.LoginTableAdapter.Fill(Me.SHITSTEMDataSet.login)
                cleartextboxes()

            End Using
        End If
    End Sub
    Private Sub cleartextboxes()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        ComboBox1.Text = ""
        user_id = ""
        LoginDataGridView.ClearSelection()
    End Sub
    Private Sub resetbtn()
        addbtn.Visible = False
        savebtn.Visible = False
        deletebtn.Visible = False
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If allowedit = False Then
            GenerateUserID()
        End If
    End Sub
    Private Sub GenerateUserID()

        con.Open()
        Dim rolePrefix As String = ""

        If ComboBox1.Text = "Employee" Then
            rolePrefix = "Em"
        ElseIf ComboBox1.Text = "Manager" Then
            rolePrefix = "Mg"
        ElseIf ComboBox1.Text = "Owner" Then
            rolePrefix = "Own"
        End If
        Dim cmd As New SqlCommand("SELECT COUNT(*) FROM login WHERE role = @role", con)
        cmd.Parameters.AddWithValue("@role", ComboBox1.Text)

        Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar()) + 1
        con.Close()

        ' Format the user ID (e.g. Em001)
        user_id = count.ToString("D3")
    End Sub
End Class
