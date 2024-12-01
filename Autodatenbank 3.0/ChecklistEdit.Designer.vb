<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ChecklistEdit
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ChecklistEdit))
        Me.LB_ListChecklist = New System.Windows.Forms.ListBox()
        Me.CMS_SavedChecklist = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.TSMI_EditSavedChecklist = New System.Windows.Forms.ToolStripMenuItem()
        Me.BTN_NewChecklist = New System.Windows.Forms.Button()
        Me.GB_Checklist = New System.Windows.Forms.GroupBox()
        Me.GB_NewChecklist = New System.Windows.Forms.GroupBox()
        Me.TXB_DescriptionChecklist = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BTN_SaveWorkstep = New System.Windows.Forms.Button()
        Me.BTN_SaveChecklist = New System.Windows.Forms.Button()
        Me.RTB_DescriptionWorkStep = New System.Windows.Forms.RichTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LB_ChecklistPoints = New System.Windows.Forms.ListBox()
        Me.CMS_CheckListEditEntrys = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.TMSI_EditWorkStepEntry = New System.Windows.Forms.ToolStripMenuItem()
        Me.TMSI_DeleteWorkStepEntry = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMS_SavedChecklist.SuspendLayout()
        Me.GB_Checklist.SuspendLayout()
        Me.GB_NewChecklist.SuspendLayout()
        Me.CMS_CheckListEditEntrys.SuspendLayout()
        Me.SuspendLayout()
        '
        'LB_ListChecklist
        '
        Me.LB_ListChecklist.ContextMenuStrip = Me.CMS_SavedChecklist
        resources.ApplyResources(Me.LB_ListChecklist, "LB_ListChecklist")
        Me.LB_ListChecklist.FormattingEnabled = True
        Me.LB_ListChecklist.Name = "LB_ListChecklist"
        '
        'CMS_SavedChecklist
        '
        Me.CMS_SavedChecklist.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSMI_EditSavedChecklist})
        Me.CMS_SavedChecklist.Name = "CMS_SavedChecklist"
        resources.ApplyResources(Me.CMS_SavedChecklist, "CMS_SavedChecklist")
        '
        'TSMI_EditSavedChecklist
        '
        Me.TSMI_EditSavedChecklist.Name = "TSMI_EditSavedChecklist"
        resources.ApplyResources(Me.TSMI_EditSavedChecklist, "TSMI_EditSavedChecklist")
        '
        'BTN_NewChecklist
        '
        Me.BTN_NewChecklist.BackColor = System.Drawing.Color.LightGray
        resources.ApplyResources(Me.BTN_NewChecklist, "BTN_NewChecklist")
        Me.BTN_NewChecklist.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.BTN_NewChecklist.Name = "BTN_NewChecklist"
        Me.BTN_NewChecklist.UseVisualStyleBackColor = False
        '
        'GB_Checklist
        '
        Me.GB_Checklist.Controls.Add(Me.LB_ListChecklist)
        Me.GB_Checklist.Controls.Add(Me.BTN_NewChecklist)
        resources.ApplyResources(Me.GB_Checklist, "GB_Checklist")
        Me.GB_Checklist.Name = "GB_Checklist"
        Me.GB_Checklist.TabStop = False
        '
        'GB_NewChecklist
        '
        Me.GB_NewChecklist.Controls.Add(Me.TXB_DescriptionChecklist)
        Me.GB_NewChecklist.Controls.Add(Me.Label3)
        Me.GB_NewChecklist.Controls.Add(Me.BTN_SaveWorkstep)
        Me.GB_NewChecklist.Controls.Add(Me.BTN_SaveChecklist)
        Me.GB_NewChecklist.Controls.Add(Me.RTB_DescriptionWorkStep)
        Me.GB_NewChecklist.Controls.Add(Me.Label2)
        Me.GB_NewChecklist.Controls.Add(Me.Label1)
        Me.GB_NewChecklist.Controls.Add(Me.LB_ChecklistPoints)
        resources.ApplyResources(Me.GB_NewChecklist, "GB_NewChecklist")
        Me.GB_NewChecklist.Name = "GB_NewChecklist"
        Me.GB_NewChecklist.TabStop = False
        '
        'TXB_DescriptionChecklist
        '
        resources.ApplyResources(Me.TXB_DescriptionChecklist, "TXB_DescriptionChecklist")
        Me.TXB_DescriptionChecklist.Name = "TXB_DescriptionChecklist"
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'BTN_SaveWorkstep
        '
        Me.BTN_SaveWorkstep.BackColor = System.Drawing.Color.LightGray
        resources.ApplyResources(Me.BTN_SaveWorkstep, "BTN_SaveWorkstep")
        Me.BTN_SaveWorkstep.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.BTN_SaveWorkstep.Name = "BTN_SaveWorkstep"
        Me.BTN_SaveWorkstep.UseVisualStyleBackColor = False
        '
        'BTN_SaveChecklist
        '
        Me.BTN_SaveChecklist.BackColor = System.Drawing.Color.LightGray
        resources.ApplyResources(Me.BTN_SaveChecklist, "BTN_SaveChecklist")
        Me.BTN_SaveChecklist.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.BTN_SaveChecklist.Name = "BTN_SaveChecklist"
        Me.BTN_SaveChecklist.UseVisualStyleBackColor = False
        '
        'RTB_DescriptionWorkStep
        '
        resources.ApplyResources(Me.RTB_DescriptionWorkStep, "RTB_DescriptionWorkStep")
        Me.RTB_DescriptionWorkStep.Name = "RTB_DescriptionWorkStep"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'LB_ChecklistPoints
        '
        Me.LB_ChecklistPoints.AllowDrop = True
        Me.LB_ChecklistPoints.ContextMenuStrip = Me.CMS_CheckListEditEntrys
        resources.ApplyResources(Me.LB_ChecklistPoints, "LB_ChecklistPoints")
        Me.LB_ChecklistPoints.FormattingEnabled = True
        Me.LB_ChecklistPoints.Name = "LB_ChecklistPoints"
        '
        'CMS_CheckListEditEntrys
        '
        Me.CMS_CheckListEditEntrys.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TMSI_EditWorkStepEntry, Me.TMSI_DeleteWorkStepEntry})
        Me.CMS_CheckListEditEntrys.Name = "CMS_CheckListEditEntrys"
        resources.ApplyResources(Me.CMS_CheckListEditEntrys, "CMS_CheckListEditEntrys")
        '
        'TMSI_EditWorkStepEntry
        '
        Me.TMSI_EditWorkStepEntry.Name = "TMSI_EditWorkStepEntry"
        resources.ApplyResources(Me.TMSI_EditWorkStepEntry, "TMSI_EditWorkStepEntry")
        '
        'TMSI_DeleteWorkStepEntry
        '
        Me.TMSI_DeleteWorkStepEntry.ForeColor = System.Drawing.Color.Red
        Me.TMSI_DeleteWorkStepEntry.Name = "TMSI_DeleteWorkStepEntry"
        resources.ApplyResources(Me.TMSI_DeleteWorkStepEntry, "TMSI_DeleteWorkStepEntry")
        '
        'Checklist
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GB_NewChecklist)
        Me.Controls.Add(Me.GB_Checklist)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "Checklist"
        Me.CMS_SavedChecklist.ResumeLayout(False)
        Me.GB_Checklist.ResumeLayout(False)
        Me.GB_NewChecklist.ResumeLayout(False)
        Me.GB_NewChecklist.PerformLayout()
        Me.CMS_CheckListEditEntrys.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LB_ListChecklist As ListBox
    Friend WithEvents BTN_NewChecklist As Button
    Friend WithEvents GB_Checklist As GroupBox
    Friend WithEvents GB_NewChecklist As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents LB_ChecklistPoints As ListBox
    Friend WithEvents RTB_DescriptionWorkStep As RichTextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TXB_DescriptionChecklist As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents BTN_SaveWorkstep As Button
    Friend WithEvents BTN_SaveChecklist As Button
    Friend WithEvents CMS_CheckListEditEntrys As ContextMenuStrip
    Friend WithEvents TMSI_EditWorkStepEntry As ToolStripMenuItem
    Friend WithEvents TMSI_DeleteWorkStepEntry As ToolStripMenuItem
    Friend WithEvents CMS_SavedChecklist As ContextMenuStrip
    Friend WithEvents TSMI_EditSavedChecklist As ToolStripMenuItem
End Class
