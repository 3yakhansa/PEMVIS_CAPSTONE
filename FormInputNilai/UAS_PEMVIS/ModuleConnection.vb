Imports MySqlConnector

Module ModuleConnection
    Public ReadOnly ConnectionString As String =
        "Server=localhost;Port=3306;Database=db_nilai_xyz;UserID=root;Password=;"

    Public Function GetConnection() As MySqlConnection
        Return New MySqlConnection(ConnectionString)
    End Function

End Module