
Imports System.IO

Public Class Constants
    
    Public Const BASE_API_URL As String = "http://localhost:8000"
    Public Function WriteToFile(filepath As String, text As String, Optional append As Boolean = True)

        Dim file As StreamWriter = My.Computer.FileSystem.OpenTextFileWriter(filepath, append)
        file.WriteLine(text)
        file.Close()
        Console.WriteLine("Finished writing to file!")
        Return Nothing
    End Function

    Public Shared Function ImageToByte(ByVal image As Image) As Byte()
        Dim converter As New ImageConverter()
        Return converter.ConvertTo(image, GetType(Byte()))
    End Function
End Class
