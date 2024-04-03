#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Catalog/DevInterview.Catalog.Api/DevInterview.Catalog.Api.csproj", "Catalog/DevInterview.Catalog.Api/"]
COPY ["Catalog/DevInterview.Catalog.Application/DevInterview.Catalog.Application.csproj", "Catalog/DevInterview.Catalog.Application/"]
COPY ["Catalog/DevInterview.Catalog.Domain/DevInterview.Catalog.Domain.csproj", "Catalog/DevInterview.Catalog.Domain/"]
COPY ["Catalog/DevInterview.Catalog.Infrastructure/DevInterview.Catalog.Infrastructure.csproj", "Catalog/DevInterview.Catalog.Infrastructure/"]
RUN dotnet restore "./Catalog/DevInterview.Catalog.Api/./DevInterview.Catalog.Api.csproj"
COPY . .
WORKDIR "/src/Catalog/DevInterview.Catalog.Api"
RUN dotnet build "./DevInterview.Catalog.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./DevInterview.Catalog.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DevInterview.Catalog.Api.dll"]