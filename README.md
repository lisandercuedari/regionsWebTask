# Regions Web Task
The application consists of the backend API in .NET Core C# with a SQL Server database (that can be created through the migrations using EF Core). 
MediatR is used for the Mediator Pattern implementaion.

Fluent validation is used to create strongly-typed validation rules
React is used for the frontend (with create react app) with axios used as a libary for the http requests.
Antd is used as the UI library for the application.

All the dependencies (regarding the frontend) should require only *npm install*.

**If you have any problem with the CSV Helper's version on your machine you can just install the latest version of it from NuGet**

The frontend has the *Base Url* in the *api* folder in *client.js* (for the axios instance): *baseURL: `https://localhost:44380/`* If you want to run it on another port you can change it there (also on the project properties in the backend)

# Note

The CSV files need to be in a folder named *CSV* inside the bin folder. This was used by me during development and I forgot to change the path after the last push.
Considering the task mentioned to not push anything new after submitting the project I am not changing it.
**Please create a folder named CSV in the bin folder, with the two csv files inside of it (they are read in the ApplicationDbContextSeed.cs)**


Unfortunately the connectrion string for the database is hardcoded.
It is in two places in the Infrastructure layer (the DependencyInjection.cs and ContextFactory.cs files).
The best approach is to move it to the appsettings.json and use the Options Pattern
The connection string to be replaced is from my own server: *Server=it2\\sqlServer2017;Database=RegionsWebTask;Integrated Security=SSPI;*

React libraries may need npm audit or npm fix, but it does not affect the running of the application.

The View for the GET is: https://localhost:44380/ui/regions/employees


