<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NewPassword
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NewPassword))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TXB_Password = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TXB_PasswordRepeat = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LL_ShowPassword = New System.Windows.Forms.LinkLabel()
        Me.BTN_Login = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(490, 80)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Herzlich Willkommen," & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Sie haben sich erfolgreich mit Ihrem OneTimePassword ange" &
    "meldet." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Bitte legen Sie jetzt Ihr neues Individuelles Passwort an."
        '
        'TXB_Password
        '
        Me.TXB_Password.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXB_Password.Location = New System.Drawing.Point(16, 155)
        Me.TXB_Password.Name = "TXB_Password"
        Me.TXB_Password.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TXB_Password.Size = New System.Drawing.Size(486, 26)
        Me.TXB_Password.TabIndex = 10
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(13, 136)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 16)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Passwort"
        '
        'TXB_PasswordRepeat
        '
        Me.TXB_PasswordRepeat.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXB_PasswordRepeat.Location = New System.Drawing.Point(16, 212)
        Me.TXB_PasswordRepeat.Name = "TXB_PasswordRepeat"
        Me.TXB_PasswordRepeat.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TXB_PasswordRepeat.Size = New System.Drawing.Size(486, 26)
        Me.TXB_PasswordRepeat.TabIndex = 12
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(13, 193)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(138, 16)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Passwort wiederholen"
        '
        'LL_ShowPassword
        '
        Me.LL_ShowPassword.AutoSize = True
        Me.LL_ShowPassword.Location = New System.Drawing.Point(451, 136)
        Me.LL_ShowPassword.Name = "LL_ShowPassword"
        Me.LL_ShowPassword.Size = New System.Drawing.Size(51, 13)
        Me.LL_ShowPassword.TabIndex = 13
        Me.LL_ShowPassword.TabStop = True
        Me.LL_ShowPassword.Text = "Anzeigen"
        '
        'BTN_Login
        '
        Me.BTN_Login.BackColor = System.Drawing.Color.LightGray
        Me.BTN_Login.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!)
        Me.BTN_Login.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.BTN_Login.Location = New System.Drawing.Point(16, 244)
        Me.BTN_Login.Name = "BTN_Login"
        Me.BTN_Login.Size = New System.Drawing.Size(486, 64)
        Me.BTN_Login.TabIndex = 36
        Me.BTN_Login.Text = "Anmelden"
        Me.BTN_Login.UseVisualStyleBackColor = False
        '
        'NewPassword
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(519, 320)
        Me.Controls.Add(Me.BTN_Login)
        Me.Controls.Add(Me.LL_ShowPassword)
        Me.Controls.Add(Me.TXB_PasswordRepeat)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TXB_Password)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "NewPassword"
        Me.Text = "Neues Passwort festlegen"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents TXB_Password As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TXB_PasswordRepeat As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents LL_ShowPassword As LinkLabel
    Friend WithEvents BTN_Login As Button
End Class
