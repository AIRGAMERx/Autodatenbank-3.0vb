Imports System.IO
Imports System.Net
Imports MySqlConnector
Imports Renci.SshNet

Public Class FirstRun
    Dim ConnectionString As String
    Dim ftpconected As Boolean = False

    Private Sub FirstRun_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            File.Delete(Application.StartupPath & "\ConnectionSettings.xml")
        Catch ex As Exception

        End Try
        If FindConnectionSettings() = False Then
            LBL_MySqlConnection.Text = "Nicht Konfiguriert"
            LBL_FTPConnection.Text = "Nicht Konfiguriert"
        Else
            LBL_MySqlConnection.Text = "Nicht Konfiguriert"
            LBL_FTPConnection.Text = "Nicht Konfiguriert"
        End If

        'Panel einstellungen
        PNL_2.Visible = False
        PNL_1.Visible = True
        PNL_1.Location = New Point(12, 63)
        PNL_1.Size = New Size(624, 547)

    End Sub

    Private Sub BTN_GetStarted_Click(sender As Object, e As EventArgs) Handles BTN_GetStarted.Click
        PNL_1.Visible = False
        PNL_2.Visible = True
        PNL_2.Location = New Point(12, 63)
        PNL_2.Size = New Size(624, 782)

    End Sub

    Private Sub BTN_TryMqSqlConnectin_Click(sender As Object, e As EventArgs) Handles BTN_TryMqSqlConnectin.Click
        ConnectionString = "server=" + TXB_MySqlServer.Text + ";user=" + TXB_MySqlUsername.Text + ";database=" + TXB_MySqlDatabase.Text + ";password=" + TXB_MySqlPassword.Text + ";"

        Dim TestConnectionMysql As New MySqlConnection(ConnectionString)

        Try
            TestConnectionMysql.Open()
            LBL_MySqlConnection.Text = "Verbunden"
            LBL_MySqlConnection.ForeColor = Color.Green
            MsgBox("Erfolgreich mit Datenbank Verbunden", MsgBoxStyle.Information)
        Catch ex As Exception

            LBL_MySqlConnection.Text = "Nicht Verbunden"
            LBL_MySqlConnection.ForeColor = Color.Red
            MsgBox("Verbindung zur Datenbank konnte nicht hergestellt werden", MsgBoxStyle.Critical)
            SavetoLogFile(ex.Message, "TryMySqlConnectionFirstrun")
        End Try

        If LBL_MySqlConnection.Text = "Verbunden" AndAlso LBL_FTPConnection.Text = "Verbunden" Then
            BTN_SaveData.Enabled = True
        End If

    End Sub

    Private Sub BTN_TryFTPConnection_Click(sender As Object, e As EventArgs) Handles BTN_TryFTPConnection.Click

        Dim trimmedText As String = TXB_FTPServerUri.Text.Trim().ToLower()

        ' FTP: Wenn der Benutzer nicht "ftp://" eingegeben hat, wird es hinzugefügt
        If Not trimmedText.StartsWith("ftp://") And Not My.Settings.sftp Then
            TXB_FTPServerUri.Text = "ftp://" & TXB_FTPServerUri.Text
        End If

        Try
            If My.Settings.sftp Or CB_SFTP.Checked = True Then
                ' Teste SFTP-Verbindung
                TestSFTPConnection()
            Else
                ' Teste FTP-Verbindung
                TestFTPConnection()
            End If

            ' QR-Code generieren und Verbindung als erfolgreich markieren
            If ftpconected = True Then
                LBL_FTPConnection.Text = "Verbunden"
                LBL_FTPConnection.ForeColor = Color.Green
            Else
                LBL_FTPConnection.Text = "Nicht Verbunden"
                LBL_FTPConnection.ForeColor = Color.Red
            End If





        Catch ex As Exception
            LBL_FTPConnection.Text = "Nicht Verbunden"
            LBL_FTPConnection.ForeColor = Color.Red
            MsgBox("Verbindung zum Server konnte nicht hergestellt werden", MsgBoxStyle.Critical)
            SavetoLogFile(ex.Message, "TryFTPConnectionServerConnection")
        End Try

        ' Aktiviert den Speichern-Button nur, wenn beide Verbindungen erfolgreich sind
        If LBL_MySqlConnection.Text = "Verbunden" AndAlso LBL_FTPConnection.Text = "Verbunden" Then
            BTN_SaveData.Enabled = True
        End If


    End Sub

    Private Sub BTN_TrySFTPConnection_Click(sender As Object, e As EventArgs) Handles BTN_TrySFTPConnection.Click

        Dim trimmedText As String = TXB_FTPServerUri.Text.Trim().ToLower()

        ' FTP: Wenn der Benutzer nicht "ftp://" eingegeben hat, wird es hinzugefügt
        If Not trimmedText.StartsWith("ftp://") And Not My.Settings.sftp Then
            TXB_FTPServerUri.Text = "ftp://" & TXB_FTPServerUri.Text
        End If

        Try
            If My.Settings.sftp Or CB_SFTP.Checked = True Then
                ' Teste SFTP-Verbindung
                TestSFTPConnection()
            Else
                ' Teste FTP-Verbindung
                TestFTPConnection()
            End If

            ' QR-Code generieren und Verbindung als erfolgreich markieren
            If ftpconected = True Then
                LBL_FTPConnection.Text = "Verbunden"
                LBL_FTPConnection.ForeColor = Color.Green
            Else
                LBL_FTPConnection.Text = "Nicht Verbunden"
                LBL_FTPConnection.ForeColor = Color.Red
            End If





        Catch ex As Exception
            LBL_FTPConnection.Text = "Nicht Verbunden"
            LBL_FTPConnection.ForeColor = Color.Red
            MsgBox("Verbindung zum Server konnte nicht hergestellt werden", MsgBoxStyle.Critical)
            SavetoLogFile(ex.Message, "TryFTPConnectionServerConnection")
        End Try

        ' Aktiviert den Speichern-Button nur, wenn beide Verbindungen erfolgreich sind
        If LBL_MySqlConnection.Text = "Verbunden" AndAlso LBL_FTPConnection.Text = "Verbunden" Then
            BTN_SaveData.Enabled = True
        End If
    End Sub
    Private Sub TestFTPConnection()
        Dim uri As New Uri(TXB_FTPServerUri.Text)
        Dim ftpRequest As FtpWebRequest = DirectCast(WebRequest.Create(uri), FtpWebRequest)
        ftpRequest.Credentials = New NetworkCredential(TXB_FTPUsername.Text, TXB_FTPPassword.Text)
        ftpRequest.Method = WebRequestMethods.Ftp.ListDirectory

        Using ftpResponse As FtpWebResponse = CType(ftpRequest.GetResponse(), FtpWebResponse)
            ftpconected = True
        End Using
    End Sub


    Private Sub TestSFTPConnection()

        Try
            ' Lade den privaten Schlüssel aus der .pem-Datei
            Dim privateKeyFilePath As String = My.Settings.keyfile ' Hier wird der Pfad zur PEM-Datei gespeichert
            Dim keyFile As PrivateKeyFile

            ' Prüfen, ob eine Passphrase vorhanden ist
            If String.IsNullOrEmpty(My.Settings.keyfilepass) Or My.Settings.keyfilepass = "Default" Then
                ' Ohne Passphrase laden
                keyFile = New PrivateKeyFile(privateKeyFilePath)
            Else
                ' Mit Passphrase laden
                keyFile = New PrivateKeyFile(privateKeyFilePath, My.Settings.keyfilepass)
            End If

            ' SSH-Authentifizierungsmethode mit dem privaten Schlüssel
            Dim keyFiles As New List(Of PrivateKeyFile) From {keyFile}
            Dim authMethods As New List(Of AuthenticationMethod) From {
            New PrivateKeyAuthenticationMethod(TXB_SFTPUsername.Text, keyFile)
        }

            ' Verbindung mit dem Server herstellen
            Dim connectionInfo As New ConnectionInfo(TXB_SFTPServerUri.Text, TXB_SFTPUsername.Text, authMethods.ToArray())
            Using client As New SftpClient(connectionInfo)
                client.Connect()

                If client.IsConnected Then
                    client.ChangeDirectory("Datenbank")

                    ' Die SFTP-Verbindung war erfolgreich
                    LBL_FTPConnection.Text = "Verbunden"
                    LBL_FTPConnection.ForeColor = Color.Green
                    ftpconected = True
                Else
                    Throw New Exception("SFTP-Verbindung konnte nicht hergestellt werden.")
                End If

                client.Disconnect()
            End Using

        Catch ex As Exception
            ftpconected = False
            LBL_FTPConnection.Text = "Nicht Verbunden"
            LBL_FTPConnection.ForeColor = Color.Red
            MsgBox("SFTP-Verbindung konnte nicht hergestellt werden: " & ex.Message, MsgBoxStyle.Critical)
            SavetoLogFile(ex.Message, "TestSFTPConnection")
        End Try
    End Sub



    Private Sub BTN_SaveData_Click(sender As Object, e As EventArgs) Handles BTN_SaveData.Click
        Select Case True
            'Prüfen ob Name und Email korrekt angegeben worden sind.
            Case TXB_LicenseName.Text.Length < 3
                MsgBox("Name muss mindestens 3 Zeichen enthalten")
            Case Not TXB_LicenseEmail.Text.Contains("@")
                MsgBox("Gültige Email adresse eingeben")

            Case Else
                'Wenn Lizenzschlüssel erstellt worden ist

                If CreateRegKey(TXB_Regkey.Text) = True Then
                    'Wenn SettingsXML erstellt worden ist

                    If CreateSettings(ConnectionString, TXB_FTPServerUri.Text, TXB_FTPUsername.Text, TXB_FTPPassword.Text, CB_SFTP.Checked, My.Settings.keyfile, My.Settings.keyfilepass, TXB_SFTPServerUri.Text, TXB_SFTPUsername.Text, TXB_Regkey.Text) = True Then
                        MsgBox("Daten wurden erfolgreich Regestriert und Lokal und verschlüsselt gespeichert", MsgBoxStyle.Information)
                        LoadConnectionSettings()

                        'Wenn Tabellen und Verzeichniss angelegt werden soll
                        If CheckBox1.Checked Then
                            CreateTables()
                        End If

                        Welcome.Show()
                        Me.Close()
                    Else
                        MsgBox("Fehler beim Speichern der Daten, wende dich an den Support von Autodatenbank")
                        Try
                            File.Delete(Application.StartupPath & "\ConnectionSettings.xml")
                        Catch ex As Exception

                        End Try

                    End If

                End If
        End Select
    End Sub

    Private Sub CreateTables()

        Dim connection As New MySqlConnection(My.Settings.connectionstring)

        Dim createAutoSql As String = "    CREATE TABLE IF Not EXISTS `Autos` (
    `Marke` varchar(50) DEFAULT '',
    `Model` varchar(50) DEFAULT '',
    `Kennzeichen` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci Not NULL DEFAULT '',
    `MKB` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT '',
    `Hubraum` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT '',
    `PS` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT '',
    `FIN` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT '',
    `Baujahr` varchar(50) DEFAULT '',
    `HSN` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT '',
    `Besitzer` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT '',
    `Gekauft` varchar(50) DEFAULT '',
    `Preis` varchar(50) DEFAULT '',
    `Info` mediumtext() DEFAULT '',
  PRIMARY KEY(`Kennzeichen`) USING BTREE )"

        Dim cmda As New MySqlCommand(createAutoSql, connection)

        Try
            connection.Open()
            cmda.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show("Fehler beim Erstellen der Tabelle: " & ex.Message)
            SavetoLogFile(ex.Message, "CreateTablesFirstRun")
        Finally
            connection.Close()
        End Try

        'Tabelle Reparatur erstellen

        Dim createReparaturSql As String = "CREATE TABLE IF NOT EXISTS `Reparatur` (
  `ID_Reparatur` int NOT NULL AUTO_INCREMENT,
  `ID_Kennzeichen` varchar(50) NOT NULL DEFAULT 'Kennzeichenlos',
  `Bezeichnung` varchar(50) DEFAULT NULL,
  `Kilometer` varchar(50) DEFAULT NULL,
  `Datum` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Preis` varchar(50) DEFAULT NULL,
  `Kommentar` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Art` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  PRIMARY KEY (`ID_Reparatur`) USING BTREE)"

        Dim cmdr As New MySqlCommand(createReparaturSql, connection)
        Try
            connection.Open()
            cmdr.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show("Fehler beim Erstellen der Tabelle: " & ex.Message)
            SavetoLogFile(ex.Message, "CreateTablesFirstRun")
        Finally
            connection.Close()
        End Try

        'Tabelle Service erstellen

        Dim createServiceSql As String = "CREATE TABLE IF NOT EXISTS `Service` (
  `ID_Service` int NOT NULL AUTO_INCREMENT,
  `ID_Kennzeichen` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL DEFAULT 'Kennzeichenlos',
  `Bezeichnung` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Kilometer` varchar(50) DEFAULT NULL,
  `Datum` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Preis` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Kommentar` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Art` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`ID_Service`)) "
        Dim cmds As New MySqlCommand(createServiceSql, connection)
        Try
            connection.Open()
            cmds.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show("Fehler beim Erstellen der Tabelle: " & ex.Message)
            SavetoLogFile(ex.Message, "CreateTablesFirstRun")
        Finally
            connection.Close()
        End Try

        'Tabelle Sonstiges erstellen

        Dim createSonstigeseSql As String = "CREATE TABLE IF NOT EXISTS `Sonstiges` (
  `ID_Sonstiges` int NOT NULL AUTO_INCREMENT,
  `ID_Kennzeichen` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL DEFAULT 'Kennzeichenlos',
  `Bezeichnung` varchar(50) DEFAULT NULL,
  `Kilometer` varchar(50) DEFAULT NULL,
  `Datum` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Preis` varchar(50) DEFAULT NULL,
  `Kommentar` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Art` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`ID_Sonstiges`))"

        Dim cmdso As New MySqlCommand(createSonstigeseSql, connection)

        Try
            connection.Open()
            cmdso.ExecuteNonQuery()
            FTPHelper.CreateDirectory(My.Settings.Ftpserveruri, My.Settings.Ftpusername, My.Settings.Ftppassword)
            UpdateSettings(My.Settings.Regkey)
            MsgBox("Tabellen und Verzeichniss erfolgreich erstellt.")
        Catch ex As Exception
            MessageBox.Show("Fehler beim Erstellen der Tabelle: " & ex.Message)
            SavetoLogFile(ex.Message, "CreateTablesFirstRun")
        Finally
            connection.Close()
        End Try

    End Sub

    Private Sub BTN_ImportSettings_Click(sender As Object, e As EventArgs) Handles BTN_ImportSettings.Click
        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.Filter = "Encrypted files (*.enc)|*.enc|All files (*.*)|*.*"
        openFileDialog.Title = "Verschlüsselte Konfigurationsdatei auswählen"

        If openFileDialog.ShowDialog() = DialogResult.OK Then
            Dim filePath As String = openFileDialog.FileName

            ' Passwort vom Benutzer abfragen
            Dim userPassword As String = InputBox("Bitte geben Sie das Passwort ein, um die Datei zu entschlüsseln:", "Passwort Eingabe")

            If String.IsNullOrEmpty(userPassword) Then
                MessageBox.Show("Kein Passwort eingegeben. Vorgang abgebrochen.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            Dim keySize As Integer = 16 ' 128 Bit
            Dim key As Byte() = PasswordHelper.GenerateKeyFromPassword(userPassword, keySize)

            Try
                ' Lesen Sie die gespeicherten Daten, die IV und verschlüsselte Daten enthalten
                Dim ivAndEncryptedData As Byte() = IO.File.ReadAllBytes(filePath)

                ' Extrahieren Sie den IV
                Dim iv As Byte() = ivAndEncryptedData.Take(16).ToArray()

                ' Extrahieren Sie die verschlüsselten Daten
                Dim encryptedData As Byte() = ivAndEncryptedData.Skip(16).ToArray()
                Dim encryptedDataString As String = Convert.ToBase64String(encryptedData)

                ' Entschlüsseln der Daten
                Dim decryptedData As String = PasswordHelper.DecryptString(encryptedDataString, key, iv)
                Dim dataParts As String() = decryptedData.Split(";"c)

                For Each part As String In dataParts
                    If String.IsNullOrWhiteSpace(part) Then
                        Continue For ' Überspringen Sie leere Teile
                    End If

                    Dim keyValue As String() = part.Split("="c)
                    If keyValue.Length <> 2 Then
                        Continue For ' Überspringen Sie fehlerhafte Teile
                    End If

                    Select Case keyValue(0)
                        Case "MySQLServer"
                            TXB_MySqlServer.Text = keyValue(1)
                        Case "MySQLUser"
                            TXB_MySqlUsername.Text = keyValue(1)
                        Case "MySQLDatabaseName"
                            TXB_MySqlDatabase.Text = keyValue(1)
                        Case "MySQLPassword"
                            TXB_MySqlPassword.Text = keyValue(1)
                        Case "FTPServer"
                            TXB_FTPServerUri.Text = keyValue(1)
                        Case "FTPUser"
                            TXB_FTPUsername.Text = keyValue(1)
                        Case "FTPPassword"
                            TXB_FTPPassword.Text = keyValue(1)
                    End Select
                Next

                Notify(NI_Successful, "Erfolg", "Daten wurden erfolgreich geladen", 5000, ToolTipIcon.None)
            Catch ex As UnauthorizedAccessException
                Notify(NI_Error, "Fehler", "Zugriff verweigert. Bitte prüfen Sie die Berechtigungen", 5000, ToolTipIcon.None)
            Catch ex As Exception
                Notify(NI_Error, "Fehler", "Ein Fehler ist aufgetreten: " & ex.Message, 5000, ToolTipIcon.None)
            End Try
        End If
    End Sub

    Private Sub CB_SFTP_CheckedChanged(sender As Object, e As EventArgs) Handles CB_SFTP.CheckedChanged
        If CB_SFTP.Checked Then
            PNL_SFTP.Visible = True
            PNL_FTP.Visible = False
        Else
            PNL_SFTP.Visible = False
            PNL_FTP.Visible = True
        End If
    End Sub

    Private Sub BTN_LoadOpenSSHKey_Click(sender As Object, e As EventArgs) Handles BTN_LoadOpenSSHKey.Click
        SSHKEY.Show()


    End Sub

    Private Async Sub BTN_CheckLicense_Click(sender As Object, e As EventArgs) Handles BTN_CheckLicense.Click
        If TXB_LicenseName.Text.Length > 0 AndAlso TXB_LicenseEmail.Text.Length > 0 AndAlso TXB_Regkey.Text.Length > 0 Then



            Dim userdata = Await GetUserDataAsync(TXB_Regkey.Text)

            If Not String.IsNullOrEmpty(userdata.Name) AndAlso Not String.IsNullOrEmpty(userdata.Email) AndAlso TXB_LicenseName.Text.ToUpper = userdata.Name.ToUpper AndAlso TXB_LicenseEmail.Text.ToUpper = userdata.Email.ToUpper Then
                GroupBox2.Enabled = True
                GroupBox3.Enabled = True
            Else
                MsgBox("Lizenzdaten ungültig")
            End If
        Else
            MsgBox("Bitte alle Lizenzdaten ausfüllen")
        End If



    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Process.Start("https://www.lfdev.de/php/register.php")
    End Sub


End Class

