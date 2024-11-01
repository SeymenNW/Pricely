

# Pricely 1.0 - Prissamenligningsværktøj uden sporing

<img src="https://i.imgur.com/ee41Wgp.png" alt="Pricely Officiel Logo" width="175" height="175"/>

### Hvad er Pricely?
Et prissammenligningsværktøj der henter data ned fra forskellige virksomheder. Formålet med Pricely er at vise dig de helt rigtige priser. Uden reklamer. Uden sporing. Det vil sige at Pricely er fair. Den holder det jordnært uden at være bundet til bestemte virksomheder.

Dette er repositorien for Pricely 1.0 og **ikke** Pricely 0.4.5. Den gamle Pricely (Som midlertidigt stadig kan tilgås ved  [**old.pricely.dk**](https://old.pricely.dk/)) er blevet skrevet 95% om. Ikke mere end 5% af kode er blevet overført fra Pricely 0.4.5 til Pricely 1.0.

### What is Pricely? (English)
A price comparison tool that gathers data from various companies. The purpose of Pricely is to show you the most accurate prices, meaning that Pricely is fair. It keeps things fair without being tied to specific companies. The rest of the documentation here will be on danish, but I might make an english version in the future.


### Udviklingen
Pricely er udviklet med .NET 8, Blazor Web App (Auto) og ASP.NET Web API. Formålet har været at skrive det hele i .NET. I fremtiden vil der dog blive udviklet en Mobil app skrevet i React Native (hvilket fungerer meget bedre end forskellige .NET Multi-platform frameworks som .NET MAUI og Avalonia).

# Hvorfor Pricely?
#### Ingen Sporing
Pricely henter produktdata ned fra virksomheder uden alle former for trackere. Det vil sige du kan søge frit og enkelt uden at du bliver tracket. Alt prishentning foregår på serveren og derefter bliver det videresendt til forbrugeren. Så undgår du bla. tracking (sporing) fra: Klarna, Google, Adform, yahoo, Facebook, TikTok og meget mere.

#### Ingen betalte Reklamer/Annoncer
Pricely viser objektive søgeresultater, og platformen påvirkes ikke af betalte annoncer eller reklamer. Vores mål er at sikre, at brugerne modtager uafhængige og gennemsigtige resultater uden præference for specifikke brands eller produkter.

#### Open Source
Pricely er 100% source. Både Backend serveren og frontend serveren. Så hvis Pricely.dk en dag går ned, kan man stadig selv hoste den på sin egen server eller andet. Der medfølger derudover en Docker Compose fil som sørger for at få både Backend serveren og Blazor siden til at køre (Der er dog ikke nogle images. Den bygger direkte ud fra det der ligger i GitHub repoen). Der er dog ingen garantier på at Pricely vil fortsætte med at fungere i fremtiden. Hvis der bliver foretaget API ændringer hos virksomhederne skal Pricely 99% nok opdateres før den fungerer igen.

## Environment Variables 
### PricelyAPI (Backend projektet)
Kommer snart.

### PricelyWeb (Blazor projektet)
Kommer snart.






## Road & To-Do-List 
Denne liste er lidt mere udviklingsorienteret en funktionsorienteret. Dette vil dog ændre sig i fremtiden, når jeg har et bedre overblik over tingene. Mit fokus har været på udviklingen, men dokumentation kommer også.

### PriceRunner
- [x] Kunne søge i deres API. 
- [x] Udvikle klasser til deserialisering
- [x] Wrapper klasser til nemt håndtering af de forskellige resultater fra API'en.
- [x]  Kunne hente data fra Produkt Data API'en.
- [x]  Detaljeret information om de forskellige produkter.
- [x]  Vise produktlinks til ikke betalende kunder.
- [x] Vise priser fra PriceRunner uden sporing 
- [ ] Behandling af redirect links som gør det muligt at besøge sider uden at komme igennem PriceRunner først.

### Elgiganten
- [x] Kunne søge i deres API. 
- [x] Hente produktdata ned
- [ ] Fixe fejl med billeder

### Power
- [x] Kunne søge i deres API. 
- [x] Hente produktdata ned
- [x] Loade billeder


### Virksomheder der skal tilføjes
Nogle af virksomhederne har desværre ikke en offentlig API. Derfor vil der i fremtiden blive tilføjet Web Scraping til projektet, men dette venter jeg med. Web Scraping er fedt, men det betyder også at backenden vil bruge flere ressourcer og der vil gå længere tid før man får en respons fra den. Derfor vil det blive tilføjet som en 'optional' funktion, hvilket også vil betyde at man vil begrænse hvilke virksomheder man kan vil have med i sin søgning.
- [ ] ProShop integration
- [x] Power integration
- [ ] Dustin Integration
- [ ] ComputerSalg integration
- [ ] CDON integration

### Generelle 
For at sikre en effektiv søgemaskine er det afgørende at implementere disse grundlæggende funktioner løbende i Pricely. Sorteringsfunktioner og lignende vil blive håndteret klient-side, hvilket betyder, at et API-kald til serveren vil returnere en omfattende JSON. Målet er at indsamle alle relevante data om et produkt på én gang, da det er mere hensigtsmæssigt (for mig) at minimere kommunikation med backend og dermed optimere ydeevnen. 
- [ ] **Ny søgefunktion der understøtter at hente data fra alle understøttede virksomheder med én søgnign.**
	- [x] PriceRunner integration i denne søgning
	- [ ] Elgiganten integration
	- [ ] Øvrige virksomheder (som også lige først skal implementeres individuelt)

- [ ] **Søgefiltrering**
	- [ ] Filtrer ud fra pris
	- [ ] Filtrer ud fra alfabetisk rækkefølge
	- [ ] Filtrer ud fra brand (? måske)
	- [ ] Filtrer ud fra produktkategori (PriceRunner)

Mere kommer snart.
 
### API Rate Limits fra virksomheder
PriceRunner har foreksempel en ratelimiter, der begrænser antallet af requests inden for kort tid. For at omgå denne begrænsning har jeg anvendt en ***Rotating Proxy*** til at spoofe søgninger gennem forskellige IP-adresser. Denne løsning fungerer, men det har desværre gjort Pricely (lidt) langsommere. Hvis man hoster sin egen instans af Pricely, bør dette ikke have nogen stor betydning. Min plan er dog at hoste Pricely på min egen side, og derfor vil jeg fortsat benytte rotating proxies, hvor det er muligt.







