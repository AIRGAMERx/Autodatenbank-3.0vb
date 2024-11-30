<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class KeyNumbers
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(KeyNumbers))
        Me.TXB_KeyNumber = New System.Windows.Forms.TextBox()
        Me.BTN_Search = New System.Windows.Forms.Button()
        Me.LBL_HSNTSN = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lbl_displacement = New System.Windows.Forms.Label()
        Me.lbl_power = New System.Windows.Forms.Label()
        Me.lbl_model = New System.Windows.Forms.Label()
        Me.lbl_brand = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'TXB_KeyNumber
        '
        Me.TXB_KeyNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXB_KeyNumber.Location = New System.Drawing.Point(12, 37)
        Me.TXB_KeyNumber.Name = "TXB_KeyNumber"
        Me.TXB_KeyNumber.Size = New System.Drawing.Size(338, 26)
        Me.TXB_KeyNumber.TabIndex = 0
        '
        'BTN_Search
        '
        Me.BTN_Search.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_Search.Location = New System.Drawing.Point(356, 37)
        Me.BTN_Search.Name = "BTN_Search"
        Me.BTN_Search.Size = New System.Drawing.Size(95, 26)
        Me.BTN_Search.TabIndex = 1
        Me.BTN_Search.Text = "Suchen"
        Me.BTN_Search.UseVisualStyleBackColor = True
        '
        'LBL_HSNTSN
        '
        Me.LBL_HSNTSN.AutoSize = True
        Me.LBL_HSNTSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_HSNTSN.Location = New System.Drawing.Point(12, 14)
        Me.LBL_HSNTSN.Name = "LBL_HSNTSN"
        Me.LBL_HSNTSN.Size = New System.Drawing.Size(79, 20)
        Me.LBL_HSNTSN.TabIndex = 2
        Me.LBL_HSNTSN.Text = "HSN-TSN"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 89)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 20)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Marke"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 118)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 20)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Model"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 177)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 20)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Hubraum"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 148)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 20)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Leistung"
        '
        'lbl_displacement
        '
        Me.lbl_displacement.AutoSize = True
        Me.lbl_displacement.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_displacement.Location = New System.Drawing.Point(155, 177)
        Me.lbl_displacement.Name = "lbl_displacement"
        Me.lbl_displacement.Size = New System.Drawing.Size(0, 20)
        Me.lbl_displacement.TabIndex = 10
        '
        'lbl_power
        '
        Me.lbl_power.AutoSize = True
        Me.lbl_power.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_power.Location = New System.Drawing.Point(155, 148)
        Me.lbl_power.Name = "lbl_power"
        Me.lbl_power.Size = New System.Drawing.Size(0, 20)
        Me.lbl_power.TabIndex = 9
        '
        'lbl_model
        '
        Me.lbl_model.AutoSize = True
        Me.lbl_model.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_model.Location = New System.Drawing.Point(155, 118)
        Me.lbl_model.Name = "lbl_model"
        Me.lbl_model.Size = New System.Drawing.Size(0, 20)
        Me.lbl_model.TabIndex = 8
        '
        'lbl_brand
        '
        Me.lbl_brand.AutoSize = True
        Me.lbl_brand.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_brand.Location = New System.Drawing.Point(155, 89)
        Me.lbl_brand.Name = "lbl_brand"
        Me.lbl_brand.Size = New System.Drawing.Size(0, 20)
        Me.lbl_brand.TabIndex = 7
        '
        'KeyNumbers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(478, 211)
        Me.Controls.Add(Me.lbl_displacement)
        Me.Controls.Add(Me.lbl_power)
        Me.Controls.Add(Me.lbl_model)
        Me.Controls.Add(Me.lbl_brand)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LBL_HSNTSN)
        Me.Controls.Add(Me.BTN_Search)
        Me.Controls.Add(Me.TXB_KeyNumber)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "KeyNumbers"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Auto nach Schlüsselnummer suchen"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TXB_KeyNumber As TextBox
    Friend WithEvents BTN_Search As Button
    Friend WithEvents LBL_HSNTSN As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents lbl_displacement As Label
    Friend WithEvents lbl_power As Label
    Friend WithEvents lbl_model As Label
    Friend WithEvents lbl_brand As Label
End Class
