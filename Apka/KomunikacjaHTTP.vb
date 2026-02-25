Imports System.Net.Http
Imports System.Text

Public Class KomunikacjaHTTP

    Private ReadOnly client As HttpClient

    Public Sub New()
        client = New HttpClient()
        client.Timeout = TimeSpan.FromSeconds(3)
    End Sub

    Public Async Function PobierzDane(ip As String, login As String, haslo As String) As Task(Of String)

        Dim url As String = "http://" & ip & "/?cmd=19"

        Dim authValue As String =
            Convert.ToBase64String(
            Encoding.ASCII.GetBytes(login & ":" & haslo))

        client.DefaultRequestHeaders.Authorization =
            New Headers.AuthenticationHeaderValue("Basic", authValue)

        Dim response As HttpResponseMessage = Await client.GetAsync(url)
        response.EnsureSuccessStatusCode()

        Return Await response.Content.ReadAsStringAsync()

    End Function

End Class

