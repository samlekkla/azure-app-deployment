# azure-app-deployment
Web application with automated Azure deployment pipeline via GitHub Actions.

Jag skapade en Azure App Service genom att logga in på Azure Portal och valde att skapa en ny resurs. Eftersom jag inte hade ett eget domännamn och eftersom Azure Managed Certificate inkluderade ett basic SSL-certifikat för gratisanvändning, behövde jag inte skapa en App Service Plan. Jag valde istället den gratis versionen av Azure App Service, vilket innebar att jag använde den standard azurewebsites.net-domän som Azure tillhandahåller.

För att aktivera Application Insights, installerade jag Microsoft Application Insights via NuGet Package. Jag injicerade sedan Application Insights i Program.cs och kopierade Instrumentation Key till appsettings.json. Efter att ha pushat upp koden och genomfört deploymenten, fungerade allt som förväntat och telemetri började samlas in.

För säker åtkomst till applikationen använde jag IAM (Identity and Access Management) och ställde in så att endast mitt konto hade Owner-rollen, eftersom jag är den enda som behöver åtkomst till resurserna.

Slutligen deployade jag applikationen via GitHub Actions, vilket gjorde att ändringar i GitHub automatiskt deployades till Azure App Service. Jag verifierade deploymenten genom att besöka applikationens URL.

Med detta upplägg säkerställde jag att applikationen var övervakad via Application Insights, och att åtkomsten var korrekt kontrollerad via IAM, samtidigt som jag körde projektet på Azure App Service i den gratis versionen utan att behöva skapa en App Service Plan.
