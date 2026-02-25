' ═══════════════════════════════════════════════════════════════
' Translations.vb
' ═══════════════════════════════════════════════════════════════

Public Enum Jezyk
    PL
    EN
    DE
End Enum

Public Module Translations

    Public CurrentJezyk As Jezyk = Jezyk.PL

    Private ReadOnly _teksty As New Dictionary(Of String, String)

    Sub New()

        ' ── Toggle TAK/NIE ────────────────────────────────────
        _teksty.Add("toggle.tak|PL", "TAK")
        _teksty.Add("toggle.tak|EN", "YES")
        _teksty.Add("toggle.tak|DE", "JA")

        _teksty.Add("toggle.nie|PL", "NIE")
        _teksty.Add("toggle.nie|EN", "NO")
        _teksty.Add("toggle.nie|DE", "NEIN")

        ' ── Wartości TAK/NIE (dane z centralki) ──────────────
        _teksty.Add("wartosc.tak|PL", "TAK")
        _teksty.Add("wartosc.tak|EN", "YES")
        _teksty.Add("wartosc.tak|DE", "JA")

        _teksty.Add("wartosc.nie|PL", "NIE")
        _teksty.Add("wartosc.nie|EN", "NO")
        _teksty.Add("wartosc.nie|DE", "NEIN")

        ' ── Zakładki TabControl ───────────────────────────────
        _teksty.Add("tab.stan|PL", "Stan Systemu")
        _teksty.Add("tab.stan|EN", "System Status")
        _teksty.Add("tab.stan|DE", "Systemzustand")

        _teksty.Add("tab.ts|PL", "Testy")
        _teksty.Add("tab.ts|EN", "Tests")
        _teksty.Add("tab.ts|DE", "Tests")

        ' DODANO: zakładka Stan Opraw
        _teksty.Add("tab.stanopraw|PL", "Stan Opraw")
        _teksty.Add("tab.stanopraw|EN", "Luminaire Status")
        _teksty.Add("tab.stanopraw|DE", "Leuchten-Status")

        _teksty.Add("tab.migaj|PL", "Miganie LED")
        _teksty.Add("tab.migaj|EN", "LED Blink")
        _teksty.Add("tab.migaj|DE", "LED Blinken")

        ' ── Status ogólny ─────────────────────────────────────
        _teksty.Add("status.brak_polaczenia|PL", "Brak połączenia")
        _teksty.Add("status.brak_polaczenia|EN", "No connection")
        _teksty.Add("status.brak_polaczenia|DE", "Keine Verbindung")

        _teksty.Add("status.polaczono|PL", "Połączono")
        _teksty.Add("status.polaczono|EN", "Connected")
        _teksty.Add("status.polaczono|DE", "Verbunden")

        _teksty.Add("status.rozlaczono|PL", "Rozłączono")
        _teksty.Add("status.rozlaczono|EN", "Disconnected")
        _teksty.Add("status.rozlaczono|DE", "Getrennt")

        _teksty.Add("status.blad_komunikacji|PL", "Błąd komunikacji")
        _teksty.Add("status.blad_komunikacji|EN", "Communication error")
        _teksty.Add("status.blad_komunikacji|DE", "Kommunikationsfehler")

        _teksty.Add("status.odswiezanie|PL", "Odświeżanie")
        _teksty.Add("status.odswiezanie|EN", "Refreshing")
        _teksty.Add("status.odswiezanie|DE", "Aktualisierung")

        ' ── Błędy połączenia ──────────────────────────────────
        _teksty.Add("err.podaj_login|PL", "Podaj login i hasło")
        _teksty.Add("err.podaj_login|EN", "Enter login and password")
        _teksty.Add("err.podaj_login|DE", "Login und Passwort eingeben")

        _teksty.Add("err.podaj_ip|PL", "Podaj adres IP")
        _teksty.Add("err.podaj_ip|EN", "Enter IP address")
        _teksty.Add("err.podaj_ip|DE", "IP-Adresse eingeben")

        _teksty.Add("err.nieprawidlowy_ip|PL", "Nieprawidłowy adres IP")
        _teksty.Add("err.nieprawidlowy_ip|EN", "Invalid IP address")
        _teksty.Add("err.nieprawidlowy_ip|DE", "Ungültige IP-Adresse")

        ' ── tabStan – przyciski ───────────────────────────────
        _teksty.Add("stan.btn_polacz|PL", "Połącz")
        _teksty.Add("stan.btn_polacz|EN", "Connect")
        _teksty.Add("stan.btn_polacz|DE", "Verbinden")

        _teksty.Add("stan.btn_rozlacz|PL", "Rozłącz")
        _teksty.Add("stan.btn_rozlacz|EN", "Disconnect")
        _teksty.Add("stan.btn_rozlacz|DE", "Trennen")

        _teksty.Add("stan.btn_zamknij|PL", "Zamknij")
        _teksty.Add("stan.btn_zamknij|EN", "Exit")
        _teksty.Add("stan.btn_zamknij|DE", "Beenden")

        ' ── tabStan – etykiety ────────────────────────────────
        _teksty.Add("stan.lbl_adres_ip|PL", "Adres IP:")
        _teksty.Add("stan.lbl_adres_ip|EN", "IP Address:")
        _teksty.Add("stan.lbl_adres_ip|DE", "IP-Adresse:")

        _teksty.Add("stan.lbl_login|PL", "Login")
        _teksty.Add("stan.lbl_login|EN", "Login")
        _teksty.Add("stan.lbl_login|DE", "Anmeldung")

        _teksty.Add("stan.lbl_haslo|PL", "Hasło")
        _teksty.Add("stan.lbl_haslo|EN", "Password")
        _teksty.Add("stan.lbl_haslo|DE", "Passwort")

        _teksty.Add("stan.lbl_odpowiedz|PL", "Odpowiedź serwera:")
        _teksty.Add("stan.lbl_odpowiedz|EN", "Server response:")
        _teksty.Add("stan.lbl_odpowiedz|DE", "Serverantwort:")

        ' ── tabStan – dane centralki ──────────────────────────
        _teksty.Add("stan.sutc|PL", "Aktualny czas centralki")
        _teksty.Add("stan.sutc|EN", "Current controller time")
        _teksty.Add("stan.sutc|DE", "Aktuelle Zentral-Zeit")

        ' POPRAWIONO: "Awaria" → "Oprawy w awarii"
        _teksty.Add("stan.awar|PL", "Oprawy w awarii")
        _teksty.Add("stan.awar|EN", "Luminaires in failure")
        _teksty.Add("stan.awar|DE", "Leuchten in Störung")

        ' POPRAWIONO: "Praca awaryjna" → "Oprawy w pracy awaryjnej"
        _teksty.Add("stan.praw|PL", "Oprawy w pracy awaryjnej")
        _teksty.Add("stan.praw|EN", "Luminaires in emergency mode")
        _teksty.Add("stan.praw|DE", "Leuchten im Notbetrieb")

        ' POPRAWIONO: "Tryb nocny" → "Oprawy w trybie nocnym"
        _teksty.Add("stan.prtn|PL", "Oprawy w trybie nocnym")
        _teksty.Add("stan.prtn|EN", "Luminaires in night mode")
        _teksty.Add("stan.prtn|DE", "Leuchten im Nachtbetrieb")

        _teksty.Add("stan.wykl|PL", "Oprawy wykluczone")
        _teksty.Add("stan.wykl|EN", "Luminaires excluded")
        _teksty.Add("stan.wykl|DE", "Leuchten ausgeschlossen")

        _teksty.Add("stan.firm|PL", "Numer Firmware")
        _teksty.Add("stan.firm|EN", "Firmware version")
        _teksty.Add("stan.firm|DE", "Firmware-Version")

        _teksty.Add("stan.pcbv|PL", "Numer płyty głównej")
        _teksty.Add("stan.pcbv|EN", "Main board number")
        _teksty.Add("stan.pcbv|DE", "Hauptplatinen-Nummer")

        ' POPRAWIONO: dodano "centralki"
        _teksty.Add("stan.rtime|PL", "Czas pracy centralki od resetu/załączenia")
        _teksty.Add("stan.rtime|EN", "Controller uptime since reset/power-on")
        _teksty.Add("stan.rtime|DE", "Betriebszeit der Zentrale seit Reset/Einschalten")

        _teksty.Add("stan.mpe12|PL", "Komunikaty na wyjściu MPE-12-4")
        _teksty.Add("stan.mpe12|EN", "Messages on MPE-12-4 output")
        _teksty.Add("stan.mpe12|DE", "Meldungen am MPE-12-4-Ausgang")

        _teksty.Add("stan.siec|PL", "Awaria LAN")
        _teksty.Add("stan.siec|EN", "LAN failure")
        _teksty.Add("stan.siec|DE", "LAN-Störung")

        _teksty.Add("stan.ups|PL", "Awaria UPS")
        _teksty.Add("stan.ups|EN", "UPS failure")
        _teksty.Add("stan.ups|DE", "USV-Störung")

        _teksty.Add("stan.bat|PL", "Awaria baterii")
        _teksty.Add("stan.bat|EN", "Battery failure")
        _teksty.Add("stan.bat|DE", "Batteriestörung")

        _teksty.Add("stan.inne|PL", "Awarie inne")
        _teksty.Add("stan.inne|EN", "Other failures")
        _teksty.Add("stan.inne|DE", "Sonstige Störungen")

        _teksty.Add("stan.blok|PL", "Blokada opraw")
        _teksty.Add("stan.blok|EN", "Luminaire lock")
        _teksty.Add("stan.blok|DE", "Leuchtensperre")

        ' ── tabTS – etykiety ──────────────────────────────────
        _teksty.Add("ts.lbl_nr_grupy|PL", "Wyślij TS do pojedynczej grupy (0-127):")
        _teksty.Add("ts.lbl_nr_grupy|EN", "Send FT to a single group (0-127):")
        _teksty.Add("ts.lbl_nr_grupy|DE", "FT an eine einzelne Gruppe senden (0-127):")

        _teksty.Add("ts.lbl_wszystkie|PL", "Wyślij TS do wszystkich grup")
        _teksty.Add("ts.lbl_wszystkie|EN", "Send FT to all groups")
        _teksty.Add("ts.lbl_wszystkie|DE", "FT an alle Gruppen senden")

        _teksty.Add("ts.lbl_ilosc|PL", "Podaj ilość grup do TS")
        _teksty.Add("ts.lbl_ilosc|EN", "Enter number of groups for FT")
        _teksty.Add("ts.lbl_ilosc|DE", "Anzahl der Gruppen für FT eingeben")

        ' ── tabTS – przyciski ─────────────────────────────────
        _teksty.Add("ts.btn_wyslij|PL", "Wykonaj TS")
        _teksty.Add("ts.btn_wyslij|EN", "Run FT")
        _teksty.Add("ts.btn_wyslij|DE", "FT ausführen")

        _teksty.Add("ts.btn_utworz|PL", "Zatwierdź ilość grup do TS")
        _teksty.Add("ts.btn_utworz|EN", "Confirm number of FT groups")
        _teksty.Add("ts.btn_utworz|DE", "Anzahl der FT-Gruppen bestätigen")

        _teksty.Add("ts.btn_reset|PL", "Resetuj ustawienia")
        _teksty.Add("ts.btn_reset|EN", "Reset settings")
        _teksty.Add("ts.btn_reset|DE", "Einstellungen zurücksetzen")

        _teksty.Add("ts.btn_czasc|PL", "Wyczyść historię")
        _teksty.Add("ts.btn_czasc|EN", "Clear history")
        _teksty.Add("ts.btn_czasc|DE", "Verlauf löschen")

        ' ── tabTS – historia / status ─────────────────────────
        _teksty.Add("ts.historia|PL", "Historia komend:")
        _teksty.Add("ts.historia|EN", "Command history:")
        _teksty.Add("ts.historia|DE", "Befehlsverlauf:")

        _teksty.Add("ts.status_domyslny|PL", "Status: -")
        _teksty.Add("ts.status_domyslny|EN", "Status: -")
        _teksty.Add("ts.status_domyslny|DE", "Status: -")

        _teksty.Add("ts.status_wysylanie|PL", "Status: Wysyłanie TS...")
        _teksty.Add("ts.status_wysylanie|EN", "Status: Sending FT...")
        _teksty.Add("ts.status_wysylanie|DE", "Status: FT wird gesendet...")

        _teksty.Add("ts.status_blad_zakresu|PL", "Status: Podaj prawidłowy numer (0-127)")
        _teksty.Add("ts.status_blad_zakresu|EN", "Status: Enter valid number (0-127)")
        _teksty.Add("ts.status_blad_zakresu|DE", "Status: Gültige Nummer eingeben (0-127)")

        _teksty.Add("ts.status_brak_grup|PL", "Status: Brak prawidłowych numerów grup")
        _teksty.Add("ts.status_brak_grup|EN", "Status: No valid group numbers")
        _teksty.Add("ts.status_brak_grup|DE", "Status: Keine gültigen Gruppennummern")

        _teksty.Add("ts.status_blad_komunikacji|PL", "Status: Błąd komunikacji")
        _teksty.Add("ts.status_blad_komunikacji|EN", "Status: Communication error")
        _teksty.Add("ts.status_blad_komunikacji|DE", "Status: Kommunikationsfehler")

        _teksty.Add("ts.err_ilosc_grup|PL", "Podaj liczbę od 1 do 63.")
        _teksty.Add("ts.err_ilosc_grup|EN", "Enter a number from 1 to 63.")
        _teksty.Add("ts.err_ilosc_grup|DE", "Geben Sie eine Zahl von 1 bis 63 ein.")

        _teksty.Add("ts.tooltip_zakres|PL", "Wartość poza zakresem 0-127!")
        _teksty.Add("ts.tooltip_zakres|EN", "Value out of range 0-127!")
        _teksty.Add("ts.tooltip_zakres|DE", "Wert außerhalb des Bereichs 0-127!")

        ' ── tabTCP – etykiety ─────────────────────────────────
        _teksty.Add("tcp.lbl_nr_grupy|PL", "Wyślij TCP do pojedynczej grupy (0-127):")
        _teksty.Add("tcp.lbl_nr_grupy|EN", "Send DT to a single group (0-127):")
        _teksty.Add("tcp.lbl_nr_grupy|DE", "DT an eine einzelne Gruppe senden (0-127):")

        _teksty.Add("tcp.lbl_wszystkie|PL", "Wyślij TCP do wszystkich grup")
        _teksty.Add("tcp.lbl_wszystkie|EN", "Send DT to all groups")
        _teksty.Add("tcp.lbl_wszystkie|DE", "DT an alle Gruppen senden")

        _teksty.Add("tcp.lbl_ilosc|PL", "Podaj ilość grup do TCP")
        _teksty.Add("tcp.lbl_ilosc|EN", "Enter number of groups for DT")
        _teksty.Add("tcp.lbl_ilosc|DE", "Anzahl der Gruppen für DT eingeben")

        ' ── tabTCP – przyciski ────────────────────────────────
        _teksty.Add("tcp.btn_start|PL", "Wykonaj TCP")
        _teksty.Add("tcp.btn_start|EN", "Run DT")
        _teksty.Add("tcp.btn_start|DE", "DT ausführen")

        _teksty.Add("tcp.btn_stop|PL", "Zatrzymaj TCP")
        _teksty.Add("tcp.btn_stop|EN", "Stop DT")
        _teksty.Add("tcp.btn_stop|DE", "DT stoppen")

        _teksty.Add("tcp.btn_utworz|PL", "Zatwierdź ilość grup do TCP")
        _teksty.Add("tcp.btn_utworz|EN", "Confirm number of DT groups")
        _teksty.Add("tcp.btn_utworz|DE", "Anzahl der DT-Gruppen bestätigen")

        _teksty.Add("tcp.btn_reset|PL", "Resetuj ustawienia")
        _teksty.Add("tcp.btn_reset|EN", "Reset settings")
        _teksty.Add("tcp.btn_reset|DE", "Einstellungen zurücksetzen")

        ' ── tabTCP – historia / status ────────────────────────
        _teksty.Add("tcp.status_domyslny|PL", "Status: -")
        _teksty.Add("tcp.status_domyslny|EN", "Status: -")
        _teksty.Add("tcp.status_domyslny|DE", "Status: -")

        _teksty.Add("tcp.status_wysylanie|PL", "Status: Wysyłanie TCP...")
        _teksty.Add("tcp.status_wysylanie|EN", "Status: Sending DT...")
        _teksty.Add("tcp.status_wysylanie|DE", "Status: DT wird gesendet...")

        _teksty.Add("tcp.status_brak_aktywnych|PL", "Status: Brak aktywnych grup TCP do zatrzymania")
        _teksty.Add("tcp.status_brak_aktywnych|EN", "Status: No active DT groups to stop")
        _teksty.Add("tcp.status_brak_aktywnych|DE", "Status: Keine aktiven DT-Gruppen zum Stoppen")

        _teksty.Add("tcp.status_wszystkie_aktywne|PL", "Status: Wszystkie wybrane grupy mają już aktywny TCP")
        _teksty.Add("tcp.status_wszystkie_aktywne|EN", "Status: All selected groups already have active DT")
        _teksty.Add("tcp.status_wszystkie_aktywne|DE", "Status: Alle ausgewählten Gruppen haben bereits aktives DT")

        _teksty.Add("tcp.status_anulowane|PL", "Status: Wysyłanie anulowane")
        _teksty.Add("tcp.status_anulowane|EN", "Status: Sending cancelled")
        _teksty.Add("tcp.status_anulowane|DE", "Status: Senden abgebrochen")

        _teksty.Add("tcp.status_blad_komunikacji|PL", "Status: Błąd komunikacji")
        _teksty.Add("tcp.status_blad_komunikacji|EN", "Status: Communication error")
        _teksty.Add("tcp.status_blad_komunikacji|DE", "Status: Kommunikationsfehler")

        _teksty.Add("tcp.status_stop_wysylanie|PL", "Status: Wysyłanie STOP...")
        _teksty.Add("tcp.status_stop_wysylanie|EN", "Status: Sending STOP...")
        _teksty.Add("tcp.status_stop_wysylanie|DE", "Status: STOP wird gesendet...")

        _teksty.Add("tcp.blokada_aktywna|PL", "TCP już aktywny - pominięto")
        _teksty.Add("tcp.blokada_aktywna|EN", "DT already active - skipped")
        _teksty.Add("tcp.blokada_aktywna|DE", "DT bereits aktiv - übersprungen")

        _teksty.Add("tcp.anulowany_przez_uzytkownika|PL", "Start TCP anulowany przez użytkownika")
        _teksty.Add("tcp.anulowany_przez_uzytkownika|EN", "DT Start cancelled by user")
        _teksty.Add("tcp.anulowany_przez_uzytkownika|DE", "DT-Start vom Benutzer abgebrochen")

        _teksty.Add("tcp.err_ilosc_grup|PL", "Podaj liczbę od 1 do 63.")
        _teksty.Add("tcp.err_ilosc_grup|EN", "Enter a number from 1 to 63.")
        _teksty.Add("tcp.err_ilosc_grup|DE", "Geben Sie eine Zahl von 1 bis 63 ein.")

        _teksty.Add("tcp.tooltip_zakres|PL", "Wartość poza zakresem 0-127!")
        _teksty.Add("tcp.tooltip_zakres|EN", "Value out of range 0-127!")
        _teksty.Add("tcp.tooltip_zakres|DE", "Wert außerhalb des Bereichs 0-127!")

        ' ── tabTCP – MessageBox ───────────────────────────────
        _teksty.Add("tcp.msgbox.tytul|PL", "Ostrzeżenie - Ponowny Start TCP")
        _teksty.Add("tcp.msgbox.tytul|EN", "Warning - Repeated DT Start")
        _teksty.Add("tcp.msgbox.tytul|DE", "Warnung - Erneuter DT-Start")

        _teksty.Add("tcp.msgbox.naglowek|PL", "Następujące grupy miały już uruchomiony TCP:")
        _teksty.Add("tcp.msgbox.naglowek|EN", "The following groups already had DT running:")
        _teksty.Add("tcp.msgbox.naglowek|DE", "Folgende Gruppen hatten bereits DT aktiv:")

        _teksty.Add("tcp.msgbox.ostatni_start|PL", "ostatni Start:")
        _teksty.Add("tcp.msgbox.ostatni_start|EN", "last Start:")
        _teksty.Add("tcp.msgbox.ostatni_start|DE", "letzter Start:")

        _teksty.Add("tcp.msgbox.min_temu|PL", "min temu")
        _teksty.Add("tcp.msgbox.min_temu|EN", "min ago")
        _teksty.Add("tcp.msgbox.min_temu|DE", "Min. zuvor")

        _teksty.Add("tcp.msgbox.ostrzezenie|PL", "Ponowne uruchomienie TCP może ustawić tryb odroczenia testu dla grupy!")
        _teksty.Add("tcp.msgbox.ostrzezenie|EN", "Re-running DT may set the postponement mode for the group!")
        _teksty.Add("tcp.msgbox.ostrzezenie|DE", "Erneuter DT kann den Aufschubmodus für die Gruppe setzen!")

        _teksty.Add("tcp.msgbox.pytanie|PL", "Czy na pewno chcesz wysłać Start TCP do tych grup?")
        _teksty.Add("tcp.msgbox.pytanie|EN", "Are you sure you want to send DT Start to these groups?")
        _teksty.Add("tcp.msgbox.pytanie|DE", "Möchten Sie wirklich DT Start an diese Gruppen senden?")

        ' ── Tray ──────────────────────────────────────────────
        _teksty.Add("tray.otworz|PL", "Otwórz")
        _teksty.Add("tray.otworz|EN", "Open")
        _teksty.Add("tray.otworz|DE", "Öffnen")

        _teksty.Add("tray.zamknij|PL", "Zamknij")
        _teksty.Add("tray.zamknij|EN", "Exit")
        _teksty.Add("tray.zamknij|DE", "Beenden")

        ' ── tabMigaj – etykiety ───────────────────────────────
        _teksty.Add("migaj.lbl_nr_grupy|PL", "Wyślij migaj LED do pojedynczej grupy (0-127):")
        _teksty.Add("migaj.lbl_nr_grupy|EN", "Send LED blink to a single group (0-127):")
        _teksty.Add("migaj.lbl_nr_grupy|DE", "LED-Blinken an eine einzelne Gruppe senden (0-127):")

        ' POPRAWIONO: "(adres fizyczny)" zamiast "(1-15000000)"
        _teksty.Add("migaj.lbl_nr_oprawy|PL", "Wyślij migaj LED do pojedynczej oprawy (adres fizyczny):")
        _teksty.Add("migaj.lbl_nr_oprawy|EN", "Send LED blink to a single luminaire (physical address):")
        _teksty.Add("migaj.lbl_nr_oprawy|DE", "LED-Blinken an eine einzelne Leuchte senden (physische Adresse):")

        ' ── tabMigaj – przyciski ──────────────────────────────
        _teksty.Add("migaj.btn_start|PL", "Wykonaj migaj LED")
        _teksty.Add("migaj.btn_start|EN", "Run LED blink")
        _teksty.Add("migaj.btn_start|DE", "LED-Blinken starten")

        _teksty.Add("migaj.btn_stop|PL", "Zatrzymaj migaj LED")
        _teksty.Add("migaj.btn_stop|EN", "Stop LED blink")
        _teksty.Add("migaj.btn_stop|DE", "LED-Blinken stoppen")

        ' ── tabMigaj – ostrzeżenie uprawnień ──────────────────
        _teksty.Add("migaj.wymaga_uprawnien_tytul|PL", "Wymagane uprawnienia")
        _teksty.Add("migaj.wymaga_uprawnien_tytul|EN", "Permissions required")
        _teksty.Add("migaj.wymaga_uprawnien_tytul|DE", "Berechtigung erforderlich")

        _teksty.Add("migaj.wymaga_uprawnien|PL", "Funkcja wymaga wyższych uprawnień." & vbCrLf & "Zaloguj się jako ADMIN lub SERWIS.")
        _teksty.Add("migaj.wymaga_uprawnien|EN", "This function requires higher permissions." & vbCrLf & "Please log in as ADMIN or SERWIS.")
        _teksty.Add("migaj.wymaga_uprawnien|DE", "Diese Funktion erfordert höhere Berechtigungen." & vbCrLf & "Bitte als ADMIN oder SERWIS anmelden.")

        ' ── tabMigaj – status ─────────────────────────────────
        _teksty.Add("migaj.status_wysylanie|PL", "Status: Wysyłanie migaj LED...")
        _teksty.Add("migaj.status_wysylanie|EN", "Status: Sending LED blink...")
        _teksty.Add("migaj.status_wysylanie|DE", "Status: LED-Blinken wird gesendet...")

        _teksty.Add("migaj.status_stop_wysylanie|PL", "Status: Wysyłanie STOP migaj LED...")
        _teksty.Add("migaj.status_stop_wysylanie|EN", "Status: Sending STOP LED blink...")
        _teksty.Add("migaj.status_stop_wysylanie|DE", "Status: STOP LED-Blinken wird gesendet...")

        _teksty.Add("migaj.status_blad_zakresu_grupy|PL", "Status: Podaj prawidłowy numer grupy (0-127)")
        _teksty.Add("migaj.status_blad_zakresu_grupy|EN", "Status: Enter valid group number (0-127)")
        _teksty.Add("migaj.status_blad_zakresu_grupy|DE", "Status: Gültige Gruppennummer eingeben (0-127)")

        _teksty.Add("migaj.status_blad_zakresu_oprawy|PL", "Status: Podaj prawidłowy numer oprawy (adres fizyczny)")
        _teksty.Add("migaj.status_blad_zakresu_oprawy|EN", "Status: Enter valid luminaire number (physical address)")
        _teksty.Add("migaj.status_blad_zakresu_oprawy|DE", "Status: Gültige Leuchten-Nummer eingeben (physische Adresse)")

        _teksty.Add("migaj.status_brak_danych|PL", "Status: Podaj numer grupy lub oprawy")
        _teksty.Add("migaj.status_brak_danych|EN", "Status: Enter group or luminaire number")
        _teksty.Add("migaj.status_brak_danych|DE", "Status: Gruppen- oder Leuchten-Nummer eingeben")

        _teksty.Add("migaj.status_blad_komunikacji|PL", "Status: Błąd komunikacji")
        _teksty.Add("migaj.status_blad_komunikacji|EN", "Status: Communication error")
        _teksty.Add("migaj.status_blad_komunikacji|DE", "Status: Kommunikationsfehler")

        _teksty.Add("migaj.tooltip_zakres_grupy|PL", "Wartość poza zakresem 0-127!")
        _teksty.Add("migaj.tooltip_zakres_grupy|EN", "Value out of range 0-127!")
        _teksty.Add("migaj.tooltip_zakres_grupy|DE", "Wert außerhalb des Bereichs 0-127!")

        _teksty.Add("migaj.tooltip_zakres_oprawy|PL", "Nieprawidłowy adres fizyczny!")
        _teksty.Add("migaj.tooltip_zakres_oprawy|EN", "Invalid physical address!")
        _teksty.Add("migaj.tooltip_zakres_oprawy|DE", "Ungültige physische Adresse!")

        ' ── Reset centralki ───────────────────────────────────
        _teksty.Add("reset.btn|PL", "Reset centralki")
        _teksty.Add("reset.btn|EN", "Controller reset")
        _teksty.Add("reset.btn|DE", "Zentrale zurücksetzen")

        _teksty.Add("reset.czekaj|PL", "Czekaj, trwa reset centralki...")
        _teksty.Add("reset.czekaj|EN", "Please wait, controller is resetting...")
        _teksty.Add("reset.czekaj|DE", "Bitte warten, Zentrale wird zurückgesetzt...")

        _teksty.Add("reset.tytul|PL", "Reset centralki")
        _teksty.Add("reset.tytul|EN", "Controller reset")
        _teksty.Add("reset.tytul|DE", "Zentrale zurücksetzen")


        ' ── tabStanOpraw – kolumny ────────────────────────────────────
        _teksty.Add("op.col.adl|PL", "Adres Logiczny")
        _teksty.Add("op.col.adl|EN", "Logical Address")
        _teksty.Add("op.col.adl|DE", "Log. Adresse")

        _teksty.Add("op.col.adf|PL", "Adres Fizyczny")
        _teksty.Add("op.col.adf|EN", "Physical Address")
        _teksty.Add("op.col.adf|DE", "Phys. Adresse")

        _teksty.Add("op.col.gr|PL", "Grupa")
        _teksty.Add("op.col.gr|EN", "Group")
        _teksty.Add("op.col.gr|DE", "Gruppe")

        _teksty.Add("op.col.opi|PL", "Lokalizacja")
        _teksty.Add("op.col.opi|EN", "Location")
        _teksty.Add("op.col.opi|DE", "Standort")

        _teksty.Add("op.col.pn|PL", "Świeci w TPN")
        _teksty.Add("op.col.pn|EN", "On in NM")
        _teksty.Add("op.col.pn|DE", "An im NB")

        _teksty.Add("op.col.tnu|PL", "Aktywny TPN")
        _teksty.Add("op.col.tnu|EN", "NM Active")
        _teksty.Add("op.col.tnu|DE", "NB Aktiv")

        _teksty.Add("op.col.monit|PL", "Monitorowana")
        _teksty.Add("op.col.monit|EN", "Monitored")
        _teksty.Add("op.col.monit|DE", "Überwacht")

        _teksty.Add("op.col.stan|PL", "Stan")
        _teksty.Add("op.col.stan|EN", "Status")
        _teksty.Add("op.col.stan|DE", "Zustand")

        _teksty.Add("op.col.dsta|PL", "Czas statusu")
        _teksty.Add("op.col.dsta|EN", "Status time")
        _teksty.Add("op.col.dsta|DE", "Statuszeit")

        ' ── tabStanOpraw – stany ──────────────────────────────────────
        _teksty.Add("op.stan.sprawna|PL", "Sprawna")
        _teksty.Add("op.stan.sprawna|EN", "Operational")
        _teksty.Add("op.stan.sprawna|DE", "Betriebsbereit")

        _teksty.Add("op.stan.brak_kom|PL", "Brak komunikacji")
        _teksty.Add("op.stan.brak_kom|EN", "No communication")
        _teksty.Add("op.stan.brak_kom|DE", "Keine Kommunikation")

        _teksty.Add("op.stan.spoczynek|PL", "Tryb spoczynkowy")
        _teksty.Add("op.stan.spoczynek|EN", "Standby mode")
        _teksty.Add("op.stan.spoczynek|DE", "Ruhemodus")

        _teksty.Add("op.stan.praca_aw|PL", "Praca awaryjna")
        _teksty.Add("op.stan.praca_aw|EN", "Emergency mode")
        _teksty.Add("op.stan.praca_aw|DE", "Notbetrieb")

        _teksty.Add("op.stan.awaria_zrodla|PL", "Awaria źródła światła")
        _teksty.Add("op.stan.awaria_zrodla|EN", "Light source failure")
        _teksty.Add("op.stan.awaria_zrodla|DE", "Leuchtmittelstörung")

        _teksty.Add("op.stan.brak_akum|PL", "Brak akumulatora")
        _teksty.Add("op.stan.brak_akum|EN", "Battery missing")
        _teksty.Add("op.stan.brak_akum|DE", "Akku fehlt")

        _teksty.Add("op.stan.slaby_akum|PL", "Słaby akumulator")
        _teksty.Add("op.stan.slaby_akum|EN", "Weak battery")
        _teksty.Add("op.stan.slaby_akum|DE", "Schwacher Akku")

        _teksty.Add("op.stan.awaria_klad|PL", "Awaria ładowania")
        _teksty.Add("op.stan.awaria_klad|EN", "Charging failure")
        _teksty.Add("op.stan.awaria_klad|DE", "Ladestörung")

        _teksty.Add("op.stan.blokada|PL", "Oprawa zablokowana")
        _teksty.Add("op.stan.blokada|EN", "Luminaire locked")
        _teksty.Add("op.stan.blokada|DE", "Leuchte gesperrt")

        _teksty.Add("op.stan.test_ts|PL", "Trwa TS")
        _teksty.Add("op.stan.test_ts|EN", "FT in progress")
        _teksty.Add("op.stan.test_ts|DE", "FT läuft")

        _teksty.Add("op.stan.test_tcp|PL", "Trwa TCP")
        _teksty.Add("op.stan.test_tcp|EN", "DT in progress")
        _teksty.Add("op.stan.test_tcp|DE", "DT läuft")

        _teksty.Add("op.stan.odrocz_ts|PL", "Odroczenie TS")
        _teksty.Add("op.stan.odrocz_ts|EN", "FT postponed")
        _teksty.Add("op.stan.odrocz_ts|DE", "FT verschoben")

        _teksty.Add("op.stan.odrocz_tcp|PL", "Odroczenie TCP")
        _teksty.Add("op.stan.odrocz_tcp|EN", "DT postponed")
        _teksty.Add("op.stan.odrocz_tcp|DE", "DT verschoben")

        ' ── tabStanOpraw – UI ─────────────────────────────────────────
        _teksty.Add("op.btn_odswież|PL", "Odśwież")
        _teksty.Add("op.btn_odswież|EN", "Refresh")
        _teksty.Add("op.btn_odswież|DE", "Aktualisieren")

        _teksty.Add("op.lbl_licznik|PL", "Oprawy:")
        _teksty.Add("op.lbl_licznik|EN", "Luminaires:")
        _teksty.Add("op.lbl_licznik|DE", "Leuchten:")

        _teksty.Add("op.lbl_ostatnie|PL", "Ostatnie odświeżenie:")
        _teksty.Add("op.lbl_ostatnie|EN", "Last refresh:")
        _teksty.Add("op.lbl_ostatnie|DE", "Letzte Aktualisierung:")


    End Sub

    ' ═══════════════════════════════════════════════════════════════
    ' FUNKCJA T() – pobiera tłumaczenie
    ' ═══════════════════════════════════════════════════════════════
    Public Function T(klucz As String) As String
        Dim kompozytowy As String = klucz & "|" & CurrentJezyk.ToString()
        Dim wynik As String = Nothing
        If _teksty.TryGetValue(kompozytowy, wynik) Then
            Return wynik
        End If
        Debug.WriteLine("Brak klucza: " & kompozytowy)
        Return "[" & klucz & "]"
    End Function

End Module
