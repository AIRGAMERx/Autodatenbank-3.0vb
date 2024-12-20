Imports System.Security.Cryptography
Imports System.Text

Public Class EncryptionHelper
    Private Shared ReadOnly Key As Byte() = Encoding.UTF8.GetBytes("16CharAESKey1234") ' 16 Zeichen (128-Bit)

    ' Verschlüsselung mit zufälligem IV
    Public Shared Function Encrypt(text As String) As String
        Using aes As New AesManaged()
            aes.Key = Key
            aes.GenerateIV() ' Zufälligen IV generieren
            Dim encryptor = aes.CreateEncryptor(aes.Key, aes.IV)

            Using ms As New IO.MemoryStream()
                ' Speichern des IV vor den verschlüsselten Daten
                ms.Write(aes.IV, 0, aes.IV.Length)

                Using cs As New CryptoStream(ms, encryptor, CryptoStreamMode.Write)
                    Using sw As New IO.StreamWriter(cs)
                        sw.Write(text)
                    End Using
                End Using

                ' Rückgabe der verschlüsselten Daten mit IV
                Return Convert.ToBase64String(ms.ToArray())
            End Using
        End Using
    End Function

    ' Entschlüsselung mit IV aus den Daten
    Public Shared Function Decrypt(cipherText As String) As String
        Dim fullCipher As Byte() = Convert.FromBase64String(cipherText)

        Using aes As New AesManaged()
            aes.Key = Key

            ' IV aus den verschlüsselten Daten extrahieren
            Dim iv As Byte() = New Byte(aes.BlockSize \ 8 - 1) {}
            Array.Copy(fullCipher, 0, iv, 0, iv.Length)
            aes.IV = iv

            Dim cipherBytes As Byte() = New Byte(fullCipher.Length - iv.Length - 1) {}
            Array.Copy(fullCipher, iv.Length, cipherBytes, 0, cipherBytes.Length)

            Dim decryptor = aes.CreateDecryptor(aes.Key, aes.IV)

            Using ms As New IO.MemoryStream(cipherBytes)
                Using cs As New CryptoStream(ms, decryptor, CryptoStreamMode.Read)
                    Using sr As New IO.StreamReader(cs)
                        Return sr.ReadToEnd()
                    End Using
                End Using
            End Using
        End Using
    End Function
End Class


