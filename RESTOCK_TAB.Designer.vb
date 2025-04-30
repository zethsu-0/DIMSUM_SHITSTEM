<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RESTOCK_TAB
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Guna2BorderlessForm1 = New Guna.UI2.WinForms.Guna2BorderlessForm(Me.components)
        Me.Guna2ControlBox1 = New Guna.UI2.WinForms.Guna2ControlBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.SHITSTEMDataSet = New DIMSUM_SHITSTEM.SHITSTEMDataSet()
        Me.STOCKSBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.STOCKSTableAdapter = New DIMSUM_SHITSTEM.SHITSTEMDataSetTableAdapters.STOCKSTableAdapter()
        Me.TableAdapterManager = New DIMSUM_SHITSTEM.SHITSTEMDataSetTableAdapters.TableAdapterManager()
        Me.STOCKSDataGridView = New System.Windows.Forms.DataGridView()
        Me.item_no = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.product_name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Quantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.restock = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RESTOCKBTN = New Guna.UI2.WinForms.Guna2Button()
        Me.Panel1.SuspendLayout()
        CType(Me.SHITSTEMDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.STOCKSBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.STOCKSDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Guna2BorderlessForm1
        '
        Me.Guna2BorderlessForm1.ContainerControl = Me
        Me.Guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6R
        Me.Guna2BorderlessForm1.TransparentWhileDrag = True
        '
        'Guna2ControlBox1
        '
        Me.Guna2ControlBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Guna2ControlBox1.FillColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Guna2ControlBox1.IconColor = System.Drawing.Color.White
        Me.Guna2ControlBox1.Location = New System.Drawing.Point(123, 1)
        Me.Guna2ControlBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.Guna2ControlBox1.Name = "Guna2ControlBox1"
        Me.Guna2ControlBox1.Size = New System.Drawing.Size(60, 36)
        Me.Guna2ControlBox1.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.Guna2ControlBox1)
        Me.Panel1.Location = New System.Drawing.Point(355, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(184, 43)
        Me.Panel1.TabIndex = 1
        '
        'SHITSTEMDataSet
        '
        Me.SHITSTEMDataSet.DataSetName = "SHITSTEMDataSet"
        Me.SHITSTEMDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'STOCKSBindingSource
        '
        Me.STOCKSBindingSource.DataMember = "STOCKS"
        Me.STOCKSBindingSource.DataSource = Me.SHITSTEMDataSet
        '
        'STOCKSTableAdapter
        '
        Me.STOCKSTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.DailySalesTableAdapter = Nothing
        Me.TableAdapterManager.DailySummaryTableAdapter = Nothing
        Me.TableAdapterManager.loginTableAdapter = Nothing
        Me.TableAdapterManager.MonthlySalesTableAdapter = Nothing
        Me.TableAdapterManager.OrdersTableAdapter = Nothing
        Me.TableAdapterManager.ProductGroupsTableAdapter = Nothing
        Me.TableAdapterManager.remittancehistoryTableAdapter = Nothing
        Me.TableAdapterManager.STOCKSTableAdapter = Me.STOCKSTableAdapter
        Me.TableAdapterManager.TransactionDetailsTableAdapter = Nothing
        Me.TableAdapterManager.TransactionsTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = DIMSUM_SHITSTEM.SHITSTEMDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        Me.TableAdapterManager.WeeklySalesTableAdapter = Nothing
        Me.TableAdapterManager.YearlySalesTableAdapter = Nothing
        '
        'STOCKSDataGridView
        '
        Me.STOCKSDataGridView.AllowUserToAddRows = False
        Me.STOCKSDataGridView.AllowUserToDeleteRows = False
        Me.STOCKSDataGridView.AutoGenerateColumns = False
        Me.STOCKSDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.STOCKSDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.STOCKSDataGridView.BackgroundColor = System.Drawing.Color.White
        Me.STOCKSDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.STOCKSDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("ITC Kabel", 9.749999!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.STOCKSDataGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.STOCKSDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.STOCKSDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.item_no, Me.product_name, Me.Quantity, Me.restock})
        Me.STOCKSDataGridView.DataSource = Me.STOCKSBindingSource
        Me.STOCKSDataGridView.Location = New System.Drawing.Point(0, 43)
        Me.STOCKSDataGridView.Margin = New System.Windows.Forms.Padding(4)
        Me.STOCKSDataGridView.Name = "STOCKSDataGridView"
        Me.STOCKSDataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.STOCKSDataGridView.RowHeadersVisible = False
        Me.STOCKSDataGridView.RowHeadersWidth = 51
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        Me.STOCKSDataGridView.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.STOCKSDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.STOCKSDataGridView.Size = New System.Drawing.Size(556, 364)
        Me.STOCKSDataGridView.TabIndex = 2
        '
        'item_no
        '
        Me.item_no.DataPropertyName = "item_no"
        Me.item_no.FillWeight = 20.2247!
        Me.item_no.HeaderText = "item_no"
        Me.item_no.MinimumWidth = 6
        Me.item_no.Name = "item_no"
        Me.item_no.Visible = False
        '
        'product_name
        '
        Me.product_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.product_name.DataPropertyName = "product_name"
        DataGridViewCellStyle2.Font = New System.Drawing.Font("ITC Kabel", 9.749999!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.product_name.DefaultCellStyle = DataGridViewCellStyle2
        Me.product_name.FillWeight = 66.06859!
        Me.product_name.HeaderText = "PRODUCT NAME"
        Me.product_name.MinimumWidth = 6
        Me.product_name.Name = "product_name"
        '
        'Quantity
        '
        Me.Quantity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.Quantity.DataPropertyName = "Quantity"
        DataGridViewCellStyle3.Font = New System.Drawing.Font("ITC Kabel", 9.749999!, System.Drawing.FontStyle.Bold)
        Me.Quantity.DefaultCellStyle = DataGridViewCellStyle3
        Me.Quantity.FillWeight = 28.93514!
        Me.Quantity.HeaderText = "QUANTITY"
        Me.Quantity.MinimumWidth = 6
        Me.Quantity.Name = "Quantity"
        Me.Quantity.Width = 116
        '
        'restock
        '
        Me.restock.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle4.Font = New System.Drawing.Font("ITC Kabel", 9.749999!, System.Drawing.FontStyle.Bold)
        Me.restock.DefaultCellStyle = DataGridViewCellStyle4
        Me.restock.FillWeight = 120.0!
        Me.restock.HeaderText = "ADD"
        Me.restock.MinimumWidth = 6
        Me.restock.Name = "restock"
        Me.restock.ToolTipText = "Add an ammount"
        Me.restock.Width = 72
        '
        'RESTOCKBTN
        '
        Me.RESTOCKBTN.BorderRadius = 15
        Me.RESTOCKBTN.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.RESTOCKBTN.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.RESTOCKBTN.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.RESTOCKBTN.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.RESTOCKBTN.FillColor = System.Drawing.Color.White
        Me.RESTOCKBTN.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.RESTOCKBTN.ForeColor = System.Drawing.Color.Black
        Me.RESTOCKBTN.Location = New System.Drawing.Point(355, 438)
        Me.RESTOCKBTN.Margin = New System.Windows.Forms.Padding(4)
        Me.RESTOCKBTN.Name = "RESTOCKBTN"
        Me.RESTOCKBTN.Size = New System.Drawing.Size(168, 28)
        Me.RESTOCKBTN.TabIndex = 3
        Me.RESTOCKBTN.Text = "RESTOCK"
        '
        'RESTOCK_TAB
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Yellow
        Me.ClientSize = New System.Drawing.Size(539, 500)
        Me.Controls.Add(Me.RESTOCKBTN)
        Me.Controls.Add(Me.STOCKSDataGridView)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "RESTOCK_TAB"
        Me.Text = "RESTOCK_TAB"
        Me.Panel1.ResumeLayout(False)
        CType(Me.SHITSTEMDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.STOCKSBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.STOCKSDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Guna2BorderlessForm1 As Guna.UI2.WinForms.Guna2BorderlessForm
    Friend WithEvents Guna2ControlBox1 As Guna.UI2.WinForms.Guna2ControlBox
    Friend WithEvents STOCKSBindingSource As BindingSource
    Friend WithEvents SHITSTEMDataSet As SHITSTEMDataSet
    Friend WithEvents Panel1 As Panel
    Friend WithEvents STOCKSTableAdapter As SHITSTEMDataSetTableAdapters.STOCKSTableAdapter
    Friend WithEvents TableAdapterManager As SHITSTEMDataSetTableAdapters.TableAdapterManager
    Friend WithEvents STOCKSDataGridView As DataGridView
    Friend WithEvents RESTOCKBTN As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents item_no As DataGridViewTextBoxColumn
    Friend WithEvents product_name As DataGridViewTextBoxColumn
    Friend WithEvents Quantity As DataGridViewTextBoxColumn
    Friend WithEvents restock As DataGridViewTextBoxColumn
End Class
