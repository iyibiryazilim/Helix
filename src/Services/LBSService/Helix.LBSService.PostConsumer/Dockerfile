#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/runtime:8.0-nanoserver-1809 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0-nanoserver-1809 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Services/LBSService/Helix.LBSService.PostConsumer/Helix.LBSService.PostConsumer.csproj", "src/Services/LBSService/Helix.LBSService.PostConsumer/"]
COPY ["src/BuildingBlocks/EventBus/Helix.EventBus.Base/Helix.EventBus.Base.csproj", "src/BuildingBlocks/EventBus/Helix.EventBus.Base/"]
COPY ["src/BuildingBlocks/EventBus/Helix.EventBus.Factory/Helix.EventBus.Factory.csproj", "src/BuildingBlocks/EventBus/Helix.EventBus.Factory/"]
COPY ["src/BuildingBlocks/EventBus/Helix.EventBus.RabbitMQ/Helix.EventBus.RabbitMQ.csproj", "src/BuildingBlocks/EventBus/Helix.EventBus.RabbitMQ/"]
COPY ["src/Services/LBSService/Helix.LBSService.Base/Helix.LBSService.Base.csproj", "src/Services/LBSService/Helix.LBSService.Base/"]
RUN dotnet restore "./src/Services/LBSService/Helix.LBSService.PostConsumer/./Helix.LBSService.PostConsumer.csproj"
COPY . .
WORKDIR "/src/src/Services/LBSService/Helix.LBSService.PostConsumer"
RUN dotnet build "./Helix.LBSService.PostConsumer.csproj" -c %BUILD_CONFIGURATION% -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Helix.LBSService.PostConsumer.csproj" -c %BUILD_CONFIGURATION% -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Helix.LBSService.PostConsumer.dll"]