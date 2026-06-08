<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormDataMahasiswa
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
        Dim DataGridViewCellStyle5 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As DataGridViewCellStyle = New DataGridViewCellStyle()
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
        txtAlamat = New TextBox()
        lblAlamat = New Label()
        txtEmail = New TextBox()
        lblEmail = New Label()
        txtNoTelp = New TextBox()
        lblNoTelp = New Label()
        cmbAngkatan = New ComboBox()
        lblAngkatan = New Label()
        dtpTglLahir = New DateTimePicker()
        lblTglLahir = New Label()
        txtTempatLahir = New TextBox()
        lblTempatLahir = New Label()
        grpJK = New GroupBox()
        rbPerempuan = New RadioButton()
        rbLaki = New RadioButton()
        lblJK = New Label()
        txtNama = New TextBox()
        lblNama = New Label()
        txtNIM = New TextBox()
        lblNIM = New Label()
        pnlCardHeader = New Panel()
        lblModeBadge = New Label()
        lblFormTitle = New Label()
        pnlTabel = New Panel()
        dgvMahasiswa = New DataGridView()
        colNo = New DataGridViewTextBoxColumn()
        nim = New DataGridViewTextBoxColumn()
        namaMahasiswa = New DataGridViewTextBoxColumn()
        jenisKelamin = New DataGridViewTextBoxColumn()
        ttl = New DataGridViewTextBoxColumn()
        angkatan = New DataGridViewTextBoxColumn()
        noTelp = New DataGridViewTextBoxColumn()
        pnlToolbar = New Panel()
        lblJumlahData = New Label()
        cmbFilterJK = New ComboBox()
        cmbFilterAngk = New ComboBox()
        txtCari = New TextBox()
        pnlTabelHeader = New Panel()
        lblTabelTitle = New Label()
        epValidasi = New ErrorProvider(components)
        pnlHeader.SuspendLayout()
        pnlFormInput.SuspendLayout()
        grpJK.SuspendLayout()
        pnlCardHeader.SuspendLayout()
        pnlTabel.SuspendLayout()
        CType(dgvMahasiswa, ComponentModel.ISupportInitialize).BeginInit()
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
        pnlHeader.Margin = New Padding(4, 4, 4, 4)
        pnlHeader.Name = "pnlHeader"
        pnlHeader.Padding = New Padding(25, 0, 25, 0)
        pnlHeader.Size = New Size(1352, 88)
        pnlHeader.TabIndex = 0
        ' 
        ' lblDate
        ' 
        lblDate.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        lblDate.Font = New Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblDate.ForeColor = Color.FromArgb(CByte(106), CByte(144), CByte(144))
        lblDate.Location = New Point(1031, 50)
        lblDate.Margin = New Padding(4, 0, 4, 0)
        lblDate.Name = "lblDate"
        lblDate.Size = New Size(275, 25)
        lblDate.TabIndex = 3
        lblDate.Text = "Label1"
        lblDate.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' lblClock
        ' 
        lblClock.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        lblClock.Font = New Font("Segoe UI", 12.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblClock.ForeColor = Color.FromArgb(CByte(61), CByte(107), CByte(109))
        lblClock.Location = New Point(1081, 11)
        lblClock.Margin = New Padding(4, 0, 4, 0)
        lblClock.Name = "lblClock"
        lblClock.Size = New Size(225, 38)
        lblClock.TabIndex = 2
        lblClock.Text = "00:00:00"
        lblClock.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' lblPageTitle
        ' 
        lblPageTitle.AutoSize = True
        lblPageTitle.Font = New Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblPageTitle.ForeColor = Color.FromArgb(CByte(28), CByte(51), CByte(51))
        lblPageTitle.Location = New Point(25, 32)
        lblPageTitle.Margin = New Padding(4, 0, 4, 0)
        lblPageTitle.Name = "lblPageTitle"
        lblPageTitle.Size = New Size(273, 45)
        lblPageTitle.TabIndex = 1
        lblPageTitle.Text = "Data Mahasiswa"
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
        pnlFormInput.Controls.Add(txtAlamat)
        pnlFormInput.Controls.Add(lblAlamat)
        pnlFormInput.Controls.Add(txtEmail)
        pnlFormInput.Controls.Add(lblEmail)
        pnlFormInput.Controls.Add(txtNoTelp)
        pnlFormInput.Controls.Add(lblNoTelp)
        pnlFormInput.Controls.Add(cmbAngkatan)
        pnlFormInput.Controls.Add(lblAngkatan)
        pnlFormInput.Controls.Add(dtpTglLahir)
        pnlFormInput.Controls.Add(lblTglLahir)
        pnlFormInput.Controls.Add(txtTempatLahir)
        pnlFormInput.Controls.Add(lblTempatLahir)
        pnlFormInput.Controls.Add(grpJK)
        pnlFormInput.Controls.Add(lblJK)
        pnlFormInput.Controls.Add(txtNama)
        pnlFormInput.Controls.Add(lblNama)
        pnlFormInput.Controls.Add(txtNIM)
        pnlFormInput.Controls.Add(lblNIM)
        pnlFormInput.Controls.Add(pnlCardHeader)
        pnlFormInput.Dock = DockStyle.Top
        pnlFormInput.Location = New Point(0, 88)
        pnlFormInput.Margin = New Padding(4, 4, 4, 4)
        pnlFormInput.Name = "pnlFormInput"
        pnlFormInput.Padding = New Padding(25, 20, 25, 20)
        pnlFormInput.Size = New Size(1352, 492)
        pnlFormInput.TabIndex = 1
        ' 
        ' lblHint
        ' 
        lblHint.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        lblHint.AutoSize = True
        lblHint.Font = New Font("Segoe UI", 7.8F, FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        lblHint.ForeColor = Color.FromArgb(CByte(106), CByte(144), CByte(144))
        lblHint.Location = New Point(1114, 456)
        lblHint.Margin = New Padding(4, 0, 4, 0)
        lblHint.Name = "lblHint"
        lblHint.Size = New Size(195, 21)
        lblHint.TabIndex = 17
        lblHint.Text = "Field bertanda * wajib diisi"
        ' 
        ' btnReset
        ' 
        btnReset.BackColor = Color.FromArgb(CByte(207), CByte(222), CByte(222))
        btnReset.FlatStyle = FlatStyle.Flat
        btnReset.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnReset.ForeColor = Color.FromArgb(CByte(28), CByte(51), CByte(51))
        btnReset.Location = New Point(500, 435)
        btnReset.Margin = New Padding(4, 4, 4, 4)
        btnReset.Name = "btnReset"
        btnReset.Size = New Size(150, 42)
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
        btnHapus.Location = New Point(330, 435)
        btnHapus.Margin = New Padding(4, 4, 4, 4)
        btnHapus.Name = "btnHapus"
        btnHapus.Size = New Size(138, 42)
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
        btnUbah.Location = New Point(178, 435)
        btnUbah.Margin = New Padding(4, 4, 4, 4)
        btnUbah.Name = "btnUbah"
        btnUbah.Size = New Size(138, 42)
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
        btnSimpan.Location = New Point(25, 435)
        btnSimpan.Margin = New Padding(4, 4, 4, 4)
        btnSimpan.Name = "btnSimpan"
        btnSimpan.Size = New Size(138, 42)
        btnSimpan.TabIndex = 13
        btnSimpan.Text = "Simpan"
        btnSimpan.UseVisualStyleBackColor = False
        ' 
        ' txtAlamat
        ' 
        txtAlamat.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtAlamat.BackColor = Color.White
        txtAlamat.Font = New Font("Segoe UI", 9.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtAlamat.Location = New Point(25, 332)
        txtAlamat.Margin = New Padding(4, 4, 4, 4)
        txtAlamat.MaxLength = 200
        txtAlamat.Multiline = True
        txtAlamat.Name = "txtAlamat"
        txtAlamat.ScrollBars = ScrollBars.Vertical
        txtAlamat.Size = New Size(912, 74)
        txtAlamat.TabIndex = 9
        ' 
        ' lblAlamat
        ' 
        lblAlamat.AutoSize = True
        lblAlamat.Location = New Point(25, 310)
        lblAlamat.Margin = New Padding(4, 0, 4, 0)
        lblAlamat.Name = "lblAlamat"
        lblAlamat.Size = New Size(68, 25)
        lblAlamat.TabIndex = 12
        lblAlamat.Text = "Alamat"
        ' 
        ' txtEmail
        ' 
        txtEmail.BackColor = Color.White
        txtEmail.Font = New Font("Segoe UI", 9.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtEmail.Location = New Point(245, 255)
        txtEmail.Margin = New Padding(4, 4, 4, 4)
        txtEmail.MaxLength = 100
        txtEmail.Name = "txtEmail"
        txtEmail.Size = New Size(474, 31)
        txtEmail.TabIndex = 8
        ' 
        ' lblEmail
        ' 
        lblEmail.AutoSize = True
        lblEmail.Location = New Point(245, 232)
        lblEmail.Margin = New Padding(4, 0, 4, 0)
        lblEmail.Name = "lblEmail"
        lblEmail.Size = New Size(54, 25)
        lblEmail.TabIndex = 11
        lblEmail.Text = "Email"
        ' 
        ' txtNoTelp
        ' 
        txtNoTelp.BackColor = Color.White
        txtNoTelp.Font = New Font("Segoe UI", 9.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtNoTelp.Location = New Point(25, 255)
        txtNoTelp.Margin = New Padding(4, 4, 4, 4)
        txtNoTelp.MaxLength = 15
        txtNoTelp.Name = "txtNoTelp"
        txtNoTelp.Size = New Size(199, 31)
        txtNoTelp.TabIndex = 7
        ' 
        ' lblNoTelp
        ' 
        lblNoTelp.AutoSize = True
        lblNoTelp.Location = New Point(25, 232)
        lblNoTelp.Margin = New Padding(4, 0, 4, 0)
        lblNoTelp.Name = "lblNoTelp"
        lblNoTelp.Size = New Size(106, 25)
        lblNoTelp.TabIndex = 10
        lblNoTelp.Text = "No. Telepon"
        ' 
        ' cmbAngkatan
        ' 
        cmbAngkatan.DropDownStyle = ComboBoxStyle.DropDownList
        cmbAngkatan.FormattingEnabled = True
        cmbAngkatan.Items.AddRange(New Object() {"2021", "2022", "2023", "2024", "2025", "2026"})
        cmbAngkatan.Location = New Point(782, 186)
        cmbAngkatan.Margin = New Padding(4, 4, 4, 4)
        cmbAngkatan.Name = "cmbAngkatan"
        cmbAngkatan.Size = New Size(136, 33)
        cmbAngkatan.TabIndex = 6
        ' 
        ' lblAngkatan
        ' 
        lblAngkatan.AutoSize = True
        lblAngkatan.Location = New Point(782, 157)
        lblAngkatan.Margin = New Padding(4, 0, 4, 0)
        lblAngkatan.Name = "lblAngkatan"
        lblAngkatan.Size = New Size(101, 25)
        lblAngkatan.TabIndex = 9
        lblAngkatan.Text = "Angkatan *"
        ' 
        ' dtpTglLahir
        ' 
        dtpTglLahir.Location = New Point(535, 186)
        dtpTglLahir.Margin = New Padding(4, 4, 4, 4)
        dtpTglLahir.MaxDate = New Date(2026, 6, 3, 0, 0, 0, 0)
        dtpTglLahir.Name = "dtpTglLahir"
        dtpTglLahir.Size = New Size(236, 31)
        dtpTglLahir.TabIndex = 5
        dtpTglLahir.Value = New Date(2026, 6, 3, 0, 0, 0, 0)
        ' 
        ' lblTglLahir
        ' 
        lblTglLahir.AutoSize = True
        lblTglLahir.Location = New Point(535, 157)
        lblTglLahir.Margin = New Padding(4, 0, 4, 0)
        lblTglLahir.Name = "lblTglLahir"
        lblTglLahir.Size = New Size(115, 25)
        lblTglLahir.TabIndex = 8
        lblTglLahir.Text = "Tanggal Lahir"
        ' 
        ' txtTempatLahir
        ' 
        txtTempatLahir.BackColor = Color.White
        txtTempatLahir.Font = New Font("Segoe UI", 9.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtTempatLahir.Location = New Point(295, 186)
        txtTempatLahir.Margin = New Padding(4, 4, 4, 4)
        txtTempatLahir.MaxLength = 50
        txtTempatLahir.Name = "txtTempatLahir"
        txtTempatLahir.Size = New Size(224, 31)
        txtTempatLahir.TabIndex = 4
        ' 
        ' lblTempatLahir
        ' 
        lblTempatLahir.AutoSize = True
        lblTempatLahir.Location = New Point(295, 157)
        lblTempatLahir.Margin = New Padding(4, 0, 4, 0)
        lblTempatLahir.Name = "lblTempatLahir"
        lblTempatLahir.Size = New Size(112, 25)
        lblTempatLahir.TabIndex = 7
        lblTempatLahir.Text = "Tempat Lahir"
        ' 
        ' grpJK
        ' 
        grpJK.Controls.Add(rbPerempuan)
        grpJK.Controls.Add(rbLaki)
        grpJK.Location = New Point(25, 172)
        grpJK.Margin = New Padding(4, 4, 4, 4)
        grpJK.Name = "grpJK"
        grpJK.Padding = New Padding(4, 4, 4, 4)
        grpJK.Size = New Size(250, 45)
        grpJK.TabIndex = 6
        grpJK.TabStop = False
        ' 
        ' rbPerempuan
        ' 
        rbPerempuan.AutoSize = True
        rbPerempuan.Location = New Point(112, 12)
        rbPerempuan.Margin = New Padding(4, 4, 4, 4)
        rbPerempuan.Name = "rbPerempuan"
        rbPerempuan.Size = New Size(126, 29)
        rbPerempuan.TabIndex = 1
        rbPerempuan.TabStop = True
        rbPerempuan.Tag = "P"
        rbPerempuan.Text = "Perempuan"
        rbPerempuan.UseVisualStyleBackColor = True
        ' 
        ' rbLaki
        ' 
        rbLaki.AutoSize = True
        rbLaki.Location = New Point(10, 12)
        rbLaki.Margin = New Padding(4, 4, 4, 4)
        rbLaki.Name = "rbLaki"
        rbLaki.Size = New Size(100, 29)
        rbLaki.TabIndex = 0
        rbLaki.TabStop = True
        rbLaki.Tag = "L"
        rbLaki.Text = "Laki-laki"
        rbLaki.UseVisualStyleBackColor = True
        ' 
        ' lblJK
        ' 
        lblJK.AutoSize = True
        lblJK.Location = New Point(25, 141)
        lblJK.Margin = New Padding(4, 0, 4, 0)
        lblJK.Name = "lblJK"
        lblJK.Size = New Size(129, 25)
        lblJK.TabIndex = 5
        lblJK.Text = "Jenis Kelamin *"
        ' 
        ' txtNama
        ' 
        txtNama.BackColor = Color.White
        txtNama.Font = New Font("Segoe UI", 9.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtNama.Location = New Point(245, 98)
        txtNama.Margin = New Padding(4, 4, 4, 4)
        txtNama.MaxLength = 100
        txtNama.Name = "txtNama"
        txtNama.Size = New Size(474, 31)
        txtNama.TabIndex = 2
        ' 
        ' lblNama
        ' 
        lblNama.AutoSize = True
        lblNama.Location = New Point(245, 75)
        lblNama.Margin = New Padding(4, 0, 4, 0)
        lblNama.Name = "lblNama"
        lblNama.Size = New Size(144, 25)
        lblNama.TabIndex = 4
        lblNama.Text = "Nama Lengkap *"
        ' 
        ' txtNIM
        ' 
        txtNIM.BackColor = Color.FromArgb(CByte(238), CByte(247), CByte(247))
        txtNIM.CharacterCasing = CharacterCasing.Upper
        txtNIM.Font = New Font("Courier New", 10.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtNIM.Location = New Point(25, 98)
        txtNIM.Margin = New Padding(4, 4, 4, 4)
        txtNIM.MaxLength = 10
        txtNIM.Name = "txtNIM"
        txtNIM.Size = New Size(199, 31)
        txtNIM.TabIndex = 1
        ' 
        ' lblNIM
        ' 
        lblNIM.AutoSize = True
        lblNIM.Location = New Point(25, 75)
        lblNIM.Margin = New Padding(4, 0, 4, 0)
        lblNIM.Name = "lblNIM"
        lblNIM.Size = New Size(59, 25)
        lblNIM.TabIndex = 3
        lblNIM.Text = "NIM *"
        ' 
        ' pnlCardHeader
        ' 
        pnlCardHeader.BackColor = Color.FromArgb(CByte(243), CByte(249), CByte(249))
        pnlCardHeader.Controls.Add(lblModeBadge)
        pnlCardHeader.Controls.Add(lblFormTitle)
        pnlCardHeader.Dock = DockStyle.Top
        pnlCardHeader.Location = New Point(25, 20)
        pnlCardHeader.Margin = New Padding(4, 4, 4, 4)
        pnlCardHeader.Name = "pnlCardHeader"
        pnlCardHeader.Padding = New Padding(15, 0, 15, 0)
        pnlCardHeader.Size = New Size(1302, 50)
        pnlCardHeader.TabIndex = 2
        ' 
        ' lblModeBadge
        ' 
        lblModeBadge.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        lblModeBadge.AutoSize = True
        lblModeBadge.Location = New Point(1006, 15)
        lblModeBadge.Margin = New Padding(4, 0, 4, 0)
        lblModeBadge.Name = "lblModeBadge"
        lblModeBadge.Size = New Size(149, 25)
        lblModeBadge.TabIndex = 1
        lblModeBadge.Text = "● TAMBAH BARU"
        lblModeBadge.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' lblFormTitle
        ' 
        lblFormTitle.AutoSize = True
        lblFormTitle.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblFormTitle.ForeColor = Color.FromArgb(CByte(28), CByte(51), CByte(51))
        lblFormTitle.Location = New Point(15, 15)
        lblFormTitle.Margin = New Padding(4, 0, 4, 0)
        lblFormTitle.Name = "lblFormTitle"
        lblFormTitle.Size = New Size(249, 25)
        lblFormTitle.TabIndex = 0
        lblFormTitle.Text = "Form Input Data Mahasiswa"
        ' 
        ' pnlTabel
        ' 
        pnlTabel.BackColor = Color.White
        pnlTabel.Controls.Add(dgvMahasiswa)
        pnlTabel.Controls.Add(pnlToolbar)
        pnlTabel.Controls.Add(pnlTabelHeader)
        pnlTabel.Dock = DockStyle.Fill
        pnlTabel.Location = New Point(0, 580)
        pnlTabel.Margin = New Padding(4, 4, 4, 4)
        pnlTabel.Name = "pnlTabel"
        pnlTabel.Padding = New Padding(20, 15, 20, 15)
        pnlTabel.Size = New Size(1352, 261)
        pnlTabel.TabIndex = 2
        ' 
        ' dgvMahasiswa
        ' 
        dgvMahasiswa.AllowUserToAddRows = False
        dgvMahasiswa.AllowUserToDeleteRows = False
        dgvMahasiswa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvMahasiswa.BackgroundColor = Color.White
        dgvMahasiswa.BorderStyle = BorderStyle.None
        dgvMahasiswa.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        dgvMahasiswa.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvMahasiswa.Columns.AddRange(New DataGridViewColumn() {colNo, nim, namaMahasiswa, jenisKelamin, ttl, angkatan, noTelp})
        dgvMahasiswa.Dock = DockStyle.Fill
        dgvMahasiswa.GridColor = Color.FromArgb(CByte(228), CByte(240), CByte(240))
        dgvMahasiswa.Location = New Point(20, 125)
        dgvMahasiswa.Margin = New Padding(4, 4, 4, 4)
        dgvMahasiswa.MultiSelect = False
        dgvMahasiswa.Name = "dgvMahasiswa"
        dgvMahasiswa.ReadOnly = True
        dgvMahasiswa.RowHeadersVisible = False
        dgvMahasiswa.RowHeadersWidth = 51
        dgvMahasiswa.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvMahasiswa.Size = New Size(1312, 121)
        dgvMahasiswa.TabIndex = 2
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
        colNo.Width = 40
        ' 
        ' nim
        ' 
        nim.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        nim.DataPropertyName = "nim"
        DataGridViewCellStyle2.BackColor = Color.FromArgb(CByte(61), CByte(107), CByte(109))
        DataGridViewCellStyle2.Font = New Font("Courier New", 9.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle2.ForeColor = Color.White
        nim.DefaultCellStyle = DataGridViewCellStyle2
        nim.HeaderText = "NIM"
        nim.MinimumWidth = 6
        nim.Name = "nim"
        nim.ReadOnly = True
        nim.Width = 110
        ' 
        ' namaMahasiswa
        ' 
        namaMahasiswa.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        namaMahasiswa.DataPropertyName = "namaMahasiswa"
        DataGridViewCellStyle3.BackColor = Color.FromArgb(CByte(61), CByte(107), CByte(109))
        DataGridViewCellStyle3.Font = New Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle3.ForeColor = Color.White
        namaMahasiswa.DefaultCellStyle = DataGridViewCellStyle3
        namaMahasiswa.HeaderText = "Nama Mahasiswa"
        namaMahasiswa.MinimumWidth = 6
        namaMahasiswa.Name = "namaMahasiswa"
        namaMahasiswa.ReadOnly = True
        ' 
        ' jenisKelamin
        ' 
        jenisKelamin.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        jenisKelamin.DataPropertyName = "jenisKelamin"
        DataGridViewCellStyle4.BackColor = Color.FromArgb(CByte(61), CByte(107), CByte(109))
        DataGridViewCellStyle4.Font = New Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle4.ForeColor = Color.White
        jenisKelamin.DefaultCellStyle = DataGridViewCellStyle4
        jenisKelamin.HeaderText = "JK"
        jenisKelamin.MinimumWidth = 6
        jenisKelamin.Name = "jenisKelamin"
        jenisKelamin.ReadOnly = True
        jenisKelamin.Width = 50
        ' 
        ' ttl
        ' 
        ttl.DataPropertyName = "ttl"
        DataGridViewCellStyle5.BackColor = Color.FromArgb(CByte(61), CByte(107), CByte(109))
        DataGridViewCellStyle5.Font = New Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle5.ForeColor = Color.White
        ttl.DefaultCellStyle = DataGridViewCellStyle5
        ttl.HeaderText = "Tempat, Tanggal Lahir"
        ttl.MinimumWidth = 6
        ttl.Name = "ttl"
        ttl.ReadOnly = True
        ' 
        ' angkatan
        ' 
        angkatan.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        angkatan.DataPropertyName = "angkatan"
        DataGridViewCellStyle6.BackColor = Color.FromArgb(CByte(61), CByte(107), CByte(109))
        DataGridViewCellStyle6.Font = New Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle6.ForeColor = Color.White
        angkatan.DefaultCellStyle = DataGridViewCellStyle6
        angkatan.HeaderText = "Angkatan"
        angkatan.MinimumWidth = 6
        angkatan.Name = "angkatan"
        angkatan.ReadOnly = True
        angkatan.Width = 80
        ' 
        ' noTelp
        ' 
        noTelp.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        noTelp.DataPropertyName = "noTelp"
        DataGridViewCellStyle7.BackColor = Color.FromArgb(CByte(61), CByte(107), CByte(109))
        DataGridViewCellStyle7.Font = New Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle7.ForeColor = Color.White
        noTelp.DefaultCellStyle = DataGridViewCellStyle7
        noTelp.HeaderText = "No Telepon"
        noTelp.MinimumWidth = 6
        noTelp.Name = "noTelp"
        noTelp.ReadOnly = True
        noTelp.Width = 120
        ' 
        ' pnlToolbar
        ' 
        pnlToolbar.BackColor = Color.FromArgb(CByte(243), CByte(249), CByte(249))
        pnlToolbar.Controls.Add(lblJumlahData)
        pnlToolbar.Controls.Add(cmbFilterJK)
        pnlToolbar.Controls.Add(cmbFilterAngk)
        pnlToolbar.Controls.Add(txtCari)
        pnlToolbar.Dock = DockStyle.Top
        pnlToolbar.Location = New Point(20, 65)
        pnlToolbar.Margin = New Padding(4, 4, 4, 4)
        pnlToolbar.Name = "pnlToolbar"
        pnlToolbar.Padding = New Padding(15, 10, 15, 10)
        pnlToolbar.Size = New Size(1312, 60)
        pnlToolbar.TabIndex = 1
        ' 
        ' lblJumlahData
        ' 
        lblJumlahData.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        lblJumlahData.AutoSize = True
        lblJumlahData.Font = New Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblJumlahData.ForeColor = Color.FromArgb(CByte(106), CByte(144), CByte(144))
        lblJumlahData.Location = New Point(778, 25)
        lblJumlahData.Margin = New Padding(4, 0, 4, 0)
        lblJumlahData.Name = "lblJumlahData"
        lblJumlahData.Size = New Size(53, 21)
        lblJumlahData.TabIndex = 3
        lblJumlahData.Text = "0 data"
        ' 
        ' cmbFilterJK
        ' 
        cmbFilterJK.DropDownStyle = ComboBoxStyle.DropDownList
        cmbFilterJK.FormattingEnabled = True
        cmbFilterJK.Items.AddRange(New Object() {"Laki-laki", "Perempuan"})
        cmbFilterJK.Location = New Point(558, 12)
        cmbFilterJK.Margin = New Padding(4, 4, 4, 4)
        cmbFilterJK.Name = "cmbFilterJK"
        cmbFilterJK.Size = New Size(174, 33)
        cmbFilterJK.TabIndex = 2
        ' 
        ' cmbFilterAngk
        ' 
        cmbFilterAngk.DropDownStyle = ComboBoxStyle.DropDownList
        cmbFilterAngk.FormattingEnabled = True
        cmbFilterAngk.Items.AddRange(New Object() {"2021", "2022", "2023", "2024", "2025", "2026"})
        cmbFilterAngk.Location = New Point(355, 12)
        cmbFilterAngk.Margin = New Padding(4, 4, 4, 4)
        cmbFilterAngk.Name = "cmbFilterAngk"
        cmbFilterAngk.Size = New Size(186, 33)
        cmbFilterAngk.TabIndex = 1
        ' 
        ' txtCari
        ' 
        txtCari.BackColor = Color.White
        txtCari.BorderStyle = BorderStyle.FixedSingle
        txtCari.Location = New Point(15, 12)
        txtCari.Margin = New Padding(4, 4, 4, 4)
        txtCari.Name = "txtCari"
        txtCari.PlaceholderText = "Cari NIM atau Nama..."
        txtCari.Size = New Size(324, 31)
        txtCari.TabIndex = 0
        ' 
        ' pnlTabelHeader
        ' 
        pnlTabelHeader.BackColor = Color.FromArgb(CByte(243), CByte(249), CByte(249))
        pnlTabelHeader.Controls.Add(lblTabelTitle)
        pnlTabelHeader.Dock = DockStyle.Top
        pnlTabelHeader.Location = New Point(20, 15)
        pnlTabelHeader.Margin = New Padding(4, 4, 4, 4)
        pnlTabelHeader.Name = "pnlTabelHeader"
        pnlTabelHeader.Padding = New Padding(15, 0, 15, 0)
        pnlTabelHeader.Size = New Size(1312, 50)
        pnlTabelHeader.TabIndex = 0
        ' 
        ' lblTabelTitle
        ' 
        lblTabelTitle.AutoSize = True
        lblTabelTitle.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTabelTitle.ForeColor = Color.FromArgb(CByte(28), CByte(51), CByte(51))
        lblTabelTitle.Location = New Point(15, 15)
        lblTabelTitle.Margin = New Padding(4, 0, 4, 0)
        lblTabelTitle.Name = "lblTabelTitle"
        lblTabelTitle.Size = New Size(164, 25)
        lblTabelTitle.TabIndex = 0
        lblTabelTitle.Text = "Daftar Mahasiswa"
        ' 
        ' epValidasi
        ' 
        epValidasi.ContainerControl = Me
        ' 
        ' FormDataMahasiswa
        ' 
        AutoScaleDimensions = New SizeF(10.0F, 25.0F)
        AutoScaleMode = AutoScaleMode.Font
        AutoScroll = True
        BackColor = Color.FromArgb(CByte(207), CByte(222), CByte(222))
        ClientSize = New Size(1352, 841)
        Controls.Add(pnlTabel)
        Controls.Add(pnlFormInput)
        Controls.Add(pnlHeader)
        Margin = New Padding(4, 4, 4, 4)
        MinimumSize = New Size(1370, 886)
        Name = "FormDataMahasiswa"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Data Mahasiswa — Prodi XYZ"
        WindowState = FormWindowState.Maximized
        pnlHeader.ResumeLayout(False)
        pnlHeader.PerformLayout()
        pnlFormInput.ResumeLayout(False)
        pnlFormInput.PerformLayout()
        grpJK.ResumeLayout(False)
        grpJK.PerformLayout()
        pnlCardHeader.ResumeLayout(False)
        pnlCardHeader.PerformLayout()
        pnlTabel.ResumeLayout(False)
        CType(dgvMahasiswa, ComponentModel.ISupportInitialize).EndInit()
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
	Friend WithEvents txtNIM As TextBox
	Friend WithEvents lblNIM As Label
	Friend WithEvents lblNama As Label
	Friend WithEvents txtNama As TextBox
	Friend WithEvents lblJK As Label
	Friend WithEvents grpJK As GroupBox
	Friend WithEvents rbLaki As RadioButton
	Friend WithEvents rbPerempuan As RadioButton
	Friend WithEvents txtTempatLahir As TextBox
	Friend WithEvents lblTempatLahir As Label
	Friend WithEvents lblTglLahir As Label
	Friend WithEvents dtpTglLahir As DateTimePicker
	Friend WithEvents lblAngkatan As Label
	Friend WithEvents cmbAngkatan As ComboBox
	Friend WithEvents txtNoTelp As TextBox
	Friend WithEvents lblNoTelp As Label
	Friend WithEvents txtAlamat As TextBox
	Friend WithEvents lblAlamat As Label
	Friend WithEvents txtEmail As TextBox
	Friend WithEvents lblEmail As Label
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
	Friend WithEvents cmbFilterAngk As ComboBox
	Friend WithEvents lblJumlahData As Label
	Friend WithEvents dgvMahasiswa As DataGridView
	Friend WithEvents colNo As DataGridViewTextBoxColumn
	Friend WithEvents nim As DataGridViewTextBoxColumn
	Friend WithEvents namaMahasiswa As DataGridViewTextBoxColumn
	Friend WithEvents jenisKelamin As DataGridViewTextBoxColumn
	Friend WithEvents ttl As DataGridViewTextBoxColumn
	Friend WithEvents angkatan As DataGridViewTextBoxColumn
	Friend WithEvents noTelp As DataGridViewTextBoxColumn
	Friend WithEvents epValidasi As ErrorProvider

End Class
