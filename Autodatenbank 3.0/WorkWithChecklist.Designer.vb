<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WorkWithChecklist
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WorkWithChecklist))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CBB_SavedCars = New System.Windows.Forms.ComboBox()
        Me.CB_ListChecklist = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BTN_SaveChecklist = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LBL_Description = New System.Windows.Forms.Label()
        Me.LB_ChecklistPoints = New System.Windows.Forms.CheckedListBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(127, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Auto auswählen:"
        '
        'CBB_SavedCars
        '
        Me.CBB_SavedCars.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBB_SavedCars.FormattingEnabled = True
        Me.CBB_SavedCars.Location = New System.Drawing.Point(17, 36)
        Me.CBB_SavedCars.Name = "CBB_SavedCars"
        Me.CBB_SavedCars.Size = New System.Drawing.Size(235, 28)
        Me.CBB_SavedCars.TabIndex = 1
        '
        'CB_ListChecklist
        '
        Me.CB_ListChecklist.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CB_ListChecklist.FormattingEnabled = True
        Me.CB_ListChecklist.Location = New System.Drawing.Point(275, 36)
        Me.CB_ListChecklist.Name = "CB_ListChecklist"
        Me.CB_ListChecklist.Size = New System.Drawing.Size(1491, 28)
        Me.CB_ListChecklist.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(271, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(162, 20)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Checkliste auswählen"
        '
        'BTN_SaveChecklist
        '
        Me.BTN_SaveChecklist.BackColor = System.Drawing.Color.LightGray
        Me.BTN_SaveChecklist.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!)
        Me.BTN_SaveChecklist.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.BTN_SaveChecklist.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.BTN_SaveChecklist.Location = New System.Drawing.Point(1443, 873)
        Me.BTN_SaveChecklist.Name = "BTN_SaveChecklist"
        Me.BTN_SaveChecklist.Size = New System.Drawing.Size(323, 63)
        Me.BTN_SaveChecklist.TabIndex = 37
        Me.BTN_SaveChecklist.Text = "Checkliste speichern"
        Me.BTN_SaveChecklist.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(20, 81)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(110, 20)
        Me.Label3.TabIndex = 38
        Me.Label3.Text = "Bezeichnung: "
        '
        'LBL_Description
        '
        Me.LBL_Description.AutoSize = True
        Me.LBL_Description.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_Description.Location = New System.Drawing.Point(127, 81)
        Me.LBL_Description.Name = "LBL_Description"
        Me.LBL_Description.Size = New System.Drawing.Size(0, 20)
        Me.LBL_Description.TabIndex = 39
        '
        'LB_ChecklistPoints
        '
        Me.LB_ChecklistPoints.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LB_ChecklistPoints.Location = New System.Drawing.Point(24, 104)
        Me.LB_ChecklistPoints.Name = "LB_ChecklistPoints"
        Me.LB_ChecklistPoints.Size = New System.Drawing.Size(1742, 739)
        Me.LB_ChecklistPoints.TabIndex = 40
        '
        'WorkWithChecklist
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1778, 947)
        Me.Controls.Add(Me.LB_ChecklistPoints)
        Me.Controls.Add(Me.LBL_Description)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.BTN_SaveChecklist)
        Me.Controls.Add(Me.CB_ListChecklist)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.CBB_SavedCars)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "WorkWithChecklist"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Checklisten"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents CBB_SavedCars As ComboBox
    Friend WithEvents CB_ListChecklist As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents BTN_SaveChecklist As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents LBL_Description As Label
    Friend WithEvents LB_ChecklistPoints As CheckedListBox
End Class
