Public Class ViewSettings

    Private selectedFontFamilyDGV As String
    Private selectedFontSizeDGV As Single
    Private selectedForeColorDGV As Color
    Private selectedBackgroundColorDGV As Color
    Private selectedCellsColorDGV As Color
    Private selectedBackgroundColorOverall As Color
    Private selectedCarInfoColorOverall As Color
    Private selectedForeColorOverall As Color
    Private selectedFontFamilyOverall As String



    Private Sub ViewSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
#Region "DGV Settings Page Load"
        ' Schritt 1: Schriftarten laden
        For Each font As FontFamily In FontFamily.Families
            cbb_FontFamilyDGV.Items.Add(font.Name)
        Next

        ' Schritt 2: Farben laden
        For Each knownColor As KnownColor In [Enum].GetValues(GetType(KnownColor))
            If knownColor.ToString() <> "Transparent" Then
                cbb_ForeColorDGV.Items.Add(knownColor.ToString())
                CBB_DGVSettingsBackgroundcolor.Items.Add(knownColor.ToString())
                CBB_DGVSettingsCellsColor.Items.Add(knownColor.ToString())
            End If

        Next

        ' Schritt 3: Standardwerte setzen (falls ComboBoxen leer sind)
        If cbb_FontFamilyDGV.Items.Count > 0 Then
            cbb_FontFamilyDGV.SelectedIndex = 0
        End If

        If cbb_ForeColorDGV.Items.Count > 0 Then
            cbb_ForeColorDGV.SelectedIndex = 0
        End If

        If CBB_DGVSettingsBackgroundcolor.Items.Count > 0 Then
            CBB_DGVSettingsBackgroundcolor.SelectedIndex = 0
        End If

        If CBB_DGVSettingsCellsColor.Items.Count > 0 Then
            CBB_DGVSettingsCellsColor.SelectedIndex = 0
        End If

        ' Schritt 4: Einstellungen laden (nachdem die ComboBoxen initialisiert sind)
        LoadDGVSettings()


        ' Optional: Anwendung der geladenen Einstellungen auf die UI
        TestNewStyle()

        ' Schritt 5: DataGridView vorbereiten
        DGV_TestSettingDGV.Rows.Add()

        ' Sicherstellen, dass das DataGridView mindestens eine Zeile enthält
        If DGV_TestSettingDGV.Rows.Count > 0 Then
            ' Zugriff auf die zuletzt hinzugefügte Zeile 
            DGV_TestSettingDGV.Rows(0).Cells(0).Value = Date.Now
            DGV_TestSettingDGV.Rows(0).Cells(1).Value = "Zwei flinke Boxer jagen die quirlige Eva und ihren Mops durch Sylt"
        End If

#End Region
#Region "Overall Settings Page Load"

        ' Schritt 1: Farben laden
        For Each knownColor As KnownColor In [Enum].GetValues(GetType(KnownColor))
            ' Überprüfen Sie, ob der Name nicht "Transparent" ist
            If knownColor.ToString() <> "Transparent" Then
                CBB_OverallSettingsFormBackground.Items.Add(knownColor.ToString())
                CBB_OverallBackgroundCarInfo.Items.Add(knownColor.ToString())
                CBB_OverallSettingsLabelForeColor.Items.Add(knownColor.ToString)
            End If
        Next

        ' Schritt 2: Font Family laden
        For Each font As FontFamily In FontFamily.Families
            CBB_OverallSettingsFontFamily.Items.Add(font.Name)
        Next



        ' Schritt 3: Standardwerte setzen (falls ComboBoxen leer sind)

        If CBB_OverallSettingsFormBackground.Items.Count > 0 Then
            CBB_OverallSettingsFormBackground.SelectedItem = 0
        End If

        If CBB_OverallBackgroundCarInfo.Items.Count > 0 Then
            CBB_OverallBackgroundCarInfo.SelectedItem = 0
        End If

        ' Schritt 4: Einstellungen laden (nachdem die ComboBoxen initialisiert sind)
        LoadOverallSettings()


        ' Optional: Anwendung der geladenen Einstellungen auf die UI
        TestOverallColors()
        TestOverallLabelSettings()

#End Region

    End Sub
