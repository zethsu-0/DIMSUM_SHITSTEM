Public Class Form3


    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.STOCKSTableAdapter.Fill(Me.SHITSTEMDataSet.STOCKS)
        STOCKSDataGridView.ClearSelection()
        STOCKSDataGridView.CurrentCell = Nothing

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim editForm As New ADD_PRODUCT()
        editForm.ShowDialog()

        RefreshDataGridView()
    End Sub

    Private Sub Form1_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        RefreshDataGridView()
    End Sub
    Public Sub RefreshDataGridView()
        Me.STOCKSTableAdapter.Fill(Me.SHITSTEMDataSet.STOCKS)
        STOCKSBindingSource.ResetBindings(False)
        STOCKSDataGridView.ClearSelection()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form2.Show()
        Me.Hide()
    End Sub
End Class