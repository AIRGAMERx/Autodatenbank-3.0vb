Imports System.IO
Imports System.Net

Module FTP
    Public Function TestFTPConnection(ServerUri As String, Username As String, Password As String) As Boolean
        Dim trimmedText As String = ServerUri.Trim().ToLower()

        If Not trimmedText.StartsWith("ftp://") Then
            ServerUri = "ftp://" & ServerUri
            ServerConnection.TXB_FTPServerUri.Text = ServerUri
            FirstRun.TXB_FTPServerUri.Text = ServerUri
        End If

        Try
            Dim uri As New Uri(ServerUri)
            Dim ftpRequest As FtpWebRequest = DirectCast(WebRequest.Create(uri), FtpWebRequest)
            ftpRequest.Credentials = New NetworkCredential(Username, Password)
            ftpRequest.Method = WebRequestMethods.Ftp.ListDirectory

            Using ftpResponse As FtpWebResponse = CType(ftpRequest.GetResponse(), FtpWebResponse)
                Return True ' Verbindung erfolgreich
            End Using
        Catch ex As WebException
            ' Verbindung fehlgeschlagen
            Return False
        End Try
    End Function

    Public Sub DownloadandOpenFileFTP(destinationPath As String, ftpResource As String)
        Using client As New WebClient()
            client.Credentials = New NetworkCredential(My.Settings.Ftpusername, My.Settings.Ftppassword)

            Try
                Dim dataBytes() As Byte = client.DownloadData(ftpResource)

                If dataBytes.Length > 0 Then
                    System.IO.File.WriteAllBytes(destinationPath, dataBytes)
                    Dim p As New ProcessStartInfo(destinationPath) With {
                    .UseShellExecute = True
                }
                    Process.Start(p)
                    Cursor.Current = Cursors.Default
                Else
                    MessageBox.Show("Download failed")
                    Cursor.Current = Cursors.Default
                End If
            Catch ex As WebException
                MessageBox.Show(ex.Message)
                SavetoLogFile(ex.Message, "DownloadFileViaFTP")
                Cursor.Current = Cursors.Default
            Catch ex As IOException
                MessageBox.Show(ex.Message)
                SavetoLogFile(ex.Message, "DownloadFileViaFTP")
                Cursor.Current = Cursors.Default
            End Try
        End Using



    End Sub


    Public Sub DeleteFileFromFTP(ftpServeruri As String)
        Try
            Dim request As FtpWebRequest = DirectCast(WebRequest.Create(New Uri(ftpServeruri)), FtpWebRequest)
            request.Credentials = New NetworkCredential(My.Settings.Ftpusername, My.Settings.Ftppassword)
            request.Method = WebRequestMethods.Ftp.DeleteFile

            Using response As FtpWebResponse = DirectCast(request.GetResponse(), FtpWebResponse)
                MsgBox("Die Datei wurde erfolgreich über FTP gelöscht.")
            End Using
        Catch ex As Exception
            Throw New Exception("Fehler beim Löschen der Datei über FTP: " & ex.Message)
        End Try

    End Sub

    Public Sub ListFilesFromFTPForDGV2(Licenseplate As String)

        Try
            ' DataGridView leeren
            Autodatenbank.dgv2.Rows.Clear()

            Dim ftpUri As String
            If My.Settings.Ftpserveruri.Contains("/Datenbank") Then
                ftpUri = My.Settings.Ftpserveruri + "/" + Licenseplate
            Else
                ftpUri = My.Settings.Ftpserveruri + "/Datenbank/" + Licenseplate
            End If

            Dim anfrage As FtpWebRequest = CType(WebRequest.Create(ftpUri), FtpWebRequest)
            anfrage.Method = WebRequestMethods.Ftp.ListDirectoryDetails
            anfrage.Credentials = New NetworkCredential(My.Settings.Ftpusername, My.Settings.Ftppassword)

            Using antwort As FtpWebResponse = CType(anfrage.GetResponse(), FtpWebResponse)
                Using streamReader As New System.IO.StreamReader(antwort.GetResponseStream())
                    If streamReader.EndOfStream Then
                        Exit Sub
                    End If

                    Dim i As Integer = -1

                    ' Zeilen aus dem FTP-Stream lesen
                    While Not streamReader.EndOfStream
                        i += 1
                        Try
                            Dim zeile As String = streamReader.ReadLine()

                            ' Prüfen, ob die Zeile die erwartete Struktur hat
                            If String.IsNullOrWhiteSpace(zeile) Then Continue While

                            ' Beispiel für eine FTP-Antwort:
                            ' drwxr-xr-x   2 user group       4096 Dec 18 10:53 myfile.txt
                            ' Zerlege die Zeile, um den Dateinamen zu extrahieren
                            Dim parts() As String = zeile.Split(New Char() {" "c}, StringSplitOptions.RemoveEmptyEntries)

                            ' Sicherstellen, dass die Antwort genug Teile enthält
                            If parts.Length < 9 Then Continue While

                            ' Der Dateiname beginnt ab dem 9. Element (nach Datum und Uhrzeit)
                            Dim dateiname As String = String.Join(" ", parts.Skip(8))
                            Dim datum As String = $"{parts(5)} {parts(6)} {parts(7)}"
                            Dim pfad As String = ftpUri + "/" + dateiname

                            ' Zeile zur DataGridView hinzufügen
                            Autodatenbank.dgv2.Rows.Add()
                            Autodatenbank.dgv2.Rows(i).Cells(0).Value = dateiname
                            Autodatenbank.dgv2.Rows(i).Cells(1).Value = datum
                            Autodatenbank.dgv2.Rows(i).Cells(2).Value = pfad

                        Catch ex As Exception
                            ' Fehler beim Verarbeiten einer Zeile ignorieren
                        End Try
                    End While
                End Using
            End Using

            ' "." und ".." Zeilen entfernen
            For ind As Integer = Autodatenbank.dgv2.Rows.Count - 1 To 0 Step -1
                Dim row As DataGridViewRow = Autodatenbank.dgv2.Rows(ind)
                If row.Cells(0).Value IsNot Nothing AndAlso (row.Cells(0).Value.ToString() = "." OrElse row.Cells(0).Value.ToString() = "..") OrElse row.Cells(0).Value.ToString() = "mycar" Then
                    Autodatenbank.dgv2.Rows.Remove(row)
                End If
            Next

        Catch ex As Exception
            ' Fehler beim Verbinden mit dem FTP-Server
            MsgBox("Fehler bei der FTP-Verbindung: " & ex.Message, MsgBoxStyle.Critical)
            SavetoLogFile(ex.Message, "ListFilesFromFTP")
        End Try

    End Sub







    Public Sub UploadFileToFTP(DataPath As String, Dataname As String)
        Try
            ' FTP-URI festlegen
            Dim ftpuri As String
            If My.Settings.Ftpserveruri.Contains("/Datenbank") Then
                ftpuri = My.Settings.Ftpserveruri + "/"
            Else
                ftpuri = My.Settings.Ftpserveruri + "/Datenbank/"
            End If

            Dim folderUri As String = ftpuri & Autodatenbank.Licenseplate & "/"

            ' Überprüfen, ob das Verzeichnis existiert
            If Not FTPHelper.DirectoryExists(folderUri, My.Settings.Ftpusername, My.Settings.Ftppassword) Then
                ' Ordner erstellen, falls er nicht existiert
                FTPHelper.CreateDirectory(folderUri, My.Settings.Ftpusername, My.Settings.Ftppassword)
            End If

            ' FTP-Daten-Upload
            Dim wc As New WebClient()
            AddHandler wc.UploadProgressChanged, AddressOf UploadFiles.UploadProgressChanged
            AddHandler wc.UploadFileCompleted, AddressOf UploadFiles.UploadFileCompleted

            wc.Credentials = New NetworkCredential(My.Settings.Ftpusername, My.Settings.Ftppassword)
            wc.UploadFileAsync(New Uri(folderUri & Dataname), DataPath)

        Catch ex As Exception
            MsgBox("Fehler beim FTP-Upload: " & ex.Message, MsgBoxStyle.Critical, "Fehler")
            SavetoLogFile(ex.Message, "UploadFileViaFTP")
        End Try
    End Sub


