<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PR
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PR))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TXB_PrNumbers = New System.Windows.Forms.TextBox()
        Me.BTN_Search = New System.Windows.Forms.Button()
        Me.LB_Designation = New System.Windows.Forms.ListBox()
        Me.CMS_PRNumbers = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.KopierenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CBB_SavedCars = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BTN_InsertIntoCarList = New System.Windows.Forms.Button()
        Me.CMS_PRNumbers.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(401, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Pr-Nummer eingeben: (mehrere Nummern mit ; trennen)"
        '
        'TXB_PrNumbers
        '
        Me.TXB_PrNumbers.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXB_PrNumbers.Location = New System.Drawing.Point(15, 35)
        Me.TXB_PrNumbers.Name = "TXB_PrNumbers"
        Me.TXB_PrNumbers.Size = New System.Drawing.Size(249, 26)
        Me.TXB_PrNumbers.TabIndex = 1
        '
        'BTN_Search
        '
        Me.BTN_Search.BackColor = System.Drawing.Color.LightGray
        Me.BTN_Search.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_Search.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.BTN_Search.Location = New System.Drawing.Point(270, 31)
        Me.BTN_Search.Name = "BTN_Search"
        Me.BTN_Search.Size = New System.Drawing.Size(170, 36)
        Me.BTN_Search.TabIndex = 36
        Me.BTN_Search.Text = "Suchen"
        Me.BTN_Search.UseVisualStyleBackColor = False
        '
        'LB_Designation
        '
        Me.LB_Designation.ContextMenuStrip = Me.CMS_PRNumbers
        Me.LB_Designation.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LB_Designation.FormattingEnabled = True
        Me.LB_Designation.ItemHeight = 20
        Me.LB_Designation.Location = New System.Drawing.Point(12, 164)
        Me.LB_Designation.Name = "LB_Designation"
        Me.LB_Designation.Size = New System.Drawing.Size(428, 264)
        Me.LB_Designation.Sorted = True
        Me.LB_Designation.TabIndex = 37
        '
        'CMS_PRNumbers
        '
        Me.CMS_PRNumbers.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.KopierenToolStripMenuItem})
        Me.CMS_PRNumbers.Name = "CMS_PRNumbers"
        Me.CMS_PRNumbers.Size = New System.Drawing.Size(122, 26)
        '
        'KopierenToolStripMenuItem
        '
        Me.KopierenToolStripMenuItem.Name = "KopierenToolStripMenuItem"
        Me.KopierenToolStripMenuItem.Size = New System.Drawing.Size(121, 22)
        Me.KopierenToolStripMenuItem.Text = "Kopieren"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 70)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(231, 20)
        Me.Label2.TabIndex = 38
        Me.Label2.Text = "Pr-Nummer zu Auto hinzufügen"
        '
        'CBB_SavedCars
        '
        Me.CBB_SavedCars.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBB_SavedCars.FormattingEnabled = True
        Me.CBB_SavedCars.Location = New System.Drawing.Point(15, 95)
        Me.CBB_SavedCars.Name = "CBB_SavedCars"
        Me.CBB_SavedCars.Size = New System.Drawing.Size(249, 28)
        Me.CBB_SavedCars.TabIndex = 39
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 134)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(202, 20)
        Me.Label3.TabIndex = 40
        Me.Label3.Text = "PR-Nummern entschlüsselt"
        '
        'BTN_InsertIntoCarList
        '
        Me.BTN_InsertIntoCarList.BackColor = System.Drawing.Color.LightGray
        Me.BTN_InsertIntoCarList.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_InsertIntoCarList.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.BTN_InsertIntoCarList.Location = New System.Drawing.Point(270, 92)
        Me.BTN_InsertIntoCarList.Name = "BTN_InsertIntoCarList"
        Me.BTN_InsertIntoCarList.Size = New System.Drawing.Size(170, 36)
        Me.BTN_InsertIntoCarList.TabIndex = 41
        Me.BTN_InsertIntoCarList.Text = "Hinzufügen"
        Me.BTN_InsertIntoCarList.UseVisualStyleBackColor = False
        '
        'PR
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(497, 446)
        Me.Controls.Add(Me.BTN_InsertIntoCarList)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.CBB_SavedCars)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.LB_Designation)
        Me.Controls.Add(Me.BTN_Search)
        Me.Controls.Add(Me.TXB_PrNumbers)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "PR"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PR-Nummern entschlüsseln    (BETA)"
        Me.CMS_PRNumbers.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents TXB_PrNumbers As TextBox
    Friend WithEvents BTN_Search As Button
    Friend WithEvents LB_Designation As ListBox
    Friend WithEvents CMS_PRNumbers As ContextMenuStrip
    Friend WithEvents KopierenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label2 As Label
    Friend WithEvents CBB_SavedCars As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents BTN_InsertIntoCarList As Button
End Class
