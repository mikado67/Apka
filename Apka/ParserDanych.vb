Public Class ParserDanych

    Public Shared Function Parsuj(result As String) As Dictionary(Of String, String)

        Dim dane As New Dictionary(Of String, String)
        Dim elementy() As String = result.Split(","c)

        For Each el In elementy
            Dim czysty As String = el.Trim()

            If czysty.Contains("=") Then
                Dim para() As String = czysty.Split("="c)
                If para.Length = 2 Then
                    dane(para(0).Trim()) = para(1).Trim()
                End If
            End If
        Next

        Return dane

    End Function

End Class

