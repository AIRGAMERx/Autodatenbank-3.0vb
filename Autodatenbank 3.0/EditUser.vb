Imports MySqlConnector
Imports Sydesoft.NfcDevice

Public Class EditUser
    Dim NewPassword As Boolean = False
    Private Shared acr122u As New Sydesoft.NfcDevice.ACR122U

    Private Sub EditUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadOverallSettings()
        LoadSavedUser()
        LoadSavedPermissionRole()

    End Sub

    Private Sub LoadSavedUser()
        CBB_Username.Items.Clear()

        Dim query As String = "SELECT id, user_name FROM users"

        Using connection As New MySqlConnection(My.Settings.connectionstring)
            Using command As New MySqlCommand(query, connection)
                Try
                    connection.Open()
                    Using reader As MySqlDataReader = command.ExecuteReader()
                        While reader.Read()
                            Try

                                Dim userName As String = reader("user_name").ToString()
                                Dim ID As String = reader("id").ToString() ' ID als String behandeln

                                Dim item As New ComboBoxItemEditUser(userName, ID)
                                CBB_Username.Items.Add(item)
                            Catch ex As Exception
                                MsgBox("Fehler beim Verarbeiten der Daten: " & ex.Message)
                            End Try
                        End While
                    End Using
                Catch ex As Exception
                    MsgBox("Fehler beim Laden der Benutzernamen: " & ex.Message)
                    SavetoLogFile(ex.Message, "LoadSavedUser")
                End Try
            End Using
        End Using

    End Sub

    Private Sub LoadSavedPermissionRole()
        Dim query As String = "SELECT Name FROM Berechtigungen"

        Using Connection As New MySqlConnection(My.Settings.connectionstring)
            Using command As New MySqlCommand(query, Connection)
                Try
                    Connection.Open()
                    Using reader As MySqlDataReader = command.ExecuteReader
                        While reader.Read
                            cbb_PermissionRole.Items.Add(reader("Name").ToString)

                        End While
                    End Using
                Catch ex As Exception

                End Try
            End Using
        End Using

    End Sub

    Private Function FreeUID(Key As String) As Boolean
        Using connection As New MySqlConnection(My.Settings.connectionstring)
            Try
                connection.Open()
                Dim query As String = "SELECT * FROM users WHERE UID = @UID"
                Using command As New MySqlCommand(query, connection)
                    command.Parameters.AddWithValue("@UID", Key)
                    Using reader As MySqlDataReader = command.ExecuteReader()
                        If reader.Read() Then
                            Return False
                        Else
                            Return True
                        End If
                    End Using
                End Using
            Catch ex As Exception

                Return False
            End Try
        End Using

    End Function

    Private Sub CB_NFC_CheckedChanged(sender As Object, e As EventArgs) Handles CB_NFC.CheckedChanged
        If CB_NFC.Checked Then
            Try
                acr122u.Init(False, 50, 4, 4, 200) ' NTAG213
                AddHandler acr122u.CardInserted, AddressOf Acr122u_CardInserted
                AddHandler acr122u.CardRemoved, AddressOf Acr122u_CardRemoved
            Catch ex As Exception

            End Try
        Else

        End If
    End Sub

    Private Sub Acr122u_CardInserted(ByVal reader As PCSC.ICardReader)

        Dim uid As String = BitConverter.ToString(acr122u.GetUID(reader)).Replace("-", "")
        Zeigen(uid)

    End Sub

    Private Sub Acr122u_CardRemoved()
        'Finde dass dort kein Ereigniss nötig ist
    End Sub

    Private Sub Zeigen(ByVal text As String)
        If TXB_UID.InvokeRequired Then
            TXB_UID.Invoke(Sub() Zeigen(text))
        Else
            TXB_UID.Clear()
            TXB_UID.Text = text
        End If
    End Sub

    Private Sub InvokeReq(Control As Control, Text As String)
        If Control.InvokeRequired Then
            Control.Invoke(Sub() InvokeReq(Control, Text))
        Else
            Control.Text = Text
        End If
    End Sub

    Private Sub InvokeButton(control As Control, bool As Boolean)
        If control.InvokeRequired Then
            control.Invoke(Sub() InvokeButton(control, bool))
        Else
            control.Enabled = bool
        End If
    End Sub

    Private Sub CBB_Username_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBB_Username.SelectedIndexChanged
        If CBB_Username.SelectedIndex > -1 Then
            Dim selectedItem As ComboBoxItemEditUser = CType(CBB_Username.SelectedItem, ComboBoxItemEditUser)
            Dim userName As String = selectedItem.UserName
            Dim userID As String = selectedItem.ID

            Try
                Using con As New MySqlConnection(My.Settings.connectionstring)
                    con.Open()
                    Dim query As String = "SELECT PermissionRole, UID, email FROM users WHERE id = @ID"
                    Using command As New MySqlCommand(query, con)
                        command.Parameters.AddWithValue("@ID", userID)

                        Using reader As MySqlDataReader = command.ExecuteReader()
                            While reader.Read()
                                If cbb_PermissionRole.Items.Contains(reader("PermissionRole")) Then
                                    cbb_PermissionRole.SelectedItem = reader("PermissionRole")
                                Else
                                    cbb_PermissionRole.SelectedIndex = -1
                                End If

                                TXB_UID.Text = reader("UID").ToString()
                                TXB_Email.Text = reader("email").ToString
                            End While
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                MsgBox("Fehler beim Laden der Daten: " & ex.Message)
                SavetoLogFile(ex.Message, "SelectUsernameEditUser")
            End Try
        End If
    End Sub



    Private Sub BTN_Save_Click(sender As Object, e As EventArgs) Handles BTN_Save.Click

        If CB_NFC.Checked And FreeUID(TXB_UID.Text) = True Or CB_NFC.Checked = False Then


            Dim PermissionRole As String = cbb_PermissionRole.SelectedItem.ToString
                    Dim UID As String = TXB_UID.Text
                    Dim con As New MySqlConnection(My.Settings.connectionstring)

                    Dim selectedItem As ComboBoxItemEditUser = CType(CBB_Username.SelectedItem, ComboBoxItemEditUser)
                    If selectedItem Is Nothing Then
                        MsgBox("Bitte wählen Sie einen Benutzernamen aus.")
                        Exit Sub
                    End If

                    Dim userName As String = selectedItem.UserName
                    Dim userID As String = selectedItem.ID





            Dim query As String = "UPDATE users SET PermissionRole = @PermissionRole, uid = @UID, email = @Email WHERE id = @UserID"


            Using cmd As New MySqlCommand(query, con)
                        If NewPassword Then

                    cmd.Parameters.AddWithValue("@Passdate", Now.Date)
                        End If
                        cmd.Parameters.AddWithValue("@PermissionRole", PermissionRole)
                cmd.Parameters.AddWithValue("@UID", UID)
                cmd.Parameters.AddWithValue("@Email", TXB_Email.Text)
                cmd.Parameters.AddWithValue("@UserID", userID)

                        Try
                            con.Open()
                            Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
                            If rowsAffected > 0 Then
                                MsgBox("Benutzerdaten erfolgreich aktualisiert.")
                                Me.Close()
                            Else
                                MsgBox("Kein Benutzer mit dieser ID gefunden.")
                            End If
                        Catch ex As MySqlException
                            MsgBox("Fehler bei der Aktualisierung der Benutzerdaten: " & ex.Message)
                        Finally
                            con.Close()
                        End Try
                    End Using

        Else
                MsgBox("NFC Transponder schon in Benutzung, bitte anderen benutzen", MsgBoxStyle.Critical, Title:="Fehler bei NFC Transponder")
                TXB_UID.Clear()
            End If

    End Sub

    Private Sub BTN_SendOTP_Click(sender As Object, e As EventArgs) Handles BTN_SendOTP.Click
        If CBB_Username.SelectedIndex > -1 Then
            If String.IsNullOrEmpty(TXB_Email.Text) OrElse Not TXB_Email.Text.Contains("@") Then Throw New ArgumentException("Bite gültige Email-Adresse eingeben")
            Dim selectedItem As ComboBoxItemEditUser = CType(CBB_Username.SelectedItem, ComboBoxItemEditUser)
            Dim userName As String = selectedItem.UserName
            Dim userID As String = selectedItem.ID
            Dim otp As String = GetOTP()
            Dim passwordResult As PasswordHashResult = PasswordHelper.HashPassword(otp)
            If SendEmail(TXB_Email.Text, "Ihr OneTimePassword für die einmalige Anmeldung an der Autodatenbank", "Hallo " & userName & "," & vbNewLine & "Anbei erhalten Sie das OneTimePassword, dieses ist nur 1 stunde gültig" & vbNewLine & vbNewLine & "OneTimePassword: " & otp) = True Then
                Dim query As String = "UPDATE users SET otp = @otp, otp_date = @otp_date, password = @password, salt = @salt WHERE id = @ID"

                Using con As New MySqlConnection(My.Settings.connectionstring)
                    con.Open()

                    Using cmd As New MySqlCommand(query, con)
                        cmd.Parameters.AddWithValue("@otp", 1)
                        cmd.Parameters.AddWithValue("@otp_date", Now)
                        cmd.Parameters.AddWithValue("@password", passwordResult.HashedPassword)
                        cmd.Parameters.AddWithValue("@salt", passwordResult.Salt)
                        cmd.Parameters.AddWithValue("@ID", userID)
                        cmd.ExecuteNonQuery()
                        MsgBox("Das OneTimePasswort wurde per Email versendet")
                    End Using
                End Using
            End If


        Else
            MsgBox("Bitte Benutzername auswählen")
        End If
    End Sub
    Private Function GetOTP() As String
        Dim rnd As New Random
        Dim otp As String = rnd.Next(1, 99999999).ToString
        Return otp
    End Function
End Class

Public Class ComboBoxItemEditUser
    Public Property UserName As String
    Public Property ID As String

    Public Sub New(userName As String, id As String)
        Me.UserName = userName
        Me.ID = id
    End Sub

    Public Overrides Function ToString() As String
        Return Me.UserName
    End Function

End Class