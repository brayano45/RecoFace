Imports MySqlConnector

Public Class FormPresences
    Private selectedPresenceId As Integer = -1

    ' =========================================================================
    ' 1. INITIALISATION ET CHARGEMENT
    ' =========================================================================
    Private Sub FormPresences_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Initialiser les dates à aujourd'hui
        dtStart.Value = Date.Today
        dtEnd.Value = Date.Today

        ' Charger la liste des classes dans le ComboBox
        ChargerListeClasses()

        ' Charger la grille
        LoadGrid()
    End Sub

    Private Sub ChargerListeClasses()
        Try
            Using conn = DBConnector.GetConnection()
                conn.Open()
                ' On récupère les classes distinctes
                Dim sql As String = "SELECT DISTINCT classe FROM students WHERE classe IS NOT NULL AND classe <> '' ORDER BY classe"

                Using cmd As New MySqlCommand(sql, conn)
                    Using rdr = cmd.ExecuteReader()
                        txtFiltreClasse.Items.Clear()
                        txtFiltreClasse.Items.Add("") ' Option vide pour tout afficher
                        While rdr.Read()
                            txtFiltreClasse.Items.Add(rdr.GetString("classe"))
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Erreur chargement classes : " & ex.Message)
        End Try
    End Sub

    ' 2. CHARGEMENT DE LA GRILLE (LE COEUR DU SYSTÈME)
    Private Sub LoadGrid()
        Try
            ' A. HYDRATATION : On s'assure que les lignes existent pour la période
            ' (Appelle la fonction intelligente qui vérifie le planning)
            Dim currentDate = dtStart.Value.Date
            While currentDate <= dtEnd.Value.Date
                PresenceService.EnsureRowsExistForDate(currentDate)
                currentDate = currentDate.AddDays(1)
            End While

            ' B. RÉCUPÉRATION DES DONNÉES
            ' On récupère la valeur de la classe sélectionnée (ou vide)
            Dim classeFiltre As String = ""
            If txtFiltreClasse.SelectedItem IsNot Nothing Then
                classeFiltre = txtFiltreClasse.SelectedItem.ToString()
            Else
                classeFiltre = txtFiltreClasse.Text.Trim()
            End If

            ' Appel avec les 4 paramètres corrects
            Dim dt = PresenceService.GetPresencesForStudent(
                txtSearchStudent.Text.Trim(),
                classeFiltre,
                dtStart.Value.Date,
                dtEnd.Value.Date
            )

            dgPresences.DataSource = dt

            ' C. ESTHÉTIQUE
            FormatGrid()

        Catch ex As Exception
            MessageBox.Show("Erreur chargement grille : " & ex.Message)
        End Try
    End Sub

    Private Sub FormatGrid()
        ' Masquer les colonnes techniques
        Dim colsToHide() As String = {"id", "student_id", "sched_p1", "sched_p2", "sched_p3", "sched_p4"}
        For Each col In colsToHide
            If dgPresences.Columns(col) IsNot Nothing Then dgPresences.Columns(col).Visible = False
        Next

        ' Renommer les colonnes visibles
        If dgPresences.Columns("classe") IsNot Nothing Then dgPresences.Columns("classe").HeaderText = "Classe"
        If dgPresences.Columns("matricule") IsNot Nothing Then dgPresences.Columns("matricule").HeaderText = "Matricule"
        If dgPresences.Columns("last_name") IsNot Nothing Then dgPresences.Columns("last_name").HeaderText = "Nom"
        If dgPresences.Columns("first_name") IsNot Nothing Then dgPresences.Columns("first_name").HeaderText = "Prénom"
        If dgPresences.Columns("attendance_date") IsNot Nothing Then dgPresences.Columns("attendance_date").HeaderText = "Date"
        If dgPresences.Columns("justification") IsNot Nothing Then dgPresences.Columns("justification").HeaderText = "Justificatif"
        If dgPresences.Columns("p1") IsNot Nothing Then dgPresences.Columns("p1").HeaderText = "P1"
        If dgPresences.Columns("p2") IsNot Nothing Then dgPresences.Columns("p2").HeaderText = "P2"
        If dgPresences.Columns("p3") IsNot Nothing Then dgPresences.Columns("p3").HeaderText = "P3"
        If dgPresences.Columns("p4") IsNot Nothing Then dgPresences.Columns("p4").HeaderText = "P4"
    End Sub

    ' =========================================================================
    ' 3. GESTION VISUELLE (GRISER LES CASES SANS COURS)
    ' =========================================================================
    Private Sub dgPresences_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgPresences.CellFormatting
        If e.RowIndex < 0 Then Return

        Dim colName = dgPresences.Columns(e.ColumnIndex).Name

        ' Si on est sur une colonne P1, P2, P3 ou P4
        If {"p1", "p2", "p3", "p4"}.Contains(colName) Then
            Dim row = dgPresences.Rows(e.RowIndex)
            Dim schedColName = "sched_" & colName ' ex: sched_p1

            ' On vérifie si la colonne planning existe (cachée) et si elle dit FALSE
            If dgPresences.Columns.Contains(schedColName) AndAlso Not IsDBNull(row.Cells(schedColName).Value) Then
                Dim coursPrevu As Boolean = Convert.ToBoolean(row.Cells(schedColName).Value)

                If coursPrevu = False Then
                    ' On grise la case pour dire "Pas cours"
                    e.CellStyle.BackColor = Color.LightGray
                    e.CellStyle.ForeColor = Color.DarkGray
                    e.CellStyle.SelectionBackColor = Color.Gray
                End If
            End If
        End If
    End Sub

    ' Empêcher de modifier une case grisée
    Private Sub dgPresences_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgPresences.CellContentClick
        If e.RowIndex < 0 Then Return

        ' Commit immédiat pour avoir la valeur à jour
        dgPresences.CommitEdit(DataGridViewDataErrorContexts.Commit)

        Dim colName = dgPresences.Columns(e.ColumnIndex).Name
        If {"p1", "p2", "p3", "p4"}.Contains(colName) Then
            Dim row = dgPresences.Rows(e.RowIndex)
            Dim schedColName = "sched_" & colName

            If dgPresences.Columns.Contains(schedColName) AndAlso Not IsDBNull(row.Cells(schedColName).Value) Then
                If Convert.ToBoolean(row.Cells(schedColName).Value) = False Then
                    MessageBox.Show("Aucun cours n'est programmé sur cette période.", "Hors planning", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ' On recharge pour annuler le clic visuellement
                    LoadGrid()
                End If
            End If
        End If
    End Sub

    ' =========================================================================
    ' 4. INTERACTIONS ET BOUTONS
    ' =========================================================================

    ' Sélection d'une ligne -> Remplir les champs en bas
    Private Sub dgPresences_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgPresences.CellClick
        If e.RowIndex < 0 Then Exit Sub
        Dim row = dgPresences.Rows(e.RowIndex)

        selectedPresenceId = CInt(row.Cells("id").Value)

        lblSelectedStudent.Text = row.Cells("matricule").Value.ToString() & " - " & row.Cells("last_name").Value.ToString()
        dtDate.Value = CDate(row.Cells("attendance_date").Value)

        chkP1.Checked = If(IsDBNull(row.Cells("p1").Value), False, CBool(row.Cells("p1").Value))
        chkP2.Checked = If(IsDBNull(row.Cells("p2").Value), False, CBool(row.Cells("p2").Value))
        chkP3.Checked = If(IsDBNull(row.Cells("p3").Value), False, CBool(row.Cells("p3").Value))
        chkP4.Checked = If(IsDBNull(row.Cells("p4").Value), False, CBool(row.Cells("p4").Value))

        If dgPresences.Columns.Contains("justification") AndAlso Not IsDBNull(row.Cells("justification").Value) Then
            txtJustification.Text = row.Cells("justification").Value.ToString()
        Else
            txtJustification.Text = ""
        End If
    End Sub

    ' Bouton ENREGISTRER (Modification manuelle)
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If selectedPresenceId = -1 Then
            MessageBox.Show("Veuillez sélectionner une ligne dans le tableau.")
            Return
        End If

        PresenceService.UpdatePresence(
            selectedPresenceId,
            chkP1.Checked,
            chkP2.Checked,
            chkP3.Checked,
            chkP4.Checked,
            txtJustification.Text.Trim()
        )

        MessageBox.Show("Mise à jour effectuée.")
        LoadGrid()
    End Sub

    ' Boutons de Filtre
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        LoadGrid()
    End Sub
    Private Sub btnFilter_Click(sender As Object, e As EventArgs) Handles btnFilter.Click
        LoadGrid()
    End Sub

    ' Rafraîchissement automatique quand on change les dates
    Private Sub dtStart_ValueChanged(sender As Object, e As EventArgs) Handles dtStart.ValueChanged
        LoadGrid()
    End Sub
    Private Sub dtEnd_ValueChanged(sender As Object, e As EventArgs) Handles dtEnd.ValueChanged
        LoadGrid()
    End Sub

    ' Bouton VIDER
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        selectedPresenceId = -1
        lblSelectedStudent.Text = "—"
        chkP1.Checked = False : chkP2.Checked = False : chkP3.Checked = False : chkP4.Checked = False
        txtJustification.Clear()
        dgPresences.ClearSelection()
    End Sub

    ' Bouton SUPPRIMER (Attention : Supprime la ligne de présence)
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If selectedPresenceId = -1 Then
            MessageBox.Show("Sélectionnez une ligne.")
            Return
        End If
        If MessageBox.Show("Voulez-vous vraiment supprimer cette ligne ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
            PresenceService.DeletePresence(selectedPresenceId)
            LoadGrid()
            btnClear.PerformClick()
        End If
    End Sub

End Class