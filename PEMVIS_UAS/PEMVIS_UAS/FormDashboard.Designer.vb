<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormDashboard
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
        lblWelcome = New Label()
        lblLevel = New Label()
        PanelSidebar = New Panel()
        lblMenu = New Label()
        btnDataUser = New Button()
        btnDataMahasiswa = New Button()
        btnMataKuliah = New Button()
        btnInputNilai = New Button()
        btnLogAktivitas = New Button()
        btnReportNilai = New Button()
        btnReportLog = New Button()
        PanelDivider = New Panel()
        btnLogout = New Button()
        PanelContent = New Panel()
        lblContentTitle = New Label()
        lblContentDesc = New Label()
        PanelHeader.SuspendLayout()
        PanelSidebar.SuspendLayout()
        PanelContent.SuspendLayout()
        SuspendLayout()

        ' ── PanelHeader ──────────────────────────────────────────
        PanelHeader.BackColor = Color.FromArgb(CByte(102), CByte(187), CByte(187))
        PanelHeader.Controls.Add(lblWelcome)
        PanelHeader.Controls.Add(lblLevel)
        PanelHeader.Dock = DockStyle.Top
        PanelHeader.Location = New Point(0, 0)
        PanelHeader.Name = "PanelHeader"
        PanelHeader.Size = New Size(1000, 70)
        PanelHeader.TabIndex = 0

        lblWelcome.AutoSize = True
        lblWelcome.Font = New Font("Segoe UI", 16.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblWelcome.ForeColor = Color.White
        lblWelcome.Location = New Point(20, 12)
        lblWelcome.Name = "lblWelcome"
        lblWelcome.TabIndex = 0
        lblWelcome.Text = "Selamat Datang"

        lblLevel.AutoSize = True
        lblLevel.Font = New Font("Segoe UI", 9.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblLevel.ForeColor = Color.FromArgb(CByte(220), CByte(245), CByte(245))
        lblLevel.Location = New Point(22, 46)
        lblLevel.Name = "lblLevel"
        lblLevel.TabIndex = 1
        lblLevel.Text = "Role: -"

        ' ── PanelSidebar ─────────────────────────────────────────
        PanelSidebar.BackColor = Color.FromArgb(CByte(42), CByte(82), CByte(82))
        PanelSidebar.Controls.Add(lblMenu)
        PanelSidebar.Controls.Add(btnDataUser)
        PanelSidebar.Controls.Add(btnDataMahasiswa)
        PanelSidebar.Controls.Add(btnMataKuliah)
        PanelSidebar.Controls.Add(btnInputNilai)
        PanelSidebar.Controls.Add(btnLogAktivitas)
        PanelSidebar.Controls.Add(btnReportNilai)
        PanelSidebar.Controls.Add(btnReportLog)
        PanelSidebar.Controls.Add(PanelDivider)
        PanelSidebar.Controls.Add(btnLogout)
        PanelSidebar.Dock = DockStyle.Left
        PanelSidebar.Location = New Point(0, 70)
        PanelSidebar.Name = "PanelSidebar"
        PanelSidebar.Size = New Size(220, 580)
        PanelSidebar.TabIndex = 1

        lblMenu.AutoSize = True
        lblMenu.Font = New Font("Segoe UI", 8.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblMenu.ForeColor = Color.FromArgb(CByte(150), CByte(210), CByte(210))
        lblMenu.Location = New Point(18, 18)
        lblMenu.Name = "lblMenu"
        lblMenu.TabIndex = 0
        lblMenu.Text = "MENU UTAMA"

        ' Helper: shared sidebar button style applied below per button
        ' btnDataUser
        btnDataUser.BackColor = Color.Transparent
        btnDataUser.FlatAppearance.BorderSize = 0
        btnDataUser.FlatAppearance.MouseDownBackColor = Color.FromArgb(CByte(74), CByte(124), CByte(124))
        btnDataUser.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(60), CByte(110), CByte(110))
        btnDataUser.FlatStyle = FlatStyle.Flat
        btnDataUser.Font = New Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnDataUser.ForeColor = Color.White
        btnDataUser.Location = New Point(0, 50)
        btnDataUser.Name = "btnDataUser"
        btnDataUser.Size = New Size(220, 42)
        btnDataUser.TabIndex = 1
        btnDataUser.Text = "  👤  Data User"
        btnDataUser.TextAlign = ContentAlignment.MiddleLeft
        btnDataUser.UseVisualStyleBackColor = False
        btnDataUser.Cursor = Cursors.Hand

        btnDataMahasiswa.BackColor = Color.Transparent
        btnDataMahasiswa.FlatAppearance.BorderSize = 0
        btnDataMahasiswa.FlatAppearance.MouseDownBackColor = Color.FromArgb(CByte(74), CByte(124), CByte(124))
        btnDataMahasiswa.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(60), CByte(110), CByte(110))
        btnDataMahasiswa.FlatStyle = FlatStyle.Flat
        btnDataMahasiswa.Font = New Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnDataMahasiswa.ForeColor = Color.White
        btnDataMahasiswa.Location = New Point(0, 92)
        btnDataMahasiswa.Name = "btnDataMahasiswa"
        btnDataMahasiswa.Size = New Size(220, 42)
        btnDataMahasiswa.TabIndex = 2
        btnDataMahasiswa.Text = "  🎓  Data Mahasiswa"
        btnDataMahasiswa.TextAlign = ContentAlignment.MiddleLeft
        btnDataMahasiswa.UseVisualStyleBackColor = False
        btnDataMahasiswa.Cursor = Cursors.Hand

        btnMataKuliah.BackColor = Color.Transparent
        btnMataKuliah.FlatAppearance.BorderSize = 0
        btnMataKuliah.FlatAppearance.MouseDownBackColor = Color.FromArgb(CByte(74), CByte(124), CByte(124))
        btnMataKuliah.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(60), CByte(110), CByte(110))
        btnMataKuliah.FlatStyle = FlatStyle.Flat
        btnMataKuliah.Font = New Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnMataKuliah.ForeColor = Color.White
        btnMataKuliah.Location = New Point(0, 134)
        btnMataKuliah.Name = "btnMataKuliah"
        btnMataKuliah.Size = New Size(220, 42)
        btnMataKuliah.TabIndex = 3
        btnMataKuliah.Text = "  📚  Data Mata Kuliah"
        btnMataKuliah.TextAlign = ContentAlignment.MiddleLeft
        btnMataKuliah.UseVisualStyleBackColor = False
        btnMataKuliah.Cursor = Cursors.Hand

        btnInputNilai.BackColor = Color.Transparent
        btnInputNilai.FlatAppearance.BorderSize = 0
        btnInputNilai.FlatAppearance.MouseDownBackColor = Color.FromArgb(CByte(74), CByte(124), CByte(124))
        btnInputNilai.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(60), CByte(110), CByte(110))
        btnInputNilai.FlatStyle = FlatStyle.Flat
        btnInputNilai.Font = New Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnInputNilai.ForeColor = Color.White
        btnInputNilai.Location = New Point(0, 176)
        btnInputNilai.Name = "btnInputNilai"
        btnInputNilai.Size = New Size(220, 42)
        btnInputNilai.TabIndex = 4
        btnInputNilai.Text = "  ✏️  Input Nilai"
        btnInputNilai.TextAlign = ContentAlignment.MiddleLeft
        btnInputNilai.UseVisualStyleBackColor = False
        btnInputNilai.Cursor = Cursors.Hand

        btnLogAktivitas.BackColor = Color.Transparent
        btnLogAktivitas.FlatAppearance.BorderSize = 0
        btnLogAktivitas.FlatAppearance.MouseDownBackColor = Color.FromArgb(CByte(74), CByte(124), CByte(124))
        btnLogAktivitas.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(60), CByte(110), CByte(110))
        btnLogAktivitas.FlatStyle = FlatStyle.Flat
        btnLogAktivitas.Font = New Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnLogAktivitas.ForeColor = Color.White
        btnLogAktivitas.Location = New Point(0, 218)
        btnLogAktivitas.Name = "btnLogAktivitas"
        btnLogAktivitas.Size = New Size(220, 42)
        btnLogAktivitas.TabIndex = 5
        btnLogAktivitas.Text = "  📋  Log Aktivitas"
        btnLogAktivitas.TextAlign = ContentAlignment.MiddleLeft
        btnLogAktivitas.UseVisualStyleBackColor = False
        btnLogAktivitas.Cursor = Cursors.Hand

        btnReportNilai.BackColor = Color.Transparent
        btnReportNilai.FlatAppearance.BorderSize = 0
        btnReportNilai.FlatAppearance.MouseDownBackColor = Color.FromArgb(CByte(74), CByte(124), CByte(124))
        btnReportNilai.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(60), CByte(110), CByte(110))
        btnReportNilai.FlatStyle = FlatStyle.Flat
        btnReportNilai.Font = New Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnReportNilai.ForeColor = Color.White
        btnReportNilai.Location = New Point(0, 260)
        btnReportNilai.Name = "btnReportNilai"
        btnReportNilai.Size = New Size(220, 42)
        btnReportNilai.TabIndex = 6
        btnReportNilai.Text = "  📊  Report Nilai"
        btnReportNilai.TextAlign = ContentAlignment.MiddleLeft
        btnReportNilai.UseVisualStyleBackColor = False
        btnReportNilai.Cursor = Cursors.Hand

        btnReportLog.BackColor = Color.Transparent
        btnReportLog.FlatAppearance.BorderSize = 0
        btnReportLog.FlatAppearance.MouseDownBackColor = Color.FromArgb(CByte(74), CByte(124), CByte(124))
        btnReportLog.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(60), CByte(110), CByte(110))
        btnReportLog.FlatStyle = FlatStyle.Flat
        btnReportLog.Font = New Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnReportLog.ForeColor = Color.White
        btnReportLog.Location = New Point(0, 302)
        btnReportLog.Name = "btnReportLog"
        btnReportLog.Size = New Size(220, 42)
        btnReportLog.TabIndex = 7
        btnReportLog.Text = "  🗒️  Report Log"
        btnReportLog.TextAlign = ContentAlignment.MiddleLeft
        btnReportLog.UseVisualStyleBackColor = False
        btnReportLog.Cursor = Cursors.Hand

        ' Divider line
        PanelDivider.BackColor = Color.FromArgb(CByte(74), CByte(124), CByte(124))
        PanelDivider.Location = New Point(15, 490)
        PanelDivider.Name = "PanelDivider"
        PanelDivider.Size = New Size(190, 1)
        PanelDivider.TabIndex = 8

        ' btnLogout
        btnLogout.BackColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        btnLogout.FlatAppearance.BorderSize = 0
        btnLogout.FlatAppearance.MouseDownBackColor = Color.FromArgb(CByte(160), CByte(0), CByte(0))
        btnLogout.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(210), CByte(30), CByte(30))
        btnLogout.FlatStyle = FlatStyle.Flat
        btnLogout.Font = New Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnLogout.ForeColor = Color.White
        btnLogout.Location = New Point(15, 500)
        btnLogout.Name = "btnLogout"
        btnLogout.Size = New Size(190, 42)
        btnLogout.TabIndex = 9
        btnLogout.Text = "🚪  Logout"
        btnLogout.TextAlign = ContentAlignment.MiddleLeft
        btnLogout.UseVisualStyleBackColor = False
        btnLogout.Cursor = Cursors.Hand

        ' ── PanelContent ─────────────────────────────────────────
        PanelContent.BackColor = Color.FromArgb(CByte(245), CByte(252), CByte(252))
        PanelContent.Controls.Add(lblContentTitle)
        PanelContent.Controls.Add(lblContentDesc)
        PanelContent.Dock = DockStyle.Fill
        PanelContent.Location = New Point(220, 70)
        PanelContent.Name = "PanelContent"
        PanelContent.Padding = New Padding(30)
        PanelContent.Size = New Size(780, 580)
        PanelContent.TabIndex = 2

        lblContentTitle.AutoSize = True
        lblContentTitle.Font = New Font("Segoe UI", 20.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblContentTitle.ForeColor = Color.FromArgb(CByte(74), CByte(124), CByte(124))
        lblContentTitle.Location = New Point(30, 40)
        lblContentTitle.Name = "lblContentTitle"
        lblContentTitle.TabIndex = 0
        lblContentTitle.Text = "Dashboard"

        lblContentDesc.AutoSize = True
        lblContentDesc.Font = New Font("Segoe UI", 10.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblContentDesc.ForeColor = Color.Gray
        lblContentDesc.Location = New Point(32, 82)
        lblContentDesc.Name = "lblContentDesc"
        lblContentDesc.TabIndex = 1
        lblContentDesc.Text = "Pilih menu di sebelah kiri untuk memulai."

        ' ── FormDashboard ────────────────────────────────────────
        AutoScaleDimensions = New SizeF(8.0F, 20.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(1000, 650)
        Controls.Add(PanelContent)
        Controls.Add(PanelSidebar)
        Controls.Add(PanelHeader)
        FormBorderStyle = FormBorderStyle.None
        Name = "FormDashboard"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Dashboard - Sistem Nilai XYZ"
        PanelHeader.ResumeLayout(False)
        PanelHeader.PerformLayout()
        PanelSidebar.ResumeLayout(False)
        PanelSidebar.PerformLayout()
        PanelContent.ResumeLayout(False)
        PanelContent.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents PanelHeader As Panel
    Friend WithEvents lblWelcome As Label
    Friend WithEvents lblLevel As Label
    Friend WithEvents PanelSidebar As Panel
    Friend WithEvents lblMenu As Label
    Friend WithEvents btnDataUser As Button
    Friend WithEvents btnDataMahasiswa As Button
    Friend WithEvents btnMataKuliah As Button
    Friend WithEvents btnInputNilai As Button
    Friend WithEvents btnLogAktivitas As Button
    Friend WithEvents btnReportNilai As Button
    Friend WithEvents btnReportLog As Button
    Friend WithEvents PanelDivider As Panel
    Friend WithEvents btnLogout As Button
    Friend WithEvents PanelContent As Panel
    Friend WithEvents lblContentTitle As Label
    Friend WithEvents lblContentDesc As Label

End Class