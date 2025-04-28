Imports System.Data.SqlClient
Imports System.Windows.Interop
Imports Guna.UI2.WinForms



Public Class LOGIN_PAGE
    Dim count As Integer = 0
    Dim roleSelect As String = ""
    Private Sub LOGIN_PAGE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadscreen()
        Opencon()
        con.Close()
        ifownerexists()
        PictureBox1.Visible = True
        PictureBox2.Visible = False
        manager_ico.Visible = False
        owner_ico.Visible = False
        crew_ico.Visible = False
    End Sub

    Private Sub ifownerexists()
        con.Open()
        Dim query As String = "SELECT COUNT(*) FROM Login WHERE role = 'Owner'"
        Dim cmd As New SqlCommand(query, con)

        count = Convert.ToInt32(cmd.ExecuteScalar())

        If count > 0 Then
            Button6.Visible = False
        Else
            Button6.Visible = True
        End If
        con.Close()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        con.Open()
        cmd = New SqlCommand("login1", con)
        With cmd
            .CommandType = CommandType.StoredProcedure
            .Parameters.AddWithValue("@user_id", TextBox1.Text)
            .Parameters.AddWithValue("@pass", TextBox2.Text)
            .Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output
            .Parameters.Add("@role", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
            .ExecuteNonQuery()
        End With
        con.Close()

        Dim userRole As String = If(cmd.Parameters("@role").Value IsNot DBNull.Value, cmd.Parameters("@role").Value.ToString(), "")
        If CInt(cmd.Parameters("@result").Value = 1) Then
            If roleSelect = userRole Then
                Select Case userRole
                    Case "Employee"
                        Dim user_Role As String = userRole
                        Dim user_id As String = TextBox1.Text
                        If Not String.IsNullOrEmpty(user_Role) Then
                            Dim CASHIER As New CASHIER()
                            CASHIER.user_Role = user_Role
                            CASHIER.user_id = user_id
                            CASHIER.Show()
                            Me.Hide()
                            showRolefields()
                        Else
                            MessageBox.Show("Please enter a valid User ID!", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If


                    Case "Manager"

                        Dim user_Role As String = userRole
                        Dim user_id As String = TextBox1.Text


                        If Not String.IsNullOrEmpty(user_Role) Then
                            Dim form2 As New Form2()
                            Dim CASHIER As New CASHIER()
                            form2.user_role = user_Role
                            form2.user_id = user_id
                            CASHIER.user_id = user_id
                            form2.Show()
                            Me.Hide()
                            showRolefields()
                        Else
                            MessageBox.Show("Please enter a valid User ID!", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If

                    Case "Owner"
                        Dim user_Role As String = userRole
                        Dim user_id As String = TextBox1.Text

                        If Not String.IsNullOrEmpty(user_id) Then
                            Dim form2 As New Form2()
                            Dim CASHIER As New CASHIER()
                            form2.user_role = user_Role
                            form2.user_id = user_id
                            CASHIER.user_id = user_id
                            form2.Show()
                            Me.Hide()
                            showRolefields()
                        Else
                            MessageBox.Show("Please enter a valid User ID!", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If

                    Case Else
                        MsgBox("Role not recognized")
                End Select
            Else
                MsgBox("You are not assigned to this role!")
            End If
        Else
            MsgBox("Login Failed", vbCritical)
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Showloginfields()
        Button2.Visible = False
        Button3.Visible = False
        Button4.Visible = False
        Button5.Visible = True
        Label1.Visible = True
        roleSelect = "Employee"
        PictureBox1.Visible = False
        PictureBox2.Visible = True
        manager_ico.Visible = False
        owner_ico.Visible = False
        crew_ico.Visible = True
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Showloginfields()
        Button2.Visible = False
        Button3.Visible = False
        Button4.Visible = False
        Button5.Visible = True
        Label2.Visible = True
        roleSelect = "Manager"
        PictureBox1.Visible = False
        PictureBox2.Visible = True
        manager_ico.Visible = True
        owner_ico.Visible = False
        crew_ico.Visible = False
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If count = 0 Then
            MsgBox("Owner does not exists yet")
        Else
            Showloginfields()
            Button2.Visible = False
            Button3.Visible = False
            Button4.Visible = False
            Button5.Visible = True
            Label3.Visible = True
            roleSelect = "Owner"
            PictureBox1.Visible = False
            PictureBox2.Visible = True
            manager_ico.Visible = False
            owner_ico.Visible = True
            crew_ico.Visible = False
        End If



    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        TextBox1.Visible = False
        TextBox2.Visible = False
        Button1.Visible = False
        Button5.Visible = False
        showRolefields()
        PictureBox1.Visible = True
        PictureBox2.Visible = False
        manager_ico.Visible = False
        owner_ico.Visible = False
        crew_ico.Visible = False
    End Sub
    Public Sub Showloginfields()
        TextBox1.Visible = True
        TextBox2.Visible = True
        Button1.Visible = True
        Guna2CheckBox1.Visible = True
    End Sub
    Public Sub showRolefields()
        Button1.Visible = False
        Button2.Visible = True
        Button3.Visible = True
        Button4.Visible = True
        Button5.Visible = False
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox1.Visible = False
        TextBox2.Visible = False
        Label1.Visible = False
        Label2.Visible = False
        Label3.Visible = False
        Guna2CheckBox1.Visible = False
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs)
        PRODUCTS.Show()
        Me.Hide()
    End Sub

    Private Sub Button6_Click_1(sender As Object, e As EventArgs) Handles Button6.Click
        Dim users As New Users()
        users.ShowDialog()

        ifownerexists()
    End Sub

    Dim txt1 As Boolean = False
    Dim txt2 As Boolean = False
    Private Sub TextBox1_Click(sender As Object, e As EventArgs)
        txt1 = True
        If txt1 = True Then
            TextBox1.Text = ""
        End If

    End Sub
    Private Sub TextBox2_Click(sender As Object, e As EventArgs)
        txt2 = True
        If txt2 = True Then
            TextBox2.PasswordChar = "*"
            TextBox2.Text = ""
        End If
    End Sub

    Private Sub LOGIN_PAGE_Click(sender As Object, e As EventArgs) Handles Me.Click
        Me.ActiveControl = Nothing
    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.A Then
            TextBox1.SelectAll()
            e.SuppressKeyPress = True
        End If
    End Sub
    Private Sub TextBox2_KeyDown(sender As Object, e As KeyEventArgs)
        If e.Control AndAlso e.KeyCode = Keys.A Then
            TextBox2.SelectAll()
            e.SuppressKeyPress = True
        End If
    End Sub


    Private loadingscreen As New loadingscreen()
    Private Sub loadscreen()
        Me.Controls.Add(loadingscreen)
        loadingscreen.BringToFront()
        loadingscreen.Dock = DockStyle.Fill
    End Sub

    Private Sub Guna2CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles Guna2CheckBox1.CheckedChanged
        If Guna2CheckBox1.Checked = True Then
            TextBox2.PasswordChar = Nothing
        End If
        If Guna2CheckBox1.Checked = False Then
            TextBox2.PasswordChar = "*"
        End If
    End Sub

    Private Sub Panel1_DoubleClick(sender As Object, e As EventArgs) Handles Panel1.DoubleClick
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Public Sub ResetLoginPage()
        PictureBox1.Visible = True
        PictureBox2.Visible = False
        manager_ico.Visible = False
        owner_ico.Visible = False
        crew_ico.Visible = False
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox1.Visible = False
        TextBox2.Visible = False
        Button1.Visible = False
        Button5.Visible = False
        Label1.Visible = False
        Label2.Visible = False
        Label3.Visible = False
        Button2.Visible = True
        Button3.Visible = True
        Button4.Visible = True
        Guna2CheckBox1.Checked = False
        Guna2CheckBox1.Visible = False
        roleSelect = ""
    End Sub
End Class
