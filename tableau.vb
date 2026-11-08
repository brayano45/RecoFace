Imports MySqlConnector
Imports System.Windows.Forms.DataVisualization.Charting

Public Class tableau
    ' Variables globales
    Public result As Integer
    Public startLastWeek As Date
    Public endLastWeek As Date
    Public today As Date = Date.Now


    Public Sub New()
        ' A. Correctif technique pour les Graphiques (Charts) sur .NET 8
        ' Cela force l'application à reconnaître le composant de base de données
        Try
            System.Data.Common.DbProviderFactories.RegisterFactory("System.Data.SqlClient", System.Data.SqlClient.SqlClientFactory.Instance)
        Catch ex As Exception
            ' Si c'est déjà enregistré, on ignore
        End Try

        ' B. Cette ligne CRÉE physiquement les graphiques et les boutons
        ' Sans elle -> Erreur "Object reference not set..."
        InitializeComponent()
    End Sub
    ' =========================================================================

    Private Sub tableau_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Initialisation des dates (Semaine courante par défaut)
        Dim diff As Integer = (7 + (today.DayOfWeek - DayOfWeek.Monday)) Mod 7
        Dim startOfThisWeek As Date = today.AddDays(-diff)

        dbdate.Value = startOfThisWeek.AddDays(-7)
        dfdate.Value = startOfThisWeek.AddDays(-1)

        dbdate.MaxDate = Date.Today
        dfdate.MaxDate = Date.Today

        CalculerEtAfficher()
    End Sub

    Private Sub Voir_Click(sender As Object, e As EventArgs) Handles Voir.Click
        CalculerEtAfficher()
    End Sub

    Private Sub CalculerEtAfficher()
        startLastWeek = dbdate.Value.Date
        endLastWeek = dfdate.Value.Date

        ' A. Total Étudiants
        Try
            Using conn = DBConnector.GetConnection()
                conn.Open()
                Dim sql = "SELECT COUNT(*) FROM students"
                Dim cmd As New MySqlCommand(sql, conn)
                result = Convert.ToInt32(cmd.ExecuteScalar())
            End Using
        Catch
            result = 0
        End Try
        Label3.Text = result.ToString()

        ' B. Calcul Heures
        Dim heuresPresences As Integer = CalculerHeures(1)
        ' 1 Période = 2 Heures
        Label7.Text = (heuresPresences * 2).ToString() & " h"

        Dim heuresAbsences As Integer = CalculerHeures(0)
        Label6.Text = (heuresAbsences * 2).ToString() & " h"

        ' C. Mises à jour Graphiques
        MettreAJourCamembert(heuresPresences, heuresAbsences)
        MettreAJourCourbe()
    End Sub

    Private Function CalculerHeures(etatRecherche As Integer) As Integer
        Dim total As Integer = 0
        Try
            Using conn = DBConnector.GetConnection()
                conn.Open()
                Dim sql = "SELECT " &
                          "(SELECT COUNT(*) FROM attendance WHERE p1=@cs AND DATE(attendance_date) BETWEEN @s AND @e) + " &
                          "(SELECT COUNT(*) FROM attendance WHERE p2=@cs AND DATE(attendance_date) BETWEEN @s AND @e) + " &
                          "(SELECT COUNT(*) FROM attendance WHERE p3=@cs AND DATE(attendance_date) BETWEEN @s AND @e) + " &
                          "(SELECT COUNT(*) FROM attendance WHERE p4=@cs AND DATE(attendance_date) BETWEEN @s AND @e)"

                Dim cmd As New MySqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@cs", etatRecherche)
                cmd.Parameters.Add("@s", MySqlDbType.Date).Value = startLastWeek
                cmd.Parameters.Add("@e", MySqlDbType.Date).Value = endLastWeek

                Dim res = cmd.ExecuteScalar()
                If res IsNot Nothing AndAlso Not IsDBNull(res) Then
                    total = Convert.ToInt32(res)
                End If
            End Using
        Catch
        End Try
        Return total
    End Function

    Private Sub MettreAJourCamembert(hPresence As Integer, hAbsence As Integer)
        ' SÉCURITÉ : On vérifie que le graphique existe bien
        If ChartCamembert Is Nothing Then Return

        ChartCamembert.Series(0).Points.Clear()

        Dim total As Double = hPresence + hAbsence
        Dim txPres As Double = 0
        Dim txAbs As Double = 0

        If total > 0 Then
            txPres = Math.Round((hPresence / total) * 100, 1)
            txAbs = Math.Round((hAbsence / total) * 100, 1)
        End If

        Dim p1 = ChartCamembert.Series(0).Points.Add(txPres)
        p1.LegendText = "Présence"
        p1.Color = Color.FromArgb(46, 204, 113)
        p1.Label = txPres.ToString() & "%"

        Dim p2 = ChartCamembert.Series(0).Points.Add(txAbs)
        p2.LegendText = "Absence"
        p2.Color = Color.FromArgb(231, 76, 60)
        p2.Label = txAbs.ToString() & "%"
    End Sub

    Private Sub MettreAJourCourbe()
        If ChartCourbe Is Nothing Then Return

        ChartCourbe.Series(0).Points.Clear()

        Dim currDate = startLastWeek
        If (endLastWeek - startLastWeek).Days > 31 Then Return

        Try
            Using conn = DBConnector.GetConnection()
                conn.Open()
                While currDate <= endLastWeek
                    Dim nb = 0
                    Dim sql = "SELECT COUNT(DISTINCT student_id) FROM attendance " &
                              "WHERE attendance_date = @d AND (p1=1 OR p2=1 OR p3=1 OR p4=1)"

                    Using cmd As New MySqlCommand(sql, conn)
                        cmd.Parameters.AddWithValue("@d", currDate)
                        Dim res = cmd.ExecuteScalar()
                        If res IsNot Nothing AndAlso Not IsDBNull(res) Then nb = Convert.ToInt32(res)
                    End Using

                    ChartCourbe.Series(0).Points.AddXY(currDate.ToString("dd/MM"), nb)
                    currDate = currDate.AddDays(1)
                End While
            End Using
        Catch
        End Try
    End Sub

End Class