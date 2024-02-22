#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Services/IdentityServer/Helix.IdentityServer.WebApi/Helix.IdentityServer.WebApi.csproj", "src/Services/IdentityServer/Helix.IdentityServer.WebApi/"]
COPY ["src/UserInterfaces/SysUI/Helix.UI.Sys.Module/Helix.UI.Sys.Module.csproj", "src/UserInterfaces/SysUI/Helix.UI.Sys.Module/"]
RUN dotnet restore "./src/Services/IdentityServer/Helix.IdentityServer.WebApi/./Helix.IdentityServer.WebApi.csproj"
COPY . .
WORKDIR "/src/src/Services/IdentityServer/Helix.IdentityServer.WebApi" 
RUN dotnet add package DevExtreme.AspNet.Core --version 21.2.5 
RUN dotnet build "./Helix.IdentityServer.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Helix.IdentityServer.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Helix.IdentityServer.WebApi.dll"]