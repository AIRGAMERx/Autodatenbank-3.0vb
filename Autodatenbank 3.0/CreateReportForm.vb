Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports iTextSharp.text.pdf.draw

Public Class CreateReportForm

    ' Definition von Listen für die TextBoxen
    Private txtBezeichnungen As New List(Of TextBox)

    Private txtPreise As New List(Of TextBox)
    Private txtKommentare As New List(Of TextBox)
    Private txtKilometerListe As New List(Of TextBox) ' Umbenennen der Liste
    Private txtDaten As New List(Of TextBox)

    ' Definition von Klassenvariablen für die TextBoxen im OwnerPanel
    Private txtOwner As TextBox

    Private txtMarke As TextBox
    Private txtModel As TextBox
    Private txtKennzeichen As TextBox
    Private txtMotorkennbuchstaben As TextBox
    Private txtFIN As TextBox
    Private txtHSN As TextBox

    Private ReportPanels As New List(Of Panel)
    Private currentIndex As Integer

    Private Sub CreateReportForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadOverallSettings()
        MainPanel.Controls.Clear()
        MainPanel.Size = New Size(Me.Width - 50, 200)
        OwnerPanel.Controls.Clear()

        ' Dynamisch Panels basierend auf den ausgewählten Indizes hinzufügen
        For Each index As String In Autodatenbank.ReportSelect
            Dim rowIndex As Integer = Convert.ToInt32(index)
            Dim row As DataGridViewRow = Autodatenbank.dgv.Rows(rowIndex)

            ' Dynamisch ein neues Panel hinzufügen
            Dim newPanel As New Panel With {
                .Size = New Size(MainPanel.Width - 20, MainPanel.Height - 20),
                .BorderStyle = BorderStyle.FixedSingle,
                .Margin = New Padding(10),
                .Location = New Point(10, 10)
            }

            ' Bezeichnung Label und TextBox hinzufügen
            Dim lblBezeichnung As New Label With {
                .Location = New Point(10, 10),
                .Size = New Size(100, 20),
                .Text = "Bezeichnung:"
            }
            newPanel.Controls.Add(lblBezeichnung)

            Dim txtBezeichnung As New TextBox With {
                .Location = New Point(120, 10),
                .Size = New Size(150, 20),
                .Text = row.Cells("Bezeichnung").Value.ToString()
            }
            newPanel.Controls.Add(txtBezeichnung)
            txtBezeichnungen.Add(txtBezeichnung)

            ' Preis Label und TextBox hinzufügen
            Dim lblPreis As New Label With {
                .Location = New Point(10, 40),
                .Size = New Size(100, 20),
                .Text = "Preis:"
            }
            newPanel.Controls.Add(lblPreis)

            Dim txtPreis As New TextBox With {
                .Location = New Point(120, 40),
                .Size = New Size(150, 20),
                .Text = row.Cells("Preis in €").Value.ToString()
            }
            newPanel.Controls.Add(txtPreis)
            txtPreise.Add(txtPreis)

            ' Kommentar Label und TextBox hinzufügen
            Dim lblKommentar As New Label With {
                .Location = New Point(10, 70),
                .Size = New Size(100, 20),
                .Text = "Kommentar:"
            }
            newPanel.Controls.Add(lblKommentar)

            Dim txtKommentar As New TextBox With {
                .Location = New Point(120, 70),
                .Size = New Size(MainPanel.Width - 200, 60),
                .Multiline = True,
                .Text = row.Cells("Kommentar").Value.ToString()
            }
            newPanel.Controls.Add(txtKommentar)
            txtKommentare.Add(txtKommentar)

            ' Kilometer Label und TextBox hinzufügen
            Dim lblKilometer As New Label With {
                .Location = New Point(300, 40),
                .Size = New Size(100, 20),
                .Text = "Kilometer:"
            }
            newPanel.Controls.Add(lblKilometer)

            Dim txtKilometer As New TextBox With {
                .Location = New Point(400, 40),
                .Size = New Size(150, 20),
                .Text = row.Cells("Kilometer").Value.ToString()
            }
            newPanel.Controls.Add(txtKilometer)
            txtKilometerListe.Add(txtKilometer) ' Hinzufügen zur umbenannten Liste

            ' Datum Label und TextBox hinzufügen
            Dim lblDatum As New Label With {
                .Location = New Point(300, 10),
                .Size = New Size(100, 20),
                .Text = "Datum:"
            }
            newPanel.Controls.Add(lblDatum)

            Dim txtDatum As New TextBox With {
                .Location = New Point(400, 10),
                .Size = New Size(150, 20),
                .Text = row.Cells("Datum").Value.ToString()
            }
            newPanel.Controls.Add(txtDatum)
            txtDaten.Add(txtDatum)

            ' Das neue Panel zur Liste hinzufügen
            ReportPanels.Add(newPanel)
        Next

        ' Zeigen Sie das erste Panel an
        If ReportPanels.Count > 0 Then
            ShowPanel(0)
        Else
            MessageBox.Show("Keine Einträge ausgewählt.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        ' Erstellen und hinzufügen des OwnerPanel
        Dim OwnerPan As New Panel With {
            .Size = New Size(OwnerPanel.Width - 20, MainPanel.Height - 20),
            .BorderStyle = BorderStyle.FixedSingle,
            .Margin = New Padding(10),
            .Location = New Point(10, 10)
        }

        ' Besitzer Label und TextBox hinzufügen
        Dim lblOwner As New Label With {
            .Location = New Point(10, 10),
            .Size = New Size(100, 20),
            .Text = "Besitzer:"
        }
        OwnerPan.Controls.Add(lblOwner)

        txtOwner = New TextBox With {
            .Location = New Point(120, 10),
            .Size = New Size(150, 20),
            .Text = Autodatenbank.TXB_Owner.Text,
            .Enabled = False
        }
        OwnerPan.Controls.Add(txtOwner)

        ' Marke Label und TextBox hinzufügen
        Dim lblMarke As New Label With {
            .Location = New Point(10, 40),
            .Size = New Size(100, 20),
            .Text = "Marke:"
        }
        OwnerPan.Controls.Add(lblMarke)

        txtMarke = New TextBox With {
            .Location = New Point(120, 40),
            .Size = New Size(150, 20),
            .Text = Autodatenbank.TXB_Brand.Text,
            .Enabled = True
        }
        OwnerPan.Controls.Add(txtMarke)

        ' Model Label und TextBox hinzufügen
        Dim lblModel As New Label With {
            .Location = New Point(10, 70),
            .Size = New Size(100, 20),
            .Text = "Model:"
        }
        OwnerPan.Controls.Add(lblModel)

        txtModel = New TextBox With {
            .Location = New Point(120, 70),
            .Size = New Size(150, 20),
            .Text = Autodatenbank.TXB_Model.Text,
            .Enabled = True
        }
        OwnerPan.Controls.Add(txtModel)

        ' Kennzeichen Label und TextBox hinzufügen
        Dim lblKennzeichen As New Label With {
            .Location = New Point(300, 10),
            .Size = New Size(100, 20),
            .Text = "Kennzeichen:"
        }
        OwnerPan.Controls.Add(lblKennzeichen)

        txtKennzeichen = New TextBox With {
            .Location = New Point(410, 10),
            .Size = New Size(150, 20),
            .Text = Autodatenbank.TXB_LicensePlate.Text,
            .Enabled = False
        }
        OwnerPan.Controls.Add(txtKennzeichen)

        ' Motorkennbuchstaben Label und TextBox hinzufügen
        Dim lblMotorkennbuchstaben As New Label With {
            .Location = New Point(300, 40),
            .Size = New Size(100, 20),
            .Text = "MKB:"
        }
        OwnerPan.Controls.Add(lblMotorkennbuchstaben)

        txtMotorkennbuchstaben = New TextBox With {
            .Location = New Point(410, 40),
            .Size = New Size(150, 20),
            .Text = Autodatenbank.TXB_Motorcode.Text,
            .Enabled = True
        }
        OwnerPan.Controls.Add(txtMotorkennbuchstaben)

        ' FIN Label und TextBox hinzufügen
        Dim lblFIN As New Label With {
            .Location = New Point(300, 70),
            .Size = New Size(100, 20),
            .Text = "FIN:"
        }
        OwnerPan.Controls.Add(lblFIN)

        txtFIN = New TextBox With {
            .Location = New Point(410, 70),
            .Size = New Size(150, 20),
            .Text = Autodatenbank.TXB_VIN.Text,
            .Enabled = True
        }
        OwnerPan.Controls.Add(txtFIN)

        ' HSN Label und TextBox hinzufügen
        Dim lblHSN As New Label With {
            .Location = New Point(300, 100),
            .Size = New Size(100, 20),
            .Text = "HSN/TSN:"
        }
        OwnerPan.Controls.Add(lblHSN)

        txtHSN = New TextBox With {
            .Location = New Point(410, 100),
            .Size = New Size(150, 20),
            .Text = Autodatenbank.TXB_KeyNumber.Text,
            .Enabled = True
        }
        OwnerPan.Controls.Add(txtHSN)

        ' Fügen Sie das Panel zu OwnerPanel hinzu
        OwnerPanel.Controls.Add(OwnerPan)
    End Sub

    Private Sub ShowPanel(index As Integer)
        If index >= 0 AndAlso index < ReportPanels.Count Then
            ' Entfernen Sie das aktuelle Panel aus dem MainPanel
            MainPanel.Controls.Clear()

            ' Fügen Sie das neue Panel hinzu
            MainPanel.Controls.Add(ReportPanels(index))

            ' Setzen Sie den aktuellen Index
            currentIndex = index

            ' Schaltflächen aktivieren/deaktivieren
            Btn_Previous.Enabled = (currentIndex > 0)
            BTN_Next.Enabled = (currentIndex < ReportPanels.Count - 1)

            ' Eintragsnummer anzeigen
            lbl_EntryCurrent.Text = (currentIndex + 1).ToString
            lbl_EntrySum.Text = (ReportPanels.Count).ToString
        End If
    End Sub

    ' Methode zum Anzeigen des vorherigen Panels
    Private Sub Btn_Previous_Click(sender As Object, e As EventArgs) Handles Btn_Previous.Click
        If currentIndex > 0 Then
            ShowPanel(currentIndex - 1)
        End If
    End Sub

    ' Methode zum Anzeigen des nächsten Panels
    Private Sub BTN_Next_Click(sender As Object, e As EventArgs) Handles BTN_Next.Click
        If currentIndex < ReportPanels.Count - 1 Then
            ShowPanel(currentIndex + 1)
        End If
    End Sub


    Private Sub BTN_CreateReport_Click(sender As Object, e As EventArgs) Handles BTN_CreateReport.Click
        Dim price As Decimal = 0D
        Dim salary As Decimal = 0D
        Dim pdfpath As String = Application.StartupPath & "\Temp\Lieferschein" & txtKennzeichen.Text & Now.Millisecond & ".pdf"
        Dim doc As New Document()
        PdfWriter.GetInstance(doc, New FileStream(pdfpath, FileMode.Create))
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

        ' Firmendaten hinzufügen
        Dim firmData As String = My.Settings.CompName & vbCrLf &
                           My.Settings.CompStreet & vbCrLf &
                          My.Settings.CompCity & vbCrLf &
                         "Bearbeiter: " & My.Settings.Username
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

        Dim headers As String() = {"Besitzer", "Kennzeichen", "Marke", "Modell", "MKB", "FIN", "HSN/TSN"}
        Dim vehicleData As String() = {txtOwner.Text, txtKennzeichen.Text, txtMarke.Text, txtModel.Text, txtMotorkennbuchstaben.Text, txtFIN.Text, txtHSN.Text}

        For i As Integer = 0 To headers.Length - 1
            Dim cellHeader As New PdfPCell(New Phrase(headers(i), FontFactory.GetFont("Arial", 10)))
            cellHeader.BorderWidth = 1
            vehicleTable.AddCell(cellHeader)
            vehicleTable.AddCell(vehicleData(i))
        Next

        doc.Add(vehicleTable)

        ' Einträge Tabelle
        Dim entryTable As New PdfPTable(5)
        entryTable.WidthPercentage = 100
        entryTable.SpacingAfter = 10
        entryTable.DefaultCell.Padding = 5

        Dim entryHeaders As String() = {"Bezeichnung", "Datum", "Preis", "Kilometer", "Kommentar"}
        For Each header As String In entryHeaders
            Dim cell As New PdfPCell(New Phrase(header, FontFactory.GetFont("Arial", 10)))
            cell.BorderWidth = 1
            cell.HorizontalAlignment = Element.ALIGN_CENTER
            entryTable.AddCell(cell)
        Next

        ' Einträge dynamisch hinzufügen
        For i As Integer = 0 To txtBezeichnungen.Count - 1
            entryTable.AddCell(txtBezeichnungen(i).Text)
            entryTable.AddCell(txtDaten(i).Text)
            entryTable.AddCell(txtPreise(i).Text)
            entryTable.AddCell(txtKilometerListe(i).Text)
            entryTable.AddCell(txtKommentare(i).Text)
            If IsNumeric(txtPreise(i).Text) Then
                price += CDec(txtPreise(i).Text)
            End If
        Next

        ' Arbeitsstunden hinzufügen
        If CB_WorkingHours.Checked Then
            If IsNumeric(TXB_amountWorkingHours.Text) AndAlso IsNumeric(TXB_hourlywage.Text) Then
                salary = CDec(TXB_amountWorkingHours.Text) * CDec(TXB_hourlywage.Text)
            Else
                MsgBox("Arbeitslohn konnte nicht berechnet werden.")
                Exit Sub
            End If

            entryTable.AddCell("Arbeitsstunden")
            entryTable.AddCell("Menge: " & TXB_amountWorkingHours.Text)
            entryTable.AddCell("€/h " & TXB_hourlywage.Text)
            entryTable.AddCell("∑ " & salary.ToString("C2"))
            entryTable.AddCell(" ")
        End If

        doc.Add(entryTable)

        If RTB_Comment.TextLength > 0 Then


            ' Berichtskommentar hinzufügen
            Dim commentHeader As New Paragraph("Ausgeführte Arbeit", FontFactory.GetFont("Arial", 10))
            commentHeader.SpacingBefore = 10
            doc.Add(commentHeader)
            doc.Add(New Paragraph(RTB_Comment.Text, FontFactory.GetFont("Arial", 10)))
        End If

        ' Summe für Materialien und Gehalt, falls Rechnung erstellt werden soll
        If CB_CreateBill.Checked Then
            ' Trennstrich
            Dim line As New LineSeparator(1.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_CENTER, -1)
            doc.Add(New Chunk(line))

            ' Berechnung und Anzeige von Materialpreis, Gehalt und Gesamtsumme
            Dim total As Decimal = price + salary

            Dim summaryParagraph As New Paragraph()
            summaryParagraph.SpacingBefore = 10
            summaryParagraph.Add(New Phrase("Preis für Materialien: " & price.ToString("C2") & Environment.NewLine, FontFactory.GetFont("Arial", 10)))
            summaryParagraph.Add(New Phrase("Preis für Arbeitslohn: " & salary.ToString("C2") & Environment.NewLine, FontFactory.GetFont("Arial", 10)))
            summaryParagraph.Add(New Phrase("Gesamtsumme: " & total.ToString("C2"), FontFactory.GetFont("Arial", 12)))
            summaryParagraph.Alignment = Element.ALIGN_RIGHT

            doc.Add(summaryParagraph)



            Dim signatureTable As New PdfPTable(3)
            signatureTable.WidthPercentage = 100
            signatureTable.SpacingBefore = 20

            ' Spaltenbreiten festlegen (z.B. 20% für Datum/Ort und 40% für jede Unterschriftsspalte)
            signatureTable.SetWidths(New Single() {20.0F, 40.0F, 40.0F})

            ' Kombinierte Zelle für Datum und Ort
            Dim locationText As String = InputBox("Bitte geben Sie den Ort ein:", "Ort eingeben")
            Dim dateAndLocationText As String = "Datum: " & DateTime.Now.ToString("dd.MM.yyyy") & vbCrLf & "Ort: " & locationText
            Dim dateAndLocationCell As New PdfPCell(New Phrase(dateAndLocationText, FontFactory.GetFont("Arial", 10)))
            dateAndLocationCell.Border = Rectangle.NO_BORDER
            dateAndLocationCell.HorizontalAlignment = Element.ALIGN_LEFT
            dateAndLocationCell.PaddingTop = 30
            signatureTable.AddCell(dateAndLocationCell)

            ' Unterschrift Ersteller - Platzhalter
            Dim creatorSignatureCell As New PdfPCell(New Phrase("Unterschrift Ersteller", FontFactory.GetFont("Arial", 10)))
            creatorSignatureCell.Border = Rectangle.NO_BORDER
            creatorSignatureCell.HorizontalAlignment = Element.ALIGN_CENTER
            creatorSignatureCell.PaddingTop = 30 ' Platz für die Unterschrift lassen
            signatureTable.AddCell(creatorSignatureCell)

            ' Unterschrift Kunde - Platzhalter
            Dim customerSignatureCell As New PdfPCell(New Phrase("Unterschrift Kunde", FontFactory.GetFont("Arial", 10)))
            customerSignatureCell.Border = Rectangle.NO_BORDER
            customerSignatureCell.HorizontalAlignment = Element.ALIGN_CENTER
            customerSignatureCell.PaddingTop = 30 ' Platz für die Unterschrift lassen
            signatureTable.AddCell(customerSignatureCell)

            ' Leere Zellen für zusätzlichen Platz hinzufügen
            Dim emptyCell As New PdfPCell(New Phrase(" "))
            emptyCell.Border = Rectangle.NO_BORDER
            signatureTable.AddCell(emptyCell)
            signatureTable.AddCell(emptyCell)
            signatureTable.AddCell(emptyCell)

            ' Tabelle zum Dokument hinzufügen
            doc.Add(signatureTable)


        End If


        ' Dokument schließen
        doc.Close()
        MessageBox.Show("PDF wurde erfolgreich erstellt!", "Erfolg", MessageBoxButtons.OK, MessageBoxIcon.Information)


        If File.Exists(pdfPath) Then
            Process.Start(pdfPath)
        Else
            MessageBox.Show("Die Datei konnte nicht gefunden werden.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub





    Private Function BerechneSummePreise() As Decimal
        Dim summe As Decimal = 0

        For Each txtPreis As TextBox In txtPreise
            Dim preis As Decimal
            If Decimal.TryParse(txtPreis.Text, preis) Then
                summe += preis
            End If
        Next

        Return summe
    End Function

    Private Sub CB_WorkingHours_CheckedChanged(sender As Object, e As EventArgs) Handles CB_WorkingHours.CheckedChanged
        If CB_WorkingHours.Checked Then
            LBL_amouontWorkingHours.Enabled = True
            LBL_HourlyWage.Enabled = True
            TXB_amountWorkingHours.Enabled = True
            TXB_hourlywage.Enabled = True
            TXB_hourlywage.Text = My.Settings.hourlywage.ToString
        Else
            LBL_amouontWorkingHours.Enabled = False
            LBL_HourlyWage.Enabled = False
            TXB_amountWorkingHours.Enabled = False
            TXB_hourlywage.Enabled = False
        End If
    End Sub

    Private Sub TXB_hourlywage_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXB_hourlywage.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "," AndAlso e.KeyChar <> ChrW(Keys.Back) Then
            ' Unterdrückt die Eingabe, wenn es keine erlaubte Taste ist
            e.Handled = True
        End If

        ' Optional: Verhindert mehr als ein Komma in der TextBox
        If e.KeyChar = "," AndAlso TXB_hourlywage.Text.Contains(",") Then
            e.Handled = True
        End If
    End Sub

    Private Sub TXB_amountWorkingHours_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXB_amountWorkingHours.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "," AndAlso e.KeyChar <> ChrW(Keys.Back) Then
            ' Unterdrückt die Eingabe, wenn es keine erlaubte Taste ist
            e.Handled = True
        End If
        If e.KeyChar = "," AndAlso TXB_amountWorkingHours.Text.Contains(",") Then
            e.Handled = True
        End If
    End Sub
End Class