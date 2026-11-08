
Imports MySqlConnector
Public Class FormAudit
    Private Sub FormAudit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ConfigGrid()
        LoadAudits("")
    End Sub

    Private Sub ConfigGrid()
        dgAudits.AllowUserToAddRows = False
        dgAudits.AllowUserToDeleteRows = False
        dgAudits.ReadOnly = True
        dgAudits.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgAudits.MultiSelect = False
        dgAudits.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgAudits.RowHeadersVisible = False ' Plus propre sans l'en-tête de ligne gris à gauche
    End Sub


    Private Sub LoadAudits(keyword As String)
        Try
            Using conn = DBConnector.GetConnection()
                conn.Open()

                ' EXPLICATION DE LA REQUÊTE SQL :
                ' 1. On sélectionne l'ID, l'Action et la Date depuis audit_logs (l).
                ' 2. On récupère le 'username' depuis la table admins (a).
                ' 3. IFNULL(a.username, 'Système') : Si admin_id est NULL (ex: fermeture auto), on écrit "Système".
                ' 4. Le WHERE permet de chercher dans le nom de l'admin OU dans le texte de l'action.

                Dim sql As String = "
                    SELECT 
                        l.id, 
                        COALESCE(a.username, 'Système') AS 'Utilisateur', 
                        l.action AS 'Action réalisée', 
                        l.created_at AS 'Date & Heure'
                    FROM audit_logs l
                    LEFT JOIN admins a ON l.admin_id = a.id
                    WHERE (a.username LIKE @k OR l.action LIKE @k)
                    ORDER BY l.created_at DESC
                "

                Using cmd As New MySqlCommand(sql, conn)
                    ' Le % permet de chercher "ce qui contient" le mot clé
                    cmd.Parameters.AddWithValue("@k", "%" & keyword & "%")

                    Dim dt As New DataTable()
                    Using da As New MySqlDataAdapter(cmd)
                        da.Fill(dt)
                    End Using

                    dgAudits.DataSource = dt

                    ' Masquer la colonne ID (inutile pour l'utilisateur)
                    If dgAudits.Columns("id") IsNot Nothing Then
                        dgAudits.Columns("id").Visible = False
                    End If

                    ' Formatage de la largeur des colonnes (Optionnel)
                    If dgAudits.Columns("Date & Heure") IsNot Nothing Then
                        dgAudits.Columns("Date & Heure").Width = 150
                    End If
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Erreur lors du chargement des logs : " & ex.Message)
        End Try
    End Sub

    ' ---------------------------------------------------------
    ' RECHERCHE DYNAMIQUE (Dès qu'on tape une lettre)
    ' ---------------------------------------------------------
    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged

        LoadAudits(txtSearch.Text.Trim())
    End Sub

    Private Sub txtSearch_Click(sender As Object, e As EventArgs) Handles txtSearch.Click
        txtSearch.Clear()
    End Sub
End Class