End Module
Public Class FTPHelper

    Public Shared Sub CreateDirectory(folderUri As String, username As String, password As String)
        Try
            Dim request As FtpWebRequest = CType(WebRequest.Create(folderUri), FtpWebRequest)
            request.Method = WebRequestMethods.Ftp.MakeDirectory
            request.Credentials = New NetworkCredential(username, password)

            Using response As FtpWebResponse = CType(request.GetResponse(), FtpWebResponse)
                ' Verzeichnis wurde erstellt
            End Using
        Catch ex As Exception
            Throw New Exception("Fehler beim Erstellen des Verzeichnisses: " & ex.Message)
        End Try
    End Sub


    Public Shared Function DirectoryExists(folderUri As String, username As String, password As String) As Boolean
        Try
            Dim request As FtpWebRequest = CType(WebRequest.Create(folderUri), FtpWebRequest)
            request.Method = WebRequestMethods.Ftp.ListDirectory
            request.Credentials = New NetworkCredential(username, password)

            Using response As FtpWebResponse = CType(request.GetResponse(), FtpWebResponse)
                Return True ' Verzeichnis existiert
            End Using
        Catch ex As WebException
            Dim response As FtpWebResponse = CType(ex.Response, FtpWebResponse)
            If response.StatusCode = FtpStatusCode.ActionNotTakenFileUnavailable Then
                ' Verzeichnis existiert nicht
                Return False
            Else
                Throw ' Anderen Fehler werfen
            End If
        End Try
    End Function

End Class