#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/ApiGateways/WebApiGateway/Helix.Web.ApiGateway/Helix.Web.ApiGateway.csproj", "src/ApiGateways/WebApiGateway/Helix.Web.ApiGateway/"]
RUN dotnet restore "./src/ApiGateways/WebApiGateway/Helix.Web.ApiGateway/./Helix.Web.ApiGateway.csproj"
COPY . .
WORKDIR "/src/src/ApiGateways/WebApiGateway/Helix.Web.ApiGateway"
RUN dotnet build "./Helix.Web.ApiGateway.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Helix.Web.ApiGateway.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Helix.Web.ApiGateway.dll"]