# Git Commands per Pubblicare CHO Calc v4.0 su GitHub

## Inizializzazione Repository Locale

```bash
# Inizializza repository Git
git init

# Aggiungi tutti i file al tracking
git add .

# Primo commit con versione v4.0
git commit -m "Initial commit: CHO Calc v4.0 - App Android bilingue per calcolo carboidrati

- Supporto completo Italiano/Inglese con cambio lingua dinamico
- Bandiere cliccabili per switch IT ? EN istantaneo  
- Icona spiga di grano personalizzata e design elegante
- Validazione input real-time (solo numeri, max 100)
- Calcolo istantaneo: (Carboidrati × Peso) ÷ 100
- Risultati senza decimali per semplicità
- Firma autore: Matteo Gabriele
- Target: .NET 9 Android API 21+
- APK firmato pronto per distribuzione"
```

## Collegamento a GitHub

```bash
# Aggiungi remote repository (sostituisci USERNAME con il tuo username GitHub)
git remote add origin https://github.com/USERNAME/cho-calc.git

# Oppure con SSH (se configurato)
git remote add origin git@github.com:USERNAME/cho-calc.git

# Push del codice su GitHub
git push -u origin main
```

## Tagging della Release v4.0

```bash
# Crea tag per la versione v4.0.0
git tag -a v4.0.0 -m "CHO Calc v4.0.0 - Bilingual Android App

Features:
? Complete Italian/English bilingual support
? Dynamic language switching with flags
? Real-time carbohydrate calculator  
? Input validation (max 100g)
? Elegant UI with wheat grain icon
? Author signature: Matteo Gabriele
? .NET 9 Android targeting API 21+
? 7.1MB signed APK ready for distribution"

# Push del tag su GitHub
git push origin v4.0.0
```

## Comandi Utili

```bash
# Verifica stato repository
git status

# Verifica remote configurati
git remote -v

# Verifica tutti i tag
git tag -l

# Mostra informazioni tag
git show v4.0.0

# Crea nuovo branch per sviluppo futuro
git checkout -b develop

# Ritorna al main
git checkout main
```

## Struttura Repository GitHub Finale

```
cho-calc/
??? ?? README.md                         # Documentazione bilingue completa
??? ?? LICENSE                           # Licenza MIT
??? ?? RELEASES.md                       # Note di rilascio v1.0-v4.0
??? ?? PROGETTO_COMPLETATO.md           # Riepilogo finale progetto
??? ?? .gitignore                        # Git ignore rules (.NET Android)
??? ?? MainActivity.cs                   # Logica app + cambio lingua
??? ?? AndroidManifest.xml               # Configurazione Android
??? ?? calcolatore carboidrati.csproj    # Progetto .NET 9
??? ?? Resources/                        # Risorse Android
    ??? ?? layout/
    ?   ??? activity_main.xml            # Layout con bandiere
    ??? ?? values/
    ?   ??? strings.xml                  # Stringhe bilingui
    ?   ??? colors.xml                   # Palette colori
    ?   ??? styles.xml                   # Stili UI
    ?   ??? dimens.xml                   # Dimensioni
    ??? ?? drawable/
    ?   ??? wheat_icon.xml               # ?? Icona spiga
    ?   ??? flag_italy.xml               # ???? Bandiera italiana
    ?   ??? flag_uk.xml                  # ???? Bandiera inglese
    ?   ??? rounded_edittext.xml         # Input normale
    ?   ??? rounded_edittext_error.xml   # Input errore
    ?   ??? result_background.xml        # Sfondo risultato
    ??? ?? mipmap-anydpi-v26/
        ??? appicon.xml                  # Icona app
        ??? appicon_round.xml            # Icona rotonda
```

## GitHub Actions (Opzionale)

Crea `.github/workflows/build.yml` per build automatico:

```yaml
name: Build CHO Calc APK

on:
  push:
    branches: [ main, develop ]
    tags: [ 'v*' ]
  pull_request:
    branches: [ main ]

jobs:
  build:
    runs-on: ubuntu-latest
    
    steps:
    - name: Checkout code
      uses: actions/checkout@v4
    
    - name: Setup .NET 9
      uses: actions/setup-dotnet@v4
      with:
        dotnet-version: 9.0.x
        
    - name: Setup Android SDK
      uses: android-actions/setup-android@v3
    
    - name: Restore dependencies
      run: dotnet restore
      
    - name: Build APK
      run: dotnet publish -f net9.0-android -c Release
      
    - name: Upload APK Artifact
      uses: actions/upload-artifact@v4
      with:
        name: CHO-Calc-v4.0-APK
        path: bin/Release/net9.0-android/*.apk
        
    - name: Create Release (on tag)
      if: startsWith(github.ref, 'refs/tags/v')
      uses: softprops/action-gh-release@v1
      with:
        files: bin/Release/net9.0-android/com.chocalc.app-Signed.apk
        body: |
          # CHO Calc ${{ github.ref_name }}
          
          ?? **Calcolatore di Carboidrati Bilingue**
          
          ## ? Features
          - ???????? Supporto bilingue Italiano/Inglese
          - ?? Cambio lingua dinamico con bandiere
          - ?? Calcolo carboidrati in tempo reale
          - ? Validazione input intelligente
          - ?? Design elegante e responsive
          
          ## ?? Installation
          Scarica l'APK allegato e installa su Android
          
          **Creato da Matteo Gabriele**
      env:
        GITHUB_TOKEN: ${{ secrets.GITHUB_TOKEN }}
```

## ?? Prossimi Passi

### 1. Crea Repository su GitHub
1. Vai su https://github.com
2. Click "New repository" 
3. Nome: `cho-calc`
4. Descrizione: "?? CHO Calc - Calcolatore di carboidrati bilingue per Android (.NET 9)"
5. Pubblico ?
6. Non aggiungere README (ne abbiamo già uno)
7. Click "Create repository"

### 2. Esegui i Comandi Git
Copia e incolla i comandi sopra nel terminale nella directory del progetto.

### 3. Configura Release
Dopo il push, vai su GitHub ? Releases ? Create new release ? Allega APK

### 4. Opzionale: Configura GitHub Actions
Crea la cartella `.github/workflows/` e aggiungi il file `build.yml`

---

**CHO Calc v4.0** è pronto per GitHub! ????