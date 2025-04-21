Imports System.Data.SqlClient
Imports System.Windows.Controls
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

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

                    role = "Owner"
                    user_id = TextBox1.Text
                    firstname = TextBox2.Text
                    lastname = TextBox3.Text
                    age = TextBox4.Text
                    address = TextBox5.Text
                    Phone_no = TextBox6.Text
                    password = TextBox7.Text
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
End Class