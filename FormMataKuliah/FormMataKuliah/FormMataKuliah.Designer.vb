<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormMataKuliah
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Dim DataGridViewCellStyle3 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As DataGridViewCellStyle = New DataGridViewCellStyle()
        pnlHeader = New Panel()
        lblDate = New Label()
        lblClock = New Label()
        lblPageTitle = New Label()
        tmrClock = New Timer(components)
        pnlFormInput = New Panel()
        lblHint = New Label()
        btnReset = New Button()
        btnHapus = New Button()
        btnUbah = New Button()
        btnSimpan = New Button()
        cboSKS = New ComboBox()
        lblSKS = New Label()
        txtNamaMK = New TextBox()
        lblNamaMK = New Label()
        txtKodeMK = New TextBox()
        lblKodeMK = New Label()
        pnlCardHeader = New Panel()
        lblModeBadge = New Label()
        lblFormTitle = New Label()
        pnlTabel = New Panel()
        dgvMataKuliah = New DataGridView()
        colNo = New DataGridViewTextBoxColumn()
        kodeMK = New DataGridViewTextBoxColumn()
        namaMK = New DataGridViewTextBoxColumn()
        sks = New DataGridViewTextBoxColumn()
        pnlToolbar = New Panel()
        lblJumlahData = New Label()
        cmbFilterSKS = New ComboBox()
        txtCari = New TextBox()
        pnlTabelHeader = New Panel()
        lblTabelTitle = New Label()
        epValidasi = New ErrorProvider(components)
        pnlHeader.SuspendLayout()
        pnlFormInput.SuspendLayout()
        pnlCardHeader.SuspendLayout()
        pnlTabel.SuspendLayout()
        CType(dgvMataKuliah, ComponentModel.ISupportInitialize).BeginInit()
        pnlToolbar.SuspendLayout()
        pnlTabelHeader.SuspendLayout()
        CType(epValidasi, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' pnlHeader
        ' 
        pnlHeader.BackColor = Color.White
        pnlHeader.Controls.Add(lblDate)
        pnlHeader.Controls.Add(lblClock)
        pnlHeader.Controls.Add(lblPageTitle)
        pnlHeader.Dock = DockStyle.Top
        pnlHeader.Location = New Point(0, 0)
        pnlHeader.Margin = New Padding(5)
        pnlHeader.Name = "pnlHeader"
        pnlHeader.Padding = New Padding(32, 0, 32, 0)
        pnlHeader.Size = New Size(1716, 112)
        pnlHeader.TabIndex = 0
        ' 
        ' lblDate
        ' 
        lblDate.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        lblDate.Font = New Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblDate.ForeColor = Color.FromArgb(CByte(106), CByte(144), CByte(144))
        lblDate.Location = New Point(1299, 64)
        lblDate.Margin = New Padding(5, 0, 5, 0)
        lblDate.Name = "lblDate"
        lblDate.Size = New Size(358, 32)
        lblDate.TabIndex = 3
        lblDate.Text = "-"
        lblDate.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' lblClock
        ' 
        lblClock.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        lblClock.Font = New Font("Segoe UI", 12.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblClock.ForeColor = Color.FromArgb(CByte(61), CByte(107), CByte(109))
        lblClock.Location = New Point(1364, 14)
        lblClock.Margin = New Padding(5, 0, 5, 0)
        lblClock.Name = "lblClock"
        lblClock.Size = New Size(292, 48)
        lblClock.TabIndex = 2
        lblClock.Text = "00:00:00"
        lblClock.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' lblPageTitle
        ' 
        lblPageTitle.AutoSize = True
        lblPageTitle.Font = New Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblPageTitle.ForeColor = Color.FromArgb(CByte(28), CByte(51), CByte(51))
        lblPageTitle.Location = New Point(32, 42)
        lblPageTitle.Margin = New Padding(5, 0, 5, 0)
        lblPageTitle.Name = "lblPageTitle"
        lblPageTitle.Size = New Size(385, 60)
        lblPageTitle.TabIndex = 1
        lblPageTitle.Text = "Data Mata Kuliah"
        ' 
        ' tmrClock
        ' 
        tmrClock.Enabled = True
        tmrClock.Interval = 1000
        ' 
        ' pnlFormInput
        ' 
        pnlFormInput.BackColor = Color.White
        pnlFormInput.Controls.Add(lblHint)
        pnlFormInput.Controls.Add(btnReset)
        pnlFormInput.Controls.Add(btnHapus)
        pnlFormInput.Controls.Add(btnUbah)
        pnlFormInput.Controls.Add(btnSimpan)
        pnlFormInput.Controls.Add(cboSKS)
        pnlFormInput.Controls.Add(lblSKS)
        pnlFormInput.Controls.Add(txtNamaMK)
        pnlFormInput.Controls.Add(lblNamaMK)
        pnlFormInput.Controls.Add(txtKodeMK)
        pnlFormInput.Controls.Add(lblKodeMK)
        pnlFormInput.Controls.Add(pnlCardHeader)
        pnlFormInput.Dock = DockStyle.Top
        pnlFormInput.Location = New Point(0, 112)
        pnlFormInput.Margin = New Padding(5)
        pnlFormInput.Name = "pnlFormInput"
        pnlFormInput.Padding = New Padding(32, 26, 32, 26)
        pnlFormInput.Size = New Size(1716, 326)
        pnlFormInput.TabIndex = 1
        ' 
        ' lblHint
        ' 
        lblHint.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        lblHint.AutoSize = True
        lblHint.Font = New Font("Segoe UI", 7.8F, FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        lblHint.ForeColor = Color.FromArgb(CByte(106), CByte(144), CByte(144))
        lblHint.Location = New Point(1406, 262)
        lblHint.Margin = New Padding(5, 0, 5, 0)
        lblHint.Name = "lblHint"
        lblHint.Size = New Size(248, 30)
        lblHint.TabIndex = 17
        lblHint.Text = "Field bertanda * wajib diisi"
        ' 
        ' btnReset
        ' 
        btnReset.BackColor = Color.FromArgb(CByte(207), CByte(222), CByte(222))
        btnReset.FlatStyle = FlatStyle.Flat
        btnReset.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnReset.ForeColor = Color.FromArgb(CByte(28), CByte(51), CByte(51))
        btnReset.Location = New Point(650, 235)
        btnReset.Margin = New Padding(5)
        btnReset.Name = "btnReset"
        btnReset.Size = New Size(195, 54)
        btnReset.TabIndex = 16
        btnReset.Text = "Batal"
        btnReset.UseVisualStyleBackColor = False
        ' 
        ' btnHapus
        ' 
        btnHapus.BackColor = Color.FromArgb(CByte(192), CByte(87), CByte(74))
        btnHapus.Enabled = False
        btnHapus.FlatAppearance.BorderSize = 0
        btnHapus.FlatStyle = FlatStyle.Flat
        btnHapus.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnHapus.ForeColor = Color.White
        btnHapus.Location = New Point(429, 235)
        btnHapus.Margin = New Padding(5)
        btnHapus.Name = "btnHapus"
        btnHapus.Size = New Size(179, 54)
        btnHapus.TabIndex = 15
        btnHapus.Text = "Hapus"
        btnHapus.UseVisualStyleBackColor = False
        ' 
        ' btnUbah
        ' 
        btnUbah.BackColor = Color.FromArgb(CByte(212), CByte(136), CByte(58))
        btnUbah.Enabled = False
        btnUbah.FlatAppearance.BorderSize = 0
        btnUbah.FlatStyle = FlatStyle.Flat
        btnUbah.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnUbah.ForeColor = Color.White
        btnUbah.Location = New Point(231, 235)
        btnUbah.Margin = New Padding(5)
        btnUbah.Name = "btnUbah"
        btnUbah.Size = New Size(179, 54)
        btnUbah.TabIndex = 14
        btnUbah.Text = "Ubah"
        btnUbah.UseVisualStyleBackColor = False
        ' 
        ' btnSimpan
        ' 
        btnSimpan.BackColor = Color.FromArgb(CByte(74), CByte(124), CByte(126))
        btnSimpan.FlatAppearance.BorderSize = 0
        btnSimpan.FlatStyle = FlatStyle.Flat
        btnSimpan.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnSimpan.ForeColor = Color.White
        btnSimpan.Location = New Point(32, 235)
        btnSimpan.Margin = New Padding(5)
        btnSimpan.Name = "btnSimpan"
        btnSimpan.Size = New Size(179, 54)
        btnSimpan.TabIndex = 13
        btnSimpan.Text = "Simpan"
        btnSimpan.UseVisualStyleBackColor = False
        ' 
        ' cboSKS
        ' 
        cboSKS.DropDownStyle = ComboBoxStyle.DropDownList
        cboSKS.FormattingEnabled = True
        cboSKS.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6"})
        cboSKS.Location = New Point(959, 125)
        cboSKS.Margin = New Padding(5)
        cboSKS.Name = "cboSKS"
        cboSKS.Size = New Size(176, 40)
        cboSKS.TabIndex = 6
        ' 
        ' lblSKS
        ' 
        lblSKS.AutoSize = True
        lblSKS.Location = New Point(959, 96)
        lblSKS.Margin = New Padding(5, 0, 5, 0)
        lblSKS.Name = "lblSKS"
        lblSKS.Size = New Size(71, 32)
        lblSKS.TabIndex = 9
        lblSKS.Text = "SKS *"
        ' 
        ' txtNamaMK
        ' 
        txtNamaMK.BackColor = Color.White
        txtNamaMK.Font = New Font("Segoe UI", 9.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtNamaMK.Location = New Point(318, 125)
        txtNamaMK.Margin = New Padding(5)
        txtNamaMK.MaxLength = 100
        txtNamaMK.Name = "txtNamaMK"
        txtNamaMK.Size = New Size(615, 39)
        txtNamaMK.TabIndex = 2
        ' 
        ' lblNamaMK
        ' 
        lblNamaMK.AutoSize = True
        lblNamaMK.Location = New Point(318, 96)
        lblNamaMK.Margin = New Padding(5, 0, 5, 0)
        lblNamaMK.Name = "lblNamaMK"
        lblNamaMK.Size = New Size(228, 32)
        lblNamaMK.TabIndex = 4
        lblNamaMK.Text = "Nama Mata Kuliah *"
        ' 
        ' txtKodeMK
        ' 
        txtKodeMK.BackColor = Color.FromArgb(CByte(238), CByte(247), CByte(247))
        txtKodeMK.CharacterCasing = CharacterCasing.Upper
        txtKodeMK.Font = New Font("Courier New", 10.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtKodeMK.Location = New Point(32, 125)
        txtKodeMK.Margin = New Padding(5)
        txtKodeMK.MaxLength = 10
        txtKodeMK.Name = "txtKodeMK"
        txtKodeMK.Size = New Size(258, 38)
        txtKodeMK.TabIndex = 1
        ' 
        ' lblKodeMK
        ' 
        lblKodeMK.AutoSize = True
        lblKodeMK.Location = New Point(32, 96)
        lblKodeMK.Margin = New Padding(5, 0, 5, 0)
        lblKodeMK.Name = "lblKodeMK"
        lblKodeMK.Size = New Size(219, 32)
        lblKodeMK.TabIndex = 3
        lblKodeMK.Text = "Kode Mata Kuliah *"
        ' 
        ' pnlCardHeader
        ' 
        pnlCardHeader.BackColor = Color.FromArgb(CByte(243), CByte(249), CByte(249))
        pnlCardHeader.Controls.Add(lblModeBadge)
        pnlCardHeader.Controls.Add(lblFormTitle)
        pnlCardHeader.Dock = DockStyle.Top
        pnlCardHeader.Location = New Point(32, 26)
        pnlCardHeader.Margin = New Padding(5)
        pnlCardHeader.Name = "pnlCardHeader"
        pnlCardHeader.Padding = New Padding(20, 0, 20, 0)
        pnlCardHeader.Size = New Size(1652, 64)
        pnlCardHeader.TabIndex = 2
        ' 
        ' lblModeBadge
        ' 
        lblModeBadge.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        lblModeBadge.AutoSize = True
        lblModeBadge.Location = New Point(1267, 19)
        lblModeBadge.Margin = New Padding(5, 0, 5, 0)
        lblModeBadge.Name = "lblModeBadge"
        lblModeBadge.Size = New Size(196, 32)
        lblModeBadge.TabIndex = 1
        lblModeBadge.Text = "● TAMBAH BARU"
        lblModeBadge.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' lblFormTitle
        ' 
        lblFormTitle.AutoSize = True
        lblFormTitle.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblFormTitle.ForeColor = Color.FromArgb(CByte(28), CByte(51), CByte(51))
        lblFormTitle.Location = New Point(20, 19)
        lblFormTitle.Margin = New Padding(5, 0, 5, 0)
        lblFormTitle.Name = "lblFormTitle"
        lblFormTitle.Size = New Size(346, 32)
        lblFormTitle.TabIndex = 0
        lblFormTitle.Text = "Form Input Data Mata Kuliah"
        ' 
        ' pnlTabel
        ' 
        pnlTabel.BackColor = Color.White
        pnlTabel.Controls.Add(dgvMataKuliah)
        pnlTabel.Controls.Add(pnlToolbar)
        pnlTabel.Controls.Add(pnlTabelHeader)
        pnlTabel.Dock = DockStyle.Fill
        pnlTabel.Location = New Point(0, 438)
        pnlTabel.Margin = New Padding(5)
        pnlTabel.Name = "pnlTabel"
        pnlTabel.Padding = New Padding(26, 19, 26, 19)
        pnlTabel.Size = New Size(1716, 639)
        pnlTabel.TabIndex = 2
        ' 
        ' dgvMataKuliah
        ' 
        dgvMataKuliah.AllowUserToAddRows = False
        dgvMataKuliah.AllowUserToDeleteRows = False
        dgvMataKuliah.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvMataKuliah.BackgroundColor = Color.White
        dgvMataKuliah.BorderStyle = BorderStyle.None
        dgvMataKuliah.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        dgvMataKuliah.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvMataKuliah.Columns.AddRange(New DataGridViewColumn() {colNo, kodeMK, namaMK, sks})
        dgvMataKuliah.Dock = DockStyle.Fill
        dgvMataKuliah.GridColor = Color.FromArgb(CByte(228), CByte(240), CByte(240))
        dgvMataKuliah.Location = New Point(26, 160)
        dgvMataKuliah.Margin = New Padding(5)
        dgvMataKuliah.MultiSelect = False
        dgvMataKuliah.Name = "dgvMataKuliah"
        dgvMataKuliah.ReadOnly = True
        dgvMataKuliah.RowHeadersVisible = False
        dgvMataKuliah.RowHeadersWidth = 51
        dgvMataKuliah.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvMataKuliah.Size = New Size(1664, 460)
        dgvMataKuliah.TabIndex = 2
        ' 
        ' colNo
        ' 
        colNo.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        colNo.DataPropertyName = "colNo"
        DataGridViewCellStyle1.BackColor = Color.FromArgb(CByte(61), CByte(107), CByte(109))
        DataGridViewCellStyle1.Font = New Font("Segoe UI", 7.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle1.ForeColor = Color.White
        colNo.DefaultCellStyle = DataGridViewCellStyle1
        colNo.HeaderText = "No"
        colNo.MinimumWidth = 6
        colNo.Name = "colNo"
        colNo.ReadOnly = True
        colNo.Width = 150
        ' 
        ' kodeMK
        ' 
        kodeMK.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        kodeMK.DataPropertyName = "kodeMK"
        DataGridViewCellStyle2.BackColor = Color.FromArgb(CByte(61), CByte(107), CByte(109))
        DataGridViewCellStyle2.Font = New Font("Courier New", 9.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle2.ForeColor = Color.White
        kodeMK.DefaultCellStyle = DataGridViewCellStyle2
        kodeMK.HeaderText = "Kode MK"
        kodeMK.MinimumWidth = 6
        kodeMK.Name = "kodeMK"
        kodeMK.ReadOnly = True
        kodeMK.Width = 200
        ' 
        ' namaMK
        ' 
        namaMK.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        namaMK.DataPropertyName = "namaMK"
        DataGridViewCellStyle3.BackColor = Color.FromArgb(CByte(61), CByte(107), CByte(109))
        DataGridViewCellStyle3.Font = New Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle3.ForeColor = Color.White
        namaMK.DefaultCellStyle = DataGridViewCellStyle3
        namaMK.HeaderText = "Nama Mata Kuliah"
        namaMK.MinimumWidth = 6
        namaMK.Name = "namaMK"
        namaMK.ReadOnly = True
        ' 
        ' sks
        ' 
        sks.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        sks.DataPropertyName = "sks"
        DataGridViewCellStyle4.BackColor = Color.FromArgb(CByte(61), CByte(107), CByte(109))
        DataGridViewCellStyle4.Font = New Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle4.ForeColor = Color.White
        sks.DefaultCellStyle = DataGridViewCellStyle4
        sks.HeaderText = "SKS"
        sks.MinimumWidth = 6
        sks.Name = "sks"
        sks.ReadOnly = True
        sks.Width = 200
        ' 
        ' pnlToolbar
        ' 
        pnlToolbar.BackColor = Color.FromArgb(CByte(243), CByte(249), CByte(249))
        pnlToolbar.Controls.Add(lblJumlahData)
        pnlToolbar.Controls.Add(cmbFilterSKS)
        pnlToolbar.Controls.Add(txtCari)
        pnlToolbar.Dock = DockStyle.Top
        pnlToolbar.Location = New Point(26, 83)
        pnlToolbar.Margin = New Padding(5)
        pnlToolbar.Name = "pnlToolbar"
        pnlToolbar.Padding = New Padding(20, 13, 20, 13)
        pnlToolbar.Size = New Size(1664, 77)
        pnlToolbar.TabIndex = 1
        ' 
        ' lblJumlahData
        ' 
        lblJumlahData.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        lblJumlahData.AutoSize = True
        lblJumlahData.Font = New Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblJumlahData.ForeColor = Color.FromArgb(CByte(106), CByte(144), CByte(144))
        lblJumlahData.Location = New Point(671, 26)
        lblJumlahData.Margin = New Padding(5, 0, 5, 0)
        lblJumlahData.Name = "lblJumlahData"
        lblJumlahData.Size = New Size(71, 30)
        lblJumlahData.TabIndex = 3
        lblJumlahData.Text = "0 data"
        ' 
        ' cmbFilterSKS
        ' 
        cmbFilterSKS.DropDownStyle = ComboBoxStyle.DropDownList
        cmbFilterSKS.FormattingEnabled = True
        cmbFilterSKS.Items.AddRange(New Object() {"-- Filter SKS --", "1", "2", "3", "4", "5", "6"})
        cmbFilterSKS.Location = New Point(462, 16)
        cmbFilterSKS.Margin = New Padding(5)
        cmbFilterSKS.Name = "cmbFilterSKS"
        cmbFilterSKS.Size = New Size(241, 40)
        cmbFilterSKS.TabIndex = 1
        ' 
        ' txtCari
        ' 
        txtCari.BackColor = Color.White
        txtCari.BorderStyle = BorderStyle.FixedSingle
        txtCari.Location = New Point(20, 16)
        txtCari.Margin = New Padding(5)
        txtCari.Name = "txtCari"
        txtCari.PlaceholderText = "Cari Kode MK atau Nama.."
        txtCari.Size = New Size(421, 39)
        txtCari.TabIndex = 0
        ' 
        ' pnlTabelHeader
        ' 
        pnlTabelHeader.BackColor = Color.FromArgb(CByte(243), CByte(249), CByte(249))
        pnlTabelHeader.Controls.Add(lblTabelTitle)
        pnlTabelHeader.Dock = DockStyle.Top
        pnlTabelHeader.Location = New Point(26, 19)
        pnlTabelHeader.Margin = New Padding(5)
        pnlTabelHeader.Name = "pnlTabelHeader"
        pnlTabelHeader.Padding = New Padding(20, 0, 20, 0)
        pnlTabelHeader.Size = New Size(1664, 64)
        pnlTabelHeader.TabIndex = 0
        ' 
        ' lblTabelTitle
        ' 
        lblTabelTitle.AutoSize = True
        lblTabelTitle.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTabelTitle.ForeColor = Color.FromArgb(CByte(28), CByte(51), CByte(51))
        lblTabelTitle.Location = New Point(20, 19)
        lblTabelTitle.Margin = New Padding(5, 0, 5, 0)
        lblTabelTitle.Name = "lblTabelTitle"
        lblTabelTitle.Size = New Size(230, 32)
        lblTabelTitle.TabIndex = 0
        lblTabelTitle.Text = "Daftar Mata Kuliah"
        ' 
        ' epValidasi
        ' 
        epValidasi.ContainerControl = Me
        ' 
        ' FormMataKuliah
        ' 
        AutoScaleDimensions = New SizeF(13F, 32F)
        AutoScaleMode = AutoScaleMode.Font
        AutoScroll = True
        BackColor = Color.FromArgb(CByte(207), CByte(222), CByte(222))
        ClientSize = New Size(1716, 1077)
        Controls.Add(pnlTabel)
        Controls.Add(pnlFormInput)
        Controls.Add(pnlHeader)
        Margin = New Padding(5)
        MinimumSize = New Size(1710, 1109)
        Name = "FormMataKuliah"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Data Mahasiswa — Prodi XYZ"
        WindowState = FormWindowState.Maximized
        pnlHeader.ResumeLayout(False)
        pnlHeader.PerformLayout()
        pnlFormInput.ResumeLayout(False)
        pnlFormInput.PerformLayout()
        pnlCardHeader.ResumeLayout(False)
        pnlCardHeader.PerformLayout()
        pnlTabel.ResumeLayout(False)
        CType(dgvMataKuliah, ComponentModel.ISupportInitialize).EndInit()
        pnlToolbar.ResumeLayout(False)
        pnlToolbar.PerformLayout()
        pnlTabelHeader.ResumeLayout(False)
        pnlTabelHeader.PerformLayout()
        CType(epValidasi, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents pnlHeader As Panel
    Friend WithEvents lblPageTitle As Label
    Friend WithEvents lblClock As Label
    Friend WithEvents lblDate As Label
    Friend WithEvents tmrClock As Timer
    Friend WithEvents pnlFormInput As Panel
    Friend WithEvents pnlCardHeader As Panel
    Friend WithEvents lblFormTitle As Label
    Friend WithEvents lblModeBadge As Label
    Friend WithEvents txtKodeMK As TextBox
    Friend WithEvents lblKodeMK As Label
    Friend WithEvents lblNamaMK As Label
    Friend WithEvents txtNamaMK As TextBox
    Friend WithEvents lblSKS As Label
    Friend WithEvents cboSKS As ComboBox
    Friend WithEvents btnSimpan As Button
    Friend WithEvents btnUbah As Button
    Friend WithEvents btnHapus As Button
    Friend WithEvents lblHint As Label
    Friend WithEvents btnReset As Button
    Friend WithEvents pnlTabel As Panel
    Friend WithEvents pnlTabelHeader As Panel
    Friend WithEvents pnlToolbar As Panel
    Friend WithEvents lblTabelTitle As Label
    Friend WithEvents txtCari As TextBox
    Friend WithEvents cmbFilterJK As ComboBox
    Friend WithEvents cmbFilterSKS As ComboBox
    Friend WithEvents lblJumlahData As Label
    Friend WithEvents dgvMataKuliah As DataGridView
    Friend WithEvents epValidasi As ErrorProvider


    Friend WithEvents colNo As DataGridViewTextBoxColumn
    Friend WithEvents kodeMK As DataGridViewTextBoxColumn
    Friend WithEvents namaMK As DataGridViewTextBoxColumn
    Friend WithEvents sks As DataGridViewTextBoxColumn
End Class
