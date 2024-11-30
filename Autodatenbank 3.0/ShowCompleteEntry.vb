Imports System.IO
Imports System.Net
Imports MySqlConnector

Public Class ShowCompleteEntry
    Dim contentid As Integer = 0
    Private Sub ShowCompleteEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadOverallSettings()
    End Sub



    Public Sub SetValuesInTextboxes(item As MySQLEntryInfo)
        TXB_Licenseplate.Clear()
        TXB_Designation.Clear()
        TXB_Millage.Clear()
        TXB_Date.Clear()
        TXB_Price.Clear()
        TXB_Art.Clear()
        TXB_Editor.Clear()
        RTB_Comment.Clear()
        Me.Text = "Eintrag: " & item.Bezeichnung & "  Auto: " & item.Kennzeichen

        TXB_Licenseplate.Text = item.Kennzeichen
        TXB_Designation.Text = item.Bezeichnung
        TXB_Millage.Text = item.Kilometer
        TXB_Date.Text = item.Datum
        TXB_Price.Text = item.Preis
        TXB_Art.Text = item.art
        TXB_Editor.Text = item.Bearbeiter
        RTB_Comment.Text = item.Kommentar
        contentid = item.ID


        Select Case True
            Case item.art = "Service/Wartung"
                LoadLinkedData("Service", "ID_Service", item.ID)
            Case item.art = "Reparatur"
                LoadLinkedData("Reparatur", "ID_Reparatur", item.ID)
            Case item.art = "Sonstiges"
                LoadLinkedData("Sonstiges", "ID_Sonstiges", item.ID)
        End Select










    End Sub



    Private Sub LoadLinkedData(tabelname As String, tabelid As String, recordid As Integer)
        Dim compactLink As String = ""
        Dim query As String = $"SELECT Datein FROM {tabelname} WHERE {tabelid} = {recordid}"

        Using conn As New MySqlConnection(My.Settings.connectionstring)
            conn.Open()

            Using cmd As New MySqlCommand(query, conn)
                Using reader As MySqlDataReader = cmd.ExecuteReader
                    If reader.HasRows Then
                        While reader.Read
                            If Not IsDBNull(reader("Datein")) Then
                                ' Hole den Wert der Spalte und weise ihn der Variable zu
                                compactLink = reader("Datein").ToString()
                            End If

                        End While
                    End If
                    ' CompactLink Aufsplitten in eine Liste
                    Dim SeperateLink As New List(Of String)

                    SeperateLink.AddRange(compactLink.Split(";"c))

                    If SeperateLink.Count > -1 Then
                        For Each item As String In SeperateLink
                            ListBox1.Items.Add(item)
                        Next
                    End If


                    'Größe Einstellen
                    If Not String.IsNullOrEmpty(ListBox1.Items(0).ToString) Then
                        Me.Size = New Size(1217, 955)
                        ListBox1.SelectedIndex = 0
                    Else
                        Me.Size = New Size(467, 955)
                    End If

                End Using
            End Using
        End Using







    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        Cursor = Cursors.WaitCursor
        WB_Preview.Navigate("about:blank")
        PB_Preview.Image = Nothing
        Dim imageExtensions As List(Of String) = New List(Of String) From {
        ".jpg", ".jpeg", ".png", ".bmp", ".gif", ".tiff"
    }
        If ListBox1.SelectedIndex > -1 Then

            Dim extension As String = Path.GetExtension(ListBox1.SelectedItem.ToString).ToLower()
            If imageExtensions.Contains(extension) Then
                WB_Preview.Visible = False
                PB_Preview.Visible = True
                LoadImageFromFTP(ListBox1.SelectedItem.ToString)
            ElseIf extension = ".pdf" Then
                LoadPdfFromFTP(ListBox1.SelectedItem.ToString)
            End If


        End If
    End Sub

    Private Sub LoadImageFromFTP(ftpurl As String)

        Try
            Dim webclient As New WebClient

            webclient.Credentials = New NetworkCredential(My.Settings.Ftpusername, My.Settings.Ftppassword)

            Dim imageBytes() As Byte = webclient.DownloadData(ftpurl)

            Using stream As New IO.MemoryStream(imageBytes)
                ' Lade das Bild in die PictureBox
                PB_Preview.Image = Image.FromStream(stream)
                PB_Preview.SizeMode = PictureBoxSizeMode.Zoom ' Optional: Bild in der PictureBox skalieren
            End Using

        Catch ex As Exception
            Cursor = Cursors.Default
        End Try
        Cursor = Cursors.Default

    End Sub

    Private Sub LoadPdfFromFTP(ftpurl As String)
        Try
            ' Erstelle einen temporären Dateipfad für die heruntergeladene PDF-Datei
            Dim tempFilePath As String = IO.Path.Combine(IO.Path.GetTempPath(), "tempfile.pdf")

            ' Verwende WebClient, um die PDF-Datei von der FTP-URL herunterzuladen
            Dim webClient As New WebClient()
            webClient.Credentials = New NetworkCredential(My.Settings.Ftpusername, My.Settings.Ftppassword)

            ' Lade die PDF-Datei herunter und speichere sie temporär
            webClient.DownloadFile(ftpurl, tempFilePath)


            WB_Preview.Navigate(tempFilePath)
            WB_Preview.Visible = True
            PB_Preview.Visible = False

        Catch ex As Exception
            Cursor = Cursors.Default
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub LöschenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LöschenToolStripMenuItem.Click
        Dim compaktLink As String = ""
        Dim LinkList As New List(Of String)
        Dim tabelid As String = ""
        Dim tabelname As String = ""

        ' Tabelle je nach Typ festlegen
        Select Case True
            Case TXB_Art.Text = "Service/Wartung"
                tabelname = "Service"
                tabelid = "ID_Service"
            Case TXB_Art.Text = "Reparatur"
                tabelname = "Reparatur"
                tabelid = "ID_Reparatur"
            Case TXB_Art.Text = "Sonstiges"
                tabelname = "Sonstiges"
                tabelid = "ID_Sonstiges"
        End Select



        If ListBox1.SelectedIndex > -1 Then
            Try
                Dim queryGetData As String = $"SELECT Datein FROM {tabelname} WHERE {tabelid} = @contentid"

                Using conn As New MySqlConnection(My.Settings.connectionstring)
                    conn.Open()

                    ' Daten aus der Datenbank holen
                    Using cmd As New MySqlCommand(queryGetData, conn)
                        cmd.Parameters.AddWithValue("@contentid", contentid)

                        Using reader As MySqlDataReader = cmd.ExecuteReader()
                            If reader.HasRows Then
                                While reader.Read()
                                    If Not String.IsNullOrEmpty(reader.GetString("Datein")) Then
                                        compaktLink = reader.GetString("Datein")
                                        LinkList.AddRange(compaktLink.Split(";"c))

                                        ' Entferne den ausgewählten Link
                                        LinkList.Remove(ListBox1.SelectedItem.ToString())
                                    End If
                                End While
                            End If
                        End Using
                    End Using

                    ' Kompakte Liste zu einem String zusammensetzen und in der Datenbank aktualisieren
                    Dim updatedLinks As String = String.Join(";", LinkList)

                    Dim queryUpdate As String = $"UPDATE {tabelname} SET Datein = @updatedLinks WHERE {tabelid} = @contentid"

                    Using cmdUpdate As New MySqlCommand(queryUpdate, conn)
                        cmdUpdate.Parameters.AddWithValue("@updatedLinks", updatedLinks)
                        cmdUpdate.Parameters.AddWithValue("@contentid", contentid)
                        cmdUpdate.ExecuteNonQuery()
                    End Using
                End Using

                ' Liste aktualisieren
                ListBox1.Items.Remove(ListBox1.SelectedItem)
                Cursor = Cursors.Default
            Catch ex As Exception
                MessageBox.Show("Fehler beim Löschen des Links: " & ex.Message)
                Cursor = Cursors.Default
            End Try
        End If
    End Sub

    Private Sub PB_Preview_Click(sender As Object, e As EventArgs) Handles PB_Preview.Click
        PB_Preview.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
        PB_Preview.Invalidate()
    End Sub
End Class