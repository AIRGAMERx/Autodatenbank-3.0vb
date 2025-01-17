<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Email
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Email))
        Me.GB_EmailSettings = New System.Windows.Forms.GroupBox()
        Me.TXB_SMTP = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TXB_Port = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TXB_LoginEmail = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TXB_password = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TXB_SenderEmail = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TXB_SenderDisplayName = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TXB_Timeout = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.BTN_Save = New System.Windows.Forms.Button()
        Me.CB_SSL = New System.Windows.Forms.CheckBox()
        Me.GB_EmailSettings.SuspendLayout()
        Me.SuspendLayout()
        '
        'GB_EmailSettings
        '
        Me.GB_EmailSettings.Controls.Add(Me.CB_SSL)
        Me.GB_EmailSettings.Controls.Add(Me.BTN_Save)
        Me.GB_EmailSettings.Controls.Add(Me.TXB_Timeout)
        Me.GB_EmailSettings.Controls.Add(Me.Label7)
        Me.GB_EmailSettings.Controls.Add(Me.TXB_SenderDisplayName)
        Me.GB_EmailSettings.Controls.Add(Me.Label6)
        Me.GB_EmailSettings.Controls.Add(Me.TXB_SenderEmail)
        Me.GB_EmailSettings.Controls.Add(Me.Label5)
        Me.GB_EmailSettings.Controls.Add(Me.TXB_password)
        Me.GB_EmailSettings.Controls.Add(Me.Label4)
        Me.GB_EmailSettings.Controls.Add(Me.TXB_LoginEmail)
        Me.GB_EmailSettings.Controls.Add(Me.Label3)
        Me.GB_EmailSettings.Controls.Add(Me.TXB_Port)
        Me.GB_EmailSettings.Controls.Add(Me.Label2)
        Me.GB_EmailSettings.Controls.Add(Me.TXB_SMTP)
        Me.GB_EmailSettings.Controls.Add(Me.Label1)
        Me.GB_EmailSettings.Location = New System.Drawing.Point(12, 12)
        Me.GB_EmailSettings.Name = "GB_EmailSettings"
        Me.GB_EmailSettings.Size = New System.Drawing.Size(490, 497)
        Me.GB_EmailSettings.TabIndex = 0
        Me.GB_EmailSettings.TabStop = False
        Me.GB_EmailSettings.Text = "Verbindungseinstellungen"
        '
        'TXB_SMTP
        '
        Me.TXB_SMTP.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXB_SMTP.Location = New System.Drawing.Point(6, 43)
        Me.TXB_SMTP.Name = "TXB_SMTP"
        Me.TXB_SMTP.Size = New System.Drawing.Size(473, 26)
        Me.TXB_SMTP.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(142, 16)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "SMTP Server Adresse"
        '
        'TXB_Port
        '
        Me.TXB_Port.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXB_Port.Location = New System.Drawing.Point(9, 91)
        Me.TXB_Port.Name = "TXB_Port"
        Me.TXB_Port.Size = New System.Drawing.Size(473, 26)
        Me.TXB_Port.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 16)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Port "
        '
        'TXB_LoginEmail
        '
        Me.TXB_LoginEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXB_LoginEmail.Location = New System.Drawing.Point(9, 139)
        Me.TXB_LoginEmail.Name = "TXB_LoginEmail"
        Me.TXB_LoginEmail.Size = New System.Drawing.Size(473, 26)
        Me.TXB_LoginEmail.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 120)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(132, 16)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Login Email-Adresse"
        '
        'TXB_password
        '
        Me.TXB_password.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXB_password.Location = New System.Drawing.Point(9, 187)
        Me.TXB_password.Name = "TXB_password"
        Me.TXB_password.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TXB_password.Size = New System.Drawing.Size(473, 26)
        Me.TXB_password.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(6, 168)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 16)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Passwort"
        '
        'TXB_SenderEmail
        '
        Me.TXB_SenderEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXB_SenderEmail.Location = New System.Drawing.Point(9, 235)
        Me.TXB_SenderEmail.Name = "TXB_SenderEmail"
        Me.TXB_SenderEmail.Size = New System.Drawing.Size(473, 26)
        Me.TXB_SenderEmail.TabIndex = 11
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(6, 216)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(158, 16)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Absender Email-Adresse"
        '
        'TXB_SenderDisplayName
        '
        Me.TXB_SenderDisplayName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXB_SenderDisplayName.Location = New System.Drawing.Point(9, 283)
        Me.TXB_SenderDisplayName.Name = "TXB_SenderDisplayName"
        Me.TXB_SenderDisplayName.Size = New System.Drawing.Size(473, 26)
        Me.TXB_SenderDisplayName.TabIndex = 13
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(6, 264)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(243, 16)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Anzeige Sendername (z.b Firmenname)"
        '
        'TXB_Timeout
        '
        Me.TXB_Timeout.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXB_Timeout.Location = New System.Drawing.Point(9, 331)
        Me.TXB_Timeout.Name = "TXB_Timeout"
        Me.TXB_Timeout.Size = New System.Drawing.Size(473, 26)
        Me.TXB_Timeout.TabIndex = 15
        Me.TXB_Timeout.Text = "3000"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(6, 312)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(221, 16)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Timeout des Sendeversuchs (in ms)"
        '
        'BTN_Save
        '
        Me.BTN_Save.BackColor = System.Drawing.Color.LightGray
        Me.BTN_Save.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!)
        Me.BTN_Save.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.BTN_Save.Location = New System.Drawing.Point(0, 405)
        Me.BTN_Save.Name = "BTN_Save"
        Me.BTN_Save.Size = New System.Drawing.Size(473, 86)
        Me.BTN_Save.TabIndex = 36
        Me.BTN_Save.Text = "Test Email versenden und Daten speichern"
        Me.BTN_Save.UseVisualStyleBackColor = False
        '
        'CB_SSL
        '
        Me.CB_SSL.AutoSize = True
        Me.CB_SSL.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CB_SSL.Location = New System.Drawing.Point(9, 364)
        Me.CB_SSL.Name = "CB_SSL"
        Me.CB_SSL.Size = New System.Drawing.Size(133, 24)
        Me.CB_SSL.TabIndex = 37
        Me.CB_SSL.Text = "Use SSL / TLS"
        Me.CB_SSL.UseVisualStyleBackColor = True
        '
        'Email
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(526, 550)
        Me.Controls.Add(Me.GB_EmailSettings)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Email"
        Me.Text = "Email Einstellungen"
        Me.GB_EmailSettings.ResumeLayout(False)
        Me.GB_EmailSettings.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GB_EmailSettings As GroupBox
    Friend WithEvents TXB_SMTP As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TXB_SenderDisplayName As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents TXB_SenderEmail As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents TXB_password As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TXB_LoginEmail As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TXB_Port As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TXB_Timeout As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents BTN_Save As Button
    Friend WithEvents CB_SSL As CheckBox
End Class
