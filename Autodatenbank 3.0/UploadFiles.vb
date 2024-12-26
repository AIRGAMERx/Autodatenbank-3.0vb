Imports System.Drawing.Imaging
Imports System.IO
Imports System.Net
Public Class UploadFiles
    Public dir As New List(Of String)
    Dim tempFolderPath As String = Path.Combine(Application.StartupPath, "temp")
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
                Me.Size = New Size(444, 198)
                UploadFile()
            Else
                MsgBox("Bezeichnung muss mindestens 3 Zeichen enthalten")
            End If

        End If

    End Sub


    Private Sub UploadFile()
        Try

            If IsValidFileName(TXB_FileName.Text) = True Then

                TXB_FileName.Text = TXB_FileName.Text.Replace("ä", "ae").Replace("Ä", "Ae")
                TXB_FileName.Text = TXB_FileName.Text.Replace("ö", "oe").Replace("Ö", "Oe")
                TXB_FileName.Text = TXB_FileName.Text.Replace("ü", "ue").Replace("Ü", "Ue")



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

    Private Sub TSL_Screenshot_Click(sender As Object, e As EventArgs) Handles TSL_Screenshot.Click
        PB_PrevieScreenshot.BackgroundImage = Nothing

        ' Setze den Cursor auf "Fadenkreuz" für die Auswahl
        Cursor = Cursors.Cross
        Me.Enabled = False ' Deaktiviert die Benutzerinteraktion während des Prozesses
        Try
            ' Zeige das Auswahl-Overlay an
            Dim overlay As New SelectionOverlay()
            If overlay.ShowDialog() = DialogResult.OK Then
                Dim rect As Rectangle = overlay.SelectedRectangle

                ' Prüfe, ob ein gültiger Bereich ausgewählt wurde
                If rect.Width > 0 And rect.Height > 0 Then
                    Dim bmp As New Bitmap(rect.Width, rect.Height)

                    Using g As Graphics = Graphics.FromImage(bmp)
                        g.CopyFromScreen(rect.Location, Point.Empty, rect.Size)
                    End Using

                    ' Speicherort definieren
                    Dim tempFolderPath As String = Path.Combine(Application.StartupPath, "temp")
                    If Not Directory.Exists(tempFolderPath) Then
                        Directory.CreateDirectory(tempFolderPath)
                    End If

                    Dim tempFilePath As String = Path.Combine(tempFolderPath, $"screenshot_{DateTime.Now:yyyyMMdd_HHmmss}.png")

                    ' Screenshot speichern
                    bmp.Save(tempFilePath, Imaging.ImageFormat.Png)
                    TXB_DataPath.Text = tempFilePath
                    TXB_FileName.Text = Path.GetFileName(tempFilePath)

                    Me.Size = New Size(444, 469)
                    ' Lade das Bild sicher in die PictureBox
                    Using fs As New FileStream(tempFilePath, FileMode.Open, FileAccess.Read)
                        PB_PrevieScreenshot.BackgroundImage = Image.FromStream(fs)
                    End Using

                Else
                    MessageBox.Show("Kein gültiger Bereich ausgewählt.")
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            MessageBox.Show($"Ein Fehler ist aufgetreten: {ex.Message}")
        Finally
            ' Setze den Cursor immer zurück, unabhängig vom Ergebnis
            Cursor = Cursors.Default
            Me.Enabled = True ' Reaktiviert das Formular
        End Try
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

Public Class SelectionOverlay
    Inherits Form ' Deine Klasse wird ein Windows-Formular

    Private startPoint As Point
    Private endPoint As Point
    Private isDrawing As Boolean = False
    Public SelectedRectangle As Rectangle

    Private Sub SelectionOverlay_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        ' Startpunkt des Auswahlrahmens
        isDrawing = True
        startPoint = e.Location
    End Sub

    Private Sub SelectionOverlay_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        ' Aktualisiere den Auswahlrahmen, während die Maus gezogen wird
        If isDrawing Then
            endPoint = e.Location
            Me.Invalidate() ' Erzwingt das Neuzeichnen des Formulars
        End If
    End Sub

    Private Sub SelectionOverlay_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp
        ' Beende die Auswahl und speichere das Rechteck
        isDrawing = False
        Dim x As Integer = Math.Min(startPoint.X, endPoint.X)
        Dim y As Integer = Math.Min(startPoint.Y, endPoint.Y)
        Dim width As Integer = Math.Abs(startPoint.X - endPoint.X)
        Dim height As Integer = Math.Abs(startPoint.Y - endPoint.Y)
        SelectedRectangle = New Rectangle(x, y, width, height)
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub SelectionOverlay_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        ' Zeichne den Auswahlrahmen
        If isDrawing Then
            Dim rect As New Rectangle(Math.Min(startPoint.X, endPoint.X),
                                       Math.Min(startPoint.Y, endPoint.Y),
                                       Math.Abs(startPoint.X - endPoint.X),
                                       Math.Abs(startPoint.Y - endPoint.Y))
            Using pen As New Pen(Color.Red, 4)
                e.Graphics.DrawRectangle(pen, rect)
            End Using
        End If
    End Sub

    Private Sub SelectionOverlay_Load(sender As Object, e As EventArgs) Handles Me.Load
        ' Erweitere das Overlay über alle Bildschirme
        Dim screenBounds As Rectangle = Screen.AllScreens.Select(Function(s) s.Bounds).Aggregate(Function(a, b) Rectangle.Union(a, b))
        Me.Bounds = screenBounds

        ' Stelle sicher, dass das Overlay korrekt angezeigt wird
        Me.FormBorderStyle = FormBorderStyle.None
        Me.WindowState = FormWindowState.Normal
        Me.TopMost = True
        Me.BackColor = Color.Black
        Me.Opacity = 0.3 ' Halbtransparent
    End Sub
End Class
