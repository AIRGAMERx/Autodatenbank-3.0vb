Imports MySqlConnector
Imports QRCoder

Public Class Smartphone_verification
    Dim ID As String
    Dim min As Integer
    Dim sec As Integer
    Dim verified As Boolean = False
    Dim RandomKey As String = ""

    Private Sub Smartphone_verification_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadOverallSettings()
        Dim connection As New MySqlConnection(My.Settings.connectionstring)


        Try
            connection.Open()
            Dim query As String = "SELECT id, user_name, Verified FROM users"
            Dim cmd As New MySqlCommand(query, connection)
            Dim reader As MySqlDataReader = cmd.ExecuteReader()

            CBB_RegUser.Items.Clear()

            While reader.Read()
                If reader("Verified").ToString = "0" Or reader("Verified").ToString = "1" Then
                    Dim item As New ComboBoxItem With {
                    .Text = reader("user_name").ToString(),
                    .Tag = reader("id")
                }
                    CBB_RegUser.Items.Add(item)
                End If

            End While

            reader.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            SavetoLogFile(ex.Message, "SmartphoneVerificationLoad")
        End Try


    End Sub

    Private Async Sub CBB_RegUser_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBB_RegUser.SelectedIndexChanged
        If CBB_RegUser.SelectedIndex > -1 Then

            Dim selectedItem As ComboBoxItem = CType(CBB_RegUser.SelectedItem, ComboBoxItem)
            ID = selectedItem.Tag.ToString()


            Dim connection As New MySqlConnection(My.Settings.connectionstring)
            Try
                connection.Open()
                Dim query As String = "SELECT VerifiKey, Verified FROM users WHERE id = @SearchValue"
                Dim cmd As New MySqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@SearchValue", ID)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()


                While reader.Read
                    Dim userdata = Await GetUserDataAsync(My.Settings.Regkey)
                    My.Settings.LicenseEmail = userdata.Email
                    My.Settings.LicenseName = userdata.Name
                    My.Settings.Save()
                    Dim qrGenerator As New QRCodeGenerator()
                    Dim qrCodeData = qrGenerator.CreateQrCode("LDN~" & My.Settings.LicenseName & "|LDE~" & My.Settings.LicenseEmail & "|LDR~" & My.Settings.Regkey & "|UDI~" & ID & "|MSDCS~" & My.Settings.connectionstring & "|FTPS~" & My.Settings.Ftpserveruri & "|FTPU~" & My.Settings.Ftpusername & "|FTPP~" & My.Settings.Ftppassword, QRCodeGenerator.ECCLevel.Q)
                    Dim qrcode As New QRCode(qrCodeData)
                    Dim qrCodeBitmap = qrcode.GetGraphic(20)
                    PictureBox1.BackgroundImage = qrCodeBitmap




                End While



                reader.Close()
            Catch ex As Exception
                Console.WriteLine(ex.Message)
                SavetoLogFile(ex.Message, "SelectedIndexChangedSmartphoneVerification")
            End Try





        End If


    End Sub

    Private Sub KopierenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KopierenToolStripMenuItem.Click
        Clipboard.SetImage(PictureBox1.BackgroundImage)
        MsgBox("QR-Code in Zwischenablage kopiert")
    End Sub
End Class


Public Class ComboBoxItem
    Public Property Text As String
    Public Property Tag As Object

    Public Overrides Function ToString() As String
        Return Text
    End Function
End Class