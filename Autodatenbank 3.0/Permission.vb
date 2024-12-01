Imports MySqlConnector
'1 Benutzer anlegen
'2 Benutzer bearbeiten
'3 Benutzer löschen
'4 Einträge erstellen
'5 Einträge bearbeiten Auto infos gehören auch dazu
'6 Einträge löschen
'7 Einstellungen der Anwendung verändern
'8 Datein hochladen
'9 Datein öffnen
'10 Datein löschen
'11 Neues Auto anlegen Kunden gehören auch dazu
'12 Einträge drucken
Module Permission

    Public Sub LoadPermissionTable()
        AdminSettings.FlowLayoutPanel1.Controls.Clear()
        Dim connection As New MySqlConnection(My.Settings.connectionstring)

        Try
            connection.Open()

            Dim cmd As String = "SELECT * FROM Berechtigungen"

            Using cmdPermission As New MySqlCommand(cmd, connection)
                Using reader As MySqlDataReader = cmdPermission.ExecuteReader()

                    If reader.HasRows Then
                        While reader.Read()

                            Dim Role As New PermissonsRole With {
                            .RoleName = reader.GetString("Name"),
                            .Key = reader.GetString("Key")
                        }

                            AdminSettings.FillFlowLayoutPanel(Role.RoleName, Role.Key)
                        End While
                    End If

                End Using
            End Using

        Catch ex As Exception
            MsgBox(ex.Message)
            Notify(Autodatenbank.NI_Error, "Fehler", "Fehler beim Laden der Berechtigungstabelle" & vbNewLine & ex.Message, 5000, ToolTipIcon.Error)
            SavetoLogFile(ex.Message, "LoadPermissionTable")
        Finally
            connection.Close()
        End Try
    End Sub


    Public Sub DeletePermissionRole(RoleName As String)

        Dim connection As New MySqlConnection(My.Settings.connectionstring)

        Try
            connection.Open()

            Dim query As String = "DELETE FROM Berechtigungen WHERE Name = @Rolename"
            Using cmd As New MySqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@Rolename", RoleName)
                cmd.ExecuteNonQuery()
            End Using




        Catch ex As Exception
            Notify(Autodatenbank.NI_Error, "Fehler", "Fehler beim Löschen der Berechtigungsstufe " & vbNewLine & ex.Message, 5000, ToolTipIcon.Error)
        End Try

    End Sub

    Public Function GetPermission(Key As String, Index As Integer) As Boolean
        Dim permission As Char = Key(Index - 1)

        If permission = "1" Then
            Return True
        Else
            Return False
        End If



    End Function



    Public Function CheckFreeRole(Rolename As String) As Boolean
        Dim connection As New MySqlConnection(My.Settings.connectionstring)
        Try
            connection.Open()

            Dim query As String = "SELECT Name FROM Berechtigungen"
            Using cmd As New MySqlCommand(query, connection)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    ' Schleife, um alle Datensätze durchzugehen
                    While reader.Read()
                        If reader("Name").ToString().Equals(Rolename, StringComparison.InvariantCultureIgnoreCase) Then
                            ' Wenn der Name gefunden wird, gebe False zurück
                            Return False
                        End If
                    End While
                End Using
            End Using
            ' Wenn der Name nicht gefunden wird, gebe True zurück
            Return True
        Catch ex As Exception
            ' Fehlerbehandlung, gebe False zurück bei einem Fehler
            Return False
        Finally
            connection.Close()
        End Try
    End Function

    Public Function GetPermissionKeyFromRole(Role As String) As String
        Dim query As String = "SELECT `Key` FROM Berechtigungen WHERE Name = @RoleName LIMIT 1"

        Using connection As New MySqlConnection(My.Settings.connectionstring)
            ' Verbindung öffnen
            connection.Open()

            Using cmd As New MySqlCommand(query, connection)
                ' Parameter hinzufügen
                cmd.Parameters.AddWithValue("@RoleName", Role)

                ' Reader ausführen
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    ' Falls Daten vorhanden sind
                    If reader.Read() Then
                        ' Key prüfen und zurückgeben
                        Dim keyValue As String = reader.GetString("Key")
                        If Not String.IsNullOrEmpty(keyValue) Then
                            Return keyValue
                        End If
                    End If
                End Using
            End Using
        End Using

        ' Leeren String zurückgeben, falls kein Ergebnis
        Return String.Empty
    End Function

    Public Function CreatePermissionKey(createUser As Boolean, editUser As Boolean, deleteUser As Boolean, createEntries As Boolean, editEntries As Boolean, deleteEntries As Boolean, adminPermission As Boolean, UploadData As Boolean, OpenData As Boolean, DeleteData As Boolean, CreateNewCar As Boolean, PrintEntries As Boolean) As String
        Dim key As String = ""

        If createUser Then
            key &= "1"
        Else
            key &= "0"
        End If

        If editUser Then
            key &= "1"
        Else
            key &= "0"
        End If

        If deleteUser Then
            key &= "1"
        Else
            key &= "0"
        End If

        If createEntries Then
            key &= "1"
        Else
            key &= "0"
        End If

        If editEntries Then
            key &= "1"
        Else
            key &= "0"
        End If

        If deleteEntries Then
            key &= "1"
        Else
            key &= "0"
        End If

        If adminPermission Then
            key &= "1"
        Else
            key &= "0"
        End If

        If UploadData Then
            key &= "1"
        Else
            key &= "0"
        End If

        If OpenData Then
            key &= "1"
        Else
            key &= "0"
        End If

        If DeleteData Then
            key &= "1"
        Else
            key &= "0"
        End If

        If CreateNewCar Then
            key &= "1"
        Else
            key &= "0"
        End If

        If PrintEntries Then
            key &= "1"
        Else
            key &= "0"
        End If

        Return key
    End Function
End Module
Public Class PermissonsRole
    Public Property RoleName As String
    Public Property Key As String

End Class
