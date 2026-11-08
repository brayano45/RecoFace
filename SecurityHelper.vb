Imports System.Text
Imports System.Security.Cryptography

Public Class SecurityHelper

    Public Function HashPassword(password As String) As String
        Using sha As SHA256 = SHA256.Create()
            Dim bytes = Encoding.UTF8.GetBytes(password)
            Dim hash = sha.ComputeHash(bytes)
            Return BitConverter.ToString(hash).Replace("-", "").ToLower()
        End Using
    End Function

    ' Vérification du mot de passe
    Public Function VerifyPassword(inputPassword As String, storedHash As String) As Boolean
        Dim hashed = HashPassword(inputPassword)
        Return hashed = storedHash
    End Function

    Public Shared Function SHA256Hash(text As String) As String
        Using sha As SHA256 = SHA256.Create()
            Dim bytes = Encoding.UTF8.GetBytes(text)
            Dim hashBytes = sha.ComputeHash(bytes)
            Dim sb As New StringBuilder()

            For Each b In hashBytes
                sb.Append(b.ToString("x2"))
            Next

            Return sb.ToString()
        End Using
    End Function
End Class
