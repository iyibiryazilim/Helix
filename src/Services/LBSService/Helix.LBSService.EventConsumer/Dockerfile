#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Services/LBSService/Helix.LBSService.EventConsumer/Helix.LBSService.EventConsumer.csproj", "src/Services/LBSService/Helix.LBSService.EventConsumer/"]
COPY ["src/BuildingBlocks/EventBus/Helix.EventBus.Base/Helix.EventBus.Base.csproj", "src/BuildingBlocks/EventBus/Helix.EventBus.Base/"]
COPY ["src/BuildingBlocks/EventBus/Helix.EventBus.Factory/Helix.EventBus.Factory.csproj", "src/BuildingBlocks/EventBus/Helix.EventBus.Factory/"]
COPY ["src/BuildingBlocks/EventBus/Helix.EventBus.RabbitMQ/Helix.EventBus.RabbitMQ.csproj", "src/BuildingBlocks/EventBus/Helix.EventBus.RabbitMQ/"]
RUN dotnet restore "./src/Services/LBSService/Helix.LBSService.EventConsumer/./Helix.LBSService.EventConsumer.csproj"
COPY . .
WORKDIR "/src/src/Services/LBSService/Helix.LBSService.EventConsumer"
RUN dotnet build "./Helix.LBSService.EventConsumer.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Helix.LBSService.EventConsumer.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Helix.LBSService.EventConsumer.dll"]