Imports MySqlConnector

Public Class FormSchedule

    ' 1. CHARGEMENT DE LA PAGE
    Private Sub FormSchedule_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ChargerClasses()

        ' Dates par défaut : Semaine courante
        dtpDebut.Value = Date.Today
        dtpFin.Value = Date.Today.AddDays(6)

        ' Mise à l'état par défaut (Tout coché sauf Dimanche)
        ReinitialiserAffichage()
    End Sub

    Private Sub ChargerClasses()
        Try
            Using conn = DBConnector.GetConnection()
                conn.Open()
                Dim cmd As New MySqlCommand("SELECT DISTINCT classe FROM students WHERE classe IS NOT NULL AND classe <> ''", conn)
                Dim rdr = cmd.ExecuteReader()
                cmbClasse.Items.Clear()
                While rdr.Read()
                    cmbClasse.Items.Add(rdr.GetString("classe"))
                End While
                If cmbClasse.Items.Count > 0 Then cmbClasse.SelectedIndex = 0
            End Using
        Catch ex As Exception
            MessageBox.Show("Erreur chargement classes : " & ex.Message)
        End Try
    End Sub

    ' 2. BOUTON CHARGER (AVEC SÉCURITÉ ANTI-DOUBLON DE JOUR)

    Private Sub btnCharger_Click(sender As Object, e As EventArgs) Handles btnCharger.Click
        ' 1. Vérification de la classe
        If cmbClasse.SelectedItem Is Nothing Then
            MessageBox.Show("Veuillez sélectionner une classe.")
            Return
        End If

        Dim dStart = dtpDebut.Value.Date
        Dim dEnd = dtpFin.Value.Date

        ' 2. Vérification de l'ordre des dates
        If dEnd < dStart Then
            MessageBox.Show("La date de fin ne peut pas être antérieure à la date de début.", "Erreur de date", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' 3. SÉCURITÉ : Vérifier si l'intervalle est trop grand (> 7 jours)
        ' Exemple : Du Lundi 2 au Lundi 9 = 8 jours. Le Lundi apparait 2 fois -> Impossible à afficher.
        ' On accepte max 6 jours de différence (ex: Lundi au Dimanche).
        Dim duree = (dEnd - dStart).Days

        If duree >= 7 Then
            MessageBox.Show("Impossible d'afficher cette période car elle contient deux fois le même jour de la semaine (intervalle > 7 jours)." & vbCrLf & vbCrLf &
                            "L'interface ne peut afficher qu'une semaine à la fois pour la visualisation." & vbCrLf &
                            "Veuillez réduire la période.",
                            "Intervalle trop grand", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' 4. On remet tout par défaut (Nettoyage)
        ReinitialiserAffichage()

        Dim classe = cmbClasse.SelectedItem.ToString()
        Dim joursModifies As Integer = 0

        Try
            Using conn = DBConnector.GetConnection()
                conn.Open()

                ' 5. On récupère les configs
                Dim sql = "SELECT schedule_date, p1, p2, p3, p4 FROM schedule " &
                          "WHERE classe=@c AND schedule_date BETWEEN @d1 AND @d2"

                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@c", classe)
                    cmd.Parameters.AddWithValue("@d1", dStart)
                    cmd.Parameters.AddWithValue("@d2", dEnd)

                    Using rdr = cmd.ExecuteReader()
                        While rdr.Read()
                            ' Pour chaque jour trouvé, on met à jour la colonne correspondante
                            Dim dateTrouvee = rdr.GetDateTime("schedule_date")
                            Dim dayIndex = GetUiDayIndex(dateTrouvee.DayOfWeek)

                            SetCheckState(dayIndex, 1, rdr.GetBoolean("p1"))
                            SetCheckState(dayIndex, 2, rdr.GetBoolean("p2"))
                            SetCheckState(dayIndex, 3, rdr.GetBoolean("p3"))
                            SetCheckState(dayIndex, 4, rdr.GetBoolean("p4"))

                            joursModifies += 1
                        End While
                    End Using
                End Using
            End Using

            If joursModifies > 0 Then
                MessageBox.Show($"{joursModifies} jour(s) spécifique(s) chargé(s) pour cette période.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Aucune configuration spécifique trouvée en base de données pour cette période." & vbCrLf &
                                "L'affichage montre la semaine type par défaut.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MessageBox.Show("Erreur : " & ex.Message)
        End Try
    End Sub


    ' 3. BOUTON ENREGISTRER (Avec Sécurités)

    Private Sub btnEnregistrer_Click(sender As Object, e As EventArgs) Handles btnEnregistrer.Click
        If cmbClasse.SelectedIndex < 0 Then
            MessageBox.Show("Sélectionnez une classe.")
            Return
        End If

        ' Sécurité Dates
        If dtpFin.Value.Date < dtpDebut.Value.Date Then
            MessageBox.Show("La date de fin est antérieure à la date de début.")
            Return
        End If

        ' Avertissement Passé
        If dtpDebut.Value.Date < DateTime.Today Then
            MessageBox.Show("Impossible de modifier le planning dans le PASSÉ.")
            Return
        End If

        Dim classe = cmbClasse.SelectedItem.ToString()
        Dim currentDate = dtpDebut.Value.Date
        Dim endDate = dtpFin.Value.Date
        Dim count As Integer = 0

        Try
            Using conn = DBConnector.GetConnection()
                conn.Open()

                Dim sql = "INSERT INTO schedule (classe, schedule_date, p1, p2, p3, p4) 
                           VALUES (@c, @d, @p1, @p2, @p3, @p4)
                           ON DUPLICATE KEY UPDATE p1=@p1, p2=@p2, p3=@p3, p4=@p4"

                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@c", classe)
                    cmd.Parameters.Add("@d", MySqlDbType.Date)
                    cmd.Parameters.Add("@p1", MySqlDbType.Int16)
                    cmd.Parameters.Add("@p2", MySqlDbType.Int16)
                    cmd.Parameters.Add("@p3", MySqlDbType.Int16)
                    cmd.Parameters.Add("@p4", MySqlDbType.Int16)

                    ' BOUCLE : JOUR PAR JOUR
                    While currentDate <= endDate
                        ' 1. Quel colonne regarder ? (0=Lundi ... 6=Dimanche)
                        Dim dayIndex = GetUiDayIndex(currentDate.DayOfWeek)

                        ' 2. Lire les CheckBox correspondantes
                        Dim p1 = GetCheckState(dayIndex, 1)
                        Dim p2 = GetCheckState(dayIndex, 2)
                        Dim p3 = GetCheckState(dayIndex, 3)
                        Dim p4 = GetCheckState(dayIndex, 4)

                        ' 3. Exécuter
                        cmd.Parameters("@d").Value = currentDate
                        cmd.Parameters("@p1").Value = If(p1, 1, 0)
                        cmd.Parameters("@p2").Value = If(p2, 1, 0)
                        cmd.Parameters("@p3").Value = If(p3, 1, 0)
                        cmd.Parameters("@p4").Value = If(p4, 1, 0)

                        cmd.ExecuteNonQuery()

                        currentDate = currentDate.AddDays(1)
                        count += 1
                    End While
                End Using
            End Using

            MessageBox.Show($"Planning enregistré avec succès sur {count} jours !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Erreur sauvegarde : " & ex.Message)
        End Try
    End Sub

    ' 4. OUTILS (HELPERS) POUR GERER LES CASES

    Private Sub ReinitialiserAffichage()
        CocherTout(True)    ' On coche tout le monde

    End Sub

    ' Coche ou décoche TOUTES les cases
    Private Sub CocherTout(etat As Boolean)
        For i = 0 To 6 ' Pour chaque jour
            For j = 1 To 4 ' Pour chaque période
                SetCheckState(i, j, etat)
            Next
        Next
    End Sub

    ' Décoche un jour précis (ex: dayIndex 6 pour Dimanche)
    Private Sub DecocherJour(dayIndex As Integer)
        For j = 1 To 4
            SetCheckState(dayIndex, j, False)
        Next
    End Sub

    ' Trouve si une case est cochée
    Private Function GetCheckState(dayIndex As Integer, periodIndex As Integer) As Boolean
        Dim ctrlName = $"chk_{dayIndex}_{periodIndex}"
        Dim matches = Me.Controls.Find(ctrlName, True)
        If matches.Length > 0 Then Return CType(matches(0), CheckBox).Checked
        Return False
    End Function

    ' Coche/Décoche une case précise par son nom
    Private Sub SetCheckState(dayIndex As Integer, periodIndex As Integer, state As Boolean)
        Dim ctrlName = $"chk_{dayIndex}_{periodIndex}"
        Dim matches = Me.Controls.Find(ctrlName, True)
        If matches.Length > 0 Then
            CType(matches(0), CheckBox).Checked = state
        End If
    End Sub

    ' Mappe les jours .NET (Dimanche=0) vers notre UI (Lundi=0... Dimanche=6)
    Private Function GetUiDayIndex(dw As DayOfWeek) As Integer
        Select Case dw
            Case DayOfWeek.Monday : Return 0
            Case DayOfWeek.Tuesday : Return 1
            Case DayOfWeek.Wednesday : Return 2
            Case DayOfWeek.Thursday : Return 3
            Case DayOfWeek.Friday : Return 4
            Case DayOfWeek.Saturday : Return 5
            Case DayOfWeek.Sunday : Return 6
            Case Else : Return 0
        End Select
    End Function


End Class