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
        Me.Guna2PictureBox1 = New Guna.UI2.WinForms.Guna2PictureBox()
        Me.progressbar = New Guna.UI2.WinForms.Guna2CircleProgressBar()
        CType(Me.Guna2PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.progressbar.SuspendLayout()
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 50
        '
        'Guna2PictureBox1
        '
        Me.Guna2PictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Guna2PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.Guna2PictureBox1.FillColor = System.Drawing.Color.Transparent
        Me.Guna2PictureBox1.Image = Global.DIMSUM_SHITSTEM.My.Resources.Resources.dimsum_factory_logo
        Me.Guna2PictureBox1.ImageRotate = 0!
        Me.Guna2PictureBox1.Location = New System.Drawing.Point(0, 47)
        Me.Guna2PictureBox1.Name = "Guna2PictureBox1"
        Me.Guna2PictureBox1.Size = New System.Drawing.Size(232, 134)
        Me.Guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Guna2PictureBox1.TabIndex = 0
        Me.Guna2PictureBox1.TabStop = False
        Me.Guna2PictureBox1.UseTransparentBackground = True
        '
        'progressbar
        '
        Me.progressbar.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.progressbar.Controls.Add(Me.Guna2PictureBox1)
        Me.progressbar.FillColor = System.Drawing.Color.White
        Me.progressbar.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.progressbar.ForeColor = System.Drawing.Color.White
        Me.progressbar.Location = New System.Drawing.Point(132, 127)
        Me.progressbar.Minimum = 0
        Me.progressbar.Name = "progressbar"
        Me.progressbar.ProgressBrushMode = Guna.UI2.WinForms.Enums.BrushMode.SolidTransition
        Me.progressbar.ProgressColor = System.Drawing.Color.Yellow
        Me.progressbar.ProgressColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.progressbar.ProgressEndCap = System.Drawing.Drawing2D.LineCap.Round
        Me.progressbar.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle
        Me.progressbar.Size = New System.Drawing.Size(232, 232)
        Me.progressbar.TabIndex = 2
        Me.progressbar.Text = "Guna2CircleProgressBar1"
        Me.progressbar.TextMode = Guna.UI2.WinForms.Enums.ProgressBarTextMode.Value
        '
        'loadingscreen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.progressbar)
        Me.DoubleBuffered = True
        Me.Name = "loadingscreen"
        Me.Size = New System.Drawing.Size(528, 545)
        CType(Me.Guna2PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.progressbar.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Timer1 As Timer
    Friend WithEvents Guna2PictureBox1 As Guna.UI2.WinForms.Guna2PictureBox
    Friend WithEvents progressbar As Guna.UI2.WinForms.Guna2CircleProgressBar
End Class
