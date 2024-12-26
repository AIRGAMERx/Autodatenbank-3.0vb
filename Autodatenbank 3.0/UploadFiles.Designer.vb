<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UploadFiles
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UploadFiles))
        Me.BTN_Upload = New System.Windows.Forms.Button()
        Me.BTN_SelectFile = New System.Windows.Forms.Button()
        Me.TXB_DataPath = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.OFD_UploadFiles = New System.Windows.Forms.OpenFileDialog()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TXB_FileName = New System.Windows.Forms.TextBox()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.TSL_Screenshot = New System.Windows.Forms.ToolStripLabel()
        Me.PB_PrevieScreenshot = New System.Windows.Forms.PictureBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.PB_PrevieScreenshot, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BTN_Upload
        '
        Me.BTN_Upload.Location = New System.Drawing.Point(336, 94)
        Me.BTN_Upload.Name = "BTN_Upload"
        Me.BTN_Upload.Size = New System.Drawing.Size(75, 23)
        Me.BTN_Upload.TabIndex = 0
        Me.BTN_Upload.Text = "Hochladen"
        Me.BTN_Upload.UseVisualStyleBackColor = True
        '
        'BTN_SelectFile
        '
        Me.BTN_SelectFile.Location = New System.Drawing.Point(336, 46)
        Me.BTN_SelectFile.Name = "BTN_SelectFile"
        Me.BTN_SelectFile.Size = New System.Drawing.Size(75, 23)
        Me.BTN_SelectFile.TabIndex = 1
        Me.BTN_SelectFile.Text = "..."
        Me.BTN_SelectFile.UseVisualStyleBackColor = True
        '
        'TXB_DataPath
        '
        Me.TXB_DataPath.Location = New System.Drawing.Point(12, 46)
        Me.TXB_DataPath.Name = "TXB_DataPath"
        Me.TXB_DataPath.Size = New System.Drawing.Size(318, 20)
        Me.TXB_DataPath.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Dateipfad"
        '
        'OFD_UploadFiles
        '
        Me.OFD_UploadFiles.FileName = "Datei auswählen"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 81)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Bezeichnung"
        '
        'TXB_FileName
        '
        Me.TXB_FileName.Location = New System.Drawing.Point(12, 97)
        Me.TXB_FileName.Name = "TXB_FileName"
        Me.TXB_FileName.Size = New System.Drawing.Size(318, 20)
        Me.TXB_FileName.TabIndex = 4
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(15, 130)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(396, 23)
        Me.ProgressBar1.TabIndex = 6
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSL_Screenshot})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(428, 25)
        Me.ToolStrip1.TabIndex = 7
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'TSL_Screenshot
        '
        Me.TSL_Screenshot.Name = "TSL_Screenshot"
        Me.TSL_Screenshot.Size = New System.Drawing.Size(111, 22)
        Me.TSL_Screenshot.Text = "Screenshot machen"
        '
        'PB_PrevieScreenshot
        '
        Me.PB_PrevieScreenshot.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PB_PrevieScreenshot.Location = New System.Drawing.Point(15, 184)
        Me.PB_PrevieScreenshot.Name = "PB_PrevieScreenshot"
        Me.PB_PrevieScreenshot.Size = New System.Drawing.Size(396, 225)
        Me.PB_PrevieScreenshot.TabIndex = 8
        Me.PB_PrevieScreenshot.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 168)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(109, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Vorschau Screenshot"
        '
        'UploadFiles
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(428, 159)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.PB_PrevieScreenshot)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TXB_FileName)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TXB_DataPath)
        Me.Controls.Add(Me.BTN_SelectFile)
        Me.Controls.Add(Me.BTN_Upload)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "UploadFiles"
        Me.Text = " Datei Hochladen"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.PB_PrevieScreenshot, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BTN_Upload As Button
    Friend WithEvents BTN_SelectFile As Button
    Friend WithEvents TXB_DataPath As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents OFD_UploadFiles As OpenFileDialog
    Friend WithEvents Label2 As Label
    Friend WithEvents TXB_FileName As TextBox
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents TSL_Screenshot As ToolStripLabel
    Friend WithEvents PB_PrevieScreenshot As PictureBox
    Friend WithEvents Label3 As Label
End Class
