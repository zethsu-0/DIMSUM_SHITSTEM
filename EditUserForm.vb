Imports System.Data.SqlClient
Imports System.IO
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports Microsoft.VisualBasic.ApplicationServices
Imports TheArtOfDevHtmlRenderer.Adapters


Public Class EditUserForm

    Public Property user_id As String
    Public Property user_Role As String
    Public Property IsNewUser As Boolean = False
    Public Property LoggedInUserRole As String
    Public Property LoggedInUserId As String
    Public Property currentRole As String

    Private Sub EditUserForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If con IsNot Nothing AndAlso con.State = ConnectionState.Open Then con.Close()
        Opencon()

        txtUserId.Text = user_id
        If user_id = "" Then
            txtUserId.ReadOnly = False
        End If
        cboRole.Items.Clear()

        If LoggedInUserRole = "Owner" Then
            cboRole.Items.AddRange(New String() {"Manager", "Employee"})
        ElseIf LoggedInUserRole = "Manager" Then
            cboRole.Items.Add("Employee")
        End If

        If LoggedInUserRole = "Owner" AndAlso user_id = LoggedInUserId Then
            cboRole.Visible = False
            cboRole.Items.Add("Owner")
            cboRole.Text = "Owner"
            Label6.Visible = False
            deletebtn.Visible = False
        End If

        If cboRole.Visible Then
            cboRole.Text = currentRole
        End If

        If IsNewUser Then
            deletebtn.Visible = False
        End If
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If LoggedInUserRole = "Owner" Then

        End If
        If txtUserId.Text = "" Or txtFirstName.Text = "" Or txtLastName.Text = "" Or txtPhone.Text = "" Or txtAddress.Text = "" Or txtAge.Text = "" Or txtpassword.Text = "" Then

        Else
            If IsNewUser Then
                Dim arrimage() As Byte = Nothing

                If Not picProfile.Image Is My.Resources.defaulticon Then
                    Dim mstream As New MemoryStream()
                    picProfile.Image.Save(mstream, System.Drawing.Imaging.ImageFormat.Png)
                    arrimage = mstream.ToArray()
                    mstream.Close()
                Else
                    picProfile.Image = My.Resources.defaulticon
                End If

                If cboRole.Text = "" Then
                    MessageBox.Show("Role is empty")
                Else
                    Dim insertQuery As String = "INSERT INTO login (user_id,Photo, firstname, lastname, age, address, Phone_no, role, password) 
                                 VALUES (@userId, @Photo,@firstname, @lastname, @age, @address, @phone, @role, @password)"
                    Using cmd As New SqlCommand(insertQuery, con)
                        cmd.Parameters.AddWithValue("@userId", txtUserId.Text)
                        cmd.Parameters.AddWithValue("@firstname", txtFirstName.Text)
                        cmd.Parameters.AddWithValue("@lastname", txtLastName.Text)
                        cmd.Parameters.AddWithValue("@age", txtAge.Text)
                        cmd.Parameters.AddWithValue("@address", txtAddress.Text)
                        cmd.Parameters.AddWithValue("@phone", txtPhone.Text)
                        cmd.Parameters.AddWithValue("@role", cboRole.Text)
                        cmd.Parameters.AddWithValue("@password", txtpassword.Text)
                        If arrimage IsNot Nothing Then
                            cmd.Parameters.Add("@Photo", SqlDbType.VarBinary).Value = arrimage
                        Else
                            cmd.Parameters.Add("@Photo", SqlDbType.VarBinary).Value = DBNull.Value
                        End If

                        cmd.ExecuteNonQuery()
                        con.Close()
                        Me.Close()
                    End Using
                    MessageBox.Show("New user added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            Else

                If user_Role = "Owner" Then
                    cboRole.Items.Add("Owner")
                    cboRole.Text = "Owner"
                    cboRole.Visible = False
                End If
                If user_Role = "Manager" Then
                    cboRole.Text = "Manager"
                    cboRole.Visible = False
                End If
                Dim Filesize As UInt32
                Dim mstream As New System.IO.MemoryStream
                picProfile.Image.Save(mstream, System.Drawing.Imaging.ImageFormat.Png)
                Dim arrimage() As Byte = mstream.GetBuffer()
                Filesize = mstream.Length
                mstream.Close()

                Dim updateQuery As String = "UPDATE login SET Photo=@Photo,firstname=@firstname, lastname=@lastname, age=@age, address=@address, Phone_no=@phone, role=@role,password=@password WHERE user_id=@userId"
                Using cmd As New SqlCommand(updateQuery, con)
                    cmd.Parameters.AddWithValue("@userId", txtUserId.Text)
                    cmd.Parameters.AddWithValue("@firstname", txtFirstName.Text)
                    cmd.Parameters.AddWithValue("@lastname", txtLastName.Text)
                    cmd.Parameters.AddWithValue("@age", txtAge.Text)
                    cmd.Parameters.AddWithValue("@address", txtAddress.Text)
                    cmd.Parameters.AddWithValue("@phone", txtPhone.Text)
                    cmd.Parameters.AddWithValue("@role", cboRole.Text)
                    cmd.Parameters.AddWithValue("@password", txtpassword.Text)
                    If arrimage IsNot Nothing Then
                        cmd.Parameters.Add("@Photo", SqlDbType.VarBinary).Value = arrimage
                    Else
                        cmd.Parameters.Add("@Photo", SqlDbType.VarBinary).Value = DBNull.Value
                    End If

                    cmd.ExecuteNonQuery()
                    con.Close()
                    Me.Close()
                End Using
                MessageBox.Show("User updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        If con IsNot Nothing AndAlso con.State = ConnectionState.Open Then con.Close()
        Me.Close()
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


            Dim originalImage As Image = Image.FromFile(selectedFile)
            Dim resizedImage As Image = ResizeImage(originalImage, 200, 200) ' Adjust size as needed


            picProfile.Image = resizedImage
            picProfile.SizeMode = PictureBoxSizeMode.StretchImage
        End If
    End Sub

    Private Sub EditUserForm_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        If con IsNot Nothing AndAlso con.State = ConnectionState.Open Then con.Close()
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

    Private Sub deletebtn_Click(sender As Object, e As EventArgs) Handles deletebtn.Click
        If con IsNot Nothing AndAlso con.State = ConnectionState.Open Then con.Close()

        If MessageBox.Show("Are you sure you want to delete this user?", "Confirm Delete",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
            If LoggedInUserRole = "Owner" AndAlso user_id = LoggedInUserId Then
                MessageBox.Show("You can't delete your own account!", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            Try
                Opencon()
                Dim query As String = "DELETE FROM login WHERE user_id = @userId"
                Using cmd As New SqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@userId", user_id)
                    Dim rowsAffected = cmd.ExecuteNonQuery()
                    If rowsAffected > 0 Then
                        MessageBox.Show("User deleted successfully!", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("No user deleted. Something went wrong.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End Using
                Me.Close()
            Catch ex As Exception
                MessageBox.Show($"Error deleting user: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                If con IsNot Nothing AndAlso con.State = ConnectionState.Open Then con.Close()
            End Try
        End If
    End Sub


End Class