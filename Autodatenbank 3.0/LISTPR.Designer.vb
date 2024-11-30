<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LISTPR
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LISTPR))
        Me.LB_PrNumbers = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LB_PRDesignation = New System.Windows.Forms.ListBox()
        Me.BTN_Refresh = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'LB_PrNumbers
        '
        Me.LB_PrNumbers.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LB_PrNumbers.FormattingEnabled = True
        Me.LB_PrNumbers.ItemHeight = 20
        Me.LB_PrNumbers.Location = New System.Drawing.Point(12, 49)
        Me.LB_PrNumbers.Name = "LB_PrNumbers"
        Me.LB_PrNumbers.Size = New System.Drawing.Size(190, 264)
        Me.LB_PrNumbers.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(98, 20)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Pr-Nummern"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(208, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(195, 20)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Pr-Nummern entschlüsselt"
        '
        'LB_PRDesignation
        '
        Me.LB_PRDesignation.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LB_PRDesignation.FormattingEnabled = True
        Me.LB_PRDesignation.ItemHeight = 20
        Me.LB_PRDesignation.Location = New System.Drawing.Point(208, 49)
        Me.LB_PRDesignation.Name = "LB_PRDesignation"
        Me.LB_PRDesignation.Size = New System.Drawing.Size(521, 264)
        Me.LB_PRDesignation.TabIndex = 2
        '
        'BTN_Refresh
        '
        Me.BTN_Refresh.BackgroundImage = CType(resources.GetObject("BTN_Refresh.BackgroundImage"), System.Drawing.Image)
        Me.BTN_Refresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BTN_Refresh.Location = New System.Drawing.Point(695, 12)
        Me.BTN_Refresh.Name = "BTN_Refresh"
        Me.BTN_Refresh.Size = New System.Drawing.Size(34, 31)
        Me.BTN_Refresh.TabIndex = 4
        Me.BTN_Refresh.UseVisualStyleBackColor = True
        '
        'LISTPR
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(744, 327)
        Me.Controls.Add(Me.BTN_Refresh)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.LB_PRDesignation)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LB_PrNumbers)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "LISTPR"
        Me.Text = "PR-Nummern auflisten"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LB_PrNumbers As ListBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents LB_PRDesignation As ListBox
    Friend WithEvents BTN_Refresh As Button
End Class
