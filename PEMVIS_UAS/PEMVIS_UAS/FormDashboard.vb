Imports Microsoft.Extensions.Logging

Public Class FormDashboard

    ' ── Load ────────────────────────────────────────────────────
    Private Sub FormDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblWelcome.Text = "Welcome, " & Session.username
        lblLevel.Text = If(Session.level = 2, "Role: Admin", "Role: Viewer")
    End Sub

    ' ── Navigasi form ───────────────────────────────────────────
    Private Sub btnDataUser_Click(sender As Object, e As EventArgs) Handles btnDataUser.Click
        Dim frm As New FormDataUser()
        frm.ShowDialog()
    End Sub

    Private Sub btnDataMahasiswa_Click(sender As Object, e As EventArgs) Handles btnDataMahasiswa.Click
        Dim frm As New FormDataMahasiswa()
        frm.ShowDialog()
    End Sub

    Private Sub btnMataKuliah_Click(sender As Object, e As EventArgs) Handles btnMataKuliah.Click
        Dim frm As New FormMataKuliah()
        frm.ShowDialog()
    End Sub

    Private Sub btnInputNilai_Click(sender As Object, e As EventArgs) Handles btnInputNilai.Click
        Dim frm As New FormInputNilai()
        frm.ShowDialog()
    End Sub

    Private Sub btnLogAktivitas_Click(sender As Object, e As EventArgs) Handles btnLogAktivitas.Click
        Dim frm As New FormLogAktivitas()
        frm.ShowDialog()
    End Sub

    Private Sub btnReportNilai_Click(sender As Object, e As EventArgs) Handles btnReportNilai.Click
        Dim frm As New FormReportNilai()
        frm.ShowDialog()
    End Sub

    Private Sub btnReportLog_Click(sender As Object, e As EventArgs) Handles btnReportLog.Click
        Dim frm As New FormReportLog()
        frm.ShowDialog()
    End Sub

    ' ── Logout ──────────────────────────────────────────────────
    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        ' Catat log logout sebelum session dihapus
        CatatLogLogout()

        ' Hapus session
        Session.Clear()

        ' Kembali ke login
        LoginForm.Show()
        Me.Close()
    End Sub

    ' ── Helper: catat log LOGOUT ─────────────────────────────────
    Private Sub CatatLogLogout()
        Try
            If String.IsNullOrEmpty(Session.nimAdmin) Then Return

            Using conn = ConnectionModule.GetConnection()
                conn.Open()

                ' Cek FK
                Using cek As New MySqlConnector.MySqlCommand(
                    "SELECT COUNT(*) FROM admin WHERE nimAdmin = @n", conn)
                    cek.Parameters.AddWithValue("@n", Session.nimAdmin)
                    If CInt(cek.ExecuteScalar()) = 0 Then Return
                End Using

                Using cmd As New MySqlConnector.MySqlCommand(
                    "INSERT INTO log (tanggalJam, aktifitas, nimAdmin, ipAddress, keterangan) " &
                    "VALUES (NOW(), @akt, @nim, @ip, @ket)", conn)
                    cmd.Parameters.AddWithValue("@akt", "LOGOUT")
                    cmd.Parameters.AddWithValue("@nim", Session.nimAdmin)
                    cmd.Parameters.AddWithValue("@ip", GetLocalIP())
                    cmd.Parameters.AddWithValue("@ket", "User " & Session.username & " logout")
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch

        End Try
    End Sub

    Private Function GetLocalIP() As String
        Try
            For Each ip In Net.Dns.GetHostEntry(Net.Dns.GetHostName()).AddressList
                If ip.AddressFamily = Net.Sockets.AddressFamily.InterNetwork Then
                    Return ip.ToString()
                End If
            Next
            Return "127.0.0.1"
        Catch
            Return "127.0.0.1"
        End Try
    End Function

End Class