#Region "DGV Settings Functions"
    Private Sub cbb_FontFamily_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbb_FontFamilyDGV.SelectedIndexChanged
        TestNewStyle()

    End Sub

    Private Sub cbb_FontSize_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbb_FontSizeDGV.SelectedIndexChanged
        TestNewStyle()
    End Sub

    Private Sub cbb_ForeColorDGV_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbb_ForeColorDGV.SelectedIndexChanged
        TestNewStyle()
    End Sub

    Private Sub CBB_DGVSettingsBackgroundcolor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBB_DGVSettingsBackgroundcolor.SelectedIndexChanged
        TestNewStyle()
    End Sub

    Private Sub CBB_DGVSettingsCellsColor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBB_DGVSettingsCellsColor.SelectedIndexChanged
        TestNewStyle()
    End Sub

    Public Sub TestNewStyle()
        If cbb_FontFamilyDGV.SelectedItem IsNot Nothing AndAlso cbb_FontSizeDGV.SelectedItem IsNot Nothing AndAlso cbb_ForeColorDGV.SelectedItem IsNot Nothing AndAlso CBB_DGVSettingsBackgroundcolor.SelectedItem IsNot Nothing AndAlso CBB_DGVSettingsCellsColor.SelectedItem IsNot Nothing Then

            ' Initialisieren der Klassenvariablen für Schriftart und Schriftgröße
            selectedFontFamilyDGV = cbb_FontFamilyDGV.SelectedItem.ToString()
            selectedFontSizeDGV = CSng(cbb_FontSizeDGV.SelectedItem.ToString())

            ' Erstellen des Font-Objekts basierend auf den ausgewählten Werten
            Dim selectedFont As New Font(selectedFontFamilyDGV, selectedFontSizeDGV)

            ' Initialisieren der Klassenvariablen für Farben
            selectedForeColorDGV = Color.FromKnownColor(DirectCast([Enum].Parse(GetType(KnownColor), cbb_ForeColorDGV.SelectedItem.ToString()), KnownColor))
            selectedBackgroundColorDGV = Color.FromKnownColor(DirectCast([Enum].Parse(GetType(KnownColor), CBB_DGVSettingsBackgroundcolor.SelectedItem.ToString()), KnownColor))
            selectedCellsColorDGV = Color.FromKnownColor(DirectCast([Enum].Parse(GetType(KnownColor), CBB_DGVSettingsCellsColor.SelectedItem.ToString()), KnownColor))

            ' Anwenden der neuen Schriftart und Farbe auf das DataGridView
            DGV_TestSettingDGV.Font = selectedFont
            DGV_TestSettingDGV.ForeColor = selectedForeColorDGV
            DGV_TestSettingDGV.BackgroundColor = selectedBackgroundColorDGV
            DGV_TestSettingDGV.DefaultCellStyle.BackColor = selectedCellsColorDGV
        End If
    End Sub

    Private Sub BTN_SaveDGVSettings_Click(sender As Object, e As EventArgs) Handles BTN_SaveDGVSettings.Click

        Try
            SaveDGVSettings(selectedFontFamilyDGV, selectedFontSizeDGV, selectedForeColorDGV.Name, selectedBackgroundColorDGV.Name, selectedCellsColorDGV.Name, ShownData.ToString)
            MsgBox("Einstellung erfolgreich gespeichert" & vbNewLine & "Bitte starten Sie die Anwendung neu, um die Einstellungen zu visualiseren", MsgBoxStyle.Information)
        Catch ex As Exception
            MsgBox("Fehler beim Speichern der Einstellungen " & ex.Message)
            SavetoLogFile(ex.Message, "SaveDGVSettings")
        End Try

    End Sub

    Private Function ShownData() As String
        Dim Key As String = ""


        If CB_DGVSettingsDataLP.Checked Then
            Key &= "1"
        Else
            Key &= "0"
        End If

        If CB_DGVSettingsDataDC.Checked Then
            Key &= "1"
        Else
            Key &= "0"
        End If

        If CB_DGVSettingsDataMA.Checked Then
            Key &= "1"
        Else
            Key &= "0"
        End If

        If CB_DGVSettingsDataDate.Checked Then
            Key &= "1"
        Else
            Key &= "0"
        End If

        If CB_DGVSettingsDataPrice.Checked Then
            Key &= "1"
        Else
            Key &= "0"
        End If

        If CB_DGVSettingsDataComm.Checked Then
            Key &= "1"
        Else
            Key &= "0"
        End If

        If CB_DGVSettingsDataArt.Checked Then
            Key &= "1"
        Else
            Key &= "0"
        End If

        If CB_DGVSettingsDataEditor.Checked Then
            Key &= "1"
        Else
            Key &= "0"
        End If


        Return Key



    End Function


