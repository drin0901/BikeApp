# CRUD Application Using .Net Development
**Version: 1.0**
## About the App

The application can create, read, update and delete bike records. 

It was developed using ASP.NET C# MVC with Entity Framework and Web API. Tt is also secured and applied Authentication and Authorization.

The application has the following Roles:

ADMIN
- can create,read,update and delete bike informations.
- can create new role.
- can create new user.

STAFF
- can create read and update bike informations.

### Technologies used

- [ASP.NET (AspNetCore)](https://dotnet.microsoft.com/apps/aspnet) (v5.0)
- [Microsoft Entity Framework] (v5.0)
- [SQL Server] (v15.0)


### Rest API Tool for UI

- [Swagger](https://swagger.io/tools/swaggerhub/?)

### Platforms Used

- [Microsoft Visual Studio] (2019)
- [Microsoft SQL Server Management] (2019)

### Other Tools

- [ASP.NET Core Identity] (v5.0)
- [ASP.NET Core Web API Client] (v5.2)

### Steps to run the application

- Restore Database using the .bak files attached on this zip file.
- Modify SQL Server connection string in the appsettings.json for both Web and Web API Projects. 
  It will be based on your local connection string. On my end, its "(LocalDb)\\MyLocalDB".
  You can just replace it for the entire solution for your convenience.
- Open the project using Visual Studio 2019
- Make sure the startup project is set to Multiple Projects such as `Web` and `WebAPI`
- Run the project 
- I've created 2 existing account on the database. You can login with the email and password below:

- Email: mansion88@ymail.com
  Password: M@nsion88
  Role: Admin

- Email: drin0901@yahoo.com
  Password: @Aldrin22
  Role: Staff

- You can also create a new user using the Admin role account.