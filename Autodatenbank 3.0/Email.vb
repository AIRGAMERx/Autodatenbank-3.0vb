Imports System.IO
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel

Public Class Email
    Private Sub Email_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If File.Exists(Application.StartupPath & "\Settings\" & My.Settings.UID & "\EmailSettings.json") Then
            Dim password As String
            password = InputBox("Bitte geben Sie Ihr Passwort ein:", "Passwort-Eingabe")

            If String.IsNullOrWhiteSpace(password) Then
                MsgBox("Kein Passwort eingegeben!", MsgBoxStyle.Exclamation, "Fehler")
            Else
                Try
                    Dim finalkey As String = GenerateKeyFromPassphrase(password)
                    Dim settings As EmailSettings = LoadEmailSettings(finalkey)

                    TXB_SMTP.Text = settings.SmtpServer
                    TXB_Port.Text = settings.Port.ToString
                    TXB_LoginEmail.Text = settings.Username
                    TXB_password.Text = settings.Password
                    TXB_SenderEmail.Text = settings.SenderEmail
                    TXB_SenderDisplayName.Text = settings.SenderDisplayName
                    TXB_Timeout.Text = settings.Timeout.ToString

                    If settings.EnableSsl = True Then
                        CB_SSL.Checked = True
                    Else
                        CB_SSL.Checked = False
                    End If


                Catch ex As Exception

                End Try
            End If

        End If
    End Sub

    Private Sub BTN_Save_Click(sender As Object, e As EventArgs) Handles BTN_Save.Click
        For Each ctrl As Control In GB_EmailSettings.Controls
            Try

                If TypeOf ctrl Is TextBox Then
                    Dim tb As TextBox = DirectCast(ctrl, TextBox)

                    If String.IsNullOrWhiteSpace(tb.Text) Then
                        MsgBox("Bitte alle Felder ausfüllen")
                        Exit For
                    End If
                End If
            Catch ex As Exception

                MsgBox($"Ein Fehler ist aufgetreten: {ex.Message}")
            End Try
        Next

        Dim port As Integer
        If Not Integer.TryParse(TXB_Port.Text, port) Then
            MsgBox("Bitte nur ganze Zahlen in das Feld 'Port' eingeben.", MsgBoxStyle.Exclamation, "Ungültige Eingabe")
            TXB_Port.Focus()
            Return
        End If

        Dim timeout As Integer
        If Not Integer.TryParse(TXB_Timeout.Text, timeout) Then
            MsgBox("Bitte nur ganze Zahlen in das Feld 'Timeout' eingeben.", MsgBoxStyle.Exclamation, "Ungültige Eingabe")
            TXB_Timeout.Focus()
            Return
        End If

        If TrySendTestEmail() = False Then
            Exit Sub
        Else
            Dim password As String
            password = InputBox("Diese Daten werden mit einem extra Passwort gesichert, bitte gebe eins an. Diesen Passwort muss vor jedem Email versand zb. bei vergabe eines OTP eines Benutzers eingegeben werden", "Passwort-Eingabe")

            If String.IsNullOrWhiteSpace(password) Then
                MsgBox("Kein Passwort eingegeben, bitte erneut versuchen")
            Else
                Dim finalKey As String = GenerateKeyFromPassphrase(password)
                CreateEmailSettings(TXB_SMTP.Text, CInt(TXB_Port.Text), TXB_LoginEmail.Text, TXB_password.Text, TXB_SenderEmail.Text, TXB_SenderDisplayName.Text, CB_SSL.Checked, CInt(TXB_Timeout.Text), finalKey)
                Notify(Autodatenbank.NI_Successful, "Erfolgreich gespeichert", "Email Einstellungen wurden erfolgreich getestet und gespeichert.", 5000, ToolTipIcon.Info)
            End If

        End If





    End Sub




    Private Function TrySendTestEmail() As Boolean
        Try
            ' Validierung der Eingaben
            If String.IsNullOrWhiteSpace(TXB_SMTP.Text) Then Throw New ArgumentException("SMTP-Server darf nicht leer sein.")
            If CDbl(TXB_Port.Text) <= 0 Then Throw New ArgumentException("Port muss eine gültige Zahl sein.")
            If String.IsNullOrWhiteSpace(TXB_LoginEmail.Text) OrElse String.IsNullOrWhiteSpace(TXB_password.Text) Then Throw New ArgumentException("Benutzername und Passwort dürfen nicht leer sein.")
            If String.IsNullOrWhiteSpace(TXB_SenderEmail.Text) OrElse Not TXB_SenderEmail.Text.Contains("@") Then Throw New ArgumentException("Ungültige Absender-E-Mail-Adresse.")



            ' E-Mail-Nachricht erstellen
            Dim mail As New System.Net.Mail.MailMessage()
            mail.From = New System.Net.Mail.MailAddress(TXB_SenderEmail.Text, TXB_SenderDisplayName.Text)
            mail.To.Add("autodatenbanktest@lfdev.de")
            mail.Subject = "Test-E-Mail"
            mail.Body = "Dies ist eine Test-E-Mail, um die SMTP-Verbindung zu überprüfen."
            mail.IsBodyHtml = False

            ' SMTP-Client konfigurieren
            Dim smtp As New System.Net.Mail.SmtpClient(TXB_SMTP.Text, CInt(TXB_Port.Text))
            smtp.Credentials = New System.Net.NetworkCredential(TXB_LoginEmail.Text, TXB_password.Text)
            smtp.EnableSsl = CB_SSL.Checked

            ' Test-E-Mail senden
            smtp.Send(mail)
            Return True
        Catch ex As Exception
            ' Fehler abfangen und anzeigen
            MsgBox($"Fehler beim Senden der Test-E-Mail: {ex.Message} {ex.StackTrace}", MsgBoxStyle.Critical, "Fehler")
            Return False
        End Try
    End Function
End Class