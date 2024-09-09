

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["IdentityServer/MicroServiceShop.IdentityServer/MicroServiceShop.IdentityServer.csproj", "IdentityServer/MicroServiceShop.IdentityServer/"]
RUN dotnet restore "./IdentityServer/MicroServiceShop.IdentityServer/MicroServiceShop.IdentityServer.csproj"
COPY . .
WORKDIR "/src/IdentityServer/MicroServiceShop.IdentityServer"
RUN dotnet build "./MicroServiceShop.IdentityServer.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./MicroServiceShop.IdentityServer.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MicroServiceShop.IdentityServer.dll"]