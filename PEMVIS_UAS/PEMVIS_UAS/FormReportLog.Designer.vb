<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormReportLog
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then components.Dispose()
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        Dim DgvHeader As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DgvCell As DataGridViewCellStyle = New DataGridViewCellStyle()

        PanelHeader = New Panel()
        LabelTitle = New Label()
        PanelFilter = New Panel()
        LabelFilterTitle = New Label()
        LabelTanggalDari = New Label()
        LabelTanggalSampai = New Label()
        LabelBulan = New Label()
        LabelTahun = New Label()
        LabelAktivitas = New Label()
        DateTimePickerDari = New DateTimePicker()
        DateTimePickerSampai = New DateTimePicker()
        ComboBoxBulan = New ComboBox()
        ComboBoxTahun = New ComboBox()
        ComboBoxAktivitas = New ComboBox()
        ButtonFilter = New Button()
        ButtonRefresh = New Button()
        ButtonPrint = New Button()
        PanelGrid = New Panel()
        DataGridViewLog = New DataGridView()
        PanelFooter = New Panel()
        LabelTotalRecord = New Label()
        ButtonClose = New Button()
        PrintDocument1 = New Printing.PrintDocument()
        PrintPreviewDialog1 = New PrintPreviewDialog()
        PrintDialog1 = New PrintDialog()

        PanelHeader.SuspendLayout()
        PanelFilter.SuspendLayout()
        PanelGrid.SuspendLayout()
        CType(DataGridViewLog, ComponentModel.ISupportInitialize).BeginInit()
        PanelFooter.SuspendLayout()
        SuspendLayout()

        ' ============================================================
        ' PanelHeader
        ' ============================================================
        PanelHeader.BackColor = Color.FromArgb(102, 187, 187)
        PanelHeader.Controls.Add(LabelTitle)
        PanelHeader.Dock = DockStyle.Top
        PanelHeader.Size = New Size(1100, 80)

        LabelTitle.AutoSize = True
        LabelTitle.Font = New Font("Segoe UI", 20.25F, FontStyle.Bold)
        LabelTitle.ForeColor = Color.White
        LabelTitle.Location = New Point(25, 18)
        LabelTitle.Text = "Report Log Aktivitas"

        ' ============================================================
        ' PanelFilter
        ' ============================================================
        PanelFilter.BackColor = Color.FromArgb(220, 240, 240)
        PanelFilter.Controls.AddRange(New Control() {
            LabelFilterTitle, LabelTanggalDari, LabelTanggalSampai,
            LabelBulan, LabelTahun, LabelAktivitas,
            DateTimePickerDari, DateTimePickerSampai,
            ComboBoxBulan, ComboBoxTahun, ComboBoxAktivitas,
            ButtonFilter, ButtonRefresh, ButtonPrint})
        PanelFilter.Dock = DockStyle.Top
        PanelFilter.Padding = New Padding(20, 15, 20, 15)
        PanelFilter.Size = New Size(1100, 120)

        LabelFilterTitle.AutoSize = True
        LabelFilterTitle.Font = New Font("Segoe UI", 11.25F, FontStyle.Bold)
        LabelFilterTitle.ForeColor = Color.FromArgb(74, 144, 144)
        LabelFilterTitle.Location = New Point(23, 13)
        LabelFilterTitle.Text = "Filter Laporan"

        ' Row 1 labels (y=48) — ditulis eksplisit (Designer tidak mendukung loop)
        LabelTanggalDari.AutoSize = True
        LabelTanggalDari.Font = New Font("Segoe UI", 9.0F)
        LabelTanggalDari.ForeColor = Color.FromArgb(74, 144, 144)
        LabelTanggalDari.Location = New Point(23, 48)
        LabelTanggalDari.Text = "Tanggal Dari:"

        LabelTanggalSampai.AutoSize = True
        LabelTanggalSampai.Font = New Font("Segoe UI", 9.0F)
        LabelTanggalSampai.ForeColor = Color.FromArgb(74, 144, 144)
        LabelTanggalSampai.Location = New Point(210, 48)
        LabelTanggalSampai.Text = "Tanggal Sampai:"

        LabelBulan.AutoSize = True
        LabelBulan.Font = New Font("Segoe UI", 9.0F)
        LabelBulan.ForeColor = Color.FromArgb(74, 144, 144)
        LabelBulan.Location = New Point(400, 48)
        LabelBulan.Text = "Bulan:"

        LabelTahun.AutoSize = True
        LabelTahun.Font = New Font("Segoe UI", 9.0F)
        LabelTahun.ForeColor = Color.FromArgb(74, 144, 144)
        LabelTahun.Location = New Point(520, 48)
        LabelTahun.Text = "Tahun:"

        LabelAktivitas.AutoSize = True
        LabelAktivitas.Font = New Font("Segoe UI", 9.0F)
        LabelAktivitas.ForeColor = Color.FromArgb(74, 144, 144)
        LabelAktivitas.Location = New Point(640, 48)
        LabelAktivitas.Text = "Jenis Aktivitas:"

        ' DateTimePicker Dari
        DateTimePickerDari.Font = New Font("Segoe UI", 9.0F)
        DateTimePickerDari.CustomFormat = "dd MMMM yyyy"
        DateTimePickerDari.Format = DateTimePickerFormat.Custom
        DateTimePickerDari.Location = New Point(23, 70)
        DateTimePickerDari.Size = New Size(175, 28)
        DateTimePickerDari.CalendarForeColor = Color.FromArgb(74, 144, 144)

        ' DateTimePicker Sampai
        DateTimePickerSampai.Font = New Font("Segoe UI", 9.0F)
        DateTimePickerSampai.CustomFormat = "dd MMMM yyyy"
        DateTimePickerSampai.Format = DateTimePickerFormat.Custom
        DateTimePickerSampai.Location = New Point(210, 70)
        DateTimePickerSampai.Size = New Size(175, 28)
        DateTimePickerSampai.CalendarForeColor = Color.FromArgb(74, 144, 144)

        ' ComboBox Bulan
        ComboBoxBulan.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBoxBulan.Font = New Font("Segoe UI", 9.0F)
        ComboBoxBulan.Location = New Point(400, 70)
        ComboBoxBulan.Size = New Size(110, 28)
        ComboBoxBulan.FlatStyle = FlatStyle.Flat
        ComboBoxBulan.Items.AddRange(New Object() {"Semua Bulan", "Januari", "Februari", "Maret",
                                                    "April", "Mei", "Juni", "Juli", "Agustus",
                                                    "September", "Oktober", "November", "Desember"})

        ' ComboBox Tahun
        ComboBoxTahun.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBoxTahun.Font = New Font("Segoe UI", 9.0F)
        ComboBoxTahun.Location = New Point(520, 70)
        ComboBoxTahun.Size = New Size(110, 28)
        ComboBoxTahun.FlatStyle = FlatStyle.Flat

        ' ComboBox Aktivitas
        ComboBoxAktivitas.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBoxAktivitas.Font = New Font("Segoe UI", 9.0F)
        ComboBoxAktivitas.Location = New Point(640, 70)
        ComboBoxAktivitas.Size = New Size(130, 28)
        ComboBoxAktivitas.FlatStyle = FlatStyle.Flat
        ComboBoxAktivitas.Items.AddRange(New Object() {"Semua Aktivitas", "Login", "Logout",
                                                        "Tambah", "Ubah", "Hapus"})

        ' Buttons
        ButtonFilter.BackColor = Color.FromArgb(102, 187, 187)
        ButtonFilter.FlatAppearance.BorderSize = 0
        ButtonFilter.FlatStyle = FlatStyle.Flat
        ButtonFilter.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        ButtonFilter.ForeColor = Color.White
        ButtonFilter.Location = New Point(790, 65)
        ButtonFilter.Size = New Size(90, 32)
        ButtonFilter.Text = "Filter"

        ButtonRefresh.BackColor = Color.FromArgb(160, 160, 160)
        ButtonRefresh.FlatAppearance.BorderSize = 0
        ButtonRefresh.FlatStyle = FlatStyle.Flat
        ButtonRefresh.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        ButtonRefresh.ForeColor = Color.White
        ButtonRefresh.Location = New Point(892, 65)
        ButtonRefresh.Size = New Size(90, 32)
        ButtonRefresh.Text = "Reset"

        ButtonPrint.BackColor = Color.FromArgb(74, 144, 144)
        ButtonPrint.FlatAppearance.BorderSize = 0
        ButtonPrint.FlatStyle = FlatStyle.Flat
        ButtonPrint.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        ButtonPrint.ForeColor = Color.White
        ButtonPrint.Location = New Point(992, 65)
        ButtonPrint.Size = New Size(90, 32)
        ButtonPrint.Text = "🖨 Print"

        ' ============================================================
        ' PanelGrid
        ' ============================================================
        PanelGrid.BackColor = Color.White
        PanelGrid.BorderStyle = BorderStyle.FixedSingle
        PanelGrid.Controls.Add(DataGridViewLog)
        PanelGrid.Dock = DockStyle.Fill
        PanelGrid.Padding = New Padding(15, 10, 15, 10)

        DgvHeader.BackColor = Color.FromArgb(102, 187, 187)
        DgvHeader.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        DgvHeader.ForeColor = Color.White
        DgvHeader.SelectionBackColor = Color.FromArgb(74, 144, 144)
        DgvHeader.SelectionForeColor = Color.White

        DgvCell.BackColor = Color.White
        DgvCell.Font = New Font("Segoe UI", 9.0F)
        DgvCell.ForeColor = Color.FromArgb(74, 144, 144)
        DgvCell.SelectionBackColor = Color.FromArgb(220, 240, 240)
        DgvCell.SelectionForeColor = Color.FromArgb(74, 144, 144)

        DataGridViewLog.ColumnHeadersDefaultCellStyle = DgvHeader
        DataGridViewLog.DefaultCellStyle = DgvCell
        DataGridViewLog.BackgroundColor = Color.White
        DataGridViewLog.BorderStyle = BorderStyle.None
        DataGridViewLog.GridColor = Color.FromArgb(220, 240, 240)
        DataGridViewLog.EnableHeadersVisualStyles = False
        DataGridViewLog.Dock = DockStyle.Fill
        DataGridViewLog.RowHeadersVisible = False
        DataGridViewLog.TabIndex = 0

        ' ============================================================
        ' PanelFooter
        ' ============================================================
        PanelFooter.BackColor = Color.FromArgb(102, 187, 187)
        PanelFooter.Controls.AddRange(New Control() {LabelTotalRecord, ButtonClose})
        PanelFooter.Dock = DockStyle.Bottom
        PanelFooter.Size = New Size(1100, 55)

        LabelTotalRecord.AutoSize = True
        LabelTotalRecord.Font = New Font("Segoe UI", 9.75F)
        LabelTotalRecord.ForeColor = Color.White
        LabelTotalRecord.Location = New Point(25, 18)
        LabelTotalRecord.Text = "Total Record: 0 data"

        ButtonClose.BackColor = Color.FromArgb(74, 144, 144)
        ButtonClose.FlatAppearance.BorderSize = 0
        ButtonClose.FlatAppearance.MouseOverBackColor = Color.FromArgb(94, 164, 164)
        ButtonClose.FlatStyle = FlatStyle.Flat
        ButtonClose.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold)
        ButtonClose.ForeColor = Color.White
        ButtonClose.Size = New Size(110, 35)
        ButtonClose.Location = New Point(970, 10)
        ButtonClose.Text = "Tutup"
        ButtonClose.Anchor = AnchorStyles.Top Or AnchorStyles.Right

        PrintPreviewDialog1.Document = PrintDocument1
        PrintPreviewDialog1.UseAntiAlias = True

        ' ============================================================
        ' Form
        ' ============================================================
        AutoScaleDimensions = New SizeF(8.0F, 20.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(1100, 700)
        Controls.Add(PanelGrid)
        Controls.Add(PanelFooter)
        Controls.Add(PanelFilter)
        Controls.Add(PanelHeader)
        Font = New Font("Segoe UI", 9.0F)
        FormBorderStyle = FormBorderStyle.None
        Name = "FormReportLog"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Report Log Aktivitas"

        PanelHeader.ResumeLayout(False)
        PanelHeader.PerformLayout()
        PanelFilter.ResumeLayout(False)
        PanelFilter.PerformLayout()
        PanelGrid.ResumeLayout(False)
        CType(DataGridViewLog, ComponentModel.ISupportInitialize).EndInit()
        PanelFooter.ResumeLayout(False)
        PanelFooter.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents PanelHeader As Panel
    Friend WithEvents LabelTitle As Label
    Friend WithEvents PanelFilter As Panel
    Friend WithEvents LabelFilterTitle As Label
    Friend WithEvents LabelTanggalDari As Label
    Friend WithEvents LabelTanggalSampai As Label
    Friend WithEvents LabelBulan As Label
    Friend WithEvents LabelTahun As Label
    Friend WithEvents LabelAktivitas As Label
    Friend WithEvents DateTimePickerDari As DateTimePicker
    Friend WithEvents DateTimePickerSampai As DateTimePicker
    Friend WithEvents ComboBoxBulan As ComboBox
    Friend WithEvents ComboBoxTahun As ComboBox
    Friend WithEvents ComboBoxAktivitas As ComboBox
    Friend WithEvents ButtonFilter As Button
    Friend WithEvents ButtonRefresh As Button
    Friend WithEvents ButtonPrint As Button
    Friend WithEvents PanelGrid As Panel
    Friend WithEvents DataGridViewLog As DataGridView
    Friend WithEvents PanelFooter As Panel
    Friend WithEvents LabelTotalRecord As Label
    Friend WithEvents ButtonClose As Button
    Friend WithEvents PrintDocument1 As Printing.PrintDocument
    Friend WithEvents PrintPreviewDialog1 As PrintPreviewDialog
    Friend WithEvents PrintDialog1 As PrintDialog
End Class