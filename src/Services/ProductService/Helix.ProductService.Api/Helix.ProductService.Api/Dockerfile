#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Services/ProductService/Helix.ProductService.Api/Helix.ProductService.Api/Helix.ProductService.Api.csproj", "src/Services/ProductService/Helix.ProductService.Api/Helix.ProductService.Api/"]
COPY ["src/BuildingBlocks/EventBus/Helix.EventBus.Base/Helix.EventBus.Base.csproj", "src/BuildingBlocks/EventBus/Helix.EventBus.Base/"]
COPY ["src/BuildingBlocks/EventBus/Helix.EventBus.Factory/Helix.EventBus.Factory.csproj", "src/BuildingBlocks/EventBus/Helix.EventBus.Factory/"]
COPY ["src/BuildingBlocks/EventBus/Helix.EventBus.RabbitMQ/Helix.EventBus.RabbitMQ.csproj", "src/BuildingBlocks/EventBus/Helix.EventBus.RabbitMQ/"]
COPY ["src/Core/DataAccess/Helix.Tiger.DataAccess/Helix.Tiger.DataAccess.csproj", "src/Core/DataAccess/Helix.Tiger.DataAccess/"]
COPY ["src/Core/Entity/Helix.SharedEntity/Helix.SharedEntity.csproj", "src/Core/Entity/Helix.SharedEntity/"]
COPY ["src/Core/Entity/Helix.Tiger.Entity/Helix.Tiger.Entity.csproj", "src/Core/Entity/Helix.Tiger.Entity/"]
COPY ["src/Core/DataAccess/Helix.Queries/Helix.Queries.csproj", "src/Core/DataAccess/Helix.Queries/"]
COPY ["src/Services/ProductService/Helix.ProductService.Application/Helix.ProductService.Application.csproj", "src/Services/ProductService/Helix.ProductService.Application/"]
COPY ["src/Services/ProductService/Helix.ProductService.Domain/Helix.ProductService.Domain.csproj", "src/Services/ProductService/Helix.ProductService.Domain/"]
COPY ["src/Services/ProductService/Helix.ProductService.Infrastructure/Helix.ProductService.Infrastructure.csproj", "src/Services/ProductService/Helix.ProductService.Infrastructure/"]
RUN dotnet restore "./src/Services/ProductService/Helix.ProductService.Api/Helix.ProductService.Api/./Helix.ProductService.Api.csproj"
COPY . .
WORKDIR "/src/src/Services/ProductService/Helix.ProductService.Api/Helix.ProductService.Api"
RUN dotnet build "./Helix.ProductService.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Helix.ProductService.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Helix.ProductService.Api.dll"]