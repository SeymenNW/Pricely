<p align="center">
  <img width="200" src="https://i.imgur.com/ee41Wgp.png"/>
</p>

<h1 align="center">Pricely</h1>


<p align="center">
Et prissammenligningsværktøj, der indsamler data fra forskellige virksomheder. Formålet med Pricely er at vise dig de mest præcise priser – uden reklamer og uden sporing. Pricely holder sig neutral og jordnær uden bindinger til specifikke virksomheder.

 - Pricely API: https://api.pricely.dk (https://api.pricely.dk/swagger/index.html for docs) (Kan bruges af
   alle)
 - Pricely: https://pricely.dk/
 - (Readme/Docs skal opdateres lidt, men det meste kan bruges)

</p>


## Skærmbilleder (Eksempler for Frontend delen)
Pricely er ikke færdigudviklet/designet endnu og disse er kun eksempler fra udviklingen indtil videre.
### Eksempel for søgning.
 <img width="500" align="center" src="https://i.imgur.com/FodpZCs.png"/>
 
### Eksempel for produktdetaljer.
  <img width="500" align="center" src="https://i.imgur.com/q6WwbfS.png"/>


## Indhold

<!-- TOC -->
* [Hvad er Pricely?](#hvad-er-pricely)
* [Pricely 1.0](#pricely-10)
* [Udviklingen](#udviklingen)
* [Hvorfor Pricely?](#hvorfor-pricely)
  * [Ingen Sporing](#ingen-sporing)
  * [Ingen betalte Reklamer/Annoncer](#ingen-betalte-reklamerannoncer)
  * [Open Source](#open-source)
* [Environment Variables](#environment-variables)
  * [PricelyAPI (Backend projektet)](#pricelyapi-backend-projektet)
  * [PricelyWeb (Blazor projektet)](#pricelyweb-blazor-projektet)
* [Road & To-Do-List](#road--to-do-list)
  * [PriceRunner](#pricerunner)
  * [Elgiganten](#elgiganten)
  * [Power](#power)
  * [Virksomheder der skal tilføjes](#virksomheder-der-skal-tilføjes)
  * [Generelle funktioner](#generelle-funktioner)
* [API Rate Limits fra virksomheder](#api-rate-limits-fra-virksomheder)
* [Teknologier](#teknologier)
* [Ressourcer](#ressourcer)
* [Pricely er uafhængig og gratis](#pricely-er-uafhængig-og-gratis)
<!-- TOC -->

## Pricely 1.0 

### Hvad er Pricely?
Pricely er et prissammenligningsværktøj, der indsamler produktdata fra forskellige virksomheder. Formålet er at vise dig de mest præcise priser, uden reklamer og uden sporing. Pricely er fair og holder sig uafhængig af specifikke virksomheder.

Dette er repositoriet for Pricely 1.0 og **ikke** Pricely 0.4.5. Den gamle Pricely (midlertidigt tilgængelig via [**old.pricely.dk**](https://old.pricely.dk/)) er blevet omskrevet 95%. Kun omkring 5% af koden er overført fra Pricely 0.4.5 til Pricely 1.0.

### What is Pricely? (English)
A price comparison tool that gathers data from various companies. The purpose of Pricely is to show you the most accurate prices, without ads or tracking. Pricely is fair and independent from specific companies. The rest of the documentation is in Danish, but an English version may be added in the future.

### Udviklingen
Pricely er udviklet med .NET 8, Blazor Web App (Auto) og ASP.NET Web API. Målet har været at samle alt i .NET. I fremtiden er planen at udvikle en mobilapp i React Native, som fungerer bedre end andre .NET-multiplatformsrammer som .NET MAUI og Avalonia.

## Hvorfor Pricely?
### Ingen Sporing
Pricely henter produktdata uden trackere, så du kan søge frit uden at blive sporet. Alt data hentes på serveren og videresendes til dig, hvilket betyder ingen tracking fra tjenester som Klarna, Google, Adform, Facebook, TikTok m.fl.

### Ingen betalte Reklamer/Annoncer
Pricely præsenterer uafhængige søgeresultater uden indflydelse fra betalte annoncer. Målet er at sikre gennemsigtighed og neutralitet.

### Open Source
Pricely er 100% open source – både backend-serveren og frontend-applikationen. Hvis Pricely.dk lukker, kan du selv hoste det. Der er en Docker Compose-fil, der gør det let at køre både backend og Blazor frontend. Bemærk, at funktionaliteten kan ændre sig, hvis de anvendte API'er ændrer sig.

## Environment Variables 
### PricelyAPI (Backend projektet)
(Optional). Pricely bruger generelt set en Proxy, men man kan også sætte den i Dev environment. (I prod env bruges disse ikke. Der bruges HTTP/HTTPS_PROXY)
|Env  |Value  |
|--|--|
| PROXY__URL |  URL til proxy|
| PROXY__USERNAME |Brugernavn  |
| PROXY__PASSWORD |Adgangskode  |



### PricelyWeb (Blazor projektet)
(Kun i Production)
| Env | Value  |
|--|--|
| BACKEND__URL | (url til backend) |

## Road & To-Do-List 
Denne liste fokuserer på udviklingsopgaver. I fremtiden vil mere funktionalitet blive tilføjet, i takt med at projektet modnes.

### PriceRunner
- [x] Mulighed for at søge i API'et 
- [x] Klasser til deserialisering af API-data
- [x] Wrapper-klasser til nem håndtering af API-resultater
- [x] Hentning af produktdata 
- [ ] Vise detaljerede produktinformationer
- [x] Links til produkter for ikke-betalende virksomheder/kunder hos PriceRunner
- [x] Vise priser uden sporing 
- [x] Vise pris med eller uden fragt
- [x] Fuldtekst søgning i virksomhedsresultater.
- [ ] Håndtering af redirect-links uden om PriceRunner (For at forbedre no tracking oplevelsen)

### Elgiganten
- [x] Mulighed for søgning i API'et
- [ ] Hentning af produktdata
- [ ] Detaljeret information
- [ ] Prøve at få adgang til EAN nummer på produkter

### Power (Pricely 1.0)
- [x] Mulighed for søgning i API'et
- [ ] Hentning af produktdata
- [ ] Visning af billeder

### Virksomheder der skal tilføjes
Nogle virksomheder har ikke offentlige API'er. Webscraping kan blive nødvendigt, men vil blive optional grundet øget ressourceforbrug. 
- [ ] ProShop integration
- [x] Power integration
- [ ] Dustin integration
- [ ] ComputerSalg integration
- [ ] CDON integration
- [ ] Komplett integration
- [ ] DBA integration

### Generelle funktioner
For at sikre en effektiv søgemaskine vil klienten (browseren) modtage en omfattende JSON-struktur, der muliggør sortering klient-side og reducerer antallet af serverkald. 
- [ ] **Ny søgefunktion til alle understøttede virksomheder**
	- [x] PriceRunner integration
	- [ ] Elgiganten integration
- [ ] **Søgefiltrering**
	- [ ] Filtrer efter pris, alfabetisk orden, brand og produktkategori (PriceRunner)

Mere kommer snart.
 
### API Rate Limits fra virksomheder
PriceRunner anvender rate limits på forespørgsler. For at omgå dette bruges en ***Rotating Proxy***, der distribuerer søgninger over forskellige IP-adresser. Dette gør Pricely lidt langsommere, men påvirker ikke selv-hostede instanser.

## Teknologier
**Teknologier**
- [C# (Programmeringssprog)](https://learn.microsoft.com/en-us/dotnet/csharp/tour-of-csharp/overview)
- [Blazor (Frontend)](https://dotnet.microsoft.com/en-us/apps/aspnet/web-apps/blazor)
- [ASP.NET Web API (Backend Server)](https://dotnet.microsoft.com/en-us/apps/aspnet/apis)
- [Git](https://git-scm.com/)

**Libraries**
- [Newtonsoft.Json](https://www.newtonsoft.com/json)
- [Playwright (Webscraping)](https://playwright.dev/dotnet/)

**Software**
- [Visual Studio 2022 (IDE)](https://visualstudio.com/)

## Ressourcer
...

## Pricely er fuldstændig uafhængig og gratis at bruge.
Pricely har ingen relationer til de virksomheder, hvis API’er bruges, inklusiv men ikke begrænset til: Elgiganten, PriceRunner, Power, ProShop, ComputerSalg. Pricely gemmer ikke varemærkebeskyttede billeder eller medieindhold; alt medie hentes direkte fra eksterne sider.

Hvis din virksomhed gerne vil have fjernet jeres ressourcer fra Pricely kan i kontakte mig på seymen@live.dk. Så skal jeg nok sørge for at det bliver fjernet.
