<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NewUser
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NewUser))
        Me.TXB_UserName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GB_NFC = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TXB_UID = New System.Windows.Forms.TextBox()
        Me.CB_NFC = New System.Windows.Forms.CheckBox()
        Me.TXB_Password = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TXB_PasswordRepeat = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.BTN_Save = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cbb_PermissionRole = New System.Windows.Forms.ComboBox()
        Me.GB_NFC.SuspendLayout()
        Me.SuspendLayout()
        '
        'TXB_UserName
        '
        Me.TXB_UserName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXB_UserName.Location = New System.Drawing.Point(24, 44)
        Me.TXB_UserName.Name = "TXB_UserName"
        Me.TXB_UserName.Size = New System.Drawing.Size(473, 26)
        Me.TXB_UserName.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(21, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Benutzername"
        '
        'GB_NFC
        '
        Me.GB_NFC.Controls.Add(Me.Label2)
        Me.GB_NFC.Controls.Add(Me.TXB_UID)
        Me.GB_NFC.Controls.Add(Me.CB_NFC)
        Me.GB_NFC.Location = New System.Drawing.Point(24, 294)
        Me.GB_NFC.Name = "GB_NFC"
        Me.GB_NFC.Size = New System.Drawing.Size(473, 115)
        Me.GB_NFC.TabIndex = 2
        Me.GB_NFC.TabStop = False
        Me.GB_NFC.Text = "NFC"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 16)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "UID: "
        '
        'TXB_UID
        '
        Me.TXB_UID.Enabled = False
        Me.TXB_UID.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXB_UID.Location = New System.Drawing.Point(9, 62)
        Me.TXB_UID.Name = "TXB_UID"
        Me.TXB_UID.Size = New System.Drawing.Size(430, 26)
        Me.TXB_UID.TabIndex = 3
        '
        'CB_NFC
        '
        Me.CB_NFC.AutoSize = True
        Me.CB_NFC.Location = New System.Drawing.Point(9, 19)
        Me.CB_NFC.Name = "CB_NFC"
        Me.CB_NFC.Size = New System.Drawing.Size(148, 17)
        Me.CB_NFC.TabIndex = 0
        Me.CB_NFC.Text = "NFC Transpoder anlernen"
        Me.CB_NFC.UseVisualStyleBackColor = True
        '
        'TXB_Password
        '
        Me.TXB_Password.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXB_Password.Location = New System.Drawing.Point(24, 106)
        Me.TXB_Password.Name = "TXB_Password"
        Me.TXB_Password.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TXB_Password.Size = New System.Drawing.Size(473, 26)
        Me.TXB_Password.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(21, 87)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 16)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Passwort"
        '
        'TXB_PasswordRepeat
        '
        Me.TXB_PasswordRepeat.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXB_PasswordRepeat.Location = New System.Drawing.Point(24, 170)
        Me.TXB_PasswordRepeat.Name = "TXB_PasswordRepeat"
        Me.TXB_PasswordRepeat.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TXB_PasswordRepeat.Size = New System.Drawing.Size(473, 26)
        Me.TXB_PasswordRepeat.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(21, 151)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(138, 16)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Passwort wiederholen"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(438, 87)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(51, 13)
        Me.LinkLabel1.TabIndex = 10
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Anzeigen"
        '
        'BTN_Save
        '
        Me.BTN_Save.BackColor = System.Drawing.Color.LightGray
        Me.BTN_Save.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!)
        Me.BTN_Save.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.BTN_Save.Location = New System.Drawing.Point(24, 427)
        Me.BTN_Save.Name = "BTN_Save"
        Me.BTN_Save.Size = New System.Drawing.Size(473, 86)
        Me.BTN_Save.TabIndex = 35
        Me.BTN_Save.Text = "Benutzer anlegen"
        Me.BTN_Save.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(21, 212)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(121, 16)
        Me.Label5.TabIndex = 39
        Me.Label5.Text = "Berechtigungsstufe"
        '
        'cbb_PermissionRole
        '
        Me.cbb_PermissionRole.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbb_PermissionRole.FormattingEnabled = True
        Me.cbb_PermissionRole.Location = New System.Drawing.Point(24, 231)
        Me.cbb_PermissionRole.Name = "cbb_PermissionRole"
        Me.cbb_PermissionRole.Size = New System.Drawing.Size(473, 28)
        Me.cbb_PermissionRole.TabIndex = 38
        '
        'NewUser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(513, 547)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cbb_PermissionRole)
        Me.Controls.Add(Me.BTN_Save)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.TXB_PasswordRepeat)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TXB_Password)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.GB_NFC)
        Me.Controls.Add(Me.TXB_UserName)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "NewUser"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Benutzer anlegen"
        Me.GB_NFC.ResumeLayout(False)
        Me.GB_NFC.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TXB_UserName As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents GB_NFC As GroupBox
    Friend WithEvents CB_NFC As CheckBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TXB_UID As TextBox
    Friend WithEvents TXB_Password As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TXB_PasswordRepeat As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents BTN_Save As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents cbb_PermissionRole As ComboBox
End Class
