Imports System.Net
Imports System.Net.Http
Imports HtmlAgilityPack
Imports MySqlConnector
Imports Newtonsoft.Json.Linq

Public Class NewCar

    Private Sub TXB_Licenseplate_TextChanged(sender As Object, e As EventArgs) Handles TXB_Licenseplate.TextChanged

    End Sub

    Private Sub TXB_Licenseplate_GotFocus(sender As Object, e As EventArgs) Handles TXB_Licenseplate.GotFocus
        If TXB_Licenseplate.Text = "Pflichtfeld" Then
            TXB_Licenseplate.Clear()
            TXB_Licenseplate.ForeColor = Color.Black

        End If
    End Sub

    Private Sub TXB_Licenseplate_LostFocus(sender As Object, e As EventArgs) Handles TXB_Licenseplate.LostFocus
        If String.IsNullOrEmpty(TXB_Licenseplate.Text) Then
            TXB_Licenseplate.Text = "Pflichtfeld"
            TXB_Licenseplate.ForeColor = Color.Gray
        End If
    End Sub

    Private Async Sub BTN_SearchForKeyNumber_Click(sender As Object, e As EventArgs) Handles BTN_SearchForKeyNumber.Click
        If TXB_KeyNumber.Text.Length > 0 Then
            If TXB_KeyNumber.Text.Length >= 7 Then
                Dim hsn As String = GetHSN(TXB_KeyNumber.Text)
                Dim tsn As String = GetTSN(TXB_KeyNumber.Text)
                Dim client As New HttpClient()
                Dim url As String = ""

                If TXB_KeyNumber.Text.Contains("/") Then
                    url = "https://lfdev.de/php/get_keynumbers.php?hsn=" & TXB_KeyNumber.Text
                Else
                    url = "https://lfdev.de/php/get_keynumbers.php?hsn=" & hsn & "/" & tsn
                End If



                Dim response As HttpResponseMessage = Await client.GetAsync(url)
                Try




                    If response.StatusCode = 200 Then
                        Dim jsonResponse As String = Await response.Content.ReadAsStringAsync

                        ' Verwende JArray und konvertiere das erste Element explizit in JObject
                        Dim cardataArray As JArray = JArray.Parse(jsonResponse)

                        ' Überprüfe, ob das Array nicht leer ist
                        If cardataArray.Count > 0 Then
                            Dim cardata As JObject = DirectCast(cardataArray(0), JObject) ' Explizite Konvertierung

                            If cardata("Modelbezeichnung") IsNot Nothing Then
                                Dim modelbezeichnung As String = cardata("Modelbezeichnung").ToString()

                                ' Annahme: Der Hersteller ist das erste Wort und die Typbezeichnung ist der Rest
                                Dim parts As String() = modelbezeichnung.Split(New Char() {" "c}, 2) ' Trennzeichen als Char-Array definieren

                                Dim hersteller As String = parts(0) ' Der Hersteller ist das erste Wort
                                Dim typbezeichnung As String = If(parts.Length > 1, parts(1), "") ' Der Rest als Typbezeichnung

                                TXB_Brand.Text = hersteller
                                TXB_Model.Text = typbezeichnung ' Typbezeichnung in ein entsprechendes Label setzen

                                Dim leistung As String = cardata("Leistung").ToString()
                                Dim hubraum As String = cardata("Hubraum").ToString()
                                Dim kraftstoff As String = cardata("Energie").ToString()

                                TXB_Power.Text = leistung
                                TXB_Displacement.Text = hubraum
                            End If

                        Else
                            MsgBox("Keine Daten gefunden", MsgBoxStyle.Information, Title:="Info")
                        End If
                    ElseIf response.StatusCode = 404 Then
                        MsgBox("Zu dieser Schlüsselnummer wurden keine Ergebnisse gefunden", MsgBoxStyle.Information, Title:="Info")
                    Else
                        MsgBox("Fehler beim Abrufen der Daten", MsgBoxStyle.Critical, Title:="Fehler")
                    End If
                Catch ex As Exception
                    MessageBox.Show("Fehler beim Verarbeiten der Daten: " & ex.Message)
                End Try
            Else
                MsgBox("Bitte HSN/TSN mit mindestens 7 Zeichen eintragen", MsgBoxStyle.Information, Title:="Info")
            End If
        Else
            MsgBox("Bitte HSN/TSN eintragen", MsgBoxStyle.Information, Title:="Info")
        End If
    End Sub

    Private Function GetHSN(input As String) As String

        If input.Length >= 4 Then
            Return input.Substring(0, 4)
        Else
            Return input
        End If

    End Function

    Private Function GetTSN(input As String) As String
        If input.Length >= 8 Then
            Return input.Substring(5, 3)
        ElseIf input.Length = 7 Then
            Return input.Substring(4, 3)
        Else
            Return input
        End If
    End Function

    Private Function GetBrand(input As String) As String
        Dim index As Integer = input.IndexOf(" ")
        If index >= 0 Then
            Return input.Substring(0, index)
        Else
            Return input
        End If
    End Function

    Private Function GetModel(input As String) As String
        Dim index As Integer = input.IndexOf(" ")
        If index >= 0 Then
            Return input.Substring(index + 1)
        Else
            Return ""
        End If
    End Function

    Private Sub BTN_SaveCar_Click(sender As Object, e As EventArgs) Handles BTN_SaveCar.Click
        If TXB_Licenseplate.Text.Length > 5 And Not TXB_Licenseplate.Text = "Pflichtfeld" And Not CBB_Customer.SelectedIndex = -1 Then

            Dim isNumeric As Boolean = Double.TryParse(TXB_Price.Text, Nothing)
            Dim selectedItem As ComboBoxItemEditUser = CType(CBB_Customer.SelectedItem, ComboBoxItemEditUser)
            Dim userName As String = selectedItem.UserName
            Dim userID As String = selectedItem.ID

            Try
                Using connection As New MySqlConnection(My.Settings.connectionstring)
                    connection.Open()

                    Dim query As String = "INSERT INTO Autos (Marke, Model, Kennzeichen, MKB, Hubraum, PS, FIN, Besitzer, Gekauft, Preis, Baujahr, HSN, kunden_id, tuev) VALUES (@Data1, @Data2, @Data3, @Data4, @Data5, @Data6, @Data7, @Data8, @Data9, @Data10, @Data11, @Data12, @Data13, @Data14)"

                    Using command As New MySqlCommand(query, connection)
                        command.Parameters.AddWithValue("@Data1", TXB_Brand.Text)
                        command.Parameters.AddWithValue("@Data2", TXB_Model.Text)
                        command.Parameters.AddWithValue("@Data3", TXB_Licenseplate.Text)
                        command.Parameters.AddWithValue("@Data4", TXB_Motorcode.Text)
                        command.Parameters.AddWithValue("@Data5", TXB_Displacement.Text)
                        command.Parameters.AddWithValue("@Data6", TXB_Power.Text)
                        command.Parameters.AddWithValue("@Data7", TXB_VIN.Text)
                        command.Parameters.AddWithValue("@Data8", userName)
                        command.Parameters.AddWithValue("@Data9", TXB_BuyDate.Text)
                        command.Parameters.AddWithValue("@Data10", TXB_Price.Text)
                        command.Parameters.AddWithValue("@Data11", TXB_ConstructionYear.Text)
                        command.Parameters.AddWithValue("@Data12", TXB_KeyNumber.Text)
                        command.Parameters.AddWithValue("@Data13", userID)

                        ' Stelle sicher, dass die ausgewählten Werte vorhanden und korrekt konvertiert sind
                        Dim selectedMonth As String = CBB_NextInspectionMonth.SelectedItem.ToString()
                        Dim selectedYear As String = CBB_NextInspectionYear.SelectedItem.ToString()
                        command.Parameters.AddWithValue("@Data14", SetNextInspection(selectedMonth, selectedYear))

                        command.ExecuteNonQuery()
                    End Using
                End Using

                MessageBox.Show("Daten wurden erfolgreich in die Datenbank eingefügt.")
                Application.Restart()
            Catch ex As Exception
                MessageBox.Show("Fehler beim Einfügen der Daten: " & ex.Message)
                SavetoLogFile(ex.Message, "SaveNewCar")
            End Try

            Autodatenbank.Refresh()
            Me.Close()
        Else
            MsgBox("Bitte Kennzeichen eintragen und Besitzer auswählen")
        End If
    End Sub

    Private Sub NewCar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadOverallSettings()
        LoadSavedCustomers()

    End Sub

    Private Function SetNextInspection(month As String, year As String) As String
        Dim monthInt As Integer
        Dim yearInt As Integer

        ' Konvertiere den Monat und das Jahr in Integer
        If Integer.TryParse(month, monthInt) AndAlso Integer.TryParse(year, yearInt) Then
            Return New DateTime(yearInt, monthInt, 1).ToString("yyyy-MM-dd")
        Else
            Throw New ArgumentException("Ungültige Werte für Monat oder Jahr")
        End If
    End Function

    Private Sub BNT_OCR_Click(sender As Object, e As EventArgs) Handles BNT_OCR.Click
        'ocr.Show()

        MsgBox("Diese Funktion ist nicht verfügbar.", MsgBoxStyle.Information, Title:="Info")
    End Sub

    Private Sub BTN_RefreshSavedCustomers_Click(sender As Object, e As EventArgs) Handles BTN_RefreshSavedCustomers.Click
        LoadSavedCustomers()
    End Sub



    Private Sub LoadSavedCustomers()

        CBB_Customer.Items.Clear()
        For year As Integer = 2023 To Now.Year + 5
            CBB_NextInspectionYear.Items.Add(year.ToString())
        Next

        CBB_NextInspectionYear.Text = Now.Year.ToString

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
                    SavetoLogFile(ex.Message, "NewCarLoad")
                End Try
            End Using
        End Using

    End Sub

    Private Sub BTN_AddNewCustomer_Click(sender As Object, e As EventArgs) Handles BTN_AddNewCustomer.Click
        NewCustomer.ShowDialog()
    End Sub
End Class