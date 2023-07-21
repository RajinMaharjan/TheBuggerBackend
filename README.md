# TheBuggerBackend
## Go to following link to setup Clean Architecture
https://github.com/RajinMaharjan/Clean-Architecture-ASP.NET-Web-API

## Adding migration and updating database using console 
### Adding Migration
    dotnet ef migrations add "migration message" --project src/Infrastructure --startup-project src/Api -o Persistence/Migrations 
### Updating database
    dotnet ef database update  --project src/Infrastructure --startup-project src/Api 
