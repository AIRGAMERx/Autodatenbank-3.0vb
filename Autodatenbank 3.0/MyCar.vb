Imports System.Globalization
Imports System.Net.Http
Imports System.Windows.Forms.DataVisualization.Charting
Imports MySqlConnector
Imports Newtonsoft.Json.Linq

Public Class MyCar
    Dim Kennzeichen As String = ""
    Dim growthTimer As Timer
    Dim currentValues As List(Of Decimal)
    Dim targetValues As List(Of Decimal)
    Dim growthSpeed As Decimal = 50 ' Geschwindigkeit des Wachstums

    Private Sub MyCar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadOverallSettings() ' Diese Methode existiert nicht im ursprünglichen Code; ggf. entfernen oder definieren
        GetMyCar()
        GetRefillData()
    End Sub

    Private Sub GetMyCar()
        Dim query As String = "SELECT mycar FROM users WHERE id = @UID"
        Using con As New MySqlConnection(My.Settings.connectionstring)
            Try
                con.Open()
                Using cmd As New MySqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@UID", My.Settings.UID.ToString)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.HasRows Then
                            While reader.Read()
                                Kennzeichen = If(reader.IsDBNull(reader.GetOrdinal("mycar")), "", reader.GetString("mycar"))
                                Me.Text = "Mein Auto: " & Kennzeichen
                            End While
                        Else
                            MsgBox("Kein Auto mit diesem Benutzer verknüpft")
                            Me.Close()
                        End If
                    End Using
                End Using
            Catch ex As Exception
                MsgBox("Fehler: " & ex.Message)
            End Try
        End Using

        If Not String.IsNullOrEmpty(Kennzeichen) Then
            GetMyCarCost()
        End If
    End Sub

    Private Sub GetMyCarCost()
        Dim repaircost As Decimal = 0.0D
        Dim othercost As Decimal = 0.0D
        Dim servicecost As Decimal = 0.0D
        Dim refillcost As Decimal = 0.0D
        Dim culture As CultureInfo = CultureInfo.InvariantCulture

        ' Liste der Abfragen mit dem entsprechenden Spaltennamen, Typ und Update-Action
        Dim queries As List(Of Tuple(Of String, String, Type, Action(Of Decimal))) = New List(Of Tuple(Of String, String, Type, Action(Of Decimal))) From {
            New Tuple(Of String, String, Type, Action(Of Decimal))("SELECT Preis FROM Reparatur WHERE ID_Kennzeichen = @Kennzeichen", "Preis", GetType(String), Sub(value As Decimal) repaircost += value),
            New Tuple(Of String, String, Type, Action(Of Decimal))("SELECT Preis FROM Service WHERE ID_Kennzeichen = @Kennzeichen", "Preis", GetType(String), Sub(value As Decimal) servicecost += value),
            New Tuple(Of String, String, Type, Action(Of Decimal))("SELECT Preis FROM Sonstiges WHERE ID_Kennzeichen = @Kennzeichen", "Preis", GetType(String), Sub(value As Decimal) othercost += value),
            New Tuple(Of String, String, Type, Action(Of Decimal))("SELECT PPT FROM Verbrauch WHERE Kennzeichen = @Kennzeichen", "PPT", GetType(Double), Sub(value As Decimal) refillcost += value)
        }

        ' Iteration durch die Abfragen
        For Each queryTuple In queries
            Dim query As String = queryTuple.Item1
            Dim columnName As String = queryTuple.Item2
            Dim columnType As Type = queryTuple.Item3
            Dim updateAction As Action(Of Decimal) = queryTuple.Item4

            Using conn As New MySqlConnection(My.Settings.connectionstring)
                Try
                    conn.Open()
                    Using cmd As New MySqlCommand(query, conn)
                        cmd.Parameters.AddWithValue("@Kennzeichen", Kennzeichen)
                        Using reader As MySqlDataReader = cmd.ExecuteReader()
                            If reader.HasRows Then
                                While reader.Read()
                                    Dim preisAsDecimal As Decimal
                                    If columnType = GetType(String) Then
                                        Dim preis As String = reader.GetString(columnName).Trim()
                                        If preis.Contains("€") Then preis = preis.Replace("€", "")
                                        preis = preis.Replace(",", ".").Trim()
                                        If Decimal.TryParse(preis, NumberStyles.Any, culture, preisAsDecimal) Then
                                            updateAction(preisAsDecimal)
                                        End If
                                    ElseIf columnType = GetType(Double) Then
                                        preisAsDecimal = Convert.ToDecimal(reader.GetDouble(columnName))
                                        updateAction(preisAsDecimal)
                                    End If
                                End While
                            End If
                        End Using
                    End Using
                Catch ex As Exception
                    Debug.WriteLine($"Fehler bei Abfrage: {query}. Fehler: {ex.Message}")
                End Try
            End Using
        Next

        ' Zielwerte und Animation starten
        targetValues = New List(Of Decimal) From {repaircost, servicecost, othercost, refillcost}
        currentValues = New List(Of Decimal)(New Decimal(targetValues.Count - 1) {})
        StartAnimation()
    End Sub

    Private Sub StartAnimation()
        growthTimer = New Timer() With {.Interval = 50} ' 50 ms für flüssige Animation
        Debug.WriteLine($"Aktuelle Werte: Reparaturen: {currentValues(0)}, Service: {currentValues(1)}, Sonstiges: {currentValues(2)}, Tanken: {currentValues(3)}")
        AddHandler growthTimer.Tick, AddressOf GrowthTimer_Tick
        growthTimer.Start()
    End Sub

    Private Sub GrowthTimer_Tick(sender As Object, e As EventArgs)
        Dim allComplete As Boolean = True

        For i As Integer = 0 To targetValues.Count - 1
            If currentValues(i) < targetValues(i) Then
                Dim increment As Decimal = targetValues(i) * 0.05D ' 5% Wachstum pro Tick
                currentValues(i) = Math.Min(currentValues(i) + increment, targetValues(i))
                allComplete = False
            End If
        Next

        ' Debugging: Zeige die aktuellen Werte
        Debug.WriteLine("Aktuelle Werte: " & String.Join(", ", currentValues))

        ' Aktualisiere das Diagramm
        UpdateChart(currentValues)

        ' Beende den Timer, wenn alle Balken fertig sind
        If allComplete Then
            growthTimer.Stop()
            Debug.WriteLine("Animation abgeschlossen.")
        End If
    End Sub



    Private Sub UpdateChart(values As List(Of Decimal))
        ' Überprüfen, ob die Werte gültig sind
        If values Is Nothing OrElse values.Count < 4 Then
            Throw New ArgumentException("Die 'values'-Liste muss mindestens 4 Werte enthalten.")
        End If

        ' Prüfen, ob alle Werte 0 sind
        If values.All(Function(v) v = 0) Then
            MessageBox.Show("Alle Werte sind 0. Es gibt keine Daten, die angezeigt werden können.")
            Return
        End If

        ' Diagramm zurücksetzen (alte Daten entfernen)
        priceChart.Series.Clear()

        ' Neue Serie für das Kreisdiagramm erstellen
        Dim pieSeries As New Series("Kosten") With {
        .ChartType = SeriesChartType.Pie,
        .Font = New Font("Arial", 10, FontStyle.Bold),
        .IsValueShownAsLabel = True,
        .LabelFormat = "C", ' Format für Währungswerte
        .LabelForeColor = Color.Black
    }

        ' Datenpunkte hinzufügen
        pieSeries.Points.AddXY("Reparaturen", values(0))
        pieSeries.Points.AddXY("Service/Wartung", values(1))
        pieSeries.Points.AddXY("Sonstiges", values(2))
        pieSeries.Points.AddXY("Tanken", values(3))

        ' Farben der Segmente individuell anpassen
        pieSeries.Points(0).Color = Color.SteelBlue
        pieSeries.Points(1).Color = Color.SeaGreen
        pieSeries.Points(2).Color = Color.Goldenrod
        pieSeries.Points(3).Color = Color.IndianRed

        ' Hinzufügen der Serie zum Diagramm
        priceChart.Series.Add(pieSeries)

        ' ChartArea konfigurieren, falls nicht vorhanden
        If priceChart.ChartAreas.Count = 0 Then
            Dim chartArea As New ChartArea("MainArea")
            With chartArea
                .Area3DStyle.Enable3D = True ' Aktiviert 3D-Effekt für das Kreisdiagramm
                .Position = New ElementPosition(10, 10, 80, 80)
                .BackColor = Color.Transparent ' Hintergrund des Diagrammbereichs transparent machen
            End With
            priceChart.ChartAreas.Add(chartArea)
        Else
            ' Hintergrund des vorhandenen ChartArea transparent machen
            priceChart.ChartAreas(0).BackColor = Color.Transparent
        End If

        ' Diagrammtitel hinzufügen (falls nicht vorhanden)
        If priceChart.Titles.Count = 0 Then
            priceChart.Titles.Add("Kosten")
            With priceChart.Titles(0)
                .Font = New Font("Arial", 14, FontStyle.Bold)
                .ForeColor = Color.DarkBlue
                .BackColor = Color.Transparent ' Hintergrund des Titels transparent machen
            End With
        Else
            ' Hintergrund des vorhandenen Titels transparent machen
            priceChart.Titles(0).BackColor = Color.Transparent
        End If

        ' Legendenhintergrund transparent machen
        If priceChart.Legends.Count = 0 Then
            priceChart.Legends.Add(New Legend("Legend") With {
            .BackColor = Color.Transparent, ' Legendenhintergrund transparent machen
            .Font = New Font("Arial", 10, FontStyle.Regular)
        })
        Else
            priceChart.Legends(0).BackColor = Color.Transparent
        End If

        ' Hintergrund des gesamten Diagramms transparent machen
        priceChart.BackColor = Color.Transparent
    End Sub



    Private Async Sub GetRefillData()
        FlowLayoutPanel1.FlowDirection = FlowDirection.TopDown

        ' Textstyle for TableLayoutPanel
        Dim textFont As New Font(Font.FontFamily, 12, FontStyle.Regular)
        Dim boldFont As New Font(Font.FontFamily, 12, FontStyle.Bold)

        ' Beschreibungspanel
        Dim DescriptionPanel As New TableLayoutPanel With {
            .BorderStyle = BorderStyle.FixedSingle,
            .Width = 350,
            .Height = 60,
            .Margin = New Padding(10),
            .BackColor = Color.FromArgb(220, Color.LightGray),
            .Padding = New Padding(5),
            .RowCount = 2,
            .ColumnCount = 1
        }

        Dim Description As New Label With {
            .Text = "Tankdaten für " & Kennzeichen,
            .Font = boldFont,
            .ForeColor = Color.Black,
            .TextAlign = ContentAlignment.MiddleLeft,
            .AutoSize = True
        }
        Dim CB_OpenGoogleMaps As New CheckBox With {
            .Text = "Standort beim Klick auf das Panel öffnen",
            .Checked = False,
            .AutoSize = True
        }

        DescriptionPanel.Controls.Add(Description, 0, 0)
        DescriptionPanel.Controls.Add(CB_OpenGoogleMaps, 0, 1)
        FlowLayoutPanel1.Controls.Add(DescriptionPanel)

        Dim query As String = "SELECT * FROM Verbrauch WHERE Kennzeichen = @Kennzeichen"

        Using con As New MySqlConnection(My.Settings.connectionstring)
            con.Open()
            Using cmd As New MySqlCommand(query, con)
                cmd.Parameters.AddWithValue("@Kennzeichen", Kennzeichen)

                Using reader As MySqlDataReader = cmd.ExecuteReader
                    If reader.HasRows Then
                        While reader.Read()
                            ' TableLayoutPanel für die Anzeige erstellen
                            Dim RefillPanel As New TableLayoutPanel With {
                                .BorderStyle = BorderStyle.FixedSingle,
                                .Width = 350,
                                .Height = 250,
                                .Margin = New Padding(10),
                                .BackColor = Color.FromArgb(220, Color.LightGray),
                                .Padding = New Padding(5),
                                .RowCount = 7,
                                .ColumnCount = 2
                            }

                            ' Spaltenbreite festlegen
                            RefillPanel.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 40)) ' Beschriftungen
                            RefillPanel.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 60)) ' Werte

                            ' Daten aus der Datenbank lesen und Labels erstellen
                            Dim DatumLabel As New Label With {
                                .Text = "Datum:",
                                .Font = boldFont,
                                .ForeColor = Color.DarkBlue,
                                .TextAlign = ContentAlignment.MiddleLeft
                            }
                            Dim DatumValue As New Label With {
                                .Text = If(reader.IsDBNull(reader.GetOrdinal("Datum")), "N/A", reader.GetDateTime(reader.GetOrdinal("Datum")).ToString("dd.MM.yyyy")),
                                .Font = textFont,
                                .ForeColor = Color.DarkBlue,
                                .TextAlign = ContentAlignment.MiddleRight
                            }

                            Dim MengeLabel As New Label With {
                                .Text = "Liter:",
                                .Font = boldFont,
                                .ForeColor = Color.Green,
                                .TextAlign = ContentAlignment.MiddleLeft
                            }
                            Dim MengeValue As New Label With {
                                .Text = If(reader.IsDBNull(reader.GetOrdinal("Kraftstoffmenge")), "N/A", reader.GetDouble(reader.GetOrdinal("Kraftstoffmenge")).ToString("F2") & " l"),
                                .Font = textFont,
                                .ForeColor = Color.Green,
                                .TextAlign = ContentAlignment.MiddleRight
                            }

                            Dim PreisLabel As New Label With {
                                .Text = "Preis:",
                                .Font = boldFont,
                                .ForeColor = Color.Red,
                                .TextAlign = ContentAlignment.MiddleLeft
                            }
                            Dim PreisValue As New Label With {
                                .Text = If(reader.IsDBNull(reader.GetOrdinal("PPT")), "N/A", reader.GetDouble(reader.GetOrdinal("PPT")).ToString("C2")),
                                .Font = textFont,
                                .ForeColor = Color.Red,
                                .TextAlign = ContentAlignment.MiddleRight
                            }

                            Dim StreckeLabel As New Label With {
                                .Text = "Wegstrecke:",
                                .Font = boldFont,
                                .ForeColor = Color.Black,
                                .TextAlign = ContentAlignment.MiddleLeft
                            }
                            Dim StreckeValue As New Label With {
                                .Text = If(reader.IsDBNull(reader.GetOrdinal("Wegstrecke")), "N/A", reader.GetString(reader.GetOrdinal("Wegstrecke")) & " km"),
                                .Font = textFont,
                                .ForeColor = Color.Black,
                                .TextAlign = ContentAlignment.MiddleRight
                            }

                            Dim VerbrauchLabel As New Label With {
                                .Text = "Verbrauch/100km:",
                                .Font = boldFont,
                                .ForeColor = Color.Purple,
                                .TextAlign = ContentAlignment.MiddleLeft
                            }
                            Dim VerbrauchValue As New Label With {
                                .Text = If(reader.IsDBNull(reader.GetOrdinal("VerbrauchPro100km")), "N/A", reader.GetDouble(reader.GetOrdinal("VerbrauchPro100km")).ToString("F2") & " l/100km"),
                                .Font = textFont,
                                .ForeColor = Color.Purple,
                                .TextAlign = ContentAlignment.MiddleRight
                            }

                            ' Labels dem Panel hinzufügen
                            RefillPanel.Controls.Add(DatumLabel, 0, 0)
                            RefillPanel.Controls.Add(DatumValue, 1, 0)
                            RefillPanel.Controls.Add(MengeLabel, 0, 1)
                            RefillPanel.Controls.Add(MengeValue, 1, 1)
                            RefillPanel.Controls.Add(PreisLabel, 0, 2)
                            RefillPanel.Controls.Add(PreisValue, 1, 2)
                            RefillPanel.Controls.Add(StreckeLabel, 0, 3)
                            RefillPanel.Controls.Add(StreckeValue, 1, 3)
                            RefillPanel.Controls.Add(VerbrauchLabel, 0, 4)
                            RefillPanel.Controls.Add(VerbrauchValue, 1, 4)

                            ' Geocoding-Daten
                            Dim lat As Nullable(Of Double) = If(Not reader.IsDBNull(reader.GetOrdinal("latitude")), reader.GetDouble(reader.GetOrdinal("latitude")), CType(Nothing, Nullable(Of Double)))
                            Dim lon As Nullable(Of Double) = If(Not reader.IsDBNull(reader.GetOrdinal("longitude")), reader.GetDouble(reader.GetOrdinal("longitude")), CType(Nothing, Nullable(Of Double)))

                            If lat.HasValue AndAlso lon.HasValue Then
                                Dim adress As String = Await New Geocoder().GetAddress(lat.Value, lon.Value)

                                ' Tag für das gesamte Panel setzen
                                RefillPanel.Tag = $"{adress}!{lat.Value}!{lon.Value}"

                                Dim StandortLabel As New Label With {
                                    .Text = "Standort:",
                                    .Font = boldFont,
                                    .ForeColor = Color.Orange,
                                    .TextAlign = ContentAlignment.MiddleLeft
                                }
                                Dim StandortValue As New Label With {
                                    .Text = adress,
                                    .Font = textFont,
                                    .ForeColor = Color.Orange,
                                    .TextAlign = ContentAlignment.TopLeft,
                                    .AutoSize = True
                                }

                                RefillPanel.Controls.Add(StandortLabel, 0, 5)
                                RefillPanel.Controls.Add(StandortValue, 1, 5)
                            End If

                            ' Click-Event für alle Controls im Panel registrieren
                            RegisterClickHandler(RefillPanel, AddressOf Panel_Click)

                            ' Panel zum FlowLayoutPanel hinzufügen
                            FlowLayoutPanel1.Controls.Add(RefillPanel)
                        End While
                    Else
                        MessageBox.Show("Keine Daten gefunden.")
                    End If
                End Using
            End Using
        End Using
    End Sub

    ' Methode zur Registrierung von Click-Events für ein Panel und alle enthaltenen Steuerelemente
    Private Sub RegisterClickHandler(control As Control, handler As EventHandler)
        AddHandler control.Click, handler
        For Each child As Control In control.Controls
            RegisterClickHandler(child, handler)
        Next
    End Sub

    ' Panel-Click-Handler
    Private Sub Panel_Click(sender As Object, e As EventArgs)
        ' Überprüfen, ob die CheckBox aktiviert ist
        Dim descriptionPanel As TableLayoutPanel = CType(FlowLayoutPanel1.Controls(0), TableLayoutPanel)
        Dim openGoogleMapsCheckbox As CheckBox = CType(descriptionPanel.Controls.OfType(Of CheckBox).FirstOrDefault(), CheckBox)

        If openGoogleMapsCheckbox Is Nothing OrElse Not openGoogleMapsCheckbox.Checked Then
            Return
        End If

        ' Das übergeordnete TableLayoutPanel des angeklickten Steuerelements finden
        Dim clickedControl As Control = CType(sender, Control)
        Dim clickedPanel As TableLayoutPanel = Nothing

        While clickedControl IsNot Nothing
            If TypeOf clickedControl Is TableLayoutPanel Then
                clickedPanel = CType(clickedControl, TableLayoutPanel)
                Exit While
            End If
            clickedControl = clickedControl.Parent
        End While

        ' Sicherstellen, dass ein TableLayoutPanel gefunden wurde
        If clickedPanel IsNot Nothing AndAlso clickedPanel.Tag IsNot Nothing Then
            ' Tag auslesen (z. B. "Adresse!latitude!longitude")
            Dim tagData As String = clickedPanel.Tag.ToString()
            Dim tagParts As String() = tagData.Split("!"c)

            If tagParts.Length >= 3 Then
                Dim latitudeFormatted As String = tagParts(1).Replace(",", ".")
                Dim longitudeFormatted As String = tagParts(2).Replace(",", ".")
                Dim googleMapsUrl As String = $"https://www.google.com/maps?q={latitudeFormatted},{longitudeFormatted}"

                ' URL im Standardbrowser öffnen
                Try
                    Process.Start(New ProcessStartInfo With {
                        .FileName = googleMapsUrl,
                        .UseShellExecute = True
                    })
                Catch ex As Exception
                    MsgBox($"Fehler beim Öffnen von Google Maps: {ex.Message}")
                End Try
            End If
        Else
            MsgBox("Kein gültiges Panel gefunden oder kein Tag gesetzt.")
        End If
    End Sub








