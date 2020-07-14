# NetCore-WebAPI-V2
Simple API Developed by ASP.Net Core \b
Connect to existing database
``` 
dotnet ef dbcontext scaffold "Server=KBT-DEV-04; Database=Value; Trusted_Connection=true;" Microsoft.EntityFrameworkCore.SqlServer -o Models -c DataContext -f
```
- Http method GET, POST, PUT, DELETE
- Entity Framework
- DataContext
- Use SQL Server as Database
- LINQ
- Swagger
- Enabled Cross-Origin Requests (CORS)
