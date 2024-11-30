<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MyCar
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
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MyCar))
        Me.priceChart = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        CType(Me.priceChart, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'priceChart
        '
        Me.priceChart.BackColor = System.Drawing.Color.Transparent
        Me.priceChart.BackImageTransparentColor = System.Drawing.Color.Transparent
        Me.priceChart.BorderlineColor = System.Drawing.Color.Transparent
        ChartArea1.Name = "ChartArea1"
        Me.priceChart.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        Me.priceChart.Legends.Add(Legend1)
        Me.priceChart.Location = New System.Drawing.Point(463, 46)
        Me.priceChart.Name = "priceChart"
        Series1.ChartArea = "ChartArea1"
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Me.priceChart.Series.Add(Series1)
        Me.priceChart.Size = New System.Drawing.Size(476, 355)
        Me.priceChart.TabIndex = 0
        Me.priceChart.Text = "Chart1"
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.AutoScroll = True
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(12, 46)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(372, 896)
        Me.FlowLayoutPanel1.TabIndex = 3
        Me.FlowLayoutPanel1.WrapContents = False
        '
        'MyCar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(973, 954)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Controls.Add(Me.priceChart)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "MyCar"
        Me.Text = "Mein Auto"
        CType(Me.priceChart, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents priceChart As DataVisualization.Charting.Chart
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
End Class
