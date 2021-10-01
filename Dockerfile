FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["./Directory.build.props", "./"]
COPY ["./Directory.build.targets", "./"]
COPY ["./src/EmployeesService.Core/EmployeesService.Core.csproj", "./EmployeesService.Core/"]
COPY ["./src/EmployeesService.ApplicationServices/EmployeesService.ApplicationServices.csproj", "./EmployeesService.ApplicationServices/"]
COPY ["./src/EmployeesService.DataAccess/EmployeesService.DataAccess.csproj", "./EmployeesService.DataAccess/"]
COPY ["./src/EmployeesService.Migrations/EmployeesService.Migrations.csproj", "./EmployeesService.Migrations/"]
COPY ["./src/EmployeesService.Hosting/EmployeesService.Hosting.csproj", "./EmployeesService.Hosting/"]
RUN dotnet restore "./EmployeesService.Hosting/EmployeesService.Hosting.csproj"

COPY "./Directory.build.props" .
COPY "./Directory.build.targets" .
COPY "./src" .
WORKDIR "/src/EmployeesService.Hosting/."

RUN dotnet build "EmployeesService.Hosting.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EmployeesService.Hosting.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EmployeesService.Hosting.dll"]
