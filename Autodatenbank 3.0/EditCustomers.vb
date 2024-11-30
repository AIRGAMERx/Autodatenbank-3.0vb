Imports MySqlConnector

Public Class EditCustomers

    Private Sub EditCustomers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadOverallSettings()

        CBB_Customer.Items.Clear()

        Dim query As String = "SELECT ID, Name FROM Kunden"

        Using connection As New MySqlConnection(My.Settings.connectionstring)
            Using command As New MySqlCommand(query, connection)
                Try
                    connection.Open()
                    Using reader As MySqlDataReader = command.ExecuteReader()
                        While reader.Read()
                            Try
                                Dim userName As String = reader("Name").ToString()
                                Dim ID As String = reader("ID").ToString()

                                Dim item As New ComboBoxItemEditUser(userName, ID)
                                CBB_Customer.Items.Add(item)
                            Catch ex As Exception
                                MsgBox("Fehler beim Verarbeiten der Daten: " & ex.Message)
                            End Try
                        End While
                    End Using

                    ' Überprüfen Sie, ob CustomID gesetzt ist und wählen Sie den entsprechenden Kunden aus
                    If Autodatenbank.CustomID <> 0 Then
                        For Each item As ComboBoxItemEditUser In CBB_Customer.Items
                            If item.ID = Autodatenbank.CustomID.ToString() Then
                                CBB_Customer.SelectedItem = item
                                Exit For
                            End If
                        Next
                    End If
                Catch ex As Exception
                    MsgBox("Fehler beim Laden der Benutzernamen: " & ex.Message)
                    SavetoLogFile(ex.Message, "EditCustomerLoad")
                End Try
            End Using
        End Using
    End Sub

    Private Sub CBB_Customer_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBB_Customer.SelectedIndexChanged
        If CBB_Customer.SelectedIndex > -1 Then
            Dim selectedItem As ComboBoxItemEditUser = CType(CBB_Customer.SelectedItem, ComboBoxItemEditUser)
            Dim userName As String = selectedItem.UserName
            Dim userID As String = selectedItem.ID

            Try
                Using con As New MySqlConnection(My.Settings.connectionstring)
                    con.Open()
                    Dim query As String = "SELECT Straße, Plz, Ort, Telefonnummer, Email  FROM Kunden WHERE ID = @ID"
                    Using command As New MySqlCommand(query, con)
                        command.Parameters.AddWithValue("@ID", userID)

                        Using reader As MySqlDataReader = command.ExecuteReader()
                            While reader.Read()
                                TXB_Street.Text = reader("Straße").ToString
                                TXB_ZIP.Text = reader("Plz").ToString
                                TXB_City.Text = reader("Ort").ToString
                                TXB_Fon.Text = reader("Telefonnummer").ToString
                                TXB_Email.Text = reader("Email").ToString
                            End While
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                MsgBox("Fehler beim Laden der Daten: " & ex.Message)
                SavetoLogFile(ex.Message, "SelectCustomer")
            End Try
        End If

    End Sub

    Private Sub BTN_Save_Click(sender As Object, e As EventArgs) Handles BTN_Save.Click
        Dim con As New MySqlConnection(My.Settings.connectionstring)

        Dim selectedItem As ComboBoxItemEditUser = CType(CBB_Customer.SelectedItem, ComboBoxItemEditUser)
        If selectedItem Is Nothing Then
            MsgBox("Bitte wählen Sie einen Benutzernamen aus.")
            Exit Sub
        End If

        Dim userName As String = selectedItem.UserName
        Dim userID As String = selectedItem.ID

        Dim query As String = "UPDATE Kunden SET Straße = @Straße, Plz = @Plz, Ort = @Ort, Telefonnummer = @Telefonnummer, Email = @Email WHERE ID = @UserID"

        Using cmd As New MySqlCommand(query, con)
            cmd.Parameters.AddWithValue("@Straße", TXB_Street.Text)
            cmd.Parameters.AddWithValue("@Plz", TXB_ZIP.Text)
            cmd.Parameters.AddWithValue("@Ort", TXB_City.Text)
            cmd.Parameters.AddWithValue("@Telefonnummer", TXB_Fon.Text)
            cmd.Parameters.AddWithValue("@Email", TXB_Email.Text)
            cmd.Parameters.AddWithValue("@UserID", userID)

            Try
                con.Open()
                Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
                If rowsAffected > 0 Then
                    MsgBox("Kunde erfolgreich aktualisiert.")
                    Me.Close()
                Else
                    MsgBox("Kein Kunde mit dieser ID gefunden.")
                End If
            Catch ex As MySqlException
                MsgBox("Fehler bei der Aktualisierung der Benutzerdaten: " & ex.Message)
                SavetoLogFile(ex.Message, "SaveEditCustomer")
            Finally
                con.Close()
            End Try
        End Using
    End Sub

    Private Sub BTN_DeleteUser_Click(sender As Object, e As EventArgs) Handles BTN_DeleteUser.Click
        Select Case MessageBox.Show(CBB_Customer.SelectedItem.ToString & " wirklich Löschen", "Kunde Löschen?", MessageBoxButtons.YesNo)
            Case Windows.Forms.DialogResult.Yes
                DeleteCustomer()
            Case Windows.Forms.DialogResult.No

        End Select
    End Sub
    Private Sub DeleteCustomer()
        Dim selectedItem As ComboBoxItemEditUser = CType(CBB_Customer.SelectedItem, ComboBoxItemEditUser)
        If selectedItem Is Nothing Then
            MsgBox("Bitte wählen Sie einen Benutzernamen aus.")
            Exit Sub
        End If


        Dim ID As Integer = CInt(selectedItem.ID)
        Dim query As String = "DELETE FROM Kunden WHERE ID = @ID"


        Try
            Using conn As New MySqlConnection(My.Settings.connectionstring)
                conn.Open()

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@ID", ID)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            EditCustomers_Load(Nothing, EventArgs.Empty)
            Notify(Autodatenbank.NI_Successful, "Erfolg", "Kunde wurde erfolgreich gelöscht", 3000, ToolTipIcon.None)



        Catch ex As Exception
            SavetoLogFile(ex.Message, "DeleteCustomer")
            Notify(Autodatenbank.NI_Error, "Fehler", "Fehler beim löschen der Kundendaten: " & ex.Message, 10000, ToolTipIcon.None)
        End Try








    End Sub



End Class