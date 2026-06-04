' ============================================================
'  ModSession.vb
'  Menyimpan informasi user yang sedang login.
'  Diisi oleh FormLogin, dibaca oleh semua form lain.
' ============================================================
Module ModSession

    ' ID user yang login
    Public UserLoginID As Integer = 0

    ' Username yang login
    Public UserLoginName As String = ""

    ' Level akses: 1 = Admin, 2 = Viewer
    Public LevelLogin As Integer = 0

    ' NIM referensi (jika user terhubung ke data admin/mahasiswa)
    Public NimLogin As String = ""

    ' Nama lengkap untuk ditampilkan di UI
    Public NamaLogin As String = ""

    ' Waktu login
    Public WaktuLogin As DateTime = Nothing

    ' ── Cek apakah user adalah Admin ──────────────────────
    Public ReadOnly Property IsAdmin As Boolean
        Get
            Return LevelLogin = 1
        End Get
    End Property

    ' ── Cek apakah user adalah Viewer ─────────────────────
    Public ReadOnly Property IsViewer As Boolean
        Get
            Return LevelLogin = 2
        End Get
    End Property

    ' ── Reset session saat logout ──────────────────────────
    Public Sub ResetSession()
        UserLoginID = 0
        UserLoginName = ""
        LevelLogin = 0
        NimLogin = ""
        NamaLogin = ""
        WaktuLogin = Nothing
    End Sub

End Module