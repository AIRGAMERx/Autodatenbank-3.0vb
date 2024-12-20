Imports System.Security.Cryptography
Imports System.Text
Imports Microsoft.Win32

Module RegistryOptions
    ReadOnly RegistryPath As String = "Software\Autodatenbank3.0"

    Public Function SearchRegEntry() As Boolean
        Dim KeyName As String = "RegKey"

        Dim KeyValue As String = GetRegistryValue(RegistryPath, KeyName)

        If Not String.IsNullOrEmpty(KeyValue) Or Not String.IsNullOrWhiteSpace(KeyValue) Then
            My.Settings.Regkey = KeyValue
            My.Settings.Save()
            Return True
        Else
            Return False
        End If

    End Function


    Public Sub SetRegistryValue(path As String, keyName As String, keyValue As String)
        Try
            Dim encryptedValue = EncryptionHelper.Encrypt(keyValue) ' Verschlüsseln des Werts

            Dim currentUserKey As RegistryKey = Registry.CurrentUser
            Dim subKey As RegistryKey = currentUserKey.CreateSubKey(path)

            If subKey IsNot Nothing Then
                subKey.SetValue(keyName, encryptedValue) ' Verschlüsselten Wert speichern
                subKey.Close()
                currentUserKey.Close()
            End If
        Catch ex As Exception
            ' Fehlerbehandlung
            MessageBox.Show("Fehler beim Speichern des Schlüssels: " & ex.Message, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub





    Public Function GetRegistryValue(path As String, keyName As String) As String
        Try
            Dim currentUserKey As RegistryKey = Registry.CurrentUser
            Dim subKey As RegistryKey = currentUserKey.OpenSubKey(path)

            If subKey IsNot Nothing Then
                Dim encryptedValue As Object = subKey.GetValue(keyName)
                If encryptedValue IsNot Nothing Then
                    Dim valueString As String = encryptedValue.ToString()

                    ' Überprüfen, ob der Wert Base64-codiert ist
                    If IsBase64String(valueString) Then
                        Try
                            ' Entschlüsseln, wenn Base64-codiert
                            Return EncryptionHelper.Decrypt(valueString)
                        Catch ex As CryptographicException
                            ' Entschlüsselung fehlgeschlagen
                            Console.WriteLine("Entschlüsselung fehlgeschlagen: " & ex.Message)
                            Return valueString ' Klartext zurückgeben
                        End Try
                    Else
                        ' Wenn nicht Base64-codiert, Klartext zurückgeben
                        Return valueString
                    End If
                End If
                subKey.Close()
            End If
            currentUserKey.Close()
        Catch ex As Exception
            MessageBox.Show("Fehler beim Abrufen des Schlüssels: " & ex.Message, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return Nothing
    End Function

    ' Helferfunktion zur Überprüfung, ob ein String Base64-codiert ist
    Private Function IsBase64String(value As String) As Boolean
        Try
            Dim buffer As Byte() = Convert.FromBase64String(value)
            Return True
        Catch ex As FormatException
            Return False
        End Try
    End Function






    Public Function CreateRegKey(Regkey As String) As Boolean
        Try
            ' Asynchron den Registrierungsschlüssel vom Backend erhalten
            Dim generatedKey As String = Regkey

            ' Überprüfe, ob der Schlüssel erfolgreich generiert wurde
            If generatedKey IsNot Nothing Then
                ' Speichern des Schlüssels in den Einstellungen
                My.Settings.Regkey = generatedKey
                My.Settings.Save()

                ' Speichern des verschlüsselten Schlüssels in der Registry
                Dim keyName As String = "RegKey"
                Dim encryptedKey As String = EncryptionHelper.Encrypt(generatedKey) ' Verschlüsselung des Schlüssels
                Dim currentUserKey As RegistryKey = Registry.CurrentUser
                Dim subKey As RegistryKey = currentUserKey.CreateSubKey(RegistryPath)

                If subKey IsNot Nothing Then
                    subKey.SetValue(keyName, encryptedKey) ' Verschlüsselten Wert speichern
                    subKey.Close()
                End If
                currentUserKey.Close()

                ' Erfolgreich erstellt
                Return True
            Else
                ' Rückgabe bei Fehler
                Return False
            End If

        Catch ex As Exception
            ' Fehlerbehandlung
            MessageBox.Show("Ein Fehler ist aufgetreten: " & ex.Message, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error)
            SavetoLogFile(ex.Message, "CreateRegKeyRegOptions")
            Return False
        End Try
    End Function





    Private Function GenerateRandomKey(format As String) As String
        Dim random As New Random()
        Dim sb As New StringBuilder()

        For i As Integer = 0 To 31
            sb.Append(format(random.Next(format.Length)))
        Next

        Return sb.ToString()
    End Function

End Module
