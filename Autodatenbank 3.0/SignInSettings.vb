﻿Imports System.ComponentModel
Imports MySqlConnector


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
'


Public Class SigninSettings
    Dim CreateNewRole As Boolean = False
    Dim SelectetRoleName As String = ""
    Private Shared acr122u As New Sydesoft.NfcDevice.ACR122U

    Private Sub SignInSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadOverallSettings()
        LoadPermissionTable()

        If CheckExistTableUsers("users") Then
            CB_SignActive.Checked = True
        End If


        If My.Settings.RememberLogin = True Then
            CB_RememberLogin.Checked = True
        End If


        If My.Settings.SmartphoneVerify = True Then
            CB_SmartphoneSignIn.Checked = True
            BTN_OpenSmartphoneVerification.Enabled = True
        Else
            CB_SmartphoneSignIn.Checked = False
            BTN_OpenSmartphoneVerification.Enabled = False
        End If

        If My.Settings.OldPassword = True Then
            cb_CheckOldPass.Checked = True
        Else
            cb_CheckOldPass.Checked = False
        End If

        TT_Info(CB_SignActive, "Anmeldung", "Wenn die Anmeldung aktiviert ist, wird jeder Eintrag, der gemacht wird, in der Datenbank dokumentiert. Dafür müssen für jeden Benutzer Benutzerkonten vom Administrator eingerichtet werden." & vbNewLine & "Wenn die Anmeldung deaktiviert ist, ist keine Anmeldung notwendig, aber es wird auch kein Bearbeiter des Eintrags dokumentiert.")

        TT_Info(CB_SmartphoneSignIn, "Anmeldung mit Smartphone", "Bei Aktivierung dieser Funktion kann sich der Benutzer, wenn sein Smartphone mit der Autodatenbank-App verbunden ist, ohne Passwort per QR-Code oder Einmalpasswort anmelden.")

        TT_Info(CB_NFCVerify, "Anmeldung mit NFC-Transponder", "Bei Aktivierung dieser Funktion kann sich der Benutzer mit dem für ihn verbundenen NFC-Transponder anmelden.")

        TT_Info(CB_RememberLogin, "Angemeldet bleiben", "Bei Aktivierung dieser Funktion wird der Benutzer nicht automatisch beim Beenden der Anwendung abgemeldet." & vbNewLine & "Dies wird nur bei Computern empfohlen, die alleine benutzt werden.")

        TT_Info(cb_CheckOldPass, "Passworterinnerung", "Bei Aktivierung dieser Funktion wird der Benutzer darauf aufmerksam gemacht, wenn das Passwort länger als 6 Monate nicht geändert wurde, ein neues zu erstellen.")

    End Sub






    Public Sub FillFlowLayoutPanel(Name As String, Key As String)
        ' Erstellt ein neues TableLayoutPanel mit 2 Spalten
        Dim rolePanel As New TableLayoutPanel()
        rolePanel.ColumnCount = 2
        rolePanel.RowCount = 1
        rolePanel.Dock = DockStyle.Top
        rolePanel.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100)) ' 100% für die erste Spalte (Name)
        rolePanel.ColumnStyles.Add(New ColumnStyle(SizeType.AutoSize)) ' AutoSize für die zweite Spalte (Button)
        rolePanel.AutoSize = True
        rolePanel.Margin = New Padding(5) ' Abstand zwischen den Panels

        ' Speichert die Rolle und den Key im Tag des Panels
        rolePanel.Tag = New PermissonsRole With {.RoleName = Name, .Key = Key}

        ' Erstellt ein Label für den Rollennamen
        Dim roleNameLabel As New Label()
        roleNameLabel.Text = Name
        roleNameLabel.Font = New Font("Microsoft Sans Serif", 10)
        roleNameLabel.AutoSize = True
        roleNameLabel.Anchor = AnchorStyles.Left ' Verankert das Label links
        roleNameLabel.Cursor = Cursors.Hand ' Cursor ändert sich zu einer Hand, wenn man über den Text hovert
        AddHandler roleNameLabel.Click, AddressOf RolePanel_Click ' Ereignishandler für den Klick des Namens

        ' Erstellt eine Schaltfläche zum Löschen (X-Icon)
        Dim deleteButton As New Button()
        deleteButton.Text = "X"
        deleteButton.Size = New Size(25, 25)
        deleteButton.BackColor = Color.Red
        deleteButton.ForeColor = Color.White
        deleteButton.FlatStyle = FlatStyle.Flat
        deleteButton.FlatAppearance.BorderSize = 0
        deleteButton.Anchor = AnchorStyles.Right ' Verankert den Button rechts
        deleteButton.Cursor = Cursors.Hand ' Cursor ändert sich zu einer Hand, wenn man über die Schaltfläche hovert
        AddHandler deleteButton.Click, AddressOf RolePanel_Click ' Ereignishandler für den Klick des Lösch-Buttons

        ' Füge das Label und die Schaltfläche dem TableLayoutPanel hinzu
        rolePanel.Controls.Add(roleNameLabel, 0, 0)
        rolePanel.Controls.Add(deleteButton, 1, 0)

        ' Fügt das Panel zum FlowLayoutPanel hinzu
        FlowLayoutPanel1.FlowDirection = FlowDirection.TopDown ' Setze die Ausrichtung auf vertikal
        FlowLayoutPanel1.WrapContents = False ' Verhindere das Umbruch-Verhalten
        FlowLayoutPanel1.Controls.Add(rolePanel)
    End Sub

    ' Ereignishandler für den Klick auf die Löschen-Schaltfläche


    Private Sub RolePanel_Click(sender As Object, e As EventArgs)
        ' Greife auf das Panel zu, egal welches Steuerelement angeklickt wurde (Label oder Button)
        Dim rolePanel As Panel = DirectCast(DirectCast(sender, Control).Parent, Panel)

        ' Setze die Hintergrundfarbe aller Panels im FlowLayoutPanel zurück
        For Each ctrl As Control In FlowLayoutPanel1.Controls
            If TypeOf ctrl Is Panel Then
                DirectCast(ctrl, Panel).BackColor = FlowLayoutPanel1.BackColor ' Setze auf die Standardfarbe zurück
            End If
        Next

        ' Setze den Hintergrund des aktuell ausgewählten Panels auf LightGray
        rolePanel.BackColor = Color.LightGray

        ' Cast das Tag-Objekt des Panels zu PermissonsRole, um darauf zuzugreifen
        Dim roleInfo As PermissonsRole = DirectCast(rolePanel.Tag, PermissonsRole)

        ' CheckBoxen deaktivieren oder aktivieren, je nach Rolle
        If roleInfo.RoleName = "Administrator" Then
            For Each ctrl As Control In GB_Permission.Controls
                If TypeOf ctrl Is CheckBox Then
                    DirectCast(ctrl, CheckBox).Enabled = False
                End If
            Next
        Else
            For Each ctrl As Control In GB_Permission.Controls
                If TypeOf ctrl Is CheckBox Then
                    DirectCast(ctrl, CheckBox).Enabled = True
                End If
            Next
        End If

        ' Überprüfe, ob der Benutzer den Button oder das Label angeklickt hat
        If TypeOf sender Is Button Then
            ' Der Benutzer hat die Löschen-Schaltfläche geklickt

            If roleInfo.RoleName = "Administrator" Then
                Notify(Autodatenbank.NI_Error, "Fehler", "Die Rolle 'Administrator' kann nicht gelöscht werden", 5000, ToolTipIcon.Error)
                Return
            End If

            ' Bestätigungsdialog, um die Rolle zu löschen
            If MessageBox.Show($"Möchten Sie die Rolle '{roleInfo.RoleName}' wirklich löschen?", "Bestätigung", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                ' Hier füge deine SQL-Logik zum Löschen hinzu
                DeletePermissionRole(roleInfo.RoleName)

                ' Entferne das entsprechende Panel aus dem FlowLayoutPanel
                FlowLayoutPanel1.Controls.Remove(rolePanel)
            End If

        ElseIf TypeOf sender Is Label Then
            ' Der Benutzer hat das Label geklickt

            ' Setze die CheckBoxen basierend auf dem Key der Rolle
            SetCheckBoxesFromKey(roleInfo.Key)
            SelectetRoleName = roleInfo.RoleName
        End If
    End Sub
    Private Sub SetCheckBoxesFromKey(key As String)
        If key.Length <> 12 Then
            MsgBox("Ungültiger Schlüssel!")
            Exit Sub
        End If

        CB_CreateUser.Checked = (key(0) = "1")
        CB_EditUser.Checked = (key(1) = "1")
        CB_DeleteUser.Checked = (key(2) = "1")
        CB_CreateEntries.Checked = (key(3) = "1")
        CB_EditEntries.Checked = (key(4) = "1")
        CB_DeleteEntries.Checked = (key(5) = "1")
        CB_AdminPermission.Checked = (key(6) = "1")
        CB_UploadData.Checked = (key(7) = "1")
        CB_OpenData.Checked = (key(8) = "1")
        CB_DeleteData.Checked = (key(9) = "1")
        CB_CreateNewCar.Checked = (key(10) = "1")
        CB_Print.Checked = (key(11) = "1")


    End Sub

    Private Sub BTN_SaveEditRole_Click(sender As Object, e As EventArgs) Handles BTN_SaveEditRole.Click
        Dim key As String = CreatePermissionKey(CB_CreateUser.Checked, CB_EditUser.Checked, CB_DeleteUser.Checked, CB_CreateEntries.Checked, CB_EditEntries.Checked, CB_DeleteEntries.Checked, CB_AdminPermission.Checked, CB_UploadData.Checked, CB_OpenData.Checked, CB_DeleteData.Checked, CB_CreateNewCar.Checked, CB_Print.Checked)
        Dim connection As New MySqlConnection(My.Settings.connectionstring)

        Try
            connection.Open()

            Dim query As String = "UPDATE Berechtigungen SET `Key` = @Key WHERE Name = @RoleName"
            Using cmd As New MySqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@Key", key)
                cmd.Parameters.AddWithValue("@RoleName", SelectetRoleName)
                cmd.ExecuteNonQuery()
            End Using

            Notify(Autodatenbank.NI_Successful, "Erfolg", "Berechtigungsstufe wurde erfolgreich gespeichert", 3000, ToolTipIcon.None)

        Catch ex As Exception

        End Try


    End Sub

    Private Sub CB_SignActive_CheckedChanged(sender As Object, e As EventArgs) Handles CB_SignActive.CheckedChanged

        If CB_SignActive.Checked = True Then
            Dim userTableExist As Boolean = CheckExistTableUsers("users")
            Dim usersShotdownTableExist As Boolean = CheckExistTableUsers("users_shutdown")

            If userTableExist Or usersShotdownTableExist Then
                If usersShotdownTableExist Then
                    BootupTableUsers()
                End If
            Else
                CreateTableUsers()
            End If

        End If


        If CB_SignActive.Checked = False Then
            Dim userTableExist As Boolean = CheckExistTableUsers("users")
            If userTableExist Then
                ShutdownTableUsers()
            End If
        End If


    End Sub




    Private Sub SigninSettings_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Autodatenbank.EditData = False
    End Sub



    Private Sub CB_RememberLogin_CheckedChanged(sender As Object, e As EventArgs) Handles CB_RememberLogin.CheckedChanged
        If GetPermission(My.Settings.PermissionKey, 7) Then
            If CB_RememberLogin.Checked Then
                My.Settings.RememberLogin = True
            Else
                My.Settings.RememberLogin = False
            End If
            My.Settings.Save()
        Else
            MsgBox("Keine Berechtigung um Einstellungen der Anwendug zu verändern")
        End If

    End Sub

    Private Sub BTN_OpenSmartphoneVerification_Click(sender As Object, e As EventArgs) Handles BTN_OpenSmartphoneVerification.Click
        Smartphone_verification.Show()
    End Sub

    Private Sub CB_NFCVerify_CheckedChanged(sender As Object, e As EventArgs) Handles CB_NFCVerify.CheckedChanged
        My.Settings.NFCVerify = CB_NFCVerify.Checked
        My.Settings.Save()




    End Sub

    Private Sub CB_SmartphoneVerify_CheckedChanged(sender As Object, e As EventArgs) Handles CB_SmartphoneSignIn.CheckedChanged
        My.Settings.SmartphoneVerify = CB_SmartphoneSignIn.Checked
        My.Settings.Save()

        If CB_SmartphoneSignIn.Checked Then
            BTN_OpenSmartphoneVerification.Enabled = True
        Else
            BTN_OpenSmartphoneVerification.Enabled = False
        End If
    End Sub

    Private Sub cb_CheckOldPass_CheckedChanged(sender As Object, e As EventArgs) Handles cb_CheckOldPass.CheckedChanged
        My.Settings.OldPassword = cb_CheckOldPass.Checked
        My.Settings.Save()
    End Sub

    Private Sub BTN_NewUserSave_Click(sender As Object, e As EventArgs) 
        NewUser.Show()
    End Sub

    Private Sub BTN_EditUser_Click(sender As Object, e As EventArgs) 
        EditUser.Show()
    End Sub

    Private Sub TXB_NamePermissionRole_TextChanged(sender As Object, e As EventArgs) Handles TXB_NamePermissionRole.TextChanged

    End Sub

    Private Sub TXB_NamePermissionRole_GotFocus(sender As Object, e As EventArgs) Handles TXB_NamePermissionRole.GotFocus
        If CreateNewRole = False Then
            CreateNewRole = True

            For Each ctrl As Control In GB_Permission.Controls
                If TypeOf ctrl Is CheckBox Then
                    DirectCast(ctrl, CheckBox).Checked = False
                End If
            Next
        End If
        For Each ctrl As Control In GB_Permission.Controls
            If TypeOf ctrl Is CheckBox Then
                DirectCast(ctrl, CheckBox).Enabled = True
            End If
        Next
    End Sub

    Private Sub FlowLayoutPanel1_Paint(sender As Object, e As PaintEventArgs) Handles FlowLayoutPanel1.Paint

    End Sub

    Private Sub FlowLayoutPanel1_GotFocus(sender As Object, e As EventArgs) Handles FlowLayoutPanel1.GotFocus
        CreateNewRole = False
    End Sub

    Private Sub BTN_SavePermissionRole_Click(sender As Object, e As EventArgs) Handles BTN_SavePermissionRole.Click
        If CheckFreeRole(TXB_NamePermissionRole.Text) = True Then
            Dim key As String = CreatePermissionKey(CB_CreateUser.Checked, CB_EditUser.Checked, CB_DeleteUser.Checked, CB_CreateEntries.Checked, CB_EditEntries.Checked, CB_DeleteEntries.Checked, CB_AdminPermission.Checked, CB_UploadData.Checked, CB_OpenData.Checked, CB_DeleteData.Checked, CB_CreateNewCar.Checked, CB_Print.Checked)

            Dim connection As New MySqlConnection(My.Settings.connectionstring)

            Try
                connection.Open()

                Dim query As String = "INSERT INTO Berechtigungen(Name, `Key`) VALUES (@Name, @Key)"

                Using cmdInsert As New MySqlCommand(query, connection)
                    cmdInsert.Parameters.AddWithValue("@Name", TXB_NamePermissionRole.Text)
                    cmdInsert.Parameters.AddWithValue("@Key", key)
                    cmdInsert.ExecuteNonQuery()
                End Using

                connection.Close()
                LoadPermissionTable()
                TXB_NamePermissionRole.Text = ""
            Catch ex As Exception
                MsgBox("Fehler beim Erstellen der Berechtigungsstufe " & ex.Message)
                SavetoLogFile(ex.Message, "SavePermissionRole")
            End Try







        Else
            Notify(Autodatenbank.NI_Error, "Fehler", "Rollennamen können nur einmal verwendet werden", 5000, ToolTipIcon.Error)
        End If
    End Sub






    Private Sub FlowLayoutPanel1_LostFocus(sender As Object, e As EventArgs) Handles FlowLayoutPanel1.LostFocus

    End Sub

    Private Sub BTN_SaveLoginSettings_Click(sender As Object, e As EventArgs) Handles BTN_SaveLoginSettings.Click
        My.Settings.RememberLogin = CB_RememberLogin.Checked
        My.Settings.SmartphoneVerify = CB_SmartphoneSignIn.Checked
        My.Settings.NFCVerify = CB_NFCVerify.Checked
        My.Settings.OldPassword = cb_CheckOldPass.Checked
        My.Settings.Save()
        Notify(Autodatenbank.NI_Successful, "Erfolg", "Einstellungen wurden erfolgreich gespeichert", 3000, ToolTipIcon.None)

    End Sub
End Class


