<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Smartphone_verification
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Smartphone_verification))
        Me.CBB_RegUser = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.CMS_QRCodeSmartphoneVerification = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.KopierenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CMS_QRCodeSmartphoneVerification.SuspendLayout()
        Me.SuspendLayout()
        '
        'CBB_RegUser
        '
        Me.CBB_RegUser.FormattingEnabled = True
        Me.CBB_RegUser.Location = New System.Drawing.Point(15, 46)
        Me.CBB_RegUser.Name = "CBB_RegUser"
        Me.CBB_RegUser.Size = New System.Drawing.Size(314, 21)
        Me.CBB_RegUser.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(323, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Benutzer welcher mit Smartphone verknüpft werden soll auswählen"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.ContextMenuStrip = Me.CMS_QRCodeSmartphoneVerification
        Me.PictureBox1.Location = New System.Drawing.Point(15, 73)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(314, 314)
        Me.PictureBox1.TabIndex = 8
        Me.PictureBox1.TabStop = False
        '
        'CMS_QRCodeSmartphoneVerification
        '
        Me.CMS_QRCodeSmartphoneVerification.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.KopierenToolStripMenuItem})
        Me.CMS_QRCodeSmartphoneVerification.Name = "CMS_QRCodeSmartphoneVerification"
        Me.CMS_QRCodeSmartphoneVerification.Size = New System.Drawing.Size(122, 26)
        '
        'KopierenToolStripMenuItem
        '
        Me.KopierenToolStripMenuItem.Name = "KopierenToolStripMenuItem"
        Me.KopierenToolStripMenuItem.Size = New System.Drawing.Size(121, 22)
        Me.KopierenToolStripMenuItem.Text = "Kopieren"
        '
        'Smartphone_verification
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(348, 397)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CBB_RegUser)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Smartphone_verification"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Smartphone verbinden"
        Me.TopMost = True
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CMS_QRCodeSmartphoneVerification.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents CBB_RegUser As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents CMS_QRCodeSmartphoneVerification As ContextMenuStrip
    Friend WithEvents KopierenToolStripMenuItem As ToolStripMenuItem
End Class
