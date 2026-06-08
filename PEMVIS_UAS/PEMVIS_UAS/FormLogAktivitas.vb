Imports System.Data
Imports System.Drawing.Printing
Imports MySqlConnector

Public Class FormLogAktivitas

    Private dtLog As DataTable
    Private printData As DataTable
    Private currentPage As Integer = 0
    Private ReadOnly rowsPerPage As Integer = 30

    Public Sub New()
        InitializeComponent()
        InitializeForm()
    End Sub

    Private Sub InitializeForm()
        SetupDataGridView()
        LoadTahun()
        SetupFilterDate()   ' does NOT call LoadTahun() again
        LoadLogAktivitas()
    End Sub

    ' ── DataGridView setup ───────────────────────────────────────
    Private Sub SetupDataGridView()
        DataGridViewLog.RowTemplate.Height = 35
        DataGridViewLog.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None

        DataGridViewLog.Columns.Clear()
        DataGridViewLog.Columns.Add("No", "No")
        DataGridViewLog.Columns.Add("TanggalJam", "Tanggal & Waktu")
        DataGridViewLog.Columns.Add("Aktifitas", "Aktivitas")
        DataGridViewLog.Columns.Add("ID Admin", "ID Admin")
        DataGridViewLog.Columns.Add("Nama Admin", "Nama Admin")
        DataGridViewLog.Columns.Add("IP Address", "IP Address")
        DataGridViewLog.Columns.Add("Keterangan", "Keterangan")

        DataGridViewLog.Columns("No").Width = 50
        DataGridViewLog.Columns("No").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewLog.Columns("TanggalJam").Width = 160
        DataGridViewLog.Columns("Aktifitas").Width = 150
        DataGridViewLog.Columns("ID Admin").Width = 110
        DataGridViewLog.Columns("Nama Admin").Width = 170
        DataGridViewLog.Columns("IP Address").Width = 120
        DataGridViewLog.Columns("Keterangan").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        AddHandler DataGridViewLog.CellFormatting, AddressOf DataGridViewLog_CellFormatting
    End Sub

    Private Sub DataGridViewLog_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs)
        If e.RowIndex < 0 OrElse e.Value Is Nothing Then Return
        If DataGridViewLog.Columns(e.ColumnIndex).Name <> "Aktifitas" Then Return

        Dim aktivitas As String = e.Value.ToString().ToLower()
        If aktivitas.Contains("login") Then
            e.CellStyle.BackColor = Color.FromArgb(200, 240, 200)
            e.CellStyle.Font = New Font("Segoe UI", 9.0, FontStyle.Bold)
        ElseIf aktivitas.Contains("logout") Then
            e.CellStyle.BackColor = Color.FromArgb(240, 220, 200)
            e.CellStyle.Font = New Font("Segoe UI", 9.0, FontStyle.Bold)
        ElseIf aktivitas.Contains("tambah") OrElse aktivitas.Contains("add") Then
            e.CellStyle.BackColor = Color.FromArgb(200, 230, 255)
        ElseIf aktivitas.Contains("ubah") OrElse aktivitas.Contains("edit") Then
            e.CellStyle.BackColor = Color.FromArgb(255, 240, 200)
        ElseIf aktivitas.Contains("hapus") OrElse aktivitas.Contains("delete") Then
            e.CellStyle.BackColor = Color.FromArgb(255, 220, 220)
        End If
    End Sub

    ' ── Filter / date setup ──────────────────────────────────────
    Private Sub SetupFilterDate()
        ' FIX: do NOT call LoadTahun() here — it's already called in InitializeForm
        DateTimePickerDari.Value = DateTime.Now.AddDays(-30)
        DateTimePickerSampai.Value = DateTime.Now
        DateTimePickerDari.MaxDate = DateTime.Now
        DateTimePickerSampai.MaxDate = DateTime.Now
        ComboBoxBulan.SelectedIndex = 0
        ' ComboBoxTahun default is set by LoadTahun() which runs before this
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

    ' ── DB helpers ───────────────────────────────────────────────
    Private Function GetDataTable(sql As String, ParamArray params() As MySqlParameter) As DataTable
        Dim dt As New DataTable()
        Using conn As New MySqlConnection(ConnectionModule.ConnectionString)
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

    ' ── Load / filter ────────────────────────────────────────────
    Private Sub LoadLogAktivitas()
        Try
            ' FIX: ipAddress may not be a column in all schemas → handled by IsDBNull in DisplayData
            Dim sql As String =
                "SELECT l.tanggalJam, l.aktifitas, l.nimAdmin, l.keterangan, " &
                "       COALESCE(l.ipAddress, '') AS ipAddress, " &
                "       COALESCE(a.namaAdmin, '') AS namaAdmin " &
                "FROM log l " &
                "LEFT JOIN admin a ON l.nimAdmin = a.nimAdmin " &
                "ORDER BY l.tanggalJam DESC"
            dtLog = GetDataTable(sql)
            DisplayData()
        Catch ex As Exception
            MessageBox.Show("Error memuat data: " & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FilterData()
        Try
            Dim sql As String =
                "SELECT l.tanggalJam, l.aktifitas, l.nimAdmin, l.keterangan, " &
                "       COALESCE(l.ipAddress, '') AS ipAddress, " &
                "       COALESCE(a.namaAdmin, '') AS namaAdmin " &
                "FROM log l " &
                "LEFT JOIN admin a ON l.nimAdmin = a.nimAdmin " &
                "WHERE DATE(l.tanggalJam) BETWEEN @dari AND @sampai"

            If ComboBoxBulan.SelectedIndex > 0 Then
                sql &= " AND MONTH(l.tanggalJam) = @bulan"
            End If
            If ComboBoxTahun.SelectedIndex > 0 Then
                sql &= " AND YEAR(l.tanggalJam) = @tahun"
            End If
            If Not String.IsNullOrWhiteSpace(TextBoxCari.Text) Then
                sql &= " AND (l.aktifitas LIKE @kw OR l.nimAdmin LIKE @kw " &
                       "     OR a.namaAdmin LIKE @kw OR l.keterangan LIKE @kw)"
            End If
            sql &= " ORDER BY l.tanggalJam DESC"

            Dim paramList As New List(Of MySqlParameter) From {
                Param("@dari", DateTimePickerDari.Value.ToString("yyyy-MM-dd")),
                Param("@sampai", DateTimePickerSampai.Value.ToString("yyyy-MM-dd"))
            }
            If ComboBoxBulan.SelectedIndex > 0 Then
                paramList.Add(Param("@bulan", ComboBoxBulan.SelectedIndex))
            End If
            If ComboBoxTahun.SelectedIndex > 0 Then
                paramList.Add(Param("@tahun", ComboBoxTahun.SelectedItem.ToString()))
            End If
            If Not String.IsNullOrWhiteSpace(TextBoxCari.Text) Then
                paramList.Add(Param("@kw", "%" & TextBoxCari.Text.Trim() & "%"))
            End If

            dtLog = GetDataTable(sql, paramList.ToArray())
            DisplayData()
        Catch ex As Exception
            MessageBox.Show("Error filter data: " & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ── Display ──────────────────────────────────────────────────
    Private Sub DisplayData()
        DataGridViewLog.Rows.Clear()
        If dtLog Is Nothing OrElse dtLog.Rows.Count = 0 Then
            LabelTotalRecord.Text = "Total Record: 0 data"
            Return
        End If

        Dim no As Integer = 1
        For Each row As DataRow In dtLog.Rows
            DataGridViewLog.Rows.Add(
                no,
                FormatTanggalJam(row("tanggalJam")),
                row("aktifitas").ToString(),
                row("nimAdmin").ToString(),
                SafeStr(row("namaAdmin")),
                SafeStr(row("ipAddress")),
                SafeStr(row("keterangan")))
            no += 1
        Next

        LabelTotalRecord.Text = $"Total Record: {DataGridViewLog.Rows.Count} data"
    End Sub

    ' FIX: FormatDateTime is VB6-only → use this helper instead
    Private Function FormatTanggalJam(value As Object) As String
        If IsDBNull(value) OrElse value Is Nothing Then Return "-"
        Try
            Return CDate(value).ToString("dd MMM yyyy  HH:mm:ss")
        Catch
            Return value.ToString()
        End Try
    End Function

    ' FIX: safe null-to-dash conversion for all nullable columns
    Private Function SafeStr(value As Object) As String
        If IsDBNull(value) OrElse value Is Nothing Then Return "-"
        Dim s = value.ToString().Trim()
        Return If(s = "", "-", s)
    End Function

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
                    row.Cells("No").Value,
                    row.Cells("TanggalJam").Value,
                    row.Cells("Aktifitas").Value,
                    row.Cells("ID Admin").Value,
                    row.Cells("Nama Admin").Value,
                    row.Cells("IP Address").Value,
                    row.Cells("Keterangan").Value)
            End If
        Next
        currentPage = 0
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim titleFont As New Font("Segoe UI", 15, FontStyle.Bold)
        Dim headerFont As New Font("Segoe UI", 9, FontStyle.Bold)
        Dim contentFont As New Font("Segoe UI", 8.5, FontStyle.Regular)
        Dim footerFont As New Font("Segoe UI", 8, FontStyle.Italic)
        Dim subFont As New Font("Segoe UI", 9, FontStyle.Regular)
        Dim headerColor As Color = Color.FromArgb(102, 187, 187)
        Dim titleColor As Color = Color.FromArgb(74, 144, 144)
        Dim textColor As Color = Color.FromArgb(50, 50, 50)

        Dim leftMargin As Single = e.MarginBounds.Left
        Dim topMargin As Single = e.MarginBounds.Top
        Dim rightMargin As Single = e.MarginBounds.Right
        Dim bottomMargin As Single = e.MarginBounds.Bottom
        Dim yPos As Single = topMargin

        ' Title
        Dim titleText As String = "LOG AKTIVITAS SISTEM - PROGRAM STUDI XYZ"
        Dim ts As SizeF = e.Graphics.MeasureString(titleText, titleFont)
        e.Graphics.DrawString(titleText, titleFont, New SolidBrush(titleColor),
                              leftMargin + (e.MarginBounds.Width - ts.Width) / 2, yPos)
        yPos += ts.Height + 4

        Dim sub1 As String = "Dicetak pada: " & DateTime.Now.ToString("dd MMMM yyyy HH:mm:ss")
        Dim s1 As SizeF = e.Graphics.MeasureString(sub1, subFont)
        e.Graphics.DrawString(sub1, subFont, Brushes.Gray,
                              leftMargin + (e.MarginBounds.Width - s1.Width) / 2, yPos)
        yPos += s1.Height + 12
        e.Graphics.DrawLine(New Pen(headerColor, 2), leftMargin, yPos, rightMargin, yPos)
        yPos += 10

        ' Column headers
        Dim colWidths As Single() = {40, 130, 110, 80, 130, 100, 160}
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

        ' Rows
        Dim rowHeight As Single = 22
        Dim rowsPrinted As Integer = 0
        Dim startRow As Integer = currentPage * rowsPerPage

        While startRow + rowsPrinted < printData.Rows.Count AndAlso
              yPos + rowHeight <= bottomMargin
            Dim rowIdx As Integer = startRow + rowsPrinted
            Dim row As DataRow = printData.Rows(rowIdx)
            Dim rowBg As Color = If(rowsPrinted Mod 2 = 0, Color.White, Color.FromArgb(240, 248, 248))
            e.Graphics.FillRectangle(New SolidBrush(rowBg), startX, yPos, totalWidth, rowHeight)

            colX = startX
            For i As Integer = 0 To row.ItemArray.Length - 1
                Dim cellRect As New RectangleF(colX + 2, yPos, colWidths(i) - 4, rowHeight)
                Dim align As StringAlignment = If(i = 0, StringAlignment.Center, StringAlignment.Near)
                e.Graphics.DrawString(row(i)?.ToString(), contentFont, New SolidBrush(textColor),
                                      cellRect, New StringFormat With {
                                          .Alignment = align,
                                          .LineAlignment = StringAlignment.Center,
                                          .Trimming = StringTrimming.EllipsisCharacter})
                colX += colWidths(i)
            Next
            e.Graphics.DrawRectangle(Pens.LightGray, startX, yPos, totalWidth, rowHeight)
            yPos += rowHeight
            rowsPrinted += 1
        End While

        ' Footer
        Dim totalPages As Integer = CInt(Math.Ceiling(printData.Rows.Count / rowsPerPage))
        currentPage += 1
        Dim footerText As String = $"Halaman {currentPage} dari {totalPages} | Total: {printData.Rows.Count} data"
        Dim footerSize As SizeF = e.Graphics.MeasureString(footerText, footerFont)
        e.Graphics.DrawString(footerText, footerFont, Brushes.Gray,
                              leftMargin + (e.MarginBounds.Width - footerSize.Width) / 2,
                              bottomMargin + 10)

        e.HasMorePages = (startRow + rowsPrinted < printData.Rows.Count)
        If Not e.HasMorePages Then currentPage = 0
    End Sub

    ' ── Static log helper (called from other forms) ──────────────
    ''' <summary>
    ''' Catat log dari form lain.
    ''' Contoh: FormLogAktivitas.CatatLog(Session.nimAdmin, "TAMBAH DATA", "detail")
    ''' </summary>
    Public Shared Sub CatatLog(nimAdmin As String, aktivitas As String,
                               Optional keterangan As String = "",
                               Optional ipAddress As String = "")
        Try
            If String.IsNullOrEmpty(nimAdmin) Then Return
            Using conn As New MySqlConnection(ConnectionModule.ConnectionString)
                conn.Open()
                Using cek As New MySqlCommand(
                    "SELECT COUNT(*) FROM admin WHERE nimAdmin = @nim", conn)
                    cek.Parameters.AddWithValue("@nim", nimAdmin)
                    If CInt(cek.ExecuteScalar()) = 0 Then Return
                End Using
                Using cmd As New MySqlCommand(
                    "INSERT INTO log (tanggalJam, aktifitas, nimAdmin, ipAddress, keterangan) " &
                    "VALUES (NOW(), @aktivitas, @nimAdmin, @ipAddress, @keterangan)", conn)
                    cmd.Parameters.AddWithValue("@aktivitas", aktivitas)
                    cmd.Parameters.AddWithValue("@nimAdmin", nimAdmin)
                    cmd.Parameters.AddWithValue("@ipAddress",
                        If(String.IsNullOrEmpty(ipAddress), GetLocalIPAddress(), ipAddress))
                    cmd.Parameters.AddWithValue("@keterangan", keterangan)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("Error mencatat log: " & ex.Message)
        End Try
    End Sub

    Private Shared Function GetLocalIPAddress() As String
        Try
            For Each ip As System.Net.IPAddress In
                System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName()).AddressList
                If ip.AddressFamily = System.Net.Sockets.AddressFamily.InterNetwork Then
                    Return ip.ToString()
                End If
            Next
            Return "127.0.0.1"
        Catch
            Return "127.0.0.1"
        End Try
    End Function

    ' ── Event handlers ───────────────────────────────────────────
    Private Sub ButtonFilter_Click(sender As Object, e As EventArgs) Handles ButtonFilter.Click
        FilterData()
    End Sub

    Private Sub ButtonRefresh_Click(sender As Object, e As EventArgs) Handles ButtonRefresh.Click
        TextBoxCari.Clear()
        LoadTahun()
        SetupFilterDate()
        LoadLogAktivitas()
    End Sub

    Private Sub ButtonClose_Click(sender As Object, e As EventArgs) Handles ButtonClose.Click
        Me.Close()
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
            MessageBox.Show("Error saat preview: " & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' FIX: live search as user types
    Private Sub TextBoxCari_TextChanged(sender As Object, e As EventArgs) Handles TextBoxCari.TextChanged
        FilterData()
    End Sub

    Private Sub DataGridViewLog_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) _
        Handles DataGridViewLog.CellDoubleClick
        If e.RowIndex < 0 Then Return
        Dim row As DataGridViewRow = DataGridViewLog.Rows(e.RowIndex)
        Dim detail As String =
            "Detail Log Aktivitas" & vbCrLf & vbCrLf &
            $"Tanggal   : {row.Cells("TanggalJam").Value}" & vbCrLf &
            $"Aktivitas : {row.Cells("Aktifitas").Value}" & vbCrLf &
            $"ID Admin  : {row.Cells("ID Admin").Value}" & vbCrLf &
            $"Nama Admin: {row.Cells("Nama Admin").Value}" & vbCrLf &
            $"IP Address: {row.Cells("IP Address").Value}" & vbCrLf &
            $"Keterangan: {row.Cells("Keterangan").Value}"
        MessageBox.Show(detail, "Detail Log", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    ' FIX: alternating row colours (RowPrePaint is more reliable than CellFormatting for bg)
    Private Sub DataGridViewLog_RowPrePaint(sender As Object, e As DataGridViewRowPrePaintEventArgs) _
        Handles DataGridViewLog.RowPrePaint
        If e.RowIndex < 0 Then Return
        If Not DataGridViewLog.Rows(e.RowIndex).Selected Then
            DataGridViewLog.Rows(e.RowIndex).DefaultCellStyle.BackColor =
                If(e.RowIndex Mod 2 = 0, Color.White, Color.FromArgb(240, 250, 250))
        End If
    End Sub

    Private Sub LabelTanggalSampai_Click(sender As Object, e As EventArgs) Handles LabelTanggalSampai.Click

    End Sub
End Class