# Introduction

.NET Multi-Tenant example using a single database.

>**NOTE:** The example uses two DB Contexts to prevent a circular reference with the `Http Resolver`. Possible fix to not use multiple contexts is to implement the repository pattern that will abstract the context usage.

# References

- [Nano ASP - Build a Multi-Tenant App With Entity Framework Core & ASP.NET 7 – Free Guide (Part 1)](https://aspnano.com/build-multi-tenant-application-core-asp-net-7/)
- [Article completed code](https://github.com/aspnano/multiTenantApp)

# Docker compose for SQLServer

For this example SQL server was ran in docker using the `docker-compose` file located in the root of this project. For reference see the contents of the compose file below.

```yaml
version: '3.8'

services:
  mssql:
    image: mcr.microsoft.com/mssql/server:2017-latest
    ports:
      - 1433:1433
    environment:
      - ACCEPT_EULA="Y"
      - MSSQL_SA_PASSWORD=MTA_Example
```

Once the docker container is up and running login using `sa` as the username and `MTA_Example` as the password. Create a database called `MTASingle`

# Migration commands

Execute this from the top level solution directory that contains the `.sln` file to add migrations to `AppDbContext`.

##### Add migrations


```bash
dotnet ef migrations add Init --context AppDbContext --project MTA.Data --startup-project MTA.API --output-dir Migrations
```

>**NOTE:** The initial migration is already there that will create the necessary tables with their configuration and seed tenant information for testing.

##### Remove migrations

```bash
dotnet ef migrations remove --context AppDbContext --project MTA.Data --startup-project MTA.API
```

##### Database Update with environment

```bash
dotnet ef database update --project MTA.Data --startup-project MTA.API
```

# Testing

The project runs on the following urls:

- https://localhost:7279
- http://localhost:5245

Remember to set the `tenant` header when calling the available endpoints. Swagger is already configured to require the header but you will need to set it manually when using something else like curl or postman.

### Available Tenants
| Id    | Name              |
| ----- | ----------------- |
| alpha | Alpha Corporation |
| beta  | Beta Pty(Ltd)     |
| gamma | Gamma LLC         |

### Available Endpoints
| Endpoint      | Method | Description            |
| ------------- | ------ | ---------------------- |
| /product      | POST   | Create new product     |
| /product      | GET    | Get all products       |
| /product/{id} | DELETE | Delete product with ID |
| /product/{id} | GET    | Get product with ID    |
