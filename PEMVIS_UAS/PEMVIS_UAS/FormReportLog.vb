Imports System.Data
Imports System.Drawing.Printing
Imports MySqlConnector

Public Class FormReportLog

    Private conn As MySqlConnection
    Private dtLog As DataTable
    Private printData As DataTable
    Private currentPage As Integer = 0
    Private rowsPerPage As Integer = 30

    Public Sub New()
        InitializeComponent()
        InitializeForm()
    End Sub

    Private Sub InitializeForm()
        SetupDataGridView()
        LoadTahun()
        SetupFilterDate()
        LoadLog()
        PrintDocument1.DocumentName = "Report Log Aktivitas"
        PrintPreviewDialog1.Document = PrintDocument1
    End Sub

    Private Sub SetupDataGridView()
        DataGridViewLog.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 9.5, FontStyle.Bold)
        DataGridViewLog.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(102, 187, 187)
        DataGridViewLog.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        DataGridViewLog.EnableHeadersVisualStyles = False
        DataGridViewLog.DefaultCellStyle.Font = New Font("Segoe UI", 9.0, FontStyle.Regular)
        DataGridViewLog.DefaultCellStyle.ForeColor = Color.FromArgb(74, 144, 144)
        DataGridViewLog.DefaultCellStyle.SelectionBackColor = Color.FromArgb(220, 240, 240)
        DataGridViewLog.RowTemplate.Height = 33
        DataGridViewLog.AllowUserToAddRows = False
        DataGridViewLog.AllowUserToDeleteRows = False
        DataGridViewLog.ReadOnly = True
        DataGridViewLog.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DataGridViewLog.MultiSelect = False
        DataGridViewLog.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
        DataGridViewLog.BackgroundColor = Color.White
        DataGridViewLog.BorderStyle = BorderStyle.None
        DataGridViewLog.GridColor = Color.FromArgb(220, 240, 240)
        DataGridViewLog.RowHeadersVisible = False

        DataGridViewLog.Columns.Clear()
        DataGridViewLog.Columns.Add("ColNo", "No")
        DataGridViewLog.Columns.Add("ColTanggal", "Tanggal & Waktu")
        DataGridViewLog.Columns.Add("ColAktivitas", "Aktivitas")
        DataGridViewLog.Columns.Add("ColNIM", "ID Admin")
        DataGridViewLog.Columns.Add("ColNama", "Nama Admin")
        DataGridViewLog.Columns.Add("ColIP", "IP Address")
        DataGridViewLog.Columns.Add("ColKeterangan", "Keterangan")

        DataGridViewLog.Columns("ColNo").Width = 50
        DataGridViewLog.Columns("ColNo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewLog.Columns("ColTanggal").Width = 160
        DataGridViewLog.Columns("ColAktivitas").Width = 140
        DataGridViewLog.Columns("ColNIM").Width = 110
        DataGridViewLog.Columns("ColNama").Width = 180
        DataGridViewLog.Columns("ColIP").Width = 120
        DataGridViewLog.Columns("ColKeterangan").Width = 290

        AddHandler DataGridViewLog.CellFormatting, AddressOf DataGridViewLog_CellFormatting
    End Sub

    Private Sub DataGridViewLog_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs)
        If DataGridViewLog.Columns(e.ColumnIndex).Name = "ColAktivitas" AndAlso e.Value IsNot Nothing Then
            Dim a As String = e.Value.ToString().ToLower()
            If a.Contains("login") Then
                e.CellStyle.BackColor = Color.FromArgb(200, 240, 200)
                e.CellStyle.Font = New Font("Segoe UI", 9.0, FontStyle.Bold)
            ElseIf a.Contains("logout") Then
                e.CellStyle.BackColor = Color.FromArgb(240, 220, 200)
                e.CellStyle.Font = New Font("Segoe UI", 9.0, FontStyle.Bold)
            ElseIf a.Contains("tambah") OrElse a.Contains("add") Then
                e.CellStyle.BackColor = Color.FromArgb(200, 230, 255)
            ElseIf a.Contains("ubah") OrElse a.Contains("edit") Then
                e.CellStyle.BackColor = Color.FromArgb(255, 240, 200)
            ElseIf a.Contains("hapus") OrElse a.Contains("delete") Then
                e.CellStyle.BackColor = Color.FromArgb(255, 220, 220)
            End If
        End If
    End Sub

    Private Sub SetupFilterDate()
        DateTimePickerDari.Value = DateTime.Now.AddDays(-30)
        DateTimePickerSampai.Value = DateTime.Now
        ComboBoxBulan.SelectedIndex = 0
        ComboBoxTahun.SelectedIndex = 0
        ComboBoxAktivitas.SelectedIndex = 0
    End Sub

    Private Sub LoadTahun()
        ComboBoxTahun.Items.Clear()
        ComboBoxTahun.Items.Add("Semua Tahun")
        Dim tahun As Integer = DateTime.Now.Year
        For i As Integer = tahun To tahun - 5 Step -1
            ComboBoxTahun.Items.Add(i.ToString())
        Next
        ComboBoxTahun.SelectedIndex = 0
    End Sub

    Private Sub LoadLog()
        Try
            conn = New MySqlConnection(ConnectionModule.ConnectionString)
            conn.Open()

            Dim query As String =
                "SELECT l.*, a.namaAdmin FROM log l " &
                "LEFT JOIN admin a ON l.nimAdmin = a.nimAdmin WHERE 1=1"

            ' Date filter
            query &= " AND DATE(l.tanggalJam) BETWEEN @dari AND @sampai"

            ' Month filter
            If ComboBoxBulan.SelectedIndex > 0 Then
                query &= " AND MONTH(l.tanggalJam) = @bulan"
            End If

            ' Year filter
            If ComboBoxTahun.SelectedIndex > 0 Then
                query &= " AND YEAR(l.tanggalJam) = @tahun"
            End If

            ' Aktivitas filter
            If ComboBoxAktivitas.SelectedIndex > 0 Then
                query &= " AND LOWER(l.aktifitas) LIKE @akt"
            End If

            query &= " ORDER BY l.tanggalJam DESC"

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@dari", DateTimePickerDari.Value.ToString("yyyy-MM-dd"))
                cmd.Parameters.AddWithValue("@sampai", DateTimePickerSampai.Value.ToString("yyyy-MM-dd"))

                If ComboBoxBulan.SelectedIndex > 0 Then
                    cmd.Parameters.AddWithValue("@bulan", ComboBoxBulan.SelectedIndex)
                End If
                If ComboBoxTahun.SelectedIndex > 0 Then
                    cmd.Parameters.AddWithValue("@tahun", ComboBoxTahun.SelectedItem.ToString())
                End If
                If ComboBoxAktivitas.SelectedIndex > 0 Then
                    Dim akt As String = ComboBoxAktivitas.SelectedItem.ToString().ToLower()
                    cmd.Parameters.AddWithValue("@akt", "%" & akt & "%")
                End If

                Dim adapter As New MySqlDataAdapter(cmd)
                dtLog = New DataTable()
                adapter.Fill(dtLog)
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
        DataGridViewLog.Rows.Clear()
        If dtLog IsNot Nothing AndAlso dtLog.Rows.Count > 0 Then
            Dim no As Integer = 1
            For Each row As DataRow In dtLog.Rows
                DataGridViewLog.Rows.Add(
                    no,
                    Convert.ToDateTime(row("tanggalJam")).ToString("dd MMM yyyy HH:mm:ss"),
                    row("aktifitas"),
                    row("nimAdmin"),
                    If(IsDBNull(row("namaAdmin")), "-", row("namaAdmin")),
                    If(IsDBNull(row("ipAddress")), "-", row("ipAddress")),
                    If(IsDBNull(row("keterangan")), "-", row("keterangan")))
                no += 1
            Next
        End If
        LabelTotalRecord.Text = "Total Record: " & DataGridViewLog.Rows.Count & " data"
    End Sub

    ' ── Print ────────────────────────────────────────────────────
    Private Sub PrintDocument1_BeginPrint(sender As Object, e As PrintEventArgs) Handles PrintDocument1.BeginPrint
        printData = New DataTable()
        For Each col As String In {"No", "Tanggal & Waktu", "Aktivitas", "ID Admin",
                                   "Nama Admin", "IP Address", "Keterangan"}
            printData.Columns.Add(col)
        Next
        For Each row As DataGridViewRow In DataGridViewLog.Rows
            If Not row.IsNewRow Then
                printData.Rows.Add(
                    row.Cells("ColNo").Value, row.Cells("ColTanggal").Value,
                    row.Cells("ColAktivitas").Value, row.Cells("ColNIM").Value,
                    row.Cells("ColNama").Value, row.Cells("ColIP").Value,
                    row.Cells("ColKeterangan").Value)
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

        Dim leftMargin As Single = e.MarginBounds.Left
        Dim topMargin As Single = e.MarginBounds.Top
        Dim rightMargin As Single = e.MarginBounds.Right
        Dim bottomMargin As Single = e.MarginBounds.Bottom
        Dim yPos As Single = topMargin

        Dim titleText As String = "REPORT LOG AKTIVITAS SISTEM - PROGRAM STUDI XYZ"
        Dim ts As SizeF = e.Graphics.MeasureString(titleText, titleFont)
        e.Graphics.DrawString(titleText, titleFont, New SolidBrush(titleColor),
                             leftMargin + (e.MarginBounds.Width - ts.Width) / 2, yPos)
        yPos += ts.Height + 4

        Dim subFont As New Font("Segoe UI", 9, FontStyle.Regular)
        Dim sub1 As String = "Dicetak pada: " & DateTime.Now.ToString("dd MMMM yyyy HH:mm:ss")
        Dim s1 As SizeF = e.Graphics.MeasureString(sub1, subFont)
        e.Graphics.DrawString(sub1, subFont, Brushes.Gray,
                             leftMargin + (e.MarginBounds.Width - s1.Width) / 2, yPos)
        yPos += s1.Height + 4

        Dim filterInfo As String = "Periode: " & DateTimePickerDari.Value.ToString("dd MMM yyyy") &
                                  " s/d " & DateTimePickerSampai.Value.ToString("dd MMM yyyy")
        Dim fi As SizeF = e.Graphics.MeasureString(filterInfo, subFont)
        e.Graphics.DrawString(filterInfo, subFont, Brushes.Gray,
                             leftMargin + (e.MarginBounds.Width - fi.Width) / 2, yPos)
        yPos += fi.Height + 12
        e.Graphics.DrawLine(New Pen(headerColor, 2), leftMargin, yPos, rightMargin, yPos)
        yPos += 10

        Dim colWidths As Single() = {40, 130, 100, 80, 130, 100, 170}
        Dim totalWidth As Single = colWidths.Sum()
        Dim startX As Single = leftMargin + (e.MarginBounds.Width - totalWidth) / 2
        Dim headerHeight As Single = 24
        e.Graphics.FillRectangle(New SolidBrush(headerColor), startX, yPos, totalWidth, headerHeight)

        Dim headers As String() = {"No", "Tanggal & Waktu", "Aktivitas", "ID Admin",
                                   "Nama Admin", "IP Address", "Keterangan"}
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
                Dim align As StringAlignment = If(i = 0, StringAlignment.Center, StringAlignment.Near)
                e.Graphics.DrawString(row(i).ToString(), contentFont, Brushes.Black, cR,
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
        LoadLog()
    End Sub

    Private Sub ButtonRefresh_Click(sender As Object, e As EventArgs) Handles ButtonRefresh.Click
        SetupFilterDate()
        LoadLog()
    End Sub

    Private Sub ButtonPrint_Click(sender As Object, e As EventArgs) Handles ButtonPrint.Click
        If DataGridViewLog.Rows.Count = 0 Then
            MessageBox.Show("Tidak ada data untuk dicetak!", "Informasi",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        Try
            PrintPreviewDialog1.WindowState = FormWindowState.Maximized
            PrintPreviewDialog1.ShowDialog()
        Catch ex As Exception
            MessageBox.Show("Error preview: " & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ButtonClose_Click(sender As Object, e As EventArgs) Handles ButtonClose.Click
        Me.Close()
    End Sub

End Class
