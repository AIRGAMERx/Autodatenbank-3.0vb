Imports System.IO

Public Class ocr
    Private APIKEY As String
    Private Sub btn_OpenFile_Click(sender As Object, e As EventArgs) Handles btn_OpenFile.Click
        FSOFD.Filter = "Bilddateien (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png;*.JPG;*.JPEG;*.PNG"
        If FSOFD.ShowDialog = DialogResult.OK Then
            If File.Exists(FSOFD.FileName) Then
                PB_Preview.BackgroundImage = Image.FromFile(FSOFD.FileName)
                txb_FilePath.Text = FSOFD.FileName
            Else
                PB_Preview.Dispose()
            End If

        End If
    End Sub

    Private Async Sub btn_UploadPicture_Click(sender As Object, e As EventArgs) Handles btn_UploadPicture.Click
        If Await GetAPIKey() = True Then
            Dim ergebnis As String = Await UploadAndOCR(txb_FilePath.Text, My.Settings.Regkey, "ocr", APIKEY)
            MsgBox(ergebnis)
            Dim info = ParseFahrzeugschein(ergebnis)

            Dim ausgabe As String = "Kennzeichen: " & info.Kennzeichen & vbCrLf &
                        "FIN: " & info.FIN & vbCrLf &
                        "Kraftstoff: " & info.Kraftstoff & vbCrLf &
                        "Erstzulassung: " & info.Erstzulassung & vbCrLf &
                        "Adresse: " & info.Adresse

            MessageBox.Show(ausgabe, "Ausgelesene Fahrzeugdaten")
        Else
            MsgBox("APIKEY konnte nicht geladen werden")
        End If




    End Sub


    Private Async Function GetAPIKey() As Task(Of Boolean)
        APIKEY = ""
        APIKEY = Await GetForeignAPIKEY("OCR")
        If APIKEY.Length > 0 Then
            Return True
        Else
            Return False
        End If


    End Function

    Public Function ParseFahrzeugschein(ocrText As String) As FahrzeugscheinInfo
        Dim info As New FahrzeugscheinInfo()
        Dim lines = ocrText.Split({vbCrLf, vbLf}, StringSplitOptions.RemoveEmptyEntries)

        For i = 0 To lines.Length - 1
            Dim line = lines(i).Trim()

            ' FIN (17-stellig, alphanumerisch)
            If info.FIN Is Nothing AndAlso line.Length = 17 AndAlso line.All(Function(c) Char.IsLetterOrDigit(c)) Then
                info.FIN = line
            End If

            ' Kennzeichen (Bindestrich, max. 10 Zeichen)
            If info.Kennzeichen Is Nothing AndAlso line.Contains("-") AndAlso line.Length <= 10 Then
                info.Kennzeichen = line
            End If

            ' Erstzulassung (TT.MM.JJJJ)
            If info.Erstzulassung Is Nothing AndAlso line Like "??.??.????" Then
                info.Erstzulassung = line
            End If

            ' Kraftstoff
            If info.Kraftstoff Is Nothing Then
                Dim l = line.ToUpper()
                If l.Contains("DIESEL") Then info.Kraftstoff = "DIESEL"
                If l.Contains("BENZIN") Then info.Kraftstoff = "BENZIN"
                If l.Contains("ELEKTRO") Then info.Kraftstoff = "ELEKTRO"
                If l.Contains("HYBRID") Then info.Kraftstoff = "HYBRID"
            End If

            ' Adresse (PLZ beginnt mit 5 Ziffern)
            If info.Adresse Is Nothing AndAlso line Like "#####*" Then
                Dim nextLine = If(i + 1 < lines.Length, lines(i + 1).Trim(), "")
                info.Adresse = line & " " & nextLine
            End If
        Next

        Return info
    End Function

End Class

Public Class FahrzeugscheinInfo
    Public Property FIN As String
    Public Property Modell As String
    Public Property Hersteller As String
    Public Property Kraftstoff As String
    Public Property Erstzulassung As String
    Public Property Adresse As String
    Public Property Kennzeichen As String
End Class