# Regions Web Task
The application consists of the backend API in .NET Core C# with a SQL Server database (that can be created through the migrations using EF Core). 
MediatR is used for the Mediator Pattern implementaion.

All the dependencies (regarding the frontend) should require only *npm install*.

# Note
Unfortunately the connectrion string for the database is hardcoded.
It is in two places in the Infrastructure layer (the DependencyInjection.cs and ContextFactory.cs files).
The best approach is to move it to the appsettings.json and use the Options Pattern
The connection string to be replaced is from my own server: *Server=it2\\sqlServer2017;Database=RegionsWebTask;Integrated Security=SSPI;*

Fluent validation is used to create strongly-typed validation rules
React is used for the frontend with axios used as a libary for the http requests.
Antd is used as the UI library for the application.
