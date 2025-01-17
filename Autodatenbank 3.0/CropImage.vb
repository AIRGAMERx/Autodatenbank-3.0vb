Public Class CropImage
    ' Private Variable für das Originalbild
    Private originalImage As Bitmap

    ' Eigenschaft, um das zugeschnittene Bild zurückzugeben
    Public Property CroppedImage As Bitmap

    ' Rechteck für den Zuschneidebereich
    Private croppingRectangle As Rectangle
    Private isMouseDown As Boolean = False
    Private startX As Integer
    Private startY As Integer

    ' ToolStrip und Buttons
    Private toolStrip As ToolStrip
    Private cropButton As ToolStripButton
    Private cancelsButton As ToolStripButton
    Private rotateButton As ToolStripButton
    Private resetButton As ToolStripButton

    ' Konstruktor: Bild von der Hauptform übergeben
    Public Sub New(image As Bitmap)
        InitializeComponent()
        originalImage = image
    End Sub

    Private Sub CropImage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PictureBox1.Image = originalImage
        PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox1.Dock = DockStyle.Fill

        InitializeToolStrip()
    End Sub

    Private Sub InitializeToolStrip()
        toolStrip = New ToolStrip()

        cropButton = New ToolStripButton("Fertig")
        cancelsButton = New ToolStripButton("Abbrechen")
        rotateButton = New ToolStripButton("Drehen")
        resetButton = New ToolStripButton("Zurücksetzen")

        AddHandler cropButton.Click, AddressOf ButtonCrop_Click
        AddHandler cancelsButton.Click, AddressOf ButtonCancel_Click
        AddHandler rotateButton.Click, AddressOf ButtonRotate_Click
        AddHandler resetButton.Click, AddressOf ButtonReset_Click

        toolStrip.Items.Add(cropButton)
        toolStrip.Items.Add(New ToolStripSeparator())
        toolStrip.Items.Add(rotateButton)
        toolStrip.Items.Add(New ToolStripSeparator())
        toolStrip.Items.Add(resetButton)
        toolStrip.Items.Add(New ToolStripSeparator())
        toolStrip.Items.Add(cancelsButton)

        toolStrip.Dock = DockStyle.Top
        Me.Controls.Add(toolStrip)
    End Sub

    Private Sub PictureBox1_MouseDown(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseDown
        isMouseDown = True
        startX = e.X
        startY = e.Y
    End Sub

    ' MouseMove: Rechteck dynamisch zeichnen
    Private Sub PictureBox1_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseMove
        If isMouseDown Then
            Dim endX As Integer = e.X
            Dim endY As Integer = e.Y
            croppingRectangle = New Rectangle(Math.Min(startX, endX), Math.Min(startY, endY),
                                               Math.Abs(endX - startX), Math.Abs(endY - startY))
            PictureBox1.Refresh()
        End If
    End Sub

    ' MouseUp: Rechteck zeichnen beenden und Bild zuschneiden
    Private Sub PictureBox1_MouseUp(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseUp
        isMouseDown = False

        ' Prüfen, ob das Rechteck gültig ist
        If croppingRectangle.Width > 0 AndAlso croppingRectangle.Height > 0 Then
            ' Dimensionen des angezeigten Bildes berechnen
            Dim imageAspect As Double = originalImage.Width / originalImage.Height
            Dim boxAspect As Double = PictureBox1.ClientSize.Width / PictureBox1.ClientSize.Height

            Dim displayWidth, displayHeight As Integer
            Dim offsetX, offsetY As Integer

            If imageAspect > boxAspect Then
                ' Bild ist breiter als die PictureBox
                displayWidth = PictureBox1.ClientSize.Width
                displayHeight = CInt(PictureBox1.ClientSize.Width / imageAspect)
                offsetX = 0
                offsetY = (PictureBox1.ClientSize.Height - displayHeight) \ 2
            Else
                ' Bild ist höher als die PictureBox
                displayHeight = PictureBox1.ClientSize.Height
                displayWidth = CInt(PictureBox1.ClientSize.Height * imageAspect)
                offsetX = (PictureBox1.ClientSize.Width - displayWidth) \ 2
                offsetY = 0
            End If

            ' Rechteck-Koordinaten auf das tatsächliche Bild skalieren
            Dim scaleX As Double = originalImage.Width / displayWidth
            Dim scaleY As Double = originalImage.Height / displayHeight

            Dim sourceRect As New Rectangle(CInt((croppingRectangle.X - offsetX) * scaleX),
                                         CInt((croppingRectangle.Y - offsetY) * scaleY),
                                         CInt(croppingRectangle.Width * scaleX),
                                         CInt(croppingRectangle.Height * scaleY))

            ' Prüfen, ob das Rechteck innerhalb der Bildgrenzen liegt
            If sourceRect.X < 0 OrElse sourceRect.Y < 0 OrElse
            sourceRect.X + sourceRect.Width > originalImage.Width OrElse
            sourceRect.Y + sourceRect.Height > originalImage.Height Then
                MessageBox.Show("Das ausgewählte Rechteck liegt außerhalb der Bildgrenzen.")
                Return
            End If

            ' Erstelle das zugeschnittene Bild
            Dim croppedBitmap As New Bitmap(sourceRect.Width, sourceRect.Height)
            Using g As Graphics = Graphics.FromImage(croppedBitmap)
                g.DrawImage(originalImage, New Rectangle(0, 0, croppedBitmap.Width, croppedBitmap.Height), sourceRect, GraphicsUnit.Pixel)
            End Using

            ' Zeige das zugeschnittene Bild in der PictureBox an
            PictureBox1.Image = croppedBitmap

            ' Speichere das zugeschnittene Bild für die Rückgabe
            CroppedImage = croppedBitmap

            ' **Roter Rahmen entfernen**
            croppingRectangle = Rectangle.Empty
            PictureBox1.Refresh() ' Aktualisiere die PictureBox, um den Rahmen zu entfernen
        Else
            MessageBox.Show("Das ausgewählte Rechteck ist ungültig. Bitte wählen Sie erneut.")
        End If
    End Sub


    ' Paint: Rechteck auf der PictureBox anzeigen
    Private Sub PictureBox1_Paint(sender As Object, e As PaintEventArgs) Handles PictureBox1.Paint
        If croppingRectangle.Width > 0 AndAlso croppingRectangle.Height > 0 Then
            Dim pen As New Pen(Color.Red, 2)
            e.Graphics.DrawRectangle(pen, croppingRectangle)
        End If
    End Sub

    ' Button: Zuschneiden
    Private Sub ButtonCrop_Click(sender As Object, e As EventArgs)
        ' Prüfen, ob ein Zuschneidebereich definiert ist

        If CroppedImage IsNot Nothing Then
                ' Übergabe des zugeschnittenen Bildes an die Hauptform

                If UploadFiles IsNot Nothing Then
                    UploadFiles.ReceiveCroppedImage(CroppedImage) ' Übergabe an die Hauptform
                End If

                ' Danach die Form schließen
                DialogResult = DialogResult.OK
                Me.Close()
            Else
            If UploadFiles IsNot Nothing And PictureBox1.Image IsNot Nothing Then
                Dim bmp As New Bitmap(PictureBox1.Image)
                UploadFiles.ReceiveCroppedImage(bmp)
                CroppedImage = bmp
                DialogResult = DialogResult.OK
                Me.Close()
            End If
        End If

    End Sub


    ' Button: Abbrechen
    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs)
        DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private unrotatedImage As Bitmap

    Private Sub ButtonRotate_Click(sender As Object, e As EventArgs)
        If PictureBox1.Image IsNot Nothing Then
            Try
                ' Eine Kopie des Bildes erstellen, um Konflikte zu vermeiden
                Dim currentImage As Bitmap = CType(PictureBox1.Image, Bitmap)
                Dim rotatedBitmap As New Bitmap(currentImage)

                ' Bild um 90 Grad drehen
                rotatedBitmap.RotateFlip(RotateFlipType.Rotate90FlipNone)

                ' Aktualisiere das angezeigte Bild
                PictureBox1.Image = rotatedBitmap

                ' Behalte das ursprüngliche Bild unberührt
                If unrotatedImage Is Nothing Then
                    unrotatedImage = CType(originalImage.Clone(), Bitmap)
                End If

                ' Aktualisiere das Originalbild für zukünftige Berechnungen
                originalImage = rotatedBitmap
            Catch ex As Exception
                MessageBox.Show($"Fehler beim Drehen des Bildes: {ex.Message}")
            End Try
        Else
            MessageBox.Show("Kein Bild zum Drehen vorhanden.")
        End If
    End Sub

    Private Sub ButtonReset_Click(sender As Object, e As EventArgs)
        If unrotatedImage IsNot Nothing Then
            Dim oldImage As Image = PictureBox1.Image
            PictureBox1.Image = New Bitmap(unrotatedImage)
            If oldImage IsNot Nothing Then oldImage.Dispose()
        Else
            MessageBox.Show("Kein Originalbild zum Wiederherstellen vorhanden.")
        End If
    End Sub

End Class
