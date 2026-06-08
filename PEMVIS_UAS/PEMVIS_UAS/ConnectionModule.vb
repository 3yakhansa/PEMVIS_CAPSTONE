Imports MySqlConnector

' ================================================================
'  ConnectionModule.vb
'  Modul koneksi terpusat — semua form menggunakan GetConnection()
'  Database : db_nilai_xyz
'  Ubah Server/Port/Uid/Pwd sesuai konfigurasi lokal.
' ================================================================
Module ConnectionModule

    Private Const SERVER As String = "localhost"
    Private Const PORT As String = "3306"
    Private Const DATABASE As String = "db_nilai_xyz"
    Private Const UID As String = "root"
    Private Const PWD As String = ""

    Public ReadOnly Property ConnectionString As String
        Get
            Return $"Server={SERVER};Port={PORT};Database={DATABASE};Uid={UID};Pwd={PWD};CharSet=utf8mb4;"
        End Get
    End Property

    ''' <summary>Mengembalikan MySqlConnection baru. Panggil .Open() sebelum digunakan.</summary>
    Public Function GetConnection() As MySqlConnection
        Return New MySqlConnection(ConnectionString)
    End Function

End Module
