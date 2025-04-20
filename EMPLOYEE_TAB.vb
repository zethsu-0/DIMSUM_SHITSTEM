Imports System.Data.SqlClient
Imports Guna.UI2.WinForms
Imports System.IO
Imports Microsoft.VisualBasic.ApplicationServices

Public Class EMPLOYEE_TAB
    Public Property user_Role As String
    Public Property User_id As String

    Private Sub EMPLOYEE_TAB_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Opencon()
        con.Close()
        LoadLoggedInUserIntoPanel1()
        LoadOtherUsersIntoFlowLayoutPanel()
    End Sub
    Private Sub LoadLoggedInUserIntoPanel1()
        Panel1.Controls.Clear()
        Dim userPhoto As Image = Nothing
        Try
            con.Open()
            Dim query As String = "SELECT Photo FROM login WHERE user_id = @userId"
            Using cmd As New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@userId", User_id)
                Dim result = cmd.ExecuteScalar()
                If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                    Dim imgBytes() As Byte = DirectCast(result, Byte())
                    Using ms As New MemoryStream(imgBytes)
                        userPhoto = Image.FromStream(ms)
                    End Using
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading user photo: " & ex.Message)
        Finally
            If con.State = ConnectionState.Open Then con.Close()
        End Try

        If user_Role = "Owner" OrElse user_Role = "Manager" Then
            Dim userPanel As New Panel()
            userPanel.Width = 250
            userPanel.Height = 180
            userPanel.BackColor = If(user_Role = "Owner", Color.LightGoldenrodYellow, Color.LightBlue)
            userPanel.BorderStyle = BorderStyle.FixedSingle
            userPanel.Padding = New Padding(10)


            Dim lblTitle As New Label()
            lblTitle.Text = $" {user_Role.ToUpper()}"
            lblTitle.Font = New Font("Arial", 12, FontStyle.Bold)
            lblTitle.Location = New Point(10, 10)
            lblTitle.AutoSize = True

            Dim lblUserId As New Label()
            lblUserId.Text = $"ID: {User_id}"
            lblUserId.Location = New Point(10, 70)
            lblUserId.AutoSize = True

            Dim editbtn As New Guna2Button()
            editbtn.Text = "Edit"
            editbtn.Size = New Size(60, 20)
            editbtn.Location = New Point(100, 190)
            editbtn.Tag = Me.User_id
            AddHandler editbtn.Click, AddressOf EditUser_Click
            userPanel.Controls.Add(editbtn)

            Dim picBox As New PictureBox()
            picBox.Size = New Size(80, 80)
            picBox.Location = New Point(60, 70)
            picBox.SizeMode = PictureBoxSizeMode.StretchImage
            picBox.Image = If(userPhoto IsNot Nothing, userPhoto, My.Resources.defaulticon)


            userPanel.Controls.AddRange({lblTitle, lblUserId, editbtn, picBox})

            Panel1.Controls.Add(userPanel)
        End If
    End Sub
    Private Sub LoadOtherUsersIntoFlowLayoutPanel()
        FlowLayoutPanel1.Controls.Clear()

        Try
            con.Open()
            Dim query As String = "
            SELECT user_id, firstname, lastname, role, age, address, phone_no, photo
              FROM login
             WHERE user_id <> @currentUserId
               AND (
                    (@currentRole = 'Owner')
                 OR (@currentRole = 'Manager' AND role = 'Employee')
               )"

            Using cmd As New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@currentUserId", User_id)
                cmd.Parameters.AddWithValue("@currentRole", user_Role)

                Using reader As SqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        ' Create panel for each user
                        Dim userPanel As New Panel()
                        userPanel.Tag = reader("user_id").ToString()
                        userPanel.Width = 200
                        userPanel.Height = 250
                        userPanel.BackColor = Color.White
                        userPanel.BorderStyle = BorderStyle.FixedSingle
                        userPanel.Margin = New Padding(5)

                        ' Add user details
                        Dim lblName As New Label()
                        lblName.Text = $"{reader("firstname")} {reader("lastname")}"
                        lblName.Font = New Font("Arial", 10, FontStyle.Bold)
                        lblName.Location = New Point(10, 10)
                        lblName.AutoSize = True

                        Dim lblRole As New Label()
                        lblRole.Text = $"Role: {reader("role")}"
                        lblRole.Location = New Point(10, 40)

                        Dim lblUserId As New Label()
                        lblUserId.Text = $"ID: {reader("user_id")}"
                        lblUserId.Location = New Point(10, 70)

                        Dim editbtn As New Guna2Button()
                        editbtn.Text = "Edit"
                        editbtn.Size = New Size(60, 20)
                        editbtn.Location = New Point(100, 190)
                        editbtn.Tag = reader("user_id").ToString()
                        AddHandler editbtn.Click, AddressOf EditUser_Click

                        Dim picBox As New PictureBox()
                        picBox.Size = New Size(80, 80)
                        picBox.Location = New Point(60, 70)
                        picBox.SizeMode = PictureBoxSizeMode.StretchImage

                        If Not IsDBNull(reader("Photo")) Then
                            Dim bytes As Byte() = DirectCast(reader("Photo"), Byte())
                            Using ms As New MemoryStream(bytes)
                                picBox.Image = Image.FromStream(ms)
                            End Using
                        Else
                            picBox.Image = My.Resources.defaulticon
                        End If


                        userPanel.Controls.AddRange({lblName, lblRole, lblUserId, editbtn, picBox})


                        FlowLayoutPanel1.Controls.Add(userPanel)
                    End While
                End Using
            End Using
            con.Close()
        Catch ex As Exception
            MessageBox.Show($"Error loading users: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub EditUser_Click(sender As Object, e As EventArgs)
        Dim clickedButton As Guna2Button = DirectCast(sender, Guna2Button)
        Dim targetUserId As String = clickedButton.Tag.ToString()
        If con IsNot Nothing AndAlso con.State = ConnectionState.Open Then con.Close()
        Try
            con.Open()
            Dim query As String = "SELECT * FROM login WHERE user_id = @targetUserId"
            Using cmd As New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@targetUserId", targetUserId)

                Using reader As SqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        Dim editForm As New EditUserForm()
                        With editForm
                            .user_id = reader("user_id").ToString()
                            .txtFirstName.Text = reader("firstname").ToString()
                            .txtLastName.Text = reader("lastname").ToString()
                            editForm.currentRole = reader("role").ToString()

                            .txtAge.Text = reader("age").ToString()
                            .txtAddress.Text = reader("address").ToString()
                            .txtPhone.Text = reader("phone_no").ToString()
                            .txtpassword.Text = reader("Password").ToString()

                            ' Load image if exists
                            If Not IsDBNull(reader("Photo")) Then
                                Dim bytes As Byte() = DirectCast(reader("Photo"), Byte())
                                Using ms As New MemoryStream(bytes)
                                    .picProfile.Image = Image.FromStream(ms)
                                    .picProfile.SizeMode = PictureBoxSizeMode.StretchImage
                                End Using
                            End If
                        End With
                        editForm.LoggedInUserRole = Me.user_Role
                        editForm.LoggedInUserId = Me.User_id
                        editForm.ShowDialog()

                        LoadLoggedInUserIntoPanel1()
                        LoadOtherUsersIntoFlowLayoutPanel()
                    End If
                End Using
            End Using
            con.Close()
        Catch ex As Exception
            MessageBox.Show($"Error loading user data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub addemployeebtn_Click(sender As Object, e As EventArgs) Handles addemployeebtn.Click
        Dim addForm As New EditUserForm()
        addForm.IsNewUser = True
        addForm.LoggedInUserRole = Me.user_Role
        addForm.LoggedInUserId = Me.User_id
        addForm.ShowDialog()

        LoadLoggedInUserIntoPanel1()
        LoadOtherUsersIntoFlowLayoutPanel()
    End Sub
End Class
