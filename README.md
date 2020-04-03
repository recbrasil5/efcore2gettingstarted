# efcore2gettingstarted

## First Course: Entity Framework Core 2: Getting Started (Pluralsight)

### Creating a Data Model and Database with EF Core

Note: Run powershell commands where DbContext lives (`Samurai.Data`)

### EF Core Help

`get-help entityframeworkcore`

#### Add Migration  
`Add-Migration initial`

#### Script Migration - Used for Renee
`script-migration`

#### Add Relationship (add schema update migration)
add-migration relationships

#### Update-Migration (update database w/any changes since last snapshot - creates db if not exists)
`update-migration`

#### Database-first script (sreate entities from existing db)
`scaffold-dbcontext  -provider Microsoft.EntityFrameworkCore.SqlServer -connection "ConStr" ` `


### Helpful: Known Nuget Package Installs
```

 - Microsoft.EntityFrameworkCore.SqlServer v2.0.1
 - Microsoft.EntityFrameworkCore.Tools v2.0.1 
 - Microsoft.EntityFrameworkCore.Design v2.0.1
 ```

