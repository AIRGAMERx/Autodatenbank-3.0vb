<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SearchEntries
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SearchEntries))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TXB_SearchWord = New System.Windows.Forms.TextBox()
        Me.DGV = New System.Windows.Forms.DataGridView()
        Me.SearchMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.BearbeitenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ÖffnenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LöschenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CB_SearchInDatabase = New System.Windows.Forms.CheckBox()
        Me.CB_SearchOnFTP = New System.Windows.Forms.CheckBox()
        Me.BTN_SearchEntries = New System.Windows.Forms.Button()
        Me.cb_editor = New System.Windows.Forms.CheckBox()
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SearchMenuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(108, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Suchbegriff eingeben"
        '
        'TXB_SearchWord
        '
        Me.TXB_SearchWord.Location = New System.Drawing.Point(12, 30)
        Me.TXB_SearchWord.Name = "TXB_SearchWord"
        Me.TXB_SearchWord.Size = New System.Drawing.Size(292, 20)
        Me.TXB_SearchWord.TabIndex = 1
        '
        'DGV
        '
        Me.DGV.AllowUserToAddRows = False
        Me.DGV.AllowUserToDeleteRows = False
        Me.DGV.BackgroundColor = System.Drawing.Color.White
        Me.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV.ContextMenuStrip = Me.SearchMenuStrip
        Me.DGV.Location = New System.Drawing.Point(15, 77)
        Me.DGV.Name = "DGV"
        Me.DGV.Size = New System.Drawing.Size(945, 332)
        Me.DGV.TabIndex = 3
        '
        'SearchMenuStrip
        '
        Me.SearchMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BearbeitenToolStripMenuItem, Me.ÖffnenToolStripMenuItem, Me.LöschenToolStripMenuItem})
        Me.SearchMenuStrip.Name = "SearchMenuStrip"
        Me.SearchMenuStrip.Size = New System.Drawing.Size(131, 70)
        '
        'BearbeitenToolStripMenuItem
        '
        Me.BearbeitenToolStripMenuItem.Name = "BearbeitenToolStripMenuItem"
        Me.BearbeitenToolStripMenuItem.Size = New System.Drawing.Size(130, 22)
        Me.BearbeitenToolStripMenuItem.Text = "Bearbeiten"
        '
        'ÖffnenToolStripMenuItem
        '
        Me.ÖffnenToolStripMenuItem.Name = "ÖffnenToolStripMenuItem"
        Me.ÖffnenToolStripMenuItem.Size = New System.Drawing.Size(130, 22)
        Me.ÖffnenToolStripMenuItem.Text = "Öffnen"
        '
        'LöschenToolStripMenuItem
        '
        Me.LöschenToolStripMenuItem.Name = "LöschenToolStripMenuItem"
        Me.LöschenToolStripMenuItem.Size = New System.Drawing.Size(130, 22)
        Me.LöschenToolStripMenuItem.Text = "Löschen"
        '
        'CB_SearchInDatabase
        '
        Me.CB_SearchInDatabase.AutoSize = True
        Me.CB_SearchInDatabase.Checked = True
        Me.CB_SearchInDatabase.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CB_SearchInDatabase.Location = New System.Drawing.Point(823, 11)
        Me.CB_SearchInDatabase.Name = "CB_SearchInDatabase"
        Me.CB_SearchInDatabase.Size = New System.Drawing.Size(129, 17)
        Me.CB_SearchInDatabase.TabIndex = 4
        Me.CB_SearchInDatabase.Text = "In Datenbank suchen"
        Me.CB_SearchInDatabase.UseVisualStyleBackColor = True
        '
        'CB_SearchOnFTP
        '
        Me.CB_SearchOnFTP.AutoSize = True
        Me.CB_SearchOnFTP.Location = New System.Drawing.Point(823, 36)
        Me.CB_SearchOnFTP.Name = "CB_SearchOnFTP"
        Me.CB_SearchOnFTP.Size = New System.Drawing.Size(137, 17)
        Me.CB_SearchOnFTP.TabIndex = 5
        Me.CB_SearchOnFTP.Text = "Auf FTP-Server suchen"
        Me.CB_SearchOnFTP.UseVisualStyleBackColor = True
        '
        'BTN_SearchEntries
        '
        Me.BTN_SearchEntries.BackColor = System.Drawing.Color.LightGray
        Me.BTN_SearchEntries.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!)
        Me.BTN_SearchEntries.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.BTN_SearchEntries.Location = New System.Drawing.Point(327, 24)
        Me.BTN_SearchEntries.Name = "BTN_SearchEntries"
        Me.BTN_SearchEntries.Size = New System.Drawing.Size(201, 32)
        Me.BTN_SearchEntries.TabIndex = 35
        Me.BTN_SearchEntries.Text = "Suchen"
        Me.BTN_SearchEntries.UseVisualStyleBackColor = False
        '
        'cb_editor
        '
        Me.cb_editor.AutoSize = True
        Me.cb_editor.Location = New System.Drawing.Point(15, 54)
        Me.cb_editor.Name = "cb_editor"
        Me.cb_editor.Size = New System.Drawing.Size(141, 17)
        Me.cb_editor.TabIndex = 36
        Me.cb_editor.Text = "Nach Bearbeiter suchen"
        Me.cb_editor.UseVisualStyleBackColor = True
        '
        'SearchEntries
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(972, 421)
        Me.Controls.Add(Me.cb_editor)
        Me.Controls.Add(Me.BTN_SearchEntries)
        Me.Controls.Add(Me.CB_SearchOnFTP)
        Me.Controls.Add(Me.CB_SearchInDatabase)
        Me.Controls.Add(Me.DGV)
        Me.Controls.Add(Me.TXB_SearchWord)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "SearchEntries"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Suchen"
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SearchMenuStrip.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents TXB_SearchWord As TextBox
    Friend WithEvents DGV As DataGridView
    Friend WithEvents CB_SearchInDatabase As CheckBox
    Friend WithEvents CB_SearchOnFTP As CheckBox
    Friend WithEvents SearchMenuStrip As ContextMenuStrip
    Friend WithEvents BearbeitenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ÖffnenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LöschenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BTN_SearchEntries As Button
    Friend WithEvents cb_editor As CheckBox
End Class
