Imports System.Net.WebRequestMethods

Module EmailHelper
    Public Function SendEmail(mailto As String, subject As String, body As String) As Boolean
        Dim password As String
        password = InputBox("Bitte gebe dein Passwort  für Email versand ein:", "Passwort-Eingabe")

        If String.IsNullOrWhiteSpace(password) Then
            MsgBox("Kein passwort angegeben bitte erneut eingeben")
            Return False
        End If
        Dim finalKey As String = GenerateKeyFromPassphrase(password)
        Dim settings As EmailSettings = LoadEmailSettings(finalKey)

        Try


            Dim mail As New System.Net.Mail.MailMessage()
            mail.From = New System.Net.Mail.MailAddress(settings.SenderEmail, settings.SenderDisplayName)
            mail.To.Add(mailto)
            mail.Subject = subject
            mail.Body = body
            mail.IsBodyHtml = False


            Dim smtp As New System.Net.Mail.SmtpClient(settings.SmtpServer, settings.Port)
            smtp.Credentials = New System.Net.NetworkCredential(settings.Username, settings.Password)
            smtp.EnableSsl = settings.EnableSsl

            smtp.Send(mail)
            Return True
        Catch ex As Exception
            MsgBox($"Fehler beim Senden der E-Mail: {ex.Message} {ex.StackTrace}", MsgBoxStyle.Critical, "Fehler")
            SavetoLogFile(ex.Message & ex.StackTrace, "Send Email")
            Return False
        End Try


    End Function






End Module
