Public Class Form2
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim sure = MessageBox.Show("Open Stocks?", "Confirm", CType(vbOKCancel, MessageBoxButtons))
        If sure = MsgBoxResult.Ok Then
            Form3.Show()
            Me.Hide()
        Else
            Return
        End If
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
End Class