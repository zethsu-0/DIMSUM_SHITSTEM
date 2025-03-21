Imports System.Data.SqlClient

Public Class Form1

    Dim roleSelect As String = ""
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Opencon()
        con.Close()

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        con.Open()
        cmd = New SqlCommand("login1", con)
        With cmd
            .CommandType = CommandType.StoredProcedure
            .Parameters.AddWithValue("@user", TextBox1.Text)
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
                    Case "employee"
                        MsgBox("eeeeeee")
                    Case "manager"
                        MsgBox("mmmmmmm")
                    Case "owner"
                        MsgBox("ooooooo")
                        Form2.Show()
                        Me.Hide()
                    Case Else
                        MsgBox("Role not recognized")
                End Select
            Else
                MsgBox("You are not assigned to this role!")
            End If
        Else
            MsgBox("Logn Failed", vbCritical)
        End If


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Showloginfields()
        Button2.Visible = False
        Button3.Visible = False
        Button4.Visible = False
        Button5.Visible = True

        roleSelect = "employee"
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Showloginfields()
        Button2.Visible = False
        Button3.Visible = False
        Button4.Visible = False
        Button5.Visible = True

        roleSelect = "manager"
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Showloginfields()
        Button2.Visible = False
        Button3.Visible = False
        Button4.Visible = False
        Button5.Visible = True

        roleSelect = "owner"
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
        Button2.Visible = True
        Button3.Visible = True
        Button4.Visible = True
        TextBox1.Text = ""
        TextBox2.Text = ""
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs)
        Form3.Show()
        Me.Hide()
    End Sub
End Class
