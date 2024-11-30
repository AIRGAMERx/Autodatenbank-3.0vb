Imports MySqlConnector

Public Class PR
    Dim designation As New List(Of String)
    Dim lastPrnumber As String = ""

    Private Sub PR_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadOverallSettings()
        LoadSavedCars()

    End Sub
    Private Sub BTN_Search_Click(sender As Object, e As EventArgs) Handles BTN_Search.Click
        If TXB_PrNumbers.Text.Length > 0 Then
            TXB_PrNumbers.Text = TXB_PrNumbers.Text.ToUpper
        End If

        If TXB_PrNumbers.Text.Contains(";") Then
            GetMultiNumber()
        Else
            GetSingleNumber()
        End If

    End Sub


    Private Async Sub GetSingleNumber()
        LB_Designation.Items.Clear()

        If TXB_PrNumbers.Text.Length > 0 Then

            Dim prNumber As String = TXB_PrNumbers.Text

            Dim designation As List(Of String) = Await GETPrDesignation(prNumber)

            If designation IsNot Nothing AndAlso designation.Count > 0 Then
                For Each des As String In designation
                    Dim item As New ListBoxItemWithTag() With {
                    .Text = des,
                    .PR_Number = prNumber
                }
                    LB_Designation.Items.Add(item)
                Next
            Else

                TXB_PrNumbers.Text = String.Empty
                LB_Designation.Items.Add("Leider wurden keine Einträge gefunden")
            End If
        End If
    End Sub

    Private Async Sub GetMultiNumber()
        Dim Numbers As New List(Of String)
        Numbers.AddRange(TXB_PrNumbers.Text.Split(";"c))
        lastPrnumber = Numbers(Numbers.Count - 1)
        LB_Designation.Items.Clear()


        Dim foundPRNumbers As New List(Of String)

        For Each num As String In Numbers

            Dim designations As List(Of String) = Await GETPrDesignation(num)


            If designations IsNot Nothing AndAlso designations.Count > 0 Then
                For Each des As String In designations
                    ' Erstelle ein neues ListBoxItemWithTag-Objekt
                    Dim item As New ListBoxItemWithTag() With {
                .Text = des,
                .PR_Number = num
            }

                    LB_Designation.Items.Add(item)
                Next

                foundPRNumbers.Add(num)
            End If
        Next

        Dim notFoundPRNumbers = Numbers.Except(foundPRNumbers).ToList()


        TXB_PrNumbers.Text = String.Join(";", foundPRNumbers)


        If notFoundPRNumbers.Count > 0 Then
            MessageBox.Show("Die folgenden PR-Nummern wurden nicht gefunden: " & String.Join(", ", notFoundPRNumbers))
        End If


        If LB_Designation.Items.Count = 0 Then
            LB_Designation.Items.Add("Leider wurden keine Einträge gefunden")
        End If
    End Sub
    Private Sub BTN_InsertIntoCarList_Click(sender As Object, e As EventArgs) Handles BTN_InsertIntoCarList.Click

        If TXB_PrNumbers.Text.Length > 0 Then
            TXB_PrNumbers.Text = TXB_PrNumbers.Text.ToUpper
        End If

        If TXB_PrNumbers.Text.Contains(";") Then
            Dim ListedPrNumbers As New List(Of String)
            ListedPrNumbers.AddRange(TXB_PrNumbers.Text.Split(";"c))

            For Each item As String In ListedPrNumbers
                LoadPRNumbers(item)
            Next


        Else
            lastPrnumber = TXB_PrNumbers.Text
            LoadPRNumbers(TXB_PrNumbers.Text)
        End If


    End Sub

    Private Sub LoadPRNumbers(NewPRNumber As String)
        If Not CBB_SavedCars.SelectedIndex = -1 Then
            Dim car As CarInfo = DirectCast(CBB_SavedCars.SelectedItem, CarInfo)
            Dim selectedLicenseplate As String = car.Kennzeichen
            Dim PRList As New List(Of String)

            Dim query As String = "SELECT PR FROM Autos WHERE Kennzeichen = @Kennzeichen"

            Using connection As New MySqlConnection(My.Settings.connectionstring)
                connection.Open() ' Verbindungsöffnung hinzugefügt
                Using cmd As New MySqlCommand(query, connection)
                    cmd.Parameters.AddWithValue("@Kennzeichen", selectedLicenseplate)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.HasRows Then
                            While reader.Read() ' Wichtige Überprüfung hinzugefügt
                                Dim SavedPrNumbers As String = reader.GetString("PR").ToString()
                                PRList.AddRange(SavedPrNumbers.Split(";"c))
                            End While
                        End If
                    End Using
                End Using
            End Using

            ' Überprüfe auf Duplikate und füge neue PR-Nummer hinzu
            If Not HasDuplicatePRNumber(PRList, NewPRNumber) Then
                InsertPRNumbers(String.Join(";", PRList), NewPRNumber, selectedLicenseplate)
            End If
        Else
            MsgBox("Bitte Auto auswählen, zu dem die PR-Nummer hinzugefügt werden soll")
        End If
    End Sub

    Private Sub InsertPRNumbers(SavedPrNumbers As String, NewPRNumber As String, selectedLicenseplate As String)

        If Not SavedPrNumbers = "N/A" AndAlso Not String.IsNullOrEmpty(SavedPrNumbers) Then
            SavedPrNumbers &= ";" & NewPRNumber
        Else
            SavedPrNumbers = NewPRNumber
        End If


        Dim query As String = "UPDATE Autos SET PR = @SavedPrNumbers WHERE Kennzeichen = @Kennzeichen"

        Using connection As New MySqlConnection(My.Settings.connectionstring)
            connection.Open()
            Using cmd As New MySqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@SavedPrNumbers", SavedPrNumbers)
                cmd.Parameters.AddWithValue("@Kennzeichen", selectedLicenseplate)
                cmd.ExecuteNonQuery()
            End Using
        End Using
        If NewPRNumber = lastPrnumber Then
            Notify(Autodatenbank.NI_Successful, "Erfolgreich", "PR-Nummer(n) wurde(n) erfolgreich hinzugefügt", 5000, ToolTipIcon.None)
        End If

    End Sub






    Private Function HasDuplicatePRNumber(Data As List(Of String), Number As String) As Boolean
        For Each item As String In Data
            If item = Number Then
                Return True
            End If
        Next

        Return False
    End Function





    Private Sub InsertMultiNumbers()
        Dim numbers As New List(Of String)

        numbers.AddRange(TXB_PrNumbers.Text.Split(";"c))
    End Sub

    Private Sub LB_Designation_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LB_Designation.SelectedIndexChanged
        Dim i As Integer = LB_Designation.SelectedIndex
        If i > -1 Then
            Dim item As ListBoxItemWithTag = DirectCast(LB_Designation.Items(i), ListBoxItemWithTag)
            MsgBox("PR-Nummer ist : " & item.PR_Number, Title:="Zugehörige PR-Nummer")
        End If

    End Sub

    Private Sub KopierenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KopierenToolStripMenuItem.Click
        Dim i As Integer = LB_Designation.SelectedIndex
        Clipboard.SetText(LB_Designation.Items(i).ToString)
        Notify(Autodatenbank.NI_Successful, "Kopiert", "Bezeichnung in Zwischenablage kopiert", 2000, ToolTipIcon.None)
    End Sub

    Private Sub TXB_PrNumbers_TextChanged(sender As Object, e As EventArgs) Handles TXB_PrNumbers.TextChanged
        Dim currentText As String = TXB_PrNumbers.Text.Replace(";", "").ToUpper() ' Entferne bestehende Semikolons

        ' Wenn die Länge des Textes ein Vielfaches von 3 ist, füge ein Semikolon hinzu
        If currentText.Length Mod 3 = 0 AndAlso currentText.Length > 0 Then
            TXB_PrNumbers.Text = InsertSemicolons(currentText)
            TXB_PrNumbers.SelectionStart = TXB_PrNumbers.Text.Length ' Setzt den Cursor ans Ende
        End If

    End Sub
    Private Function InsertSemicolons(text As String) As String
        ' Füge nach jedem dritten Zeichen ein Semikolon hinzu
        Dim result As New System.Text.StringBuilder()
        For i As Integer = 0 To text.Length - 1
            result.Append(text(i))
            If (i + 1) Mod 3 = 0 AndAlso i < text.Length - 1 Then
                result.Append(";") ' Semikolon hinzufügen nach jedem dritten Zeichen
            End If
        Next
        Return result.ToString()
    End Function

    Private Sub TXB_PrNumbers_KeyDown(sender As Object, e As KeyEventArgs) Handles TXB_PrNumbers.KeyDown
        If e.KeyCode = Keys.Enter Then
            BTN_Search.PerformClick()
        End If
    End Sub


    Private Sub LoadSavedCars()
        Using connection As New MySqlConnection(My.Settings.connectionstring)
            Try
                connection.Open()
                ' SQL-Abfrage, um das Kennzeichen und den Kundennamen abzurufen
                Dim Query As String = "SELECT a.Kennzeichen, k.ID AS kunden_id, k.Name AS kunden_name FROM Autos a JOIN Kunden k ON a.kunden_id = k.ID"

                Using Adapter As New MySqlDataAdapter(Query, connection)
                    Dim dataTable As New DataTable()
                    Adapter.Fill(dataTable)

                    CBB_SavedCars.Items.Clear() ' Vorherige Items löschen, um Doppelungen zu vermeiden

                    For Each row As DataRow In dataTable.Rows
                        ' Initialisiere die CarInfo-Klasse mit Kennzeichen, KundenId und KundenName
                        Dim carInfo As New CarInfo(row("Kennzeichen").ToString(), Convert.ToInt32(row("kunden_id")), row("kunden_name").ToString())
                        CBB_SavedCars.Items.Add(carInfo)
                    Next
                End Using
            Catch ex As Exception
                Notify(Autodatenbank.NI_Error, "Fehler beim Abrufen der gespeicherten Autos ", ex.Message.ToString, 10000, ToolTipIcon.Error)
                SavetoLogFile(ex.Message, "LoadSavedCarsPR")
            End Try
        End Using
    End Sub


End Class
Public Class ListBoxItemWithTag
    Public Property Text As String
    Public Property PR_Number As String

    Public Overrides Function ToString() As String
        Return Text
    End Function

    Public Function GetPrNumer() As String
        Return PR_Number
    End Function
End Class