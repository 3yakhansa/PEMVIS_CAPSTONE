Imports System.Drawing
Imports System.Text.RegularExpressions
Imports System.Reflection
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

    ' ── Connection helpers ───────────────────────────────────────
    Private Function ExecNonQuery(sql As String, ParamArray params() As MySqlParameter) As Integer
        Using conn As MySqlConnection = ConnectionModule.GetConnection()
            conn.Open()
            Using cmd As New MySqlCommand(sql, conn)
                If params IsNot Nothing Then cmd.Parameters.AddRange(params)
                Return cmd.ExecuteNonQuery()
            End Using
        End Using
    End Function

    Private Function ExecScalar(sql As String, ParamArray params() As MySqlParameter) As Object
        Using conn As MySqlConnection = ConnectionModule.GetConnection()
            conn.Open()
            Using cmd As New MySqlCommand(sql, conn)
                If params IsNot Nothing Then cmd.Parameters.AddRange(params)
                Return cmd.ExecuteScalar()
            End Using
        End Using
    End Function

    Private Function GetDataTable(sql As String, ParamArray params() As MySqlParameter) As DataTable
        Dim dt As New DataTable()
        Using conn As MySqlConnection = ConnectionModule.GetConnection()
            conn.Open()
            Using cmd As New MySqlCommand(sql, conn)
                If params IsNot Nothing Then cmd.Parameters.AddRange(params)
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

    ' ── CRUD ────────────────────────────────────────────────────
    Private Function GetAllMataKuliah() As DataTable
        Return GetDataTable("SELECT kodeMK, namaMK, sks FROM matakuliah ORDER BY kodeMK ASC")
    End Function

    Private Function CariMataKuliah(keyword As String, sks As String) As DataTable
        Dim sql As String =
            "SELECT kodeMK, namaMK, sks FROM matakuliah " &
            "WHERE (kodeMK LIKE @kw OR namaMK LIKE @kw)"
        If Not String.IsNullOrWhiteSpace(sks) Then sql &= " AND sks = @sks"
        sql &= " ORDER BY kodeMK ASC"

        If String.IsNullOrWhiteSpace(sks) Then
            Return GetDataTable(sql, Param("@kw", "%" & keyword & "%"))
        Else
            Return GetDataTable(sql, Param("@kw", "%" & keyword & "%"), Param("@sks", sks))
        End If
    End Function

    Private Function GetMataKuliahByKode(kode As String) As MataKuliah
        Dim dt = GetDataTable(
            "SELECT kodeMK, namaMK, sks FROM matakuliah WHERE kodeMK = @kode LIMIT 1",
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
        Return Convert.ToInt32(ExecScalar(
            "SELECT COUNT(*) FROM matakuliah WHERE kodeMK=@kode",
            Param("@kode", kode))) > 0
    End Function

    Private Function TambahMataKuliah(mk As MataKuliah) As Boolean
        Return ExecNonQuery(
            "INSERT INTO matakuliah (kodeMK, namaMK, sks) VALUES (@kode, @nama, @sks)",
            Param("@kode", mk.kodeMK),
            Param("@nama", mk.namaMK),
            Param("@sks", mk.sks)) > 0
    End Function

    Private Function UbahMataKuliah(mk As MataKuliah) As Boolean
        Return ExecNonQuery(
            "UPDATE matakuliah SET namaMK=@nama, sks=@sks WHERE kodeMK=@kode",
            Param("@nama", mk.namaMK),
            Param("@sks", mk.sks),
            Param("@kode", mk.kodeMK)) > 0
    End Function

    Private Function HapusMataKuliah(kode As String) As Boolean
        Dim jumlah = Convert.ToInt32(ExecScalar(
            "SELECT COUNT(*) FROM nilai WHERE kodeMK=@kode", Param("@kode", kode)))
        If jumlah > 0 Then
            Throw New Exception(
                "Mata kuliah ini memiliki data nilai yang terkait." & vbCrLf &
                "Hapus data nilai terlebih dahulu.")
        End If
        Return ExecNonQuery(
            "DELETE FROM matakuliah WHERE kodeMK=@kode", Param("@kode", kode)) > 0
    End Function

    ' ── Log ─────────────────────────────────────────────────────
    Private Sub CatatLog(aktivitas As String, Optional keterangan As String = "")
        Try
            Dim nimAdmin As String = GetSessionNimAdmin()
            If String.IsNullOrEmpty(nimAdmin) Then Return
            ExecNonQuery(
                "INSERT INTO log (tanggalJam, aktifitas, nimAdmin, keterangan) " &
                "VALUES (NOW(), @aktifitas, @nim, @ket)",
                Param("@aktifitas", aktivitas),
                Param("@nim", nimAdmin),
                Param("@ket", keterangan))
        Catch ex As Exception
            Debug.WriteLine($"[LOG ERROR] {ex.Message}")
        End Try
    End Sub

    Private Function GetSessionNimAdmin() As String
        Try
            For Each asm In AppDomain.CurrentDomain.GetAssemblies()
                For Each t In asm.GetTypes()
                    If t.Name = "Session" Then
                        Dim prop = t.GetProperty("nimAdmin",
                            BindingFlags.Public Or BindingFlags.Static Or BindingFlags.FlattenHierarchy)
                        If prop IsNot Nothing Then
                            Dim v = prop.GetValue(Nothing)
                            If v IsNot Nothing Then Return v.ToString()
                        End If
                        Dim fld = t.GetField("nimAdmin",
                            BindingFlags.Public Or BindingFlags.Static Or BindingFlags.FlattenHierarchy)
                        If fld IsNot Nothing Then
                            Dim v = fld.GetValue(Nothing)
                            If v IsNot Nothing Then Return v.ToString()
                        End If
                    End If
                Next
            Next
        Catch ex As Exception
            Debug.WriteLine($"[SESSION REFLECTION ERROR] {ex.Message}")
        End Try
        Return String.Empty
    End Function

    ' ── Validasi ────────────────────────────────────────────────
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

    Private Function ValidasiKodeMK(kode As String) As HasilValidasi
        If String.IsNullOrWhiteSpace(kode) Then Return New HasilValidasi(False, "Kode MK wajib diisi.")
        If kode.Length < 3 Then Return New HasilValidasi(False, "Kode MK minimal 3 karakter.")
        If kode.Length > 20 Then Return New HasilValidasi(False, "Kode MK maksimal 20 karakter.")
        Return New HasilValidasi(True, "")
    End Function

    Private Function ValidasiNamaMK(nama As String) As HasilValidasi
        If String.IsNullOrWhiteSpace(nama) Then Return New HasilValidasi(False, "Nama Mata Kuliah wajib diisi.")
        If nama.Length < 3 Then Return New HasilValidasi(False, "Nama Mata Kuliah minimal 3 karakter.")
        If nama.Length > 100 Then Return New HasilValidasi(False, "Nama Mata Kuliah maksimal 100 karakter.")
        Return New HasilValidasi(True, "")
    End Function

    Private Function ValidasiSKS() As HasilValidasi
        If cboSKS.SelectedIndex < 0 Then Return New HasilValidasi(False, "SKS wajib dipilih.", cboSKS)
        Return New HasilValidasi(True, "")
    End Function

    Private Function ValidasiFormMataKuliah(Optional isEdit As Boolean = False) As Boolean
        Dim valid As Boolean = True
        epValidasi.Clear()

        If Not isEdit Then
            Dim vKode = ValidasiKodeMK(txtKodeMK.Text.Trim())
            If Not vKode.Valid Then
                epValidasi.SetError(txtKodeMK, vKode.Pesan)
                valid = False
            End If
        End If

        Dim vNama = ValidasiNamaMK(txtNamaMK.Text.Trim())
        If Not vNama.Valid Then
            epValidasi.SetError(txtNamaMK, vNama.Pesan)
            valid = False
        End If

        Dim vSKS = ValidasiSKS()
        If Not vSKS.Valid Then
            epValidasi.SetError(cboSKS, vSKS.Pesan)
            valid = False
        End If

        Return valid
    End Function

    Private Function PesanValidasiLengkap(Optional isEdit As Boolean = False) As String
        Dim sb As New System.Text.StringBuilder
        If Not isEdit Then
            Dim vKode = ValidasiKodeMK(txtKodeMK.Text.Trim())
            If Not vKode.Valid Then sb.AppendLine("• " & vKode.Pesan)
        End If
        Dim vNama = ValidasiNamaMK(txtNamaMK.Text.Trim())
        If Not vNama.Valid Then sb.AppendLine("• " & vNama.Pesan)
        Dim vSKS = ValidasiSKS()
        If Not vSKS.Valid Then sb.AppendLine("• " & vSKS.Pesan)
        Return sb.ToString()
    End Function

    Private Sub BersihkanSemuaError()
        epValidasi.Clear()
    End Sub

    ' ── Form Load ───────────────────────────────────────────────
    Private Sub FormMataKuliah_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        IsiFilterSKS()
        MuatDataMataKuliah()
        SetModeForm(False)
        tmrClock.Start()
        ' Seed clock and date immediately (don't wait 1 s for first tick)
        PerbaruhiJamTanggal()
    End Sub

    Private Sub IsiFilterSKS()
        ' cboSKS (form input) — items already set in designer, just ensure clear
        cboSKS.Items.Clear()
        For i = 1 To 6
            cboSKS.Items.Add(i.ToString())
        Next

        ' cmbFilterSKS (toolbar filter) — also seeded in designer; nothing extra needed
    End Sub

    Private Sub MuatDataMataKuliah()
        Try
            Dim dt = GetAllMataKuliah()
            dgvMataKuliah.DataSource = dt
            PerbaruhiLabelJumlah(dt.Rows.Count)
        Catch ex As Exception
            TampilkanError("Gagal memuat data", ex)
        End Try
    End Sub

    ' ── FIX: colNo has no DataPropertyName, so fill it in RowPrePaint
    '        (replaces the old AturKolomDGV approach for numbering)
    Private Sub dgvMataKuliah_RowPrePaint(sender As Object, e As DataGridViewRowPrePaintEventArgs) _
        Handles dgvMataKuliah.RowPrePaint

        If e.RowIndex < 0 Then Return

        ' Auto-number the No column
        dgvMataKuliah.Rows(e.RowIndex).Cells("colNo").Value = e.RowIndex + 1

        ' Alternating row colour
        Dim bg As Color = If(e.RowIndex Mod 2 = 0, Color.White, ColorTranslator.FromHtml("#F4FAFA"))
        If Not dgvMataKuliah.Rows(e.RowIndex).Selected Then
            dgvMataKuliah.Rows(e.RowIndex).DefaultCellStyle.BackColor = bg
            dgvMataKuliah.Rows(e.RowIndex).DefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#1C3333")
        End If
    End Sub

    Private Sub JalankanFilter()
        ' Resolve the filter-SKS value: index 0 is the "-- Filter SKS --" placeholder
        Dim sksFilter As String = If(cmbFilterSKS.SelectedIndex <= 0, "", cmbFilterSKS.SelectedItem.ToString())
        Dim kw As String = txtCari.Text.Trim()
        Try
            Dim dt = CariMataKuliah(kw, sksFilter)
            dgvMataKuliah.DataSource = dt
            PerbaruhiLabelJumlah(dt.Rows.Count)
        Catch ex As Exception
            TampilkanError("Gagal memfilter data", ex)
        End Try
    End Sub

    ' FIX: centralise lblJumlahData update
    Private Sub PerbaruhiLabelJumlah(jumlah As Integer)
        lblJumlahData.Text = $"{jumlah} data"
    End Sub

    Private Sub dgvMataKuliah_CellClick(sender As Object, e As DataGridViewCellEventArgs) _
        Handles dgvMataKuliah.CellClick

        If e.RowIndex < 0 Then Return
        _kodeMKDipilih = dgvMataKuliah.Rows(e.RowIndex).Cells("kodeMK").Value?.ToString()
        If String.IsNullOrEmpty(_kodeMKDipilih) Then Return

        Dim mk = GetMataKuliahByKode(_kodeMKDipilih)
        If mk Is Nothing Then Return

        _isLoading = True
        txtKodeMK.Text = mk.kodeMK
        txtNamaMK.Text = mk.namaMK
        Dim idx = cboSKS.Items.IndexOf(mk.sks.ToString())
        cboSKS.SelectedIndex = idx
        _isLoading = False

        BersihkanSemuaError()
        SetModeForm(True)
    End Sub

    ' FIX: also update lblModeBadge to reflect current mode
    Private Sub SetModeForm(adaPilihan As Boolean)
        _modeEdit = adaPilihan
        txtKodeMK.ReadOnly = adaPilihan
        btnSimpan.Enabled = Not adaPilihan
        btnUbah.Enabled = adaPilihan
        btnHapus.Enabled = adaPilihan

        If adaPilihan Then
            lblModeBadge.Text = "● EDIT"
            lblModeBadge.ForeColor = ColorTranslator.FromHtml("#D4883A")
        Else
            lblModeBadge.Text = "● TAMBAH BARU"
            lblModeBadge.ForeColor = ColorTranslator.FromHtml("#4A7C7E")
        End If
    End Sub

    Private Function BacaFormKeMataKuliah() As MataKuliah
        Return New MataKuliah With {
            .kodeMK = txtKodeMK.Text.Trim(),
            .namaMK = txtNamaMK.Text.Trim(),
            .sks = If(cboSKS.SelectedIndex >= 0, CInt(cboSKS.SelectedItem.ToString()), 0)
        }
    End Function

    ' ── Tombol ──────────────────────────────────────────────────
    Private Sub txtCari_TextChanged(sender As Object, e As EventArgs) Handles txtCari.TextChanged
        JalankanFilter()
    End Sub

    ' FIX: handler name matches designer control name (cmbFilterSKS)
    Private Sub cmbFilterSKS_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles cmbFilterSKS.SelectedIndexChanged
        JalankanFilter()
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        Dim formValid = ValidasiFormMataKuliah(isEdit:=False)
        Dim pesanTambahan = PesanValidasiLengkap(isEdit:=False)

        If Not formValid OrElse pesanTambahan.Length > 0 Then
            MessageBox.Show("Mohon perbaiki kesalahan:" & Environment.NewLine & Environment.NewLine & pesanTambahan,
                            "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If KodeMKSudahAda(txtKodeMK.Text.Trim()) Then
            epValidasi.SetError(txtKodeMK, "Kode MK sudah digunakan.")
            MessageBox.Show("Kode MK sudah terdaftar.", "Duplikat", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Dim mk = BacaFormKeMataKuliah()
            If TambahMataKuliah(mk) Then
                CatatLog("TAMBAH MATA KULIAH", $"Kode: {mk.kodeMK} | Nama: {mk.namaMK}")
                MessageBox.Show($"Mata Kuliah {mk.namaMK} berhasil ditambahkan.", "Berhasil",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
                ResetForm()
                JalankanFilter()
            Else
                MessageBox.Show("Gagal menyimpan.", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            TampilkanError("Gagal menambah mata kuliah", ex)
        End Try
    End Sub

    Private Sub btnUbah_Click(sender As Object, e As EventArgs) Handles btnUbah.Click
        If String.IsNullOrEmpty(_kodeMKDipilih) Then Return
        Dim formValid = ValidasiFormMataKuliah(isEdit:=True)
        Dim pesanTambahan = PesanValidasiLengkap(isEdit:=True)

        If Not formValid OrElse pesanTambahan.Length > 0 Then
            MessageBox.Show("Mohon perbaiki kesalahan:" & Environment.NewLine & Environment.NewLine & pesanTambahan,
                            "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If MessageBox.Show($"Yakin mengubah {txtNamaMK.Text.Trim()}?", "Konfirmasi",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Return

        Try
            Dim mk = BacaFormKeMataKuliah()
            mk.kodeMK = _kodeMKDipilih
            If UbahMataKuliah(mk) Then
                CatatLog("UBAH MATA KULIAH", $"Kode: {mk.kodeMK} | Nama: {mk.namaMK}")
                MessageBox.Show($"{mk.namaMK} berhasil diperbarui.", "Berhasil",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
                ResetForm()
                JalankanFilter()
            Else
                MessageBox.Show("Gagal memperbarui.", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            TampilkanError("Gagal mengubah mata kuliah", ex)
        End Try
    End Sub

    Private Sub btnHapus_Click(sender As Object, e As EventArgs) Handles btnHapus.Click
        If String.IsNullOrEmpty(_kodeMKDipilih) Then Return
        Dim namaMKText As String = txtNamaMK.Text.Trim()

        If MessageBox.Show(
                $"Hapus mata kuliah {namaMKText} ({_kodeMKDipilih})?{Environment.NewLine}Aksi ini TIDAK dapat dibatalkan.",
                "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.No Then Return

        Try
            If HapusMataKuliah(_kodeMKDipilih) Then
                CatatLog("HAPUS MATA KULIAH", $"Kode: {_kodeMKDipilih} | Nama: {namaMKText}")
                MessageBox.Show($"{namaMKText} berhasil dihapus.", "Berhasil",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
                ResetForm()
                JalankanFilter()
            Else
                MessageBox.Show("Gagal menghapus.", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            ' HapusMataKuliah throws a user-friendly message for FK constraint
            MessageBox.Show(ex.Message, "Tidak Dapat Dihapus", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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

    ' ── DGV styling ─────────────────────────────────────────────
    Private Sub dgvMataKuliah_SelectionChanged(sender As Object, e As EventArgs) _
        Handles dgvMataKuliah.SelectionChanged

        For Each row As DataGridViewRow In dgvMataKuliah.Rows
            If row.Selected Then
                row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#D9EFEF")
                row.DefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#1C3333")
            Else
                row.DefaultCellStyle.BackColor =
                    If(row.Index Mod 2 = 0, Color.White, ColorTranslator.FromHtml("#F4FAFA"))
                row.DefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#1C3333")
            End If
        Next
    End Sub

    ' ── Mouse hover ──────────────────────────────────────────────
    Private Sub btnSimpan_MouseEnter(s As Object, e As EventArgs) Handles btnSimpan.MouseEnter
        If btnSimpan.Enabled Then btnSimpan.BackColor = CLR_HOVER_D
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

    ' ── Keyboard shortcuts ───────────────────────────────────────
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        Select Case keyData
            Case Keys.Escape
                ResetForm()
                Return True
            Case Keys.F5
                JalankanFilter()
                Return True
            Case Keys.Control Or Keys.S
                If btnSimpan.Enabled Then btnSimpan.PerformClick()
                Return True
        End Select
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    ' ── Clock / Date ─────────────────────────────────────────────
    ' FIX: lblClock shows time only; lblDate shows date only
    Private Sub tmrClock_Tick(sender As Object, e As EventArgs) Handles tmrClock.Tick
        PerbaruhiJamTanggal()
    End Sub

    Private Sub PerbaruhiJamTanggal()
        Dim now As DateTime = DateTime.Now
        lblClock.Text = now.ToString("HH:mm:ss")
        lblDate.Text = now.ToString("dddd, dd MMMM yyyy")
    End Sub

    ' ── Utility ──────────────────────────────────────────────────
    Private Sub TampilkanError(konteks As String, ex As Exception)
        MessageBox.Show($"{konteks}:{Environment.NewLine}{ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error)
        Debug.WriteLine($"[ERROR] {konteks}: {ex}")
    End Sub

    Private Sub FormMataKuliah_FormClosing(sender As Object, e As FormClosingEventArgs) _
        Handles MyBase.FormClosing
        tmrClock.Stop()
        epValidasi.Dispose()
    End Sub

    Private Sub dgvMataKuliah_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) _
        Handles dgvMataKuliah.CellContentClick
        ' Reserved for future cell-button actions
    End Sub

End Class