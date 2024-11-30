<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SSHKEY
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SSHKEY))
        Me.OFD_PEM = New System.Windows.Forms.OpenFileDialog()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TXB_PPKPath = New System.Windows.Forms.TextBox()
        Me.BTN_SelectPPK = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TXB_PPKPass = New System.Windows.Forms.TextBox()
        Me.BTN_TestKeyConnection = New System.Windows.Forms.Button()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.BTN_Save = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'OFD_PEM
        '
        Me.OFD_PEM.FileName = "PEM Datei auswählen"
        Me.OFD_PEM.Filter = "PuTTY Public Key (*.pem)|*.pem|All Files (*.*)|*.*"
        Me.OFD_PEM.Title = "PEM Datei auswählen"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(314, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "OpenSSH-Schlüsseldatei auswählen (.pem-Format)"
        '
        'TXB_PPKPath
        '
        Me.TXB_PPKPath.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXB_PPKPath.Location = New System.Drawing.Point(12, 28)
        Me.TXB_PPKPath.Name = "TXB_PPKPath"
        Me.TXB_PPKPath.Size = New System.Drawing.Size(323, 22)
        Me.TXB_PPKPath.TabIndex = 1
        '
        'BTN_SelectPPK
        '
        Me.BTN_SelectPPK.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_SelectPPK.Location = New System.Drawing.Point(350, 28)
        Me.BTN_SelectPPK.Name = "BTN_SelectPPK"
        Me.BTN_SelectPPK.Size = New System.Drawing.Size(83, 23)
        Me.BTN_SelectPPK.TabIndex = 2
        Me.BTN_SelectPPK.Text = "auswählen"
        Me.BTN_SelectPPK.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 71)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(121, 16)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Passwort (optional)"
        '
        'TXB_PPKPass
        '
        Me.TXB_PPKPass.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXB_PPKPass.Location = New System.Drawing.Point(15, 90)
        Me.TXB_PPKPass.Name = "TXB_PPKPass"
        Me.TXB_PPKPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TXB_PPKPass.Size = New System.Drawing.Size(320, 22)
        Me.TXB_PPKPass.TabIndex = 4
        '
        'BTN_TestKeyConnection
        '
        Me.BTN_TestKeyConnection.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_TestKeyConnection.Location = New System.Drawing.Point(350, 90)
        Me.BTN_TestKeyConnection.Name = "BTN_TestKeyConnection"
        Me.BTN_TestKeyConnection.Size = New System.Drawing.Size(83, 23)
        Me.BTN_TestKeyConnection.TabIndex = 5
        Me.BTN_TestKeyConnection.Text = "Testen"
        Me.BTN_TestKeyConnection.UseVisualStyleBackColor = True
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(15, 119)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(421, 147)
        Me.ListBox1.TabIndex = 6
        '
        'BTN_Save
        '
        Me.BTN_Save.Location = New System.Drawing.Point(15, 272)
        Me.BTN_Save.Name = "BTN_Save"
        Me.BTN_Save.Size = New System.Drawing.Size(421, 33)
        Me.BTN_Save.TabIndex = 7
        Me.BTN_Save.Text = "Speichern"
        Me.BTN_Save.UseVisualStyleBackColor = True
        '
        'SSHKEY
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(448, 317)
        Me.Controls.Add(Me.BTN_Save)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.BTN_TestKeyConnection)
        Me.Controls.Add(Me.TXB_PPKPass)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.BTN_SelectPPK)
        Me.Controls.Add(Me.TXB_PPKPath)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SSHKEY"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "OpenSSH-Schlüssel hinzufügen"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents OFD_PEM As OpenFileDialog
    Friend WithEvents Label1 As Label
    Friend WithEvents TXB_PPKPath As TextBox
    Friend WithEvents BTN_SelectPPK As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents TXB_PPKPass As TextBox
    Friend WithEvents BTN_TestKeyConnection As Button
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents BTN_Save As Button
End Class
