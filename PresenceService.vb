Imports MySqlConnector

Public Class PresenceService

    ' ---------------------------------------------------------
    ' 1. LECTURE AVEC FILTRE CLASSE (C'est ici que tu avais l'erreur)
    ' ---------------------------------------------------------
    ' Regarde bien la parenthèse : il y a maintenant 4 paramètres dont 'classe'
    Public Shared Function GetPresencesForStudent(keyword As String, classe As String, dateStart As Date, dateEnd As Date) As DataTable
        Dim dt As New DataTable()

        Using conn = DBConnector.GetConnection()
            conn.Open()

            ' SQL : On récupère aussi le planning (schedule) pour savoir si on doit griser
            Dim sql As String = "
                SELECT p.id, p.student_id, s.matricule, s.last_name, s.first_name, s.classe,
                       p.attendance_date, p.p1, p.p2, p.p3, p.p4, p.justification,
                       
                       sch.p1 AS sched_p1,
                       sch.p2 AS sched_p2,
                       sch.p3 AS sched_p3,
                       sch.p4 AS sched_p4

                FROM attendance p
                INNER JOIN students s ON p.student_id = s.id
                LEFT JOIN schedule sch ON s.classe = sch.classe AND p.attendance_date = sch.schedule_date
                
                WHERE (s.matricule LIKE @k OR s.last_name LIKE @k OR s.first_name LIKE @k)
                AND (@c = '' OR s.classe = @c)  -- <--- LE FILTRE CLASSE EST ICI
                AND p.attendance_date BETWEEN @ds AND @de
                
                ORDER BY p.attendance_date DESC, s.last_name ASC
            "

            Using cmd As New MySqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@k", "%" & keyword & "%")
                cmd.Parameters.AddWithValue("@c", classe) ' <--- Paramètre ajouté
                cmd.Parameters.AddWithValue("@ds", dateStart)
                cmd.Parameters.AddWithValue("@de", dateEnd)

                Using da As New MySqlDataAdapter(cmd)
                    da.Fill(dt)
                End Using
            End Using
        End Using

        Return dt
    End Function

    ' ---------------------------------------------------------
    ' 2. CRÉATION INTELLIGENTE (HYDRATATION)
    ' ---------------------------------------------------------
    Public Shared Sub EnsureRowsExistForDate(targetDate As Date)
        Using conn = DBConnector.GetConnection()
            conn.Open()

            ' On ne crée une ligne d'absence QUE si un cours est prévu ce jour-là
            Dim sql As String = "
                INSERT INTO attendance (student_id, attendance_date, p1, p2, p3, p4)
                SELECT s.id, @date, 0, 0, 0, 0 
                FROM students s
                LEFT JOIN schedule sch ON s.classe = sch.classe AND sch.schedule_date = @date
                WHERE s.id NOT IN (
                    SELECT student_id FROM attendance WHERE attendance_date = @date
                )
                -- Si pas de planning (NULL), on assume cours normal. Si planning, il faut au moins 1 cours.
                AND (sch.id IS NULL OR (sch.p1=1 OR sch.p2=1 OR sch.p3=1 OR sch.p4=1))
            "

            Using cmd As New MySqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@date", targetDate)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    ' ---------------------------------------------------------
    ' 3. MISE A JOUR (UPDATE)
    ' ---------------------------------------------------------
    Public Shared Sub UpdatePresence(id As Integer, p1 As Boolean, p2 As Boolean, p3 As Boolean, p4 As Boolean, justification As String)
        Using conn = DBConnector.GetConnection()
            conn.Open()
            Dim sql As String = "UPDATE attendance SET p1=@p1, p2=@p2, p3=@p3, p4=@p4, justification=@j WHERE id=@id"

            Using cmd As New MySqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@p1", p1)
                cmd.Parameters.AddWithValue("@p2", p2)
                cmd.Parameters.AddWithValue("@p3", p3)
                cmd.Parameters.AddWithValue("@p4", p4)

                If String.IsNullOrWhiteSpace(justification) Then
                    cmd.Parameters.AddWithValue("@j", DBNull.Value)
                Else
                    cmd.Parameters.AddWithValue("@j", justification)
                End If

                cmd.Parameters.AddWithValue("@id", id)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    ' ---------------------------------------------------------
    ' 4. SUPPRESSION
    ' ---------------------------------------------------------
    Public Shared Sub DeletePresence(id As Integer)
        Using conn = DBConnector.GetConnection()
            conn.Open()
            Dim sql As String = "DELETE FROM attendance WHERE id=@id"
            Using cmd As New MySqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@id", id)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

End Class