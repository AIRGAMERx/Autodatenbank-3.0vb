'LFDEV.de
Imports System.ComponentModel
Imports System.IO
Imports MySqlConnector
Imports Sydesoft.NfcDevice
Imports System.Threading
Imports IWshRuntimeLibrary


Public Class Autodatenbank
    Dim VisualizeThread As Thread
    Private Shared acr122u As New ACR122U
    Public LoginSetting As Boolean ' Einstellung für Anmeldung aktiviert
    Public Login As Boolean ' Aktuell angemeldet
    Public EditData As Boolean 'SigninSettings ist offen
    Public UID As String 'Angemeldeter User ID
    Public Licenseplate As String = ""
    Public EntryID As Integer
    Public CustomID As Integer = 0
    Public CreateReport As Boolean = False
    Public ReportSelect As List(Of String)
    Dim CurrentFTPLink As String = ""
    Private isF2Pressed As Boolean = False
    Private isLPressed As Boolean = False

    Private Async Sub Autodatenbank_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Console.WriteLine(My.Settings.Regkey & "  5")





        Me.Visible = False

        ' Aktuelle Version anzeigen lassen
        Me.Text = "Autodatenbank Version: " & GetCurrentVersion(My.Settings.Version.ToString)

        ' Wenn Anmeldung aktiv ist
        If CheckExistTableUsers("users") Then
            LBL_Login.Visible = True
            LoginSetting = True

            ' NFC-Verifikation
            If My.Settings.NFCVerify = True Then
                Try
                    acr122u.Init(False, 50, 4, 4, 200)
                    AddHandler acr122u.CardInserted, AddressOf Acr122u_CardInserted
                Catch ex As Exception
                    ' Fehlerbehandlung
                End Try
            End If

            If My.Settings.Username = "" Then
                Authent.Show()
                My.Settings.CloseToAuth = True
                Me.Close()
            End If

        Else
            LBL_Login.Visible = False
            LBL_Logout.Visible = False
            LoginSetting = False
        End If



        ' Auf Abschluss von Initialisation warten
        Await Initialisation()

        ' Visualize aufrufen (falls nicht im Thread benötigt)
        Visualize()

        ' Form sichtbar machen
        Me.Visible = True

    End Sub

    Public Async Function Initialisation() As Task
        ' Lizensdaten Laden
        Try
            Console.WriteLine(My.Settings.Regkey & "  8")
            Dim userdata = Await GetUserDataAsync(My.Settings.Regkey)
            My.Settings.LicenseName = userdata.Name
        Catch ex As Exception
            ' Fehlerbehandlung
        End Try

        ' Gespeicherte Autos Laden
        LoadCars()

        ' DGV aufbauen
        CreateDGV()

        ' Visuelle Einstellungen laden
        LoadOverallSettings()
        LoadDGVSettings()

        ' Tüv Termin CB füllen
        For year As Integer = 2023 To Now.Year + 5
            CBB_NextInspectionYear.Items.Add(year.ToString())
        Next
        ReportSelect = New List(Of String)()
        CBB_NextInspectionYear.Text = Now.Year.ToString()

        ' User Laden
        If My.Settings.RememberLogin = True And Not My.Settings.Username = "" Then
            InvokeToolStripItem(ToolStrip1, LBL_Login, "Angemeldet: " & My.Settings.Username)
            UID = My.Settings.UID
            Login = True
            LBL_Logout.Visible = True
        End If
        DeleteOldLogEntries()
        LoadCompanyData()
        CreateShortCutInStartMenu()
    End Function
    Public Sub CreateShortCutInStartMenu()
        Dim exePath As String = Application.StartupPath & "/Autodatenbank 3.0.exe"
        Dim startMenuPath As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.StartMenu), "Programs", "Autodatenbank")

        Dim shortcutName As String = "Autodatenbank.lnk"
        Dim shortcutPath As String = Path.Combine(startMenuPath, shortcutName)

        Try

            If Not Directory.Exists(startMenuPath) Then
                Directory.CreateDirectory(startMenuPath)
            End If


            Dim shell As New WshShell()
            Dim shortcut As IWshShortcut = CType(shell.CreateShortcut(shortcutPath), IWshShortcut)


            shortcut.TargetPath = exePath
            shortcut.WorkingDirectory = Path.GetDirectoryName(exePath)
            shortcut.Description = "Der alleskönner für die von dir betreuten Fahrzeuge"
            shortcut.Save()


        Catch ex As Exception

        End Try
    End Sub

    Public Sub Visualize()
        Dim p As String = My.Settings.PermissionKey ' Shorten Code

        ' Benutzer Optionen
        If GetPermission(p, 1) AndAlso GetPermission(p, 2) AndAlso GetPermission(p, 3) = False Then
            TSM_Benutzer.Visible = False
        End If

        If GetPermission(p, 1) = False Then
            TSM_Benutzer_Erstellen.Visible = False
        End If

        If GetPermission(p, 2) = False Then
            TSM_Benutzer_Bearbeiten.Visible = False
        End If

        ' Einträge
        If GetPermission(p, 4) = False Then
            LBL_NewEntry.Visible = False
            TSMI_Checklistedit.Visible = False
        End If

        If GetPermission(p, 5) = False Then
            TSMI_Eintrag_Bearbeiten.Visible = False
            BTN_SaveCarData.Visible = False
            TSMI_ChecklistOpen.Visible = False
        End If

        If GetPermission(p, 6) = False Then
            TSMI_Eintrag_Loeschen.Visible = False
        End If

        ' Admin
        If GetPermission(p, 7) = False Then
            TSMI_Admin.Visible = False
            TSMI_LogFile_Oeffnen.Visible = False
            TSMI_Server_Verbindungen.Visible = False
            TSB_Issue.Visible = False
            BTN_DeleteCarData.Visible = False ' Auto Löschen nur für Admin
        End If

        ' Dateien
        If GetPermission(p, 8) = False Then
            TSB_UploadFile.Visible = False
        End If

        If GetPermission(p, 9) = False Then
            TSMI_Datei_Oeffnen.Visible = False
        End If

        If GetPermission(p, 10) = False Then
            TSMI_Datei_Loeschen.Visible = False
        End If

        ' Auto anlegen
        If GetPermission(p, 11) = False Then
            TSL_Neues_Auto.Visible = False
        End If

        ' Bericht
        If GetPermission(p, 12) = False Then
            TSMI_Bericht_erstellen.Visible = False
            TSMI_Bericht_Einstellungen.Visible = False
        End If
    End Sub

    Private Sub Autodatenbank_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If My.Settings.RememberLogin = False And My.Settings.CloseToAuth = False Then
            My.Settings.Reset()
            My.Settings.Save()
        End If

        My.Settings.DefaultSettings = False
        My.Settings.Save()

        Try
            Dim d As String() = Directory.GetFiles(Application.StartupPath & "\temp\")
            For Each datei As String In d
                Try
                    System.IO.File.Delete(datei)
                Catch ex As Exception
                End Try

            Next
        Catch ex As Exception

        End Try

    End Sub

    Public Sub LoadCars()
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
                Notify(NI_Error, "Fehler beim Abrufen der gespeicherten Autos ", ex.Message.ToString, 10000, ToolTipIcon.Error)
                SavetoLogFile(ex.Message, "LoadCars")
            End Try
        End Using
    End Sub

    Private Sub ToolStripLabel2_Click(sender As Object, e As EventArgs) Handles LBL_NewEntry.Click

        If GetPermission(My.Settings.PermissionKey, 4) Then
            DatabaseEntries.Show()
        Else
            MsgBox("Keine Berechtigung um neue Einträge zu erstellen")
        End If
    End Sub

    Private Sub CBB_SavedCars_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBB_SavedCars.SelectedIndexChanged
        If CBB_SavedCars.SelectedIndex > -1 Then
            Dim selectedCarInfo As CarInfo = CType(CBB_SavedCars.SelectedItem, CarInfo)

            ' Verwende das Kennzeichen des ausgewählten CarInfo-Objekts
            Licenseplate = selectedCarInfo.Kennzeichen

            LBL_NewEntry.Enabled = True
            TSB_UploadFile.Enabled = True

            LoadSelectedCar()
            FillDGV()

            If My.Settings.sftp = True Then
                SFTP.ListFilesFromSFTPForDGV2(Licenseplate)

            Else
                FTP.ListFilesFromFTPForDGV2(Licenseplate)


            End If
        Else

            ' Falls nichts ausgewählt ist, tue nichts oder setze Standardwerte
        End If
    End Sub

    Public Sub LoadSelectedCar()
        'Textboxen leeren
        TXB_Brand.Text = ""
        TXB_Model.Text = ""
        TXB_LicensePlate.Text = ""
        TXB_Motorcode.Text = ""
        TXB_Displacement.Text = ""
        TXB_Power.Text = ""
        TXB_VIN.Text = ""
        TXB_Owner.Text = ""
        TXB_BuyDate.Text = ""
        TXB_Price.Text = ""
        TXB_ConstructionYear.Text = ""
        TXB_KeyNumber.Text = ""
        RTB_Infos.Clear()

        Dim connection As New MySqlConnection(My.Settings.connectionstring)

        Try
            connection.Open()

            Dim searchValue As String = Licenseplate
            Dim query As String = "SELECT * FROM Autos WHERE Kennzeichen = @SearchValue"

            Using cmd As New MySqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@SearchValue", searchValue)

                Dim reader As MySqlDataReader = cmd.ExecuteReader()

                While reader.Read()
                    ' Überprüfen ob DBNull für jede Spalte
                    TXB_Brand.Text = If(reader.IsDBNull(reader.GetOrdinal("Marke")), "", reader.GetString("Marke"))
                    TXB_Model.Text = If(reader.IsDBNull(reader.GetOrdinal("Model")), "", reader.GetString("Model"))
                    TXB_LicensePlate.Text = If(reader.IsDBNull(reader.GetOrdinal("Kennzeichen")), "", reader.GetString("Kennzeichen"))
                    TXB_Motorcode.Text = If(reader.IsDBNull(reader.GetOrdinal("MKB")), "", reader.GetString("MKB"))
                    TXB_Displacement.Text = If(reader.IsDBNull(reader.GetOrdinal("Hubraum")), "", reader.GetString("Hubraum"))
                    TXB_Power.Text = If(reader.IsDBNull(reader.GetOrdinal("PS")), "", reader.GetString("PS"))
                    TXB_VIN.Text = If(reader.IsDBNull(reader.GetOrdinal("FIN")), "", reader.GetString("FIN"))
                    TXB_Owner.Text = If(reader.IsDBNull(reader.GetOrdinal("Besitzer")), "", reader.GetString("Besitzer"))
                    TXB_BuyDate.Text = If(reader.IsDBNull(reader.GetOrdinal("Gekauft")), "", reader.GetString("Gekauft"))
                    TXB_Price.Text = If(reader.IsDBNull(reader.GetOrdinal("Preis")), "", reader.GetString("Preis").ToString())
                    TXB_ConstructionYear.Text = If(reader.IsDBNull(reader.GetOrdinal("Baujahr")), "", reader.GetString("Baujahr"))
                    TXB_KeyNumber.Text = If(reader.IsDBNull(reader.GetOrdinal("HSN")), "", reader.GetString("HSN"))
                    RTB_Infos.Text = If(reader.IsDBNull(reader.GetOrdinal("Info")), "", reader.GetString("Info"))

                    ' Überprüfen ob TÜV NULL ist
                    If Not reader.IsDBNull(reader.GetOrdinal("tuev")) Then
                        Dim tuevDate As DateTime = reader.GetDateTime("tuev")
                        CBB_NextInspectionMonth.SelectedItem = tuevDate.Month.ToString("D2")
                        CBB_NextInspectionYear.SelectedItem = tuevDate.Year.ToString()
                    Else
                        ' Setze ComboBoxes auf Standardwert oder lasse sie leer
                        CBB_NextInspectionMonth.SelectedItem = Now.Month.ToString("D2")
                        CBB_NextInspectionYear.SelectedItem = Now.Year.ToString()
                    End If
                End While

                reader.Close()
            End Using

            My.Settings.LicensePlate = TXB_LicensePlate.Text
            My.Settings.Save()
            My.Settings.Reload()

            If NextInspectionDue(CInt(CBB_NextInspectionYear.SelectedItem), CInt(CBB_NextInspectionMonth.SelectedItem)) Then
                Notify(NI_InspectionDate, "TÜV abgelaufen", "Bei " & TXB_LicensePlate.Text & " ist der TÜV abgelaufen, bitte demnächst erneuern", 5000, ToolTipIcon.Warning)
            End If
        Catch ex As Exception
            Notify(NI_Error, "Fehler beim Laden der Daten", ex.Message.ToString, 10000, ToolTipIcon.Error)
            SavetoLogFile(ex.Message, "LoadSelectedCar")
        Finally
            connection.Close()
        End Try
    End Sub

    Private Sub BTN_SaveCarData_Click(sender As Object, e As EventArgs) Handles BTN_SaveCarData.Click
        Dim connection As New MySqlConnection(My.Settings.connectionstring)

        Try
            connection.Open()

            Dim primaryKeyValue As String = TXB_LicensePlate.Text
            Dim newValue1 As String = TXB_Brand.Text
            Dim newValue2 As String = TXB_Model.Text
            Dim newValue4 As String = TXB_Motorcode.Text
            Dim newValue5 As String = TXB_Displacement.Text
            Dim newValue6 As String = TXB_Power.Text
            Dim newValue7 As String = TXB_VIN.Text
            Dim newValue8 As String = TXB_ConstructionYear.Text
            Dim newValue9 As String = TXB_KeyNumber.Text
            Dim newValue10 As String = TXB_Owner.Text
            Dim newValue11 As String = TXB_BuyDate.Text
            Dim newValue12 As String = TXB_Price.Text
            Dim newValue13 As String = RTB_Infos.Text

            Dim query As String = "UPDATE Autos SET Marke = @NewValue1, Model = @NewValue2, MKB = @NewValue4, Hubraum = @NewValue5, PS = @NewValue6, FIN = @NewValue7, Baujahr = @NewValue8, HSN = @NewValue9, Besitzer = @NewValue10, Gekauft = @NewValue11, Preis = @NewValue12, Info = @NewValue13, tuev = @NewValue14 WHERE Kennzeichen = @PrimaryKeyValue"

            Using cmd As New MySqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@NewValue1", newValue1)
                cmd.Parameters.AddWithValue("@NewValue2", newValue2)
                cmd.Parameters.AddWithValue("@NewValue4", newValue4)
                cmd.Parameters.AddWithValue("@NewValue5", newValue5)
                cmd.Parameters.AddWithValue("@NewValue6", newValue6)
                cmd.Parameters.AddWithValue("@NewValue7", newValue7)
                cmd.Parameters.AddWithValue("@NewValue8", newValue8)
                cmd.Parameters.AddWithValue("@NewValue9", newValue9)
                cmd.Parameters.AddWithValue("@NewValue10", newValue10)
                cmd.Parameters.AddWithValue("@NewValue11", newValue11)
                cmd.Parameters.AddWithValue("@NewValue12", newValue12)
                cmd.Parameters.AddWithValue("@NewValue13", newValue13)
                Dim selectedMonth As String = CBB_NextInspectionMonth.SelectedItem.ToString()
                Dim selectedYear As String = CBB_NextInspectionYear.SelectedItem.ToString()
                cmd.Parameters.AddWithValue("@NewValue14", SetNextInspection(selectedMonth, selectedYear))

                cmd.Parameters.AddWithValue("@PrimaryKeyValue", primaryKeyValue)

                Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

                If rowsAffected > 0 Then

                    Notify(NI_Successful, "Erfolg", "Daten für " & TXB_LicensePlate.Text & " wurden erfolgreich gespeichert", 5000, ToolTipIcon.Info)
                Else
                    MsgBox("Fehler beim Speichern.")
                End If
            End Using
        Catch ex As Exception
            Notify(NI_Error, "Fehler beim Speichern der Daten", ex.Message.ToString, 10000, ToolTipIcon.Error)
            SavetoLogFile(ex.Message, "SaveCarInfo")
        Finally
            connection.Close()
        End Try
    End Sub

    Private Sub CreateDGV()
        ' Die DataGridViews komplett leeren: alle Zeilen und Spalten entfernen
        dgv.Rows.Clear()
        dgv.Columns.Clear()
        dgv2.Rows.Clear()
        dgv2.Columns.Clear()

        If CreateReport = True Then
            Dim chkColumn As New DataGridViewCheckBoxColumn With {
            .Name = "InBerichtAufnehmen",
            .HeaderText = "In Bericht aufnehmen",
            .Width = 150 ' Sie können die Breite nach Bedarf anpassen
        }
            dgv.Columns.Insert(0, chkColumn) ' Die CheckBox-Spalte an der ersten Position hinzufügen
        End If

        ' Die restlichen Spalten hinzufügen
        dgv.Columns.Add("ID", "ID")
        dgv.Columns.Add("Tabellenname", "Tabellenname")
        dgv.Columns.Add("ID_Kennzeichen", "Kennzeichen")
        dgv.Columns.Add("Bezeichnung", "Bezeichnung")
        dgv.Columns.Add("Kilometer", "Kilometer")
        dgv.Columns.Add("Datum", "Datum")
        dgv.Columns.Add("Preis in €", "Preis in €")
        dgv.Columns.Add("Kommentar", "Kommentar")
        dgv.Columns.Add("Art", "Art")
        dgv.Columns.Add("Bearbeiter", "Bearbeiter")

        If CreateReport = True Then
            dgv.Columns(1).Visible = False
            dgv.Columns(2).Visible = False
        Else
            dgv.Columns(0).Visible = False
            dgv.Columns(1).Visible = False
        End If

        ' Setze alle Spalten auf ReadOnly, außer der CheckBox-Spalte
        For Each col As DataGridViewColumn In dgv.Columns
            If col.Name <> "InBerichtAufnehmen" Then
                col.ReadOnly = True
            End If
        Next
        dgv.RowHeadersVisible = False

        ' Spalten für dgv2 hinzufügen
        dgv2.Columns.Add("Dateiname", "Dateiname")
        dgv2.Columns.Add("Erstelldatum", "Erstelldatum")
        dgv2.Columns.Add("Dateipfad", "Dateipfad")
        dgv2.Columns("Dateiname").Width = 300
        dgv2.Columns("Erstelldatum").Width = 150
        dgv2.Columns("Dateipfad").Width = 600

        dgv2.RowHeadersVisible = False
    End Sub

    Public Sub FillDGV()
        Dim i As Integer = -1
        Dim connection As New MySqlConnection(My.Settings.connectionstring)
        Dim searchValue As String = Licenseplate
        dgv.Rows.Clear()

        Try
            connection.Open() ' Nur einmal die Verbindung öffnen

            ' Service-Daten abrufen
            FetchData("SELECT * FROM Service WHERE ID_Kennzeichen = @SearchValue", connection, searchValue, "Service", i)

            ' Reparatur-Daten abrufen
            FetchData("SELECT * FROM Reparatur WHERE ID_Kennzeichen = @SearchValue", connection, searchValue, "Reparatur", i)

            ' Sonstiges-Daten abrufen
            FetchData("SELECT * FROM Sonstiges WHERE ID_Kennzeichen = @SearchValue", connection, searchValue, "Sonstiges", i)
        Catch ex As Exception
            MessageBox.Show("Fehler beim Abrufen der Daten: " & ex.Message)
            SavetoLogFile(ex.Message, "FillDGV")
        Finally
            connection.Close() ' Verbindung nach dem gesamten Vorgang schließen
        End Try
    End Sub

    Private Sub FetchData(query As String, connection As MySqlConnection, searchValue As String, art As String, ByRef i As Integer)
        Try
            Using cmd As New MySqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@SearchValue", searchValue)

                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim newRow As New DataGridViewRow()
                        dgv.Rows.Add(newRow)
                        i += 1

                        ' Überprüfen, ob "CreateReport" False ist
                        If CreateReport = False Then
                            dgv.Rows(i).Cells(0).Value = If(reader.IsDBNull(reader.GetOrdinal("ID_" & art)), 0, reader.GetInt32("ID_" & art))
                            dgv.Rows(i).Cells(1).Value = art
                            dgv.Rows(i).Cells(2).Value = If(reader.IsDBNull(reader.GetOrdinal("ID_Kennzeichen")), String.Empty, reader.GetString("ID_Kennzeichen"))
                            dgv.Rows(i).Cells(3).Value = If(reader.IsDBNull(reader.GetOrdinal("Bezeichnung")), String.Empty, reader.GetString("Bezeichnung"))
                            dgv.Rows(i).Cells(4).Value = If(reader.IsDBNull(reader.GetOrdinal("Kilometer")), String.Empty, reader.GetString("Kilometer"))
                            dgv.Rows(i).Cells(5).Value = If(reader.IsDBNull(reader.GetOrdinal("Datum")), String.Empty, reader.GetString("Datum"))
                            dgv.Rows(i).Cells(6).Value = If(reader.IsDBNull(reader.GetOrdinal("Preis")), String.Empty, reader.GetString("Preis"))
                            dgv.Rows(i).Cells(7).Value = If(reader.IsDBNull(reader.GetOrdinal("Kommentar")), String.Empty, reader.GetString("Kommentar"))
                            dgv.Rows(i).Cells(8).Value = If(reader.IsDBNull(reader.GetOrdinal("Art")), String.Empty, reader.GetString("Art"))
                            SetUserName(If(reader.IsDBNull(reader.GetOrdinal("Bearbeiter")), String.Empty, reader.GetString("Bearbeiter")), i, 9)
                        Else
                            ' Block für CreateReport = True
                            dgv.Rows(i).Cells(1).Value = If(reader.IsDBNull(reader.GetOrdinal("ID_" & art)), 0, reader.GetInt32("ID_" & art))
                            dgv.Rows(i).Cells(2).Value = "Service"
                            dgv.Rows(i).Cells(3).Value = If(reader.IsDBNull(reader.GetOrdinal("ID_Kennzeichen")), String.Empty, reader.GetString("ID_Kennzeichen"))
                            dgv.Rows(i).Cells(4).Value = If(reader.IsDBNull(reader.GetOrdinal("Bezeichnung")), String.Empty, reader.GetString("Bezeichnung"))
                            dgv.Rows(i).Cells(5).Value = If(reader.IsDBNull(reader.GetOrdinal("Kilometer")), String.Empty, reader.GetString("Kilometer"))
                            dgv.Rows(i).Cells(6).Value = If(reader.IsDBNull(reader.GetOrdinal("Datum")), String.Empty, reader.GetString("Datum"))
                            dgv.Rows(i).Cells(7).Value = If(reader.IsDBNull(reader.GetOrdinal("Preis")), String.Empty, reader.GetString("Preis"))
                            dgv.Rows(i).Cells(8).Value = If(reader.IsDBNull(reader.GetOrdinal("Kommentar")), String.Empty, reader.GetString("Kommentar"))
                            dgv.Rows(i).Cells(9).Value = If(reader.IsDBNull(reader.GetOrdinal("Art")), String.Empty, reader.GetString("Art"))
                            SetUserName(If(reader.IsDBNull(reader.GetOrdinal("Bearbeiter")), String.Empty, reader.GetString("Bearbeiter")), i, 10)
                        End If
                    End While
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Fehler beim Abrufen der Daten: " & ex.Message)
        End Try
    End Sub

    Private Sub SetUserName(ByVal userId As String, ByVal rowIndex As Integer, ByVal cellIndex As Integer)
        Dim connection As New MySqlConnection(My.Settings.connectionstring)
        Try
            connection.Open()
            Dim query As String = "SELECT user_name FROM users WHERE id = @UID"
            Using cmd As New MySqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@UID", userId)
                Dim userReader As MySqlDataReader = cmd.ExecuteReader()
                If userReader.Read() Then
                    dgv.Rows(rowIndex).Cells(cellIndex).Value = userReader.GetString("user_name")
                Else
                    dgv.Rows(rowIndex).Cells(cellIndex).Value = "Bearbeiter nicht gefunden"
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Fehler beim Abrufen des Benutzernamens: " & ex.Message)
            SavetoLogFile(ex.Message, "SetUsername")
        Finally
            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If
        End Try
    End Sub

    Private Sub BearbeitenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TSMI_Eintrag_Bearbeiten.Click
        If GetPermission(My.Settings.PermissionKey, 5) Or LoginSetting = False Then
            EntryID = CInt(dgv.CurrentRow.Cells(0).Value)
            DatabaseEntries.Show()
            Select Case True
                Case dgv.CurrentRow.Cells(1).Value.ToString = "Service"
                    DatabaseEntries.CBB_TypeOfEntry.SelectedIndex = 0
                Case dgv.CurrentRow.Cells(1).Value.ToString = "Reparatur"
                    DatabaseEntries.CBB_TypeOfEntry.SelectedIndex = 1
                Case dgv.CurrentRow.Cells(1).Value.ToString = "Sonstiges"
                    DatabaseEntries.CBB_TypeOfEntry.SelectedIndex = 2
            End Select
            DatabaseEntries.CBB_TypeOfEntry.Enabled = False
            DatabaseEntries.TXB_Description.Text = If(dgv.CurrentRow.Cells(3).Value IsNot Nothing, dgv.CurrentRow.Cells(3).Value.ToString(), "")
            DatabaseEntries.TXB_Mileage.Text = If(dgv.CurrentRow.Cells(4).Value IsNot Nothing, dgv.CurrentRow.Cells(4).Value.ToString(), "")
            DatabaseEntries.TXB_Date.Text = If(dgv.CurrentRow.Cells(5).Value IsNot Nothing, dgv.CurrentRow.Cells(5).Value.ToString(), "")
            DatabaseEntries.TXB_Price.Text = If(dgv.CurrentRow.Cells(6).Value IsNot Nothing, dgv.CurrentRow.Cells(6).Value.ToString(), "")
            DatabaseEntries.RTB_Comment.Text = If(dgv.CurrentRow.Cells(7).Value IsNot Nothing, dgv.CurrentRow.Cells(7).Value.ToString(), "")
            DatabaseEntries.Text = "Datenbankeintrag bearbeiten"
            DatabaseEntries.BTN_Save.Text = "Änderung speichern"
        Else
            MsgBox("Keine Berechtigung um Datenbankeinträge zu bearbeiten")
        End If
    End Sub

    Private Sub LöschenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TSMI_Eintrag_Loeschen.Click
        Dim SelectedEntry As String = If(CreateReport = True, dgv.CurrentRow.Cells(4).Value.ToString, dgv.CurrentRow.Cells(3).Value.ToString)

        If GetPermission(My.Settings.PermissionKey, 6) Or LoginSetting = False Then
            Select Case MessageBox.Show(SelectedEntry & " löschen ?", "Daten löschen", MessageBoxButtons.YesNo)
                Case Windows.Forms.DialogResult.Yes
                    DeleteDatabaseEntry()
                Case Windows.Forms.DialogResult.No

            End Select
        Else
            MsgBox("Keine Berechtgung um Datenbankeinträge zu löschen")
        End If

    End Sub

    Private Sub Dgv_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellContentClick
        If e.RowIndex >= 0 Then
            Dim selectedRow As DataGridViewRow = dgv.Rows(e.RowIndex)
        End If
    End Sub

    Private Sub DeleteDatabaseEntry()
        Dim connection As New MySqlConnection(My.Settings.connectionstring)
        Dim location As String = ""
        Dim tabelname As String = ""

        EntryID = CInt(dgv.CurrentRow.Cells(0).Value)
        Select Case True
            Case dgv.CurrentRow.Cells(1).Value.ToString = "Service" Or dgv.CurrentRow.Cells(6).Value.ToString = "Service/Wartung"
                tabelname = "Service"
                location = "ID_Service"
            Case dgv.CurrentRow.Cells(1).Value.ToString = "Reparatur"
                tabelname = "Reparatur"
                location = "ID_Reparatur"
            Case dgv.CurrentRow.Cells(1).Value.ToString = "Sonstiges"
                tabelname = "Sonstiges"
                location = "ID_Sonstiges"
        End Select

        Try
            connection.Open()

            Dim primaryKeyValue As Integer = EntryID

            Dim sql As String = "DELETE FROM " & tabelname & " WHERE " & location & " = @primaryKeyValue"

            Using cmd As New MySqlCommand(sql, connection)
                cmd.Parameters.AddWithValue("@primaryKeyValue", primaryKeyValue)
                cmd.ExecuteNonQuery()
            End Using

            MessageBox.Show("Daten wurden erfolgreich gelöscht.")
            dgv.Rows.Clear()
            FillDGV()
        Catch ex As Exception
            MessageBox.Show("Fehler bei der Datenbankverbindung oder beim Löschen der Zeile: " & ex.Message)
            SavetoLogFile(ex.Message, "DeleteDatabaseEntry")
        Finally
            connection.Close()
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles TSB_UploadFile.Click
        If CBB_SavedCars.SelectedIndex > -1 Then

            If GetPermission(My.Settings.PermissionKey, 8) Then
                UploadFiles.Show()
            Else
                MsgBox("Keine Berechtigung um Datein hochzuladen")
            End If

        Else
            MsgBox("Bitte Fahrzeug auswählen")

        End If
    End Sub

    Private Sub ÖffnenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TSMI_Datei_Oeffnen.Click
        If GetPermission(My.Settings.PermissionKey, 9) = True Or LoginSetting = False Then
            If dgv2.Rows.Count > 0 Then
                Dim tempPath As String = Application.StartupPath & "\temp\"

                If Not System.IO.Directory.Exists(tempPath) Then
                    System.IO.Directory.CreateDirectory(tempPath)
                End If

                Cursor.Current = Cursors.WaitCursor

                If My.Settings.sftp Then
                    SFTP.DownloadandOpenFileSFTP(tempPath & dgv2.CurrentRow.Cells(0).Value.ToString, Path.GetFileName(dgv2.CurrentRow.Cells(2).Value.ToString), Licenseplate)
                Else
                    FTP.DownloadandOpenFileFTP(tempPath & dgv2.CurrentRow.Cells(0).Value.ToString, dgv2.CurrentRow.Cells(2).Value.ToString)
                End If
            End If
        Else
            MsgBox("Keine Berechtigung um Dateien zu öffnen")
        End If
    End Sub

    Private Sub LöschenToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles TSMI_Datei_Loeschen.Click
        If GetPermission(My.Settings.PermissionKey, 10) = True Or LoginSetting = False Then
            If dgv2.Rows.Count > 0 Then
                Select Case MessageBox.Show("Wirklich Löschen?", "Datei unwiderruflich Löschen?", MessageBoxButtons.YesNo)
                    Case Windows.Forms.DialogResult.Yes
                        DeleteFileFromServer(dgv2.CurrentRow.Cells(2).Value.ToString)
                    Case Windows.Forms.DialogResult.No

                End Select
            End If
        Else
            MsgBox("Keine Berechtigung um Datein zu löschen")
        End If
    End Sub

    Sub DeleteFileFromServer(ftpServerUri As String)
        Try
            If My.Settings.sftp Then

                SFTP.DeleteFileFromSFTP(Path.GetFileName(ftpServerUri), Licenseplate)
                SFTP.ListFilesFromSFTPForDGV2(Licenseplate)
            Else

                FTP.DeleteFileFromFTP(ftpServerUri)
                FTP.ListFilesFromFTPForDGV2(Licenseplate)
            End If

            ' Nach erfolgreichem Löschen die Liste aktualisieren
        Catch ex As Exception
            Notify(NI_Error, "Fehler beim Löschen der Datei", ex.Message.ToString(), 10000, ToolTipIcon.Error)
            SavetoLogFile(ex.Message, "DeleteFileFromServer")
        End Try
    End Sub

    Private Sub VeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TSMI_Server_Verbindungen.Click
        If LoginSetting = True Then
            If GetPermission(My.Settings.PermissionKey, 7) Then
                ServerConnection.Show()
            Else

                Select Case True
                    Case Login = True
                        MsgBox("Fehlende Zugriffsberechtigung")
                    Case Login = False
                        MsgBox("Nicht angemeldet")
                End Select
            End If
        Else
            ServerConnection.Show()

        End If

    End Sub

    Private Sub AnmeldungToolStripMenuItem1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub BerichtToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TSMI_Bericht_Einstellungen.Click
        If GetPermission(My.Settings.PermissionKey, 7) = True Then
            ReportSettings.Show()
        Else
            MsgBox("Keine Berechtigung")
        End If

    End Sub

    Private Sub ToolStripLabel1_Click(sender As Object, e As EventArgs) Handles TSL_Neues_Auto.Click
        If GetPermission(My.Settings.PermissionKey, 11) = True Or LoginSetting = False Then
            NewCar.Show()
        Else
            MsgBox("Keine Berechtigung um ein neues Auto anzulegen")
        End If

    End Sub

    Private Sub EinträgeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EinträgeToolStripMenuItem.Click
        SearchEntries.Show()
    End Sub

    Private Sub TeilenummernToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TeilenummernToolStripMenuItem.Click
        Partnumber.Show()
    End Sub

    Private Sub Acr122u_CardInserted(ByVal reader As PCSC.ICardReader)
        If EditData = False Then
            UID = BitConverter.ToString(acr122u.GetUID(reader)).Replace("-", "")
            GetUserData(UID)
        End If

    End Sub

    Public Sub GetUserData(id As String)
        Try
            Using connection As New MySqlConnection(My.Settings.connectionstring)
                connection.Open()
                Dim query As String = "SELECT user_name, id, PermissionRole FROM users WHERE id = @ID"

                Using cmd As New MySqlCommand(query, connection)
                    cmd.Parameters.AddWithValue("@ID", id)

                    Dim reader As MySqlDataReader = cmd.ExecuteReader
                    If reader.Read() Then

                        InvokeToolStripItem(ToolStrip1, LBL_Login, "Angemeldet: " & reader.GetString("user_name"))
                        My.Settings.Username = reader.GetString("user_name")
                        My.Settings.PermissionKey = GetPermissionKeyFromRole(reader.GetString("PermissionRole"))
                        My.Settings.UID = id
                        Login = True
                        LBL_Logout.Visible = True
                    Else
                        InvokeToolStripItem(ToolStrip1, LBL_Login, "Benutzer nicht regestriert")
                        LBL_Logout.Visible = False
                    End If

                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
            SavetoLogFile(ex.Message, "GetUserData")
        End Try
    End Sub

    Private Sub InvokeReq(Control As Control, Text As String)
        If Control.InvokeRequired Then
            Control.Invoke(Sub() InvokeReq(Control, Text))
        Else
            Control.Text = Text
        End If
    End Sub

    Private Sub InvokeToolStripItem(toolStrip As ToolStrip, item As ToolStripItem, text As String)
        If toolStrip.InvokeRequired Then
            toolStrip.Invoke(Sub() item.Text = text)
            toolStrip.Invoke(Sub() item.Margin = New Padding(0, 0, 10, 0))
        Else
            item.Text = text
            item.Margin = New Padding(0, 0, 10, 0)
        End If
    End Sub

    Private Sub LBL_Logout_Click(sender As Object, e As EventArgs) Handles LBL_Logout.Click
        My.Settings.PermissionKey = "000000000000"
        My.Settings.Username = ""

        My.Settings.Save()
        LBL_Login.Text = "Anmelden"
        LBL_Logout.Visible = False
        Login = False
        If CheckExistTableUsers("users") Then
            LBL_Login.Visible = True
            LoginSetting = True
            Try
                acr122u.Init(False, 50, 4, 4, 200)
                AddHandler acr122u.CardInserted, AddressOf Acr122u_CardInserted
            Catch ex As Exception

            End Try

            If My.Settings.Username = "" Then

                Authent.Show()
                Me.Close()
            End If
        End If

    End Sub

    Function GetPermission(Key As String, Index As Integer) As Boolean
        If Index <= 0 OrElse Index > Key.Length Then
            Return False
        End If

        If LoginSetting = True Then

            Dim permission As Char = Key(Index - 1)

            ' Prüfen, ob der Wert "1" ist
            If permission = "1" Then
                Return True
            Else
                Return False
            End If
        Else
            Return True
        End If
    End Function

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

    Private Function NextInspectionDue(year As Integer, month As Integer) As Boolean

        If year <= Now.Year And month <= Now.Month Then
            Return True
        End If

        If year = Now.Year And month <= Now.Month Then
            Return True
        End If

        Return False

    End Function

    Private Sub LBL_Login_Click(sender As Object, e As EventArgs) Handles LBL_Login.Click
        Authent.Show()
        Me.Close()
    End Sub

    Private Sub LBL_NewCustomer_Click(sender As Object, e As EventArgs) Handles LBL_NewCustomer.Click
        If GetPermission(My.Settings.PermissionKey, 11) = True Or LoginSetting = False Then
            NewCustomer.Show()
        Else
            MsgBox("Keine Berechtigung um ein neuen Kunden anzulegen")
        End If

    End Sub

    Private Sub LBL_EditCustomer_Click(sender As Object, e As EventArgs) Handles LBL_EditCustomer.Click
        If GetPermission(My.Settings.PermissionKey, 11) = True Or LoginSetting = False Then
            EditCustomers.Show()
        Else
            MsgBox("Keine Berechtigung um Kunden zu bearbeiten")
        End If
    End Sub

    Private Sub PB_Adressbook_Click(sender As Object, e As EventArgs) Handles PB_Adressbook.Click
        Dim selectedCar As CarInfo = CType(CBB_SavedCars.SelectedItem, CarInfo)
        If selectedCar IsNot Nothing Then
            CustomID = selectedCar.KundenId
            EditCustomers.Show()
        Else
            MsgBox("Bitte Kennzeichen auswählen", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub NachUpdateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NachUpdateToolStripMenuItem.Click
        Dim UpdaterPath As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ADBUpdater\Autodatenbank Updater.exe")
        Try
            Process.Start(UpdaterPath)
        Catch ex As Exception
            MsgBox("Updater konnte nicht gefunden werden, bitte versuchen Sie die Anwendung neu zu Installieren " & UpdaterPath, MsgBoxStyle.Critical, Title:="Schwerer Fehler 0x00001")
        End Try
    End Sub

    Private Sub BTN_DeleteCarData_Click(sender As Object, e As EventArgs) Handles BTN_DeleteCarData.Click
        Dim result As DialogResult = MessageBox.Show("Möchten Sie dieses Auto wirklich löschen?", "Löschen bestätigen", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            ' Verbindungszeichenfolge zur Datenbank
            Dim connection As New MySqlConnection(My.Settings.connectionstring)

            Try
                connection.Open()

                ' Primärschlüsselwert aus dem Textfeld
                Dim primaryKeyValue As String = TXB_LicensePlate.Text

                ' SQL-Abfrage zum Löschen des Eintrags
                Dim query As String = "DELETE FROM Autos WHERE Kennzeichen = @PrimaryKeyValue"

                Using cmd As New MySqlCommand(query, connection)
                    ' Parameter für die Abfrage festlegen
                    cmd.Parameters.AddWithValue("@PrimaryKeyValue", primaryKeyValue)

                    ' Ausführen der Abfrage
                    Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

                    ' Überprüfung, ob ein Eintrag gelöscht wurde
                    If rowsAffected > 0 Then
                        MsgBox("Der Eintrag wurde erfolgreich gelöscht.")
                    Else
                        Notify(NI_Error, "Fehler", "beim löschen des Eintrags", 10000, ToolTipIcon.Error)
                    End If
                End Using
            Catch ex As Exception
                Notify(NI_Error, "Fehler beim Löschen der Daten", ex.Message.ToString, 10000, ToolTipIcon.Error)
                SavetoLogFile(ex.Message, "DeleteCarData")
            Finally
                connection.Close()
            End Try
        End If
    End Sub

    Private Sub BerichtErstellenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TSMI_Bericht_erstellen.Click
        If CreateReport = False Then
            CreateReport = True
            BTN_CreateReport.Visible = True
            lbl_CreateReport.Visible = True
        Else
            CreateReport = False
            BTN_CreateReport.Visible = False
            lbl_CreateReport.Visible = False
        End If

        If My.Settings.sftp = True Then
            SFTP.ListFilesFromSFTPForDGV2(Licenseplate)
        Else
            FTP.ListFilesFromFTPForDGV2(Licenseplate)
        End If

        CreateDGV()
        FillDGV()
    End Sub

    Private Sub BTN_CreateReport_Click(sender As Object, e As EventArgs) Handles BTN_CreateReport.Click
        ReportSelect.Clear()

        For Each row As DataGridViewRow In dgv.Rows
            If Not row.IsNewRow Then
                Dim isChecked As Boolean = Convert.ToBoolean(row.Cells("InBerichtAufnehmen").Value)
                If isChecked Then
                    ReportSelect.Add(row.Index.ToString)
                End If
            End If
        Next

        If ReportSelect.Count > 100 Then
            MsgBox("Es können nur 3 Einträge ausgewählt werden.")
        ElseIf ReportSelect.Count < 1 Then
            MsgBox("Es muss mindestens 1 Eintrag ausgewählt werden")
        Else
            CreateReportForm.Show()
        End If

    End Sub

    Private Sub InfoZuSchlüsselnummerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InfoZuSchlüsselnummerToolStripMenuItem.Click
        KeyNumbers.Show()
    End Sub

    Function GetCurrentVersion(input As String) As String
        If Len(input) < 3 Then
            input = input.PadLeft(3, "0"c)
        End If


        Dim part1 As String = input.Substring(0, 1) ' Erstes Zeichen
        Dim part2 As String = input.Substring(1, 1) ' Zweites Zeichen
        Dim part3 As String = input.Substring(2)    ' Restliche Zeichen

        ' Setzt die Teile zusammen
        Dim result As String = part1 & "." & part2 & "." & part3

        Return result
    End Function

    Private Sub Autodatenbank_ResizeEnd(sender As Object, e As EventArgs) Handles Me.ResizeEnd
        FLP_Main.Size = New Size(291, Me.Size.Height - 34)
        If Me.Size.Height > 1024 Or Me.Size.Width > 1600 Then
            dgv.Size = New Size(CInt(Me.Width - 361), CInt(Me.Height * 0.51171875))

            dgv2.Location = New Point(333, dgv.Location.Y + dgv.Height + 60)
            dgv2.Size = New Size(CInt(Me.Width - 361), CInt(Me.Height * 0.29980469))

            Label15.Location = New Point(333, dgv2.Location.Y - 21)

            lbl_CreateReport.Location = New Point((Me.Width - lbl_CreateReport.Size.Width) - 28, dgv.Location.Y + dgv.Size.Height + 7)
            BTN_CreateReport.Location = New Point((Me.Width - BTN_CreateReport.Width) - 28, lbl_CreateReport.Location.Y + 19)
            dgv.Columns("Kommentar").Width = dgv.Size.Width - 7 * 100 - 50

        End If

        If Me.Size.Height <= 1024 Or Me.Size.Width <= 1600 Then
            dgv.Size = New Size(1239, 524)

            dgv2.Location = New Point(333, 646)
            dgv2.Size = New Size(1239, 307)

            Label15.Location = New Point(333, 625)
            lbl_CreateReport.Location = New Point((Me.Width - lbl_CreateReport.Size.Width) - 28, 593)
            BTN_CreateReport.Location = New Point((Me.Width - BTN_CreateReport.Width) - 28, 612)
            dgv.Columns("Kommentar").Width = dgv.Size.Width - 7 * 100 - 50

        End If

    End Sub

    Private Sub Autodatenbank_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged

        ' If Me.WindowState = FormWindowState.Maximized Then

        Try

            FLP_Main.Size = New Size(291, Me.Size.Height - 34)
            If Me.Size.Height > 1024 Or Me.Size.Width > 1600 Then
                dgv.Size = New Size(CInt(Me.Width - 361), CInt(Me.Height * 0.51171875))

                dgv2.Location = New Point(333, dgv.Location.Y + dgv.Height + 60)
                dgv2.Size = New Size(CInt(Me.Width - 361), CInt(Me.Height * 0.3))

                Label15.Location = New Point(333, dgv2.Location.Y - 21)

                lbl_CreateReport.Location = New Point((Me.Width - lbl_CreateReport.Size.Width) - 28, dgv.Location.Y + dgv.Size.Height + 7)
                BTN_CreateReport.Location = New Point((Me.Width - BTN_CreateReport.Width) - 28, lbl_CreateReport.Location.Y + 19)
                If dgv.Columns.Contains("Kommentar") Then
                    dgv.Columns("Kommentar").Width = dgv.Size.Width - 7 * 100 - 50
                End If

            End If

            If Me.Size.Height <= 1024 Or Me.Size.Width <= 1600 Then
                dgv.Size = New Size(1239, 524)

                dgv2.Location = New Point(333, 646)
                dgv2.Size = New Size(1239, 307)

                Label15.Location = New Point(333, 625)
                lbl_CreateReport.Location = New Point((Me.Width - lbl_CreateReport.Size.Width) - 28, 593)
                BTN_CreateReport.Location = New Point((Me.Width - BTN_CreateReport.Width) - 28, 612)
                If dgv.Columns.Contains("Kommentar") Then
                    dgv.Columns("Kommentar").Width = dgv.Size.Width - 7 * 100 - 50
                End If

            End If
        Catch ex As Exception

        End Try
        'End If
    End Sub

    Private Sub AnmeldungToolStripMenuItem1_Click_1(sender As Object, e As EventArgs) Handles TSMI_Admin.Click
        If LoginSetting = True Then
            If GetPermission(My.Settings.PermissionKey, 1) OrElse GetPermission(My.Settings.PermissionKey, 2) OrElse GetPermission(My.Settings.PermissionKey, 3) Then
                AdminSettings.Show()
                EditData = True
            Else
                Select Case True
                    Case Login = True
                        MsgBox("Fehlende Zugriffsberechtigung")
                    Case Login = False
                        MsgBox("Nicht angemeldet")
                End Select
            End If
        Else
            AdminSettings.Show()
            EditData = True
        End If
    End Sub

    Private Sub AnsichtToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AnsichtToolStripMenuItem1.Click
        ViewSettings.Show()
    End Sub

    Private Sub PRNummerEntschlüsselnToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PRNummerEntschlüsselnToolStripMenuItem.Click
        PR.Show()
    End Sub

    Private Sub BTN_ShowPRNumbers_Click(sender As Object, e As EventArgs) Handles BTN_ShowPRNumbers.Click
        If Not String.IsNullOrEmpty(My.Settings.LicensePlate) Then
            LISTPR.Show()
        Else
            MsgBox("Bitte Auto auswählen um PR-Nummern anzuzeigen")
        End If

    End Sub

    Private Async Sub TSB_Issue_Click(sender As Object, e As EventArgs) Handles TSB_Issue.Click
        Select Case MessageBox.Show("Logfile übermitteln und Fehler Melden ?", "Fehler melden?", MessageBoxButtons.YesNo)
            Case Windows.Forms.DialogResult.Yes
                Await SendLogFileAsync()
        End Select
    End Sub

    Private Sub FTPMenuStrip_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles FTPMenuStrip.Opening
        Try
            ' Leere die vorherigen Einträge, um Duplikate zu vermeiden
            TSMI_Service.DropDownItems.Clear()
            TSMI_Repair.DropDownItems.Clear()
            TSMI_Other.DropDownItems.Clear()
            If dgv2.Rows.Count > 0 Then
                If dgv2.CurrentRow.Cells(2).Value IsNot Nothing AndAlso dgv2.CurrentRow.Cells(2).Value IsNot DBNull.Value Then
                    CurrentFTPLink = dgv2.CurrentRow.Cells(2).Value.ToString
                End If
            End If
            ' Iteriere über die DataGridView-Zeilen
            For Each row As DataGridViewRow In dgv.Rows
                Dim item As New FTPEntryInfo With {
                .Bezeichnung = row.Cells(3).Value.ToString(),
                .Tabelle = row.Cells(1).Value.ToString(),
                .ID = row.Cells(0).Value.ToString()
            }

                ' Erstelle das ToolStripMenuItem
                Dim menuItem As New ToolStripMenuItem(item.Bezeichnung)
                menuItem.Tag = item ' Speichere das EntryInfo-Objekt im Tag-Feld
                AddHandler menuItem.Click, AddressOf MenuItem_Click ' Event-Handler für das Click-Ereignis hinzufügen

                ' Füge das Menüitem dem passenden DropDown hinzu
                Select Case item.Tabelle
                    Case "Service"
                        TSMI_Service.DropDownItems.Add(menuItem)
                    Case "Reparatur"
                        TSMI_Repair.DropDownItems.Add(menuItem)
                    Case "Sonstiges"
                        TSMI_Other.DropDownItems.Add(menuItem)
                End Select
            Next
        Catch ex As Exception
            SavetoLogFile(ex.Message, "MenuStrip")
        End Try
    End Sub

    Private Sub MenuItem_Click(sender As Object, e As EventArgs)
        ' Cast das Sender-Objekt zu ToolStripMenuItem
        Dim clickedItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)

        ' Hole das gespeicherte EntryInfo-Objekt aus dem Tag-Feld
        Dim entry As FTPEntryInfo = CType(clickedItem.Tag, FTPEntryInfo)

        ' Führe die gewünschte Aktion aus, z.B. zeige eine Nachricht oder führe eine Datenbankabfrage durch

        Select Case True
            Case entry.Tabelle = "Service"
                AddLinkToDatabase(CurrentFTPLink, entry.Tabelle, "ID_Service", CInt(entry.ID))
            Case entry.Tabelle = "Reparatur"
                AddLinkToDatabase(CurrentFTPLink, entry.Tabelle, "ID_Reparatur", CInt(entry.ID))
            Case entry.Tabelle = "Sonstiges"
                AddLinkToDatabase(CurrentFTPLink, entry.Tabelle, "ID_Sonstiges", CInt(entry.ID))
        End Select

    End Sub

    Private Sub AddLinkToDatabase(link As String, tableName As String, tableid As String, recordID As Integer)
        Dim Linklist As New List(Of String)
        Try
            ' Verbindung zur Datenbank herstellen
            Using conn As New MySqlConnection(My.Settings.connectionstring)
                conn.Open()

                ' Abfrage, um den aktuellen Wert der Spalte 'Datein' zu bekommen
                Using cmdSelect As New MySqlCommand($"SELECT Datein FROM {tableName} WHERE {tableid} = @recordID", conn)
                    cmdSelect.Parameters.AddWithValue("@recordID", recordID)

                    ' Aktuelle Links in der Datenbank abrufen
                    Dim currentLinks As String = Convert.ToString(cmdSelect.ExecuteScalar())

                    ' Überprüfen, ob aktuelle Links vorhanden sind und sie zur Liste hinzufügen
                    If Not String.IsNullOrEmpty(currentLinks) Then
                        Linklist.AddRange(currentLinks.Split(";"c))
                    End If

                    ' Prüfen, ob der neue Link bereits vorhanden ist
                    For Each item As String In Linklist
                        If item = link Then
                            MsgBox("Datei ist bereits hinzugefügt worden")
                            Return
                        End If
                    Next

                    ' Wenn der Link nicht vorhanden ist, füge ihn hinzu
                    Linklist.Add(link)

                    ' Die aktualisierte Liste in die Datenbank schreiben
                    currentLinks = String.Join(";", Linklist)

                    ' Abfrage, um den neuen Wert in die Spalte zu schreiben
                    Using cmdUpdate As New MySqlCommand($"UPDATE {tableName} SET Datein = @newLinks WHERE {tableid} = @recordID", conn)
                        cmdUpdate.Parameters.AddWithValue("@newLinks", currentLinks)
                        cmdUpdate.Parameters.AddWithValue("@recordID", recordID)

                        cmdUpdate.ExecuteNonQuery()
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Fehler beim Hinzufügen des Links: " & ex.Message)
        End Try
    End Sub

    Private Sub EintragAnzeigenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EintragAnzeigenToolStripMenuItem.Click

        Dim i As Integer = -1

        For Each col As DataGridViewColumn In dgv.Columns
            If col.HeaderText = "Bearbeiter" Then
                i = col.Index
                Exit For
            End If
        Next

        ' Prüfen, ob eine Zeile ausgewählt ist und i einen gültigen Wert hat
        If dgv.CurrentRow IsNot Nothing AndAlso dgv.CurrentRow.Index > -1 AndAlso i > -1 Then
            ' Erstelle ein neues MySQLEntryInfo-Objekt mit den Werten der ausgewählten Zeile
            Dim item As New MySQLEntryInfo With {
                .ID = CInt(dgv.CurrentRow.Cells(0).Value),
                .IDTabelle = dgv.CurrentRow.Cells(1).Value.ToString,
                .Kennzeichen = dgv.CurrentRow.Cells(2).Value.ToString,
                .Bezeichnung = dgv.CurrentRow.Cells(3).Value.ToString,
                .Kilometer = dgv.CurrentRow.Cells(4).Value.ToString,
                .Datum = dgv.CurrentRow.Cells(5).Value.ToString,
                .Preis = dgv.CurrentRow.Cells(6).Value.ToString,
                .Kommentar = dgv.CurrentRow.Cells(7).Value.ToString,
                .Art = dgv.CurrentRow.Cells(8).Value.ToString,
                .Bearbeiter = dgv.CurrentRow.Cells(i).Value.ToString
            }
            If item IsNot Nothing Then
                ShowCompleteEntry.Show()
                ShowCompleteEntry.SetValuesInTextboxes(item)
            End If
        End If

    End Sub

    Private Sub Autodatenbank_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F2 Then
            isF2Pressed = True
        End If

        If e.KeyCode = Keys.L Then
            isLPressed = True
        End If

        If isF2Pressed AndAlso isLPressed Then
            BTN_DeleteCarData.PerformClick()
            isF2Pressed = False
            isLPressed = False
        End If

    End Sub

    Private Sub Autodatenbank_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.F2 Then
            isF2Pressed = False
        End If

        If e.KeyCode = Keys.D Then
            isLPressed = False
        End If
    End Sub

    Private Sub ToolStripDropDownButton1_DropDownOpening(sender As Object, e As CancelEventArgs)
        ' Verhindert das Öffnen des Dropdown-Menüs

    End Sub

    Private Sub LogFileÖffnenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TSMI_LogFile_Oeffnen.Click
        If LoginSetting = True Then
            If GetPermission(My.Settings.PermissionKey, 7) Then
                OpenLogFile()
            Else

                Select Case True
                    Case Login = True
                        MsgBox("Fehlende Zugriffsberechtigung")
                    Case Login = False
                        MsgBox("Nicht angemeldet")
                End Select
            End If
        Else
            OpenLogFile()

        End If
    End Sub



    Private Sub ErstellenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TSM_Benutzer_Erstellen.Click
        NewUser.Show()
    End Sub

    Private Sub TSM_Benutzer_Bearbeiten_Click(sender As Object, e As EventArgs) Handles TSM_Benutzer_Bearbeiten.Click
        EditUser.Show()
    End Sub

    Private Sub TSMI_MyCar_Click(sender As Object, e As EventArgs) Handles TSMI_MyCar.Click
        MyCar.Show()
    End Sub

    Private Sub TSMI_Checklistedit_Click(sender As Object, e As EventArgs) Handles TSMI_Checklistedit.Click
        ChecklistEdit.Show()
    End Sub

    Private Sub TSMI_ChecklistOpen_Click(sender As Object, e As EventArgs) Handles TSMI_ChecklistOpen.Click
        If CBB_SavedCars.SelectedIndex > -1 Then
            WorkWithChecklist.Show()
        Else
            MsgBox("Bitte wähle ein Auto aus")
        End If

    End Sub
End Class

Public Class CarInfo
    Public Property Kennzeichen As String
    Public Property KundenId As Integer
    Public Property KundenName As String ' Neue Eigenschaft für den Kundennamen

    Public Sub New(kennzeichen As String, kundenId As Integer, kundenName As String)
        Me.Kennzeichen = kennzeichen
        Me.KundenId = kundenId
        Me.KundenName = kundenName
    End Sub

    Public Overrides Function ToString() As String
        ' Anzeigeformat für die ComboBox
        Return $"{Kennzeichen} || {KundenName}"
    End Function

End Class

Public Class FTPEntryInfo
    Public Property Bezeichnung As String
    Public Property Tabelle As String
    Public Property ID As String

    Public Overrides Function Tostring() As String
        Return Bezeichnung
    End Function

End Class

Public Class MySQLEntryInfo
    Public Property Kennzeichen As String
    Public Property Bezeichnung As String
    Public Property Kilometer As String
    Public Property Datum As String
    Public Property Preis As String
    Public Property Art As String
    Public Property Bearbeiter As String
    Public Property Kommentar As String
    Public Property ID As Integer
    Public Property IDTabelle As String

End Class