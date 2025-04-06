<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Sales
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
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Title1 As System.Windows.Forms.DataVisualization.Charting.Title = New System.Windows.Forms.DataVisualization.Charting.Title()
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Title2 As System.Windows.Forms.DataVisualization.Charting.Title = New System.Windows.Forms.DataVisualization.Charting.Title()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.EarnedLabel1 = New System.Windows.Forms.Label()
        Me.DailySalesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SHITSTEMDataSet = New DIMSUM_SHITSTEM.SHITSTEMDataSet()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Chart2 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.MonthlySalesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.MonthlySalesTableAdapter = New DIMSUM_SHITSTEM.SHITSTEMDataSetTableAdapters.MonthlySalesTableAdapter()
        Me.TableAdapterManager = New DIMSUM_SHITSTEM.SHITSTEMDataSetTableAdapters.TableAdapterManager()
        Me.DailySalesTableAdapter = New DIMSUM_SHITSTEM.SHITSTEMDataSetTableAdapters.DailySalesTableAdapter()
        Me.WeeklySalesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.WeeklySalesTableAdapter = New DIMSUM_SHITSTEM.SHITSTEMDataSetTableAdapters.WeeklySalesTableAdapter()
        Me.Panel2.SuspendLayout()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        CType(Me.DailySalesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SHITSTEMDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.Chart2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel6.SuspendLayout()
        CType(Me.MonthlySalesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WeeklySalesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1375, 57)
        Me.Panel1.TabIndex = 1
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Red
        Me.Panel2.Controls.Add(Me.Chart1)
        Me.Panel2.Location = New System.Drawing.Point(373, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(882, 262)
        Me.Panel2.TabIndex = 0
        '
        'Chart1
        '
        ChartArea1.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea1)
        Me.Chart1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Chart1.Location = New System.Drawing.Point(0, 0)
        Me.Chart1.Name = "Chart1"
        Me.Chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Fire
        Series1.ChartArea = "ChartArea1"
        Series1.Name = "Series1"
        Me.Chart1.Series.Add(Series1)
        Me.Chart1.Size = New System.Drawing.Size(882, 262)
        Me.Chart1.TabIndex = 0
        Me.Chart1.Text = "Chart1"
        Title1.Name = "Title1"
        Title1.Text = "MONTLY EARNINGS"
        Me.Chart1.Titles.Add(Title1)
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Panel4.Controls.Add(Me.Label3)
        Me.Panel4.Controls.Add(Me.Label2)
        Me.Panel4.Controls.Add(Me.Label1)
        Me.Panel4.Controls.Add(Me.EarnedLabel1)
        Me.Panel4.Location = New System.Drawing.Point(3, 3)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(364, 262)
        Me.Panel4.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Palatino Linotype", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(84, 60)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 44)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "₱"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Palatino Linotype", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(88, 161)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 22)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "DMMYYYY"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Palatino Linotype", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(125, 126)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(106, 22)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Earned Today"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'EarnedLabel1
        '
        Me.EarnedLabel1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.DailySalesBindingSource, "Earned", True))
        Me.EarnedLabel1.Font = New System.Drawing.Font("Palatino Linotype", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EarnedLabel1.Location = New System.Drawing.Point(112, 39)
        Me.EarnedLabel1.Name = "EarnedLabel1"
        Me.EarnedLabel1.Size = New System.Drawing.Size(132, 87)
        Me.EarnedLabel1.TabIndex = 1
        Me.EarnedLabel1.Text = "Label1"
        Me.EarnedLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.AutoScroll = True
        Me.FlowLayoutPanel1.BackColor = System.Drawing.Color.Gray
        Me.FlowLayoutPanel1.Controls.Add(Me.Panel4)
        Me.FlowLayoutPanel1.Controls.Add(Me.Panel2)
        Me.FlowLayoutPanel1.Controls.Add(Me.Panel3)
        Me.FlowLayoutPanel1.Controls.Add(Me.Panel5)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 57)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(1375, 696)
        Me.FlowLayoutPanel1.TabIndex = 2
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Panel3.Location = New System.Drawing.Point(3, 271)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(364, 267)
        Me.Panel3.TabIndex = 2
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.Red
        Me.Panel5.Controls.Add(Me.Chart2)
        Me.Panel5.Location = New System.Drawing.Point(373, 271)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(882, 265)
        Me.Panel5.TabIndex = 1
        '
        'Chart2
        '
        ChartArea2.Name = "ChartArea1"
        Me.Chart2.ChartAreas.Add(ChartArea2)
        Me.Chart2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Chart2.Location = New System.Drawing.Point(0, 0)
        Me.Chart2.Name = "Chart2"
        Me.Chart2.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SemiTransparent
        Series2.ChartArea = "ChartArea1"
        Series2.Name = "Series1"
        Me.Chart2.Series.Add(Series2)
        Me.Chart2.Size = New System.Drawing.Size(882, 265)
        Me.Chart2.TabIndex = 0
        Me.Chart2.Text = "Chart4"
        Title2.Name = "Title1"
        Title2.Text = "WEEKLY EARNINGS"
        Me.Chart2.Titles.Add(Title2)
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.Button1)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel6.Location = New System.Drawing.Point(0, 698)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(1375, 55)
        Me.Panel6.TabIndex = 3
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(1212, 7)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(110, 40)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Close"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'MonthlySalesBindingSource
        '
        Me.MonthlySalesBindingSource.DataMember = "MonthlySales"
        Me.MonthlySalesBindingSource.DataSource = Me.SHITSTEMDataSet
        '
        'MonthlySalesTableAdapter
        '
        Me.MonthlySalesTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.DailySalesTableAdapter = Nothing
        Me.TableAdapterManager.loginTableAdapter = Nothing
        Me.TableAdapterManager.MonthlySalesTableAdapter = Me.MonthlySalesTableAdapter
        Me.TableAdapterManager.ProductGroupsTableAdapter = Nothing
        Me.TableAdapterManager.STOCKSTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = DIMSUM_SHITSTEM.SHITSTEMDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        Me.TableAdapterManager.WeeklySalesTableAdapter = Nothing
        '
        'DailySalesTableAdapter
        '
        Me.DailySalesTableAdapter.ClearBeforeFill = True
        '
        'WeeklySalesBindingSource
        '
        Me.WeeklySalesBindingSource.DataMember = "WeeklySales"
        Me.WeeklySalesBindingSource.DataSource = Me.SHITSTEMDataSet
        '
        'WeeklySalesTableAdapter
        '
        Me.WeeklySalesTableAdapter.ClearBeforeFill = True
        '
        'Sales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(1375, 753)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel6)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Location = New System.Drawing.Point(240, 175)
        Me.Name = "Sales"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "earnings"
        Me.Panel2.ResumeLayout(False)
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.DailySalesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SHITSTEMDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        CType(Me.Chart2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel6.ResumeLayout(False)
        CType(Me.MonthlySalesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WeeklySalesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Chart1 As DataVisualization.Charting.Chart
    Friend WithEvents Panel4 As Panel
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Chart2 As DataVisualization.Charting.Chart
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Button1 As Button
    Friend WithEvents SHITSTEMDataSet As SHITSTEMDataSet
    Friend WithEvents MonthlySalesBindingSource As BindingSource
    Friend WithEvents MonthlySalesTableAdapter As SHITSTEMDataSetTableAdapters.MonthlySalesTableAdapter
    Friend WithEvents TableAdapterManager As SHITSTEMDataSetTableAdapters.TableAdapterManager
    Friend WithEvents DailySalesBindingSource As BindingSource
    Friend WithEvents DailySalesTableAdapter As SHITSTEMDataSetTableAdapters.DailySalesTableAdapter
    Friend WithEvents EarnedLabel1 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents WeeklySalesBindingSource As BindingSource
    Friend WithEvents WeeklySalesTableAdapter As SHITSTEMDataSetTableAdapters.WeeklySalesTableAdapter
End Class
