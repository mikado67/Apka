Imports System.IO

Public Class LoggerCSV

    Private ReadOnly sciezka As String = "log.csv"

    Public Sub Zapisz(dane As Dictionary(Of String, String))

        Dim linia As String = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")

        For Each para In dane
            linia &= ";" & para.Value
        Next

        File.AppendAllText(sciezka, linia & Environment.NewLine)

    End Sub

End Class

