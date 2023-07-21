# TheBuggerBackend
## Go to following link to learn to setup Clean Architecture
https://github.com/RajinMaharjan/Clean-Architecture-ASP.NET-Web-API
## Description
QA Lint is a hiring application based on hiring QA engineers where the QA can start testing in real world by passing two tests.
### Key features:
- Email verification with link
- Reset password verification with link
- Quiz

## Technologies Used
- ASP.NET Core
- My SQL
- MailKit (Uses google mail system for sending mail to verifiy email and reset password)
- Serilog

## Prerequisites
- Microsoft Visual Studio or Visual Studio Code as Code Editor (preferred Microsoft Visual Studio)
- .NET SDK(7.0)
- Entity Framework Core (7.0)
- MySQL Workbench, MySQL Server and MySQL Connector

## Database Setup
- Install MySQL Workbench, MySQL Server and MySQL Connector.
- Create database with server localhost and port 3306.
- For username and password you can use anything. Recommended for personal use : Username = root and Password = root.
- Open database and create database(you can skip this step because the database name you enter will automatically be created during migration).
  
## Mail Setup
- You can use any of your google mail or try creating new google mail.
- Enable two factor authentication in your google account(if not enabled).
- Search for App password in your google account setting, then:
    - Select main in app option
    - Select Windows Computer in device option
![image](https://github.com/QA-Lint/QA_Lint-Backend/assets/132996735/5b103db5-a607-47bc-920b-7834f51572ab)
![image](https://github.com/QA-Lint/QA_Lint-Backend/assets/132996735/e3043fe2-f7a9-4b85-99b8-76f8be27fe9a)
![image](https://github.com/QA-Lint/QA_Lint-Backend/assets/132996735/256e0d11-5877-44b6-bf90-47afb4bdae04)
- Select generate, then new password is generated which you will use in your code for sending mail with. 
 
## Adding migration and updating database using console 
### Adding EF Core tools(This enables us to use migrations)
    dotnet add package Microsoft.EntityFrameworkCore.Tools 
### Adding Migration
    dotnet ef migrations add "migration message" --project src/Infrastructure --startup-project src/Api -o Persistence/Migrations 
### Updating database
    dotnet ef database update  --project src/Infrastructure --startup-project src/Api 

## Run 
### Run with watch(applies code changes to running application)
    dotnet watch run
### Run without watch
    dotnet run 

## Docker Commands to check for deployment
### Building Docker image
    docker build -t qalint .
Where qalint in the name of image you want to build.

### Running Container
    docker run -d -p 8080:80 --name api qalint
Where qalint is the name of the image you already built and api is the name of container you are going to run in.
## Adding migration and updating database using console 
### Adding Migration
    dotnet ef migrations add "migration message" --project src/Infrastructure --startup-project src/Api -o Persistence/Migrations 
### Updating database
    dotnet ef database update  --project src/Infrastructure --startup-project src/Api
