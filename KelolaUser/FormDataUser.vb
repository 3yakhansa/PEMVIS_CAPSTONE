Imports MySqlConnector
Imports System.Security.Cryptography
Imports System.Text

' ================================================================
'  FormDataUser.vb
'  Cocok dengan database: db_nilai_xyz (MariaDB 10.4)
'  Tabel   : `user`   → idUser, username, password, lvl,
'                        nimRef, isActive, lastLogin
'  Log     : `log`    → idLog, tanggalJam, aktifitas,
'                        nimAdmin (FK → admin.nimAdmin),
'                        ipAddress, keterangan
'
'  PENTING – FK log.nimAdmin → admin.nimAdmin
'  Pastikan ada 1 baris di tabel admin sebelum fitur log aktif,
'  ATAU set nimAdmin di CatatLog() sesuai NIM admin yg login.
'  Selama development, log dinonaktifkan jika tabel admin kosong.
' ================================================================
Public Class FormDataUser

    ' ── State ────────────────────────────────────────────
    Private isEditMode As Boolean = False
    Private selectedIdUser As Integer = -1

    ' ══════════════════════════════════════════════════════
    ' FORM LOAD
    ' ══════════════════════════════════════════════════════
    Private Sub FormDataUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Uji koneksi sekali di awal agar error koneksi jelas
        If Not TesKoneksi() Then Return
        InitComboBoxes()
        LoadData()
        SetButtonState(False)
    End Sub

    ' ── Tes koneksi saat load ──────────────────────────────
    Private Function TesKoneksi() As Boolean
        Try
            Using conn As MySqlConnection = GetConnection()
                conn.Open()
                Return True
            End Using
        Catch ex As Exception
            MessageBox.Show(
                "Tidak dapat terhubung ke database!" & vbNewLine & vbNewLine &
                ex.Message & vbNewLine & vbNewLine &
                "Periksa ConnectionModule.vb (Server, Port, Database, User, Password).",
                "Koneksi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    ' ══════════════════════════════════════════════════════
    ' INISIALISASI COMBOBOX
    ' ══════════════════════════════════════════════════════
    Private Sub InitComboBoxes()
        ' cmbLevel = filter tabel (di luar Panel1)
        cmbLevel.DropDownStyle = ComboBoxStyle.DropDownList
        cmbLevel.Items.Clear()
        cmbLevel.Items.AddRange(New Object() {"Semua Level", "Admin (Lvl1)", "Viewer (Lvl2)"})
        cmbLevel.SelectedIndex = 0

        ' cmbLevelAkses = input form (di Panel1)
        ' Sesuai CHECK constraint: lvl IN (1,2)
        cmbLevelAkses.DropDownStyle = ComboBoxStyle.DropDownList
        cmbLevelAkses.Items.Clear()
        cmbLevelAkses.Items.Add("-- Pilih Level --")   ' index 0
        cmbLevelAkses.Items.Add("1 - Admin (CRUD)")    ' index 1 → lvl=1
        cmbLevelAkses.Items.Add("2 - Viewer (Lihat Saja)") ' index 2 → lvl=2
        cmbLevelAkses.SelectedIndex = 0

        ' cmbStatus = input form (di Panel1)
        ' Sesuai kolom isActive tinyint(1) DEFAULT 1
        cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList
        cmbStatus.Items.Clear()
        cmbStatus.Items.Add("-- Pilih Status --") ' index 0
        cmbStatus.Items.Add("Aktif")              ' index 1 → isActive=1
        cmbStatus.Items.Add("Nonaktif")           ' index 2 → isActive=0
        cmbStatus.SelectedIndex = 0

        ' Style tombol
        For Each btn As Button In {btnSimpan, btnEdit, btnHapus, btnBatal}
            btn.ForeColor = Color.White
            btn.FlatStyle = FlatStyle.Flat
            btn.FlatAppearance.BorderSize = 0
            btn.Cursor = Cursors.Hand
        Next

        txtPassword.UseSystemPasswordChar = True
    End Sub

    ' ══════════════════════════════════════════════════════
    ' LOAD DATA KE DATAGRIDVIEW
    ' Kolom tabel `user`:
    '   idUser | username | password | lvl | nimRef | isActive | lastLogin
    ' Alias tanpa spasi agar DataTable bisa dibaca DGV
    ' ══════════════════════════════════════════════════════
    Private Sub LoadData(Optional keyword As String = "",
                         Optional filterLevel As String = "")
        Try
            Using conn As MySqlConnection = GetConnection()
                conn.Open()

                Dim sql As String =
                    "SELECT " &
                    "  u.idUser                                               AS ID, " &
                    "  u.username                                             AS Username, " &
                    "  CASE u.lvl WHEN 1 THEN 'Admin (CRUD)' " &
                    "             ELSE 'Viewer' END                           AS Level, " &
                    "  IFNULL(u.nimRef, '-')                                  AS NIMRef, " &
                    "  CASE u.isActive WHEN 1 THEN 'Aktif' " &
                    "                  ELSE 'Nonaktif' END                    AS Status, " &
                    "  IFNULL(DATE_FORMAT(u.lastLogin,'%d-%m-%Y %H:%i'), '-') AS LoginTerakhir " &
                    "FROM `user` u " &
                    "WHERE (u.username LIKE @kw OR IFNULL(u.nimRef,'') LIKE @kw)"

                ' Filter level sesuai nilai cmbLevel
                Select Case filterLevel
                    Case "Admin (Lvl1)" : sql &= " AND u.lvl = 1"
                    Case "Viewer (Lvl2)" : sql &= " AND u.lvl = 2"
                End Select

                sql &= " ORDER BY u.idUser"

                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@kw", "%" & keyword & "%")

                    Using da As New MySqlDataAdapter(cmd)
                        Dim dt As New DataTable()
                        da.Fill(dt)
                        dgvUser.DataSource = dt

                        ' Atur header & lebar kolom
                        If dgvUser.Columns.Count > 0 Then
                            dgvUser.Columns("ID").HeaderText = "ID"
                            dgvUser.Columns("ID").Width = 45
                            dgvUser.Columns("Username").HeaderText = "Username"
                            dgvUser.Columns("Username").Width = 165
                            dgvUser.Columns("Level").HeaderText = "Level"
                            dgvUser.Columns("Level").Width = 115
                            dgvUser.Columns("NIMRef").HeaderText = "NIM Referensi"
                            dgvUser.Columns("NIMRef").Width = 120
                            dgvUser.Columns("Status").HeaderText = "Status"
                            dgvUser.Columns("Status").Width = 85
                            dgvUser.Columns("LoginTerakhir").HeaderText = "Login Terakhir"
                        End If

                        ' Style row
                        dgvUser.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(226, 240, 241)
                        dgvUser.DefaultCellStyle.ForeColor = Color.FromArgb(30, 45, 48)
                        dgvUser.DefaultCellStyle.SelectionBackColor = Color.FromArgb(74, 124, 134)
                        dgvUser.DefaultCellStyle.SelectionForeColor = Color.White
                        dgvUser.DefaultCellStyle.Font = New Font("Segoe UI", 9.0F)
                        dgvUser.RowTemplate.Height = 30
                    End Using
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Gagal memuat data:" & vbNewLine & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ══════════════════════════════════════════════════════
    ' KLIK BARIS DGV → ISI FORM OTOMATIS
    ' ══════════════════════════════════════════════════════
    Private Sub dgvUser_CellClick(sender As Object, e As DataGridViewCellEventArgs) _
        Handles dgvUser.CellClick

        If e.RowIndex < 0 Then Return

        selectedIdUser = CInt(dgvUser.Rows(e.RowIndex).Cells("ID").Value)
        IsiFormDariId(selectedIdUser)
        SetButtonState(True)
        isEditMode = False
        SetFormReadOnly(True)
        ErrorProvider1.Clear()
    End Sub

    Private Sub IsiFormDariId(id As Integer)
        Try
            Using conn As MySqlConnection = GetConnection()
                conn.Open()
                Using cmd As New MySqlCommand(
                    "SELECT username, lvl, nimRef, isActive " &
                    "FROM `user` WHERE idUser = @id", conn)

                    cmd.Parameters.AddWithValue("@id", id)
                    Using r As MySqlDataReader = cmd.ExecuteReader()
                        If r.Read() Then
                            txtUsername.Text = r("username").ToString()
                            txtPassword.Text = ""

                            ' lvl: 1→index 1 (Admin), 2→index 2 (Viewer)
                            cmbLevelAkses.SelectedIndex = If(CInt(r("lvl")) = 1, 1, 2)

                            ' isActive: 1→index 1 (Aktif), 0→index 2 (Nonaktif)
                            cmbStatus.SelectedIndex = If(CInt(r("isActive")) = 1, 1, 2)

                            txtNimRef.Text = If(IsDBNull(r("nimRef")), "", r("nimRef").ToString())
                        End If
                    End Using
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Gagal memuat detail user: " & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ══════════════════════════════════════════════════════
    ' TOMBOL SIMPAN — mode tambah / mode edit
    ' ══════════════════════════════════════════════════════
    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        If isEditMode Then SimpanEdit() Else SimpanBaru()
    End Sub

    ' ── Tambah baru ──────────────────────────────────────
    Private Sub SimpanBaru()
        If Not ValidasiForm(isTambah:=True) Then Return

        Dim username As String = txtUsername.Text.Trim()
        Dim password As String = txtPassword.Text.Trim()
        Dim lvl As Integer = GetLvlDariCombo()
        Dim nimRef As Object = GetNimRef()
        Dim isActive As Integer = GetIsActive()

        Try
            Using conn As MySqlConnection = GetConnection()
                conn.Open()

                If UsernameAda(username, -1, conn) Then
                    ErrorProvider1.SetError(txtUsername, "Username sudah digunakan")
                    txtUsername.Focus()
                    Return
                End If

                Using cmd As New MySqlCommand(
                    "INSERT INTO `user` (username, password, lvl, nimRef, isActive) " &
                    "VALUES (@un, @pw, @lvl, @nim, @aktif)", conn)

                    cmd.Parameters.AddWithValue("@un", username)
                    cmd.Parameters.AddWithValue("@pw", HashPassword(password))
                    cmd.Parameters.AddWithValue("@lvl", lvl)
                    cmd.Parameters.AddWithValue("@nim", nimRef)
                    cmd.Parameters.AddWithValue("@aktif", isActive)
                    cmd.ExecuteNonQuery()
                End Using

                ' Log: hanya jika tabel admin tidak kosong
                CatatLog(conn, "Tambah User", "Menambah user baru: " & username)
            End Using

            MessageBox.Show("User baru berhasil ditambahkan!",
                            "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
            BersihkanForm()
            LoadData(txtCariUser.Text.Trim(), GetFilterLevel())

        Catch ex As MySqlException When ex.Number = 1452
            ' Error FK violation (misal nimRef tidak ada di mahasiswa/admin)
            MessageBox.Show(
                "NIM Referensi tidak ditemukan di tabel mahasiswa/admin." & vbNewLine &
                "Kosongkan NIM Referensi jika tidak ingin menghubungkan ke data tertentu.",
                "NIM Referensi Tidak Valid", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Catch ex As Exception
            MessageBox.Show("Gagal menyimpan: " & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ── Simpan hasil edit ────────────────────────────────
    Private Sub SimpanEdit()
        If Not ValidasiForm(isTambah:=False) Then Return

        Dim username As String = txtUsername.Text.Trim()
        Dim password As String = txtPassword.Text.Trim()
        Dim lvl As Integer = GetLvlDariCombo()
        Dim nimRef As Object = GetNimRef()
        Dim isActive As Integer = GetIsActive()

        Try
            Using conn As MySqlConnection = GetConnection()
                conn.Open()

                If UsernameAda(username, selectedIdUser, conn) Then
                    ErrorProvider1.SetError(txtUsername, "Username sudah digunakan user lain")
                    txtUsername.Focus()
                    Return
                End If

                Dim sql As String
                If String.IsNullOrEmpty(password) Then
                    sql = "UPDATE `user` SET username=@un, lvl=@lvl, " &
                          "nimRef=@nim, isActive=@aktif WHERE idUser=@id"
                Else
                    sql = "UPDATE `user` SET username=@un, password=@pw, lvl=@lvl, " &
                          "nimRef=@nim, isActive=@aktif WHERE idUser=@id"
                End If

                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@un", username)
                    cmd.Parameters.AddWithValue("@lvl", lvl)
                    cmd.Parameters.AddWithValue("@nim", nimRef)
                    cmd.Parameters.AddWithValue("@aktif", isActive)
                    cmd.Parameters.AddWithValue("@id", selectedIdUser)
                    If Not String.IsNullOrEmpty(password) Then
                        cmd.Parameters.AddWithValue("@pw", HashPassword(password))
                    End If
                    cmd.ExecuteNonQuery()
                End Using

                CatatLog(conn, "Edit User",
                         "Mengubah user ID=" & selectedIdUser & " (" & username & ")")
            End Using

            MessageBox.Show("Data user berhasil diubah!",
                            "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
            BersihkanForm()
            LoadData(txtCariUser.Text.Trim(), GetFilterLevel())

        Catch ex As Exception
            MessageBox.Show("Gagal mengubah data: " & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ══════════════════════════════════════════════════════
    ' TOMBOL EDIT → aktifkan mode edit
    ' ══════════════════════════════════════════════════════
    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If selectedIdUser < 0 Then
            MessageBox.Show("Pilih user pada tabel terlebih dahulu.",
                            "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        isEditMode = True
        SetFormReadOnly(False)
        txtPassword.Text = ""
        btnSimpan.Text = "SIMPAN EDIT"
        txtUsername.Focus()
    End Sub

    ' ══════════════════════════════════════════════════════
    ' TOMBOL HAPUS
    ' ══════════════════════════════════════════════════════
    Private Sub btnHapus_Click(sender As Object, e As EventArgs) Handles btnHapus.Click
        If selectedIdUser < 0 Then
            MessageBox.Show("Pilih user pada tabel terlebih dahulu.",
                            "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim konfirmasi As DialogResult = MessageBox.Show(
            "Yakin ingin menghapus user """ & txtUsername.Text & """?" & vbNewLine &
            "Tindakan ini tidak dapat dibatalkan.",
            "Konfirmasi Hapus",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning)

        If konfirmasi <> DialogResult.Yes Then Return

        Try
            Dim namaUser As String = txtUsername.Text
            Using conn As MySqlConnection = GetConnection()
                conn.Open()

                ' Log dulu sebelum hapus (karena setelah hapus data sudah tidak ada)
                CatatLog(conn, "Hapus User",
                         "Menghapus user ID=" & selectedIdUser & " (" & namaUser & ")")

                Using cmd As New MySqlCommand(
                    "DELETE FROM `user` WHERE idUser = @id", conn)
                    cmd.Parameters.AddWithValue("@id", selectedIdUser)
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("User berhasil dihapus.",
                            "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
            BersihkanForm()
            LoadData(txtCariUser.Text.Trim(), GetFilterLevel())

        Catch ex As Exception
            MessageBox.Show("Gagal menghapus: " & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ══════════════════════════════════════════════════════
    ' TOMBOL BATAL
    ' ══════════════════════════════════════════════════════
    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        BersihkanForm()
    End Sub

    ' ══════════════════════════════════════════════════════
    ' PENCARIAN — real-time
    ' ══════════════════════════════════════════════════════
    Private Sub txtCariUser_TextChanged(sender As Object, e As EventArgs) _
        Handles txtCariUser.TextChanged
        LoadData(txtCariUser.Text.Trim(), GetFilterLevel())
    End Sub

    ' ══════════════════════════════════════════════════════
    ' FILTER LEVEL
    ' ══════════════════════════════════════════════════════
    Private Sub cmbLevel_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles cmbLevel.SelectedIndexChanged
        LoadData(txtCariUser.Text.Trim(), GetFilterLevel())
    End Sub

    ' ══════════════════════════════════════════════════════
    ' VALIDASI FORM
    ' ══════════════════════════════════════════════════════
    Private Function ValidasiForm(isTambah As Boolean) As Boolean
        ErrorProvider1.Clear()
        Dim valid As Boolean = True

        ' Username wajib, min 3 karakter
        If String.IsNullOrWhiteSpace(txtUsername.Text) Then
            ErrorProvider1.SetError(txtUsername, "Username wajib diisi")
            valid = False
        ElseIf txtUsername.Text.Trim().Length < 3 Then
            ErrorProvider1.SetError(txtUsername, "Username minimal 3 karakter")
            valid = False
        End If

        ' Password: wajib saat tambah; opsional saat edit (min 6 jika diisi)
        If isTambah Then
            If String.IsNullOrWhiteSpace(txtPassword.Text) Then
                ErrorProvider1.SetError(txtPassword, "Password wajib diisi")
                valid = False
            ElseIf txtPassword.Text.Length < 6 Then
                ErrorProvider1.SetError(txtPassword, "Password minimal 6 karakter")
                valid = False
            End If
        Else
            If Not String.IsNullOrEmpty(txtPassword.Text) AndAlso
               txtPassword.Text.Length < 6 Then
                ErrorProvider1.SetError(txtPassword, "Password minimal 6 karakter jika diisi")
                valid = False
            End If
        End If

        ' Level akses wajib dipilih (index 0 = placeholder)
        If cmbLevelAkses.SelectedIndex <= 0 Then
            ErrorProvider1.SetError(cmbLevelAkses, "Level akses wajib dipilih")
            valid = False
        End If

        ' Status wajib dipilih (index 0 = placeholder)
        If cmbStatus.SelectedIndex <= 0 Then
            ErrorProvider1.SetError(cmbStatus, "Status wajib dipilih")
            valid = False
        End If

        Return valid
    End Function

    ' ══════════════════════════════════════════════════════
    ' HELPER: CEK DUPLIKAT USERNAME
    ' ══════════════════════════════════════════════════════
    Private Function UsernameAda(username As String, excludeId As Integer,
                                  conn As MySqlConnection) As Boolean
        Using cmd As New MySqlCommand(
            "SELECT COUNT(*) FROM `user` WHERE username = @un AND idUser <> @id",
            conn)
            cmd.Parameters.AddWithValue("@un", username)
            cmd.Parameters.AddWithValue("@id", If(excludeId < 0, -1, excludeId))
            Return CInt(cmd.ExecuteScalar()) > 0
        End Using
    End Function

    ' ══════════════════════════════════════════════════════
    ' HELPER: HASH PASSWORD SHA-256
    ' ══════════════════════════════════════════════════════
    Private Function HashPassword(plain As String) As String
        Using sha As New SHA256Managed()
            Dim bytes() As Byte = sha.ComputeHash(Encoding.UTF8.GetBytes(plain))
            Return BitConverter.ToString(bytes).Replace("-", "").ToLower()
        End Using
    End Function

    ' ══════════════════════════════════════════════════════
    ' HELPER: CATAT LOG
    ' ──────────────────────────────────────────────────────
    ' PERHATIAN FK: log.nimAdmin → admin.nimAdmin
    ' Log hanya dieksekusi jika ada data di tabel admin.
    ' Ganti "ADMIN_NIM_HERE" dengan NIM admin yg sedang login
    ' (dari modul session global tim kamu).
    ' Selama development/testing: pastikan insert dulu 1 baris
    ' ke tabel admin, contoh:
    '   INSERT INTO admin (nimAdmin, namaAdmin) VALUES ('ADM001', 'Admin');
    ' ══════════════════════════════════════════════════════
    Private Sub CatatLog(conn As MySqlConnection, aktifitas As String, keterangan As String)
        Try
            ' ↓ Ganti dengan NIM admin yg login, misal: ModulSession.NimAdmin
            Dim nimAdmin As String = "ADM001"

            ' Cek dulu apakah nimAdmin ada di tabel admin
            Using cekCmd As New MySqlCommand(
                "SELECT COUNT(*) FROM admin WHERE nimAdmin = @nim", conn)
                cekCmd.Parameters.AddWithValue("@nim", nimAdmin)
                If CInt(cekCmd.ExecuteScalar()) = 0 Then Return ' skip log jika belum ada
            End Using

            Using cmd As New MySqlCommand(
                "INSERT INTO log (aktifitas, nimAdmin, ipAddress, keterangan) " &
                "VALUES (@akt, @nim, @ip, @ket)", conn)
                cmd.Parameters.AddWithValue("@akt", aktifitas)
                cmd.Parameters.AddWithValue("@nim", nimAdmin)
                cmd.Parameters.AddWithValue("@ip", GetLocalIP())
                cmd.Parameters.AddWithValue("@ket", keterangan)
                cmd.ExecuteNonQuery()
            End Using

        Catch
            ' Log gagal tidak boleh hentikan proses utama
        End Try
    End Sub

    Private Function GetLocalIP() As String
        Try
            For Each ip In Net.Dns.GetHostEntry(Net.Dns.GetHostName()).AddressList
                If ip.AddressFamily = Net.Sockets.AddressFamily.InterNetwork Then
                    Return ip.ToString()
                End If
            Next
            Return "127.0.0.1"
        Catch
            Return "127.0.0.1"
        End Try
    End Function

    ' ══════════════════════════════════════════════════════
    ' HELPER: BERSIHKAN FORM
    ' ══════════════════════════════════════════════════════
    Private Sub BersihkanForm()
        txtUsername.Text = ""
        txtPassword.Text = ""
        txtNimRef.Text = ""
        cmbLevelAkses.SelectedIndex = 0
        cmbStatus.SelectedIndex = 0
        selectedIdUser = -1
        isEditMode = False
        btnSimpan.Text = "SIMPAN"
        ErrorProvider1.Clear()
        SetButtonState(False)
        SetFormReadOnly(False)
    End Sub

    ' ══════════════════════════════════════════════════════
    ' HELPER: NILAI DARI COMBO
    ' ══════════════════════════════════════════════════════
    Private Function GetLvlDariCombo() As Integer
        ' index 1 = Admin → lvl 1 | index 2 = Viewer → lvl 2
        Return If(cmbLevelAkses.SelectedIndex = 1, 1, 2)
    End Function

    Private Function GetIsActive() As Integer
        ' index 1 = Aktif → 1 | index 2 = Nonaktif → 0
        Return If(cmbStatus.SelectedIndex = 1, 1, 0)
    End Function

    Private Function GetNimRef() As Object
        Dim val As String = txtNimRef.Text.Trim()
        Return If(String.IsNullOrEmpty(val), CObj(DBNull.Value), CObj(val))
    End Function

    Private Function GetFilterLevel() As String
        If cmbLevel.SelectedIndex <= 0 Then Return ""
        Return cmbLevel.SelectedItem.ToString()
    End Function

    ' ══════════════════════════════════════════════════════
    ' HELPER: SET READONLY FORM INPUT
    ' ══════════════════════════════════════════════════════
    Private Sub SetFormReadOnly(isReadOnly As Boolean)
        txtUsername.ReadOnly = isReadOnly
        txtPassword.ReadOnly = isReadOnly
        cmbLevelAkses.Enabled = Not isReadOnly
        cmbStatus.Enabled = Not isReadOnly
        txtNimRef.ReadOnly = isReadOnly
    End Sub

    ' ══════════════════════════════════════════════════════
    ' HELPER: SET STATE TOMBOL EDIT & HAPUS
    ' ══════════════════════════════════════════════════════
    Private Sub SetButtonState(adaBaris As Boolean)
        btnEdit.Enabled = adaBaris
        btnHapus.Enabled = adaBaris
    End Sub

End Class