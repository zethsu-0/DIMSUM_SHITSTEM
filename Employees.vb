Imports System.Collections.ObjectModel
Imports System.Data.Common
Imports System.Data.SqlClient

Public Class Employees

    Private originalTable As DataTable

    Private Sub Employees_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'SHITSTEMDataSet22.login' table. You can move, or remove it, as needed.
        Me.LoginTableAdapter.Fill(Me.SHITSTEMDataSet2.login)

        Opencon()
        con.Close()
        LoginDataGridView.ReadOnly = True
        Me.LoginTableAdapter.Fill(Me.SHITSTEMDataSet2.login)
        LoginDataGridView.ClearSelection()
        LoginBindingSource.Filter = "role <> 'Owner'"
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim confirm = MessageBox.Show("are you sure you want to Exit?", "Confirm", CType(vbOKCancel, MessageBoxButtons))
        If confirm = MsgBoxResult.Ok Then
            Form2.Show()
            Me.Hide()
        Else
            Return
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        LoginDataGridView.ReadOnly = False
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        con.Open()

        If MessageBox.Show("Save Update?", "Confirm Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Me.Validate()
            LoginBindingSource.EndEdit()
            TableAdapterManager.UpdateAll(Me.SHITSTEMDataSet2)
            LoginDataGridView.ClearSelection()
            con.Close()
        Else
            Me.LoginTableAdapter.Fill(Me.SHITSTEMDataSet2.login)
            LoginDataGridView.ClearSelection()
            LoginDataGridView.ReadOnly = True
            MessageBox.Show("No updates were made")
            con.Close()
        End If

    End Sub

    Private Sub LoginBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.LoginBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.SHITSTEMDataSet2)

    End Sub

    Private Sub LoginBindingNavigatorSaveItem_Click_1(sender As Object, e As EventArgs)
        Me.Validate()
        Me.LoginBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.SHITSTEMDataSet2)

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Users.Show()
    End Sub
End Class