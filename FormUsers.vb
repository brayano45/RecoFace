Imports MySqlConnector

Public Class FormUsers
    Private selectedUserId As Integer = -1


    ' CHARGEMENT

    Private Sub FormUsers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Sélection par défaut dans la liste
        cmbRole.SelectedIndex = 1 ' Responsable par défaut

        ConfigGrid()
        LoadUsers()
        ClearFields()
    End Sub

    Private Sub ConfigGrid()
        dgUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgUsers.MultiSelect = False
        dgUsers.AllowUserToAddRows = False
        dgUsers.ReadOnly = True
        dgUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    End Sub

    Private Sub LoadUsers()
        Try
            Using conn = DBConnector.GetConnection()
                conn.Open()
                ' 1. On récupère aussi la colonne ROLE
                Dim sql As String = "SELECT id, username, role, created_at, is_active FROM admins ORDER BY id DESC"

                Dim dt As New DataTable()
                Using cmd As New MySqlCommand(sql, conn)
                    Using da As New MySqlDataAdapter(cmd)
                        da.Fill(dt)
                    End Using
                End Using

                dgUsers.AutoGenerateColumns = False
                dgUsers.Columns.Clear()

                ' Colonnes ID (Invisible)
                Dim colId As New DataGridViewTextBoxColumn()
                colId.DataPropertyName = "id"
                colId.Name = "ID"
                colId.Visible = False
                dgUsers.Columns.Add(colId)

                ' Colonne Username
                Dim colUser As New DataGridViewTextBoxColumn()
                colUser.DataPropertyName = "username"
                colUser.HeaderText = "Utilisateur"
                dgUsers.Columns.Add(colUser)

                ' --- NOUVELLE COLONNE ROLE ---
                Dim colRole As New DataGridViewTextBoxColumn()
                colRole.DataPropertyName = "role"
                colRole.Name = "role" ' Important pour le formatage
                colRole.HeaderText = "Fonction"
                dgUsers.Columns.Add(colRole)
                ' -----------------------------

                ' Colonne Date
                Dim colDate As New DataGridViewTextBoxColumn()
                colDate.DataPropertyName = "created_at"
                colDate.HeaderText = "Créé le"
                dgUsers.Columns.Add(colDate)

                ' Colonne Etat
                Dim colEtat As New DataGridViewTextBoxColumn()
                colEtat.DataPropertyName = "is_active"
                colEtat.Name = "is_active"
                colEtat.HeaderText = "État"
                dgUsers.Columns.Add(colEtat)

                dgUsers.DataSource = dt
            End Using
        Catch ex As Exception
            MessageBox.Show("Erreur de chargement : " & ex.Message)
        End Try
    End Sub


    ' FORMATAGE VISUEL ROBUSTE (CORRIGÉ)

    Private Sub dgUsers_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgUsers.CellFormatting

        ' --- 1. GESTION ACTIF / BLOQUÉ ---
        If dgUsers.Columns(e.ColumnIndex).Name = "is_active" AndAlso e.Value IsNot Nothing AndAlso Not IsDBNull(e.Value) Then

            ' CORRECTION : On convertit en texte minuscule et on teste tous les cas possibles
            Dim rawVal As String = e.Value.ToString().ToLower()

            ' Si c'est "1" (chiffre) OU "true" (booléen), alors c'est ACTIF
            If rawVal = "1" OrElse rawVal = "true" Then
                e.Value = "Actif"
                e.CellStyle.ForeColor = Color.Green
            Else
                e.Value = "Bloqué"
                e.CellStyle.ForeColor = Color.Red
                e.CellStyle.Font = New Font(e.CellStyle.Font, FontStyle.Bold)
            End If

            e.FormattingApplied = True
        End If

        ' --- 2. GESTION DU RÔLE (ADMIN/RESPONSABLE) ---
        If dgUsers.Columns(e.ColumnIndex).Name = "role" AndAlso e.Value IsNot Nothing Then
            Dim roleCode = e.Value.ToString().ToLower() ' ToLower pour être sûr

            If roleCode = "admin" Then
                e.Value = "Administrateur"
                e.CellStyle.Font = New Font(e.CellStyle.Font, FontStyle.Bold)
            ElseIf roleCode = "responsable" Then
                e.Value = "Responsable Filière"
            Else
                e.Value = roleCode ' Affiche tel quel si inconnu
            End If

            e.FormattingApplied = True
        End If

    End Sub

    Private Sub dgUsers_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgUsers.DataError
        e.ThrowException = False
        e.Cancel = True
    End Sub


    ' SELECTION ET REMPLISSAGE FORMULAIRE
    Private Sub dgUsers_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgUsers.CellClick
        If e.RowIndex < 0 Then Return

        Dim row = dgUsers.Rows(e.RowIndex)
        selectedUserId = CInt(row.Cells(0).Value) ' ID est en index 0
        txtUsername.Text = row.Cells(1).Value.ToString() ' Username en 1

        txtPassword.Text = ""
        txtPassword.PlaceholderText = "Laisser vide..."

        ' Sélectionner le bon rôle dans la liste déroulante
        Dim dbRole = row.Cells(2).Value.ToString() ' Role en index 2
        If dbRole = "admin" Then
            cmbRole.SelectedItem = "Administrateur"
        Else
            cmbRole.SelectedItem = "Responsable de filière"
        End If

        ' Bouton Bloquer
        Dim val As Integer = 0
        Try
            val = Convert.ToInt32(row.Cells(4).Value) ' is_active en index 4
        Catch
        End Try

        If val = 1 Then
            btnToggleBlock.Text = "Bloquer 🔒"
            btnToggleBlock.BackColor = Color.Salmon
        Else
            btnToggleBlock.Text = "Débloquer 🔓"
            btnToggleBlock.BackColor = Color.LightGreen
        End If
    End Sub


    ' AJOUTER (CREATE)
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If txtUsername.Text.Trim() = "" Or txtPassword.Text.Trim() = "" Then
            MessageBox.Show("Nom et mot de passe requis.")
            Return
        End If

        ' Déterminer le code rôle à enregistrer (admin ou responsable)
        Dim roleToSave As String = "responsable"
        If cmbRole.SelectedItem IsNot Nothing AndAlso cmbRole.SelectedItem.ToString() = "Administrateur" Then
            roleToSave = "admin"
        End If

        Try
            Using connCheck = DBConnector.GetConnection()
                connCheck.Open()
                Dim cmdCheck As New MySqlCommand("SELECT COUNT(*) FROM admins WHERE username = @u", connCheck)
                cmdCheck.Parameters.AddWithValue("@u", txtUsername.Text.Trim())
                Dim count = Convert.ToInt32(cmdCheck.ExecuteScalar())
                If count > 0 Then
                    MessageBox.Show("Ce nom d'utilisateur est déjà pris.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If
            End Using

            Using conn = DBConnector.GetConnection()
                conn.Open()
                Dim hash = SecurityHelper.SHA256Hash(txtPassword.Text.Trim())

                ' On insère le role
                Dim sql As String = "INSERT INTO admins (username, password_hash, role, is_active) VALUES (@u, @p, @r, 1)"

                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@u", txtUsername.Text.Trim())
                    cmd.Parameters.AddWithValue("@p", hash)
                    cmd.Parameters.AddWithValue("@r", roleToSave)
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("Utilisateur ajouté.")
            AuditService.Log("Ajout de l'utilisateur : " & txtUsername.Text)

            LoadUsers()
            ClearFields()
        Catch ex As Exception
            MessageBox.Show("Erreur : " & ex.Message)
        End Try
    End Sub

    ' MODIFIER (UPDATE)
    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If selectedUserId = -1 Then Return

        Dim roleToSave As String = "responsable"
        If cmbRole.SelectedItem IsNot Nothing AndAlso cmbRole.SelectedItem.ToString() = "Administrateur" Then
            roleToSave = "admin"
        End If

        Try
            Using conn = DBConnector.GetConnection()
                conn.Open()
                Dim sql As String = ""

                ' On ajoute le role dans l'update
                If txtPassword.Text.Trim() <> "" Then
                    sql = "UPDATE admins SET username=@u, password_hash=@p, role=@r WHERE id=@id"
                Else
                    sql = "UPDATE admins SET username=@u, role=@r WHERE id=@id"
                End If

                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@u", txtUsername.Text.Trim())
                    cmd.Parameters.AddWithValue("@r", roleToSave)
                    cmd.Parameters.AddWithValue("@id", selectedUserId)

                    If txtPassword.Text.Trim() <> "" Then
                        Dim hash = SecurityHelper.SHA256Hash(txtPassword.Text.Trim())
                        cmd.Parameters.AddWithValue("@p", hash)
                    End If

                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("Utilisateur modifié.")
            AuditService.Log("Modification de l'utilisateur : " & txtUsername.Text)
            LoadUsers()
            ClearFields()
        Catch ex As Exception
            MessageBox.Show("Erreur : " & ex.Message)
        End Try
    End Sub

    ' ---------------------------------------------------------
    ' AUTRES
    ' ---------------------------------------------------------
    Private Sub btnToggleBlock_Click(sender As Object, e As EventArgs) Handles btnToggleBlock.Click
        If selectedUserId = -1 Then Return

        ' Empêcher de se bloquer soi-même
        If selectedUserId = Session.CurrentAdminId Then
            MessageBox.Show("Vous ne pouvez pas bloquer  votre propre compte !", "Sécurité")
            Return
        End If
        Try
            Using conn = DBConnector.GetConnection()
                conn.Open()
                Dim sql As String = "UPDATE admins SET is_active = NOT is_active WHERE id=@id"
                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@id", selectedUserId)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            LoadUsers()
            ClearFields()
        Catch ex As Exception
            MessageBox.Show("Erreur : " & ex.Message)
            AuditService.Log($"Modification statut (Bloqué/Débloqué) pour l'ID {selectedUserId}")
        End Try
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearFields()
    End Sub

    Private Sub ClearFields()
        selectedUserId = -1
        txtUsername.Clear()
        txtPassword.Clear()
        cmbRole.SelectedIndex = 1 ' Remettre sur Responsable
        btnToggleBlock.Text = "Bloquer / Débloquer"
        btnToggleBlock.BackColor = SystemColors.Control
        dgUsers.ClearSelection()
    End Sub
End Class