Imports System.IO
Imports System.Net
Imports Renci.SshNet
Imports Renci.SshNet.Common
Imports Renci.SshNet.Sftp

Module SFTP
    Public Function TestSFTPConnection(ServerUri As String, username As String) As Boolean
        Try
            ' Lade den privaten Schlüssel aus der .pem-Datei
            Dim privateKeyFilePath As String = My.Settings.keyfile ' Hier wird der Pfad zur PEM-Datei gespeichert
            Dim keyFile As PrivateKeyFile

            ' Prüfen, ob eine Passphrase vorhanden ist
            If String.IsNullOrEmpty(My.Settings.keyfilepass) Or My.Settings.keyfilepass = "Default" Then
                ' Ohne Passphrase laden
                keyFile = New PrivateKeyFile(privateKeyFilePath)
            Else
                ' Mit Passphrase laden
                keyFile = New PrivateKeyFile(privateKeyFilePath, My.Settings.keyfilepass)
            End If

            ' SSH-Authentifizierungsmethode mit dem privaten Schlüssel
            Dim keyFiles As New List(Of PrivateKeyFile) From {keyFile}
            Dim authMethods As New List(Of AuthenticationMethod) From {
            New PrivateKeyAuthenticationMethod(username, keyFile)
        }

            ' Verbindung mit dem Server herstellen
            Dim connectionInfo As New ConnectionInfo(ServerUri, username, authMethods.ToArray())
            Using client As New SftpClient(connectionInfo)
                client.Connect()

                If client.IsConnected Then


                    ' Die SFTP-Verbindung war erfolgreich
                    client.Disconnect()
                    Return True
                Else
                    Throw New Exception("SFTP-Verbindung konnte nicht hergestellt werden.")
                    client.Disconnect()
                    Return False
                End If

                client.Disconnect()
            End Using

        Catch ex As Exception

            MsgBox("SFTP-Verbindung konnte nicht hergestellt werden: " & ex.Message, MsgBoxStyle.Critical)
            SavetoLogFile(ex.Message, "TestSFTPConnection")
            Return False
        End Try

    End Function


    Public Function CheckAndCreateDirectoryOnSFTP(serverUri As String, username As String) As Boolean
        Try
            ' Lade den privaten Schlüssel aus der .pem-Datei
            Dim privateKeyFilePath As String = My.Settings.keyfile ' Hier wird der Pfad zur PEM-Datei gespeichert
            Dim keyFile As PrivateKeyFile

            ' Prüfen, ob eine Passphrase vorhanden ist
            If String.IsNullOrEmpty(My.Settings.keyfilepass) Or My.Settings.keyfilepass = "Default" Then
                ' Ohne Passphrase laden
                keyFile = New PrivateKeyFile(privateKeyFilePath)
            Else
                ' Mit Passphrase laden
                keyFile = New PrivateKeyFile(privateKeyFilePath, My.Settings.keyfilepass)
            End If

            ' SSH-Authentifizierungsmethode mit dem privaten Schlüssel
            Dim keyFiles As New List(Of PrivateKeyFile) From {keyFile}
            Dim authMethods As New List(Of AuthenticationMethod) From {
            New PrivateKeyAuthenticationMethod(username, keyFile)
            }
            Dim connectionInfo As New ConnectionInfo(serverUri, username, authMethods.ToArray())
            Using client As New SftpClient(connectionInfo)

                ' Prüfen, ob das Verzeichnis existiert
                If Not client.Exists("Datenbank") Then
                    ' Verzeichnis erstellen, wenn es nicht existiert
                    client.CreateDirectory("Datenbank")
                End If

                ' Erfolg: Verzeichnis existiert oder wurde erstellt
                Return True
            End Using
        Catch ex As Exception
            ' Fehler beim Erstellen oder Prüfen des Verzeichnisses
            MsgBox("Fehler beim Überprüfen oder Erstellen des Verzeichnisses: " & ex.Message, MsgBoxStyle.Critical)
            SavetoLogFile(ex.Message, "CheckAndCreateDirectoryOnSFTP")
            Return False
        End Try
    End Function



    Public Sub DownloadandOpenFileSFTP(destinationPath As String, sftpResource As String, Licenseplate As String)

        Try
            ' SFTP-Verbindung herstellen
            Dim privateKeyFilePath As String = My.Settings.keyfile
            Dim keyFile As PrivateKeyFile

            If String.IsNullOrEmpty(My.Settings.keyfilepass) Then
                keyFile = New PrivateKeyFile(privateKeyFilePath)
            Else
                keyFile = New PrivateKeyFile(privateKeyFilePath, My.Settings.keyfilepass)
            End If

            ' Authentifizierungsmethode festlegen
            Dim keyFiles As New List(Of PrivateKeyFile) From {keyFile}
            Dim authMethods As New List(Of AuthenticationMethod) From {
            New PrivateKeyAuthenticationMethod(My.Settings.Ftpusername, keyFile)
        }

            Dim connectionInfo As New ConnectionInfo(My.Settings.SFTPServerUri, My.Settings.SFTPUsername, authMethods.ToArray())

            Using client As New SftpClient(connectionInfo)
                client.Connect()
                client.ChangeDirectory("Datenbank/" & Licenseplate)

                ' SFTP-Datei herunterladen
                Using fileStream As New FileStream(destinationPath, FileMode.Create)
                    client.DownloadFile(sftpResource, fileStream)
                End Using

                client.Disconnect()

                ' Datei öffnen
                Dim p As New ProcessStartInfo(destinationPath) With {
                .UseShellExecute = True
            }
                Process.Start(p)

                Cursor.Current = Cursors.Default
            End Using

        Catch ex As Exception
            MessageBox.Show("Fehler beim Herunterladen der Datei via SFTP: " & ex.Message)
            SavetoLogFile(ex.Message, "DownloadFileViaSFTP")
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Public Sub DeleteFileFromSFTP(Filename As String, Licenseplate As String)
        Dim username As String = My.Settings.SFTPUsername
        Try
            Dim privateKeyFilePath As String = My.Settings.keyfile
            Dim keyFile As PrivateKeyFile

            If String.IsNullOrEmpty(My.Settings.keyfilepass) Then
                keyFile = New PrivateKeyFile(privateKeyFilePath)
            Else
                keyFile = New PrivateKeyFile(privateKeyFilePath, My.Settings.keyfilepass)
            End If

            Dim keyFiles As New List(Of PrivateKeyFile) From {keyFile}
            Dim authMethods As New List(Of AuthenticationMethod) From {
            New PrivateKeyAuthenticationMethod(username, keyFile)
        }

            Dim connectionInfo As New ConnectionInfo(My.Settings.SFTPServerUri, username, authMethods.ToArray())
            Using client As New SftpClient(connectionInfo)
                client.Connect()
                client.ChangeDirectory("Datenbank")
                If client.IsConnected Then
                    ' Entfernen der Datei


                    client.DeleteFile(Licenseplate & "/" & Filename)
                    MsgBox("Die Datei wurde erfolgreich über SFTP gelöscht.")
                Else
                    Throw New Exception("SFTP-Verbindung konnte nicht hergestellt werden.")
                End If

                client.Disconnect()
            End Using
        Catch ex As Exception
            Throw New Exception("Fehler beim Löschen der Datei über SFTP: " & ex.Message)
        End Try

    End Sub



    Public Sub ListFilesFromSFTPForDGV2(Licenseplate As String)
        Try
            ' DataGridView leeren
            Autodatenbank.dgv2.Rows.Clear()

            ' ProgressBar initialisieren
            Autodatenbank.PGB_FetchFTPData.Visible = True
            Autodatenbank.PGB_FetchFTPData.Minimum = 0
            Autodatenbank.PGB_FetchFTPData.Maximum = 100
            Autodatenbank.PGB_FetchFTPData.Value = 0

            ' Verbindung zu SFTP-Server herstellen
            Dim privateKeyFilePath As String = My.Settings.keyfile
            Dim keyFile As PrivateKeyFile

            ' Private Key laden (mit oder ohne Passwort)
            If String.IsNullOrEmpty(My.Settings.keyfilepass) Or My.Settings.keyfile = "Default" Then
                keyFile = New PrivateKeyFile(privateKeyFilePath)
            Else
                keyFile = New PrivateKeyFile(privateKeyFilePath, My.Settings.keyfilepass)
            End If

            Dim keyFiles As New List(Of PrivateKeyFile) From {keyFile}
            Dim authMethods As New List(Of AuthenticationMethod) From {
            New PrivateKeyAuthenticationMethod(My.Settings.SFTPUsername, keyFile)
        }

            Dim connectionInfo As New ConnectionInfo(My.Settings.SFTPServerUri, My.Settings.SFTPUsername, authMethods.ToArray())

            Dim fileList As New List(Of SftpFile)
            Dim basePath As String

            Using client As New SftpClient(connectionInfo)
                client.Connect()

                If client.IsConnected Then
                    ' Absoluter Verzeichnispfad
                    basePath = client.WorkingDirectory.TrimEnd("/"c) ' Hole den Basispfad
                    Dim dataPath As String = basePath & "/Datenbank/" & Licenseplate & "/"

                    ' Verzeichnis wechseln
                    client.ChangeDirectory(dataPath)


                    ' Dateien abrufen
                    For Each file As SftpFile In client.ListDirectory(client.WorkingDirectory)
                        If Not file.Name.StartsWith(".") AndAlso file.Name <> "mycar" AndAlso file.Name <> "Thumbnails" Then
                            fileList.Add(file)
                        End If
                    Next
                End If
            End Using ' Nach dem `Using`-Block ist der `client` nicht mehr verfügbar

            ' Prüfen, ob Dateien vorhanden sind
            If fileList.Count = 0 Then

                Autodatenbank.PGB_FetchFTPData.Visible = False
                Return
            End If

            ' Anzahl der Dateien für die ProgressBar
            Dim totalFiles = fileList.Count
            Dim currentFile = 0

            ' Task-basierte Verarbeitung der Dateien
            Dim rows As New List(Of DataGridViewRow)
            For Each file As SftpFile In fileList
                Dim dateiname = file.Name
                Dim datum = file.LastWriteTime.ToString("dd.MM.yyyy")
