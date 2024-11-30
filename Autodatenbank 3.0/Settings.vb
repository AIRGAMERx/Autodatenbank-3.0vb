Imports System.IO
Imports System.Security.Cryptography
Imports System.Text
Imports System.Xml.Serialization
Imports Newtonsoft.Json

Module Settings
    ReadOnly ConnectionSettingsFilePath As String = Application.StartupPath & "\ConnectionSettings.xml"
    ReadOnly DGVSettingsFilePath As String = Application.StartupPath & "\Settings\" & My.Settings.UID & "\DGVSettings.json"
    ReadOnly OverallSettingsFilePath As String = Application.StartupPath & "\Settings\" & My.Settings.UID & "\OverallSettings.json"
    ReadOnly CompDataFilePath As String = Application.StartupPath & "\Settings\" & My.Settings.UID & "\CompData.json"



#Region "ConnectionSettings"


    Public Function FindConnectionSettings() As Boolean
        If File.Exists(ConnectionSettingsFilePath) Then
            Return True
        Else
            Return False
        End If
    End Function


    Public Function CreateSettings(Connectionstring As String, FTPServer As String, FTPUsername As String, FTPPassword As String, SFTP As Boolean, KeyFile As String, KeyFilePass As String, SFTPServerUri As String, SFTPUsername As String, key As String) As Boolean



        Try




            Dim Data As New UserConnectionData With {
                .Connectionstring = Connectionstring,
                .FTPServerUri = FTPServer,
                .FTPUsername = FTPUsername,
                .FTPPassword = FTPPassword,
                .SFTP = SFTP,
                .KeyFile = KeyFile,
                .KeyFilePass = KeyFilePass,
                .SFTPServerUri = SFTPServerUri,
                .SFTPUsername = SFTPUsername
            }


            Data.Connectionstring = EncryptString(If(Not String.IsNullOrEmpty(Connectionstring), Connectionstring, "Connectionstring"), key)
            Data.FTPServerUri = EncryptString(If(Not String.IsNullOrEmpty(FTPServer), FTPServer, "ftp://examle.com"), key)
            Data.FTPUsername = EncryptString(If(Not String.IsNullOrEmpty(FTPUsername), FTPUsername, "FtpUser"), key)
            Data.FTPPassword = EncryptString(If(Not String.IsNullOrEmpty(FTPPassword), FTPPassword, "Ftppassword"), key)
            Data.SFTP = SFTP
            Data.KeyFile = EncryptString(If(Not String.IsNullOrEmpty(KeyFile), KeyFile, "KeyFile"), key)
            Data.KeyFilePass = EncryptString(If(Not String.IsNullOrEmpty(KeyFilePass), KeyFilePass, "KeyFilePass"), key)
            Data.SFTPServerUri = EncryptString(If(Not String.IsNullOrEmpty(SFTPServerUri), SFTPServerUri, "SFTPServeruri"), key)
            Data.SFTPUsername = EncryptString(If(Not String.IsNullOrEmpty(SFTPUsername), SFTPUsername, "SFTPUsername"), key)

            Dim serializer As New XmlSerializer(GetType(UserConnectionData))
            Using writer As New StreamWriter(ConnectionSettingsFilePath)
                serializer.Serialize(writer, Data)
            End Using
            Return True
        Catch ex As Exception

            Return False
        End Try


    End Function

    Public Sub LoadConnectionSettings()
        Try
            Dim serializer As New XmlSerializer(GetType(UserConnectionData))
            Dim data As UserConnectionData
            Dim key As String = My.Settings.Regkey

            Using reader As New StreamReader(ConnectionSettingsFilePath)
                data = DirectCast(serializer.Deserialize(reader), UserConnectionData)
            End Using

            ' Entschlüsseln der Verbindungsdaten mit separater Fehlerbehandlung
            Try
                My.Settings.connectionstring = DecryptString(data.Connectionstring, key)
            Catch ex As Exception
                MsgBox("Fehler beim Entschlüsseln von Connectionstring: " & ex.Message)
            End Try

            Try
                My.Settings.Ftpserveruri = DecryptString(data.FTPServerUri, key)
            Catch ex As Exception
                MsgBox("Fehler beim Entschlüsseln von FTPServerUri: " & ex.Message)
            End Try

            Try
                My.Settings.Ftpusername = DecryptString(data.FTPUsername, key)
            Catch ex As Exception
                MsgBox("Fehler beim Entschlüsseln von FTPUsername: " & ex.Message)
            End Try

            Try
                My.Settings.Ftppassword = DecryptString(data.FTPPassword, key)
            Catch ex As Exception
                MsgBox("Fehler beim Entschlüsseln von FTPPassword: " & ex.Message)
            End Try

            ' SFTP-Einstellungen ohne Entschlüsselung
            My.Settings.sftp = data.SFTP

            Try
                My.Settings.keyfile = DecryptString(data.KeyFile, key)
            Catch ex As Exception
                MsgBox("Fehler beim Entschlüsseln von KeyFile: " & ex.Message)
            End Try

            Try
                My.Settings.keyfilepass = DecryptString(data.KeyFilePass, key)
            Catch ex As Exception
                MsgBox("Fehler beim Entschlüsseln von KeyFilePass: " & ex.Message)
            End Try

            Try
                My.Settings.SFTPServerUri = DecryptString(data.SFTPServerUri, key)
            Catch ex As Exception
                MsgBox("Fehler beim Entschlüsseln von SFTPServerUri: " & ex.Message)
            End Try

            Try
                My.Settings.SFTPUsername = DecryptString(data.SFTPUsername, key)
            Catch ex As Exception
                MsgBox("Fehler beim Entschlüsseln von SFTPUsername: " & ex.Message)
            End Try

            My.Settings.Save()
        Catch ex As Exception
            MsgBox("Allgemeiner Fehler beim Laden der Verbindungsdaten: " & ex.Message)
        End Try
    End Sub

    Public Sub UpdateSettings(ByVal key As String)
        Try
            Dim serializer As New XmlSerializer(GetType(UserConnectionData))
            Dim data As New UserConnectionData()

            ' Überprüfe und setze den Standardwert für ConnectionString
            If String.IsNullOrEmpty(My.Settings.connectionstring) Then
                My.Settings.connectionstring = "server=" + "test.com" + ";user=" + "Default" + ";database=" + "Default" + ";password=" + "Default" + ";"
            End If
            data.Connectionstring = My.Settings.connectionstring

            ' Überprüfe und setze den Standardwert für FTPServerUri
            If String.IsNullOrEmpty(My.Settings.Ftpserveruri) Then
                My.Settings.Ftpserveruri = "ftp://example.com"
            End If
            data.FTPServerUri = My.Settings.Ftpserveruri

            ' Überprüfe und setze den Standardwert für FTPUsername
            If String.IsNullOrEmpty(My.Settings.Ftpusername) Then
                My.Settings.Ftpusername = "Default"
            End If
            data.FTPUsername = My.Settings.Ftpusername

            ' Überprüfe und setze den Standardwert für FTPPassword
            If String.IsNullOrEmpty(My.Settings.Ftppassword) Then
                My.Settings.Ftppassword = "Default"
            End If
            data.FTPPassword = My.Settings.Ftppassword


            data.SFTP = My.Settings.sftp

            If String.IsNullOrEmpty(My.Settings.keyfile) Then
                My.Settings.keyfile = "Default"
            End If
            data.KeyFile = My.Settings.keyfile

            If String.IsNullOrEmpty(My.Settings.keyfilepass) Then
                My.Settings.keyfilepass = "Default"
            End If
            data.KeyFilePass = My.Settings.keyfilepass

            If String.IsNullOrEmpty(My.Settings.SFTPServerUri) Then
                My.Settings.SFTPServerUri = "Default"
            End If
            data.SFTPServerUri = My.Settings.SFTPServerUri

            If String.IsNullOrEmpty(My.Settings.SFTPUsername) Then
                My.Settings.SFTPUsername = "Default"
            End If
            data.SFTPUsername = My.Settings.SFTPUsername




            ' Verschlüssele die Daten
            data.Connectionstring = EncryptString(data.Connectionstring, key)
            data.FTPServerUri = EncryptString(data.FTPServerUri, key)
            data.FTPUsername = EncryptString(data.FTPUsername, key)
            data.FTPPassword = EncryptString(data.FTPPassword, key)
            data.SFTP = data.SFTP
            data.KeyFile = EncryptString(data.KeyFile, key)
            data.KeyFilePass = EncryptString(data.KeyFilePass, key)
            data.SFTPServerUri = EncryptString(data.SFTPServerUri, key)
            data.SFTPUsername = EncryptString(data.SFTPUsername, key)

            ' Schreibe die aktualisierten, verschlüsselten Daten zurück in die XML-Datei
            Using writer As New StreamWriter(ConnectionSettingsFilePath)
                serializer.Serialize(writer, data)
            End Using
        Catch ex As Exception
            MsgBox("Fehler beim Aktualisieren der Verbindungseinstellungen: " & ex.Message)
        End Try
    End Sub



    Public Function EncryptString(ByVal plainText As String, ByVal key As String) As String
        Dim aesAlg As New AesCryptoServiceProvider With {
        .Key = HexStringToByteArray(key), ' Verwende HexStringToByteArray
        .IV = New Byte(15) {} ' Initialisierungsvektor bleibt leer
    }

        Dim encryptor As ICryptoTransform = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV)

        Using msEncrypt As New MemoryStream()
            Using csEncrypt As New CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write)
                Using swEncrypt As New StreamWriter(csEncrypt)
                    swEncrypt.Write(plainText)
                End Using
                Dim encryptedBytes() As Byte = msEncrypt.ToArray()
                Return Convert.ToBase64String(encryptedBytes)
            End Using
        End Using
    End Function

    Public Function DecryptString(ByVal cipherText As String, ByVal key As String) As String
        If Not IsBase64String(cipherText) Then
            Throw New FormatException("Ungültiger Base64-String")
        End If

        Dim aesAlg As New AesCryptoServiceProvider With {
        .Key = HexStringToByteArray(key), ' Verwende HexStringToByteArray
        .IV = New Byte(15) {}
    }

        Dim decryptor As ICryptoTransform = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV)

        Using msDecrypt As New MemoryStream(Convert.FromBase64String(cipherText))
            Using csDecrypt As New CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read)
                Using srDecrypt As New StreamReader(csDecrypt)
                    Return srDecrypt.ReadToEnd()
                End Using
            End Using
        End Using
    End Function

    Public Function HexStringToByteArray(hex As String) As Byte()
        Dim bytes(hex.Length \ 2 - 1) As Byte
        For i As Integer = 0 To hex.Length - 1 Step 2
            bytes(i \ 2) = Convert.ToByte(hex.Substring(i, 2), 16)
        Next
        Return bytes
    End Function
    Public Function IsBase64String(s As String) As Boolean
        Try
            Dim data As Byte() = Convert.FromBase64String(s)
            Return True
        Catch ex As FormatException
            Return False
        End Try
    End Function
