<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form2))
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.SHITSTEMDataSet = New DIMSUM_SHITSTEM.SHITSTEMDataSet()
        Me.LoginBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Guna2BorderlessLOGIN_PAGE = New Guna.UI2.WinForms.Guna2BorderlessForm(Me.components)
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Guna2ControlBox1 = New Guna.UI2.WinForms.Guna2ControlBox()
        Me.Guna2ControlBox2 = New Guna.UI2.WinForms.Guna2ControlBox()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.logoutbtn = New Guna.UI2.WinForms.Guna2Button()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.salesbtn = New Guna.UI2.WinForms.Guna2Button()
        Me.cashierbtn = New Guna.UI2.WinForms.Guna2Button()
        Me.employeebtn = New Guna.UI2.WinForms.Guna2Button()
        Me.productbtn = New Guna.UI2.WinForms.Guna2Button()
        Me.Guna2Panel1 = New Guna.UI2.WinForms.Guna2Panel()
        Me.profilepic = New Guna.UI2.WinForms.Guna2CirclePictureBox()
        Me.Guna2HtmlLabel1 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        CType(Me.SHITSTEMDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LoginBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Guna2Panel1.SuspendLayout()
        CType(Me.profilepic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("ITC Kabel", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(10, 6)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(132, 22)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "HELLO OWNER:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("ITC Kabel", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(86, 54)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 20)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Label3"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("ITC Kabel", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(307, 8)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 28)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Label1"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Font = New System.Drawing.Font("ITC Kabel", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker1.Location = New System.Drawing.Point(7, 9)
        Me.DateTimePicker1.Margin = New System.Windows.Forms.Padding(4)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(262, 25)
        Me.DateTimePicker1.TabIndex = 2
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
        'Timer1
        '
        '
        'Guna2BorderlessLOGIN_PAGE
        '
        Me.Guna2BorderlessLOGIN_PAGE.ContainerControl = Me
        Me.Guna2BorderlessLOGIN_PAGE.DockIndicatorTransparencyValue = 0.6R
        Me.Guna2BorderlessLOGIN_PAGE.TransparentWhileDrag = True
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.Panel4.Controls.Add(Me.Label1)
        Me.Panel4.Controls.Add(Me.Guna2ControlBox1)
        Me.Panel4.Controls.Add(Me.Guna2ControlBox2)
        Me.Panel4.Controls.Add(Me.DateTimePicker1)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1244, 48)
        Me.Panel4.TabIndex = 3
        '
        'Guna2ControlBox1
        '
        Me.Guna2ControlBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Guna2ControlBox1.FillColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Guna2ControlBox1.HoverState.FillColor = System.Drawing.Color.Red
        Me.Guna2ControlBox1.IconColor = System.Drawing.Color.Black
        Me.Guna2ControlBox1.Location = New System.Drawing.Point(1187, 0)
        Me.Guna2ControlBox1.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.Guna2ControlBox1.Name = "Guna2ControlBox1"
        Me.Guna2ControlBox1.Size = New System.Drawing.Size(57, 48)
        Me.Guna2ControlBox1.TabIndex = 0
        '
        'Guna2ControlBox2
        '
        Me.Guna2ControlBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Guna2ControlBox2.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox
        Me.Guna2ControlBox2.FillColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.Guna2ControlBox2.HoverState.FillColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Guna2ControlBox2.IconColor = System.Drawing.Color.Black
        Me.Guna2ControlBox2.Location = New System.Drawing.Point(1121, 0)
        Me.Guna2ControlBox2.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.Guna2ControlBox2.Name = "Guna2ControlBox2"
        Me.Guna2ControlBox2.Size = New System.Drawing.Size(60, 48)
        Me.Guna2ControlBox2.TabIndex = 1
        '
        'SplitContainer1
        '
        Me.SplitContainer1.AllowDrop = True
        Me.SplitContainer1.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 48)
        Me.SplitContainer1.Margin = New System.Windows.Forms.Padding(4)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.SplitContainer1.Panel1.Controls.Add(Me.logoutbtn)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TableLayoutPanel1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.SplitContainer1.Panel2.Controls.Add(Me.Guna2HtmlLabel1)
        Me.SplitContainer1.Size = New System.Drawing.Size(1244, 571)
        Me.SplitContainer1.SplitterDistance = 200
        Me.SplitContainer1.SplitterWidth = 5
        Me.SplitContainer1.TabIndex = 5
        '
        'logoutbtn
        '
        Me.logoutbtn.Animated = True
        Me.logoutbtn.BackColor = System.Drawing.Color.Transparent
        Me.logoutbtn.BorderRadius = 15
        Me.logoutbtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.logoutbtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.logoutbtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.logoutbtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.logoutbtn.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.logoutbtn.FillColor = System.Drawing.Color.Transparent
        Me.logoutbtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.logoutbtn.ForeColor = System.Drawing.Color.Red
        Me.logoutbtn.HoverState.FillColor = System.Drawing.Color.Red
        Me.logoutbtn.HoverState.ForeColor = System.Drawing.Color.White
        Me.logoutbtn.IndicateFocus = True
        Me.logoutbtn.Location = New System.Drawing.Point(0, 517)
        Me.logoutbtn.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.logoutbtn.Name = "logoutbtn"
        Me.logoutbtn.Size = New System.Drawing.Size(200, 54)
        Me.logoutbtn.TabIndex = 4
        Me.logoutbtn.Text = "LOGOUT"
        Me.logoutbtn.TextTransform = Guna.UI2.WinForms.Enums.TextTransform.UpperCase
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.salesbtn, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cashierbtn, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.employeebtn, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.productbtn, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Guna2Panel1, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(4)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 5
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.85549!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.91908!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.05202!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(200, 426)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'salesbtn
        '
        Me.salesbtn.Animated = True
        Me.salesbtn.BorderRadius = 4
        Me.salesbtn.BorderThickness = 1
        Me.salesbtn.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton
        Me.salesbtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.salesbtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.salesbtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.salesbtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.salesbtn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.salesbtn.FillColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.salesbtn.Font = New System.Drawing.Font("ITC Kabel", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.salesbtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.salesbtn.Image = Global.DIMSUM_SHITSTEM.My.Resources.Resources.bar_chart
        Me.salesbtn.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.salesbtn.ImageSize = New System.Drawing.Size(50, 50)
        Me.salesbtn.IndicateFocus = True
        Me.salesbtn.Location = New System.Drawing.Point(7, 112)
        Me.salesbtn.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.salesbtn.Name = "salesbtn"
        Me.salesbtn.Size = New System.Drawing.Size(186, 64)
        Me.salesbtn.TabIndex = 1
        Me.salesbtn.Text = "DASHBOARD"
        Me.salesbtn.TextOffset = New System.Drawing.Point(30, 0)
        '
        'cashierbtn
        '
        Me.cashierbtn.Animated = True
        Me.cashierbtn.BorderRadius = 4
        Me.cashierbtn.BorderThickness = 1
        Me.cashierbtn.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton
        Me.cashierbtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.cashierbtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.cashierbtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.cashierbtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.cashierbtn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cashierbtn.FillColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.cashierbtn.Font = New System.Drawing.Font("ITC Kabel", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cashierbtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.cashierbtn.IndicateFocus = True
        Me.cashierbtn.Location = New System.Drawing.Point(7, 345)
        Me.cashierbtn.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.cashierbtn.Name = "cashierbtn"
        Me.cashierbtn.Size = New System.Drawing.Size(186, 75)
        Me.cashierbtn.TabIndex = 3
        Me.cashierbtn.Text = "CASHIER"
        '
        'employeebtn
        '
        Me.employeebtn.Animated = True
        Me.employeebtn.BorderRadius = 4
        Me.employeebtn.BorderThickness = 1
        Me.employeebtn.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton
        Me.employeebtn.Checked = True
        Me.employeebtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.employeebtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.employeebtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.employeebtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.employeebtn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.employeebtn.FillColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.employeebtn.Font = New System.Drawing.Font("ITC Kabel", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.employeebtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.employeebtn.IndicateFocus = True
        Me.employeebtn.Location = New System.Drawing.Point(7, 260)
        Me.employeebtn.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.employeebtn.Name = "employeebtn"
        Me.employeebtn.Size = New System.Drawing.Size(186, 73)
        Me.employeebtn.TabIndex = 2
        Me.employeebtn.Text = "EMPLOYEES"
        '
        'productbtn
        '
        Me.productbtn.Animated = True
        Me.productbtn.BackColor = System.Drawing.Color.Transparent
        Me.productbtn.BorderRadius = 4
        Me.productbtn.BorderThickness = 1
        Me.productbtn.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton
        Me.productbtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.productbtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.productbtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.productbtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.productbtn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.productbtn.FillColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.productbtn.Font = New System.Drawing.Font("ITC Kabel", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.productbtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.productbtn.Image = Global.DIMSUM_SHITSTEM.My.Resources.Resources.producticon
        Me.productbtn.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.productbtn.ImageSize = New System.Drawing.Size(50, 50)
        Me.productbtn.IndicateFocus = True
        Me.productbtn.Location = New System.Drawing.Point(7, 188)
        Me.productbtn.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.productbtn.Name = "productbtn"
        Me.productbtn.Size = New System.Drawing.Size(186, 60)
        Me.productbtn.TabIndex = 0
        Me.productbtn.Text = "PRODUCT"
        Me.productbtn.TextOffset = New System.Drawing.Point(20, 0)
        '
        'Guna2Panel1
        '
        Me.Guna2Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Guna2Panel1.BorderColor = System.Drawing.Color.Black
        Me.Guna2Panel1.BorderRadius = 6
        Me.Guna2Panel1.BorderThickness = 2
        Me.Guna2Panel1.Controls.Add(Me.Label2)
        Me.Guna2Panel1.Controls.Add(Me.Label3)
        Me.Guna2Panel1.Controls.Add(Me.profilepic)
        Me.Guna2Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Guna2Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Guna2Panel1.Name = "Guna2Panel1"
        Me.Guna2Panel1.Size = New System.Drawing.Size(194, 100)
        Me.Guna2Panel1.TabIndex = 4
        '
        'profilepic
        '
        Me.profilepic.ImageRotate = 0!
        Me.profilepic.Location = New System.Drawing.Point(10, 34)
        Me.profilepic.Margin = New System.Windows.Forms.Padding(4)
        Me.profilepic.Name = "profilepic"
        Me.profilepic.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle
        Me.profilepic.Size = New System.Drawing.Size(68, 62)
        Me.profilepic.TabIndex = 1
        Me.profilepic.TabStop = False
        '
        'Guna2HtmlLabel1
        '
        Me.Guna2HtmlLabel1.AutoSize = False
        Me.Guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel1.ForeColor = System.Drawing.Color.Yellow
        Me.Guna2HtmlLabel1.Location = New System.Drawing.Point(359, 261)
        Me.Guna2HtmlLabel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Guna2HtmlLabel1.Name = "Guna2HtmlLabel1"
        Me.Guna2HtmlLabel1.Size = New System.Drawing.Size(313, 44)
        Me.Guna2HtmlLabel1.TabIndex = 0
        Me.Guna2HtmlLabel1.Text = "DIMSUM FACTORY"
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1244, 619)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.Panel4)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MinimizeBox = False
        Me.Name = "Form2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " "
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.SHITSTEMDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LoginBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Guna2Panel1.ResumeLayout(False)
        Me.Guna2Panel1.PerformLayout()
        CType(Me.profilepic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents SHITSTEMDataSet As SHITSTEMDataSet
    Friend WithEvents LoginBindingSource As BindingSource
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Guna2BorderlessLOGIN_PAGE As Guna.UI2.WinForms.Guna2BorderlessForm
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Guna2ControlBox2 As Guna.UI2.WinForms.Guna2ControlBox
    Friend WithEvents Guna2ControlBox1 As Guna.UI2.WinForms.Guna2ControlBox
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents logoutbtn As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents cashierbtn As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents employeebtn As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents salesbtn As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents productbtn As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents profilepic As Guna.UI2.WinForms.Guna2CirclePictureBox
    Friend WithEvents Guna2HtmlLabel1 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents Guna2Panel1 As Guna.UI2.WinForms.Guna2Panel
End Class
