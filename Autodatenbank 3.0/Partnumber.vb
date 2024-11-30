Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Text.RegularExpressions
Imports HtmlAgilityPack

Public Class Partnumber
    Dim Searchlink As String = ""
    Private Sub BTN_SearchPartNumber_Click(sender As Object, e As EventArgs) Handles BTN_SearchPartNumber.Click
        If CBB_Brand.SelectedIndex > -1 And TXB_PartNumber.Text.Length > 0 Then
            Searchlink = CreateLink(TXB_PartNumber.Text)

            Dim client As New WebClient
            Cursor = Cursors.WaitCursor
            Try
                Dim html As String = client.DownloadString(Searchlink)
                Dim pattern As String = "<h2\s+itemprop=""name""><a\s+href=""([^""]+)"""


                Dim match As Match = Regex.Match(html, pattern)

                If match.Success Then

                    Dim link As String = match.Groups(1).Value
                    GetInfos(link)
                    Cursor = Cursors.Default
                Else
                    Console.WriteLine("Keine Links gefunden.")
                    Cursor = Cursors.Default
                End If
            Catch ex As Exception

                Console.WriteLine("Fehler beim Abrufen des HTML: " & ex.Message)
                SavetoLogFile(ex.Message, "GetPartInfos")
                Cursor = Cursors.Default
            End Try
        End If
    End Sub
    Private Sub GetInfos(Link As String)
        Dim client As New WebClient()

        Try
            Cursor = Cursors.WaitCursor
            Dim html As String = client.DownloadString(Link)

            ' HtmlDocument erstellen und HTML-Code laden
            Dim doc As New HtmlDocument()
            doc.LoadHtml(html)

            ' Beschreibung aus dem <meta name="description">-Tag extrahieren
            Dim descriptionElement As HtmlNode = doc.DocumentNode.SelectSingleNode("//meta[@name='description']")
            Dim descriptionContent As String = If(descriptionElement IsNot Nothing, descriptionElement.GetAttributeValue("content", ""), "")

            ' Extrahiere den Text vor dem ersten ":"
            Dim indexDescription As Integer = descriptionContent.IndexOf(":")
            Dim extractedDescription As String = If(indexDescription <> -1, descriptionContent.Substring(0, indexDescription), "N/A")
            LBL_Discription.Text = extractedDescription.Trim()

            ' Preis aus dem <div id="pd_puprice">-Element extrahieren
            Dim priceElement As HtmlNode = doc.DocumentNode.SelectSingleNode("//div[@id='pd_puprice']/span[@class='standard_price']")
            Dim priceText As String = If(priceElement IsNot Nothing, priceElement.InnerText.Trim(), "N/A")
            LBL_Price.Text = priceText

            ' Zusätzlich den Text aus dem <div itemprop="description">-Element extrahieren
            Dim descriptionDetailElement As HtmlNode = doc.DocumentNode.SelectSingleNode("//div[@itemprop='description']")
            Dim descriptionDetailText As String = If(descriptionDetailElement IsNot Nothing, ConvertHtmlToPlainText(descriptionDetailElement), "N/A")

            ' Hier kannst du den extrahierten descriptionDetailText weiterverarbeiten
            ' Zum Beispiel, um ihn in einer RichTextBox anzuzeigen
            RTB_ProductDiscription.Text = descriptionDetailText



            'Bild in Picturebox laden
            Dim imageElement As HtmlNode = doc.DocumentNode.SelectSingleNode("//a[@class='cbimages']/img[@itemprop='image']")
            If imageElement IsNot Nothing Then
                Dim imageUrl As String = imageElement.GetAttributeValue("src", "")
                If Not String.IsNullOrEmpty(imageUrl) Then
                    ' Bild von der URL herunterladen und in die PictureBox laden
                    Using clientImage As New WebClient()
                        Dim imageData As Byte() = clientImage.DownloadData(imageUrl)
                        If imageData IsNot Nothing AndAlso imageData.Length > 0 Then
                            Using ms As New MemoryStream(imageData)
                                Dim image As Image = Image.FromStream(ms)
                                PictureBox1.Image = image
                                PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
                            End Using
                        End If
                    End Using
                End If
            Else
                MsgBox("Bild nicht gefunden.")
            End If



        Catch ex As Exception
            MsgBox("Für diese Teilenummer konnte nichts gefunden werden.")
            SavetoLogFile(ex.Message, "GetPartInfos")
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Function CreateLink(nr As String) As String
        If CBB_Brand.SelectedItem.ToString = "Volkswagen" Then
            Return "https://www.onlineparts24.com/volkswagen-ersatzteile/search_results.php?keywords=" & nr
        ElseIf CBB_Brand.SelectedItem.ToString = "Audi" Then
            Return "https://www.onlineparts24.com/audi-ersatzteile/search_results.php?keywords=" & nr
        ElseIf CBB_Brand.SelectedItem.ToString = "Seat" Then
            Return "https://www.onlineparts24.com/seat-ersatzteile/search_results.php?keywords=" & nr
        ElseIf CBB_Brand.SelectedItem.ToString = "Skoda" Then
            Return "https://www.onlineparts24.com/skoda-ersatzteile/search_results.php?keywords=" & nr
        Else
            Return String.Empty
        End If


    End Function


    Private Function ConvertHtmlToPlainText(node As HtmlNode) As String
        Dim sb As New StringBuilder()

        For Each subNode As HtmlNode In node.ChildNodes
            If subNode.NodeType = HtmlNodeType.Text Then
                ' Textknoten hinzufügen
                sb.Append(subNode.InnerText)
            ElseIf subNode.Name = "br" Then
                ' Zeilenumbruch hinzufügen
                sb.AppendLine()
            ElseIf subNode.NodeType = HtmlNodeType.Element Then
                ' Rekursiv Unterknoten verarbeiten
                sb.Append(ConvertHtmlToPlainText(subNode))
            End If
        Next

        Return sb.ToString().Trim()
    End Function

    Private Sub Partnumber_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadOverallSettings()
    End Sub
End Class