#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Students/DevInterview.Students.Api/DevInterview.Students.Api.csproj", "Students/DevInterview.Students.Api/"]
COPY ["Students/DevInterview.Students.Application/DevInterview.Students.Application.csproj", "Students/DevInterview.Students.Application/"]
COPY ["Students/DevInterview.Students.Domain/DevInterview.Students.Domain.csproj", "Students/DevInterview.Students.Domain/"]
COPY ["Students/DevInterview.Students.Infrastructure/DevInterview.Students.Infrastructure.csproj", "Students/DevInterview.Students.Infrastructure/"]
RUN dotnet restore "./Students/DevInterview.Students.Api/./DevInterview.Students.Api.csproj"
COPY . .
WORKDIR "/src/Students/DevInterview.Students.Api"
RUN dotnet build "./DevInterview.Students.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./DevInterview.Students.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DevInterview.Students.Api.dll"]