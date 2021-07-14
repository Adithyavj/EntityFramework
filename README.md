# Entity Framework Core Project

## What is Entity Framework Core?
Entity Framework Core is the new version of Entity Framework after EF 6.x
### Entity Framework - 
- Entity Framework is an Object/Relational Mapping (O/RM) framework. 
- It is an enhancement to ADO.NET that gives developers an automated mechanism for accessing & storing the data in the database.
- EF Core is intended to be used with .NET Core applications. However, it can also be used with standard .NET 4.5+ framework based applications.

## EF Core Development Approaches
EF Core supports two development approaches 
1) Code-First 
2) Database-First.
EF Core mainly targets the code-first approach and provides little support for the database-first approach because the visual designer or wizard for DB model is not supported as of EF Core 2.0.

### Code-First Approach
In the code-first approach, EF Core API creates the database and tables using migration based on the conventions and configuration provided in your domain classes. 
This approach is useful in Domain Driven Design (DDD).

### Database-First Approach
In the database-first approach, EF Core API creates the domain and context classes based on your existing database using EF Core commands. 
This has limited support in EF Core as it does not support visual designer or wizard
Creating entity & context classes for an existing database is called Database-First approach.

## EF Core Supports the following features:
- DbContext & DbSet
- Data Model
- Querying using Linq-to-Entities
- Change Tracking
- SaveChanges
- Migrations

## Installation
It is available as a NuGet package. You need to install NuGet packages for the following two things to use EF Core in your application:

1. EF Core DB provider
Install-Package Microsoft.EntityFrameworkCore.SqlServer
2. EF Core tools
Along with the DB provider package, you also need to install EF tools to execute EF Core commands. 
These make it easier to perform several EF Core-related tasks in your project at design time, such as migrations, scaffolding, etc.
Microsoft.EntityFrameworkCore.Tools.DotNet
<DotNetCliToolReference Include="Microsoft.EntityFrameworkCore.Tools.DotNet" Version="2.0.0" />

## Scaffold-DbContext Command
Use Scaffold-DbContext to create a model based on your existing database. The following parameters can be specified with Scaffold-DbContext in Package Manager Console:
`
Scaffold-DbContext [-Connection] [-Provider] [-OutputDir] [-Context] [-Schemas>] [-Tables>] 
                    [-DataAnnotations] [-Force] [-Project] [-StartupProject] [<CommonParameters>]`
`PM> Scaffold-DbContext "Server=.\SQLExpress;Database=SchoolDB;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models`
EF Core creates entity classes only for tables and not for StoredProcedures or Views.

DotNetCli : `dotnet ef dbcontext scaffold "Server=.\SQLEXPRESS;Database=SchoolDB;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -o Models`
