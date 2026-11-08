Public Class EtudiantSemaine
    Public Property Id As Integer
    Public Property NomComplet As String
    Public Property Jours As New Dictionary(Of Date, PresenceJour)
    Public Property TotalAbsencesHeures As Integer
End Class