#End Region

#Region "Settings"
#Region "DGV Settings"
    Public Sub SaveDGVSettings(Fontfamily As String, FontSize As Single, ForeColor As String, BackgroundColor As String, CellsColor As String, ShownData As String)
        ' Erstellen einer neuen Instanz der DGVSettings-Klasse und Laden der Daten in den Konstruktor
        Dim settings As New DGVSettings With {
        .FontFamily = Fontfamily,
        .FontSize = FontSize,
        .ForeColor = ForeColor,
        .BackgroundColor = BackgroundColor,
        .CellsColor = CellsColor,
        .DGVShowDataCode = ShownData
    }

        ' Serialisieren der Einstellungen in eine JSON-String
        Dim json As String = JsonConvert.SerializeObject(settings, Formatting.Indented)

        'Falls datei noch nicht existiert neu erstellen
        If Not File.Exists(DGVSettingsFilePath) Then
            ' Holen Sie das Verzeichnis aus dem Pfad
            Dim directoryPath As String = Path.GetDirectoryName(DGVSettingsFilePath)

            ' Überprüfen, ob das Verzeichnis existiert
            If Not Directory.Exists(directoryPath) Then
                ' Verzeichnis erstellen
                Directory.CreateDirectory(directoryPath)
            End If

            ' Datei erstellen
            File.Create(DGVSettingsFilePath).Dispose() ' Verwenden Sie Dispose(), um den Datei-Stream zu schließen
        End If

        ' Speichern des JSON-Strings in einer Datei
        File.WriteAllText(DGVSettingsFilePath, json)
    End Sub
    Public Sub LoadDGVSettings()



        ' Überprüfen, ob die Datei existiert
        If Not File.Exists(DGVSettingsFilePath) Or My.Settings.DefaultSettings = True Then
            ' Laden der Standard-Microsoft-Einstellungen
            SetDefaultDGVVisualSettings()
            Return
        End If

        ' JSON aus Datei lesen
        Dim json As String = File.ReadAllText(DGVSettingsFilePath)

        ' JSON deserialisieren
        Dim settings As DGVSettings = JsonConvert.DeserializeObject(Of DGVSettings)(json)

        If settings IsNot Nothing Then
            Try
                'Schriftart und Schriftgröße anwenden
                Dim selectedFont As New Font(settings.FontFamily, settings.FontSize)
                Autodatenbank.dgv.Font = selectedFont
                Autodatenbank.dgv2.Font = selectedFont
                ViewSettings.cbb_FontFamilyDGV.SelectedItem = settings.FontFamily
                ViewSettings.cbb_FontSizeDGV.SelectedItem = settings.FontSize.ToString


                ' Vordergrundfarbe anwenden
                Dim selectedForeColor As Color = Color.FromName(settings.ForeColor)
                Autodatenbank.dgv.ForeColor = selectedForeColor
                Autodatenbank.dgv2.ForeColor = selectedForeColor
                ViewSettings.cbb_ForeColorDGV.SelectedItem = selectedForeColor.Name



                ' Hintergrundfarbe anwenden
                Dim selectedBackgroundColor As Color = Color.FromName(settings.BackgroundColor)
                Autodatenbank.dgv.BackgroundColor = selectedBackgroundColor
                Autodatenbank.dgv2.BackgroundColor = selectedBackgroundColor
                ViewSettings.CBB_DGVSettingsBackgroundcolor.SelectedItem = selectedBackgroundColor

                ' Zellenfarbe anwenden
                Dim selectedCellsColor As Color = Color.FromName(settings.CellsColor)
                Autodatenbank.dgv.DefaultCellStyle.BackColor = selectedCellsColor
                Autodatenbank.dgv2.DefaultCellStyle.BackColor = selectedCellsColor
                ViewSettings.CBB_DGVSettingsCellsColor.SelectedItem = selectedCellsColor

                ' Optional: Zellenfarben für jede Zelle anwenden
                For Each row As DataGridViewRow In Autodatenbank.dgv.Rows
                    For Each cell As DataGridViewCell In row.Cells
                        cell.Style.BackColor = selectedCellsColor
                    Next
                Next

                For Each row As DataGridViewRow In Autodatenbank.dgv2.Rows
                    For Each cell As DataGridViewCell In row.Cells
                        cell.Style.BackColor = selectedCellsColor
                    Next
                Next
            Catch ex As Exception
                SetDefaultDGVDataSettings()
            End Try
            If settings.DGVShowDataCode Is Nothing Then
                SetDefaultDGVDataSettings()
            End If


            If settings.DGVShowDataCode IsNot Nothing Then
                SetSavedDGVDataSettings(settings.DGVShowDataCode)
            End If

        End If
    End Sub

    Private Sub SetDefaultDGVVisualSettings()
        ' Standard-Microsoft-Einstellungen laden

        ' Standard-Schriftart und Schriftgröße
        Dim defaultFont As New Font("Microsoft Sans Serif", 8.25F)
        Autodatenbank.dgv.Font = defaultFont
        Autodatenbank.dgv2.Font = defaultFont

        ' Standard-Vordergrundfarbe
        Autodatenbank.dgv.ForeColor = SystemColors.ControlText
        Autodatenbank.dgv2.ForeColor = SystemColors.ControlText

        ' Standard-Hintergrundfarbe
        Autodatenbank.dgv.BackgroundColor = SystemColors.Window
        Autodatenbank.dgv2.BackgroundColor = SystemColors.Window

        ' Standard-Zellenfarbe
        Autodatenbank.dgv.DefaultCellStyle.BackColor = SystemColors.Window
        Autodatenbank.dgv2.DefaultCellStyle.BackColor = SystemColors.Window


    End Sub

    Private Sub SetDefaultDGVDataSettings()
        ' Alle Spalten durchlaufen
        For Each col As DataGridViewColumn In Autodatenbank.dgv.Columns
            ' Überprüfen, ob der Spaltenname "ID" oder "Tabellenname" ist
            If col.Name = "ID" OrElse col.Name = "Tabellenname" Then
                ' Diese Spalten ausblenden
                col.Visible = False
            Else
                ' Alle anderen Spalten sichtbar machen
                col.Visible = True
            End If
        Next

        Dim checkBoxNames As String() = {"CB_DGVSettingsDataLP", "CB_DGVSettingsDataDC", "CB_DGVSettingsDataMA", "CB_DGVSettingsDataDate", "CB_DGVSettingsDataPrice", "CB_DGVSettingsDataComm", "CB_DGVSettingsDataArt", "CB_DGVSettingsDataEditor"}

        ' Schleife durch die Zeichen im Schlüssel und die entsprechenden CheckBoxen
        For i As Integer = 0 To 7
            ' Finden Sie die CheckBox mit dem entsprechenden Namen
            Dim checkBox As CheckBox = CType(ViewSettings.GB_DGVSettingsData.Controls(checkBoxNames(i)), CheckBox)

            checkBox.Checked = True
        Next


    End Sub

    Public Sub SetSavedDGVDataSettings(key As String)
        Try
            ' Überprüfen, ob der Schlüssel die richtige Länge hat
            If key.Length <> 8 Then
                SetDefaultDGVDataSettings()
            Else
                ' Spaltennamen, die den Schlüsselzeichen entsprechen
                Dim columnNames As String() = {"ID_Kennzeichen", "Bezeichnung", "Kilometer", "Datum", "Preis in €", "Kommentar", "Art", "Bearbeiter"}

                ' Überprüfen, ob die DataGridView initialisiert ist
                If Autodatenbank.dgv Is Nothing OrElse Autodatenbank.dgv.Columns Is Nothing Then
                    Throw New InvalidOperationException("Die DataGridView oder ihre Columns-Eigenschaft ist nicht initialisiert.")
                End If

                ' Schleife: Schlüsselzeichen und Spalten anzeigen/verstecken
                For i As Integer = 0 To key.Length - 1
                    If Autodatenbank.dgv.Columns.Contains(columnNames(i)) Then
                        Autodatenbank.dgv.Columns(columnNames(i)).Visible = (key(i) = "1")
                    Else
                        Throw New ArgumentException($"Die Spalte '{columnNames(i)}' existiert nicht.")
                    End If
                Next

                ' Sichtbare Breite berechnen
                Dim vis As Integer = 0
                For Each col As DataGridViewColumn In Autodatenbank.dgv.Columns
                    If col.Visible Then vis += col.Width
                Next
                Autodatenbank.dgv.Columns("Kommentar").Width = Autodatenbank.dgv.Width - vis + 25

                ' CheckBox-Namen, die den Schlüsselzeichen entsprechen
                Dim checkBoxNames As String() = {"CB_DGVSettingsDataLP", "CB_DGVSettingsDataDC", "CB_DGVSettingsDataMA", "CB_DGVSettingsDataDate", "CB_DGVSettingsDataPrice", "CB_DGVSettingsDataComm", "CB_DGVSettingsDataArt", "CB_DGVSettingsDataEditor"}

                ' Schleife: Schlüsselzeichen und Checkbox-Zustand
                For i As Integer = 0 To key.Length - 1
                    Dim control = ViewSettings.GB_DGVSettingsData.Controls(checkBoxNames(i))
                    If control Is Nothing Then
                        Throw New ArgumentException($"Die Checkbox '{checkBoxNames(i)}' existiert nicht.")
                    End If
                    Dim checkBox As CheckBox = CType(control, CheckBox)
                    checkBox.Checked = (key(i) = "1")
                Next
            End If
        Catch ex As Exception
            ' Fehler protokollieren
            MessageBox.Show($"Ein Fehler ist aufgetreten: {ex.Message}{Environment.NewLine}{ex.StackTrace}")
        End Try
    End Sub

