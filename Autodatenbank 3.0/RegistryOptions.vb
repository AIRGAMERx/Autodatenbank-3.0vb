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
            ' Öffnen oder erstellen des Unterschlüssels
            Dim currentUserKey As RegistryKey = Registry.CurrentUser
            Dim subKey As RegistryKey = currentUserKey.CreateSubKey(path)

            If subKey IsNot Nothing Then
                ' Setzen des Wertes
                subKey.SetValue(keyName, keyValue)
                subKey.Close()
                currentUserKey.Close()


            End If
        Catch ex As Exception



        End Try
    End Sub





    Public Function GetRegistryValue(path As String, KeyName As String) As String
        Dim currentUserKey As RegistryKey = Registry.CurrentUser
        Dim subKey As RegistryKey = currentUserKey.OpenSubKey(path)

        If subKey IsNot Nothing Then

            Dim Value As Object = subKey.GetValue(KeyName)
            If Value IsNot Nothing Then
                Return Value.ToString
            Else
                Return Nothing
            End If
            subKey.Close()
        End If
        currentUserKey.Close()
        Return Nothing


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

                ' Speichern des Schlüssels in der Registry
                Dim keyName As String = "RegKey"
                Dim keyValue As String = generatedKey
                Dim currentUserKey As RegistryKey = Registry.CurrentUser
                Dim subKey As RegistryKey = currentUserKey.CreateSubKey(RegistryPath)

                If subKey IsNot Nothing Then
                    subKey.SetValue(keyName, keyValue)
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
