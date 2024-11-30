<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewSettings
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ViewSettings))
        Me.TC_Settings = New System.Windows.Forms.TabControl()
        Me.Overall = New System.Windows.Forms.TabPage()
        Me.BTN_SaveOverallSettings = New System.Windows.Forms.Button()
        Me.GB_OverallSettingsLabel = New System.Windows.Forms.GroupBox()
        Me.LBL_LabelTest = New System.Windows.Forms.Label()
        Me.CBB_OverallSettingsLabelForeColor = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.CBB_OverallSettingsFontFamily = New System.Windows.Forms.ComboBox()
        Me.GB_OverallSettingsBackgroundColor = New System.Windows.Forms.GroupBox()
        Me.PB_BackgroundColorCarInfoOverall = New System.Windows.Forms.PictureBox()
        Me.PB_BackgroundColorFormOverall = New System.Windows.Forms.PictureBox()
        Me.CBB_OverallSettingsFormBackground = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.CBB_OverallBackgroundCarInfo = New System.Windows.Forms.ComboBox()
        Me.Datagridview = New System.Windows.Forms.TabPage()
        Me.GB_DGVSettingsData = New System.Windows.Forms.GroupBox()
        Me.CB_DGVSettingsDataEditor = New System.Windows.Forms.CheckBox()
        Me.CB_DGVSettingsDataArt = New System.Windows.Forms.CheckBox()
        Me.CB_DGVSettingsDataComm = New System.Windows.Forms.CheckBox()
        Me.CB_DGVSettingsDataPrice = New System.Windows.Forms.CheckBox()
        Me.CB_DGVSettingsDataDate = New System.Windows.Forms.CheckBox()
        Me.CB_DGVSettingsDataMA = New System.Windows.Forms.CheckBox()
        Me.CB_DGVSettingsDataDC = New System.Windows.Forms.CheckBox()
        Me.CB_DGVSettingsDataLP = New System.Windows.Forms.CheckBox()
        Me.GB_DGVSettingsVisual = New System.Windows.Forms.GroupBox()
        Me.cbb_FontFamilyDGV = New System.Windows.Forms.ComboBox()
        Me.CBB_DGVSettingsCellsColor = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CBB_DGVSettingsBackgroundcolor = New System.Windows.Forms.ComboBox()
        Me.cbb_FontSizeDGV = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbb_ForeColorDGV = New System.Windows.Forms.ComboBox()
        Me.DGV_TestSettingDGV = New System.Windows.Forms.DataGridView()
        Me.Dates = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TestText = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BTN_SaveDGVSettings = New System.Windows.Forms.Button()
        Me.TC_Settings.SuspendLayout()
        Me.Overall.SuspendLayout()
        Me.GB_OverallSettingsLabel.SuspendLayout()
        Me.GB_OverallSettingsBackgroundColor.SuspendLayout()
        CType(Me.PB_BackgroundColorCarInfoOverall, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PB_BackgroundColorFormOverall, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Datagridview.SuspendLayout()
        Me.GB_DGVSettingsData.SuspendLayout()
        Me.GB_DGVSettingsVisual.SuspendLayout()
        CType(Me.DGV_TestSettingDGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TC_Settings
        '
        Me.TC_Settings.Controls.Add(Me.Overall)
        Me.TC_Settings.Controls.Add(Me.Datagridview)
        Me.TC_Settings.Location = New System.Drawing.Point(0, 2)
        Me.TC_Settings.Name = "TC_Settings"
        Me.TC_Settings.SelectedIndex = 0
        Me.TC_Settings.Size = New System.Drawing.Size(464, 533)
        Me.TC_Settings.TabIndex = 0
        '
        'Overall
        '
        Me.Overall.Controls.Add(Me.BTN_SaveOverallSettings)
        Me.Overall.Controls.Add(Me.GB_OverallSettingsLabel)
        Me.Overall.Controls.Add(Me.GB_OverallSettingsBackgroundColor)
        Me.Overall.Location = New System.Drawing.Point(4, 22)
        Me.Overall.Name = "Overall"
        Me.Overall.Padding = New System.Windows.Forms.Padding(3)
        Me.Overall.Size = New System.Drawing.Size(456, 507)
        Me.Overall.TabIndex = 0
        Me.Overall.Text = "Allgemein"
        Me.Overall.UseVisualStyleBackColor = True
        '
        'BTN_SaveOverallSettings
        '
        Me.BTN_SaveOverallSettings.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_SaveOverallSettings.Location = New System.Drawing.Point(12, 458)
        Me.BTN_SaveOverallSettings.Name = "BTN_SaveOverallSettings"
        Me.BTN_SaveOverallSettings.Size = New System.Drawing.Size(431, 43)
        Me.BTN_SaveOverallSettings.TabIndex = 14
        Me.BTN_SaveOverallSettings.Text = "Einstellungen speichern"
        Me.BTN_SaveOverallSettings.UseVisualStyleBackColor = True
        '
        'GB_OverallSettingsLabel
        '
        Me.GB_OverallSettingsLabel.Controls.Add(Me.LBL_LabelTest)
        Me.GB_OverallSettingsLabel.Controls.Add(Me.CBB_OverallSettingsLabelForeColor)
        Me.GB_OverallSettingsLabel.Controls.Add(Me.Label9)
        Me.GB_OverallSettingsLabel.Controls.Add(Me.Label10)
        Me.GB_OverallSettingsLabel.Controls.Add(Me.CBB_OverallSettingsFontFamily)
        Me.GB_OverallSettingsLabel.Location = New System.Drawing.Point(5, 150)
        Me.GB_OverallSettingsLabel.Name = "GB_OverallSettingsLabel"
        Me.GB_OverallSettingsLabel.Size = New System.Drawing.Size(445, 122)
        Me.GB_OverallSettingsLabel.TabIndex = 11
        Me.GB_OverallSettingsLabel.TabStop = False
        Me.GB_OverallSettingsLabel.Text = "Label Design"
        '
        'LBL_LabelTest
        '
        Me.LBL_LabelTest.AutoSize = True
        Me.LBL_LabelTest.Location = New System.Drawing.Point(73, 85)
        Me.LBL_LabelTest.Name = "LBL_LabelTest"
        Me.LBL_LabelTest.Size = New System.Drawing.Size(318, 13)
        Me.LBL_LabelTest.TabIndex = 9
        Me.LBL_LabelTest.Text = "Zwei flinke Boxer jagen die quirlige Eva und ihren Mops durch Sylt"
        '
        'CBB_OverallSettingsLabelForeColor
        '
        Me.CBB_OverallSettingsLabelForeColor.FormattingEnabled = True
        Me.CBB_OverallSettingsLabelForeColor.Location = New System.Drawing.Point(9, 42)
        Me.CBB_OverallSettingsLabelForeColor.Name = "CBB_OverallSettingsLabelForeColor"
        Me.CBB_OverallSettingsLabelForeColor.Size = New System.Drawing.Size(199, 21)
        Me.CBB_OverallSettingsLabelForeColor.TabIndex = 6
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 25)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(115, 13)
        Me.Label9.TabIndex = 5
        Me.Label9.Text = "Schriftfarbe auswählen"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(226, 25)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(103, 13)
        Me.Label10.TabIndex = 7
        Me.Label10.Text = "Schriftart auswählen"
        '
        'CBB_OverallSettingsFontFamily
        '
        Me.CBB_OverallSettingsFontFamily.FormattingEnabled = True
        Me.CBB_OverallSettingsFontFamily.Location = New System.Drawing.Point(229, 42)
        Me.CBB_OverallSettingsFontFamily.Name = "CBB_OverallSettingsFontFamily"
        Me.CBB_OverallSettingsFontFamily.Size = New System.Drawing.Size(199, 21)
        Me.CBB_OverallSettingsFontFamily.TabIndex = 8
        '
        'GB_OverallSettingsBackgroundColor
        '
        Me.GB_OverallSettingsBackgroundColor.Controls.Add(Me.PB_BackgroundColorCarInfoOverall)
        Me.GB_OverallSettingsBackgroundColor.Controls.Add(Me.PB_BackgroundColorFormOverall)
        Me.GB_OverallSettingsBackgroundColor.Controls.Add(Me.CBB_OverallSettingsFormBackground)
        Me.GB_OverallSettingsBackgroundColor.Controls.Add(Me.Label7)
        Me.GB_OverallSettingsBackgroundColor.Controls.Add(Me.Label8)
        Me.GB_OverallSettingsBackgroundColor.Controls.Add(Me.CBB_OverallBackgroundCarInfo)
        Me.GB_OverallSettingsBackgroundColor.Location = New System.Drawing.Point(5, 6)
        Me.GB_OverallSettingsBackgroundColor.Name = "GB_OverallSettingsBackgroundColor"
        Me.GB_OverallSettingsBackgroundColor.Size = New System.Drawing.Size(445, 138)
        Me.GB_OverallSettingsBackgroundColor.TabIndex = 0
        Me.GB_OverallSettingsBackgroundColor.TabStop = False
        Me.GB_OverallSettingsBackgroundColor.Text = "Hintergrundfarben"
        '
        'PB_BackgroundColorCarInfoOverall
        '
        Me.PB_BackgroundColorCarInfoOverall.Location = New System.Drawing.Point(229, 69)
        Me.PB_BackgroundColorCarInfoOverall.Name = "PB_BackgroundColorCarInfoOverall"
        Me.PB_BackgroundColorCarInfoOverall.Size = New System.Drawing.Size(199, 50)
        Me.PB_BackgroundColorCarInfoOverall.TabIndex = 10
        Me.PB_BackgroundColorCarInfoOverall.TabStop = False
        '
        'PB_BackgroundColorFormOverall
        '
        Me.PB_BackgroundColorFormOverall.Location = New System.Drawing.Point(9, 69)
        Me.PB_BackgroundColorFormOverall.Name = "PB_BackgroundColorFormOverall"
        Me.PB_BackgroundColorFormOverall.Size = New System.Drawing.Size(199, 50)
        Me.PB_BackgroundColorFormOverall.TabIndex = 9
        Me.PB_BackgroundColorFormOverall.TabStop = False
        '
        'CBB_OverallSettingsFormBackground
        '
        Me.CBB_OverallSettingsFormBackground.FormattingEnabled = True
        Me.CBB_OverallSettingsFormBackground.Location = New System.Drawing.Point(9, 42)
        Me.CBB_OverallSettingsFormBackground.Name = "CBB_OverallSettingsFormBackground"
        Me.CBB_OverallSettingsFormBackground.Size = New System.Drawing.Size(199, 21)
        Me.CBB_OverallSettingsFormBackground.TabIndex = 6
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 25)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(146, 13)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "Hintergrundfarbe auswählen: "
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(226, 25)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(190, 13)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Hintergrundfarbe Autoinfos auswählen:"
        '
        'CBB_OverallBackgroundCarInfo
        '
        Me.CBB_OverallBackgroundCarInfo.FormattingEnabled = True
        Me.CBB_OverallBackgroundCarInfo.Location = New System.Drawing.Point(229, 42)
        Me.CBB_OverallBackgroundCarInfo.Name = "CBB_OverallBackgroundCarInfo"
        Me.CBB_OverallBackgroundCarInfo.Size = New System.Drawing.Size(199, 21)
        Me.CBB_OverallBackgroundCarInfo.TabIndex = 8
        '
        'Datagridview
        '
        Me.Datagridview.Controls.Add(Me.GB_DGVSettingsData)
        Me.Datagridview.Controls.Add(Me.GB_DGVSettingsVisual)
        Me.Datagridview.Controls.Add(Me.BTN_SaveDGVSettings)
        Me.Datagridview.Location = New System.Drawing.Point(4, 22)
        Me.Datagridview.Name = "Datagridview"
        Me.Datagridview.Padding = New System.Windows.Forms.Padding(3)
        Me.Datagridview.Size = New System.Drawing.Size(456, 507)
        Me.Datagridview.TabIndex = 1
        Me.Datagridview.Text = "Datagridview"
        Me.Datagridview.UseVisualStyleBackColor = True
        '
        'GB_DGVSettingsData
        '
        Me.GB_DGVSettingsData.Controls.Add(Me.CB_DGVSettingsDataEditor)
        Me.GB_DGVSettingsData.Controls.Add(Me.CB_DGVSettingsDataArt)
        Me.GB_DGVSettingsData.Controls.Add(Me.CB_DGVSettingsDataComm)
        Me.GB_DGVSettingsData.Controls.Add(Me.CB_DGVSettingsDataPrice)
        Me.GB_DGVSettingsData.Controls.Add(Me.CB_DGVSettingsDataDate)
        Me.GB_DGVSettingsData.Controls.Add(Me.CB_DGVSettingsDataMA)
        Me.GB_DGVSettingsData.Controls.Add(Me.CB_DGVSettingsDataDC)
        Me.GB_DGVSettingsData.Controls.Add(Me.CB_DGVSettingsDataLP)
        Me.GB_DGVSettingsData.Location = New System.Drawing.Point(6, 345)
        Me.GB_DGVSettingsData.Name = "GB_DGVSettingsData"
        Me.GB_DGVSettingsData.Size = New System.Drawing.Size(444, 100)
        Me.GB_DGVSettingsData.TabIndex = 15
        Me.GB_DGVSettingsData.TabStop = False
        Me.GB_DGVSettingsData.Text = "Daten"
        '
        'CB_DGVSettingsDataEditor
        '
        Me.CB_DGVSettingsDataEditor.AutoSize = True
        Me.CB_DGVSettingsDataEditor.Location = New System.Drawing.Point(321, 43)
        Me.CB_DGVSettingsDataEditor.Name = "CB_DGVSettingsDataEditor"
        Me.CB_DGVSettingsDataEditor.Size = New System.Drawing.Size(74, 17)
        Me.CB_DGVSettingsDataEditor.TabIndex = 7
        Me.CB_DGVSettingsDataEditor.Text = "Bearbeiter"
        Me.CB_DGVSettingsDataEditor.UseVisualStyleBackColor = True
        '
        'CB_DGVSettingsDataArt
        '
        Me.CB_DGVSettingsDataArt.AutoSize = True
        Me.CB_DGVSettingsDataArt.Location = New System.Drawing.Point(321, 19)
        Me.CB_DGVSettingsDataArt.Name = "CB_DGVSettingsDataArt"
        Me.CB_DGVSettingsDataArt.Size = New System.Drawing.Size(39, 17)
        Me.CB_DGVSettingsDataArt.TabIndex = 6
        Me.CB_DGVSettingsDataArt.Text = "Art"
        Me.CB_DGVSettingsDataArt.UseVisualStyleBackColor = True
        '
        'CB_DGVSettingsDataComm
        '
        Me.CB_DGVSettingsDataComm.AutoSize = True
        Me.CB_DGVSettingsDataComm.Location = New System.Drawing.Point(152, 66)
        Me.CB_DGVSettingsDataComm.Name = "CB_DGVSettingsDataComm"
        Me.CB_DGVSettingsDataComm.Size = New System.Drawing.Size(79, 17)
        Me.CB_DGVSettingsDataComm.TabIndex = 5
        Me.CB_DGVSettingsDataComm.Text = "Kommentar"
        Me.CB_DGVSettingsDataComm.UseVisualStyleBackColor = True
        '
        'CB_DGVSettingsDataPrice
        '
        Me.CB_DGVSettingsDataPrice.AutoSize = True
        Me.CB_DGVSettingsDataPrice.Location = New System.Drawing.Point(152, 43)
        Me.CB_DGVSettingsDataPrice.Name = "CB_DGVSettingsDataPrice"
        Me.CB_DGVSettingsDataPrice.Size = New System.Drawing.Size(49, 17)
        Me.CB_DGVSettingsDataPrice.TabIndex = 4
        Me.CB_DGVSettingsDataPrice.Text = "Preis"
        Me.CB_DGVSettingsDataPrice.UseVisualStyleBackColor = True
        '
        'CB_DGVSettingsDataDate
        '
        Me.CB_DGVSettingsDataDate.AutoSize = True
        Me.CB_DGVSettingsDataDate.Location = New System.Drawing.Point(152, 20)
        Me.CB_DGVSettingsDataDate.Name = "CB_DGVSettingsDataDate"
        Me.CB_DGVSettingsDataDate.Size = New System.Drawing.Size(57, 17)
        Me.CB_DGVSettingsDataDate.TabIndex = 3
        Me.CB_DGVSettingsDataDate.Text = "Datum"
        Me.CB_DGVSettingsDataDate.UseVisualStyleBackColor = True
        '
        'CB_DGVSettingsDataMA
        '
        Me.CB_DGVSettingsDataMA.AutoSize = True
        Me.CB_DGVSettingsDataMA.Location = New System.Drawing.Point(9, 66)
        Me.CB_DGVSettingsDataMA.Name = "CB_DGVSettingsDataMA"
        Me.CB_DGVSettingsDataMA.Size = New System.Drawing.Size(69, 17)
        Me.CB_DGVSettingsDataMA.TabIndex = 2
        Me.CB_DGVSettingsDataMA.Text = "Kilometer"
        Me.CB_DGVSettingsDataMA.UseVisualStyleBackColor = True
        '
        'CB_DGVSettingsDataDC
        '
        Me.CB_DGVSettingsDataDC.AutoSize = True
        Me.CB_DGVSettingsDataDC.Location = New System.Drawing.Point(9, 43)
        Me.CB_DGVSettingsDataDC.Name = "CB_DGVSettingsDataDC"
        Me.CB_DGVSettingsDataDC.Size = New System.Drawing.Size(88, 17)
        Me.CB_DGVSettingsDataDC.TabIndex = 1
        Me.CB_DGVSettingsDataDC.Text = "Bezeichnung"
        Me.CB_DGVSettingsDataDC.UseVisualStyleBackColor = True
        '
        'CB_DGVSettingsDataLP
        '
        Me.CB_DGVSettingsDataLP.AutoSize = True
        Me.CB_DGVSettingsDataLP.Checked = True
        Me.CB_DGVSettingsDataLP.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CB_DGVSettingsDataLP.Enabled = False
        Me.CB_DGVSettingsDataLP.Location = New System.Drawing.Point(9, 20)
        Me.CB_DGVSettingsDataLP.Name = "CB_DGVSettingsDataLP"
        Me.CB_DGVSettingsDataLP.Size = New System.Drawing.Size(88, 17)
        Me.CB_DGVSettingsDataLP.TabIndex = 0
        Me.CB_DGVSettingsDataLP.Text = "Kennzeichen"
        Me.CB_DGVSettingsDataLP.UseVisualStyleBackColor = True
        '
        'GB_DGVSettingsVisual
        '
        Me.GB_DGVSettingsVisual.Controls.Add(Me.cbb_FontFamilyDGV)
        Me.GB_DGVSettingsVisual.Controls.Add(Me.CBB_DGVSettingsCellsColor)
        Me.GB_DGVSettingsVisual.Controls.Add(Me.Label1)
        Me.GB_DGVSettingsVisual.Controls.Add(Me.Label6)
        Me.GB_DGVSettingsVisual.Controls.Add(Me.Label2)
        Me.GB_DGVSettingsVisual.Controls.Add(Me.CBB_DGVSettingsBackgroundcolor)
        Me.GB_DGVSettingsVisual.Controls.Add(Me.cbb_FontSizeDGV)
        Me.GB_DGVSettingsVisual.Controls.Add(Me.Label5)
        Me.GB_DGVSettingsVisual.Controls.Add(Me.Label3)
        Me.GB_DGVSettingsVisual.Controls.Add(Me.Label4)
        Me.GB_DGVSettingsVisual.Controls.Add(Me.cbb_ForeColorDGV)
        Me.GB_DGVSettingsVisual.Controls.Add(Me.DGV_TestSettingDGV)
        Me.GB_DGVSettingsVisual.Location = New System.Drawing.Point(6, 6)
        Me.GB_DGVSettingsVisual.Name = "GB_DGVSettingsVisual"
        Me.GB_DGVSettingsVisual.Size = New System.Drawing.Size(447, 333)
        Me.GB_DGVSettingsVisual.TabIndex = 14
        Me.GB_DGVSettingsVisual.TabStop = False
        Me.GB_DGVSettingsVisual.Text = "Visuelle Einstellungen"
        '
        'cbb_FontFamilyDGV
        '
        Me.cbb_FontFamilyDGV.FormattingEnabled = True
        Me.cbb_FontFamilyDGV.Location = New System.Drawing.Point(6, 32)
        Me.cbb_FontFamilyDGV.Name = "cbb_FontFamilyDGV"
        Me.cbb_FontFamilyDGV.Size = New System.Drawing.Size(188, 21)
        Me.cbb_FontFamilyDGV.TabIndex = 1
        '
        'CBB_DGVSettingsCellsColor
        '
        Me.CBB_DGVSettingsCellsColor.FormattingEnabled = True
        Me.CBB_DGVSettingsCellsColor.Location = New System.Drawing.Point(200, 73)
        Me.CBB_DGVSettingsCellsColor.Name = "CBB_DGVSettingsCellsColor"
        Me.CBB_DGVSettingsCellsColor.Size = New System.Drawing.Size(166, 21)
        Me.CBB_DGVSettingsCellsColor.TabIndex = 12
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(106, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Schriftart auswählen:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(197, 56)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(136, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Hintergrundfarbe der Zellen"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(197, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(115, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Schriftgröße auswähle:"
        '
        'CBB_DGVSettingsBackgroundcolor
        '
        Me.CBB_DGVSettingsBackgroundcolor.FormattingEnabled = True
        Me.CBB_DGVSettingsBackgroundcolor.Location = New System.Drawing.Point(6, 73)
        Me.CBB_DGVSettingsBackgroundcolor.Name = "CBB_DGVSettingsBackgroundcolor"
        Me.CBB_DGVSettingsBackgroundcolor.Size = New System.Drawing.Size(188, 21)
        Me.CBB_DGVSettingsBackgroundcolor.TabIndex = 10
        '
        'cbb_FontSizeDGV
        '
        Me.cbb_FontSizeDGV.FormattingEnabled = True
        Me.cbb_FontSizeDGV.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20"})
        Me.cbb_FontSizeDGV.Location = New System.Drawing.Point(200, 32)
        Me.cbb_FontSizeDGV.Name = "cbb_FontSizeDGV"
        Me.cbb_FontSizeDGV.Size = New System.Drawing.Size(115, 21)
        Me.cbb_FontSizeDGV.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(3, 56)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(169, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Hintergrundfarbe der Datagridview"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(318, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(118, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Schriftfarbe auswählen:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 99)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(93, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Test Datagridview"
        '
        'cbb_ForeColorDGV
        '
        Me.cbb_ForeColorDGV.FormattingEnabled = True
        Me.cbb_ForeColorDGV.Location = New System.Drawing.Point(321, 32)
        Me.cbb_ForeColorDGV.Name = "cbb_ForeColorDGV"
        Me.cbb_ForeColorDGV.Size = New System.Drawing.Size(112, 21)
        Me.cbb_ForeColorDGV.TabIndex = 6
        '
        'DGV_TestSettingDGV
        '
        Me.DGV_TestSettingDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_TestSettingDGV.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Dates, Me.TestText})
        Me.DGV_TestSettingDGV.Location = New System.Drawing.Point(6, 118)
        Me.DGV_TestSettingDGV.Name = "DGV_TestSettingDGV"
        Me.DGV_TestSettingDGV.Size = New System.Drawing.Size(434, 202)
        Me.DGV_TestSettingDGV.TabIndex = 7
        '
        'Dates
        '
        Me.Dates.HeaderText = "Datum"
        Me.Dates.Name = "Dates"
        '
        'TestText
        '
        Me.TestText.HeaderText = "Test Text"
        Me.TestText.Name = "TestText"
        Me.TestText.Width = 285
        '
        'BTN_SaveDGVSettings
        '
        Me.BTN_SaveDGVSettings.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_SaveDGVSettings.Location = New System.Drawing.Point(14, 458)
        Me.BTN_SaveDGVSettings.Name = "BTN_SaveDGVSettings"
        Me.BTN_SaveDGVSettings.Size = New System.Drawing.Size(431, 43)
        Me.BTN_SaveDGVSettings.TabIndex = 13
        Me.BTN_SaveDGVSettings.Text = "Einstellungen speichern"
        Me.BTN_SaveDGVSettings.UseVisualStyleBackColor = True
        '
        'ViewSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(461, 538)
        Me.Controls.Add(Me.TC_Settings)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ViewSettings"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ansicht"
        Me.TopMost = True
        Me.TC_Settings.ResumeLayout(False)
        Me.Overall.ResumeLayout(False)
        Me.GB_OverallSettingsLabel.ResumeLayout(False)
        Me.GB_OverallSettingsLabel.PerformLayout()
        Me.GB_OverallSettingsBackgroundColor.ResumeLayout(False)
        Me.GB_OverallSettingsBackgroundColor.PerformLayout()
        CType(Me.PB_BackgroundColorCarInfoOverall, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PB_BackgroundColorFormOverall, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Datagridview.ResumeLayout(False)
        Me.GB_DGVSettingsData.ResumeLayout(False)
        Me.GB_DGVSettingsData.PerformLayout()
        Me.GB_DGVSettingsVisual.ResumeLayout(False)
        Me.GB_DGVSettingsVisual.PerformLayout()
        CType(Me.DGV_TestSettingDGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TC_Settings As TabControl
    Friend WithEvents Overall As TabPage
    Friend WithEvents Datagridview As TabPage
    Friend WithEvents cbb_FontFamilyDGV As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cbb_FontSizeDGV As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cbb_ForeColorDGV As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents DGV_TestSettingDGV As DataGridView
    Friend WithEvents Label4 As Label
    Friend WithEvents Dates As DataGridViewTextBoxColumn
    Friend WithEvents TestText As DataGridViewTextBoxColumn
    Friend WithEvents CBB_DGVSettingsCellsColor As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents CBB_DGVSettingsBackgroundcolor As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents BTN_SaveDGVSettings As Button
    Friend WithEvents GB_DGVSettingsData As GroupBox
    Friend WithEvents GB_DGVSettingsVisual As GroupBox
    Friend WithEvents CB_DGVSettingsDataEditor As CheckBox
    Friend WithEvents CB_DGVSettingsDataArt As CheckBox
    Friend WithEvents CB_DGVSettingsDataComm As CheckBox
    Friend WithEvents CB_DGVSettingsDataPrice As CheckBox
    Friend WithEvents CB_DGVSettingsDataDate As CheckBox
    Friend WithEvents CB_DGVSettingsDataMA As CheckBox
    Friend WithEvents CB_DGVSettingsDataDC As CheckBox
    Friend WithEvents CB_DGVSettingsDataLP As CheckBox
    Friend WithEvents GB_OverallSettingsBackgroundColor As GroupBox
    Friend WithEvents CBB_OverallSettingsFormBackground As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents CBB_OverallBackgroundCarInfo As ComboBox
    Friend WithEvents PB_BackgroundColorCarInfoOverall As PictureBox
    Friend WithEvents PB_BackgroundColorFormOverall As PictureBox
    Friend WithEvents GB_OverallSettingsLabel As GroupBox
    Friend WithEvents CBB_OverallSettingsLabelForeColor As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents CBB_OverallSettingsFontFamily As ComboBox
    Friend WithEvents LBL_LabelTest As Label
    Friend WithEvents BTN_SaveOverallSettings As Button
End Class
