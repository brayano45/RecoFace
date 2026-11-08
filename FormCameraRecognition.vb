Imports System.IO
' AJOUT POUR LA PAROLE
Imports System.Speech.Synthesis
Imports Emgu.CV
Imports Emgu.CV.CvEnum
Imports Emgu.CV.Face
Imports Emgu.CV.Face.FaceRecognizer
Imports Emgu.CV.Structure
Imports MySqlConnector

Public Class FormCameraRecognition
    Private cam As VideoCapture = Nothing
    Private faceCascade As CascadeClassifier = Nothing
    Private isCapturing As Boolean = False
    Private recognizer As LBPHFaceRecognizer = Nothing
    Private cascadeFile As String = Path.Combine(Application.StartupPath, "haarcascade_frontalface_default.xml")
    Private lastFrame As Mat = Nothing

    ' DÉCLARATION DU SYNTHETISEUR VOCAL
    Private speaker As New SpeechSynthesizer()

    Private Sub FormCameraRecognition_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Configuration de la voix
        Try
            speaker.Volume = 100 ' Volume max (0-100)
            speaker.Rate = 0     ' Vitesse normale (-10 à 10)
        Catch ex As Exception
            ' Pas grave si ça échoue
        End Try

        If Not File.Exists(cascadeFile) Then
            MessageBox.Show("Cascade introuvable : " & cascadeFile)
            btnStart.Enabled = False
            btnScan.Enabled = False
            Return
        End If

        faceCascade = New CascadeClassifier(cascadeFile)

        ' Charger modèle si existant
        recognizer = RecognizerService.LoadRecognizer()
        If recognizer Is Nothing Then
            lblStatus.Text = "Aucun modèle d'entraînement trouvé."
            lblStatus.ForeColor = Color.Red
        Else
            lblStatus.Text = "Système prêt. Connectez votre enceinte Bluetooth."
            lblStatus.ForeColor = Color.Green
        End If
    End Sub

    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        Try
            If cam Is Nothing Then
                cam = New VideoCapture(0, VideoCapture.API.DShow)
                cam.Set(CapProp.FrameWidth, 640)
                cam.Set(CapProp.FrameHeight, 480)
            End If
            AddHandler Application.Idle, AddressOf ProcessFrame
            isCapturing = True
            btnStart.Enabled = False
            btnStop.Enabled = True
            btnScan.Enabled = True
            lblStatus.Text = "Caméra active"
        Catch ex As Exception
            MessageBox.Show("Erreur démarrage caméra : " & ex.Message)
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
        If cam IsNot Nothing Then
            cam.Dispose()
            cam = Nothing
        End If
        btnStart.Enabled = True
        btnStop.Enabled = False
        btnScan.Enabled = False
        lblStatus.Text = "Caméra arrêtée"
        pictureBoxCamera.Image = Nothing
    End Sub

    Private Sub ProcessFrame(sender As Object, e As EventArgs)
        If Not isCapturing OrElse cam Is Nothing Then Return

        Using frame As Mat = cam.QueryFrame()
            If frame Is Nothing Then Return

            If lastFrame IsNot Nothing Then lastFrame.Dispose()
            lastFrame = frame.Clone()

            Dim imageBgr = frame.Clone()
            Dim imageGray As New Mat()
            CvInvoke.CvtColor(imageBgr, imageGray, ColorConversion.Bgr2Gray)

            ' PRÉTRAITEMENT STANDARDISÉ
            ImageProcessingModule.PretraitementStandard(imageGray)

            ' DÉTECTION OPTIMISÉE
            Dim faces() As Rectangle = ImageProcessingModule.DetecterVisages(faceCascade, imageGray)
            faces = ImageProcessingModule.FiltrerChevauchements(faces)

            ' Dessiner avec indicateurs
            For Each r As Rectangle In faces
                Dim color As New MCvScalar(0, 255, 0)
                If faces.Length > 1 Then color = New MCvScalar(0, 165, 255)

                CvInvoke.Rectangle(imageBgr, r, color, 2)
                CvInvoke.PutText(imageBgr, $"{r.Width}px",
                           New Point(r.X, r.Y - 10),
                           FontFace.HersheySimplex, 0.5, color, 1)
            Next

            Dim bmp As Bitmap = imageBgr.ToBitmap()
            If pictureBoxCamera.Image IsNot Nothing Then
                Dim old = pictureBoxCamera.Image
                pictureBoxCamera.Image = Nothing
                old.Dispose()
            End If
            pictureBoxCamera.Image = bmp
        End Using
    End Sub
    Private Sub btnScan_Click(sender As Object, e As EventArgs) Handles btnScan.Click
        If cam Is Nothing Then
            Dire("Veuillez démarrer la caméra")
            Return
        End If
        If recognizer Is Nothing Then
            Dire("Erreur, aucun modèle chargé")
            Return
        End If
        If lastFrame Is Nothing Then
            lblStatus.Text = "Erreur : Pas d'image reçue."
            Return
        End If

        Using frame As Mat = lastFrame.Clone()
            Dim gray As New Mat()
            CvInvoke.CvtColor(frame, gray, ColorConversion.Bgr2Gray)

            ' PRÉTRAITEMENT STANDARDISÉ
            ImageProcessingModule.PretraitementStandard(gray)

            ' DÉTECTION OPTIMISÉE
            Dim faces() As Rectangle = ImageProcessingModule.DetecterVisages(faceCascade, gray)
            faces = ImageProcessingModule.FiltrerChevauchements(faces)

            If faces.Length = 0 Then
                lblStatus.Text = "❌ Aucun visage détecté."
                lblStatus.ForeColor = Color.Red
                Dire("Approchez vous")
                Return
            End If

            If faces.Length > 1 Then
                lblStatus.Text = "⚠️ Plusieurs visages détectés."
                lblStatus.ForeColor = Color.Orange
                Dire("Une seule personne s'il vous plaît")
                Return
            End If

            Dim rect As Rectangle = faces(0)

            ' VÉRIFIER LA TAILLE
            If rect.Width < ImageProcessingModule.MIN_FACE_SIZE Then
                lblStatus.Text = $"⚠️ Visage trop petit ({rect.Width}px)"
                lblStatus.ForeColor = Color.Orange
                Dire("Approchez vous")
                Return
            End If

            ' EXTRAIRE LE VISAGE
            Dim faceMat As New Mat(gray, rect)

            ' PRÉPARER POUR RECONNAISSANCE
            Dim faceResized = ImageProcessingModule.PreparerVisagePourReconnaissance(faceMat)
            faceMat.Dispose()

            ' RECONNAISSANCE AVEC VALIDATION MULTI-PRÉDICTIONS
            Dim predictions As New List(Of PredictionResult)()

            ' Faire 3 prédictions
            For i = 0 To 2
                Dim result = recognizer.Predict(faceResized)
                predictions.Add(result)
            Next

            ' Calculer la moyenne et l'écart-type des distances
            Dim distances = predictions.Select(Function(p) p.Distance).ToList()
            Dim avgDistance = distances.Average()
            Dim stdDev = Math.Sqrt(distances.Select(Function(d) Math.Pow(d - avgDistance, 2)).Average())

            ' Vérifier la cohérence des prédictions
            Dim labels = predictions.Select(Function(p) p.Label).Distinct().ToList()
            Dim isConsistent = labels.Count = 1

            Dim label As Integer = predictions(0).Label
            Dim threshold As Double = GetLBPHThreshold()

            ' Debug console
            Console.WriteLine($"ID: {label} - Distance moy: {avgDistance:F1} - Écart: {stdDev:F1} - Seuil: {threshold} - Cohérent: {isConsistent}")

            ' VALIDATION STRICTE
            Dim isRecognized As Boolean = (label >= 0 AndAlso
                                   avgDistance < threshold AndAlso
                                   isConsistent AndAlso
                                   stdDev < 15.0)

            If isRecognized Then
                Dim infos = GetStudentInfo(label)
                Dim studentName = infos(0)
                Dim matricule = infos(1)
                Dim classe = infos(2)

                LoadFaceThumb(label)

                Dim periodIndex = GetCurrentPeriodIndex()
                If periodIndex = -1 Then
                    lblStatus.Text = $"✅ Reconnu : {studentName} | HORS COURS"
                    lblStatus.ForeColor = Color.Orange
                    Dire($"Salut {SplitName(studentName)}. Vous n'avez pas cours maintenant.")

                    lblStudent.Text = studentName
                    lblMatricule.Text = $"Matricule: {matricule}"
                    lblConfidence.Text = $"Distance : {Math.Round(avgDistance, 1)} (σ:{Math.Round(stdDev, 1)})"
                    lblPeriod.Text = "Hors période"
                    Return
                End If

                If Not IsClassScheduled(classe, periodIndex) Then
                    lblStatus.Text = $"⚠️ Pas de cours P{periodIndex} pour {classe}"
                    lblStatus.ForeColor = Color.Orange
                    Dire($"Bonjour {SplitName(studentName)}. Vous n'avez pas cours.")

                    lblStudent.Text = studentName
                    lblMatricule.Text = $"Matricule: {matricule}"
                    lblConfidence.Text = $"Distance : {Math.Round(avgDistance, 1)}"
                    lblPeriod.Text = $"P{periodIndex} (pas de cours)"
                    Return
                End If

                Dim res = MarkPresence(label, periodIndex)
                If res = 1 Then
                    lblStatus.Text = $"✅ PRÉSENCE : {studentName}"
                    lblStatus.ForeColor = Color.Green
                    Dire($"Bienvenue {SplitName(studentName)}, Présence validée.")
                ElseIf res = 2 Then
                    lblStatus.Text = $"⚠️ DÉJÀ MARQUÉ : {studentName}"
                    lblStatus.ForeColor = Color.Orange
                    Dire($"Salut {SplitName(studentName)}. Présence déjà marquée.")
                Else
                    lblStatus.Text = "❌ Erreur SQL."
                    lblStatus.ForeColor = Color.Red
                End If

                lblStudent.Text = studentName
                lblMatricule.Text = $"Matricule: {matricule}"
                lblConfidence.Text = $"Distance : {Math.Round(avgDistance, 1)} | σ:{Math.Round(stdDev, 1)}"
                lblPeriod.Text = $"Période : P{periodIndex}"
            Else
                ' DÉTERMINER LA RAISON DU REJET
                Dim raison As String = ""
                If Not isConsistent Then
                    raison = "Prédictions incohérentes"
                ElseIf avgDistance >= threshold Then
                    raison = $"Distance trop élevée ({Math.Round(avgDistance, 1)} >= {threshold})"
                ElseIf stdDev >= 15.0 Then
                    raison = $"Trop de variation (σ:{Math.Round(stdDev, 1)})"
                Else
                    raison = "Visage inconnu"
                End If

                lblStatus.Text = $"❌ NON RECONNU - {raison}"
                lblStatus.ForeColor = Color.Red
                pictureBoxFaceThumb.Image = Nothing
                lblStudent.Text = "Inconnu"
                lblMatricule.Text = ""
                lblConfidence.Text = $"Distance : {Math.Round(avgDistance, 1)} | σ:{Math.Round(stdDev, 1)}"
                lblPeriod.Text = ""

                Dire("Visage non reconnu.")
            End If

            faceResized.Dispose()
        End Using
    End Sub


    ' --- FONCTIONS UTILES ---

    Private Function SplitName(fullName As String) As String
        If String.IsNullOrEmpty(fullName) Then Return ""
        Dim parts = fullName.Split(" "c)
        If parts.Length > 0 Then Return parts(0)
        Return fullName
    End Function

    Private Sub Dire(texte As String)
        Try
            If speaker.State = SynthesizerState.Speaking Then
                speaker.SpeakAsyncCancelAll()
            End If
            speaker.SpeakAsync(texte)
        Catch
        End Try
    End Sub

    ' --- ACCÈS BASE DE DONNÉES ---

    Private Function GetLBPHThreshold() As Double
        Try
            Using conn = DBConnector.GetConnection()
                conn.Open()
                Dim sql = "SELECT lbph_threshold FROM settings LIMIT 1"
                Using cmd As New MySqlCommand(sql, conn)
                    Dim res = cmd.ExecuteScalar()
                    If res IsNot Nothing Then Return Convert.ToDouble(res)
                End Using
            End Using
        Catch
        End Try
        Return 70.0
    End Function

    ' Récupère Nom, Matricule et Classe en une seule requête
    Private Function GetStudentInfo(studentId As Integer) As String()
        Try
            Using conn = DBConnector.GetConnection()
                conn.Open()
                Dim sql = "SELECT CONCAT(first_name, ' ', last_name), matricule, classe FROM students WHERE id=@id LIMIT 1"
                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@id", studentId)
                    Using rdr = cmd.ExecuteReader()
                        If rdr.Read() Then
                            Return {rdr.GetString(0), rdr.GetString(1), rdr.GetString(2)}
                        End If
                    End Using
                End Using
            End Using
        Catch
        End Try
        Return {"Étudiant", "", ""}
    End Function

    Private Sub LoadFaceThumb(studentId As Integer)
        Try
            Using conn = DBConnector.GetConnection()
                conn.Open()
                Dim sql = "SELECT image_path FROM training_images WHERE student_id=@id LIMIT 1"
                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@id", studentId)
                    Dim relPath = Convert.ToString(cmd.ExecuteScalar())
                    If Not String.IsNullOrEmpty(relPath) Then
                        Dim fullPath = Path.Combine(Application.StartupPath, relPath)
                        If File.Exists(fullPath) Then
                            Using fs = New FileStream(fullPath, FileMode.Open, FileAccess.Read)
                                pictureBoxFaceThumb.Image = Image.FromStream(fs)
                            End Using
                        End If
                    End If
                End Using
            End Using
        Catch
            pictureBoxFaceThumb.Image = Nothing
        End Try
    End Sub

    ' Vérifie l'heure système
    Private Function GetCurrentPeriodIndex() As Integer
        Try
            Using conn = DBConnector.GetConnection()
                conn.Open()
                Dim sql = "SELECT period1_start, period1_end, period2_start, period2_end, period3_start, period3_end, period4_start, period4_end FROM settings LIMIT 1"
                Using cmd As New MySqlCommand(sql, conn)
                    Using rdr = cmd.ExecuteReader()
                        If rdr.Read() Then
                            Dim nowT = DateTime.Now.TimeOfDay
                            If nowT >= rdr.GetTimeSpan("period1_start") AndAlso nowT <= rdr.GetTimeSpan("period1_end") Then Return 1
                            If nowT >= rdr.GetTimeSpan("period2_start") AndAlso nowT <= rdr.GetTimeSpan("period2_end") Then Return 2
                            If nowT >= rdr.GetTimeSpan("period3_start") AndAlso nowT <= rdr.GetTimeSpan("period3_end") Then Return 3
                            If nowT >= rdr.GetTimeSpan("period4_start") AndAlso nowT <= rdr.GetTimeSpan("period4_end") Then Return 4
                        End If
                    End Using
                End Using
            End Using
        Catch
        End Try
        Return -1
    End Function

    ' Vérifie le Planning (Schedule) : Est-ce qu'il y a cours ce jour-là pour cette classe ?
    Private Function IsClassScheduled(classe As String, periodIndex As Integer) As Boolean
        Try
            Using conn = DBConnector.GetConnection()
                conn.Open()
                Dim col = $"p{periodIndex}" ' p1, p2...
                Dim sql = $"SELECT {col} FROM schedule WHERE classe=@c AND schedule_date=@d LIMIT 1"

                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@c", classe)
                    cmd.Parameters.AddWithValue("@d", DateTime.Today)

                    Dim res = cmd.ExecuteScalar()

                    ' Si pas de ligne ou si la valeur est 0 (False) -> Pas de cours
                    If res Is Nothing OrElse IsDBNull(res) Then Return False ' Par sécurité, pas de planning = pas de cours ? Ou True par défaut ? À toi de voir. Ici je mets False.

                    Return Convert.ToBoolean(res)
                End Using
            End Using
        Catch ex As Exception
            Return True ' En cas d'erreur, on laisse passer pour ne pas bloquer
        End Try
    End Function

    ' --- CORRECTION DU BUG DBNull ICI ---
    Private Function MarkPresence(studentId As Integer, periodIndex As Integer) As Integer
        Try
            Dim col = $"p{periodIndex}"
            Dim colTime = $"p{periodIndex}_time"

            Using conn = DBConnector.GetConnection()
                conn.Open()
                ' 1. Vérifier si déjà présent
                Dim qCheck = $"SELECT {col} FROM attendance WHERE student_id=@sid AND attendance_date=@d"
                Using cmdCheck As New MySqlCommand(qCheck, conn)
                    cmdCheck.Parameters.AddWithValue("@sid", studentId)
                    cmdCheck.Parameters.AddWithValue("@d", DateTime.Now.Date)
                    Dim val = cmdCheck.ExecuteScalar()

                    ' CORRECTION : On vérifie Not IsDBNull(val)
                    If val IsNot Nothing AndAlso Not IsDBNull(val) Then
                        If Convert.ToInt32(val) = 1 Then
                            Return 2 ' Déjà marqué
                        End If
                    End If
                End Using

                ' 2. Marquer
                Dim sql = $"INSERT INTO attendance (student_id, attendance_date, {col}, {colTime}) 
                            VALUES (@sid, @d, 1, NOW()) 
                            ON DUPLICATE KEY UPDATE {col}=1, {colTime}=NOW()"

                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@sid", studentId)
                    cmd.Parameters.AddWithValue("@d", DateTime.Now.Date)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            Return 1 ' Succès
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return 0 ' Erreur
        End Try
    End Function

    Private Sub FormCameraRecognition_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        StopCapture()
        If faceCascade IsNot Nothing Then faceCascade.Dispose()
        If recognizer IsNot Nothing Then recognizer.Dispose()
        If speaker IsNot Nothing Then speaker.Dispose()
    End Sub



    Private Sub FormCameraRecognition_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        FormChoix.Show()

    End Sub

    Private Sub btnReloadModel_Click(sender As Object, e As EventArgs) Handles btnReloadModel.Click

    End Sub


End Class