<p align="center">
  <img width="200" src="https://i.imgur.com/ee41Wgp.png"/>
</p>

<h1 align="center">Pricely</h1>


<p align="center">
Et prissammenligningsværktøj, der indsamler data fra forskellige virksomheder. Formålet med Pricely er at vise de mest præcise priser – uden reklamer og uden sporing. Pricely holder sig neutral og jordnær uden bindinger til specifikke virksomheder.

</p>


## ToS
**Dette repository er kun beregnet til lærings- og forskningsformål.**  
Ved at anvende dette repository accepterer du at:  
1. Overholde alle gældende lokale, nationale og internationale love.  
2. Undgå handlinger, der krænker andre platformes vilkår, overtræder andres rettigheder eller kan betragtes som ondsindede.  
3. Tage fuldt ansvar for eventuelle konsekvenser, der måtte opstå som følge af forkert brug af koden.

Som udvikler fraskriver jeg mig ethvert ansvar for brug af koden, der ikke følger disse retningslinjer. 

Fra https://www.pricerunner.dk/info/terms:  
> ### Framing, linking osv.  
> Brugen af indhold på andre hjemmesider eller enheder i netværket er forbudt.  
> Framing, spejling, scraping eller data mining af hjemmesiden samt alle handlinger, der efter vores vurdering forhindrer eller besværliggør andres brug af hjemmesiden (eller nogen tilhørende hjemmesider), er ikke tilladt.

### Disclaimer (English)

**This repository is intended for educational and research purposes only.**

By using or cloning this repository, you agree to:

1. Comply with all local, state, and federal laws.
2. Avoid any activities that violate the terms of service of other platforms, infringe upon the rights of others, or could be deemed malicious.
3. Take full responsibility for any consequences resulting from misuse of this code.

The author(s) of this repository do not condone or take responsibility for any use of this code that does not adhere to these guidelines (or any use at all). Misuse of this repository could result in legal action from affected parties.
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

## Skærmbilleder (Eksempler for Frontend delen)
Pricely er ikke færdigudviklet/designet endnu og disse er kun eksempler fra udviklingen indtil videre.
### Eksempel for søgning.
 <img width="500" align="center" src="https://i.imgur.com/FodpZCs.png"/>
 
### Eksempel for produktdetaljer.
  <img width="500" align="center" src="https://i.imgur.com/q6WwbfS.png"/>

## Pricely 1.0 

### Hvad er Pricely?
Pricely er et prissammenligningsværktøj, der indsamler produktdata fra forskellige virksomheder. Formålet er at vise dig de mest præcise priser, uden reklamer og uden sporing. Pricely er fair og holder sig uafhængig af specifikke virksomheder.

### What is Pricely? (English)
A price comparison tool that gathers data from various companies. The purpose of Pricely is to show you the most accurate prices, without ads or tracking. Pricely is fair and independent from specific companies. The rest of the documentation is in Danish, but an English version may be added in the future.

## Hvorfor Pricely?
### Ingen Sporing
Pricely henter produktdata uden trackere, så du kan søge frit uden at blive sporet. Alt data hentes på serveren og videresendes til dig, hvilket betyder ingen tracking fra tjenester som Klarna, Google, Adform, Facebook, TikTok m.fl.

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
