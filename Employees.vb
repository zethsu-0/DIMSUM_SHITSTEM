Public Class Employees
    Private Sub Employees_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'SHITSTEMDataSet.Employees' table. You can move, or remove it, as needed.
        Me.EmployeesTableAdapter.Fill(Me.SHITSTEMDataSet.Employees)

    End Sub

End Class