Public Class EMPLOYEE_TAB

    Private originalTable As DataTable

    Private Sub Employees_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Opencon()
        con.Close()
        LoginDataGridView.ReadOnly = True
        Me.LoginTableAdapter.Fill(Me.SHITSTEMDataSet.login)
        LoginDataGridView.ClearSelection()
        LoginBindingSource.Filter = "role <> 'Owner'"
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        LoginDataGridView.ReadOnly = False
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        con.Open()

        If MessageBox.Show("Save Update?", "Confirm Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Me.Validate()
            LoginBindingSource.EndEdit()
            TableAdapterManager.UpdateAll(Me.SHITSTEMDataSet)
            LoginDataGridView.ClearSelection()
            con.Close()
        Else
            Me.LoginTableAdapter.Fill(Me.SHITSTEMDataSet.login)
            LoginDataGridView.ClearSelection()
            LoginDataGridView.ReadOnly = True
            MessageBox.Show("No updates were made")
            con.Close()
        End If

    End Sub

    Private Sub LoginBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.LoginBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.SHITSTEMDataSet)

    End Sub

    Private Sub LoginBindingNavigatorSaveItem_Click_1(sender As Object, e As EventArgs)
        Me.Validate()
        Me.LoginBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.SHITSTEMDataSet)

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Users.Show()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.LoginTableAdapter.Fill(Me.SHITSTEMDataSet.login)
    End Sub
End Class
