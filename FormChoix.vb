Public Class FormChoix
    Private Sub btnEtudiant_Click(sender As Object, e As EventArgs) Handles btnEtudiant.Click
        FormCameraRecognition.Show()
        Me.Hide()
    End Sub

    Private Sub btnResponsable_Click(sender As Object, e As EventArgs) Handles btnResponsable.Click
        FormLogin.Show()
        Me.Hide()
    End Sub
End Class                                                                                                                                                                                                                                                                                                                                                                          