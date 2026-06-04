<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormInputNilai
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
		Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
		Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
		pnlHeader = New Panel()
		lblTitle = New Label()
		lblSubtitle = New Label()
		pnlSectionMahasiswa = New Panel()
		lblSectionMahasiswa = New Label()
		lblNIM = New Label()
		cmbNIM = New ComboBox()
		lblNamaMahasiswa = New Label()
		txtNamaMahasiswa = New TextBox()
		lblMataKuliah = New Label()
		cmbMataKuliah = New ComboBox()
		lblSemester = New Label()
		cmbSemester = New ComboBox()
		pnlSectionNilai = New Panel()
		btnHitung = New Button()
		txtNilaiAfektif = New TextBox()
		txtNilaiTugas = New TextBox()
		txtNilaiUAS = New TextBox()
		txtNilaiPraktikum = New TextBox()
		txtNilaiUTS = New TextBox()
		lblSectionNilai = New Label()
		lblTugas = New Label()
		lblTugasBobot = New Label()
		lblPraktikum = New Label()
		lblPraktikumBobot = New Label()
		lblUTS = New Label()
		lblUTSBobot = New Label()
		lblUAS = New Label()
		lblUASBobot = New Label()
		lblAfektif = New Label()
		lblAfektifBobot = New Label()
		pnlSectionHasil = New Panel()
		lblSectionHasil = New Label()
		pnlHasilCard = New Panel()
		lblNilaiEfektifLabel = New Label()
		lblNilaiEfektifValue = New Label()
		lblPredikatLabel = New Label()
		lblPredikatValue = New Label()
		pnlSectionGrid = New Panel()
		lblSectionGrid = New Label()
		lblSearch = New Label()
		txtSearch = New TextBox()
		dgvNilai = New DataGridView()
		btnSimpan = New Button()
		btnRefresh = New Button()
		btnHapus = New Button()
		btnEdit = New Button()
		pnlHeader.SuspendLayout()
		pnlSectionMahasiswa.SuspendLayout()
		pnlSectionNilai.SuspendLayout()
		pnlSectionHasil.SuspendLayout()
		pnlHasilCard.SuspendLayout()
		pnlSectionGrid.SuspendLayout()
		CType(dgvNilai, ComponentModel.ISupportInitialize).BeginInit()
		SuspendLayout()
		' 
		' pnlHeader
		' 
		pnlHeader.BackColor = Color.FromArgb(CByte(45), CByte(95), CByte(95))
		pnlHeader.Controls.Add(lblTitle)
		pnlHeader.Controls.Add(lblSubtitle)
		pnlHeader.Dock = DockStyle.Top
		pnlHeader.Location = New Point(0, 0)
		pnlHeader.Name = "pnlHeader"
		pnlHeader.Size = New Size(800, 80)
		pnlHeader.TabIndex = 1
		' 
		' lblTitle
		' 
		lblTitle.AutoSize = True
		lblTitle.BackColor = Color.Transparent
		lblTitle.Font = New Font("Segoe UI", 16.0F, FontStyle.Bold)
		lblTitle.ForeColor = Color.White
		lblTitle.Location = New Point(25, 12)
		lblTitle.Name = "lblTitle"
		lblTitle.Size = New Size(359, 30)
		lblTitle.TabIndex = 0
		lblTitle.Text = "Form Input dan Perhitungan Nilai"
		' 
		' lblSubtitle
		' 
		lblSubtitle.AutoSize = True
		lblSubtitle.BackColor = Color.Transparent
		lblSubtitle.Font = New Font("Segoe UI", 9.0F)
		lblSubtitle.ForeColor = Color.FromArgb(CByte(180), CByte(220), CByte(220))
		lblSubtitle.Location = New Point(27, 45)
		lblSubtitle.Name = "lblSubtitle"
		lblSubtitle.Size = New Size(306, 15)
		lblSubtitle.TabIndex = 1
		lblSubtitle.Text = "Program Studi XYZ  |  Sistem Pengolahan Nilai Akademik"
		' 
		' pnlSectionMahasiswa
		' 
		pnlSectionMahasiswa.BackColor = SystemColors.Control
		pnlSectionMahasiswa.Controls.Add(lblSectionMahasiswa)
		pnlSectionMahasiswa.Controls.Add(lblNIM)
		pnlSectionMahasiswa.Controls.Add(cmbNIM)
		pnlSectionMahasiswa.Controls.Add(lblNamaMahasiswa)
		pnlSectionMahasiswa.Controls.Add(txtNamaMahasiswa)
		pnlSectionMahasiswa.Controls.Add(lblMataKuliah)
		pnlSectionMahasiswa.Controls.Add(cmbMataKuliah)
		pnlSectionMahasiswa.Controls.Add(lblSemester)
		pnlSectionMahasiswa.Controls.Add(cmbSemester)
		pnlSectionMahasiswa.Location = New Point(25, 102)
		pnlSectionMahasiswa.Name = "pnlSectionMahasiswa"
		pnlSectionMahasiswa.Size = New Size(300, 233)
		pnlSectionMahasiswa.TabIndex = 2
		' 
		' lblSectionMahasiswa
		' 
		lblSectionMahasiswa.BackColor = Color.FromArgb(CByte(45), CByte(95), CByte(95))
		lblSectionMahasiswa.Dock = DockStyle.Top
		lblSectionMahasiswa.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
		lblSectionMahasiswa.ForeColor = Color.White
		lblSectionMahasiswa.Location = New Point(0, 0)
		lblSectionMahasiswa.Name = "lblSectionMahasiswa"
		lblSectionMahasiswa.Padding = New Padding(10, 0, 0, 0)
		lblSectionMahasiswa.Size = New Size(300, 32)
		lblSectionMahasiswa.TabIndex = 0
		lblSectionMahasiswa.Text = "  Data Mahasiswa"
		lblSectionMahasiswa.TextAlign = ContentAlignment.MiddleLeft
		' 
		' lblNIM
		' 
		lblNIM.AutoSize = True
		lblNIM.Font = New Font("Segoe UI", 9.0F)
		lblNIM.ForeColor = Color.FromArgb(CByte(60), CByte(80), CByte(80))
		lblNIM.Location = New Point(15, 48)
		lblNIM.Name = "lblNIM"
		lblNIM.Size = New Size(99, 15)
		lblNIM.TabIndex = 1
		lblNIM.Text = "NIM Mahasiswa *"
		' 
		' cmbNIM
		' 
		cmbNIM.DropDownStyle = ComboBoxStyle.DropDownList
		cmbNIM.FlatStyle = FlatStyle.Flat
		cmbNIM.Font = New Font("Segoe UI", 9.5F)
		cmbNIM.Location = New Point(26, 66)
		cmbNIM.Name = "cmbNIM"
		cmbNIM.Size = New Size(141, 25)
		cmbNIM.TabIndex = 2
		' 
		' lblNamaMahasiswa
		' 
		lblNamaMahasiswa.AutoSize = True
		lblNamaMahasiswa.Font = New Font("Segoe UI", 9.0F)
		lblNamaMahasiswa.ForeColor = Color.FromArgb(CByte(60), CByte(80), CByte(80))
		lblNamaMahasiswa.Location = New Point(14, 111)
		lblNamaMahasiswa.Name = "lblNamaMahasiswa"
		lblNamaMahasiswa.Size = New Size(100, 15)
		lblNamaMahasiswa.TabIndex = 3
		lblNamaMahasiswa.Text = "Nama Mahasiswa"
		' 
		' txtNamaMahasiswa
		' 
		txtNamaMahasiswa.BackColor = Color.FromArgb(CByte(235), CByte(242), CByte(242))
		txtNamaMahasiswa.BorderStyle = BorderStyle.FixedSingle
		txtNamaMahasiswa.Font = New Font("Segoe UI", 9.5F)
		txtNamaMahasiswa.Location = New Point(26, 129)
		txtNamaMahasiswa.Name = "txtNamaMahasiswa"
		txtNamaMahasiswa.ReadOnly = True
		txtNamaMahasiswa.Size = New Size(258, 24)
		txtNamaMahasiswa.TabIndex = 4
		' 
		' lblMataKuliah
		' 
		lblMataKuliah.AutoSize = True
		lblMataKuliah.Font = New Font("Segoe UI", 9.0F)
		lblMataKuliah.ForeColor = Color.FromArgb(CByte(60), CByte(80), CByte(80))
		lblMataKuliah.Location = New Point(15, 169)
		lblMataKuliah.Name = "lblMataKuliah"
		lblMataKuliah.Size = New Size(78, 15)
		lblMataKuliah.TabIndex = 5
		lblMataKuliah.Text = "Mata Kuliah *"
		' 
		' cmbMataKuliah
		' 
		cmbMataKuliah.DropDownStyle = ComboBoxStyle.DropDownList
		cmbMataKuliah.FlatStyle = FlatStyle.Flat
		cmbMataKuliah.Font = New Font("Segoe UI", 9.5F)
		cmbMataKuliah.Location = New Point(26, 187)
		cmbMataKuliah.Name = "cmbMataKuliah"
		cmbMataKuliah.Size = New Size(258, 25)
		cmbMataKuliah.TabIndex = 6
		' 
		' lblSemester
		' 
		lblSemester.AutoSize = True
		lblSemester.Font = New Font("Segoe UI", 9.0F)
		lblSemester.ForeColor = Color.FromArgb(CByte(60), CByte(80), CByte(80))
		lblSemester.Location = New Point(187, 48)
		lblSemester.Name = "lblSemester"
		lblSemester.Size = New Size(63, 15)
		lblSemester.TabIndex = 7
		lblSemester.Text = "Semester *"
		' 
		' cmbSemester
		' 
		cmbSemester.DropDownStyle = ComboBoxStyle.DropDownList
		cmbSemester.FlatStyle = FlatStyle.Flat
		cmbSemester.Font = New Font("Segoe UI", 9.5F)
		cmbSemester.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8"})
		cmbSemester.Location = New Point(199, 66)
		cmbSemester.Name = "cmbSemester"
		cmbSemester.Size = New Size(85, 25)
		cmbSemester.TabIndex = 8
		' 
		' pnlSectionNilai
		' 
		pnlSectionNilai.BackColor = SystemColors.Control
		pnlSectionNilai.Controls.Add(btnHitung)
		pnlSectionNilai.Controls.Add(txtNilaiAfektif)
		pnlSectionNilai.Controls.Add(txtNilaiTugas)
		pnlSectionNilai.Controls.Add(txtNilaiUAS)
		pnlSectionNilai.Controls.Add(txtNilaiPraktikum)
		pnlSectionNilai.Controls.Add(txtNilaiUTS)
		pnlSectionNilai.Controls.Add(lblSectionNilai)
		pnlSectionNilai.Controls.Add(lblTugas)
		pnlSectionNilai.Controls.Add(lblTugasBobot)
		pnlSectionNilai.Controls.Add(lblPraktikum)
		pnlSectionNilai.Controls.Add(lblPraktikumBobot)
		pnlSectionNilai.Controls.Add(lblUTS)
		pnlSectionNilai.Controls.Add(lblUTSBobot)
		pnlSectionNilai.Controls.Add(lblUAS)
		pnlSectionNilai.Controls.Add(lblUASBobot)
		pnlSectionNilai.Controls.Add(lblAfektif)
		pnlSectionNilai.Controls.Add(lblAfektifBobot)
		pnlSectionNilai.Location = New Point(349, 102)
		pnlSectionNilai.Name = "pnlSectionNilai"
		pnlSectionNilai.Size = New Size(425, 233)
		pnlSectionNilai.TabIndex = 3
		' 
		' btnHitung
		' 
		btnHitung.BackColor = Color.FromArgb(CByte(107), CByte(158), CByte(158))
		btnHitung.FlatAppearance.BorderSize = 0
		btnHitung.FlatStyle = FlatStyle.Flat
		btnHitung.Font = New Font("Segoe UI", 9.5F, FontStyle.Bold)
		btnHitung.ForeColor = Color.White
		btnHitung.Location = New Point(250, 176)
		btnHitung.Name = "btnHitung"
		btnHitung.Size = New Size(130, 36)
		btnHitung.TabIndex = 6
		btnHitung.Text = "Hitung Nilai"
		btnHitung.UseVisualStyleBackColor = False
		' 
		' txtNilaiAfektif
		' 
		txtNilaiAfektif.Location = New Point(24, 189)
		txtNilaiAfektif.Name = "txtNilaiAfektif"
		txtNilaiAfektif.Size = New Size(84, 23)
		txtNilaiAfektif.TabIndex = 20
		' 
		' txtNilaiTugas
		' 
		txtNilaiTugas.Location = New Point(24, 71)
		txtNilaiTugas.Name = "txtNilaiTugas"
		txtNilaiTugas.Size = New Size(84, 23)
		txtNilaiTugas.TabIndex = 19
		' 
		' txtNilaiUAS
		' 
		txtNilaiUAS.Location = New Point(250, 129)
		txtNilaiUAS.Name = "txtNilaiUAS"
		txtNilaiUAS.Size = New Size(84, 23)
		txtNilaiUAS.TabIndex = 18
		' 
		' txtNilaiPraktikum
		' 
		txtNilaiPraktikum.Location = New Point(250, 71)
		txtNilaiPraktikum.Name = "txtNilaiPraktikum"
		txtNilaiPraktikum.Size = New Size(84, 23)
		txtNilaiPraktikum.TabIndex = 17
		' 
		' txtNilaiUTS
		' 
		txtNilaiUTS.Location = New Point(24, 129)
		txtNilaiUTS.Name = "txtNilaiUTS"
		txtNilaiUTS.Size = New Size(84, 23)
		txtNilaiUTS.TabIndex = 16
		' 
		' lblSectionNilai
		' 
		lblSectionNilai.BackColor = Color.FromArgb(CByte(45), CByte(95), CByte(95))
		lblSectionNilai.Dock = DockStyle.Top
		lblSectionNilai.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
		lblSectionNilai.ForeColor = Color.White
		lblSectionNilai.Location = New Point(0, 0)
		lblSectionNilai.Name = "lblSectionNilai"
		lblSectionNilai.Padding = New Padding(10, 0, 0, 0)
		lblSectionNilai.Size = New Size(425, 32)
		lblSectionNilai.TabIndex = 0
		lblSectionNilai.Text = "  Input Nilai (0 - 100)"
		lblSectionNilai.TextAlign = ContentAlignment.MiddleLeft
		' 
		' lblTugas
		' 
		lblTugas.AutoSize = True
		lblTugas.Font = New Font("Segoe UI", 9.0F)
		lblTugas.ForeColor = Color.FromArgb(CByte(60), CByte(80), CByte(80))
		lblTugas.Location = New Point(15, 48)
		lblTugas.Name = "lblTugas"
		lblTugas.Size = New Size(65, 15)
		lblTugas.TabIndex = 1
		lblTugas.Text = "Nilai Tugas"
		' 
		' lblTugasBobot
		' 
		lblTugasBobot.AutoSize = True
		lblTugasBobot.Font = New Font("Segoe UI", 8.0F)
		lblTugasBobot.ForeColor = Color.FromArgb(CByte(107), CByte(158), CByte(158))
		lblTugasBobot.Location = New Point(114, 75)
		lblTugasBobot.Name = "lblTugasBobot"
		lblTugasBobot.Size = New Size(65, 13)
		lblTugasBobot.TabIndex = 3
		lblTugasBobot.Text = "Bobot: 20%"
		' 
		' lblPraktikum
		' 
		lblPraktikum.AutoSize = True
		lblPraktikum.Font = New Font("Segoe UI", 9.0F)
		lblPraktikum.ForeColor = Color.FromArgb(CByte(60), CByte(80), CByte(80))
		lblPraktikum.Location = New Point(242, 48)
		lblPraktikum.Name = "lblPraktikum"
		lblPraktikum.Size = New Size(88, 15)
		lblPraktikum.TabIndex = 4
		lblPraktikum.Text = "Nilai Praktikum"
		' 
		' lblPraktikumBobot
		' 
		lblPraktikumBobot.AutoSize = True
		lblPraktikumBobot.Font = New Font("Segoe UI", 8.0F)
		lblPraktikumBobot.ForeColor = Color.FromArgb(CByte(107), CByte(158), CByte(158))
		lblPraktikumBobot.Location = New Point(340, 75)
		lblPraktikumBobot.Name = "lblPraktikumBobot"
		lblPraktikumBobot.Size = New Size(65, 13)
		lblPraktikumBobot.TabIndex = 6
		lblPraktikumBobot.Text = "Bobot: 15%"
		' 
		' lblUTS
		' 
		lblUTS.AutoSize = True
		lblUTS.Font = New Font("Segoe UI", 9.0F)
		lblUTS.ForeColor = Color.FromArgb(CByte(60), CByte(80), CByte(80))
		lblUTS.Location = New Point(15, 106)
		lblUTS.Name = "lblUTS"
		lblUTS.Size = New Size(54, 15)
		lblUTS.TabIndex = 7
		lblUTS.Text = "Nilai UTS"
		' 
		' lblUTSBobot
		' 
		lblUTSBobot.AutoSize = True
		lblUTSBobot.Font = New Font("Segoe UI", 8.0F)
		lblUTSBobot.ForeColor = Color.FromArgb(CByte(107), CByte(158), CByte(158))
		lblUTSBobot.Location = New Point(114, 133)
		lblUTSBobot.Name = "lblUTSBobot"
		lblUTSBobot.Size = New Size(65, 13)
		lblUTSBobot.TabIndex = 9
		lblUTSBobot.Text = "Bobot: 25%"
		' 
		' lblUAS
		' 
		lblUAS.AutoSize = True
		lblUAS.Font = New Font("Segoe UI", 9.0F)
		lblUAS.ForeColor = Color.FromArgb(CByte(60), CByte(80), CByte(80))
		lblUAS.Location = New Point(242, 106)
		lblUAS.Name = "lblUAS"
		lblUAS.Size = New Size(56, 15)
		lblUAS.TabIndex = 10
		lblUAS.Text = "Nilai UAS"
		' 
		' lblUASBobot
		' 
		lblUASBobot.AutoSize = True
		lblUASBobot.Font = New Font("Segoe UI", 8.0F)
		lblUASBobot.ForeColor = Color.FromArgb(CByte(107), CByte(158), CByte(158))
		lblUASBobot.Location = New Point(340, 133)
		lblUASBobot.Name = "lblUASBobot"
		lblUASBobot.Size = New Size(65, 13)
		lblUASBobot.TabIndex = 12
		lblUASBobot.Text = "Bobot: 30%"
		' 
		' lblAfektif
		' 
		lblAfektif.AutoSize = True
		lblAfektif.Font = New Font("Segoe UI", 9.0F)
		lblAfektif.ForeColor = Color.FromArgb(CByte(60), CByte(80), CByte(80))
		lblAfektif.Location = New Point(15, 166)
		lblAfektif.Name = "lblAfektif"
		lblAfektif.Size = New Size(127, 15)
		lblAfektif.TabIndex = 13
		lblAfektif.Text = "Nilai Afektif/Kehadiran"
		' 
		' lblAfektifBobot
		' 
		lblAfektifBobot.AutoSize = True
		lblAfektifBobot.Font = New Font("Segoe UI", 8.0F)
		lblAfektifBobot.ForeColor = Color.FromArgb(CByte(107), CByte(158), CByte(158))
		lblAfektifBobot.Location = New Point(114, 193)
		lblAfektifBobot.Name = "lblAfektifBobot"
		lblAfektifBobot.Size = New Size(65, 13)
		lblAfektifBobot.TabIndex = 15
		lblAfektifBobot.Text = "Bobot: 10%"
		' 
		' pnlSectionHasil
		' 
		pnlSectionHasil.BackColor = SystemColors.Control
		pnlSectionHasil.Controls.Add(lblSectionHasil)
		pnlSectionHasil.Controls.Add(pnlHasilCard)
		pnlSectionHasil.Location = New Point(25, 355)
		pnlSectionHasil.Name = "pnlSectionHasil"
		pnlSectionHasil.Size = New Size(300, 121)
		pnlSectionHasil.TabIndex = 4
		' 
		' lblSectionHasil
		' 
		lblSectionHasil.BackColor = Color.FromArgb(CByte(45), CByte(95), CByte(95))
		lblSectionHasil.Dock = DockStyle.Top
		lblSectionHasil.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
		lblSectionHasil.ForeColor = Color.White
		lblSectionHasil.Location = New Point(0, 0)
		lblSectionHasil.Name = "lblSectionHasil"
		lblSectionHasil.Padding = New Padding(10, 0, 0, 0)
		lblSectionHasil.Size = New Size(300, 32)
		lblSectionHasil.TabIndex = 0
		lblSectionHasil.Text = "Hasil Perhitungan Nilai Akhir"
		lblSectionHasil.TextAlign = ContentAlignment.MiddleLeft
		' 
		' pnlHasilCard
		' 
		pnlHasilCard.BackColor = Color.FromArgb(CByte(235), CByte(245), CByte(245))
		pnlHasilCard.Controls.Add(lblNilaiEfektifLabel)
		pnlHasilCard.Controls.Add(lblNilaiEfektifValue)
		pnlHasilCard.Controls.Add(lblPredikatLabel)
		pnlHasilCard.Controls.Add(lblPredikatValue)
		pnlHasilCard.Location = New Point(26, 44)
		pnlHasilCard.Name = "pnlHasilCard"
		pnlHasilCard.Size = New Size(250, 65)
		pnlHasilCard.TabIndex = 1
		' 
		' lblNilaiEfektifLabel
		' 
		lblNilaiEfektifLabel.AutoSize = True
		lblNilaiEfektifLabel.Font = New Font("Segoe UI", 9.0F)
		lblNilaiEfektifLabel.ForeColor = Color.FromArgb(CByte(80), CByte(100), CByte(100))
		lblNilaiEfektifLabel.Location = New Point(39, 9)
		lblNilaiEfektifLabel.Name = "lblNilaiEfektifLabel"
		lblNilaiEfektifLabel.Size = New Size(73, 15)
		lblNilaiEfektifLabel.TabIndex = 0
		lblNilaiEfektifLabel.Text = "NILAI AKHIR"
		' 
		' lblNilaiEfektifValue
		' 
		lblNilaiEfektifValue.AutoSize = True
		lblNilaiEfektifValue.Font = New Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
		lblNilaiEfektifValue.ForeColor = Color.FromArgb(CByte(45), CByte(95), CByte(95))
		lblNilaiEfektifValue.Location = New Point(39, 24)
		lblNilaiEfektifValue.Name = "lblNilaiEfektifValue"
		lblNilaiEfektifValue.Size = New Size(72, 37)
		lblNilaiEfektifValue.TabIndex = 1
		lblNilaiEfektifValue.Text = "0.00"
		' 
		' lblPredikatLabel
		' 
		lblPredikatLabel.AutoSize = True
		lblPredikatLabel.Font = New Font("Segoe UI", 9.0F)
		lblPredikatLabel.ForeColor = Color.FromArgb(CByte(80), CByte(100), CByte(100))
		lblPredikatLabel.Location = New Point(154, 9)
		lblPredikatLabel.Name = "lblPredikatLabel"
		lblPredikatLabel.Size = New Size(58, 15)
		lblPredikatLabel.TabIndex = 2
		lblPredikatLabel.Text = "PREDIKAT"
		' 
		' lblPredikatValue
		' 
		lblPredikatValue.AutoSize = True
		lblPredikatValue.Font = New Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
		lblPredikatValue.ForeColor = Color.FromArgb(CByte(107), CByte(158), CByte(158))
		lblPredikatValue.Location = New Point(168, 24)
		lblPredikatValue.Name = "lblPredikatValue"
		lblPredikatValue.Size = New Size(28, 37)
		lblPredikatValue.TabIndex = 3
		lblPredikatValue.Text = "-"
		' 
		' pnlSectionGrid
		' 
		pnlSectionGrid.BackColor = SystemColors.Control
		pnlSectionGrid.Controls.Add(lblSectionGrid)
		pnlSectionGrid.Controls.Add(lblSearch)
		pnlSectionGrid.Controls.Add(txtSearch)
		pnlSectionGrid.Controls.Add(dgvNilai)
		pnlSectionGrid.Location = New Point(25, 499)
		pnlSectionGrid.Name = "pnlSectionGrid"
		pnlSectionGrid.Size = New Size(749, 209)
		pnlSectionGrid.TabIndex = 5
		' 
		' lblSectionGrid
		' 
		lblSectionGrid.BackColor = Color.FromArgb(CByte(45), CByte(95), CByte(95))
		lblSectionGrid.Dock = DockStyle.Top
		lblSectionGrid.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
		lblSectionGrid.ForeColor = Color.White
		lblSectionGrid.Location = New Point(0, 0)
		lblSectionGrid.Name = "lblSectionGrid"
		lblSectionGrid.Padding = New Padding(10, 0, 0, 0)
		lblSectionGrid.Size = New Size(749, 32)
		lblSectionGrid.TabIndex = 0
		lblSectionGrid.Text = "  Daftar Nilai Mahasiswa"
		lblSectionGrid.TextAlign = ContentAlignment.MiddleLeft
		' 
		' lblSearch
		' 
		lblSearch.AutoSize = True
		lblSearch.Font = New Font("Segoe UI", 9.0F)
		lblSearch.ForeColor = Color.FromArgb(CByte(60), CByte(80), CByte(80))
		lblSearch.Location = New Point(15, 40)
		lblSearch.Name = "lblSearch"
		lblSearch.Size = New Size(182, 15)
		lblSearch.TabIndex = 1
		lblSearch.Text = "Cari (NIM / Nama / Mata Kuliah):"
		' 
		' txtSearch
		' 
		txtSearch.BorderStyle = BorderStyle.FixedSingle
		txtSearch.Font = New Font("Segoe UI", 9.5F)
		txtSearch.Location = New Point(215, 37)
		txtSearch.Name = "txtSearch"
		txtSearch.Size = New Size(260, 24)
		txtSearch.TabIndex = 2
		' 
		' dgvNilai
		' 
		dgvNilai.AllowUserToAddRows = False
		dgvNilai.AllowUserToDeleteRows = False
		dgvNilai.BackgroundColor = SystemColors.Control
		dgvNilai.BorderStyle = BorderStyle.None
		DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft
		DataGridViewCellStyle1.BackColor = Color.FromArgb(CByte(107), CByte(158), CByte(158))
		DataGridViewCellStyle1.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
		DataGridViewCellStyle1.ForeColor = Color.White
		DataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight
		DataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText
		DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True
		dgvNilai.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
		dgvNilai.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
		DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft
		DataGridViewCellStyle2.BackColor = SystemColors.Window
		DataGridViewCellStyle2.Font = New Font("Segoe UI", 9.0F)
		DataGridViewCellStyle2.ForeColor = SystemColors.ControlText
		DataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(CByte(180), CByte(215), CByte(215))
		DataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(CByte(30), CByte(60), CByte(60))
		DataGridViewCellStyle2.WrapMode = DataGridViewTriState.False
		dgvNilai.DefaultCellStyle = DataGridViewCellStyle2
		dgvNilai.GridColor = Color.FromArgb(CByte(210), CByte(228), CByte(228))
		dgvNilai.Location = New Point(3, 68)
		dgvNilai.Name = "dgvNilai"
		dgvNilai.ReadOnly = True
		dgvNilai.RowHeadersVisible = False
		dgvNilai.SelectionMode = DataGridViewSelectionMode.FullRowSelect
		dgvNilai.Size = New Size(743, 138)
		dgvNilai.TabIndex = 3
		' 
		' btnSimpan
		' 
		btnSimpan.BackColor = Color.FromArgb(CByte(45), CByte(95), CByte(95))
		btnSimpan.FlatAppearance.BorderSize = 0
		btnSimpan.FlatStyle = FlatStyle.Flat
		btnSimpan.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
		btnSimpan.ForeColor = Color.White
		btnSimpan.Location = New Point(396, 440)
		btnSimpan.Name = "btnSimpan"
		btnSimpan.Size = New Size(90, 36)
		btnSimpan.TabIndex = 7
		btnSimpan.Text = "Simpan"
		btnSimpan.UseVisualStyleBackColor = False
		' 
		' btnRefresh
		' 
		btnRefresh.BackColor = Color.White
		btnRefresh.FlatAppearance.BorderColor = Color.FromArgb(CByte(107), CByte(158), CByte(158))
		btnRefresh.FlatStyle = FlatStyle.Flat
		btnRefresh.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
		btnRefresh.ForeColor = Color.FromArgb(CByte(45), CByte(95), CByte(95))
		btnRefresh.Location = New Point(684, 440)
		btnRefresh.Name = "btnRefresh"
		btnRefresh.Size = New Size(90, 36)
		btnRefresh.TabIndex = 8
		btnRefresh.Text = "Refresh"
		btnRefresh.UseVisualStyleBackColor = False
		' 
		' btnHapus
		' 
		btnHapus.BackColor = Color.Maroon
		btnHapus.FlatAppearance.BorderSize = 0
		btnHapus.FlatStyle = FlatStyle.Flat
		btnHapus.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
		btnHapus.ForeColor = Color.White
		btnHapus.Location = New Point(588, 440)
		btnHapus.Name = "btnHapus"
		btnHapus.Size = New Size(90, 36)
		btnHapus.TabIndex = 9
		btnHapus.Text = "Hapus"
		btnHapus.UseVisualStyleBackColor = False
		' 
		' btnEdit
		' 
		btnEdit.BackColor = Color.FromArgb(CByte(120), CByte(120), CByte(120))
		btnEdit.FlatAppearance.BorderSize = 0
		btnEdit.FlatStyle = FlatStyle.Flat
		btnEdit.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
		btnEdit.ForeColor = Color.White
		btnEdit.Location = New Point(492, 440)
		btnEdit.Name = "btnEdit"
		btnEdit.Size = New Size(90, 36)
		btnEdit.TabIndex = 10
		btnEdit.Text = "Edit"
		btnEdit.UseVisualStyleBackColor = False
		' 
		' FormInputNilai
		' 
		AutoScaleDimensions = New SizeF(7.0F, 15.0F)
		AutoScaleMode = AutoScaleMode.Font
		BackColor = SystemColors.ControlLightLight
		ClientSize = New Size(800, 734)
		Controls.Add(btnSimpan)
		Controls.Add(btnRefresh)
		Controls.Add(btnHapus)
		Controls.Add(btnEdit)
		Controls.Add(pnlSectionGrid)
		Controls.Add(pnlSectionHasil)
		Controls.Add(pnlSectionNilai)
		Controls.Add(pnlSectionMahasiswa)
		Controls.Add(pnlHeader)
		Name = "FormInputNilai"
		Text = "FormInputNilai"
		pnlHeader.ResumeLayout(False)
		pnlHeader.PerformLayout()
		pnlSectionMahasiswa.ResumeLayout(False)
		pnlSectionMahasiswa.PerformLayout()
		pnlSectionNilai.ResumeLayout(False)
		pnlSectionNilai.PerformLayout()
		pnlSectionHasil.ResumeLayout(False)
		pnlHasilCard.ResumeLayout(False)
		pnlHasilCard.PerformLayout()
		pnlSectionGrid.ResumeLayout(False)
		pnlSectionGrid.PerformLayout()
		CType(dgvNilai, ComponentModel.ISupportInitialize).EndInit()
		ResumeLayout(False)
	End Sub

	Friend WithEvents pnlHeader As Panel
	Friend WithEvents lblTitle As Label
	Friend WithEvents lblSubtitle As Label
	Friend WithEvents pnlSectionMahasiswa As Panel
	Friend WithEvents lblSectionMahasiswa As Label
	Friend WithEvents lblNIM As Label
	Friend WithEvents cmbNIM As ComboBox
	Friend WithEvents lblNamaMahasiswa As Label
	Friend WithEvents txtNamaMahasiswa As TextBox
	Friend WithEvents lblMataKuliah As Label
	Friend WithEvents cmbMataKuliah As ComboBox
	Friend WithEvents lblSemester As Label
	Friend WithEvents cmbSemester As ComboBox
	Friend WithEvents pnlSectionNilai As Panel
	Friend WithEvents lblSectionNilai As Label
	Friend WithEvents lblTugas As Label
	Friend WithEvents lblTugasBobot As Label
	Friend WithEvents lblPraktikum As Label
	Friend WithEvents lblPraktikumBobot As Label
	Friend WithEvents lblUTS As Label
	Friend WithEvents lblUTSBobot As Label
	Friend WithEvents lblUAS As Label
	Friend WithEvents lblUASBobot As Label
	Friend WithEvents lblAfektif As Label
	Friend WithEvents lblAfektifBobot As Label
	Friend WithEvents txtNilaiPraktikum As TextBox
	Friend WithEvents txtNilaiUTS As TextBox
	Friend WithEvents txtNilaiAfektif As TextBox
	Friend WithEvents txtNilaiTugas As TextBox
	Friend WithEvents txtNilaiUAS As TextBox
	Friend WithEvents pnlSectionHasil As Panel
	Friend WithEvents lblSectionHasil As Label
	Friend WithEvents pnlHasilCard As Panel
	Friend WithEvents lblNilaiEfektifLabel As Label
	Friend WithEvents lblNilaiEfektifValue As Label
	Friend WithEvents lblPredikatLabel As Label
	Friend WithEvents lblPredikatValue As Label
	Friend WithEvents pnlSectionGrid As Panel
	Friend WithEvents lblSectionGrid As Label
	Friend WithEvents lblSearch As Label
	Friend WithEvents txtSearch As TextBox
	Friend WithEvents dgvNilai As DataGridView
	Friend WithEvents btnHitung As Button
	Friend WithEvents btnSimpan As Button
	Friend WithEvents btnRefresh As Button
	Friend WithEvents btnHapus As Button
	Friend WithEvents btnEdit As Button
End Class
