Imports System.Drawing.Imaging
Imports System.IO
Imports System.Net
Imports System.Runtime.InteropServices
Imports TwainDotNet
Imports TwainDotNet.TwainNative
Imports TwainDotNet.WinFroms
Public Class UploadFiles
    Private Twain As Twain
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
        Dim extensionList As New List(Of String) From {".jpg", ".png", ".bmp"}
        Dim thumbnailPathTemp As String = Path.Combine(Application.StartupPath, "Temp\thumbnail.jpg")
        Dim thumbnailCreated As Boolean = False
        Try
            ' Temp-Verzeichnis erstellen
            CreateTempDirectory()

            ' Dateiname validieren
            If Not IsValidFileName(TXB_FileName.Text) Then
                MsgBox("Fehler im Dateinamen. Prüfe folgende Dinge:" & vbNewLine &
                   "- Ungültige Zeichen im Dateinamen (z. B. *, /, :, etc.)" & vbNewLine &
                   "- Fehlende Dateiendung" & vbNewLine &
                   "- Dateiname beginnt oder endet mit einem Punkt.", MsgBoxStyle.Critical)
                Exit Sub
            End If

            ' Sonderzeichen im Dateinamen ersetzen
            TXB_FileName.Text = ReplaceUmlauts(TXB_FileName.Text)

            ' Prüfen, ob die Datei existiert
            If Not File.Exists(TXB_DataPath.Text) Then
                MsgBox("Die ausgewählte Datei konnte nicht gefunden werden.", MsgBoxStyle.Critical)
                Exit Sub
            End If

            ' Überprüfen der Dateiendung
            Dim ext As String = Path.GetExtension(TXB_DataPath.Text).ToLower()
            If extensionList.Contains(ext) Then
                ' Thumbnail erstellen
                thumbnailCreated = CreateThumbnail(TXB_DataPath.Text, thumbnailPathTemp)
            End If

            ' Wenn das Thumbnail nicht erstellt werden konnte
            If Not thumbnailCreated AndAlso extensionList.Contains(ext) Then
                ' Benutzer fragen, ob er trotzdem fortfahren möchte
                Dim result As DialogResult = MessageBox.Show("Fehler beim Erstellen des Thumbnails. Trotzdem fortfahren?", "Fehler", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                If result = DialogResult.No Then
                    ' Benutzer hat entschieden, nicht fortzufahren – gesamte Aktion abbrechen
                    Exit Sub
                End If
            End If

            ' Thumbnail hochladen, wenn erstellt
            If thumbnailCreated Then
                If My.Settings.sftp Then
                    UploadThumbnailToSFTP(thumbnailPathTemp, TXB_FileName.Text)
                Else
                    UploadThumbnailToFTP(thumbnailPathTemp, TXB_FileName.Text)
                End If
            End If

            ' Hauptdatei hochladen – nur nach Benutzerbestätigung oder erfolgreicher Thumbnail-Erstellung
            If My.Settings.sftp Then
                SFTP.UploadFileToSFTP(TXB_DataPath.Text, TXB_FileName.Text)
            Else
                FTP.UploadFileToFTP(TXB_DataPath.Text, TXB_FileName.Text)
            End If

            ' Erfolgreiche Benachrichtigung
            Notify(Autodatenbank.NI_Successful, "Erfolg", "Datei erfolgreich hochgeladen", 3000, ToolTipIcon.None)

            ' Fenster schließen
            Me.Close()
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
        TT_Info(PB_PrevieScreenshot, "Bearbeiten", "Zum bearbeiten des Dokuments Rechtsklick")
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
                    ' Erhalte den Monitor, auf dem sich der ausgewählte Bereich befindet
                    Dim screen As Screen = Screen.FromRectangle(rect)

                    ' Berechne die korrekten absoluten Koordinaten (inkl. Monitor-Offset)
                    Dim adjustedX As Integer = rect.X + screen.Bounds.X
                    Dim adjustedY As Integer = rect.Y + screen.Bounds.Y

                    ' Bildschirm-Skalierung des Monitors berücksichtigen
                    Dim dpiX As Single = Graphics.FromHwnd(IntPtr.Zero).DpiX / 96.0F
                    Dim dpiY As Single = Graphics.FromHwnd(IntPtr.Zero).DpiY / 96.0F

                    ' Skaliere den ausgewählten Bereich
                    Dim scaledRect As New Rectangle(CInt(adjustedX * dpiX),
                                                 CInt(adjustedY * dpiY),
                                                 CInt(rect.Width * dpiX),
                                                 CInt(rect.Height * dpiY))

                    ' Screenshot erstellen
                    Dim bmp As New Bitmap(scaledRect.Width, scaledRect.Height)
                    Using g As Graphics = Graphics.FromImage(bmp)
                        g.CopyFromScreen(New Point(scaledRect.X, scaledRect.Y), Point.Empty, scaledRect.Size)
                    End Using

                    ' Speicherort definieren
                    Dim tempFolderPath As String = Path.Combine(Application.StartupPath, "temp")
                    CreateTempDirectory()
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




    Private Sub TSL_Scann_Click(sender As Object, e As EventArgs) Handles TSL_Scann.Click
        Scann.Show()


        'Try
        ' TWAIN-Manager initialisieren
        ' Twain = New Twain(New WinFormsWindowMessageHook(Me))

        ' Ereignisse definieren
        ' AddHandler Twain.TransferImage, AddressOf OnImageScanned
        ' AddHandler Twain.ScanningComplete, AddressOf OnScanComplete

        ' Scanner auswählen
        ' Twain.SelectSource()

        ' Scan-Einstellungen festlegen
        ' Dim Settings As New ScanSettings()
        ' Settings.ShowTwainUI = False ' Zeigt die Scanner-Benutzeroberfläche an
        ' Settings.Resolution = New ResolutionSettings()
        ' Settings.UseAutoFeeder = False ' Flachbett-Scanner verwenden
        '  Settings.UseDuplex = False ' Einseitiges Scannen
        '
        ' Scan starten
        'Twain.StartScanning(Settings)

        'Catch ex As Exception
        ' MsgBox($"Fehler beim Scannen: {ex.Message}")
        ' End Try '
    End Sub

    ' Bild speichern


    Private Sub OnImageScanned(sender As Object, args As TransferImageEventArgs)
        If args.Image IsNot Nothing Then
            Try
                ' Temp-Ordner erstellen
                Dim tempFolderPath As String = Path.Combine(Application.StartupPath, "temp")
                If Not Directory.Exists(tempFolderPath) Then
                    Directory.CreateDirectory(tempFolderPath)
                End If

                ' Pfad für die gescannte Datei erstellen
                Dim tempFilePath As String = Path.Combine(tempFolderPath, $"scanned_document_{DateTime.Now:yyyyMMdd_HHmmss}.png")

                ' Bitmap erstellen und speichern
                Using bitmap As New Bitmap(args.Image)
                    bitmap.Save(tempFilePath, System.Drawing.Imaging.ImageFormat.Png)
                End Using

                ' Daten in die Textboxen schreiben
                TXB_DataPath.Text = tempFilePath
                TXB_FileName.Text = Path.GetFileName(tempFilePath)

                ' Bild in der PictureBox anzeigen
                Using fs As New FileStream(tempFilePath, FileMode.Open, FileAccess.Read)
                    PB_PrevieScreenshot.BackgroundImage = Image.FromStream(fs)
                End Using

                ' Größe der Form anpassen (optional)
                Me.Size = New Size(444, 469)
            Catch ex As Exception
                ' Fehlerbehandlung
                MsgBox($"Fehler beim Speichern des Bildes: {ex.Message}{vbCrLf}StackTrace: {ex.StackTrace}")
            End Try
        Else
            MsgBox("Kein Bild zum Speichern vorhanden.")
        End If
    End Sub

    Private Sub OnScanComplete(sender As Object, e As EventArgs)
        MsgBox("Scannen abgeschlossen.")
    End Sub

    Private Sub ZuschneidenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ZuschneidenToolStripMenuItem.Click
        ' Prüfen, ob ein Bild in der PictureBox vorhanden ist
        If PB_PrevieScreenshot.BackgroundImage Is Nothing Then
            MessageBox.Show("Es ist kein Bild zum Zuschneiden vorhanden.")
            Return
        End If

        ' Das Bild, das zugeschnitten werden soll (z. B. aus einer PictureBox)
        Dim cropForm As New CropImage(CType(PB_PrevieScreenshot.BackgroundImage, Bitmap))

        ' Zuschneideform anzeigen
        If cropForm.ShowDialog() = DialogResult.OK Then
            ' Das zugeschnittene Bild aus der Form zurückholen
            Dim croppedImage As Bitmap = cropForm.CroppedImage

            ' Sicherstellen, dass ein Bild zurückgegeben wurde
            If croppedImage Is Nothing Then
                MessageBox.Show("Das Zuschneiden wurde nicht abgeschlossen.")
                Return
            End If

            ' Das zugeschnittene Bild an die Hauptform übergeben
            ReceiveCroppedImage(croppedImage)

        Else
            MessageBox.Show("Das Zuschneiden wurde abgebrochen.")
        End If
    End Sub

    Public Sub ReceiveCroppedImage(croppedImage As Bitmap)
        'Temporäre Speicherung des Bildes
        Dim tempFilePath As String = Path.Combine(tempFolderPath, $"scanned_cropped_document_{DateTime.Now:yyyyMMdd_HHmmss}.png")



        ' Zeige das zugeschnittene Bild in der PictureBox an
        PB_PrevieScreenshot.BackgroundImage = croppedImage

        ' Speichere das Bild auf der Festplatte

        croppedImage.Save(tempFilePath, Imaging.ImageFormat.Jpeg)
        TXB_DataPath.Text = tempFilePath

        ' Optional: Benutzer informieren

    End Sub

    Private Sub ToolStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStrip1.ItemClicked

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


