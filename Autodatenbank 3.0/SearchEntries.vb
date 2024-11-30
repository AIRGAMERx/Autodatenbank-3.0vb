Imports System.Net
Imports MySqlConnector


Public Class SearchEntries
    Dim uid As String = ""
    Private Sub SearchEntries_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadOverallSettings()

        KeyPreview = True
        CreateDGV()
        DGV.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        TXB_SearchWord.Focus()
    End Sub

    Private Sub CreateDGV()

        DGV.Columns.Add("Kennzeichen", "Kennzeichen")
        DGV.Columns.Add("Bezeichnung", "Bezeichnung")
        DGV.Columns.Add("Kilometer", "Kilometer")
        DGV.Columns.Add("Datum", "Datum")
        DGV.Columns.Add("Preis", "Preis")
        DGV.Columns.Add("Kommentar", "Kommentar")
        DGV.Columns.Add("Art", "Art")
        DGV.Columns.Add("Dateipfad", "Dateipfad")
        DGV.Columns.Add("ID", "ID")
        DGV.Columns.Add("Bearbeiter", "Bearbeiter")

        DGV.Columns(8).Visible = False



    End Sub


    Private Sub Search()
        Dim Suchwort As String
        DGV.Rows.Clear()

        If cb_editor.Checked AndAlso GetID(TXB_SearchWord.Text) IsNot Nothing Then
            uid = GetID(TXB_SearchWord.Text)
            Suchwort = uid
        Else

            Suchwort = TXB_SearchWord.Text
        End If


        Dim columnsrep As String = "ID_Reparatur,ID_Kennzeichen,Bezeichnung,Datum,Preis,Kommentar,Art,Bearbeiter"
        Dim ausgewaehlteSpaltenrep As String() = columnsrep.Split(","c)


        Using connection As New MySqlConnection(My.Settings.connectionstring)
            connection.Open()
            Dim whereCondition As String
            If cb_editor.Checked Then
                whereCondition = $"Bearbeiter = '{Suchwort}'"
            Else
                whereCondition = String.Join(" OR ", ausgewaehlteSpaltenrep.Select(Function(s) $"{s} LIKE '%{Suchwort}%'"))
            End If
            Dim query As String = $"SELECT * FROM Reparatur WHERE {whereCondition}"

            Using cmd As New MySqlCommand(query, connection)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        ' Hier wird eine neue Zeile für jeden Eintrag erstellt
                        Dim i As Integer = DGV.Rows.Add()


                        DGV.Rows(i).Cells(0).Value = reader.GetString("ID_Kennzeichen")
                        DGV.Rows(i).Cells(1).Value = reader.GetString("Bezeichnung")
                        DGV.Rows(i).Cells(2).Value = reader.GetString("Kilometer")
                        DGV.Rows(i).Cells(3).Value = reader.GetString("Datum")
                        DGV.Rows(i).Cells(4).Value = reader.GetString("Preis")
                        DGV.Rows(i).Cells(5).Value = reader.GetString("Kommentar")
                        DGV.Rows(i).Cells(6).Value = reader.GetString("Art")
                        DGV.Rows(i).Cells(8).Value = reader.GetInt32("ID_Reparatur")
                        DGV.Rows(i).Cells(9).Value = GetUsername(reader.GetString("Bearbeiter").ToString)
                    End While
                End Using
            End Using

        End Using



        Dim columnsserv As String = "ID_Service,ID_Kennzeichen,Bezeichnung,Datum,Preis,Kommentar,Art"
        Dim ausgewaehlteSpaltenserv As String() = columnsserv.Split(","c)


        Using connection As New MySqlConnection(My.Settings.connectionstring)
            connection.Open()
            Dim whereCondition As String
            If cb_editor.Checked Then
                whereCondition = $"Bearbeiter = '{Suchwort}'"
            Else
                whereCondition = String.Join(" OR ", ausgewaehlteSpaltenserv.Select(Function(s) $"{s} LIKE '%{Suchwort}%'"))
            End If

            Dim query As String = $"SELECT * FROM Service WHERE {whereCondition}"

            Using cmd As New MySqlCommand(query, connection)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        ' Hier wird eine neue Zeile für jeden Eintrag erstellt
                        Dim i As Integer = DGV.Rows.Add()


                        DGV.Rows(i).Cells(0).Value = reader.GetString("ID_Kennzeichen")
                        DGV.Rows(i).Cells(1).Value = reader.GetString("Bezeichnung")
                        DGV.Rows(i).Cells(2).Value = reader.GetString("Kilometer")
                        DGV.Rows(i).Cells(3).Value = reader.GetString("Datum")
                        DGV.Rows(i).Cells(4).Value = reader.GetString("Preis")
                        DGV.Rows(i).Cells(5).Value = reader.GetString("Kommentar")
                        DGV.Rows(i).Cells(6).Value = reader.GetString("Art")
                        DGV.Rows(i).Cells(8).Value = reader.GetInt32("ID_Service")
                        DGV.Rows(i).Cells(9).Value = GetUsername(reader.GetString("Bearbeiter").ToString)
                    End While
                End Using
            End Using

        End Using



        Dim columnsson As String = "ID_Sonstiges,ID_Kennzeichen,Bezeichnung,Datum,Preis,Kommentar,Art"
        Dim ausgewaehlteSpaltenson As String() = columnsson.Split(","c)


        Using connection As New MySqlConnection(My.Settings.connectionstring)
            connection.Open()
            Dim whereCondition As String
            If cb_editor.Checked Then
                whereCondition = $"Bearbeiter = '{Suchwort}'"
            Else
                whereCondition = String.Join(" OR ", ausgewaehlteSpaltenson.Select(Function(s) $"{s} LIKE '%{Suchwort}%'"))
            End If

            Dim query As String = $"SELECT * FROM Sonstiges WHERE {whereCondition}"

            Using cmd As New MySqlCommand(query, connection)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        ' Hier wird eine neue Zeile für jeden Eintrag erstellt
                        Dim i As Integer = DGV.Rows.Add()


                        DGV.Rows(i).Cells(0).Value = reader.GetString("ID_Kennzeichen")
                        DGV.Rows(i).Cells(1).Value = reader.GetString("Bezeichnung")
                        DGV.Rows(i).Cells(2).Value = reader.GetString("Kilometer")
                        DGV.Rows(i).Cells(3).Value = reader.GetString("Datum")
                        DGV.Rows(i).Cells(4).Value = reader.GetString("Preis")
                        DGV.Rows(i).Cells(5).Value = reader.GetString("Kommentar")
                        DGV.Rows(i).Cells(6).Value = reader.GetString("Art")
                        DGV.Rows(i).Cells(8).Value = reader.GetInt32("ID_Sonstiges")
                        DGV.Rows(i).Cells(9).Value = GetUsername(reader.GetString("Bearbeiter").ToString)
                    End While
                End Using
            End Using

        End Using

        If CB_SearchOnFTP.Checked = False Then
            If DGV.Rows.Count > 0 Then
                Me.Text = "Suchen     Es wurden " & DGV.Rows.Count & " Einträge gefunden"
            ElseIf DGV.Rows.Count = 1 Then
                Me.Text = "Suchen     Es wurde 1 Eintrag gefunden"
            Else
                Me.Text = "Suchen     Es wurden keine Einträge gefunden"
            End If
        End If





    End Sub

    Public Function GetID(Username As String) As String

        Try
            Using connection As New MySqlConnection(My.Settings.connectionstring)
                connection.Open()
                Dim query As String = "SELECT id FROM users WHERE user_name = @user_name"

                Using cmd As New MySqlCommand(query, connection)
                    cmd.Parameters.AddWithValue("@user_name", Username)

                    Dim reader As MySqlDataReader = cmd.ExecuteReader
                    If reader.Read() Then


                        Return reader.GetString("id").ToString


                    Else

                    End If


                End Using
            End Using
        Catch ex As Exception
            Return Nothing

            SavetoLogFile(ex.Message, "GetIDBySearching")
        End Try



        Return Nothing




    End Function

    Public Function GetUsername(ID As String) As String
        Try
            Using connection As New MySqlConnection(My.Settings.connectionstring)
                connection.Open()
                Dim query As String = "SELECT user_name FROM users WHERE id = @id"
                Using cmd As New MySqlCommand(query, connection)
                    cmd.Parameters.AddWithValue("@id", ID)

                    Dim reader As MySqlDataReader = cmd.ExecuteReader
                    If reader.Read() Then


                        Return reader.GetString("user_name").ToString


                    Else

                    End If


                End Using
            End Using
        Catch ex As Exception
            Return Nothing
        End Try



        Return Nothing

    End Function



    Private Sub SearchInFolder(folderUri As String, username As String, password As String, searchTerm As String, Optional depth As Integer = 0)
        Dim maxRecursionDepth As Integer = 2
        If depth >= maxRecursionDepth Then ' MaxRecursionDepth ist eine Konstante, die Sie definieren können, um die maximale Rekursionstiefe anzugeben
            Return ' Beenden Sie die Rekursion, wenn die maximale Tiefe erreicht ist
        End If

        Dim subfolderUri As String = ""
        Dim request As FtpWebRequest = DirectCast(WebRequest.Create(folderUri), FtpWebRequest)
        request.Method = WebRequestMethods.Ftp.ListDirectoryDetails
        request.Credentials = New NetworkCredential(username, password)

        Try
            Using response As FtpWebResponse = DirectCast(request.GetResponse(), FtpWebResponse)
                Using responseStream As System.IO.Stream = response.GetResponseStream()
                    Using reader As New System.IO.StreamReader(responseStream)
                        While Not reader.EndOfStream
                            Dim line As String = reader.ReadLine()
                            Dim itemName As String = ""

                            If line.Contains(".") Then
                                ' Es handelt sich um eine Datei, hier könntest du nach dem Suchwort filtern
                                If line.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) <> -1 Then
                                    ParseDirectoryListingLine(line, itemName)
                                    Dim i As Integer = DGV.Rows.Add()
                                    ' Füge die Daten in die DataGridView ein (angepasst nach deiner Datenstruktur)
                                    DGV.Rows(i).Cells(0).Value = GetDirName(subfolderUri)
                                    DGV.Rows(i).Cells(1).Value = System.IO.Path.GetFileName(itemName)
                                    DGV.Rows(i).Cells(7).Value = My.Settings.Ftpserveruri & "/" & GetDirName(subfolderUri) & "/" & itemName
                                End If
                            Else
                                ' Es handelt sich um einen Ordner, rekursiv in den Ordner gehen
                                subfolderUri = $"{folderUri}/{line}"
                                SearchInFolder(subfolderUri, username, password, searchTerm, depth + 1) ' Rekursiver Aufruf mit erhöhter Tiefe
                            End If
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            Console.WriteLine($"Fehler beim Zugriff auf {folderUri}: {ex.Message}")
            SavetoLogFile(ex.Message, "SearchInFolder")
        End Try
    End Sub

    Private Sub ParseDirectoryListingLine(line As String, ByRef itemName As String)
        ' Finde den Index des letzten Wortes (Dateiname)
        Dim lastSpaceIndex As Integer = line.LastIndexOf(" ")
        If lastSpaceIndex > 0 Then
            itemName = line.Substring(lastSpaceIndex + 1)
        End If
    End Sub

    Private Sub Suche_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        If e.KeyChar = ChrW(13) And TXB_SearchWord.Focused Then
            BTN_SearchEntries.PerformClick()
        End If
    End Sub

    Private Function GetDirName(paths As String) As String
        Dim lastSpaceIndex As Integer = paths.LastIndexOf(" ")

        If lastSpaceIndex > 0 Then
            Dim complete As String = paths.Substring(lastSpaceIndex + 1)
            Return complete.Substring(0, complete.Length - 1)
        Else
            Return " "
        End If
    End Function

    Private Sub Dgv_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV.CellContentClick
        If e.RowIndex >= 0 Then
            Dim selectedRow As DataGridViewRow = DGV.Rows(e.RowIndex)
        End If
    End Sub

    Private Sub BearbeitenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BearbeitenToolStripMenuItem.Click
        If DGV.CurrentRow.Cells(7).Value Is Nothing Then
            If Autodatenbank.GetPermission(My.Settings.PermissionKey, 5) Or Autodatenbank.LoginSetting = False Then
                Autodatenbank.EntryID = CInt(DGV.CurrentRow.Cells(8).Value)
                DatabaseEntries.Show()
                Select Case True
                    Case DGV.CurrentRow.Cells(6).Value.ToString = "Service" Or DGV.CurrentRow.Cells(6).Value.ToString = "Service/Wartung"
                        DatabaseEntries.CBB_TypeOfEntry.SelectedIndex = 0
                    Case DGV.CurrentRow.Cells(6).Value.ToString = "Reparatur"
                        DatabaseEntries.CBB_TypeOfEntry.SelectedIndex = 1
                    Case DGV.CurrentRow.Cells(6).Value.ToString = "Sonstiges"
                        DatabaseEntries.CBB_TypeOfEntry.SelectedIndex = 2
                End Select
                DatabaseEntries.CBB_TypeOfEntry.Enabled = False
                DatabaseEntries.TXB_Description.Text = If(DGV.CurrentRow.Cells(1).Value IsNot Nothing, DGV.CurrentRow.Cells(1).Value.ToString(), "")
                DatabaseEntries.TXB_Mileage.Text = If(DGV.CurrentRow.Cells(2).Value IsNot Nothing, DGV.CurrentRow.Cells(2).Value.ToString(), "")
                DatabaseEntries.TXB_Date.Text = If(DGV.CurrentRow.Cells(3).Value IsNot Nothing, DGV.CurrentRow.Cells(3).Value.ToString(), "")
                DatabaseEntries.TXB_Price.Text = If(DGV.CurrentRow.Cells(4).Value IsNot Nothing, DGV.CurrentRow.Cells(4).Value.ToString(), "")
                DatabaseEntries.RTB_Comment.Text = If(DGV.CurrentRow.Cells(5).Value IsNot Nothing, DGV.CurrentRow.Cells(5).Value.ToString(), "")
                DatabaseEntries.Text = "Datenbankeintrag bearbeiten"
                Me.Close()
            Else
                MsgBox("Keine Berechtigung um Datenbankeinträge zu bearbeiten")
            End If
        Else
            MsgBox("Einträge auf FTP-Server können nicht bearbeitet werden.")
        End If
    End Sub

    Private Sub LöschenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LöschenToolStripMenuItem.Click
        If Autodatenbank.GetPermission(My.Settings.PermissionKey, 6) Or Autodatenbank.LoginSetting = False Then

            If DGV.CurrentRow.Cells(7).Value Is Nothing Then
                Select Case MessageBox.Show("Daten sicher löschen ?", "Daten löschen", MessageBoxButtons.YesNo)
                    Case Windows.Forms.DialogResult.Yes
                        DeleteDatabaseEntry()
                    Case Windows.Forms.DialogResult.No

                End Select
            Else
                If Autodatenbank.GetPermission(My.Settings.PermissionKey, 10) = True Or Autodatenbank.LoginSetting = False Then
                    Select Case MessageBox.Show("Wirklich Löschen?", "Datei unwiderruflich Löschen?", MessageBoxButtons.YesNo)
                        Case Windows.Forms.DialogResult.Yes
                            DeleteFileFromFtpServer(DGV.CurrentRow.Cells(7).Value.ToString, My.Settings.Ftpusername, My.Settings.Ftppassword)
                        Case Windows.Forms.DialogResult.No

                    End Select
                Else
                    MsgBox("Keine Berechtigung um Datein zu löschen")
                End If
            End If

            If Autodatenbank.CBB_SavedCars.SelectedIndex > -1 Then
                Autodatenbank.dgv.Rows.Clear()
                Autodatenbank.dgv2.Rows.Clear()
                Autodatenbank.FillDGV()
                If My.Settings.sftp = True Then
                    SFTP.ListFilesFromSFTPForDGV2(Autodatenbank.Licenseplate)
                Else
                    FTP.ListFilesFromFTPForDGV2(Autodatenbank.Licenseplate)
                End If
            End If


        Else
            MsgBox("Keine Berechtgung um Datenbankeinträge oder Datein zu löschen")
        End If
    End Sub
    Sub DeleteFileFromFtpServer(ftpServerUri As String, username As String, password As String)

        Try
            If My.Settings.sftp = True Then
                SFTP.DeleteFileFromSFTP(DGV.CurrentRow.Cells(1).Value.ToString, DGV.CurrentRow.Cells(0).Value.ToString)

            Else
                FTP.DeleteFileFromFTP(DGV.CurrentRow.Cells(7).Value.ToString)
            End If
            Me.Close()
        Catch ex As Exception

            MsgBox("Fehler beim Löschen der Datei: " & ex.Message)
            SavetoLogFile(ex.Message, "DeleteFTPFileBySearching")

        End Try







    End Sub
    Private Sub DeleteDatabaseEntry()

        Dim connection As New MySqlConnection(My.Settings.connectionstring)
        Dim location As String = ""
        Dim tabelname As String = ""

        Autodatenbank.EntryID = CInt(DGV.CurrentRow.Cells(8).Value)
        Select Case True
            Case DGV.CurrentRow.Cells(6).Value.ToString = "Service" Or DGV.CurrentRow.Cells(6).Value.ToString = "Service/Wartung"
                tabelname = "Service"
                location = "ID_Service"
            Case DGV.CurrentRow.Cells(6).Value.ToString = "Reparatur"
                tabelname = "Reparatur"
                location = "ID_Reparatur"
            Case DGV.CurrentRow.Cells(6).Value.ToString = "Sonstiges"
                tabelname = "Sonstiges"
                location = "ID_Sonstiges"
        End Select

        Try
            connection.Open()


            Dim primaryKeyValue As Integer = Autodatenbank.EntryID

            ' Erstelle die DELETE-Anweisung mit dem Primärschlüsselwert als Bedingung
            Dim sql As String = "DELETE FROM " & tabelname & " WHERE " & location & " = @primaryKeyValue"

            ' Führe die DELETE-Anweisung mit dem Parameter für den Primärschlüsselwert aus
            Using cmd As New MySqlCommand(sql, connection)
                cmd.Parameters.AddWithValue("@primaryKeyValue", primaryKeyValue)
                cmd.ExecuteNonQuery()
            End Using

            MessageBox.Show("Daten wurden erfolgreich gelöscht.")
            Me.Close()

        Catch ex As Exception
            MessageBox.Show("Fehler bei der Datenbankverbindung oder beim Löschen der Zeile: " & ex.Message)
            SavetoLogFile(ex.Message, "DeleteDatabaseEntryBySearching")
        Finally
            connection.Close()
        End Try
    End Sub

    Private Sub ÖffnenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ÖffnenToolStripMenuItem.Click




        If GetPermission(My.Settings.PermissionKey, 9) = True Then
            If DGV.Rows.Count > 0 Then
                Dim tempPath As String = Application.StartupPath & "\temp\"

                ' Überprüfen, ob das temporäre Verzeichnis existiert
                If Not System.IO.Directory.Exists(tempPath) Then
                    System.IO.Directory.CreateDirectory(tempPath)
                End If

                ' Setze den Cursor auf Wartezustand
                Cursor.Current = Cursors.WaitCursor

                ' Wähle die Methode basierend auf SFTP oder FTP
                If My.Settings.sftp Then
                    ' SFTP-Download

                    SFTP.DownloadandOpenFileSFTP(tempPath & DGV.CurrentRow.Cells(1).Value.ToString, DGV.CurrentRow.Cells(1).Value.ToString, DGV.CurrentRow.Cells(0).Value.ToString)
                Else
                    ' FTP-Download

                    FTP.DownloadandOpenFileFTP(tempPath & DGV.CurrentRow.Cells(1).Value.ToString, DGV.CurrentRow.Cells(7).Value.ToString)
                End If
            End If
        Else
            MsgBox("Keine Berechtigung um Dateien zu öffnen")
        End If
    End Sub


    Private Sub BTN_SearchEntries_Click(sender As Object, e As EventArgs) Handles BTN_SearchEntries.Click
        If TXB_SearchWord.Text.Length > 0 Then
            Cursor = Cursors.WaitCursor
            If CB_SearchInDatabase.Checked Then
                Search()
            End If
            Try

                If CB_SearchOnFTP.Checked AndAlso cb_editor.Checked = False Then
                    If My.Settings.sftp = True Then
                        SFTP.SearchInSFTPFolder(My.Settings.SFTPServerUri, TXB_SearchWord.Text)
                    Else
                        SearchInFolder(My.Settings.Ftpserveruri, My.Settings.Ftpusername, My.Settings.Ftppassword, TXB_SearchWord.Text)
                    End If
                End If

            Catch ex As Exception
                Cursor = Cursors.Default
                MsgBox($"Fehler beim Durchsuchen des FTP-Servers: {ex.Message}")
                SavetoLogFile(ex.Message, "SearchDatabaseEntries")
            End Try


        Else
            MsgBox("Bitte Suchwort eingeben")
        End If
        If DGV.Rows.Count > 0 Then
            Me.Text = "Suchen     Es wurden " & DGV.Rows.Count & " Einträge gefunden"
        ElseIf DGV.Rows.Count = 1 Then
            Me.Text = "Suchen     Es wurde 1 Eintrag gefunden"
        Else
            Me.Text = "Suchen     Es wurden keine Einträge gefunden"
        End If

        Cursor = Cursors.Default
    End Sub
End Class