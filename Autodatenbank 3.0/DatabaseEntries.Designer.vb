<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DatabaseEntries
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DatabaseEntries))
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TXB_Price = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TXB_Date = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TXB_Mileage = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TXB_Description = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.RTB_Comment = New System.Windows.Forms.RichTextBox()
        Me.LBL_Licenseplate = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CBB_TypeOfEntry = New System.Windows.Forms.ComboBox()
        Me.BTN_Save = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(9, 262)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(258, 13)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "Kommentar (Artikelnummern, Ausführung durch, etc..)"
        '
        'TXB_Price
        '
        Me.TXB_Price.Location = New System.Drawing.Point(12, 234)
        Me.TXB_Price.Name = "TXB_Price"
        Me.TXB_Price.Size = New System.Drawing.Size(518, 20)
        Me.TXB_Price.TabIndex = 14
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 212)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(30, 13)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Preis"
        '
        'TXB_Date
        '
        Me.TXB_Date.Location = New System.Drawing.Point(12, 184)
        Me.TXB_Date.Name = "TXB_Date"
        Me.TXB_Date.Size = New System.Drawing.Size(518, 20)
        Me.TXB_Date.TabIndex = 13
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(9, 162)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 13)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Datum"
        '
        'TXB_Mileage
        '
        Me.TXB_Mileage.Location = New System.Drawing.Point(12, 134)
        Me.TXB_Mileage.Name = "TXB_Mileage"
        Me.TXB_Mileage.Size = New System.Drawing.Size(518, 20)
        Me.TXB_Mileage.TabIndex = 11
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 112)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Kilometer"
        '
        'TXB_Description
        '
        Me.TXB_Description.Location = New System.Drawing.Point(12, 84)
        Me.TXB_Description.Name = "TXB_Description"
        Me.TXB_Description.Size = New System.Drawing.Size(518, 20)
        Me.TXB_Description.TabIndex = 10
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 62)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Bezeichnung"
        '
        'RTB_Comment
        '
        Me.RTB_Comment.Location = New System.Drawing.Point(12, 278)
        Me.RTB_Comment.Name = "RTB_Comment"
        Me.RTB_Comment.Size = New System.Drawing.Size(518, 148)
        Me.RTB_Comment.TabIndex = 18
        Me.RTB_Comment.Text = ""
        '
        'LBL_Licenseplate
        '
        Me.LBL_Licenseplate.AutoSize = True
        Me.LBL_Licenseplate.Location = New System.Drawing.Point(13, 13)
        Me.LBL_Licenseplate.Name = "LBL_Licenseplate"
        Me.LBL_Licenseplate.Size = New System.Drawing.Size(69, 13)
        Me.LBL_Licenseplate.TabIndex = 20
        Me.LBL_Licenseplate.Text = "Kennzeichen"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(406, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 13)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Art des Eintrags"
        '
        'CBB_TypeOfEntry
        '
        Me.CBB_TypeOfEntry.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBB_TypeOfEntry.FormattingEnabled = True
        Me.CBB_TypeOfEntry.Items.AddRange(New Object() {"Wartung", "Reparatur", "Sonstiges"})
        Me.CBB_TypeOfEntry.Location = New System.Drawing.Point(409, 25)
        Me.CBB_TypeOfEntry.Name = "CBB_TypeOfEntry"
        Me.CBB_TypeOfEntry.Size = New System.Drawing.Size(121, 24)
        Me.CBB_TypeOfEntry.TabIndex = 22
        '
        'BTN_Save
        '
        Me.BTN_Save.BackColor = System.Drawing.Color.LightGray
        Me.BTN_Save.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!)
        Me.BTN_Save.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.BTN_Save.Location = New System.Drawing.Point(12, 432)
        Me.BTN_Save.Name = "BTN_Save"
        Me.BTN_Save.Size = New System.Drawing.Size(525, 86)
        Me.BTN_Save.TabIndex = 36
        Me.BTN_Save.Text = "Eintrag speichern"
        Me.BTN_Save.UseVisualStyleBackColor = False
        '
        'DatabaseEntries
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(549, 522)
        Me.Controls.Add(Me.BTN_Save)
        Me.Controls.Add(Me.CBB_TypeOfEntry)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LBL_Licenseplate)
        Me.Controls.Add(Me.RTB_Comment)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.TXB_Price)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TXB_Date)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TXB_Mileage)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TXB_Description)
        Me.Controls.Add(Me.Label2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "DatabaseEntries"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Datenbankeintrag neu erstellen"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label9 As Label
    Friend WithEvents TXB_Price As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TXB_Date As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents TXB_Mileage As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TXB_Description As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents RTB_Comment As RichTextBox
    Friend WithEvents LBL_Licenseplate As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents CBB_TypeOfEntry As ComboBox
    Friend WithEvents BTN_Save As Button
End Class
