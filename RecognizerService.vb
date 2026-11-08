
Imports System.IO
Imports Emgu.CV
Imports Emgu.CV.Face
Imports MySqlConnector


Public Class RecognizerService

    Private Shared ReadOnly modelFolder As String = Path.Combine(Application.StartupPath, "Data", "models")
    Private Shared ReadOnly modelFile As String = Path.Combine(modelFolder, "recognizer_model.xml")
    Private Shared ReadOnly trainingRoot As String = Path.Combine(Application.StartupPath, "TrainingImages")

    ''' <summary>
    ''' Entraîne le recognizer LBPH à partir des entrées en DB (table training_images).
    ''' Sauvegarde le modèle dans Data/models/recognizer_model.xml et crée une copie horodatée.
    ''' Retourne True si OK, False sinon.
    ''' </summary>
    Public Shared Function Train() As Boolean
        Try
            If Not Directory.Exists(trainingRoot) Then
                Throw New Exception("Dossier TrainingImages introuvable: " & trainingRoot)
            End If

            ' Récupérer toutes les images référencées en DB (table training_images)
            Dim imagesList As New List(Of Mat)()
            Dim labelsList As New List(Of Integer)()

            Using conn = DBConnector.GetConnection()
                conn.Open()
                Dim sql = "SELECT student_id, image_path FROM training_images ORDER BY student_id"
                Using cmd As New MySqlCommand(sql, conn)
                    Using rdr = cmd.ExecuteReader()
                        While rdr.Read()
                            Dim sid = Convert.ToInt32(rdr("student_id"))
                            Dim rel = rdr("image_path").ToString()
                            Dim full = Path.Combine(Application.StartupPath, rel)
                            If File.Exists(full) Then
                                ' Charger en grayscale et normaliser
                                Dim m As Mat = CvInvoke.Imread(full, Emgu.CV.CvEnum.ImreadModes.Grayscale)
                                If m.IsEmpty = False Then
                                    ' redimensionner si nécessaire (200x200)
                                    Dim resized As New Mat()
                                    CvInvoke.Resize(m, resized, New System.Drawing.Size(200, 200))
                                    CvInvoke.EqualizeHist(resized, resized)
                                    imagesList.Add(resized)
                                    labelsList.Add(sid)
                                End If
                            End If
                        End While
                    End Using
                End Using
            End Using

            If imagesList.Count = 0 Then
                Throw New Exception("Aucune image d'entraînement trouvée en DB.")
            End If

            ' Préparer arrays
            Dim imgs(imagesList.Count - 1) As Mat
            Dim lbs(imagesList.Count - 1) As Integer
            For i = 0 To imagesList.Count - 1
                imgs(i) = imagesList(i)
                lbs(i) = labelsList(i)
            Next

            ' Créer dossier modèle si nécessaire
            If Not Directory.Exists(modelFolder) Then
                Directory.CreateDirectory(modelFolder)
            End If

            ' Créer recognizer LBPH et entraîner
            Dim recognizer = New LBPHFaceRecognizer()
            recognizer.Train(imgs, lbs)

            ' Sauvegarder modèle principal
            recognizer.Write(modelFile)

            ' Versionner (copie horodatée)
            Dim ts = DateTime.Now.ToString("yyyyMMdd_HHmmss")
            Dim versionFile = Path.Combine(modelFolder, $"recognizer_model_{ts}.xml")
            File.Copy(modelFile, versionFile, True)

            Return True
        Catch ex As Exception
            ' Tu peux logger ici l'erreur
            MessageBox.Show("Erreur entraînement : " & ex.Message)
            Return False
        End Try
    End Function

    Public Shared Function ModelExists() As Boolean
        Return File.Exists(modelFile)
    End Function


    ''' <summary>
    ''' Charge un recognizer depuis le modèle sauvegardé. Retourne Nothing si fichier absent.
    ''' </summary>
    Public Shared Function LoadRecognizer() As LBPHFaceRecognizer
        Try
            If Not File.Exists(modelFile) Then
                Return Nothing
            End If
            Dim r = New LBPHFaceRecognizer()
            r.Read(modelFile) ' load the model
            Return r
        Catch ex As Exception
            MessageBox.Show("Erreur chargement modèle LBPH : " & ex.Message)
            Return Nothing
        End Try
    End Function
End Class
