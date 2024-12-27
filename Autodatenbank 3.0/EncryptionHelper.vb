Imports System.Security.Cryptography
Imports System.Text

Public Class EncryptionHelper
    Private Shared ReadOnly Key As Byte() = Encoding.UTF8.GetBytes("abcdefghijklmnopabcdefghijklmnop") ' 32 Bytes für AES-256
    Private Shared ReadOnly IV As Byte() = Encoding.UTF8.GetBytes("1234567890123456") ' 16 Bytes für AES

    ' Verschlüsselung mit zufälligem IV
    Public Shared Function Encrypt(plainText As String) As String
        Using aes As Aes = Aes.Create()
            aes.Key = Key
            aes.IV = IV
            Dim encryptor As ICryptoTransform = aes.CreateEncryptor(aes.Key, aes.IV)

            Using ms As New IO.MemoryStream()
                Using cs As New CryptoStream(ms, encryptor, CryptoStreamMode.Write)
                    Using sw As New IO.StreamWriter(cs)
                        sw.Write(plainText)
                    End Using
                    Return Convert.ToBase64String(ms.ToArray())
                End Using
            End Using
        End Using
    End Function

    ' Entschlüsselung mit IV aus den Daten
    Public Shared Function Decrypt(cipherText As String) As String
        Using aes As Aes = Aes.Create()
            aes.Key = Key
            aes.IV = IV
            Dim decryptor As ICryptoTransform = aes.CreateDecryptor(aes.Key, aes.IV)

            Using ms As New IO.MemoryStream(Convert.FromBase64String(cipherText))
                Using cs As New CryptoStream(ms, decryptor, CryptoStreamMode.Read)
                    Using sr As New IO.StreamReader(cs)
                        Return sr.ReadToEnd()
                    End Using
                End Using
            End Using
        End Using
    End Function
End Class


