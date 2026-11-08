Imports System.Speech.Synthesis
Imports MySqlConnector


Public Class FormLogin

    Private speaker As New SpeechSynthesizer()
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim user = txtUsername.Text.Trim()
        Dim pass = txtPassword.Text.Trim()

        If user = "" OrElse pass = "" Then
            LabelError.Text = "Veuillez remplir tous les champs."
            Dire("s'il vous plait veuillez remplir tous les champs")
            Return
        End If

        Dim hash = SecurityHelper.SHA256Hash(pass)

        Try
            Using conn = DBConnector.GetConnection()
                conn.Open()

                ' On récupère ID, Username et Role
                Dim sql = "SELECT id, username, role FROM admins WHERE username=@u AND password_hash=@p AND is_active=1 LIMIT 1"

                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@u", user)
                    cmd.Parameters.AddWithValue("@p", hash)

                    Using rdr = cmd.ExecuteReader()
                        If rdr.Read() Then
                            ' --- 1. RÉCUPÉRATION ---
                            Dim adminId As Integer = rdr.GetInt32("id")
                            Dim nomUtilisateur As String = rdr.GetString("username")
                            Dim role As String = rdr.GetString("role")

                            rdr.Close() ' On ferme le reader tout de suite

                            ' --- 2. REMPLISSAGE DE LA SESSION (C'EST ÇA QUI MANQUAIT !) ---
                            ' Sans ça, AuditService ne sait pas qui est connecté
                            Session.CurrentAdminId = adminId
                            Session.CurrentUsername = nomUtilisateur
                            Session.CurrentRole = role

                            ' --- 3. AUDIT & NAVIGATION ---
                            InsertLoginAudit(adminId)

                            Me.Hide()

                            ' On passe aussi les infos au Dashboard pour l'affichage visuel
                            Dim f As New FormDashboard(adminId, nomUtilisateur, role)
                            f.Show()
                        Else
                            LabelError.Text = "Identifiants incorrects ou compte bloqué."
                            Dire("Accès refusé")

                        End If
                    End Using
                End Using
            End Using

        Catch ex As Exception
            LabelError.Text = "Erreur : " & ex.Message
        End Try
    End Sub

    Private Sub InsertLoginAudit(adminId As Integer)
        Try
            Using conn = DBConnector.GetConnection()
                conn.Open()
                Dim sql = "INSERT INTO audit_logs(admin_id, action) VALUES(@a, 'Connexion réussie')"
                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@a", adminId)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch
            ' On ignore volontairement les erreurs d'audit
        End Try
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        FormChoix.Show()
        Me.Close()
    End Sub



    Private Sub FormLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtPassword.PasswordChar = "*"c

        Panel1.Visible = False
        Panel2.Visible = False
    End Sub

    ' 1. AU DÉMARRAGE : ON CACHE TOUT

    ' 2. QUAND ON CLIQUE SUR LE FOND DU FORMULAIRE
    Private Sub FormLogin_Click(sender As Object, e As EventArgs) Handles MyBase.Click
        BasculerVisibilite()
    End Sub

    ' 3. PROCÉDURE POUR BASCULER (Toggle)
    Private Sub BasculerVisibilite()
        ' Si c'est Visible, ça devient Invisible (et inversement)
        Dim etatActuel As Boolean = Panel1.Visible

        ' On inverse l'état
        Panel1.Visible = Not etatActuel
        Panel2.Visible = Not etatActuel
    End Sub

    Private Sub FormLogin_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        ' (Sauf si on est déjà passé au dashboard, mais ici on est au login)
        If Application.OpenForms("FormDashboard") Is Nothing Then
            FormChoix.Show()
        End If
    End Sub

    Private Sub Dire(texte As String)
        Try
            If speaker.State = SynthesizerState.Speaking Then
                speaker.SpeakAsyncCancelAll()
            End If
            speaker.SpeakAsync(texte)
        Catch
        End Try
    End Sub
End Class