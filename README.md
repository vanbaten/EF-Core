# EF-Core
Getting Started with EF Core


https://learn.microsoft.com/en-us/ef/core/get-started/overview/first-app?tabs=visual-studio


## About Connectionstrings
This application intentionally keeps things simple for clarity. Connection strings **SHOULD NOT** be stored in the code for production applications.

https://learn.microsoft.com/en-us/ef/core/miscellaneous/connection-strings?tabs=dotnet-core-cli


## QA
### 'SQLitePCLRaw.lib.e_sqlite3' severty vulnerability exists in the project.
This is a false positive. The package is used by Microsoft.Data.Sqlite and is not directly referenced in the project. The package is used to provide SQLite support for EF Core.
For the sake of moving on with the 'get-started' tutorial ignore the warning and use the following command to suppress the warning:

The complete PowerShell command at 'Create the database'-section becomes:
```bash
Install-Package Microsoft.EntityFrameworkCore.Tools
Add-Migration InitialCreate -ErrorAction Continue
Update-Database
```