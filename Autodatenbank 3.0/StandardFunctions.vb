Imports System.IO

Module StandardFunctions
    Public Sub CreateTempDirectory()
        If Not Directory.Exists(Application.StartupPath & "\Temp") Then
            Directory.CreateDirectory(Application.StartupPath & "\Temp")
        End If
    End Sub

    Public Function ReplaceUmlauts(input As String) As String
        Return input.Replace("ä", "ae").Replace("Ä", "Ae") _
                    .Replace("ö", "oe").Replace("Ö", "Oe") _
                    .Replace("ü", "ue").Replace("Ü", "Ue")
    End Function

    Function GetTotalFolderSize(folderPath As String) As Long
        Dim totalSize As Long = 0

        Try
            ' Alle Dateien im aktuellen Ordner durchsuchen
            Dim files As String() = Directory.GetFiles(folderPath)
            For Each file In files
                ' Dateigröße hinzufügen
                Dim fileInfo As New FileInfo(file)
                totalSize += fileInfo.Length
            Next

            ' Alle Unterordner durchsuchen und deren Größen hinzufügen
            Dim directories As String() = Directory.GetDirectories(folderPath)
            For Each d In directories
                totalSize += GetTotalFolderSize(d)
            Next
        Catch ex As Exception
            Console.WriteLine($"Fehler beim Berechnen der Größe: {ex.Message}")
        End Try

        Return totalSize
    End Function
End Module