#End Region
#Region "Overall Settings"
    Public Sub SaveOverallSettings(LabelFontFamily As String, LabelForeColor As String, BackgroundColor As String, CarInfoBackColor As String)

        ' Erstellen einer neuen Instanz der DGVSettings-Klasse und Laden der Daten in den Konstruktor
        Dim settings As New OverallSettings With {
        .LabelFontFamily = LabelFontFamily,
        .LabelForeColor = LabelForeColor,
        .BackgroundColor = BackgroundColor,
        .CarInfoBackColor = CarInfoBackColor
    }

        ' Serialisieren der Einstellungen in eine JSON-String
        Dim json As String = JsonConvert.SerializeObject(settings, Formatting.Indented)

        'Falls datei noch nicht existiert neu erstellen
        If Not File.Exists(OverallSettingsFilePath) Then
            ' Holen Sie das Verzeichnis aus dem Pfad
            Dim directoryPath As String = Path.GetDirectoryName(OverallSettingsFilePath)

            ' Überprüfen, ob das Verzeichnis existiert
            If Not Directory.Exists(directoryPath) Then
                ' Verzeichnis erstellen
                Directory.CreateDirectory(directoryPath)
            End If

            ' Datei erstellen
            File.Create(OverallSettingsFilePath).Dispose() ' Verwenden Sie Dispose(), um den Datei-Stream zu schließen
        End If

        ' Speichern des JSON-Strings in einer Datei
        File.WriteAllText(OverallSettingsFilePath, json)
    End Sub


    Public Sub LoadOverallSettings()
        ' Überprüfen, ob die Datei existiert
        If Not File.Exists(OverallSettingsFilePath) Or My.Settings.DefaultSettings = True Then
            ' Laden der Standard-Microsoft-Einstellungen
            SetDefaultDGVVisualSettings()
            Return
        End If

        ' JSON aus Datei lesen
        Dim json As String = File.ReadAllText(OverallSettingsFilePath)

        ' JSON deserialisieren
        Dim settings As OverallSettings = JsonConvert.DeserializeObject(Of OverallSettings)(json)

        If settings IsNot Nothing Then
            For Each formName In FormManager.AllFormNames
                ' Formular finden, das mit dem Namen übereinstimmt
                Dim frm As Form = Application.OpenForms.OfType(Of Form)().FirstOrDefault(Function(f) f.Name = formName)

                ' Debugging: Überprüfen, ob das Formular gefunden wurde
                If frm Is Nothing Then
                    Console.WriteLine($"Formular mit dem Namen {formName} wurde nicht gefunden.")
                Else
                    Console.WriteLine($"Formular mit dem Namen {formName} wird aktualisiert.")
                    ApplySettingsToForm(frm, settings)
                End If
            Next

            ' Gespeicherte Werte in die Comboboxen setzen
            If settings.BackgroundColor IsNot Nothing Then
                ' Setzen Sie den ausgewählten Hintergrundfarben-Namen als String
                ViewSettings.CBB_OverallSettingsFormBackground.SelectedItem = settings.BackgroundColor
            End If

            If settings.CarInfoBackColor IsNot Nothing Then
                ' Setzen Sie den ausgewählten AutoInfo Hintergrundfarben-Namen als String
                ViewSettings.CBB_OverallBackgroundCarInfo.SelectedItem = settings.CarInfoBackColor
            End If

            If settings.LabelForeColor IsNot Nothing Then
                ' Setzen Sie den ausgewählten Schriftfarben-Namen als String
                ViewSettings.CBB_OverallSettingsLabelForeColor.SelectedItem = settings.LabelForeColor
            End If

            If settings.LabelFontFamily IsNot Nothing Then
                ' Setzen Sie die Schriftart-Auswahl
                ViewSettings.CBB_OverallSettingsFontFamily.SelectedItem = settings.LabelFontFamily
            End If

            If settings.CarInfoBackColor IsNot Nothing Then
                Autodatenbank.FLP_Main.BackColor = Color.FromKnownColor(DirectCast([Enum].Parse(GetType(KnownColor), settings.CarInfoBackColor), KnownColor))
            End If

        End If
    End Sub

    Public Sub SetDefaultOverallVisualSettings()

        Autodatenbank.BackColor = Color.FromKnownColor(DirectCast([Enum].Parse(GetType(KnownColor), "ControlLight"), KnownColor))
        Autodatenbank.FLP_Main.BackColor = Color.FromKnownColor(DirectCast([Enum].Parse(GetType(KnownColor), "White"), KnownColor))

        For Each formName In FormManager.AllFormNames
            ' Formular finden, das mit dem Namen übereinstimmt
            Dim frm As Form = Application.OpenForms.OfType(Of Form)().FirstOrDefault(Function(f) f.Name = formName)

            ' Debugging: Überprüfen, ob das Formular gefunden wurde
            If frm Is Nothing Then
                Console.WriteLine($"Formular mit dem Namen {formName} wurde nicht gefunden.")
            Else
                Console.WriteLine($"Formular mit dem Namen {formName} wird aktualisiert.")
                ApplyDefaultSettingsToForm(frm)
            End If
        Next

        ViewSettings.CBB_OverallSettingsFormBackground.SelectedItem = "ControlLight"
        ViewSettings.CBB_OverallBackgroundCarInfo.SelectedItem = "White"


        ViewSettings.CBB_OverallSettingsFontFamily.Text = "Microsoft Sans Serif"
        ViewSettings.CBB_OverallSettingsLabelForeColor.Text = "ControlText"

    End Sub

    Public Sub ApplyDefaultSettingsToForm(frm As Form)


        Dim labelFont As New Font("Microsoft Sans Serif", 8.25F)
        For Each ctrl As Control In frm.Controls
            ApplyDefaultSettingsToControl(ctrl, labelFont)
        Next

    End Sub

    Private Sub ApplyDefaultSettingsToControl(ctrl As Control, font As Font)
        If TypeOf ctrl Is Label Then
            DirectCast(ctrl, Label).Font = font
            DirectCast(ctrl, Label).ForeColor = Color.FromName("ControlText")
        End If

        ' Wenn das Steuerelement Container-Steuerelemente hat, auch deren Kinder durchlaufen
        For Each childCtrl As Control In ctrl.Controls
            ApplyDefaultSettingsToControl(childCtrl, font)
        Next
    End Sub




    Public Sub ApplySettingsToForm(frm As Form, settings As OverallSettings)
        ' Schriftart für Labels setzen
        If Not String.IsNullOrEmpty(settings.LabelFontFamily) Then
            Dim labelFont As New Font(settings.LabelFontFamily, 10) ' Setzen Sie die Schriftgröße nach Bedarf
            For Each ctrl As Control In frm.Controls
                ApplySettingsToControl(ctrl, labelFont, settings)
            Next
        End If

        ' Hintergrundfarbe des Formulars setzen
        If Not String.IsNullOrEmpty(settings.BackgroundColor) Then
            frm.BackColor = Color.FromName(settings.BackgroundColor)
        End If
    End Sub

    ' Methode zum Anwenden der Einstellungen auf ein Steuerelement und seine Untersteuerelemente
    Public Sub ApplySettingsToControl(ctrl As Control, font As Font, settings As OverallSettings)
        If TypeOf ctrl Is Label Then
            DirectCast(ctrl, Label).Font = font
            DirectCast(ctrl, Label).ForeColor = Color.FromName(settings.LabelForeColor)
        End If

        ' Wenn das Steuerelement Container-Steuerelemente hat, auch deren Kinder durchlaufen
        For Each childCtrl As Control In ctrl.Controls
            ApplySettingsToControl(childCtrl, font, settings)
        Next
    End Sub





