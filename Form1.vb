Imports System.Data.SqlClient

Public Class Form1

    Dim roleSelect As String = ""
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Opencon()
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
                        MsgBox("eeeeeee")
                    Case "Manager"
                        MsgBox("mmmmmmm")
                    Case "Owner"
                        MsgBox("ooooooo")
                        Dim user_id As String = TextBox1.Text

                        If Not String.IsNullOrEmpty(user_id) Then ' Ensure user_id is entered
                            Dim form2 As New Form2()
                            form2.user_id = user_id ' Pass user_id to Form2
                            form2.Show()
                            Me.Hide()
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
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Showloginfields()
        Button2.Visible = False
        Button3.Visible = False
        Button4.Visible = False
        Button5.Visible = True
        Label2.Visible = True
        roleSelect = "Manager"
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Showloginfields()
        Button2.Visible = False
        Button3.Visible = False
        Button4.Visible = False
        Button5.Visible = True
        Label3.Visible = True
        roleSelect = "Owner"
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        TextBox1.Visible = False
        TextBox2.Visible = False
        Button1.Visible = False
        Button5.Visible = False
        showRolefields()
    End Sub
    Public Sub Showloginfields()
        TextBox1.Visible = True
        TextBox2.Visible = True
        Button1.Visible = True
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
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs)
        Form3.Show()
        Me.Hide()
    End Sub

    Private Sub Button6_Click_1(sender As Object, e As EventArgs) Handles Button6.Click
        Users.Show()
        Me.Hide()
    End Sub
End Class
