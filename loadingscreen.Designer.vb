<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class loadingscreen
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
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.progressbar = New Guna.UI2.WinForms.Guna2CircleProgressBar()
        Me.Guna2PictureBox1 = New Guna.UI2.WinForms.Guna2PictureBox()
        Me.progressbar.SuspendLayout()
        CType(Me.Guna2PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 50
        '
        'progressbar
        '
        Me.progressbar.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.progressbar.BackColor = System.Drawing.Color.Transparent
        Me.progressbar.Controls.Add(Me.Guna2PictureBox1)
        Me.progressbar.FillColor = System.Drawing.Color.Yellow
        Me.progressbar.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.progressbar.ForeColor = System.Drawing.Color.Red
        Me.progressbar.Location = New System.Drawing.Point(574, 119)
        Me.progressbar.Margin = New System.Windows.Forms.Padding(4)
        Me.progressbar.Minimum = 0
        Me.progressbar.Name = "progressbar"
        Me.progressbar.ProgressBrushMode = Guna.UI2.WinForms.Enums.BrushMode.SolidTransition
        Me.progressbar.ProgressColor = System.Drawing.Color.Yellow
        Me.progressbar.ProgressColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.progressbar.ProgressEndCap = System.Drawing.Drawing2D.LineCap.Round
        Me.progressbar.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle
        Me.progressbar.Size = New System.Drawing.Size(452, 452)
        Me.progressbar.TabIndex = 2
        Me.progressbar.Text = "Guna2CircleProgressBar1"
        Me.progressbar.TextMode = Guna.UI2.WinForms.Enums.ProgressBarTextMode.Value
        '
        'Guna2PictureBox1
        '
        Me.Guna2PictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Guna2PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.Guna2PictureBox1.FillColor = System.Drawing.Color.Transparent
        Me.Guna2PictureBox1.Image = Global.DIMSUM_SHITSTEM.My.Resources.Resources.dimsum_factory_logo
        Me.Guna2PictureBox1.ImageRotate = 0!
        Me.Guna2PictureBox1.Location = New System.Drawing.Point(100, 146)
        Me.Guna2PictureBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.Guna2PictureBox1.Name = "Guna2PictureBox1"
        Me.Guna2PictureBox1.Size = New System.Drawing.Size(307, 165)
        Me.Guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Guna2PictureBox1.TabIndex = 0
        Me.Guna2PictureBox1.TabStop = False
        Me.Guna2PictureBox1.UseTransparentBackground = True
        '
        'loadingscreen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Yellow
        Me.Controls.Add(Me.progressbar)
        Me.DoubleBuffered = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "loadingscreen"
        Me.Size = New System.Drawing.Size(1847, 804)
        Me.progressbar.ResumeLayout(False)
        CType(Me.Guna2PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Timer1 As Timer
    Friend WithEvents Guna2PictureBox1 As Guna.UI2.WinForms.Guna2PictureBox
    Friend WithEvents progressbar As Guna.UI2.WinForms.Guna2CircleProgressBar
End Class
