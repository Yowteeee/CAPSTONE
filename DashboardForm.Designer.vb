<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DashboardForm
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
        Dim CustomizableEdges1 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges2 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        PictureBox1 = New PictureBox()
        Guna2GradientButton1 = New Guna.UI2.WinForms.Guna2GradientButton()
        Guna2CheckBox1 = New Guna.UI2.WinForms.Guna2CheckBox()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = My.Resources.Resources.Screenshot_9
        PictureBox1.Location = New Point(3, 1)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(971, 583)
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.TabIndex = 0
        PictureBox1.TabStop = False
        ' 
        ' Guna2GradientButton1
        ' 
        Guna2GradientButton1.BorderRadius = 10
        Guna2GradientButton1.CustomizableEdges = CustomizableEdges1
        Guna2GradientButton1.DisabledState.BorderColor = Color.DarkGray
        Guna2GradientButton1.DisabledState.CustomBorderColor = Color.DarkGray
        Guna2GradientButton1.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        Guna2GradientButton1.DisabledState.FillColor2 = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        Guna2GradientButton1.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        Guna2GradientButton1.Font = New Font("Segoe UI", 9F)
        Guna2GradientButton1.ForeColor = Color.White
        Guna2GradientButton1.Location = New Point(246, 432)
        Guna2GradientButton1.Name = "Guna2GradientButton1"
        Guna2GradientButton1.ShadowDecoration.CustomizableEdges = CustomizableEdges2
        Guna2GradientButton1.Size = New Size(158, 128)
        Guna2GradientButton1.TabIndex = 1
        Guna2GradientButton1.Text = "Guna2GradientButton1"
        ' 
        ' Guna2CheckBox1
        ' 
        Guna2CheckBox1.AutoSize = True
        Guna2CheckBox1.CheckedState.BorderColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        Guna2CheckBox1.CheckedState.BorderRadius = 0
        Guna2CheckBox1.CheckedState.BorderThickness = 0
        Guna2CheckBox1.CheckedState.FillColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        Guna2CheckBox1.Location = New Point(190, 251)
        Guna2CheckBox1.Name = "Guna2CheckBox1"
        Guna2CheckBox1.Size = New Size(119, 19)
        Guna2CheckBox1.TabIndex = 2
        Guna2CheckBox1.Text = "Guna2CheckBox1"
        Guna2CheckBox1.UncheckedState.BorderColor = Color.FromArgb(CByte(125), CByte(137), CByte(149))
        Guna2CheckBox1.UncheckedState.BorderRadius = 0
        Guna2CheckBox1.UncheckedState.BorderThickness = 0
        Guna2CheckBox1.UncheckedState.FillColor = Color.FromArgb(CByte(125), CByte(137), CByte(149))
        ' 
        ' DashboardForm
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1081, 733)
        Controls.Add(Guna2CheckBox1)
        Controls.Add(Guna2GradientButton1)
        Controls.Add(PictureBox1)
        Name = "DashboardForm"
        Text = "Dashboard"
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Guna2GradientButton1 As Guna.UI2.WinForms.Guna2GradientButton
    Friend WithEvents Guna2CheckBox1 As Guna.UI2.WinForms.Guna2CheckBox
End Class