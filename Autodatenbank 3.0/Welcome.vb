Imports System.Threading
Imports Microsoft.Win32

Public Class Welcome
    Dim initializationThread As Thread
    Dim initializationComplete As Boolean = False
    Private isF2Pressed As Boolean = False
    Private isDPressed As Boolean = False

    Private Async Sub Welcome_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Sicherstellen, dass Settings leer sind beim Starten
        UnloadUserSettings()



        If SearchRegEntry() = True Then
            Dim permission As Integer = Await GetPermissionForRegKey(My.Settings.Regkey)
            If permission = 0 Then
                MsgBox("Sie haben nicht die Berechtigung diese Anwendung zu starten")
                Me.Close()
            ElseIf permission >= 1 Then
                If GetRegistryValue("Software\Autodatenbank3.0", "Update") = "1" Then
                    MsgBox("Update erfolgreich installiert")
                End If
                Me.KeyPreview = True
                initializationThread = New Thread(AddressOf Initialization)
                initializationThread.Start()

            End If
        ElseIf SearchRegEntry() = False Then
            FirstRun.Show()
            Me.Close()
        End If



        ' Starte die Initialisierung in einem separaten Thread nach dem Laden der Form

    End Sub

    Private Async Sub Initialization()
        Try
            ' Die Initialisierung wird nun in einem separaten Thread durchgeführt
            Invoke(Sub() Lbl_Status.Text = "Nach Updates suchen")

            ' Füge eine Verzögerung von 5 Sekunden ein, um sicherzustellen, dass das GIF mindestens so lange abgespielt wird
            Thread.Sleep(3000)

            If Await CheckUpdate() = True Then
                Invoke(Sub() MsgBox("Es ist ein Update verfügbar. Patch Notes auf www.lfdev.de verfügbar."))
            End If

            ' Registry-Werte setzen
            SetRegistryValue("Software\Autodatenbank3.0", "Version", My.Settings.Version.ToString)
            SetRegistryValue("Software\Autodatenbank3.0", "Path", Application.StartupPath)
            SetRegistryValue("Software\Autodatenbank3.0", "Update", "0")



            ' Aufruf der Methode im Modul zur Überprüfung und Aktualisierung der Tabellen
            If FindConnectionSettings() = True Then
                Invoke(Sub() Lbl_Status.Text = "Datenbanken auf Fehler prüfen")
                SQLTable.UpdateTable()
            End If


            Invoke(Sub() Lbl_Status.Text = "Verbindungsdaten laden")

            ' Logik für das Öffnen der entsprechenden Forms
            If RegistryOptions.SearchRegEntry = True AndAlso FindConnectionSettings() = True Then
                Invoke(Sub()
                           LoadConnectionSettings()
                           Autodatenbank.Show()
                           Me.Close()
                       End Sub)
            ElseIf SearchRegEntry() = False And FindConnectionSettings() = False Then
                Invoke(Sub()
                           FirstRun.Show()
                           Me.Close()
                       End Sub)
            ElseIf SearchRegEntry() = False And FindConnectionSettings() = True Then
                Invoke(Sub()
                           FirstRun.Show()
                           Me.Close()
                       End Sub)
            ElseIf SearchRegEntry() = True And FindConnectionSettings() = False Then
                Invoke(Sub()
                           ServerConnection.Show()
                           Me.Close()
                       End Sub)
            End If

            initializationComplete = True ' Initialisierung erfolgreich abgeschlossen
        Catch ex As Exception
            Invoke(Sub() MessageBox.Show("Fehler bei der Initialisierung: " & ex.Message))
            SavetoLogFile(ex.Message, "InitialaizationWelcome")
        End Try
    End Sub

    Private Async Function CheckUpdate() As Task(Of Boolean)
        Dim InstalledVersion As Integer = My.Settings.Version

        Dim newestVersion As Integer = Await GetNewestVersion()


        If InstalledVersion < newestVersion Then
            Return True
        Else
            Return False
        End If

    End Function

    ' Hilfsmethoden zur Interaktion mit der Registry
    Private Sub SetRegistryValue(keyPath As String, valueName As String, value As String)
        Try
            Dim key As RegistryKey = Registry.CurrentUser.CreateSubKey(keyPath)
            key.SetValue(valueName, value)
            key.Close()
        Catch ex As Exception
            MessageBox.Show("Fehler beim Setzen des Registry-Werts: " & ex.Message)
            SavetoLogFile(ex.Message, "SetRegistryValueWelcome")
        End Try
    End Sub

    Private Sub Welcome_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F2 Then
            isF2Pressed = True
        End If

        ' Prüfen, ob D gedrückt wurde
        If e.KeyCode = Keys.D Then
            isDPressed = True
        End If

        ' Prüfen, ob beide Tasten gedrückt wurden
        If isF2Pressed AndAlso isDPressed Then
            LBL_HELP.Text = "Standardeinstellungen werden geladen"
            My.Settings.DefaultSettings = True
            My.Settings.Save()

            ' Zurücksetzen der Status
            isF2Pressed = False
            isDPressed = False
        End If

    End Sub

    Private Sub Welcome_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        ' Wenn die Tasten losgelassen werden, setzen Sie die Flags zurück
        If e.KeyCode = Keys.F2 Then
            isF2Pressed = False
        End If

        If e.KeyCode = Keys.D Then
            isDPressed = False
        End If
    End Sub
    Private Sub UnloadUserSettings()
        My.Settings.Regkey = ""
        My.Settings.LicenseName = ""
        My.Settings.LicenseEmail = ""
        My.Settings.Permission = 0
        My.Settings.LicensePlate = ""
        My.Settings.Ftpserveruri = ""
        My.Settings.Ftpusername = ""
        My.Settings.Ftppassword = ""
        My.Settings.SFTPServerUri = ""
        My.Settings.SFTPUsername = ""
        My.Settings.keyfile = ""
        My.Settings.keyfilepass = ""
        My.Settings.sftp = False
        If My.Settings.RememberLogin = False Then
            My.Settings.Username = ""
            My.Settings.UID = ""
            My.Settings.PermissionKey = "000000000000"
        End If
        My.Settings.CompName = ""
        My.Settings.CompStreet = ""
        My.Settings.CompCity = ""
        My.Settings.Save()


    End Sub

    Private Sub PB_Logo_Click(sender As Object, e As EventArgs) Handles PB_Logo.Click

    End Sub
End Class
