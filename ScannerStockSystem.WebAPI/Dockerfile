#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ScannerStockSystem.WebAPI/ScannerStockSystem.WebAPI.csproj", "ScannerStockSystem.WebAPI/"]
COPY ["ScannerStockSystem.Application/ScannerStockSystem.Application.csproj", "ScannerStockSystem.Application/"]
COPY ["ScannerStockSystem.Domain/ScannerStockSystem.Domain.csproj", "ScannerStockSystem.Domain/"]
COPY ["ScannerStockSystem.Shared/ScannerStockSystem.Shared.csproj", "ScannerStockSystem.Shared/"]
COPY ["ScannerStockSystem.Infrastructure/ScannerStockSystem.Infrastructure.csproj", "ScannerStockSystem.Infrastructure/"]
COPY ["ScannerStockSystem.Persistence/ScannerStockSystem.Persistence.csproj", "ScannerStockSystem.Persistence/"]
RUN dotnet restore "./ScannerStockSystem.WebAPI/ScannerStockSystem.WebAPI.csproj"
COPY . .
WORKDIR "/src/ScannerStockSystem.WebAPI"
RUN dotnet build "./ScannerStockSystem.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ScannerStockSystem.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ScannerStockSystem.WebAPI.dll"]