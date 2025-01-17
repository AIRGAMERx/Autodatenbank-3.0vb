Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Windows.Media.Media3D
Imports iTextSharp.text.pdf

Module Thumbnail
    Function CreateThumbnail(inputpath As String, outputpath As String) As Boolean
        Try

            Dim originalImage As Image = Image.FromFile(inputpath)

            Dim thumbnail As Image = originalImage.GetThumbnailImage(150, 150, Nothing, IntPtr.Zero)

            thumbnail.Save(outputpath)
            originalImage.Dispose()
            thumbnail.Dispose()
            Return True
        Catch ex As Exception
            Return False
        End Try




    End Function




End Module
