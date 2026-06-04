<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormLogAktivitas
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
        components = New ComponentModel.Container()
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormLogAktivitas))
        PanelHeader = New Panel()
        LabelTitle = New Label()
        PanelFilter = New Panel()
        LabelFilter = New Label()
        LabelTanggalDari = New Label()
        LabelTanggalSampai = New Label()
        LabelBulan = New Label()
        LabelTahun = New Label()
        DateTimePickerDari = New DateTimePicker()
        DateTimePickerSampai = New DateTimePicker()
        ComboBoxBulan = New ComboBox()
        ComboBoxTahun = New ComboBox()
        ButtonFilter = New Button()
        ButtonRefresh = New Button()
        ButtonPrint = New Button()
        PanelGrid = New Panel()
        DataGridViewLog = New DataGridView()
        PanelFooter = New Panel()
        LabelTotalRecord = New Label()
        ButtonClose = New Button()
        ToolTip1 = New ToolTip(components)
        PrintDocument1 = New Printing.PrintDocument()
        PrintPreviewDialog1 = New PrintPreviewDialog()
        PrintDialog1 = New PrintDialog()
        PanelHeader.SuspendLayout()
        PanelFilter.SuspendLayout()
        PanelGrid.SuspendLayout()
        CType(DataGridViewLog, ComponentModel.ISupportInitialize).BeginInit()
        PanelFooter.SuspendLayout()
        SuspendLayout()
        ' 
        ' PanelHeader
        ' 
        PanelHeader.BackColor = Color.FromArgb(CByte(102), CByte(187), CByte(187))
        PanelHeader.Controls.Add(LabelTitle)
        PanelHeader.Dock = DockStyle.Top
        PanelHeader.Location = New Point(0, 0)
        PanelHeader.Name = "PanelHeader"
        PanelHeader.Size = New Size(1000, 80)
        PanelHeader.TabIndex = 0
        ' 
        ' LabelTitle
        ' 
        LabelTitle.AutoSize = True
        LabelTitle.Font = New Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        LabelTitle.ForeColor = Color.White
        LabelTitle.Location = New Point(25, 20)
        LabelTitle.Name = "LabelTitle"
        LabelTitle.Size = New Size(343, 46)
        LabelTitle.TabIndex = 0
        LabelTitle.Text = "Log Aktivitas Sistem"
        ' 
        ' PanelFilter
        ' 
        PanelFilter.BackColor = Color.FromArgb(CByte(220), CByte(240), CByte(240))
        PanelFilter.Controls.Add(LabelFilter)
        PanelFilter.Controls.Add(LabelTanggalDari)
        PanelFilter.Controls.Add(LabelTanggalSampai)
        PanelFilter.Controls.Add(LabelBulan)
        PanelFilter.Controls.Add(LabelTahun)
        PanelFilter.Controls.Add(DateTimePickerDari)
        PanelFilter.Controls.Add(DateTimePickerSampai)
        PanelFilter.Controls.Add(ComboBoxBulan)
        PanelFilter.Controls.Add(ComboBoxTahun)
        PanelFilter.Controls.Add(ButtonFilter)
        PanelFilter.Controls.Add(ButtonRefresh)
        PanelFilter.Controls.Add(ButtonPrint)
        PanelFilter.Dock = DockStyle.Top
        PanelFilter.Location = New Point(0, 80)
        PanelFilter.Name = "PanelFilter"
        PanelFilter.Padding = New Padding(20, 15, 20, 15)
        PanelFilter.Size = New Size(1000, 110)
        PanelFilter.TabIndex = 1
        ' 
        ' LabelFilter
        ' 
        LabelFilter.AutoSize = True
        LabelFilter.Font = New Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        LabelFilter.ForeColor = Color.FromArgb(CByte(74), CByte(144), CByte(144))
        LabelFilter.Location = New Point(23, 18)
        LabelFilter.Name = "LabelFilter"
        LabelFilter.Size = New Size(149, 25)
        LabelFilter.TabIndex = 0
        LabelFilter.Text = "Filter Pencarian"
        ' 
        ' LabelTanggalDari
        ' 
        LabelTanggalDari.AutoSize = True
        LabelTanggalDari.Font = New Font("Segoe UI", 9.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LabelTanggalDari.ForeColor = Color.FromArgb(CByte(74), CByte(144), CByte(144))
        LabelTanggalDari.Location = New Point(20, 52)
        LabelTanggalDari.Name = "LabelTanggalDari"
        LabelTanggalDari.Size = New Size(96, 20)
        LabelTanggalDari.TabIndex = 1
        LabelTanggalDari.Text = "Tanggal Dari:"
        ' 
        ' LabelTanggalSampai
        ' 
        LabelTanggalSampai.AutoSize = True
        LabelTanggalSampai.Font = New Font("Segoe UI", 9.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LabelTanggalSampai.ForeColor = Color.FromArgb(CByte(74), CByte(144), CByte(144))
        LabelTanggalSampai.Location = New Point(190, 52)
        LabelTanggalSampai.Name = "LabelTanggalSampai"
        LabelTanggalSampai.Size = New Size(118, 20)
        LabelTanggalSampai.TabIndex = 2
        LabelTanggalSampai.Text = "Tanggal Sampai:"
        ' 
        ' LabelBulan
        ' 
        LabelBulan.AutoSize = True
        LabelBulan.Font = New Font("Segoe UI", 9.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LabelBulan.ForeColor = Color.FromArgb(CByte(74), CByte(144), CByte(144))
        LabelBulan.Location = New Point(360, 52)
        LabelBulan.Name = "LabelBulan"
        LabelBulan.Size = New Size(49, 20)
        LabelBulan.TabIndex = 3
        LabelBulan.Text = "Bulan:"
        ' 
        ' LabelTahun
        ' 
        LabelTahun.AutoSize = True
        LabelTahun.Font = New Font("Segoe UI", 9.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LabelTahun.ForeColor = Color.FromArgb(CByte(74), CByte(144), CByte(144))
        LabelTahun.Location = New Point(500, 52)
        LabelTahun.Name = "LabelTahun"
        LabelTahun.Size = New Size(50, 20)
        LabelTahun.TabIndex = 4
        LabelTahun.Text = "Tahun:"
        ' 
        ' DateTimePickerDari
        ' 
        DateTimePickerDari.CalendarForeColor = Color.FromArgb(CByte(74), CByte(144), CByte(144))
        DateTimePickerDari.CalendarMonthBackground = Color.White
        DateTimePickerDari.CalendarTitleForeColor = Color.FromArgb(CByte(74), CByte(144), CByte(144))
        DateTimePickerDari.CustomFormat = "dd MMMM yyyy"
        DateTimePickerDari.Font = New Font("Segoe UI", 9.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DateTimePickerDari.Format = DateTimePickerFormat.Custom
        DateTimePickerDari.Location = New Point(20, 70)
        DateTimePickerDari.Name = "DateTimePickerDari"
        DateTimePickerDari.Size = New Size(150, 27)
        DateTimePickerDari.TabIndex = 5
        ' 
        ' DateTimePickerSampai
        ' 
        DateTimePickerSampai.CalendarForeColor = Color.FromArgb(CByte(74), CByte(144), CByte(144))
        DateTimePickerSampai.CalendarMonthBackground = Color.White
        DateTimePickerSampai.CalendarTitleForeColor = Color.FromArgb(CByte(74), CByte(144), CByte(144))
        DateTimePickerSampai.CustomFormat = "dd MMMM yyyy"
        DateTimePickerSampai.Font = New Font("Segoe UI", 9.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DateTimePickerSampai.Format = DateTimePickerFormat.Custom
        DateTimePickerSampai.Location = New Point(190, 70)
        DateTimePickerSampai.Name = "DateTimePickerSampai"
        DateTimePickerSampai.Size = New Size(150, 27)
        DateTimePickerSampai.TabIndex = 6
        ' 
        ' ComboBoxBulan
        ' 
        ComboBoxBulan.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBoxBulan.Font = New Font("Segoe UI", 9.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ComboBoxBulan.FormattingEnabled = True
        ComboBoxBulan.Items.AddRange(New Object() {"Semua Bulan", "Januari", "Februari", "Maret", "April", "Mei", "Juni", "Juli", "Agustus", "September", "Oktober", "November", "Desember"})
        ComboBoxBulan.Location = New Point(360, 70)
        ComboBoxBulan.Name = "ComboBoxBulan"
        ComboBoxBulan.Size = New Size(120, 28)
        ComboBoxBulan.TabIndex = 7
        ' 
        ' ComboBoxTahun
        ' 
        ComboBoxTahun.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBoxTahun.Font = New Font("Segoe UI", 9.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ComboBoxTahun.FormattingEnabled = True
        ComboBoxTahun.Location = New Point(500, 70)
        ComboBoxTahun.Name = "ComboBoxTahun"
        ComboBoxTahun.Size = New Size(80, 28)
        ComboBoxTahun.TabIndex = 8
        ' 
        ' ButtonFilter
        ' 
        ButtonFilter.BackColor = Color.FromArgb(CByte(102), CByte(187), CByte(187))
        ButtonFilter.FlatAppearance.BorderSize = 0
        ButtonFilter.FlatAppearance.MouseDownBackColor = Color.FromArgb(CByte(74), CByte(144), CByte(144))
        ButtonFilter.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(120), CByte(200), CByte(200))
        ButtonFilter.FlatStyle = FlatStyle.Flat
        ButtonFilter.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        ButtonFilter.ForeColor = Color.White
        ButtonFilter.Location = New Point(610, 68)
        ButtonFilter.Name = "ButtonFilter"
        ButtonFilter.Size = New Size(100, 30)
        ButtonFilter.TabIndex = 9
        ButtonFilter.Text = "Filter"
        ToolTip1.SetToolTip(ButtonFilter, "Klik untuk memfilter data")
        ButtonFilter.UseVisualStyleBackColor = False
        ' 
        ' ButtonRefresh
        ' 
        ButtonRefresh.BackColor = Color.FromArgb(CByte(144), CByte(202), CByte(202))
        ButtonRefresh.FlatAppearance.BorderSize = 0
        ButtonRefresh.FlatAppearance.MouseDownBackColor = Color.FromArgb(CByte(102), CByte(187), CByte(187))
        ButtonRefresh.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(160), CByte(220), CByte(220))
        ButtonRefresh.FlatStyle = FlatStyle.Flat
        ButtonRefresh.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        ButtonRefresh.ForeColor = Color.White
        ButtonRefresh.Location = New Point(720, 68)
        ButtonRefresh.Name = "ButtonRefresh"
        ButtonRefresh.Size = New Size(100, 30)
        ButtonRefresh.TabIndex = 10
        ButtonRefresh.Text = "Refresh"
        ToolTip1.SetToolTip(ButtonRefresh, "Klik untuk refresh data")
        ButtonRefresh.UseVisualStyleBackColor = False
        ' 
        ' ButtonPrint
        ' 
        ButtonPrint.BackColor = Color.FromArgb(CByte(74), CByte(144), CByte(144))
        ButtonPrint.FlatAppearance.BorderSize = 0
        ButtonPrint.FlatAppearance.MouseDownBackColor = Color.FromArgb(CByte(54), CByte(124), CByte(124))
        ButtonPrint.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(94), CByte(164), CByte(164))
        ButtonPrint.FlatStyle = FlatStyle.Flat
        ButtonPrint.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        ButtonPrint.ForeColor = Color.White
        ButtonPrint.Location = New Point(830, 68)
        ButtonPrint.Name = "ButtonPrint"
        ButtonPrint.Size = New Size(100, 30)
        ButtonPrint.TabIndex = 11
        ButtonPrint.Text = "Print"
        ToolTip1.SetToolTip(ButtonPrint, "Klik untuk preview & cetak laporan")
        ButtonPrint.UseVisualStyleBackColor = False
        ' 
        ' PanelGrid
        ' 
        PanelGrid.BackColor = Color.White
        PanelGrid.BorderStyle = BorderStyle.FixedSingle
        PanelGrid.Controls.Add(DataGridViewLog)
        PanelGrid.Dock = DockStyle.Fill
        PanelGrid.Location = New Point(0, 190)
        PanelGrid.Name = "PanelGrid"
        PanelGrid.Padding = New Padding(20, 10, 20, 10)
        PanelGrid.Size = New Size(1000, 400)
        PanelGrid.TabIndex = 2
        ' 
        ' DataGridViewLog
        ' 
        DataGridViewLog.AllowUserToAddRows = False
        DataGridViewLog.AllowUserToDeleteRows = False
        DataGridViewLog.BackgroundColor = Color.White
        DataGridViewLog.BorderStyle = BorderStyle.None
        DataGridViewLog.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = Color.FromArgb(CByte(102), CByte(187), CByte(187))
        DataGridViewCellStyle1.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle1.ForeColor = Color.White
        DataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(CByte(74), CByte(144), CByte(144))
        DataGridViewCellStyle1.SelectionForeColor = Color.White
        DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True
        DataGridViewLog.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        DataGridViewLog.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = Color.White
        DataGridViewCellStyle2.Font = New Font("Segoe UI", 9.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle2.ForeColor = Color.FromArgb(CByte(74), CByte(144), CByte(144))
        DataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(CByte(220), CByte(240), CByte(240))
        DataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(CByte(74), CByte(144), CByte(144))
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.False
        DataGridViewLog.DefaultCellStyle = DataGridViewCellStyle2
        DataGridViewLog.Dock = DockStyle.Fill ' DIUBAH: Agar otomatis memenuhi panel
        DataGridViewLog.EnableHeadersVisualStyles = False
        DataGridViewLog.GridColor = Color.FromArgb(CByte(220), CByte(240), CByte(240))
        DataGridViewLog.MultiSelect = False
        DataGridViewLog.Name = "DataGridViewLog"
        DataGridViewLog.ReadOnly = True
        DataGridViewLog.RowHeadersVisible = False
        DataGridViewLog.RowHeadersWidth = 51
        DataGridViewLog.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DataGridViewLog.TabIndex = 0
        ' 
        ' PanelFooter
        ' 
        PanelFooter.BackColor = Color.FromArgb(CByte(102), CByte(187), CByte(187))
        PanelFooter.Controls.Add(LabelTotalRecord)
        PanelFooter.Controls.Add(ButtonClose)
        PanelFooter.Dock = DockStyle.Bottom
        PanelFooter.Location = New Point(0, 590)
        PanelFooter.Name = "PanelFooter"
        PanelFooter.Size = New Size(1000, 60)
        PanelFooter.TabIndex = 3
        ' 
        ' LabelTotalRecord
        ' 
        LabelTotalRecord.AutoSize = True
        LabelTotalRecord.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LabelTotalRecord.ForeColor = Color.White
        LabelTotalRecord.Location = New Point(25, 20)
        LabelTotalRecord.Name = "LabelTotalRecord"
        LabelTotalRecord.Size = New Size(161, 23)
        LabelTotalRecord.TabIndex = 1
        LabelTotalRecord.Text = "Total Record: 0 data"
        ' 
        ' ButtonClose
        ' 
        ButtonClose.BackColor = Color.FromArgb(CByte(74), CByte(144), CByte(144))
        ButtonClose.FlatAppearance.BorderSize = 0
        ButtonClose.FlatAppearance.MouseDownBackColor = Color.FromArgb(CByte(54), CByte(124), CByte(124))
        ButtonClose.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(94), CByte(164), CByte(164))
        ButtonClose.FlatStyle = FlatStyle.Flat
        ButtonClose.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        ButtonClose.ForeColor = Color.White
        ButtonClose.Location = New Point(870, 12) ' DIUBAH: Posisi disesuaikan untuk lebar 1000
        ButtonClose.Name = "ButtonClose"
        ButtonClose.Size = New Size(110, 35)
        ButtonClose.TabIndex = 0
        ButtonClose.Text = "Tutup"
        ButtonClose.Anchor = AnchorStyles.Top Or AnchorStyles.Right ' DIUBAH: Menempel kanan
        ButtonClose.UseVisualStyleBackColor = False
        ' 
        ' PrintPreviewDialog1
        ' 
        PrintPreviewDialog1.AutoScrollMargin = New Size(0, 0)
        PrintPreviewDialog1.AutoScrollMinSize = New Size(0, 0)
        PrintPreviewDialog1.ClientSize = New Size(400, 300)
        PrintPreviewDialog1.Document = PrintDocument1
        PrintPreviewDialog1.Enabled = True
        PrintPreviewDialog1.Icon = CType(resources.GetObject("PrintPreviewDialog1.Icon"), Icon)
        PrintPreviewDialog1.Name = "PrintPreviewDialog1"
        PrintPreviewDialog1.UseAntiAlias = True
        PrintPreviewDialog1.Visible = False
        ' 
        ' PrintDialog1
        ' 
        PrintDialog1.UseEXDialog = True
        ' 
        ' FormLogAktivitas
        ' 
        AutoScaleDimensions = New SizeF(8.0F, 20.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(1000, 650) ' DIUBAH: Ukuran form diperkecil (tidak max)
        Controls.Add(PanelGrid)
        Controls.Add(PanelFooter)
        Controls.Add(PanelFilter)
        Controls.Add(PanelHeader)
        Font = New Font("Segoe UI", 9.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        FormBorderStyle = FormBorderStyle.None
        Name = "FormLogAktivitas"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Log Aktivitas"
        ' WindowState = FormWindowState.Maximized -> DIHAPUS
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

    Friend WithEvents PanelHeader As System.Windows.Forms.Panel
    Friend WithEvents LabelTitle As System.Windows.Forms.Label
    Friend WithEvents PanelFilter As System.Windows.Forms.Panel
    Friend WithEvents LabelFilter As System.Windows.Forms.Label
    Friend WithEvents LabelTanggalDari As System.Windows.Forms.Label
    Friend WithEvents LabelTanggalSampai As System.Windows.Forms.Label
    Friend WithEvents LabelBulan As System.Windows.Forms.Label
    Friend WithEvents LabelTahun As System.Windows.Forms.Label
    Friend WithEvents DateTimePickerDari As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePickerSampai As System.Windows.Forms.DateTimePicker
    Friend WithEvents ComboBoxBulan As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBoxTahun As System.Windows.Forms.ComboBox
    Friend WithEvents ButtonFilter As System.Windows.Forms.Button
    Friend WithEvents ButtonRefresh As System.Windows.Forms.Button
    Friend WithEvents ButtonPrint As System.Windows.Forms.Button
    Friend WithEvents PanelGrid As System.Windows.Forms.Panel
    Friend WithEvents DataGridViewLog As System.Windows.Forms.DataGridView
    Friend WithEvents PanelFooter As System.Windows.Forms.Panel
    Friend WithEvents LabelTotalRecord As System.Windows.Forms.Label
    Friend WithEvents ButtonClose As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents PrintDialog1 As PrintDialog
End Class