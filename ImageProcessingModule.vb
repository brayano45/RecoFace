Imports Emgu.CV
Imports Emgu.CV.CvEnum
Imports Emgu.CV.Structure

Public Module ImageProcessingModule
    ' Paramètres constants pour garantir la cohérence
    Public Const GAMMA_VALUE As Double = 1.5
    Public Const FACE_SIZE As Integer = 200
    Public Const MIN_FACE_SIZE As Integer = 200

    ''' <summary>
    ''' Prétraitement standardisé d'image - VERSION SIMPLIFIÉE (TA MÉTHODE ORIGINALE)
    ''' </summary>
    Public Sub PretraitementStandard(ByRef imageGray As Mat)
        ' 1. Égalisation d'histogramme (améliore le contraste)
        CvInvoke.EqualizeHist(imageGray, imageGray)

        ' 2. Correction Gamma (normalise la luminosité)
        AppliquerCorrectionGamma(imageGray, GAMMA_VALUE)
    End Sub

    ''' <summary>
    ''' Application de la correction gamma
    ''' </summary>
    Private Sub AppliquerCorrectionGamma(ByRef img As Mat, gamma As Double)
        Dim lut(255) As Byte
        For i As Integer = 0 To 255
            lut(i) = Math.Min(255, CInt(Math.Pow(i / 255.0, 1.0 / gamma) * 255.0))
        Next

        Dim matLut = New Mat(1, 256, DepthType.Cv8U, 1)
        Runtime.InteropServices.Marshal.Copy(lut, 0, matLut.DataPointer, 256)
        CvInvoke.LUT(img, matLut, img)
        matLut.Dispose()
    End Sub

    ''' <summary>
    ''' Détection de visages avec paramètres optimisés
    ''' </summary>
    Public Function DetecterVisages(cascade As CascadeClassifier, imageGray As Mat) As Rectangle()
        ' Paramètres optimisés pour réduire les fausses détections
        Dim scaleFactor As Double = 1.15
        Dim minNeighbors As Integer = 6
        Dim minSize As New Size(MIN_FACE_SIZE, MIN_FACE_SIZE)
        Dim maxSize As New Size(500, 500)

        Return cascade.DetectMultiScale(imageGray, scaleFactor, minNeighbors, minSize, maxSize)
    End Function

    ''' <summary>
    ''' Filtre les visages qui se chevauchent (garde le plus grand)
    ''' </summary>
    Public Function FiltrerChevauchements(faces() As Rectangle) As Rectangle()
        If faces.Length <= 1 Then Return faces

        Dim filtered As New List(Of Rectangle)()
        Dim used(faces.Length - 1) As Boolean

        ' Trier par taille décroissante
        Dim sortedFaces = faces.OrderByDescending(Function(r) r.Width * r.Height).ToArray()

        For i = 0 To sortedFaces.Length - 1
            If used(i) Then Continue For

            Dim current = sortedFaces(i)
            filtered.Add(current)

            ' Marquer les visages qui se chevauchent avec celui-ci
            For j = i + 1 To sortedFaces.Length - 1
                If used(j) Then Continue For

                If RectanglesSeChevаuchent(current, sortedFaces(j)) Then
                    used(j) = True
                End If
            Next
        Next

        Return filtered.ToArray()
    End Function

    ''' <summary>
    ''' Vérifie si deux rectangles se chevauchent
    ''' </summary>
    Private Function RectanglesSeChevаuchent(r1 As Rectangle, r2 As Rectangle) As Boolean
        Dim intersection = Rectangle.Intersect(r1, r2)
        If intersection.IsEmpty Then Return False

        Dim areaIntersection = intersection.Width * intersection.Height
        Dim areaR1 = r1.Width * r1.Height
        Dim areaR2 = r2.Width * r2.Height

        ' Si l'intersection est > 30% de la plus petite surface, on considère un chevauchement
        Dim minArea = Math.Min(areaR1, areaR2)
        Return (areaIntersection / minArea) > 0.3
    End Function

    ''' <summary>
    ''' Prépare un visage pour la reconnaissance (taille standard)
    ''' </summary>
    Public Function PreparerVisagePourReconnaissance(faceMat As Mat) As Mat
        Dim faceResized As New Mat()
        CvInvoke.Resize(faceMat, faceResized, New Size(FACE_SIZE, FACE_SIZE))

        ' Le prétraitement a déjà été fait sur l'image complète
        ' On n'applique PAS de nouveau traitement ici

        Return faceResized
    End Function

End Module