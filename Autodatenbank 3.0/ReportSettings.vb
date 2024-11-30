Imports System.IO

Public Class ReportSettings
    Dim logopath As String = Application.StartupPath & "\Logo.png"
    Private Sub GB_CompanyData_Enter(sender As Object, e As EventArgs) Handles GB_CompanyData.Enter

    End Sub

    Private Sub BTN_SelectNewLogo_Click(sender As Object, e As EventArgs) Handles BTN_SelectNewLogo.Click
        Dim ofd As New OpenFileDialog With {
        .Multiselect = False,
        .Filter = "png-Datei|*.png" & "|All Files|*.*"
        }

        If ofd.ShowDialog = DialogResult.OK Then
            TXB_LogoPath.Text = ofd.FileName
        End If
    End Sub

    Private Sub ReportSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCompanyData()

        If My.Settings.Logoheight > 0 And My.Settings.Logowidth > 0 Then
            TXB_LogoHeight.Text = My.Settings.Logoheight.ToString
            TXB_LogoWidth.Text = My.Settings.Logowidth.ToString

        End If

        If File.Exists(logopath) Then
            LoadLogo()
        End If
    End Sub

    Private Sub BTN_Preview_Click(sender As Object, e As EventArgs) Handles BTN_Preview.Click
        Dim selectedLogo As String = ""
        If Not String.IsNullOrEmpty(TXB_LogoPath.Text) Then
            selectedLogo = TXB_LogoPath.Text
        Else
            selectedLogo = Application.StartupPath & "\Logo.png"
        End If



        If File.Exists(selectedLogo) Then
            ' Original-Bitmap laden
            Dim originalLogo As New Bitmap(selectedLogo)

            ' Zielhöhe und -breite aus den Einstellungen holen
            Dim logoWidth As Integer = CInt(TXB_LogoWidth.Text)
            Dim logoHeight As Integer = CInt(TXB_LogoHeight.Text)

            ' Neue Bitmap mit den gewünschten Abmessungen erstellen
            Dim resizedLogo As New Bitmap(logoWidth, logoHeight)

            ' Das Originalbild auf die neue Größe skalieren und in die neue Bitmap zeichnen
            Using g As Graphics = Graphics.FromImage(resizedLogo)
                g.DrawImage(originalLogo, 0, 0, logoWidth, logoHeight)
            End Using

            PB_Logo.BackgroundImage = resizedLogo
        Else
            MsgBox("Logo konnte nicht geladen werden")
        End If













    End Sub

    Private Sub BTN_Save_Click(sender As Object, e As EventArgs) Handles BTN_Save.Click
        Try

            Try
                SaveCompanyData(TXB_CompName.Text, TXB_CompStreet.Text, TXB_CompCity.Text)
            Catch ex As Exception

            End Try

            If File.Exists(TXB_LogoPath.Text) Then
                PB_Logo.BackgroundImage = Nothing
                File.Copy(TXB_LogoPath.Text, logopath, True)
                My.Settings.Logowidth = CDbl(TXB_LogoWidth.Text)
                My.Settings.Logoheight = CDbl(TXB_LogoHeight.Text)
                My.Settings.Save()
                LoadLogo()
            End If

            Notify(NI_Successful, "Erfolg", "Daten wurden erfolgreich gespeichert", 5000, ToolTipIcon.None)
        Catch ex As Exception
            Notify(NI_Error, "Fehler", "Fehler beim speichern der Daten Fehler wurde in Logfile abgelegt", 5000, ToolTipIcon.None)
            SavetoLogFile(ex.Message, "SaveReportSettings")
        End Try


    End Sub



    Private Sub LoadLogo()
        If My.Settings.Logoheight > 0 And My.Settings.Logowidth > 0 Then
            TXB_LogoHeight.Text = My.Settings.Logoheight.ToString
            TXB_LogoWidth.Text = My.Settings.Logowidth.ToString

        End If

        If File.Exists(logopath) Then
            ' Original-Bitmap laden
            Dim originalLogo As New Bitmap(logopath)

            ' Zielhöhe und -breite aus den Einstellungen holen
            Dim logoWidth As Integer = CInt(My.Settings.Logowidth)
            Dim logoHeight As Integer = CInt(My.Settings.Logoheight)

            ' Neue Bitmap mit den gewünschten Abmessungen erstellen
            Dim resizedLogo As New Bitmap(logoWidth, logoHeight)

            ' Das Originalbild auf die neue Größe skalieren und in die neue Bitmap zeichnen
            Using g As Graphics = Graphics.FromImage(resizedLogo)
                g.DrawImage(originalLogo, 0, 0, logoWidth, logoHeight)
            End Using

            PB_Logo.BackgroundImage = resizedLogo
        End If
    End Sub

    Private Sub TXB_LogoHeight_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXB_LogoHeight.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> ChrW(Keys.Back) Then
            ' Unterdrückt die Eingabe, wenn es keine erlaubte Taste ist
            e.Handled = True
        End If
    End Sub
    Private Sub TXB_LogoWidth_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXB_LogoWidth.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> ChrW(Keys.Back) Then
            ' Unterdrückt die Eingabe, wenn es keine erlaubte Taste ist
            e.Handled = True
        End If
    End Sub
End Class