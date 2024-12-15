Imports System.Reflection
Imports MySqlConnector

Public Class ChecklistEdit
    Private draggedIndex As Integer = -1
    Private CreateNew As Boolean = True
    Private CreatedBy As String = My.Settings.Username
    Private Sub Checklist_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetChecklists()
    End Sub


    Private Sub GetChecklists()
        LB_ListChecklist.Items.Clear()
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
                            LB_ListChecklist.Items.Add(item)
                        End While
                    End If
                End Using
            End Using
        End Using




    End Sub
    Private Sub TSMI_EditSavedChecklist_Click(sender As Object, e As EventArgs) Handles TSMI_EditSavedChecklist.Click
        If LB_ListChecklist.SelectedIndex > -1 Then
            Dim selectedItem As ListboxItemChecklist = CType(LB_ListChecklist.SelectedItem, ListboxItemChecklist)
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

            TXB_DescriptionChecklist.Text = text

            If Not String.IsNullOrEmpty(Workstepstogehter) Then
                LB_ChecklistPoints.Items.Clear()
                Dim separators As Char() = {"|"c}
                Dim Worksteps As String() = Workstepstogehter.Split(separators)
                For Each item In Worksteps
                    item = item.Replace("{", "").Replace("}", "").Trim()
                    If Not String.IsNullOrWhiteSpace(item) Then
                        LB_ChecklistPoints.Items.Add(item)
                    End If
                Next
            End If
            CreateNew = False
        End If
    End Sub



    Private Sub BTN_NewChecklist_Click(sender As Object, e As EventArgs) Handles BTN_NewChecklist.Click
        CreateNew = True
        TXB_DescriptionChecklist.Clear()
        RTB_DescriptionWorkStep.Clear()
        LB_ChecklistPoints.Items.Clear()

    End Sub


    Private Sub BTN_SaveWorkstep_Click(sender As Object, e As EventArgs) Handles BTN_SaveWorkstep.Click
        If RTB_DescriptionWorkStep.Text.Length > 1 Then


            If RTB_DescriptionWorkStep.Tag Is Nothing OrElse RTB_DescriptionWorkStep.Tag.ToString() = "-1" Then

                ' Prüfen, ob der Arbeitsschritt bereits existiert
                For Each item In LB_ChecklistPoints.Items
                    If item.ToString.Trim.ToLower = RTB_DescriptionWorkStep.Text.Trim.ToLower Then
                        Dim result = MessageBox.Show("Gleicher Arbeitsschritt schon vorhanden, trotzdem hinzufügen?", "Hinweis", MessageBoxButtons.YesNo)
                        If result = Windows.Forms.DialogResult.Yes Then
                            LB_ChecklistPoints.Items.Add(RTB_DescriptionWorkStep.Text)
                            RTB_DescriptionWorkStep.Text = ""
                            RTB_DescriptionWorkStep.Tag = "-1"
                        End If
                        Exit Sub
                    End If
                Next


                LB_ChecklistPoints.Items.Add(RTB_DescriptionWorkStep.Text)
                RTB_DescriptionWorkStep.Text = ""
                RTB_DescriptionWorkStep.Tag = "-1"
            Else
                ' Vorhandenen Arbeitsschritt bearbeiten
                Dim index As Integer = Convert.ToInt32(RTB_DescriptionWorkStep.Tag)

                ' Prüfen, ob die neue Beschreibung bereits existiert
                For i As Integer = 0 To LB_ChecklistPoints.Items.Count - 1
                    If i <> index AndAlso LB_ChecklistPoints.Items(i).ToString().Trim().ToLower() = RTB_DescriptionWorkStep.Text.Trim().ToLower() Then
                        MessageBox.Show("Ein anderer Arbeitsschritt hat bereits denselben Text. Änderungen werden nicht gespeichert.", "Warnung", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If
                Next


                LB_ChecklistPoints.Items(index) = RTB_DescriptionWorkStep.Text
                RTB_DescriptionWorkStep.Text = ""
                RTB_DescriptionWorkStep.Tag = "-1"
            End If
        Else
            MessageBox.Show("Bitte geben Sie eine gültige Beschreibung ein.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub



    Private Sub TMSI_EditWorkStepEntry_Click(sender As Object, e As EventArgs) Handles TMSI_EditWorkStepEntry.Click
        Dim index As Integer = LB_ChecklistPoints.SelectedIndex

        If LB_ChecklistPoints.SelectedIndex > -1 Then
            RTB_DescriptionWorkStep.Text = LB_ChecklistPoints.Items(index).ToString()
            RTB_DescriptionWorkStep.Tag = index.ToString()
        End If
    End Sub

    Private Sub TMSI_DeleteWorkStepEntry_Click(sender As Object, e As EventArgs) Handles TMSI_DeleteWorkStepEntry.Click
        Dim index As Integer = LB_ChecklistPoints.SelectedIndex

        If LB_ChecklistPoints.SelectedIndex > -1 Then
            LB_ChecklistPoints.Items.RemoveAt(index)
        End If
    End Sub

    Private Sub BTN_SaveChecklist_Click(sender As Object, e As EventArgs) Handles BTN_SaveChecklist.Click
        If CreateNew = True Then



            Dim items As List(Of String) = LB_ChecklistPoints.Items.Cast(Of Object)().Select(Function(x) x.ToString()).ToList()
            Dim LBIToString As String = "{" & String.Join("|", items) & "}"





            If TXB_DescriptionChecklist.Text.Length > 3 Then
                    Dim query As String = "INSERT INTO checklist(Description, UpdatedBy, CreatedBy, Worksteps) VALUES (@Description, @UpdatedBy, @CreatedBy, @Worksteps)"
                    Using con As New MySqlConnection(My.Settings.connectionstring)
                        con.Open()
                        Using cmd As New MySqlCommand(query, con)
                            cmd.Parameters.AddWithValue("@Description", TXB_DescriptionChecklist.Text)
                            cmd.Parameters.AddWithValue("@UpdatedBy", My.Settings.Username)
                            cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy)
                            cmd.Parameters.AddWithValue("@Worksteps", LBIToString)
                            cmd.ExecuteNonQuery()
                        End Using
                    End Using
                    GetChecklists()
                    TXB_DescriptionChecklist.Clear()
                    RTB_DescriptionWorkStep.Clear()
                    LB_ChecklistPoints.Items.Clear()
                    MsgBox("Checkliste erfolgreich gespeichert")
                    CreateNew = True


                Else
                    MsgBox("Bezeichnung muss mindestens 3 Zeichen haben")
                End If
            Else
                Dim items As List(Of String) = LB_ChecklistPoints.Items.Cast(Of Object)().Select(Function(x) x.ToString()).ToList()
                Dim LBIToString As String = "{" & String.Join("|", items) & "}"



                If TXB_DescriptionChecklist.Text.Length > 3 Then
                    Dim query As String = "UPDATE  checklist SET Description = @Description, UpdatedBy = @UpdatedBy, Worksteps = @Worksteps"
                    Using con As New MySqlConnection(My.Settings.connectionstring)
                        con.Open()
                        Using cmd As New MySqlCommand(query, con)
                            cmd.Parameters.AddWithValue("@Description", TXB_DescriptionChecklist.Text)
                            cmd.Parameters.AddWithValue("@UpdatedBy", My.Settings.Username)
                            cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy)
                            cmd.Parameters.AddWithValue("@Worksteps", LBIToString)
                            cmd.ExecuteNonQuery()
                        End Using
                    End Using
                    GetChecklists()
                    TXB_DescriptionChecklist.Clear()
                    RTB_DescriptionWorkStep.Clear()
                    LB_ChecklistPoints.Items.Clear()
                    MsgBox("Checkliste erfolgreich akutualisiert")
                    CreateNew = True


                Else
                    MsgBox("Bezeichnung muss mindestens 3 Zeichen haben")
                End If
            End If



    End Sub





