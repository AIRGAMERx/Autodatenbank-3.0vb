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
            Autodatenbank.dgv2.Rows.Clear()
            Dim i As Integer = -1
            Dim anfrage As FtpWebRequest = CType(WebRequest.Create(My.Settings.Ftpserveruri + "/" + Licenseplate), FtpWebRequest)
            anfrage.Method = WebRequestMethods.Ftp.ListDirectoryDetails
            anfrage.Credentials = New NetworkCredential(My.Settings.Ftpusername, My.Settings.Ftppassword)

            Using antwort As FtpWebResponse = CType(anfrage.GetResponse(), FtpWebResponse)
                Using streamReader As New System.IO.StreamReader(antwort.GetResponseStream())
                    While Not streamReader.EndOfStream
                        i += 1
                        Try
                            Dim zeile As String = streamReader.ReadLine()
                            Dim zeilenteile() As String = zeile.Split(" "c)
                            Dim dateiname As String = zeilenteile(zeilenteile.Length - 1)
                            Dim datum As String = zeilenteile(zeilenteile.Length - 3)
                            Dim pfad As String = My.Settings.Ftpserveruri + "/" + Licenseplate + "/" + dateiname

                            Autodatenbank.dgv2.Rows.Add()
                            Autodatenbank.dgv2.Rows(i).Cells(0).Value = dateiname
                            Autodatenbank.dgv2.Rows(i).Cells(1).Value = datum
                            Autodatenbank.dgv2.Rows(i).Cells(2).Value = pfad
                        Catch ex As Exception
                        End Try
                    End While
                End Using
            End Using

            For Each row As DataGridViewRow In Autodatenbank.dgv2.Rows
                If row.Cells(0).Value.ToString = "." Then

                    Autodatenbank.dgv2.Rows.Remove(row)
                End If
            Next

            For Each row As DataGridViewRow In Autodatenbank.dgv2.Rows
                If row.Cells(0).Value.ToString = ".." Then

                    Autodatenbank.dgv2.Rows.Remove(row)
                End If
            Next

        Catch ex As Exception
            MsgBox("Fehler bei der FTP-Verbindung: " & ex.Message, MsgBoxStyle.Critical)
            SavetoLogFile(ex.Message, "ListFilesFromFTP")
        End Try





    End Sub




    Public Sub UploadFileToFTP(DataPath As String, Dataname As String)
        Try
            ' Überprüfen, ob der Ordner für das Kennzeichen auf dem FTP-Server vorhanden ist
            FtpHelperUpload.ListDirs(My.Settings.Ftpserveruri & "/", My.Settings.Ftpusername, My.Settings.Ftppassword)

            ' Ordner erstellen, falls nicht vorhanden
            For Each directoryName As String In Dir()

                If directoryName <> Autodatenbank.Licenseplate Then
                    FTPHelper.CreateDirectory(My.Settings.Ftpserveruri, My.Settings.Ftpusername, My.Settings.Ftppassword, Autodatenbank.Licenseplate)
                End If
            Next

            ' FTP-Daten-Upload
            Dim wc As New WebClient()
            AddHandler wc.UploadProgressChanged, AddressOf UploadFiles.UploadProgressChanged
            AddHandler wc.UploadFileCompleted, AddressOf UploadFiles.UploadFileCompleted

            wc.Credentials = New NetworkCredential(My.Settings.Ftpusername, My.Settings.Ftppassword)
            wc.UploadFileAsync(New Uri(My.Settings.Ftpserveruri & "/" & Autodatenbank.Licenseplate & "/" & Dataname), DataPath)
        Catch ex As Exception
            MsgBox("Fehler beim FTP-Upload: " & ex.Message, MsgBoxStyle.Critical, "Fehler")
            SavetoLogFile(ex.Message, "UploadFileViaFTP")
        End Try
    End Sub

End Module
Public Class FTPHelper

    Public Shared Sub CreateDirectory(ByVal serverUri As String, ByVal username As String, ByVal password As String, ByVal directoryName As String)
        Dim request As FtpWebRequest = CType(WebRequest.Create(serverUri + "/" + directoryName), FtpWebRequest)
        request.Method = WebRequestMethods.Ftp.MakeDirectory
        request.Credentials = New NetworkCredential(username, password)

        Try
            Dim response As FtpWebResponse = CType(request.GetResponse(), FtpWebResponse)
            Console.WriteLine("Ordner erfolgreich erstellt: " + directoryName)
            response.Close()
        Catch ex As Exception
            Console.WriteLine("Fehler beim Erstellen des Ordners: " + ex.Message)
            SavetoLogFile(ex.Message, "FTPHelper")
        End Try
    End Sub

End Class