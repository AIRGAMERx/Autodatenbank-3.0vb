Imports System.Net
Imports System.Net.Http
Imports HtmlAgilityPack
Imports Newtonsoft.Json.Linq

Public Class KeyNumbers
    Private Async Sub BTN_Search_Click(sender As Object, e As EventArgs) Handles BTN_Search.Click
        If TXB_KeyNumber.Text.Length > 0 Then
            If TXB_KeyNumber.Text.Length >= 7 Then
                Dim hsn As String = GetHSN(TXB_KeyNumber.Text)
                Dim tsn As String = GetTSN(TXB_KeyNumber.Text)
                Dim client As New HttpClient()

                Dim url As String = "https://lfdev.de/php/get_keynumbers.php?hsn=" & TXB_KeyNumber.Text

                Dim response As HttpResponseMessage = Await client.GetAsync(url)

                If response.IsSuccessStatusCode Then
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

                            lbl_brand.Text = hersteller
                            lbl_model.Text = typbezeichnung ' Typbezeichnung in ein entsprechendes Label setzen

                            Dim leistung As String = cardata("Leistung").ToString()
                            Dim hubraum As String = cardata("Hubraum").ToString()
                            Dim kraftstoff As String = cardata("Energie").ToString()

                            lbl_power.Text = leistung
                            lbl_displacement.Text = hubraum
                        End If

                    Else
                        MsgBox("Keine Daten gefunden", MsgBoxStyle.Information, Title:="Info")
                    End If
                Else
                    MsgBox("Fehler beim Abrufen der Daten", MsgBoxStyle.Critical, Title:="Fehler")
                End If
            Else
                MsgBox("Bitte HSN/TSN mit mindestens 7 Zeichen eintragen", MsgBoxStyle.Information, Title:="Info")
            End If
        Else
            MsgBox("Bitte HSN/TSN eintragen", MsgBoxStyle.Information, Title:="Info")
        End If
    End Sub


    Private Function GetHSN(input As String) As String
        Return If(input.Length >= 4, input.Substring(0, 4), input)
    End Function

    Private Function GetTSN(input As String) As String
        Return If(input.Length >= 8, input.Substring(5, 3), input.Substring(4))
    End Function

    Private Function GetBrand(input As String) As String
        Dim index As Integer = input.IndexOf(" ")
        Return If(index >= 0, input.Substring(0, index), input)
    End Function

    Private Function GetModel(input As String) As String
        Dim index As Integer = input.IndexOf(" ")
        Return If(index >= 0, input.Substring(index + 1), "")
    End Function

    Private Sub TXB_KeyNumber_TextChanged(sender As Object, e As EventArgs) Handles TXB_KeyNumber.TextChanged

    End Sub

    Private Sub TXB_KeyNumber_KeyDown(sender As Object, e As KeyEventArgs) Handles TXB_KeyNumber.KeyDown
        If e.KeyCode = Keys.Enter Then
            BTN_Search.PerformClick()
        End If
        If TXB_KeyNumber.Text.Length = 4 Then
            TXB_KeyNumber.Text += "/"
            TXB_KeyNumber.SelectionStart = TXB_KeyNumber.Text.Length
        End If

    End Sub

    Private Sub KeyNumbers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadOverallSettings()
    End Sub

End Class