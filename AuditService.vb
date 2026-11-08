Imports MySqlConnector

Public Class AuditService
    Public Shared Sub Log(action As String)
        ' Vérification de sécurité
        Dim adminId As Object = DBNull.Value

        ' On utilise la variable globale remplie par le Login
        If Session.CurrentAdminId <> -1 Then
            adminId = Session.CurrentAdminId
        End If

        Try
            Using conn = DBConnector.GetConnection()
                conn.Open()
                Dim sql As String = "INSERT INTO audit_logs (admin_id, action, created_at) VALUES (@id, @act, NOW())"

                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@id", adminId)
                    cmd.Parameters.AddWithValue("@act", action)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            ' Log silencieux en console (fenêtre sortie) pour ne pas bloquer l'appli
            System.Diagnostics.Debug.WriteLine("Erreur Audit : " & ex.Message)
        End Try
    End Sub
End Class