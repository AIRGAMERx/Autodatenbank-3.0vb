Imports TwainDotNet
Imports TwainDotNet.WinFroms

Public Class Scann
    Private SingleScannFormats As String() = {".jpg", ".png"}
    Private MultiScannFormats As String() = {".pdf"}
    Private Twain As Twain
    Private scannerList As List(Of String)
    Private scannedImages As List(Of Image)

    Public Sub New()
        InitializeComponent()
        ' Twain-Instanz erstellen
        Twain = New Twain(New WinFormsWindowMessageHook(Me))
        scannedImages = New List(Of Image)()
    End Sub

    Private Sub Scann_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ' Twain-Instanz initialisieren
            Twain = New Twain(New WinFormsWindowMessageHook(Me))
            LoadAvailableScanners()
        Catch ex As Exception
            MessageBox.Show($"Fehler beim Initialisieren von Twain: {ex.Message}", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CB_UseSingleScann_CheckedChanged(sender As Object, e As EventArgs) Handles CB_UseSingleScann.CheckedChanged
        If CB_UseSingleScann.Checked Then
            CB_UseAutoFeeder.Checked = False
            CBB_OutputFormat.Items.Clear()
            CBB_OutputFormat.Text = ""
            For Each Item As String In SingleScannFormats
                CBB_OutputFormat.Items.Add(Item)
            Next

        Else
            CBB_OutputFormat.Items.Clear()

        End If

    End Sub

    Private Sub CB_UseAutoFeeder_CheckedChanged(sender As Object, e As EventArgs) Handles CB_UseAutoFeeder.CheckedChanged
        If CB_UseAutoFeeder.Checked Then
            CB_UseSingleScann.Checked = False
            CBB_OutputFormat.Items.Clear()
            CBB_OutputFormat.Text = ""
            For Each Item As String In MultiScannFormats
                CBB_OutputFormat.Items.Add(Item)
            Next

        Else
            CBB_OutputFormat.Items.Clear()

        End If
    End Sub

    Private Sub LoadAvailableScanners()
        Try
            ' Scanner-Liste abrufen
            scannerList = New List(Of String)()
            For Each source In Twain.SourceNames
                scannerList.Add(source)
            Next

            ' Scanner in ComboBox einfügen
            CBB_ListScanner.Items.Clear()
            CBB_ListScanner.Items.AddRange(scannerList.ToArray())

            ' Ersten Scanner auswählen, falls verfügbar
            If CBB_ListScanner.Items.Count > 0 Then
                CBB_ListScanner.SelectedIndex = 0
            Else
                MessageBox.Show("Keine Scanner gefunden!", "Hinweis", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show($"Fehler beim Laden der Scanner: {ex.Message}", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CBB_ListScanner_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBB_ListScanner.SelectedIndexChanged
        If CBB_ListScanner.SelectedIndex < -1 Then
            Dim selectedScanner = CBB_ListScanner.SelectedItem.ToString
            Twain.SelectSource(selectedScanner)

            Try
                Dim supportsADF = CheckADFSupport()
                If supportsADF = False Then
                    CB_UseAutoFeeder.Checked = False
                    CB_UseAutoFeeder.Enabled = False
                Else
                    CB_UseAutoFeeder.Checked = True
                    CB_UseAutoFeeder.Enabled = True
                End If
            Catch ex As Exception

            End Try
        End If
    End Sub


    Public Function CheckADFSupport() As Boolean
        ' Versuche den Feeder zu aktivieren
        Try
            Dim settings As New ScanSettings()
            settings.UseAutoFeeder = True

            ' Wenn keine Ausnahme ausgelöst wird, wird ADF unterstützt
            Return True
        Catch ex As Exception
            ' ADF wird nicht unterstützt
            Return False
        End Try
    End Function

    Private Sub BTN_BeginnScann_Click(sender As Object, e As EventArgs) Handles BTN_BeginnScann.Click
        Select Case True
            Case CB_UseAutoFeeder.Checked = False And CB_UseSingleScann.Checked = False
                MsgBox("Bitte Einzug auswählen")
                Exit Sub
            Case CBB_ListScanner.SelectedIndex < 0
                MsgBox("Bitte Scanner auswählen")
                Exit Sub
            Case CBB_OutputFormat.SelectedIndex < 0
                MsgBox("Bitte Format auswählen")
                Exit Sub
        End Select


        Dim selectedScanner = CBB_ListScanner.SelectedItem.ToString()
        Twain.SelectSource(selectedScanner)
        Dim AF As Boolean = CB_UseAutoFeeder.Checked

        Try
            Dim settings As New ScanSettings() With {
                .UseAutoFeeder = AF,
                .ShowTwainUI = True,
                .Resolution = New ResolutionSettings(),
                .Page = PageSettings.Default}

            MsgBox(AF.ToString)

            AddHandler Twain.TransferImage, AddressOf OnTransferImage
            AddHandler Twain.ScanningComplete, AddressOf OnScanningComplete

            Twain.StartScanning(settings)
        Catch ex As Exception

        End Try





    End Sub


    Private Sub OnTransferImage(sender As Object, args As TransferImageEventArgs)
        If args.Image IsNot Nothing Then
            ' Gescanntes Bild in der Liste speichern
            scannedImages.Add(args.Image)

            ' Optional: Vorschau anzeigen
            PB_Preview.Image = args.Image
        End If
    End Sub

    Private Sub OnScanningComplete(sender As Object, e As EventArgs)
        ' Scan abgeschlossen
        MessageBox.Show($"Scan abgeschlossen. {scannedImages.Count} Dokumente gescannt.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)

        ' Event-Handler entfernen
        RemoveHandler Twain.TransferImage, AddressOf OnTransferImage
        RemoveHandler Twain.ScanningComplete, AddressOf OnScanningComplete
    End Sub
End Class




