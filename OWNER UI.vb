Public Class Form2
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Button3.Visible = False
        Button2.Visible = False
        Button1.Visible = False
        Label1.Visible = True
        Button5.Visible = True
        Button6.Visible = True
        Button4.Visible = True
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim confirm = MessageBox.Show("are you sure you want to log out?", "Confirm", CType(vbOKCancel, MessageBoxButtons))
        If confirm = MsgBoxResult.Ok Then
            Form1.Show()
            Me.Hide()
        Else
            Return
        End If

    End Sub

    Private Sub Form2_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Form1.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim sure = MessageBox.Show("Open Stocks?", "Confirm", CType(vbOKCancel, MessageBoxButtons))
        If sure = MsgBoxResult.Ok Then
            Form3.Show()
            Me.Hide()
        Else
            Return
        End If

    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        initialize()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        initialize()
    End Sub

    Private Sub initialize()
        Button3.Visible = True
        Button6.Visible = False
        Button4.Visible = False
        Button5.Visible = False
        Button2.Visible = True
        Button1.Visible = True
        Label1.Visible = False
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

    End Sub
End Class