<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportSettings
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReportSettings))
        Me.TXB_CompName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TXB_CompStreet = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TXB_CompCity = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GB_CompanyData = New System.Windows.Forms.GroupBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TXB_LogoWidth = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.BTN_Preview = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TXB_LogoHeight = New System.Windows.Forms.TextBox()
        Me.BTN_SelectNewLogo = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TXB_LogoPath = New System.Windows.Forms.TextBox()
        Me.PB_Logo = New System.Windows.Forms.PictureBox()
        Me.BTN_Save = New System.Windows.Forms.Button()
        Me.NI_Successful = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.NI_Error = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.GB_CompanyData.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PB_Logo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TXB_CompName
        '
        Me.TXB_CompName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXB_CompName.Location = New System.Drawing.Point(6, 44)
        Me.TXB_CompName.Name = "TXB_CompName"
        Me.TXB_CompName.Size = New System.Drawing.Size(240, 22)
        Me.TXB_CompName.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 16)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Firmenname"
        '
        'TXB_CompStreet
        '
        Me.TXB_CompStreet.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXB_CompStreet.Location = New System.Drawing.Point(6, 98)
        Me.TXB_CompStreet.Name = "TXB_CompStreet"
        Me.TXB_CompStreet.Size = New System.Drawing.Size(240, 22)
        Me.TXB_CompStreet.TabIndex = 11
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(3, 79)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(143, 16)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Straße u. Hausnummer"
        '
        'TXB_CompCity
        '
        Me.TXB_CompCity.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXB_CompCity.Location = New System.Drawing.Point(6, 154)
        Me.TXB_CompCity.Name = "TXB_CompCity"
        Me.TXB_CompCity.Size = New System.Drawing.Size(240, 22)
        Me.TXB_CompCity.TabIndex = 13
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 135)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 16)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "PLZ u. Stadt"
        '
        'GB_CompanyData
        '
        Me.GB_CompanyData.Controls.Add(Me.Label1)
        Me.GB_CompanyData.Controls.Add(Me.TXB_CompCity)
        Me.GB_CompanyData.Controls.Add(Me.TXB_CompName)
        Me.GB_CompanyData.Controls.Add(Me.Label3)
        Me.GB_CompanyData.Controls.Add(Me.Label2)
        Me.GB_CompanyData.Controls.Add(Me.TXB_CompStreet)
        Me.GB_CompanyData.Location = New System.Drawing.Point(12, 12)
        Me.GB_CompanyData.Name = "GB_CompanyData"
        Me.GB_CompanyData.Size = New System.Drawing.Size(252, 203)
        Me.GB_CompanyData.TabIndex = 14
        Me.GB_CompanyData.TabStop = False
        Me.GB_CompanyData.Text = "Firmenanschrift"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TXB_LogoWidth)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.BTN_Preview)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.TXB_LogoHeight)
        Me.GroupBox1.Controls.Add(Me.BTN_SelectNewLogo)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.TXB_LogoPath)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 221)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(252, 203)
        Me.GroupBox1.TabIndex = 15
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Logo "
        '
        'TXB_LogoWidth
        '
        Me.TXB_LogoWidth.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXB_LogoWidth.Location = New System.Drawing.Point(139, 129)
        Me.TXB_LogoWidth.Name = "TXB_LogoWidth"
        Me.TXB_LogoWidth.Size = New System.Drawing.Size(107, 22)
        Me.TXB_LogoWidth.TabIndex = 21
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(136, 110)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(76, 16)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "Logo Breite"
        '
        'BTN_Preview
        '
        Me.BTN_Preview.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_Preview.Location = New System.Drawing.Point(9, 159)
        Me.BTN_Preview.Name = "BTN_Preview"
        Me.BTN_Preview.Size = New System.Drawing.Size(240, 26)
        Me.BTN_Preview.TabIndex = 19
        Me.BTN_Preview.Text = "Vorschau"
        Me.BTN_Preview.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(6, 110)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(74, 16)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "Logo Höhe"
        '
        'TXB_LogoHeight
        '
        Me.TXB_LogoHeight.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXB_LogoHeight.Location = New System.Drawing.Point(9, 129)
        Me.TXB_LogoHeight.Name = "TXB_LogoHeight"
        Me.TXB_LogoHeight.Size = New System.Drawing.Size(107, 22)
        Me.TXB_LogoHeight.TabIndex = 18
        '
        'BTN_SelectNewLogo
        '
        Me.BTN_SelectNewLogo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_SelectNewLogo.Location = New System.Drawing.Point(9, 74)
        Me.BTN_SelectNewLogo.Name = "BTN_SelectNewLogo"
        Me.BTN_SelectNewLogo.Size = New System.Drawing.Size(240, 26)
        Me.BTN_SelectNewLogo.TabIndex = 16
        Me.BTN_SelectNewLogo.Text = "Neues Logo auswählen"
        Me.BTN_SelectNewLogo.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(6, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(110, 16)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Logo Speicherort"
        '
        'TXB_LogoPath
        '
        Me.TXB_LogoPath.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXB_LogoPath.Location = New System.Drawing.Point(9, 44)
        Me.TXB_LogoPath.Name = "TXB_LogoPath"
        Me.TXB_LogoPath.Size = New System.Drawing.Size(240, 22)
        Me.TXB_LogoPath.TabIndex = 15
        '
        'PB_Logo
        '
        Me.PB_Logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PB_Logo.Location = New System.Drawing.Point(271, 13)
        Me.PB_Logo.Name = "PB_Logo"
        Me.PB_Logo.Size = New System.Drawing.Size(517, 411)
        Me.PB_Logo.TabIndex = 16
        Me.PB_Logo.TabStop = False
        '
        'BTN_Save
        '
        Me.BTN_Save.BackColor = System.Drawing.Color.LightGray
        Me.BTN_Save.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!)
        Me.BTN_Save.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.BTN_Save.Location = New System.Drawing.Point(12, 430)
        Me.BTN_Save.Name = "BTN_Save"
        Me.BTN_Save.Size = New System.Drawing.Size(776, 76)
        Me.BTN_Save.TabIndex = 36
        Me.BTN_Save.Text = "Einstellungen speichern"
        Me.BTN_Save.UseVisualStyleBackColor = False
        '
        'NI_Successful
        '
        Me.NI_Successful.Icon = CType(resources.GetObject("NI_Successful.Icon"), System.Drawing.Icon)
        Me.NI_Successful.Text = "NotifyIcon1"
        '
        'NI_Error
        '
        Me.NI_Error.Icon = CType(resources.GetObject("NI_Error.Icon"), System.Drawing.Icon)
        Me.NI_Error.Text = "NotifyIcon1"
        Me.NI_Error.Visible = True
        '
        'ReportSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 518)
        Me.Controls.Add(Me.BTN_Save)
        Me.Controls.Add(Me.PB_Logo)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GB_CompanyData)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ReportSettings"
        Me.Text = "Bericht Einstellungen"
        Me.GB_CompanyData.ResumeLayout(False)
        Me.GB_CompanyData.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PB_Logo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TXB_CompName As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TXB_CompStreet As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TXB_CompCity As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents GB_CompanyData As GroupBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents BTN_SelectNewLogo As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents TXB_LogoPath As TextBox
    Friend WithEvents TXB_LogoWidth As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents BTN_Preview As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents TXB_LogoHeight As TextBox
    Friend WithEvents PB_Logo As PictureBox
    Friend WithEvents BTN_Save As Button
    Friend WithEvents NI_Successful As NotifyIcon
    Friend WithEvents NI_Error As NotifyIcon
End Class