#Disable Warning BC42104 ' Die Variable wurde verwendet, bevor ihr ein Wert zugewiesen wurde.
                Dim pfad = basePath & "/Datenbank/" & Licenseplate & "/" & dateiname
#Enable Warning BC42104 ' Die Variable wurde verwendet, bevor ihr ein Wert zugewiesen wurde.
                Dim thumbnailPath = basePath & "/Datenbank/" & Licenseplate & "/Thumbnails/" & dateiname

                Dim thumbnailImage As Image = Nothing
                Dim tagValue = "Placeholder"

                ' Thumbnail herunterladen
                Try
                    Using client As New SftpClient(connectionInfo) ' Neuen Client erstellen für den Thumbnail-Download
                        client.Connect()
                        Using thumbnailStream As Stream = client.OpenRead(thumbnailPath)
                            thumbnailImage = Image.FromStream(thumbnailStream)
                            tagValue = "RealThumbnail"
                        End Using
                    End Using
                Catch ex As Exception
                    ' Kein Thumbnail gefunden
                    thumbnailImage = My.Resources.Nothing_Found
                End Try

                ' Zeile erstellen
                Dim row As New DataGridViewRow()
                row.CreateCells(Autodatenbank.dgv2)
                row.Cells(0).Value = thumbnailImage ' Thumbnail-Bild
                row.Cells(1).Value = dateiname       ' Dateiname
                row.Cells(2).Value = datum           ' Erstelldatum
                row.Cells(3).Value = pfad            ' Dateipfad
                row.Cells(0).Tag = tagValue          ' Tag-Wert

                rows.Add(row)

                ' Fortschritt aktualisieren
                currentFile += 1
                Autodatenbank.PGB_FetchFTPData.Value = CInt((currentFile / totalFiles) * 100)
            Next

            ' Zeilen hinzufügen
            Autodatenbank.dgv2.Rows.AddRange(rows.ToArray())

            ' Höhe der Zeilen anpassen
            For Each row As DataGridViewRow In Autodatenbank.dgv2.Rows
                If row.Cells(0).Tag IsNot Nothing AndAlso row.Cells(0).Tag.ToString() = "Placeholder" Then
                    row.Height = 22 ' Standardhöhe
                Else
                    row.Height = 100 ' Höhe für echte Thumbnails
                End If
            Next

            ' ProgressBar ausblenden
            Autodatenbank.PGB_FetchFTPData.Visible = False
        Catch ex As Exception
            ' Fehler anzeigen
            MsgBox("Fehler: " & ex.Message)
            SavetoLogFile(ex.Message, "ListFilesFromSFTP")
        Finally
            ' ProgressBar ausblenden
            Autodatenbank.PGB_FetchFTPData.Visible = False
        End Try
    End Sub







    Public Function UploadFileToSFTP(DataPath As String, Dataname As String) As Boolean
        Try
            ' Verbindung mit dem SFTP-Server herstellen
            Dim privateKeyFilePath As String = My.Settings.keyfile ' Dateipfad für den privaten Schlüssel
            Dim keyFile As PrivateKeyFile

            ' Wenn eine Passphrase benötigt wird, diese laden, ansonsten ohne Passphrase
            If String.IsNullOrEmpty(My.Settings.keyfilepass) Then
                keyFile = New PrivateKeyFile(privateKeyFilePath)
            Else
                keyFile = New PrivateKeyFile(privateKeyFilePath, My.Settings.keyfilepass)
            End If

            ' Authentifizierungsmethode mit dem privaten Schlüssel
            Dim keyFiles As New List(Of PrivateKeyFile) From {keyFile}
            Dim authMethods As New List(Of AuthenticationMethod) From {
            New PrivateKeyAuthenticationMethod(My.Settings.SFTPUsername, keyFile)
        }

            Dim connectionInfo As New ConnectionInfo(My.Settings.SFTPServerUri, My.Settings.SFTPUsername, authMethods.ToArray())

            Using client As New SftpClient(connectionInfo)
                client.Connect()

                ' Prüfen, ob Verzeichnis existiert, und erstellen falls nötig
                If Not client.Exists("Datenbank/" & Autodatenbank.Licenseplate) Then
                    client.CreateDirectory("Datenbank/" & Autodatenbank.Licenseplate)
                End If

                ' Datei über SFTP hochladen
                Using fileStream As New FileStream(DataPath, FileMode.Open)
                    client.UploadFile(fileStream, "Datenbank/" & Autodatenbank.Licenseplate & "/" & Dataname)
                End Using

                client.Disconnect()
            End Using


            SFTP.ListFilesFromSFTPForDGV2(Autodatenbank.Licenseplate)
            Return True

        Catch ex As Exception
            MsgBox("Fehler beim SFTP-Upload: " & ex.Message, MsgBoxStyle.Critical, "Fehler")
            SavetoLogFile(ex.Message, "UploadFileViaSFTP")
            Return False
        End Try
    End Function

    Public Function UploadThumbnailToSFTP(DataPath As String, Dataname As String) As Boolean
        Try
            ' Verbindung mit dem SFTP-Server herstellen
            Dim privateKeyFilePath As String = My.Settings.keyfile ' Dateipfad für den privaten Schlüssel
            Dim keyFile As PrivateKeyFile

            ' Wenn eine Passphrase benötigt wird, diese laden, ansonsten ohne Passphrase
            If String.IsNullOrEmpty(My.Settings.keyfilepass) Then
                keyFile = New PrivateKeyFile(privateKeyFilePath)
            Else
                keyFile = New PrivateKeyFile(privateKeyFilePath, My.Settings.keyfilepass)
            End If

            ' Authentifizierungsmethode mit dem privaten Schlüssel
            Dim keyFiles As New List(Of PrivateKeyFile) From {keyFile}
            Dim authMethods As New List(Of AuthenticationMethod) From {
            New PrivateKeyAuthenticationMethod(My.Settings.SFTPUsername, keyFile)
        }

            Dim connectionInfo As New ConnectionInfo(My.Settings.SFTPServerUri, My.Settings.SFTPUsername, authMethods.ToArray())

            Using client As New SftpClient(connectionInfo)
                client.Connect()

                ' Prüfen, ob Verzeichnis existiert, und erstellen falls nötig
                If Not client.Exists("Datenbank/" & Autodatenbank.Licenseplate & "/Thumbnails") Then
                    client.CreateDirectory("Datenbank/" & Autodatenbank.Licenseplate & "/Thumbnails")
                End If

                ' Datei über SFTP hochladen
                Using fileStream As New FileStream(DataPath, FileMode.Open)
                    client.UploadFile(fileStream, "Datenbank/" & Autodatenbank.Licenseplate & "/Thumbnails/" & Dataname)
                End Using

                client.Disconnect()
            End Using


            SFTP.ListFilesFromSFTPForDGV2(Autodatenbank.Licenseplate)
            Return True
        Catch ex As Exception
            MsgBox("Fehler beim SFTP-Upload: " & ex.Message, MsgBoxStyle.Critical, "Fehler")
            SavetoLogFile(ex.Message, "UploadFileViaSFTP")
            Return False
        End Try
    End Function
    Public Sub SearchInSFTPFolder(folderpath As String, searchterm As String, Optional depth As Integer = 0)
        Dim files As New List(Of String)

        ' SSH-Verbindung herstellen (mit OpenSSH-Keyfile)
        Dim privateKeyFilePath As String = My.Settings.keyfile ' Pfad zur PEM-Datei
        Dim keyFile As PrivateKeyFile
        If String.IsNullOrEmpty(My.Settings.keyfilepass) Then
            keyFile = New PrivateKeyFile(privateKeyFilePath)
        Else
            keyFile = New PrivateKeyFile(privateKeyFilePath, My.Settings.keyfilepass)
        End If

        Dim keyFiles As New List(Of PrivateKeyFile) From {keyFile}
        Dim authMethods As New List(Of AuthenticationMethod) From {
            New PrivateKeyAuthenticationMethod(My.Settings.SFTPUsername, keyFile)
        }

        Dim connectionInfo As New ConnectionInfo(My.Settings.SFTPServerUri, My.Settings.SFTPUsername, authMethods.ToArray())

        Using client As New SftpClient(connectionInfo)
            ' Verbindung herstellen
            client.Connect()


            ' Überprüfe, ob das Verzeichnis existiert
            If client.Exists("Datenbank") Then
                client.ChangeDirectory("Datenbank")

            Else
                MsgBox("Verzeichnis 'Datenbank' existiert nicht.")
                Exit Sub ' Beende, wenn das Verzeichnis nicht existiert
            End If

            ' Dateien im aktuellen Verzeichnis auflisten
            ListDirectory(client, files)

            ' Verbindung trennen
            client.Disconnect()
        End Using

        ' Ausgabe der Dateien oder weiterverarbeiten
        For Each file As String In files
            Console.WriteLine(file)
        Next

    End Sub
    Public Sub ListDirectory(client As SftpClient, ByRef files As List(Of String))
        Try
            ' Hole das aktuelle Verzeichnis
            Dim currentDirectory As String = client.WorkingDirectory

            ' Listet alle Dateien und Unterverzeichnisse rekursiv auf
            For Each entry In client.ListDirectory(currentDirectory)
                Try
                    If entry.IsDirectory AndAlso Not entry.Name.StartsWith(".") Then
                        ' In das Verzeichnis wechseln (relativer Pfad)
                        client.ChangeDirectory(entry.Name)
                        ListDirectory(client, files) ' Rekursion
                        client.ChangeDirectory("..") ' Zurück zum übergeordneten Verzeichnis
                    ElseIf entry.IsRegularFile Then
                        ' Datei zur Liste hinzufügen
                        files.Add(entry.FullName)
                    End If
                Catch ex As Exception
                    ' Hier die Fehlerbehandlung hinzufügen, wenn nötig
                End Try
            Next
        Catch ex As Exception
            MsgBox("Fehler: " & ex.Message)
        End Try

        ' Wenn Dateien gefunden wurden, Daten verarbeiten
        If files.Count > 0 Then
            For Each item As String In files
                ' Überprüfen, ob der Dateipfad oder Name den Suchbegriff enthält
                If item.IndexOf(SearchEntries.TXB_SearchWord.Text, StringComparison.OrdinalIgnoreCase) <> -1 Then
                    ' Den Dateinamen extrahieren
                    Dim fileName As String = Path.GetFileName(item) ' Extrahiert den Dateinamen

                    ' Den Pfad ohne Dateinamen extrahieren
                    Dim directoryPath As String = Path.GetDirectoryName(item)

                    ' Den letzten Ordner  extrahieren
                    Dim parentDirectory As String = Path.GetFileName(directoryPath)

                    ' Relativen Pfad erzeugen
                    Dim relativePath As String = item.Replace("/home/webpages/lima-city/airgamerx/Datenbank/", "") ' Entfernt den absoluten Teil des Pfads

                    ' Vollständigen Pfad erstellen, der verglichen wird
                    Dim fullPath As String = My.Settings.SFTPServerUri & "/" & relativePath

                    ' Prüfen, ob der Eintrag bereits existiert (doppelten Eintrag vermeiden)
                    Dim duplicate As Boolean = False
                    For Each row As DataGridViewRow In SearchEntries.DGV.Rows
                        If row.Cells(7).Value IsNot Nothing AndAlso row.Cells(7).Value.ToString() = fullPath Then
                            duplicate = True
                            Exit For
                        End If
                    Next

                    ' Nur hinzufügen, wenn kein Duplikat gefunden wurde
                    If Not duplicate Then
                        ' Neue Zeile zur DataGridView hinzufügen
                        SearchEntries.DGV.Rows.Add()

                        ' Zeilenindex ermitteln (die zuletzt hinzugefügte Zeile)
                        Dim i As Integer = SearchEntries.DGV.Rows.Count - 1

                        ' Werte in die DataGridView einfügen
                        SearchEntries.DGV.Rows(i).Cells(1).Value = fileName  ' Datei Name
                        SearchEntries.DGV.Rows(i).Cells(7).Value = fullPath  ' Vollständiger SFTP-Pfad
                        SearchEntries.DGV.Rows(i).Cells(0).Value = parentDirectory ' Ordnername 
                    End If
                End If
            Next
        End If
    End Sub
End Module
