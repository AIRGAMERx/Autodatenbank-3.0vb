Imports System.IO
Imports System.IO.Compression
Imports System.Security.Cryptography
Imports MySqlConnector
Imports QRCoder

Public Class ServerConnection
    Dim ConnectionString As String


    Private Async Sub ServerConnection_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        LoadOverallSettings()

        If SSHKEY.CheckOpenSSHKey(My.Settings.keyfile, My.Settings.keyfilepass) Then
            CB_KeyFileLoaded.Checked = True
        Else
            CB_KeyFileLoaded.Checked = False

        End If

        'Settings in Textboxen laden
        Dim parts As String() = My.Settings.connectionstring.Split(";"c)

        For Each part As String In parts
            Dim keyValue As String() = part.Split("="c)
            If keyValue.Length = 2 Then
                Dim key As String = keyValue(0).Trim()
                Dim value As String = keyValue(1).Trim()

                Select Case key.ToLower()
                    Case "server"
                        TXB_MySqlServer.Text = value
                    Case "user"
                        TXB_MySqlUsername.Text = value
                    Case "database"
                        TXB_MySqlDatabase.Text = value
                    Case "password"
                        TXB_MySqlPassword.Text = value

                End Select
            End If
        Next


        TXB_FTPServerUri.Text = My.Settings.Ftpserveruri
        TXB_FTPUsername.Text = My.Settings.Ftpusername
        TXB_FTPPassword.Text = My.Settings.Ftppassword
        TXB_SFTPServerUri.Text = My.Settings.SFTPServerUri
        TXB_SFTPUsername.Text = My.Settings.SFTPUsername


        If My.Settings.sftp = True Then
            CB_SFTP.Checked = True
            PNL_SFTP.Visible = True
            PNL_FTP.Visible = False
            GB_FTPConnectionData.Text = "SFTP Verbindungsdaten"
        Else
            CB_SFTP.Checked = False
            PNL_SFTP.Visible = False
            PNL_FTP.Visible = True
            GB_FTPConnectionData.Text = "FTP Verbindungsdaten"
        End If




        Dim userdata = Await GetUserDataAsync(My.Settings.Regkey)
        TXB_LicenseEmail.Text = userdata.Email
        TXB_LicenseName.Text = userdata.Name







    End Sub

    Private Sub BTN_TryMqSqlConnectin_Click(sender As Object, e As EventArgs) Handles BTN_TryMqSqlConnectin.Click
        ConnectionString = "server=" + TXB_MySqlServer.Text + ";user=" + TXB_MySqlUsername.Text + ";database=" + TXB_MySqlDatabase.Text + ";password=" + TXB_MySqlPassword.Text + ";"

        Dim TestConnectionMysql As New MySqlConnection(ConnectionString)

        Try
            TestConnectionMysql.Open()
            LBL_MySqlConnection.Text = "Verbunden"
            LBL_MySqlConnection.ForeColor = Color.Green


            Notify(Autodatenbank.NI_Successful, "Erfolg", "Erfolgreich mit Datenbank verbunden", 5000, ToolTipIcon.None)


            Dim data As String = "FTP;" + "server_uri=" + TXB_MySqlServer.Text + ";port=3306" + ";databasename=" + TXB_MySqlDatabase.Text + ";username=" + TXB_MySqlUsername.Text + ";password=" + TXB_MySqlPassword.Text

            Dim qrCodeImage As Bitmap = GenerateQRCode(data)
            PB_QRMYSQL.BackgroundImage = qrCodeImage




        Catch ex As Exception

            LBL_MySqlConnection.Text = "Nicht Verbunden"
            LBL_MySqlConnection.ForeColor = Color.Red
            MsgBox("Verbindung zur Datenbank konnte nicht hergestellt werden", MsgBoxStyle.Critical)
            SavetoLogFile(ex.Message, "TryMySqlConnectionServerconnection")
        End Try

        If LBL_MySqlConnection.Text = "Verbunden" AndAlso LBL_FTPConnection.Text = "Verbunden" Then
            BTN_SaveData.Enabled = True


        End If


    End Sub

    Private Sub BTN_TryFTPConnection_Click(sender As Object, e As EventArgs) Handles BTN_TryFTPConnection.Click

        Try



            ' QR-Code generieren und Verbindung als erfolgreich markieren
            If FTP.TestFTPConnection(TXB_FTPServerUri.Text, TXB_FTPUsername.Text, TXB_FTPPassword.Text) = True Then
                LBL_FTPConnection.Text = "Verbunden"
                LBL_FTPConnection.ForeColor = Color.Green
                Notify(Autodatenbank.NI_Successful, "Erfolg", "Erfolgreich mit dem Server verbunden", 5000, ToolTipIcon.None)
                Dim data As String = "server_uri=" + TXB_FTPServerUri.Text + ";port=21" + ";username=" + TXB_FTPUsername.Text + ";password=" + TXB_FTPPassword.Text
                Dim qrCodeImage As Bitmap = GenerateQRCode(data)
                PB_QRFTP.BackgroundImage = qrCodeImage
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
        If CB_KeyFileLoaded.Checked = True Then

            Try

                If TestSFTPConnection(TXB_SFTPServerUri.Text, TXB_SFTPUsername.Text) = True Then
                    LBL_FTPConnection.Text = "Verbunden"
                    LBL_FTPConnection.ForeColor = Color.Green
                    Notify(Autodatenbank.NI_Successful, "Erfolg", "Erfolgreich mit dem Server verbunden", 5000, ToolTipIcon.None)
                    CB_SFTP.Checked = True
                    My.Settings.sftp = True
                    My.Settings.Save()
                    UpdateSettings(My.Settings.Regkey)

                Else
                    LBL_FTPConnection.Text = "Nicht Verbunden"
                    LBL_FTPConnection.ForeColor = Color.Red
                End If

            Catch ex As Exception
                LBL_FTPConnection.Text = "Nicht Verbunden"
                LBL_FTPConnection.ForeColor = Color.Red
                MsgBox("Verbindung zum Server konnte nicht hergestellt werden", MsgBoxStyle.Critical)
                SavetoLogFile(ex.Message, "TrySFTPConnectionServerConnection")

            End Try
        Else
            MsgBox("Bei Verbindung mit SFTP muss zuerst der OpenSSH-Key erfolgreich geladen werden")
        End If
        ' Aktiviert den Speichern-Button nur, wenn beide Verbindungen erfolgreich sind
        If LBL_MySqlConnection.Text = "Verbunden" AndAlso LBL_FTPConnection.Text = "Verbunden" Then
            BTN_SaveData.Enabled = True
        End If


    End Sub


    Private Sub BTN_SaveData_Click(sender As Object, e As EventArgs) Handles BTN_SaveData.Click
        ConnectionString = "server=" + TXB_MySqlServer.Text + ";user=" + TXB_MySqlUsername.Text + ";database=" + TXB_MySqlDatabase.Text + ";password=" + TXB_MySqlPassword.Text + ";"
        Dim trimmedText As String = TXB_FTPServerUri.Text.Trim().ToLower()
        If Not trimmedText.StartsWith("ftp://") AndAlso My.Settings.sftp = False Then
            TXB_FTPServerUri.Text = "ftp://" & TXB_FTPServerUri.Text
        End If


        My.Settings.connectionstring = ConnectionString
        My.Settings.Ftpserveruri = TXB_FTPServerUri.Text
        My.Settings.Ftpusername = TXB_FTPUsername.Text
        My.Settings.Ftppassword = TXB_FTPPassword.Text
        My.Settings.SFTPServerUri = TXB_SFTPServerUri.Text
        My.Settings.SFTPUsername = TXB_SFTPUsername.Text
        My.Settings.sftp = CB_SFTP.Checked
        My.Settings.Save()

        UpdateSettings(My.Settings.Regkey)

        LoadConnectionSettings()

        If CheckBox1.Checked Then
            CreateTables()
        End If

        If CB_RepairDatabase.Checked Then
            If UpdateTable() = True Then
                Notify(Autodatenbank.NI_Successful, "Erfolg", "Datenbank wurde erfolgreich überprüft", 5000, ToolTipIcon.None)
            End If
        End If

        Autodatenbank.LoadCars()
        Me.Close()
    End Sub

    Private Function GenerateQRCode(data As String) As Bitmap
        Dim qrGenerator As New QRCodeGenerator()
        Dim qrCodeData = qrGenerator.CreateQrCode(data, QRCodeGenerator.ECCLevel.Q)
        Dim qrCode As New QRCode(qrCodeData)
        Return qrCode.GetGraphic(20)
    End Function

    Private Sub ToolStripLabel2_Click(sender As Object, e As EventArgs) Handles ToolStripLabel2.Click
        If FBD_SaveConfigFile.ShowDialog() = DialogResult.OK Then
            Dim userPassword As String = InputBox("Bitte geben Sie ein Passwort ein, um die Datei zu verschlüsseln:", "Passwort Eingabe")
            If String.IsNullOrEmpty(userPassword) Then
                MessageBox.Show("Kein Passwort eingegeben. Speichern abgebrochen.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            Dim keySize As Integer = 16 ' 128 Bit
            Dim key As Byte() = PasswordHelper.GenerateKeyFromPassword(userPassword, keySize)

            ' Generiere einen zufälligen IV für zusätzliche Sicherheit
            Dim iv As Byte() = New Byte(15) {} ' 16 Bytes = 128 Bit für AES
            Using rng As New RNGCryptoServiceProvider()
                rng.GetBytes(iv)
            End Using

            Dim data As String = "MySQLServer=" & TXB_MySqlServer.Text & ";MySQLUser=" & TXB_MySqlUsername.Text & ";MySQLDatabaseName=" & TXB_MySqlDatabase.Text &
                             ";MySQLPassword=" & TXB_MySqlPassword.Text & ";FTPServer=" & TXB_FTPServerUri.Text &
                             ";FTPUser=" & TXB_FTPUsername.Text & ";FTPPassword=" & TXB_FTPPassword.Text & ";SFTPServer=" & TXB_SFTPServerUri.Text & ";SFTPUser=" & TXB_SFTPUsername.Text &
                             ";SFTPKeypass=" & My.Settings.keyfilepass & ";SFTPKeyFileName=" & Path.GetFileName(My.Settings.keyfile)


            Dim encryptedData As String = PasswordHelper.EncryptString(data, key, iv)

            ' Kombinieren Sie den IV und die verschlüsselten Daten
            Dim ivAndEncryptedData As Byte() = iv.Concat(Convert.FromBase64String(encryptedData)).ToArray()

            Try
                ' Verwende ein sicheres Format für den Dateinamen
                Dim fileName As String = "AutodatenbankConfig_" & Now.ToString("yyyyMMdd") & ".enc"
                Dim filePath As String = IO.Path.Combine(FBD_SaveConfigFile.SelectedPath, fileName)

                ' Speichern Sie die kombinierten Daten (IV + verschlüsselte Daten)
                IO.File.WriteAllBytes(filePath, ivAndEncryptedData)
                If File.Exists(IO.Path.Combine(FBD_SaveConfigFile.SelectedPath, "ConnectionSettings.enczip")) Then
                    File.Delete(IO.Path.Combine(FBD_SaveConfigFile.SelectedPath, "ConnectionSettings.enczip"))
                End If
                Using archiver As ZipArchive = ZipFile.Open(IO.Path.Combine(FBD_SaveConfigFile.SelectedPath, "ConnectionSettings.enczip"), ZipArchiveMode.Create)
                    archiver.CreateEntryFromFile(filePath, Path.GetFileName(filePath))
                    If File.Exists(My.Settings.keyfile) Then
                        archiver.CreateEntryFromFile(My.Settings.keyfile, Path.GetFileName(My.Settings.keyfile))
                    End If


                End Using



                Notify(NI_Successful, "Erfolg", "Daten wurden erfolgreich exportiert und als ConnectionSettings.enczip gespeichert", 5000, ToolTipIcon.None)
            Catch ex As UnauthorizedAccessException
                Notify(NI_Error, "Fehler", "Zugriff verweigert. Bitte prüfen Sie die Berechtigungen.", 5000, ToolTipIcon.None)
                SavetoLogFile(ex.Message, "ExportServerConnection")
            Catch ex As Exception
                Notify(NI_Error, "Fehler", "Ein Fehler ist aufgetreten: " & ex.Message, 5000, ToolTipIcon.None)
                SavetoLogFile(ex.Message, "ExportServerConnection")
            End Try
        End If
    End Sub


    Private Sub ToolStripLabel1_Click(sender As Object, e As EventArgs) Handles ToolStripLabel1.Click
        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.Filter = "Encrypted files (*.enczip)|*.enczip|All files (*.*)|*.*"
        openFileDialog.Title = "Verschlüsselte Konfigurationsdatei auswählen"




        If openFileDialog.ShowDialog() = DialogResult.OK Then
            Dim zipedFilepath As String = openFileDialog.FileName
            Dim connectionFile As String = ""
            Dim filelist As List(Of String) = ListFilesInZip(zipedFilepath)
            Dim OpenSSHKey As Boolean = False
            Dim OpenSSHKeyFilename As String = ""
            Try
                For Each tempfile As String In Directory.GetFiles(Application.StartupPath & "/temp/")
                    Try
                        File.Delete(tempfile)
                    Catch ex As Exception

                    End Try
                Next
            Catch ex As Exception

            End Try



            ZipFile.ExtractToDirectory(zipedFilepath, Application.StartupPath & "/temp/")

            For Each fileName As String In filelist
                If Path.GetExtension(fileName) = ".enc" Then
                    connectionFile = Application.StartupPath & "/temp/" & Path.GetFileName(fileName)
                    Exit For
                End If
            Next

            For Each fileName As String In filelist
                If Path.GetExtension(fileName) = ".pem" Then
                    OpenSSHKey = True
                    CB_SFTP.Checked = True
                    PNL_SFTP.Visible = True
                    PNL_FTP.Visible = False
                    Exit For
                Else
                    OpenSSHKey = False
                End If

            Next




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
                Dim ivAndEncryptedData As Byte() = IO.File.ReadAllBytes(connectionFile)

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
                        Case "SFTPServer"
                            TXB_SFTPServerUri.Text = keyValue(1)
                        Case "SFTPUser"
                            TXB_SFTPUsername.Text = keyValue(1)
                        Case "SFTPKeypass"
                            My.Settings.keyfilepass = keyValue(1)
                        Case "SFTPKeyFileName"
                            OpenSSHKeyFilename = Path.GetFileNameWithoutExtension(keyValue(1))
                    End Select
                Next
                If OpenSSHKey = True Then
                    If File.Exists(Application.StartupPath & "/temp/" & OpenSSHKeyFilename & ".pem") Then
                        File.Copy(Application.StartupPath & "/temp/" & OpenSSHKeyFilename & ".pem", Application.StartupPath & "/" & OpenSSHKeyFilename & ".pem", True)
                        My.Settings.keyfile = Application.StartupPath & "/" & OpenSSHKeyFilename & ".pem"
                        If SSHKEY.CheckOpenSSHKey(My.Settings.keyfile, My.Settings.keyfilepass) = True Then
                            CB_KeyFileLoaded.Checked = True
                        Else
                            CB_KeyFileLoaded.Checked = False
                        End If
                    End If

                End If




                Notify(NI_Successful, "Erfolg", "Daten wurden erfolgreich geladen", 5000, ToolTipIcon.None)
            Catch ex As UnauthorizedAccessException
                Notify(NI_Error, "Fehler", "Zugriff verweigert. Bitte prüfen Sie die Berechtigungen", 5000, ToolTipIcon.None)
                SavetoLogFile(ex.Message, "ImportServerConnection")
            Catch ex As Exception
                Notify(NI_Error, "Fehler", "Ein Fehler ist aufgetreten: " & ex.Message, 5000, ToolTipIcon.None)
                SavetoLogFile(ex.Message, "ImportServerconnection")
            End Try
        End If
    End Sub

    Private Sub CB_SFTP_CheckedChanged(sender As Object, e As EventArgs) Handles CB_SFTP.CheckedChanged

    End Sub

    Private Sub CB_SFTP_Click(sender As Object, e As EventArgs) Handles CB_SFTP.Click

        If CB_SFTP.Checked = True Then
            PNL_SFTP.Visible = True
            PNL_FTP.Visible = False
            PNL_FTP.SendToBack()
            PNL_SFTP.BringToFront()
            GB_FTPConnectionData.Text = "SFTP Verbindungsdaten"
        Else
            Select Case MessageBox.Show(" Sftp wirklich deaktivieren, OpenSSH Keyfile wird dabei unwiederruflich gelöscht", "SFTP Deaktivieren?", MessageBoxButtons.YesNo)
                Case Windows.Forms.DialogResult.Yes

                    Try
                        If File.Exists(My.Settings.keyfile) Then
                            File.Delete(My.Settings.keyfile)
                        End If

                        My.Settings.sftp = False
                        My.Settings.keyfile = ""
                        My.Settings.keyfilepass = ""
                        My.Settings.SFTPServerUri = ""
                        My.Settings.SFTPUsername = ""
                        My.Settings.Save()
                        CB_KeyFileLoaded.Checked = False
                        PNL_SFTP.Visible = False
                        PNL_FTP.Visible = True
                        GB_FTPConnectionData.Text = "FTP Verbindungsdaten"

                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                        SavetoLogFile(ex.Message, "DeleteSFTPKey")
                    End Try

                Case Windows.Forms.DialogResult.No
                    CB_SFTP.Checked = True


            End Select
        End If
    End Sub

    Private Sub BTN_LoadOpenSSHKey_Click(sender As Object, e As EventArgs) Handles BTN_LoadOpenSSHKey.Click
        SSHKEY.Show()

    End Sub


    Public Function ListFilesInZip(zipFilePath As String) As List(Of String)
        ' Liste zur Speicherung der Dateinamen
        Dim fileList As New List(Of String)()

        ' Öffnet das ZIP-Archiv
        Using archive As ZipArchive = ZipFile.OpenRead(zipFilePath)
            ' Iteriere durch alle Einträge im ZIP-Archiv
            For Each entry As ZipArchiveEntry In archive.Entries
                ' Füge den vollständigen Dateipfad zur Liste hinzu
                fileList.Add(entry.FullName)
            Next
        End Using

        ' Rückgabe der Liste mit Dateinamen
        Return fileList
    End Function
End Class

