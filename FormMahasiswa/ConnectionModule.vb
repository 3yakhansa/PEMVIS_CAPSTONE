Imports MySql.Data.MySqlClient
Imports MySqlConnector

Module ConnectionModule

    Private Const SERVER As String = "localhost"
    Private Const PORT As String = "3306"
    Private Const DATABASE As String = "db_nilai_xyz"
    Private Const USER As String = "root"
    Private Const PASSWORD As String = ""
    Private Const CONNECT_TIMEOUT As Integer = 10

    Public ReadOnly Property ConnectionString As String
        Get
            Return $"Server={SERVER};Port={PORT};Database={DATABASE};" &
                   $"Uid={USER};Pwd={PASSWORD};" &
                   $"Connect Timeout={CONNECT_TIMEOUT};CharSet=utf8mb4;"
        End Get
    End Property

    Public Function BukaKoneksi() As MySqlConnection
        Dim conn As New MySqlConnection(ConnectionString)
        Try
            conn.Open()
            Return conn
        Catch ex As MySqlException
            Throw New Exception($"Gagal terhubung ke database:{Environment.NewLine}{ex.Message}", ex)
        End Try
    End Function

    Public Function TestKoneksi() As Boolean
        Try
            Using conn As MySqlConnection = BukaKoneksi()
                Return conn.State = ConnectionState.Open
            End Using
        Catch
            Return False
        End Try
    End Function

End Module