# efcore2gettingstarted

## EF Core 2.0 - Getting Started (Pluralsight)

### Creating a Data Model and Database with EF Core

Note: Run powershell commands where DbContext lives (`Samurai.Data`)

#### Add Migration  
`Add-Migration initial`

#### Script Migration - Used for Renee
`script-migration`

#### Add Relationship (add schema update migration)
`add-migration relationships`

#### Update-Database (update database w/any changes since last snapshot - creates db if not exists)
`update-database`

#### Database-first script (sreate entities from existing db)
`scaffold-dbcontext  -provider Microsoft.EntityFrameworkCore.SqlServer -connection "ConStr" ` `

##### Helpful Poweshell script EF commands

`get-help entityframeworkcore`

## Interacting with your EF Core Data Model

Note: Run powershell commands where DbContext lives (`Samurai.Data`)

#### Add Logging to see the SQL EF is generating
Nugetget pkg: Microsoft.Extensions.Logging.Console

```
optionsBuilder
     .UseLoggerFactory(MyConsoleLoggerFactory) //set logging factory
     .EnableSensitiveDataLogging(true) //view parameter values in the console logs
```

##### Helpful: Known Nuget Package Installs
```
 - Microsoft.EntityFrameworkCore.SqlServer v2.0.1
 - Microsoft.EntityFrameworkCore.Tools v2.0.1 
 - Microsoft.EntityFrameworkCore.Design v2.0.1
 - Microsoft.Extensions.Logging.Console v2.0.0
 ```

