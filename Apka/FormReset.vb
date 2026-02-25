Public Class FormReset

    Private _sekundy As Integer = 10
    Private ReadOnly tmr As New Timer()

    Public Sub New()
        InitializeComponent()
        Me.BackColor = Color.FromArgb(15, 15, 15)
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.ControlBox = False
        Me.StartPosition = FormStartPosition.CenterParent
        Me.TopMost = True

        tmr.Interval = 1000
        AddHandler tmr.Tick, AddressOf Tmr_Tick
    End Sub

    Public Sub StartOdliczanie()
        AktualizujNapis()
        tmr.Start()
    End Sub

    Private Sub Tmr_Tick(sender As Object, e As EventArgs)
        _sekundy -= 1
        AktualizujNapis()
        If _sekundy <= 0 Then
            tmr.Stop()
            Me.Close()
        End If
    End Sub

    Private Sub AktualizujNapis()
        lblKomunikat.Text = T("reset.czekaj") & $"  ({_sekundy} s)"
    End Sub

End Class
