Imports System.ComponentModel
Imports System.IO
Imports Renci.SshNet
Imports Renci.SshNet.Common

Public Class SSHKEY
    Dim connected As Boolean = False
    Private Sub BTN_SelectPPK_Click(sender As Object, e As EventArgs) Handles BTN_SelectPPK.Click
        If OFD_PEM.ShowDialog = DialogResult.OK Then
            TXB_PPKPath.Text = OFD_PEM.FileName

        End If
    End Sub

    Private Sub BTN_TestKeyConnection_Click(sender As Object, e As EventArgs) Handles BTN_TestKeyConnection.Click
        If File.Exists(TXB_PPKPath.Text) Then
            Try
                If TXB_PPKPass.Text.Length > 0 Then
                    If CheckOpenSSHKey(TXB_PPKPath.Text, TXB_PPKPass.Text) Then
                        ListBox1.Items.Add("Schlüssel erfolgreich getestet")
                    End If
                Else
                    If CheckOpenSSHKey(TXB_PPKPath.Text) Then
                        ListBox1.Items.Add("Schlüssel erfolgreich getestet")
                    End If
                End If
            Catch ex As Exception
                ListBox1.Items.Add("Test fehlgeschlagen: ")
                ListBox1.Items.Add(ex.Message)
            End Try

        End If
    End Sub



    Public Function CheckOpenSSHKey(ppkFilePath As String, Optional passphrase As String = Nothing) As Boolean
        Try
            Dim keyFile As PrivateKeyFile

            ' Prüfen, ob eine Passphrase vorhanden ist
            If String.IsNullOrEmpty(passphrase) Then
                ' Keine Passphrase - Versuche, die .ppk-Datei ohne Passphrase zu laden
                keyFile = New PrivateKeyFile(ppkFilePath)
            Else
                ' Passphrase vorhanden - Lade die .ppk-Datei mit der Passphrase
                keyFile = New PrivateKeyFile(ppkFilePath, passphrase)
            End If

            Return True

        Catch ex As SshException
            ' Wenn ein SshException ausgelöst wird, erfordert der Schlüssel möglicherweise eine Passphrase oder es liegt ein anderer Fehler vor

            Return False

        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub BTN_Save_Click(sender As Object, e As EventArgs) Handles BTN_Save.Click



        Try

            If TXB_PPKPass.Text.Length > 0 Then
                'Wenn Passphrase eingegeben wurde
                If CheckOpenSSHKey(TXB_PPKPath.Text, TXB_PPKPass.Text) = True Then
                    If File.Exists(TXB_PPKPath.Text) Then
                        Dim fp As String = System.IO.Path.GetFileName(TXB_PPKPath.Text)
                        File.Copy(TXB_PPKPath.Text, Application.StartupPath & "\" & fp, True)
                        My.Settings.keyfile = Application.StartupPath & "\" & fp
                        My.Settings.keyfilepass = TXB_PPKPass.Text
                        My.Settings.Save()
                        connected = True
                        If File.Exists(Application.StartupPath & "\ConnectionSettings.xml") Then
                            UpdateSettings(My.Settings.Regkey)
                        End If

                        Try
                            ServerConnection.CB_SFTP.Checked = True
                            ServerConnection.CB_KeyFileLoaded.Checked = True
                            FirstRun.CB_SFTP.Checked = True
                            FirstRun.CB_KeyFileLoaded.Checked = True

                        Catch ex As Exception
                            MsgBox("Fehler beim Speichern der Schlüsseldatei " & ex.Message)
                        End Try


                        Me.Close()
                    End If

                End If
            Else

                'Wenn keine Passphrase eingegeben wurde
                If CheckOpenSSHKey(TXB_PPKPath.Text) = True Then
                    If File.Exists(TXB_PPKPath.Text) Then
                        Dim fp As String = System.IO.Path.GetFileName(TXB_PPKPath.Text)
                        File.Copy(TXB_PPKPath.Text, Application.StartupPath & "\" & fp, True)
                        My.Settings.keyfile = Application.StartupPath & "\" & fp
                        My.Settings.keyfilepass = TXB_PPKPass.Text
                        My.Settings.Save()
                        connected = True
                        If File.Exists(Application.StartupPath & "\ConnectionSettings.xml") Then
                            UpdateSettings(My.Settings.Regkey)
                        End If

                        Try
                            ServerConnection.CB_SFTP.Checked = True
                            ServerConnection.CB_KeyFileLoaded.Checked = True
                            FirstRun.CB_SFTP.Checked = True
                            FirstRun.CB_KeyFileLoaded.Checked = True
                        Catch ex As Exception
                            MsgBox("Fehler beim Speichern der Schlüsseldatei " & ex.Message)
                        End Try


                        Me.Close()
                    End If

                End If


            End If

        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try







    End Sub

    Private Sub SSHKEY_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub SSHKEY_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If connected = False Then
            Try
                ServerConnection.CB_SFTP.Checked = False
                FirstRun.CB_SFTP.Checked = False
            Catch ex As Exception

            End Try

        End If
    End Sub
End Class