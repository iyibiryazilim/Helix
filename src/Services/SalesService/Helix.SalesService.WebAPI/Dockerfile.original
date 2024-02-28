#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Services/SalesService/Helix.SalesService.WebAPI/Helix.SalesService.WebAPI.csproj", "src/Services/SalesService/Helix.SalesService.WebAPI/"]
COPY ["src/BuildingBlocks/EventBus/Helix.EventBus.Base/Helix.EventBus.Base.csproj", "src/BuildingBlocks/EventBus/Helix.EventBus.Base/"]
COPY ["src/BuildingBlocks/EventBus/Helix.EventBus.Factory/Helix.EventBus.Factory.csproj", "src/BuildingBlocks/EventBus/Helix.EventBus.Factory/"]
COPY ["src/BuildingBlocks/EventBus/Helix.EventBus.RabbitMQ/Helix.EventBus.RabbitMQ.csproj", "src/BuildingBlocks/EventBus/Helix.EventBus.RabbitMQ/"]
COPY ["src/Services/SalesService/Helix.SalesService.Application/Helix.SalesService.Application.csproj", "src/Services/SalesService/Helix.SalesService.Application/"]
COPY ["src/Services/SalesService/Helix.SalesService.Domain/Helix.SalesService.Domain.csproj", "src/Services/SalesService/Helix.SalesService.Domain/"]
COPY ["src/Services/SalesService/Helix.SalesService.Infrastructure/Helix.SalesService.Infrastructure.csproj", "src/Services/SalesService/Helix.SalesService.Infrastructure/"]
RUN dotnet restore "./src/Services/SalesService/Helix.SalesService.WebAPI/./Helix.SalesService.WebAPI.csproj"
COPY . .
WORKDIR "/src/src/Services/SalesService/Helix.SalesService.WebAPI"
RUN dotnet build "./Helix.SalesService.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Helix.SalesService.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Helix.SalesService.WebAPI.dll"]