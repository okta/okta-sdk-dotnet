Pre-requisites to run the SQL data-driven unit tests

1. Install Microsoft SQL Server Compact 4.0 (https://www.microsoft.com/en-us/download/details.aspx?id=17876)
2. Install the SQL Server Compact/SQLite Toolbox (https://visualstudiogallery.msdn.microsoft.com/0e313dfd-be80-4afb-b5e9-6e74d369f7a1)
3. Open app.config and change the values for TenantUrl and ApiKey in the <appSettings> section
4. Open the OktaSDKTests.sdf in Server Explorer==>SQLite Toolbox and edit the rows in the User and Group tables to your liking