#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Services/Cargo/MicroServiceShop.Cargo.WebAPI/MicroServiceShop.Cargo.WebAPI.csproj", "Services/Cargo/MicroServiceShop.Cargo.WebAPI/"]
COPY ["Core/MicroServiceShop.Core/MicroServiceShop.Core.csproj", "Core/MicroServiceShop.Core/"]
RUN dotnet restore "./Services/Cargo/MicroServiceShop.Cargo.WebAPI/MicroServiceShop.Cargo.WebAPI.csproj"
COPY . .
WORKDIR "/src/Services/Cargo/MicroServiceShop.Cargo.WebAPI"
RUN dotnet build "./MicroServiceShop.Cargo.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./MicroServiceShop.Cargo.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MicroServiceShop.Cargo.WebAPI.dll"]