#End Region
#Region "CompanyData Settings"

    Public Sub SaveCompanyData(Name As String, Street As String, City As String)
        Dim ComData As New CompanyData With {
            .Name = Name,
            .Street = Street,
            .City = City}



        ' Serialisieren der Einstellungen in eine JSON-String
        Dim json As String = JsonConvert.SerializeObject(ComData, Formatting.Indented)

        'Falls datei noch nicht existiert neu erstellen
        If Not File.Exists(CompDataFilePath) Then
            ' Holen Sie das Verzeichnis aus dem Pfad
            Dim directoryPath As String = Path.GetDirectoryName(CompDataFilePath)

            ' Überprüfen, ob das Verzeichnis existiert
            If Not Directory.Exists(directoryPath) Then
                ' Verzeichnis erstellen
                Directory.CreateDirectory(directoryPath)
            End If

            ' Datei erstellen
            File.Create(CompDataFilePath).Dispose() ' Verwenden Sie Dispose(), um den Datei-Stream zu schließen
        End If

        ' Speichern des JSON-Strings in einer Datei
        File.WriteAllText(CompDataFilePath, json)

    End Sub

    Public Sub LoadCompanyData()
        If File.Exists(CompDataFilePath) Then



            Dim json As String = File.ReadAllText(CompDataFilePath)

            ' JSON deserialisieren
            Dim settings As CompanyData = JsonConvert.DeserializeObject(Of CompanyData)(json)

            If settings IsNot Nothing Then


                Try
                    If settings.Name IsNot Nothing Then
                        ReportSettings.TXB_CompName.Text = settings.Name
                    End If

                    If settings.Street IsNot Nothing Then
                        ReportSettings.TXB_CompStreet.Text = settings.Street

                    End If

                    If settings.City IsNot Nothing Then
                        ReportSettings.TXB_CompCity.Text = settings.City
                    End If
                Catch ex As Exception

                End Try

                If settings.Name IsNot Nothing Then
                    My.Settings.CompName = settings.Name
                End If

                If settings.Street IsNot Nothing Then
                    My.Settings.CompStreet = settings.Street
                End If

                If settings.City IsNot Nothing Then
                    My.Settings.CompCity = settings.City
                End If


                My.Settings.Save()
            End If

        End If
    End Sub












#End Region

#End Region

















End Module

Public Class UserConnectionData
    Public Property Connectionstring As String
    Public Property FTPServerUri As String
    Public Property FTPUsername As String
    Public Property FTPPassword As String
    Public Property SFTP As Boolean
    Public Property KeyFile As String
    Public Property KeyFilePass As String
    Public Property SFTPServerUri As String
    Public Property SFTPUsername As String

End Class

Public Class DGVSettings
    Public Property FontFamily As String
    Public Property FontSize As Single
    Public Property ForeColor As String
    Public Property BackgroundColor As String
    Public Property CellsColor As String
    Public Property DGVShowDataCode As String

End Class
Public Class SFTPSettings


End Class


Public Class OverallSettings
    Public Property LabelFontFamily As String
    Public Property LabelForeColor As String
    Public Property BackgroundColor As String
    Public Property CarInfoBackColor As String


End Class




Public Class CompanyData
    Public Property Name As String
    Public Property Street As String
    Public Property City As String


End Class

