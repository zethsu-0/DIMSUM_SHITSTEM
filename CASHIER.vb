Public Class CASHIER
    Private Sub OrdersBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.OrdersBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.SHITSTEMDataSet)

    End Sub

    Private Sub CASHIER_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'SHITSTEMDataSet.Orders' table. You can move, or remove it, as needed.
        Me.OrdersTableAdapter.Fill(Me.SHITSTEMDataSet.Orders)

    End Sub
End Class