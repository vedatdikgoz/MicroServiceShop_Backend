#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Services/Order/MicroServiceShop.Order.WebAPI/MicroServiceShop.Order.WebAPI.csproj", "Services/Order/MicroServiceShop.Order.WebAPI/"]
COPY ["Core/MicroServiceShop.Core/MicroServiceShop.Core.csproj", "Core/MicroServiceShop.Core/"]
COPY ["Services/Order/MicroServiceShop.Order.Application/MicroServiceShop.Order.Application.csproj", "Services/Order/MicroServiceShop.Order.Application/"]
COPY ["Services/Order/MicroServiceShop.Order.Domain/MicroServiceShop.Order.Domain.csproj", "Services/Order/MicroServiceShop.Order.Domain/"]
COPY ["Services/Order/MicroServiceShop.Order.Infrastructure/MicroServiceShop.Order.Infrastructure.csproj", "Services/Order/MicroServiceShop.Order.Infrastructure/"]
RUN dotnet restore "./Services/Order/MicroServiceShop.Order.WebAPI/MicroServiceShop.Order.WebAPI.csproj"
COPY . .
WORKDIR "/src/Services/Order/MicroServiceShop.Order.WebAPI"
RUN dotnet build "./MicroServiceShop.Order.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./MicroServiceShop.Order.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MicroServiceShop.Order.WebAPI.dll"]