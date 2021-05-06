# Generate workspace

```powershell
# Generate .gitignore with .NET settings
dotnet new gitignore
# Generate Visual Studio solution configuration
dotnet new sln
```

# Generate web API project

```powershell
# Create project folder
mkdir Lars.WeatherApi
# Generate ASP.NET Core Web API project
dotnet new webapi --output Lars.WeatherApi
```

# Generate testing project

```powershell
# Create project folder
mkdir Lars.WeatherApi.Test
# Generate ASP.NET Core Web API project
dotnet new xunit --output Lars.WeatherApi.Test
```

# Add project reference

```powershell
# Add reference from testing project to web API project
dotnet add Lars.WeatherApi.Test/Lars.WeatherApi.Test.csproj reference Lars.WeatherApi/Lars.WeatherApi.csproj
```

# Generate GitHub Actions CI workflow

```powershell
# Install GitHub Actions .NET template
dotnet new -i TimHeuer.GitHubActions.Templates
# Generate GitHub Actions CI workflow
dotnet new workflow
```
