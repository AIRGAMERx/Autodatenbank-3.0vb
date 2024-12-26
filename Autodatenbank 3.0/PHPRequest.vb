Imports System.Net.Http
Imports Newtonsoft.Json.Linq

Module PHPRequest
    Public Async Function GetPermissionForRegKey(regKey As String) As Task(Of Integer)
        Dim client As New HttpClient()
        Dim url As String = "https://lfdev.de/php/get_permission.php?regKey=" & regKey
        Try
            ' HTTP GET-Anfrage an das PHP-Backend senden
            Dim response As HttpResponseMessage = Await client.GetAsync(url)

            If response.IsSuccessStatusCode Then
                ' JSON-Antwort verarbeiten
                Dim jsonResponse As String = Await response.Content.ReadAsStringAsync()
                Dim permission As Integer = JObject.Parse(jsonResponse)("permission").ToObject(Of Integer)()
                Return permission
            Else
                ' Wenn die Anfrage fehlschlägt, aber kein Fehler auftritt
                Throw New Exception("Server antwortete mit einem Fehler: " & response.StatusCode.ToString())
            End If

        Catch ex As HttpRequestException
            ' Speziell: Keine Internetverbindung oder Server nicht erreichbar
            MessageBox.Show("Keine Internetverbindung oder Server nicht erreichbar. Bitte überprüfe deine Verbindung.")
            Return -1

        Catch ex As TaskCanceledException
            ' Timeout der Anfrage
            MessageBox.Show("Die Anfrage hat zu lange gedauert. Bitte versuche es erneut.")
            Return -1

        Catch ex As Exception
            ' Allgemeine Fehlerbehandlung
            MessageBox.Show("Es wurden keine Daten gefunden")
            SavetoLogFile(ex.Message, "GetPermissionFroRegKey")
            Return -1
        End Try
    End Function


    Public Async Function GetNewestVersion() As Task(Of Integer)

        Dim client As New HttpClient()
        Dim url As String = "https://lfdev.de/php/get_newest_version.php"
        Try
            ' HTTP GET-Anfrage an das PHP-Backend senden
            Dim response As HttpResponseMessage = Await client.GetAsync(url)

            If response.IsSuccessStatusCode Then
                ' JSON-Antwort verarbeiten
                Dim jsonResponse As String = Await response.Content.ReadAsStringAsync()
                Dim Version As Integer = JObject.Parse(jsonResponse)("Aktuelle").ToObject(Of Integer)()
                Return Version
            Else
                ' Wenn die Anfrage fehlschlägt, aber kein Fehler auftritt
                Throw New Exception("Server antwortete mit einem Fehler: " & response.StatusCode.ToString())
            End If

        Catch ex As HttpRequestException
            ' Speziell: Keine Internetverbindung oder Server nicht erreichbar
            MessageBox.Show("Keine Internetverbindung oder Server nicht erreichbar. Bitte überprüfe deine Verbindung.")
            Return -1

        Catch ex As TaskCanceledException
            ' Timeout der Anfrage
            MessageBox.Show("Die Anfrage hat zu lange gedauert. Bitte versuche es erneut.")
            Return -1

        Catch ex As Exception
            ' Allgemeine Fehlerbehandlung
            MessageBox.Show("Es wurden keine Daten gefunden")
            SavetoLogFile(ex.Message, "GetNewestVersion")
            Return -1
        End Try




    End Function
    Public Async Function GetUserDataAsync(Regkey As String) As Task(Of (Name As String, Email As String))
        Dim client As New HttpClient()
        Dim url As String = "https://lfdev.de/php/get_user_data.php"
        If Not String.IsNullOrEmpty(Regkey) Then




            ' Bereite die Form-Daten für den HTTP-POST vor (mit dem RegKey aus My.Settings)
            Dim postData As New Dictionary(Of String, String) From {
        {"regKey", Regkey}
    }
            Dim content As New FormUrlEncodedContent(postData)

            Try
                ' HTTP POST-Anfrage an das PHP-Backend senden
                Dim response As HttpResponseMessage = Await client.PostAsync(url, content)

                ' Wenn die Antwort erfolgreich war, verarbeite die JSON-Antwort
                If response.IsSuccessStatusCode Then
                    Dim jsonResponse As String = Await response.Content.ReadAsStringAsync()
                    Dim userData As JObject = JObject.Parse(jsonResponse)

                    ' Überprüfe, ob die Antwort erfolgreich war
                    If userData("success").ToObject(Of Boolean)() Then
                        ' Extrahiere Name und E-Mail
                        Dim name As String = userData("Name").ToString()
                        Dim email As String = userData("Email").ToString()

                        ' Rückgabe als Tuple
                        Return (name, email)
                    Else
                        ' Fehler vom PHP-Backend anzeigen
                        MessageBox.Show(userData("error").ToString(), "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return ("", "") ' Rückgabe eines leeren Wertes im Fehlerfall
                    End If
                Else
                    ' Wenn die HTTP-Anfrage fehlschlägt, eine Fehlermeldung anzeigen
                    MessageBox.Show("Verbindung zum Server fehlgeschlagen", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return ("", "") ' Rückgabe eines leeren Wertes im Fehlerfall
                End If

            Catch ex As Exception
                ' Allgemeine Fehlerbehandlung
                MessageBox.Show("Es wurden keine Daten gefunden")
                SavetoLogFile(ex.Message, "GetUserDataAsync")
                Return ("", "") ' Rückgabe eines leeren Wertes im Fehlerfall
            End Try
        Else
            MessageBox.Show("Es wurden keine Daten gefunden")
            SavetoLogFile("Regkey is Empty", "GetUserDataAsync")
            Return ("", "") ' Rückgabe eines leeren Wertes im Fehlerfall
        End If
    End Function



    Public Async Function GETPrDesignation(pr As String) As Task(Of List(Of String))
        Dim client As New HttpClient()
        Dim url As String = "https://lfdev.de/php/get_pr_number.php?pr=" & pr
        Try
            ' HTTP GET-Anfrage an das PHP-Backend senden
            Dim response As HttpResponseMessage = Await client.GetAsync(url)

            If response.IsSuccessStatusCode Then
                ' JSON-Antwort verarbeiten
                Dim jsonResponse As String = Await response.Content.ReadAsStringAsync()
                Dim jsonArray As JArray = JArray.Parse(jsonResponse)

                ' Liste der Bezeichnungen aus der JSON-Antwort extrahieren
                Dim designations As New List(Of String)
                For Each item As JObject In jsonArray
                    designations.Add(item("Bezeichnung").ToString())
                Next

                Return designations
            Else
                ' Wenn die Anfrage fehlschlägt, aber kein Fehler auftritt
                Throw New Exception("Server antwortete mit einem Fehler: " & response.StatusCode.ToString())
            End If

        Catch ex As HttpRequestException
            ' Speziell: Keine Internetverbindung oder Server nicht erreichbar
            MessageBox.Show("Keine Internetverbindung oder Server nicht erreichbar. Bitte überprüfe deine Verbindung.")
            Return New List(Of String)()

        Catch ex As TaskCanceledException
            ' Timeout der Anfrage
            MessageBox.Show("Die Anfrage hat zu lange gedauert. Bitte versuche es erneut.")
            Return New List(Of String)()

        Catch ex As Exception
            ' Allgemeine Fehlerbehandlung
            MessageBox.Show("Es wurden keine Daten gefunden")
            SavetoLogFile(ex.Message, "GetDesignation")
            Return New List(Of String)()
        End Try
    End Function

End Module
