Imports System.Data
Imports System.Drawing.Printing
Imports MySql.Data.MySqlClient
Imports MySqlConnector

Public Class FormLogAktivitas

    'Koneksi Database (Shared agar bisa diakses dari method Shared)
    Private Shared connectionString As String = "Server=localhost;Database=db_nilai_xyz;Uid=root;Pwd=;"
    Private conn As MySqlConnection

    'DataTable untuk menyimpan data
    Private dtLog As DataTable

    'Variabel untuk printing
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
        LoadLogAktivitas()

        'Setup PrintDialog
        PrintDocument1.DocumentName = "Log Aktivitas Sistem"
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

        DataGridViewLog.RowTemplate.Height = 35
        DataGridViewLog.AllowUserToAddRows = False
        DataGridViewLog.AllowUserToDeleteRows = False
        DataGridViewLog.ReadOnly = True
        DataGridViewLog.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DataGridViewLog.MultiSelect = False

        ' DIUBAH: Menjadi None agar lebar kolom bisa diatur manual dan tidak melebar paksa
        DataGridViewLog.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
        DataGridViewLog.BackgroundColor = Color.White
        DataGridViewLog.BorderStyle = BorderStyle.None
        DataGridViewLog.GridColor = Color.FromArgb(220, 240, 240)

        'Tambah kolom
        DataGridViewLog.Columns.Clear()
        DataGridViewLog.Columns.Add("No", "No")
        DataGridViewLog.Columns.Add("TanggalJam", "Tanggal & Waktu")
        DataGridViewLog.Columns.Add("Aktifitas", "Aktivitas")
        DataGridViewLog.Columns.Add("ID Admin", "ID Admin") ' DIPERBAIKI: Sebelumnya "ID Admin"
        DataGridViewLog.Columns.Add("Nama Admin", "Nama Admin")
        DataGridViewLog.Columns.Add("IP Address", "IP Address")
        DataGridViewLog.Columns.Add("Keterangan", "Keterangan")

        ' DIUBAH: Lebar kolom dikecilkan agar proporsional dengan form
        DataGridViewLog.Columns("No").Width = 50
        DataGridViewLog.Columns("No").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewLog.Columns("TanggalJam").Width = 160
        DataGridViewLog.Columns("Aktifitas").Width = 140
        DataGridViewLog.Columns("ID Admin").Width = 120
        DataGridViewLog.Columns("Nama Admin").Width = 180
        DataGridViewLog.Columns("IP Address").Width = 130
        DataGridViewLog.Columns("Keterangan").Width = 240

        AddHandler DataGridViewLog.CellFormatting, AddressOf DataGridViewLog_CellFormatting
    End Sub

    Private Sub DataGridViewLog_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs)
        If DataGridViewLog.Columns(e.ColumnIndex).Name = "Aktifitas" AndAlso e.Value IsNot Nothing Then
            Dim aktivitas As String = e.Value.ToString().ToLower()

            If aktivitas.Contains("login") Then
                e.CellStyle.BackColor = Color.FromArgb(200, 240, 200)
                e.CellStyle.Font = New Font("Segoe UI", 9.0, FontStyle.Bold)
            ElseIf aktivitas.Contains("logout") Then
                e.CellStyle.BackColor = Color.FromArgb(240, 220, 200)
                e.CellStyle.Font = New Font("Segoe UI", 9.0, FontStyle.Bold)
            ElseIf aktivitas.Contains("tambah") Or aktivitas.Contains("add") Then
                e.CellStyle.BackColor = Color.FromArgb(200, 230, 255)
            ElseIf aktivitas.Contains("ubah") Or aktivitas.Contains("edit") Then
                e.CellStyle.BackColor = Color.FromArgb(255, 240, 200)
            ElseIf aktivitas.Contains("hapus") Or aktivitas.Contains("delete") Then
                e.CellStyle.BackColor = Color.FromArgb(255, 220, 220)
            End If
        End If
    End Sub

    Private Sub SetupFilterDate()
        DateTimePickerDari.Value = DateTime.Now.AddDays(-30)
        DateTimePickerSampai.Value = DateTime.Now
        DateTimePickerDari.MaxDate = DateTime.Now
        DateTimePickerSampai.MaxDate = DateTime.Now
        ComboBoxBulan.SelectedIndex = 0
        LoadTahun()
    End Sub

    Private Sub LoadTahun()
        ComboBoxTahun.Items.Clear()
        ComboBoxTahun.Items.Add("Semua Tahun")

        Dim tahunSekarang As Integer = DateTime.Now.Year
        For i As Integer = tahunSekarang To tahunSekarang - 5 Step -1
            ComboBoxTahun.Items.Add(i.ToString())
        Next

        ComboBoxTahun.SelectedIndex = 0
    End Sub

    Private Sub LoadLogAktivitas()
        Try
            conn = New MySqlConnection(connectionString)
            conn.Open()

            Dim query As String = "SELECT l.*, a.namaAdmin " &
                                 "FROM log l " &
                                 "LEFT JOIN admin a ON l.nimAdmin = a.nimAdmin " &
                                 "ORDER BY l.tanggalJam DESC"

            Dim adapter As New MySqlDataAdapter(query, conn)
            dtLog = New DataTable()
            adapter.Fill(dtLog)

            DisplayData()
            conn.Close()

        Catch ex As Exception
            MessageBox.Show("Error loading data: " & ex.Message, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
    End Sub

    Private Sub DisplayData()
        DataGridViewLog.Rows.Clear()

        If dtLog IsNot Nothing AndAlso dtLog.Rows.Count > 0 Then
            Dim no As Integer = 1
            For Each row As DataRow In dtLog.Rows
                DataGridViewLog.Rows.Add(
                    no,
                    FormatDateTime(row("tanggalJam")),
                    row("aktifitas"),
                    row("nimAdmin"),
                    If(IsDBNull(row("namaAdmin")), "-", row("namaAdmin")),
                    If(IsDBNull(row("ipAddress")), "-", row("ipAddress")),
                    If(IsDBNull(row("keterangan")), "-", row("keterangan"))
                )
                no += 1
            Next
        End If

        LabelTotalRecord.Text = "Total Record: " & DataGridViewLog.Rows.Count & " data"
    End Sub

    Private Sub FilterData()
        Try
            conn = New MySqlConnection(connectionString)
            conn.Open()

            Dim query As String = "SELECT l.*, a.namaAdmin " &
                                 "FROM log l " &
                                 "LEFT JOIN admin a ON l.nimAdmin = a.nimAdmin " &
                                 "WHERE 1=1"

            'Filter tanggal
            If DateTimePickerDari.Value >= DateTimePickerDari.MinDate AndAlso
               DateTimePickerSampai.Value >= DateTimePickerSampai.MinDate Then
                query &= " AND DATE(l.tanggalJam) BETWEEN '" &
                        DateTimePickerDari.Value.ToString("yyyy-MM-dd") &
                        "' AND '" &
                        DateTimePickerSampai.Value.ToString("yyyy-MM-dd") & "'"
            End If

            'Filter bulan
            If ComboBoxBulan.SelectedIndex > 0 Then
                Dim bulan As Integer = ComboBoxBulan.SelectedIndex
                query &= " AND MONTH(l.tanggalJam) = " & bulan
            End If

            'Filter tahun
            If ComboBoxTahun.SelectedIndex > 0 Then
                Dim tahun As String = ComboBoxTahun.SelectedItem.ToString()
                query &= " AND YEAR(l.tanggalJam) = " & tahun
            End If

            query &= " ORDER BY l.tanggalJam DESC"

            Dim adapter As New MySqlDataAdapter(query, conn)
            dtLog = New DataTable()
            adapter.Fill(dtLog)

            DisplayData()
            conn.Close()

        Catch ex As Exception
            MessageBox.Show("Error filtering data: " & ex.Message, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
    End Sub

    Private Function FormatDateTime(obj As Object) As String
        If IsDBNull(obj) Then Return "-"
        Dim dt As DateTime = Convert.ToDateTime(obj)
        Return dt.ToString("dd MMM yyyy HH:mm:ss")
    End Function

    '==============================================
    'FITUR PRINT MENGGUNAKAN PRINTDOCUMENT
    '==============================================

    Private Sub PrintDocument1_BeginPrint(sender As Object, e As PrintEventArgs)
        'Siapkan data untuk printing
        printData = New DataTable()
        printData.Columns.Add("No", GetType(String))
        printData.Columns.Add("Tanggal & Waktu", GetType(String))
        printData.Columns.Add("Aktivitas", GetType(String))
        printData.Columns.Add("NIM Admin", GetType(String))
        printData.Columns.Add("Nama Admin", GetType(String))
        printData.Columns.Add("IP Address", GetType(String))
        printData.Columns.Add("Keterangan", GetType(String))

        'Copy data dari DataGridView
        For Each row As DataGridViewRow In DataGridViewLog.Rows
            If Not row.IsNewRow Then
                printData.Rows.Add(
                    row.Cells("No").Value.ToString(),
                    row.Cells("TanggalJam").Value.ToString(),
                    row.Cells("Aktifitas").Value.ToString(),
                    row.Cells("NIM Admin").Value.ToString(),
                    row.Cells("Nama Admin").Value.ToString(),
                    row.Cells("IP Address").Value.ToString(),
                    row.Cells("Keterangan").Value.ToString()
                )
            End If
        Next

        currentPage = 0
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As PrintPageEventArgs)
        'Setup font
        Dim titleFont As New Font("Segoe UI", 16, FontStyle.Bold)
        Dim headerFont As New Font("Segoe UI", 10, FontStyle.Bold)
        Dim contentFont As New Font("Segoe UI", 9, FontStyle.Regular)
        Dim footerFont As New Font("Segoe UI", 8, FontStyle.Italic)

        'Setup warna
        Dim headerColor As Color = Color.FromArgb(102, 187, 187)
        Dim titleColor As Color = Color.FromArgb(74, 144, 144)
        Dim textColor As Color = Color.FromArgb(50, 50, 50)

        'Margin
        Dim leftMargin As Single = e.MarginBounds.Left
        Dim topMargin As Single = e.MarginBounds.Top
        Dim rightMargin As Single = e.MarginBounds.Right
        Dim bottomMargin As Single = e.MarginBounds.Bottom

        '==============================================
        'HEADER - Judul Laporan
        '==============================================
        Dim yPos As Single = topMargin
        Dim titleText As String = "LOG AKTIVITAS SISTEM"
        Dim titleSize As SizeF = e.Graphics.MeasureString(titleText, titleFont)

        e.Graphics.DrawString(titleText, titleFont, New SolidBrush(titleColor),
                             leftMargin + (e.MarginBounds.Width - titleSize.Width) / 2, yPos)
        yPos += titleSize.Height + 5

        'Sub-title dengan tanggal print
        Dim subTitle As String = "Dicetak pada: " & DateTime.Now.ToString("dd MMMM yyyy HH:mm:ss")
        Dim subTitleFont As New Font("Segoe UI", 9, FontStyle.Regular)
        Dim subTitleSize As SizeF = e.Graphics.MeasureString(subTitle, subTitleFont)
        e.Graphics.DrawString(subTitle, subTitleFont, New SolidBrush(Color.Gray),
                             leftMargin + (e.MarginBounds.Width - subTitleSize.Width) / 2, yPos)
        yPos += subTitleSize.Height + 5

        'Filter info
        Dim filterInfo As String = "Periode: " &
                                  DateTimePickerDari.Value.ToString("dd MMM yyyy") &
                                  " s/d " &
                                  DateTimePickerSampai.Value.ToString("dd MMM yyyy")
        If ComboBoxBulan.SelectedIndex > 0 Then
            filterInfo &= " | Bulan: " & ComboBoxBulan.SelectedItem.ToString()
        End If
        If ComboBoxTahun.SelectedIndex > 0 Then
            filterInfo &= " | Tahun: " & ComboBoxTahun.SelectedItem.ToString()
        End If

        Dim filterFont As New Font("Segoe UI", 8, FontStyle.Regular)
        Dim filterSize As SizeF = e.Graphics.MeasureString(filterInfo, filterFont)
        e.Graphics.DrawString(filterInfo, filterFont, New SolidBrush(Color.Gray),
                             leftMargin + (e.MarginBounds.Width - filterSize.Width) / 2, yPos)
        yPos += filterSize.Height + 15

        '==============================================
        'GARIS PEMISAH
        '==============================================
        e.Graphics.DrawLine(New Pen(headerColor, 2), leftMargin, yPos, rightMargin, yPos)
        yPos += 10

        '==============================================
        'KOLOM HEADER TABEL
        '==============================================
        'Definisi lebar kolom (total harus <= lebar halaman)
        Dim colWidths As Single() = {40, 140, 100, 80, 130, 100, 160}
        Dim totalWidth As Single = colWidths.Sum()
        Dim startX As Single = leftMargin + (e.MarginBounds.Width - totalWidth) / 2

        'Background header
        Dim headerHeight As Single = 25
        Dim headerRect As New RectangleF(startX, yPos, totalWidth, headerHeight)
        e.Graphics.FillRectangle(New SolidBrush(headerColor), headerRect)

        'Teks header
        Dim headers As String() = {"No", "Tanggal & Waktu", "Aktivitas", "NIM Admin",
                                   "Nama Admin", "IP Address", "Keterangan"}

        Dim colX As Single = startX
        For i As Integer = 0 To headers.Length - 1
            Dim headerRect2 As New RectangleF(colX, yPos, colWidths(i), headerHeight)
            e.Graphics.DrawString(headers(i), headerFont, New SolidBrush(Color.White),
                                 headerRect2, New StringFormat With {
                                     .Alignment = StringAlignment.Center,
                                     .LineAlignment = StringAlignment.Center
                                 })
            colX += colWidths(i)
        Next

        yPos += headerHeight

        'Border header
        e.Graphics.DrawRectangle(New Pen(headerColor, 1), startX, yPos - headerHeight, totalWidth, headerHeight)

        '==============================================
        'DATA ROWS
        '==============================================
        Dim rowHeight As Single = 22
        Dim rowsPrinted As Integer = 0
        Dim startRow As Integer = currentPage * rowsPerPage

        While startRow + rowsPrinted < printData.Rows.Count AndAlso
              yPos + rowHeight <= bottomMargin

            Dim rowIndex As Integer = startRow + rowsPrinted
            Dim row As DataRow = printData.Rows(rowIndex)

            'Warna baris bergantian
            Dim rowColor As Color = If(rowsPrinted Mod 2 = 0, Color.White,
                                      Color.FromArgb(240, 248, 248))
            e.Graphics.FillRectangle(New SolidBrush(rowColor),
                                    startX, yPos, totalWidth, rowHeight)

            'Tulis data per kolom
            colX = startX
            For i As Integer = 0 To row.ItemArray.Length - 1
                Dim cellText As String = row(i).ToString()
                Dim cellRect As New RectangleF(colX, yPos, colWidths(i), rowHeight)

                'Warna teks berbeda untuk kolom Aktivitas
                Dim cellFont As Font = contentFont
                Dim cellColor As Color = textColor

                If i = 2 Then 'Kolom Aktivitas
                    Dim aktivitas As String = cellText.ToLower()
                    If aktivitas.Contains("login") Then
                        cellColor = Color.FromArgb(34, 139, 34)
                        cellFont = New Font("Segoe UI", 9, FontStyle.Bold)
                    ElseIf aktivitas.Contains("logout") Then
                        cellColor = Color.FromArgb(178, 102, 34)
                        cellFont = New Font("Segoe UI", 9, FontStyle.Bold)
                    ElseIf aktivitas.Contains("hapus") Then
                        cellColor = Color.FromArgb(178, 34, 34)
                        cellFont = New Font("Segoe UI", 9, FontStyle.Bold)
                    End If
                End If

                Dim align As StringAlignment = If(i = 0, StringAlignment.Center, StringAlignment.Near)
                e.Graphics.DrawString(cellText, cellFont, New SolidBrush(cellColor),
                                     cellRect, New StringFormat With {
                                         .Alignment = align,
                                         .LineAlignment = StringAlignment.Center,
                                         .Trimming = StringTrimming.EllipsisCharacter
                                     })
                colX += colWidths(i)
            Next

            'Border row
            e.Graphics.DrawRectangle(New Pen(Color.LightGray, 0.5), startX, yPos, totalWidth, rowHeight)

            yPos += rowHeight
            rowsPrinted += 1
        End While

        '==============================================
        'FOOTER - Halaman
        '==============================================
        Dim totalPages As Integer = CInt(Math.Ceiling(printData.Rows.Count / rowsPerPage))
        currentPage += 1

        Dim footerText As String = "Halaman " & currentPage & " dari " & totalPages &
                                  " | Total: " & printData.Rows.Count & " data"
        Dim footerSize As SizeF = e.Graphics.MeasureString(footerText, footerFont)
        e.Graphics.DrawString(footerText, footerFont, New SolidBrush(Color.Gray),
                             leftMargin + (e.MarginBounds.Width - footerSize.Width) / 2,
                             bottomMargin + 10)

        'Cek apakah ada halaman berikutnya
        If startRow + rowsPrinted < printData.Rows.Count Then
            e.HasMorePages = True
        Else
            e.HasMorePages = False
            currentPage = 0
        End If
    End Sub

    Private Sub ButtonPrint_Click(sender As Object, e As EventArgs) Handles ButtonPrint.Click
        If DataGridViewLog.Rows.Count = 0 Then
            MessageBox.Show("Tidak ada data untuk dicetak!", "Informasi",
                          MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        'Tampilkan Print Preview dulu
        Try
            PrintPreviewDialog1.WindowState = FormWindowState.Maximized
            PrintPreviewDialog1.ShowDialog()
        Catch ex As Exception
            MessageBox.Show("Error saat preview: " & ex.Message, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '==============================================
    'FITUR LOG AKTIVITAS (SHARED)
    '==============================================

    Public Shared Sub CatatLog(nimAdmin As String, aktivitas As String,
                              Optional keterangan As String = "",
                              Optional ipAddress As String = "")
        Try
            Dim conn As New MySqlConnection(connectionString)
            conn.Open()

            Dim query As String = "INSERT INTO log (tanggalJam, aktifitas, nimAdmin, ipAddress, keterangan) " &
                                 "VALUES (NOW(), @aktivitas, @nimAdmin, @ipAddress, @keterangan)"

            Dim cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@aktivitas", aktivitas)
            cmd.Parameters.AddWithValue("@nimAdmin", nimAdmin)
            cmd.Parameters.AddWithValue("@ipAddress", If(ipAddress = "", GetLocalIPAddress(), ipAddress))
            cmd.Parameters.AddWithValue("@keterangan", keterangan)

            cmd.ExecuteNonQuery()
            conn.Close()

        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("Error mencatat log: " & ex.Message)
        End Try
    End Sub

    Private Shared Function GetLocalIPAddress() As String
        Dim host As String = System.Net.Dns.GetHostName()
        Dim ipaddresses() As System.Net.IPAddress = System.Net.Dns.GetHostEntry(host).AddressList

        For Each ip As System.Net.IPAddress In ipaddresses
            If ip.AddressFamily = System.Net.Sockets.AddressFamily.InterNetwork Then
                Return ip.ToString()
            End If
        Next

        Return "127.0.0.1"
    End Function

    'Event Handlers
    Private Sub ButtonFilter_Click(sender As Object, e As EventArgs) Handles ButtonFilter.Click
        FilterData()
    End Sub

    Private Sub ButtonRefresh_Click(sender As Object, e As EventArgs) Handles ButtonRefresh.Click
        SetupFilterDate()
        LoadLogAktivitas()
    End Sub

    Private Sub ButtonClose_Click(sender As Object, e As EventArgs) Handles ButtonClose.Click
        Me.Close()
    End Sub

    Private Sub DataGridViewLog_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewLog.CellDoubleClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = DataGridViewLog.Rows(e.RowIndex)
            Dim detail As String = "Detail Log Aktivitas" & vbCrLf & vbCrLf &
                                  "Tanggal: " & row.Cells("TanggalJam").Value & vbCrLf &
                                  "Aktivitas: " & row.Cells("Aktifitas").Value & vbCrLf &
                                  "NIM Admin: " & row.Cells("NIM Admin").Value & vbCrLf &
                                  "Nama Admin: " & row.Cells("Nama Admin").Value & vbCrLf &
                                  "IP Address: " & row.Cells("IP Address").Value & vbCrLf &
                                  "Keterangan: " & row.Cells("Keterangan").Value

            MessageBox.Show(detail, "Detail Log", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

End Class