Imports MySqlConnector

Public Class NewCustomer

    Private Function SearchForName(Key As String) As Boolean
        Using connection As New MySqlConnection(My.Settings.connectionstring)
            Try
                connection.Open()
                Dim query As String = "SELECT * FROM Kunden WHERE Name = @Name"
                Using command As New MySqlCommand(query, connection)
                    command.Parameters.AddWithValue("@Name", Key)
                    Using reader As MySqlDataReader = command.ExecuteReader()
                        If reader.Read() Then
                            Return True ' Kunde gefunden
                        Else
                            Return False ' Kunde nicht gefunden
                        End If
                    End Using
                End Using
            Catch ex As Exception
                MsgBox("Fehler bei der Suche: " & ex.Message, MsgBoxStyle.Critical)
                SavetoLogFile(ex.Message, "SearchForName")
                Return False
            End Try
        End Using
    End Function

    Private Sub NewCustomer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadOverallSettings()
    End Sub

    Private Sub BTN_Save_Click(sender As Object, e As EventArgs) Handles BTN_Save.Click
        If TXB_Name.Text.Length > 3 Then
            Dim kundeVorhanden As Boolean = SearchForName(TXB_Name.Text)

            If kundeVorhanden Then
                ' Kunde existiert bereits
                Dim result As DialogResult = MessageBox.Show("Kunde schon vorhanden trotzdem erstellen?", "Kunde gefunden", MessageBoxButtons.YesNo)
                If result = Windows.Forms.DialogResult.No Then
                    Exit Sub
                End If
            End If

            ' Erstellen Sie den Kunden
            Dim con As New MySqlConnection(My.Settings.connectionstring)
            Try
                con.Open()
                Dim query As String = "INSERT INTO Kunden (Name, Straße, Plz, Ort, Telefonnummer, Email, Erstellt) VALUES (@Name, @Straße, @Plz, @Ort, @Telefonnummer, @Email, @Erstellt)"
                Dim cmd As New MySqlCommand(query, con)

                cmd.Parameters.AddWithValue("@Name", TXB_Name.Text)
                cmd.Parameters.AddWithValue("@Straße", TXB_Street.Text)
                cmd.Parameters.AddWithValue("@Plz", TXB_ZIP.Text)
                cmd.Parameters.AddWithValue("@Ort", TXB_City.Text)
                cmd.Parameters.AddWithValue("@Telefonnummer", TXB_Fon.Text)
                cmd.Parameters.AddWithValue("@Email", TXB_Email.Text)
                cmd.Parameters.AddWithValue("@Erstellt", DateTime.Now)

                cmd.ExecuteNonQuery()

                MsgBox("Kunde erfolgreich angelegt", Title:="Erfolgreich angelegt")
            Catch ex As Exception
                MsgBox("Fehler beim Anlegen des Kunden: " & ex.Message, MsgBoxStyle.Critical, Title:="Fehler beim Anlegen")
                SavetoLogFile(ex.Message, "CreateNewCustomer")
            Finally
                con.Close()
            End Try
        Else
            MsgBox("Bitte Vor- und Nachnamen eingeben", MsgBoxStyle.Information)
        End If
    End Sub

End Class