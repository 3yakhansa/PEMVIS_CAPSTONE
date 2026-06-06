Imports MySqlConnector

Public Class LoginForm

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click

        ' 1. VALIDASI INPUT
        If txtUsername.Text = "" Or txtPassword.Text = "" Then
            MsgBox("Username dan Password wajib diisi!", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Try
            ' 2. KONEKSI DATABASE
            Using conn As MySqlConnection = GetConnection()
                conn.Open()

                ' 3. QUERY USER
                Dim query As String = "SELECT * FROM user WHERE username=@username AND isActive=1"
                Dim cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@username", txtUsername.Text)

                Dim reader As MySqlDataReader = cmd.ExecuteReader()

                ' 4. CEK USER
                If reader.Read() Then

                    Dim dbPassword As String = reader("password").ToString()

                    ' 5. CEK PASSWORD
                    If txtPassword.Text = dbPassword Then

                        ' 6. SIMPAN SESSION
                        Session.username = reader("username").ToString()
                        Session.level = Convert.ToInt32(reader("lvl"))

                        MsgBox("Login berhasil!", MsgBoxStyle.Information)

                        ' 7. PINDAH KE DASHBOARD (BELUM ADA → COMMENT DULU)
                        FormDashboard.Show()
                        Me.Hide()

                    Else
                        MsgBox("Password salah!", MsgBoxStyle.Critical)
                    End If

                Else
                    MsgBox("User tidak ditemukan atau tidak aktif!", MsgBoxStyle.Critical)
                End If

            End Using

        Catch ex As Exception
            MsgBox("Terjadi error: " & ex.Message)
        End Try

    End Sub

End Class