Imports MySqlConnector

Public Class FormInputNilai

    Private idNilaiEdit As Integer = 0

    Private Sub FormInputNilai_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadMahasiswa()
        LoadMataKuliah()
        LoadDataNilai()
        ClearForm()

        btnSimpan.Enabled = True
        btnEdit.Enabled = False
        btnHapus.Enabled = False
    End Sub

    Private Sub LoadMahasiswa()
        Try
            Using conn = ConnectionModule.GetConnection()
                conn.Open()
                Dim dt As New DataTable()
                Dim cmd As New MySqlCommand(
                    "SELECT nim, namaMahasiswa FROM mahasiswa ORDER BY nim", conn)
                dt.Load(cmd.ExecuteReader())

                cmbNIM.DataSource = dt
                cmbNIM.DisplayMember = "nim"
                cmbNIM.ValueMember = "nim"
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadMataKuliah()
        Try
            Using conn = ConnectionModule.GetConnection()
                conn.Open()
                Dim dt As New DataTable()
                Dim cmd As New MySqlCommand(
                    "SELECT kodeMK, namaMK FROM matakuliah ORDER BY namaMK", conn)
                dt.Load(cmd.ExecuteReader())

                cmbMataKuliah.DataSource = dt
                cmbMataKuliah.DisplayMember = "namaMK"
                cmbMataKuliah.ValueMember = "kodeMK"
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbNIM_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbNIM.SelectedIndexChanged
        Try
            If cmbNIM.SelectedValue Is Nothing Then Exit Sub
            Using conn = ConnectionModule.GetConnection()
                conn.Open()
                Dim cmd As New MySqlCommand(
                    "SELECT namaMahasiswa FROM mahasiswa WHERE nim=@nim", conn)
                cmd.Parameters.AddWithValue("@nim", cmbNIM.SelectedValue)
                Dim nama = cmd.ExecuteScalar()
                If nama IsNot Nothing Then txtNamaMahasiswa.Text = nama.ToString()
            End Using
        Catch
        End Try
    End Sub

    Private Function ValidasiNilai() As Boolean
        Dim fields = {txtNilaiTugas, txtNilaiPraktikum, txtNilaiUTS, txtNilaiUAS, txtNilaiAfektif}

        For Each txt In fields
            If String.IsNullOrWhiteSpace(txt.Text) Then
                MessageBox.Show("Semua nilai harus diisi!", "Validasi Data",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txt.Focus()
                Return False
            End If

            Dim nilai As Double
            If Not Double.TryParse(txt.Text, nilai) Then
                MessageBox.Show("Nilai harus berupa angka!", "Validasi Data",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txt.Focus()
                Return False
            End If

            If nilai < 0 Or nilai > 100 Then
                MessageBox.Show("Nilai harus 0 - 100!", "Validasi Data",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txt.Focus()
                Return False
            End If
        Next

        Return True
    End Function

    Private Function HitungNilai() As (nilaiAkhir As Double, predikat As String)
        Dim tugas = Val(txtNilaiTugas.Text)
        Dim praktikum = Val(txtNilaiPraktikum.Text)
        Dim uts = Val(txtNilaiUTS.Text)
        Dim uas = Val(txtNilaiUAS.Text)
        Dim afektif = Val(txtNilaiAfektif.Text)

        Dim nilaiAkhir =
            (tugas * 0.2) + (praktikum * 0.15) + (uts * 0.25) +
            (uas * 0.3) + (afektif * 0.1)

        Return (nilaiAkhir, GetGrade(nilaiAkhir))
    End Function

    Private Function GetGrade(nilai As Double) As String
        If nilai >= 80 Then Return "A"
        If nilai >= 70 Then Return "B"
        If nilai >= 60 Then Return "C"
        If nilai >= 50 Then Return "D"
        Return "E"
    End Function

    Private Function DataSudahAda(nim As String, kodeMK As String, semester As String) As Boolean
        Try
            Using conn = ConnectionModule.GetConnection()
                conn.Open()
                Dim cmd As New MySqlCommand(
                    "SELECT COUNT(*) FROM nilai " &
                    "WHERE nim=@nim AND kodeMK=@kodeMK AND semester=@semester", conn)
                cmd.Parameters.AddWithValue("@nim", nim)
                cmd.Parameters.AddWithValue("@kodeMK", kodeMK)
                cmd.Parameters.AddWithValue("@semester", semester)
                Return Convert.ToInt32(cmd.ExecuteScalar()) > 0
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return True
        End Try
    End Function

    Private Sub LoadDataNilai()
        Try
            Using conn = ConnectionModule.GetConnection()
                conn.Open()

                Dim query As String =
                    "SELECT n.idNilai,n.nim,m.namaMahasiswa,n.kodeMK,mk.namaMK," &
                    "n.tugas,n.praktikum,n.uts,n.uas,n.afektif," &
                    "n.nilaiAkhir,n.predikat,n.semester,n.tglInput " &
                    "FROM nilai n " &
                    "JOIN mahasiswa m  ON n.nim    = m.nim " &
                    "JOIN matakuliah mk ON n.kodeMK = mk.kodeMK " &
                    "ORDER BY n.idNilai"

                Dim da As New MySqlDataAdapter(query, conn)
                Dim dt As New DataTable()
                da.Fill(dt)

                dgvNilai.DataSource = dt
                With dgvNilai
                    .Columns("idNilai").HeaderText = "ID Nilai"
                    .Columns("nim").HeaderText = "NIM"
                    .Columns("namaMahasiswa").HeaderText = "Nama Mahasiswa"
                    .Columns("kodeMK").HeaderText = "Kode MK"
                    .Columns("namaMK").HeaderText = "Mata Kuliah"
                    .Columns("tugas").HeaderText = "Tugas"
                    .Columns("praktikum").HeaderText = "Praktikum"
                    .Columns("uts").HeaderText = "UTS"
                    .Columns("uas").HeaderText = "UAS"
                    .Columns("afektif").HeaderText = "Afektif"
                    .Columns("nilaiAkhir").HeaderText = "Nilai Akhir"
                    .Columns("predikat").HeaderText = "Predikat"
                    .Columns("semester").HeaderText = "Semester"
                    .Columns("tglInput").HeaderText = "Tanggal Input"
                    .ClearSelection()
                    .CurrentCell = Nothing
                End With
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvNilai_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvNilai.CellClick
        If e.RowIndex < 0 Then Exit Sub
        Dim r = dgvNilai.Rows(e.RowIndex)
        idNilaiEdit = r.Cells("idNilai").Value

        cmbNIM.Text = r.Cells("nim").Value.ToString()
        cmbMataKuliah.Text = r.Cells("namaMK").Value.ToString()
        cmbSemester.Text = r.Cells("semester").Value.ToString()

        txtNilaiTugas.Text = r.Cells("tugas").Value.ToString()
        txtNilaiPraktikum.Text = r.Cells("praktikum").Value.ToString()
        txtNilaiUTS.Text = r.Cells("uts").Value.ToString()
        txtNilaiUAS.Text = r.Cells("uas").Value.ToString()
        txtNilaiAfektif.Text = r.Cells("afektif").Value.ToString()

        lblNilaiEfektifValue.Text = r.Cells("nilaiAkhir").Value.ToString()
        lblPredikatValue.Text = r.Cells("predikat").Value.ToString()

        btnSimpan.Enabled = False
        btnEdit.Enabled = True
        btnHapus.Enabled = True
    End Sub

    Private Sub btnHitung_Click(sender As Object, e As EventArgs) Handles btnHitung.Click
        Try
            Dim hasil = HitungNilai()
            lblNilaiEfektifValue.Text = hasil.nilaiAkhir.ToString("0.00")
            lblPredikatValue.Text = hasil.predikat
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        Try
            If cmbNIM.SelectedValue Is Nothing OrElse cmbMataKuliah.SelectedValue Is Nothing OrElse
               String.IsNullOrWhiteSpace(cmbSemester.Text) Then
                MessageBox.Show("Lengkapi data!", "Validasi Data",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            If Not ValidasiNilai() Then Exit Sub

            If DataSudahAda(cmbNIM.SelectedValue.ToString(),
                            cmbMataKuliah.SelectedValue.ToString(),
                            cmbSemester.Text) Then
                MessageBox.Show("Data sudah ada!", "Duplikat Data",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Dim hasil = HitungNilai()

            Using conn = ConnectionModule.GetConnection()
                conn.Open()
                Dim cmd As New MySqlCommand(
                    "INSERT INTO nilai " &
                    "(nim,kodeMK,tugas,praktikum,uts,uas,afektif,nilaiAkhir,predikat,semester) " &
                    "VALUES " &
                    "(@nim,@kodeMK,@tugas,@praktikum,@uts,@uas,@afektif,@nilaiAkhir,@predikat,@semester)", conn)

                cmd.Parameters.AddWithValue("@nim", cmbNIM.SelectedValue.ToString())
                cmd.Parameters.AddWithValue("@kodeMK", cmbMataKuliah.SelectedValue.ToString())
                cmd.Parameters.AddWithValue("@semester", cmbSemester.Text)
                cmd.Parameters.AddWithValue("@tugas", CDbl(txtNilaiTugas.Text))
                cmd.Parameters.AddWithValue("@praktikum", CDbl(txtNilaiPraktikum.Text))
                cmd.Parameters.AddWithValue("@uts", CDbl(txtNilaiUTS.Text))
                cmd.Parameters.AddWithValue("@uas", CDbl(txtNilaiUAS.Text))
                cmd.Parameters.AddWithValue("@afektif", CDbl(txtNilaiAfektif.Text))
                cmd.Parameters.AddWithValue("@nilaiAkhir", hasil.nilaiAkhir)
                cmd.Parameters.AddWithValue("@predikat", hasil.predikat)
                cmd.ExecuteNonQuery()
            End Using

            MessageBox.Show("Data berhasil disimpan", "Sukses",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadDataNilai()
            ClearForm()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If idNilaiEdit = 0 Then Exit Sub
        If Not ValidasiNilai() Then Exit Sub

        Dim hasil = HitungNilai()

        Try
            Using conn = ConnectionModule.GetConnection()
                conn.Open()
                Dim cmd As New MySqlCommand(
                    "UPDATE nilai SET " &
                    "nim=@nim,kodeMK=@kodeMK,semester=@semester," &
                    "tugas=@tugas,praktikum=@praktikum,uts=@uts,uas=@uas,afektif=@afektif," &
                    "nilaiAkhir=@nilaiAkhir,predikat=@predikat " &
                    "WHERE idNilai=@id", conn)

                cmd.Parameters.AddWithValue("@nim", cmbNIM.SelectedValue.ToString())
                cmd.Parameters.AddWithValue("@kodeMK", cmbMataKuliah.SelectedValue.ToString())
                cmd.Parameters.AddWithValue("@semester", cmbSemester.Text)
                cmd.Parameters.AddWithValue("@tugas", CDbl(txtNilaiTugas.Text))
                cmd.Parameters.AddWithValue("@praktikum", CDbl(txtNilaiPraktikum.Text))
                cmd.Parameters.AddWithValue("@uts", CDbl(txtNilaiUTS.Text))
                cmd.Parameters.AddWithValue("@uas", CDbl(txtNilaiUAS.Text))
                cmd.Parameters.AddWithValue("@afektif", CDbl(txtNilaiAfektif.Text))
                cmd.Parameters.AddWithValue("@nilaiAkhir", hasil.nilaiAkhir)
                cmd.Parameters.AddWithValue("@predikat", hasil.predikat)
                cmd.Parameters.AddWithValue("@id", idNilaiEdit)
                cmd.ExecuteNonQuery()
            End Using

            MessageBox.Show("Data berhasil diupdate", "Sukses",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadDataNilai()
            ClearForm()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnHapus_Click(sender As Object, e As EventArgs) Handles btnHapus.Click
        If idNilaiEdit = 0 Then Exit Sub

        If MessageBox.Show("Hapus data?", "Konfirmasi",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Exit Sub

        Try
            Using conn = ConnectionModule.GetConnection()
                conn.Open()
                Dim cmd As New MySqlCommand(
                    "DELETE FROM nilai WHERE idNilai=@id", conn)
                cmd.Parameters.AddWithValue("@id", idNilaiEdit)
                cmd.ExecuteNonQuery()
            End Using

            MessageBox.Show("Data berhasil dihapus", "Sukses",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadDataNilai()
            ClearForm()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadDataNilai()
        ClearForm()
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        Try
            Using conn = ConnectionModule.GetConnection()
                conn.Open()
                Dim query As String =
                    "SELECT n.idNilai,n.nim,m.namaMahasiswa,n.kodeMK,mk.namaMK," &
                    "n.tugas,n.praktikum,n.uts,n.uas,n.afektif,n.nilaiAkhir,n.predikat,n.semester,n.tglInput " &
                    "FROM nilai n " &
                    "JOIN mahasiswa m   ON n.nim    = m.nim " &
                    "JOIN matakuliah mk ON n.kodeMK = mk.kodeMK " &
                    "WHERE n.nim LIKE @c OR m.namaMahasiswa LIKE @c " &
                    "   OR n.kodeMK LIKE @c OR mk.namaMK LIKE @c OR n.semester LIKE @c " &
                    "ORDER BY n.idNilai"

                Dim da As New MySqlDataAdapter(query, conn)
                da.SelectCommand.Parameters.AddWithValue("@c", "%" & txtSearch.Text & "%")
                Dim dt As New DataTable()
                da.Fill(dt)
                dgvNilai.DataSource = dt
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ClearForm()
        cmbNIM.SelectedIndex = -1
        cmbMataKuliah.SelectedIndex = -1
        cmbSemester.SelectedIndex = -1
        txtNamaMahasiswa.Clear()
        txtNilaiTugas.Clear()
        txtNilaiPraktikum.Clear()
        txtNilaiUTS.Clear()
        txtNilaiUAS.Clear()
        txtNilaiAfektif.Clear()
        lblNilaiEfektifValue.Text = "0.00"
        lblPredikatValue.Text = "-"
        idNilaiEdit = 0
        btnSimpan.Enabled = True
        btnEdit.Enabled = False
        btnHapus.Enabled = False
        dgvNilai.ClearSelection()
        dgvNilai.CurrentCell = Nothing
    End Sub

End Class
