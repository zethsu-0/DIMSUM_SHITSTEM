<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ADD_PRODUCT
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
        Dim PriceLabel As System.Windows.Forms.Label
        Dim QuatityLabel As System.Windows.Forms.Label
        Dim Product_nameLabel As System.Windows.Forms.Label
        Dim Item_noLabel As System.Windows.Forms.Label
        Me.SHITSTEMDataSet = New DIMSUM_SHITSTEM.SHITSTEMDataSet()
        Me.STOCKSBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.STOCKSTableAdapter = New DIMSUM_SHITSTEM.SHITSTEMDataSetTableAdapters.STOCKSTableAdapter()
        Me.TableAdapterManager = New DIMSUM_SHITSTEM.SHITSTEMDataSetTableAdapters.TableAdapterManager()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.STOCKSDataGridView = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        PriceLabel = New System.Windows.Forms.Label()
        QuatityLabel = New System.Windows.Forms.Label()
        Product_nameLabel = New System.Windows.Forms.Label()
        Item_noLabel = New System.Windows.Forms.Label()
        CType(Me.SHITSTEMDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.STOCKSBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.STOCKSDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PriceLabel
        '
        PriceLabel.AutoSize = True
        PriceLabel.Location = New System.Drawing.Point(89, 154)
        PriceLabel.Name = "PriceLabel"
        PriceLabel.Size = New System.Drawing.Size(33, 13)
        PriceLabel.TabIndex = 16
        PriceLabel.Text = "price:"
        '
        'QuatityLabel
        '
        QuatityLabel.AutoSize = True
        QuatityLabel.Location = New System.Drawing.Point(89, 128)
        QuatityLabel.Name = "QuatityLabel"
        QuatityLabel.Size = New System.Drawing.Size(41, 13)
        QuatityLabel.TabIndex = 14
        QuatityLabel.Text = "quatity:"
        '
        'Product_nameLabel
        '
        Product_nameLabel.AutoSize = True
        Product_nameLabel.Location = New System.Drawing.Point(89, 102)
        Product_nameLabel.Name = "Product_nameLabel"
        Product_nameLabel.Size = New System.Drawing.Size(75, 13)
        Product_nameLabel.TabIndex = 12
        Product_nameLabel.Text = "product name:"
        '
        'Item_noLabel
        '
        Item_noLabel.AutoSize = True
        Item_noLabel.Location = New System.Drawing.Point(89, 76)
        Item_noLabel.Name = "Item_noLabel"
        Item_noLabel.Size = New System.Drawing.Size(44, 13)
        Item_noLabel.TabIndex = 10
        Item_noLabel.Text = "item no:"
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
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(12, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(126, 48)
        Me.Button1.TabIndex = 9
        Me.Button1.Text = "ADD"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'STOCKSDataGridView
        '
        Me.STOCKSDataGridView.AutoGenerateColumns = False
        Me.STOCKSDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.STOCKSDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.STOCKSDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4})
        Me.STOCKSDataGridView.DataSource = Me.STOCKSBindingSource
        Me.STOCKSDataGridView.Location = New System.Drawing.Point(12, 66)
        Me.STOCKSDataGridView.Name = "STOCKSDataGridView"
        Me.STOCKSDataGridView.Size = New System.Drawing.Size(405, 220)
        Me.STOCKSDataGridView.TabIndex = 18
        Me.STOCKSDataGridView.Visible = False
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "item_no"
        Me.DataGridViewTextBoxColumn1.HeaderText = "item_no"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "product_name"
        Me.DataGridViewTextBoxColumn2.HeaderText = "product_name"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "quatity"
        Me.DataGridViewTextBoxColumn3.HeaderText = "quatity"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "price"
        Me.DataGridViewTextBoxColumn4.HeaderText = "price"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(291, 12)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(126, 48)
        Me.Button2.TabIndex = 19
        Me.Button2.Text = "REMOVE"
        Me.Button2.UseVisualStyleBackColor = True
        Me.Button2.Visible = False
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(187, 73)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(139, 20)
        Me.TextBox1.TabIndex = 21
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(187, 99)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(139, 20)
        Me.TextBox2.TabIndex = 22
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(187, 125)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(139, 20)
        Me.TextBox3.TabIndex = 23
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(187, 151)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(139, 20)
        Me.TextBox4.TabIndex = 24
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Navy
        Me.Label2.Location = New System.Drawing.Point(309, 300)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 13)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "Add An item?"
        Me.Label2.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(309, 194)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 13)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Remove An item?"
        '
        'ADD_PRODUCT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(429, 327)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.STOCKSDataGridView)
        Me.Controls.Add(Me.TextBox4)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Item_noLabel)
        Me.Controls.Add(Product_nameLabel)
        Me.Controls.Add(QuatityLabel)
        Me.Controls.Add(PriceLabel)
        Me.Controls.Add(Me.Button1)
        Me.Name = "ADD_PRODUCT"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "ADD_PRODUCT"
        CType(Me.SHITSTEMDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.STOCKSBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.STOCKSDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents SHITSTEMDataSet As SHITSTEMDataSet
    Friend WithEvents STOCKSBindingSource As BindingSource
    Friend WithEvents STOCKSTableAdapter As SHITSTEMDataSetTableAdapters.STOCKSTableAdapter
    Friend WithEvents TableAdapterManager As SHITSTEMDataSetTableAdapters.TableAdapterManager
    Friend WithEvents Button1 As Button
    Friend WithEvents ErrorProvider1 As ErrorProvider
    Friend WithEvents STOCKSDataGridView As DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents Button2 As Button
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
End Class
