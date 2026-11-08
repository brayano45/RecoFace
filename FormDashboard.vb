Imports System.Runtime
Imports System.Speech.Synthesis
Imports Emgu.CV.Cuda.CudaVideoWriter
Imports iText.StyledXmlParser.Jsoup.Select.Evaluator
Imports Microsoft.VisualBasic.ApplicationServices
Imports MySqlConnector
Imports Windows.Win32.System

Public Class FormDashboard
    ' Variables de classe
    Private AdminID As Integer
    Public CurrentUserRole As String
    Public CurrentUsername As String
    Private currentBtn As Button ' Pour se souvenir quel bouton est actif
    Private colorNormal As Color = Color.FromArgb(190, 230, 253)
    Private colorActive As Color = Color.FromArgb(26, 59, 85)
    Private speaker As New SpeechSynthesizer()

    ' --- CORRECTION ICI : Regarde bien ce qui est entre parenthèses ---
    ' On déclare 3 paramètres : anId, unNom, unRole
    Public Sub New(anId As Integer, unNom As String, unRole As String)

        ' Cet appel est requis par le concepteur Windows Form.
        InitializeComponent()

        ' On remplit les variables avec les valeurs reçues
        Me.AdminID = anId
        Me.CurrentUsername = unNom
        Me.CurrentUserRole = unRole

        Dim rdm As New Random
        Dim choix As Integer = rdm.Next(1, 5)
        Select Case choix
            Case 1
                Dire($"bienvenue {CurrentUsername}, promis, aucune donnée n'a été maltraitée pendant votre absence")
            Case 2
                Dire($"bienvenus {CurrentUsername}, Authentification acceptée. Initialisation du système.")
            Case 3
                Dire($"bienvenue {CurrentUsername}, les données sont prêtes pour votre utilisation")
            Case 4
                Dire($"bienvenue {CurrentUsername}, votre environnement de travail a été chargé avec succès")
        End Select

        ' On met à jour l'affichage
        lblAdminName.Text = Me.CurrentUsername
        Dim usee As New tableau
        monPanel.Controls.Add(usee)
        ' TEST (A retirer plus tard) :
        'MessageBox.Show("Bienvenue " & unNom)
    End Sub
    Private Sub AfficherFormDansPanel(childForm As Form)
        ' 1. Vider le panel de tout contenu précédent
        monPanel.Controls.Clear()

        ' 2. Configurer le formulaire enfant
        childForm.TopLevel = False  ' PAS une fenêtre indépendante
        childForm.FormBorderStyle = FormBorderStyle.None  ' Sans bordure
        childForm.Dock = DockStyle.Fill  ' Remplit tout le panel

        ' 3. Ajouter le formulaire au panel
        monPanel.Controls.Add(childForm)

        ' 4. Mettre au premier plan
        childForm.BringToFront()

        ' 5. Afficher le formulaire
        childForm.Show()
    End Sub

    Private Sub LoadPage(page As UserControl)
        PanelMain.Controls.Clear()
        page.Dock = DockStyle.Fill
        PanelMain.Controls.Add(page)
    End Sub

    Private Sub btnStudents_Click(sender As Object, e As EventArgs) Handles btnStudents.Click
        lblStat.Text = "Gérez vos Etudiants"
        AfficherFormDansPanel(New FormStudents())
    End Sub

    Private Sub btnEnroll_Click(sender As Object, e As EventArgs) Handles btnEnroll.Click
        lblStat.Text = "Capturer les visages de vos Etudiants"
        AfficherFormDansPanel(New FormCameraEnroll())
    End Sub



    Private Sub btnPresences_Click(sender As Object, e As EventArgs) Handles btnPresences.Click
        lblStat.Text = "Gérez les présences des Etudiants"
        AfficherFormDansPanel(New FormPresences())
    End Sub

    Private Sub btnPDF_Click(sender As Object, e As EventArgs) Handles btnPDF.Click
        lblStat.Text = "Génération PDF..."
        AfficherFormDansPanel(New FormGeneratePDF())
    End Sub

    Private Sub btnSettings_Click(sender As Object, e As EventArgs) Handles btnSettings.Click
        lblStat.Text = "Gérer les paramètres de l'application"
        AfficherFormDansPanel(New FormSettings)
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        ' 1. On affiche le Login
        FormLogin.Show()

        ' 2. On CACHE le dashboard 
        Me.Hide()
    End Sub

    Private Sub btnTrain_Click(sender As Object, e As EventArgs) Handles btnTrain.Click
        If RecognizerService.Train() Then
            MessageBox.Show("Modèle entraîné avec succès !")
        End If
    End Sub

    Private Sub FormDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If RecognizerService.ModelExists() Then
            lblModelStatus.Text = "Modèle LBPH : OK ✔"
            lblModelStatus.ForeColor = Color.Green
        Else
            lblModelStatus.Text = "Modèle LBPH : Manquant ❌"
            lblModelStatus.ForeColor = Color.Red
        End If
        TimerCheckPeriods.Interval = 60000
        TimerCheckPeriods.Start()
        TimerCheckPeriods.Start()

        ' --- GESTION DES DROITS (Cacher le bouton Utilisateurs si pas admin) ---

        If CurrentUserRole <> "admin" Then
            btnUsers.Visible = False
            btnSettings.Visible = False
        End If

        ' On applique la magie à tous les boutons du panel Menu
        For Each ctrl As Control In Panel1.Controls
            If TypeOf ctrl Is Button Then
                Dim btn As Button = CType(ctrl, Button)

                ' On attache les événements dynamiquement

                AddHandler btn.Click, AddressOf Button_Click

                ' Style de base
                btn.BackColor = colorNormal
                btn.ForeColor = Color.Black
                btn.FlatStyle = FlatStyle.Flat
                btn.FlatAppearance.BorderSize = 0
            End If
        Next

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

    ' Timer qui tourne toutes les minutes
    Private Sub TimerCheckPeriods_Tick(sender As Object, e As EventArgs) Handles TimerCheckPeriods.Tick
        CheckPeriods()

        ' Reset journalier de la table period_closure (existait déjà dans ton code)
        Static lastDay As Date = DateTime.Now.Date
        If DateTime.Now.Date <> lastDay Then
            Using conn = DBConnector.GetConnection()
                conn.Open()
                Using cmd As New MySqlCommand("DELETE FROM period_closure", conn)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            lastDay = DateTime.Now.Date
        End If
    End Sub

    ' ---------------------------------------------------------
    ' NOUVELLE VERSION DE CHECKPERIODS (DYNAMIQUE)
    ' ---------------------------------------------------------
    Private Sub CheckPeriods()
        Dim p1End As TimeSpan
        Dim p2End As TimeSpan
        Dim p3End As TimeSpan
        Dim p4End As TimeSpan

        ' 1. On récupère les heures de fin réelles depuis la BDD
        Try
            Using conn = DBConnector.GetConnection()
                conn.Open()
                Dim sql = "SELECT period1_end, period2_end, period3_end, period4_end FROM settings LIMIT 1"
                Using cmd As New MySqlCommand(sql, conn)
                    Using rdr = cmd.ExecuteReader()
                        If rdr.Read() Then
                            p1End = rdr.GetTimeSpan("period1_end")
                            p2End = rdr.GetTimeSpan("period2_end")
                            p3End = rdr.GetTimeSpan("period3_end")
                            p4End = rdr.GetTimeSpan("period4_end")
                        Else
                            ' Sécurité si la BDD est vide (valeurs par défaut)
                            p1End = TimeSpan.Parse("09:50")
                            p2End = TimeSpan.Parse("12:00")
                            p3End = TimeSpan.Parse("14:50")
                            p4End = TimeSpan.Parse("17:00")
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            ' Si erreur de connexion, on ne fait rien cette fois-ci
            Return
        End Try

        ' 2. On compare l'heure actuelle avec les heures de la BDD
        Dim nowTime = DateTime.Now.TimeOfDay

        ' --- P1 ---
        ' On ajoute une petite marge de 5 minutes après la fin pour laisser le temps de pointer aux retardataires
        If nowTime > p1End.Add(TimeSpan.FromMinutes(5)) AndAlso Not IsPeriodClosed(1) Then
            ClosePeriod(1)
        End If

        ' --- P2 ---
        If nowTime > p2End.Add(TimeSpan.FromMinutes(5)) AndAlso Not IsPeriodClosed(2) Then
            ClosePeriod(2)
        End If

        ' --- P3 ---
        If nowTime > p3End.Add(TimeSpan.FromMinutes(5)) AndAlso Not IsPeriodClosed(3) Then
            ClosePeriod(3)
        End If

        ' --- P4 ---
        If nowTime > p4End.Add(TimeSpan.FromMinutes(5)) AndAlso Not IsPeriodClosed(4) Then
            ClosePeriod(4)
        End If
    End Sub

    Private Sub ClosePeriod(periodIndex As Integer)
        Dim col = $"p{periodIndex}"

        Try
            Using conn = DBConnector.GetConnection()
                conn.Open()

                Dim sql =
                $"UPDATE attendance 
                  SET {col} = 0 
                  WHERE attendance_date=@d 
                    AND {col} IS NULL"

                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@d", DateTime.Now.Date)
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MarkPeriodClosed(periodIndex)
            LogAudit(Nothing, $"Fermeture période P{periodIndex}")
            MessageBox.Show($"Période P{periodIndex} clôturée automatiquement.")

        Catch ex As Exception
            MessageBox.Show("Erreur fermeture période : " & ex.Message)
        End Try
    End Sub

    Private Function IsPeriodClosed(periodIndex As Integer) As Boolean
        Using conn = DBConnector.GetConnection()
            conn.Open()
            Dim sql =
            "SELECT 1 FROM period_closure WHERE period=@p AND closure_date=@d LIMIT 1"
            Using cmd As New MySqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@p", periodIndex)
                cmd.Parameters.AddWithValue("@d", DateTime.Now.Date)
                Dim res = cmd.ExecuteScalar()
                Return res IsNot Nothing
            End Using
        End Using
    End Function

    Private Sub MarkPeriodClosed(periodIndex As Integer)
        Using conn = DBConnector.GetConnection()
            conn.Open()
            Dim sql =
            "INSERT IGNORE INTO period_closure(period, closure_date) VALUES(@p,@d)"
            Using cmd As New MySqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@p", periodIndex)
                cmd.Parameters.AddWithValue("@d", DateTime.Now.Date)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Private Sub LogAudit(adminId As Integer?, action As String)
        Try
            Using conn = DBConnector.GetConnection()
                conn.Open()
                Dim sql = "INSERT INTO audit_logs(admin_id, action) VALUES(@a, @act)"
                Using cmd As New MySqlCommand(sql, conn)
                    If adminId.HasValue Then
                        cmd.Parameters.AddWithValue("@a", adminId.Value)
                    Else
                        cmd.Parameters.AddWithValue("@a", DBNull.Value)
                    End If
                    cmd.Parameters.AddWithValue("@act", action)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch
            ' ignore
        End Try
    End Sub

    Private Sub FormDashboard_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        ' Arrête proprement tous les timers
        TimerCheckPeriods.Stop()

        ' Force l'arrêt de tous les formulaires et threads en arrière-plan
        Application.Exit()
    End Sub

    Private Sub btnUsers_Click(sender As Object, e As EventArgs) Handles btnUsers.Click
        lblStat.Text = "Gerez vos Utilisateurs"
        AfficherFormDansPanel(New FormUsers())
    End Sub

    Private Sub btnLogs_Click(sender As Object, e As EventArgs) Handles btnLogs.Click
        lblStat.Text = "Consulter l'historique de connexion"
        AfficherFormDansPanel(New FormAudit())
    End Sub

    Private Sub Button_Click(sender As Object, e As EventArgs)
        Dim btn As Button = CType(sender, Button)

        ' 1. On "éteint" l'ancien bouton actif s'il y en a un
        If currentBtn IsNot Nothing Then
            currentBtn.BackColor = colorNormal
            currentBtn.Padding = New Padding(10, 0, 0, 0)
        End If

        ' 2. On "allume" le nouveau
        currentBtn = btn
        currentBtn.BackColor = colorActive
        currentBtn.Padding = New Padding(25, 0, 0, 0) ' Il reste décalé pour montrer qu'il est actif

        ' ICI, TU METTRAS TA LOGIQUE DE NAVIGATION EXISTANTE
        ' Ex: If btn.Name = "btnStudents" Then ...
    End Sub



    Private Sub btnSchedule_Click(sender As Object, e As EventArgs) Handles btnSchedule.Click
        lblStat.Text = "Planifier les periodes de cours"
        AfficherFormDansPanel(New FormSchedule())
    End Sub

    Private Sub btnDashboard_Click(sender As Object, e As EventArgs) Handles btnDashboard.Click
        monPanel.Controls.Clear()

        Dim usee As New tableau
        monPanel.Controls.Add(usee)
    End Sub
End Class