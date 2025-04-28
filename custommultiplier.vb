Public Class custommultiplier
    Public Property CustomQuantity As Integer = 1
    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        If Integer.TryParse(txtQuantity.Text, CustomQuantity) Then
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Else
            MessageBox.Show("Please enter a valid number.")
        End If
    End Sub
    Private Sub txtQuantity_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            ConfirmQuantity()
        End If
    End Sub
    Private Sub ConfirmQuantity()
        If Integer.TryParse(txtQuantity.Text, CustomQuantity) AndAlso CustomQuantity > 0 Then
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Else
            txtQuantity.SelectAll()
            txtQuantity.Focus()
        End If
    End Sub

    Private Sub custommultiplier_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtQuantity.Focus()
    End Sub
    Private Sub txtQuantity_Enter(sender As Object, e As EventArgs)
        txtQuantity.SelectAll()
    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub txtQuantity_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
End Class