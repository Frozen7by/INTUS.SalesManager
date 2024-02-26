## Getting Started

If you want to run this project on your own machine, you can do so by following these easy steps.


### Installation

1. Create `src\Infrastructure\INTUS.SalesManager.Infrastructure.DataAccess\appsettings.migration.json` and `src\Api\INTUS.SalesManager.Api.Web\appsettings.json` with the same content and connection string to a database
   ```json
    {
        "ConnectionStrings": {
            "DefaultConnection": "Server..."
        }
    }
   ```
2. Update the database
   ```sh
   \src\Infrastructure\INTUS.SalesManager.Infrastructure.DataAccess> dotnet ef database update
   ```
3. Run the project
   ```sh
   \src\Api\INTUS.SalesManager.Api.Web\> dotnet run -lp=https
   ```
