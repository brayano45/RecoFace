
Public Class FormStudents
    Private selectedUserId As Integer = -1

    Private selectedId As Integer = -1

    Private Sub FormStudents_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadStudents()
    End Sub

    Private Sub LoadStudents()
        dgStudents.DataSource = StudentService.GetAllStudents()
        dgStudents.Columns("id").Visible = False
    End Sub

    Private Sub ClearFields()
        txtMatricule.Clear()
        txtNom.Clear()
        txtPrenom.Clear()
        txtClasse.SelectedIndex = -1
        selectedId = -1
    End Sub

    Private Sub dgStudents_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgStudents.CellClick
        If e.RowIndex >= 0 Then
            Dim row = dgStudents.Rows(e.RowIndex)
            selectedId = row.Cells("id").Value
            txtMatricule.Text = row.Cells("matricule").Value.ToString()
            txtNom.Text = row.Cells("last_name").Value.ToString()
            txtPrenom.Text = row.Cells("first_name").Value.ToString()
            txtClasse.SelectedItem = row.Cells("classe").Value.ToString()
        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If txtMatricule.Text = "" Or txtNom.Text = "" Or txtPrenom.Text = "" Or txtClasse.SelectedItem = "" Then
            MessageBox.Show("Veuillez remplir tous les champs.")
            Exit Sub
        End If


        If txtMatricule.Text.Trim().Length < 4 Then
            MessageBox.Show("Matricule trop court")
            Exit Sub
        End If

        Try
            StudentService.AddStudent(txtMatricule.Text, txtNom.Text, txtPrenom.Text, txtClasse.SelectedItem)
            LoadStudents()
            ClearFields()
            MessageBox.Show("Étudiant ajouté avec succès !")
            AuditService.Log($"Ajout étudiant : {txtMatricule.Text} - {txtNom.Text}")
        Catch ex As Exception
            If ex.Message.Contains("Duplicate") Then
                MessageBox.Show("Cet Etudiant(e) existe déjà.")
            Else
                MessageBox.Show("Erreur : " & ex.Message)

            End If
        End Try
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click

        If selectedId = -1 Then
            MessageBox.Show("Sélectionnez un étudiant.")
            Exit Sub
        End If

        Try
            StudentService.UpdateStudent(selectedId, txtMatricule.Text, txtNom.Text, txtPrenom.Text, txtClasse.SelectedItem)
            LoadStudents()
            MessageBox.Show("Modification réussie !")
            AuditService.Log($"modifcation de  étudiant : {txtMatricule.Text} - {txtNom.Text}")
        Catch ex As Exception
            MessageBox.Show("Erreur : " & ex.Message)
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

        If selectedId = -1 Then
            MessageBox.Show("Sélectionnez un étudiant.")
            Exit Sub
        End If

        If MessageBox.Show("Voulez-vous vraiment supprimer cet étudiant ?",
                           "Confirmation",
                           MessageBoxButtons.YesNo,
                           MessageBoxIcon.Warning) = DialogResult.Yes Then

            Try
                StudentService.DeleteStudent(selectedId)
                AuditService.Log($"suppression de étudiant : {txtMatricule.Text} - {txtNom.Text}")
                LoadStudents()
                ClearFields()
                MessageBox.Show("Étudiant supprimé.")
            Catch ex As Exception
                MessageBox.Show("Erreur : " & ex.Message)
            End Try

        End If
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        dgStudents.DataSource = StudentService.SearchStudents(txtSearch.Text.Trim())
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearFields()
    End Sub

    Private Sub txtSearch_Click(sender As Object, e As EventArgs) Handles txtSearch.Click
        txtSearch.Clear()
    End Sub


End Class