<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ShowCompleteEntry
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ShowCompleteEntry))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TXB_Licenseplate = New System.Windows.Forms.TextBox()
        Me.TXB_Designation = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TXB_Millage = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TXB_Date = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TXB_Editor = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TXB_Art = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TXB_Price = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.RTB_Comment = New System.Windows.Forms.RichTextBox()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.PB_Preview = New System.Windows.Forms.PictureBox()
        Me.WB_Preview = New System.Windows.Forms.WebBrowser()
        Me.CMS_LB_LinkedData = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.LöschenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FlowLayoutPanel1.SuspendLayout()
        CType(Me.PB_Preview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CMS_LB_LinkedData.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Kennzeichen"
        '
        'TXB_Licenseplate
        '
        Me.TXB_Licenseplate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXB_Licenseplate.Location = New System.Drawing.Point(13, 33)
        Me.TXB_Licenseplate.Name = "TXB_Licenseplate"
        Me.TXB_Licenseplate.ReadOnly = True
        Me.TXB_Licenseplate.Size = New System.Drawing.Size(395, 26)
        Me.TXB_Licenseplate.TabIndex = 1
        '
        'TXB_Designation
        '
        Me.TXB_Designation.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXB_Designation.Location = New System.Drawing.Point(13, 85)
        Me.TXB_Designation.Name = "TXB_Designation"
        Me.TXB_Designation.ReadOnly = True
        Me.TXB_Designation.Size = New System.Drawing.Size(395, 26)
        Me.TXB_Designation.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(13, 62)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(102, 20)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Bezeichnung"
        '
        'TXB_Millage
        '
        Me.TXB_Millage.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXB_Millage.Location = New System.Drawing.Point(13, 137)
        Me.TXB_Millage.Name = "TXB_Millage"
        Me.TXB_Millage.ReadOnly = True
        Me.TXB_Millage.Size = New System.Drawing.Size(395, 26)
        Me.TXB_Millage.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(13, 114)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 20)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Kilometer"
        '
        'TXB_Date
        '
        Me.TXB_Date.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXB_Date.Location = New System.Drawing.Point(13, 189)
        Me.TXB_Date.Name = "TXB_Date"
        Me.TXB_Date.ReadOnly = True
        Me.TXB_Date.Size = New System.Drawing.Size(395, 26)
        Me.TXB_Date.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(13, 166)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 20)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Datum"
        '
        'TXB_Editor
        '
        Me.TXB_Editor.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXB_Editor.Location = New System.Drawing.Point(13, 345)
        Me.TXB_Editor.Name = "TXB_Editor"
        Me.TXB_Editor.ReadOnly = True
        Me.TXB_Editor.Size = New System.Drawing.Size(395, 26)
        Me.TXB_Editor.TabIndex = 15
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(13, 322)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(83, 20)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Bearbeiter"
        '
        'TXB_Art
        '
        Me.TXB_Art.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXB_Art.Location = New System.Drawing.Point(13, 293)
        Me.TXB_Art.Name = "TXB_Art"
        Me.TXB_Art.ReadOnly = True
        Me.TXB_Art.Size = New System.Drawing.Size(395, 26)
        Me.TXB_Art.TabIndex = 13
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(13, 270)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(30, 20)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Art"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(13, 374)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(91, 20)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Kommentar"
        '
        'TXB_Price
        '
        Me.TXB_Price.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXB_Price.Location = New System.Drawing.Point(13, 241)
        Me.TXB_Price.Name = "TXB_Price"
        Me.TXB_Price.ReadOnly = True
        Me.TXB_Price.Size = New System.Drawing.Size(395, 26)
        Me.TXB_Price.TabIndex = 9
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(13, 218)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(73, 20)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "Preis in €"
        '
        'RTB_Comment
        '
        Me.RTB_Comment.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RTB_Comment.Location = New System.Drawing.Point(13, 397)
        Me.RTB_Comment.Name = "RTB_Comment"
        Me.RTB_Comment.ReadOnly = True
        Me.RTB_Comment.Size = New System.Drawing.Size(395, 189)
        Me.RTB_Comment.TabIndex = 16
        Me.RTB_Comment.Text = ""
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.BackColor = System.Drawing.Color.White
        Me.FlowLayoutPanel1.Controls.Add(Me.Label1)
        Me.FlowLayoutPanel1.Controls.Add(Me.TXB_Licenseplate)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label2)
        Me.FlowLayoutPanel1.Controls.Add(Me.TXB_Designation)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label3)
        Me.FlowLayoutPanel1.Controls.Add(Me.TXB_Millage)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label4)
        Me.FlowLayoutPanel1.Controls.Add(Me.TXB_Date)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label8)
        Me.FlowLayoutPanel1.Controls.Add(Me.TXB_Price)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label6)
        Me.FlowLayoutPanel1.Controls.Add(Me.TXB_Art)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label5)
        Me.FlowLayoutPanel1.Controls.Add(Me.TXB_Editor)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label7)
        Me.FlowLayoutPanel1.Controls.Add(Me.RTB_Comment)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label9)
        Me.FlowLayoutPanel1.Controls.Add(Me.ListBox1)
        Me.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(12, 12)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Padding = New System.Windows.Forms.Padding(10, 10, 0, 5)
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(427, 897)
        Me.FlowLayoutPanel1.TabIndex = 17
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(13, 589)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(139, 20)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "Verknüpfte Datein"
        '
        'ListBox1
        '
        Me.ListBox1.ContextMenuStrip = Me.CMS_LB_LinkedData
        Me.ListBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 20
        Me.ListBox1.Location = New System.Drawing.Point(13, 612)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(395, 264)
        Me.ListBox1.TabIndex = 18
        '
        'PB_Preview
        '
        Me.PB_Preview.Location = New System.Drawing.Point(611, 12)
        Me.PB_Preview.Name = "PB_Preview"
        Me.PB_Preview.Size = New System.Drawing.Size(569, 897)
        Me.PB_Preview.TabIndex = 18
        Me.PB_Preview.TabStop = False
        '
        'WB_Preview
        '
        Me.WB_Preview.Location = New System.Drawing.Point(611, 12)
        Me.WB_Preview.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WB_Preview.Name = "WB_Preview"
        Me.WB_Preview.Size = New System.Drawing.Size(569, 892)
        Me.WB_Preview.TabIndex = 19
        Me.WB_Preview.Visible = False
        '
        'CMS_LB_LinkedData
        '
        Me.CMS_LB_LinkedData.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LöschenToolStripMenuItem})
        Me.CMS_LB_LinkedData.Name = "CMS_LB_LinkedData"
        Me.CMS_LB_LinkedData.Size = New System.Drawing.Size(187, 26)
        '
        'LöschenToolStripMenuItem
        '
        Me.LöschenToolStripMenuItem.Name = "LöschenToolStripMenuItem"
        Me.LöschenToolStripMenuItem.Size = New System.Drawing.Size(186, 22)
        Me.LöschenToolStripMenuItem.Text = "Verknüpfung löschen"
        '
        'ShowCompleteEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(451, 916)
        Me.Controls.Add(Me.WB_Preview)
        Me.Controls.Add(Me.PB_Preview)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ShowCompleteEntry"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Eintrag"
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        CType(Me.PB_Preview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CMS_LB_LinkedData.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents TXB_Licenseplate As TextBox
    Friend WithEvents TXB_Designation As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TXB_Millage As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TXB_Date As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TXB_Editor As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents TXB_Art As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents TXB_Price As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents RTB_Comment As RichTextBox
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents PB_Preview As PictureBox
    Friend WithEvents WB_Preview As WebBrowser
    Friend WithEvents Label9 As Label
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents CMS_LB_LinkedData As ContextMenuStrip
    Friend WithEvents LöschenToolStripMenuItem As ToolStripMenuItem
End Class
