<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SALES_TAB
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Title2 As System.Windows.Forms.DataVisualization.Charting.Title = New System.Windows.Forms.DataVisualization.Charting.Title()
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Title1 As System.Windows.Forms.DataVisualization.Charting.Title = New System.Windows.Forms.DataVisualization.Charting.Title()
        Me.DailySalesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SHITSTEMDataSet = New DIMSUM_SHITSTEM.SHITSTEMDataSet()
        Me.STOCKSBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DailySummaryBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DailySalesTableAdapter = New DIMSUM_SHITSTEM.SHITSTEMDataSetTableAdapters.DailySalesTableAdapter()
        Me.TableAdapterManager = New DIMSUM_SHITSTEM.SHITSTEMDataSetTableAdapters.TableAdapterManager()
        Me.MonthlySalesTableAdapter = New DIMSUM_SHITSTEM.SHITSTEMDataSetTableAdapters.MonthlySalesTableAdapter()
        Me.WeeklySalesTableAdapter = New DIMSUM_SHITSTEM.SHITSTEMDataSetTableAdapters.WeeklySalesTableAdapter()
        Me.MonthlySalesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.WeeklySalesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.STOCKSTableAdapter = New DIMSUM_SHITSTEM.SHITSTEMDataSetTableAdapters.STOCKSTableAdapter()
        Me.WeeklySalesTableAdapter1 = New DIMSUM_SHITSTEM.SHITSTEMDataSetTableAdapters.WeeklySalesTableAdapter()
        Me.DailySummaryTableAdapter = New DIMSUM_SHITSTEM.SHITSTEMDataSetTableAdapters.DailySummaryTableAdapter()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.STOCKSDataGridView = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Guna2CircleButton1 = New Guna.UI2.WinForms.Guna2CircleButton()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.RESTOCKBTN = New Guna.UI2.WinForms.Guna2Button()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.DailySummaryDataGridView = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.totalsalestodaypanel = New System.Windows.Forms.Panel()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.salesTotallbl = New System.Windows.Forms.Label()
        Me.todayprofitpanel = New System.Windows.Forms.Panel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.profitlbl = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Chart2 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Guna2HtmlLabel1 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.TransactionsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TransactionsTableAdapter = New DIMSUM_SHITSTEM.SHITSTEMDataSetTableAdapters.TransactionsTableAdapter()
        Me.TransactionsDataGridView = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn19 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn20 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn21 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn22 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn23 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn24 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn25 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DailySalesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SHITSTEMDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.STOCKSBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DailySummaryBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MonthlySalesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WeeklySalesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.STOCKSDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlowLayoutPanel1.SuspendLayout()
        CType(Me.DailySummaryDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.totalsalestodaypanel.SuspendLayout()
        Me.todayprofitpanel.SuspendLayout()
        Me.FlowLayoutPanel2.SuspendLayout()
        CType(Me.Chart2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.TransactionsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TransactionsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DailySalesBindingSource
        '
        Me.DailySalesBindingSource.DataMember = "DailySales"
        Me.DailySalesBindingSource.DataSource = Me.SHITSTEMDataSet
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
        'DailySummaryBindingSource
        '
        Me.DailySummaryBindingSource.DataMember = "DailySummary"
        Me.DailySummaryBindingSource.DataSource = Me.SHITSTEMDataSet
        '
        'DailySalesTableAdapter
        '
        Me.DailySalesTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.DailySalesTableAdapter = Me.DailySalesTableAdapter
        Me.TableAdapterManager.DailySummaryTableAdapter = Nothing
        Me.TableAdapterManager.loginTableAdapter = Nothing
        Me.TableAdapterManager.MonthlySalesTableAdapter = Me.MonthlySalesTableAdapter
        Me.TableAdapterManager.OrdersTableAdapter = Nothing
        Me.TableAdapterManager.ProductGroupsTableAdapter = Nothing
        Me.TableAdapterManager.STOCKSTableAdapter = Nothing
        Me.TableAdapterManager.TransactionDetailsTableAdapter = Nothing
        Me.TableAdapterManager.TransactionsTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = DIMSUM_SHITSTEM.SHITSTEMDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        Me.TableAdapterManager.WeeklySalesTableAdapter = Me.WeeklySalesTableAdapter
        '
        'MonthlySalesTableAdapter
        '
        Me.MonthlySalesTableAdapter.ClearBeforeFill = True
        '
        'WeeklySalesTableAdapter
        '
        Me.WeeklySalesTableAdapter.ClearBeforeFill = True
        '
        'MonthlySalesBindingSource
        '
        Me.MonthlySalesBindingSource.DataMember = "MonthlySales"
        Me.MonthlySalesBindingSource.DataSource = Me.SHITSTEMDataSet
        '
        'WeeklySalesBindingSource
        '
        Me.WeeklySalesBindingSource.DataMember = "WeeklySales"
        Me.WeeklySalesBindingSource.DataSource = Me.SHITSTEMDataSet
        '
        'STOCKSTableAdapter
        '
        Me.STOCKSTableAdapter.ClearBeforeFill = True
        '
        'WeeklySalesTableAdapter1
        '
        Me.WeeklySalesTableAdapter1.ClearBeforeFill = True
        '
        'DailySummaryTableAdapter
        '
        Me.DailySummaryTableAdapter.ClearBeforeFill = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToResizeColumns = False
        Me.DataGridView1.AllowUserToResizeRows = False
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.DataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8, Me.DataGridViewTextBoxColumn9, Me.DataGridViewTextBoxColumn10})
        Me.DataGridView1.DataSource = Me.STOCKSBindingSource
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView1.Location = New System.Drawing.Point(1038, 106)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridView1.RowHeadersVisible = False
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DataGridView1.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridView1.RowTemplate.Height = 30
        Me.DataGridView1.Size = New System.Drawing.Size(282, 137)
        Me.DataGridView1.TabIndex = 2
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "Quantity"
        Me.DataGridViewTextBoxColumn10.HeaderText = "QUANTITY"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "product_group"
        Me.DataGridViewTextBoxColumn9.HeaderText = "GROUP"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "product_name"
        Me.DataGridViewTextBoxColumn8.HeaderText = "PRODUCT NAME"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "item_no"
        Me.DataGridViewTextBoxColumn7.HeaderText = "ITEM_NO"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(1035, 90)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(101, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "NO STOCKS LEFT:"
        '
        'STOCKSDataGridView
        '
        Me.STOCKSDataGridView.AllowUserToAddRows = False
        Me.STOCKSDataGridView.AllowUserToDeleteRows = False
        Me.STOCKSDataGridView.AllowUserToResizeColumns = False
        Me.STOCKSDataGridView.AllowUserToResizeRows = False
        Me.STOCKSDataGridView.AutoGenerateColumns = False
        Me.STOCKSDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.STOCKSDataGridView.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.STOCKSDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.STOCKSDataGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.STOCKSDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.STOCKSDataGridView.ColumnHeadersVisible = False
        Me.STOCKSDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4})
        Me.STOCKSDataGridView.DataSource = Me.STOCKSBindingSource
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.STOCKSDataGridView.DefaultCellStyle = DataGridViewCellStyle6
        Me.STOCKSDataGridView.Location = New System.Drawing.Point(1038, 280)
        Me.STOCKSDataGridView.Name = "STOCKSDataGridView"
        Me.STOCKSDataGridView.ReadOnly = True
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.STOCKSDataGridView.RowHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.STOCKSDataGridView.RowHeadersVisible = False
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.STOCKSDataGridView.RowsDefaultCellStyle = DataGridViewCellStyle8
        Me.STOCKSDataGridView.RowTemplate.Height = 30
        Me.STOCKSDataGridView.Size = New System.Drawing.Size(282, 148)
        Me.STOCKSDataGridView.TabIndex = 1
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "Quantity"
        Me.DataGridViewTextBoxColumn4.HeaderText = "Quantity"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "product_group"
        Me.DataGridViewTextBoxColumn3.HeaderText = "product_group"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "product_name"
        Me.DataGridViewTextBoxColumn2.HeaderText = "product_name"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "item_no"
        Me.DataGridViewTextBoxColumn1.HeaderText = "item_no"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'Guna2CircleButton1
        '
        Me.Guna2CircleButton1.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.Guna2CircleButton1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.Guna2CircleButton1.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.Guna2CircleButton1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.Guna2CircleButton1.FillColor = System.Drawing.Color.White
        Me.Guna2CircleButton1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Guna2CircleButton1.ForeColor = System.Drawing.Color.White
        Me.Guna2CircleButton1.Image = Global.DIMSUM_SHITSTEM.My.Resources.Resources.refresh
        Me.Guna2CircleButton1.Location = New System.Drawing.Point(960, 15)
        Me.Guna2CircleButton1.Name = "Guna2CircleButton1"
        Me.Guna2CircleButton1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle
        Me.Guna2CircleButton1.Size = New System.Drawing.Size(36, 36)
        Me.Guna2CircleButton1.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(1039, 258)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(97, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "LOW ON STOCKS"
        '
        'RESTOCKBTN
        '
        Me.RESTOCKBTN.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.RESTOCKBTN.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.RESTOCKBTN.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.RESTOCKBTN.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.RESTOCKBTN.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.RESTOCKBTN.ForeColor = System.Drawing.Color.White
        Me.RESTOCKBTN.Location = New System.Drawing.Point(1042, 434)
        Me.RESTOCKBTN.Name = "RESTOCKBTN"
        Me.RESTOCKBTN.Size = New System.Drawing.Size(115, 25)
        Me.RESTOCKBTN.TabIndex = 10
        Me.RESTOCKBTN.Text = "RESTOCK"
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.FlowLayoutPanel1.Controls.Add(Me.todayprofitpanel)
        Me.FlowLayoutPanel1.Controls.Add(Me.totalsalestodaypanel)
        Me.FlowLayoutPanel1.Controls.Add(Me.DailySummaryDataGridView)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(31, 84)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(971, 172)
        Me.FlowLayoutPanel1.TabIndex = 0
        '
        'DailySummaryDataGridView
        '
        Me.DailySummaryDataGridView.AllowUserToAddRows = False
        Me.DailySummaryDataGridView.AllowUserToDeleteRows = False
        Me.DailySummaryDataGridView.AutoGenerateColumns = False
        Me.DailySummaryDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DailySummaryDataGridView.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.DailySummaryDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DailySummaryDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn11, Me.DataGridViewTextBoxColumn12, Me.DataGridViewTextBoxColumn13})
        Me.DailySummaryDataGridView.DataSource = Me.DailySummaryBindingSource
        Me.DailySummaryDataGridView.Location = New System.Drawing.Point(550, 3)
        Me.DailySummaryDataGridView.Margin = New System.Windows.Forms.Padding(20, 3, 20, 3)
        Me.DailySummaryDataGridView.Name = "DailySummaryDataGridView"
        Me.DailySummaryDataGridView.ReadOnly = True
        Me.DailySummaryDataGridView.RowHeadersVisible = False
        Me.DailySummaryDataGridView.Size = New System.Drawing.Size(391, 156)
        Me.DailySummaryDataGridView.TabIndex = 10
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.DataPropertyName = "Revenue"
        Me.DataGridViewTextBoxColumn13.HeaderText = "Revenue"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.ReadOnly = True
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.DataPropertyName = "OrderDate"
        Me.DataGridViewTextBoxColumn12.HeaderText = "OrderDate"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.ReadOnly = True
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "Quantity"
        Me.DataGridViewTextBoxColumn11.HeaderText = "Quantity"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.ReadOnly = True
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "Product_Name"
        Me.DataGridViewTextBoxColumn6.HeaderText = "Product_Name"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "OrderID"
        Me.DataGridViewTextBoxColumn5.HeaderText = "OrderID"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        '
        'totalsalestodaypanel
        '
        Me.totalsalestodaypanel.Controls.Add(Me.salesTotallbl)
        Me.totalsalestodaypanel.Controls.Add(Me.Label3)
        Me.totalsalestodaypanel.Controls.Add(Me.Label10)
        Me.totalsalestodaypanel.Location = New System.Drawing.Point(285, 3)
        Me.totalsalestodaypanel.Margin = New System.Windows.Forms.Padding(20, 3, 20, 3)
        Me.totalsalestodaypanel.Name = "totalsalestodaypanel"
        Me.totalsalestodaypanel.Size = New System.Drawing.Size(225, 156)
        Me.totalsalestodaypanel.TabIndex = 8
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Palatino Linotype", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(31, 111)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(172, 22)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = "TOTAL SALES TODAY"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Palatino Linotype", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(96, 11)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 44)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "₱"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'salesTotallbl
        '
        Me.salesTotallbl.AutoSize = True
        Me.salesTotallbl.BackColor = System.Drawing.Color.Transparent
        Me.salesTotallbl.Font = New System.Drawing.Font("Poppins", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.salesTotallbl.Location = New System.Drawing.Point(74, 55)
        Me.salesTotallbl.Name = "salesTotallbl"
        Me.salesTotallbl.Size = New System.Drawing.Size(87, 56)
        Me.salesTotallbl.TabIndex = 11
        Me.salesTotallbl.Text = "000"
        Me.salesTotallbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'todayprofitpanel
        '
        Me.todayprofitpanel.Controls.Add(Me.profitlbl)
        Me.todayprofitpanel.Controls.Add(Me.Label1)
        Me.todayprofitpanel.Controls.Add(Me.Label9)
        Me.todayprofitpanel.Location = New System.Drawing.Point(20, 3)
        Me.todayprofitpanel.Margin = New System.Windows.Forms.Padding(20, 3, 20, 3)
        Me.todayprofitpanel.Name = "todayprofitpanel"
        Me.todayprofitpanel.Size = New System.Drawing.Size(225, 156)
        Me.todayprofitpanel.TabIndex = 6
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Palatino Linotype", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(43, 111)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(124, 22)
        Me.Label9.TabIndex = 6
        Me.Label9.Text = "PROFIT TODAY"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Palatino Linotype", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(84, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 44)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "₱"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'profitlbl
        '
        Me.profitlbl.AutoSize = True
        Me.profitlbl.BackColor = System.Drawing.Color.Transparent
        Me.profitlbl.Font = New System.Drawing.Font("Poppins", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.profitlbl.Location = New System.Drawing.Point(62, 58)
        Me.profitlbl.Name = "profitlbl"
        Me.profitlbl.Size = New System.Drawing.Size(87, 56)
        Me.profitlbl.TabIndex = 8
        Me.profitlbl.Text = "000"
        Me.profitlbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.Controls.Add(Me.Chart1)
        Me.FlowLayoutPanel2.Controls.Add(Me.Chart2)
        Me.FlowLayoutPanel2.Controls.Add(Me.TransactionsDataGridView)
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(123, 280)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(773, 1007)
        Me.FlowLayoutPanel2.TabIndex = 11
        '
        'Chart2
        '
        ChartArea2.Name = "ChartArea1"
        Me.Chart2.ChartAreas.Add(ChartArea2)
        Me.Chart2.Location = New System.Drawing.Point(3, 261)
        Me.Chart2.Name = "Chart2"
        Me.Chart2.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SemiTransparent
        Series2.ChartArea = "ChartArea1"
        Series2.Name = "Series1"
        Me.Chart2.Series.Add(Series2)
        Me.Chart2.Size = New System.Drawing.Size(747, 252)
        Me.Chart2.TabIndex = 1
        Me.Chart2.Text = "Chart4"
        Title2.Name = "Title1"
        Title2.Text = "WEEKLY EARNINGS"
        Me.Chart2.Titles.Add(Title2)
        '
        'Chart1
        '
        ChartArea1.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea1)
        Me.Chart1.Location = New System.Drawing.Point(3, 3)
        Me.Chart1.Name = "Chart1"
        Me.Chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Fire
        Series1.ChartArea = "ChartArea1"
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Me.Chart1.Series.Add(Series1)
        Me.Chart1.Size = New System.Drawing.Size(747, 252)
        Me.Chart1.TabIndex = 1
        Me.Chart1.Text = "Chart1"
        Title1.Name = "Title1"
        Title1.Text = "MONTLY EARNINGS"
        Me.Chart1.Titles.Add(Title1)
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Guna2HtmlLabel1)
        Me.Panel1.Controls.Add(Me.FlowLayoutPanel2)
        Me.Panel1.Controls.Add(Me.FlowLayoutPanel1)
        Me.Panel1.Controls.Add(Me.RESTOCKBTN)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Guna2CircleButton1)
        Me.Panel1.Controls.Add(Me.STOCKSDataGridView)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.DataGridView1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1358, 1336)
        Me.Panel1.TabIndex = 8
        '
        'Guna2HtmlLabel1
        '
        Me.Guna2HtmlLabel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Guna2HtmlLabel1.Font = New System.Drawing.Font("ITC Kabel", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel1.ForeColor = System.Drawing.Color.Black
        Me.Guna2HtmlLabel1.Location = New System.Drawing.Point(35, 15)
        Me.Guna2HtmlLabel1.Name = "Guna2HtmlLabel1"
        Me.Guna2HtmlLabel1.Size = New System.Drawing.Size(241, 46)
        Me.Guna2HtmlLabel1.TabIndex = 12
        Me.Guna2HtmlLabel1.Text = "O V E R V I E W"
        '
        'TransactionsBindingSource
        '
        Me.TransactionsBindingSource.DataMember = "Transactions"
        Me.TransactionsBindingSource.DataSource = Me.SHITSTEMDataSet
        '
        'TransactionsTableAdapter
        '
        Me.TransactionsTableAdapter.ClearBeforeFill = True
        '
        'TransactionsDataGridView
        '
        Me.TransactionsDataGridView.AutoGenerateColumns = False
        Me.TransactionsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TransactionsDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn19, Me.DataGridViewTextBoxColumn20, Me.DataGridViewTextBoxColumn21, Me.DataGridViewTextBoxColumn22, Me.DataGridViewTextBoxColumn23, Me.DataGridViewTextBoxColumn24, Me.DataGridViewTextBoxColumn25})
        Me.TransactionsDataGridView.DataSource = Me.TransactionsBindingSource
        Me.TransactionsDataGridView.Location = New System.Drawing.Point(3, 519)
        Me.TransactionsDataGridView.Name = "TransactionsDataGridView"
        Me.TransactionsDataGridView.Size = New System.Drawing.Size(747, 220)
        Me.TransactionsDataGridView.TabIndex = 9
        '
        'DataGridViewTextBoxColumn19
        '
        Me.DataGridViewTextBoxColumn19.DataPropertyName = "TransactionID"
        Me.DataGridViewTextBoxColumn19.HeaderText = "TransactionID"
        Me.DataGridViewTextBoxColumn19.Name = "DataGridViewTextBoxColumn19"
        Me.DataGridViewTextBoxColumn19.ReadOnly = True
        '
        'DataGridViewTextBoxColumn20
        '
        Me.DataGridViewTextBoxColumn20.DataPropertyName = "TransactionDate"
        Me.DataGridViewTextBoxColumn20.HeaderText = "TransactionDate"
        Me.DataGridViewTextBoxColumn20.Name = "DataGridViewTextBoxColumn20"
        '
        'DataGridViewTextBoxColumn21
        '
        Me.DataGridViewTextBoxColumn21.DataPropertyName = "TotalAmount"
        Me.DataGridViewTextBoxColumn21.HeaderText = "TotalAmount"
        Me.DataGridViewTextBoxColumn21.Name = "DataGridViewTextBoxColumn21"
        '
        'DataGridViewTextBoxColumn22
        '
        Me.DataGridViewTextBoxColumn22.DataPropertyName = "PaymentAmount"
        Me.DataGridViewTextBoxColumn22.HeaderText = "PaymentAmount"
        Me.DataGridViewTextBoxColumn22.Name = "DataGridViewTextBoxColumn22"
        '
        'DataGridViewTextBoxColumn23
        '
        Me.DataGridViewTextBoxColumn23.DataPropertyName = "ChangeGiven"
        Me.DataGridViewTextBoxColumn23.HeaderText = "ChangeGiven"
        Me.DataGridViewTextBoxColumn23.Name = "DataGridViewTextBoxColumn23"
        '
        'DataGridViewTextBoxColumn24
        '
        Me.DataGridViewTextBoxColumn24.DataPropertyName = "Total_Item"
        Me.DataGridViewTextBoxColumn24.HeaderText = "Total_Item"
        Me.DataGridViewTextBoxColumn24.Name = "DataGridViewTextBoxColumn24"
        '
        'DataGridViewTextBoxColumn25
        '
        Me.DataGridViewTextBoxColumn25.DataPropertyName = "Profit"
        Me.DataGridViewTextBoxColumn25.HeaderText = "Profit"
        Me.DataGridViewTextBoxColumn25.Name = "DataGridViewTextBoxColumn25"
        '
        'SALES_TAB
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.Controls.Add(Me.Panel1)
        Me.Name = "SALES_TAB"
        Me.Size = New System.Drawing.Size(1358, 1336)
        CType(Me.DailySalesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SHITSTEMDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.STOCKSBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DailySummaryBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MonthlySalesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WeeklySalesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.STOCKSDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        CType(Me.DailySummaryDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.totalsalestodaypanel.ResumeLayout(False)
        Me.totalsalestodaypanel.PerformLayout()
        Me.todayprofitpanel.ResumeLayout(False)
        Me.todayprofitpanel.PerformLayout()
        Me.FlowLayoutPanel2.ResumeLayout(False)
        CType(Me.Chart2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.TransactionsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TransactionsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SHITSTEMDataSet As SHITSTEMDataSet
    Friend WithEvents DailySalesBindingSource As BindingSource
    Friend WithEvents DailySalesTableAdapter As SHITSTEMDataSetTableAdapters.DailySalesTableAdapter
    Friend WithEvents TableAdapterManager As SHITSTEMDataSetTableAdapters.TableAdapterManager
    Friend WithEvents WeeklySalesBindingSource As BindingSource
    Friend WithEvents MonthlySalesBindingSource As BindingSource
    Friend WithEvents MonthlySalesTableAdapter As SHITSTEMDataSetTableAdapters.MonthlySalesTableAdapter
    Friend WithEvents WeeklySalesTableAdapter As SHITSTEMDataSetTableAdapters.WeeklySalesTableAdapter
    Friend WithEvents STOCKSBindingSource As BindingSource
    Friend WithEvents STOCKSTableAdapter As SHITSTEMDataSetTableAdapters.STOCKSTableAdapter
    Friend WithEvents WeeklySalesTableAdapter1 As SHITSTEMDataSetTableAdapters.WeeklySalesTableAdapter
    Friend WithEvents DailySummaryBindingSource As BindingSource
    Friend WithEvents DailySummaryTableAdapter As SHITSTEMDataSetTableAdapters.DailySummaryTableAdapter
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents DataGridViewTextBoxColumn7 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As DataGridViewTextBoxColumn
    Friend WithEvents Label4 As Label
    Friend WithEvents STOCKSDataGridView As DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents Guna2CircleButton1 As Guna.UI2.WinForms.Guna2CircleButton
    Friend WithEvents Label5 As Label
    Friend WithEvents RESTOCKBTN As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents todayprofitpanel As Panel
    Friend WithEvents profitlbl As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents totalsalestodaypanel As Panel
    Friend WithEvents salesTotallbl As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents DailySummaryDataGridView As DataGridView
    Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As DataGridViewTextBoxColumn
    Friend WithEvents FlowLayoutPanel2 As FlowLayoutPanel
    Friend WithEvents Chart1 As DataVisualization.Charting.Chart
    Friend WithEvents Chart2 As DataVisualization.Charting.Chart
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Guna2HtmlLabel1 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents TransactionsDataGridView As DataGridView
    Friend WithEvents DataGridViewTextBoxColumn19 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn20 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn21 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn22 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn23 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn24 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn25 As DataGridViewTextBoxColumn
    Friend WithEvents TransactionsBindingSource As BindingSource
    Friend WithEvents TransactionsTableAdapter As SHITSTEMDataSetTableAdapters.TransactionsTableAdapter
End Class
