Public Class loadingscreen
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        progressbar.Value += 2
        If progressbar.Value >= 100 Then
            Timer1.Stop()
            Me.Hide()
        End If
    End Sub

    Private Sub loadingscreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Start()
    End Sub

    Private Sub Guna2PictureBox1_Click(sender As Object, e As EventArgs) Handles Guna2PictureBox1.Click
        progressbar.Value += 1
    End Sub
End Class
