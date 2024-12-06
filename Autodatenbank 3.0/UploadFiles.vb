Imports System.IO
Imports System.Net
Public Class UploadFiles
    Public dir As New List(Of String)
    Private Sub BTN_SelectFile_Click(sender As Object, e As EventArgs) Handles BTN_SelectFile.Click
        If OFD_UploadFiles.ShowDialog() = DialogResult.OK Then
            TXB_DataPath.Text = OFD_UploadFiles.FileName
            If TXB_FileName.Text.Length = 0 Then
                TXB_FileName.Text = OFD_UploadFiles.SafeFileName
            End If
        End If
    End Sub

    Private Sub BTN_Upload_Click(sender As Object, e As EventArgs) Handles BTN_Upload.Click
        If TXB_FileName.Text.ToLower = "mycar" Then
            MsgBox("mycar ist ein Systemreservierter string")
        Else
            If TXB_FileName.Text.Length > 3 Then
                UploadFile()
            Else
                MsgBox("Bezeichnung muss mindestens 3 Zeichen enthalten")
            End If

        End If

    End Sub


    Private Sub UploadFile()
        Try

            If IsValidFileName(TXB_FileName.Text) = True Then

                If File.Exists(TXB_DataPath.Text) Then

                    If My.Settings.sftp = True Then
                        ' SFTP-Upload ausführen
                        SFTP.UploadFileToSFTP(TXB_DataPath.Text, TXB_FileName.Text)
                    Else
                        ' FTP-Upload ausführen
                        FTP.UploadFileToFTP(TXB_DataPath.Text, TXB_FileName.Text)
                    End If
                    Me.Close()
                Else
                    MsgBox("Ausgewählte Datei konnte nicht gefunden werden")
                End If
            Else
                MsgBox("Fehler im Dateinamen prüfe folgende Sachen" & vbNewLine &
                "Der Dateiname enthält ungültige Zeichen für Dateinamen (z. B. *, /, , :)." & vbNewLine &
                "Dateiendung ist nicht angegeben" & vbNewLine &
                "Dateiname beginnt oder endet mit einem Punkt")
            End If
        Catch ex As Exception
            MsgBox("Fehler beim Hochladen der Datei: " & ex.Message, MsgBoxStyle.Critical, "Fehler beim Upload")
            SavetoLogFile(ex.Message, "UploadFile")
        End Try

    End Sub


    Public Sub UploadProgressChanged(sender As Object, e As UploadProgressChangedEventArgs)
        ProgressBar1.Value = e.ProgressPercentage
    End Sub

    Public Sub UploadFileCompleted(sender As Object, e As UploadFileCompletedEventArgs)
        If e.Error Is Nothing Then
            If My.Settings.sftp = True Then
                SFTP.ListFilesFromSFTPForDGV2(Autodatenbank.Licenseplate)
            Else
                FTP.ListFilesFromFTPForDGV2(Autodatenbank.Licenseplate)
            End If
            MsgBox("Datei wurde erfolgreich hochgeladen")
        Else
            MsgBox("Fehler beim Hochladen der Datei: " & e.Error.Message, MsgBoxStyle.Critical, Title:="Fehler beim Upload")
        End If
        Me.Close()
    End Sub


    Private Function IsValidFileName(fileName As String) As Boolean
        If String.IsNullOrWhiteSpace(fileName) Then
            Return False
        End If

        ' Definiere Zeichen, die im Dateinamen nicht erlaubt sind
        Dim invalidChars() As Char = Path.GetInvalidFileNameChars()

        ' Prüfe, ob der Dateiname ungültige Zeichen enthält
        If fileName.IndexOfAny(invalidChars) <> -1 Then
            Return False
        End If

        ' Prüfe, ob der Dateiname einen Punkt enthält (erforderlich für eine Dateiendung)
        If Not fileName.Contains(".") Then
            Return False
        End If

        ' Prüfe, ob der Dateiname mit einem Punkt beginnt oder endet
        If fileName.StartsWith(".") OrElse fileName.EndsWith(".") Then
            Return False
        End If

        ' Prüfe, ob der Dateiname aus einem oder mehreren Leerzeichen besteht
        If fileName.Trim().Length = 0 Then
            Return False
        End If

        ' Wenn alle Bedingungen erfüllt sind, ist der Dateiname gültig
        Return True
    End Function

    Private Sub UploadFiles_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadOverallSettings()
    End Sub
End Class
Public Class FtpHelperUpload

    Public Shared Sub CreateFtpDirectory(serverUri As String, username As String, password As String, directoryPath As String)
        Dim request As FtpWebRequest = CType(WebRequest.Create(serverUri + "/" + directoryPath), FtpWebRequest)
        request.Credentials = New NetworkCredential(username, password)
        request.Method = WebRequestMethods.Ftp.MakeDirectory

        Try
            Using response As FtpWebResponse = CType(request.GetResponse(), FtpWebResponse)
                ' Der Ordner wurde erfolgreich erstellt
                Console.WriteLine("Der Ordner wurde erfolgreich erstellt.")
            End Using
        Catch ex As WebException
            Dim response As FtpWebResponse = CType(ex.Response, FtpWebResponse)
            ' Wenn der Server antwortet, dass der Pfad nicht gefunden wurde, kann der Ordner nicht erstellt werden
            If response.StatusCode = FtpStatusCode.ActionNotTakenFileUnavailable Then
                Console.WriteLine("Der Ordner konnte nicht erstellt werden, möglicherweise existiert ein übergeordneter Ordner nicht.")
                SavetoLogFile(ex.Message, "FTPUPload")
            Else
                ' Andere Fehler sollten behandelt werden, falls erforderlich
                Throw
            End If
        End Try
    End Sub

    Public Shared Sub ListDirs(serveruri As String, username As String, password As String)

        Dim request As Net.FtpWebRequest = DirectCast(Net.FtpWebRequest.Create(serveruri), Net.FtpWebRequest)
        request.Method = Net.WebRequestMethods.Ftp.ListDirectory
        request.Credentials = New Net.NetworkCredential(username, password)
        Dim response As Net.FtpWebResponse = DirectCast(request.GetResponse(), FtpWebResponse)
        Using myreader As New IO.StreamReader(response.GetResponseStream)
            Do While myreader.EndOfStream = False
                UploadFiles.dir.Add(myreader.ReadLine)
            Loop
        End Using






    End Sub
End Class