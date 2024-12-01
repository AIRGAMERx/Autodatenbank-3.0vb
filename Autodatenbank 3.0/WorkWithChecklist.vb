Imports MySqlConnector

Public Class WorkWithChecklist
    Private Sub WorkWithChecklist_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCars()
        GetChecklists()
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
                Notify(Autodatenbank.NI_Error, "Fehler beim Abrufen der gespeicherten Autos ", ex.Message.ToString, 10000, ToolTipIcon.Error)
                SavetoLogFile(ex.Message, "LoadCars")
            End Try
        End Using
    End Sub

    Private Sub GetChecklists()
        CB_ListChecklist.Items.Clear()
        Dim query As String = "SELECT * FROM checklist"

        Using con As New MySqlConnection(My.Settings.connectionstring)
            con.Open()
            Using cmd As New MySqlCommand(query, con)
                Using Reader As MySqlDataReader = cmd.ExecuteReader
                    If Reader.HasRows Then
                        While Reader.Read

                            Dim description As String = (If(Reader.IsDBNull(Reader.GetOrdinal("Description")), "N/A", Reader.GetString(Reader.GetOrdinal("Description"))))
                            Dim id As Integer = (If(Reader.IsDBNull(Reader.GetOrdinal("ID")), 0, Reader.GetInt16(Reader.GetOrdinal("ID"))))
                            Dim Created As String = (If(Reader.IsDBNull(Reader.GetOrdinal("CreatedBy")), "N/A", Reader.GetString(Reader.GetOrdinal("CreatedBy"))))
                            Dim Updated As String = (If(Reader.IsDBNull(Reader.GetOrdinal("UpdatedBy")), "N/A", Reader.GetString(Reader.GetOrdinal("UpdatedBy"))))
                            Dim item As New ListboxItemChecklist(description, id, Created, Updated)
                            CB_ListChecklist.Items.Add(item)
                        End While
                    End If
                End Using
            End Using
        End Using




    End Sub

    Private Sub LoadSelectedChecklist()
        If CB_ListChecklist.SelectedIndex > -1 Then
            Dim selectedItem As ListboxItemChecklist = CType(CB_ListChecklist.SelectedItem, ListboxItemChecklist)
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


    Private Sub CB_ListChecklist_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CB_ListChecklist.SelectedIndexChanged
        If CB_ListChecklist.SelectedIndex > -1 Then
            LoadSelectedChecklist()
        End If
    End Sub
End Class

