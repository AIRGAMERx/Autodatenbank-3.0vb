Imports MySqlConnector
Imports Sydesoft.NfcDevice
'PermissionKey entschluesseln

'1 Benutzer anlegen
'2 Benutzer bearbeiten
'3 Benutzer löschen
'4 Einträge erstellen
'5 Einträge bearbeiten
'6 Einträge löschen
'7 Einstellungen der Anwendung verändern
'8 Datein hochladen
'9 Datein öffnen
'10 Datein löschen
'11 Neues Auto anlegen
'12 Einträge drucken
Public Class NewUser
    Private Shared acr122u As New Sydesoft.NfcDevice.ACR122U
    Private Sub NewUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadOverallSettings()
        LoadSavedPermissionRole()

        If My.Settings.NFCVerify = False Then
            GB_NFC.Enabled = False
        Else
            GB_NFC.Enabled = True
        End If






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
        If FreeUID(uid) = False Then
            MsgBox("Dieser NFC Transponder ist schon in Benutzung, bitte anderen nehmen", MsgBoxStyle.Information)

        End If

    End Sub


    Private Sub Acr122u_CardRemoved()

        InvokeReq(TXB_UID, "")
        InvokeReq(TXB_UserName, "")


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


    Private Function Generate_ID() As Integer
        Dim rnd As New Random()
        Dim ID As Integer = rnd.Next(10000000, 99999999)

        If SearchFreeID(ID.ToString()) Then
            Return ID
        Else
            Return Generate_ID()
        End If
    End Function



    Private Function SearchFreeID(Key As String) As Boolean
        Using connection As New MySqlConnection(My.Settings.connectionstring)
            Try
                connection.Open()
                Dim query As String = "SELECT * FROM users WHERE id = @ID"
                Using command As New MySqlCommand(query, connection)
                    command.Parameters.AddWithValue("@ID", Key)
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

    Private Function FreeUsername(Username As String) As Boolean
        Using connection As New MySqlConnection(My.Settings.connectionstring)
            Try
                connection.Open()
                Dim query As String = "SELECT * FROM users WHERE user_name = @username"
                Using command As New MySqlCommand(query, connection)
                    command.Parameters.AddWithValue("@username", Username)
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

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        If TXB_Password.PasswordChar = "*" Then
            TXB_Password.PasswordChar = Nothing
            TXB_PasswordRepeat.PasswordChar = Nothing
            LinkLabel1.Text = "Verdecken"
        Else
            TXB_Password.PasswordChar = "*"c
            TXB_PasswordRepeat.PasswordChar = "*"c
            LinkLabel1.Text = "Anzeigen"
        End If

    End Sub

    Private Sub BTN_Save_Click(sender As Object, e As EventArgs) Handles BTN_Save.Click
        If TXB_UserName.Text.Length > 2 Then
            If FreeUsername(TXB_UserName.Text) = True Then
                If TXB_Password.Text = TXB_PasswordRepeat.Text And TXB_Password.Text.Length >= 4 Then

                    Dim PermissionRole As String = cbb_PermissionRole.SelectedItem.ToString
                    Dim ID As Integer = Generate_ID()

                    ' Hashen des Passworts und Erhalt von Salt und Hash
                    Dim passwordResult As PasswordHashResult = PasswordHelper.HashPassword(TXB_Password.Text)

                    Dim UID As String = If(CB_NFC.Checked And TXB_UID.Text.Length > 5, TXB_UID.Text, String.Empty)
                    If FreeUID(UID) = True And CB_NFC.Checked Or CB_NFC.Checked = False Then

                        Dim connection As New MySqlConnection(My.Settings.connectionstring)

                        Try
                            connection.Open()
                            ' Anpassung der SQL-Anweisung, um Salt und Hash getrennt zu speichern
                            Dim query As String = "INSERT INTO users(id, user_name, PermissionRole, UID, password, salt, Passdate) VALUES (@ID, @user_name, @PermissionRole, @UID, @Password, @Salt, @Passdate)"
                            Using cmdInsert As New MySqlCommand(query, connection)
                                cmdInsert.Parameters.AddWithValue("@ID", ID)
                                cmdInsert.Parameters.AddWithValue("@user_name", TXB_UserName.Text)
                                cmdInsert.Parameters.AddWithValue("@PermissionRole", PermissionRole)
                                cmdInsert.Parameters.AddWithValue("@UID", UID)
                                cmdInsert.Parameters.AddWithValue("@Password", passwordResult.HashedPassword)
                                cmdInsert.Parameters.AddWithValue("@Salt", passwordResult.Salt)
                                cmdInsert.Parameters.AddWithValue("@Passdate", Now.Date)
                                cmdInsert.ExecuteNonQuery()
                            End Using

                            connection.Close()
                            MsgBox("Benutzer wurde erfolgreich angelegt", MsgBoxStyle.Information, Title:="Benutzer angelegt")
                            Me.Close()
                        Catch ex As Exception
                            MsgBox("Fehler beim Anlegen des Benutzers: " & ex.Message)
                            SavetoLogFile(ex.Message, "CreateNewUser")
                        End Try
                    Else
                        MsgBox("Dieser NFC Transponder ist schon in Benutzung, bitte anderen nehmen", MsgBoxStyle.Information)
                    End If
                Else
                    MsgBox("Passwörter stimmen nicht überein")
                End If
            Else
                MsgBox("Benutzername schon vergeben," & vbNewLine & "bitte anderen Benutzernamen eingeben", MsgBoxStyle.Information)
            End If
        Else
            MsgBox("Gültigen Namen eingeben." & vbNewLine & "Mindestens 3 Zeichen")
        End If


    End Sub
End Class


