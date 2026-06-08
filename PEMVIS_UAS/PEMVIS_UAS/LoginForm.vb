Imports MySqlConnector
Imports System.Security.Cryptography
Imports System.Text

Public Class LoginForm

    Private Function HashPassword(plain As String) As String
        Using sha As New SHA256Managed()
            Dim bytes() As Byte = sha.ComputeHash(Encoding.UTF8.GetBytes(plain))
            Return BitConverter.ToString(bytes).Replace("-", "").ToLower()
        End Using
    End Function

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click

        If String.IsNullOrWhiteSpace(txtUsername.Text) OrElse
           String.IsNullOrWhiteSpace(txtPassword.Text) Then
            MsgBox("Username dan Password wajib diisi!", MsgBoxStyle.Exclamation, "Login")
            Exit Sub
        End If

        Try
            Using conn As MySqlConnection = ConnectionModule.GetConnection()
                conn.Open()

                Dim sql As String =
                    "SELECT u.idUser, u.username, u.password, u.lvl, " &
                    "       u.nimRef, a.nimAdmin, a.namaAdmin " &
                    "FROM `user` u " &
                    "LEFT JOIN admin a ON u.nimRef = a.nimAdmin " &
                    "WHERE u.username = @username AND u.isActive = 1 " &
                    "LIMIT 1"

                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@username", txtUsername.Text.Trim())

                    Using reader As MySqlDataReader = cmd.ExecuteReader()

                        If reader.Read() Then

                            Dim dbPassword As String = reader("password").ToString()

                            If HashPassword(txtPassword.Text) = dbPassword Then

                                Session.username = reader("username").ToString()
                                Session.level = Convert.ToInt32(reader("lvl"))

                                ' ── Level 1 = Mahasiswa (Viewer) ───────────────
                                ' ── Level 2 = Admin (CRUD) ─────────────────────
                                If Session.level = 2 Then
                                    ' Admin: nimRef merujuk ke tabel admin
                                    Session.nimAdmin = If(IsDBNull(reader("nimAdmin")), "", reader("nimAdmin").ToString())
                                    Session.namaAdmin = If(IsDBNull(reader("namaAdmin")), Session.username, reader("namaAdmin").ToString())
                                    Session.nim = ""
                                Else
                                    ' Mahasiswa lvl 1: nimRef adalah NIM mahasiswa
                                    Session.nim = If(IsDBNull(reader("nimRef")), "", reader("nimRef").ToString())
                                    Session.nimAdmin = ""
                                    Session.namaAdmin = Session.username
                                End If

                                reader.Close()

                                ' Update lastLogin
                                Using cmdUp As New MySqlCommand(
                                    "UPDATE `user` SET lastLogin = NOW() WHERE username = @u", conn)
                                    cmdUp.Parameters.AddWithValue("@u", Session.username)
                                    cmdUp.ExecuteNonQuery()
                                End Using

                                ' Catat log (hanya Admin yang punya nimAdmin)
                                CatatLogLogin(conn)

                                ' ── Routing berdasarkan level ──────────────────
                                If Session.level = 2 Then
                                    ' Admin lvl 2 → FormDashboard
                                    FormDashboard.Show()
                                Else
                                    ' Mahasiswa lvl 1 → FormDashboardMahasiswa
                                    Dim frmDash As New FormDashboardMahasiswa()
                                    frmDash.nim = Session.nim
                                    frmDash.Show()
                                End If

                                Me.Hide()

                            Else
                                MsgBox("Password salah!", MsgBoxStyle.Critical, "Login Gagal")
                            End If

                        Else
                            MsgBox("User tidak ditemukan atau tidak aktif!",
                                   MsgBoxStyle.Critical, "Login Gagal")
                        End If

                    End Using
                End Using
            End Using

        Catch ex As Exception
            MsgBox("Terjadi error koneksi:" & vbCrLf & ex.Message,
                   MsgBoxStyle.Critical, "Error")
        End Try

    End Sub

    Private Sub CatatLogLogin(conn As MySqlConnection)
        Try
            If String.IsNullOrEmpty(Session.nimAdmin) Then Return

            Using cek As New MySqlCommand(
                "SELECT COUNT(*) FROM admin WHERE nimAdmin = @n", conn)
                cek.Parameters.AddWithValue("@n", Session.nimAdmin)
                If CInt(cek.ExecuteScalar()) = 0 Then Return
            End Using

            Using cmd As New MySqlCommand(
                "INSERT INTO log (tanggalJam, aktifitas, nimAdmin, ipAddress, keterangan) " &
                "VALUES (NOW(), @akt, @nim, @ip, @ket)", conn)
                cmd.Parameters.AddWithValue("@akt", "LOGIN")
                cmd.Parameters.AddWithValue("@nim", Session.nimAdmin)
                cmd.Parameters.AddWithValue("@ip", GetLocalIP())
                cmd.Parameters.AddWithValue("@ket", "User " & Session.username & " berhasil login")
                cmd.ExecuteNonQuery()
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

    Private Sub LoginForm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then btnLogin.PerformClick()
    End Sub

End Class