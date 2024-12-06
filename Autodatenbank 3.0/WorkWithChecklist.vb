Imports System.IO
Imports System.Windows.Controls
Imports System.Windows.Interop
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports MySqlConnector

Public Class WorkWithChecklist
    Dim SavedChecklist As Boolean = False
    Private Sub WorkWithChecklist_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetChecklists()

    End Sub



    Private Sub GetChecklists()
        CBB_ListChecklist.Items.Clear()

        Dim querySav As String = "SELECT * FROM savedChecklist WHERE Kennzeichen = @Kennzeichen"

        Using conSav As New MySqlConnection(My.Settings.connectionstring)
            conSav.Open()
            Using cmdSav As New MySqlCommand(querySav, conSav)
                ' Verwende SelectedItem, um das ausgewählte Kennzeichen zu erhalten

                Dim kennzeichen As String = Autodatenbank.Licenseplate

                ' Parameter setzen
                cmdSav.Parameters.AddWithValue("@Kennzeichen", kennzeichen)


                Using Reader As MySqlDataReader = cmdSav.ExecuteReader
                    If Reader.HasRows Then
                        ' Überschrift als normales Item hinzufügen
                        CBB_ListChecklist.Items.Add("Für dieses Auto gespeicherte Checklisten:")

                        ' Gespeicherte Checklisten hinzufügen
                        While Reader.Read
                            Dim description As String = If(Reader.IsDBNull(Reader.GetOrdinal("Description")), "N/A", Reader.GetString(Reader.GetOrdinal("Description")))
                            Dim id As Integer = If(Reader.IsDBNull(Reader.GetOrdinal("ID")), 0, Reader.GetInt32(Reader.GetOrdinal("ID")))
                            Dim editor As String = If(Reader.IsDBNull(Reader.GetOrdinal("Editor")), "N/A", Reader.GetString(Reader.GetOrdinal("Editor")))

                            ' Neues Item mit Beschreibung, ID und Editor erstellen
                            Dim item As New ComboboxItemsWithTag(description, id, editor)
                            CBB_ListChecklist.Items.Add(item)
                        End While

                    End If
                End Using
            End Using
        End Using








        Dim queryNew As String = "SELECT * FROM checklist"

        Using conNew As New MySqlConnection(My.Settings.connectionstring)
            conNew.Open()
            Using cmdNew As New MySqlCommand(queryNew, conNew)
                Using Reader As MySqlDataReader = cmdNew.ExecuteReader
                    If Reader.HasRows Then
                        CBB_ListChecklist.Items.Add("Neue Checkliste beginnen:")
                        While Reader.Read

                            Dim description As String = (If(Reader.IsDBNull(Reader.GetOrdinal("Description")), "N/A", Reader.GetString(Reader.GetOrdinal("Description"))))
                            Dim id As Integer = (If(Reader.IsDBNull(Reader.GetOrdinal("ID")), 0, Reader.GetInt16(Reader.GetOrdinal("ID"))))
                            Dim Created As String = (If(Reader.IsDBNull(Reader.GetOrdinal("CreatedBy")), "N/A", Reader.GetString(Reader.GetOrdinal("CreatedBy"))))
                            Dim Updated As String = (If(Reader.IsDBNull(Reader.GetOrdinal("UpdatedBy")), "N/A", Reader.GetString(Reader.GetOrdinal("UpdatedBy"))))
                            Dim item As New ListboxItemChecklist(description, id, Created, Updated)
                            CBB_ListChecklist.Items.Add(item)
                        End While
                    End If
                End Using
            End Using
        End Using

        CBB_ListChecklist.Enabled = True


    End Sub

    Private Sub LoadSelectedChecklist()
        If CBB_ListChecklist.SelectedIndex > -1 Then
            Dim selectedItem As ListboxItemChecklist = CType(CBB_ListChecklist.SelectedItem, ListboxItemChecklist)
            Dim text As String = selectedItem.Text
            Dim id As Integer = selectedItem.Tag
            Dim createdBy As String = selectedItem.CreatedBy
            Dim updatedBy As String = selectedItem.UpdatedBy
            Dim Workstepstogehter As String = ""

            Dim query As String = "SELECT * FROM checklist WHERE ID = @ID"

            Using con As New MySqlConnection(My.Settings.connectionstring)
                con.Open()
                Using cmd As New MySqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@ID", id)
                    Using reader As MySqlDataReader = cmd.ExecuteReader
                        If reader.HasRows Then
                            While reader.Read
                                Workstepstogehter = If(reader.IsDBNull(reader.GetOrdinal("Worksteps")), "", reader.GetString(reader.GetOrdinal("Worksteps")))
                            End While
                        End If
                    End Using
                End Using
            End Using

            LBL_Description.Text = text

            If Not String.IsNullOrEmpty(Workstepstogehter) Then
                LB_ChecklistPoints.Items.Clear()
                Dim separators As Char() = {"|"c}
                Dim Worksteps As String() = Workstepstogehter.Split(separators)
                For Each item In Worksteps
                    ' Entfernt Zeilenumbrüche (falls vorhanden) und zusätzliche Leerzeichen
                    item = item.Replace("{", "").Replace("}", "").Replace(vbCr, "").Replace(vbLf, "").Trim()

                    If Not String.IsNullOrWhiteSpace(item) Then
                        ' Füge den Punkt als nicht angehakt hinzu
                        LB_ChecklistPoints.Items.Add(item, False)
                    End If
                Next
            End If
        End If
    End Sub
    Private Sub LoadSavedChecklisttoListbox(selectedChecklistId As Integer)
        Dim query As String = "SELECT Worksteps, Finish FROM savedChecklist WHERE ID = @ID"

        Try
            Using con As New MySqlConnection(My.Settings.connectionstring)
                con.Open()
                Using cmd As New MySqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@ID", selectedChecklistId)

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.HasRows Then
                            While reader.Read

                                Dim workstepsString As String = If(reader.IsDBNull(reader.GetOrdinal("Worksteps")), "", reader.GetString(reader.GetOrdinal("Worksteps")))
                                Dim finish As String = If(reader.IsDBNull(reader.GetOrdinal("Finish")), "", reader.GetString(reader.GetOrdinal("Finish")))

                                If finish = "true" Then
                                    CB_Finish.Checked = True
                                Else
                                    CB_Finish.Checked = False
                                End If
                                LoadWorkstepsIntoChecklistBox(workstepsString)
                            End While

                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MsgBox("Ein Fehler ist beim Laden der gespeicherten Checkliste aufgetreten.")
            SavetoLogFile(ex.Message, "LoadSavedChecklist")
        End Try


    End Sub
    Private Sub LoadWorkstepsIntoChecklistBox(workstepsString As String)

        LB_ChecklistPoints.Items.Clear()


        workstepsString = workstepsString.Trim("{"c, "}"c)


        Dim worksteps As String() = workstepsString.Split("|"c)


        For Each stepItem In worksteps

            Dim parts As String() = stepItem.Split(":"c)
            If parts.Length = 2 Then
                Dim task As String = parts(0).Trim()
                Dim isChecked As Boolean = Boolean.Parse(parts(1).Trim())

                LB_ChecklistPoints.Items.Add(task, isChecked)
            End If
        Next
    End Sub
    Private Sub CB_ListChecklist_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBB_ListChecklist.SelectedIndexChanged
        If CBB_ListChecklist.SelectedIndex > -1 And TypeOf CBB_ListChecklist.SelectedItem Is ListboxItemChecklist Then
            SavedChecklist = False
            CB_Finish.Checked = False
            LoadSelectedChecklist()
        ElseIf CBB_ListChecklist.SelectedIndex > -1 And TypeOf CBB_ListChecklist.SelectedItem Is ComboboxItemsWithTag Then
            SavedChecklist = True

            Dim selectedItem As Object = CBB_ListChecklist.SelectedItem
            Dim id As Integer = 0
            If TypeOf selectedItem Is ComboboxItemsWithTag Then
                Dim checklistItem As ComboboxItemsWithTag = CType(selectedItem, ComboboxItemsWithTag)
                id = checklistItem.Tag
                LoadSavedChecklisttoListbox(id)
            End If


        Else
            LB_ChecklistPoints.Items.Clear()
        End If
    End Sub

    Private Sub BTN_SaveChecklist_Click(sender As Object, e As EventArgs) Handles BTN_SaveChecklist.Click

        ' Erstellen der Worksteps-String-Liste
        Dim items As List(Of String) = LB_ChecklistPoints.Items.Cast(Of Object)().
        Select(Function(x, index) $"{x.ToString()}:{LB_ChecklistPoints.GetItemChecked(index)}").
        ToList()

        ' Zusammenfügen der Worksteps in einen String
        Dim LBIToString As String = "{" & String.Join("|", items) & "}"

        ' Finish-Status aus der Checkbox
        Dim finish As String = If(CB_Finish.Checked, "true", "false")

        ' Variablen für Kennzeichen und Beschreibung
        Dim kennzeichen As String = ""
        Dim description As String = ""
        Dim id As Integer = 0

        ' Beschreibung aus der ComboBox 'CBB_ListChecklist'
        Dim selectedItem As Object = CBB_ListChecklist.SelectedItem
        If selectedItem IsNot Nothing Then
            ' Prüfen, ob das Item ein String oder ein benutzerdefiniertes Objekt ist
            If TypeOf selectedItem Is String Then
                description = selectedItem.ToString()
            ElseIf TypeOf selectedItem Is ComboboxItemsWithTag Then
                Dim checklistItem As ComboboxItemsWithTag = CType(selectedItem, ComboboxItemsWithTag)
                description = checklistItem.Text
            ElseIf TypeOf selectedItem Is ListboxItemChecklist Then
                Dim checklistItem As ListboxItemChecklist = CType(selectedItem, ListboxItemChecklist)
                description = checklistItem.Text
            End If
        Else
            MsgBox("Bitte eine gültige Checkliste auswählen!")
            Exit Sub
        End If


        kennzeichen = Autodatenbank.Licenseplate


        Dim query As String
        If SavedChecklist = False Then

            query = "INSERT INTO savedChecklist (Kennzeichen, Description, Worksteps, Infos, Finish, Editor) 
             VALUES (@Kennzeichen, @Description, @Worksteps, @Info, @Finish, @Editor)"
        Else

            query = "UPDATE savedChecklist 
             SET Description = @Description, 
                 Worksteps = @Worksteps, 
                 Infos = @Info, 
                 Finish = @Finish, 
                 Editor = @Editor
             WHERE ID = @ID"
            If TypeOf CBB_ListChecklist.SelectedItem Is ComboboxItemsWithTag Then
                id = CType(CBB_ListChecklist.SelectedItem, ComboboxItemsWithTag).Tag
            End If


        End If



        Try
            Using con As New MySqlConnection(My.Settings.connectionstring)
                con.Open()
                Using cmd As New MySqlCommand(query, con)
                    ' Parameter hinzufügen
                    cmd.Parameters.AddWithValue("@ID", id)
                    If SavedChecklist = False Then
                        cmd.Parameters.AddWithValue("@Description", description & "|" & DateAndTime.Today)
                        cmd.Parameters.AddWithValue("@Kennzeichen", kennzeichen)
                    Else
                        cmd.Parameters.AddWithValue("@Description", description)
                    End If

                    cmd.Parameters.AddWithValue("@Worksteps", LBIToString)
                    cmd.Parameters.AddWithValue("@Info", "")
                    cmd.Parameters.AddWithValue("@Finish", finish)
                    cmd.Parameters.AddWithValue("@Editor", My.Settings.UID)

                    ' SQL ausführen
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            If CB_Finish.Checked Then
                SaveChecklistPDF()
            End If

            LB_ChecklistPoints.Items.Clear()
            MsgBox("Checkliste erfolgreich gespeichert")
            GetChecklists()

        Catch ex As Exception
            ' Fehlerbehandlung
            MsgBox("Ein Fehler ist aufgetreten und wurde in der Logfile abgelegt")
            SavetoLogFile(ex.Message, "SaveChecklistworkwith")
        End Try
    End Sub



    Private Sub CBB_SavedCars_SelectedIndexChanged(sender As Object, e As EventArgs)
        CBB_ListChecklist.Items.Clear()
        CBB_ListChecklist.Text = ""
        GetChecklists()
        CBB_ListChecklist.Enabled = True
    End Sub


    Private Sub SaveChecklistPDF()
        Dim kennzeichen As String
        Dim owner As String = ""
        Dim marke As String = ""
        Dim modell As String = ""
        Dim mkb As String = ""
        Dim fin As String = ""
        Dim hsn As String = ""
        kennzeichen = Autodatenbank.Licenseplate

            Dim pdfPath As String = Application.StartupPath & "\Temp\Checkliste_" & kennzeichen & Now.Millisecond & ".pdf"
        Dim doc As New Document()
        PdfWriter.GetInstance(doc, New FileStream(pdfPath, FileMode.Create))
        doc.Open()

        ' Tabelle für Logo und Firmendaten erstellen
        Dim headerTable As New PdfPTable(2)
        headerTable.WidthPercentage = 100
        headerTable.SpacingAfter = 20
        headerTable.SetWidths(New Single() {30.0F, 70.0F}) ' 30% für Logo, 70% für Firmendaten

        ' Logo hinzufügen, falls vorhanden
        Dim logoPath As String = Application.StartupPath & "/Logo.png"
        If File.Exists(logoPath) Then
            Dim logo As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(logoPath)
            logo.ScaleToFit(CSng(My.Settings.Logowidth), CSng(My.Settings.Logoheight))
            logo.Alignment = Element.ALIGN_LEFT

            ' Logo in eine Zelle hinzufügen
            Dim logoCell As New PdfPCell(logo)
            logoCell.Border = Rectangle.NO_BORDER
            logoCell.HorizontalAlignment = Element.ALIGN_LEFT
            headerTable.AddCell(logoCell)
        Else
            ' Leere Zelle, falls kein Logo vorhanden ist
            Dim emptyLogoCell As New PdfPCell(New Phrase(" "))
            emptyLogoCell.Border = Rectangle.NO_BORDER
            headerTable.AddCell(emptyLogoCell)
        End If

        ' Firmendaten und Erstellungsdatum hinzufügen
        Dim creationDate As String = "Erstellt am: " & DateTime.Now.ToString("dd.MM.yyyy HH:mm")
        Dim firmData As String = My.Settings.CompName & vbCrLf &
                                 My.Settings.CompStreet & vbCrLf &
                                 My.Settings.CompCity & vbCrLf &
                                 "Bearbeiter: " & My.Settings.Username & vbCrLf &
                                 creationDate

        Dim firmDataCell As New PdfPCell(New Phrase(firmData, FontFactory.GetFont("Arial", 10)))
        firmDataCell.Border = Rectangle.NO_BORDER
        firmDataCell.HorizontalAlignment = Element.ALIGN_RIGHT
        firmDataCell.VerticalAlignment = Element.ALIGN_TOP
        headerTable.AddCell(firmDataCell)

        ' Tabelle zum Dokument hinzufügen
        doc.Add(headerTable)

        ' Fahrzeuginformationen Tabelle
        Dim vehicleTable As New PdfPTable(2)
        vehicleTable.WidthPercentage = 100
        vehicleTable.SpacingAfter = 10
        vehicleTable.DefaultCell.Padding = 5
        vehicleTable.DefaultCell.BorderWidth = 1

        Try
            Dim query As String = "SELECT * FROM Autos WHERE Kennzeichen = @Kennzeichen"
            Using con As New MySqlConnection(My.Settings.connectionstring)
                con.Open()

                Using cmd As New MySqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@Kennzeichen", kennzeichen)
                    Using reader As MySqlDataReader = cmd.ExecuteReader
                        If reader.HasRows Then
                            While reader.Read
                                owner = If(reader.IsDBNull(reader.GetOrdinal("Besitzer")), "", reader.GetString(reader.GetOrdinal("Besitzer")))
                                marke = If(reader.IsDBNull(reader.GetOrdinal("Marke")), "", reader.GetString(reader.GetOrdinal("Marke")))
                                modell = If(reader.IsDBNull(reader.GetOrdinal("Model")), "", reader.GetString(reader.GetOrdinal("Model")))
                                mkb = If(reader.IsDBNull(reader.GetOrdinal("MKB")), "", reader.GetString(reader.GetOrdinal("MKB")))
                                fin = If(reader.IsDBNull(reader.GetOrdinal("FIN")), "", reader.GetString(reader.GetOrdinal("FIN")))
                                hsn = If(reader.IsDBNull(reader.GetOrdinal("HSN")), "", reader.GetString(reader.GetOrdinal("HSN")))
                            End While
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception

        End Try

        Dim headers As String() = {"Besitzer", "Kennzeichen", "Marke", "Modell", "MKB", "FIN", "HSN/TSN"}
        Dim vehicleData As String() = {owner, kennzeichen, marke, modell, mkb, fin, hsn}

        For i As Integer = 0 To headers.Length - 1
            Dim cellHeader As New PdfPCell(New Phrase(headers(i), FontFactory.GetFont("Arial", 10)))
            cellHeader.BorderWidth = 1
            vehicleTable.AddCell(cellHeader)
            vehicleTable.AddCell(vehicleData(i))
        Next

        doc.Add(vehicleTable)

        ' Checklistenpunkte Tabelle
        Dim checklistTable As New PdfPTable(2)
        checklistTable.WidthPercentage = 100
        checklistTable.SpacingAfter = 10
        checklistTable.DefaultCell.Padding = 5
        checklistTable.DefaultCell.BorderWidth = 1

        ' Kopfzeile der Checkliste
        Dim checklistHeaders As String() = {"Checklistenpunkt", "Status"}
        For Each header As String In checklistHeaders
            Dim cell As New PdfPCell(New Phrase(header, FontFactory.GetFont("Arial", 10)))
            cell.BorderWidth = 1
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            checklistTable.AddCell(cell)
        Next

        ' Checklistenpunkte hinzufügen
        For i As Integer = 0 To LB_ChecklistPoints.Items.Count - 1
            Dim workstep As String = LB_ChecklistPoints.Items(i).ToString()
            Dim isChecked As Boolean = LB_ChecklistPoints.GetItemChecked(i)

            ' Punkt und Status hinzufügen
            checklistTable.AddCell(New Phrase(workstep, FontFactory.GetFont("Arial", 10)))
            checklistTable.AddCell(New Phrase(If(isChecked, "Erledigt", "Nicht erledigt"), FontFactory.GetFont("Arial", 10)))
        Next

        doc.Add(checklistTable)

        ' Abschluss
        doc.Close()

        Dim description As String = ""
        Dim selectedItem As Object = CBB_ListChecklist.SelectedItem

        If selectedItem IsNot Nothing Then
            ' Prüfen, ob das Item ein String oder ein benutzerdefiniertes Objekt ist
            If TypeOf selectedItem Is String Then
                description = selectedItem.ToString()
            ElseIf TypeOf selectedItem Is ComboboxItemsWithTag Then
                Dim checklistItem As ComboboxItemsWithTag = CType(selectedItem, ComboboxItemsWithTag)
                description = checklistItem.Text
            ElseIf TypeOf selectedItem Is ListboxItemChecklist Then
                Dim checklistItem As ListboxItemChecklist = CType(selectedItem, ListboxItemChecklist)
                description = checklistItem.Text
            End If
        Else
            MsgBox("Bitte eine gültige Checkliste auswählen!")
            Exit Sub
        End If

        If description.Contains("|") Then
            description = description.Substring(0, description.IndexOf("|"))
        End If


        If File.Exists(pdfPath) Then
            Try
                If My.Settings.sftp = True Then
                    UploadFileToSFTP(pdfPath, "CL_" & kennzeichen & "_" & description & "_" & Today & ".pdf")
                Else
                    UploadFileToFTP(pdfPath, "CL_" & kennzeichen & "_" & description & "_" & Today & ".pdf")
                End If
            Catch ex As Exception

            End Try
        Else
            MessageBox.Show("Die Datei konnte nicht gefunden werden.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If


        MessageBox.Show("Checkliste erfolgreich als PDF erstellt und auf PDF Server hochgeladen", "Erfolg", MessageBoxButtons.OK, MessageBoxIcon.Information)


    End Sub




End Class

Public Class ComboboxItemsWithTag

    Public Property Text As String
    Public Property Tag As Integer
    Public Property Editor As String


    Public Sub New(text As String, tag As Integer, Editor As String)
        Me.Text = text
        Me.Tag = tag
        Me.Editor = Editor

    End Sub

    Public Overrides Function ToString() As String
        Return Text
    End Function
End Class