Imports MySqlConnector

Public Class DBConnector
    ' On retire la chaîne hardcodée et on construit dynamiquement
    Public Shared Function GetConnection() As MySqlConnection
        Dim host As String = "localhost"
        Dim db As String = "gestion_presence"
        Dim user As String = "root"
        Dim pwd As String = ""

        ' On essaie de lire les paramètres sauvegardés si disponibles
        Try
            host = My.Settings.DB_Host
            db = My.Settings.DB_Name
            user = My.Settings.DB_User
            pwd = My.Settings.DB_Pass
        Catch
            ' Si erreur (premier lancement), on garde les valeurs par défaut ci-dessus
        End Try

        Dim connString = $"Server={host};Database={db};Uid={user};Pwd={pwd};SslMode=None;"
        Return New MySqlConnection(connString)
    End Function

    Public Shared Function TestConnection() As Boolean
        Try
            Using conn = GetConnection()
                conn.Open()
                Return True
            End Using
        Catch ex As Exception
            Return False
        End Try
    End Function
End Class