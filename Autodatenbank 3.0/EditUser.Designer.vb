﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditUser
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EditUser))
        Me.GB_NFC = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TXB_UID = New System.Windows.Forms.TextBox()
        Me.CB_NFC = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CBB_Username = New System.Windows.Forms.ComboBox()
        Me.BTN_Save = New System.Windows.Forms.Button()
        Me.cbb_PermissionRole = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TXB_Email = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.BTN_SendOTP = New System.Windows.Forms.Button()
        Me.GB_NFC.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GB_NFC
        '
        Me.GB_NFC.Controls.Add(Me.Label2)
        Me.GB_NFC.Controls.Add(Me.TXB_UID)
        Me.GB_NFC.Controls.Add(Me.CB_NFC)
        Me.GB_NFC.Location = New System.Drawing.Point(34, 200)
        Me.GB_NFC.Name = "GB_NFC"
        Me.GB_NFC.Size = New System.Drawing.Size(473, 115)
        Me.GB_NFC.TabIndex = 12
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
        Me.TXB_UID.Size = New System.Drawing.Size(458, 26)
        Me.TXB_UID.TabIndex = 3
        '
        'CB_NFC
        '
        Me.CB_NFC.AutoSize = True
        Me.CB_NFC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CB_NFC.Location = New System.Drawing.Point(9, 19)
        Me.CB_NFC.Name = "CB_NFC"
        Me.CB_NFC.Size = New System.Drawing.Size(182, 20)
        Me.CB_NFC.TabIndex = 0
        Me.CB_NFC.Text = "NFC Transpoder anlernen"
        Me.CB_NFC.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(31, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 16)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Benutzername"
        '
        'CBB_Username
        '
        Me.CBB_Username.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBB_Username.FormattingEnabled = True
        Me.CBB_Username.Location = New System.Drawing.Point(34, 50)
        Me.CBB_Username.Name = "CBB_Username"
        Me.CBB_Username.Size = New System.Drawing.Size(473, 28)
        Me.CBB_Username.TabIndex = 19
        '
        'BTN_Save
        '
        Me.BTN_Save.BackColor = System.Drawing.Color.LightGray
        Me.BTN_Save.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!)
        Me.BTN_Save.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.BTN_Save.Location = New System.Drawing.Point(43, 428)
        Me.BTN_Save.Name = "BTN_Save"
        Me.BTN_Save.Size = New System.Drawing.Size(458, 75)
        Me.BTN_Save.TabIndex = 35
        Me.BTN_Save.Text = "Änderung speichern"
        Me.BTN_Save.UseVisualStyleBackColor = False
        '
        'cbb_PermissionRole
        '
        Me.cbb_PermissionRole.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbb_PermissionRole.FormattingEnabled = True
        Me.cbb_PermissionRole.Location = New System.Drawing.Point(34, 161)
        Me.cbb_PermissionRole.Name = "cbb_PermissionRole"
        Me.cbb_PermissionRole.Size = New System.Drawing.Size(473, 28)
        Me.cbb_PermissionRole.TabIndex = 36
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(31, 142)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(121, 16)
        Me.Label5.TabIndex = 37
        Me.Label5.Text = "Berechtigungsstufe"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(31, 86)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 16)
        Me.Label3.TabIndex = 38
        Me.Label3.Text = "Email"
        '
        'TXB_Email
        '
        Me.TXB_Email.Enabled = False
        Me.TXB_Email.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXB_Email.Location = New System.Drawing.Point(34, 105)
        Me.TXB_Email.Name = "TXB_Email"
        Me.TXB_Email.Size = New System.Drawing.Size(473, 26)
        Me.TXB_Email.TabIndex = 4
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.BTN_SendOTP)
        Me.GroupBox1.Location = New System.Drawing.Point(34, 322)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(473, 100)
        Me.GroupBox1.TabIndex = 39
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "OneTimePasswort"
        '
        'BTN_SendOTP
        '
        Me.BTN_SendOTP.BackColor = System.Drawing.Color.LightGray
        Me.BTN_SendOTP.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!)
        Me.BTN_SendOTP.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.BTN_SendOTP.Location = New System.Drawing.Point(6, 19)
        Me.BTN_SendOTP.Name = "BTN_SendOTP"
        Me.BTN_SendOTP.Size = New System.Drawing.Size(461, 75)
        Me.BTN_SendOTP.TabIndex = 40
        Me.BTN_SendOTP.Text = "OneTimePasswort erstellen "
        Me.BTN_SendOTP.UseVisualStyleBackColor = False
        '
        'EditUser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(523, 523)
        Me.Controls.Add(Me.BTN_Save)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.TXB_Email)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cbb_PermissionRole)
        Me.Controls.Add(Me.CBB_Username)
        Me.Controls.Add(Me.GB_NFC)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "EditUser"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Benutzer ändern"
        Me.GB_NFC.ResumeLayout(False)
        Me.GB_NFC.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GB_NFC As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TXB_UID As TextBox
    Friend WithEvents CB_NFC As CheckBox
    Friend WithEvents Label1 As Label
    Friend WithEvents CBB_Username As ComboBox
    Friend WithEvents BTN_Save As Button
    Friend WithEvents cbb_PermissionRole As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents TXB_Email As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents BTN_SendOTP As Button
End Class
