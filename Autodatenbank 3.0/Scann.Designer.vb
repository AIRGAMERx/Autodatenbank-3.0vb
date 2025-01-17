<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Scann
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Scann))
        Me.GB_ScannSettings = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CBB_ListScanner = New System.Windows.Forms.ComboBox()
        Me.CBB_OutputFormat = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CB_UseAutoFeeder = New System.Windows.Forms.CheckBox()
        Me.CB_UseSingleScann = New System.Windows.Forms.CheckBox()
        Me.BTN_BeginnScann = New System.Windows.Forms.Button()
        Me.PB_Preview = New System.Windows.Forms.PictureBox()
        Me.GB_ScannSettings.SuspendLayout()
        CType(Me.PB_Preview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GB_ScannSettings
        '
        Me.GB_ScannSettings.Controls.Add(Me.Label2)
        Me.GB_ScannSettings.Controls.Add(Me.CBB_ListScanner)
        Me.GB_ScannSettings.Controls.Add(Me.CBB_OutputFormat)
        Me.GB_ScannSettings.Controls.Add(Me.Label1)
        Me.GB_ScannSettings.Controls.Add(Me.CB_UseAutoFeeder)
        Me.GB_ScannSettings.Controls.Add(Me.CB_UseSingleScann)
        Me.GB_ScannSettings.Location = New System.Drawing.Point(12, 12)
        Me.GB_ScannSettings.Name = "GB_ScannSettings"
        Me.GB_ScannSettings.Size = New System.Drawing.Size(271, 228)
        Me.GB_ScannSettings.TabIndex = 0
        Me.GB_ScannSettings.TabStop = False
        Me.GB_ScannSettings.Text = "Scann Einstellungen"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 91)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(101, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Scanner auswählen"
        '
        'CBB_ListScanner
        '
        Me.CBB_ListScanner.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBB_ListScanner.FormattingEnabled = True
        Me.CBB_ListScanner.Location = New System.Drawing.Point(6, 107)
        Me.CBB_ListScanner.Name = "CBB_ListScanner"
        Me.CBB_ListScanner.Size = New System.Drawing.Size(259, 28)
        Me.CBB_ListScanner.TabIndex = 4
        '
        'CBB_OutputFormat
        '
        Me.CBB_OutputFormat.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBB_OutputFormat.FormattingEnabled = True
        Me.CBB_OutputFormat.Location = New System.Drawing.Point(6, 155)
        Me.CBB_OutputFormat.Name = "CBB_OutputFormat"
        Me.CBB_OutputFormat.Size = New System.Drawing.Size(259, 28)
        Me.CBB_OutputFormat.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 138)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(185, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Gescannte Dokumente speichern als "
        '
        'CB_UseAutoFeeder
        '
        Me.CB_UseAutoFeeder.AutoSize = True
        Me.CB_UseAutoFeeder.Location = New System.Drawing.Point(6, 55)
        Me.CB_UseAutoFeeder.Name = "CB_UseAutoFeeder"
        Me.CB_UseAutoFeeder.Size = New System.Drawing.Size(165, 17)
        Me.CB_UseAutoFeeder.TabIndex = 1
        Me.CB_UseAutoFeeder.Text = "Dokumenteneinzug benutzen"
        Me.CB_UseAutoFeeder.UseVisualStyleBackColor = True
        '
        'CB_UseSingleScann
        '
        Me.CB_UseSingleScann.AutoSize = True
        Me.CB_UseSingleScann.Location = New System.Drawing.Point(6, 32)
        Me.CB_UseSingleScann.Name = "CB_UseSingleScann"
        Me.CB_UseSingleScann.Size = New System.Drawing.Size(127, 17)
        Me.CB_UseSingleScann.TabIndex = 0
        Me.CB_UseSingleScann.Text = "Ablagefach benutzen"
        Me.CB_UseSingleScann.UseVisualStyleBackColor = True
        '
        'BTN_BeginnScann
        '
        Me.BTN_BeginnScann.BackColor = System.Drawing.Color.LightGray
        Me.BTN_BeginnScann.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!)
        Me.BTN_BeginnScann.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.BTN_BeginnScann.Location = New System.Drawing.Point(24, 246)
        Me.BTN_BeginnScann.Name = "BTN_BeginnScann"
        Me.BTN_BeginnScann.Size = New System.Drawing.Size(259, 38)
        Me.BTN_BeginnScann.TabIndex = 40
        Me.BTN_BeginnScann.Text = "Scannen"
        Me.BTN_BeginnScann.UseVisualStyleBackColor = False
        '
        'PB_Preview
        '
        Me.PB_Preview.Location = New System.Drawing.Point(289, 21)
        Me.PB_Preview.Name = "PB_Preview"
        Me.PB_Preview.Size = New System.Drawing.Size(231, 261)
        Me.PB_Preview.TabIndex = 41
        Me.PB_Preview.TabStop = False
        '
        'Scann
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(549, 294)
        Me.Controls.Add(Me.PB_Preview)
        Me.Controls.Add(Me.BTN_BeginnScann)
        Me.Controls.Add(Me.GB_ScannSettings)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Scann"
        Me.Text = "Dokumente Scannen"
        Me.GB_ScannSettings.ResumeLayout(False)
        Me.GB_ScannSettings.PerformLayout()
        CType(Me.PB_Preview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GB_ScannSettings As GroupBox
    Friend WithEvents CB_UseSingleScann As CheckBox
    Friend WithEvents CB_UseAutoFeeder As CheckBox
    Friend WithEvents CBB_OutputFormat As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents CBB_ListScanner As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents BTN_BeginnScann As Button
    Friend WithEvents PB_Preview As PictureBox
End Class
