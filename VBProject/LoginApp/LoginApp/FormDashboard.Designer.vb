<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormDashboard
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
        lblWelcome = New Label()
        lblLevel = New Label()
        btnLogout = New Button()
        SuspendLayout()
        ' 
        ' lblWelcome
        ' 
        lblWelcome.AutoSize = True
        lblWelcome.Location = New Point(30, 38)
        lblWelcome.Name = "lblWelcome"
        lblWelcome.Size = New Size(142, 15)
        lblWelcome.TabIndex = 0
        lblWelcome.Text = "Selamat Datang (✿◠‿◠)"
        ' 
        ' lblLevel
        ' 
        lblLevel.AutoSize = True
        lblLevel.Location = New Point(30, 104)
        lblLevel.Name = "lblLevel"
        lblLevel.Size = New Size(41, 15)
        lblLevel.TabIndex = 1
        lblLevel.Text = "Label2"
        ' 
        ' btnLogout
        ' 
        btnLogout.Location = New Point(30, 171)
        btnLogout.Name = "btnLogout"
        btnLogout.Size = New Size(75, 23)
        btnLogout.TabIndex = 2
        btnLogout.Text = "Logout"
        btnLogout.UseVisualStyleBackColor = True
        ' 
        ' FormDashboard
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(btnLogout)
        Controls.Add(lblLevel)
        Controls.Add(lblWelcome)
        Name = "FormDashboard"
        Text = "FormDashboard"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblWelcome As Label
    Friend WithEvents lblLevel As Label
    Friend WithEvents btnLogout As Button
End Class
