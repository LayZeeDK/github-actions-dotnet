# Generate workspace

```powershell
# Generate .gitignore with .NET settings
dotnet new gitignore
# Generate Visual Studio solution configuration
dotnet new sln
# Rename solution configuration
mv github-actions-dotnet.sln Lars.sln
```

## Generate web API project

```powershell
# Create project folder
mkdir Lars.WeatherApi
# Generate ASP.NET Core Web API project
dotnet new webapi --output Lars.WeatherApi
# Add project to solution
dotnet sln github-actions-dotnet.sln add .\Lars.WeatherApi\Lars.WeatherApi.csproj
```

## Generate testing project

```powershell
# Create project folder
mkdir Lars.WeatherApi.Tests
# Generate ASP.NET Core Web API project
dotnet new xunit --output Lars.WeatherApi.Tests
# Add project to solution
dotnet sln github-actions-dotnet.sln add .\Lars.WeatherApi.Tests\Lars.WeatherApi.Tests.csproj
```

## Add project reference

```powershell
# Add reference from testing project to web API project
dotnet add Lars.WeatherApi.Test/Lars.WeatherApi.Tests.csproj reference Lars.WeatherApi/Lars.WeatherApi.csproj
```

## Generate GitHub Actions CI workflow

```powershell
# Install GitHub Actions .NET template
dotnet new -i TimHeuer.GitHubActions.Templates
# Generate GitHub Actions CI workflow
dotnet new workflow
```