End Class

Public Class Geocoder
  

    Public Async Function GetAddress(latitude As Double, longitude As Double) As Task(Of String)
        Dim client As New HttpClient()
        Dim email As String = My.Settings.LicenseEmail
        ' Setzen des User-Agent-Headers
        client.DefaultRequestHeaders.UserAgent.ParseAdd($"Autodatenbank/3.0 ({email})")

        Dim url As String = $"https://nominatim.openstreetmap.org/reverse?lat={latitude.ToString(System.Globalization.CultureInfo.InvariantCulture)}&lon={longitude.ToString(System.Globalization.CultureInfo.InvariantCulture)}&format=json"


        Dim response = Await client.GetAsync(url)

        ' Überprüfen, ob die Anfrage erfolgreich war
        If response.IsSuccessStatusCode Then
            Dim responseBody = Await response.Content.ReadAsStringAsync()
            Dim json = JObject.Parse(responseBody)

            If json.ContainsKey("display_name") Then
                Return json("display_name").ToString()
            Else
                Throw New Exception("Keine Adresse gefunden.")
            End If
        Else
            ' Fehler werfen, wenn der Statuscode nicht erfolgreich ist
            Throw New HttpRequestException($"Fehler beim Geocoding: Der Antwortstatuscode gibt keinen Erfolg an: {CInt(response.StatusCode)} ({response.ReasonPhrase}).")
        End If
    End Function
End Class
