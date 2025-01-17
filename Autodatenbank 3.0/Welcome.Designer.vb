<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Welcome
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Welcome))
        Me.TMR_WaitForStart = New System.Windows.Forms.Timer(Me.components)
        Me.Lbl_Status = New System.Windows.Forms.Label()
        Me.LBL_HELP = New System.Windows.Forms.Label()
        Me.PB_Logo = New System.Windows.Forms.PictureBox()
        CType(Me.PB_Logo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Lbl_Status
        '
        Me.Lbl_Status.AutoSize = True
        Me.Lbl_Status.Location = New System.Drawing.Point(12, 478)
        Me.Lbl_Status.Name = "Lbl_Status"
        Me.Lbl_Status.Size = New System.Drawing.Size(0, 13)
        Me.Lbl_Status.TabIndex = 1
        '
        'LBL_HELP
        '
        Me.LBL_HELP.AutoSize = True
        Me.LBL_HELP.Location = New System.Drawing.Point(12, 9)
        Me.LBL_HELP.Name = "LBL_HELP"
        Me.LBL_HELP.Size = New System.Drawing.Size(254, 13)
        Me.LBL_HELP.TabIndex = 2
        Me.LBL_HELP.Text = "Drücke F2+d um die Standardeinstellungen zu laden"
        '
        'PB_Logo
        '
        Me.PB_Logo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PB_Logo.Image = Global.Autodatenbank_3._0.My.Resources.Resources.logo
        Me.PB_Logo.Location = New System.Drawing.Point(0, 0)
        Me.PB_Logo.Name = "PB_Logo"
        Me.PB_Logo.Size = New System.Drawing.Size(500, 500)
        Me.PB_Logo.TabIndex = 0
        Me.PB_Logo.TabStop = False
        '
        'Welcome
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(500, 500)
        Me.Controls.Add(Me.Lbl_Status)
        Me.Controls.Add(Me.LBL_HELP)
        Me.Controls.Add(Me.PB_Logo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Welcome"
        Me.Opacity = 0.9R
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Welcome"
        CType(Me.PB_Logo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PB_Logo As PictureBox
    Friend WithEvents TMR_WaitForStart As Timer
    Friend WithEvents Lbl_Status As Label
    Friend WithEvents LBL_HELP As Label
End Class
