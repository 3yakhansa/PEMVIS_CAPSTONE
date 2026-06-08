Imports MySqlConnector

Public Class FormDashboardMahasiswa

    Private _nim As String = ""
    <System.ComponentModel.Browsable(False)>
    <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)>
    Public Property nim As String
        Get
            Return _nim
        End Get
        Set(value As String)
            _nim = value
        End Set
    End Property

    ' =========================================================
    ' Form Load
    ' =========================================================
    Private Sub FormDashboardMahasiswa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If String.IsNullOrEmpty(_nim) Then
            MessageBox.Show("NIM mahasiswa tidak ditemukan. Silakan login ulang.",
                            "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.Close()
            Return
        End If

        MuatDataProfil()
        MuatDataNilai()
        MuatRingkasanNilai()
    End Sub

    ' =========================================================
    ' Muat data profil mahasiswa
    ' =========================================================
    Private Sub MuatDataProfil()
        Try
            Using conn As New MySqlConnection(ConnectionModule.ConnectionString)
                conn.Open()
                Dim query As String =
                    "SELECT nim, namaMahasiswa, jenisKelamin, tempatLahir, tanggalLahir,
                            alamat, noTelp, email, angkatan
                     FROM mahasiswa
                     WHERE nim = @nim"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@nim", _nim)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            LabelNamaValue.Text = reader("namaMahasiswa").ToString()
                            LabelNIMValue.Text = reader("nim").ToString()
                            LabelAngkatanValue.Text = reader("angkatan").ToString()

                            Dim jk As String = reader("jenisKelamin").ToString()
                            LabelJKValue.Text = If(jk = "L", "Laki-laki", "Perempuan")

                            Dim ttl As String = ""
                            If Not IsDBNull(reader("tempatLahir")) Then
                                ttl = reader("tempatLahir").ToString()
                            End If
                            If Not IsDBNull(reader("tanggalLahir")) Then
                                Dim tgl As Date = CDate(reader("tanggalLahir"))
                                ttl &= If(ttl <> "", ", " & tgl.ToString("dd MMMM yyyy"), tgl.ToString("dd MMMM yyyy"))
                            End If
                            LabelTTLValue.Text = If(ttl <> "", ttl, "-")

                            LabelAlamatValue.Text = If(IsDBNull(reader("alamat")), "-", reader("alamat").ToString())
                            LabelNoTelpValue.Text = If(IsDBNull(reader("noTelp")), "-", reader("noTelp").ToString())
                            LabelEmailValue.Text = If(IsDBNull(reader("email")), "-", reader("email").ToString())

                            ' Update header nama
                            LabelSubtitle.Text = "Selamat datang, " & reader("namaMahasiswa").ToString() & "!"
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Gagal memuat data profil: " & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' =========================================================
    ' Muat data nilai mahasiswa
    ' =========================================================
    Private Sub MuatDataNilai()
        Try
            Using conn As New MySqlConnection(ConnectionModule.ConnectionString)
                conn.Open()
                Dim query As String =
                    "SELECT mk.namaMK, mk.sks, n.tugas, n.praktikum, n.uts, n.uas,
                            n.nilaiAkhir, n.nilai AS huruf, n.predikat, n.semester
                     FROM nilai n
                     INNER JOIN matakuliah mk ON n.kodeMK = mk.kodeMK
                     WHERE n.nim = @nim
                     ORDER BY n.semester DESC, mk.namaMK ASC"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@nim", _nim)
                    Dim da As New MySqlDataAdapter(cmd)
                    Dim dt As New DataTable()
                    da.Fill(dt)

                    ' Rename kolom untuk tampilan
                    If dt.Columns.Contains("namaMK") Then dt.Columns("namaMK").ColumnName = "Mata Kuliah"
                    If dt.Columns.Contains("sks") Then dt.Columns("sks").ColumnName = "SKS"
                    If dt.Columns.Contains("tugas") Then dt.Columns("tugas").ColumnName = "Tugas"
                    If dt.Columns.Contains("praktikum") Then dt.Columns("praktikum").ColumnName = "Praktikum"
                    If dt.Columns.Contains("uts") Then dt.Columns("uts").ColumnName = "UTS"
                    If dt.Columns.Contains("uas") Then dt.Columns("uas").ColumnName = "UAS"
                    If dt.Columns.Contains("nilaiAkhir") Then dt.Columns("nilaiAkhir").ColumnName = "Nilai Akhir"
                    If dt.Columns.Contains("huruf") Then dt.Columns("huruf").ColumnName = "Nilai"
                    If dt.Columns.Contains("predikat") Then dt.Columns("predikat").ColumnName = "Predikat"
                    If dt.Columns.Contains("semester") Then dt.Columns("semester").ColumnName = "Semester"

                    DataGridViewNilai.DataSource = dt
                    AturKolomGrid()

                    LabelTotalMK.Text = "Total Mata Kuliah: " & dt.Rows.Count & " MK"
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Gagal memuat data nilai: " & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' =========================================================
    ' Muat ringkasan / statistik nilai
    ' =========================================================
    Private Sub MuatRingkasanNilai()
        Try
            Using conn As New MySqlConnection(ConnectionModule.ConnectionString)
                conn.Open()
                Dim query As String =
                    "SELECT COUNT(*) AS totalMK,
                            COALESCE(SUM(mk.sks), 0) AS totalSKS,
                            COALESCE(AVG(n.nilaiAkhir), 0) AS rataRata
                     FROM nilai n
                     INNER JOIN matakuliah mk ON n.kodeMK = mk.kodeMK
                     WHERE n.nim = @nim AND n.nilaiAkhir IS NOT NULL"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@nim", _nim)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            LabelCardMKValue.Text = reader("totalMK").ToString()
                            LabelCardSKSValue.Text = reader("totalSKS").ToString()

                            Dim rata As Double = CDbl(reader("rataRata"))
                            LabelCardRataValue.Text = rata.ToString("F2")

                            ' Hitung IP sederhana (skala 4)
                            Dim ip As Double = HitungIP(rata)
                            LabelCardIPValue.Text = ip.ToString("F2")
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            ' Tampilkan default jika gagal
            LabelCardMKValue.Text = "0"
            LabelCardSKSValue.Text = "0"
            LabelCardRataValue.Text = "0.00"
            LabelCardIPValue.Text = "0.00"
        End Try
    End Sub

    ' =========================================================
    ' Konversi nilai angka ke IP skala 4
    ' =========================================================
    Private Function HitungIP(nilaiAngka As Double) As Double
        Select Case nilaiAngka
            Case Is >= 85 : Return 4.0
            Case Is >= 75 : Return 3.5
            Case Is >= 70 : Return 3.0
            Case Is >= 60 : Return 2.5
            Case Is >= 55 : Return 2.0
            Case Is >= 40 : Return 1.0
            Case Else : Return 0.0
        End Select
    End Function

    ' =========================================================
    ' Atur tampilan kolom DataGridView
    ' =========================================================
    Private Sub AturKolomGrid()
        With DataGridViewNilai
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

            For Each col As DataGridViewColumn In .Columns
                col.MinimumWidth = 60
            Next

            ' Kolom angka - center align
            Dim kolomAngka() As String = {"SKS", "Tugas", "Praktikum", "UTS", "UAS", "Nilai Akhir", "Nilai", "Predikat"}
            For Each namaKolom As String In kolomAngka
                If .Columns.Contains(namaKolom) Then
                    .Columns(namaKolom).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Columns(namaKolom).FillWeight = 60
                End If
            Next

            ' Kolom Mata Kuliah lebih lebar
            If .Columns.Contains("Mata Kuliah") Then
                .Columns("Mata Kuliah").FillWeight = 180
            End If
            If .Columns.Contains("Semester") Then
                .Columns("Semester").FillWeight = 70
                .Columns("Semester").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End If
        End With
    End Sub

    ' =========================================================
    ' Tombol Refresh
    ' =========================================================
    Private Sub ButtonRefresh_Click(sender As Object, e As EventArgs) Handles ButtonRefresh.Click
        MuatDataProfil()
        MuatDataNilai()
        MuatRingkasanNilai()
        MessageBox.Show("Data berhasil diperbarui.", "Info",
                        MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    ' =========================================================
    ' Tombol Tutup
    ' =========================================================
    Private Sub ButtonClose_Click(sender As Object, e As EventArgs) Handles ButtonClose.Click
        Me.Close()
    End Sub

    ' =========================================================
    ' Warnai baris berdasarkan nilai huruf
    ' =========================================================
    Private Sub DataGridViewNilai_RowPrePaint(sender As Object, e As DataGridViewRowPrePaintEventArgs) Handles DataGridViewNilai.RowPrePaint
        If e.RowIndex < 0 OrElse e.RowIndex >= DataGridViewNilai.Rows.Count Then Return

        Dim row As DataGridViewRow = DataGridViewNilai.Rows(e.RowIndex)
        If row.DataBoundItem Is Nothing Then Return

        If DataGridViewNilai.Columns.Contains("Nilai") Then
            Dim nilaiHuruf As String = row.Cells("Nilai").Value?.ToString()
            Select Case nilaiHuruf
                Case "A"
                    row.DefaultCellStyle.BackColor = Color.FromArgb(220, 255, 220)
                Case "AB", "B"
                    row.DefaultCellStyle.BackColor = Color.FromArgb(240, 255, 240)
                Case "BC", "C"
                    row.DefaultCellStyle.BackColor = Color.White
                Case "D", "E"
                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 240, 240)
                Case Else
                    row.DefaultCellStyle.BackColor = Color.White
            End Select
        End If
    End Sub

End Class