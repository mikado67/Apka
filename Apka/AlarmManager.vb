Public Class AlarmManager

    Public Event AlarmWystapil()

    Public Sub SprawdzAlarm(dane As Dictionary(Of String, String))

        If dane.ContainsKey("awar") Then

            Dim awarValue As Integer

            If Integer.TryParse(dane("awar"), awarValue) Then
                If awarValue > 0 Then
                    RaiseEvent AlarmWystapil()
                End If
            End If

        End If

    End Sub

End Class
