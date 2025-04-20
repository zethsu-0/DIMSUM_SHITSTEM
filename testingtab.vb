Imports System.Data.SqlClient
Imports System.IO
Imports System.Web.Security
Imports Guna.UI2.WinForms

Public Class testingtab
    Private Sub testingtab_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Opencon()
        con.Close()
        LoadUsers()

    End Sub
    Private Sub LoadUsers()
        FlowLayoutPanel1.Controls.Clear()
        Panel1.Controls.Clear()

        Try
            con.Open()
            Dim query As String = "SELECT user_id, firstname, lastname, role, Photo FROM login"
            Using cmd As New SqlCommand(query, con)
                Using reader As SqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        ' Get user data
                        Dim userId As String = reader("user_id").ToString()
                        Dim firstName As String = reader("firstname").ToString()
                        Dim lastName As String = reader("lastname").ToString()
                        Dim role As String = reader("role").ToString()

                        ' Create a panel for each user
                        Dim userPanel As New Panel()
                        userPanel.Width = 200  ' Fixed width
                        userPanel.Height = 220 ' Fixed height
                        userPanel.Margin = New Padding(10)
                        userPanel.BackColor = Color.White
                        userPanel.BorderStyle = BorderStyle.FixedSingle
                        userPanel.Margin = New Padding(10) ' Spacing between panels



                        ' --- PictureBox (Top) ---
                        Dim picBox As New PictureBox()
                        picBox.Width = 100
                        picBox.Height = 100
                        picBox.SizeMode = PictureBoxSizeMode.StretchImage
                        picBox.Location = New Point(50, 10) ' Centered horizontally

                        ' Load image if available (assuming BLOB data in DB)
                        If Not IsDBNull(reader("Photo")) Then
                            Try
                                Dim imageBytes As Byte() = DirectCast(reader("Photo"), Byte())
                                Using ms As New MemoryStream(imageBytes)
                                    picBox.Image = Image.FromStream(ms)
                                End Using
                            Catch ex As Exception
                                picBox.Image = My.Resources.defaulticon ' Fallback image
                            End Try
                        Else
                            picBox.Image = My.Resources.defaulticon ' Default if no image
                        End If

                        ' --- Labels for User Info ---
                        ' User ID
                        Dim lblUserId As New Label()
                        lblUserId.Text = $"ID: {userId}"
                        lblUserId.Location = New Point(10, 120) ' Below picture
                        lblUserId.AutoSize = True

                        ' First Name
                        Dim lblFirstName As New Label()
                        lblFirstName.Text = $"First: {firstName}"
                        lblFirstName.Location = New Point(10, 140)
                        lblFirstName.AutoSize = True

                        ' Last Name
                        Dim lblLastName As New Label()
                        lblLastName.Text = $"Last: {lastName}"
                        lblLastName.Location = New Point(10, 160)
                        lblLastName.AutoSize = True
                        Dim editbtn As New Guna2Button()
                        editbtn.Text = "Edit"
                        editbtn.Size = New Size(60, 20)
                        editbtn.Location = New Point(100, 190)
                        editbtn.Tag = userId
                        AddHandler editbtn.Click, AddressOf EditUser_Click

                        ' Add controls to the panel
                        userPanel.Controls.Add(picBox)
                        userPanel.Controls.Add(lblUserId)
                        userPanel.Controls.Add(lblFirstName)
                        userPanel.Controls.Add(lblLastName)
                        userPanel.Controls.Add(editbtn)

                        If role = "Owner" Then
                            Panel1.Controls.Add(userPanel)  ' Add to Panel1
                        Else
                            FlowLayoutPanel1.Controls.Add(userPanel)  ' Add to FlowLayoutPanel
                        End If
                    End While
                End Using
            End Using
            con.Close()
        Catch ex As Exception
            MessageBox.Show($"Error loading users: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub EditUser_Click(sender As Object, e As EventArgs)
        Dim btn As Guna2Button = DirectCast(sender, Guna2Button)
        Dim userId As String = btn.Tag.ToString()
        Try
            con.Open()
            Dim query As String = "SELECT * FROM login WHERE user_id = @userId"
            Using cmd As New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@userId", userId)
                Using reader As SqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then

                        Dim editForm As New EditUserForm()
                        editForm.txtUserId.Text = reader("user_id").ToString()
                        editForm.txtFirstName.Text = reader("firstname").ToString()
                        editForm.txtLastName.Text = reader("lastname").ToString()
                        editForm.txtAge.Text = reader("age").ToString()
                        editForm.txtAddress.Text = reader("address").ToString()
                        editForm.txtPhone.Text = reader("Phone_no").ToString()
                        editForm.cboRole.Text = reader("role").ToString()

                        If Not IsDBNull(reader("Photo")) Then
                            Dim imageBytes As Byte() = DirectCast(reader("Photo"), Byte())
                            Using ms As New MemoryStream(imageBytes)
                                editForm.picProfile.Image = Image.FromStream(ms)
                            End Using
                        End If

                        editForm.ShowDialog()
                    End If
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show($"Error loading user data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If con IsNot Nothing AndAlso con.State = ConnectionState.Open Then con.Close()
        End Try
    End Sub

End Class