Imports MySqlConnector

'###HILFE##' DELETE BY RELEASE

'WORK WHAT FROM TABLE WHERE = CONDITION;

'SELECT username FROM users WHERE id = @ID

'FILL WITH PARAMETERS 







Module SQLTable
    Public Function CheckExistTableUsers(tableName As String) As Boolean
        Try
            Using connection As New MySqlConnection(My.Settings.connectionstring)
                connection.Open()

                Dim query As String = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = DATABASE() AND TABLE_NAME = @TableName"

                Using cmd As New MySqlCommand(query, connection)
                    cmd.Parameters.AddWithValue("@TableName", tableName)

                    Dim reader As MySqlDataReader = cmd.ExecuteReader()

                    If reader.Read() Then
                        Return True
                    Else
                        Return False
                    End If
                End Using
            End Using
        Catch ex As Exception
            MsgBox("Fehler bei der Verbindung zur Datenbank", MsgBoxStyle.Critical, Title:="Verbindungsfehler")
            SavetoLogFile(ex.Message, "CheckExistTableUser")
            Return False
        End Try
    End Function

    Public Sub BootupTableUsers()

        'Tabelle Users wird umbenannt um wieder ausgelesen zu werden
        Try
            Dim connection As New MySqlConnection(My.Settings.connectionstring)

            connection.Open()
            Dim renameQuery As String = "RENAME TABLE users_shutdown TO users"

            Using cmd As New MySqlCommand(renameQuery, connection)
                cmd.ExecuteNonQuery()
            End Using


        Catch ex As Exception

        End Try
    End Sub
    Public Sub ShutdownTableUsers()

        'Tabelle Users wird deaktiviert um nicht beachtet zu werden
        Try
            Dim connection As New MySqlConnection(My.Settings.connectionstring)

            connection.Open()
            Dim renameQuery As String = "RENAME TABLE users TO users_shutdown"

            Using cmd As New MySqlCommand(renameQuery, connection)
                cmd.ExecuteNonQuery()
            End Using


        Catch ex As Exception

        End Try
    End Sub
    Public Sub CreateTableUsers()
        Try
            Dim connection As New MySqlConnection(My.Settings.connectionstring)
            connection.Open()

            Dim query As String = "CREATE TABLE IF NOT EXISTS `users` (
           `id` VARCHAR(200) NOT NULL COLLATE 'utf8mb4_0900_ai_ci',
           `user_name` VARCHAR(200) NOT NULL COLLATE 'utf8mb4_0900_ai_ci',
           `PermissionKey` VARCHAR(50) NOT NULL DEFAULT '000000' COLLATE 'utf8mb4_0900_ai_ci',
           `PermissionRole` VARCHAR(50) NULL DEFAULT NULL COLLATE 'utf8mb4_0900_ai_ci',
           `VerifiKey` VARCHAR(50) NULL DEFAULT NULL COLLATE 'utf8mb4_0900_ai_ci',
           `Verified` INT NOT NULL DEFAULT '0',
           `Authent` VARCHAR(50) NOT NULL DEFAULT '0' COLLATE 'utf8mb4_0900_ai_ci',
           `AuthentKey` VARCHAR(50) NULL DEFAULT NULL COLLATE 'utf8mb4_0900_ai_ci',
           `UID` VARCHAR(50) NULL DEFAULT NULL COLLATE 'utf8mb4_0900_ai_ci',
           `password` VARCHAR(50) NULL DEFAULT NULL COLLATE 'utf8mb4_0900_ai_ci',
           `salt` VARCHAR(50) NULL DEFAULT NULL COLLATE 'utf8mb4_0900_ai_ci',
           `Passdate` DATE NULL DEFAULT NULL,
           `failed_attempts` INT NULL DEFAULT '0',
           `lockout_until` DATETIME NULL DEFAULT NULL,
           PRIMARY KEY (`id`) USING BTREE
        )
        COLLATE='utf8mb4_0900_ai_ci'
        ENGINE=InnoDB;"

            Using cmd As New MySqlCommand(query, connection)
                cmd.ExecuteNonQuery()
            End Using

        Catch ex As Exception
            MsgBox("Tabelle in Datenbank konnte nicht angelegt werden, bitte Berechtigung prüfen: " & ex.Message)
            SavetoLogFile(ex.Message, "CreateTableUsers")
        End Try
    End Sub

    Public Sub CreateTables()

        Dim connection As New MySqlConnection(My.Settings.connectionstring)

        Try
            connection.Open()

            ' Tabelle Autos erstellen
            Dim createAutoSql As String = "CREATE TABLE IF NOT EXISTS `Autos` (
            `Marke` VARCHAR(50) NULL DEFAULT 'N/A' COLLATE 'utf8mb4_0900_ai_ci',
            `Model` VARCHAR(50) NULL DEFAULT 'N/A' COLLATE 'utf8mb4_0900_ai_ci',
            `Kennzeichen` VARCHAR(50) NOT NULL COLLATE 'utf8mb4_0900_ai_ci',
            `MKB` VARCHAR(50) NULL DEFAULT 'N/A' COLLATE 'utf8mb4_0900_ai_ci',
            `Hubraum` VARCHAR(50) NULL DEFAULT 'N/A' COLLATE 'utf8mb4_0900_ai_ci',
            `PS` VARCHAR(50) NULL DEFAULT 'N/A' COLLATE 'utf8mb4_0900_ai_ci',
            `FIN` VARCHAR(50) NULL DEFAULT 'N/A' COLLATE 'utf8mb4_0900_ai_ci',
            `Baujahr` VARCHAR(50) NULL DEFAULT 'N/A' COLLATE 'utf8mb4_0900_ai_ci',
            `HSN` VARCHAR(50) NULL DEFAULT 'N/A' COLLATE 'utf8mb4_0900_ai_ci',
            `Besitzer` VARCHAR(50) NULL DEFAULT 'N/A' COLLATE 'utf8mb4_0900_ai_ci',
            `Gekauft` VARCHAR(50) NULL DEFAULT 'N/A' COLLATE 'utf8mb4_0900_ai_ci',
            `Preis` VARCHAR(50) NULL DEFAULT 'N/A' COLLATE 'utf8mb4_0900_ai_ci',
            `Info` VARCHAR(500) NULL DEFAULT 'N/A' COLLATE 'utf8mb4_0900_ai_ci',
            `kunden_id` INT NULL DEFAULT NULL,
            `tuev` DATE NULL DEFAULT NULL,
            `PR` VARCHAR(500) NULL DEFAULT 'N/A' COLLATE 'utf8mb4_0900_ai_ci',
            PRIMARY KEY (`Kennzeichen`) USING BTREE,
            INDEX `fk_kunden_id` (`kunden_id`) USING BTREE,
            CONSTRAINT `fk_kunden_id` FOREIGN KEY (`kunden_id`) REFERENCES `Kunden` (`ID`) ON UPDATE NO ACTION ON DELETE NO ACTION
            )
            COLLATE='utf8mb4_0900_ai_ci'
            ENGINE=InnoDB;"

            Using cmda As New MySqlCommand(createAutoSql, connection)
                cmda.ExecuteNonQuery()
            End Using

            ' Tabelle Reparatur erstellen
            Dim createReparaturSql As String = "CREATE TABLE IF NOT EXISTS `Reparatur` (
            `ID_Reparatur` INT NOT NULL AUTO_INCREMENT,
            `ID_Kennzeichen` VARCHAR(50) NOT NULL DEFAULT 'Kennzeichenlos' COLLATE 'utf8mb4_0900_ai_ci',
            `Bezeichnung` VARCHAR(50) NULL DEFAULT NULL COLLATE 'utf8mb4_0900_ai_ci',
            `Kilometer` VARCHAR(50) NULL DEFAULT NULL COLLATE 'utf8mb4_0900_ai_ci',
            `Datum` VARCHAR(50) NULL DEFAULT NULL COLLATE 'utf8mb4_0900_ai_ci',
            `Preis` VARCHAR(50) NULL DEFAULT NULL COLLATE 'utf8mb4_0900_ai_ci',
            `Kommentar` LONGTEXT NULL DEFAULT NULL COLLATE 'utf8mb4_0900_ai_ci',
            `Datein` LONGTEXT NULL DEFAULT NULL COLLATE 'utf8mb4_0900_ai_ci',
            `Art` VARCHAR(50) NULL DEFAULT NULL COLLATE 'utf8mb4_0900_ai_ci',
            `Bearbeiter` VARCHAR(50) NULL DEFAULT NULL COLLATE 'utf8mb4_0900_ai_ci',
            PRIMARY KEY (`ID_Reparatur`) USING BTREE
        )
        COLLATE='utf8mb4_0900_ai_ci'
        ENGINE=InnoDB;"

            Using cmdr As New MySqlCommand(createReparaturSql, connection)
                cmdr.ExecuteNonQuery()
            End Using

            ' Tabelle Service erstellen
            Dim createServiceSql As String = "CREATE TABLE IF NOT EXISTS `Service` (
            `ID_Service` INT NOT NULL AUTO_INCREMENT,
            `ID_Kennzeichen` VARCHAR(50) NOT NULL DEFAULT 'Kennzeichenlos' COLLATE 'utf8mb4_0900_ai_ci',
            `Bezeichnung` VARCHAR(50) NULL DEFAULT NULL COLLATE 'utf8mb4_0900_ai_ci',
            `Kilometer` VARCHAR(50) NULL DEFAULT NULL COLLATE 'utf8mb4_0900_ai_ci',
            `Datum` VARCHAR(50) NULL DEFAULT NULL COLLATE 'utf8mb4_0900_ai_ci',
            `Preis` VARCHAR(50) NULL DEFAULT NULL COLLATE 'utf8mb4_0900_ai_ci',
            `Kommentar` LONGTEXT NULL DEFAULT NULL COLLATE 'utf8mb4_0900_ai_ci',
            `Datein` LONGTEXT NULL DEFAULT NULL COLLATE 'utf8mb4_0900_ai_ci',
            `Art` VARCHAR(50) NULL DEFAULT NULL COLLATE 'utf8mb4_0900_ai_ci',
            `Bearbeiter` VARCHAR(50) NULL DEFAULT 'Kein Bearbeiter' COLLATE 'utf8mb4_0900_ai_ci',
            PRIMARY KEY (`ID_Service`) USING BTREE
        )
        COLLATE='utf8mb4_0900_ai_ci'
        ENGINE=InnoDB;"

            Using cmds As New MySqlCommand(createServiceSql, connection)
                cmds.ExecuteNonQuery()
            End Using

            ' Tabelle Kunden erstellen
            Dim createKundenSql As String = "CREATE TABLE IF NOT EXISTS `Kunden` (
            `ID` INT NOT NULL AUTO_INCREMENT,
            `Name` VARCHAR(50) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',
            `Straße` VARCHAR(50) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',
            `Plz` VARCHAR(50) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',
            `Ort` VARCHAR(50) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',
            `Telefonnummer` VARCHAR(50) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',
            `Email` VARCHAR(50) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',
            `Erstellt` VARCHAR(50) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',
            PRIMARY KEY (`ID`) USING BTREE
        )
        COLLATE='utf8mb4_general_ci'
        ENGINE=InnoDB;"

            Using cmdku As New MySqlCommand(createKundenSql, connection)
                cmdku.ExecuteNonQuery()
            End Using

            ' Tabelle Meldungen erstellen
            Dim createMeldungenSql As String = "CREATE TABLE IF NOT EXISTS `Meldungen` (
            `Name` VARCHAR(50) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',
            `Datum` VARCHAR(50) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',
            `Art` VARCHAR(50) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',
            `Text` VARCHAR(255) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci'
        )
        COLLATE='utf8mb4_general_ci'
        ENGINE=InnoDB;"

            Using cmdmel As New MySqlCommand(createMeldungenSql, connection)
                cmdmel.ExecuteNonQuery()
            End Using

            ' Tabelle Sonstiges erstellen
            Dim createSonstigeseSql As String = "CREATE TABLE IF NOT EXISTS `Sonstiges` (
            `ID_Sonstiges` INT NOT NULL AUTO_INCREMENT,
            `ID_Kennzeichen` VARCHAR(50) NOT NULL DEFAULT 'Kennzeichenlos' COLLATE 'utf8mb4_0900_ai_ci',
            `Bezeichnung` VARCHAR(50) NULL DEFAULT NULL COLLATE 'utf8mb4_0900_ai_ci',
            `Kilometer` VARCHAR(50) NULL DEFAULT NULL COLLATE 'utf8mb4_0900_ai_ci',
            `Datum` VARCHAR(50) NULL DEFAULT NULL COLLATE 'utf8mb4_0900_ai_ci',
            `Preis` VARCHAR(50) NULL DEFAULT NULL COLLATE 'utf8mb4_0900_ai_ci',
            `Kommentar` LONGTEXT NULL DEFAULT NULL COLLATE 'utf8mb4_0900_ai_ci',
            `Datein` LONGTEXT NULL DEFAULT NULL COLLATE 'utf8mb4_0900_ai_ci',
            `Art` VARCHAR(50) NULL DEFAULT NULL COLLATE 'utf8mb4_0900_ai_ci',
            `Bearbeiter` VARCHAR(50) NULL DEFAULT 'Kein Bearbeiter' COLLATE 'utf8mb4_0900_ai_ci',
            PRIMARY KEY (`ID_Sonstiges`) USING BTREE
        )
        COLLATE='utf8mb4_0900_ai_ci'
        ENGINE=InnoDB;"

            Using cmdso As New MySqlCommand(createSonstigeseSql, connection)
                cmdso.ExecuteNonQuery()
            End Using




            Dim createBerechtigungenSql As String = "CREATE TABLE IF NOT EXISTS `Berechtigungen` (" &
                               "`Name` varchar(50) COLLATE utf8mb4_general_ci DEFAULT NULL, " &
                               "`Key` varchar(255) COLLATE utf8mb4_general_ci DEFAULT NULL " &
                               ") ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;"


            Dim InsertDefaultRole As String = "INSERT IGNORE INTO `Berechtigungen` (`Name`, `Key`) VALUES ('Administrator', '111111111111');"



            Using cmdbe As New MySqlCommand(createBerechtigungenSql, connection)
                cmdbe.ExecuteNonQuery()
            End Using

            Using cmdbeInsert As New MySqlCommand(InsertDefaultRole, connection)
                cmdbeInsert.ExecuteNonQuery()
            End Using



            ' Weitere Aktionen nach dem Erstellen der Tabellen
            If My.Settings.sftp = False Then
                FTPHelper.CreateDirectory(My.Settings.Ftpserveruri, My.Settings.Ftpusername, My.Settings.Ftppassword, "Autodatenbank")
                My.Settings.Ftpserveruri &= "/Datenbank"
                My.Settings.Save()
            Else
                CheckAndCreateDirectoryOnSFTP(My.Settings.SFTPServerUri, My.Settings.SFTPUsername)
            End If

            UpdateSettings(My.Settings.Regkey)
            MsgBox("Tabellen und Verzeichnisse erfolgreich erstellt.")

        Catch ex As Exception
            MessageBox.Show("Fehler beim Erstellen der Tabellen: " & ex.Message)
            SavetoLogFile(ex.Message, "CreateTables")
        Finally
            connection.Close()
        End Try

    End Sub




    Public Function UpdateTable() As Boolean

        Dim connection As New MySqlConnection(My.Settings.connectionstring)

        Try
            connection.Open()

            ' Überprüfen und aktualisieren der Tabelle 'Users'
            EnsureTableAndColumns(connection, "users", New Dictionary(Of String, String) From {
                {"id", "VARCHAR(200) NOT NULL"},
                {"user_name", "VARCHAR(200) NOT NULL"},
                {"PermissionKey", "VARCHAR(50) NOT NULL DEFAULT '000000'"},
                {"PermissionRole", "VARCHAR(50)  NULL DEFAULT NULL"},
                {"VerifiKey", "VARCHAR(50) NULL DEFAULT NULL"},
                {"Verified", "INT NOT NULL DEFAULT '0'"},
                {"Authent", "VARCHAR(50) NOT NULL DEFAULT '0'"},
                {"AuthentKey", "VARCHAR(50) NULL DEFAULT NULL"},
                {"UID", "VARCHAR(50) NULL DEFAULT NULL"},
                {"password", "VARCHAR(50) NULL DEFAULT NULL"},
                {"salt", "VARCHAR(50) NULL DEFAULT NULL"},
                {"Passdate", "DATE NULL DEFAULT NULL"},
                {"failed_attempts", "INT NULL DEFAULT '0'"},
                {"lockout_until", "DATETIME NULL DEFAULT NULL"}
            })

            ' Überprüfen und aktualisieren der Tabelle 'Autos'
            EnsureTableAndColumns(connection, "Autos", New Dictionary(Of String, String) From {
                {"Marke", "VARCHAR(50) NULL DEFAULT 'N/A'"},
                {"Model", "VARCHAR(50) NULL DEFAULT 'N/A'"},
                {"Kennzeichen", "VARCHAR(50) NOT NULL"},
                {"MKB", "VARCHAR(50) NULL DEFAULT 'N/A'"},
                {"Hubraum", "VARCHAR(50) NULL DEFAULT 'N/A'"},
                {"PS", "VARCHAR(50) NULL DEFAULT 'N/A'"},
                {"FIN", "VARCHAR(50) NULL DEFAULT 'N/A'"},
                {"Baujahr", "VARCHAR(50) NULL DEFAULT 'N/A'"},
                {"HSN", "VARCHAR(50) NULL DEFAULT 'N/A'"},
                {"Besitzer", "VARCHAR(50) NULL DEFAULT 'N/A'"},
                {"Gekauft", "VARCHAR(50) NULL DEFAULT 'N/A'"},
                {"Preis", "VARCHAR(50) NULL DEFAULT 'N/A'"},
                {"Info", "VARCHAR(500) NULL DEFAULT 'N/A'"},
                {"kunden_id", "INT NULL DEFAULT NULL"},
                {"tuev", "DATE NULL DEFAULT NULL"},
                {"PR", "VARCHAR(500) NULL DEFAULT 'N/A'"}
            })

            ' Überprüfen und aktualisieren der Tabelle 'Reparatur'
            EnsureTableAndColumns(connection, "Reparatur", New Dictionary(Of String, String) From {
                {"ID_Reparatur", "INT NOT NULL AUTO_INCREMENT"},
                {"ID_Kennzeichen", "VARCHAR(50) NOT NULL DEFAULT 'Kennzeichenlos'"},
                {"Bezeichnung", "VARCHAR(50) NULL DEFAULT NULL"},
                {"Kilometer", "VARCHAR(50) NULL DEFAULT NULL"},
                {"Datum", "VARCHAR(50) NULL DEFAULT NULL"},
                {"Preis", "VARCHAR(50) NULL DEFAULT NULL"},
                {"Kommentar", "LONGTEXT NULL DEFAULT NULL"},
                {"Datein", "LONGTEXT NULL DEFAULT NULL"},
                {"Art", "VARCHAR(50) NULL DEFAULT NULL"},
                {"Bearbeiter", "VARCHAR(50) NULL DEFAULT NULL"}
            })

            ' Überprüfen und aktualisieren der Tabelle 'Service'
            EnsureTableAndColumns(connection, "Service", New Dictionary(Of String, String) From {
                {"ID_Service", "INT NOT NULL AUTO_INCREMENT"},
                {"ID_Kennzeichen", "VARCHAR(50) NOT NULL DEFAULT 'Kennzeichenlos'"},
                {"Bezeichnung", "VARCHAR(50) NULL DEFAULT NULL"},
                {"Kilometer", "VARCHAR(50) NULL DEFAULT NULL"},
                {"Datum", "VARCHAR(50) NULL DEFAULT NULL"},
                {"Preis", "VARCHAR(50) NULL DEFAULT NULL"},
                {"Kommentar", "LONGTEXT NULL DEFAULT NULL"},
                 {"Datein", "LONGTEXT NULL DEFAULT NULL"},
                {"Art", "VARCHAR(50) NULL DEFAULT NULL"},
                {"Bearbeiter", "VARCHAR(50) NULL DEFAULT 'Kein Bearbeiter'"}
            })

            ' Überprüfen und aktualisieren der Tabelle 'Kunden'
            EnsureTableAndColumns(connection, "Kunden", New Dictionary(Of String, String) From {
                {"ID", "INT NOT NULL AUTO_INCREMENT"},
                {"Name", "VARCHAR(50) NULL DEFAULT NULL"},
                {"Straße", "VARCHAR(50) NULL DEFAULT NULL"},
                {"Plz", "VARCHAR(50) NULL DEFAULT NULL"},
                {"Ort", "VARCHAR(50) NULL DEFAULT NULL"},
                {"Telefonnummer", "VARCHAR(50) NULL DEFAULT NULL"},
                {"Email", "VARCHAR(50) NULL DEFAULT NULL"},
                {"Erstellt", "VARCHAR(50) NULL DEFAULT NULL"}
            })

            ' Überprüfen und aktualisieren der Tabelle 'Meldungen'
            EnsureTableAndColumns(connection, "Meldungen", New Dictionary(Of String, String) From {
                {"Name", "VARCHAR(50) NULL DEFAULT NULL"},
                {"Datum", "VARCHAR(50) NULL DEFAULT NULL"},
                {"Art", "VARCHAR(50) NULL DEFAULT NULL"},
                {"Text", "VARCHAR(255) NULL DEFAULT NULL"}
            })

            ' Überprüfen und aktualisieren der Tabelle 'Sonstiges'
            EnsureTableAndColumns(connection, "Sonstiges", New Dictionary(Of String, String) From {
                {"ID_Sonstiges", "INT NOT NULL AUTO_INCREMENT"},
                {"ID_Kennzeichen", "VARCHAR(50) NOT NULL DEFAULT 'Kennzeichenlos'"},
                {"Bezeichnung", "VARCHAR(50) NULL DEFAULT NULL"},
                {"Kilometer", "VARCHAR(50) NULL DEFAULT NULL"},
                {"Datum", "VARCHAR(50) NULL DEFAULT NULL"},
                {"Preis", "VARCHAR(50) NULL DEFAULT NULL"},
                {"Kommentar", "LONGTEXT NULL DEFAULT NULL"},
                 {"Datein", "LONGTEXT NULL DEFAULT NULL"},
                {"Art", "VARCHAR(50) NULL DEFAULT NULL"},
                {"Bearbeiter", "VARCHAR(50) NULL DEFAULT 'Kein Bearbeiter'"}
            })

            'Überprüfen und aktualisieren der Tabelle 'Berechtigungen'
            EnsureTableAndColumns(connection, "Berechtigungen", New Dictionary(Of String, String) From {
                {"Name", "VARCHAR(50) COLLATE utf8mb4_general_ci DEFAULT NULL"},
                {"Key", "VARCHAR(255) COLLATE utf8mb4_general_ci DEFAULT NULL"}
            })

            EnsureAdministratorExists(connection)

            Return True

        Catch ex As Exception
            MessageBox.Show("Fehler beim Überprüfen oder Aktualisieren des Datenbankschemas: " & ex.Message)
            SavetoLogFile(ex.Message, "UpdatesTables")
            Return False
        Finally
            connection.Close()
        End Try
    End Function

    Private Sub EnsureTableAndColumns(connection As MySqlConnection, tableName As String, columns As Dictionary(Of String, String))
        For Each columnName As String In columns.Keys
            Dim checkColumnQuery As String = $"SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{tableName}' AND COLUMN_NAME = '{columnName}';"
            Dim columnExists As Boolean = False

            Using checkCmd As New MySqlCommand(checkColumnQuery, connection)
                Using reader As MySqlDataReader = checkCmd.ExecuteReader()
                    columnExists = reader.HasRows
                End Using
            End Using

            If Not columnExists Then
                Select Case MessageBox.Show($"Spalte `{columnName}` in der Tabelle: `{tableName}` wurde nicht gefunden." + vbNewLine + "Soll diese wiederhergestellt werden?", "Es wurden Fehler in der Datenbank gefunden", MessageBoxButtons.YesNo)
                    Case Windows.Forms.DialogResult.Yes
                        Dim alterTableQuery As String = $"ALTER TABLE `{tableName}` ADD COLUMN `{columnName}` {columns(columnName)};"
                        Using alterCmd As New MySqlCommand(alterTableQuery, connection)
                            alterCmd.ExecuteNonQuery()
                        End Using
                        MessageBox.Show($"Spalte `{columnName}` wurde zu Tabelle `{tableName}` hinzugefügt.")
                    Case Windows.Forms.DialogResult.No

                End Select



            End If
        Next
    End Sub

    Private Sub EnsureAdministratorExists(connection As MySqlConnection)
        Dim checkAdminQuery As String = "SELECT * FROM `Berechtigungen` WHERE `Name` = 'Administrator';"
        Dim adminExists As Boolean = False

        Using checkCmd As New MySqlCommand(checkAdminQuery, connection)
            Using reader As MySqlDataReader = checkCmd.ExecuteReader()
                If reader.HasRows Then
                    reader.Read() ' Leseposition auf die erste (und einzige) Zeile setzen
                    If reader("Key").ToString() = "111111111111" Then
                        adminExists = True
                    End If
                End If
            End Using
        End Using

        If Not adminExists Then
            Dim insertAdminQuery As String = "INSERT INTO `Berechtigungen` (`Name`, `Key`) VALUES ('Administrator', '111111111111');"
            Using insertCmd As New MySqlCommand(insertAdminQuery, connection)
                insertCmd.ExecuteNonQuery()
            End Using

        Else

        End If
    End Sub
End Module
