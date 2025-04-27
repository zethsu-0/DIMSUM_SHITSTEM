Imports System.Data.SqlClient
Imports System.IO
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports Microsoft.VisualBasic.ApplicationServices
Imports TheArtOfDevHtmlRenderer.Adapters

Public Class Users

    Private Sub Users_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub
    Private Sub reset()
        txtUserId.Text = ""
        txtFirstName.Text = ""
        txtLastName.Text = ""
        TxtAge.Text = ""
        txtAddress.Text = ""
        txtPhone.Text = ""
        txtpassword.Text = ""
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs)

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

    Private Sub txtPhone_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPhone.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True ' Block non-digit input
        End If
    End Sub

    Private Sub txtAge_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtAge.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True ' Block non-digit input
        End If
    End Sub

    Private Sub txtFirstName_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFirstName.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso
       Not Char.IsLetter(e.KeyChar) AndAlso
       e.KeyChar <> "."c AndAlso
       e.KeyChar <> "-"c Then
            e.Handled = True ' Block anything except letter, dot, hyphen
        End If

        ' Prevent dot or hyphen as first character
        If (e.KeyChar = "."c OrElse e.KeyChar = "-"c) AndAlso txtFirstName.SelectionStart = 0 Then
            e.Handled = True
        End If
    End Sub



    Private Sub txtLastName_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtLastName.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso
           Not Char.IsLetter(e.KeyChar) AndAlso
           e.KeyChar <> "."c AndAlso
           e.KeyChar <> "-"c Then
            e.Handled = True
        End If

        If (e.KeyChar = "."c OrElse e.KeyChar = "-"c) AndAlso txtLastName.SelectionStart = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtAge_Leave(sender As Object, e As EventArgs) Handles TxtAge.Leave
        Dim age As Integer
        If Integer.TryParse(TxtAge.Text, age) Then
            If age < 16 Then
                MessageBox.Show("Age must be 16 or older.", "Invalid Age", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TxtAge.Clear()
                TxtAge.Focus()
            End If
        ElseIf TxtAge.Text <> "" Then
            MessageBox.Show("Please enter a valid numeric age.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TxtAge.Clear()
            TxtAge.Focus()
        End If
    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        Dim user_id As String = txtUserId.Text
        Dim firstname As String = txtFirstName.Text
        Dim lastname As String = txtLastName.Text
        Dim age As String = TxtAge.Text
        Dim address As String = txtAddress.Text
        Dim Phone_no As String = txtPhone.Text
        Dim password As String = txtpassword.Text
        Dim role As String = "Owner"

        Opencon()
        Dim sure As DialogResult = MessageBox.Show(Me, "Are you sure everything is Correct?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If sure = DialogResult.Yes Then
            Try
                If txtUserId.Text = "" Or txtFirstName.Text = "" Or txtLastName.Text = "" Or TxtAge.Text = "" Or txtAddress.Text = "" Or txtPhone.Text = "" Or txtpassword.Text = "" Then
                    MessageBox.Show("Please Fill all the SHITS")
                Else

                    Dim arrimage() As Byte = Nothing

                    If picProfile.Image IsNot Nothing AndAlso picProfile.Image IsNot My.Resources.defaulticon Then
                        Dim mstream As New MemoryStream()
                        picProfile.Image.Save(mstream, System.Drawing.Imaging.ImageFormat.Png)
                        arrimage = mstream.ToArray()
                        mstream.Close()
                    Else
                        picProfile.Image = My.Resources.defaulticon
                    End If


                    Dim insertQuery As String = "INSERT INTO login (user_id,Photo, firstname, lastname, age, address, Phone_no, role, password) 
                             VALUES (@userId, @Photo,@firstname, @lastname, @age, @address, @phone, @role, @password)"
                    Using cmd As New SqlCommand(insertQuery, con)
                        cmd.Parameters.AddWithValue("@userId", txtUserId.Text)
                        cmd.Parameters.AddWithValue("@firstname", txtFirstName.Text)
                        cmd.Parameters.AddWithValue("@lastname", txtLastName.Text)
                        cmd.Parameters.AddWithValue("@age", TxtAge.Text)
                        cmd.Parameters.AddWithValue("@address", txtAddress.Text)
                        cmd.Parameters.AddWithValue("@phone", txtPhone.Text)
                        cmd.Parameters.AddWithValue("@role", role)
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
                    MsgBox("Your username: " & user_id & vbCrLf & "Your Password: " & password)
                    reset()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                If con.State = ConnectionState.Open Then con.Close()
            End Try
        Else
            If con.State = ConnectionState.Open Then con.Close()
        End If
    End Sub

    Private Sub Guna2Button3_Click(sender As Object, e As EventArgs) Handles Guna2Button3.Click
        reset()
        Me.Close()
    End Sub
End Class