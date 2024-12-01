<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AdminSettings
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AdminSettings))
        Me.CB_SignActive = New System.Windows.Forms.CheckBox()
        Me.CB_RememberLogin = New System.Windows.Forms.CheckBox()
        Me.BTN_OpenSmartphoneVerification = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.BTN_SaveLoginSettings = New System.Windows.Forms.Button()
        Me.cb_CheckOldPass = New System.Windows.Forms.CheckBox()
        Me.CB_NFCVerify = New System.Windows.Forms.CheckBox()
        Me.CB_SmartphoneSignIn = New System.Windows.Forms.CheckBox()
        Me.TT_Informations = New System.Windows.Forms.ToolTip(Me.components)
        Me.GB_Permission = New System.Windows.Forms.GroupBox()
        Me.BTN_SaveEditRole = New System.Windows.Forms.Button()
        Me.GB_AddPermissionRole = New System.Windows.Forms.GroupBox()
        Me.BTN_SavePermissionRole = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TXB_NamePermissionRole = New System.Windows.Forms.TextBox()
        Me.CB_Print = New System.Windows.Forms.CheckBox()
        Me.CB_CreateNewCar = New System.Windows.Forms.CheckBox()
        Me.CB_DeleteData = New System.Windows.Forms.CheckBox()
        Me.CB_OpenData = New System.Windows.Forms.CheckBox()
        Me.CB_UploadData = New System.Windows.Forms.CheckBox()
        Me.CB_AdminPermission = New System.Windows.Forms.CheckBox()
        Me.CB_DeleteEntries = New System.Windows.Forms.CheckBox()
        Me.CB_DeleteUser = New System.Windows.Forms.CheckBox()
        Me.CB_EditUser = New System.Windows.Forms.CheckBox()
        Me.CB_CreateUser = New System.Windows.Forms.CheckBox()
        Me.CB_EditEntries = New System.Windows.Forms.CheckBox()
        Me.CB_CreateEntries = New System.Windows.Forms.CheckBox()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.GroupBox3.SuspendLayout()
        Me.GB_Permission.SuspendLayout()
        Me.GB_AddPermissionRole.SuspendLayout()
        Me.SuspendLayout()
        '
        'CB_SignActive
        '
        Me.CB_SignActive.AutoSize = True
        Me.CB_SignActive.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CB_SignActive.Location = New System.Drawing.Point(9, 19)
        Me.CB_SignActive.Name = "CB_SignActive"
        Me.CB_SignActive.Size = New System.Drawing.Size(155, 20)
        Me.CB_SignActive.TabIndex = 0
        Me.CB_SignActive.Text = "Anmeldung aktivieren"
        Me.CB_SignActive.UseVisualStyleBackColor = True
        '
        'CB_RememberLogin
        '
        Me.CB_RememberLogin.AutoSize = True
        Me.CB_RememberLogin.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CB_RememberLogin.Location = New System.Drawing.Point(9, 88)
        Me.CB_RememberLogin.Name = "CB_RememberLogin"
        Me.CB_RememberLogin.Size = New System.Drawing.Size(358, 20)
        Me.CB_RememberLogin.TabIndex = 4
        Me.CB_RememberLogin.Text = "Angemeldet bleiben beim schließen der Autodatenbank"
        Me.CB_RememberLogin.UseVisualStyleBackColor = True
        '
        'BTN_OpenSmartphoneVerification
        '
        Me.BTN_OpenSmartphoneVerification.Location = New System.Drawing.Point(198, 42)
        Me.BTN_OpenSmartphoneVerification.Name = "BTN_OpenSmartphoneVerification"
        Me.BTN_OpenSmartphoneVerification.Size = New System.Drawing.Size(146, 23)
        Me.BTN_OpenSmartphoneVerification.TabIndex = 5
        Me.BTN_OpenSmartphoneVerification.Text = "Smartphone Verbinden"
        Me.BTN_OpenSmartphoneVerification.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.BTN_SaveLoginSettings)
        Me.GroupBox3.Controls.Add(Me.cb_CheckOldPass)
        Me.GroupBox3.Controls.Add(Me.CB_NFCVerify)
        Me.GroupBox3.Controls.Add(Me.CB_SmartphoneSignIn)
        Me.GroupBox3.Controls.Add(Me.BTN_OpenSmartphoneVerification)
        Me.GroupBox3.Controls.Add(Me.CB_RememberLogin)
        Me.GroupBox3.Controls.Add(Me.CB_SignActive)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(387, 196)
        Me.GroupBox3.TabIndex = 6
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Anmeldung "
        '
        'BTN_SaveLoginSettings
        '
        Me.BTN_SaveLoginSettings.BackColor = System.Drawing.Color.LightGray
        Me.BTN_SaveLoginSettings.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!)
        Me.BTN_SaveLoginSettings.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.BTN_SaveLoginSettings.Location = New System.Drawing.Point(6, 146)
        Me.BTN_SaveLoginSettings.Name = "BTN_SaveLoginSettings"
        Me.BTN_SaveLoginSettings.Size = New System.Drawing.Size(365, 38)
        Me.BTN_SaveLoginSettings.TabIndex = 38
        Me.BTN_SaveLoginSettings.Text = "Änderung Speichern"
        Me.BTN_SaveLoginSettings.UseVisualStyleBackColor = False
        '
        'cb_CheckOldPass
        '
        Me.cb_CheckOldPass.AutoSize = True
        Me.cb_CheckOldPass.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_CheckOldPass.Location = New System.Drawing.Point(9, 111)
        Me.cb_CheckOldPass.Name = "cb_CheckOldPass"
        Me.cb_CheckOldPass.Size = New System.Drawing.Size(342, 20)
        Me.cb_CheckOldPass.TabIndex = 8
        Me.cb_CheckOldPass.Text = "Daran erinnern Passwörter zu ändern nach 6 Monaten"
        Me.cb_CheckOldPass.UseVisualStyleBackColor = True
        '
        'CB_NFCVerify
        '
        Me.CB_NFCVerify.AutoSize = True
        Me.CB_NFCVerify.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CB_NFCVerify.Location = New System.Drawing.Point(9, 65)
        Me.CB_NFCVerify.Name = "CB_NFCVerify"
        Me.CB_NFCVerify.Size = New System.Drawing.Size(185, 20)
        Me.CB_NFCVerify.TabIndex = 7
        Me.CB_NFCVerify.Text = "NFC Anmeldung aktivieren"
        Me.CB_NFCVerify.UseVisualStyleBackColor = True
        '
        'CB_SmartphoneSignIn
        '
        Me.CB_SmartphoneSignIn.AutoSize = True
        Me.CB_SmartphoneSignIn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CB_SmartphoneSignIn.Location = New System.Drawing.Point(9, 42)
        Me.CB_SmartphoneSignIn.Name = "CB_SmartphoneSignIn"
        Me.CB_SmartphoneSignIn.Size = New System.Drawing.Size(190, 20)
        Me.CB_SmartphoneSignIn.TabIndex = 6
        Me.CB_SmartphoneSignIn.Text = "Anmeldung mit Smartphone"
        Me.CB_SmartphoneSignIn.UseVisualStyleBackColor = True
        '
        'TT_Informations
        '
        Me.TT_Informations.IsBalloon = True
        '
        'GB_Permission
        '
        Me.GB_Permission.Controls.Add(Me.BTN_SaveEditRole)
        Me.GB_Permission.Controls.Add(Me.GB_AddPermissionRole)
        Me.GB_Permission.Controls.Add(Me.CB_Print)
        Me.GB_Permission.Controls.Add(Me.CB_CreateNewCar)
        Me.GB_Permission.Controls.Add(Me.CB_DeleteData)
        Me.GB_Permission.Controls.Add(Me.CB_OpenData)
        Me.GB_Permission.Controls.Add(Me.CB_UploadData)
        Me.GB_Permission.Controls.Add(Me.CB_AdminPermission)
        Me.GB_Permission.Controls.Add(Me.CB_DeleteEntries)
        Me.GB_Permission.Controls.Add(Me.CB_DeleteUser)
        Me.GB_Permission.Controls.Add(Me.CB_EditUser)
        Me.GB_Permission.Controls.Add(Me.CB_CreateUser)
        Me.GB_Permission.Controls.Add(Me.CB_EditEntries)
        Me.GB_Permission.Controls.Add(Me.CB_CreateEntries)
        Me.GB_Permission.Controls.Add(Me.FlowLayoutPanel1)
        Me.GB_Permission.Location = New System.Drawing.Point(411, 12)
        Me.GB_Permission.Name = "GB_Permission"
        Me.GB_Permission.Size = New System.Drawing.Size(542, 468)
        Me.GB_Permission.TabIndex = 38
        Me.GB_Permission.TabStop = False
        Me.GB_Permission.Text = "Berechtigungsstufen bearbeiten"
        '
        'BTN_SaveEditRole
        '
        Me.BTN_SaveEditRole.BackColor = System.Drawing.Color.LightGray
        Me.BTN_SaveEditRole.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!)
        Me.BTN_SaveEditRole.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.BTN_SaveEditRole.Location = New System.Drawing.Point(6, 418)
        Me.BTN_SaveEditRole.Name = "BTN_SaveEditRole"
        Me.BTN_SaveEditRole.Size = New System.Drawing.Size(504, 38)
        Me.BTN_SaveEditRole.TabIndex = 37
        Me.BTN_SaveEditRole.Text = "Änderung Speichern"
        Me.BTN_SaveEditRole.UseVisualStyleBackColor = False
        '
        'GB_AddPermissionRole
        '
        Me.GB_AddPermissionRole.Controls.Add(Me.BTN_SavePermissionRole)
        Me.GB_AddPermissionRole.Controls.Add(Me.Label1)
        Me.GB_AddPermissionRole.Controls.Add(Me.TXB_NamePermissionRole)
        Me.GB_AddPermissionRole.Location = New System.Drawing.Point(248, 19)
        Me.GB_AddPermissionRole.Name = "GB_AddPermissionRole"
        Me.GB_AddPermissionRole.Size = New System.Drawing.Size(245, 115)
        Me.GB_AddPermissionRole.TabIndex = 26
        Me.GB_AddPermissionRole.TabStop = False
        Me.GB_AddPermissionRole.Text = "Neue Berechtigungsstufe hinzufügen"
        '
        'BTN_SavePermissionRole
        '
        Me.BTN_SavePermissionRole.BackColor = System.Drawing.Color.LightGray
        Me.BTN_SavePermissionRole.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_SavePermissionRole.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.BTN_SavePermissionRole.Location = New System.Drawing.Point(10, 68)
        Me.BTN_SavePermissionRole.Name = "BTN_SavePermissionRole"
        Me.BTN_SavePermissionRole.Size = New System.Drawing.Size(217, 29)
        Me.BTN_SavePermissionRole.TabIndex = 37
        Me.BTN_SavePermissionRole.Text = "Berechtigungsstufe anlegen"
        Me.BTN_SavePermissionRole.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(147, 13)
        Me.Label1.TabIndex = 27
        Me.Label1.Text = "Name der Berechtigungsstufe"
        '
        'TXB_NamePermissionRole
        '
        Me.TXB_NamePermissionRole.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXB_NamePermissionRole.Location = New System.Drawing.Point(10, 40)
        Me.TXB_NamePermissionRole.Name = "TXB_NamePermissionRole"
        Me.TXB_NamePermissionRole.Size = New System.Drawing.Size(217, 22)
        Me.TXB_NamePermissionRole.TabIndex = 26
        '
        'CB_Print
        '
        Me.CB_Print.AutoSize = True
        Me.CB_Print.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CB_Print.Location = New System.Drawing.Point(248, 369)
        Me.CB_Print.Name = "CB_Print"
        Me.CB_Print.Size = New System.Drawing.Size(127, 20)
        Me.CB_Print.TabIndex = 25
        Me.CB_Print.Text = "Einträge drucken"
        Me.CB_Print.UseVisualStyleBackColor = True
        '
        'CB_CreateNewCar
        '
        Me.CB_CreateNewCar.AutoSize = True
        Me.CB_CreateNewCar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CB_CreateNewCar.Location = New System.Drawing.Point(248, 346)
        Me.CB_CreateNewCar.Name = "CB_CreateNewCar"
        Me.CB_CreateNewCar.Size = New System.Drawing.Size(221, 20)
        Me.CB_CreateNewCar.TabIndex = 24
        Me.CB_CreateNewCar.Text = "Neues Auto und Kunden anlegen"
        Me.CB_CreateNewCar.UseVisualStyleBackColor = True
        '
        'CB_DeleteData
        '
        Me.CB_DeleteData.AutoSize = True
        Me.CB_DeleteData.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CB_DeleteData.Location = New System.Drawing.Point(248, 323)
        Me.CB_DeleteData.Name = "CB_DeleteData"
        Me.CB_DeleteData.Size = New System.Drawing.Size(115, 20)
        Me.CB_DeleteData.TabIndex = 23
        Me.CB_DeleteData.Text = "Datein löschen"
        Me.CB_DeleteData.UseVisualStyleBackColor = True
        '
        'CB_OpenData
        '
        Me.CB_OpenData.AutoSize = True
        Me.CB_OpenData.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CB_OpenData.Location = New System.Drawing.Point(248, 300)
        Me.CB_OpenData.Name = "CB_OpenData"
        Me.CB_OpenData.Size = New System.Drawing.Size(104, 20)
        Me.CB_OpenData.TabIndex = 22
        Me.CB_OpenData.Text = "Datein öffnen"
        Me.CB_OpenData.UseVisualStyleBackColor = True
        '
        'CB_UploadData
        '
        Me.CB_UploadData.AutoSize = True
        Me.CB_UploadData.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CB_UploadData.Location = New System.Drawing.Point(248, 276)
        Me.CB_UploadData.Name = "CB_UploadData"
        Me.CB_UploadData.Size = New System.Drawing.Size(131, 20)
        Me.CB_UploadData.TabIndex = 21
        Me.CB_UploadData.Text = "Datein hochladen"
        Me.CB_UploadData.UseVisualStyleBackColor = True
        '
        'CB_AdminPermission
        '
        Me.CB_AdminPermission.AutoSize = True
        Me.CB_AdminPermission.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CB_AdminPermission.Location = New System.Drawing.Point(248, 392)
        Me.CB_AdminPermission.Name = "CB_AdminPermission"
        Me.CB_AdminPermission.Size = New System.Drawing.Size(266, 20)
        Me.CB_AdminPermission.TabIndex = 20
        Me.CB_AdminPermission.Text = "Einstellungen der Anwendung verändern"
        Me.CB_AdminPermission.UseVisualStyleBackColor = True
        '
        'CB_DeleteEntries
        '
        Me.CB_DeleteEntries.AutoSize = True
        Me.CB_DeleteEntries.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CB_DeleteEntries.Location = New System.Drawing.Point(248, 254)
        Me.CB_DeleteEntries.Name = "CB_DeleteEntries"
        Me.CB_DeleteEntries.Size = New System.Drawing.Size(126, 20)
        Me.CB_DeleteEntries.TabIndex = 19
        Me.CB_DeleteEntries.Text = "Einträge löschen"
        Me.CB_DeleteEntries.UseVisualStyleBackColor = True
        '
        'CB_DeleteUser
        '
        Me.CB_DeleteUser.AutoSize = True
        Me.CB_DeleteUser.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CB_DeleteUser.Location = New System.Drawing.Point(248, 186)
        Me.CB_DeleteUser.Name = "CB_DeleteUser"
        Me.CB_DeleteUser.Size = New System.Drawing.Size(128, 20)
        Me.CB_DeleteUser.TabIndex = 16
        Me.CB_DeleteUser.Text = "Benutzer löschen"
        Me.CB_DeleteUser.UseVisualStyleBackColor = True
        '
        'CB_EditUser
        '
        Me.CB_EditUser.AutoSize = True
        Me.CB_EditUser.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CB_EditUser.Location = New System.Drawing.Point(248, 163)
        Me.CB_EditUser.Name = "CB_EditUser"
        Me.CB_EditUser.Size = New System.Drawing.Size(146, 20)
        Me.CB_EditUser.TabIndex = 15
        Me.CB_EditUser.Text = "Benutzer bearbeiten"
        Me.CB_EditUser.UseVisualStyleBackColor = True
        '
        'CB_CreateUser
        '
        Me.CB_CreateUser.AutoSize = True
        Me.CB_CreateUser.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CB_CreateUser.Location = New System.Drawing.Point(248, 140)
        Me.CB_CreateUser.Name = "CB_CreateUser"
        Me.CB_CreateUser.Size = New System.Drawing.Size(130, 20)
        Me.CB_CreateUser.TabIndex = 14
        Me.CB_CreateUser.Text = "Benutzer anlegen"
        Me.CB_CreateUser.UseVisualStyleBackColor = True
        '
        'CB_EditEntries
        '
        Me.CB_EditEntries.AutoSize = True
        Me.CB_EditEntries.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CB_EditEntries.Location = New System.Drawing.Point(248, 233)
        Me.CB_EditEntries.Name = "CB_EditEntries"
        Me.CB_EditEntries.Size = New System.Drawing.Size(291, 20)
        Me.CB_EditEntries.TabIndex = 18
        Me.CB_EditEntries.Text = "Einträge bearbeiten / Checklisten bearbeiten"
        Me.CB_EditEntries.UseVisualStyleBackColor = True
        '
        'CB_CreateEntries
        '
        Me.CB_CreateEntries.AutoSize = True
        Me.CB_CreateEntries.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CB_CreateEntries.Location = New System.Drawing.Point(248, 209)
        Me.CB_CreateEntries.Name = "CB_CreateEntries"
        Me.CB_CreateEntries.Size = New System.Drawing.Size(263, 20)
        Me.CB_CreateEntries.TabIndex = 17
        Me.CB_CreateEntries.Text = "Einträge erstellen / Checklisten erstellen"
        Me.CB_CreateEntries.UseVisualStyleBackColor = True
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.BackColor = System.Drawing.Color.White
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(6, 19)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(225, 393)
        Me.FlowLayoutPanel1.TabIndex = 0
        '
        'AdminSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(965, 490)
        Me.Controls.Add(Me.GB_Permission)
        Me.Controls.Add(Me.GroupBox3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "AdminSettings"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Administrative Einstellungen"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GB_Permission.ResumeLayout(False)
        Me.GB_Permission.PerformLayout()
        Me.GB_AddPermissionRole.ResumeLayout(False)
        Me.GB_AddPermissionRole.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents CB_SignActive As CheckBox
    Friend WithEvents CB_RememberLogin As CheckBox
    Friend WithEvents BTN_OpenSmartphoneVerification As Button
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents CB_SmartphoneSignIn As CheckBox
    Friend WithEvents CB_NFCVerify As CheckBox
    Friend WithEvents cb_CheckOldPass As CheckBox
    Friend WithEvents TT_Informations As ToolTip
    Friend WithEvents GB_Permission As GroupBox
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents CB_Print As CheckBox
    Friend WithEvents CB_CreateNewCar As CheckBox
    Friend WithEvents CB_DeleteData As CheckBox
    Friend WithEvents CB_OpenData As CheckBox
    Friend WithEvents CB_UploadData As CheckBox
    Friend WithEvents CB_AdminPermission As CheckBox
    Friend WithEvents CB_DeleteEntries As CheckBox
    Friend WithEvents CB_DeleteUser As CheckBox
    Friend WithEvents CB_EditUser As CheckBox
    Friend WithEvents CB_CreateUser As CheckBox
    Friend WithEvents CB_EditEntries As CheckBox
    Friend WithEvents CB_CreateEntries As CheckBox
    Friend WithEvents GB_AddPermissionRole As GroupBox
    Friend WithEvents BTN_SavePermissionRole As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents TXB_NamePermissionRole As TextBox
    Friend WithEvents BTN_SaveEditRole As Button
    Friend WithEvents BTN_SaveLoginSettings As Button
End Class
