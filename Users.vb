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



    End Sub


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        lastname = TextBox2.Text
        firstname = TextBox1.Text





    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        firstname = TextBox1.Text
        age = TextBox3.Text
        address = TextBox4.Text
        Phone_no = TextBox5.Text.Trim()
        password = TextBox6.Text
        role = ComboBox1.Text



    End Sub

    Private Sub LoginBInt32indingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.LoginBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.SHITSTEMDataSet)

    End Sub

    Private Sub LoginBindingNavigatorSaveItem_Click_1(sender As Object, e As EventArgs)
        Me.Validate()
        Me.LoginBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.SHITSTEMDataSet)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        ComboBox1.Text = ""
        Me.Hide()
    End Sub
End Class