<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Users
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
        Me.SHITSTEMDataSet = New DIMSUM_SHITSTEM.SHITSTEMDataSet()
        Me.LoginBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.LoginTableAdapter = New DIMSUM_SHITSTEM.SHITSTEMDataSetTableAdapters.loginTableAdapter()
        Me.TableAdapterManager = New DIMSUM_SHITSTEM.SHITSTEMDataSetTableAdapters.TableAdapterManager()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TextBox7 = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Guna2BorderlessForm1 = New Guna.UI2.WinForms.Guna2BorderlessForm(Me.components)
        CType(Me.SHITSTEMDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LoginBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SHITSTEMDataSet
        '
        Me.SHITSTEMDataSet.DataSetName = "SHITSTEMDataSet"
        Me.SHITSTEMDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'LoginBindingSource
        '
        Me.LoginBindingSource.DataMember = "login"
        Me.LoginBindingSource.DataSource = Me.SHITSTEMDataSet
        '
        'LoginTableAdapter
        '
        Me.LoginTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.DailySalesTableAdapter = Nothing
        Me.TableAdapterManager.loginTableAdapter = Me.LoginTableAdapter
        Me.TableAdapterManager.MonthlySalesTableAdapter = Nothing
        Me.TableAdapterManager.OrdersTableAdapter = Nothing
        Me.TableAdapterManager.ProductGroupsTableAdapter = Nothing
        Me.TableAdapterManager.STOCKSTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = DIMSUM_SHITSTEM.SHITSTEMDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        Me.TableAdapterManager.WeeklySalesTableAdapter = Nothing
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(233, 453)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(198, 31)
        Me.Button2.TabIndex = 18
        Me.Button2.Text = "Cancel"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(12, 453)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(198, 31)
        Me.Button1.TabIndex = 17
        Me.Button1.Text = "Save"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(69, 281)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Address:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(69, 232)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(29, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Age:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(69, 187)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Lastname:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(69, 142)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Firstname:"
        '
        'TextBox5
        '
        Me.TextBox5.Location = New System.Drawing.Point(154, 274)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(208, 20)
        Me.TextBox5.TabIndex = 4
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(154, 229)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(208, 20)
        Me.TextBox4.TabIndex = 3
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(154, 184)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(208, 20)
        Me.TextBox3.TabIndex = 2
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(154, 139)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(208, 20)
        Me.TextBox2.TabIndex = 1
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(154, 94)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(208, 20)
        Me.TextBox1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(69, 97)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Username:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(69, 324)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(61, 13)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "Phone_No:"
        '
        'TextBox6
        '
        Me.TextBox6.Location = New System.Drawing.Point(154, 317)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New System.Drawing.Size(208, 20)
        Me.TextBox6.TabIndex = 19
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(69, 371)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 13)
        Me.Label7.TabIndex = 22
        Me.Label7.Text = "Password"
        '
        'TextBox7
        '
        Me.TextBox7.Location = New System.Drawing.Point(154, 364)
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Size = New System.Drawing.Size(208, 20)
        Me.TextBox7.TabIndex = 21
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(151, 18)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(121, 13)
        Me.Label8.TabIndex = 23
        Me.Label8.Text = "SIGN UP FOR OWNER"
        '
        'Guna2BorderlessForm1
        '
        Me.Guna2BorderlessForm1.ContainerControl = Me
        Me.Guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6R
        Me.Guna2BorderlessForm1.TransparentWhileDrag = True
        '
        'Users
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(443, 581)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TextBox7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TextBox6)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBox5)
        Me.Controls.Add(Me.TextBox4)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Users"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "User Manager"
        CType(Me.SHITSTEMDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LoginBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SHITSTEMDataSet As SHITSTEMDataSet
    Friend WithEvents LoginBindingSource As BindingSource
    Friend WithEvents LoginTableAdapter As SHITSTEMDataSetTableAdapters.loginTableAdapter
    Friend WithEvents TableAdapterManager As SHITSTEMDataSetTableAdapters.TableAdapterManager
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBox5 As TextBox
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents TextBox6 As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents TextBox7 As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Guna2BorderlessForm1 As Guna.UI2.WinForms.Guna2BorderlessForm
End Class
