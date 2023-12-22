<!-- Models génération from DB Source -->

dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.Sqlite --version 8.0.0

dotnet ef dbcontext scaffold "Data Source=dbslack.db;" Microsoft.EntityFrameworkCore.Sqlite --output-dir .\Models\
