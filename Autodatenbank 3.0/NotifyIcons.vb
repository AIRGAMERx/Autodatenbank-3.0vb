Imports System.Media

Module NotifyIcons

    Public Sub Notify(ni As NotifyIcon, title As String, context As String, time As Integer, icon As ToolTipIcon)

        ni.Visible = True
        ni.ShowBalloonTip(5000, title, context, icon)
        If icon = ToolTipIcon.Error Then
            SystemSounds.Exclamation.Play()
        End If
        Dim t As New Timer()
        t.Interval = time


        AddHandler t.Tick, Sub(timerSender, timerEventArgs)
                               ni.Visible = False
                               t.Stop()
                               t.Dispose()
                           End Sub

        t.Start() ' Timer starten






    End Sub


    Public Sub TT_Info(control As Control, Headline As String, Caption As String)
        Dim mytoolTip As New ToolTip With {
            .ToolTipTitle = Headline,
            .ToolTipIcon = ToolTipIcon.Info,
            .IsBalloon = True}

        mytoolTip.SetToolTip(control, Caption)



    End Sub








End Module
