
---
```markdown
# 🧮 Blazor Calculator

### 📚 Emne 6 – Software Design  
**Student:** Marcos Elijah Carreno Fernandez  
**Semester:** Høst 2025  
**Institusjon:** Gokstad Akademiet  

---

## 🎯 1. Introduksjon
Dette prosjektet er en **komponentbasert kalkulator bygget i Blazor (.NET 9)**.  
Applikasjonen viser hvordan man kombinerer **Dependency Injection (DI)**, **komponentkommunikasjon** og **state-håndtering** i en moderne webapplikasjon.  

Prosjektet demonstrerer god arkitektur, tydelig struktur og et ryddig brukergrensesnitt utviklet etter prinsippene for programvare-design.

---

## 🧱 2. Arkitektur og struktur

### 📂 Prosjektstruktur
```

BlazorCalculator/
│
├── Components/
│   └── Layout/
│       ├── MainLayout.razor
│       └── NavMenu.razor
│
├── Pages/
│   ├── Calculator.razor
│   ├── CalculatorDisplay.razor
│   ├── CalculatorKeypad.razor
│   ├── Counter.razor
│   ├── Weather.razor
│   └── Error.razor
│
├── Services/
│   └── CalculatorService.cs
│
├── wwwroot/


---

## ⚙️ 3. Teknisk oppsett

### 🧩 Teknologier
- **ASP.NET Core 9.0**
- **Blazor Web App (Interactive Server)**
- **C# 12**
- **Dependency Injection (DI)**
- **CSS3 / Flexbox**

### 🧠 Avhengigheter
Prosjektet bruker kun standardbiblioteker fra .NET – ingen tredjeparts-pakker.  

---

## 🔢 4. Funksjonalitet

| Funksjon | Beskrivelse |
|-----------|--------------|
| `0–9` | Registrerer tall |
| `+ – × ÷` | Grunnleggende operasjoner |
| `=` | Utfører valgt operasjon |
| `C` | Tømmer nåværende input |
| `AC` | Tilbakestiller hele kalkulatoren |
| `±` | Endrer fortegn |
| `,` | Legger til desimal |
| `/0` | Viser feilmelding **"Kan ikke dele på 0"** uten å krasje |

---

## 🧩 5. Arkitektur og flyt

### 🔹 Komponenter
- **Calculator.razor** – hovedkomponenten som koordinerer display og keypad  
- **CalculatorDisplay.razor** – viser gjeldende verdi og feilmeldinger  
- **CalculatorKeypad.razor** – håndterer knappetrykk via EventCallbacks  

### 🔹 Service-lag
`CalculatorService.cs` håndterer:
- state for nåværende og tidligere verdier  
- operatorlogikk  
- desimaler, fortegn, null-deling  
- reset og feilhåndtering  

Registrert i `Program.cs`:
```csharp
builder.Services.AddSingleton<CalculatorService>();
````

---

## 💡 6. Beregningsmodus

Prosjektet bruker **umiddelbar modus**,
dvs. operasjoner evalueres fortløpende etter hvert trykk
– ikke som et matematisk uttrykk med operatorprioritet.

---

## 🧪 7. Testing

| Test          | Forventet resultat                 |
| ------------- | ---------------------------------- |
| `5 ÷ 0 =`     | Viser melding “Kan ikke dele på 0” |
| `5 ±`         | Viser `-5`                         |
| `1 , 5 + 1 =` | Resultat: `2,5`                    |
| `AC`          | Nullstiller alt                    |
| `C`           | Nullstiller kun displayet          |

---

## 🎨 8. Design og styling

Tilpasset **app.css** for lys og moderne stil:

* lys bakgrunn
* grønne handlingstaster
* røde feilmeldinger
* responsive grid-knapper

Eksempel:

```css
.calculator-error {
  background: #fee2e2;
  color: #b91c1c;
  padding: 0.4rem 0.6rem;
  border-radius: 0.4rem;
  font-size: 0.85rem;
  margin-bottom: 0.3rem;
}
```

---

## 🚀 9. Kjøring av prosjektet

### Kommandoer

```bash
dotnet build
dotnet run
```

Åpne deretter:
👉 [http://localhost:5233/calculator](http://localhost:5233/calculator)

---

## 🤖 10. Bruk av KI i utviklingsprosessen

Kunstig intelligens ble brukt som **teknisk sparringspartner**,
KI bidro til **planlegging, feilsøking og optimalisering**.

---

### 💼 Rollen til KI

| Rolle                       | Beskrivelse                                                                                                                                            |
| --------------------------- |--------------------------------------------------------------------------------------------------------------------------------------------------------|
| 🧭 **Arkitektveileder**     | Hjalp til å bryte ned oppgaven i faser (Fase 1–4), strukturere prosjektet og velge riktig Blazor-variant (`dotnet new blazor --interactivity Server`). |
| 🧠 **Problemløser**         | Forklarte hvorfor og hvordan `@rendermode InteractiveServer` aktiverer interaktivitet i .NET 9.                                                        |
| ⚙️ **Kodekvalitetssikrer**  | Identifiserte naming-konflikter (`Calculator` vs `CalculatorService`) og foreslo ryddigere event-binding med `@(() => …)`.                             |
| 🎨 **UI-designer**          | Genererte første-utkast til CSS. Jeg tilpasset farger, header-bar og responsivitet mot Blazor-layout.                                                  |
| 🧩 **Feature-assistent**    | Bidro til utvidelser: **AC**, **±**, **,** og feilmelding ved deling på 0 – uten å bryte state-logikken.                                               |
| 🧾 **Dokumentasjonsmentor** | Hjalp med struktur og språk for README, slik at dokumentasjonen fremstår profesjonell.                                                                 |

---

### 📚 Konkrete eksempler

**Eksempel 1 – Routingfeil**

> “Unrecognized child content ‘@page’ inside `<Router>`.”
> KI foreslo å flytte `@page` til `Calculator.razor`.
> → Routing og navigasjon fungerte korrekt.

**Eksempel 2 – Manglende interaktivitet**

> “Knapper vises men gjør ingenting.”
> KI foreslo `@rendermode InteractiveServer`.
> → Full interaktivitet.

**Eksempel 3 – UI-forbedring**

> “CSS-en er for mørk.”
> KI foreslo lysere tema med blå-grønn gradient og myke skygger.
> → Estetisk dashboard-design.

**Eksempel 4 – Feilhåndtering**

> “Hvordan håndtere deling på null uten crash?”
> KI foreslo `LastError = "Kan ikke dele på 0"` i `CalculatorService`.
> → Stabil og brukervennlig feilmelding.

---

### 🧾 Erklæring

Jeg har brukt KI som støtte til strukturering, debugging og estetiske forslag.
Alle løsninger er testet og validert manuelt.

---

## 🧭 11. Refleksjon

Gjennom dette prosjektet lærte jeg hvordan Blazor håndterer state,
hvordan DI skiller logikk fra presentasjon, og hvordan en enkel applikasjon
kan brytes ned i små, gjenbrukbare komponenter.

Jeg opplevde også verdien av KI som utviklingsstøtte: den effektiviserte
feilsøking og forbedret struktur, men krever kritisk vurdering og egen forståelse.

Prosjektet oppfyller alle funksjonelle krav og demonstrerer solid forståelse
for arkitektur, struktur og interaktiv komponent-design i Blazor.

---

### ✅ Status

**✔️ Ferdig utviklet og testet**, Jeg la til en knapp i navbar som leder direkte til kalkulatoren for enklere tilgang.