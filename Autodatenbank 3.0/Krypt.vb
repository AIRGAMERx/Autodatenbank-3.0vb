Imports System.IO
Imports System.Security.Cryptography
Imports System.Text

Public Class PasswordHelper

    Public Shared Function HashPassword(password As String) As PasswordHashResult
        ' Generiere ein 16-Byte-Salt
        Dim saltBytes As Byte() = New Byte(15) {}
        Using rng As New RNGCryptoServiceProvider()
            rng.GetBytes(saltBytes)
        End Using
        Dim salt As String = Convert.ToBase64String(saltBytes)

        ' Verwende PBKDF2 zum Hashen des Passworts mit dem Salt
        Using pbkdf2 = New Rfc2898DeriveBytes(password, saltBytes, 10000)
            Dim hash As String = Convert.ToBase64String(pbkdf2.GetBytes(32)) ' 32 Byte für den Hash

            ' Erstelle eine Instanz von PasswordHashResult und setze die Werte
            Dim result As New PasswordHashResult()
            result.HashedPassword = hash
            result.Salt = salt
            Return result
        End Using
    End Function

    Public Shared Function VerifyPassword(password As String, storedHash As String, storedSalt As String) As Boolean
        Dim saltBytes As Byte() = Convert.FromBase64String(storedSalt)
        Using pbkdf2 = New Rfc2898DeriveBytes(password, saltBytes, 10000)
            Dim hash As String = Convert.ToBase64String(pbkdf2.GetBytes(32))
            Return hash = storedHash
        End Using
    End Function

    Public Shared Function GenerateKeyFromPassword(password As String, keySize As Integer) As Byte()
        Using sha256 As SHA256 = SHA256.Create()
            ' Generiert ein Byte-Array der gewünschten Länge basierend auf dem gehashten Passwort
            Return sha256.ComputeHash(Encoding.UTF8.GetBytes(password)).Take(keySize).ToArray()
        End Using
    End Function

    Public Shared Function EncryptString(plainText As String, key As Byte(), iv As Byte()) As String
        Dim encrypted As Byte()

        Using aes As Aes = Aes.Create()
            aes.Key = key
            aes.IV = iv

            Dim encryptor As ICryptoTransform = aes.CreateEncryptor(aes.Key, aes.IV)

            Using ms As New MemoryStream()
                Using cs As New CryptoStream(ms, encryptor, CryptoStreamMode.Write)
                    Using sw As New StreamWriter(cs)
                        sw.Write(plainText)
                    End Using
                    encrypted = ms.ToArray()
                End Using
            End Using
        End Using

        Return Convert.ToBase64String(encrypted)
    End Function

    Public Shared Function DecryptString(encryptedText As String, key As Byte(), iv As Byte()) As String
        Dim plainText As String = Nothing
        Dim cipherText As Byte() = Convert.FromBase64String(encryptedText)

        Using aes As Aes = Aes.Create()
            aes.Key = key
            aes.IV = iv

            Dim decryptor As ICryptoTransform = aes.CreateDecryptor(aes.Key, aes.IV)

            Using ms As New MemoryStream(cipherText)
                Using cs As New CryptoStream(ms, decryptor, CryptoStreamMode.Read)
                    Using sr As New StreamReader(cs)
                        plainText = sr.ReadToEnd()
                    End Using
                End Using
            End Using
        End Using

        Return plainText
    End Function

End Class

Public Class PasswordHashResult
    Public Property HashedPassword As String
    Public Property Salt As String
End Class