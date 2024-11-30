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
            End With
            priceChart.ChartAreas.Add(chartArea)
        End If

        ' Diagrammtitel hinzufügen (falls nicht vorhanden)
        If priceChart.Titles.Count = 0 Then
            priceChart.Titles.Add("Kostenübersicht")
            priceChart.Titles(0).Font = New Font("Arial", 14, FontStyle.Bold)
            priceChart.Titles(0).ForeColor = Color.DarkBlue
        End If
    End Sub


    Private Async Sub GetRefillData()
        Dim query As String = "SELECT * FROM Verbrauch WHERE Kennzeichen = @Kennzeichen"

        Using con As New MySqlConnection(My.Settings.connectionstring)
            con.Open()
            Using cmd As New MySqlCommand(query, con)
                cmd.Parameters.AddWithValue("@Kennzeichen", Kennzeichen)
                Using reader As MySqlDataReader = cmd.ExecuteReader
                    If reader.HasRows Then
                        While reader.Read()
                            Dim textFont As New Font(Font.FontFamily, 12, FontStyle.Regular)
                            Dim boldFont As New Font(Font.FontFamily, 12, FontStyle.Bold)
                            Dim RefillPanel As New TableLayoutPanel With {
                                .BorderStyle = BorderStyle.FixedSingle,
                                .Width = 350,
                                .Height = 150,
                                .Margin = New Padding(10),
                                .BackColor = Color.FromArgb(150, Color.LightGray),
                                .Padding = New Padding(10)
                            }

                            ' Labels erstellen
                            Dim Datum As New Label With {
                                .Text = "Datum: " & If(reader.IsDBNull(reader.GetOrdinal("Datum")), "", reader.GetDateTime(reader.GetOrdinal("Datum")).ToString("dd.MM.yyyy")),
                                .AutoSize = True,
                                .Font = boldFont,
                                .ForeColor = Color.DarkBlue
                            }
                            Dim Menge As New Label With {
                                .Text = "Liter: " & If(reader.IsDBNull(reader.GetOrdinal("Kraftstoffmenge")), "", reader.GetDouble(reader.GetOrdinal("Kraftstoffmenge")).ToString("F2")) & "l",
                                .AutoSize = True,
                                .Font = boldFont,
                                .ForeColor = Color.Green
                            }
                            Dim Preis As New Label With {
                                .Text = "Preis: " & If(reader.IsDBNull(reader.GetOrdinal("PPT")), "", reader.GetDouble(reader.GetOrdinal("PPT")).ToString("C2")),
                                .AutoSize = True,
                                .Font = boldFont,
                                .ForeColor = Color.Red
                            }
                            Dim Strecke As New Label With {
                                .Text = "Wegstrecke: " & If(reader.IsDBNull(reader.GetOrdinal("Wegstrecke")), "", reader.GetString(reader.GetOrdinal("Wegstrecke")).ToString),
                                .AutoSize = True,
                                .Font = boldFont,
                                .ForeColor = Color.Red
                            }

                            Dim Verbrauch As New Label With {
                                .Text = "Verbrauch/100km: " & If(reader.IsDBNull(reader.GetOrdinal("VerbrauchPro100km")), "", reader.GetDouble(reader.GetOrdinal("VerbrauchPro100km")).ToString("C2")),
                                .AutoSize = True,
                                .Font = boldFont,
                                .ForeColor = Color.Red
                            }
                            RefillPanel.Controls.Add(Datum)
                            RefillPanel.Controls.Add(Menge)
                            RefillPanel.Controls.Add(Preis)
                            RefillPanel.Controls.Add(Strecke)
                            RefillPanel.Controls.Add(Verbrauch)


                            Dim lat As Nullable(Of Double) = If(Not reader.IsDBNull(reader.GetOrdinal("latitude")), reader.GetDouble(reader.GetOrdinal("latitude")), CType(Nothing, Nullable(Of Double)))
                            Dim lon As Nullable(Of Double) = If(Not reader.IsDBNull(reader.GetOrdinal("longitude")), reader.GetDouble(reader.GetOrdinal("longitude")), CType(Nothing, Nullable(Of Double)))

                            If CBool(lat.HasValue & lon.HasValue) Then


                                Dim geocoder As New Geocoder
                                Try
                                    Dim adress As String = Await geocoder.GetAddress(CDbl(lat), CDbl(lon))
                                    Dim Standort As New Label With {
                                    .Text = "Standort: " & adress,
                                    .AutoSize = True,
                                    .Font = boldFont,
                                    .ForeColor = Color.Red
                                }

                                    RefillPanel.Controls.Add(Standort)
                                Catch ex As Exception

                                End Try



                            End If


                            FlowLayoutPanel1.Controls.Add(RefillPanel)


                        End While
                    End If






                End Using


            End Using

        End Using

    End Sub


End Class

Public Class Geocoder
    Private Const BaseUrl As String = "https://nominatim.openstreetmap.org/reverse"

    Public Async Function GetAddress(latitude As Double, longitude As Double) As Task(Of String)
        Dim client As New HttpClient()
        Dim url As String = $"{BaseUrl}?lat={latitude}&lon={longitude}&format=json"

        Dim response = Await client.GetStringAsync(url)
        Dim json = JObject.Parse(response)

        If json.ContainsKey("display_name") Then
            Return json("display_name").ToString()
        Else
            Throw New Exception("Keine Adresse gefunden.")
        End If
    End Function
End Class
