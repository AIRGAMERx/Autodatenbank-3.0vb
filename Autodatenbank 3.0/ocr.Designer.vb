<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ocr
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ocr))
        Me.FSOFD = New System.Windows.Forms.OpenFileDialog()
        Me.txb_FilePath = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btn_OpenFile = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PB_Preview = New System.Windows.Forms.PictureBox()
        Me.btn_UploadPicture = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        CType(Me.PB_Preview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'FSOFD
        '
        Me.FSOFD.FileName = "Fahrzeugschein"
        Me.FSOFD.Filter = """Bilddatein|*.jpg;*.jpeg;*.png"";"
        '
        'txb_FilePath
        '
        Me.txb_FilePath.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txb_FilePath.Location = New System.Drawing.Point(12, 45)
        Me.txb_FilePath.Name = "txb_FilePath"
        Me.txb_FilePath.Size = New System.Drawing.Size(412, 26)
        Me.txb_FilePath.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(203, 20)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Fahrzeugschein auswählen"
        '
        'btn_OpenFile
        '
        Me.btn_OpenFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_OpenFile.Location = New System.Drawing.Point(430, 45)
        Me.btn_OpenFile.Name = "btn_OpenFile"
        Me.btn_OpenFile.Size = New System.Drawing.Size(43, 26)
        Me.btn_OpenFile.TabIndex = 2
        Me.btn_OpenFile.Text = "..."
        Me.btn_OpenFile.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel1.Controls.Add(Me.PB_Preview)
        Me.Panel1.Location = New System.Drawing.Point(16, 116)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(408, 237)
        Me.Panel1.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 93)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 20)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Vorschau"
        '
        'PB_Preview
        '
        Me.PB_Preview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PB_Preview.Location = New System.Drawing.Point(3, 3)
        Me.PB_Preview.Name = "PB_Preview"
        Me.PB_Preview.Size = New System.Drawing.Size(402, 231)
        Me.PB_Preview.TabIndex = 0
        Me.PB_Preview.TabStop = False
        '
        'btn_UploadPicture
        '
        Me.btn_UploadPicture.BackColor = System.Drawing.Color.LightGray
        Me.btn_UploadPicture.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!)
        Me.btn_UploadPicture.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.btn_UploadPicture.Location = New System.Drawing.Point(12, 372)
        Me.btn_UploadPicture.Name = "btn_UploadPicture"
        Me.btn_UploadPicture.Size = New System.Drawing.Size(412, 38)
        Me.btn_UploadPicture.TabIndex = 44
        Me.btn_UploadPicture.Text = "Bildl Hochladen"
        Me.btn_UploadPicture.UseVisualStyleBackColor = False
        '
        'ocr
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1676, 727)
        Me.Controls.Add(Me.btn_UploadPicture)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btn_OpenFile)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txb_FilePath)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ocr"
        Me.Text = "Fahrzeugschein Hochladen"
        Me.Panel1.ResumeLayout(False)
        CType(Me.PB_Preview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents FSOFD As OpenFileDialog
    Friend WithEvents txb_FilePath As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btn_OpenFile As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents PB_Preview As PictureBox
    Friend WithEvents btn_UploadPicture As Button
End Class
