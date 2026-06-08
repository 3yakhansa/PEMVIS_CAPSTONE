Imports MySqlConnector

Module ConnectionModule

    ' ================================================================
    '  PENTING: MySqlConnector (bukan MySql.Data) pakai "User" bukan "User ID"
    '  Sesuaikan nilai di bawah jika berbeda di komputer kamu
    ' ================================================================
    Public ReadOnly ConnectionString As String =
        "Server=localhost;" &
        "Port=3306;" &
        "Database=db_nilai_xyz;" &
        "User=root;" &
        "Password=;"

    Public Function GetConnection() As MySqlConnection
        Return New MySqlConnection(ConnectionString)
    End Function

End Module