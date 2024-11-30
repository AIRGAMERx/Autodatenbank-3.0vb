<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class NewCar
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NewCar))
        Me.GB_CarInfo = New System.Windows.Forms.GroupBox()
        Me.CBB_NextInspectionYear = New System.Windows.Forms.ComboBox()
        Me.CBB_NextInspectionMonth = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TXB_KeyNumber = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TXB_ConstructionYear = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TXB_VIN = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TXB_Power = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TXB_Displacement = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TXB_Motorcode = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TXB_Licenseplate = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TXB_Model = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TXB_Brand = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CBB_Customer = New System.Windows.Forms.ComboBox()
        Me.BTN_SearchForKeyNumber = New System.Windows.Forms.Button()
        Me.BTN_SaveCar = New System.Windows.Forms.Button()
        Me.TXB_Price = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TXB_BuyDate = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.GB_CarInfo.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GB_CarInfo
        '
        Me.GB_CarInfo.Controls.Add(Me.CBB_NextInspectionYear)
        Me.GB_CarInfo.Controls.Add(Me.CBB_NextInspectionMonth)
        Me.GB_CarInfo.Controls.Add(Me.Label14)
        Me.GB_CarInfo.Controls.Add(Me.Label10)
        Me.GB_CarInfo.Controls.Add(Me.TXB_KeyNumber)
        Me.GB_CarInfo.Controls.Add(Me.Label9)
        Me.GB_CarInfo.Controls.Add(Me.TXB_ConstructionYear)
        Me.GB_CarInfo.Controls.Add(Me.Label5)
        Me.GB_CarInfo.Controls.Add(Me.TXB_VIN)
        Me.GB_CarInfo.Controls.Add(Me.Label6)
        Me.GB_CarInfo.Controls.Add(Me.TXB_Power)
        Me.GB_CarInfo.Controls.Add(Me.Label7)
        Me.GB_CarInfo.Controls.Add(Me.TXB_Displacement)
        Me.GB_CarInfo.Controls.Add(Me.Label8)
        Me.GB_CarInfo.Controls.Add(Me.TXB_Motorcode)
        Me.GB_CarInfo.Controls.Add(Me.Label3)
        Me.GB_CarInfo.Controls.Add(Me.TXB_Licenseplate)
        Me.GB_CarInfo.Controls.Add(Me.Label4)
        Me.GB_CarInfo.Controls.Add(Me.TXB_Model)
        Me.GB_CarInfo.Controls.Add(Me.Label2)
        Me.GB_CarInfo.Controls.Add(Me.TXB_Brand)
        Me.GB_CarInfo.Controls.Add(Me.Label1)
        Me.GB_CarInfo.Location = New System.Drawing.Point(12, 12)
        Me.GB_CarInfo.Name = "GB_CarInfo"
        Me.GB_CarInfo.Size = New System.Drawing.Size(274, 564)
        Me.GB_CarInfo.TabIndex = 0
        Me.GB_CarInfo.TabStop = False
        Me.GB_CarInfo.Text = "Informationen Auto"
        '
        'CBB_NextInspectionYear
        '
        Me.CBB_NextInspectionYear.FormattingEnabled = True
        Me.CBB_NextInspectionYear.Location = New System.Drawing.Point(132, 526)
        Me.CBB_NextInspectionYear.Name = "CBB_NextInspectionYear"
        Me.CBB_NextInspectionYear.Size = New System.Drawing.Size(115, 21)
        Me.CBB_NextInspectionYear.TabIndex = 21
        '
        'CBB_NextInspectionMonth
        '
        Me.CBB_NextInspectionMonth.FormattingEnabled = True
        Me.CBB_NextInspectionMonth.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12"})
        Me.CBB_NextInspectionMonth.Location = New System.Drawing.Point(9, 526)
        Me.CBB_NextInspectionMonth.Name = "CBB_NextInspectionMonth"
        Me.CBB_NextInspectionMonth.Size = New System.Drawing.Size(117, 21)
        Me.CBB_NextInspectionMonth.TabIndex = 20
        Me.CBB_NextInspectionMonth.Text = "01"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(6, 510)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(117, 13)
        Me.Label14.TabIndex = 19
        Me.Label14.Text = "Nächste HU/AU (TÜV)"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(118, 135)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(140, 13)
        Me.Label10.TabIndex = 18
        Me.Label10.Text = "Formatierung XXX-XX-XXXX"
        '
        'TXB_KeyNumber
        '
        Me.TXB_KeyNumber.Location = New System.Drawing.Point(9, 478)
        Me.TXB_KeyNumber.Name = "TXB_KeyNumber"
        Me.TXB_KeyNumber.Size = New System.Drawing.Size(249, 20)
        Me.TXB_KeyNumber.TabIndex = 17
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 457)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(148, 13)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "HSN/TSN (Schlüsselnummer)"
        '
        'TXB_ConstructionYear
        '
        Me.TXB_ConstructionYear.Location = New System.Drawing.Point(9, 424)
        Me.TXB_ConstructionYear.Name = "TXB_ConstructionYear"
        Me.TXB_ConstructionYear.Size = New System.Drawing.Size(249, 20)
        Me.TXB_ConstructionYear.TabIndex = 15
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 403)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 13)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Baujahr"
        '
        'TXB_VIN
        '
        Me.TXB_VIN.Location = New System.Drawing.Point(9, 371)
        Me.TXB_VIN.Name = "TXB_VIN"
        Me.TXB_VIN.Size = New System.Drawing.Size(249, 20)
        Me.TXB_VIN.TabIndex = 13
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 350)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(24, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "FIN"
        '
        'TXB_Power
        '
        Me.TXB_Power.Location = New System.Drawing.Point(9, 317)
        Me.TXB_Power.Name = "TXB_Power"
        Me.TXB_Power.Size = New System.Drawing.Size(249, 20)
        Me.TXB_Power.TabIndex = 11
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 296)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(75, 13)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Leistung in PS"
        '
        'TXB_Displacement
        '
        Me.TXB_Displacement.Location = New System.Drawing.Point(9, 263)
        Me.TXB_Displacement.Name = "TXB_Displacement"
        Me.TXB_Displacement.Size = New System.Drawing.Size(249, 20)
        Me.TXB_Displacement.TabIndex = 9
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 242)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(84, 13)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "Hubraum in ccm"
        '
        'TXB_Motorcode
        '
        Me.TXB_Motorcode.Location = New System.Drawing.Point(9, 209)
        Me.TXB_Motorcode.Name = "TXB_Motorcode"
        Me.TXB_Motorcode.Size = New System.Drawing.Size(249, 20)
        Me.TXB_Motorcode.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 188)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(177, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Motorkennbuchstaben  (Motorcode)"
        '
        'TXB_Licenseplate
        '
        Me.TXB_Licenseplate.ForeColor = System.Drawing.Color.Gray
        Me.TXB_Licenseplate.Location = New System.Drawing.Point(9, 156)
        Me.TXB_Licenseplate.Name = "TXB_Licenseplate"
        Me.TXB_Licenseplate.Size = New System.Drawing.Size(249, 20)
        Me.TXB_Licenseplate.TabIndex = 5
        Me.TXB_Licenseplate.Text = "Pflichtfeld"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 135)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Kennzeichen"
        '
        'TXB_Model
        '
        Me.TXB_Model.Location = New System.Drawing.Point(9, 102)
        Me.TXB_Model.Name = "TXB_Model"
        Me.TXB_Model.Size = New System.Drawing.Size(249, 20)
        Me.TXB_Model.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 81)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Model"
        '
        'TXB_Brand
        '
        Me.TXB_Brand.Location = New System.Drawing.Point(9, 48)
        Me.TXB_Brand.Name = "TXB_Brand"
        Me.TXB_Brand.Size = New System.Drawing.Size(249, 20)
        Me.TXB_Brand.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Marke"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CBB_Customer)
        Me.GroupBox1.Controls.Add(Me.BTN_SearchForKeyNumber)
        Me.GroupBox1.Controls.Add(Me.BTN_SaveCar)
        Me.GroupBox1.Controls.Add(Me.TXB_Price)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.TXB_BuyDate)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Location = New System.Drawing.Point(292, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(275, 564)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Zusätzliche Informationen"
        '
        'CBB_Customer
        '
        Me.CBB_Customer.FormattingEnabled = True
        Me.CBB_Customer.Location = New System.Drawing.Point(6, 47)
        Me.CBB_Customer.Name = "CBB_Customer"
        Me.CBB_Customer.Size = New System.Drawing.Size(249, 21)
        Me.CBB_Customer.TabIndex = 27
        '
        'BTN_SearchForKeyNumber
        '
        Me.BTN_SearchForKeyNumber.Location = New System.Drawing.Point(6, 208)
        Me.BTN_SearchForKeyNumber.Name = "BTN_SearchForKeyNumber"
        Me.BTN_SearchForKeyNumber.Size = New System.Drawing.Size(249, 23)
        Me.BTN_SearchForKeyNumber.TabIndex = 26
        Me.BTN_SearchForKeyNumber.Text = "Nach HSN/TSN suchen"
        Me.BTN_SearchForKeyNumber.UseVisualStyleBackColor = True
        '
        'BTN_SaveCar
        '
        Me.BTN_SaveCar.Location = New System.Drawing.Point(6, 237)
        Me.BTN_SaveCar.Name = "BTN_SaveCar"
        Me.BTN_SaveCar.Size = New System.Drawing.Size(249, 23)
        Me.BTN_SaveCar.TabIndex = 25
        Me.BTN_SaveCar.Text = "Auto anlegen"
        Me.BTN_SaveCar.UseVisualStyleBackColor = True
        '
        'TXB_Price
        '
        Me.TXB_Price.Location = New System.Drawing.Point(6, 156)
        Me.TXB_Price.Name = "TXB_Price"
        Me.TXB_Price.Size = New System.Drawing.Size(249, 20)
        Me.TXB_Price.TabIndex = 24
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(3, 135)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(30, 13)
        Me.Label11.TabIndex = 23
        Me.Label11.Text = "Preis"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(3, 27)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(44, 13)
        Me.Label13.TabIndex = 19
        Me.Label13.Text = "Besitzer"
        '
        'TXB_BuyDate
        '
        Me.TXB_BuyDate.Location = New System.Drawing.Point(6, 102)
        Me.TXB_BuyDate.Name = "TXB_BuyDate"
        Me.TXB_BuyDate.Size = New System.Drawing.Size(249, 20)
        Me.TXB_BuyDate.TabIndex = 22
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(3, 81)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(62, 13)
        Me.Label12.TabIndex = 21
        Me.Label12.Text = "Gekauft am"
        '
        'NewCar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(574, 583)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GB_CarInfo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "NewCar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Neues Auto anlegen"
        Me.GB_CarInfo.ResumeLayout(False)
        Me.GB_CarInfo.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GB_CarInfo As GroupBox
    Friend WithEvents TXB_KeyNumber As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents TXB_ConstructionYear As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents TXB_VIN As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents TXB_Power As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents TXB_Displacement As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents TXB_Motorcode As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TXB_Licenseplate As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TXB_Model As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TXB_Brand As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents BTN_SearchForKeyNumber As Button
    Friend WithEvents BTN_SaveCar As Button
    Friend WithEvents TXB_Price As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents TXB_BuyDate As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents CBB_Customer As ComboBox
    Friend WithEvents Label14 As Label
    Friend WithEvents CBB_NextInspectionYear As ComboBox
    Friend WithEvents CBB_NextInspectionMonth As ComboBox
End Class
