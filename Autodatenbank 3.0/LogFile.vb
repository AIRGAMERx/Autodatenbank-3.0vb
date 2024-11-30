Imports System.IO
Imports System.Net.Http
Imports MySqlConnector

Module LogFile

    Dim logfile As String = Application.StartupPath & "/logfile.txt"

    Public Async Sub SavetoLogFile(exception As String, ev As String)
        If Not String.IsNullOrEmpty(exception.ToString()) Then

            ' Prüfen, ob die Logdatei existiert
            If Not File.Exists(logfile) Then
                ' Datei erstellen und sofort schließen, um Sperrprobleme zu vermeiden
                Using fs As FileStream = File.Create(logfile)
                    fs.Close()
                End Using

                ' Warte auf Benutzerdaten
                Dim userdata = Await GetUserDataAsync(My.Settings.Regkey)

                ' Schreibvorgang starten
                Using NewSw As New StreamWriter(logfile, True)
                    NewSw.WriteLine("Issue Protocol from: " & userdata.Name & Environment.NewLine &
                                "For questions about errors please report here: " & userdata.Email & Environment.NewLine &
                                "RegKey: " & My.Settings.Regkey)
                End Using
            End If

            ' In die Logdatei schreiben
            Using sw As New StreamWriter(logfile, True)
                sw.WriteLine(Environment.NewLine & "Zeit: " & Date.Now & Environment.NewLine &
                         "OS: " & My.Computer.Info.OSVersion & " Server available: " & ServerConnection())
                sw.WriteLine("Exception: " & exception.ToString())
                sw.WriteLine("Event: " & ev)
            End Using

            ' Erfolgsnachricht

        End If
    End Sub

    Public Function ServerConnection() As Boolean
        Dim TestConnectionMysql As New MySqlConnection(My.Settings.connectionstring)

        Try
            TestConnectionMysql.Open()

            Return True
        Catch ex As Exception

            Return False
        End Try

    End Function

    Public Async Function SendLogFileAsync() As Task

        Try
            ' URL des PHP-Skripts
            Dim url As String = "https://lfdev.de/PHP/get_issue.php"

            ' Erstelle eine HttpClient-Instanz
            Using client As New HttpClient()

                ' Erstelle Form-Daten für den Upload
                Dim formData As New MultipartFormDataContent()

                ' Füge den Benutzernamen als POST-Parameter hinzu
                formData.Add(New StringContent(My.Settings.LicenseName), "username")

                ' Datei als Byte-Array hinzufügen
                Dim fileContent As ByteArrayContent = New ByteArrayContent(File.ReadAllBytes(logfile))
                fileContent.Headers.ContentType = New System.Net.Http.Headers.MediaTypeHeaderValue("text/plain")
                formData.Add(fileContent, "file", Path.GetFileName(logfile))

                ' Sende die POST-Anfrage an das PHP-Skript
                Dim response As HttpResponseMessage = Await client.PostAsync(New Uri(url), formData)

                ' Lese die Antwort
                Dim responseText As String = Await response.Content.ReadAsStringAsync()

                ' Ausgabe der Serverantwort
                Console.WriteLine(responseText)
                MsgBox("Logfile wurde übermittelt, danke." & vbNewLine & "Nur so kann die Anwendung besser werden und Fehler ausgebessert werden")
            End Using
        Catch ex As Exception
            SavetoLogFile(ex.Message, "SendLogFile")
            MsgBox("Fehler beim Hochladen der Datei: " & ex.Message)
        End Try
    End Function

    Public Sub OpenLogFile()
        If File.Exists(logfile) Then
            Try
                Dim p As New ProcessStartInfo(logfile) With {
                 .UseShellExecute = True
             }
                Process.Start(p)
            Catch ex As Exception

            End Try
        End If
    End Sub

    Public Sub DeleteOldLogEntries()
        Try
            ' Prüfe, ob die Logdatei existiert
            If File.Exists(logfile) Then
                ' Die Logdatei zeilenweise einlesen
                Dim logLines As List(Of String) = File.ReadAllLines(logfile).ToList()

                ' Eine Liste für den Kopfteil erstellen
                Dim headerLines As New List(Of String)()

                ' Finde den ersten Log-Eintrag nach dem Kopfteil (der mit "Zeit:" beginnt)
                Dim firstLogIndex As Integer = logLines.FindIndex(Function(line) line.StartsWith("Zeit:"))

                ' Wenn ein Log-Eintrag gefunden wurde
                If firstLogIndex <> -1 Then
                    ' Trenne den Kopfteil vom Rest der Logs
                    headerLines = logLines.Take(firstLogIndex).ToList()
                    logLines = logLines.Skip(firstLogIndex).ToList()
                End If

                ' Neue Liste, um nur die aktuellen Einträge zu speichern
                Dim updatedLogLines As New List(Of String)()
                Dim currentDate As DateTime = DateTime.Now

                ' Iteriere durch die verbleibenden Log-Zeilen
                For i As Integer = 0 To logLines.Count - 1
                    If logLines(i).StartsWith("Zeit:") Then
                        ' Datum und Uhrzeit extrahieren
                        Dim dateString As String = logLines(i).Substring(6, 19) ' Format "dd.MM.yyyy HH:mm:ss"
                        Dim logDate As DateTime

                        ' Versuche das Datum zu parsen
                        If DateTime.TryParseExact(dateString, "dd.MM.yyyy HH:mm:ss", Globalization.CultureInfo.InvariantCulture, Globalization.DateTimeStyles.None, logDate) Then
                            ' Überprüfe, ob das Log-Datum älter als 14 Tage ist
                            If (currentDate - logDate).Days <= 14 Then
                                ' Falls der Eintrag aktuell ist, füge ihn zur neuen Liste hinzu
                                updatedLogLines.Add(logLines(i))

                                ' Füge auch die nachfolgenden Einträge (bis zum nächsten Zeit-Tag) hinzu
                                Dim j As Integer = i + 1
                                While j < logLines.Count AndAlso Not logLines(j).StartsWith("Zeit:")
                                    updatedLogLines.Add(logLines(j))
                                    j += 1
                                End While

                                ' Setze den Index auf die nächste "Zeit:"-Zeile
                                i = j - 1
                            End If
                        End If
                    End If
                Next

                ' Die neue Liste kombiniert aus Kopfteil und gefilterten Logs schreiben
                File.WriteAllLines(logfile, headerLines.Concat(updatedLogLines))
            Else
                Console.WriteLine("Die Log-Datei wurde nicht gefunden.")
            End If
        Catch ex As Exception
            Console.WriteLine("Fehler beim Bereinigen der Log-Datei: " & ex.Message)
        End Try
    End Sub


End Module