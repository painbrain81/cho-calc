# CHO Calc - Calcolatore di Carboidrati

Un'app Android elegante e funzionale per calcolare i carboidrati nei cibi, sviluppata in .NET 9.

**Creato da Matteo Gabriele**

## Descrizione

CHO Calc è un'applicazione bilingue (Italiano/Inglese) semplice e intuitiva che permette di calcolare rapidamente la quantità di carboidrati contenuti in una porzione di cibo, basandosi sui valori nutrizionali per 100 grammi.

## Caratteristiche

- **Design Elegante**: Interfaccia moderna con icona personalizzata della spiga di grano
- **Calcolo in Tempo Reale**: I risultati si aggiornano automaticamente durante la digitazione
- **Bilingue**: Supporto completo per Italiano e Inglese con cambio lingua tramite bandiera
- **Validazione Intelligente**: 
  - Solo input numerici consentiti
  - Controllo valore massimo (100g per 100g)
  - Feedback visuale per errori
- **UI Professionale**: 
  - Colori coordinati (verde e oro)
  - Layout responsive e centrato
  - Angoli arrotondati e ombre
- **Risultati Chiari**: Visualizzazione senza decimali per maggiore semplicità

## Funzionalità

### Calcolo Carboidrati
- **Formula**: `(Carboidrati per 100g × Peso in grammi) ÷ 100`
- **Input**: 
  - Carboidrati da tabella nutrizionale (max 100g)
  - Peso dell'alimento in grammi
- **Output**: Quantità totale di carboidrati (CHO)

### Supporto Multilingue
- **???? Italiano**: "Calcolatore CHO"
- **???? Inglese**: "CHO Calculator"
- **Cambio Lingua**: Click sulla bandiera in alto a destra
- **Traduzioni Complete**: Tutti i testi e messaggi di errore

### Validazione
- ? Valori fino a 100 per i carboidrati
- ? Evidenziazione in rosso per valori > 100
- ? Messaggio "valore non corretto" / "incorrect value" per input non validi

## Tecnologie

- **Framework**: .NET 9
- **Platform**: Android (API Level 21+)
- **Language**: C# 13.0
- **UI**: Native Android XML Layouts
- **Architecture**: Activity-based con cambio lingua dinamico

## Struttura Progetto

```
calcolatore-carboidrati/
??? MainActivity.cs                 # Logica principale dell'app con supporto bilingue
??? Resources/
?   ??? layout/
?   ?   ??? activity_main.xml      # Layout dell'interfaccia con bandiere
?   ??? values/
?   ?   ??? strings.xml            # Stringhe bilingui (IT/EN)
?   ?   ??? colors.xml             # Palette colori
?   ?   ??? styles.xml             # Stili personalizzati
?   ?   ??? dimens.xml             # Dimensioni responsive
?   ??? drawable/
?   ?   ??? wheat_icon.xml         # Icona spiga di grano
?   ?   ??? flag_italy.xml         # Bandiera italiana
?   ?   ??? flag_uk.xml            # Bandiera inglese
?   ?   ??? rounded_edittext.xml   # Stile campi input
?   ?   ??? result_background.xml  # Sfondo risultato
?   ??? mipmap-anydpi-v26/
?       ??? appicon.xml            # Icona app adattiva
?       ??? appicon_round.xml      # Icona rotonda
??? AndroidManifest.xml            # Configurazione app
??? calcolatore carboidrati.csproj # File progetto
```

## Build e Installazione

### Prerequisiti
- Visual Studio 2022 o Visual Studio Code
- .NET 9 SDK
- Android SDK (API Level 21+)
- Workload .NET Android

### Comandi Build
```bash
# Ripristino dipendenze
dotnet restore

# Build Debug
dotnet build

# Build Release con APK
dotnet publish -f net9.0-android -c Release
```

### APK Location
L'APK firmato viene generato in:
```
bin/Release/net9.0-android/com.chocalc.app-Signed.apk
```

## Installazione

1. Scarica l'APK dalla cartella `bin/Release/net9.0-android/`
2. Abilita "Origini sconosciute" nelle impostazioni Android
3. Installa l'APK sul dispositivo

## Screenshots

L'app presenta:
- **???? Italiano**: Titolo "Calcolatore CHO" con firma "creato da Matteo Gabriele"
- **???? Inglese**: Titolo "CHO Calculator" con firma "created by Matteo Gabriele"
- Bandiera cliccabile per cambio lingua in alto a destra
- Campo "Carboidrati da tabella nutrizionale" / "Carbohydrates from the nutritional table"
- Campo "Peso" / "Weight" per inserire i grammi
- Risultato in tempo reale con etichetta "CHO"
- Formula di calcolo mostrata in entrambe le lingue

## Contribuire

1. Fork del repository
2. Crea un branch per la tua feature (`git checkout -b feature/nuova-funzionalita`)
3. Commit delle modifiche (`git commit -am 'Aggiunta nuova funzionalità'`)
4. Push al branch (`git push origin feature/nuova-funzionalita`)
5. Crea una Pull Request

## Licenza

Questo progetto è rilasciato sotto licenza MIT. Vedi il file `LICENSE` per i dettagli.

## Versioni

- **v1.0**: Versione iniziale con calcolo base
- **v2.0**: Aggiunta validazione e design migliorato
- **v3.0**: Nuova icona spiga di grano e ottimizzazioni UI
- **v4.0**: Supporto bilingue IT/EN e firma autore

## Contatti

**Autore**: Matteo Gabriele

Per segnalazioni bug o richieste di funzionalità, apri un issue su GitHub.

---

**CHO Calc** - Calcola i tuoi carboidrati con semplicità! ??

*Created by Matteo Gabriele*