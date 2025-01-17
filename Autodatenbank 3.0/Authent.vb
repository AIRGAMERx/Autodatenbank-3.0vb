Imports System.ComponentModel
Imports MySqlConnector
Imports QRCoder

Public Class Authent
    Dim id As String = ""
    Dim username As String = ""
    Dim permissionKey As String = ""

    Private Sub Authent_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Autodatenbank.Enabled = False
        My.Settings.Username = ""
        My.Settings.Save()

        If My.Settings.NFCVerify = True Then

            LBL_NFC.Visible = True

        Else
            LBL_NFC.Visible = False

        End If

        If My.Settings.SmartphoneVerify = True And Not String.IsNullOrEmpty(GetUserNameFromID(My.Settings.LastUserLog)) Then
            LL_LastUser.Text = "Nicht " & GetUserNameFromID(My.Settings.LastUserLog) & "?"
            LL_LastUser.Visible = True
            PictureBox1.Visible = True

        Else
            LL_LastUser.Visible = False
            PictureBox1.Visible = False
        End If


        If Not String.IsNullOrEmpty(GetUserNameFromID(My.Settings.LastUserLog)) Then
            TXB_UserName.Text = GetUserNameFromID(My.Settings.LastUserLog)
        End If


        If Not String.IsNullOrEmpty(My.Settings.LastUserLog) Then
            Dim con As New MySqlConnection(My.Settings.connectionstring)
            TMR_CheckAuthent.Start()
            Dim rnd As New Random
            Dim randomKey As String = rnd.Next(10000000, 99999999).ToString()
            Dim gen As New QRCodeGenerator
            Dim data = gen.CreateQrCode(randomKey, QRCodeGenerator.ECCLevel.Q)
            Dim code As New QRCode(data)
            PictureBox1.BackgroundImage = code.GetGraphic(6)
            Try
                con.Open()
                Dim query As String = "UPDATE users SET AuthentKey = @Value WHERE id = @ID "
                Dim command As New MySqlCommand(query, con)
                command.Parameters.AddWithValue("@Value", randomKey)
                command.Parameters.AddWithValue("@ID", My.Settings.LastUserLog)
                command.ExecuteNonQuery()
                con.Close()
                'MsgBox("wurde aktualisiert bei ID: " & My.Settings.LastUserLog & vbNewLine & "Key : " & randomKey) '#Debugg Anweisung im Release löschen
            Catch ex As Exception
                MsgBox(ex.Message)
                con.Close()
            End Try
        End If


    End Sub
    Private Sub LL_LastUser_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LL_LastUser.LinkClicked
        LL_LastUser.Visible = False
        PictureBox1.Visible = False
        TXB_UserName.Text = ""

        Try
            Dim query As String = "UPDATE users SET AuthentKey = @Value WHERE id = @ID"
            Using con As New MySqlConnection(My.Settings.connectionstring)
                con.Open()
                Using cmd As New MySqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@Value", "")
                    cmd.Parameters.AddWithValue("@ID", My.Settings.LastUserLog)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            My.Settings.LastUserLog = ""
            My.Settings.Save()
        Catch ex As Exception
            SavetoLogFile(ex.Message, "DeleteLastUser")
        End Try




    End Sub

    Private Sub TMR_CheckAuthent_Tick(sender As Object, e As EventArgs) Handles TMR_CheckAuthent.Tick

        If Not My.Settings.Username = "" Then
            Autodatenbank.Enabled = True
            Me.Close()
        End If

        Dim con As New MySqlConnection(My.Settings.connectionstring)

        Try
            con.Open()
            Dim query As String = "SELECT id, user_name, PermissionKey FROM users WHERE Authent = 1"
            Dim command As New MySqlCommand(query, con)
            Using reader As MySqlDataReader = command.ExecuteReader
                If reader.HasRows Then
                    While reader.Read()
                        id = reader.GetString(0)
                        username = reader.GetString(1)
                        permissionKey = reader.GetString(2)
                    End While
                End If
            End Using
            con.Close()

            If Not id = "" Then

                Try
                    Autodatenbank.GetUserData(id)
                    Dim connection As New MySqlConnection(My.Settings.connectionstring)
                    connection.Open()
                    Dim queryDelete As String = "UPDATE users SET AuthentKey = '', Authent = 0  "
                    Dim commandDelete As New MySqlCommand(queryDelete, connection)
                    commandDelete.ExecuteNonQuery()
                    connection.Close()
                    Autodatenbank.Show()
                    LoadDGVSettings()
                    Me.Close()
                Catch ex As Exception

                End Try
            End If
        Catch ex As Exception

        End Try

    End Sub


    Private Sub Authent_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If Autodatenbank.Enabled = False Then
            Autodatenbank.Close()
        End If

    End Sub

    Private Sub TXB_Password_KeyDown(sender As Object, e As KeyEventArgs) Handles TXB_Password.KeyDown
        If e.KeyCode = Keys.Enter Then
            BTN_Login.PerformClick()
        End If


    End Sub
    Private Sub TXB_Password_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXB_Password.KeyPress

    End Sub

    Private Sub BTN_Login_Click(sender As Object, e As EventArgs) Handles BTN_Login.Click
        Dim GotDate As Boolean = False
        Dim savedPassword As String = ""
        Dim savedSalt As String = ""
        Dim passdate As DateTime
        Dim failedAttempts As Integer
        Dim lockoutUntil As DateTime?
        Dim otpactive As Integer
        Dim otpdate As DateTime

        Me.Cursor = Cursors.WaitCursor

        ' Aktualisierte SQL-Abfrage, um zusätzliche Felder zu erhalten
        Dim query As String = "SELECT password, salt, id, Passdate, failed_attempts, lockout_until, otp, otp_date FROM users WHERE user_name = @Username"

        Using connection As New MySqlConnection(My.Settings.connectionstring)
            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@Username", TXB_UserName.Text)

                Try
                    connection.Open()
                    Using reader As MySqlDataReader = command.ExecuteReader()
                        If reader.Read() Then
                            ' Benutzername existiert, zusätzliche Felder abrufen
                            savedPassword = reader("password").ToString()
                            savedSalt = reader("salt").ToString()


                            otpactive = If(reader.IsDBNull(reader.GetOrdinal("otp")), 0, CType(reader("otp"), Integer))
                            otpdate = If(reader.IsDBNull(reader.GetOrdinal("otp_date")), Nothing, CType(reader("otp_date"), DateTime))

                            Dim userId As String = reader("id").ToString()
                                failedAttempts = Convert.ToInt32(reader("failed_attempts"))
                                lockoutUntil = If(reader.IsDBNull(reader.GetOrdinal("lockout_until")), Nothing, CType(reader("lockout_until"), DateTime?))

                                'Datum der Letzten Passwortänderung abrufen
                                If Not reader.IsDBNull(reader.GetOrdinal("Passdate")) Then
                                    passdate = reader.GetDateTime("Passdate")
                                    GotDate = True
                                End If

                                ' Überprüfen, ob der Benutzer gesperrt ist
                                If lockoutUntil.HasValue AndAlso DateTime.Now < lockoutUntil.Value Then
                                    ' Benutzer ist gesperrt
                                    Me.Cursor = Cursors.Default
                                    MsgBox("Ihr Konto ist gesperrt. Bitte versuchen Sie es später erneut.", MsgBoxStyle.Critical)
                                    Return
                                End If

                                ' Hash des eingegebenen Passworts unter Verwendung des gespeicherten Salts berechnen
                                Dim isPasswordCorrect As Boolean = PasswordHelper.VerifyPassword(TXB_Password.Text, savedPassword, savedSalt)

                                ' Vergleich mit dem gespeicherten Passwort
                                If isPasswordCorrect Then
                                    ' Passwort korrekt, Benutzerdaten abrufen
                                    Me.Cursor = Cursors.Default

                                    ' Reset fehlgeschlagene Versuche
                                    Dim resetCommand As New MySqlCommand("UPDATE users SET failed_attempts = 0, lockout_until = NULL WHERE user_name = @Username", connection)
                                    resetCommand.Parameters.AddWithValue("@Username", TXB_UserName.Text)
                                    reader.Close() ' Reader schließen, bevor eine neue Abfrage ausgeführt wird
                                    resetCommand.ExecuteNonQuery()

                                    If otpactive = 1 Then
                                    If Now.Date <= otpdate.AddHours(1) Then
                                        NewPassword.Show()
                                        NewPassword.GetData(userId, TXB_UserName.Text)
                                        Me.Close()
                                        Exit Sub

                                    Else
                                        MsgBox("Das OneTimePassword ist abgelaufen, bitte Administrator kontaktien")
                                            Exit Sub
                                        End If

                                    End If


                                    ' Überprüfen, ob das Passwort älter als 6 Monate ist
                                    If GotDate AndAlso My.Settings.OldPassword = True AndAlso Now.Date > passdate.AddMonths(6) Then
                                        ' Erstelle und zeige einen benutzerdefinierten Dialog
                                        Dim result As DialogResult = MessageBox.Show("Passwort ist schon mindestens seit 6 Monaten nicht geändert worden", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)

                                        ' Warten, bis der Benutzer den Dialog bestätigt
                                        If result = DialogResult.OK Then

                                            ' Schließt das Formular erst, nachdem der Benutzer den Dialog bestätigt hat
                                            Autodatenbank.GetUserData(userId)
                                            My.Settings.LastUserLog = userId
                                            My.Settings.Save()
                                            Autodatenbank.Show()
                                            LoadOverallSettings()
                                            LoadDGVSettings()
                                            My.Settings.CloseToAuth = False
                                            Notify(Autodatenbank.NI_Successful, "Anmeldung", "Herzlich Wilkommen zurück " & My.Settings.Username, 5000, ToolTipIcon.None)
                                            Me.Close()
                                        End If
                                    Else
                                        ' Schließt das Formular, wenn keine Nachricht angezeigt wird

                                        Autodatenbank.GetUserData(userId)
                                        My.Settings.LastUserLog = userId
                                        My.Settings.Save()
                                        LoadDGVSettings()
                                        LoadOverallSettings()
                                        Autodatenbank.Show()
                                        Notify(Autodatenbank.NI_Successful, "Anmeldung", "Herzlich Wilkommen zurück " & My.Settings.Username, 5000, ToolTipIcon.None)
                                        Me.Close()
                                    End If
                                Else
                                    ' Passwort ist nicht korrekt
                                    failedAttempts += 1

                                    If failedAttempts >= 5 Then
                                        ' Konto sperren
                                        Dim lockoutTime As DateTime = DateTime.Now.AddMinutes(15) ' Sperre für 15 Minuten
                                        Dim lockCommand As New MySqlCommand("UPDATE users SET failed_attempts = @failedAttempts, lockout_until = @lockoutUntil WHERE user_name = @Username", connection)
                                        lockCommand.Parameters.AddWithValue("@failedAttempts", failedAttempts)
                                        lockCommand.Parameters.AddWithValue("@lockoutUntil", lockoutTime)
                                        lockCommand.Parameters.AddWithValue("@Username", TXB_UserName.Text)
                                        reader.Close() ' Reader schließen, bevor eine neue Abfrage ausgeführt wird
                                        lockCommand.ExecuteNonQuery()

                                        Me.Cursor = Cursors.Default
                                        MsgBox("Zu viele fehlgeschlagene Anmeldeversuche. Ihr Konto ist für 15 Minuten gesperrt.", MsgBoxStyle.Critical)
                                    Else
                                        ' Anzahl der fehlgeschlagenen Versuche aktualisieren
                                        Dim updateCommand As New MySqlCommand("UPDATE users SET failed_attempts = @failedAttempts WHERE user_name = @Username", connection)
                                        updateCommand.Parameters.AddWithValue("@failedAttempts", failedAttempts)
                                        updateCommand.Parameters.AddWithValue("@Username", TXB_UserName.Text)
                                        reader.Close() ' Reader schließen, bevor eine neue Abfrage ausgeführt wird
                                        updateCommand.ExecuteNonQuery()

                                        Me.Cursor = Cursors.Default
                                        Notify(Autodatenbank.NI_Error, "Login Daten", "Passwort oder Benutzer nicht korrekt", 10000, ToolTipIcon.Error)
                                    End If
                                End If
                            Else
                                ' Benutzername wurde nicht gefunden
                                Me.Cursor = Cursors.Default
                            Notify(Autodatenbank.NI_Error, "Login Daten", "Passwort oder Benutzer nicht korrekt", 10000, ToolTipIcon.Error)
                        End If
                    End Using
                Catch ex As Exception
                    ' Fehlerbehandlung
                    Me.Cursor = Cursors.Default
                    Notify(Autodatenbank.NI_Error, "Fehler beim Anmelden", ex.Message.ToString, 10000, ToolTipIcon.Error)
                    SavetoLogFile(ex.Message, "LogIN")
                End Try
            End Using
        End Using
    End Sub



    Public Function GetUserNameFromID(ID As String) As String
        Console.WriteLine(ID & "Last Login ID")
        If String.IsNullOrEmpty(ID) Then
            Return String.Empty
        Else
            Try
                Dim query As String = "SELECT user_name FROM users WHERE id = @ID"
                Using con As New MySqlConnection(My.Settings.connectionstring)
                    con.Open()
                    Using cmd As New MySqlCommand(query, con)
                        cmd.Parameters.AddWithValue("@ID", ID)
                        Using reader As MySqlDataReader = cmd.ExecuteReader
                            If reader.Read Then
                                If reader.HasRows Then
                                    Dim name As String = reader.GetString("user_name")
                                    Return name
                                Else
                                    Return String.Empty
                                End If
                            Else
                                Return String.Empty
                            End If

                        End Using
                    End Using



                End Using
            Catch ex As Exception
                SavetoLogFile(ex.Message, "GetUserNameFromID")
                Return String.Empty

            End Try


        End If

    End Function


End Class