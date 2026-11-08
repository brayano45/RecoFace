Imports MySqlConnector
Imports System.IO

Public Class FormSettings
    Inherits Form

    Private Sub FormSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' 1. Charger les paramètres généraux (chemins, db, etc.) depuis My.Settings
        Try
            nudThreshold.Value = CDec(If(HasSetting("LBPH_Threshold"), My.Settings.LBPH_Threshold, 70))
        Catch
            nudThreshold.Value = 70
        End Try

        Try
            nudImagesPerStudent.Value = CDec(If(HasSetting("ImagesPerStudent"), My.Settings.ImagesPerStudent, 20))
        Catch
            nudImagesPerStudent.Value = 20
        End Try

        Try
            nudMinSize.Value = CDec(If(HasSetting("MinFaceSize"), My.Settings.MinFaceSize, 100))
        Catch
            nudMinSize.Value = 100
        End Try

        txtTrainingPath.Text = If(HasSetting("TrainingPath"), My.Settings.TrainingPath, Path.Combine(Application.StartupPath, "TrainingImages"))
        txtModelPath.Text = If(HasSetting("ModelPath"), My.Settings.ModelPath, Path.Combine(Application.StartupPath, "Data", "models"))

        txtHost.Text = If(HasSetting("DB_Host"), My.Settings.DB_Host, "localhost")
        txtDBName.Text = If(HasSetting("DB_Name"), My.Settings.DB_Name, "gestion_presence")
        txtDBUser.Text = If(HasSetting("DB_User"), My.Settings.DB_User, "root")
        txtDBPass.Text = If(HasSetting("DB_Pass"), My.Settings.DB_Pass, "")


        chkDarkMode.Checked = If(HasSetting("DarkMode"), My.Settings.DarkMode, False)
        chkLogs.Checked = If(HasSetting("EnableLogs"), My.Settings.EnableLogs, True)

        ThemeManager.ApplyTheme(Me, chkDarkMode.Checked)

        ' 2. CHARGER LES HORAIRES DEPUIS LA BDD (C'est la dernière action pour ne pas être écrasé)
        LoadTimeSlots()
    End Sub

    Private Function HasSetting(name As String) As Boolean
        Try
            Dim val = My.Settings(name)
            Return True
        Catch
            Return False
        End Try
    End Function

    ' ---------------------------------------------------------
    ' BOUTONS DE PARCOURS (Browsing)
    ' ---------------------------------------------------------
    Private Sub btnBrowseTraining_Click(sender As Object, e As EventArgs) Handles btnBrowseTraining.Click
        Using fd As New FolderBrowserDialog()
            If fd.ShowDialog() = DialogResult.OK Then
                txtTrainingPath.Text = fd.SelectedPath
            End If
        End Using
    End Sub

    Private Sub btnBrowseModel_Click(sender As Object, e As EventArgs) Handles btnBrowseModel.Click
        Using fd As New FolderBrowserDialog
            If fd.ShowDialog = DialogResult.OK Then
                txtModelPath.Text = fd.SelectedPath
            End If
        End Using
    End Sub


    ' ---------------------------------------------------------
    ' TEST CONNEXION
    ' ---------------------------------------------------------
    Private Sub btnTestConnection_Click(sender As Object, e As EventArgs) Handles btnTestConnection.Click
        Dim connStr = $"Server={txtHost.Text};Database={txtDBName.Text};Uid={txtDBUser.Text};Pwd={txtDBPass.Text};SslMode=None;"
        Try
            Using cn As New MySqlConnection(connStr)
                cn.Open()
                lblDBStatus.Text = "Connexion OK"
                lblDBStatus.ForeColor = Color.Green
            End Using
        Catch ex As Exception
            lblDBStatus.Text = "Erreur : " & ex.Message
            lblDBStatus.ForeColor = Color.Red
        End Try
    End Sub


    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            ' 1. Sauvegarde Locale (My.Settings) - Pour l'affichage au prochain lancement
            My.Settings.LBPH_Threshold = CInt(nudThreshold.Value)
            My.Settings.ImagesPerStudent = CInt(nudImagesPerStudent.Value)
            My.Settings.MinFaceSize = CInt(nudMinSize.Value)

            ' Chemins
            My.Settings.TrainingPath = txtTrainingPath.Text
            My.Settings.ModelPath = txtModelPath.Text

            ' Options
            My.Settings.DarkMode = chkDarkMode.Checked
            My.Settings.EnableLogs = chkLogs.Checked

            My.Settings.Save() ' Écriture sur le disque du PC

            ' 2. SAUVEGARDE EN BASE DE DONNÉES (CRUCIAL POUR LA CAMÉRA)
            Using conn = DBConnector.GetConnection()
                conn.Open()
                ' On met à jour la configuration globale
                Dim sql = "UPDATE settings SET lbph_threshold = @seuil"
                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@seuil", nudThreshold.Value)
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("Paramètres enregistrés (Local + Base de données) !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Appliquer le thème
            ThemeManager.ApplyTheme(Me, chkDarkMode.Checked)

        Catch ex As Exception
            MessageBox.Show("Erreur sauvegarde : " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    ' GESTION DES HORAIRES (DATABASE) - VERSION ROBUSTE
    ' 

    Private Sub LoadTimeSlots()
        Try
            EnsureSettingsExist()

            Using conn = DBConnector.GetConnection()
                conn.Open()
                ' On prend la PREMIÈRE ligne trouvée (peu importe son ID)
                Dim sql As String = "SELECT * FROM settings ORDER BY id ASC LIMIT 1"

                Using cmd As New MySqlCommand(sql, conn)
                    Using rdr = cmd.ExecuteReader()
                        If rdr.Read() Then
                            ' On stocke l'ID réel dans le TAG pour savoir quelle ligne modifier
                            Dim realId As Integer = rdr.GetInt32("id")
                            Me.Tag = realId

                            Dim today = DateTime.Today

                            dtpP1Start.Value = today.Add(rdr.GetTimeSpan("period1_start"))
                            dtpP1End.Value = today.Add(rdr.GetTimeSpan("period1_end"))
                            dtpP2Start.Value = today.Add(rdr.GetTimeSpan("period2_start"))
                            dtpP2End.Value = today.Add(rdr.GetTimeSpan("period2_end"))
                            dtpP3Start.Value = today.Add(rdr.GetTimeSpan("period3_start"))
                            dtpP3End.Value = today.Add(rdr.GetTimeSpan("period3_end"))
                            dtpP4Start.Value = today.Add(rdr.GetTimeSpan("period4_start"))
                            dtpP4End.Value = today.Add(rdr.GetTimeSpan("period4_end"))
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Erreur chargement horaires : " & ex.Message)
        End Try
    End Sub

    Private Sub btnSaveTimes_Click(sender As Object, e As EventArgs) Handles btnSaveTimes.Click
        Try
            ' On récupère l'ID réel (stocké lors du chargement)
            Dim targetId As Integer = 1
            If Me.Tag IsNot Nothing AndAlso IsNumeric(Me.Tag) Then
                targetId = CInt(Me.Tag)
            End If

            Using conn = DBConnector.GetConnection()
                conn.Open()

                Dim sql As String = "
                    UPDATE settings 
                    SET period1_start=@p1s, period1_end=@p1e,
                        period2_start=@p2s, period2_end=@p2e,
                        period3_start=@p3s, period3_end=@p3e,
                        period4_start=@p4s, period4_end=@p4e
                    WHERE id = @id"

                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@p1s", dtpP1Start.Value.TimeOfDay)
                    cmd.Parameters.AddWithValue("@p1e", dtpP1End.Value.TimeOfDay)
                    cmd.Parameters.AddWithValue("@p2s", dtpP2Start.Value.TimeOfDay)
                    cmd.Parameters.AddWithValue("@p2e", dtpP2End.Value.TimeOfDay)
                    cmd.Parameters.AddWithValue("@p3s", dtpP3Start.Value.TimeOfDay)
                    cmd.Parameters.AddWithValue("@p3e", dtpP3End.Value.TimeOfDay)
                    cmd.Parameters.AddWithValue("@p4s", dtpP4Start.Value.TimeOfDay)
                    cmd.Parameters.AddWithValue("@p4e", dtpP4End.Value.TimeOfDay)

                    cmd.Parameters.AddWithValue("@id", targetId)

                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("Horaires mis à jour dans la base de données !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Erreur sauvegarde horaires : " & ex.Message)
        End Try
    End Sub

    Private Sub EnsureSettingsExist()
        Using conn = DBConnector.GetConnection()
            conn.Open()
            ' On vérifie juste si la table n'est pas vide
            Dim cmdCheck As New MySqlCommand("SELECT COUNT(*) FROM settings", conn)
            Dim count = Convert.ToInt32(cmdCheck.ExecuteScalar())

            If count = 0 Then
                Dim sql As String = "
                    INSERT INTO settings (period1_start, period1_end, period2_start, period2_end, period3_start, period3_end, period4_start, period4_end, lbph_threshold) 
                    VALUES ('07:30', '09:30', '09:45', '11:45', '13:00', '15:00', '15:15', '17:15', 70)"
                Dim cmdInsert As New MySqlCommand(sql, conn)
                cmdInsert.ExecuteNonQuery()
            End If
        End Using
    End Sub



    ' Bouton Reset


End Class