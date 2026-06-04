Imports System.Drawing
Imports System.Text.RegularExpressions
Imports MySqlConnector

Public Class FormMahasiswa

    Public Class Mahasiswa
        Public Property NIM As String
        Public Property NamaMahasiswa As String
        Public Property JenisKelamin As String
        Public Property TempatLahir As String
        Public Property TanggalLahir As DateTime?
        Public Property Alamat As String
        Public Property NoTelp As String
        Public Property Email As String
        Public Property Angkatan As String
    End Class

    Private _modeEdit As Boolean = False
    Private _nimDipilih As String = ""
    Private _isLoading As Boolean = False

    Private ReadOnly CLR_SIMPAN As Color = ColorTranslator.FromHtml("#4A7C7E")
    Private ReadOnly CLR_UBAH As Color = ColorTranslator.FromHtml("#D4883A")
    Private ReadOnly CLR_HAPUS As Color = ColorTranslator.FromHtml("#C0574A")
    Private ReadOnly CLR_RESET As Color = ColorTranslator.FromHtml("#CFDEDE")
    Private ReadOnly CLR_HOVER_D As Color = ColorTranslator.FromHtml("#3D6B6D")

    ' connection helper

    Private Function ExecNonQuery(sql As String, ParamArray params() As MySqlParameter) As Integer
        Using conn As MySqlConnection = ConnectionModule.GetConnection()
            conn.Open()
            Using cmd As New MySqlCommand(sql, conn)
                If params IsNot Nothing Then
                    cmd.Parameters.AddRange(params)
                End If
                Return cmd.ExecuteNonQuery()
            End Using
        End Using
    End Function

    Private Function ExecScalar(sql As String, ParamArray params() As MySqlParameter) As Object
        Using conn As MySqlConnection = ConnectionModule.GetConnection()
            conn.Open()
            Using cmd As New MySqlCommand(sql, conn)
                If params IsNot Nothing Then
                    cmd.Parameters.AddRange(params)
                End If
                Return cmd.ExecuteScalar()
            End Using
        End Using
    End Function

    Private Function GetDataTable(sql As String, ParamArray params() As MySqlParameter) As DataTable
        Dim dt As New DataTable()
        Using conn As MySqlConnection = ConnectionModule.GetConnection()
            conn.Open()
            Using cmd As New MySqlCommand(sql, conn)
                If params IsNot Nothing Then
                    cmd.Parameters.AddRange(params)
                End If
                Using adapter As New MySqlDataAdapter(cmd)
                    adapter.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    Private Function Param(name As String, value As Object) As MySqlParameter
        Return New MySqlParameter(name, If(value Is Nothing, DBNull.Value, value))
    End Function

    ' crud

    Private Function GetAllMahasiswa() As DataTable
        Dim sql As String =
            "SELECT nim, namaMahasiswa, jenisKelamin, tempatLahir, " &
            "       tanggalLahir, angkatan, noTelp, email, alamat " &
            "FROM mahasiswa " &
            "ORDER BY angkatan DESC, namaMahasiswa ASC"

        Return GetDataTable(sql)
    End Function

    Private Function CariMahasiswa(keyword As String, angkatan As String, jk As String) As DataTable
        Dim conditions As New List(Of String)
        Dim params As New List(Of MySqlParameter)

        If Not String.IsNullOrWhiteSpace(keyword) Then
            conditions.Add("(nim LIKE @kw OR namaMahasiswa LIKE @kw)")
            params.Add(Param("@kw", $"%{keyword.Trim()}%"))
        End If

        If Not String.IsNullOrWhiteSpace(angkatan) AndAlso angkatan <> "(Semua Angkatan)" Then
            conditions.Add("angkatan = @angkatan")
            params.Add(Param("@angkatan", angkatan))
        End If

        If Not String.IsNullOrWhiteSpace(jk) AndAlso jk <> "(Semua JK)" Then
            conditions.Add("jenisKelamin = @jk")
            params.Add(Param("@jk", jk))
        End If

        Dim where As String = If(conditions.Count > 0, " WHERE " & String.Join(" AND ", conditions), "")

        Dim sql As String =
            "SELECT nim, namaMahasiswa, jenisKelamin, tempatLahir, " &
            "       tanggalLahir, angkatan, noTelp, email, alamat " &
            "FROM mahasiswa" & where &
            " ORDER BY angkatan DESC, namaMahasiswa ASC"

        Return GetDataTable(sql, params.ToArray())
    End Function

    Private Function GetMahasiswaByNIM(nim As String) As Mahasiswa
        Dim sql As String =
            "SELECT nim, namaMahasiswa, jenisKelamin, tempatLahir, " &
            "       tanggalLahir, alamat, noTelp, email, angkatan " &
            "FROM mahasiswa WHERE nim = @nim LIMIT 1"

        Dim dt = GetDataTable(sql, Param("@nim", nim))

        If dt.Rows.Count = 0 Then Return Nothing

        Dim row = dt.Rows(0)
        Dim m As New Mahasiswa With {
            .NIM = row("nim").ToString(),
            .NamaMahasiswa = row("namaMahasiswa").ToString(),
            .JenisKelamin = row("jenisKelamin").ToString(),
            .TempatLahir = row("tempatLahir").ToString(),
            .TanggalLahir = If(IsDBNull(row("tanggalLahir")), CType(Nothing, DateTime?), CDate(row("tanggalLahir"))),
            .Alamat = row("alamat").ToString(),
            .NoTelp = row("noTelp").ToString(),
            .Email = row("email").ToString(),
            .Angkatan = row("angkatan").ToString()
        }
        Return m
    End Function

    Private Function NIMSudahAda(nim As String) As Boolean
        Dim sql As String = "SELECT COUNT(*) FROM mahasiswa WHERE nim = @nim"
        Dim result = ExecScalar(sql, Param("@nim", nim))
        Return Convert.ToInt32(result) > 0
    End Function

    Private Function EmailSudahAda(email As String, Optional nimSendiri As String = "") As Boolean
        If String.IsNullOrWhiteSpace(email) Then Return False

        Dim sql As String = "SELECT COUNT(*) FROM mahasiswa WHERE email = @email " &
            If(String.IsNullOrWhiteSpace(nimSendiri), "", "AND nim <> @nim")

        Dim params As New List(Of MySqlParameter)
        params.Add(Param("@email", email))
        If Not String.IsNullOrWhiteSpace(nimSendiri) Then
            params.Add(Param("@nim", nimSendiri))
        End If

        Dim result = ExecScalar(sql, params.ToArray())
        Return Convert.ToInt32(result) > 0
    End Function

    Private Function TambahMahasiswa(m As Mahasiswa) As Boolean
        Dim sql As String =
            "INSERT INTO mahasiswa " &
            "(nim, namaMahasiswa, jenisKelamin, tempatLahir, " &
            " tanggalLahir, alamat, noTelp, email, angkatan) " &
            "VALUES (@nim, @nama, @jk, @tempat, @tgl, @alamat, @telp, @email, @angkatan)"

        Dim rows As Integer = ExecNonQuery(sql,
            Param("@nim", m.NIM),
            Param("@nama", m.NamaMahasiswa),
            Param("@jk", m.JenisKelamin),
            Param("@tempat", m.TempatLahir),
            Param("@tgl", If(m.TanggalLahir.HasValue, CObj(m.TanggalLahir.Value), DBNull.Value)),
            Param("@alamat", m.Alamat),
            Param("@telp", m.NoTelp),
            Param("@email", m.Email),
            Param("@angkatan", m.Angkatan))

        Return rows > 0
    End Function

    Private Function UbahMahasiswa(m As Mahasiswa) As Boolean
        Dim sql As String =
            "UPDATE mahasiswa SET " &
            "  namaMahasiswa = @nama, " &
            "  jenisKelamin  = @jk, " &
            "  tempatLahir   = @tempat, " &
            "  tanggalLahir  = @tgl, " &
            "  alamat        = @alamat, " &
            "  noTelp        = @telp, " &
            "  email         = @email, " &
            "  angkatan      = @angkatan " &
            "WHERE nim = @nim"

        Dim rows As Integer = ExecNonQuery(sql,
            Param("@nama", m.NamaMahasiswa),
            Param("@jk", m.JenisKelamin),
            Param("@tempat", m.TempatLahir),
            Param("@tgl", If(m.TanggalLahir.HasValue, CObj(m.TanggalLahir.Value), DBNull.Value)),
            Param("@alamat", m.Alamat),
            Param("@telp", m.NoTelp),
            Param("@email", m.Email),
            Param("@angkatan", m.Angkatan),
            Param("@nim", m.NIM))

        Return rows > 0
    End Function

    Private Function HapusMahasiswa(nim As String) As Boolean
        Dim cekNilai As String = "SELECT COUNT(*) FROM nilai WHERE nim = @nim"
        Dim jumlahNilai = Convert.ToInt32(ExecScalar(cekNilai, Param("@nim", nim)))

        If jumlahNilai > 0 Then
            Throw New Exception("Mahasiswa ini memiliki data nilai yang terkait. " &
                "Hapus data nilai terlebih dahulu sebelum menghapus mahasiswa.")
        End If

        Dim sql As String = "DELETE FROM mahasiswa WHERE nim = @nim"
        Dim rows As Integer = ExecNonQuery(sql, Param("@nim", nim))
        Return rows > 0
    End Function

    Private Sub CatatLog(nimAdmin As String, aktivitas As String, Optional keterangan As String = "")
        Try
            Dim sql As String =
                "INSERT INTO log (nimAdmin, aktifitas, keterangan, tanggalJam) " &
                "VALUES (@nim, @aktifitas, @ket, NOW())"

            ExecNonQuery(sql,
                Param("@nim", nimAdmin),
                Param("@aktifitas", aktivitas),
                Param("@ket", keterangan))
        Catch ex As Exception
            Debug.WriteLine($"[LOG ERROR] {ex.Message}")
        End Try
    End Sub

    Private Function FormatTTL(tempat As String, tgl As Object) As String
        If IsDBNull(tgl) OrElse tgl Is Nothing Then
            Return If(String.IsNullOrWhiteSpace(tempat), "—", tempat)
        End If

        Dim tglDate As DateTime = CDate(tgl)
        Dim tglStr As String = tglDate.ToString("dd MMM yyyy", New System.Globalization.CultureInfo("id-ID"))

        If String.IsNullOrWhiteSpace(tempat) Then
            Return tglStr
        End If

        Return $"{tempat}, {tglStr}"
    End Function

    ' validasi

    Public Class HasilValidasi
        Public Property Valid As Boolean = True
        Public Property Pesan As String = ""
        Public Property FieldTarget As Control = Nothing

        Public Sub New(valid As Boolean, pesan As String, Optional target As Control = Nothing)
            Me.Valid = valid
            Me.Pesan = pesan
            Me.FieldTarget = target
        End Sub
    End Class

    Private Function ValidasiNIM(nim As String, Optional isEdit As Boolean = False) As HasilValidasi
        If String.IsNullOrWhiteSpace(nim) Then
            Return New HasilValidasi(False, "NIM wajib diisi.")
        End If
        If nim.Length < 8 OrElse nim.Length > 10 Then
            Return New HasilValidasi(False, "NIM harus antara 8–10 karakter.")
        End If
        If Not Regex.IsMatch(nim, "^\d+$") Then
            Return New HasilValidasi(False, "NIM hanya boleh berisi angka.")
        End If
        Return New HasilValidasi(True, "")
    End Function

    Private Function ValidasiNama(nama As String) As HasilValidasi
        If String.IsNullOrWhiteSpace(nama) Then
            Return New HasilValidasi(False, "Nama lengkap wajib diisi.")
        End If
        If nama.Length < 3 Then
            Return New HasilValidasi(False, "Nama minimal 3 karakter.")
        End If
        If nama.Length > 100 Then
            Return New HasilValidasi(False, "Nama maksimal 100 karakter.")
        End If
        If Not Regex.IsMatch(nama, "^[A-Za-zÀ-ÿ\s\.\,\-\']+$") Then
            Return New HasilValidasi(False, "Nama hanya boleh mengandung huruf dan spasi.")
        End If
        If nama.Contains("  ") Then
            Return New HasilValidasi(False, "Nama tidak boleh mengandung spasi ganda.")
        End If
        Return New HasilValidasi(True, "")
    End Function

    Private Function ValidasiTempatLahir(tempat As String) As HasilValidasi
        If tempat.Length > 50 Then
            Return New HasilValidasi(False, "Tempat lahir maksimal 50 karakter.")
        End If
        If Not Regex.IsMatch(tempat, "^[A-Za-zÀ-ÿ0-9\s\.\,\-]+$") Then
            Return New HasilValidasi(False, "Tempat lahir mengandung karakter tidak valid.")
        End If
        Return New HasilValidasi(True, "")
    End Function

    Private Function ValidasiTanggalLahir(tgl As DateTime) As HasilValidasi
        Dim hari As DateTime = DateTime.Today
        If tgl > hari Then
            Return New HasilValidasi(False, "Tanggal lahir tidak boleh di masa depan.")
        End If
        Dim umur As Integer = hari.Year - tgl.Year
        If tgl.Date > hari.AddYears(-umur) Then umur -= 1
        If umur < 10 Then
            Return New HasilValidasi(False, "Umur mahasiswa tidak valid (min. 10 tahun).")
        End If
        If umur > 70 Then
            Return New HasilValidasi(False, "Tanggal lahir tidak wajar (umur > 70 tahun).")
        End If
        Return New HasilValidasi(True, "")
    End Function

    Private Function ValidasiTelepon(telp As String) As HasilValidasi
        If telp.Length > 15 Then
            Return New HasilValidasi(False, "No. telepon maksimal 15 digit.")
        End If
        Dim pattern As String = "^(\+62|62|0)[0-9]{8,13}$"
        If Not Regex.IsMatch(telp, pattern) Then
            Return New HasilValidasi(False, "Format telepon tidak valid. Contoh: 08123456789 atau +6281234567")
        End If
        Return New HasilValidasi(True, "")
    End Function

    Private Function ValidasiEmail(email As String) As HasilValidasi
        If email.Length > 100 Then
            Return New HasilValidasi(False, "Email maksimal 100 karakter.")
        End If
        Dim pattern As String = "^[a-zA-Z0-9._%+\-]+@[a-zA-Z0-9.\-]+\.[a-zA-Z]{2,}$"
        If Not Regex.IsMatch(email, pattern) Then
            Return New HasilValidasi(False, "Format email tidak valid. Contoh: nama@domain.com")
        End If
        Return New HasilValidasi(True, "")
    End Function

    Private Function ValidasiAlamat(alamat As String) As HasilValidasi
        If alamat.Length > 200 Then
            Return New HasilValidasi(False, "Alamat maksimal 200 karakter.")
        End If
        Return New HasilValidasi(True, "")
    End Function

    Private Function ValidasiAngkatan(angkatan As String) As HasilValidasi
        If String.IsNullOrWhiteSpace(angkatan) Then
            Return New HasilValidasi(False, "Angkatan wajib dipilih.")
        End If
        Dim tahun As Integer
        If Not Integer.TryParse(angkatan, tahun) Then
            Return New HasilValidasi(False, "Format angkatan tidak valid.")
        End If
        Dim tahunSekarang As Integer = DateTime.Now.Year
        If tahun < 2000 OrElse tahun > tahunSekarang Then
            Return New HasilValidasi(False, $"Angkatan harus antara 2000 dan {tahunSekarang}.")
        End If
        Return New HasilValidasi(True, "")
    End Function

    Private Function ValidasiFormMahasiswa(
            txtNIM As TextBox,
            txtNama As TextBox,
            rbLaki As RadioButton,
            rbPerempuan As RadioButton,
            txtTempat As TextBox,
            dtp As DateTimePicker,
            cmb As ComboBox,
            txtTelp As TextBox,
            txtEmail As TextBox,
            txtAlamat As TextBox,
            Optional isEdit As Boolean = False) As Boolean

        BersihkanSemuaError()
        Dim valid As Boolean = True

        Dim resNIM = ValidasiNIM(txtNIM.Text.Trim(), isEdit)
        If Not resNIM.Valid Then
            epValidasi.SetError(txtNIM, resNIM.Pesan)
            valid = False
        End If

        Dim resNama = ValidasiNama(txtNama.Text.Trim())
        If Not resNama.Valid Then
            epValidasi.SetError(txtNama, resNama.Pesan)
            valid = False
        End If

        If Not rbLaki.Checked AndAlso Not rbPerempuan.Checked Then
            valid = False
        End If

        If Not String.IsNullOrWhiteSpace(txtTempat.Text) Then
            Dim resTempat = ValidasiTempatLahir(txtTempat.Text.Trim())
            If Not resTempat.Valid Then
                epValidasi.SetError(txtTempat, resTempat.Pesan)
                valid = False
            End If
        End If

        Dim resTgl = ValidasiTanggalLahir(dtp.Value)
        If Not resTgl.Valid Then
            epValidasi.SetError(txtTempat, resTgl.Pesan)
            valid = False
        End If

        If cmb.SelectedIndex < 0 Then
            valid = False
        End If

        If Not String.IsNullOrWhiteSpace(txtTelp.Text) Then
            Dim resTelp = ValidasiTelepon(txtTelp.Text.Trim())
            If Not resTelp.Valid Then
                epValidasi.SetError(txtTelp, resTelp.Pesan)
                valid = False
            End If
        End If

        If Not String.IsNullOrWhiteSpace(txtEmail.Text) Then
            Dim resEmail = ValidasiEmail(txtEmail.Text.Trim())
            If Not resEmail.Valid Then
                epValidasi.SetError(txtEmail, resEmail.Pesan)
                valid = False
            End If
        End If

        If Not String.IsNullOrWhiteSpace(txtAlamat.Text) Then
            Dim resAlamat = ValidasiAlamat(txtAlamat.Text.Trim())
            If Not resAlamat.Valid Then
                epValidasi.SetError(txtAlamat, resAlamat.Pesan)
                valid = False
            End If
        End If

        Return valid
    End Function

    Private Function PesanValidasiLengkap(rbLaki As RadioButton, rbPerempuan As RadioButton, cmb As ComboBox) As String
        Dim sb As New System.Text.StringBuilder
        If Not rbLaki.Checked AndAlso Not rbPerempuan.Checked Then
            sb.AppendLine("• Jenis kelamin wajib dipilih.")
        End If
        If cmb.SelectedIndex < 0 Then
            sb.AppendLine("• Angkatan wajib dipilih.")
        End If
        Return sb.ToString().Trim()
    End Function

    Private Sub SanitasiInput()
        txtNIM.Text = txtNIM.Text.Trim()
        txtNama.Text = txtNama.Text.Trim()
        txtTempatLahir.Text = txtTempatLahir.Text.Trim()
        txtNoTelp.Text = Regex.Replace(txtNoTelp.Text.Trim(), "[^\d\+]", "")
        txtEmail.Text = txtEmail.Text.Trim().ToLower()
        txtAlamat.Text = txtAlamat.Text.Trim()
    End Sub

    Private Function ProperCase(s As String) As String
        If String.IsNullOrWhiteSpace(s) Then Return s
        Return System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(s.ToLower())
    End Function

    Private Sub BersihkanSemuaError()
        epValidasi.Clear()
        epValidasi.SetError(txtNIM, "")
        epValidasi.SetError(txtNama, "")
        epValidasi.SetError(txtTempatLahir, "")
        epValidasi.SetError(txtNoTelp, "")
        epValidasi.SetError(txtEmail, "")
        epValidasi.SetError(txtAlamat, "")
    End Sub

    ' form

    Private Sub FormMahasiswa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbFilterAngk.Items.Insert(0, "(Semua Angkatan)")
        cmbFilterJK.Items.Insert(0, "(Semua JK)")

        cmbFilterAngk.SelectedIndex = 0
        cmbFilterJK.SelectedIndex = 0

        dtpTglLahir.MaxDate = DateTime.Today
        dtpTglLahir.Value = DateTime.Today.AddYears(-18)
        MuatData()
        SetModeForm(False)
    End Sub

    Private Sub MuatData()
        MuatDataDenganFilter("", "", "")
    End Sub

    Private Sub MuatDataDenganFilter(keyword As String, angkatan As String, jk As String)
        Try
            _isLoading = True

            Dim dt = CariMahasiswa(keyword, angkatan, jk)

            If Not dt.Columns.Contains("ttl") Then
                dt.Columns.Add("ttl", GetType(String))
            End If
            For Each row As DataRow In dt.Rows
                row("ttl") = FormatTTL(row("tempatLahir").ToString(), row("tanggalLahir"))
            Next

            dgvMahasiswa.DataSource = dt

            SembunyikanKolom("tempatLahir", "tanggalLahir")

            AturHeaderDGV()
            TambahNomorUrut()
            lblJumlahData.Text = $"{dt.Rows.Count} data ditemukan"

        Catch ex As Exception
            TampilkanError("Gagal memuat data mahasiswa", ex)
        Finally
            _isLoading = False
        End Try
    End Sub

    Private Sub SembunyikanKolom(ParamArray namaKolom() As String)
        For Each nama In namaKolom
            If dgvMahasiswa.Columns.Contains(nama) Then
                dgvMahasiswa.Columns(nama).Visible = False
            End If
        Next
    End Sub

    Private Sub AturHeaderDGV()
        Dim mapping As New Dictionary(Of String, String) From {
            {"nim", "NIM"},
            {"namaMahasiswa", "Nama Mahasiswa"},
            {"jenisKelamin", "JK"},
            {"ttl", "Tempat, Tgl Lahir"},
            {"angkatan", "Angkatan"},
            {"noTelp", "No. Telp"},
            {"alamat", "Alamat"},
            {"email", "Email"}
        }
        For Each kv In mapping
            If dgvMahasiswa.Columns.Contains(kv.Key) Then
                dgvMahasiswa.Columns(kv.Key).HeaderText = kv.Value
            End If
        Next

        If dgvMahasiswa.Columns.Contains("jenisKelamin") Then
            dgvMahasiswa.Columns("jenisKelamin").Width = 40
            dgvMahasiswa.Columns("jenisKelamin").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        End If
        If dgvMahasiswa.Columns.Contains("angkatan") Then
            dgvMahasiswa.Columns("angkatan").Width = 75
            dgvMahasiswa.Columns("angkatan").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        End If
        If dgvMahasiswa.Columns.Contains("nim") Then
            dgvMahasiswa.Columns("nim").Width = 110
            dgvMahasiswa.Columns("nim").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        End If
        If dgvMahasiswa.Columns.Contains("noTelp") Then
            dgvMahasiswa.Columns("noTelp").Width = 120
            dgvMahasiswa.Columns("noTelp").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        End If
        If dgvMahasiswa.Columns.Contains("alamat") Then
            dgvMahasiswa.Columns("alamat").Width = 300
            dgvMahasiswa.Columns("alamat").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        End If
        If dgvMahasiswa.Columns.Contains("email") Then
            dgvMahasiswa.Columns("email").Width = 180
            dgvMahasiswa.Columns("email").AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        End If
        If dgvMahasiswa.Columns.Contains("namaMahasiswa") Then
            dgvMahasiswa.Columns("namaMahasiswa").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End If
    End Sub

    Private Sub TambahNomorUrut()
        If dgvMahasiswa.Columns.Contains("colNo") Then
            dgvMahasiswa.Columns.Remove("colNo")
        End If

        Dim colNo As New DataGridViewTextBoxColumn With {
            .Name = "colNo",
            .HeaderText = "No",
            .Width = 40,
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
            .ReadOnly = True,
            .DisplayIndex = 0,
            .DefaultCellStyle = New DataGridViewCellStyle With {
                .Alignment = DataGridViewContentAlignment.MiddleCenter,
                .ForeColor = ColorTranslator.FromHtml("#6A9090"),
                .Font = New Font("Segoe UI", 8, FontStyle.Bold)
            }
        }
        dgvMahasiswa.Columns.Insert(0, colNo)

        For i As Integer = 0 To dgvMahasiswa.Rows.Count - 1
            dgvMahasiswa.Rows(i).Cells("colNo").Value = i + 1
        Next
    End Sub


    Private Sub tmrClock_Tick(sender As Object, e As EventArgs) Handles tmrClock.Tick
        lblClock.Text = DateTime.Now.ToString("HH:mm:ss")
        lblDate.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy", New System.Globalization.CultureInfo("id-ID"))
    End Sub

    Private Sub txtCari_TextChanged(sender As Object, e As EventArgs) Handles txtCari.TextChanged
        JalankanFilter()
    End Sub

    Private Sub cmbFilterAngk_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFilterAngk.SelectedIndexChanged
        If Not _isLoading Then JalankanFilter()
    End Sub

    Private Sub cmbFilterJK_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFilterJK.SelectedIndexChanged
        If Not _isLoading Then JalankanFilter()
    End Sub

    Private Sub JalankanFilter()
        Dim keyword As String = txtCari.Text.Trim()
        Dim angkatan As String = ""
        Dim jk As String = ""

        If cmbFilterAngk.SelectedIndex > 0 Then
            angkatan = cmbFilterAngk.SelectedItem.ToString()
        End If

        Select Case cmbFilterJK.SelectedIndex
            Case 1 : jk = "L"
            Case 2 : jk = "P"
        End Select

        MuatDataDenganFilter(keyword, angkatan, jk)
    End Sub


    Private Sub dgvMahasiswa_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMahasiswa.CellClick
        If _isLoading Then Return
        If e.RowIndex < 0 Then Return

        Dim row = dgvMahasiswa.Rows(e.RowIndex)
        Dim nim As String = row.Cells("nim").Value?.ToString()
        If String.IsNullOrEmpty(nim) Then Return

        IsikanFormDariDB(nim)
    End Sub

    Private Sub IsikanFormDariDB(nim As String)
        Try
            Dim m = GetMahasiswaByNIM(nim)
            If m Is Nothing Then
                MessageBox.Show("Data mahasiswa tidak ditemukan.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            _nimDipilih = nim
            _isLoading = True

            txtNIM.Text = m.NIM
            txtNIM.Enabled = False
            txtNama.Text = m.NamaMahasiswa
            txtTempatLahir.Text = m.TempatLahir
            txtNoTelp.Text = m.NoTelp
            txtEmail.Text = m.Email
            txtAlamat.Text = m.Alamat

            If m.TanggalLahir.HasValue Then
                dtpTglLahir.Value = m.TanggalLahir.Value
            End If

            Dim idxAngk = cmbAngkatan.Items.IndexOf(m.Angkatan)
            cmbAngkatan.SelectedIndex = If(idxAngk >= 0, idxAngk, -1)

            rbLaki.Checked = (m.JenisKelamin = "L")
            rbPerempuan.Checked = (m.JenisKelamin = "P")

            _isLoading = False

            SetModeForm(True)

            pnlFormInput.ScrollControlIntoView(txtNIM)

        Catch ex As Exception
            _isLoading = False
            TampilkanError("Gagal memuat data mahasiswa", ex)
        End Try
    End Sub

    Private Sub SetModeForm(isEdit As Boolean)
        _modeEdit = isEdit

        If isEdit Then
            lblModeBadge.Text = "✏  EDIT DATA / HAPUS DATA"
            lblModeBadge.ForeColor = ColorTranslator.FromHtml("#D4883A")
            btnUbah.Enabled = True
            btnHapus.Enabled = True
        Else
            lblModeBadge.Text = "●  TAMBAH BARU"
            lblModeBadge.ForeColor = ColorTranslator.FromHtml("#4A7C7E")
            btnUbah.Enabled = False
            btnHapus.Enabled = False
            txtNIM.Enabled = True
        End If

        BersihkanSemuaError()
    End Sub

    Private Function BacaFormKeMahasiswa() As Mahasiswa
        Dim jk As String = If(rbLaki.Checked, "L", "P")

        Return New Mahasiswa With {
            .NIM = txtNIM.Text.Trim().ToUpper(),
            .NamaMahasiswa = ProperCase(txtNama.Text.Trim()),
            .JenisKelamin = jk,
            .TempatLahir = ProperCase(txtTempatLahir.Text.Trim()),
            .TanggalLahir = dtpTglLahir.Value.Date,
            .Alamat = txtAlamat.Text.Trim(),
            .NoTelp = txtNoTelp.Text.Trim(),
            .Email = txtEmail.Text.Trim().ToLower(),
            .Angkatan = If(cmbAngkatan.SelectedIndex >= 0, cmbAngkatan.SelectedItem.ToString(), "")
        }
    End Function

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        SanitasiInput()

        Dim formValid As Boolean = ValidasiFormMahasiswa(
            txtNIM, txtNama, rbLaki, rbPerempuan,
            txtTempatLahir, dtpTglLahir, cmbAngkatan,
            txtNoTelp, txtEmail, txtAlamat, isEdit:=False)

        Dim pesanTambahan As String = PesanValidasiLengkap(rbLaki, rbPerempuan, cmbAngkatan)

        If Not formValid OrElse pesanTambahan.Length > 0 Then
            Dim pesan As String = "Mohon perbaiki kesalahan berikut:" & Environment.NewLine & Environment.NewLine
            If pesanTambahan.Length > 0 Then pesan &= pesanTambahan
            MessageBox.Show(pesan, "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If NIMSudahAda(txtNIM.Text.Trim()) Then
            epValidasi.SetError(txtNIM, "NIM ini sudah terdaftar.")
            MessageBox.Show("NIM sudah terdaftar di sistem.", "Duplikat NIM", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtNIM.Focus()
            Return
        End If

        If Not String.IsNullOrWhiteSpace(txtEmail.Text) AndAlso EmailSudahAda(txtEmail.Text.Trim()) Then
            epValidasi.SetError(txtEmail, "Email ini sudah digunakan mahasiswa lain.")
            MessageBox.Show("Email sudah digunakan mahasiswa lain.", "Duplikat Email", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtEmail.Focus()
            Return
        End If

        Try
            Dim m = BacaFormKeMahasiswa()
            Dim berhasil = TambahMahasiswa(m)

            If berhasil Then
                CatatLog("ADM0000001", "TAMBAH MAHASISWA", $"NIM: {m.NIM} | Nama: {m.NamaMahasiswa}")

                MessageBox.Show($"Data mahasiswa {m.NamaMahasiswa} berhasil ditambahkan.", "Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ResetForm()
                JalankanFilter()
            Else
                MessageBox.Show("Gagal menyimpan data. Silakan coba lagi.", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            TampilkanError("Gagal menambahkan mahasiswa", ex)
        End Try
    End Sub

    Private Sub btnUbah_Click(sender As Object, e As EventArgs) Handles btnUbah.Click
        If String.IsNullOrEmpty(_nimDipilih) Then Return

        SanitasiInput()

        Dim formValid As Boolean = ValidasiFormMahasiswa(
            txtNIM, txtNama, rbLaki, rbPerempuan,
            txtTempatLahir, dtpTglLahir, cmbAngkatan,
            txtNoTelp, txtEmail, txtAlamat, isEdit:=True)

        Dim pesanTambahan As String = PesanValidasiLengkap(rbLaki, rbPerempuan, cmbAngkatan)

        If Not formValid OrElse pesanTambahan.Length > 0 Then
            Dim pesan As String = "Mohon perbaiki kesalahan berikut:" & Environment.NewLine & Environment.NewLine
            If pesanTambahan.Length > 0 Then pesan &= pesanTambahan
            MessageBox.Show(pesan, "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If Not String.IsNullOrWhiteSpace(txtEmail.Text) AndAlso EmailSudahAda(txtEmail.Text.Trim(), _nimDipilih) Then
            epValidasi.SetError(txtEmail, "Email ini sudah digunakan mahasiswa lain.")
            MessageBox.Show("Email sudah digunakan mahasiswa lain.", "Duplikat Email", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtEmail.Focus()
            Return
        End If

        Dim konfirmasi = MessageBox.Show($"Yakin ingin mengubah data mahasiswa {txtNama.Text.Trim()}?", "Konfirmasi Ubah", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If konfirmasi = DialogResult.No Then Return

        Try
            Dim m = BacaFormKeMahasiswa()
            m.NIM = _nimDipilih

            Dim berhasil = UbahMahasiswa(m)

            If berhasil Then
                CatatLog("ADM0000001", "UBAH MAHASISWA", $"NIM: {m.NIM} | Nama: {m.NamaMahasiswa}")

                MessageBox.Show($"Data mahasiswa {m.NamaMahasiswa} berhasil diperbarui.", "Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ResetForm()
                JalankanFilter()
            Else
                MessageBox.Show("Gagal memperbarui data. Silakan coba lagi.", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            TampilkanError("Gagal mengubah mahasiswa", ex)
        End Try
    End Sub

    Private Sub btnHapus_Click(sender As Object, e As EventArgs) Handles btnHapus.Click
        If String.IsNullOrEmpty(_nimDipilih) Then Return

        Dim nama As String = txtNama.Text.Trim()

        Dim konfirmasi1 = MessageBox.Show(
            $"Anda akan menghapus data mahasiswa:{Environment.NewLine}" &
            $"Nama : {nama}{Environment.NewLine}" &
            $"NIM  : {_nimDipilih}{Environment.NewLine}{Environment.NewLine}" &
            "Aksi ini TIDAK dapat dibatalkan. Lanjutkan?",
            "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If konfirmasi1 = DialogResult.No Then Return

        Try
            Dim berhasil = HapusMahasiswa(_nimDipilih)

            If berhasil Then
                CatatLog("ADM0000001", "HAPUS MAHASISWA", $"NIM: {_nimDipilih} | Nama: {nama}")

                MessageBox.Show($"Data mahasiswa {nama} berhasil dihapus.", "Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ResetForm()
                JalankanFilter()
            Else
                MessageBox.Show("Gagal menghapus data. Silakan coba lagi.", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Tidak Dapat Dihapus", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        ResetForm()
    End Sub

    Private Sub ResetForm()
        _nimDipilih = ""
        _isLoading = True

        txtNIM.Text = ""
        txtNama.Text = ""
        txtTempatLahir.Text = ""
        txtNoTelp.Text = ""
        txtEmail.Text = ""
        txtAlamat.Text = ""

        dtpTglLahir.Value = DateTime.Today.AddYears(-18)
        cmbAngkatan.SelectedIndex = -1

        rbLaki.Checked = False
        rbPerempuan.Checked = False

        BersihkanSemuaError()

        _isLoading = False

        SetModeForm(False)

        txtNIM.Focus()
    End Sub


    Private Sub dgvMahasiswa_RowPrePaint(sender As Object, e As DataGridViewRowPrePaintEventArgs) Handles dgvMahasiswa.RowPrePaint
        If e.RowIndex < 0 Then Return
        Dim row = dgvMahasiswa.Rows(e.RowIndex)

        If e.RowIndex Mod 2 = 0 Then
            row.DefaultCellStyle.BackColor = Color.White
        Else
            row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F4FAFA")
        End If
    End Sub

    Private Sub dgvMahasiswa_SelectionChanged(sender As Object, e As EventArgs) Handles dgvMahasiswa.SelectionChanged
        For Each row As DataGridViewRow In dgvMahasiswa.Rows
            If row.Selected Then
                row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#D9EFEF")
                row.DefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#1C3333")
            End If
        Next
    End Sub


    Private Sub btnSimpan_MouseEnter(s As Object, e As EventArgs) Handles btnSimpan.MouseEnter
        btnSimpan.BackColor = CLR_HOVER_D
    End Sub
    Private Sub btnSimpan_MouseLeave(s As Object, e As EventArgs) Handles btnSimpan.MouseLeave
        btnSimpan.BackColor = CLR_SIMPAN
    End Sub

    Private Sub btnUbah_MouseEnter(s As Object, e As EventArgs) Handles btnUbah.MouseEnter
        If btnUbah.Enabled Then btnUbah.BackColor = ColorTranslator.FromHtml("#B87430")
    End Sub
    Private Sub btnUbah_MouseLeave(s As Object, e As EventArgs) Handles btnUbah.MouseLeave
        btnUbah.BackColor = CLR_UBAH
    End Sub

    Private Sub btnHapus_MouseEnter(s As Object, e As EventArgs) Handles btnHapus.MouseEnter
        If btnHapus.Enabled Then btnHapus.BackColor = ColorTranslator.FromHtml("#A3453A")
    End Sub
    Private Sub btnHapus_MouseLeave(s As Object, e As EventArgs) Handles btnHapus.MouseLeave
        btnHapus.BackColor = CLR_HAPUS
    End Sub

    Private Sub btnReset_MouseEnter(s As Object, e As EventArgs) Handles btnReset.MouseEnter
        btnReset.BackColor = ColorTranslator.FromHtml("#B5CFCF")
    End Sub
    Private Sub btnReset_MouseLeave(s As Object, e As EventArgs) Handles btnReset.MouseLeave
        btnReset.BackColor = CLR_RESET
    End Sub


    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        Select Case keyData
            Case Keys.Escape
                ResetForm()
                Return True
            Case Keys.F5
                JalankanFilter()
                Return True
            Case Keys.Control Or Keys.S
                btnSimpan.PerformClick()
                Return True
        End Select
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Private Sub TampilkanError(konteks As String, ex As Exception)
        MessageBox.Show($"{konteks}:{Environment.NewLine}{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Debug.WriteLine($"[ERROR] {konteks}: {ex}")
    End Sub

    Private Sub FormMahasiswa_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        tmrClock.Stop()
        epValidasi.Dispose()
    End Sub

End Class