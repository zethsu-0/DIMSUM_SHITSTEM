<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CASHIER
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Cancel = New Guna.UI2.WinForms.Guna2Button()
        Me.SiomaiFilter = New Guna.UI2.WinForms.Guna2Button()
        Me.SiopaoFilter = New Guna.UI2.WinForms.Guna2Button()
        Me.DrinksFilter = New Guna.UI2.WinForms.Guna2Button()
        Me.Guna2PictureBox1 = New Guna.UI2.WinForms.Guna2PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Guna2HtmlLabel3 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.discount_choice = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.paymenttxtbox = New System.Windows.Forms.TextBox()
        Me.Guna2HtmlLabel1 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.lbltotal = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.OrdersDataGridView = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Item_no = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OrdersBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SHITSTEMDataSet = New DIMSUM_SHITSTEM.SHITSTEMDataSet()
        Me.checkoutbtn = New Guna.UI2.WinForms.Guna2Button()
        Me.Guna2ControlBox1 = New Guna.UI2.WinForms.Guna2ControlBox()
        Me.Guna2Panel1 = New Guna.UI2.WinForms.Guna2Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Guna2ControlBox2 = New Guna.UI2.WinForms.Guna2ControlBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel3 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBoxSearch = New System.Windows.Forms.TextBox()
        Me.panel3 = New Guna.UI2.WinForms.Guna2Panel()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.OrdersTableAdapter = New DIMSUM_SHITSTEM.SHITSTEMDataSetTableAdapters.OrdersTableAdapter()
        Me.TableAdapterManager = New DIMSUM_SHITSTEM.SHITSTEMDataSetTableAdapters.TableAdapterManager()
        Me.Guna2Button1 = New Guna.UI2.WinForms.Guna2Button()
        Me.Panel2.SuspendLayout()
        Me.FlowLayoutPanel2.SuspendLayout()
        CType(Me.Guna2PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.OrdersDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OrdersBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SHITSTEMDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Guna2Panel1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.FlowLayoutPanel2)
        Me.Panel2.Controls.Add(Me.Guna2PictureBox1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(253, 908)
        Me.Panel2.TabIndex = 1
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.FlowLayoutPanel2.AutoScroll = True
        Me.FlowLayoutPanel2.Controls.Add(Me.Cancel)
        Me.FlowLayoutPanel2.Controls.Add(Me.SiomaiFilter)
        Me.FlowLayoutPanel2.Controls.Add(Me.SiopaoFilter)
        Me.FlowLayoutPanel2.Controls.Add(Me.DrinksFilter)
        Me.FlowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(36, 224)
        Me.FlowLayoutPanel2.Margin = New System.Windows.Forms.Padding(4)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(188, 649)
        Me.FlowLayoutPanel2.TabIndex = 22
        Me.FlowLayoutPanel2.WrapContents = False
        '
        'Cancel
        '
        Me.Cancel.Animated = True
        Me.Cancel.BorderRadius = 15
        Me.Cancel.BorderThickness = 2
        Me.Cancel.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.Cancel.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.Cancel.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.Cancel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.Cancel.FillColor = System.Drawing.Color.White
        Me.Cancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Cancel.ForeColor = System.Drawing.Color.Black
        Me.Cancel.Location = New System.Drawing.Point(27, 25)
        Me.Cancel.Margin = New System.Windows.Forms.Padding(27, 25, 27, 25)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.Size = New System.Drawing.Size(107, 98)
        Me.Cancel.TabIndex = 24
        Me.Cancel.Text = "All"
        Me.Cancel.TextOffset = New System.Drawing.Point(0, 25)
        '
        'SiomaiFilter
        '
        Me.SiomaiFilter.Animated = True
        Me.SiomaiFilter.BorderRadius = 15
        Me.SiomaiFilter.BorderThickness = 2
        Me.SiomaiFilter.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.SiomaiFilter.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.SiomaiFilter.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.SiomaiFilter.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.SiomaiFilter.FillColor = System.Drawing.Color.White
        Me.SiomaiFilter.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold)
        Me.SiomaiFilter.ForeColor = System.Drawing.Color.Black
        Me.SiomaiFilter.Location = New System.Drawing.Point(27, 173)
        Me.SiomaiFilter.Margin = New System.Windows.Forms.Padding(27, 25, 27, 25)
        Me.SiomaiFilter.Name = "SiomaiFilter"
        Me.SiomaiFilter.Size = New System.Drawing.Size(107, 98)
        Me.SiomaiFilter.TabIndex = 19
        Me.SiomaiFilter.Text = "Siomai"
        Me.SiomaiFilter.TextOffset = New System.Drawing.Point(0, 25)
        '
        'SiopaoFilter
        '
        Me.SiopaoFilter.Animated = True
        Me.SiopaoFilter.BorderRadius = 15
        Me.SiopaoFilter.BorderThickness = 2
        Me.SiopaoFilter.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.SiopaoFilter.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.SiopaoFilter.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.SiopaoFilter.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.SiopaoFilter.FillColor = System.Drawing.Color.White
        Me.SiopaoFilter.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold)
        Me.SiopaoFilter.ForeColor = System.Drawing.Color.Black
        Me.SiopaoFilter.Location = New System.Drawing.Point(27, 321)
        Me.SiopaoFilter.Margin = New System.Windows.Forms.Padding(27, 25, 27, 25)
        Me.SiopaoFilter.Name = "SiopaoFilter"
        Me.SiopaoFilter.Size = New System.Drawing.Size(107, 98)
        Me.SiopaoFilter.TabIndex = 25
        Me.SiopaoFilter.Text = "Siopao"
        Me.SiopaoFilter.TextOffset = New System.Drawing.Point(0, 25)
        '
        'DrinksFilter
        '
        Me.DrinksFilter.Animated = True
        Me.DrinksFilter.BorderRadius = 15
        Me.DrinksFilter.BorderThickness = 2
        Me.DrinksFilter.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.DrinksFilter.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.DrinksFilter.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.DrinksFilter.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.DrinksFilter.FillColor = System.Drawing.Color.White
        Me.DrinksFilter.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold)
        Me.DrinksFilter.ForeColor = System.Drawing.Color.Black
        Me.DrinksFilter.Location = New System.Drawing.Point(27, 469)
        Me.DrinksFilter.Margin = New System.Windows.Forms.Padding(27, 25, 27, 25)
        Me.DrinksFilter.Name = "DrinksFilter"
        Me.DrinksFilter.Size = New System.Drawing.Size(107, 98)
        Me.DrinksFilter.TabIndex = 20
        Me.DrinksFilter.Text = "Drinks"
        Me.DrinksFilter.TextOffset = New System.Drawing.Point(0, 25)
        '
        'Guna2PictureBox1
        '
        Me.Guna2PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.Guna2PictureBox1.BorderRadius = 15
        Me.Guna2PictureBox1.Image = Global.DIMSUM_SHITSTEM.My.Resources.Resources.icon
        Me.Guna2PictureBox1.ImageRotate = 0!
        Me.Guna2PictureBox1.Location = New System.Drawing.Point(36, 27)
        Me.Guna2PictureBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.Guna2PictureBox1.Name = "Guna2PictureBox1"
        Me.Guna2PictureBox1.Size = New System.Drawing.Size(173, 160)
        Me.Guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Guna2PictureBox1.TabIndex = 1
        Me.Guna2PictureBox1.TabStop = False
        Me.Guna2PictureBox1.UseTransparentBackground = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(27, 32)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(136, 39)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Orders:"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Guna2Button1)
        Me.Panel1.Controls.Add(Me.Guna2HtmlLabel3)
        Me.Panel1.Controls.Add(Me.discount_choice)
        Me.Panel1.Controls.Add(Me.paymenttxtbox)
        Me.Panel1.Controls.Add(Me.Guna2HtmlLabel1)
        Me.Panel1.Controls.Add(Me.lbltotal)
        Me.Panel1.Controls.Add(Me.OrdersDataGridView)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.checkoutbtn)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(944, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(471, 850)
        Me.Panel1.TabIndex = 8
        '
        'Guna2HtmlLabel3
        '
        Me.Guna2HtmlLabel3.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel3.Location = New System.Drawing.Point(27, 537)
        Me.Guna2HtmlLabel3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Guna2HtmlLabel3.Name = "Guna2HtmlLabel3"
        Me.Guna2HtmlLabel3.Size = New System.Drawing.Size(119, 18)
        Me.Guna2HtmlLabel3.TabIndex = 27
        Me.Guna2HtmlLabel3.Text = "APPLY DISCOUNT"
        '
        'discount_choice
        '
        Me.discount_choice.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.discount_choice.AutoRoundedCorners = True
        Me.discount_choice.BackColor = System.Drawing.Color.Transparent
        Me.discount_choice.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.discount_choice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.discount_choice.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.discount_choice.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.discount_choice.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.discount_choice.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.discount_choice.ItemHeight = 30
        Me.discount_choice.Items.AddRange(New Object() {"NONE", "PWD/SENIOR", "20%", "10%"})
        Me.discount_choice.Location = New System.Drawing.Point(16, 560)
        Me.discount_choice.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.discount_choice.Name = "discount_choice"
        Me.discount_choice.Size = New System.Drawing.Size(140, 36)
        Me.discount_choice.TabIndex = 26
        '
        'paymenttxtbox
        '
        Me.paymenttxtbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.paymenttxtbox.Location = New System.Drawing.Point(267, 560)
        Me.paymenttxtbox.Margin = New System.Windows.Forms.Padding(4)
        Me.paymenttxtbox.Name = "paymenttxtbox"
        Me.paymenttxtbox.Size = New System.Drawing.Size(147, 34)
        Me.paymenttxtbox.TabIndex = 24
        '
        'Guna2HtmlLabel1
        '
        Me.Guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel1.Location = New System.Drawing.Point(272, 526)
        Me.Guna2HtmlLabel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Guna2HtmlLabel1.Name = "Guna2HtmlLabel1"
        Me.Guna2HtmlLabel1.Size = New System.Drawing.Size(76, 26)
        Me.Guna2HtmlLabel1.TabIndex = 20
        Me.Guna2HtmlLabel1.Text = "TOTAL: "
        Me.Guna2HtmlLabel1.TextAlignment = System.Drawing.ContentAlignment.BottomLeft
        '
        'lbltotal
        '
        Me.lbltotal.BackColor = System.Drawing.Color.Transparent
        Me.lbltotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltotal.Location = New System.Drawing.Point(356, 528)
        Me.lbltotal.Margin = New System.Windows.Forms.Padding(4)
        Me.lbltotal.Name = "lbltotal"
        Me.lbltotal.Size = New System.Drawing.Size(36, 26)
        Me.lbltotal.TabIndex = 19
        Me.lbltotal.Text = "000"
        Me.lbltotal.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        '
        'OrdersDataGridView
        '
        Me.OrdersDataGridView.AllowUserToAddRows = False
        Me.OrdersDataGridView.AllowUserToDeleteRows = False
        Me.OrdersDataGridView.AllowUserToResizeColumns = False
        Me.OrdersDataGridView.AllowUserToResizeRows = False
        Me.OrdersDataGridView.AutoGenerateColumns = False
        Me.OrdersDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.OrdersDataGridView.BackgroundColor = System.Drawing.Color.White
        Me.OrdersDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.OrdersDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.OrdersDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.OrdersDataGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.OrdersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.OrdersDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.Item_no, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4})
        Me.OrdersDataGridView.DataSource = Me.OrdersBindingSource
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.OrdersDataGridView.DefaultCellStyle = DataGridViewCellStyle6
        Me.OrdersDataGridView.Location = New System.Drawing.Point(16, 76)
        Me.OrdersDataGridView.Margin = New System.Windows.Forms.Padding(4)
        Me.OrdersDataGridView.Name = "OrdersDataGridView"
        Me.OrdersDataGridView.ReadOnly = True
        Me.OrdersDataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.OrdersDataGridView.RowHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.OrdersDataGridView.RowHeadersVisible = False
        Me.OrdersDataGridView.RowHeadersWidth = 51
        Me.OrdersDataGridView.Size = New System.Drawing.Size(439, 444)
        Me.OrdersDataGridView.TabIndex = 9
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "Product_name"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DataGridViewTextBoxColumn1.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewTextBoxColumn1.FillWeight = 97.00599!
        Me.DataGridViewTextBoxColumn1.HeaderText = "Name"
        Me.DataGridViewTextBoxColumn1.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'Item_no
        '
        Me.Item_no.DataPropertyName = "Item_no"
        Me.Item_no.HeaderText = "Item_no"
        Me.Item_no.MinimumWidth = 6
        Me.Item_no.Name = "Item_no"
        Me.Item_no.ReadOnly = True
        Me.Item_no.Visible = False
        Me.Item_no.Width = 125
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "Quantity"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGridViewTextBoxColumn2.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridViewTextBoxColumn2.FillWeight = 75.85712!
        Me.DataGridViewTextBoxColumn2.HeaderText = "Qty"
        Me.DataGridViewTextBoxColumn2.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 60
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "Price"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGridViewTextBoxColumn3.DefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridViewTextBoxColumn3.FillWeight = 101.0499!
        Me.DataGridViewTextBoxColumn3.HeaderText = "Price"
        Me.DataGridViewTextBoxColumn3.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 60
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "Total_price"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGridViewTextBoxColumn4.DefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridViewTextBoxColumn4.FillWeight = 126.087!
        Me.DataGridViewTextBoxColumn4.HeaderText = "Total"
        Me.DataGridViewTextBoxColumn4.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 60
        '
        'OrdersBindingSource
        '
        Me.OrdersBindingSource.DataMember = "Orders"
        Me.OrdersBindingSource.DataSource = Me.SHITSTEMDataSet
        '
        'SHITSTEMDataSet
        '
        Me.SHITSTEMDataSet.DataSetName = "SHITSTEMDataSet"
        Me.SHITSTEMDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'checkoutbtn
        '
        Me.checkoutbtn.Animated = True
        Me.checkoutbtn.BackColor = System.Drawing.Color.Transparent
        Me.checkoutbtn.BorderRadius = 15
        Me.checkoutbtn.BorderThickness = 2
        Me.checkoutbtn.CustomBorderThickness = New System.Windows.Forms.Padding(2)
        Me.checkoutbtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.checkoutbtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.checkoutbtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.checkoutbtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.checkoutbtn.FillColor = System.Drawing.Color.White
        Me.checkoutbtn.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.checkoutbtn.ForeColor = System.Drawing.Color.Black
        Me.checkoutbtn.HoverState.BorderColor = System.Drawing.Color.Transparent
        Me.checkoutbtn.HoverState.FillColor = System.Drawing.Color.DimGray
        Me.checkoutbtn.HoverState.ForeColor = System.Drawing.Color.White
        Me.checkoutbtn.Location = New System.Drawing.Point(128, 752)
        Me.checkoutbtn.Margin = New System.Windows.Forms.Padding(27, 25, 27, 25)
        Me.checkoutbtn.Name = "checkoutbtn"
        Me.checkoutbtn.Size = New System.Drawing.Size(204, 63)
        Me.checkoutbtn.TabIndex = 17
        Me.checkoutbtn.Text = "check out"
        Me.checkoutbtn.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias
        '
        'Guna2ControlBox1
        '
        Me.Guna2ControlBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Guna2ControlBox1.BackColor = System.Drawing.Color.Black
        Me.Guna2ControlBox1.FillColor = System.Drawing.Color.White
        Me.Guna2ControlBox1.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Guna2ControlBox1.IconColor = System.Drawing.Color.Black
        Me.Guna2ControlBox1.Location = New System.Drawing.Point(1355, 4)
        Me.Guna2ControlBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.Guna2ControlBox1.Name = "Guna2ControlBox1"
        Me.Guna2ControlBox1.Size = New System.Drawing.Size(53, 49)
        Me.Guna2ControlBox1.TabIndex = 11
        '
        'Guna2Panel1
        '
        Me.Guna2Panel1.BackColor = System.Drawing.Color.White
        Me.Guna2Panel1.Controls.Add(Me.Label3)
        Me.Guna2Panel1.Controls.Add(Me.Guna2ControlBox2)
        Me.Guna2Panel1.Controls.Add(Me.Guna2ControlBox1)
        Me.Guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Guna2Panel1.Location = New System.Drawing.Point(253, 0)
        Me.Guna2Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Guna2Panel1.Name = "Guna2Panel1"
        Me.Guna2Panel1.Size = New System.Drawing.Size(1415, 58)
        Me.Guna2Panel1.TabIndex = 12
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(13, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(122, 39)
        Me.Label3.TabIndex = 27
        Me.Label3.Text = "MENU"
        '
        'Guna2ControlBox2
        '
        Me.Guna2ControlBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Guna2ControlBox2.BackColor = System.Drawing.Color.Black
        Me.Guna2ControlBox2.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox
        Me.Guna2ControlBox2.FillColor = System.Drawing.Color.White
        Me.Guna2ControlBox2.HoverState.FillColor = System.Drawing.Color.Silver
        Me.Guna2ControlBox2.IconColor = System.Drawing.Color.Black
        Me.Guna2ControlBox2.Location = New System.Drawing.Point(1300, 4)
        Me.Guna2ControlBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.Guna2ControlBox2.Name = "Guna2ControlBox2"
        Me.Guna2ControlBox2.Size = New System.Drawing.Size(53, 49)
        Me.Guna2ControlBox2.TabIndex = 12
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.White
        Me.Panel4.Controls.Add(Me.Label4)
        Me.Panel4.Controls.Add(Me.FlowLayoutPanel3)
        Me.Panel4.Controls.Add(Me.Label2)
        Me.Panel4.Controls.Add(Me.TextBoxSearch)
        Me.Panel4.Controls.Add(Me.panel3)
        Me.Panel4.Controls.Add(Me.Panel1)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(253, 58)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1415, 850)
        Me.Panel4.TabIndex = 13
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Aquamarine
        Me.Label4.Location = New System.Drawing.Point(17, 679)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 16)
        Me.Label4.TabIndex = 28
        Me.Label4.Text = "others"
        '
        'FlowLayoutPanel3
        '
        Me.FlowLayoutPanel3.BackColor = System.Drawing.Color.LightGray
        Me.FlowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.FlowLayoutPanel3.Location = New System.Drawing.Point(0, 698)
        Me.FlowLayoutPanel3.Name = "FlowLayoutPanel3"
        Me.FlowLayoutPanel3.Size = New System.Drawing.Size(944, 152)
        Me.FlowLayoutPanel3.TabIndex = 27
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(13, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(167, 39)
        Me.Label2.TabIndex = 26
        Me.Label2.Text = "SEARCH"
        '
        'TextBoxSearch
        '
        Me.TextBoxSearch.BackColor = System.Drawing.Color.Silver
        Me.TextBoxSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxSearch.Location = New System.Drawing.Point(215, 15)
        Me.TextBoxSearch.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxSearch.Name = "TextBoxSearch"
        Me.TextBoxSearch.Size = New System.Drawing.Size(359, 34)
        Me.TextBoxSearch.TabIndex = 25
        '
        'panel3
        '
        Me.panel3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panel3.BackColor = System.Drawing.Color.SeaShell
        Me.panel3.Controls.Add(Me.FlowLayoutPanel1)
        Me.panel3.Location = New System.Drawing.Point(20, 139)
        Me.panel3.Margin = New System.Windows.Forms.Padding(4)
        Me.panel3.Name = "panel3"
        Me.panel3.Size = New System.Drawing.Size(895, 527)
        Me.panel3.TabIndex = 11
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.AutoScroll = True
        Me.FlowLayoutPanel1.BackColor = System.Drawing.Color.White
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.FlowLayoutPanel1.Margin = New System.Windows.Forms.Padding(4)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(895, 527)
        Me.FlowLayoutPanel1.TabIndex = 0
        '
        'OrdersTableAdapter
        '
        Me.OrdersTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.DailySalesTableAdapter = Nothing
        Me.TableAdapterManager.DailySummaryTableAdapter = Nothing
        Me.TableAdapterManager.loginTableAdapter = Nothing
        Me.TableAdapterManager.MonthlySalesTableAdapter = Nothing
        Me.TableAdapterManager.OrdersTableAdapter = Me.OrdersTableAdapter
        Me.TableAdapterManager.ProductGroupsTableAdapter = Nothing
        Me.TableAdapterManager.STOCKSTableAdapter = Nothing
        Me.TableAdapterManager.TransactionDetailsTableAdapter = Nothing
        Me.TableAdapterManager.TransactionsTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = DIMSUM_SHITSTEM.SHITSTEMDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        Me.TableAdapterManager.WeeklySalesTableAdapter = Nothing
        '
        'Guna2Button1
        '
        Me.Guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.Guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.Guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.Guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.Guna2Button1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Guna2Button1.ForeColor = System.Drawing.Color.White
        Me.Guna2Button1.Location = New System.Drawing.Point(288, 820)
        Me.Guna2Button1.Name = "Guna2Button1"
        Me.Guna2Button1.Size = New System.Drawing.Size(183, 30)
        Me.Guna2Button1.TabIndex = 28
        Me.Guna2Button1.Text = "cancel order"
        '
        'CASHIER
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1668, 908)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Guna2Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "CASHIER"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CASHIER"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel2.ResumeLayout(False)
        Me.FlowLayoutPanel2.ResumeLayout(False)
        CType(Me.Guna2PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.OrdersDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OrdersBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SHITSTEMDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Guna2Panel1.ResumeLayout(False)
        Me.Guna2Panel1.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.panel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Guna2PictureBox1 As Guna.UI2.WinForms.Guna2PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents checkoutbtn As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents SHITSTEMDataSet As SHITSTEMDataSet
    Friend WithEvents OrdersBindingSource As BindingSource
    Friend WithEvents OrdersTableAdapter As SHITSTEMDataSetTableAdapters.OrdersTableAdapter
    Friend WithEvents TableAdapterManager As SHITSTEMDataSetTableAdapters.TableAdapterManager
    Friend WithEvents OrdersDataGridView As DataGridView
    Friend WithEvents SiomaiFilter As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Guna2Panel1 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents Guna2ControlBox1 As Guna.UI2.WinForms.Guna2ControlBox
    Friend WithEvents Guna2ControlBox2 As Guna.UI2.WinForms.Guna2ControlBox
    Friend WithEvents Panel4 As Panel
    Friend WithEvents lbltotal As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents Guna2HtmlLabel1 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents panel3 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents paymenttxtbox As TextBox
    Friend WithEvents TextBoxSearch As TextBox
    Friend WithEvents DrinksFilter As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents FlowLayoutPanel2 As FlowLayoutPanel
    Friend WithEvents Cancel As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents SiopaoFilter As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents discount_choice As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents Guna2HtmlLabel3 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents Item_no As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents FlowLayoutPanel3 As FlowLayoutPanel
    Friend WithEvents Label4 As Label
    Friend WithEvents Guna2Button1 As Guna.UI2.WinForms.Guna2Button
End Class
