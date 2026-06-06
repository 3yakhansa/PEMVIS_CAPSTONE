Public Class FormDashboard

    Private Sub FormDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Tampilkan username
        lblWelcome.Text = "Welcome, " & Session.username

        ' Tampilkan level
        If Session.level = 1 Then
            lblLevel.Text = "Role: Admin"
        Else
            lblLevel.Text = "Role: Viewer"
        End If

    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click

        ' Hapus session
        Session.username = ""
        Session.level = 0

        ' Kembali ke login
        LoginForm.Show()
        Me.Close()

    End Sub

End Class