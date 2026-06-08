<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormLogAktivitas
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
        Dim DataGridViewCellStyle3 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormLogAktivitas))
        PanelHeader = New Panel()
        LabelTitle = New Label()
        PanelFilter = New Panel()
        LabelFilter = New Label()
        LabelTanggalDari = New Label()
        LabelTanggalSampai = New Label()
        LabelBulan = New Label()
        LabelTahun = New Label()
        LabelCari = New Label()
        DateTimePickerDari = New DateTimePicker()
        DateTimePickerSampai = New DateTimePicker()
        ComboBoxBulan = New ComboBox()
        ComboBoxTahun = New ComboBox()
        TextBoxCari = New TextBox()
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
        LabelTitle.Size = New Size(416, 55)
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
        PanelFilter.Controls.Add(LabelCari)
        PanelFilter.Controls.Add(DateTimePickerDari)
        PanelFilter.Controls.Add(DateTimePickerSampai)
        PanelFilter.Controls.Add(ComboBoxBulan)
        PanelFilter.Controls.Add(ComboBoxTahun)
        PanelFilter.Controls.Add(TextBoxCari)
        PanelFilter.Controls.Add(ButtonFilter)
        PanelFilter.Controls.Add(ButtonRefresh)
        PanelFilter.Controls.Add(ButtonPrint)
        PanelFilter.Dock = DockStyle.Top
        PanelFilter.Location = New Point(0, 80)
        PanelFilter.Name = "PanelFilter"
        PanelFilter.Padding = New Padding(20, 10, 20, 10)
        PanelFilter.Size = New Size(1000, 150)
        PanelFilter.TabIndex = 1
        ' 
        ' LabelFilter
        ' 
        LabelFilter.AutoSize = True
        LabelFilter.Font = New Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        LabelFilter.ForeColor = Color.FromArgb(CByte(74), CByte(144), CByte(144))
        LabelFilter.Location = New Point(23, -1)
        LabelFilter.Name = "LabelFilter"
        LabelFilter.Size = New Size(180, 31)
        LabelFilter.TabIndex = 0
        LabelFilter.Text = "Filter Pencarian"
        ' 
        ' LabelTanggalDari
        ' 
        LabelTanggalDari.AutoSize = True
        LabelTanggalDari.Font = New Font("Segoe UI", 9.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LabelTanggalDari.ForeColor = Color.FromArgb(CByte(74), CByte(144), CByte(144))
        LabelTanggalDari.Location = New Point(23, 30)
        LabelTanggalDari.Name = "LabelTanggalDari"
        LabelTanggalDari.Size = New Size(114, 25)
        LabelTanggalDari.TabIndex = 1
        LabelTanggalDari.Text = "Tanggal Dari:"
        ' 
        ' LabelTanggalSampai
        ' 
        LabelTanggalSampai.AutoSize = True
        LabelTanggalSampai.Font = New Font("Segoe UI", 9.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LabelTanggalSampai.ForeColor = Color.FromArgb(CByte(74), CByte(144), CByte(144))
        LabelTanggalSampai.Location = New Point(200, 30)
        LabelTanggalSampai.Name = "LabelTanggalSampai"
        LabelTanggalSampai.Size = New Size(141, 25)
        LabelTanggalSampai.TabIndex = 2
        LabelTanggalSampai.Text = "Tanggal Sampai:"
        ' 
        ' LabelBulan
        ' 
        LabelBulan.AutoSize = True
        LabelBulan.Font = New Font("Segoe UI", 9.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LabelBulan.ForeColor = Color.FromArgb(CByte(74), CByte(144), CByte(144))
        LabelBulan.Location = New Point(390, 30)
        LabelBulan.Name = "LabelBulan"
        LabelBulan.Size = New Size(59, 25)
        LabelBulan.TabIndex = 3
        LabelBulan.Text = "Bulan:"
        ' 
        ' LabelTahun
        ' 
        LabelTahun.AutoSize = True
        LabelTahun.Font = New Font("Segoe UI", 9.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LabelTahun.ForeColor = Color.FromArgb(CByte(74), CByte(144), CByte(144))
        LabelTahun.Location = New Point(540, 30)
        LabelTahun.Name = "LabelTahun"
        LabelTahun.Size = New Size(62, 25)
        LabelTahun.TabIndex = 4
        LabelTahun.Text = "Tahun:"
        ' 
        ' LabelCari
        ' 
        LabelCari.AutoSize = True
        LabelCari.Font = New Font("Segoe UI", 9.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LabelCari.ForeColor = Color.FromArgb(CByte(74), CByte(144), CByte(144))
        LabelCari.Location = New Point(650, 30)
        LabelCari.Name = "LabelCari"
        LabelCari.Size = New Size(46, 25)
        LabelCari.TabIndex = 12
        LabelCari.Text = "Cari:"
        ' 
        ' DateTimePickerDari
        ' 
        DateTimePickerDari.CalendarForeColor = Color.FromArgb(CByte(74), CByte(144), CByte(144))
        DateTimePickerDari.CalendarMonthBackground = Color.White
        DateTimePickerDari.CalendarTitleForeColor = Color.FromArgb(CByte(74), CByte(144), CByte(144))
        DateTimePickerDari.CustomFormat = "dd MMMM yyyy"
        DateTimePickerDari.Font = New Font("Segoe UI", 9.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DateTimePickerDari.Format = DateTimePickerFormat.Custom
        DateTimePickerDari.Location = New Point(23, 58)
        DateTimePickerDari.Name = "DateTimePickerDari"
        DateTimePickerDari.Size = New Size(158, 31)
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
        DateTimePickerSampai.Location = New Point(200, 58)
        DateTimePickerSampai.Name = "DateTimePickerSampai"
        DateTimePickerSampai.Size = New Size(158, 31)
        DateTimePickerSampai.TabIndex = 6
        ' 
        ' ComboBoxBulan
        ' 
        ComboBoxBulan.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBoxBulan.Font = New Font("Segoe UI", 9.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ComboBoxBulan.FormattingEnabled = True
        ComboBoxBulan.Items.AddRange(New Object() {"Semua Bulan", "Januari", "Februari", "Maret", "April", "Mei", "Juni", "Juli", "Agustus", "September", "Oktober", "November", "Desember"})
        ComboBoxBulan.Location = New Point(390, 58)
        ComboBoxBulan.Name = "ComboBoxBulan"
        ComboBoxBulan.Size = New Size(130, 33)
        ComboBoxBulan.TabIndex = 7
        ' 
        ' ComboBoxTahun
        ' 
        ComboBoxTahun.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBoxTahun.Font = New Font("Segoe UI", 9.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ComboBoxTahun.FormattingEnabled = True
        ComboBoxTahun.Location = New Point(540, 58)
        ComboBoxTahun.Name = "ComboBoxTahun"
        ComboBoxTahun.Size = New Size(90, 33)
        ComboBoxTahun.TabIndex = 8
        ' 
        ' TextBoxCari
        ' 
        TextBoxCari.BorderStyle = BorderStyle.FixedSingle
        TextBoxCari.Font = New Font("Segoe UI", 9.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TextBoxCari.Location = New Point(650, 58)
        TextBoxCari.Name = "TextBoxCari"
        TextBoxCari.PlaceholderText = "Cari aktivitas, admin, keterangan..."
        TextBoxCari.Size = New Size(220, 31)
        TextBoxCari.TabIndex = 9
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
        ButtonFilter.Location = New Point(23, 100)
        ButtonFilter.Name = "ButtonFilter"
        ButtonFilter.Size = New Size(100, 30)
        ButtonFilter.TabIndex = 10
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
        ButtonRefresh.Location = New Point(133, 100)
        ButtonRefresh.Name = "ButtonRefresh"
        ButtonRefresh.Size = New Size(100, 30)
        ButtonRefresh.TabIndex = 11
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
        ButtonPrint.Location = New Point(243, 100)
        ButtonPrint.Name = "ButtonPrint"
        ButtonPrint.Size = New Size(100, 30)
        ButtonPrint.TabIndex = 12
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
        PanelGrid.Location = New Point(0, 230)
        PanelGrid.Name = "PanelGrid"
        PanelGrid.Padding = New Padding(10, 8, 10, 8)
        PanelGrid.Size = New Size(1000, 360)
        PanelGrid.TabIndex = 2
        ' 
        ' DataGridViewLog
        ' 
        DataGridViewLog.AllowUserToAddRows = False
        DataGridViewLog.AllowUserToDeleteRows = False
        DataGridViewLog.BackgroundColor = Color.White
        DataGridViewLog.BorderStyle = BorderStyle.None
        DataGridViewLog.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
        DataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = Color.FromArgb(CByte(102), CByte(187), CByte(187))
        DataGridViewCellStyle3.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle3.ForeColor = Color.White
        DataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(CByte(74), CByte(144), CByte(144))
        DataGridViewCellStyle3.SelectionForeColor = Color.White
        DataGridViewCellStyle3.WrapMode = DataGridViewTriState.True
        DataGridViewLog.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        DataGridViewLog.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = Color.White
        DataGridViewCellStyle4.Font = New Font("Segoe UI", 9.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle4.ForeColor = Color.FromArgb(CByte(74), CByte(144), CByte(144))
        DataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(CByte(220), CByte(240), CByte(240))
        DataGridViewCellStyle4.SelectionForeColor = Color.FromArgb(CByte(74), CByte(144), CByte(144))
        DataGridViewCellStyle4.WrapMode = DataGridViewTriState.False
        DataGridViewLog.DefaultCellStyle = DataGridViewCellStyle4
        DataGridViewLog.Dock = DockStyle.Fill
        DataGridViewLog.EnableHeadersVisualStyles = False
        DataGridViewLog.GridColor = Color.FromArgb(CByte(220), CByte(240), CByte(240))
        DataGridViewLog.Location = New Point(10, 8)
        DataGridViewLog.MultiSelect = False
        DataGridViewLog.Name = "DataGridViewLog"
        DataGridViewLog.ReadOnly = True
        DataGridViewLog.RowHeadersVisible = False
        DataGridViewLog.RowHeadersWidth = 51
        DataGridViewLog.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DataGridViewLog.Size = New Size(978, 342)
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
        LabelTotalRecord.Size = New Size(184, 28)
        LabelTotalRecord.TabIndex = 1
        LabelTotalRecord.Text = "Total Record: 0 data"
        ' 
        ' ButtonClose
        ' 
        ButtonClose.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        ButtonClose.BackColor = Color.FromArgb(CByte(74), CByte(144), CByte(144))
        ButtonClose.FlatAppearance.BorderSize = 0
        ButtonClose.FlatAppearance.MouseDownBackColor = Color.FromArgb(CByte(54), CByte(124), CByte(124))
        ButtonClose.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(94), CByte(164), CByte(164))
        ButtonClose.FlatStyle = FlatStyle.Flat
        ButtonClose.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        ButtonClose.ForeColor = Color.White
        ButtonClose.Location = New Point(870, 12)
        ButtonClose.Name = "ButtonClose"
        ButtonClose.Size = New Size(110, 35)
        ButtonClose.TabIndex = 0
        ButtonClose.Text = "Tutup"
        ButtonClose.UseVisualStyleBackColor = False
        ' 
        ' PrintDocument1
        ' 
        PrintDocument1.DocumentName = "Log Aktivitas Sistem"
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
        AutoScaleDimensions = New SizeF(10.0F, 25.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(1000, 650)
        Controls.Add(PanelGrid)
        Controls.Add(PanelFooter)
        Controls.Add(PanelFilter)
        Controls.Add(PanelHeader)
        Font = New Font("Segoe UI", 9.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        FormBorderStyle = FormBorderStyle.None
        Name = "FormLogAktivitas"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Log Aktivitas"
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
    Friend WithEvents LabelFilter As Label
    Friend WithEvents LabelTanggalDari As Label
    Friend WithEvents LabelTanggalSampai As Label
    Friend WithEvents LabelBulan As Label
    Friend WithEvents LabelTahun As Label
    Friend WithEvents LabelCari As Label
    Friend WithEvents DateTimePickerDari As DateTimePicker
    Friend WithEvents DateTimePickerSampai As DateTimePicker
    Friend WithEvents ComboBoxBulan As ComboBox
    Friend WithEvents ComboBoxTahun As ComboBox
    Friend WithEvents TextBoxCari As TextBox
    Friend WithEvents ButtonFilter As Button
    Friend WithEvents ButtonRefresh As Button
    Friend WithEvents ButtonPrint As Button
    Friend WithEvents PanelGrid As Panel
    Friend WithEvents DataGridViewLog As DataGridView
    Friend WithEvents PanelFooter As Panel
    Friend WithEvents LabelTotalRecord As Label
    Friend WithEvents ButtonClose As Button
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents PrintDocument1 As Printing.PrintDocument
    Friend WithEvents PrintPreviewDialog1 As PrintPreviewDialog
    Friend WithEvents PrintDialog1 As PrintDialog
End Class