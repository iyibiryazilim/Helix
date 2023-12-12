#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Services/LBSService/Helix.LBSService.WebAPI/Helix.LBSService.WebAPI.csproj", "src/Services/LBSService/Helix.LBSService.WebAPI/"]
RUN dotnet restore "./src/Services/LBSService/Helix.LBSService.WebAPI/./Helix.LBSService.WebAPI.csproj"
COPY . .
WORKDIR "/src/src/Services/LBSService/Helix.LBSService.WebAPI"
RUN dotnet build "./Helix.LBSService.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Helix.LBSService.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Helix.LBSService.WebAPI.dll"]