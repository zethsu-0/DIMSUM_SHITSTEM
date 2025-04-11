<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SALES_TAB
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Title1 As System.Windows.Forms.DataVisualization.Charting.Title = New System.Windows.Forms.DataVisualization.Charting.Title()
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Title2 As System.Windows.Forms.DataVisualization.Charting.Title = New System.Windows.Forms.DataVisualization.Charting.Title()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Chart2 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.EarnedLabel1 = New System.Windows.Forms.Label()
        Me.DailySalesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SHITSTEMDataSet = New DIMSUM_SHITSTEM.SHITSTEMDataSet()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DailySalesTableAdapter = New DIMSUM_SHITSTEM.SHITSTEMDataSetTableAdapters.DailySalesTableAdapter()
        Me.TableAdapterManager = New DIMSUM_SHITSTEM.SHITSTEMDataSetTableAdapters.TableAdapterManager()
        Me.MonthlySalesTableAdapter = New DIMSUM_SHITSTEM.SHITSTEMDataSetTableAdapters.MonthlySalesTableAdapter()
        Me.WeeklySalesTableAdapter = New DIMSUM_SHITSTEM.SHITSTEMDataSetTableAdapters.WeeklySalesTableAdapter()
        Me.MonthlySalesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.WeeklySalesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Panel5.SuspendLayout()
        CType(Me.Chart2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        CType(Me.DailySalesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SHITSTEMDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MonthlySalesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WeeklySalesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Panel5.Controls.Add(Me.Chart2)
        Me.Panel5.Location = New System.Drawing.Point(501, 344)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(803, 305)
        Me.Panel5.TabIndex = 6
        '
        'Chart2
        '
        ChartArea1.Name = "ChartArea1"
        Me.Chart2.ChartAreas.Add(ChartArea1)
        Me.Chart2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Chart2.Location = New System.Drawing.Point(0, 0)
        Me.Chart2.Name = "Chart2"
        Me.Chart2.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SemiTransparent
        Series1.ChartArea = "ChartArea1"
        Series1.Name = "Series1"
        Me.Chart2.Series.Add(Series1)
        Me.Chart2.Size = New System.Drawing.Size(803, 305)
        Me.Chart2.TabIndex = 1
        Me.Chart2.Text = "Chart4"
        Title1.Name = "Title1"
        Title1.Text = "WEEKLY EARNINGS"
        Me.Chart2.Titles.Add(Title1)
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Panel3.Controls.Add(Me.Chart1)
        Me.Panel3.Location = New System.Drawing.Point(501, 21)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(803, 292)
        Me.Panel3.TabIndex = 5
        '
        'Chart1
        '
        ChartArea2.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea2)
        Me.Chart1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Chart1.Location = New System.Drawing.Point(0, 0)
        Me.Chart1.Name = "Chart1"
        Me.Chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Fire
        Series2.ChartArea = "ChartArea1"
        Series2.Name = "Series1"
        Me.Chart1.Series.Add(Series2)
        Me.Chart1.Size = New System.Drawing.Size(803, 292)
        Me.Chart1.TabIndex = 1
        Me.Chart1.Text = "Chart1"
        Title2.Name = "Title1"
        Title2.Text = "MONTLY EARNINGS"
        Me.Chart1.Titles.Add(Title2)
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Panel4.Controls.Add(Me.EarnedLabel1)
        Me.Panel4.Controls.Add(Me.Label3)
        Me.Panel4.Controls.Add(Me.Label2)
        Me.Panel4.Controls.Add(Me.Label1)
        Me.Panel4.Location = New System.Drawing.Point(59, 21)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(325, 239)
        Me.Panel4.TabIndex = 2
        '
        'EarnedLabel1
        '
        Me.EarnedLabel1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.DailySalesBindingSource, "Earned", True))
        Me.EarnedLabel1.Font = New System.Drawing.Font("Palatino Linotype", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EarnedLabel1.Location = New System.Drawing.Point(133, 60)
        Me.EarnedLabel1.Name = "EarnedLabel1"
        Me.EarnedLabel1.Size = New System.Drawing.Size(123, 44)
        Me.EarnedLabel1.TabIndex = 5
        Me.EarnedLabel1.Text = "Label4"
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
        Me.Label1.Location = New System.Drawing.Point(106, 126)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(106, 22)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Earned Today"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DailySalesTableAdapter
        '
        Me.DailySalesTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.DailySalesTableAdapter = Me.DailySalesTableAdapter
        Me.TableAdapterManager.loginTableAdapter = Nothing
        Me.TableAdapterManager.MonthlySalesTableAdapter = Me.MonthlySalesTableAdapter
        Me.TableAdapterManager.OrdersTableAdapter = Nothing
        Me.TableAdapterManager.ProductGroupsTableAdapter = Nothing
        Me.TableAdapterManager.STOCKSTableAdapter = Nothing
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
        'SALES_TAB
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Name = "SALES_TAB"
        Me.Size = New System.Drawing.Size(1359, 684)
        Me.Panel5.ResumeLayout(False)
        CType(Me.Chart2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.DailySalesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SHITSTEMDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MonthlySalesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WeeklySalesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Chart1 As DataVisualization.Charting.Chart
    Friend WithEvents Chart2 As DataVisualization.Charting.Chart
    Friend WithEvents SHITSTEMDataSet As SHITSTEMDataSet
    Friend WithEvents DailySalesBindingSource As BindingSource
    Friend WithEvents DailySalesTableAdapter As SHITSTEMDataSetTableAdapters.DailySalesTableAdapter
    Friend WithEvents TableAdapterManager As SHITSTEMDataSetTableAdapters.TableAdapterManager
    Friend WithEvents WeeklySalesBindingSource As BindingSource
    Friend WithEvents MonthlySalesBindingSource As BindingSource
    Friend WithEvents MonthlySalesTableAdapter As SHITSTEMDataSetTableAdapters.MonthlySalesTableAdapter
    Friend WithEvents WeeklySalesTableAdapter As SHITSTEMDataSetTableAdapters.WeeklySalesTableAdapter
    Friend WithEvents EarnedLabel1 As Label
End Class
