Imports MySqlConnector
Imports System.IO ' On garde l'import, mais on précisera System.IO.Path dans le code
Imports iText.Kernel.Pdf
Imports iText.Layout
Imports iText.Layout.Element
Imports iText.Layout.Properties
Imports iText.Kernel.Font
Imports iText.IO.Font.Constants
Imports iText.Kernel.Geom
Imports iText.Kernel.Colors
Imports iText.Layout.Borders

Public Class FormGeneratePDF

    Private Sub FormGeneratePDF_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ChargerListeClasses()
        dtStart.Value = Date.Today.AddDays(-7)
        dtEnd.Value = Date.Today

        ' --- CHARGEMENT DU CHEMIN DE SAUVEGARDE ---
        ' On regarde dans les paramètres. Si vide, on met un dossier par défaut.
        Dim savedPath = My.Settings.PDF_Path
        If String.IsNullOrWhiteSpace(savedPath) Then
            savedPath = System.IO.Path.Combine(Application.StartupPath, "Reports")
        End If

        ' On l'affiche dans la zone de texte qu'on vient d'ajouter
        txtSavePath.Text = savedPath
    End Sub


    ' --- CHARGEMENT DES CLASSES DANS LE COMBOBOX ---
    Private Sub ChargerListeClasses()
        Try
            Using conn = DBConnector.GetConnection()
                conn.Open()
                Dim sql As String = "SELECT DISTINCT classe FROM students WHERE classe IS NOT NULL AND classe <> '' ORDER BY classe"
                Using cmd As New MySqlCommand(sql, conn)
                    Using rdr = cmd.ExecuteReader()
                        cmbClasse.Items.Clear()
                        cmbClasse.Items.Add("-- Sélectionner --")
                        While rdr.Read()
                            cmbClasse.Items.Add(rdr.GetString("classe"))
                        End While
                        cmbClasse.SelectedIndex = 0
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Erreur classes : " & ex.Message)
        End Try
    End Sub

    ' --- CLIC SUR LE BOUTON GÉNÉRER ---
    Private Sub btnGenererPDF_Click(sender As Object, e As EventArgs) Handles btnGenererPDF.Click
        ' A. Vérifications
        If cmbClasse.SelectedIndex <= 0 Then
            MessageBox.Show("Veuillez sélectionner une classe.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If dtEnd.Value.Date < dtStart.Value.Date Then
            MessageBox.Show("La date de fin doit être après la date de début.")
            Return
        End If

        If dtStart.Value.Date > DateTime.Today Then
            MessageBox.Show("Vous ne pouvez pas générer un rapport uniquement dans le futur.", "Information")
            Return
        End If

        ' Vérification que le dossier existe
        If String.IsNullOrWhiteSpace(txtSavePath.Text) OrElse Not Directory.Exists(txtSavePath.Text) Then
            ' Si le dossier n'existe pas, on tente de le créer (cas du dossier par défaut supprimé)
            Try
                Directory.CreateDirectory(txtSavePath.Text)
            Catch
                MessageBox.Show("Le dossier de sauvegarde est invalide. Veuillez en choisir un autre.", "Erreur Chemin", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End Try
        End If

        Dim classeChoisie = cmbClasse.SelectedItem.ToString()

        Try
            ' B. Construction du nom de fichier
            Dim folderPath As String = txtSavePath.Text ' On prend le chemin du TextBox
            Dim fileName As String = $"Rapport_{classeChoisie}_{dtStart.Value:yyyyMMdd}_au_{dtEnd.Value:yyyyMMdd}.pdf"
            Dim fullPath As String = System.IO.Path.Combine(folderPath, fileName)

            ' C. Chargement des données
            Dim planning = ChargerProgrammeSemaine(dtStart.Value.Date, dtEnd.Value.Date, classeChoisie)
            Dim listeEtudiants = ChargerDonneesPeriode(dtStart.Value.Date, dtEnd.Value.Date, classeChoisie)

            ' D. Génération
            GenererPDFDesign(fullPath, listeEtudiants, planning, dtStart.Value.Date, dtEnd.Value.Date, classeChoisie)

            ' E. Succès
            MessageBox.Show("PDF généré avec succès !" & vbCrLf & "Emplacement : " & fullPath, "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information)
            AuditService.Log($"PDF généré pour {classeChoisie} dans {fileName}")

        Catch ex As Exception
            MessageBox.Show("Erreur lors de la génération : " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' --- RÉCUPÉRATION DU PLANNING ---
    Private Function ChargerProgrammeSemaine(dStart As Date, dEnd As Date, classe As String) As Dictionary(Of Date, ProgrammeJour)
        Dim prog As New Dictionary(Of Date, ProgrammeJour)
        Using conn = DBConnector.GetConnection()
            conn.Open()
            Dim sql = "SELECT schedule_date, p1, p2, p3, p4 FROM schedule WHERE classe=@c AND schedule_date BETWEEN @d1 AND @d2"
            Using cmd As New MySqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@c", classe)
                cmd.Parameters.AddWithValue("@d1", dStart)
                cmd.Parameters.AddWithValue("@d2", dEnd)
                Using rdr = cmd.ExecuteReader()
                    While rdr.Read()
                        Dim d = rdr.GetDateTime("schedule_date").Date
                        Dim p As New ProgrammeJour With {
                            .P1 = rdr.GetBoolean("p1"),
                            .P2 = rdr.GetBoolean("p2"),
                            .P3 = rdr.GetBoolean("p3"),
                            .P4 = rdr.GetBoolean("p4")
                        }
                        prog(d) = p
                    End While
                End Using
            End Using
        End Using
        Return prog
    End Function

    ' --- RÉCUPÉRATION DES PRÉSENCES ---
    Private Function ChargerDonneesPeriode(dStart As Date, dEnd As Date, classe As String) As List(Of EtudiantSemaine)
        Dim result As New List(Of EtudiantSemaine)
        Using con = DBConnector.GetConnection()
            con.Open()
            Dim sql As String =
                "SELECT s.id, s.last_name, s.first_name, a.attendance_date, a.p1, a.p2, a.p3, a.p4, a.justification
                 FROM students s
                 LEFT JOIN attendance a ON s.id = a.student_id AND a.attendance_date BETWEEN @d1 AND @d2
                 WHERE s.classe = @cl
                 ORDER BY s.last_name, a.attendance_date;"

            Dim cmd As New MySqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@d1", dStart)
            cmd.Parameters.AddWithValue("@d2", dEnd)
            cmd.Parameters.AddWithValue("@cl", classe)

            Dim rd = cmd.ExecuteReader()
            Dim temp As New Dictionary(Of Integer, EtudiantSemaine)

            While rd.Read()
                Dim id = rd.GetInt32("id")
                If Not temp.ContainsKey(id) Then
                    temp(id) = New EtudiantSemaine With {.Id = id, .NomComplet = rd.GetString("last_name") & " " & rd.GetString("first_name")}
                End If
                If Not IsDBNull(rd("attendance_date")) Then
                    Dim day As Date = rd.GetDateTime("attendance_date")
                    Dim pj As New PresenceJour With {
                        .DateJour = day,
                        .P1 = If(IsDBNull(rd("p1")), False, rd.GetBoolean("p1")),
                        .P2 = If(IsDBNull(rd("p2")), False, rd.GetBoolean("p2")),
                        .P3 = If(IsDBNull(rd("p3")), False, rd.GetBoolean("p3")),
                        .P4 = If(IsDBNull(rd("p4")), False, rd.GetBoolean("p4"))
                    }
                    If Not IsDBNull(rd("justification")) Then pj.Justification = rd.GetString("justification")
                    temp(id).Jours(day) = pj
                End If
            End While
            For Each et In temp.Values : result.Add(et) : Next
        End Using
        Return result
    End Function

    ' --- GÉNÉRATION DU DESIGN PDF (CORRIGÉ SANS CHAÎNAGE) ---
    Private Sub GenererPDFDesign(path As String, etudiants As List(Of EtudiantSemaine), planning As Dictionary(Of Date, ProgrammeJour), dStart As Date, dEnd As Date, classe As String)

        Dim fs As New FileStream(path, FileMode.Create, FileAccess.Write)
        Dim writer As New PdfWriter(fs)
        Dim pdf As New PdfDocument(writer)
        Dim document As New Document(pdf, PageSize.A4.Rotate())

        ' Couleurs et Polices
        Dim colorHeaderBack As New DeviceRgb(41, 128, 185)
        Dim colorHeaderText As Color = ColorConstants.WHITE
        Dim colorRowEven As New DeviceRgb(240, 240, 240)
        Dim boldFont = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD)
        Dim normalFont = PdfFontFactory.CreateFont(StandardFonts.HELVETICA)

        ' CORRECTION "Fin instruction attendue" : On décompose les lignes

        ' 1. Titre
        Dim pTitre As New Paragraph("RAPPORT DE PRÉSENCE")
        pTitre.SetFont(boldFont)
        pTitre.SetFontSize(18)
        pTitre.SetFontColor(colorHeaderBack)
        pTitre.SetTextAlignment(TextAlignment.CENTER)
        document.Add(pTitre)

        ' 2. Classe
        Dim pClasse As New Paragraph("CLASSE : " & classe)
        pClasse.SetFont(boldFont)
        pClasse.SetFontSize(14)
        pClasse.SetTextAlignment(TextAlignment.CENTER)
        document.Add(pClasse)

        ' 3. Date
        Dim pDate As New Paragraph("Période du " & dStart.ToString("dd/MM/yyyy") & " au " & dEnd.ToString("dd/MM/yyyy"))
        pDate.SetFont(normalFont)
        pDate.SetFontSize(10)
        pDate.SetTextAlignment(TextAlignment.CENTER)
        document.Add(pDate)

        document.Add(New Paragraph(" "))

        ' 4. Tableau
        Dim nbJours = (dEnd - dStart).Days + 1
        Dim nbCols = nbJours + 2
        Dim widths(nbCols - 1) As Single
        widths(0) = 4
        For k = 1 To nbJours : widths(k) = 1 : Next
        widths(nbCols - 1) = 1.2

        Dim table As New Table(UnitValue.CreatePercentArray(widths))
        table.SetWidth(UnitValue.CreatePercentValue(100))

        ' En-têtes
        AddHeaderCell(table, "ÉTUDIANTS", boldFont, colorHeaderBack, colorHeaderText)
        For i = 0 To nbJours - 1
            Dim loopDate = dStart.AddDays(i)
            AddHeaderCell(table, loopDate.ToString("ddd dd").ToUpper(), boldFont, colorHeaderBack, colorHeaderText)
        Next
        AddHeaderCell(table, "TOTAL", boldFont, colorHeaderBack, colorHeaderText)

        ' Données
        Dim rowIndex As Integer = 0
        For Each et In etudiants
            Dim totalAbsences As Integer = 0
            Dim bgRow As Color
            If rowIndex Mod 2 = 0 Then
                bgRow = colorRowEven
            Else
                bgRow = ColorConstants.WHITE
            End If

            ' Cellule Nom (Décomposée)
            Dim pNom As New Paragraph(et.NomComplet)
            pNom.SetFont(normalFont)
            pNom.SetFontSize(10)
            Dim cellNom As New Cell()
            cellNom.Add(pNom)
            cellNom.SetBackgroundColor(bgRow)
            table.AddCell(cellNom)

            ' Boucle Jours
            For i = 0 To nbJours - 1
                Dim currDate = dStart.AddDays(i)
                Dim cellContent As String = ""
                Dim cellTextColor As Color = ColorConstants.BLACK

                ' Vérification Planning
                Dim coursPrevu As Boolean = False
                If planning.ContainsKey(currDate) Then
                    Dim prog = planning(currDate)
                    If prog.P1 Or prog.P2 Or prog.P3 Or prog.P4 Then coursPrevu = True
                End If

                If Not coursPrevu Then
                    cellContent = "-"
                    cellTextColor = ColorConstants.GRAY
                Else
                    If et.Jours.ContainsKey(currDate) Then
                        Dim p = et.Jours(currDate)

                        ' Justification Globale
                        If Not String.IsNullOrEmpty(p.Justification) AndAlso (Not p.P1 And Not p.P2 And Not p.P3 And Not p.P4) Then
                            cellContent = "J"
                            cellTextColor = New DeviceRgb(41, 128, 185)
                        Else
                            ' Calcul
                            Dim count = 0
                            ' On évite les IF en une ligne ici pour être sûr
                            If p.P1 Then
                                count += 1
                            Else
                                totalAbsences += 1
                            End If

                            If p.P2 Then
                                count += 1
                            Else
                                totalAbsences += 1
                            End If

                            If p.P3 Then
                                count += 1
                            Else
                                totalAbsences += 1
                            End If

                            If p.P4 Then
                                count += 1
                            Else
                                totalAbsences += 1
                            End If


                            If count = 4 Then
                                cellContent = "•"
                                cellTextColor = New DeviceRgb(39, 174, 96)
                            ElseIf count = 0 Then
                                cellContent = "ABS"
                                cellTextColor = ColorConstants.RED
                            Else
                                cellContent = ""
                                If p.P1 Then cellContent &= "1 "
                                If p.P2 Then cellContent &= "2 "
                                If p.P3 Then cellContent &= "3 "
                                If p.P4 Then cellContent &= "4 "
                            End If
                        End If
                    Else
                        ' Pas de ligne
                        If currDate.Date > DateTime.Today Then
                            cellContent = "-"
                            cellTextColor = ColorConstants.GRAY
                        Else
                            cellContent = "ABS"
                            cellTextColor = ColorConstants.RED
                            totalAbsences += 4
                        End If
                    End If
                End If

                ' Ajout Cellule Jour (Décomposée)
                Dim pDay As New Paragraph(cellContent)
                pDay.SetFont(normalFont)
                pDay.SetFontSize(9)
                pDay.SetFontColor(cellTextColor)
                pDay.SetTextAlignment(TextAlignment.CENTER)

                Dim cellDay As New Cell()
                cellDay.Add(pDay)
                cellDay.SetBackgroundColor(bgRow)
                table.AddCell(cellDay)
            Next

            ' Cellule Total (Décomposée)
            Dim pTotal As New Paragraph(totalAbsences.ToString())
            pTotal.SetFont(boldFont)
            pTotal.SetTextAlignment(TextAlignment.CENTER)

            Dim cellTotal As New Cell()
            cellTotal.Add(pTotal)
            cellTotal.SetBackgroundColor(bgRow)
            If totalAbsences > 0 Then cellTotal.SetFontColor(ColorConstants.RED)

            table.AddCell(cellTotal)

            rowIndex += 1
        Next

        document.Add(table)

        ' Légende
        document.Add(New Paragraph(" "))
        Dim pLegend As New Paragraph("Légende : • = Présent | ABS = Absent | J = Justifié | - = Pas de cours")
        pLegend.SetFont(normalFont)
        pLegend.SetFontSize(8)
        pLegend.SetFontColor(ColorConstants.GRAY)
        document.Add(pLegend)

        document.Close()
    End Sub

    ' Helper pour l'en-tête (Décomposé aussi)
    Private Sub AddHeaderCell(tbl As Table, text As String, font As PdfFont, bg As Color, fg As Color)
        Dim p As New Paragraph(text)
        p.SetFont(font)
        p.SetFontSize(9)
        p.SetFontColor(fg)
        p.SetTextAlignment(TextAlignment.CENTER)

        Dim c As New Cell()
        c.Add(p)
        c.SetBackgroundColor(bg)

        tbl.AddHeaderCell(c)
    End Sub



    Private Sub btnBrowsePDF_Click(sender As Object, e As EventArgs)
        Using fd As New FolderBrowserDialog
            If fd.ShowDialog = DialogResult.OK Then
                txtSavePath.Text = fd.SelectedPath
            End If
        End Using

    End Sub

    Private Sub btnBrowsePDF_Click_1(sender As Object, e As EventArgs) Handles btnBrowsePDF.Click
        Using fbd As New FolderBrowserDialog()
            ' On propose le dossier actuel comme point de départ
            fbd.SelectedPath = txtSavePath.Text

            If fbd.ShowDialog() = DialogResult.OK Then
                ' 1. Mettre à jour l'affichage
                txtSavePath.Text = fbd.SelectedPath

                ' 2. Sauvegarder ce choix pour la prochaine fois (Mémoire)
                My.Settings.PDF_Path = fbd.SelectedPath
                My.Settings.Save()
            End If
        End Using
    End Sub
End Class

' Classe Helper
Public Class ProgrammeJour
    Public P1 As Boolean = False
    Public P2 As Boolean = False
    Public P3 As Boolean = False
    Public P4 As Boolean = False
End Class