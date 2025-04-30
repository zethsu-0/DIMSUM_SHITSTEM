Imports System.ComponentModel
Imports System.Data.SqlClient

Public Class RESTOCK_TAB
    Public Event RestockClosed As EventHandler

    Private Sub RESTOCK_TAB_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Load low-stock items
        Me.STOCKSTableAdapter.Fill(Me.SHITSTEMDataSet.STOCKS)

        Dim bs As New BindingSource()
        bs.DataSource = Me.SHITSTEMDataSet.STOCKS
        bs.Filter = "Quantity <= 5"
        STOCKSDataGridView.DataSource = bs

        ' Add Restock column
        If Not STOCKSDataGridView.Columns.Contains("restock") Then
            Dim restockColumn As New DataGridViewTextBoxColumn()
            restockColumn.Name = "restock"
            restockColumn.HeaderText = "Restock"
            restockColumn.ValueType = GetType(Integer)
            restockColumn.Width = 60
            restockColumn.DefaultCellStyle.NullValue = 0
            STOCKSDataGridView.Columns.Add(restockColumn)
        End If

        ' Add Expiration Date Picker column
        If Not STOCKSDataGridView.Columns.Contains("new_expdate") Then
            Dim expColumn As New CalendarColumn()
            expColumn.Name = "new_expdate"
            expColumn.HeaderText = "New Expiration"
            expColumn.Width = 130
            STOCKSDataGridView.Columns.Add(expColumn)
        End If
    End Sub

    Private Sub RESTOCKBTN_Click(sender As Object, e As EventArgs) Handles RESTOCKBTN.Click
        Dim anyRestocked As Boolean = False

        If Not STOCKSDataGridView.Columns.Contains("new_expdate") Then
            MessageBox.Show("Column 'new_expdate' was not added.")
            Exit Sub
        End If

        ' Check if every row with restock value also has a valid exp date
        For Each row As DataGridViewRow In STOCKSDataGridView.Rows
            If Not row.IsNewRow Then
                Dim restockQty As Integer = 0
                Integer.TryParse(If(row.Cells("restock").Value?.ToString(), "0"), restockQty)

                Dim expVal = row.Cells("new_expdate").Value

                If restockQty > 0 AndAlso (expVal Is Nothing OrElse Not IsDate(expVal) OrElse CDate(expVal) <= Date.Today) Then
                    MessageBox.Show("Please enter a valid *future* expiration date for all restocked items.", "Missing or Invalid Expiration", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If

                If restockQty <= 0 AndAlso expVal IsNot Nothing AndAlso IsDate(expVal) Then
                    MessageBox.Show("You have selected an expiration date without entering a restock amount.", "Missing Restock Quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
            End If
        Next

        ' Main processing
        For Each row As DataGridViewRow In STOCKSDataGridView.Rows
            If Not row.IsNewRow Then
                Dim currentStock As Integer = 0
                Dim restockQty As Integer = 0

                Integer.TryParse(If(row.Cells("Quantity").Value?.ToString(), "0"), currentStock)
                Integer.TryParse(If(row.Cells("restock").Value?.ToString(), "0"), restockQty)

                If restockQty > 0 Then
                    anyRestocked = True

                    Dim selectedExpDate = row.Cells("new_expdate").Value
                    Dim expDate As Date = CDate(selectedExpDate)

                    ' Update dataset
                    Dim drv As DataRowView = TryCast(row.DataBoundItem, DataRowView)
                    If drv IsNot Nothing Then
                        drv("Quantity") = currentStock + restockQty
                        drv("expdate") = expDate
                    End If
                End If
            End If
        Next

        If Not anyRestocked Then
            MessageBox.Show("No restock amounts entered.", "Nothing Updated", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        ' Clear restock fields
        For Each row As DataGridViewRow In STOCKSDataGridView.Rows
            If Not row.IsNewRow Then
                row.Cells("restock").Value = 0
            End If
        Next

        ' Save changes
        Me.Validate()
        Me.STOCKSBindingSource.EndEdit()
        Me.STOCKSTableAdapter.Update(Me.SHITSTEMDataSet.STOCKS)
        Me.SHITSTEMDataSet.STOCKS.AcceptChanges()

        MessageBox.Show("Restock successful.", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information)

        ' Refresh grid
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
        ' Allow only digits and backspace
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    ' Calendar column and editor classes

    Public Class CalendarColumn
        Inherits DataGridViewColumn
        Public Sub New()
            MyBase.New(New CalendarCell())
        End Sub

        Public Overrides Property CellTemplate As DataGridViewCell
            Get
                Return MyBase.CellTemplate
            End Get
            Set(value As DataGridViewCell)
                If Not TypeOf value Is CalendarCell Then
                    Throw New InvalidCastException("Must be a CalendarCell")
                End If
                MyBase.CellTemplate = value
            End Set
        End Property
    End Class

    Public Class CalendarCell
        Inherits DataGridViewTextBoxCell
        Public Sub New()
            Me.Style.Format = "d"
        End Sub

        Public Overrides Sub InitializeEditingControl(rowIndex As Integer, initialFormattedValue As Object, dataGridViewCellStyle As DataGridViewCellStyle)
            MyBase.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle)
            Dim ctl As CalendarEditingControl = CType(DataGridView.EditingControl, CalendarEditingControl)
            ctl.Value = If(Me.Value IsNot Nothing AndAlso IsDate(Me.Value), CDate(Me.Value), Date.Today)
        End Sub

        Public Overrides ReadOnly Property EditType As Type
            Get
                Return GetType(CalendarEditingControl)
            End Get
        End Property

        Public Overrides ReadOnly Property ValueType As Type
            Get
                Return GetType(Date)
            End Get
        End Property

        Public Overrides ReadOnly Property DefaultNewRowValue As Object
            Get
                Return Date.Today
            End Get
        End Property
    End Class

    Public Class CalendarEditingControl
        Inherits DateTimePicker
        Implements IDataGridViewEditingControl

        Private dataGridViewControl As DataGridView
        Private valueIsChanged As Boolean = False
        Private rowIndexNum As Integer

        Public Sub ApplyCellStyleToEditingControl(cellStyle As DataGridViewCellStyle) Implements IDataGridViewEditingControl.ApplyCellStyleToEditingControl
            Me.Font = cellStyle.Font
            Me.CalendarForeColor = cellStyle.ForeColor
            Me.CalendarMonthBackground = cellStyle.BackColor
        End Sub

        Public Property EditingControlFormattedValue As Object Implements IDataGridViewEditingControl.EditingControlFormattedValue
            Get
                Return Me.Value.ToShortDateString()
            End Get
            Set(value As Object)
                If TypeOf value Is String Then
                    Me.Value = DateTime.Parse(value)
                End If
            End Set
        End Property

        Public Function GetEditingControlFormattedValue(context As DataGridViewDataErrorContexts) As Object Implements IDataGridViewEditingControl.GetEditingControlFormattedValue
            Return Me.Value.ToShortDateString()
        End Function

        Public Sub PrepareEditingControlForEdit(selectAll As Boolean) Implements IDataGridViewEditingControl.PrepareEditingControlForEdit
            Me.MinDate = Date.Today ' ✅ Prevent past dates
        End Sub


        Public ReadOnly Property RepositionEditingControlOnValueChange As Boolean Implements IDataGridViewEditingControl.RepositionEditingControlOnValueChange
            Get
                Return False
            End Get
        End Property

        Public Property EditingControlDataGridView As DataGridView Implements IDataGridViewEditingControl.EditingControlDataGridView
            Get
                Return dataGridViewControl
            End Get
            Set(value As DataGridView)
                dataGridViewControl = value
            End Set
        End Property

        Public Property EditingControlRowIndex As Integer Implements IDataGridViewEditingControl.EditingControlRowIndex
            Get
                Return rowIndexNum
            End Get
            Set(value As Integer)
                rowIndexNum = value
            End Set
        End Property

        Public Property EditingControlValueChanged As Boolean Implements IDataGridViewEditingControl.EditingControlValueChanged
            Get
                Return valueIsChanged
            End Get
            Set(value As Boolean)
                valueIsChanged = value
            End Set
        End Property

        Public ReadOnly Property EditingPanelCursor As Cursor Implements IDataGridViewEditingControl.EditingPanelCursor
            Get
                Return MyBase.Cursor
            End Get
        End Property

        Public Function EditingControlWantsInputKey(keyData As Keys, dataGridViewWantsInputKey As Boolean) As Boolean Implements IDataGridViewEditingControl.EditingControlWantsInputKey
            Select Case keyData And Keys.KeyCode
                Case Keys.Left, Keys.Up, Keys.Down, Keys.Right, Keys.Home, Keys.End, Keys.PageDown, Keys.PageUp
                    Return True
                Case Else
                    Return Not dataGridViewWantsInputKey
            End Select
        End Function

        Protected Overrides Sub OnValueChanged(eventargs As EventArgs)
            valueIsChanged = True
            Me.EditingControlDataGridView.NotifyCurrentCellDirty(True)
            MyBase.OnValueChanged(eventargs)
        End Sub
    End Class
End Class
