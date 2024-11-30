Imports System.IO
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
            Autodatenbank.dgv2.Rows.Clear()
            Dim privateKeyFilePath As String = My.Settings.keyfile
            Dim keyFile As PrivateKeyFile

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

            Using client As New SftpClient(connectionInfo)
                client.Connect()

                If client.IsConnected Then
                    client.ChangeDirectory("Datenbank")
                    Dim files = client.ListDirectory(Licenseplate)

                    Dim i As Integer = -1
                    For Each file As SftpFile In files
                        If Not file.Name.StartsWith(".") AndAlso Not file.Name.StartsWith("mycar") Then
                            i += 1
                            Autodatenbank.dgv2.Rows.Add()
                            Autodatenbank.dgv2.Rows(i).Cells(0).Value = file.Name
                            Autodatenbank.dgv2.Rows(i).Cells(1).Value = file.LastWriteTime
                            Autodatenbank.dgv2.Rows(i).Cells(2).Value = My.Settings.SFTPServerUri + "/" + Licenseplate + "/" + file.Name
                        End If
                    Next
                End If

                client.Disconnect()
            End Using
        Catch DirectionEx As SftpPathNotFoundException
            Console.WriteLine(DirectionEx.Message)
        Catch ex As Exception
            MsgBox("Fehler bei der SFTP-Verbindung: " & ex.Message, MsgBoxStyle.Critical)
            SavetoLogFile(ex.Message, "ListFilesFromFTP")
        End Try
    End Sub


    Public Sub UploadFileToSFTP(DataPath As String, Dataname As String)
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

            MsgBox("Die Datei wurde erfolgreich über SFTP hochgeladen.")
            SFTP.ListFilesFromSFTPForDGV2(Autodatenbank.Licenseplate)

        Catch ex As Exception
            MsgBox("Fehler beim SFTP-Upload: " & ex.Message, MsgBoxStyle.Critical, "Fehler")
            SavetoLogFile(ex.Message, "UploadFileViaSFTP")
        End Try
    End Sub


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
