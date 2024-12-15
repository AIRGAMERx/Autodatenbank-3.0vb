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
            `Marke` VARCHAR(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT 'N/A',
            `Model` VARCHAR(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT 'N/A',
            `Kennzeichen` VARCHAR(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
            `MKB` VARCHAR(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT 'N/A',
            `Hubraum` VARCHAR(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT 'N/A',
            `PS` VARCHAR(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT 'N/A',
            `FIN` VARCHAR(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT 'N/A',
            `Baujahr` VARCHAR(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT 'N/A',
            `HSN` VARCHAR(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT 'N/A',
            `Besitzer` VARCHAR(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT 'N/A',
            `Gekauft` VARCHAR(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT 'N/A',
            `Preis` VARCHAR(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT 'N/A',
            `Info` VARCHAR(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT 'N/A',
            `kunden_id` INT DEFAULT NULL,
            `tuev` DATE DEFAULT NULL,
            `PR` VARCHAR(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT 'N/A',
            PRIMARY KEY (`Kennzeichen`),
            CONSTRAINT `fk_kunden_id` FOREIGN KEY (`kunden_id`) REFERENCES `Kunden` (`ID`)
        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;"

            Using cmda As New MySqlCommand(createAutoSql, connection)
                cmda.ExecuteNonQuery()
            End Using

            ' Tabelle Berechtigungen erstellen
            Dim createBerechtigungenSql As String = "CREATE TABLE IF NOT EXISTS `Berechtigungen` (
            `Name` VARCHAR(50) COLLATE utf8mb4_general_ci DEFAULT NULL,
            `Key` VARCHAR(50) COLLATE utf8mb4_general_ci DEFAULT NULL
        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;"

            Using cmdb As New MySqlCommand(createBerechtigungenSql, connection)
                cmdb.ExecuteNonQuery()
            End Using

            ' Tabelle Checklist erstellen
            Dim createChecklistSql As String = "CREATE TABLE IF NOT EXISTS `checklist` (
            `ID` INT NOT NULL AUTO_INCREMENT,
            `Description` VARCHAR(255) COLLATE utf8mb4_general_ci NOT NULL,
            `UpdatedBy` VARCHAR(50) COLLATE utf8mb4_general_ci NOT NULL,
            `CreatedBy` VARCHAR(50) COLLATE utf8mb4_general_ci NOT NULL,
            `Worksteps` VARCHAR(5000) COLLATE utf8mb4_general_ci DEFAULT NULL,
            PRIMARY KEY (`ID`)
        ) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;"

            Using cmdc As New MySqlCommand(createChecklistSql, connection)
                cmdc.ExecuteNonQuery()
            End Using

            ' Tabelle Kunden erstellen
            Dim createKundenSql As String = "CREATE TABLE IF NOT EXISTS `Kunden` (
            `ID` INT NOT NULL AUTO_INCREMENT,
            `Name` VARCHAR(50) COLLATE utf8mb4_general_ci DEFAULT NULL,
            `Straße` VARCHAR(50) COLLATE utf8mb4_general_ci DEFAULT NULL,
            `Plz` VARCHAR(50) COLLATE utf8mb4_general_ci DEFAULT NULL,
            `Ort` VARCHAR(50) COLLATE utf8mb4_general_ci DEFAULT NULL,
            `Telefonnummer` VARCHAR(50) COLLATE utf8mb4_general_ci DEFAULT NULL,
            `Email` VARCHAR(50) COLLATE utf8mb4_general_ci DEFAULT NULL,
            `Erstellt` VARCHAR(50) COLLATE utf8mb4_general_ci DEFAULT NULL,
            PRIMARY KEY (`ID`)
        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;"

            Using cmdk As New MySqlCommand(createKundenSql, connection)
                cmdk.ExecuteNonQuery()
            End Using

            ' Tabelle Meldungen erstellen
            Dim createMeldungenSql As String = "CREATE TABLE IF NOT EXISTS `Meldungen` (
            `Name` VARCHAR(50) COLLATE utf8mb4_general_ci DEFAULT NULL,
            `Datum` VARCHAR(50) COLLATE utf8mb4_general_ci DEFAULT NULL,
            `Art` VARCHAR(50) COLLATE utf8mb4_general_ci DEFAULT NULL,
            `Text` VARCHAR(255) COLLATE utf8mb4_general_ci DEFAULT NULL
        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;"

            Using cmdm As New MySqlCommand(createMeldungenSql, connection)
                cmdm.ExecuteNonQuery()
            End Using

            ' Tabelle Reparatur erstellen
            Dim createReparaturSql As String = "CREATE TABLE IF NOT EXISTS `Reparatur` (
            `ID_Reparatur` INT NOT NULL AUTO_INCREMENT,
            `ID_Kennzeichen` VARCHAR(50) NOT NULL DEFAULT 'Kennzeichenlos',
            `Bezeichnung` VARCHAR(50) COLLATE utf8mb4_0900_ai_ci NOT NULL,
            `Kilometer` VARCHAR(50) DEFAULT NULL,
            `Datum` VARCHAR(50) COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
            `Preis` VARCHAR(50) DEFAULT NULL,
            `Kommentar` LONGTEXT COLLATE utf8mb4_0900_ai_ci,
            `Art` VARCHAR(50) COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
            `Bearbeiter` VARCHAR(50) COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
            `Datein` LONGTEXT,
            PRIMARY KEY (`ID_Reparatur`)
        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;"

            Using cmdr As New MySqlCommand(createReparaturSql, connection)
                cmdr.ExecuteNonQuery()
            End Using

            ' Tabelle Service erstellen
            Dim createServiceSql As String = "CREATE TABLE IF NOT EXISTS `Service` (
            `ID_Service` INT NOT NULL AUTO_INCREMENT,
            `ID_Kennzeichen` VARCHAR(50) COLLATE utf8mb4_0900_ai_ci NOT NULL DEFAULT 'Kennzeichenlos',
            `Bezeichnung` VARCHAR(50) COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
            `Kilometer` VARCHAR(50) DEFAULT NULL,
            `Datum` VARCHAR(50) COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
            `Preis` VARCHAR(50) COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
            `Kommentar` LONGTEXT COLLATE utf8mb4_0900_ai_ci,
            `Art` VARCHAR(50) DEFAULT NULL,
            `Bearbeiter` VARCHAR(50) COLLATE utf8mb4_0900_ai_ci DEFAULT 'Kein Bearbeiter',
            `Datein` LONGTEXT,
            PRIMARY KEY (`ID_Service`)
        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;"

            Using cmds As New MySqlCommand(createServiceSql, connection)
                cmds.ExecuteNonQuery()
            End Using

            ' Tabelle Sonstiges erstellen
            Dim createSonstigesSql As String = "CREATE TABLE IF NOT EXISTS `Sonstiges` (
            `ID_Sonstiges` INT NOT NULL AUTO_INCREMENT,
            `ID_Kennzeichen` VARCHAR(50) COLLATE utf8mb4_0900_ai_ci NOT NULL DEFAULT 'Kennzeichenlos',
            `Bezeichnung` VARCHAR(50) DEFAULT NULL,
            `Kilometer` VARCHAR(50) DEFAULT NULL,
            `Datum` VARCHAR(50) COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
            `Preis` VARCHAR(50) DEFAULT NULL,
            `Kommentar` LONGTEXT COLLATE utf8mb4_0900_ai_ci,
            `Art` VARCHAR(50) DEFAULT NULL,
            `Bearbeiter` VARCHAR(50) DEFAULT 'Kein Bearbeiter',
            `Datein` LONGTEXT,
            PRIMARY KEY (`ID_Sonstiges`)
        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;"

            Using cmdso As New MySqlCommand(createSonstigesSql, connection)
                cmdso.ExecuteNonQuery()
            End Using

            ' Tabelle savedChecklist erstellen
            Dim createSavedChecklistSql As String = "CREATE TABLE IF NOT EXISTS `savedChecklist` (
            `ID` INT NOT NULL AUTO_INCREMENT,
            `Kennzeichen` VARCHAR(50) COLLATE utf8mb4_general_ci DEFAULT NULL,
            `Description` VARCHAR(50) COLLATE utf8mb4_general_ci DEFAULT NULL,
            `Worksteps` VARCHAR(5000) COLLATE utf8mb4_general_ci DEFAULT NULL,
            `Infos` VARCHAR(255) COLLATE utf8mb4_general_ci DEFAULT NULL,
            `Finish` VARCHAR(50) COLLATE utf8mb4_general_ci DEFAULT NULL,
            `Editor` VARCHAR(50) COLLATE utf8mb4_general_ci DEFAULT NULL,
            PRIMARY KEY (`ID`)
        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;"

            Using cmdsc As New MySqlCommand(createSavedChecklistSql, connection)
                cmdsc.ExecuteNonQuery()
            End Using

            ' Tabelle Verbrauch erstellen
            Dim createVerbrauchSql As String = "CREATE TABLE IF NOT EXISTS `Verbrauch` (
            `Kennzeichen` VARCHAR(50) COLLATE utf8mb4_general_ci NOT NULL DEFAULT 'Kennzeichenlos',
            `Wegstrecke` VARCHAR(50) COLLATE utf8mb4_general_ci NOT NULL,
            `ID` INT NOT NULL AUTO_INCREMENT,
            `Kraftstoffmenge` DOUBLE NOT NULL DEFAULT '0',
            `PPL` DOUBLE NOT NULL DEFAULT '0',
            `PPT` DOUBLE NOT NULL DEFAULT '0',
            `Kilometerstand` DOUBLE NOT NULL,
            `Datum` DATE NOT NULL,
            `VerbrauchPro100km` DOUBLE DEFAULT NULL,
            `latitude` DOUBLE DEFAULT NULL,
            `longitude` DOUBLE DEFAULT NULL,
            PRIMARY KEY (`ID`)
        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;"

            Using cmdv As New MySqlCommand(createVerbrauchSql, connection)
                cmdv.ExecuteNonQuery()
            End Using

            MsgBox("Alle Tabellen erfolgreich erstellt!")

        Catch ex As Exception
            MsgBox("Fehler beim Erstellen der Tabellen: " & ex.Message, MsgBoxStyle.Critical)
        Finally
            connection.Close()
        End Try

    End Sub





    Public Function UpdateTable() As Boolean

        Dim connection As New MySqlConnection(My.Settings.connectionstring)

        Try
            connection.Open()

            ' Tabelle 'Users' überprüfen und aktualisieren
            EnsureTableAndColumns(connection, "users", New Dictionary(Of String, String) From {
            {"id", "VARCHAR(200) NOT NULL"},
            {"user_name", "VARCHAR(200) NOT NULL"},
            {"PermissionKey", "VARCHAR(50) NOT NULL DEFAULT '000000'"},
            {"PermissionRole", "VARCHAR(50) NULL DEFAULT NULL"},
            {"VerifiKey", "VARCHAR(50) NULL DEFAULT NULL"},
            {"Verified", "INT NOT NULL DEFAULT '0'"},
            {"Authent", "VARCHAR(50) NOT NULL DEFAULT '0'"},
            {"AuthentKey", "VARCHAR(50) NULL DEFAULT NULL"},
            {"UID", "VARCHAR(50) NULL DEFAULT NULL"},
            {"password", "VARCHAR(50) NULL DEFAULT NULL"},
            {"salt", "VARCHAR(50) NULL DEFAULT NULL"},
            {"Passdate", "DATE NULL DEFAULT NULL"},
            {"failed_attempts", "INT NULL DEFAULT '0'"},
            {"lockout_until", "DATETIME NULL DEFAULT NULL"},
            {"mycar", "VARCHAR(50) NULL DEFAULT NULL"}
        })

            ' Tabelle 'Autos' überprüfen und aktualisieren
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

            ' Tabelle 'Reparatur' überprüfen und aktualisieren
            EnsureTableAndColumns(connection, "Reparatur", New Dictionary(Of String, String) From {
            {"ID_Reparatur", "INT NOT NULL AUTO_INCREMENT"},
            {"ID_Kennzeichen", "VARCHAR(50) NOT NULL DEFAULT 'Kennzeichenlos'"},
            {"Bezeichnung", "VARCHAR(50) NOT NULL"},
            {"Kilometer", "VARCHAR(50) NULL DEFAULT NULL"},
            {"Datum", "VARCHAR(50) NULL DEFAULT NULL"},
            {"Preis", "VARCHAR(50) NULL DEFAULT NULL"},
            {"Kommentar", "LONGTEXT NULL DEFAULT NULL"},
            {"Datein", "LONGTEXT NULL DEFAULT NULL"},
            {"Art", "VARCHAR(50) NULL DEFAULT NULL"},
            {"Bearbeiter", "VARCHAR(50) NULL DEFAULT NULL"}
        })

            ' Tabelle 'Service' überprüfen und aktualisieren
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

            ' Tabelle 'Kunden' überprüfen und aktualisieren
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

            ' Tabelle 'Meldungen' überprüfen und aktualisieren
            EnsureTableAndColumns(connection, "Meldungen", New Dictionary(Of String, String) From {
            {"Name", "VARCHAR(50) NULL DEFAULT NULL"},
            {"Datum", "VARCHAR(50) NULL DEFAULT NULL"},
            {"Art", "VARCHAR(50) NULL DEFAULT NULL"},
            {"Text", "VARCHAR(255) NULL DEFAULT NULL"}
        })

            ' Tabelle 'Sonstiges' überprüfen und aktualisieren
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

            ' Tabelle 'Berechtigungen' überprüfen und aktualisieren
            EnsureTableAndColumns(connection, "Berechtigungen", New Dictionary(Of String, String) From {
            {"Name", "VARCHAR(50) NULL DEFAULT NULL"},
            {"Key", "VARCHAR(50) NULL DEFAULT NULL"}
        })

            ' Tabelle 'checklist' überprüfen und aktualisieren
            EnsureTableAndColumns(connection, "checklist", New Dictionary(Of String, String) From {
            {"ID", "INT NOT NULL AUTO_INCREMENT"},
            {"Description", "VARCHAR(255) NOT NULL"},
            {"UpdatedBy", "VARCHAR(50) NOT NULL"},
            {"CreatedBy", "VARCHAR(50) NOT NULL"},
            {"Worksteps", "VARCHAR(5000) NULL"}
        })

            ' Tabelle 'savedChecklist' überprüfen und aktualisieren
            EnsureTableAndColumns(connection, "savedChecklist", New Dictionary(Of String, String) From {
            {"ID", "INT NOT NULL AUTO_INCREMENT"},
            {"Kennzeichen", "VARCHAR(50) NULL DEFAULT NULL"},
            {"Description", "VARCHAR(50) NULL DEFAULT NULL"},
            {"Worksteps", "VARCHAR(5000) NULL"},
            {"Infos", "VARCHAR(255) NULL DEFAULT NULL"},
            {"Finish", "VARCHAR(50) NULL DEFAULT NULL"},
            {"Editor", "VARCHAR(50) NULL DEFAULT NULL"}
        })

            ' Tabelle 'Verbrauch' überprüfen und aktualisieren
            EnsureTableAndColumns(connection, "Verbrauch", New Dictionary(Of String, String) From {
            {"Kennzeichen", "VARCHAR(50) NOT NULL DEFAULT 'Kennzeichenlos'"},
            {"Wegstrecke", "VARCHAR(50) NOT NULL"},
            {"ID", "INT NOT NULL AUTO_INCREMENT"},
            {"Kraftstoffmenge", "DOUBLE NOT NULL DEFAULT '0'"},
            {"PPL", "DOUBLE NOT NULL DEFAULT '0'"},
            {"PPT", "DOUBLE NOT NULL DEFAULT '0'"},
            {"Kilometerstand", "DOUBLE NOT NULL"},
            {"Datum", "DATE NOT NULL"},
            {"VerbrauchPro100km", "DOUBLE NULL"},
            {"latitude", "DOUBLE NULL"},
            {"longitude", "DOUBLE NULL"}
        })

            ' Sicherstellen, dass ein Administrator existiert
            EnsureAdministratorExists(connection)

            Return True

        Catch ex As Exception
            MsgBox("Fehler beim Aktualisieren der Tabellen: " & ex.Message, MsgBoxStyle.Critical)
            SavetoLogFile(ex.Message, "UpdateTable")
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
