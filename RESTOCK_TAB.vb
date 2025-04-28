Imports System.ComponentModel
Imports System.Data.SqlClient

Public Class RESTOCK_TAB
    Public Event RestockClosed As EventHandler

    Private Sub RESTOCK_TAB_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Fill the STOCKS table
        Me.STOCKSTableAdapter.Fill(Me.SHITSTEMDataSet.STOCKS)

        ' Bind using BindingSource for easy filtering
        Dim bs As New BindingSource()
        bs.DataSource = Me.SHITSTEMDataSet.STOCKS
        bs.Filter = "Quantity <= 5"
        STOCKSDataGridView.DataSource = bs

        ' Add restock column if not already added
        If Not STOCKSDataGridView.Columns.Contains("restock") Then
            Dim restockColumn As New DataGridViewTextBoxColumn()
            restockColumn.Name = "restock"
            restockColumn.HeaderText = "Restock"
            restockColumn.ValueType = GetType(Integer)
            restockColumn.Width = 60
            STOCKSDataGridView.Columns.Add(restockColumn)
        End If
    End Sub


    Private Sub RESTOCKBTN_Click(sender As Object, e As EventArgs) Handles RESTOCKBTN.Click
        For Each row As DataGridViewRow In STOCKSDataGridView.Rows
            If Not row.IsNewRow Then
                Dim currentStock As Integer = 0
                Dim restockQty As Integer = 0

                Integer.TryParse(If(row.Cells("Quantity").Value?.ToString(), "0"), currentStock)
                Integer.TryParse(If(row.Cells("restock").Value?.ToString(), "0"), restockQty)

                If restockQty > 0 Then
                    row.Cells("Quantity").Value = currentStock + restockQty
                End If
            End If
        Next

        ' Reset restock column
        If STOCKSDataGridView.Columns.Contains("restock") Then
            For Each row As DataGridViewRow In STOCKSDataGridView.Rows
                If Not row.IsNewRow AndAlso row.Cells("restock") IsNot Nothing Then
                    row.Cells("restock").Value = 0
                End If
            Next
        End If

        Me.STOCKSTableAdapter.Update(Me.SHITSTEMDataSet.STOCKS)
        Me.STOCKSTableAdapter.Fill(Me.SHITSTEMDataSet.STOCKS)
    End Sub

    Private Sub STOCKSDataGridView_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles STOCKSDataGridView.EditingControlShowing
        Dim tb As TextBox = TryCast(e.Control, TextBox)

        If tb IsNot Nothing Then
            RemoveHandler tb.KeyPress, AddressOf RestockColumn_KeyPress
            If STOCKSDataGridView.CurrentCell.OwningColumn.Name = "restock" Then
                AddHandler tb.KeyPress, AddressOf RestockColumn_KeyPress
            End If
        End If
    End Sub

    Private Sub RestockColumn_KeyPress(sender As Object, e As KeyPressEventArgs)
        ' Allow only digits (0–9) and backspace
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
End Class
