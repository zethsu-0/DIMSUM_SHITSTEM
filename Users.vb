Imports System.Data.SqlClient
Imports System.IO
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports Microsoft.VisualBasic.ApplicationServices
Imports TheArtOfDevHtmlRenderer.Adapters

Public Class Users

    Dim firstname As String
    Dim lastname As String
    Dim age As String
    Dim address As String
    Dim Phone_no As String
    Dim password As String
    Dim role As String
    Dim user_id As String
    Private Sub Users_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Opencon()
        Dim sure As DialogResult = MessageBox.Show(Me, "Are you sure everything is Correct?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If sure = DialogResult.Yes Then
            MsgBox("weeeeeehhh")
            Try
                If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or TextBox6.Text = "" Then
                    MessageBox.Show("Please Fill all the SHITS")
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


                        ' INSERT logic

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
    Private Sub reset()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        reset()
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
End Class