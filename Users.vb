Imports System.Data.SqlClient
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
        'TODO: This line of code loads data into the 'SHITSTEMDataSet.login' table. You can move, or remove it, as needed.
        Me.LoginTableAdapter.Fill(Me.SHITSTEMDataSet.login)


        Opencon()
        con.Close()


    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        lastname = TextBox2.Text

        Dim roleid As String
        If ComboBox1.Text = "Employee" Then
            roleid = "Em"
        End If
        If ComboBox1.Text = "Manager" Then
            roleid = "Mg"
        End If
        If ComboBox1.Text = "Owner" Then
            roleid = "Own"
        End If

        con.Open()
        Dim cmd As New SqlCommand("SELECT COUNT(*) FROM Employees", con)
        Dim empcount As Integer = CInt(cmd.ExecuteScalar())
        con.Close()

        user_id = roleid & "_" & lastname & "_" & "2025" & empcount + 1
        TextBox7.Text = user_id
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        firstname = TextBox1.Text
        age = TextBox3.Text
        address = TextBox4.Text
        Phone_no = Convert.ToString(TextBox5.Text)
        password = TextBox6.Text
        role = ComboBox1.Text



        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Then
                MessageBox.Show("Please Fill all the SHITS")
            Else


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


                    con.Open()
                    insertCmd.ExecuteNonQuery()
                    con.Close()
                End Using

                TextBox1.Text = ""
                TextBox2.Text = ""
                TextBox3.Text = ""
                TextBox4.Text = ""
                TextBox6.Text = ""
                TextBox7.Text = ""
                ComboBox1.Text = ""


                Me.LoginTableAdapter.Fill(Me.SHITSTEMDataSet.login)
            End If
        ' Catch ex As Exception
        MessageBox.Show(firstname & lastname & age & address & Phone_no & password & role & user_id)
        ' End Try
    End Sub

    Private Sub LoginBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.LoginBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.SHITSTEMDataSet)

    End Sub

    Private Sub LoginBindingNavigatorSaveItem_Click_1(sender As Object, e As EventArgs)
        Me.Validate()
        Me.LoginBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.SHITSTEMDataSet)

    End Sub
End Class