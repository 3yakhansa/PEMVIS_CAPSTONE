' ================================================================
'  SessionModule.vb
'  Menyimpan data session user yang sedang login.
'  Diakses dari seluruh form tanpa perlu instansiasi.
' ================================================================
Module Session

    ''' <summary>Username user yang sedang login.</summary>
    Public username As String = ""

    ''' <summary>Level akses: 1 = Mahasiswa (Viewer), 2 = Admin (CRUD).</summary>
    Public level As Integer = 0

    ''' <summary>NIM admin (dari tabel admin) untuk keperluan pencatatan log.</summary>
    Public nimAdmin As String = ""

    ''' <summary>Nama lengkap admin untuk ditampilkan di UI.</summary>
    Public namaAdmin As String = ""

    ''' <summary>NIM mahasiswa yang sedang login (untuk dashboard mahasiswa).</summary>
    Public nim As String = ""

    ''' <summary>Menghapus seluruh data session (dipanggil saat logout).</summary>
    Public Sub Clear()
        username = ""
        level = 0
        nimAdmin = ""
        namaAdmin = ""
        nim = ""
    End Sub

    ''' <summary>True jika user adalah Admin (level 2).</summary>
    Public ReadOnly Property IsAdmin As Boolean
        Get
            Return level = 2
        End Get
    End Property

End Module