Imports MySqlConnector

Public Class NewPassword
    Dim userid As String
    Private Sub NewPassword_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub


    Public Sub GetData(id As String, username As String)
        userid = id
        Label1.Text = "Herzlich Willkommen " & username & "," & vbNewLine & "Sie haben sich erfolgreich mit Ihrem OneTimePassword angemeldet." & vbNewLine & "Bitte legen Sie jetzt Ihr neues Individuelles Passwort an."
    End Sub

    Private Sub LL_ShowPassword_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LL_ShowPassword.LinkClicked
        If TXB_Password.PasswordChar = "*"c Then
            TXB_Password.PasswordChar = ControlChars.NullChar
            TXB_PasswordRepeat.PasswordChar = ControlChars.NullChar
            LL_ShowPassword.Text = "Verdecken"
        Else
            TXB_Password.PasswordChar = "*"c
            TXB_PasswordRepeat.PasswordChar = "*"c
            LL_ShowPassword.Text = "Anzeigen"

        End If
    End Sub

    Private Sub BTN_Login_Click(sender As Object, e As EventArgs) Handles BTN_Login.Click
        If TXB_Password.Text.Length < 3 Then
            MsgBox("Passwort muss mindestens 4 zeichen enthalten")
        Else
            If Not TXB_Password.Text = TXB_PasswordRepeat.Text Then
                MsgBox("Passwörter stimmen nicht überein")
            Else
                SaveNewPassword(TXB_Password.Text)
            End If
        End If
    End Sub


    Private Sub SaveNewPassword(password As String)
        Dim passwordResult As PasswordHashResult = PasswordHelper.HashPassword(password)


        Dim query As String = "UPDATE users SET password = @Password, salt = @Salt, passdate = @Passdate, otp = @OTP WHERE id = @UserID"
        Dim con As New MySqlConnection(My.Settings.connectionstring)
        con.Open()
        Using cmd As New MySqlCommand(query, con)
            cmd.Parameters.AddWithValue("@Password", passwordResult.HashedPassword)
            cmd.Parameters.AddWithValue("@Salt", passwordResult.Salt)
            cmd.Parameters.AddWithValue("@Passdate", Now.Date)
            cmd.Parameters.AddWithValue("@OTP", 0)
            cmd.Parameters.AddWithValue("@UserID", userid)
            Try
                Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
                If rowsAffected > 0 Then
                    MsgBox("Passwort wurde erfolgreich geändert")
                    Autodatenbank.Show()
                    Me.Close()
                Else
                    MsgBox("Fehler beim ändern des Passwortes, bitte Administrator kontaktieren")

                End If
            Catch ex As Exception
                MsgBox("Fehler beim ändern des Passwortes, bitte Administrator kontaktieren")
                SavetoLogFile(ex.Message, "ChangePassword")
            End Try

        End Using
    End Sub


End Class