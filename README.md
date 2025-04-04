
<p align="center"> <img width="200" src="https://i.imgur.com/ee41Wgp.png"/> </p>
<table>
    <tr>
        <td width="99999" align="center">This repository is intended solely for educational and research purposes.  
 <b>
    </tr>
</table>

 <h1 align="center">Pricely 1.2</h1> <p align="center"> Pricely is a price comparison tool that enhances the **Klarna/PriceRunner** experience by making it more user-friendly and privacy-focused. It acts as a wrapper for PriceRunner/Klarna, providing accurate price data without ads or tracking. Unlike traditional platforms, Pricely supports multi-country comparisons, ensuring users can access the best deals across borders. Currently only focused for Denmark.
</p>

 <p align="center"> 
In addition to Klarna/PriceRunner, **Pricely** offers a seamless way to search for products based on a supported store. This functionality mirrors searching directly on the store's website but comes with the added benefits of a tracker-free and ad-free experience.
 </p>


## Screenshots

Pricely is not fully developed/designed yet, and these are only examples from development so far.

### Example Search

<img width="500" align="center" src="https://i.imgur.com/FodpZCs.png"/>

### Example Product Details

<img width="500" align="center" src="https://i.imgur.com/q6WwbfS.png"/>

## Pricely 1.0

### What is Pricely?

Pricely is a price comparison tool that gathers product data from various companies. Its purpose is to show you the most accurate prices, free from ads and tracking. Pricely is fair and independent of specific companies.

### How to search in Pricely.dk?
You will need to input your own API or a public one hosted by someone else. I am not responsible for what data you send to Pricely and I am **not** hosting the PricelyAPI Project found on this repository anywhere on the web. 
![Pricely Tilføj API](https://i.imgur.com/wBTQcU9.png)



## What does it do?

### No Tracking

Pricely retrieves product data without trackers, allowing search freely without being tracked. All data is fetched on the server and passed to the client, meaning no tracking from services like Klarna, Google, Adform, Facebook, TikTok, etc.


## Environment Variables

### PricelyAPI (Backend Project) Environment Variables
*(Optional)* Pricely generally uses a proxy, which can also be set in the Dev environment. (In production, these are not used; HTTP/HTTPS_PROXY is used instead.)

| Env             | Value          |
|-----------------|----------------|
| PROXY__URL      | Proxy URL      |
| PROXY__USERNAME | Username       |
| PROXY__PASSWORD | Password       |

### PricelyWeb (Blazor Project)
*(Production Only)*

| Env            | Value         |
|----------------|---------------|
| BACKEND__URL   | Backend URL   |


## Road & To-Do-List

#### PriceRunner
- [x] Ability to search in the API
- [x] Classes for deserializing API data
- [x] Wrapper classes for easy handling of API results
- [x] Fetch product data
- [ ] Display detailed product information
- [x] Links to products for non-paying companies/customers of PriceRunner
- [x] Show prices without tracking
- [x] Show prices with or without shipping
- [x] Full-text search in company results
- [ ] Handle redirect links bypassing PriceRunner (to improve no-tracking experience)

#### Elgiganten
- [x] Ability to search in the API
- [ ] Fetch product data
- [ ] Detailed information
- [ ] Attempt to access EAN number for products

#### Power (ONLY on Pricely 0.4.5 (old.pricely.dk)
- [x] Ability to search in the API
- [ ] Fetch product data
- [ ] Display images

#### Countries to add
Klarna (PriceRunner) operates in multiple countries, with price comparisons typically limited to retailers within each respective country (market). For example, PriceRunner.de features German stores, while PriceRunner.dk has Danish stores.

However, many retailers often offer international shipping, making price comparisons across countries (Europe) relevant for Danish consumers. Even when a retailer does not provide direct international shipping, third-party services—such as P.O. box forwarding—can facilitate cross-border purchases.
- [ ] German PriceRunner
- [x] UK Klarna 
- [ ] Dustin integration
- [ ] ComputerSalg integration
- [ ] CDON integration
- [ ] Komplett integration
- [ ] DBA integration

#### General Features
To ensure an efficient search engine, the client (browser) will receive a comprehensive JSON structure, enabling client-side sorting and reducing server calls.
- [ ] **New search functionality for all supported companies**
  - [x] PriceRunner integration
  - [ ] Elgiganten integration
- [ ] **Search filtering**
  - [ ] Filter by price, alphabetical order, brand, and product category (PriceRunner)

More coming soon.


To ensure an efficient search engine, the client (browser) will receive a comprehensive JSON structure, allowing for client-side sorting and reducing server calls.

-   **New search functionality for all supported companies**
    -   PriceRunner integration
    -   Elgiganten integration
-   **Search Filtering**
    -   Filter by price, alphabetical order, brand, and product category (PriceRunner)

More to come soon.

### API Rate Limits by Companies
Most companies limit their API usage.
## Technologies

**Technologies**

-   [C# (Programming Language)](https://learn.microsoft.com/en-us/dotnet/csharp/tour-of-csharp/overview)
-   [Blazor (Frontend)](https://dotnet.microsoft.com/en-us/apps/aspnet/web-apps/blazor)
-   [ASP.NET Web API (Backend Server)](https://dotnet.microsoft.com/en-us/apps/aspnet/apis)
-   [Git](https://git-scm.com/)

**Libraries**

-   [Newtonsoft.Json](https://www.newtonsoft.com/json)
-   [Playwright (Web scraping)](https://playwright.dev/dotnet/)

**Software**

-   [Visual Studio 2022 (IDE)](https://visualstudio.com/)

## Terms of Use, Service & Disclaimer.

**This repository is intended solely for educational and research purposes. 
By using this project or its source code, for any purpose and in any shape or form, you grant your **implicit agreement** to all the following statements:


-  Comply with all applicable local, national, and international laws.
-  Avoid actions that violate other platforms' terms, infringe on others' rights, or could be considered malicious.
-  Take full responsibility for any consequences that may arise from misuse of the code.

As the developer, I disclaim any responsibility for the use of this code in any way and those that do not adhere to these guidelines.

