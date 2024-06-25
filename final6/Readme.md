# ASP .Net Claim Authorization
Refer [here](https://learn.microsoft.com/en-us/aspnet/core/security/authorization/secure-data?view=aspnetcore-8.0) for details

### Create migrations

Create migrations.

```
dotnet ef migrations add InitialCreate
```

### Set admin password

```
dotnet user-secrets set SeedUserPW <PW>
dotnet user-secrets set Secret <Secret>
```

### Running in different environments

Update [appsettings.json](appsettings.json) for `Production`, [appsettings.Development.json](appsettings.Development.json) for `Development` and [appsettings.Staging.json](appsettings.Staging.json) for `Staging` respectively. The `ASPNETCORE_ENVIRONMENT` is set to the respective environment.

```
dotnet run --environment Development
dotnet run --environment Production
```

### Users

```
manager@contoso.com
admin@contoso.com
```

### Authorization

Happens on model directly and access controls for different users is defined in [Authorization](Authorization)

#### Update migrations ( Not required )

Already done by `dotnet run`
Update it to the database or create database, once for each environment.

```
dotnet ef database update -- --environment Development
```

### Swagger or API's

Navigate to [swagger](https://localhost:7027/swagger) to access the API's. Use correct port if different.

### Reference

Read [MS EF Core](https://learn.microsoft.com/en-us/ef/core/) for more.
