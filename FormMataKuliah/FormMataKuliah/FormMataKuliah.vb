Imports System.Drawing
Imports System.Text.RegularExpressions
Imports MySqlConnector

Public Class FormMataKuliah

    Public Class MataKuliah
        Public Property kodeMK As String
        Public Property namaMK As String
        Public Property sks As Integer
    End Class

    Private _modeEdit As Boolean = False
    Private _kodeMKDipilih As String = ""
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

    Private Function GetAllMataKuliah() As DataTable
        Dim sql As String =
            "SELECT kodeMK, namaMK, sks " &
            "FROM matakuliah " &
            "ORDER BY kodeMK ASC"

        Return GetDataTable(sql)
    End Function

    Private Function CariMataKuliah(
    keyword As String,
    sks As String) As DataTable

        Dim sql As String =
        "SELECT kodeMK, namaMK, sks " &
        "FROM matakuliah " &
        "WHERE (kodeMK LIKE @kw OR namaMK LIKE @kw)"

        If Not String.IsNullOrWhiteSpace(sks) Then
            sql &= " AND sks = @sks"
        End If

        sql &= " ORDER BY kodeMK ASC"

        If String.IsNullOrWhiteSpace(sks) Then

            Return GetDataTable(
            sql,
            Param("@kw", "%" & keyword & "%"))

        Else

            Return GetDataTable(
            sql,
            Param("@kw", "%" & keyword & "%"),
            Param("@sks", sks))

        End If

    End Function

    Private Function GetMataKuliahByKode(kode As String) As MataKuliah

        Dim sql As String =
        "SELECT kodeMK, namaMK, sks " &
        "FROM matakuliah " &
        "WHERE kodeMK = @kode LIMIT 1"

        Dim dt = GetDataTable(sql,
        Param("@kode", kode))

        If dt.Rows.Count = 0 Then Return Nothing

        Dim row = dt.Rows(0)

        Return New MataKuliah With {
        .kodeMK = row("kodeMK").ToString(),
        .namaMK = row("namaMK").ToString(),
        .sks = Convert.ToInt32(row("sks"))
    }

    End Function

    Private Function KodeMKSudahAda(kode As String) As Boolean

        Dim sql As String =
        "SELECT COUNT(*) FROM matakuliah " &
        "WHERE kodeMK=@kode"

        Return Convert.ToInt32(
        ExecScalar(sql,
        Param("@kode", kode))) > 0

    End Function

    Private Function TambahMataKuliah(mk As MataKuliah) As Boolean

        Dim sql As String =
        "INSERT INTO matakuliah " &
        "(kodeMK,namaMK,sks) " &
        "VALUES (@kode,@nama,@sks)"

        Dim rows As Integer =
        ExecNonQuery(sql,
            Param("@kode", mk.kodeMK),
            Param("@nama", mk.namaMK),
            Param("@sks", mk.sks))

        Return rows > 0

    End Function

    Private Function UbahMataKuliah(mk As MataKuliah) As Boolean

        Dim sql As String =
        "UPDATE matakuliah SET " &
        "namaMK=@nama, " &
        "sks=@sks " &
        "WHERE kodeMK=@kode"

        Dim rows As Integer =
        ExecNonQuery(sql,
            Param("@nama", mk.namaMK),
            Param("@sks", mk.sks),
            Param("@kode", mk.kodeMK))

        Return rows > 0

    End Function

    Private Function HapusMataKuliah(kode As String) As Boolean

        Dim cekNilai As String =
        "SELECT COUNT(*) FROM nilai " &
        "WHERE kodeMK=@kode"

        Dim jumlah =
        Convert.ToInt32(
            ExecScalar(cekNilai,
            Param("@kode", kode)))

        If jumlah > 0 Then

            Throw New Exception(
            "Mata kuliah ini memiliki data nilai yang terkait." &
            vbCrLf &
            "Hapus data nilai terlebih dahulu.")

        End If

        Dim sql As String =
        "DELETE FROM matakuliah " &
        "WHERE kodeMK=@kode"

        Dim rows As Integer =
        ExecNonQuery(sql,
            Param("@kode", kode))

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

    Private Function ValidasiNamaMK(
        namaMK As String) As HasilValidasi

        If String.IsNullOrWhiteSpace(namaMK) Then
            Return New HasilValidasi(
            False,
            "Nama Mata Kuliah wajib diisi.")
        End If

        If namaMK.Length < 3 Then
            Return New HasilValidasi(
            False,
            "Nama Mata Kuliah minimal 3 karakter.")
        End If

        If namaMK.Length > 100 Then
            Return New HasilValidasi(
            False,
            "Nama Mata Kuliah maksimal 100 karakter.")
        End If

        Return New HasilValidasi(True, "")

    End Function

    Private Function ValidasiKodeMK(
        kodeMK As String,
        Optional isEdit As Boolean = False) As HasilValidasi

        If String.IsNullOrWhiteSpace(kodeMK) Then
            Return New HasilValidasi(
            False,
            "Kode Mata Kuliah wajib diisi.")
        End If

        If kodeMK.Length > 10 Then
            Return New HasilValidasi(
            False,
            "Kode Mata Kuliah maksimal 10 karakter.")
        End If

        Return New HasilValidasi(True, "")

    End Function
    Private Function ValidasiFormMataKuliah(
            txtKodeMK As TextBox,
            txtNamaMK As TextBox,
            cboSKS As ComboBox,
            Optional isEdit As Boolean = False) As Boolean

        BersihkanSemuaError()
        Dim valid As Boolean = True

        Dim resKodeMK = ValidasiKodeMK(txtKodeMK.Text.Trim(), isEdit)
        If Not resKodeMK.Valid Then
            epValidasi.SetError(txtKodeMK, resKodeMK.Pesan)
            valid = False
        End If

        Dim resNamaMK = ValidasiNamaMK(txtNamaMK.Text.Trim())

        If Not resNamaMK.Valid Then
            epValidasi.SetError(txtNamaMK, resNamaMK.Pesan)
            valid = False
        End If

        If cboSKS.SelectedIndex < 0 Then
            epValidasi.SetError(cboSKS, "SKS wajib dipilih.")
            valid = False
        End If

        Return valid
    End Function

    Private Function PesanValidasiLengkap(cboSKS As ComboBox) As String

        Dim sb As New System.Text.StringBuilder

        If cboSKS.SelectedIndex < 0 Then
            sb.AppendLine("• SKS wajib dipilih.")
        End If

        Return sb.ToString().Trim()

    End Function

    Private Sub SanitasiInput()
        txtKodeMK.Text = txtKodeMK.Text.Trim()
        txtNamaMK.Text = txtNamaMK.Text.Trim()

    End Sub

    Private Function ProperCase(s As String) As String
        If String.IsNullOrWhiteSpace(s) Then Return s
        Return System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(s.ToLower())
    End Function

    Private Sub BersihkanSemuaError()
        epValidasi.Clear()
        epValidasi.SetError(txtKodeMK, "")
        epValidasi.SetError(txtNamaMK, "")
    End Sub

    ' form

    Private Sub FormMataKuliah_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        MuatData()

        cmbFilterSKS.SelectedIndex = 0

        SetModeForm(False)

    End Sub

    Private Sub MuatData()

        Try

            Dim dt = GetAllMataKuliah()

            dgvMataKuliah.DataSource = dt

            AturHeaderDGV()
            TambahNomorUrut()

            lblJumlahData.Text =
            dt.Rows.Count & " data ditemukan"

        Catch ex As Exception

            TampilkanError(
            "Gagal memuat data mata kuliah",
            ex)

        End Try

    End Sub

    Private Sub MuatDataDenganFilter(
    keyword As String,
    sks As String)

        Try

            _isLoading = True

            Dim dt As DataTable =
            CariMataKuliah(keyword, sks)

            dgvMataKuliah.DataSource = dt

            AturHeaderDGV()

            TambahNomorUrut()

            lblJumlahData.Text =
            dt.Rows.Count & " data ditemukan"

        Catch ex As Exception

            TampilkanError(
            "Gagal memuat data mata kuliah",
            ex)

        Finally

            _isLoading = False

        End Try

    End Sub

    Private Sub SembunyikanKolom(ParamArray namaKolom() As String)
        For Each nama In namaKolom
            If dgvMataKuliah.Columns.Contains(nama) Then
                dgvMataKuliah.Columns(nama).Visible = False
            End If
        Next
    End Sub

    Private Sub AturHeaderDGV()

        Dim mapping As New Dictionary(Of String, String) From {
        {"kodeMK", "Kode MK"},
        {"namaMK", "Nama Mata Kuliah"},
        {"sks", "SKS"}
    }

        For Each kv In mapping

            If dgvMataKuliah.Columns.Contains(kv.Key) Then
                dgvMataKuliah.Columns(kv.Key).HeaderText = kv.Value
            End If

        Next

        ' Kode MK
        If dgvMataKuliah.Columns.Contains("kodeMK") Then

            dgvMataKuliah.Columns("kodeMK").Width = 200
            dgvMataKuliah.Columns("kodeMK").AutoSizeMode =
            DataGridViewAutoSizeColumnMode.None

        End If

        ' SKS
        If dgvMataKuliah.Columns.Contains("sks") Then

            dgvMataKuliah.Columns("sks").Width = 200
            dgvMataKuliah.Columns("sks").AutoSizeMode =
            DataGridViewAutoSizeColumnMode.None

        End If

        ' Nama Mata Kuliah
        If dgvMataKuliah.Columns.Contains("namaMK") Then

            dgvMataKuliah.Columns("namaMK").AutoSizeMode =
            DataGridViewAutoSizeColumnMode.Fill

        End If

        ' Kolom No
        If dgvMataKuliah.Columns.Contains("colNo") Then

            dgvMataKuliah.Columns("colNo").Width = 150
            dgvMataKuliah.Columns("colNo").AutoSizeMode =
            DataGridViewAutoSizeColumnMode.None

        End If

    End Sub

    Private Sub TambahNomorUrut()

        If Not dgvMataKuliah.Columns.Contains("colNo") Then

            Dim colNo As New DataGridViewTextBoxColumn With {
            .Name = "colNo",
            .HeaderText = "No",
            .Width = 150,
            .ReadOnly = True
        }

            dgvMataKuliah.Columns.Insert(0, colNo)

        End If

        For i As Integer = 0 To dgvMataKuliah.Rows.Count - 1
            dgvMataKuliah.Rows(i).Cells("colNo").Value = i + 1
        Next

    End Sub


    Private Sub tmrClock_Tick(sender As Object, e As EventArgs) Handles tmrClock.Tick
        lblClock.Text = DateTime.Now.ToString("HH:mm:ss")
        lblDate.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy", New System.Globalization.CultureInfo("id-ID"))
    End Sub
    Private Sub txtCari_TextChanged(
    sender As Object,
    e As EventArgs) Handles txtCari.TextChanged

        If Not _isLoading Then
            JalankanFilter()
        End If

    End Sub


    Private Sub cmbFilterSKS_SelectedIndexChanged(
    sender As Object,
    e As EventArgs) Handles cmbFilterSKS.SelectedIndexChanged

        If Not _isLoading Then
            JalankanFilter()
        End If

    End Sub
    Private Sub JalankanFilter()

        Dim keyword As String =
        txtCari.Text.Trim()

        Dim sks As String = ""

        If cmbFilterSKS.SelectedIndex <= 0 Then

            sks = ""

        Else

            sks = cmbFilterSKS.SelectedItem.ToString()

        End If

        MuatDataDenganFilter(
        keyword,
        sks)

    End Sub


    Private Sub dgvMataKuliah_CellClick(
    sender As Object,
    e As DataGridViewCellEventArgs) Handles dgvMataKuliah.CellClick

        If _isLoading Then Return

        If e.RowIndex < 0 Then Return

        Dim row = dgvMataKuliah.Rows(e.RowIndex)

        Dim kodeMK As String =
        row.Cells("kodeMK").Value?.ToString()

        If String.IsNullOrEmpty(kodeMK) Then Return

        IsikanFormDariDB(kodeMK)

    End Sub

    Private Sub IsikanFormDariDB(kodeMK As String)

        Try

            Dim mk As MataKuliah =
            GetMataKuliahByKode(kodeMK)

            If mk Is Nothing Then

                MessageBox.Show(
                "Data mata kuliah tidak ditemukan.",
                "Info",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information)

                Return

            End If

            _kodeMKDipilih = kodeMK

            _isLoading = True

            txtKodeMK.Text = mk.kodeMK
            txtKodeMK.Enabled = False

            txtNamaMK.Text = mk.namaMK

            cboSKS.Text = mk.sks.ToString()

            _isLoading = False

            SetModeForm(True)

            pnlFormInput.ScrollControlIntoView(txtKodeMK)

        Catch ex As Exception

            _isLoading = False

            TampilkanError(
            "Gagal memuat data mata kuliah",
            ex)

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
            txtKodeMK.Enabled = True
        End If

        BersihkanSemuaError()
    End Sub

    Private Function BacaFormKeMataKuliah() As MataKuliah

        Return New MataKuliah With {
        .kodeMK = txtKodeMK.Text.Trim().ToUpper(),
        .namaMK = txtNamaMK.Text.Trim(),
        .sks = Convert.ToInt32(cboSKS.Text)
    }

    End Function

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click

        SanitasiInput()

        Dim formValid As Boolean =
        ValidasiFormMataKuliah(
            txtKodeMK,
            txtNamaMK,
            cboSKS,
            isEdit:=False)

        Dim pesanTambahan As String =
        PesanValidasiLengkap(cboSKS)

        If Not formValid OrElse pesanTambahan.Length > 0 Then

            Dim pesan As String =
            "Mohon perbaiki kesalahan berikut:" &
            Environment.NewLine &
            Environment.NewLine

            If pesanTambahan.Length > 0 Then
                pesan &= pesanTambahan
            End If

            MessageBox.Show(
            pesan,
            "Validasi Gagal",
            MessageBoxButtons.OK,
            MessageBoxIcon.Warning)

            Return

        End If

        If KodeMKSudahAda(txtKodeMK.Text.Trim()) Then

            epValidasi.SetError(
            txtKodeMK,
            "Kode Mata Kuliah sudah terdaftar.")

            MessageBox.Show(
            "Kode Mata Kuliah sudah terdaftar.",
            "Duplikat Data",
            MessageBoxButtons.OK,
            MessageBoxIcon.Warning)

            txtKodeMK.Focus()

            Return

        End If

        Try

            Dim mk As MataKuliah =
            BacaFormKeMataKuliah()

            Dim berhasil As Boolean =
            TambahMataKuliah(mk)

            If berhasil Then

                CatatLog(
                "ADM0000001",
                "TAMBAH MATA KULIAH",
                $"Kode MK: {mk.kodeMK} | Nama: {mk.namaMK}")

                MessageBox.Show(
                $"Data Mata Kuliah {mk.namaMK} berhasil ditambahkan.",
                "Berhasil",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information)

                ResetForm()

                JalankanFilter()

            Else

                MessageBox.Show(
                "Gagal menyimpan data.",
                "Gagal",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)

            End If

        Catch ex As Exception

            TampilkanError(
            "Gagal menambahkan mata kuliah",
            ex)

        End Try

    End Sub

    Private Sub btnUbah_Click(sender As Object, e As EventArgs) Handles btnUbah.Click

        If String.IsNullOrEmpty(_kodeMKDipilih) Then Return

        SanitasiInput()

        Dim formValid As Boolean =
        ValidasiFormMataKuliah(
            txtKodeMK,
            txtNamaMK,
            cboSKS,
            isEdit:=True)

        Dim pesanTambahan As String =
        PesanValidasiLengkap(cboSKS)

        If Not formValid OrElse pesanTambahan.Length > 0 Then

            Dim pesan As String =
            "Mohon perbaiki kesalahan berikut:" &
            Environment.NewLine &
            Environment.NewLine

            If pesanTambahan.Length > 0 Then
                pesan &= pesanTambahan
            End If

            MessageBox.Show(
            pesan,
            "Validasi Gagal",
            MessageBoxButtons.OK,
            MessageBoxIcon.Warning)

            Return

        End If

        Dim konfirmasi As DialogResult =
        MessageBox.Show(
            $"Yakin ingin mengubah data mata kuliah {txtNamaMK.Text.Trim()}?",
            "Konfirmasi Ubah",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question)

        If konfirmasi = DialogResult.No Then Return

        Try

            Dim mk As MataKuliah =
            BacaFormKeMataKuliah()

            mk.kodeMK = _kodeMKDipilih

            Dim berhasil As Boolean =
            UbahMataKuliah(mk)

            If berhasil Then

                CatatLog(
                "ADM0000001",
                "UBAH MATA KULIAH",
                $"Kode MK: {mk.kodeMK} | Nama: {mk.namaMK}")

                MessageBox.Show(
                $"Data Mata Kuliah {mk.namaMK} berhasil diperbarui.",
                "Berhasil",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information)

                ResetForm()

                JalankanFilter()

            Else

                MessageBox.Show(
                "Gagal memperbarui data.",
                "Gagal",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)

            End If

        Catch ex As Exception

            TampilkanError(
            "Gagal mengubah mata kuliah",
            ex)

        End Try

    End Sub

    Private Sub btnHapus_Click(sender As Object, e As EventArgs) Handles btnHapus.Click

        If String.IsNullOrEmpty(_kodeMKDipilih) Then Return

        Dim namaMK As String =
        txtNamaMK.Text.Trim()

        Dim konfirmasi As DialogResult =
        MessageBox.Show(
            $"Anda akan menghapus data mata kuliah:{Environment.NewLine}" &
            $"Nama MK  : {namaMK}{Environment.NewLine}" &
            $"Kode MK  : {_kodeMKDipilih}{Environment.NewLine}{Environment.NewLine}" &
            "Aksi ini TIDAK dapat dibatalkan. Lanjutkan?",
            "Konfirmasi Hapus",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning)

        If konfirmasi = DialogResult.No Then Return

        Try

            Dim berhasil As Boolean =
            HapusMataKuliah(_kodeMKDipilih)

            If berhasil Then

                CatatLog(
                "ADM0000001",
                "HAPUS MATA KULIAH",
                $"Kode MK: {_kodeMKDipilih} | Nama: {namaMK}")

                MessageBox.Show(
                $"Data Mata Kuliah {namaMK} berhasil dihapus.",
                "Berhasil",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information)

                ResetForm()

                JalankanFilter()

            Else

                MessageBox.Show(
                "Gagal menghapus data.",
                "Gagal",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)

            End If

        Catch ex As Exception

            MessageBox.Show(
            ex.Message,
            "Tidak Dapat Dihapus",
            MessageBoxButtons.OK,
            MessageBoxIcon.Warning)

        End Try

    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        ResetForm()
    End Sub

    Private Sub ResetForm()

        _kodeMKDipilih = ""

        _isLoading = True

        txtKodeMK.Text = ""
        txtNamaMK.Text = ""

        cboSKS.SelectedIndex = -1

        BersihkanSemuaError()

        _isLoading = False

        SetModeForm(False)

        txtKodeMK.Focus()

    End Sub


    Private Sub dgvMataKuliah_RowPrePaint(
    sender As Object,
    e As DataGridViewRowPrePaintEventArgs) Handles dgvMataKuliah.RowPrePaint

        If e.RowIndex < 0 Then Return

        Dim row As DataGridViewRow =
        dgvMataKuliah.Rows(e.RowIndex)

        If e.RowIndex Mod 2 = 0 Then

            row.DefaultCellStyle.BackColor = Color.White

        Else

            row.DefaultCellStyle.BackColor =
            ColorTranslator.FromHtml("#F4FAFA")

        End If

    End Sub

    Private Sub dgvMataKuliah_SelectionChanged(sender As Object, e As EventArgs) Handles dgvMataKuliah.SelectionChanged

        For Each row As DataGridViewRow In dgvMataKuliah.Rows

            If row.Selected Then

                row.DefaultCellStyle.BackColor =
                ColorTranslator.FromHtml("#D9EFEF")

                row.DefaultCellStyle.ForeColor =
                ColorTranslator.FromHtml("#1C3333")

            Else

                row.DefaultCellStyle.BackColor =
                dgvMataKuliah.DefaultCellStyle.BackColor

                row.DefaultCellStyle.ForeColor =
                dgvMataKuliah.DefaultCellStyle.ForeColor

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

    Private Sub FormMataKuliah_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        tmrClock.Stop()
        epValidasi.Dispose()
    End Sub

    Private Sub dgvMataKuliah_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMataKuliah.CellContentClick

    End Sub
End Class