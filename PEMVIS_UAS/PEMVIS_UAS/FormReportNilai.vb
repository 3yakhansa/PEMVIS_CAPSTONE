Imports System.Data
Imports System.Drawing.Printing
Imports MySqlConnector

Public Class FormReportNilai

    Private conn As MySqlConnection
    Private dtNilai As DataTable
    Private printData As DataTable
    Private currentPage As Integer = 0
    Private rowsPerPage As Integer = 25

    Public Sub New()
        InitializeComponent()
        InitializeForm()
    End Sub

    Private Sub InitializeForm()
        SetupDataGridView()
        LoadMataKuliah()
        LoadSemester()
        LoadNilai()
        PrintDocument1.DocumentName = "Report Nilai Mahasiswa"
        PrintPreviewDialog1.Document = PrintDocument1
    End Sub

    Private Sub SetupDataGridView()
        DataGridViewNilai.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 9.5, FontStyle.Bold)
        DataGridViewNilai.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(102, 187, 187)
        DataGridViewNilai.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        DataGridViewNilai.EnableHeadersVisualStyles = False
        DataGridViewNilai.DefaultCellStyle.Font = New Font("Segoe UI", 9.0, FontStyle.Regular)
        DataGridViewNilai.DefaultCellStyle.ForeColor = Color.FromArgb(74, 144, 144)
        DataGridViewNilai.DefaultCellStyle.SelectionBackColor = Color.FromArgb(220, 240, 240)
        DataGridViewNilai.DefaultCellStyle.SelectionForeColor = Color.FromArgb(74, 144, 144)
        DataGridViewNilai.RowTemplate.Height = 33
        DataGridViewNilai.AllowUserToAddRows = False
        DataGridViewNilai.AllowUserToDeleteRows = False
        DataGridViewNilai.ReadOnly = True
        DataGridViewNilai.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DataGridViewNilai.MultiSelect = False
        DataGridViewNilai.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
        DataGridViewNilai.BackgroundColor = Color.White
        DataGridViewNilai.BorderStyle = BorderStyle.None
        DataGridViewNilai.GridColor = Color.FromArgb(220, 240, 240)
        DataGridViewNilai.RowHeadersVisible = False

        DataGridViewNilai.Columns.Clear()
        DataGridViewNilai.Columns.Add("ColNo", "No")
        DataGridViewNilai.Columns.Add("ColNIM", "NIM")
        DataGridViewNilai.Columns.Add("ColNama", "Nama Mahasiswa")
        DataGridViewNilai.Columns.Add("ColMK", "Mata Kuliah")
        DataGridViewNilai.Columns.Add("ColSemester", "Semester")
        DataGridViewNilai.Columns.Add("ColTugas", "Tugas")
        DataGridViewNilai.Columns.Add("ColPraktikum", "Praktikum")
        DataGridViewNilai.Columns.Add("ColUTS", "UTS")
        DataGridViewNilai.Columns.Add("ColUAS", "UAS")
        DataGridViewNilai.Columns.Add("ColEfektif", "Nilai Efektif")
        DataGridViewNilai.Columns.Add("ColPredikat", "Predikat")

        DataGridViewNilai.Columns("ColNo").Width = 45
        DataGridViewNilai.Columns("ColNo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewNilai.Columns("ColNIM").Width = 110
        DataGridViewNilai.Columns("ColNama").Width = 180
        DataGridViewNilai.Columns("ColMK").Width = 180
        DataGridViewNilai.Columns("ColSemester").Width = 80
        DataGridViewNilai.Columns("ColSemester").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewNilai.Columns("ColTugas").Width = 65
        DataGridViewNilai.Columns("ColTugas").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewNilai.Columns("ColPraktikum").Width = 75
        DataGridViewNilai.Columns("ColPraktikum").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewNilai.Columns("ColUTS").Width = 55
        DataGridViewNilai.Columns("ColUTS").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewNilai.Columns("ColUAS").Width = 55
        DataGridViewNilai.Columns("ColUAS").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewNilai.Columns("ColEfektif").Width = 85
        DataGridViewNilai.Columns("ColEfektif").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewNilai.Columns("ColPredikat").Width = 75
        DataGridViewNilai.Columns("ColPredikat").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        AddHandler DataGridViewNilai.CellFormatting, AddressOf DataGridViewNilai_CellFormatting
    End Sub

    Private Sub DataGridViewNilai_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs)
        If DataGridViewNilai.Columns(e.ColumnIndex).Name = "ColPredikat" AndAlso e.Value IsNot Nothing Then
            Select Case e.Value.ToString().Trim()
                Case "A"
                    e.CellStyle.BackColor = Color.FromArgb(180, 240, 180)
                    e.CellStyle.ForeColor = Color.FromArgb(0, 120, 0)
                    e.CellStyle.Font = New Font("Segoe UI", 9.0, FontStyle.Bold)
                Case "B"
                    e.CellStyle.BackColor = Color.FromArgb(200, 230, 255)
                    e.CellStyle.ForeColor = Color.FromArgb(0, 80, 160)
                    e.CellStyle.Font = New Font("Segoe UI", 9.0, FontStyle.Bold)
                Case "C"
                    e.CellStyle.BackColor = Color.FromArgb(255, 245, 200)
                    e.CellStyle.ForeColor = Color.FromArgb(160, 120, 0)
                Case "D"
                    e.CellStyle.BackColor = Color.FromArgb(255, 225, 190)
                    e.CellStyle.ForeColor = Color.FromArgb(180, 80, 0)
                Case "E"
                    e.CellStyle.BackColor = Color.FromArgb(255, 210, 210)
                    e.CellStyle.ForeColor = Color.FromArgb(180, 0, 0)
                    e.CellStyle.Font = New Font("Segoe UI", 9.0, FontStyle.Bold)
            End Select
        End If
    End Sub

    Private Sub LoadMataKuliah()
        Try
            conn = New MySqlConnection(ConnectionModule.ConnectionString)
            conn.Open()
            Dim cmd As New MySqlCommand("SELECT kodeMK, namaMK FROM matakuliah ORDER BY namaMK", conn)
            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            ComboBoxMatkul.Items.Clear()
            ComboBoxMatkul.Items.Add("-- Semua Mata Kuliah --")
            While reader.Read()
                ComboBoxMatkul.Items.Add(reader("kodeMK").ToString() & " - " & reader("namaMK").ToString())
            End While
            reader.Close()
            ComboBoxMatkul.SelectedIndex = 0
            conn.Close()
        Catch ex As Exception
            ' Tidak munculkan error saat init combo
        Finally
            If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub

    Private Sub LoadSemester()
        ComboBoxSemester.Items.Clear()
        ComboBoxSemester.Items.Add("-- Semua Semester --")
        Dim tahun As Integer = DateTime.Now.Year
        For i As Integer = tahun To tahun - 3 Step -1
            ComboBoxSemester.Items.Add(i.ToString() & "/1")
            ComboBoxSemester.Items.Add(i.ToString() & "/2")
        Next
        ComboBoxSemester.SelectedIndex = 0
    End Sub

    Private Sub LoadNilai()
        Try
            conn = New MySqlConnection(ConnectionModule.ConnectionString)
            conn.Open()

            Dim query As String =
                "SELECT n.*, m.namaMahasiswa, mk.namaMK " &
                "FROM nilai n " &
                "JOIN mahasiswa m   ON n.nim    = m.nim " &
                "JOIN matakuliah mk ON n.kodeMK = mk.kodeMK " &
                "WHERE 1=1"

            ' Filter mata kuliah
            If ComboBoxMatkul.SelectedIndex > 0 Then
                Dim kode As String = ComboBoxMatkul.SelectedItem.ToString().Split("-"c)(0).Trim()
                query &= " AND n.kodeMK = @kodeMK"
            End If

            ' Filter semester
            If ComboBoxSemester.SelectedIndex > 0 Then
                query &= " AND n.semester = @semester"
            End If

            ' Filter cari
            If Not String.IsNullOrWhiteSpace(TextBoxCari.Text) Then
                query &= " AND (m.namaMahasiswa LIKE @cari OR n.nim LIKE @cari OR mk.namaMK LIKE @cari)"
            End If

            query &= " ORDER BY m.namaMahasiswa, mk.namaMK"

            Using cmd As New MySqlCommand(query, conn)
                If ComboBoxMatkul.SelectedIndex > 0 Then
                    Dim kode As String = ComboBoxMatkul.SelectedItem.ToString().Split("-"c)(0).Trim()
                    cmd.Parameters.AddWithValue("@kodeMK", kode)
                End If
                If ComboBoxSemester.SelectedIndex > 0 Then
                    cmd.Parameters.AddWithValue("@semester", ComboBoxSemester.SelectedItem.ToString())
                End If
                If Not String.IsNullOrWhiteSpace(TextBoxCari.Text) Then
                    cmd.Parameters.AddWithValue("@cari", "%" & TextBoxCari.Text.Trim() & "%")
                End If

                Dim adapter As New MySqlDataAdapter(cmd)
                dtNilai = New DataTable()
                adapter.Fill(dtNilai)
            End Using

            DisplayData()
            conn.Close()

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub

    Private Sub DisplayData()
        DataGridViewNilai.Rows.Clear()
        If dtNilai IsNot Nothing AndAlso dtNilai.Rows.Count > 0 Then
            Dim no As Integer = 1
            For Each row As DataRow In dtNilai.Rows
                DataGridViewNilai.Rows.Add(
                    no,
                    row("nim"),
                    row("namaMahasiswa"),
                    row("namaMK"),
                    row("semester"),
                    row("tugas"),
                    row("praktikum"),
                    row("uts"),
                    row("uas"),
                    row("nilaiAkhir"),
                    row("predikat"))
                no += 1
            Next
        End If
        LabelTotalRecord.Text = "Total Record: " & DataGridViewNilai.Rows.Count & " data"
    End Sub

    ' ── Print ────────────────────────────────────────────────────
    Private Sub PrintDocument1_BeginPrint(sender As Object, e As PrintEventArgs) Handles PrintDocument1.BeginPrint
        printData = New DataTable()
        For Each col As String In {"No", "NIM", "Nama Mahasiswa", "Mata Kuliah", "Semester",
                                   "Tugas", "Praktikum", "UTS", "UAS", "Efektif", "Predikat"}
            printData.Columns.Add(col)
        Next
        For Each row As DataGridViewRow In DataGridViewNilai.Rows
            If Not row.IsNewRow Then
                printData.Rows.Add(
                    row.Cells("ColNo").Value, row.Cells("ColNIM").Value,
                    row.Cells("ColNama").Value, row.Cells("ColMK").Value,
                    row.Cells("ColSemester").Value, row.Cells("ColTugas").Value,
                    row.Cells("ColPraktikum").Value, row.Cells("ColUTS").Value,
                    row.Cells("ColUAS").Value, row.Cells("ColEfektif").Value,
                    row.Cells("ColPredikat").Value)
            End If
        Next
        currentPage = 0
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim titleFont As New Font("Segoe UI", 15, FontStyle.Bold)
        Dim headerFont As New Font("Segoe UI", 9, FontStyle.Bold)
        Dim contentFont As New Font("Segoe UI", 8.5, FontStyle.Regular)
        Dim footerFont As New Font("Segoe UI", 8, FontStyle.Italic)
        Dim headerColor As Color = Color.FromArgb(102, 187, 187)
        Dim titleColor As Color = Color.FromArgb(74, 144, 144)
        Dim textColor As Color = Color.FromArgb(50, 50, 50)

        Dim leftMargin As Single = e.MarginBounds.Left
        Dim topMargin As Single = e.MarginBounds.Top
        Dim rightMargin As Single = e.MarginBounds.Right
        Dim bottomMargin As Single = e.MarginBounds.Bottom
        Dim yPos As Single = topMargin

        Dim titleText As String = "REPORT NILAI MAHASISWA - PROGRAM STUDI XYZ"
        Dim ts As SizeF = e.Graphics.MeasureString(titleText, titleFont)
        e.Graphics.DrawString(titleText, titleFont, New SolidBrush(titleColor),
                             leftMargin + (e.MarginBounds.Width - ts.Width) / 2, yPos)
        yPos += ts.Height + 4

        Dim subFont As New Font("Segoe UI", 9, FontStyle.Regular)
        Dim sub1 As String = "Dicetak pada: " & DateTime.Now.ToString("dd MMMM yyyy HH:mm:ss")
        Dim s1 As SizeF = e.Graphics.MeasureString(sub1, subFont)
        e.Graphics.DrawString(sub1, subFont, Brushes.Gray,
                             leftMargin + (e.MarginBounds.Width - s1.Width) / 2, yPos)
        yPos += s1.Height + 12
        e.Graphics.DrawLine(New Pen(headerColor, 2), leftMargin, yPos, rightMargin, yPos)
        yPos += 10

        Dim colWidths As Single() = {35, 90, 150, 140, 60, 50, 60, 50, 50, 65, 55}
        Dim totalWidth As Single = colWidths.Sum()
        Dim startX As Single = leftMargin + (e.MarginBounds.Width - totalWidth) / 2
        Dim headerHeight As Single = 24
        e.Graphics.FillRectangle(New SolidBrush(headerColor), startX, yPos, totalWidth, headerHeight)

        Dim headers As String() = {"No", "NIM", "Nama Mahasiswa", "Mata Kuliah", "Sem",
                                   "Tugas", "Prakt.", "UTS", "UAS", "Efektif", "Predikat"}
        Dim colX As Single = startX
        For i As Integer = 0 To headers.Length - 1
            Dim hR As New RectangleF(colX, yPos, colWidths(i), headerHeight)
            e.Graphics.DrawString(headers(i), headerFont, Brushes.White, hR,
                New StringFormat With {.Alignment = StringAlignment.Center,
                                       .LineAlignment = StringAlignment.Center})
            colX += colWidths(i)
        Next
        yPos += headerHeight

        Dim rowH As Single = 20
        Dim rowsPrinted As Integer = 0
        Dim startRow As Integer = currentPage * rowsPerPage

        While startRow + rowsPrinted < printData.Rows.Count AndAlso yPos + rowH <= bottomMargin
            Dim row As DataRow = printData.Rows(startRow + rowsPrinted)
            Dim bg As Color = If(rowsPrinted Mod 2 = 0, Color.White, Color.FromArgb(240, 248, 248))
            e.Graphics.FillRectangle(New SolidBrush(bg), startX, yPos, totalWidth, rowH)
            colX = startX
            For i As Integer = 0 To row.ItemArray.Length - 1
                Dim cR As New RectangleF(colX, yPos, colWidths(i), rowH)
                Dim align As StringAlignment = If(i = 0 OrElse i >= 5, StringAlignment.Center, StringAlignment.Near)
                e.Graphics.DrawString(row(i).ToString(), contentFont, New SolidBrush(textColor), cR,
                    New StringFormat With {.Alignment = align, .LineAlignment = StringAlignment.Center,
                                          .Trimming = StringTrimming.EllipsisCharacter})
                colX += colWidths(i)
            Next
            e.Graphics.DrawRectangle(New Pen(Color.LightGray, 0.5), startX, yPos, totalWidth, rowH)
            yPos += rowH
            rowsPrinted += 1
        End While

        Dim totalPages As Integer = CInt(Math.Ceiling(printData.Rows.Count / rowsPerPage))
        currentPage += 1
        e.Graphics.DrawString(
            "Halaman " & currentPage & " dari " & totalPages & " | Total: " & printData.Rows.Count & " data",
            footerFont, Brushes.Gray, leftMargin, bottomMargin + 10)
        e.HasMorePages = (startRow + rowsPrinted < printData.Rows.Count)
        If Not e.HasMorePages Then currentPage = 0
    End Sub

    ' ── Event Handlers ───────────────────────────────────────────
    Private Sub ButtonFilter_Click(sender As Object, e As EventArgs) Handles ButtonFilter.Click
        LoadNilai()
    End Sub

    Private Sub ButtonRefresh_Click(sender As Object, e As EventArgs) Handles ButtonRefresh.Click
        ComboBoxMatkul.SelectedIndex = 0
        ComboBoxSemester.SelectedIndex = 0
        TextBoxCari.Text = ""
        LoadNilai()
    End Sub

    Private Sub ButtonPrint_Click(sender As Object, e As EventArgs) Handles ButtonPrint.Click
        If DataGridViewNilai.Rows.Count = 0 Then
            MessageBox.Show("Tidak ada data untuk dicetak!", "Informasi",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        Try
            PrintPreviewDialog1.WindowState = FormWindowState.Maximized
            PrintPreviewDialog1.ShowDialog()
        Catch ex As Exception
            MessageBox.Show("Error saat preview: " & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ButtonClose_Click(sender As Object, e As EventArgs) Handles ButtonClose.Click
        Me.Close()
    End Sub

    Private Sub TextBoxCari_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxCari.KeyDown
        If e.KeyCode = Keys.Enter Then LoadNilai()
    End Sub

End Class
