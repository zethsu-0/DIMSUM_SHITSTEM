<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form3
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
        Dim Item_noLabel As System.Windows.Forms.Label
        Dim Product_nameLabel As System.Windows.Forms.Label
        Dim QuatityLabel As System.Windows.Forms.Label
        Dim PriceLabel As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form3))
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SHITSTEMDataSet = New DIMSUM_SHITSTEM.SHITSTEMDataSet()
        Me.STOCKSBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.STOCKSTableAdapter = New DIMSUM_SHITSTEM.SHITSTEMDataSetTableAdapters.STOCKSTableAdapter()
        Me.TableAdapterManager = New DIMSUM_SHITSTEM.SHITSTEMDataSetTableAdapters.TableAdapterManager()
        Me.STOCKSDataGridView = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.TextBox7 = New System.Windows.Forms.TextBox()
        Me.TextBox8 = New System.Windows.Forms.TextBox()
        Me.Button7 = New System.Windows.Forms.Button()
        Item_noLabel = New System.Windows.Forms.Label()
        Product_nameLabel = New System.Windows.Forms.Label()
        QuatityLabel = New System.Windows.Forms.Label()
        PriceLabel = New System.Windows.Forms.Label()
        CType(Me.SHITSTEMDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.STOCKSBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.STOCKSDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Item_noLabel
        '
        Item_noLabel.AutoSize = True
        Item_noLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!)
        Item_noLabel.Location = New System.Drawing.Point(6, 58)
        Item_noLabel.Name = "Item_noLabel"
        Item_noLabel.Size = New System.Drawing.Size(88, 25)
        Item_noLabel.TabIndex = 39
        Item_noLabel.Text = "Item no:"
        '
        'Product_nameLabel
        '
        Product_nameLabel.AutoSize = True
        Product_nameLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!)
        Product_nameLabel.Location = New System.Drawing.Point(6, 92)
        Product_nameLabel.Name = "Product_nameLabel"
        Product_nameLabel.Size = New System.Drawing.Size(151, 25)
        Product_nameLabel.TabIndex = 40
        Product_nameLabel.Text = "Product name:"
        '
        'QuatityLabel
        '
        QuatityLabel.AutoSize = True
        QuatityLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!)
        QuatityLabel.Location = New System.Drawing.Point(6, 164)
        QuatityLabel.Name = "QuatityLabel"
        QuatityLabel.Size = New System.Drawing.Size(86, 25)
        QuatityLabel.TabIndex = 41
        QuatityLabel.Text = "Quatity:"
        '
        'PriceLabel
        '
        PriceLabel.AutoSize = True
        PriceLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!)
        PriceLabel.Location = New System.Drawing.Point(6, 201)
        PriceLabel.Name = "PriceLabel"
        PriceLabel.Size = New System.Drawing.Size(67, 25)
        PriceLabel.TabIndex = 42
        PriceLabel.Text = "Price:"
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(859, 18)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(113, 31)
        Me.Button1.TabIndex = 21
        Me.Button1.Text = "edit"
        Me.Button1.UseVisualStyleBackColor = True
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
        Me.TableAdapterManager.loginTableAdapter = Nothing
        Me.TableAdapterManager.STOCKSTableAdapter = Me.STOCKSTableAdapter
        Me.TableAdapterManager.UpdateOrder = DIMSUM_SHITSTEM.SHITSTEMDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'STOCKSDataGridView
        '
        Me.STOCKSDataGridView.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.STOCKSDataGridView.AutoGenerateColumns = False
        Me.STOCKSDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.STOCKSDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.STOCKSDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4})
        Me.STOCKSDataGridView.DataSource = Me.STOCKSBindingSource
        Me.STOCKSDataGridView.Location = New System.Drawing.Point(12, 70)
        Me.STOCKSDataGridView.Name = "STOCKSDataGridView"
        Me.STOCKSDataGridView.ReadOnly = True
        Me.STOCKSDataGridView.Size = New System.Drawing.Size(680, 256)
        Me.STOCKSDataGridView.TabIndex = 22
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "item_no"
        Me.DataGridViewTextBoxColumn1.HeaderText = "item_no"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "product_name"
        Me.DataGridViewTextBoxColumn2.HeaderText = "product_name"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "quatity"
        Me.DataGridViewTextBoxColumn3.HeaderText = "quatity"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "price"
        Me.DataGridViewTextBoxColumn4.HeaderText = "price"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.Location = New System.Drawing.Point(859, 373)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(113, 31)
        Me.Button2.TabIndex = 23
        Me.Button2.Text = "back"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Button3.Location = New System.Drawing.Point(722, 18)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(113, 31)
        Me.Button3.TabIndex = 31
        Me.Button3.Text = "Add"
        Me.Button3.UseVisualStyleBackColor = True
        Me.Button3.Visible = False
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(7, 58)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 25)
        Me.Label1.TabIndex = 32
        Me.Label1.Text = "Item No."
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(7, 92)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(154, 25)
        Me.Label2.TabIndex = 33
        Me.Label2.Text = "Product Name:"
        '
        'Label3
        '
        Me.Label3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(7, 164)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(92, 25)
        Me.Label3.TabIndex = 34
        Me.Label3.Text = "Quantity"
        '
        'Label4
        '
        Me.Label4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(6, 201)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 25)
        Me.Label4.TabIndex = 35
        Me.Label4.Text = "Price"
        '
        'Button4
        '
        Me.Button4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button4.Location = New System.Drawing.Point(859, 18)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(113, 31)
        Me.Button4.TabIndex = 36
        Me.Button4.Text = "close edit"
        Me.Button4.UseVisualStyleBackColor = True
        Me.Button4.Visible = False
        '
        'Label5
        '
        Me.Label5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(209, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(42, 20)
        Me.Label5.TabIndex = 37
        Me.Label5.Text = "save"
        '
        'TextBox4
        '
        Me.TextBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TextBox4.Location = New System.Drawing.Point(168, 200)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(100, 26)
        Me.TextBox4.TabIndex = 47
        '
        'TextBox3
        '
        Me.TextBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TextBox3.Location = New System.Drawing.Point(168, 163)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(100, 26)
        Me.TextBox3.TabIndex = 46
        '
        'TextBox2
        '
        Me.TextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TextBox2.Location = New System.Drawing.Point(22, 121)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(245, 26)
        Me.TextBox2.TabIndex = 45
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TextBox1.Location = New System.Drawing.Point(174, 57)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(93, 26)
        Me.TextBox1.TabIndex = 44
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(6, 19)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(93, 32)
        Me.Button6.TabIndex = 38
        Me.Button6.Text = "ADD"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(175, 19)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(93, 32)
        Me.Button5.TabIndex = 48
        Me.Button5.Text = "REMOVE"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.Color.Silver
        Me.GroupBox1.Controls.Add(Me.Button6)
        Me.GroupBox1.Controls.Add(Me.Button5)
        Me.GroupBox1.Controls.Add(Me.TextBox4)
        Me.GroupBox1.Controls.Add(PriceLabel)
        Me.GroupBox1.Controls.Add(Me.TextBox3)
        Me.GroupBox1.Controls.Add(QuatityLabel)
        Me.GroupBox1.Controls.Add(Me.TextBox2)
        Me.GroupBox1.Controls.Add(Product_nameLabel)
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Controls.Add(Item_noLabel)
        Me.GroupBox1.Location = New System.Drawing.Point(698, 70)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(274, 256)
        Me.GroupBox1.TabIndex = 49
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.TextBox5)
        Me.GroupBox2.Controls.Add(Me.TextBox6)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.TextBox7)
        Me.GroupBox2.Controls.Add(Me.TextBox8)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Location = New System.Drawing.Point(698, 70)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(274, 256)
        Me.GroupBox2.TabIndex = 50
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Visible = False
        '
        'TextBox5
        '
        Me.TextBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TextBox5.Location = New System.Drawing.Point(169, 199)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(100, 26)
        Me.TextBox5.TabIndex = 51
        '
        'TextBox6
        '
        Me.TextBox6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TextBox6.Location = New System.Drawing.Point(169, 162)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New System.Drawing.Size(100, 26)
        Me.TextBox6.TabIndex = 50
        '
        'TextBox7
        '
        Me.TextBox7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TextBox7.Location = New System.Drawing.Point(23, 120)
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Size = New System.Drawing.Size(245, 26)
        Me.TextBox7.TabIndex = 49
        '
        'TextBox8
        '
        Me.TextBox8.Enabled = False
        Me.TextBox8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TextBox8.Location = New System.Drawing.Point(175, 56)
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.ReadOnly = True
        Me.TextBox8.Size = New System.Drawing.Size(93, 26)
        Me.TextBox8.TabIndex = 48
        '
        'Button7
        '
        Me.Button7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button7.Location = New System.Drawing.Point(722, 18)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(113, 31)
        Me.Button7.TabIndex = 51
        Me.Button7.Text = "edit"
        Me.Button7.UseVisualStyleBackColor = True
        Me.Button7.Visible = False
        '
        'Form3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 407)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.STOCKSDataGridView)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(1000, 446)
        Me.Name = "Form3"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "STOCKS"
        CType(Me.SHITSTEMDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.STOCKSBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.STOCKSDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button1 As Button
    Friend WithEvents SHITSTEMDataSet As SHITSTEMDataSet
    Friend WithEvents STOCKSBindingSource As BindingSource
    Friend WithEvents STOCKSTableAdapter As SHITSTEMDataSetTableAdapters.STOCKSTableAdapter
    Friend WithEvents TableAdapterManager As SHITSTEMDataSetTableAdapters.TableAdapterManager
    Friend WithEvents STOCKSDataGridView As DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Button4 As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Button6 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Button7 As Button
    Friend WithEvents TextBox5 As TextBox
    Friend WithEvents TextBox6 As TextBox
    Friend WithEvents TextBox7 As TextBox
    Friend WithEvents TextBox8 As TextBox
End Class
