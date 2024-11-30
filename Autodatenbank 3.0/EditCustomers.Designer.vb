<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class EditCustomers
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EditCustomers))
        Me.TXB_Email = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TXB_Fon = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TXB_City = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TXB_ZIP = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TXB_Street = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CBB_Customer = New System.Windows.Forms.ComboBox()
        Me.BTN_Save = New System.Windows.Forms.Button()
        Me.BTN_DeleteUser = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'TXB_Email
        '
        Me.TXB_Email.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXB_Email.Location = New System.Drawing.Point(25, 302)
        Me.TXB_Email.Name = "TXB_Email"
        Me.TXB_Email.Size = New System.Drawing.Size(320, 26)
        Me.TXB_Email.TabIndex = 31
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(22, 286)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(32, 13)
        Me.Label7.TabIndex = 30
        Me.Label7.Text = "Email"
        '
        'TXB_Fon
        '
        Me.TXB_Fon.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXB_Fon.Location = New System.Drawing.Point(25, 250)
        Me.TXB_Fon.Name = "TXB_Fon"
        Me.TXB_Fon.Size = New System.Drawing.Size(320, 26)
        Me.TXB_Fon.TabIndex = 29
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(22, 234)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(80, 13)
        Me.Label6.TabIndex = 28
        Me.Label6.Text = "Telefonnummer"
        '
        'TXB_City
        '
        Me.TXB_City.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXB_City.Location = New System.Drawing.Point(25, 196)
        Me.TXB_City.Name = "TXB_City"
        Me.TXB_City.Size = New System.Drawing.Size(320, 26)
        Me.TXB_City.TabIndex = 27
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(22, 180)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(21, 13)
        Me.Label5.TabIndex = 26
        Me.Label5.Text = "Ort"
        '
        'TXB_ZIP
        '
        Me.TXB_ZIP.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXB_ZIP.Location = New System.Drawing.Point(25, 146)
        Me.TXB_ZIP.Name = "TXB_ZIP"
        Me.TXB_ZIP.Size = New System.Drawing.Size(320, 26)
        Me.TXB_ZIP.TabIndex = 25
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(22, 130)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 13)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "Postleitzahl"
        '
        'TXB_Street
        '
        Me.TXB_Street.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXB_Street.Location = New System.Drawing.Point(25, 95)
        Me.TXB_Street.Name = "TXB_Street"
        Me.TXB_Street.Size = New System.Drawing.Size(320, 26)
        Me.TXB_Street.TabIndex = 23
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(22, 79)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(124, 13)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "Straße und Hausnummer"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(108, 13)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Vor- und Nachnamen"
        '
        'CBB_Customer
        '
        Me.CBB_Customer.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBB_Customer.FormattingEnabled = True
        Me.CBB_Customer.Location = New System.Drawing.Point(25, 39)
        Me.CBB_Customer.Name = "CBB_Customer"
        Me.CBB_Customer.Size = New System.Drawing.Size(320, 28)
        Me.CBB_Customer.TabIndex = 33
        '
        'BTN_Save
        '
        Me.BTN_Save.BackColor = System.Drawing.Color.LightGray
        Me.BTN_Save.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!)
        Me.BTN_Save.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.BTN_Save.Location = New System.Drawing.Point(25, 343)
        Me.BTN_Save.Name = "BTN_Save"
        Me.BTN_Save.Size = New System.Drawing.Size(320, 63)
        Me.BTN_Save.TabIndex = 34
        Me.BTN_Save.Text = "Änderung speichern"
        Me.BTN_Save.UseVisualStyleBackColor = False
        '
        'BTN_DeleteUser
        '
        Me.BTN_DeleteUser.BackColor = System.Drawing.Color.LightGray
        Me.BTN_DeleteUser.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!)
        Me.BTN_DeleteUser.ForeColor = System.Drawing.Color.Red
        Me.BTN_DeleteUser.Location = New System.Drawing.Point(25, 412)
        Me.BTN_DeleteUser.Name = "BTN_DeleteUser"
        Me.BTN_DeleteUser.Size = New System.Drawing.Size(320, 63)
        Me.BTN_DeleteUser.TabIndex = 35
        Me.BTN_DeleteUser.Text = "Löschen"
        Me.BTN_DeleteUser.UseVisualStyleBackColor = False
        '
        'EditCustomers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(367, 485)
        Me.Controls.Add(Me.BTN_DeleteUser)
        Me.Controls.Add(Me.BTN_Save)
        Me.Controls.Add(Me.CBB_Customer)
        Me.Controls.Add(Me.TXB_Email)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TXB_Fon)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TXB_City)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TXB_ZIP)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TXB_Street)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "EditCustomers"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Kunde bearbeiten"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TXB_Email As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents TXB_Fon As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents TXB_City As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents TXB_ZIP As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TXB_Street As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents CBB_Customer As ComboBox
    Friend WithEvents BTN_Save As Button
    Friend WithEvents BTN_DeleteUser As Button
End Class
