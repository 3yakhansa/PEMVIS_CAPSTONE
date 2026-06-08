<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormDataUser
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
		txtSearch = New TextBox()
		cmbLevel = New ComboBox()
		btnSimpan = New Button()
		dgvUser = New DataGridView()
		Panel4 = New Panel()
		Label1 = New Label()
		Panel1 = New Panel()
		Label7 = New Label()
		Label6 = New Label()
		Label5 = New Label()
		Label4 = New Label()
		Label3 = New Label()
		Label2 = New Label()
		txtNimRef = New TextBox()
		cmbStatus = New ComboBox()
		cmbLevelAkses = New ComboBox()
		txtPassword = New TextBox()
		txtUsername = New TextBox()
		btnEdit = New Button()
		btnHapus = New Button()
		btnBatal = New Button()
		ErrorProvider1 = New ErrorProvider(components)
		CType(dgvUser, ComponentModel.ISupportInitialize).BeginInit()
		Panel4.SuspendLayout()
		Panel1.SuspendLayout()
		CType(ErrorProvider1, ComponentModel.ISupportInitialize).BeginInit()
		SuspendLayout()
		' 
		' txtSearch
		' 
		txtSearch.BackColor = Color.FromArgb(CByte(184), CByte(213), CByte(218))
		txtSearch.Location = New Point(12, 270)
		txtSearch.Name = "txtSearch"
		txtSearch.PlaceholderText = "Cari username atau NIM Referensi..."
		txtSearch.Size = New Size(774, 27)
		txtSearch.TabIndex = 2
		' 
		' cmbLevel
		' 
		cmbLevel.BackColor = Color.FromArgb(CByte(123), CByte(170), CByte(179))
		cmbLevel.ForeColor = Color.White
		cmbLevel.FormattingEnabled = True
		cmbLevel.Items.AddRange(New Object() {"Semua Level", "Admin (Lvl1)", "Viewer (Lvl2"})
		cmbLevel.Location = New Point(12, 231)
		cmbLevel.Name = "cmbLevel"
		cmbLevel.Size = New Size(203, 28)
		cmbLevel.TabIndex = 3
		cmbLevel.Text = "--Pilih Level--"
		' 
		' btnSimpan
		' 
		btnSimpan.BackColor = Color.FromArgb(CByte(74), CByte(124), CByte(134))
		btnSimpan.Font = New Font("Segoe UI Semibold", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
		btnSimpan.Location = New Point(273, 226)
		btnSimpan.Name = "btnSimpan"
		btnSimpan.Size = New Size(124, 38)
		btnSimpan.TabIndex = 5
		btnSimpan.Text = "SIMPAN"
		btnSimpan.UseVisualStyleBackColor = False
		' 
		' dgvUser
		' 
		dgvUser.AllowUserToAddRows = False
		dgvUser.AllowUserToDeleteRows = False
		dgvUser.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
		dgvUser.BackgroundColor = Color.White
		dgvUser.BorderStyle = BorderStyle.None
		DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft
		DataGridViewCellStyle1.BackColor = Color.FromArgb(CByte(74), CByte(124), CByte(134))
		DataGridViewCellStyle1.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
		DataGridViewCellStyle1.ForeColor = Color.White
		DataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight
		DataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText
		DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True
		dgvUser.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
		dgvUser.ColumnHeadersHeight = 35
		dgvUser.EnableHeadersVisualStyles = False
		dgvUser.Location = New Point(12, 303)
		dgvUser.MultiSelect = False
		dgvUser.Name = "dgvUser"
		dgvUser.ReadOnly = True
		dgvUser.RowHeadersVisible = False
		dgvUser.RowHeadersWidth = 51
		dgvUser.SelectionMode = DataGridViewSelectionMode.FullRowSelect
		dgvUser.Size = New Size(776, 188)
		dgvUser.TabIndex = 6
		' 
		' Panel4
		' 
		Panel4.BackColor = Color.FromArgb(CByte(123), CByte(170), CByte(179))
		Panel4.Controls.Add(Label1)
		Panel4.Location = New Point(12, 5)
		Panel4.Name = "Panel4"
		Panel4.Size = New Size(776, 54)
		Panel4.TabIndex = 7
		' 
		' Label1
		' 
		Label1.AutoSize = True
		Label1.Font = New Font("Segoe UI Black", 12.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
		Label1.ForeColor = Color.White
		Label1.Location = New Point(249, 8)
		Label1.Name = "Label1"
		Label1.Size = New Size(267, 28)
		Label1.TabIndex = 0
		Label1.Text = "MANAJEMEN DATA USER"
		' 
		' Panel1
		' 
		Panel1.BackColor = Color.FromArgb(CByte(212), CByte(228), CByte(228))
		Panel1.Controls.Add(Label7)
		Panel1.Controls.Add(Label6)
		Panel1.Controls.Add(Label5)
		Panel1.Controls.Add(Label4)
		Panel1.Controls.Add(Label3)
		Panel1.Controls.Add(Label2)
		Panel1.Controls.Add(txtNimRef)
		Panel1.Controls.Add(cmbStatus)
		Panel1.Controls.Add(cmbLevelAkses)
		Panel1.Controls.Add(txtPassword)
		Panel1.Controls.Add(txtUsername)
		Panel1.Location = New Point(12, 44)
		Panel1.Name = "Panel1"
		Panel1.Size = New Size(776, 175)
		Panel1.TabIndex = 0
		' 
		' Label7
		' 
		Label7.AutoSize = True
		Label7.Font = New Font("Segoe UI", 7.20000029F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
		Label7.ForeColor = Color.Gray
		Label7.Location = New Point(521, 112)
		Label7.Name = "Label7"
		Label7.Size = New Size(218, 34)
		Label7.TabIndex = 10
		Label7.Text = "isi jika user terhubung " & vbCrLf & "dengan data mahasiswa atau admin"
		' 
		' Label6
		' 
		Label6.AutoSize = True
		Label6.Font = New Font("Segoe UI Semibold", 9.0F, FontStyle.Bold)
		Label6.ForeColor = Color.Black
		Label6.Location = New Point(380, 89)
		Label6.Name = "Label6"
		Label6.Size = New Size(106, 20)
		Label6.TabIndex = 9
		Label6.Text = "NIM Referensi"
		' 
		' Label5
		' 
		Label5.AutoSize = True
		Label5.Font = New Font("Segoe UI Semibold", 9.0F, FontStyle.Bold)
		Label5.ForeColor = Color.Black
		Label5.Location = New Point(380, 44)
		Label5.Name = "Label5"
		Label5.Size = New Size(50, 20)
		Label5.TabIndex = 8
		Label5.Text = "Status"
		' 
		' Label4
		' 
		Label4.AutoSize = True
		Label4.Font = New Font("Segoe UI Semibold", 9.0F, FontStyle.Bold)
		Label4.ForeColor = Color.Black
		Label4.Location = New Point(22, 140)
		Label4.Name = "Label4"
		Label4.Size = New Size(86, 20)
		Label4.TabIndex = 7
		Label4.Text = "Level Akses"
		' 
		' Label3
		' 
		Label3.AutoSize = True
		Label3.Font = New Font("Segoe UI Semibold", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
		Label3.ForeColor = Color.Black
		Label3.Location = New Point(22, 89)
		Label3.Name = "Label3"
		Label3.Size = New Size(73, 20)
		Label3.TabIndex = 6
		Label3.Text = "Password"
		' 
		' Label2
		' 
		Label2.AutoSize = True
		Label2.Font = New Font("Segoe UI Semibold", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
		Label2.ForeColor = Color.Black
		Label2.Location = New Point(22, 44)
		Label2.Name = "Label2"
		Label2.Size = New Size(78, 20)
		Label2.TabIndex = 5
		Label2.Text = "Username"
		' 
		' txtNimRef
		' 
		txtNimRef.Location = New Point(521, 82)
		txtNimRef.Name = "txtNimRef"
		txtNimRef.Size = New Size(225, 27)
		txtNimRef.TabIndex = 4
		' 
		' cmbStatus
		' 
		cmbStatus.FormattingEnabled = True
		cmbStatus.Location = New Point(521, 37)
		cmbStatus.Name = "cmbStatus"
		cmbStatus.Size = New Size(225, 28)
		cmbStatus.TabIndex = 3
		' 
		' cmbLevelAkses
		' 
		cmbLevelAkses.FormattingEnabled = True
		cmbLevelAkses.Location = New Point(127, 132)
		cmbLevelAkses.Name = "cmbLevelAkses"
		cmbLevelAkses.Size = New Size(225, 28)
		cmbLevelAkses.TabIndex = 2
		' 
		' txtPassword
		' 
		txtPassword.Location = New Point(127, 82)
		txtPassword.Name = "txtPassword"
		txtPassword.Size = New Size(225, 27)
		txtPassword.TabIndex = 1
		' 
		' txtUsername
		' 
		txtUsername.Location = New Point(127, 37)
		txtUsername.Name = "txtUsername"
		txtUsername.Size = New Size(225, 27)
		txtUsername.TabIndex = 0
		' 
		' btnEdit
		' 
		btnEdit.BackColor = Color.FromArgb(CByte(255), CByte(128), CByte(0))
		btnEdit.Font = New Font("Segoe UI Semibold", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
		btnEdit.Location = New Point(403, 225)
		btnEdit.Name = "btnEdit"
		btnEdit.Size = New Size(124, 38)
		btnEdit.TabIndex = 8
		btnEdit.Text = "EDIT"
		btnEdit.UseVisualStyleBackColor = False
		' 
		' btnHapus
		' 
		btnHapus.BackColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
		btnHapus.Font = New Font("Segoe UI Semibold", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
		btnHapus.Location = New Point(533, 225)
		btnHapus.Name = "btnHapus"
		btnHapus.Size = New Size(124, 38)
		btnHapus.TabIndex = 9
		btnHapus.Text = "HAPUS"
		btnHapus.UseVisualStyleBackColor = False
		' 
		' btnBatal
		' 
		btnBatal.BackColor = Color.FromArgb(CByte(123), CByte(170), CByte(179))
		btnBatal.Font = New Font("Segoe UI Semibold", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
		btnBatal.Location = New Point(664, 225)
		btnBatal.Name = "btnBatal"
		btnBatal.Size = New Size(124, 38)
		btnBatal.TabIndex = 10
		btnBatal.Text = "BATAL"
		btnBatal.UseVisualStyleBackColor = False
		' 
		' ErrorProvider1
		' 
		ErrorProvider1.ContainerControl = Me
		' 
		' FormDataUser
		' 
		AutoScaleDimensions = New SizeF(8.0F, 20.0F)
		AutoScaleMode = AutoScaleMode.Font
		BackColor = Color.FromArgb(CByte(235), CByte(242), CByte(242))
		ClientSize = New Size(801, 503)
		Controls.Add(btnBatal)
		Controls.Add(btnHapus)
		Controls.Add(btnEdit)
		Controls.Add(btnSimpan)
		Controls.Add(Panel4)
		Controls.Add(dgvUser)
		Controls.Add(cmbLevel)
		Controls.Add(txtSearch)
		Controls.Add(Panel1)
		ForeColor = Color.White
		Name = "FormDataUser"
		StartPosition = FormStartPosition.CenterScreen
		Text = "Form1"
		CType(dgvUser, ComponentModel.ISupportInitialize).EndInit()
		Panel4.ResumeLayout(False)
		Panel4.PerformLayout()
		Panel1.ResumeLayout(False)
		Panel1.PerformLayout()
		CType(ErrorProvider1, ComponentModel.ISupportInitialize).EndInit()
		ResumeLayout(False)
		PerformLayout()
	End Sub
	Friend WithEvents txtSearch As TextBox
	Friend WithEvents cmbLevel As ComboBox
	Friend WithEvents btnSimpan As Button
	Friend WithEvents dgvUser As DataGridView
	Friend WithEvents Panel4 As Panel
	Friend WithEvents Label1 As Label
	Friend WithEvents Panel1 As Panel
	Friend WithEvents Label6 As Label
	Friend WithEvents Label5 As Label
	Friend WithEvents Label4 As Label
	Friend WithEvents Label3 As Label
	Friend WithEvents Label2 As Label
	Friend WithEvents txtNimRef As TextBox
	Friend WithEvents cmbStatus As ComboBox
	Friend WithEvents cmbLevelAkses As ComboBox
	Friend WithEvents txtPassword As TextBox
	Friend WithEvents txtUsername As TextBox
	Friend WithEvents btnEdit As Button
	Friend WithEvents btnHapus As Button
	Friend WithEvents Label7 As Label
	Friend WithEvents btnBatal As Button
	Friend WithEvents ErrorProvider1 As ErrorProvider

End Class