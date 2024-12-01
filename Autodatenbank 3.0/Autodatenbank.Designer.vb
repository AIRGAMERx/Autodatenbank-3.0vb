<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Autodatenbank
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Autodatenbank))
        Me.dgv = New System.Windows.Forms.DataGridView()
        Me.DatabaseMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EintragAnzeigenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_Eintrag_Bearbeiten = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_Eintrag_Loeschen = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_Bericht_erstellen = New System.Windows.Forms.ToolStripMenuItem()
        Me.dgv2 = New System.Windows.Forms.DataGridView()
        Me.FTPMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.TSMI_Datei_Oeffnen = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_Datei_Loeschen = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_LINK = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_Service = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_Repair = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_Other = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.TSL_Neues_Auto = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.LBL_NewCustomer = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.LBL_NewEntry = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.TSMI_MyCar = New System.Windows.Forms.ToolStripLabel()
        Me.LBL_Logout = New System.Windows.Forms.ToolStripLabel()
        Me.LBL_Login = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.BTN_CreateReport = New System.Windows.Forms.Button()
        Me.lbl_CreateReport = New System.Windows.Forms.Label()
        Me.FLP_Main = New System.Windows.Forms.FlowLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CBB_SavedCars = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TXB_Brand = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TXB_Model = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TXB_LicensePlate = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TXB_Motorcode = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TXB_Displacement = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TXB_Power = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TXB_VIN = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TXB_ConstructionYear = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TXB_KeyNumber = New System.Windows.Forms.TextBox()
        Me.TLP_Main1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TXB_Owner = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TXB_BuyDate = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TXB_Price = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.CBB_NextInspectionYear = New System.Windows.Forms.ComboBox()
        Me.CBB_NextInspectionMonth = New System.Windows.Forms.ComboBox()
        Me.BTN_ShowPRNumbers = New System.Windows.Forms.Button()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.RTB_Infos = New System.Windows.Forms.RichTextBox()
        Me.BTN_SaveCarData = New System.Windows.Forms.Button()
        Me.BTN_DeleteCarData = New System.Windows.Forms.Button()
        Me.NI_InspectionDate = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.NI_Successful = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.NI_Error = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.PB_Adressbook = New System.Windows.Forms.PictureBox()
        Me.TSB_UploadFile = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripDropDownButton2 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.EinträgeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TeilenummernToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InfoZuSchlüsselnummerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PRNummerEntschlüsselnToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LBL_EditCustomer = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripDropDownButton1 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.TSMI_Server_Verbindungen = New System.Windows.Forms.ToolStripMenuItem()
        Me.NachUpdateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_Admin = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_Bericht_Einstellungen = New System.Windows.Forms.ToolStripMenuItem()
        Me.AnsichtToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_LogFile_Oeffnen = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSM_Benutzer = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSM_Benutzer_Erstellen = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSM_Benutzer_Bearbeiten = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSB_Issue = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripDropDownButton3 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.TSMI_Checklistedit = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSMI_ChecklistOpen = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.DatabaseMenuStrip.SuspendLayout()
        CType(Me.dgv2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FTPMenuStrip.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.FLP_Main.SuspendLayout()
        Me.TLP_Main1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.PB_Adressbook, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgv
        '
        Me.dgv.AllowUserToAddRows = False
        Me.dgv.AllowUserToDeleteRows = False
        Me.dgv.BackgroundColor = System.Drawing.Color.White
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.ContextMenuStrip = Me.DatabaseMenuStrip
        Me.dgv.Location = New System.Drawing.Point(333, 62)
        Me.dgv.Name = "dgv"
        Me.dgv.Size = New System.Drawing.Size(1239, 524)
        Me.dgv.TabIndex = 4
        '
        'DatabaseMenuStrip
        '
        Me.DatabaseMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EintragAnzeigenToolStripMenuItem, Me.TSMI_Eintrag_Bearbeiten, Me.TSMI_Eintrag_Loeschen, Me.TSMI_Bericht_erstellen})
        Me.DatabaseMenuStrip.Name = "DatabaseMenuStrip"
        Me.DatabaseMenuStrip.Size = New System.Drawing.Size(162, 92)
        '
        'EintragAnzeigenToolStripMenuItem
        '
        Me.EintragAnzeigenToolStripMenuItem.Name = "EintragAnzeigenToolStripMenuItem"
        Me.EintragAnzeigenToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.EintragAnzeigenToolStripMenuItem.Text = "Eintrag anzeigen"
        '
        'TSMI_Eintrag_Bearbeiten
        '
        Me.TSMI_Eintrag_Bearbeiten.Name = "TSMI_Eintrag_Bearbeiten"
        Me.TSMI_Eintrag_Bearbeiten.Size = New System.Drawing.Size(161, 22)
        Me.TSMI_Eintrag_Bearbeiten.Text = "Bearbeiten"
        '
        'TSMI_Eintrag_Loeschen
        '
        Me.TSMI_Eintrag_Loeschen.Name = "TSMI_Eintrag_Loeschen"
        Me.TSMI_Eintrag_Loeschen.Size = New System.Drawing.Size(161, 22)
        Me.TSMI_Eintrag_Loeschen.Text = "Löschen"
        '
        'TSMI_Bericht_erstellen
        '
        Me.TSMI_Bericht_erstellen.Name = "TSMI_Bericht_erstellen"
        Me.TSMI_Bericht_erstellen.Size = New System.Drawing.Size(161, 22)
        Me.TSMI_Bericht_erstellen.Text = "Bericht erstellen"
        '
        'dgv2
        '
        Me.dgv2.AllowUserToAddRows = False
        Me.dgv2.AllowUserToDeleteRows = False
        Me.dgv2.BackgroundColor = System.Drawing.Color.White
        Me.dgv2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv2.ContextMenuStrip = Me.FTPMenuStrip
        Me.dgv2.Location = New System.Drawing.Point(333, 646)
        Me.dgv2.Name = "dgv2"
        Me.dgv2.ReadOnly = True
        Me.dgv2.Size = New System.Drawing.Size(1239, 307)
        Me.dgv2.TabIndex = 5
        '
        'FTPMenuStrip
        '
        Me.FTPMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSMI_Datei_Oeffnen, Me.TSMI_Datei_Loeschen, Me.TSMI_LINK})
        Me.FTPMenuStrip.Name = "FTPMenuStrip"
        Me.FTPMenuStrip.Size = New System.Drawing.Size(135, 70)
        '
        'TSMI_Datei_Oeffnen
        '
        Me.TSMI_Datei_Oeffnen.Name = "TSMI_Datei_Oeffnen"
        Me.TSMI_Datei_Oeffnen.Size = New System.Drawing.Size(134, 22)
        Me.TSMI_Datei_Oeffnen.Text = "Öffnen"
        '
        'TSMI_Datei_Loeschen
        '
        Me.TSMI_Datei_Loeschen.Name = "TSMI_Datei_Loeschen"
        Me.TSMI_Datei_Loeschen.Size = New System.Drawing.Size(134, 22)
        Me.TSMI_Datei_Loeschen.Text = "Löschen"
        '
        'TSMI_LINK
        '
        Me.TSMI_LINK.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSMI_Service, Me.TSMI_Repair, Me.TSMI_Other})
        Me.TSMI_LINK.Name = "TSMI_LINK"
        Me.TSMI_LINK.Size = New System.Drawing.Size(134, 22)
        Me.TSMI_LINK.Text = "Verknüpfen"
        '
        'TSMI_Service
        '
        Me.TSMI_Service.Name = "TSMI_Service"
        Me.TSMI_Service.Size = New System.Drawing.Size(162, 22)
        Me.TSMI_Service.Text = "Wartung/Service"
        '
        'TSMI_Repair
        '
        Me.TSMI_Repair.Name = "TSMI_Repair"
        Me.TSMI_Repair.Size = New System.Drawing.Size(162, 22)
        Me.TSMI_Repair.Text = "Reparatur"
        '
        'TSMI_Other
        '
        Me.TSMI_Other.Name = "TSMI_Other"
        Me.TSMI_Other.Size = New System.Drawing.Size(162, 22)
        Me.TSMI_Other.Text = "Sonstiges"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(333, 625)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(184, 13)
        Me.Label15.TabIndex = 6
        Me.Label15.Text = "Gespeicherte Dokumente, Bilder etc.."
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(330, 41)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(165, 13)
        Me.Label16.TabIndex = 7
        Me.Label16.Text = "Wartung, Reparaturen, Sonstiges"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSL_Neues_Auto, Me.ToolStripSeparator2, Me.LBL_NewCustomer, Me.ToolStripSeparator5, Me.LBL_NewEntry, Me.ToolStripSeparator1, Me.TSB_UploadFile, Me.ToolStripSeparator3, Me.ToolStripDropDownButton2, Me.ToolStripSeparator9, Me.LBL_EditCustomer, Me.TSMI_MyCar, Me.LBL_Logout, Me.LBL_Login, Me.ToolStripSeparator6, Me.ToolStripDropDownButton1, Me.ToolStripSeparator7, Me.TSB_Issue, Me.ToolStripSeparator8, Me.ToolStripDropDownButton3})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1584, 25)
        Me.ToolStrip1.TabIndex = 9
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'TSL_Neues_Auto
        '
        Me.TSL_Neues_Auto.Name = "TSL_Neues_Auto"
        Me.TSL_Neues_Auto.Size = New System.Drawing.Size(114, 22)
        Me.TSL_Neues_Auto.Text = "Neues Auto anlegen"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'LBL_NewCustomer
        '
        Me.LBL_NewCustomer.Name = "LBL_NewCustomer"
        Me.LBL_NewCustomer.Size = New System.Drawing.Size(131, 22)
        Me.LBL_NewCustomer.Text = "Neuen Kunden anlegen"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'LBL_NewEntry
        '
        Me.LBL_NewEntry.Enabled = False
        Me.LBL_NewEntry.Name = "LBL_NewEntry"
        Me.LBL_NewEntry.Size = New System.Drawing.Size(129, 22)
        Me.LBL_NewEntry.Text = "Neuen Eintrag erstellen"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(6, 25)
        '
        'TSMI_MyCar
        '
        Me.TSMI_MyCar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.TSMI_MyCar.Name = "TSMI_MyCar"
        Me.TSMI_MyCar.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TSMI_MyCar.Size = New System.Drawing.Size(63, 22)
        Me.TSMI_MyCar.Text = "Mein Auto"
        '
        'LBL_Logout
        '
        Me.LBL_Logout.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.LBL_Logout.Name = "LBL_Logout"
        Me.LBL_Logout.Padding = New System.Windows.Forms.Padding(0, 0, 7, 0)
        Me.LBL_Logout.Size = New System.Drawing.Size(72, 22)
        Me.LBL_Logout.Text = " Abmelden"
        Me.LBL_Logout.Visible = False
        '
        'LBL_Login
        '
        Me.LBL_Login.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.LBL_Login.Name = "LBL_Login"
        Me.LBL_Login.Padding = New System.Windows.Forms.Padding(0, 0, 7, 0)
        Me.LBL_Login.Size = New System.Drawing.Size(69, 22)
        Me.LBL_Login.Text = "Anmelden"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 25)
        '
        'BTN_CreateReport
        '
        Me.BTN_CreateReport.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.BTN_CreateReport.Location = New System.Drawing.Point(1466, 612)
        Me.BTN_CreateReport.Name = "BTN_CreateReport"
        Me.BTN_CreateReport.Size = New System.Drawing.Size(106, 23)
        Me.BTN_CreateReport.TabIndex = 11
        Me.BTN_CreateReport.Text = "Bericht erstellen"
        Me.BTN_CreateReport.UseVisualStyleBackColor = True
        Me.BTN_CreateReport.Visible = False
        '
        'lbl_CreateReport
        '
        Me.lbl_CreateReport.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_CreateReport.AutoSize = True
        Me.lbl_CreateReport.Location = New System.Drawing.Point(1416, 593)
        Me.lbl_CreateReport.Name = "lbl_CreateReport"
        Me.lbl_CreateReport.Padding = New System.Windows.Forms.Padding(0, 0, 5, 0)
        Me.lbl_CreateReport.Size = New System.Drawing.Size(156, 13)
        Me.lbl_CreateReport.TabIndex = 12
        Me.lbl_CreateReport.Text = "Einträge für Bericht auswählen"
        Me.lbl_CreateReport.Visible = False
        '
        'FLP_Main
        '
        Me.FLP_Main.AutoSize = True
        Me.FLP_Main.BackColor = System.Drawing.Color.White
        Me.FLP_Main.Controls.Add(Me.Label1)
        Me.FLP_Main.Controls.Add(Me.CBB_SavedCars)
        Me.FLP_Main.Controls.Add(Me.Label2)
        Me.FLP_Main.Controls.Add(Me.TXB_Brand)
        Me.FLP_Main.Controls.Add(Me.Label3)
        Me.FLP_Main.Controls.Add(Me.TXB_Model)
        Me.FLP_Main.Controls.Add(Me.Label5)
        Me.FLP_Main.Controls.Add(Me.TXB_LicensePlate)
        Me.FLP_Main.Controls.Add(Me.Label4)
        Me.FLP_Main.Controls.Add(Me.TXB_Motorcode)
        Me.FLP_Main.Controls.Add(Me.Label9)
        Me.FLP_Main.Controls.Add(Me.TXB_Displacement)
        Me.FLP_Main.Controls.Add(Me.Label8)
        Me.FLP_Main.Controls.Add(Me.TXB_Power)
        Me.FLP_Main.Controls.Add(Me.Label7)
        Me.FLP_Main.Controls.Add(Me.TXB_VIN)
        Me.FLP_Main.Controls.Add(Me.Label6)
        Me.FLP_Main.Controls.Add(Me.TXB_ConstructionYear)
        Me.FLP_Main.Controls.Add(Me.Label13)
        Me.FLP_Main.Controls.Add(Me.TXB_KeyNumber)
        Me.FLP_Main.Controls.Add(Me.TLP_Main1)
        Me.FLP_Main.Controls.Add(Me.TXB_Owner)
        Me.FLP_Main.Controls.Add(Me.Label11)
        Me.FLP_Main.Controls.Add(Me.TXB_BuyDate)
        Me.FLP_Main.Controls.Add(Me.Label10)
        Me.FLP_Main.Controls.Add(Me.TXB_Price)
        Me.FLP_Main.Controls.Add(Me.Label17)
        Me.FLP_Main.Controls.Add(Me.TableLayoutPanel1)
        Me.FLP_Main.Controls.Add(Me.BTN_ShowPRNumbers)
        Me.FLP_Main.Controls.Add(Me.Label14)
        Me.FLP_Main.Controls.Add(Me.RTB_Infos)
        Me.FLP_Main.Controls.Add(Me.BTN_SaveCarData)
        Me.FLP_Main.Controls.Add(Me.BTN_DeleteCarData)
        Me.FLP_Main.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.FLP_Main.Location = New System.Drawing.Point(0, 23)
        Me.FLP_Main.Margin = New System.Windows.Forms.Padding(0, 5, 0, 5)
        Me.FLP_Main.Name = "FLP_Main"
        Me.FLP_Main.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.FLP_Main.Size = New System.Drawing.Size(292, 963)
        Me.FLP_Main.TabIndex = 13
        Me.FLP_Main.WrapContents = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 16)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Auto auswählen"
        '
        'CBB_SavedCars
        '
        Me.CBB_SavedCars.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBB_SavedCars.FormattingEnabled = True
        Me.CBB_SavedCars.Location = New System.Drawing.Point(13, 39)
        Me.CBB_SavedCars.Name = "CBB_SavedCars"
        Me.CBB_SavedCars.Size = New System.Drawing.Size(266, 24)
        Me.CBB_SavedCars.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
        Me.Label2.Size = New System.Drawing.Size(37, 16)
        Me.Label2.TabIndex = 27
        Me.Label2.Text = "Marke"
        '
        'TXB_Brand
        '
        Me.TXB_Brand.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXB_Brand.Location = New System.Drawing.Point(13, 85)
        Me.TXB_Brand.Name = "TXB_Brand"
        Me.TXB_Brand.Size = New System.Drawing.Size(264, 22)
        Me.TXB_Brand.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 110)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 13)
        Me.Label3.TabIndex = 29
        Me.Label3.Text = "Model"
        '
        'TXB_Model
        '
        Me.TXB_Model.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXB_Model.Location = New System.Drawing.Point(13, 126)
        Me.TXB_Model.Name = "TXB_Model"
        Me.TXB_Model.Size = New System.Drawing.Size(264, 22)
        Me.TXB_Model.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(13, 151)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(69, 13)
        Me.Label5.TabIndex = 33
        Me.Label5.Text = "Kennzeichen"
        '
        'TXB_LicensePlate
        '
        Me.TXB_LicensePlate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXB_LicensePlate.Location = New System.Drawing.Point(13, 167)
        Me.TXB_LicensePlate.Name = "TXB_LicensePlate"
        Me.TXB_LicensePlate.ReadOnly = True
        Me.TXB_LicensePlate.Size = New System.Drawing.Size(264, 22)
        Me.TXB_LicensePlate.TabIndex = 31
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 192)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(137, 13)
        Me.Label4.TabIndex = 35
        Me.Label4.Text = "Motorkennbuchstabe(MKB)"
        '
        'TXB_Motorcode
        '
        Me.TXB_Motorcode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXB_Motorcode.Location = New System.Drawing.Point(13, 208)
        Me.TXB_Motorcode.Name = "TXB_Motorcode"
        Me.TXB_Motorcode.Size = New System.Drawing.Size(264, 22)
        Me.TXB_Motorcode.TabIndex = 4
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(13, 233)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(84, 13)
        Me.Label9.TabIndex = 38
        Me.Label9.Text = "Hubraum in ccm"
        '
        'TXB_Displacement
        '
        Me.TXB_Displacement.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXB_Displacement.Location = New System.Drawing.Point(13, 249)
        Me.TXB_Displacement.Name = "TXB_Displacement"
        Me.TXB_Displacement.Size = New System.Drawing.Size(264, 22)
        Me.TXB_Displacement.TabIndex = 5
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(13, 274)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(75, 13)
        Me.Label8.TabIndex = 42
        Me.Label8.Text = "Leistung in PS"
        '
        'TXB_Power
        '
        Me.TXB_Power.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXB_Power.Location = New System.Drawing.Point(13, 290)
        Me.TXB_Power.Name = "TXB_Power"
        Me.TXB_Power.Size = New System.Drawing.Size(264, 22)
        Me.TXB_Power.TabIndex = 6
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(13, 315)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(24, 13)
        Me.Label7.TabIndex = 44
        Me.Label7.Text = "FIN"
        '
        'TXB_VIN
        '
        Me.TXB_VIN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXB_VIN.Location = New System.Drawing.Point(13, 331)
        Me.TXB_VIN.Name = "TXB_VIN"
        Me.TXB_VIN.Size = New System.Drawing.Size(264, 22)
        Me.TXB_VIN.TabIndex = 7
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(13, 356)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(43, 13)
        Me.Label6.TabIndex = 46
        Me.Label6.Text = "Baujahr"
        '
        'TXB_ConstructionYear
        '
        Me.TXB_ConstructionYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXB_ConstructionYear.Location = New System.Drawing.Point(13, 372)
        Me.TXB_ConstructionYear.Name = "TXB_ConstructionYear"
        Me.TXB_ConstructionYear.Size = New System.Drawing.Size(264, 22)
        Me.TXB_ConstructionYear.TabIndex = 8
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(13, 397)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(148, 13)
        Me.Label13.TabIndex = 47
        Me.Label13.Text = "HSN/TSN (Schlüsselnummer)"
        '
        'TXB_KeyNumber
        '
        Me.TXB_KeyNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXB_KeyNumber.Location = New System.Drawing.Point(13, 413)
        Me.TXB_KeyNumber.Name = "TXB_KeyNumber"
        Me.TXB_KeyNumber.Size = New System.Drawing.Size(264, 22)
        Me.TXB_KeyNumber.TabIndex = 9
        '
        'TLP_Main1
        '
        Me.TLP_Main1.ColumnCount = 2
        Me.TLP_Main1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TLP_Main1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TLP_Main1.Controls.Add(Me.Label12, 0, 0)
        Me.TLP_Main1.Controls.Add(Me.PB_Adressbook, 1, 0)
        Me.TLP_Main1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize
        Me.TLP_Main1.Location = New System.Drawing.Point(10, 438)
        Me.TLP_Main1.Margin = New System.Windows.Forms.Padding(0, 0, 0, 5)
        Me.TLP_Main1.Name = "TLP_Main1"
        Me.TLP_Main1.Padding = New System.Windows.Forms.Padding(5, 0, 10, 0)
        Me.TLP_Main1.RowCount = 1
        Me.TLP_Main1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TLP_Main1.Size = New System.Drawing.Size(264, 25)
        Me.TLP_Main1.TabIndex = 48
        '
        'Label12
        '
        Me.Label12.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(8, 6)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(38, 13)
        Me.Label12.TabIndex = 48
        Me.Label12.Text = "Kunde"
        '
        'TXB_Owner
        '
        Me.TXB_Owner.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXB_Owner.Location = New System.Drawing.Point(13, 471)
        Me.TXB_Owner.Name = "TXB_Owner"
        Me.TXB_Owner.Size = New System.Drawing.Size(264, 22)
        Me.TXB_Owner.TabIndex = 10
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(13, 496)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(62, 13)
        Me.Label11.TabIndex = 49
        Me.Label11.Text = "Gekauft am"
        '
        'TXB_BuyDate
        '
        Me.TXB_BuyDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXB_BuyDate.Location = New System.Drawing.Point(13, 512)
        Me.TXB_BuyDate.Name = "TXB_BuyDate"
        Me.TXB_BuyDate.Size = New System.Drawing.Size(264, 22)
        Me.TXB_BuyDate.TabIndex = 11
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(13, 537)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(30, 13)
        Me.Label10.TabIndex = 50
        Me.Label10.Text = "Preis"
        '
        'TXB_Price
        '
        Me.TXB_Price.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXB_Price.Location = New System.Drawing.Point(13, 553)
        Me.TXB_Price.Name = "TXB_Price"
        Me.TXB_Price.Size = New System.Drawing.Size(264, 22)
        Me.TXB_Price.TabIndex = 12
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(13, 578)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(117, 13)
        Me.Label17.TabIndex = 55
        Me.Label17.Text = "Nächste HU/AU (TÜV)"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.CBB_NextInspectionYear, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.CBB_NextInspectionMonth, 0, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(13, 594)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(261, 32)
        Me.TableLayoutPanel1.TabIndex = 51
        '
        'CBB_NextInspectionYear
        '
        Me.CBB_NextInspectionYear.FormattingEnabled = True
        Me.CBB_NextInspectionYear.Location = New System.Drawing.Point(133, 3)
        Me.CBB_NextInspectionYear.Name = "CBB_NextInspectionYear"
        Me.CBB_NextInspectionYear.Size = New System.Drawing.Size(125, 21)
        Me.CBB_NextInspectionYear.TabIndex = 14
        '
        'CBB_NextInspectionMonth
        '
        Me.CBB_NextInspectionMonth.FormattingEnabled = True
        Me.CBB_NextInspectionMonth.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12"})
        Me.CBB_NextInspectionMonth.Location = New System.Drawing.Point(3, 3)
        Me.CBB_NextInspectionMonth.Name = "CBB_NextInspectionMonth"
        Me.CBB_NextInspectionMonth.Size = New System.Drawing.Size(124, 21)
        Me.CBB_NextInspectionMonth.TabIndex = 13
        Me.CBB_NextInspectionMonth.Text = "01"
        '
        'BTN_ShowPRNumbers
        '
        Me.BTN_ShowPRNumbers.Location = New System.Drawing.Point(13, 632)
        Me.BTN_ShowPRNumbers.Name = "BTN_ShowPRNumbers"
        Me.BTN_ShowPRNumbers.Size = New System.Drawing.Size(264, 39)
        Me.BTN_ShowPRNumbers.TabIndex = 15
        Me.BTN_ShowPRNumbers.Text = "PR-Nummern (VAG ONLY)"
        Me.BTN_ShowPRNumbers.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(13, 674)
        Me.Label14.Name = "Label14"
        Me.Label14.Padding = New System.Windows.Forms.Padding(0, 10, 0, 0)
        Me.Label14.Size = New System.Drawing.Size(115, 23)
        Me.Label14.TabIndex = 52
        Me.Label14.Text = "Sonstige Informationen"
        '
        'RTB_Infos
        '
        Me.RTB_Infos.Location = New System.Drawing.Point(13, 700)
        Me.RTB_Infos.Name = "RTB_Infos"
        Me.RTB_Infos.Size = New System.Drawing.Size(264, 119)
        Me.RTB_Infos.TabIndex = 16
        Me.RTB_Infos.Text = ""
        '
        'BTN_SaveCarData
        '
        Me.BTN_SaveCarData.Location = New System.Drawing.Point(13, 825)
        Me.BTN_SaveCarData.Name = "BTN_SaveCarData"
        Me.BTN_SaveCarData.Size = New System.Drawing.Size(264, 39)
        Me.BTN_SaveCarData.TabIndex = 17
        Me.BTN_SaveCarData.Text = "Änderung Speichern"
        Me.BTN_SaveCarData.UseVisualStyleBackColor = True
        '
        'BTN_DeleteCarData
        '
        Me.BTN_DeleteCarData.ForeColor = System.Drawing.Color.Red
        Me.BTN_DeleteCarData.Location = New System.Drawing.Point(13, 870)
        Me.BTN_DeleteCarData.Name = "BTN_DeleteCarData"
        Me.BTN_DeleteCarData.Size = New System.Drawing.Size(264, 36)
        Me.BTN_DeleteCarData.TabIndex = 18
        Me.BTN_DeleteCarData.Text = "Fahrzeug löschen"
        Me.BTN_DeleteCarData.UseVisualStyleBackColor = True
        '
        'NI_InspectionDate
        '
        Me.NI_InspectionDate.Icon = CType(resources.GetObject("NI_InspectionDate.Icon"), System.Drawing.Icon)
        Me.NI_InspectionDate.Text = "NotifyIcon1"
        '
        'NI_Successful
        '
        Me.NI_Successful.Icon = CType(resources.GetObject("NI_Successful.Icon"), System.Drawing.Icon)
        Me.NI_Successful.Text = "NotifyIcon1"
        '
        'NI_Error
        '
        Me.NI_Error.Icon = CType(resources.GetObject("NI_Error.Icon"), System.Drawing.Icon)
        Me.NI_Error.Text = "NotifyIcon1"
        Me.NI_Error.Visible = True
        '
        'PB_Adressbook
        '
        Me.PB_Adressbook.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.PB_Adressbook.BackgroundImage = Global.Autodatenbank_3._0.My.Resources.Resources.adressbook
        Me.PB_Adressbook.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PB_Adressbook.Location = New System.Drawing.Point(228, 3)
        Me.PB_Adressbook.Name = "PB_Adressbook"
        Me.PB_Adressbook.Size = New System.Drawing.Size(23, 20)
        Me.PB_Adressbook.TabIndex = 11
        Me.PB_Adressbook.TabStop = False
        '
        'TSB_UploadFile
        '
        Me.TSB_UploadFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TSB_UploadFile.Image = CType(resources.GetObject("TSB_UploadFile.Image"), System.Drawing.Image)
        Me.TSB_UploadFile.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSB_UploadFile.Name = "TSB_UploadFile"
        Me.TSB_UploadFile.Size = New System.Drawing.Size(23, 22)
        Me.TSB_UploadFile.Text = "Datei Hochladen"
        '
        'ToolStripDropDownButton2
        '
        Me.ToolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripDropDownButton2.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EinträgeToolStripMenuItem, Me.TeilenummernToolStripMenuItem, Me.InfoZuSchlüsselnummerToolStripMenuItem, Me.PRNummerEntschlüsselnToolStripMenuItem})
        Me.ToolStripDropDownButton2.Image = CType(resources.GetObject("ToolStripDropDownButton2.Image"), System.Drawing.Image)
        Me.ToolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton2.Name = "ToolStripDropDownButton2"
        Me.ToolStripDropDownButton2.Size = New System.Drawing.Size(29, 22)
        Me.ToolStripDropDownButton2.Text = "Suche"
        '
        'EinträgeToolStripMenuItem
        '
        Me.EinträgeToolStripMenuItem.Name = "EinträgeToolStripMenuItem"
        Me.EinträgeToolStripMenuItem.Size = New System.Drawing.Size(281, 22)
        Me.EinträgeToolStripMenuItem.Text = "Einträge"
        '
        'TeilenummernToolStripMenuItem
        '
        Me.TeilenummernToolStripMenuItem.Name = "TeilenummernToolStripMenuItem"
        Me.TeilenummernToolStripMenuItem.Size = New System.Drawing.Size(281, 22)
        Me.TeilenummernToolStripMenuItem.Text = "Teilenummern"
        '
        'InfoZuSchlüsselnummerToolStripMenuItem
        '
        Me.InfoZuSchlüsselnummerToolStripMenuItem.Name = "InfoZuSchlüsselnummerToolStripMenuItem"
        Me.InfoZuSchlüsselnummerToolStripMenuItem.Size = New System.Drawing.Size(281, 22)
        Me.InfoZuSchlüsselnummerToolStripMenuItem.Text = "Info zu Schlüsselnummer"
        '
        'PRNummerEntschlüsselnToolStripMenuItem
        '
        Me.PRNummerEntschlüsselnToolStripMenuItem.Name = "PRNummerEntschlüsselnToolStripMenuItem"
        Me.PRNummerEntschlüsselnToolStripMenuItem.Size = New System.Drawing.Size(281, 22)
        Me.PRNummerEntschlüsselnToolStripMenuItem.Text = "PR-Nummer entschlüsseln (VAG ONLY)"
        '
        'LBL_EditCustomer
        '
        Me.LBL_EditCustomer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.LBL_EditCustomer.Image = Global.Autodatenbank_3._0.My.Resources.Resources.adressbook
        Me.LBL_EditCustomer.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.LBL_EditCustomer.Name = "LBL_EditCustomer"
        Me.LBL_EditCustomer.Size = New System.Drawing.Size(23, 22)
        Me.LBL_EditCustomer.Text = "Kunden bearbeiten"
        '
        'ToolStripDropDownButton1
        '
        Me.ToolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripDropDownButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSMI_Server_Verbindungen, Me.NachUpdateToolStripMenuItem, Me.TSMI_Admin, Me.TSMI_Bericht_Einstellungen, Me.AnsichtToolStripMenuItem1, Me.TSMI_LogFile_Oeffnen, Me.TSM_Benutzer})
        Me.ToolStripDropDownButton1.Image = CType(resources.GetObject("ToolStripDropDownButton1.Image"), System.Drawing.Image)
        Me.ToolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton1.Name = "ToolStripDropDownButton1"
        Me.ToolStripDropDownButton1.Size = New System.Drawing.Size(29, 22)
        Me.ToolStripDropDownButton1.Text = "Einstellungen"
        '
        'TSMI_Server_Verbindungen
        '
        Me.TSMI_Server_Verbindungen.Name = "TSMI_Server_Verbindungen"
        Me.TSMI_Server_Verbindungen.Size = New System.Drawing.Size(225, 22)
        Me.TSMI_Server_Verbindungen.Text = "Server Verbindungen"
        '
        'NachUpdateToolStripMenuItem
        '
        Me.NachUpdateToolStripMenuItem.Name = "NachUpdateToolStripMenuItem"
        Me.NachUpdateToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.NachUpdateToolStripMenuItem.Text = "Nach Updates suchen"
        '
        'TSMI_Admin
        '
        Me.TSMI_Admin.Name = "TSMI_Admin"
        Me.TSMI_Admin.Size = New System.Drawing.Size(225, 22)
        Me.TSMI_Admin.Text = "Administrative Einstellungen"
        '
        'TSMI_Bericht_Einstellungen
        '
        Me.TSMI_Bericht_Einstellungen.Name = "TSMI_Bericht_Einstellungen"
        Me.TSMI_Bericht_Einstellungen.Size = New System.Drawing.Size(225, 22)
        Me.TSMI_Bericht_Einstellungen.Text = "Bericht"
        '
        'AnsichtToolStripMenuItem1
        '
        Me.AnsichtToolStripMenuItem1.Name = "AnsichtToolStripMenuItem1"
        Me.AnsichtToolStripMenuItem1.Size = New System.Drawing.Size(225, 22)
        Me.AnsichtToolStripMenuItem1.Text = "Ansicht"
        '
        'TSMI_LogFile_Oeffnen
        '
        Me.TSMI_LogFile_Oeffnen.Name = "TSMI_LogFile_Oeffnen"
        Me.TSMI_LogFile_Oeffnen.Size = New System.Drawing.Size(225, 22)
        Me.TSMI_LogFile_Oeffnen.Text = "LogFile öffnen"
        '
        'TSM_Benutzer
        '
        Me.TSM_Benutzer.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSM_Benutzer_Erstellen, Me.TSM_Benutzer_Bearbeiten})
        Me.TSM_Benutzer.Name = "TSM_Benutzer"
        Me.TSM_Benutzer.Size = New System.Drawing.Size(225, 22)
        Me.TSM_Benutzer.Text = "Benutzer"
        '
        'TSM_Benutzer_Erstellen
        '
        Me.TSM_Benutzer_Erstellen.Name = "TSM_Benutzer_Erstellen"
        Me.TSM_Benutzer_Erstellen.Size = New System.Drawing.Size(130, 22)
        Me.TSM_Benutzer_Erstellen.Text = "Erstellen"
        '
        'TSM_Benutzer_Bearbeiten
        '
        Me.TSM_Benutzer_Bearbeiten.Name = "TSM_Benutzer_Bearbeiten"
        Me.TSM_Benutzer_Bearbeiten.Size = New System.Drawing.Size(130, 22)
        Me.TSM_Benutzer_Bearbeiten.Text = "Bearbeiten"
        '
        'TSB_Issue
        '
        Me.TSB_Issue.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TSB_Issue.Image = CType(resources.GetObject("TSB_Issue.Image"), System.Drawing.Image)
        Me.TSB_Issue.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSB_Issue.Name = "TSB_Issue"
        Me.TSB_Issue.Size = New System.Drawing.Size(23, 22)
        Me.TSB_Issue.Text = "Fehler Melden"
        '
        'ToolStripDropDownButton3
        '
        Me.ToolStripDropDownButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripDropDownButton3.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSMI_Checklistedit, Me.TSMI_ChecklistOpen})
        Me.ToolStripDropDownButton3.Image = CType(resources.GetObject("ToolStripDropDownButton3.Image"), System.Drawing.Image)
        Me.ToolStripDropDownButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton3.Name = "ToolStripDropDownButton3"
        Me.ToolStripDropDownButton3.Size = New System.Drawing.Size(29, 22)
        Me.ToolStripDropDownButton3.Text = "ToolStripDropDownButton3"
        '
        'TSMI_Checklistedit
        '
        Me.TSMI_Checklistedit.Name = "TSMI_Checklistedit"
        Me.TSMI_Checklistedit.Size = New System.Drawing.Size(241, 22)
        Me.TSMI_Checklistedit.Text = "Ckeckliste erstellen / bearbeiten"
        '
        'TSMI_ChecklistOpen
        '
        Me.TSMI_ChecklistOpen.Name = "TSMI_ChecklistOpen"
        Me.TSMI_ChecklistOpen.Size = New System.Drawing.Size(241, 22)
        Me.TSMI_ChecklistOpen.Text = "Checkliste öffnen"
        '
        'Autodatenbank
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(1584, 985)
        Me.Controls.Add(Me.FLP_Main)
        Me.Controls.Add(Me.lbl_CreateReport)
        Me.Controls.Add(Me.BTN_CreateReport)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.dgv2)
        Me.Controls.Add(Me.dgv)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(1600, 1024)
        Me.Name = "Autodatenbank"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Autodatenbank"
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.DatabaseMenuStrip.ResumeLayout(False)
        CType(Me.dgv2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FTPMenuStrip.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.FLP_Main.ResumeLayout(False)
        Me.FLP_Main.PerformLayout()
        Me.TLP_Main1.ResumeLayout(False)
        Me.TLP_Main1.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.PB_Adressbook, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgv As DataGridView
    Friend WithEvents dgv2 As DataGridView
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents TSL_Neues_Auto As ToolStripLabel
    Friend WithEvents ToolStripDropDownButton1 As ToolStripDropDownButton
    Friend WithEvents TSMI_Server_Verbindungen As ToolStripMenuItem
    Friend WithEvents LBL_Login As ToolStripLabel
    Friend WithEvents LBL_Logout As ToolStripLabel
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents LBL_NewEntry As ToolStripLabel
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents DatabaseMenuStrip As ContextMenuStrip
    Friend WithEvents TSMI_Eintrag_Bearbeiten As ToolStripMenuItem
    Friend WithEvents TSMI_Eintrag_Loeschen As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents FTPMenuStrip As ContextMenuStrip
    Friend WithEvents TSMI_Datei_Oeffnen As ToolStripMenuItem
    Friend WithEvents TSMI_Datei_Loeschen As ToolStripMenuItem
    Friend WithEvents ToolStripDropDownButton2 As ToolStripDropDownButton
    Friend WithEvents EinträgeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TeilenummernToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents InfoZuSchlüsselnummerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LBL_NewCustomer As ToolStripLabel
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents LBL_EditCustomer As ToolStripButton
    Friend WithEvents ToolStripSeparator6 As ToolStripSeparator
    Friend WithEvents NachUpdateToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TSMI_Bericht_erstellen As ToolStripMenuItem
    Friend WithEvents BTN_CreateReport As Button
    Friend WithEvents lbl_CreateReport As Label
    Friend WithEvents FLP_Main As FlowLayoutPanel
    Friend WithEvents CBB_SavedCars As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TXB_Brand As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TXB_Model As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents TXB_LicensePlate As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TXB_Motorcode As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents TXB_Displacement As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents TXB_Power As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents TXB_VIN As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents TXB_ConstructionYear As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents TXB_KeyNumber As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents TXB_Owner As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents TXB_BuyDate As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents TXB_Price As TextBox
    Friend WithEvents RTB_Infos As RichTextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents BTN_SaveCarData As Button
    Friend WithEvents BTN_DeleteCarData As Button
    Friend WithEvents PB_Adressbook As PictureBox
    Friend WithEvents Label17 As Label
    Friend WithEvents CBB_NextInspectionMonth As ComboBox
    Friend WithEvents CBB_NextInspectionYear As ComboBox
    Friend WithEvents TLP_Main1 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents TSMI_Admin As ToolStripMenuItem
    Friend WithEvents AnsichtToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents NI_InspectionDate As NotifyIcon
    Friend WithEvents NI_Successful As NotifyIcon
    Friend WithEvents NI_Error As NotifyIcon
    Friend WithEvents PRNummerEntschlüsselnToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BTN_ShowPRNumbers As Button
    Friend WithEvents ToolStripSeparator7 As ToolStripSeparator
    Friend WithEvents TSB_Issue As ToolStripButton
    Friend WithEvents ToolStripSeparator8 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator9 As ToolStripSeparator
    Friend WithEvents TSB_UploadFile As ToolStripButton
    Friend WithEvents EintragAnzeigenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TSMI_LINK As ToolStripMenuItem
    Friend WithEvents TSMI_Service As ToolStripMenuItem
    Friend WithEvents TSMI_Repair As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents TSMI_Other As ToolStripMenuItem
    Friend WithEvents TSMI_LogFile_Oeffnen As ToolStripMenuItem
    Friend WithEvents TSMI_Bericht_Einstellungen As ToolStripMenuItem
    Friend WithEvents TSM_Benutzer As ToolStripMenuItem
    Friend WithEvents TSM_Benutzer_Erstellen As ToolStripMenuItem
    Friend WithEvents TSM_Benutzer_Bearbeiten As ToolStripMenuItem
    Friend WithEvents TSMI_MyCar As ToolStripLabel
    Friend WithEvents ToolStripDropDownButton3 As ToolStripDropDownButton
    Friend WithEvents TSMI_Checklistedit As ToolStripMenuItem
    Friend WithEvents TSMI_ChecklistOpen As ToolStripMenuItem
End Class
