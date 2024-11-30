<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Authent
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Authent))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LBL_NFC = New System.Windows.Forms.Label()
        Me.TMR_CheckAuthent = New System.Windows.Forms.Timer(Me.components)
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.TXB_Password = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TXB_UserName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BTN_Login = New System.Windows.Forms.Button()
        Me.LL_LastUser = New System.Windows.Forms.LinkLabel()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(5, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(245, 39)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Bitte einloggen"
        '
        'LBL_NFC
        '
        Me.LBL_NFC.AutoSize = True
        Me.LBL_NFC.Location = New System.Drawing.Point(433, 391)
        Me.LBL_NFC.Name = "LBL_NFC"
        Me.LBL_NFC.Size = New System.Drawing.Size(135, 13)
        Me.LBL_NFC.TabIndex = 1
        Me.LBL_NFC.Text = "NFC Transponder auflegen"
        '
        'TMR_CheckAuthent
        '
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(12, 154)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(250, 225)
        Me.PictureBox1.TabIndex = 4
        Me.PictureBox1.TabStop = False
        '
        'TXB_Password
        '
        Me.TXB_Password.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXB_Password.Location = New System.Drawing.Point(12, 122)
        Me.TXB_Password.Name = "TXB_Password"
        Me.TXB_Password.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TXB_Password.Size = New System.Drawing.Size(250, 26)
        Me.TXB_Password.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(9, 103)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 16)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Passwort"
        '
        'TXB_UserName
        '
        Me.TXB_UserName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXB_UserName.Location = New System.Drawing.Point(12, 75)
        Me.TXB_UserName.Name = "TXB_UserName"
        Me.TXB_UserName.Size = New System.Drawing.Size(250, 26)
        Me.TXB_UserName.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(9, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 16)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Benutzername"
        '
        'BTN_Login
        '
        Me.BTN_Login.BackColor = System.Drawing.Color.LightGray
        Me.BTN_Login.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!)
        Me.BTN_Login.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.BTN_Login.Location = New System.Drawing.Point(12, 385)
        Me.BTN_Login.Name = "BTN_Login"
        Me.BTN_Login.Size = New System.Drawing.Size(250, 86)
        Me.BTN_Login.TabIndex = 35
        Me.BTN_Login.Text = "Anmelden"
        Me.BTN_Login.UseVisualStyleBackColor = False
        '
        'LL_LastUser
        '
        Me.LL_LastUser.AutoSize = True
        Me.LL_LastUser.Location = New System.Drawing.Point(154, 58)
        Me.LL_LastUser.Name = "LL_LastUser"
        Me.LL_LastUser.Size = New System.Drawing.Size(41, 13)
        Me.LL_LastUser.TabIndex = 36
        Me.LL_LastUser.TabStop = True
        Me.LL_LastUser.Text = "Nicht ?"
        Me.LL_LastUser.Visible = False
        '
        'Authent
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(275, 479)
        Me.Controls.Add(Me.LL_LastUser)
        Me.Controls.Add(Me.BTN_Login)
        Me.Controls.Add(Me.TXB_Password)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TXB_UserName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.LBL_NFC)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Authent"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Login"
        Me.TopMost = True
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents LBL_NFC As Label
    Friend WithEvents TMR_CheckAuthent As Timer
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents TXB_Password As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TXB_UserName As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents BTN_Login As Button
    Friend WithEvents LL_LastUser As LinkLabel
End Class
