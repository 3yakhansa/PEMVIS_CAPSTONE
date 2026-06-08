<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormDashboardMahasiswa
    Inherits System.Windows.Forms.Form

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

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim ToolTip1 As ToolTip = New ToolTip(components)

        ' ── Containers ──────────────────────────────────────────────
        PanelHeader = New Panel()
        PanelCards = New Panel()
        PanelProfil = New Panel()
        PanelNilai = New Panel()
        PanelFooter = New Panel()

        ' ── Header controls ─────────────────────────────────────────
        LabelTitle = New Label()
        LabelSubtitle = New Label()

        ' ── Card controls ────────────────────────────────────────────
        ' Card 1 – Mata Kuliah
        PanelCardMK = New Panel()
        LabelCardMKTitle = New Label()
        LabelCardMKValue = New Label()
        LabelCardMKIcon = New Label()

        ' Card 2 – Total SKS
        PanelCardSKS = New Panel()
        LabelCardSKSTitle = New Label()
        LabelCardSKSValue = New Label()
        LabelCardSKSIcon = New Label()

        ' Card 3 – Rata-rata Nilai
        PanelCardRata = New Panel()
        LabelCardRataTitle = New Label()
        LabelCardRataValue = New Label()
        LabelCardRataIcon = New Label()

        ' Card 4 – IP
        PanelCardIP = New Panel()
        LabelCardIPTitle = New Label()
        LabelCardIPValue = New Label()
        LabelCardIPIcon = New Label()

        ' ── Profil controls ──────────────────────────────────────────
        LabelProfilHeader = New Label()
        LabelNIM = New Label()
        LabelNama = New Label()
        LabelAngkatan = New Label()
        LabelJK = New Label()
        LabelTTL = New Label()
        LabelAlamat = New Label()
        LabelNoTelp = New Label()
        LabelEmail = New Label()
        LabelNIMValue = New Label()
        LabelNamaValue = New Label()
        LabelAngkatanValue = New Label()
        LabelJKValue = New Label()
        LabelTTLValue = New Label()
        LabelAlamatValue = New Label()
        LabelNoTelpValue = New Label()
        LabelEmailValue = New Label()
        SeparatorProfil = New Panel()

        ' ── Nilai controls ───────────────────────────────────────────
        LabelNilaiHeader = New Label()
        ButtonRefresh = New Button()
        DataGridViewNilai = New DataGridView()

        ' ── Footer controls ──────────────────────────────────────────
        LabelTotalMK = New Label()
        ButtonClose = New Button()

        ' ════════════════════════════════════════════════════════════
        ' Begin Init
        ' ════════════════════════════════════════════════════════════
        PanelHeader.SuspendLayout()
        PanelCards.SuspendLayout()
        PanelProfil.SuspendLayout()
        PanelNilai.SuspendLayout()
        PanelFooter.SuspendLayout()
        PanelCardMK.SuspendLayout()
        PanelCardSKS.SuspendLayout()
        PanelCardRata.SuspendLayout()
        PanelCardIP.SuspendLayout()
        CType(DataGridViewNilai, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()

        ' ──────────────────────────────────────────────────────────
        ' PanelHeader
        ' ──────────────────────────────────────────────────────────
        PanelHeader.BackColor = Color.FromArgb(102, 187, 187)
        PanelHeader.Controls.Add(LabelTitle)
        PanelHeader.Controls.Add(LabelSubtitle)
        PanelHeader.Dock = DockStyle.Top
        PanelHeader.Location = New Point(0, 0)
        PanelHeader.Name = "PanelHeader"
        PanelHeader.Size = New Size(1100, 90)
        PanelHeader.TabIndex = 0

        ' LabelTitle
        LabelTitle.AutoSize = True
        LabelTitle.Font = New Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        LabelTitle.ForeColor = Color.White
        LabelTitle.Location = New Point(25, 10)
        LabelTitle.Name = "LabelTitle"
        LabelTitle.Text = "Dashboard Mahasiswa"

        ' LabelSubtitle
        LabelSubtitle.AutoSize = True
        LabelSubtitle.Font = New Font("Segoe UI", 10.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LabelSubtitle.ForeColor = Color.FromArgb(220, 255, 255)
        LabelSubtitle.Location = New Point(28, 58)
        LabelSubtitle.Name = "LabelSubtitle"
        LabelSubtitle.Text = "Selamat datang!"

        ' ──────────────────────────────────────────────────────────
        ' PanelCards  (strip kartu ringkasan)
        ' ──────────────────────────────────────────────────────────
        PanelCards.BackColor = Color.FromArgb(220, 240, 240)
        PanelCards.Controls.Add(PanelCardMK)
        PanelCards.Controls.Add(PanelCardSKS)
        PanelCards.Controls.Add(PanelCardRata)
        PanelCards.Controls.Add(PanelCardIP)
        PanelCards.Dock = DockStyle.Top
        PanelCards.Location = New Point(0, 90)
        PanelCards.Name = "PanelCards"
        PanelCards.Padding = New Padding(20, 12, 20, 12)
        PanelCards.Size = New Size(1100, 100)
        PanelCards.TabIndex = 1

        ' ── Helper: posisi kartu (4 kartu sejajar) ─────────────────
        Dim cardW As Integer = 220
        Dim cardH As Integer = 72
        Dim cardTop As Integer = 14
        Dim cardGap As Integer = 20
        Dim cardStart As Integer = 20

        ' ── PanelCardMK ────────────────────────────────────────────
        BuildCard(PanelCardMK, LabelCardMKIcon, LabelCardMKTitle, LabelCardMKValue,
                  cardStart, cardTop, cardW, cardH,
                  "📚", "Mata Kuliah", Color.FromArgb(102, 187, 187))

        ' ── PanelCardSKS ───────────────────────────────────────────
        BuildCard(PanelCardSKS, LabelCardSKSIcon, LabelCardSKSTitle, LabelCardSKSValue,
                  cardStart + (cardW + cardGap), cardTop, cardW, cardH,
                  "📖", "Total SKS", Color.FromArgb(74, 144, 144))

        ' ── PanelCardRata ──────────────────────────────────────────
        BuildCard(PanelCardRata, LabelCardRataIcon, LabelCardRataTitle, LabelCardRataValue,
                  cardStart + (cardW + cardGap) * 2, cardTop, cardW, cardH,
                  "📊", "Rata-rata Nilai", Color.FromArgb(102, 187, 187))

        ' ── PanelCardIP ────────────────────────────────────────────
        BuildCard(PanelCardIP, LabelCardIPIcon, LabelCardIPTitle, LabelCardIPValue,
                  cardStart + (cardW + cardGap) * 3, cardTop, cardW, cardH,
                  "🎯", "Indeks Prestasi", Color.FromArgb(74, 144, 144))

        ' ──────────────────────────────────────────────────────────
        ' PanelProfil  (kiri bawah)
        ' ──────────────────────────────────────────────────────────
        PanelProfil.BackColor = Color.White
        PanelProfil.BorderStyle = BorderStyle.FixedSingle
        PanelProfil.Controls.Add(LabelProfilHeader)
        PanelProfil.Controls.Add(SeparatorProfil)
        PanelProfil.Controls.Add(LabelNIM)
        PanelProfil.Controls.Add(LabelNIMValue)
        PanelProfil.Controls.Add(LabelNama)
        PanelProfil.Controls.Add(LabelNamaValue)
        PanelProfil.Controls.Add(LabelAngkatan)
        PanelProfil.Controls.Add(LabelAngkatanValue)
        PanelProfil.Controls.Add(LabelJK)
        PanelProfil.Controls.Add(LabelJKValue)
        PanelProfil.Controls.Add(LabelTTL)
        PanelProfil.Controls.Add(LabelTTLValue)
        PanelProfil.Controls.Add(LabelAlamat)
        PanelProfil.Controls.Add(LabelAlamatValue)
        PanelProfil.Controls.Add(LabelNoTelp)
        PanelProfil.Controls.Add(LabelNoTelpValue)
        PanelProfil.Controls.Add(LabelEmail)
        PanelProfil.Controls.Add(LabelEmailValue)
        PanelProfil.Dock = DockStyle.Left
        PanelProfil.Location = New Point(0, 190)
        PanelProfil.Name = "PanelProfil"
        PanelProfil.Padding = New Padding(16, 12, 16, 12)
        PanelProfil.Size = New Size(310, 460)
        PanelProfil.TabIndex = 2

        ' LabelProfilHeader
        LabelProfilHeader.AutoSize = True
        LabelProfilHeader.Font = New Font("Segoe UI", 11.25F, FontStyle.Bold)
        LabelProfilHeader.ForeColor = Color.FromArgb(74, 144, 144)
        LabelProfilHeader.Location = New Point(16, 12)
        LabelProfilHeader.Name = "LabelProfilHeader"
        LabelProfilHeader.Text = "👤  Profil Mahasiswa"

        ' SeparatorProfil
        SeparatorProfil.BackColor = Color.FromArgb(102, 187, 187)
        SeparatorProfil.Location = New Point(16, 40)
        SeparatorProfil.Name = "SeparatorProfil"
        SeparatorProfil.Size = New Size(270, 2)

        ' Baris-baris profil
        BuildProfilRow(LabelNIM, LabelNIMValue, "NIM", 16, 55)
        BuildProfilRow(LabelNama, LabelNamaValue, "Nama", 16, 90)
        BuildProfilRow(LabelAngkatan, LabelAngkatanValue, "Angkatan", 16, 125)
        BuildProfilRow(LabelJK, LabelJKValue, "Jenis Kelamin", 16, 160)
        BuildProfilRow(LabelTTL, LabelTTLValue, "Tempat, Tgl Lahir", 16, 195)
        BuildProfilRow(LabelAlamat, LabelAlamatValue, "Alamat", 16, 245)
        BuildProfilRow(LabelNoTelp, LabelNoTelpValue, "No. Telp", 16, 330)
        BuildProfilRow(LabelEmail, LabelEmailValue, "Email", 16, 365)

        ' Alamat value – bisa wrap
        LabelAlamatValue.AutoSize = False
        LabelAlamatValue.Size = New Size(270, 55)
        LabelAlamatValue.MaximumSize = New Size(270, 0)

        ' ──────────────────────────────────────────────────────────
        ' PanelNilai  (kanan bawah)
        ' ──────────────────────────────────────────────────────────
        PanelNilai.BackColor = Color.White
        PanelNilai.BorderStyle = BorderStyle.FixedSingle
        PanelNilai.Controls.Add(LabelNilaiHeader)
        PanelNilai.Controls.Add(ButtonRefresh)
        PanelNilai.Controls.Add(DataGridViewNilai)
        PanelNilai.Dock = DockStyle.Fill
        PanelNilai.Location = New Point(310, 190)
        PanelNilai.Name = "PanelNilai"
        PanelNilai.Padding = New Padding(12, 10, 12, 10)
        PanelNilai.Size = New Size(790, 460)
        PanelNilai.TabIndex = 3

        ' LabelNilaiHeader
        LabelNilaiHeader.AutoSize = True
        LabelNilaiHeader.Font = New Font("Segoe UI", 11.25F, FontStyle.Bold)
        LabelNilaiHeader.ForeColor = Color.FromArgb(74, 144, 144)
        LabelNilaiHeader.Location = New Point(12, 12)
        LabelNilaiHeader.Name = "LabelNilaiHeader"
        LabelNilaiHeader.Text = "📋  Rekap Nilai"

        ' ButtonRefresh
        ButtonRefresh.BackColor = Color.FromArgb(144, 202, 202)
        ButtonRefresh.FlatAppearance.BorderSize = 0
        ButtonRefresh.FlatAppearance.MouseDownBackColor = Color.FromArgb(102, 187, 187)
        ButtonRefresh.FlatAppearance.MouseOverBackColor = Color.FromArgb(160, 220, 220)
        ButtonRefresh.FlatStyle = FlatStyle.Flat
        ButtonRefresh.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        ButtonRefresh.ForeColor = Color.White
        ButtonRefresh.Location = New Point(660, 8)
        ButtonRefresh.Name = "ButtonRefresh"
        ButtonRefresh.Size = New Size(100, 30)
        ButtonRefresh.TabIndex = 1
        ButtonRefresh.Text = "Refresh"
        ToolTip1.SetToolTip(ButtonRefresh, "Klik untuk memperbarui data")
        ButtonRefresh.UseVisualStyleBackColor = False

        ' DataGridViewNilai
        DataGridViewNilai.AllowUserToAddRows = False
        DataGridViewNilai.AllowUserToDeleteRows = False
        DataGridViewNilai.BackgroundColor = Color.White
        DataGridViewNilai.BorderStyle = BorderStyle.None
        DataGridViewNilai.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single

        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = Color.FromArgb(102, 187, 187)
        DataGridViewCellStyle1.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        DataGridViewCellStyle1.ForeColor = Color.White
        DataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(74, 144, 144)
        DataGridViewCellStyle1.SelectionForeColor = Color.White
        DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True
        DataGridViewNilai.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        DataGridViewNilai.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize

        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = Color.White
        DataGridViewCellStyle2.Font = New Font("Segoe UI", 9.0F, FontStyle.Regular)
        DataGridViewCellStyle2.ForeColor = Color.FromArgb(74, 144, 144)
        DataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(220, 240, 240)
        DataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(74, 144, 144)
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.False
        DataGridViewNilai.DefaultCellStyle = DataGridViewCellStyle2

        DataGridViewNilai.EnableHeadersVisualStyles = False
        DataGridViewNilai.GridColor = Color.FromArgb(220, 240, 240)
        DataGridViewNilai.Location = New Point(12, 48)
        DataGridViewNilai.MultiSelect = False
        DataGridViewNilai.Name = "DataGridViewNilai"
        DataGridViewNilai.ReadOnly = True
        DataGridViewNilai.RowHeadersVisible = False
        DataGridViewNilai.RowHeadersWidth = 51
        DataGridViewNilai.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DataGridViewNilai.Size = New Size(754, 390)
        DataGridViewNilai.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or
                                   AnchorStyles.Left Or AnchorStyles.Right
        DataGridViewNilai.TabIndex = 0

        ' ──────────────────────────────────────────────────────────
        ' PanelFooter
        ' ──────────────────────────────────────────────────────────
        PanelFooter.BackColor = Color.FromArgb(102, 187, 187)
        PanelFooter.Controls.Add(LabelTotalMK)
        PanelFooter.Controls.Add(ButtonClose)
        PanelFooter.Dock = DockStyle.Bottom
        PanelFooter.Location = New Point(0, 650)
        PanelFooter.Name = "PanelFooter"
        PanelFooter.Size = New Size(1100, 60)
        PanelFooter.TabIndex = 4

        ' LabelTotalMK
        LabelTotalMK.AutoSize = True
        LabelTotalMK.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular)
        LabelTotalMK.ForeColor = Color.White
        LabelTotalMK.Location = New Point(25, 20)
        LabelTotalMK.Name = "LabelTotalMK"
        LabelTotalMK.Text = "Total Mata Kuliah: 0 MK"

        ' ButtonClose
        ButtonClose.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        ButtonClose.BackColor = Color.FromArgb(74, 144, 144)
        ButtonClose.FlatAppearance.BorderSize = 0
        ButtonClose.FlatAppearance.MouseDownBackColor = Color.FromArgb(54, 124, 124)
        ButtonClose.FlatAppearance.MouseOverBackColor = Color.FromArgb(94, 164, 164)
        ButtonClose.FlatStyle = FlatStyle.Flat
        ButtonClose.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold)
        ButtonClose.ForeColor = Color.White
        ButtonClose.Location = New Point(970, 12)
        ButtonClose.Name = "ButtonClose"
        ButtonClose.Size = New Size(110, 35)
        ButtonClose.TabIndex = 0
        ButtonClose.Text = "Tutup"
        ButtonClose.UseVisualStyleBackColor = False

        ' ──────────────────────────────────────────────────────────
        ' FormDashboardMahasiswa
        ' ──────────────────────────────────────────────────────────
        AutoScaleDimensions = New SizeF(10.0F, 25.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(220, 240, 240)
        ClientSize = New Size(1100, 710)
        Controls.Add(PanelNilai)
        Controls.Add(PanelProfil)
        Controls.Add(PanelFooter)
        Controls.Add(PanelCards)
        Controls.Add(PanelHeader)
        Font = New Font("Segoe UI", 9.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        FormBorderStyle = FormBorderStyle.None
        MinimumSize = New Size(900, 600)
        Name = "FormDashboardMahasiswa"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Dashboard Mahasiswa"

        ' ── Resume ───────────────────────────────────────────────
        PanelHeader.ResumeLayout(False)
        PanelHeader.PerformLayout()
        PanelCards.ResumeLayout(False)
        PanelCardMK.ResumeLayout(False)
        PanelCardMK.PerformLayout()
        PanelCardSKS.ResumeLayout(False)
        PanelCardSKS.PerformLayout()
        PanelCardRata.ResumeLayout(False)
        PanelCardRata.PerformLayout()
        PanelCardIP.ResumeLayout(False)
        PanelCardIP.PerformLayout()
        PanelProfil.ResumeLayout(False)
        PanelProfil.PerformLayout()
        PanelNilai.ResumeLayout(False)
        PanelNilai.PerformLayout()
        PanelFooter.ResumeLayout(False)
        PanelFooter.PerformLayout()
        CType(DataGridViewNilai, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    ' ════════════════════════════════════════════════════════════════
    ' Helper: buat satu kartu ringkasan
    ' ════════════════════════════════════════════════════════════════
    Private Sub BuildCard(panel As Panel,
                          lblIcon As Label, lblTitle As Label, lblValue As Label,
                          x As Integer, y As Integer, w As Integer, h As Integer,
                          icon As String, title As String, accentColor As Color)
        panel.BackColor = Color.White
        panel.BorderStyle = BorderStyle.FixedSingle
        panel.Location = New Point(x, y)
        panel.Name = panel.Name
        panel.Size = New Size(w, h)

        ' Garis aksen kiri
        Dim accent As New Panel()
        accent.BackColor = accentColor
        accent.Location = New Point(0, 0)
        accent.Size = New Size(5, h)
        panel.Controls.Add(accent)

        ' Icon
        lblIcon.AutoSize = True
        lblIcon.Font = New Font("Segoe UI", 18.0F)
        lblIcon.ForeColor = accentColor
        lblIcon.Location = New Point(14, 8)
        lblIcon.Text = icon
        panel.Controls.Add(lblIcon)

        ' Title
        lblTitle.AutoSize = True
        lblTitle.Font = New Font("Segoe UI", 8.25F, FontStyle.Regular)
        lblTitle.ForeColor = Color.Gray
        lblTitle.Location = New Point(58, 10)
        lblTitle.Text = title
        panel.Controls.Add(lblTitle)

        ' Value
        lblValue.AutoSize = True
        lblValue.Font = New Font("Segoe UI", 16.0F, FontStyle.Bold)
        lblValue.ForeColor = accentColor
        lblValue.Location = New Point(58, 30)
        lblValue.Text = "0"
        panel.Controls.Add(lblValue)
    End Sub

    ' ════════════════════════════════════════════════════════════════
    ' Helper: buat satu baris label profil (label kiri + value kanan)
    ' ════════════════════════════════════════════════════════════════
    Private Sub BuildProfilRow(lblKey As Label, lblVal As Label,
                                keyText As String, x As Integer, y As Integer)
        ' Key label
        lblKey.AutoSize = True
        lblKey.Font = New Font("Segoe UI", 8.25F, FontStyle.Regular)
        lblKey.ForeColor = Color.Gray
        lblKey.Location = New Point(x, y)
        lblKey.Text = keyText

        ' Value label
        lblVal.AutoSize = True
        lblVal.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        lblVal.ForeColor = Color.FromArgb(74, 144, 144)
        lblVal.Location = New Point(x, y + 18)
        lblVal.Text = "-"
        lblVal.MaximumSize = New Size(270, 0)
    End Sub

    ' ════════════════════════════════════════════════════════════════
    ' Deklarasi kontrol
    ' ════════════════════════════════════════════════════════════════
    Friend WithEvents PanelHeader As Panel
    Friend WithEvents PanelCards As Panel
    Friend WithEvents PanelProfil As Panel
    Friend WithEvents PanelNilai As Panel
    Friend WithEvents PanelFooter As Panel

    Friend WithEvents LabelTitle As Label
    Friend WithEvents LabelSubtitle As Label

    Friend WithEvents PanelCardMK As Panel
    Friend WithEvents LabelCardMKIcon As Label
    Friend WithEvents LabelCardMKTitle As Label
    Friend WithEvents LabelCardMKValue As Label

    Friend WithEvents PanelCardSKS As Panel
    Friend WithEvents LabelCardSKSIcon As Label
    Friend WithEvents LabelCardSKSTitle As Label
    Friend WithEvents LabelCardSKSValue As Label

    Friend WithEvents PanelCardRata As Panel
    Friend WithEvents LabelCardRataIcon As Label
    Friend WithEvents LabelCardRataTitle As Label
    Friend WithEvents LabelCardRataValue As Label

    Friend WithEvents PanelCardIP As Panel
    Friend WithEvents LabelCardIPIcon As Label
    Friend WithEvents LabelCardIPTitle As Label
    Friend WithEvents LabelCardIPValue As Label

    Friend WithEvents LabelProfilHeader As Label
    Friend WithEvents SeparatorProfil As Panel

    Friend WithEvents LabelNIM As Label
    Friend WithEvents LabelNama As Label
    Friend WithEvents LabelAngkatan As Label
    Friend WithEvents LabelJK As Label
    Friend WithEvents LabelTTL As Label
    Friend WithEvents LabelAlamat As Label
    Friend WithEvents LabelNoTelp As Label
    Friend WithEvents LabelEmail As Label

    Friend WithEvents LabelNIMValue As Label
    Friend WithEvents LabelNamaValue As Label
    Friend WithEvents LabelAngkatanValue As Label
    Friend WithEvents LabelJKValue As Label
    Friend WithEvents LabelTTLValue As Label
    Friend WithEvents LabelAlamatValue As Label
    Friend WithEvents LabelNoTelpValue As Label
    Friend WithEvents LabelEmailValue As Label

    Friend WithEvents LabelNilaiHeader As Label
    Friend WithEvents ButtonRefresh As Button
    Friend WithEvents DataGridViewNilai As DataGridView

    Friend WithEvents LabelTotalMK As Label
    Friend WithEvents ButtonClose As Button
End Class