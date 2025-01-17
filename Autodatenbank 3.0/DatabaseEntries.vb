Imports MySqlConnector

Public Class DatabaseEntries

    Private Sub SaveNewEntry(type As String)
        Dim typeofEntry As String = ""
        Dim EditorofEntry As String = ""
        If Autodatenbank.LoginSetting = True Then
            EditorofEntry = Autodatenbank.UID
        Else
            EditorofEntry = "0"
        End If

        Try
            Using connection As New MySqlConnection(My.Settings.connectionstring)
                connection.Open()
                Dim query As String = ""
                Select Case True
                    Case CBB_TypeOfEntry.SelectedItem.ToString = "Wartung"
                        typeofEntry = "Service/Wartung"
                        query = "INSERT INTO Service (ID_Kennzeichen, Bezeichnung, Kilometer, Datum, Preis, Kommentar, Art, Bearbeiter) VALUES (@Data1, @Data2, @Data3, @Data4, @Data5, @Data6, @Data7, @Data8)"
                    Case CBB_TypeOfEntry.SelectedItem.ToString = "Reparatur"
                        typeofEntry = "Reparatur"
                        query = "INSERT INTO Reparatur (ID_Kennzeichen, Bezeichnung, Kilometer, Datum, Preis, Kommentar, Art, Bearbeiter) VALUES (@Data1, @Data2, @Data3, @Data4, @Data5, @Data6, @Data7, @Data8)"
                    Case CBB_TypeOfEntry.SelectedItem.ToString = "Sonstiges"
                        typeofEntry = "Sonstiges"
                        query = "INSERT INTO Sonstiges (ID_Kennzeichen, Bezeichnung, Kilometer, Datum, Preis, Kommentar, Art, Bearbeiter) VALUES (@Data1, @Data2, @Data3, @Data4, @Data5, @Data6, @Data7, @Data8)"
                End Select
                If Not String.IsNullOrEmpty(query) Then
                    Using command As New MySqlCommand(query, connection)
                        command.Parameters.AddWithValue("@Data1", Autodatenbank.Licenseplate)
                        command.Parameters.AddWithValue("@Data2", TXB_Description.Text)
                        command.Parameters.AddWithValue("@Data3", TXB_Mileage.Text)
                        command.Parameters.AddWithValue("@Data4", TXB_Date.Text)
                        command.Parameters.AddWithValue("@Data5", TXB_Price.Text)
                        command.Parameters.AddWithValue("@Data6", RTB_Comment.Text)
                        command.Parameters.AddWithValue("@Data7", typeofEntry)
                        command.Parameters.AddWithValue("@Data8", EditorofEntry)
                        command.ExecuteNonQuery()
                    End Using

                    MessageBox.Show("Daten wurden erfolgreich in die Datenbank eingefügt.")
                    Autodatenbank.dgv.Rows.Clear()
                    Autodatenbank.FillDGV()
                    Me.Close()
                Else
                    MsgBox("Fehler beim Einfügen der Daten")
                End If

            End Using
        Catch ex As Exception
            Notify(Autodatenbank.NI_Error, "Fehler beim einfügen der Daten", ex.Message.ToString, 10000, ToolTipIcon.Error)
            SavetoLogFile(ex.Message, "SaveNewEntry")
        End Try

    End Sub

    Private Sub SaveEditEntry()
        Dim connection As New MySqlConnection(My.Settings.connectionstring)
        Dim location As String = ""
        Dim tabelname As String = ""
        Dim EditorofEntry As String = ""
        If Autodatenbank.LoginSetting = True Then
            EditorofEntry = Autodatenbank.UID
        Else
            EditorofEntry = "0"
        End If

        Select Case True
            Case CBB_TypeOfEntry.SelectedIndex = 0
                location = "ID_Service"
                tabelname = "Service"
            Case CBB_TypeOfEntry.SelectedIndex = 1
                location = "ID_Reparatur"
                tabelname = "Reparatur"
            Case CBB_TypeOfEntry.SelectedIndex = 2
                location = "ID_Sonstiges"
                tabelname = "Sonstiges"
        End Select

        Try
            connection.Open()

            Dim primaryKeyValue As String = Autodatenbank.EntryID.ToString
            Dim newValue1 As String = TXB_Description.Text
            Dim newValue2 As String = TXB_Mileage.Text
            Dim newValue4 As String = TXB_Date.Text
            Dim newValue5 As String = TXB_Price.Text
            Dim newValue6 As String = RTB_Comment.Text
            Dim newValue7 As String = EditorofEntry

            Dim query As String = "UPDATE " & tabelname & " SET Bezeichnung = @NewValue1, Kilometer = @NewValue2, Datum = @NewValue4, Preis = @NewValue5, Kommentar = @NewValue6, Bearbeiter =@NewValue7  WHERE " & location & " = @PrimaryKeyValue"

            Using cmd As New MySqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@NewValue1", newValue1)
                cmd.Parameters.AddWithValue("@NewValue2", newValue2)
                cmd.Parameters.AddWithValue("@NewValue4", newValue4)
                cmd.Parameters.AddWithValue("@NewValue5", newValue5)
                cmd.Parameters.AddWithValue("@NewValue6", newValue6)
                cmd.Parameters.AddWithValue("@NewValue7", newValue7)
                cmd.Parameters.AddWithValue("@PrimaryKeyValue", primaryKeyValue)
                Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

                If rowsAffected > 0 Then
                    Notify(Autodatenbank.NI_Successful, "Erfolg", "Daten wurden erfolgreich gespeichert", 5000, ToolTipIcon.None)
                    Autodatenbank.dgv.Rows.Clear()
                    Autodatenbank.FillDGV()

                    Me.Close()
                Else
                    MsgBox("Fehler beim Speichern.")
                End If
            End Using
        Catch ex As Exception
            Notify(Autodatenbank.NI_Error, "Fehler beim Speichern der Daten", ex.Message.ToString, 10000, ToolTipIcon.Error)
            SavetoLogFile(ex.Message, "SaveEditEntry")
        Finally
            connection.Close()
        End Try

    End Sub

    Private Sub DatabaseEntries_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadOverallSettings()
        LBL_Licenseplate.Text = Autodatenbank.Licenseplate
    End Sub

    Private Sub TXB_Description_TextChanged(sender As Object, e As EventArgs) Handles TXB_Description.TextChanged

    End Sub

    Private Sub BTN_Save_Click(sender As Object, e As EventArgs) Handles BTN_Save.Click
        Dim eurosymbol As String = "€"
        Dim text As String = TXB_Price.Text

        Dim euroIndex As Integer = text.IndexOf(eurosymbol)

        If euroIndex >= 0 Then
            Dim newtext As String = text.Remove(euroIndex, text.Length - euroIndex)
            TXB_Price.Text = newtext
        End If

        If TXB_Description.Text.Length < 2 Then
            MsgBox("Bezeichnung muss mindestens 3 zeichen haben")
        Else

            If CBB_TypeOfEntry.Enabled = True Then

                If CBB_TypeOfEntry.SelectedIndex > -1 Then
                    SaveNewEntry(CBB_TypeOfEntry.SelectedItem.ToString)
                Else
                    MsgBox("Bitte Art des Eintrags auswählen")
                End If
            Else
                SaveEditEntry()

            End If
        End If
    End Sub

    Private Sub LL_Today_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LL_Today.LinkClicked
        TXB_Date.Text = DateTime.Now.ToString("dd.MM.yyyy")
    End Sub
End Class