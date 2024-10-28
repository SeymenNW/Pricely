

# Pricely 1.0 - Prissamenlignings værktøj!

<img src="https://i.imgur.com/ee41Wgp.png" alt="Pricely Officiel Logo" width="175" height="175"/>

### Hvad er Pricely?
Et prissammenligningsværktøj der henter data ned fra forskellige virksomheder. Formålet med Pricely er at vise dig de helt rigtige priser. Det vil sige at Pricely er fair. Den holder det jordnært uden at være bundet til bestemte virksomheder.

### What is Pricely? (English)
A price comparison tool that gathers data from various companies. The purpose of Pricely is to show you the most accurate prices, meaning that Pricely is fair. It keeps things fair without being tied to specific companies. The rest of the documentation here will be on danish, but I might make an english version in the future.


### Udviklingen
Pricely er udviklet med .NET 8, Blazor Web App (Auto) og ASP.NET Web API. Formålet har været at skrive det hele i .NET.

# Hvorfor Pricely?
**Ingen Sporing**
Pricely henter produktdata ned fra virksomheder uden alle former for trackere. Det vil sige du kan søge frit og enkelt uden at du bliver tracket. Alt prishentning foregår på serveren og derefter bliver det videresendt til forbrugeren. Så undgår du bla. tracking (sporing) fra: Klarna, Google, Adform, yahoo, Facebook, TikTok og meget mere.

**Ingen betalte Reklamer/Annoncer**
Pricely viser objektive søgeresultater, og platformen påvirkes ikke af betalte annoncer eller reklamer. Vores mål er at sikre, at brugerne modtager uafhængige og gennemsigtige resultater uden præference for specifikke brands eller produkter.

**Open Source**
Pricely er 100% source. Både Backend serveren og frontend serveren. Så hvis Pricely.dk en dag går ned, kan man stadig selv hoste den på sin egen server eller andet. Der medfølger derudover en Docker Compose fil som sørger for at få både Backend serveren og Blazor siden til at køre (Der er dog ikke nogle images. Den bygger direkte ud fra det der ligger i GitHub repoen).




## Road & To-Do-List 
Denne liste er lidt mere udviklingsorienteret en funktionsorienteret. Dette vil dog ændre sig i fremtiden, når jeg har et bedre overblik over tingene. Mit fokus har været på udviklingen, men dokumentation kommer også.

### PriceRunner
- [x] Kunne søge i deres API. 
- [x] Udvikle klasser til deserialisering
- [x] Wrapper klasser til nemt håndtering af de forskellige resultater fra API'en.
- [x]  Kunne hente data fra Produkt Data API'en.
- [ ]  Detaljeret information om de forskellige produkter.
- [ ]  Vise produktlinks til ikke betalende kunder.
- [ ] Vise priser fra PriceRunner uden sporing

### Elgiganten
- [x] Kunne søge i deres API. 
- [x] Hente produktdata ned
- [ ] Fixe fejl med billeder


### Virksomheder der skal tilføjes
Nogle af virksomhederne har desværre ikke en offentlig API. Derfor vil der i fremtiden blive tilføjet Web Scraping til projektet, men dette venter jeg med. Web Scraping er fedt, men det betyder også at backenden vil bruge flere ressourcer og der vil gå længere tid før man får en respons fra den. Derfor vil det blive tilføjet som en 'optional' funktion, hvilket også vil betyde at man vil begrænse hvilke virksomheder man kan vil have med i sin søgning.
- [ ] ProShop integration
- [ ] Power integration
- [ ] Dustion Integration







