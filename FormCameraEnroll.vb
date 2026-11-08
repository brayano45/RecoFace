Imports System.IO
Imports System.Speech.Synthesis
Imports Emgu.CV
Imports Emgu.CV.BitmapExtension
Imports Emgu.CV.CvEnum
Imports Emgu.CV.Structure
Imports MySqlConnector

Public Class FormCameraEnroll

    ' Variables Caméra
    Private videoCapture As VideoCapture = Nothing
    Private faceCascade As CascadeClassifier = Nothing
    Private isCapturing As Boolean = False
    Private speaker As New SpeechSynthesizer()
    ' Stockage temporaire des captures
    Private capturedFaces As New List(Of Bitmap)()
    Private capturedFaceMats As New List(Of Mat)()

    ' Chemins
    Private cascadeFile As String = Path.Combine(Application.StartupPath, "haarcascade_frontalface_default.xml")
    Private trainingRoot As String = Path.Combine(Application.StartupPath, "TrainingImages")

    ' 1. CHARGEMENT
    Private Sub FormCameraEnroll_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Vérification Cascade
        If Not File.Exists(cascadeFile) Then
            MessageBox.Show("Fichier cascade introuvable : " & vbCrLf & cascadeFile)
            btnStart.Enabled = False
            Return
        End If
        faceCascade = New CascadeClassifier(cascadeFile)

        ' Config UI
        numTarget.Value = 20
        lblCount.Text = "0 / 20"

        ' Charger la liste des étudiants avec leur statut
        LoadEnrollmentList()
    End Sub

    ' --- CHARGEMENT DU TABLEAU DES ÉTUDIANTS ---
    Private Sub LoadEnrollmentList(Optional keyword As String = "")
        Try
            Using conn = DBConnector.GetConnection()
                conn.Open()
                ' Compte les photos pour chaque étudiant
                Dim sql = "SELECT s.id, s.matricule, s.last_name, s.first_name, COUNT(t.id) as photos_count " &
                          "FROM students s " &
                          "LEFT JOIN training_images t ON s.id = t.student_id " &
                          "WHERE s.matricule LIKE @k OR s.last_name LIKE @k " &
                          "GROUP BY s.id ORDER BY photos_count DESC, s.last_name ASC"

                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@k", "%" & keyword & "%")
                    Dim dt As New DataTable()
                    Using da As New MySqlDataAdapter(cmd)
                        da.Fill(dt)
                    End Using

                    dgEnrolled.DataSource = dt
                End Using
            End Using

            ' Formatage
            dgEnrolled.Columns("id").Visible = False
            dgEnrolled.Columns("matricule").HeaderText = "Matricule"
            dgEnrolled.Columns("last_name").HeaderText = "Nom"
            dgEnrolled.Columns("first_name").HeaderText = "Prénom"
            dgEnrolled.Columns("photos_count").HeaderText = "Photos"
            dgEnrolled.Columns("photos_count").Width = 60

        Catch ex As Exception
            MessageBox.Show("Erreur chargement liste : " & ex.Message)
        End Try
    End Sub

    ' --- RECHERCHE DYNAMIQUE ---
    Private Sub txtSearchEnroll_TextChanged(sender As Object, e As EventArgs) Handles txtSearchEnroll.TextChanged
        LoadEnrollmentList(txtSearchEnroll.Text.Trim())
    End Sub

    ' --- SÉLECTION D'UN ÉTUDIANT DANS LA LISTE ---
    Private Sub dgEnrolled_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgEnrolled.CellClick
        If e.RowIndex < 0 Then Return

        Dim row = dgEnrolled.Rows(e.RowIndex)
        Dim mat = row.Cells("matricule").Value.ToString()
        Dim count = Convert.ToInt32(row.Cells("photos_count").Value)

        txtMatricule.Text = mat

        If count > 0 Then
            lblStatus.Text = $"Cet étudiant est DÉJÀ enrôlé ({count} photos)."
            lblStatus.ForeColor = Color.Green
            btnSaveSet.Enabled = False
            btnDeleteEnroll.Enabled = True
        Else
            lblStatus.Text = "Étudiant non enrôlé. Prêt à capturer."
            lblStatus.ForeColor = Color.Blue
            btnSaveSet.Enabled = True
            btnDeleteEnroll.Enabled = False
        End If
    End Sub

    ' --- FORMATAGE VISUEL ---
    Private Sub dgEnrolled_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgEnrolled.CellFormatting
        If dgEnrolled.Columns(e.ColumnIndex).Name = "photos_count" Then
            Dim val = Convert.ToInt32(e.Value)
            If val = 0 Then
                e.CellStyle.BackColor = Color.MistyRose
                e.CellStyle.ForeColor = Color.Red
            Else
                e.CellStyle.BackColor = Color.LightGreen
                e.CellStyle.ForeColor = Color.DarkGreen
            End If
        End If
    End Sub

    ' 2. GESTION CAMÉRA
    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        Try
            If videoCapture Is Nothing Then
                videoCapture = New VideoCapture(0, VideoCapture.API.DShow)
                videoCapture.Set(CapProp.FrameWidth, 640)
                videoCapture.Set(CapProp.FrameHeight, 480)
            End If
            AddHandler Application.Idle, AddressOf ProcessFrame
            isCapturing = True
            btnStart.Enabled = False
            btnStop.Enabled = True
            btnCapture.Enabled = True
            lblStatus.Text = "Caméra démarrée"
            Dire("Caméra démarrée")
        Catch ex As Exception
            MessageBox.Show("Erreur caméra : " & ex.Message)
            Dire("erreur détectée")
        End Try
    End Sub

    Private Sub btnStop_Click(sender As Object, e As EventArgs) Handles btnStop.Click
        StopCapture()
    End Sub

    Private Sub StopCapture()
        If isCapturing Then
            RemoveHandler Application.Idle, AddressOf ProcessFrame
            isCapturing = False
        End If
        If videoCapture IsNot Nothing Then
            videoCapture.Dispose()
            videoCapture = Nothing
        End If
        btnStart.Enabled = True
        btnStop.Enabled = False
        btnCapture.Enabled = False
        PictureBoxCamera.Image = Nothing
        lblStatus.Text = "Caméra arrêtée"
        Dire("Caméra arretée")
    End Sub

    Private Sub ProcessFrame(sender As Object, e As EventArgs)
        If Not isCapturing OrElse videoCapture Is Nothing Then Return
        Using frame As Mat = videoCapture.QueryFrame()
            If frame Is Nothing Then Return

            Dim imageBgr = frame.Clone()
            Dim imageGray As New Mat()
            CvInvoke.CvtColor(imageBgr, imageGray, ColorConversion.Bgr2Gray)

            ' UTILISER LE MODULE DE TRAITEMENT STANDARDISÉ
            ImageProcessingModule.PretraitementStandard(imageGray)

            ' DÉTECTION AVEC PARAMÈTRES OPTIMISÉS
            Dim faces() As Rectangle = ImageProcessingModule.DetecterVisages(faceCascade, imageGray)

            ' FILTRER LES CHEVAUCHEMENTS
            faces = ImageProcessingModule.FiltrerChevauchements(faces)

            ' Dessiner les rectangles
            For Each r As Rectangle In faces
                ' Couleur selon le nombre de visages
                Dim color As New MCvScalar(0, 255, 0) ' Vert si OK
                If faces.Length > 1 Then
                    color = New MCvScalar(0, 165, 255) ' Orange si multiple
                End If
                CvInvoke.Rectangle(imageBgr, r, color, 2)

                ' Afficher la taille du visage
                CvInvoke.PutText(imageBgr, $"{r.Width}x{r.Height}",
                           New Point(r.X, r.Y - 10),
                           FontFace.HersheySimplex, 0.5, color, 1)
            Next

            Dim bmp As Bitmap = imageBgr.ToBitmap()
            If PictureBoxCamera.Image IsNot Nothing Then
                Dim old = PictureBoxCamera.Image
                PictureBoxCamera.Image = Nothing
                old.Dispose()
            End If
            PictureBoxCamera.Image = bmp
        End Using
    End Sub

    Private Sub btnCapture_Click(sender As Object, e As EventArgs) Handles btnCapture.Click
        If videoCapture Is Nothing Then Return
        If Not btnSaveSet.Enabled Then
            MessageBox.Show("Veuillez supprimer l'enrôlement existant ou choisir un autre étudiant.", "Attention")
            Return
        End If

        Using frame As Mat = videoCapture.QueryFrame()
            If frame Is Nothing Then Return

            Dim gray As New Mat()
            CvInvoke.CvtColor(frame, gray, ColorConversion.Bgr2Gray)

            ' PRÉTRAITEMENT STANDARDISÉ
            ImageProcessingModule.PretraitementStandard(gray)

            ' DÉTECTION OPTIMISÉE
            Dim faces() As Rectangle = ImageProcessingModule.DetecterVisages(faceCascade, gray)
            faces = ImageProcessingModule.FiltrerChevauchements(faces)

            If faces.Length = 0 Then
                lblStatus.Text = "❌ Aucun visage détecté. Approchez-vous."
                lblStatus.ForeColor = Color.Red
                Dire("Approchez vous")
                Return
            End If

            If faces.Length > 1 Then
                lblStatus.Text = "⚠️ Plusieurs visages détectés. Une seule personne."
                lblStatus.ForeColor = Color.Orange
                Dire("Une seule personne s'il vous plaît")
                Return
            End If

            Dim rect As Rectangle = faces(0)

            ' VÉRIFIER LA TAILLE MINIMALE
            If rect.Width < ImageProcessingModule.MIN_FACE_SIZE Then
                lblStatus.Text = $"⚠️ Visage trop petit ({rect.Width}px). Min: {ImageProcessingModule.MIN_FACE_SIZE}px"
                lblStatus.ForeColor = Color.Orange
                Dire("Approchez vous davantage")
                Return
            End If

            ' EXTRAIRE LE VISAGE
            Dim faceMat As New Mat(gray, rect)

            ' PRÉPARER POUR SAUVEGARDE
            Dim faceResized = ImageProcessingModule.PreparerVisagePourReconnaissance(faceMat)
            faceMat.Dispose()

            Dim bmpFace As Bitmap = faceResized.ToBitmap()
            capturedFaces.Add(CType(bmpFace.Clone(), Bitmap))
            capturedFaceMats.Add(faceResized.Clone())

            Dim thumb As New PictureBox()
            thumb.SizeMode = PictureBoxSizeMode.Zoom
            thumb.Width = 90
            thumb.Height = 90
            thumb.Image = bmpFace
            FlowPanelThumbs.Controls.Add(thumb)

            lblCount.Text = $"{capturedFaces.Count} / {numTarget.Value}"
            lblStatus.Text = $"✅ Photo {capturedFaces.Count} capturée"
            lblStatus.ForeColor = Color.Green

            ' Feedback vocal
            If capturedFaces.Count < numTarget.Value Then
                Dire("Photo prise. Bougez légèrement la tête.")
            Else
                lblStatus.Text = "✅ Nombre atteint. Sauvegardez !"
                lblStatus.ForeColor = Color.Green
                Dire("Terminé. Veuillez sauvegarder.")
            End If
        End Using
    End Sub



    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearCaptures()
    End Sub

    Private Sub ClearCaptures()
        For Each ctrl As Control In FlowPanelThumbs.Controls
            ctrl.Dispose()
        Next
        FlowPanelThumbs.Controls.Clear()
        capturedFaces.Clear()
        capturedFaceMats.Clear()
        lblCount.Text = $"0 / {numTarget.Value}"
        lblStatus.Text = "Prêt"
    End Sub

    ' 3. SAUVEGARDE ET SUPPRESSION (AVEC TRAÇABILITÉ/AUDIT)
    Private Sub btnSaveSet_Click(sender As Object, e As EventArgs) Handles btnSaveSet.Click
        If txtMatricule.Text.Trim() = "" Then
            MessageBox.Show("Sélectionnez un étudiant.")

            Return
        End If
        If capturedFaceMats.Count = 0 Then
            MessageBox.Show("Aucune photo capturée.")
            Return
        End If

        Dim studentId As Integer = GetStudentIdByMatricule(txtMatricule.Text)
        If studentId = -1 Then Return

        Dim studentFolder As String = Path.Combine(trainingRoot, studentId.ToString())
        If Not Directory.Exists(studentFolder) Then Directory.CreateDirectory(studentFolder)

        Try
            Using conn = DBConnector.GetConnection()
                conn.Open()
                For i As Integer = 0 To capturedFaceMats.Count - 1
                    Dim timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss_fff")
                    Dim filename = $"img_{timestamp}_{i}.jpg"
                    Dim fullpath = Path.Combine(studentFolder, filename)

                    capturedFaceMats(i).Save(fullpath)

                    Dim relPath = Path.Combine("TrainingImages", studentId.ToString(), filename)
                    Dim sql = "INSERT INTO training_images (student_id, image_path) VALUES (@sid, @path)"
                    Using cmd As New MySqlCommand(sql, conn)
                        cmd.Parameters.AddWithValue("@sid", studentId)
                        cmd.Parameters.AddWithValue("@path", relPath)
                        cmd.ExecuteNonQuery()
                    End Using
                Next
            End Using

            ' --- AUDIT LOG ---
            AuditService.Log($"Enrôlement de l'étudiant {txtMatricule.Text} ({capturedFaceMats.Count} photos)")

            MessageBox.Show("Enrôlement réussi !", "Succès")
            Dire("nouvel enrôlement effectué, veuillez entraîner le modèle")
            ClearCaptures()
            LoadEnrollmentList()

            ' Lancer l'entraînement auto
            RecognizerService.Train()

        Catch ex As Exception
            MessageBox.Show("Erreur sauvegarde : " & ex.Message)
        End Try
    End Sub

    Private Sub btnDeleteEnroll_Click(sender As Object, e As EventArgs) Handles btnDeleteEnroll.Click
        If txtMatricule.Text = "" Then Return

        Dim rep = MessageBox.Show($"Supprimer l'enrôlement de {txtMatricule.Text} ?",
                                  "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

        If rep = DialogResult.Yes Then
            Dim studentId = GetStudentIdByMatricule(txtMatricule.Text)
            If studentId = -1 Then Return

            Try
                ' 1. BDD
                Using conn = DBConnector.GetConnection()
                    conn.Open()
                    Dim sql = "DELETE FROM training_images WHERE student_id = @id"
                    Using cmd As New MySqlCommand(sql, conn)
                        cmd.Parameters.AddWithValue("@id", studentId)
                        cmd.ExecuteNonQuery()
                    End Using
                End Using

                ' 2. Physique
                Dim folder = Path.Combine(trainingRoot, studentId.ToString())
                If Directory.Exists(folder) Then
                    Directory.Delete(folder, True)
                End If

                ' --- AUDIT LOG ---
                AuditService.Log($"Suppression de l'enrôlement de l'étudiant {txtMatricule.Text}")

                MessageBox.Show("Enrôlement supprimé.")
                LoadEnrollmentList()
                btnSaveSet.Enabled = True
                lblStatus.Text = "Prêt pour ré-enrôlement."

                ' Ré-entraîner pour oublier ce visage
                RecognizerService.Train()

            Catch ex As Exception
                MessageBox.Show("Erreur suppression : " & ex.Message)
            End Try
        End If
    End Sub

    Private Function GetStudentIdByMatricule(mat As String) As Integer
        Using conn = DBConnector.GetConnection()
            conn.Open()
            Dim cmd As New MySqlCommand("SELECT id FROM students WHERE matricule=@m", conn)
            cmd.Parameters.AddWithValue("@m", mat)
            Dim res = cmd.ExecuteScalar()
            If res IsNot Nothing Then Return Convert.ToInt32(res)
        End Using
        Return -1
    End Function

    Private Sub FormCameraEnroll_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        StopCapture()
        If faceCascade IsNot Nothing Then faceCascade.Dispose()
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