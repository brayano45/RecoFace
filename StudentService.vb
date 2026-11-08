Imports MySqlConnector

Public Class StudentService
    Public Shared Function GetAllStudents() As DataTable
        Dim dt As New DataTable()

        Using conn = DBConnector.GetConnection()
            conn.Open()

            Using cmd As New MySqlCommand("SELECT * FROM students ORDER BY last_name", conn)
                Using da As New MySqlDataAdapter(cmd)
                    da.Fill(dt)
                End Using
            End Using
        End Using

        Return dt
    End Function

    Public Shared Function MatriculeExists(matricule As String) As Boolean
        Using conn = DBConnector.GetConnection()
            conn.Open()
            Dim sql = "SELECT COUNT(*) FROM students WHERE matricule = @m"
            Using cmd As New MySqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@m", matricule)
                Dim count = Convert.ToInt32(cmd.ExecuteScalar())
                Return count > 0
            End Using
        End Using
    End Function

    Public Shared Function SearchStudents(keyword As String) As DataTable
        Dim dt As New DataTable()

        Using conn = DBConnector.GetConnection()
            conn.Open()

            Dim sql As String = "
                SELECT * FROM students 
                WHERE matricule LIKE @k OR last_name LIKE @k OR first_name LIKE @k OR classe LIKE @k
                ORDER BY last_name"

            Using cmd As New MySqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@k", "%" & keyword & "%")
                Using da As New MySqlDataAdapter(cmd)
                    da.Fill(dt)
                End Using
            End Using
        End Using

        Return dt
    End Function

    Public Shared Sub AddStudent(matricule As String, nom As String, prenom As String, classe As String)
        Using conn = DBConnector.GetConnection()
            conn.Open()

            Dim sql As String = "
                INSERT INTO students (matricule, last_name, first_name, classe)
                VALUES (@m, @n, @p, @c)"

            Using cmd As New MySqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@m", matricule)
                cmd.Parameters.AddWithValue("@n", nom)
                cmd.Parameters.AddWithValue("@p", prenom)
                cmd.Parameters.AddWithValue("@c", classe)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Shared Sub UpdateStudent(id As Integer, matricule As String, nom As String, prenom As String, classe As String)
        Using conn = DBConnector.GetConnection()
            conn.Open()

            Dim sql As String = "
                UPDATE students 
                SET matricule=@m, last_name=@n, first_name=@p, classe=@c
                WHERE id=@id"

            Using cmd As New MySqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@m", matricule)
                cmd.Parameters.AddWithValue("@n", nom)
                cmd.Parameters.AddWithValue("@p", prenom)
                cmd.Parameters.AddWithValue("@c", classe)
                cmd.Parameters.AddWithValue("@id", id)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Shared Sub DeleteStudent(id As Integer)
        Using conn = DBConnector.GetConnection()
            conn.Open()

            Dim sql As String = "DELETE FROM students WHERE id=@id"

            Using cmd As New MySqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@id", id)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub
End Class
