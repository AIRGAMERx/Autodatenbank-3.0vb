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

    Public Async Sub ListFilesFromFTPForDGV2(Licenseplate As String)
        If Not Directory.Exists(Application.StartupPath & "\Thumbnails\" & Licenseplate) Then
            Directory.CreateDirectory(Application.StartupPath & "\Thumbnails\" & Licenseplate)
        End If


        Try
            ' DataGridView leeren
            Autodatenbank.dgv2.Rows.Clear()

            ' ProgressBar initialisieren
            With Autodatenbank.PGB_FetchFTPData
                .Visible = True
                .Minimum = 0
                .Maximum = 100
                .Value = 0
            End With

            ' Spalten überprüfen und erstellen
            If Autodatenbank.dgv2.Columns.Count = 0 Then
                Autodatenbank.dgv2.Columns.Add(New DataGridViewImageColumn() With {
                .Name = "Thumbnail",
                .HeaderText = "Thumbnail",
                .ImageLayout = DataGridViewImageCellLayout.Zoom
            })
                Autodatenbank.dgv2.Columns.Add("Dateiname", "Dateiname")
                Autodatenbank.dgv2.Columns.Add("Erstelldatum", "Erstelldatum")
                Autodatenbank.dgv2.Columns.Add("Dateipfad", "Dateipfad")

                Autodatenbank.dgv2.Columns("Thumbnail").Width = 100
                Autodatenbank.dgv2.Columns("Dateiname").Width = 300
                Autodatenbank.dgv2.Columns("Erstelldatum").Width = 150
                Autodatenbank.dgv2.Columns("Dateipfad").Width = 600

                Autodatenbank.dgv2.RowHeadersVisible = False
            End If

            ' FTP-URI definieren
            Dim ftpUri As String = If(My.Settings.Ftpserveruri.Contains("/Datenbank"),
                                   $"{My.Settings.Ftpserveruri}/{Licenseplate}",
                                   $"{My.Settings.Ftpserveruri}/Datenbank/{Licenseplate}")
            Dim thumbnailUri As String = $"{ftpUri}/Thumbnails"

            ' Liste der Dateien abrufen
            Dim fileList As New List(Of Tuple(Of String, String))
            Dim anfrage As FtpWebRequest = CType(WebRequest.Create(ftpUri), FtpWebRequest)
            anfrage.Method = WebRequestMethods.Ftp.ListDirectoryDetails
            anfrage.Credentials = New NetworkCredential(My.Settings.Ftpusername, My.Settings.Ftppassword)

            Using antwort As FtpWebResponse = CType(anfrage.GetResponse(), FtpWebResponse)
                Using reader As New System.IO.StreamReader(antwort.GetResponseStream())
                    While Not reader.EndOfStream
                        Dim line As String = reader.ReadLine()
                        If Not String.IsNullOrWhiteSpace(line) Then
                            Dim parts() As String = line.Split(New Char() {" "c}, StringSplitOptions.RemoveEmptyEntries)
                            If parts.Length >= 9 Then
                                Dim fileName As String = String.Join(" ", parts.Skip(8))
                                Dim fileDate As String = $"{parts(5)} {parts(6)} {parts(7)}"
                                fileList.Add(Tuple.Create(fileName, fileDate))
                            End If
                        End If
                    End While
                End Using
            End Using

            ' Anzahl der Dateien für die ProgressBar
            Dim totalFiles As Integer = fileList.Count
            Dim currentFile As Integer = 0

            ' Ergebnisse verarbeiten
            For Each fileInfo In fileList
                Dim result = Await Task.Run(Function()
                                                Dim fileName = fileInfo.Item1
                                                Dim fileDate = fileInfo.Item2
                                                Dim filePath = $"{ftpUri}/{fileName}"
                                                Dim thumbnailPath = $"{thumbnailUri}/{fileName}"
                                                Dim thumbnailImage As Image = Nothing
                                                Dim tagValue = "Placeholder"

                                                Dim savePath As String = Application.StartupPath & "\Thumbnails\" & Licenseplate & "\" & fileName


                                                ' Prüfen, ob das Thumbnail lokal existiert
                                                If File.Exists(savePath) Then
                                                    ' Thumbnail lokal laden
                                                    thumbnailImage = Image.FromFile(savePath)
                                                    tagValue = "LocalThumbnail"
                                                Else
                                                    ' Thumbnail vom FTP herunterladen
                                                    Try
                                                        Dim thumbnailRequest As FtpWebRequest = CType(WebRequest.Create(thumbnailPath), FtpWebRequest)
                                                        thumbnailRequest.Method = WebRequestMethods.Ftp.DownloadFile
                                                        thumbnailRequest.Credentials = New NetworkCredential(My.Settings.Ftpusername, My.Settings.Ftppassword)

                                                        Using thumbnailResponse As FtpWebResponse = CType(thumbnailRequest.GetResponse(), FtpWebResponse)
                                                            Using thumbnailStream As Stream = thumbnailResponse.GetResponseStream()
                                                                thumbnailImage = Image.FromStream(thumbnailStream)

                                                                ' Thumbnail lokal speichern
                                                                thumbnailImage.Save(savePath, System.Drawing.Imaging.ImageFormat.Jpeg)
                                                                tagValue = "RealThumbnail"
                                                            End Using
                                                        End Using
                                                    Catch
                                                        ' Kein Thumbnail gefunden
                                                        thumbnailImage = My.Resources.Nothing_Found
                                                        tagValue = "Placeholder"
                                                    End Try
                                                End If

                                                ' Rückgabe als anonyme Struktur
                                                Return New With {
                                                .ThumbnailImage = thumbnailImage,
                                                .FileName = fileName,
                                                .Date = fileDate,
                                                .Path = filePath,
                                                .Tag = tagValue
                                            }
                                            End Function)

                ' Zeile hinzufügen
                If Not {"mycar", "Thumbnails", ".", ".."}.Contains(result.FileName) Then
                    Dim row As New DataGridViewRow()
                    row.CreateCells(Autodatenbank.dgv2)
                    row.Cells(0).Value = result.ThumbnailImage
                    row.Cells(1).Value = result.FileName
                    row.Cells(2).Value = result.Date
                    row.Cells(3).Value = result.Path
                    row.Cells(0).Tag = result.Tag
                    Autodatenbank.dgv2.Rows.Add(row)
                End If

                ' Fortschritt aktualisieren
                currentFile += 1
                Autodatenbank.PGB_FetchFTPData.Invoke(Sub()
                                                          Autodatenbank.PGB_FetchFTPData.Value = CInt((currentFile / totalFiles) * 100)
                                                      End Sub)
            Next

            ' Höhe der Zeilen anpassen
            For Each row As DataGridViewRow In Autodatenbank.dgv2.Rows
                If row.Cells(0).Tag IsNot Nothing AndAlso row.Cells(0).Tag.ToString() = "Placeholder" Then
                    row.Height = 22 ' Standardhöhe
                Else
                    row.Height = 100 ' Höhe für echte Thumbnails
                End If
            Next

        Catch ex As Exception
            ' Fehler beim Verbinden mit dem FTP-Server
            MsgBox("Fehler bei der FTP-Verbindung: " & ex.Message, MsgBoxStyle.Critical)
            SavetoLogFile(ex.Message, "ListFilesFromFTP")
        Finally
            ' ProgressBar ausblenden
            Autodatenbank.PGB_FetchFTPData.Invoke(Sub()
                                                      Autodatenbank.PGB_FetchFTPData.Visible = False
                                                  End Sub)
        End Try
    End Sub














    Public Function UploadFileToFTP(DataPath As String, Dataname As String) As Boolean
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
            Return True
        Catch ex As Exception
            MsgBox("Fehler beim FTP-Upload: " & ex.Message, MsgBoxStyle.Critical, "Fehler")
            SavetoLogFile(ex.Message, "UploadFileViaFTP")
            Return False
        End Try
    End Function


    Public Function UploadThumbnailToFTP(DataPath As String, Dataname As String) As Boolean
        Try
            ' FTP-URI festlegen
            Dim ftpuri As String
            If My.Settings.Ftpserveruri.Contains("/Datenbank") Then
                ftpuri = My.Settings.Ftpserveruri + "/"
            Else
                ftpuri = My.Settings.Ftpserveruri + "/Datenbank/"
            End If

            Dim folderUri As String = ftpuri & Autodatenbank.Licenseplate & "/Thumbnails/"

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
            Return True
        Catch ex As Exception
            MsgBox("Fehler beim FTP-Upload: " & ex.Message, MsgBoxStyle.Critical, "Fehler")
            SavetoLogFile(ex.Message, "UploadThumbnailViaFTP")
            Return False
        End Try
    End Function


End Module
Public Class FTPHelper

    Public Shared Sub CreateDirectory(folderUri As String, username As String, password As String)
        MsgBox("Hier")
        Try
            Dim request As FtpWebRequest = CType(WebRequest.Create(folderUri), FtpWebRequest)
            request.Method = WebRequestMethods.Ftp.MakeDirectory
            request.Credentials = New NetworkCredential(username, password)

            Using response As FtpWebResponse = CType(request.GetResponse(), FtpWebResponse)
                Notify(Autodatenbank.NI_Successful, "Erfolg", "Neues Verzeichnis wurde auf dem FTP-Server angelegt", 3000, ToolTipIcon.Info)
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