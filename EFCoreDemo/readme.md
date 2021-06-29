# Entity Framework Core Demo

I created this repository to explore the best practices for creating a .NET Core application that uses Entity Framework (EF) Core to interact with a database.

Key things to observe:

* Use of .NET Core's built in dependency injection. ILocalDbContext is injected into ValuesController. ValuesController is able to resolve ILocalDbContext as LocalDbContext because it is bound in the Startup.cs. Transient scope allows us to ensure database connections are quickly opened and closed as needed.
* Use of EF code first migrations.
* Use of an IDesignTimeDbContextFactory implementation, LocalDesignTimeDbContextFactory, in Startup.cs. The EF Core Add-Migrations command is a "design-time" action, and EF Core doesn't know how to use our "runtime" Startup.cs code to create an instance of LocalDbContext. A little bit more detail can be found in LocalDesignTimeDbContextFactory.cs.

### Running EFCoreDemo

#### Assumptions

* You have everything needed to run a .NET Core 2.2 Web API and run `dotnet` commands.
* You have a localhost SQL server setup.

#### Setup

By default this code is setup to look at a localhost server, EFCoreDemo database, efcoredemo schema. Ensure that this database is created. Once the database is created, apply the migrations in the Migrations folder using the `dotnet ef database update` command. Ensure you're in the directory that contains the .csproj file when you run that command. You can read more about `dotnet ef` commands [here](https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli) if that fails for any reason. Then, run `dotnet build` and `dotnet run`, and the service should be running.