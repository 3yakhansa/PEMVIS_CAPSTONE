<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class LoginForm
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        PanelHeader = New Panel()
        lblLogin = New Label()
        lblSubtitle = New Label()
        PanelBody = New Panel()
        lblUsername = New Label()
        txtUsername = New TextBox()
        lblPassword = New Label()
        txtPassword = New TextBox()
        btnLogin = New Button()
        lblFooter = New Label()
        PanelHeader.SuspendLayout()
        PanelBody.SuspendLayout()
        SuspendLayout()
        ' 
        ' PanelHeader
        ' 
        PanelHeader.BackColor = Color.FromArgb(CByte(102), CByte(187), CByte(187))
        PanelHeader.Controls.Add(lblLogin)
        PanelHeader.Controls.Add(lblSubtitle)
        PanelHeader.Dock = DockStyle.Top
        PanelHeader.Location = New Point(0, 0)
        PanelHeader.Margin = New Padding(4, 4, 4, 4)
        PanelHeader.Name = "PanelHeader"
        PanelHeader.Size = New Size(500, 125)
        PanelHeader.TabIndex = 0
        ' 
        ' lblLogin
        ' 
        lblLogin.AutoSize = True
        lblLogin.Font = New Font("Segoe UI", 18.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblLogin.ForeColor = Color.White
        lblLogin.Location = New Point(25, 22)
        lblLogin.Margin = New Padding(4, 0, 4, 0)
        lblLogin.Name = "lblLogin"
        lblLogin.Size = New Size(413, 48)
        lblLogin.TabIndex = 0
        lblLogin.Text = "Sistem Nilai Mahasiswa"
        ' 
        ' lblSubtitle
        ' 
        lblSubtitle.AutoSize = True
        lblSubtitle.Font = New Font("Segoe UI", 9.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblSubtitle.ForeColor = Color.FromArgb(CByte(220), CByte(245), CByte(245))
        lblSubtitle.Location = New Point(28, 78)
        lblSubtitle.Margin = New Padding(4, 0, 4, 0)
        lblSubtitle.Name = "lblSubtitle"
        lblSubtitle.Size = New Size(285, 25)
        lblSubtitle.TabIndex = 1
        lblSubtitle.Text = "Silahkan masuk untuk melanjutkan"
        ' 
        ' PanelBody
        ' 
        PanelBody.BackColor = Color.FromArgb(CByte(240), CByte(248), CByte(248))
        PanelBody.Controls.Add(lblUsername)
        PanelBody.Controls.Add(txtUsername)
        PanelBody.Controls.Add(lblPassword)
        PanelBody.Controls.Add(txtPassword)
        PanelBody.Controls.Add(btnLogin)
        PanelBody.Controls.Add(lblFooter)
        PanelBody.Dock = DockStyle.Fill
        PanelBody.Location = New Point(0, 125)
        PanelBody.Margin = New Padding(4, 4, 4, 4)
        PanelBody.Name = "PanelBody"
        PanelBody.Padding = New Padding(38, 31, 38, 25)
        PanelBody.Size = New Size(500, 350)
        PanelBody.TabIndex = 1
        ' 
        ' lblUsername
        ' 
        lblUsername.AutoSize = True
        lblUsername.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblUsername.ForeColor = Color.FromArgb(CByte(74), CByte(124), CByte(124))
        lblUsername.Location = New Point(38, 38)
        lblUsername.Margin = New Padding(4, 0, 4, 0)
        lblUsername.Name = "lblUsername"
        lblUsername.Size = New Size(97, 25)
        lblUsername.TabIndex = 0
        lblUsername.Text = "Username"
        ' 
        ' txtUsername
        ' 
        txtUsername.BorderStyle = BorderStyle.FixedSingle
        txtUsername.Font = New Font("Segoe UI", 10.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtUsername.Location = New Point(38, 65)
        txtUsername.Margin = New Padding(4, 4, 4, 4)
        txtUsername.Name = "txtUsername"
        txtUsername.PlaceholderText = "Masukkan username..."
        txtUsername.Size = New Size(424, 34)
        txtUsername.TabIndex = 1
        ' 
        ' lblPassword
        ' 
        lblPassword.AutoSize = True
        lblPassword.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblPassword.ForeColor = Color.FromArgb(CByte(74), CByte(124), CByte(124))
        lblPassword.Location = New Point(38, 125)
        lblPassword.Margin = New Padding(4, 0, 4, 0)
        lblPassword.Name = "lblPassword"
        lblPassword.Size = New Size(92, 25)
        lblPassword.TabIndex = 2
        lblPassword.Text = "Password"
        ' 
        ' txtPassword
        ' 
        txtPassword.BorderStyle = BorderStyle.FixedSingle
        txtPassword.Font = New Font("Segoe UI", 10.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtPassword.Location = New Point(38, 152)
        txtPassword.Margin = New Padding(4, 4, 4, 4)
        txtPassword.Name = "txtPassword"
        txtPassword.PasswordChar = "*"c
        txtPassword.PlaceholderText = "Masukkan password..."
        txtPassword.Size = New Size(424, 34)
        txtPassword.TabIndex = 3
        txtPassword.UseSystemPasswordChar = True
        ' 
        ' btnLogin
        ' 
        btnLogin.BackColor = Color.FromArgb(CByte(74), CByte(124), CByte(124))
        btnLogin.Cursor = Cursors.Hand
        btnLogin.FlatAppearance.BorderSize = 0
        btnLogin.FlatAppearance.MouseDownBackColor = Color.FromArgb(CByte(54), CByte(104), CByte(104))
        btnLogin.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(94), CByte(144), CByte(144))
        btnLogin.FlatStyle = FlatStyle.Flat
        btnLogin.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnLogin.ForeColor = Color.White
        btnLogin.Location = New Point(38, 219)
        btnLogin.Margin = New Padding(4, 4, 4, 4)
        btnLogin.Name = "btnLogin"
        btnLogin.Size = New Size(425, 52)
        btnLogin.TabIndex = 4
        btnLogin.Text = "MASUK"
        btnLogin.UseVisualStyleBackColor = False
        ' 
        ' lblFooter
        ' 
        lblFooter.AutoSize = True
        lblFooter.Font = New Font("Segoe UI", 8.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblFooter.ForeColor = Color.Gray
        lblFooter.Location = New Point(38, 290)
        lblFooter.Margin = New Padding(4, 0, 4, 0)
        lblFooter.Name = "lblFooter"
        lblFooter.Size = New Size(182, 21)
        lblFooter.TabIndex = 5
        lblFooter.Text = "© 2025 Sistem Nilai XYZ"
        ' 
        ' LoginForm
        ' 
        AutoScaleDimensions = New SizeF(10.0F, 25.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(500, 475)
        Controls.Add(PanelBody)
        Controls.Add(PanelHeader)
        FormBorderStyle = FormBorderStyle.FixedSingle
        KeyPreview = True
        Margin = New Padding(4, 4, 4, 4)
        MaximizeBox = False
        Name = "LoginForm"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Login - Sistem Nilai Mahasiswa"
        PanelHeader.ResumeLayout(False)
        PanelHeader.PerformLayout()
        PanelBody.ResumeLayout(False)
        PanelBody.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents PanelHeader As Panel
    Friend WithEvents lblLogin As Label
    Friend WithEvents lblSubtitle As Label
    Friend WithEvents PanelBody As Panel
    Friend WithEvents lblUsername As Label
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents lblPassword As Label
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents btnLogin As Button
    Friend WithEvents lblFooter As Label

End Class