#Region "SortListboxItems"
    Private Sub LB_ChecklistPoints_MouseDown(sender As Object, e As MouseEventArgs) Handles LB_ChecklistPoints.MouseDown
        ' Prüfen, ob es ein Linksklick ist
        If e.Button = MouseButtons.Left Then
            ' Ermittelt den Index des angeklickten Elements
            draggedIndex = LB_ChecklistPoints.IndexFromPoint(e.Location)

            ' Wenn ein gültiges Element geklickt wurde, beginnt der Drag
            If draggedIndex >= 0 Then
                LB_ChecklistPoints.DoDragDrop(LB_ChecklistPoints.Items(draggedIndex), DragDropEffects.Move)
            End If
        End If

        ' Bei Rechtsklick nichts machen (Kontextmenü wird normal angezeigt)
    End Sub

    ' DragEnter-Ereignis: Überprüft, ob ein Drag-and-Drop zulässig ist
    Private Sub LB_ChecklistPoints_DragEnter(sender As Object, e As DragEventArgs) Handles LB_ChecklistPoints.DragEnter
        ' Setzt den DragDrop-Effekt auf "Move"
        e.Effect = DragDropEffects.Move
    End Sub

    ' DragDrop-Ereignis: Führt das Verschieben durch
    Private Sub LB_ChecklistPoints_DragDrop(sender As Object, e As DragEventArgs) Handles LB_ChecklistPoints.DragDrop
        ' Zielposition ermitteln
        Dim point As Point = LB_ChecklistPoints.PointToClient(New Point(e.X, e.Y))
        Dim targetIndex As Integer = LB_ChecklistPoints.IndexFromPoint(point)

        ' Sicherstellen, dass der Zielindex gültig ist
        If targetIndex >= 0 AndAlso draggedIndex >= 0 AndAlso targetIndex <> draggedIndex Then
            ' Das Element verschieben
            Dim draggedItem As Object = LB_ChecklistPoints.Items(draggedIndex)
            LB_ChecklistPoints.Items.RemoveAt(draggedIndex)
            LB_ChecklistPoints.Items.Insert(targetIndex, draggedItem)
        End If
    End Sub












#End Region


End Class


Public Class ListboxItemChecklist

    Public Property Text As String
    Public Property Tag As Integer
    Public Property CreatedBy As String
    Public Property UpdatedBy As String

    Public Sub New(text As String, tag As Integer, CreatedBy As String, UpdatedBy As String)
        Me.Text = text
        Me.Tag = tag
        Me.CreatedBy = CreatedBy
        Me.UpdatedBy = UpdatedBy
    End Sub

    Public Overrides Function ToString() As String
        Return Text
    End Function
End Class