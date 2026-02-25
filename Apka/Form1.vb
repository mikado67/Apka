Imports System.Drawing.Drawing2D
Imports System.IO
Imports System.Linq
Imports System.Net.Http
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Threading
Imports System.Xml

Public Class Form1



    ' ═══════════════════════════════════════════════════════════════
    ' KOLORY / STAŁE
    ' ═══════════════════════════════════════════════════════════════
    Private ReadOnly TLO As Color = Color.FromArgb(15, 15, 15)
    Private ReadOnly ZIELONY As Color = Color.Lime
    Private ReadOnly OPIS As Color = Color.Silver
    Private ReadOnly PANEL As Color = Color.FromArgb(25, 25, 25)

    ' ═══════════════════════════════════════════════════════════════
    ' POLA KLASY
    ' ═══════════════════════════════════════════════════════════════
    Private czyOdswiezanieWTrakcie As Boolean = False
    Private sekundyDoOdswiezenia As Integer = 5
    Private polaczony As Boolean = False
    Private isDragging As Boolean = False
    Private mouseOffset As Point

    Private ReadOnly toolTipMigaj As New ToolTip()
    Private wszystkieGrupyAktywne As Boolean = False
    Private ReadOnly toolTipGrupy As New ToolTip()
    Private wszystkieGrupyAktywneTCP As Boolean = False
    Private _ctsPetlaTCP As CancellationTokenSource = Nothing
    Private ReadOnly toolTipGrupyTCP As New ToolTip()
    Private ReadOnly _grupyTCPAktywne As New HashSet(Of Integer)
    Private ReadOnly _grupyTCPHistoria As New Dictionary(Of Integer, DateTime)

    ' ── tabStanOpraw ──────────────────────────────────────────────
    Private _pobieranieOpraw As Boolean = False
    Private tmrOprawy As New System.Windows.Forms.Timer()

    Private ReadOnly handler As New HttpClientHandler() With {
        .UseCookies = True,
        .CookieContainer = New Net.CookieContainer()
    }
    Private httpClient As HttpClient

    Private csvConfig As DataTable


    ' ═══════════════════════════════════════════════════════════════
    ' MODEL OPRAWY
    ' ═══════════════════════════════════════════════════════════════
    Private Class Oprawa
        Public Property AdresLogiczny As Integer
        Public Property AdresFizyczny As Integer
        Public Property Grupa As Integer
        Public Property Lokalizacja As String
        Public Property Pn As Integer
        Public Property Tnu As Integer
        Public Property Monit As Integer
        Public Property Tspo As Integer
        Public Property Ok As Integer
        Public Property Paw As Integer
        Public Property Awz As Integer
        Public Property Akum As Integer
        Public Property Awlad As Integer
        Public Property Bl As Integer
        Public Property Ts As Integer
        Public Property Tcp As Integer
        Public Property Ots As String
        Public Property Otcp As String
        Public Property CzasStatusu As String
    End Class

    ' ═══════════════════════════════════════════════════════════════
    ' KONSTRUKTOR
    ' ═══════════════════════════════════════════════════════════════
    Public Sub New()
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint Or
                    ControlStyles.UserPaint Or
                    ControlStyles.OptimizedDoubleBuffer, True)
        Me.UpdateStyles()
        Me.BackColor = Color.FromArgb(15, 15, 15)
        InitializeComponent()
        httpClient = New HttpClient(handler) With {.Timeout = TimeSpan.FromSeconds(3)}
        Me.DoubleBuffered = True
        Me.Opacity = 0
    End Sub

    Private Sub UstawSzerokoscZakladek()
        tabMain.SizeMode = TabSizeMode.Fixed
        tabMain.ItemSize = New Size(160, 28)
    End Sub

    ' ═══════════════════════════════════════════════════════════════
    ' LOAD / SHOWN
    ' ═══════════════════════════════════════════════════════════════
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        btnPobierzKonfig.Text = T("csv.btn_pobierz")

        Me.FormBorderStyle = FormBorderStyle.FixedSingle
        Me.MaximizeBox = False

        tabMain.SelectedTab = tabStan
        tabMain.DrawMode = TabDrawMode.OwnerDrawFixed
        tabMain.SizeMode = TabSizeMode.Fixed
        tabMain.Multiline = True
        tabMain.ItemSize = New Size(140, 30)
        tabMain.Padding = New Point(15, 5)
        tabMain.BackColor = TLO

        For Each tp As TabPage In {tabStan, tabTS, tabStanOpraw, tabProgramowanie}
            tp.UseVisualStyleBackColor = False
            tp.BackColor = TLO
        Next

        ' ── Timer opraw ───────────────────────────────────────────
        tmrOprawy.Interval = 3000
        AddHandler tmrOprawy.Tick, Async Sub(s, ev)
                                       If tabMain.SelectedTab Is tabStanOpraw AndAlso Not _pobieranieOpraw Then
                                           Await OdswiezOprawy()
                                       End If
                                   End Sub
    End Sub

    Private Async Sub Form1_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        For i = 0 To 10
            Me.Opacity = i / 10.0
            Await Task.Delay(30)
        Next

        UstawTrybSCADA()
        UstawLEDShape()
        UstawToggle()
        UstawToggleTCP()
        UstawSzerokoscZakladek()
        InicjalizujPanelPodsumowania()
        OdswiezTlumaczenia()

        txtIP.Font = New Font("Consolas", 12, FontStyle.Bold)
        txtIP.TextAlign = HorizontalAlignment.Center
        txtLogin.Text = "PUSER"
        txtPassword.Text = "power"

        lblStatus.Text = T("status.brak_polaczenia")
        lblStatus.ForeColor = OPIS
        UstawLED(Color.Gray)
        AktualizujStanPrzyciskow()

        CurrentJezyk = Jezyk.PL
        OdswiezTlumaczenia()
        PodswietlAktywnyJezyk(btnLangPL)

        InicjalizujDgvOprawy()
    End Sub



    ' ═══════════════════════════════════════════════════════════════
    ' JĘZYK – FLAGI
    ' ═══════════════════════════════════════════════════════════════
    Private Sub btnLangPL_Click(sender As Object, e As EventArgs) Handles btnLangPL.Click
        CurrentJezyk = Jezyk.PL
        OdswiezTlumaczenia()
        PodswietlAktywnyJezyk(btnLangPL)
    End Sub

    Private Sub btnLangEN_Click(sender As Object, e As EventArgs) Handles btnLangEN.Click
        CurrentJezyk = Jezyk.EN
        OdswiezTlumaczenia()
        PodswietlAktywnyJezyk(btnLangEN)
    End Sub

    Private Sub btnLangDE_Click(sender As Object, e As EventArgs) Handles btnLangDE.Click
        CurrentJezyk = Jezyk.DE
        OdswiezTlumaczenia()
        PodswietlAktywnyJezyk(btnLangDE)
    End Sub

    Private Sub PodswietlAktywnyJezyk(aktywny As Button)
        For Each btn As Button In {btnLangPL, btnLangEN, btnLangDE}
            btn.FlatAppearance.BorderColor = Color.DimGray
            btn.BackColor = PANEL
        Next
        aktywny.FlatAppearance.BorderColor = ZIELONY
        aktywny.BackColor = Color.FromArgb(0, 60, 0)
    End Sub

    ' ═══════════════════════════════════════════════════════════════
    ' ODŚWIEŻ TŁUMACZENIA
    ' ═══════════════════════════════════════════════════════════════
    Private Sub OdswiezTlumaczenia()
        Label1.Text = T("stan.lbl_adres_ip")
        lblLogin.Text = T("stan.lbl_login")
        lblHasło.Text = T("stan.lbl_haslo")
        lblOdpowiedzStanOpis.Text = T("stan.lbl_odpowiedz")
        btnConnect.Text = T("stan.btn_polacz")
        btnDisconnect.Text = T("stan.btn_rozlacz")
        btnExit.Text = T("stan.btn_zamknij")
        lblOdświeżanie.Text = T("status.odswiezanie")
        btnPobierzKonfig.Text = T("csv.btn_pobierz")
        LblSutc.Text = T("stan.sutc")
        LblAwar.Text = T("stan.awar")
        LblPraw.Text = T("stan.praw")
        LblPrtn.Text = T("stan.prtn")
        LblWykl.Text = T("stan.wykl")
        LblFirm.Text = T("stan.firm")
        LblPcbv.Text = T("stan.pcbv")
        LblRtime.Text = T("stan.rtime")
        LblMPE12.Text = T("stan.mpe12")
        LblSiec.Text = T("stan.siec")
        LblUps.Text = T("stan.ups")
        Lblbat.Text = T("stan.bat")
        LblInne.Text = T("stan.inne")
        LblBlok.Text = T("stan.blok")

        lblNrGrupy.Text = T("ts.lbl_nr_grupy")
        lblWszystkieGrupy.Text = T("ts.lbl_wszystkie")
        lblIloscGrup.Text = T("ts.lbl_ilosc")
        btnWyslij.Text = T("ts.btn_wyslij")
        btnUtworzGrupy.Text = T("ts.btn_utworz")
        btnReset.Text = T("ts.btn_reset")

        lblNrGrupyTCP.Text = T("tcp.lbl_nr_grupy")
        lblWszystkieGrupyTCP.Text = T("tcp.lbl_wszystkie")
        lblIloscGrupTCP.Text = T("tcp.lbl_ilosc")
        btnWyslijTCPStart.Text = T("tcp.btn_start")
        btnWyslijTCPStop.Text = T("tcp.btn_stop")
        btnUtworzGrupyTCP.Text = T("tcp.btn_utworz")
        btnResetTCP.Text = T("tcp.btn_reset")

        lblNrGrupyMigaj.Text = T("migaj.lbl_nr_grupy")
        lblNrOprawyMigaj.Text = T("migaj.lbl_nr_oprawy")
        btnWyslijMigajStart.Text = T("migaj.btn_start")
        btnWyslijMigajStop.Text = T("migaj.btn_stop")

        lblHistoriaOpis.Text = T("ts.historia")
        btnCzyscHistorie.Text = T("ts.btn_czasc")

        tabStan.Text = T("tab.stan")
        tabTS.Text = T("tab.ts")
        tabStanOpraw.Text = T("tab.stanopraw")
        tabProgramowanie.Text = T("tab.programowanie")
        tabMain.Invalidate()

        OtwórzToolStripMenuItem.Text = T("tray.otworz")
        ZamknijToolStripMenuItem.Text = T("tray.zamknij")
        btnResetCentralki.Text = T("reset.btn")

        If Not polaczony Then
            lblStatus.Text = T("status.brak_polaczenia")
        End If

        ' ── tabStanOpraw ──────────────────────────────────────────
        btnOdswiezOprawy.Text = T("op.btn_odswież")
        lblLicznikOpraw.Text = T("op.lbl_licznik") & " " & dgvOprawy.Rows.Count.ToString()

        If dgvOprawy.Columns.Count = 9 Then
            dgvOprawy.Columns("adl").HeaderText = T("op.col.adl")
            dgvOprawy.Columns("adf").HeaderText = T("op.col.adf")
            dgvOprawy.Columns("gr").HeaderText = T("op.col.gr")
            dgvOprawy.Columns("opi").HeaderText = T("op.col.opi")
            dgvOprawy.Columns("pn").HeaderText = T("op.col.pn")
            dgvOprawy.Columns("tnu").HeaderText = T("op.col.tnu")
            dgvOprawy.Columns("monit").HeaderText = T("op.col.monit")
            dgvOprawy.Columns("stan").HeaderText = T("op.col.stan")
            dgvOprawy.Columns("dsta").HeaderText = T("op.col.dsta")
            If dgvOprawy.Rows.Count > 0 Then PrzeliczStanyOpraw()
        End If

        UstawToggle()
        UstawToggleTCP()
    End Sub

    ' ═══════════════════════════════════════════════════════════════
    ' TRAY ICON
    ' ═══════════════════════════════════════════════════════════════
    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If Me.WindowState = FormWindowState.Minimized Then
            trayIcon.Visible = True
            Me.Hide()
        End If
    End Sub

    Private Sub PrzywrocOkno()
        If Me.InvokeRequired Then
            Me.Invoke(New MethodInvoker(AddressOf PrzywrocOkno))
            Return
        End If
        Me.Show()
        Me.WindowState = FormWindowState.Normal
        Me.Activate()
        trayIcon.Visible = False
    End Sub

    Private Sub trayIcon_DoubleClick(sender As Object, e As EventArgs) Handles trayIcon.DoubleClick
        PrzywrocOkno()
    End Sub

    Private Sub OtwórzToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OtwórzToolStripMenuItem.Click
        PrzywrocOkno()
    End Sub

    Private Sub ZamknijToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ZamknijToolStripMenuItem.Click
        trayIcon.Visible = False
        Application.Exit()
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            e.Cancel = True
            Me.WindowState = FormWindowState.Minimized
        End If
    End Sub

    ' ═══════════════════════════════════════════════════════════════
    ' PRZYCISKI GŁÓWNE
    ' ═══════════════════════════════════════════════════════════════
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Application.Exit()
    End Sub

    Private Async Sub btnConnect_Click(sender As Object, e As EventArgs) Handles btnConnect.Click
        Await PolaczZSerwerem()
    End Sub

    Private Sub btnDisconnect_Click(sender As Object, e As EventArgs) Handles btnDisconnect.Click
        tmrRefresh.Stop()
        tmrOprawy.Stop()
        sekundyDoOdswiezenia = 5
        lblCountdown.Text = "-"
        UstawLED(Color.Gray)
        lblStatus.Text = T("status.rozlaczono")
        lblStatus.ForeColor = OPIS
        txtOdpowiedzStan.Text = ""
        WyczyśćDane()
        dgvOprawy.Rows.Clear()
        lblLicznikOpraw.Text = T("op.lbl_licznik") & " 0"
        pnlOdswiezStatus.BackColor = Color.Gray
        polaczony = False
        AktualizujStanPrzyciskow()
    End Sub

    Private Sub AktualizujStanPrzyciskow()
        btnConnect.Enabled = Not polaczony
        btnDisconnect.Enabled = polaczony

        If polaczony Then
            btnConnect.BackColor = Color.DarkGreen
            btnConnect.ForeColor = Color.Black
            btnDisconnect.BackColor = Color.Orange
            btnDisconnect.ForeColor = Color.Black
        Else
            btnConnect.BackColor = PANEL
            btnConnect.ForeColor = ZIELONY
            btnDisconnect.BackColor = PANEL
            btnDisconnect.ForeColor = Color.Orange
        End If
    End Sub

    ' ═══════════════════════════════════════════════════════════════
    ' TIMER GŁÓWNY
    ' ═══════════════════════════════════════════════════════════════
    Private Async Sub tmrRefresh_Tick(sender As Object, e As EventArgs) Handles tmrRefresh.Tick
        If czyOdswiezanieWTrakcie Then Exit Sub
        sekundyDoOdswiezenia -= 1
        lblCountdown.Text = sekundyDoOdswiezenia.ToString() & " s"
        If sekundyDoOdswiezenia <= 0 Then
            czyOdswiezanieWTrakcie = True
            Await PolaczZSerwerem()
            czyOdswiezanieWTrakcie = False
            sekundyDoOdswiezenia = 5
        End If
    End Sub

    ' ═══════════════════════════════════════════════════════════════
    ' POŁĄCZENIE Z SERWEREM
    ' ═══════════════════════════════════════════════════════════════
    Private Async Function PolaczZSerwerem() As Task
        Dim login As String = txtLogin.Text.Trim()
        Dim haslo As String = txtPassword.Text.Trim()

        If String.IsNullOrWhiteSpace(login) OrElse String.IsNullOrWhiteSpace(haslo) Then
            MessageBox.Show(T("err.podaj_login"))
            Return
        End If

        Dim ip As String = txtIP.Text.Trim()
        If ip = "" Then
            MessageBox.Show(T("err.podaj_ip"))
            Return
        End If

        Dim ipTest As Net.IPAddress
        If Not Net.IPAddress.TryParse(ip, ipTest) Then
            MessageBox.Show(T("err.nieprawidlowy_ip"))
            Return
        End If

        Dim authValue As String = Convert.ToBase64String(
            Encoding.ASCII.GetBytes(login & ":" & haslo))
        httpClient.DefaultRequestHeaders.Authorization =
            New Headers.AuthenticationHeaderValue("Basic", authValue)

        Try
            Dim response As HttpResponseMessage = Await httpClient.GetAsync(
                $"http://{ip}/?cmd=19")
            response.EnsureSuccessStatusCode()
            Dim result As String = Await response.Content.ReadAsStringAsync()

            txtOdpowiedzStan.Text = result
            UstawLED(Color.Lime)
            lblStatus.Text = T("status.polaczono")
            lblStatus.ForeColor = OPIS
            polaczony = True
            AktualizujStanPrzyciskow()
            sekundyDoOdswiezenia = 5
            tmrRefresh.Start()
            ParsujOdpowiedz(result)

            ' ── Pierwsze pobranie opraw + start timera ─────────────
            If Not tmrOprawy.Enabled Then
                Await OdswiezOprawy()
                tmrOprawy.Start()
            End If

        Catch ex As Exception
            UstawLED(Color.Red)
            lblStatus.Text = T("status.brak_polaczenia")
            lblStatus.ForeColor = OPIS
            txtOdpowiedzStan.Text = ""
            WyczyśćDane()
            tmrRefresh.Stop()
            tmrOprawy.Stop()
            lblCountdown.Text = "-"
            sekundyDoOdswiezenia = 5
            polaczony = False
            AktualizujStanPrzyciskow()
            Debug.WriteLine(ex.ToString())
        End Try
    End Function

    ' ═══════════════════════════════════════════════════════════════
    ' PARSOWANIE ODPOWIEDZI GŁÓWNEJ
    ' ═══════════════════════════════════════════════════════════════
    Private Sub ParsujOdpowiedz(result As String)
        Dim dane As New Dictionary(Of String, String)(StringComparer.OrdinalIgnoreCase)

        For Each el In result.Split(","c)
            Dim czysty As String = el.Trim()
            Dim idx As Integer = czysty.IndexOf("="c)
            If idx > 0 Then
                dane(czysty.Substring(0, idx).Trim()) = czysty.Substring(idx + 1).Trim()
            End If
        Next

        Dim v As String = Nothing

        If dane.TryGetValue("sutc", v) Then
            Dim unixTime As Long
            If Long.TryParse(v, unixTime) Then
                Label4.Text = DateTimeOffset.FromUnixTimeSeconds(unixTime) _
                                            .LocalDateTime.ToString("yyyy-MM-dd HH:mm:ss")
            End If
        End If

        If dane.TryGetValue("awar", v) Then
            Label5.Text = If(v = "1", T("wartosc.tak"), T("wartosc.nie"))
            Label5.ForeColor = If(v = "1", Color.Red, ZIELONY)
        End If

        If dane.TryGetValue("praw", v) Then
            Label6.Text = If(v = "1", T("wartosc.tak"), T("wartosc.nie"))
            Label6.ForeColor = If(v = "1", Color.Red, ZIELONY)
        End If

        If dane.TryGetValue("prtn", v) Then
            Label7.Text = If(v = "1", T("wartosc.tak"), T("wartosc.nie"))
            Label7.ForeColor = If(v = "1", Color.Orange, ZIELONY)
        End If

        If dane.TryGetValue("wykl", v) Then
            Label8.Text = If(v = "1", T("wartosc.tak"), T("wartosc.nie"))
            Label8.ForeColor = If(v = "1", Color.Orange, ZIELONY)
        End If

        If dane.TryGetValue("firm", v) Then Label9.Text = v
        If dane.TryGetValue("pcbv", v) Then Label10.Text = v

        If dane.TryGetValue("rtime", v) Then
            Dim seconds As Long
            If Long.TryParse(v, seconds) Then
                Dim ts As TimeSpan = TimeSpan.FromSeconds(seconds)
                Label11.Text = $"{ts.Days} dni {ts.Hours:00} h {ts.Minutes:00} min"
            End If
        End If

        If dane.TryGetValue("siec", v) Then Label12.Text = v
        If dane.TryGetValue("ups", v) Then Label13.Text = v
        If dane.TryGetValue("bat", v) Then Label14.Text = v
        If dane.TryGetValue("inne", v) Then Label15.Text = v
        If dane.TryGetValue("blok", v) Then Label16.Text = v
    End Sub

    Private Sub WyczyśćDane()
        For Each lbl As Label In {Label4, Label5, Label6, Label7,
                                   Label8, Label9, Label10, Label11,
                                   Label12, Label13, Label14, Label15, Label16}
            lbl.Text = "n/d"
        Next
    End Sub

    ' ═══════════════════════════════════════════════════════════════
    ' tabStanOpraw – INICJALIZACJA TABELI
    ' ═══════════════════════════════════════════════════════════════
    Private Sub InicjalizujDgvOprawy()
        dgvOprawy.Columns.Clear()

        Dim kolumny() As (String, String, Integer) = {
        ("adl", T("op.col.adl"), 66),
        ("adf", T("op.col.adf"), 88),
        ("gr", T("op.col.gr"), 55),
        ("opi", T("op.col.opi"), 220),
        ("pn", T("op.col.pn"), 110),
        ("tnu", T("op.col.tnu"), 110),
        ("monit", T("op.col.monit"), 110),
        ("stan", T("op.col.stan"), 176),
        ("dsta", T("op.col.dsta"), 176)
    }

        For Each k In kolumny
            dgvOprawy.Columns.Add(k.Item1, k.Item2)
            Dim col = dgvOprawy.Columns(k.Item1)
            col.Width = CInt(k.Item3 * 1.1)
            col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Next

        dgvOprawy.Columns("opi").DefaultCellStyle.WrapMode = DataGridViewTriState.True
        dgvOprawy.Columns("opi").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvOprawy.Columns("stan").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvOprawy.Columns("dsta").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    End Sub

    ' ═══════════════════════════════════════════════════════════════
    ' tabStanOpraw – INICJALIZACJA PANELU PODSUMOWANIA       ← TUTAJ
    ' ═══════════════════════════════════════════════════════════════
    Private Sub InicjalizujPanelPodsumowania()
        Dim xPos As Integer = 10

        pnlSummary = New Panel()
        pnlSummary.Location = New Point(0, 46)
        pnlSummary.Size = New Size(tabStanOpraw.Width, 36)
        pnlSummary.BackColor = Color.FromArgb(35, 35, 38)
        pnlSummary.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        tabStanOpraw.Controls.Add(pnlSummary)

        Dim AddLbl = Sub(ByRef lbl As Label, txt As String)
                         lbl = New Label()
                         lbl.Text = txt
                         lbl.AutoSize = True
                         lbl.Font = New Font("Consolas", 9.0F, FontStyle.Bold)
                         lbl.ForeColor = Color.FromArgb(180, 180, 180)
                         lbl.BackColor = Color.Transparent
                         lbl.Location = New Point(xPos, 10)
                         pnlSummary.Controls.Add(lbl)
                         xPos += lbl.PreferredWidth + 25
                     End Sub

        AddLbl(lblSumTotal, "Oprawy: -")
        AddLbl(lblSumTPN, "TPN aktywny: -")
        AddLbl(lblSumSwiecTPN, "Świeci w TPN: -")
        AddLbl(lblSumMonit, "Monitorowane: -")
        AddLbl(lblSumSprawna, "Sprawne: -")
        AddLbl(lblSumInne, "Inne stany: -")

        dgvOprawy.Location = New Point(0, 82)
        dgvOprawy.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        dgvOprawy.Height = tabStanOpraw.Height - 82
    End Sub


    ' ═══════════════════════════════════════════════════════════════
    ' tabStanOpraw – PRZYCISK ODŚWIEŻ
    ' ═══════════════════════════════════════════════════════════════
    Private Async Sub btnOdswiezOprawy_Click(sender As Object, e As EventArgs) _
    Handles btnOdswiezOprawy.Click
        btnOdswiezOprawy.Enabled = False
        Await OdswiezOprawy()
        btnOdswiezOprawy.Enabled = True
    End Sub


    ' ═══════════════════════════════════════════════════════════════
    ' tabStanOpraw – POBIERANIE XML
    ' ═══════════════════════════════════════════════════════════════
    Private Async Function OdswiezOprawy() As Task
        If Not polaczony Then Return
        Dim ip As String = txtIP.Text.Trim()
        If String.IsNullOrEmpty(ip) Then Return

        _pobieranieOpraw = True
        Try
            Dim url As String = $"http://{ip}/oprawy.xml"
            Dim xmlText As String = Await httpClient.GetStringAsync(url)
            Dim oprawy As List(Of Oprawa) = ParsujOprawy(xmlText)
            ZaladujTabeleOpraw(oprawy)
        Catch ex As Exception
            pnlOdswiezStatus.BackColor = Color.Red
            Debug.WriteLine($"OdswiezOprawy błąd: {ex.Message}")
        Finally
            _pobieranieOpraw = False
        End Try
    End Function

    ' ═══════════════════════════════════════════════════════════════
    ' tabStanOpraw – PARSOWANIE XML
    ' ═══════════════════════════════════════════════════════════════
    Private Function ParsujOprawy(xmlText As String) As List(Of Oprawa)
        Dim lista As New List(Of Oprawa)
        Dim doc As New XmlDocument()
        doc.LoadXml(xmlText)

        For Each node As XmlNode In doc.SelectNodes("//op")
            Dim op As New Oprawa()
            op.AdresLogiczny = ParseInt(node("adl"))
            op.AdresFizyczny = ParseInt(node("adf"))
            op.Grupa = ParseInt(node("gr"))
            op.Lokalizacja = SanityzujOpis(node("opi")?.InnerText)
            op.Pn = ParseInt(node("pn"))
            op.Tnu = ParseInt(node("tnu"))
            op.Monit = ParseInt(node("monit"))
            op.Tspo = ParseInt(node("tspo"))
            op.Ok = ParseInt(node("ok"))
            op.Paw = ParseInt(node("paw"))
            op.Awz = ParseInt(node("awz"))
            op.Akum = ParseInt(node("akum"))
            op.Awlad = ParseInt(node("awlad"))
            op.Bl = ParseInt(node("bl"))
            op.Ts = ParseInt(node("ts"))
            op.Tcp = ParseInt(node("tcp"))
            op.Ots = node("ots")?.InnerText
            op.Otcp = node("otcp")?.InnerText
            op.CzasStatusu = UnixNaCzas(node("dsta")?.InnerText)
            lista.Add(op)
        Next
        Return lista
    End Function

    Private Function ParseInt(node As XmlNode) As Integer
        If node Is Nothing Then Return 0
        Dim v As Integer
        Integer.TryParse(node.InnerText, v)
        Return v
    End Function

    Private Function SanityzujOpis(raw As String) As String
        If String.IsNullOrEmpty(raw) Then Return ""
        Dim czysty As String = Regex.Replace(raw, "[^A-Za-z0-9 ]", "")
        Return If(czysty.Length > 27, czysty.Substring(0, 27), czysty)
    End Function

    Private Function UnixNaCzas(raw As String) As String
        Dim ts As Long
        If Long.TryParse(raw, ts) AndAlso ts > 0 Then
            Return DateTimeOffset.FromUnixTimeSeconds(ts).LocalDateTime.ToString("yyyy-MM-dd HH:mm:ss")
        End If
        Return "-"
    End Function

    ' ═══════════════════════════════════════════════════════════════
    ' tabStanOpraw – LOGIKA STANU
    ' ═══════════════════════════════════════════════════════════════
    Private Function GetStanOprawy(op As Oprawa) As String
        If op.Tspo = 1 Then Return T("op.stan.spoczynek")
        If op.Paw = 1 Then Return T("op.stan.praca_aw")
        If op.Awz = 1 Then Return T("op.stan.awaria_zrodla")
        If op.Akum = 3 Then Return T("op.stan.brak_akum")
        If op.Akum = 1 Then Return T("op.stan.slaby_akum")
        If op.Awlad = 1 Then Return T("op.stan.awaria_klad")
        If op.Bl = 1 Then Return T("op.stan.blokada")
        If op.Ts = 1 Then Return T("op.stan.test_ts")
        If op.Tcp = 1 Then Return T("op.stan.test_tcp")
        If op.Ots = "1" Then Return T("op.stan.odrocz_ts")
        If op.Otcp = "1" Then Return T("op.stan.odrocz_tcp")
        If op.Ok = 1 Then Return T("op.stan.sprawna")
        Return T("op.stan.brak_kom")
    End Function

    Private Sub ZaladujTabeleOpraw(oprawy As List(Of Oprawa))
        dgvOprawy.Rows.Clear()

        For Each op In oprawy
            Dim idx As Integer = dgvOprawy.Rows.Add(
            op.AdresLogiczny,
            op.AdresFizyczny,
            op.Grupa,
            op.Lokalizacja,
            If(op.Pn = 1, T("wartosc.nie"), T("wartosc.tak")),
            If(op.Tnu = 1, T("wartosc.tak"), T("wartosc.nie")),
            If(op.Monit = 1, T("wartosc.tak"), T("wartosc.nie")),
            GetStanOprawy(op),
            op.CzasStatusu
        )

            Dim row As DataGridViewRow = dgvOprawy.Rows(idx)
            row.Tag = op
            KolorujWiersz(row, op)
        Next

        lblLicznikOpraw.Text = T("op.lbl_licznik") & " " & oprawy.Count.ToString()
        lblOdswiezOpis.Text = T("op.lbl_ostatnie") & " " & DateTime.Now.ToString("HH:mm:ss")
        pnlOdswiezStatus.BackColor = Color.FromArgb(39, 174, 96)
        AktualizujPodsumowanie(oprawy)   ' ← DODANE
    End Sub

    ' ═══════════════════════════════════════════════════════════════
    ' tabStanOpraw – PODSUMOWANIE
    ' ═══════════════════════════════════════════════════════════════
    Private Sub AktualizujPodsumowanie(oprawy As List(Of Oprawa))
        ' Guard — jeśli kontrolki jeszcze nie zainicjalizowane
        If lblSumTotal Is Nothing OrElse
       lblSumTPN Is Nothing OrElse
       lblSumSwiecTPN Is Nothing OrElse
       lblSumMonit Is Nothing OrElse
       lblSumSprawna Is Nothing OrElse
       lblSumInne Is Nothing Then Return

        Dim total As Integer = oprawy.Count
        Dim tpnAkt As Integer = oprawy.Where(Function(o) o.Tnu = 1).Count()
        Dim swiecTPN As Integer = oprawy.Where(Function(o) o.Pn = 1).Count()
        Dim monit As Integer = oprawy.Where(Function(o) o.Monit = 1).Count()
        Dim sprawne As Integer = oprawy.Where(Function(o) GetStanOprawy(o) = T("op.stan.sprawna")).Count()
        Dim inne As Integer = total - sprawne

        lblSumTotal.Text = $"Oprawy: {total}"
        lblSumTPN.Text = $"TPN aktywny: {tpnAkt}"
        lblSumSwiecTPN.Text = $"Świeci w TPN: {swiecTPN}"
        lblSumMonit.Text = $"Monitorowane: {monit}"

        lblSumSprawna.Text = $"Sprawne: {sprawne}"
        lblSumSprawna.ForeColor = If(sprawne = total AndAlso total > 0,
                                 Color.Lime, Color.FromArgb(180, 180, 180))

        lblSumInne.Text = $"Inne stany: {inne}"
        lblSumInne.ForeColor = If(inne > 0, Color.OrangeRed, Color.Lime)
    End Sub



    ' ═══════════════════════════════════════════════════════════════
    ' tabStanOpraw – KOLOROWANIE WIERSZA
    ' ═══════════════════════════════════════════════════════════════
    Private Sub KolorujWiersz(row As DataGridViewRow, op As Oprawa)
        Dim bg As Color
        Dim fg As Color = Color.White

        Select Case True
            Case op.Tspo = 1
                bg = Color.FromArgb(30, 30, 100)         ' granatowy — spoczynek
            Case op.Paw = 1
                bg = Color.FromArgb(230, 126, 34)        ' pomarańczowy — praca aw.
            Case op.Awz = 1
                bg = Color.FromArgb(152, 0, 76)          ' malinowy — awaria źródła
            Case op.Akum = 3
                bg = Color.FromArgb(192, 57, 43)         ' czerwony — brak akum
            Case op.Akum = 1
                bg = Color.FromArgb(180, 140, 0)         ' żółty — słaby akum
                fg = Color.FromArgb(30, 30, 30)
            Case op.Awlad = 1
                bg = Color.FromArgb(130, 80, 0)          ' brązowy — awaria ładowania
            Case op.Bl = 1
                bg = Color.FromArgb(63, 63, 70)          ' szary — blokada
                fg = Color.FromArgb(200, 200, 200)
            Case op.Ts = 1 OrElse op.Tcp = 1
                bg = Color.FromArgb(0, 80, 120)          ' niebieski — trwa test
            Case op.Monit = 0
                bg = Color.FromArgb(50, 50, 53)          ' ciemny szary — brak monit.
                fg = Color.FromArgb(150, 150, 150)
            Case op.Ok = 1
                bg = Color.FromArgb(39, 174, 96)         ' zielony — sprawna
            Case Else
                bg = Color.FromArgb(80, 40, 40)          ' ciemny — brak komunikacji
        End Select

        row.DefaultCellStyle.BackColor = bg
        row.DefaultCellStyle.ForeColor = fg
    End Sub


    ' ═══════════════════════════════════════════════════════════════
    ' tabStanOpraw – PRZELICZ STANY PO ZMIANIE JĘZYKA
    ' ═══════════════════════════════════════════════════════════════
    Private Sub PrzeliczStanyOpraw()
        For Each row As DataGridViewRow In dgvOprawy.Rows
            Dim op As Oprawa = TryCast(row.Tag, Oprawa)
            If op Is Nothing Then Continue For
            row.Cells("pn").Value = If(op.Pn = 1, T("wartosc.nie"), T("wartosc.tak"))
            row.Cells("tnu").Value = If(op.Tnu = 1, T("wartosc.tak"), T("wartosc.nie"))
            row.Cells("monit").Value = If(op.Monit = 1, T("wartosc.tak"), T("wartosc.nie"))
            row.Cells("stan").Value = GetStanOprawy(op)
        Next
    End Sub

    ' ═══════════════════════════════════════════════════════════════
    ' LED
    ' ═══════════════════════════════════════════════════════════════
    Private Sub UstawLEDShape()
        If pnlStatus.Width > 0 AndAlso pnlStatus.Height > 0 Then
            Dim path As New GraphicsPath()
            path.AddEllipse(0, 0, pnlStatus.Width - 1, pnlStatus.Height - 1)
            pnlStatus.Region = New Region(path)
        End If
    End Sub

    Private Sub pnlStatus_Resize(sender As Object, e As EventArgs) Handles pnlStatus.Resize
        UstawLEDShape()
    End Sub

    Private Sub UstawLED(kolor As Color)
        pnlStatus.BackColor = kolor
    End Sub

    ' ═══════════════════════════════════════════════════════════════
    ' STYL SCADA
    ' ═══════════════════════════════════════════════════════════════
    Private Sub UstawTrybSCADA()
        Me.BackColor = TLO
        StylujKontrolkiRekurencyjnie(Me)
    End Sub

    Private Sub StylujKontrolkiRekurencyjnie(parent As Control)
        For Each ctrl As Control In parent.Controls
            StylSCADA(ctrl)
            If ctrl.HasChildren Then StylujKontrolkiRekurencyjnie(ctrl)
        Next
    End Sub

    Private Sub StylSCADA(ctrl As Control)
        Select Case True
            Case TypeOf ctrl Is TabControl
                ctrl.BackColor = TLO
                ctrl.ForeColor = ZIELONY

            Case TypeOf ctrl Is TabPage
                ctrl.BackColor = TLO

            Case TypeOf ctrl Is Panel
                If ctrl.Name <> "pnlStatus" AndAlso
                   ctrl.Name <> "pnlOdswiezStatus" Then
                    ctrl.BackColor = PANEL
                End If

            Case TypeOf ctrl Is Label
                ctrl.BackColor = Color.Transparent
                ctrl.Font = New Font("Consolas", 10, FontStyle.Bold)
                Dim nr As Integer
                If ctrl.Name.StartsWith("Label") AndAlso
                   Integer.TryParse(ctrl.Name.Substring(5), nr) AndAlso
                   nr >= 4 AndAlso nr <= 16 Then
                    ctrl.ForeColor = ZIELONY
                Else
                    ctrl.ForeColor = OPIS
                End If

            Case TypeOf ctrl Is TextBox
                Dim tb As TextBox = CType(ctrl, TextBox)
                tb.BackColor = PANEL
                tb.ForeColor = ZIELONY
                tb.BorderStyle = BorderStyle.FixedSingle
                tb.Font = New Font("Consolas", 10, FontStyle.Bold)

            Case TypeOf ctrl Is ListBox
                Dim lb As ListBox = CType(ctrl, ListBox)
                lb.BackColor = PANEL
                lb.ForeColor = ZIELONY
                lb.BorderStyle = BorderStyle.FixedSingle
                lb.Font = New Font("Consolas", 9, FontStyle.Regular)

            Case TypeOf ctrl Is DataGridView
                ' DGV ma własny styl SCADA — nie nadpisujemy
                Exit Select

            Case TypeOf ctrl Is Button
                Dim btn As Button = CType(ctrl, Button)
                btn.FlatStyle = FlatStyle.Flat
                btn.FlatAppearance.BorderColor = Color.DimGray

                Select Case btn.Name
                    Case "btnExit"
                        btn.BackColor = PANEL
                        btn.ForeColor = Color.Red
                        btn.FlatAppearance.BorderColor = Color.Red
                    Case "btnDisconnect"
                        btn.BackColor = PANEL
                        btn.ForeColor = Color.Orange
                        btn.FlatAppearance.BorderColor = Color.Orange
                    Case "btnWyslijTCPStop"
                        btn.BackColor = PANEL
                        btn.ForeColor = Color.OrangeRed
                        btn.FlatAppearance.BorderColor = Color.OrangeRed
                    Case "btnWyslijMigajStop"
                        btn.BackColor = PANEL
                        btn.ForeColor = Color.OrangeRed
                        btn.FlatAppearance.BorderColor = Color.OrangeRed
                    Case "btnLangPL", "btnLangEN", "btnLangDE"
                        btn.BackColor = PANEL
                        btn.ForeColor = Color.White
                        btn.Font = New Font("Segoe UI Emoji", 16, FontStyle.Regular)
                    Case "btnResetCentralki"
                        btn.BackColor = PANEL
                        btn.ForeColor = Color.DodgerBlue
                        btn.FlatAppearance.BorderColor = Color.DodgerBlue
                    Case "btnOdswiezOprawy"
                        btn.BackColor = Color.FromArgb(0, 122, 204)
                        btn.ForeColor = Color.White
                        btn.FlatAppearance.BorderColor = Color.FromArgb(0, 122, 204)
                        btn.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
                    Case Else
                        btn.BackColor = PANEL
                        btn.ForeColor = ZIELONY
                End Select
        End Select
    End Sub

    ' ═══════════════════════════════════════════════════════════════
    ' TABCONTROL – RYSOWANIE ZAKŁADEK
    ' ═══════════════════════════════════════════════════════════════
    Private Sub tabMain_DrawItem(sender As Object, e As DrawItemEventArgs) Handles tabMain.DrawItem
        Dim g As Graphics = e.Graphics
        Dim rect As Rectangle = e.Bounds
        Dim tab As TabPage = tabMain.TabPages(e.Index)
        Dim isSelected As Boolean = (e.State And DrawItemState.Selected) = DrawItemState.Selected

        If isSelected Then rect.Y += 2

        Using br As New SolidBrush(If(isSelected, PANEL, TLO))
            g.FillRectangle(br, rect)
        End Using

        TextRenderer.DrawText(g, tab.Text,
            New Font("Consolas", 10, FontStyle.Bold),
            rect,
            If(isSelected, ZIELONY, OPIS),
            TextFormatFlags.HorizontalCenter Or TextFormatFlags.VerticalCenter)
    End Sub

    Protected Overrides Sub OnPaintBackground(e As PaintEventArgs)
        MyBase.OnPaintBackground(e)
        Using br As New SolidBrush(TLO)
            e.Graphics.FillRectangle(br, 0, 0, Me.ClientSize.Width, tabMain.Top + 3)
        End Using
    End Sub

    ' ═══════════════════════════════════════════════════════════════
    ' DRAG OKNA
    ' ═══════════════════════════════════════════════════════════════
    Private Sub Form1_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        If e.Button <> MouseButtons.Left Then Return
        isDragging = True
        mouseOffset = New Point(-e.X, -e.Y)
    End Sub

    Private Sub Form1_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        If Not isDragging Then Return
        Dim mousePos As Point = Control.MousePosition
        mousePos.Offset(mouseOffset.X, mouseOffset.Y)
        Me.Location = mousePos
    End Sub

    Private Sub Form1_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp
        isDragging = False
    End Sub

    ' ═══════════════════════════════════════════════════════════════
    ' KODER GRUP 0–127 → 128-bit HEX
    ' ═══════════════════════════════════════════════════════════════
    Private Function KodujGrupa(numer As Integer) As String
        If numer < 0 OrElse numer > 127 Then
            Throw New ArgumentException("Numer musi być w zakresie 0–127.")
        End If

        Dim bytes(15) As Byte
        bytes(numer \ 8) = CByte(1 << (7 - (numer Mod 8)))

        Dim sb As New StringBuilder()
        For i As Integer = 0 To 15
            sb.Append(bytes(i).ToString("X2"))
        Next
        Return sb.ToString()
    End Function

    ' ═══════════════════════════════════════════════════════════════
    ' WYSYŁANIE KOMENDY HTTP
    ' ═══════════════════════════════════════════════════════════════
    Private Async Function WyslijKomende(cmd As String, parametr As String) As Task(Of String)
        Dim url As String = $"http://{txtIP.Text.Trim()}/?cmd={cmd}&par01={parametr}"
        Try
            Dim response As HttpResponseMessage = Await httpClient.GetAsync(url)
            Return Await response.Content.ReadAsStringAsync()
        Catch ex As HttpRequestException
            Debug.WriteLine($"WyslijKomende błąd: {ex.Message}")
            Return ""
        Catch ex As TaskCanceledException
            Debug.WriteLine("WyslijKomende timeout")
            Return ""
        End Try
    End Function

    ' ═══════════════════════════════════════════════════════════════
    ' FORMATOWANIE WPISÓW DO HISTORII
    ' ═══════════════════════════════════════════════════════════════
    Private Function FormatujWpisy(numer As Integer, hex As String,
                                    odpowiedz As String,
                                    statusInfo As String) As List(Of String)
        Dim wpisy As New List(Of String)
        Dim ts As String = DateTime.Now.ToString("HH:mm:ss")
        Dim hexSkrot As String = If(hex.Length >= 8, hex.Substring(0, 8) & "…", hex)

        wpisy.Add($"[{ts}]  Gr.{numer,3}  →  {hexSkrot}  |  {statusInfo}")
        wpisy.Add($"         Surowa   : {odpowiedz.Trim()}")

        Dim mExec As Match = Regex.Match(odpowiedz, "execute=\s*(\d+)")
        If mExec.Success Then
            wpisy.Add($"         Czas wyk.: {mExec.Groups(1).Value} s")
        End If

        If String.IsNullOrEmpty(odpowiedz) Then
            wpisy.Add("         (brak odpowiedzi od serwera)")
        End If

        wpisy.Add("         ─────────────────────────────────────")
        Return wpisy
    End Function

    Private Function FormatujWpisyMigaj(cel As String, cmd As String,
                                         odpowiedz As String,
                                         statusInfo As String) As List(Of String)
        Dim wpisy As New List(Of String)
        Dim ts As String = DateTime.Now.ToString("HH:mm:ss")

        wpisy.Add($"[{ts}]  {cel}  →  cmd={cmd}  |  {statusInfo}")
        wpisy.Add($"         Surowa   : {odpowiedz.Trim()}")

        Dim mExec As Match = Regex.Match(odpowiedz, "execute=\s*(\d+)")
        If mExec.Success Then
            wpisy.Add($"         Czas wyk.: {mExec.Groups(1).Value} s")
        End If

        If String.IsNullOrEmpty(odpowiedz) Then
            wpisy.Add("         (brak odpowiedzi od serwera)")
        End If

        wpisy.Add("         ─────────────────────────────────────")
        Return wpisy
    End Function

    ' ═══════════════════════════════════════════════════════════════
    ' tabTS – TOGGLE / UTWÓRZ / RESET / WALIDACJA / WYŚLIJ
    ' ═══════════════════════════════════════════════════════════════
    Private Sub UstawToggle()
        btnToggleWszystkie.FlatStyle = FlatStyle.Flat
        btnToggleWszystkie.Font = New Font("Consolas", 10, FontStyle.Bold)
        If wszystkieGrupyAktywne Then
            btnToggleWszystkie.Text = T("toggle.tak")
            btnToggleWszystkie.BackColor = Color.FromArgb(0, 120, 0)
            btnToggleWszystkie.ForeColor = Color.White
            btnToggleWszystkie.FlatAppearance.BorderColor = ZIELONY
            btnUtworzGrupy.Enabled = False
            txtIloscGrup.Enabled = False
        Else
            btnToggleWszystkie.Text = T("toggle.nie")
            btnToggleWszystkie.BackColor = PANEL
            btnToggleWszystkie.ForeColor = Color.Gray
            btnToggleWszystkie.FlatAppearance.BorderColor = Color.Gray
            btnUtworzGrupy.Enabled = True
            txtIloscGrup.Enabled = True
        End If
    End Sub

    Private Sub btnToggleWszystkie_Click(sender As Object, e As EventArgs) Handles btnToggleWszystkie.Click
        wszystkieGrupyAktywne = Not wszystkieGrupyAktywne
        UstawToggle()
    End Sub

    Private Sub btnUtworzGrupy_Click(sender As Object, e As EventArgs) Handles btnUtworzGrupy.Click
        Dim iloscGrup As Integer
        If Not Integer.TryParse(txtIloscGrup.Text, iloscGrup) OrElse
           iloscGrup < 1 OrElse iloscGrup > 63 Then
            MessageBox.Show(T("ts.err_ilosc_grup"), "Błąd",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        pnlGrupy.Controls.Clear()
        Const TB_W As Integer = 45
        Const TB_H As Integer = 23
        Const ROW_H As Integer = 30
        Const PADDING As Integer = 6
        Const TOP_PAD As Integer = 3

        Dim effectiveW As Integer = pnlGrupy.ClientSize.Width - 2 * PADDING
        Dim perRow As Integer = Math.Max(1, (effectiveW + 4) \ (TB_W + 4))
        If perRow > iloscGrup Then perRow = iloscGrup
        Dim rows As Integer = CInt(Math.Ceiling(iloscGrup / CDbl(perRow)))

        For i As Integer = 0 To iloscGrup - 1
            Dim row As Integer = i \ perRow
            Dim col As Integer = i Mod perRow
            Dim itemsInRow As Integer = If(row = rows - 1, iloscGrup - row * perRow, perRow)
            Dim x As Integer
            If itemsInRow = 1 Then
                x = PADDING + (effectiveW - TB_W) \ 2
            Else
                x = PADDING + CInt(col * CDbl(effectiveW - TB_W) / (itemsInRow - 1))
            End If

            Dim tb As New TextBox()
            tb.Name = $"tbGrupa_{i + 1}"
            tb.Size = New Size(TB_W, TB_H)
            tb.MaxLength = 3
            tb.TextAlign = HorizontalAlignment.Center
            tb.Location = New Point(x, row * ROW_H + TOP_PAD)
            tb.Tag = i
            tb.Font = New Font("Consolas", 10, FontStyle.Bold)
            tb.BackColor = PANEL
            tb.ForeColor = ZIELONY
            tb.BorderStyle = BorderStyle.FixedSingle
            AddHandler tb.KeyPress, AddressOf tbGrupa_KeyPress
            AddHandler tb.Leave, AddressOf tbGrupa_Leave
            toolTipGrupy.SetToolTip(tb, $"Grupa {i + 1}")
            pnlGrupy.Controls.Add(tb)
        Next

        lblStatusTS.Text = $"Status: Utworzono {iloscGrup} pól ({rows} wiersze)"
        lblStatusTS.ForeColor = OPIS
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        txtNumer.Text = ""
        txtIloscGrup.Text = ""
        pnlGrupy.Controls.Clear()
        wszystkieGrupyAktywne = False
        UstawToggle()
        lblStatusTS.Text = T("ts.status_domyslny")
        lblStatusTS.ForeColor = OPIS
    End Sub

    Private Sub tbGrupa_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub tbGrupa_Leave(sender As Object, e As EventArgs)
        Dim tb As TextBox = CType(sender, TextBox)
        If String.IsNullOrWhiteSpace(tb.Text) Then
            tb.BackColor = PANEL : Return
        End If
        Dim val As Integer
        If Integer.TryParse(tb.Text, val) AndAlso val >= 0 AndAlso val <= 127 Then
            tb.BackColor = PANEL
        Else
            tb.BackColor = Color.DarkRed
            toolTipGrupy.SetToolTip(tb, T("ts.tooltip_zakres"))
        End If
    End Sub

    Private Sub btnCzyscHistorie_Click(sender As Object, e As EventArgs) Handles btnCzyscHistorie.Click
        lstHistoria.Items.Clear()
        lblStatusTS.Text = T("ts.status_domyslny")
        lblStatusTS.ForeColor = OPIS
    End Sub

    Private Async Sub btnWyslij_Click(sender As Object, e As EventArgs) Handles btnWyslij.Click
        btnWyslij.Enabled = False
        lblStatusTS.Text = T("ts.status_wysylanie")
        lblStatusTS.ForeColor = Color.Yellow

        Try
            Dim grupy As New List(Of Integer)

            If wszystkieGrupyAktywne Then
                For i As Integer = 0 To 63 : grupy.Add(i) : Next
            ElseIf pnlGrupy.Controls.Count > 0 Then
                For Each tb As TextBox In pnlGrupy.Controls.OfType(Of TextBox)().OrderBy(Function(t) CInt(t.Tag))
                    If String.IsNullOrWhiteSpace(tb.Text) Then Continue For
                    Dim val As Integer
                    If Integer.TryParse(tb.Text, val) AndAlso val >= 0 AndAlso val <= 127 Then
                        grupy.Add(val)
                    Else
                        tb.BackColor = Color.DarkRed
                    End If
                Next
                If grupy.Count = 0 Then
                    lblStatusTS.Text = T("ts.status_brak_grup")
                    lblStatusTS.ForeColor = Color.Red
                    Return
                End If
            Else
                Dim numer As Integer
                If Not Integer.TryParse(txtNumer.Text, numer) OrElse numer < 0 OrElse numer > 127 Then
                    lblStatusTS.Text = T("ts.status_blad_zakresu")
                    lblStatusTS.ForeColor = Color.Red
                    Return
                End If
                grupy.Add(numer)
            End If

            Dim sukces As Boolean = True
            For Each numer As Integer In grupy
                Dim hex As String = KodujGrupa(numer)
                lblStatusTS.Text = $"Status: → Gr.{numer}"
                lblStatusTS.ForeColor = Color.Yellow
                Dim odpowiedz As String = Await WyslijKomende("01", hex)
                Dim statusInfo As String
                If odpowiedz.Contains("parameter(s) OK") Then
                    Dim m As Match = Regex.Match(odpowiedz, "execute=\s*(\d+)")
                    statusInfo = If(m.Success, $"OK | Czas: {m.Groups(1).Value} s", "OK")
                    lblStatusTS.ForeColor = ZIELONY
                Else
                    statusInfo = "Błąd wykonania"
                    lblStatusTS.Text = $"Status: ⛔ Gr.{numer}"
                    lblStatusTS.ForeColor = Color.Red
                    sukces = False
                    For Each wiersz In FormatujWpisy(numer, hex, odpowiedz, $"⛔ {statusInfo}")
                        lstHistoria.Items.Insert(0, wiersz)
                    Next
                    Exit For
                End If
                For Each wiersz In FormatujWpisy(numer, hex, odpowiedz, statusInfo)
                    lstHistoria.Items.Insert(0, wiersz)
                Next
            Next

            If sukces Then
                Dim podsumowanie As String
                If wszystkieGrupyAktywne Then
                    podsumowanie = "TS → 64 grupy (0–63)"
                ElseIf grupy.Count > 1 Then
                    podsumowanie = $"TS → {grupy.Count} grup"
                Else
                    podsumowanie = $"TS → Gr.{grupy(0)}"
                End If
                lblStatusTS.Text = $"Status: {podsumowanie}"
                lblStatusTS.ForeColor = ZIELONY
                lblStatus.Text = podsumowanie
                lblStatus.ForeColor = OPIS
            End If

        Catch ex As ArgumentException
            lblStatusTS.Text = $"Status: {ex.Message}"
            lblStatusTS.ForeColor = Color.Red
        Catch ex As Exception
            lblStatusTS.Text = T("ts.status_blad_komunikacji")
            lblStatusTS.ForeColor = Color.Red
            lstHistoria.Items.Insert(0, $"[{DateTime.Now:HH:mm:ss}]  ⛔ {ex.Message}")
        Finally
            btnWyslij.Enabled = True
        End Try
    End Sub

    ' ═══════════════════════════════════════════════════════════════
    ' tabTCP – TOGGLE / UTWÓRZ / RESET / WALIDACJA / START / STOP
    ' ═══════════════════════════════════════════════════════════════
    Private Sub UstawToggleTCP()
        btnToggleWszystkieTCP.FlatStyle = FlatStyle.Flat
        btnToggleWszystkieTCP.Font = New Font("Consolas", 10, FontStyle.Bold)
        If wszystkieGrupyAktywneTCP Then
            btnToggleWszystkieTCP.Text = T("toggle.tak")
            btnToggleWszystkieTCP.BackColor = Color.FromArgb(0, 120, 0)
            btnToggleWszystkieTCP.ForeColor = Color.White
            btnToggleWszystkieTCP.FlatAppearance.BorderColor = ZIELONY
            btnUtworzGrupyTCP.Enabled = False
            txtIloscGrupTCP.Enabled = False
        Else
            btnToggleWszystkieTCP.Text = T("toggle.nie")
            btnToggleWszystkieTCP.BackColor = PANEL
            btnToggleWszystkieTCP.ForeColor = Color.Gray
            btnToggleWszystkieTCP.FlatAppearance.BorderColor = Color.Gray
            btnUtworzGrupyTCP.Enabled = True
            txtIloscGrupTCP.Enabled = True
        End If
    End Sub

    Private Sub btnToggleWszystkieTCP_Click(sender As Object, e As EventArgs) Handles btnToggleWszystkieTCP.Click
        wszystkieGrupyAktywneTCP = Not wszystkieGrupyAktywneTCP
        UstawToggleTCP()
    End Sub

    Private Sub btnUtworzGrupyTCP_Click(sender As Object, e As EventArgs) Handles btnUtworzGrupyTCP.Click
        Dim iloscGrup As Integer
        If Not Integer.TryParse(txtIloscGrupTCP.Text, iloscGrup) OrElse
           iloscGrup < 1 OrElse iloscGrup > 63 Then
            MessageBox.Show(T("tcp.err_ilosc_grup"), "Błąd",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        pnlGrupyTCP.Controls.Clear()
        Const TB_W As Integer = 45
        Const TB_H As Integer = 23
        Const ROW_H As Integer = 30
        Const PADDING As Integer = 6
        Const TOP_PAD As Integer = 3

        Dim effectiveW As Integer = pnlGrupyTCP.ClientSize.Width - 2 * PADDING
        Dim perRow As Integer = Math.Max(1, (effectiveW + 4) \ (TB_W + 4))
        If perRow > iloscGrup Then perRow = iloscGrup
        Dim rows As Integer = CInt(Math.Ceiling(iloscGrup / CDbl(perRow)))

        For i As Integer = 0 To iloscGrup - 1
            Dim row As Integer = i \ perRow
            Dim col As Integer = i Mod perRow
            Dim itemsInRow As Integer = If(row = rows - 1, iloscGrup - row * perRow, perRow)
            Dim x As Integer
            If itemsInRow = 1 Then
                x = PADDING + (effectiveW - TB_W) \ 2
            Else
                x = PADDING + CInt(col * CDbl(effectiveW - TB_W) / (itemsInRow - 1))
            End If

            Dim tb As New TextBox()
            tb.Name = $"tbGrupaTCP_{i + 1}"
            tb.Size = New Size(TB_W, TB_H)
            tb.MaxLength = 3
            tb.TextAlign = HorizontalAlignment.Center
            tb.Location = New Point(x, row * ROW_H + TOP_PAD)
            tb.Tag = i
            tb.Font = New Font("Consolas", 10, FontStyle.Bold)
            tb.BackColor = PANEL
            tb.ForeColor = ZIELONY
            tb.BorderStyle = BorderStyle.FixedSingle
            AddHandler tb.KeyPress, AddressOf tbGrupaTCP_KeyPress
            AddHandler tb.Leave, AddressOf tbGrupaTCP_Leave
            toolTipGrupyTCP.SetToolTip(tb, $"Grupa {i + 1}")
            pnlGrupyTCP.Controls.Add(tb)
        Next

        lblStatusTS.Text = $"Status: Utworzono {iloscGrup} pól TCP ({rows} wiersze)"
        lblStatusTS.ForeColor = OPIS
    End Sub

    Private Sub btnResetTCP_Click(sender As Object, e As EventArgs) Handles btnResetTCP.Click
        txtNumerTCP.Text = ""
        txtIloscGrupTCP.Text = ""
        pnlGrupyTCP.Controls.Clear()
        wszystkieGrupyAktywneTCP = False
        UstawToggleTCP()
        lblStatusTS.Text = T("tcp.status_domyslny")
        lblStatusTS.ForeColor = OPIS
    End Sub

    Private Sub tbGrupaTCP_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub tbGrupaTCP_Leave(sender As Object, e As EventArgs)
        Dim tb As TextBox = CType(sender, TextBox)
        If String.IsNullOrWhiteSpace(tb.Text) Then
            tb.BackColor = PANEL : Return
        End If
        Dim val As Integer
        If Integer.TryParse(tb.Text, val) AndAlso val >= 0 AndAlso val <= 127 Then
            tb.BackColor = PANEL
        Else
            tb.BackColor = Color.DarkRed
            toolTipGrupyTCP.SetToolTip(tb, T("tcp.tooltip_zakres"))
        End If
    End Sub

    Private Async Sub btnWyslijTCPStart_Click(sender As Object, e As EventArgs) Handles btnWyslijTCPStart.Click
        If _ctsPetlaTCP IsNot Nothing Then
            _ctsPetlaTCP.Cancel()
            Return
        End If

        _ctsPetlaTCP = New CancellationTokenSource()
        Dim token = _ctsPetlaTCP.Token
        btnWyslijTCPStart.Enabled = False
        lblStatusTS.Text = T("tcp.status_wysylanie")
        lblStatusTS.ForeColor = Color.Yellow

        Try
            Dim grupy As New List(Of Integer)

            If wszystkieGrupyAktywneTCP Then
                For i As Integer = 0 To 63 : grupy.Add(i) : Next
            ElseIf pnlGrupyTCP.Controls.Count > 0 Then
                For Each tb As TextBox In pnlGrupyTCP.Controls.OfType(Of TextBox)().OrderBy(Function(t) CInt(t.Tag))
                    If String.IsNullOrWhiteSpace(tb.Text) Then Continue For
                    Dim val As Integer
                    If Integer.TryParse(tb.Text, val) AndAlso val >= 0 AndAlso val <= 127 Then
                        grupy.Add(val)
                    Else
                        tb.BackColor = Color.DarkRed
                    End If
                Next
                If grupy.Count = 0 Then
                    lblStatusTS.Text = T("ts.status_brak_grup")
                    lblStatusTS.ForeColor = Color.Red
                    Return
                End If
            Else
                Dim numer As Integer
                If Not Integer.TryParse(txtNumerTCP.Text, numer) OrElse numer < 0 OrElse numer > 127 Then
                    lblStatusTS.Text = T("ts.status_blad_zakresu")
                    lblStatusTS.ForeColor = Color.Red
                    Return
                End If
                grupy.Add(numer)
            End If

            Dim grupyZablokowane = grupy.Where(Function(n) _grupyTCPAktywne.Contains(n)).ToList()
            For Each numer In grupyZablokowane
                lstHistoria.Items.Insert(0, $"[{Date.Now:HH:mm:ss}]  ⛔ Gr.{numer,3}  →  {T("tcp.blokada_aktywna")}")
            Next
            grupy.RemoveAll(Function(n) _grupyTCPAktywne.Contains(n))

            If grupy.Count = 0 Then
                lblStatusTS.Text = T("tcp.status_wszystkie_aktywne")
                lblStatusTS.ForeColor = Color.Orange
                Return
            End If

            Dim grupyDoPotwierdzenia = grupy.Where(Function(n) _grupyTCPHistoria.ContainsKey(n)).ToList()
            If grupyDoPotwierdzenia.Count > 0 Then
                Dim sb As New StringBuilder()
                sb.AppendLine(T("tcp.msgbox.naglowek"))
                sb.AppendLine()
                For Each numer In grupyDoPotwierdzenia
                    Dim elapsed = Date.Now - _grupyTCPHistoria(numer)
                    sb.AppendLine($"  • Gr.{numer,3}  –  {T("tcp.msgbox.ostatni_start")} " &
                                  $"{_grupyTCPHistoria(numer):HH:mm:ss}  " &
                                  $"({CInt(elapsed.TotalMinutes)} {T("tcp.msgbox.min_temu")})")
                Next
                sb.AppendLine()
                sb.AppendLine(T("tcp.msgbox.ostrzezenie"))
                sb.AppendLine()
                sb.AppendLine(T("tcp.msgbox.pytanie"))

                Dim wynik = MessageBox.Show(sb.ToString(), T("tcp.msgbox.tytul"),
                                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                If wynik = DialogResult.No Then
                    For Each numer In grupyDoPotwierdzenia
                        lstHistoria.Items.Insert(0, $"[{Date.Now:HH:mm:ss}]  ⚠ Gr.{numer,3}  →  {T("tcp.anulowany_przez_uzytkownika")}")
                    Next
                    grupy.RemoveAll(Function(n) grupyDoPotwierdzenia.Contains(n))
                End If
            End If

            If grupy.Count = 0 Then
                lblStatusTS.Text = T("tcp.status_anulowane")
                lblStatusTS.ForeColor = Color.Orange
                Return
            End If

            Dim sukces As Boolean = True
            For Each numer In grupy
                If token.IsCancellationRequested Then
                    lstHistoria.Items.Insert(0, $"[{Date.Now:HH:mm:ss}]  ⚠ Zatrzymano na grupie {numer}")
                    lblStatusTS.Text = $"Status: Zatrzymano → Gr.{numer}"
                    lblStatusTS.ForeColor = Color.Orange
                    sukces = False
                    Exit For
                End If

                Dim hex As String = KodujGrupa(numer)
                lblStatusTS.Text = $"Status: TCP → Gr.{numer}"
                lblStatusTS.ForeColor = Color.Yellow
                Dim odpowiedz As String = Await WyslijKomende("02", hex)

                Dim statusInfo As String
                If odpowiedz.Contains("parameter(s) OK") Then
                    Dim m As Match = Regex.Match(odpowiedz, "execute=\s*(\d+)")
                    statusInfo = If(m.Success, $"START OK | Czas: {m.Groups(1).Value} s", "START OK")
                    _grupyTCPAktywne.Add(numer)
                    _grupyTCPHistoria(numer) = Date.Now
                    lblStatusTS.ForeColor = ZIELONY
                Else
                    statusInfo = "Błąd wykonania"
                    lblStatusTS.Text = $"Status: ⛔ Gr.{numer}"
                    lblStatusTS.ForeColor = Color.Red
                    sukces = False
                    For Each wiersz In FormatujWpisy(numer, hex, odpowiedz, $"⛔ {statusInfo}")
                        lstHistoria.Items.Insert(0, wiersz)
                    Next
                    Exit For
                End If
                For Each wiersz In FormatujWpisy(numer, hex, odpowiedz, statusInfo)
                    lstHistoria.Items.Insert(0, wiersz)
                Next
            Next

            If sukces Then
                Dim podsumowanie As String = If(grupy.Count > 1,
                    $"TCP START → {grupy.Count} grup", $"TCP START → Gr.{grupy(0)}")
                lblStatusTS.Text = $"Status: {podsumowanie}"
                lblStatusTS.ForeColor = ZIELONY
            End If

        Catch ex As OperationCanceledException
            lblStatusTS.Text = "Status: Zatrzymano przez użytkownika"
            lblStatusTS.ForeColor = Color.Orange
        Catch ex As ArgumentException
            lblStatusTS.Text = $"Status: {ex.Message}"
            lblStatusTS.ForeColor = Color.Red
        Catch ex As Exception
            lblStatusTS.Text = T("tcp.status_blad_komunikacji")
            lblStatusTS.ForeColor = Color.Red
            lstHistoria.Items.Insert(0, $"[{Date.Now:HH:mm:ss}]  ⛔ {ex.Message}")
        Finally
            _ctsPetlaTCP?.Dispose()
            _ctsPetlaTCP = Nothing
            btnWyslijTCPStart.Enabled = True
        End Try
    End Sub

    Private Async Sub btnWyslijTCPStop_Click(sender As Object, e As EventArgs) Handles btnWyslijTCPStop.Click
        If _grupyTCPAktywne.Count = 0 Then
            lblStatusTS.Text = T("tcp.status_brak_aktywnych")
            lblStatusTS.ForeColor = Color.Orange
            Return
        End If

        btnWyslijTCPStop.Enabled = False
        lblStatusTS.Text = T("tcp.status_stop_wysylanie")
        lblStatusTS.ForeColor = Color.Yellow

        Try
            Dim grupyDoZatrzymania As New List(Of Integer)(_grupyTCPAktywne)
            Dim sukces As Boolean = True

            For Each numer In grupyDoZatrzymania
                Dim hex As String = KodujGrupa(numer)
                lblStatusTS.Text = $"Status: STOP → Gr.{numer}"
                lblStatusTS.ForeColor = Color.Yellow
                Dim odpowiedz As String = Await WyslijKomende("03", hex)

                Dim statusInfo As String
                If odpowiedz.Contains("parameter(s) OK") Then
                    Dim m As Match = Regex.Match(odpowiedz, "execute=\s*(\d+)")
                    statusInfo = If(m.Success, $"STOP OK | Czas: {m.Groups(1).Value} s", "STOP OK")
                    _grupyTCPAktywne.Remove(numer)
                    lblStatusTS.ForeColor = ZIELONY
                Else
                    statusInfo = "Błąd STOP"
                    lblStatusTS.Text = $"Status: ⛔ STOP Gr.{numer}"
                    lblStatusTS.ForeColor = Color.Red
                    sukces = False
                    For Each wiersz In FormatujWpisy(numer, hex, odpowiedz, $"⛔ {statusInfo}")
                        lstHistoria.Items.Insert(0, wiersz)
                    Next
                    Exit For
                End If
                For Each wiersz In FormatujWpisy(numer, hex, odpowiedz, statusInfo)
                    lstHistoria.Items.Insert(0, wiersz)
                Next
            Next

            If sukces Then
                lblStatusTS.Text = $"Status: STOP → {grupyDoZatrzymania.Count} grup"
                lblStatusTS.ForeColor = ZIELONY
            End If

        Catch ex As ArgumentException
            lblStatusTS.Text = $"Status: {ex.Message}"
            lblStatusTS.ForeColor = Color.Red
        Catch ex As Exception
            lblStatusTS.Text = T("tcp.status_blad_komunikacji")
            lblStatusTS.ForeColor = Color.Red
            lstHistoria.Items.Insert(0, $"[{Date.Now:HH:mm:ss}]  ⛔ STOP {ex.Message}")
        Finally
            btnWyslijTCPStop.Enabled = True
        End Try
    End Sub

    ' ═══════════════════════════════════════════════════════════════
    ' tabMigaj – WALIDACJA / START / STOP
    ' ═══════════════════════════════════════════════════════════════
    Private Sub tbMigajGrupa_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub tbMigajGrupa_Leave(sender As Object, e As EventArgs)
        If String.IsNullOrWhiteSpace(txtNumerMigaj.Text) Then
            txtNumerMigaj.BackColor = PANEL : Return
        End If
        Dim val As Integer
        If Integer.TryParse(txtNumerMigaj.Text, val) AndAlso val >= 0 AndAlso val <= 127 Then
            txtNumerMigaj.BackColor = PANEL
        Else
            txtNumerMigaj.BackColor = Color.DarkRed
            toolTipMigaj.SetToolTip(txtNumerMigaj, T("migaj.tooltip_zakres_grupy"))
        End If
    End Sub

    Private Sub tbMigajOprawa_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub tbMigajOprawa_Leave(sender As Object, e As EventArgs)
        If String.IsNullOrWhiteSpace(txtNumerOprawyMigaj.Text) Then
            txtNumerOprawyMigaj.BackColor = PANEL : Return
        End If
        Dim val As Long
        If Long.TryParse(txtNumerOprawyMigaj.Text, val) AndAlso val >= 1 AndAlso val <= 15000000 Then
            txtNumerOprawyMigaj.BackColor = PANEL
        Else
            txtNumerOprawyMigaj.BackColor = Color.DarkRed
            toolTipMigaj.SetToolTip(txtNumerOprawyMigaj, T("migaj.tooltip_zakres_oprawy"))
        End If
    End Sub

    Private Async Sub btnWyslijMigajStart_Click(sender As Object, e As EventArgs) Handles btnWyslijMigajStart.Click
        Dim maGrupe As Boolean = Not String.IsNullOrWhiteSpace(txtNumerMigaj.Text)
        Dim maOprawe As Boolean = Not String.IsNullOrWhiteSpace(txtNumerOprawyMigaj.Text)
        Dim loginUpper As String = txtLogin.Text.Trim().ToUpper()
        If loginUpper <> "ADMIN" AndAlso loginUpper <> "SERWIS" Then
            MessageBox.Show(T("migaj.wymaga_uprawnien"), T("migaj.wymaga_uprawnien_tytul"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If Not maGrupe AndAlso Not maOprawe Then
            lblStatusTS.Text = T("migaj.status_brak_danych")
            lblStatusTS.ForeColor = Color.Red
            Return
        End If

        Dim numerGrupy As Integer = -1
        If maGrupe Then
            If Not Integer.TryParse(txtNumerMigaj.Text, numerGrupy) OrElse
               numerGrupy < 0 OrElse numerGrupy > 127 Then
                lblStatusTS.Text = T("migaj.status_blad_zakresu_grupy")
                lblStatusTS.ForeColor = Color.Red
                txtNumerMigaj.BackColor = Color.DarkRed
                Return
            End If
        End If

        Dim numerOprawy As Long = -1
        If maOprawe Then
            If Not Long.TryParse(txtNumerOprawyMigaj.Text, numerOprawy) OrElse
               numerOprawy < 1 OrElse numerOprawy > 15000000 Then
                lblStatusTS.Text = T("migaj.status_blad_zakresu_oprawy")
                lblStatusTS.ForeColor = Color.Red
                txtNumerOprawyMigaj.BackColor = Color.DarkRed
                Return
            End If
        End If

        btnWyslijMigajStart.Enabled = False
        lblStatusTS.Text = T("migaj.status_wysylanie")
        lblStatusTS.ForeColor = Color.Yellow

        Try
            Dim sukces As Boolean = True

            If maGrupe Then
                Dim hex As String = KodujGrupa(numerGrupy)
                lblStatusTS.Text = $"Status: Migaj → Gr.{numerGrupy}"
                lblStatusTS.ForeColor = Color.Yellow
                Dim odpowiedz As String = Await WyslijKomende("10", hex)
                Dim statusInfo As String
                If odpowiedz.Contains("parameter(s) OK") Then
                    Dim m As Match = Regex.Match(odpowiedz, "execute=\s*(\d+)")
                    statusInfo = If(m.Success, $"START OK | Czas: {m.Groups(1).Value} s", "START OK")
                    lblStatusTS.ForeColor = ZIELONY
                Else
                    statusInfo = "Błąd wykonania"
                    lblStatusTS.Text = $"Status: ⛔ Migaj Gr.{numerGrupy}"
                    lblStatusTS.ForeColor = Color.Red
                    sukces = False
                End If
                For Each wiersz In FormatujWpisyMigaj($"Gr.{numerGrupy,3}", "10", odpowiedz, statusInfo)
                    lstHistoria.Items.Insert(0, wiersz)
                Next
            End If

            If maOprawe AndAlso sukces Then
                lblStatusTS.Text = $"Status: Migaj → Oprawa {numerOprawy}"
                lblStatusTS.ForeColor = Color.Yellow
                Dim url As String = $"http://{txtIP.Text.Trim()}/?cmd=10&par18={numerOprawy}"
                Dim odpowiedzOprawa As String
                Try
                    Dim response = Await httpClient.GetAsync(url)
                    odpowiedzOprawa = Await response.Content.ReadAsStringAsync()
                Catch ex As Exception
                    odpowiedzOprawa = ""
                End Try
                Dim statusInfoOprawa As String
                If odpowiedzOprawa.Contains("parameter(s) OK") Then
                    Dim m As Match = Regex.Match(odpowiedzOprawa, "execute=\s*(\d+)")
                    statusInfoOprawa = If(m.Success, $"START OK | Czas: {m.Groups(1).Value} s", "START OK")
                    lblStatusTS.ForeColor = ZIELONY
                Else
                    statusInfoOprawa = "Błąd wykonania"
                    lblStatusTS.Text = $"Status: ⛔ Migaj Oprawa {numerOprawy}"
                    lblStatusTS.ForeColor = Color.Red
                    sukces = False
                End If
                For Each wiersz In FormatujWpisyMigaj($"Oprawa {numerOprawy}", "10", odpowiedzOprawa, statusInfoOprawa)
                    lstHistoria.Items.Insert(0, wiersz)
                Next
            End If

            If sukces Then
                Dim czesci As New List(Of String)
                If maGrupe Then czesci.Add($"Gr.{numerGrupy}")
                If maOprawe Then czesci.Add($"Oprawa {numerOprawy}")
                lblStatusTS.Text = $"Status: Migaj START → {String.Join(" + ", czesci)}"
                lblStatusTS.ForeColor = ZIELONY
            End If

        Catch ex As Exception
            lblStatusTS.Text = T("migaj.status_blad_komunikacji")
            lblStatusTS.ForeColor = Color.Red
            lstHistoria.Items.Insert(0, $"[{Date.Now:HH:mm:ss}]  ⛔ {ex.Message}")
        Finally
            btnWyslijMigajStart.Enabled = True
        End Try
    End Sub

    Private Async Sub btnWyslijMigajStop_Click(sender As Object, e As EventArgs) Handles btnWyslijMigajStop.Click
        Dim maGrupe As Boolean = Not String.IsNullOrWhiteSpace(txtNumerMigaj.Text)
        Dim maOprawe As Boolean = Not String.IsNullOrWhiteSpace(txtNumerOprawyMigaj.Text)
        Dim loginUpper As String = txtLogin.Text.Trim().ToUpper()
        If loginUpper <> "ADMIN" AndAlso loginUpper <> "SERWIS" Then
            MessageBox.Show(T("migaj.wymaga_uprawnien"), T("migaj.wymaga_uprawnien_tytul"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If Not maGrupe AndAlso Not maOprawe Then
            lblStatusTS.Text = T("migaj.status_brak_danych")
            lblStatusTS.ForeColor = Color.Red
            Return
        End If

        Dim numerGrupy As Integer = -1
        If maGrupe Then
            If Not Integer.TryParse(txtNumerMigaj.Text, numerGrupy) OrElse
               numerGrupy < 0 OrElse numerGrupy > 127 Then
                lblStatusTS.Text = T("migaj.status_blad_zakresu_grupy")
                lblStatusTS.ForeColor = Color.Red
                txtNumerMigaj.BackColor = Color.DarkRed
                Return
            End If
        End If

        Dim numerOprawy As Long = -1
        If maOprawe Then
            If Not Long.TryParse(txtNumerOprawyMigaj.Text, numerOprawy) OrElse
               numerOprawy < 1 OrElse numerOprawy > 15000000 Then
                lblStatusTS.Text = T("migaj.status_blad_zakresu_oprawy")
                lblStatusTS.ForeColor = Color.Red
                txtNumerOprawyMigaj.BackColor = Color.DarkRed
                Return
            End If
        End If

        btnWyslijMigajStop.Enabled = False
        lblStatusTS.Text = T("migaj.status_stop_wysylanie")
        lblStatusTS.ForeColor = Color.Yellow

        Try
            Dim sukces As Boolean = True

            If maGrupe Then
                Dim hex As String = KodujGrupa(numerGrupy)
                lblStatusTS.Text = $"Status: STOP Migaj → Gr.{numerGrupy}"
                lblStatusTS.ForeColor = Color.Yellow
                Dim odpowiedz As String = Await WyslijKomende("11", hex)
                Dim statusInfo As String
                If odpowiedz.Contains("parameter(s) OK") Then
                    Dim m As Match = Regex.Match(odpowiedz, "execute=\s*(\d+)")
                    statusInfo = If(m.Success, $"STOP OK | Czas: {m.Groups(1).Value} s", "STOP OK")
                    lblStatusTS.ForeColor = ZIELONY
                Else
                    statusInfo = "Błąd STOP"
                    lblStatusTS.Text = $"Status: ⛔ STOP Migaj Gr.{numerGrupy}"
                    lblStatusTS.ForeColor = Color.Red
                    sukces = False
                End If
                For Each wiersz In FormatujWpisyMigaj($"Gr.{numerGrupy,3}", "11", odpowiedz, statusInfo)
                    lstHistoria.Items.Insert(0, wiersz)
                Next
            End If

            If maOprawe AndAlso sukces Then
                lblStatusTS.Text = $"Status: STOP Migaj → Oprawa {numerOprawy}"
                lblStatusTS.ForeColor = Color.Yellow
                Dim url As String = $"http://{txtIP.Text.Trim()}/?cmd=11&par18={numerOprawy}"
                Dim odpowiedzOprawa As String
                Try
                    Dim response = Await httpClient.GetAsync(url)
                    odpowiedzOprawa = Await response.Content.ReadAsStringAsync()
                Catch ex As Exception
                    odpowiedzOprawa = ""
                End Try
                Dim statusInfoOprawa As String
                If odpowiedzOprawa.Contains("parameter(s) OK") Then
                    Dim m As Match = Regex.Match(odpowiedzOprawa, "execute=\s*(\d+)")
                    statusInfoOprawa = If(m.Success, $"STOP OK | Czas: {m.Groups(1).Value} s", "STOP OK")
                    lblStatusTS.ForeColor = ZIELONY
                Else
                    statusInfoOprawa = "Błąd STOP"
                    lblStatusTS.Text = $"Status: ⛔ STOP Migaj Oprawa {numerOprawy}"
                    lblStatusTS.ForeColor = Color.Red
                    sukces = False
                End If
                For Each wiersz In FormatujWpisyMigaj($"Oprawa {numerOprawy}", "11", odpowiedzOprawa, statusInfoOprawa)
                    lstHistoria.Items.Insert(0, wiersz)
                Next
            End If

            If sukces Then
                Dim czesci As New List(Of String)
                If maGrupe Then czesci.Add($"Gr.{numerGrupy}")
                If maOprawe Then czesci.Add($"Oprawa {numerOprawy}")
                lblStatusTS.Text = $"Status: Migaj STOP → {String.Join(" + ", czesci)}"
                lblStatusTS.ForeColor = ZIELONY
            End If

        Catch ex As Exception
            lblStatusTS.Text = T("migaj.status_blad_komunikacji")
            lblStatusTS.ForeColor = Color.Red
            lstHistoria.Items.Insert(0, $"[{Date.Now:HH:mm:ss}]  ⛔ STOP {ex.Message}")
        Finally
            btnWyslijMigajStop.Enabled = True
        End Try
    End Sub

    ' ═══════════════════════════════════════════════════════════════
    ' tabStan – RESET CENTRALKI (cmd=24)
    ' ═══════════════════════════════════════════════════════════════
    Private Async Sub btnResetCentralki_Click(sender As Object, e As EventArgs) _
        Handles btnResetCentralki.Click

        tabMain.Enabled = False
        Dim frmReset As New FormReset()
        frmReset.Text = T("reset.tytul")
        frmReset.Owner = Me
        frmReset.Show()
        frmReset.BringToFront()
        frmReset.StartOdliczanie()

        Try
            Dim url As String = $"http://{txtIP.Text.Trim()}/?cmd=24"
            Try
                Await httpClient.GetAsync(url)
            Catch
            End Try
            Await Task.Delay(10000)
            If Not frmReset.IsDisposed Then frmReset.Close()
        Finally
            tabMain.Enabled = True
        End Try

        Await PolaczZSerwerem()
    End Sub

    ' 2. Przycisk CSV
    Private Sub btnPobierzKonfig_Click(sender As Object, e As EventArgs) Handles btnPobierzKonfig.Click, btnPobierzKonfig.Click
        Dim ofd As New OpenFileDialog With {
        .Filter = "CSV|*.csv",
        .Title = "Wczytaj oprawy.csv"
    }
        If ofd.ShowDialog = DialogResult.OK Then
            Try
                csvConfig = ParseOprawyCsv(ofd.FileName)
                MsgBox($"Wczytano {csvConfig.Rows.Count} opraw z pliku")
            Catch ex As Exception
                MsgBox("BŁĄD CSV: " & ex.Message)
            End Try
        End If
    End Sub


    ' 3. Parser CSV - PEŁNY
    Private Function ParseOprawyCsv(path As String) As DataTable
        Dim dt As New DataTable("Oprawy")
        Dim lines() As String = IO.File.ReadAllLines(path)

        If lines.Length < 2 Then Throw New Exception("CSV pusty")

        ' Nagłówek
        Dim headers() As String = Split(lines(0), ";")
        For Each h In headers
            dt.Columns.Add(Trim(h), GetType(String))
        Next

        ' Dane
        For i As Integer = 1 To lines.Length - 1
            Dim cells() As String = Split(lines(i), ";")
            Dim row As DataRow = dt.NewRow()
            For j As Integer = 0 To Math.Min(headers.Length - 1, cells.Length - 1)
                row(j) = Trim(cells(j))
            Next
            dt.Rows.Add(row)
        Next

        Return dt
    End Function


End Class