#End Region

#Region "Overall Settings Functions"

    Private Sub CBB_OverallSettingsFormBackground_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBB_OverallSettingsFormBackground.SelectedIndexChanged
        TestOverallColors()
    End Sub
    Private Sub CBB_OverallBackgroundCarInfo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBB_OverallBackgroundCarInfo.SelectedIndexChanged
        TestOverallColors()
    End Sub
    Private Sub CBB_OverallSettingsLabelForeColor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBB_OverallSettingsLabelForeColor.SelectedIndexChanged
        TestOverallLabelSettings()
    End Sub

    Private Sub CBB_OverallSettingsFontFamily_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBB_OverallSettingsFontFamily.SelectedIndexChanged
        TestOverallLabelSettings()
    End Sub

    Private Sub TestOverallColors()
        If CBB_OverallSettingsFormBackground.SelectedIndex > -1 Then
            Try
                selectedBackgroundColorOverall = Color.FromKnownColor(DirectCast([Enum].Parse(GetType(KnownColor), CBB_OverallSettingsFormBackground.SelectedItem.ToString()), KnownColor))
                PB_BackgroundColorFormOverall.BackColor = selectedBackgroundColorOverall
            Catch ex As Exception

            End Try
        End If

        If CBB_OverallBackgroundCarInfo.SelectedIndex > -1 Then
            Try
                selectedCarInfoColorOverall = Color.FromKnownColor(DirectCast([Enum].Parse(GetType(KnownColor), CBB_OverallBackgroundCarInfo.SelectedItem.ToString()), KnownColor))
                PB_BackgroundColorCarInfoOverall.BackColor = selectedCarInfoColorOverall
            Catch ex As Exception

            End Try
        End If




    End Sub

    Private Sub TestOverallLabelSettings()
        If CBB_OverallSettingsLabelForeColor.SelectedIndex > -1 Then
            Try
                selectedForeColorOverall = Color.FromKnownColor(DirectCast([Enum].Parse(GetType(KnownColor), CBB_OverallSettingsLabelForeColor.SelectedItem.ToString()), KnownColor))
                LBL_LabelTest.ForeColor = selectedForeColorOverall
            Catch ex As Exception

            End Try
        End If



        If CBB_OverallSettingsFontFamily.SelectedIndex > -1 Then
            Try
                selectedFontFamilyOverall = CBB_OverallSettingsFontFamily.SelectedItem.ToString
                Dim selectedFont As New Font(selectedFontFamilyOverall, 10)
                LBL_LabelTest.Font = selectedFont

                'Label mittig platzieren lassen
                Dim newX As Integer = CInt((GB_OverallSettingsLabel.Width - LBL_LabelTest.Width) / 2)
                Dim newY As Integer = LBL_LabelTest.Location.Y
                LBL_LabelTest.Location = New Point(newX, newY)
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub BTN_SaveOverallSettings_Click(sender As Object, e As EventArgs) Handles BTN_SaveOverallSettings.Click
        Try
            SaveOverallSettings(selectedFontFamilyOverall, selectedForeColorOverall.Name, selectedBackgroundColorOverall.Name, selectedCarInfoColorOverall.Name)
            MsgBox("Einstellung erfolgreich gespeichert" & vbNewLine & "Bitte starten Sie die Anwendung neu, um die Einstellungen zu visualiseren", MsgBoxStyle.Information)
        Catch ex As Exception
            MsgBox("Fehler beim Speichern der Einstellungen " & ex.Message)
            SavetoLogFile(ex.Message, "SaveOverallsettings")
        End Try

    End Sub

    Private Sub Overall_Click(sender As Object, e As EventArgs) Handles Overall.Click

    End Sub





#End Region








End Class