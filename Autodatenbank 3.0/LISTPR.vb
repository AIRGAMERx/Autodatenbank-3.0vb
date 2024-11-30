Imports MySqlConnector

Public Class LISTPR

    Private Sub LISTPR_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadOverallSettings()
        Me.Text &= "      PR-Nummern werden für " & My.Settings.LicensePlate & " aufgelistet und entschlüsselt"
        ListPRNumbers()

    End Sub

    Public Async Sub ListPRNumbers()
        Dim licenseplate As String = My.Settings.LicensePlate
        Dim PrNumbers As String = ""
        Dim PRList As New List(Of String)

        'Listboxen leeren
        LB_PRDesignation.Items.Clear()
        LB_PrNumbers.Items.Clear()

        If Not String.IsNullOrEmpty(licenseplate) Then
            Cursor = Cursors.WaitCursor
            Dim query As String = "SELECT PR FROM Autos WHERE Kennzeichen = @Kennzeichen LIMIT 1"
            Try

                Using connection As New MySqlConnection(My.Settings.connectionstring)
                    connection.Open()

                    Using cmd As New MySqlCommand(query, connection)
                        cmd.Parameters.AddWithValue("@Kennzeichen", licenseplate)
                        Using reader As MySqlDataReader = cmd.ExecuteReader
                            If reader.HasRows Then
                                While reader.Read
                                    PrNumbers = reader.GetString("PR")
                                End While

                            End If
                        End Using
                    End Using
                End Using

                PRList.AddRange(PrNumbers.Split(";"c))

                For Each item As String In PRList
                    Dim designation As List(Of String) = Await GETPrDesignation(item)
                    Dim comment As String = ""
                    If designation IsNot Nothing AndAlso designation.Count > 0 Then
                        For Each des As String In designation
                            comment &= des
                        Next
                    End If

                    Dim LbItem As New ListBoxItemWithTagForList With {
                    .PR_Number = item,
                    .Text = comment
                    }
                    LB_PrNumbers.Items.Add(LbItem)
                    LB_PRDesignation.Items.Add(LbItem.Text)

                Next
            Catch ex As Exception
                Cursor = Cursors.Default
                SavetoLogFile(ex.Message, "ListPrNumbers")
            End Try

        End If
        Cursor = Cursors.Default
        If LB_PrNumbers.Items.Count = 0 OrElse LB_PrNumbers.Items(0).ToString = "N/A" Then
            LB_PrNumbers.Items.Clear()
            LB_PrNumbers.Items.Add("Es wurden keine PR-Nummern für dieses Fahrzeug gespeichert.")
        End If

    End Sub

    Private Sub LB_PrNumbers_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LB_PrNumbers.SelectedIndexChanged
        Dim i As Integer = LB_PrNumbers.SelectedIndex
        Try

            If i > -1 Then
                ' Cast das ausgewählte Item auf ListBoxItemWithTagForList
                Dim item As ListBoxItemWithTagForList = DirectCast(LB_PrNumbers.Items(i), ListBoxItemWithTagForList)

                ' Suche den passenden Text in der LB_PRDesignation ListBox
                For j As Integer = 0 To LB_PRDesignation.Items.Count - 1
                    Dim designation As String = DirectCast(LB_PRDesignation.Items(j), String)

                    ' Vergleich mit dem Text des ausgewählten Items
                    If designation = item.Text Then
                        ' Setze den Index in der LB_PRDesignation ListBox auf den gefundenen Wert
                        LB_PRDesignation.SelectedIndex = j
                        Exit For
                    End If
                Next
            End If
        Catch ex As Exception
            SavetoLogFile(ex.Message, "SelectPRnumbers")
        End Try
    End Sub

    Private Sub BTN_Refresh_Click(sender As Object, e As EventArgs) Handles BTN_Refresh.Click
        ListPRNumbers()
    End Sub

End Class

Public Class ListBoxItemWithTagForList
    Public Property Text As String
    Public Property PR_Number As String

    Public Function GetText() As String
        Return Text
    End Function

    Public Overrides Function ToString() As String
        Return PR_Number
    End Function

End Class