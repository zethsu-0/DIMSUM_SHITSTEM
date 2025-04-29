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
        ResetRevenueIfNewDay()
        LoadLoggedInUserIntoPanel1()
        LoadOtherUsersIntoFlowLayoutPanel()
        Me.RemittancehistoryTableAdapter.Fill(Me.SHITSTEMDataSet.remittancehistory)
    End Sub

    Private Sub ResetRevenueIfNewDay()
        Try
            Opencon()
            Dim todayDate As Date = Date.Today

            ' 1) Read everything (no nested readers)
            Dim selectQuery As String = "
            SELECT user_id, revenue, dateofremittance, firstname, lastname
            FROM login
            WHERE role IN ('Owner','Manager','Employee')
        "
            Dim usersToReset As New List(Of (userId As String, revenue As Decimal, firstName As String, lastName As String))

            Using cmd As New SqlCommand(selectQuery, con)
                Using reader As SqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim userId = reader("user_id").ToString()
                        Dim revenueAmt = If(reader.IsDBNull(reader.GetOrdinal("revenue")), 0D, Convert.ToDecimal(reader("revenue")))
                        Dim lastResetVal = reader("dateofremittance")
                        Dim lastReset As Date? = If(lastResetVal Is DBNull.Value, CType(Nothing, Date?), CType(lastResetVal, Date))
                        ' if never reset or last reset <> today, and revenue > 0
                        If (Not lastReset.HasValue OrElse lastReset.Value.Date <> todayDate) AndAlso revenueAmt > 0 Then
                            usersToReset.Add((userId, revenueAmt, reader("firstname").ToString(), reader("lastname").ToString()))
                        End If
                    End While
                End Using
            End Using

            ' 2) Now reader is closed, do inserts & updates
            For Each u In usersToReset
                ' Insert into remittancehistory
                Using insertCmd As New SqlCommand("
                INSERT INTO remittancehistory
                  (User_id, revenue, date, firstname, lastname)
                VALUES
                  (@User_id, @revenue, @date, @firstname, @lastname)
            ", con)
                    insertCmd.Parameters.AddWithValue("@User_id", u.userId)
                    insertCmd.Parameters.AddWithValue("@revenue", u.revenue)
                    insertCmd.Parameters.AddWithValue("@date", todayDate)
                    insertCmd.Parameters.AddWithValue("@firstname", u.firstName)
                    insertCmd.Parameters.AddWithValue("@lastname", u.lastName)
                    insertCmd.ExecuteNonQuery()
                End Using

                ' Reset login.revenue & update dateofremittance
                Using resetCmd As New SqlCommand("
                UPDATE login
                SET revenue = 0,
                    dateofremittance = @today
                WHERE user_id = @userID
            ", con)
                    resetCmd.Parameters.AddWithValue("@today", todayDate)
                    resetCmd.Parameters.AddWithValue("@userID", u.userId)
                    resetCmd.ExecuteNonQuery()
                End Using
            Next

        Catch ex As Exception
            MessageBox.Show("Error resetting employee revenues: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If con.State = ConnectionState.Open Then con.Close()
        End Try
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
            userPanel.Width = 203
            userPanel.Height = 254
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
            lblUserId.Location = New Point(120, 10)
            lblUserId.AutoSize = True

            Dim editbtn As New Guna2Button()
            editbtn.Text = "Edit"
            editbtn.Size = New Size(60, 20)
            editbtn.Location = New Point(10, 210)
            editbtn.Tag = Me.User_id
            AddHandler editbtn.Click, AddressOf EditUser_Click
            userPanel.Controls.Add(editbtn)

            Dim picBox As New Guna2CirclePictureBox()
            picBox.Size = New Size(80, 80)
            picBox.Location = New Point(60, 40)
            picBox.SizeMode = PictureBoxSizeMode.StretchImage
            picBox.Image = If(userPhoto IsNot Nothing, userPhoto, My.Resources.defaulticon)


            userPanel.Controls.AddRange({lblTitle, lblUserId, editbtn, picBox})

            Panel1.Controls.Add(userPanel)

        End If
    End Sub
    Private Sub LoadOtherUsersIntoFlowLayoutPanel()

        If user_Role = "Manager" Then
            FlowLayoutPanel1.Visible = False
            Label1.Visible = False

        Else
            FlowLayoutPanel1.Visible = True

        End If

        FlowLayoutPanel1.Controls.Clear()
        FlowLayoutPanel2.Controls.Clear()

        Try
            con.Open()

            Dim query As String = "
        SELECT user_id, firstname, lastname, role, age, address, phone_no, photo, revenue 
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
                        userPanel.Tag = reader("user_id").ToString() ' Store user ID for reference
                        userPanel.Width = 200
                        userPanel.Height = 250 ' Increased height to potentially accommodate revenue better
                        userPanel.BackColor = Color.White
                        userPanel.BorderStyle = BorderStyle.FixedSingle
                        userPanel.Margin = New Padding(10) ' Increased margin slightly
                        userPanel.Padding = New Padding(5) ' Inner padding

                        ' User Photo
                        Dim picBox As New PictureBox() ' Consider Guna2CirclePictureBox if you want consistency
                        picBox.Size = New Size(60, 60) ' Adjusted size
                        picBox.Location = New Point(10, 10) ' Top-left
                        picBox.SizeMode = PictureBoxSizeMode.Zoom ' Zoom might be better than StretchImage

                        If Not IsDBNull(reader("Photo")) Then
                            Dim bytes As Byte() = DirectCast(reader("Photo"), Byte())
                            Using ms As New MemoryStream(bytes)
                                picBox.Image = Image.FromStream(ms)
                            End Using
                        Else
                            picBox.Image = My.Resources.defaulticon ' Ensure this resource exists
                        End If
                        userPanel.Controls.Add(picBox)

                        ' User Details (positioned relative to photo)
                        Dim leftMargin As Integer = picBox.Right + 10 ' Position details to the right of the photo
                        Dim currentTop As Integer = picBox.Top

                        Dim lblName As New Label()
                        lblName.Text = $"{reader("firstname")} {reader("lastname")}"
                        lblName.Font = New Font("Arial", 10, FontStyle.Bold)
                        lblName.Location = New Point(leftMargin, currentTop)
                        lblName.AutoSize = True
                        userPanel.Controls.Add(lblName)
                        currentTop += lblName.Height + 5 ' Move down for next label

                        Dim lblRole As New Label()
                        lblRole.Text = $"Role: {reader("role")}"
                        lblRole.Font = New Font("Arial", 9) ' Slightly smaller font
                        lblRole.Location = New Point(leftMargin, currentTop)
                        lblRole.AutoSize = True
                        userPanel.Controls.Add(lblRole)
                        currentTop += lblRole.Height + 5

                        Dim lblUserId As New Label()
                        lblUserId.Text = $"ID: {reader("user_id")}"
                        lblUserId.Font = New Font("Arial", 9)
                        lblUserId.Location = New Point(leftMargin, currentTop)
                        lblUserId.AutoSize = True
                        userPanel.Controls.Add(lblUserId)
                        currentTop += lblUserId.Height + 5

                        Dim lblRevenue As New Label()
                        ' Format revenue as currency or number
                        Dim revenueValue As Decimal = 0
                        If Not IsDBNull(reader("revenue")) Then
                            Decimal.TryParse(reader("revenue").ToString(), revenueValue)
                        End If
                        lblRevenue.Text = $"Revenue: ₱ {revenueValue}"
                        lblRevenue.Font = New Font("Arial", 9)
                        lblRevenue.Location = New Point(leftMargin, currentTop) ' Corrected location assignment
                        lblRevenue.AutoSize = True
                        userPanel.Controls.Add(lblRevenue) ' Add the revenue label
                        ' currentTop += lblRevenue.Height + 5 ' Update currentTop if more controls follow below details

                        ' Buttons (Positioned at the bottom)
                        Dim buttonTop As Integer = userPanel.Height - 35 ' Position buttons near the bottom

                        Dim editbtn As New Guna.UI2.WinForms.Guna2Button() ' Using Guna button for consistency
                        editbtn.Text = "Edit"
                        editbtn.Size = New Size(70, 25) ' Slightly larger
                        editbtn.Location = New Point(userPanel.Width - editbtn.Width - 10, buttonTop) ' Bottom-right
                        editbtn.Tag = reader("user_id").ToString()
                        AddHandler editbtn.Click, AddressOf EditUser_Click ' Ensure EditUser_Click exists and handles the sender/event args
                        userPanel.Controls.Add(editbtn)

                        Dim userRoleFromDb As String = reader("role").ToString()
                        If userRoleFromDb = "Manager" Then
                            FlowLayoutPanel1.Controls.Add(userPanel)
                        ElseIf userRoleFromDb = "Employee" Then
                            FlowLayoutPanel2.Controls.Add(userPanel)
                        End If

                    End While
                End Using ' reader closed/disposed
            End Using ' cmd disposed
            con.Close() ' Close connection

        Catch ex As SqlException
            MessageBox.Show($"Database error loading users: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            If con IsNot Nothing AndAlso con.State = ConnectionState.Open Then con.Close() ' Ensure close on DB error
        Catch ex As Exception
            MessageBox.Show($"General error loading users: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            If con IsNot Nothing AndAlso con.State = ConnectionState.Open Then con.Close() ' Ensure close on general error
        Finally
            ' Double-check connection state, though it should be closed in Try/Catch
            If con IsNot Nothing AndAlso con.State = ConnectionState.Open Then con.Close()
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
