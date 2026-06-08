Imports MySqlConnector
Imports System.Security.Cryptography
Imports System.Text

Partial Public Class FormDataUser

    Private isEditMode As Boolean = False
    Private selectedIdUser As Integer = -1

    ' ══════════════════════════════════════════════════════
    ' FORM LOAD
    ' ══════════════════════════════════════════════════════
    Private Sub FormDataUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not TesKoneksi() Then Return
        InitComboBoxes()
        LoadData()
        SetButtonState(False)
    End Sub

    Private Function TesKoneksi() As Boolean
        Try
            Using conn As MySqlConnection = ConnectionModule.GetConnection()
                conn.Open()
                Return True
            End Using
        Catch ex As Exception
            MessageBox.Show(
                "Tidak dapat terhubung ke database!" & vbCrLf & vbCrLf &
                ex.Message & vbCrLf & vbCrLf &
                "Periksa ConnectionModule.vb (Server, Port, Database, User, Password).",
                "Koneksi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    ' ══════════════════════════════════════════════════════
    ' INISIALISASI COMBOBOX
    ' ══════════════════════════════════════════════════════
    Private Sub InitComboBoxes()
        cmbLevel.DropDownStyle = ComboBoxStyle.DropDownList
        cmbLevel.Items.Clear()
        ' Urutan dan label disesuaikan (Lvl 1 = Mahasiswa, Lvl 2 = Admin)
        cmbLevel.Items.AddRange(New Object() {"Semua Level", "Mahasiswa (Lvl1)", "Admin (Lvl2)"})
        cmbLevel.SelectedIndex = 0

        cmbLevelAkses.DropDownStyle = ComboBoxStyle.DropDownList
        cmbLevelAkses.Items.Clear()
        cmbLevelAkses.Items.Add("-- Pilih Level --")
        ' PERBAIKAN: Label disesuaikan agar tidak membingungkan
        cmbLevelAkses.Items.Add("1 - Mahasiswa (Viewer)")   ' Index 1 → lvl = 1
        cmbLevelAkses.Items.Add("2 - Admin (CRUD)")          ' Index 2 → lvl = 2
        cmbLevelAkses.SelectedIndex = 0

        cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList
        cmbStatus.Items.Clear()
        cmbStatus.Items.Add("-- Pilih Status --")
        cmbStatus.Items.Add("Aktif")
        cmbStatus.Items.Add("Nonaktif")
        cmbStatus.SelectedIndex = 0

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
    ' ══════════════════════════════════════════════════════
    Private Sub LoadData(Optional keyword As String = "", Optional filterLevel As String = "")
        Try
            Using conn As MySqlConnection = ConnectionModule.GetConnection()
                conn.Open()

                Dim sql As String =
                    "SELECT " &
                    "  u.idUser                                               AS ID, " &
                    "  u.username                                             AS Username, " &
                    "  CASE u.lvl WHEN 1 THEN 'Mahasiswa (Viewer)' " &              ' Lvl 1 = Mahasiswa
                    "             ELSE 'Admin (CRUD)' END               AS Level, " &
                    "  IFNULL(u.nimRef, '-')                                  AS NIMRef, " &
                    "  CASE u.isActive WHEN 1 THEN 'Aktif' " &
                    "                  ELSE 'Nonaktif' END                    AS Status, " &
                    "  IFNULL(DATE_FORMAT(u.lastLogin,'%d-%m-%Y %H:%i'), '-') AS LoginTerakhir " &
                    "FROM `user` u " &
                    "WHERE (u.username LIKE @kw OR IFNULL(u.nimRef,'') LIKE @kw)"

                ' Filter disesuaikan dengan label baru
                Select Case filterLevel
                    Case "Mahasiswa (Lvl1)" : sql &= " AND u.lvl = 1"
                    Case "Admin (Lvl2)" : sql &= " AND u.lvl = 2"
                End Select

                sql &= " ORDER BY u.idUser"

                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@kw", "%" & keyword & "%")

                    Using da As New MySqlDataAdapter(cmd)
                        Dim dt As New DataTable()
                        da.Fill(dt)
                        dgvUser.DataSource = dt

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
            MessageBox.Show("Gagal memuat data:" & vbCrLf & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ══════════════════════════════════════════════════════
    ' KLIK BARIS DGV → ISI FORM
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
            Using conn As MySqlConnection = ConnectionModule.GetConnection()
                conn.Open()
                Using cmd As New MySqlCommand(
                    "SELECT * FROM `user` WHERE idUser = @id LIMIT 1", conn)
                    cmd.Parameters.AddWithValue("@id", id)
                    Using r As MySqlDataReader = cmd.ExecuteReader()
                        If r.Read() Then
                            txtUsername.Text = r("username").ToString()
                            txtPassword.Text = ""
                            txtNimRef.Text = If(IsDBNull(r("nimRef")), "", r("nimRef").ToString())
                            cmbLevelAkses.SelectedIndex = If(CInt(r("lvl")) = 1, 1, 2)
                            cmbStatus.SelectedIndex = If(CInt(r("isActive")) = 1, 1, 2)
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Gagal mengambil data:" & vbCrLf & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ── Filter / Search ──────────────────────────────────
    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        LoadData(txtSearch.Text.Trim(), GetFilterLevel())
    End Sub

    Private Sub cmbLevel_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbLevel.SelectedIndexChanged
        LoadData(txtSearch.Text.Trim(), GetFilterLevel())
    End Sub

    ' ── Tombol SIMPAN (tambah baru) ───────────────────────
    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        If isEditMode Then
            UpdateUser()
        Else
            TambahUser()
        End If
    End Sub

    Private Sub TambahUser()
        If Not ValidasiForm(True) Then Return

        Try
            Using conn As MySqlConnection = ConnectionModule.GetConnection()
                conn.Open()

                If UsernameAda(txtUsername.Text.Trim(), -1, conn) Then
                    ErrorProvider1.SetError(txtUsername, "Username sudah digunakan")
                    MessageBox.Show("Username sudah digunakan!", "Duplikat",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If

                Using cmd As New MySqlCommand(
                    "INSERT INTO `user` (username, password, lvl, nimRef, isActive) " &
                    "VALUES (@un, @pw, @lvl, @nim, @act)", conn)
                    cmd.Parameters.AddWithValue("@un", txtUsername.Text.Trim())
                    cmd.Parameters.AddWithValue("@pw", HashPassword(txtPassword.Text))
                    cmd.Parameters.AddWithValue("@lvl", GetLvlDariCombo())
                    cmd.Parameters.AddWithValue("@nim", GetNimRef())
                    cmd.Parameters.AddWithValue("@act", GetIsActive())
                    cmd.ExecuteNonQuery()
                End Using

                CatatLog(conn, "TAMBAH USER", "Username: " & txtUsername.Text.Trim())
            End Using

            MessageBox.Show("User berhasil ditambahkan.", "Berhasil",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            BersihkanForm()
            LoadData()

        Catch ex As Exception
            MessageBox.Show("Gagal menambah user:" & vbCrLf & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ── Tombol EDIT ──────────────────────────────────────
    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If selectedIdUser < 0 Then Return
        isEditMode = True
        SetFormReadOnly(False)
        btnSimpan.Text = "UPDATE"
    End Sub

    Private Sub UpdateUser()
        If Not ValidasiForm(False) Then Return

        Try
            Using conn As MySqlConnection = ConnectionModule.GetConnection()
                conn.Open()

                If UsernameAda(txtUsername.Text.Trim(), selectedIdUser, conn) Then
                    ErrorProvider1.SetError(txtUsername, "Username sudah digunakan")
                    MessageBox.Show("Username sudah digunakan user lain!", "Duplikat",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If

                Dim sqlUpdate As String
                If String.IsNullOrEmpty(txtPassword.Text) Then
                    sqlUpdate = "UPDATE `user` SET username=@un, lvl=@lvl, nimRef=@nim, isActive=@act WHERE idUser=@id"
                Else
                    sqlUpdate = "UPDATE `user` SET username=@un, password=@pw, lvl=@lvl, nimRef=@nim, isActive=@act WHERE idUser=@id"
                End If

                Using cmd As New MySqlCommand(sqlUpdate, conn)
                    cmd.Parameters.AddWithValue("@un", txtUsername.Text.Trim())
                    If Not String.IsNullOrEmpty(txtPassword.Text) Then
                        cmd.Parameters.AddWithValue("@pw", HashPassword(txtPassword.Text))
                    End If
                    cmd.Parameters.AddWithValue("@lvl", GetLvlDariCombo())
                    cmd.Parameters.AddWithValue("@nim", GetNimRef())
                    cmd.Parameters.AddWithValue("@act", GetIsActive())
                    cmd.Parameters.AddWithValue("@id", selectedIdUser)
                    cmd.ExecuteNonQuery()
                End Using

                CatatLog(conn, "EDIT USER", "ID: " & selectedIdUser & " | Username: " & txtUsername.Text.Trim())
            End Using

            MessageBox.Show("User berhasil diperbarui.", "Berhasil",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            BersihkanForm()
            LoadData()

        Catch ex As Exception
            MessageBox.Show("Gagal memperbarui user:" & vbCrLf & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ── Tombol HAPUS ─────────────────────────────────────
    Private Sub btnHapus_Click(sender As Object, e As EventArgs) Handles btnHapus.Click
        If selectedIdUser < 0 Then Return

        If MessageBox.Show("Yakin ingin menghapus user ini?", "Konfirmasi Hapus",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.No Then Return

        Try
            Using conn As MySqlConnection = ConnectionModule.GetConnection()
                conn.Open()
                Using cmd As New MySqlCommand(
                    "DELETE FROM `user` WHERE idUser = @id", conn)
                    cmd.Parameters.AddWithValue("@id", selectedIdUser)
                    cmd.ExecuteNonQuery()
                End Using
                CatatLog(conn, "HAPUS USER", "ID: " & selectedIdUser & " | Username: " & txtUsername.Text.Trim())
            End Using

            MessageBox.Show("User berhasil dihapus.", "Berhasil",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            BersihkanForm()
            LoadData()

        Catch ex As Exception
            MessageBox.Show("Gagal menghapus user:" & vbCrLf & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ── Tombol BATAL ─────────────────────────────────────
    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        BersihkanForm()
    End Sub

    ' ══════════════════════════════════════════════════════
    ' VALIDASI
    ' ══════════════════════════════════════════════════════
    Private Function ValidasiForm(isTambah As Boolean) As Boolean
        ErrorProvider1.Clear()
        Dim valid As Boolean = True

        If String.IsNullOrWhiteSpace(txtUsername.Text) Then
            ErrorProvider1.SetError(txtUsername, "Username wajib diisi")
            valid = False
        ElseIf txtUsername.Text.Trim().Length < 3 Then
            ErrorProvider1.SetError(txtUsername, "Username minimal 3 karakter")
            valid = False
        End If

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

        If cmbLevelAkses.SelectedIndex <= 0 Then
            ErrorProvider1.SetError(cmbLevelAkses, "Level akses wajib dipilih")
            valid = False
        End If

        If cmbStatus.SelectedIndex <= 0 Then
            ErrorProvider1.SetError(cmbStatus, "Status wajib dipilih")
            valid = False
        End If

        Return valid
    End Function

    ' ══════════════════════════════════════════════════════
    ' HELPER: DUPLIKAT, HASH, LOG, dsb.
    ' ══════════════════════════════════════════════════════
    Private Function UsernameAda(username As String, excludeId As Integer,
                                  conn As MySqlConnection) As Boolean
        Using cmd As New MySqlCommand(
            "SELECT COUNT(*) FROM `user` WHERE username = @un AND idUser <> @id", conn)
            cmd.Parameters.AddWithValue("@un", username)
            cmd.Parameters.AddWithValue("@id", If(excludeId < 0, -1, excludeId))
            Return CInt(cmd.ExecuteScalar()) > 0
        End Using
    End Function

    Private Function HashPassword(plain As String) As String
        Using sha As New SHA256Managed()
            Dim bytes() As Byte = sha.ComputeHash(Encoding.UTF8.GetBytes(plain))
            Return BitConverter.ToString(bytes).Replace("-", "").ToLower()
        End Using
    End Function

    ''' <summary>
    ''' Mencatat log ke tabel log.
    ''' nimAdmin diambil dari Session.nimAdmin (diisi saat login).
    ''' </summary>
    Private Sub CatatLog(conn As MySqlConnection, aktifitas As String, keterangan As String)
        Try
            Dim nimAdmin As String = Session.nimAdmin
            If String.IsNullOrEmpty(nimAdmin) Then Return

            Using cekCmd As New MySqlCommand(
                "SELECT COUNT(*) FROM admin WHERE nimAdmin = @nim", conn)
                cekCmd.Parameters.AddWithValue("@nim", nimAdmin)
                If CInt(cekCmd.ExecuteScalar()) = 0 Then Return
            End Using

            Using cmd As New MySqlCommand(
                "INSERT INTO log (tanggalJam, aktifitas, nimAdmin, ipAddress, keterangan) " &
                "VALUES (NOW(), @akt, @nim, @ip, @ket)", conn)
                cmd.Parameters.AddWithValue("@akt", aktifitas)
                cmd.Parameters.AddWithValue("@nim", nimAdmin)
                cmd.Parameters.AddWithValue("@ip", GetLocalIP())
                cmd.Parameters.AddWithValue("@ket", keterangan)
                cmd.ExecuteNonQuery()
            End Using
        Catch
        End Try
    End Sub

    Private Function GetLocalIP() As String
        Try
            For Each ip In Net.Dns.GetHostEntry(Net.Dns.GetHostName()).AddressList
                If ip.AddressFamily = Net.Sockets.AddressFamily.InterNetwork Then Return ip.ToString()
            Next
            Return "127.0.0.1"
        Catch
            Return "127.0.0.1"
        End Try
    End Function

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

    ' ── Mapping combo index → nilai lvl di database ──────────────
    ' Index 1 → Mahasiswa (lvl 1), Index 2 → Admin (lvl 2)
    Private Function GetLvlDariCombo() As Integer
        Return If(cmbLevelAkses.SelectedIndex = 1, 1, 2)
    End Function

    Private Function GetIsActive() As Integer
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

    Private Sub SetFormReadOnly(isReadOnly As Boolean)
        txtUsername.ReadOnly = isReadOnly
        txtPassword.ReadOnly = isReadOnly
        cmbLevelAkses.Enabled = Not isReadOnly
        cmbStatus.Enabled = Not isReadOnly
        txtNimRef.ReadOnly = isReadOnly
    End Sub

    Private Sub SetButtonState(adaBaris As Boolean)
        btnEdit.Enabled = adaBaris
        btnHapus.Enabled = adaBaris
    End Sub

End Class