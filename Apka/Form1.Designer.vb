<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As DataGridViewCellStyle = New DataGridViewCellStyle()
        tmrRefresh = New Timer(components)
        trayIcon = New NotifyIcon(components)
        trayMenu = New ContextMenuStrip(components)
        OtwórzToolStripMenuItem = New ToolStripMenuItem()
        ZamknijToolStripMenuItem = New ToolStripMenuItem()
        btnConnect = New Button()
        txtIP = New TextBox()
        Label1 = New Label()
        LblSutc = New Label()
        LblAwar = New Label()
        LblPraw = New Label()
        LblPrtn = New Label()
        LblWykl = New Label()
        LblFirm = New Label()
        LblPcbv = New Label()
        LblRtime = New Label()
        LblMPE12 = New Label()
        LblSiec = New Label()
        LblUps = New Label()
        Lblbat = New Label()
        LblBlok = New Label()
        LblInne = New Label()
        Label4 = New Label()
        Label5 = New Label()
        Label6 = New Label()
        Label7 = New Label()
        Label8 = New Label()
        Label9 = New Label()
        Label10 = New Label()
        Label11 = New Label()
        Label12 = New Label()
        Label13 = New Label()
        Label14 = New Label()
        Label15 = New Label()
        Label16 = New Label()
        pnlStatus = New Panel()
        lblStatus = New Label()
        btnExit = New Button()
        lblOdświeżanie = New Label()
        lblCountdown = New Label()
        btnDisconnect = New Button()
        txtLogin = New TextBox()
        txtPassword = New TextBox()
        lblLogin = New Label()
        lblHasło = New Label()
        lblOdpowiedzStanOpis = New Label()
        txtOdpowiedzStan = New TextBox()
        btnLangPL = New Button()
        btnLangEN = New Button()
        btnLangDE = New Button()
        btnResetCentralki = New Button()
        Label2 = New Label()
        Label3 = New Label()
        tabStan = New TabPage()
        tabTS = New TabPage()
        lblNrGrupy = New Label()
        txtNumer = New TextBox()
        btnWyslij = New Button()
        lblWszystkieGrupy = New Label()
        btnToggleWszystkie = New Button()
        lblIloscGrup = New Label()
        txtIloscGrup = New TextBox()
        btnUtworzGrupy = New Button()
        btnReset = New Button()
        pnlGrupy = New Panel()
        lblNrGrupyTCP = New Label()
        txtNumerTCP = New TextBox()
        btnWyslijTCPStart = New Button()
        lblWszystkieGrupyTCP = New Label()
        btnToggleWszystkieTCP = New Button()
        btnWyslijTCPStop = New Button()
        lblIloscGrupTCP = New Label()
        txtIloscGrupTCP = New TextBox()
        btnUtworzGrupyTCP = New Button()
        btnResetTCP = New Button()
        pnlGrupyTCP = New Panel()
        lblNrGrupyMigaj = New Label()
        txtNumerMigaj = New TextBox()
        btnWyslijMigajStart = New Button()
        lblNrOprawyMigaj = New Label()
        txtNumerOprawyMigaj = New TextBox()
        btnWyslijMigajStop = New Button()
        lblStatusTS = New Label()
        lblHistoriaOpis = New Label()
        btnCzyscHistorie = New Button()
        lstHistoria = New ListBox()
        tabStanOpraw = New TabPage()
        pnlHeader = New Panel()
        btnOdswiezOprawy = New Button()
        lblLicznikOpraw = New Label()
        pnlOdswiezStatus = New Panel()
        lblOdswiezOpis = New Label()
        dgvOprawy = New DataGridView()
        tabMigaj = New TabPage()
        tabMain = New TabControl()
        pnlSummary = New Panel()
        btnPobierzKonfig = New Button()
        trayMenu.SuspendLayout()
        tabStan.SuspendLayout()
        tabTS.SuspendLayout()
        tabStanOpraw.SuspendLayout()
        pnlHeader.SuspendLayout()
        CType(dgvOprawy, ComponentModel.ISupportInitialize).BeginInit()
        tabMain.SuspendLayout()
        SuspendLayout()
        ' 
        ' tmrRefresh
        ' 
        tmrRefresh.Interval = 1000
        ' 
        ' trayIcon
        ' 
        trayIcon.ContextMenuStrip = trayMenu
        trayIcon.Icon = CType(resources.GetObject("trayIcon.Icon"), Icon)
        trayIcon.Text = "MPII Monitor"
        ' 
        ' trayMenu
        ' 
        trayMenu.Items.AddRange(New ToolStripItem() {OtwórzToolStripMenuItem, ZamknijToolStripMenuItem})
        trayMenu.Name = "trayMenu"
        trayMenu.Size = New Size(118, 48)
        ' 
        ' OtwórzToolStripMenuItem
        ' 
        OtwórzToolStripMenuItem.Name = "OtwórzToolStripMenuItem"
        OtwórzToolStripMenuItem.Size = New Size(117, 22)
        OtwórzToolStripMenuItem.Text = "Otwórz"
        ' 
        ' ZamknijToolStripMenuItem
        ' 
        ZamknijToolStripMenuItem.Name = "ZamknijToolStripMenuItem"
        ZamknijToolStripMenuItem.Size = New Size(117, 22)
        ZamknijToolStripMenuItem.Text = "Zamknij"
        ' 
        ' btnConnect
        ' 
        btnConnect.Location = New Point(21, 136)
        btnConnect.Name = "btnConnect"
        btnConnect.Size = New Size(87, 29)
        btnConnect.TabIndex = 0
        btnConnect.Text = "Połącz"
        btnConnect.UseVisualStyleBackColor = True
        ' 
        ' txtIP
        ' 
        txtIP.Font = New Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(238))
        txtIP.Location = New Point(145, 22)
        txtIP.Name = "txtIP"
        txtIP.Size = New Size(144, 33)
        txtIP.TabIndex = 2
        txtIP.Text = "192.168.1.248"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 12.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(238))
        Label1.Location = New Point(25, 28)
        Label1.Name = "Label1"
        Label1.Size = New Size(70, 21)
        Label1.TabIndex = 3
        Label1.Text = "Adres IP:"
        ' 
        ' LblSutc
        ' 
        LblSutc.AutoSize = True
        LblSutc.Location = New Point(25, 262)
        LblSutc.Name = "LblSutc"
        LblSutc.Size = New Size(127, 15)
        LblSutc.TabIndex = 6
        LblSutc.Text = "Aktualny czas centralki"
        ' 
        ' LblAwar
        ' 
        LblAwar.AutoSize = True
        LblAwar.Location = New Point(25, 290)
        LblAwar.Name = "LblAwar"
        LblAwar.Size = New Size(94, 15)
        LblAwar.TabIndex = 7
        LblAwar.Text = "Oprawy w awarii"
        ' 
        ' LblPraw
        ' 
        LblPraw.AutoSize = True
        LblPraw.Location = New Point(25, 316)
        LblPraw.Name = "LblPraw"
        LblPraw.Size = New Size(145, 15)
        LblPraw.TabIndex = 8
        LblPraw.Text = "Oprawy w pracy awaryjnej"
        ' 
        ' LblPrtn
        ' 
        LblPrtn.AutoSize = True
        LblPrtn.Location = New Point(25, 342)
        LblPrtn.Name = "LblPrtn"
        LblPrtn.Size = New Size(140, 15)
        LblPrtn.TabIndex = 9
        LblPrtn.Text = "Oprawy w trybie nocnym"
        ' 
        ' LblWykl
        ' 
        LblWykl.AutoSize = True
        LblWykl.Location = New Point(25, 368)
        LblWykl.Name = "LblWykl"
        LblWykl.Size = New Size(113, 15)
        LblWykl.TabIndex = 10
        LblWykl.Text = "Oprawy wykluczone"
        ' 
        ' LblFirm
        ' 
        LblFirm.AutoSize = True
        LblFirm.Location = New Point(25, 394)
        LblFirm.Name = "LblFirm"
        LblFirm.Size = New Size(96, 15)
        LblFirm.TabIndex = 11
        LblFirm.Text = "Numer Firmware"
        ' 
        ' LblPcbv
        ' 
        LblPcbv.AutoSize = True
        LblPcbv.Location = New Point(25, 420)
        LblPcbv.Name = "LblPcbv"
        LblPcbv.Size = New Size(118, 15)
        LblPcbv.TabIndex = 12
        LblPcbv.Text = "Numer płyty głównej"
        ' 
        ' LblRtime
        ' 
        LblRtime.AutoSize = True
        LblRtime.Location = New Point(25, 446)
        LblRtime.Name = "LblRtime"
        LblRtime.Size = New Size(221, 15)
        LblRtime.TabIndex = 13
        LblRtime.Text = "Czas pracy centralki od resetu/załączenia"
        ' 
        ' LblMPE12
        ' 
        LblMPE12.AutoSize = True
        LblMPE12.Font = New Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(238))
        LblMPE12.Location = New Point(25, 482)
        LblMPE12.Name = "LblMPE12"
        LblMPE12.Size = New Size(244, 20)
        LblMPE12.TabIndex = 14
        LblMPE12.Text = "Komunikaty na wyjściu MPE-12-4"
        ' 
        ' LblSiec
        ' 
        LblSiec.AutoSize = True
        LblSiec.Location = New Point(25, 518)
        LblSiec.Name = "LblSiec"
        LblSiec.Size = New Size(69, 15)
        LblSiec.TabIndex = 15
        LblSiec.Text = "Awaria LAN"
        ' 
        ' LblUps
        ' 
        LblUps.AutoSize = True
        LblUps.Location = New Point(25, 542)
        LblUps.Name = "LblUps"
        LblUps.Size = New Size(67, 15)
        LblUps.TabIndex = 16
        LblUps.Text = "Awaria UPS"
        ' 
        ' Lblbat
        ' 
        Lblbat.AutoSize = True
        Lblbat.Location = New Point(25, 566)
        Lblbat.Name = "Lblbat"
        Lblbat.Size = New Size(79, 15)
        Lblbat.TabIndex = 17
        Lblbat.Text = "Awaria baterii"
        ' 
        ' LblBlok
        ' 
        LblBlok.AutoSize = True
        LblBlok.Location = New Point(25, 614)
        LblBlok.Name = "LblBlok"
        LblBlok.Size = New Size(85, 15)
        LblBlok.TabIndex = 18
        LblBlok.Text = "Blokada opraw"
        ' 
        ' LblInne
        ' 
        LblInne.AutoSize = True
        LblInne.Location = New Point(25, 590)
        LblInne.Name = "LblInne"
        LblInne.Size = New Size(69, 15)
        LblInne.TabIndex = 19
        LblInne.Text = "Awarie inne"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(369, 262)
        Label4.Name = "Label4"
        Label4.Size = New Size(16, 15)
        Label4.TabIndex = 22
        Label4.Text = "..."
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(369, 290)
        Label5.Name = "Label5"
        Label5.Size = New Size(16, 15)
        Label5.TabIndex = 23
        Label5.Text = "..."
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(369, 316)
        Label6.Name = "Label6"
        Label6.Size = New Size(16, 15)
        Label6.TabIndex = 24
        Label6.Text = "..."
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Location = New Point(369, 342)
        Label7.Name = "Label7"
        Label7.Size = New Size(16, 15)
        Label7.TabIndex = 25
        Label7.Text = "..."
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Location = New Point(369, 368)
        Label8.Name = "Label8"
        Label8.Size = New Size(16, 15)
        Label8.TabIndex = 26
        Label8.Text = "..."
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Location = New Point(369, 394)
        Label9.Name = "Label9"
        Label9.Size = New Size(16, 15)
        Label9.TabIndex = 27
        Label9.Text = "..."
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Location = New Point(369, 420)
        Label10.Name = "Label10"
        Label10.Size = New Size(16, 15)
        Label10.TabIndex = 28
        Label10.Text = "..."
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Location = New Point(369, 446)
        Label11.Name = "Label11"
        Label11.Size = New Size(16, 15)
        Label11.TabIndex = 29
        Label11.Text = "..."
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.Location = New Point(369, 518)
        Label12.Name = "Label12"
        Label12.Size = New Size(16, 15)
        Label12.TabIndex = 30
        Label12.Text = "..."
        ' 
        ' Label13
        ' 
        Label13.AutoSize = True
        Label13.Location = New Point(369, 542)
        Label13.Name = "Label13"
        Label13.Size = New Size(16, 15)
        Label13.TabIndex = 31
        Label13.Text = "..."
        ' 
        ' Label14
        ' 
        Label14.AutoSize = True
        Label14.Location = New Point(369, 566)
        Label14.Name = "Label14"
        Label14.Size = New Size(16, 15)
        Label14.TabIndex = 32
        Label14.Text = "..."
        ' 
        ' Label15
        ' 
        Label15.AutoSize = True
        Label15.Location = New Point(369, 590)
        Label15.Name = "Label15"
        Label15.Size = New Size(16, 15)
        Label15.TabIndex = 33
        Label15.Text = "..."
        ' 
        ' Label16
        ' 
        Label16.AutoSize = True
        Label16.Location = New Point(369, 614)
        Label16.Name = "Label16"
        Label16.Size = New Size(16, 15)
        Label16.TabIndex = 34
        Label16.Text = "..."
        ' 
        ' pnlStatus
        ' 
        pnlStatus.BackColor = Color.Silver
        pnlStatus.Location = New Point(341, 70)
        pnlStatus.Name = "pnlStatus"
        pnlStatus.Size = New Size(20, 20)
        pnlStatus.TabIndex = 35
        ' 
        ' lblStatus
        ' 
        lblStatus.AutoSize = True
        lblStatus.Location = New Point(308, 33)
        lblStatus.Name = "lblStatus"
        lblStatus.Size = New Size(89, 15)
        lblStatus.TabIndex = 36
        lblStatus.Text = "Brak połączenia"
        ' 
        ' btnExit
        ' 
        btnExit.Location = New Point(205, 136)
        btnExit.Name = "btnExit"
        btnExit.Size = New Size(84, 29)
        btnExit.TabIndex = 37
        btnExit.Text = "Zamknij"
        btnExit.UseVisualStyleBackColor = True
        ' 
        ' lblOdświeżanie
        ' 
        lblOdświeżanie.AutoSize = True
        lblOdświeżanie.Location = New Point(431, 33)
        lblOdświeżanie.Name = "lblOdświeżanie"
        lblOdświeżanie.Size = New Size(73, 15)
        lblOdświeżanie.TabIndex = 38
        lblOdświeżanie.Text = "Odświeżanie"
        ' 
        ' lblCountdown
        ' 
        lblCountdown.AutoSize = True
        lblCountdown.Location = New Point(463, 70)
        lblCountdown.Name = "lblCountdown"
        lblCountdown.Size = New Size(12, 15)
        lblCountdown.TabIndex = 39
        lblCountdown.Text = "-"
        ' 
        ' btnDisconnect
        ' 
        btnDisconnect.Location = New Point(114, 136)
        btnDisconnect.Name = "btnDisconnect"
        btnDisconnect.Size = New Size(85, 29)
        btnDisconnect.TabIndex = 40
        btnDisconnect.Text = "Rozłącz"
        btnDisconnect.UseVisualStyleBackColor = True
        ' 
        ' txtLogin
        ' 
        txtLogin.Location = New Point(23, 89)
        txtLogin.Name = "txtLogin"
        txtLogin.Size = New Size(123, 23)
        txtLogin.TabIndex = 41
        ' 
        ' txtPassword
        ' 
        txtPassword.Location = New Point(166, 89)
        txtPassword.Name = "txtPassword"
        txtPassword.Size = New Size(123, 23)
        txtPassword.TabIndex = 42
        txtPassword.UseSystemPasswordChar = True
        ' 
        ' lblLogin
        ' 
        lblLogin.AutoSize = True
        lblLogin.Location = New Point(25, 70)
        lblLogin.Name = "lblLogin"
        lblLogin.Size = New Size(37, 15)
        lblLogin.TabIndex = 43
        lblLogin.Text = "Login"
        ' 
        ' lblHasło
        ' 
        lblHasło.AutoSize = True
        lblHasło.Location = New Point(166, 70)
        lblHasło.Name = "lblHasło"
        lblHasło.Size = New Size(37, 15)
        lblHasło.TabIndex = 44
        lblHasło.Text = "Hasło"
        ' 
        ' lblOdpowiedzStanOpis
        ' 
        lblOdpowiedzStanOpis.AutoSize = True
        lblOdpowiedzStanOpis.Location = New Point(25, 175)
        lblOdpowiedzStanOpis.Name = "lblOdpowiedzStanOpis"
        lblOdpowiedzStanOpis.Size = New Size(113, 15)
        lblOdpowiedzStanOpis.TabIndex = 60
        lblOdpowiedzStanOpis.Text = "Odpowiedź serwera:"
        ' 
        ' txtOdpowiedzStan
        ' 
        txtOdpowiedzStan.Location = New Point(25, 193)
        txtOdpowiedzStan.Multiline = True
        txtOdpowiedzStan.Name = "txtOdpowiedzStan"
        txtOdpowiedzStan.ReadOnly = True
        txtOdpowiedzStan.ScrollBars = ScrollBars.Vertical
        txtOdpowiedzStan.Size = New Size(601, 60)
        txtOdpowiedzStan.TabIndex = 61
        ' 
        ' btnLangPL
        ' 
        btnLangPL.BackColor = Color.FromArgb(CByte(25), CByte(25), CByte(25))
        btnLangPL.Cursor = Cursors.Hand
        btnLangPL.FlatAppearance.BorderColor = Color.DimGray
        btnLangPL.FlatStyle = FlatStyle.Flat
        btnLangPL.Font = New Font("Segoe UI Emoji", 16.0F)
        btnLangPL.Location = New Point(25, 799)
        btnLangPL.Name = "btnLangPL"
        btnLangPL.Size = New Size(52, 42)
        btnLangPL.TabIndex = 70
        btnLangPL.Text = "🇵🇱"
        btnLangPL.UseVisualStyleBackColor = False
        ' 
        ' btnLangEN
        ' 
        btnLangEN.BackColor = Color.FromArgb(CByte(25), CByte(25), CByte(25))
        btnLangEN.Cursor = Cursors.Hand
        btnLangEN.FlatAppearance.BorderColor = Color.DimGray
        btnLangEN.FlatStyle = FlatStyle.Flat
        btnLangEN.Font = New Font("Segoe UI Emoji", 16.0F)
        btnLangEN.Location = New Point(85, 799)
        btnLangEN.Name = "btnLangEN"
        btnLangEN.Size = New Size(52, 42)
        btnLangEN.TabIndex = 71
        btnLangEN.Text = "🇬🇧"
        btnLangEN.UseVisualStyleBackColor = False
        ' 
        ' btnLangDE
        ' 
        btnLangDE.BackColor = Color.FromArgb(CByte(25), CByte(25), CByte(25))
        btnLangDE.Cursor = Cursors.Hand
        btnLangDE.FlatAppearance.BorderColor = Color.DimGray
        btnLangDE.FlatStyle = FlatStyle.Flat
        btnLangDE.Font = New Font("Segoe UI Emoji", 16.0F)
        btnLangDE.Location = New Point(145, 799)
        btnLangDE.Name = "btnLangDE"
        btnLangDE.Size = New Size(52, 42)
        btnLangDE.TabIndex = 72
        btnLangDE.Text = "🇩🇪"
        btnLangDE.UseVisualStyleBackColor = False
        ' 
        ' btnResetCentralki
        ' 
        btnResetCentralki.Location = New Point(449, 136)
        btnResetCentralki.Name = "btnResetCentralki"
        btnResetCentralki.Size = New Size(177, 29)
        btnResetCentralki.TabIndex = 80
        btnResetCentralki.Text = "Reset centralki"
        btnResetCentralki.UseVisualStyleBackColor = True
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(940, 808)
        Label2.Name = "Label2"
        Label2.Size = New Size(226, 15)
        Label2.TabIndex = 81
        Label2.Text = "Tomasz Pietrzak Amatech Elektrotechnika"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(999, 835)
        Label3.Name = "Label3"
        Label3.Size = New Size(167, 15)
        Label3.TabIndex = 82
        Label3.Text = "Powered by Claude Sonnet 4.6"
        ' 
        ' tabStan
        ' 
        tabStan.Controls.Add(Label3)
        tabStan.Controls.Add(Label2)
        tabStan.Controls.Add(btnResetCentralki)
        tabStan.Controls.Add(Label1)
        tabStan.Controls.Add(btnConnect)
        tabStan.Controls.Add(lblHasło)
        tabStan.Controls.Add(txtIP)
        tabStan.Controls.Add(lblLogin)
        tabStan.Controls.Add(txtPassword)
        tabStan.Controls.Add(txtLogin)
        tabStan.Controls.Add(btnDisconnect)
        tabStan.Controls.Add(lblCountdown)
        tabStan.Controls.Add(lblOdświeżanie)
        tabStan.Controls.Add(btnExit)
        tabStan.Controls.Add(lblStatus)
        tabStan.Controls.Add(pnlStatus)
        tabStan.Controls.Add(lblOdpowiedzStanOpis)
        tabStan.Controls.Add(txtOdpowiedzStan)
        tabStan.Controls.Add(LblSutc)
        tabStan.Controls.Add(Label4)
        tabStan.Controls.Add(LblAwar)
        tabStan.Controls.Add(Label5)
        tabStan.Controls.Add(LblPraw)
        tabStan.Controls.Add(Label6)
        tabStan.Controls.Add(LblPrtn)
        tabStan.Controls.Add(Label7)
        tabStan.Controls.Add(LblWykl)
        tabStan.Controls.Add(Label8)
        tabStan.Controls.Add(LblFirm)
        tabStan.Controls.Add(Label9)
        tabStan.Controls.Add(LblPcbv)
        tabStan.Controls.Add(Label10)
        tabStan.Controls.Add(LblRtime)
        tabStan.Controls.Add(Label11)
        tabStan.Controls.Add(LblMPE12)
        tabStan.Controls.Add(LblSiec)
        tabStan.Controls.Add(Label12)
        tabStan.Controls.Add(LblUps)
        tabStan.Controls.Add(Label13)
        tabStan.Controls.Add(Lblbat)
        tabStan.Controls.Add(Label14)
        tabStan.Controls.Add(LblInne)
        tabStan.Controls.Add(Label15)
        tabStan.Controls.Add(LblBlok)
        tabStan.Controls.Add(Label16)
        tabStan.Controls.Add(btnLangPL)
        tabStan.Controls.Add(btnLangEN)
        tabStan.Controls.Add(btnLangDE)
        tabStan.Location = New Point(4, 24)
        tabStan.Name = "tabStan"
        tabStan.Padding = New Padding(3)
        tabStan.Size = New Size(1308, 866)
        tabStan.TabIndex = 3
        tabStan.Text = "Stan Systemu"
        tabStan.UseVisualStyleBackColor = True
        ' 
        ' tabTS
        ' 
        tabTS.AutoScroll = True
        tabTS.Controls.Add(lblNrGrupy)
        tabTS.Controls.Add(txtNumer)
        tabTS.Controls.Add(btnWyslij)
        tabTS.Controls.Add(lblWszystkieGrupy)
        tabTS.Controls.Add(btnToggleWszystkie)
        tabTS.Controls.Add(lblIloscGrup)
        tabTS.Controls.Add(txtIloscGrup)
        tabTS.Controls.Add(btnUtworzGrupy)
        tabTS.Controls.Add(btnReset)
        tabTS.Controls.Add(pnlGrupy)
        tabTS.Controls.Add(lblNrGrupyTCP)
        tabTS.Controls.Add(txtNumerTCP)
        tabTS.Controls.Add(btnWyslijTCPStart)
        tabTS.Controls.Add(lblWszystkieGrupyTCP)
        tabTS.Controls.Add(btnToggleWszystkieTCP)
        tabTS.Controls.Add(btnWyslijTCPStop)
        tabTS.Controls.Add(lblIloscGrupTCP)
        tabTS.Controls.Add(txtIloscGrupTCP)
        tabTS.Controls.Add(btnUtworzGrupyTCP)
        tabTS.Controls.Add(btnResetTCP)
        tabTS.Controls.Add(pnlGrupyTCP)
        tabTS.Controls.Add(lblNrGrupyMigaj)
        tabTS.Controls.Add(txtNumerMigaj)
        tabTS.Controls.Add(btnWyslijMigajStart)
        tabTS.Controls.Add(lblNrOprawyMigaj)
        tabTS.Controls.Add(txtNumerOprawyMigaj)
        tabTS.Controls.Add(btnWyslijMigajStop)
        tabTS.Controls.Add(lblStatusTS)
        tabTS.Controls.Add(lblHistoriaOpis)
        tabTS.Controls.Add(btnCzyscHistorie)
        tabTS.Controls.Add(lstHistoria)
        tabTS.Location = New Point(4, 24)
        tabTS.Name = "tabTS"
        tabTS.Padding = New Padding(3)
        tabTS.Size = New Size(1308, 866)
        tabTS.TabIndex = 0
        tabTS.Text = "Testy"
        tabTS.UseVisualStyleBackColor = True
        ' 
        ' lblNrGrupy
        ' 
        lblNrGrupy.AutoSize = True
        lblNrGrupy.Location = New Point(32, 15)
        lblNrGrupy.Name = "lblNrGrupy"
        lblNrGrupy.Size = New Size(215, 15)
        lblNrGrupy.TabIndex = 50
        lblNrGrupy.Text = "Wyślij TS do pojedynczej grupy (0–127):"
        ' 
        ' txtNumer
        ' 
        txtNumer.Location = New Point(390, 12)
        txtNumer.Name = "txtNumer"
        txtNumer.Size = New Size(50, 23)
        txtNumer.TabIndex = 0
        txtNumer.TextAlign = HorizontalAlignment.Center
        ' 
        ' btnWyslij
        ' 
        btnWyslij.Location = New Point(477, 13)
        btnWyslij.Name = "btnWyslij"
        btnWyslij.Size = New Size(160, 53)
        btnWyslij.TabIndex = 1
        btnWyslij.Text = "Wykonaj TS"
        btnWyslij.UseVisualStyleBackColor = True
        ' 
        ' lblWszystkieGrupy
        ' 
        lblWszystkieGrupy.AutoSize = True
        lblWszystkieGrupy.Location = New Point(32, 55)
        lblWszystkieGrupy.Name = "lblWszystkieGrupy"
        lblWszystkieGrupy.Size = New Size(158, 15)
        lblWszystkieGrupy.TabIndex = 63
        lblWszystkieGrupy.Text = "Wyślij TS do wszystkich grup"
        ' 
        ' btnToggleWszystkie
        ' 
        btnToggleWszystkie.FlatStyle = FlatStyle.Flat
        btnToggleWszystkie.Location = New Point(390, 51)
        btnToggleWszystkie.Name = "btnToggleWszystkie"
        btnToggleWszystkie.Size = New Size(50, 23)
        btnToggleWszystkie.TabIndex = 62
        btnToggleWszystkie.Text = "NIE"
        btnToggleWszystkie.UseVisualStyleBackColor = False
        ' 
        ' lblIloscGrup
        ' 
        lblIloscGrup.AutoSize = True
        lblIloscGrup.Location = New Point(32, 90)
        lblIloscGrup.Name = "lblIloscGrup"
        lblIloscGrup.Size = New Size(125, 15)
        lblIloscGrup.TabIndex = 58
        lblIloscGrup.Text = "Podaj ilość grup do TS"
        ' 
        ' txtIloscGrup
        ' 
        txtIloscGrup.Location = New Point(390, 88)
        txtIloscGrup.MaxLength = 2
        txtIloscGrup.Name = "txtIloscGrup"
        txtIloscGrup.Size = New Size(50, 23)
        txtIloscGrup.TabIndex = 59
        txtIloscGrup.TextAlign = HorizontalAlignment.Center
        ' 
        ' btnUtworzGrupy
        ' 
        btnUtworzGrupy.Location = New Point(265, 119)
        btnUtworzGrupy.Name = "btnUtworzGrupy"
        btnUtworzGrupy.Size = New Size(175, 31)
        btnUtworzGrupy.TabIndex = 60
        btnUtworzGrupy.Text = "Zatwierdź ilość grup do TS"
        btnUtworzGrupy.UseVisualStyleBackColor = True
        ' 
        ' btnReset
        ' 
        btnReset.Location = New Point(32, 120)
        btnReset.Name = "btnReset"
        btnReset.Size = New Size(120, 31)
        btnReset.TabIndex = 64
        btnReset.Text = "Resetuj ustawienia"
        btnReset.UseVisualStyleBackColor = False
        ' 
        ' pnlGrupy
        ' 
        pnlGrupy.BorderStyle = BorderStyle.FixedSingle
        pnlGrupy.Location = New Point(32, 162)
        pnlGrupy.Name = "pnlGrupy"
        pnlGrupy.Size = New Size(605, 189)
        pnlGrupy.TabIndex = 61
        ' 
        ' lblNrGrupyTCP
        ' 
        lblNrGrupyTCP.AutoSize = True
        lblNrGrupyTCP.Location = New Point(32, 376)
        lblNrGrupyTCP.Name = "lblNrGrupyTCP"
        lblNrGrupyTCP.Size = New Size(223, 15)
        lblNrGrupyTCP.TabIndex = 69
        lblNrGrupyTCP.Text = "Wyślij TCP do pojedynczej grupy (0–127):"
        ' 
        ' txtNumerTCP
        ' 
        txtNumerTCP.Location = New Point(390, 373)
        txtNumerTCP.Name = "txtNumerTCP"
        txtNumerTCP.Size = New Size(50, 23)
        txtNumerTCP.TabIndex = 67
        txtNumerTCP.TextAlign = HorizontalAlignment.Center
        ' 
        ' btnWyslijTCPStart
        ' 
        btnWyslijTCPStart.Location = New Point(477, 376)
        btnWyslijTCPStart.Name = "btnWyslijTCPStart"
        btnWyslijTCPStart.Size = New Size(160, 53)
        btnWyslijTCPStart.TabIndex = 68
        btnWyslijTCPStart.Text = "Wykonaj TCP"
        btnWyslijTCPStart.UseVisualStyleBackColor = True
        ' 
        ' lblWszystkieGrupyTCP
        ' 
        lblWszystkieGrupyTCP.AutoSize = True
        lblWszystkieGrupyTCP.Location = New Point(32, 414)
        lblWszystkieGrupyTCP.Name = "lblWszystkieGrupyTCP"
        lblWszystkieGrupyTCP.Size = New Size(166, 15)
        lblWszystkieGrupyTCP.TabIndex = 79
        lblWszystkieGrupyTCP.Text = "Wyślij TCP do wszystkich grup"
        ' 
        ' btnToggleWszystkieTCP
        ' 
        btnToggleWszystkieTCP.FlatStyle = FlatStyle.Flat
        btnToggleWszystkieTCP.Location = New Point(390, 410)
        btnToggleWszystkieTCP.Name = "btnToggleWszystkieTCP"
        btnToggleWszystkieTCP.Size = New Size(50, 23)
        btnToggleWszystkieTCP.TabIndex = 78
        btnToggleWszystkieTCP.Text = "NIE"
        btnToggleWszystkieTCP.UseVisualStyleBackColor = False
        ' 
        ' btnWyslijTCPStop
        ' 
        btnWyslijTCPStop.Location = New Point(477, 448)
        btnWyslijTCPStop.Name = "btnWyslijTCPStop"
        btnWyslijTCPStop.Size = New Size(160, 53)
        btnWyslijTCPStop.TabIndex = 81
        btnWyslijTCPStop.Text = "Zatrzymaj TCP"
        btnWyslijTCPStop.UseVisualStyleBackColor = True
        ' 
        ' lblIloscGrupTCP
        ' 
        lblIloscGrupTCP.AutoSize = True
        lblIloscGrupTCP.Location = New Point(32, 450)
        lblIloscGrupTCP.Name = "lblIloscGrupTCP"
        lblIloscGrupTCP.Size = New Size(133, 15)
        lblIloscGrupTCP.TabIndex = 74
        lblIloscGrupTCP.Text = "Podaj ilość grup do TCP"
        ' 
        ' txtIloscGrupTCP
        ' 
        txtIloscGrupTCP.Location = New Point(390, 447)
        txtIloscGrupTCP.MaxLength = 2
        txtIloscGrupTCP.Name = "txtIloscGrupTCP"
        txtIloscGrupTCP.Size = New Size(50, 23)
        txtIloscGrupTCP.TabIndex = 75
        txtIloscGrupTCP.TextAlign = HorizontalAlignment.Center
        ' 
        ' btnUtworzGrupyTCP
        ' 
        btnUtworzGrupyTCP.Location = New Point(265, 480)
        btnUtworzGrupyTCP.Name = "btnUtworzGrupyTCP"
        btnUtworzGrupyTCP.Size = New Size(175, 31)
        btnUtworzGrupyTCP.TabIndex = 76
        btnUtworzGrupyTCP.Text = "Zatwierdź ilość grup do TCP"
        btnUtworzGrupyTCP.UseVisualStyleBackColor = True
        ' 
        ' btnResetTCP
        ' 
        btnResetTCP.Location = New Point(32, 480)
        btnResetTCP.Name = "btnResetTCP"
        btnResetTCP.Size = New Size(120, 31)
        btnResetTCP.TabIndex = 80
        btnResetTCP.Text = "Resetuj ustawienia"
        btnResetTCP.UseVisualStyleBackColor = False
        ' 
        ' pnlGrupyTCP
        ' 
        pnlGrupyTCP.BorderStyle = BorderStyle.FixedSingle
        pnlGrupyTCP.Location = New Point(32, 521)
        pnlGrupyTCP.Name = "pnlGrupyTCP"
        pnlGrupyTCP.Size = New Size(605, 189)
        pnlGrupyTCP.TabIndex = 77
        ' 
        ' lblNrGrupyMigaj
        ' 
        lblNrGrupyMigaj.AutoSize = True
        lblNrGrupyMigaj.Location = New Point(32, 730)
        lblNrGrupyMigaj.Name = "lblNrGrupyMigaj"
        lblNrGrupyMigaj.Size = New Size(214, 15)
        lblNrGrupyMigaj.TabIndex = 86
        lblNrGrupyMigaj.Text = "Wyślij migaj LED do pojedynczej grupy:"
        ' 
        ' txtNumerMigaj
        ' 
        txtNumerMigaj.Location = New Point(360, 753)
        txtNumerMigaj.MaxLength = 3
        txtNumerMigaj.Name = "txtNumerMigaj"
        txtNumerMigaj.Size = New Size(80, 23)
        txtNumerMigaj.TabIndex = 82
        txtNumerMigaj.TextAlign = HorizontalAlignment.Center
        ' 
        ' btnWyslijMigajStart
        ' 
        btnWyslijMigajStart.Location = New Point(505, 723)
        btnWyslijMigajStart.Name = "btnWyslijMigajStart"
        btnWyslijMigajStart.Size = New Size(132, 53)
        btnWyslijMigajStart.TabIndex = 84
        btnWyslijMigajStart.Text = "Wykonaj migaj LED"
        btnWyslijMigajStart.UseVisualStyleBackColor = True
        ' 
        ' lblNrOprawyMigaj
        ' 
        lblNrOprawyMigaj.AutoSize = True
        lblNrOprawyMigaj.Location = New Point(32, 786)
        lblNrOprawyMigaj.Name = "lblNrOprawyMigaj"
        lblNrOprawyMigaj.Size = New Size(261, 15)
        lblNrOprawyMigaj.TabIndex = 87
        lblNrOprawyMigaj.Text = "Wyślij migaj LED do pojedynczej oprawy (adres):"
        ' 
        ' txtNumerOprawyMigaj
        ' 
        txtNumerOprawyMigaj.Location = New Point(360, 816)
        txtNumerOprawyMigaj.MaxLength = 8
        txtNumerOprawyMigaj.Name = "txtNumerOprawyMigaj"
        txtNumerOprawyMigaj.Size = New Size(80, 23)
        txtNumerOprawyMigaj.TabIndex = 83
        txtNumerOprawyMigaj.TextAlign = HorizontalAlignment.Center
        ' 
        ' btnWyslijMigajStop
        ' 
        btnWyslijMigajStop.Location = New Point(505, 786)
        btnWyslijMigajStop.Name = "btnWyslijMigajStop"
        btnWyslijMigajStop.Size = New Size(132, 53)
        btnWyslijMigajStop.TabIndex = 85
        btnWyslijMigajStop.Text = "Zatrzymaj migaj LED"
        btnWyslijMigajStop.UseVisualStyleBackColor = True
        ' 
        ' lblStatusTS
        ' 
        lblStatusTS.AutoSize = True
        lblStatusTS.Location = New Point(669, 15)
        lblStatusTS.Name = "lblStatusTS"
        lblStatusTS.Size = New Size(51, 15)
        lblStatusTS.TabIndex = 54
        lblStatusTS.Text = "Status: –"
        ' 
        ' lblHistoriaOpis
        ' 
        lblHistoriaOpis.AutoSize = True
        lblHistoriaOpis.Location = New Point(669, 63)
        lblHistoriaOpis.Name = "lblHistoriaOpis"
        lblHistoriaOpis.Size = New Size(98, 15)
        lblHistoriaOpis.TabIndex = 55
        lblHistoriaOpis.Text = "Historia komend:"
        ' 
        ' btnCzyscHistorie
        ' 
        btnCzyscHistorie.Location = New Point(1119, 10)
        btnCzyscHistorie.Name = "btnCzyscHistorie"
        btnCzyscHistorie.Size = New Size(150, 56)
        btnCzyscHistorie.TabIndex = 56
        btnCzyscHistorie.Text = "Wyczyść historię"
        btnCzyscHistorie.UseVisualStyleBackColor = True
        ' 
        ' lstHistoria
        ' 
        lstHistoria.Font = New Font("Consolas", 9.0F)
        lstHistoria.FormattingEnabled = True
        lstHistoria.ItemHeight = 14
        lstHistoria.Location = New Point(669, 93)
        lstHistoria.Name = "lstHistoria"
        lstHistoria.Size = New Size(600, 746)
        lstHistoria.TabIndex = 57
        ' 
        ' tabStanOpraw
        ' 
        tabStanOpraw.BackColor = Color.FromArgb(CByte(30), CByte(30), CByte(30))
        tabStanOpraw.Controls.Add(pnlHeader)
        tabStanOpraw.Controls.Add(dgvOprawy)
        tabStanOpraw.Location = New Point(4, 24)
        tabStanOpraw.Name = "tabStanOpraw"
        tabStanOpraw.Padding = New Padding(3)
        tabStanOpraw.Size = New Size(1308, 866)
        tabStanOpraw.TabIndex = 1
        tabStanOpraw.Text = "Stan Opraw"
        tabStanOpraw.UseVisualStyleBackColor = True
        ' 
        ' pnlHeader
        ' 
        pnlHeader.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        pnlHeader.Controls.Add(btnPobierzKonfig)
        pnlHeader.Controls.Add(btnOdswiezOprawy)
        pnlHeader.Controls.Add(lblLicznikOpraw)
        pnlHeader.Controls.Add(pnlOdswiezStatus)
        pnlHeader.Controls.Add(lblOdswiezOpis)
        pnlHeader.Dock = DockStyle.Top
        pnlHeader.Location = New Point(3, 3)
        pnlHeader.Name = "pnlHeader"
        pnlHeader.Size = New Size(1302, 46)
        pnlHeader.TabIndex = 0
        ' 
        ' btnOdswiezOprawy
        ' 
        btnOdswiezOprawy.BackColor = Color.FromArgb(CByte(0), CByte(122), CByte(204))
        btnOdswiezOprawy.Cursor = Cursors.Hand
        btnOdswiezOprawy.FlatAppearance.BorderColor = Color.FromArgb(CByte(0), CByte(122), CByte(204))
        btnOdswiezOprawy.FlatStyle = FlatStyle.Flat
        btnOdswiezOprawy.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        btnOdswiezOprawy.ForeColor = Color.White
        btnOdswiezOprawy.Location = New Point(8, 8)
        btnOdswiezOprawy.Name = "btnOdswiezOprawy"
        btnOdswiezOprawy.Size = New Size(130, 30)
        btnOdswiezOprawy.TabIndex = 0
        btnOdswiezOprawy.Text = "Odśwież"
        btnOdswiezOprawy.UseVisualStyleBackColor = False
        ' 
        ' lblLicznikOpraw
        ' 
        lblLicznikOpraw.AutoSize = True
        lblLicznikOpraw.Font = New Font("Segoe UI", 9.0F)
        lblLicznikOpraw.ForeColor = Color.FromArgb(CByte(180), CByte(180), CByte(180))
        lblLicznikOpraw.Location = New Point(150, 14)
        lblLicznikOpraw.Name = "lblLicznikOpraw"
        lblLicznikOpraw.Size = New Size(59, 15)
        lblLicznikOpraw.TabIndex = 1
        lblLicznikOpraw.Text = "Oprawy: -"
        ' 
        ' pnlOdswiezStatus
        ' 
        pnlOdswiezStatus.BackColor = Color.Gray
        pnlOdswiezStatus.Location = New Point(260, 17)
        pnlOdswiezStatus.Name = "pnlOdswiezStatus"
        pnlOdswiezStatus.Size = New Size(12, 12)
        pnlOdswiezStatus.TabIndex = 2
        ' 
        ' lblOdswiezOpis
        ' 
        lblOdswiezOpis.AutoSize = True
        lblOdswiezOpis.Font = New Font("Segoe UI", 9.0F)
        lblOdswiezOpis.ForeColor = Color.FromArgb(CByte(180), CByte(180), CByte(180))
        lblOdswiezOpis.Location = New Point(280, 14)
        lblOdswiezOpis.Name = "lblOdswiezOpis"
        lblOdswiezOpis.Size = New Size(129, 15)
        lblOdswiezOpis.TabIndex = 3
        lblOdswiezOpis.Text = "Ostatnie odświeżenie: -"
        ' 
        ' dgvOprawy
        ' 
        dgvOprawy.AllowUserToAddRows = False
        dgvOprawy.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = Color.FromArgb(CByte(37), CByte(37), CByte(38))
        dgvOprawy.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        dgvOprawy.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        dgvOprawy.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        dgvOprawy.BackgroundColor = Color.FromArgb(CByte(30), CByte(30), CByte(30))
        dgvOprawy.BorderStyle = BorderStyle.None
        dgvOprawy.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        DataGridViewCellStyle2.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        DataGridViewCellStyle2.ForeColor = Color.FromArgb(CByte(0), CByte(122), CByte(204))
        DataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.True
        dgvOprawy.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        dgvOprawy.ColumnHeadersHeight = 32
        DataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        DataGridViewCellStyle3.Font = New Font("Consolas", 9.5F)
        DataGridViewCellStyle3.ForeColor = Color.FromArgb(CByte(212), CByte(212), CByte(212))
        DataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(CByte(0), CByte(122), CByte(204))
        DataGridViewCellStyle3.SelectionForeColor = Color.White
        DataGridViewCellStyle3.WrapMode = DataGridViewTriState.True
        dgvOprawy.DefaultCellStyle = DataGridViewCellStyle3
        dgvOprawy.EnableHeadersVisualStyles = False
        dgvOprawy.GridColor = Color.FromArgb(CByte(63), CByte(63), CByte(70))
        dgvOprawy.Location = New Point(0, 46)
        dgvOprawy.MultiSelect = False
        dgvOprawy.Name = "dgvOprawy"
        dgvOprawy.ReadOnly = True
        dgvOprawy.RowHeadersVisible = False
        dgvOprawy.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvOprawy.Size = New Size(1308, 820)
        dgvOprawy.TabIndex = 1
        ' 
        ' tabMigaj
        ' 
        tabMigaj.Location = New Point(4, 24)
        tabMigaj.Name = "tabMigaj"
        tabMigaj.Padding = New Padding(3)
        tabMigaj.Size = New Size(1308, 866)
        tabMigaj.TabIndex = 2
        tabMigaj.Text = "Miganie LED"
        tabMigaj.UseVisualStyleBackColor = True
        ' 
        ' tabMain
        ' 
        tabMain.Controls.Add(tabStan)
        tabMain.Controls.Add(tabTS)
        tabMain.Controls.Add(tabStanOpraw)
        tabMain.Controls.Add(tabMigaj)
        tabMain.Dock = DockStyle.Left
        tabMain.Location = New Point(0, 0)
        tabMain.Multiline = True
        tabMain.Name = "tabMain"
        tabMain.SelectedIndex = 0
        tabMain.Size = New Size(1316, 894)
        tabMain.TabIndex = 45
        ' 
        ' pnlSummary
        ' 
        pnlSummary.BackColor = Color.FromArgb(CByte(35), CByte(35), CByte(38))
        pnlSummary.Location = New Point(0, 46)
        pnlSummary.Name = "pnlSummary"
        pnlSummary.Size = New Size(1308, 36)
        pnlSummary.TabIndex = 0
        ' 
        ' btnPobierzKonfig
        ' 
        btnPobierzKonfig.Location = New Point(1088, 12)
        btnPobierzKonfig.Name = "btnPobierzKonfig"
        btnPobierzKonfig.Size = New Size(199, 23)
        btnPobierzKonfig.TabIndex = 4
        btnPobierzKonfig.Text = "Wgraj konfigurację z pliku"
        btnPobierzKonfig.UseVisualStyleBackColor = True
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1321, 894)
        Controls.Add(tabMain)
        FormBorderStyle = FormBorderStyle.Fixed3D
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "Form1"
        Text = "Maks Pro II tester"
        trayMenu.ResumeLayout(False)
        tabStan.ResumeLayout(False)
        tabStan.PerformLayout()
        tabTS.ResumeLayout(False)
        tabTS.PerformLayout()
        tabStanOpraw.ResumeLayout(False)
        pnlHeader.ResumeLayout(False)
        pnlHeader.PerformLayout()
        CType(dgvOprawy, ComponentModel.ISupportInitialize).EndInit()
        tabMain.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    '═══════════════════════════════════════════════════════════════
    ' DEKLARACJE KONTROLEK
    '═══════════════════════════════════════════════════════════════
    Friend WithEvents tmrRefresh As Timer
    Friend WithEvents trayIcon As NotifyIcon
    Friend WithEvents trayMenu As ContextMenuStrip
    Friend WithEvents OtwórzToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ZamknijToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnConnect As Button
    Friend WithEvents txtIP As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents LblSutc As Label
    Friend WithEvents LblAwar As Label
    Friend WithEvents LblPraw As Label
    Friend WithEvents LblPrtn As Label
    Friend WithEvents LblWykl As Label
    Friend WithEvents LblFirm As Label
    Friend WithEvents LblPcbv As Label
    Friend WithEvents LblRtime As Label
    Friend WithEvents LblMPE12 As Label
    Friend WithEvents LblSiec As Label
    Friend WithEvents LblUps As Label
    Friend WithEvents Lblbat As Label
    Friend WithEvents LblBlok As Label
    Friend WithEvents LblInne As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents pnlStatus As Panel
    Friend WithEvents lblStatus As Label
    Friend WithEvents btnExit As Button
    Friend WithEvents lblOdświeżanie As Label
    Friend WithEvents lblCountdown As Label
    Friend WithEvents btnDisconnect As Button
    Friend WithEvents txtLogin As TextBox
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents lblLogin As Label
    Friend WithEvents lblHasło As Label
    Friend WithEvents lblOdpowiedzStanOpis As Label
    Friend WithEvents txtOdpowiedzStan As TextBox
    Friend WithEvents btnLangPL As Button
    Friend WithEvents btnLangEN As Button
    Friend WithEvents btnLangDE As Button
    Friend WithEvents btnResetCentralki As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents tabStan As TabPage
    Friend WithEvents tabMain As TabControl
    Friend WithEvents tabTS As TabPage
    Friend WithEvents lblWszystkieGrupy As Label
    Friend WithEvents btnToggleWszystkie As Button
    Friend WithEvents lblNrGrupy As Label
    Friend WithEvents txtNumer As TextBox
    Friend WithEvents btnWyslij As Button
    Friend WithEvents lblIloscGrup As Label
    Friend WithEvents txtIloscGrup As TextBox
    Friend WithEvents btnUtworzGrupy As Button
    Friend WithEvents btnReset As Button
    Friend WithEvents pnlGrupy As Panel
    Friend WithEvents lblWszystkieGrupyTCP As Label
    Friend WithEvents btnToggleWszystkieTCP As Button
    Friend WithEvents lblNrGrupyTCP As Label
    Friend WithEvents txtNumerTCP As TextBox
    Friend WithEvents btnWyslijTCPStart As Button
    Friend WithEvents btnWyslijTCPStop As Button
    Friend WithEvents lblIloscGrupTCP As Label
    Friend WithEvents txtIloscGrupTCP As TextBox
    Friend WithEvents btnUtworzGrupyTCP As Button
    Friend WithEvents btnResetTCP As Button
    Friend WithEvents pnlGrupyTCP As Panel
    Friend WithEvents lblNrGrupyMigaj As Label
    Friend WithEvents txtNumerMigaj As TextBox
    Friend WithEvents lblNrOprawyMigaj As Label
    Friend WithEvents txtNumerOprawyMigaj As TextBox
    Friend WithEvents btnWyslijMigajStart As Button
    Friend WithEvents btnWyslijMigajStop As Button
    Friend WithEvents lblStatusTS As Label
    Friend WithEvents lblHistoriaOpis As Label
    Friend WithEvents btnCzyscHistorie As Button
    Friend WithEvents lstHistoria As ListBox
    Friend WithEvents tabStanOpraw As TabPage
    Friend WithEvents tabMigaj As TabPage
    ' Deklaracje:
    Friend WithEvents btnOdswiezOprawy As Button
    Friend WithEvents lblLicznikOpraw As Label
    Friend WithEvents pnlOdswiezStatus As Panel
    Friend WithEvents lblOdswiezOpis As Label
    Private lblSumTotal As Label
    Private lblSumTPN As Label
    Private lblSumSwiecTPN As Label
    Private lblSumMonit As Label
    Private lblSumSprawna As Label
    Private lblSumInne As Label
    ' Deklaracje (dodaj do istniejących):
    Friend WithEvents pnlSummary As Panel


    Friend WithEvents dgvOprawy As DataGridView
    Friend WithEvents pnlHeader As Panel
    Friend WithEvents btnPobierzKonfig As Button

End Class
