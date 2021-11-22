FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["./Directory.build.props", "./"]
COPY ["./Directory.build.targets", "./"]
COPY ["./src/CSharpCourse.EmployeesService.Domain/CSharpCourse.EmployeesService.Domain.csproj", "./EmployeesService.Domain/"]
COPY ["./src/CSharpCourse.EmployeesService.ApplicationServices/CSharpCourse.EmployeesService.ApplicationServices.csproj", "./EmployeesService.ApplicationServices/"]
COPY ["./src/CSharpCourse.EmployeesService.DataAccess.EntityFramework/CSharpCourse.EmployeesService.DataAccess.EntityFramework.csproj", "./EmployeesService.DataAccess.EntityFramework/"]
COPY ["./src/CSharpCourse.EmployeesService.DataAccess.Dapper/CSharpCourse.EmployeesService.DataAccess.Dapper.csproj", "./EmployeesService.DataAccess.Dapper/"]
COPY ["./src/CSharpCourse.EmployeesService.PresentationModels/CSharpCourse.EmployeesService.PresentationModels.csproj", "./EmployeesService.PresentationModels/"]
COPY ["./src/CSharpCourse.EmployeesService.Migrations/CSharpCourse.EmployeesService.Migrations.csproj", "./EmployeesService.Migrations/"]
COPY ["./src/CSharpCourse.EmployeesService.Hosting/CSharpCourse.EmployeesService.Hosting.csproj", "./EmployeesService.Hosting/"]
RUN dotnet restore "./EmployeesService.Hosting/CSharpCourse.EmployeesService.Hosting.csproj"

COPY "./Directory.build.props" .
COPY "./Directory.build.targets" .
COPY "./src" .
WORKDIR "/src/CSharpCourse.EmployeesService.Hosting/."

RUN dotnet build "CSharpCourse.EmployeesService.Hosting.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CSharpCourse.EmployeesService.Hosting.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CSharpCourse.EmployeesService.Hosting.dll"]
