<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FirstRun
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FirstRun))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PNL_1 = New System.Windows.Forms.Panel()
        Me.BTN_GetStarted = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LBL_MySqlConnection = New System.Windows.Forms.Label()
        Me.LBL_FTPConnection = New System.Windows.Forms.Label()
        Me.PNL_2 = New System.Windows.Forms.Panel()
        Me.BTN_ImportSettings = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.PNL_FTP = New System.Windows.Forms.Panel()
        Me.TXB_FTPServerUri = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.BTN_TryFTPConnection = New System.Windows.Forms.Button()
        Me.TXB_FTPUsername = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TXB_FTPPassword = New System.Windows.Forms.TextBox()
        Me.CB_SFTP = New System.Windows.Forms.CheckBox()
        Me.PNL_SFTP = New System.Windows.Forms.Panel()
        Me.BTN_LoadOpenSSHKey = New System.Windows.Forms.Button()
        Me.CB_KeyFileLoaded = New System.Windows.Forms.CheckBox()
        Me.TXB_SFTPServerUri = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.BTN_TrySFTPConnection = New System.Windows.Forms.Button()
        Me.TXB_SFTPUsername = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.BTN_TryMqSqlConnectin = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TXB_MySqlPassword = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TXB_MySqlDatabase = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TXB_MySqlUsername = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TXB_MySqlServer = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.BTN_CheckLicense = New System.Windows.Forms.Button()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.TXB_Regkey = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TXB_LicenseEmail = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TXB_LicenseName = New System.Windows.Forms.TextBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.BTN_SaveData = New System.Windows.Forms.Button()
        Me.FBD_SaveConfigFile = New System.Windows.Forms.FolderBrowserDialog()
        Me.NI_Successful = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.NI_Error = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.TT_Licensedata = New System.Windows.Forms.ToolTip(Me.components)
        Me.PB_QRFTP = New System.Windows.Forms.PictureBox()
        Me.PNL_1.SuspendLayout()
        Me.PNL_2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.PNL_FTP.SuspendLayout()
        Me.PNL_SFTP.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PB_QRFTP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(81, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(405, 25)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Herzlich Willkommen zur Autodatenbank "
        '
        'PNL_1
        '
        Me.PNL_1.Controls.Add(Me.BTN_GetStarted)
        Me.PNL_1.Controls.Add(Me.Label5)
        Me.PNL_1.Location = New System.Drawing.Point(642, 100)
        Me.PNL_1.Name = "PNL_1"
        Me.PNL_1.Size = New System.Drawing.Size(624, 547)
        Me.PNL_1.TabIndex = 1
        '
        'BTN_GetStarted
        '
        Me.BTN_GetStarted.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTN_GetStarted.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_GetStarted.Location = New System.Drawing.Point(57, 173)
        Me.BTN_GetStarted.Name = "BTN_GetStarted"
        Me.BTN_GetStarted.Size = New System.Drawing.Size(512, 120)
        Me.BTN_GetStarted.TabIndex = 1
        Me.BTN_GetStarted.Text = "Los gehts"
        Me.BTN_GetStarted.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(16, 23)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(504, 120)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Beim ersten Start müssen einige Einstellungen vorgenommen werden," & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "damit die Auto" &
    "datenbank reibungslos funktioniert." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "-Name und Email " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "-MySqlServer Verbindung" &
    "sdaten" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "-FTP-Server Verbindungsdaten"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(26, 851)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(138, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "MYSQL-Server Verbindung:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(26, 875)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(121, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "FTP-Server Verbindung:"
        '
        'LBL_MySqlConnection
        '
        Me.LBL_MySqlConnection.AutoSize = True
        Me.LBL_MySqlConnection.Location = New System.Drawing.Point(184, 851)
        Me.LBL_MySqlConnection.Name = "LBL_MySqlConnection"
        Me.LBL_MySqlConnection.Size = New System.Drawing.Size(115, 13)
        Me.LBL_MySqlConnection.TabIndex = 4
        Me.LBL_MySqlConnection.Text = "LBL_MySqlConnection"
        '
        'LBL_FTPConnection
        '
        Me.LBL_FTPConnection.AutoSize = True
        Me.LBL_FTPConnection.Location = New System.Drawing.Point(184, 875)
        Me.LBL_FTPConnection.Name = "LBL_FTPConnection"
        Me.LBL_FTPConnection.Size = New System.Drawing.Size(106, 13)
        Me.LBL_FTPConnection.TabIndex = 5
        Me.LBL_FTPConnection.Text = "LBL_FTPConnection"
        '
        'PNL_2
        '
        Me.PNL_2.Controls.Add(Me.BTN_ImportSettings)
        Me.PNL_2.Controls.Add(Me.GroupBox3)
        Me.PNL_2.Controls.Add(Me.GroupBox2)
        Me.PNL_2.Controls.Add(Me.GroupBox1)
        Me.PNL_2.Location = New System.Drawing.Point(12, 48)
        Me.PNL_2.Name = "PNL_2"
        Me.PNL_2.Size = New System.Drawing.Size(624, 782)
        Me.PNL_2.TabIndex = 2
        '
        'BTN_ImportSettings
        '
        Me.BTN_ImportSettings.Location = New System.Drawing.Point(431, 756)
        Me.BTN_ImportSettings.Name = "BTN_ImportSettings"
        Me.BTN_ImportSettings.Size = New System.Drawing.Size(168, 23)
        Me.BTN_ImportSettings.TabIndex = 10
        Me.BTN_ImportSettings.Text = "Verbindungsdaten Importieren"
        Me.BTN_ImportSettings.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.PNL_FTP)
        Me.GroupBox3.Controls.Add(Me.CB_SFTP)
        Me.GroupBox3.Controls.Add(Me.PNL_SFTP)
        Me.GroupBox3.Enabled = False
        Me.GroupBox3.Location = New System.Drawing.Point(17, 472)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(582, 282)
        Me.GroupBox3.TabIndex = 9
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "FTP Verbingunsdaten"
        '
        'PNL_FTP
        '
        Me.PNL_FTP.Controls.Add(Me.TXB_FTPServerUri)
        Me.PNL_FTP.Controls.Add(Me.PB_QRFTP)
        Me.PNL_FTP.Controls.Add(Me.Label14)
        Me.PNL_FTP.Controls.Add(Me.BTN_TryFTPConnection)
        Me.PNL_FTP.Controls.Add(Me.TXB_FTPUsername)
        Me.PNL_FTP.Controls.Add(Me.Label11)
        Me.PNL_FTP.Controls.Add(Me.Label13)
        Me.PNL_FTP.Controls.Add(Me.TXB_FTPPassword)
        Me.PNL_FTP.Location = New System.Drawing.Point(6, 32)
        Me.PNL_FTP.Name = "PNL_FTP"
        Me.PNL_FTP.Size = New System.Drawing.Size(570, 180)
        Me.PNL_FTP.TabIndex = 13
        '
        'TXB_FTPServerUri
        '
        Me.TXB_FTPServerUri.Location = New System.Drawing.Point(15, 54)
        Me.TXB_FTPServerUri.Name = "TXB_FTPServerUri"
        Me.TXB_FTPServerUri.Size = New System.Drawing.Size(364, 20)
        Me.TXB_FTPServerUri.TabIndex = 7
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(12, 33)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(75, 13)
        Me.Label14.TabIndex = 1
        Me.Label14.Text = "Serveradresse"
        '
        'BTN_TryFTPConnection
        '
        Me.BTN_TryFTPConnection.Location = New System.Drawing.Point(408, 151)
        Me.BTN_TryFTPConnection.Name = "BTN_TryFTPConnection"
        Me.BTN_TryFTPConnection.Size = New System.Drawing.Size(143, 23)
        Me.BTN_TryFTPConnection.TabIndex = 8
        Me.BTN_TryFTPConnection.Text = "Verbindung Testen"
        Me.BTN_TryFTPConnection.UseVisualStyleBackColor = True
        '
        'TXB_FTPUsername
        '
        Me.TXB_FTPUsername.Location = New System.Drawing.Point(15, 103)
        Me.TXB_FTPUsername.Name = "TXB_FTPUsername"
        Me.TXB_FTPUsername.Size = New System.Drawing.Size(364, 20)
        Me.TXB_FTPUsername.TabIndex = 8
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(12, 132)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(50, 13)
        Me.Label11.TabIndex = 7
        Me.Label11.Text = "Passwort"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(12, 82)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(75, 13)
        Me.Label13.TabIndex = 3
        Me.Label13.Text = "Benutzername"
        '
        'TXB_FTPPassword
        '
        Me.TXB_FTPPassword.Location = New System.Drawing.Point(15, 153)
        Me.TXB_FTPPassword.Name = "TXB_FTPPassword"
        Me.TXB_FTPPassword.Size = New System.Drawing.Size(364, 20)
        Me.TXB_FTPPassword.TabIndex = 9
        '
        'CB_SFTP
        '
        Me.CB_SFTP.AutoSize = True
        Me.CB_SFTP.Location = New System.Drawing.Point(523, 9)
        Me.CB_SFTP.Name = "CB_SFTP"
        Me.CB_SFTP.Size = New System.Drawing.Size(53, 17)
        Me.CB_SFTP.TabIndex = 12
        Me.CB_SFTP.Text = "SFTP"
        Me.CB_SFTP.UseVisualStyleBackColor = True
        '
        'PNL_SFTP
        '
        Me.PNL_SFTP.Controls.Add(Me.BTN_LoadOpenSSHKey)
        Me.PNL_SFTP.Controls.Add(Me.CB_KeyFileLoaded)
        Me.PNL_SFTP.Controls.Add(Me.TXB_SFTPServerUri)
        Me.PNL_SFTP.Controls.Add(Me.Label12)
        Me.PNL_SFTP.Controls.Add(Me.BTN_TrySFTPConnection)
        Me.PNL_SFTP.Controls.Add(Me.TXB_SFTPUsername)
        Me.PNL_SFTP.Controls.Add(Me.Label15)
        Me.PNL_SFTP.Location = New System.Drawing.Point(6, 32)
        Me.PNL_SFTP.Name = "PNL_SFTP"
        Me.PNL_SFTP.Size = New System.Drawing.Size(570, 186)
        Me.PNL_SFTP.TabIndex = 14
        Me.PNL_SFTP.Visible = False
        '
        'BTN_LoadOpenSSHKey
        '
        Me.BTN_LoadOpenSSHKey.Location = New System.Drawing.Point(408, 31)
        Me.BTN_LoadOpenSSHKey.Name = "BTN_LoadOpenSSHKey"
        Me.BTN_LoadOpenSSHKey.Size = New System.Drawing.Size(143, 23)
        Me.BTN_LoadOpenSSHKey.TabIndex = 10
        Me.BTN_LoadOpenSSHKey.Text = "OpenSSH-Key laden"
        Me.BTN_LoadOpenSSHKey.UseVisualStyleBackColor = True
        '
        'CB_KeyFileLoaded
        '
        Me.CB_KeyFileLoaded.AutoSize = True
        Me.CB_KeyFileLoaded.Enabled = False
        Me.CB_KeyFileLoaded.Location = New System.Drawing.Point(14, 122)
        Me.CB_KeyFileLoaded.Name = "CB_KeyFileLoaded"
        Me.CB_KeyFileLoaded.Size = New System.Drawing.Size(136, 17)
        Me.CB_KeyFileLoaded.TabIndex = 9
        Me.CB_KeyFileLoaded.Text = "OpenSSH-Key geladen"
        Me.CB_KeyFileLoaded.UseVisualStyleBackColor = True
        '
        'TXB_SFTPServerUri
        '
        Me.TXB_SFTPServerUri.Location = New System.Drawing.Point(14, 33)
        Me.TXB_SFTPServerUri.Name = "TXB_SFTPServerUri"
        Me.TXB_SFTPServerUri.Size = New System.Drawing.Size(364, 20)
        Me.TXB_SFTPServerUri.TabIndex = 7
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(11, 12)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(75, 13)
        Me.Label12.TabIndex = 1
        Me.Label12.Text = "Serveradresse"
        '
        'BTN_TrySFTPConnection
        '
        Me.BTN_TrySFTPConnection.Location = New System.Drawing.Point(408, 151)
        Me.BTN_TrySFTPConnection.Name = "BTN_TrySFTPConnection"
        Me.BTN_TrySFTPConnection.Size = New System.Drawing.Size(143, 23)
        Me.BTN_TrySFTPConnection.TabIndex = 8
        Me.BTN_TrySFTPConnection.Text = "Verbindung Testen"
        Me.BTN_TrySFTPConnection.UseVisualStyleBackColor = True
        '
        'TXB_SFTPUsername
        '
        Me.TXB_SFTPUsername.Location = New System.Drawing.Point(14, 81)
        Me.TXB_SFTPUsername.Name = "TXB_SFTPUsername"
        Me.TXB_SFTPUsername.Size = New System.Drawing.Size(364, 20)
        Me.TXB_SFTPUsername.TabIndex = 8
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(11, 60)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(75, 13)
        Me.Label15.TabIndex = 3
        Me.Label15.Text = "Benutzername"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.BTN_TryMqSqlConnectin)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.TXB_MySqlPassword)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.TXB_MySqlDatabase)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.TXB_MySqlUsername)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.TXB_MySqlServer)
        Me.GroupBox2.Enabled = False
        Me.GroupBox2.Location = New System.Drawing.Point(17, 225)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(582, 232)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "MySql Verbingunsdaten"
        '
        'BTN_TryMqSqlConnectin
        '
        Me.BTN_TryMqSqlConnectin.Location = New System.Drawing.Point(414, 197)
        Me.BTN_TryMqSqlConnectin.Name = "BTN_TryMqSqlConnectin"
        Me.BTN_TryMqSqlConnectin.Size = New System.Drawing.Size(143, 23)
        Me.BTN_TryMqSqlConnectin.TabIndex = 8
        Me.BTN_TryMqSqlConnectin.Text = "Verbindung Testen"
        Me.BTN_TryMqSqlConnectin.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(18, 178)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(50, 13)
        Me.Label9.TabIndex = 7
        Me.Label9.Text = "Passwort"
        '
        'TXB_MySqlPassword
        '
        Me.TXB_MySqlPassword.Location = New System.Drawing.Point(21, 199)
        Me.TXB_MySqlPassword.Name = "TXB_MySqlPassword"
        Me.TXB_MySqlPassword.Size = New System.Drawing.Size(364, 20)
        Me.TXB_MySqlPassword.TabIndex = 6
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(18, 129)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(86, 13)
        Me.Label10.TabIndex = 5
        Me.Label10.Text = "Datenbankname"
        '
        'TXB_MySqlDatabase
        '
        Me.TXB_MySqlDatabase.Location = New System.Drawing.Point(21, 150)
        Me.TXB_MySqlDatabase.Name = "TXB_MySqlDatabase"
        Me.TXB_MySqlDatabase.Size = New System.Drawing.Size(364, 20)
        Me.TXB_MySqlDatabase.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(18, 80)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Benutzername"
        '
        'TXB_MySqlUsername
        '
        Me.TXB_MySqlUsername.Location = New System.Drawing.Point(21, 101)
        Me.TXB_MySqlUsername.Name = "TXB_MySqlUsername"
        Me.TXB_MySqlUsername.Size = New System.Drawing.Size(364, 20)
        Me.TXB_MySqlUsername.TabIndex = 4
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(18, 31)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(75, 13)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "Serveradresse"
        '
        'TXB_MySqlServer
        '
        Me.TXB_MySqlServer.Location = New System.Drawing.Point(20, 47)
        Me.TXB_MySqlServer.Name = "TXB_MySqlServer"
        Me.TXB_MySqlServer.Size = New System.Drawing.Size(364, 20)
        Me.TXB_MySqlServer.TabIndex = 3
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.LinkLabel1)
        Me.GroupBox1.Controls.Add(Me.BTN_CheckLicense)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.TXB_Regkey)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.TXB_LicenseEmail)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.TXB_LicenseName)
        Me.GroupBox1.Location = New System.Drawing.Point(17, 21)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(582, 198)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Lizenzdaten"
        Me.TT_Licensedata.SetToolTip(Me.GroupBox1, "Lizenzdaten können auf https://www.lfdev.de erworben werden." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Folgende Lizenzen g" &
        "ibt es: " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "-> Free")
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(18, 173)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(85, 13)
        Me.LinkLabel1.TabIndex = 10
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Hier Registrieren"
        '
        'BTN_CheckLicense
        '
        Me.BTN_CheckLicense.Location = New System.Drawing.Point(414, 151)
        Me.BTN_CheckLicense.Name = "BTN_CheckLicense"
        Me.BTN_CheckLicense.Size = New System.Drawing.Size(143, 23)
        Me.BTN_CheckLicense.TabIndex = 9
        Me.BTN_CheckLicense.Text = "Lizenzdaten überprüfen"
        Me.BTN_CheckLicense.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(18, 129)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(44, 13)
        Me.Label16.TabIndex = 5
        Me.Label16.Text = "Regkey"
        '
        'TXB_Regkey
        '
        Me.TXB_Regkey.Location = New System.Drawing.Point(21, 150)
        Me.TXB_Regkey.Name = "TXB_Regkey"
        Me.TXB_Regkey.Size = New System.Drawing.Size(364, 20)
        Me.TXB_Regkey.TabIndex = 4
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(18, 80)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(32, 13)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "Email"
        '
        'TXB_LicenseEmail
        '
        Me.TXB_LicenseEmail.Location = New System.Drawing.Point(21, 101)
        Me.TXB_LicenseEmail.Name = "TXB_LicenseEmail"
        Me.TXB_LicenseEmail.Size = New System.Drawing.Size(364, 20)
        Me.TXB_LicenseEmail.TabIndex = 2
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(18, 31)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(35, 13)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Name"
        '
        'TXB_LicenseName
        '
        Me.TXB_LicenseName.Location = New System.Drawing.Point(21, 52)
        Me.TXB_LicenseName.Name = "TXB_LicenseName"
        Me.TXB_LicenseName.Size = New System.Drawing.Size(364, 20)
        Me.TXB_LicenseName.TabIndex = 0
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.Location = New System.Drawing.Point(379, 847)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(257, 17)
        Me.CheckBox1.TabIndex = 9
        Me.CheckBox1.Text = "Tabellen und Verzeichnisse automatisch anlegen"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'BTN_SaveData
        '
        Me.BTN_SaveData.Enabled = False
        Me.BTN_SaveData.Location = New System.Drawing.Point(379, 865)
        Me.BTN_SaveData.Name = "BTN_SaveData"
        Me.BTN_SaveData.Size = New System.Drawing.Size(257, 23)
        Me.BTN_SaveData.TabIndex = 10
        Me.BTN_SaveData.Text = "Daten Sichern und Fortfahren"
        Me.BTN_SaveData.UseVisualStyleBackColor = True
        '
        'FBD_SaveConfigFile
        '
        '
        'NI_Successful
        '
        Me.NI_Successful.Icon = CType(resources.GetObject("NI_Successful.Icon"), System.Drawing.Icon)
        Me.NI_Successful.Text = "NotifyIcon1"
        Me.NI_Successful.Visible = True
        '
        'NI_Error
        '
        Me.NI_Error.Icon = CType(resources.GetObject("NI_Error.Icon"), System.Drawing.Icon)
        Me.NI_Error.Text = "NotifyIcon1"
        Me.NI_Error.Visible = True
        '
        'PB_QRFTP
        '
        Me.PB_QRFTP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PB_QRFTP.Location = New System.Drawing.Point(433, 21)
        Me.PB_QRFTP.Name = "PB_QRFTP"
        Me.PB_QRFTP.Size = New System.Drawing.Size(118, 118)
        Me.PB_QRFTP.TabIndex = 10
        Me.PB_QRFTP.TabStop = False
        '
        'FirstRun
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(653, 913)
        Me.Controls.Add(Me.BTN_SaveData)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.PNL_2)
        Me.Controls.Add(Me.LBL_FTPConnection)
        Me.Controls.Add(Me.LBL_MySqlConnection)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PNL_1)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FirstRun"
        Me.Text = "Erste Schritte"
        Me.PNL_1.ResumeLayout(False)
        Me.PNL_1.PerformLayout()
        Me.PNL_2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.PNL_FTP.ResumeLayout(False)
        Me.PNL_FTP.PerformLayout()
        Me.PNL_SFTP.ResumeLayout(False)
        Me.PNL_SFTP.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PB_QRFTP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents PNL_1 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents LBL_MySqlConnection As Label
    Friend WithEvents LBL_FTPConnection As Label
    Friend WithEvents BTN_GetStarted As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents PNL_2 As Panel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label7 As Label
    Friend WithEvents TXB_LicenseEmail As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents TXB_LicenseName As TextBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label9 As Label
    Friend WithEvents TXB_MySqlPassword As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents TXB_MySqlDatabase As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TXB_MySqlUsername As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents TXB_MySqlServer As TextBox
    Friend WithEvents BTN_TryMqSqlConnectin As Button
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents BTN_SaveData As Button
    Friend WithEvents BTN_ImportSettings As Button
    Friend WithEvents FBD_SaveConfigFile As FolderBrowserDialog
    Friend WithEvents NI_Successful As NotifyIcon
    Friend WithEvents NI_Error As NotifyIcon
    Friend WithEvents CB_SFTP As CheckBox
    Friend WithEvents PNL_SFTP As Panel
    Friend WithEvents BTN_LoadOpenSSHKey As Button
    Friend WithEvents CB_KeyFileLoaded As CheckBox
    Friend WithEvents TXB_SFTPServerUri As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents BTN_TrySFTPConnection As Button
    Friend WithEvents TXB_SFTPUsername As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents PNL_FTP As Panel
    Friend WithEvents TXB_FTPServerUri As TextBox
    Friend WithEvents PB_QRFTP As PictureBox
    Friend WithEvents Label14 As Label
    Friend WithEvents BTN_TryFTPConnection As Button
    Friend WithEvents TXB_FTPUsername As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents TXB_FTPPassword As TextBox
    Friend WithEvents BTN_CheckLicense As Button
    Friend WithEvents Label16 As Label
    Friend WithEvents TXB_Regkey As TextBox
    Friend WithEvents TT_Licensedata As ToolTip
    Friend WithEvents LinkLabel1 As LinkLabel
End Class
