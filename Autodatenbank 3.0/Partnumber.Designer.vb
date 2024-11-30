<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Partnumber
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Partnumber))
        Me.CBB_Brand = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TXB_PartNumber = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.LBL_Price = New System.Windows.Forms.Label()
        Me.LBL_Discription = New System.Windows.Forms.Label()
        Me.RTB_ProductDiscription = New System.Windows.Forms.RichTextBox()
        Me.BTN_SearchPartNumber = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CBB_Brand
        '
        Me.CBB_Brand.AutoCompleteCustomSource.AddRange(New String() {"Volkswagen", "Audi", "Seat", "Skoda"})
        Me.CBB_Brand.FormattingEnabled = True
        Me.CBB_Brand.Items.AddRange(New Object() {"Volkswagen", "Audi", "Seat", "Skoda"})
        Me.CBB_Brand.Location = New System.Drawing.Point(15, 35)
        Me.CBB_Brand.Name = "CBB_Brand"
        Me.CBB_Brand.Size = New System.Drawing.Size(317, 21)
        Me.CBB_Brand.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(102, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Hersteller auswähle:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 73)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Teilenummer:"
        '
        'TXB_PartNumber
        '
        Me.TXB_PartNumber.Location = New System.Drawing.Point(15, 90)
        Me.TXB_PartNumber.Name = "TXB_PartNumber"
        Me.TXB_PartNumber.Size = New System.Drawing.Size(317, 20)
        Me.TXB_PartNumber.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 140)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Bezeichnung"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(15, 162)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(30, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Preis"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(15, 185)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(108, 13)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Produktbeschreibung"
        '
        'LBL_Price
        '
        Me.LBL_Price.AutoSize = True
        Me.LBL_Price.Location = New System.Drawing.Point(130, 162)
        Me.LBL_Price.Name = "LBL_Price"
        Me.LBL_Price.Size = New System.Drawing.Size(0, 13)
        Me.LBL_Price.TabIndex = 8
        '
        'LBL_Discription
        '
        Me.LBL_Discription.AutoSize = True
        Me.LBL_Discription.Location = New System.Drawing.Point(130, 140)
        Me.LBL_Discription.Name = "LBL_Discription"
        Me.LBL_Discription.Size = New System.Drawing.Size(0, 13)
        Me.LBL_Discription.TabIndex = 7
        '
        'RTB_ProductDiscription
        '
        Me.RTB_ProductDiscription.Location = New System.Drawing.Point(18, 201)
        Me.RTB_ProductDiscription.Name = "RTB_ProductDiscription"
        Me.RTB_ProductDiscription.Size = New System.Drawing.Size(473, 112)
        Me.RTB_ProductDiscription.TabIndex = 9
        Me.RTB_ProductDiscription.Text = ""
        '
        'BTN_SearchPartNumber
        '
        Me.BTN_SearchPartNumber.Location = New System.Drawing.Point(257, 116)
        Me.BTN_SearchPartNumber.Name = "BTN_SearchPartNumber"
        Me.BTN_SearchPartNumber.Size = New System.Drawing.Size(75, 23)
        Me.BTN_SearchPartNumber.TabIndex = 11
        Me.BTN_SearchPartNumber.Text = "Suchen"
        Me.BTN_SearchPartNumber.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(363, 35)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(128, 128)
        Me.PictureBox1.TabIndex = 10
        Me.PictureBox1.TabStop = False
        '
        'Partnumber
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(535, 331)
        Me.Controls.Add(Me.BTN_SearchPartNumber)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.RTB_ProductDiscription)
        Me.Controls.Add(Me.LBL_Price)
        Me.Controls.Add(Me.LBL_Discription)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TXB_PartNumber)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CBB_Brand)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Partnumber"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Teilenummern"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents CBB_Brand As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TXB_PartNumber As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents LBL_Price As Label
    Friend WithEvents LBL_Discription As Label
    Friend WithEvents RTB_ProductDiscription As RichTextBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents BTN_SearchPartNumber As Button
End Class
