<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CreateReportForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CreateReportForm))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.MainPanel = New System.Windows.Forms.Panel()
        Me.Btn_Previous = New System.Windows.Forms.Button()
        Me.BTN_Next = New System.Windows.Forms.Button()
        Me.OwnerPanel = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.RTB_Comment = New System.Windows.Forms.RichTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BTN_CreateReport = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lbl_EntryCurrent = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lbl_EntrySum = New System.Windows.Forms.Label()
        Me.GB_Other = New System.Windows.Forms.GroupBox()
        Me.TXB_hourlywage = New System.Windows.Forms.TextBox()
        Me.LBL_HourlyWage = New System.Windows.Forms.Label()
        Me.TXB_amountWorkingHours = New System.Windows.Forms.TextBox()
        Me.LBL_amouontWorkingHours = New System.Windows.Forms.Label()
        Me.CB_WorkingHours = New System.Windows.Forms.CheckBox()
        Me.CB_CreateBill = New System.Windows.Forms.CheckBox()
        Me.GB_Other.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(23, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(165, 20)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Ausgewählte Einträge"
        '
        'MainPanel
        '
        Me.MainPanel.BackColor = System.Drawing.Color.White
        Me.MainPanel.Location = New System.Drawing.Point(27, 52)
        Me.MainPanel.Name = "MainPanel"
        Me.MainPanel.Size = New System.Drawing.Size(751, 201)
        Me.MainPanel.TabIndex = 3
        '
        'Btn_Previous
        '
        Me.Btn_Previous.Location = New System.Drawing.Point(622, 259)
        Me.Btn_Previous.Name = "Btn_Previous"
        Me.Btn_Previous.Size = New System.Drawing.Size(75, 23)
        Me.Btn_Previous.TabIndex = 4
        Me.Btn_Previous.Text = "Zurück"
        Me.Btn_Previous.UseVisualStyleBackColor = True
        '
        'BTN_Next
        '
        Me.BTN_Next.Location = New System.Drawing.Point(703, 259)
        Me.BTN_Next.Name = "BTN_Next"
        Me.BTN_Next.Size = New System.Drawing.Size(75, 23)
        Me.BTN_Next.TabIndex = 5
        Me.BTN_Next.Text = "Weiter"
        Me.BTN_Next.UseVisualStyleBackColor = True
        '
        'OwnerPanel
        '
        Me.OwnerPanel.BackColor = System.Drawing.Color.White
        Me.OwnerPanel.Location = New System.Drawing.Point(27, 295)
        Me.OwnerPanel.Name = "OwnerPanel"
        Me.OwnerPanel.Size = New System.Drawing.Size(751, 201)
        Me.OwnerPanel.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(23, 269)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(180, 20)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Fahrzeug Informationen"
        '
        'RTB_Comment
        '
        Me.RTB_Comment.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RTB_Comment.Location = New System.Drawing.Point(27, 537)
        Me.RTB_Comment.Name = "RTB_Comment"
        Me.RTB_Comment.Size = New System.Drawing.Size(751, 211)
        Me.RTB_Comment.TabIndex = 7
        Me.RTB_Comment.Text = ""
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(23, 511)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(143, 20)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Ausgeführte Arbeit"
        '
        'BTN_CreateReport
        '
        Me.BTN_CreateReport.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_CreateReport.Location = New System.Drawing.Point(27, 941)
        Me.BTN_CreateReport.Name = "BTN_CreateReport"
        Me.BTN_CreateReport.Size = New System.Drawing.Size(751, 74)
        Me.BTN_CreateReport.TabIndex = 9
        Me.BTN_CreateReport.Text = "Bericht erstellen"
        Me.BTN_CreateReport.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(464, 259)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 20)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Eintrag"
        '
        'lbl_EntryCurrent
        '
        Me.lbl_EntryCurrent.AutoSize = True
        Me.lbl_EntryCurrent.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_EntryCurrent.Location = New System.Drawing.Point(530, 259)
        Me.lbl_EntryCurrent.Name = "lbl_EntryCurrent"
        Me.lbl_EntryCurrent.Size = New System.Drawing.Size(18, 20)
        Me.lbl_EntryCurrent.TabIndex = 11
        Me.lbl_EntryCurrent.Text = "0"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(554, 262)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(13, 20)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "/"
        '
        'lbl_EntrySum
        '
        Me.lbl_EntrySum.AutoSize = True
        Me.lbl_EntrySum.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_EntrySum.Location = New System.Drawing.Point(573, 259)
        Me.lbl_EntrySum.Name = "lbl_EntrySum"
        Me.lbl_EntrySum.Size = New System.Drawing.Size(18, 20)
        Me.lbl_EntrySum.TabIndex = 13
        Me.lbl_EntrySum.Text = "1"
        '
        'GB_Other
        '
        Me.GB_Other.BackColor = System.Drawing.Color.White
        Me.GB_Other.Controls.Add(Me.TXB_hourlywage)
        Me.GB_Other.Controls.Add(Me.LBL_HourlyWage)
        Me.GB_Other.Controls.Add(Me.TXB_amountWorkingHours)
        Me.GB_Other.Controls.Add(Me.LBL_amouontWorkingHours)
        Me.GB_Other.Controls.Add(Me.CB_WorkingHours)
        Me.GB_Other.Controls.Add(Me.CB_CreateBill)
        Me.GB_Other.Location = New System.Drawing.Point(27, 755)
        Me.GB_Other.Name = "GB_Other"
        Me.GB_Other.Size = New System.Drawing.Size(751, 180)
        Me.GB_Other.TabIndex = 14
        Me.GB_Other.TabStop = False
        Me.GB_Other.Text = "Sonstige Einstellungen"
        '
        'TXB_hourlywage
        '
        Me.TXB_hourlywage.Enabled = False
        Me.TXB_hourlywage.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXB_hourlywage.Location = New System.Drawing.Point(13, 140)
        Me.TXB_hourlywage.Name = "TXB_hourlywage"
        Me.TXB_hourlywage.Size = New System.Drawing.Size(181, 22)
        Me.TXB_hourlywage.TabIndex = 5
        Me.TXB_hourlywage.Text = "0"
        '
        'LBL_HourlyWage
        '
        Me.LBL_HourlyWage.AutoSize = True
        Me.LBL_HourlyWage.Enabled = False
        Me.LBL_HourlyWage.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_HourlyWage.Location = New System.Drawing.Point(10, 121)
        Me.LBL_HourlyWage.Name = "LBL_HourlyWage"
        Me.LBL_HourlyWage.Size = New System.Drawing.Size(38, 16)
        Me.LBL_HourlyWage.TabIndex = 4
        Me.LBL_HourlyWage.Text = "€/Std"
        '
        'TXB_amountWorkingHours
        '
        Me.TXB_amountWorkingHours.Enabled = False
        Me.TXB_amountWorkingHours.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXB_amountWorkingHours.Location = New System.Drawing.Point(13, 87)
        Me.TXB_amountWorkingHours.Name = "TXB_amountWorkingHours"
        Me.TXB_amountWorkingHours.Size = New System.Drawing.Size(181, 22)
        Me.TXB_amountWorkingHours.TabIndex = 3
        Me.TXB_amountWorkingHours.Text = "0"
        '
        'LBL_amouontWorkingHours
        '
        Me.LBL_amouontWorkingHours.AutoSize = True
        Me.LBL_amouontWorkingHours.Enabled = False
        Me.LBL_amouontWorkingHours.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_amouontWorkingHours.Location = New System.Drawing.Point(10, 68)
        Me.LBL_amouontWorkingHours.Name = "LBL_amouontWorkingHours"
        Me.LBL_amouontWorkingHours.Size = New System.Drawing.Size(49, 16)
        Me.LBL_amouontWorkingHours.TabIndex = 2
        Me.LBL_amouontWorkingHours.Text = "Menge"
        '
        'CB_WorkingHours
        '
        Me.CB_WorkingHours.AutoSize = True
        Me.CB_WorkingHours.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CB_WorkingHours.Location = New System.Drawing.Point(13, 45)
        Me.CB_WorkingHours.Name = "CB_WorkingHours"
        Me.CB_WorkingHours.Size = New System.Drawing.Size(181, 20)
        Me.CB_WorkingHours.TabIndex = 1
        Me.CB_WorkingHours.Text = "Arbeitsstunden hinzufügen"
        Me.CB_WorkingHours.UseVisualStyleBackColor = True
        '
        'CB_CreateBill
        '
        Me.CB_CreateBill.AutoSize = True
        Me.CB_CreateBill.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CB_CreateBill.Location = New System.Drawing.Point(13, 19)
        Me.CB_CreateBill.Name = "CB_CreateBill"
        Me.CB_CreateBill.Size = New System.Drawing.Size(163, 20)
        Me.CB_CreateBill.TabIndex = 0
        Me.CB_CreateBill.Text = "Als Rechnung erstellen"
        Me.CB_CreateBill.UseVisualStyleBackColor = True
        '
        'CreateReportForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(790, 1027)
        Me.Controls.Add(Me.GB_Other)
        Me.Controls.Add(Me.lbl_EntrySum)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lbl_EntryCurrent)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.BTN_CreateReport)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.RTB_Comment)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.OwnerPanel)
        Me.Controls.Add(Me.BTN_Next)
        Me.Controls.Add(Me.Btn_Previous)
        Me.Controls.Add(Me.MainPanel)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CreateReportForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Bericht erstellen"
        Me.GB_Other.ResumeLayout(False)
        Me.GB_Other.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents MainPanel As Panel
    Friend WithEvents Btn_Previous As Button
    Friend WithEvents BTN_Next As Button
    Friend WithEvents OwnerPanel As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents RTB_Comment As RichTextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents BTN_CreateReport As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents lbl_EntryCurrent As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents lbl_EntrySum As Label
    Friend WithEvents GB_Other As GroupBox
    Friend WithEvents CB_WorkingHours As CheckBox
    Friend WithEvents CB_CreateBill As CheckBox
    Friend WithEvents TXB_hourlywage As TextBox
    Friend WithEvents LBL_HourlyWage As Label
    Friend WithEvents TXB_amountWorkingHours As TextBox
    Friend WithEvents LBL_amouontWorkingHours As Label
End Class
